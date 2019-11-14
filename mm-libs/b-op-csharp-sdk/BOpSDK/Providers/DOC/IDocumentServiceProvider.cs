using BOp.Providers.DOC.DTO.Request;
using BOp.Providers.DOC.DTO.Response;
using BOp.Providers.DOC.Response;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.DOC
{
    public interface IDocumentServiceProvider
    {
        DocumentInfo GetDocumentInfo(Guid documentID, string sessionToken);
        string GenerateDownloadLink(Guid documentID, string sessionToken, bool? download = false, bool? urlSession = false, bool? isPublic = false);
        string GenerateImageThumbnailLink(Guid documentID, string sessionToken, bool? download = false, int? size = null, bool? urlSession = false, bool? isPublic = false);
        Guid UploadDocument(byte[] document, string documentName, string sessionToken, string uploadedFrom);
        Guid UploadDocument(Guid documentId, byte[] document, string documentName, string sessionToken, string uploadedFrom);
        ShareDocumentResponse ShareDocument(Guid documentID, ShareDocumentRequest request, string sessionToken);

        void DeleteDocument(Guid documentID, string sessionToken);

        // PERMISSIONS
        DocumentPermission GetDocumentPermission(Guid documentID, Guid permissionID);
        List<DocumentPermission> GetAllDocumentPermissions(Guid documentID);
        void CreateDocumentPermission(Guid documentID, DocumentPermission permission, string sessionToken);
        void RemoveDocumentPermission(Guid documentID, Guid permissionID, string sessionToken);
    }
}
