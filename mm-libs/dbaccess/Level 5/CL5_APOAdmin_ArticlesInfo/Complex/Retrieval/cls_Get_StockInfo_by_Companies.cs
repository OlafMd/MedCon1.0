/* 
 * Generated on 5/23/2014 2:30:17 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL3_Warehouse.Atomic.Retrieval;

namespace CL5_APOAdmin_ArticlesInfo.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StockInfo_by_Companies.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StockInfo_by_Companies
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AI_GSIbC_1341_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AI_GSIbC_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5AI_GSIbC_1341_Array();

            var productIds = new List<Guid>();
            productIds.Add(Parameter.ProductID);
            //var param = new P_L3WH_GSPfT_1107
            //{
            //    ProductIDs = productIds.ToArray()
            //};
            //var p = cls_Get_StoragePlaces_for_TenantID.Invoke(Connection, Transaction, param, securityTicket).Result;
            var filterCriteria = new P_L3WH_GSPfFC_1504()
            {
                WarehouseGroupID = null,
                WarehouseID = null,
                AreaID = null,
                RackID = null,
                UseShelfIDList = false,
                ShelfIDs = new Guid[] { Guid.Empty },
                UseProductIDList = productIds.Count > 0,
                ProductIDs = productIds.ToArray(),
                BottomShelfQuantity = null,
                TopShelfQuantity = null,
                UseProductTrackingInstanceIDList = false,
                ProductTrackingInstanceIDs = new Guid[] { Guid.Empty },
                StartExpirationDate = null,
                EndExpirationDate = null
            };
            var p = cls_Get_StoragePlaces_for_FilterCriteria.Invoke(
                Connection,
                Transaction,
                filterCriteria,
                securityTicket).Result;

            var list = new List<L5AI_GSIbC_1341>();

            var item = new L5AI_GSIbC_1341();

            item.CompanyID = Guid.NewGuid();
            item.CompanyName = "-";
            item.CurrentQuantityOnStock = 0;
            item.AMO = "-";

            list.Add(item);

            returnValue.Result = list.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AI_GSIbC_1341_Array Invoke(string ConnectionString,P_L5AI_GSIbC_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AI_GSIbC_1341_Array Invoke(DbConnection Connection,P_L5AI_GSIbC_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AI_GSIbC_1341_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AI_GSIbC_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AI_GSIbC_1341_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AI_GSIbC_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AI_GSIbC_1341_Array functionReturn = new FR_L5AI_GSIbC_1341_Array();
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

				throw new Exception("Exception occured in method cls_Get_StockInfo_by_Companies",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AI_GSIbC_1341_Array : FR_Base
	{
		public L5AI_GSIbC_1341[] Result	{ get; set; } 
		public FR_L5AI_GSIbC_1341_Array() : base() {}

		public FR_L5AI_GSIbC_1341_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AI_GSIbC_1341 for attribute P_L5AI_GSIbC_1341
		[DataContract]
		public class P_L5AI_GSIbC_1341 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5AI_GSIbC_1341 for attribute L5AI_GSIbC_1341
		[DataContract]
		public class L5AI_GSIbC_1341 
		{
			//Standard type parameters
			[DataMember]
			public Guid CompanyID { get; set; } 
			[DataMember]
			public String CompanyName { get; set; } 
			[DataMember]
			public Double CurrentQuantityOnStock { get; set; } 
			[DataMember]
			public String AMO { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AI_GSIbC_1341_Array cls_Get_StockInfo_by_Companies(,P_L5AI_GSIbC_1341 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AI_GSIbC_1341_Array invocationResult = cls_Get_StockInfo_by_Companies.Invoke(connectionString,P_L5AI_GSIbC_1341 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_ArticlesInfo.Complex.Retrieval.P_L5AI_GSIbC_1341();
parameter.ProductID = ...;

*/
