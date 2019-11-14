
Select
  Count(doc_documents.DOC_DocumentID) As numberOfEdifacts
From
  doc_documents
Where
  doc_documents.Tenant_RefID = @TenantID And
  doc_documents.PrimaryType = 'EDIFACT' And
  doc_documents.GlobalPropertyMatchingID = @ContractID And     
  YEAR(doc_documents.Creation_Timestamp) = YEAR(CURDATE())
  


    