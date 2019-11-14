
Select
  res_str_basements.RES_STR_BasementID,
  res_str_basements.RES_BLD_Basement_RefID,
  res_bld_basements.TypeOfFloor_RefID,
  res_str_basements.DocumentHeader_RefID As Basement_DocumentHeader_RefID,
  res_str_basements.AverageRating_RefID,
  res_str_basements.Comment As Basement_Comment,
  Assessments.RES_STR_Basement_PropertyID,
  Assessments.RES_STR_Basement_PropertyAssessmentID,
  Assessments.RES_STR_Basement_RequiredActionID,
  Assessments.GlobalPropertyMatchingID,
  Assessments.STR_Basement_RefID,
  Assessments.BasementProperty_RefID,
  Assessments.Rating_RefID,
  Assessments.DocumentHeader_RefID,
  Assessments.PropertyAssessment_Comment,
  Assessments.Tenant_RefID,
  Assessments.Action_Name_DictID,
  Assessments.BasementPropertyAssestment_RefID,
  Assessments.EffectivePrice_RefID,
  Assessments.Action_PricePerUnit_RefID,
  Assessments.Action_UnitAmount,
  Assessments.Action_Unit_RefID,
  Assessments.IsCustom,
  Assessments.IfCustom_Name,
  Assessments.IfCustom_Description,
  Assessments.Action_Timeframe_RefID,
  Assessments.RequiredAction_Comment,
  Assessments.SelectedActionVersion_RefID,
  Assessments.PriceValue_Amount
From
  res_str_basements Left Join
  (Select
    res_str_basement_properties.RES_STR_Basement_PropertyID,
    res_str_basement_properties.GlobalPropertyMatchingID,
    res_str_basement_propertyassessments.RES_STR_Basement_PropertyAssessmentID,
    res_str_basement_propertyassessments.STR_Basement_RefID,
    res_str_basement_propertyassessments.Rating_RefID,
    res_str_basement_propertyassessments.BasementProperty_RefID,
    res_str_basement_propertyassessments.DocumentHeader_RefID,
    res_str_basement_propertyassessments.Comment As PropertyAssessment_Comment,
    res_str_basement_propertyassessments.IsDeleted,
    res_str_basement_properties.IsDeleted As IsDeleted1,
    res_str_basement_properties.Tenant_RefID,
    RequieredActions.RES_STR_Basement_RequiredActionID,
    RequieredActions.Action_Name_DictID,
    RequieredActions.BasementPropertyAssestment_RefID,
    RequieredActions.EffectivePrice_RefID,
    RequieredActions.Action_PricePerUnit_RefID,
    RequieredActions.Action_UnitAmount,
    RequieredActions.Action_Unit_RefID,
    RequieredActions.IsCustom,
    RequieredActions.IfCustom_Name,
    RequieredActions.IfCustom_Description,
    RequieredActions.Action_Timeframe_RefID,
    RequieredActions.RequiredAction_Comment,
    RequieredActions.SelectedActionVersion_RefID,
    RequieredActions.PriceValue_Amount
  From
    res_str_basement_properties Inner Join
    res_str_basement_propertyassessments
      On res_str_basement_propertyassessments.BasementProperty_RefID =
      res_str_basement_properties.RES_STR_Basement_PropertyID Left Join
    (Select
      res_act_action_version.Action_Name_DictID,
      res_str_basement_requiredactions.RES_STR_Basement_RequiredActionID,
      res_str_basement_requiredactions.BasementPropertyAssestment_RefID,
      res_str_basement_requiredactions.EffectivePrice_RefID,
      res_str_basement_requiredactions.Action_PricePerUnit_RefID,
      res_str_basement_requiredactions.Action_UnitAmount,
      res_str_basement_requiredactions.Action_Unit_RefID,
      res_str_basement_requiredactions.IsCustom,
      res_str_basement_requiredactions.IfCustom_Name,
      res_str_basement_requiredactions.IfCustom_Description,
      res_str_basement_requiredactions.Creation_Timestamp,
      res_str_basement_requiredactions.Action_Timeframe_RefID,
      res_str_basement_requiredactions.Comment As RequiredAction_Comment,
      res_act_action_version.Tenant_RefID,
      res_str_basement_requiredactions.Tenant_RefID As Tenant_RefID1,
      res_str_basement_requiredactions.IsDeleted,
      res_act_action_version.IsDeleted As IsDeleted1,
      res_str_basement_requiredactions.SelectedActionVersion_RefID,
      cmn_price_values.PriceValue_Amount,
      cmn_price_values.IsDeleted As IsDeleted2
    From
      res_act_action_version Inner Join
      res_str_basement_requiredactions
        On res_str_basement_requiredactions.SelectedActionVersion_RefID =
        res_act_action_version.RES_ACT_Action_VersionID Inner Join
      cmn_price_values On cmn_price_values.Price_RefID =
        res_str_basement_requiredactions.Action_PricePerUnit_RefID
    Where
      cmn_price_values.IsDeleted = 0) RequieredActions
      On RequieredActions.BasementPropertyAssestment_RefID =
      res_str_basement_propertyassessments.RES_STR_Basement_PropertyAssessmentID
  Where
    res_str_basement_propertyassessments.IsDeleted = 0 And
    res_str_basement_properties.IsDeleted = 0 And
    res_str_basement_properties.Tenant_RefID = @TenantID) Assessments
    On Assessments.STR_Basement_RefID = res_str_basements.RES_STR_BasementID
  Inner Join
  res_bld_basements On res_bld_basements.RES_BLD_BasementID =
    res_str_basements.RES_BLD_Basement_RefID
Where
  res_str_basements.IsDeleted = 0 And
  res_str_basements.Tenant_RefID = @TenantID And
  res_str_basements.DUD_Revision_RefID = @RevisionID
  