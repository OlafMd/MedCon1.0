/* 
 * Generated on 3/7/2014 1:18:41 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_LOG_WRH;

namespace CL2_InventoryChangeReason.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Inventory_Change_Reason.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Inventory_Change_Reason
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2IC_SICR_0943 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            Dict nameDict = new Dict("log_wrh_inventorychangereasons");
            Dict descriptionDict = new Dict("log_wrh_inventorychangereasons");

            foreach(var langID in Parameter.Languages)
            {
                nameDict.AddEntry(langID, Parameter.Name);
                descriptionDict.AddEntry(langID, Parameter.Description);
            }

            ORM_LOG_WRH_InventoryChangeReason reason = new ORM_LOG_WRH_InventoryChangeReason();

            if (Parameter.InventoryChangeReasonID == Guid.Empty)
                reason.LOG_WRH_InventoryChangeReasonID = Guid.NewGuid();    // new
            else
                reason.Load(Connection, Transaction, Parameter.InventoryChangeReasonID); // edit

            reason.InventoryChange_Description = descriptionDict;
            reason.InventoryChange_Name = nameDict;
            reason.Creation_Timestamp = DateTime.Now;
            reason.Tenant_RefID = securityTicket.TenantID;
            reason.GlobalPropertyMatchingID = Guid.Empty.ToString();
            reason.IsDeleted = false;

            reason.Save(Connection, Transaction);

            returnValue.Result = reason.LOG_WRH_InventoryChangeReasonID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2IC_SICR_0943 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2IC_SICR_0943 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2IC_SICR_0943 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2IC_SICR_0943 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Inventory_Change_Reason",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2IC_SICR_0943 for attribute P_L2IC_SICR_0943
		[DataContract]
		public class P_L2IC_SICR_0943 
		{
			//Standard type parameters
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public String Description { get; set; } 
			[DataMember]
			public Guid[] Languages { get; set; } 
			[DataMember]
			public Guid InventoryChangeReasonID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Inventory_Change_Reason(,P_L2IC_SICR_0943 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Inventory_Change_Reason.Invoke(connectionString,P_L2IC_SICR_0943 Parameter,securityTicket);
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
var parameter = new CL2_InventoryChangeReason.Atomic.Manipulation.P_L2IC_SICR_0943();
parameter.Name = ...;
parameter.Description = ...;
parameter.Languages = ...;
parameter.InventoryChangeReasonID = ...;

*/
