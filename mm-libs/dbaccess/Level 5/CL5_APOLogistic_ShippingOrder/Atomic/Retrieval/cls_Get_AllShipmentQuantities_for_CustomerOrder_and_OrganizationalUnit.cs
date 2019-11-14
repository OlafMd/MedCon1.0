/* 
 * Generated on 10/5/2014 7:13:52 PM
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

namespace CL5_APOLogistic_ShippingOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllShipmentQuantities_for_CustomerOrder_and_OrganizationalUnit.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllShipmentQuantities_for_CustomerOrder_and_OrganizationalUnit
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_GASQfCOaOU_1011_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_GASQfCOaOU_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SO_GASQfCOaOU_1011_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.SQL.cls_Get_AllShipmentQuantities_for_CustomerOrder_and_OrganizationalUnit.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomerOrderID", Parameter.CustomerOrderID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrganizationalUnitID", Parameter.OrganizationalUnitID);



			List<L5SO_GASQfCOaOU_1011_raw> results = new List<L5SO_GASQfCOaOU_1011_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_PositionID","CustomerOrderQuantity","OranizationalUnitQuantity","LOG_SHP_Shipment_PositionID","LOG_SHP_Shipment_Header_RefID","ShipmentQuantity","IsShipped" });
				while(reader.Read())
				{
					L5SO_GASQfCOaOU_1011_raw resultItem = new L5SO_GASQfCOaOU_1011_raw();
					//0:Parameter ORD_CUO_CustomerOrder_PositionID of type Guid
					resultItem.ORD_CUO_CustomerOrder_PositionID = reader.GetGuid(0);
					//1:Parameter CustomerOrderQuantity of type String
					resultItem.CustomerOrderQuantity = reader.GetString(1);
					//2:Parameter OranizationalUnitQuantity of type String
					resultItem.OranizationalUnitQuantity = reader.GetString(2);
					//3:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(3);
					//4:Parameter LOG_SHP_Shipment_Header_RefID of type Guid
					resultItem.LOG_SHP_Shipment_Header_RefID = reader.GetGuid(4);
					//5:Parameter ShipmentQuantity of type String
					resultItem.ShipmentQuantity = reader.GetString(5);
					//6:Parameter IsShipped of type Boolean
					resultItem.IsShipped = reader.GetBoolean(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllShipmentQuantities_for_CustomerOrder_and_OrganizationalUnit",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5SO_GASQfCOaOU_1011_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SO_GASQfCOaOU_1011_Array Invoke(string ConnectionString,P_L5SO_GASQfCOaOU_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_GASQfCOaOU_1011_Array Invoke(DbConnection Connection,P_L5SO_GASQfCOaOU_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_GASQfCOaOU_1011_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_GASQfCOaOU_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_GASQfCOaOU_1011_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_GASQfCOaOU_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_GASQfCOaOU_1011_Array functionReturn = new FR_L5SO_GASQfCOaOU_1011_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllShipmentQuantities_for_CustomerOrder_and_OrganizationalUnit",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5SO_GASQfCOaOU_1011_raw 
	{
		public Guid ORD_CUO_CustomerOrder_PositionID; 
		public String CustomerOrderQuantity; 
		public String OranizationalUnitQuantity; 
		public Guid LOG_SHP_Shipment_PositionID; 
		public Guid LOG_SHP_Shipment_Header_RefID; 
		public String ShipmentQuantity; 
		public Boolean IsShipped; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5SO_GASQfCOaOU_1011[] Convert(List<L5SO_GASQfCOaOU_1011_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5SO_GASQfCOaOU_1011 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ORD_CUO_CustomerOrder_PositionID)).ToArray()
	group el_L5SO_GASQfCOaOU_1011 by new 
	{ 
		el_L5SO_GASQfCOaOU_1011.ORD_CUO_CustomerOrder_PositionID,

	}
	into gfunct_L5SO_GASQfCOaOU_1011
	select new L5SO_GASQfCOaOU_1011
	{     
		ORD_CUO_CustomerOrder_PositionID = gfunct_L5SO_GASQfCOaOU_1011.Key.ORD_CUO_CustomerOrder_PositionID ,
		CustomerOrderQuantity = gfunct_L5SO_GASQfCOaOU_1011.FirstOrDefault().CustomerOrderQuantity ,
		OranizationalUnitQuantity = gfunct_L5SO_GASQfCOaOU_1011.FirstOrDefault().OranizationalUnitQuantity ,

		ShipmentPositions = 
		(
			from el_ShipmentPositions in gfunct_L5SO_GASQfCOaOU_1011.Where(element => !EqualsDefaultValue(element.LOG_SHP_Shipment_PositionID)).ToArray()
			group el_ShipmentPositions by new 
			{ 
				el_ShipmentPositions.LOG_SHP_Shipment_PositionID,

			}
			into gfunct_ShipmentPositions
			select new L5SO_GASQfCOaOU_1011a
			{     
				LOG_SHP_Shipment_PositionID = gfunct_ShipmentPositions.Key.LOG_SHP_Shipment_PositionID ,
				LOG_SHP_Shipment_Header_RefID = gfunct_ShipmentPositions.FirstOrDefault().LOG_SHP_Shipment_Header_RefID ,
				ShipmentQuantity = gfunct_ShipmentPositions.FirstOrDefault().ShipmentQuantity ,
				IsShipped = gfunct_ShipmentPositions.FirstOrDefault().IsShipped ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_GASQfCOaOU_1011_Array : FR_Base
	{
		public L5SO_GASQfCOaOU_1011[] Result	{ get; set; } 
		public FR_L5SO_GASQfCOaOU_1011_Array() : base() {}

		public FR_L5SO_GASQfCOaOU_1011_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_GASQfCOaOU_1011 for attribute P_L5SO_GASQfCOaOU_1011
		[DataContract]
		public class P_L5SO_GASQfCOaOU_1011 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderID { get; set; } 
			[DataMember]
			public Guid OrganizationalUnitID { get; set; } 

		}
		#endregion
		#region SClass L5SO_GASQfCOaOU_1011 for attribute L5SO_GASQfCOaOU_1011
		[DataContract]
		public class L5SO_GASQfCOaOU_1011 
		{
			[DataMember]
			public L5SO_GASQfCOaOU_1011a[] ShipmentPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_PositionID { get; set; } 
			[DataMember]
			public String CustomerOrderQuantity { get; set; } 
			[DataMember]
			public String OranizationalUnitQuantity { get; set; } 

		}
		#endregion
		#region SClass L5SO_GASQfCOaOU_1011a for attribute ShipmentPositions
		[DataContract]
		public class L5SO_GASQfCOaOU_1011a 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_Header_RefID { get; set; } 
			[DataMember]
			public String ShipmentQuantity { get; set; } 
			[DataMember]
			public Boolean IsShipped { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_GASQfCOaOU_1011_Array cls_Get_AllShipmentQuantities_for_CustomerOrder_and_OrganizationalUnit(,P_L5SO_GASQfCOaOU_1011 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_GASQfCOaOU_1011_Array invocationResult = cls_Get_AllShipmentQuantities_for_CustomerOrder_and_OrganizationalUnit.Invoke(connectionString,P_L5SO_GASQfCOaOU_1011 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.P_L5SO_GASQfCOaOU_1011();
parameter.CustomerOrderID = ...;
parameter.OrganizationalUnitID = ...;

*/
