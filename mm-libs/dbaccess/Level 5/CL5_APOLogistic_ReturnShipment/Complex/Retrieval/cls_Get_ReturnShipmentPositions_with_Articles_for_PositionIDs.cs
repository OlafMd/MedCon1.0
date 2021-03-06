/* 
 * Generated on 7/3/2014 10:42:14 AM
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
using CL5_APOLogistic_ReturnShipment.Atomic.Retrieval;
using CL3_Articles.Atomic.Retrieval;
using CL3_Price.Complex.Retrieval;

namespace CL5_APOLogistic_ReturnShipment.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ReturnShipmentPositions_with_Articles_for_PositionIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ReturnShipmentPositions_with_Articles_for_PositionIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RS_GRSPwAfP_1526_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5RS_GRSPwAfP_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_L5RS_GRSPwAfP_1526_Array();

            #region Get Return Shipment Positions
            var returnShipmentPositions = cls_Get_ReturnShipmentPositions_for_PositionIDs.Invoke(Connection, Transaction, Parameter.SearchCriteria, securityTicket).Result;
            #endregion

            #region Get Articles
            var articleIDs = returnShipmentPositions.Select(rsp => rsp.CMN_PRO_Product_RefID).Distinct().ToArray<Guid>();

            var articles = new L3AR_GAfAL_0942[0];
            var prices = new L3PR_GSPfPIL_1645[0];

            if (articleIDs.Length != 0)
            {
                var parameterArticles = new P_L3AR_GAfAL_0942
                {
                    ProductID_List = articleIDs
                };
                articles = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, parameterArticles, securityTicket).Result;

                var parameterPrices = new P_L3PR_GSPfPIL_1645
                {
                    ProductIDList = articleIDs
                };
                prices = cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, parameterPrices, securityTicket).Result;
            }
            #endregion

            #region Set Return Value
            var returnElements = new List<L5RS_GRSPwAfP_1526>();
            foreach (var position in returnShipmentPositions)
            {
                var returnElement = new L5RS_GRSPwAfP_1526
                {
                    Article = articles.FirstOrDefault(a => a.CMN_PRO_ProductID == position.CMN_PRO_Product_RefID),
                    Price = prices.FirstOrDefault(a => a.ProductID == position.CMN_PRO_Product_RefID),
                    Position = position
                };
                returnElements.Add(returnElement);
            }
            returnValue.Result = returnElements.ToArray();
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5RS_GRSPwAfP_1526_Array Invoke(string ConnectionString,P_L5RS_GRSPwAfP_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RS_GRSPwAfP_1526_Array Invoke(DbConnection Connection,P_L5RS_GRSPwAfP_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RS_GRSPwAfP_1526_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RS_GRSPwAfP_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RS_GRSPwAfP_1526_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RS_GRSPwAfP_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RS_GRSPwAfP_1526_Array functionReturn = new FR_L5RS_GRSPwAfP_1526_Array();
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

				throw new Exception("Exception occured in method cls_Get_ReturnShipmentPositions_with_Articles_for_PositionIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5RS_GRSPwAfP_1526_Array : FR_Base
	{
		public L5RS_GRSPwAfP_1526[] Result	{ get; set; } 
		public FR_L5RS_GRSPwAfP_1526_Array() : base() {}

		public FR_L5RS_GRSPwAfP_1526_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5RS_GRSPwAfP_1526 for attribute P_L5RS_GRSPwAfP_1526
		[DataContract]
		public class P_L5RS_GRSPwAfP_1526 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOLogistic_ReturnShipment.Atomic.Retrieval.P_L5RS_GRSPfP_1523 SearchCriteria { get; set; } 

		}
		#endregion
		#region SClass L5RS_GRSPwAfP_1526 for attribute L5RS_GRSPwAfP_1526
		[DataContract]
		public class L5RS_GRSPwAfP_1526 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL3_Price.Complex.Retrieval.L3PR_GSPfPIL_1645 Price { get; set; } 
			[DataMember]
			public CL5_APOLogistic_ReturnShipment.Atomic.Retrieval.L5RS_GRSPfP_1523 Position { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RS_GRSPwAfP_1526_Array cls_Get_ReturnShipmentPositions_with_Articles_for_PositionIDs(,P_L5RS_GRSPwAfP_1526 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RS_GRSPwAfP_1526_Array invocationResult = cls_Get_ReturnShipmentPositions_with_Articles_for_PositionIDs.Invoke(connectionString,P_L5RS_GRSPwAfP_1526 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ReturnShipment.Complex.Retrieval.P_L5RS_GRSPwAfP_1526();
parameter.SearchCriteria = ...;

*/
