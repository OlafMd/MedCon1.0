UPDATE 
	cmn_cal_apr_responsiblepersons
SET 
	NumberOfResponsiblePersonsRequiredToApprove=@NumberOfResponsiblePersonsRequiredToApprove,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_APR_ResponsiblePersonID = @CMN_CAL_APR_ResponsiblePersonID