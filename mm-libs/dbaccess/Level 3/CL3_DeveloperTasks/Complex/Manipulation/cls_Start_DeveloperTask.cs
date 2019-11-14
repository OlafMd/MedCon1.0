/* 
 * Generated on 7/16/2014 1:57:06 PM
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
using CL2_DeveloperTask.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.DanuTask;
using CL1_TMS_PRO;

namespace CL3_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    /// 

    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Start_DeveloperTask.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Start_DeveloperTask
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3DT_SDT_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            //Put your code here

            #region Started status
            var Parameter_StartedStatusID = new P_L2DT_GDTSfGPM_1121();
            Parameter_StartedStatusID.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDeveloperTaskHistory.Started);

            var StatusStarted_ID = cls_Get_DeveloperTaskStatus_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, Parameter_StartedStatusID, securityTicket).Result;
            #endregion 

            #region Involvement
            ORM_TMS_PRO_DeveloperTask_Involvement DeveloperTask_Involvement = new ORM_TMS_PRO_DeveloperTask_Involvement();
            DeveloperTask_Involvement.Load(Connection, Transaction, Parameter.DeveloperTask_InvolvementID);
            #endregion

            #region Create Developer Task Status History
            ORM_TMS_PRO_DeveloperTask_StatusHistory DeveloperTask_StatusHistory = new ORM_TMS_PRO_DeveloperTask_StatusHistory();
            DeveloperTask_StatusHistory.DeveloperTask_RefID = DeveloperTask_Involvement.DeveloperTask_RefID;
            DeveloperTask_StatusHistory.DeveloperTask_Status_RefID = StatusStarted_ID.TMS_PRO_DeveloperTask_StatusID;
            DeveloperTask_StatusHistory.TriggeredBy_ProjectMember_RefID = DeveloperTask_Involvement.ProjectMember_RefID;
            DeveloperTask_StatusHistory.CreatedFor_ProjectMember_RefID = Guid.Empty;
            DeveloperTask_StatusHistory.Comment = "Task has been started.";
            DeveloperTask_StatusHistory.Tenant_RefID = securityTicket.TenantID;

            DeveloperTask_StatusHistory.Save(Connection, Transaction);

            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3DT_SDT_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3DT_SDT_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DT_SDT_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DT_SDT_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Start_DeveloperTask",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3DT_SDT_1636 for attribute P_L3DT_SDT_1636
		[DataContract]
		public class P_L3DT_SDT_1636 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTask_InvolvementID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Start_DeveloperTask(,P_L3DT_SDT_1636 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Start_DeveloperTask.Invoke(connectionString,P_L3DT_SDT_1636 Parameter,securityTicket);
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
var parameter = new CL3_DeveloperTask.Complex.Manipulation.P_L3DT_SDT_1636();
parameter.DeveloperTask_InvolvementID = ...;

*/
