/* 
 * Generated on 11/6/2014 2:31:08 PM
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
using CL2_Products.Atomic.Retrieval;

namespace CL3_Price.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StandardPrices_for_ProductITLList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StandardPrices_for_ProductITLList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GSPfPITLL_1258 Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GSPfPITLL_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L3PR_GSPfPITLL_1258();
            returnValue.Result = new L3PR_GSPfPITLL_1258();
            returnValue.Result.Prices = new L3PR_GSPfPIL_1645[0];

            #region ProductIDs
            var param = new P_L2PR_GPfPITL_1308()
            {
                ProductITLList = Parameter.ProductITLList
            };

            var products = cls_Get_ProductIDs_for_ProductITLs.Invoke(Connection, Transaction, param, securityTicket).Result;

            if(products == null || products.Count()==0)
                return returnValue;
            
            #endregion

            #region StandardPrices 
            
            var spParam = new P_L3PR_GSPfPIL_1645()
            {
                ProductIDList = products.Select(i => i.CMN_PRO_ProductID).ToArray()
            };

            var standardPrices = cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, spParam, securityTicket).Result;

            #endregion

            returnValue.Result.Prices = standardPrices;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PR_GSPfPITLL_1258 Invoke(string ConnectionString,P_L3PR_GSPfPITLL_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GSPfPITLL_1258 Invoke(DbConnection Connection,P_L3PR_GSPfPITLL_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GSPfPITLL_1258 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GSPfPITLL_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GSPfPITLL_1258 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GSPfPITLL_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GSPfPITLL_1258 functionReturn = new FR_L3PR_GSPfPITLL_1258();
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

				throw new Exception("Exception occured in method cls_Get_StandardPrices_for_ProductITLList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GSPfPITLL_1258 : FR_Base
	{
		public L3PR_GSPfPITLL_1258 Result	{ get; set; }

		public FR_L3PR_GSPfPITLL_1258() : base() {}

		public FR_L3PR_GSPfPITLL_1258(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GSPfPITLL_1258 for attribute P_L3PR_GSPfPITLL_1258
		[DataContract]
		public class P_L3PR_GSPfPITLL_1258 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerID { get; set; } 
			[DataMember]
			public String[] ProductITLList { get; set; } 

		}
		#endregion
		#region SClass L3PR_GSPfPITLL_1258 for attribute L3PR_GSPfPITLL_1258
		[DataContract]
		public class L3PR_GSPfPITLL_1258 
		{
			//Standard type parameters
			[DataMember]
			public L3PR_GSPfPIL_1645[] Prices { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GSPfPITLL_1258 cls_Get_StandardPrices_for_ProductITLList(,P_L3PR_GSPfPITLL_1258 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GSPfPITLL_1258 invocationResult = cls_Get_StandardPrices_for_ProductITLList.Invoke(connectionString,P_L3PR_GSPfPITLL_1258 Parameter,securityTicket);
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
var parameter = new CL3_Price.Complex.Retrieval.P_L3PR_GSPfPITLL_1258();
parameter.CustomerID = ...;
parameter.ProductITLList = ...;

*/