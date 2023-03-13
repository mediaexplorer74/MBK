namespace MobileBandSync.MobileBandSync_XamlTypeInfo
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using Windows.UI.Xaml.Markup;

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0"), DebuggerNonUserCode]
    internal class XamlMember : IXamlMember
    {
        private XamlTypeInfoProvider _provider;
        private string _name;
        private bool _isAttachable;
        private bool _isDependencyProperty;
        private bool _isReadOnly;
        private string _typeName;
        private string _targetTypeName;

        public XamlMember(XamlTypeInfoProvider provider, string name, string typeName);
        public object GetValue(object instance);
        public void SetIsAttachable();
        public void SetIsDependencyProperty();
        public void SetIsReadOnly();
        public void SetTargetTypeName(string targetTypeName);
        public void SetValue(object instance, object value);

        public string Name { get; }

        public IXamlType Type { get; }

        public IXamlType TargetType { get; }

        public bool IsAttachable { get; }

        public bool IsDependencyProperty { get; }

        public bool IsReadOnly { get; }

        public MobileBandSync.MobileBandSync_XamlTypeInfo.Getter Getter { get; set; }

        public MobileBandSync.MobileBandSync_XamlTypeInfo.Setter Setter { get; set; }
    }
}

