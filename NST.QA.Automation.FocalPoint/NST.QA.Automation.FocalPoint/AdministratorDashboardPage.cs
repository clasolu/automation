using System.Configuration;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace NST.QA.Automation.FocalPoint
{
    public class AdministratorDashboardPage
    {
        public static bool IsAt()
        {
            var FindElement = Driver.Instance.PageSource.Contains("Administration Dashboard");
            return FindElement;

        }
#region Buttons
        public class RegisteredClientsButton
        {
            private static string fieldvalue = "h4[class=text-center]";
                //"/html/body/main/div/div[1]/a/div/div/div/div[2]/h4";
                //body > main > div > div:nth-child(1) > a > div > div > div > div.col-xs-offset-1.col-xs-8 > h4";
            public static void Click()
            {
                var WebElement = Driver.Instance.FindElements(By.CssSelector(fieldvalue));
                var ElementCount=WebElement.Count;
                //"Registered clients"
                for(int i=0;i<=ElementCount;i++)
                {
                    var contentElement = WebElement[i];
                    var ElementText= contentElement.Text;
                    if ("Registered clients"==ElementText)
                    {
                        contentElement.Click();
                        break;
                    }
                }
            }

            public static bool Exist()
            {
                var WebElement = Driver.Instance.HasElement(By.XPath(fieldvalue));

                return WebElement;
            }

            public static bool Displayed()
            {
                var WebElement = Driver.Instance.IsElementDisplayed(By.XPath(fieldvalue));

                return WebElement;
            }

        }

        public class RegisteredEmployeesButton
        {
            private static string fieldvalue = "/html/body/main/div/div[2]/a/div/div/div/div[2]/h4";
            
            public static void Click()
            {
                var WebElement = Driver.Instance.FindElement(By.XPath(fieldvalue));
                WebElement.Click();
            }

            public static bool Exist()
            {
                var WebElement = Driver.Instance.HasElement(By.XPath(fieldvalue));

                return WebElement;
            }

            public static bool Displayed()
            {
                var WebElement = Driver.Instance.IsElementDisplayed(By.XPath(fieldvalue));

                return WebElement;
            }

        }

        public class RegisteredFocalpointPermissionsButton
        {
            private static string fieldvalue = "/html/body/main/div/div[3]/a/div/div/div/div[2]/h4";

            public static void Click()
            {
                var WebElement = Driver.Instance.FindElement(By.XPath(fieldvalue));
                WebElement.Click();
            }

            public static bool Exist()
            {
                var WebElement = Driver.Instance.HasElement(By.XPath(fieldvalue));

                return WebElement;
            }

            public static bool Displayed()
            {
                var WebElement = Driver.Instance.IsElementDisplayed(By.XPath(fieldvalue));

                return WebElement;
            }

        }
#endregion
    }
}
