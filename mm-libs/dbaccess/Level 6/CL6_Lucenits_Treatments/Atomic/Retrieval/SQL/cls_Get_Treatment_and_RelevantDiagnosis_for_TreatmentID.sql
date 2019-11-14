

Select
  hec_patient_treatment.HEC_Patient_TreatmentID,
  hec_patient_treatment.TreatmentPractice_RefID,
  hec_patient_treatment.IsTreatmentPerformed,
  hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID,
  hec_patient_treatment.IfTreatmentPerformed_Date,
  hec_patient_treatment.IsTreatmentFollowup,
  hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID,
  hec_patient_treatment.IsScheduled,
  hec_patient_treatment.IfSheduled_Date,
  hec_patient_treatment.IsTreatmentBilled,
  hec_patient_treatment.IfTreatmentBilled_Date,
  hec_patient_treatment.Treatment_Comment,
  RelevantDiagnosis.HEC_Patient_Treatment_RelevantDiagnosisID,
  RelevantDiagnosis.HEC_DIA_Diagnosis_StateID,
  RelevantDiagnosis.HEC_DIA_Diagnosis_LocalizationID,
  RelevantDiagnosis.HEC_DIA_PotentialDiagnosisID,
  RelevantDiagnosis.Doctor_RefID,
  RelevantDiagnosis.DiagnosisLocalization_Name_DictID,
  RelevantDiagnosis.ICD10_Code,
  RelevantDiagnosis.DiagnosisState_Name_DictID,
  RelevantDiagnosis.DiagnosisState_Abbreviation,
  RelevantDiagnosis.DoctorFirstName,
  RelevantDiagnosis.DoctorLastName,
  RelevantDiagnosis.Creation_Date,
  RelevantDiagnosis.PotentialDiagnosis_Name_DictID,
  hec_patient_treatment_ocularextension.IsTreatmentOfLeftEye,
  hec_patient_treatment_ocularextension.IsTreatmentOfRightEye,
  RelevantDiagnosis.DiagnosedOnDate,
  Articles.Product_Name_DictID,
  Articles.Product_Number,
  Articles.Quantity,
  Articles.CMN_PRO_ProductID,
  PerformedStatus.TransmitionCode
From
  hec_patient_treatment Left Join
  bil_billposition_2_patienttreatment
    On bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    bil_billposition_2_patienttreatment.IsDeleted = 0 Left Join
  (Select
    hec_patient_treatment_relevantdiagnoses.HEC_Patient_Treatment_RelevantDiagnosisID,
    hec_patient_treatment_relevantdiagnoses.Patient_Treatment_RefID,
    hec_patient_treatment_relevantdiagnoses.Doctor_RefID,
    hec_dia_diagnosis_localizations.HEC_DIA_Diagnosis_LocalizationID,
    hec_dia_diagnosis_localizations.DiagnosisLocalization_Name_DictID,
    hec_dia_potentialdiagnoses.ICD10_Code,
    hec_dia_diagnosis_states.HEC_DIA_Diagnosis_StateID,
    hec_dia_diagnosis_states.DiagnosisState_Abbreviation,
    hec_dia_diagnosis_states.DiagnosisState_Name_DictID,
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID,
    cmn_per_personinfo.FirstName As DoctorFirstName,
    cmn_per_personinfo.LastName As DoctorLastName,
    hec_patient_treatment_relevantdiagnoses.Creation_Timestamp As Creation_Date,
    hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
    hec_patient_treatment_relevantdiagnoses.DiagnosedOnDate
  From
    hec_patient_treatment_relevantdiagnoses Inner Join
    hec_patient_treatment_relevantdiagnosis_localizations
      On
      hec_patient_treatment_relevantdiagnosis_localizations.HEC_Patient_Treatment_RelevantDiagnoses_RefID = hec_patient_treatment_relevantdiagnoses.HEC_Patient_Treatment_RelevantDiagnosisID Inner Join
    hec_dia_diagnosis_localizations
      On
      hec_patient_treatment_relevantdiagnosis_localizations.HEC_DIA_Diagnosis_Localization_RefID = hec_dia_diagnosis_localizations.HEC_DIA_Diagnosis_LocalizationID Inner Join
    hec_dia_potentialdiagnoses
      On hec_patient_treatment_relevantdiagnoses.DIA_PotentialDiagnosis_RefID =
      hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID Inner Join
    hec_dia_diagnosis_states
      On hec_patient_treatment_relevantdiagnoses.DIA_State_RefID =
      hec_dia_diagnosis_states.HEC_DIA_Diagnosis_StateID Inner Join
    hec_doctors On hec_patient_treatment_relevantdiagnoses.Doctor_RefID =
      hec_doctors.HEC_DoctorID Inner Join
    cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
    cmn_per_personinfo
      On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
      cmn_per_personinfo.CMN_PER_PersonInfoID
  Where
    hec_patient_treatment_relevantdiagnosis_localizations.IsDeleted = 0 And
    hec_patient_treatment_relevantdiagnoses.IsDeleted = 0 And
    hec_dia_diagnosis_states.IsDeleted = 0 And
    hec_dia_potentialdiagnoses.IsDeleted = 0 And
    hec_dia_diagnosis_localizations.IsDeleted = 0 And
    hec_patient_treatment_relevantdiagnoses.Tenant_RefID = @TenantID And
    hec_doctors.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_per_personinfo.IsDeleted = 0) RelevantDiagnosis
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    RelevantDiagnosis.Patient_Treatment_RefID Left Join
  hec_patient_treatment_ocularextension
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_treatment_ocularextension.HEC_Patient_Treatment_RefID And
    hec_patient_treatment_ocularextension.IsDeleted = 0 Left Join
  (Select
    cmn_pro_products.Product_Name_DictID,
    cmn_pro_products.Product_Number,
    hec_patient_treatment_requiredproducts.Quantity,
    hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID,
    cmn_pro_products.CMN_PRO_ProductID
  From
    hec_patient_treatment_requiredproducts Inner Join
    hec_products On hec_patient_treatment_requiredproducts.HEC_Product_RefID =
      hec_products.HEC_ProductID Inner Join
    cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
      cmn_pro_products.CMN_PRO_ProductID
  Where
    cmn_pro_products.IsDeleted = 0 And
    hec_products.IsDeleted = 0 And
    hec_patient_treatment_requiredproducts.IsDeleted = 0) Articles
    On Articles.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID Left Join
  (Select
    bil_billposition_transmitionstatuses.BillPosition_RefID,
    Max(bil_billposition_transmitionstatuses.TransmitionCode) As TransmitionCode
  From
    bil_billposition_transmitionstatuses
  Where
    bil_billposition_transmitionstatuses.IsDeleted = 0  And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID
  Group By
    bil_billposition_transmitionstatuses.BillPosition_RefID) PerformedStatus
    On PerformedStatus.BillPosition_RefID =
    bil_billposition_2_patienttreatment.BIL_BillPosition_RefID
Where
  hec_patient_treatment.HEC_Patient_TreatmentID = @TreatmentID And
  hec_patient_treatment.IsDeleted = 0 And
  hec_patient_treatment.Tenant_RefID = @TenantID
  
  