/* 
 * Generated on 7/18/2014 12:24:04 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL3_BookingAccounts.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3BA_GBAPBPAfBP_1717_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3BA_GBAPBPAfBP_1717 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3BA_GBAPBPAfBP_1717_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_BookingAccounts.Atomic.Retrieval.SQL.cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FiscalYearID", Parameter.FiscalYearID);

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@BusinessParticipantID_List"," IN $$BusinessParticipantID_List$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$BusinessParticipantID_List$",Parameter.BusinessParticipantID_List);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsRevenueAccount", Parameter.IsRevenueAccount);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsCustomerAccount", Parameter.IsCustomerAccount);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsVATAccount", Parameter.IsVATAccount);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsSupplierAccount", Parameter.IsSupplierAccount);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsBankAccount", Parameter.IsBankAccount);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsCashBox", Parameter.IsCashBox);



			List<L3BA_GBAPBPAfBP_1717> results = new List<L3BA_GBAPBPAfBP_1717>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID","BusinessParticipant_RefID","BookingAccount_RefID","BookingAccountName","BookingAccountNumber","Is_L1_BalanceSheet_Account","Is_L1_IncomeStatement_Account","Is_L2_AssetAccount","Is_L2_LiabilitiesAccount","Is_L2_RevenuesOrIncomeAccount","Is_L2_ExpensesOrLossesAccount","If_L3_AssetAccount_BankAccount_RefID","Is_L3_BankAccount","Is_L3_CustomerAccount","Is_L3_SupplierAccount","Is_L3_VATAccount" });
				while(reader.Read())
				{
					L3BA_GBAPBPAfBP_1717 resultItem = new L3BA_GBAPBPAfBP_1717();
					//0:Parameter ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID of type Guid
					resultItem.ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID = reader.GetGuid(0);
					//1:Parameter BusinessParticipant_RefID of type Guid
					resultItem.BusinessParticipant_RefID = reader.GetGuid(1);
					//2:Parameter BookingAccount_RefID of type Guid
					resultItem.BookingAccount_RefID = reader.GetGuid(2);
					//3:Parameter BookingAccountName of type String
					resultItem.BookingAccountName = reader.GetString(3);
					//4:Parameter BookingAccountNumber of type String
					resultItem.BookingAccountNumber = reader.GetString(4);
					//5:Parameter Is_L1_BalanceSheet_Account of type Boolean
					resultItem.Is_L1_BalanceSheet_Account = reader.GetBoolean(5);
					//6:Parameter Is_L1_IncomeStatement_Account of type Boolean
					resultItem.Is_L1_IncomeStatement_Account = reader.GetBoolean(6);
					//7:Parameter Is_L2_AssetAccount of type Boolean
					resultItem.Is_L2_AssetAccount = reader.GetBoolean(7);
					//8:Parameter Is_L2_LiabilitiesAccount of type Boolean
					resultItem.Is_L2_LiabilitiesAccount = reader.GetBoolean(8);
					//9:Parameter Is_L2_RevenuesOrIncomeAccount of type Boolean
					resultItem.Is_L2_RevenuesOrIncomeAccount = reader.GetBoolean(9);
					//10:Parameter Is_L2_ExpensesOrLossesAccount of type Boolean
					resultItem.Is_L2_ExpensesOrLossesAccount = reader.GetBoolean(10);
					//11:Parameter If_L3_AssetAccount_BankAccount_RefID of type Guid
					resultItem.If_L3_AssetAccount_BankAccount_RefID = reader.GetGuid(11);
					//12:Parameter Is_L3_BankAccount of type Boolean
					resultItem.Is_L3_BankAccount = reader.GetBoolean(12);
					//13:Parameter Is_L3_CustomerAccount of type Boolean
					resultItem.Is_L3_CustomerAccount = reader.GetBoolean(13);
					//14:Parameter Is_L3_SupplierAccount of type Boolean
					resultItem.Is_L3_SupplierAccount = reader.GetBoolean(14);
					//15:Parameter Is_L3_VATAccount of type Boolean
					resultItem.Is_L3_VATAccount = reader.GetBoolean(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3BA_GBAPBPAfBP_1717_Array Invoke(string ConnectionString,P_L3BA_GBAPBPAfBP_1717 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3BA_GBAPBPAfBP_1717_Array Invoke(DbConnection Connection,P_L3BA_GBAPBPAfBP_1717 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3BA_GBAPBPAfBP_1717_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BA_GBAPBPAfBP_1717 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3BA_GBAPBPAfBP_1717_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BA_GBAPBPAfBP_1717 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3BA_GBAPBPAfBP_1717_Array functionReturn = new FR_L3BA_GBAPBPAfBP_1717_Array();
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

				throw new Exception("Exception occured in method cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3BA_GBAPBPAfBP_1717_Array : FR_Base
	{
		public L3BA_GBAPBPAfBP_1717[] Result	{ get; set; } 
		public FR_L3BA_GBAPBPAfBP_1717_Array() : base() {}

		public FR_L3BA_GBAPBPAfBP_1717_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3BA_GBAPBPAfBP_1717 for attribute P_L3BA_GBAPBPAfBP_1717
		[DataContract]
		public class P_L3BA_GBAPBPAfBP_1717 
		{
			//Standard type parameters
			[DataMember]
			public Guid FiscalYearID { get; set; } 
			[DataMember]
			public Guid[] BusinessParticipantID_List { get; set; } 
			[DataMember]
			public Boolean? IsRevenueAccount { get; set; } 
			[DataMember]
			public Boolean? IsCustomerAccount { get; set; } 
			[DataMember]
			public Boolean? IsVATAccount { get; set; } 
			[DataMember]
			public Boolean? IsSupplierAccount { get; set; } 
			[DataMember]
			public Boolean? IsBankAccount { get; set; } 
			[DataMember]
			public Boolean? IsCashBox { get; set; } 

		}
		#endregion
		#region SClass L3BA_GBAPBPAfBP_1717 for attribute L3BA_GBAPBPAfBP_1717
		[DataContract]
		public class L3BA_GBAPBPAfBP_1717 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID { get; set; } 
			[DataMember]
			public Guid BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid BookingAccount_RefID { get; set; } 
			[DataMember]
			public String BookingAccountName { get; set; } 
			[DataMember]
			public String BookingAccountNumber { get; set; } 
			[DataMember]
			public Boolean Is_L1_BalanceSheet_Account { get; set; } 
			[DataMember]
			public Boolean Is_L1_IncomeStatement_Account { get; set; } 
			[DataMember]
			public Boolean Is_L2_AssetAccount { get; set; } 
			[DataMember]
			public Boolean Is_L2_LiabilitiesAccount { get; set; } 
			[DataMember]
			public Boolean Is_L2_RevenuesOrIncomeAccount { get; set; } 
			[DataMember]
			public Boolean Is_L2_ExpensesOrLossesAccount { get; set; } 
			[DataMember]
			public Guid If_L3_AssetAccount_BankAccount_RefID { get; set; } 
			[DataMember]
			public Boolean Is_L3_BankAccount { get; set; } 
			[DataMember]
			public Boolean Is_L3_CustomerAccount { get; set; } 
			[DataMember]
			public Boolean Is_L3_SupplierAccount { get; set; } 
			[DataMember]
			public Boolean Is_L3_VATAccount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3BA_GBAPBPAfBP_1717_Array cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List(,P_L3BA_GBAPBPAfBP_1717 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3BA_GBAPBPAfBP_1717_Array invocationResult = cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List.Invoke(connectionString,P_L3BA_GBAPBPAfBP_1717 Parameter,securityTicket);
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
var parameter = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GBAPBPAfBP_1717();
parameter.FiscalYearID = ...;
parameter.BusinessParticipantID_List = ...;
parameter.IsRevenueAccount = ...;
parameter.IsCustomerAccount = ...;
parameter.IsVATAccount = ...;
parameter.IsSupplierAccount = ...;
parameter.IsBankAccount = ...;
parameter.IsCashBox = ...;

*/
