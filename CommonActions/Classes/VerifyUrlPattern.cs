using CommonActions.Enums;
using CommonActions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonActions.Classes
{
    public class VerifyUrlPattern : IVerifyUrlPattern
    {
        /// <summary>
        /// Make sure if string value refers to a URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool IsValidUrl(string url)
        {
            Regex regex = new Regex(RPattern.VALID_URL_PATTERN);
            if (regex.IsMatch(url))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
