
    Select
      hec_bil_potentialcodes.HEC_BIL_PotentialCodeID as gpos_id,
      hec_bil_potentialcodes_de.Content as gpos_name
    From
      hec_bil_potentialcodes Inner Join
      hec_bil_potentialcodes_de
        On hec_bil_potentialcodes.CodeName_DictID = hec_bil_potentialcodes_de.DictID And
        hec_bil_potentialcodes_de.Language_RefID = @LanguageID And
        hec_bil_potentialcodes_de.IsDeleted = 0
    Where
	    hec_bil_potentialcodes.Tenant_RefID = @TenantID And
	    hec_bil_potentialcodes.IsDeleted = 0
	