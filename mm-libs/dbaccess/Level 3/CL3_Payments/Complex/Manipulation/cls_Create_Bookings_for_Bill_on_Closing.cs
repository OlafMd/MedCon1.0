/* 
 * Generated on 5/30/2014 2:50:43 PM
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
    /// var result = cls_Create_Bookings_for_Bill_on_Closing.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Bookings_for_Bill_on_Closing
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PY_CBfB_0959 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();

            /*
             * 0. Load current fiscal year;
             * 1. Load bill header and positions
             * 2. Load taxes for products on bill positions
             * 3. Load VAT booking accounts for retrieved taxes from positions
             * 4. Load customer's account (debtor) -- from BillRecepient_BPID
             * 5. Load tenant's revenue accounts per taxes
             * 6. Create one transaction and multiple booking lines
             * 7. Create link between bill and acc. transaction
             */

            #region 0. Load current fiscal year

            Guid currentFiscalYearID = CL2_FiscalYear.Complex.Retrieval.cls_Get_Current_FiscalYear.Invoke(Connection, Transaction, securityTicket).Result.ACC_FiscalYearID;

            #endregion

            #region 1. Load bill positions

            var billPositions = CL1_BIL.ORM_BIL_BillPosition.Query.Search(Connection, Transaction,
                new CL1_BIL.ORM_BIL_BillPosition.Query
                {
                    BIL_BilHeader_RefID = Parameter.BillHeaderID
                });
            if (billPositions != null && billPositions.Count > 0)
            {
            #endregion

                #region 2. Load taxes for products on bill positions

                Guid[] applicableTaxes = billPositions.Select(x => x.ApplicableSalesTax_RefID).Distinct().ToArray();

                #endregion

                #region 3. Load VAT booking accounts for retrieved taxes from positions

                var taxAccountsParam = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GAfTaFY_1647
                {
                    FiscalYearID = currentFiscalYearID,
                    TaxID = applicableTaxes,
                    IsTaxAccount = true,
                    IsRevenueAccount = false
                };

                var taxAccountAssignments = CL3_BookingAccounts.Atomic.Retrieval.cls_Get_Assignment_for_TaxID_List_and_FiscalYearID.Invoke(
                    Connection, Transaction, taxAccountsParam, securityTicket).Result;

                #endregion

                #region 4. Load customer's account (debtor) -- from BillRecepient_BPID

                var param = new CL3_Payments.Complex.Retrieval.P_L3PY_GBAfBP_1521
                {
                    FiscalYearID = currentFiscalYearID,
                    BillHeaderID = Parameter.BillHeaderID
                };

                var billDataWithBookingAccounts = CL3_Payments.Complex.Retrieval.cls_Get_Booking_Accounts_for_Bill_Participants.Invoke(Connection, Transaction, param, securityTicket).Result;

                #endregion

                #region 5. Load tenant's revenue accounts per taxes

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

                #region 6. Create one transaction and multiple booking lines

                var transactionParam = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315
                {
                    AccountingTransactionTypeID = Guid.Empty,
                    CurrencyID = billDataWithBookingAccounts.Bill.CurrencyID,
                    DateOfTransaction = DateTime.Now
                };

                var bookingLines = new List<CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a>();

                CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a bookingLine = null;

                #region VAT Accounts booking lines

                foreach (var item in taxAccountAssignments)
                {
                    bookingLine = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a();
                    bookingLine.BookingAccountID = item.ACC_BOK_BookingAccount_RefID;
                    // VAT-account: Bill VAT amount is booked with positive sign
                    decimal taxValue = billPositions.Where(x => x.ApplicableSalesTax_RefID == item.ACC_TAX_Tax_RefID).Sum(x => x.PositionValue_IncludingTax - x.PositionValue_BeforeTax);
                    bookingLine.TransactionValue = taxValue;
                    bookingLines.Add(bookingLine);
                }

                #endregion

                #region Customer Account booking line

                bookingLine = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a();
                bookingLine.BookingAccountID = billDataWithBookingAccounts.CustomerAccount.BookingAccountID;
                // Debtor account: Bill amount including VAT is booked as receivable with negative sign
                bookingLine.TransactionValue = -(1) * billDataWithBookingAccounts.Bill.TotalValuee_with_DunningFees_IncludingTax;
                bookingLines.Add(bookingLine);

                #endregion

                #region Tenant's Revenue Account booking line

                foreach (var revenueAccount in revenueAccountAssignments)
                {
                    bookingLine = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315a();

                    bookingLine.BookingAccountID = revenueAccount.ACC_BOK_BookingAccount_RefID;
                    // Revenue account: Bill amount is booked  with positive sign
                    decimal value = billPositions.Where(x => x.ApplicableSalesTax_RefID == revenueAccount.ACC_TAX_Tax_RefID).Sum(x => x.PositionValue_BeforeTax);
                    bookingLine.TransactionValue = value;

                    bookingLines.Add(bookingLine);
                }

                #endregion

                transactionParam.BookingLines = bookingLines.ToArray();

                Guid accountTransactionID = CL3_BookingAccounts.Complex.Manipulation.cls_Create_Accounting_Transaction_with_BookingLines.Invoke(
                    Connection, Transaction, transactionParam, securityTicket).Result;

                #endregion

                #region 7. Create link between bill and acc. transaction

                var bill2Transaction = new CL1_BIL.ORM_BIL_BillHeader_2_AccountingTransaction
                {
                    AssignmentID = Guid.NewGuid(),
                    ACC_BOK_Accounting_Transaction_RefID = accountTransactionID,
                    BIL_BillHeader_RefID = Parameter.BillHeaderID,
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID
                };
                bill2Transaction.Save(Connection, Transaction);

                #endregion
            }
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3PY_CBfB_0959 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3PY_CBfB_0959 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PY_CBfB_0959 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PY_CBfB_0959 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_Bookings_for_Bill_on_Closing",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PY_CBfB_0959 for attribute P_L3PY_CBfB_0959
		[DataContract]
		public class P_L3PY_CBfB_0959 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_Bookings_for_Bill_on_Closing(,P_L3PY_CBfB_0959 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_Bookings_for_Bill_on_Closing.Invoke(connectionString,P_L3PY_CBfB_0959 Parameter,securityTicket);
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
var parameter = new CL3_Payments.Complex.Manipulation.P_L3PY_CBfB_0959();
parameter.BillHeaderID = ...;

*/
