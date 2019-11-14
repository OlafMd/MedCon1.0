
Select
  hec_patient_prescription_headers.PrescribedBy_Doctor_RefID,
  hec_patient_prescription_headers.HEC_Patient_Prescription_HeaderID,
  hec_patient_prescription_positions.HEC_Patient_Prescription_PositionID,
  hec_patient_prescription_headers.Prescription_Date,
  hec_patient_prescription_positions.InitializedFrom_PatientMedication_RefID
From
  hec_patient_prescription_headers Inner Join
  hec_patient_prescription_positions
    On hec_patient_prescription_positions.PrescriptionHeader_RefID =
    hec_patient_prescription_headers.HEC_Patient_Prescription_HeaderID
Where
  hec_patient_prescription_headers.HEC_ACT_PerformedAction_RefID =
  @PerformedActionID And
  hec_patient_prescription_headers.IsDeleted = 0 And
  hec_patient_prescription_headers.Tenant_RefID = @TenantID And
  hec_patient_prescription_positions.IsDeleted = 0
  Order By
  hec_patient_prescription_headers.Creation_Timestamp Desc
  