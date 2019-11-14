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

namespace BOp.Tests.Providers
{
    [TestClass]
    public class MessageServiceProviderTests
    {
        private Mock<IRestClient> mockedClient;
        private IMessageServiceProvider provider;

        [TestInitialize]
        public void SetUp()
        {
            mockedClient = new Mock<IRestClient>();
            provider = new MessageServiceProvider(mockedClient.Object);
        }

        [TestMethod]
        public void Test_ListenerSerialization()
        {
            var listener = new MessageListener()
            {
                ApplicationID = Guid.NewGuid(),
                ModuleID = Guid.NewGuid(),
                MessageTypes = new List<string> { "message.type1", "message.type2" },
                Endpoints = new List<Uri> { new Uri("http://google.com") }
            };


            var serializer = new BOp.Services.Serialization.JSONSerializer();
            var actualData = serializer.Serialize(listener);
            var expectedData = "{{\"applicationId\":\"{0}\",\"moduleId\":\"{1}\"" +
                ",\"endpoints\":[\"http://google.com\"],\"messageTypes\":[\"message.type1\",\"message.type2\"]}}";
            Assert.AreEqual(String.Format(expectedData, listener.ApplicationID, listener.ModuleID), actualData);
        }

        [TestMethod]
        public void Test_MessageSerialization()
        {




        }



        [TestMethod]
        public void Test_MessageHandlerRegistration_Valid()
        {
            bool messageReceived = false;
            string subtype = "example-message";


            HandleMessage handler = delegate(Message receivedMessage)
            {
                messageReceived = true;
            };

            var repo = new MessageHandlerRepository();
            repo.RegisterHandler(handler, subtype);

            var message = new Message();
            message.Header = new Header();
            message.Header.Subtype = subtype;
            repo.ProcessMessage(message);


            Assert.IsTrue(messageReceived);
        }

        [TestMethod]
        public void Test_MessageReceival_Valid()
        {
            bool messageReceived = false;
            string subtype = "example-message";

            var msg = new Message();
            msg.Header = new Header();
            msg.Header.MessageID = Guid.NewGuid();
            msg.Header.Subtype = subtype;


            HandleMessage handler = delegate(Message rMsg)
            {
                Assert.AreEqual(msg.Header.Subtype,rMsg.Header.Subtype);
                Assert.AreEqual(msg.Header.MessageID,rMsg.Header.MessageID);

                messageReceived = true;
            };

            var repo = new MessageHandlerRepository();
            repo.RegisterHandler(handler, subtype);


            var messageListener = new MessageListenerService(repo);


            string messageData = new JSONSerializer().Serialize(msg);
            messageListener.ProcessMessage(messageData);
            
            Assert.IsTrue(messageReceived);
        }

    }
}
