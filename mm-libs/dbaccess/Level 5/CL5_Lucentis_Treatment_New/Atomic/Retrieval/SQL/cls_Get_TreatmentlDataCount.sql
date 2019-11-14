
Select
COUNT(treatment.HEC_Patient_TreatmentID) as total_record_count
From
  hec_patient_treatment treatment Inner Join 
  hec_patient_2_patienttreatment On treatment.HEC_Patient_TreatmentID =
    hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID And
    hec_patient_2_patienttreatment.IsDeleted = 0 And
    hec_patient_2_patienttreatment.Tenant_RefID =
    @TenantID Inner Join
  hec_patients On hec_patient_2_patienttreatment.HEC_Patient_RefID =
    hec_patients.HEC_PatientID And hec_patients.IsDeleted = 0 And
    hec_patients.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID =
    @TenantID Inner Join
  cmn_per_personinfo patient_personInfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    patient_personInfo.CMN_PER_PersonInfoID And patient_personInfo.IsDeleted = 0
    And patient_personInfo.Tenant_RefID = @TenantID @s_Patient
  Inner Join
  hec_patient_healthinsurances On hec_patient_healthinsurances.Patient_RefID =
    hec_patients.HEC_PatientID And hec_patient_healthinsurances.IsDeleted = 0
    And hec_patient_healthinsurances.Tenant_RefID =
    @TenantID Inner Join
  hec_his_healthinsurance_companies
    On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID =
    hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
    hec_his_healthinsurance_companies.IsDeleted = 0 And
    hec_his_healthinsurance_companies.Tenant_RefID =
    @TenantID Inner Join
  cmn_bpt_businessparticipants healthInsurance_bussinessParticipant
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    healthInsurance_bussinessParticipant.CMN_BPT_BusinessParticipantID
    And healthInsurance_bussinessParticipant.IsDeleted = 0 And
    healthInsurance_bussinessParticipant.Tenant_RefID =
    @TenantID @s_HealthInsurance And
    healthInsurance_bussinessParticipant.IsNaturalPerson = 0 And
    healthInsurance_bussinessParticipant.IsCompany = 1 Inner Join
  hec_doctors scheduledDoctor On treatment.IfSheduled_ForDoctor_RefID =
    scheduledDoctor.HEC_DoctorID And scheduledDoctor.Tenant_RefID =
    @TenantID And scheduledDoctor.IsDeleted = 0
  Inner Join
  cmn_bpt_businessparticipants scheduledDoctor_businessparticipant
    On scheduledDoctor_businessparticipant.CMN_BPT_BusinessParticipantID =
    scheduledDoctor.BusinessParticipant_RefID And
    scheduledDoctor_businessparticipant.IsCompany = 0 And
    scheduledDoctor_businessparticipant.IsNaturalPerson = 1 And
    scheduledDoctor_businessparticipant.IsDeleted = 0 And
    scheduledDoctor_businessparticipant.Tenant_RefID =
    @TenantID Inner Join
  cmn_per_personinfo scheduledDoctor_personinfo
    On
    scheduledDoctor_businessparticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID
    = scheduledDoctor_personinfo.CMN_PER_PersonInfoID And
    scheduledDoctor_personinfo.IsDeleted = 0 And
    scheduledDoctor_personinfo.Tenant_RefID =
    @TenantID     Inner Join
  hec_medicalpractises On hec_medicalpractises.HEC_MedicalPractiseID =
    treatment.TreatmentPractice_RefID And hec_medicalpractises.IsDeleted = 0 And
    hec_medicalpractises.Tenant_RefID = @TenantID 
  Inner Join
  cmn_bpt_businessparticipants medical_practice 
    On medical_practice.IfCompany_CMN_COM_CompanyInfo_RefID =
    hec_medicalpractises.Ext_CompanyInfo_RefID  And
  medical_practice.Tenant_RefID = @TenantID @S_Practice And
  medical_practice.IsDeleted = 0 Left Join
  hec_doctors performed_doctor On treatment.IfTreatmentPerformed_ByDoctor_RefID
    = performed_doctor.HEC_DoctorID And performed_doctor.IsDeleted = 0
    And performed_doctor.Tenant_RefID = @TenantID
  Left Join
  cmn_bpt_businessparticipants performed_doctor_businessparticipant
    On performed_doctor.BusinessParticipant_RefID =
    performed_doctor_businessparticipant.CMN_BPT_BusinessParticipantID
    And performed_doctor_businessparticipant.IsCompany = 0 And
    performed_doctor_businessparticipant.IsNaturalPerson = 1 And
    performed_doctor_businessparticipant.IsDeleted = 0 And
    performed_doctor_businessparticipant.Tenant_RefID =
    @TenantID Left Join
  cmn_per_personinfo performed_doctor_personinfo
    On
    performed_doctor_businessparticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = performed_doctor_personinfo.CMN_PER_PersonInfoID And
    performed_doctor_personinfo.IsDeleted = 0 And performed_doctor_personinfo.Tenant_RefID = @TenantID

Where
  treatment.IsDeleted = 0 And
  treatment.Tenant_RefID = @TenantID @statusParameters   
  
  