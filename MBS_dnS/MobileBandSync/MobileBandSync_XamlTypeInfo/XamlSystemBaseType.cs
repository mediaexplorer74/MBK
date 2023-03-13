using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Windows.UI.Xaml.Markup;

namespace MobileBandSync.MobileBandSync_XamlTypeInfo
{
	// Token: 0x02000009 RID: 9
	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class XamlSystemBaseType : IXamlType
	{
		// Token: 0x06000118 RID: 280 RVA: 0x000088E0 File Offset: 0x00006AE0
		public XamlSystemBaseType(string fullName, Type underlyingType)
		{
			this._fullName = fullName;
			this._underlyingType = underlyingType;
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000119 RID: 281 RVA: 0x000088F6 File Offset: 0x00006AF6
		public string FullName
		{
			get
			{
				return this._fullName;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600011A RID: 282 RVA: 0x000088FE File Offset: 0x00006AFE
		public Type UnderlyingType
		{
			get
			{
				return this._underlyingType;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual IXamlType BaseType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual IXamlMember ContentProperty
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual IXamlMember GetMember(string name)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual bool IsArray
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual bool IsCollection
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000120 RID: 288 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual bool IsConstructible
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual bool IsDictionary
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual bool IsMarkupExtension
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual bool IsBindable
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual bool IsReturnTypeStub
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual bool IsLocalType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual IXamlType ItemType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual IXamlType KeyType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual object ActivateInstance()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual void AddToMap(object instance, object key, object item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual void AddToVector(object instance, object item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual void RunInitializer()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00008906 File Offset: 0x00006B06
		public virtual object CreateFromString(string input)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000062 RID: 98
		private string _fullName;

		// Token: 0x04000063 RID: 99
		private Type _underlyingType;
	}
}
