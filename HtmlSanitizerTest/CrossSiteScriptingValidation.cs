using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlSanitizerTest
{
    public static class CrossSiteScriptingValidation
    {
        private static bool IsDangerousString(string str)
        {
            HtmlSanitizerHelper helper = new HtmlSanitizerHelper();
            helper.Sanitize(str);
            return helper.IsDangerous;
        }

        public static void ValidateDangerousString(string tempValue, int lineNumber, string fileName = null)
        {
            if (IsDangerousString(tempValue))
            {
                var ex = new Exception($"Dangerous xss string \"{tempValue}\" found at line {lineNumber} in file {fileName}");
                throw new ArgumentException($"Illegal string \"{tempValue}\" found.", ex);
            }
        }
    }
}
