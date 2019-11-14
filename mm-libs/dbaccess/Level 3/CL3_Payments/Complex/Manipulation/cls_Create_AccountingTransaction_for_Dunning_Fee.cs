/* 
 * Generated on 7/7/2014 8:51:12 AM
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
using System.Runtime.Serialization;

namespace CL3_Payments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_AccountingTransaction_for_Dunning_Fee.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_AccountingTransaction_for_Dunning_Fee
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PY_CATfDF_0849 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            /*
             * 0. Load current fiscal year
             * 1. Find bill recepient and load his customer booking account
             * 2. Find tenant's "other income" booking account i.e. revenue account for tax that is 0%
             * 3. Create one transaction and multiple booking lines
             */

            #region 0. Load current fiscal year

            Guid currentFiscalYearID = CL2_FiscalYear.Complex.Retrieval.cls_Get_Current_FiscalYear.Invoke(Connection, Transaction, securityTicket).Result.ACC_FiscalYearID;

            #endregion

            #region 1. Find bill recepient to load his customer booking account

            var billHeader = new CL1_BIL.ORM_BIL_BillHeader();
            billHeader.Load(Connection, Transaction, Parameter.BillHeaderID);

            var cbaParam = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GBAPBPAfBP_1717
            {
                FiscalYearID = currentFiscalYearID,
                IsCustomerAccount = true,
                BusinessParticipantID_List = new Guid[] { billHeader.BillRecipient_BuisnessParticipant_RefID }
            };
            Guid customerBookingAccountID = CL3_BookingAccounts.Atomic.Retrieval.cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List.Invoke(
                Connection, Transaction, cbaParam, securityTicket).Result.Single().BookingAccount_RefID;

            #endregion

            #region 2. Find tenant's "other incomes" booking account i.e. revenue account for tax that is 0%

            Guid tenantBPID = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
                new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query
                {
                    IfTenant_Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single().CMN_BPT_BusinessParticipantID;

            var taxZero = CL1_ACC_TAX.ORM_ACC_TAX_Tax.Query.Search(Connection, Transaction,
                new CL1_ACC_TAX.ORM_ACC_TAX_Tax.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).SingleOrDefault(x => Double.Equals(x.TaxRate, 0.0d));

            if (taxZero == null)
            {
                return returnValue;
            }

            var tbaParam = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GAfTaFY_1647
            {
                FiscalYearID = currentFiscalYearID,
                IsRevenueAccount = true,
                IsTaxAccount = false,
                TaxID = new Guid[] { taxZero.ACC_TAX_TaxeID }
            };
            Guid otherIncomeAccountID = CL3_BookingAccounts.Atomic.Retrieval.cls_Get_Assignment_for_TaxID_List_and_FiscalYearID.Invoke(
                Connection, Transaction, tbaParam, securityTicket).Result.Single().ACC_BOK_BookingAccount_RefID;

            #endregion

            #region 3. Create one transaction and multiple booking lines
            
            var transactionParam = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315
            {
                AccountingTransactionTypeID = Guid.Empty,
                CurrencyID = billHeader.Currency_RefID,
                DateOfTransaction = DateTime.Now
            };

            var bookingLines = new List<CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a>();
            CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a bookingLine = null;

            #region Booking line for customer account

            bookingLine = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a()
            {
                BookingAccountID = customerBookingAccountID,
                // Debtor account: Dunning fee is booked as receivable with negative sign
                TransactionValue = -1 * Parameter.DunningFee
            };
            bookingLines.Add(bookingLine);

            #endregion

            #region Booking line for tenant's "other income" account

            bookingLine = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a
            {
                BookingAccountID = otherIncomeAccountID,
                // "Other income account" Dunning Fee is booked with positive sign
                TransactionValue = Parameter.DunningFee
            };
            bookingLines.Add(bookingLine);

            #endregion

            transactionParam.BookingLines = bookingLines.ToArray();

            Guid accountTransactionID = CL3_BookingAccounts.Complex.Manipulation.cls_Create_Accounting_Transaction_with_BookingLines.Invoke(
                Connection, Transaction, transactionParam, securityTicket).Result;
            
            #endregion

            returnValue.Result = accountTransactionID;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3PY_CATfDF_0849 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3PY_CATfDF_0849 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PY_CATfDF_0849 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PY_CATfDF_0849 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_AccountingTransaction_for_Dunning_Fee",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PY_CATfDF_0849 for attribute P_L3PY_CATfDF_0849
		[DataContract]
		public class P_L3PY_CATfDF_0849 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 
			[DataMember]
			public Decimal DunningFee { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_AccountingTransaction_for_Dunning_Fee(,P_L3PY_CATfDF_0849 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_AccountingTransaction_for_Dunning_Fee.Invoke(connectionString,P_L3PY_CATfDF_0849 Parameter,securityTicket);
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
var parameter = new CL3_Payments.Complex.Manipulation.P_L3PY_CATfDF_0849();
parameter.BillHeaderID = ...;
parameter.DunningFee = ...;

*/
