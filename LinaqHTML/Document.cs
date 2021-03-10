using LinaqHTML.Models;
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
        public BaseTagElement Head { get; private set; }
        public BaseTagElement Body { get; private set; }
        public List<BaseTagElement> Children { get; private set; } 

        public Document()
        {
            Children = new List<BaseTagElement>();
            // Head = new BaseTagElement();
            Body = new Body();

        }

        public string GetContent()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Children)
            {
                sb.AppendLine($"\t{item.GetContent()}");
            }

            return sb.ToString();

        }

        private void GenerateAndSaveContent(string path)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<!DOCTYPE html>");

            sb.AppendLine("<html>");

            //   sb.AppendLine(Head.GetContent());
            int i = 0;
            sb.AppendLine(Body.GetContent(i));
            sb.AppendLine(this.GetContent());

            sb.AppendLine("</html>");

            File.WriteAllText(path,sb.ToString());
        }

        public void SaveToFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path can not be empty.", nameof(path));

          //  if (File.Exists(path))
              //  path = Helpers.GetUniqueFilePath(path);

            GenerateAndSaveContent(path);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
