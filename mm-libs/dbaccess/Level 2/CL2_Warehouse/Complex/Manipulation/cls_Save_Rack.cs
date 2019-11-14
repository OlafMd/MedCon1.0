/* 
 * Generated on 7/11/2013 09:31:32
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
    /// var result = cls_Save_Rack.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Rack
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2WH_SRCK_1343 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            var item = new CL1_LOG_WRH.ORM_LOG_WRH_Rack();
            var defaultSupplier = new CL1_LOG_WRH.ORM_LOG_WRH_Rack_DefaultSupplier();
            if (Parameter.LOG_WRH_RackID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.LOG_WRH_RackID);

                defaultSupplier = CL1_LOG_WRH.ORM_LOG_WRH_Rack_DefaultSupplier.Query.Search(Connection, Transaction,
                               new CL1_LOG_WRH.ORM_LOG_WRH_Rack_DefaultSupplier.Query()
                               {
                                   Rack_RefID = item.LOG_WRH_RackID,
                                   IsDeleted = false
                               }).SingleOrDefault();

                if (Parameter.Default_Supplier_RefID == Guid.Empty && defaultSupplier != null)
                {
                    defaultSupplier.IsDeleted = true;
                }
                else if (defaultSupplier == null)
                {
                    defaultSupplier = new CL1_LOG_WRH.ORM_LOG_WRH_Rack_DefaultSupplier();
                }
            }

           
            if (Parameter.IsDeleted == true)
            {
                defaultSupplier.IsDeleted = true;
                defaultSupplier.Save(Connection, Transaction);

                // Delete all references shelves
                var shelves = CL1_LOG_WRH.ORM_LOG_WRH_Shelf.Query.Search(Connection, Transaction,
                    new CL1_LOG_WRH.ORM_LOG_WRH_Shelf.Query { IsDeleted = false, Rack_RefID = Parameter.LOG_WRH_RackID });
                foreach (var s in shelves)
                {
                    s.IsDeleted = true;
                    s.Save(Connection, Transaction);
                }

                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.LOG_WRH_RackID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.LOG_WRH_RackID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            defaultSupplier.Rack_RefID = item.LOG_WRH_RackID;
            defaultSupplier.CMN_BPT_Supplier_RefID = Parameter.Default_Supplier_RefID;
            defaultSupplier.Tenant_RefID = item.Tenant_RefID;
            defaultSupplier.Save(Connection, Transaction);

            item.Area_RefID = Parameter.Area_RefID;
            item.CoordinateCode = Parameter.CoordinateCode;
            item.Shelves_Use_XCoordinate = Parameter.Shelves_Use_XCoordinate;
            item.Shelves_Use_YCoordinate = Parameter.Shelves_Use_YCoordinate;
            item.Shelves_Use_ZCoordinate = Parameter.Shelves_Use_ZCoordinate;
            item.Shelves_XLabel = Parameter.Shelves_XLabel;
            item.Shelves_YLabel = Parameter.Shelves_YLabel;
            item.Shelves_ZLabel = Parameter.Shelves_ZLabel;
            item.IsStructureHidden = Parameter.IsStructureHidden;
            item.Shelf_NamePrefix = Parameter.Shelf_NamePrefix;
            item.Rack_Name = Parameter.Rack_Name;
            return new FR_Guid(item.Save(Connection, Transaction), item.LOG_WRH_RackID);
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2WH_SRCK_1343 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2WH_SRCK_1343 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2WH_SRCK_1343 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2WH_SRCK_1343 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Rack",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2WH_SRCK_1343 for attribute P_L2WH_SRCK_1343
		[DataContract]
		public class P_L2WH_SRCK_1343 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_RackID { get; set; } 
			[DataMember]
			public Guid Area_RefID { get; set; } 
			[DataMember]
			public String CoordinateCode { get; set; } 
			[DataMember]
			public Boolean Shelves_Use_XCoordinate { get; set; } 
			[DataMember]
			public Boolean Shelves_Use_YCoordinate { get; set; } 
			[DataMember]
			public Boolean Shelves_Use_ZCoordinate { get; set; } 
			[DataMember]
			public String Shelves_XLabel { get; set; } 
			[DataMember]
			public String Shelves_YLabel { get; set; } 
			[DataMember]
			public String Shelves_ZLabel { get; set; } 
			[DataMember]
			public Boolean IsStructureHidden { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public String Shelf_NamePrefix { get; set; } 
			[DataMember]
			public String Rack_Name { get; set; } 
			[DataMember]
			public Guid Default_Supplier_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Rack(,P_L2WH_SRCK_1343 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Rack.Invoke(connectionString,P_L2WH_SRCK_1343 Parameter,securityTicket);
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
var parameter = new CL2_Warehouse.Complex.Manipulation.P_L2WH_SRCK_1343();
parameter.LOG_WRH_RackID = ...;
parameter.Area_RefID = ...;
parameter.CoordinateCode = ...;
parameter.Shelves_Use_XCoordinate = ...;
parameter.Shelves_Use_YCoordinate = ...;
parameter.Shelves_Use_ZCoordinate = ...;
parameter.Shelves_XLabel = ...;
parameter.Shelves_YLabel = ...;
parameter.Shelves_ZLabel = ...;
parameter.IsStructureHidden = ...;
parameter.IsDeleted = ...;
parameter.Shelf_NamePrefix = ...;
parameter.Rack_Name = ...;
parameter.Default_Supplier_RefID = ...;

*/
