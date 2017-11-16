using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShuPing.WebApi;
using ShuPing.WebApi.Controllers;

namespace ShuPing.WebApi.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // 配置
            HomeController controller = new HomeController();

            // 操作
            ViewResult result = controller.Index() as ViewResult;

            // 断言
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
