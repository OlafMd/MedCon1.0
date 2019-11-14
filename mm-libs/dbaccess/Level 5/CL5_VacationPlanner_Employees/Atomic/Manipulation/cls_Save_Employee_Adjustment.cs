/* 
 * Generated on 1/16/2014 10:59:16 AM
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
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using CL1_CMN_CAL;
using CL5_VacationPlanner_Employees.Complex.Retrieval;
using CL5_VacationPlanner_Employees.Atomic.Retrieval;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Employee_Adjustment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Employee_Adjustment
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_SEA_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();




            ORM_CMN_BPT_EMP_ContractAbsenceAdjustment adjustment = new ORM_CMN_BPT_EMP_ContractAbsenceAdjustment();
            if (Parameter.AdjustmentID != Guid.Empty)
            {
                var result = adjustment.Load(Connection, Transaction, Parameter.AdjustmentID);
                if (result.Status != FR_Status.Success || adjustment.CMN_BPT_EMP_ContractAbsenceAdjustmentID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            Guid workingContractTimeFrameID = Guid.Empty;
            var timeFrame = cls_Get_CalculationTimeFramesForTenant.Invoke(Connection, Transaction, securityTicket).Result.Where(x => x.CalculationTimeframe_StartDate.Year == Parameter.Year).FirstOrDefault();
            if (timeFrame == null)
            {
                ORM_CMN_CAL_CalculationTimeframe timeFramePar = new ORM_CMN_CAL_CalculationTimeframe();
                timeFramePar.CalculationTimeframe_StartDate = new DateTime(Parameter.Year, 1, 1);
                timeFramePar.CalculationTimefrate_EndDate = new DateTime(0);
                timeFramePar.CalculationTimeframe_EstimatedEndDate = new DateTime(Parameter.Year, 12, 31);
                timeFramePar.IsCalculationTimeframe_Active = false;
                timeFramePar.Tenant_RefID = securityTicket.TenantID;
                timeFramePar.Save(Connection, Transaction);
                L5EM_GEFT_0959[] employees = cls_Get_Employees_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                foreach (var emp in employees)
                {
                    ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe workingContractTimeFrame = new ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe();
                    workingContractTimeFrame.CalculationTimeframe_RefID = timeFramePar.CMN_CAL_CalculationTimeframeID;
                    workingContractTimeFrame.EmploymentRelationship_RefID = emp.CMN_BPT_EMP_EmploymentRelationshipID;
                    workingContractTimeFrame.Tenant_RefID = securityTicket.TenantID;
                    workingContractTimeFrame.Save(Connection, Transaction);
                    if (emp.CMN_BPT_EMP_EmployeeID == Parameter.EmployeeID)
                        workingContractTimeFrameID = workingContractTimeFrame.CMN_BPT_EMP_EmploymentRelationship_TimeframeID;
                }
            }
            else
            {
                P_L5EM_GERTFFETF_1129 param = new P_L5EM_GERTFFETF_1129();
                param.EmployeeID = Parameter.EmployeeID;
                param.CalculationTimeframeID = timeFrame.CMN_CAL_CalculationTimeframeID;
                L5EM_GERTFFETF_1129 workingContractTimeFrame = cls_Get_EmploymentRelationshipTimeFrame_For_Employee_And_TimeFrame.Invoke(Connection, Transaction, param, securityTicket).Result;
                if (workingContractTimeFrame == null)
                {
                    P_L5EM_GEFE_1150 empPar = new P_L5EM_GEFE_1150();
                    empPar.EmployeeID = Parameter.EmployeeID;
                    L5EM_GEFE_1150 employee = cls_Get_Employee_For_EmployeeID.Invoke(Connection, Transaction, empPar, securityTicket).Result;
                    ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe workingContractTimeFrameNew = new ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe();
                    workingContractTimeFrameNew.CalculationTimeframe_RefID = timeFrame.CMN_CAL_CalculationTimeframeID;
                    workingContractTimeFrameNew.EmploymentRelationship_RefID = employee.CMN_BPT_EMP_EmploymentRelationshipID;
                    workingContractTimeFrameNew.Tenant_RefID = securityTicket.TenantID;
                    workingContractTimeFrameNew.Save(Connection, Transaction);
                    workingContractTimeFrameID = workingContractTimeFrameNew.CMN_BPT_EMP_EmploymentRelationship_TimeframeID;
                }
                else
                    workingContractTimeFrameID = workingContractTimeFrame.CMN_BPT_EMP_EmploymentRelationship_TimeframeID;
            }
            adjustment.AbsenceTime_InMinutes = Parameter.AbsenceTimeInMinutes;
            adjustment.AdjustmentComment = Parameter.AdjustmentComment;
            adjustment.AbsenceReason_RefID = Parameter.AbsenceReasonID;
            adjustment.EmploymentRelationship_Timeframe_RefID = workingContractTimeFrameID;
            adjustment.IsManual = Parameter.isManual;
            adjustment.InternalAdjustmentType = Parameter.InternalAdjustmentType;
            adjustment.TriggeringAccount_RefID = securityTicket.AccountID;
            adjustment.AdjustmentDate = Parameter.AdjustmentDate;
            adjustment.Tenant_RefID = securityTicket.TenantID;
            adjustment.IsDeleted = Parameter.isDeleted;
            adjustment.Save(Connection, Transaction);
            returnValue.Result = adjustment.CMN_BPT_EMP_ContractAbsenceAdjustmentID;
            //Put your code here
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EM_SEA_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EM_SEA_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_SEA_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_SEA_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
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
FR_Guid cls_Save_Employee_Adjustment(P_L5EM_SEA_1409 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_Employee_Adjustment.Invoke(connectionString,P_L5EM_SEA_1409 Parameter,securityTicket);
	 return result;
}
*/