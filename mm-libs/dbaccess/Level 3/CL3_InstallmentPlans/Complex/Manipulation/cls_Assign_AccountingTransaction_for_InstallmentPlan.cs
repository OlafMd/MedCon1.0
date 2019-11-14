/* 
 * Generated on 7/16/2014 3:55:55 PM
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

namespace CL3_InstallmentPlans.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Assign_AccountingTransaction_for_InstallmentPlan.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Assign_AccountingTransaction_for_InstallmentPlan
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L3IP_AATfIP_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guids();

            /*
             * 0. Load current's account business participant ID
             * 1. Find all not fully payed installments
             * 2. Assign payment to open installments
             * 3. Change installment plan status history
             * 
             */

            List<Guid> updatedInstallmentIDs = new List<Guid>();

            #region 0. Load current's account business participant ID

            var account = CL1_USR.ORM_USR_Account.Query.Search(Connection, Transaction,
                new CL1_USR.ORM_USR_Account.Query
                {
                    USR_AccountID = securityTicket.AccountID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

            #endregion

            #region 1. Find all not fully payed installments

            var installments = CL1_ACC_IPL.ORM_ACC_IPL_Installment.Query.Search(Connection, Transaction,
                new CL1_ACC_IPL.ORM_ACC_IPL_Installment.Query
                {
                    InstallmentPlan_RefID = Parameter.InstallmentPlanID,
                    IsFullyPaid = false,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).OrderBy(x => x.PaymentDeadline);

            #endregion

            #region 2. Assign payment to open installments and set to fully paid if needed

            CL1_ACC_IPL.ORM_ACC_IPL_Installment_2_AssignedPayment installment2AssignedPayment = null;
            CL1_ACC_IPL.ORM_ACC_IPL_Installment_2_AccountTransactionPairBatch installment2AccountTransactionPairBatch = null;

            decimal unassignedAmount = Parameter.TransactionAmount;
            foreach (var item in installments)
            {
                // stop if unassigned amount has reached zero
                if (Decimal.Compare(unassignedAmount,0M) == 0)
                {
                    break;
                }

                /**
                 * assigned value is amount on installment by default, 
                 * but if it is less than unassigned amount it receives the value of unassigned amount
                 */
                bool isFullyPaid = (item.Amount <= unassignedAmount);

                decimal amountAssignedToInstallment = isFullyPaid ? item.Amount : unassignedAmount;

                installment2AssignedPayment = new CL1_ACC_IPL.ORM_ACC_IPL_Installment_2_AssignedPayment
                {
                    ACC_IPL_Installment_2_AssignedPaymentID = Guid.NewGuid(),
                    ACC_BOK_Accounting_Transaction_RefID = Parameter.AccountingTransactionID,
                    ACC_IPL_Installment_RefID = item.ACC_IPL_InstallmentID,
                    AssignedValue = amountAssignedToInstallment,
                    AssignedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID,
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID
                };
                installment2AssignedPayment.Save(Connection, Transaction);

                installment2AccountTransactionPairBatch = new CL1_ACC_IPL.ORM_ACC_IPL_Installment_2_AccountTransactionPairBatch
                {
                    AssignmentID = Guid.NewGuid(),
                    ACC_BOK_Accounting_Transaction_RefID = Parameter.AccountingTransactionID,
                    ACC_IPL_Installment_RefID = item.ACC_IPL_InstallmentID,
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID
                };
                installment2AccountTransactionPairBatch.Save(Connection, Transaction);

                #region Set current as fully paid and adjust amount if it is lower than the part of the payment can cover

                if (item.Amount < amountAssignedToInstallment)
                {
                    item.Amount = amountAssignedToInstallment;
                }
                item.IsFullyPaid = true;
                item.Save(Connection, Transaction);
                
                #endregion

                if (isFullyPaid == false)
                {
                    #region Create new installment with the amount that is left on current installment

                    var newInstallment = new CL1_ACC_IPL.ORM_ACC_IPL_Installment
                    {
                        ACC_IPL_InstallmentID = Guid.NewGuid(),
                        InstallmentPlan_RefID = Parameter.InstallmentPlanID,
                        PaymentDeadline = item.PaymentDeadline,
                        IsFullyPaid = false,
                        Amount = item.Amount - unassignedAmount,
                        Tenant_RefID = securityTicket.TenantID 
                    };

                    newInstallment.IsFullyPaid = false;
                    newInstallment.Save(Connection, Transaction);

                    #endregion
                }

                unassignedAmount -= amountAssignedToInstallment;

                updatedInstallmentIDs.Add(item.ACC_IPL_InstallmentID);
            }

            #endregion

            #region 3. Change installment plan status history

            var statusHistoryParam = new P_L3IP_CIPSH_1447
            {
                InstallmentPlanID = Parameter.InstallmentPlanID,
                DoTerminate = false
            };
            cls_Change_InstallmentPlan_StatusHistory.Invoke(Connection, Transaction, statusHistoryParam, securityTicket);

            #endregion

            returnValue.Result = updatedInstallmentIDs.ToArray();

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L3IP_AATfIP_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L3IP_AATfIP_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L3IP_AATfIP_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3IP_AATfIP_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guids functionReturn = new FR_Guids();
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

				throw new Exception("Exception occured in method cls_Assign_AccountingTransaction_for_InstallmentPlan",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3IP_AATfIP_1331 for attribute P_L3IP_AATfIP_1331
		[DataContract]
		public class P_L3IP_AATfIP_1331 
		{
			//Standard type parameters
			[DataMember]
			public Guid InstallmentPlanID { get; set; } 
			[DataMember]
			public Guid AccountingTransactionID { get; set; } 
			[DataMember]
			public Decimal TransactionAmount { get; set; } 
			[DataMember]
			public DateTime PaymentDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Assign_AccountingTransaction_for_InstallmentPlan(,P_L3IP_AATfIP_1331 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Assign_AccountingTransaction_for_InstallmentPlan.Invoke(connectionString,P_L3IP_AATfIP_1331 Parameter,securityTicket);
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
var parameter = new CL3_InstallmentPlans.Complex.Manipulation.P_L3IP_AATfIP_1331();
parameter.InstallmentPlanID = ...;
parameter.AccountingTransactionID = ...;
parameter.TransactionAmount = ...;
parameter.PaymentDate = ...;

*/
