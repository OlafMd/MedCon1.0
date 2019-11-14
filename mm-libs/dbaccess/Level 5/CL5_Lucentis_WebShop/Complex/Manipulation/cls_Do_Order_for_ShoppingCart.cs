/* 
 * Generated on 12/30/2013 8:16:54 PM
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

namespace CL5_Lucentis_WebShop.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Do_Order_for_ShoppingCart.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Do_Order_for_ShoppingCart
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5WS_DOfSC_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            #region Shopping cart
            // Get shopping cart
            var shoppingCart = new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart();
            shoppingCart.Load(Connection, Transaction, Parameter.ORD_PRC_ShoppingCartID);

            // Get shopping cart status
            var statusOrdered = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query()
                {
                    GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EShoppingCartStatus.Ordered),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

            // Create and save new shopping cart history
            var shoppingHistory = new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCartStatus_History();
            shoppingHistory.ORD_PRC_ShoppingCart_RefID = shoppingCart.ORD_PRC_ShoppingCartID;
            shoppingHistory.ORD_PRC_ShoppingCart_Status_RefID = statusOrdered.ORD_PRC_ShoppingCart_StatusID;
            shoppingHistory.PerformedBy_Account_RefID = securityTicket.AccountID;
            shoppingHistory.Tenant_RefID = securityTicket.TenantID;
            shoppingHistory.Save(Connection, Transaction);

            var shoppingProducts = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Product.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Product.Query
                {
                    ORD_PRC_ShoppingCart_RefID = Parameter.ORD_PRC_ShoppingCartID,
                    IsDeleted = false
                });

            // Save shopping cart
            shoppingCart.IsProcurementOrderCreated = true;
            shoppingCart.ShoppingCart_CurrentStatus_RefID = statusOrdered.ORD_PRC_ShoppingCart_StatusID;

            #endregion

            #region Procurement Order
            // Get procurement order status
            var procurementOrderStatus = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Status.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Status.Query()
                {
                    GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EProcurementStatus.Active),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

            var account = new CL1_USR.ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);

            // Find last added procurement order header
            var lastProcurementOrderHeader = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Header.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Header.Query
                {
                    Tenant_RefID = securityTicket.TenantID
                }).OrderByDescending(x => Convert.ToInt64(x.ProcurementOrder_Number)).FirstOrDefault();

            // Find last procurement order number
            long procurementOrderNumber = 0;
            if (lastProcurementOrderHeader != null)
            {
                procurementOrderNumber = Convert.ToInt64(lastProcurementOrderHeader.ProcurementOrder_Number);
            }

            // Create procurement order header
            var procurementOrderHeader = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Header();
            procurementOrderHeader.Tenant_RefID = securityTicket.TenantID;
            procurementOrderHeader.CreatedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
            procurementOrderHeader.Current_ProcurementOrderStatus_RefID = procurementOrderStatus.ORD_PRC_ProcurementOrder_StatusID;
            procurementOrderHeader.ProcurementOrder_Supplier_RefID = Guid.Empty;
            procurementOrderHeader.ProcurementOrder_Date = DateTime.Now;
            //procurementOrderHeader.TotalValue_BeforeTax = 0;
            procurementOrderHeader.ProcurementOrder_Number = (++procurementOrderNumber).ToString();
            procurementOrderHeader.Save(Connection, Transaction);

            // Create procurement order status history
            var procurementOrderStatusHistory = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_StatusHistory();
            procurementOrderStatusHistory.Tenant_RefID = securityTicket.TenantID;
            procurementOrderStatusHistory.ProcurementOrder_Header_RefID = procurementOrderHeader.ORD_PRC_ProcurementOrder_HeaderID;
            procurementOrderStatusHistory.ProcurementOrder_Status_RefID = procurementOrderStatus.ORD_PRC_ProcurementOrder_StatusID;
            procurementOrderStatusHistory.Save(Connection, Transaction);

            returnValue = new FR_Guid(shoppingCart.Save(Connection, Transaction), procurementOrderHeader.ORD_PRC_ProcurementOrder_HeaderID);

            #endregion

            #region Procurement Order Shopping Products
            // Create and save procurement order for shopping products
            foreach (var shoppingProduct in shoppingProducts)
            {
                var procurementOrderPosition = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position();
                procurementOrderPosition.Tenant_RefID = securityTicket.TenantID;
                procurementOrderPosition.ProcurementOrder_Header_RefID = procurementOrderHeader.ORD_PRC_ProcurementOrder_HeaderID;
                procurementOrderPosition.Position_Quantity = shoppingProduct.Quantity;
                procurementOrderPosition.CMN_PRO_Product_RefID = shoppingProduct.CMN_PRO_Product_RefID;
                procurementOrderPosition.CMN_PRO_Product_Release_RefID = shoppingProduct.CMN_PRO_Product_Release_RefID;
                procurementOrderPosition.CMN_PRO_Product_Variant_RefID = shoppingProduct.CMN_PRO_Product_Variant_RefID;
                procurementOrderPosition.Save(Connection, Transaction);

                var shoppingCart2ProcurementOrder = new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_2_ProcurementOrderPosition();
                shoppingCart2ProcurementOrder.Tenant_RefID = securityTicket.TenantID;
                shoppingCart2ProcurementOrder.ORD_PRC_ShoppingCart_Product_RefID = shoppingProduct.ORD_PRC_ShoppingCart_ProductID;
                shoppingCart2ProcurementOrder.ORD_PRC_ProcurementOrder_Position_RefID = procurementOrderPosition.ORD_PRC_ProcurementOrder_PositionID;
                shoppingCart2ProcurementOrder.Save(Connection, Transaction);
            }
            #endregion

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5WS_DOfSC_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5WS_DOfSC_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WS_DOfSC_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WS_DOfSC_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Do_Order_for_ShoppingCart",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5WS_DOfSC_1525 for attribute P_L5WS_DOfSC_1525
		[DataContract]
		public class P_L5WS_DOfSC_1525 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ShoppingCartID { get; set; } 
			[DataMember]
			public Guid CurrentPractice_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Do_Order_for_ShoppingCart(,P_L5WS_DOfSC_1525 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Do_Order_for_ShoppingCart.Invoke(connectionString,P_L5WS_DOfSC_1525 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_WebShop.Complex.Manipulation.P_L5WS_DOfSC_1525();
parameter.ORD_PRC_ShoppingCartID = ...;
parameter.CurrentPractice_BusinessParticipantID = ...;
parameter.LanguageID = ...;

*/
