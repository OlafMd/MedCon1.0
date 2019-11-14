/* 
 * Generated on 3/16/2015 03:56:17
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
using CL1_LOG_WRH;
using CL3_Warehouse.Atomic.Retrieval;

namespace CL3_ShelfContent.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShelfPaths_for_Product_and_ShelfIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShelfPaths_for_Product_and_ShelfIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SC_GSPfPaSIDs_1539_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SC_GSPfPaSIDs_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5SC_GSPfPaSIDs_1539_Array();
			//Put your code here

            //This method will return a paths of shelves from Parameter, but only those for which shelf content for given product doesn't already exist
            if (Parameter.ShelfIDList.Count() > 0)
            {
                var shelvesData = cls_Get_ShelfPath_for_ShelfIDList.Invoke(Connection, Transaction, new P_L3WH_GSPfSL_1443() {ShelfIDs = Parameter.ShelfIDList}, securityTicket).Result.ToList();

                List<L5SC_GSPfPaSIDs_1539> resultList = new List<L5SC_GSPfPaSIDs_1539>();

                foreach (var shelfID in Parameter.ShelfIDList)
                {
                    //var shelfContendExist = ORM_LOG_WRH_Shelf_Content.Query.Exists(Connection, Transaction, new ORM_LOG_WRH_Shelf_Content.Query() { Product_RefID = Parameter.ProductID, Shelf_RefID = shelfID, Tenant_RefID=securityTicket.TenantID, IsDeleted=false });

                    ORM_LOG_WRH_Shelf_Content.Query shelfContentQuery = new ORM_LOG_WRH_Shelf_Content.Query()
                    {
                        Product_RefID = Parameter.ProductID,
                        Shelf_RefID = shelfID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    };
                    var shelfContents = ORM_LOG_WRH_Shelf_Content.Query.Search(Connection, Transaction, shelfContentQuery); 

                    if (shelfContents == null || shelfContents.Where(x => x.Quantity_Current != 0).ToList().Count() == 0)
                    {
                        var shelfData = shelvesData.SingleOrDefault(x => x.LOG_WRH_ShelfID == shelfID);

                        L5SC_GSPfPaSIDs_1539 resultItem = new L5SC_GSPfPaSIDs_1539();
                        resultItem.ShelfID = shelfID;
                        resultItem.Path = String.Format("{0}-{1}-{2}-{3}", shelfData.WarehouseCode, shelfData.AreaCode, shelfData.RackCode, shelfData.ShelfCode);

                        resultList.Add(resultItem);
                    }
                }
                returnValue.Result = resultList.ToArray();
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SC_GSPfPaSIDs_1539_Array Invoke(string ConnectionString,P_L5SC_GSPfPaSIDs_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SC_GSPfPaSIDs_1539_Array Invoke(DbConnection Connection,P_L5SC_GSPfPaSIDs_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SC_GSPfPaSIDs_1539_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SC_GSPfPaSIDs_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SC_GSPfPaSIDs_1539_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SC_GSPfPaSIDs_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SC_GSPfPaSIDs_1539_Array functionReturn = new FR_L5SC_GSPfPaSIDs_1539_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShelfPaths_for_Product_and_ShelfIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SC_GSPfPaSIDs_1539_Array : FR_Base
	{
		public L5SC_GSPfPaSIDs_1539[] Result	{ get; set; } 
		public FR_L5SC_GSPfPaSIDs_1539_Array() : base() {}

		public FR_L5SC_GSPfPaSIDs_1539_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SC_GSPfPaSIDs_1539 for attribute P_L5SC_GSPfPaSIDs_1539
		[DataContract]
		public class P_L5SC_GSPfPaSIDs_1539 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ShelfIDList { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5SC_GSPfPaSIDs_1539 for attribute L5SC_GSPfPaSIDs_1539
		[DataContract]
		public class L5SC_GSPfPaSIDs_1539 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShelfID { get; set; } 
			[DataMember]
			public string Path { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SC_GSPfPaSIDs_1539_Array cls_Get_ShelfPaths_for_Product_and_ShelfIDs(,P_L5SC_GSPfPaSIDs_1539 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SC_GSPfPaSIDs_1539_Array invocationResult = cls_Get_ShelfPaths_for_Product_and_ShelfIDs.Invoke(connectionString,P_L5SC_GSPfPaSIDs_1539 Parameter,securityTicket);
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
var parameter = new CL3_ShelfContent.Complex.Retrieval.P_L5SC_GSPfPaSIDs_1539();
parameter.ShelfIDList = ...;
parameter.ProductID = ...;

*/
