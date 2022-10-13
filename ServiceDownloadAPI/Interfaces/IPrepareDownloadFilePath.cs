using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceDownloadAPI.Interfaces
{
    public interface IPrepareDownloadFilePath
    {
        /// <summary>
        /// Interface of sort strings values of file features for singular http path of a file
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public string[] PrepareDownloadFilePath(string cadena, string url);
    }
}
