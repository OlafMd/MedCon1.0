
	Select
  res_dud_revisions.RES_DUD_RevisionID,
  res_dud_revisions.RevisionGroup_RefID,
  res_dud_revisions.RES_BLD_Building_RefID,
  res_dud_revisions.Revision_Comment,
  res_dud_revisions.Revision_Title,
  res_dud_revisions.ScopeOfInspectionIncludes_Internal,
  res_dud_revisions.ScopeOfInspectionIncludes_External,
  res_dud_revisions.QuestionnaireVersion_RefID,
  Appartments.RES_BLD_ApartmentID,
  Appartments.RES_STR_ApartmentID,
  Appartments.RES_STR_Apartment_PropertyAssessmentID,
  Appartments.RES_STR_Apartment_PropertyID,
  Appartments.RES_STR_Apartment_RequiredActionID,
  Appartments.RES_BLD_Apartment_Type_RefID,
  Appartments.ApartmentType_RefID,
  Appartments.ApartmentSize_Value,
  Appartments.IsAppartment_ForRent,
  Appartments.ApartmentSize_Unit_RefID,
  Appartments.AverageRating_RefID,
  Appartments.Rating_RefID,
  Appartments.Appartmnet_AssessmentComment,
  Appartments.ApartmentProperty_Name_DictID,
  Appartments.SelectedActionVersion_RefID,
  res_bld_buildings.RES_BLD_BuildingID,
  res_bld_buildings.Building_BalconyPortionPercent,
  res_bld_buildings.Building_Name,
  res_bld_buildings.Building_DocumentationStructure_RefID,
  res_bld_buildings.Creation_Timestamp,
  res_bld_buildings.IsContaminationSuspected,
  res_bld_buildings.Building_NumberOfFloors,
  res_bld_buildings.Building_ElevatorCoveragePercent,
  res_bld_buildings.Building_NumberOfAppartments,
  res_bld_buildings.Building_NumberOfOccupiedAppartments,
  res_bld_buildings.Building_NumberOfOffices,
  res_bld_buildings.Building_NumberOfRetailUnits,
  res_bld_buildings.Building_NumberOfProductionUnits,
  res_bld_buildings.Building_NumberOfOtherUnits,
  res_bld_buildings.Building_CurrentAverageRentPrice_per_sqm_RefID,
  res_bld_buildings.BuildingRevisionHeader_RefID,
  Attic.RES_BLD_AtticID,
  Attic.RES_STR_AtticID,
  Attic.RES_STR_Attic_PropertyAssessmentID,
  Attic.RES_STR_Attic_RequiredActionID,
  Attic.RES_BLD_Attic_Type_RefID,
  Attic.AverageRating_RefID As AverageRating_RefID1,
  Attic.Rating_RefID As Rating_RefID1,
  Attic.Attic_AssessmentComment,
  Attic.AtticProperty_Name_DictID,
  Attic.SelectedActionVersion_RefID As SelectedActionVersion_RefID1,
  Facades.SelectedActionVersion_RefID As SelectedActionVersion_RefID2,
  Facades.FacadeProperty_Name_DictID,
  Facades.Rating_RefID As Rating_RefID2,
  Facades.Facade_AssessmentComment,
  Facades.AverageRating_RefID As AverageRating_RefID2,
  Facades.RES_BLD_Facade_Type_RefID,
  Facades.RES_STR_Facade_RequiredActionID,
  Facades.RES_STR_Facade_PropertyID,
  Facades.RES_STR_Facade_PropertyAssessmentID,
  Facades.RES_STR_FacadeID,
  Facades.REL_BLD_FacadeID,
  Outdoor_Facilities.RES_BLD_OutdoorFacilityID,
  Outdoor_Facilities.RES_STR_OutdoorFacilityID,
  Outdoor_Facilities.RES_STR_OutdoorFacility_PropertyAssessmentID,
  Outdoor_Facilities.RES_STR_OutdoorFacility_PropertyID,
  Outdoor_Facilities.RES_STR_OutdoorFacility_RequiredActionID,
  Outdoor_Facilities.NumberOfGaragePlaces,
  Outdoor_Facilities.NumberOfRentedGaragePlaces,
  Outdoor_Facilities.RES_BLD_OutdoorFacility_Type_RefID,
  Outdoor_Facilities.AverageRating_RefID As AverageRating_RefID3,
  Outdoor_Facilities.Rating_RefID As Rating_RefID3,
  Outdoor_Facilities.Outdoor_AssessmentComment,
  Outdoor_Facilities.OutdoorFacilityProperty_Name_DictID,
  Outdoor_Facilities.SelectedActionVersion_RefID As
  SelectedActionVersion_RefID3,
  Staircases.RES_BLD_StaircaseID,
  Staircases.RES_STR_StaircaseID,
  Staircases.RES_STR_Staircase_PropertyAssessmentID,
  Staircases.RES_STR_Staircase_PropertyID,
  Staircases.RES_STR_Staircase_RequiredActionID,
  Staircases.StaircaseSize_Unit_RefID,
  Staircases.StaircaseSize_Value,
  Staircases.RES_BLD_Staircase_Type_RefID,
  Staircases.AverageRating_RefID As AverageRating_RefID4,
  Staircases.Rating_RefID As Rating_RefID4,
  Staircases.Staircase_AssessmentComment,
  Staircases.StaircaseProperty_Name_DictID,
  Staircases.SelectedActionVersion_RefID As SelectedActionVersion_RefID4,
  HVACR.RES_BLD_HVACRID,
  HVACR.RES_STR_HVACRID,
  HVACR.RES_STR_HVACR_PropertyAssessmentID,
  HVACR.RES_STR_HVACR_PropertyID,
  HVACR.RES_STR_HVACR_RequiredActionID,
  HVACR.RES_BLD_HVACR_Type_RefID,
  HVACR.AverageRating_RefID As AverageRating_RefID6,
  HVACR.Rating_RefID As Rating_RefID6,
  HVACR.HVACR__AssessmentComment,
  HVACR.HVACRProperty_Name_DictID,
  HVACR.SelectedActionVersion_RefID As SelectedActionVersion_RefID6,
  Roof.RES_BLD_RoofID,
  Roof.RES_STR_Roof_PropertyAssessmentID,
  Roof.RES_STR_RoofID,
  Roof.RES_STR_Roof_PropertyID,
  Roof.RES_STR_Roof_RequiredActionID,
  Roof.RES_BLD_Roof_Type_RefID,
  Roof.AverageRating_RefID As AverageRating_RefID7,
  Roof.Rating_RefID As Rating_RefID7,
  Roof.Rood_AssessmentComment,
  Roof.RoofProperty_Name_DictID,
  Roof.SelectedActionVersion_RefID As SelectedActionVersion_RefID7,
  Questionnaires.RES_QST_QuestionnaireID,
  Questionnaires.RES_QST_Questionnaire_VersionID,
  Questionnaires.RES_QST_OutdoorFacility_AvailablePropertyID,
  Questionnaires.RES_QST_Staircase_AvailablePropertyID,
  Questionnaires.RES_QST_Roof_AvailablePropertyID,
  Questionnaires.RES_QST_Facade_AvailablePropertyID,
  Questionnaires.RES_QST_Attic_AvailablePropertyID,
  Questionnaires.RES_QST_Basement_AvailablePropertyID,
  Questionnaires.RES_QST_Apartment_AvailablePropertyID,
  Questionnaires.RES_QST_HVACR_AvailablePropertyID,
  Questionnaires.Questionnaire_Name_DictID,
  Questionnaires.Questionnaire_Description_DictID,
  Questionnaires.QuestionnaireVersion_Comment,
  Questionnaires.QuestionnaireVersion_VersionNumber,
  Questionnaires.IsApartmentStructureVisible,
  Questionnaires.IsStaircaseStructureVisible,
  Questionnaires.IsOutdoorFacilityVisible,
  Questionnaires.IsFacadeVisible,
  Questionnaires.IsRoofVisible,
  Questionnaires.IsBasementVisible,
  Questionnaires.IsHVACRVisible,
  Questionnaires.RES_STR_OutdoorFacility_Property_RefID,
  Questionnaires.IsAtticVisible,
  Questionnaires.RES_STR_Staircase_Property_RefID,
  Questionnaires.RES_STR_Roof_Property_RefID,
  Questionnaires.RES_STR_Facade_Property_RefID,
  Questionnaires.RES_STR_Basement_Property_RefID,
  Questionnaires.RES_STR_Attic_Property_RefID,
  Questionnaires.RES_STR_Apartment_Property_RefID,
  Questionnaires.RES_STR_HVACR_Property_RefID,
  Questionnaires.RES_QST_Questionnaire_Version_RefID,
  Basements.RES_STR_Basement_PropertyAssessmentID,
  Basements.RES_STR_Basement_PropertyID,
  Basements.RES_STR_Basement_RequiredActionID,
  Basements.RES_STR_BasementID,
  Basements.RES_BLD_BasementID,
  Basements.Basement_Assessment_Comment,
  Basements.Rating_RefID As Rating_RefID5,
  Basements.BasementProperty_Name_DictID,
  Basements.AverageRating_RefID As AverageRating_RefID5,
  Basements.RES_BLD_Basement_Type_RefID,
  Basements.SelectedActionVersion_RefID As SelectedActionVersion_RefID5,
  Documents.Alias,
  Documents.PrimaryType,
  Documents.DOC_DocumentID,
  Staircases.DocumentHeader_RefID,
  Appartments.DocumentHeader_RefID As DocumentHeader_RefID1,
  Basements.DocumentHeader_RefID As DocumentHeader_RefID2,
  HVACR.DocumentHeader_RefID As DocumentHeader_RefID3,
  Roof.DocumentHeader_RefID As DocumentHeader_RefID4,
  Outdoor_Facilities.DocumentHeader_RefID As DocumentHeader_RefID5,
  Facades.DocumentHeader_RefID As DocumentHeader_RefID6,
  Attic.DocumentHeader_RefID As DocumentHeader_RefID7
