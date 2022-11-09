using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace SourceGenerators
{
    [Generator]
    public class AtolDataProvidersGenerator : ISourceGenerator
    {
        private List<Type> _types;
        private Dictionary<string, string> _methodsNames;

        public void Initialize(GeneratorInitializationContext context)
        {
            _types = new List<Type>
            {
                typeof(int),
                typeof(string),
                typeof(DateTime),
                typeof(double),
                typeof(bool),
                typeof(byte[])
            };

            _methodsNames = new Dictionary<string, string>
            {
                {"Int32", "GetParamInt"},
                {"String", "GetParamString"},
                {"DateTime", "GetParamDateTime"},
                {"Double", "GetParamDouble"},
                {"Boolean", "GetParamBool"},
                {"Byte[]", "GetParamByteArray"}
            };
        }

        public void Execute(GeneratorExecutionContext context)
        {
            foreach (var type in _types)
            {
                var className = $"{GetLettersFromString(type.Name)}AtolDataProvider";
                var source = string.Format(@"using System;
using System.Collections.Generic;
using Atol.NET.Abstractions;

namespace Atol.NET.DataProviders
{{
    public class {0} : IAtolDataProvider
    {{
        private readonly IKktDriver _kkt;
        
        public {0}(IKktDriver kkt)
        {{
            _kkt = kkt;
        }}

        public Type GetResultType() => typeof({1});

        public object GetData(int constant)
        {{
            return _kkt.{2}(constant);
        }}
    }}
}}", className, type, _methodsNames[type.Name]);
                context.AddSource($"{className}.g.cs", SourceText.From(source, Encoding.UTF8));
            }
        }

        private string GetLettersFromString(string input)
        {
            return new string(input.Where(c => char.IsLetter(c)).ToArray());
        }
    }
}