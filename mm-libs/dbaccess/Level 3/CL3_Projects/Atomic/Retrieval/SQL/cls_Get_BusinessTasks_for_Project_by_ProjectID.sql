
    
Select
  tms_pro_businesstasks.TMS_PRO_BusinessTaskID,
  tms_pro_businesstasks.Task_Name_DictID
From
  tms_pro_projects Right Join
  tms_pro_businesstasks On tms_pro_projects.TMS_PRO_ProjectID =
    tms_pro_businesstasks.Project_RefID
Where
  tms_pro_projects.TMS_PRO_ProjectID = @ProjectID And
  tms_pro_businesstasks.IsArchived = 0 And
  tms_pro_businesstasks.IsDeleted = 0
  
  