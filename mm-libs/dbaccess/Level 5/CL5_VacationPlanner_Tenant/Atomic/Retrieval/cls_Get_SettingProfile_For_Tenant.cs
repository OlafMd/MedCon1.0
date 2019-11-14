/* 
 * Generated on 13-Nov-13 16:17:31
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

namespace CL5_VacationPlanner_Tenant.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_SettingProfile_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_SettingProfile_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TN_GSPFT_1044_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TN_GSPFT_1044_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Tenant.Atomic.Retrieval.SQL.cls_Get_SettingProfile_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L5TN_GSPFT_1044> results = new List<L5TN_GSPFT_1044>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_STA_SettingProfileID","IsLeaveTimeCalculated_InDays","StafMember_Caption_DictID","IsLeaveTimeCalculated_InHours","IsUsingWorkflow_ForLeaveRequests","Default_AdulthoodAge","Default_RestWarningThreshold_Adults_in_mins","Default_RestWarningThreshold_NonAdults_in_mins","Default_RestMinimumThresholdl_Adults_in_mins","Default_RestMinimumThresholdl_NonAdults_in_mins","Default_WorkTimeWarningTreshold_Adults_in_mins","Default_WorkTimeWarningTreshold_NonAdults_in_mins","Default_WorkTimeMaximumTreshold_Adults_in_mins","Default_WorkTimeMaximumTreshold_NonAdults_in_mins","Default_WorkStartTimeWarning_NonAdults_in_mins","Default_WorkStartTimeMinimum_NonAdults_in_mins","Default_WorkEndTimeWarning_NonAdults_in_mins","Default_WorktimeBalancePeriod_in_months","Default_WorkEndTimeMaximum_NonAdults_in_mins","Default_WorkdayStart_in_mins","Default_RoosterGridMinimumPlanningUnit_in_mins","Default_MaximumPreWork_Period_in_mins","Default_MaximumPostWork_Period_in_mins","Default_SurchargeCalculation_UseMaximum","Default_SurchargeCalculation_UseAccumulated" });
				while(reader.Read())
				{
					L5TN_GSPFT_1044 resultItem = new L5TN_GSPFT_1044();
					//0:Parameter CMN_BPT_STA_SettingProfileID of type Guid
					resultItem.CMN_BPT_STA_SettingProfileID = reader.GetGuid(0);
					//1:Parameter IsLeaveTimeCalculated_InDays of type bool
					resultItem.IsLeaveTimeCalculated_InDays = reader.GetBoolean(1);
					//2:Parameter StafMember_Caption of type Dict
					resultItem.StafMember_Caption = reader.GetDictionary(2);
					resultItem.StafMember_Caption.SourceTable = "cmn_bpt_sta_settingprofiles";
					loader.Append(resultItem.StafMember_Caption);
					//3:Parameter IsLeaveTimeCalculated_InHours of type bool
					resultItem.IsLeaveTimeCalculated_InHours = reader.GetBoolean(3);
					//4:Parameter IsUsingWorkflow_ForLeaveRequests of type bool
					resultItem.IsUsingWorkflow_ForLeaveRequests = reader.GetBoolean(4);
					//5:Parameter Default_AdulthoodAge of type int
					resultItem.Default_AdulthoodAge = reader.GetInteger(5);
					//6:Parameter Default_RestWarningThreshold_Adults_in_mins of type int
					resultItem.Default_RestWarningThreshold_Adults_in_mins = reader.GetInteger(6);
					//7:Parameter Default_RestWarningThreshold_NonAdults_in_mins of type int
					resultItem.Default_RestWarningThreshold_NonAdults_in_mins = reader.GetInteger(7);
					//8:Parameter Default_RestMinimumThresholdl_Adults_in_mins of type int
					resultItem.Default_RestMinimumThresholdl_Adults_in_mins = reader.GetInteger(8);
					//9:Parameter Default_RestMinimumThresholdl_NonAdults_in_mins of type int
					resultItem.Default_RestMinimumThresholdl_NonAdults_in_mins = reader.GetInteger(9);
					//10:Parameter Default_WorkTimeWarningTreshold_Adults_in_mins of type int
					resultItem.Default_WorkTimeWarningTreshold_Adults_in_mins = reader.GetInteger(10);
					//11:Parameter Default_WorkTimeWarningTreshold_NonAdults_in_mins of type int
					resultItem.Default_WorkTimeWarningTreshold_NonAdults_in_mins = reader.GetInteger(11);
					//12:Parameter Default_WorkTimeMaximumTreshold_Adults_in_mins of type int
					resultItem.Default_WorkTimeMaximumTreshold_Adults_in_mins = reader.GetInteger(12);
					//13:Parameter Default_WorkTimeMaximumTreshold_NonAdults_in_mins of type int
					resultItem.Default_WorkTimeMaximumTreshold_NonAdults_in_mins = reader.GetInteger(13);
					//14:Parameter Default_WorkStartTimeWarning_NonAdults_in_mins of type int
					resultItem.Default_WorkStartTimeWarning_NonAdults_in_mins = reader.GetInteger(14);
					//15:Parameter Default_WorkStartTimeMinimum_NonAdults_in_mins of type int
					resultItem.Default_WorkStartTimeMinimum_NonAdults_in_mins = reader.GetInteger(15);
					//16:Parameter Default_WorkEndTimeWarning_NonAdults_in_mins of type int
					resultItem.Default_WorkEndTimeWarning_NonAdults_in_mins = reader.GetInteger(16);
					//17:Parameter Default_WorktimeBalancePeriod_in_months of type int
					resultItem.Default_WorktimeBalancePeriod_in_months = reader.GetInteger(17);
					//18:Parameter Default_WorkEndTimeMaximum_NonAdults_in_mins of type int
					resultItem.Default_WorkEndTimeMaximum_NonAdults_in_mins = reader.GetInteger(18);
					//19:Parameter Default_WorkdayStart_in_mins of type int
					resultItem.Default_WorkdayStart_in_mins = reader.GetInteger(19);
					//20:Parameter Default_RoosterGridMinimumPlanningUnit_in_mins of type int
					resultItem.Default_RoosterGridMinimumPlanningUnit_in_mins = reader.GetInteger(20);
					//21:Parameter Default_MaximumPreWork_Period_in_mins of type int
					resultItem.Default_MaximumPreWork_Period_in_mins = reader.GetInteger(21);
					//22:Parameter Default_MaximumPostWork_Period_in_mins of type int
					resultItem.Default_MaximumPostWork_Period_in_mins = reader.GetInteger(22);
					//23:Parameter Default_SurchargeCalculation_UseMaximum of type bool
					resultItem.Default_SurchargeCalculation_UseMaximum = reader.GetBoolean(23);
					//24:Parameter Default_SurchargeCalculation_UseAccumulated of type bool
					resultItem.Default_SurchargeCalculation_UseAccumulated = reader.GetBoolean(24);

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
		public static FR_L5TN_GSPFT_1044_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TN_GSPFT_1044_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TN_GSPFT_1044_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TN_GSPFT_1044_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TN_GSPFT_1044_Array functionReturn = new FR_L5TN_GSPFT_1044_Array();
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
	public class FR_L5TN_GSPFT_1044_Array : FR_Base
	{
		public L5TN_GSPFT_1044[] Result	{ get; set; } 
		public FR_L5TN_GSPFT_1044_Array() : base() {}

		public FR_L5TN_GSPFT_1044_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}
