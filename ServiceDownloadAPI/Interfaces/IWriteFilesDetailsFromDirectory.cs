using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDownloadAPI.Interfaces
{
    public interface IWriteFilesDetailsFromDirectory
    {
        /// <summary>
        /// Interface of a method that write downloaded file details from a specific directory
        /// </summary>
        /// <param name="filesStoragePath"></param>
        public void WriteFilesDetails(string filesStoragePath);
    }
}
