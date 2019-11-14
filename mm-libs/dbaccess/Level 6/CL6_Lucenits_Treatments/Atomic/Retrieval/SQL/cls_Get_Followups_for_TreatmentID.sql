
Select
  hec_patient_treatment_followups.IsTreatmentPerformed,
  hec_patient_treatment_followups.IfTreatmentPerformed_Date,
  hec_patient_treatment_followups.IsScheduled,
  hec_patient_treatment_followups.IfSheduled_Date,
  hec_patient_treatment_followups.HEC_Patient_TreatmentID,
  hec_patient_treatment_followups.TreatmentPractice_RefID,
  hec_patient_treatment_followups.IfTreatmentPerformed_ByDoctor_RefID,
  hec_patient_treatment_followups.Treatment_Comment,
  PerforemdInPractice.PracticeName,
  PerformedByDoctor.HEC_DoctorID,
  PerformedByDoctor.FirstName,
  PerformedByDoctor.LastName,
  PerformedByDoctor.Title,
  hec_patient_treatment_followups.IsTreatmentBilled,
  hec_patient_treatment_followups.IfTreatmentBilled_Date,
  ScheduledByDoctor.DoctorFirstNameScheduled,
  ScheduledByDoctor.DoctorLastnameScheduled,
  ScheduledByDoctor.DoctorTitleScheduled,
  ScheduledByDoctor.ScheduledDoctorID
From
  hec_patient_treatment hec_patient_treatment_followups Inner Join
  hec_patient_treatment
    On hec_patient_treatment_followups.IfTreatmentFollowup_FromTreatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID Left Join
  (Select
    cmn_bpt_businessparticipants.DisplayName As PracticeName,
    hec_medicalpractises.HEC_MedicalPractiseID As PracticeID
  From
    cmn_com_companyinfo Inner Join
    cmn_bpt_businessparticipants
      On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
      cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
    hec_medicalpractises On hec_medicalpractises.Ext_CompanyInfo_RefID =
      cmn_com_companyinfo.CMN_COM_CompanyInfoID
  Where
    cmn_com_companyinfo.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    hec_medicalpractises.IsDeleted = 0 And
    hec_medicalpractises.Tenant_RefID = @TenantID) PerforemdInPractice
    On hec_patient_treatment_followups.TreatmentPractice_RefID =
    PerforemdInPractice.PracticeID Left Join
  (Select
    hec_doctors.HEC_DoctorID,
    cmn_per_personinfo.FirstName,
    cmn_per_personinfo.LastName,
    cmn_per_personinfo.Title
  From
    hec_doctors Inner Join
    cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
    cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
      cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Where
    hec_doctors.IsDeleted = 0 And
    hec_doctors.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_per_personinfo.IsDeleted = 0) PerformedByDoctor
    On PerformedByDoctor.HEC_DoctorID =
    hec_patient_treatment_followups.IfTreatmentPerformed_ByDoctor_RefID
  Left Join
  (Select
    cmn_per_personinfo.FirstName As DoctorFirstNameScheduled,
    cmn_per_personinfo.LastName As DoctorLastnameScheduled,
    cmn_per_personinfo.Title As DoctorTitleScheduled,
    hec_doctors.HEC_DoctorID As ScheduledDoctorID
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
    hec_doctors.IsDeleted = 0) ScheduledByDoctor
    On hec_patient_treatment_followups.IfSheduled_ForDoctor_RefID =
    ScheduledByDoctor.ScheduledDoctorID
Where
  hec_patient_treatment_followups.IsDeleted = 0 And
  hec_patient_treatment.IsDeleted = 0 And
  hec_patient_treatment_followups.IsTreatmentFollowup = 1 And
  hec_patient_treatment.HEC_Patient_TreatmentID = @TreatmentID And
  hec_patient_treatment.IsTreatmentFollowup = 0
  