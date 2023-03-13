System.NotSupportedException: Unknown attribute 'ContentType' in module 'WinRTXamlToolkit.Controls.DataVisualization.dll' in assembly name 'Windows, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime'.
   at Reflector.CodeModel.Assembly.Module.ParseAssemblyReference(String value)
   at Reflector.CodeModel.Assembly.Module.ReadTypeFullyQualifiedNameIntern(String typeName, String assemblyReference)
   at Reflector.CodeModel.Assembly.Module.ReadTypeFullyQualifiedName(String typeName, String assemblyReference)
   at Reflector.CodeModel.Assembly.Module.ReadTypeFullyQualifiedName(String fullyQualifiedName)
   at Reflector.CodeModel.Assembly.Module.ReadTypeFullyQualifiedName(ByteArrayReader reader)
   at Reflector.CodeModel.Assembly.CustomAttribute.ReadValue(ByteArrayReader reader, String namespaceName, String name)
   at Reflector.CodeModel.Assembly.CustomAttribute.ReadValue(ByteArrayReader reader, IType type)
   at Reflector.CodeModel.Assembly.CustomAttribute.ReadMemberInitializer(ByteArrayReader reader)
   at Reflector.CodeModel.Assembly.CustomAttribute.get_Arguments()
   at Reflector.Disassembler.IteratorAndAsync.Async.AsyncUtils.<>c.<GatherDataForAsync>b__3_0(ICustomAttribute attribute)
   at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   at System.Linq.Enumerable.Any[TSource](IEnumerable`1 source, Func`2 predicate)
   at Reflector.Disassembler.IteratorAndAsync.Async.AsyncUtils.GatherDataForAsync(IMethodDeclaration targetMethod, ClonerMethod cloner)
   at Reflector.Disassembler.Optimizer.GenerateAsync(IMethodDeclaration value, ClonerMethod cloner, Configuration configuration, ITypeDeclaration declaringType)
   at Reflector.Disassembler.Optimizer.TransformMethodDeclaration(IMethodDeclaration value)
   at Reflector.Disassembler.Disassembler.TransformMethodDeclaration(IMethodDeclaration value)
   at Reflector.CodeModel.Visitor.Transformer.TransformMethodDeclarationCollection(IMethodDeclarationCollection methods)
   at Reflector.Disassembler.Disassembler.TransformTypeDeclaration(ITypeDeclaration value)
   at Reflector.CodeModel.Visitor.Transformer.TransformTypeDeclarationCollection(ITypeDeclarationCollection value)
   at Reflector.Disassembler.Disassembler.TransformTypeDeclaration(ITypeDeclaration value)
   at Reflector.Application.Translator.TranslateTypeDeclaration(ITypeDeclaration value, Boolean memberDeclarationList, Boolean methodDeclarationBody)
   at Reflector.Application.ExportSource.CodeFile.WriteToOutput(ILanguageWriterConfiguration configuration, ILanguage language, ITranslator disassembler)
namespace MobileBandSync
{
}

