/* 
 * Generated on 2/13/2014 10:49:32 AM
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

namespace CL5_Lucentis_Practice.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Practice_SimpleData_for_Tennant_EM.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Practice_SimpleData_for_Tennant_EM
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_GPSDfTEM_1404_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_GPSDfTEM_1404_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Practice.Atomic.Retrieval.SQL.cls_Get_Practice_SimpleData_for_Tennant_EM.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<GPSDfTEM_1404> results = new List<GPSDfTEM_1404>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_MedicalPractiseID","DisplayName","CMN_BPT_BusinessParticipantID","CompanyInfo_EstablishmentNumber" });
				while(reader.Read())
				{
					GPSDfTEM_1404 resultItem = new GPSDfTEM_1404();
					//0:Parameter HEC_MedicalPractiseID of type Guid
					resultItem.HEC_MedicalPractiseID = reader.GetGuid(0);
					//1:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(1);
					//2:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(2);
					//3:Parameter CompanyInfo_EstablishmentNumber of type String
					resultItem.CompanyInfo_EstablishmentNumber = reader.GetString(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Practice_SimpleData_for_Tennant_EM",ex);
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
		public static FR_GPSDfTEM_1404_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_GPSDfTEM_1404_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_GPSDfTEM_1404_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_GPSDfTEM_1404_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_GPSDfTEM_1404_Array functionReturn = new FR_GPSDfTEM_1404_Array();
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

				throw new Exception("Exception occured in method cls_Get_Practice_SimpleData_for_Tennant_EM",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_GPSDfTEM_1404_Array : FR_Base
	{
		public GPSDfTEM_1404[] Result	{ get; set; } 
		public FR_GPSDfTEM_1404_Array() : base() {}

		public FR_GPSDfTEM_1404_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass GPSDfTEM_1404 for attribute GPSDfTEM_1404
		[DataContract]
		public class GPSDfTEM_1404 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String CompanyInfo_EstablishmentNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_GPSDfTEM_1404_Array cls_Get_Practice_SimpleData_for_Tennant_EM(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_GPSDfTEM_1404_Array invocationResult = cls_Get_Practice_SimpleData_for_Tennant_EM.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

