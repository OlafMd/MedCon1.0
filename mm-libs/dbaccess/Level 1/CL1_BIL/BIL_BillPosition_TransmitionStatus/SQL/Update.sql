UPDATE 
	bil_billposition_transmitionstatuses
SET 
	BillPosition_RefID=@BillPosition_RefID,
	TransmitionStatusKey=@TransmitionStatusKey,
	TransmitionCode=@TransmitionCode,
	PrimaryComment=@PrimaryComment,
	SecondaryComment=@SecondaryComment,
	TransmittedOnDate=@TransmittedOnDate,
	IsActive=@IsActive,
	TransmissionDataXML=@TransmissionDataXML,
	IsTransmitionStatusManuallySet=@IsTransmitionStatusManuallySet,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	BIL_BillPosition_TransmitionStatusID = @BIL_BillPosition_TransmitionStatusID