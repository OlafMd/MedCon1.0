
Select
  cmn_per_personinfo.FirstName As Doctor_FirstName,
  cmn_per_personinfo.LastName As Doctor_LastName,
  cmn_per_personinfo.Title As Doctor_Title,
  cmn_bpt_businessparticipants1.DisplayName As CompanyName,
  cmn_bpt_ctm_catalogproductextensionrequests.CMN_BPT_CTM_CatalogProductExtensionRequestID,
  cmn_bpt_ctm_catalogproductextensionrequests.RequestCaseIdentifier,
  cmn_bpt_ctm_catalogproductextensionrequests.CatalogProductExtensionRequestITL,
  cmn_bpt_ctm_catalogproductextensionrequests.RequestedFor_Catalog_RefID,
  cmn_bpt_ctm_catalogproductextensionrequests.RequestedBy_Person_BusinessParticipant_RefID,
  cmn_bpt_ctm_catalogproductextensionrequests.RequestedBy_Customer_BusinessParticipant_RefID,
  cmn_bpt_ctm_catalogproductextensionrequests.Request_Question,
  cmn_bpt_ctm_catalogproductextensionrequests.Request_Answer,
  cmn_bpt_ctm_catalogproductextensionrequests.IsAnswerSent,
  cmn_bpt_ctm_catalogproductextensionrequests.IfAnswerSent_By_BusinessParticipant_RefID,
  cmn_bpt_ctm_catalogproductextensionrequests.IfAnswerSent_Date,
  cmn_bpt_ctm_catalogproductextensionrequests.Creation_Timestamp As RequestDate
From
  cmn_bpt_businessparticipants Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  cmn_bpt_ctm_catalogproductextensionrequests
    On
    cmn_bpt_ctm_catalogproductextensionrequests.RequestedBy_Person_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID =
    cmn_bpt_ctm_catalogproductextensionrequests.RequestedBy_Customer_BusinessParticipant_RefID
Where
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants1.IsCompany = 1 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsTenant = 0 And
  cmn_bpt_businessparticipants1.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_bpt_ctm_catalogproductextensionrequests.IsDeleted = 0 And
  cmn_bpt_ctm_catalogproductextensionrequests.Tenant_RefID = @TenantID
  