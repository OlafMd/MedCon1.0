/* 
 * Generated on 7/3/2014 10:52:46 AM
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
    /// var result = cls_Create_Payments_for_Bill.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Payments_for_Bill
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PY_CPfB_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            /*
             * 0. Get current fiscal year
             * 1. Get current's account business participant
             * 2. Get booking accounts for bill's revenue participant and debtor participant
             * 3. Find unpayed amount for bill
             * 4. Create accounting transaction with booking lines
             * 5. Create new bill header assigned payment entry and assign accunting transaction to installments
             * 6. Update dunning process if needed
             */

            #region 0. Load current fiscal year

            Guid currentFiscalYearID = CL2_FiscalYear.Complex.Retrieval.cls_Get_Current_FiscalYear.Invoke(Connection, Transaction, securityTicket).Result.ACC_FiscalYearID;

            #endregion

            #region 1. Get current's account business participant
            
            Guid accountBPID = CL1_USR.ORM_USR_Account.Query.Search(Connection, Transaction, 
                new CL1_USR.ORM_USR_Account.Query
                {
                    USR_AccountID = securityTicket.AccountID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single().BusinessParticipant_RefID;
            
            #endregion

            #region 2. Get booking accounts for bill's revenue participant and debtor participant

            var param = new CL3_Payments.Complex.Retrieval.P_L3PY_GBAfBP_1521
            {
                FiscalYearID = currentFiscalYearID,
                BillHeaderID = Parameter.BillHeaderID
            };

            var billDataWithBookingAccounts = CL3_Payments.Complex.Retrieval.cls_Get_Booking_Accounts_for_Bill_Participants.Invoke(Connection, Transaction, param, securityTicket).Result;
            
            #endregion

            #region 3. Find unpayed amount for bill
            
            var payedParam = new CL3_Payments.Atomic.Retrieval.P_L3PY_GPAfB_1312
            {
                BillHeaderID_List = new Guid[] { Parameter.BillHeaderID }
            };
            var payed = CL3_Payments.Atomic.Retrieval.cls_Get_Payed_Amount_for_Bills.Invoke(Connection, Transaction, payedParam, securityTicket).Result;

            decimal amountLeftToBePayed = billDataWithBookingAccounts.Bill.TotalValuee_with_DunningFees_IncludingTax - payed.Single(x => x.BillHeaderID == Parameter.BillHeaderID).TotalPayedValue;

            // check if amount left to be payed is zero or if the amount for the current payment is larger than amount that is left to pay and send error status
            if (Decimal.Compare(amountLeftToBePayed, Decimal.Zero) == 0)
            {
                throw new Exception("Amount left to be payed is zero.");
            }
            else if (Decimal.Compare((amountLeftToBePayed - Parameter.Amount), Decimal.Zero) < 0)
            {
                throw new Exception("Amount for the current payment is larger than amount that is left to pay for this bill");
            }

            #endregion

            #region 4. Create accounting transaction with booking lines

            var transactionParam = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315
            {
                AccountingTransactionTypeID = Guid.Empty,
                CurrencyID = billDataWithBookingAccounts.Bill.CurrencyID,
                DateOfTransaction = Parameter.PaymentDate
            };

            var bookingLines = new List<CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a>();

            CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a bookingLine = null;

            #region Customer Account booking line

            bookingLine = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a();
            bookingLine.BookingAccountID = billDataWithBookingAccounts.CustomerAccount.BookingAccountID;
            // Debtor account: Arrived amount is booked with positive sign
            bookingLine.TransactionValue = Parameter.Amount;
            bookingLines.Add(bookingLine);

            #endregion

            Guid tenantBPID = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
                new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query
                {
                    IfTenant_Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single().CMN_BPT_BusinessParticipantID;

            var bankAccountParam = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GBAPBPAfBP_1717
            {
                BusinessParticipantID_List = new Guid[] { tenantBPID },
                FiscalYearID = currentFiscalYearID,
                IsBankAccount = true
            };
            var bankAccount = CL3_BookingAccounts.Atomic.Retrieval.cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List.Invoke(
                Connection, Transaction, bankAccountParam, securityTicket).Result.SingleOrDefault();

            if (bankAccount != null)
            {

                #region Tenant's Bank Account booking line

                bookingLine = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a();
                bookingLine.BookingAccountID = bankAccount.BookingAccount_RefID;
                // On the tenants bank account the arrived amount is booked with negative sign
                bookingLine.TransactionValue = -1 * Parameter.Amount;
                bookingLines.Add(bookingLine);

                #endregion

                transactionParam.BookingLines = bookingLines.ToArray();

                Guid accountTransactionID = CL3_BookingAccounts.Complex.Manipulation.cls_Create_Accounting_Transaction_with_BookingLines.Invoke(
                    Connection, Transaction, transactionParam, securityTicket).Result;

            #endregion

                #region 5. Create new bill header assigned payment entry and assign accunting transaction to installments

                bool isFullyPaid = Decimal.Compare((amountLeftToBePayed - Parameter.Amount), Decimal.Zero) == 0;
                // if the whole bill is payed before -- stop
                if (Decimal.Compare(amountLeftToBePayed, Decimal.Zero) == 0)
                {
                    return returnValue;
                }
                // if this transaction will pay the rest of the bill set flag on the bill
                else if (isFullyPaid)
                {
                    var billHeader = new CL1_BIL.ORM_BIL_BillHeader();
                    billHeader.Load(Connection, Transaction, Parameter.BillHeaderID);

                    billHeader.IsFullyPaid = true;
                    billHeader.Save(Connection, Transaction);
                }

                var assignParam = new P_L3PY_AATtB_1107
                {
                    AccountTransactionID = accountTransactionID,
                    AssignedAmount = Parameter.Amount,
                    BillHeaderID = Parameter.BillHeaderID,
                    PaymentDate = Parameter.PaymentDate
                };

                cls_Assign_AccountingTransaction_to_Bill.Invoke(Connection, Transaction, assignParam, securityTicket);

                #region Load taxes and bill positions for taxes per position

                var billPositions = CL1_BIL.ORM_BIL_BillPosition.Query.Search(Connection, Transaction,
                    new CL1_BIL.ORM_BIL_BillPosition.Query
                    {
                        BIL_BilHeader_RefID = Parameter.BillHeaderID
                    });

                Guid[] applicableTaxes = billPositions.Select(x => x.ApplicableSalesTax_RefID).Distinct().ToArray();

                var revenueAccountsParam = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GAfTaFY_1647
                {
                    FiscalYearID = currentFiscalYearID,
                    TaxID = applicableTaxes,
                    IsTaxAccount = false,
                    IsRevenueAccount = true
                };

                var revenueAccountAssignments = CL3_BookingAccounts.Atomic.Retrieval.cls_Get_Assignment_for_TaxID_List_and_FiscalYearID.Invoke(
                    Connection, Transaction, revenueAccountsParam, securityTicket).Result;

                #endregion

                var balanceParam = new P_L3PY_CBCfAT_1329
                {
                    AccountingTransactionID = accountTransactionID,
                    BookingAccountID = bankAccount.BookingAccount_RefID,
                    Amount = Parameter.Amount
                };
                cls_Create_BalanceChange_for_AccountingTransaction.Invoke(Connection, Transaction, balanceParam, securityTicket);

                #endregion

                #region 6. Update dunning process if needed

                var dunningProcessMemberBill = CL1_ACC_DUN.ORM_ACC_DUN_DunningProcess_MemberBill.Query.Search(Connection, Transaction,
                    new CL1_ACC_DUN.ORM_ACC_DUN_DunningProcess_MemberBill.Query
                    {
                        BIL_BillHeader_RefID = Parameter.BillHeaderID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).SingleOrDefault();


                if (dunningProcessMemberBill != null)
                {
                    dunningProcessMemberBill.CurrentUnpaidBillFraction = amountLeftToBePayed;
                    dunningProcessMemberBill.Save(Connection, Transaction);

                    var dunningProcess = CL1_ACC_DUN.ORM_ACC_DUN_DunningProcess.Query.Search(Connection, Transaction,
                        new CL1_ACC_DUN.ORM_ACC_DUN_DunningProcess.Query
                        {
                            ACC_DUN_DunningProcessID = dunningProcessMemberBill.ACC_DUN_DunningProcess_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                    if (isFullyPaid)
                    {
                        dunningProcess.IsDunningProcessClosed = true;
                        dunningProcess.DunningProcessClosedAt_Date = DateTime.Now;
                        dunningProcess.DunningProcessClosedBy_BusinessParticipnant_RefID = accountBPID;
                        dunningProcess.Save(Connection, Transaction);
                    }
                }
            }
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3PY_CPfB_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3PY_CPfB_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PY_CPfB_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PY_CPfB_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_Payments_for_Bill",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PY_CPfB_1506 for attribute P_L3PY_CPfB_1506
		[DataContract]
		public class P_L3PY_CPfB_1506 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 
			[DataMember]
			public DateTime PaymentDate { get; set; } 
			[DataMember]
			public Decimal Amount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_Payments_for_Bill(,P_L3PY_CPfB_1506 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_Payments_for_Bill.Invoke(connectionString,P_L3PY_CPfB_1506 Parameter,securityTicket);
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
var parameter = new CL3_Payments.Complex.Manipulation.P_L3PY_CPfB_1506();
parameter.BillHeaderID = ...;
parameter.PaymentDate = ...;
parameter.Amount = ...;

*/
