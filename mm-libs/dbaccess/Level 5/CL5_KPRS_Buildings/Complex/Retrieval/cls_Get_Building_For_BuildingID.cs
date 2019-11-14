/* 
 * Generated on 7/23/2013 10:04:44 AM
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

namespace CL5_KPRS_Buildings.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Building_For_BuildingID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Building_For_BuildingID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BD_GBFB_1408 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_GBFB_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5BD_GBFB_1408();

            returnValue.Result = new L5BD_GBFB_1408();

            ORM_RES_BLD_Building building = new ORM_RES_BLD_Building();
            building.Load(Connection, Transaction, Parameter.BuildingID);

            returnValue.Result.Building_BalconyPortionPercent = building.Building_BalconyPortionPercent;
            returnValue.Result.Building_DocumentationStructure_RefID = building.Building_DocumentationStructure_RefID;
            returnValue.Result.Building_ElevatorCoveragePercent = building.Building_ElevatorCoveragePercent;
            returnValue.Result.Building_Name = building.Building_Name;
            returnValue.Result.Building_NumberOfAppartments = building.Building_NumberOfAppartments;
            returnValue.Result.Building_NumberOfFloors = building.Building_NumberOfFloors;
            returnValue.Result.Building_NumberOfOccupiedAppartments = building.Building_NumberOfOccupiedAppartments;
            returnValue.Result.Building_NumberOfOffices = building.Building_NumberOfOffices;
            returnValue.Result.Building_NumberOfOtherUnits = building.Building_NumberOfOtherUnits;
            returnValue.Result.Building_NumberOfProductionUnits = building.Building_NumberOfProductionUnits;
            returnValue.Result.Building_NumberOfRetailUnits = building.Building_NumberOfRetailUnits;
            returnValue.Result.IsContaminationSuspected = building.IsContaminationSuspected ;
            returnValue.Result.RES_BLD_BuildingID = building.RES_BLD_BuildingID;


            ORM_RES_BLD_Apartment.Query apQuery = new ORM_RES_BLD_Apartment.Query();
            apQuery.Tenant_RefID = securityTicket.TenantID;
            apQuery.IsDeleted = false;
            apQuery.Building_RefID = building.RES_BLD_BuildingID;
            returnValue.Result.AppartmentCount = ORM_RES_BLD_Apartment.Query.Search(Connection, Transaction, apQuery).ToArray().Length;

            ORM_RES_BLD_Attic.Query atQuery = new ORM_RES_BLD_Attic.Query();
            atQuery.Tenant_RefID = securityTicket.TenantID;
            atQuery.IsDeleted = false;
            atQuery.Building_RefID = building.RES_BLD_BuildingID;
            returnValue.Result.atticsCount = ORM_RES_BLD_Attic.Query.Search(Connection, Transaction, atQuery).ToArray().Length;

            ORM_RES_BLD_Basement.Query baQuery = new ORM_RES_BLD_Basement.Query();
            baQuery.Tenant_RefID = securityTicket.TenantID;
            baQuery.IsDeleted = false;
            baQuery.Building_RefID = building.RES_BLD_BuildingID;
            returnValue.Result.basementsCount = ORM_RES_BLD_Basement.Query.Search(Connection, Transaction, baQuery).ToArray().Length;

            ORM_RES_BLD_Facade.Query faQuery = new ORM_RES_BLD_Facade.Query();
            faQuery.Tenant_RefID = securityTicket.TenantID;
            faQuery.IsDeleted = false;
            faQuery.Building_RefID = building.RES_BLD_BuildingID;
            returnValue.Result.facadesCount = ORM_RES_BLD_Facade.Query.Search(Connection, Transaction, faQuery).ToArray().Length;

            ORM_RES_BLD_HVACR.Query hvQuery = new ORM_RES_BLD_HVACR.Query();
            hvQuery.Tenant_RefID = securityTicket.TenantID;
            hvQuery.IsDeleted = false;
            hvQuery.Building_RefID = building.RES_BLD_BuildingID;
            returnValue.Result.hvarcsCount = ORM_RES_BLD_HVACR.Query.Search(Connection, Transaction, hvQuery).ToArray().Length;

            ORM_RES_BLD_OutdoorFacility.Query ofQuery = new ORM_RES_BLD_OutdoorFacility.Query();
            ofQuery.Tenant_RefID = securityTicket.TenantID;
            ofQuery.IsDeleted = false;
            ofQuery.Building_RefID = building.RES_BLD_BuildingID;
            returnValue.Result.outdoorfacilitiesCount = ORM_RES_BLD_OutdoorFacility.Query.Search(Connection, Transaction, ofQuery).ToArray().Length;

            ORM_RES_BLD_Roof.Query roQuery = new ORM_RES_BLD_Roof.Query();
            roQuery.Tenant_RefID = securityTicket.TenantID;
            roQuery.IsDeleted = false;
            roQuery.Building_RefID = building.RES_BLD_BuildingID;
            returnValue.Result.roofCount = ORM_RES_BLD_Roof.Query.Search(Connection, Transaction, roQuery).ToArray().Length;

            ORM_RES_BLD_Staircase.Query stQuery = new ORM_RES_BLD_Staircase.Query();
            stQuery.Tenant_RefID = securityTicket.TenantID;
            stQuery.IsDeleted = false;
            stQuery.Building_RefID = building.RES_BLD_BuildingID;
            returnValue.Result.staircasesCount = ORM_RES_BLD_Staircase.Query.Search(Connection, Transaction, stQuery).ToArray().Length;

            ORM_RES_BLD_Building_2_GarbageContainerType.Query gctQuery = new ORM_RES_BLD_Building_2_GarbageContainerType.Query();
            gctQuery.Tenant_RefID = securityTicket.TenantID;
            gctQuery.IsDeleted = false;
            gctQuery.RES_BLD_Building_RefID = building.RES_BLD_BuildingID;
            List<ORM_RES_BLD_Building_2_GarbageContainerType> garbageContainerType = ORM_RES_BLD_Building_2_GarbageContainerType.Query.Search(Connection, Transaction, gctQuery);
            returnValue.Result.RES_BLD_GarbageContainerTypeID = garbageContainerType[0].RES_BLD_GarbageContainerType_RefID;

            ORM_RES_BLD_Building_2_BuildingType.Query bdQuery = new ORM_RES_BLD_Building_2_BuildingType.Query();
            bdQuery.Tenant_RefID = securityTicket.TenantID;
            bdQuery.IsDeleted = false;
            bdQuery.RES_BLD_Building_RefID = building.RES_BLD_BuildingID;
            List<ORM_RES_BLD_Building_2_BuildingType> buildingType = ORM_RES_BLD_Building_2_BuildingType.Query.Search(Connection, Transaction, bdQuery);
            returnValue.Result.RES_BLD_Building_TypeID = buildingType[0].RES_BLD_Building_Type_RefID;
            
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BD_GBFB_1408 Invoke(string ConnectionString,P_L5BD_GBFB_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BD_GBFB_1408 Invoke(DbConnection Connection,P_L5BD_GBFB_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BD_GBFB_1408 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_GBFB_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BD_GBFB_1408 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_GBFB_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BD_GBFB_1408 functionReturn = new FR_L5BD_GBFB_1408();
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

				throw new Exception("Exception occured in method cls_Get_Building_For_BuildingID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BD_GBFB_1408 : FR_Base
	{
		public L5BD_GBFB_1408 Result	{ get; set; }

		public FR_L5BD_GBFB_1408() : base() {}

		public FR_L5BD_GBFB_1408(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BD_GBFB_1408 for attribute P_L5BD_GBFB_1408
		[DataContract]
		public class P_L5BD_GBFB_1408 
		{
			//Standard type parameters
			[DataMember]
			public Guid BuildingID { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFB_1408 for attribute L5BD_GBFB_1408
		[DataContract]
		public class L5BD_GBFB_1408 
		{
			//Standard type parameters
			[DataMember]
			public String Building_Name { get; set; } 
			[DataMember]
			public Guid RES_BLD_BuildingID { get; set; } 
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
			public Guid RES_BLD_GarbageContainerTypeID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Building_TypeID { get; set; } 
			[DataMember]
			public Guid Building_DocumentationStructure_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BD_GBFB_1408 cls_Get_Building_For_BuildingID(,P_L5BD_GBFB_1408 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BD_GBFB_1408 invocationResult = cls_Get_Building_For_BuildingID.Invoke(connectionString,P_L5BD_GBFB_1408 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_Buildings.Complex.Retrieval.P_L5BD_GBFB_1408();
parameter.BuildingID = ...;

*/