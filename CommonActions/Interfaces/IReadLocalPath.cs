using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonActions.Interfaces
{
    public interface IReadLocalPath
    {
        /// <summary>
        /// Interface method for reading a file from local path config
        /// </summary>
        /// <returns></returns>
        public string GetLocalPathValue();
    }
}
