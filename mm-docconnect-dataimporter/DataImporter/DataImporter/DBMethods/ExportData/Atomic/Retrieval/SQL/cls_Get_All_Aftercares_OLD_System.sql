
Select
  hec_patient_treatment.HEC_Patient_TreatmentID As FollowupID,
  hec_patient_treatment.IsTreatmentPerformed,
  hec_patient_treatment.IsScheduled,
  hec_patient_treatment.IfSheduled_Date,
  hec_patient_treatment.IsTreatmentBilled,
  hec_patient_treatment.IfTreatmentPerformed_Date,
  hec_doctors.DoctorIDNumber As PerformedDoctorLANR,
  cmn_per_personinfo.FirstName As PerformedDoctorFirstName,
  cmn_per_personinfo.LastName As PerformedDoctorLastName,
  hec_doctors1.DoctorIDNumber As ScheduledDoctorLANR,
  cmn_per_personinfo1.FirstName As ScheduledDoctorFirstName,
  cmn_per_personinfo1.LastName As ScheduledDoctorLastName,
  bil_billpositions.External_PositionReferenceField As VorgangsNummer,
  bil_billpositions.PositionValue_IncludingTax,
  bil_billpositions.External_PositionType,
  bil_billpositions.BIL_BillPositionID,
  bil_billposition_transmitionstatuses.TransmitionCode,
  bil_billposition_transmitionstatuses.PrimaryComment,
  bil_billposition_transmitionstatuses.SecondaryComment,
  bil_billposition_transmitionstatuses.TransmittedOnDate,
  bil_billpositions.External_PositionCode As GPOS,
  cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As BSNR,
  cmn_bpt_businessparticipants2.DisplayName As PracticeName
From
  hec_patient_treatment Left Join
  hec_doctors On hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID =
    hec_doctors.HEC_DoctorID And hec_doctors.IsDeleted = 0 And
    hec_doctors.Tenant_RefID = @TenantID Left Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Left Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Left Join
  hec_doctors hec_doctors1 On hec_patient_treatment.IfSheduled_ForDoctor_RefID =
    hec_doctors1.HEC_DoctorID And hec_doctors1.IsDeleted = 0 And
    hec_doctors1.Tenant_RefID = @TenantID Left Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On hec_doctors1.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants1.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants1.IsCompany = 0 And
    cmn_bpt_businessparticipants1.IsDeleted = 0 And
    cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID Left Join
  cmn_per_personinfo cmn_per_personinfo1
    On cmn_bpt_businessparticipants1.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo1.CMN_PER_PersonInfoID And cmn_per_personinfo1.IsDeleted =
    0 And cmn_per_personinfo1.Tenant_RefID = @TenantID Left Join
  bil_billposition_2_patienttreatment
    On bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    bil_billposition_2_patienttreatment.IsDeleted = 0 And
    bil_billposition_2_patienttreatment.Tenant_RefID = @TenantID Left Join
  bil_billpositions
    On bil_billposition_2_patienttreatment.BIL_BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID And bil_billpositions.Tenant_RefID =
    @TenantID And bil_billpositions.IsDeleted = 0 Left Join
  bil_billposition_transmitionstatuses On bil_billpositions.BIL_BillPositionID =
    bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.IsDeleted = 0 And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
    bil_billposition_transmitionstatuses.IsActive = 1 Inner Join
  hec_medicalpractises On hec_patient_treatment.TreatmentPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID And
    hec_medicalpractises.IsDeleted = 0 And hec_medicalpractises.Tenant_RefID =
    @TenantID Inner Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted
    = 0 And cmn_com_companyinfo.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants2
    On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    cmn_bpt_businessparticipants2.IfCompany_CMN_COM_CompanyInfo_RefID  
      And
  cmn_bpt_businessparticipants2.IsNaturalPerson = 0 And
  cmn_bpt_businessparticipants2.IsCompany = 1 And
  cmn_bpt_businessparticipants2.IsDeleted = 0 And
  cmn_bpt_businessparticipants2.Tenant_RefID = @TenantID
Where
  hec_patient_treatment.IsTreatmentFollowup = 1 And
  hec_patient_treatment.IsDeleted = 0 And
  hec_patient_treatment.Tenant_RefID = @TenantID And
  hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID = @TreatmentID

  