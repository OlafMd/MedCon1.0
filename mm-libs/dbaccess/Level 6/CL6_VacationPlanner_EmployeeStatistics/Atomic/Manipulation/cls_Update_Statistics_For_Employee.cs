/* 
 * Generated on 8/30/2013 11:25:06 AM
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
using CL5_VacationPlanner_Contract.Atomic.Manipulation;

namespace CL6_VacationPlanner_EmployeeStatistics.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Update_Statistics_For_Employee.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Update_Statistics_For_Employee
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6ES_USFE_1220 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            foreach (var absenceReason in Parameter.AbsenceReasons)
            {
                ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic.Query statisticQuery = new ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic.Query();
                statisticQuery.Employee_RefID = Parameter.EmployeeID;
                statisticQuery.AbsenceReason_RefID = absenceReason.AbsenceReasonID;
                ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic[] statistics = ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic.Query.Search(Connection, Transaction, statisticQuery).ToArray();
                foreach (var statistic in statistics)
                {
                    P_L5EM_SEARTFS_1356 statisticsPar = new P_L5EM_SEARTFS_1356();
                    statisticsPar.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID = statistic.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID;
                    statisticsPar.AbsenceReason_RefID = statistic.AbsenceReason_RefID;
                    statisticsPar.CalculationTimeframe_RefID = statistic.CalculationTimeframe_RefID;
                    statisticsPar.Employee_RefID = Parameter.EmployeeID;
                    statisticsPar.R_AbsenceCarryOver_InDays = statistic.R_AbsenceCarryOver_InDays;
                    statisticsPar.R_AbsenceCarryOver_InHours = statistic.R_AbsenceCarryOver_InHours;
                    statisticsPar.R_AbsenceTimeUsed_InDays = statistic.R_AbsenceTimeUsed_InDays;
                    statisticsPar.R_AbsenceTimeUsed_InHours = statistic.R_AbsenceTimeUsed_InHours;
                    statisticsPar.R_TotalAllowedAbsenceTime_InDays = absenceReason.TotalAllowedAbsenceInDays;
                    statisticsPar.R_TotalAllowedAbsenceTime_InHours = absenceReason.TotalAllowedAbsenceInHours;
                    cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, statisticsPar, securityTicket);
                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6ES_USFE_1220 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6ES_USFE_1220 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6ES_USFE_1220 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6ES_USFE_1220 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Update_Statistics_For_Employee",ex);
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
FR_Guid cls_Update_Statistics_For_Employee(,P_L6ES_USFE_1220 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Update_Statistics_For_Employee.Invoke(connectionString,P_L6ES_USFE_1220 Parameter,securityTicket);
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
var parameter = new CL6_VacationPlanner_EmployeeStatistics.Atomic.Manipulation.P_L6ES_USFE_1220();
parameter.AbsenceReasons = ...;

parameter.EmployeeID = ...;

*/