/* 
 * Generated on 10/1/2014 05:25:04
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
using CL5_APOWebShop_ShoppingCart.Complex.Retrieval;
using CL5_APOWebShop_ShoppingCart.Atomic.Retrieval;
using DLCore_DBCommons.APODemand;

namespace CL5_APOWebShop_ShoppingCart.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Approval_Cart_for_ShoppingCart_Before_Order.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Approval_Cart_for_ShoppingCart_Before_Order
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AWSAR_CAPCfSCBO_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            // Find priviges for current user
            var checkParam = new P_L5AWSSC_CUPfSCBO_1414();
            checkParam.ORD_PRC_ShoppingCartID = Parameter.ShoppingCartID;
            var checkResult = cls_Check_User_Permissions_for_ShoppingCart_Before_Order.Invoke(Connection, Transaction, checkParam, securityTicket).Result;

            if (!checkResult.HasPrivileges)
            {
                throw new Exception("User doesn't have privileges to order!");
            }

            if (checkResult.CreateApprovalShoppingCart)
            {
                // Check does user have ABDA articles
                var paramShoppingProducts = new P_L5AWSSC_GSPfSC_1650 { ShoppingCartID = Parameter.ShoppingCartID };

                var shoppingProducts = cls_Get_ShoppingProducts_for_ShoppingCartID.Invoke(Connection, Transaction, paramShoppingProducts, securityTicket).Result;
                var shoppingProductsForApproval = new List<CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Product>();

                foreach (var p in shoppingProducts.Products)
                {
                    if (p.Group_GlobalPropertyMatchingID == DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(EProductGroup.ABDA))
                    {
                        var product = new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Product();
                        product.Load(Connection, Transaction, p.ORD_PRC_ShoppingCart_ProductID);
                        shoppingProductsForApproval.Add(product);
                    }
                }

                // Create new approval shopping cart
                if (shoppingProductsForApproval.Count > 0)
                {
                    // Find office for current shopping cart
                    var officeShoppingCart = CL1_ORD_PRC.ORM_ORD_PRC_Office_ShoppingCart.Query.Search(Connection, Transaction,
                        new CL1_ORD_PRC.ORM_ORD_PRC_Office_ShoppingCart.Query
                        {
                            ORD_PRC_ShoppingCart_RefID = Parameter.ShoppingCartID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Single();

                    // Create new shopping cart that will contain ABDA articles
                    var paramCreateShoppingCart = new P_L5AWSAR_CSC_1809();
                    paramCreateShoppingCart.IsWaitingForApproval = true;
                    paramCreateShoppingCart.OfficeID = officeShoppingCart.CMN_STR_Office_RefID;
                    var newShoppingCartId = cls_Create_ShoppingChart_for_CurrentOffice.Invoke(Connection, Transaction, paramCreateShoppingCart, securityTicket).Result;

                    // Move products from current shopping cart to new shopping cart
                    foreach (var p in shoppingProductsForApproval)
                    {
                        p.ORD_PRC_ShoppingCart_RefID = newShoppingCartId;
                        p.Save(Connection, Transaction);
                    }
                }
            }
            
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AWSAR_CAPCfSCBO_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AWSAR_CAPCfSCBO_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AWSAR_CAPCfSCBO_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AWSAR_CAPCfSCBO_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_Approval_Cart_for_ShoppingCart_Before_Order",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AWSAR_CAPCfSCBO_1349 for attribute P_L5AWSAR_CAPCfSCBO_1349
		[DataContract]
		public class P_L5AWSAR_CAPCfSCBO_1349 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShoppingCartID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_Approval_Cart_for_ShoppingCart_Before_Order(,P_L5AWSAR_CAPCfSCBO_1349 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_Approval_Cart_for_ShoppingCart_Before_Order.Invoke(connectionString,P_L5AWSAR_CAPCfSCBO_1349 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ShoppingCart.Complex.Manipulation.P_L5AWSAR_CAPCfSCBO_1349();
parameter.ShoppingCartID = ...;

*/
