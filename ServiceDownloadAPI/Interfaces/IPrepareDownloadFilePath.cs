using ServiceDownloadAPI.DTO;
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
        /// <param name="chain"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public PathsDTO PrepareDownloadFilePath(string chain, string url);
    }
}
