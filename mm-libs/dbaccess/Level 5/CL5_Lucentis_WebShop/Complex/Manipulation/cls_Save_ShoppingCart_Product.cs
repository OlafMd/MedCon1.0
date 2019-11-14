/* 
 * Generated on 12/11/2013 3:34:19 PM
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
    /// var result = cls_Save_ShoppingCart_Product.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ShoppingCart_Product
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5WS_SSCP_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            foreach (var paramShoppingCart in Parameter.ShoppingCart)
            {
                var item = new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Product();
                if (paramShoppingCart.ORD_PRC_ShoppingCart_ProductID != Guid.Empty)
                {
                    item.Load(Connection, Transaction, paramShoppingCart.ORD_PRC_ShoppingCart_ProductID);
                }

                // Check does for current shopping cart exist product with same id
                if (paramShoppingCart.ORD_PRC_ShoppingCart_ProductID == Guid.Empty)
                {
                    var existingProduct = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Product.Query.Search(Connection, Transaction,
                         new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Product.Query
                         {
                             CMN_PRO_Product_RefID = paramShoppingCart.CMN_PRO_Product_RefID,
                             ORD_PRC_ShoppingCart_RefID = paramShoppingCart.ORD_PRC_ShoppingCart_RefID,
                             Tenant_RefID = securityTicket.TenantID,
                             IsCanceled = false,
                             IsDeleted = false
                         }).FirstOrDefault();

                    if (existingProduct != null)
                    {
                        item = existingProduct;
                        paramShoppingCart.Quantity += item.Quantity;
                    }
                }

                if (paramShoppingCart.IsDeleted == true)
                {
                    item.IsDeleted = true;
                    return new FR_Guid(item.Save(Connection, Transaction), item.ORD_PRC_ShoppingCart_ProductID);
                }

                //Creation specific parameters (Tenant, Account ... )
                if (paramShoppingCart.ORD_PRC_ShoppingCart_ProductID == Guid.Empty)
                {
                    item.Tenant_RefID = securityTicket.TenantID;
                }

                item.ORD_PRC_ShoppingCart_RefID = paramShoppingCart.ORD_PRC_ShoppingCart_RefID;
                item.CMN_PRO_Product_RefID = paramShoppingCart.CMN_PRO_Product_RefID;
                item.CMN_PRO_Product_Variant_RefID = paramShoppingCart.CMN_PRO_Product_Variant_RefID;
                item.CMN_PRO_Product_Release_RefID = paramShoppingCart.CMN_PRO_Product_Release_RefID;
                item.SequenceNumber = paramShoppingCart.SequenceNumber;
                item.Quantity = paramShoppingCart.Quantity;
                item.IsCanceled = paramShoppingCart.IsCanceled;
                item.Save(Connection, Transaction);
            }
            return new FR_Guid(Guid.NewGuid());
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5WS_SSCP_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5WS_SSCP_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WS_SSCP_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WS_SSCP_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ShoppingCart_Product",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5WS_SSCP_1533 for attribute P_L5WS_SSCP_1533
		[DataContract]
		public class P_L5WS_SSCP_1533 
		{
			[DataMember]
			public P_L5AWSAR_SSCP_1653_ShoppingCart[] ShoppingCart { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5AWSAR_SSCP_1653_ShoppingCart for attribute ShoppingCart
		[DataContract]
		public class P_L5AWSAR_SSCP_1653_ShoppingCart 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ShoppingCart_ProductID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ShoppingCart_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_Variant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_Release_RefID { get; set; } 
			[DataMember]
			public int SequenceNumber { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public Boolean IsCanceled { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ShoppingCart_Product(,P_L5WS_SSCP_1533 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ShoppingCart_Product.Invoke(connectionString,P_L5WS_SSCP_1533 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_WebShop.Complex.Manipulation.P_L5WS_SSCP_1533();
parameter.ShoppingCart = ...;


*/
