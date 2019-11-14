
Select
  hec_doctors.HEC_DoctorID,
  doc_documenttemplate_2_businessparticipant.DOC_DocumentTemplate_Instance_RefID,
  doc_documenttemplate_2_businessparticipant.AssignmentID,
  doc_documenttemplate_2_businessparticipant.IsDeleted,
  hec_doctors.Tenant_RefID,
  doc_documenttemplate_2_businessparticipant.Modification_Timestamp,
  hec_doctors.Modification_Timestamp As Modification_Timestamp1,
  doc_documenttemplate_2_businessparticipant.Creation_Timestamp,
  hec_doctors.Creation_Timestamp As Creation_Timestamp1
From
  doc_documenttemplate_2_businessparticipant Inner Join
  hec_doctors
    On
    doc_documenttemplate_2_businessparticipant.CMN_BPT_BusinessParticipant_RefID
    = hec_doctors.BusinessParticipant_RefID
Where
  hec_doctors.IsDeleted = 0 And
  doc_documenttemplate_2_businessparticipant.IsDeleted = 0 And
  hec_doctors.Tenant_RefID = @Tenant
  