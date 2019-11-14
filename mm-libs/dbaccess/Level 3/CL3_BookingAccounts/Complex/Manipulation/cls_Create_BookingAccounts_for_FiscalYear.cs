/* 
 * Generated on 5/29/2014 3:24:32 PM
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
    /// var result = cls_Create_BookingAccounts_for_FiscalYear.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_BookingAccounts_for_FiscalYear
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3BA_CBAfFY_1249 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            Guid currentFiscalYearID = Parameter.ACC_FiscalYearID;
             
            #region Get current fiscal year if none is given by the parameter

            if (currentFiscalYearID == Guid.Empty)
            {
                currentFiscalYearID = CL2_FiscalYear.Complex.Retrieval.cls_Get_Current_FiscalYear.Invoke(Connection, Transaction, securityTicket).Result.ACC_FiscalYearID;
            }

            #endregion

            #region Get tenant's business participant ID
            
            var tenantBusinessParticipantID = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new 
                CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query
                {
                    IsDeleted = false,
                    IsTenant = true,
                    IfTenant_Tenant_RefID = securityTicket.TenantID
                }).Single().CMN_BPT_BusinessParticipantID;

            #endregion

            #region Create VAT accounts (made for each tax)

            var taxParam = new P_L3BA_CTBAfFY_1530
            {
                BusinessParticipantID = tenantBusinessParticipantID,
                FiscalYearID = currentFiscalYearID
            };
            
            cls_Create_Tax_Booking_Accounts_for_FiscalYear.Invoke(Connection, Transaction, taxParam, securityTicket);
            
            #endregion

            #region Create customer accounts for each business participant that is the customer

            var customerBPIDs = CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction,
                new CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_Customer.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Select(x => x.Ext_BusinessParticipant_RefID);

            if (customerBPIDs.Count() > 0)
            {
                var customerAccParam = new P_L3BA_CCAfBP_1655
                {
                    FiscalYearID = currentFiscalYearID,
                    BusinessParticipantIDs = customerBPIDs.ToArray()
                };
                cls_Create_Customer_Account_for_BusinessParticipants.Invoke(Connection, Transaction, customerAccParam, securityTicket);
            }

            #endregion

            #region Create revenue account for business participant that is the current tenant

            var revAccParam = new P_L3BA_CRAfT_0903
            {
                FiscalYearID = currentFiscalYearID
            };
            
            cls_Create_Revenue_Account_for_TenantID.Invoke(Connection, Transaction, revAccParam, securityTicket);

            #endregion

            #region Create bank account for business participant that is the current tenant

            var tenantBP = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
                new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query
                {
                    IsTenant = true,
                    IfTenant_Tenant_RefID = securityTicket.TenantID,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

            var bnkAccParam = new P_L3BA_CBA_1141
            {
                FiscalYearID = currentFiscalYearID,
                BusinessParticipantID = tenantBP.CMN_BPT_BusinessParticipantID,
                BookingAccountName = tenantBP.DisplayName
            };

            cls_Create_Bank_Account.Invoke(Connection, Transaction, bnkAccParam, securityTicket);

            #endregion
            
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3BA_CBAfFY_1249 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3BA_CBAfFY_1249 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BA_CBAfFY_1249 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BA_CBAfFY_1249 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_BookingAccounts_for_FiscalYear",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3BA_CBAfFY_1249 for attribute P_L3BA_CBAfFY_1249
		[DataContract]
		public class P_L3BA_CBAfFY_1249 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_FiscalYearID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_BookingAccounts_for_FiscalYear(,P_L3BA_CBAfFY_1249 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_BookingAccounts_for_FiscalYear.Invoke(connectionString,P_L3BA_CBAfFY_1249 Parameter,securityTicket);
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
var parameter = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CBAfFY_1249();
parameter.ACC_FiscalYearID = ...;

*/
