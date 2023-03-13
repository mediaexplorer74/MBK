namespace MobileBandSync.MobileBandSync_XamlTypeInfo
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using Windows.UI.Xaml.Markup;

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0"), DebuggerNonUserCode]
    internal class XamlUserType : XamlSystemBaseType
    {
        private XamlTypeInfoProvider _provider;
        private IXamlType _baseType;
        private bool _isArray;
        private bool _isMarkupExtension;
        private bool _isBindable;
        private bool _isReturnTypeStub;
        private bool _isLocalType;
        private string _contentPropertyName;
        private string _itemTypeName;
        private string _keyTypeName;
        private Dictionary<string, string> _memberNames;
        private Dictionary<string, object> _enumValues;

        public XamlUserType(XamlTypeInfoProvider provider, string fullName, Type fullType, IXamlType baseType);
        public override object ActivateInstance();
        public void AddEnumValue(string name, object value);
        public void AddMemberName(string shortName);
        public override void AddToMap(object instance, object key, object item);
        public override void AddToVector(object instance, object item);
        public override object CreateFromString(string input);
        public override IXamlMember GetMember(string name);
        public override void RunInitializer();
        public void SetContentPropertyName(string contentPropertyName);
        public void SetIsArray();
        public void SetIsBindable();
        public void SetIsLocalType();
        public void SetIsMarkupExtension();
        public void SetIsReturnTypeStub();
        public void SetItemTypeName(string itemTypeName);
        public void SetKeyTypeName(string keyTypeName);

        public override IXamlType BaseType { get; }

        public override bool IsArray { get; }

        public override bool IsCollection { get; }

        public override bool IsConstructible { get; }

        public override bool IsDictionary { get; }

        public override bool IsMarkupExtension { get; }

        public override bool IsBindable { get; }

        public override bool IsReturnTypeStub { get; }

        public override bool IsLocalType { get; }

        public override IXamlMember ContentProperty { get; }

        public override IXamlType ItemType { get; }

        public override IXamlType KeyType { get; }

        public MobileBandSync.MobileBandSync_XamlTypeInfo.Activator Activator { get; set; }

        public AddToCollection CollectionAdd { get; set; }

        public AddToDictionary DictionaryAdd { get; set; }
    }
}

