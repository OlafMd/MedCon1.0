/* 
 * Generated on 21.10.2014 10:57:01
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

namespace CL5_APOLogistic_Storage.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StorageDetails_for_ProductIDorShelfID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StorageDetails_for_ProductIDorShelfID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SG_GSDfPIDoSID_1612_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SG_GSDfPIDoSID_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SG_GSDfPIDoSID_1612_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_Storage.Atomic.Retrieval.SQL.cls_Get_StorageDetails_for_ProductIDorShelfID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShelfID", Parameter.ShelfID);



			List<L5SG_GSDfPIDoSID_1612> results = new List<L5SG_GSDfPIDoSID_1612>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Quantity_Current","BatchNumber","ExpirationDate","Rack_Name","Shelf_Name","Area_Name","Warehouse_Name","LOG_ProductTrackingInstanceID","CurrentQuantityOnTrackingInstance","LOG_WRH_Shelf_ContentID","Product_RefID","LOG_WRH_ShelfID","ReservedQuantity","LOG_RSV_ReservationID","ReservedSumPerContent" });
				while(reader.Read())
				{
					L5SG_GSDfPIDoSID_1612 resultItem = new L5SG_GSDfPIDoSID_1612();
					//0:Parameter Quantity_Current of type Double
					resultItem.Quantity_Current = reader.GetDouble(0);
					//1:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(1);
					//2:Parameter ExpirationDate of type DateTime
					resultItem.ExpirationDate = reader.GetDate(2);
					//3:Parameter Rack_Name of type String
					resultItem.Rack_Name = reader.GetString(3);
					//4:Parameter Shelf_Name of type String
					resultItem.Shelf_Name = reader.GetString(4);
					//5:Parameter Area_Name of type String
					resultItem.Area_Name = reader.GetString(5);
					//6:Parameter Warehouse_Name of type String
					resultItem.Warehouse_Name = reader.GetString(6);
					//7:Parameter LOG_ProductTrackingInstanceID of type Guid
					resultItem.LOG_ProductTrackingInstanceID = reader.GetGuid(7);
					//8:Parameter CurrentQuantityOnTrackingInstance of type Double
					resultItem.CurrentQuantityOnTrackingInstance = reader.GetDouble(8);
					//9:Parameter LOG_WRH_Shelf_ContentID of type Guid
					resultItem.LOG_WRH_Shelf_ContentID = reader.GetGuid(9);
					//10:Parameter Product_RefID of type Guid
					resultItem.Product_RefID = reader.GetGuid(10);
					//11:Parameter LOG_WRH_ShelfID of type Guid
					resultItem.LOG_WRH_ShelfID = reader.GetGuid(11);
					//12:Parameter ReservedQuantity of type Double
					resultItem.ReservedQuantity = reader.GetDouble(12);
					//13:Parameter LOG_RSV_ReservationID of type Guid
					resultItem.LOG_RSV_ReservationID = reader.GetGuid(13);
					//14:Parameter ReservedSumPerContent of type Double
					resultItem.ReservedSumPerContent = reader.GetDouble(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_StorageDetails_for_ProductIDorShelfID",ex);
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
		public static FR_L5SG_GSDfPIDoSID_1612_Array Invoke(string ConnectionString,P_L5SG_GSDfPIDoSID_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SG_GSDfPIDoSID_1612_Array Invoke(DbConnection Connection,P_L5SG_GSDfPIDoSID_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SG_GSDfPIDoSID_1612_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SG_GSDfPIDoSID_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SG_GSDfPIDoSID_1612_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SG_GSDfPIDoSID_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SG_GSDfPIDoSID_1612_Array functionReturn = new FR_L5SG_GSDfPIDoSID_1612_Array();
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

				throw new Exception("Exception occured in method cls_Get_StorageDetails_for_ProductIDorShelfID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SG_GSDfPIDoSID_1612_Array : FR_Base
	{
		public L5SG_GSDfPIDoSID_1612[] Result	{ get; set; } 
		public FR_L5SG_GSDfPIDoSID_1612_Array() : base() {}

		public FR_L5SG_GSDfPIDoSID_1612_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SG_GSDfPIDoSID_1612 for attribute P_L5SG_GSDfPIDoSID_1612
		[DataContract]
		public class P_L5SG_GSDfPIDoSID_1612 
		{
			//Standard type parameters
			[DataMember]
			public Guid? ProductID { get; set; } 
			[DataMember]
			public Guid? ShelfID { get; set; } 

		}
		#endregion
		#region SClass L5SG_GSDfPIDoSID_1612 for attribute L5SG_GSDfPIDoSID_1612
		[DataContract]
		public class L5SG_GSDfPIDoSID_1612 
		{
			//Standard type parameters
			[DataMember]
			public Double Quantity_Current { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpirationDate { get; set; } 
			[DataMember]
			public String Rack_Name { get; set; } 
			[DataMember]
			public String Shelf_Name { get; set; } 
			[DataMember]
			public String Area_Name { get; set; } 
			[DataMember]
			public String Warehouse_Name { get; set; } 
			[DataMember]
			public Guid LOG_ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public Double CurrentQuantityOnTrackingInstance { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_ContentID { get; set; } 
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_ShelfID { get; set; } 
			[DataMember]
			public Double ReservedQuantity { get; set; } 
			[DataMember]
			public Guid LOG_RSV_ReservationID { get; set; } 
			[DataMember]
			public Double ReservedSumPerContent { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SG_GSDfPIDoSID_1612_Array cls_Get_StorageDetails_for_ProductIDorShelfID(,P_L5SG_GSDfPIDoSID_1612 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SG_GSDfPIDoSID_1612_Array invocationResult = cls_Get_StorageDetails_for_ProductIDorShelfID.Invoke(connectionString,P_L5SG_GSDfPIDoSID_1612 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Storage.Atomic.Retrieval.P_L5SG_GSDfPIDoSID_1612();
parameter.ProductID = ...;
parameter.ShelfID = ...;

*/
