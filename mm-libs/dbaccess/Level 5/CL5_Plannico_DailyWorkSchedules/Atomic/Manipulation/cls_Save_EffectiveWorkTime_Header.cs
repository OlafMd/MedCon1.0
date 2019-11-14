/* 
 * Generated on 14-May-14 10:59:18
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

namespace CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_EffectiveWorkTime_Header.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_EffectiveWorkTime_Header
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_SEWTH_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            if (Parameter.CMN_STR_PPS_EffectiveWorkTime_HeaderID != Guid.Empty)
            {
                ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query headerQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query();
                headerQuery.CMN_STR_PPS_EffectiveWorkTime_HeaderID = Parameter.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
                headerQuery.IsDeleted = false;
                headerQuery.Tenant_RefID = securityTicket.TenantID;

                var header = ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query.Search(Connection, Transaction, headerQuery).FirstOrDefault();

                header.IsBreakTimeManualySpecified = Parameter.IsBreakTimeManualySpecified;
                header.BreakDurationTime_in_sec = Parameter.BreakDurationTime_in_sec;
                header.ContractWorkerText = Parameter.ContractWorkerText;
                header.EffectiveBusinessDay = Parameter.EffectiveBusinessDay;
                header.Employee_RefID = Parameter.Employee_RefID;
                header.SheduleBreakTemplate_RefID = Parameter.SheduleBreakTemplate_RefID;
                header.WorktimeComment = Parameter.WorktimeComment;

                header.Save(Connection, Transaction);

                return new FR_Guid(header.CMN_STR_PPS_EffectiveWorkTime_HeaderID);
            }
            else
            {
                ORM_CMN_BPT_EMP_EffectiveWorkTime_Header header = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header();
                header.IsBreakTimeManualySpecified = Parameter.IsBreakTimeManualySpecified;
                header.BreakDurationTime_in_sec = Parameter.BreakDurationTime_in_sec;
                header.ContractWorkerText = Parameter.ContractWorkerText;
                header.EffectiveBusinessDay = Parameter.EffectiveBusinessDay;
                header.Employee_RefID = Parameter.Employee_RefID;
                header.SheduleBreakTemplate_RefID = Parameter.SheduleBreakTemplate_RefID;
                header.WorktimeComment = Parameter.WorktimeComment;
                header.Tenant_RefID = securityTicket.TenantID;
                header.Save(Connection, Transaction);

                return new FR_Guid(header.CMN_STR_PPS_EffectiveWorkTime_HeaderID);
            }

           

			
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DWS_SEWTH_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DWS_SEWTH_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_SEWTH_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_SEWTH_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		

	#endregion
}
