/* 
 * Generated on 3/14/2017 2:49:07 PM
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

namespace DataImporter.DBMethods.ExportData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Patients_from_DB.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Patients_from_DB
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GAPDB_1001_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GAPDB_1001_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_All_Patients_from_DB.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<DO_GAPDB_1001> results = new List<DO_GAPDB_1001>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Id","HIPID","PracticeID","FirstName","LastName","BirthDate","ValidFrom","ValidThrough","Gender","HipNumber","InsuranceStatus","HealthInsurance_IKNumber" });
				while(reader.Read())
				{
					DO_GAPDB_1001 resultItem = new DO_GAPDB_1001();
					//0:Parameter Id of type Guid
					resultItem.Id = reader.GetGuid(0);
					//1:Parameter HIPID of type Guid
					resultItem.HIPID = reader.GetGuid(1);
					//2:Parameter PracticeID of type Guid
					resultItem.PracticeID = reader.GetGuid(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter LastName of type String
					resultItem.LastName = reader.GetString(4);
					//5:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(5);
					//6:Parameter ValidFrom of type DateTime
					resultItem.ValidFrom = reader.GetDate(6);
					//7:Parameter ValidThrough of type DateTime
					resultItem.ValidThrough = reader.GetDate(7);
					//8:Parameter Gender of type Double
					resultItem.Gender = reader.GetDouble(8);
					//9:Parameter HipNumber of type String
					resultItem.HipNumber = reader.GetString(9);
					//10:Parameter InsuranceStatus of type String
					resultItem.InsuranceStatus = reader.GetString(10);
					//11:Parameter HealthInsurance_IKNumber of type String
					resultItem.HealthInsurance_IKNumber = reader.GetString(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Patients_from_DB",ex);
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
		public static FR_DO_GAPDB_1001_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GAPDB_1001_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GAPDB_1001_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GAPDB_1001_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GAPDB_1001_Array functionReturn = new FR_DO_GAPDB_1001_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Patients_from_DB",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GAPDB_1001_Array : FR_Base
	{
		public DO_GAPDB_1001[] Result	{ get; set; } 
		public FR_DO_GAPDB_1001_Array() : base() {}

		public FR_DO_GAPDB_1001_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass DO_GAPDB_1001 for attribute DO_GAPDB_1001
		[DataContract]
		public class DO_GAPDB_1001 
		{
			//Standard type parameters
			[DataMember]
			public Guid Id { get; set; } 
			[DataMember]
			public Guid HIPID { get; set; } 
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public DateTime ValidFrom { get; set; } 
			[DataMember]
			public DateTime ValidThrough { get; set; } 
			[DataMember]
			public Double Gender { get; set; } 
			[DataMember]
			public String HipNumber { get; set; } 
			[DataMember]
			public String InsuranceStatus { get; set; } 
			[DataMember]
			public String HealthInsurance_IKNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GAPDB_1001_Array cls_Get_All_Patients_from_DB(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GAPDB_1001_Array invocationResult = cls_Get_All_Patients_from_DB.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

