
	  Select
      usr_groups.USR_GroupID,
      usr_groups.Group_Name_DictID,
      usr_groups.Group_Description_DictID
    From
      usr_groups
    Where
      usr_groups.IsDeleted = 0 And
      usr_groups.Tenant_RefID = @TenantID
  