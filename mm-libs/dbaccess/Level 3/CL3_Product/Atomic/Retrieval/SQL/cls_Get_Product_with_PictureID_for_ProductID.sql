
	Select
      cmn_pro_products.CMN_PRO_ProductID,
      cmn_pro_products.Product_Name_DictID,
      cmn_pro_products.Product_Description_DictID,
      cmn_pro_products.Product_Number,
      cmn_pro_products.IsCustomizable,
      cmn_pro_products.Product_DocumentationStructure_RefID,
      doc_document_2_structure.Document_RefID,
      cmn_pro_products.IsImportedFromExternalCatalog
    From
      cmn_pro_products Left Join
      doc_document_2_structure
        On cmn_pro_products.Product_DocumentationStructure_RefID =
        doc_document_2_structure.StructureHeader_RefID And
        (doc_document_2_structure.Tenant_RefID = @TenantID And
        doc_document_2_structure.IsDeleted = 0)
    Where
      cmn_pro_products.CMN_PRO_ProductID = @ProductID And
      cmn_pro_products.Tenant_RefID = @TenantID And
      cmn_pro_products.IsDeleted = 0
  