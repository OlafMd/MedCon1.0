
Select
  res_str_roofs.RES_STR_RoofID,
  res_bld_roof_2_rooftype.RES_BLD_Roof_Type_RefID,
  res_str_roofs.DocumentHeader_RefID As Roof_DocumentHeader_RefID,
  res_str_roofs.Comment As Roof_Comment,
  res_str_roofs.AverageRating_RefID,
  res_str_roofs.RES_BLD_Roof_RefID,
  Assessments.RES_STR_Roof_PropertyID,
  Assessments.RES_STR_Roof_PropertyAssessmentID,
  Assessments.RES_STR_Roof_RequiredActionID,
  Assessments.GlobalPropertyMatchingID,
  Assessments.STR_Roof_RefID,
  Assessments.Rating_RefID,
  Assessments.RoofProperty_RefID,
  Assessments.DocumentHeader_RefID,
  Assessments.PropertyAssessment_Comment,
  Assessments.Action_Name_DictID,
  Assessments.RoofPropertyAssestment_RefID,
  Assessments.EffectivePrice_RefID,
  Assessments.Action_PricePerUnit_RefID,
  Assessments.IsCustom,
  Assessments.Action_UnitAmount,
  Assessments.Action_Unit_RefID,
  Assessments.IfCustom_Name,
  Assessments.IfCustom_Description,
  Assessments.RequiredAction_Comment,
  Assessments.Action_Timeframe_RefID,
  Assessments.SelectedActionVersion_RefID,
  Assessments.PriceValue_Amount
From
  res_str_roofs Left Join
  (Select
    res_str_roof_properties.RES_STR_Roof_PropertyID,
    res_str_roof_properties.GlobalPropertyMatchingID,
    res_str_roof_propertyassessments.RES_STR_Roof_PropertyAssessmentID,
    res_str_roof_propertyassessments.STR_Roof_RefID,
    res_str_roof_propertyassessments.Rating_RefID,
    res_str_roof_propertyassessments.RoofProperty_RefID,
    res_str_roof_propertyassessments.DocumentHeader_RefID,
    res_str_roof_propertyassessments.Comment As PropertyAssessment_Comment,
    res_str_roof_properties.IsDeleted,
    res_str_roof_propertyassessments.IsDeleted As IsDeleted1,
    res_str_roof_propertyassessments.Tenant_RefID As Tenant_RefID1,
    RequieredActions.RES_STR_Roof_RequiredActionID,
    RequieredActions.Action_Name_DictID,
    RequieredActions.RoofPropertyAssestment_RefID,
    RequieredActions.EffectivePrice_RefID,
    RequieredActions.Action_PricePerUnit_RefID,
    RequieredActions.IsCustom,
    RequieredActions.Action_UnitAmount,
    RequieredActions.Action_Unit_RefID,
    RequieredActions.IfCustom_Name,
    RequieredActions.IfCustom_Description,
    RequieredActions.Creation_Timestamp,
    RequieredActions.RequiredAction_Comment,
    RequieredActions.Action_Timeframe_RefID,
    RequieredActions.SelectedActionVersion_RefID,
    RequieredActions.PriceValue_Amount
  From
    res_str_roof_properties Inner Join
    res_str_roof_propertyassessments
      On res_str_roof_propertyassessments.RoofProperty_RefID =
      res_str_roof_properties.RES_STR_Roof_PropertyID Left Join
    (Select
      res_act_action_version.Action_Name_DictID,
      res_str_roof_requiredactions.RES_STR_Roof_RequiredActionID,
      res_str_roof_requiredactions.RoofPropertyAssestment_RefID,
      res_str_roof_requiredactions.EffectivePrice_RefID,
      res_str_roof_requiredactions.Action_PricePerUnit_RefID,
      res_str_roof_requiredactions.IsCustom,
      res_str_roof_requiredactions.Action_UnitAmount,
      res_str_roof_requiredactions.Action_Unit_RefID,
      res_str_roof_requiredactions.IfCustom_Name,
      res_str_roof_requiredactions.IfCustom_Description,
      res_str_roof_requiredactions.Creation_Timestamp,
      res_str_roof_requiredactions.Comment As RequiredAction_Comment,
      res_str_roof_requiredactions.Action_Timeframe_RefID,
      res_str_roof_requiredactions.IsDeleted,
      res_act_action_version.IsDeleted As IsDeleted1,
      res_act_action_version.Tenant_RefID,
      res_str_roof_requiredactions.Tenant_RefID As Tenant_RefID1,
      res_str_roof_requiredactions.SelectedActionVersion_RefID,
      Price.PriceValue_Amount
    From
      res_act_action_version Inner Join
      res_str_roof_requiredactions
        On res_str_roof_requiredactions.SelectedActionVersion_RefID =
        res_act_action_version.RES_ACT_Action_VersionID Inner Join
      (Select
        cmn_price_values.PriceValue_Amount,
        cmn_price_values.Price_RefID
      From
        cmn_price_values
      Where
        cmn_price_values.IsDeleted = 0 And
        cmn_price_values.Tenant_RefID = @TenantID) Price
        On res_str_roof_requiredactions.Action_PricePerUnit_RefID =
        Price.Price_RefID
    Where
      res_str_roof_requiredactions.IsDeleted = 0 And
      res_act_action_version.IsDeleted = 0 And
      res_act_action_version.Tenant_RefID = @TenantID And
      res_str_roof_requiredactions.Tenant_RefID = @TenantID) RequieredActions
      On RequieredActions.RoofPropertyAssestment_RefID =
      res_str_roof_propertyassessments.RES_STR_Roof_PropertyAssessmentID
  Where
    res_str_roof_properties.IsDeleted = 0 And
    res_str_roof_propertyassessments.IsDeleted = 0 And
    res_str_roof_propertyassessments.Tenant_RefID = @TenantID) Assessments
    On Assessments.STR_Roof_RefID = res_str_roofs.RES_STR_RoofID Inner Join
  res_bld_roof On res_bld_roof.RES_BLD_RoofID = res_str_roofs.RES_BLD_Roof_RefID
  Inner Join
  res_bld_roof_2_rooftype On res_bld_roof.RES_BLD_RoofID =
    res_bld_roof_2_rooftype.RES_BLD_Roof_RefID
Where
  res_str_roofs.IsDeleted = 0 And
  res_str_roofs.RES_BLD_Roof_RefID = @BuildingPartID And
  res_str_roofs.DUD_Revision_RefID = @RevisionID And
  res_str_roofs.Tenant_RefID = @TenantID
  