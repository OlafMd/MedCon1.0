
SELECT cmn_str_costcenter_types.CMN_STR_CostCenter_TypeID,
       cmn_str_costcenter_types.CostCenterType_Name_DictID,
       cmn_str_costcenter_types.IsDeleted
  FROM cmn_str_costcenter_types
  WHERE Tenant_RefID = @TenantID
    AND IsDeleted = 0
  