/* 
 * Generated on 5/8/2014 3:20:10 PM
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

namespace CL5_APOLogistic_SupplierBill.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_SupplierBill_for_ReceiptHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_SupplierBill_for_ReceiptHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SB_GSBfRH_1433 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SB_GSBfRH_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5SB_GSBfRH_1433();
			//Put your code here

            //get assignment
            var receiptToBillAssignment = ORM_ORD_PRC_SPB_SupplierBill_2_ReceiptHeader.Query.Search(Connection, Transaction,
             new ORM_ORD_PRC_SPB_SupplierBill_2_ReceiptHeader.Query()
             {
                 LOG_RCP_Receipt_Header_RefID = Parameter.LOG_RCP_Receipt_HeaderID,
                 Tenant_RefID = securityTicket.TenantID,
                 IsDeleted = false
             }).Single();

            ORM_ORD_PRC_SPB_SupplierBill_Header billHeader = new ORM_ORD_PRC_SPB_SupplierBill_Header();
            billHeader.Load(Connection, Transaction, receiptToBillAssignment.ORD_PRC_SPB_SupplierBill_Header_RefID);

            returnValue.Result = new L5SB_GSBfRH_1433();
            returnValue.Result.CashDiscountInPercent = billHeader.CashDiscountInPercent;
            returnValue.Result.PaymentTargetTime = billHeader.PaymentTargetDate;
            returnValue.Result.DateOnBill = billHeader.DateOnBill;
            returnValue.Result.SupplierBillNumber = billHeader.SupplierBillNumber;            

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SB_GSBfRH_1433 Invoke(string ConnectionString,P_L5SB_GSBfRH_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SB_GSBfRH_1433 Invoke(DbConnection Connection,P_L5SB_GSBfRH_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SB_GSBfRH_1433 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SB_GSBfRH_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SB_GSBfRH_1433 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SB_GSBfRH_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SB_GSBfRH_1433 functionReturn = new FR_L5SB_GSBfRH_1433();
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

				throw new Exception("Exception occured in method cls_Get_SupplierBill_for_ReceiptHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SB_GSBfRH_1433 : FR_Base
	{
		public L5SB_GSBfRH_1433 Result	{ get; set; }

		public FR_L5SB_GSBfRH_1433() : base() {}

		public FR_L5SB_GSBfRH_1433(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SB_GSBfRH_1433 for attribute P_L5SB_GSBfRH_1433
		[DataContract]
		public class P_L5SB_GSBfRH_1433 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_HeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SB_GSBfRH_1433 for attribute L5SB_GSBfRH_1433
		[DataContract]
		public class L5SB_GSBfRH_1433 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_SPB_SupplierBill_HeaderID { get; set; } 
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
FR_L5SB_GSBfRH_1433 cls_Get_SupplierBill_for_ReceiptHeader(,P_L5SB_GSBfRH_1433 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SB_GSBfRH_1433 invocationResult = cls_Get_SupplierBill_for_ReceiptHeader.Invoke(connectionString,P_L5SB_GSBfRH_1433 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_SupplierBill.Complex.Retrieval.P_L5SB_GSBfRH_1433();
parameter.LOG_RCP_Receipt_HeaderID = ...;

*/
