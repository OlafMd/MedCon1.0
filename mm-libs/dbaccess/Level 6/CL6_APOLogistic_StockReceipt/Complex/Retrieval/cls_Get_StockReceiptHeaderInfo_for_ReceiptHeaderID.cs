/* 
 * Generated on 5/23/2014 3:14:37 PM
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
using CL5_APOLogistic_StockReceipt.Atomic.Retrieval;
using CL3_Account.Atomic.Retrieval;
using CL1_CMN_BPT;
using CL5_APOLogistic_Supplier.Atomic.Retrieval;
using CL1_ORD_PRC_SPB;

namespace CL6_APOLogistic_StockReceipt.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StockReceiptHeaderInfo_for_ReceiptHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StockReceiptHeaderInfo_for_ReceiptHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SR_GSRHIfRH_1646 Execute(DbConnection Connection,DbTransaction Transaction,P_L6SR_GSRHIfRH_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6SR_GSRHIfRH_1646();
			    
            P_L5SR_GRaPHfRH_1636 param = new P_L5SR_GRaPHfRH_1636();
            param.ReceiptHeaderID = Parameter.ReceiptHeaderID;

            var receceiptHeader = cls_Get_ReceiptHeader_and_ProcurmentHeader_for_ReceiptHeaderID.Invoke(Connection, Transaction, param, securityTicket).Result;

            if(receceiptHeader == null)
                return returnValue;

            var accountsParam = new List<Guid>();

            if (receceiptHeader.IsQualityControlPerformed)
                accountsParam.Add(receceiptHeader.QualityControlPerformed_ByAccount_RefID);
            if (receceiptHeader.IsTakenIntoStock)
                accountsParam.Add(receceiptHeader.TakenIntoStock_ByAccount_RefID);
            if (receceiptHeader.IsPriceConditionsManuallyCleared)
                accountsParam.Add(receceiptHeader.PriceConditionsManuallyCleared_ByAccount_RefID);
            if (receceiptHeader.IsReceiptForwardedToBookkeeping)
                accountsParam.Add(receceiptHeader.ReceiptForwardedToBookkeeping_ByAccount_RefID);

            var accounts = new List<CL2_AC_GADNoAfT_1621>();

            if (accountsParam.Count() != 0) {
                accounts = cls_Get_AllDisplayNames_of_Accounts_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            }

            #region Supplier Info

            var supplierInfo = new L5ALSU_GSfToS_1546();
            if(receceiptHeader.ProvidingSupplier_RefID != Guid.Empty){
                P_L5ALSU_GSfToS_1546 supplierParam = new P_L5ALSU_GSfToS_1546();
                supplierParam.CMN_BPT_SupplierID = receceiptHeader.ProvidingSupplier_RefID;

                supplierInfo = cls_Get_Suppliers_for_TenantID_or_SupplierID.Invoke(Connection, Transaction, supplierParam, securityTicket).Result.SingleOrDefault();
            }

            #endregion

            #region BillInfo

            ORM_ORD_PRC_SPB_SupplierBill_Header billHeader = new ORM_ORD_PRC_SPB_SupplierBill_Header();

            if(receceiptHeader.IsReceiptForwardedToBookkeeping){

                var receiptToSupplierBillHeader = ORM_ORD_PRC_SPB_SupplierBill_2_ReceiptHeader.Query.Search(Connection, Transaction, 
                    new ORM_ORD_PRC_SPB_SupplierBill_2_ReceiptHeader.Query(){
                        LOG_RCP_Receipt_Header_RefID = receceiptHeader.LOG_RCP_Receipt_HeaderID,
                        IsDeleted = false
                    }).SingleOrDefault();
            
                if(receiptToSupplierBillHeader != null){
                
                    billHeader = ORM_ORD_PRC_SPB_SupplierBill_Header.Query.Search(Connection, Transaction, 
                    new ORM_ORD_PRC_SPB_SupplierBill_Header.Query(){
                        ORD_PRC_SPB_SupplierBill_HeaderID = receiptToSupplierBillHeader.ORD_PRC_SPB_SupplierBill_Header_RefID,
                        IsDeleted = false
                    }).SingleOrDefault();
                
                }

            
            }

            #endregion

            returnValue.Result = new L6SR_GSRHIfRH_1646();
            returnValue.Result.LOG_RCP_Receipt_HeaderID = receceiptHeader.LOG_RCP_Receipt_HeaderID;

            returnValue.Result.ProcurementOrder_Number = receceiptHeader.ProcurementOrder_Number;
            returnValue.Result.ReceiptNumber = receceiptHeader.ReceiptNumber;

            returnValue.Result.ProvidingSupplier_RefID = receceiptHeader.ProvidingSupplier_RefID;
            returnValue.Result.SupplierName = supplierInfo.CompanyName_Line1;
            returnValue.Result.SupplierType = supplierInfo.SupplierType_Name.CopyContents(ORM_CMN_BPT_Supplier_Type.TableName);

            returnValue.Result.BillNumber = billHeader.SupplierBillNumber ;
            returnValue.Result.BillDate = billHeader.DateOnBill;
            returnValue.Result.PaymentDeadline = billHeader.PaymentTargetDate;

            returnValue.Result.IsQualityControlPerformed = receceiptHeader.IsQualityControlPerformed;
            returnValue.Result.QualityControlPerformed_ByAccount_RefID = receceiptHeader.QualityControlPerformed_ByAccount_RefID;
            returnValue.Result.QualityControlPerformed_By = accounts.Where(i => i.USR_AccountID == receceiptHeader.QualityControlPerformed_ByAccount_RefID).Select(j=>j.DisplayName).SingleOrDefault();
            returnValue.Result.QualityControlPerformed_AtDate = receceiptHeader.QualityControlPerformed_AtDate;

            returnValue.Result.IsTakenIntoStock = receceiptHeader.IsTakenIntoStock;
            returnValue.Result.TakenIntoStock_ByAccount_RefID = receceiptHeader.TakenIntoStock_ByAccount_RefID;
            returnValue.Result.TakenIntoStock_ByAccount_By = accounts.Where(i => i.USR_AccountID == receceiptHeader.TakenIntoStock_ByAccount_RefID).Select(j=>j.DisplayName).SingleOrDefault();
            returnValue.Result.TakenIntoStock_AtDate = receceiptHeader.TakenIntoStock_AtDate;

            returnValue.Result.IsPriceConditionsManuallyCleared = receceiptHeader.IsPriceConditionsManuallyCleared;
            returnValue.Result.PriceConditionsManuallyCleared_ByAccount_RefID = receceiptHeader.PriceConditionsManuallyCleared_ByAccount_RefID;
            returnValue.Result.PriceConditionsManuallyCleared_By = accounts.Where(i => i.USR_AccountID == receceiptHeader.PriceConditionsManuallyCleared_ByAccount_RefID).Select(j=>j.DisplayName).SingleOrDefault();
            returnValue.Result.PriceConditionsManuallyCleared_AtDate = receceiptHeader.PriceConditionsManuallyCleared_AtDate;

            returnValue.Result.IsReceiptForwardedToBookkeeping = receceiptHeader.IsReceiptForwardedToBookkeeping;
            returnValue.Result.ReceiptForwardedToBookkeeping_ByAccount_RefID = receceiptHeader.ReceiptForwardedToBookkeeping_ByAccount_RefID;
            returnValue.Result.ReceiptForwardedToBookkeeping_By = accounts.Where(i => i.USR_AccountID == receceiptHeader.ReceiptForwardedToBookkeeping_ByAccount_RefID).Select(j=>j.DisplayName).SingleOrDefault();
            returnValue.Result.ReceiptForwardedToBookkeeping_AtDate = receceiptHeader.ReceiptForwardedToBookkeeping_AtDate;



			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6SR_GSRHIfRH_1646 Invoke(string ConnectionString,P_L6SR_GSRHIfRH_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SR_GSRHIfRH_1646 Invoke(DbConnection Connection,P_L6SR_GSRHIfRH_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SR_GSRHIfRH_1646 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SR_GSRHIfRH_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SR_GSRHIfRH_1646 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SR_GSRHIfRH_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SR_GSRHIfRH_1646 functionReturn = new FR_L6SR_GSRHIfRH_1646();
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

				throw new Exception("Exception occured in method cls_Get_StockReceiptHeaderInfo_for_ReceiptHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SR_GSRHIfRH_1646 : FR_Base
	{
		public L6SR_GSRHIfRH_1646 Result	{ get; set; }

		public FR_L6SR_GSRHIfRH_1646() : base() {}

		public FR_L6SR_GSRHIfRH_1646(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SR_GSRHIfRH_1646 for attribute P_L6SR_GSRHIfRH_1646
		[DataContract]
		public class P_L6SR_GSRHIfRH_1646 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 

		}
		#endregion
		#region SClass L6SR_GSRHIfRH_1646 for attribute L6SR_GSRHIfRH_1646
		[DataContract]
		public class L6SR_GSRHIfRH_1646 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_HeaderID { get; set; } 
			[DataMember]
			public String ProcurementOrder_Number { get; set; } 
			[DataMember]
			public String ReceiptNumber { get; set; } 
			[DataMember]
			public Guid ProvidingSupplier_RefID { get; set; } 
			[DataMember]
			public String SupplierName { get; set; } 
			[DataMember]
			public Dict SupplierType { get; set; } 
			[DataMember]
			public String TenantID { get; set; } 
			[DataMember]
			public String TenantName { get; set; } 
			[DataMember]
			public String BillNumber { get; set; } 
			[DataMember]
			public DateTime BillDate { get; set; } 
			[DataMember]
			public DateTime PaymentDeadline { get; set; } 
			[DataMember]
			public bool IsQualityControlPerformed { get; set; } 
			[DataMember]
			public Guid QualityControlPerformed_ByAccount_RefID { get; set; } 
			[DataMember]
			public String QualityControlPerformed_By { get; set; } 
			[DataMember]
			public DateTime QualityControlPerformed_AtDate { get; set; } 
			[DataMember]
			public bool IsTakenIntoStock { get; set; } 
			[DataMember]
			public Guid TakenIntoStock_ByAccount_RefID { get; set; } 
			[DataMember]
			public String TakenIntoStock_ByAccount_By { get; set; } 
			[DataMember]
			public DateTime TakenIntoStock_AtDate { get; set; } 
			[DataMember]
			public bool IsPriceConditionsManuallyCleared { get; set; } 
			[DataMember]
			public Guid PriceConditionsManuallyCleared_ByAccount_RefID { get; set; } 
			[DataMember]
			public String PriceConditionsManuallyCleared_By { get; set; } 
			[DataMember]
			public DateTime PriceConditionsManuallyCleared_AtDate { get; set; } 
			[DataMember]
			public bool IsReceiptForwardedToBookkeeping { get; set; } 
			[DataMember]
			public Guid ReceiptForwardedToBookkeeping_ByAccount_RefID { get; set; } 
			[DataMember]
			public String ReceiptForwardedToBookkeeping_By { get; set; } 
			[DataMember]
			public DateTime ReceiptForwardedToBookkeeping_AtDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SR_GSRHIfRH_1646 cls_Get_StockReceiptHeaderInfo_for_ReceiptHeaderID(,P_L6SR_GSRHIfRH_1646 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SR_GSRHIfRH_1646 invocationResult = cls_Get_StockReceiptHeaderInfo_for_ReceiptHeaderID.Invoke(connectionString,P_L6SR_GSRHIfRH_1646 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_StockReceipt.Complex.Retrieval.P_L6SR_GSRHIfRH_1646();
parameter.ReceiptHeaderID = ...;

*/
