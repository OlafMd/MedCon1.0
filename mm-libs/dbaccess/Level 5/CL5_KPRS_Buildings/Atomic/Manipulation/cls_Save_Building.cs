/* 
 * Generated on 7/16/2013 1:58:21 PM
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
using CL1_DOC;
using CL1_RES_DUD;

namespace CL5_KPRS_Buildings.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Building.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Building
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_SB_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            bool editedVersion = false;

            ORM_RES_BLD_Building building = new ORM_RES_BLD_Building();
            if (Parameter.RES_BLD_BuildingID != Guid.Empty)
            {
                var result = building.Load(Connection, Transaction, Parameter.RES_BLD_BuildingID);
                if (result.Status != FR_Status.Success || building.RES_BLD_BuildingID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }

                List<ORM_RES_DUD_Revision> revisions = new List<ORM_RES_DUD_Revision>();
                revisions = ORM_RES_DUD_Revision.Query.Search(Connection, Transaction, new ORM_RES_DUD_Revision.Query()
                {
                    RES_BLD_Building_RefID = Parameter.RES_BLD_BuildingID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                if (revisions.Count > 0)
                {
                    //building is connected to revision. create new with same properties if IsBuildingForEdit returns 0.
                    if (IsBuildingForEdit(Connection, Transaction, Parameter, building, securityTicket) == 0)
                    {
                        building = new ORM_RES_BLD_Building();
                        editedVersion = true;
                    }
                    else
                    {
                        var noEdit = new FR_Guid();
                        noEdit.ErrorMessage = "No need to be edited.";
                        noEdit.Status = FR_Status.Success;
                        return noEdit;
                    }
                }

            }

            if (building.BuildingRevisionHeader_RefID == Guid.Empty)
            {
                ORM_RES_BLD_Building_RevisionHeader revisionHeader = new ORM_RES_BLD_Building_RevisionHeader();
                revisionHeader.RES_BLD_Building_RevisionHeaderID = Guid.NewGuid();
                revisionHeader.CurrentBuildingVersion_RefID = building.RES_BLD_BuildingID;
                revisionHeader.RealestateProperty_RefID = Parameter.RealestatePropertyID;
                revisionHeader.Tenant_RefID = securityTicket.TenantID;
                revisionHeader.Save(Connection, Transaction);
                building.BuildingRevisionHeader_RefID = revisionHeader.RES_BLD_Building_RevisionHeaderID;
                
                ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                structureHeader.Save(Connection, Transaction);
                building.Building_DocumentationStructure_RefID = structureHeader.DOC_Structure_HeaderID;
            }

            building.Building_BalconyPortionPercent = Parameter.Building_BalconyPortionPercent;

            //if building is connected with revision, copied building has to have different name.
            building.Building_Name = editedVersion ? Parameter.Building_Name + " edit" : Parameter.Building_Name;

            building.IsContaminationSuspected = Parameter.IsContaminationSuspected;
            building.Building_NumberOfFloors = Parameter.Building_NumberOfFloors;
            building.Building_ElevatorCoveragePercent = Parameter.Building_ElevatorCoveragePercent;
            building.Building_NumberOfAppartments = Parameter.Building_NumberOfAppartments;
            building.Building_NumberOfOccupiedAppartments = Parameter.Building_NumberOfOccupiedAppartments;
            building.Building_NumberOfOffices = Parameter.Building_NumberOfOffices;
            building.Building_NumberOfRetailUnits = Parameter.Building_NumberOfRetailUnits;
            building.Building_NumberOfProductionUnits = Parameter.Building_NumberOfProductionUnits;
            building.Building_NumberOfOtherUnits = Parameter.Building_NumberOfOtherUnits;
            building.Tenant_RefID = securityTicket.TenantID;
            building.Save(Connection, Transaction);

            ORM_RES_BLD_Building_2_GarbageContainerType.Query build2GarbQuery = new ORM_RES_BLD_Building_2_GarbageContainerType.Query();
            build2GarbQuery.RES_BLD_Building_RefID = building.RES_BLD_BuildingID;
            build2GarbQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_RES_BLD_Building_2_GarbageContainerType> buildingsToGarbage = ORM_RES_BLD_Building_2_GarbageContainerType.Query.Search(Connection, Transaction, build2GarbQuery);

            if (buildingsToGarbage.Count != 0)
            {
                ORM_RES_BLD_Building_2_GarbageContainerType garbage = buildingsToGarbage[0];
                garbage.RES_BLD_GarbageContainerType_RefID = Parameter.RES_BLD_GarbageContainerTypeID;
                garbage.Save(Connection, Transaction);
            }
            else
            {
                ORM_RES_BLD_Building_2_GarbageContainerType garbage = new ORM_RES_BLD_Building_2_GarbageContainerType();
                garbage.RES_BLD_GarbageContainerType_RefID = Parameter.RES_BLD_GarbageContainerTypeID;
                garbage.RES_BLD_Building_RefID = building.RES_BLD_BuildingID;
                garbage.Tenant_RefID = securityTicket.TenantID;
                garbage.Save(Connection, Transaction);
            }

            ORM_RES_BLD_Building_2_BuildingType.Query buildTypeQuery = new ORM_RES_BLD_Building_2_BuildingType.Query();
            buildTypeQuery.RES_BLD_Building_RefID = building.RES_BLD_BuildingID;
            buildTypeQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_RES_BLD_Building_2_BuildingType> buildingsType = ORM_RES_BLD_Building_2_BuildingType.Query.Search(Connection, Transaction, buildTypeQuery);

            if (buildingsType.Count != 0)
            {
                ORM_RES_BLD_Building_2_BuildingType buildingType = buildingsType[0];
                buildingType.RES_BLD_Building_Type_RefID = Parameter.RES_BLD_Building_TypeID;
                buildingType.RES_BLD_Building_RefID = building.RES_BLD_BuildingID;
                buildingType.Save(Connection, Transaction);
            }
            else
            {
                ORM_RES_BLD_Building_2_BuildingType buildingType = new ORM_RES_BLD_Building_2_BuildingType();
                buildingType.RES_BLD_Building_RefID = building.RES_BLD_BuildingID;
                buildingType.RES_BLD_Building_Type_RefID = Parameter.RES_BLD_Building_TypeID;
                buildingType.Tenant_RefID = securityTicket.TenantID;
                buildingType.Save(Connection, Transaction);
            }

            if (Parameter.RES_BLD_BuildingID == Guid.Empty || editedVersion)
            {
                for (int i = 0; i < Parameter.AppartmentCount; i++)
                {
                    ORM_RES_BLD_Apartment newAppartment = new ORM_RES_BLD_Apartment();
                    newAppartment.Building_RefID = building.RES_BLD_BuildingID;
                    newAppartment.Tenant_RefID = securityTicket.TenantID;
                    newAppartment.Save(Connection, Transaction);
                }

                for (int i = 0; i < Parameter.staircasesCount; i++)
                {
                    ORM_RES_BLD_Staircase newStaircase = new ORM_RES_BLD_Staircase();
                    newStaircase.Building_RefID = building.RES_BLD_BuildingID;
                    newStaircase.Tenant_RefID = securityTicket.TenantID;
                    newStaircase.Save(Connection, Transaction);
                }

                for (int i = 0; i < Parameter.outdoorfacilitiesCount; i++)
                {
                    ORM_RES_BLD_OutdoorFacility newOutdoorfacility = new ORM_RES_BLD_OutdoorFacility();
                    newOutdoorfacility.Building_RefID = building.RES_BLD_BuildingID;
                    newOutdoorfacility.Tenant_RefID = securityTicket.TenantID;
                    newOutdoorfacility.Save(Connection, Transaction);
                }

                for (int i = 0; i < Parameter.facadesCount; i++)
                {
                    ORM_RES_BLD_Facade newFacade = new ORM_RES_BLD_Facade();
                    newFacade.Building_RefID = building.RES_BLD_BuildingID;
                    newFacade.Tenant_RefID = securityTicket.TenantID;
                    newFacade.Save(Connection, Transaction);
                }

                for (int i = 0; i < Parameter.roofCount; i++)
                {
                    ORM_RES_BLD_Roof newRoof = new ORM_RES_BLD_Roof();
                    newRoof.Building_RefID = building.RES_BLD_BuildingID;
                    newRoof.Tenant_RefID = securityTicket.TenantID;
                    newRoof.Save(Connection, Transaction);
                }

                for (int i = 0; i < Parameter.atticsCount; i++)
                {
                    ORM_RES_BLD_Attic newAttic = new ORM_RES_BLD_Attic();
                    newAttic.Building_RefID = building.RES_BLD_BuildingID;
                    newAttic.Tenant_RefID = securityTicket.TenantID;
                    newAttic.Save(Connection, Transaction);
                }

                for (int i = 0; i < Parameter.basementsCount; i++)
                {
                    ORM_RES_BLD_Basement newBasement = new ORM_RES_BLD_Basement();
                    newBasement.Building_RefID = building.RES_BLD_BuildingID;
                    newBasement.Tenant_RefID = securityTicket.TenantID;
                    newBasement.Save(Connection, Transaction);
                }

                for (int i = 0; i < Parameter.hvarcsCount; i++)
                {
                    ORM_RES_BLD_HVACR newHvacr = new ORM_RES_BLD_HVACR();
                    newHvacr.Building_RefID = building.RES_BLD_BuildingID;
                    newHvacr.Tenant_RefID = securityTicket.TenantID;
                    newHvacr.Save(Connection, Transaction);
                }
            }
            else
            {
                
                ORM_RES_BLD_Apartment.Query appartmentQuery = new ORM_RES_BLD_Apartment.Query();
                appartmentQuery.Building_RefID = Parameter.RES_BLD_BuildingID;
                appartmentQuery.Tenant_RefID = securityTicket.TenantID;
                appartmentQuery.IsDeleted = false;
                List<ORM_RES_BLD_Apartment> appartmentList = ORM_RES_BLD_Apartment.Query.Search(Connection, Transaction, appartmentQuery);

                if (appartmentList.Count > Parameter.AppartmentCount)
                {
                    int counts = appartmentList.Count - Parameter.AppartmentCount;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_Apartment deleteAppartment = appartmentList[i];
                        deleteAppartment.Remove(Connection, Transaction);
                    }
                }
                else if (appartmentList.Count < Parameter.AppartmentCount)
                {
                    int counts = Parameter.AppartmentCount - appartmentList.Count;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_Apartment newAppartment = new ORM_RES_BLD_Apartment();
                        newAppartment.Building_RefID = Parameter.RES_BLD_BuildingID;
                        newAppartment.Tenant_RefID = securityTicket.TenantID;
                        newAppartment.Save(Connection, Transaction);
                    }
                }

                ORM_RES_BLD_OutdoorFacility.Query outdoorfacilitiesQuery = new ORM_RES_BLD_OutdoorFacility.Query();
                outdoorfacilitiesQuery.Building_RefID = Parameter.RES_BLD_BuildingID;
                outdoorfacilitiesQuery.Tenant_RefID = securityTicket.TenantID;
                outdoorfacilitiesQuery.IsDeleted = false;
                List<ORM_RES_BLD_OutdoorFacility> outdoorfacilitiesList = ORM_RES_BLD_OutdoorFacility.Query.Search(Connection, Transaction, outdoorfacilitiesQuery);

                if (outdoorfacilitiesList.Count > Parameter.outdoorfacilitiesCount)
                {
                    int counts = outdoorfacilitiesList.Count - Parameter.outdoorfacilitiesCount;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_OutdoorFacility deleteOutdoor = outdoorfacilitiesList[i];
                        deleteOutdoor.Remove(Connection, Transaction);
                    }
                }
                else if (outdoorfacilitiesList.Count < Parameter.outdoorfacilitiesCount)
                {
                    int counts = Parameter.outdoorfacilitiesCount - outdoorfacilitiesList.Count;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_OutdoorFacility newOutdoorFacility = new ORM_RES_BLD_OutdoorFacility();
                        newOutdoorFacility.Building_RefID = building.RES_BLD_BuildingID;
                        newOutdoorFacility.Tenant_RefID = securityTicket.TenantID;
                        newOutdoorFacility.Save(Connection, Transaction);
                    }
                }

                
                ORM_RES_BLD_Staircase.Query staircaseQuery = new ORM_RES_BLD_Staircase.Query();
                staircaseQuery.Building_RefID = Parameter.RES_BLD_BuildingID;
                staircaseQuery.Tenant_RefID = securityTicket.TenantID;
                staircaseQuery.IsDeleted = false;
                List<ORM_RES_BLD_Staircase> staircaseList = ORM_RES_BLD_Staircase.Query.Search(Connection, Transaction, staircaseQuery);

                if (staircaseList.Count > Parameter.staircasesCount)
                {
                    int counts = staircaseList.Count - Parameter.staircasesCount;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_Staircase deleteStaircase = staircaseList[i];
                        deleteStaircase.Remove(Connection, Transaction);
                    }
                }
                else if (staircaseList.Count < Parameter.staircasesCount)
                {
                    int counts = Parameter.staircasesCount - staircaseList.Count;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_Staircase newStaircase = new ORM_RES_BLD_Staircase();
                        newStaircase.Building_RefID = building.RES_BLD_BuildingID;
                        newStaircase.Tenant_RefID = securityTicket.TenantID;
                        newStaircase.Save(Connection, Transaction);
                    }
                }
                
                ORM_RES_BLD_Facade.Query facadesQuery = new ORM_RES_BLD_Facade.Query();
                facadesQuery.Building_RefID = Parameter.RES_BLD_BuildingID;
                facadesQuery.Tenant_RefID = securityTicket.TenantID;
                facadesQuery.IsDeleted = false;
                List<ORM_RES_BLD_Facade> facadesList = ORM_RES_BLD_Facade.Query.Search(Connection, Transaction, facadesQuery);

                if (facadesList.Count > Parameter.facadesCount)
                {
                    int counts = facadesList.Count - Parameter.facadesCount;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_Facade deleteFacade = facadesList[i];
                        deleteFacade.Remove(Connection, Transaction);
                    }
                }
                else if (facadesList.Count < Parameter.facadesCount)
                {
                    int counts = Parameter.facadesCount - facadesList.Count;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_Facade newFacade = new ORM_RES_BLD_Facade();
                        newFacade.Building_RefID = building.RES_BLD_BuildingID;
                        newFacade.Tenant_RefID = securityTicket.TenantID;
                        newFacade.Save(Connection, Transaction);
                    }
                }
                
                ORM_RES_BLD_Roof.Query roofQuery = new ORM_RES_BLD_Roof.Query();
                roofQuery.Building_RefID = Parameter.RES_BLD_BuildingID;
                roofQuery.Tenant_RefID = securityTicket.TenantID;
                roofQuery.IsDeleted = false;
                List<ORM_RES_BLD_Roof> roofList = ORM_RES_BLD_Roof.Query.Search(Connection, Transaction, roofQuery);

                if (roofList.Count > Parameter.roofCount)
                {
                    int counts = roofList.Count - Parameter.roofCount;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_Roof deleteRoof = roofList[i];
                        deleteRoof.Remove(Connection, Transaction);
                    }
                }
                else if (roofList.Count < Parameter.roofCount)
                {
                    int counts = Parameter.roofCount - roofList.Count;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_Roof newRoof = new ORM_RES_BLD_Roof();
                        newRoof.Building_RefID = building.RES_BLD_BuildingID;
                        newRoof.Tenant_RefID = securityTicket.TenantID;
                        newRoof.Save(Connection, Transaction);
                    }
                }
                
                ORM_RES_BLD_Attic.Query atticsQuery = new ORM_RES_BLD_Attic.Query();
                atticsQuery.Building_RefID = Parameter.RES_BLD_BuildingID;
                atticsQuery.Tenant_RefID = securityTicket.TenantID;
                atticsQuery.IsDeleted = false;
                List<ORM_RES_BLD_Attic> atticsList = ORM_RES_BLD_Attic.Query.Search(Connection, Transaction, atticsQuery);

                if (atticsList.Count > Parameter.atticsCount)
                {
                    int counts = atticsList.Count - Parameter.atticsCount;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_Attic deleteAttic = atticsList[i];
                        deleteAttic.Remove(Connection, Transaction);
                    }
                }
                else if (atticsList.Count < Parameter.atticsCount)
                {
                    int counts = Parameter.atticsCount - atticsList.Count;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_Attic newAttic = new ORM_RES_BLD_Attic();
                        newAttic.Building_RefID = building.RES_BLD_BuildingID;
                        newAttic.Tenant_RefID = securityTicket.TenantID;
                        newAttic.Save(Connection, Transaction);
                    }
                }
                
                ORM_RES_BLD_Basement.Query basementQuery = new ORM_RES_BLD_Basement.Query();
                basementQuery.Building_RefID = Parameter.RES_BLD_BuildingID;
                basementQuery.Tenant_RefID = securityTicket.TenantID;
                basementQuery.IsDeleted = false;
                List<ORM_RES_BLD_Basement> basementList = ORM_RES_BLD_Basement.Query.Search(Connection, Transaction, basementQuery);

                if (basementList.Count > Parameter.basementsCount)
                {
                    int counts = basementList.Count - Parameter.basementsCount;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_Basement deleteBasement = basementList[i];
                        deleteBasement.Remove(Connection, Transaction);
                    }
                }
                else if (basementList.Count < Parameter.basementsCount)
                {
                    int counts = Parameter.basementsCount - basementList.Count;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_Basement newBasement = new ORM_RES_BLD_Basement();
                        newBasement.Building_RefID = building.RES_BLD_BuildingID;
                        newBasement.Tenant_RefID = securityTicket.TenantID;
                        newBasement.Save(Connection, Transaction);
                    }
                }

                ORM_RES_BLD_HVACR.Query hvacrQuery = new ORM_RES_BLD_HVACR.Query();
                hvacrQuery.Building_RefID = Parameter.RES_BLD_BuildingID;
                hvacrQuery.Tenant_RefID = securityTicket.TenantID;
                hvacrQuery.IsDeleted = false;
                List<ORM_RES_BLD_HVACR> hvacrList = ORM_RES_BLD_HVACR.Query.Search(Connection, Transaction, hvacrQuery);

                if (hvacrList.Count > Parameter.hvarcsCount)
                {
                    int counts = hvacrList.Count - Parameter.hvarcsCount;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_HVACR deleteHvacr = hvacrList[i];
                        deleteHvacr.Remove(Connection, Transaction);
                    }
                }
                else if (hvacrList.Count < Parameter.hvarcsCount)
                {
                    int counts = Parameter.hvarcsCount - hvacrList.Count;
                    for (int i = 0; i < counts; i++)
                    {
                        ORM_RES_BLD_HVACR newHvacr = new ORM_RES_BLD_HVACR();
                        newHvacr.Building_RefID = building.RES_BLD_BuildingID;
                        newHvacr.Tenant_RefID = securityTicket.TenantID;
                        newHvacr.Save(Connection, Transaction);
                    }
                }

            }

            returnValue.Result = building.RES_BLD_BuildingID;

            //Put your code here
            return returnValue;
			#endregion UserCode
		}
		#endregion

        private static int IsBuildingForEdit(DbConnection Connection,DbTransaction Transaction,P_L5BD_SB_1359 Parameter,ORM_RES_BLD_Building building, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            int status = 1;

            if (building.Building_Name != Parameter.Building_Name)
                return 0;

            if (building.IsContaminationSuspected != Parameter.IsContaminationSuspected)
                return 0;

            if (building.Building_NumberOfAppartments != Parameter.Building_NumberOfAppartments)
                return 0;

            if (building.Building_NumberOfOccupiedAppartments != Parameter.Building_NumberOfOccupiedAppartments)
                return 0;

            if (building.Building_NumberOfFloors != Parameter.Building_NumberOfFloors)
                return 0;

            if (building.Building_NumberOfOffices != Parameter.Building_NumberOfOffices)
                return 0;

            if (building.Building_NumberOfRetailUnits != Parameter.Building_NumberOfRetailUnits)
                return 0;

            if (building.Building_NumberOfProductionUnits != Parameter.Building_NumberOfProductionUnits)
                return 0;

            if (building.Building_NumberOfOtherUnits != Parameter.Building_NumberOfOtherUnits)
                return 0;

            if (building.Building_BalconyPortionPercent != Parameter.Building_BalconyPortionPercent)
                return 0;

            if (building.Building_ElevatorCoveragePercent != Parameter.Building_ElevatorCoveragePercent)
                return 0;

            var buildingTypeRefID = ORM_RES_BLD_Building_2_BuildingType.Query.Search(Connection, Transaction,
                        new ORM_RES_BLD_Building_2_BuildingType.Query()
                        {
                            RES_BLD_Building_RefID = building.RES_BLD_BuildingID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Select(b => b.RES_BLD_Building_Type_RefID).FirstOrDefault();
            var garbageContainerTypeRefID = ORM_RES_BLD_Building_2_GarbageContainerType.Query.Search(Connection, Transaction,
                        new ORM_RES_BLD_Building_2_GarbageContainerType.Query()
                        {
                            RES_BLD_Building_RefID = building.RES_BLD_BuildingID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Select(b => b.RES_BLD_GarbageContainerType_RefID).FirstOrDefault();

            if (buildingTypeRefID != Parameter.RES_BLD_Building_TypeID)
                return 0;

            if (garbageContainerTypeRefID != Parameter.RES_BLD_GarbageContainerTypeID)
                return 0;

            var numberOfAppartments = ORM_RES_BLD_Apartment.Query.Search(Connection, Transaction, new ORM_RES_BLD_Apartment.Query()
            {
                Building_RefID = building.RES_BLD_BuildingID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Count();
            if (numberOfAppartments != Parameter.AppartmentCount)
                return 0;

            var numberOfOutdoorFacilities = ORM_RES_BLD_OutdoorFacility.Query.Search(Connection, Transaction, new ORM_RES_BLD_OutdoorFacility.Query()
            {
                Building_RefID = building.RES_BLD_BuildingID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Count();
            if (numberOfOutdoorFacilities != Parameter.outdoorfacilitiesCount)
                return 0;

            var numberOfFacades = ORM_RES_BLD_Facade.Query.Search(Connection, Transaction, new ORM_RES_BLD_Facade.Query()
            {
                Building_RefID = building.RES_BLD_BuildingID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Count();
            if (numberOfFacades != Parameter.facadesCount)
                return 0;

            var numberOfRoofs = ORM_RES_BLD_Roof.Query.Search(Connection, Transaction, new ORM_RES_BLD_Roof.Query()
            {
                Building_RefID = building.RES_BLD_BuildingID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Count();
            if (numberOfRoofs != Parameter.roofCount)
                return 0;

            var numberOfAttics = ORM_RES_BLD_Attic.Query.Search(Connection, Transaction, new ORM_RES_BLD_Attic.Query()
            {
                Building_RefID = building.RES_BLD_BuildingID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Count();
            if (numberOfAttics != Parameter.atticsCount)
                return 0;

            var numberOfStaircases = ORM_RES_BLD_Staircase.Query.Search(Connection, Transaction, new ORM_RES_BLD_Staircase.Query()
            {
                Building_RefID = building.RES_BLD_BuildingID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Count();
            if (numberOfStaircases != Parameter.staircasesCount)
                return 0;

            var numberOfBasements = ORM_RES_BLD_Basement.Query.Search(Connection, Transaction, new ORM_RES_BLD_Basement.Query()
            {
                Building_RefID = building.RES_BLD_BuildingID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Count();
            if (numberOfBasements != Parameter.basementsCount)
                return 0;

            var numberOfHVACRS = ORM_RES_BLD_HVACR.Query.Search(Connection, Transaction, new ORM_RES_BLD_HVACR.Query()
            {
                Building_RefID = building.RES_BLD_BuildingID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Count();
            if (numberOfHVACRS != Parameter.hvarcsCount)
                return 0;

            return status;
        }

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5BD_SB_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5BD_SB_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_SB_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_SB_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);


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
					if (cleanupTransaction == true && Transaction!=null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5BD_SB_1359 for attribute P_L5BD_SB_1359
		[DataContract]
		public class P_L5BD_SB_1359 
		{
			//Standard type parameters
			[DataMember]
			public String Building_Name { get; set; } 
			[DataMember]
			public Guid RealestatePropertyID { get; set; } 
			[DataMember]
			public Guid RES_BLD_BuildingID { get; set; } 
			[DataMember]
			public int Building_NumberOfFloors { get; set; } 
			[DataMember]
			public double Building_ElevatorCoveragePercent { get; set; } 
			[DataMember]
			public int Building_NumberOfAppartments { get; set; } 
			[DataMember]
			public int Building_NumberOfOccupiedAppartments { get; set; } 
			[DataMember]
			public int Building_NumberOfOffices { get; set; } 
			[DataMember]
			public int Building_NumberOfRetailUnits { get; set; } 
			[DataMember]
			public int Building_NumberOfProductionUnits { get; set; } 
			[DataMember]
			public int Building_NumberOfOtherUnits { get; set; } 
			[DataMember]
			public bool IsContaminationSuspected { get; set; } 
			[DataMember]
			public double Building_BalconyPortionPercent { get; set; } 
			[DataMember]
			public Guid RES_BLD_Building_RevisionHeaderID { get; set; } 
			[DataMember]
			public Guid RES_BLD_GarbageContainerTypeID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Building_TypeID { get; set; } 
			[DataMember]
			public int AppartmentCount { get; set; } 
			[DataMember]
			public int roofCount { get; set; } 
			[DataMember]
			public int staircasesCount { get; set; } 
			[DataMember]
			public int atticsCount { get; set; } 
			[DataMember]
			public int outdoorfacilitiesCount { get; set; } 
			[DataMember]
			public int basementsCount { get; set; } 
			[DataMember]
			public int facadesCount { get; set; } 
			[DataMember]
			public int hvarcsCount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Building(P_L5BD_SB_1359 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_Building.Invoke(connectionString,P_L5BD_SB_1359 Parameter,securityTicket);
	 return result;
}
*/