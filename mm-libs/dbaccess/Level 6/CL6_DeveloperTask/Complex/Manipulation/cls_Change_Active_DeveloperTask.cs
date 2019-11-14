/* 
 * Generated on 7/25/2014 2:52:57 PM
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
using CL2_DeveloperTask.Atomic.Retrieval;
using DLCore_DBCommons.DanuTask;
using DLCore_DBCommons.Utils;

namespace CL6_DanuTask_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    /// 

    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Change_Active_DeveloperTask.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Change_Active_DeveloperTask
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_CADT_1453 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
            var returnValue = new FR_Guid();
            #region Activated
          

            var activatedParam = new P_L2DT_GDTSfGPM_1121();
            activatedParam.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDeveloperTaskHistory.Activated);

            var activatedID = cls_Get_DeveloperTaskStatus_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, activatedParam, securityTicket).Result;

            #endregion

            #region Started

            var startedParam = new P_L2DT_GDTSfGPM_1121();
            startedParam.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDeveloperTaskHistory.Started);

            var startedID = cls_Get_DeveloperTaskStatus_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, startedParam, securityTicket).Result;

            #endregion

            #region Deactivated

            var deactivatedParam = new P_L2DT_GDTSfGPM_1121();
            deactivatedParam.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDeveloperTaskHistory.Deactivated);

            var deactivatedID = cls_Get_DeveloperTaskStatus_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, deactivatedParam, securityTicket).Result;

            #endregion

            #region ORM_TMS_PRO_DeveloperTask_2_ProjectMember

            //Load New 
            ORM_TMS_PRO_DeveloperTask_Involvement newActive = new ORM_TMS_PRO_DeveloperTask_Involvement();
            if (Parameter.AssignmentID_newActive != Guid.Empty)
            {
                newActive.Load(Connection, Transaction, Parameter.AssignmentID_newActive);
            }

            //Load Old
            ORM_TMS_PRO_DeveloperTask_Involvement oldActive = new ORM_TMS_PRO_DeveloperTask_Involvement();
            if (Parameter.AssignmentID_oldActive != Guid.Empty)
            {
                oldActive.Load(Connection, Transaction, Parameter.AssignmentID_oldActive);
            }

            //Save New
            if (Parameter.AssignmentID_newActive != Guid.Empty)
            {
                newActive.IsActive = true;
                newActive.OrderSequence = 0;

                newActive.Save(Connection, Transaction);
            }

            //Save Old
            if (Parameter.AssignmentID_oldActive != Guid.Empty)
            {
                oldActive.IsActive = false;
                oldActive.OrderSequence = newActive.OrderSequence;
                oldActive.Save(Connection, Transaction);
            }

            #endregion ORM_TMS_PRO_DeveloperTask_2_ProjectMember

            #region ORM_TMS_PRO_DeveloperTask

            if (Parameter.AssignmentID_newActive != Guid.Empty)
            {
                ORM_TMS_PRO_DeveloperTask task = new ORM_TMS_PRO_DeveloperTask();
                task.Load(Connection, Transaction, newActive.DeveloperTask_RefID);

                if (task.IsIncompleteInformation)
                {
                    task.IsIncompleteInformation = false;
                    task.Save(Connection, Transaction);
                }
            }

            #endregion

            #region ORM_DeveloperTask_StatusHistory_newActive

            if (Parameter.AssignmentID_newActive != Guid.Empty)
            {
                //Activated
                ORM_TMS_PRO_DeveloperTask_StatusHistory newActive_history = new ORM_TMS_PRO_DeveloperTask_StatusHistory();

                newActive_history.DeveloperTask_RefID = newActive.DeveloperTask_RefID;
                newActive_history.DeveloperTask_Status_RefID = activatedID.TMS_PRO_DeveloperTask_StatusID;
                newActive_history.TriggeredBy_ProjectMember_RefID = newActive.ProjectMember_RefID;
                newActive_history.CreatedFor_ProjectMember_RefID = Guid.Empty;
                newActive_history.Comment = "Task is activated.";
                newActive_history.Tenant_RefID = securityTicket.TenantID;
                newActive_history.Creation_Timestamp = DateTime.Now;

                newActive_history.Save(Connection, Transaction);

                //Started
                newActive_history = new ORM_TMS_PRO_DeveloperTask_StatusHistory();

                newActive_history.DeveloperTask_RefID = newActive.DeveloperTask_RefID;
                newActive_history.DeveloperTask_Status_RefID = startedID.TMS_PRO_DeveloperTask_StatusID;
                newActive_history.TriggeredBy_ProjectMember_RefID = newActive.ProjectMember_RefID;
                newActive_history.CreatedFor_ProjectMember_RefID = Guid.Empty;
                newActive_history.Comment = "Task is started.";
                newActive_history.Tenant_RefID = securityTicket.TenantID;
                newActive_history.Creation_Timestamp = DateTime.Now.AddSeconds(2); //add 2 sec to be shure that is last one  

                newActive_history.Save(Connection, Transaction);
            }


            #endregion ORM_DeveloperTask_StatusHistory_newActive

            #region ORM_DeveloperTask_StatusHistory_oldActive

            if (Parameter.AssignmentID_oldActive != Guid.Empty)
            {

                ORM_TMS_PRO_DeveloperTask_StatusHistory oldActive_history = new ORM_TMS_PRO_DeveloperTask_StatusHistory();

                //Deactivated
                oldActive_history.DeveloperTask_RefID = oldActive.DeveloperTask_RefID;
                oldActive_history.DeveloperTask_Status_RefID = deactivatedID.TMS_PRO_DeveloperTask_StatusID;
                oldActive_history.TriggeredBy_ProjectMember_RefID = oldActive.ProjectMember_RefID;
                oldActive_history.CreatedFor_ProjectMember_RefID = Guid.Empty;
                oldActive_history.Comment = "Task is deactivated.";
                oldActive_history.Tenant_RefID = securityTicket.TenantID;
                oldActive_history.Creation_Timestamp = DateTime.Now.AddSeconds(2); //add 2 sec to be shure that is last one 

                oldActive_history.Save(Connection, Transaction);
            }

            #endregion ORM_DeveloperTask_StatusHistory_oldActive
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DT_CADT_1453 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DT_CADT_1453 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_CADT_1453 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_CADT_1453 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Change_Active_DeveloperTask",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6DT_CADT_1453 for attribute P_L6DT_CADT_1453
		[DataContract]
		public class P_L6DT_CADT_1453 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID_newActive { get; set; } 
			[DataMember]
			public Guid AssignmentID_oldActive { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Change_Active_DeveloperTask(,P_L6DT_CADT_1453 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Change_Active_DeveloperTask.Invoke(connectionString,P_L6DT_CADT_1453 Parameter,securityTicket);
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
var parameter = new CLE_L6_TMS_PRO_DeveloperTask.Complex.Manipulation.P_L6DT_CADT_1453();
parameter.AssignmentID_newActive = ...;
parameter.AssignmentID_oldActive = ...;

*/
