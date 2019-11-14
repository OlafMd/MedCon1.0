/* 
 * Generated on 6/20/2014 3:24:54 PM
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
using CL3_CustomerOrder.Atomic.Retrieval;

namespace CL5_APOBackoffice_CustomerOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrderReturnPositions_with_Details_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrderReturnPositions_with_Details_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_GCORPwDfH_1521_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_GCORPwDfH_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5CO_GCORPwDfH_1521_Array();
			
            #region Get CustomerOrderReturn Positions
            var customerOrderReturnPositions = cls_Get_CustomerOrderReturnHeaders_with_Positions_by_HeaderIDs.Invoke(
                Connection, 
                Transaction, 
                new P_L3CO_GCORHwPbH_1610() { CustomerOrderReturnHeaderIDs = new Guid[] { Parameter.CustomerOrderReturnHeaderID } }, 
                securityTicket);
            if (customerOrderReturnPositions.Status != FR_Status.Success || customerOrderReturnPositions.Result == null || customerOrderReturnPositions.Result.Count() <= 0)
            {
                returnValue.Result = null;
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            }
            var resultCustomerOrderReturnPositions = customerOrderReturnPositions.Result.Single().Positions;
            #endregion

            #region Get Articles
            var paramArticles = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfAL_0942();
            paramArticles.ProductID_List = resultCustomerOrderReturnPositions.Select(x => x.CMN_PRO_Product_RefID).ToArray<Guid>();
            var articles = new CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942[0];
            if (paramArticles.ProductID_List.Length != 0)
            {
                articles = CL3_Articles.Atomic.Retrieval.cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, paramArticles, securityTicket).Result;
            }
            #endregion

            #region Set Result
            var lsrResult = new List<L5CO_GCORPwDfH_1521>();
            foreach (var position in resultCustomerOrderReturnPositions)
            {
                var article = articles.SingleOrDefault(x => x.CMN_PRO_ProductID == position.CMN_PRO_Product_RefID);
                if (article == null)
                    continue;

                lsrResult.Add(new L5CO_GCORPwDfH_1521()
                {
                    Position = position,
                    Article = article
                });
            }
            returnValue.Status = FR_Status.Success;
            returnValue.Result = lsrResult.ToArray();
            #endregion

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CO_GCORPwDfH_1521_Array Invoke(string ConnectionString,P_L5CO_GCORPwDfH_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_GCORPwDfH_1521_Array Invoke(DbConnection Connection,P_L5CO_GCORPwDfH_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_GCORPwDfH_1521_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_GCORPwDfH_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_GCORPwDfH_1521_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_GCORPwDfH_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_GCORPwDfH_1521_Array functionReturn = new FR_L5CO_GCORPwDfH_1521_Array();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrderReturnPositions_with_Details_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_GCORPwDfH_1521_Array : FR_Base
	{
		public L5CO_GCORPwDfH_1521[] Result	{ get; set; } 
		public FR_L5CO_GCORPwDfH_1521_Array() : base() {}

		public FR_L5CO_GCORPwDfH_1521_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CO_GCORPwDfH_1521 for attribute P_L5CO_GCORPwDfH_1521
		[DataContract]
		public class P_L5CO_GCORPwDfH_1521 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderReturnHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5CO_GCORPwDfH_1521 for attribute L5CO_GCORPwDfH_1521
		[DataContract]
		public class L5CO_GCORPwDfH_1521 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL3_CustomerOrder.Atomic.Retrieval.L3CO_GCORHwPbH_1610a Position { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_GCORPwDfH_1521_Array cls_Get_CustomerOrderReturnPositions_with_Details_for_HeaderID(,P_L5CO_GCORPwDfH_1521 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_GCORPwDfH_1521_Array invocationResult = cls_Get_CustomerOrderReturnPositions_with_Details_for_HeaderID.Invoke(connectionString,P_L5CO_GCORPwDfH_1521 Parameter,securityTicket);
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
var parameter = new CL5_APOBackoffice_CustomerOrder.Complex.Retrieval.P_L5CO_GCORPwDfH_1521();
parameter.CustomerOrderReturnHeaderID = ...;

*/
