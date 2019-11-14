
Select
	hec_medicalpractises.HEC_MedicalPractiseID As practiceID,
	cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As practice_BSNR,
	cmn_universalcontactdetails.IsCompany As is_company,
	cmn_bpt_businessparticipants.DisplayName As practice_name,
  cmn_universalcontactdetails.Street_Name as street,
  cmn_universalcontactdetails.Street_Number as number,
  cmn_universalcontactdetails.ZIP as zip,
  cmn_universalcontactdetails.Town as city,
	Concat(cmn_universalcontactdetails.Street_Name, ' ',
	cmn_universalcontactdetails.Street_Number) As practice_address,
	Concat(cmn_universalcontactdetails.ZIP, ' ', cmn_universalcontactdetails.Town)
	As practice_town,
	cmn_universalcontactdetails.Contact_Email,
	cmn_universalcontactdetails.Contact_Telephone,
	cmn_universalcontactdetails.Contact_Fax,
	Concat_Ws(' ', cmn_universalcontactdetails.First_Name,
	cmn_universalcontactdetails.Last_Name) As contact_person_name,
	acc_bnk_bankaccounts.IBAN As practice_IBAN,
	acc_bnk_banks.BankName As practice_bank_name,
	acc_bnk_banks.BICCode As practice_bank_BIC,
	acc_bnk_bankaccounts.OwnerText As account_holder,
	hec_medicalpractice_universalproperties.IsValue_String,
	hec_medicalpractice_universalproperties.IsValue_Number,
	hec_medicalpractice_universalproperties.IsValue_Boolean,
	hec_medicalpractice_universalproperties.PropertyName,
	hec_medicalpractice_2_universalproperty.Value_String,
	hec_medicalpractice_2_universalproperty.Value_Number,
	hec_medicalpractice_2_universalproperty.Value_Boolean,
	usr_accounts.AccountSignInEmailAddress as sign_in_email
From
	hec_medicalpractises Inner Join
	cmn_bpt_ctm_organizationalunits
		On
		cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
		= hec_medicalpractises.HEC_MedicalPractiseID And
		cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
		cmn_bpt_ctm_organizationalunits.IsDeleted = 0 Inner Join
	cmn_bpt_ctm_customers On cmn_bpt_ctm_organizationalunits.Customer_RefID =
		cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And
		cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
		cmn_bpt_ctm_customers.IsDeleted = 0 Inner Join
	cmn_bpt_businessparticipants
		On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
		cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
		cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
		cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
	cmn_com_companyinfo_addresses
		On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
		cmn_com_companyinfo_addresses.CompanyInfo_RefID And
		cmn_com_companyinfo_addresses.Tenant_RefID = @TenantID And
		cmn_com_companyinfo_addresses.IsDeleted = 0 Inner Join
	cmn_universalcontactdetails On cmn_com_companyinfo_addresses.Address_UCD_RefID
		= cmn_universalcontactdetails.CMN_UniversalContactDetailID And
		cmn_universalcontactdetails.Tenant_RefID = @TenantID And
		cmn_universalcontactdetails.IsDeleted = 0 Inner Join
	cmn_bpt_ctm_organizationalunits cmn_bpt_ctm_organizationalunits1
		On
		cmn_bpt_ctm_organizationalunits1.IfMedicalPractise_HEC_MedicalPractice_RefID
		= hec_medicalpractises.HEC_MedicalPractiseID And
		cmn_bpt_ctm_organizationalunits1.Tenant_RefID = @TenantID And
		cmn_bpt_ctm_organizationalunits1.IsDeleted = 0 Inner Join
	cmn_bpt_ctm_customers cmn_bpt_ctm_customers1
		On cmn_bpt_ctm_organizationalunits1.Customer_RefID =
		cmn_bpt_ctm_customers1.CMN_BPT_CTM_CustomerID And
		cmn_bpt_ctm_customers1.Tenant_RefID = @TenantID And
		cmn_bpt_ctm_customers1.IsDeleted = 0 Inner Join
	cmn_bpt_businessparticipant_2_bankaccount
		On cmn_bpt_ctm_customers1.Ext_BusinessParticipant_RefID =
		cmn_bpt_businessparticipant_2_bankaccount.CMN_BPT_BusinessParticipant_RefID
		And cmn_bpt_businessparticipant_2_bankaccount.Tenant_RefID = @TenantID And
		cmn_bpt_businessparticipant_2_bankaccount.IsDeleted = 0 Inner Join
	acc_bnk_bankaccounts
		On cmn_bpt_businessparticipant_2_bankaccount.ACC_BNK_BankAccount_RefID =
		acc_bnk_bankaccounts.ACC_BNK_BankAccountID And
		acc_bnk_bankaccounts.Tenant_RefID = @TenantID And
		acc_bnk_bankaccounts.IsDeleted = 0 Left Join
	acc_bnk_banks On acc_bnk_bankaccounts.Bank_RefID =
		acc_bnk_banks.ACC_BNK_BankID And acc_bnk_banks.Tenant_RefID = @TenantID And
		acc_bnk_banks.IsDeleted = 0 Inner Join
	cmn_com_companyinfo On cmn_com_companyinfo_addresses.CompanyInfo_RefID =
		cmn_com_companyinfo.CMN_COM_CompanyInfoID And
		cmn_com_companyinfo.Tenant_RefID = @TenantID And
		cmn_com_companyinfo.IsDeleted = 0 Inner Join
	hec_medicalpractice_2_universalproperty
		On hec_medicalpractises.HEC_MedicalPractiseID =
		hec_medicalpractice_2_universalproperty.HEC_MedicalPractice_RefID And
		hec_medicalpractice_2_universalproperty.Tenant_RefID = @TenantID And
		hec_medicalpractice_2_universalproperty.IsDeleted = 0 Inner Join
	hec_medicalpractice_universalproperties
		On
		hec_medicalpractice_2_universalproperty.HEC_MedicalPractice_UniversalProperty_RefID = hec_medicalpractice_universalproperties.HEC_MedicalPractice_UniversalPropertyID And hec_medicalpractice_universalproperties.Tenant_RefID = @TenantID And hec_medicalpractice_universalproperties.IsDeleted = 0 Inner Join
	usr_accounts On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
		usr_accounts.BusinessParticipant_RefID And
		usr_accounts.IsDeleted = 0 And
		usr_accounts.Tenant_RefID = @TenantID
Where
	hec_medicalpractises.HEC_MedicalPractiseID = @PracticeID And
	hec_medicalpractises.Tenant_RefID = @TenantID And
	hec_medicalpractises.IsDeleted = 0
	