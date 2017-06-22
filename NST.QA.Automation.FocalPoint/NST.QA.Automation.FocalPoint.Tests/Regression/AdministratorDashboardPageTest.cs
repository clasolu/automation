using Microsoft.VisualStudio.TestTools.UnitTesting;
using NST.QA.Automation.FocalPoint;

namespace NST.QA.Automation.FocalPoint.Tests.Regression
{
    [TestClass]
    public class AdministratorDashboardPageTest : TestWithChrome
    {
        bool CloseBrowser = true;
        [TestMethod, TestCategory("Regression Administrator Dashboard Page")]
        public void ButtonsDisplayed()
        { 
        LoginPage.GoTo();
        LoginPage.LoginAs("developer@nearshoretechnology.com").WithPassword("123456").Login();
        var buttonRegistered = AdministratorDashboardPage.RegisteredClientsButton.Displayed();
        var buttonEmployees =AdministratorDashboardPage.RegisteredEmployeesButton.Displayed();
        var buttonPermissions =AdministratorDashboardPage.RegisteredFocalpointPermissionsButton.Displayed();
        Driver.CloseBrowser = CloseBrowser;
        Assert.AreEqual("True,True,True", buttonRegistered + "," + buttonEmployees + "," + buttonPermissions, "buttonRegistered expected(true) actual(" + buttonRegistered + ").buttonEmployees exp(true) actual(" + buttonEmployees + ").buttonPermissions expected(true) actual(" + buttonPermissions + ")");

        }

        [TestMethod, TestCategory("Regression Administrator Dashboard Page")]
        public void ClickRegistered()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("developer@nearshoretechnology.com").WithPassword("123456").Login();
            AdministratorDashboardPage.RegisteredClientsButton.Click();

        }
    }
}
