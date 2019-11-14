
	Select
	  cmn_pro_products.Product_Name_DictID,
	  hec_products.HEC_ProductID,
	  hec_product_dosageforms.DosageForm_Name_DictID,
	  hec_sub_substance_names.SubstanceName_Label_DictID,
	  hec_sub_substances.HEC_SUB_SubstanceID,
	  cmn_bpt_businessparticipants.DisplayName As Manufacturer,
	  cmn_pro_pac_packageinfo.PackageContent_Amount As Strength_Name,
	  cmn_units.ISOCode As Strength_Units,
	  cmn_pro_pac_packageinfo.PackageContent_DisplayLabel
	From
	  cmn_pro_products Inner Join
	  hec_products On hec_products.Ext_PRO_Product_RefID =
	    cmn_pro_products.CMN_PRO_ProductID And hec_products.IsDeleted = 0 And
	    hec_products.Tenant_RefID = @TenantID Inner Join
	  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
	    hec_product_dosageforms.HEC_Product_DosageFormID And
	    hec_product_dosageforms.IsDeleted = 0 And
	    hec_product_dosageforms.Tenant_RefID = @TenantID Inner Join
	  hec_pro_product_components On hec_pro_product_components.HEC_PRO_Product_RefID
	    = hec_products.HEC_ProductID And hec_pro_product_components.Tenant_RefID =
	    @TenantID And hec_pro_product_components.IsDeleted = 0 Inner Join
	  hec_pro_components On hec_pro_product_components.HEC_PRO_Component_RefID =
	    hec_pro_components.HEC_PRO_ComponentID And hec_pro_components.Tenant_RefID =
	    @TenantID And hec_pro_components.IsDeleted = 0 Inner Join
	  hec_pro_component_substanceingredients
	    On hec_pro_component_substanceingredients.Component_RefID =
	    hec_pro_components.HEC_PRO_ComponentID And
	    hec_pro_component_substanceingredients.Tenant_RefID = @TenantID And
	    hec_pro_component_substanceingredients.IsDeleted = 0 Inner Join
	  hec_sub_substances On hec_pro_component_substanceingredients.Substance_RefID =
	    hec_sub_substances.HEC_SUB_SubstanceID And hec_sub_substances.Tenant_RefID =
	    @TenantID And hec_sub_substances.IsDeleted = 0 Inner Join
	  hec_sub_substance_names On hec_sub_substance_names.HEC_SUB_Substance_RefID =
	    hec_sub_substances.HEC_SUB_SubstanceID And
	    hec_sub_substance_names.Tenant_RefID = @TenantID And
	    hec_sub_substance_names.IsDeleted = 0 Inner Join
	  cmn_bpt_businessparticipants
	    On cmn_pro_products.ProducingBusinessParticipant_RefID =
	    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants.IsCompany = 1 And
	    cmn_bpt_businessparticipants.IsDeleted = 0 And
	    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
	  cmn_pro_pac_packageinfo On cmn_pro_products.PackageInfo_RefID =
	    cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID And
	    cmn_pro_pac_packageinfo.IsDeleted = 0 And
	    cmn_pro_pac_packageinfo.Tenant_RefID = @TenantID Inner Join
	  cmn_units
	    On cmn_units.CMN_UnitID =
	    cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID And
	    cmn_units.IsDeleted = 0 And cmn_units.Tenant_RefID = @TenantID
	Where
	  cmn_pro_products.Tenant_RefID = @TenantID And
	  cmn_pro_products.IsDeleted = 0
  