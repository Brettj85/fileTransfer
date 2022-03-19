using System;
using System.IO;

namespace ScripthostFileTransferUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileToCopy= "";
            //find file name
            DirectoryInfo originatingDirectory = new DirectoryInfo("PATH");
            FileInfo[] originatingDirectoryFiles = originatingDirectory.GetFiles();
            DateTime todaysDate = DateTime.Now.Date;
            string formatedDate = todaysDate.ToString("MM/dd/yyyy");
            foreach (var fileName in originatingDirectoryFiles)
            {
                string substringToLocate = formatedDate.Replace("/","");
                if (fileName.ToString().Contains(substringToLocate))
                {
                    fileToCopy = fileName.ToString();
                }
            }
            string currentFileLocation = Path.Combine("PATH", Path.GetFileName(fileToCopy));
            string destinationDirectory = Path.Combine("PATH", Path.GetFileName(fileToCopy));
            File.Copy(currentFileLocation, destinationDirectory, true);
        }
    }
}
