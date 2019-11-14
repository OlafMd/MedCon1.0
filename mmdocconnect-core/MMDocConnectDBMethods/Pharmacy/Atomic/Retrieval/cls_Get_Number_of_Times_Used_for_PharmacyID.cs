/* 
 * Generated on 2/2/2017 4:30:09 PM
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

namespace MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Number_of_Times_Used_for_PharmacyID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Number_of_Times_Used_for_PharmacyID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PH_GNoTUfPID_1626 Execute(DbConnection Connection,DbTransaction Transaction,P_PH_GNoTUfPID_1626 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PH_GNoTUfPID_1626();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval.SQL.cls_Get_Number_of_Times_Used_for_PharmacyID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PharmacyID", Parameter.PharmacyID);



			List<PH_GNoTUfPID_1626> results = new List<PH_GNoTUfPID_1626>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "NumberOfUsages" });
				while(reader.Read())
				{
					PH_GNoTUfPID_1626 resultItem = new PH_GNoTUfPID_1626();
					//0:Parameter NumberOfUsages of type int
					resultItem.NumberOfUsages = reader.GetInteger(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Number_of_Times_Used_for_PharmacyID",ex);
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
		public static FR_PH_GNoTUfPID_1626 Invoke(string ConnectionString,P_PH_GNoTUfPID_1626 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PH_GNoTUfPID_1626 Invoke(DbConnection Connection,P_PH_GNoTUfPID_1626 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PH_GNoTUfPID_1626 Invoke(DbConnection Connection, DbTransaction Transaction,P_PH_GNoTUfPID_1626 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PH_GNoTUfPID_1626 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PH_GNoTUfPID_1626 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PH_GNoTUfPID_1626 functionReturn = new FR_PH_GNoTUfPID_1626();
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

				throw new Exception("Exception occured in method cls_Get_Number_of_Times_Used_for_PharmacyID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PH_GNoTUfPID_1626 : FR_Base
	{
		public PH_GNoTUfPID_1626 Result	{ get; set; }

		public FR_PH_GNoTUfPID_1626() : base() {}

		public FR_PH_GNoTUfPID_1626(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PH_GNoTUfPID_1626 for attribute P_PH_GNoTUfPID_1626
		[DataContract]
		public class P_PH_GNoTUfPID_1626 
		{
			//Standard type parameters
			[DataMember]
			public Guid PharmacyID { get; set; } 

		}
		#endregion
		#region SClass PH_GNoTUfPID_1626 for attribute PH_GNoTUfPID_1626
		[DataContract]
		public class PH_GNoTUfPID_1626 
		{
			//Standard type parameters
			[DataMember]
			public int NumberOfUsages { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PH_GNoTUfPID_1626 cls_Get_Number_of_Times_Used_for_PharmacyID(,P_PH_GNoTUfPID_1626 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PH_GNoTUfPID_1626 invocationResult = cls_Get_Number_of_Times_Used_for_PharmacyID.Invoke(connectionString,P_PH_GNoTUfPID_1626 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval.P_PH_GNoTUfPID_1626();
parameter.PharmacyID = ...;

*/
