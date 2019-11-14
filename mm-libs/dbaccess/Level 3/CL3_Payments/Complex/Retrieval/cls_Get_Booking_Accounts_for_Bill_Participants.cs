/* 
 * Generated on 7/8/2014 9:50:01 AM
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

namespace CL3_Payments.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Booking_Accounts_for_Bill_Participants.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Booking_Accounts_for_Bill_Participants
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PY_GBAfBP_1521 Execute(DbConnection Connection,DbTransaction Transaction,P_L3PY_GBAfBP_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3PY_GBAfBP_1521();
            
            #region Load customer's account (debtor) -- from BillRecepient_BPID

            var billHeader = new CL1_BIL.ORM_BIL_BillHeader();
            billHeader.Load(Connection, Transaction, Parameter.BillHeaderID);

            // Customer's BusinessParticipant ID
            Guid customerBPID = billHeader.BillRecipient_BuisnessParticipant_RefID;

            // Current tenant's BusinessParticipant ID
            var tenantBPID = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query
            {
                IfTenant_Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Single().CMN_BPT_BusinessParticipantID;

            var customerAccParam = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GBAPBPAfBP_1717
            {
                FiscalYearID = Parameter.FiscalYearID,
                BusinessParticipantID_List = new Guid[] { customerBPID, tenantBPID }
            };

            var accountsAssignments = CL3_BookingAccounts.Atomic.Retrieval.cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List.Invoke
                (Connection, Transaction, customerAccParam, securityTicket).Result;

            Guid customerBookingAccountID = accountsAssignments.Single(x => x.BusinessParticipant_RefID == customerBPID).BookingAccount_RefID;

            #endregion

            #region Find dunning fees applied to this bill

            var dunningProcessMemberBill = CL1_ACC_DUN.ORM_ACC_DUN_DunningProcess_MemberBill.Query.Search(Connection, Transaction,
                new CL1_ACC_DUN.ORM_ACC_DUN_DunningProcess_MemberBill.Query
                {
                    BIL_BillHeader_RefID = Parameter.BillHeaderID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).SingleOrDefault();

            decimal applicableProcessDunningFees = (dunningProcessMemberBill == null) ? 0.0M : dunningProcessMemberBill.ApplicableProcessDunningFees;

            #endregion

            #region Bind retrieved data to returning object

            var result = new L3PY_GBAfBP_1521();
            // bill
            result.Bill = new L3PY_GBAfBP_1521a();
            result.Bill.CurrencyID = billHeader.Currency_RefID;
            result.Bill.TotalValue_with_DunningFees_BeforeTax = billHeader.TotalValue_BeforeTax + applicableProcessDunningFees;
            result.Bill.TotalValuee_with_DunningFees_IncludingTax = billHeader.TotalValue_IncludingTax + applicableProcessDunningFees;
            // customer
            result.CustomerAccount = new L3PY_GBAfBP_1521b();
            result.CustomerAccount.BookingAccountID = customerBookingAccountID;
            result.CustomerAccount.BusinessParticipantID = customerBPID;

            #endregion

            returnValue.Result = result;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PY_GBAfBP_1521 Invoke(string ConnectionString,P_L3PY_GBAfBP_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PY_GBAfBP_1521 Invoke(DbConnection Connection,P_L3PY_GBAfBP_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PY_GBAfBP_1521 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PY_GBAfBP_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PY_GBAfBP_1521 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PY_GBAfBP_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PY_GBAfBP_1521 functionReturn = new FR_L3PY_GBAfBP_1521();
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

				throw new Exception("Exception occured in method cls_Get_Booking_Accounts_for_Bill_Participants",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PY_GBAfBP_1521 : FR_Base
	{
		public L3PY_GBAfBP_1521 Result	{ get; set; }

		public FR_L3PY_GBAfBP_1521() : base() {}

		public FR_L3PY_GBAfBP_1521(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PY_GBAfBP_1521 for attribute P_L3PY_GBAfBP_1521
		[DataContract]
		public class P_L3PY_GBAfBP_1521 
		{
			//Standard type parameters
			[DataMember]
			public Guid FiscalYearID { get; set; } 
			[DataMember]
			public Guid BillHeaderID { get; set; } 
			[DataMember]
			public Guid BillRecepientID { get; set; } 

		}
		#endregion
		#region SClass L3PY_GBAfBP_1521 for attribute L3PY_GBAfBP_1521
		[DataContract]
		public class L3PY_GBAfBP_1521 
		{
			[DataMember]
			public L3PY_GBAfBP_1521a Bill { get; set; }
			[DataMember]
			public L3PY_GBAfBP_1521b CustomerAccount { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L3PY_GBAfBP_1521a for attribute Bill
		[DataContract]
		public class L3PY_GBAfBP_1521a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CurrencyID { get; set; } 
			[DataMember]
			public Decimal TotalValue_with_DunningFees_BeforeTax { get; set; } 
			[DataMember]
			public Decimal TotalValuee_with_DunningFees_IncludingTax { get; set; } 

		}
		#endregion
		#region SClass L3PY_GBAfBP_1521b for attribute CustomerAccount
		[DataContract]
		public class L3PY_GBAfBP_1521b 
		{
			//Standard type parameters
			[DataMember]
			public Guid BookingAccountID { get; set; } 
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PY_GBAfBP_1521 cls_Get_Booking_Accounts_for_Bill_Participants(,P_L3PY_GBAfBP_1521 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PY_GBAfBP_1521 invocationResult = cls_Get_Booking_Accounts_for_Bill_Participants.Invoke(connectionString,P_L3PY_GBAfBP_1521 Parameter,securityTicket);
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
var parameter = new CL3_Payments.Complex.Retrieval.P_L3PY_GBAfBP_1521();
parameter.FiscalYearID = ...;
parameter.BillHeaderID = ...;
parameter.BillRecepientID = ...;

*/
