/* 
 * Generated on 5/29/2014 3:25:27 PM
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
    /// var result = cls_Create_Tax_Booking_Accounts_for_Taxes.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Tax_Booking_Accounts_for_Taxes
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L3BA_CTBAfT_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();

            #region Tax account counter for fiscal year - until better solution comes

            var taxAccountCounter = CL1_ACC_BOK.ORM_ACC_BOK_BookingAccount.Query.Search(Connection, Transaction,
                new CL1_ACC_BOK.ORM_ACC_BOK_BookingAccount.Query
                {
                    FiscalYear_RefID = Parameter.FiscalYearID,
                    Tenant_RefID = securityTicket.TenantID
                }).Count();

            #endregion

            #region Find out if there is already made account for this tax in this fiscalyear

            var param = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GAfTaFY_1647
            {
                FiscalYearID = Parameter.FiscalYearID,
                TaxID = Parameter.TaxIDs,
                IsTaxAccount = true,
                IsRevenueAccount = false
            };
            var alreadyExists = CL3_BookingAccounts.Atomic.Retrieval.cls_Get_Assignment_for_TaxID_List_and_FiscalYearID.Invoke(Connection, Transaction, param, securityTicket).Result;
            var taxesNotAssignedAccount = Parameter.TaxIDs.Except(alreadyExists.Select(x => x.ACC_TAX_Tax_RefID));

            #endregion

            foreach (var taxID in taxesNotAssignedAccount)
            {
                #region Load Tax

                var taxQuery = new CL1_ACC_TAX.ORM_ACC_TAX_Tax.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                };
                var tax = new CL1_ACC_TAX.ORM_ACC_TAX_Tax();
                tax.Load(Connection, Transaction, taxID);

                #endregion

                #region Create booking account
                
                var bookingAccountParam = new P_L3BA_CBA_1305
                {
                    FiscalYearID = Parameter.FiscalYearID,
                    BookingAccountName = String.Format("VAT {0}%", tax.TaxRate),
                    BookingAccountNumber = String.Format("{0:000000000000}", taxAccountCounter + 1)
                };
                Guid bookingAccountID = cls_Create_Booking_Account.Invoke(Connection, Transaction, bookingAccountParam, securityTicket).Result;

                #endregion

                #region Booking account 2 tax

                Guid tenantBPID = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
                    new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query
                    {
                        IfTenant_Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single().CMN_BPT_BusinessParticipantID;
                
                var bookingAccountTypeParam = new P_L3BA_SBAT_1310
                {
                    BookingAccountID = bookingAccountID,
                    BusinessParticipantID = tenantBPID,
                    FiscalYearID = Parameter.FiscalYearID,
                    IsVATAccount = true,
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
		public static FR_Bool Invoke(string ConnectionString,P_L3BA_CTBAfT_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L3BA_CTBAfT_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BA_CTBAfT_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BA_CTBAfT_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_Tax_Booking_Accounts_for_Taxes",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3BA_CTBAfT_1519 for attribute P_L3BA_CTBAfT_1519
		[DataContract]
		public class P_L3BA_CTBAfT_1519 
		{
			//Standard type parameters
			[DataMember]
			public Guid FiscalYearID { get; set; } 
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid[] TaxIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Create_Tax_Booking_Accounts_for_Taxes(,P_L3BA_CTBAfT_1519 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Create_Tax_Booking_Accounts_for_Taxes.Invoke(connectionString,P_L3BA_CTBAfT_1519 Parameter,securityTicket);
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
var parameter = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CTBAfT_1519();
parameter.FiscalYearID = ...;
parameter.BusinessParticipantID = ...;
parameter.TaxIDs = ...;

*/
