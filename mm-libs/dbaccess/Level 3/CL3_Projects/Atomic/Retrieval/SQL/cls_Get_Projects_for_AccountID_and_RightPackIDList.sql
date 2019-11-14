
    Select Distinct
      tms_pro_projectmembers.TMS_PRO_ProjectMemberID,
      tms_pro_projects.TMS_PRO_ProjectID,
      tms_pro_projects.DOC_Structure_Header_RefID,
      tms_pro_projects.Name_DictID,
      tms_pro_projects.Status_RefID,
      tms_pro_projects.IsArchived,
      tms_pro_projects.Creation_Timestamp,
      tms_pro_projects.Description_DictID,
      tms_pro_members_2_rightpackage.ACC_RightsPackage_RefID
    From
      tms_pro_projectmembers Left Join
      tms_pro_projects On tms_pro_projectmembers.Project_RefID =
        tms_pro_projects.TMS_PRO_ProjectID Inner Join
      tms_pro_members_2_rightpackage
        On tms_pro_members_2_rightpackage.ProjectMember_RefID =
        tms_pro_projectmembers.TMS_PRO_ProjectMemberID
    Where
      (tms_pro_projects.IsArchived = 0 Or
        tms_pro_projects.IsArchived = @isArchived) And
      tms_pro_projects.Tenant_RefID = @TenantID And
      tms_pro_projectmembers.USR_Account_RefID = @AccountID And
      tms_pro_projectmembers.IsDeleted = 0 And
      tms_pro_projects.IsDeleted = 0 And
      tms_pro_members_2_rightpackage.IsDeleted = 0 And
      tms_pro_members_2_rightpackage.ACC_RightsPackage_RefID = @RightPackIDList
  