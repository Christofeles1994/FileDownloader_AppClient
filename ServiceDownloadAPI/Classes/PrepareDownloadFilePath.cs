using ServiceDownloadAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDownloadAPI.Classes
{
    public class PrepareDownloadFilePath : IPrepareDownloadFilePath
    {
        /// <summary>
        /// Sort strings values of file features for singular http path of a file
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        string[] IPrepareDownloadFilePath.PrepareDownloadFilePath(string cadena, string url)
        {
            string[] paths = new string[5];
            Uri urlPath = new Uri(url);
            string[] segments = urlPath.Segments;
            string host = urlPath.Host;
            string path = urlPath.Scheme + @"://";
            string web = path + host;

            if (cadena.Contains("href=\"..")) 
            {
                cadena = cadena.Replace("href=\"", "").Replace(@"""", "").Replace("#", "");

                //cuenta los ../ para saber los niveles que debe subir desde la pagina inicial del sitio
                int niveles = cadena.Split('/', '\\').Count(x => x.Equals(".."));
                //nivel identificado despues de subir el numerto de niveles anterior
                var tempPath = String.Join("", segments.Take(segments.Length - 1 - niveles));

                var directory = "\\" + String.Join("\\", tempPath.Split('/').Where(a => a.Length > 0).ToList()) + "\\";

                cadena = cadena.Replace("../", "");

                paths[0] = cadena;
                paths[1] = tempPath;
                paths[2] = directory;
                paths[3] = web;
                paths[4] = host;
            }
            return paths;
        }
    }
}
