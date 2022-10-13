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
    public class UpdateLocalPath : IUpdateLocalPath
    {
        /// <summary>
        /// Set and Update value of json config set for local path destionation directory
        /// </summary>
        /// <param name="local"></param>
        void IUpdateLocalPath.UpdateLocalPath(string local)
        {
            IReadJsonConfig jconf = new ReadJsonConfig();
            string json = jconf.GetJsonConfig("LocalPathConf.json");
            var resultpath = JsonConvert.DeserializeObject<LocalPath>(json);

            if (resultpath.path != local && local != String.Empty)
            {
                resultpath.path = local;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(resultpath, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("LocalPathConf.json", output);
            }
        }
    }
}
