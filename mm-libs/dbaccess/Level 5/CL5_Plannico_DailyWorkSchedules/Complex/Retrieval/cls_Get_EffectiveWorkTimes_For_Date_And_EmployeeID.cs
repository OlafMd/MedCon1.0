/* 
 * Generated on 15-May-14 10:00:30
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
using CL1_CMN_BPT_EMP;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_EffectiveWorkTimes_For_Date_And_EmployeeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_EffectiveWorkTimes_For_Date_And_EmployeeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DWS_GEWTFDAE_0953 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_GEWTFDAE_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5DWS_GEWTFDAE_0953();
			//Put your code here

            ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query effectiveWorkTimeHeaderQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query();
            effectiveWorkTimeHeaderQuery.EffectiveBusinessDay = Parameter.currentDate.Date;
            effectiveWorkTimeHeaderQuery.Employee_RefID = Parameter.EmployeeID;
            effectiveWorkTimeHeaderQuery.IsDeleted = false;
            effectiveWorkTimeHeaderQuery.Tenant_RefID = securityTicket.TenantID;


            var header = ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query.Search(Connection, Transaction, effectiveWorkTimeHeaderQuery).FirstOrDefault();

            if (header == null)
            {
                returnValue.Result = new L5DWS_GEWTFDAE_0953();
                returnValue.Result.EffectiveWorkTime = null;
                return returnValue;
            }
           
            L5DWS_GEWTFD_1648 resultItem = new L5DWS_GEWTFD_1648();
            resultItem.CMN_STR_PPS_EffectiveWorkTime_HeaderID = header.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
            resultItem.BreakDurationTime_in_sec = header.BreakDurationTime_in_sec;
            resultItem.ContractWorkerText = header.ContractWorkerText;
            resultItem.EffectiveBusinessDay = header.EffectiveBusinessDay;
            resultItem.Employee_RefID = header.Employee_RefID;
            resultItem.IsBreakTimeManualySpecified = header.IsBreakTimeManualySpecified;
            resultItem.SheduleBreakTemplate_RefID = header.SheduleBreakTemplate_RefID;
            resultItem.WorktimeComment = header.WorktimeComment;

            ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query positionQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query();
            positionQuery.EffectiveWorkTime_Header_RefID = header.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
            positionQuery.IsDeleted = false;
            positionQuery.Tenant_RefID = securityTicket.TenantID;

            var positions = ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query.Search(Connection, Transaction, positionQuery);

            List<L5DWS_GEWTFD_1648_Position> listOfPositions = new List<L5DWS_GEWTFD_1648_Position>();

            foreach (var position in positions)
            {
                L5DWS_GEWTFD_1648_Position newPosition = new L5DWS_GEWTFD_1648_Position();
                newPosition.Activity_RefID = position.Activity_RefID;
                newPosition.CMN_BPT_EMP_EffectiveWorkTime_PositionID = position.CMN_BPT_EMP_EffectiveWorkTime_PositionID;
                newPosition.CMN_BPT_EMP_Employe_RefID = position.CMN_BPT_EMP_Employe_RefID;
                newPosition.CMN_BPT_EMP_Employee_LeaveRequest_RefID = position.CMN_BPT_EMP_Employee_LeaveRequest_RefID;
                newPosition.EffectiveWorkTime_Header_RefID = position.EffectiveWorkTime_Header_RefID;
                newPosition.SourceOfEntry = position.SourceOfEntry;
                newPosition.Workplace_RefID = position.Workplace_RefID;
                newPosition.WorkTime_Duration_in_sec = position.WorkTime_Duration_in_sec;
                newPosition.WorkTime_StartTime = position.WorkTime_StartTime;

                if (position.CMN_BPT_EMP_Employee_LeaveRequest_RefID != Guid.Empty)
                {
                    ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query lrQuery = new ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query();
                    lrQuery.CMN_BPT_EMP_Employee_LeaveRequestID = position.CMN_BPT_EMP_Employee_LeaveRequest_RefID;
                    lrQuery.IsDeleted = false;
                    lrQuery.Tenant_RefID = securityTicket.TenantID;

                    var leaveRequest = ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query.Search(Connection, Transaction, lrQuery).FirstOrDefault();
                    newPosition.AbsenceReason_RefID = leaveRequest.CMN_BPT_STA_AbsenceReason_RefID;
                }
                else
                    newPosition.AbsenceReason_RefID = Guid.Empty;

                listOfPositions.Add(newPosition);
            }

            resultItem.Positions = listOfPositions.ToArray();

            returnValue.Result = new L5DWS_GEWTFDAE_0953();
            returnValue.Result.EffectiveWorkTime = resultItem;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DWS_GEWTFDAE_0953 Invoke(string ConnectionString,P_L5DWS_GEWTFDAE_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DWS_GEWTFDAE_0953 Invoke(DbConnection Connection,P_L5DWS_GEWTFDAE_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DWS_GEWTFDAE_0953 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_GEWTFDAE_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DWS_GEWTFDAE_0953 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_GEWTFDAE_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DWS_GEWTFDAE_0953 functionReturn = new FR_L5DWS_GEWTFDAE_0953();
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
	public class FR_L5DWS_GEWTFDAE_0953 : FR_Base
	{
		public L5DWS_GEWTFDAE_0953 Result	{ get; set; }

		public FR_L5DWS_GEWTFDAE_0953() : base() {}

		public FR_L5DWS_GEWTFDAE_0953(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}
