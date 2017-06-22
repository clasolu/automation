using Microsoft.VisualStudio.TestTools.UnitTesting;
using NST.QA.Automation;

namespace NST.QA.Automation.FocalPoint.Tests
{
    /* 
     * This is way too generic to be on all projects, we could extract and just reference...
     * Anyway, I don't think this approach is the best, we would need to have multiple test
     * classes just to use different drivers, duplicating code (!DRY). We could either have
     * a driver resolver that can provide us the desired one and just use it from a
     * TestCase (available in nunit).
     * TODO: reserach if TestCase is available in MS's UT Framework
     */
    [TestClass]
    public class TestWithFirefox
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize(Browser.Firefox);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }

    [TestClass]
    public class TestWithChrome
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize(Browser.Chrome);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }

    [TestClass]
    public class TestWithIE
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize(Browser.InternetExplorer);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}
