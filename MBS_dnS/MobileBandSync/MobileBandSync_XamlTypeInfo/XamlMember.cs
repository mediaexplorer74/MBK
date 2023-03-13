using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Windows.UI.Xaml.Markup;

namespace MobileBandSync.MobileBandSync_XamlTypeInfo
{
	// Token: 0x02000010 RID: 16
	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class XamlMember : IXamlMember
	{
		// Token: 0x06000164 RID: 356 RVA: 0x00008C27 File Offset: 0x00006E27
		public XamlMember(XamlTypeInfoProvider provider, string name, string typeName)
		{
			this._name = name;
			this._typeName = typeName;
			this._provider = provider;
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00008C44 File Offset: 0x00006E44
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000166 RID: 358 RVA: 0x00008C4C File Offset: 0x00006E4C
		public IXamlType Type
		{
			get
			{
				return this._provider.GetXamlTypeByName(this._typeName);
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00008C5F File Offset: 0x00006E5F
		public void SetTargetTypeName(string targetTypeName)
		{
			this._targetTypeName = targetTypeName;
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000168 RID: 360 RVA: 0x00008C68 File Offset: 0x00006E68
		public IXamlType TargetType
		{
			get
			{
				return this._provider.GetXamlTypeByName(this._targetTypeName);
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00008C7B File Offset: 0x00006E7B
		public void SetIsAttachable()
		{
			this._isAttachable = true;
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600016A RID: 362 RVA: 0x00008C84 File Offset: 0x00006E84
		public bool IsAttachable
		{
			get
			{
				return this._isAttachable;
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00008C8C File Offset: 0x00006E8C
		public void SetIsDependencyProperty()
		{
			this._isDependencyProperty = true;
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00008C95 File Offset: 0x00006E95
		public bool IsDependencyProperty
		{
			get
			{
				return this._isDependencyProperty;
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00008C9D File Offset: 0x00006E9D
		public void SetIsReadOnly()
		{
			this._isReadOnly = true;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00008CA6 File Offset: 0x00006EA6
		public bool IsReadOnly
		{
			get
			{
				return this._isReadOnly;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600016F RID: 367 RVA: 0x00008CAE File Offset: 0x00006EAE
		// (set) Token: 0x06000170 RID: 368 RVA: 0x00008CB6 File Offset: 0x00006EB6
		public Getter Getter { get; set; }

		// Token: 0x06000171 RID: 369 RVA: 0x00008CBF File Offset: 0x00006EBF
		public object GetValue(object instance)
		{
			if (this.Getter != null)
			{
				return this.Getter(instance);
			}
			throw new InvalidOperationException("GetValue");
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000172 RID: 370 RVA: 0x00008CE0 File Offset: 0x00006EE0
		// (set) Token: 0x06000173 RID: 371 RVA: 0x00008CE8 File Offset: 0x00006EE8
		public Setter Setter { get; set; }

		// Token: 0x06000174 RID: 372 RVA: 0x00008CF1 File Offset: 0x00006EF1
		public void SetValue(object instance, object value)
		{
			if (this.Setter != null)
			{
				this.Setter(instance, value);
				return;
			}
			throw new InvalidOperationException("SetValue");
		}

		// Token: 0x04000073 RID: 115
		private XamlTypeInfoProvider _provider;

		// Token: 0x04000074 RID: 116
		private string _name;

		// Token: 0x04000075 RID: 117
		private bool _isAttachable;

		// Token: 0x04000076 RID: 118
		private bool _isDependencyProperty;

		// Token: 0x04000077 RID: 119
		private bool _isReadOnly;

		// Token: 0x04000078 RID: 120
		private string _typeName;

		// Token: 0x04000079 RID: 121
		private string _targetTypeName;
	}
}
