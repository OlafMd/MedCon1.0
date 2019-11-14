
	Select
	  hec_medicalpractises.HEC_MedicalPractiseID,
	  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Name_DictID
	From
	  hec_medicalpractises Inner Join
	  cmn_bpt_ctm_organizationalunits
	    On
	    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
	    = hec_medicalpractises.HEC_MedicalPractiseID And
	    cmn_bpt_ctm_organizationalunits.IsDeleted = 0 And
	    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID
	Where
	  hec_medicalpractises.Tenant_RefID = @TenantID And
	  hec_medicalpractises.IsDeleted = 0
  