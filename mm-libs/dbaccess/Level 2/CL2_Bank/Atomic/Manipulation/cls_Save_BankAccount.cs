/* 
 * Generated on 7/24/2014 9:48:21 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL2_Bank.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ACC_BNK_BankAccount.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_BankAccount
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2B_SBA_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new CL1_ACC_BNK.ORM_ACC_BNK_BankAccount();
			if (Parameter.ACC_BNK_BankAccountID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.ACC_BNK_BankAccountID);
			    if (result.Status != FR_Status.Success || item.ACC_BNK_BankAccountID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.ACC_BNK_BankAccountID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.ACC_BNK_BankAccountID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.Bank_RefID = Parameter.Bank_RefID;
			item.Currency_RefID = Parameter.Currency_RefID;
			item.IBAN = Parameter.IBAN;
			item.AccountNumber = Parameter.AccountNumber;
			item.BankAccountType_RefID = Parameter.BankAccountType_RefID;
			item.OwnerText = Parameter.OwnerText;
			item.AccountOpenedAtDate = Parameter.AccountOpenedAtDate;
			item.AccountClosedAtDate = Parameter.AccountClosedAtDate;
			item.IsValid = Parameter.IsValid;
			item.R_AccountBalance = Parameter.R_AccountBalance;


			return new FR_Guid(item.Save(Connection, Transaction),item.ACC_BNK_BankAccountID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2B_SBA_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2B_SBA_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2B_SBA_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2B_SBA_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ACC_BNK_BankAccount",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2B_SBA_0944 for attribute P_L2B_SBA_0944
		[DataContract]
		public class P_L2B_SBA_0944 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_BNK_BankAccountID { get; set; } 
			[DataMember]
			public Guid Bank_RefID { get; set; } 
			[DataMember]
			public Guid Currency_RefID { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String AccountNumber { get; set; } 
			[DataMember]
			public Guid BankAccountType_RefID { get; set; } 
			[DataMember]
			public String OwnerText { get; set; } 
			[DataMember]
			public DateTime AccountOpenedAtDate { get; set; } 
			[DataMember]
			public DateTime AccountClosedAtDate { get; set; } 
			[DataMember]
			public Boolean IsValid { get; set; } 
			[DataMember]
			public Decimal R_AccountBalance { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ACC_BNK_BankAccount(,P_L2B_SBA_0944 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ACC_BNK_BankAccount.Invoke(connectionString,P_L2B_SBA_0944 Parameter,securityTicket);
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
var parameter = new Save_BankAccount.P_L2B_SBA_0944();
parameter.ACC_BNK_BankAccountID = ...;
parameter.Bank_RefID = ...;
parameter.Currency_RefID = ...;
parameter.IBAN = ...;
parameter.AccountNumber = ...;
parameter.BankAccountType_RefID = ...;
parameter.OwnerText = ...;
parameter.AccountOpenedAtDate = ...;
parameter.AccountClosedAtDate = ...;
parameter.IsValid = ...;
parameter.R_AccountBalance = ...;
parameter.IsDeleted = ...;

*/
