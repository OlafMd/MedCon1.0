/* 
 * Generated on 8/13/2014 3:12:53 PM
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

namespace CL3_MeasuringPoints.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_AdressHistory_by_AccountCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_AdressHistory_by_AccountCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3_AHbAC_1534_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3_AHbAC_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3_AHbAC_1534_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_MeasuringPoints.Atomic.Retrieval.SQL.cls_AdressHistory_by_AccountCode.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AccountCode", Parameter.AccountCode);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DownloadCode", Parameter.DownloadCode);



			List<L3_AHbAC_1534> results = new List<L3_AHbAC_1534>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "MRS_MPT_AddressHistoryID","MeasuringPoint_RefID","Address_RefID","ActiveFrom","ActiveThrough","Creation_Timestamp","Tenant_RefID","IsDeleted" });
				while(reader.Read())
				{
					L3_AHbAC_1534 resultItem = new L3_AHbAC_1534();
					//0:Parameter MRS_MPT_AddressHistoryID of type Guid
					resultItem.MRS_MPT_AddressHistoryID = reader.GetGuid(0);
					//1:Parameter MeasuringPoint_RefID of type Guid
					resultItem.MeasuringPoint_RefID = reader.GetGuid(1);
					//2:Parameter Address_RefID of type Guid
					resultItem.Address_RefID = reader.GetGuid(2);
					//3:Parameter ActiveFrom of type String
					resultItem.ActiveFrom = reader.GetString(3);
					//4:Parameter ActiveThrough of type String
					resultItem.ActiveThrough = reader.GetString(4);
					//5:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(5);
					//6:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(6);
					//7:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_AdressHistory_by_AccountCode",ex);
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
		public static FR_L3_AHbAC_1534_Array Invoke(string ConnectionString,P_L3_AHbAC_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3_AHbAC_1534_Array Invoke(DbConnection Connection,P_L3_AHbAC_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3_AHbAC_1534_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_AHbAC_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3_AHbAC_1534_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_AHbAC_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3_AHbAC_1534_Array functionReturn = new FR_L3_AHbAC_1534_Array();
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

				throw new Exception("Exception occured in method cls_AdressHistory_by_AccountCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3_AHbAC_1534_Array : FR_Base
	{
		public L3_AHbAC_1534[] Result	{ get; set; } 
		public FR_L3_AHbAC_1534_Array() : base() {}

		public FR_L3_AHbAC_1534_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3_AHbAC_1534 for attribute P_L3_AHbAC_1534
		[DataContract]
		public class P_L3_AHbAC_1534 
		{
			//Standard type parameters
			[DataMember]
			public string AccountCode { get; set; } 
			[DataMember]
			public string DownloadCode { get; set; } 

		}
		#endregion
		#region SClass L3_AHbAC_1534 for attribute L3_AHbAC_1534
		[DataContract]
		public class L3_AHbAC_1534 
		{
			//Standard type parameters
			[DataMember]
			public Guid MRS_MPT_AddressHistoryID { get; set; } 
			[DataMember]
			public Guid MeasuringPoint_RefID { get; set; } 
			[DataMember]
			public Guid Address_RefID { get; set; } 
			[DataMember]
			public String ActiveFrom { get; set; } 
			[DataMember]
			public String ActiveThrough { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3_AHbAC_1534_Array cls_AdressHistory_by_AccountCode(,P_L3_AHbAC_1534 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3_AHbAC_1534_Array invocationResult = cls_AdressHistory_by_AccountCode.Invoke(connectionString,P_L3_AHbAC_1534 Parameter,securityTicket);
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
var parameter = new CL3_MeasuringPoints.Atomic.Retrieval.P_L3_AHbAC_1534();
parameter.AccountCode = ...;
parameter.DownloadCode = ...;

*/
