/* 
 * Generated on 9/8/2014 9:58:24 AM
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
using CL3_Warehouse.Atomic.Retrieval;
using CL5_APOLogistic_Inventory.Atomic.Retrieval;

namespace CL5_APOLogistic_Inventory.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StoragePlaces_for_InvetoryJob.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StoragePlaces_for_InvetoryJob
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5IN_GSPfIJ_1641 Execute(DbConnection Connection,DbTransaction Transaction,P_L5IN_GSPfIJ_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5IN_GSPfIJ_1641();
            returnValue.Result = new L5IN_GSPfIJ_1641();

            var filterCriteria = new P_L3WH_GSPfFC_1504()
            {
                WarehouseGroupID = Parameter.Warehouse_GroupID,
                WarehouseID = Parameter.WarehouseID,
                AreaID = Parameter.AreaID,
                RackID = Parameter.RackID,
                UseShelfIDList = Parameter.UseShelfList,
                ShelfIDs = Parameter.UseShelfList ? Parameter.ShelfID_List : new Guid[] { Guid.Empty },
                UseProductIDList = false,
                ProductIDs = new Guid[] { Guid.Empty },
                BottomShelfQuantity = (int?)Parameter.QuantityBottom,
                TopShelfQuantity = (int?)Parameter.QuantityTop,
                UseProductTrackingInstanceIDList = false,
                ProductTrackingInstanceIDs = new Guid[] { Guid.Empty },
                StartExpirationDate = null,
                EndExpirationDate = null
            };
            if (Parameter.ShelfID != null && Parameter.UseShelfList)
            {
                filterCriteria.ShelfIDs.Concat(new Guid[] { new Guid(Parameter.ShelfID.ToString()) });
            }
            var storagePlaces = cls_Get_StoragePlaces_for_FilterCriteria.Invoke(
                Connection,
                Transaction,
                filterCriteria,
                securityTicket).Result;

            if (Parameter.InventoryJobID != null)
            {
                var paramShelfsInvetoryJob = new P_L5IN_GSfIJ_1053();
                paramShelfsInvetoryJob.InventoryJobID = Parameter.InventoryJobID == null ? Guid.Empty : (Guid)Parameter.InventoryJobID;
                var usedSelfs = cls_Get_Shelfs_for_InvetoryJob.Invoke(Connection, Transaction, paramShelfsInvetoryJob, securityTicket).Result;
                returnValue.Result.StoragePlace = storagePlaces.Where(x => !usedSelfs.Select(y => y.LOG_WRH_Shelf_RefID).Contains(x.LOG_WRH_ShelfID)).ToArray();
            }
            else
            {
                returnValue.Result.StoragePlace = storagePlaces;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5IN_GSPfIJ_1641 Invoke(string ConnectionString,P_L5IN_GSPfIJ_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5IN_GSPfIJ_1641 Invoke(DbConnection Connection,P_L5IN_GSPfIJ_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5IN_GSPfIJ_1641 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IN_GSPfIJ_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5IN_GSPfIJ_1641 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IN_GSPfIJ_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5IN_GSPfIJ_1641 functionReturn = new FR_L5IN_GSPfIJ_1641();
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

				throw new Exception("Exception occured in method cls_Get_StoragePlaces_for_InvetoryJob",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5IN_GSPfIJ_1641 : FR_Base
	{
		public L5IN_GSPfIJ_1641 Result	{ get; set; }

		public FR_L5IN_GSPfIJ_1641() : base() {}

		public FR_L5IN_GSPfIJ_1641(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5IN_GSPfIJ_1641 for attribute P_L5IN_GSPfIJ_1641
		[DataContract]
		public class P_L5IN_GSPfIJ_1641 
		{
			//Standard type parameters
			[DataMember]
			public Guid? Warehouse_GroupID { get; set; } 
			[DataMember]
			public Guid? WarehouseID { get; set; } 
			[DataMember]
			public Guid? AreaID { get; set; } 
			[DataMember]
			public Guid? RackID { get; set; } 
			[DataMember]
			public Guid? ShelfID { get; set; } 
			[DataMember]
			public bool UseShelfList { get; set; } 
			[DataMember]
			public Guid[] ShelfID_List { get; set; } 
			[DataMember]
			public float? QuantityTop { get; set; } 
			[DataMember]
			public float? QuantityBottom { get; set; } 
			[DataMember]
			public Guid? InventoryJobID { get; set; } 

		}
		#endregion
		#region SClass L5IN_GSPfIJ_1641 for attribute L5IN_GSPfIJ_1641
		[DataContract]
		public class L5IN_GSPfIJ_1641 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Warehouse.Atomic.Retrieval.L3WH_GSPfFC_1504[] StoragePlace { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5IN_GSPfIJ_1641 cls_Get_StoragePlaces_for_InvetoryJob(,P_L5IN_GSPfIJ_1641 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5IN_GSPfIJ_1641 invocationResult = cls_Get_StoragePlaces_for_InvetoryJob.Invoke(connectionString,P_L5IN_GSPfIJ_1641 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Complex.Retrieval.P_L5IN_GSPfIJ_1641();
parameter.Warehouse_GroupID = ...;
parameter.WarehouseID = ...;
parameter.AreaID = ...;
parameter.RackID = ...;
parameter.ShelfID = ...;
parameter.UseShelfList = ...;
parameter.ShelfID_List = ...;
parameter.QuantityTop = ...;
parameter.QuantityBottom = ...;
parameter.InventoryJobID = ...;

*/
