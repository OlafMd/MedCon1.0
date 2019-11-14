/* 
 * Generated on 10/24/15 12:03:34
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

namespace MMDocConnectDBMethods.Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllContracts_for_Practice_Doctors.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllContracts_for_Practice_Doctors
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GACfPD_1252_Array Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GACfPD_1252 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GACfPD_1252_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_AllContracts_for_Practice_Doctors.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PracticeID", Parameter.PracticeID);



			List<DO_GACfPD_1252> results = new List<DO_GACfPD_1252>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_CTR_ContractID","ContractName","ValidFrom","ValidThrough","participation_consent_valid_days" });
				while(reader.Read())
				{
					DO_GACfPD_1252 resultItem = new DO_GACfPD_1252();
					//0:Parameter CMN_CTR_ContractID of type Guid
					resultItem.CMN_CTR_ContractID = reader.GetGuid(0);
					//1:Parameter ContractName of type String
					resultItem.ContractName = reader.GetString(1);
					//2:Parameter ValidFrom of type DateTime
					resultItem.ValidFrom = reader.GetDate(2);
					//3:Parameter ValidThrough of type DateTime
					resultItem.ValidThrough = reader.GetDate(3);
					//4:Parameter participation_consent_valid_days of type double
					resultItem.participation_consent_valid_days = reader.GetDouble(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllContracts_for_Practice_Doctors",ex);
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
		public static FR_DO_GACfPD_1252_Array Invoke(string ConnectionString,P_DO_GACfPD_1252 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GACfPD_1252_Array Invoke(DbConnection Connection,P_DO_GACfPD_1252 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GACfPD_1252_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GACfPD_1252 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GACfPD_1252_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GACfPD_1252 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GACfPD_1252_Array functionReturn = new FR_DO_GACfPD_1252_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllContracts_for_Practice_Doctors",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GACfPD_1252_Array : FR_Base
	{
		public DO_GACfPD_1252[] Result	{ get; set; } 
		public FR_DO_GACfPD_1252_Array() : base() {}

		public FR_DO_GACfPD_1252_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GACfPD_1252 for attribute P_DO_GACfPD_1252
		[DataContract]
		public class P_DO_GACfPD_1252 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 

		}
		#endregion
		#region SClass DO_GACfPD_1252 for attribute DO_GACfPD_1252
		[DataContract]
		public class DO_GACfPD_1252 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_CTR_ContractID { get; set; } 
			[DataMember]
			public String ContractName { get; set; } 
			[DataMember]
			public DateTime ValidFrom { get; set; } 
			[DataMember]
			public DateTime ValidThrough { get; set; } 
			[DataMember]
			public double participation_consent_valid_days { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GACfPD_1252_Array cls_Get_AllContracts_for_Practice_Doctors(,P_DO_GACfPD_1252 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GACfPD_1252_Array invocationResult = cls_Get_AllContracts_for_Practice_Doctors.Invoke(connectionString,P_DO_GACfPD_1252 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Atomic.Retrieval.P_DO_GACfPD_1252();
parameter.PracticeID = ...;

*/
