
        Select
  tms_pro_projects.CreatedByAccount_RefID,
  tms_pro_projects.Creation_Timestamp,
  tms_pro_projects.TMS_PRO_ProjectID,
  usr_accounts.Username,
  usr_accounts.Tenant_RefID,
  usr_accounts.IsDeleted,
  tms_pro_projects.IsDeleted As IsDeleted1
From
    tms_pro_projects Inner Join
    usr_accounts
    On usr_accounts.USR_AccountID = tms_pro_projects.CreatedByAccount_RefID  
where 
    usr_accounts.IsDeleted= 0 And 
    tms_pro_projects.IsDeleted = 0 And 
    tms_pro_projects.Tenant_RefID = @TenantID
     

  