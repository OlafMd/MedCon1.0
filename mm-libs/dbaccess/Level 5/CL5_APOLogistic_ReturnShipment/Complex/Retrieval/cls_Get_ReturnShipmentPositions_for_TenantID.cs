/* 
 * Generated on 28/4/2014 02:08:17
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
using CL3_Articles.Atomic.Retrieval;
using CL5_APOLogistic_ReturnShipment.Atomic.Retrieval;

namespace CL5_APOLogistic_ReturnShipment.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ReturnShipmentPositions_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ReturnShipmentPositions_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RS_GRSPfT_1636_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5RS_GRSPfT_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 

            var returnValue = new FR_L5RS_GRSPfT_1636_Array();
            var shipmentPositions = cls_Get_ReturnShipmentPositions.Invoke(Connection, Transaction, Parameter.SearchParam, securityTicket).Result;

            #region Get Articles
            var parameterProductIds = new P_L3AR_GAfAL_0942();
            parameterProductIds.ProductID_List = shipmentPositions.Select(s => s.CMN_PRO_Product_RefID).ToArray();
            var articles = new L3AR_GAfAL_0942[0];
            if (parameterProductIds.ProductID_List.Length != 0)
            {
                articles = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, parameterProductIds, securityTicket).Result;
            }
            #endregion 

            #region Set Return Value
            var returnElements = new List<L5RS_GRSPfT_1636>();
            foreach (var shipmentPosition in shipmentPositions)
            {
                var returnElement = new L5RS_GRSPfT_1636
                {
                    Article = articles.FirstOrDefault(a => a.CMN_PRO_ProductID == shipmentPosition.CMN_PRO_Product_RefID),
                    Position = shipmentPosition
                };
                returnElements.Add(returnElement);
            }

            returnValue.Result = returnElements.ToArray();
            #endregion

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5RS_GRSPfT_1636_Array Invoke(string ConnectionString,P_L5RS_GRSPfT_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RS_GRSPfT_1636_Array Invoke(DbConnection Connection,P_L5RS_GRSPfT_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RS_GRSPfT_1636_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RS_GRSPfT_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RS_GRSPfT_1636_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RS_GRSPfT_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RS_GRSPfT_1636_Array functionReturn = new FR_L5RS_GRSPfT_1636_Array();
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

				throw new Exception("Exception occured in method cls_Get_ReturnShipmentPositions_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5RS_GRSPfT_1636_Array : FR_Base
	{
		public L5RS_GRSPfT_1636[] Result	{ get; set; } 
		public FR_L5RS_GRSPfT_1636_Array() : base() {}

		public FR_L5RS_GRSPfT_1636_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5RS_GRSPfT_1636 for attribute P_L5RS_GRSPfT_1636
		[DataContract]
		public class P_L5RS_GRSPfT_1636 
		{
			//Standard type parameters
			[DataMember]
			public Guid Header_ID { get; set; } 
			[DataMember]
			public CL5_APOLogistic_ReturnShipment.Atomic.Retrieval.P_L5RS_RSP_1552 SearchParam { get; set; } 

		}
		#endregion
		#region SClass L5RS_GRSPfT_1636 for attribute L5RS_GRSPfT_1636
		[DataContract]
		public class L5RS_GRSPfT_1636 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL5_APOLogistic_ReturnShipment.Atomic.Retrieval.L5RS_RSP_1552 Position { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RS_GRSPfT_1636_Array cls_Get_ReturnShipmentPositions_for_TenantID(,P_L5RS_GRSPfT_1636 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RS_GRSPfT_1636_Array invocationResult = cls_Get_ReturnShipmentPositions_for_TenantID.Invoke(connectionString,P_L5RS_GRSPfT_1636 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ReturnShipment.Complex.Retrieval.P_L5RS_GRSPfT_1636();
parameter.Header_ID = ...;
parameter.SearchParam = ...;

*/
