/* 
 * Generated on 10/6/2014 03:43:57
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
using System.Runtime.Serialization;
using CL5_APOBilling_CustomerOrderReturn.Atomic.Retrieval;

namespace CL5_APOBilling_Bill.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_OpenOrderReturnPositions_with_Articles_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OpenOrderReturnPositions_with_Articles_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GOORPwAfT_1427_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5BL_GOORPwAfT_1427_Array();
			//Put your code here

            //Get Customer Order Return Positions
            var customerOrderReturnPositions = cls_Get_Open_CustomerOrderReturnPosition_with_Data.Invoke(Connection, Transaction, securityTicket).Result;

            // Get Articles
            var arrayOfProductId = customerOrderReturnPositions.Select(x => x.CMN_PRO_Product_RefID).ToArray<Guid>();

            var paramArticles = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfAL_0942();
            paramArticles.ProductID_List = arrayOfProductId;

            var articles = new CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942[0];

            if (arrayOfProductId.Length != 0)
            {
                articles = CL3_Articles.Atomic.Retrieval.cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, paramArticles, securityTicket).Result;
            }

            var lsrResult = new List<L5BL_GOORPwAfT_1427>();

            foreach (var position in customerOrderReturnPositions)
            {
                var retObj = new L5BL_GOORPwAfT_1427();
                retObj.OrderReturnPositions = position;
                retObj.Article = articles.SingleOrDefault(x => x.CMN_PRO_ProductID == position.CMN_PRO_Product_RefID);

                lsrResult.Add(retObj);
            }

            returnValue.Result = lsrResult.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BL_GOORPwAfT_1427_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GOORPwAfT_1427_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GOORPwAfT_1427_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GOORPwAfT_1427_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GOORPwAfT_1427_Array functionReturn = new FR_L5BL_GOORPwAfT_1427_Array();
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

				throw new Exception("Exception occured in method cls_Get_OpenOrderReturnPositions_with_Articles_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GOORPwAfT_1427_Array : FR_Base
	{
		public L5BL_GOORPwAfT_1427[] Result	{ get; set; } 
		public FR_L5BL_GOORPwAfT_1427_Array() : base() {}

		public FR_L5BL_GOORPwAfT_1427_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5BL_GOORPwAfT_1427 for attribute L5BL_GOORPwAfT_1427
		[DataContract]
		public class L5BL_GOORPwAfT_1427 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOBilling_CustomerOrderReturn.Atomic.Retrieval.L5OR_GOCORPwD_1526 OrderReturnPositions { get; set; } 
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GOORPwAfT_1427_Array cls_Get_OpenOrderReturnPositions_with_Articles_for_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BL_GOORPwAfT_1427_Array invocationResult = cls_Get_OpenOrderReturnPositions_with_Articles_for_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

