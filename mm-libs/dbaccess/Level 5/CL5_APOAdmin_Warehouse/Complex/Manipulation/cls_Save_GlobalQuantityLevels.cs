/* 
 * Generated on 09/11/2014 11:59:06
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_LOG_WRH;

namespace CL5_APOAdmin_Warehouse.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_GlobalQuantityLevels.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_GlobalQuantityLevels
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5WH_SGQL_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();
			//Put your code here

            returnValue.Result = false;
            ORM_LOG_WRH_QuantityLevel quantityLevel = null;
            
            if (Parameter.LOG_WRH_QuantityLevelID != Guid.Empty)
            quantityLevel = ORM_LOG_WRH_QuantityLevel.Query.Search(Connection, Transaction, new ORM_LOG_WRH_QuantityLevel.Query
            {
                IsDeleted = false,
                LOG_WRH_QuantityLevelID = Parameter.LOG_WRH_QuantityLevelID,
                Tenant_RefID = securityTicket.TenantID
            }).SingleOrDefault();

            if (quantityLevel != null)
            {
                quantityLevel.Quantity_Minimum = Parameter.Quantity_Minimum;
                quantityLevel.Save(Connection, Transaction);
                
            }
            else
            {
                quantityLevel = new ORM_LOG_WRH_QuantityLevel();
                quantityLevel.LOG_WRH_QuantityLevelID = Guid.NewGuid();
                quantityLevel.Tenant_RefID = securityTicket.TenantID;
                quantityLevel.Quantity_Minimum = Parameter.Quantity_Minimum;
                quantityLevel.Save(Connection, Transaction);
            }

            var currentWareHouse = ORM_LOG_WRH_Warehouse.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Warehouse.Query
            {
                IsDeleted = false,
                LOG_WRH_WarehouseID = Parameter.LOG_WRH_WarehouseID,
                Tenant_RefID = securityTicket.TenantID
            }).SingleOrDefault();


            ORM_LOG_WRH_Warehouse_2_QuantityLevel WareHouseToQuantityLevels = null;

            if (Parameter.AssignmentID != Guid.Empty)
            {
                WareHouseToQuantityLevels = ORM_LOG_WRH_Warehouse_2_QuantityLevel.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Warehouse_2_QuantityLevel.Query
                {
                    AssignmentID = Parameter.AssignmentID
                }).Single();
            }

            if (WareHouseToQuantityLevels == null || Parameter.AssignmentID == Guid.Empty)
            {
                WareHouseToQuantityLevels = new ORM_LOG_WRH_Warehouse_2_QuantityLevel();
                WareHouseToQuantityLevels.AssignmentID = Guid.NewGuid();
                WareHouseToQuantityLevels.LOG_WRH_QuantityLevel_RefID = quantityLevel.LOG_WRH_QuantityLevelID;
                WareHouseToQuantityLevels.LOG_WRH_Warehouse_RefID = currentWareHouse.LOG_WRH_WarehouseID;
                WareHouseToQuantityLevels.Tenant_RefID = securityTicket.TenantID;
                WareHouseToQuantityLevels.Save(Connection, Transaction);
            }


            returnValue.Result = true;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5WH_SGQL_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5WH_SGQL_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WH_SGQL_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WH_SGQL_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Save_GlobalQuantityLevels",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5WH_SGQL_1335 for attribute P_L5WH_SGQL_1335
		[DataContract]
		public class P_L5WH_SGQL_1335 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_WarehouseID { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_QuantityLevelID { get; set; } 
			[DataMember]
			public Double Quantity_Minimum { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_GlobalQuantityLevels(,P_L5WH_SGQL_1335 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_GlobalQuantityLevels.Invoke(connectionString,P_L5WH_SGQL_1335 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Warehouse.Complex.Manipulation.P_L5WH_SGQL_1335();
parameter.LOG_WRH_WarehouseID = ...;
parameter.AssignmentID = ...;
parameter.LOG_WRH_QuantityLevelID = ...;
parameter.Quantity_Minimum = ...;

*/
