/* 
 * Generated on 23-May-14 13:40:04
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
using PlannicoModel.Models;
using CL1_CMN_BPT_EMP;
using VacationPlaner;

namespace CL5_Plannico_TypesOfSalary.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_WorkingContract_SalaryTypes_For_WorkingContract.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_WorkingContract_SalaryTypes_For_WorkingContract
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5TS_DWCSTFWC_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here


            ORM_CMN_BPT_EMP_WorkingContract_SalaryType.Query salaryTypeQuery = new ORM_CMN_BPT_EMP_WorkingContract_SalaryType.Query();
            salaryTypeQuery.CMN_BPT_EMP_WorkingContract_RefID = Parameter.CMN_BPT_EMP_WorkingContract_RefID;
            salaryTypeQuery.Tenant_RefID = securityTicket.TenantID;
            salaryTypeQuery.IsDeleted = false;

            var salaryTypes = ORM_CMN_BPT_EMP_WorkingContract_SalaryType.Query.Search(Connection, Transaction, salaryTypeQuery);

            foreach (var salaryType in salaryTypes)
            {
                salaryType.IsDeleted = true;
                salaryType.Save(Connection, Transaction);
            }

            returnValue.Status = FR_Status.Success;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5TS_DWCSTFWC_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5TS_DWCSTFWC_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TS_DWCSTFWC_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TS_DWCSTFWC_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes

	#endregion
}
