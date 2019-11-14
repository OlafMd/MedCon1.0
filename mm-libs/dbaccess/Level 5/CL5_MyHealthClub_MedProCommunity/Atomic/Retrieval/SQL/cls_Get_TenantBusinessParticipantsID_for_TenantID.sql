
	Select
	  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
	From
	  cmn_bpt_businessparticipants
	Where
	  cmn_bpt_businessparticipants.IsTenant = 1 And
	  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
	  cmn_bpt_businessparticipants.IsDeleted = 0 And
	  cmn_bpt_businessparticipants.IfTenant_Tenant_RefID = @TenantID
  