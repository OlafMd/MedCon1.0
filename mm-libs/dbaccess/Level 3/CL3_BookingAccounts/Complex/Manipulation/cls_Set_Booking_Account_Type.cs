/* 
 * Generated on 7/29/2014 9:45:48 AM
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
    /// var result = cls_Set_Booking_Account_Type.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Set_Booking_Account_Type
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L3BA_SBAT_1310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 

	        var returnValue = new FR_Bool();

            var tenantBP = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
            new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query
            {
                IsTenant = true,
                IfTenant_Tenant_RefID = securityTicket.TenantID,
                Tenant_RefID = securityTicket.TenantID
            }).Single().CMN_BPT_BusinessParticipantID;


	        CL1_ACC_BOK.ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment assignment = null;

	        var foundAssignments = CL1_ACC_BOK.ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment.Query.Search(Connection,
	            Transaction,
	            new CL1_ACC_BOK.ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment.Query
	            {
	                Tenant_RefID = securityTicket.TenantID,
	                IsDeleted = false,
                    BusinessParticipant_RefID = tenantBP,
                    BookingAccount_RefID = Parameter.BookingAccountID
                    
	            });

 
	        if (Parameter.IsRevenueAccount || Parameter.IsVATAccount)
	        {
	            if (Parameter.IsRevenueAccount)
	            {
	                if (foundAssignments.Count == 0)
	                {
                        assignment = CL3_BookingAccounts.Utils.BookingAccountUtils.GetEmptyRevenueAccount(); 
	                }
                    else
                    {
                        assignment = foundAssignments.Single();
                    }
	            }
	            else // it has to be VAT account
	            {
	                if (foundAssignments.Count == 0)
	                {
                        assignment = CL3_BookingAccounts.Utils.BookingAccountUtils.GetEmptyVATAccount();
	                }
                    else
                    {
                        assignment = foundAssignments.Single();
                    }
	            }

	            #region Get correct Tax by tax rate

	            var taxes = CL1_ACC_TAX.ORM_ACC_TAX_Tax.Query.Search(Connection, Transaction,
	                new CL1_ACC_TAX.ORM_ACC_TAX_Tax.Query
	                {
	                    IsDeleted = false,
	                    Tenant_RefID = securityTicket.TenantID
	                });
	            var tax = taxes.Where(x => Double.Equals(x.TaxRate, Parameter.TaxRate)).SingleOrDefault();
	            if (tax == null)
	            {
	                returnValue.Status = FR_Status.Error_Internal;
	                returnValue.Result = false;
	                return returnValue;
	            }

	            #endregion

	            #region Assign tax to booking account

                
	            CL1_ACC_BOK.ORM_ACC_BOK_BookingAccount_2_Tax foundBooking2Tax = null;

	            if (Parameter.IsRevenueAccount && tax.TaxRate != 0 && foundAssignments != null)
	            {
                    foundBooking2Tax = CL1_ACC_BOK.ORM_ACC_BOK_BookingAccount_2_Tax.Query.Search(Connection, Transaction,
                        new CL1_ACC_BOK.ORM_ACC_BOK_BookingAccount_2_Tax.Query
                        {
                            IsDeleted = false,
                            IsDefaultAccountForRevenueBookings = true,
                            ACC_TAX_Tax_RefID = tax.ACC_TAX_TaxeID
                        }).FirstOrDefault();
	            }
	            else
	            {
                    foundBooking2Tax = CL1_ACC_BOK.ORM_ACC_BOK_BookingAccount_2_Tax.Query.Search(Connection, Transaction,
                        new CL1_ACC_BOK.ORM_ACC_BOK_BookingAccount_2_Tax.Query
                        {
                            ACC_BOK_BookingAccount_RefID = Parameter.BookingAccountID,
                            ACC_TAX_Tax_RefID = tax.ACC_TAX_TaxeID
                        }).SingleOrDefault();
	            }


	            CL1_ACC_BOK.ORM_ACC_BOK_BookingAccount_2_Tax bookingAcc2Tax = null;
	            Guid bookingAccount2Tax_assignmentId;

	            if (foundBooking2Tax != null)
	            {
	                bookingAccount2Tax_assignmentId = foundBooking2Tax.AssignmentID;
	                bookingAcc2Tax = foundBooking2Tax;
	                
	            }
	            else
	            {
	                bookingAcc2Tax = new CL1_ACC_BOK.ORM_ACC_BOK_BookingAccount_2_Tax();
                    bookingAccount2Tax_assignmentId = Guid.NewGuid();
	            }

	            bookingAcc2Tax.AssignmentID = bookingAccount2Tax_assignmentId;
	            bookingAcc2Tax.ACC_BOK_BookingAccount_RefID = Parameter.BookingAccountID;
	            bookingAcc2Tax.ACC_TAX_Tax_RefID = tax.ACC_TAX_TaxeID;
	            bookingAcc2Tax.IsDefaultAccountForRevenueBookings = Parameter.IsRevenueAccount;
	            bookingAcc2Tax.IsDefaultAccountForTaxBookings = Parameter.IsVATAccount;
	            bookingAcc2Tax.Tenant_RefID = securityTicket.TenantID;
	            
	            bookingAcc2Tax.Save(Connection, Transaction);

	            #endregion
	        }
	    


	        else if (Parameter.IsCustomerAccount)
            {
                assignment = CL3_BookingAccounts.Utils.BookingAccountUtils.GetEmptyCustomerAccount();
            }
            else if (Parameter.IsBankAccount)
            {

                var foundAssignments_for_Bank = CL1_ACC_BOK.ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment.Query.Search(Connection,
                Transaction,
                new CL1_ACC_BOK.ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment.Query
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    BusinessParticipant_RefID = tenantBP,
                    Is_L3_BankAccount = true

                });

                if (foundAssignments_for_Bank.Count == 0)
                {
                    assignment = CL3_BookingAccounts.Utils.BookingAccountUtils.GetEmptyBankAccount();
                    assignment.Is_L3_BankAccount = true;
                    assignment.If_L3_AssetAccount_BankAccount_RefID = Parameter.BankAccountID;
                    //assignment.BookingAccount_RefID = Guid.NewGuid();
                }
                else
                {
                    assignment = foundAssignments.Single();
                }


                
            }

            if (assignment != null)
            {
                if (assignment.ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID == Guid.Empty)
                    assignment.ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID = Guid.NewGuid();
                assignment.BookingAccount_RefID = Parameter.BookingAccountID;
                assignment.BusinessParticipant_RefID = Parameter.BusinessParticipantID;
                assignment.Tenant_RefID = securityTicket.TenantID;
                assignment.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L3BA_SBAT_1310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L3BA_SBAT_1310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BA_SBAT_1310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BA_SBAT_1310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Set_Booking_Account_Type",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3BA_SBAT_1310 for attribute P_L3BA_SBAT_1310
		[DataContract]
		public class P_L3BA_SBAT_1310 
		{
			//Standard type parameters
			[DataMember]
			public Guid FiscalYearID { get; set; } 
			[DataMember]
			public Guid BookingAccountID { get; set; } 
			[DataMember]
			public Guid BankAccountID { get; set; } 
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 
			[DataMember]
			public Boolean IsRevenueAccount { get; set; } 
			[DataMember]
			public Boolean IsVATAccount { get; set; } 
			[DataMember]
			public Boolean IsCustomerAccount { get; set; } 
			[DataMember]
			public Boolean IsBankAccount { get; set; } 
			[DataMember]
			public Double TaxRate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Set_Booking_Account_Type(,P_L3BA_SBAT_1310 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Set_Booking_Account_Type.Invoke(connectionString,P_L3BA_SBAT_1310 Parameter,securityTicket);
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
var parameter = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_SBAT_1310();
parameter.FiscalYearID = ...;
parameter.BookingAccountID = ...;
parameter.BankAccountID = ...;
parameter.BusinessParticipantID = ...;
parameter.IsRevenueAccount = ...;
parameter.IsVATAccount = ...;
parameter.IsCustomerAccount = ...;
parameter.IsBankAccount = ...;
parameter.TaxRate = ...;

*/
