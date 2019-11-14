    
Select
  hec_patient_treatment.IsDeleted As IsTreatmentDeleted,
  hec_patient_treatment.IsTreatmentFollowup,
  hec_patient_treatment.IfSheduled_ForDoctor_RefID,
  hec_patient_treatment.Treatment_Comment,
  hec_patient_treatment.IfTreatmentBilled_Date,
  hec_patient_treatment.IsTreatmentBilled,
  hec_patient_treatment.IfSheduled_Date,
  hec_patient_treatment.IsScheduled,
  hec_patient_treatment.IfTreatmentPerformed_Date,
  hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID,
  hec_patient_treatment.IsTreatmentPerformed,
  hec_patient_treatment.TreatmentPractice_RefID,
  hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID,
  hec_patient_treatment_ocularextension.IsTreatmentOfLeftEye,
  hec_patient_treatment_ocularextension.IsTreatmentOfRightEye,
  hec_patient_2_patienttreatment.HEC_Patient_RefID,
  bil_billpositions.External_PositionCode,
  bil_billpositions.External_PositionType,
  bil_billpositions.External_PositionReferenceField,
  bil_billpositions.BillPosition_ProductNumber,
  bil_billpositions.PositionValue_IncludingTax,
  bil_billpositions.PositionValue_BeforeTax,
  bil_billpositions.PositionNumber,
  bil_billpositions.BIL_BillPositionID,
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID,
  bil_billposition_transmitionstatuses.TransmitionCode,
  bil_billposition_transmitionstatuses.PrimaryComment,
  bil_billposition_transmitionstatuses.SecondaryComment,
  bil_billposition_transmitionstatuses.TransmittedOnDate,
  bil_billposition_transmitionstatuses.Creation_Timestamp,
  bil_billposition_transmitionstatuses.IsActive,
  hec_patient_treatment_relevantdiagnoses.DiagnosedOnDate,
  hec_patient_treatment_relevantdiagnoses.HEC_Patient_Treatment_RelevantDiagnosisID,
  hec_patient_treatment_relevantdiagnoses.Doctor_RefID,
  hec_patient_treatment_relevantdiagnoses.Creation_Timestamp As Creation_Date,
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID,
  hec_dia_potentialdiagnoses.ICD10_Code,
  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
  hec_dia_diagnosis_states.HEC_DIA_Diagnosis_StateID,
  hec_dia_diagnosis_states.DiagnosisState_Abbreviation,
  hec_dia_diagnosis_states.DiagnosisState_Name_DictID,
  hec_patient_treatment_requiredproducts.Quantity,
  cmn_pro_products.Product_Number,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.CMN_PRO_ProductID,
  hec_patient_treatment.HEC_Patient_TreatmentID
From
  hec_patient_treatment Left Join
  hec_patient_treatment_ocularextension
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_treatment_ocularextension.HEC_Patient_Treatment_RefID And
    hec_patient_treatment_ocularextension.IsDeleted = 0 And
    hec_patient_treatment_ocularextension.Tenant_RefID = @TenantID Left Join
  hec_patient_2_patienttreatment
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID And
    hec_patient_2_patienttreatment.Tenant_RefID = @TenantID And
    (hec_patient_2_patienttreatment.IsDeleted = 0 Or
      hec_patient_2_patienttreatment.IsDeleted Is Null) Left Join
  bil_billposition_2_patienttreatment
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID And
    (bil_billposition_2_patienttreatment.IsDeleted = 0 Or
      bil_billposition_2_patienttreatment.IsDeleted Is Null) And
    bil_billposition_2_patienttreatment.Tenant_RefID = @TenantID Left Join
  bil_billpositions
    On bil_billposition_2_patienttreatment.BIL_BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID And (bil_billpositions.IsDeleted = 0 Or
      bil_billpositions.IsDeleted Is Null) And bil_billpositions.Tenant_RefID =
    @TenantID Left Join
  bil_billposition_transmitionstatuses On bil_billpositions.BIL_BillPositionID =
    bil_billposition_transmitionstatuses.BillPosition_RefID And
    (bil_billposition_transmitionstatuses.IsDeleted = 0 Or
      bil_billposition_transmitionstatuses.IsDeleted Is Null) And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID Left Join
  hec_patient_treatment_relevantdiagnoses
    On hec_patient_treatment_relevantdiagnoses.Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    hec_patient_treatment_relevantdiagnoses.Tenant_RefID = @TenantID And
    hec_patient_treatment_relevantdiagnoses.IsDeleted = 0 Left Join
  hec_dia_potentialdiagnoses
    On hec_patient_treatment_relevantdiagnoses.DIA_PotentialDiagnosis_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
    hec_dia_potentialdiagnoses.IsDeleted = 0 And
    hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID Left Join
  hec_dia_diagnosis_states On hec_dia_diagnosis_states.HEC_DIA_Diagnosis_StateID
    = hec_patient_treatment_relevantdiagnoses.DIA_State_RefID And
    hec_dia_diagnosis_states.IsDeleted = 0 And
    hec_dia_diagnosis_states.Tenant_RefID = @TenantID Left Join
  hec_patient_treatment_requiredproducts
    On hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    hec_patient_treatment_requiredproducts.IsDeleted = 0 And
    hec_patient_treatment_requiredproducts.Tenant_RefID = @TenantID Left Join
  hec_products
    On hec_products.HEC_ProductID =
    hec_patient_treatment_requiredproducts.HEC_Product_RefID And
    hec_products.IsDeleted = 0 And hec_products.Tenant_RefID = @TenantID
  Left Join
  cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.IsDeleted = 0 And
    cmn_pro_products.Tenant_RefID = @TenantID
Where
  hec_patient_treatment.HEC_Patient_TreatmentID = @TreatmentIDs And
  hec_patient_treatment.Tenant_RefID = @TenantID
  