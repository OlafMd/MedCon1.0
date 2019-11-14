
Select
  cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID As
  PracticeID,
  cmn_bpt_businessparticipants.DisplayName As PracticeName,
  acc_bnk_bankaccounts.OwnerText As AccountHolder,
  acc_bnk_bankaccounts.IBAN,
  acc_bnk_banks.BankName,
  acc_bnk_banks.BICCode,
  cmn_com_companyinfo.CompanyInfo_EstablishmentNumber as PracticeBSNR
From
  cmn_bpt_ctm_organizationalunits
  Inner Join cmn_bpt_ctm_customers
    On cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID =
    cmn_bpt_ctm_organizationalunits.Customer_RefID And
    cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_customers.IsDeleted = 0 And
    cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = @BPT
  Inner Join hec_medicalpractises
    On
    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_medicalpractises.HEC_MedicalPractiseID And
    hec_medicalpractises.Tenant_RefID = @TenantID And
    hec_medicalpractises.IsDeleted = 0
  Inner Join cmn_bpt_businessparticipants
    On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
  Inner Join cmn_bpt_businessparticipant_2_bankaccount
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_2_bankaccount.CMN_BPT_BusinessParticipant_RefID
    And cmn_bpt_businessparticipant_2_bankaccount.Tenant_RefID =
    @TenantID And
    cmn_bpt_businessparticipant_2_bankaccount.IsDeleted = 0
  Inner Join acc_bnk_bankaccounts
    On cmn_bpt_businessparticipant_2_bankaccount.ACC_BNK_BankAccount_RefID =
    acc_bnk_bankaccounts.ACC_BNK_BankAccountID And
    acc_bnk_bankaccounts.Tenant_RefID = @TenantID And
    acc_bnk_bankaccounts.IsDeleted = 0
  Inner Join acc_bnk_banks On acc_bnk_bankaccounts.Bank_RefID =
    acc_bnk_banks.ACC_BNK_BankID And acc_bnk_banks.Tenant_RefID =
    @TenantID And acc_bnk_banks.IsDeleted = 0
  Inner Join cmn_com_companyinfo
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And
    cmn_com_companyinfo.Tenant_RefID = @TenantID And
    cmn_com_companyinfo.IsDeleted = 0
Where
  cmn_bpt_ctm_organizationalunits.Tenant_RefID =
  @TenantID And
  cmn_bpt_ctm_organizationalunits.IsDeleted = 0
	