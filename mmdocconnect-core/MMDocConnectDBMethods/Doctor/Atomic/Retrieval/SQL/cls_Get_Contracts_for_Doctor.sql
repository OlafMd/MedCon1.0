
Select
  cmn_ctr_contracts.ContractName,
  cmn_ctr_contracts.CMN_CTR_ContractID as contractID,
  cmn_ctr_contracts.ValidThrough,
    cmn_ctr_contracts.ValidFrom
From
  cmn_ctr_contracts
Where
  cmn_ctr_contracts.Tenant_RefID = @TenantID And
  cmn_ctr_contracts.IsDeleted = 0
  
  