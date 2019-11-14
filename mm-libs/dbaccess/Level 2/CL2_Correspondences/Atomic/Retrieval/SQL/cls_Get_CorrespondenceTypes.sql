
	Select
	  cmn_per_personinfo_correspondencetypes.CMN_PER_PersonInfo_CorrespondenceTypeID,
	  cmn_per_personinfo_correspondencetypes.GlobalPropertyMatchingID,
	  cmn_per_personinfo_correspondencetypes.DisplayName
	From
	  cmn_per_personinfo_correspondencetypes
	Where
	  cmn_per_personinfo_correspondencetypes.Tenant_RefID = @TenantID And
	  cmn_per_personinfo_correspondencetypes.IsDeleted = 0
  