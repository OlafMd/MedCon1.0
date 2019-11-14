
Select
  Concat_Ws(' ', cmn_per_personinfo.FirstName, cmn_per_personinfo.LastName) As
  name,
  cmn_per_personinfo.FirstName As patient_first_name,
  cmn_per_personinfo.LastName As patient_last_name,
  cmn_per_personinfo.BirthDate As birthday,
  hec_patient_healthinsurances.HealthInsurance_Number As insurance_id,
  hec_patient_healthinsurances.InsuranceStateCode As insurance_status,
  cmn_bpt_businessparticipants1.DisplayName As health_insurance_provider,
  hec_patients.HEC_PatientID As id,
  hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom As
  participation_consent_issue_date,
  hec_crt_insurancetobrokercontract_participatingpatients.ValidThrough,
  Count(hec_cas_cases.HEC_CAS_CaseID) As contract_number,
  cmn_per_personinfo.Gender As gender,
  hec_crt_insurancetobrokercontract_participatingpatients.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID,
  hec_his_healthinsurance_companies.HealthInsurance_IKNumber,
  cmn_ctr_contract_parties.Contract_RefID As contractID
From
  cmn_per_personinfo Inner Join
  cmn_bpt_businessparticipants On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  hec_patients On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    hec_patients.CMN_BPT_BusinessParticipant_RefID And hec_patients.IsDeleted =
    0 And hec_patients.Tenant_RefID = @TenantID Inner Join
  hec_patient_healthinsurances On hec_patients.HEC_PatientID =
    hec_patient_healthinsurances.Patient_RefID And
    hec_patient_healthinsurances.IsDeleted = 0 And
    hec_patient_healthinsurances.Tenant_RefID = @TenantID Inner Join
  hec_his_healthinsurance_companies
    On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID =
    hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
    hec_his_healthinsurance_companies.IsDeleted = 0 And
    hec_his_healthinsurance_companies.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants1.IsCompany = 1 And
    cmn_bpt_businessparticipants1.IsNaturalPerson = 0 And
    cmn_bpt_businessparticipants1.IsDeleted = 0 And
    cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID Left Join
  hec_crt_insurancetobrokercontract_participatingpatients
    On hec_patients.HEC_PatientID =
    hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID And
    hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID =
    @TenantID And
    hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0
  Left Join
  hec_cas_cases On hec_patients.HEC_PatientID = hec_cas_cases.Patient_RefID And
    hec_cas_cases.Tenant_RefID = @TenantID And hec_cas_cases.IsDeleted = 0
  Inner Join
  cmn_ctr_contract_parties
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID 
    And
  cmn_ctr_contract_parties.Tenant_RefID = @TenantID And
  cmn_ctr_contract_parties.IsDeleted = 0
Where
  hec_patients.HEC_PatientID = @PatientID And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_per_personinfo.Tenant_RefID = @TenantID 
  