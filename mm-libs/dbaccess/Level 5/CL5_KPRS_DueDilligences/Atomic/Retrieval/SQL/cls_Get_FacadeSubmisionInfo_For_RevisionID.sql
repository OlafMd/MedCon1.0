
Select
  res_str_facades.RES_STR_FacadeID,
  res_str_facades.DocumentHeader_RefID As Facade_DocumentHeader_RefID,
  res_str_facades.Comment As Facade_Comment,
  res_str_facades.AverageRating_RefID,
  res_str_facades.RES_BLD_Facade_RefID,
  Assassments.RES_STR_Facade_PropertyID,
  Assassments.RES_STR_Facade_PropertyAssessmentID,
  Assassments.RES_STR_Facade_RequiredActionID,
  Assassments.GlobalPropertyMatchingID,
  Assassments.STR_Facade_RefID,
  Assassments.Rating_RefID,
  Assassments.FacadeProperty_RefID,
  Assassments.DocumentHeader_RefID,
  Assassments.PropertyAssessment_Comment,
  Assassments.Action_Name_DictID,
  Assassments.FacadePropertyAssestment_RefID,
  Assassments.Action_PricePerUnit_RefID,
  Assassments.EffectivePrice_RefID,
  Assassments.Action_Unit_RefID,
  Assassments.Action_UnitAmount,
  Assassments.IsCustom,
  Assassments.IfCustom_Name,
  Assassments.IfCustom_Description,
  Assassments.Action_Timeframe_RefID,
  Assassments.RequiredActions_Comment,
  Assassments.SelectedActionVersion_RefID,
  Assassments.PriceValue_Amount
From
  res_str_facades Left Join
  (Select
    res_str_facade_properties.GlobalPropertyMatchingID,
    res_str_facade_properties.RES_STR_Facade_PropertyID,
    res_str_facade_propertyassessments.RES_STR_Facade_PropertyAssessmentID,
    res_str_facade_propertyassessments.STR_Facade_RefID,
    res_str_facade_propertyassessments.Rating_RefID,
    res_str_facade_propertyassessments.FacadeProperty_RefID,
    res_str_facade_propertyassessments.DocumentHeader_RefID,
    res_str_facade_propertyassessments.Comment As PropertyAssessment_Comment,
    RequieredActions.RES_STR_Facade_RequiredActionID,
    RequieredActions.Action_Name_DictID,
    RequieredActions.FacadePropertyAssestment_RefID,
    RequieredActions.EffectivePrice_RefID,
    RequieredActions.Action_PricePerUnit_RefID,
    RequieredActions.Action_Unit_RefID,
    RequieredActions.Action_UnitAmount,
    RequieredActions.IsCustom,
    RequieredActions.IfCustom_Name,
    RequieredActions.IfCustom_Description,
    RequieredActions.Action_Timeframe_RefID,
    RequieredActions.RequiredActions_Comment,
    RequieredActions.SelectedActionVersion_RefID,
    RequieredActions.PriceValue_Amount
  From
    res_str_facade_properties Inner Join
    res_str_facade_propertyassessments
      On res_str_facade_propertyassessments.FacadeProperty_RefID =
      res_str_facade_properties.RES_STR_Facade_PropertyID Left Join
    (Select
      res_act_action_version.Action_Name_DictID,
      res_str_facade_requiredactions.RES_STR_Facade_RequiredActionID,
      res_str_facade_requiredactions.FacadePropertyAssestment_RefID,
      res_str_facade_requiredactions.EffectivePrice_RefID,
      res_str_facade_requiredactions.Action_PricePerUnit_RefID,
      res_str_facade_requiredactions.Action_Unit_RefID,
      res_str_facade_requiredactions.Action_UnitAmount,
      res_str_facade_requiredactions.IsCustom,
      res_str_facade_requiredactions.IfCustom_Name,
      res_str_facade_requiredactions.IfCustom_Description,
      res_str_facade_requiredactions.Action_Timeframe_RefID,
      res_str_facade_requiredactions.Comment As RequiredActions_Comment,
      res_str_facade_requiredactions.IsDeleted,
      res_act_action_version.IsDeleted As IsDeleted1,
      res_act_action_version.Tenant_RefID,
      res_str_facade_requiredactions.Tenant_RefID As Tenant_RefID1,
      res_str_facade_requiredactions.SelectedActionVersion_RefID,
      cmn_price_values.PriceValue_Amount,
      cmn_price_values.IsDeleted As IsDeleted2
    From
      res_act_action_version Inner Join
      res_str_facade_requiredactions
        On res_str_facade_requiredactions.SelectedActionVersion_RefID =
        res_act_action_version.RES_ACT_Action_VersionID Inner Join
      cmn_price_values On cmn_price_values.Price_RefID =
        res_str_facade_requiredactions.Action_PricePerUnit_RefID
    Where
      res_str_facade_requiredactions.IsDeleted = 0 And
      res_act_action_version.IsDeleted = 0 And
      res_act_action_version.Tenant_RefID = @TenantID And
      res_str_facade_requiredactions.Tenant_RefID = @TenantID And
      cmn_price_values.IsDeleted = 0) RequieredActions
      On RequieredActions.FacadePropertyAssestment_RefID =
      res_str_facade_propertyassessments.RES_STR_Facade_PropertyAssessmentID
  Where
    res_str_facade_propertyassessments.IsDeleted = 0 And
    res_str_facade_properties.IsDeleted = 0 And
    res_str_facade_propertyassessments.Tenant_RefID = @TenantID) Assassments
    On Assassments.STR_Facade_RefID = res_str_facades.RES_STR_FacadeID
Where
  res_str_facades.IsDeleted = 0 And
    res_str_facades.RES_BLD_Facade_RefID = @BuildingPartID And

  res_str_facades.Tenant_RefID = @TenantID And
  res_str_facades.DUD_Revision_RefID = @RevisionID
  