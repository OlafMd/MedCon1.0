
Select
  doc_documenttemplate_instances.Source_DocumentTemplate_RefID,
  doc_documenttemplate_instances.DisplayName,
  doc_documenttemplate_instances.InstanceContent,
  doc_documenttemplate_2_businessparticipant.CMN_BPT_BusinessParticipant_RefID,
  doc_documenttemplate_instances.DOC_DocumentTemplate_InstanceID,
  doc_documenttemplate_instances.Modification_Timestamp,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.Title
From
  doc_documenttemplate_instances Inner Join
  doc_documenttemplate_2_businessparticipant
    On doc_documenttemplate_instances.DOC_DocumentTemplate_InstanceID =
    doc_documenttemplate_2_businessparticipant.DOC_DocumentTemplate_Instance_RefID And doc_documenttemplate_2_businessparticipant.Tenant_RefID = @TenantID And doc_documenttemplate_2_businessparticipant.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants
    On
    doc_documenttemplate_2_businessparticipant.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID
Where
  doc_documenttemplate_instances.Tenant_RefID = @TenantID And
  doc_documenttemplate_instances.IsDeleted = 0
  