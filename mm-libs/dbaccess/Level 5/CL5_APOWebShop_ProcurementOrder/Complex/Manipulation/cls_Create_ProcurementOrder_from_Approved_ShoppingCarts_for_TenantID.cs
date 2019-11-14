/* 
 * Generated on 4/8/2014 10:16:06 AM
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
using CL5_APOWebShop_ShoppingCart.Atomic.Retrieval;
using CL1_ORD_PRC;
using CL2_NumberRange.Complex.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL5_APOWebShop_ShoppingCart.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_ProcurementOrder_from_Approved_ShoppingCarts_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_ProcurementOrder_from_Approved_ShoppingCarts_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            // Get shopping cart status - Ordered
            var statusOrdered = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query()
                {
                    GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EShoppingCartStatus.Ordered),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

            var tenant = securityTicket.TenantID;

            #region Find All Shopping Carts in Approved state for TenantID

            var statusApproved = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query
                {
                    Tenant_RefID = securityTicket.TenantID,
                    GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EShoppingCartStatus.Approved),
                    IsDeleted = false
                }).Single();

            var approvedShoppingCarts = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart.Query
                {
                    ShoppingCart_CurrentStatus_RefID = statusApproved.ORD_PRC_ShoppingCart_StatusID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

            if (approvedShoppingCarts == null || approvedShoppingCarts.Count() == 0)
            {
                returnValue.Result = Guid.Empty;
                return returnValue;
            }
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

            #region

            var incrNumberParam = new P_L2NR_GaIINfUA_1454()
            {
                GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.ProcurementOrderNumber)
            };
            var procurementNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

            #endregion

            // Create procurement order header
            var procurementOrderHeader = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Header();
            procurementOrderHeader.Tenant_RefID = securityTicket.TenantID;
            procurementOrderHeader.CreatedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
            procurementOrderHeader.Current_ProcurementOrderStatus_RefID = procurementOrderStatus.ORD_PRC_ProcurementOrder_StatusID;
            procurementOrderHeader.ProcurementOrder_Supplier_RefID = Guid.Empty;
            procurementOrderHeader.ProcurementOrder_Date = DateTime.Now;
            procurementOrderHeader.TotalValue_BeforeTax = 0;
            procurementOrderHeader.ProcurementOrder_Number = procurementNumber;
            procurementOrderHeader.Save(Connection, Transaction);

            // Create procurement order status history
            var procurementOrderStatusHistory = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_StatusHistory();
            procurementOrderStatusHistory.Tenant_RefID = securityTicket.TenantID;
            procurementOrderStatusHistory.ProcurementOrder_Header_RefID = procurementOrderHeader.ORD_PRC_ProcurementOrder_HeaderID;
            procurementOrderStatusHistory.ProcurementOrder_Status_RefID = procurementOrderStatus.ORD_PRC_ProcurementOrder_StatusID;
            procurementOrderStatusHistory.Save(Connection, Transaction);

            // Set return value
            returnValue.Result = procurementOrderHeader.ORD_PRC_ProcurementOrder_HeaderID;
            #endregion

            foreach (var item in approvedShoppingCarts)
            {
                #region Procurement Order Shopping Products

                var param = new P_L5AWSSC_GSPfSC_1650();
                param.ShoppingCartID = item.ORD_PRC_ShoppingCartID;
                var shoppingProducts =  cls_Get_ShoppingProducts_for_ShoppingCartID.Invoke(Connection, Transaction, param, securityTicket).Result;

                //when office is deleted but there is ordered items for it 
                if (shoppingProducts == null)
                    continue;

                // Create and save procurement order for shopping products
                foreach (var shoppingProduct in shoppingProducts.Products)
                {
                    #region Skip if Product is not good

                    if (shoppingProduct.IsProductCanceled || shoppingProduct.IsProductDeleted)
                    {
                        continue;
                    }

                    #endregion

                    var procurementOrderPosition = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position();
                    procurementOrderPosition.ORD_PRC_ProcurementOrder_PositionID = Guid.NewGuid();
                    procurementOrderPosition.ProcurementOrder_Header_RefID = procurementOrderHeader.ORD_PRC_ProcurementOrder_HeaderID;
                    procurementOrderPosition.Position_Quantity = shoppingProduct.Quantity;
                    procurementOrderPosition.Position_ValuePerUnit = shoppingProduct.Price;
                    procurementOrderPosition.Position_ValueTotal = shoppingProduct.Price * (Decimal)shoppingProduct.Quantity;
                    procurementOrderPosition.Position_Unit_RefID = Guid.Empty;
                    procurementOrderPosition.Position_RequestedDateOfDelivery = new DateTime();
                    procurementOrderPosition.CMN_PRO_Product_RefID = shoppingProduct.CMN_PRO_Product_RefID;
                    procurementOrderPosition.CMN_PRO_Product_Release_RefID = shoppingProduct.CMN_PRO_Product_Release_RefID;
                    procurementOrderPosition.CMN_PRO_Product_Variant_RefID = shoppingProduct.CMN_PRO_Product_Variant_RefID;
                    procurementOrderPosition.Creation_Timestamp = DateTime.Now;
                    procurementOrderPosition.Tenant_RefID = securityTicket.TenantID;
                    procurementOrderPosition.IsProductReplacementAllowed = shoppingProduct.IsProductReplacementAllowed;
                    procurementOrderPosition.Save(Connection, Transaction);

                    var shoppingCart2ProcurementOrder = new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_2_ProcurementOrderPosition();
                    shoppingCart2ProcurementOrder.AssignmentID = Guid.NewGuid();
                    shoppingCart2ProcurementOrder.ORD_PRC_ShoppingCart_Product_RefID = shoppingProduct.ORD_PRC_ShoppingCart_ProductID;
                    shoppingCart2ProcurementOrder.ORD_PRC_ProcurementOrder_Position_RefID = procurementOrderPosition.ORD_PRC_ProcurementOrder_PositionID;
                    shoppingCart2ProcurementOrder.Tenant_RefID = securityTicket.TenantID;
                    shoppingCart2ProcurementOrder.Save(Connection, Transaction);

                    procurementOrderHeader.TotalValue_BeforeTax += procurementOrderPosition.Position_ValueTotal;
                }
                #endregion

                #region ShoppingCartNotes

                var notesParam = new P_L5AWSAR_GSCNfSC_1454()
                {
                    ShoppingCartID = item.ORD_PRC_ShoppingCartID
                };
                var scNotes = cls_Get_ShoppingCart_Notes_for_ShoppingCartID.Invoke(Connection, Transaction, notesParam, securityTicket).Result;

                var count = 1;
                foreach (var scNote in scNotes)
                {
                    if(!scNote.IsNoteForProcurementOrder)
                        continue;

                    var officeInfo = ORM_ORD_PRC_Office_ShoppingCart.Query.Search(Connection, Transaction, new ORM_ORD_PRC_Office_ShoppingCart.Query() { 
                        ORD_PRC_ShoppingCart_RefID = item.ORD_PRC_ShoppingCartID,
                        IsDeleted = false
                    }).Single();

                    var note = new ORM_ORD_PRC_ProcurementOrder_Note();
                    note.ORD_PRC_ProcurementOrder_NoteID = Guid.NewGuid();
                    note.ORD_PRC_ProcurementOrder_Header_RefID = procurementOrderHeader.ORD_PRC_ProcurementOrder_HeaderID;
                    note.ORD_PRC_ProcurementOrder_Position_RefID = Guid.Empty;
                    note.CMN_STR_Office_RefID = officeInfo.CMN_STR_Office_RefID;
                    note.Comment = scNote.Memo_Text;
                    note.Title = "";
                    note.NotePublishDate = scNote.UpdatedOn;
                    note.SequenceOrderNumber = count;
                    note.Tenant_RefID = securityTicket.TenantID;

                    note.Save(Connection, Transaction);

                    count++;
                }

                #endregion

                #region Shopping Cart

                // Change shopping cart status
                item.ShoppingCart_CurrentStatus_RefID = statusOrdered.ORD_PRC_ShoppingCart_StatusID;
                item.IsProcurementOrderCreated = true;
                item.Save(Connection, Transaction);

                // Create and save new shopping cart history
                var shoppingHistory = new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCartStatus_History();
                shoppingHistory.ORD_PRC_ShoppingCart_RefID = item.ORD_PRC_ShoppingCartID;
                shoppingHistory.ORD_PRC_ShoppingCart_Status_RefID = statusOrdered.ORD_PRC_ShoppingCart_StatusID;
                shoppingHistory.PerformedBy_Account_RefID = securityTicket.AccountID;
                shoppingHistory.Tenant_RefID = securityTicket.TenantID;
                shoppingHistory.Save(Connection, Transaction);

                #endregion
            }

            //Save TotalValue_BeforeTax after updates
            procurementOrderHeader.Save(Connection, Transaction);

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Create_ProcurementOrder_from_Approved_ShoppingCarts_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_ProcurementOrder_from_Approved_ShoppingCarts_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_ProcurementOrder_from_Approved_ShoppingCarts_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

