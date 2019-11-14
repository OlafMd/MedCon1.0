/* 
 * Generated on 13-May-14 12:44:00
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
    /// var result = cls_Get_EffectiveWorkTime_Position_For_PositionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_EffectiveWorkTime_Position_For_PositionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DWS_GEWTPFPID_1242 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_GEWTPFPID_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5DWS_GEWTPFPID_1242();
			//Put your code here

            if (Parameter.EffectiveWorkTime_PositionID == Guid.Empty)
                return null;

            ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query positionQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query();
            positionQuery.CMN_BPT_EMP_EffectiveWorkTime_PositionID = Parameter.EffectiveWorkTime_PositionID;
            positionQuery.IsDeleted = false;
            positionQuery.Tenant_RefID = securityTicket.TenantID;

            var position = ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query.Search(Connection, Transaction, positionQuery).FirstOrDefault();           
            
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

            returnValue.Result = new L5DWS_GEWTPFPID_1242();
            returnValue.Result.EffectiveWorkTimePosition = newPosition;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DWS_GEWTPFPID_1242 Invoke(string ConnectionString,P_L5DWS_GEWTPFPID_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DWS_GEWTPFPID_1242 Invoke(DbConnection Connection,P_L5DWS_GEWTPFPID_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DWS_GEWTPFPID_1242 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_GEWTPFPID_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DWS_GEWTPFPID_1242 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_GEWTPFPID_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DWS_GEWTPFPID_1242 functionReturn = new FR_L5DWS_GEWTPFPID_1242();
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
	public class FR_L5DWS_GEWTPFPID_1242 : FR_Base
	{
		public L5DWS_GEWTPFPID_1242 Result	{ get; set; }

		public FR_L5DWS_GEWTPFPID_1242() : base() {}

		public FR_L5DWS_GEWTPFPID_1242(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}
