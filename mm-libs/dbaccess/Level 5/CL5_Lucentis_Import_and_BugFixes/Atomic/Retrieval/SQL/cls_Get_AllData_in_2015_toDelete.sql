
		Select
  bil_billpositions.BIL_BillPositionID,
  bil_billpositions.External_PositionReferenceField As VorgangsNummer,
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID,
  bil_billheaders.BIL_BillHeaderID,
  bil_billheaders.BillNumber,
  bil_billposition_2_patienttreatment.AssignmentID,
  hec_patient_treatment.HEC_Patient_TreatmentID,
  hec_patient_treatment.IsTreatmentFollowup,
  hec_patient_treatment1.HEC_Patient_TreatmentID As OriginalTreatmentID
From
  bil_billpositions Inner Join
  bil_billposition_transmitionstatuses On bil_billpositions.BIL_BillPositionID =
    bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
    bil_billposition_transmitionstatuses.IsDeleted = 0 And
    bil_billposition_transmitionstatuses.IsActive = 1 Inner Join
  bil_billheaders On bil_billpositions.BIL_BilHeader_RefID =
    bil_billheaders.BIL_BillHeaderID And bil_billheaders.IsDeleted = 0
    And bil_billheaders.Tenant_RefID = @TenantID Inner Join
  bil_billposition_2_patienttreatment
    On bil_billposition_2_patienttreatment.BIL_BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID And
    bil_billposition_2_patienttreatment.IsDeleted = 0 And
    bil_billposition_2_patienttreatment.Tenant_RefID = @TenantID Inner Join
  hec_patient_treatment
    On bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    hec_patient_treatment.IsDeleted = 0 And hec_patient_treatment.Tenant_RefID =
    @TenantID And hec_patient_treatment.IsTreatmentBilled = 1 Left Join
  hec_patient_treatment hec_patient_treatment1
    On hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID =
    hec_patient_treatment1.HEC_Patient_TreatmentID And
    hec_patient_treatment1.IsDeleted = 0 And hec_patient_treatment1.Tenant_RefID
    = @TenantID And hec_patient_treatment1.IsTreatmentFollowup = 0
Where
  bil_billpositions.Tenant_RefID = @TenantID And
  bil_billpositions.IsDeleted = 0  And
  YEAR(bil_billpositions.Creation_Timestamp)=2015
  