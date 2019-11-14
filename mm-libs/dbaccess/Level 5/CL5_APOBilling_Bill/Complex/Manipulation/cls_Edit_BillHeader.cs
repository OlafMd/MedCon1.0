/* 
 * Generated on 5/7/2014 10:53:35 AM
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
using CL3_CustomerAdresses.Complex.Retrieval;

namespace CL5_APOBilling_Bill.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Edit_BillHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Edit_BillHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_EBH_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			
            #region Preloading data

            var BillParam = Parameter.Bill_Parameter.BillHeaderData;

            var billHeader = CL1_BIL.ORM_BIL_BillHeader.Query.Search(Connection, Transaction,
                new CL1_BIL.ORM_BIL_BillHeader.Query()
                {
                    BIL_BillHeaderID = BillParam.BIL_BillHeaderID
                }).SingleOrDefault();

            var ucd = CL1_CMN.ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction,
                new CL1_CMN.ORM_CMN_UniversalContactDetail.Query()
                {
                    CMN_UniversalContactDetailID = BillParam.CMN_UniversalContactDetailID
                }).SingleOrDefault();

            var account = new CL1_USR.ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);
            var customer = CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction,
                new CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_Customer.Query()
                {
                    CMN_BPT_CTM_CustomerID = BillParam.BillingReceiverCustomer.CMN_BPT_CTM_CustomerID
                }).SingleOrDefault();

            #endregion

            if (BillParam.BillingAddressID != Guid.Empty)
            {
                List<L3ACAAD_GCAfT_1612> customerAddresses = cls_Get_CustomerAddresses_for_CustomerID.Invoke(Connection, Transaction, new P_L3ACAAD_GCAfCID_1612 { CustomerID = BillParam.BillingReceiverCustomer.CMN_BPT_CTM_CustomerID }, securityTicket).Result.ToList();
                L3ACAAD_GCAfT_1612 customerAddress = customerAddresses.Where(x => x.AddressID == BillParam.BillingAddressID).SingleOrDefault();
                ucd.CMN_UniversalContactDetailID = BillParam.CMN_UniversalContactDetailID;
                ucd.Country_639_1_ISOCode = customerAddress.Country_639_1_ISOCode;
                ucd.Country_Name = customerAddress.Country_Name;
                ucd.Street_Name = customerAddress.Street_Name;
                ucd.Street_Number = customerAddress.Street_Number;
                ucd.Town = customerAddress.Town;
                ucd.ZIP = customerAddress.ZIP;
                ucd.Tenant_RefID = account.Tenant_RefID;
                ucd.CompanyName_Line1 = BillParam.BillingReceiverCustomer.DisplayName;
                ucd.First_Name = BillParam.BillingReceiverCustomer.FirstName;
                ucd.Last_Name = BillParam.BillingReceiverCustomer.LastName;
                ucd.IsCompany = BillParam.BillingReceiverCustomer.IsCompany;
                ucd.Save(Connection, Transaction);
            }
            billHeader.CreatedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
            billHeader.BillRecipient_BuisnessParticipant_RefID = customer.Ext_BusinessParticipant_RefID;
            billHeader.Tenant_RefID = account.Tenant_RefID;
            billHeader.BillingAddress_UCD_RefID = ucd.CMN_UniversalContactDetailID;
            billHeader.DateOnBill = BillParam.BillingDate;
            billHeader.BillComment = BillParam.Comment;
            billHeader.BillHeader_PaymentCondition_RefID = Parameter.Bill_Parameter.BillHeaderData.PaymentTargetID;
            billHeader.Save(Connection, Transaction);

            #region Method of Payment

            var methodOfPayment = CL1_BIL.ORM_BIL_BillHeader_MethodOfPayment.Query.Search(Connection, Transaction, 
                new CL1_BIL.ORM_BIL_BillHeader_MethodOfPayment.Query
                {
                    BIL_BillHeader_RefID = billHeader.BIL_BillHeaderID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).SingleOrDefault();

            if (methodOfPayment == null)
            {
                methodOfPayment = new CL1_BIL.ORM_BIL_BillHeader_MethodOfPayment
                {
                    BIL_BillHeader_MethodOfPaymentID = Guid.NewGuid(),
                    ACC_PAY_Type_RefID = Parameter.Bill_Parameter.BillHeaderData.PaymentTypeID,
                    BIL_BillHeader_RefID = billHeader.BIL_BillHeaderID,
                    IsPreferredMethodOfPayment = true,
                    SequenceNumber = 0,
                    Tenant_RefID = securityTicket.TenantID
                };
            }

            methodOfPayment.ACC_PAY_Type_RefID = Parameter.Bill_Parameter.BillHeaderData.PaymentTypeID;
            methodOfPayment.Save(Connection, Transaction);

            #endregion

            returnValue.Result = billHeader.BIL_BillHeaderID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CO_EBH_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CO_EBH_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_EBH_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_EBH_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Edit_BillHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CO_EBH_1108 for attribute P_L5CO_EBH_1108
		[DataContract]
		public class P_L5CO_EBH_1108 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOBilling_Bill.Complex.Manipulation.P_L5BL_SB_1645 Bill_Parameter { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Edit_BillHeader(,P_L5CO_EBH_1108 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Edit_BillHeader.Invoke(connectionString,P_L5CO_EBH_1108 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Complex.Manipulation.P_L5CO_EBH_1108();
BillParam.Bill_Parameter = ...;

*/
