
	Select
  res_realestateproperties.RES_RealestatePropertyID,
  res_realestateproperties.InformationSubmittedBy_Account_RefID,
  res_realestateproperties.RealestateProperty_Address_RefID,
  res_realestateproperties.RealestateProperty_Location_RefID,
  res_realestateproperties.RealestateProperty_GroundValuePrice_RefID,
  res_realestateproperties.RealestateProperty_AverageAreaRentPrice_RefID,
  res_realestateproperties.Geolocation_Lattitude,
  res_realestateproperties.Geolocation_Longitude,
  res_realestateproperties.RealestateProperty_Title,
  res_realestateproperties.RealestateProperty_InternalID,
  res_realestateproperties.RealestateProperty_ConstructionDate,
  res_realestateproperties.RealestateProperty_RefurbishmentDate,
  res_realestateproperties.RealestateProperty_LivingSpace_in_sqm,
  res_realestateproperties.RealestateProperty_InformationDate,
  res_realestateproperties.RealestateProperty_NumberOfResidentialUnits,
  ConstructionType.AssignmentID As ConstructionTypeAssigmentID,
  ConstructionType.ConstructionType_Name_DictID,
  ConstructionType.ConstructionType_Description_DictID,
  ConstructionType.Comment As ConstructionTypeComment,
  PropertyType.RES_RealestateProperty_TypeID,
  PropertyType.AssignmentID As PropertyTypeAssigment,
  PropertyType.RealestatePropertyType_Name_DictID,
  PropertyType.RealestatePropertyType_Description_DictID,
  PropertyType.Comment As PropertyTypeComment,
  SourceOfInformation.Comment As SourceOfInformationComment,
  SourceOfInformation.SourceOfInformation_Description_DictID,
  SourceOfInformation.SourceOfInformation_Name_DictID,
  SourceOfInformation.AssignmentID As SourceOfInformationAssigmentID,
  SourceOfInformation.RES_RealestateProperty_SourceOfInformationID,
  ConstructionType.RES_RealestateProperty_ConstructionTypeID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  usr_accounts.Username,
  res_realestateproperties.RealestateProperty_GroundAreaSize_in_sqm
From
  res_realestateproperties Left Join
  (Select
    res_realestateproperty_constructiontypes.ConstructionType_Name_DictID,
    res_realestateproperty_constructiontypes.ConstructionType_Description_DictID,
    res_realestateproperty_2_propertyconstructiontype.AssignmentID,
    res_realestateproperty_2_propertyconstructiontype.Comment,
    res_realestateproperty_constructiontypes.IsDeleted,
    res_realestateproperty_constructiontypes.Tenant_RefID,
    res_realestateproperty_2_propertyconstructiontype.RES_RealestateProperty_RefID,
    res_realestateproperty_constructiontypes.RES_RealestateProperty_ConstructionTypeID
  From
    res_realestateproperty_constructiontypes Inner Join
    res_realestateproperty_2_propertyconstructiontype
      On
      res_realestateproperty_constructiontypes.RES_RealestateProperty_ConstructionTypeID = res_realestateproperty_2_propertyconstructiontype.RES_RealestateProperty_ConstructionType_RefID
  Where
    res_realestateproperty_constructiontypes.IsDeleted = 0 And
    res_realestateproperty_constructiontypes.Tenant_RefID = @TenantID And
    res_realestateproperty_2_propertyconstructiontype.IsDeleted =
    0) ConstructionType On ConstructionType.RES_RealestateProperty_RefID =
    res_realestateproperties.RES_RealestatePropertyID Left Join
  (Select
    res_realestateproperty_types.RES_RealestateProperty_TypeID,
    res_realestateproperty_types.RealestatePropertyType_Name_DictID,
    res_realestateproperty_types.RealestatePropertyType_Description_DictID,
    res_realestateproperty_2_propertytype.AssignmentID,
    res_realestateproperty_2_propertytype.Comment,
    res_realestateproperty_2_propertytype.IsDeleted,
    res_realestateproperty_types.IsDeleted As IsDeleted1,
    res_realestateproperty_2_propertytype.Tenant_RefID,
    res_realestateproperty_2_propertytype.RES_RealestateProperty_RefID
  From
    res_realestateproperty_2_propertytype Inner Join
    res_realestateproperty_types
      On res_realestateproperty_types.RES_RealestateProperty_TypeID =
      res_realestateproperty_2_propertytype.RES_RealestateProperty_Type_RefID
  Where
    res_realestateproperty_2_propertytype.IsDeleted = 0 And
    res_realestateproperty_types.IsDeleted = 0 And
    res_realestateproperty_2_propertytype.Tenant_RefID = @TenantID) PropertyType
    On PropertyType.RES_RealestateProperty_RefID =
    res_realestateproperties.RES_RealestatePropertyID Left Join
  (Select
    res_realestateproperty_sourceofinformation.RES_RealestateProperty_SourceOfInformationID,
    res_realestateproperty_sourceofinformation.SourceOfInformation_Name_DictID,
    res_realestateproperty_sourceofinformation.SourceOfInformation_Description_DictID,
    res_realestateproperty_2_propertysourceofinformation.AssignmentID,
    res_realestateproperty_2_propertysourceofinformation.Comment,
    res_realestateproperty_2_propertysourceofinformation.RES_RealestateProperty_RefID,
    res_realestateproperty_sourceofinformation.IsDeleted,
    res_realestateproperty_2_propertysourceofinformation.IsDeleted As
    IsDeleted1,
    res_realestateproperty_sourceofinformation.Tenant_RefID
  From
    res_realestateproperty_sourceofinformation Inner Join
    res_realestateproperty_2_propertysourceofinformation
      On
      res_realestateproperty_sourceofinformation.RES_RealestateProperty_SourceOfInformationID = res_realestateproperty_2_propertysourceofinformation.RES_RealestateProperty_SourceOfInformation_RefID
  Where
    res_realestateproperty_sourceofinformation.IsDeleted = 0 And
    res_realestateproperty_2_propertysourceofinformation.IsDeleted = 0 And
    res_realestateproperty_sourceofinformation.Tenant_RefID = @TenantID)
  SourceOfInformation On SourceOfInformation.RES_RealestateProperty_RefID =
    res_realestateproperties.RES_RealestatePropertyID Inner Join
  usr_accounts
    On usr_accounts.USR_AccountID =
    res_realestateproperties.InformationSubmittedBy_Account_RefID Inner Join
  cmn_per_personinfo_2_account On cmn_per_personinfo_2_account.USR_Account_RefID
    = usr_accounts.USR_AccountID Inner Join
  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID
Where
  res_realestateproperties.RES_RealestatePropertyID = @RealestatePropertyID And
  res_realestateproperties.IsDeleted = 0
  