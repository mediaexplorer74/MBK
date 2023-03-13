using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x02000061 RID: 97
	public static class AsyncHelpers
	{
		// Token: 0x06000373 RID: 883 RVA: 0x0000B188 File Offset: 0x00009388
		public static void RunSync(Func<Task> task)
		{
			SynchronizationContext synchronizationContext = SynchronizationContext.Current;
			AsyncHelpers.ExclusiveSynchronizationContext synch = new AsyncHelpers.ExclusiveSynchronizationContext();
			SynchronizationContext.SetSynchronizationContext(synch);
			synch.Post(async delegate(object _)
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
			SynchronizationContext.SetSynchronizationContext(synchronizationContext);
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000B1E8 File Offset: 0x000093E8
		public static T RunSync<T>(Func<Task<T>> task)
		{
			AsyncHelpers.<>c__DisplayClass1_0<T> CS$<>8__locals1 = new AsyncHelpers.<>c__DisplayClass1_0<T>();
			CS$<>8__locals1.task = task;
			SynchronizationContext synchronizationContext = SynchronizationContext.Current;
			CS$<>8__locals1.synch = new AsyncHelpers.ExclusiveSynchronizationContext();
			SynchronizationContext.SetSynchronizationContext(CS$<>8__locals1.synch);
			CS$<>8__locals1.ret = default(T);
			CS$<>8__locals1.synch.Post(async delegate(object _)
			{
				try
				{
					AsyncHelpers.<>c__DisplayClass1_0<T> CS$<>8__locals2 = CS$<>8__locals1;
					T ret = CS$<>8__locals2.ret;
					T ret2 = await CS$<>8__locals1.task();
					CS$<>8__locals2.ret = ret2;
					CS$<>8__locals2 = null;
				}
				catch (Exception innerException)
				{
					CS$<>8__locals1.synch.InnerException = innerException;
					throw;
				}
				finally
				{
					CS$<>8__locals1.synch.EndMessageLoop();
				}
			}, null);
			CS$<>8__locals1.synch.BeginMessageLoop();
			SynchronizationContext.SetSynchronizationContext(synchronizationContext);
			return CS$<>8__locals1.ret;
		}

		// Token: 0x020000EC RID: 236
		private class ExclusiveSynchronizationContext : SynchronizationContext
		{
			// Token: 0x17000204 RID: 516
			// (get) Token: 0x060006DE RID: 1758 RVA: 0x0001700E File Offset: 0x0001520E
			// (set) Token: 0x060006DF RID: 1759 RVA: 0x00017016 File Offset: 0x00015216
			public Exception InnerException { get; set; }

			// Token: 0x060006E0 RID: 1760 RVA: 0x0001701F File Offset: 0x0001521F
			public override void Send(SendOrPostCallback d, object state)
			{
				throw new NotSupportedException("We cannot send to our same thread");
			}

			// Token: 0x060006E1 RID: 1761 RVA: 0x0001702C File Offset: 0x0001522C
			public override void Post(SendOrPostCallback d, object state)
			{
				Queue<Tuple<SendOrPostCallback, object>> obj = this.items;
				lock (obj)
				{
					this.items.Enqueue(Tuple.Create<SendOrPostCallback, object>(d, state));
				}
				this.workItemsWaiting.Set();
			}

			// Token: 0x060006E2 RID: 1762 RVA: 0x00017084 File Offset: 0x00015284
			public void EndMessageLoop()
			{
				this.Post(delegate(object _)
				{
					this.done = true;
				}, null);
			}

			// Token: 0x060006E3 RID: 1763 RVA: 0x0001709C File Offset: 0x0001529C
			public void BeginMessageLoop()
			{
				while (!this.done)
				{
					Tuple<SendOrPostCallback, object> tuple = null;
					Queue<Tuple<SendOrPostCallback, object>> obj = this.items;
					lock (obj)
					{
						if (this.items.Count > 0)
						{
							tuple = this.items.Dequeue();
						}
					}
					if (tuple != null)
					{
						tuple.Item1(tuple.Item2);
						if (this.InnerException != null)
						{
							throw new AggregateException("AsyncHelpers.Run method threw an exception.", this.InnerException);
						}
					}
					else
					{
						this.workItemsWaiting.WaitOne();
					}
				}
			}

			// Token: 0x060006E4 RID: 1764 RVA: 0x00017138 File Offset: 0x00015338
			public override SynchronizationContext CreateCopy()
			{
				return this;
			}

			// Token: 0x04000594 RID: 1428
			private bool done;

			// Token: 0x04000596 RID: 1430
			private readonly AutoResetEvent workItemsWaiting = new AutoResetEvent(false);

			// Token: 0x04000597 RID: 1431
			private readonly Queue<Tuple<SendOrPostCallback, object>> items = new Queue<Tuple<SendOrPostCallback, object>>();
		}
	}
}
