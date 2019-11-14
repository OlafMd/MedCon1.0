/* 
 * Generated on 19-Nov-14 11:35:29 AM
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

namespace CL6_DanuTask_PriceGrade.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PriceGrades_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PriceGrades_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PG_GPGfT_1132_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6PG_GPGfT_1132_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_DanuTask_PriceGrade.Atomic.Retrieval.SQL.cls_Get_PriceGrades_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L6PG_GPGfT_1132> results = new List<L6PG_GPGfT_1132>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PriceAmount","CurrencyName","ChangingLevel_Name_DictID","CMN_BPT_InvestedWorkTime_ChargingLevelID","Tenant_RefID" });
				while(reader.Read())
				{
					L6PG_GPGfT_1132 resultItem = new L6PG_GPGfT_1132();
					//0:Parameter PriceAmount of type String
					resultItem.PriceAmount = reader.GetString(0);
					//1:Parameter CurrencyName of type Dict
					resultItem.CurrencyName = reader.GetDictionary(1);
					resultItem.CurrencyName.SourceTable = "cmn_currencies";
					loader.Append(resultItem.CurrencyName);
					//2:Parameter ChangingLevel_Name of type Dict
					resultItem.ChangingLevel_Name = reader.GetDictionary(2);
					resultItem.ChangingLevel_Name.SourceTable = "cmn_bpt_investedworktime_charginglevels";
					loader.Append(resultItem.ChangingLevel_Name);
					//3:Parameter CMN_BPT_InvestedWorkTime_ChargingLevelID of type Guid
					resultItem.CMN_BPT_InvestedWorkTime_ChargingLevelID = reader.GetGuid(3);
					//4:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PriceGrades_for_Tenant",ex);
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
		public static FR_L6PG_GPGfT_1132_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PG_GPGfT_1132_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PG_GPGfT_1132_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PG_GPGfT_1132_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PG_GPGfT_1132_Array functionReturn = new FR_L6PG_GPGfT_1132_Array();
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

				throw new Exception("Exception occured in method cls_Get_PriceGrades_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PG_GPGfT_1132_Array : FR_Base
	{
		public L6PG_GPGfT_1132[] Result	{ get; set; } 
		public FR_L6PG_GPGfT_1132_Array() : base() {}

		public FR_L6PG_GPGfT_1132_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6PG_GPGfT_1132 for attribute L6PG_GPGfT_1132
		[DataContract]
		public class L6PG_GPGfT_1132 
		{
			//Standard type parameters
			[DataMember]
			public String PriceAmount { get; set; } 
			[DataMember]
			public Dict CurrencyName { get; set; } 
			[DataMember]
			public Dict ChangingLevel_Name { get; set; } 
			[DataMember]
			public Guid CMN_BPT_InvestedWorkTime_ChargingLevelID { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PG_GPGfT_1132_Array cls_Get_PriceGrades_for_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PG_GPGfT_1132_Array invocationResult = cls_Get_PriceGrades_for_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

