/* 
 * Generated on 9/4/2014 11:40:54 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL2_Warehouse.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Warehouse_Area_for_ID_or_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Warehouse_Area_for_ID_or_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2WH_GWHAfIoT_1444_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2WH_GWHAfIoT_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2WH_GWHAfIoT_1444_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Warehouse.Atomic.Retrieval.SQL.cls_Get_Warehouse_Area_for_ID_or_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AreaID", Parameter.AreaID);



			List<L2WH_GWHAfIoT_1444> results = new List<L2WH_GWHAfIoT_1444>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_AreaID","CoordinateCode","Area_Name","Warehouse_RefID","IsStructureHidden","IsConsignmentArea","IfConsignmentArea_DefaultOwningSupplier_RefID","Rack_NamePrefix","IsPointOfSalesArea","IsLongTermStorageArea","IsDeleted","CMN_BPT_Supplier_RefID","IsDefaultIntakeArea" });
				while(reader.Read())
				{
					L2WH_GWHAfIoT_1444 resultItem = new L2WH_GWHAfIoT_1444();
					//0:Parameter LOG_WRH_AreaID of type Guid
					resultItem.LOG_WRH_AreaID = reader.GetGuid(0);
					//1:Parameter CoordinateCode of type String
					resultItem.CoordinateCode = reader.GetString(1);
					//2:Parameter Area_Name of type String
					resultItem.Area_Name = reader.GetString(2);
					//3:Parameter Warehouse_RefID of type Guid
					resultItem.Warehouse_RefID = reader.GetGuid(3);
					//4:Parameter IsStructureHidden of type bool
					resultItem.IsStructureHidden = reader.GetBoolean(4);
					//5:Parameter IsConsignmentArea of type bool
					resultItem.IsConsignmentArea = reader.GetBoolean(5);
					//6:Parameter IfConsignmentArea_DefaultOwningSupplier_RefID of type Guid
					resultItem.IfConsignmentArea_DefaultOwningSupplier_RefID = reader.GetGuid(6);
					//7:Parameter Rack_NamePrefix of type String
					resultItem.Rack_NamePrefix = reader.GetString(7);
					//8:Parameter IsPointOfSalesArea of type bool
					resultItem.IsPointOfSalesArea = reader.GetBoolean(8);
					//9:Parameter IsLongTermStorageArea of type bool
					resultItem.IsLongTermStorageArea = reader.GetBoolean(9);
					//10:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(10);
					//11:Parameter CMN_BPT_Supplier_RefID of type Guid
					resultItem.CMN_BPT_Supplier_RefID = reader.GetGuid(11);
					//12:Parameter IsDefaultIntakeArea of type bool
					resultItem.IsDefaultIntakeArea = reader.GetBoolean(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Warehouse_Area_for_ID_or_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2WH_GWHAfIoT_1444_Array Invoke(string ConnectionString,P_L2WH_GWHAfIoT_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2WH_GWHAfIoT_1444_Array Invoke(DbConnection Connection,P_L2WH_GWHAfIoT_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2WH_GWHAfIoT_1444_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2WH_GWHAfIoT_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2WH_GWHAfIoT_1444_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2WH_GWHAfIoT_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2WH_GWHAfIoT_1444_Array functionReturn = new FR_L2WH_GWHAfIoT_1444_Array();
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

				throw new Exception("Exception occured in method cls_Get_Warehouse_Area_for_ID_or_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2WH_GWHAfIoT_1444_Array : FR_Base
	{
		public L2WH_GWHAfIoT_1444[] Result	{ get; set; } 
		public FR_L2WH_GWHAfIoT_1444_Array() : base() {}

		public FR_L2WH_GWHAfIoT_1444_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2WH_GWHAfIoT_1444 for attribute P_L2WH_GWHAfIoT_1444
		[DataContract]
		public class P_L2WH_GWHAfIoT_1444 
		{
			//Standard type parameters
			[DataMember]
			public Guid? AreaID { get; set; } 

		}
		#endregion
		#region SClass L2WH_GWHAfIoT_1444 for attribute L2WH_GWHAfIoT_1444
		[DataContract]
		public class L2WH_GWHAfIoT_1444 
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
			public bool IsStructureHidden { get; set; } 
			[DataMember]
			public bool IsConsignmentArea { get; set; } 
			[DataMember]
			public Guid IfConsignmentArea_DefaultOwningSupplier_RefID { get; set; } 
			[DataMember]
			public String Rack_NamePrefix { get; set; } 
			[DataMember]
			public bool IsPointOfSalesArea { get; set; } 
			[DataMember]
			public bool IsLongTermStorageArea { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid CMN_BPT_Supplier_RefID { get; set; } 
			[DataMember]
			public bool IsDefaultIntakeArea { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2WH_GWHAfIoT_1444_Array cls_Get_Warehouse_Area_for_ID_or_TenantID(,P_L2WH_GWHAfIoT_1444 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2WH_GWHAfIoT_1444_Array invocationResult = cls_Get_Warehouse_Area_for_ID_or_TenantID.Invoke(connectionString,P_L2WH_GWHAfIoT_1444 Parameter,securityTicket);
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
var parameter = new CL2_Warehouse.Atomic.Retrieval.P_L2WH_GWHAfIoT_1444();
parameter.AreaID = ...;

*/
