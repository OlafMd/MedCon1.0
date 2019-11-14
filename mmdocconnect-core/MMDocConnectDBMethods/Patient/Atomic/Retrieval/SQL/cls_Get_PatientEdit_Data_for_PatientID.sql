
Select
  hec_patients.HEC_PatientID As id,
  cmn_per_personinfo.FirstName As first_name,
  cmn_per_personinfo.LastName As last_name,
  cmn_per_personinfo.BirthDate As birthday,
  cmn_per_personinfo.Gender As sex,
  hec_patient_healthinsurances.HealthInsurance_Number As insurance_id,
   hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID As health_insurance_provider_id,
  Max(hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom) As valid_from,
  hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID As contract_id,
  hec_patient_healthinsurances.InsuranceStateCode As insurance_status,
  hec_crt_insurancetobrokercontract_participatingpatients.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID As participation_id,
  hec_his_healthinsurance_companies.HealthInsurance_IKNumber As hip_ik_number,
  cmn_bpt_businessparticipants1.DisplayName As hip_name,
  Concat(cmn_bpt_businessparticipants1.DisplayName, ' (', hec_his_healthinsurance_companies.HealthInsurance_IKNumber, ')') As hip_display_name
From
  hec_patients
  Inner Join cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And cmn_bpt_businessparticipants.IsCompany = 0 And cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
  Inner Join cmn_per_personinfo On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID And
    cmn_per_personinfo.IsDeleted = 0 And cmn_per_personinfo.Tenant_RefID = @TenantID
  Inner Join hec_patient_healthinsurances On hec_patients.HEC_PatientID = hec_patient_healthinsurances.Patient_RefID And hec_patient_healthinsurances.IsDeleted = 0 And
    hec_patient_healthinsurances.Tenant_RefID = @TenantID
  Left Join hec_crt_insurancetobrokercontract_participatingpatients On hec_patients.HEC_PatientID = hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID And
    hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0
  Left Join hec_crt_insurancetobrokercontracts On hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID =
    hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
    hec_crt_insurancetobrokercontracts.IsDeleted = 0
  Inner Join hec_his_healthinsurance_companies On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID = hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID
    And hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And hec_his_healthinsurance_companies.IsDeleted = 0
  Inner Join cmn_bpt_businessparticipants cmn_bpt_businessparticipants1 On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID And cmn_bpt_businessparticipants1.IsDeleted = 0
Where
  hec_patients.HEC_PatientID = @PatientID And
  hec_patients.IsDeleted = 0 And
  hec_patients.Tenant_RefID = @TenantID
Group By
  hec_crt_insurancetobrokercontract_participatingpatients.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID
  