using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonActions.Interfaces
{
    public interface IUpdateLocalPath
    {
        /// <summary>
        /// Interface method for updating a local path value in json configs
        /// </summary>
        /// <param name="local"></param>
        public void UpdateLocalPath(string local);
    }
}
