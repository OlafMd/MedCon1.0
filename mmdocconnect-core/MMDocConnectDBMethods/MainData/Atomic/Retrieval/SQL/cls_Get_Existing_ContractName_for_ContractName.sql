
    Select
      cmn_ctr_contracts.ContractName
    From
      cmn_ctr_contracts
    Where
      cmn_ctr_contracts.ContractName Like @ContractName And
      cmn_ctr_contracts.IsDeleted = 0 And
      cmn_ctr_contracts.Tenant_RefID = @TenantID
    Order By
      cmn_ctr_contracts.Creation_Timestamp desc
    Limit 1
  