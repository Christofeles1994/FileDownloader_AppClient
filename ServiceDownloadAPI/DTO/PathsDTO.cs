using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDownloadAPI.DTO
{
    public class PathsDTO
    {
        public string chain { get; set; }
        public string tempPath { get; set; }
        public string directory { get; set; }
        public string web { get; set; }
        public string host { get; set; }
        public string currentTempPath { get; set; }
    }
}
