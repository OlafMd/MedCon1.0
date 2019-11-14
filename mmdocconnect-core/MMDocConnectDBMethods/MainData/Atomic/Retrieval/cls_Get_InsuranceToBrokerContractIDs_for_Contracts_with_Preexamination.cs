/* 
 * Generated on 3/23/2017 10:38:19 AM
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
    /// var result = cls_Get_InsuranceToBrokerContractIDs_for_Contracts_with_Preexamination.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_InsuranceToBrokerContractIDs_for_Contracts_with_Preexamination
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MD_GITBCIDSfCwPE_1558_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_MD_GITBCIDSfCwPE_1558_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.MainData.Atomic.Retrieval.SQL.cls_Get_InsuranceToBrokerContractIDs_for_Contracts_with_Preexamination.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<MD_GITBCIDSfCwPE_1558> results = new List<MD_GITBCIDSfCwPE_1558>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "InsuranceToBrokerContractID","ContractID" });
				while(reader.Read())
				{
					MD_GITBCIDSfCwPE_1558 resultItem = new MD_GITBCIDSfCwPE_1558();
					//0:Parameter InsuranceToBrokerContractID of type Guid
					resultItem.InsuranceToBrokerContractID = reader.GetGuid(0);
					//1:Parameter ContractID of type Guid
					resultItem.ContractID = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_InsuranceToBrokerContractIDs_for_Contracts_with_Preexamination",ex);
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
		public static FR_MD_GITBCIDSfCwPE_1558_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MD_GITBCIDSfCwPE_1558_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MD_GITBCIDSfCwPE_1558_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MD_GITBCIDSfCwPE_1558_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MD_GITBCIDSfCwPE_1558_Array functionReturn = new FR_MD_GITBCIDSfCwPE_1558_Array();
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

				throw new Exception("Exception occured in method cls_Get_InsuranceToBrokerContractIDs_for_Contracts_with_Preexamination",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_MD_GITBCIDSfCwPE_1558_Array : FR_Base
	{
		public MD_GITBCIDSfCwPE_1558[] Result	{ get; set; } 
		public FR_MD_GITBCIDSfCwPE_1558_Array() : base() {}

		public FR_MD_GITBCIDSfCwPE_1558_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass MD_GITBCIDSfCwPE_1558 for attribute MD_GITBCIDSfCwPE_1558
		[DataContract]
		public class MD_GITBCIDSfCwPE_1558 
		{
			//Standard type parameters
			[DataMember]
			public Guid InsuranceToBrokerContractID { get; set; } 
			[DataMember]
			public Guid ContractID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MD_GITBCIDSfCwPE_1558_Array cls_Get_InsuranceToBrokerContractIDs_for_Contracts_with_Preexamination(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GITBCIDSfCwPE_1558_Array invocationResult = cls_Get_InsuranceToBrokerContractIDs_for_Contracts_with_Preexamination.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

