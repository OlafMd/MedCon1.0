
Select
  bil_billpositions.External_PositionType,
  bil_billpositions.External_PositionReferenceField As VorgassNumber,
  bil_billpositions.BIL_BillPositionID,
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID,
  hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID,
  hec_patient_treatment.HEC_Patient_TreatmentID As FollowupID
From
  hec_patient_treatment Inner Join
  bil_billposition_2_patienttreatment
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID Inner Join
  bil_billpositions
    On bil_billposition_2_patienttreatment.BIL_BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID Inner Join
  bil_billposition_transmitionstatuses On bil_billpositions.BIL_BillPositionID =
    bil_billposition_transmitionstatuses.BillPosition_RefID
Where
  bil_billpositions.IsDeleted = 0 And
  bil_billpositions.Tenant_RefID = @TenantID And
  hec_patient_treatment.IsTreatmentFollowup = 1 And
  bil_billposition_transmitionstatuses.IsActive = 1 And
  bil_billposition_transmitionstatuses.IsDeleted = 0
  