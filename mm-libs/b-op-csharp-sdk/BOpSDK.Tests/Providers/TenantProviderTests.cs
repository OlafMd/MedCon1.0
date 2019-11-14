using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOp.Providers;
using BOp.Providers.TMS.Requests;
using RestSharp;
using Moq;
using BOp.Providers.TMS;
using System.Net;
using BOp.Services.Rest;
using BOp.Providers.TMS.Responses;

namespace BOp.Tests.Providers
{
    [TestClass]
    public class TenantProviderTests
    {

        private Mock<IRestClient> mockedClient;
        private TenantServiceProvider provider;

        private static string _accountEmail;
        private static string _accountPassword;

        [TestInitialize]
        public void SetUp()
        {
            mockedClient = new Mock<IRestClient>();
            provider = new TenantServiceProvider(mockedClient.Object);
        }

        [TestMethod]
        public void TestCreateTenantAndAccountValid()
        {
            var request = new RegistrationRequest();
            var mockedResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.Created
            };
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.CreateTenantAndAccount(request);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);

        }

        [TestMethod]
        public void TestGetTenantsForSameCredentials()
        {
            var sessionToken = "test";
            var tenants = new List<TenantBasicInfo>(){
                    new TenantBasicInfo(){
                        DisplayName = "test",
                        ID = Guid.NewGuid()
                    }
                };
            IRestResponse<List<TenantBasicInfo>> mockedResponse = new RestResponse<List<TenantBasicInfo>>()
            {
                StatusCode = HttpStatusCode.OK,
                Data = tenants
            };
            mockedClient.Setup<IRestResponse>(
                c => c.Execute<List<TenantBasicInfo>>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetTenantsForSessionToken(sessionToken);
            Assert.AreEqual(tenants, result);

            mockedClient.Verify(c => c.Execute<List<TenantBasicInfo>>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

    
    }
}
