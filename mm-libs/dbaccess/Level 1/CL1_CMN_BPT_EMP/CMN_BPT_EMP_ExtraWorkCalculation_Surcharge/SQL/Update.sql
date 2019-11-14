UPDATE 
	cmn_bpt_emp_extraworkcalculation_surcharges
SET 
	IsNightTimeSurcharge=@IsNightTimeSurcharge,
	IsSpecialEventSurcharge=@IsSpecialEventSurcharge,
	Surcharge_Name_DictID=@Surcharge_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_EMP_ExtraWorkCalculation_SurchargeID = @CMN_BPT_EMP_ExtraWorkCalculation_SurchargeID