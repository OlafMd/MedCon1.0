/* 
 * Generated on 8/30/2013 11:30:25 AM
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
using CL1_CMN;
using CL1_CMN_CAL;
using CL1_CMN_CAL_APR;
using PlannicoModel.Models;

namespace CL6_VacationPlanner_Tenant.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Tenant_Settings.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Tenant_Settings
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6TN_STS_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_CMN_CAL_APR_ResponsiblePerson responsiblePersons = new ORM_CMN_CAL_APR_ResponsiblePerson();
            if (Parameter.CMN_CAL_APR_ResponsiblePersonID != Guid.Empty)
            {
                var result = responsiblePersons.Load(Connection, Transaction, Parameter.CMN_CAL_APR_ResponsiblePersonID);
                if (result.Status != FR_Status.Success || responsiblePersons.CMN_CAL_APR_ResponsiblePersonID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            responsiblePersons.NumberOfResponsiblePersonsRequiredToApprove = Parameter.NumberOfResponsiblePersonsRequiredToApprove;
            responsiblePersons.Tenant_RefID = securityTicket.TenantID;
            responsiblePersons.Save(Connection, Transaction);

            ORM_CMN_CAL_Event_ApprovalProcess_Type eventApprovalProcessType = new ORM_CMN_CAL_Event_ApprovalProcess_Type();
            if (Parameter.CMN_CAL_Event_ApprovalProcess_TypeID != Guid.Empty)
            {
                var result = eventApprovalProcessType.Load(Connection, Transaction, Parameter.CMN_CAL_Event_ApprovalProcess_TypeID);
                if (result.Status != FR_Status.Success || eventApprovalProcessType.CMN_CAL_Event_ApprovalProcess_TypeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            eventApprovalProcessType.Tenant_RefID = securityTicket.TenantID;
            eventApprovalProcessType.IsResponsiblePersonBased = true;
            eventApprovalProcessType.IfResponsiblePersonBased_RefID = responsiblePersons.CMN_CAL_APR_ResponsiblePersonID;
            eventApprovalProcessType.Save(Connection, Transaction);

            ORM_CMN_Tenant_ActiveApprovalProcessType activeApprovalProcessType = new ORM_CMN_Tenant_ActiveApprovalProcessType();
            if (Parameter.CMN_Tenant_ActiveApprovalProcessTypeID != Guid.Empty)
            {
                var result = activeApprovalProcessType.Load(Connection, Transaction, Parameter.CMN_Tenant_ActiveApprovalProcessTypeID);
                if (result.Status != FR_Status.Success || activeApprovalProcessType.CMN_Tenant_ActiveApprovalProcessTypeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            activeApprovalProcessType.Tenant_RefID = securityTicket.TenantID;
            activeApprovalProcessType.IsActive = true;
            activeApprovalProcessType.CMN_CAL_Event_ApprovalProcess_Type_RefID = eventApprovalProcessType.CMN_CAL_Event_ApprovalProcess_TypeID;
            activeApprovalProcessType.Save(Connection, Transaction);

            ORM_CMN_Tenant tenantItem = new ORM_CMN_Tenant();
            if (securityTicket.TenantID != Guid.Empty)
            {
                var result = tenantItem.Load(Connection, Transaction, securityTicket.TenantID);
                if (result.Status != FR_Status.Success || tenantItem.CMN_TenantID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            tenantItem.IsUsing_Offices = Parameter.IsUsing_Offices;
            tenantItem.IsUsing_WorkAreas = Parameter.IsUsing_WorkAreas;
            tenantItem.IsUsing_Workplaces = Parameter.IsUsing_Workplaces;
            tenantItem.IsUsing_CostCenters = Parameter.IsUsing_CostCenters;
            tenantItem.Save(Connection, Transaction);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6TN_STS_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6TN_STS_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TN_STS_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TN_STS_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Tenant_Settings",ex);
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
FR_Guid cls_Save_Tenant_Settings(,P_L6TN_STS_1026 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Tenant_Settings.Invoke(connectionString,P_L6TN_STS_1026 Parameter,securityTicket);
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
var parameter = new CL6_VacationPlanner_Tenant.Atomic.Manipulation.P_L6TN_STS_1026();
parameter.IsUsing_Offices = ...;
parameter.IsUsing_WorkAreas = ...;
parameter.IsUsing_Workplaces = ...;
parameter.IsUsing_CostCenters = ...;
parameter.NumberOfResponsiblePersonsRequiredToApprove = ...;
parameter.CMN_CAL_APR_ResponsiblePersonID = ...;
parameter.CMN_CAL_Event_ApprovalProcess_TypeID = ...;
parameter.CMN_Tenant_ActiveApprovalProcessTypeID = ...;

*/