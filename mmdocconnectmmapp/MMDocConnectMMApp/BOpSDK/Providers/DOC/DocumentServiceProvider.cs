using BOp.Providers.DOC.DTO.Response;
using BOp.Providers.DOC.Response;
using BOp.Services.Rest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace BOp.Providers.DOC
{
    internal class DocumentServiceProvider : IDocumentServiceProvider
    {
        IRestClient _client;

        public DocumentServiceProvider(IRestClient client)
        {
            _client = client;
        }

        #region Document
        public DocumentInfo GetDocumentInfo(Guid documentID, string sessionToken)
        {
            var url = string.Format("api/v3/documents/{0}/info", documentID);
            var httpRequest = new JSONRestRequest(url);
            httpRequest.AddHeader("token", sessionToken);
            var documentInfoResponse = _client.Execute<DocumentInfo>(httpRequest);
            if (documentInfoResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Server returned:" + documentInfoResponse.StatusCode);
            }
            return documentInfoResponse.Data;
        }


        public Guid UploadDocument(byte[] document, string documentName, string sessionToken, string uploadedFrom)
        {
            return UploadDocument(Guid.NewGuid(), document, documentName, sessionToken, uploadedFrom);
        }

        public Guid UploadDocument(Guid documentID, byte[] document, string documentName, string sessionToken, string uploadedFrom)
        {
            var uploadUrl = string.Format("api/v3/documents/{0}?token={1}", documentID, sessionToken);
            if (uploadedFrom != null)
            {
                uploadUrl += ("&source=" + uploadedFrom);
            }
            var httpRequest = new RestRequest(uploadUrl, Method.POST);
            httpRequest.AddParameter(new Parameter()
            {
                Name = "token",
                Value = sessionToken
            });
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
            httpRequest.AddHeader("Content-Type", "multipart/form-data");
            httpRequest.AddParameter(new Parameter()
            {
                Name = "source",
                Value = uploadedFrom
            });
            httpRequest.AddFile("file", document, documentName);
            var uploadResponse = _client.Execute(httpRequest);
            if (uploadResponse.StatusCode != HttpStatusCode.Created)
            {
                throw new Exception("Server returned:" + uploadResponse.StatusCode);
            }
            return documentID;
        }


        public string GenerateDownloadLink(Guid documentID, string sessionToken, bool? download = false, bool? urlSession = false, bool? isPublic = false)
        {
            return GenerateImageThumbnailLink(documentID, sessionToken, download, null, urlSession, isPublic);
        }

        public string GenerateImageThumbnailLink(Guid documentID, string sessionToken, bool? download = false, int? size = null, bool? urlSession = false, bool? isPublic = false)
        {
            var relativePath = String.Format("{0}api/v3/documents/{1}?download={2}", _client.BaseUrl, documentID, download);
            var requestPathBuilder = new StringBuilder(relativePath);
            if (size != null) requestPathBuilder.Append("&size=").Append(size);
            if (!isPublic.GetValueOrDefault())
            {
                if (urlSession.GetValueOrDefault())
                {
                    requestPathBuilder.Append("&token=").Append(sessionToken);
                }
            }
            return requestPathBuilder.ToString();
        }
        public ShareDocumentResponse ShareDocument(Guid documentID, DTO.Request.ShareDocumentRequest request, string sessionToken)
        {
            var url = string.Format("api/v3/documents/{0}/share", documentID);
            var httpRequest = new JSONRestRequest(url, Method.POST);
            httpRequest.AddHeader("token", sessionToken);
            httpRequest.AddBody(request);
            var shareResponse = _client.Execute(httpRequest);
            if (shareResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Server returned:" + shareResponse.StatusCode);
            }
            var locationObject = shareResponse.Headers.FirstOrDefault(x => x.Name == "Location");
            String sharedDocumentLocation = (locationObject != null) ? (string)locationObject.Value : null;

            return new ShareDocumentResponse { sharedDocumentURL = sharedDocumentLocation };
        }

        public void DeleteDocument(Guid documentID, string sessionToken)
        {
            var url = string.Format("api/v3/documents/{0}", documentID);
            var httpRequest = new JSONRestRequest(url, Method.DELETE);
            httpRequest.AddHeader("token", sessionToken);
            var createResponse = _client.Execute(httpRequest);
            if (createResponse.StatusCode != HttpStatusCode.NoContent)
            {
                throw new Exception("Server returned:" + createResponse.StatusCode);
            }
        }

        #endregion Document

        #region Document Permissions
       
        public DocumentPermission GetDocumentPermission(Guid documentID, Guid permissionID)
        {
            var url = string.Format("api/v3/documents/{0}/permissions/{1}", documentID, permissionID);
            var httpRequest = new JSONRestRequest(url);
            var getDocumentPermissionResponse = _client.Execute<DocumentPermission>(httpRequest);
            if (getDocumentPermissionResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Server returned:" + getDocumentPermissionResponse.StatusCode);
            }
            return getDocumentPermissionResponse.Data;
        }

        public List<DocumentPermission> GetAllDocumentPermissions(Guid documentID)
        {
            var url = string.Format("api/v3/documents/{0}/permissions", documentID);
            var httpRequest = new JSONRestRequest(url);
            var getDocumentPermissionsResponse = _client.Execute<List<DocumentPermission>>(httpRequest);
            if (getDocumentPermissionsResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Server returned:" + getDocumentPermissionsResponse.StatusCode);
            }
            return getDocumentPermissionsResponse.Data;
        }

        /// <summary>
        /// Set document permission for tenant or for account. (if account no need to fill tenant id)
        /// </summary>
        /// <param name="documentID"></param>
        /// <param name="permission"></param>
        /// <param name="sessionToken"></param>
        public void CreateDocumentPermission(Guid documentID, DocumentPermission permission, string sessionToken)
        {
            var url = string.Format("api/v3/documents/{0}/permissions", documentID);
            var httpRequest = new JSONRestRequest(url, Method.POST);
            httpRequest.AddHeader("token", sessionToken);
            httpRequest.AddBody(permission);
            var createResponse = _client.Execute(httpRequest);
            if (createResponse.StatusCode != HttpStatusCode.Created)
            {
                throw new Exception("Server returned:" + createResponse.StatusCode);
            }
        }

        public void RemoveDocumentPermission(Guid documentID, Guid permissionID, string sessionToken)
        {
            var url = string.Format("api/v3/documents/{0}/permissions/{1}", documentID, permissionID);
            var httpRequest = new JSONRestRequest(url, Method.DELETE);
            httpRequest.AddHeader("token", sessionToken);
            var createResponse = _client.Execute(httpRequest);
            if (createResponse.StatusCode != HttpStatusCode.NoContent)
            {
                throw new Exception("Server returned:" + createResponse.StatusCode);
            }
        }

        #endregion Document Permissions


    }
}
