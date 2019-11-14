
Select
  res_act_action.RES_ACT_ActionID,
  res_act_action.CurrentVersion_RefID,
  res_act_action_version.RES_ACT_Action_VersionID,
  res_act_action_version.Action_Name_DictID,
  res_act_action_version.Action_Description_DictID,
  res_act_action_version.Action_Version,
  PriceValue.CMN_Price_ValueID,
  PriceValue.CMN_PriceID,
  PriceValue.PriceValue_Currency_RefID,
  PriceValue.PriceValue_Amount,
  Units.CMN_UnitID,
  Units.Label_DictID
From
  res_act_action Inner Join
  res_act_action_version On res_act_action_version.RES_ACT_Action_VersionID =
    res_act_action.CurrentVersion_RefID Left Join
  (Select
    cmn_price_values.CMN_Price_ValueID,
    cmn_price_values.PriceValue_Currency_RefID,
    cmn_price_values.PriceValue_Amount,
    cmn_prices.CMN_PriceID
  From
    cmn_prices Left Join
    cmn_price_values On cmn_prices.CMN_PriceID = cmn_price_values.Price_RefID
  Where
    cmn_prices.IsDeleted = 0 And
    cmn_price_values.IsDeleted = 0) PriceValue
    On res_act_action_version.Default_PricePerUnit_RefID =
    PriceValue.CMN_PriceID Left Join
  (Select
    Units.CMN_UnitID,
    Units.Label_DictID
  From
    cmn_units Units
  Where
    Units.IsDeleted = 0) Units On res_act_action_version.Default_Unit_RefID =
    Units.CMN_UnitID
Where
  res_act_action.IsDeleted = 0 And
  res_act_action_version.IsDeleted = 0 And
  res_act_action_version.Tenant_RefID = @TenantID
  