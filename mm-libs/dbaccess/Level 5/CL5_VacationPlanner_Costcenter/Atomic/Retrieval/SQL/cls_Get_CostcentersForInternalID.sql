 
Select
  cmn_str_costcenters.CMN_STR_CostCenterID,
  cmn_str_costcenters.Name_DictID,
  cmn_str_costcenters.InternalID
From
  cmn_str_costcenters
Where
  cmn_str_costcenters.InternalID = @InternalID and
  cmn_str_costcenters.Tenant_RefID = @TenantID And
  cmn_str_costcenters.IsDeleted = 0
  