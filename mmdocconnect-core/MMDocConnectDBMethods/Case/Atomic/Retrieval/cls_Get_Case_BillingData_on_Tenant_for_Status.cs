/* 
 * Generated on 04/25/17 10:16:57
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Case_BillingData_on_Tenant_for_Status.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_BillingData_on_Tenant_for_Status
	{
        public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_CAS_GCBDoTfS_1945_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCBDoTfS_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCBDoTfS_1945_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_BillingData_on_Tenant_for_Status.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@Statuses"," IN $$Statuses$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$Statuses$",Parameter.Statuses);


			List<CAS_GCBDoTfS_1945> results = new List<CAS_GCBDoTfS_1945>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "case_id","case_number","bill_position_id","gpos_id","fs_status_key","fs_status_code","bill_position_number","gpos_code","gpos_price","gpos_type","hec_bill_position_id","fs_status_id" });
				while(reader.Read())
				{
					CAS_GCBDoTfS_1945 resultItem = new CAS_GCBDoTfS_1945();
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

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_BillingData_on_Tenant_for_Status",ex);
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
		public static FR_CAS_GCBDoTfS_1945_Array Invoke(string ConnectionString,P_CAS_GCBDoTfS_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCBDoTfS_1945_Array Invoke(DbConnection Connection,P_CAS_GCBDoTfS_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCBDoTfS_1945_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCBDoTfS_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCBDoTfS_1945_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCBDoTfS_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCBDoTfS_1945_Array functionReturn = new FR_CAS_GCBDoTfS_1945_Array();
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

				throw new Exception("Exception occured in method cls_Get_Case_BillingData_on_Tenant_for_Status",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCBDoTfS_1945_Array : FR_Base
	{
		public CAS_GCBDoTfS_1945[] Result	{ get; set; } 
		public FR_CAS_GCBDoTfS_1945_Array() : base() {}

		public FR_CAS_GCBDoTfS_1945_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCBDoTfS_1405 for attribute P_CAS_GCBDoTfS_1405
		[DataContract]
		public class P_CAS_GCBDoTfS_1405 
		{
			//Standard type parameters
			[DataMember]
			public String[] Statuses { get; set; } 

		}
		#endregion
		#region SClass CAS_GCBDoTfS_1945 for attribute CAS_GCBDoTfS_1945
		[DataContract]
		public class CAS_GCBDoTfS_1945 
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

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCBDoTfS_1945_Array cls_Get_Case_BillingData_on_Tenant_for_Status(,P_CAS_GCBDoTfS_1405 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCBDoTfS_1945_Array invocationResult = cls_Get_Case_BillingData_on_Tenant_for_Status.Invoke(connectionString,P_CAS_GCBDoTfS_1405 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GCBDoTfS_1405();
parameter.Statuses = ...;

*/
