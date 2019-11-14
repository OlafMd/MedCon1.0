/* 
 * Generated on 7/23/2013 10:26:58 AM
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
    /// var result = cls_Get_Buildings_For_RealestatePropertyID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Buildings_For_RealestatePropertyID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BD_GBFRP_1436_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_GBFRP_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5BD_GBFRP_1436_Array();

            List<L5BD_GBFRP_1436> resultList = new List<L5BD_GBFRP_1436>();

            List<ORM_RES_BLD_Building> builidingList = new List<ORM_RES_BLD_Building>();

            ORM_RES_BLD_Building_RevisionHeader.Query rhQuery=new ORM_RES_BLD_Building_RevisionHeader.Query();
            rhQuery.IsDeleted = false;
            rhQuery.Tenant_RefID = securityTicket.TenantID;
            rhQuery.RealestateProperty_RefID = Parameter.RealestatePropertyID;
            List<ORM_RES_BLD_Building_RevisionHeader> revisionHeaderList = ORM_RES_BLD_Building_RevisionHeader.Query.Search(Connection, Transaction, rhQuery);
            foreach (var revisionHeader in revisionHeaderList)
            {
                ORM_RES_BLD_Building bdQuery = new ORM_RES_BLD_Building();
                L5BD_GBFRP_1436 item = new L5BD_GBFRP_1436();

                ORM_RES_BLD_Building building = new ORM_RES_BLD_Building();
                building.Load(Connection, Transaction, revisionHeader.CurrentBuildingVersion_RefID);

                ORM_RES_BLD_Apartment.Query apQuery = new ORM_RES_BLD_Apartment.Query();
                apQuery.Tenant_RefID = securityTicket.TenantID;
                apQuery.IsDeleted = false;
                apQuery.Building_RefID = building.RES_BLD_BuildingID;
                item.appartmentCount = ORM_RES_BLD_Apartment.Query.Search(Connection, Transaction, apQuery).ToArray().Length;

                ORM_RES_BLD_Attic.Query atQuery = new ORM_RES_BLD_Attic.Query();
                atQuery.Tenant_RefID = securityTicket.TenantID;
                atQuery.IsDeleted = false;
                atQuery.Building_RefID = building.RES_BLD_BuildingID;
                item.atticsCount = ORM_RES_BLD_Attic.Query.Search(Connection, Transaction, atQuery).ToArray().Length;

                ORM_RES_BLD_Basement.Query baQuery = new ORM_RES_BLD_Basement.Query();
                baQuery.Tenant_RefID = securityTicket.TenantID;
                baQuery.IsDeleted = false;
                baQuery.Building_RefID = building.RES_BLD_BuildingID;
                item.basementsCount = ORM_RES_BLD_Basement.Query.Search(Connection, Transaction, baQuery).ToArray().Length;

                ORM_RES_BLD_Facade.Query faQuery = new ORM_RES_BLD_Facade.Query();
                faQuery.Tenant_RefID = securityTicket.TenantID;
                faQuery.IsDeleted = false;
                faQuery.Building_RefID = building.RES_BLD_BuildingID;
                item.facadesCount = ORM_RES_BLD_Facade.Query.Search(Connection, Transaction, faQuery).ToArray().Length;

                ORM_RES_BLD_HVACR.Query hvQuery = new ORM_RES_BLD_HVACR.Query();
                hvQuery.Tenant_RefID = securityTicket.TenantID;
                hvQuery.IsDeleted = false;
                hvQuery.Building_RefID = building.RES_BLD_BuildingID;
                item.hvarcsCount = ORM_RES_BLD_HVACR.Query.Search(Connection, Transaction, hvQuery).ToArray().Length;

                ORM_RES_BLD_OutdoorFacility.Query ofQuery = new ORM_RES_BLD_OutdoorFacility.Query();
                ofQuery.Tenant_RefID = securityTicket.TenantID;
                ofQuery.IsDeleted = false;
                ofQuery.Building_RefID = building.RES_BLD_BuildingID;
                item.outdoorfacilitiesCount = ORM_RES_BLD_OutdoorFacility.Query.Search(Connection, Transaction, ofQuery).ToArray().Length;

                ORM_RES_BLD_Roof.Query roQuery = new ORM_RES_BLD_Roof.Query();
                roQuery.Tenant_RefID = securityTicket.TenantID;
                roQuery.IsDeleted = false;
                roQuery.Building_RefID = building.RES_BLD_BuildingID;
                item.roofCount = ORM_RES_BLD_Roof.Query.Search(Connection, Transaction, roQuery).ToArray().Length;

                ORM_RES_BLD_Staircase.Query stQuery = new ORM_RES_BLD_Staircase.Query();
                stQuery.Tenant_RefID = securityTicket.TenantID;
                stQuery.IsDeleted = false;
                stQuery.Building_RefID = building.RES_BLD_BuildingID;
                item.staircasesCount = ORM_RES_BLD_Staircase.Query.Search(Connection, Transaction, stQuery).ToArray().Length;

                item.Building_Name = building.Building_Name;
                item.RES_BLD_BuildingID = building.RES_BLD_BuildingID;
                resultList.Add(item);

            }

            returnValue.Result = resultList.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BD_GBFRP_1436_Array Invoke(string ConnectionString,P_L5BD_GBFRP_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BD_GBFRP_1436_Array Invoke(DbConnection Connection,P_L5BD_GBFRP_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BD_GBFRP_1436_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_GBFRP_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BD_GBFRP_1436_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_GBFRP_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BD_GBFRP_1436_Array functionReturn = new FR_L5BD_GBFRP_1436_Array();
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

				throw new Exception("Exception occured in method cls_Get_Buildings_For_RealestatePropertyID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BD_GBFRP_1436_Array : FR_Base
	{
		public L5BD_GBFRP_1436[] Result	{ get; set; } 
		public FR_L5BD_GBFRP_1436_Array() : base() {}

		public FR_L5BD_GBFRP_1436_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BD_GBFRP_1436 for attribute P_L5BD_GBFRP_1436
		[DataContract]
		public class P_L5BD_GBFRP_1436 
		{
			//Standard type parameters
			[DataMember]
			public Guid RealestatePropertyID { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRP_1436 for attribute L5BD_GBFRP_1436
		[DataContract]
		public class L5BD_GBFRP_1436 
		{
			//Standard type parameters
			[DataMember]
			public String Building_Name { get; set; } 
			[DataMember]
			public Guid RES_BLD_BuildingID { get; set; } 
			[DataMember]
			public int appartmentCount { get; set; } 
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
FR_L5BD_GBFRP_1436_Array cls_Get_Buildings_For_RealestatePropertyID(,P_L5BD_GBFRP_1436 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BD_GBFRP_1436_Array invocationResult = cls_Get_Buildings_For_RealestatePropertyID.Invoke(connectionString,P_L5BD_GBFRP_1436 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_Buildings.Complex.Retrieval.P_L5BD_GBFRP_1436();
parameter.RealestatePropertyID = ...;

*/