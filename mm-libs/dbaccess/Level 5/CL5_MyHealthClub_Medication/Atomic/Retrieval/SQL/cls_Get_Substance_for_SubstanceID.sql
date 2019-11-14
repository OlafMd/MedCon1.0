
	Select
	  hec_sub_substance_names.SubstanceName_Label_DictID
	From
	  hec_sub_substances Inner Join
	  hec_sub_substance_names On hec_sub_substances.HEC_SUB_SubstanceID =
	    hec_sub_substance_names.HEC_SUB_Substance_RefID And
	  hec_sub_substance_names.Tenant_RefID = @TenantID And
	  hec_sub_substance_names.IsDeleted = 0
	Where
	  hec_sub_substances.Tenant_RefID = @TenantID And
	  hec_sub_substances.IsDeleted = 0 And
	  hec_sub_substances.HEC_SUB_SubstanceID = @SubstanceID
  