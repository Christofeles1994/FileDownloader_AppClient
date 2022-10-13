using CommonActions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonActions.Bases
{
    public abstract class AErrorCodeHandler : IErrorCodeHandler
    {
        /// <summary>
        /// Obtain an error description from an error JDB set catalog
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public abstract string GetErrorMessageFromCode(int errorCode);

    }
}
