using System.Configuration;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace NST.QA.Automation.FocalPoint
{
    public class LoginPage
    {
        public static void GoTo()
        {
            string baseUrl;
            /*
             * TODO: wrap ConfigurationManager calls into our own config helper or at least
             * have constants for the config keys. Also, baseUrl can be on a base class.
             */
            baseUrl = ConfigurationManager.AppSettings["OnlineBaseUrl"];
            Driver.Instance.Navigate().GoToUrl(baseUrl + "/login");
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }

        public static bool IsAt()
        {
            var IsAt = Driver.Instance.PageSource.Contains("Focalpoint <small>Access</small>"); //this is adding a direct reference for the Title page
            return IsAt;
        }


        #region fields

        public class Loginfield
        {

           // private static string field = "/html/body/main/form/div[1]/div/input";
            private static string field = "input[name=username]";

            public static void SendText(string Type)
            {
                var WebItem = Driver.Instance.FindElement(By.CssSelector(field));
                WebItem.SendKeys(Type);
            }

            public static void Clear()
            {
                var WebItem = Driver.Instance.FindElement(By.CssSelector(field));
                WebItem.Clear();
            }

            public static bool Exist()
            {
                var WebItem = Driver.Instance.HasElement(By.CssSelector(field));
                return WebItem;
            }

            public static void Click()
            {
                var WebItem = Driver.Instance.FindElement(By.CssSelector(field));
                WebItem.Click();
            }

        }

        public class Passwordfield
        {

            //private static string field = "/html/body/main/form/div[2]/div/input";
            private static string field = "input[name=password]";

            public static void SendText(string Type)
            {
                var WebItem = Driver.Instance.FindElement(By.CssSelector(field));
                WebItem.SendKeys(Type);
            }

            public static void Clear()
            {
                var WebItem = Driver.Instance.FindElement(By.CssSelector(field));
                WebItem.Clear();
            }

            public static bool Exist()
            {
                var WebItem = Driver.Instance.HasElement(By.CssSelector(field));
                return WebItem;
            }

            public static void Click()
            {
                var WebItem = Driver.Instance.FindElement(By.CssSelector(field));
                WebItem.Click();
            }

        }

        #endregion

        #region buttons

        public class LoginButton
        {
            //private static string button = "/html/body/main/form/div[3]/div/button";
            private static string button = "button[type=submit]";

            public static bool Exist()
            {
                var WebItem = Driver.Instance.HasElement(By.CssSelector(button));
                return WebItem;
            }

            public static void Click()
            {
                var WebItem = Driver.Instance.FindElement(By.CssSelector(button));
                WebItem.Click();
            }

        }

        #endregion

        #region alerts
        public static bool InvalidUserAndPassword()
        {
            string Element = "/html/body/main/form/div[1]";
            string Text = "Invalid Username And/Or Password";
           bool alert;

           alert = Driver.Instance.IsElementDisplayed(By.XPath(Element));
           if (alert)
           {
               var InvUsrPswd = Driver.Instance.FindElement(By.XPath(Element));
               if (InvUsrPswd.Text.Contains(Text))
               {
                   return true;
               } else 
                   return false;
           }else
           return false;
        }
        #endregion

    }

    public class LoginCommand
    {

        private readonly string username;
        private string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="NST.QA.Automation.FocalPoint.LoginCommand"/> class.
        /// </summary>
        /// <param name="username">The username of the user logging in.</param>
        public LoginCommand(string username)
        {
            this.username = username;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            //IWebElement loginInput, passwordInput, loginButton;

            //loginInput =  Driver.Instance.FindElement(By.XPath("/html/body/main/form/div[1]/div/input"));
            //loginInput.SendKeys(username);

            //passwordInput = Driver.Instance.FindElement(By.XPath("/html/body/main/form/div[2]/div/input"));
            //passwordInput.SendKeys(password);

            //loginButton = Driver.Instance.FindElement(By.XPath("/html/body/main/form/div[3]/div/button"));
            //loginButton.Click();
            LoginPage.Loginfield.SendText(username);
            LoginPage.Passwordfield.SendText(password);
            LoginPage.LoginButton.Click();
            Driver.Instance.WaitForPageToLoad();
        }
    }
}
