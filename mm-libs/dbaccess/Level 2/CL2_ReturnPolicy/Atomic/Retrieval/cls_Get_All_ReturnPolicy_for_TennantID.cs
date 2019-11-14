/* 
 * Generated on 6/10/2014 2:56:58 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL2_ReturnPolicy.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_ReturnPolicy_for_TennantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_ReturnPolicy_for_TennantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2RP_GARPfT_1630_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2RP_GARPfT_1630_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_ReturnPolicy.Atomic.Retrieval.SQL.cls_Get_All_ReturnPolicy_for_TennantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2RP_GARPfT_1630> results = new List<L2RP_GARPfT_1630>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_RET_ReturnPolicyID","GlobalPropertyMatchingID","ReturnPolicy_Abbreviation","ReturnPolicy_Reason_DictID","Tenant_RefID","PriceValue_Amount","PriceValue_Currency_RefID" });
				while(reader.Read())
				{
					L2RP_GARPfT_1630 resultItem = new L2RP_GARPfT_1630();
					//0:Parameter LOG_RET_ReturnPolicyID of type Guid
					resultItem.LOG_RET_ReturnPolicyID = reader.GetGuid(0);
					//1:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(1);
					//2:Parameter ReturnPolicy_Abbreviation of type String
					resultItem.ReturnPolicy_Abbreviation = reader.GetString(2);
					//3:Parameter ReturnPolicy_Reason of type Dict
					resultItem.ReturnPolicy_Reason = reader.GetDictionary(3);
					resultItem.ReturnPolicy_Reason.SourceTable = "log_ret_returnpolicies";
					loader.Append(resultItem.ReturnPolicy_Reason);
					//4:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(4);
					//5:Parameter PriceValue_Amount of type Double
					resultItem.PriceValue_Amount = reader.GetDouble(5);
					//6:Parameter PriceValue_Currency_RefID of type Guid
					resultItem.PriceValue_Currency_RefID = reader.GetGuid(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_ReturnPolicy_for_TennantID",ex);
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
		public static FR_L2RP_GARPfT_1630_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2RP_GARPfT_1630_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2RP_GARPfT_1630_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2RP_GARPfT_1630_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2RP_GARPfT_1630_Array functionReturn = new FR_L2RP_GARPfT_1630_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_ReturnPolicy_for_TennantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2RP_GARPfT_1630_Array : FR_Base
	{
		public L2RP_GARPfT_1630[] Result	{ get; set; } 
		public FR_L2RP_GARPfT_1630_Array() : base() {}

		public FR_L2RP_GARPfT_1630_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2RP_GARPfT_1630 for attribute L2RP_GARPfT_1630
		[DataContract]
		public class L2RP_GARPfT_1630 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RET_ReturnPolicyID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String ReturnPolicy_Abbreviation { get; set; } 
			[DataMember]
			public Dict ReturnPolicy_Reason { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Double PriceValue_Amount { get; set; } 
			[DataMember]
			public Guid PriceValue_Currency_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2RP_GARPfT_1630_Array cls_Get_All_ReturnPolicy_for_TennantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2RP_GARPfT_1630_Array invocationResult = cls_Get_All_ReturnPolicy_for_TennantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

