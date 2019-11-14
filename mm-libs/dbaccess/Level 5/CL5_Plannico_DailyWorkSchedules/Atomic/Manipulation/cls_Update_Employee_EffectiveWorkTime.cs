/* 
 * Generated on 08/05/2014 13:42:36
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
using PlannicoModel.Models;
using CL5_VacationPlanner_Contract.Atomic.Manipulation;
using CL5_VacationPlanner_Contract.Atomic.Retrieval;
using CL1_CMN_CAL;
using CL1_CMN_BPT_EMP;
using CL1_CMN_STR_PPS;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Update_Employee_EffectiveWorkTime.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Update_Employee_EffectiveWorkTime
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_UEWT_1310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_CMN_BPT_EMP_EffectiveWorkTime_Position effectiveWorkTime = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Position();
            if (Parameter.CMN_STR_PPS_EffectiveWorkTimeID != Guid.Empty)
            {
                var result = effectiveWorkTime.Load(Connection, Transaction, Parameter.CMN_STR_PPS_EffectiveWorkTimeID);
                if (result.Status != FR_Status.Success || effectiveWorkTime.CMN_BPT_EMP_EffectiveWorkTime_PositionID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID.";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                effectiveWorkTime.Activity_RefID = Parameter.Activity_RefID;                
                effectiveWorkTime.Workplace_RefID = Parameter.Workplace_RefID;
                effectiveWorkTime.WorkTime_Duration_in_sec = Parameter.WorkTime_Duration_in_sec;
                effectiveWorkTime.WorkTime_StartTime = Parameter.WorkTime_StartTime;
                effectiveWorkTime.Save(Connection, Transaction);
            }
            
            
            //Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DWS_UEWT_1310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DWS_UEWT_1310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_UEWT_1310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_UEWT_1310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw new Exception("Exception occured in method cls_Update_Employee_EffectiveWorkTime",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
	

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Update_Employee_EffectiveWorkTime(,P_L5DWS_UEWT_1310 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Update_Employee_EffectiveWorkTime.Invoke(connectionString,P_L5DWS_UEWT_1310 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation.P_L5DWS_UEWT_1310();
parameter.CMN_STR_PPS_EffectiveWorkTimeID = ...;
parameter.BoundTo_DailyWorkShedule_Detail_RefID = ...;
parameter.Activity_RefID = ...;
parameter.Workplace_RefID = ...;
parameter.CMN_BPT_EMP_Employee_LeaveRequest_RefID = ...;
parameter.WorkTime_StartTime = ...;
parameter.WorkTime_Duration_in_sec = ...;
parameter.SourceOfEntry = ...;
parameter.durationInDays = ...;
parameter.durationInHours = ...;
parameter.OldDurationInDays = ...;
parameter.OldDurationInHours = ...;
parameter.AbsenceReason_RefID = ...;

*/
