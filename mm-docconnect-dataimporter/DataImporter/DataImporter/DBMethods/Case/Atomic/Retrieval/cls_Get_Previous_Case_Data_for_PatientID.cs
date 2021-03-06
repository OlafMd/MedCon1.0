/* 
 * Generated on 1/20/2017 2:33:28 PM
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
    /// var result = cls_Get_Previous_Case_Data_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Previous_Case_Data_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GPCDfPID_1144 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GPCDfPID_1144 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GPCDfPID_1144();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Previous_Case_Data_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<CAS_GPCDfPID_1144> results = new List<CAS_GPCDfPID_1144>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "treatment_doctor_id","diagnose_id","localization","aftercare_doctor_id","is_aftercare_doctor","aftercare_doctor_display_name","aftercare_practice_display_name","aftercare_practice_id","is_diagnosis_confirmed" });
				while(reader.Read())
				{
					CAS_GPCDfPID_1144 resultItem = new CAS_GPCDfPID_1144();
					//0:Parameter treatment_doctor_id of type Guid
					resultItem.treatment_doctor_id = reader.GetGuid(0);
					//1:Parameter diagnose_id of type Guid
					resultItem.diagnose_id = reader.GetGuid(1);
					//2:Parameter localization of type String
					resultItem.localization = reader.GetString(2);
					//3:Parameter aftercare_doctor_id of type Guid
					resultItem.aftercare_doctor_id = reader.GetGuid(3);
					//4:Parameter is_aftercare_doctor of type Boolean
					resultItem.is_aftercare_doctor = reader.GetBoolean(4);
					//5:Parameter aftercare_doctor_display_name of type String
					resultItem.aftercare_doctor_display_name = reader.GetString(5);
					//6:Parameter aftercare_practice_display_name of type String
					resultItem.aftercare_practice_display_name = reader.GetString(6);
					//7:Parameter aftercare_practice_id of type Guid
					resultItem.aftercare_practice_id = reader.GetGuid(7);
					//8:Parameter is_diagnosis_confirmed of type Boolean
					resultItem.is_diagnosis_confirmed = reader.GetBoolean(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Previous_Case_Data_for_PatientID",ex);
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
		public static FR_CAS_GPCDfPID_1144 Invoke(string ConnectionString,P_CAS_GPCDfPID_1144 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GPCDfPID_1144 Invoke(DbConnection Connection,P_CAS_GPCDfPID_1144 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GPCDfPID_1144 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GPCDfPID_1144 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GPCDfPID_1144 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GPCDfPID_1144 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GPCDfPID_1144 functionReturn = new FR_CAS_GPCDfPID_1144();
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

				throw new Exception("Exception occured in method cls_Get_Previous_Case_Data_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GPCDfPID_1144 : FR_Base
	{
		public CAS_GPCDfPID_1144 Result	{ get; set; }

		public FR_CAS_GPCDfPID_1144() : base() {}

		public FR_CAS_GPCDfPID_1144(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GPCDfPID_1144 for attribute P_CAS_GPCDfPID_1144
		[DataContract]
		public class P_CAS_GPCDfPID_1144 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass CAS_GPCDfPID_1144 for attribute CAS_GPCDfPID_1144
		[DataContract]
		public class CAS_GPCDfPID_1144 
		{
			//Standard type parameters
			[DataMember]
			public Guid treatment_doctor_id { get; set; } 
			[DataMember]
			public Guid diagnose_id { get; set; } 
			[DataMember]
			public String localization { get; set; } 
			[DataMember]
			public Guid aftercare_doctor_id { get; set; } 
			[DataMember]
			public Boolean is_aftercare_doctor { get; set; } 
			[DataMember]
			public String aftercare_doctor_display_name { get; set; } 
			[DataMember]
			public String aftercare_practice_display_name { get; set; } 
			[DataMember]
			public Guid aftercare_practice_id { get; set; } 
			[DataMember]
			public Boolean is_diagnosis_confirmed { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GPCDfPID_1144 cls_Get_Previous_Case_Data_for_PatientID(,P_CAS_GPCDfPID_1144 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GPCDfPID_1144 invocationResult = cls_Get_Previous_Case_Data_for_PatientID.Invoke(connectionString,P_CAS_GPCDfPID_1144 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Retrieval.P_CAS_GPCDfPID_1144();
parameter.PatientID = ...;

*/
