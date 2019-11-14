
SELECT cmn_per_personinfo_correspondences.CorrespondenceText
	,cmn_per_personinfo_correspondences.CMN_PER_PersonInfo_CorrespondenceID
FROM bil_billheaders
INNER JOIN cmn_bpt_ctm_Customers ON cmn_bpt_ctm_Customers.Ext_BusinessParticipant_RefID = bil_billheaders.BillRecipient_BuisnessParticipant_RefID
	AND  cmn_bpt_ctm_customers.IsDeleted = 0
INNER JOIN cmn_bpt_businessparticipants ON cmn_bpt_ctm_Customers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
	AND cmn_bpt_businessparticipants.IsDeleted = 0
INNER JOIN CMN_BPT_BusinessParticipant_AssociatedBusinessParticipants association ON association.AssociatedBusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
	AND association.IsDeleted = 0
INNER JOIN cmn_bpt_businessparticipants bp ON bp.CMN_BPT_BusinessParticipantID = association.BusinessParticipant_RefID
	AND bp.IsDeleted = 0
	AND bp.IsNaturalPerson = 1
INNER JOIN cmn_per_personinfo ON cmn_per_personinfo.CMN_PER_PersonInfoID = bp.IfNaturalPerson_CMN_PER_PersonInfo_RefID
	AND cmn_per_personinfo.IsDeleted = 0
INNER JOIN cmn_per_personinfo_correspondences ON cmn_per_personinfo_correspondences.CMN_PER_PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID
	AND cmn_per_personinfo_correspondences.IsDeleted = 0
WHERE bil_billheaders.BIL_BillHeaderID = @BillHeaderID
	AND bil_billheaders.IsDeleted = 0
	AND bil_billheaders.Tenant_RefID = @TenantID
  