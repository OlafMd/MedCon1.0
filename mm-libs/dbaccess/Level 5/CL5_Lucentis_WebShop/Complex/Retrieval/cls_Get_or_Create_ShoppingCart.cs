/* 
 * Generated on 12/23/2013 2:31:00 PM
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
using CL5_Lucentis_WebShop.Complex.Manipulation;

namespace CL5_Lucentis_WebShop.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_or_Create_ShoppingCart.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_or_Create_ShoppingCart
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5WS_GoCSC_1550_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5WS_GoCSC_1550 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5WS_GoCSC_1550_Array();

            List<L5WS_GoCSC_1550> shoppingCarts = new List<L5WS_GoCSC_1550>();
            // Get active shopping cart status for tenant
            var statusActive = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query()
                {
                    GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EShoppingCartStatus.Active),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

            CL5_Lucentis_WebShop.Atomic.Retrieval.P_L5WS_GSCfSCS_1539 getParameter = new CL5_Lucentis_WebShop.Atomic.Retrieval.P_L5WS_GSCfSCS_1539();
            getParameter.ShoppingCartStatusID = statusActive.ORD_PRC_ShoppingCart_StatusID;
            getParameter.PracticeBPID = Parameter.PracticeBPID;
            // Retrieve shopping cart
            var shoppingCartProducts = CL5_Lucentis_WebShop.Atomic.Retrieval.cls_Get_ShoppingCart_for_ShoppingCartStatusID.Invoke(Connection, Transaction, getParameter, securityTicket).Result;

            if (shoppingCartProducts.Length == 0)
            {
                // Create shopping cart.
                P_L5WS_CSCfP_1431 createParam = new P_L5WS_CSCfP_1431();
                createParam.PracticeBPID = Parameter.PracticeBPID;
                Guid shoppingCartID = CL5_Lucentis_WebShop.Complex.Manipulation.cls_Create_ShoppingChart.Invoke(Connection, Transaction, createParam, securityTicket).Result;
                // Again retrieve shopping cart
                shoppingCartProducts = CL5_Lucentis_WebShop.Atomic.Retrieval.cls_Get_ShoppingCart_for_ShoppingCartStatusID.Invoke(Connection, Transaction, getParameter, securityTicket).Result;
            }

            foreach (var item in shoppingCartProducts)
            {
                L5WS_GoCSC_1550 shoppingCart = new L5WS_GoCSC_1550();
                shoppingCart.ORD_PRC_ShoppingCartID = item.ORD_PRC_ShoppingCartID;
                shoppingCart.Products = item.Products;
                shoppingCarts.Add(shoppingCart);
            }
           
            returnValue.Result = shoppingCarts.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5WS_GoCSC_1550_Array Invoke(string ConnectionString,P_L5WS_GoCSC_1550 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5WS_GoCSC_1550_Array Invoke(DbConnection Connection,P_L5WS_GoCSC_1550 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5WS_GoCSC_1550_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WS_GoCSC_1550 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5WS_GoCSC_1550_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WS_GoCSC_1550 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5WS_GoCSC_1550_Array functionReturn = new FR_L5WS_GoCSC_1550_Array();
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

				throw new Exception("Exception occured in method cls_Get_or_Create_ShoppingCart",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5WS_GoCSC_1550_Array : FR_Base
	{
		public L5WS_GoCSC_1550[] Result	{ get; set; } 
		public FR_L5WS_GoCSC_1550_Array() : base() {}

		public FR_L5WS_GoCSC_1550_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5WS_GoCSC_1550 for attribute P_L5WS_GoCSC_1550
		[DataContract]
		public class P_L5WS_GoCSC_1550 
		{
			//Standard type parameters
			[DataMember]
			public String PracticeBPID { get; set; } 

		}
		#endregion
		#region SClass L5WS_GoCSC_1550 for attribute L5WS_GoCSC_1550
		[DataContract]
		public class L5WS_GoCSC_1550 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ShoppingCartID { get; set; } 
			[DataMember]
			public CL5_Lucentis_WebShop.Atomic.Retrieval.L5WS_GSCfSCS_1539_Product[] Products { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5WS_GoCSC_1550_Array cls_Get_or_Create_ShoppingCart(,P_L5WS_GoCSC_1550 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5WS_GoCSC_1550_Array invocationResult = cls_Get_or_Create_ShoppingCart.Invoke(connectionString,P_L5WS_GoCSC_1550 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_WebShop.Complex.Retrieval.P_L5WS_GoCSC_1550();
parameter.PracticeBPID = ...;

*/
