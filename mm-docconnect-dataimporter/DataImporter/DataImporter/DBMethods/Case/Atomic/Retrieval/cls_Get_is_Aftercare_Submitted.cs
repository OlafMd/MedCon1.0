/* 
 * Generated on 1/20/2017 2:33:27 PM
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
    /// var result = cls_Get_is_Aftercare_Submitted.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_is_Aftercare_Submitted
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GiAS_2345_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GiAS_2345 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GiAS_2345_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_is_Aftercare_Submitted.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AftercarePlannedActionTypeID", Parameter.AftercarePlannedActionTypeID);



			List<CAS_GiAS_2345> results = new List<CAS_GiAS_2345>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "is_aftercare_submitted","case_id" });
				while(reader.Read())
				{
					CAS_GiAS_2345 resultItem = new CAS_GiAS_2345();
					//0:Parameter is_aftercare_submitted of type Boolean
					resultItem.is_aftercare_submitted = reader.GetBoolean(0);
					//1:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_is_Aftercare_Submitted",ex);
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
		public static FR_CAS_GiAS_2345_Array Invoke(string ConnectionString,P_CAS_GiAS_2345 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GiAS_2345_Array Invoke(DbConnection Connection,P_CAS_GiAS_2345 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GiAS_2345_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GiAS_2345 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GiAS_2345_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GiAS_2345 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GiAS_2345_Array functionReturn = new FR_CAS_GiAS_2345_Array();
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

				throw new Exception("Exception occured in method cls_Get_is_Aftercare_Submitted",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GiAS_2345_Array : FR_Base
	{
		public CAS_GiAS_2345[] Result	{ get; set; } 
		public FR_CAS_GiAS_2345_Array() : base() {}

		public FR_CAS_GiAS_2345_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GiAS_2345 for attribute P_CAS_GiAS_2345
		[DataContract]
		public class P_CAS_GiAS_2345 
		{
			//Standard type parameters
			[DataMember]
			public Guid AftercarePlannedActionTypeID { get; set; } 

		}
		#endregion
		#region SClass CAS_GiAS_2345 for attribute CAS_GiAS_2345
		[DataContract]
		public class CAS_GiAS_2345 
		{
			//Standard type parameters
			[DataMember]
			public Boolean is_aftercare_submitted { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GiAS_2345_Array cls_Get_is_Aftercare_Submitted(,P_CAS_GiAS_2345 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GiAS_2345_Array invocationResult = cls_Get_is_Aftercare_Submitted.Invoke(connectionString,P_CAS_GiAS_2345 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Retrieval.P_CAS_GiAS_2345();
parameter.AftercarePlannedActionTypeID = ...;

*/
