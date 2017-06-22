using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace NST.QA.Automation
{
    public class WebPage
    {
        #region Web page styles class
        public class Styles
        {
            /// <summary>
            /// This method is used to validate the tooltip background color property
            /// </summary>
            /// <param name="backgroundColor">The color string with format 'RGBA(0,0,0,0)'</param>
            /// <returns>Bool</returns>
            public static string rgbaColorStringToHexColorString(string rgbaColorString)
            {
                var regex = new Regex(@"([0-9]+)");

                var matches = regex.Matches(rgbaColorString);
                int r = (int)Math.Round(double.Parse(matches[0].Value));
                int g = (int)Math.Round(double.Parse(matches[1].Value));
                int b = (int)Math.Round(double.Parse(matches[2].Value));
                int a = (int)Math.Round(double.Parse(matches[3].Value));

                var color = Color.FromArgb(a, r, g, b);

                return color.Name.ToUpper();
            }
        }
        #endregion
    }
}
