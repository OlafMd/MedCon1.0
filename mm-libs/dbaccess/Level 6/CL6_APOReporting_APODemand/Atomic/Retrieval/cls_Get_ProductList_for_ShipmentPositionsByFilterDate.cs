/* 
 * Generated on 16.09.2014 15:24:03
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

namespace CL6_APOReporting_APODemand.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProductList_for_ShipmentPositionsByFilterDate.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProductList_for_ShipmentPositionsByFilterDate
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6AD_GPLfSPBFD_1828_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6AD_GPLfSPBFD_1828 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6AD_GPLfSPBFD_1828_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_APOReporting_APODemand.Atomic.Retrieval.SQL.cls_Get_ProductList_for_ShipmentPositionsByFilterDate.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DateFrom", Parameter.DateFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DateTo", Parameter.DateTo);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomerID", Parameter.CustomerID);



			List<L6AD_GPLfSPBFD_1828_raw> results = new List<L6AD_GPLfSPBFD_1828_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_Name_DictID","CMN_PRO_ProductID","IsShipped","GlobalPropertyMatchingID","Creation_Timestamp","RecipientBusinessParticipant_RefID","QuantityToShip","LOG_SHP_Shipment_HeaderID","Product_Number" });
				while(reader.Read())
				{
					L6AD_GPLfSPBFD_1828_raw resultItem = new L6AD_GPLfSPBFD_1828_raw();
					//0:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(0);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//1:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(1);
					//2:Parameter IsShipped of type bool
					resultItem.IsShipped = reader.GetBoolean(2);
					//3:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter RecipientBusinessParticipant_RefID of type Guid
					resultItem.RecipientBusinessParticipant_RefID = reader.GetGuid(5);
					//6:Parameter QuantityToShip of type float
					resultItem.QuantityToShip = (float)reader.GetDouble(6);
					//7:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(7);
					//8:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProductList_for_ShipmentPositionsByFilterDate",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L6AD_GPLfSPBFD_1828_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6AD_GPLfSPBFD_1828_Array Invoke(string ConnectionString,P_L6AD_GPLfSPBFD_1828 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6AD_GPLfSPBFD_1828_Array Invoke(DbConnection Connection,P_L6AD_GPLfSPBFD_1828 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6AD_GPLfSPBFD_1828_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6AD_GPLfSPBFD_1828 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6AD_GPLfSPBFD_1828_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6AD_GPLfSPBFD_1828 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6AD_GPLfSPBFD_1828_Array functionReturn = new FR_L6AD_GPLfSPBFD_1828_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProductList_for_ShipmentPositionsByFilterDate",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L6AD_GPLfSPBFD_1828_raw 
	{
		public Dict Product_Name; 
		public Guid CMN_PRO_ProductID; 
		public bool IsShipped; 
		public String GlobalPropertyMatchingID; 
		public DateTime Creation_Timestamp; 
		public Guid RecipientBusinessParticipant_RefID; 
		public float QuantityToShip; 
		public Guid LOG_SHP_Shipment_HeaderID; 
		public String Product_Number; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6AD_GPLfSPBFD_1828[] Convert(List<L6AD_GPLfSPBFD_1828_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6AD_GPLfSPBFD_1828 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
	group el_L6AD_GPLfSPBFD_1828 by new 
	{ 
		el_L6AD_GPLfSPBFD_1828.CMN_PRO_ProductID,

	}
	into gfunct_L6AD_GPLfSPBFD_1828
	select new L6AD_GPLfSPBFD_1828
	{     
		Product_Name = gfunct_L6AD_GPLfSPBFD_1828.FirstOrDefault().Product_Name ,
		CMN_PRO_ProductID = gfunct_L6AD_GPLfSPBFD_1828.Key.CMN_PRO_ProductID ,
		IsShipped = gfunct_L6AD_GPLfSPBFD_1828.FirstOrDefault().IsShipped ,
		GlobalPropertyMatchingID = gfunct_L6AD_GPLfSPBFD_1828.FirstOrDefault().GlobalPropertyMatchingID ,
		Creation_Timestamp = gfunct_L6AD_GPLfSPBFD_1828.FirstOrDefault().Creation_Timestamp ,
		RecipientBusinessParticipant_RefID = gfunct_L6AD_GPLfSPBFD_1828.FirstOrDefault().RecipientBusinessParticipant_RefID ,
		QuantityToShip = gfunct_L6AD_GPLfSPBFD_1828.FirstOrDefault().QuantityToShip ,
		LOG_SHP_Shipment_HeaderID = gfunct_L6AD_GPLfSPBFD_1828.FirstOrDefault().LOG_SHP_Shipment_HeaderID ,
		Product_Number = gfunct_L6AD_GPLfSPBFD_1828.FirstOrDefault().Product_Number ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6AD_GPLfSPBFD_1828_Array : FR_Base
	{
		public L6AD_GPLfSPBFD_1828[] Result	{ get; set; } 
		public FR_L6AD_GPLfSPBFD_1828_Array() : base() {}

		public FR_L6AD_GPLfSPBFD_1828_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6AD_GPLfSPBFD_1828 for attribute P_L6AD_GPLfSPBFD_1828
		[DataContract]
		public class P_L6AD_GPLfSPBFD_1828 
		{
			//Standard type parameters
			[DataMember]
			public DateTime DateFrom { get; set; } 
			[DataMember]
			public DateTime DateTo { get; set; } 
			[DataMember]
			public Guid CustomerID { get; set; } 

		}
		#endregion
		#region SClass L6AD_GPLfSPBFD_1828 for attribute L6AD_GPLfSPBFD_1828
		[DataContract]
		public class L6AD_GPLfSPBFD_1828 
		{
			//Standard type parameters
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public bool IsShipped { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid RecipientBusinessParticipant_RefID { get; set; } 
			[DataMember]
			public float QuantityToShip { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6AD_GPLfSPBFD_1828_Array cls_Get_ProductList_for_ShipmentPositionsByFilterDate(,P_L6AD_GPLfSPBFD_1828 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6AD_GPLfSPBFD_1828_Array invocationResult = cls_Get_ProductList_for_ShipmentPositionsByFilterDate.Invoke(connectionString,P_L6AD_GPLfSPBFD_1828 Parameter,securityTicket);
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
var parameter = new CL6_APOReporting_APODemand.Atomic.Retrieval.P_L6AD_GPLfSPBFD_1828();
parameter.DateFrom = ...;
parameter.DateTo = ...;
parameter.CustomerID = ...;

*/
