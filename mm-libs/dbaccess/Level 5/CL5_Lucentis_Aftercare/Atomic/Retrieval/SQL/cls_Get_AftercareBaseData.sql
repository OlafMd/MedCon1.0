Select
  MedicalPractice.DisplayName As Practice,
  Followup.HEC_Patient_TreatmentID As FollowupID,
  Followup.IsScheduled,
  Followup.IfSheduled_Date,
  Followup.IsTreatmentBilled,
  Followup.IfTreatmentBilled_Date,
  Followup.IsTreatmentPerformed,
  Followup.IfTreatmentPerformed_Date,
  cmn_per_personinfo.Title As PerformedDoctorTitle,
  cmn_per_personinfo.FirstName As PerformedDoctorFirstName,
  cmn_per_personinfo.LastName As PerformedDoctorLastName,
  ScheduledDoctor_PersonInfo.Title As SheduledDoctorTitle,
  ScheduledDoctor_PersonInfo.FirstName As SheduledDoctorFirstName,
  ScheduledDoctor_PersonInfo.LastName As SheduledDoctorLastName,
  Followup.IfTreatmentFollowup_FromTreatment_RefID    As TreatmentID
From
  cmn_bpt_businessparticipants MedicalPractice Inner Join
  hec_medicalpractises On MedicalPractice.IfCompany_CMN_COM_CompanyInfo_RefID =
    hec_medicalpractises.Ext_CompanyInfo_RefID And
    hec_medicalpractises.Tenant_RefID = @TenantID And
    hec_medicalpractises.IsDeleted = 0 Inner Join
  hec_patient_treatment Followup On Followup.TreatmentPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID And
    Followup.IsTreatmentFollowup = 1  And    
    Followup.Tenant_RefID = @TenantID @statusParameters And
    Followup.IsDeleted = 0 Left Join
  hec_doctors On Followup.IfTreatmentPerformed_ByDoctor_RefID =
    hec_doctors.HEC_DoctorID And hec_doctors.IsDeleted = 0 And
    hec_doctors.Tenant_RefID = @TenantID Left Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID =
    @TenantID Left Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID @s_doctorParam
  Left Join
  hec_doctors ScheduledDoctor
    On Followup.IfSheduled_ForDoctor_RefID =
    ScheduledDoctor.HEC_DoctorID And ScheduledDoctor.IsDeleted = 0 And
    ScheduledDoctor.Tenant_RefID = @TenantID Left Join
  cmn_bpt_businessparticipants SheduledDoctor_Businessparticipants
    On ScheduledDoctor.BusinessParticipant_RefID =
    SheduledDoctor_Businessparticipants.CMN_BPT_BusinessParticipantID And
    SheduledDoctor_Businessparticipants.IsNaturalPerson = 1 And
    SheduledDoctor_Businessparticipants.IsCompany = 0 And
    SheduledDoctor_Businessparticipants.IsDeleted = 0 And
    SheduledDoctor_Businessparticipants.Tenant_RefID =
    @TenantID Left Join
  cmn_per_personinfo ScheduledDoctor_PersonInfo
    On
    SheduledDoctor_Businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
    = ScheduledDoctor_PersonInfo.CMN_PER_PersonInfoID And ScheduledDoctor_PersonInfo.IsDeleted = 0
     And
    ScheduledDoctor_PersonInfo.Tenant_RefID =
    @TenantID @s_scheduled_doctorParam
Where
  MedicalPractice.IsCompany = 1 And
  MedicalPractice.IsNaturalPerson = 0 And
  MedicalPractice.IsDeleted = 0 And
  MedicalPractice.Tenant_RefID = @TenantID @S_Practice
      ORDER BY 
        Case When @OrderBy = 'ASC' Then @OrderValue End Asc,
        Case When @OrderBy = 'DESC' Then @OrderValue End Desc         
LIMIT @StartIndex , @NumberOfElements