using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonActions.Interfaces
{
    public interface IVerifyUrlPattern
    {
        /// <summary>
        /// Interface method to verify url pattern
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool IsValidUrl(string url);    
    }
}
