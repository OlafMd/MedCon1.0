/* 
 * Generated on 2/18/2014 12:30:46 PM
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

namespace CL5_VacationPlanner_Employees.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_EmployeeFunctionHistory.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_EmployeeFunctionHistory
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_SEP_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

			//Put your code here
            ORM_CMN_BPT_EMP_Employee_FunctionHistory.Query employeeProfessionQuery = new ORM_CMN_BPT_EMP_Employee_FunctionHistory.Query();
            employeeProfessionQuery.CMN_BPT_EMP_Employee_RefID = Parameter.Employee_RefID;
            employeeProfessionQuery.Tenant_RefID = securityTicket.TenantID;
            employeeProfessionQuery.IsDeleted = false;
            List<ORM_CMN_BPT_EMP_Employee_FunctionHistory> employeeProfessionList = ORM_CMN_BPT_EMP_Employee_FunctionHistory.Query.Search(Connection, Transaction, employeeProfessionQuery);

            //delete profession from database witch doesn't exist in passed parameter
            List<ORM_CMN_BPT_EMP_Employee_FunctionHistory> deletedProfessionList = new List<ORM_CMN_BPT_EMP_Employee_FunctionHistory>();
            foreach (var item in employeeProfessionList)
            {
                if (Parameter.FunctionHistories.Any(p => p.CMN_BPT_EMP_Employee_FunctionHistoryID == item.CMN_BPT_EMP_Employee_FunctionHistoryID))
                    continue;

                item.Remove(Connection, Transaction);
                deletedProfessionList.Add(item);
            }
            employeeProfessionList = employeeProfessionList.Except(deletedProfessionList).ToList();

            //add or edit every profession from parameter
            foreach (var professionItem in Parameter.FunctionHistories)
            {
                ORM_CMN_BPT_EMP_Employee_FunctionHistory employeeProfession = new ORM_CMN_BPT_EMP_Employee_FunctionHistory();

                if (employeeProfessionList.Any(e => e.CMN_BPT_EMP_Employee_FunctionHistoryID == professionItem.CMN_BPT_EMP_Employee_FunctionHistoryID))
                    employeeProfession.Load(Connection, Transaction, professionItem.CMN_BPT_EMP_Employee_FunctionHistoryID);

                employeeProfession.CMN_BPT_EMP_Employee_RefID = Parameter.Employee_RefID;
                employeeProfession.ValidFrom = professionItem.ValidFrom;
                employeeProfession.FunctionName = professionItem.FunctionName;
                employeeProfession.Tenant_RefID = securityTicket.TenantID;

                employeeProfession.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EM_SEP_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EM_SEP_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_SEP_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_SEP_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
FR_Guid cls_Save_EmployeeFunctionHistory(P_L5EM_SEP_1447 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_EmployeeFunctionHistory.Invoke(connectionString,P_L5EM_SEP_1447 Parameter,securityTicket);
	 return result;
}
*/