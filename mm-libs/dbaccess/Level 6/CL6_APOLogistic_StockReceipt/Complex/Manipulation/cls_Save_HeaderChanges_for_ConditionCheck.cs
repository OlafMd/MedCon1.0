/* 
 * Generated on 5/8/2014 1:38:13 PM
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
using CL1_ORD_PRC;
using CL2_DiscountType.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL6_APOLogistic_StockReceipt.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_HeaderChanges_for_ConditionCheck.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_HeaderChanges_for_ConditionCheck
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6SO_SHCfCC_1640 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header receiptHeader = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header();
            receiptHeader.Load(Connection, Transaction, Parameter.ReceiptHeaderID);

            var expectedDeliveryHeader = CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header.Query.Search(Connection, Transaction,
             new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header.Query()
             {
                 ORD_PRC_ExpectedDelivery_HeaderID = receiptHeader.ExpectedDeliveryHeader_RefID,
                 Tenant_RefID = securityTicket.TenantID,
                 IsDeleted = false
             }).Single();

            expectedDeliveryHeader.ExpectedDeliveryDate = Parameter.DeliveryDate;
            expectedDeliveryHeader.ExpectedDeliveryNumber = Parameter.DeliveryNumber;
            expectedDeliveryHeader.Save(Connection, Transaction);

            //create bill header
            P_L2BH_SOPSSBH_1515 saveBillHeaderParam = new P_L2BH_SOPSSBH_1515();
            saveBillHeaderParam.CashDiscountInPercent = Parameter.CashDiscountInPercent;                   
            saveBillHeaderParam.PaymentTargetDate = Parameter.PaymentTargetTime;

            Guid savedBillHeader = cls_Save_ORD_PRC_SPB_SupplierBill_Header.Invoke(Connection, Transaction, saveBillHeaderParam, securityTicket).Result;

            //create assignment to receipt header
            ORM_ORD_PRC_SPB_SupplierBill_2_ReceiptHeader receiptToSupplierBillHeader = new ORM_ORD_PRC_SPB_SupplierBill_2_ReceiptHeader();

            receiptToSupplierBillHeader.LOG_RCP_Receipt_Header_RefID = Parameter.ReceiptHeaderID;
            receiptToSupplierBillHeader.ORD_PRC_SPB_SupplierBill_Header_RefID = savedBillHeader;
            receiptToSupplierBillHeader.Tenant_RefID = securityTicket.TenantID;
            receiptToSupplierBillHeader.Save(Connection, Transaction);

            //set IsPriceConditionsManuallyCleared to true 
            receiptHeader.IsPriceConditionsManuallyCleared = true;
            receiptHeader.PriceConditionsManuallyCleared_AtDate = DateTime.Now;
            receiptHeader.PriceConditionsManuallyCleared_ByAccount_RefID = securityTicket.AccountID;
            receiptHeader.Save(Connection, Transaction);

            #region save discount amounts

            var receiptPosition = CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position.Query.Search(
                Connection,
                Transaction,
                new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position.Query
                {
                    Receipt_Header_RefID = Parameter.ReceiptHeaderID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

            var cashDiscount = EnumUtils.GetEnumDescription(EDiscountType.CashDiscount);

            foreach (var position in receiptPosition)
            {
                var discountType = new CL1_ORD_PRC.ORM_ORD_PRC_DiscountType
                {
                    ORD_PRC_DiscountTypeID = Guid.NewGuid(),
                    GlobalPropertyMatchingID = cashDiscount.ToString(),
                    Tenant_RefID = securityTicket.TenantID
                };

                discountType.Save(Connection, Transaction);

                var discountAmount = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_DiscountAmount
                {
                    LOG_RCP_Receipt_Position_DiscountAmountID = Guid.NewGuid(),
                    ORD_PRC_DiscountType_RefID = discountType.ORD_PRC_DiscountTypeID,
                    LOG_RCP_Receipt_Position_RefID = position.LOG_RCP_Receipt_PositionID,
                    PositionDiscountValue = Parameter.CashDiscountInPercent,
                    Tenant_RefID = securityTicket.TenantID
                };

                discountAmount.Save(Connection, Transaction);
            }

            #endregion

            //just returning input header ID
            returnValue.Result = Parameter.ReceiptHeaderID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6SO_SHCfCC_1640 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6SO_SHCfCC_1640 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SO_SHCfCC_1640 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SO_SHCfCC_1640 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_HeaderChanges_for_ConditionCheck",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6SO_SHCfCC_1640 for attribute P_L6SO_SHCfCC_1640
		[DataContract]
		public class P_L6SO_SHCfCC_1640 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 
			[DataMember]
			public DateTime DeliveryDate { get; set; } 
			[DataMember]
			public String DeliveryNumber { get; set; } 
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
FR_Guid cls_Save_HeaderChanges_for_ConditionCheck(,P_L6SO_SHCfCC_1640 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_HeaderChanges_for_ConditionCheck.Invoke(connectionString,P_L6SO_SHCfCC_1640 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_StockReceipt.Complex.Manipulation.P_L6SO_SHCfCC_1640();
parameter.ReceiptHeaderID = ...;
parameter.DeliveryDate = ...;
parameter.DeliveryNumber = ...;
parameter.PaymentTargetTime = ...;
parameter.CashDiscountInPercent = ...;

*/
