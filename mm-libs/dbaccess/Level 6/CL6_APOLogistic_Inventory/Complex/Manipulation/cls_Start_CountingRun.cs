/* 
 * Generated on 4/1/2014 2:34:45 PM
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
using CL5_APOLogistic_Inventory.Atomic.Retrieval;
using CL1_LOG_WRH;

namespace CL6_APOLogistic_Inventory.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Start_CountingRun.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Start_CountingRun
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6IN_SCR_1430 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            var paramShelves = new CL5_APOLogistic_Inventory.Atomic.Retrieval.P_L5IN_GSCwQfIJP_1023();
            paramShelves.ProcessID = Parameter.InventoryJob_Process_RefID;
            var shelves = CL5_APOLogistic_Inventory.Atomic.Retrieval.cls_Get_ShelfContent_with_Quantity_for_InventoryJob_ProcessID.Invoke(Connection, Transaction, paramShelves, securityTicket).Result;

            ORM_LOG_WRH_INJ_InventoryJob_CountingRun countingRun = new ORM_LOG_WRH_INJ_InventoryJob_CountingRun();
            countingRun.Load(Connection, Transaction, Parameter.LOG_WRH_INJ_InventoryJob_CountingRunID);
            countingRun.IsCounting_Started = true;
            countingRun.Save(Connection, Transaction);

            ORM_LOG_WRH_INJ_InventoryJob_Process_ShelfContent processShelfContent = null;
            ORM_LOG_WRH_INJ_Process_ShelfContents_TrackingInstance processShelfContentsTrackingInstance = null;


            foreach (var itemShelfContentID in shelves.Select(x => x.LOG_WRH_Shelf_ContentID).Distinct())
            {
                var shelfContent = shelves.Single(x => x.LOG_WRH_Shelf_ContentID == itemShelfContentID);
                ORM_LOG_WRH_Shelf_Content shelfContentOrm = new ORM_LOG_WRH_Shelf_Content();
                shelfContentOrm.Load(Connection, Transaction, itemShelfContentID);
                shelfContentOrm.IsLocked = true;
                shelfContentOrm.Save(Connection, Transaction);

                processShelfContent = new ORM_LOG_WRH_INJ_InventoryJob_Process_ShelfContent();
                processShelfContent.LOG_WRH_INJ_InventoryJob_Process_ShelfContentID = Guid.NewGuid();
                processShelfContent.LOG_WRH_INJ_InventoryJob_Process_Shelf_RefID = shelfContent.LOG_WRH_INJ_InventoryJob_Process_ShelfID;
                processShelfContent.LOG_WRH_Shelf_Content_RefID = shelfContent.LOG_WRH_Shelf_ContentID;
                processShelfContent.ExpectedQuantityOnShelfContent = shelfContent.ShelfContent_Quantity;
                processShelfContent.Tenant_RefID = securityTicket.TenantID;
                processShelfContent.Creation_Timestamp = DateTime.Now;
                processShelfContent.Save(Connection, Transaction);

                foreach (var ti in shelves.Where(x => x.LOG_WRH_Shelf_ContentID == itemShelfContentID))
                {
                    processShelfContentsTrackingInstance = new ORM_LOG_WRH_INJ_Process_ShelfContents_TrackingInstance();
                    processShelfContentsTrackingInstance.ExpectedQuantityOnTrackingInstance = ti.TrackingInstance_Quantity;
                    processShelfContentsTrackingInstance.LOG_ProductTrackingInstance_RefID = ti.LOG_ProductTrackingInstanceID;
                    processShelfContentsTrackingInstance.LOG_WRH_INJ_Process_ShelfContents_TrackingInstanceID = Guid.NewGuid();
                    processShelfContentsTrackingInstance.LOG_WRH_INJ_InventoryJob_Process_ShelfContent_RefID = processShelfContent.LOG_WRH_INJ_InventoryJob_Process_ShelfContentID;
                    processShelfContentsTrackingInstance.Tenant_RefID = securityTicket.TenantID;
                    processShelfContentsTrackingInstance.Creation_Timestamp = DateTime.Now;
                    processShelfContentsTrackingInstance.Save(Connection, Transaction);
                }
            }

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6IN_SCR_1430 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6IN_SCR_1430 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6IN_SCR_1430 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6IN_SCR_1430 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Start_CountingRun",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6IN_SCR_1430 for attribute P_L6IN_SCR_1430
		[DataContract]
		public class P_L6IN_SCR_1430 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_CountingRunID { get; set; } 
			[DataMember]
			public Guid InventoryJob_Process_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Start_CountingRun(,P_L6IN_SCR_1430 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Start_CountingRun.Invoke(connectionString,P_L6IN_SCR_1430 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_Inventory.Complex.Manipulation.P_L6IN_SCR_1430();
parameter.LOG_WRH_INJ_InventoryJob_CountingRunID = ...;
parameter.InventoryJob_Process_RefID = ...;

*/
