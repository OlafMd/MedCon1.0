/* 
 * Generated on 03-Jan-14 15:22:40
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

namespace CL5_Plannico_ExtraWorkCalculations.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ExtraWorkCalculations_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ExtraWorkCalculations_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EW_GEWCFT_1546_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EW_GEWCFT_1546_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Plannico_ExtraWorkCalculations.Atomic.Retrieval.SQL.cls_Get_ExtraWorkCalculations_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L5EW_GEWCFT_1546> results = new List<L5EW_GEWCFT_1546>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_EMP_ExtraWorkCalculationID","ExtraWorkCalculation_Name_DictID","IsCalculatingOvertimeEnabled","AreAdditionalWorkDays_CalculatedIn_Hours","AreAdditionalWorkDays_CalculatedIn_DaysAsHours","AreAdditionalWorkDays_CalculatedIn_Days","StandardWorkDay_in_mins","IsDisplayedAs_HoursAsDays","IsDisplayedAs_DaysAndHours","MinimalOvertimeTreshold_in_minutes","BoundTo_Office_RefID","BoundTo_WorkArea_RefID","BoundTo_Workplace_RefID" });
				while(reader.Read())
				{
					L5EW_GEWCFT_1546 resultItem = new L5EW_GEWCFT_1546();
					//0:Parameter CMN_BPT_EMP_ExtraWorkCalculationID of type Guid
					resultItem.CMN_BPT_EMP_ExtraWorkCalculationID = reader.GetGuid(0);
					//1:Parameter ExtraWorkCalculation_Name of type Dict
					resultItem.ExtraWorkCalculation_Name = reader.GetDictionary(1);
					resultItem.ExtraWorkCalculation_Name.SourceTable = "cmn_bpt_emp_extraworkcalculations";
					loader.Append(resultItem.ExtraWorkCalculation_Name);
					//2:Parameter IsCalculatingOvertimeEnabled of type bool
					resultItem.IsCalculatingOvertimeEnabled = reader.GetBoolean(2);
					//3:Parameter AreAdditionalWorkDays_CalculatedIn_Hours of type bool
					resultItem.AreAdditionalWorkDays_CalculatedIn_Hours = reader.GetBoolean(3);
					//4:Parameter AreAdditionalWorkDays_CalculatedIn_DaysAsHours of type bool
					resultItem.AreAdditionalWorkDays_CalculatedIn_DaysAsHours = reader.GetBoolean(4);
					//5:Parameter AreAdditionalWorkDays_CalculatedIn_Days of type bool
					resultItem.AreAdditionalWorkDays_CalculatedIn_Days = reader.GetBoolean(5);
					//6:Parameter StandardWorkDay_in_mins of type int
					resultItem.StandardWorkDay_in_mins = reader.GetInteger(6);
					//7:Parameter IsDisplayedAs_HoursAsDays of type bool
					resultItem.IsDisplayedAs_HoursAsDays = reader.GetBoolean(7);
					//8:Parameter IsDisplayedAs_DaysAndHours of type bool
					resultItem.IsDisplayedAs_DaysAndHours = reader.GetBoolean(8);
					//9:Parameter MinimalOvertimeTreshold_in_minutes of type int
					resultItem.MinimalOvertimeTreshold_in_minutes = reader.GetInteger(9);
					//10:Parameter BoundTo_Office_RefID of type Guid
					resultItem.BoundTo_Office_RefID = reader.GetGuid(10);
					//11:Parameter BoundTo_WorkArea_RefID of type Guid
					resultItem.BoundTo_WorkArea_RefID = reader.GetGuid(11);
					//12:Parameter BoundTo_Workplace_RefID of type Guid
					resultItem.BoundTo_Workplace_RefID = reader.GetGuid(12);

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
		public static FR_L5EW_GEWCFT_1546_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EW_GEWCFT_1546_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EW_GEWCFT_1546_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EW_GEWCFT_1546_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EW_GEWCFT_1546_Array functionReturn = new FR_L5EW_GEWCFT_1546_Array();
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
	public class FR_L5EW_GEWCFT_1546_Array : FR_Base
	{
		public L5EW_GEWCFT_1546[] Result	{ get; set; } 
		public FR_L5EW_GEWCFT_1546_Array() : base() {}

		public FR_L5EW_GEWCFT_1546_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}
