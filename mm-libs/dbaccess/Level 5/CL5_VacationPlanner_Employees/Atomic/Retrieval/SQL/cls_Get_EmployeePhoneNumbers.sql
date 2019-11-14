
	Select
  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID,
  cmn_per_communicationcontacts.Content,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.Title,
  cmn_per_personinfo.BirthDate,
  cmn_per_personinfo.Address_RefID,
  cmn_per_personinfo.ProfileImage_Document_RefID,
  cmn_per_personinfo.Creation_Timestamp,
  cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID,
  cmn_per_communicationcontacts.CMN_PER_CommunicationContactID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_per_communicationcontact_types.Type,
  cmn_per_personinfo.CMN_PER_PersonInfoID
From
  cmn_bpt_emp_employees Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_emp_employees.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Inner Join
  cmn_per_communicationcontacts On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_communicationcontacts.PersonInfo_RefID Inner Join
  cmn_per_communicationcontact_types
    On cmn_per_communicationcontacts.Contact_Type =
    cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID
Where
  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID = @EmployeeID And
  cmn_per_communicationcontacts.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_emp_employees.IsDeleted = 0
  