using LinaqHTML.Models;
using LinaqHTML.Models.HTMLTags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaqHTML
{
    public class Document : IDisposable
    {
        public BaseTagElement Header { get; private set; }
        public List<BaseTagElement> Children { get; set; } 

        public Document()
        {
            Header = new BaseTagElement();
        }

        public string GetContent()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Children)
            {
                sb.AppendLine(item.GetContent());
            }

            return sb.ToString();

        }

        private void GenerateAndSaveContent(string path)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<!DOCTYPE html>");

            sb.AppendLine("<html>");

            sb.AppendLine(Header.GetContent());

            sb.AppendLine(this.GetContent());

            sb.AppendLine("</html>");

            File.WriteAllText(path,sb.ToString());
        }

        public void SaveToFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path can not be empty.", nameof(path));

            if (File.Exists(path))
                path = Helpers.GetUniqueFilePath(path);

            GenerateAndSaveContent(path);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
