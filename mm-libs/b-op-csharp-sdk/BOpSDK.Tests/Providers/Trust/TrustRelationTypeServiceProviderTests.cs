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
    public class TrustRelationTypeProviderTests
    {
        private Mock<IRestClient> mockedClient;
        private ITrustRelationTypeServiceProvider provider;

        [TestInitialize]
        public void SetUp()
        {
            mockedClient = new Mock<IRestClient>();
            provider = new TrustRelationTypeServiceProvider(mockedClient.Object);
        }

        [TestMethod]
        public void TestGetAllTrustRelationTypesValid()
        {
            IRestResponse<List<TrustRelationType>> mockedResponse = new RestResponse<List<TrustRelationType>>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var types = new List<TrustRelationType>(){
                new TrustRelationType(){
                    ID = Guid.NewGuid(),
                    MessageTypes = new List<string>(){
                        "test", "test1"
                    }                   
                }
            };
            mockedResponse.Data = types;
            mockedClient.Setup<IRestResponse>(c => c.Execute<List<TrustRelationType>>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetAllTrustRelationTypes();
            Assert.AreEqual(types, result);
            mockedClient.Verify(c => c.Execute<List<TrustRelationType>>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGetAllTrustRelationTypesForApplicationIDValid()
        {
            var appID = Guid.NewGuid();
            IRestResponse<List<TrustRelationType>> mockedResponse = new RestResponse<List<TrustRelationType>>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var types = new List<TrustRelationType>(){
                new TrustRelationType(){
                    ID = Guid.NewGuid(),
                    CreatedByApplicationID = appID,
                    MessageTypes = new List<string>(){
                        "test", "test1"
                    }                   
                }
            };
            mockedResponse.Data = types;
            mockedClient.Setup<IRestResponse>(c => c.Execute<List<TrustRelationType>>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetAllTrustRelationTypes(appID);
            Assert.AreEqual(types, result);
            mockedClient.Verify(c => c.Execute<List<TrustRelationType>>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGetTrustRelationTypeByIdValid()
        {
            var id = Guid.NewGuid();
            IRestResponse<TrustRelationType> mockedResponse = new RestResponse<TrustRelationType>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var type = new TrustRelationType()
            {
                ID = id,
                MessageTypes = new List<string>(){
                        "test", "test1"
                }
            };
            mockedResponse.Data = type;
            mockedClient.Setup<IRestResponse>(c => c.Execute<TrustRelationType>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetTrustRelationType(id);
            Assert.AreEqual(type, result);
            mockedClient.Verify(c => c.Execute<TrustRelationType>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestSaveTrustRelationTypeValid()
        {
            var id = Guid.NewGuid();
            var type = new TrustRelationType()
            {
                ID = id,
                MessageTypes = new List<string>(){
                        "test", "test1"
                }
            };
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = System.Net.HttpStatusCode.NoContent
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.SaveTrustRelationType(type);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestRemoveTrustRelationTypeValid()
        {
            var id = Guid.NewGuid();
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = System.Net.HttpStatusCode.NoContent
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.RemoveTrustRelationType(id);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }


        [TestMethod]
        public void TestGetAllTrustRelationTypeGroupsValid()
        {
            IRestResponse<List<TrustRelationTypeGroup>> mockedResponse = new RestResponse<List<TrustRelationTypeGroup>>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var groups = new List<TrustRelationTypeGroup>(){
                new TrustRelationTypeGroup(){
                    Code = "test",
                    ApplicationID = Guid.NewGuid()
                }
            };
            mockedResponse.Data = groups;
            mockedClient.Setup<IRestResponse>(c => c.Execute<List<TrustRelationTypeGroup>>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetAllTrustRelationTypeGroups();
            Assert.AreEqual(groups[0].Code, result[0].Code);
            Assert.AreEqual(groups[0].ApplicationID, result[0].ApplicationID);
            mockedClient.Verify(c => c.Execute<List<TrustRelationTypeGroup>>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGetTrustRelationTypeGroupValid()
        {
            var code = "test";
            IRestResponse<TrustRelationTypeGroup> mockedResponse = new RestResponse<TrustRelationTypeGroup>()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            var group = new TrustRelationTypeGroup()
            {
                Code = code,
                ApplicationID = Guid.NewGuid()

            };
            mockedResponse.Data = group;
            mockedClient.Setup<IRestResponse>(c => c.Execute<TrustRelationTypeGroup>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetTrustRelationGroup(code);
            Assert.AreEqual(group, result);
            mockedClient.Verify(c => c.Execute<TrustRelationTypeGroup>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestSaveTrustRelationTypeGroupValid()
        {
            var code = "code";
            var group = new TrustRelationTypeGroup()
            {
                Code = code,
                ApplicationID = Guid.NewGuid(),
                OfferedTrustTypes = new List<Guid>()
                {
                    Guid.NewGuid()
                }
            };
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = System.Net.HttpStatusCode.Created
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.SaveTrustRelationTypeGroup(group);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestRemoveTrustRelationTypeGroupValid()
        {
            var code = "test";
            IRestResponse<object> mockedResponse = new RestResponse<object>()
            {
                StatusCode = System.Net.HttpStatusCode.NoContent
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute<object>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.RemoveTrustRelationTypeGroup(code);
            mockedClient.Verify(c => c.Execute<object>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

    }
}
