using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOp.Providers.Message;
using RestSharp;
using Moq;
using System.Net;
using BOp.Services.Rest;
using System.Web;
using System.IO;
using BOp.Services.Serialization;
using BOp.Providers;

namespace BOp.Tests.Providers
{
    [TestClass]
    public class TenantIntroductionTests
    {
        private Mock<IRestClient> mockedClient;
        private IMessageServiceProvider provider;

        [TestInitialize]
        public void SetUp()
        {
            //mockedClient = new Mock<IRestClient>();
            //provider = new MessageProvider(mockedClient.Object);
        }

        [TestMethod]
        public void Test_Send_TennatIntroductionRequest_Message_Valid()
        {
            var requestingTenantCode = "KeY8bYKF";
            var approvingTenantCode = "zaHB4gaT";
            var request = new IntroductionRequest();
            request.IsAutoApproved = true;
            request.RequestComment = "Request Comment";
            request.RequestTitle = "Request Title";
            request.RequestingTenantCode = requestingTenantCode;
            request.RequestedForTenantCode = approvingTenantCode;
            string messageContent = request.ToPayload();
            var provider = ProviderFactory.Instance.CreateMessageServiceProvider();
            provider.SendMessage(new Message()
            {
                Header = new Header(){
                    Destination = new Target(),
                    Source = new Target(),
                    MessageID = Guid.NewGuid(),
                    Type = "tenant_introduction",
                    Subtype = "tenant_introduction.request"
                },
                Body = messageContent
            });

        }
    }
}
