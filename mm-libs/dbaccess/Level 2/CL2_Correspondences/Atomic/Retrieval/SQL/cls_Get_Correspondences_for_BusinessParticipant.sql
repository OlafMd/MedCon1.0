
Select
  cmn_per_personinfo_correspondences.CorrespondenceText,
  cmn_per_personinfo_correspondences.CMN_PER_PersonInfo_CorrespondenceID,
  bp.CMN_BPT_BusinessParticipantID,
  cmn_per_personinfo_correspondences.IsDefaultCorrespondence,
  cmn_per_personinfo_correspondences.CorrespondenceType_RefID
From
  cmn_bpt_ctm_customers Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipant_associatedbusinessparticipants association
    On association.AssociatedBusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    association.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants bp On bp.CMN_BPT_BusinessParticipantID =
    association.BusinessParticipant_RefID And bp.IsDeleted = 0 And
    bp.IsNaturalPerson = 1 Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    bp.IfNaturalPerson_CMN_PER_PersonInfo_RefID And
    cmn_per_personinfo.IsDeleted = 0 Inner Join
  cmn_per_personinfo_correspondences
    On cmn_per_personinfo_correspondences.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And
    cmn_per_personinfo_correspondences.IsDeleted = 0
Where
  cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID = @CustomerID And
  cmn_bpt_ctm_customers.IsDeleted = 0
  