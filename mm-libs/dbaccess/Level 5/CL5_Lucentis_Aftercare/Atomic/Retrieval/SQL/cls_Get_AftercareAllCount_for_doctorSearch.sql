
Select
  COUNT(Followup.HEC_Patient_TreatmentID) As total_record_count
From
  cmn_bpt_businessparticipants MedicalPractice Inner Join
  hec_medicalpractises On MedicalPractice.IfCompany_CMN_COM_CompanyInfo_RefID =
    hec_medicalpractises.Ext_CompanyInfo_RefID And
    hec_medicalpractises.Tenant_RefID = @TenantID And
    hec_medicalpractises.IsDeleted = 0 Inner Join
  hec_patient_treatment Followup On Followup.TreatmentPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID And
    Followup.IsTreatmentFollowup = 1 And Followup.Tenant_RefID =
    @TenantID @statusParameters
    And Followup.IsDeleted = 0 Inner Join
  hec_doctors On Followup.IfTreatmentPerformed_ByDoctor_RefID =
    hec_doctors.HEC_DoctorID And hec_doctors.IsDeleted = 0 And
    hec_doctors.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID =
    @TenantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID @s_doctorParam
  Inner Join
  hec_doctors ScheduledDoctor On Followup.IfSheduled_ForDoctor_RefID =
    ScheduledDoctor.HEC_DoctorID And ScheduledDoctor.IsDeleted = 0 And
    ScheduledDoctor.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants SheduledDoctor_Businessparticipants
    On ScheduledDoctor.BusinessParticipant_RefID =
    SheduledDoctor_Businessparticipants.CMN_BPT_BusinessParticipantID And
    SheduledDoctor_Businessparticipants.IsNaturalPerson = 1 And
    SheduledDoctor_Businessparticipants.IsCompany = 0 And
    SheduledDoctor_Businessparticipants.IsDeleted = 0 And 
    SheduledDoctor_Businessparticipants.Tenant_RefID =
    @TenantID  Inner Join
  cmn_per_personinfo ScheduledDoctor_PersonInfo
    On
    SheduledDoctor_Businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
    = ScheduledDoctor_PersonInfo.CMN_PER_PersonInfoID And
    ScheduledDoctor_PersonInfo.Tenant_RefID =
    @TenantID @s_scheduled_doctorParam And ScheduledDoctor_PersonInfo.IsDeleted
    = 0 Inner Join
  hec_patient_treatment Treatment On Treatment.HEC_Patient_TreatmentID =
    Followup.IfTreatmentFollowup_FromTreatment_RefID And
    Treatment.IsTreatmentFollowup = 0 And Treatment.IsDeleted = 0 And
    Treatment.Tenant_RefID = @TenantID Inner Join
  hec_patient_2_patienttreatment
    On hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID =
    Treatment.HEC_Patient_TreatmentID And
    hec_patient_2_patienttreatment.IsDeleted = 0 And
    hec_patient_2_patienttreatment.Tenant_RefID =
    @TenantID Inner Join
  hec_patients
    On hec_patients.HEC_PatientID =
    hec_patient_2_patienttreatment.HEC_Patient_RefID And
    hec_patients.IsDeleted = 0 And hec_patients.Tenant_RefID =
    @TenantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On hec_patients.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants1.IsCompany = 0 And
    cmn_bpt_businessparticipants1.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants1.IsDeleted = 0 And
    cmn_bpt_businessparticipants1.Tenant_RefID =
    @TenantID Inner Join
  cmn_per_personinfo cmn_per_personinfo1
    On cmn_bpt_businessparticipants1.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo1.CMN_PER_PersonInfoID And cmn_per_personinfo1.IsDeleted =
    0 And cmn_per_personinfo1.Tenant_RefID = @TenantID @s_Patient
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
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants2
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants2.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants2.IsNaturalPerson = 0 And
    cmn_bpt_businessparticipants2.IsCompany = 1 And
    cmn_bpt_businessparticipants2.IsDeleted = 0 And
    cmn_bpt_businessparticipants2.Tenant_RefID =
    @TenantID @s_HealthInsurance
Where
  MedicalPractice.IsCompany = 1 And
  MedicalPractice.IsNaturalPerson = 0 And
  MedicalPractice.IsDeleted = 0 And
  MedicalPractice.Tenant_RefID = @TenantID @S_Practice
  