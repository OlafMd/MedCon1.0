/* 
 * Generated on 12/12/2013 2:25:54 PM
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
using CL1_CMN_PPS;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_HealthInsurances.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_BreakModel.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_BreakModel
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5BR_SBM_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_CMN_PPS_BreakTime_Template breakTimeTemplate = new ORM_CMN_PPS_BreakTime_Template();
            if (Parameter.CMN_PPS_BreakTime_TemplateID != Guid.Empty)
            {
                var result = breakTimeTemplate.Load(Connection, Transaction, Parameter.CMN_PPS_BreakTime_TemplateID);
                if (result.Status != FR_Status.Success || breakTimeTemplate.CMN_PPS_BreakTime_TemplateID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            breakTimeTemplate.BreakTimeTemplate_Name = Parameter.BreakTimeTemplate_Name_DictID;
            breakTimeTemplate.Tenant_RefID = securityTicket.TenantID;
            breakTimeTemplate.BoundTo_Office_RefID = Parameter.Office_RefID;
            breakTimeTemplate.BoundTo_Workarea_RefID = Parameter.Workarea_RefID;
            breakTimeTemplate.BoundTo_Workplace_RefID = Parameter.Workplace_RefID;
            breakTimeTemplate.Save(Connection, Transaction);

     
            ORM_CMN_PPS_BreakTime_Template_Assignment.Query breakeTimeAssigmentQuery = new ORM_CMN_PPS_BreakTime_Template_Assignment.Query();
            breakeTimeAssigmentQuery.IsDeleted = false;
            breakeTimeAssigmentQuery.Tenant_RefID = securityTicket.TenantID;
            breakeTimeAssigmentQuery.BreakTime_Template_RefID = breakTimeTemplate.CMN_PPS_BreakTime_TemplateID;
            List<ORM_CMN_PPS_BreakTime_Template_Assignment> breakTimeAssignemnts = ORM_CMN_PPS_BreakTime_Template_Assignment.Query.Search(Connection, Transaction, breakeTimeAssigmentQuery);

            List<ORM_CMN_PPS_BreakTime> breakTimes = new List<ORM_CMN_PPS_BreakTime>();
            if(breakTimeAssignemnts!=null)
            foreach (var breakTimeAssignment in breakTimeAssignemnts)
            {
                ORM_CMN_PPS_BreakTime breakTime = new ORM_CMN_PPS_BreakTime();
                breakTime.Load(Connection, Transaction, breakTimeAssignment.BreakTime_RefID);
                breakTimes.Add(breakTime);
            }
            
            if (Parameter.BreakfestDuration != 0)
            {
                if (breakTimes.Any(i => i.IsBreakfastBreak))
                {
                    ORM_CMN_PPS_BreakTime breakTime = breakTimes.FirstOrDefault(i => i.IsBreakfastBreak);
                    breakTime.Default_Duration_in_sec = Parameter.BreakfestDuration;
                    breakTime.Save(Connection, Transaction);
                }
                else
                {
                    ORM_CMN_PPS_BreakTime breakTime = new ORM_CMN_PPS_BreakTime();
                    breakTime.Default_Duration_in_sec = Parameter.BreakfestDuration;
                    breakTime.IsBreakfastBreak = true;
                    breakTime.Tenant_RefID = securityTicket.TenantID;
                    breakTime.Save(Connection, Transaction);

                    ORM_CMN_PPS_BreakTime_Template_Assignment newAssignment = new ORM_CMN_PPS_BreakTime_Template_Assignment();
                    newAssignment.BreakTime_RefID = breakTime.CMN_PPS_BreakTimeID;
                    newAssignment.BreakTime_Template_RefID = breakTimeTemplate.CMN_PPS_BreakTime_TemplateID;
                    newAssignment.Tenant_RefID = securityTicket.TenantID;
                    newAssignment.Save(Connection, Transaction);
                }
            }
            else
            {
                if (breakTimes.Any(i => i.IsBreakfastBreak))
                {
                    ORM_CMN_PPS_BreakTime breakTime = breakTimes.FirstOrDefault(i => i.IsBreakfastBreak);
                    breakTime.Remove(Connection, Transaction);
                }
            }


            if (Parameter.DinnerDuration != 0)
            {
                if (breakTimes.Any(i => i.IsDinnerBreak))
                {
                    ORM_CMN_PPS_BreakTime breakTime = breakTimes.FirstOrDefault(i => i.IsDinnerBreak);
                    breakTime.Default_Duration_in_sec = Parameter.DinnerDuration;
                    breakTime.Save(Connection, Transaction);
                }
                else
                {
                    ORM_CMN_PPS_BreakTime breakTime = new ORM_CMN_PPS_BreakTime();
                    breakTime.Default_Duration_in_sec = Parameter.DinnerDuration;
                    breakTime.IsDinnerBreak = true;
                    breakTime.Tenant_RefID = securityTicket.TenantID;
                    breakTime.Save(Connection, Transaction);

                    ORM_CMN_PPS_BreakTime_Template_Assignment newAssignment = new ORM_CMN_PPS_BreakTime_Template_Assignment();
                    newAssignment.BreakTime_RefID = breakTime.CMN_PPS_BreakTimeID;
                    newAssignment.BreakTime_Template_RefID = breakTimeTemplate.CMN_PPS_BreakTime_TemplateID;
                    newAssignment.Tenant_RefID = securityTicket.TenantID;
                    newAssignment.Save(Connection, Transaction);
                }
            }
            else
            {
                if (breakTimes.Any(i => i.IsDinnerBreak))
                {
                    ORM_CMN_PPS_BreakTime breakTime = breakTimes.FirstOrDefault(i => i.IsDinnerBreak);
                    breakTime.Remove(Connection, Transaction);
                }
            }

            if (Parameter.LunchDuration != 0)
            {
                if (breakTimes.Any(i => i.IsLunchBreak))
                {
                    ORM_CMN_PPS_BreakTime breakTime = breakTimes.FirstOrDefault(i => i.IsLunchBreak);
                    breakTime.Default_Duration_in_sec = Parameter.LunchDuration;
                    breakTime.Save(Connection, Transaction);
                }
                else
                {
                    ORM_CMN_PPS_BreakTime breakTime = new ORM_CMN_PPS_BreakTime();
                    breakTime.Default_Duration_in_sec = Parameter.LunchDuration;
                    breakTime.IsLunchBreak = true;
                    breakTime.Tenant_RefID = securityTicket.TenantID;
                    breakTime.Save(Connection, Transaction);

                    ORM_CMN_PPS_BreakTime_Template_Assignment newAssignment = new ORM_CMN_PPS_BreakTime_Template_Assignment();
                    newAssignment.BreakTime_RefID = breakTime.CMN_PPS_BreakTimeID;
                    newAssignment.BreakTime_Template_RefID = breakTimeTemplate.CMN_PPS_BreakTime_TemplateID;
                    newAssignment.Tenant_RefID = securityTicket.TenantID;
                    newAssignment.Save(Connection, Transaction);
                }
            }
            else
            {
                if (breakTimes.Any(i => i.IsLunchBreak))
                {
                    ORM_CMN_PPS_BreakTime breakTime = breakTimes.FirstOrDefault(i => i.IsLunchBreak);
                    breakTime.Remove(Connection, Transaction);
                }
            }

            if (Parameter.Duration != 0)
            {
                if (breakTimes.Any(i => !i.IsLunchBreak&&!i.IsBreakfastBreak&&!i.IsDinnerBreak))
                {
                    ORM_CMN_PPS_BreakTime breakTime = breakTimes.FirstOrDefault(i => !i.IsLunchBreak && !i.IsBreakfastBreak && !i.IsDinnerBreak);
                    breakTime.Default_Duration_in_sec = Parameter.Duration;
                    breakTime.Save(Connection, Transaction);
                }
                else
                {
                    ORM_CMN_PPS_BreakTime breakTime = new ORM_CMN_PPS_BreakTime();
                    breakTime.Default_Duration_in_sec = Parameter.Duration;                
                    breakTime.Tenant_RefID = securityTicket.TenantID;
                    breakTime.Save(Connection, Transaction);

                    ORM_CMN_PPS_BreakTime_Template_Assignment newAssignment = new ORM_CMN_PPS_BreakTime_Template_Assignment();
                    newAssignment.BreakTime_RefID = breakTime.CMN_PPS_BreakTimeID;
                    newAssignment.BreakTime_Template_RefID = breakTimeTemplate.CMN_PPS_BreakTime_TemplateID;
                    newAssignment.Tenant_RefID = securityTicket.TenantID;
                    newAssignment.Save(Connection, Transaction);
                }
            }
            else
            {
                if (breakTimes.Any(i => !i.IsLunchBreak&&!i.IsBreakfastBreak&&!i.IsDinnerBreak))
                {
                    ORM_CMN_PPS_BreakTime breakTime = breakTimes.FirstOrDefault(i => !i.IsLunchBreak&&!i.IsBreakfastBreak&&!i.IsDinnerBreak);
                    breakTime.Remove(Connection, Transaction);
                }
            }

            returnValue.Result = breakTimeTemplate.CMN_PPS_BreakTime_TemplateID;
    
            
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5BR_SBM_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5BR_SBM_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BR_SBM_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BR_SBM_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw new Exception("Exception occured in method cls_Save_BreakModel",ex);
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
FR_Guid cls_Save_BreakModel(,P_L5BR_SBM_1545 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_BreakModel.Invoke(connectionString,P_L5BR_SBM_1545 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_HealthInsurances.Atomic.Manipulation.P_L5BR_SBM_1545();
parameter.CMN_PPS_BreakTime_TemplateID = ...;
parameter.BreakTimeTemplate_Name_DictID = ...;
parameter.BreakfestDuration = ...;
parameter.LunchDuration = ...;
parameter.DinnerDuration = ...;
parameter.Duration = ...;
parameter.Office_RefID = ...;
parameter.Workarea_RefID = ...;
parameter.Workplace_RefID = ...;

*/