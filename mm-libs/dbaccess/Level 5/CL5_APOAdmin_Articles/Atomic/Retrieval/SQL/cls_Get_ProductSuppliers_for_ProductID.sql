
   Select
  cmn_pro_product_suppliers.SupplierPriority,
  cmn_pro_product_suppliers.MinimalPackageOrderingAmount,
  cmn_pro_product_suppliers.BatchOrderSize,
  cmn_bpt_businessparticipants.DisplayName,
  cmn_bpt_businessparticipants.Tenant_RefID,
  cmn_pro_product_suppliers.CMN_PRO_Product_RefID,
  cmn_pro_product_suppliers.RecommendedRetailPrice_RefID,
  cmn_bpt_supplier_types.SupplierType_Name_DictID,
  cmn_bpt_supplier_types.GlobalPropertyMatchingID,
  cmn_pro_product_suppliers.CMN_BPT_Supplier_RefID,
  cmn_pro_product_suppliers.CMN_PRO_Product_SupplierID,
  cmn_pro_product_supplier_discountvalues.ORD_PRC_DiscountType_RefID,
  cmn_pro_product_supplier_discountvalues.DiscountValue,
  cmn_pro_product_suppliers.ProcurementPrice_RefID,
  cmn_price_values.PriceValue_Amount
From
  cmn_pro_product_suppliers Inner Join
  cmn_bpt_suppliers On cmn_bpt_suppliers.CMN_BPT_SupplierID =
    cmn_pro_product_suppliers.CMN_BPT_Supplier_RefID And
    cmn_bpt_suppliers.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_suppliers.Ext_BusinessParticipant_RefID And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_supplier_types On cmn_bpt_suppliers.SupplierType_RefID =
    cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID And
    cmn_bpt_suppliers.Tenant_RefID = @TenantID Left Join
  cmn_pro_product_supplier_discountvalues
    On cmn_pro_product_supplier_discountvalues.Product_Supplier_RefID =
    cmn_pro_product_suppliers.CMN_PRO_Product_SupplierID And
    cmn_pro_product_supplier_discountvalues.Tenant_RefID = @TenantID Left Join
  cmn_price_values On cmn_pro_product_suppliers.ProcurementPrice_RefID =
    cmn_price_values.Price_RefID
Where
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
  cmn_pro_product_suppliers.CMN_PRO_Product_RefID = @ProductID And
  cmn_pro_product_suppliers.IsDeleted = 0
  