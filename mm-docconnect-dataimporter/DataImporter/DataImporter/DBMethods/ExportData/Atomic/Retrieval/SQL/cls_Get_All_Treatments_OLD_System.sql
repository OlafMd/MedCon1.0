
Select
  hec_patient_treatment.HEC_Patient_TreatmentID,
  hec_patient_treatment.IsScheduled As isTreatmentScheduled,
  hec_patient_treatment.IsTreatmentBilled As isTreatmentBilled,
  hec_patient_treatment.IfSheduled_Date As treatmentScheduledDate,
  hec_patient_treatment.IfTreatmentPerformed_Date As treatmentPerformedDate,
  hec_patient_treatment.IsTreatmentPerformed As isTreatmentPerformed,
  cmn_per_personinfo.FirstName As PatientFirstName,
  cmn_per_personinfo.LastName As PatientLastName,
  hec_patient_healthinsurances.HealthInsurance_Number,
  performed_hec_doctors.DoctorIDNumber As OPperformedDoctorLANR,
  performed_doctor_cmn_per_personinfo.FirstName As OPperformedDoctorFirstName,
  performed_doctor_cmn_per_personinfo.LastName As OPperformedDoctorLastName,
  ac_scheduled_hec_doctor.DoctorIDNumber As OPscheduledDoctorLANR,
  ac_scheduled_cmn_per_personinfo.FirstName As OPScheduledDoctorFirstName,
  ac_scheduled_cmn_per_personinfo.LastName As OPScheduledDoctorLastName,
  hec_patient_treatment_ocularextension.IsTreatmentOfLeftEye,
  hec_patient_treatment_ocularextension.IsTreatmentOfRightEye,
  hec_dia_potentialdiagnoses.ICD10_Code,
  cmn_pro_products.Product_Number As PZN,
  cmn_pro_products_de.Content As ArticleName,
  hec_patient_treatment_relevantdiagnoses.HEC_Patient_Treatment_RelevantDiagnosisID As diagnnoseID,
  hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RequiredProductID,
  cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As BSNR,
  cmn_bpt_businessparticipants.DisplayName As PracticeName,
  hec_patient_treatment_relevantdiagnoses.DiagnosedOnDate
From
  hec_patient_treatment Inner Join
  hec_patient_2_patienttreatment
    On hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    hec_patient_2_patienttreatment.IsDeleted = 0 And
    hec_patient_2_patienttreatment.Tenant_RefID = @TenantID Inner Join
  hec_patients On hec_patient_2_patienttreatment.HEC_Patient_RefID =
    hec_patients.HEC_PatientID And hec_patients.IsDeleted = 0 And
    hec_patients.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants patient_cmn_bpt_businessparticipants
    On hec_patients.CMN_BPT_BusinessParticipant_RefID =
    patient_cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
    And patient_cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    patient_cmn_bpt_businessparticipants.IsCompany = 0 And
    patient_cmn_bpt_businessparticipants.IsDeleted = 0 And
    patient_cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    patient_cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID And cmn_per_personinfo.Tenant_RefID = @TenantID And cmn_per_personinfo.IsDeleted = 0 Inner Join
  hec_patient_healthinsurances On hec_patients.HEC_PatientID =
    hec_patient_healthinsurances.Patient_RefID And
    hec_patient_healthinsurances.Tenant_RefID = @TenantID And
    hec_patient_healthinsurances.IsDeleted = 0 Left Join
  hec_doctors performed_hec_doctors
    On hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID =
    performed_hec_doctors.HEC_DoctorID And performed_hec_doctors.IsDeleted = 0
    And performed_hec_doctors.Tenant_RefID = @TenantID Left Join
  cmn_bpt_businessparticipants performed_doctor_cmn_bpt_businessparticipants
    On performed_hec_doctors.BusinessParticipant_RefID =
    performed_doctor_cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
    And performed_doctor_cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    performed_doctor_cmn_bpt_businessparticipants.IsCompany = 0 And
    performed_doctor_cmn_bpt_businessparticipants.IsDeleted = 0 And
    performed_doctor_cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
  Left Join
  cmn_per_personinfo performed_doctor_cmn_per_personinfo
    On
    performed_doctor_cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = performed_doctor_cmn_per_personinfo.CMN_PER_PersonInfoID And performed_doctor_cmn_per_personinfo.Tenant_RefID = @TenantID And performed_doctor_cmn_per_personinfo.IsDeleted = 0 Left Join
  hec_doctors ac_scheduled_hec_doctor
    On hec_patient_treatment.IfSheduled_ForDoctor_RefID =
    ac_scheduled_hec_doctor.HEC_DoctorID And ac_scheduled_hec_doctor.IsDeleted =
    0 And ac_scheduled_hec_doctor.Tenant_RefID = @TenantID Left Join
  cmn_bpt_businessparticipants ac_scheduled_cmn_bpt_businessparticipants
    On ac_scheduled_hec_doctor.BusinessParticipant_RefID =
    ac_scheduled_cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    ac_scheduled_cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    ac_scheduled_cmn_bpt_businessparticipants.IsCompany = 0 And
    ac_scheduled_cmn_bpt_businessparticipants.IsDeleted = 0 And
    ac_scheduled_cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Left Join
  cmn_per_personinfo ac_scheduled_cmn_per_personinfo
    On
    ac_scheduled_cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = ac_scheduled_cmn_per_personinfo.CMN_PER_PersonInfoID And ac_scheduled_cmn_per_personinfo.IsDeleted = 0 And ac_scheduled_cmn_per_personinfo.Tenant_RefID = @TenantID Left Join
  hec_patient_treatment_ocularextension
    On hec_patient_treatment_ocularextension.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    hec_patient_treatment_ocularextension.IsDeleted = 0 And
    hec_patient_treatment_ocularextension.Tenant_RefID = @TenantID Left Join
  hec_patient_treatment_relevantdiagnoses
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_treatment_relevantdiagnoses.Patient_Treatment_RefID And
    hec_patient_treatment_relevantdiagnoses.IsDeleted = 0 And
    hec_patient_treatment_relevantdiagnoses.Tenant_RefID = @TenantID Left Join
  hec_dia_potentialdiagnoses
    On hec_patient_treatment_relevantdiagnoses.DIA_PotentialDiagnosis_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
    hec_dia_potentialdiagnoses.IsDeleted = 0 And
    hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID Left Join
  hec_patient_treatment_requiredproducts
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID
    And hec_patient_treatment_requiredproducts.IsDeleted = 0 And
    hec_patient_treatment_requiredproducts.Tenant_RefID = @TenantID Left Join
  hec_products On hec_patient_treatment_requiredproducts.HEC_Product_RefID =
    hec_products.HEC_ProductID And hec_products.Tenant_RefID = @TenantID And
    hec_products.IsDeleted = 0 Left Join
  cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.IsDeleted = 0 And
    cmn_pro_products.Tenant_RefID = @TenantID Left Join
  cmn_pro_products_de On cmn_pro_products.Product_Name_DictID =
    cmn_pro_products_de.DictID And cmn_pro_products_de.IsDeleted = 0 Inner Join
  hec_medicalpractises On hec_patient_treatment.TreatmentPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID And
    hec_medicalpractises.IsDeleted = 0 And hec_medicalpractises.Tenant_RefID =
    @TenantID Inner Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted
    = 0 And cmn_com_companyinfo.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And
    cmn_bpt_businessparticipants.IsCompany = 1 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
Where
  hec_patient_treatment.IsDeleted = 0 And
  hec_patient_treatment.Tenant_RefID = @TenantID And
  hec_patient_treatment.IsTreatmentFollowup = 0
  