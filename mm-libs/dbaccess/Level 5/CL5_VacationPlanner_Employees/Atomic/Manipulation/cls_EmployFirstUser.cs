/* 
 * Generated on 8/26/2013 4:38:45 PM
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
using CL5_VacationPlanner_Company.Complex.Retrieval;
using CL5_VacationPlanner_Employees.Atomic.Retrieval;
using CL1_CMN_BPT_EMP;
using CL5_VacationPlanner_Employees.Complex.Retrieval;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_EmployFirstUser.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_EmployFirstUser
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_EFU_1845 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here
            ORM_CMN_BPT_EMP_Employee employee = new ORM_CMN_BPT_EMP_Employee();
            if (Parameter.CMN_BPT_EMP_EmployeeID != Guid.Empty)
            {
                var result = employee.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_EmployeeID);
                if (result.Status != FR_Status.Success || employee.CMN_BPT_EMP_EmployeeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
         
            P_L5EM_GEFE_1150 par = new P_L5EM_GEFE_1150();
            par.EmployeeID = Parameter.CMN_BPT_EMP_EmployeeID;
            L5CM_GCSFT_1157 company= cls_Get_Company_Structure_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            employee.Save(Connection, Transaction);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5EM_EFU_1845 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5EM_EFU_1845 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_EFU_1845 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_EFU_1845 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
FR_Base cls_EmployFirstUser(P_L5EM_EFU_1845 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Base result = cls_EmployFirstUser.Invoke(connectionString,P_L5EM_EFU_1845 Parameter,securityTicket);
	 return result;
}
*/