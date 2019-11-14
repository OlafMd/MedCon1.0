/* 
 * Generated on 6/3/2014 9:48:45 AM
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
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL3_Payments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Assign_Free_Value_from_AccountingTransaction_to_Bill.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Assign_Free_Value_from_AccountingTransaction_to_Bill
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PY_AFVfATtB_0934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            /*
             * 0. Find current fiscal year if none is given by the parameter
             * 1. Load bill to find recepient's BPID
             * 2. Find all values from accounting transactions that are not fully assigned to other bills
             * 3. Assign maximum free amount that needs to be assigned to bill
             */

            #region 0. Find current fiscal year if none is given by the parameter

            Guid currentFiscalYearID = Parameter.FiscalYearID;
            if (currentFiscalYearID == Guid.Empty)
            {
                currentFiscalYearID = CL2_FiscalYear.Complex.Retrieval.cls_Get_Current_FiscalYear.Invoke(
                    Connection, Transaction, securityTicket).Result.ACC_FiscalYearID;
            }

            #endregion
            
            #region 1. Load bill to find recepient's BPID
            
            var billHeader = new CL1_BIL.ORM_BIL_BillHeader();
            billHeader.Load(Connection, Transaction, Parameter.BillHeaderID);

            #endregion

            #region 2. Find all values from accounting transactions that are not fully assigned to other bills

            var unassignedParam = new CL3_Payments.Atomic.Retrieval.P_L3PY_GAATNFAtP_0846
            {
                FiscalYearID = currentFiscalYearID,
                BusinessParticipantID = billHeader.BillRecipient_BuisnessParticipant_RefID
            };

            var transactions = CL3_Payments.Atomic.Retrieval.cls_Get_All_AccountingTransactions_Not_Fully_Assigned_to_Payments.Invoke(
                Connection, Transaction, unassignedParam, securityTicket).Result.Where(x => x.UnassignedTransactionValue > 0);

            #endregion

            #region 3. Assign maximum free amount that needs to be assigned to bill

            var payedParam = new CL3_Payments.Atomic.Retrieval.P_L3PY_GPAfB_1312
            {
                BillHeaderID_List = new Guid[] { Parameter.BillHeaderID }
            };
            var payed = CL3_Payments.Atomic.Retrieval.cls_Get_Payed_Amount_for_Bills.Invoke(Connection, Transaction, payedParam, securityTicket).Result;

            decimal amountLeftToBill = billHeader.TotalValue_IncludingTax - payed.Single(x => x.BillHeaderID == Parameter.BillHeaderID).TotalPayedValue;
            foreach(var item in transactions)
            {
                // if the whole bill is payed with transaction - stop the iteration
                if (Decimal.Compare(amountLeftToBill, Decimal.Zero) == 0)
                {
                    break;
                }

                decimal assignedAmount = item.UnassignedTransactionValue;
                if (amountLeftToBill > item.UnassignedTransactionValue)
                {
                    assignedAmount = amountLeftToBill;
                }

                var assignParam = new P_L3PY_AATtB_1107
                {
                    AccountTransactionID = item.AccountingTransactionID,
                    AssignedAmount = assignedAmount,
                    BillHeaderID = Parameter.BillHeaderID
                };

                cls_Assign_AccountingTransaction_to_Bill.Invoke(Connection, Transaction, assignParam, securityTicket);
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
		public static FR_Guid Invoke(string ConnectionString,P_L3PY_AFVfATtB_0934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3PY_AFVfATtB_0934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PY_AFVfATtB_0934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PY_AFVfATtB_0934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Assign_Free_Value_from_AccountingTransaction_to_Bill",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PY_AFVfATtB_0934 for attribute P_L3PY_AFVfATtB_0934
		[DataContract]
		public class P_L3PY_AFVfATtB_0934 
		{
			//Standard type parameters
			[DataMember]
			public Guid FiscalYearID { get; set; } 
			[DataMember]
			public Guid BillHeaderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Assign_Free_Value_from_AccountingTransaction_to_Bill(,P_L3PY_AFVfATtB_0934 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Assign_Free_Value_from_AccountingTransaction_to_Bill.Invoke(connectionString,P_L3PY_AFVfATtB_0934 Parameter,securityTicket);
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
var parameter = new CL3_Payments.Complex.Manipulation.P_L3PY_AFVfATtB_0934();
parameter.FiscalYearID = ...;
parameter.BillHeaderID = ...;

*/
