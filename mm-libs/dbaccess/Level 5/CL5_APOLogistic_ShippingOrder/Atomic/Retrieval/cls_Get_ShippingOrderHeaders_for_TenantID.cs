/* 
 * Generated on 8/8/2014 2:14:49 PM
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
    /// var result = cls_Get_ShippingOrderHeaders_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShippingOrderHeaders_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_GSOHfTID_1650_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_GSOHfTID_1650 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SO_GSOHfTID_1650_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.SQL.cls_Get_ShippingOrderHeaders_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsPartiallyReadyForPicking", Parameter.IsPartiallyReadyForPicking);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsReadyForPicking", Parameter.IsReadyForPicking);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HasPickingStarted", Parameter.HasPickingStarted);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HasPickingFinished", Parameter.HasPickingFinished);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsManuallyCleared_ForPicking", Parameter.IsManuallyCleared_ForPicking);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsBilled", Parameter.IsBilled);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsShipped", Parameter.IsShipped);



			List<L5SO_GSOHfTID_1650_raw> results = new List<L5SO_GSOHfTID_1650_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_HeaderID","ORD_CUO_CustomerOrder_HeaderID","ShipmentHeader_Number","CustomerOrder_Number","CustomerOrderCreationDate","ShippingCreationDate","IsPartiallyReadyForPicking","IsReadyForPicking","HasPickingStarted","HasPickingFinished","IsManuallyCleared_ForPicking","IsBilled","IsShipped","CompanyName_Line1","Shippipng_AddressUCD_RefID" });
				while(reader.Read())
				{
					L5SO_GSOHfTID_1650_raw resultItem = new L5SO_GSOHfTID_1650_raw();
					//0:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(0);
					//1:Parameter ORD_CUO_CustomerOrder_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrder_HeaderID = reader.GetGuid(1);
					//2:Parameter ShipmentHeader_Number of type String
					resultItem.ShipmentHeader_Number = reader.GetString(2);
					//3:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(3);
					//4:Parameter CustomerOrderCreationDate of type DateTime
					resultItem.CustomerOrderCreationDate = reader.GetDate(4);
					//5:Parameter ShippingCreationDate of type DateTime
					resultItem.ShippingCreationDate = reader.GetDate(5);
					//6:Parameter IsPartiallyReadyForPicking of type Boolean
					resultItem.IsPartiallyReadyForPicking = reader.GetBoolean(6);
					//7:Parameter IsReadyForPicking of type Boolean
					resultItem.IsReadyForPicking = reader.GetBoolean(7);
					//8:Parameter HasPickingStarted of type Boolean
					resultItem.HasPickingStarted = reader.GetBoolean(8);
					//9:Parameter HasPickingFinished of type Boolean
					resultItem.HasPickingFinished = reader.GetBoolean(9);
					//10:Parameter IsManuallyCleared_ForPicking of type Boolean
					resultItem.IsManuallyCleared_ForPicking = reader.GetBoolean(10);
					//11:Parameter IsBilled of type Boolean
					resultItem.IsBilled = reader.GetBoolean(11);
					//12:Parameter IsShipped of type Boolean
					resultItem.IsShipped = reader.GetBoolean(12);
					//13:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(13);
					//14:Parameter Shippipng_AddressUCD_RefID of type Guid
					resultItem.Shippipng_AddressUCD_RefID = reader.GetGuid(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShippingOrderHeaders_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5SO_GSOHfTID_1650_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SO_GSOHfTID_1650_Array Invoke(string ConnectionString,P_L5SO_GSOHfTID_1650 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_GSOHfTID_1650_Array Invoke(DbConnection Connection,P_L5SO_GSOHfTID_1650 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_GSOHfTID_1650_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_GSOHfTID_1650 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_GSOHfTID_1650_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_GSOHfTID_1650 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_GSOHfTID_1650_Array functionReturn = new FR_L5SO_GSOHfTID_1650_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShippingOrderHeaders_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5SO_GSOHfTID_1650_raw 
	{
		public Guid LOG_SHP_Shipment_HeaderID; 
		public Guid ORD_CUO_CustomerOrder_HeaderID; 
		public String ShipmentHeader_Number; 
		public String CustomerOrder_Number; 
		public DateTime CustomerOrderCreationDate; 
		public DateTime ShippingCreationDate; 
		public Boolean IsPartiallyReadyForPicking; 
		public Boolean IsReadyForPicking; 
		public Boolean HasPickingStarted; 
		public Boolean HasPickingFinished; 
		public Boolean IsManuallyCleared_ForPicking; 
		public Boolean IsBilled; 
		public Boolean IsShipped; 
		public String CompanyName_Line1; 
		public Guid Shippipng_AddressUCD_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5SO_GSOHfTID_1650[] Convert(List<L5SO_GSOHfTID_1650_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5SO_GSOHfTID_1650 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.LOG_SHP_Shipment_HeaderID)).ToArray()
	group el_L5SO_GSOHfTID_1650 by new 
	{ 
		el_L5SO_GSOHfTID_1650.LOG_SHP_Shipment_HeaderID,

	}
	into gfunct_L5SO_GSOHfTID_1650
	select new L5SO_GSOHfTID_1650
	{     
		LOG_SHP_Shipment_HeaderID = gfunct_L5SO_GSOHfTID_1650.Key.LOG_SHP_Shipment_HeaderID ,
		ORD_CUO_CustomerOrder_HeaderID = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().ORD_CUO_CustomerOrder_HeaderID ,
		ShipmentHeader_Number = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().ShipmentHeader_Number ,
		CustomerOrder_Number = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().CustomerOrder_Number ,
		CustomerOrderCreationDate = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().CustomerOrderCreationDate ,
		ShippingCreationDate = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().ShippingCreationDate ,
		IsPartiallyReadyForPicking = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().IsPartiallyReadyForPicking ,
		IsReadyForPicking = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().IsReadyForPicking ,
		HasPickingStarted = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().HasPickingStarted ,
		HasPickingFinished = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().HasPickingFinished ,
		IsManuallyCleared_ForPicking = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().IsManuallyCleared_ForPicking ,
		IsBilled = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().IsBilled ,
		IsShipped = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().IsShipped ,
		CompanyName_Line1 = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().CompanyName_Line1 ,
		Shippipng_AddressUCD_RefID = gfunct_L5SO_GSOHfTID_1650.FirstOrDefault().Shippipng_AddressUCD_RefID ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_GSOHfTID_1650_Array : FR_Base
	{
		public L5SO_GSOHfTID_1650[] Result	{ get; set; } 
		public FR_L5SO_GSOHfTID_1650_Array() : base() {}

		public FR_L5SO_GSOHfTID_1650_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_GSOHfTID_1650 for attribute P_L5SO_GSOHfTID_1650
		[DataContract]
		public class P_L5SO_GSOHfTID_1650 
		{
			//Standard type parameters
			[DataMember]
			public Boolean? IsPartiallyReadyForPicking { get; set; } 
			[DataMember]
			public Boolean? IsReadyForPicking { get; set; } 
			[DataMember]
			public Boolean? HasPickingStarted { get; set; } 
			[DataMember]
			public Boolean? HasPickingFinished { get; set; } 
			[DataMember]
			public Boolean? IsManuallyCleared_ForPicking { get; set; } 
			[DataMember]
			public Boolean? IsBilled { get; set; } 
			[DataMember]
			public Boolean? IsShipped { get; set; } 

		}
		#endregion
		#region SClass L5SO_GSOHfTID_1650 for attribute L5SO_GSOHfTID_1650
		[DataContract]
		public class L5SO_GSOHfTID_1650 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public DateTime CustomerOrderCreationDate { get; set; } 
			[DataMember]
			public DateTime ShippingCreationDate { get; set; } 
			[DataMember]
			public Boolean IsPartiallyReadyForPicking { get; set; } 
			[DataMember]
			public Boolean IsReadyForPicking { get; set; } 
			[DataMember]
			public Boolean HasPickingStarted { get; set; } 
			[DataMember]
			public Boolean HasPickingFinished { get; set; } 
			[DataMember]
			public Boolean IsManuallyCleared_ForPicking { get; set; } 
			[DataMember]
			public Boolean IsBilled { get; set; } 
			[DataMember]
			public Boolean IsShipped { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public Guid Shippipng_AddressUCD_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_GSOHfTID_1650_Array cls_Get_ShippingOrderHeaders_for_TenantID(,P_L5SO_GSOHfTID_1650 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_GSOHfTID_1650_Array invocationResult = cls_Get_ShippingOrderHeaders_for_TenantID.Invoke(connectionString,P_L5SO_GSOHfTID_1650 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.P_L5SO_GSOHfTID_1650();
parameter.IsPartiallyReadyForPicking = ...;
parameter.IsReadyForPicking = ...;
parameter.HasPickingStarted = ...;
parameter.HasPickingFinished = ...;
parameter.IsManuallyCleared_ForPicking = ...;
parameter.IsBilled = ...;
parameter.IsShipped = ...;

*/
