using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NST.QA.Automation
{
    public static class Extensions
    {
        /// <summary>
        /// Gets the count of elements in the provided enumerable.
        /// </summary>
        /// <param name="webElements">Enumerable to count against to.</param>
        /// <returns>Elements count.</returns>
        public static int GetCount(this IEnumerable<IWebElement> webElements)
        {
            return webElements == null ? 0 : webElements.Count();
        }

        /// <summary>
        /// Sends keys to a web element.
        /// </summary>
        /// <param name="webElement">Web element receiving keys.</param>
        /// <param name="value">Keys to send to web element.</param>
        /// <param name="clearFirst">If true, web element is cleared before keys are sent to it.</param>
        public static void SendKeys(this IWebElement webElement, string value, bool clearFirst = false)
        {
            if(clearFirst)
            {
                webElement.Clear();
            }

            webElement.SendKeys(value);
        }

        //TODO: Add an overload for this method that outs the found element so we don't have to ask for it if needed
        /// <summary>
        /// Validates the existence of an element in the page.
        /// </summary>
        /// <param name="webDriver">WebDriver handling search mechanism.</param>
        /// <param name="by">Mechanism to be used to look for the element.</param>
        /// <returns></returns>
        public static bool HasElement(this IWebDriver webDriver, By by)
        {
            try
            {
                webDriver.FindElement(by);
            }
            catch(NoSuchElementException)
            {
                return false;
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Selects the option within a <see cref="OpenQA.Selenium.Support.UI.SelectElement"/>
        /// that matches the value passed in <para>text</para>.
        /// </summary>
        /// <param name="select">The select element where the option will be looked for and selected if found.</param>
        /// <param name="text">Text</param>
        /// <returns></returns>
        public static string SelectByText(this SelectElement select, string text)
        {
            foreach(var option in select.Options.Where(option => option.Text.Contains(text)))
            {
                var optionText = option.Text;
                option.Click();
                return optionText;
            }

            //TODO: debug
            select.SelectByText(text);
            return text;
        }

        /// <summary>
        /// Gets the Dislayed state of the web element located by the mechanism provided.
        /// </summary>
        /// <param name="webDriver">WebDriver handling search mechanism.</param>
        /// <param name="by">Mechanism to be used to look for the element.</param>
        /// <returns></returns>
        public static bool IsElementDisplayed(this IWebDriver webDriver, By by)
        {
            //TODO: refactor, we already have a method that does part of this
            try
            {
                if(webDriver.FindElements(by).Count > 0)
                {
                    return (webDriver.FindElement(by).Displayed);
                }
                else
                {
                    return false;
                }
            }
            catch(NoSuchElementException)
            {
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the Enabled state of the web element located by the mechanism provided.
        /// </summary>
        /// <param name="webDriver">WebDriver handling search mechanism.</param>
        /// <param name="by">Mechanism to be used to look for the element.</param>
        /// <returns></returns>
        public static bool IsElementEnabled(this IWebDriver webDriver, By by)
        {
            //TODO: refactor, we already have a method that does part of this
            try
            {
                if(webDriver.FindElements(by).Count > 0)
                {
                    return webDriver.FindElement(by).Enabled;
                }
                else
                {
                    return false;
                }
            }
            catch(NoSuchElementException)
            {
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static void WaitForPageToLoad(this IWebDriver webDriver)
        {
            TimeSpan timeout;
            WebDriverWait wait;
            IJavaScriptExecutor jsExecutor;

            timeout = new TimeSpan(0, 0, 30);
            wait = new WebDriverWait(webDriver, timeout);
            jsExecutor = webDriver as IJavaScriptExecutor;

            if(jsExecutor == null)
            {
                throw new ArgumentException("webDriver", "Web driver provided must support javascript execution.");
            }

            wait.Until((page) =>
            {
                try
                {
                    string readyState = jsExecutor.ExecuteScript(
                        "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower().Equals("complete");
                }
                //Window is no longer available
                catch(InvalidOperationException e)
                {
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                //Browser is no longer available
                catch(WebDriverException e)
                {
                    return e.Message.ToLower().Contains("unable to connect");
                }
                //General exception
                catch(Exception)
                {
                    return false;
                }
            });
        }

        public static void WaitForElement(this IWebDriver driver, By element)
        {
            WebDriverWait wait;

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until<bool>((webDriver) =>
            {
                //TODO: refactor, we already have code that does this
                try
                {
                    return webDriver.FindElement(element).Displayed;
                }
                catch(NoSuchElementException)
                {
                    return false;
                }

            });
        }

        public static string HasNoValue(this string text, string value)
        {
            return string.IsNullOrWhiteSpace(text) ? value : text;
        }
    }
}
