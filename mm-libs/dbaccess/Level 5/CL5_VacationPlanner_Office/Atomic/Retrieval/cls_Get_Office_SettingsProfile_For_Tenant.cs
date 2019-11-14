/* 
 * Generated on 14-Nov-13 10:37:15
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

namespace CL5_VacationPlanner_Office.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Office_SettingsProfile_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Office_SettingsProfile_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OF_GOSPFT_1325_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OF_GOSPFT_1325_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Office.Atomic.Retrieval.SQL.cls_Get_Office_SettingsProfile_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L5OF_GOSPFT_1325> results = new List<L5OF_GOSPFT_1325>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_STR_Office_SettingsProfileID","Office_RefID","AdulthoodAge","RestMinimumThresholdl_NonAdults_in_mins","RestWarningThreshold_NonAdults_in_mins","RestWarningThreshold_Adults_in_mins","RestMinimumThresholdl_Adults_in_mins","WorkTimeWarningTreshold_Adults_in_mins","WorkTimeWarningTreshold_NonAdults_in_mins","WorkTimeMaximumTreshold_Adults_in_mins","WorkTimeMaximumTreshold_NonAdults_in_mins","WorkStartTimeWarning_NonAdults_in_mins","WorkStartTimeMinimum_NonAdults_in_mins","WorkEndTimeWarning_NonAdults_in_mins","WorkEndTimeMaximum_NonAdults_in_mins","WorktimeBalancePeriod_in_months","WorkdayStart_in_mins","RoosterGridMinimumPlanningUnit_in_mins","MaximumPreWork_Period_in_mins","MaximumPostWork_Period_in_mins" });
				while(reader.Read())
				{
					L5OF_GOSPFT_1325 resultItem = new L5OF_GOSPFT_1325();
					//0:Parameter CMN_BPT_STR_Office_SettingsProfileID of type Guid
					resultItem.CMN_BPT_STR_Office_SettingsProfileID = reader.GetGuid(0);
					//1:Parameter Office_RefID of type Guid
					resultItem.Office_RefID = reader.GetGuid(1);
					//2:Parameter AdulthoodAge of type int
					resultItem.AdulthoodAge = reader.GetInteger(2);
					//3:Parameter RestMinimumThresholdl_NonAdults_in_mins of type int
					resultItem.RestMinimumThresholdl_NonAdults_in_mins = reader.GetInteger(3);
					//4:Parameter RestWarningThreshold_NonAdults_in_mins of type int
					resultItem.RestWarningThreshold_NonAdults_in_mins = reader.GetInteger(4);
					//5:Parameter RestWarningThreshold_Adults_in_mins of type int
					resultItem.RestWarningThreshold_Adults_in_mins = reader.GetInteger(5);
					//6:Parameter RestMinimumThresholdl_Adults_in_mins of type int
					resultItem.RestMinimumThresholdl_Adults_in_mins = reader.GetInteger(6);
					//7:Parameter WorkTimeWarningTreshold_Adults_in_mins of type int
					resultItem.WorkTimeWarningTreshold_Adults_in_mins = reader.GetInteger(7);
					//8:Parameter WorkTimeWarningTreshold_NonAdults_in_mins of type int
					resultItem.WorkTimeWarningTreshold_NonAdults_in_mins = reader.GetInteger(8);
					//9:Parameter WorkTimeMaximumTreshold_Adults_in_mins of type int
					resultItem.WorkTimeMaximumTreshold_Adults_in_mins = reader.GetInteger(9);
					//10:Parameter WorkTimeMaximumTreshold_NonAdults_in_mins of type int
					resultItem.WorkTimeMaximumTreshold_NonAdults_in_mins = reader.GetInteger(10);
					//11:Parameter WorkStartTimeWarning_NonAdults_in_mins of type int
					resultItem.WorkStartTimeWarning_NonAdults_in_mins = reader.GetInteger(11);
					//12:Parameter WorkStartTimeMinimum_NonAdults_in_mins of type int
					resultItem.WorkStartTimeMinimum_NonAdults_in_mins = reader.GetInteger(12);
					//13:Parameter WorkEndTimeWarning_NonAdults_in_mins of type int
					resultItem.WorkEndTimeWarning_NonAdults_in_mins = reader.GetInteger(13);
					//14:Parameter WorkEndTimeMaximum_NonAdults_in_mins of type int
					resultItem.WorkEndTimeMaximum_NonAdults_in_mins = reader.GetInteger(14);
					//15:Parameter WorktimeBalancePeriod_in_months of type int
					resultItem.WorktimeBalancePeriod_in_months = reader.GetInteger(15);
					//16:Parameter WorkdayStart_in_mins of type int
					resultItem.WorkdayStart_in_mins = reader.GetInteger(16);
					//17:Parameter RoosterGridMinimumPlanningUnit_in_mins of type int
					resultItem.RoosterGridMinimumPlanningUnit_in_mins = reader.GetInteger(17);
					//18:Parameter MaximumPreWork_Period_in_mins of type int
					resultItem.MaximumPreWork_Period_in_mins = reader.GetInteger(18);
					//19:Parameter MaximumPostWork_Period_in_mins of type int
					resultItem.MaximumPostWork_Period_in_mins = reader.GetInteger(19);

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
		public static FR_L5OF_GOSPFT_1325_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OF_GOSPFT_1325_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OF_GOSPFT_1325_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OF_GOSPFT_1325_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OF_GOSPFT_1325_Array functionReturn = new FR_L5OF_GOSPFT_1325_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OF_GOSPFT_1325_Array : FR_Base
	{
		public L5OF_GOSPFT_1325[] Result	{ get; set; } 
		public FR_L5OF_GOSPFT_1325_Array() : base() {}

		public FR_L5OF_GOSPFT_1325_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}
