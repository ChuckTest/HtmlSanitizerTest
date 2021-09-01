using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        }

        [Test]
        public void Test20210901_003()
        {
            //<img src=x onerror=alert(1)>
            var html = @"\u003C\u0069\u006D\u0067\u0020\u0073\u0072\u0063\u003D\u0078\u0020\u006F\u006E\u0065\u0072\u0072\u006F\u0072\u003D\u0061\u006C\u0065\u0072\u0074\u0028\u0031\u0029\u003E";
            CrossSiteScriptingValidation.ValidateDangerousString(html, 1);
        }

        [Test]
        public void Test20210901_004()
        {
            Employee employee = new Employee();
            employee.FullName = "chucklu";
            var result = JsonConvert.SerializeObject(employee);
            Console.WriteLine(result);
            //{"FullName":"chucklu"}
        }

        [Test]
        public void Test20210901_005()
        {
            var html =
                @"\u003C\u0069\u006D\u0067\u0020\u0073\u0072\u0063\u003D\u0078\u0020\u006F\u006E\u0065\u0072\u0072\u006F\u0072\u003D\u0061\u006C\u0065\u0072\u0074\u0028\u0031\u0029\u003E";

            var jsonString = "{ \"FullName\":\"" + html + "\"}";
            //Console.WriteLine(jsonString);
            var result = JsonConvert.DeserializeObject<Employee>(jsonString);
            Console.WriteLine(result?.FullName);
        }
    }

    public class Employee
    {
        public string FullName { get; set; }
    }
}
