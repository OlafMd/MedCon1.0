
Select
  hec_patients.HEC_PatientID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  Treatments.ExpectedDateOfDelivery,
  Treatments.Product_Name_DictID,
  Treatments.IfSheduled_Date,
  Treatments.HEC_Patient_TreatmentID,
  Treatments.HEC_Patient_RefID,
  Treatments.HEC_ProductID,
  Treatments.IsTreatmentFollowup,
  Treatments.FollowUp_HEC_Patient_TreatmentID,
  Treatments.IsTreatmentFollowupFollowUP,
  Treatments.FollowUp_IfSheduled_Date,
  Treatments.TreatmentPractice_RefID,
  cmn_per_personinfo.BirthDate,
  Treatments.FollowUp_PracticeID,
  hec_patient_medicalpractices.HEC_MedicalPractices_RefID As PracticeID
From
  hec_patients Inner Join
  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Left Join
  (Select
    hec_patient_treatment.HEC_Patient_TreatmentID,
    hec_patient_treatment.IsTreatmentFollowup,
    hec_patient_treatment.IfSheduled_Date,
    Articles.Product_Name_DictID,
    Articles.ExpectedDateOfDelivery,
    hec_patient_2_patienttreatment.HEC_Patient_RefID,
    Articles.HEC_ProductID,
    FollowUp.IsTreatmentFollowupFollowUP,
    FollowUp.FollowUp_IfSheduled_Date,
    FollowUp.FollowUp_HEC_Patient_TreatmentID,
    hec_patient_treatment.TreatmentPractice_RefID,
    FollowUp.TreatmentPractice_RefID As FollowUp_PracticeID
  From
    hec_patient_2_patienttreatment Inner Join
    hec_patient_treatment
      On hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID =
      hec_patient_treatment.HEC_Patient_TreatmentID Left Join
    (Select
      cmn_pro_products.Product_Name_DictID,
      hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID,
      hec_patient_treatment_requiredproducts.ExpectedDateOfDelivery,
      hec_products.HEC_ProductID
    From
      hec_products Inner Join
      hec_patient_treatment_requiredproducts
        On hec_patient_treatment_requiredproducts.HEC_Product_RefID =
        hec_products.HEC_ProductID Inner Join
      cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
        cmn_pro_products.CMN_PRO_ProductID
    Where
      cmn_pro_products.IsDeleted = 0 And
      hec_products.IsDeleted = 0 And
      hec_patient_treatment_requiredproducts.IsDeleted = 0) Articles
      On hec_patient_treatment.HEC_Patient_TreatmentID =
      Articles.HEC_Patient_Treatment_RefID Left Join
    (Select
      hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID,
      hec_patient_treatment.HEC_Patient_TreatmentID As
      FollowUp_HEC_Patient_TreatmentID,
      hec_patient_treatment.IfSheduled_Date As FollowUp_IfSheduled_Date,
      hec_patient_treatment.IsTreatmentFollowup As IsTreatmentFollowupFollowUP,
      hec_patient_treatment.TreatmentPractice_RefID
    From
      hec_patient_treatment
    Where
      hec_patient_treatment.IsTreatmentFollowup = 1 And
      hec_patient_treatment.IsDeleted = 0) FollowUp
      On hec_patient_treatment.HEC_Patient_TreatmentID =
      FollowUp.IfTreatmentFollowup_FromTreatment_RefID
  Where
    (hec_patient_treatment.IsTreatmentFollowup = 0 And
    hec_patient_2_patienttreatment.IsDeleted = 0 And
    hec_patient_treatment.IsDeleted = 0) Or
    (hec_patient_treatment.IsTreatmentFollowup = 0 And
    hec_patient_2_patienttreatment.IsDeleted = 0 And
    hec_patient_treatment.IsDeleted = 0)) Treatments
    On hec_patients.HEC_PatientID = Treatments.HEC_Patient_RefID Inner Join
  hec_patient_medicalpractices On hec_patient_medicalpractices.HEC_Patient_RefID
    = hec_patients.HEC_PatientID
Where
  hec_patients.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  hec_patients.Tenant_RefID = @TenantID And
  hec_patient_medicalpractices.IsDeleted = 0 And
  hec_patient_medicalpractices.HEC_MedicalPractices_RefID = @PracticeID
  