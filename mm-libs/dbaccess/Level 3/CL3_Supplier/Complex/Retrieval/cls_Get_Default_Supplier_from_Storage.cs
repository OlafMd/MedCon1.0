/* 
 * Generated on 22/7/2014 01:55:05
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL3_Warehouse.Atomic.Retrieval;
using CL1_LOG_WRH;

namespace CL3_Supplier.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Default_Supplier_from_Storage.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Default_Supplier_from_Storage
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3SP_GDSfS_1347 Execute(DbConnection Connection,DbTransaction Transaction,P_L3SP_GDSfS_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3SP_GDSfS_1347();
			//Put your code here
            bool proceed = true;
            string name = string.Empty;
            Guid id = Guid.Empty;

            if (Parameter.RackID != Guid.Empty)
            {
                P_L3WH_GDSNfR_1749 paramRack = new P_L3WH_GDSNfR_1749();
                paramRack.RackID = Parameter.RackID;

                var rackSupplier = cls_Get_Default_SupplierName_for_Rack.Invoke(Connection, Transaction, paramRack, securityTicket).Result.ToArray();

                foreach (var item in rackSupplier)
                {
                    if (item.RackSupplierName != String.Empty)
                    {
                        name = item.RackSupplierName;
                        id = item.CMN_BPT_Supplier_RefID;
                        proceed = false;
                        break;
                    }
                }
            }

            if (proceed && Parameter.AreaID != Guid.Empty)
            {
                P_L3WH_GDSNfA_1741 paramArea = new P_L3WH_GDSNfA_1741();
                paramArea.AreaID = Parameter.AreaID;

                var areaSupplier = cls_Get_Default_SupplierName_for_Area.Invoke(Connection, Transaction, paramArea, securityTicket).Result.ToArray();

                foreach (var item in areaSupplier)
                {
                    if (item.AreaSupplierName != String.Empty)
                    {
                        name = item.AreaSupplierName;
                        id = item.CMN_BPT_Supplier_RefID;
                        proceed = false;
                        break;
                    }
                }
            }

            if (proceed && Parameter.WarehouseID != Guid.Empty)
            {
                P_L3WH_GDSNfW_1618 paramWarehouse = new P_L3WH_GDSNfW_1618();
                paramWarehouse.WarehouseID = Parameter.WarehouseID;

                var warehouseSupplier = cls_Get_Default_SupplierName_for_Warehouse.Invoke(Connection, Transaction, paramWarehouse, securityTicket).Result.ToArray();

                foreach (var item in warehouseSupplier)
                {
                    if (item.WarehouseSupplierName != String.Empty)
                    {
                        name = item.WarehouseSupplierName;
                        id = item.CMN_BPT_Supplier_RefID;
                        proceed = false;
                        break;
                    }
                }
            }

            if (proceed && Parameter.WarehouseID != Guid.Empty)
            {
                var warehouseGroups = ORM_LOG_WRH_Warehouse_2_WarehouseGroup.Query.Search(Connection, Transaction,
                new ORM_LOG_WRH_Warehouse_2_WarehouseGroup.Query
                {
                    LOG_WRH_Warehouse_RefID = Parameter.WarehouseID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });


                foreach (var currentWarehousegroup in warehouseGroups)
                {
                    if (proceed)
                    {
                        P_L5WH_GDSNfWG_0949 paramWarehouseGroup = new P_L5WH_GDSNfWG_0949();
                        paramWarehouseGroup.WarehouseGroupID = currentWarehousegroup.LOG_WRH_Warehouse_Group_RefID;

                        var warehouseGroupSupplier = cls_Get_Default_SupplierName_for_WarehouseGroup.Invoke(Connection, Transaction, paramWarehouseGroup, securityTicket).Result.ToArray();

                        foreach (var item in warehouseGroupSupplier)
                        {
                            if (item.WarehouseGroupSupplierName != String.Empty)
                            {
                                name = item.WarehouseGroupSupplierName;
                                id = item.CMN_BPT_Supplier_RefID;
                                proceed = false;
                                break;
                            }
                        }
                    }
                }
            }

            L3SP_GDSfS_1347 resultItem = new L3SP_GDSfS_1347();
            resultItem.SupplierName = name;
            resultItem.SupplierID = id;

            returnValue.Result = resultItem;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3SP_GDSfS_1347 Invoke(string ConnectionString,P_L3SP_GDSfS_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3SP_GDSfS_1347 Invoke(DbConnection Connection,P_L3SP_GDSfS_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3SP_GDSfS_1347 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SP_GDSfS_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3SP_GDSfS_1347 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SP_GDSfS_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3SP_GDSfS_1347 functionReturn = new FR_L3SP_GDSfS_1347();
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

				throw new Exception("Exception occured in method cls_Get_Default_Supplier_from_Storage",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3SP_GDSfS_1347 : FR_Base
	{
		public L3SP_GDSfS_1347 Result	{ get; set; }

		public FR_L3SP_GDSfS_1347() : base() {}

		public FR_L3SP_GDSfS_1347(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3SP_GDSfS_1347 for attribute P_L3SP_GDSfS_1347
		[DataContract]
		public class P_L3SP_GDSfS_1347 
		{
			//Standard type parameters
			[DataMember]
			public Guid RackID { get; set; } 
			[DataMember]
			public Guid AreaID { get; set; } 
			[DataMember]
			public Guid WarehouseID { get; set; } 
			[DataMember]
			public Guid WarehouseGroupID { get; set; } 

		}
		#endregion
		#region SClass L3SP_GDSfS_1347 for attribute L3SP_GDSfS_1347
		[DataContract]
		public class L3SP_GDSfS_1347 
		{
			//Standard type parameters
			[DataMember]
			public string SupplierName { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3SP_GDSfS_1347 cls_Get_Default_Supplier_from_Storage(,P_L3SP_GDSfS_1347 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3SP_GDSfS_1347 invocationResult = cls_Get_Default_Supplier_from_Storage.Invoke(connectionString,P_L3SP_GDSfS_1347 Parameter,securityTicket);
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
var parameter = new CL3_Supplier.Complex.Retrieval.P_L3SP_GDSfS_1347();
parameter.RackID = ...;
parameter.AreaID = ...;
parameter.WarehouseID = ...;
parameter.WarehouseGroupID = ...;

*/
