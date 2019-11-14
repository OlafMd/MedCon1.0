/* 
 * Generated on 14/08/2014 15:31:42
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
using CL1_CMN_PPS;
using CL1_CMN_BPT_STR;
using CL1_CMN_STR_PPS;
using CL1_CMN_STR;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Office.complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Is_Office_Used.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Is_Office_Used
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5OF_IOFU_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Bool();

            ORM_CMN_BPT_EMP_Employee_PlanGroup.Query planGroupQuery = new ORM_CMN_BPT_EMP_Employee_PlanGroup.Query();
            planGroupQuery.BoundTo_Office_RefID = Parameter.OfficeID;
            planGroupQuery.IsDeleted = false;
            planGroupQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_BPT_EMP_Employee_PlanGroup.Query.Exists(Connection, Transaction, planGroupQuery))
                returnValue.Result = true;

            ORM_CMN_BPT_EMP_ExtraWorkCalculation_StructureBinding.Query extraWorkCalculationQuery = new ORM_CMN_BPT_EMP_ExtraWorkCalculation_StructureBinding.Query();
            extraWorkCalculationQuery.BoundTo_Office_RefID = Parameter.OfficeID;
            extraWorkCalculationQuery.IsDeleted = false;
            extraWorkCalculationQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_BPT_EMP_ExtraWorkCalculation_StructureBinding.Query.Exists(Connection, Transaction, extraWorkCalculationQuery))
                returnValue.Result = true;

            ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBinding.Query surchargeQuery = new ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBinding.Query();
            surchargeQuery.BoundTo_Office_RefID = Parameter.OfficeID;
            surchargeQuery.IsDeleted = false;
            surchargeQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBinding.Query.Exists(Connection, Transaction, surchargeQuery))
                returnValue.Result = true;

            ORM_CMN_BPT_EMP_Employee.Query employeeQuery = new ORM_CMN_BPT_EMP_Employee.Query();
            employeeQuery.Primary_Office_RefID = Parameter.OfficeID;
            employeeQuery.IsDeleted = false;
            employeeQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_BPT_EMP_Employee.Query.Exists(Connection, Transaction, employeeQuery))
                returnValue.Result = true;

            ORM_CMN_PPS_ShiftTemplate.Query shiftTemplateQuery = new ORM_CMN_PPS_ShiftTemplate.Query();
            shiftTemplateQuery.CMN_STR_Office_RefID = Parameter.OfficeID;
            shiftTemplateQuery.IsDeleted = false;
            shiftTemplateQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_PPS_ShiftTemplate.Query.Exists(Connection, Transaction, shiftTemplateQuery))
                returnValue.Result = true;

            ORM_CMN_PPS_BreakTime_Defaults_StructureBinding.Query defaultBreakQuery = new ORM_CMN_PPS_BreakTime_Defaults_StructureBinding.Query();
            defaultBreakQuery.BoundTo_Office_RefID = Parameter.OfficeID;
            defaultBreakQuery.IsDeleted = false;
            defaultBreakQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_PPS_BreakTime_Defaults_StructureBinding.Query.Exists(Connection, Transaction, defaultBreakQuery))
                returnValue.Result = true;

            ORM_CMN_PPS_BreakTime_Template.Query breakTimeTemplateQuery = new ORM_CMN_PPS_BreakTime_Template.Query();
            breakTimeTemplateQuery.BoundTo_Office_RefID = Parameter.OfficeID;
            breakTimeTemplateQuery.IsDeleted = false;
            breakTimeTemplateQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_PPS_BreakTime_Template.Query.Exists(Connection, Transaction, breakTimeTemplateQuery))
                returnValue.Result = true;


            ORM_CMN_STR_PPS_WorkArea.Query workplaceQuery = new ORM_CMN_STR_PPS_WorkArea.Query();
            workplaceQuery.Office_RefID = Parameter.OfficeID;
            workplaceQuery.IsDeleted = false;
            workplaceQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_STR_PPS_WorkArea.Query.Exists(Connection, Transaction, workplaceQuery))
                returnValue.Result = true;

            ORM_CMN_BPT_STR_Office_SettingsProfile.Query OfficeSettingsProfileQuery = new ORM_CMN_BPT_STR_Office_SettingsProfile.Query();
            OfficeSettingsProfileQuery.Office_RefID = Parameter.OfficeID;
            OfficeSettingsProfileQuery.IsDeleted = false;
            OfficeSettingsProfileQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_BPT_STR_Office_SettingsProfile.Query.Exists(Connection, Transaction, OfficeSettingsProfileQuery))
                returnValue.Result = true;
            
            ORM_CMN_STR_Office_2_CostCenter.Query OfficeCostcenterQuery = new ORM_CMN_STR_Office_2_CostCenter.Query();
            OfficeCostcenterQuery.Office_RefID = Parameter.OfficeID;
            OfficeCostcenterQuery.IsDeleted = false;
            OfficeCostcenterQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_STR_Office_2_CostCenter.Query.Exists(Connection, Transaction, OfficeCostcenterQuery))
                returnValue.Result = true;

            ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template.Query OfficeDefaultWorkRelationTemplateQuery = new ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template.Query();
            OfficeDefaultWorkRelationTemplateQuery.CMN_STR_Office_RefID = Parameter.OfficeID;
            OfficeDefaultWorkRelationTemplateQuery.IsDeleted = false;
            OfficeDefaultWorkRelationTemplateQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template.Query.Exists(Connection, Transaction, OfficeDefaultWorkRelationTemplateQuery))
                returnValue.Result = true;

            

         
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5OF_IOFU_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5OF_IOFU_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OF_IOFU_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OF_IOFU_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Is_Office_Used",ex);
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
FR_Bool cls_Is_Office_Used(,P_L5OF_IOFU_1531 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Is_Office_Used.Invoke(connectionString,P_L5OF_IOFU_1531 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Office.complex.Retrieval.P_L5OF_IOFU_1531();
parameter.OfficeID = ...;

*/
