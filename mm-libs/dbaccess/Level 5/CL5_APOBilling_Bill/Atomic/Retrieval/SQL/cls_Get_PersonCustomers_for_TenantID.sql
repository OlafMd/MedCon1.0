
Select
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.BirthDate,
  cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID,
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_ctm_availablepaymenttypes.ACC_PAY_Type_RefID,
  cmn_bpt_businessparticipants.DisplayName,
  LegalGuardian.DisplayName As LegalGuardian,
  cmn_bpt_ctm_customers.InternalCustomerNumber
From
  cmn_bpt_businessparticipants Inner Join
  cmn_bpt_ctm_customers On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  cmn_bpt_ctm_availablepaymenttypes
    On cmn_bpt_ctm_availablepaymenttypes.Customer_RefID =
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID Left Join
  cmn_bpt_businessparticipant_associatedbusinessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID And cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipants LegalGuardian
    On
    cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = LegalGuardian.CMN_BPT_BusinessParticipantID And LegalGuardian.IsDeleted = 0
Where
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_ctm_customers.IsDeleted = 0 And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
  cmn_bpt_ctm_availablepaymenttypes.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsTenant = 1
  