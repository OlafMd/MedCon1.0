/* 
 * Generated on 7/25/2014 11:14:59 AM
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

namespace CL6_APOLogistic_Inventory.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Data_for_CountingRuns_Page.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Data_for_CountingRuns_Page
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6IN_GDfCRP_0947_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6IN_GDfCRP_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L6IN_GDfCRP_0947_Array();
            var lsrResult = new List<L6IN_GDfCRP_0947>();

            var countingRun = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun.Query.Search(Connection, Transaction,
                new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun.Query
                {
                    LOG_WRH_INJ_InventoryJob_CountingRunID = Parameter.CountingRunID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

            #region Get Shelves
            var paramShelves = new CL5_APOLogistic_Inventory.Atomic.Retrieval.P_L5IN_GSCwQfIJP_1023();
            paramShelves.ProcessID = countingRun.InventoryJob_Process_RefID;
            var shelves = CL5_APOLogistic_Inventory.Atomic.Retrieval.cls_Get_ShelfContent_with_Quantity_for_InventoryJob_ProcessID.Invoke(Connection, Transaction, paramShelves, securityTicket).Result;

            // filter by difference found on first counting run
            if (countingRun.SequenceNumber == 2)
            {
                var firstCountingRun = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun.Query.Search(Connection, Transaction,
                    new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun.Query
                {
                    InventoryJob_Process_RefID = countingRun.InventoryJob_Process_RefID,
                    SequenceNumber = 1,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

                var crParameter = new CL5_APOLogistic_Inventory.Atomic.Retrieval.P_L5IN_GRfCR_1143
                {
                    CountingRunID = firstCountingRun.LOG_WRH_INJ_InventoryJob_CountingRunID,
                    OnlyIf_IsDifferenceFound = true
                };

                var firstCountingRunResults = CL5_APOLogistic_Inventory.Atomic.Retrieval.cls_Get_Results_for_CountingRun.Invoke(Connection, Transaction, crParameter, securityTicket).Result;

                var diffTrackingInstanceIDs = firstCountingRunResults.Select(x => x.LOG_ProductTrackingInstance_RefID);
                var diffShelfContentIDs = firstCountingRunResults.Select(x => x.LOG_WRH_Shelf_Content_RefID);

                var shelfContentIDs = shelves.Select(x => x.LOG_WRH_Shelf_ContentID);
                var shelfTrackingInstances = shelves.Select(x => x.LOG_ProductTrackingInstanceID);

                var intersectionTrackingInstances = shelfTrackingInstances.Intersect(diffTrackingInstanceIDs);
                var intersectionShelfContents = shelfContentIDs.Intersect(diffShelfContentIDs);

                shelves = shelves.Where(x =>
                     (x.LOG_ProductTrackingInstanceID == Guid.Empty && intersectionShelfContents.Contains(x.LOG_WRH_Shelf_ContentID)) ||
                     (x.LOG_ProductTrackingInstanceID != Guid.Empty && intersectionTrackingInstances.Contains(x.LOG_ProductTrackingInstanceID))
                     ).ToArray();
            }

            #endregion

            #region Get Articles
            var paramArticles = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfAL_0942();
            paramArticles.ProductID_List = shelves.Select(x => x.Product_RefID).ToArray<Guid>();
            var articles = new CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942[0];
            if (paramArticles.ProductID_List.Length != 0)
            {
                articles = CL3_Articles.Atomic.Retrieval.cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, paramArticles, securityTicket).Result;
            }
            
            #endregion

            #region Get Counting Results

            var parameterGetCountingResult = new CL5_APOLogistic_Inventory.Atomic.Retrieval.P_L5IN_GRfCR_1143
            {
                CountingRunID = Parameter.CountingRunID
            };
            var countingRunResults = CL5_APOLogistic_Inventory.Atomic.Retrieval.cls_Get_Results_for_CountingRun.Invoke(Connection, Transaction, parameterGetCountingResult, securityTicket).Result;
           
            //countingRunResults = countingRunResults.Where(x => x.LOG_ProductTrackingInstance_RefID != Guid.Empty).ToArray();


            #endregion

            foreach (var item in shelves)
            {
                var retObj = new L6IN_GDfCRP_0947();
                retObj.Shelf = item;
                retObj.Article = articles.SingleOrDefault(x => x.CMN_PRO_ProductID == item.Product_RefID);
                retObj.CountingResult = countingRunResults.Where(x =>
                    (x.LOG_ProductTrackingInstance_RefID == Guid.Empty 
                        && x.LOG_WRH_Shelf_Content_RefID == retObj.Shelf.LOG_WRH_Shelf_ContentID
                        && x.LOG_WRH_INJ_InventoryJob_CountingResultID != Guid.Empty
                    )
                    ||
                    (x.LOG_ProductTrackingInstance_RefID != Guid.Empty 
                        && x.LOG_ProductTrackingInstance_RefID == retObj.Shelf.LOG_ProductTrackingInstanceID
                        && x.LOG_WRH_INJ_CountingResult_TrackingInstanceID != Guid.Empty)
                    ).FirstOrDefault();

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
		public static FR_L6IN_GDfCRP_0947_Array Invoke(string ConnectionString,P_L6IN_GDfCRP_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6IN_GDfCRP_0947_Array Invoke(DbConnection Connection,P_L6IN_GDfCRP_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6IN_GDfCRP_0947_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6IN_GDfCRP_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6IN_GDfCRP_0947_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6IN_GDfCRP_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6IN_GDfCRP_0947_Array functionReturn = new FR_L6IN_GDfCRP_0947_Array();
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

				throw new Exception("Exception occured in method cls_Get_Data_for_CountingRuns_Page",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6IN_GDfCRP_0947_Array : FR_Base
	{
		public L6IN_GDfCRP_0947[] Result	{ get; set; } 
		public FR_L6IN_GDfCRP_0947_Array() : base() {}

		public FR_L6IN_GDfCRP_0947_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6IN_GDfCRP_0947 for attribute P_L6IN_GDfCRP_0947
		[DataContract]
		public class P_L6IN_GDfCRP_0947 
		{
			//Standard type parameters
			[DataMember]
			public Guid CountingRunID { get; set; } 

		}
		#endregion
		#region SClass L6IN_GDfCRP_0947 for attribute L6IN_GDfCRP_0947
		[DataContract]
		public class L6IN_GDfCRP_0947 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOLogistic_Inventory.Atomic.Retrieval.L5IN_GRfCR_1143 CountingResult { get; set; } 
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL5_APOLogistic_Inventory.Atomic.Retrieval.L5IN_GSCwQfIJP_1023 Shelf { get; set; } 
			[DataMember]
			public int CountingRunSequenceNumber { get; set; } 
			[DataMember]
			public bool isContinuousInventory { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6IN_GDfCRP_0947_Array cls_Get_Data_for_CountingRuns_Page(,P_L6IN_GDfCRP_0947 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6IN_GDfCRP_0947_Array invocationResult = cls_Get_Data_for_CountingRuns_Page.Invoke(connectionString,P_L6IN_GDfCRP_0947 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_Inventory.Complex.Retrieval.P_L6IN_GDfCRP_0947();
parameter.CountingRunID = ...;

*/
