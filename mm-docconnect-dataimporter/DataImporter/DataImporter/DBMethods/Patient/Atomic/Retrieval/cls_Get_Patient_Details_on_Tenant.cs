/* 
 * Generated on 1/20/2017 2:31:26 PM
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

namespace DataImporter.DBMethods.Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Patient_Details_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Patient_Details_on_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PA_GPDoT_1803_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PA_GPDoT_1803_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_Patient_Details_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<PA_GPDoT_1803> results = new List<PA_GPDoT_1803>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "name","patient_first_name","patient_last_name","birthday","insurance_id","insurance_status","gender","health_insurance_provider","HealthInsurance_IKNumber","id" });
				while(reader.Read())
				{
					PA_GPDoT_1803 resultItem = new PA_GPDoT_1803();
					//0:Parameter name of type String
					resultItem.name = reader.GetString(0);
					//1:Parameter patient_first_name of type String
					resultItem.patient_first_name = reader.GetString(1);
					//2:Parameter patient_last_name of type String
					resultItem.patient_last_name = reader.GetString(2);
					//3:Parameter birthday of type DateTime
					resultItem.birthday = reader.GetDate(3);
					//4:Parameter insurance_id of type String
					resultItem.insurance_id = reader.GetString(4);
					//5:Parameter insurance_status of type String
					resultItem.insurance_status = reader.GetString(5);
					//6:Parameter gender of type int
					resultItem.gender = reader.GetInteger(6);
					//7:Parameter health_insurance_provider of type String
					resultItem.health_insurance_provider = reader.GetString(7);
					//8:Parameter HealthInsurance_IKNumber of type String
					resultItem.HealthInsurance_IKNumber = reader.GetString(8);
					//9:Parameter id of type Guid
					resultItem.id = reader.GetGuid(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Patient_Details_on_Tenant",ex);
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
		public static FR_PA_GPDoT_1803_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_GPDoT_1803_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_GPDoT_1803_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_GPDoT_1803_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_GPDoT_1803_Array functionReturn = new FR_PA_GPDoT_1803_Array();
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

				throw new Exception("Exception occured in method cls_Get_Patient_Details_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PA_GPDoT_1803_Array : FR_Base
	{
		public PA_GPDoT_1803[] Result	{ get; set; } 
		public FR_PA_GPDoT_1803_Array() : base() {}

		public FR_PA_GPDoT_1803_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass PA_GPDoT_1803 for attribute PA_GPDoT_1803
		[DataContract]
		public class PA_GPDoT_1803 
		{
			//Standard type parameters
			[DataMember]
			public String name { get; set; } 
			[DataMember]
			public String patient_first_name { get; set; } 
			[DataMember]
			public String patient_last_name { get; set; } 
			[DataMember]
			public DateTime birthday { get; set; } 
			[DataMember]
			public String insurance_id { get; set; } 
			[DataMember]
			public String insurance_status { get; set; } 
			[DataMember]
			public int gender { get; set; } 
			[DataMember]
			public String health_insurance_provider { get; set; } 
			[DataMember]
			public String HealthInsurance_IKNumber { get; set; } 
			[DataMember]
			public Guid id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_GPDoT_1803_Array cls_Get_Patient_Details_on_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GPDoT_1803_Array invocationResult = cls_Get_Patient_Details_on_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

