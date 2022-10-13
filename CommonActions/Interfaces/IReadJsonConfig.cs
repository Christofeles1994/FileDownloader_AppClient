using CommonActions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonActions.Interfaces
{
    public interface IReadJsonConfig
    {
        /// <summary>
        /// Interface method for reading a file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetJsonConfig(string path);
    }
}
