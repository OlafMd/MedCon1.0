
Select
  cmn_bpt_investedworktimes.WorkTime_Amount_min,
  tms_pro_projects.Name_DictID,
  tms_pro_projects.TMS_PRO_ProjectID,
  tms_pro_developertasks.IdentificationNumber,
  cmn_bpt_investedworktimes.WorkTime_Start,
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID,
  tms_pro_developertasks.Name As DeveloperTask_Name,
  tms_pro_developertasks.Description As DeveloperTask_Description,
  tms_pro_developertasks.DeveloperTask_Type_RefID
From
  tms_pro_developertasks Inner Join
  tms_pro_developertask_involvements
    On tms_pro_developertasks.TMS_PRO_DeveloperTaskID =
    tms_pro_developertask_involvements.DeveloperTask_RefID Inner Join
  tms_pro_developertask_involvements_investedworktime
    On
    tms_pro_developertask_involvements_investedworktime.TMS_PRO_DeveloperTask_Involvement_RefID = tms_pro_developertask_involvements.TMS_PRO_DeveloperTask_InvolvementID Inner Join
  cmn_bpt_investedworktimes
    On
    tms_pro_developertask_involvements_investedworktime.CMN_BPT_InvestedWorkTime_RefID = cmn_bpt_investedworktimes.CMN_BPT_InvestedWorkTimeID Inner Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_investedworktimes.BusinessParticipant_RefID Inner Join
  tms_pro_projects On tms_pro_developertasks.Project_RefID =
    tms_pro_projects.TMS_PRO_ProjectID
Where
  cmn_bpt_investedworktimes.IsDeleted = 0 And
  cmn_bpt_investedworktimes.Tenant_RefID = @TenantID And
  tms_pro_developertasks.Tenant_RefID = @TenantID And
  tms_pro_developertask_involvements_investedworktime.IsDeleted = 0 And
  Date(cmn_bpt_investedworktimes.WorkTime_Start) = Date(@StartDate) And
  usr_accounts.USR_AccountID = @AccountID
  