/* 
 * Generated on 5/29/2014 4:57:48 PM
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

namespace CL3_BookingAccounts.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Customer_Account_for_BusinessParticipants.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Customer_Account_for_BusinessParticipants
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L3BA_CCAfBP_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();

            #region Check if the business participants already have booking account and skip creation for them.
            
            var checkParam = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GBAPBPAfBP_1717
            {
                FiscalYearID = Parameter.FiscalYearID,
                BusinessParticipantID_List = Parameter.BusinessParticipantIDs
            };

            var bpThatAlreadyHaveAccountArray = CL3_BookingAccounts.Atomic.Retrieval.cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List.Invoke(
                Connection, Transaction, checkParam, securityTicket).Result.Select(x => x.BusinessParticipant_RefID);

            var bpItems = Parameter.BusinessParticipantIDs.Except(bpThatAlreadyHaveAccountArray);

            #endregion

            foreach (var BPID in bpItems)
            {
                var accBPAssignment = CL3_BookingAccounts.Utils.BookingAccountUtils.GetEmptyCustomerAccount();

                #region Business participant's data
                
                var customer = CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction,
                    new CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_Customer.Query
                    {
                        Ext_BusinessParticipant_RefID = BPID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();

                var businessParticipant = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
                   new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query
                   {
                       CMN_BPT_BusinessParticipantID = BPID,
                       IsDeleted = false,
                       Tenant_RefID = securityTicket.TenantID
                   }).Single();

                #endregion

                #region Create booking account
                
                var bookingAccount = new CL1_ACC_BOK.ORM_ACC_BOK_BookingAccount
                {
                    ACC_BOK_BookingAccountID = Guid.NewGuid(),
                    BookingAccountName = businessParticipant.DisplayName, // TODO: just name or something else?
                    BookingAccountNumber = customer.InternalCustomerNumber,
                    FiscalYear_RefID = Parameter.FiscalYearID,
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID
                };
                bookingAccount.Save(Connection, Transaction);

                #endregion

                #region Create Account assignment to booking account as "Customer Account"

                var accountAssignment = CL3_BookingAccounts.Utils.BookingAccountUtils.GetEmptyCustomerAccount();
                accountAssignment.ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID = Guid.NewGuid();
                accountAssignment.BookingAccount_RefID = bookingAccount.ACC_BOK_BookingAccountID;
                accountAssignment.BusinessParticipant_RefID = BPID;
                accountAssignment.Creation_Timestamp = DateTime.Now;
                accountAssignment.Tenant_RefID = securityTicket.TenantID;

                accountAssignment.Save(Connection, Transaction);

                #endregion
            }

            returnValue.Result = true;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L3BA_CCAfBP_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L3BA_CCAfBP_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BA_CCAfBP_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BA_CCAfBP_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Create_Customer_Account_for_BusinessParticipants",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3BA_CCAfBP_1655 for attribute P_L3BA_CCAfBP_1655
		[DataContract]
		public class P_L3BA_CCAfBP_1655 
		{
			//Standard type parameters
			[DataMember]
			public Guid FiscalYearID { get; set; } 
			[DataMember]
			public Guid[] BusinessParticipantIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Create_Customer_Account_for_BusinessParticipants(,P_L3BA_CCAfBP_1655 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Create_Customer_Account_for_BusinessParticipants.Invoke(connectionString,P_L3BA_CCAfBP_1655 Parameter,securityTicket);
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
var parameter = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CCAfBP_1655();
parameter.FiscalYearID = ...;
parameter.BusinessParticipantIDs = ...;

*/
