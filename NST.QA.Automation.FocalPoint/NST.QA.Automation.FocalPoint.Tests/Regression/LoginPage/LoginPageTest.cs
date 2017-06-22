using Microsoft.VisualStudio.TestTools.UnitTesting;
using NST.QA.Automation.FocalPoint;

namespace NST.QA.Automation.FocalPoint.Tests
{
    [TestClass]
    public class LoginPageTest : TestWithChrome
    {
        bool CloseBrowser = true;

        [TestMethod, TestCategory("Regression Login Page")]
        public void TestLoginAttemptWithSuccess()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("developer@nearshoretechnology.com").WithPassword("123456").Login();
            Driver.CloseBrowser = CloseBrowser;
            Assert.IsFalse(LoginPage.IsAt(), "Login Page is still");
            

        }

        [TestMethod, TestCategory("Regression Login Page")]
        public void TestLoginPageWasDiplayed()
        {
            LoginPage.GoTo();
            Driver.CloseBrowser = CloseBrowser;
            Assert.IsTrue(LoginPage.IsAt(), "Login Page was not shown as expected");
        }

        [TestMethod, TestCategory("Regression Login Page")]
        public void TestLoginAttemptWithoutSuccess()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("developers@nearshoretechnology.com").WithPassword("123457").Login();
            Driver.CloseBrowser = CloseBrowser;
            Assert.IsTrue(LoginPage.InvalidUserAndPassword(), "Invalid User and Password Alert was not shown as Expected");
        }

        [TestMethod, TestCategory("Regression Login Page")]
        public void AttemptToLoginAtAdministratorsDashboardWithSuccess()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("developer@nearshoretechnology.com").WithPassword("123456").Login();
            Driver.CloseBrowser = CloseBrowser;
            Assert.IsTrue(AdministratorDashboardPage.IsAt(), "Invalid User or Password");

        }

        [TestMethod, TestCategory("Regression Login Page")]
        public void AttemptToLoginAtAdministratorsDashboardWithoutSuccess()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("developer@nearshoretechnology.com").WithPassword("abcde").Login();
            Driver.CloseBrowser = CloseBrowser;
            Assert.IsFalse(AdministratorDashboardPage.IsAt(), "Page Shouldn´t be Displayed");
        }

    }
}
