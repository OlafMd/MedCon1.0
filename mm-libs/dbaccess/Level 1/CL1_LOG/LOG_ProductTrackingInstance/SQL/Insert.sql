INSERT INTO 
	log_producttrackinginstances
	(
		LOG_ProductTrackingInstanceID,
		TrackingInstanceTakenFromSourceTrackingInstance_RefID,
		TrackingCode,
		SerialNumber,
		BatchNumber,
		OwnedBy_BusinessParticipant_RefID,
		CMN_PRO_Product_RefID,
		CMN_PRO_Product_Variant_RefID,
		CMN_PRO_Product_Release_RefID,
		ExpirationDate,
		IsDeleted,
		Tenant_RefID,
		InitialQuantityOnTrackingInstance,
		CurrentQuantityOnTrackingInstance,
		R_ReservedQuantity,
		R_FreeQuantity,
		Creation_Timestamp
	)
VALUES 
	(
		@LOG_ProductTrackingInstanceID,
		@TrackingInstanceTakenFromSourceTrackingInstance_RefID,
		@TrackingCode,
		@SerialNumber,
		@BatchNumber,
		@OwnedBy_BusinessParticipant_RefID,
		@CMN_PRO_Product_RefID,
		@CMN_PRO_Product_Variant_RefID,
		@CMN_PRO_Product_Release_RefID,
		@ExpirationDate,
		@IsDeleted,
		@Tenant_RefID,
		@InitialQuantityOnTrackingInstance,
		@CurrentQuantityOnTrackingInstance,
		@R_ReservedQuantity,
		@R_FreeQuantity,
		@Creation_Timestamp
	)