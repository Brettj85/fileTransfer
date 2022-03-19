using System;
using System.IO;

namespace ScripthostFileTransferUtility
{
    class Program
    {
        static void Main(string[] args)
        {            
            DirectoryInfo originatingDirectory = new DirectoryInfo("PATH");

            FileInfo[] originatingDirectoryFiles = originatingDirectory.GetFiles();

            string formatedDate = GetDate();

            string fileToCopy = FindFileIfExists(originatingDirectoryFiles, formatedDate);

            string currentFileLocation = Path.Combine("PATH", Path.GetFileName(fileToCopy));

            string destinationDirectory = Path.Combine("PATH", Path.GetFileName(fileToCopy));
            try
            {
                File.Copy(currentFileLocation, destinationDirectory, true);
            }
            catch (IOException ex)
            {
                //send e-mail to co worker containing ex.Message to alert them to correct file generation error on their server
            }

        }

        public static string GetDate()
        {
            DateTime todaysDate = DateTime.Now.Date;
            return todaysDate.ToString("MMddyyyy");
        }

        public static string FindFileIfExists(FileInfo[] originatingDirectoryFiles, string formatedDate)
        {
            foreach (var fileName in originatingDirectoryFiles)
            {
                string file = fileName.ToString();

                if (file.Contains(formatedDate))
                {
                    return fileName.ToString();
                }
            }
            return "";
        }
    }
}
