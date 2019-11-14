Select
  hec_patient_treatment.IsTreatmentPerformed,
  hec_patient_treatment.IfTreatmentPerformed_Date,
  MedicalPractice_cmn_bpt_businessparticipants.DisplayName,
  DoctorPerformed.DoctorLastname,
  DoctorPerformed.DoctorTitle,
  DoctorPerformed.DoctorFirstName,
  hec_patient_treatment.HEC_Patient_TreatmentID,
  hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID,
  hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID,
  hec_patient_treatment.IsScheduled,
  hec_patient_treatment.IfSheduled_Date,
  hec_patient_treatment.IsTreatmentBilled,
  hec_patient_treatment.IfTreatmentBilled_Date
From
  hec_patient_treatment Inner Join
  hec_medicalpractises On hec_patient_treatment.TreatmentPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID Inner Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_bpt_businessparticipants MedicalPractice_cmn_bpt_businessparticipants
    On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    MedicalPractice_cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID Left Join
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
    On hec_patient_treatment.IfSheduled_ForDoctor_RefID =
    DoctorPerformed.HEC_DoctorID
Where
  hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID = @TreatmentIDs
  And
  hec_patient_treatment.IsTreatmentFollowup = 1 And
  hec_patient_treatment.IsDeleted = 0 And
  hec_medicalpractises.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  MedicalPractice_cmn_bpt_businessparticipants.IsCompany = 1 And
  MedicalPractice_cmn_bpt_businessparticipants.IsNaturalPerson = 0 And
  MedicalPractice_cmn_bpt_businessparticipants.IsDeleted = 0 And
  MedicalPractice_cmn_bpt_businessparticipants.IsTenant = 0