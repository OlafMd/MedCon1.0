/* 
 * Generated on 11/6/2013 4:14:07 PM
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
using CL3_Document.Atomic.Retrieval;

namespace CL5_KPRS_Buildings.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BuildingInfo_for_Building_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BuildingInfo_for_Building_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GBIfBI_1159 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_GBIfBI_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5BL_GBIfBI_1159();
            //Put your code here
            var building = new ORM_RES_BLD_Building();
            building.Load(Connection, Transaction, Parameter.BuildingID);
            if (building == null || building.RES_BLD_BuildingID == Guid.Empty)
            {
                return null;
            }
            returnValue.Result = new L5BL_GBIfBI_1159();
            returnValue.Result.Building_BalconyPortionPercent = building.Building_BalconyPortionPercent;
            returnValue.Result.Building_DocumentationStructure_RefID = building.Building_DocumentationStructure_RefID;
            returnValue.Result.Building_ElevatorCoveragePercent = building.Building_ElevatorCoveragePercent;
            returnValue.Result.Building_Name = building.Building_Name;
            returnValue.Result.Building_NumberOfAppartments = building.Building_NumberOfAppartments;
            returnValue.Result.Building_NumberOfOccupiedAppartments = building.Building_NumberOfOccupiedAppartments;
            returnValue.Result.Building_NumberOfFloors = building.Building_NumberOfFloors;
            returnValue.Result.Building_NumberOfOffices = building.Building_NumberOfOffices;
            returnValue.Result.Building_NumberOfOtherUnits = building.Building_NumberOfOtherUnits;
            returnValue.Result.Building_NumberOfProductionUnits = building.Building_NumberOfProductionUnits;
            returnValue.Result.Building_NumberOfRetailUnits = building.Building_NumberOfRetailUnits;
            returnValue.Result.BuildingRevisionHeader_RefID = building.BuildingRevisionHeader_RefID;
            returnValue.Result.IsContaminationSuspected = building.IsContaminationSuspected;
            returnValue.Result.RES_BLD_BuildingID = building.RES_BLD_BuildingID;
            ORM_RES_BLD_Building_2_BuildingType type = ORM_RES_BLD_Building_2_BuildingType.Query.Search(Connection, Transaction, new ORM_RES_BLD_Building_2_BuildingType.Query { RES_BLD_Building_RefID = building.RES_BLD_BuildingID, Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).FirstOrDefault();
            if (type != null)
            {
                returnValue.Result.BuildingType_RefID=type.RES_BLD_Building_Type_RefID;
            }
            ORM_RES_BLD_Building_2_GarbageContainerType garbageType = ORM_RES_BLD_Building_2_GarbageContainerType.Query.Search(Connection, Transaction, new ORM_RES_BLD_Building_2_GarbageContainerType.Query { RES_BLD_Building_RefID = building.RES_BLD_BuildingID, Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).FirstOrDefault();
            if (type != null)
            {
                returnValue.Result.GarbageContainerType_RefID = garbageType.RES_BLD_GarbageContainerType_RefID;
            }

            var apartments = new List<L5BL_GBIfBI_1159_Apartment>();
            var basements = new List<L5BL_GBIfBI_1159_Basement>();
            var attics = new List<L5BL_GBIfBI_1159_Attic>();
            var outdoorFascilities = new List<L5BL_GBIfBI_1159_OutdoorFacility>();
            var facades = new List<L5BL_GBIfBI_1159_Facade>();
            var HVACRs = new List<L5BL_GBIfBI_1159_HVACR>();
            var staircases = new List<L5BL_GBIfBI_1159_Staircase>();
            var roofs = new List<L5BL_GBIfBI_1159_Roof>();

            #region apartments
            var ormApartments = ORM_RES_BLD_Apartment.Query.Search(Connection, Transaction, new ORM_RES_BLD_Apartment.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Building_RefID = Parameter.BuildingID
            });

            foreach (var ormApartment in ormApartments)
            {
                var apt = new L5BL_GBIfBI_1159_Apartment()
                {
                    ApartmentSize_Unit_RefID = ormApartment.ApartmentSize_Unit_RefID,
                    ApartmentSize_Value = ormApartment.ApartmentSize_Value,
                    RES_BLD_ApartmentID = ormApartment.RES_BLD_ApartmentID,
                    IsAppartment_ForRent = ormApartment.IsAppartment_ForRent,
                    Appartment_HeatingType = ormApartment.TypeOfHeating_RefID,
                    Appartment_FlooringType = ormApartment.TypeOfFlooring_RefID,
                    Appartment_WallCoveringType = ormApartment.TypeOfWallCovering_RefID,
                    RES_BLD_Apartment_TypeID = ORM_RES_BLD_Apartment_2_ApartmentType.Query.Search(Connection, Transaction, new ORM_RES_BLD_Apartment_2_ApartmentType.Query()
                        {
                            RES_BLD_Apartment_RefID = ormApartment.RES_BLD_ApartmentID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(a=>a.RES_BLD_Apartment_Type_RefID).FirstOrDefault()
                };

                apartments.Add(apt);

            }
            #endregion


            #region attics
            var ormAttics = ORM_RES_BLD_Attic.Query.Search(Connection, Transaction, new ORM_RES_BLD_Attic.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Building_RefID = Parameter.BuildingID
            });

            foreach (var ormAttic in ormAttics)
            {
                var attic = new L5BL_GBIfBI_1159_Attic()
                {
                    RES_BLD_AtticID = ormAttic.RES_BLD_AtticID,
                    RES_BLD_Attic_TypeID = ORM_RES_BLD_Attic_2_AtticType.Query.Search(Connection, Transaction, new ORM_RES_BLD_Attic_2_AtticType.Query()
                        {
                            RES_BLD_Attic_RefID = ormAttic.RES_BLD_AtticID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(a=>a.RES_BLD_Attic_Type_RefID).FirstOrDefault()
                };

                attics.Add(attic);

            }
            #endregion


            #region roofs
            var ormRoofs = ORM_RES_BLD_Roof.Query.Search(Connection, Transaction, new ORM_RES_BLD_Roof.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Building_RefID = Parameter.BuildingID
            });

            foreach (var ormRoof in ormRoofs)
            {
                var roof = new L5BL_GBIfBI_1159_Roof()
                {
                    RES_BLD_RoofID = ormRoof.RES_BLD_RoofID,
                    RES_BLD_RoofTypeID = ORM_RES_BLD_Roof_2_RoofType.Query.Search(Connection, Transaction, new ORM_RES_BLD_Roof_2_RoofType.Query()
                        {
                            RES_BLD_Roof_RefID = ormRoof.RES_BLD_RoofID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(r=>r.RES_BLD_Roof_Type_RefID).FirstOrDefault()
                };

                roofs.Add(roof);

            }
            #endregion


            #region staircases
            var ormStaircases = ORM_RES_BLD_Staircase.Query.Search(Connection, Transaction, new ORM_RES_BLD_Staircase.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Building_RefID = Parameter.BuildingID
            });

            foreach (var ormStaircase in ormStaircases)
            {
                var staircase = new L5BL_GBIfBI_1159_Staircase()
                {
                    StaircaseSize_Unit_RefID = ormStaircase.StaircaseSize_Unit_RefID,
                    StaircaseSize_Value = ormStaircase.StaircaseSize_Value,
                    RES_BLD_StaircaseID = ormStaircase.RES_BLD_StaircaseID,
                    RES_BLD_Staircase_TypeID = ORM_RES_BLD_Staircase_2_StaircaseType.Query.Search(Connection, Transaction, new ORM_RES_BLD_Staircase_2_StaircaseType.Query()
                        {
                            RES_BLD_Staircase_RefID = ormStaircase.RES_BLD_StaircaseID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(s=>s.RES_BLD_Staircase_Type_RefID).FirstOrDefault()
                };

                staircases.Add(staircase);

            }
            #endregion


            #region basements
            var ormBasements = ORM_RES_BLD_Basement.Query.Search(Connection, Transaction, new ORM_RES_BLD_Basement.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Building_RefID = Parameter.BuildingID
            });

            foreach (var ormBasement in ormBasements)
            {
                var basement = new L5BL_GBIfBI_1159_Basement()
                {
                    RES_BLD_BasementID = ormBasement.RES_BLD_BasementID,
                    Basement_FloorType = ormBasement.TypeOfFloor_RefID,
                    RES_BLD_Basement_TypeID = ORM_RES_BLD_Basement_2_BasementType.Query.Search(Connection, Transaction, new ORM_RES_BLD_Basement_2_BasementType.Query()
                        {
                            RES_BLD_Basement_RefID = ormBasement.RES_BLD_BasementID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(b=>b.RES_BLD_Basement_Type_RefID).FirstOrDefault()
                };

                basements.Add(basement);

            }
            #endregion


            #region HVACRs
            var ormHVACRs = ORM_RES_BLD_HVACR.Query.Search(Connection, Transaction, new ORM_RES_BLD_HVACR.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Building_RefID = Parameter.BuildingID
            });

            foreach (var ormHVACR in ormHVACRs)
            {
                var hvacr = new L5BL_GBIfBI_1159_HVACR()
                {
                    RES_BLD_HVACRID = ormHVACR.RES_BLD_HVACRID,
                    RES_BLD_HVACR_TypeID = ORM_RES_BLD_HVACR_2_HVACR_Type.Query.Search(Connection, Transaction, new ORM_RES_BLD_HVACR_2_HVACR_Type.Query()
                        {
                            RES_BLD_HVACR_RefID = ormHVACR.RES_BLD_HVACRID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(h=>h.RES_BLD_HVACR_Type_RefID).FirstOrDefault()
                };

                HVACRs.Add(hvacr);

            }
            #endregion


            #region facades
            var ormFacades = ORM_RES_BLD_Facade.Query.Search(Connection, Transaction, new ORM_RES_BLD_Facade.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Building_RefID = Parameter.BuildingID
            });

            foreach (var ormFacade in ormFacades)
            {
                var facade = new L5BL_GBIfBI_1159_Facade()
                {
                    RES_BLD_FacadeID = ormFacade.RES_BLD_FacadeID,
                    RES_BLD_Facade_TypeID = ORM_RES_BLD_Facade_2_FacadeType.Query.Search(Connection, Transaction, new ORM_RES_BLD_Facade_2_FacadeType.Query()
                        {
                            RES_BLD_Facade_RefID = ormFacade.RES_BLD_FacadeID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(f=>f.RES_BLD_Facade_Type_RefID).FirstOrDefault()
                };

                facades.Add(facade);

            }
            #endregion



            #region outdoorFascilitys
            var ormOutdoorFascilitys = ORM_RES_BLD_OutdoorFacility.Query.Search(Connection, Transaction, new ORM_RES_BLD_OutdoorFacility.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Building_RefID = Parameter.BuildingID
            });

            foreach (var ormOutdoorFascility in ormOutdoorFascilitys)
            {
                var outdoorFascility = new L5BL_GBIfBI_1159_OutdoorFacility()
                {
                    RES_BLD_OutdoorFacilityID = ormOutdoorFascility.RES_BLD_OutdoorFacilityID,
                    NumberOfGaragePlaces = ormOutdoorFascility.NumberOfGaragePlaces,
                    NumberOfRentedGaragePlaces = ormOutdoorFascility.NumberOfRentedGaragePlaces,
                    OutdoorFacility_AccessRoadType = ormOutdoorFascility.TypeOfAccessRoad_RefID,
                    OutdoorFacility_FenceType = ormOutdoorFascility.TypeOfFence_RefID,
                    RES_BLD_OutdoorFacility_TypeID = ORM_RES_BLD_OutdoorFacility_2_OutdoorFacilityType.Query.Search(Connection, Transaction, new ORM_RES_BLD_OutdoorFacility_2_OutdoorFacilityType.Query()
                        {
                            RES_BLD_OutdoorFacility_RefID = ormOutdoorFascility.RES_BLD_OutdoorFacilityID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Select(o=>o.RES_BLD_OutdoorFacility_Type_RefID).FirstOrDefault()
                };

                outdoorFascilities.Add(outdoorFascility);

            }
            #endregion

            returnValue.Result.Apartment = apartments.ToArray();
            returnValue.Result.Attic = attics.ToArray();
            returnValue.Result.Basement = basements.ToArray();
            returnValue.Result.OutdoorFacility = outdoorFascilities.ToArray();
            returnValue.Result.Facade = facades.ToArray();
            returnValue.Result.HVACR = HVACRs.ToArray();
            returnValue.Result.Staircase = staircases.ToArray();
            returnValue.Result.Roof = roofs.ToArray();
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BL_GBIfBI_1159 Invoke(string ConnectionString,P_L5BL_GBIfBI_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GBIfBI_1159 Invoke(DbConnection Connection,P_L5BL_GBIfBI_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GBIfBI_1159 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_GBIfBI_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GBIfBI_1159 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_GBIfBI_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GBIfBI_1159 functionReturn = new FR_L5BL_GBIfBI_1159();
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
	public class L5BL_GBIfBI_1159_raw 
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
		public Guid BuildingRevisionHeader_RefID; 
		public Guid Building_DocumentationStructure_RefID; 
		public Guid BuildingType_RefID; 
		public Guid GarbageContainerType_RefID; 
		public L3DO_GDfDH_1133[] Images; 
		public Guid RES_BLD_Apartment_TypeID; 
		public Guid RES_BLD_ApartmentID; 
		public bool IsAppartment_ForRent; 
		public Guid ApartmentSize_Unit_RefID; 
		public double ApartmentSize_Value; 
		public Guid Appartment_HeatingType; 
		public Guid Appartment_FlooringType; 
		public Guid Appartment_WallCoveringType; 
		public Guid RES_BLD_OutdoorFacilityID; 
		public int NumberOfRentedGaragePlaces; 
		public int NumberOfGaragePlaces; 
		public Guid OutdoorFacility_AccessRoadType; 
		public Guid OutdoorFacility_FenceType; 
		public Guid RES_BLD_OutdoorFacility_TypeID; 
		public Guid RES_BLD_Facade_TypeID; 
		public Guid RES_BLD_FacadeID; 
		public Guid RES_BLD_HVACRID; 
		public Guid RES_BLD_HVACR_TypeID; 
		public Guid RES_BLD_Basement_TypeID; 
		public Guid RES_BLD_BasementID; 
		public Guid Basement_FloorType; 
		public Guid RES_BLD_Attic_TypeID; 
		public Guid RES_BLD_AtticID; 
		public Guid RES_BLD_Staircase_TypeID; 
		public double StaircaseSize_Value; 
		public Guid StaircaseSize_Unit_RefID; 
		public Guid RES_BLD_StaircaseID; 
		public Guid RES_BLD_RoofID; 
		public Guid RES_BLD_RoofTypeID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5BL_GBIfBI_1159[] Convert(List<L5BL_GBIfBI_1159_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5BL_GBIfBI_1159 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_BLD_BuildingID)).ToArray()
	group el_L5BL_GBIfBI_1159 by new 
	{ 
		el_L5BL_GBIfBI_1159.RES_BLD_BuildingID,

	}
	into gfunct_L5BL_GBIfBI_1159
	select new L5BL_GBIfBI_1159
	{     
		Building_Name = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().Building_Name ,
		RES_BLD_BuildingID = gfunct_L5BL_GBIfBI_1159.Key.RES_BLD_BuildingID ,
		IsContaminationSuspected = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().IsContaminationSuspected ,
		Building_NumberOfFloors = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().Building_NumberOfFloors ,
		Building_ElevatorCoveragePercent = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().Building_ElevatorCoveragePercent ,
		Building_NumberOfAppartments = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().Building_NumberOfAppartments ,
		Building_NumberOfOccupiedAppartments = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().Building_NumberOfOccupiedAppartments ,
		Building_NumberOfOffices = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().Building_NumberOfOffices ,
		Building_NumberOfRetailUnits = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().Building_NumberOfRetailUnits ,
		Building_NumberOfProductionUnits = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().Building_NumberOfProductionUnits ,
		Building_NumberOfOtherUnits = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().Building_NumberOfOtherUnits ,
		Building_BalconyPortionPercent = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().Building_BalconyPortionPercent ,
		BuildingRevisionHeader_RefID = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().BuildingRevisionHeader_RefID ,
		Building_DocumentationStructure_RefID = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().Building_DocumentationStructure_RefID ,
		BuildingType_RefID = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().BuildingType_RefID ,
		GarbageContainerType_RefID = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().GarbageContainerType_RefID ,
		Images = gfunct_L5BL_GBIfBI_1159.FirstOrDefault().Images ,

		Apartment = 
		(
			from el_Apartment in gfunct_L5BL_GBIfBI_1159.Where(element => !EqualsDefaultValue(element.RES_BLD_ApartmentID)).ToArray()
			group el_Apartment by new 
			{ 
				el_Apartment.RES_BLD_ApartmentID,

			}
			into gfunct_Apartment
			select new L5BL_GBIfBI_1159_Apartment
			{     
				RES_BLD_Apartment_TypeID = gfunct_Apartment.FirstOrDefault().RES_BLD_Apartment_TypeID ,
				RES_BLD_ApartmentID = gfunct_Apartment.Key.RES_BLD_ApartmentID ,
				IsAppartment_ForRent = gfunct_Apartment.FirstOrDefault().IsAppartment_ForRent ,
				ApartmentSize_Unit_RefID = gfunct_Apartment.FirstOrDefault().ApartmentSize_Unit_RefID ,
				ApartmentSize_Value = gfunct_Apartment.FirstOrDefault().ApartmentSize_Value ,
				Appartment_HeatingType = gfunct_Apartment.FirstOrDefault().Appartment_HeatingType ,
				Appartment_FlooringType = gfunct_Apartment.FirstOrDefault().Appartment_FlooringType ,
				Appartment_WallCoveringType = gfunct_Apartment.FirstOrDefault().Appartment_WallCoveringType ,

			}
		).ToArray(),
		OutdoorFacility = 
		(
			from el_OutdoorFacility in gfunct_L5BL_GBIfBI_1159.Where(element => !EqualsDefaultValue(element.RES_BLD_OutdoorFacilityID)).ToArray()
			group el_OutdoorFacility by new 
			{ 
				el_OutdoorFacility.RES_BLD_OutdoorFacilityID,

			}
			into gfunct_OutdoorFacility
			select new L5BL_GBIfBI_1159_OutdoorFacility
			{     
				RES_BLD_OutdoorFacilityID = gfunct_OutdoorFacility.Key.RES_BLD_OutdoorFacilityID ,
				NumberOfRentedGaragePlaces = gfunct_OutdoorFacility.FirstOrDefault().NumberOfRentedGaragePlaces ,
				NumberOfGaragePlaces = gfunct_OutdoorFacility.FirstOrDefault().NumberOfGaragePlaces ,
				OutdoorFacility_AccessRoadType = gfunct_OutdoorFacility.FirstOrDefault().OutdoorFacility_AccessRoadType ,
				OutdoorFacility_FenceType = gfunct_OutdoorFacility.FirstOrDefault().OutdoorFacility_FenceType ,
				RES_BLD_OutdoorFacility_TypeID = gfunct_OutdoorFacility.FirstOrDefault().RES_BLD_OutdoorFacility_TypeID ,

			}
		).ToArray(),
		Facade = 
		(
			from el_Facade in gfunct_L5BL_GBIfBI_1159.Where(element => !EqualsDefaultValue(element.RES_BLD_FacadeID)).ToArray()
			group el_Facade by new 
			{ 
				el_Facade.RES_BLD_FacadeID,

			}
			into gfunct_Facade
			select new L5BL_GBIfBI_1159_Facade
			{     
				RES_BLD_Facade_TypeID = gfunct_Facade.FirstOrDefault().RES_BLD_Facade_TypeID ,
				RES_BLD_FacadeID = gfunct_Facade.Key.RES_BLD_FacadeID ,

			}
		).ToArray(),
		HVACR = 
		(
			from el_HVACR in gfunct_L5BL_GBIfBI_1159.Where(element => !EqualsDefaultValue(element.RES_BLD_HVACRID)).ToArray()
			group el_HVACR by new 
			{ 
				el_HVACR.RES_BLD_HVACRID,

			}
			into gfunct_HVACR
			select new L5BL_GBIfBI_1159_HVACR
			{     
				RES_BLD_HVACRID = gfunct_HVACR.Key.RES_BLD_HVACRID ,
				RES_BLD_HVACR_TypeID = gfunct_HVACR.FirstOrDefault().RES_BLD_HVACR_TypeID ,

			}
		).ToArray(),
		Basement = 
		(
			from el_Basement in gfunct_L5BL_GBIfBI_1159.Where(element => !EqualsDefaultValue(element.RES_BLD_BasementID)).ToArray()
			group el_Basement by new 
			{ 
				el_Basement.RES_BLD_BasementID,

			}
			into gfunct_Basement
			select new L5BL_GBIfBI_1159_Basement
			{     
				RES_BLD_Basement_TypeID = gfunct_Basement.FirstOrDefault().RES_BLD_Basement_TypeID ,
				RES_BLD_BasementID = gfunct_Basement.Key.RES_BLD_BasementID ,
				Basement_FloorType = gfunct_Basement.FirstOrDefault().Basement_FloorType ,

			}
		).ToArray(),
		Attic = 
		(
			from el_Attic in gfunct_L5BL_GBIfBI_1159.Where(element => !EqualsDefaultValue(element.RES_BLD_AtticID)).ToArray()
			group el_Attic by new 
			{ 
				el_Attic.RES_BLD_AtticID,

			}
			into gfunct_Attic
			select new L5BL_GBIfBI_1159_Attic
			{     
				RES_BLD_Attic_TypeID = gfunct_Attic.FirstOrDefault().RES_BLD_Attic_TypeID ,
				RES_BLD_AtticID = gfunct_Attic.Key.RES_BLD_AtticID ,

			}
		).ToArray(),
		Staircase = 
		(
			from el_Staircase in gfunct_L5BL_GBIfBI_1159.Where(element => !EqualsDefaultValue(element.RES_BLD_StaircaseID)).ToArray()
			group el_Staircase by new 
			{ 
				el_Staircase.RES_BLD_StaircaseID,

			}
			into gfunct_Staircase
			select new L5BL_GBIfBI_1159_Staircase
			{     
				RES_BLD_Staircase_TypeID = gfunct_Staircase.FirstOrDefault().RES_BLD_Staircase_TypeID ,
				StaircaseSize_Value = gfunct_Staircase.FirstOrDefault().StaircaseSize_Value ,
				StaircaseSize_Unit_RefID = gfunct_Staircase.FirstOrDefault().StaircaseSize_Unit_RefID ,
				RES_BLD_StaircaseID = gfunct_Staircase.Key.RES_BLD_StaircaseID ,

			}
		).ToArray(),
		Roof = 
		(
			from el_Roof in gfunct_L5BL_GBIfBI_1159.Where(element => !EqualsDefaultValue(element.RES_BLD_RoofID)).ToArray()
			group el_Roof by new 
			{ 
				el_Roof.RES_BLD_RoofID,

			}
			into gfunct_Roof
			select new L5BL_GBIfBI_1159_Roof
			{     
				RES_BLD_RoofID = gfunct_Roof.Key.RES_BLD_RoofID ,
				RES_BLD_RoofTypeID = gfunct_Roof.FirstOrDefault().RES_BLD_RoofTypeID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GBIfBI_1159 : FR_Base
	{
		public L5BL_GBIfBI_1159 Result	{ get; set; }

		public FR_L5BL_GBIfBI_1159() : base() {}

		public FR_L5BL_GBIfBI_1159(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BL_GBIfBI_1159 for attribute P_L5BL_GBIfBI_1159
		[DataContract]
		public class P_L5BL_GBIfBI_1159 
		{
			//Standard type parameters
			[DataMember]
			public Guid BuildingID { get; set; } 

		}
		#endregion
		#region SClass L5BL_GBIfBI_1159 for attribute L5BL_GBIfBI_1159
		[DataContract]
		public class L5BL_GBIfBI_1159 
		{
			[DataMember]
			public L5BL_GBIfBI_1159_Apartment[] Apartment { get; set; }
			[DataMember]
			public L5BL_GBIfBI_1159_OutdoorFacility[] OutdoorFacility { get; set; }
			[DataMember]
			public L5BL_GBIfBI_1159_Facade[] Facade { get; set; }
			[DataMember]
			public L5BL_GBIfBI_1159_HVACR[] HVACR { get; set; }
			[DataMember]
			public L5BL_GBIfBI_1159_Basement[] Basement { get; set; }
			[DataMember]
			public L5BL_GBIfBI_1159_Attic[] Attic { get; set; }
			[DataMember]
			public L5BL_GBIfBI_1159_Staircase[] Staircase { get; set; }
			[DataMember]
			public L5BL_GBIfBI_1159_Roof[] Roof { get; set; }

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
			public Guid BuildingRevisionHeader_RefID { get; set; } 
			[DataMember]
			public Guid Building_DocumentationStructure_RefID { get; set; } 
			[DataMember]
			public Guid BuildingType_RefID { get; set; } 
			[DataMember]
			public Guid GarbageContainerType_RefID { get; set; } 
			[DataMember]
			public L3DO_GDfDH_1133[] Images { get; set; } 

		}
		#endregion
		#region SClass L5BL_GBIfBI_1159_Apartment for attribute Apartment
		[DataContract]
		public class L5BL_GBIfBI_1159_Apartment 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Apartment_TypeID { get; set; } 
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

		}
		#endregion
		#region SClass L5BL_GBIfBI_1159_OutdoorFacility for attribute OutdoorFacility
		[DataContract]
		public class L5BL_GBIfBI_1159_OutdoorFacility 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_OutdoorFacilityID { get; set; } 
			[DataMember]
			public int NumberOfRentedGaragePlaces { get; set; } 
			[DataMember]
			public int NumberOfGaragePlaces { get; set; } 
			[DataMember]
			public Guid OutdoorFacility_AccessRoadType { get; set; } 
			[DataMember]
			public Guid OutdoorFacility_FenceType { get; set; } 
			[DataMember]
			public Guid RES_BLD_OutdoorFacility_TypeID { get; set; } 

		}
		#endregion
		#region SClass L5BL_GBIfBI_1159_Facade for attribute Facade
		[DataContract]
		public class L5BL_GBIfBI_1159_Facade 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Facade_TypeID { get; set; } 
			[DataMember]
			public Guid RES_BLD_FacadeID { get; set; } 

		}
		#endregion
		#region SClass L5BL_GBIfBI_1159_HVACR for attribute HVACR
		[DataContract]
		public class L5BL_GBIfBI_1159_HVACR 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_HVACRID { get; set; } 
			[DataMember]
			public Guid RES_BLD_HVACR_TypeID { get; set; } 

		}
		#endregion
		#region SClass L5BL_GBIfBI_1159_Basement for attribute Basement
		[DataContract]
		public class L5BL_GBIfBI_1159_Basement 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Basement_TypeID { get; set; } 
			[DataMember]
			public Guid RES_BLD_BasementID { get; set; } 
			[DataMember]
			public Guid Basement_FloorType { get; set; } 

		}
		#endregion
		#region SClass L5BL_GBIfBI_1159_Attic for attribute Attic
		[DataContract]
		public class L5BL_GBIfBI_1159_Attic 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Attic_TypeID { get; set; } 
			[DataMember]
			public Guid RES_BLD_AtticID { get; set; } 

		}
		#endregion
		#region SClass L5BL_GBIfBI_1159_Staircase for attribute Staircase
		[DataContract]
		public class L5BL_GBIfBI_1159_Staircase 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Staircase_TypeID { get; set; } 
			[DataMember]
			public double StaircaseSize_Value { get; set; } 
			[DataMember]
			public Guid StaircaseSize_Unit_RefID { get; set; } 
			[DataMember]
			public Guid RES_BLD_StaircaseID { get; set; } 

		}
		#endregion
		#region SClass L5BL_GBIfBI_1159_Roof for attribute Roof
		[DataContract]
		public class L5BL_GBIfBI_1159_Roof 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_RoofID { get; set; } 
			[DataMember]
			public Guid RES_BLD_RoofTypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GBIfBI_1159 cls_Get_BuildingInfo_for_Building_ID(P_L5BL_GBIfBI_1159 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5BL_GBIfBI_1159 result = cls_Get_BuildingInfo_for_Building_ID.Invoke(connectionString,P_L5BL_GBIfBI_1159 Parameter,securityTicket);
	 return result;
}
*/