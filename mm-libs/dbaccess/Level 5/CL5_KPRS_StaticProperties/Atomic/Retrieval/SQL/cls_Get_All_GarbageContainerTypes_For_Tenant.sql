
	Select
	  res_bld_garbagecontainertypes.GarbageContainerType_Name_DictID,
	  res_bld_garbagecontainertypes.RES_BLD_GarbageContainerTypeID
	From
	  res_bld_garbagecontainertypes
	Where
	  res_bld_garbagecontainertypes.Tenant_RefID = @TenantID And
	  res_bld_garbagecontainertypes.IsDeleted = 0
	Group By
	  res_bld_garbagecontainertypes.GarbageContainerType_Name_DictID,
	  res_bld_garbagecontainertypes.RES_BLD_GarbageContainerTypeID
  