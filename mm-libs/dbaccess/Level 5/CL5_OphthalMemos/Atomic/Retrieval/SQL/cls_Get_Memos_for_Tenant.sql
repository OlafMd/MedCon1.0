
Select
  cmn_bpt_memos.CMN_BPT_MemoID,
  cmn_bpt_memos.CreatedBy_Account_RefID,
  cmn_bpt_memos.Memo_Title,
  cmn_bpt_memos.Memo_Abbreviation,
  cmn_bpt_memos.Memo_Text,
  cmn_bpt_memos.UpdatedOn,
  cmn_bpt_memos.UpdatedBy_Account_RefID,
  cmn_bpt_memos.Creation_Timestamp,
  cmn_bpt_memo_additionalfields.CMN_BPT_Memo_AdditionalFieldID,
  cmn_bpt_memo_additionalfields.Field_Value,
  cmn_bpt_memo_additionalfields.Field_Key,
  cmn_bpt_memos.DocumentStructureHeader_RefID,
  doc_structures.DOC_StructureID,
  cmn_bpt_memo_relatedparticipants.CMN_BPT_Memo_RelatedParticipantID As
  Doctor_CMN_BPT_Memo_RelatedParticipantID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As
  Doctor_CMN_BPT_BusinessParticipantID,
  cmn_bpt_memo_relatedparticipants1.CMN_BPT_Memo_RelatedParticipantID As
  Practice_CMN_BPT_Memo_RelatedParticipantID,
  cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID As
  Practice_BusinessParticipantID
From
  cmn_bpt_memos Left Join
  cmn_bpt_memo_additionalfields On cmn_bpt_memos.CMN_BPT_MemoID =
    cmn_bpt_memo_additionalfields.Memo_RefID Inner Join
  doc_structures On cmn_bpt_memos.DocumentStructureHeader_RefID =
    doc_structures.Structure_Header_RefID Inner Join
  cmn_bpt_memo_relatedparticipants On cmn_bpt_memos.CMN_BPT_MemoID =
    cmn_bpt_memo_relatedparticipants.CMN_BPT_Memo_RefID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_memo_relatedparticipants.CMN_BPT_BusinessParticipant_RefID
  Inner Join
  cmn_bpt_memo_relatedparticipants cmn_bpt_memo_relatedparticipants1
    On cmn_bpt_memos.CMN_BPT_MemoID =
    cmn_bpt_memo_relatedparticipants1.CMN_BPT_Memo_RefID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On cmn_bpt_memo_relatedparticipants1.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID
Where
  cmn_bpt_memos.IsDeleted = 0 And
  cmn_bpt_memos.Tenant_RefID = @TenantID And
  (cmn_bpt_memo_additionalfields.IsDeleted = 0 Or
    cmn_bpt_memo_additionalfields.IsDeleted Is Null) And
  doc_structures.IsDeleted = 0 And
  cmn_bpt_memo_relatedparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants1.IsCompany = 1 And
  cmn_bpt_memo_relatedparticipants1.IsDeleted = 0 And
  cmn_bpt_businessparticipants1.IsDeleted = 0
Order By
  cmn_bpt_memos.UpdatedOn Desc
  