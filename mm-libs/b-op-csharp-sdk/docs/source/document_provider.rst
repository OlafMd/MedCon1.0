Document Provider
=================

Document provider offers the support to upload/download the documents to the b-op services. The uploadded documents are private by default and offer limited support.

To initialize the provider, the application must be configured in the app.config or the web.config file.

.. code-block:: xml
   :emphasize-lines: 3

	<configuration>
		<appSettings>
			<add key="bop.config.provider.doc" value="http://local.b-op.com:8080/doc/" />
		</appSettings>
	</configuration>

For every operation, a provider instance is required which can be obtained by

.. code-block:: csharp

	var provider = BOp.Providers.ProviderFactory.Instance.CreateDocumentServiceProvider();


Available Methods
-----------------

Methods that the document provider offers:


GetDocumentInfo
"""""""""""""""

.. function:: DocumentInfo GetDocumentInfo(Guid documentID, string sessionToken);

   Returns the document information for the provided document ID.

   :param documentID: specifies the document ID for the document information
   :param sessionToken: ssession token to verify if the request is valid
   :rtype: DocumentInformation about the requested document ID


GenerateDownloadLink
""""""""""""""""""""

.. function:: string GenerateDownloadLink(Guid documentID, string sessionToken, bool? download = false, bool? urlSession = false, bool? isPublic = false);

	Generates the download link for the document, which will can give access to the document

	:param documentID: document ID for which the document link will be generated
	:param sessionToken: session token to verify if the request is valid
	:param download: specify if the browser should not try to render the document, but to download it only
	:param urlSession: specify if the session token should be passsed as an URL parameter
	:param isPublic: specify if the link to the download is public
	:rtype: download link to the document


GenerateImageThumbnailLink
""""""""""""""""""""""""""

.. function:: string GenerateImageThumbnailLink(Guid documentID, string sessionToken, bool? download = false, int? size = null, bool? urlSession = false, bool? isPublic = false);

	Generates the link to an image thumbnail. The thumbnail is created on the fly to reduce the bandwidth requirements of applications

	:param documentID: document ID for which the thumbnail will be downloaded
	:param sessionToken: session token to verify if the request is valid
	:param download: specify if the browser should not try to render the document, but to download it only
	:param urlSession: specify if the session token should be passsed as an URL parameter
	:param isPublic: specify if the link to the download is public
	:rtype: download link to the document thumbnail


UploadDocument
""""""""""""""

.. function:: Guid UploadDocument(byte[] document, string documentName, string sessionToken, string uploadedFrom);
	
	Uploads a document to the document service. The document can later be retrieved. The method optionally takes a documentId parameter, which sets the documentId instead of making the document service. 

	:param documentID: specific document ID for the upload
	:param document: document contents
	:param documentName: specifies the document name for the uploaded document
	:param sessionToken: session token to verify if the request is valid
	:param uploadedFrom: IP Address where the document was uploaded from
	:rtype: id of the uploaded document

ShareDocument
"""""""""""""

.. function:: ShareDocumentResponse ShareDocument(Guid documentID, ShareDocumentRequest request, string sessionToken);

	Shares the document publically for a limited (or unlimited time). The shared document, unlike the standard document is available publically.

	:param documentID: specified document ID
	:param request: contains parameters for the sharing of the document such as time to live
	:param sessionToken: session token to verify if the request is valid

DeleteDocument
""""""""""""""

.. function:: void DeleteDocument(Guid documentID, string sessionToken);

	Deletes the document from the document server. This also deletes all the shared document bound to this document.

	:param documentID: specified document ID to be deleted
	:param sessionToken: session token to verify if the request is valid


GetDocumentPermission
"""""""""""""""""""""

.. function:: DocumentPermission GetDocumentPermission(Guid documentID, Guid permissionID);

	Retrieves the permissions for a document. 

	:param documentID: specified document ID to be retrieved
	:param permissionID: specified permission ID to be retrieved

GetAllDocumentPermissions
"""""""""""""""""""""""""

.. function:: List<DocumentPermission> GetAllDocumentPermissions(Guid documentID);

	Gets all the permissions of a document.

	:param documentID: specified document ID to be deleted
	:rtype: list of document permissions

CreateDocumentPermission
""""""""""""""""""""""""

.. function:: void CreateDocumentPermission(Guid documentID, DocumentPermission permission, string sessionToken);

	Creates a document permission for the specified document for either a tenant or an account from a tenant

	:param documentID: specified document ID to be deleted
	:param permission: contains the permission which is to be added either for a tenant or a specific account of a tenant
	:param sessionToken: session token to verify if the request is valid


RemoveDocumentPermission
""""""""""""""""""""""""

.. function:: void RemoveDocumentPermission(Guid documentID, Guid permissionID, string sessionToken);
	
	Removes the document permission with the specified id, for that document


	:param documentID: specified document ID which holds the permission 
	:param permissionID: specified permissionID to be deleted
	:param sessionToken: session token to verify if the request is valid


