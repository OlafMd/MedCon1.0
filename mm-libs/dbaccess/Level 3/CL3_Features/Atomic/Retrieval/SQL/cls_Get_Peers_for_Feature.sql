
  Select
    cmn_per_personinfo.PrimaryEmail,
    cmn_per_personinfo.FirstName,
    cmn_per_personinfo.LastName,
	tms_pro_projectmembers.TMS_PRO_ProjectMemberID
  From
    tms_pro_peers_businesstask Inner Join
    tms_pro_projectmembers On tms_pro_peers_businesstask.ProjectMember_RefID =
      tms_pro_projectmembers.TMS_PRO_ProjectMemberID Inner Join
    cmn_per_personinfo_2_account On tms_pro_projectmembers.USR_Account_RefID =
      cmn_per_personinfo_2_account.USR_Account_RefID Inner Join
    cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
      cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
    tms_pro_businesstask_2_feature
      On tms_pro_businesstask_2_feature.BusinessTask_RefID =
      tms_pro_peers_businesstask.BusinessTask_RefID
  Where
    tms_pro_businesstask_2_feature.Feature_RefID = @FeatureID And
    cmn_per_personinfo_2_account.IsDeleted = 0 And
    cmn_per_personinfo.IsDeleted = 0 And
    tms_pro_projectmembers.IsDeleted = 0 And
    tms_pro_peers_businesstask.IsDeleted = 0 And
    tms_pro_businesstask_2_feature.IsDeleted = 0
  Union
  Select
    cmn_per_personinfo.PrimaryEmail,
    cmn_per_personinfo.FirstName,
    cmn_per_personinfo.LastName,
	tms_pro_projectmembers.TMS_PRO_ProjectMemberID
  From
    tms_pro_peers_features Inner Join
    tms_pro_projectmembers On tms_pro_peers_features.ProjectMember_RefID =
      tms_pro_projectmembers.TMS_PRO_ProjectMemberID Inner Join
    cmn_per_personinfo_2_account On tms_pro_projectmembers.USR_Account_RefID =
      cmn_per_personinfo_2_account.USR_Account_RefID Inner Join
    cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
      cmn_per_personinfo.CMN_PER_PersonInfoID
  Where
    tms_pro_peers_features.Feature_RefID = @FeatureID And
    tms_pro_peers_features.IsDeleted = 0 And
    tms_pro_projectmembers.IsDeleted = 0 And
    cmn_per_personinfo_2_account.IsDeleted = 0 And
    cmn_per_personinfo.IsDeleted = 0
  