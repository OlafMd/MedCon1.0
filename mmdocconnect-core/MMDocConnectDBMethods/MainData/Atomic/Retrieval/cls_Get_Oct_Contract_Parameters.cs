/* 
 * Generated on 10/05/16 15:32:55
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

namespace MMDocConnectDBMethods.MainData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Oct_Contract_Parameters.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Oct_Contract_Parameters
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MD_GOctCP_1756_Array Execute(DbConnection Connection,DbTransaction Transaction,P_MD_GOctCP_1756 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_MD_GOctCP_1756_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.MainData.Atomic.Retrieval.SQL.cls_Get_Oct_Contract_Parameters.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"GposCatalogID", Parameter.GposCatalogID);



			List<MD_GOctCP_1756> results = new List<MD_GOctCP_1756>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Contract_RefID","ParameterName","IfStringValue_Value","IfNumericValue_Value","IfBooleanValue_Value" });
				while(reader.Read())
				{
					MD_GOctCP_1756 resultItem = new MD_GOctCP_1756();
					//0:Parameter Contract_RefID of type Guid
					resultItem.Contract_RefID = reader.GetGuid(0);
					//1:Parameter ParameterName of type String
					resultItem.ParameterName = reader.GetString(1);
					//2:Parameter IfStringValue_Value of type String
					resultItem.IfStringValue_Value = reader.GetString(2);
					//3:Parameter IfNumericValue_Value of type double
					resultItem.IfNumericValue_Value = reader.GetDouble(3);
					//4:Parameter IfBooleanValue_Value of type Boolean
					resultItem.IfBooleanValue_Value = reader.GetBoolean(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Oct_Contract_Parameters",ex);
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
		public static FR_MD_GOctCP_1756_Array Invoke(string ConnectionString,P_MD_GOctCP_1756 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MD_GOctCP_1756_Array Invoke(DbConnection Connection,P_MD_GOctCP_1756 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MD_GOctCP_1756_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_MD_GOctCP_1756 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MD_GOctCP_1756_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_MD_GOctCP_1756 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MD_GOctCP_1756_Array functionReturn = new FR_MD_GOctCP_1756_Array();
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

				throw new Exception("Exception occured in method cls_Get_Oct_Contract_Parameters",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_MD_GOctCP_1756_Array : FR_Base
	{
		public MD_GOctCP_1756[] Result	{ get; set; } 
		public FR_MD_GOctCP_1756_Array() : base() {}

		public FR_MD_GOctCP_1756_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_MD_GOctCP_1756 for attribute P_MD_GOctCP_1756
		[DataContract]
		public class P_MD_GOctCP_1756 
		{
			//Standard type parameters
			[DataMember]
			public String GposCatalogID { get; set; } 

		}
		#endregion
		#region SClass MD_GOctCP_1756 for attribute MD_GOctCP_1756
		[DataContract]
		public class MD_GOctCP_1756 
		{
			//Standard type parameters
			[DataMember]
			public Guid Contract_RefID { get; set; } 
			[DataMember]
			public String ParameterName { get; set; } 
			[DataMember]
			public String IfStringValue_Value { get; set; } 
			[DataMember]
			public double IfNumericValue_Value { get; set; } 
			[DataMember]
			public Boolean IfBooleanValue_Value { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MD_GOctCP_1756_Array cls_Get_Oct_Contract_Parameters(,P_MD_GOctCP_1756 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GOctCP_1756_Array invocationResult = cls_Get_Oct_Contract_Parameters.Invoke(connectionString,P_MD_GOctCP_1756 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Retrieval.P_MD_GOctCP_1756();
parameter.GposCatalogID = ...;

*/
