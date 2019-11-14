/* 
 * Generated on 1/15/2015 11:05:07
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

namespace CL2_Warehouse.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Warehouse.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Warehouse
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2WH_SWH_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            var item = new CL1_LOG_WRH.ORM_LOG_WRH_Warehouse();
            var defaultSupplier = new CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_DefaultSupplier();
            if (Parameter.LOG_WRH_WarehouseID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.LOG_WRH_WarehouseID);
                defaultSupplier = CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_DefaultSupplier.Query.Search(Connection, Transaction,
                                new CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_DefaultSupplier.Query()
                                {
                                    Warehouse_RefID = item.LOG_WRH_WarehouseID,
                                    IsDeleted = false
                                }).SingleOrDefault();

                if (Parameter.Default_Supplier_RefID == Guid.Empty && defaultSupplier != null)
                {
                    defaultSupplier.IsDeleted = true;
                }
                else if (defaultSupplier == null)
                {
                    defaultSupplier = new CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_DefaultSupplier();
                }
            }

            // Add relationship ORM_LOG_WRH_Warehouse_2_WarehouseGroup if not exists 
            if (Parameter.LOG_WRH_WarehouseGroupID != Guid.Empty)
            {
                var warehouseGroup = CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_2_WarehouseGroup.Query.Search(Connection, Transaction,
                new CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_2_WarehouseGroup.Query
                {
                    IsDeleted = false,
                    LOG_WRH_Warehouse_Group_RefID = Parameter.LOG_WRH_WarehouseGroupID,
                    LOG_WRH_Warehouse_RefID = item.LOG_WRH_WarehouseID
                }).SingleOrDefault();

                if (warehouseGroup != null && Parameter.IsDeleted)
                {
                    warehouseGroup.IsDeleted = true;
                    warehouseGroup.Save(Connection, Transaction);
                }
                else if (warehouseGroup == null)
                {
                    warehouseGroup = new CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_2_WarehouseGroup();
                    warehouseGroup.LOG_WRH_Warehouse_Group_RefID = Parameter.LOG_WRH_WarehouseGroupID;
                    warehouseGroup.LOG_WRH_Warehouse_RefID = item.LOG_WRH_WarehouseID;
                    warehouseGroup.Tenant_RefID = securityTicket.TenantID;
                    warehouseGroup.Save(Connection, Transaction);
                }
            }

            if (Parameter.IsDeleted == true)
            {
                defaultSupplier.IsDeleted = true;
                defaultSupplier.Save(Connection, Transaction);

                // DELETE REFERENCES
                var areas = CL1_LOG_WRH.ORM_LOG_WRH_Area.Query.Search(Connection, Transaction,
                    new CL1_LOG_WRH.ORM_LOG_WRH_Area.Query { IsDeleted = false, Warehouse_RefID = Parameter.LOG_WRH_WarehouseID });
                foreach (var a in areas)
                {
                    var racks = CL1_LOG_WRH.ORM_LOG_WRH_Rack.Query.Search(Connection, Transaction,
                        new CL1_LOG_WRH.ORM_LOG_WRH_Rack.Query { IsDeleted = false, Area_RefID = a.LOG_WRH_AreaID });
                    foreach (var r in racks)
                    {
                        var shelves = CL1_LOG_WRH.ORM_LOG_WRH_Shelf.Query.Search(Connection, Transaction,
                            new CL1_LOG_WRH.ORM_LOG_WRH_Shelf.Query { IsDeleted = false, Rack_RefID = r.LOG_WRH_RackID });
                        foreach (var s in shelves)
                        {
                            s.IsDeleted = true;
                            s.Save(Connection, Transaction);
                        }
                        r.IsDeleted = true;
                        r.Save(Connection, Transaction);
                    }
                    a.IsDeleted = true;
                    a.Save(Connection, Transaction);
                }
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.LOG_WRH_WarehouseID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.LOG_WRH_WarehouseID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            defaultSupplier.Warehouse_RefID = item.LOG_WRH_WarehouseID;
            defaultSupplier.CMN_BPT_Supplier_RefID = Parameter.Default_Supplier_RefID;
            defaultSupplier.Tenant_RefID = item.Tenant_RefID;
            defaultSupplier.Save(Connection, Transaction);

            item.CoordinateCode = Parameter.CoordinateCode;
            item.Warehouse_Name = Parameter.Warehouse_Name;
            item.DeliveryAddress_RefID = Parameter.DeliveryAddress_RefID;
            item.BoundTo_EconomicRegion_RefID = Parameter.BoundTo_EconomicRegion_RefID;
            item.IsStructureHidden = Parameter.IsStructureHidden;
            item.IsConsignmentWarehouse = Parameter.IsConsignmentWarehouse;
            item.IfConsignmentWarehouse_DefaultOwningSupplier_RefID = Parameter.IfConsignmentWarehouse_DefaultOwningSupplier_RefID;
            item.IsDefaultShipmentWarehouse = Parameter.IsDefaultShipmentWarehouse;
            //item.Default_Supplier_RefID = Parameter.Default_Supplier_RefID;

            return new FR_Guid(item.Save(Connection, Transaction), item.LOG_WRH_WarehouseID);
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2WH_SWH_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2WH_SWH_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2WH_SWH_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2WH_SWH_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_Warehouse",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2WH_SWH_1339 for attribute P_L2WH_SWH_1339
		[DataContract]
		public class P_L2WH_SWH_1339 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_WarehouseID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_WarehouseGroupID { get; set; } 
			[DataMember]
			public String CoordinateCode { get; set; } 
			[DataMember]
			public String Warehouse_Name { get; set; } 
			[DataMember]
			public Guid DeliveryAddress_RefID { get; set; } 
			[DataMember]
			public Guid BoundTo_EconomicRegion_RefID { get; set; } 
			[DataMember]
			public Boolean IsStructureHidden { get; set; } 
			[DataMember]
			public Boolean IsConsignmentWarehouse { get; set; } 
			[DataMember]
			public Guid IfConsignmentWarehouse_DefaultOwningSupplier_RefID { get; set; } 
			[DataMember]
			public Guid Default_Supplier_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public bool IsDefaultShipmentWarehouse { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Warehouse(,P_L2WH_SWH_1339 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Warehouse.Invoke(connectionString,P_L2WH_SWH_1339 Parameter,securityTicket);
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
var parameter = new CL2_Warehouse.Complex.Manipulation.P_L2WH_SWH_1339();
parameter.LOG_WRH_WarehouseID = ...;
parameter.LOG_WRH_WarehouseGroupID = ...;
parameter.CoordinateCode = ...;
parameter.Warehouse_Name = ...;
parameter.DeliveryAddress_RefID = ...;
parameter.BoundTo_EconomicRegion_RefID = ...;
parameter.IsStructureHidden = ...;
parameter.IsConsignmentWarehouse = ...;
parameter.IfConsignmentWarehouse_DefaultOwningSupplier_RefID = ...;
parameter.Default_Supplier_RefID = ...;
parameter.IsDeleted = ...;
parameter.IsDefaultShipmentWarehouse = ...;

*/
