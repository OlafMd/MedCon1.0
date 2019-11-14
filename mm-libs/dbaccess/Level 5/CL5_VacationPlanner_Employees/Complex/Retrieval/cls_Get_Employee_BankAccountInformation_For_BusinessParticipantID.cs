/* 
 * Generated on 06-Dec-13 11:36:48
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
using CL1_CMN_BPT;
using CL1_ACC_BNK;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Employee_BankAccountInformation_For_BusinessParticipantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Employee_BankAccountInformation_For_BusinessParticipantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEBAIFBPID_1111 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_GEBAIFBPID_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5EM_GEBAIFBPID_1111();

            ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query bankAcc2BPQuery = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query();
            bankAcc2BPQuery.CMN_BPT_BusinessParticipant_RefID = Parameter.BusinessParticipantID;
            bankAcc2BPQuery.IsDeleted = false;
            bankAcc2BPQuery.Tenant_RefID = securityTicket.TenantID;

            var bankAcc2BPQueryResult = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, bankAcc2BPQuery);

            if (bankAcc2BPQueryResult.Count == 0)
                return null;

            ORM_ACC_BNK_BankAccount.Query bankAccQuery = new ORM_ACC_BNK_BankAccount.Query();
            bankAccQuery.ACC_BNK_BankAccountID = bankAcc2BPQueryResult.FirstOrDefault().ACC_BNK_BankAccount_RefID;
            bankAccQuery.IsDeleted = false;
            bankAccQuery.Tenant_RefID = securityTicket.TenantID;

            var bankAccount = ORM_ACC_BNK_BankAccount.Query.Search(Connection, Transaction, bankAccQuery).FirstOrDefault();
            
            ORM_ACC_BNK_Bank.Query banksQuery = new ORM_ACC_BNK_Bank.Query();
            banksQuery.ACC_BNK_BankID = bankAccount.Bank_RefID;
            banksQuery.IsDeleted = false;
            banksQuery.Tenant_RefID = securityTicket.TenantID;

            var bank = ORM_ACC_BNK_Bank.Query.Search(Connection, Transaction, banksQuery).FirstOrDefault();

            L5EM_GEBAIFBPID_1111 result = new L5EM_GEBAIFBPID_1111();
            result.BankName = bank.BankName;
            result.BIC = bank.BICCode;
            result.IBAN = bankAccount.IBAN;

            returnValue.Result = result;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EM_GEBAIFBPID_1111 Invoke(string ConnectionString,P_L5EM_GEBAIFBPID_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEBAIFBPID_1111 Invoke(DbConnection Connection,P_L5EM_GEBAIFBPID_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEBAIFBPID_1111 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_GEBAIFBPID_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEBAIFBPID_1111 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_GEBAIFBPID_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEBAIFBPID_1111 functionReturn = new FR_L5EM_GEBAIFBPID_1111();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEBAIFBPID_1111 : FR_Base
	{
		public L5EM_GEBAIFBPID_1111 Result	{ get; set; }

		public FR_L5EM_GEBAIFBPID_1111() : base() {}

		public FR_L5EM_GEBAIFBPID_1111(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}
