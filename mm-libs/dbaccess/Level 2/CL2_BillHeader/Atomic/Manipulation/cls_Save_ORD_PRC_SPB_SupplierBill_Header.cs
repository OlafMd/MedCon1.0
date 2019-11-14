/* 
 * Generated on 2/27/2014 5:08:49 PM
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
using CL1_ORD_PRC_SPB;

namespace CL2_BillHeader.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ORD_PRC_SPB_SupplierBill_Header.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ORD_PRC_SPB_SupplierBill_Header
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2BH_SOPSSBH_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new ORM_ORD_PRC_SPB_SupplierBill_Header();
			if (Parameter.ORD_PRC_SPB_SupplierBill_HeaderID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.ORD_PRC_SPB_SupplierBill_HeaderID);
			    if (result.Status != FR_Status.Success || item.ORD_PRC_SPB_SupplierBill_HeaderID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.ORD_PRC_SPB_SupplierBill_HeaderID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.ORD_PRC_SPB_SupplierBill_HeaderID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.Supplier_RefID = Parameter.Supplier_RefID;
			item.Currency_RefID = Parameter.Currency_RefID;
			item.SupplierBillNumber = Parameter.SupplierBillNumber;
			item.DateOnBill = Parameter.DateOnBill;
			item.TotalValue_BeforeTax = Parameter.TotalValue_BeforeTax;
			item.TotalValue_IncludingTax = Parameter.TotalValue_IncludingTax;
			item.BillComment = Parameter.BillComment;
			item.PaymentTargetDate = Parameter.PaymentTargetDate;
			item.CashDiscountInPercent = Parameter.CashDiscountInPercent;


			return new FR_Guid(item.Save(Connection, Transaction),item.ORD_PRC_SPB_SupplierBill_HeaderID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2BH_SOPSSBH_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2BH_SOPSSBH_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2BH_SOPSSBH_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2BH_SOPSSBH_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ORD_PRC_SPB_SupplierBill_Header",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2BH_SOPSSBH_1515 for attribute P_L2BH_SOPSSBH_1515
		[DataContract]
		public class P_L2BH_SOPSSBH_1515 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_SPB_SupplierBill_HeaderID { get; set; } 
			[DataMember]
			public Guid Supplier_RefID { get; set; } 
			[DataMember]
			public Guid Currency_RefID { get; set; } 
			[DataMember]
			public String SupplierBillNumber { get; set; } 
			[DataMember]
			public DateTime DateOnBill { get; set; } 
			[DataMember]
			public Decimal TotalValue_BeforeTax { get; set; } 
			[DataMember]
			public Decimal TotalValue_IncludingTax { get; set; } 
			[DataMember]
			public String BillComment { get; set; } 
			[DataMember]
			public DateTime PaymentTargetDate { get; set; } 
			[DataMember]
			public Double CashDiscountInPercent { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ORD_PRC_SPB_SupplierBill_Header(,P_L2BH_SOPSSBH_1515 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ORD_PRC_SPB_SupplierBill_Header.Invoke(connectionString,P_L2BH_SOPSSBH_1515 Parameter,securityTicket);
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
var parameter = new CL2_BillHeader.Atomic.Manipulation.P_L2BH_SOPSSBH_1515();
parameter.ORD_PRC_SPB_SupplierBill_HeaderID = ...;
parameter.Supplier_RefID = ...;
parameter.Currency_RefID = ...;
parameter.SupplierBillNumber = ...;
parameter.DateOnBill = ...;
parameter.TotalValue_BeforeTax = ...;
parameter.TotalValue_IncludingTax = ...;
parameter.BillComment = ...;
parameter.PaymentTargetDate = ...;
parameter.CashDiscountInPercent = ...;
parameter.IsDeleted = ...;

*/
