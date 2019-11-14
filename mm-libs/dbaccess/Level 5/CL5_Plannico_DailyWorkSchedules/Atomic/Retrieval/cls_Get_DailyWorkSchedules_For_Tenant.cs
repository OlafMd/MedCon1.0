/* 
 * Generated on 17-Jan-14 18:10:45
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
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DailyWorkSchedules_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DailyWorkSchedules_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DWS_GDWSFT_1154_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DWS_GDWSFT_1154_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Plannico_DailyWorkSchedules.Atomic.Retrieval.SQL.cls_Get_DailyWorkSchedules_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L5DWS_GDWSFT_1154> results = new List<L5DWS_GDWSFT_1154>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_STR_PPS_DailyWorkScheduleID","Employee_RefID","WorkSheduleDate","InstantiatedWithShiftTemplate_RefID","SheduleBreakTemplate_RefID","IsBreakTimeManualySpecified","WorkingSheduleComment","ContractWorkerText","R_WorkDay_Start_in_sec","R_WorkDay_End_in_sec","R_WorkDay_Duration_in_sec","BreakDurationTime_in_sec","R_ContractSpecified_WorkingTime_in_sec","IsWorkShedule_Confirmed","WorkShedule_ConfirmedBy_Account_RefID" });
				while(reader.Read())
				{
					L5DWS_GDWSFT_1154 resultItem = new L5DWS_GDWSFT_1154();
					//0:Parameter CMN_STR_PPS_DailyWorkScheduleID of type Guid
					resultItem.CMN_STR_PPS_DailyWorkScheduleID = reader.GetGuid(0);
					//1:Parameter Employee_RefID of type Guid
					resultItem.Employee_RefID = reader.GetGuid(1);
					//2:Parameter WorkSheduleDate of type DateTime
					resultItem.WorkSheduleDate = reader.GetDate(2);
					//3:Parameter InstantiatedWithShiftTemplate_RefID of type Guid
					resultItem.InstantiatedWithShiftTemplate_RefID = reader.GetGuid(3);
					//4:Parameter SheduleBreakTemplate_RefID of type Guid
					resultItem.SheduleBreakTemplate_RefID = reader.GetGuid(4);
					//5:Parameter IsBreakTimeManualySpecified of type bool
					resultItem.IsBreakTimeManualySpecified = reader.GetBoolean(5);
					//6:Parameter WorkingSheduleComment of type String
					resultItem.WorkingSheduleComment = reader.GetString(6);
					//7:Parameter ContractWorkerText of type String
					resultItem.ContractWorkerText = reader.GetString(7);
					//8:Parameter R_WorkDay_Start_in_sec of type int
					resultItem.R_WorkDay_Start_in_sec = reader.GetInteger(8);
					//9:Parameter R_WorkDay_End_in_sec of type int
					resultItem.R_WorkDay_End_in_sec = reader.GetInteger(9);
					//10:Parameter R_WorkDay_Duration_in_sec of type int
					resultItem.R_WorkDay_Duration_in_sec = reader.GetInteger(10);
					//11:Parameter BreakDurationTime_in_sec of type int
					resultItem.BreakDurationTime_in_sec = reader.GetInteger(11);
					//12:Parameter R_ContractSpecified_WorkingTime_in_sec of type int
					resultItem.R_ContractSpecified_WorkingTime_in_sec = reader.GetInteger(12);
					//13:Parameter IsWorkShedule_Confirmed of type bool
					resultItem.IsWorkShedule_Confirmed = reader.GetBoolean(13);
					//14:Parameter WorkShedule_ConfirmedBy_Account_RefID of type Guid
					resultItem.WorkShedule_ConfirmedBy_Account_RefID = reader.GetGuid(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DWS_GDWSFT_1154_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DWS_GDWSFT_1154_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DWS_GDWSFT_1154_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DWS_GDWSFT_1154_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DWS_GDWSFT_1154_Array functionReturn = new FR_L5DWS_GDWSFT_1154_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);


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
	public class FR_L5DWS_GDWSFT_1154_Array : FR_Base
	{
		public L5DWS_GDWSFT_1154[] Result	{ get; set; } 
		public FR_L5DWS_GDWSFT_1154_Array() : base() {}

		public FR_L5DWS_GDWSFT_1154_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}
