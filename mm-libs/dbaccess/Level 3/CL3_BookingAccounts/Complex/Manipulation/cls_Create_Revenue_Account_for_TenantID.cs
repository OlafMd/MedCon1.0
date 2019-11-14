/* 
 * Generated on 5/30/2014 9:03:28 AM
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
    /// var result = cls_Create_Revenue_Account_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Revenue_Account_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L3BA_CRAfT_0903 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Bool();

            #region Tenant's Business Participant
            
            var tenantBP = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
                new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query
                {
                    IsTenant = true,
                    IfTenant_Tenant_RefID = securityTicket.TenantID,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();
            
            #endregion

            #region Retrieve all valid taxes

            var taxQuery = new CL1_ACC_TAX.ORM_ACC_TAX_Tax.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            };
            var taxes = CL1_ACC_TAX.ORM_ACC_TAX_Tax.Query.Search(Connection, Transaction, taxQuery);

            #endregion

            int counter = 0;
            foreach (var tax in taxes)
            {
                #region Booking Account
                
                var bookingAccountParam = new P_L3BA_CBA_1305
                {
                    FiscalYearID = Parameter.FiscalYearID,
                    BookingAccountName = tenantBP.DisplayName,
                    BookingAccountNumber = String.Format("{0:000000000000}", counter + 1)
                };
                Guid bookingAccountID = cls_Create_Booking_Account.Invoke(Connection, Transaction, bookingAccountParam, securityTicket).Result;

                #endregion

                #region Create Account assignment to booking account as "Revenue Account"

                var bookingAccountTypeParam = new P_L3BA_SBAT_1310
                {
                    BookingAccountID = bookingAccountID,
                    BusinessParticipantID = tenantBP.CMN_BPT_BusinessParticipantID,
                    FiscalYearID = Parameter.FiscalYearID,
                    IsRevenueAccount = true,
                    TaxRate = tax.TaxRate
                };
                cls_Set_Booking_Account_Type.Invoke(Connection, Transaction, bookingAccountTypeParam, securityTicket);

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
		public static FR_Bool Invoke(string ConnectionString,P_L3BA_CRAfT_0903 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L3BA_CRAfT_0903 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BA_CRAfT_0903 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BA_CRAfT_0903 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_Revenue_Account_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3BA_CRAfT_0903 for attribute P_L3BA_CRAfT_0903
		[DataContract]
		public class P_L3BA_CRAfT_0903 
		{
			//Standard type parameters
			[DataMember]
			public Guid FiscalYearID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Create_Revenue_Account_for_TenantID(,P_L3BA_CRAfT_0903 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Create_Revenue_Account_for_TenantID.Invoke(connectionString,P_L3BA_CRAfT_0903 Parameter,securityTicket);
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
var parameter = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CRAfT_0903();
parameter.FiscalYearID = ...;

*/
