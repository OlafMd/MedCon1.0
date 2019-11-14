
	Select
	  res_realestateproperty_landregistrationentries.RES_RealestateProperty_LandRegistrationEntryID,
	  res_realestateproperty_landregistrationentries.LandRegistrationEntry_LandTitleRegister,
	  res_realestateproperty_landregistrationentries.LandRegistrationEntry_Marking,
	  res_realestateproperty_landregistrationentries.LandRegistrationEntry_LandLot,
	  res_realestateproperty_landregistrationentries.LandRegistrationEntry_Parcel_FromNumber,
	  res_realestateproperty_landregistrationentries.LandRegistrationEntry_Parcel_ToNumber,
	  res_realestateproperty_landregistrationentries.LandRegistrationEntry_Sheet,
	  res_realestateproperty_landregistrationentries.LandRegistrationEntry_GroundAreaSize_in_sqm,
	  res_realestateproperty_landregistrationentries.RealestateProperty_RefID
	From
	  res_realestateproperty_landregistrationentries
	Where
	  res_realestateproperty_landregistrationentries.RealestateProperty_RefID =
	  @RealestatePropertyID And
	  res_realestateproperty_landregistrationentries.Tenant_RefID = @TenantID And
	  res_realestateproperty_landregistrationentries.IsDeleted = 0
  