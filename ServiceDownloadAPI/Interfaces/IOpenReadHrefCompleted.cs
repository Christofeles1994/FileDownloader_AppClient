using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDownloadAPI.Interfaces
{
    public interface IOpenReadHrefCompleted
    {
        /// <summary>
        /// Interface for the obtain a text reader for regex and string collections that matches with Href pattern
        /// </summary>
        /// <param name="e"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public object[] OpenReadHrefCompleted(OpenReadCompletedEventArgs e, string url);
    }
}
