/* 
 * Generated on 11/09/15 13:32:07
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
    /// var result = cls_Get_PatientEdit_Data_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientEdit_Data_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PA_GPDfPID_1101 Execute(DbConnection Connection,DbTransaction Transaction,P_PA_GPDfPID_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PA_GPDfPID_1101();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_PatientEdit_Data_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<PA_GPDfPID_1101> results = new List<PA_GPDfPID_1101>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "id","first_name","last_name","birthday","sex","insurance_id","health_insurance_provider_id","valid_from","contract_id","insurance_status","participation_id","hip_ik_number","hip_name","hip_display_name" });
				while(reader.Read())
				{
					PA_GPDfPID_1101 resultItem = new PA_GPDfPID_1101();
					//0:Parameter id of type Guid
					resultItem.id = reader.GetGuid(0);
					//1:Parameter first_name of type String
					resultItem.first_name = reader.GetString(1);
					//2:Parameter last_name of type String
					resultItem.last_name = reader.GetString(2);
					//3:Parameter birthday of type DateTime
					resultItem.birthday = reader.GetDate(3);
					//4:Parameter sex of type int
					resultItem.sex = reader.GetInteger(4);
					//5:Parameter insurance_id of type String
					resultItem.insurance_id = reader.GetString(5);
					//6:Parameter health_insurance_provider_id of type Guid
					resultItem.health_insurance_provider_id = reader.GetGuid(6);
					//7:Parameter valid_from of type DateTime
					resultItem.valid_from = reader.GetDate(7);
					//8:Parameter contract_id of type Guid
					resultItem.contract_id = reader.GetGuid(8);
					//9:Parameter insurance_status of type String
					resultItem.insurance_status = reader.GetString(9);
					//10:Parameter participation_id of type Guid
					resultItem.participation_id = reader.GetGuid(10);
					//11:Parameter hip_ik_number of type String
					resultItem.hip_ik_number = reader.GetString(11);
					//12:Parameter hip_name of type String
					resultItem.hip_name = reader.GetString(12);
					//13:Parameter hip_display_name of type String
					resultItem.hip_display_name = reader.GetString(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PatientEdit_Data_for_PatientID",ex);
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
		public static FR_PA_GPDfPID_1101 Invoke(string ConnectionString,P_PA_GPDfPID_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_GPDfPID_1101 Invoke(DbConnection Connection,P_PA_GPDfPID_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_GPDfPID_1101 Invoke(DbConnection Connection, DbTransaction Transaction,P_PA_GPDfPID_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_GPDfPID_1101 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PA_GPDfPID_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_GPDfPID_1101 functionReturn = new FR_PA_GPDfPID_1101();
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

				throw new Exception("Exception occured in method cls_Get_PatientEdit_Data_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PA_GPDfPID_1101 : FR_Base
	{
		public PA_GPDfPID_1101 Result	{ get; set; }

		public FR_PA_GPDfPID_1101() : base() {}

		public FR_PA_GPDfPID_1101(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PA_GPDfPID_1101 for attribute P_PA_GPDfPID_1101
		[DataContract]
		public class P_PA_GPDfPID_1101 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass PA_GPDfPID_1101 for attribute PA_GPDfPID_1101
		[DataContract]
		public class PA_GPDfPID_1101 
		{
			//Standard type parameters
			[DataMember]
			public Guid id { get; set; } 
			[DataMember]
			public String first_name { get; set; } 
			[DataMember]
			public String last_name { get; set; } 
			[DataMember]
			public DateTime birthday { get; set; } 
			[DataMember]
			public int sex { get; set; } 
			[DataMember]
			public String insurance_id { get; set; } 
			[DataMember]
			public Guid health_insurance_provider_id { get; set; } 
			[DataMember]
			public DateTime valid_from { get; set; } 
			[DataMember]
			public Guid contract_id { get; set; } 
			[DataMember]
			public String insurance_status { get; set; } 
			[DataMember]
			public Guid participation_id { get; set; } 
			[DataMember]
			public String hip_ik_number { get; set; } 
			[DataMember]
			public String hip_name { get; set; } 
			[DataMember]
			public String hip_display_name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_GPDfPID_1101 cls_Get_PatientEdit_Data_for_PatientID(,P_PA_GPDfPID_1101 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GPDfPID_1101 invocationResult = cls_Get_PatientEdit_Data_for_PatientID.Invoke(connectionString,P_PA_GPDfPID_1101 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Atomic.Retrieval.P_PA_GPDfPID_1101();
parameter.PatientID = ...;

*/
