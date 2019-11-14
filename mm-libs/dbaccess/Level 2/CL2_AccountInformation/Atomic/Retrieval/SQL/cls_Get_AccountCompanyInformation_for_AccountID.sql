
	Select
	  usr_accounts.USR_AccountID,
	  usr_accounts.BusinessParticipant_RefID,
	  cmn_bpt_businessparticipants.IsCompany,
	  usr_accounts.Username,
	  cmn_universalcontactdetails.CompanyName_Line1
	From
	  usr_accounts Inner Join
	  cmn_bpt_businessparticipants On usr_accounts.BusinessParticipant_RefID =
	    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
	  cmn_com_companyinfo
	    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
	    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
	  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
	    cmn_universalcontactdetails.CMN_UniversalContactDetailID
	Where
	  usr_accounts.USR_AccountID = @AccountID And
	  usr_accounts.Tenant_RefID = @TenantID And
	  cmn_bpt_businessparticipants.IsDeleted = 0
  