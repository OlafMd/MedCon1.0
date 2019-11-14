/* 
 * Generated on 7/11/2013 09:35:23
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL2_Warehouse.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Warehouse_Group.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Warehouse_Group
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2WH_SWHG_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            var item = new CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_Group();
            var defaultSupplier = new CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_Group_DefaultSupplier();
            if (Parameter.LOG_WRH_Warehouse_GroupID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.LOG_WRH_Warehouse_GroupID);

               defaultSupplier = CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_Group_DefaultSupplier.Query.Search(Connection, Transaction,
                new CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_Group_DefaultSupplier.Query()
                {
                    Warehouse_Group_RefID = item.LOG_WRH_Warehouse_GroupID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (Parameter.Default_Supplier_RefID == Guid.Empty && defaultSupplier != null)
                {
                    defaultSupplier.IsDeleted = true;
                }
                else if (defaultSupplier == null)
                {
                    defaultSupplier = new CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_Group_DefaultSupplier();
                }
            }

            if (Parameter.IsDeleted == true)
            {
                // DELETE REFERENCES
                defaultSupplier.IsDeleted = true;
                defaultSupplier.Save(Connection, Transaction);

                var warehouse_2_warehousegroup = CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_2_WarehouseGroup.Query.Search(Connection, Transaction,
                    new CL1_LOG_WRH.ORM_LOG_WRH_Warehouse_2_WarehouseGroup.Query { IsDeleted = false, LOG_WRH_Warehouse_Group_RefID = Parameter.LOG_WRH_Warehouse_GroupID });
                foreach (var warehouse2toGroup in warehouse_2_warehousegroup)
                {
                    var warehouses = CL1_LOG_WRH.ORM_LOG_WRH_Warehouse.Query.Search(Connection, Transaction,
                        new CL1_LOG_WRH.ORM_LOG_WRH_Warehouse.Query { IsDeleted = false, LOG_WRH_WarehouseID = warehouse2toGroup.LOG_WRH_Warehouse_RefID });
                    foreach (var w in warehouses)
                    {
                        var areas = CL1_LOG_WRH.ORM_LOG_WRH_Area.Query.Search(Connection, Transaction,
                            new CL1_LOG_WRH.ORM_LOG_WRH_Area.Query { IsDeleted = false, Warehouse_RefID = w.LOG_WRH_WarehouseID });
                        foreach (var a in areas)
                        {
                            var racks = CL1_LOG_WRH.ORM_LOG_WRH_Rack.Query.Search(Connection, Transaction,
                                new CL1_LOG_WRH.ORM_LOG_WRH_Rack.Query { IsDeleted = false, Area_RefID = a.LOG_WRH_AreaID });
                            foreach (var r in racks)
                            {
                                var shelves = CL1_LOG_WRH.ORM_LOG_WRH_Shelf.Query.Search(Connection, Transaction,
                                    new CL1_LOG_WRH.ORM_LOG_WRH_Shelf.Query { IsDeleted = true, Rack_RefID = r.LOG_WRH_RackID });
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
                        w.IsDeleted = true;
                        w.Save(Connection, Transaction);
                    }
                }
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.LOG_WRH_Warehouse_GroupID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.LOG_WRH_Warehouse_GroupID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            defaultSupplier.Warehouse_Group_RefID = item.LOG_WRH_Warehouse_GroupID;
            defaultSupplier.CMN_BPT_Supplier_RefID = Parameter.Default_Supplier_RefID;
            defaultSupplier.Tenant_RefID = item.Tenant_RefID;
            defaultSupplier.Save(Connection, Transaction);

            item.Parent_RefID = Parameter.Parent_RefID;
            item.WarehouseGroup_Name = Parameter.WarehouseGroup_Name;
            item.WarehouseGroup_Description = Parameter.WarehouseGroup_Description;
            //item.Default_Supplier_RefID = Parameter.Default_Supplier_RefID;

            return new FR_Guid(item.Save(Connection, Transaction), item.LOG_WRH_Warehouse_GroupID);
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2WH_SWHG_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2WH_SWHG_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2WH_SWHG_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2WH_SWHG_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Warehouse_Group",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2WH_SWHG_1327 for attribute P_L2WH_SWHG_1327
		[DataContract]
		public class P_L2WH_SWHG_1327 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_Warehouse_GroupID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public String WarehouseGroup_Name { get; set; } 
			[DataMember]
			public Dict WarehouseGroup_Description { get; set; } 
			[DataMember]
			public Guid Default_Supplier_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Warehouse_Group(,P_L2WH_SWHG_1327 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Warehouse_Group.Invoke(connectionString,P_L2WH_SWHG_1327 Parameter,securityTicket);
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
var parameter = new CL2_Warehouse.Complex.Manipulation.P_L2WH_SWHG_1327();
parameter.LOG_WRH_Warehouse_GroupID = ...;
parameter.Parent_RefID = ...;
parameter.WarehouseGroup_Name = ...;
parameter.WarehouseGroup_Description = ...;
parameter.Default_Supplier_RefID = ...;
parameter.IsDeleted = ...;

*/
