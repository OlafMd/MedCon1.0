using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOp.Providers.TrustRelation;
using System.Collections.Generic;
using BOp.Providers;
using BOp.Exceptions;
using BOp.Providers.TMS.Requests;
using System.Threading;

namespace BOp.Tests.IntegrationTests
{
    [TestClass]
    public class TrustRelationTests
    {
        private Tenant _sourceTenant;
        private Tenant _targetTenant;
        private Tenant _initiatingTenant;
        private TrustRelationType _trustRelationType;

        [TestInitialize]
        public void Initialize()
        {
            _sourceTenant = Utils.CreateRegistrationEntity().Tenant;
            _targetTenant = Utils.CreateRegistrationEntity().Tenant;
            _initiatingTenant = Utils.CreateRegistrationEntity().Tenant;

            var trustRelationTypeProvider = ProviderFactory.Instance.CreateTrustRelationTypeServiceProvider();

            _trustRelationType = new TrustRelationType()
            {
                ID = Guid.NewGuid(),
                MessageTypes = new List<string>() { "One", "Two", "Three" },
                Name = new Dictionary<string, string>(){ 
                    {"en","Trust Relation Name"}
                },
                Description = new Dictionary<string, string>(){
                    {"en","Trust Relation Description"}
                },
                CreatedByApplicationID = Guid.NewGuid()
            };
            trustRelationTypeProvider.SaveTrustRelationType(_trustRelationType);
        }


        [TestMethod]
        public void IntegrationTest_TrustRelation_TestErrorHandling()
        {
            try
            {
                var provider = ProviderFactory.Instance.CreateTrustRelationRequestServiceProvider();
                var builder = new TrustRelationRequestBuilder();
                builder.SetFromTenant(Guid.Empty);
                var request = builder.Build();
                provider.SendTrustRelationRequest(request);
            }
            catch (SDKServiceException ex)
            {
                Assert.AreEqual(ex.ServerResponseCode, System.Net.HttpStatusCode.BadRequest);
                //Should throw exception
            }

        }

        /// <summary>
        /// Trusts the relation request with response.
        /// </summary>
        [TestMethod]
        public void IntegrationTest_TrustRelation_RequestWithAutoResponse()
        {
            var providerFactory = ProviderFactory.Instance;
            var typeProvider = providerFactory.CreateTrustRelationTypeServiceProvider();


            var builder = new TrustRelationRequestBuilder();
            builder.SetFromTenant(_sourceTenant.ID).SetToTenant(_targetTenant.ID);
            builder.SetMessage("TestMsg").SetTitle("title").SetLanguageISO("en");
            builder.AddOfferedTrustType(_trustRelationType.ID).AddRequestedTrustType(_trustRelationType.ID);

            var request = builder.Build();
            var requestProvider = providerFactory.CreateTrustRelationRequestServiceProvider();
            requestProvider.SendTrustRelationRequest(request, true);
            Thread.Sleep(1000);


            var incomingReqests = requestProvider.GetAllIncomingTrustRelationRequests(_targetTenant.ID);
            Assert.AreEqual(1, incomingReqests.Count);
            Assert.AreEqual(TrustRequestStatus.Accepted, incomingReqests[0].Status);

            var outgoingReqests = requestProvider.GetAllOutgoingTrustRelationRequests(_sourceTenant.ID);
            Assert.AreEqual(1, outgoingReqests.Count);
            Assert.AreEqual(TrustRequestStatus.Accepted, outgoingReqests[0].Status);
        }
        [TestMethod]
        public void IntegrationTest_TrustRelation_RequestWithResponse()
        {
            var providerFactory = ProviderFactory.Instance;
            var typeProvider = providerFactory.CreateTrustRelationTypeServiceProvider();

            var builder = new TrustRelationRequestBuilder();
            builder.SetFromTenant(_sourceTenant.ID).SetToTenant(_targetTenant.ID);
            builder.SetMessage("TestMsg").SetTitle("title").SetLanguageISO("en");
            builder.AddOfferedTrustType(_trustRelationType.ID).AddRequestedTrustType(_trustRelationType.ID);

            var request = builder.Build();
            var requestProvider = providerFactory.CreateTrustRelationRequestServiceProvider();
            requestProvider.SendTrustRelationRequest(request);

            Thread.Sleep(500);

            var incomingReqests = requestProvider.GetAllIncomingTrustRelationRequests(_targetTenant.ID);
            Assert.AreEqual(1, incomingReqests.Count);
            Assert.AreEqual(TrustRequestStatus.Pending, incomingReqests[0].Status);
            requestProvider.AcceptIncomingTrustRelationRequest(_targetTenant.ID, incomingReqests[0].Code, "fine");

            Thread.Sleep(500);
            var outgoingReqests = requestProvider.GetAllOutgoingTrustRelationRequests(_sourceTenant.ID);
            Assert.AreEqual(1, outgoingReqests.Count);
            Assert.AreEqual(TrustRequestStatus.Accepted, outgoingReqests[0].Status);

        }

        [TestMethod]
        public void IntegrationTest_TrustRelation_RequestInitiatedAutoApproved()
        {
            var providerFactory = ProviderFactory.Instance;
            var requestProvider = providerFactory.CreateTrustRelationRequestServiceProvider();

            var builder = new TrustRelationRequestBuilder();
            builder.SetFromTenant(_sourceTenant.ID)
                .SetToTenant(_targetTenant.ID)
                .SetInitiatedFromTenant(_initiatingTenant.ID);

            builder.SetMessage("TestMsg").SetTitle("title").SetLanguageISO("en");
            builder.AddOfferedTrustType(_trustRelationType.ID).AddRequestedTrustType(_trustRelationType.ID);

            var request = builder.Build();

            requestProvider.SendTrustRelationRequest(request, true);
            Thread.Sleep(1500);

            var incomingReqests = requestProvider.GetAllIncomingTrustRelationRequests(_targetTenant.ID);
            Assert.AreEqual(1, incomingReqests.Count);
            Assert.AreEqual(TrustRequestStatus.Accepted, incomingReqests[0].Status);
            var outgoingReqests = requestProvider.GetAllOutgoingTrustRelationRequests(_sourceTenant.ID);
            Assert.AreEqual(1, outgoingReqests.Count);
            Assert.AreEqual(TrustRequestStatus.Accepted, outgoingReqests[0].Status);

            var initiatedReqests = requestProvider.GetAllInitiatedTrustRelationRequests(_initiatingTenant.ID);
            Assert.AreEqual(1, initiatedReqests.Count);
            Assert.AreEqual(TrustRequestStatus.Accepted, initiatedReqests[0].Status);

            //requestProvider.AcceptIncomingTrustRelationRequest(targetTenant, incomingReqests[0].Code, "fine");

        }
    }
}
