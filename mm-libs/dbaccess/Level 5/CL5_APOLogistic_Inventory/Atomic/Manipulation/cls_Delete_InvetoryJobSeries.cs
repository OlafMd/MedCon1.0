/* 
 * Generated on 6/6/2014 10:52:52 AM
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
using CL1_LOG_WRH_INJ;

namespace CL5_APOLogistic_Inventory.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_InvetoryJobSeries.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_InvetoryJobSeries
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5IN_DIJS_1052 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            //Put your code here

            //load InvetoryJob
            var inventoryJob = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Series();
            inventoryJob.Load(Connection, Transaction, Parameter.InventoryJobSeriesID);

            //delete invetory Participating Shelves
            var invetoryParticipatingShelves = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelf.Query.SoftDelete(
                Connection,
                Transaction,
                new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelf.Query
                {
                    LOG_WRH_INJ_InventoryJob_Series_RefID = inventoryJob.LOG_WRH_INJ_InventoryJob_SeriesID,
                    Tenant_RefID = securityTicket.TenantID
                });

            //delete inventoryJobSeriesRythms
            var inventoryJobSeriesRythms = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Series_Rythm.Query.SoftDelete(
                Connection,
                Transaction,
                new ORM_LOG_WRH_INJ_InventoryJob_Series_Rythm.Query
                {
                    InventoryJob_Series_RefID = inventoryJob.LOG_WRH_INJ_InventoryJob_SeriesID,
                    Tenant_RefID = securityTicket.TenantID
                });

            //delete invetory job
            inventoryJob.IsDeleted = true;
            inventoryJob.Save(Connection, Transaction);

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5IN_DIJS_1052 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5IN_DIJS_1052 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IN_DIJS_1052 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IN_DIJS_1052 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_InvetoryJobSeries",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5IN_DIJS_1052 for attribute P_L5IN_DIJS_1052
		[DataContract]
		public class P_L5IN_DIJS_1052 
		{
			//Standard type parameters
			[DataMember]
			public Guid InventoryJobSeriesID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_InvetoryJobSeries(,P_L5IN_DIJS_1052 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_InvetoryJobSeries.Invoke(connectionString,P_L5IN_DIJS_1052 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Atomic.Manipulation.P_L5IN_DIJS_1052();
parameter.InventoryJobSeriesID = ...;

*/
