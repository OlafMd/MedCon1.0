
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.Title,
  cmn_per_personinfo.Salutation_General,
  cmn_per_personinfo.Salutation_Letter,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  usr_accounts.USR_AccountID,
  usr_device_accountcodes.USR_Device_AccountCodeID,
  hec_doctors.HEC_DoctorID,
  usr_device_accountcodes.AccountCode_Value,
  hec_doctors.Tenant_RefID
From
  cmn_bpt_businessparticipants Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Inner Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  usr_device_accountcodes On usr_device_accountcodes.Account_RefID =
    usr_accounts.USR_AccountID Inner Join
  usr_device_accountcode_statushistory
    On usr_device_accountcodes.AccountCode_CurrentStatus_RefID =
    usr_device_accountcode_statushistory.USR_Device_AccountCode_StatusHistoryID
  Inner Join
  hec_doctors On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
Where
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  usr_accounts.AccountType = 3 And
  usr_accounts.IsDeleted = 0 And
  usr_device_accountcode_statushistory.IsDeleted = 0 And
  usr_device_accountcodes.IsDeleted = 0 And
  hec_doctors.IsDeleted = 0 And
  usr_device_accountcodes.AccountCode_Value = @DeviceCode And
  usr_device_accountcode_statushistory.IsAccountCode_Active = 1
  