using CommonActions.Interfaces;
using CommonActions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonActions.Classes
{
    public class ReadJsonConfig : IReadJsonConfig
    {
        /// <summary>
        /// Obatin all string value from a file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetJsonConfig(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
               return r.ReadToEnd();
            }
        }
    }
}
