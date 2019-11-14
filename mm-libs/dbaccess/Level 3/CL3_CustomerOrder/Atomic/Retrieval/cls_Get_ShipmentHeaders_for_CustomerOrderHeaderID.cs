/* 
 * Generated on 9/24/2014 2:38:14 PM
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
using System.Runtime.Serialization;

namespace CL3_CustomerOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShipmentHeaders_for_CustomerOrderHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShipmentHeaders_for_CustomerOrderHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CO_GSHfCOH_0734_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3CO_GSHfCOH_0734 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CO_GSHfCOH_0734_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_ShipmentHeaders_for_CustomerOrderHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomerOrderHeaderID", Parameter.CustomerOrderHeaderID);



			List<L3CO_GSHfCOH_0734_raw> results = new List<L3CO_GSHfCOH_0734_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_HeaderID","LOG_SHP_Shipment_HeaderID","ShipmentHeader_Number","CustomerOrder_Number","ShipmentOrderDate","CustomerOrder_Date","ShipmentPositionsCount","BillPositionsCount","InternalOrganizationalUnitNumber","ExternalOrganizationalUnitNumber","OrganizationalUnit_SimpleName","StatusDate","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L3CO_GSHfCOH_0734_raw resultItem = new L3CO_GSHfCOH_0734_raw();
					//0:Parameter ORD_CUO_CustomerOrder_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrder_HeaderID = reader.GetGuid(0);
					//1:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(1);
					//2:Parameter ShipmentHeader_Number of type String
					resultItem.ShipmentHeader_Number = reader.GetString(2);
					//3:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(3);
					//4:Parameter ShipmentOrderDate of type DateTime
					resultItem.ShipmentOrderDate = reader.GetDate(4);
					//5:Parameter CustomerOrder_Date of type DateTime
					resultItem.CustomerOrder_Date = reader.GetDate(5);
					//6:Parameter ShipmentPositionsCount of type int
					resultItem.ShipmentPositionsCount = reader.GetInteger(6);
					//7:Parameter BillPositionsCount of type int
					resultItem.BillPositionsCount = reader.GetInteger(7);
					//8:Parameter InternalOrganizationalUnitNumber of type String
					resultItem.InternalOrganizationalUnitNumber = reader.GetString(8);
					//9:Parameter ExternalOrganizationalUnitNumber of type String
					resultItem.ExternalOrganizationalUnitNumber = reader.GetString(9);
					//10:Parameter OrganizationalUnit_SimpleName of type String
					resultItem.OrganizationalUnit_SimpleName = reader.GetString(10);
					//11:Parameter StatusDate of type DateTime
					resultItem.StatusDate = reader.GetDate(11);
					//12:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShipmentHeaders_for_CustomerOrderHeaderID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3CO_GSHfCOH_0734_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3CO_GSHfCOH_0734_Array Invoke(string ConnectionString,P_L3CO_GSHfCOH_0734 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CO_GSHfCOH_0734_Array Invoke(DbConnection Connection,P_L3CO_GSHfCOH_0734 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CO_GSHfCOH_0734_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CO_GSHfCOH_0734 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CO_GSHfCOH_0734_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CO_GSHfCOH_0734 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CO_GSHfCOH_0734_Array functionReturn = new FR_L3CO_GSHfCOH_0734_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShipmentHeaders_for_CustomerOrderHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3CO_GSHfCOH_0734_raw 
	{
		public Guid ORD_CUO_CustomerOrder_HeaderID; 
		public Guid LOG_SHP_Shipment_HeaderID; 
		public String ShipmentHeader_Number; 
		public String CustomerOrder_Number; 
		public DateTime ShipmentOrderDate; 
		public DateTime CustomerOrder_Date; 
		public int ShipmentPositionsCount; 
		public int BillPositionsCount; 
		public String InternalOrganizationalUnitNumber; 
		public String ExternalOrganizationalUnitNumber; 
		public String OrganizationalUnit_SimpleName; 
		public DateTime StatusDate; 
		public String GlobalPropertyMatchingID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3CO_GSHfCOH_0734[] Convert(List<L3CO_GSHfCOH_0734_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3CO_GSHfCOH_0734 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.LOG_SHP_Shipment_HeaderID)).ToArray()
	group el_L3CO_GSHfCOH_0734 by new 
	{ 
		el_L3CO_GSHfCOH_0734.LOG_SHP_Shipment_HeaderID,

	}
	into gfunct_L3CO_GSHfCOH_0734
	select new L3CO_GSHfCOH_0734
	{     
		ORD_CUO_CustomerOrder_HeaderID = gfunct_L3CO_GSHfCOH_0734.FirstOrDefault().ORD_CUO_CustomerOrder_HeaderID ,
		LOG_SHP_Shipment_HeaderID = gfunct_L3CO_GSHfCOH_0734.Key.LOG_SHP_Shipment_HeaderID ,
		ShipmentHeader_Number = gfunct_L3CO_GSHfCOH_0734.FirstOrDefault().ShipmentHeader_Number ,
		CustomerOrder_Number = gfunct_L3CO_GSHfCOH_0734.FirstOrDefault().CustomerOrder_Number ,
		ShipmentOrderDate = gfunct_L3CO_GSHfCOH_0734.FirstOrDefault().ShipmentOrderDate ,
		CustomerOrder_Date = gfunct_L3CO_GSHfCOH_0734.FirstOrDefault().CustomerOrder_Date ,
		ShipmentPositionsCount = gfunct_L3CO_GSHfCOH_0734.FirstOrDefault().ShipmentPositionsCount ,
		BillPositionsCount = gfunct_L3CO_GSHfCOH_0734.FirstOrDefault().BillPositionsCount ,
		InternalOrganizationalUnitNumber = gfunct_L3CO_GSHfCOH_0734.FirstOrDefault().InternalOrganizationalUnitNumber ,
		ExternalOrganizationalUnitNumber = gfunct_L3CO_GSHfCOH_0734.FirstOrDefault().ExternalOrganizationalUnitNumber ,
		OrganizationalUnit_SimpleName = gfunct_L3CO_GSHfCOH_0734.FirstOrDefault().OrganizationalUnit_SimpleName ,

		Statuses = 
		(
			from el_Statuses in gfunct_L3CO_GSHfCOH_0734.Where(element => !EqualsDefaultValue(element.GlobalPropertyMatchingID)).ToArray()
			group el_Statuses by new 
			{ 
				el_Statuses.GlobalPropertyMatchingID,

			}
			into gfunct_Statuses
			select new L3CO_GSHfCOH_0734a
			{     
				StatusDate = gfunct_Statuses.FirstOrDefault().StatusDate ,
				GlobalPropertyMatchingID = gfunct_Statuses.Key.GlobalPropertyMatchingID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3CO_GSHfCOH_0734_Array : FR_Base
	{
		public L3CO_GSHfCOH_0734[] Result	{ get; set; } 
		public FR_L3CO_GSHfCOH_0734_Array() : base() {}

		public FR_L3CO_GSHfCOH_0734_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CO_GSHfCOH_0734 for attribute P_L3CO_GSHfCOH_0734
		[DataContract]
		public class P_L3CO_GSHfCOH_0734 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass L3CO_GSHfCOH_0734 for attribute L3CO_GSHfCOH_0734
		[DataContract]
		public class L3CO_GSHfCOH_0734 
		{
			[DataMember]
			public L3CO_GSHfCOH_0734a[] Statuses { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public DateTime ShipmentOrderDate { get; set; } 
			[DataMember]
			public DateTime CustomerOrder_Date { get; set; } 
			[DataMember]
			public int ShipmentPositionsCount { get; set; } 
			[DataMember]
			public int BillPositionsCount { get; set; } 
			[DataMember]
			public String InternalOrganizationalUnitNumber { get; set; } 
			[DataMember]
			public String ExternalOrganizationalUnitNumber { get; set; } 
			[DataMember]
			public String OrganizationalUnit_SimpleName { get; set; } 

		}
		#endregion
		#region SClass L3CO_GSHfCOH_0734a for attribute Statuses
		[DataContract]
		public class L3CO_GSHfCOH_0734a 
		{
			//Standard type parameters
			[DataMember]
			public DateTime StatusDate { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CO_GSHfCOH_0734_Array cls_Get_ShipmentHeaders_for_CustomerOrderHeaderID(,P_L3CO_GSHfCOH_0734 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CO_GSHfCOH_0734_Array invocationResult = cls_Get_ShipmentHeaders_for_CustomerOrderHeaderID.Invoke(connectionString,P_L3CO_GSHfCOH_0734 Parameter,securityTicket);
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
var parameter = new CL3_CustomerOrder.Atomic.Retrieval.P_L3CO_GSHfCOH_0734();
parameter.CustomerOrderHeaderID = ...;

*/
