INSERT INTO 
	res_realestateproperty_landregistrationentries
	(
		RES_RealestateProperty_LandRegistrationEntryID,
		RealestateProperty_RefID,
		LandRegistrationEntry_LandTitleRegister,
		LandRegistrationEntry_Marking,
		LandRegistrationEntry_LandLot,
		LandRegistrationEntry_Parcel_FromNumber,
		LandRegistrationEntry_Parcel_ToNumber,
		LandRegistrationEntry_Sheet,
		LandRegistrationEntry_GroundAreaSize_in_sqm,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_RealestateProperty_LandRegistrationEntryID,
		@RealestateProperty_RefID,
		@LandRegistrationEntry_LandTitleRegister,
		@LandRegistrationEntry_Marking,
		@LandRegistrationEntry_LandLot,
		@LandRegistrationEntry_Parcel_FromNumber,
		@LandRegistrationEntry_Parcel_ToNumber,
		@LandRegistrationEntry_Sheet,
		@LandRegistrationEntry_GroundAreaSize_in_sqm,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)