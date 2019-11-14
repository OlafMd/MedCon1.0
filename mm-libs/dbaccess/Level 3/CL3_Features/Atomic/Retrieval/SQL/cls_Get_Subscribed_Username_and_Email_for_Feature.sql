
	Select
	  cmn_per_personinfo.PrimaryEmail,
	  usr_accounts.Username
	From
	  tms_pro_projectmembers Inner Join
	  cmn_per_personinfo_2_account On tms_pro_projectmembers.USR_Account_RefID =
	    cmn_per_personinfo_2_account.USR_Account_RefID Inner Join
	  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
	  usr_accounts On tms_pro_projectmembers.USR_Account_RefID =
	    usr_accounts.USR_AccountID Inner Join
	  tms_pro_peers_features On tms_pro_peers_features.ProjectMember_RefID =
	    tms_pro_projectmembers.TMS_PRO_ProjectMemberID
	Where
	  tms_pro_projectmembers.IsDeleted = 0 And
	  usr_accounts.IsDeleted = 0 And
	  cmn_per_personinfo_2_account.IsDeleted = 0 And
	  cmn_per_personinfo.IsDeleted = 0 And
	  tms_pro_peers_features.IsDeleted = 0 And
	  tms_pro_peers_features.Feature_RefID = @FeatureID

  