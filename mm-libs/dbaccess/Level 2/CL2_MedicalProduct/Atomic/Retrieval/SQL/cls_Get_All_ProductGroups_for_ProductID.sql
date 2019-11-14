
    Select
      cmn_pro_product_2_productgroup.CMN_PRO_Product_RefID,
      cmn_pro_productgroups.GlobalPropertyMatchingID,
      cmn_pro_productgroups.CMN_PRO_ProductGroupID,
      cmn_pro_productgroups.ProductGroup_Name_DictID,
      cmn_pro_productgroups.ProductGroup_Description_DictID,
      cmn_pro_productgroups.Parent_RefID
    From
      cmn_pro_product_2_productgroup Inner Join
      cmn_pro_productgroups On cmn_pro_productgroups.CMN_PRO_ProductGroupID =
        cmn_pro_product_2_productgroup.CMN_PRO_ProductGroup_RefID
    Where
      cmn_pro_product_2_productgroup.CMN_PRO_Product_RefID = @ProductID And
      cmn_pro_product_2_productgroup.IsDeleted = 0 And
      cmn_pro_productgroups.IsDeleted = 0 And
      cmn_pro_productgroups.Tenant_RefID = @TenantID
  