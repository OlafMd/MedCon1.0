
Select
	acc_bnk_banks.BICCode,
	acc_bnk_banks.BankName,
	acc_bnk_bankaccounts.OwnerText,
	acc_bnk_bankaccounts.IBAN,  
	acc_bnk_bankaccounts.ACC_BNK_BankAccountID as BankAccountID,  
	acc_bnk_banks.ACC_BNK_BankID as BankID
From
	hec_medicalpractises Inner Join
	cmn_bpt_ctm_organizationalunits
		On
		cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
		= hec_medicalpractises.HEC_MedicalPractiseID And 
		cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
		cmn_bpt_ctm_organizationalunits.IsDeleted = 0 
		Inner Join
	cmn_bpt_ctm_customers On cmn_bpt_ctm_organizationalunits.Customer_RefID =
		cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And 
		cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
		cmn_bpt_ctm_customers.IsDeleted = 0
	 Inner Join
	cmn_bpt_businessparticipants
		On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
		cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID And 
		cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And 
		cmn_bpt_businessparticipants.IsDeleted = 0   
	 Inner Join
	cmn_bpt_businessparticipant_2_bankaccount
		On
		cmn_bpt_businessparticipant_2_bankaccount.CMN_BPT_BusinessParticipant_RefID
		= cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And 
	 cmn_bpt_businessparticipant_2_bankaccount.Tenant_RefID = @TenantID And
	 cmn_bpt_businessparticipant_2_bankaccount.IsDeleted = 0    
		Inner Join
	acc_bnk_bankaccounts On acc_bnk_bankaccounts.ACC_BNK_BankAccountID =
		cmn_bpt_businessparticipant_2_bankaccount.ACC_BNK_BankAccount_RefID And
		acc_bnk_bankaccounts.IsDeleted = 0 And
		acc_bnk_bankaccounts.Tenant_RefID = @TenantID
	Inner Join
	acc_bnk_banks On acc_bnk_bankaccounts.Bank_RefID =
		acc_bnk_banks.ACC_BNK_BankID And 
		acc_bnk_banks.Tenant_RefID = @TenantID And
		acc_bnk_banks.IsDeleted = 0 
Where
	hec_medicalpractises.HEC_MedicalPractiseID = @PracticeID And
	hec_medicalpractises.IsDeleted = 0 And    
	hec_medicalpractises.Tenant_RefID = @TenantID     
	