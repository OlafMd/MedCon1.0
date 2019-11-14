/* 
 * Generated on 10/1/2014 05:30:12
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
using DLCore_DBCommons.APODemand;

namespace CL5_APOWebShop_ShoppingCart.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Check_User_Permissions_for_ShoppingCart_Before_Order.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Check_User_Permissions_for_ShoppingCart_Before_Order
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AWSSC_CUPfSCBO_1414 Execute(DbConnection Connection,DbTransaction Transaction,P_L5AWSSC_CUPfSCBO_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5AWSSC_CUPfSCBO_1414();
            returnValue.Result = new L5AWSSC_CUPfSCBO_1414();

            // Get shopping cart
            var shoppingCart = new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart();
            shoppingCart.Load(Connection, Transaction, Parameter.ORD_PRC_ShoppingCartID);

            // Check does current user has a privilege to order ABDA articles
            var flrParam = new CL2_FunctionLevelRight.Complex.Retrieval.P_L2FLR_GFLRfABoIoG_1215();
            flrParam.AccountFunctionLevelRightGroup = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(EAccountFunctionLevelRightGroup.APOWebShop);
            var levels = CL2_FunctionLevelRight.Complex.Retrieval.cls_Get_FunctionalLevelRight_for_Account_Based_on_Individual_or_Group.Invoke(Connection, Transaction, flrParam, securityTicket);

            EAccountFunctionLevelRight maxLevel = EAccountFunctionLevelRight.APOWebShopLevel1;
            foreach(var str in levels.Result)
            {
                EAccountFunctionLevelRight l = (EAccountFunctionLevelRight)DLCore_DBCommons.Utils.EnumUtils.GetEnumValueByDescription(str.RightLevel, typeof(EAccountFunctionLevelRight));
                if((int)l > (int)maxLevel)
                    maxLevel = l;
            }

            switch(maxLevel)
            {
                case EAccountFunctionLevelRight.APOWebShopLevel1:
                    returnValue.Result.HasPrivileges = false;
                    returnValue.Result.CreateApprovalShoppingCart = true;
                    break;
                    case EAccountFunctionLevelRight.APOWebShopLevel2:
                    returnValue.Result.HasPrivileges = true;
                    returnValue.Result.CreateApprovalShoppingCart = true;
                    break;
                    case EAccountFunctionLevelRight.APOWebShopLevel3:
                    returnValue.Result.HasPrivileges = true;
                    break;
            }
            
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AWSSC_CUPfSCBO_1414 Invoke(string ConnectionString,P_L5AWSSC_CUPfSCBO_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AWSSC_CUPfSCBO_1414 Invoke(DbConnection Connection,P_L5AWSSC_CUPfSCBO_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AWSSC_CUPfSCBO_1414 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AWSSC_CUPfSCBO_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AWSSC_CUPfSCBO_1414 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AWSSC_CUPfSCBO_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AWSSC_CUPfSCBO_1414 functionReturn = new FR_L5AWSSC_CUPfSCBO_1414();
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

				throw new Exception("Exception occured in method cls_Check_User_Permissions_for_ShoppingCart_Before_Order",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AWSSC_CUPfSCBO_1414 : FR_Base
	{
		public L5AWSSC_CUPfSCBO_1414 Result	{ get; set; }

		public FR_L5AWSSC_CUPfSCBO_1414() : base() {}

		public FR_L5AWSSC_CUPfSCBO_1414(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AWSSC_CUPfSCBO_1414 for attribute P_L5AWSSC_CUPfSCBO_1414
		[DataContract]
		public class P_L5AWSSC_CUPfSCBO_1414 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ShoppingCartID { get; set; } 

		}
		#endregion
		#region SClass L5AWSSC_CUPfSCBO_1414 for attribute L5AWSSC_CUPfSCBO_1414
		[DataContract]
		public class L5AWSSC_CUPfSCBO_1414 
		{
			//Standard type parameters
			[DataMember]
			public bool HasPrivileges { get; set; } 
			[DataMember]
			public bool CreateApprovalShoppingCart { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AWSSC_CUPfSCBO_1414 cls_Check_User_Permissions_for_ShoppingCart_Before_Order(,P_L5AWSSC_CUPfSCBO_1414 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AWSSC_CUPfSCBO_1414 invocationResult = cls_Check_User_Permissions_for_ShoppingCart_Before_Order.Invoke(connectionString,P_L5AWSSC_CUPfSCBO_1414 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ShoppingCart.Complex.Retrieval.P_L5AWSSC_CUPfSCBO_1414();
parameter.ORD_PRC_ShoppingCartID = ...;

*/
