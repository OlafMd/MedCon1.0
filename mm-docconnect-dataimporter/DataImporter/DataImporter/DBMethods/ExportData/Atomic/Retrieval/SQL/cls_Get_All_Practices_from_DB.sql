
                       
Select
  hec_medicalpractises.ContactPerson_RefID,
  hec_medicalpractises.Contact_EmergencyPhoneNumber,
  hec_medicalpractises.Creation_Timestamp,
  cmn_universalcontactdetails.CompanyName_Line1,
  cmn_bpt_businessparticipants.DisplayName As Name,
  cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As BSNR,
  cmn_universalcontactdetails.Town As City,
  cmn_universalcontactdetails.ZIP,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.Contact_Telephone,
  cmn_universalcontactdetails.Contact_Email,
  acc_bnk_banks.BankName,
  acc_bnk_banks.BICCode,
  acc_bnk_bankaccounts.IBAN,
  acc_bnk_bankaccounts.OwnerText As AccountHolder,
  hec_medicalpractises.HEC_MedicalPractiseID As PracticeID,
  hec_medicalpractice_2_universalproperty.Value_Boolean As IsSurgeryPractice,
  usr_accounts.USR_AccountID As AccountID,
  acc_bnk_bankaccounts.ACC_BNK_BankAccountID As BankAccountID,
  hec_medicalpractice_universalproperties.PropertyName,
  cmn_com_companyinfo_addresses.Address_Description,
  cmn_com_companyinfo_addresses.IsBilling,
  cmn_com_companyinfo_addresses.IsShipping,
  cmn_com_companyinfo_addresses.Address_UCD_RefID,
  cmn_universalcontactdetails1.First_Name,
  cmn_universalcontactdetails1.Last_Name,
  cmn_universalcontactdetails1.Contact_Email As Contact_Email1,
  cmn_universalcontactdetails1.Contact_Telephone As Contact_Telephone1
From
  cmn_bpt_businessparticipants Left Join
  cmn_bpt_ctm_customers On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Left Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_organizationalunits.Customer_RefID =
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID =
    @TenantID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0 Left Join
  hec_medicalpractises
    On
    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_medicalpractises.HEC_MedicalPractiseID And
    hec_medicalpractises.Tenant_RefID = @TenantID And
    hec_medicalpractises.IsDeleted = 0 Inner Join
  cmn_com_companyinfo
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And
    cmn_com_companyinfo.Tenant_RefID = @TenantID And
    cmn_com_companyinfo.IsDeleted = 0 Inner Join
  cmn_com_companyinfo_addresses
    On cmn_com_companyinfo_addresses.CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And
    cmn_com_companyinfo_addresses.Tenant_RefID =
    @TenantID And
    cmn_com_companyinfo_addresses.Address_Description =
    'Standard address for billing, shipping' And
    cmn_com_companyinfo_addresses.IsDeleted = 0 Inner Join
  cmn_universalcontactdetails
    On cmn_universalcontactdetails.CMN_UniversalContactDetailID =
    cmn_com_companyinfo_addresses.Address_UCD_RefID And
    cmn_universalcontactdetails.Tenant_RefID =
    @TenantID And
    cmn_universalcontactdetails.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipant_2_bankaccount
    On
    cmn_bpt_businessparticipant_2_bankaccount.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipant_2_bankaccount.Tenant_RefID =
    @TenantID And
    cmn_bpt_businessparticipant_2_bankaccount.IsDeleted = 0 Inner Join
  acc_bnk_bankaccounts On acc_bnk_bankaccounts.ACC_BNK_BankAccountID =
    cmn_bpt_businessparticipant_2_bankaccount.ACC_BNK_BankAccount_RefID And
    acc_bnk_bankaccounts.Tenant_RefID = @TenantID And
    acc_bnk_bankaccounts.IsDeleted = 0 Inner Join
  acc_bnk_banks On acc_bnk_bankaccounts.Bank_RefID =
    acc_bnk_banks.ACC_BNK_BankID And acc_bnk_banks.IsDeleted = 0 And
    acc_bnk_banks.Tenant_RefID = @TenantID Inner Join
  hec_medicalpractice_2_universalproperty
    On hec_medicalpractice_2_universalproperty.HEC_MedicalPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID And
    hec_medicalpractice_2_universalproperty.IsDeleted = 0 And
    hec_medicalpractice_2_universalproperty.Tenant_RefID =
    @TenantID Inner Join
  hec_medicalpractice_universalproperties
    On
    hec_medicalpractice_2_universalproperty.HEC_MedicalPractice_UniversalProperty_RefID = hec_medicalpractice_universalproperties.HEC_MedicalPractice_UniversalPropertyID And hec_medicalpractice_universalproperties.PropertyName = "Surgery Practice" And hec_medicalpractice_universalproperties.IsDeleted = 0 And hec_medicalpractice_universalproperties.Tenant_RefID = @TenantID Inner Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_com_companyinfo cmn_com_companyinfo1
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo1.CMN_COM_CompanyInfoID Inner Join
  cmn_com_companyinfo_addresses cmn_com_companyinfo_addresses1
    On cmn_com_companyinfo_addresses1.CompanyInfo_RefID =
    cmn_com_companyinfo1.CMN_COM_CompanyInfoID And
    cmn_com_companyinfo_addresses1.Address_Description =
    'Standard contact person data' And cmn_com_companyinfo_addresses1.IsDeleted
    = 0 And cmn_com_companyinfo_addresses1.Tenant_RefID =
    @TenantID Inner Join
  cmn_universalcontactdetails cmn_universalcontactdetails1
    On cmn_com_companyinfo_addresses1.Address_UCD_RefID =
    cmn_universalcontactdetails1.CMN_UniversalContactDetailID  and
    cmn_universalcontactdetails1.IsDeleted = 0 and
    cmn_universalcontactdetails1.Tenant_RefID =
    @TenantID 
 Where
   cmn_bpt_businessparticipants.Tenant_RefID = 
   @TenantID And
cmn_bpt_businessparticipants.IsDeleted = 0
Group by 
PracticeID

  