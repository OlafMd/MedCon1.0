using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOp.Services.Rest;
using System.Net;
using BOp.Services.Serialization;
using BOp.Services;

namespace BOp.Tests.Rest
{
    //TODO: Dont' use the pre-defined URLs
    [TestClass]
    public class RestClientTest
    {
        private IRestClient client;

        [TestInitialize]
        public void SetUp()
        {
            //client = new ServiceFactory().BuildClient();
        }

        

        [TestMethod]
        public void TestMethod1()
        {
            var request = new ServiceFactory().BuildRequest("http://www.tomee.local.b-op.com/auth/status");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [TestMethod]
        public void TestMethod2()
        {
            var url = "http://192.168.32.165:8080/cms/api/v3/sessions/";
            var request = new ServiceFactory().BuildRequest(url);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
