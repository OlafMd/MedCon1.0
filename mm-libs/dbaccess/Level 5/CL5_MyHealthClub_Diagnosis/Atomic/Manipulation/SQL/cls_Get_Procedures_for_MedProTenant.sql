
  Select Distinct
  hec_tre_potentialprocedures.HEC_TRE_PotentialProcedureID,
  hec_tre_potentialprocedures.PotentialProcedure_Name_DictID,
  hec_tre_potentialprocedure_catalogcodes.Code
From
  hec_tre_potentialprocedures Inner Join
  hec_tre_potentialprocedure_catalogcodes
    On hec_tre_potentialprocedures.HEC_TRE_PotentialProcedureID =
    hec_tre_potentialprocedure_catalogcodes.PotentialProcedure_RefID And
    hec_tre_potentialprocedure_catalogcodes.Tenant_RefID = @TenantID And
    hec_tre_potentialprocedure_catalogcodes.IsDeleted = 0
Where
  hec_tre_potentialprocedures.Tenant_RefID = @TenantID And
  hec_tre_potentialprocedures.IsDeleted =  0
  