using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using QA;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task LoginTest()
        {
            var Service = new QA.LoginTest();
            string returnString = await Service.VerifyLoginAsync("aaa@example.com", "Password123");
            Assert.IsNotNull(returnString);
        }

        [TestMethod]
        public async Task RegisterTest()
        {
            var Service = new QA.RegisterTest();
            string returnString = await Service.VerifyRegisterAsync("aaa","aaa@example.com", "Password123","Mr.","01","01","1900","aaa","bbb","ccc Company","UK1","UK2","GB","W01 0AA","London","London","+12345678901");
            Assert.IsNotNull(returnString);
        }

        [TestMethod]
        public async Task ProductsTest()
        {
            var Service = new QA.GetProductsTest();
            var returnObj = await Service.VerifyProductsListAsync();
            Assert.IsNotNull(returnObj);
        }
    }
}
