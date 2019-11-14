
  select 
    tms_pro_projectmembers.TMS_PRO_ProjectMemberID as MemberID, cmn_per_personinfo.FirstName, cmn_per_personinfo.LastName
  from
    tms_pro_projectmembers     
  inner join
    tms_pro_projects
  on
    tms_pro_projectmembers.Project_RefID = tms_pro_projects.tms_pro_projectid and
    tms_pro_projectmembers.Tenant_RefID = tms_pro_projects.Tenant_RefID and
    tms_pro_projects.IsDeleted = 0
  inner join
    cmn_per_personinfo_2_account   
  on
    cmn_per_personinfo_2_account.USR_Account_RefID = tms_pro_projectmembers.USR_Account_RefID and
    tms_pro_projectmembers.Tenant_RefID = cmn_per_personinfo_2_account.Tenant_RefID and
    cmn_per_personinfo_2_account.IsDeleted = 0
  inner join    
    cmn_per_personinfo
  on
    cmn_per_personinfo.CMN_PER_PersonInfoID = cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID and
    cmn_per_personinfo_2_account.Tenant_RefID = cmn_per_personinfo.Tenant_RefID and
    cmn_per_personinfo.IsDeleted = 0
  where 
    tms_pro_projects.tms_pro_projectid = @ProjectID and
    tms_pro_projectmembers.isdeleted = 0 and
    cmn_per_personinfo.isdeleted = 0 and
    tms_pro_projects.Tenant_RefID = @TenantID
  
  