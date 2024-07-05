using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIConverter
{
    public class FolderClearer
    {
        public string ResultFolderPath { get; set; }

        public FolderClearer()
        {
            ResultFolderPath = string.Empty;
        }

        public FolderClearer(string resultFolderPath)
        {
            ResultFolderPath = resultFolderPath;
        }

        public void ClearResultFolder()
        {
            CheckEmptyResultFolderPath();
            var files = Directory.GetFiles(ResultFolderPath);
            foreach (var file in files)
                if (file.EndsWith("png")) File.Delete(file);
        }

        private void CheckEmptyResultFolderPath()
        {
            if (String.IsNullOrEmpty(ResultFolderPath))
                throw new ArgumentNullException("Result folder path is empty");
        }
    }
}
