using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MobileBandSync.MSFTBandLib;

public static class AsyncHelpers
{
	private class ExclusiveSynchronizationContext : SynchronizationContext
	{
		private bool done;

		private readonly AutoResetEvent workItemsWaiting = new AutoResetEvent(initialState: false);

		private readonly Queue<Tuple<SendOrPostCallback, object>> items = new Queue<Tuple<SendOrPostCallback, object>>();

		public Exception InnerException { get; set; }

		public override void Send(SendOrPostCallback d, object state)
		{
			throw new NotSupportedException("We cannot send to our same thread");
		}

		public override void Post(SendOrPostCallback d, object state)
		{
			lock (items)
			{
				items.Enqueue(Tuple.Create(d, state));
			}
			workItemsWaiting.Set();
		}

		public void EndMessageLoop()
		{
			Post(delegate
			{
				done = true;
			}, null);
		}

		public void BeginMessageLoop()
		{
			while (!done)
			{
				Tuple<SendOrPostCallback, object> tuple = null;
				lock (items)
				{
					if (items.Count > 0)
					{
						tuple = items.Dequeue();
					}
				}
				if (tuple != null)
				{
					tuple.Item1(tuple.Item2);
					if (InnerException != null)
					{
						throw new AggregateException("AsyncHelpers.Run method threw an exception.", InnerException);
					}
				}
				else
				{
					workItemsWaiting.WaitOne();
				}
			}
		}

		public override SynchronizationContext CreateCopy()
		{
			return this;
		}
	}

	public static void RunSync(Func<Task> task)
	{
		SynchronizationContext current = SynchronizationContext.Current;
		ExclusiveSynchronizationContext synch = new ExclusiveSynchronizationContext();
		SynchronizationContext.SetSynchronizationContext(synch);
		synch.Post(async delegate
		{
			try
			{
				await task();
			}
			catch (Exception innerException)
			{
				synch.InnerException = innerException;
				throw;
			}
			finally
			{
				synch.EndMessageLoop();
			}
		}, null);
		synch.BeginMessageLoop();
		SynchronizationContext.SetSynchronizationContext(current);
	}

	public static T RunSync<T>(Func<Task<T>> task)
	{
		SynchronizationContext current = SynchronizationContext.Current;
		ExclusiveSynchronizationContext synch = new ExclusiveSynchronizationContext();
		SynchronizationContext.SetSynchronizationContext(synch);
		T ret = default(T);
		synch.Post(async delegate
		{
			try
			{
				_ = ret;
				ret = await task();
			}
			catch (Exception innerException)
			{
				synch.InnerException = innerException;
				throw;
			}
			finally
			{
				synch.EndMessageLoop();
			}
		}, null);
		synch.BeginMessageLoop();
		SynchronizationContext.SetSynchronizationContext(current);
		return ret;
	}
}
