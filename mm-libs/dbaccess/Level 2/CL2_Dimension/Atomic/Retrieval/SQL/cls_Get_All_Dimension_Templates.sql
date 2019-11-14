
Select
  cmn_pro_dimensions.CMN_PRO_DimensionID,
  cmn_pro_dimensions.Product_RefID,
  cmn_pro_dimensions.Abbreviation,
  cmn_pro_dimensions.DimensionName_DictID,
  cmn_pro_dimensions.OrderSequence,
  cmn_pro_dimensions.IsDimensionTemplate,
  cmn_pro_dimensions.Creation_Timestamp,
  cmn_pro_dimensions.Modification_Timestamp
From
  cmn_pro_dimensions
Where
  cmn_pro_dimensions.IsDeleted = 0 And
  cmn_pro_dimensions.Modification_Timestamp = @TenantID And
  cmn_pro_dimensions.IsDimensionTemplate = 1
  