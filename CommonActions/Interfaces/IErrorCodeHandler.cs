using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonActions.Interfaces
{
    public interface IErrorCodeHandler
    {
        /// <summary>
        /// Interface method of getting an error description
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public string GetErrorMessageFromCode(int errorCode);
    }
}
