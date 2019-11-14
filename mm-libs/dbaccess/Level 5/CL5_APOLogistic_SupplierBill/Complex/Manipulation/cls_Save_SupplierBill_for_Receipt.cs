/* 
 * Generated on 2/27/2014 5:07:37 PM
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL2_BillHeader.Atomic.Manipulation;
using CL1_ORD_PRC_SPB;
using CL1_LOG_RCP;

namespace CL5_APOLogistic_SupplierBill.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_SupplierBill_for_Receipt.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_SupplierBill_for_Receipt
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SB_SSBfR_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            ORM_ORD_PRC_SPB_SupplierBill_2_ReceiptHeader receiptToSupplierBillHeader = new ORM_ORD_PRC_SPB_SupplierBill_2_ReceiptHeader();
            
            ORM_LOG_RCP_Receipt_Header.Query receiptHeaderQuery = new ORM_LOG_RCP_Receipt_Header.Query();
            receiptHeaderQuery.LOG_RCP_Receipt_HeaderID = Parameter.LOG_RCP_Receipt_HeaderID;
            receiptHeaderQuery.Tenant_RefID = securityTicket.TenantID;
            var foundReceiptHeaderEntity = ORM_LOG_RCP_Receipt_Header.Query.Search(Connection, Transaction, receiptHeaderQuery);

            //update receipt header status 
            if (foundReceiptHeaderEntity == null)
            {
                return new FR_Guid("Not found", FR_Status.Error_Internal);
            }
            else
            {
                ORM_LOG_RCP_Receipt_Header foundReceiptHeader = foundReceiptHeaderEntity.Single();
                foundReceiptHeader.IsReceiptForwardedToBookkeeping = true;
                foundReceiptHeader.ReceiptForwardedToBookkeeping_AtDate = DateTime.Now;
                foundReceiptHeader.ReceiptForwardedToBookkeeping_ByAccount_RefID = securityTicket.AccountID;
                foundReceiptHeader.Save(Connection, Transaction);
            }

            var receiptToBillAssignment = ORM_ORD_PRC_SPB_SupplierBill_2_ReceiptHeader.Query.Search(Connection, Transaction,
             new ORM_ORD_PRC_SPB_SupplierBill_2_ReceiptHeader.Query()
             {
                 LOG_RCP_Receipt_Header_RefID = Parameter.LOG_RCP_Receipt_HeaderID,
                 Tenant_RefID = securityTicket.TenantID,
                 IsDeleted = false
             }).SingleOrDefault();

            //update bill header
            if (receiptToBillAssignment != null)
            {
                ORM_ORD_PRC_SPB_SupplierBill_Header billHeader = new ORM_ORD_PRC_SPB_SupplierBill_Header();
                billHeader.Load(Connection, Transaction, receiptToBillAssignment.ORD_PRC_SPB_SupplierBill_Header_RefID);
                billHeader.CashDiscountInPercent = Parameter.CashDiscountInPercent;
                billHeader.DateOnBill = Parameter.DateOnBill;
                billHeader.SupplierBillNumber = Parameter.SupplierBillNumber;
                billHeader.PaymentTargetDate = Parameter.PaymentTargetTime;
                billHeader.Save(Connection, Transaction);
            }
            else
            {

                P_L2BH_SOPSSBH_1515 saveBillHeaderParam = new P_L2BH_SOPSSBH_1515();

                saveBillHeaderParam.CashDiscountInPercent = Parameter.CashDiscountInPercent;
                saveBillHeaderParam.DateOnBill = Parameter.DateOnBill;
                saveBillHeaderParam.SupplierBillNumber = Parameter.SupplierBillNumber;
                saveBillHeaderParam.PaymentTargetDate = Parameter.PaymentTargetTime;

                Guid savedBillHeader = cls_Save_ORD_PRC_SPB_SupplierBill_Header.Invoke(Connection, Transaction, saveBillHeaderParam, securityTicket).Result;

                receiptToBillAssignment = new ORM_ORD_PRC_SPB_SupplierBill_2_ReceiptHeader();
                receiptToBillAssignment.ORD_PRC_SPB_SupplierBill_2_ReceiptHeaderID = Guid.NewGuid();
                receiptToBillAssignment.ORD_PRC_SPB_SupplierBill_Header_RefID = savedBillHeader;
                receiptToBillAssignment.LOG_RCP_Receipt_Header_RefID = Parameter.LOG_RCP_Receipt_HeaderID;
                receiptToBillAssignment.Tenant_RefID = securityTicket.TenantID;
                receiptToBillAssignment.Save(Connection, Transaction);
            }
            

            returnValue.Result = receiptToBillAssignment.ORD_PRC_SPB_SupplierBill_2_ReceiptHeaderID;
            
            return returnValue;
            
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SB_SSBfR_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SB_SSBfR_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SB_SSBfR_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SB_SSBfR_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_SupplierBill_for_Receipt",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SB_SSBfR_1401 for attribute P_L5SB_SSBfR_1401
		[DataContract]
		public class P_L5SB_SSBfR_1401 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_HeaderID { get; set; } 
			[DataMember]
			public String SupplierBillNumber { get; set; } 
			[DataMember]
			public DateTime DateOnBill { get; set; } 
			[DataMember]
			public DateTime PaymentTargetTime { get; set; } 
			[DataMember]
			public Double CashDiscountInPercent { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_SupplierBill_for_Receipt(,P_L5SB_SSBfR_1401 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_SupplierBill_for_Receipt.Invoke(connectionString,P_L5SB_SSBfR_1401 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_SupplierBill.Complex.Manipulation.P_L5SB_SSBfR_1401();
parameter.LOG_RCP_Receipt_HeaderID = ...;
parameter.SupplierBillNumber = ...;
parameter.DateOnBill = ...;
parameter.PaymentTargetTime = ...;
parameter.CashDiscountInPercent = ...;

*/
