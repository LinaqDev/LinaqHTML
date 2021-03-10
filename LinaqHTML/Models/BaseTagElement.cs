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
        protected abstract string StartTag { get; }
        protected abstract string EndTag { get; }
        public List<BaseTagElement> Children { get; internal set; }

        public BaseTagElement()
        {
            Id = Guid.NewGuid().ToString();
            Children = new List<BaseTagElement>();
        }

        public string GetContent(int i = 0)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{AdditionalTab(i - 1 )}{StartTag}");

            if (Children.Count > 0)
            {
                sb.AppendLine(); 
                i++;
            }
               
            foreach (var item in Children)
            {
                sb.AppendLine($"{tabs(i)}{item.GetContent(i)}");
            }

            i--;
            sb.Append($"{AdditionalTab(i)}{EndTag}");


            return sb.ToString();
        }

        private string AdditionalTab(int i) => Children.Count > 0 ? tabs(i) : "";

        private string tabs(int i)
        {
            var result = "";
            for (int j = 0; j < i; j++)
            {
                result += "\t";
            }
            return result;
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
