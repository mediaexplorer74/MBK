namespace MobileBandSync.MobileBandSync_XamlTypeInfo
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using Windows.UI.Xaml.Markup;

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0"), DebuggerNonUserCode]
    internal class XamlSystemBaseType : IXamlType
    {
        private string _fullName;
        private Type _underlyingType;

        public XamlSystemBaseType(string fullName, Type underlyingType);
        public virtual object ActivateInstance();
        public virtual void AddToMap(object instance, object key, object item);
        public virtual void AddToVector(object instance, object item);
        public virtual object CreateFromString(string input);
        public virtual IXamlMember GetMember(string name);
        public virtual void RunInitializer();

        public string FullName { get; }

        public Type UnderlyingType { get; }

        public virtual IXamlType BaseType { get; }

        public virtual IXamlMember ContentProperty { get; }

        public virtual bool IsArray { get; }

        public virtual bool IsCollection { get; }

        public virtual bool IsConstructible { get; }

        public virtual bool IsDictionary { get; }

        public virtual bool IsMarkupExtension { get; }

        public virtual bool IsBindable { get; }

        public virtual bool IsReturnTypeStub { get; }

        public virtual bool IsLocalType { get; }

        public virtual IXamlType ItemType { get; }

        public virtual IXamlType KeyType { get; }
    }
}

