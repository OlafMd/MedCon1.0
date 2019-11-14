using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOp.Services;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;
using BOp.Providers;
using BOp.Providers.TMS.Requests;
using Moq;
using RestSharp;
using BOp.Providers.TMS;
using BOp.Services.Rest;
using System.Net;

namespace BOp.Tests.Providers
{
    [TestClass]
    public class SessionServiceTests
    {
        private Mock<IRestClient> mockedClient;
        private SessionServiceProvider provider;

        [TestInitialize]
        public void SetUp()
        {
            mockedClient = new Mock<IRestClient>();
            provider = new SessionServiceProvider(mockedClient.Object, null);
        }

        [TestMethod]
        public void TestSignInValid()
        {
            IRestResponse<object> mockedSingInResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.Created
            };
            mockedSingInResponse.Headers.Add(new Parameter()
            {
                Name = "Location",
                Value = "http://localhost:8080/cms/api/v3/sessions/123123123"
            });
            var mockedGetSessionInformationResponse = new RestResponse<Session>()
            {
                StatusCode = HttpStatusCode.OK
            };
            var mockedSesionResponse = new Session()
            {
                AccountID = Guid.NewGuid(),
                SessionToken = "123123123"
            };
            mockedGetSessionInformationResponse.Data = mockedSesionResponse;
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedSingInResponse);
            mockedClient.Setup<IRestResponse>(c => c.Execute<Session>(It.IsAny<JSONRestRequest>())).Returns(mockedGetSessionInformationResponse);
            var signInrequest = new SignInRequest()
            {

            };
            var resutl = provider.SignIn(signInrequest);
            Assert.AreEqual(resutl.SessionToken, mockedSesionResponse.SessionToken);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
            mockedClient.Verify(c => c.Execute<Session>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestSignInPlainPasswordValid()
        {
            IRestResponse<object> mockedSingInResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.Created
            };
            mockedSingInResponse.Headers.Add(new Parameter()
            {
                Name = "Location",
                Value = "http://localhost:8080/cms/api/v3/sessions/123123123"
            });
            var mockedGetSessionInformationResponse = new RestResponse<Session>()
            {
                StatusCode = HttpStatusCode.OK
            };
            var mockedSesionResponse = new Session()
            {
                AccountID = Guid.NewGuid(),
                SessionToken = "123123123"
            };
            mockedGetSessionInformationResponse.Data = mockedSesionResponse;
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedSingInResponse);
            mockedClient.Setup<IRestResponse>(c => c.Execute<Session>(It.IsAny<JSONRestRequest>())).Returns(mockedGetSessionInformationResponse);

            var resutl = provider.SignIn("test@test.com", "test");
            Assert.AreEqual(resutl.SessionToken, mockedSesionResponse.SessionToken);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
            mockedClient.Verify(c => c.Execute<Session>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestSignInPlainPasswordWithTenantValid()
        {
            IRestResponse<object> mockedSingInResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.Created
            };
            mockedSingInResponse.Headers.Add(new Parameter()
            {
                Name = "Location",
                Value = "http://localhost:8080/cms/api/v3/sessions/123123123"
            });
            var mockedGetSessionInformationResponse = new RestResponse<Session>()
            {
                StatusCode = HttpStatusCode.OK
            };
            var mockedSesionResponse = new Session()
            {
                AccountID = Guid.NewGuid(),
                SessionToken = "123123123"
            };
            mockedGetSessionInformationResponse.Data = mockedSesionResponse;
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedSingInResponse);
            mockedClient.Setup<IRestResponse>(c => c.Execute<Session>(It.IsAny<JSONRestRequest>())).Returns(mockedGetSessionInformationResponse);

            var resutl = provider.SignIn("test@test.com", "test", Guid.NewGuid());
            Assert.AreEqual(resutl.SessionToken, mockedSesionResponse.SessionToken);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
            mockedClient.Verify(c => c.Execute<Session>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestSignOutValid()
        {
            var sessionToken = "123123123";
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.OK
            };
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.SignOut(sessionToken);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }
        [TestMethod]
        public void TestCheckIfSessionExistsValid()
        {
            var sessionToken = "123123123";
            IRestResponse mockedResponse = new RestResponse()
            {
                StatusCode = HttpStatusCode.OK
            };
            mockedClient.Setup(c => c.Execute(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            bool doesSessionExist = provider.CheckIfSessionExists(sessionToken);
            Assert.AreEqual(true, doesSessionExist);
            mockedClient.Verify(c => c.Execute(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGetSessionInformationValid()
        {
            var sessionToken = "123123123";
            var mockedGetSessionInformationResponse = new RestResponse<Session>()
            {
                StatusCode = HttpStatusCode.OK
            };
            var mockedSesionResponse = new Session()
            {
                AccountID = Guid.NewGuid(),
                SessionToken = sessionToken
            };
            mockedGetSessionInformationResponse.Data = mockedSesionResponse;
            mockedClient.Setup<IRestResponse>(c => c.Execute<Session>(It.IsAny<JSONRestRequest>())).Returns(mockedGetSessionInformationResponse);
            var response = provider.GetSessionInformation(sessionToken);
            Assert.AreEqual(sessionToken, response.SessionToken);
            mockedClient.Verify(c => c.Execute<Session>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestVerifySessionTokenValid()
        {
            var sessionToken = "123123123";
            var mockedResponse = new RestResponse()
            {
                StatusCode = HttpStatusCode.OK
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var isSessionValid = provider.CheckIfSessionIsValid(sessionToken);
            Assert.AreEqual(true, isSessionValid);
            mockedClient.Verify(c => c.Execute(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestSwitchTenantValid()
        {
            var sessionToken = "123123123";
            var tenantIdHashed = "4297f44b13955235245b2497399d7a93";
            IRestResponse<object> mockedSwitchTenantResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.OK
            };
            mockedSwitchTenantResponse.Headers.Add(new Parameter()
            {
                Name = "Location",
                Value = "http://localhost:8080/cms/api/v3/sessions/123123123"
            });
            var mockedGetSessionInformationResponse = new RestResponse<Session>()
            {
                StatusCode = HttpStatusCode.OK
            };
            var mockedSesionResponse = new Session()
            {
                AccountID = Guid.NewGuid(),
                SessionToken = "123123123"
            };
            mockedGetSessionInformationResponse.Data = mockedSesionResponse;
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedSwitchTenantResponse);
            mockedClient.Setup<IRestResponse>(c => c.Execute<Session>(It.IsAny<JSONRestRequest>())).Returns(mockedGetSessionInformationResponse);
            var signInrequest = new SignInRequest()
            {

            };
            var resutl = provider.SwitchTenant(new SwitchTenantRequest()
            {
                TenantIdHash = tenantIdHashed
            }, sessionToken);
            Assert.AreEqual(resutl.SessionToken, mockedSesionResponse.SessionToken);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
            mockedClient.Verify(c => c.Execute<Session>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGenerateSessionTokenValid()
        {
            var request = new TemporaryTokenRequest()
            {
                AccountID = Guid.NewGuid(),
                TenantID = Guid.NewGuid(),
                TimeToLive = 132
            };
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = HttpStatusCode.Created
            };
            var p = new Parameter()
            {
                Name = "Location",
                Value = "http://test.com/sessions/123123123123"
            };
            mockedResponse.Headers.Add(p);
            mockedClient.Setup(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.GenerateTemporarySession(request);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);

        }
    }
}
