
        Select
          doc_structures.DOC_StructureID,
          doc_structures.Label,
          doc_structures.Parent_RefID,
          doc_structures.Structure_Header_RefID
      From
          doc_structures Inner Join
          doc_structure_headers On doc_structures.Structure_Header_RefID =
          doc_structure_headers.DOC_Structure_HeaderID Inner Join
          cmn_pro_product_releases On cmn_pro_product_releases.ProductRelease_DocumentationStructure_RefID =
          doc_structure_headers.DOC_Structure_HeaderID
      Where
          doc_structures.IsDeleted = 0 And
          doc_structure_headers.IsDeleted = 0 And
          cmn_pro_product_releases.IsDeleted = 0 And
          cmn_pro_product_releases.Tenant_RefID = @TenantID And
          cmn_pro_product_releases.CMN_PRO_Product_ReleaseID = @ID
  
  