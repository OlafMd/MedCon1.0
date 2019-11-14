/* 
 * Generated on 8/26/2013 4:39:36 PM
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
using CL5_VacationPlanner_Employees.Atomic.Retrieval;
using BOp.Infrastructure;
using BOp.Infrastructure.Enterprise;
using CL1_CMN_BPT_EMP;
using CL5_VacationPlanner_Employees.Complex.Retrieval;
using BOp.Message.Realm;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Employee.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Employee
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_DE_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here

            P_L5EM_GEFE_1150 par=new P_L5EM_GEFE_1150();
            par.EmployeeID=Parameter.CMN_BPT_EMP_EmployeeID;
            L5EM_GEFE_1150 employee=cls_Get_Employee_For_EmployeeID.Invoke(Connection,Transaction, par, securityTicket).Result;


            ORM_CMN_BPT_EMP_Employee whereInstanceEmployee = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_BPT_EMP_Employee>();
            whereInstanceEmployee.CMN_BPT_EMP_EmployeeID = employee.CMN_BPT_EMP_EmployeeID;
            CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceEmployee);


            var enterpriseService = InfrastructureFactory.CreateEnterpriseService();
            KeyPerformanceIndicator action = new KeyPerformanceIndicator();
            action.PerformedByAccountID = securityTicket.AccountID;
            action.PerformedByApplicationID = Parameter.ApplicationID;
            action.PerformedOn = DateTime.Now;
            action.PerformedByTenantID = securityTicket.TenantID;
            action.KeyPerformanceIndicatorID = Guid.Parse("4dda967a-5399-4929-afae-7af64699895b");
            action.Value = cls_Get_Employees_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result.Length ;

            var result = enterpriseService.SendMessage(action.ToPayload(), KeyPerformanceIndicator.MESSAGE_TYPE, Parameter.ApplicationID, EMessageRecipient.CUSTOMER_MANAGEMENT_PLATFORM);

            ORM_CMN_BPT_EMP_EmploymentRelationship whereInstanceContract = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_BPT_EMP_EmploymentRelationship>();
            whereInstanceContract.CMN_BPT_EMP_EmploymentRelationshipID = employee.CMN_BPT_EMP_EmploymentRelationshipID;
            CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceContract);

            ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query searchInstanceWorkingContract = new ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query();
            searchInstanceWorkingContract.WorkingContract_RefID = employee.CMN_BPT_EMP_EmploymentRelationshipID;
            List<ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract> employmentRelationshipToWorkingContract = ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query.Search(Connection, Transaction, searchInstanceWorkingContract);
            if(employmentRelationshipToWorkingContract!=null)
            foreach (var relationShipToContract in employmentRelationshipToWorkingContract)
            {
                ORM_CMN_BPT_EMP_WorkingContract workingContractQuery = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_BPT_EMP_WorkingContract>();
                workingContractQuery.CMN_BPT_EMP_WorkingContractID = relationShipToContract.WorkingContract_RefID;
                CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, workingContractQuery);


                ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason allowedreasons = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason>();
                allowedreasons.WorkingContract_RefID = relationShipToContract.WorkingContract_RefID;
                CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, allowedreasons);
                
            }


            
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5EM_DE_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5EM_DE_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_DE_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_DE_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
FR_Base cls_Delete_Employee(P_L5EP_DE_1006 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Base result = cls_Delete_Employee.Invoke(connectionString,P_L5EP_DE_1006 Parameter,securityTicket);
	 return result;
}
*/