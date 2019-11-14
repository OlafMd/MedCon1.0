
Select
  hec_tre_potentialprocedures.PotentialProcedure_Name_DictID,
  hec_tre_potentialprocedures.HEC_TRE_PotentialProcedureID,
  hec_act_performedaction_procedures.HEC_ACT_PerformedAction_ProcedureID
From
  hec_act_performedaction_procedures Inner Join
  hec_tre_potentialprocedures
    On hec_act_performedaction_procedures.PotentialProcedure_RefID =
    hec_tre_potentialprocedures.HEC_TRE_PotentialProcedureID
Where
  hec_act_performedaction_procedures.HEC_ACT_PerformedAction_RefID =
  @PerformedActionID And
  hec_act_performedaction_procedures.IsDeleted = 0 And
  hec_act_performedaction_procedures.Tenant_RefID = @TenantID And
  hec_tre_potentialprocedures.IsDeleted = 0
Order By
  hec_act_performedaction_procedures.Creation_Timestamp Desc
  