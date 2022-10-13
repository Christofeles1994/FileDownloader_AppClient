using ServiceDownloadAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDownloadAPI.Classes
{
    public class WriteFilesDetailsFromDirectory: IWriteFilesDetailsFromDirectory
    {
        /// <summary>
        /// Method that write downloaded file details from a specific directory
        /// </summary>
        /// <param name="filesStoragePath"></param>
        public void WriteFilesDetails(string filesStoragePath)
        {
            StringBuilder filesSummary = new StringBuilder();
            string fileName = @"" + filesStoragePath + "\\DownloadDetailInfo.txt";
            //MessageBox.Show("Download completed!");
            foreach (string file in Directory.GetFiles(filesStoragePath))
            {
                FileInfo oFileInfo = new FileInfo(file);
                if (oFileInfo != null || oFileInfo.Length == 0)
                {
                    filesSummary.AppendLine("FILE NAME: " + oFileInfo.Name);
                    filesSummary.AppendLine("EXTENSION: " + oFileInfo.Extension);
                    filesSummary.AppendLine("SIZE: " + oFileInfo.Length + " Bytes");
                    filesSummary.AppendLine("LAST MODIFIED DATE: " + oFileInfo.LastWriteTime);
                    filesSummary.AppendLine("----------------------------------------------------------------");

                }
            }

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                // Create a new file     
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine(filesSummary.ToString());
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("Done! ");
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
