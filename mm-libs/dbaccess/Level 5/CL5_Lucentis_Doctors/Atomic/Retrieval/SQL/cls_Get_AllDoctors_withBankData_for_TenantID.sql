
	Select
  hec_doctors.HEC_DoctorID,
  hec_doctors.DoctorIDNumber As LANR,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  hec_doctors.Account_RefID,
  cmn_per_personinfo.PrimaryEmail,
  acc_bnk_banks.BankName,
  acc_bnk_banks.BICCode,
  acc_bnk_banks.RoutingNumber,
  acc_bnk_banks.BankNumber,
  acc_bnk_bankaccounts.AccountNumber,
  acc_bnk_bankaccounts.IBAN,
  acc_bnk_bankaccounts.OwnerText
From
  hec_doctors Inner Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  cmn_bpt_businessparticipant_2_bankaccount
    On
    cmn_bpt_businessparticipant_2_bankaccount.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  acc_bnk_bankaccounts
    On cmn_bpt_businessparticipant_2_bankaccount.ACC_BNK_BankAccount_RefID =
    acc_bnk_bankaccounts.ACC_BNK_BankAccountID Inner Join
  acc_bnk_banks On acc_bnk_banks.ACC_BNK_BankID =
    acc_bnk_bankaccounts.Bank_RefID
Where
  hec_doctors.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsTenant = 0 And
  hec_doctors.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipant_2_bankaccount.IsDeleted = 0 And
  acc_bnk_bankaccounts.IsDeleted = 0 And
  acc_bnk_banks.IsDeleted = 0
  