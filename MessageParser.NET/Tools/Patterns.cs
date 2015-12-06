using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MessageParser.NET.Tools
{
   public class Patterns
    {
        private string Mail = @"\b([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)";
        private string Currency = @"\$(\d{1,3},?(\d{3},?)*\d{3}([.]\d{0,3})?|\d{1,3}(.\d{2})?)";
        private string Date = @"\b[1-9][0-9][0-9][0-9]-(([1][0-2])|([0][1-9]))-(([1-2][0-9])|([3][0-1])|([0][1-9]))";
        private string Url = @"\b((http://)|(https://))?(www[.])?(([a-zA-Z]+([-_.]?[a-zA-Z]+)+))+[.](\w{2,3})(([a-z]*[A-Z]*[0-9]*[-_?=%$#*!^/]*))*";
        private string Position = @"\d\d[.]\d+(\s*[,]\s*\d\d\s*[.]\s*\d+)";

        Regex regex;

        /// <summary>
        /// Get Mail Addess In The Txt Content
        /// </summary>
        /// <param name="txt">txt</param>
        /// <returns></returns>
        public string[] GetMails(string txt)
        {
            try
            {
                regex = new Regex(Mail);
                var temp = regex.Matches(txt);

                return CopyToArray(temp);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get Currency In The Txt Content
        /// </summary>
        /// <param name="txt">txt</param>
        /// <returns></returns>
        public string[] GetCurrency(string txt)
        {
            try
            {
                regex = new Regex(Currency);
                var temp = regex.Matches(txt);

                return CopyToArray(temp);

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get Date In The Txt Content
        /// </summary>
        /// <param name="txt">txt</param>
        /// <returns></returns>
        public string[] GetDate(string txt)
        {
            try
            {
                regex = new Regex(Date);
                var temp = regex.Matches(txt);

                return CopyToArray(temp);

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get Url In The Txt Content
        /// </summary>
        /// <param name="txt">txt</param>
        /// <returns></returns>
        public string[] GetUrl(string txt)
        {
            try
            {
                regex = new Regex(Url);
                var temp = regex.Matches(txt);

                return CopyToArray(temp);

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get Geo Position In The Txt Content
        /// </summary>
        /// <param name="txt">txt</param>
        /// <returns></returns>
        public string[] GetPosition(string txt)
        {
            try
            {
                regex = new Regex(Position);
                var temp = regex.Matches(txt);

                return CopyToArray(temp);

            }
            catch
            {
                return null;
            }
        }


        private string[] CopyToArray(MatchCollection input)
        {
            try
            {
                string[] result = new string[input.Count];

                for (int i = 0; i < input.Count; i++)
                {
                    result[i] = input[i].Value;
                }

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
