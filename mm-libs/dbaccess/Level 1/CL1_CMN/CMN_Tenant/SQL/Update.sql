UPDATE 
	cmn_tenants
SET 
	TenantITL=@TenantITL,
	UniversalContactDetail_RefID=@UniversalContactDetail_RefID,
	CMN_CAL_CalendarInstance_RefID=@CMN_CAL_CalendarInstance_RefID,
	IsUsing_Offices=@IsUsing_Offices,
	IsUsing_WorkAreas=@IsUsing_WorkAreas,
	IsUsing_Workplaces=@IsUsing_Workplaces,
	IsUsing_CostCenters=@IsUsing_CostCenters,
	CMN_BPT_STA_SettingProfile_RefID=@CMN_BPT_STA_SettingProfile_RefID,
	DocumentServerRootURL=@DocumentServerRootURL,
	Customers_DefaultPricelist_RefID=@Customers_DefaultPricelist_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_TenantID = @CMN_TenantID