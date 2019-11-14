/* 
 * Generated on 5/27/2014 3:14:02 PM
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
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using PlannicoModel.Models;
using CL5_VacationPlanner_Absence.Atomic.Retrieval;
using VacationPlannerCore.CustomClasses;
using CL5_VacationPlanner_LeaveRequest.Atomic.Retrieval;
using CLE_L5_PlannicoMobile_Events.Complex.Retrieval;
using CL5_VacationPlanner_Employees.Complex.Retrieval;

namespace CLE_L6_PlannicoMobile_LeaveRequest.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Validate_New_Leave.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Validate_New_Leave
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6LR_VNL_M_1429 Execute(DbConnection Connection,DbTransaction Transaction,P_L6LR_VNL_M_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6LR_VNL_M_1429();

            var calculationTimeframe = cls_Get_CalculationTimeFramesForTenant.Invoke(Connection, Transaction, securityTicket).Result.FirstOrDefault();
            #region  get events
            P_L5LR_EV_TSD_1047 param = new P_L5LR_EV_TSD_1047
            {
                EndDate = Parameter.EndDate,
                StartDate = Parameter.StartDate
            };
            var forbiddingEvents = cls_Get_Events_for_Timespan_Data.Invoke(Connection, Transaction, param, securityTicket).Result.Where(e => e.forbiddenLeaveTypes != null && e.forbiddenLeaveTypes.FirstOrDefault(f => f.CMN_BPT_STA_AbsenceReasonID == Parameter.AbsenceTypeID) != null);

            #endregion

            #region basic validation
            if (Parameter.ForPerson == Guid.Empty || Parameter.ForPerson == null)
            {
                returnValue.Result = new L6LR_VNL_M_1429 { isInvalidPerson = true };
                return returnValue;
            }
            else if (Parameter.AbsenceTypeID == Guid.Empty || Parameter.AbsenceTypeID == null)
            {
                returnValue.Result = new L6LR_VNL_M_1429 { isInvalidAbsenceReason = true };
                return returnValue;
            }
            if (Parameter.StartDate == Parameter.EndDate)
            {
                returnValue.Result = new L6LR_VNL_M_1429 { isSamedate = true };
                return returnValue;
            }
            if (Parameter.StartDate == DateTime.MinValue || Parameter.EndDate == DateTime.MinValue)
            {
                returnValue.Result = new L6LR_VNL_M_1429 { isInvalidDatePairGiven = true };
                return returnValue;
            }
            if (Parameter.EndDate < Parameter.EndDate)
            {
                returnValue.Result = new L6LR_VNL_M_1429 { isEndTimeLover = true };
                return returnValue;
            }
            #endregion basic validation

            var employeeAndLrData = cls_Get_Employees_And_LeaveRequestData_For_IDList.Invoke(Connection, Transaction, new P_L5EM_GEALRDFIDL_1138 { EmployeeIDList = new Guid[] { Parameter.ForPerson } }, securityTicket).Result.FirstOrDefault();
            var contract = employeeAndLrData.WorkingContract2LeaveRequest.FirstOrDefault(c => c.CMN_BPT_STA_AbsenceReasonID == Parameter.AbsenceTypeID);
            if (contract == null)
            {
                var reason = cls_get_Active_AbsenceReason_For_TenantID.Invoke(Connection,Transaction,securityTicket).Result.FirstOrDefault(r =>r.CMN_BPT_STA_AbsenceReasonID == Parameter.AbsenceTypeID);
                if (reason.IsAllowedAbsence)//WTF?
                {
                    returnValue.Result = new L6LR_VNL_M_1429 { isInvalidAbsenceReason = true };
                    return returnValue;
                }
                else
                {
                    if (forbiddingEvents.Count() > 0)
                    {
                        returnValue.Result = new L6LR_VNL_M_1429 { isIntersectingWithForbiddenEvent = true };
                        returnValue.Result.errorDaysInfo = new List<DateTime>();
                        returnValue.Result.errorDaysInfo.Add(forbiddingEvents.ToArray()[0].repetitions[0].Start);
                        return returnValue;
                    }
                    else
                    {
                        returnValue.Result = new L6LR_VNL_M_1429 { isValidationPassed = true };
                        return returnValue;
                    }
                }
            }

            var statistisParam = new P_L6LR_GLRS_M_1706
            {
                AbsenceResonID = Parameter.AbsenceTypeID,
                EndDate = Parameter.EndDate,
                ForPerson = Parameter.ForPerson,
                SavedLeaveDuration = 0,
                StartDate = Parameter.StartDate
            };
            var statistics = cls_Get_Leave_Statistics_Mobile.Invoke(Connection, Transaction, statistisParam, securityTicket).Result;
            if (statistics.PlannedAndTaken + statistics.ThisRequest > contract.ContractAllowedAbsence_per_Month + statistics.FromLastyear + statistics.adjustment && contract.IsAllowedAbsence)
            {
                returnValue.Result = new L6LR_VNL_M_1429 { isMoreDaysThanAllowed = true };
                return returnValue;
            }
            else if (forbiddingEvents.Count() > 0)
            {
                returnValue.Result = new L6LR_VNL_M_1429 { isIntersectingWithForbiddenEvent = true };
                return returnValue;
            }
            else
            {
                var p = new P_L5LR_GLRTFEAT_1634();
                p.EndTime = Parameter.EndDate;
                p.StartTime = Parameter.StartDate;
                p.EmployeeID = Parameter.ForPerson;
                var res = cls_Get_LeaveRequestsTimes_For_EmployeeAndTime.Invoke(Connection, Transaction, p, securityTicket).Result;

                if (res != null)
                {
                    returnValue.Result = new L6LR_VNL_M_1429 { isIntersectingWithLeaveRequest = true };
                    returnValue.Result.errorDaysInfo = new List<DateTime>();
                    returnValue.Result.errorDaysInfo.Add(res.StartTime);
                    returnValue.Result.errorDaysInfo.Add(res.EndTime);
                    return returnValue;
                }
            }

            returnValue.Result = new L6LR_VNL_M_1429 { isValidationPassed = true };
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6LR_VNL_M_1429 Invoke(string ConnectionString,P_L6LR_VNL_M_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6LR_VNL_M_1429 Invoke(DbConnection Connection,P_L6LR_VNL_M_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6LR_VNL_M_1429 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6LR_VNL_M_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6LR_VNL_M_1429 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6LR_VNL_M_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6LR_VNL_M_1429 functionReturn = new FR_L6LR_VNL_M_1429();
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

				throw new Exception("Exception occured in method cls_Validate_New_Leave",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6LR_VNL_M_1429 : FR_Base
	{
		public L6LR_VNL_M_1429 Result	{ get; set; }

		public FR_L6LR_VNL_M_1429() : base() {}

		public FR_L6LR_VNL_M_1429(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6LR_VNL_M_1429 for attribute P_L6LR_VNL_M_1429
		[DataContract]
		public class P_L6LR_VNL_M_1429 
		{
			//Standard type parameters
			[DataMember]
			public DateTime StartDate { get; set; } 
			[DataMember]
			public DateTime EndDate { get; set; } 
			[DataMember]
			public Guid ForPerson { get; set; } 
			[DataMember]
			public Guid AbsenceTypeID { get; set; } 
			[DataMember]
			public Guid LeaveID { get; set; } 

		}
		#endregion
		#region SClass L6LR_VNL_M_1429 for attribute L6LR_VNL_M_1429
		[DataContract]
		public class L6LR_VNL_M_1429 
		{
			//Standard type parameters
			[DataMember]
			public bool isIntersectingWithPlanningDetails { get; set; } 
			[DataMember]
			public bool isIntersectingWithLeaveRequest { get; set; } 
			[DataMember]
			public bool isValidationPassed { get; set; } 
			[DataMember]
			public bool isEndTimeLover { get; set; } 
			[DataMember]
			public bool isIntersectingWithForbiddenEvent { get; set; } 
			[DataMember]
			public bool isMoreDaysThanAllowed { get; set; } 
			[DataMember]
			public bool isInvalidDatePairGiven { get; set; } 
			[DataMember]
			public bool isInvalidAbsenceReason { get; set; } 
			[DataMember]
			public bool isInvalidPerson { get; set; } 
			[DataMember]
			public bool isSamedate { get; set; } 
			[DataMember]
			public List<DateTime> errorDaysInfo { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6LR_VNL_M_1429 cls_Validate_New_Leave(,P_L6LR_VNL_M_1429 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6LR_VNL_M_1429 invocationResult = cls_Validate_New_Leave.Invoke(connectionString,P_L6LR_VNL_M_1429 Parameter,securityTicket);
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
var parameter = new CLE_L6_PlannicoMobile_LeaveRequest.Complex.Retrieval.P_L6LR_VNL_M_1429();
parameter.StartDate = ...;
parameter.EndDate = ...;
parameter.ForPerson = ...;
parameter.AbsenceTypeID = ...;
parameter.LeaveID = ...;

*/
