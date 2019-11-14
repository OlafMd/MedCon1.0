/* 
 * Generated on 6/26/2015 3:34:21 PM
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
    /// var result = cls_Get_Number_of_Edifacts.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Number_of_Edifacts
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ARCH_GNoE_0910 Execute(DbConnection Connection,DbTransaction Transaction,P_ARCH_GNoE_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ARCH_GNoE_0910();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Archive.Atomic.Retrieval.SQL.cls_Get_Number_of_Edifacts.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ContractID", Parameter.ContractID);



			List<ARCH_GNoE_0910> results = new List<ARCH_GNoE_0910>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "numberOfEdifacts" });
				while(reader.Read())
				{
					ARCH_GNoE_0910 resultItem = new ARCH_GNoE_0910();
					//0:Parameter numberOfEdifacts of type int
					resultItem.numberOfEdifacts = reader.GetInteger(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Number_of_Edifacts",ex);
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
		public static FR_ARCH_GNoE_0910 Invoke(string ConnectionString,P_ARCH_GNoE_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ARCH_GNoE_0910 Invoke(DbConnection Connection,P_ARCH_GNoE_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ARCH_GNoE_0910 Invoke(DbConnection Connection, DbTransaction Transaction,P_ARCH_GNoE_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ARCH_GNoE_0910 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ARCH_GNoE_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ARCH_GNoE_0910 functionReturn = new FR_ARCH_GNoE_0910();
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

				throw new Exception("Exception occured in method cls_Get_Number_of_Edifacts",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ARCH_GNoE_0910 : FR_Base
	{
		public ARCH_GNoE_0910 Result	{ get; set; }

		public FR_ARCH_GNoE_0910() : base() {}

		public FR_ARCH_GNoE_0910(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ARCH_GNoE_0910 for attribute P_ARCH_GNoE_0910
		[DataContract]
		public class P_ARCH_GNoE_0910 
		{
			//Standard type parameters
			[DataMember]
			public String ContractID { get; set; } 

		}
		#endregion
		#region SClass ARCH_GNoE_0910 for attribute ARCH_GNoE_0910
		[DataContract]
		public class ARCH_GNoE_0910 
		{
			//Standard type parameters
			[DataMember]
			public int numberOfEdifacts { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ARCH_GNoE_0910 cls_Get_Number_of_Edifacts(,P_ARCH_GNoE_0910 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ARCH_GNoE_0910 invocationResult = cls_Get_Number_of_Edifacts.Invoke(connectionString,P_ARCH_GNoE_0910 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Archive.Atomic.Retrieval.P_ARCH_GNoE_0910();
parameter.ContractID = ...;

*/
