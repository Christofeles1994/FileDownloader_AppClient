using ServiceDownloadAPI.DTO;
using ServiceDownloadAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDownloadAPI.Classes
{
    public class PrepareDownloadFilePath : IPrepareDownloadFilePath
    {
        /// <summary>
        /// Sort strings values of file features for singular http path of a file
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        PathsDTO IPrepareDownloadFilePath.PrepareDownloadFilePath(string chain, string url)
        {
            PathsDTO pathsDTO = new PathsDTO();
            Uri urlPath = new Uri(url);
            string[] segments = urlPath.Segments;
            string host = urlPath.Host;
            string path = urlPath.Scheme + @"://";
            string web = path + host;

            if (chain.Contains("href=\".."))
            {
                chain = chain.Replace("href=\"", "").Replace(@"""", "").Replace("#", "");

                //cuenta los ../ para saber los niveles que debe subir desde la pagina inicial del sitio
                int niveles = chain.Split('/', '\\').Count(x => x.Equals(".."));
                //nivel identificado despues de subir el numerto de niveles anterior
                var tempPath = String.Join("", segments.Take(segments.Length - 1 - niveles));

                var directory = "\\" + String.Join("\\", tempPath.Split('/').Where(a => a.Length > 0).ToList()) + "\\";

                chain = chain.Replace("../", "");

                pathsDTO.chain = chain;
                pathsDTO.tempPath = tempPath;
                pathsDTO.directory = directory;
                
            }
            else if (chain.Contains("href=\""))
            {
                string[] file = chain.Split('=', '/');
                if (file.Length == 2)
                {
                    string fileName = file[1];

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        fileName = fileName.Replace(@"""", "");
                        string currentTempPath = urlPath + fileName;
                        string directory = String.Join("", segments.Take(segments.Length));
                        directory = directory.Replace('/', '\\');

                        pathsDTO.directory = directory;
                        pathsDTO.currentTempPath = currentTempPath;
                        pathsDTO.chain = string.Empty;

                    }

                }
            }
            pathsDTO.web = web;
            pathsDTO.host = host;
            
            return pathsDTO;
        }
    }
}