From
  res_dud_revisions Left Join
  (Select
    res_bld_apartment_2_apartmenttype.RES_BLD_Apartment_Type_RefID,
    res_bld_apartments.RES_BLD_ApartmentID,
    res_bld_apartments.ApartmentType_RefID,
    res_bld_apartments.IsAppartment_ForRent,
    res_bld_apartments.ApartmentSize_Unit_RefID,
    res_bld_apartments.ApartmentSize_Value,
    res_str_apartments.DUD_Revision_RefID,
    res_str_apartments.RES_STR_ApartmentID,
    res_str_apartments.AverageRating_RefID,
    res_str_apartment_propertyassessments.RES_STR_Apartment_PropertyAssessmentID,
    res_str_apartment_propertyassessments.Rating_RefID,
    res_str_apartment_propertyassessments.Comment As
    Appartmnet_AssessmentComment,
    res_str_apartment_properties.RES_STR_Apartment_PropertyID,
    res_str_apartment_properties.ApartmentProperty_Name_DictID,
    res_str_apartment_requiredactions.RES_STR_Apartment_RequiredActionID,
    res_str_apartment_requiredactions.SelectedActionVersion_RefID,
    res_str_apartments.DocumentHeader_RefID
  From
    res_bld_apartments Inner Join
    res_bld_apartment_2_apartmenttype
      On res_bld_apartment_2_apartmenttype.RES_BLD_Apartment_RefID =
      res_bld_apartments.RES_BLD_ApartmentID Inner Join
    res_str_apartments On res_str_apartments.RES_BLD_Apartment_RefID =
      res_bld_apartments.RES_BLD_ApartmentID Inner Join
    res_str_apartment_propertyassessments
      On res_str_apartment_propertyassessments.STR_Apartment_RefID =
      res_str_apartments.RES_STR_ApartmentID Inner Join
    res_str_apartment_requiredactions
      On res_str_apartment_requiredactions.ApartmentPropertyAssessment_RefID =
      res_str_apartment_propertyassessments.RES_STR_Apartment_PropertyAssessmentID Inner Join
    res_str_apartment_properties
      On res_str_apartment_properties.RES_STR_Apartment_PropertyID =
      res_str_apartment_propertyassessments.ApartmentProperty_RefID
  Where
    res_bld_apartments.IsDeleted = 0 And
    res_bld_apartment_2_apartmenttype.IsDeleted = 0 And
    res_str_apartments.IsDeleted = 0 And
    res_str_apartment_propertyassessments.IsDeleted = 0 And
    res_str_apartment_requiredactions.IsDeleted = 0 And
    res_str_apartment_properties.IsDeleted = 0) Appartments
    On Appartments.DUD_Revision_RefID = res_dud_revisions.RES_DUD_RevisionID
  Inner Join
  res_bld_buildings On res_bld_buildings.RES_BLD_BuildingID =
    res_dud_revisions.RES_BLD_Building_RefID Left Join
  (Select
    res_bld_attics.RES_BLD_AtticID,
    res_bld_attic_2_attictype.RES_BLD_Attic_Type_RefID,
    res_str_attics.RES_STR_AtticID,
    res_str_attics.DUD_Revision_RefID,
    res_str_attics.AverageRating_RefID,
    res_str_attic_propertyassessments.RES_STR_Attic_PropertyAssessmentID,
    res_str_attic_propertyassessments.Rating_RefID,
    res_str_attic_propertyassessments.Comment As Attic_AssessmentComment,
    res_str_attic_properties.AtticProperty_Name_DictID,
    res_str_attic_requiredactions.RES_STR_Attic_RequiredActionID,
    res_str_attic_requiredactions.SelectedActionVersion_RefID,
    res_str_attics.DocumentHeader_RefID
  From
    res_bld_attics Inner Join
    res_bld_attic_2_attictype On res_bld_attic_2_attictype.RES_BLD_Attic_RefID =
      res_bld_attics.RES_BLD_AtticID Inner Join
    res_str_attics On res_str_attics.RES_BLD_Attic_RefID =
      res_bld_attics.RES_BLD_AtticID Inner Join
    res_str_attic_propertyassessments
      On res_str_attic_propertyassessments.STR_Attic_RefID =
      res_str_attics.RES_STR_AtticID Inner Join
    res_str_attic_requiredactions
      On res_str_attic_requiredactions.AtticPropertyAssestment_RefID =
      res_str_attic_propertyassessments.RES_STR_Attic_PropertyAssessmentID
    Inner Join
    res_str_attic_properties
      On res_str_attic_properties.RES_STR_Attic_PropertyID =
      res_str_attic_propertyassessments.AtticProperty_RefID
  Where
    res_bld_attics.IsDeleted = 0 And
    res_bld_attic_2_attictype.IsDeleted = 0 And
    res_str_attics.IsDeleted = 0 And
    res_str_attic_propertyassessments.IsDeleted = 0 And
    res_str_attic_properties.IsDeleted = 0 And
    res_str_attic_requiredactions.IsDeleted = 0) Attic
    On Attic.DUD_Revision_RefID = res_dud_revisions.RES_DUD_RevisionID Left Join
  (Select
    rel_bld_facades.REL_BLD_FacadeID,
    res_bld_facade_2_facadetype.RES_BLD_Facade_Type_RefID,
    res_str_facades.RES_STR_FacadeID,
    res_str_facades.DUD_Revision_RefID,
    res_str_facades.AverageRating_RefID,
    res_str_facade_propertyassessments.RES_STR_Facade_PropertyAssessmentID,
    res_str_facade_propertyassessments.Rating_RefID,
    res_str_facade_propertyassessments.Comment As Facade_AssessmentComment,
    res_str_facade_properties.RES_STR_Facade_PropertyID,
    res_str_facade_properties.FacadeProperty_Name_DictID,
    res_str_facade_requiredactions.RES_STR_Facade_RequiredActionID,
    res_str_facade_requiredactions.SelectedActionVersion_RefID,
    res_str_facades.DocumentHeader_RefID
  From
    rel_bld_facades Inner Join
    res_bld_facade_2_facadetype
      On res_bld_facade_2_facadetype.RES_BLD_Facade_RefID =
      rel_bld_facades.REL_BLD_FacadeID Inner Join
    res_str_facades On res_str_facades.RES_BLD_Facade_RefID =
      rel_bld_facades.REL_BLD_FacadeID Inner Join
    res_str_facade_propertyassessments
      On res_str_facade_propertyassessments.STR_Facade_RefID =
      res_str_facades.RES_STR_FacadeID Inner Join
    res_str_facade_properties
      On res_str_facade_properties.RES_STR_Facade_PropertyID =
      res_str_facade_propertyassessments.FacadeProperty_RefID Inner Join
    res_str_facade_requiredactions
      On res_str_facade_requiredactions.FacadePropertyAssestment_RefID =
      res_str_facade_propertyassessments.RES_STR_Facade_PropertyAssessmentID
  Where
    res_str_facade_requiredactions.IsDeleted = 0 And
    res_str_facade_properties.IsDeleted = 0 And
    res_str_facade_propertyassessments.IsDeleted = 0 And
    res_str_facades.IsDeleted = 0 And
    res_bld_facade_2_facadetype.IsDeleted = 0 And
    rel_bld_facades.IsDeleted = 0) Facades On Facades.DUD_Revision_RefID =
    res_dud_revisions.RES_DUD_RevisionID Left Join
  (Select
    res_bld_outdoorfacilities.RES_BLD_OutdoorFacilityID,
    res_bld_outdoorfacilities.NumberOfGaragePlaces,
    res_bld_outdoorfacilities.NumberOfRentedGaragePlaces,
    res_bld_outdoorfacility_2_outdoorfacilitytype.RES_BLD_OutdoorFacility_Type_RefID,
    res_str_outdoorfacilities.DUD_Revision_RefID,
    res_str_outdoorfacilities.RES_STR_OutdoorFacilityID,
    res_str_outdoorfacilities.AverageRating_RefID,
    res_str_outdoorfacility_propertyassessments.RES_STR_OutdoorFacility_PropertyAssessmentID,
    res_str_outdoorfacility_propertyassessments.Rating_RefID,
    res_str_outdoorfacility_propertyassessments.Comment As
    Outdoor_AssessmentComment,
    res_str_outdoorfacility_properties.RES_STR_OutdoorFacility_PropertyID,
    res_str_outdoorfacility_properties.OutdoorFacilityProperty_Name_DictID,
    res_str_outdoorfacility_requiredactions.RES_STR_OutdoorFacility_RequiredActionID,
    res_str_outdoorfacility_requiredactions.SelectedActionVersion_RefID,
    res_str_outdoorfacilities.DocumentHeader_RefID
  From
    res_bld_outdoorfacilities Inner Join
    res_bld_outdoorfacility_2_outdoorfacilitytype
      On
      res_bld_outdoorfacility_2_outdoorfacilitytype.RES_BLD_OutdoorFacility_RefID = res_bld_outdoorfacilities.RES_BLD_OutdoorFacilityID Inner Join
    res_str_outdoorfacilities
      On res_str_outdoorfacilities.RES_BLD_OutdoorFacility_RefID =
      res_bld_outdoorfacilities.RES_BLD_OutdoorFacilityID Inner Join
    res_str_outdoorfacility_propertyassessments
      On res_str_outdoorfacility_propertyassessments.STR_OutdoorFacility_RefID =
      res_str_outdoorfacilities.RES_STR_OutdoorFacilityID Inner Join
    res_str_outdoorfacility_properties
      On res_str_outdoorfacility_properties.RES_STR_OutdoorFacility_PropertyID =
      res_str_outdoorfacility_propertyassessments.OutdoorFacilityProperty_RefID
    Inner Join
    res_str_outdoorfacility_requiredactions
      On
      res_str_outdoorfacility_requiredactions.OutdoorFacilityPropertyAssestment_RefID = res_str_outdoorfacility_propertyassessments.RES_STR_OutdoorFacility_PropertyAssessmentID
  Where
    res_str_outdoorfacility_requiredactions.IsDeleted = 0 And
    res_str_outdoorfacility_properties.IsDeleted = 0 And
    res_str_outdoorfacility_propertyassessments.IsDeleted = 0 And
    res_str_outdoorfacilities.IsDeleted = 0 And
    res_bld_outdoorfacility_2_outdoorfacilitytype.IsDeleted = 0 And
    res_bld_outdoorfacilities.IsDeleted = 0) Outdoor_Facilities
    On Outdoor_Facilities.DUD_Revision_RefID =
    res_dud_revisions.RES_DUD_RevisionID Inner Join
  (Select
    res_bld_staircases.RES_BLD_StaircaseID,
    res_bld_staircases.StaircaseSize_Unit_RefID,
    res_bld_staircases.StaircaseSize_Value,
    res_bld_staircase_2_staircasetype.RES_BLD_Staircase_Type_RefID,
    res_str_staircases.RES_STR_StaircaseID,
    res_str_staircases.AverageRating_RefID,
    res_str_staircase_propertyassessments.RES_STR_Staircase_PropertyAssessmentID,
    res_str_staircase_propertyassessments.Rating_RefID,
    res_str_staircase_propertyassessments.Comment As
    Staircase_AssessmentComment,
    res_str_staircase_properties.RES_STR_Staircase_PropertyID,
    res_str_staircase_properties.StaircaseProperty_Name_DictID,
    res_str_staircase_requiredactions.RES_STR_Staircase_RequiredActionID,
    res_str_staircase_requiredactions.SelectedActionVersion_RefID,
    res_str_staircases.DUD_Revision_RefID,
    res_str_staircases.DocumentHeader_RefID
  From
    res_bld_staircases Inner Join
    res_bld_staircase_2_staircasetype
      On res_bld_staircase_2_staircasetype.RES_BLD_Staircase_RefID =
      res_bld_staircases.RES_BLD_StaircaseID Inner Join
    res_str_staircases On res_str_staircases.RES_BLD_Staircase_RefID =
      res_bld_staircases.RES_BLD_StaircaseID Inner Join
    res_str_staircase_propertyassessments
      On res_str_staircase_propertyassessments.STR_Staircase_RefID =
      res_str_staircases.RES_STR_StaircaseID Inner Join
    res_str_staircase_properties
      On res_str_staircase_properties.RES_STR_Staircase_PropertyID =
      res_str_staircase_propertyassessments.StaircaseProperty_RefID Inner Join
    res_str_staircase_requiredactions
      On res_str_staircase_requiredactions.StaircasePropertyAssessment_RefID =
      res_str_staircase_propertyassessments.RES_STR_Staircase_PropertyAssessmentID
  Where
    res_str_staircase_requiredactions.IsDeleted = 0 And
    res_str_staircase_properties.IsDeleted = 0 And
    res_str_staircase_propertyassessments.IsDeleted = 0 And
    res_str_staircases.IsDeleted = 0 And
    res_bld_staircases.IsDeleted = 0 And
    res_bld_staircase_2_staircasetype.IsDeleted = 0) Staircases
    On Staircases.DUD_Revision_RefID = res_dud_revisions.RES_DUD_RevisionID
  Left Join
  (Select
    res_str_basement_propertyassessments.Comment As Basement_Assessment_Comment,
    res_str_basement_propertyassessments.Rating_RefID,
    res_str_basement_propertyassessments.RES_STR_Basement_PropertyAssessmentID,
    res_str_basement_properties.BasementProperty_Name_DictID,
    res_str_basement_properties.RES_STR_Basement_PropertyID,
    res_str_basement_requiredactions.RES_STR_Basement_RequiredActionID,
    res_str_basements.RES_STR_BasementID,
    res_str_basements.DUD_Revision_RefID,
    res_str_basements.AverageRating_RefID,
    res_bld_basement_2_basementtype.RES_BLD_Basement_Type_RefID,
    res_bld_basements.RES_BLD_BasementID,
    res_str_basement_requiredactions.SelectedActionVersion_RefID,
    res_str_basements.DocumentHeader_RefID
  From
    res_bld_basements Inner Join
    res_str_basements On res_str_basements.RES_BLD_Basement_RefID =
      res_bld_basements.RES_BLD_BasementID Inner Join
    res_bld_basement_2_basementtype
      On res_bld_basement_2_basementtype.RES_BLD_Basement_RefID =
      res_bld_basements.RES_BLD_BasementID Inner Join
    res_str_basement_propertyassessments
      On res_str_basement_propertyassessments.STR_Basement_RefID =
      res_str_basements.RES_STR_BasementID Inner Join
    res_str_basement_requiredactions
      On res_str_basement_requiredactions.BasementPropertyAssestment_RefID =
      res_str_basement_propertyassessments.RES_STR_Basement_PropertyAssessmentID
    Inner Join
    res_str_basement_properties
      On res_str_basement_propertyassessments.BasementProperty_RefID =
      res_str_basement_properties.RES_STR_Basement_PropertyID
  Where
    res_bld_basement_2_basementtype.IsDeleted = 0 And
    res_str_basements.IsDeleted = 0 And
    res_str_basement_propertyassessments.IsDeleted = 0 And
    res_str_basement_properties.IsDeleted = 0 And
    res_str_basement_requiredactions.IsDeleted = 0 And
    res_bld_basements.IsDeleted = 0) Basements On Basements.DUD_Revision_RefID =
    res_dud_revisions.RES_DUD_RevisionID Left Join
  (Select
    res_bld_hvacrs.RES_BLD_HVACRID,
    res_bld_hvacr_2_hvacr_type.RES_BLD_HVACR_Type_RefID,
    res_str_hvacrs.RES_STR_HVACRID,
    res_str_hvacrs.DUD_Revision_RefID,
    res_str_hvacrs.AverageRating_RefID,
    res_str_hvacr_propertyassessments.RES_STR_HVACR_PropertyAssessmentID,
    res_str_hvacr_propertyassessments.Rating_RefID,
    res_str_hvacr_propertyassessments.Comment As HVACR__AssessmentComment,
    res_str_hvacr_properties.RES_STR_HVACR_PropertyID,
    res_str_hvacr_properties.HVACRProperty_Name_DictID,
    res_str_hvacr_requiredactions.RES_STR_HVACR_RequiredActionID,
    res_str_hvacr_requiredactions.SelectedActionVersion_RefID,
    res_str_hvacrs.DocumentHeader_RefID
  From
    res_bld_hvacrs Inner Join
    res_bld_hvacr_2_hvacr_type On res_bld_hvacr_2_hvacr_type.RES_BLD_HVACR_RefID
      = res_bld_hvacrs.RES_BLD_HVACRID Inner Join
    res_str_hvacrs On res_str_hvacrs.RES_BLD_HVACR_RefID =
      res_bld_hvacrs.RES_BLD_HVACRID Inner Join
    res_str_hvacr_propertyassessments
      On res_str_hvacr_propertyassessments.STR_HVACR_RefID =
      res_str_hvacrs.RES_STR_HVACRID Inner Join
    res_str_hvacr_properties
      On res_str_hvacr_properties.RES_STR_HVACR_PropertyID =
      res_str_hvacr_propertyassessments.HVACRProperty_RefID Inner Join
    res_str_hvacr_requiredactions
      On res_str_hvacr_requiredactions.HVACRPropertyAssestment_RefID =
      res_str_hvacr_propertyassessments.RES_STR_HVACR_PropertyAssessmentID
  Where
    res_str_hvacr_requiredactions.IsDeleted = 0 And
    res_str_hvacr_properties.IsDeleted = 0 And
    res_str_hvacr_propertyassessments.IsDeleted = 0 And
    res_str_hvacrs.IsDeleted = 0 And
    res_bld_hvacr_2_hvacr_type.IsDeleted = 0 And
    res_bld_hvacrs.IsDeleted = 0) HVACR On HVACR.DUD_Revision_RefID =
    res_dud_revisions.RES_DUD_RevisionID Left Join
  (Select
    res_bld_roof.RES_BLD_RoofID,
    res_bld_roof_2_rooftype.RES_BLD_Roof_Type_RefID,
    res_str_roofs.RES_STR_RoofID,
    res_str_roofs.DUD_Revision_RefID,
    res_str_roofs.AverageRating_RefID,
    res_str_roof_propertyassessments.RES_STR_Roof_PropertyAssessmentID,
    res_str_roof_propertyassessments.Rating_RefID,
    res_str_roof_propertyassessments.Comment As Rood_AssessmentComment,
    res_str_roof_properties.RES_STR_Roof_PropertyID,
    res_str_roof_properties.RoofProperty_Name_DictID,
    res_str_roof_requiredactions.RES_STR_Roof_RequiredActionID,
    res_str_roof_requiredactions.SelectedActionVersion_RefID,
    res_str_roofs.DocumentHeader_RefID
  From
    res_bld_roof Inner Join
    res_bld_roof_2_rooftype On res_bld_roof_2_rooftype.RES_BLD_Roof_RefID =
      res_bld_roof.RES_BLD_RoofID Inner Join
    res_str_roofs On res_str_roofs.RES_BLD_Roof_RefID =
      res_bld_roof.RES_BLD_RoofID Inner Join
    res_str_roof_propertyassessments
      On res_str_roof_propertyassessments.STR_Roof_RefID =
      res_str_roofs.RES_STR_RoofID Inner Join
    res_str_roof_properties On res_str_roof_properties.RES_STR_Roof_PropertyID =
      res_str_roof_propertyassessments.RoofProperty_RefID Inner Join
    res_str_roof_requiredactions
      On res_str_roof_requiredactions.RoofPropertyAssestment_RefID =
      res_str_roof_propertyassessments.RES_STR_Roof_PropertyAssessmentID
  Where
    res_str_roof_requiredactions.IsDeleted = 0 And
    res_str_roof_propertyassessments.IsDeleted = 0 And
    res_str_roof_properties.IsDeleted = 0 And
    res_str_roofs.IsDeleted = 0 And
    res_bld_roof_2_rooftype.IsDeleted = 0 And
    res_bld_roof.IsDeleted = 0) Roof On Roof.DUD_Revision_RefID =
    res_dud_revisions.RES_DUD_RevisionID Left Join
  (Select
    doc_documents.Alias,
    doc_documents.PrimaryType,
    doc_documents.DOC_DocumentID,
    doc_structure_headers.DOC_Structure_HeaderID
  From
    doc_documents Inner Join
    doc_document_2_structure On doc_document_2_structure.Document_RefID =
      doc_documents.DOC_DocumentID Inner Join
    doc_structures On doc_document_2_structure.Structure_RefID =
      doc_structures.DOC_StructureID Inner Join
    doc_structure_headers On doc_structures.Structure_Header_RefID =
      doc_structure_headers.DOC_Structure_HeaderID
  Where
    doc_documents.IsDeleted = 0 And
    doc_document_2_structure.IsDeleted = 0 And
    doc_structures.IsDeleted = 0 And
    doc_structure_headers.IsDeleted = 0) Documents
    On Documents.DOC_Structure_HeaderID =
    res_bld_buildings.Building_DocumentationStructure_RefID And
    Staircases.DocumentHeader_RefID = Documents.DOC_Structure_HeaderID
    And Attic.DocumentHeader_RefID = Documents.DOC_Structure_HeaderID And
    Basements.DocumentHeader_RefID = Documents.DOC_Structure_HeaderID And
    HVACR.DocumentHeader_RefID = Documents.DOC_Structure_HeaderID And
    Roof.DocumentHeader_RefID = Documents.DOC_Structure_HeaderID And
    Outdoor_Facilities.DocumentHeader_RefID = Documents.DOC_Structure_HeaderID
    And Facades.DocumentHeader_RefID = Documents.DOC_Structure_HeaderID,
  (Select
    res_qst_questionnaire.RES_QST_QuestionnaireID,
    res_qst_questionnaire.Questionnaire_Name_DictID,
    res_qst_questionnaire.Questionnaire_Description_DictID,
    res_qst_questionnaire_version.RES_QST_Questionnaire_VersionID,
    res_qst_questionnaire_version.QuestionnaireVersion_Comment,
    res_qst_questionnaire_version.QuestionnaireVersion_VersionNumber,
    res_qst_questionnaire_version.IsApartmentStructureVisible,
    res_qst_questionnaire_version.IsStaircaseStructureVisible,
    res_qst_questionnaire_version.IsOutdoorFacilityVisible,
    res_qst_questionnaire_version.IsFacadeVisible,
    res_qst_questionnaire_version.IsRoofVisible,
    res_qst_questionnaire_version.IsAtticVisible,
    res_qst_questionnaire_version.IsBasementVisible,
    res_qst_questionnaire_version.IsHVACRVisible,
    res_qst_outdoorfacility_availableproperties.RES_QST_OutdoorFacility_AvailablePropertyID,
    res_qst_outdoorfacility_availableproperties.RES_STR_OutdoorFacility_Property_RefID,
    res_qst_staircase_availableproperties.RES_QST_Staircase_AvailablePropertyID,
    res_qst_staircase_availableproperties.RES_STR_Staircase_Property_RefID,
    res_qst_roof_availableproperties.RES_QST_Roof_AvailablePropertyID,
    res_qst_roof_availableproperties.RES_STR_Roof_Property_RefID,
    res_qst_facade_availableproperties.RES_QST_Facade_AvailablePropertyID,
    res_qst_facade_availableproperties.RES_STR_Facade_Property_RefID,
    res_qst_basement_availableproperties.RES_QST_Basement_AvailablePropertyID,
    res_qst_basement_availableproperties.RES_STR_Basement_Property_RefID,
    res_qst_attic_availableproperties.RES_QST_Attic_AvailablePropertyID,
    res_qst_attic_availableproperties.RES_STR_Attic_Property_RefID,
    res_qst_apartment_availableproperties.RES_QST_Apartment_AvailablePropertyID,
    res_qst_apartment_availableproperties.RES_STR_Apartment_Property_RefID,
    res_qst_hvacr_availableproperties.RES_STR_HVACR_Property_RefID,
    res_qst_hvacr_availableproperties.RES_QST_HVACR_AvailablePropertyID,
    res_qst_hvacr_availableproperties.RES_QST_Questionnaire_Version_RefID
  From
    res_qst_questionnaire Inner Join
    res_qst_questionnaire_version
      On res_qst_questionnaire.RES_QST_QuestionnaireID =
      res_qst_questionnaire_version.Questionnaire_RefID Left Join
    res_qst_apartment_availableproperties
      On res_qst_questionnaire_version.RES_QST_Questionnaire_VersionID =
      res_qst_apartment_availableproperties.RES_QST_Questionnaire_Version_RefID
    Left Join
    res_qst_attic_availableproperties
      On res_qst_questionnaire_version.RES_QST_Questionnaire_VersionID =
      res_qst_attic_availableproperties.RES_QST_Questionnaire_Version_RefID
    Left Join
    res_qst_basement_availableproperties
      On res_qst_questionnaire_version.RES_QST_Questionnaire_VersionID =
      res_qst_basement_availableproperties.RES_QST_Questionnaire_Version_RefID
    Left Join
    res_qst_facade_availableproperties
      On res_qst_questionnaire_version.RES_QST_Questionnaire_VersionID =
      res_qst_facade_availableproperties.RES_QST_Questionnaire_Version_RefID
    Left Join
    res_qst_outdoorfacility_availableproperties
      On res_qst_questionnaire_version.RES_QST_Questionnaire_VersionID =
      res_qst_outdoorfacility_availableproperties.RES_QST_Questionnaire_Version_RefID Left Join
    res_qst_staircase_availableproperties
      On res_qst_questionnaire_version.RES_QST_Questionnaire_VersionID =
      res_qst_staircase_availableproperties.RES_QST_Questionnaire_Version_RefID
    Left Join
    res_qst_roof_availableproperties
      On res_qst_questionnaire_version.RES_QST_Questionnaire_VersionID =
      res_qst_roof_availableproperties.RES_QST_Questionnaire_Version_RefID
    Left Join
    res_qst_hvacr_availableproperties
      On res_qst_hvacr_availableproperties.RES_QST_Questionnaire_Version_RefID =
      res_qst_questionnaire_version.RES_QST_Questionnaire_VersionID
  Where
    res_qst_questionnaire.Tenant_RefID = @TenantID And
    res_qst_questionnaire.IsDeleted = 0 And
    res_qst_questionnaire_version.IsDeleted = 0) Questionnaires
Where
  res_dud_revisions.RES_DUD_RevisionID = @RevisionID And
  res_dud_revisions.IsDeleted = 0 And
  res_bld_buildings.IsDeleted = 0 And
  res_dud_revisions.Tenant_RefID = @TenantID
  