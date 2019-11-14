using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOp.Providers;
using Moq;
using RestSharp;
using BOp.Providers.TMS;
using BOp.Services.Rest;
using System.Net;
using BOp.Providers.TMS.Requests;
using BOp.Exceptions;

namespace BOp.Tests.Providers
{
    [TestClass]
    public class AccountServiceProviderTests
    {
        private Mock<IRestClient> mockedClient;
        private IAccountServiceProvider provider;

        [TestInitialize]
        public void SetUp()
        {
            mockedClient = new Mock<IRestClient>();
            provider = new AccountServiceProvider(mockedClient.Object);
        }

        [TestMethod]
        public void TestGetAllAccountsForTenantValid()
        {
            var tenantId = Guid.NewGuid();

            IRestResponse<List<Account>> mockedResponse = new RestResponse<List<Account>>()
            {
                StatusCode = HttpStatusCode.OK

            };
            var accounts = new List<Account>()
            {
                new Account(){
                    ID = Guid.NewGuid()
                }
            };
            mockedResponse.Data = accounts;
            mockedClient.Setup<IRestResponse>(
                c => c.Execute<List<Account>>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);

            var result = provider.GetAllAccountsForTenant(tenantId);
            Assert.AreEqual(accounts, result);

            var url = string.Format("api/v3/tenants/{0}/accounts/", tenantId.ToString());

            var request = new JSONRestRequest("url");
            mockedClient.Verify(c => c.Execute<List<Account>>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestBanAccountValid()
        {
            var accountId = Guid.NewGuid();
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.OK
            };
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.BanAccount(accountId, "anyReason");
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestUnbanAccountValid()
        {
            var accountId = Guid.NewGuid();
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.OK
            };
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.UnbanAccount(accountId);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestVerifyAccountValid()
        {
            var accountId = Guid.NewGuid();
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.OK
            };
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.VerifyAccount(accountId);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestChangePasswordValid()
        {
            var accountId = Guid.NewGuid();
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.OK
            };
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.VerifyAccount(accountId);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestCreateAccountValid()
        {
            var account = new Account()
            {

            };
            var sessionToken = "213123123123";
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.Created
            };
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.CreateAccount(account, sessionToken);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestCreateDeviceAccountValid()
        {
            var account = new Account()
            {
                AccountType = EAccountType.Device
            };
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.Created
            };
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.CreateDeviceAccount(account);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }
    }
}
