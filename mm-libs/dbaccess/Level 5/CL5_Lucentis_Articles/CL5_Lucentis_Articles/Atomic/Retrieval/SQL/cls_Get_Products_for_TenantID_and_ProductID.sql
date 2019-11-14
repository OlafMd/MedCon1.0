
Select
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  cmn_pro_products.Creation_Timestamp,
  cmn_pro_products.Product_Description_DictID,
  cmn_pro_products.CMN_PRO_ProductID,
  hec_products.Recepie As ArticleRecipe,
  cmn_pro_products.Tenant_RefID,
  hec_products.HEC_ProductID,
  Quest.CMN_PRO_Product_Questionnaire_AssignmentID
From
  cmn_pro_products Left Join
  hec_products On cmn_pro_products.CMN_PRO_ProductID =
    hec_products.Ext_PRO_Product_RefID And hec_products.IsDeleted = 0 Left Join
  (Select
    cmn_pro_product_questionnaire_assignment.CMN_PRO_Product_Questionnaire_AssignmentID,
    cmn_pro_product_questionnaire_assignment.CMN_PRO_Product_RefID
  From
    cmn_pro_product_questionnaire_assignment
  Where
    cmn_pro_product_questionnaire_assignment.IsActive = 1) Quest
    On cmn_pro_products.CMN_PRO_ProductID = Quest.CMN_PRO_Product_RefID
Where
  cmn_pro_products.CMN_PRO_ProductID = @ProductID And
  cmn_pro_products.Tenant_RefID = @TenantID And
  cmn_pro_products.IsDeleted = 0
  