using CommonActions.Enums;
using ServiceDownloadAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceDownloadAPI.Classes
{
    public class OpenReadHrefCompleted : IOpenReadHrefCompleted
    {
        /// <summary>
        /// Obtain a text reader for regex and string collections that matches with Href pattern
        /// </summary>
        /// <param name="e"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        object[] IOpenReadHrefCompleted.OpenReadHrefCompleted(OpenReadCompletedEventArgs e, string url)
        {
            object[] txtReaderMatchCollection = new object[2];

            Uri urlPath = new Uri(url);
            string host = urlPath.Host;
            string path = urlPath.Scheme + @"://";
            string[] segments = urlPath.Segments;
            string web = path + host;

            string currentPath = web + String.Join("", segments.Take(segments.Length - 1));
            string[] splitHtml = currentPath.Split('/');

            if (e.Error != null)
            {
                Console.WriteLine(e.Error.Message);
                //MessageBox.Show(e.Error.Message);
            }
            else
            {
                const string PATTERN = HRefPattern.HREF_PATTERN;

                Regex regex = new Regex(PATTERN, RegexOptions.IgnoreCase);
                TextReader TR = new StreamReader(e.Result);
                string content = TR.ReadToEnd();
                MatchCollection MC = regex.Matches(content);

                txtReaderMatchCollection[0] = TR;
                txtReaderMatchCollection[1] = MC;
            }

            return txtReaderMatchCollection;
        }
    }
}
