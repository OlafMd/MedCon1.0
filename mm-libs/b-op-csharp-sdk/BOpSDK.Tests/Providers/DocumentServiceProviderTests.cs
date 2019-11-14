using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOp.Providers.DOC;
using RestSharp;
using Moq;
using System.Net;
using BOp.Services.Rest;
using System.Collections.Generic;
using System.Reflection;
using BOp.Providers;

namespace BOp.Tests.Providers
{
    [TestClass]
    public class DocumentServiceProviderTests
    {
        private Mock<IRestClient> mockedClient;
        private IDocumentServiceProvider provider;
        [TestInitialize]
        public void SetUp()
        {
            mockedClient = new Mock<IRestClient>();
            provider = new DocumentServiceProvider(mockedClient.Object);
        }
        [TestMethod]
        public void TestGetDocumentPermissionValid()
        {
            var documentId = Guid.NewGuid();
            var documentPermissionId = Guid.NewGuid();
            IRestResponse<DocumentPermission> mockedResponse = new RestResponse<DocumentPermission>()
            {
                StatusCode = HttpStatusCode.OK,
                Data = new DocumentPermission()
                {
                    ID = Guid.NewGuid()
                }
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute<DocumentPermission>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetDocumentPermission(documentId, documentPermissionId);
            mockedClient.Verify(c => c.Execute<DocumentPermission>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGetDocumentPermissionsValid()
        {
            var documentId = Guid.NewGuid();
            var documentPermissionId = Guid.NewGuid();
            var mockedResponse = new RestResponse<List<DocumentPermission>>()
            {
                StatusCode = HttpStatusCode.OK,
                Data = new List<DocumentPermission>(){
                    new DocumentPermission()
                {
                    ID = Guid.NewGuid()
                }}
            };
            mockedClient.Setup<IRestResponse>(c => c.Execute<List<DocumentPermission>>(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            var result = provider.GetAllDocumentPermissions(documentId);
            mockedClient.Verify(c => c.Execute<List<DocumentPermission>>(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestSaveDocumentPermissionValid()
        {
            var documentId = Guid.NewGuid();
            var sessionToken = "asdasdasd";
            var permission = new DocumentPermission()
            {
                AccountID = Guid.NewGuid(),
                TenantID = Guid.NewGuid(),
            };
            var mockedResponse = new RestResponse()
            {
                StatusCode = HttpStatusCode.Created
            };
            mockedClient.Setup(c => c.Execute(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);

            provider.CreateDocumentPermission(documentId, permission, sessionToken);
            mockedClient.Verify(c => c.Execute(It.IsAny<JSONRestRequest>()), Times.Once);

        }
        [TestMethod]
        public void TestRemoveDocumentPermissionValid()
        {
            var documentId = Guid.NewGuid();
            var permissionId = Guid.NewGuid();
            var sessionToken = "asdasdasd";
            var mockedResponse = new RestResponse()
            {
                StatusCode = HttpStatusCode.NoContent
            };
            mockedClient.Setup(c => c.Execute(It.IsAny<JSONRestRequest>())).Returns(mockedResponse);
            provider.RemoveDocumentPermission(documentId, permissionId, sessionToken);
            mockedClient.Verify(c => c.Execute(It.IsAny<JSONRestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestUploadDocumentValid()
        {
            var documentId = Guid.NewGuid();
            var sessionToken = "asdadasd";
            var mockedResponse = new RestResponse()
            {
                StatusCode = HttpStatusCode.Created
            };
            mockedClient.Setup(c => c.Execute(It.IsAny<RestRequest>())).Returns(mockedResponse);
            provider.UploadDocument(getDocumentBytes(), "whatever", sessionToken, "tests");
            mockedClient.Verify(c => c.Execute(It.IsAny<RestRequest>()), Times.Once);
        }

        [TestMethod]
        public void TestGenerateDownloadLinkValid()
        {
            var baseUrl = "http://localhost:8080/doc/";
            var documentId = Guid.Parse("0799A27A-F6CD-48DF-87DE-CA0681485542");
            var sessionToken = "asdasd";
            var download = true;
            var documentProvider = new DocumentServiceProvider(new RestClient()
            {
                BaseUrl = new Uri(baseUrl)
            });
            var downloadLink = documentProvider.GenerateDownloadLink(documentId, sessionToken, download);
            Assert.AreEqual("http://localhost:8080/doc/api/v3/documents/0799a27a-f6cd-48df-87de-ca0681485542?download=True", downloadLink);
        }

        [TestMethod]
        public void TestGenerateThunbmanilLinkValid()
        {
            var baseUrl = "http://localhost:8080/doc/";
            var documentId = Guid.Parse("0799A27A-F6CD-48DF-87DE-CA0681485542");
            var sessionToken = "asdasd";
            var download = true;
            var size = 120;
            var documentProvider = new DocumentServiceProvider(new RestClient()
            {
                BaseUrl = new Uri(baseUrl)
            });
            var downloadLink = documentProvider.GenerateImageThumbnailLink(documentId, sessionToken, download, size);
            Assert.AreEqual("http://localhost:8080/doc/api/v3/documents/0799a27a-f6cd-48df-87de-ca0681485542?download=True&size=120", downloadLink);
        }
        
        private byte[] getDocumentBytes()
        {
            using (var fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BOp.Tests.Resources.test.jpg"))
            {
                if (fileStream == null) return null;
                byte[] ba = new byte[fileStream.Length];
                fileStream.Read(ba, 0, ba.Length);
                return ba;
            }
        }
    }
}
