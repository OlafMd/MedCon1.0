/* 
 * Generated on 8/26/2013 11:42:38 AM
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

namespace CL5_VacationPlanner_Contract.Atomic.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Employee_AbsenceReason_TimeframeStatistic_byReasonTimeFrameEmployee.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Employee_AbsenceReason_TimeframeStatistic_byReasonTimeFrameEmployee
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEATFSbRTFE_1423 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_GEATFSbRTFE_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EM_GEATFSbRTFE_1423();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Contract.Atomic.Retrieval.SQL.cls_Get_Employee_AbsenceReason_TimeframeStatistic_byReasonTimeFrameEmployee.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"employeeID", Parameter.employeeID);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"timeFrameID", Parameter.timeFrameID);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"absenceReasonID", Parameter.absenceReasonID);


			List<L5EM_GEATFSbRTFE_1423> results = new List<L5EM_GEATFSbRTFE_1423>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID","CalculationTimeframe_RefID","Employee_RefID","AbsenceReason_RefID","R_AbsenceCarryOver_InHours","R_AbsenceCarryOver_InDays","R_AbsenceTimeUsed_InHours","R_AbsenceTimeUsed_InDays","R_RequestReservedAbsence_InHours","R_RequestReservedAbsence_InDays","R_TotalAllowedAbsenceTime_InHours","R_TotalAllowedAbsenceTime_InDays" });
				while(reader.Read())
				{
					L5EM_GEATFSbRTFE_1423 resultItem = new L5EM_GEATFSbRTFE_1423();
					//0:Parameter CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID of type Guid
					resultItem.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID = reader.GetGuid(0);
					//1:Parameter CalculationTimeframe_RefID of type Guid
					resultItem.CalculationTimeframe_RefID = reader.GetGuid(1);
					//2:Parameter Employee_RefID of type Guid
					resultItem.Employee_RefID = reader.GetGuid(2);
					//3:Parameter AbsenceReason_RefID of type Guid
					resultItem.AbsenceReason_RefID = reader.GetGuid(3);
					//4:Parameter R_AbsenceCarryOver_InHours of type double
					resultItem.R_AbsenceCarryOver_InHours = reader.GetDouble(4);
					//5:Parameter R_AbsenceCarryOver_InDays of type double
					resultItem.R_AbsenceCarryOver_InDays = reader.GetDouble(5);
					//6:Parameter R_AbsenceTimeUsed_InHours of type double
					resultItem.R_AbsenceTimeUsed_InHours = reader.GetDouble(6);
					//7:Parameter R_AbsenceTimeUsed_InDays of type double
					resultItem.R_AbsenceTimeUsed_InDays = reader.GetDouble(7);
					//8:Parameter R_RequestReservedAbsence_InHours of type double
					resultItem.R_RequestReservedAbsence_InHours = reader.GetDouble(8);
					//9:Parameter R_RequestReservedAbsence_InDays of type double
					resultItem.R_RequestReservedAbsence_InDays = reader.GetDouble(9);
					//10:Parameter R_TotalAllowedAbsenceTime_InHours of type double
					resultItem.R_TotalAllowedAbsenceTime_InHours = reader.GetDouble(10);
					//11:Parameter R_TotalAllowedAbsenceTime_InDays of type double
					resultItem.R_TotalAllowedAbsenceTime_InDays = reader.GetDouble(11);

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

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EM_GEATFSbRTFE_1423 Invoke(string ConnectionString,P_L5EM_GEATFSbRTFE_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEATFSbRTFE_1423 Invoke(DbConnection Connection,P_L5EM_GEATFSbRTFE_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEATFSbRTFE_1423 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_GEATFSbRTFE_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEATFSbRTFE_1423 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_GEATFSbRTFE_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEATFSbRTFE_1423 functionReturn = new FR_L5EM_GEATFSbRTFE_1423();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEATFSbRTFE_1423 : FR_Base
	{
		public L5EM_GEATFSbRTFE_1423 Result	{ get; set; }

		public FR_L5EM_GEATFSbRTFE_1423() : base() {}

		public FR_L5EM_GEATFSbRTFE_1423(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GEATFSbRTFE_1423 cls_Get_Employee_AbsenceReason_TimeframeStatistic_byReasonTimeFrameEmployee(P_L5EM_GEATFSbRTFE_1423 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5EM_GEATFSbRTFE_1423 result = cls_Get_Employee_AbsenceReason_TimeframeStatistic_byReasonTimeFrameEmployee.Invoke(connectionString,P_L5EM_GEATFSbRTFE_1423 Parameter,securityTicket);
	 return result;
}
*/