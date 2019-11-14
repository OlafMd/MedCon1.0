/* 
 * Generated on 11/5/2013 2:49:14 PM
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

namespace CL5_KPRS_StaticProperties.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_BuildingPartTypes_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_BuildingPartTypes_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SP_GABPTFT_1244 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5SP_GABPTFT_1244();

			//Put your code here
            returnValue.Result = new L5SP_GABPTFT_1244();

            #region Apartment_Types
            //Apartment_Types
            ORM_RES_BLD_Apartment_Type.Query apartment_TypeQuery = new ORM_RES_BLD_Apartment_Type.Query();
            apartment_TypeQuery.Tenant_RefID = securityTicket.TenantID;
            apartment_TypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_Apartment_Type> apartment_TypeList = ORM_RES_BLD_Apartment_Type.Query.Search(Connection, Transaction, apartment_TypeQuery);
            List<L5SP_GABPTFT_1244_Apartment_Types> apartment_Types = new List<L5SP_GABPTFT_1244_Apartment_Types>();
            foreach (var apartment_Type in apartment_TypeList)
            {
                L5SP_GABPTFT_1244_Apartment_Types item = new L5SP_GABPTFT_1244_Apartment_Types();
                item.RES_BLD_Apartment_TypeID = apartment_Type.RES_BLD_Apartment_TypeID;
                item.Name = apartment_Type.ApartmentType_Name;
                item.Description = apartment_Type.ApartmentType_Description;
                apartment_Types.Add(item);
            }
            returnValue.Result.Apartment_Types = apartment_Types.ToArray();
            #endregion

            #region Appartment_HeatingTypes
            //Appartment_HeatingTypes
            ORM_RES_BLD_Appartment_HeatingType.Query apartment_HeatingTypeQuery = new ORM_RES_BLD_Appartment_HeatingType.Query();
            apartment_HeatingTypeQuery.Tenant_RefID = securityTicket.TenantID;
            apartment_HeatingTypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_Appartment_HeatingType> apartment_HeatingTypeList = ORM_RES_BLD_Appartment_HeatingType.Query.Search(Connection, Transaction, apartment_HeatingTypeQuery);
            List<L5SP_GABPTFT_1244_Appartment_HeatingTypes> apartment_HeatingTypes = new List<L5SP_GABPTFT_1244_Appartment_HeatingTypes>();
            foreach (var apartment_HeatingType in apartment_HeatingTypeList)
            {
                L5SP_GABPTFT_1244_Appartment_HeatingTypes item = new L5SP_GABPTFT_1244_Appartment_HeatingTypes();
                item.RES_BLD_Appartment_HeatingTypeID = apartment_HeatingType.RES_BLD_Appartment_HeatingTypeID;
                item.Name = apartment_HeatingType.HeatingType_Name;
                item.GlobalPropertyMatchingID = apartment_HeatingType.GlobalPropertyMatchingID;
                apartment_HeatingTypes.Add(item);
            }
            returnValue.Result.Appartment_HeatingTypes = apartment_HeatingTypes.ToArray();
            #endregion

            #region Appartment_FlooringTypes
            //Appartment_FlooringTypes
            ORM_RES_BLD_Appartment_FlooringType.Query apartment_FlooringTypeQuery = new ORM_RES_BLD_Appartment_FlooringType.Query();
            apartment_FlooringTypeQuery.Tenant_RefID = securityTicket.TenantID;
            apartment_FlooringTypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_Appartment_FlooringType> apartment_FlooringTypeList = ORM_RES_BLD_Appartment_FlooringType.Query.Search(Connection, Transaction, apartment_FlooringTypeQuery);
            List<L5SP_GABPTFT_1244_Appartment_FlooringTypes> apartment_FlooringTypes = new List<L5SP_GABPTFT_1244_Appartment_FlooringTypes>();
            foreach (var apartment_FlooringType in apartment_FlooringTypeList)
            {
                L5SP_GABPTFT_1244_Appartment_FlooringTypes item = new L5SP_GABPTFT_1244_Appartment_FlooringTypes();
                item.RES_BLD_Appartment_FlooringTypesID = apartment_FlooringType.RES_BLD_Appartment_FlooringTypesID;
                item.Name = apartment_FlooringType.FlooringType_Name;
                item.GlobalPropertyMatchingID = apartment_FlooringType.GlobalPropertyMatchingID;
                apartment_FlooringTypes.Add(item);
            }
            returnValue.Result.Appartment_FlooringTypes = apartment_FlooringTypes.ToArray();
            #endregion

            #region Appartment_WallCoveringTypes
            //Appartment_WallCoveringTypes
            ORM_RES_BLD_Appartment_WallCoveringType.Query apartment_WallCoveringTypeQuery = new ORM_RES_BLD_Appartment_WallCoveringType.Query();
            apartment_WallCoveringTypeQuery.Tenant_RefID = securityTicket.TenantID;
            apartment_WallCoveringTypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_Appartment_WallCoveringType> apartment_WallCoveringTypeList = ORM_RES_BLD_Appartment_WallCoveringType.Query.Search(Connection, Transaction, apartment_WallCoveringTypeQuery);
            List<L5SP_GABPTFT_1244_Appartment_WallCoveringTypes> apartment_WallCoveringTypes = new List<L5SP_GABPTFT_1244_Appartment_WallCoveringTypes>();
            foreach (var apartment_WallCoveringType in apartment_WallCoveringTypeList)
            {
                L5SP_GABPTFT_1244_Appartment_WallCoveringTypes item = new L5SP_GABPTFT_1244_Appartment_WallCoveringTypes();
                item.RES_BLD_Appartment_WallCoveringTypeID = apartment_WallCoveringType.RES_BLD_Appartment_WallCoveringTypeID;
                item.Name = apartment_WallCoveringType.WallCoveringType_Name;
                item.GlobalPropertyMatchingID = apartment_WallCoveringType.GlobalPropertyMatchingID;
                apartment_WallCoveringTypes.Add(item);
            }
            returnValue.Result.Appartment_WallCoveringTypes = apartment_WallCoveringTypes.ToArray();
            #endregion

            #region OutdoorFacility_Types
            //OutdoorFacility_Types
            ORM_RES_BLD_OutdoorFacility_Type.Query outdoorFacility_TypeQuery = new ORM_RES_BLD_OutdoorFacility_Type.Query();
            outdoorFacility_TypeQuery.Tenant_RefID = securityTicket.TenantID;
            outdoorFacility_TypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_OutdoorFacility_Type> outdoorFacility_TypeList = ORM_RES_BLD_OutdoorFacility_Type.Query.Search(Connection,Transaction, outdoorFacility_TypeQuery);
            List<L5SP_GABPTFT_1244_OutdoorFacility_Types> outdoorFacility_Types = new List<L5SP_GABPTFT_1244_OutdoorFacility_Types>();
            foreach (var outdoorFacility_Type in outdoorFacility_TypeList)
            {
                L5SP_GABPTFT_1244_OutdoorFacility_Types item = new L5SP_GABPTFT_1244_OutdoorFacility_Types();
                item.RES_BLD_OutdoorFacility_TypeID = outdoorFacility_Type.RES_BLD_OutdoorFacility_TypeID;
                item.Name = outdoorFacility_Type.OutdoorFacilityType_Name;
                item.Description = outdoorFacility_Type.OutdoorFacilityType_Description;
                outdoorFacility_Types.Add(item);
            }
            returnValue.Result.OutdoorFacility_Types = outdoorFacility_Types.ToArray();
            #endregion

            #region OutdoorFacility_AccessRoadTypes
            //OutdoorFacility_AccessRoadTypes
            ORM_RES_BLD_OutdoorFacility_AccessRoadType.Query outdoorFacility_AccessRoadTypeQuery = new ORM_RES_BLD_OutdoorFacility_AccessRoadType.Query();
            outdoorFacility_AccessRoadTypeQuery.Tenant_RefID = securityTicket.TenantID;
            outdoorFacility_AccessRoadTypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_OutdoorFacility_AccessRoadType> outdoorFacility_AccessRoadTypeList = ORM_RES_BLD_OutdoorFacility_AccessRoadType.Query.Search(Connection, Transaction, outdoorFacility_AccessRoadTypeQuery);
            List<L5SP_GABPTFT_1244_OutdoorFacility_AccessRoadTypes> outdoorFacility_AccessRoadTypes = new List<L5SP_GABPTFT_1244_OutdoorFacility_AccessRoadTypes>();
            foreach (var outdoorFacility_AccessRoadType in outdoorFacility_AccessRoadTypeList)
            {
                L5SP_GABPTFT_1244_OutdoorFacility_AccessRoadTypes item = new L5SP_GABPTFT_1244_OutdoorFacility_AccessRoadTypes();
                item.RES_BLD_OutdoorFacility_AccessRoadTypeID = outdoorFacility_AccessRoadType.RES_BLD_OutdoorFacility_AccessRoadTypeID;
                item.Name = outdoorFacility_AccessRoadType.AccessRoadType_Name;
                item.GlobalPropertyMatchingID = outdoorFacility_AccessRoadType.GlobalPropertyMatchingID;
                outdoorFacility_AccessRoadTypes.Add(item);
            }
            returnValue.Result.OutdoorFacility_AccessRoadTypes = outdoorFacility_AccessRoadTypes.ToArray();
            #endregion

            #region OutdoorFacility_FenceTypes
            //OutdoorFacility_FenceTypes
            ORM_RES_BLD_OutdoorFacility_FenceType.Query outdoorFacility_FenceTypeQuery = new ORM_RES_BLD_OutdoorFacility_FenceType.Query();
            outdoorFacility_FenceTypeQuery.Tenant_RefID = securityTicket.TenantID;
            outdoorFacility_FenceTypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_OutdoorFacility_FenceType> outdoorFacility_FenceTypeList = ORM_RES_BLD_OutdoorFacility_FenceType.Query.Search(Connection, Transaction, outdoorFacility_FenceTypeQuery);
            List<L5SP_GABPTFT_1244_OutdoorFacility_FenceTypes> outdoorFacility_FenceTypes = new List<L5SP_GABPTFT_1244_OutdoorFacility_FenceTypes>();
            foreach (var outdoorFacility_FenceType in outdoorFacility_FenceTypeList)
            {
                L5SP_GABPTFT_1244_OutdoorFacility_FenceTypes item = new L5SP_GABPTFT_1244_OutdoorFacility_FenceTypes();
                item.RES_BLD_OutdoorFacility_FenceTypeID = outdoorFacility_FenceType.RES_BLD_OutdoorFacility_FenceTypeID;
                item.Name = outdoorFacility_FenceType.FenceType_Name;
                item.GlobalPropertyMatchingID = outdoorFacility_FenceType.GlobalPropertyMatchingID;
                outdoorFacility_FenceTypes.Add(item);
            }
            returnValue.Result.OutdoorFacility_FenceTypes = outdoorFacility_FenceTypes.ToArray();
            #endregion

            #region Basement_Types
            //Basement_Types
            ORM_RES_BLD_Basement_Type.Query basement_TypeQuery = new ORM_RES_BLD_Basement_Type.Query();
            basement_TypeQuery.Tenant_RefID = securityTicket.TenantID;
            basement_TypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_Basement_Type> basement_TypeList = ORM_RES_BLD_Basement_Type.Query.Search(Connection, Transaction, basement_TypeQuery);
            List<L5SP_GABPTFT_1244_Basement_Types> basement_Types = new List<L5SP_GABPTFT_1244_Basement_Types>();
            foreach (var basement_Type in basement_TypeList)
            {
                L5SP_GABPTFT_1244_Basement_Types item = new L5SP_GABPTFT_1244_Basement_Types();
                item.RES_BLD_Basement_TypeID = basement_Type.RES_BLD_Basement_TypeID;
                item.Name = basement_Type.BasementType_Name;
                item.Description = basement_Type.BasementType_Description;
                basement_Types.Add(item);
            }
            returnValue.Result.Basement_Types = basement_Types.ToArray();
            #endregion

            #region Basement_FloorTypes
            //Basement_FloorTypes
            ORM_RES_BLD_Basement_FloorType.Query basement_FloorTypeQuery = new ORM_RES_BLD_Basement_FloorType.Query();
            basement_FloorTypeQuery.Tenant_RefID = securityTicket.TenantID;
            basement_FloorTypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_Basement_FloorType> basement_FloorTypeList = ORM_RES_BLD_Basement_FloorType.Query.Search(Connection, Transaction, basement_FloorTypeQuery);
            List<L5SP_GABPTFT_1244_Basement_FloorTypes> basement_FloorTypes = new List<L5SP_GABPTFT_1244_Basement_FloorTypes>();
            foreach(var basement_FloorType in basement_FloorTypeList)
            {
                L5SP_GABPTFT_1244_Basement_FloorTypes item = new L5SP_GABPTFT_1244_Basement_FloorTypes();
                item.RES_BLD_Basement_FloorTypeID = basement_FloorType.RES_BLD_Basement_FloorTypeID;
                item.Name = basement_FloorType.FloorType_Name;
                item.GlobalPropertyMatchingID = basement_FloorType.GlobalPropertyMatchingID;
                basement_FloorTypes.Add(item);
            }
            returnValue.Result.Basement_FloorTypes = basement_FloorTypes.ToArray();
            #endregion

            #region Attic_Types
            //Attic_Types
            ORM_RES_BLD_Attic_Type.Query attic_TypeQuery = new ORM_RES_BLD_Attic_Type.Query();
            attic_TypeQuery.Tenant_RefID = securityTicket.TenantID;
            attic_TypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_Attic_Type> attic_TypeList = ORM_RES_BLD_Attic_Type.Query.Search(Connection, Transaction, attic_TypeQuery);
            List<L5SP_GABPTFT_1244_Attic_Types> attic_Types = new List<L5SP_GABPTFT_1244_Attic_Types>();
            foreach (var attic_Type in attic_TypeList)
            {
                L5SP_GABPTFT_1244_Attic_Types item = new L5SP_GABPTFT_1244_Attic_Types();
                item.RES_BLD_Attic_TypeID = attic_Type.RES_BLD_Attic_TypeID;
                item.Name = attic_Type.AtticType_Name;
                item.Description = attic_Type.AtticType_Description;
                attic_Types.Add(item);
            }
            returnValue.Result.Attic_Types = attic_Types.ToArray();
            #endregion

            #region Facade_Types
            //Facade_Types
            ORM_RES_BLD_Facade_Type.Query facade_TypeQuery = new ORM_RES_BLD_Facade_Type.Query();
            facade_TypeQuery.Tenant_RefID = securityTicket.TenantID;
            facade_TypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_Facade_Type> facade_TypeList = ORM_RES_BLD_Facade_Type.Query.Search(Connection, Transaction, facade_TypeQuery);
            List<L5SP_GABPTFT_1244_Facade_Types> facade_Types = new List<L5SP_GABPTFT_1244_Facade_Types>();
            foreach (var facade_Type in facade_TypeList)
            {
                L5SP_GABPTFT_1244_Facade_Types item = new L5SP_GABPTFT_1244_Facade_Types();
                item.RES_BLD_Facade_TypeID = facade_Type.RES_BLD_Facade_TypeID;
                item.Name = facade_Type.FacadeType_Name;
                item.Description = facade_Type.FacadeType_Description;
                facade_Types.Add(item);
            }
            returnValue.Result.Facade_Types = facade_Types.ToArray();
            #endregion

            #region RoofType
            //RoofType
            ORM_RES_BLD_RoofType.Query roof_TypeQuery = new ORM_RES_BLD_RoofType.Query();
            roof_TypeQuery.Tenant_RefID = securityTicket.TenantID;
            roof_TypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_RoofType> roof_TypeList = ORM_RES_BLD_RoofType.Query.Search(Connection, Transaction, roof_TypeQuery);
            List<L5SP_GABPTFT_1244_RoofType> roof_Types = new List<L5SP_GABPTFT_1244_RoofType>();
            foreach (var roof_Type in roof_TypeList)
            {
                L5SP_GABPTFT_1244_RoofType item = new L5SP_GABPTFT_1244_RoofType();
                item.RES_BLD_RoofTypeID = roof_Type.RES_BLD_RoofTypeID;
                item.Name = roof_Type.RoofType_Name;
                item.Description = roof_Type.RoofType_Dictionary;
                roof_Types.Add(item);
            }
            returnValue.Result.RoofType = roof_Types.ToArray();
            #endregion

            #region Staircase_Types
            //Staircase_Types
            ORM_RES_BLD_Staircase_Type.Query staircase_TypeQuery = new ORM_RES_BLD_Staircase_Type.Query();
            staircase_TypeQuery.Tenant_RefID = securityTicket.TenantID;
            staircase_TypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_Staircase_Type> staircase_TypeList = ORM_RES_BLD_Staircase_Type.Query.Search(Connection, Transaction, staircase_TypeQuery);
            List<L5SP_GABPTFT_1244_Staircase_Types> staircase_Types = new List<L5SP_GABPTFT_1244_Staircase_Types>();
            foreach (var staircase_Type in staircase_TypeList)
            {
                L5SP_GABPTFT_1244_Staircase_Types item = new L5SP_GABPTFT_1244_Staircase_Types();
                item.RES_BLD_Staircase_TypeID = staircase_Type.RES_BLD_Staircase_TypeID;
                item.Name = staircase_Type.StaircaseType_Name;
                item.Description = staircase_Type.StaircaseType_Description;
                staircase_Types.Add(item);
            }
            returnValue.Result.Staircase_Types = staircase_Types.ToArray();
            #endregion

            #region HVACR_Types
            //HVACR_Types
            ORM_RES_BLD_HVACR_Type.Query hvacr_TypeQuery = new ORM_RES_BLD_HVACR_Type.Query();
            hvacr_TypeQuery.Tenant_RefID = securityTicket.TenantID;
            hvacr_TypeQuery.IsDeleted = false;
            List<ORM_RES_BLD_HVACR_Type> hvacr_TypeList = ORM_RES_BLD_HVACR_Type.Query.Search(Connection, Transaction, hvacr_TypeQuery);
            List<L5SP_GABPTFT_1244_HVACR_Types> hvacr_Types = new List<L5SP_GABPTFT_1244_HVACR_Types>();
            foreach (var hvacr_Type in hvacr_TypeList)
            {
                L5SP_GABPTFT_1244_HVACR_Types item = new L5SP_GABPTFT_1244_HVACR_Types();
                item.RES_BLD_HVACR_TypeID = hvacr_Type.RES_BLD_HVACR_TypeID;
                item.Name = hvacr_Type.HVACRType_Name;
                item.Description = hvacr_Type.HVACRType_Description;
                hvacr_Types.Add(item);
            }
            returnValue.Result.HVACR_Types = hvacr_Types.ToArray();
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SP_GABPTFT_1244 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SP_GABPTFT_1244 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SP_GABPTFT_1244 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SP_GABPTFT_1244 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SP_GABPTFT_1244 functionReturn = new FR_L5SP_GABPTFT_1244();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);


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

	#region Custom Return Type
	[Serializable]
	public class FR_L5SP_GABPTFT_1244 : FR_Base
	{
		public L5SP_GABPTFT_1244 Result	{ get; set; }

		public FR_L5SP_GABPTFT_1244() : base() {}

		public FR_L5SP_GABPTFT_1244(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5SP_GABPTFT_1244 for attribute L5SP_GABPTFT_1244
		[DataContract]
		public class L5SP_GABPTFT_1244 
		{
			[DataMember]
			public L5SP_GABPTFT_1244_Apartment_Types[] Apartment_Types { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_Appartment_HeatingTypes[] Appartment_HeatingTypes { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_Appartment_FlooringTypes[] Appartment_FlooringTypes { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_Appartment_WallCoveringTypes[] Appartment_WallCoveringTypes { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_OutdoorFacility_Types[] OutdoorFacility_Types { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_OutdoorFacility_AccessRoadTypes[] OutdoorFacility_AccessRoadTypes { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_OutdoorFacility_FenceTypes[] OutdoorFacility_FenceTypes { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_Basement_Types[] Basement_Types { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_Basement_FloorTypes[] Basement_FloorTypes { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_Attic_Types[] Attic_Types { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_Facade_Types[] Facade_Types { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_RoofType[] RoofType { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_Staircase_Types[] Staircase_Types { get; set; }
			[DataMember]
			public L5SP_GABPTFT_1244_HVACR_Types[] HVACR_Types { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_Apartment_Types for attribute Apartment_Types
		[DataContract]
		public class L5SP_GABPTFT_1244_Apartment_Types 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Apartment_TypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_Appartment_HeatingTypes for attribute Appartment_HeatingTypes
		[DataContract]
		public class L5SP_GABPTFT_1244_Appartment_HeatingTypes 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Appartment_HeatingTypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_Appartment_FlooringTypes for attribute Appartment_FlooringTypes
		[DataContract]
		public class L5SP_GABPTFT_1244_Appartment_FlooringTypes 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Appartment_FlooringTypesID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_Appartment_WallCoveringTypes for attribute Appartment_WallCoveringTypes
		[DataContract]
		public class L5SP_GABPTFT_1244_Appartment_WallCoveringTypes 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Appartment_WallCoveringTypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_OutdoorFacility_Types for attribute OutdoorFacility_Types
		[DataContract]
		public class L5SP_GABPTFT_1244_OutdoorFacility_Types 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_OutdoorFacility_TypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_OutdoorFacility_AccessRoadTypes for attribute OutdoorFacility_AccessRoadTypes
		[DataContract]
		public class L5SP_GABPTFT_1244_OutdoorFacility_AccessRoadTypes 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_OutdoorFacility_AccessRoadTypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_OutdoorFacility_FenceTypes for attribute OutdoorFacility_FenceTypes
		[DataContract]
		public class L5SP_GABPTFT_1244_OutdoorFacility_FenceTypes 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_OutdoorFacility_FenceTypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_Basement_Types for attribute Basement_Types
		[DataContract]
		public class L5SP_GABPTFT_1244_Basement_Types 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Basement_TypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_Basement_FloorTypes for attribute Basement_FloorTypes
		[DataContract]
		public class L5SP_GABPTFT_1244_Basement_FloorTypes 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Basement_FloorTypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_Attic_Types for attribute Attic_Types
		[DataContract]
		public class L5SP_GABPTFT_1244_Attic_Types 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Attic_TypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_Facade_Types for attribute Facade_Types
		[DataContract]
		public class L5SP_GABPTFT_1244_Facade_Types 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Facade_TypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_RoofType for attribute RoofType
		[DataContract]
		public class L5SP_GABPTFT_1244_RoofType 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_RoofTypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_Staircase_Types for attribute Staircase_Types
		[DataContract]
		public class L5SP_GABPTFT_1244_Staircase_Types 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_Staircase_TypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5SP_GABPTFT_1244_HVACR_Types for attribute HVACR_Types
		[DataContract]
		public class L5SP_GABPTFT_1244_HVACR_Types 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_HVACR_TypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SP_GABPTFT_1244 cls_Get_All_BuildingPartTypes_For_Tenant(string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5SP_GABPTFT_1244 result = cls_Get_All_BuildingPartTypes_For_Tenant.Invoke(connectionString,securityTicket);
	 return result;
}
*/