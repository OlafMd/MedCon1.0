using BOp.Providers;
using BOp.Providers.TMS;
using BOp.Providers.TrustRelation;
using BOp.Services.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Tests.Providers
{
    [TestClass]
    public class TrustRelationRequestInvitationProviderTests
    {
        private Mock<IRestClient> mockedClient;
        private TrustRelationRequestInvivationServiceProvider provider;

        [TestInitialize]
        public void SetUp()
        {
            mockedClient = new Mock<IRestClient>();
            provider = new TrustRelationRequestInvivationServiceProvider(mockedClient.Object);
        }

        [TestMethod]
        public void TestGetAllTrustRelationRequestInvitationsValid()
        {
            var tenantID = Guid.NewGuid();
            IRestResponse<List<TrustRelationRequestInvitation>> mockedResponse = new RestResponse<List<TrustRelationRequestInvitation>>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var invitations = new List<TrustRelationRequestInvitation>(){
                new TrustRelationRequestInvitation(){
                    Code = "code",
                    Configuration = "test",
                    Groups = new List<string>(){"test", "tst1"},
                    Text = "whatever"                    
                }
            };
            mockedResponse.Data = invitations;
            mockedClient.Setup<IRestResponse>(c => c.Execute<List<TrustRelationRequestInvitation>>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetAllTrustRelationRequestInvitations(tenantID);
            Assert.AreEqual(invitations, result);
            mockedClient.Verify(c => c.Execute<List<TrustRelationRequestInvitation>>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGetTrustRelationRequestInvitationByCodeValid()
        {
            var tenantID = Guid.NewGuid();
            var code = "code";
            IRestResponse<TrustRelationRequestInvitation> mockedResponse = new RestResponse<TrustRelationRequestInvitation>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var invitation = new TrustRelationRequestInvitation()
            {
                Code = "code",
                Configuration = "test",
                Groups = new List<string>() { "test", "tst1" },
                Text = "whatever"
            };
            mockedResponse.Data = invitation;
            mockedClient.Setup<IRestResponse>(c => c.Execute<TrustRelationRequestInvitation>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetTrustRelationRequestInvitation(code, tenantID);
            Assert.AreEqual(invitation, result);
            mockedClient.Verify(c => c.Execute<TrustRelationRequestInvitation>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestSaveTrustRelationRequestInvitationValid()
        {
            var tenantID = Guid.NewGuid();
            var type = new TrustRelationRequestInvitation()
            {
                Code = "code",
                Configuration = "test",
                Groups = new List<string>() { "test", "tst1" },
                Text = "whatever"
            };
            var mockedResponse = new RestResponse<Object>()
            {
                StatusCode = System.Net.HttpStatusCode.Created
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute<Object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.SaveTrustRelationRequestInvitation(type, tenantID);
            mockedClient.Verify(c => c.Execute<Object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestRemoveTrustRelationRequestInvitationValid()
        {
            var tenantID = Guid.NewGuid();
            var code = "test";
            var mockedResponse = new RestResponse<Object>()
            {
                StatusCode = System.Net.HttpStatusCode.NoContent
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.RemoveTrustRelationRequestInvitation(code, tenantID);
            mockedClient.Verify(c => c.Execute<Object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestRevokeTrustRelationRequestInvitationValid()
        {
            var tenantID = Guid.NewGuid();
            var code = "test";
            var mockedResponse = new RestResponse<Object>()
            {
                StatusCode = System.Net.HttpStatusCode.NoContent
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.RevokeTrustRelationRequestInvitation(code, tenantID);
            mockedClient.Verify(c => c.Execute<Object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }
    }
}
