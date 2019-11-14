
Select
  cmn_bpt_businessparticipant_groups.CMN_BPT_BusinessParticipant_GroupID,
  cmn_bpt_businessparticipant_groups.BusinessParticipantGroup_Name_DictID,
  cmn_bpt_businessparticipant_groups.BusinessParticipantGroup_Description_DictID,
  cmn_bpt_businessparticipant_2_businessparticipantgroup.AssignmentID,
  cmn_bpt_businessparticipant_2_businessparticipantgroup.CMN_BPT_BusinessParticipant_RefID,
  cmn_bpt_businessparticipant_2_businessparticipantgroup.CMN_BPT_BusinessParticipant_Group_RefID,
  cmn_bpt_businessparticipant_2_businessparticipantgroup.IsDeleted
From
  cmn_bpt_businessparticipant_groups Left Join
  cmn_bpt_businessparticipant_2_businessparticipantgroup
    On cmn_bpt_businessparticipant_groups.CMN_BPT_BusinessParticipant_GroupID =
    cmn_bpt_businessparticipant_2_businessparticipantgroup.CMN_BPT_BusinessParticipant_Group_RefID
     And
    (cmn_bpt_businessparticipant_2_businessparticipantgroup.IsDeleted Is Null Or
    cmn_bpt_businessparticipant_2_businessparticipantgroup.IsDeleted = 0)
Where
    cmn_bpt_businessparticipant_groups.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipant_groups.IsDeleted = 0 
  
  
  
  