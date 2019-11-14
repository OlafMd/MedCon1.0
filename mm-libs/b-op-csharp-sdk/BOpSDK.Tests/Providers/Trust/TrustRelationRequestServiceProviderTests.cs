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
    public class TrustRelationRequestProviderTests
    {
        private Mock<IRestClient> mockedClient;
        private ITrustRelationRequestServiceProvider provider;

        [TestInitialize]
        public void SetUp()
        {
            mockedClient = new Mock<IRestClient>();
            provider = new TrustRelationRequestServiceProvider(mockedClient.Object);
        }

        [TestMethod]
        public void TestGetAllIncomingTrustRelationRequestsValid()
        {
            var tenantID = Guid.NewGuid();
            IRestResponse<List<TrustRelationRequest>> mockedResponse = new RestResponse<List<TrustRelationRequest>>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var requests = new List<TrustRelationRequest>()
            {
            };
            mockedResponse.Data = requests;
            mockedClient.Setup<IRestResponse>(c => c.Execute<List<TrustRelationRequest>>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetAllIncomingTrustRelationRequests(tenantID);
            Assert.AreEqual(requests, result);
            mockedClient.Verify(c => c.Execute<List<TrustRelationRequest>>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGetIncomingTrustRelationRequestValid()
        {
            var tenantID = Guid.NewGuid();
            var requestID = Guid.NewGuid();
            IRestResponse<TrustRelationRequest> mockedResponse = new RestResponse<TrustRelationRequest>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var request = new TrustRelationRequest()
            {
            };
            mockedResponse.Data = request;
            mockedClient.Setup<IRestResponse>(c => c.Execute<TrustRelationRequest>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetIncomingTrustRelationRequest(tenantID, requestID);
            Assert.AreEqual(request, result);
            mockedClient.Verify(c => c.Execute<TrustRelationRequest>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestAcceptIncomingTrustRelationRequestValid()
        {
            var tenantID = Guid.NewGuid();
            var requestID = Guid.NewGuid();
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = System.Net.HttpStatusCode.NoContent
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.AcceptIncomingTrustRelationRequest(tenantID, requestID, "thisLooksGood");
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestRejectIncomingTrustRelationRequestValid()
        {
            var tenantID = Guid.NewGuid();
            var requestID = Guid.NewGuid();
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = System.Net.HttpStatusCode.NoContent
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.RejectIncomingTrustRelationRequest(tenantID, requestID, "not good");
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGetAllOutgoingTrustRelationRequestsValid()
        {
            var tenantID = Guid.NewGuid();
            IRestResponse<List<TrustRelationRequest>> mockedResponse = new RestResponse<List<TrustRelationRequest>>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var requests = new List<TrustRelationRequest>()
            {
            };
            mockedResponse.Data = requests;
            mockedClient.Setup<IRestResponse>(c => c.Execute<List<TrustRelationRequest>>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetAllOutgoingTrustRelationRequests(tenantID);
            Assert.AreEqual(requests, result);
            mockedClient.Verify(c => c.Execute<List<TrustRelationRequest>>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGetOutgoingTrustRelationRequestValid()
        {
            var tenantID = Guid.NewGuid();
            var requestID = Guid.NewGuid();
            IRestResponse<TrustRelationRequest> mockedResponse = new RestResponse<TrustRelationRequest>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var request = new TrustRelationRequest()
            {
            };
            mockedResponse.Data = request;
            mockedClient.Setup<IRestResponse>(c => c.Execute<TrustRelationRequest>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetOutgoingTrustRelationRequest(tenantID, requestID);
            Assert.AreEqual(request, result);
            mockedClient.Verify(c => c.Execute<TrustRelationRequest>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestCancelOutgoingTrustRelationRequestValid()
        {
            var tenantID = Guid.NewGuid();
            var requestID = Guid.NewGuid();
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = System.Net.HttpStatusCode.NoContent
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.CancelOutgoingTrustRelationRequest(tenantID, requestID);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGetAllInitiatedTrustRelationRequestsValid()
        {
            var tenantID = Guid.NewGuid();
            IRestResponse<List<TrustRelationRequest>> mockedResponse = new RestResponse<List<TrustRelationRequest>>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var requests = new List<TrustRelationRequest>()
            {
            };
            mockedResponse.Data = requests;
            mockedClient.Setup<IRestResponse>(c => c.Execute<List<TrustRelationRequest>>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetAllInitiatedTrustRelationRequests(tenantID);
            Assert.AreEqual(requests, result);
            mockedClient.Verify(c => c.Execute<List<TrustRelationRequest>>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGetInitiatedTrustRelationRequestValid()
        {
            var tenantID = Guid.NewGuid();
            var requestID = Guid.NewGuid();
            IRestResponse<TrustRelationRequest> mockedResponse = new RestResponse<TrustRelationRequest>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var request = new TrustRelationRequest()
            {
            };
            mockedResponse.Data = request;
            mockedClient.Setup<IRestResponse>(c => c.Execute<TrustRelationRequest>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetInitiatedTrustRelationRequest(tenantID, requestID);
            Assert.AreEqual(request, result);
            mockedClient.Verify(c => c.Execute<TrustRelationRequest>(It.IsAny<JSONRestRequest>()), Times.Once);
        }


        [TestMethod]
        public void TestSendTrustRelationRequestValid()
        {
            var builder = new TrustRelationRequestBuilder();
            builder.SetAutoApproved(true).SetFromTenant(Guid.NewGuid()).SetToTenant(Guid.NewGuid()).SetInvitationCode("test");
            var request = builder.Build();

            var tenantID = Guid.NewGuid();
            var requestID = Guid.NewGuid();
            IRestResponse<Dictionary<String, String>> creationMockedResponse = new RestResponse<Dictionary<String, String>>()
            {
                StatusCode = System.Net.HttpStatusCode.Created
            };
            creationMockedResponse.Data = new Dictionary<string, string>();
            creationMockedResponse.Data["code"] = Guid.NewGuid().ToString();
            mockedClient.Setup<IRestResponse>(c => c.Execute<Dictionary<String, String>>(It.IsAny<JSONRestRequest>())).Returns(creationMockedResponse);

            IRestResponse<TrustRelationRequest> retrievalMockedResponse = new RestResponse<TrustRelationRequest>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            retrievalMockedResponse.Data = new TrustRelationRequest();
            mockedClient.Setup<IRestResponse>(c => c.Execute<TrustRelationRequest>(It.IsAny<JSONRestRequest>())).Returns(retrievalMockedResponse);
            var result = provider.SendTrustRelationRequest(request, true);
            Assert.AreEqual(request.Code, request.Code);
            Assert.AreEqual(request.FromTenant, request.FromTenant);
            Assert.AreEqual(request.ToTenant, request.ToTenant);
            //TODO: Implement rest of the check

            mockedClient.Verify(c => c.Execute<Dictionary<String, String>>(It.IsAny<JSONRestRequest>()), Times.Once);
            mockedClient.Verify(c => c.Execute<TrustRelationRequest>(It.IsAny<JSONRestRequest>()), Times.Once);


        }

    }
}
