/* 
 * Generated on 7/25/2014 1:15:17 PM
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
using CL1_TMS_PRO;
using System.Web;
using CL2_DeveloperTask.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.DanuTask;

namespace CL6_DanuTask_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Update_DeveloperTaskStatusHistoryWithAddDocument.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Update_DeveloperTaskStatusHistoryWithAddDocument
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_UDTSHwAD_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();
            //Put your code here

            #region DocumentUpdated

            var documentUpdatedParam = new P_L2DT_GDTSfGPM_1121();
            documentUpdatedParam.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDeveloperTaskHistory.DocumentUpdated);

            var documentUpdatedID = cls_Get_DeveloperTaskStatus_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, documentUpdatedParam, securityTicket).Result;

            #endregion

            var dtask = new ORM_TMS_PRO_DeveloperTask();
            dtask.Load(Connection, Transaction, Parameter.DeveloperTaskID);

            ORM_TMS_PRO_ProjectMember.Query assinment_Query = new ORM_TMS_PRO_ProjectMember.Query();
            assinment_Query.USR_Account_RefID = securityTicket.AccountID;
            assinment_Query.Project_RefID = dtask.Project_RefID;
            assinment_Query.IsDeleted = false;

            List<ORM_TMS_PRO_ProjectMember> assinment = ORM_TMS_PRO_ProjectMember.Query.Search(Connection, Transaction, assinment_Query);

            ORM_TMS_PRO_DeveloperTask_StatusHistory statusHistory = new ORM_TMS_PRO_DeveloperTask_StatusHistory();

            statusHistory.TMS_PRO_DeveloperTask_StatusHistoryID = Guid.NewGuid();
            statusHistory.DeveloperTask_RefID = dtask.TMS_PRO_DeveloperTaskID;
            statusHistory.DeveloperTask_Status_RefID = documentUpdatedID.TMS_PRO_DeveloperTask_StatusID;
            statusHistory.TriggeredBy_ProjectMember_RefID = assinment.First().TMS_PRO_ProjectMemberID;
            statusHistory.Tenant_RefID = securityTicket.TenantID;
            statusHistory.Creation_Timestamp = DateTime.Now;
            if (Parameter.FileType == "Document")
                statusHistory.Comment = (String)HttpContext.GetGlobalResourceObject("Global", "File_Add") + Parameter.FileName;
            else if (Parameter.FileType == "Revision")
                statusHistory.Comment = (String)HttpContext.GetGlobalResourceObject("Global", "File_Add") + Parameter.FileName;
            else
                statusHistory.Comment = (String)HttpContext.GetGlobalResourceObject("Global", "Folder_Add") + Parameter.FileName;

            statusHistory.Save(Connection, Transaction);

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DT_UDTSHwAD_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DT_UDTSHwAD_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_UDTSHwAD_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_UDTSHwAD_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Update_DeveloperTaskStatusHistoryWithAddDocument",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6DT_UDTSHwAD_1637 for attribute P_L6DT_UDTSHwAD_1637
		[DataContract]
		public class P_L6DT_UDTSHwAD_1637 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTaskID { get; set; } 
			[DataMember]
			public String FileName { get; set; } 
			[DataMember]
			public String FileType { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Update_DeveloperTaskStatusHistoryWithAddDocument(,P_L6DT_UDTSHwAD_1637 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Update_DeveloperTaskStatusHistoryWithAddDocument.Invoke(connectionString,P_L6DT_UDTSHwAD_1637 Parameter,securityTicket);
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
var parameter = new CL6_DeveloperTask.Complex.Manipulation.P_L6DT_UDTSHwAD_1637();
parameter.DeveloperTaskID = ...;
parameter.FileName = ...;
parameter.FileType = ...;

*/
