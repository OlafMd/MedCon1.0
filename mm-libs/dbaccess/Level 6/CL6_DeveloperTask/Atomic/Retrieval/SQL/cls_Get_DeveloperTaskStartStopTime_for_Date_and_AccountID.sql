
  
  Select
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID,   
  tms_pro_developertasks.IdentificationNumber,
  tms_pro_developertasks.Name,
  tms_pro_developertask_statushistory.Creation_Timestamp As Start_Time,
  (Select Min(sth.Creation_Timestamp) As endTime
     From tms_pro_developertask_statushistory As sth Join tms_pro_developertask_statuses As sths On sth.DeveloperTask_Status_RefID =
      sths.TMS_PRO_DeveloperTask_StatusID  Where
      sth.DeveloperTask_RefID = tms_pro_developertasks.TMS_PRO_DeveloperTaskID And
      sth.Creation_Timestamp >  tms_pro_developertask_statushistory.Creation_Timestamp And
      (sths.GlobalPropertyMatchingID = @StatusStopped or sths.GlobalPropertyMatchingID=@StatusFinished)) As End_Time,
  tms_pro_developertask_statuses.Label_DictID as StatusName
 
From
  tms_pro_developertask_statuses Left Join
  tms_pro_developertask_statushistory
    On tms_pro_developertask_statushistory.DeveloperTask_Status_RefID =
    tms_pro_developertask_statuses.TMS_PRO_DeveloperTask_StatusID  Join
  tms_pro_developertasks On tms_pro_developertasks.TMS_PRO_DeveloperTaskID =
    tms_pro_developertask_statushistory.DeveloperTask_RefID Inner Join
  tms_pro_projectmembers
    On tms_pro_developertask_statushistory.TriggeredBy_ProjectMember_RefID =
    tms_pro_projectmembers.TMS_PRO_ProjectMemberID
Where
  Date(tms_pro_developertask_statushistory.Creation_Timestamp)= Date(@DateTime)
   And
  tms_pro_developertask_statuses.GlobalPropertyMatchingID = @StatusStarted And
  tms_pro_developertasks.IsDeleted = 0 And
  tms_pro_projectmembers.USR_Account_RefID = @AccountID And
  tms_pro_developertask_statuses.Tenant_RefID = @TenantID
Order By
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID,
  tms_pro_developertask_statushistory.Creation_Timestamp
  

  
