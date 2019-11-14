
	Select
	  cmn_bpt_ctm_catalogproductextensionrequest_products.CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID,
	  cmn_bpt_ctm_catalogproductextensionrequest_products.CMN_PRO_Product_RefID,
	  cmn_bpt_ctm_catalogproductextensionrequest_products.Comment,
	  cmn_bpt_ctm_catalogproductextensionrequests.IsAnswerSent,
	  cmn_bpt_ctm_catalogproductextensionrequests.IfAnswerSent_Date,
	  cmn_bpt_ctm_catalogproductextensionrequests.Request_Answer,
	  cmn_pro_products.Product_Name_DictID,
	  cmn_pro_products.Product_Description_DictID,
	  cmn_pro_products.Product_Number,
	  cmn_sls_prices.PriceAmount,
    cmn_pro_products.ProductITL
	From
	  cmn_bpt_ctm_catalogproductextensionrequest_products 
	  Left Outer Join cmn_bpt_ctm_catalogproductextensionrequests On
	    cmn_bpt_ctm_catalogproductextensionrequest_products.CatalogProductExtensionRequest_RefID = cmn_bpt_ctm_catalogproductextensionrequests.CMN_BPT_CTM_CatalogProductExtensionRequestID 
		And (cmn_bpt_ctm_catalogproductextensionrequests.IsDeleted = 0 
		And cmn_bpt_ctm_catalogproductextensionrequests.Tenant_RefID = @TenantID) 
	  Inner Join cmn_pro_products
	    On cmn_bpt_ctm_catalogproductextensionrequest_products.CMN_PRO_Product_RefID = cmn_pro_products.CMN_PRO_ProductID 
		And cmn_bpt_ctm_catalogproductextensionrequest_products.IsDeleted = 0
	    And cmn_bpt_ctm_catalogproductextensionrequest_products.Tenant_RefID = @TenantID
	  Left Outer Join
	  cmn_pro_catalog_revisions
	    On cmn_bpt_ctm_catalogproductextensionrequests.RequestedFor_Catalog_RefID =
	    cmn_pro_catalog_revisions.CMN_PRO_Catalog_RefID And
	    cmn_pro_catalog_revisions.IsDeleted = 0 And
	    cmn_pro_catalog_revisions.Tenant_RefID = @TenantID And
	    cmn_pro_catalog_revisions.RevisionNumber = 
	      (
	        Select Max(cmn_pro_catalog_revisions.RevisionNumber)
	        From cmn_pro_catalog_revisions
	        Where cmn_pro_catalog_revisions.CMN_PRO_Catalog_RefID = cmn_bpt_ctm_catalogproductextensionrequests.RequestedFor_Catalog_RefID 
	      )
	    Left Outer Join
	  cmn_sls_prices On cmn_pro_catalog_revisions.Default_PricelistRelease_RefID =
	    cmn_sls_prices.PricelistRelease_RefID And
	    cmn_sls_prices.CMN_PRO_Product_RefID =
	    cmn_bpt_ctm_catalogproductextensionrequest_products.CMN_PRO_Product_RefID
	    And cmn_sls_prices.IsDeleted = 0 And cmn_sls_prices.Tenant_RefID = @TenantID
	Where
	  cmn_bpt_ctm_catalogproductextensionrequest_products.IsDeleted = 0 And
	  cmn_bpt_ctm_catalogproductextensionrequest_products.CatalogProductExtensionRequest_RefID = @RequestID And
	  cmn_bpt_ctm_catalogproductextensionrequest_products.Tenant_RefID = @TenantID

  
  