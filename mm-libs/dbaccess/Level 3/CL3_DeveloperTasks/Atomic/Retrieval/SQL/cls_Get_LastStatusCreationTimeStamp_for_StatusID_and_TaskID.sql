
	Select
	  tms_pro_developertask_statushistory.Creation_Timestamp
	From
	  tms_pro_developertask_statushistory Inner Join
	  tms_pro_projectmembers On tms_pro_projectmembers.TMS_PRO_ProjectMemberID =
	    tms_pro_developertask_statushistory.TriggeredBy_ProjectMember_RefID
	Where
	  tms_pro_developertask_statushistory.DeveloperTask_RefID = @DTaskID And
	  tms_pro_developertask_statushistory.DeveloperTask_Status_RefID = @StatusID And
	  tms_pro_projectmembers.USR_Account_RefID = @AccountID
	Order By
	  tms_pro_developertask_statushistory.Creation_Timestamp Desc        
	Limit 1
  