
Select
  hec_patient_treatment.HEC_Patient_TreatmentID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  hec_patient_treatment.IsTreatmentBilled,
  hec_patient_treatment.IsScheduled,
  hec_patient_treatment.IfSheduled_Date,
  hec_patient_treatment.IfTreatmentBilled_Date,
  hec_patient_treatment.IsTreatmentFollowup,
  hec_patient_treatment.IsTreatmentPerformed,
  hec_patient_treatment.IfTreatmentPerformed_Date,
  MedicalPractice_cmn_bpt_businessparticipants.DisplayName,
  hec_patient_treatment.Tenant_RefID,
  DoctorPerformed.DoctorFirstName,
  DoctorPerformed.DoctorLastname,
  DoctorPerformed.DoctorTitle,
  Doctor.DoctorFirstNameScheduled,
  Doctor.DoctorLastnameScheduled,
  Doctor.DoctorTitleScheduled,
  cmn_bpt_businessparticipants1.DisplayName As CompanyName
From
  hec_patient_treatment Left Join
  hec_patient_2_patienttreatment
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID Inner Join
  hec_patients
    On hec_patients.HEC_PatientID =
    hec_patient_2_patienttreatment.HEC_Patient_RefID Inner Join
  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  hec_medicalpractises On hec_patient_treatment.TreatmentPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID Inner Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_bpt_businessparticipants MedicalPractice_cmn_bpt_businessparticipants
    On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    MedicalPractice_cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID Inner Join
  hec_patient_healthinsurances On hec_patients.HEC_PatientID =
    hec_patient_healthinsurances.Patient_RefID Inner Join
  hec_his_healthinsurance_companies
    On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID =
    hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID Left Join
  (Select
    cmn_per_personinfo.FirstName As DoctorFirstNameScheduled,
    cmn_per_personinfo.LastName As DoctorLastnameScheduled,
    cmn_per_personinfo.Title As DoctorTitleScheduled,
    hec_doctors.HEC_DoctorID
  From
    cmn_per_personinfo Inner Join
    cmn_bpt_businessparticipants On cmn_per_personinfo.CMN_PER_PersonInfoID =
      cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
    Inner Join
    hec_doctors On hec_doctors.BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
  Where
    cmn_per_personinfo.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsTenant = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    hec_doctors.IsDeleted = 0) Doctor
    On hec_patient_treatment.IfSheduled_ForDoctor_RefID = Doctor.HEC_DoctorID
  Left Join
  (Select
    cmn_per_personinfo.FirstName As DoctorFirstName,
    cmn_per_personinfo.LastName As DoctorLastname,
    cmn_per_personinfo.Title As DoctorTitle,
    hec_doctors.HEC_DoctorID
  From
    cmn_per_personinfo Inner Join
    cmn_bpt_businessparticipants On cmn_per_personinfo.CMN_PER_PersonInfoID =
      cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
    Inner Join
    hec_doctors On hec_doctors.BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
  Where
    cmn_per_personinfo.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsTenant = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    hec_doctors.IsDeleted = 0) DoctorPerformed
    On hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID =
    DoctorPerformed.HEC_DoctorID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID
Where
  hec_patient_treatment.IsTreatmentFollowup = 0 And
  hec_patient_treatment.Tenant_RefID = @TenantID And
  hec_patients.IsDeleted = 0 And
  hec_patient_2_patienttreatment.IsDeleted = 0 And
  hec_patient_treatment.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsTenant = 0 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  hec_medicalpractises.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  MedicalPractice_cmn_bpt_businessparticipants.IsCompany = 1 And
  MedicalPractice_cmn_bpt_businessparticipants.IsNaturalPerson = 0 And
  MedicalPractice_cmn_bpt_businessparticipants.IsDeleted = 0 And
  MedicalPractice_cmn_bpt_businessparticipants.IsTenant = 0 And
  hec_his_healthinsurance_companies.IsDeleted = 0 And
  hec_patient_healthinsurances.IsDeleted = 0 And
  cmn_bpt_businessparticipants1.IsCompany = 1 And
  cmn_bpt_businessparticipants1.IsDeleted = 0
  