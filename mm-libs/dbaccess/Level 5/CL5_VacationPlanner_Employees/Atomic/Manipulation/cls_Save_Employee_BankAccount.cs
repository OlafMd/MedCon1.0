/* 
 * Generated on 12/20/2013 1:38:59 PM
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
using CL1_ACC_BNK;
using CL1_CMN_BPT;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Employee_BankAccount.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Employee_BankAccount
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_SEBA_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            bool isEdit = false;

            ORM_ACC_BNK_BankAccount bankAccount = new ORM_ACC_BNK_BankAccount();
            if (Parameter.ACC_BNK_BankAccountID != Guid.Empty)
            {
                var result = bankAccount.Load(Connection, Transaction, Parameter.ACC_BNK_BankAccountID);
                if (result.Status != FR_Status.Success || bankAccount.ACC_BNK_BankAccountID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                isEdit = true;
            }

            ORM_ACC_BNK_Bank.Query bankQuery = new ORM_ACC_BNK_Bank.Query();
            bankQuery.Tenant_RefID = securityTicket.TenantID;
            bankQuery.IsDeleted = false;

            ORM_ACC_BNK_Bank bank = ORM_ACC_BNK_Bank.Query.Search(Connection, Transaction, bankQuery).FirstOrDefault();

            bankAccount.Bank_RefID = bank == null ? new Guid() : bank.ACC_BNK_BankID;
            bankAccount.IBAN = Parameter.IBAN;
            bankAccount.OwnerText = Parameter.OwnerText;
            bankAccount.IsValid = true;
            bankAccount.Tenant_RefID = securityTicket.TenantID;
            bankAccount.Save(Connection, Transaction);

            returnValue = new FR_Guid(bankAccount.ACC_BNK_BankAccountID);

            if (!isEdit)
            {
                ORM_CMN_BPT_BusinessParticipant_2_BankAccount bankAcc2BP = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                bankAcc2BP.ACC_BNK_BankAccount_RefID = bankAccount.ACC_BNK_BankAccountID;
                bankAcc2BP.CMN_BPT_BusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipant_RefID;
                bankAcc2BP.Tenant_RefID = securityTicket.TenantID;
                bankAcc2BP.Save(Connection, Transaction);
            }
            

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EM_SEBA_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EM_SEBA_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_SEBA_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_SEBA_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
FR_Guid cls_Save_Employee_BankAccount(P_L5EM_SEBA_1001 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_Employee_BankAccount.Invoke(connectionString,P_L5EM_SEBA_1001 Parameter,securityTicket);
	 return result;
}
*/
