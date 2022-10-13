using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceDownloadAPI.Classes
{
    public class WebClientExample
    {
        public string url { get; set; }
        public string filesStoragePath { get; set; }
        public WebClientExample()
        {
        }

        public void webExecute(string url)
        {
            this.url = url;
            WebClient webClient = new WebClient();
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
            
            Uri URL = new Uri(url);
            webClient.OpenReadAsync(URL);
        }

        private void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            Uri urlPath = new Uri(this.url);
            string host = urlPath.Host;
            string path = urlPath.Scheme + @"://";
            string[] segments = urlPath.Segments;
            string web = path + host;

            string currentPath = web + String.Join("", segments.Take(segments.Length - 1));
            string[] splitHtml = currentPath.Split('/');

            if (e.Error != null)
            {
                Console.WriteLine(e.Error.Message);
                //MessageBox.Show(e.Error.Message);
            }
            else
            {
                const string PATTERN = @"href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))";
                //const string PATTERN = @"a href=""(?<link>.+?)"""; 

                Regex regex = new Regex(PATTERN, RegexOptions.IgnoreCase);
                TextReader TR = new StreamReader(e.Result);
                string content = TR.ReadToEnd();
                MatchCollection MC = regex.Matches(content);
                foreach (Match match in MC)
                {
                    string cadena = match.Value;
                    //busco los casos que tienen descarga del mismo sitio web, por ejemplo href="../shareholders.html" o href="../_assets/css/external/tablestyle.css"
                    if (cadena.Contains("href=\".."))
                    {
                        cadena = cadena.Replace("href=\"", "").Replace(@"""", "").Replace("#", "");

                        //cuenta los ../ para saber los niveles que debe subir desde la pagina inicial del sitio
                        int niveles = cadena.Split('/', '\\').Count(x => x.Equals(".."));
                        //nivel identificado despues de subir el numerto de niveles anterior
                        var tempPath = String.Join("", segments.Take(segments.Length - 1 - niveles));

                        var directory = "\\" + String.Join("\\", tempPath.Split('/').Where(a => a.Length > 0).ToList()) + "\\";

                        cadena = cadena.Replace("../", "");

                        if (!string.IsNullOrEmpty(cadena))
                        {
                            string currentTempPath = web + tempPath + cadena;
                            var pathToSace = @"C:\Workdir\"+ host + directory;

                            WebClient webClient1 = new WebClient();
                            webClient1.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                            webClient1.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                            if (!Directory.Exists(pathToSace))
                            {
                                Directory.CreateDirectory(pathToSace);
                            }
                            string fileStoraged = pathToSace + currentTempPath.Split('/')[currentTempPath.Split('/').Length - 1];
                            this.filesStoragePath = pathToSace;
                            webClient1.DownloadFileAsync(new Uri(currentTempPath), fileStoraged);
                            
                        }
                    }

                    //listBox1.Items.Add(match.Groups["pdf"]);
                    //listBox1.Items.Add(match.Value);
                    var result = match.Value;
                }
                TR.Close();
            }

            //btnScan.Enabled = true;
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //progressBar.Value = e.ProgressPercentage;
            //MessageBox.Show(e.ProgressPercentage.ToString());
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            StringBuilder filesSummary = new StringBuilder();
            string fileName = @"" + this.filesStoragePath + "\\DownloadDetailInfo.txt";
            //MessageBox.Show("Download completed!");
            foreach (string file in Directory.GetFiles(this.filesStoragePath))
            {
                FileInfo oFileInfo = new FileInfo(file);
                if (oFileInfo != null || oFileInfo.Length == 0)
                {
                    filesSummary.AppendLine("FILE NAME: "+oFileInfo.Name);
                    filesSummary.AppendLine("EXTENSION: "+oFileInfo.Extension);
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
