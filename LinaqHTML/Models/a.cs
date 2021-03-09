using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaqHTML.Models
{
    public class a : BaseTagElement
    {
        protected override string StartTag { get => $"<a {_href}>"; set => throw new NotImplementedException(); }
        protected override string EndTag { get => "</a>"; set => throw new NotImplementedException(); }

        private string _href => string.IsNullOrEmpty(Href) ? string.Empty: $"href=\"{Href}\"";
        public string Href { get; set; }
    }
}
