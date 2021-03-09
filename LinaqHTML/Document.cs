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
        public Document()
        {

        }

        private async void GenerateAndSaveContent(string path)
        {
            using (StreamWriter file = new StreamWriter(path, append: true))
            {
                await file.WriteLineAsync("Test line");
            }
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
