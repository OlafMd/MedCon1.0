/* 
 * Generated on 11/14/2013 2:48:42 PM
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
using VacationPlaner;

namespace CL5_Plannico_TypesOfSalary.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_TypesOfSalary.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_TypesOfSalary
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5TS_DTS_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();

			//Put your code here
            var type = new ORM_CMN_BPT_EMP_SalaryType();
            if (Parameter.CMN_BPT_EMP_SalaryTypeID != Guid.Empty)
            {
                var result = type.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_SalaryTypeID);
                if (result.Status != FR_Status.Success || type.CMN_BPT_EMP_SalaryTypeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            type.IsDeleted = true;
            type.Save(Connection, Transaction);

            ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query salaryType2EconomicRegionQuery = new ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query();
            salaryType2EconomicRegionQuery.CMN_BPT_EMP_SalaryType_RefID = type.CMN_BPT_EMP_SalaryTypeID;
            salaryType2EconomicRegionQuery.IsDeleted = false;
            salaryType2EconomicRegionQuery.Tenant_RefID = securityTicket.TenantID;

            var existingSalaryType2EconomicRegions = ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query.Search(Connection, Transaction, salaryType2EconomicRegionQuery);

            foreach (var existingSalaryType2EconomicRegion in existingSalaryType2EconomicRegions)
            {
                existingSalaryType2EconomicRegion.IsDeleted = true;
                existingSalaryType2EconomicRegion.Save(Connection, Transaction);
            }
            

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5TS_DTS_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5TS_DTS_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TS_DTS_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TS_DTS_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Delete_TypesOfSalary(P_L5TS_DTS_1447 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Base result = cls_Delete_TypesOfSalary.Invoke(connectionString,P_L5TS_DTS_1447 Parameter,securityTicket);
	 return result;
}
*/