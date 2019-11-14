/* 
 * Generated on 6/25/2015 3:58:10 PM
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

namespace MMDocConnectDBMethods.Archive.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Contract_Characteristic.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Contract_Characteristic
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ARCH_GCC_1510 Execute(DbConnection Connection,DbTransaction Transaction,P_ARCH_GCC_1510 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ARCH_GCC_1510();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Archive.Atomic.Retrieval.SQL.cls_Get_Contract_Characteristic.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ContractID", Parameter.ContractID);



			List<ARCH_GCC_1510> results = new List<ARCH_GCC_1510>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "contractCharacteristicID" });
				while(reader.Read())
				{
					ARCH_GCC_1510 resultItem = new ARCH_GCC_1510();
					//0:Parameter contractCharacteristicID of type String
					resultItem.contractCharacteristicID = reader.GetString(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Contract_Characteristic",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_ARCH_GCC_1510 Invoke(string ConnectionString,P_ARCH_GCC_1510 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ARCH_GCC_1510 Invoke(DbConnection Connection,P_ARCH_GCC_1510 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ARCH_GCC_1510 Invoke(DbConnection Connection, DbTransaction Transaction,P_ARCH_GCC_1510 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ARCH_GCC_1510 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ARCH_GCC_1510 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ARCH_GCC_1510 functionReturn = new FR_ARCH_GCC_1510();
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

				throw new Exception("Exception occured in method cls_Get_Contract_Characteristic",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ARCH_GCC_1510 : FR_Base
	{
		public ARCH_GCC_1510 Result	{ get; set; }

		public FR_ARCH_GCC_1510() : base() {}

		public FR_ARCH_GCC_1510(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ARCH_GCC_1510 for attribute P_ARCH_GCC_1510
		[DataContract]
		public class P_ARCH_GCC_1510 
		{
			//Standard type parameters
			[DataMember]
			public Guid ContractID { get; set; } 

		}
		#endregion
		#region SClass ARCH_GCC_1510 for attribute ARCH_GCC_1510
		[DataContract]
		public class ARCH_GCC_1510 
		{
			//Standard type parameters
			[DataMember]
			public String contractCharacteristicID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ARCH_GCC_1510 cls_Get_Contract_Characteristic(,P_ARCH_GCC_1510 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ARCH_GCC_1510 invocationResult = cls_Get_Contract_Characteristic.Invoke(connectionString,P_ARCH_GCC_1510 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Archive.Atomic.Retrieval.P_ARCH_GCC_1510();
parameter.ContractID = ...;

*/
