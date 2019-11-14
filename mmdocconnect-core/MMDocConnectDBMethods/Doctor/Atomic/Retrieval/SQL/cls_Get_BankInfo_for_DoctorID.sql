
  Select
    acc_bnk_banks.BICCode,
    acc_bnk_banks.BankName,
    acc_bnk_bankaccounts.OwnerText,
    acc_bnk_bankaccounts.IBAN,  
    acc_bnk_banks.ACC_BNK_BankID as BankID,
    acc_bnk_bankaccounts.ACC_BNK_BankAccountID as BankAccountID
  From
    hec_doctors Inner Join
    cmn_bpt_businessparticipant_2_bankaccount
      On hec_doctors.BusinessParticipant_RefID =
      cmn_bpt_businessparticipant_2_bankaccount.CMN_BPT_BusinessParticipant_RefID
      And cmn_bpt_businessparticipant_2_bankaccount.Tenant_RefID = @TenantID And
      cmn_bpt_businessparticipant_2_bankaccount.IsDeleted = 0 Inner Join
    acc_bnk_bankaccounts
      On cmn_bpt_businessparticipant_2_bankaccount.ACC_BNK_BankAccount_RefID =
      acc_bnk_bankaccounts.ACC_BNK_BankAccountID And
      acc_bnk_bankaccounts.Tenant_RefID = @TenantID And
      acc_bnk_bankaccounts.IsDeleted = 0 Inner Join
    acc_bnk_banks On acc_bnk_bankaccounts.Bank_RefID =
      acc_bnk_banks.ACC_BNK_BankID And acc_bnk_banks.Tenant_RefID = @TenantID And
      acc_bnk_banks.IsDeleted = 0
  Where
    hec_doctors.HEC_DoctorID = @DoctorID And
    hec_doctors.Tenant_RefID = @TenantID And
    hec_doctors.IsDeleted = 0
  