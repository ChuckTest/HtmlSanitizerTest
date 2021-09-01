using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ganss.XSS;

namespace HtmlSanitizerTest
{
    public class HtmlSanitizerHelper
    {
        private HtmlSanitizer sanitizer = new HtmlSanitizer();

        public bool IsDangerous { get; private set; } = false;

        public HtmlSanitizerHelper()
        {
            sanitizer.RemovingTag += Sanitizer_RemovingTag;
            sanitizer.RemovingAttribute += Sanitizer_RemovingAttribute;
            sanitizer.RemovingStyle += Sanitizer_RemovingStyle;
            sanitizer.RemovingAtRule += Sanitizer_RemovingAtRule;
            sanitizer.RemovingComment += Sanitizer_RemovingComment;
            sanitizer.RemovingCssClass += Sanitizer_RemovingCssClass;
        }

        private void Sanitizer_RemovingCssClass(object sender, RemovingCssClassEventArgs e)
        {
            IsDangerous = true;
        }

        private void Sanitizer_RemovingComment(object sender, RemovingCommentEventArgs e)
        {
            IsDangerous = true;
        }

        private void Sanitizer_RemovingAtRule(object sender, RemovingAtRuleEventArgs e)
        {
            IsDangerous = true;
        }

        private void Sanitizer_RemovingStyle(object sender, RemovingStyleEventArgs e)
        {
            IsDangerous = true;
        }

        private void Sanitizer_RemovingAttribute(object sender, RemovingAttributeEventArgs e)
        {
            IsDangerous = true;
        }

        private void Sanitizer_RemovingTag(object sender, RemovingTagEventArgs e)
        {
            IsDangerous = true;
        }

        public string Sanitize(string str)
        {
            var result = sanitizer.Sanitize(str);
            return result;
        }
    }
}
