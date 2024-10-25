using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBuilder.Helpers
{

    public static class CodeWriterExtensions
    {
        public static StringBuilder AppendIndent(this StringBuilder code, int indent, string appendCode) => code.Append(TabsIndent(indent)).Append(appendCode);

        public static StringBuilder DecreaseIndent(this StringBuilder code, int indent, string appentCode) => code.Append(TabsIndent(indent, true)).Append(appentCode);


        private static string TabsIndent(int count, bool invers = false)
        {
            string indent = string.Empty;   
            for (int i = 0; i < count; i++)
                indent += invers? "\r" : "\t";
            return indent;
        }

    }

}
