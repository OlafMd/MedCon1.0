/* 
 * Generated on 09/01/2014 17:52:01
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
using CL3_Articles.Atomic.Retrieval;
using CL5_APOWebShop_ShoppingCart.Atomic.Retrieval;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL5_APOWebShop_ShoppingCart.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShoppingProducts_for_ShoppingCartID_with_AdditionalInfo.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShoppingProducts_for_ShoppingCartID_with_AdditionalInfo
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AWSSC_GSPfSCIwAI_1135 Execute(DbConnection Connection,DbTransaction Transaction,P_L5AWSSC_GSPfSCIwAI_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5AWSSC_GSPfSCIwAI_1135();
            returnValue.Result = new L5AWSSC_GSPfSCIwAI_1135();
			//Put your code here

		    var shoppingCart =
		        cls_Get_ShoppingProducts_for_ShoppingCartID.Invoke(Connection, Transaction,
                    new P_L5AWSSC_GSPfSC_1650 { ShoppingCartID = Parameter.ShoppingCartID }, securityTicket).Result;

            L5SC_GAwASfAL_0909[] productAdditionalInfo;
		    if (shoppingCart.Products != null && shoppingCart.Products.Length > 0)
		    {
                
                productAdditionalInfo = cls_Get_Articles_with_ActiveSupstances_for_ArticleList.Invoke(Connection, Transaction, new P_L5SC_GAwASfAL_0909 { ProductID_List = shoppingCart.Products.Select(x => x.CMN_PRO_Product_RefID).ToArray() }, securityTicket).Result;    
		    }
		    else
		    {
		        productAdditionalInfo = null;
		    }
            


		    returnValue.Result.ShoppingCart = shoppingCart;
		    returnValue.Result.ProductsAdditionalInfo = productAdditionalInfo;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AWSSC_GSPfSCIwAI_1135 Invoke(string ConnectionString,P_L5AWSSC_GSPfSCIwAI_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AWSSC_GSPfSCIwAI_1135 Invoke(DbConnection Connection,P_L5AWSSC_GSPfSCIwAI_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AWSSC_GSPfSCIwAI_1135 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AWSSC_GSPfSCIwAI_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AWSSC_GSPfSCIwAI_1135 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AWSSC_GSPfSCIwAI_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AWSSC_GSPfSCIwAI_1135 functionReturn = new FR_L5AWSSC_GSPfSCIwAI_1135();
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

				throw new Exception("Exception occured in method cls_Get_ShoppingProducts_for_ShoppingCartID_with_AdditionalInfo",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AWSSC_GSPfSCIwAI_1135 : FR_Base
	{
		public L5AWSSC_GSPfSCIwAI_1135 Result	{ get; set; }

		public FR_L5AWSSC_GSPfSCIwAI_1135() : base() {}

		public FR_L5AWSSC_GSPfSCIwAI_1135(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AWSSC_GSPfSCIwAI_1135 for attribute P_L5AWSSC_GSPfSCIwAI_1135
		[DataContract]
		public class P_L5AWSSC_GSPfSCIwAI_1135 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShoppingCartID { get; set; } 

		}
		#endregion
		#region SClass L5AWSSC_GSPfSCIwAI_1135 for attribute L5AWSSC_GSPfSCIwAI_1135
		[DataContract]
		public class L5AWSSC_GSPfSCIwAI_1135 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.L5AWSSC_GSPfSC_1650 ShoppingCart { get; set; } 
			[DataMember]
            public CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.L5SC_GAwASfAL_0909[] ProductsAdditionalInfo { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AWSSC_GSPfSCIwAI_1135 cls_Get_ShoppingProducts_for_ShoppingCartID_with_AdditionalInfo(,P_L5AWSSC_GSPfSCIwAI_1135 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AWSSC_GSPfSCIwAI_1135 invocationResult = cls_Get_ShoppingProducts_for_ShoppingCartID_with_AdditionalInfo.Invoke(connectionString,P_L5AWSSC_GSPfSCIwAI_1135 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ShoppingCart.Complex.Retrieval.P_L5AWSSC_GSPfSCIwAI_1135();
parameter.ShoppingCartID = ...;

*/
