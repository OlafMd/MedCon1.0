/* 
 * Generated on 17/7/2014 03:54:57
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
    /// var result = cls_Save_InventoryJob_Process_ShelfContent_and_TrackingInstance.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_InventoryJob_Process_ShelfContent_and_TrackingInstance
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5IN_SIJPSCaTI_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();
            returnValue.Result = false;

            //Put your code here
            if (Parameter.InvJobProcessShelfID != null && Parameter.ProductTrackingInstanceID != null && Parameter.ShelfContentID != null)
            {
                var processShelfContent = new ORM_LOG_WRH_INJ_InventoryJob_Process_ShelfContent();
                processShelfContent.LOG_WRH_INJ_InventoryJob_Process_ShelfContentID = Guid.NewGuid();
                processShelfContent.LOG_WRH_INJ_InventoryJob_Process_Shelf_RefID = Parameter.InvJobProcessShelfID;
                processShelfContent.LOG_WRH_Shelf_Content_RefID = Parameter.ShelfContentID;
                processShelfContent.ExpectedQuantityOnShelfContent = Parameter.ShelfExpectedQuantity;
                processShelfContent.Tenant_RefID = securityTicket.TenantID;
                processShelfContent.Creation_Timestamp = DateTime.Now;
                processShelfContent.Save(Connection, Transaction);

                var shelfContentsTrackingInstance = new ORM_LOG_WRH_INJ_Process_ShelfContents_TrackingInstance();
                shelfContentsTrackingInstance.ExpectedQuantityOnTrackingInstance = Parameter.TrackingInstanceExpectedQuantity;
                shelfContentsTrackingInstance.LOG_ProductTrackingInstance_RefID = Parameter.ProductTrackingInstanceID;
                shelfContentsTrackingInstance.LOG_WRH_INJ_Process_ShelfContents_TrackingInstanceID = Guid.NewGuid();
                shelfContentsTrackingInstance.LOG_WRH_INJ_InventoryJob_Process_ShelfContent_RefID = processShelfContent.LOG_WRH_INJ_InventoryJob_Process_ShelfContentID;
                shelfContentsTrackingInstance.Tenant_RefID = securityTicket.TenantID;
                shelfContentsTrackingInstance.Creation_Timestamp = DateTime.Now;
                shelfContentsTrackingInstance.Save(Connection, Transaction);

                returnValue.Result = true;
            }		
            
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5IN_SIJPSCaTI_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5IN_SIJPSCaTI_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IN_SIJPSCaTI_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IN_SIJPSCaTI_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_InventoryJob_Process_ShelfContent_and_TrackingInstance",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5IN_SIJPSCaTI_1418 for attribute P_L5IN_SIJPSCaTI_1418
		[DataContract]
		public class P_L5IN_SIJPSCaTI_1418 
		{
			//Standard type parameters
			[DataMember]
			public Guid InvJobProcessShelfID { get; set; } 
			[DataMember]
			public Guid ShelfContentID { get; set; } 
			[DataMember]
			public Guid ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public double ShelfExpectedQuantity { get; set; } 
			[DataMember]
			public double TrackingInstanceExpectedQuantity { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_InventoryJob_Process_ShelfContent_and_TrackingInstance(,P_L5IN_SIJPSCaTI_1418 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_InventoryJob_Process_ShelfContent_and_TrackingInstance.Invoke(connectionString,P_L5IN_SIJPSCaTI_1418 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Atomic.Manipulation.P_L5IN_SIJPSCaTI_1418();
parameter.InvJobProcessShelfID = ...;
parameter.ShelfContentID = ...;
parameter.ProductTrackingInstanceID = ...;
parameter.ShelfExpectedQuantity = ...;
parameter.TrackingInstanceExpectedQuantity = ...;

*/
