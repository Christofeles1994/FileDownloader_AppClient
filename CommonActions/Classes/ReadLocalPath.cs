using CommonActions.Interfaces;
using CommonActions.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonActions.Classes
{
    public class ReadLocalPath : IReadLocalPath
    {
        /// <summary>
        /// Obtain a value that represents a destination for downloaded files
        /// </summary>
        /// <returns></returns>
        public string GetLocalPathValue()
        {
            IReadJsonConfig jconf = new ReadJsonConfig();
            string json = jconf.GetJsonConfig("LocalPathConf.json");
            var localpath = JsonConvert.DeserializeObject<LocalPath>(json);
            
            return localpath.path;
        }
    }
}
