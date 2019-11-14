/* 
 * Generated on 5/20/2014 12:21:41 PM
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
using CL6_VacationPlanner_LeaveRequest.Complex.Retrieval;
using PlannicoModel.Models;
using CL6_VacationPlanner_LeaveRequest.Complex.Manipulation;
using CLE_L6_PlannicoMobile_LeaveRequest.Complex.Retrieval;
using CLE_L5_PlannicoMobile_Events.Complex.Retrieval;
using CL5_VacationPlanner_Employees.Atomic.Retrieval;

namespace CLE_L6_PlannicoMobile_LeaveRequest.Complex.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_CancelLeave.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_CancelLeave
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6LR_CL_1224 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            FR_Guid returnValue = new FR_Guid();
            #region  get leave events and intervals
            var leaveToDeny = cls_Get_LeaveRequests_By_ID.Invoke(Connection, Transaction, new P_L6LR_GLR_ID_1339 { LeaveID = Parameter.LeaveRequestID }, securityTicket).Result;
            L5LR_EV_TSD_1047[] Events = cls_Get_Events_for_Timespan_Data.Invoke(Connection, Transaction, new P_L5LR_EV_TSD_1047() { EndDate = leaveToDeny.Leave.EndTime, StartDate = leaveToDeny.Leave.StartTime }, securityTicket).Result;
            L5_EM_GEWI_1628 intervalsActiveContract = cls_Get_Employee_WorktimeIntervals.Invoke(Connection, Transaction, securityTicket).Result.SingleOrDefault();
            #endregion get leave events and intervals

            #region calculate duration and deny leave
            var durationInDays = leaveToDeny.duration(intervalsActiveContract, Events, true);
            var durationInHours = leaveToDeny.duration(intervalsActiveContract, Events, false);
            var rv = cle_Save_LeaveRequest_CancelAction.Invoke(Connection, Transaction, new P_L6LR_SLRCA_1055 { LeaveRequestID = Parameter.LeaveRequestID, durationInDays = durationInDays, durationInHours = durationInHours }, securityTicket);
            #endregion calculate duration and deny leave

            returnValue.ErrorMessage = rv.ErrorMessage;
            returnValue.Status = rv.Status;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6LR_CL_1224 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6LR_CL_1224 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6LR_CL_1224 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6LR_CL_1224 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_CancelLeave",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6LR_CL_1224 for attribute P_L6LR_CL_1224
		[DataContract]
		public class P_L6LR_CL_1224 
		{
			//Standard type parameters
			[DataMember]
			public Guid LeaveRequestID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_CancelLeave(,P_L6LR_CL_1224 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_CancelLeave.Invoke(connectionString,P_L6LR_CL_1224 Parameter,securityTicket);
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
var parameter = new CLE_L6_PlannicoMobile_LeaveRequest.Complex.Manipulation.P_L6LR_CL_1224();
parameter.LeaveRequestID = ...;

*/
