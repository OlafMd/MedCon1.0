/* 
 * Generated on 8/30/2013 2:47:22 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_RES_BLD;
using CL1_RES_DUD;
using CL1_CMN;
using CL5_KPRS_Buildings.Complex.Retrieval;
using CL5_KPRS_Buildings.Atomic.Manipulation;
using CL1_RES_STR;
using CL1_DOC;
using CL2_Price.Atomic.Retrieval;

namespace CL5_KPRS_DueDiligences.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Submissions_for_RevisionGroupDetails.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Submissions_for_RevisionGroupDetails
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L6DD_SSfRGD_1503 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();

            try
            {

                ///Save prices
                foreach (var price in Parameter.Prices)
                {
                    ORM_CMN_Price ormPrice = new ORM_CMN_Price();
                    ormPrice.Load(Connection, Transaction, price.Price_RefID);
                    if (ormPrice.CMN_PriceID == Guid.Empty)
                    {
                        ormPrice.CMN_PriceID = price.Price_RefID;
                        ormPrice.Creation_Timestamp = DateTime.Now;
                        ormPrice.IsDeleted = false;
                        ormPrice.Tenant_RefID = securityTicket.TenantID;
                        ormPrice.Save(Connection, Transaction);
                    }
                    ORM_CMN_Price_Value ormPriceValue = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, new ORM_CMN_Price_Value.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Price_RefID = ormPrice.CMN_PriceID
                    }).FirstOrDefault();
                    if (ormPriceValue == null)
                    {
                        ormPriceValue = new ORM_CMN_Price_Value();
                        ormPriceValue.CMN_Price_ValueID = Guid.NewGuid();
                        ormPriceValue.Creation_Timestamp = DateTime.Now;
                        ormPriceValue.Tenant_RefID = securityTicket.TenantID;
                        ormPriceValue.IsDeleted = false;
                    }
                    ormPriceValue.Price_RefID = ormPrice.CMN_PriceID;
                    ormPriceValue.PriceValue_Amount = Double.Parse(price.PriceValue_Amount);
                    ormPriceValue.Save(Connection, Transaction);
                }


                ORM_RES_DUD_RevisionGroup revisionGroup = new ORM_RES_DUD_RevisionGroup();
                if (Parameter.RevisionGroupID != Guid.Empty)
                    revisionGroup.Load(Connection, Transaction, Parameter.RevisionGroupID);

                revisionGroup.RevisionGroup_Comment = Parameter.Comment;
                revisionGroup.RevisionGroup_Name = Parameter.Name;
                revisionGroup.RES_DUD_Revision_GroupID = Parameter.RevisionGroupID;
                revisionGroup.RevisionGroup_SubmittedBy_Account_RefID = securityTicket.AccountID;
                revisionGroup.Tenant_RefID = securityTicket.TenantID;
                revisionGroup.Save(Connection, Transaction);


                foreach (var submitedRevision in Parameter.Revisions)
                {
                    ORM_RES_DUD_Revision revision = new ORM_RES_DUD_Revision();
                    if (submitedRevision.RevisionID != Guid.Empty)
                        revision.Load(Connection, Transaction, submitedRevision.RevisionID);

                    if (revision.RES_DUD_RevisionID == Guid.Empty)
                    {
                        revision.QuestionnaireVersion_RefID = submitedRevision.QuestionnaireVersionID;
                        revision.RES_BLD_Building_RefID = submitedRevision.Building.RES_BLD_BuildingID;
                        revision.RES_DUD_RevisionID = submitedRevision.RevisionID;
                        revision.RevisionGroup_RefID = revisionGroup.RES_DUD_Revision_GroupID;
                        revision.Tenant_RefID = securityTicket.TenantID;
                    }
                    revision.Revision_Title = submitedRevision.Title;
                    revision.Revision_Comment = submitedRevision.Comment;
                    revision.QuestionnaireVersion_RefID = submitedRevision.QuestionnaireVersionID;
                    revision.RES_BLD_Building_RefID = submitedRevision.Building.RES_BLD_BuildingID;
                    revision.Save(Connection, Transaction);
                    //Building?

                    var ormBuilding = new ORM_RES_BLD_Building();
                    var submitedBuilding = submitedRevision.Building;

                    if (submitedBuilding == null)
                        return null;

                    if (submitedBuilding.RES_BLD_BuildingID != Guid.Empty)
                        ormBuilding.Load(Connection, Transaction, submitedBuilding.RES_BLD_BuildingID);

                    if (ormBuilding.Building_DocumentationStructure_RefID == Guid.Empty)
                    {
                        ormBuilding.Building_DocumentationStructure_RefID = Guid.NewGuid();
                    }

                    ORM_RES_BLD_Building_2_BuildingType type = ORM_RES_BLD_Building_2_BuildingType.Query.Search(Connection, Transaction, new ORM_RES_BLD_Building_2_BuildingType.Query { RES_BLD_Building_RefID = submitedBuilding.RES_BLD_BuildingID, Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).FirstOrDefault();
                    if (type != null)
                    {
                        type.RES_BLD_Building_Type_RefID = submitedBuilding.BuildingType_RefID;
                        type.Save(Connection, Transaction);
                    }
                    else
                    {
                        type = new ORM_RES_BLD_Building_2_BuildingType();
                        type.Tenant_RefID = securityTicket.TenantID;
                        type.RES_BLD_Building_RefID = submitedBuilding.RES_BLD_BuildingID;
                        type.RES_BLD_Building_Type_RefID = submitedBuilding.BuildingType_RefID;
                        type.Save(Connection, Transaction);
                    }

                    ORM_RES_BLD_Building_2_GarbageContainerType garbageType = ORM_RES_BLD_Building_2_GarbageContainerType.Query.Search(Connection, Transaction, new ORM_RES_BLD_Building_2_GarbageContainerType.Query { RES_BLD_Building_RefID = submitedBuilding.RES_BLD_BuildingID, Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).FirstOrDefault();
                    if (garbageType != null)
                    {
                        garbageType.RES_BLD_GarbageContainerType_RefID = submitedBuilding.GarbageContainerType_RefID;
                        garbageType.Save(Connection, Transaction);
                    }
                    else
                    {
                        garbageType = new ORM_RES_BLD_Building_2_GarbageContainerType();
                        garbageType.Tenant_RefID = securityTicket.TenantID;
                        garbageType.RES_BLD_Building_RefID = submitedBuilding.RES_BLD_BuildingID;
                        garbageType.RES_BLD_GarbageContainerType_RefID = garbageType.RES_BLD_GarbageContainerType_RefID;
                        garbageType.Save(Connection, Transaction);
                    }
                    ormBuilding.Building_BalconyPortionPercent = submitedBuilding.Building_BalconyPortionPercent;
                    ormBuilding.Building_ElevatorCoveragePercent = submitedBuilding.Building_ElevatorCoveragePercent;
                    ormBuilding.Building_Name = submitedBuilding.Building_Name;
                    ormBuilding.Building_NumberOfAppartments = submitedBuilding.Building_NumberOfAppartments;
                    ormBuilding.Building_NumberOfFloors = submitedBuilding.Building_NumberOfFloors;
                    ormBuilding.Building_NumberOfOccupiedAppartments = submitedBuilding.Building_NumberOfOccupiedAppartments;
                    ormBuilding.Building_NumberOfOffices = submitedBuilding.Building_NumberOfOffices;
                    ormBuilding.Building_NumberOfOtherUnits = submitedBuilding.Building_NumberOfOtherUnits;
                    ormBuilding.Building_NumberOfProductionUnits = submitedBuilding.Building_NumberOfProductionUnits;
                    ormBuilding.Building_NumberOfRetailUnits = submitedBuilding.Building_NumberOfRetailUnits;
                    ormBuilding.IsContaminationSuspected = submitedBuilding.IsContaminationSuspected;
                    ormBuilding.Save(Connection, Transaction);

                    if (revisionGroup.RealestateProperty_RefID == Guid.Empty)
                    {
                        ORM_RES_BLD_Building_RevisionHeader revisionHeader = new ORM_RES_BLD_Building_RevisionHeader();
                        revisionHeader.Load(Connection, Transaction, submitedBuilding.BuildingRevisionHeader_RefID);

                        revisionGroup.RealestateProperty_RefID = revisionHeader.RealestateProperty_RefID;
                        revisionGroup.Save(Connection, Transaction);
                    }

                    #region delete_building_images
                    List<ORM_DOC_Structure> allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                    {
                        Structure_Header_RefID = ormBuilding.Building_DocumentationStructure_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });
                    List<ORM_DOC_Document_2_Structure> allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                    foreach(var docStructure in allDocsStructure){
                        allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                        { 
                            Structure_RefID = docStructure.DOC_StructureID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).ToList());
                    }
                    List<ORM_DOC_DocumentRevision> allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                    foreach (var doc in allDocuments2Structure)
                    {
                        allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query() { 
                            Document_RefID = doc.Document_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }));
                    }
                    if (submitedRevision.Building.Images.Count() < allRevisionDocs.Count())
                    {
                        var submittedImages = submitedRevision.Building.Images.ToList();
                        foreach (var item in allRevisionDocs)
                        {
                            if (!submittedImages.Any(s => s.DOC_DocumentID == item.DOC_DocumentRevisionID))
                            {
                                item.Remove(Connection, Transaction);
                            }
                        }
                    }
                    #endregion

                    foreach (var image in submitedRevision.Building.Images)
                    {
                        cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                        {
                            DOC_StructureHeaderRefID = ormBuilding.Building_DocumentationStructure_RefID,
                            DOC_DocumentRevisionID = image.DOC_DocumentID,
                        }, securityTicket);
                    }

                    #region building/apartments
                    var allApartmentParts = ORM_RES_BLD_Apartment.Query.Search(Connection, Transaction, new ORM_RES_BLD_Apartment.Query() { 
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Building_RefID = ormBuilding.RES_BLD_BuildingID
                    }).ToList();
                    if (submitedRevision.Building.Apartment.Count() < allApartmentParts.Count())
                    {
                        List<L5BL_GBIfBI_1159_Apartment> submittedBuildingPartItems = submitedRevision.Building.Apartment.ToList();
                        foreach (var item in allApartmentParts)
                        {
                            if (!submittedBuildingPartItems.Any(s => s.RES_BLD_ApartmentID == item.RES_BLD_ApartmentID))
                            {
                                item.Remove(Connection, Transaction);
                            }
                        }
                    }
                    foreach (var buildingPart in submitedRevision.Building.Apartment)
                    {
                        var ormBldPart = new ORM_RES_BLD_Apartment();
                        var result = ormBldPart.Load(Connection, Transaction, buildingPart.RES_BLD_ApartmentID);

                        if (result.Status != FR_Status.Success || ormBldPart.Tenant_RefID == Guid.Empty)
                        {
                            ormBldPart = new ORM_RES_BLD_Apartment() { 
                                Building_RefID = ormBuilding.RES_BLD_BuildingID,
                                Tenant_RefID = securityTicket.TenantID
                            };
                        }
                        ormBldPart.ApartmentSize_Unit_RefID = buildingPart.ApartmentSize_Unit_RefID;
                        ormBldPart.ApartmentSize_Value = buildingPart.ApartmentSize_Value;
                        ormBldPart.IsAppartment_ForRent = buildingPart.IsAppartment_ForRent;
                        ormBldPart.TypeOfFlooring_RefID = buildingPart.Appartment_FlooringType;
                        ormBldPart.TypeOfHeating_RefID = buildingPart.Appartment_HeatingType;
                        ormBldPart.TypeOfWallCovering_RefID = buildingPart.Appartment_WallCoveringType;
                        ormBldPart.Save(Connection, Transaction);

                    }
                    #endregion

                    #region building/attics
                    var allAtticParts = ORM_RES_BLD_Attic.Query.Search(Connection, Transaction, new ORM_RES_BLD_Attic.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Building_RefID = ormBuilding.RES_BLD_BuildingID
                    }).ToList();
                    if (submitedRevision.Building.Attic.Count() < allAtticParts.Count())
                    {
                        List<L5BL_GBIfBI_1159_Attic> submittedBuildingPartItems = submitedRevision.Building.Attic.ToList();
                        foreach (var item in allAtticParts)
                        {
                            if (!submittedBuildingPartItems.Any(s => s.RES_BLD_AtticID == item.RES_BLD_AtticID))
                            {
                                item.Remove(Connection, Transaction);
                            }
                        }
                    }
                    foreach (var buildingPart in submitedRevision.Building.Attic)
                    {
                        var ormBldPart = new ORM_RES_BLD_Attic();
                        var result = ormBldPart.Load(Connection, Transaction, buildingPart.RES_BLD_AtticID);

                        if (result.Status != FR_Status.Success || ormBldPart.Tenant_RefID == Guid.Empty)
                        {
                            ormBldPart = new ORM_RES_BLD_Attic()
                            {
                                Building_RefID = ormBuilding.RES_BLD_BuildingID,
                                Tenant_RefID = securityTicket.TenantID
                            };
                        }

                        ormBldPart.Save(Connection, Transaction);
                    }
                    #endregion

                    #region building/Facades
                    var allFacadeParts = ORM_RES_BLD_Facade.Query.Search(Connection, Transaction, new ORM_RES_BLD_Facade.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Building_RefID = ormBuilding.RES_BLD_BuildingID
                    }).ToList();
                    if (submitedRevision.Building.Facade.Count() < allFacadeParts.Count())
                    {
                        List<L5BL_GBIfBI_1159_Facade> submittedBuildingPartItems = submitedRevision.Building.Facade.ToList();
                        foreach (var item in allFacadeParts)
                        {
                            if (!submittedBuildingPartItems.Any(s => s.RES_BLD_FacadeID == item.RES_BLD_FacadeID))
                            {
                                item.Remove(Connection, Transaction);
                            }
                        }
                    }
                    foreach (var buildingPart in submitedRevision.Building.Facade)
                    {
                        var ormBldPart = new ORM_RES_BLD_Facade();
                        var result = ormBldPart.Load(Connection, Transaction, buildingPart.RES_BLD_FacadeID);

                        if (result.Status != FR_Status.Success || ormBldPart.Tenant_RefID == Guid.Empty)
                        {
                            ormBldPart = new ORM_RES_BLD_Facade()
                            {
                                Building_RefID = ormBuilding.RES_BLD_BuildingID,
                                Tenant_RefID = securityTicket.TenantID
                            };
                        }
                        ormBldPart.Save(Connection, Transaction);
                    }
                    #endregion

                    #region building/OutdoorFascilitys
                    var allOutdoorFacilityParts = ORM_RES_BLD_OutdoorFacility.Query.Search(Connection, Transaction, new ORM_RES_BLD_OutdoorFacility.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Building_RefID = ormBuilding.RES_BLD_BuildingID
                    }).ToList();
                    if (submitedRevision.Building.OutdoorFacility.Count() < allOutdoorFacilityParts.Count())
                    {
                        List<L5BL_GBIfBI_1159_OutdoorFacility> submittedBuildingPartItems = submitedRevision.Building.OutdoorFacility.ToList();
                        foreach (var item in allOutdoorFacilityParts)
                        {
                            if (!submittedBuildingPartItems.Any(s => s.RES_BLD_OutdoorFacilityID == item.RES_BLD_OutdoorFacilityID))
                            {
                                item.Remove(Connection, Transaction);
                            }
                        }
                    }
                    foreach (var buildingPart in submitedRevision.Building.OutdoorFacility)
                    {
                        var ormBldPart = new ORM_RES_BLD_OutdoorFacility();
                        var result = ormBldPart.Load(Connection, Transaction, buildingPart.RES_BLD_OutdoorFacilityID);

                        if (result.Status != FR_Status.Success || ormBldPart.Tenant_RefID == Guid.Empty)
                        {
                            ormBldPart = new ORM_RES_BLD_OutdoorFacility()
                            {
                                Building_RefID = ormBuilding.RES_BLD_BuildingID,
                                Tenant_RefID = securityTicket.TenantID
                            };

                        }
                        ormBldPart.NumberOfGaragePlaces = buildingPart.NumberOfGaragePlaces;
                        ormBldPart.NumberOfRentedGaragePlaces = buildingPart.NumberOfRentedGaragePlaces;
                        ormBldPart.TypeOfAccessRoad_RefID = buildingPart.OutdoorFacility_AccessRoadType;
                        ormBldPart.TypeOfFence_RefID = buildingPart.OutdoorFacility_FenceType;
                        ormBldPart.Save(Connection, Transaction);
                    }
                    #endregion

                    #region building/HVACRs
                    var allHVACRParts = ORM_RES_BLD_HVACR.Query.Search(Connection, Transaction, new ORM_RES_BLD_HVACR.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Building_RefID = ormBuilding.RES_BLD_BuildingID
                    }).ToList();
                    if (submitedRevision.Building.HVACR.Count() < allHVACRParts.Count())
                    {
                        List<L5BL_GBIfBI_1159_HVACR> submittedBuildingPartItems = submitedRevision.Building.HVACR.ToList();
                        foreach (var item in allHVACRParts)
                        {
                            if (!submittedBuildingPartItems.Any(s => s.RES_BLD_HVACRID == item.RES_BLD_HVACRID))
                            {
                                item.Remove(Connection, Transaction);
                            }
                        }
                    }
                    foreach (var buildingPart in submitedRevision.Building.HVACR)
                    {
                        var ormBldPart = new ORM_RES_BLD_HVACR();
                        var result = ormBldPart.Load(Connection, Transaction, buildingPart.RES_BLD_HVACRID);

                        if (result.Status != FR_Status.Success || ormBldPart.Tenant_RefID == Guid.Empty)
                        {
                            ormBldPart = new ORM_RES_BLD_HVACR()
                            {
                                Building_RefID = ormBuilding.RES_BLD_BuildingID,
                                Tenant_RefID = securityTicket.TenantID
                            };
                        }
                        ormBldPart.Save(Connection, Transaction);
                    }
                    #endregion

                    #region building/Staircases
                    var allStaircaseParts = ORM_RES_BLD_Staircase.Query.Search(Connection, Transaction, new ORM_RES_BLD_Staircase.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Building_RefID = ormBuilding.RES_BLD_BuildingID
                    }).ToList();
                    if (submitedRevision.Building.Staircase.Count() < allStaircaseParts.Count())
                    {
                        List<L5BL_GBIfBI_1159_Staircase> submittedBuildingPartItems = submitedRevision.Building.Staircase.ToList();
                        foreach (var item in allStaircaseParts)
                        {
                            if (!submittedBuildingPartItems.Any(s => s.RES_BLD_StaircaseID == item.RES_BLD_StaircaseID))
                            {
                                item.Remove(Connection, Transaction);
                            }
                        }
                    }
                    foreach (var buildingPart in submitedRevision.Building.Staircase)
                    {
                        var ormBldPart = new ORM_RES_BLD_Staircase();
                        var result = ormBldPart.Load(Connection, Transaction, buildingPart.RES_BLD_StaircaseID);

                        if (result.Status != FR_Status.Success || ormBldPart.Tenant_RefID == Guid.Empty)
                        {
                            ormBldPart = new ORM_RES_BLD_Staircase()
                            {
                                Building_RefID = ormBuilding.RES_BLD_BuildingID,
                                Tenant_RefID = securityTicket.TenantID
                            };
                        }
                        ormBldPart.StaircaseSize_Unit_RefID = buildingPart.StaircaseSize_Unit_RefID;
                        ormBldPart.StaircaseSize_Value = buildingPart.StaircaseSize_Value;
                        ormBldPart.Save(Connection, Transaction);
                    }
                    #endregion

                    #region building/Roofs
                    var allRoofParts = ORM_RES_BLD_Roof.Query.Search(Connection, Transaction, new ORM_RES_BLD_Roof.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Building_RefID = ormBuilding.RES_BLD_BuildingID
                    }).ToList();
                    if (submitedRevision.Building.Roof.Count() < allRoofParts.Count())
                    {
                        List<L5BL_GBIfBI_1159_Roof> submittedBuildingPartItems = submitedRevision.Building.Roof.ToList();
                        foreach (var item in allRoofParts)
                        {
                            if (!submittedBuildingPartItems.Any(s => s.RES_BLD_RoofID == item.RES_BLD_RoofID))
                            {
                                item.Remove(Connection, Transaction);
                            }
                        }
                    }
                    foreach (var buildingPart in submitedRevision.Building.Roof)
                    {
                        var ormBldPart = new ORM_RES_BLD_Roof();
                        var result = ormBldPart.Load(Connection, Transaction, buildingPart.RES_BLD_RoofID);

                        if (result.Status != FR_Status.Success|| ormBldPart.Tenant_RefID == Guid.Empty)
                        {
                            ormBldPart = new ORM_RES_BLD_Roof()
                            {
                                Building_RefID = ormBuilding.RES_BLD_BuildingID,
                                Tenant_RefID = securityTicket.TenantID
                            };
                        }
                        ormBldPart.Save(Connection, Transaction);

                        var roof_2_Type = ORM_RES_BLD_Roof_2_RoofType.Query.Search(Connection, Transaction, new ORM_RES_BLD_Roof_2_RoofType.Query() 
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                RES_BLD_Roof_RefID = ormBldPart.RES_BLD_RoofID
                            }).FirstOrDefault();

                        if (roof_2_Type == null)
                            roof_2_Type = new ORM_RES_BLD_Roof_2_RoofType();
                        
                        roof_2_Type.Tenant_RefID = securityTicket.TenantID;
                        roof_2_Type.RES_BLD_Roof_RefID = buildingPart.RES_BLD_RoofID;
                        roof_2_Type.RES_BLD_Roof_Type_RefID = buildingPart.RES_BLD_RoofTypeID;
                        
                        roof_2_Type.Save(Connection, Transaction);

                    }
                    #endregion

                    #region building/Basements
                    var allBasementParts = ORM_RES_BLD_Basement.Query.Search(Connection, Transaction, new ORM_RES_BLD_Basement.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Building_RefID = ormBuilding.RES_BLD_BuildingID
                    }).ToList();
                    if (submitedRevision.Building.Basement.Count() < allBasementParts.Count())
                    {
                        List<L5BL_GBIfBI_1159_Basement> submittedBuildingPartItems = submitedRevision.Building.Basement.ToList();
                        foreach (var item in allBasementParts)
                        {
                            if (!submittedBuildingPartItems.Any(s => s.RES_BLD_BasementID == item.RES_BLD_BasementID))
                            {
                                item.Remove(Connection, Transaction);
                            }
                        }
                    }
                    foreach (var buildingPart in submitedRevision.Building.Basement)
                    {
                        var ormBldPart = new ORM_RES_BLD_Basement();
                        var result = ormBldPart.Load(Connection, Transaction, buildingPart.RES_BLD_BasementID);

                        if (result.Status != FR_Status.Success || ormBldPart.Tenant_RefID == Guid.Empty)
                        {
                            ormBldPart = new ORM_RES_BLD_Basement()
                            {
                                Building_RefID = ormBuilding.RES_BLD_BuildingID,
                                Tenant_RefID = securityTicket.TenantID
                            };
                        }

                        ormBldPart.TypeOfFloor_RefID = buildingPart.Basement_FloorType;
                        ormBldPart.Save(Connection, Transaction);
                    }
                    #endregion

                    //Submission part
                    #region apartment submission
                    foreach (var subBuildingPart in submitedRevision.ApartmentSubmissionInfo)
                    {
                        var str_apartment = new ORM_RES_STR_Apartment();
                        var result = str_apartment.Load(Connection, Transaction, subBuildingPart.RES_STR_ApartmentID);

                        if (result.Status != FR_Status.Success || str_apartment.Tenant_RefID == Guid.Empty)
                        {
                            ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                            structureHeader.Save(Connection, Transaction);


                            str_apartment = new ORM_RES_STR_Apartment()
                            {
                                DUD_Revision_RefID = revision.RES_DUD_RevisionID,
                                RES_BLD_Apartment_RefID = subBuildingPart.RES_BLD_Apartment_RefID,
                                RES_STR_ApartmentID = subBuildingPart.RES_STR_ApartmentID,
                                DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID,
                                Tenant_RefID = securityTicket.TenantID
                            };
                        }
                        if (subBuildingPart.AverageRating_RefID != Guid.Empty)
                            str_apartment.AverageRating_RefID = subBuildingPart.AverageRating_RefID;
                        str_apartment.Comment = subBuildingPart.Apartment_Comment;
                        str_apartment.Save(Connection, Transaction);

                        #region delete_buildingPart_images
                        allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                        {
                            Structure_Header_RefID = str_apartment.DocumentHeader_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                        allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                        foreach (var docStructure in allDocsStructure)
                        {
                            allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                            {
                                Structure_RefID = docStructure.DOC_StructureID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).ToList());
                        }
                        allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                        foreach (var doc in allDocuments2Structure)
                        {
                            allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                            {
                                Document_RefID = doc.Document_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }));
                        }
                        if (subBuildingPart.Images.Count() < allRevisionDocs.Count())
                        {
                            var submittedImages = subBuildingPart.Images.ToList();
                            foreach (var item in allRevisionDocs)
                            {
                                if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                {
                                    item.Remove(Connection, Transaction);
                                }
                            }
                        }
                        #endregion

                        foreach (var image in subBuildingPart.Images)
                        {
                            cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                            {
                                DOC_StructureHeaderRefID = str_apartment.DocumentHeader_RefID,
                                DOC_DocumentRevisionID = image,
                            }, securityTicket);
                        }

                        foreach (var subPropAssessment in subBuildingPart.ApartmentPropertyAsessments)
                        {

                            var property = ORM_RES_STR_Apartment_Property.Query.Search(Connection, Transaction, new ORM_RES_STR_Apartment_Property.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                GlobalPropertyMatchingID = subPropAssessment.GlobalPropertyMatchingID
                            }).FirstOrDefault();

                            var propertyAssessment = ORM_RES_STR_Apartment_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_Apartment_PropertyAssessment.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                STR_Apartment_RefID = str_apartment.RES_STR_ApartmentID,
                                ApartmentProperty_RefID = property.RES_STR_Apartment_PropertyID
                            }).FirstOrDefault();


                            if (propertyAssessment == null || propertyAssessment.RES_STR_Apartment_PropertyAssessmentID == Guid.Empty)
                            {
                                ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                                structureHeader.Save(Connection, Transaction);
                                propertyAssessment = new ORM_RES_STR_Apartment_PropertyAssessment()
                                {
                                    ApartmentProperty_RefID = property.RES_STR_Apartment_PropertyID,
                                    STR_Apartment_RefID = subBuildingPart.RES_STR_ApartmentID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID,
                                    Rating_RefID = subPropAssessment.Rating_RefID
                                };
                            }
                            propertyAssessment.Comment = subPropAssessment.PropertyAssessment_Comment;

                            propertyAssessment.Save(Connection, Transaction);

                            #region delete_buildingPartProperty_images
                            allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                            {
                                Structure_Header_RefID = propertyAssessment.DocumentHeader_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            });
                            allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                            foreach (var docStructure in allDocsStructure)
                            {
                                allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                                {
                                    Structure_RefID = docStructure.DOC_StructureID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).ToList());
                            }
                            allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                            foreach (var doc in allDocuments2Structure)
                            {
                                allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                                {
                                    Document_RefID = doc.Document_RefID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }));
                            }
                            if (subPropAssessment.Images.Count() < allRevisionDocs.Count())
                            {
                                var submittedImages = subPropAssessment.Images.ToList();
                                foreach (var item in allRevisionDocs)
                                {
                                    if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                    {
                                        item.Remove(Connection, Transaction);
                                    }
                                }
                            }
                            #endregion

                            foreach (var image in subPropAssessment.Images)
                            {
                                cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                                {
                                    DOC_StructureHeaderRefID = propertyAssessment.DocumentHeader_RefID,
                                    DOC_DocumentRevisionID = image,
                                }, securityTicket);
                            }

                            foreach (var subReqAction in subPropAssessment.ApartmentReqActions)
                            {
                                var requiredAction = new ORM_RES_STR_Apartment_RequiredAction();
                                var actionResult = requiredAction.Load(Connection, Transaction, subReqAction.RES_STR_Apartment_RequiredActionID);

                                if (actionResult.Status != FR_Status.Success || requiredAction.Tenant_RefID == Guid.Empty)
                                {
                                    requiredAction = new ORM_RES_STR_Apartment_RequiredAction()
                                    {
                                        ApartmentPropertyAssessment_RefID = propertyAssessment.RES_STR_Apartment_PropertyAssessmentID,
                                        Tenant_RefID = securityTicket.TenantID
                                    };
                                }

                                requiredAction.Action_PricePerUnit_RefID = subReqAction.Action_PricePerUnit_RefID;
                                requiredAction.Action_Timeframe_RefID = subReqAction.Action_Timeframe_RefID;
                                requiredAction.Action_Unit_RefID = subReqAction.Action_Unit_RefID;
                                requiredAction.Action_UnitAmount = subReqAction.Action_UnitAmount;
                                requiredAction.Comment = subReqAction.RequiredAction_Comment;
                                requiredAction.EffectivePrice_RefID = subReqAction.EffectivePrice_RefID;
                                requiredAction.IfCustom_Description = subReqAction.IfCustom_Description;
                                requiredAction.IfCustom_Name = subReqAction.IfCustom_Name;
                                requiredAction.IsCustom = subReqAction.IsCustom;
                                requiredAction.SelectedActionVersion_RefID = subReqAction.SelectedActionVersion_RefID;
                                requiredAction.Save(Connection, Transaction);
                            }
                        }
                    }
                    #endregion

                    #region attic submission
                    foreach (var subBuildingPart in submitedRevision.AtticSubmissionInfo)
                    {
                        var str_attic = new ORM_RES_STR_Attic();
                        var result = str_attic.Load(Connection, Transaction, subBuildingPart.RES_STR_AtticID);

                        if (result.Status != FR_Status.Success || str_attic.Tenant_RefID == Guid.Empty)
                        {
                            ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                            structureHeader.Save(Connection, Transaction);

                            str_attic = new ORM_RES_STR_Attic()
                            {
                                DUD_Revision_RefID = revision.RES_DUD_RevisionID,
                                RES_BLD_Attic_RefID = subBuildingPart.RES_BLD_Attic_RefID,
                                RES_STR_AtticID = subBuildingPart.RES_STR_AtticID,
                                Tenant_RefID = securityTicket.TenantID,
                                DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID
                            };
                        }
                        if (subBuildingPart.AverageRating_RefID != Guid.Empty)
                            str_attic.AverageRating_RefID = subBuildingPart.AverageRating_RefID;
                        str_attic.Comment = subBuildingPart.Attic_Comment;
                        str_attic.Save(Connection, Transaction);

                        #region delete_buildingPart_images
                        allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                        {
                            Structure_Header_RefID = str_attic.DocumentHeader_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                        allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                        foreach (var docStructure in allDocsStructure)
                        {
                            allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                            {
                                Structure_RefID = docStructure.DOC_StructureID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).ToList());
                        }
                        allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                        foreach (var doc in allDocuments2Structure)
                        {
                            allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                            {
                                Document_RefID = doc.Document_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }));
                        }
                        if (subBuildingPart.Images.Count() < allRevisionDocs.Count())
                        {
                            var submittedImages = subBuildingPart.Images.ToList();
                            foreach (var item in allRevisionDocs)
                            {
                                if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                {
                                    item.Remove(Connection, Transaction);
                                }
                            }
                        }
                        #endregion

                        foreach (var image in subBuildingPart.Images)
                        {
                            cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                            {
                                DOC_StructureHeaderRefID = str_attic.DocumentHeader_RefID,
                                DOC_DocumentRevisionID = image,
                            }, securityTicket);
                        }

                        foreach (var subPropAssessment in subBuildingPart.AtticPropertyAsessments)
                        {

                            var property = ORM_RES_STR_Attic_Property.Query.Search(Connection, Transaction, new ORM_RES_STR_Attic_Property.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                GlobalPropertyMatchingID = subPropAssessment.GlobalPropertyMatchingID
                            }).FirstOrDefault();

                            var propertyAssessment = ORM_RES_STR_Attic_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_Attic_PropertyAssessment.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                STR_Attic_RefID = str_attic.RES_STR_AtticID,
                                AtticProperty_RefID = property.RES_STR_Attic_PropertyID
                            }).FirstOrDefault();

                            if (propertyAssessment == null || propertyAssessment.RES_STR_Attic_PropertyAssessmentID == Guid.Empty)
                            {
                                ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                                structureHeader.Save(Connection, Transaction);

                                propertyAssessment = new ORM_RES_STR_Attic_PropertyAssessment()
                                {
                                    AtticProperty_RefID = property.RES_STR_Attic_PropertyID,
                                    STR_Attic_RefID = subBuildingPart.RES_STR_AtticID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID,
                                    Rating_RefID = subPropAssessment.Rating_RefID
                                };
                            }
                            propertyAssessment.Comment = subPropAssessment.PropertyAssessment_Comment;
                            propertyAssessment.Save(Connection, Transaction);

                            #region delete_buildingPartProperty_images
                            allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                            {
                                Structure_Header_RefID = propertyAssessment.DocumentHeader_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            });
                            allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                            foreach (var docStructure in allDocsStructure)
                            {
                                allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                                {
                                    Structure_RefID = docStructure.DOC_StructureID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).ToList());
                            }
                            allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                            foreach (var doc in allDocuments2Structure)
                            {
                                allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                                {
                                    Document_RefID = doc.Document_RefID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }));
                            }
                            if (subPropAssessment.Images.Count() < allRevisionDocs.Count())
                            {
                                var submittedImages = subPropAssessment.Images.ToList();
                                foreach (var item in allRevisionDocs)
                                {
                                    if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                    {
                                        item.Remove(Connection, Transaction);
                                    }
                                }
                            }
                            #endregion

                            foreach (var image in subPropAssessment.Images)
                            {
                                cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                                {
                                    DOC_StructureHeaderRefID = propertyAssessment.DocumentHeader_RefID,
                                    DOC_DocumentRevisionID = image,
                                }, securityTicket);
                            }

                            foreach (var subReqAction in subPropAssessment.AtticReqActions)
                            {
                                var requiredAction = new ORM_RES_STR_Attic_RequiredAction();
                                var actionResult = requiredAction.Load(Connection, Transaction, subReqAction.RES_STR_Attic_RequiredActionID);

                                if (actionResult.Status != FR_Status.Success || requiredAction.Tenant_RefID == Guid.Empty)
                                {
                                    requiredAction = new ORM_RES_STR_Attic_RequiredAction()
                                    {
                                        AtticPropertyAssestment_RefID = propertyAssessment.RES_STR_Attic_PropertyAssessmentID,
                                        Tenant_RefID = securityTicket.TenantID
                                    };
                                }

                                requiredAction.Action_PricePerUnit_RefID = subReqAction.Action_PricePerUnit_RefID;
                                requiredAction.Action_Timeframe_RefID = subReqAction.Action_Timeframe_RefID;
                                requiredAction.Action_Unit_RefID = subReqAction.Action_Unit_RefID;
                                requiredAction.Action_UnitAmount = subReqAction.Action_UnitAmount;
                                requiredAction.Comment = subReqAction.RequiredAction_Comment;
                                requiredAction.EffectivePrice_RefID = subReqAction.EffectivePrice_RefID;
                                requiredAction.IfCustom_Description = subReqAction.IfCustom_Description;
                                requiredAction.IfCustom_Name = subReqAction.IfCustom_Name;
                                requiredAction.IsCustom = subReqAction.IsCustom;
                                requiredAction.SelectedActionVersion_RefID = subReqAction.SelectedActionVersion_RefID;
                                requiredAction.Save(Connection, Transaction);
                            }
                        }
                    }
                    #endregion


                    //Submission part
                    #region basement submission
                    foreach (var subBuildingPart in submitedRevision.BasementSubmissionInfo)
                    {
                        var str_basement = new ORM_RES_STR_Basement();
                        var result = str_basement.Load(Connection, Transaction, subBuildingPart.RES_STR_BasementID);

                        if (result.Status != FR_Status.Success || str_basement.Tenant_RefID == Guid.Empty)
                        {
                            ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                            structureHeader.Save(Connection, Transaction);

                            str_basement = new ORM_RES_STR_Basement()
                            {
                                DUD_Revision_RefID = revision.RES_DUD_RevisionID,
                                RES_BLD_Basement_RefID = subBuildingPart.RES_BLD_Basement_RefID,
                                RES_STR_BasementID = subBuildingPart.RES_STR_BasementID,
                                Tenant_RefID = securityTicket.TenantID,
                                DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID
                            };
                        }
                        if (subBuildingPart.AverageRating_RefID != Guid.Empty)
                            str_basement.AverageRating_RefID = subBuildingPart.AverageRating_RefID;
                        str_basement.Comment = subBuildingPart.Basement_Comment;
                        str_basement.Save(Connection, Transaction);

                        #region delete_buildingPart_images
                        allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                        {
                            Structure_Header_RefID = str_basement.DocumentHeader_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                        allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                        foreach (var docStructure in allDocsStructure)
                        {
                            allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                            {
                                Structure_RefID = docStructure.DOC_StructureID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).ToList());
                        }
                        allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                        foreach (var doc in allDocuments2Structure)
                        {
                            allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                            {
                                Document_RefID = doc.Document_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }));
                        }
                        if (subBuildingPart.Images.Count() < allRevisionDocs.Count())
                        {
                            var submittedImages = subBuildingPart.Images.ToList();
                            foreach (var item in allRevisionDocs)
                            {
                                if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                {
                                    item.Remove(Connection, Transaction);
                                }
                            }
                        }
                        #endregion

                        foreach (var image in subBuildingPart.Images)
                        {
                            cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                            {
                                DOC_StructureHeaderRefID = str_basement.DocumentHeader_RefID,
                                DOC_DocumentRevisionID = image,
                            }, securityTicket);
                        }

                        foreach (var subPropAssessment in subBuildingPart.BasementPropertyAsessments)
                        {

                            var property = ORM_RES_STR_Basement_Property.Query.Search(Connection, Transaction, new ORM_RES_STR_Basement_Property.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                GlobalPropertyMatchingID = subPropAssessment.GlobalPropertyMatchingID
                            }).FirstOrDefault();

                            var propertyAssessment = ORM_RES_STR_Basement_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_Basement_PropertyAssessment.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                STR_Basement_RefID = str_basement.RES_STR_BasementID,
                                BasementProperty_RefID = property.RES_STR_Basement_PropertyID
                            }).FirstOrDefault();

                            if (propertyAssessment == null || propertyAssessment.RES_STR_Basement_PropertyAssessmentID == Guid.Empty)
                            {
                                ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                                structureHeader.Save(Connection, Transaction);

                                propertyAssessment = new ORM_RES_STR_Basement_PropertyAssessment()
                                {
                                    BasementProperty_RefID = property.RES_STR_Basement_PropertyID,
                                    STR_Basement_RefID = subBuildingPart.RES_STR_BasementID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID,
                                    Rating_RefID = subPropAssessment.Rating_RefID
                                };
                            }
                            propertyAssessment.Comment = subPropAssessment.PropertyAssessment_Comment;
                            propertyAssessment.Save(Connection, Transaction);

                            #region delete_buildingPartProperty_images
                            allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                            {
                                Structure_Header_RefID = propertyAssessment.DocumentHeader_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            });
                            allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                            foreach (var docStructure in allDocsStructure)
                            {
                                allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                                {
                                    Structure_RefID = docStructure.DOC_StructureID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).ToList());
                            }
                            allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                            foreach (var doc in allDocuments2Structure)
                            {
                                allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                                {
                                    Document_RefID = doc.Document_RefID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }));
                            }
                            if (subPropAssessment.Images.Count() < allRevisionDocs.Count())
                            {
                                var submittedImages = subPropAssessment.Images.ToList();
                                foreach (var item in allRevisionDocs)
                                {
                                    if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                    {
                                        item.Remove(Connection, Transaction);
                                    }
                                }
                            }
                            #endregion

                            foreach (var image in subPropAssessment.Images)
                            {
                                cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                                {
                                    DOC_StructureHeaderRefID = propertyAssessment.DocumentHeader_RefID,
                                    DOC_DocumentRevisionID = image,
                                }, securityTicket);
                            }

                            foreach (var subReqAction in subPropAssessment.BasementReqActions)
                            {
                                var requiredAction = new ORM_RES_STR_Basement_RequiredAction();
                                var actionResult = requiredAction.Load(Connection, Transaction, subReqAction.RES_STR_Basement_RequiredActionID);

                                if (actionResult.Status != FR_Status.Success || requiredAction.Tenant_RefID == Guid.Empty)
                                {
                                    requiredAction = new ORM_RES_STR_Basement_RequiredAction()
                                    {
                                        BasementPropertyAssestment_RefID = propertyAssessment.RES_STR_Basement_PropertyAssessmentID,
                                        Tenant_RefID = securityTicket.TenantID
                                    };
                                }

                                requiredAction.Action_PricePerUnit_RefID = subReqAction.Action_PricePerUnit_RefID;
                                requiredAction.Action_Timeframe_RefID = subReqAction.Action_Timeframe_RefID;
                                requiredAction.Action_Unit_RefID = subReqAction.Action_Unit_RefID;
                                requiredAction.Action_UnitAmount = subReqAction.Action_UnitAmount;
                                requiredAction.Comment = subReqAction.RequiredAction_Comment;
                                requiredAction.EffectivePrice_RefID = subReqAction.EffectivePrice_RefID;
                                requiredAction.IfCustom_Description = subReqAction.IfCustom_Description;
                                requiredAction.IfCustom_Name = subReqAction.IfCustom_Name;
                                requiredAction.IsCustom = subReqAction.IsCustom;
                                requiredAction.SelectedActionVersion_RefID = subReqAction.SelectedActionVersion_RefID;
                                requiredAction.Save(Connection, Transaction);
                            }
                        }
                    }

                    #endregion
                    //Submission part
                    #region facade submission
                    foreach (var subBuildingPart in submitedRevision.FacadeSubmissionInfo)
                    {
                        var str_facade = new ORM_RES_STR_Facade();
                        var result = str_facade.Load(Connection, Transaction, subBuildingPart.RES_STR_FacadeID);

                        if (result.Status != FR_Status.Success || str_facade.Tenant_RefID == Guid.Empty)
                        {
                            ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                            structureHeader.Save(Connection, Transaction);

                            str_facade = new ORM_RES_STR_Facade()
                            {
                                DUD_Revision_RefID = revision.RES_DUD_RevisionID,
                                RES_BLD_Facade_RefID = subBuildingPart.RES_BLD_Facade_RefID,
                                RES_STR_FacadeID = subBuildingPart.RES_STR_FacadeID,
                                Tenant_RefID = securityTicket.TenantID,
                                DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID
                            };
                        }
                        if (subBuildingPart.AverageRating_RefID != Guid.Empty)
                            str_facade.AverageRating_RefID = subBuildingPart.AverageRating_RefID;
                        str_facade.Comment = subBuildingPart.Facade_Comment;
                        str_facade.Save(Connection, Transaction);

                        #region delete_buildingPart_images
                        allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                        {
                            Structure_Header_RefID = str_facade.DocumentHeader_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                        allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                        foreach (var docStructure in allDocsStructure)
                        {
                            allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                            {
                                Structure_RefID = docStructure.DOC_StructureID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).ToList());
                        }
                        allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                        foreach (var doc in allDocuments2Structure)
                        {
                            allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                            {
                                Document_RefID = doc.Document_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }));
                        }
                        if (subBuildingPart.Images.Count() < allRevisionDocs.Count())
                        {
                            var submittedImages = subBuildingPart.Images.ToList();
                            foreach (var item in allRevisionDocs)
                            {
                                if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                {
                                    item.Remove(Connection, Transaction);
                                }
                            }
                        }
                        #endregion

                        foreach (var image in subBuildingPart.Images)
                        {
                            cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                            {
                                DOC_StructureHeaderRefID = str_facade.DocumentHeader_RefID,
                                DOC_DocumentRevisionID = image,
                            }, securityTicket);
                        }

                        foreach (var subPropAssessment in subBuildingPart.FacadePropertyAsessments)
                        {

                            var property = ORM_RES_STR_Facade_Property.Query.Search(Connection, Transaction, new ORM_RES_STR_Facade_Property.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                GlobalPropertyMatchingID = subPropAssessment.GlobalPropertyMatchingID
                            }).FirstOrDefault();
                            var propertyAssessment = ORM_RES_STR_Facade_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_Facade_PropertyAssessment.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                STR_Facade_RefID = str_facade.RES_STR_FacadeID,
                                FacadeProperty_RefID = property.RES_STR_Facade_PropertyID
                            }).FirstOrDefault();
                            if (propertyAssessment == null || propertyAssessment.RES_STR_Facade_PropertyAssessmentID == Guid.Empty)
                            {
                                ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                                structureHeader.Save(Connection, Transaction);

                                propertyAssessment = new ORM_RES_STR_Facade_PropertyAssessment()
                                {
                                    FacadeProperty_RefID = property.RES_STR_Facade_PropertyID,
                                    STR_Facade_RefID = subBuildingPart.RES_STR_FacadeID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID,
                                    Rating_RefID = subPropAssessment.Rating_RefID
                                };
                            }
                            propertyAssessment.Comment = subPropAssessment.PropertyAssessment_Comment;
                            propertyAssessment.Save(Connection, Transaction);

                            #region delete_buildingPartProperty_images
                            allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                            {
                                Structure_Header_RefID = propertyAssessment.DocumentHeader_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            });
                            allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                            foreach (var docStructure in allDocsStructure)
                            {
                                allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                                {
                                    Structure_RefID = docStructure.DOC_StructureID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).ToList());
                            }
                            allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                            foreach (var doc in allDocuments2Structure)
                            {
                                allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                                {
                                    Document_RefID = doc.Document_RefID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }));
                            }
                            if (subPropAssessment.Images.Count() < allRevisionDocs.Count())
                            {
                                var submittedImages = subPropAssessment.Images.ToList();
                                foreach (var item in allRevisionDocs)
                                {
                                    if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                    {
                                        item.Remove(Connection, Transaction);
                                    }
                                }
                            }
                            #endregion

                            foreach (var image in subPropAssessment.Images)
                            {
                                cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                                {
                                    DOC_StructureHeaderRefID = propertyAssessment.DocumentHeader_RefID,
                                    DOC_DocumentRevisionID = image,
                                }, securityTicket);
                            }

                            foreach (var subReqAction in subPropAssessment.FacadeReqActions)
                            {
                                var requiredAction = new ORM_RES_STR_Facade_RequiredAction();
                                var actionResult = requiredAction.Load(Connection, Transaction, subReqAction.RES_STR_Facade_RequiredActionID);

                                if (actionResult.Status != FR_Status.Success || requiredAction.Tenant_RefID == Guid.Empty)
                                {
                                    requiredAction = new ORM_RES_STR_Facade_RequiredAction()
                                    {
                                        FacadePropertyAssestment_RefID = propertyAssessment.RES_STR_Facade_PropertyAssessmentID,
                                        Tenant_RefID = securityTicket.TenantID
                                    };
                                }

                                requiredAction.Action_PricePerUnit_RefID = subReqAction.Action_PricePerUnit_RefID;
                                requiredAction.Action_Timeframe_RefID = subReqAction.Action_Timeframe_RefID;
                                requiredAction.Action_Unit_RefID = subReqAction.Action_Unit_RefID;
                                requiredAction.Action_UnitAmount = subReqAction.Action_UnitAmount;
                                requiredAction.Comment = subReqAction.RequiredActions_Comment;
                                requiredAction.EffectivePrice_RefID = subReqAction.EffectivePrice_RefID;
                                requiredAction.IfCustom_Description = subReqAction.IfCustom_Description;
                                requiredAction.IfCustom_Name = subReqAction.IfCustom_Name;
                                requiredAction.IsCustom = subReqAction.IsCustom;
                                requiredAction.SelectedActionVersion_RefID = subReqAction.SelectedActionVersion_RefID;
                                requiredAction.Save(Connection, Transaction);
                            }
                        }
                    }
                    #endregion

                    //Submission part
                    #region outdoorFacility submission
                    foreach (var subBuildingPart in submitedRevision.OutdoorFascilitySubmissionInfo)
                    {
                        var str_outdoorFacility = new ORM_RES_STR_OutdoorFacility();
                        var result = str_outdoorFacility.Load(Connection, Transaction, subBuildingPart.RES_STR_OutdoorFacilityID);

                        if (result.Status != FR_Status.Success || str_outdoorFacility.Tenant_RefID == Guid.Empty)
                        {
                            ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                            structureHeader.Save(Connection, Transaction);

                            str_outdoorFacility = new ORM_RES_STR_OutdoorFacility()
                            {
                                DUD_Revision_RefID = revision.RES_DUD_RevisionID,
                                RES_BLD_OutdoorFacility_RefID = subBuildingPart.RES_BLD_OutdoorFacility_RefID,
                                RES_STR_OutdoorFacilityID = subBuildingPart.RES_STR_OutdoorFacilityID,
                                Tenant_RefID = securityTicket.TenantID,
                                DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID
                            };
                        }
                        if (subBuildingPart.AverageRating_RefID != Guid.Empty)
                            str_outdoorFacility.AverageRating_RefID = subBuildingPart.AverageRating_RefID;
                        str_outdoorFacility.Comment = subBuildingPart.OutdoorF_Comment;
                        str_outdoorFacility.Save(Connection, Transaction);

                        #region delete_buildingPart_images
                        allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                        {
                            Structure_Header_RefID = str_outdoorFacility.DocumentHeader_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                        allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                        foreach (var docStructure in allDocsStructure)
                        {
                            allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                            {
                                Structure_RefID = docStructure.DOC_StructureID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).ToList());
                        }
                        allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                        foreach (var doc in allDocuments2Structure)
                        {
                            allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                            {
                                Document_RefID = doc.Document_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }));
                        }
                        if (subBuildingPart.Images.Count() < allRevisionDocs.Count())
                        {
                            var submittedImages = subBuildingPart.Images.ToList();
                            foreach (var item in allRevisionDocs)
                            {
                                if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                {
                                    item.Remove(Connection, Transaction);
                                }
                            }
                        }
                        #endregion

                        foreach (var image in subBuildingPart.Images)
                        {
                            cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                            {
                                DOC_StructureHeaderRefID = str_outdoorFacility.DocumentHeader_RefID,
                                DOC_DocumentRevisionID = image,
                            }, securityTicket);
                        }

                        foreach (var subPropAssessment in subBuildingPart.OutdoorFacilityAsessments)
                        {

                            var property = ORM_RES_STR_OutdoorFacility_Property.Query.Search(Connection, Transaction, new ORM_RES_STR_OutdoorFacility_Property.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                GlobalPropertyMatchingID = subPropAssessment.GlobalPropertyMatchingID
                            }).FirstOrDefault();
                            var propertyAssessment = ORM_RES_STR_OutdoorFacility_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_OutdoorFacility_PropertyAssessment.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                STR_OutdoorFacility_RefID = str_outdoorFacility.RES_STR_OutdoorFacilityID,
                                OutdoorFacilityProperty_RefID = property.RES_STR_OutdoorFacility_PropertyID
                            }).FirstOrDefault();
                            if (propertyAssessment == null || propertyAssessment.RES_STR_OutdoorFacility_PropertyAssessmentID == Guid.Empty)
                            {
                                ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                                structureHeader.Save(Connection, Transaction);

                                propertyAssessment = new ORM_RES_STR_OutdoorFacility_PropertyAssessment()
                                {
                                    OutdoorFacilityProperty_RefID = property.RES_STR_OutdoorFacility_PropertyID,
                                    STR_OutdoorFacility_RefID = subBuildingPart.RES_STR_OutdoorFacilityID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID,
                                    Rating_RefID = subPropAssessment.Rating_RefID
                                };
                            }
                            propertyAssessment.Comment = subPropAssessment.PropertyAssessment_Comment;
                            propertyAssessment.Save(Connection, Transaction);

                            #region delete_buildingPartProperty_images
                            allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                            {
                                Structure_Header_RefID = propertyAssessment.DocumentHeader_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            });
                            allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                            foreach (var docStructure in allDocsStructure)
                            {
                                allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                                {
                                    Structure_RefID = docStructure.DOC_StructureID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).ToList());
                            }
                            allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                            foreach (var doc in allDocuments2Structure)
                            {
                                allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                                {
                                    Document_RefID = doc.Document_RefID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }));
                            }
                            if (subPropAssessment.Images.Count() < allRevisionDocs.Count())
                            {
                                var submittedImages = subPropAssessment.Images.ToList();
                                foreach (var item in allRevisionDocs)
                                {
                                    if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                    {
                                        item.Remove(Connection, Transaction);
                                    }
                                }
                            }
                            #endregion

                            foreach (var image in subPropAssessment.Images)
                            {
                                cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                                {
                                    DOC_StructureHeaderRefID = propertyAssessment.DocumentHeader_RefID,
                                    DOC_DocumentRevisionID = image,
                                }, securityTicket);
                            }

                            foreach (var subReqAction in subPropAssessment.OutdoorFacilityReqActions)
                            {
                                var requiredAction = new ORM_RES_STR_OutdoorFacility_RequiredAction();
                                var actionResult = requiredAction.Load(Connection, Transaction, subReqAction.RES_STR_OutdoorFacility_RequiredActionID);

                                if (actionResult.Status != FR_Status.Success || requiredAction.Tenant_RefID == Guid.Empty)
                                {
                                    requiredAction = new ORM_RES_STR_OutdoorFacility_RequiredAction()
                                    {
                                        OutdoorFacilityPropertyAssestment_RefID = propertyAssessment.RES_STR_OutdoorFacility_PropertyAssessmentID,
                                        Tenant_RefID = securityTicket.TenantID
                                    };
                                }

                                requiredAction.Action_PricePerUnit_RefID = subReqAction.Action_PricePerUnit_RefID;
                                requiredAction.Action_Timeframe_RefID = subReqAction.Action_Timeframe_RefID;
                                requiredAction.Action_Unit_RefID = subReqAction.Action_Unit_RefID;
                                requiredAction.Action_UnitAmount = subReqAction.Action_UnitAmount;
                                requiredAction.Comment = subReqAction.RequiredAction_Comment;
                                requiredAction.EffectivePrice_RefID = subReqAction.EffectivePrice_RefID;
                                requiredAction.IfCustom_Description = subReqAction.IfCustom_Description;
                                requiredAction.IfCustom_Name = subReqAction.IfCustom_Name;
                                requiredAction.IsCustom = subReqAction.IsCustom;
                                requiredAction.SelectedActionVersion_RefID = subReqAction.SelectedActionVersion_RefID;
                                requiredAction.Save(Connection, Transaction);
                            }
                        }
                    }
                    #endregion

                    //Submission part
                    #region staircase submission
                    foreach (var subBuildingPart in submitedRevision.StaircaseSubmissionInfo)
                    {
                        var str_staircase = new ORM_RES_STR_Staircase();
                        var result = str_staircase.Load(Connection, Transaction, subBuildingPart.RES_STR_StaircaseID);

                        if (result.Status != FR_Status.Success || str_staircase.Tenant_RefID == Guid.Empty)
                        {
                            ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                            structureHeader.Save(Connection, Transaction);

                            str_staircase = new ORM_RES_STR_Staircase()
                            {
                                DUD_Revision_RefID = revision.RES_DUD_RevisionID,
                                RES_BLD_Staircase_RefID = subBuildingPart.RES_BLD_Staircase_RefID,
                                RES_STR_StaircaseID = subBuildingPart.RES_STR_StaircaseID,
                                Tenant_RefID = securityTicket.TenantID,
                                DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID
                            };
                        }
                        if (subBuildingPart.AverageRating_RefID != Guid.Empty)
                            str_staircase.AverageRating_RefID = subBuildingPart.AverageRating_RefID;
                        str_staircase.Comment = subBuildingPart.Staircase_Comment;
                        str_staircase.Save(Connection, Transaction);

                        #region delete_buildingPart_images
                        allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                        {
                            Structure_Header_RefID = str_staircase.DocumentHeader_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                        allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                        foreach (var docStructure in allDocsStructure)
                        {
                            allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                            {
                                Structure_RefID = docStructure.DOC_StructureID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).ToList());
                        }
                        allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                        foreach (var doc in allDocuments2Structure)
                        {
                            allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                            {
                                Document_RefID = doc.Document_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }));
                        }
                        if (subBuildingPart.Images.Count() < allRevisionDocs.Count())
                        {
                            var submittedImages = subBuildingPart.Images.ToList();
                            foreach (var item in allRevisionDocs)
                            {
                                if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                {
                                    item.Remove(Connection, Transaction);
                                }
                            }
                        }
                        #endregion

                        foreach (var image in subBuildingPart.Images)
                        {
                            cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                            {
                                DOC_StructureHeaderRefID = str_staircase.DocumentHeader_RefID,
                                DOC_DocumentRevisionID = image,
                            }, securityTicket);
                        }

                        foreach (var subPropAssessment in subBuildingPart.StaircasePropertyAsessments)
                        {
                            var property = ORM_RES_STR_Staircase_Property.Query.Search(Connection, Transaction, new ORM_RES_STR_Staircase_Property.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                GlobalPropertyMatchingID = subPropAssessment.GlobalPropertyMatchingID
                            }).FirstOrDefault();

                            var propertyAssessment = ORM_RES_STR_Staircase_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_Staircase_PropertyAssessment.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                STR_Staircase_RefID = str_staircase.RES_STR_StaircaseID,
                                StaircaseProperty_RefID = property.RES_STR_Staircase_PropertyID
                            }).FirstOrDefault();
                            if (propertyAssessment == null || propertyAssessment.RES_STR_Staircase_PropertyAssessmentID == Guid.Empty)
                            {
                                ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                                structureHeader.Save(Connection, Transaction);

                                propertyAssessment = new ORM_RES_STR_Staircase_PropertyAssessment()
                                {
                                    StaircaseProperty_RefID = property.RES_STR_Staircase_PropertyID,
                                    STR_Staircase_RefID = subBuildingPart.RES_STR_StaircaseID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID,
                                    Rating_RefID = subPropAssessment.Rating_RefID
                                };
                            }
                            propertyAssessment.Comment = subPropAssessment.PropertyAssessment_Comment;
                            propertyAssessment.Save(Connection, Transaction);

                            #region delete_buildingPartProperty_images
                            allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                            {
                                Structure_Header_RefID = propertyAssessment.DocumentHeader_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            });
                            allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                            foreach (var docStructure in allDocsStructure)
                            {
                                allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                                {
                                    Structure_RefID = docStructure.DOC_StructureID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).ToList());
                            }
                            allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                            foreach (var doc in allDocuments2Structure)
                            {
                                allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                                {
                                    Document_RefID = doc.Document_RefID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }));
                            }
                            if (subPropAssessment.Images.Count() < allRevisionDocs.Count())
                            {
                                var submittedImages = subPropAssessment.Images.ToList();
                                foreach (var item in allRevisionDocs)
                                {
                                    if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                    {
                                        item.Remove(Connection, Transaction);
                                    }
                                }
                            }
                            #endregion

                            foreach (var image in subPropAssessment.Images)
                            {
                                cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                                {
                                    DOC_StructureHeaderRefID = propertyAssessment.DocumentHeader_RefID,
                                    DOC_DocumentRevisionID = image,
                                }, securityTicket);
                            }

                            foreach (var subReqAction in subPropAssessment.StaircaseReqActions)
                            {
                                var requiredAction = new ORM_RES_STR_Staircase_RequiredAction();
                                var actionResult = requiredAction.Load(Connection, Transaction, subReqAction.RES_STR_Staircase_RequiredActionID);

                                if (actionResult.Status != FR_Status.Success || requiredAction.Tenant_RefID == Guid.Empty)
                                {
                                    requiredAction = new ORM_RES_STR_Staircase_RequiredAction()
                                    {
                                        StaircasePropertyAssessment_RefID = propertyAssessment.RES_STR_Staircase_PropertyAssessmentID,
                                        Tenant_RefID = securityTicket.TenantID
                                    };
                                }

                                requiredAction.Action_PricePerUnit_RefID = subReqAction.Action_PricePerUnit_RefID;
                                requiredAction.Action_Timeframe_RefID = subReqAction.Action_Timeframe_RefID;
                                requiredAction.Action_Unit_RefID = subReqAction.Action_Unit_RefID;
                                requiredAction.Action_UnitAmount = subReqAction.Action_UnitAmount;
                                requiredAction.Comment = subReqAction.RequiredAction_Comment;
                                requiredAction.EffectivePrice_RefID = subReqAction.EffectivePrice_RefID;
                                requiredAction.IfCustom_Description = subReqAction.IfCustom_Description;
                                requiredAction.IfCustom_Name = subReqAction.IfCustom_Name;
                                requiredAction.IsCustom = subReqAction.IsCustom;
                                requiredAction.SelectedActionVersion_RefID = subReqAction.SelectedActionVersion_RefID;
                                requiredAction.Save(Connection, Transaction);
                            }
                        }
                    }
                    #endregion


                    //Submission part
                    #region HVACR submission
                    foreach (var subBuildingPart in submitedRevision.HVACRSubmissionInfo)
                    {
                        var str_HVACR = new ORM_RES_STR_HVACR();
                        var result = str_HVACR.Load(Connection, Transaction, subBuildingPart.RES_STR_HVACRID);

                        if (result.Status != FR_Status.Success || str_HVACR.Tenant_RefID == Guid.Empty)
                        {
                            ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                            structureHeader.Save(Connection, Transaction);

                            str_HVACR = new ORM_RES_STR_HVACR()
                            {
                                DUD_Revision_RefID = revision.RES_DUD_RevisionID,
                                RES_BLD_HVACR_RefID = subBuildingPart.RES_BLD_HVACR_RefID,
                                RES_STR_HVACRID = subBuildingPart.RES_STR_HVACRID,
                                Tenant_RefID = securityTicket.TenantID,
                                DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID
                            };
                        }
                        if (subBuildingPart.AverageRating_RefID != Guid.Empty)
                            str_HVACR.AverageRating_RefID = subBuildingPart.AverageRating_RefID;
                        str_HVACR.Comment = subBuildingPart.HVACR_Comment;
                        str_HVACR.Save(Connection, Transaction);

                        #region delete_buildingPart_images
                        allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                        {
                            Structure_Header_RefID = str_HVACR.DocumentHeader_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                        allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                        foreach (var docStructure in allDocsStructure)
                        {
                            allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                            {
                                Structure_RefID = docStructure.DOC_StructureID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).ToList());
                        }
                        allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                        foreach (var doc in allDocuments2Structure)
                        {
                            allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                            {
                                Document_RefID = doc.Document_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }));
                        }
                        if (subBuildingPart.Images.Count() < allRevisionDocs.Count())
                        {
                            var submittedImages = subBuildingPart.Images.ToList();
                            foreach (var item in allRevisionDocs)
                            {
                                if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                {
                                    item.Remove(Connection, Transaction);
                                }
                            }
                        }
                        #endregion

                        foreach (var image in subBuildingPart.Images)
                        {
                            cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                            {
                                DOC_StructureHeaderRefID = str_HVACR.DocumentHeader_RefID,
                                DOC_DocumentRevisionID = image,
                            }, securityTicket);
                        }

                        foreach (var subPropAssessment in subBuildingPart.HVACRPropertyAsessments)
                        {
                            var property = ORM_RES_STR_HVACR_Property.Query.Search(Connection, Transaction, new ORM_RES_STR_HVACR_Property.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                GlobalPropertyMatchingID = subPropAssessment.GlobalPropertyMatchingID
                            }).FirstOrDefault();
                            var propertyAssessment = ORM_RES_STR_HVACR_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_HVACR_PropertyAssessment.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                STR_HVACR_RefID = str_HVACR.RES_STR_HVACRID,
                                HVACRProperty_RefID = property.RES_STR_HVACR_PropertyID
                            }).FirstOrDefault();

                            if (propertyAssessment == null || propertyAssessment.RES_STR_HVACR_PropertyAssessmentID == Guid.Empty)
                            {
                                ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                                structureHeader.Save(Connection, Transaction);

                                propertyAssessment = new ORM_RES_STR_HVACR_PropertyAssessment()
                                {
                                    HVACRProperty_RefID = property.RES_STR_HVACR_PropertyID,
                                    STR_HVACR_RefID = subBuildingPart.RES_STR_HVACRID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID,
                                    Rating_RefID = subPropAssessment.Rating_RefID
                                };
                            }
                            propertyAssessment.Comment = subPropAssessment.PropertyAssessment_Comment;
                            propertyAssessment.Save(Connection, Transaction);

                            foreach (var image in subPropAssessment.Images)
                            {
                                cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                                {
                                    DOC_StructureHeaderRefID = propertyAssessment.DocumentHeader_RefID,
                                    DOC_DocumentRevisionID = image,
                                }, securityTicket);
                            }

                            #region delete_buildingPartProperty_images
                            allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                            {
                                Structure_Header_RefID = propertyAssessment.DocumentHeader_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            });
                            allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                            foreach (var docStructure in allDocsStructure)
                            {
                                allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                                {
                                    Structure_RefID = docStructure.DOC_StructureID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).ToList());
                            }
                            allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                            foreach (var doc in allDocuments2Structure)
                            {
                                allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                                {
                                    Document_RefID = doc.Document_RefID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }));
                            }
                            if (subPropAssessment.Images.Count() < allRevisionDocs.Count())
                            {
                                var submittedImages = subPropAssessment.Images.ToList();
                                foreach (var item in allRevisionDocs)
                                {
                                    if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                    {
                                        item.Remove(Connection, Transaction);
                                    }
                                }
                            }
                            #endregion

                            foreach (var subReqAction in subPropAssessment.HVACRReqActions)
                            {
                                var requiredAction = new ORM_RES_STR_HVACR_RequiredAction();
                                var actionResult = requiredAction.Load(Connection, Transaction, subReqAction.RES_STR_HVACR_RequiredActionID);

                                if (actionResult.Status != FR_Status.Success || requiredAction.Tenant_RefID == Guid.Empty)
                                {
                                    requiredAction = new ORM_RES_STR_HVACR_RequiredAction()
                                    {
                                        HVACRPropertyAssestment_RefID = propertyAssessment.RES_STR_HVACR_PropertyAssessmentID,
                                        Tenant_RefID = securityTicket.TenantID
                                    };
                                }

                                requiredAction.Action_PricePerUnit_RefID = subReqAction.Action_PricePerUnit_RefID;
                                requiredAction.Action_Timeframe_RefID = subReqAction.Action_Timeframe_RefID;
                                requiredAction.Action_Unit_RefID = subReqAction.Action_Unit_RefID;
                                requiredAction.Action_UnitAmount = subReqAction.Action_UnitAmount;
                                requiredAction.Comment = subReqAction.RequiredAction_Comment;
                                requiredAction.EffectivePrice_RefID = subReqAction.EffectivePrice_RefID;
                                requiredAction.IfCustom_Description = subReqAction.IfCustom_Description;
                                requiredAction.IfCustom_Name = subReqAction.IfCustom_Name;
                                requiredAction.IsCustom = subReqAction.IsCustom;
                                requiredAction.SelectedActionVersion_RefID = subReqAction.SelectedActionVersion_RefID;
                                requiredAction.Save(Connection, Transaction);
                            }
                        }
                    }
                    #endregion

                    #region roof submission
                    foreach (var subBuildingPart in submitedRevision.RoofSubmissionInfo)
                    {
                        var str_roof = new ORM_RES_STR_Roof();
                        var result = str_roof.Load(Connection, Transaction, subBuildingPart.RES_STR_RoofID);

                        if (result.Status != FR_Status.Success || str_roof.Tenant_RefID == Guid.Empty)
                        {
                            ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                            structureHeader.Save(Connection, Transaction);

                            str_roof = new ORM_RES_STR_Roof()
                            {
                                DUD_Revision_RefID = revision.RES_DUD_RevisionID,
                                RES_BLD_Roof_RefID = subBuildingPart.RES_BLD_Roof_RefID,
                                RES_STR_RoofID = subBuildingPart.RES_STR_RoofID,
                                Tenant_RefID = securityTicket.TenantID,
                                DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID
                            };
                        }
                        if (subBuildingPart.AverageRating_RefID != Guid.Empty)
                            str_roof.AverageRating_RefID = subBuildingPart.AverageRating_RefID;
                        str_roof.Comment = subBuildingPart.Roof_Comment;
                        str_roof.Save(Connection, Transaction);

                        #region delete_buildingPart_images
                        allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                        {
                            Structure_Header_RefID = str_roof.DocumentHeader_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                        allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                        foreach (var docStructure in allDocsStructure)
                        {
                            allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                            {
                                Structure_RefID = docStructure.DOC_StructureID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).ToList());
                        }
                        allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                        foreach (var doc in allDocuments2Structure)
                        {
                            allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                            {
                                Document_RefID = doc.Document_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }));
                        }
                        if (subBuildingPart.Images.Count() < allRevisionDocs.Count())
                        {
                            var submittedImages = subBuildingPart.Images.ToList();
                            foreach (var item in allRevisionDocs)
                            {
                                if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                {
                                    item.Remove(Connection, Transaction);
                                }
                            }
                        }
                        #endregion

                        foreach (var image in subBuildingPart.Images)
                        {
                            cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                            {
                                DOC_StructureHeaderRefID = str_roof.DocumentHeader_RefID,
                                DOC_DocumentRevisionID = image,
                            }, securityTicket);
                        }

                        foreach (var subPropAssessment in subBuildingPart.RoofPropertyAsessments)
                        {
                            var property = ORM_RES_STR_Roof_Property.Query.Search(Connection, Transaction, new ORM_RES_STR_Roof_Property.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                GlobalPropertyMatchingID = subPropAssessment.GlobalPropertyMatchingID
                            }).FirstOrDefault();
                            var propertyAssessment = ORM_RES_STR_Roof_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_Roof_PropertyAssessment.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                STR_Roof_RefID = str_roof.RES_STR_RoofID,
                                RoofProperty_RefID = property.RES_STR_Roof_PropertyID
                            }).FirstOrDefault();

                            if (propertyAssessment == null || propertyAssessment.RES_STR_Roof_PropertyAssessmentID == Guid.Empty)
                            {
                                ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                                structureHeader.Save(Connection, Transaction);

                                propertyAssessment = new ORM_RES_STR_Roof_PropertyAssessment()
                                {
                                    RoofProperty_RefID = property.RES_STR_Roof_PropertyID,
                                    STR_Roof_RefID = subBuildingPart.RES_STR_RoofID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    DocumentHeader_RefID = structureHeader.DOC_Structure_HeaderID,
                                    Rating_RefID = subPropAssessment.Rating_RefID
                                };
                            }
                            propertyAssessment.Comment = subPropAssessment.PropertyAssessment_Comment;
                            propertyAssessment.Save(Connection, Transaction);

                            #region delete_buildingPartProperty_images
                            allDocsStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                            {
                                Structure_Header_RefID = propertyAssessment.DocumentHeader_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            });
                            allDocuments2Structure = new List<ORM_DOC_Document_2_Structure>();
                            foreach (var docStructure in allDocsStructure)
                            {
                                allDocuments2Structure.AddRange(ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                                {
                                    Structure_RefID = docStructure.DOC_StructureID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).ToList());
                            }
                            allRevisionDocs = new List<ORM_DOC_DocumentRevision>();
                            foreach (var doc in allDocuments2Structure)
                            {
                                allRevisionDocs.AddRange(ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                                {
                                    Document_RefID = doc.Document_RefID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }));
                            }
                            if (subPropAssessment.Images.Count() < allRevisionDocs.Count())
                            {
                                var submittedImages = subPropAssessment.Images.ToList();
                                foreach (var item in allRevisionDocs)
                                {
                                    if (!submittedImages.Contains(item.DOC_DocumentRevisionID))
                                    {
                                        item.Remove(Connection, Transaction);
                                    }
                                }
                            }
                            #endregion

                            foreach (var image in subPropAssessment.Images)
                            {
                                cls_Save_BuildingImage_for_ImageID.Invoke(Connection, Transaction, new P_L5BD_SBIfII_1360()
                                {
                                    DOC_StructureHeaderRefID = propertyAssessment.DocumentHeader_RefID,
                                    DOC_DocumentRevisionID = image,
                                }, securityTicket);
                            }

                            foreach (var subReqAction in subPropAssessment.RoofReqActions)
                            {
                                var requiredAction = new ORM_RES_STR_Roof_RequiredAction();
                                var actionResult = requiredAction.Load(Connection, Transaction, subReqAction.RES_STR_Roof_RequiredActionID);

                                if (actionResult.Status != FR_Status.Success || requiredAction.Tenant_RefID == Guid.Empty)
                                {
                                    requiredAction = new ORM_RES_STR_Roof_RequiredAction()
                                    {
                                        RoofPropertyAssestment_RefID = propertyAssessment.RES_STR_Roof_PropertyAssessmentID,
                                        Tenant_RefID = securityTicket.TenantID
                                    };
                                }

                                requiredAction.Action_PricePerUnit_RefID = subReqAction.Action_PricePerUnit_RefID;
                                requiredAction.Action_Timeframe_RefID = subReqAction.Action_Timeframe_RefID;
                                requiredAction.Action_Unit_RefID = subReqAction.Action_Unit_RefID;
                                requiredAction.Action_UnitAmount = subReqAction.Action_UnitAmount;
                                requiredAction.Comment = subReqAction.RequiredAction_Comment;
                                requiredAction.EffectivePrice_RefID = subReqAction.EffectivePrice_RefID;
                                requiredAction.IfCustom_Description = subReqAction.IfCustom_Description;
                                requiredAction.IfCustom_Name = subReqAction.IfCustom_Name;
                                requiredAction.IsCustom = subReqAction.IsCustom;
                                requiredAction.SelectedActionVersion_RefID = subReqAction.SelectedActionVersion_RefID;
                                requiredAction.Save(Connection, Transaction);
                            }
                        }
                    }
                    #endregion


                }

                returnValue.Status = FR_Status.Success;
            }
            catch (Exception ex)
            {
                returnValue.Status = FR_Status.Error_Internal;
            }
            //Put your code here
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L6DD_SSfRGD_1503 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L6DD_SSfRGD_1503 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L6DD_SSfRGD_1503 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L6DD_SSfRGD_1503 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guid functionReturn = new FR_Guid();
            try
            {

                if (cleanupConnection == true)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction == true)
                {
                    Transaction = Connection.BeginTransaction();
                }

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction == true)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection == true)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction == true && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection == true && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method cls_Save_Submissions_for_RevisionGroupDetails", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L6DD_SSfRGD_1503 for attribute P_L6DD_SSfRGD_1503
    [DataContract]
    public class P_L6DD_SSfRGD_1503
    {
        [DataMember]
        public L6DD_SSfRGd_1503_Revision[] Revisions { get; set; }

        //Standard type parameters
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String Comment { get; set; }
        [DataMember]
        public Guid SubmittedByAccount { get; set; }
        [DataMember]
        public String SubmittedByAccount_FirstName { get; set; }
        [DataMember]
        public String SubmittedByAccount_LastName { get; set; }
        [DataMember]
        public String Currency { get; set; }
        [DataMember]
        public DateTime CreationTimestamp { get; set; }
        [DataMember]
        public Guid RevisionGroupID { get; set; }
        [DataMember]
        public L2PR_GPIfP_1135[] Prices { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_Revision for attribute Revisions
    [DataContract]
    public class L6DD_SSfRGd_1503_Revision
    {
        [DataMember]
        public L6DD_SSfRGd_1503_ApartmentSubmissionInfo[] ApartmentSubmissionInfo { get; set; }
        [DataMember]
        public L6DD_SSfRGd_1503_AtticSubmissionInfo[] AtticSubmissionInfo { get; set; }
        [DataMember]
        public L6DD_SSfRGd_1503_BasementSubmissionInfo[] BasementSubmissionInfo { get; set; }
        [DataMember]
        public L6DD_SSfRGd_1503_OutdoorFascilitySubmissionInfo[] OutdoorFascilitySubmissionInfo { get; set; }
        [DataMember]
        public L6DD_SSfRGd_1503_RoofSubmissionInfo[] RoofSubmissionInfo { get; set; }
        [DataMember]
        public L6DD_SSfRGd_1503_HVACRSubmissionInfo[] HVACRSubmissionInfo { get; set; }
        [DataMember]
        public L6DD_SSfRGd_1503_StaircaseSubmissionInfo[] StaircaseSubmissionInfo { get; set; }
        [DataMember]
        public L6DD_SSfRGd_1503_FacadeSubmissionInfo[] FacadeSubmissionInfo { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RevisionID { get; set; }
        [DataMember]
        public Guid QuestionnaireVersionID { get; set; }
        [DataMember]
        public String Comment { get; set; }
        [DataMember]
        public String Title { get; set; }
        [DataMember]
        public L5BL_GBIfBI_1159 Building { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_ApartmentSubmissionInfo for attribute ApartmentSubmissionInfo
    [DataContract]
    public class L6DD_SSfRGd_1503_ApartmentSubmissionInfo
    {
        [DataMember]
        public L6DD_SSfRGd_1503_ApartmentPropertyAsessment[] ApartmentPropertyAsessments { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_STR_ApartmentID { get; set; }
        [DataMember]
        public Guid RES_BLD_Apartment_RefID { get; set; }
        [DataMember]
        public Guid AverageRating_RefID { get; set; }
        [DataMember]
        public Guid Apartment_DocumentHeader_RefID { get; set; }
        [DataMember]
        public String Apartment_Comment { get; set; }
        [DataMember]
        public bool IsAppartment_ForRent { get; set; }
        [DataMember]
        public Guid ApartmentSize_Unit_RefID { get; set; }
        [DataMember]
        public double ApartmentSize_Value { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_ApartmentPropertyAsessment for attribute ApartmentPropertyAsessments
    [DataContract]
    public class L6DD_SSfRGd_1503_ApartmentPropertyAsessment
    {
        [DataMember]
        public L6DD_SSfRGd_1503_ApartmentReqAction[] ApartmentReqActions { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_STR_Apartment_PropertyAssessmentID { get; set; }
        [DataMember]
        public Guid Rating_RefID { get; set; }
        [DataMember]
        public Guid DocumentHeader_RefID { get; set; }
        [DataMember]
        public String GlobalPropertyMatchingID { get; set; }
        [DataMember]
        public Guid RES_STR_Apartment_PropertyID { get; set; }
        [DataMember]
        public String PropertyAssessment_Comment { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_ApartmentReqAction for attribute ApartmentReqActions
    [DataContract]
    public class L6DD_SSfRGd_1503_ApartmentReqAction
    {
        //Standard type parameters
        [DataMember]
        public Guid RES_STR_Apartment_RequiredActionID { get; set; }
        [DataMember]
        public Guid SelectedActionVersion_RefID { get; set; }
        [DataMember]
        public String RequiredAction_Comment { get; set; }
        [DataMember]
        public Guid Action_PricePerUnit_RefID { get; set; }
        [DataMember]
        public Guid Action_Unit_RefID { get; set; }
        [DataMember]
        public double Action_UnitAmount { get; set; }
        [DataMember]
        public bool IsCustom { get; set; }
        [DataMember]
        public String IfCustom_Name { get; set; }
        [DataMember]
        public String IfCustom_Description { get; set; }
        [DataMember]
        public Guid EffectivePrice_RefID { get; set; }
        [DataMember]
        public Guid Action_Timeframe_RefID { get; set; }
        [DataMember]
        public Dict Action_Name { get; set; }
        [DataMember]
        public double PriceValue_Amount { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_AtticSubmissionInfo for attribute AtticSubmissionInfo
    [DataContract]
    public class L6DD_SSfRGd_1503_AtticSubmissionInfo
    {
        [DataMember]
        public L6DD_SSfRGd_1503_AtticPropertyAsessment[] AtticPropertyAsessments { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_BLD_Attic_RefID { get; set; }
        [DataMember]
        public Guid RES_STR_AtticID { get; set; }
        [DataMember]
        public Guid Attic_DocumentHeader_RefID { get; set; }
        [DataMember]
        public Guid AverageRating_RefID { get; set; }
        [DataMember]
        public String Attic_Comment { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_AtticPropertyAsessment for attribute AtticPropertyAsessments
    [DataContract]
    public class L6DD_SSfRGd_1503_AtticPropertyAsessment
    {
        [DataMember]
        public L6DD_SSfRGd_1503_AtticReqAction[] AtticReqActions { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_STR_Attic_PropertyAssessmentID { get; set; }
        [DataMember]
        public Guid DocumentHeader_RefID { get; set; }
        [DataMember]
        public Guid Rating_RefID { get; set; }
        [DataMember]
        public String PropertyAssessment_Comment { get; set; }
        [DataMember]
        public String GlobalPropertyMatchingID { get; set; }
        [DataMember]
        public Guid RES_STR_Attic_PropertyID { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_AtticReqAction for attribute AtticReqActions
    [DataContract]
    public class L6DD_SSfRGd_1503_AtticReqAction
    {
        //Standard type parameters
        [DataMember]
        public Guid Action_Timeframe_RefID { get; set; }
        [DataMember]
        public String RequiredAction_Comment { get; set; }
        [DataMember]
        public String IfCustom_Description { get; set; }
        [DataMember]
        public String IfCustom_Name { get; set; }
        [DataMember]
        public bool IsCustom { get; set; }
        [DataMember]
        public double Action_UnitAmount { get; set; }
        [DataMember]
        public Guid Action_PricePerUnit_RefID { get; set; }
        [DataMember]
        public Guid Action_Unit_RefID { get; set; }
        [DataMember]
        public Guid SelectedActionVersion_RefID { get; set; }
        [DataMember]
        public Guid RES_STR_Attic_RequiredActionID { get; set; }
        [DataMember]
        public Guid EffectivePrice_RefID { get; set; }
        [DataMember]
        public Dict Action_Name { get; set; }
        [DataMember]
        public double PriceValue_Amount { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_BasementSubmissionInfo for attribute BasementSubmissionInfo
    [DataContract]
    public class L6DD_SSfRGd_1503_BasementSubmissionInfo
    {
        [DataMember]
        public L6DD_SSfRGd_1503_BasementPropertyAsessment[] BasementPropertyAsessments { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_STR_BasementID { get; set; }
        [DataMember]
        public Guid RES_BLD_Basement_RefID { get; set; }
        [DataMember]
        public Guid Basement_DocumentHeader_RefID { get; set; }
        [DataMember]
        public Guid AverageRating_RefID { get; set; }
        [DataMember]
        public String Basement_Comment { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_BasementPropertyAsessment for attribute BasementPropertyAsessments
    [DataContract]
    public class L6DD_SSfRGd_1503_BasementPropertyAsessment
    {
        [DataMember]
        public L6DD_SSfRGd_1503_BasementReqAction[] BasementReqActions { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_STR_Basement_PropertyAssessmentID { get; set; }
        [DataMember]
        public Guid RES_STR_Basement_PropertyID { get; set; }
        [DataMember]
        public String GlobalPropertyMatchingID { get; set; }
        [DataMember]
        public Guid DocumentHeader_RefID { get; set; }
        [DataMember]
        public String PropertyAssessment_Comment { get; set; }
        [DataMember]
        public Guid Rating_RefID { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_BasementReqAction for attribute BasementReqActions
    [DataContract]
    public class L6DD_SSfRGd_1503_BasementReqAction
    {
        //Standard type parameters
        [DataMember]
        public Guid RES_STR_Basement_RequiredActionID { get; set; }
        [DataMember]
        public Guid SelectedActionVersion_RefID { get; set; }
        [DataMember]
        public Guid EffectivePrice_RefID { get; set; }
        [DataMember]
        public Guid Action_PricePerUnit_RefID { get; set; }
        [DataMember]
        public Guid Action_Unit_RefID { get; set; }
        [DataMember]
        public double Action_UnitAmount { get; set; }
        [DataMember]
        public bool IsCustom { get; set; }
        [DataMember]
        public String IfCustom_Name { get; set; }
        [DataMember]
        public String IfCustom_Description { get; set; }
        [DataMember]
        public Guid Action_Timeframe_RefID { get; set; }
        [DataMember]
        public String RequiredAction_Comment { get; set; }
        [DataMember]
        public Dict Action_Name { get; set; }
        [DataMember]
        public double PriceValue_Amount { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_OutdoorFascilitySubmissionInfo for attribute OutdoorFascilitySubmissionInfo
    [DataContract]
    public class L6DD_SSfRGd_1503_OutdoorFascilitySubmissionInfo
    {
        [DataMember]
        public L6DD_SSfRGd_1503_OutdoorFacilityPropertyAsessment[] OutdoorFacilityAsessments { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_BLD_OutdoorFacility_RefID { get; set; }
        [DataMember]
        public Guid RES_STR_OutdoorFacilityID { get; set; }
        [DataMember]
        public Guid OutdoorF_DocumentHeader_RefID { get; set; }
        [DataMember]
        public String OutdoorF_Comment { get; set; }
        [DataMember]
        public Guid AverageRating_RefID { get; set; }
        [DataMember]
        public int NumberOfGaragePlaces { get; set; }
        [DataMember]
        public int NumberOfRentedGaragePlaces { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_OutdoorFacilityPropertyAsessment for attribute OutdoorFacilityAsessments
    [DataContract]
    public class L6DD_SSfRGd_1503_OutdoorFacilityPropertyAsessment
    {
        [DataMember]
        public L6DD_SSfRGd_1503_OutdoorFacilityReqAction[] OutdoorFacilityReqActions { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_STR_OutdoorFacility_PropertyAssessmentID { get; set; }
        [DataMember]
        public String GlobalPropertyMatchingID { get; set; }
        [DataMember]
        public Guid RES_STR_OutdoorFacility_PropertyID { get; set; }
        [DataMember]
        public Guid Rating_RefID { get; set; }
        [DataMember]
        public String PropertyAssessment_Comment { get; set; }
        [DataMember]
        public Guid DocumentHeader_RefID { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_OutdoorFacilityReqAction for attribute OutdoorFacilityReqActions
    [DataContract]
    public class L6DD_SSfRGd_1503_OutdoorFacilityReqAction
    {
        //Standard type parameters
        [DataMember]
        public Guid RES_STR_OutdoorFacility_RequiredActionID { get; set; }
        [DataMember]
        public Guid Action_Timeframe_RefID { get; set; }
        [DataMember]
        public String IfCustom_Description { get; set; }
        [DataMember]
        public String IfCustom_Name { get; set; }
        [DataMember]
        public bool IsCustom { get; set; }
        [DataMember]
        public double Action_UnitAmount { get; set; }
        [DataMember]
        public Guid Action_Unit_RefID { get; set; }
        [DataMember]
        public Guid Action_PricePerUnit_RefID { get; set; }
        [DataMember]
        public Guid SelectedActionVersion_RefID { get; set; }
        [DataMember]
        public String RequiredAction_Comment { get; set; }
        [DataMember]
        public Guid EffectivePrice_RefID { get; set; }
        [DataMember]
        public Dict Action_Name { get; set; }
        [DataMember]
        public double PriceValue_Amount { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_RoofSubmissionInfo for attribute RoofSubmissionInfo
    [DataContract]
    public class L6DD_SSfRGd_1503_RoofSubmissionInfo
    {
        [DataMember]
        public L6DD_SSfRGd_1503_RoofPropertyAsessment[] RoofPropertyAsessments { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_STR_RoofID { get; set; }
        [DataMember]
        public Guid RES_BLD_Roof_RefID { get; set; }
        [DataMember]
        public Guid Roof_DocumentHeader_RefID { get; set; }
        [DataMember]
        public String Roof_Comment { get; set; }
        [DataMember]
        public Guid AverageRating_RefID { get; set; }
        [DataMember]
        public Guid STR_Roof_RefID { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_RoofPropertyAsessment for attribute RoofPropertyAsessments
    [DataContract]
    public class L6DD_SSfRGd_1503_RoofPropertyAsessment
    {
        [DataMember]
        public L6DD_SSfRGd_1503_RoofReqAction[] RoofReqActions { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_STR_Roof_PropertyAssessmentID { get; set; }
        [DataMember]
        public String PropertyAssessment_Comment { get; set; }
        [DataMember]
        public Guid Rating_RefID { get; set; }
        [DataMember]
        public Guid RES_STR_Roof_PropertyID { get; set; }
        [DataMember]
        public String GlobalPropertyMatchingID { get; set; }
        [DataMember]
        public Guid DocumentHeader_RefID { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_RoofReqAction for attribute RoofReqActions
    [DataContract]
    public class L6DD_SSfRGd_1503_RoofReqAction
    {
        //Standard type parameters
        [DataMember]
        public String RequiredAction_Comment { get; set; }
        [DataMember]
        public Guid SelectedActionVersion_RefID { get; set; }
        [DataMember]
        public Guid RES_STR_Roof_RequiredActionID { get; set; }
        [DataMember]
        public Guid Action_PricePerUnit_RefID { get; set; }
        [DataMember]
        public Guid Action_Unit_RefID { get; set; }
        [DataMember]
        public double Action_UnitAmount { get; set; }
        [DataMember]
        public Guid Action_Timeframe_RefID { get; set; }
        [DataMember]
        public bool IsCustom { get; set; }
        [DataMember]
        public String IfCustom_Name { get; set; }
        [DataMember]
        public String IfCustom_Description { get; set; }
        [DataMember]
        public Guid EffectivePrice_RefID { get; set; }
        [DataMember]
        public Dict Action_Name { get; set; }
        [DataMember]
        public double PriceValue_Amount { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_HVACRSubmissionInfo for attribute HVACRSubmissionInfo
    [DataContract]
    public class L6DD_SSfRGd_1503_HVACRSubmissionInfo
    {
        [DataMember]
        public L6DD_SSfRGd_1503_HVACRPropertyAsessment[] HVACRPropertyAsessments { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_STR_HVACRID { get; set; }
        [DataMember]
        public Guid RES_BLD_HVACR_RefID { get; set; }
        [DataMember]
        public Guid HVACR_DocumentHeader_RefID { get; set; }
        [DataMember]
        public Guid AverageRating_RefID { get; set; }
        [DataMember]
        public String HVACR_Comment { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_HVACRPropertyAsessment for attribute HVACRPropertyAsessments
    [DataContract]
    public class L6DD_SSfRGd_1503_HVACRPropertyAsessment
    {
        [DataMember]
        public L6DD_SSfRGd_1503_HVACRReqAction[] HVACRReqActions { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_STR_HVACR_PropertyAssessmentID { get; set; }
        [DataMember]
        public String GlobalPropertyMatchingID { get; set; }
        [DataMember]
        public Guid Rating_RefID { get; set; }
        [DataMember]
        public String PropertyAssessment_Comment { get; set; }
        [DataMember]
        public Guid DocumentHeader_RefID { get; set; }
        [DataMember]
        public Guid RES_STR_HVACR_PropertyID { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_HVACRReqAction for attribute HVACRReqActions
    [DataContract]
    public class L6DD_SSfRGd_1503_HVACRReqAction
    {
        //Standard type parameters
        [DataMember]
        public Guid Action_Timeframe_RefID { get; set; }
        [DataMember]
        public String IfCustom_Description { get; set; }
        [DataMember]
        public String IfCustom_Name { get; set; }
        [DataMember]
        public bool IsCustom { get; set; }
        [DataMember]
        public Guid Action_Unit_RefID { get; set; }
        [DataMember]
        public Guid Action_PricePerUnit_RefID { get; set; }
        [DataMember]
        public double Action_UnitAmount { get; set; }
        [DataMember]
        public Guid SelectedActionVersion_RefID { get; set; }
        [DataMember]
        public Guid RES_STR_HVACR_RequiredActionID { get; set; }
        [DataMember]
        public String RequiredAction_Comment { get; set; }
        [DataMember]
        public Guid EffectivePrice_RefID { get; set; }
        [DataMember]
        public Dict Action_Name { get; set; }
        [DataMember]
        public double PriceValue_Amount { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_StaircaseSubmissionInfo for attribute StaircaseSubmissionInfo
    [DataContract]
    public class L6DD_SSfRGd_1503_StaircaseSubmissionInfo
    {
        [DataMember]
        public L6DD_SSfRGd_1503_StaircasePropertyAsessment[] StaircasePropertyAsessments { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid Staircase_DocumentHeader_RefID { get; set; }
        [DataMember]
        public String Staircase_Comment { get; set; }
        [DataMember]
        public Guid AverageRating_RefID { get; set; }
        [DataMember]
        public Guid RES_STR_StaircaseID { get; set; }
        [DataMember]
        public Guid RES_BLD_Staircase_RefID { get; set; }
        [DataMember]
        public Guid StaircaseSize_Unit_RefID { get; set; }
        [DataMember]
        public Double StaircaseSize_Value { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_StaircasePropertyAsessment for attribute StaircasePropertyAsessments
    [DataContract]
    public class L6DD_SSfRGd_1503_StaircasePropertyAsessment
    {
        [DataMember]
        public L6DD_SSfRGd_1503_StaircaseReqAction[] StaircaseReqActions { get; set; }

        //Standard type parameters
        [DataMember]
        public String GlobalPropertyMatchingID { get; set; }
        [DataMember]
        public Guid RES_STR_Staircase_PropertyID { get; set; }
        [DataMember]
        public Guid RES_STR_Staircase_PropertyAssessmentID { get; set; }
        [DataMember]
        public Guid Rating_RefID { get; set; }
        [DataMember]
        public Guid DocumentHeader_RefID { get; set; }
        [DataMember]
        public String PropertyAssessment_Comment { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_StaircaseReqAction for attribute StaircaseReqActions
    [DataContract]
    public class L6DD_SSfRGd_1503_StaircaseReqAction
    {
        //Standard type parameters
        [DataMember]
        public Guid RES_STR_Staircase_RequiredActionID { get; set; }
        [DataMember]
        public Guid SelectedActionVersion_RefID { get; set; }
        [DataMember]
        public String RequiredAction_Comment { get; set; }
        [DataMember]
        public Guid Action_PricePerUnit_RefID { get; set; }
        [DataMember]
        public Guid Action_Unit_RefID { get; set; }
        [DataMember]
        public double Action_UnitAmount { get; set; }
        [DataMember]
        public bool IsCustom { get; set; }
        [DataMember]
        public String IfCustom_Name { get; set; }
        [DataMember]
        public String IfCustom_Description { get; set; }
        [DataMember]
        public Guid Action_Timeframe_RefID { get; set; }
        [DataMember]
        public Guid EffectivePrice_RefID { get; set; }
        [DataMember]
        public Dict Action_Name { get; set; }
        [DataMember]
        public double PriceValue_Amount { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_FacadeSubmissionInfo for attribute FacadeSubmissionInfo
    [DataContract]
    public class L6DD_SSfRGd_1503_FacadeSubmissionInfo
    {
        [DataMember]
        public L6DD_SSfRGd_1503_FacadePropertyAsessment[] FacadePropertyAsessments { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_STR_FacadeID { get; set; }
        [DataMember]
        public Guid Facade_DocumentHeader_RefID { get; set; }
        [DataMember]
        public String Facade_Comment { get; set; }
        [DataMember]
        public Guid AverageRating_RefID { get; set; }
        [DataMember]
        public Guid RES_BLD_Facade_RefID { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_FacadePropertyAsessment for attribute FacadePropertyAsessments
    [DataContract]
    public class L6DD_SSfRGd_1503_FacadePropertyAsessment
    {
        [DataMember]
        public L6DD_SSfRGd_1503_FacadeReqAction[] FacadeReqActions { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid RES_STR_Facade_PropertyAssessmentID { get; set; }
        [DataMember]
        public Guid DocumentHeader_RefID { get; set; }
        [DataMember]
        public Guid Rating_RefID { get; set; }
        [DataMember]
        public String GlobalPropertyMatchingID { get; set; }
        [DataMember]
        public Guid RES_STR_Facade_PropertyID { get; set; }
        [DataMember]
        public String PropertyAssessment_Comment { get; set; }
        [DataMember]
        public Guid[] Images { get; set; }

    }
    #endregion
    #region SClass L6DD_SSfRGd_1503_FacadeReqAction for attribute FacadeReqActions
    [DataContract]
    public class L6DD_SSfRGd_1503_FacadeReqAction
    {
        //Standard type parameters
        [DataMember]
        public Guid SelectedActionVersion_RefID { get; set; }
        [DataMember]
        public Guid Action_PricePerUnit_RefID { get; set; }
        [DataMember]
        public double Action_UnitAmount { get; set; }
        [DataMember]
        public Guid Action_Unit_RefID { get; set; }
        [DataMember]
        public Guid RES_STR_Facade_RequiredActionID { get; set; }
        [DataMember]
        public String IfCustom_Description { get; set; }
        [DataMember]
        public String IfCustom_Name { get; set; }
        [DataMember]
        public bool IsCustom { get; set; }
        [DataMember]
        public Guid Action_Timeframe_RefID { get; set; }
        [DataMember]
        public String RequiredActions_Comment { get; set; }
        [DataMember]
        public Guid EffectivePrice_RefID { get; set; }
        [DataMember]
        public Dict Action_Name { get; set; }
        [DataMember]
        public double PriceValue_Amount { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Submissions_for_RevisionGroupDetails(,P_L6DD_SSfRGD_1503 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Submissions_for_RevisionGroupDetails.Invoke(connectionString,P_L6DD_SSfRGD_1503 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
/* Support for Parameter Invocation (Copy&Paste)
var parameter = new CL5_KPRS_DueDiligences.Complex.Retrieval.P_L6DD_SSfRGD_1503();
parameter.Revisions = ...;

parameter.Name = ...;
parameter.Comment = ...;
parameter.SubmittedByAccount = ...;
parameter.SubmittedByAccount_FirstName = ...;
parameter.SubmittedByAccount_LastName = ...;
parameter.Currency = ...;
parameter.CreationTimestamp = ...;
parameter.RevisionGroupID = ...;
parameter.Prices = ...;

*/