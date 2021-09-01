using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HtmlSanitizerTest
{
    [TestFixture]
    public class HtmlSanitizerTest
    {
        [Test]
        public void Test20210901_001()
        {
            Console.WriteLine("hello world!");
        }

        [Test]
        public void Test20210901_002()
        {
            var html = @"<script>alert('xss')</script><div onload=""alert('xss')""";
            CrossSiteScriptingValidation.ValidateDangerousString(html, 1);
            Console.WriteLine();
        }
    }
}
