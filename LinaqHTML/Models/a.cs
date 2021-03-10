using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaqHTML.Models
{
    public class a : BaseTagElement
    {
        protected override string StartTag => $"<a {_href}>";
        protected override string EndTag => "</a>";

        private string _href => string.IsNullOrEmpty(Href) ? string.Empty : $"href=\"{Href}\"";
        public string Href { get; set; }
    }
}
