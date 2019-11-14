/* 
 * Generated on 23/08/2014 15:17:21
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
using CL1_CMN_CAL;
using CL1_CMN_BPT_EMP;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Tenant.Complex.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Open_TimeFrame.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Open_TimeFrame
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
        protected static FR_Base Execute(DbConnection Connection, DbTransaction Transaction, P_L5TN_OTF_1516 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Base();
            //Put your code here

            ORM_CMN_CAL_CalculationTimeframe.Query timeFrameQuery = new ORM_CMN_CAL_CalculationTimeframe.Query();
            timeFrameQuery.Tenant_RefID = securityTicket.TenantID;
            timeFrameQuery.IsDeleted = false;
            var timeFrames = ORM_CMN_CAL_CalculationTimeframe.Query.Search(Connection, Transaction, timeFrameQuery);
            if (timeFrames != null && timeFrames.Any(x => x.CalculationTimeframe_StartDate.Year == Parameter.year) && timeFrames.Any(x => x.CalculationTimeframe_StartDate.Year == Parameter.year + 1))
            {
                var timeFrame = timeFrames.First(x => x.CalculationTimeframe_StartDate.Year == Parameter.year);
                var nextTimeFrame = timeFrames.First(x => x.CalculationTimeframe_StartDate.Year == Parameter.year + 1);
                ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic.Query employeeAbsenceTimeFrameSatisticQuery = new ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic.Query();
                employeeAbsenceTimeFrameSatisticQuery.CalculationTimeframe_RefID = timeFrame.CMN_CAL_CalculationTimeframeID;
                employeeAbsenceTimeFrameSatisticQuery.Tenant_RefID = securityTicket.TenantID;
                employeeAbsenceTimeFrameSatisticQuery.IsDeleted = false;
                var employeeAbsenceTimeFrameSatistics = ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic.Query.Search(Connection, Transaction, employeeAbsenceTimeFrameSatisticQuery);
                if (employeeAbsenceTimeFrameSatistics != null)
                {
                    foreach (var previousEmployeeAbsenceTimeFrameSatistic in employeeAbsenceTimeFrameSatistics)
                    {
                        ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic.Query currentEmployeeAbsenceTimeFrameSatisticQuery = new ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic.Query();
                        currentEmployeeAbsenceTimeFrameSatisticQuery.AbsenceReason_RefID = previousEmployeeAbsenceTimeFrameSatistic.AbsenceReason_RefID;
                        currentEmployeeAbsenceTimeFrameSatisticQuery.Employee_RefID = previousEmployeeAbsenceTimeFrameSatistic.Employee_RefID;
                        currentEmployeeAbsenceTimeFrameSatisticQuery.Tenant_RefID = securityTicket.TenantID;
                        currentEmployeeAbsenceTimeFrameSatisticQuery.IsDeleted = false;
                        currentEmployeeAbsenceTimeFrameSatisticQuery.CalculationTimeframe_RefID = nextTimeFrame.CMN_CAL_CalculationTimeframeID;
                        var currentEmployeeAbsenceTimeFrameSatistics = ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic.Query.Search(Connection, Transaction, currentEmployeeAbsenceTimeFrameSatisticQuery);
                        if (currentEmployeeAbsenceTimeFrameSatistics != null)
                        {
                            foreach (var currentEmployeeAbsenceTimeFrameSatistic in currentEmployeeAbsenceTimeFrameSatistics)
                            {
                                currentEmployeeAbsenceTimeFrameSatistic.R_AbsenceCarryOver_InDays = 0;
                                currentEmployeeAbsenceTimeFrameSatistic.R_AbsenceCarryOver_InHours = 0;
                                currentEmployeeAbsenceTimeFrameSatistic.Save(Connection, Transaction);
                            }
                        }
                    }
                }
                timeFrame.CalculationTimefrate_EndDate = new DateTime(0);
                timeFrame.Save(Connection, Transaction);
            }
                return returnValue;
            #endregion UserCode
            }
        
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5TN_OTF_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5TN_OTF_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TN_OTF_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TN_OTF_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Open_TimeFrame",ex);
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
FR_Base cls_Open_TimeFrame(,P_L5TN_OTF_1516 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Open_TimeFrame.Invoke(connectionString,P_L5TN_OTF_1516 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Tenant.Complex.Manipulation.P_L5TN_OTF_1516();
parameter.year = ...;

*/
