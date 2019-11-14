
    
Select
  tms_pro_project_notes.TMS_PRO_Project_NoteID,
  tms_pro_project_notes.Project_RefID,
  tms_pro_tags.TMS_PRO_TagID,
  tms_pro_project_note_2_tag.AssignmentID,
  tms_pro_tags.TagValue
  
From
  tms_pro_project_notes Inner Join
  tms_pro_project_note_2_tag On tms_pro_project_note_2_tag.Project_Note_RefID =
    tms_pro_project_notes.TMS_PRO_Project_NoteID Inner Join
  tms_pro_tags On tms_pro_project_note_2_tag.Tag_RefID =
    tms_pro_tags.TMS_PRO_TagID
Where
  tms_pro_project_notes.TMS_PRO_Project_NoteID = @ProjectNoteID And
  tms_pro_project_notes.IsDeleted = 0 And
  tms_pro_tags.IsDeleted = 0 And
  tms_pro_project_note_2_tag.IsDeleted = 0 And
  tms_pro_project_notes.Tenant_RefID = @TenantID
  
  