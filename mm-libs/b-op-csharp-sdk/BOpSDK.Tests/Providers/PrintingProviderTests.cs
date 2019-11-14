using BOp.Providers;
using BOp.Providers.PCH;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BOp.Tests.Providers
{
    [TestClass]
    public class PrintingProviderTests
    {
        private Mock<IRestClient> mockedClient;
        private PrintingServiceProvider provider;

        [TestInitialize]
        public void SetUp()
        {
            mockedClient = new Mock<IRestClient>();
            provider = new PrintingServiceProvider(mockedClient.Object);
        }

        [TestMethod]
        public void IntegrationTestRequestPrintJob()
        {
            var provider = ProviderFactory.Instance.CreatePrintingServiceProvider();
            var result = provider.SubmitPrintJob(new PrintJobRequest()
            {
                Data = "test",
                Priority = 1,
                RequestedByAccountID = Guid.NewGuid(),
                RequestedByTenantID = Guid.NewGuid(),
                Template = "tmplt",
                Type = EPrintJobType.JASPER_PDF
            }, "testtest");

            var statuses = provider.GetPrintJobStatuses(result.PrintJobId, "testtest");
            var LatestStatuses = provider.GetPrintJobLatestStatus(result.PrintJobId, "testtest");
            Thread.Sleep(1000);
            provider.CancelPrintJob(result.PrintJobId, "testtest");
            statuses = provider.GetPrintJobStatuses(result.PrintJobId, "testtest");
            LatestStatuses = provider.GetPrintJobLatestStatus(result.PrintJobId, "testtest");
        }

        [TestMethod]
        public void IntegrationTestGetAgents()
        {
            Guid tenant = Guid.Parse("0993c033-d446-4bdf-8f0e-bbbcfb9074e1");
            var provider = ProviderFactory.Instance.CreatePrintingServiceProvider();
            var result = provider.GetPrintingAgents(tenant);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            var firstOne = provider.GetPrintingAgent(result[0].ID);
            Assert.IsNotNull(result);

            var logicalPrinters = provider.GetLogicalPrintersForTenant(tenant);
            
        }

    }
}
