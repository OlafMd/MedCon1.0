/* 
 * Generated on 5/7/2014 10:55:25 AM
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
using CL1_BIL;
using CL1_USR;
using CL3_CustomerAdresses.Complex.Retrieval;
using CL1_CMN;
using CL1_CMN_BPT_CTM;
using CL2_Currency.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL2_NumberRange.Complex.Retrieval;

namespace CL5_APOBilling_Bill.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_CreateBillHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_CreateBillHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_CBH_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            ORM_BIL_BillHeader billHeader = null;
            ORM_BIL_BillHeader_2_BillStatus billHeader2BillStatus = null;
            ORM_CMN_UniversalContactDetail universalContactDetail = null;
            
            var BillParam = Parameter.Bill_Parameter.BillHeaderData;

            #region Preloading data

            ORM_USR_Account account = new ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);
            var customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction,
                new ORM_CMN_BPT_CTM_Customer.Query()
                {
                    CMN_BPT_CTM_CustomerID = BillParam.BillingReceiverCustomer.CMN_BPT_CTM_CustomerID
                }).SingleOrDefault();

            List<L3ACAAD_GCAfT_1612> customerAddresses = cls_Get_CustomerAddresses_for_CustomerID.Invoke(Connection, Transaction, new P_L3ACAAD_GCAfCID_1612 { CustomerID = BillParam.BillingReceiverCustomer.CMN_BPT_CTM_CustomerID }, securityTicket).Result.ToList();
            L3ACAAD_GCAfT_1612 customerAddress = customerAddresses.Where(x => x.AddressID == BillParam.BillingAddressID).SingleOrDefault();

            var incrNumberParam = new P_L2NR_GaIINfUA_1454()
            {
                GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.BillNumber)
            };
            var billNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

            #endregion

            #region Universal Contact Detail

            universalContactDetail = new ORM_CMN_UniversalContactDetail()
            {
                CMN_UniversalContactDetailID = Guid.NewGuid(),
                Country_639_1_ISOCode = customerAddress.Country_639_1_ISOCode,
                Country_Name = customerAddress.Country_Name,
                Street_Name = customerAddress.Street_Name,
                Street_Number = customerAddress.Street_Number,
                Town = customerAddress.Town,
                ZIP = customerAddress.ZIP,
                Tenant_RefID = account.Tenant_RefID,
                CompanyName_Line1 = BillParam.BillingReceiverCustomer.DisplayName,
                First_Name = BillParam.BillingReceiverCustomer.FirstName,
                Last_Name = BillParam.BillingReceiverCustomer.LastName,
                IsCompany = BillParam.BillingReceiverCustomer.IsCompany
            };
            universalContactDetail.Save(Connection, Transaction);
            #endregion

            #region Bill Header

            billHeader = new ORM_BIL_BillHeader
            {
                BIL_BillHeaderID = Guid.NewGuid(),
                BillNumber = billNumber,
                CreatedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID,
                BillRecipient_BuisnessParticipant_RefID = customer.Ext_BusinessParticipant_RefID,
                TotalValue_BeforeTax = 0,
                TotalValue_IncludingTax = 0,
                BillingAddress_UCD_RefID = universalContactDetail.CMN_UniversalContactDetailID,
                DateOnBill = BillParam.BillingDate,
                BillComment = BillParam.Comment,
                Currency_RefID = cls_Get_DefaultCurrency_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.CMN_CurrencyID,
                BillHeader_PaymentCondition_RefID = Parameter.Bill_Parameter.BillHeaderData.PaymentTargetID,
                Tenant_RefID = securityTicket.TenantID
            };

            billHeader.Save(Connection, Transaction);

            #endregion

            #region Method of Payment

            var methodOfPayment = new CL1_BIL.ORM_BIL_BillHeader_MethodOfPayment
            {
                BIL_BillHeader_MethodOfPaymentID = Guid.NewGuid(),
                ACC_PAY_Type_RefID = Parameter.Bill_Parameter.BillHeaderData.PaymentTypeID,
                BIL_BillHeader_RefID = billHeader.BIL_BillHeaderID,
                IsPreferredMethodOfPayment = true,
                SequenceNumber = 0,
                Tenant_RefID = securityTicket.TenantID
            };
            methodOfPayment.Save(Connection, Transaction);

            #endregion

            #region Bill Status - Created

            var statusCreated = ORM_BIL_BillStatus.Query.Search(Connection, Transaction,
             new ORM_BIL_BillStatus.Query()
             {
                 GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EBillStatus.Created),
                 Tenant_RefID = account.Tenant_RefID,
                 IsDeleted = false
             }).Single();

            billHeader2BillStatus = new ORM_BIL_BillHeader_2_BillStatus
            {
                AssignmentID = Guid.NewGuid(),
                BIL_BillHeader_RefID = billHeader.BIL_BillHeaderID,
                BIL_BillStatus_RefID = statusCreated.BIL_BillStatusID,
                Tenant_RefID = account.Tenant_RefID,
                IsCurrentStatus = true
            };
            billHeader2BillStatus.Save(Connection, Transaction);

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
		public static FR_Guid Invoke(string ConnectionString,P_L5CO_CBH_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CO_CBH_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_CBH_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_CBH_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_CreateBillHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CO_CBH_1606 for attribute P_L5CO_CBH_1606
		[DataContract]
		public class P_L5CO_CBH_1606 
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
FR_Guid cls_CreateBillHeader(,P_L5CO_CBH_1606 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_CreateBillHeader.Invoke(connectionString,P_L5CO_CBH_1606 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Complex.Manipulation.P_L5CO_CBH_1606();
BillParam.Bill_Parameter = ...;

*/
