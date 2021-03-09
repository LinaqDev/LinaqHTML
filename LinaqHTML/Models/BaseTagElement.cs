using LinaqHTML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaqHTML
{
    public abstract class BaseTagElement
    {
        private string Id;
        public HTMLTag HTMLTag { get; set; }
        protected abstract string StartTag { get; set; }
        protected abstract string EndTag { get; set; }
        public List<BaseTagElement> Children { get; internal set; }

        public BaseTagElement()
        {
            Id = Guid.NewGuid().ToString();
            Children = new List<BaseTagElement>();
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
