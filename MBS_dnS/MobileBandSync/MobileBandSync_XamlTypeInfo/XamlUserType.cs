using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Markup;

namespace MobileBandSync.MobileBandSync_XamlTypeInfo
{
	// Token: 0x0200000D RID: 13
	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class XamlUserType : XamlSystemBaseType
	{
		// Token: 0x06000139 RID: 313 RVA: 0x0000890D File Offset: 0x00006B0D
		public XamlUserType(XamlTypeInfoProvider provider, string fullName, Type fullType, IXamlType baseType) : base(fullName, fullType)
		{
			this._provider = provider;
			this._baseType = baseType;
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00008926 File Offset: 0x00006B26
		public override IXamlType BaseType
		{
			get
			{
				return this._baseType;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600013B RID: 315 RVA: 0x0000892E File Offset: 0x00006B2E
		public override bool IsArray
		{
			get
			{
				return this._isArray;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00008936 File Offset: 0x00006B36
		public override bool IsCollection
		{
			get
			{
				return this.CollectionAdd != null;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00008941 File Offset: 0x00006B41
		public override bool IsConstructible
		{
			get
			{
				return this.Activator != null;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600013E RID: 318 RVA: 0x0000894C File Offset: 0x00006B4C
		public override bool IsDictionary
		{
			get
			{
				return this.DictionaryAdd != null;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00008957 File Offset: 0x00006B57
		public override bool IsMarkupExtension
		{
			get
			{
				return this._isMarkupExtension;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000140 RID: 320 RVA: 0x0000895F File Offset: 0x00006B5F
		public override bool IsBindable
		{
			get
			{
				return this._isBindable;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00008967 File Offset: 0x00006B67
		public override bool IsReturnTypeStub
		{
			get
			{
				return this._isReturnTypeStub;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000142 RID: 322 RVA: 0x0000896F File Offset: 0x00006B6F
		public override bool IsLocalType
		{
			get
			{
				return this._isLocalType;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000143 RID: 323 RVA: 0x00008977 File Offset: 0x00006B77
		public override IXamlMember ContentProperty
		{
			get
			{
				return this._provider.GetMemberByLongName(this._contentPropertyName);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000144 RID: 324 RVA: 0x0000898A File Offset: 0x00006B8A
		public override IXamlType ItemType
		{
			get
			{
				return this._provider.GetXamlTypeByName(this._itemTypeName);
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000145 RID: 325 RVA: 0x0000899D File Offset: 0x00006B9D
		public override IXamlType KeyType
		{
			get
			{
				return this._provider.GetXamlTypeByName(this._keyTypeName);
			}
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000089B0 File Offset: 0x00006BB0
		public override IXamlMember GetMember(string name)
		{
			if (this._memberNames == null)
			{
				return null;
			}
			string longMemberName;
			if (this._memberNames.TryGetValue(name, out longMemberName))
			{
				return this._provider.GetMemberByLongName(longMemberName);
			}
			return null;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000089E5 File Offset: 0x00006BE5
		public override object ActivateInstance()
		{
			return this.Activator();
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000089F2 File Offset: 0x00006BF2
		public override void AddToMap(object instance, object key, object item)
		{
			this.DictionaryAdd(instance, key, item);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00008A02 File Offset: 0x00006C02
		public override void AddToVector(object instance, object item)
		{
			this.CollectionAdd(instance, item);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00008A11 File Offset: 0x00006C11
		public override void RunInitializer()
		{
			RuntimeHelpers.RunClassConstructor(base.UnderlyingType.TypeHandle);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00008A24 File Offset: 0x00006C24
		public override object CreateFromString(string input)
		{
			if (this._enumValues != null)
			{
				int num = 0;
				foreach (string text in input.Split(new char[]
				{
					','
				}))
				{
					int num2 = 0;
					try
					{
						object value;
						if (this._enumValues.TryGetValue(text.Trim(), out value))
						{
							num2 = Convert.ToInt32(value);
						}
						else
						{
							try
							{
								num2 = Convert.ToInt32(text.Trim());
							}
							catch (FormatException)
							{
								foreach (string text2 in this._enumValues.Keys)
								{
									if (string.Compare(text.Trim(), text2, StringComparison.OrdinalIgnoreCase) == 0 && this._enumValues.TryGetValue(text2.Trim(), out value))
									{
										num2 = Convert.ToInt32(value);
										break;
									}
								}
							}
						}
						num |= num2;
					}
					catch (FormatException)
					{
						throw new ArgumentException(input, base.FullName);
					}
				}
				return num;
			}
			throw new ArgumentException(input, base.FullName);
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600014C RID: 332 RVA: 0x00008B58 File Offset: 0x00006D58
		// (set) Token: 0x0600014D RID: 333 RVA: 0x00008B60 File Offset: 0x00006D60
		public Activator Activator { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00008B69 File Offset: 0x00006D69
		// (set) Token: 0x0600014F RID: 335 RVA: 0x00008B71 File Offset: 0x00006D71
		public AddToCollection CollectionAdd { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000150 RID: 336 RVA: 0x00008B7A File Offset: 0x00006D7A
		// (set) Token: 0x06000151 RID: 337 RVA: 0x00008B82 File Offset: 0x00006D82
		public AddToDictionary DictionaryAdd { get; set; }

		// Token: 0x06000152 RID: 338 RVA: 0x00008B8B File Offset: 0x00006D8B
		public void SetContentPropertyName(string contentPropertyName)
		{
			this._contentPropertyName = contentPropertyName;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00008B94 File Offset: 0x00006D94
		public void SetIsArray()
		{
			this._isArray = true;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00008B9D File Offset: 0x00006D9D
		public void SetIsMarkupExtension()
		{
			this._isMarkupExtension = true;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00008BA6 File Offset: 0x00006DA6
		public void SetIsBindable()
		{
			this._isBindable = true;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00008BAF File Offset: 0x00006DAF
		public void SetIsReturnTypeStub()
		{
			this._isReturnTypeStub = true;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00008BB8 File Offset: 0x00006DB8
		public void SetIsLocalType()
		{
			this._isLocalType = true;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00008BC1 File Offset: 0x00006DC1
		public void SetItemTypeName(string itemTypeName)
		{
			this._itemTypeName = itemTypeName;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00008BCA File Offset: 0x00006DCA
		public void SetKeyTypeName(string keyTypeName)
		{
			this._keyTypeName = keyTypeName;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00008BD3 File Offset: 0x00006DD3
		public void AddMemberName(string shortName)
		{
			if (this._memberNames == null)
			{
				this._memberNames = new Dictionary<string, string>();
			}
			this._memberNames.Add(shortName, base.FullName + "." + shortName);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00008C05 File Offset: 0x00006E05
		public void AddEnumValue(string name, object value)
		{
			if (this._enumValues == null)
			{
				this._enumValues = new Dictionary<string, object>();
			}
			this._enumValues.Add(name, value);
		}

		// Token: 0x04000064 RID: 100
		private XamlTypeInfoProvider _provider;

		// Token: 0x04000065 RID: 101
		private IXamlType _baseType;

		// Token: 0x04000066 RID: 102
		private bool _isArray;

		// Token: 0x04000067 RID: 103
		private bool _isMarkupExtension;

		// Token: 0x04000068 RID: 104
		private bool _isBindable;

		// Token: 0x04000069 RID: 105
		private bool _isReturnTypeStub;

		// Token: 0x0400006A RID: 106
		private bool _isLocalType;

		// Token: 0x0400006B RID: 107
		private string _contentPropertyName;

		// Token: 0x0400006C RID: 108
		private string _itemTypeName;

		// Token: 0x0400006D RID: 109
		private string _keyTypeName;

		// Token: 0x0400006E RID: 110
		private Dictionary<string, string> _memberNames;

		// Token: 0x0400006F RID: 111
		private Dictionary<string, object> _enumValues;
	}
}
