/* 
 * Generated on 18/8/2014 01:24:31
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

namespace CL2_Warehouse.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Area.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Area
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2WH_SAR_1346 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            #region remove default intake area if needed

            var allWarehouseAreas = CL2_Warehouse.Atomic.Retrieval.cls_Get_Warehouse_Areas_for_WarehouseID.
                Invoke(Connection, Transaction,
                new Atomic.Retrieval.P_L2WH_HWAfWH_1135() { WorkhouseID = Parameter.Warehouse_RefID }, securityTicket).Result;

            // check if Parameter.IsDefaultIntakeArea is true and there is already one setted
            // delete default area flag for loaded one
            if (Parameter.IsDefaultIntakeArea && allWarehouseAreas.Any(i => i.IsDefaultIntakeArea))
            {
                var defaultAreaList = allWarehouseAreas.Where(i=>i.IsDefaultIntakeArea).ToList();
                CL1_LOG_WRH.ORM_LOG_WRH_Area areaORM;
                FR_Base areaORMResult;
                foreach (var oldDefaultArea in defaultAreaList)
                {
                    areaORM = new CL1_LOG_WRH.ORM_LOG_WRH_Area();
                    areaORMResult = areaORM.Load(Connection, Transaction, oldDefaultArea.LOG_WRH_AreaID);
                    if (areaORMResult.Status == FR_Status.Success && areaORM.LOG_WRH_AreaID != Guid.Empty)
                    {
                        areaORM.IsDefaultIntakeArea = false;
                        areaORM.Save(Connection, Transaction);
                    }
                }
            }

            #endregion

			var item = new CL1_LOG_WRH.ORM_LOG_WRH_Area();
            var defaultSupplier = new CL1_LOG_WRH.ORM_LOG_WRH_Area_DefaultSupplier();
            if (Parameter.LOG_WRH_AreaID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.LOG_WRH_AreaID);
                defaultSupplier = CL1_LOG_WRH.ORM_LOG_WRH_Area_DefaultSupplier.Query.Search(Connection, Transaction,
                               new CL1_LOG_WRH.ORM_LOG_WRH_Area_DefaultSupplier.Query()
                               {
                                   Area_RefID = item.LOG_WRH_AreaID,
                                   IsDeleted = false
                               }).SingleOrDefault();

                if (Parameter.Default_Supplier_RefID == Guid.Empty && defaultSupplier != null)
                {
                    defaultSupplier.IsDeleted = true;
                }
                else if (defaultSupplier == null)
                {
                    defaultSupplier = new CL1_LOG_WRH.ORM_LOG_WRH_Area_DefaultSupplier();
                }
            }

			if(Parameter.IsDeleted == true){

                defaultSupplier.IsDeleted = true;
                defaultSupplier.Save(Connection, Transaction);

                var racks = CL1_LOG_WRH.ORM_LOG_WRH_Rack.Query.Search(Connection, Transaction,
                       new CL1_LOG_WRH.ORM_LOG_WRH_Rack.Query { IsDeleted = false, Area_RefID = Parameter.LOG_WRH_AreaID });
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

				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.LOG_WRH_AreaID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.LOG_WRH_AreaID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}


            defaultSupplier.Area_RefID = item.LOG_WRH_AreaID;
            defaultSupplier.CMN_BPT_Supplier_RefID = Parameter.Default_Supplier_RefID;
            defaultSupplier.Tenant_RefID = item.Tenant_RefID;
            defaultSupplier.Save(Connection, Transaction);

			item.CoordinateCode = Parameter.CoordinateCode;
			item.Area_Name = Parameter.Area_Name;
			item.Warehouse_RefID = Parameter.Warehouse_RefID;
			item.IsStructureHidden = Parameter.IsStructureHidden;
			item.IsConsignmentArea = Parameter.IsConsignmentArea;
			item.IfConsignmentArea_DefaultOwningSupplier_RefID = Parameter.IfConsignmentArea_DefaultOwningSupplier_RefID;
            item.Rack_NamePrefix = Parameter.Rack_NamePrefix;
            item.IsPointOfSalesArea = Parameter.IsPointOfSalesArea;
            item.IsLongTermStorageArea = !Parameter.IsPointOfSalesArea;
            item.IsDefaultIntakeArea = Parameter.IsDefaultIntakeArea;

			return new FR_Guid(item.Save(Connection, Transaction),item.LOG_WRH_AreaID);
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2WH_SAR_1346 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2WH_SAR_1346 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2WH_SAR_1346 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2WH_SAR_1346 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Area",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2WH_SAR_1346 for attribute P_L2WH_SAR_1346
		[DataContract]
		public class P_L2WH_SAR_1346 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_AreaID { get; set; } 
			[DataMember]
			public String CoordinateCode { get; set; } 
			[DataMember]
			public String Area_Name { get; set; } 
			[DataMember]
			public Guid Warehouse_RefID { get; set; } 
			[DataMember]
			public Boolean IsStructureHidden { get; set; } 
			[DataMember]
			public Boolean IsConsignmentArea { get; set; } 
			[DataMember]
			public Guid IfConsignmentArea_DefaultOwningSupplier_RefID { get; set; } 
			[DataMember]
			public Guid Default_Supplier_RefID { get; set; } 
			[DataMember]
			public String Rack_NamePrefix { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsPointOfSalesArea { get; set; } 
			[DataMember]
			public Boolean IsDefaultIntakeArea { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Area(,P_L2WH_SAR_1346 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Area.Invoke(connectionString,P_L2WH_SAR_1346 Parameter,securityTicket);
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
var parameter = new CL2_Warehouse.Complex.Manipulation.P_L2WH_SAR_1346();
parameter.LOG_WRH_AreaID = ...;
parameter.CoordinateCode = ...;
parameter.Area_Name = ...;
parameter.Warehouse_RefID = ...;
parameter.IsStructureHidden = ...;
parameter.IsConsignmentArea = ...;
parameter.IfConsignmentArea_DefaultOwningSupplier_RefID = ...;
parameter.Default_Supplier_RefID = ...;
parameter.Rack_NamePrefix = ...;
parameter.IsDeleted = ...;
parameter.IsPointOfSalesArea = ...;
parameter.IsDefaultIntakeArea = ...;

*/
