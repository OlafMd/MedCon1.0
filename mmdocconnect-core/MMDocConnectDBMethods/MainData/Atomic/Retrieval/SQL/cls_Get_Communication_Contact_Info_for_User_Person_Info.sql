
Select
  cmn_per_communicationcontacts.Content,
  cmn_per_communicationcontacts.CMN_PER_CommunicationContactID,
  cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID
From
  cmn_per_communicationcontacts Inner Join
  cmn_per_communicationcontact_types
    On cmn_per_communicationcontacts.Contact_Type =
    cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID And
    cmn_per_communicationcontact_types.IsDeleted = 0 And
    cmn_per_communicationcontact_types.Tenant_RefID = @TenantID
Where
  cmn_per_communicationcontact_types.Type = @CommunicationType And
  cmn_per_communicationcontacts.IsDeleted = False And
  cmn_per_communicationcontacts.Tenant_RefID = @TenantID And
    cmn_per_communicationcontacts.PersonInfo_RefID = @PersonRefID
  