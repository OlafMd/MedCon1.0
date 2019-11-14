UPDATE 
	cmn_bpt_salesrepresentatives
SET 
	IfEmployee_Employee_RefID=@IfEmployee_Employee_RefID,
	IsEmployee=@IsEmployee,
	Ext_BusinessParticipant_RefID=@Ext_BusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_SalesRepresentativeID = @CMN_BPT_SalesRepresentativeID