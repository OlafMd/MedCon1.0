/* 
 * Generated on 5/16/2014 10:53:13 AM
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

namespace CL6_Backoffice_ShipmentsOverview.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShipmentPositions_with_Article_for_ShipmentHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShipmentPositions_with_Article_for_ShipmentHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CL6_GSPwAfSH_1049_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CL6_GSPwAfSH_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
            var returnValue = new FR_CL6_GSPwAfSH_1049_Array();

            #region Get Return Shipment Positions
            var positionsResult = cls_Get_ShipmentPositions_for_ShipmentHeaderID
                .Invoke(Connection, Transaction, new P_CL3_GSPfSH_1047() { ShipmentHeaderID = Parameter.ShipmentHeaderID }, securityTicket);
            if (positionsResult.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Get Articles
            var paramArticles = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfAL_0942();
            paramArticles.ProductID_List = positionsResult.Result.Select(x => x.CMN_PRO_Product_RefID).ToArray<Guid>();

            var articles = new CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942[0];

            if (paramArticles.ProductID_List.Length != 0)
            {
                articles = CL3_Articles.Atomic.Retrieval.cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, paramArticles, securityTicket).Result;
            }
            #endregion



            var lsrResult = new List<CL6_GSPwAfSH_1049>();
            foreach (var position in positionsResult.Result)
            {
                var retObj = new CL6_GSPwAfSH_1049()
                {
                    ShipmentPosition = position,
                    Article = articles.SingleOrDefault(x => x.CMN_PRO_ProductID == position.CMN_PRO_Product_RefID)
                };
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
		public static FR_CL6_GSPwAfSH_1049_Array Invoke(string ConnectionString,P_CL6_GSPwAfSH_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CL6_GSPwAfSH_1049_Array Invoke(DbConnection Connection,P_CL6_GSPwAfSH_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CL6_GSPwAfSH_1049_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CL6_GSPwAfSH_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CL6_GSPwAfSH_1049_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CL6_GSPwAfSH_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CL6_GSPwAfSH_1049_Array functionReturn = new FR_CL6_GSPwAfSH_1049_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShipmentPositions_with_Article_for_ShipmentHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CL6_GSPwAfSH_1049_Array : FR_Base
	{
		public CL6_GSPwAfSH_1049[] Result	{ get; set; } 
		public FR_CL6_GSPwAfSH_1049_Array() : base() {}

		public FR_CL6_GSPwAfSH_1049_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CL6_GSPwAfSH_1049 for attribute P_CL6_GSPwAfSH_1049
		[DataContract]
		public class P_CL6_GSPwAfSH_1049 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass CL6_GSPwAfSH_1049 for attribute CL6_GSPwAfSH_1049
		[DataContract]
		public class CL6_GSPwAfSH_1049 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL3_CustomerOrder.Atomic.Retrieval.CL3_GSPfSH_1047 ShipmentPosition { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CL6_GSPwAfSH_1049_Array cls_Get_ShipmentPositions_with_Article_for_ShipmentHeaderID(,P_CL6_GSPwAfSH_1049 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CL6_GSPwAfSH_1049_Array invocationResult = cls_Get_ShipmentPositions_with_Article_for_ShipmentHeaderID.Invoke(connectionString,P_CL6_GSPwAfSH_1049 Parameter,securityTicket);
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
var parameter = new CL6_Backoffice_ShipmentsOverview.Complex.Retrieval.P_CL6_GSPwAfSH_1049();
parameter.ShipmentHeaderID = ...;

*/
