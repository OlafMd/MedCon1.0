/* 
 * Generated on 04/20/17 16:53:13
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

namespace DataImporter.DBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Case_BillingData_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_BillingData_on_Tenant
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_CAS_GCBDoT_0947_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCBDoT_0947_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_BillingData_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<CAS_GCBDoT_0947> results = new List<CAS_GCBDoT_0947>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "case_id","case_number","bill_position_id","gpos_id","fs_status_key","fs_status_code","bill_position_number","gpos_code","gpos_price","gpos_type","hec_bill_position_id","fs_status_id","patient_id","localization" });
				while(reader.Read())
				{
					CAS_GCBDoT_0947 resultItem = new CAS_GCBDoT_0947();
					//0:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(0);
					//1:Parameter case_number of type String
					resultItem.case_number = reader.GetString(1);
					//2:Parameter bill_position_id of type Guid
					resultItem.bill_position_id = reader.GetGuid(2);
					//3:Parameter gpos_id of type Guid
					resultItem.gpos_id = reader.GetGuid(3);
					//4:Parameter fs_status_key of type String
					resultItem.fs_status_key = reader.GetString(4);
					//5:Parameter fs_status_code of type int
					resultItem.fs_status_code = reader.GetInteger(5);
					//6:Parameter bill_position_number of type String
					resultItem.bill_position_number = reader.GetString(6);
					//7:Parameter gpos_code of type String
					resultItem.gpos_code = reader.GetString(7);
					//8:Parameter gpos_price of type double
					resultItem.gpos_price = reader.GetDouble(8);
					//9:Parameter gpos_type of type String
					resultItem.gpos_type = reader.GetString(9);
					//10:Parameter hec_bill_position_id of type Guid
					resultItem.hec_bill_position_id = reader.GetGuid(10);
					//11:Parameter fs_status_id of type Guid
					resultItem.fs_status_id = reader.GetGuid(11);
					//12:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(12);
					//13:Parameter localization of type String
					resultItem.localization = reader.GetString(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_BillingData_on_Tenant",ex);
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
		public static FR_CAS_GCBDoT_0947_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCBDoT_0947_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCBDoT_0947_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCBDoT_0947_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCBDoT_0947_Array functionReturn = new FR_CAS_GCBDoT_0947_Array();
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

				throw new Exception("Exception occured in method cls_Get_Case_BillingData_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCBDoT_0947_Array : FR_Base
	{
		public CAS_GCBDoT_0947[] Result	{ get; set; } 
		public FR_CAS_GCBDoT_0947_Array() : base() {}

		public FR_CAS_GCBDoT_0947_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass CAS_GCBDoT_0947 for attribute CAS_GCBDoT_0947
		[DataContract]
		public class CAS_GCBDoT_0947 
		{
			//Standard type parameters
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public String case_number { get; set; } 
			[DataMember]
			public Guid bill_position_id { get; set; } 
			[DataMember]
			public Guid gpos_id { get; set; } 
			[DataMember]
			public String fs_status_key { get; set; } 
			[DataMember]
			public int fs_status_code { get; set; } 
			[DataMember]
			public String bill_position_number { get; set; } 
			[DataMember]
			public String gpos_code { get; set; } 
			[DataMember]
			public double gpos_price { get; set; } 
			[DataMember]
			public String gpos_type { get; set; } 
			[DataMember]
			public Guid hec_bill_position_id { get; set; } 
			[DataMember]
			public Guid fs_status_id { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public String localization { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCBDoT_0947_Array cls_Get_Case_BillingData_on_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCBDoT_0947_Array invocationResult = cls_Get_Case_BillingData_on_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

