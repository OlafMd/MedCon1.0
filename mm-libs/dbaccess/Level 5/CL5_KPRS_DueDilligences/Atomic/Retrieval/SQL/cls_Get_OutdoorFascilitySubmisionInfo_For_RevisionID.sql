
Select
  res_str_outdoorfacilities.RES_STR_OutdoorFacilityID,
  res_str_outdoorfacilities.DocumentHeader_RefID As
  OutdoorF_DocumentHeader_RefID,
  res_str_outdoorfacilities.Comment As OutdoorF_Comment,
  res_str_outdoorfacilities.AverageRating_RefID,
  res_str_outdoorfacilities.RES_BLD_OutdoorFacility_RefID,
  res_bld_outdoorfacilities.NumberOfGaragePlaces,
  res_bld_outdoorfacilities.NumberOfRentedGaragePlaces,
  res_bld_outdoorfacilities.TypeOfAccessRoad_RefID,
  res_bld_outdoorfacilities.TypeOfFence_RefID,
  Assessments.RES_STR_OutdoorFacility_PropertyID,
  Assessments.RES_STR_OutdoorFacility_PropertyAssessmentID,
  Assessments.RES_STR_OutdoorFacility_RequiredActionID,
  Assessments.GlobalPropertyMatchingID,
  Assessments.STR_OutdoorFacility_RefID,
  Assessments.Rating_RefID,
  Assessments.DocumentHeader_RefID,
  Assessments.PropertyAssessment_Comment,
  Assessments.OutdoorFacilityPropertyAssestment_RefID,
  Assessments.EffectivePrice_RefID,
  Assessments.Action_PricePerUnit_RefID,
  Assessments.Action_Unit_RefID,
  Assessments.Action_UnitAmount,
  Assessments.IsCustom,
  Assessments.IfCustom_Name,
  Assessments.IfCustom_Description,
  Assessments.Action_Timeframe_RefID,
  Assessments.RequiredAction_Comment,
  Assessments.Action_Name_DictID,
  Assessments.SelectedActionVersion_RefID,
  Assessments.PriceValue_Amount
From
  res_str_outdoorfacilities Inner Join
  res_bld_outdoorfacilities
    On res_str_outdoorfacilities.RES_BLD_OutdoorFacility_RefID =
    res_bld_outdoorfacilities.RES_BLD_OutdoorFacilityID Left Join
  (Select
    res_str_outdoorfacility_properties.RES_STR_OutdoorFacility_PropertyID,
    res_str_outdoorfacility_properties.GlobalPropertyMatchingID,
    res_str_outdoorfacility_propertyassessments.RES_STR_OutdoorFacility_PropertyAssessmentID,
    res_str_outdoorfacility_propertyassessments.STR_OutdoorFacility_RefID,
    res_str_outdoorfacility_propertyassessments.Rating_RefID,
    res_str_outdoorfacility_propertyassessments.DocumentHeader_RefID,
    res_str_outdoorfacility_propertyassessments.Comment As
    PropertyAssessment_Comment,
    RequieredActions.RES_STR_OutdoorFacility_RequiredActionID,
    RequieredActions.OutdoorFacilityPropertyAssestment_RefID,
    RequieredActions.EffectivePrice_RefID,
    RequieredActions.Action_PricePerUnit_RefID,
    RequieredActions.Action_Unit_RefID,
    RequieredActions.Action_UnitAmount,
    RequieredActions.IsCustom,
    RequieredActions.IfCustom_Name,
    RequieredActions.IfCustom_Description,
    RequieredActions.Action_Timeframe_RefID,
    RequieredActions.RequiredAction_Comment,
    RequieredActions.Action_Name_DictID,
    RequieredActions.SelectedActionVersion_RefID,
    RequieredActions.PriceValue_Amount
  From
    res_str_outdoorfacility_properties Inner Join
    res_str_outdoorfacility_propertyassessments
      On
      res_str_outdoorfacility_propertyassessments.OutdoorFacilityProperty_RefID
      = res_str_outdoorfacility_properties.RES_STR_OutdoorFacility_PropertyID
    Left Join
    (Select
      res_str_outdoorfacility_requiredactions.RES_STR_OutdoorFacility_RequiredActionID,
      res_str_outdoorfacility_requiredactions.OutdoorFacilityPropertyAssestment_RefID,
      res_str_outdoorfacility_requiredactions.EffectivePrice_RefID,
      res_str_outdoorfacility_requiredactions.Action_PricePerUnit_RefID,
      res_str_outdoorfacility_requiredactions.Action_Unit_RefID,
      res_str_outdoorfacility_requiredactions.Action_UnitAmount,
      res_str_outdoorfacility_requiredactions.IsCustom,
      res_str_outdoorfacility_requiredactions.IfCustom_Name,
      res_str_outdoorfacility_requiredactions.IfCustom_Description,
      res_str_outdoorfacility_requiredactions.Action_Timeframe_RefID,
      res_str_outdoorfacility_requiredactions.Comment As RequiredAction_Comment,
      res_act_action_version.Action_Name_DictID,
      res_str_outdoorfacility_requiredactions.IsDeleted,
      res_act_action_version.IsDeleted As IsDeleted1,
      res_str_outdoorfacility_requiredactions.Tenant_RefID,
      res_act_action_version.Tenant_RefID As Tenant_RefID1,
      res_str_outdoorfacility_requiredactions.SelectedActionVersion_RefID,
      cmn_price_values.PriceValue_Amount,
      cmn_price_values.IsDeleted As IsDeleted2
    From
      res_str_outdoorfacility_requiredactions Inner Join
      res_act_action_version On res_act_action_version.RES_ACT_Action_VersionID
        = res_str_outdoorfacility_requiredactions.SelectedActionVersion_RefID
      Inner Join
      cmn_price_values On cmn_price_values.Price_RefID =
        res_str_outdoorfacility_requiredactions.Action_PricePerUnit_RefID
    Where
      res_str_outdoorfacility_requiredactions.IsDeleted = 0 And
      res_act_action_version.IsDeleted = 0 And
      res_str_outdoorfacility_requiredactions.Tenant_RefID = @TenantID And
      res_act_action_version.Tenant_RefID = @TenantID And
      cmn_price_values.IsDeleted = 0) RequieredActions
      On RequieredActions.OutdoorFacilityPropertyAssestment_RefID =
      res_str_outdoorfacility_propertyassessments.RES_STR_OutdoorFacility_PropertyAssessmentID
  Where
    res_str_outdoorfacility_propertyassessments.IsDeleted = 0 And
    res_str_outdoorfacility_properties.IsDeleted = 0 And
    res_str_outdoorfacility_propertyassessments.Tenant_RefID = @TenantID)
  Assessments On Assessments.STR_OutdoorFacility_RefID =
    res_str_outdoorfacilities.RES_STR_OutdoorFacilityID
Where
  res_str_outdoorfacilities.IsDeleted = 0 And
  res_str_outdoorfacilities.RES_BLD_OutdoorFacility_RefID = @BuildingPartID And
  res_str_outdoorfacilities.Tenant_RefID = @TenantID And
  res_str_outdoorfacilities.DUD_Revision_RefID = @RevisionID
  