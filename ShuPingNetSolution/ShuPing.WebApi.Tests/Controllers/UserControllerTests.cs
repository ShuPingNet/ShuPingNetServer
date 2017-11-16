using Infrastructure.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShuPing.Entity;
using ShuPing.WebApi.Controllers;
using ShuPing.WebApi.Models.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuPing.WebApi.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        //优化单元测试逻辑
        //配置
        UserController uc;
        UserLogOnEntity loginEntity;
        ApiResultModelBase model;

        [TestInitialize]
        public void SetUp()
        {
            loginEntity = new UserLogOnEntity();
            loginEntity.C_UserId = "xhb";
            loginEntity.C_UserPassword = "12";
            Debug.WriteLine("初始化UserLogOnEntity完成");

            uc = new UserController();
            Debug.WriteLine("初始化UserController完成");

            model = new ApiResultModel
            {
                Data = "",
                IsSuccess = true,
                Message = "",
                StatusCode = Infrastructure.StatusEnum.StatusCodeEnum.Success
            };
            Debug.WriteLine("初始化ApiResultModel完成");
        }
        public UserControllerTests()
        {
            
            loginEntity = new UserLogOnEntity();
            loginEntity.C_UserId = "xhb";
            loginEntity.C_UserPassword = "12";
            Debug.WriteLine("初始化UserLogOnEntity完成");

            uc = new UserController();
            Debug.WriteLine("初始化UserController完成");

            model = new ApiResultModel
            {
                Data = "",
                IsSuccess = true,
                Message = "",
                StatusCode = Infrastructure.StatusEnum.StatusCodeEnum.Success
            };
            Debug.WriteLine("初始化ApiResultModel完成");
        }

        //清理
        [TestCleanup]
        void WWUserControllerTests()
        {
            uc = null;
            loginEntity = null;
            model = null;
            Debug.WriteLine("测试结束，销毁UserController，uc=" + uc);
            Debug.WriteLine("测试结束，销毁UserLogOnEntity，loginEntity=" + loginEntity);
            Debug.WriteLine("测试结束，ApiResultModelBase，model=" + model);
        }  

        ///断言
        [TestMethod()]
        public void Login_GetResult_NotNull()
        {
            var ret = uc.Login(loginEntity);
            Assert.IsNotNull(ret);
        }

        [TestMethod()]
        
        public void Login_GetResult_Success()
        {
            var ret = uc.Login(loginEntity);
            Assert.AreEqual(model.StatusCode, ret.StatusCode);
            Assert.IsTrue(ret.IsSuccess);
        }
    }
}