
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  hec_patient_treatment.IsTreatmentBilled,
  hec_patient_treatment.IsScheduled,
  hec_patient_treatment.IfSheduled_Date,
  hec_patient_treatment.IfTreatmentBilled_Date,
  hec_patient_treatment.IsTreatmentFollowup,
  hec_patient_treatment.IsTreatmentPerformed,
  hec_patient_treatment.IfTreatmentPerformed_Date,
  FollowUps.DisplayName,
  FollowUps.IfTreatmentPerformed_Date As IfTreatmentPerformed_Date1,
  FollowUps.IsTreatmentPerformed As IsTreatmentPerformed1,
  FollowUps.IsTreatmentFollowup As IsTreatmentFollowup1,
  FollowUps.IfTreatmentBilled_Date As IfTreatmentBilled_Date1,
  FollowUps.IfSheduled_Date As IfSheduled_Date1,
  FollowUps.IsScheduled As IsScheduled1,
  FollowUps.IsTreatmentBilled As IsTreatmentBilled1,
  FollowUps.DoctorLastname,
  FollowUps.DoctorTitle,
  FollowUps.DoctorFirstName,
  hec_patient_treatment.HEC_Patient_TreatmentID,
  FollowUps.HEC_Patient_TreatmentID As HEC_Patient_TreatmentID1,
  hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID,
  FollowUps.IfTreatmentPerformed_ByDoctor_RefID As
  IfTreatmentPerformed_ByDoctor_RefID1,
  FollowUps.ScheduledDoctor_FName,
  FollowUps.ScheduledDoctor_title,
  FollowUps.ScheduledDoctor_LName
From
  hec_patient_treatment Inner Join
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
    cmn_per_personinfo.CMN_PER_PersonInfoID Left Join
  (Select
    hec_patient_treatment.IsTreatmentBilled,
    hec_patient_treatment.IsScheduled,
    hec_patient_treatment.IfSheduled_Date,
    hec_patient_treatment.IfTreatmentBilled_Date,
    hec_patient_treatment.IsTreatmentFollowup,
    hec_patient_treatment.IsTreatmentPerformed,
    hec_patient_treatment.IfTreatmentPerformed_Date,
    MedicalPractice_cmn_bpt_businessparticipants.DisplayName,
    hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID,
    DoctorPerformed.DoctorLastname,
    DoctorPerformed.DoctorTitle,
    DoctorPerformed.DoctorFirstName,
    hec_patient_treatment.HEC_Patient_TreatmentID,
    hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID,
    ScheduledDoctor.ScheduledDoctor_FName,
    ScheduledDoctor.ScheduledDoctor_LName,
    ScheduledDoctor.ScheduledDoctor_title
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
      On hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID =
      DoctorPerformed.HEC_DoctorID Left Join
    (Select
      hec_doctors.HEC_DoctorID,
      cmn_per_personinfo.FirstName As ScheduledDoctor_FName,
      cmn_per_personinfo.LastName As ScheduledDoctor_LName,
      cmn_per_personinfo.Title As ScheduledDoctor_title
    From
      hec_doctors Inner Join
      cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
        cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
      cmn_per_personinfo
        On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
        = cmn_per_personinfo.CMN_PER_PersonInfoID
    Where
      cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
      hec_doctors.IsDeleted = 0 And
      cmn_bpt_businessparticipants.IsDeleted = 0 And
      cmn_per_personinfo.IsDeleted = 0) ScheduledDoctor
      On hec_patient_treatment.IfSheduled_ForDoctor_RefID =
      ScheduledDoctor.HEC_DoctorID
  Where
    hec_patient_treatment.IsTreatmentFollowup = 1 And
    hec_patient_treatment.HEC_Patient_TreatmentID = @TreatmentID And
    hec_patient_treatment.IsDeleted = 0 And
    hec_medicalpractises.IsDeleted = 0 And
    cmn_com_companyinfo.IsDeleted = 0 And
    MedicalPractice_cmn_bpt_businessparticipants.IsCompany = 1 And
    MedicalPractice_cmn_bpt_businessparticipants.IsNaturalPerson = 0 And
    MedicalPractice_cmn_bpt_businessparticipants.IsDeleted = 0 And
    MedicalPractice_cmn_bpt_businessparticipants.IsTenant = 0) FollowUps
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    FollowUps.IfTreatmentFollowup_FromTreatment_RefID
Where
  hec_patient_treatment.IsTreatmentFollowup = 0 And
  hec_patients.IsDeleted = 0 And
  hec_patient_2_patienttreatment.IsDeleted = 0 And
  hec_patient_treatment.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsTenant = 0 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1
  