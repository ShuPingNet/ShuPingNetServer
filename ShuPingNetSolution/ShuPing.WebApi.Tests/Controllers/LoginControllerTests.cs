using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShuPing.Entity;
using ShuPing.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuPing.WebApi.Controllers.Tests
{
    [TestClass()]
    public class LoginControllerTests
    {
        [TestMethod()]
        public void RegisterTest()
        {

        }

        [TestMethod()]
        public void LoginTest()
        {
            UserLogOnEntity entity = new UserLogOnEntity
            {
                C_UserPassword = Guid.NewGuid().ToString(),
                C_UserSecretkey = Guid.NewGuid().ToString()
            };

        }
    }
}