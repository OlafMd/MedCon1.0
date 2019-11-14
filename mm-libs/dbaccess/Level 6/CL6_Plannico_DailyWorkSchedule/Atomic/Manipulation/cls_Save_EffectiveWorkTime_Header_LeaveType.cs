/* 
 * Generated on 21/05/2014 19:43:59
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
using CL1_CMN_BPT_EMP;
using PlannicoModel.Models;
using CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation;
using VacationPlaner;

namespace CL6_Plannico_DailyWorkSchedule.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_EffectiveWorkTime_Header_LeaveType.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_EffectiveWorkTime_Header_LeaveType
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DWS_SEWTHLT_1934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            
            ORM_CMN_BPT_EMP_EffectiveWorkTime_Header effectiveWorkTimeHeader = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header();

            if (Parameter.CMN_STR_PPS_EffectiveWorkTime_HeaderID != Guid.Empty)
            {
                ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query effectiveWorkTimeHeaderQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query();
                effectiveWorkTimeHeaderQuery.CMN_STR_PPS_EffectiveWorkTime_HeaderID = Parameter.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
                effectiveWorkTimeHeaderQuery.Tenant_RefID = securityTicket.TenantID;
                effectiveWorkTimeHeaderQuery.IsDeleted = false;

                effectiveWorkTimeHeader = ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query.Search(Connection, Transaction, effectiveWorkTimeHeaderQuery).FirstOrDefault();
            }
            else
            {

                ORM_CMN_BPT_EMP_EffectiveWorkTime_Header effectiveWorkTimeHeaderToSave = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header();
                effectiveWorkTimeHeaderToSave.IsBreakTimeManualySpecified = false;
                effectiveWorkTimeHeaderToSave.ContractWorkerText = "";
                effectiveWorkTimeHeaderToSave.Employee_RefID = Parameter.Employee_RefID;
                effectiveWorkTimeHeaderToSave.Tenant_RefID = securityTicket.TenantID;
                effectiveWorkTimeHeaderToSave.EffectiveBusinessDay = Parameter.WorkSheduleDate;
                effectiveWorkTimeHeaderToSave.Save(Connection, Transaction);

                effectiveWorkTimeHeader = effectiveWorkTimeHeaderToSave;
            }

            var startTime = effectiveWorkTimeHeader.EffectiveBusinessDay.AddMinutes(Parameter.dayStartInMins);

            P_L5DWS_SEWTP_1337 effectivePositionParam = new P_L5DWS_SEWTP_1337();
            effectivePositionParam.EffectiveWorkTime_Header_RefID = effectiveWorkTimeHeader.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
            effectivePositionParam.WorkTime_Start = startTime;
            effectivePositionParam.WorkTime_End = startTime.AddSeconds(Parameter.R_ContractSpecified_WorkingTime_in_sec);
            effectivePositionParam.Employee_RefID = Parameter.Employee_RefID;
            effectivePositionParam.AbsenceReason_RefID = Parameter.LeaveTypeID;
            effectivePositionParam.RequestedFor_Employee_RefID = Parameter.Employee_RefID;
            cls_Save_EffectiveWorkTime_Position.Invoke(Connection, Transaction, effectivePositionParam, securityTicket);

            returnValue.Result = effectiveWorkTimeHeader.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
            //Put your code here
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DWS_SEWTHLT_1934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DWS_SEWTHLT_1934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DWS_SEWTHLT_1934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DWS_SEWTHLT_1934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
				throw new Exception("Exception occured in method cls_Save_EffectiveWorkTime_Header_LeaveType",ex);
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
FR_Guid cls_Save_EffectiveWorkTime_Header_LeaveType(,P_L6DWS_SEWTHLT_1934 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_EffectiveWorkTime_Header_LeaveType.Invoke(connectionString,P_L6DWS_SEWTHLT_1934 Parameter,securityTicket);
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
var parameter = new CL6_Plannico_DailyWorkSchedule.Atomic.Manipulation.P_L6DWS_SEWTHLT_1934();
parameter.WorkSheduleDate = ...;
parameter.LeaveTypeID = ...;
parameter.R_ContractSpecified_WorkingTime_in_sec = ...;
parameter.Employee_RefID = ...;
parameter.durationInDays = ...;
parameter.durationInHours = ...;

*/
