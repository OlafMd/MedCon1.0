/* 
 * Generated on 5/20/2014 12:53:20 PM
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
using CL5_VacationPlanner_Employees.Complex.Retrieval;
using PlannicoModel.Models;
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Contract.Atomic.Retrieval;
using CLE_L5_PlannicoMobile_Events.Complex.Retrieval;
using CL5_VacationPlanner_Employees.Atomic.Retrieval;

namespace CLE_L6_PlannicoMobile_LeaveRequest.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Leave_Statistics_Mobile.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Leave_Statistics_Mobile
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6LR_GLRS_M_1706 Execute(DbConnection Connection,DbTransaction Transaction,P_L6LR_GLRS_M_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6LR_GLRS_M_1706();
            
            DateTime start = Parameter.StartDate;
            DateTime end = Parameter.EndDate;
            #region  get events
            P_L5LR_EV_TSD_1047 param = new P_L5LR_EV_TSD_1047()
            {
                EndDate = end,
                StartDate = start
            };
            L5LR_EV_TSD_1047[] Events = cls_Get_Events_for_Timespan_Data.Invoke(Connection, Transaction, param, securityTicket).Result;
            #endregion get events

            #region leave request duration
            var employeeAndLrData = cls_Get_Employees_And_LeaveRequestData_For_IDList.Invoke(Connection, Transaction, new P_L5EM_GEALRDFIDL_1138 { EmployeeIDList = new Guid[] { Parameter.ForPerson } }, securityTicket).Result.FirstOrDefault();
            L5_EM_GEWI_1628 intervalsActiveContract = cls_Get_Employee_WorktimeIntervals.Invoke(Connection, Transaction, securityTicket).Result.SingleOrDefault();
            
            double leaveDuration = new L6LR_GLR_ID_1339().duration(intervalsActiveContract, Events, Parameter.StartDate, Parameter.EndDate, employeeAndLrData.IsWorkTimeCalculated_InDays);
            
            #endregion leave request duration

            var contractToReason = employeeAndLrData.WorkingContract2LeaveRequest.Where(cr => cr.CMN_BPT_STA_AbsenceReasonID == Parameter.AbsenceResonID).FirstOrDefault();
            //var reasonsAndAdjustment = cls_Get_AbsenceReason_And_Adjustments_For_Employee.Invoke(Connection, Transaction, new P_L5EM_GARaAFE_1612 {AbsenceReason_ID = Parameter.AbsenceResonID }, securityTicket).Result;
            var calculationTimeframe = cls_Get_CalculationTimeFramesForTenant.Invoke(Connection, Transaction, securityTicket).Result.Where(x => x.CalculationTimeframe_StartDate.Year == Parameter.StartDate.Year).FirstOrDefault();
            P_L5EM_GEATFSbRTFE_1423 statisticsParameter = new P_L5EM_GEATFSbRTFE_1423
            {
                absenceReasonID = Parameter.AbsenceResonID,
                employeeID = Parameter.ForPerson,
                timeFrameID = calculationTimeframe.CMN_CAL_CalculationTimeframeID
            };
            L5EM_GEATFSbRTFE_1423 EmployeeStatistics = cls_Get_Employee_AbsenceReason_TimeframeStatistic_byReasonTimeFrameEmployee.Invoke(Connection, Transaction, statisticsParameter, securityTicket).Result;
            if (EmployeeStatistics == null)
            {
                EmployeeStatistics = new L5EM_GEATFSbRTFE_1423();
            }
            double adjustment = 0;
            if (contractToReason != null && contractToReason.Adjustments != null)
            {
                foreach (var adj in contractToReason.Adjustments)
                {
                    if (employeeAndLrData.IsWorkTimeCalculated_InDays)
                    {
                        adjustment += (double)adj.AbsenceTime_InMinutes / 60;
                        double hours = Math.Abs((double)adj.AbsenceTime_InMinutes / 60);
                        double days = 0;
                        while (hours > 0) 
                        {
                            foreach (var officehours in employeeAndLrData.WeeklyOfficeHours)
                            {
                                double dayDuration = (double)(officehours.TimeTo_InMinutes - officehours.TimeFrom_InMinutes) / 60;
                                hours -= dayDuration;
                                if (officehours.IsWholeDay)
                                {
                                    days +=1;
                                }else
	                            {
                                    days +=0.5;
	                            }
                                if (hours <= 0)
                                {
                                    break;
                                }
                            }
                        }
                        adjustment = days;
                    }
                    else
                    {
                        adjustment += (double)adj.AbsenceTime_InMinutes / 60;
                    }
                }
            }
            if (contractToReason == null)
            {
                contractToReason = new L5EM_GEALRDFIDL_1138_WorkingContract2LeaveRequest();//fuj
            }
            
            #region assign result
            L6LR_GLRS_M_1706 Result = null;
            if (employeeAndLrData.IsWorkTimeCalculated_InDays)
            {
                 Result = new L6LR_GLRS_M_1706
                {
                    FromLastyear = EmployeeStatistics.R_AbsenceCarryOver_InDays,
                    PlannedAndTaken = EmployeeStatistics.R_RequestReservedAbsence_InDays + EmployeeStatistics.R_AbsenceTimeUsed_InDays - Parameter.SavedLeaveDuration,

                    FromThisYear = contractToReason.ContractAllowedAbsence_per_Month,
                    ThisRequest = leaveDuration,
                    isAllowedAbsence = contractToReason.IsAllowedAbsence,
                    adjustment = adjustment,
                };
                 Result.Remaining = (Result.FromLastyear + Result.FromThisYear) - (Result.PlannedAndTaken + Result.ThisRequest + Math.Abs(Result.adjustment));
            }
            else
            {
                Result = new L6LR_GLRS_M_1706
                {
                    FromLastyear = EmployeeStatistics.R_AbsenceCarryOver_InHours,
                    PlannedAndTaken = EmployeeStatistics.R_RequestReservedAbsence_InHours + EmployeeStatistics.R_AbsenceTimeUsed_InHours - Parameter.SavedLeaveDuration,

                    FromThisYear = contractToReason.ContractAllowedAbsence_per_Month,
                    ThisRequest = leaveDuration,
                    isAllowedAbsence = contractToReason.IsAllowedAbsence,
                    adjustment = adjustment,
                };
                Result.Remaining = (Result.FromLastyear + Result.FromThisYear) - (Result.PlannedAndTaken + Result.ThisRequest + Math.Abs(Result.adjustment));
            }
            returnValue.Result = Result;
            #endregion assign result
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6LR_GLRS_M_1706 Invoke(string ConnectionString,P_L6LR_GLRS_M_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6LR_GLRS_M_1706 Invoke(DbConnection Connection,P_L6LR_GLRS_M_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6LR_GLRS_M_1706 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6LR_GLRS_M_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6LR_GLRS_M_1706 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6LR_GLRS_M_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6LR_GLRS_M_1706 functionReturn = new FR_L6LR_GLRS_M_1706();
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

				throw new Exception("Exception occured in method cls_Get_Leave_Statistics_Mobile",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6LR_GLRS_M_1706 : FR_Base
	{
		public L6LR_GLRS_M_1706 Result	{ get; set; }

		public FR_L6LR_GLRS_M_1706() : base() {}

		public FR_L6LR_GLRS_M_1706(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6LR_GLRS_M_1706 for attribute P_L6LR_GLRS_M_1706
		[DataContract]
		public class P_L6LR_GLRS_M_1706 
		{
			//Standard type parameters
			[DataMember]
			public DateTime StartDate { get; set; } 
			[DataMember]
			public DateTime EndDate { get; set; } 
			[DataMember]
			public Guid ForPerson { get; set; } 
			[DataMember]
			public Guid AbsenceResonID { get; set; } 
			[DataMember]
			public double SavedLeaveDuration { get; set; } 

		}
		#endregion
		#region SClass L6LR_GLRS_M_1706 for attribute L6LR_GLRS_M_1706
		[DataContract]
		public class L6LR_GLRS_M_1706 
		{
			//Standard type parameters
			[DataMember]
			public double FromLastyear { get; set; } 
			[DataMember]
			public double FromThisYear { get; set; } 
			[DataMember]
			public double adjustment { get; set; } 
			[DataMember]
			public double PlannedAndTaken { get; set; } 
			[DataMember]
			public double ThisRequest { get; set; } 
			[DataMember]
			public double Remaining { get; set; } 
			[DataMember]
			public bool isAllowedAbsence { get; set; } 
			[DataMember]
			public double savedLeaveDuration { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6LR_GLRS_M_1706 cls_Get_Leave_Statistics_Mobile(,P_L6LR_GLRS_M_1706 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6LR_GLRS_M_1706 invocationResult = cls_Get_Leave_Statistics_Mobile.Invoke(connectionString,P_L6LR_GLRS_M_1706 Parameter,securityTicket);
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
var parameter = new CLE_L6_PlannicoMobile_LeaveRequest.Complex.Retrieval.P_L6LR_GLRS_M_1706();
parameter.StartDate = ...;
parameter.EndDate = ...;
parameter.ForPerson = ...;
parameter.AbsenceResonID = ...;
parameter.SavedLeaveDuration = ...;

*/
