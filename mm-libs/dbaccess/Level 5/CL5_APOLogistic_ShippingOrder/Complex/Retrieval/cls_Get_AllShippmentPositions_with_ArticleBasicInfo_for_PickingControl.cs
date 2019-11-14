/* 
 * Generated on 6/10/2014 5:18:11 PM
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
using CL5_APOLogistic_ShippingOrder.Atomic.Retrieval;
using CL3_Articles.Atomic.Retrieval;

namespace CL5_APOLogistic_ShippingOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllShippmentPositions_with_ArticleBasicInfo_for_PickingControl.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllShippmentPositions_with_ArticleBasicInfo_for_PickingControl
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_GASPwABIfPC_1135_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_GASPwABIfPC_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5SO_GASPwABIfPC_1135_Array();
            var articlesFromPosition = new List<Guid>();

            var paramP = new CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.P_L5SO_GASPfPC_1725
            {
                ShippmentHeaderID = Parameter.ShippmentHeaderID
            };
            var positions = cls_Get_All_ShippmentPositions_for_PickingControl.Invoke(Connection, Transaction, paramP, securityTicket).Result.ToList();
            foreach (var item in positions)
            {
                articlesFromPosition.Add(item.CMN_PRO_Product_RefID);
            }

            #region Get Article
            var paramA = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfAL_0942
            {
                ProductID_List = articlesFromPosition.Distinct().ToArray()
            };
            var articles = new List<L3AR_GAfAL_0942>();
            if (paramA.ProductID_List.Length > 0)
            {
                articles = CL3_Articles.Atomic.Retrieval.cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, paramA, securityTicket).Result.ToList();
            }
            #endregion

            var results = new List<L5SO_GASPwABIfPC_1135>();
            foreach (var pos in positions)
            {
                var positionArticles = new L5SO_GASPwABIfPC_1135();
                positionArticles.Position = pos;
                positionArticles.Articles = articles.Where(ar => ar.CMN_PRO_ProductID == pos.CMN_PRO_Product_RefID).Single();
                results.Add(positionArticles);
            }

            returnValue.Result = results.ToArray();
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SO_GASPwABIfPC_1135_Array Invoke(string ConnectionString,P_L5SO_GASPwABIfPC_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_GASPwABIfPC_1135_Array Invoke(DbConnection Connection,P_L5SO_GASPwABIfPC_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_GASPwABIfPC_1135_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_GASPwABIfPC_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_GASPwABIfPC_1135_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_GASPwABIfPC_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_GASPwABIfPC_1135_Array functionReturn = new FR_L5SO_GASPwABIfPC_1135_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllShippmentPositions_with_ArticleBasicInfo_for_PickingControl",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_GASPwABIfPC_1135_Array : FR_Base
	{
		public L5SO_GASPwABIfPC_1135[] Result	{ get; set; } 
		public FR_L5SO_GASPwABIfPC_1135_Array() : base() {}

		public FR_L5SO_GASPwABIfPC_1135_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_GASPwABIfPC_1135 for attribute P_L5SO_GASPwABIfPC_1135
		[DataContract]
		public class P_L5SO_GASPwABIfPC_1135 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShippmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SO_GASPwABIfPC_1135 for attribute L5SO_GASPwABIfPC_1135
		[DataContract]
		public class L5SO_GASPwABIfPC_1135 
		{
			//Standard type parameters
			[DataMember]
			public L5SO_GASPfPC_1725 Position { get; set; } 
			[DataMember]
			public L3AR_GAfAL_0942 Articles { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_GASPwABIfPC_1135_Array cls_Get_AllShippmentPositions_with_ArticleBasicInfo_for_PickingControl(,P_L5SO_GASPwABIfPC_1135 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_GASPwABIfPC_1135_Array invocationResult = cls_Get_AllShippmentPositions_with_ArticleBasicInfo_for_PickingControl.Invoke(connectionString,P_L5SO_GASPwABIfPC_1135 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Complex.Retrieval.P_L5SO_GASPwABIfPC_1135();
parameter.ShippmentHeaderID = ...;

*/
