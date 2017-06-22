using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace NST.QA.Automation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static bool CloseBrowser { get; set; }
        public static string BaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["OnlineBaseUrl"];
            }
        }
        public static List<DesiredCapabilities> GridBrowsers { get; set; }

        public static void Initialize(Browser browser = Browser.Chrome, bool closeBrowser = false)
        {
            switch(browser)
            {

                case Browser.Chrome:
                    Instance = new ChromeDriver();
                    break;
                case Browser.Firefox:
                    Instance = new FirefoxDriver();
                    break;
                case Browser.InternetExplorer:
                    Instance = new InternetExplorerDriver();
                    break;
            }

            CloseBrowser = closeBrowser;
            Instance.Manage().Window.Maximize();
            TurnOnWait();
        }

        public static void Close()
        {
            if(CloseBrowser)
                Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep(Convert.ToInt32(timeSpan.TotalSeconds * 1000));
        }

        public static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWait();
        }

        private static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }

        private static void TurnOffWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
        }

        #region Grid
        public static void GridSetup()
        {
            #region DEMO CODE
            //DesiredCapabilities capabilities = new DesiredCapabilities();
            //capabilities = DesiredCapabilities.Firefox();
            //capabilities.SetCapability(CapabilityType.BrowserName, "firefox");
            //capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
            //Instance = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
            #endregion

            if(GridBrowsers.Count() > 0)
                GridBrowsers = new List<DesiredCapabilities> {
                    DesiredCapabilities.InternetExplorer(), DesiredCapabilities.Chrome(), DesiredCapabilities.Firefox() };

            foreach(var browser in GridBrowsers)
            {
                Instance = new RemoteWebDriver(new Uri(BaseUrl), browser);
            }

            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }
        #endregion

        #region Scroll
        public static void ScrollDown()
        {
            ((IJavaScriptExecutor)Driver.Instance).ExecuteScript("window.scroll(0, 2000);");
        }
        #endregion
    }
}
