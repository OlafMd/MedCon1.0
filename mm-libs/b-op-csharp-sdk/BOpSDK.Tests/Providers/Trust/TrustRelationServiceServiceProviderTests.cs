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
    public class TrustRelationProviderTests
    {
        private Mock<IRestClient> mockedClient;
        private ITrustRelationServiceProvider provider;

        [TestInitialize]
        public void SetUp()
        {
            mockedClient = new Mock<IRestClient>();
            provider = new TrustRelationServiceProvider(mockedClient.Object);
        }

        [TestMethod]
        public void TestGetAllTrustRelationsValid()
        {
            var tenantID = Guid.NewGuid();
            IRestResponse<List<TrustRelation>> mockedResponse = new RestResponse<List<TrustRelation>>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var trustRelations = new List<TrustRelation>()
            {
            };
            mockedResponse.Data = trustRelations;
            mockedClient.Setup<IRestResponse>(c => c.Execute<List<TrustRelation>>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetAllTrustRelations(tenantID);
            Assert.AreEqual(trustRelations, result);
            mockedClient.Verify(c => c.Execute<List<TrustRelation>>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestTrustRelationValid()
        {
            var tenantID = Guid.NewGuid();
            var trustRelationID = Guid.NewGuid();
            IRestResponse<TrustRelation> mockedResponse = new RestResponse<TrustRelation>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var trustRelation = new TrustRelation()
            {
            };
            mockedResponse.Data = trustRelation;
            mockedClient.Setup<IRestResponse>(c => c.Execute<TrustRelation>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetTrustRelation(tenantID, trustRelationID);
            Assert.AreEqual(trustRelation, result);
            mockedClient.Verify(c => c.Execute<TrustRelation>(It.IsAny<JSONRestRequest>()), Times.Once);
        }
    }
}
