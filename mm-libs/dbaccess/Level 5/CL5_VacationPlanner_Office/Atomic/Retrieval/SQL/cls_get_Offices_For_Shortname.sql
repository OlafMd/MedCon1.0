
Select
  cmn_str_offices.CMN_STR_OfficeID,
  cmn_str_offices.Region_RefID,
  cmn_addresses.CMN_AddressID As BillingAddress_CMN_AddressID,
  cmn_addresses.Street_Name As BillingAddress_Street_Name,
  cmn_addresses.Street_Number As BillingAddress_Street_Number,
  cmn_addresses.City_AdministrativeDistrict As
  BillingAddress_City_AdministrativeDistrict,
  cmn_addresses.City_Region As BillingAddress_City_Region,
  cmn_addresses.City_Name As BillingAddress_City_Name,
  cmn_addresses.City_PostalCode As BillingAddress_City_PostalCode,
  cmn_addresses.Province_Name As BillingAddress_Province_Name,
  cmn_addresses.Country_Name As BillingAddress_Country_Name,
  cmn_addresses.Country_ISOCode As BillingAddress_Country_ISOCode,
  cmn_addresses1.CMN_AddressID As ShippingAddress_CMN_AddressID,
  cmn_addresses1.Street_Name As ShippingAddress_Street_Name,
  cmn_addresses1.City_AdministrativeDistrict As
  ShippingAddress_City_AdministrativeDistrict,
  cmn_addresses1.Street_Number As ShippingAddress_Street_Number,
  cmn_addresses1.City_Region As ShippingAddress_City_Region,
  cmn_addresses1.City_Name As ShippingAddress_City_Name,
  cmn_addresses1.Province_Name As ShippingAddress_Province_Name,
  cmn_addresses1.City_PostalCode As ShippingAddress_City_PostalCode,
  cmn_addresses1.Country_Name As ShippingAddress_Country_Name,
  cmn_addresses1.Country_ISOCode As ShippingAddress_Country_ISOCode,
  cmn_str_offices.Default_PhoneNumber,
  cmn_str_offices.Default_FaxNumber,
  cmn_str_offices.Office_Name_DictID,
  cmn_str_offices.Office_Description_DictID,
  cmn_str_offices.Office_ShortName,
  cmn_str_offices.CMN_CAL_CalendarInstance_RefID,
  ResponsiblePersons.CMN_BPT_BusinessParticipantID,
  ResponsiblePersons.CMN_BPT_EMP_EmployeeID,
  ResponsiblePersons.LastName,
  ResponsiblePersons.CMN_STR_Office_ResponsiblePersonID,
  ResponsiblePersons.FirstName,
  cmn_str_costcenters.Name_DictID,
  cmn_str_office_2_costcenter.AssignmentID,
  cmn_str_costcenters.InternalID,
  cmn_str_costcenters.CMN_STR_CostCenterID
From
  cmn_str_offices Left Join
  cmn_addresses On cmn_str_offices.Default_BillingAddress_RefID =
    cmn_addresses.CMN_AddressID Left Join
  cmn_addresses cmn_addresses1 On cmn_str_offices.Default_ShippingAddress_RefID
    = cmn_addresses1.CMN_AddressID Left Join
  (Select
    cmn_str_office_responsiblepersons.CMN_STR_Office_ResponsiblePersonID,
    cmn_per_personinfo.FirstName,
    cmn_per_personinfo.LastName,
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID,
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
    cmn_str_office_responsiblepersons.Office_RefID,
    cmn_str_office_responsiblepersons.IsDeleted,
    cmn_bpt_emp_employees.IsDeleted As IsDeleted1,
    cmn_bpt_businessparticipants.IsDeleted As IsDeleted2,
    cmn_per_personinfo.IsDeleted As IsDeleted3
  From
    cmn_str_office_responsiblepersons Inner Join
    cmn_bpt_emp_employees On cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID =
      cmn_str_office_responsiblepersons.CMN_BPT_EMP_Employee_RefID Inner Join
    cmn_bpt_businessparticipants
      On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
      cmn_bpt_emp_employees.BusinessParticipant_RefID Inner Join
    cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
      cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Where
    cmn_str_office_responsiblepersons.IsDeleted = 0 And
    cmn_bpt_emp_employees.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_per_personinfo.IsDeleted = 0) ResponsiblePersons
    On cmn_str_offices.CMN_STR_OfficeID = ResponsiblePersons.Office_RefID
  Left Join
  cmn_str_office_2_costcenter On cmn_str_office_2_costcenter.Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID Left Join
  cmn_str_costcenters On cmn_str_office_2_costcenter.CostCenter_RefID =
    cmn_str_costcenters.CMN_STR_CostCenterID
Where
  cmn_str_offices.Office_ShortName = @ShortName And
  cmn_addresses.IsDeleted = 0 And
  cmn_str_offices.IsDeleted = 0 And
  cmn_addresses1.IsDeleted = 0 And
  (cmn_str_office_2_costcenter.IsDeleted = 0 Or
    cmn_str_office_2_costcenter.IsDeleted Is Null) And
  (cmn_str_costcenters.IsDeleted = 0 Or
    cmn_str_costcenters.IsDeleted Is Null) And
  cmn_str_offices.Tenant_RefID = @TenantID
  