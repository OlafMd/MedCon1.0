
	Select
	  res_bld_building_types.BuildingType_Name_DictID,
	  res_bld_building_types.RES_BLD_Building_TypeID
	From
	  res_bld_building_types
	Where
	  res_bld_building_types.Tenant_RefID = @TenantID And
	  res_bld_building_types.IsDeleted = 0
	Group By
	  res_bld_building_types.BuildingType_Name_DictID,
	  res_bld_building_types.RES_BLD_Building_TypeID
  