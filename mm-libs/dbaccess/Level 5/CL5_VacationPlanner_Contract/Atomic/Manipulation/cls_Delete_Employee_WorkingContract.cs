/* 
 * Generated on 10/24/2013 10:20:43 AM
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
using PlannicoModel.Models;
using CL5_Plannico_TypesOfSalary.Atomic.Manipulation;


namespace CL5_VacationPlanner_Contract.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Employee_WorkingContract.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Employee_WorkingContract
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CT_DECT_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            if (Parameter.LastActive_WorkingContractID != Guid.Empty)
            {
                ORM_CMN_BPT_EMP_WorkingContract workingContract = new ORM_CMN_BPT_EMP_WorkingContract();
                if (Parameter.LastActive_WorkingContractID != Guid.Empty)
                {
                    var result = workingContract.Load(Connection, Transaction, Parameter.LastActive_WorkingContractID);
                    if (result.Status != FR_Status.Success || workingContract.CMN_BPT_EMP_WorkingContractID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                }
                workingContract.Contract_EndDate = DateTime.MinValue;
                workingContract.IsContractEndDateDefined = false;
                workingContract.Save(Connection, Transaction);

            }


            ORM_CMN_BPT_EMP_WorkingContract workingContractItem = new ORM_CMN_BPT_EMP_WorkingContract();
            if (Parameter.WorkingContractID != Guid.Empty)
            {
                var result = workingContractItem.Load(Connection, Transaction, Parameter.WorkingContractID);
                if (result.Status != FR_Status.Success || workingContractItem.CMN_BPT_EMP_WorkingContractID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            workingContractItem.IsDeleted = true;
            workingContractItem.Tenant_RefID = securityTicket.TenantID;
            workingContractItem.Save(Connection, Transaction);

            ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract employeeRelationShipToWorkinkContract = new ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract();
            ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query workingContractsAssigmentQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query();
            workingContractsAssigmentQuery.Tenant_RefID = securityTicket.TenantID;
            workingContractsAssigmentQuery.IsDeleted = false;
            workingContractsAssigmentQuery.WorkingContract_RefID = Parameter.WorkingContractID;
            ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract workingContractsAssigment = ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query.Search(Connection, Transaction, workingContractsAssigmentQuery).FirstOrDefault();

            P_L5TS_DWCSTFWC_1325 param = new P_L5TS_DWCSTFWC_1325();
            param.CMN_BPT_EMP_WorkingContract_RefID = Parameter.WorkingContractID;

            cls_Delete_WorkingContract_SalaryTypes_For_WorkingContract.Invoke(Connection, Transaction, param, securityTicket);


            var loadResult= employeeRelationShipToWorkinkContract.Load(Connection, Transaction, workingContractsAssigment.AssignmentID);
            if (loadResult.Status != FR_Status.Success || employeeRelationShipToWorkinkContract.AssignmentID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                employeeRelationShipToWorkinkContract.IsDeleted = true;
                employeeRelationShipToWorkinkContract.Save(Connection, Transaction);

               

            var query1 = new ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query();
            query1.Tenant_RefID = securityTicket.TenantID;
            query1.IsDeleted = false;
            query1.WorkingContract_RefID = Parameter.WorkingContractID;

            var res = ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query.Search(Connection, Transaction, query1);

            if (res != null)
            {
                foreach (var item in res)
                {
                    item.IsDeleted = true;
                    item.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_L5CT_DECT_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CT_DECT_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CT_DECT_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CT_DECT_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_Employee_WorkingContract",ex);
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
FR_Guid cls_Delete_Employee_WorkingContract(,P_L5CT_DECT_1140 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_Employee_WorkingContract.Invoke(connectionString,P_L5CT_DECT_1140 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Contract.Atomic.Manipulation.P_L5CT_DECT_1140();
parameter.WorkingContractID = ...;
parameter.AsssigmentID = ...;
parameter.LastActive_WorkingContractID = ...;

*/