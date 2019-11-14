

Select
  res_str_staircases.DocumentHeader_RefID As Staircase_DocumentHeader_RefID,
  res_str_staircases.Comment As Staircase_Comment,
  res_str_staircases.AverageRating_RefID,
  res_str_staircases.RES_STR_StaircaseID,
  res_str_staircases.RES_BLD_Staircase_RefID,
  res_bld_staircases.StaircaseSize_Unit_RefID,
  res_bld_staircases.StaircaseSize_Value,
  Assessments.RES_STR_Staircase_PropertyID,
  Assessments.RES_STR_Staircase_PropertyAssessmentID,
  Assessments.GlobalPropertyMatchingID,
  Assessments.STR_Staircase_RefID,
  Assessments.RES_STR_Staircase_RequiredActionID,
  Assessments.Rating_RefID,
  Assessments.PropertyAssessment_Comment,
  Assessments.DocumentHeader_RefID,
  Assessments.Action_Name_DictID,
  Assessments.StaircasePropertyAssessment_RefID,
  Assessments.RequiredAction_Comment,
  Assessments.EffectivePrice_RefID,
  Assessments.Action_PricePerUnit_RefID,
  Assessments.Action_UnitAmount,
  Assessments.Action_Unit_RefID,
  Assessments.IsCustom,
  Assessments.IfCustom_Name,
  Assessments.IfCustom_Description,
  Assessments.Action_Timeframe_RefID,
  Assessments.SelectedActionVersion_RefID,
  Assessments.PriceValue_Amount
From
  res_str_staircases Inner Join
  res_bld_staircases On res_bld_staircases.RES_BLD_StaircaseID =
    res_str_staircases.RES_BLD_Staircase_RefID Left Join
  (Select
    res_str_staircase_properties.RES_STR_Staircase_PropertyID,
    res_str_staircase_properties.GlobalPropertyMatchingID,
    res_str_staircase_propertyassessments.RES_STR_Staircase_PropertyAssessmentID,
    res_str_staircase_propertyassessments.STR_Staircase_RefID,
    res_str_staircase_propertyassessments.Rating_RefID,
    res_str_staircase_propertyassessments.DocumentHeader_RefID,
    res_str_staircase_propertyassessments.Comment As PropertyAssessment_Comment,
    RequieredActions.RES_STR_Staircase_RequiredActionID,
    RequieredActions.Action_Name_DictID,
    RequieredActions.StaircasePropertyAssessment_RefID,
    RequieredActions.EffectivePrice_RefID,
    RequieredActions.RequiredAction_Comment,
    RequieredActions.Action_PricePerUnit_RefID,
    RequieredActions.Action_UnitAmount,
    RequieredActions.Action_Unit_RefID,
    RequieredActions.IsCustom,
    RequieredActions.IfCustom_Name,
    RequieredActions.IfCustom_Description,
    RequieredActions.Action_Timeframe_RefID,
    RequieredActions.SelectedActionVersion_RefID,
    RequieredActions.PriceValue_Amount
  From
    res_str_staircase_properties Inner Join
    res_str_staircase_propertyassessments
      On res_str_staircase_propertyassessments.StaircaseProperty_RefID =
      res_str_staircase_properties.RES_STR_Staircase_PropertyID Left Join
    (Select
      res_act_action_version.Action_Name_DictID,
      res_str_staircase_requiredactions.RES_STR_Staircase_RequiredActionID,
      res_str_staircase_requiredactions.StaircasePropertyAssessment_RefID,
      res_str_staircase_requiredactions.EffectivePrice_RefID,
      res_str_staircase_requiredactions.Comment As RequiredAction_Comment,
      res_str_staircase_requiredactions.Action_PricePerUnit_RefID,
      res_str_staircase_requiredactions.Action_UnitAmount,
      res_str_staircase_requiredactions.Action_Unit_RefID,
      res_str_staircase_requiredactions.IsCustom,
      res_str_staircase_requiredactions.IfCustom_Name,
      res_str_staircase_requiredactions.IfCustom_Description,
      res_str_staircase_requiredactions.Action_Timeframe_RefID,
      res_str_staircase_requiredactions.IsDeleted,
      res_act_action_version.IsDeleted As IsDeleted1,
      res_act_action_version.Tenant_RefID,
      res_str_staircase_requiredactions.Tenant_RefID As Tenant_RefID1,
      res_str_staircase_requiredactions.SelectedActionVersion_RefID,
      price.PriceValue_Amount
    From
      res_act_action_version Inner Join
      res_str_staircase_requiredactions
        On res_str_staircase_requiredactions.SelectedActionVersion_RefID =
        res_act_action_version.RES_ACT_Action_VersionID Inner Join
      (Select
        cmn_price_values.PriceValue_Amount,
        cmn_price_values.IsDeleted,
        cmn_price_values.Tenant_RefID,
        cmn_price_values.Price_RefID
      From
        cmn_price_values
      Where
        cmn_price_values.IsDeleted = 0 And
        cmn_price_values.Tenant_RefID = @TenantID) price
        On res_str_staircase_requiredactions.Action_PricePerUnit_RefID =
        price.Price_RefID
    Where
      res_str_staircase_requiredactions.IsDeleted = 0 And
      res_act_action_version.IsDeleted = 0 And
      res_act_action_version.Tenant_RefID = @TenantID And
      res_str_staircase_requiredactions.Tenant_RefID = @TenantID)
    RequieredActions On RequieredActions.StaircasePropertyAssessment_RefID =
      res_str_staircase_propertyassessments.RES_STR_Staircase_PropertyAssessmentID
  Where
    res_str_staircase_propertyassessments.IsDeleted = 0 And
    res_str_staircase_properties.IsDeleted = 0 And
    res_str_staircase_properties.Tenant_RefID = @TenantID) Assessments
    On Assessments.STR_Staircase_RefID = res_str_staircases.RES_STR_StaircaseID
Where
  res_str_staircases.IsDeleted = 0 And
  res_str_staircases.RES_BLD_Staircase_RefID = @BuildingPartID And
  res_str_staircases.DUD_Revision_RefID = @RevisionID And
  res_str_staircases.Tenant_RefID = @TenantID
  