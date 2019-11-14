
  Select
  Count(doc_documents.GlobalPropertyMatchingID) As numbersOfPDFReports
From
  doc_documents
Where
  doc_documents.GlobalPropertyMatchingID = "pdf mm" And
  doc_documents.IsDeleted = 0 And
  doc_documents.Tenant_RefID = @TenantID


    