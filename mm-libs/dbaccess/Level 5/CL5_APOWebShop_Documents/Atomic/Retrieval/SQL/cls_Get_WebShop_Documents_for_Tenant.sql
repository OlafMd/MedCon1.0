
		SELECT
		  ecm_doc_generaldocuments.ECM_DOC_GeneralDocumentID,
		  doc_documents.DOC_DocumentID,
		  doc_documents.Alias,
		  doc_documents.PrimaryType,
		  doc_documentrevisions.File_ServerLocation,
	    doc_documentrevisions.File_Name
		FROM
		  ecm_doc_generaldocuments
		  INNER JOIN doc_documents
		    ON doc_documents.DOC_DocumentID = ecm_doc_generaldocuments.Document_RefID
		    AND doc_documents.IsDeleted = 0
		  LEFT JOIN doc_documentrevisions
		    ON doc_documents.DOC_DocumentID = doc_documentrevisions.Document_RefID
		    AND doc_documentrevisions.IsDeleted = 0
		    AND doc_documentrevisions.IsLastRevision = 1
		WHERE
		ecm_doc_generaldocuments.IsDeleted = 0 AND
		ecm_doc_generaldocuments.IsPublicallyVisible = 1 AND
		ecm_doc_generaldocuments.Tenant_RefID = @TenantID AND
	  ecm_doc_generaldocuments.DocumentTypeMatchingID = @DocumentType
  