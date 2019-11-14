/* 
 * Generated on 9/30/2014 3:36:59 PM
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
using CL1_CMN_BPT;

namespace CL3_PriceGrade.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CMN_BPT_InvestedWorkTime_ChargingLevel.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CMN_BPT_InvestedWorkTime_ChargingLevel
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PG_SCBITCL_0321 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            var item = new ORM_CMN_BPT_InvestedWorkTime_ChargingLevel();

            if (Parameter.CMN_BPT_InvestedWorkTime_ChargingLevelID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_BPT_InvestedWorkTime_ChargingLevelID);
                if (result.Status != FR_Status.Success || item.CMN_BPT_InvestedWorkTime_ChargingLevelID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            if (Parameter.IsDeleted == true)
            {
                //TODO:
            }       
                               
            else
            {
                item.CMN_BPT_InvestedWorkTime_ChargingLevelID = Parameter.CMN_BPT_InvestedWorkTime_ChargingLevelID;
                item.CMN_PRO_Product_Release_RefID = Parameter.CMN_PRO_Product_Release_RefID;
                item.CMN_PRO_Product_Variant_RefID = Parameter.CMN_PRO_Product_Variant_RefID;
                item.ChangingLevel_Name = Parameter.ChangingLevel_Name;
                item.CMN_PRO_Product_RefID = Parameter.CMN_PRO_Product_RefID;
                item.Creation_Timestamp = DateTime.Now;
                item.IsDeleted = false;
                item.Tenant_RefID = securityTicket.TenantID;
                
            }
            			
			return new FR_Guid(item.Save(Connection, Transaction), item.CMN_BPT_InvestedWorkTime_ChargingLevelID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3PG_SCBITCL_0321 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3PG_SCBITCL_0321 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PG_SCBITCL_0321 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PG_SCBITCL_0321 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CMN_BPT_InvestedWorkTime_ChargingLevel",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PG_SCBITCL_0321 for attribute P_L3PG_SCBITCL_0321
		[DataContract]
		public class P_L3PG_SCBITCL_0321 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_InvestedWorkTime_ChargingLevelID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_Variant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_Release_RefID { get; set; } 
			[DataMember]
			public Dict ChangingLevel_Name { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CMN_BPT_InvestedWorkTime_ChargingLevel(,P_L3PG_SCBITCL_0321 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CMN_BPT_InvestedWorkTime_ChargingLevel.Invoke(connectionString,P_L3PG_SCBITCL_0321 Parameter,securityTicket);
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
var parameter = new CL3_PriceGrade.Atomic.Manipulation.P_L3PG_SCBITCL_0321();
parameter.CMN_BPT_InvestedWorkTime_ChargingLevelID = ...;
parameter.CMN_PRO_Product_RefID = ...;
parameter.CMN_PRO_Product_Variant_RefID = ...;
parameter.CMN_PRO_Product_Release_RefID = ...;
parameter.ChangingLevel_Name = ...;
parameter.Creation_Timestamp = ...;
parameter.IsDeleted = ...;
parameter.Tenant_RefID = ...;

*/
