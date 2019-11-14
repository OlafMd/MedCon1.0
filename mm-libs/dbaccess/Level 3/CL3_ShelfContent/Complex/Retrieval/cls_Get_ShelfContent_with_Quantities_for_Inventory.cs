/* 
 * Generated on 3/12/2015 11:54:40
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
using CL3_ShelfContent.Atomic.Retrieval;
using CL3_Warehouse.Atomic.Retrieval;

namespace CL3_ShelfContent.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShelfContent_with_Quantities_for_Inventory.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShelfContent_with_Quantities_for_Inventory
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3SC_GSCwQfI_1731_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3SC_GSCwQfI_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3SC_GSCwQfI_1731_Array();
			//Put your code here
            List<L3SC_GSCwQfI_1731> resultData = new List<L3SC_GSCwQfI_1731>();

            if (Parameter.ShelfIDList != null && Parameter.ShelfIDList.Count() > 0)
            {               
                var basicData = cls_Get_ShelfContentInventarData.Invoke(Connection, Transaction, new P_L3SC_GSCID_1711() { ShelfIDList = Parameter.ShelfIDList }, securityTicket).Result;

                if (basicData != null && basicData.Count() > 0)
                {


                    var quantities = cls_Get_StockQuantity_Current_and_Free_for_ShelfContentIDList.Invoke(Connection, Transaction, new P_L3SC_GSQCaFfSC_1707() { ShelfContentIDList = basicData.Select(x => x.LOG_WRH_Shelf_ContentID).ToArray() }, securityTicket).Result;
                    var shelfPaths = cls_Get_ShelfPath_for_ShelfIDList.Invoke(Connection, Transaction, new P_L3WH_GSPfSL_1443() { ShelfIDs = Parameter.ShelfIDList }, securityTicket).Result;

                    foreach (var row in basicData)
                    {
                        L3SC_GSCwQfI_1731 stockItem = new L3SC_GSCwQfI_1731();
                        stockItem.ProductAndVariantData = row;
                        stockItem.StockQuantities = quantities.SingleOrDefault(x => x.LOG_WRH_Shelf_ContentID == row.LOG_WRH_Shelf_ContentID);

                        var path = shelfPaths.SingleOrDefault(x => x.LOG_WRH_ShelfID == row.Shelf_RefID);
                        if (path != null)
                        {
                            stockItem.StockUnitPath = String.Format("{0}-{1}-{2}-{3}", path.WarehouseCode, path.AreaCode, path.RackCode, path.ShelfCode);
                        }

                        resultData.Add(stockItem);
                    }

                }
            }
            returnValue.Result = resultData.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3SC_GSCwQfI_1731_Array Invoke(string ConnectionString,P_L3SC_GSCwQfI_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3SC_GSCwQfI_1731_Array Invoke(DbConnection Connection,P_L3SC_GSCwQfI_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3SC_GSCwQfI_1731_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SC_GSCwQfI_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3SC_GSCwQfI_1731_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SC_GSCwQfI_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3SC_GSCwQfI_1731_Array functionReturn = new FR_L3SC_GSCwQfI_1731_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShelfContent_with_Quantities_for_Inventory",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3SC_GSCwQfI_1731_Array : FR_Base
	{
		public L3SC_GSCwQfI_1731[] Result	{ get; set; } 
		public FR_L3SC_GSCwQfI_1731_Array() : base() {}

		public FR_L3SC_GSCwQfI_1731_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3SC_GSCwQfI_1731 for attribute P_L3SC_GSCwQfI_1731
		[DataContract]
		public class P_L3SC_GSCwQfI_1731 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ShelfIDList { get; set; } 

		}
		#endregion
		#region SClass L3SC_GSCwQfI_1731 for attribute L3SC_GSCwQfI_1731
		[DataContract]
		public class L3SC_GSCwQfI_1731 
		{
			//Standard type parameters
			[DataMember]
			public string StockUnitPath { get; set; } 
			[DataMember]
			public CL3_ShelfContent.Atomic.Retrieval.L3SC_GSCID_1711 ProductAndVariantData { get; set; } 
			[DataMember]
			public CL3_ShelfContent.Atomic.Retrieval.L3SC_GSQCaFfSC_1707 StockQuantities { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3SC_GSCwQfI_1731_Array cls_Get_ShelfContent_with_Quantities_for_Inventory(,P_L3SC_GSCwQfI_1731 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3SC_GSCwQfI_1731_Array invocationResult = cls_Get_ShelfContent_with_Quantities_for_Inventory.Invoke(connectionString,P_L3SC_GSCwQfI_1731 Parameter,securityTicket);
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
var parameter = new CL3_ShelfContent.Complex.Retrieval.P_L3SC_GSCwQfI_1731();
parameter.ShelfIDList = ...;

*/
