
Select
  res_str_apartments.DocumentHeader_RefID As Apartment_DocumentHeader_RefID,
  res_str_apartments.RES_STR_ApartmentID,
  res_str_apartments.AverageRating_RefID,
  res_str_apartments.Comment As Apartment_Comment,
  res_str_apartments.RES_BLD_Apartment_RefID,
  res_bld_apartments.IsAppartment_ForRent,
  res_bld_apartments.ApartmentSize_Unit_RefID,
  res_bld_apartments.ApartmentSize_Value,
  res_bld_apartments.TypeOfHeating_RefID,
  res_bld_apartments.TypeOfFlooring_RefID,
  res_bld_apartments.TypeOfWallCovering_RefID,
  Assessments.RES_STR_Apartment_PropertyAssessmentID,
  Assessments.RES_STR_Apartment_RequiredActionID,
  Assessments.Rating_RefID,
  Assessments.DocumentHeader_RefID,
  Assessments.STR_Apartment_RefID,
  Assessments.GlobalPropertyMatchingID,
  Assessments.ApartmentPropertyAssessment_RefID,
  Assessments.EffectivePrice_RefID,
  Assessments.SelectedActionVersion_RefID,
  Assessments.Action_Unit_RefID,
  Assessments.Action_PricePerUnit_RefID,
  Assessments.Action_UnitAmount,
  Assessments.IsCustom,
  Assessments.IfCustom_Name,
  Assessments.IfCustom_Description,
  Assessments.Action_Timeframe_RefID,
  Assessments.Action_Name_DictID,
  Assessments.RequiredAction_Comment,
  Assessments.RES_STR_Apartment_PropertyID,
  Assessments.PropertyAssessment_Comment,
  Assessments.PriceValue_Amount
From
  res_str_apartments Inner Join
  res_bld_apartments On res_bld_apartments.RES_BLD_ApartmentID =
    res_str_apartments.RES_BLD_Apartment_RefID Left Join
  (Select
    res_str_apartment_propertyassessments.RES_STR_Apartment_PropertyAssessmentID,
    res_str_apartment_propertyassessments.Rating_RefID,
    res_str_apartment_propertyassessments.Comment As PropertyAssessment_Comment,
    res_str_apartment_propertyassessments.DocumentHeader_RefID,
    res_str_apartment_propertyassessments.STR_Apartment_RefID,
    res_str_apartment_properties.GlobalPropertyMatchingID,
    RequieredActions.RES_STR_Apartment_RequiredActionID,
    RequieredActions.ApartmentPropertyAssessment_RefID,
    RequieredActions.EffectivePrice_RefID,
    RequieredActions.SelectedActionVersion_RefID,
    RequieredActions.Action_Unit_RefID,
    RequieredActions.Action_PricePerUnit_RefID,
    RequieredActions.Action_UnitAmount,
    RequieredActions.IsCustom,
    RequieredActions.IfCustom_Name,
    RequieredActions.IfCustom_Description,
    RequieredActions.Action_Timeframe_RefID,
    RequieredActions.Action_Name_DictID,
    RequieredActions.RequiredAction_Comment,
    res_str_apartment_propertyassessments.IsDeleted,
    res_str_apartment_propertyassessments.Tenant_RefID,
    res_str_apartment_properties.RES_STR_Apartment_PropertyID,
    RequieredActions.PriceValue_Amount
  From
    res_str_apartment_propertyassessments Inner Join
    res_str_apartment_properties
      On res_str_apartment_propertyassessments.ApartmentProperty_RefID =
      res_str_apartment_properties.RES_STR_Apartment_PropertyID Left Join
    (Select
      res_str_apartment_requiredactions.RES_STR_Apartment_RequiredActionID,
      res_str_apartment_requiredactions.ApartmentPropertyAssessment_RefID,
      res_str_apartment_requiredactions.EffectivePrice_RefID,
      res_str_apartment_requiredactions.Comment As RequiredAction_Comment,
      res_str_apartment_requiredactions.SelectedActionVersion_RefID,
      res_str_apartment_requiredactions.Action_PricePerUnit_RefID,
      res_str_apartment_requiredactions.Action_UnitAmount,
      res_str_apartment_requiredactions.Action_Unit_RefID,
      res_str_apartment_requiredactions.IsCustom,
      res_str_apartment_requiredactions.IfCustom_Name,
      res_str_apartment_requiredactions.IfCustom_Description,
      res_str_apartment_requiredactions.Action_Timeframe_RefID,
      res_act_action_version.Action_Name_DictID,
      res_str_apartment_requiredactions.IsDeleted,
      res_act_action_version.IsDeleted As IsDeleted1,
      res_act_action_version.Tenant_RefID,
      cmn_price_values.PriceValue_Amount,
      cmn_price_values.IsDeleted As IsDeleted2
    From
      res_str_apartment_requiredactions Inner Join
      res_act_action_version
        On res_str_apartment_requiredactions.SelectedActionVersion_RefID =
        res_act_action_version.RES_ACT_Action_VersionID Inner Join
      cmn_price_values On cmn_price_values.Price_RefID =
        res_str_apartment_requiredactions.Action_PricePerUnit_RefID
    Where
      res_str_apartment_requiredactions.IsDeleted = 0 And
      res_act_action_version.IsDeleted = 0 And
      res_act_action_version.Tenant_RefID = @TenantID And
      cmn_price_values.IsDeleted = 0) RequieredActions
      On RequieredActions.ApartmentPropertyAssessment_RefID =
      res_str_apartment_propertyassessments.RES_STR_Apartment_PropertyAssessmentID
  Where
    res_str_apartment_propertyassessments.IsDeleted = 0 And
    res_str_apartment_propertyassessments.Tenant_RefID = @TenantID And
    res_str_apartment_properties.IsDeleted = 0) Assessments
    On Assessments.STR_Apartment_RefID = res_str_apartments.RES_STR_ApartmentID
Where
  res_str_apartments.IsDeleted = 0 And
  res_str_apartments.RES_BLD_Apartment_RefID = @BuildingPartID And
  res_str_apartments.Tenant_RefID = @TenantID And
  res_str_apartments.DUD_Revision_RefID = @RevisionID
  