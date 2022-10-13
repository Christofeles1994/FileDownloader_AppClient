using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonActions.Enums
{
    /// <summary>
    /// All const values are located here
    /// </summary>
    internal static class RPattern
    {
        internal const string VALID_URL_PATTERN = @"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&=]*)";
    }
}
