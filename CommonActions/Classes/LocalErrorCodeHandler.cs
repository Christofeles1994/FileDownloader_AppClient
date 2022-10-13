using CommonActions.Bases;
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
    public class LocalErrorCodeHandler : AErrorCodeHandler
    {
        /// <summary>
        /// Obtaing de error description in Jason DB catalog by passing an error code id
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public override string GetErrorMessageFromCode(int errorCode)
        {
            IReadJsonConfig jconf = new ReadJsonConfig();
            string json = jconf.GetJsonConfig("LocalErrorConf.json");
            var errors = JsonConvert.DeserializeObject<List<Error>>(json);
            var message = errors.FirstOrDefault(x => x.Id == errorCode).Description;
            return message;
        }
    }
}
