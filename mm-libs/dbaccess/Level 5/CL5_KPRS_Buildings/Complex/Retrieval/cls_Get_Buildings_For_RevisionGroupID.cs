/* 
 * Generated on 11/6/2013 12:57:05 PM
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
using CL1_RES_STR;
using CL1_RES_DUD;

namespace CL5_KPRS_Buildings.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Buildings_For_RevisionGroupID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Buildings_For_RevisionGroupID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BD_GBFRG_1005_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_GBFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5BD_GBFRG_1005_Array();
			//Put your code here

            List<L5BD_GBFRG_1005> returnList = new List<L5BD_GBFRG_1005>();
            ORM_RES_DUD_Revision.Query rvQuery = new ORM_RES_DUD_Revision.Query();
            rvQuery.IsDeleted = false;
            rvQuery.Tenant_RefID = securityTicket.TenantID;
            rvQuery.RevisionGroup_RefID = Parameter.RevisionGroupID;
            List<ORM_RES_DUD_Revision> revisions = ORM_RES_DUD_Revision.Query.Search(Connection, Transaction, rvQuery);


            foreach (var revision in revisions)
            {
                ORM_RES_BLD_Building bdQuery = new ORM_RES_BLD_Building();
                L5BD_GBFRG_1005 item = new L5BD_GBFRG_1005();

                ORM_RES_BLD_Building building = new ORM_RES_BLD_Building();
                building.Load(Connection, Transaction, revision.RES_BLD_Building_RefID);

                ORM_RES_BLD_Apartment.Query apQuery = new ORM_RES_BLD_Apartment.Query();
                apQuery.Tenant_RefID = securityTicket.TenantID;
                apQuery.IsDeleted = false;
                apQuery.Building_RefID = building.RES_BLD_BuildingID;
                List<ORM_RES_BLD_Apartment> apList = ORM_RES_BLD_Apartment.Query.Search(Connection, Transaction, apQuery);

                List<L5BD_GBFRG_1005_Apartment> apResult=new List<L5BD_GBFRG_1005_Apartment>();
                foreach (var part in apList)
                {
                    L5BD_GBFRG_1005_Apartment itemPart = new L5BD_GBFRG_1005_Apartment();
                    itemPart.ApartmentSize_Unit_RefID = part.ApartmentSize_Unit_RefID;
                    itemPart.ApartmentSize_Value = part.ApartmentSize_Value;
                    itemPart.IsAppartment_ForRent = part.IsDeleted;
                    itemPart.RES_BLD_ApartmentID = part.RES_BLD_ApartmentID;
                    itemPart.Appartment_FlooringType = part.TypeOfFlooring_RefID;
                    itemPart.Appartment_HeatingType = part.TypeOfHeating_RefID;
                    itemPart.Appartment_WallCoveringType = part.TypeOfWallCovering_RefID;

                    ORM_RES_STR_Apartment strApartment = ORM_RES_STR_Apartment.Query.Search(Connection, Transaction, new ORM_RES_STR_Apartment.Query(){
                        RES_BLD_Apartment_RefID = part.RES_BLD_ApartmentID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).FirstOrDefault();
                    if (strApartment != null)
                    {
                        itemPart.ApartmentsDocumentHeader_RefID = strApartment.DocumentHeader_RefID;

                        Guid[] documentHeaders = ORM_RES_STR_Apartment_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_Apartment_PropertyAssessment.Query() {
                            STR_Apartment_RefID = strApartment.RES_STR_ApartmentID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(i => i.DocumentHeader_RefID).ToArray();

                        if (documentHeaders != null)
                            itemPart.ApartmentsPropertyDocumentHeaders = documentHeaders;
                    }

                    apResult.Add(itemPart);
                   
                }
                item.Apartments = apResult.ToArray();


                ORM_RES_BLD_Attic.Query atQuery = new ORM_RES_BLD_Attic.Query();
                atQuery.Tenant_RefID = securityTicket.TenantID;
                atQuery.IsDeleted = false;
                atQuery.Building_RefID = building.RES_BLD_BuildingID;
                List<ORM_RES_BLD_Attic> atList = ORM_RES_BLD_Attic.Query.Search(Connection, Transaction, atQuery);

                List<L5BD_GBFRG_1005_Attic> atResult = new List<L5BD_GBFRG_1005_Attic>(); 
                foreach (var part in atList)
                {
                    L5BD_GBFRG_1005_Attic itemPart = new L5BD_GBFRG_1005_Attic();
                    itemPart.RES_BLD_AtticID = part.RES_BLD_AtticID;

                    ORM_RES_STR_Attic strAttic = ORM_RES_STR_Attic.Query.Search(Connection, Transaction, new ORM_RES_STR_Attic.Query()
                    {
                        RES_BLD_Attic_RefID = part.RES_BLD_AtticID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).FirstOrDefault();
                    if (strAttic != null)
                    {
                        itemPart.AtticsDocumentHeader_RefID = strAttic.DocumentHeader_RefID;

                        Guid[] documentHeaders = ORM_RES_STR_Attic_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_Attic_PropertyAssessment.Query()
                        {
                            STR_Attic_RefID = strAttic.RES_STR_AtticID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(i => i.DocumentHeader_RefID).ToArray();

                        if (documentHeaders != null)
                            itemPart.AtticsPropertyDocumentHeaders = documentHeaders;
                    }

                    atResult.Add(itemPart);

                }
                item.Attics = atResult.ToArray();

                ORM_RES_BLD_Basement.Query baQuery = new ORM_RES_BLD_Basement.Query();
                baQuery.Tenant_RefID = securityTicket.TenantID;
                baQuery.IsDeleted = false;
                baQuery.Building_RefID = building.RES_BLD_BuildingID;
                List<ORM_RES_BLD_Basement> baList = ORM_RES_BLD_Basement.Query.Search(Connection, Transaction, baQuery);

                List<L5BD_GBFRG_1005_Basement> baResult = new List<L5BD_GBFRG_1005_Basement>();
                foreach (var part in baList)
                {
                    L5BD_GBFRG_1005_Basement itemPart = new L5BD_GBFRG_1005_Basement();
                    itemPart.Basement_FloorType = part.TypeOfFloor_RefID;
                    itemPart.RES_BLD_BasementID = part.RES_BLD_BasementID;

                    ORM_RES_STR_Basement strBasement = ORM_RES_STR_Basement.Query.Search(Connection, Transaction, new ORM_RES_STR_Basement.Query()
                    {
                        RES_BLD_Basement_RefID = part.RES_BLD_BasementID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).FirstOrDefault();
                    if (strBasement != null)
                    {
                        itemPart.BasementsDocumentHeader_RefID = strBasement.DocumentHeader_RefID;

                        Guid[] documentHeaders = ORM_RES_STR_Basement_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_Basement_PropertyAssessment.Query()
                        {
                            STR_Basement_RefID = strBasement.RES_STR_BasementID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(i => i.DocumentHeader_RefID).ToArray();

                        if (documentHeaders != null)
                            itemPart.BasementsPropertyDocumentHeaders = documentHeaders;
                    }

                    baResult.Add(itemPart);

                }
                item.Basements = baResult.ToArray();

                ORM_RES_BLD_Facade.Query faQuery = new ORM_RES_BLD_Facade.Query();
                faQuery.Tenant_RefID = securityTicket.TenantID;
                faQuery.IsDeleted = false;
                faQuery.Building_RefID = building.RES_BLD_BuildingID;
                List<ORM_RES_BLD_Facade> faList = ORM_RES_BLD_Facade.Query.Search(Connection, Transaction, faQuery);

                List<L5BD_GBFRG_1005_Facade> faResult = new List<L5BD_GBFRG_1005_Facade>();
                foreach (var part in faList)
                {
                    L5BD_GBFRG_1005_Facade itemPart = new L5BD_GBFRG_1005_Facade();
                    itemPart.RES_BLD_FacadeID = part.RES_BLD_FacadeID;

                    ORM_RES_STR_Facade strFacade = ORM_RES_STR_Facade.Query.Search(Connection, Transaction, new ORM_RES_STR_Facade.Query()
                    {
                        RES_BLD_Facade_RefID = part.RES_BLD_FacadeID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).FirstOrDefault();
                    if (strFacade != null)
                    {
                        itemPart.FacadesDocumentHeader_RefID = strFacade.DocumentHeader_RefID;

                        Guid[] documentHeaders = ORM_RES_STR_Facade_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_Facade_PropertyAssessment.Query()
                        {
                            STR_Facade_RefID = strFacade.RES_STR_FacadeID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(i => i.DocumentHeader_RefID).ToArray();

                        if (documentHeaders != null)
                            itemPart.FacadesPropertyDocumentHeaders = documentHeaders;
                    }

                    faResult.Add(itemPart);

                }
                item.Facades = faResult.ToArray();

                ORM_RES_BLD_HVACR.Query hvQuery = new ORM_RES_BLD_HVACR.Query();
                hvQuery.Tenant_RefID = securityTicket.TenantID;
                hvQuery.IsDeleted = false;
                hvQuery.Building_RefID = building.RES_BLD_BuildingID;
                List<ORM_RES_BLD_HVACR> hvList = ORM_RES_BLD_HVACR.Query.Search(Connection, Transaction, hvQuery);

                List<L5BD_GBFRG_1005_HVACR> hvResult = new List<L5BD_GBFRG_1005_HVACR>();
                foreach (var part in hvList)
                {
                    L5BD_GBFRG_1005_HVACR itemPart = new L5BD_GBFRG_1005_HVACR();
                    itemPart.RES_BLD_HVACRID = part.RES_BLD_HVACRID;

                    ORM_RES_STR_HVACR strHVACR = ORM_RES_STR_HVACR.Query.Search(Connection, Transaction, new ORM_RES_STR_HVACR.Query()
                    {
                        RES_BLD_HVACR_RefID = part.RES_BLD_HVACRID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).FirstOrDefault();
                    if (strHVACR != null)
                    {
                        itemPart.HVACRsDocumentHeader_RefID = strHVACR.DocumentHeader_RefID;

                        Guid[] documentHeaders = ORM_RES_STR_HVACR_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_HVACR_PropertyAssessment.Query()
                        {
                            STR_HVACR_RefID = strHVACR.RES_STR_HVACRID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(i => i.DocumentHeader_RefID).ToArray();

                        if (documentHeaders != null)
                            itemPart.HVACRsPropertyDocumentHeaders = documentHeaders;
                    }

                    hvResult.Add(itemPart);

                }
                item.HVACRs = hvResult.ToArray(); 

                ORM_RES_BLD_OutdoorFacility.Query ofQuery = new ORM_RES_BLD_OutdoorFacility.Query();
                ofQuery.Tenant_RefID = securityTicket.TenantID;
                ofQuery.IsDeleted = false;
                ofQuery.Building_RefID = building.RES_BLD_BuildingID;
                List<ORM_RES_BLD_OutdoorFacility> ofList = ORM_RES_BLD_OutdoorFacility.Query.Search(Connection, Transaction, ofQuery);

                List<L5BD_GBFRG_1005_OutdoorFacility> ofResult = new List<L5BD_GBFRG_1005_OutdoorFacility>();
                foreach (var part in ofList)
                {
                    L5BD_GBFRG_1005_OutdoorFacility itemPart = new L5BD_GBFRG_1005_OutdoorFacility();
                    itemPart.OutdoorFacility_AccessRoadType = part.TypeOfAccessRoad_RefID;
                    itemPart.OutdoorFacility_FenceType = part.TypeOfFence_RefID;
                    itemPart.RES_BLD_OutdoorFacilityID = part.RES_BLD_OutdoorFacilityID;

                    ORM_RES_STR_OutdoorFacility strOutdoorFacility = ORM_RES_STR_OutdoorFacility.Query.Search(Connection, Transaction, new ORM_RES_STR_OutdoorFacility.Query()
                    {
                        RES_BLD_OutdoorFacility_RefID = part.RES_BLD_OutdoorFacilityID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).FirstOrDefault();
                    if (strOutdoorFacility != null)
                    {
                        itemPart.OutdoorFacilitiesDocumentHeader_RefID = strOutdoorFacility.DocumentHeader_RefID;

                        Guid[] documentHeaders = ORM_RES_STR_OutdoorFacility_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_OutdoorFacility_PropertyAssessment.Query()
                        {
                            STR_OutdoorFacility_RefID = strOutdoorFacility.RES_STR_OutdoorFacilityID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(i => i.DocumentHeader_RefID).ToArray();

                        if (documentHeaders != null)
                            itemPart.OutdoorFacilitiesPropertyDocumentHeaders = documentHeaders;
                    }

                    ofResult.Add(itemPart);

                }
                item.OutdoorFacilities = ofResult.ToArray(); 

                ORM_RES_BLD_Roof.Query roQuery = new ORM_RES_BLD_Roof.Query();
                roQuery.Tenant_RefID = securityTicket.TenantID;
                roQuery.IsDeleted = false;
                roQuery.Building_RefID = building.RES_BLD_BuildingID;
                List<ORM_RES_BLD_Roof> roList = ORM_RES_BLD_Roof.Query.Search(Connection, Transaction, roQuery);

                List<L5BD_GBFRG_1005_Roof> roResult = new List<L5BD_GBFRG_1005_Roof>();
                foreach (var part in roList)
                {
                    L5BD_GBFRG_1005_Roof itemPart = new L5BD_GBFRG_1005_Roof();

                    itemPart.RES_BLD_Roof_Type_RefID = ORM_RES_BLD_Roof_2_RoofType.Query.Search(Connection, Transaction, new ORM_RES_BLD_Roof_2_RoofType.Query() 
                        { 
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            RES_BLD_Roof_RefID = part.RES_BLD_RoofID
                        }).Select(r=>r.RES_BLD_Roof_Type_RefID).FirstOrDefault();

                    itemPart.RES_BLD_RoofID = part.RES_BLD_RoofID;

                    ORM_RES_STR_Roof strRoof = ORM_RES_STR_Roof.Query.Search(Connection, Transaction, new ORM_RES_STR_Roof.Query()
                    {
                        RES_BLD_Roof_RefID = part.RES_BLD_RoofID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).FirstOrDefault();
                    if (strRoof != null)
                    { 
                        itemPart.RoofsDocumentHeader_RefID = strRoof.DocumentHeader_RefID;

                        Guid[] documentHeaders = ORM_RES_STR_Roof_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_Roof_PropertyAssessment.Query()
                        {
                            STR_Roof_RefID = strRoof.RES_STR_RoofID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(i => i.DocumentHeader_RefID).ToArray();

                        if (documentHeaders != null)
                            itemPart.RoofsPropertyDocumentHeaders = documentHeaders;
                    }

                    roResult.Add(itemPart);

                }
                item.Roofs = roResult.ToArray(); 

                ORM_RES_BLD_Staircase.Query stQuery = new ORM_RES_BLD_Staircase.Query();
                stQuery.Tenant_RefID = securityTicket.TenantID;
                stQuery.IsDeleted = false;
                stQuery.Building_RefID = building.RES_BLD_BuildingID;
                List<ORM_RES_BLD_Staircase> stList = ORM_RES_BLD_Staircase.Query.Search(Connection, Transaction, stQuery);

                List<L5BD_GBFRG_1005_Staircase> stResult = new List<L5BD_GBFRG_1005_Staircase>();
                foreach (var part in stList)
                {
                    L5BD_GBFRG_1005_Staircase itemPart = new L5BD_GBFRG_1005_Staircase();
                    itemPart.RES_BLD_StaircaseID = part.RES_BLD_StaircaseID;

                    ORM_RES_STR_Staircase strStaircase = ORM_RES_STR_Staircase.Query.Search(Connection, Transaction, new ORM_RES_STR_Staircase.Query()
                    {
                        RES_BLD_Staircase_RefID = part.RES_BLD_StaircaseID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).FirstOrDefault();
                    if (strStaircase != null)
                    {
                        itemPart.StaircasesDocumentHeader_RefID = strStaircase.DocumentHeader_RefID;

                        Guid[] documentHeaders = ORM_RES_STR_Staircase_PropertyAssessment.Query.Search(Connection, Transaction, new ORM_RES_STR_Staircase_PropertyAssessment.Query()
                        {
                            STR_Staircase_RefID = strStaircase.RES_STR_StaircaseID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(i => i.DocumentHeader_RefID).ToArray();

                        if (documentHeaders != null)
                            itemPart.StaircasesPropertyDocumentHeaders = documentHeaders;
                    }
                    stResult.Add(itemPart);

                }
                item.Staircases = stResult.ToArray();


                item.Building_BalconyPortionPercent = building.Building_BalconyPortionPercent;
                item.Building_DocumentationStructure_RefID = building.Building_DocumentationStructure_RefID;
                item.Building_ElevatorCoveragePercent = building.Building_ElevatorCoveragePercent;
                item.Building_Name = building.Building_Name;
                item.Building_NumberOfAppartments = building.Building_NumberOfAppartments;
                item.Building_NumberOfFloors = building.Building_NumberOfFloors;
                item.Building_NumberOfOccupiedAppartments = building.Building_NumberOfOccupiedAppartments;
                item.Building_NumberOfOffices = building.Building_NumberOfOffices;
                item.Building_NumberOfOtherUnits = building.Building_NumberOfOtherUnits;
                item.Building_NumberOfProductionUnits = building.Building_NumberOfProductionUnits;
                item.Building_NumberOfRetailUnits = building.Building_NumberOfRetailUnits;
                item.IsContaminationSuspected = building.IsContaminationSuspected;
                item.RES_BLD_BuildingID = building.RES_BLD_BuildingID;

                ORM_RES_BLD_Building_2_GarbageContainerType.Query gctQuery = new ORM_RES_BLD_Building_2_GarbageContainerType.Query();
                gctQuery.Tenant_RefID = securityTicket.TenantID;
                gctQuery.IsDeleted = false;
                gctQuery.RES_BLD_Building_RefID = building.RES_BLD_BuildingID;
                List<ORM_RES_BLD_Building_2_GarbageContainerType> garbageContainerType = ORM_RES_BLD_Building_2_GarbageContainerType.Query.Search(Connection, Transaction, gctQuery);
               

                ORM_RES_BLD_Building_2_BuildingType.Query b2tQuery = new ORM_RES_BLD_Building_2_BuildingType.Query();
                b2tQuery.Tenant_RefID = securityTicket.TenantID;
                b2tQuery.IsDeleted = false;
                b2tQuery.RES_BLD_Building_RefID = building.RES_BLD_BuildingID;
                List<ORM_RES_BLD_Building_2_BuildingType> buildingType = ORM_RES_BLD_Building_2_BuildingType.Query.Search(Connection, Transaction, b2tQuery);
             

                ORM_RES_BLD_Building_Type.Query btQuery = new ORM_RES_BLD_Building_Type.Query();
                btQuery.Tenant_RefID = securityTicket.TenantID;
                btQuery.IsDeleted = false;
                btQuery.RES_BLD_Building_TypeID = buildingType.FirstOrDefault().RES_BLD_Building_Type_RefID;
                List<ORM_RES_BLD_Building_Type> btList = ORM_RES_BLD_Building_Type.Query.Search(Connection, Transaction, btQuery);

                ORM_RES_BLD_GarbageContainerType.Query gcQuery = new ORM_RES_BLD_GarbageContainerType.Query();
                gcQuery.Tenant_RefID = securityTicket.TenantID;
                gcQuery.IsDeleted = false;
                gcQuery.RES_BLD_GarbageContainerTypeID = garbageContainerType.FirstOrDefault().RES_BLD_GarbageContainerType_RefID;
                List<ORM_RES_BLD_GarbageContainerType> gcList = ORM_RES_BLD_GarbageContainerType.Query.Search(Connection, Transaction, gcQuery);

                if (btList.Count!=0)
                item.Building_Type = btList.FirstOrDefault().BuildingType_Name;
                if (gcList.Count != 0)
                item.Building_GarbageContainerType = gcList.FirstOrDefault().GarbageContainerType_Name;

                item.QuestionnaireVersion_RefID = revision.QuestionnaireVersion_RefID;
                item.RES_DUD_RevisionID = revision.RES_DUD_RevisionID;
                
                returnList.Add(item);

            }

            returnValue.Result = returnList.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BD_GBFRG_1005_Array Invoke(string ConnectionString,P_L5BD_GBFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BD_GBFRG_1005_Array Invoke(DbConnection Connection,P_L5BD_GBFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BD_GBFRG_1005_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_GBFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BD_GBFRG_1005_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_GBFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BD_GBFRG_1005_Array functionReturn = new FR_L5BD_GBFRG_1005_Array();
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

	#region Raw Grouping Class
	[Serializable]
	public class L5BD_GBFRG_1005_raw 
	{
		public String Building_Name; 
		public Guid RES_BLD_BuildingID; 
		public bool IsContaminationSuspected; 
		public int Building_NumberOfFloors; 
		public double Building_ElevatorCoveragePercent; 
		public int Building_NumberOfAppartments; 
		public int Building_NumberOfOccupiedAppartments; 
		public int Building_NumberOfOffices; 
		public int Building_NumberOfRetailUnits; 
		public int Building_NumberOfProductionUnits; 
		public int Building_NumberOfOtherUnits; 
		public double Building_BalconyPortionPercent; 
		public Guid RES_DUD_RevisionID; 
		public Guid QuestionnaireVersion_RefID; 
		public Guid Building_DocumentationStructure_RefID; 
		public Dict Building_Type; 
		public Dict Building_GarbageContainerType; 
		public Guid RES_BLD_RoofID; 
		public Guid RES_BLD_Roof_Type_RefID; 
		public Guid RoofsDocumentHeader_RefID; 
		public Guid[] RoofsPropertyDocumentHeaders; 
		public Guid RES_BLD_ApartmentID; 
		public bool IsAppartment_ForRent; 
		public Guid ApartmentSize_Unit_RefID; 
		public double ApartmentSize_Value; 
		public Guid Appartment_HeatingType; 
		public Guid Appartment_FlooringType; 
		public Guid Appartment_WallCoveringType; 
		public Guid ApartmentsDocumentHeader_RefID; 
		public Guid[] ApartmentsPropertyDocumentHeaders; 
		public Guid RES_BLD_OutdoorFacilityID; 
		public int NumberOfGaragePlaces; 
		public int NumberOfRentedGaragePlaces; 
		public Guid OutdoorFacility_AccessRoadType; 
		public Guid OutdoorFacility_FenceType; 
		public Guid OutdoorFacilitiesDocumentHeader_RefID; 
		public Guid[] OutdoorFacilitiesPropertyDocumentHeaders; 
		public Guid RES_BLD_FacadeID; 
		public Guid FacadesDocumentHeader_RefID; 
		public Guid[] FacadesPropertyDocumentHeaders; 
		public Guid RES_BLD_HVACRID; 
		public Guid HVACRsDocumentHeader_RefID; 
		public Guid[] HVACRsPropertyDocumentHeaders; 
		public Guid RES_BLD_BasementID; 
		public Guid Basement_FloorType; 
		public Guid BasementsDocumentHeader_RefID; 
		public Guid[] BasementsPropertyDocumentHeaders; 
		public Guid RES_BLD_AtticID; 
		public Guid AtticsDocumentHeader_RefID; 
		public Guid[] AtticsPropertyDocumentHeaders; 
		public Guid RES_BLD_StaircaseID; 
		public double StaircaseSize_Value; 
		public Guid StaircaseSize_Unit_RefID; 
		public Guid StaircasesDocumentHeader_RefID; 
		public Guid[] StaircasesPropertyDocumentHeaders; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5BD_GBFRG_1005[] Convert(List<L5BD_GBFRG_1005_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5BD_GBFRG_1005 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_BLD_BuildingID)).ToArray()
	group el_L5BD_GBFRG_1005 by new 
	{ 
		el_L5BD_GBFRG_1005.RES_BLD_BuildingID,

	}
	into gfunct_L5BD_GBFRG_1005
	select new L5BD_GBFRG_1005
	{     
		Building_Name = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_Name ,
		RES_BLD_BuildingID = gfunct_L5BD_GBFRG_1005.Key.RES_BLD_BuildingID ,
		IsContaminationSuspected = gfunct_L5BD_GBFRG_1005.FirstOrDefault().IsContaminationSuspected ,
		Building_NumberOfFloors = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfFloors ,
		Building_ElevatorCoveragePercent = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_ElevatorCoveragePercent ,
		Building_NumberOfAppartments = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfAppartments ,
		Building_NumberOfOccupiedAppartments = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfOccupiedAppartments ,
		Building_NumberOfOffices = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfOffices ,
		Building_NumberOfRetailUnits = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfRetailUnits ,
		Building_NumberOfProductionUnits = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfProductionUnits ,
		Building_NumberOfOtherUnits = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfOtherUnits ,
		Building_BalconyPortionPercent = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_BalconyPortionPercent ,
		RES_DUD_RevisionID = gfunct_L5BD_GBFRG_1005.FirstOrDefault().RES_DUD_RevisionID ,
		QuestionnaireVersion_RefID = gfunct_L5BD_GBFRG_1005.FirstOrDefault().QuestionnaireVersion_RefID ,
		Building_DocumentationStructure_RefID = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_DocumentationStructure_RefID ,
		Building_Type = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_Type ,
		Building_GarbageContainerType = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_GarbageContainerType ,

		Roofs = 
		(
			from el_Roofs in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_RoofID)).ToArray()
			group el_Roofs by new 
			{ 
				el_Roofs.RES_BLD_RoofID,

			}
			into gfunct_Roofs
			select new L5BD_GBFRG_1005_Roof
			{     
				RES_BLD_RoofID = gfunct_Roofs.Key.RES_BLD_RoofID ,
				RES_BLD_Roof_Type_RefID = gfunct_Roofs.FirstOrDefault().RES_BLD_Roof_Type_RefID ,
				RoofsDocumentHeader_RefID = gfunct_Roofs.FirstOrDefault().RoofsDocumentHeader_RefID ,
				RoofsPropertyDocumentHeaders = gfunct_Roofs.FirstOrDefault().RoofsPropertyDocumentHeaders ,

			}
		).ToArray(),
		Apartments = 
		(
			from el_Apartments in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_ApartmentID)).ToArray()
			group el_Apartments by new 
			{ 
				el_Apartments.RES_BLD_ApartmentID,

			}
			into gfunct_Apartments
			select new L5BD_GBFRG_1005_Apartment
			{     
				RES_BLD_ApartmentID = gfunct_Apartments.Key.RES_BLD_ApartmentID ,
				IsAppartment_ForRent = gfunct_Apartments.FirstOrDefault().IsAppartment_ForRent ,
				ApartmentSize_Unit_RefID = gfunct_Apartments.FirstOrDefault().ApartmentSize_Unit_RefID ,
				ApartmentSize_Value = gfunct_Apartments.FirstOrDefault().ApartmentSize_Value ,
				Appartment_HeatingType = gfunct_Apartments.FirstOrDefault().Appartment_HeatingType ,
				Appartment_FlooringType = gfunct_Apartments.FirstOrDefault().Appartment_FlooringType ,
				Appartment_WallCoveringType = gfunct_Apartments.FirstOrDefault().Appartment_WallCoveringType ,
				ApartmentsDocumentHeader_RefID = gfunct_Apartments.FirstOrDefault().ApartmentsDocumentHeader_RefID ,
				ApartmentsPropertyDocumentHeaders = gfunct_Apartments.FirstOrDefault().ApartmentsPropertyDocumentHeaders ,

			}
		).ToArray(),
		OutdoorFacilities = 
		(
			from el_OutdoorFacilities in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_OutdoorFacilityID)).ToArray()
			group el_OutdoorFacilities by new 
			{ 
				el_OutdoorFacilities.RES_BLD_OutdoorFacilityID,

			}
			into gfunct_OutdoorFacilities
			select new L5BD_GBFRG_1005_OutdoorFacility
			{     
				RES_BLD_OutdoorFacilityID = gfunct_OutdoorFacilities.Key.RES_BLD_OutdoorFacilityID ,
				NumberOfGaragePlaces = gfunct_OutdoorFacilities.FirstOrDefault().NumberOfGaragePlaces ,
				NumberOfRentedGaragePlaces = gfunct_OutdoorFacilities.FirstOrDefault().NumberOfRentedGaragePlaces ,
				OutdoorFacility_AccessRoadType = gfunct_OutdoorFacilities.FirstOrDefault().OutdoorFacility_AccessRoadType ,
				OutdoorFacility_FenceType = gfunct_OutdoorFacilities.FirstOrDefault().OutdoorFacility_FenceType ,
				OutdoorFacilitiesDocumentHeader_RefID = gfunct_OutdoorFacilities.FirstOrDefault().OutdoorFacilitiesDocumentHeader_RefID ,
				OutdoorFacilitiesPropertyDocumentHeaders = gfunct_OutdoorFacilities.FirstOrDefault().OutdoorFacilitiesPropertyDocumentHeaders ,

			}
		).ToArray(),
		Facades = 
		(
			from el_Facades in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_FacadeID)).ToArray()
			group el_Facades by new 
			{ 
				el_Facades.RES_BLD_FacadeID,

			}
			into gfunct_Facades
			select new L5BD_GBFRG_1005_Facade
			{     
				RES_BLD_FacadeID = gfunct_Facades.Key.RES_BLD_FacadeID ,
				FacadesDocumentHeader_RefID = gfunct_Facades.FirstOrDefault().FacadesDocumentHeader_RefID ,
				FacadesPropertyDocumentHeaders = gfunct_Facades.FirstOrDefault().FacadesPropertyDocumentHeaders ,

			}
		).ToArray(),
		HVACRs = 
		(
			from el_HVACRs in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_HVACRID)).ToArray()
			group el_HVACRs by new 
			{ 
				el_HVACRs.RES_BLD_HVACRID,

			}
			into gfunct_HVACRs
			select new L5BD_GBFRG_1005_HVACR
			{     
				RES_BLD_HVACRID = gfunct_HVACRs.Key.RES_BLD_HVACRID ,
				HVACRsDocumentHeader_RefID = gfunct_HVACRs.FirstOrDefault().HVACRsDocumentHeader_RefID ,
				HVACRsPropertyDocumentHeaders = gfunct_HVACRs.FirstOrDefault().HVACRsPropertyDocumentHeaders ,

			}
		).ToArray(),
		Basements = 
		(
			from el_Basements in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_BasementID)).ToArray()
			group el_Basements by new 
			{ 
				el_Basements.RES_BLD_BasementID,

			}
			into gfunct_Basements
			select new L5BD_GBFRG_1005_Basement
			{     
				RES_BLD_BasementID = gfunct_Basements.Key.RES_BLD_BasementID ,
				Basement_FloorType = gfunct_Basements.FirstOrDefault().Basement_FloorType ,
				BasementsDocumentHeader_RefID = gfunct_Basements.FirstOrDefault().BasementsDocumentHeader_RefID ,
				BasementsPropertyDocumentHeaders = gfunct_Basements.FirstOrDefault().BasementsPropertyDocumentHeaders ,

			}
		).ToArray(),
		Attics = 
		(
			from el_Attics in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_AtticID)).ToArray()
			group el_Attics by new 
			{ 
				el_Attics.RES_BLD_AtticID,

			}
			into gfunct_Attics
			select new L5BD_GBFRG_1005_Attic
			{     
				RES_BLD_AtticID = gfunct_Attics.Key.RES_BLD_AtticID ,
				AtticsDocumentHeader_RefID = gfunct_Attics.FirstOrDefault().AtticsDocumentHeader_RefID ,
				AtticsPropertyDocumentHeaders = gfunct_Attics.FirstOrDefault().AtticsPropertyDocumentHeaders ,

			}
		).ToArray(),
		Staircases = 
		(
			from el_Staircases in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_StaircaseID)).ToArray()
			group el_Staircases by new 
			{ 
				el_Staircases.RES_BLD_StaircaseID,

			}
			into gfunct_Staircases
			select new L5BD_GBFRG_1005_Staircase
			{     
				RES_BLD_StaircaseID = gfunct_Staircases.Key.RES_BLD_StaircaseID ,
				StaircaseSize_Value = gfunct_Staircases.FirstOrDefault().StaircaseSize_Value ,
				StaircaseSize_Unit_RefID = gfunct_Staircases.FirstOrDefault().StaircaseSize_Unit_RefID ,
				StaircasesDocumentHeader_RefID = gfunct_Staircases.FirstOrDefault().StaircasesDocumentHeader_RefID ,
				StaircasesPropertyDocumentHeaders = gfunct_Staircases.FirstOrDefault().StaircasesPropertyDocumentHeaders ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5BD_GBFRG_1005_Array : FR_Base
	{
		public L5BD_GBFRG_1005[] Result	{ get; set; } 
		public FR_L5BD_GBFRG_1005_Array() : base() {}

		public FR_L5BD_GBFRG_1005_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BD_GBFRG_1005 for attribute P_L5BD_GBFRG_1005
		[DataContract]
		public class P_L5BD_GBFRG_1005 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionGroupID { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005 for attribute L5BD_GBFRG_1005
		[DataContract]
		public class L5BD_GBFRG_1005 
		{
			[DataMember]
			public L5BD_GBFRG_1005_Roof[] Roofs { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_Apartment[] Apartments { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_OutdoorFacility[] OutdoorFacilities { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_Facade[] Facades { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_HVACR[] HVACRs { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_Basement[] Basements { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_Attic[] Attics { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_Staircase[] Staircases { get; set; }

			//Standard type parameters
			[DataMember]
			public String Building_Name { get; set; } 
			[DataMember]
			public Guid RES_BLD_BuildingID { get; set; } 
			[DataMember]
			public bool IsContaminationSuspected { get; set; } 
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
			public double Building_BalconyPortionPercent { get; set; } 
			[DataMember]
			public Guid RES_DUD_RevisionID { get; set; } 
			[DataMember]
			public Guid QuestionnaireVersion_RefID { get; set; } 
			[DataMember]
			public Guid Building_DocumentationStructure_RefID { get; set; } 
			[DataMember]
			public Dict Building_Type { get; set; } 
			[DataMember]
			public Dict Building_GarbageContainerType { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_Roof for attribute Roofs
		[DataContract]
		public class L5BD_GBFRG_1005_Roof 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_RoofID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Roof_Type_RefID { get; set; } 
			[DataMember]
			public Guid RoofsDocumentHeader_RefID { get; set; } 
			[DataMember]
			public Guid[] RoofsPropertyDocumentHeaders { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_Apartment for attribute Apartments
		[DataContract]
		public class L5BD_GBFRG_1005_Apartment 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_ApartmentID { get; set; } 
			[DataMember]
			public bool IsAppartment_ForRent { get; set; } 
			[DataMember]
			public Guid ApartmentSize_Unit_RefID { get; set; } 
			[DataMember]
			public double ApartmentSize_Value { get; set; } 
			[DataMember]
			public Guid Appartment_HeatingType { get; set; } 
			[DataMember]
			public Guid Appartment_FlooringType { get; set; } 
			[DataMember]
			public Guid Appartment_WallCoveringType { get; set; } 
			[DataMember]
			public Guid ApartmentsDocumentHeader_RefID { get; set; } 
			[DataMember]
			public Guid[] ApartmentsPropertyDocumentHeaders { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_OutdoorFacility for attribute OutdoorFacilities
		[DataContract]
		public class L5BD_GBFRG_1005_OutdoorFacility 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_OutdoorFacilityID { get; set; } 
			[DataMember]
			public int NumberOfGaragePlaces { get; set; } 
			[DataMember]
			public int NumberOfRentedGaragePlaces { get; set; } 
			[DataMember]
			public Guid OutdoorFacility_AccessRoadType { get; set; } 
			[DataMember]
			public Guid OutdoorFacility_FenceType { get; set; } 
			[DataMember]
			public Guid OutdoorFacilitiesDocumentHeader_RefID { get; set; } 
			[DataMember]
			public Guid[] OutdoorFacilitiesPropertyDocumentHeaders { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_Facade for attribute Facades
		[DataContract]
		public class L5BD_GBFRG_1005_Facade 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_FacadeID { get; set; } 
			[DataMember]
			public Guid FacadesDocumentHeader_RefID { get; set; } 
			[DataMember]
			public Guid[] FacadesPropertyDocumentHeaders { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_HVACR for attribute HVACRs
		[DataContract]
		public class L5BD_GBFRG_1005_HVACR 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_HVACRID { get; set; } 
			[DataMember]
			public Guid HVACRsDocumentHeader_RefID { get; set; } 
			[DataMember]
			public Guid[] HVACRsPropertyDocumentHeaders { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_Basement for attribute Basements
		[DataContract]
		public class L5BD_GBFRG_1005_Basement 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_BasementID { get; set; } 
			[DataMember]
			public Guid Basement_FloorType { get; set; } 
			[DataMember]
			public Guid BasementsDocumentHeader_RefID { get; set; } 
			[DataMember]
			public Guid[] BasementsPropertyDocumentHeaders { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_Attic for attribute Attics
		[DataContract]
		public class L5BD_GBFRG_1005_Attic 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_AtticID { get; set; } 
			[DataMember]
			public Guid AtticsDocumentHeader_RefID { get; set; } 
			[DataMember]
			public Guid[] AtticsPropertyDocumentHeaders { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_Staircase for attribute Staircases
		[DataContract]
		public class L5BD_GBFRG_1005_Staircase 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_StaircaseID { get; set; } 
			[DataMember]
			public double StaircaseSize_Value { get; set; } 
			[DataMember]
			public Guid StaircaseSize_Unit_RefID { get; set; } 
			[DataMember]
			public Guid StaircasesDocumentHeader_RefID { get; set; } 
			[DataMember]
			public Guid[] StaircasesPropertyDocumentHeaders { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BD_GBFRG_1005_Array cls_Get_Buildings_For_RevisionGroupID(P_L5BD_GBFRG_1005 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5BD_GBFRG_1005_Array result = cls_Get_Buildings_For_RevisionGroupID.Invoke(connectionString,P_L5BD_GBFRG_1005 Parameter,securityTicket);
	 return result;
}
*/