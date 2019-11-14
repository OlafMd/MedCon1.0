
    Select
      hec_doctors.Account_RefID As doctor_account_id,
      hec_doctors.HEC_DoctorID As id,
      hec_doctors.DoctorIDNumber As lanr,
      Concat_Ws(' ', cmn_per_personinfo.Title, cmn_per_personinfo.LastName) As name,
      cmn_per_personinfo.FirstName As first_name,
      cmn_per_personinfo.LastName As last_name,
      cmn_per_personinfo.Title As title,
      cmn_per_communicationcontactsEmail.Content,
      acc_bnk_bankaccounts.IBAN,
      acc_bnk_banks.BankName,
      acc_bnk_banks.BICCode,
      acc_bnk_bankaccounts.OwnerText,
      cmn_per_communicationcontact_typesEmail.Type,
      cmn_per_communicationcontact_typesEmail.CMN_PER_CommunicationContact_TypeID,             
      usr_accounts.AccountSignInEmailAddress As sign_in_email,    
      practice_details.practice_id,
      practice_details.practice,
      practice_details.address,
      practice_details.ZIP,
      practice_details.town,
      practice_details.fax,
      practice_details.IsContact,
      practice_details.BSNR,
      practice_details.ZIP,
      practice_details.city  ,
	  cmn_per_personinfo.Salutation_General as salutation  ,
      acc_bnk_bankaccounts.ACC_BNK_BankAccountID as BankAccountID
    From
      hec_doctors Left Join
      usr_accounts On hec_doctors.BusinessParticipant_RefID =
        usr_accounts.BusinessParticipant_RefID And usr_accounts.Tenant_RefID =
        @TenantID And usr_accounts.IsDeleted = 0 
        Inner Join
      cmn_bpt_businessparticipants
        On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
        hec_doctors.BusinessParticipant_RefID And
        cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
        cmn_bpt_businessparticipants.IsCompany = 0 And
        cmn_bpt_businessparticipants.IsDeleted = 0 And
        cmn_bpt_businessparticipants.Tenant_RefID =
        @TenantID Inner Join
      cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
        cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID And
        cmn_per_personinfo.IsDeleted = 0 And cmn_per_personinfo.Tenant_RefID =
        @TenantID Inner Join
      cmn_per_communicationcontacts cmn_per_communicationcontactsEmail
        On cmn_per_personinfo.CMN_PER_PersonInfoID =
        cmn_per_communicationcontactsEmail.PersonInfo_RefID And
        cmn_per_communicationcontactsEmail.IsDeleted = 0 And
        cmn_per_communicationcontactsEmail.Tenant_RefID =
        @TenantID Inner Join
      cmn_per_communicationcontact_types cmn_per_communicationcontact_typesEmail
        On cmn_per_communicationcontactsEmail.Contact_Type =
        cmn_per_communicationcontact_typesEmail.CMN_PER_CommunicationContact_TypeID
        And cmn_per_communicationcontact_typesEmail.Tenant_RefID =
        @TenantID And
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
        acc_bnk_banks.Tenant_RefID = @TenantID       
         left join
                (select    
                cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID as bpt,  
          cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID As
          practice_id,
          cmn_bpt_businessparticipants1.DisplayName As practice,
          Concat_Ws(' ', cmn_universalcontactdetails.Street_Name,
          cmn_universalcontactdetails.Street_Number) As address,
          Concat_Ws(' ', cmn_universalcontactdetails.ZIP,
          cmn_universalcontactdetails.Town) As town,
          cmn_universalcontactdetails.Contact_Fax As fax,
          cmn_com_companyinfo_addresses.IsContact,
          cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As BSNR,
          cmn_universalcontactdetails.ZIP,
          cmn_universalcontactdetails.Town As city    
      from    
      cmn_bpt_ctm_organizationalunit_staff
          inner Join
      cmn_bpt_ctm_organizationalunits
        On cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID =
        cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID And
        cmn_bpt_ctm_organizationalunits.IsDeleted = 0 And
        cmn_bpt_ctm_organizationalunits.Tenant_RefID =
        @TenantID inner Join
      cmn_bpt_ctm_customers On cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID =
        cmn_bpt_ctm_organizationalunits.Customer_RefID And
        cmn_bpt_ctm_customers.IsDeleted = 0 And cmn_bpt_ctm_customers.Tenant_RefID =
        @TenantID inner Join
      cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
        On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
        cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants1.IsNaturalPerson = 0 And
        cmn_bpt_businessparticipants1.IsCompany = 1 And
        cmn_bpt_businessparticipants1.IsDeleted = 0 And
        cmn_bpt_businessparticipants1.Tenant_RefID =
        @TenantID inner Join
      cmn_com_companyinfo_addresses On cmn_com_companyinfo_addresses.IsDeleted = 0
        And cmn_com_companyinfo_addresses.Tenant_RefID =
        @TenantID And
        cmn_com_companyinfo_addresses.IsContact = 0 inner Join
      cmn_universalcontactdetails On cmn_com_companyinfo_addresses.Address_UCD_RefID
        = cmn_universalcontactdetails.CMN_UniversalContactDetailID And
        cmn_universalcontactdetails.IsDeleted = 0 And
        cmn_universalcontactdetails.Tenant_RefID =
        @TenantID inner Join
      cmn_com_companyinfo On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
        cmn_com_companyinfo_addresses.CompanyInfo_RefID And
        cmn_bpt_businessparticipants1.IfCompany_CMN_COM_CompanyInfo_RefID =
        cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted
        = 0 And cmn_com_companyinfo.Tenant_RefID =
        @TenantID
         Where           
        cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0 And
        cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID =
        @TenantID) as practice_details  
            on practice_details.bpt =
              hec_doctors.BusinessParticipant_RefID  
    Where
      hec_doctors.IsDeleted = 0 And
      hec_doctors.Tenant_RefID = @TenantID
	