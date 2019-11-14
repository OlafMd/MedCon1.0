
	Select
  hec_patient_healthinsurances.HealthInsurance_Number,
  hec_patient_healthinsurances.InsuranceValidFrom,
  hec_patient_healthinsurances.InsuranceValidThrough,
  hec_patient_healthinsurances.IsNotSelfInsured,
  hec_patient_healthinsurances.IsNotSelfInsured_InsuredPersonName,
  hec_patient_healthinsurances.IsNotSelfInsured_InsuredPersonBirthday,
  cmn_bpt_businessparticipants.DisplayName As CompanyName,
  acc_bnk_bankaccounts.AccountNumber,
  acc_bnk_bankaccounts.OwnerText,
  acc_bnk_banks.BICCode,
  acc_bnk_banks.BankName,
  hec_patient_healthinsurance_states.HEC_Patient_HealthInsurance_StateID,
  hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID,
  acc_bnk_bankaccounts.IBAN
From
  hec_patient_healthinsurances Inner Join
  hec_his_healthinsurance_companies
    On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID =
    hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
    hec_his_healthinsurance_companies.IsDeleted = 0 And
    hec_his_healthinsurance_companies.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  hec_patients
    On hec_patients.HEC_PatientID = hec_patient_healthinsurances.Patient_RefID
    And hec_patients.IsDeleted = 0 And hec_patients.Tenant_RefID = @TenantID
  Inner Join
  cmn_bpt_businessparticipant_2_bankaccount
    On
    cmn_bpt_businessparticipant_2_bankaccount.CMN_BPT_BusinessParticipant_RefID
    = hec_patients.CMN_BPT_BusinessParticipant_RefID And
    cmn_bpt_businessparticipants.IsCompany = 1 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 0 Inner Join
  acc_bnk_bankaccounts On acc_bnk_bankaccounts.ACC_BNK_BankAccountID =
    cmn_bpt_businessparticipant_2_bankaccount.ACC_BNK_BankAccount_RefID And
    acc_bnk_bankaccounts.IsDeleted = 0 And acc_bnk_bankaccounts.Tenant_RefID =
    @TenantID Inner Join
  acc_bnk_banks On acc_bnk_bankaccounts.Bank_RefID =
    acc_bnk_banks.ACC_BNK_BankID And acc_bnk_banks.IsDeleted = 0 And
    acc_bnk_banks.Tenant_RefID = @TenantID Inner Join
  hec_patient_healthinsurance_states
    On hec_patient_healthinsurance_states.HEC_Patient_HealthInsurance_StateID =
    hec_patient_healthinsurances.HealthInsurance_State_RefID And
    hec_patient_healthinsurance_states.IsDeleted = 0 And
    hec_patient_healthinsurance_states.Tenant_RefID = @TenantID
Where
  hec_patient_healthinsurances.Patient_RefID = @PatientID And
  hec_patient_healthinsurances.IsDeleted = 0 And
  hec_patient_healthinsurances.Tenant_RefID = @TenantID
  