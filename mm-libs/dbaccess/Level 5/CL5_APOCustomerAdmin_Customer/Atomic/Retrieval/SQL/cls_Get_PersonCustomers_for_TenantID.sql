
Select
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.BirthDate,
  cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID,
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_ctm_availablepaymenttypes.ACC_PAY_Type_RefID,
  cmn_bpt_ctm_customers.InternalCustomerNumber,
  cmn_bpt_ctm_availablepaymentconditions.ACC_PAY_Condition_RefID,
  cmn_bpt_businessparticipants.DisplayName,
  cmn_per_personinfo.IsRepresentedByLegalGuardian,
  `Legal Guardian`.DisplayName As LegalGuardianDisplayName,
  cmn_bpt_ctm_customers.IsCustomerOrderAutomaticallyApprovedOnReceipt,
  COUNT(cmn_bpt_memo_relatedparticipants.CMN_BPT_Memo_RelatedParticipantID) As NumberOfComments
From
  cmn_bpt_businessparticipants Inner Join
  cmn_bpt_ctm_customers On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Left Join
  cmn_bpt_ctm_availablepaymenttypes
    On cmn_bpt_ctm_availablepaymenttypes.Customer_RefID =
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID Left Join
  cmn_bpt_ctm_availablepaymentconditions
    On cmn_bpt_ctm_availablepaymentconditions.Customer_RefID =
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID Left Join
  (Select
    cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID,
    cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID,
    cmn_bpt_businessparticipants.DisplayName
  From
    cmn_bpt_businessparticipant_associatedbusinessparticipants Inner Join
    cmn_bpt_businessparticipants
      On
      cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
  Where
    cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0) `Legal Guardian`
    On `Legal Guardian`.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_tenants On cmn_bpt_businessparticipants.IfTenant_Tenant_RefID =
    cmn_tenants.CMN_TenantID Left Join
  cmn_bpt_memo_relatedparticipants On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_memo_relatedparticipants.CMN_BPT_BusinessParticipant_RefID And cmn_bpt_memo_relatedparticipants.IsDeleted = 0  
Where
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_ctm_customers.IsDeleted = 0 And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
  (cmn_bpt_ctm_availablepaymenttypes.IsDeleted = 0 Or
    cmn_bpt_ctm_availablepaymenttypes.IsDeleted Is Null) And
  (cmn_bpt_ctm_availablepaymentconditions.IsDeleted = 0 Or
    cmn_bpt_ctm_availablepaymentconditions.IsDeleted Is Null) And
  cmn_bpt_businessparticipants.IsTenant = 1 And
  cmn_tenants.IsDeleted = 0
  GROUP BY CMN_BPT_CTM_CustomerID
  