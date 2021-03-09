using LinaqHTML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaqHTML
{
    public class BaseTagElement
    {
        private string Id;
        private string StartTag { get; set; }
        private string EndTag { get; set; }
        public List<BaseTagElement> Children { get; internal set; }

        public BaseTagElement(HTMLTag hTMLTag)
        {

        }

        public string GetContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(StartTag);
            foreach (var item in Children)
            {
                sb.AppendLine(item.GetContent());
            }
            sb.AppendLine(EndTag);

            return sb.ToString();
        }

        public void AddChild(BaseTagElement tagElement)
        {
            Children.Add(tagElement);
        }

        public void RemoveChild(BaseTagElement tagElement)
        {
            Children.Remove(Children.FirstOrDefault(x => x.Id == tagElement.Id));
        }
    }
}
