
Select
  hec_doctors.DoctorIDNumber As LANR,
  cmn_per_personinfo.FirstName As DoctorFirstName,
  cmn_per_personinfo.LastName As DoctorLastName,
  acc_bnk_bankaccounts.OwnerText As AccountHolder,
  acc_bnk_bankaccounts.AccountNumber,
  acc_bnk_banks.BankName,
  acc_bnk_banks.BankNumber As BLZ,
  cmn_per_personinfo.Tenant_RefID,
  hec_doctors.HEC_DoctorID,
  hec_patient_treatment.HEC_Patient_TreatmentID,
  cmn_bpt_businessparticipants1.DisplayName As PracticeName
From
  hec_doctors Inner Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Left Join
  cmn_bpt_businessparticipant_2_bankaccount
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_2_bankaccount.CMN_BPT_BusinessParticipant_RefID
    And cmn_bpt_businessparticipant_2_bankaccount.IsDeleted = 0 Left Join
  acc_bnk_bankaccounts
    On cmn_bpt_businessparticipant_2_bankaccount.ACC_BNK_BankAccount_RefID =
    acc_bnk_bankaccounts.ACC_BNK_BankAccountID And
    acc_bnk_bankaccounts.IsDeleted = 0 Left Join
  acc_bnk_banks On acc_bnk_bankaccounts.Bank_RefID =
    acc_bnk_banks.ACC_BNK_BankID And acc_bnk_banks.IsDeleted = 0 Inner Join
  hec_patient_treatment On hec_doctors.HEC_DoctorID =
    hec_patient_treatment.IfSheduled_ForDoctor_RefID Inner Join
  hec_medicalpractises On hec_patient_treatment.TreatmentPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_bpt_businessparticipants1.IfCompany_CMN_COM_CompanyInfo_RefID
Where
  hec_doctors.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsTenant = 0 And
  cmn_per_personinfo.Tenant_RefID = @TenantID And
  hec_doctors.HEC_DoctorID = @DoctorsID And
  hec_patient_treatment.HEC_Patient_TreatmentID = @TreatmentID And
  hec_patient_treatment.IsTreatmentFollowup = 1
Group By
  acc_bnk_bankaccounts.OwnerText, acc_bnk_bankaccounts.AccountNumber,
  acc_bnk_banks.BankName, acc_bnk_banks.BankNumber,
  cmn_per_personinfo.Tenant_RefID, hec_doctors.HEC_DoctorID,
  hec_patient_treatment.HEC_Patient_TreatmentID,
  cmn_bpt_businessparticipants1.DisplayName,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  hec_doctors.Tenant_RefID, hec_patient_treatment.IsDeleted,
  hec_patient_treatment.IsTreatmentFollowup
  