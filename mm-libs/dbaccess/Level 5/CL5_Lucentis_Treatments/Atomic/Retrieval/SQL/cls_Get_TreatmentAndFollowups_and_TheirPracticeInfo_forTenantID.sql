
	Select
  followup.TreatmentPractice_RefID As followup_practiceID,
  treatment.TreatmentPractice_RefID,
  treatment.IfSheduled_Date,
  treatment.IfTreatmentPerformed_Date,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_bpt_businessparticipants1.DisplayName As TreatmentPracticeName
From
  hec_patient_treatment treatment Inner Join
  hec_patient_treatment followup On treatment.HEC_Patient_TreatmentID =
    followup.IfTreatmentFollowup_FromTreatment_RefID And
    followup.IsTreatmentFollowup = 1 And followup.IsDeleted = 0 And
    followup.Tenant_RefID = @TenantID Inner Join
  hec_patient_2_patienttreatment
    On hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID =
    treatment.HEC_Patient_TreatmentID Inner Join
  hec_patients On hec_patient_2_patienttreatment.HEC_Patient_RefID =
    hec_patients.HEC_PatientID And hec_patients.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    hec_patients.CMN_BPT_BusinessParticipant_RefID Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Inner Join
  hec_medicalpractises On treatment.TreatmentPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID Inner Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On cmn_bpt_businessparticipants1.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID
Where
  treatment.IsTreatmentFollowup = 0 And
  treatment.IsDeleted = 0 And
  treatment.Tenant_RefID = @TenantID
  