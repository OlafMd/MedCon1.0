
Select
  res_str_attics.RES_STR_AtticID,
  res_str_attics.DocumentHeader_RefID As Attic_DocumentHeader_RefID,
  res_str_attics.AverageRating_RefID,
  res_str_attics.Comment As Attic_Comment,
  res_str_attics.RES_BLD_Attic_RefID,
  Assessments.RES_STR_Attic_PropertyID,
  Assessments.RES_STR_Attic_PropertyAssessmentID,
  Assessments.RES_STR_Attic_RequiredActionID,
  Assessments.GlobalPropertyMatchingID,
  Assessments.Rating_RefID,
  Assessments.AtticProperty_RefID,
  Assessments.DocumentHeader_RefID,
  Assessments.PropertyAssessment_Comment,
  Assessments.Action_Name_DictID,
  Assessments.AtticPropertyAssestment_RefID,
  Assessments.SelectedActionVersion_RefID,
  Assessments.Action_PricePerUnit_RefID,
  Assessments.EffectivePrice_RefID,
  Assessments.Action_Unit_RefID,
  Assessments.Action_UnitAmount,
  Assessments.IsCustom,
  Assessments.IfCustom_Name,
  Assessments.IfCustom_Description,
  Assessments.RequiredAction_Comment,
  Assessments.Action_Timeframe_RefID,
  Assessments.PriceValue_Amount
From
  res_str_attics Left Join
  (Select
    res_str_attic_properties.RES_STR_Attic_PropertyID,
    res_str_attic_properties.GlobalPropertyMatchingID,
    res_str_attic_propertyassessments.RES_STR_Attic_PropertyAssessmentID,
    res_str_attic_propertyassessments.Rating_RefID,
    res_str_attic_propertyassessments.AtticProperty_RefID,
    res_str_attic_propertyassessments.DocumentHeader_RefID,
    res_str_attic_propertyassessments.Comment As PropertyAssessment_Comment,
    res_str_attic_properties.IsDeleted,
    res_str_attic_propertyassessments.IsDeleted As IsDeleted1,
    res_str_attic_properties.Tenant_RefID,
    RequieredActions.RES_STR_Attic_RequiredActionID,
    RequieredActions.Action_Name_DictID,
    RequieredActions.AtticPropertyAssestment_RefID,
    RequieredActions.SelectedActionVersion_RefID,
    RequieredActions.Action_PricePerUnit_RefID,
    RequieredActions.EffectivePrice_RefID,
    RequieredActions.Action_Unit_RefID,
    RequieredActions.Action_UnitAmount,
    RequieredActions.IsCustom,
    RequieredActions.IfCustom_Name,
    RequieredActions.IfCustom_Description,
    RequieredActions.Action_Timeframe_RefID,
    RequieredActions.RequiredAction_Comment,
    res_str_attic_propertyassessments.STR_Attic_RefID,
    RequieredActions.PriceValue_Amount
  From
    res_str_attic_properties Inner Join
    res_str_attic_propertyassessments
      On res_str_attic_propertyassessments.AtticProperty_RefID =
      res_str_attic_properties.RES_STR_Attic_PropertyID Left Join
    (Select
      res_act_action_version.Action_Name_DictID,
      res_act_action_version.IsDeleted As IsDeleted1,
      res_act_action_version.Tenant_RefID,
      res_str_attic_requiredactions.RES_STR_Attic_RequiredActionID,
      res_str_attic_requiredactions.AtticPropertyAssestment_RefID,
      res_str_attic_requiredactions.SelectedActionVersion_RefID,
      res_str_attic_requiredactions.Action_PricePerUnit_RefID,
      res_str_attic_requiredactions.EffectivePrice_RefID,
      res_str_attic_requiredactions.Action_Unit_RefID,
      res_str_attic_requiredactions.Action_UnitAmount,
      res_str_attic_requiredactions.IsCustom,
      res_str_attic_requiredactions.IfCustom_Name,
      res_str_attic_requiredactions.IfCustom_Description,
      res_str_attic_requiredactions.Action_Timeframe_RefID,
      res_str_attic_requiredactions.Comment As RequiredAction_Comment,
      res_str_attic_requiredactions.IsDeleted,
      res_str_attic_requiredactions.Tenant_RefID As Tenant_RefID1,
      cmn_price_values.PriceValue_Amount,
      cmn_price_values.IsDeleted As IsDeleted2
    From
      res_act_action_version Inner Join
      res_str_attic_requiredactions
        On res_act_action_version.RES_ACT_Action_VersionID =
        res_str_attic_requiredactions.SelectedActionVersion_RefID Inner Join
      cmn_price_values On cmn_price_values.Price_RefID =
        res_str_attic_requiredactions.Action_PricePerUnit_RefID
    Where
      res_act_action_version.IsDeleted = 0 And
      res_act_action_version.Tenant_RefID = @TenantID And
      res_str_attic_requiredactions.IsDeleted = 0 And
      res_str_attic_requiredactions.Tenant_RefID = @TenantID And
      cmn_price_values.IsDeleted = 0) RequieredActions
      On RequieredActions.AtticPropertyAssestment_RefID =
      res_str_attic_propertyassessments.RES_STR_Attic_PropertyAssessmentID
  Where
    res_str_attic_properties.IsDeleted = 0 And
    res_str_attic_propertyassessments.IsDeleted = 0 And
    res_str_attic_properties.Tenant_RefID = @TenantID) Assessments
    On Assessments.STR_Attic_RefID = res_str_attics.RES_STR_AtticID
Where
  res_str_attics.IsDeleted = 0 And
    res_str_attics.RES_BLD_Attic_RefID = @BuildingPartID And

  res_str_attics.Tenant_RefID = @TenantID And
  res_str_attics.DUD_Revision_RefID = @RevisionID
  