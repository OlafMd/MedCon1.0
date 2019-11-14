/* 
 * Generated on 11/12/2013 01:16:04
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
    /// var result = cls_Save_Shelves.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Shelves
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2WH_SSLF_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            var item = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf();
            if (Parameter.LOG_WRH_ShelfID != Guid.Empty)
            {
                var itemGetParameter = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf.Query();
                itemGetParameter.LOG_WRH_ShelfID = Parameter.LOG_WRH_ShelfID;
                itemGetParameter.IsDeleted = false;
                var foundItem = CL1_LOG_WRH.ORM_LOG_WRH_Shelf.Query.Search(Connection, Transaction, itemGetParameter);
                if (foundItem == null)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = Guid.Empty;
                    return returnValue;
                }
                else
                {
                    item = foundItem.Single();
                }
                
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.LOG_WRH_ShelfID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.LOG_WRH_ShelfID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            // Set referent fields
            CL1_LOG_WRH.ORM_LOG_WRH_Rack rack = new CL1_LOG_WRH.ORM_LOG_WRH_Rack();
            var fetchedRack = rack.Load(Connection, Transaction, Parameter.Rack_RefID);
            if (fetchedRack.Status != FR_Status.Success)
            {
                returnValue.ErrorMessage = fetchedRack.ErrorMessage;
                returnValue.Result = Guid.Empty;
                return returnValue;
            }

            CL1_LOG_WRH.ORM_LOG_WRH_Area area = new CL1_LOG_WRH.ORM_LOG_WRH_Area();
            area.Load(Connection, Transaction, rack.Area_RefID);
            Parameter.R_Warehouse_RefID = area.Warehouse_RefID;
            Parameter.R_Area_RefID = area.LOG_WRH_AreaID;

            item.Rack_RefID = Parameter.Rack_RefID;
            item.R_Warehouse_RefID = Parameter.R_Warehouse_RefID;
            item.R_Area_RefID = Parameter.R_Area_RefID;
            item.Shelf_Name = Parameter.Shelf_Name;
            item.CoordinateCode = Parameter.CoordinateCode;
            item.CoordinateX = Parameter.CoordinateX;
            item.CoordinateY = Parameter.CoordinateY;
            item.CoordinateZ = Parameter.CoordinateZ;
            item.ShelfCapacity_Unit_RefID = Parameter.ShelfCapacity_Unit_RefID;
            item.ShelfCapacity_Maximum = (decimal) Parameter.ShelfCapacity_Maximum;
            item.R_ShelfCapacity_Free = (decimal) Parameter.R_ShelfCapacity_Free;
            item.R_ShelfCapacity_Used = (decimal) Parameter.R_ShelfCapacity_Used;
            item.LimitShelfContent_ToOneProduct = Parameter.LimitShelfContent_ToOneProduct;
            item.LimitShelfContent_ToOneProductVariant = Parameter.LimitShelfContent_ToOneProductVariant;
            item.LimitShelfContent_ToOneProductRelease = Parameter.LimitShelfContent_ToOneProductRelease;
            item.IsShelfLocked = Parameter.IsShelfLocked;

            return new FR_Guid(item.Save(Connection, Transaction), item.LOG_WRH_ShelfID);
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2WH_SSLF_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2WH_SSLF_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2WH_SSLF_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2WH_SSLF_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Shelves",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2WH_SSLF_1341 for attribute P_L2WH_SSLF_1341
		[DataContract]
		public class P_L2WH_SSLF_1341 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_ShelfID { get; set; } 
			[DataMember]
			public Guid Rack_RefID { get; set; } 
			[DataMember]
			public Guid R_Warehouse_RefID { get; set; } 
			[DataMember]
			public Guid R_Area_RefID { get; set; } 
			[DataMember]
			public String Shelf_Name { get; set; } 
			[DataMember]
			public String CoordinateCode { get; set; } 
			[DataMember]
			public String CoordinateX { get; set; } 
			[DataMember]
			public String CoordinateY { get; set; } 
			[DataMember]
			public String CoordinateZ { get; set; } 
			[DataMember]
			public Guid ShelfCapacity_Unit_RefID { get; set; } 
			[DataMember]
			public double ShelfCapacity_Maximum { get; set; } 
			[DataMember]
			public double R_ShelfCapacity_Free { get; set; } 
			[DataMember]
			public double R_ShelfCapacity_Used { get; set; } 
			[DataMember]
			public Boolean LimitShelfContent_ToOneProduct { get; set; } 
			[DataMember]
			public Boolean LimitShelfContent_ToOneProductVariant { get; set; } 
			[DataMember]
			public Boolean LimitShelfContent_ToOneProductRelease { get; set; } 
			[DataMember]
			public Boolean IsShelfLocked { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Shelves(,P_L2WH_SSLF_1341 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Shelves.Invoke(connectionString,P_L2WH_SSLF_1341 Parameter,securityTicket);
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
var parameter = new CL2_Warehouse.Complex.Manipulation.P_L2WH_SSLF_1341();
parameter.LOG_WRH_ShelfID = ...;
parameter.Rack_RefID = ...;
parameter.R_Warehouse_RefID = ...;
parameter.R_Area_RefID = ...;
parameter.Shelf_Name = ...;
parameter.CoordinateCode = ...;
parameter.CoordinateX = ...;
parameter.CoordinateY = ...;
parameter.CoordinateZ = ...;
parameter.ShelfCapacity_Unit_RefID = ...;
parameter.ShelfCapacity_Maximum = ...;
parameter.R_ShelfCapacity_Free = ...;
parameter.R_ShelfCapacity_Used = ...;
parameter.LimitShelfContent_ToOneProduct = ...;
parameter.LimitShelfContent_ToOneProductVariant = ...;
parameter.LimitShelfContent_ToOneProductRelease = ...;
parameter.IsShelfLocked = ...;
parameter.IsDeleted = ...;

*/
