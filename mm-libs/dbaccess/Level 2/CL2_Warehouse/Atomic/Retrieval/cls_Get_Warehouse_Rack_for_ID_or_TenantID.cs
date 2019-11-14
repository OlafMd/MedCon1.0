/* 
 * Generated on 18/11/2013 04:51:18
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
    /// var result = cls_Get_Warehouse_Rack_for_ID_or_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Warehouse_Rack_for_ID_or_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2WH_GWHRfIoT_1454_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2WH_GWHRfIoT_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2WH_GWHRfIoT_1454_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Warehouse.Atomic.Retrieval.SQL.cls_Get_Warehouse_Rack_for_ID_or_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RackID", Parameter.RackID);



			List<L2WH_GWHRfIoT_1454> results = new List<L2WH_GWHRfIoT_1454>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_RackID","Area_RefID","CoordinateCode","Shelves_Use_XCoordinate","Shelves_Use_YCoordinate","Shelves_Use_ZCoordinate","IsStructureHidden","Shelves_XLabel","Shelves_YLabel","Shelves_ZLabel","IsDeleted","Shelf_NamePrefix","Rack_Name","CMN_BPT_Supplier_RefID" });
				while(reader.Read())
				{
					L2WH_GWHRfIoT_1454 resultItem = new L2WH_GWHRfIoT_1454();
					//0:Parameter LOG_WRH_RackID of type Guid
					resultItem.LOG_WRH_RackID = reader.GetGuid(0);
					//1:Parameter Area_RefID of type Guid
					resultItem.Area_RefID = reader.GetGuid(1);
					//2:Parameter CoordinateCode of type String
					resultItem.CoordinateCode = reader.GetString(2);
					//3:Parameter Shelves_Use_XCoordinate of type Boolean
					resultItem.Shelves_Use_XCoordinate = reader.GetBoolean(3);
					//4:Parameter Shelves_Use_YCoordinate of type Boolean
					resultItem.Shelves_Use_YCoordinate = reader.GetBoolean(4);
					//5:Parameter Shelves_Use_ZCoordinate of type Boolean
					resultItem.Shelves_Use_ZCoordinate = reader.GetBoolean(5);
					//6:Parameter IsStructureHidden of type bool
					resultItem.IsStructureHidden = reader.GetBoolean(6);
					//7:Parameter Shelves_XLabel of type String
					resultItem.Shelves_XLabel = reader.GetString(7);
					//8:Parameter Shelves_YLabel of type String
					resultItem.Shelves_YLabel = reader.GetString(8);
					//9:Parameter Shelves_ZLabel of type String
					resultItem.Shelves_ZLabel = reader.GetString(9);
					//10:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(10);
					//11:Parameter Shelf_NamePrefix of type String
					resultItem.Shelf_NamePrefix = reader.GetString(11);
					//12:Parameter Rack_Name of type String
					resultItem.Rack_Name = reader.GetString(12);
					//13:Parameter CMN_BPT_Supplier_RefID of type Guid
					resultItem.CMN_BPT_Supplier_RefID = reader.GetGuid(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Warehouse_Rack_for_ID_or_TenantID",ex);
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
		public static FR_L2WH_GWHRfIoT_1454_Array Invoke(string ConnectionString,P_L2WH_GWHRfIoT_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2WH_GWHRfIoT_1454_Array Invoke(DbConnection Connection,P_L2WH_GWHRfIoT_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2WH_GWHRfIoT_1454_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2WH_GWHRfIoT_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2WH_GWHRfIoT_1454_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2WH_GWHRfIoT_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2WH_GWHRfIoT_1454_Array functionReturn = new FR_L2WH_GWHRfIoT_1454_Array();
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

				throw new Exception("Exception occured in method cls_Get_Warehouse_Rack_for_ID_or_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2WH_GWHRfIoT_1454_Array : FR_Base
	{
		public L2WH_GWHRfIoT_1454[] Result	{ get; set; } 
		public FR_L2WH_GWHRfIoT_1454_Array() : base() {}

		public FR_L2WH_GWHRfIoT_1454_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2WH_GWHRfIoT_1454 for attribute P_L2WH_GWHRfIoT_1454
		[DataContract]
		public class P_L2WH_GWHRfIoT_1454 
		{
			//Standard type parameters
			[DataMember]
			public Guid? RackID { get; set; } 

		}
		#endregion
		#region SClass L2WH_GWHRfIoT_1454 for attribute L2WH_GWHRfIoT_1454
		[DataContract]
		public class L2WH_GWHRfIoT_1454 
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
			public bool IsStructureHidden { get; set; } 
			[DataMember]
			public String Shelves_XLabel { get; set; } 
			[DataMember]
			public String Shelves_YLabel { get; set; } 
			[DataMember]
			public String Shelves_ZLabel { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public String Shelf_NamePrefix { get; set; } 
			[DataMember]
			public String Rack_Name { get; set; } 
			[DataMember]
			public Guid CMN_BPT_Supplier_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2WH_GWHRfIoT_1454_Array cls_Get_Warehouse_Rack_for_ID_or_TenantID(,P_L2WH_GWHRfIoT_1454 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2WH_GWHRfIoT_1454_Array invocationResult = cls_Get_Warehouse_Rack_for_ID_or_TenantID.Invoke(connectionString,P_L2WH_GWHRfIoT_1454 Parameter,securityTicket);
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
var parameter = new CL2_Warehouse.Atomic.Retrieval.P_L2WH_GWHRfIoT_1454();
parameter.RackID = ...;

*/
