
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
  cmn_bpt_ctm_catalogproductextensionrequests.CMN_BPT_CTM_CatalogProductExtensionRequestID
From
  cmn_bpt_ctm_catalogproductextensionrequest_products Right Join
  cmn_bpt_ctm_catalogproductextensionrequests
    On
    cmn_bpt_ctm_catalogproductextensionrequest_products.CatalogProductExtensionRequest_RefID = cmn_bpt_ctm_catalogproductextensionrequests.CMN_BPT_CTM_CatalogProductExtensionRequestID And (cmn_bpt_ctm_catalogproductextensionrequests.IsDeleted = 0 And cmn_bpt_ctm_catalogproductextensionrequests.Tenant_RefID = @TenantID) Left Join
  cmn_pro_products
    On cmn_bpt_ctm_catalogproductextensionrequest_products.CMN_PRO_Product_RefID
    = cmn_pro_products.CMN_PRO_ProductID And
    cmn_bpt_ctm_catalogproductextensionrequest_products.IsDeleted = 0 And
    cmn_bpt_ctm_catalogproductextensionrequest_products.Tenant_RefID = @TenantID
Where
  (cmn_bpt_ctm_catalogproductextensionrequest_products.IsDeleted = 0 Or
    cmn_bpt_ctm_catalogproductextensionrequest_products.IsDeleted Is Null) And
  cmn_bpt_ctm_catalogproductextensionrequests.CMN_BPT_CTM_CatalogProductExtensionRequestID = @RequestID And
  cmn_bpt_ctm_catalogproductextensionrequests.Tenant_RefID = @TenantID And
  (cmn_pro_products.IsDeleted = 0 Or
    cmn_pro_products.IsDeleted Is Null) And
  (cmn_bpt_ctm_catalogproductextensionrequests.IsDeleted = 0 Or
    cmn_bpt_ctm_catalogproductextensionrequests.IsDeleted Is Null)
  