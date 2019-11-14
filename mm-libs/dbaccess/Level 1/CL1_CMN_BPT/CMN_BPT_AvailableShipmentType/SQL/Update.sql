UPDATE 
	cmn_bpt_availableshipmenttypes
SET 
	CMN_BPT_BusinessParticipant_RefID=@CMN_BPT_BusinessParticipant_RefID,
	LOG_SHP_Shipment_Type_RefID=@LOG_SHP_Shipment_Type_RefID,
	IsPrimaryShipmentType=@IsPrimaryShipmentType,
	SequenceNumber=@SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_BPT_AvailableShipmentTypeID = @CMN_BPT_AvailableShipmentTypeID