/* 
 * Generated on 09/01/2014 16:36:16
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Collections;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CL3_Articles.Atomic.Retrieval;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL5_APOWebShop_ShoppingCart.Atomic.Retrieval;

namespace CL5_APOWebShop_ShoppingCart.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_or_Create_ShoppingCart_for_CurrentOffice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_or_Create_ShoppingCart_for_CurrentOffice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AWSSC_GoCSCfCO_1105_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AWSSC_GoCSCfCO_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5AWSSC_GoCSCfCO_1105_Array();

            // Get active shopping cart status for tenant
            var statusActive = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query()
                {
                    GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EShoppingCartStatus.Active),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();


            CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.P_L5AWSAR_GSCfCO_1805 getParameter = new CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.P_L5AWSAR_GSCfCO_1805();
            getParameter.OfficeID = Parameter.OfficeID;
            getParameter.ShoppingCartStatusID = statusActive.ORD_PRC_ShoppingCart_StatusID;

            // Find ProductGroupMatchingID for BusinessParticipant_RefID
            var account = new CL1_USR.ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);
            //getParameter.ProductGroupMatchingID = EnumUtils.GetEnumDescription(EProductGroup.HauseList);

            // Retrieve shopping cart
            var shoppingCartProducts = CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.cls_Get_ShoppingChart_for_CurrentOffice.Invoke(Connection, Transaction, getParameter, securityTicket).Result;

            if (shoppingCartProducts.Length == 0)
            {
                // Create shopping cart.
                CL5_APOWebShop_ShoppingCart.Complex.Manipulation.P_L5AWSAR_CSC_1809 createParameter = new CL5_APOWebShop_ShoppingCart.Complex.Manipulation.P_L5AWSAR_CSC_1809();
                createParameter.OfficeID = Parameter.OfficeID;
                Guid shoppingCartID = CL5_APOWebShop_ShoppingCart.Complex.Manipulation.cls_Create_ShoppingChart_for_CurrentOffice.Invoke(Connection, Transaction, createParameter, securityTicket).Result;
                // Again retrieve shopping cart
                shoppingCartProducts = CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.cls_Get_ShoppingChart_for_CurrentOffice.Invoke(Connection, Transaction, getParameter, securityTicket).Result;

                


            }

            List<L5AWSSC_GoCSCfCO_1105> shoppingCarts = new List<L5AWSSC_GoCSCfCO_1105>();
            L5SC_GAwASfAL_0909[] AdditionInfo;
            foreach (var item in shoppingCartProducts)
            {
                L5AWSSC_GoCSCfCO_1105 shoppingCart = new L5AWSSC_GoCSCfCO_1105();
                shoppingCart.ORD_PRC_ShoppingCartID = item.ORD_PRC_ShoppingCartID;
                shoppingCart.CMN_STR_Office_RefID = item.CMN_STR_Office_RefID;
                shoppingCart.ORD_PRC_Office_ShoppingCartID = item.ORD_PRC_Office_ShoppingCartID;
                shoppingCart.IsProcurementOrderCreated = item.IsProcurementOrderCreated;
                shoppingCart.Office_InternalName = item.Office_InternalName;
                shoppingCart.ShoppingCartStatus = item.ShoppingCartStatus;
                shoppingCart.Products = item.Products;


                if (item.Products != null && item.Products.Any())
                {
                    
                    AdditionInfo =
                        cls_Get_Articles_with_ActiveSupstances_for_ArticleList.Invoke(Connection, Transaction,
                            new P_L5SC_GAwASfAL_0909
                            {
                                ProductID_List = item.Products.Select(x=> x.CMN_PRO_Product_RefID).ToArray()
                            },
                            securityTicket).Result;
                        
                }
                else AdditionInfo = null;
                shoppingCart.ProductsAdditionalInfo = AdditionInfo;
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
		public static FR_L5AWSSC_GoCSCfCO_1105_Array Invoke(string ConnectionString,P_L5AWSSC_GoCSCfCO_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AWSSC_GoCSCfCO_1105_Array Invoke(DbConnection Connection,P_L5AWSSC_GoCSCfCO_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AWSSC_GoCSCfCO_1105_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AWSSC_GoCSCfCO_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AWSSC_GoCSCfCO_1105_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AWSSC_GoCSCfCO_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AWSSC_GoCSCfCO_1105_Array functionReturn = new FR_L5AWSSC_GoCSCfCO_1105_Array();
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

				throw new Exception("Exception occured in method cls_Get_or_Create_ShoppingCart_for_CurrentOffice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AWSSC_GoCSCfCO_1105_Array : FR_Base
	{
		public L5AWSSC_GoCSCfCO_1105[] Result	{ get; set; } 
		public FR_L5AWSSC_GoCSCfCO_1105_Array() : base() {}

		public FR_L5AWSSC_GoCSCfCO_1105_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AWSSC_GoCSCfCO_1105 for attribute P_L5AWSSC_GoCSCfCO_1105
		[DataContract]
		public class P_L5AWSSC_GoCSCfCO_1105 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 

		}
		#endregion
		#region SClass L5AWSSC_GoCSCfCO_1105 for attribute L5AWSSC_GoCSCfCO_1105
		[DataContract]
		public class L5AWSSC_GoCSCfCO_1105 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ShoppingCartID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_Office_ShoppingCartID { get; set; } 
			[DataMember]
			public Guid CMN_STR_Office_RefID { get; set; } 
			[DataMember]
			public bool IsProcurementOrderCreated { get; set; } 
			[DataMember]
			public string Office_InternalName { get; set; } 
			[DataMember]
			public string ShoppingCartStatus { get; set; } 
			[DataMember]
			public CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.L5AWSAR_GSCfCO_1805_Product[] Products { get; set; } 
			[DataMember]
            public CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.L5SC_GAwASfAL_0909[] ProductsAdditionalInfo { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AWSSC_GoCSCfCO_1105_Array cls_Get_or_Create_ShoppingCart_for_CurrentOffice(,P_L5AWSSC_GoCSCfCO_1105 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AWSSC_GoCSCfCO_1105_Array invocationResult = cls_Get_or_Create_ShoppingCart_for_CurrentOffice.Invoke(connectionString,P_L5AWSSC_GoCSCfCO_1105 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ShoppingCart.Complex.Retrieval.P_L5AWSSC_GoCSCfCO_1105();
parameter.OfficeID = ...;

*/
