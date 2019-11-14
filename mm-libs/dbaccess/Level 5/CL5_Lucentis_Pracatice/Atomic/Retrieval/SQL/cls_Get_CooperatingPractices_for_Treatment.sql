
Select
  cmn_bpt_businessparticipants.DisplayName,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID As
  CMN_BPT_Coopearting_BusinessParticipantID,
  cmn_bpt_businessparticipants1.DisplayName As CooperatingPracticeName
From
  cmn_bpt_businessparticipants Left Join
  cmn_bpt_businessparticipant_associatedbusinessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID And cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On
    cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And cmn_bpt_businessparticipants1.IsDeleted = 0
Where
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = @BussinessID And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants1.IsCompany = 1 And
  cmn_bpt_businessparticipants.IsCompany = 1 And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
	