/* 
 * Generated on 8/5/2014 10:30:04 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using CL3_Warehouse.Atomic.Retrieval;
using CSV2Core.Core;

namespace CL3_Warehouse.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ArticleStorages_for_ArticleIDListComplex.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ArticleStorages_for_ArticleIDListComplex
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GAwSPfT_1002_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GAwSPfT_1002 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3PR_GAwSPfT_1002_Array();

			//Put your code here
            List<L3PR_GAwSPfT_1002> retVal = new List<L3PR_GAwSPfT_1002>();

            P_L3WH_GASfA_1924 par = new P_L3WH_GASfA_1924();
            par.ArticleID_List = Parameter.ArticleID_List.Select(i=>i).ToArray();
            var articleStorages = cls_Get_ArticleStorages_for_ArticleIDList.Invoke(Connection, Transaction, par, securityTicket).Result.Where(i => i.ShelfID != Guid.Empty).ToList();
            
            #region Get All StoragePlaces for TenantID

            var shelfIDs = articleStorages.Select(i => i.ShelfID).Distinct().ToArray();
            var productIDs = articleStorages.Select(i => i.ArticleID).Distinct().ToArray();
            var filterCriteria = new P_L3WH_GSPfFC_1504()
            {
                WarehouseGroupID = null,
                WarehouseID = null,
                AreaID = null,
                RackID = null,
                UseShelfIDList = shelfIDs.Length != 0,
                ShelfIDs = shelfIDs.Length == 0 ? new Guid[] { Guid.Empty } : shelfIDs,
                UseProductIDList = productIDs.Length != 0,
                ProductIDs = productIDs.Length == 0 ? new Guid[] { Guid.Empty } : productIDs,
                BottomShelfQuantity = null,
                TopShelfQuantity = null,
                UseProductTrackingInstanceIDList = false,
                ProductTrackingInstanceIDs = new Guid[] { Guid.Empty },
                StartExpirationDate = null,
                EndExpirationDate = null
            };
            var allStoragePlacesForTenant = cls_Get_StoragePlaces_for_FilterCriteria.Invoke(Connection, Transaction, filterCriteria, securityTicket).Result;
            #endregion

            L3PR_GAwSPfT_1002 retValItem;
            L3WH_GSPfFC_1504 storagePlace;
            foreach (var storage in articleStorages)
            {
                retValItem = new L3PR_GAwSPfT_1002();
                retValItem.ArticleID = storage.ArticleID;
                retValItem.ShelfID = storage.ShelfID;
                retValItem.StoragePlace = "-";

                storagePlace = allStoragePlacesForTenant.Where(i => i.LOG_WRH_ShelfID == storage.ShelfID).FirstOrDefault();
                if (storagePlace != null && !String.IsNullOrEmpty(storagePlace.Area_Name)
                && !String.IsNullOrEmpty(storagePlace.Rack_Name)
                && !String.IsNullOrEmpty(storagePlace.Shelf_Name))
                    retValItem.StoragePlace = String.Format("{0}-{1}-{2}-{3}",
                        storagePlace.WarehouseCoordinateCode,
                        storagePlace.AreaCoordinateCode,
                        storagePlace.RackCoordinateCode,
                        storagePlace.ShelfCoordinateCode);

                retVal.Add(retValItem);
            }

            returnValue.Result = retVal.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PR_GAwSPfT_1002_Array Invoke(string ConnectionString,P_L3PR_GAwSPfT_1002 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GAwSPfT_1002_Array Invoke(DbConnection Connection,P_L3PR_GAwSPfT_1002 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GAwSPfT_1002_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GAwSPfT_1002 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GAwSPfT_1002_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GAwSPfT_1002 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GAwSPfT_1002_Array functionReturn = new FR_L3PR_GAwSPfT_1002_Array();
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

				throw new Exception("Exception occured in method cls_Get_ArticleStorages_for_ArticleIDListComplex",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GAwSPfT_1002_Array : FR_Base
	{
		public L3PR_GAwSPfT_1002[] Result	{ get; set; } 
		public FR_L3PR_GAwSPfT_1002_Array() : base() {}

		public FR_L3PR_GAwSPfT_1002_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GAwSPfT_1002 for attribute P_L3PR_GAwSPfT_1002
		[DataContract]
		public class P_L3PR_GAwSPfT_1002 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ArticleID_List { get; set; } 

		}
		#endregion
		#region SClass L3PR_GAwSPfT_1002 for attribute L3PR_GAwSPfT_1002
		[DataContract]
		public class L3PR_GAwSPfT_1002 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 
			[DataMember]
			public Guid ShelfID { get; set; } 
			[DataMember]
			public string StoragePlace { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GAwSPfT_1002_Array cls_Get_ArticleStorages_for_ArticleIDListComplex(,P_L3PR_GAwSPfT_1002 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GAwSPfT_1002_Array invocationResult = cls_Get_ArticleStorages_for_ArticleIDListComplex.Invoke(connectionString,P_L3PR_GAwSPfT_1002 Parameter,securityTicket);
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
var parameter = new CL3_Warehouse.Complex.Retrieval.P_L3PR_GAwSPfT_1002();
parameter.ArticleID_List = ...;

*/
