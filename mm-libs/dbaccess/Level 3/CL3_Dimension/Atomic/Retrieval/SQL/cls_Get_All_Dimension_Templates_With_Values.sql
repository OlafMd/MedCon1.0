
Select
  cmn_pro_dimensions.CMN_PRO_DimensionID,
  cmn_pro_dimensions.Product_RefID,
  cmn_pro_dimensions.Abbreviation,
  cmn_pro_dimensions.DimensionName_DictID,
  cmn_pro_dimensions.OrderSequence As Dimension_Ordersequence,
  cmn_pro_dimensions.IsDimensionTemplate,
  cmn_pro_dimensions.Creation_Timestamp As Dimension_Creation_Timestamp,
  cmn_pro_dimensions.Modification_Timestamp As Dimension_Modification_Timestamp,
  
  cmn_pro_dimension_values.CMN_PRO_Dimension_ValueID,
  cmn_pro_dimension_values.Dimensions_RefID,
  cmn_pro_dimension_values.DimensionValue_Text_DictID,
  cmn_pro_dimension_values.OrderSequence As DimensionValue_Ordersequence,
  cmn_pro_dimension_values.Creation_Timestamp As    DimensionValue_Creation_Timestamp,
  cmn_pro_dimension_values.Modification_Timestamp As    DimensionValue_Modification_Timestamp  
From
  cmn_pro_dimensions 
Left Join
  cmn_pro_dimension_values 
    On cmn_pro_dimensions.CMN_PRO_DimensionID =      cmn_pro_dimension_values.Dimensions_RefID 
    And      cmn_pro_dimension_values.IsDeleted = 0 
    And      cmn_pro_dimension_values.Tenant_RefID = @TenantID  
Where
  cmn_pro_dimensions.IsDimensionTemplate = 1 
  And    cmn_pro_dimensions.Tenant_RefID = @TenantID 
  And    cmn_pro_dimensions.IsDeleted = 0
  