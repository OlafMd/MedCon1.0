
		Select
  bil_billpositions.External_PositionReferenceField As Vorgangsnummer,
  hec_patient_treatment.IsTreatmentFollowup,
  Case
    When (hec_patient_treatment.IsTreatmentFollowup =
    0) Then cmn_per_personinfo.BirthDate
    When (hec_patient_treatment.IsTreatmentFollowup =
    1) Then followup_is_wrong.BirthDate End As Patient_Birthday,
  Case
    When (hec_patient_treatment.IsTreatmentFollowup =
    0) Then cmn_per_personinfo.FirstName
    When (hec_patient_treatment.IsTreatmentFollowup =
    1) Then followup_is_wrong.FirstName End As Patient_First_Name,
  Case
    When (hec_patient_treatment.IsTreatmentFollowup =
    0) Then cmn_per_personinfo.LastName
    When (hec_patient_treatment.IsTreatmentFollowup =
    1) Then followup_is_wrong.LastName End As Patient_Last_Name,
  hec_patient_treatment.IfTreatmentPerformed_Date As Performed_Date,
  hec_patient_treatment.IfTreatmentBilled_Date As Billed_Date,
  hec_patient_treatment.HEC_Patient_TreatmentID As Treatment_ID,
  hec_doctors.DoctorIDNumber As Performed_Doctor_ID_Number,
  bil_billpositions.External_PositionType,
  bil_billpositions.PositionValue_IncludingTax,
  bil_billpositions.BIL_BillPositionID,
  bil_billposition_transmitionstatuses.TransmitionCode,
  bil_billposition_transmitionstatuses.TransmittedOnDate
From
  bil_billpositions Inner Join
  bil_billposition_2_patienttreatment
    On bil_billposition_2_patienttreatment.BIL_BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID And
    bil_billposition_2_patienttreatment.IsDeleted = 0 And
    bil_billposition_2_patienttreatment.Tenant_RefID =
    @TenantID Inner Join
  hec_patient_treatment
    On bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    hec_patient_treatment.IsDeleted = 0 And hec_patient_treatment.Tenant_RefID =
    @TenantID And
    hec_patient_treatment.IsTreatmentBilled = 1 Left Join
  hec_patient_2_patienttreatment
    On hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    hec_patient_2_patienttreatment.Tenant_RefID =
    @TenantID And
    hec_patient_2_patienttreatment.IsDeleted = 0 Left Join
  hec_patients
    On hec_patients.HEC_PatientID =
    hec_patient_2_patienttreatment.HEC_Patient_RefID And
    hec_patients.IsDeleted = 0 And hec_patients.Tenant_RefID =
    @TenantID Left Join
  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID =
    @TenantID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 Left Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID
  Inner Join
  hec_doctors On hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID =
    hec_doctors.HEC_DoctorID And hec_doctors.IsDeleted = 0 And
    hec_doctors.Tenant_RefID = @TenantID Left Join
  hec_patient_treatment hec_patient_treatment1
    On hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID =
    hec_patient_treatment1.HEC_Patient_TreatmentID And
    hec_patient_treatment1.IsTreatmentFollowup = 0 And
    hec_patient_treatment1.Tenant_RefID = @TenantID
    And hec_patient_treatment1.IsDeleted = 0 Left Join
  hec_patient_2_patienttreatment hec_patient_2_patienttreatment1
    On hec_patient_2_patienttreatment1.HEC_Patient_Treatment_RefID =
    hec_patient_treatment1.HEC_Patient_TreatmentID And
    hec_patient_2_patienttreatment1.IsDeleted = 0 And
    hec_patient_2_patienttreatment1.Tenant_RefID =
    @TenantID Left Join
  hec_patients followup_is_wrong_pat
    On hec_patient_2_patienttreatment1.HEC_Patient_RefID =
    followup_is_wrong_pat.HEC_PatientID And followup_is_wrong_pat.Tenant_RefID =
    @TenantID And followup_is_wrong_pat.IsDeleted = 0
  Left Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On followup_is_wrong_pat.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants1.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants1.IsCompany = 0 And
    cmn_bpt_businessparticipants1.IsDeleted = 0 And
    cmn_bpt_businessparticipants1.Tenant_RefID =
    @TenantID Left Join
  cmn_per_personinfo followup_is_wrong
    On cmn_bpt_businessparticipants1.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    followup_is_wrong.CMN_PER_PersonInfoID And followup_is_wrong.IsDeleted = 0
    And followup_is_wrong.Tenant_RefID = @TenantID
  Inner Join
  bil_billposition_transmitionstatuses
    On bil_billposition_transmitionstatuses.BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID And
    bil_billposition_transmitionstatuses.IsDeleted = 0 And
    bil_billposition_transmitionstatuses.IsActive = 1 And
    bil_billposition_transmitionstatuses.Tenant_RefID =
    @TenantID
Where
  bil_billpositions.IsDeleted = 0 And
  bil_billpositions.Tenant_RefID = @TenantID And
  Year(bil_billpositions.Creation_Timestamp) = 2015
  