/* 
 * Generated on 16-Jan-14 17:36:57
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
using CL1_CMN_STR_PPS;
using CL1_CMN_CAL;
using CL1_CMN_PPS;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DailyWorkSchedule_Detail_For_DetailID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DailyWorkSchedule_Detail_For_DetailID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DWS_GDWSDFDID_1730 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_GDWSDFDID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5DWS_GDWSDFDID_1730();
			//Put your code here
            returnValue.Result = new L5DWS_GDWSDFDID_1730();

            ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query detailsQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query();
            detailsQuery.CMN_STR_PPS_DailyWorkSchedule_DetailID = Parameter.CMN_STR_PPS_DailyWorkSchedule_DetailID;
            detailsQuery.IsDeleted = false;
            detailsQuery.Tenant_RefID = securityTicket.TenantID;

            var detail = ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query.Search(Connection, Transaction, detailsQuery).FirstOrDefault();           
          
            ORM_CMN_CAL_Event.Query calEventQuery = new ORM_CMN_CAL_Event.Query();
            calEventQuery.CMN_CAL_EventID = detail.CMN_CAL_Event_RefID;
            calEventQuery.IsDeleted = false;
            calEventQuery.Tenant_RefID = securityTicket.TenantID;

            ORM_CMN_CAL_Event calEvent = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, calEventQuery).FirstOrDefault();

            L5DWS_GDWSDFDWSID_1156 resultDetail = new L5DWS_GDWSDFDWSID_1156();
            resultDetail.AbsenceReason_RefID = detail.AbsenceReason_RefID;
            resultDetail.CMN_CAL_Event_RefID = detail.CMN_CAL_Event_RefID;
            resultDetail.CMN_STR_PPS_DailyWorkSchedule_DetailID = detail.CMN_STR_PPS_DailyWorkSchedule_DetailID;
            resultDetail.FromTime_as_time = calEvent.StartTime.ToString("HH:mm");
            resultDetail.ToTime_as_time = calEvent.EndTime.ToString("HH:mm");
            resultDetail.TotalWorkTime_as_time = calEvent.EndTime.Subtract(calEvent.StartTime).ToString(@"hh\:mm");
            resultDetail.IsWorkBreak = detail.IsWorkBreak;
            resultDetail.SheduleForWorkplace_RefID = detail.SheduleForWorkplace_RefID;
            resultDetail.FromTime_as_DateTime = calEvent.StartTime;
            resultDetail.ToTime_as_DateTime = calEvent.EndTime;
            resultDetail.LeaveRequest_RefID = detail.CMN_BPT_EMP_Employee_LeaveRequest_RefID;
            returnValue.Result.DailyWorkScheduleDetail = resultDetail;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DWS_GDWSDFDID_1730 Invoke(string ConnectionString,P_L5DWS_GDWSDFDID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DWS_GDWSDFDID_1730 Invoke(DbConnection Connection,P_L5DWS_GDWSDFDID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DWS_GDWSDFDID_1730 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_GDWSDFDID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DWS_GDWSDFDID_1730 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_GDWSDFDID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DWS_GDWSDFDID_1730 functionReturn = new FR_L5DWS_GDWSDFDID_1730();
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
				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DWS_GDWSDFDID_1730 : FR_Base
	{
		public L5DWS_GDWSDFDID_1730 Result	{ get; set; }

		public FR_L5DWS_GDWSDFDID_1730() : base() {}

		public FR_L5DWS_GDWSDFDID_1730(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}
