
Select
  hec_doctors.HEC_DoctorID As Id,
  hec_doctors.DoctorIDNumber As Lanr,
  cmn_per_personinfo.Salutation_General As Salutation,
  cmn_per_personinfo.FirstName As FirstName,
  cmn_per_personinfo.LastName As LastName,
  cmn_per_personinfo.Title As Title,
  acc_bnk_bankaccounts.IBAN,
  acc_bnk_banks.BankName,
  acc_bnk_banks.BICCode,
  acc_bnk_bankaccounts.OwnerText As AccountHolder,
  cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID As
  Practice_ID,
  cmn_universalcontactdetails.Contact_Telephone As Phone,
  cmn_universalcontactdetails.Contact_Email As Email,
  cmn_bpt_businessparticipants1.DisplayName As PracticeName,
  cmn_per_communicationcontact_typesEmail.Type,
  cmn_per_communicationcontact_typesEmail.CMN_PER_CommunicationContact_TypeID,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.ZIP,
  cmn_universalcontactdetails.Town,
  cmn_universalcontactdetails.Contact_Fax As Fax,
  cmn_com_companyinfo_addresses.IsContact,
  usr_accounts.USR_AccountID As AccountID,
  acc_bnk_bankaccounts.ACC_BNK_BankAccountID As BankAccountID
From
  hec_doctors Left Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    hec_doctors.BusinessParticipant_RefID Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID And
    cmn_per_personinfo.IsDeleted = 0 And cmn_per_personinfo.Tenant_RefID =
    @TenantID Left Join
  cmn_per_communicationcontacts cmn_per_communicationcontactsEmail
    On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_communicationcontactsEmail.PersonInfo_RefID And
    cmn_per_communicationcontactsEmail.IsDeleted = 0 And
    cmn_per_communicationcontactsEmail.Tenant_RefID =
    @TenantID Left Join
  cmn_per_communicationcontact_types cmn_per_communicationcontact_typesEmail
    On cmn_per_communicationcontactsEmail.Contact_Type =
    cmn_per_communicationcontact_typesEmail.CMN_PER_CommunicationContact_TypeID
    And cmn_per_communicationcontact_typesEmail.Tenant_RefID =
    @TenantID And
    cmn_per_communicationcontact_typesEmail.Type = "Phone" And
    cmn_per_communicationcontact_typesEmail.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipant_2_bankaccount
    On
    cmn_bpt_businessparticipant_2_bankaccount.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipant_2_bankaccount.IsDeleted = 0 And
    cmn_bpt_businessparticipant_2_bankaccount.Tenant_RefID =
    @TenantID Left Join
  acc_bnk_bankaccounts
    On cmn_bpt_businessparticipant_2_bankaccount.ACC_BNK_BankAccount_RefID =
    acc_bnk_bankaccounts.ACC_BNK_BankAccountID And
    acc_bnk_bankaccounts.IsDeleted = 0 And acc_bnk_bankaccounts.Tenant_RefID =
    @TenantID Left Join
  acc_bnk_banks On acc_bnk_banks.ACC_BNK_BankID =
    acc_bnk_bankaccounts.Bank_RefID And acc_bnk_banks.IsDeleted = 0 And
    acc_bnk_banks.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_ctm_organizationalunit_staff
    On cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0 And
    cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID =
    @TenantID Inner Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID =
    cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0 And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID =
    @TenantID Inner Join
  cmn_bpt_ctm_customers On cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID =
    cmn_bpt_ctm_organizationalunits.Customer_RefID And
    cmn_bpt_ctm_customers.IsDeleted = 0 And cmn_bpt_ctm_customers.Tenant_RefID =
    @TenantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants1.IsNaturalPerson = 0 And
    cmn_bpt_businessparticipants1.IsCompany = 1 And
    cmn_bpt_businessparticipants1.IsDeleted = 0 And
    cmn_bpt_businessparticipants1.Tenant_RefID =
    @TenantID Inner Join
  cmn_com_companyinfo_addresses
    On cmn_bpt_businessparticipants1.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo_addresses.CompanyInfo_RefID And
    cmn_com_companyinfo_addresses.IsDeleted = 0 And
    cmn_com_companyinfo_addresses.Tenant_RefID =
    @TenantID And
    cmn_com_companyinfo_addresses.IsContact = 0 Inner Join
  cmn_universalcontactdetails On cmn_com_companyinfo_addresses.Address_UCD_RefID
    = cmn_universalcontactdetails.CMN_UniversalContactDetailID And
    cmn_universalcontactdetails.IsDeleted = 0 And
    cmn_universalcontactdetails.Tenant_RefID =
    @TenantID Inner Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
Group By
  Id
  