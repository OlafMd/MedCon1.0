
	select cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
	         cmn_bpt_businessparticipants.IsDeleted,
		       cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID,
		       cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedParticipant_FunctionName,
		       cmn_per_personinfo.CMN_PER_PersonInfoID,
		       cmn_per_personinfo.FirstName,
		       cmn_per_personinfo.LastName,
		       cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID,
	         cmn_per_communicationcontact_types.Type CommunicationContact_Type,
		       cmn_per_communicationcontacts.Content as cmn_per_communicationcontacts_Content,
		       cmn_addresses.CMN_AddressID,
		       cmn_addresses.Street_Name,
		       cmn_addresses.Street_Number,
		       cmn_addresses.City_Name,
		       cmn_addresses.City_PostalCode,
		       cmn_addresses.Country_ISOCode,
           cmn_addresses.CareOf
		from cmn_bpt_businessparticipants
		     inner join cmn_bpt_businessparticipant_associatedbusinessparticipants on cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID and cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0
		     left join cmn_per_personinfo on cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID and cmn_per_personinfo.IsDeleted = 0
		     left join cmn_per_communicationcontacts on cmn_per_personinfo.CMN_PER_PersonInfoID = cmn_per_communicationcontacts.PersonInfo_RefID and cmn_per_communicationcontacts.IsDeleted = 0
	       left join cmn_per_communicationcontact_types on cmn_per_communicationcontacts.Contact_Type = cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID and cmn_per_communicationcontact_types.IsDeleted = 0
		     left join cmn_addresses on cmn_per_personinfo.Address_RefID = cmn_addresses.CMN_AddressID and cmn_addresses.IsDeleted = 0
		where cmn_bpt_businessparticipants.IsDeleted = 0 
		      and cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
		      and cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = @BusinessParticipantID
          and cmn_bpt_businessparticipants.IsNaturalPerson = 1
  