

Select
  res_str_hvacrs.RES_STR_HVACRID,
  res_str_hvacrs.DocumentHeader_RefID As HVACR_DocumentHeader_RefID,
  res_str_hvacrs.AverageRating_RefID,
  res_str_hvacrs.Comment As HVACR_Comment,
  res_str_hvacrs.RES_BLD_HVACR_RefID,
  Assassment.RES_STR_HVACR_PropertyID,
  Assassment.RES_STR_HVACR_PropertyAssessmentID,
  Assassment.RES_STR_HVACR_RequiredActionID,
  Assassment.GlobalPropertyMatchingID,
  Assassment.STR_HVACR_RefID,
  Assassment.Rating_RefID,
  Assassment.HVACRProperty_RefID,
  Assassment.DocumentHeader_RefID,
  Assassment.PropertyAssessment_Comment,
  Assassment.Action_Name_DictID,
  Assassment.HVACRPropertyAssestment_RefID,
  Assassment.Action_Unit_RefID,
  Assassment.EffectivePrice_RefID,
  Assassment.Action_PricePerUnit_RefID,
  Assassment.Action_UnitAmount,
  Assassment.IsCustom,
  Assassment.IfCustom_Name,
  Assassment.IfCustom_Description,
  Assassment.Action_Timeframe_RefID,
  Assassment.SelectedActionVersion_RefID,
  Assassment.RequiredAction_Comment,
  Assassment.PriceValue_Amount
From
  res_str_hvacrs Left Join
  (Select
    res_str_hvacr_properties.RES_STR_HVACR_PropertyID,
    res_str_hvacr_properties.GlobalPropertyMatchingID,
    res_str_hvacr_propertyassessments.RES_STR_HVACR_PropertyAssessmentID,
    res_str_hvacr_propertyassessments.STR_HVACR_RefID,
    res_str_hvacr_propertyassessments.Rating_RefID,
    res_str_hvacr_propertyassessments.HVACRProperty_RefID,
    res_str_hvacr_propertyassessments.DocumentHeader_RefID,
    res_str_hvacr_propertyassessments.Comment As PropertyAssessment_Comment,
    RequieredAction.RES_STR_HVACR_RequiredActionID,
    RequieredAction.Action_Name_DictID,
    RequieredAction.HVACRPropertyAssestment_RefID,
    RequieredAction.EffectivePrice_RefID,
    RequieredAction.Action_PricePerUnit_RefID,
    RequieredAction.Action_Unit_RefID,
    RequieredAction.Action_UnitAmount,
    RequieredAction.IsCustom,
    RequieredAction.IfCustom_Name,
    RequieredAction.IfCustom_Description,
    RequieredAction.Action_Timeframe_RefID,
    RequieredAction.RequiredAction_Comment,
    RequieredAction.SelectedActionVersion_RefID,
    RequieredAction.PriceValue_Amount
  From
    res_str_hvacr_properties Inner Join
    res_str_hvacr_propertyassessments
      On res_str_hvacr_propertyassessments.HVACRProperty_RefID =
      res_str_hvacr_properties.RES_STR_HVACR_PropertyID Left Join
    (Select
      res_act_action_version.Action_Name_DictID,
      res_str_hvacr_requiredactions.RES_STR_HVACR_RequiredActionID,
      res_str_hvacr_requiredactions.HVACRPropertyAssestment_RefID,
      res_str_hvacr_requiredactions.EffectivePrice_RefID,
      res_str_hvacr_requiredactions.Action_PricePerUnit_RefID,
      res_str_hvacr_requiredactions.Action_Unit_RefID,
      res_str_hvacr_requiredactions.Action_UnitAmount,
      res_str_hvacr_requiredactions.IsCustom,
      res_str_hvacr_requiredactions.IfCustom_Name,
      res_str_hvacr_requiredactions.IfCustom_Description,
      res_str_hvacr_requiredactions.Creation_Timestamp,
      res_str_hvacr_requiredactions.Action_Timeframe_RefID,
      res_str_hvacr_requiredactions.Comment As RequiredAction_Comment,
      res_str_hvacr_requiredactions.IsDeleted,
      res_act_action_version.IsDeleted As IsDeleted1,
      res_act_action_version.Tenant_RefID,
      res_str_hvacr_requiredactions.Tenant_RefID As Tenant_RefID1,
      res_str_hvacr_requiredactions.SelectedActionVersion_RefID,
      cmn_price_values.PriceValue_Amount
    From
      res_act_action_version Inner Join
      res_str_hvacr_requiredactions
        On res_str_hvacr_requiredactions.SelectedActionVersion_RefID =
        res_act_action_version.RES_ACT_Action_VersionID Inner Join
      cmn_price_values On cmn_price_values.Price_RefID =
        res_str_hvacr_requiredactions.Action_PricePerUnit_RefID
    Where
      res_str_hvacr_requiredactions.IsDeleted = 0 And
      res_act_action_version.IsDeleted = 0 And
      res_act_action_version.Tenant_RefID = @TenantID And
      res_str_hvacr_requiredactions.Tenant_RefID = @TenantID) RequieredAction
      On RequieredAction.HVACRPropertyAssestment_RefID =
      res_str_hvacr_propertyassessments.RES_STR_HVACR_PropertyAssessmentID
  Where
    res_str_hvacr_propertyassessments.IsDeleted = 0 And
    res_str_hvacr_properties.IsDeleted = 0 And
    res_str_hvacr_propertyassessments.Tenant_RefID = @TenantID) Assassment
    On Assassment.STR_HVACR_RefID = res_str_hvacrs.RES_STR_HVACRID
Where
  res_str_hvacrs.IsDeleted = 0 And
    res_str_hvacrs.RES_BLD_HVACR_RefID = @BuildingPartID And

  res_str_hvacrs.Tenant_RefID = @TenantID And
  res_str_hvacrs.DUD_Revision_RefID = @RevisionID

  