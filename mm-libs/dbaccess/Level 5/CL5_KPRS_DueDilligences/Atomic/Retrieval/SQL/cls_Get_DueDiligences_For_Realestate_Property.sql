
Select
  res_dud_revisiongroup.RES_DUD_Revision_GroupID,
  res_dud_revisiongroup.RevisionGroup_Name,
  res_dud_revisiongroup.RevisionGroup_SubmittedBy_Account_RefID,
  res_dud_revisiongroup.Creation_Timestamp,
  Buildings.Building_Name,
  res_dud_revisiongroup.Tenant_RefID,
  res_dud_revisiongroup.IsDeleted,
  res_dud_revisiongroup.RealestateProperty_RefID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  Buildings.RES_BLD_BuildingID,
  Buildings.RES_DUD_RevisionID,
  Buildings.QuestionnaireVersion_RefID,
  res_dud_revisiongroup.RevisionGroup_Comment
From
  res_dud_revisiongroup Left Join
  (Select
    res_bld_buildings.Building_Name,
    res_dud_revisions.RevisionGroup_RefID,
    res_dud_revisions.RES_DUD_RevisionID,
    res_bld_buildings.RES_BLD_BuildingID,
    res_dud_revisions.QuestionnaireVersion_RefID,
    res_qst_questionnaire_version.IsDeleted,
    res_qst_questionnaire_version.Tenant_RefID
  From
    res_bld_buildings Inner Join
    res_dud_revisions On res_dud_revisions.RES_BLD_Building_RefID =
      res_bld_buildings.RES_BLD_BuildingID Inner Join
    res_qst_questionnaire_version
      On res_qst_questionnaire_version.RES_QST_Questionnaire_VersionID =
      res_dud_revisions.QuestionnaireVersion_RefID
  Where
    res_bld_buildings.IsDeleted = 0 And
    res_dud_revisions.IsDeleted = 0 And
    res_qst_questionnaire_version.IsDeleted = 0 And
    res_qst_questionnaire_version.Tenant_RefID = @TenantID) Buildings
    On Buildings.RevisionGroup_RefID =
    res_dud_revisiongroup.RES_DUD_Revision_GroupID Inner Join
  cmn_per_personinfo_2_account
    On res_dud_revisiongroup.RevisionGroup_SubmittedBy_Account_RefID =
    cmn_per_personinfo_2_account.USR_Account_RefID Inner Join
  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID
Where
  res_dud_revisiongroup.Tenant_RefID = @TenantID And
  res_dud_revisiongroup.IsDeleted = 0 And
  res_dud_revisiongroup.RealestateProperty_RefID = @RealEstatePropertyID
  