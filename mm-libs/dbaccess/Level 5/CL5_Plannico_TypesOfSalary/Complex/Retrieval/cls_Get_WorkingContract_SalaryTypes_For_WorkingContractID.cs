/* 
 * Generated on 23-May-14 11:56:56
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

namespace CL5_Plannico_TypesOfSalary.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_WorkingContract_SalaryTypes_For_WorkingContractID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_WorkingContract_SalaryTypes_For_WorkingContractID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TS_GWCSTFWCID_1152 Execute(DbConnection Connection,DbTransaction Transaction,P_L5TS_GWCSTFWCID_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5TS_GWCSTFWCID_1152();
			//Put your code here

            ORM_CMN_BPT_EMP_WorkingContract_SalaryType.Query salaryTypeQuery = new ORM_CMN_BPT_EMP_WorkingContract_SalaryType.Query();
            salaryTypeQuery.CMN_BPT_EMP_WorkingContract_RefID = Parameter.CMN_BPT_EMP_WorkingContract_RefID;
            salaryTypeQuery.Tenant_RefID = securityTicket.TenantID;
            salaryTypeQuery.IsDeleted = false;

            var salaryTypes = ORM_CMN_BPT_EMP_WorkingContract_SalaryType.Query.Search(Connection, Transaction, salaryTypeQuery);

            List<L5TS_GWCSTFT_1148> resultList = new List<L5TS_GWCSTFT_1148>();

            foreach (var salaryType in salaryTypes)
            {
                L5TS_GWCSTFT_1148 resultItem = new L5TS_GWCSTFT_1148();
                resultItem.CMN_BPT_EMP_SalaryTypeID = salaryType.CMN_BPT_EMP_SalaryTypeID;
                resultItem.Amount = salaryType.Amount;
                resultItem.CMN_BPT_EMP_WorkingContract_RefID = salaryType.CMN_BPT_EMP_WorkingContract_RefID;
                resultItem.CMN_BPT_EMP_WorkingContract_SalaryTypeID = salaryType.CMN_BPT_EMP_WorkingContract_SalaryTypeID;

                resultList.Add(resultItem);
            }

            returnValue.Result = new L5TS_GWCSTFWCID_1152();
            returnValue.Result.WorkingContractSalaryTypes = resultList.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TS_GWCSTFWCID_1152 Invoke(string ConnectionString,P_L5TS_GWCSTFWCID_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TS_GWCSTFWCID_1152 Invoke(DbConnection Connection,P_L5TS_GWCSTFWCID_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TS_GWCSTFWCID_1152 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TS_GWCSTFWCID_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TS_GWCSTFWCID_1152 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TS_GWCSTFWCID_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TS_GWCSTFWCID_1152 functionReturn = new FR_L5TS_GWCSTFWCID_1152();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L5TS_GWCSTFWCID_1152 : FR_Base
	{
		public L5TS_GWCSTFWCID_1152 Result	{ get; set; }

		public FR_L5TS_GWCSTFWCID_1152() : base() {}

		public FR_L5TS_GWCSTFWCID_1152(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}
