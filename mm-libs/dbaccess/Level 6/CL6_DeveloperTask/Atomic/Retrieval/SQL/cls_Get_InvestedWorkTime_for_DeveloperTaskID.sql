
    Select
  cmn_bpt_investedworktimes.WorkTime_Amount_min As InvestedWorkTime,
  usr_accounts.USR_AccountID
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
    cmn_bpt_investedworktimes.BusinessParticipant_RefID
Where
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID = @DeveloperTaskID And
  tms_pro_developertasks.Tenant_RefID = @TenantID

  