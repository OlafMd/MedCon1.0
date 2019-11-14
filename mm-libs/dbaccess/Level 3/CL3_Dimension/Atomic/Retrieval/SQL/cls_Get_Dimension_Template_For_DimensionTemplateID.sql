
Select
  cmn_pro_dimensions.CMN_PRO_DimensionID,  
  cmn_pro_dimensions.Abbreviation,
  cmn_pro_dimensions.DimensionName_DictID, 
  cmn_pro_dimensions.IsDimensionTemplate,
  cmn_pro_dimension_values.CMN_PRO_Dimension_ValueID,
  cmn_pro_dimension_values.Dimensions_RefID,
  cmn_pro_dimension_values.DimensionValue_Text_DictID,
  cmn_pro_dimension_values.OrderSequence  
From
  cmn_pro_dimensions 
Left Join
  cmn_pro_dimension_values 
    On cmn_pro_dimensions.CMN_PRO_DimensionID = cmn_pro_dimension_values.Dimensions_RefID 
    And cmn_pro_dimension_values.IsDeleted = 0 
    And cmn_pro_dimension_values.Tenant_RefID = @TenantID  
Where
  cmn_pro_dimensions.CMN_PRO_DimensionID = @DimensionID 
  And cmn_pro_dimensions.IsDimensionTemplate = 1 
  And cmn_pro_dimensions.Tenant_RefID = @TenantID 
  And cmn_pro_dimensions.IsDeleted = 0
  