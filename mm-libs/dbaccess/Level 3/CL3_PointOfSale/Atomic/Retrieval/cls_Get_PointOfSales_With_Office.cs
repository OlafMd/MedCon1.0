/* 
 * Generated on 12/23/2014 1:29:04 PM
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

namespace CL3_PointOfSale.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PointOfSales_With_Office.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PointOfSales_With_Office
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PS_GPOSwO_1427_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PS_GPOSwO_1427_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_PointOfSale.Atomic.Retrieval.SQL.cls_Get_PointOfSales_With_Office.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3PS_GPOSwO_1427> results = new List<L3PS_GPOSwO_1427>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_SLS_PointOfSaleID","PointOfSale_DisplayName","PointOfSaleITL","IsPickUpStationForDistributionOrder","CMN_STR_OfficeID","Office_Name_DictID","Office_ShortName" });
				while(reader.Read())
				{
					L3PS_GPOSwO_1427 resultItem = new L3PS_GPOSwO_1427();
					//0:Parameter CMN_SLS_PointOfSaleID of type Guid
					resultItem.CMN_SLS_PointOfSaleID = reader.GetGuid(0);
					//1:Parameter PointOfSale_DisplayName of type string
					resultItem.PointOfSale_DisplayName = reader.GetString(1);
					//2:Parameter PointOfSaleITL of type string
					resultItem.PointOfSaleITL = reader.GetString(2);
					//3:Parameter IsPickUpStationForDistributionOrder of type bool
					resultItem.IsPickUpStationForDistributionOrder = reader.GetBoolean(3);
					//4:Parameter CMN_STR_OfficeID of type Guid
					resultItem.CMN_STR_OfficeID = reader.GetGuid(4);
					//5:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(5);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//6:Parameter Office_ShortName of type string
					resultItem.Office_ShortName = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PointOfSales_With_Office",ex);
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
		public static FR_L3PS_GPOSwO_1427_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PS_GPOSwO_1427_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PS_GPOSwO_1427_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PS_GPOSwO_1427_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PS_GPOSwO_1427_Array functionReturn = new FR_L3PS_GPOSwO_1427_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_PointOfSales_With_Office",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PS_GPOSwO_1427_Array : FR_Base
	{
		public L3PS_GPOSwO_1427[] Result	{ get; set; } 
		public FR_L3PS_GPOSwO_1427_Array() : base() {}

		public FR_L3PS_GPOSwO_1427_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3PS_GPOSwO_1427 for attribute L3PS_GPOSwO_1427
		[DataContract]
		public class L3PS_GPOSwO_1427 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_PointOfSaleID { get; set; } 
			[DataMember]
			public string PointOfSale_DisplayName { get; set; } 
			[DataMember]
			public string PointOfSaleITL { get; set; } 
			[DataMember]
			public bool IsPickUpStationForDistributionOrder { get; set; } 
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public string Office_ShortName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PS_GPOSwO_1427_Array cls_Get_PointOfSales_With_Office(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PS_GPOSwO_1427_Array invocationResult = cls_Get_PointOfSales_With_Office.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

