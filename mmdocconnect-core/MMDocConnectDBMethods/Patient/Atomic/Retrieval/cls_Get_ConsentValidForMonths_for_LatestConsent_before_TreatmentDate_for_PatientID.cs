/* 
 * Generated on 10/05/16 09:31:53
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
    /// var result = cls_Get_ConsentValidForMonths_for_LatestConsent_before_TreatmentDate_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ConsentValidForMonths_for_LatestConsent_before_TreatmentDate_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PA_GCVfMfLCbTDfPID_0930 Execute(DbConnection Connection,DbTransaction Transaction,P_PA_GCVfMfLCbTDfPID_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PA_GCVfMfLCbTDfPID_0930();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_ConsentValidForMonths_for_LatestConsent_before_TreatmentDate_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TreatmentDate", Parameter.TreatmentDate);



			List<PA_GCVfMfLCbTDfPID_0930> results = new List<PA_GCVfMfLCbTDfPID_0930>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "consent_valid_for_months" });
				while(reader.Read())
				{
					PA_GCVfMfLCbTDfPID_0930 resultItem = new PA_GCVfMfLCbTDfPID_0930();
					//0:Parameter consent_valid_for_months of type double
					resultItem.consent_valid_for_months = reader.GetDouble(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ConsentValidForMonths_for_LatestConsent_before_TreatmentDate_for_PatientID",ex);
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
		public static FR_PA_GCVfMfLCbTDfPID_0930 Invoke(string ConnectionString,P_PA_GCVfMfLCbTDfPID_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_GCVfMfLCbTDfPID_0930 Invoke(DbConnection Connection,P_PA_GCVfMfLCbTDfPID_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_GCVfMfLCbTDfPID_0930 Invoke(DbConnection Connection, DbTransaction Transaction,P_PA_GCVfMfLCbTDfPID_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_GCVfMfLCbTDfPID_0930 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PA_GCVfMfLCbTDfPID_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_GCVfMfLCbTDfPID_0930 functionReturn = new FR_PA_GCVfMfLCbTDfPID_0930();
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

				throw new Exception("Exception occured in method cls_Get_ConsentValidForMonths_for_LatestConsent_before_TreatmentDate_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PA_GCVfMfLCbTDfPID_0930 : FR_Base
	{
		public PA_GCVfMfLCbTDfPID_0930 Result	{ get; set; }

		public FR_PA_GCVfMfLCbTDfPID_0930() : base() {}

		public FR_PA_GCVfMfLCbTDfPID_0930(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PA_GCVfMfLCbTDfPID_0930 for attribute P_PA_GCVfMfLCbTDfPID_0930
		[DataContract]
		public class P_PA_GCVfMfLCbTDfPID_0930 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public DateTime TreatmentDate { get; set; } 

		}
		#endregion
		#region SClass PA_GCVfMfLCbTDfPID_0930 for attribute PA_GCVfMfLCbTDfPID_0930
		[DataContract]
		public class PA_GCVfMfLCbTDfPID_0930 
		{
			//Standard type parameters
			[DataMember]
			public double consent_valid_for_months { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_GCVfMfLCbTDfPID_0930 cls_Get_ConsentValidForMonths_for_LatestConsent_before_TreatmentDate_for_PatientID(,P_PA_GCVfMfLCbTDfPID_0930 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GCVfMfLCbTDfPID_0930 invocationResult = cls_Get_ConsentValidForMonths_for_LatestConsent_before_TreatmentDate_for_PatientID.Invoke(connectionString,P_PA_GCVfMfLCbTDfPID_0930 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Atomic.Retrieval.P_PA_GCVfMfLCbTDfPID_0930();
parameter.PatientID = ...;
parameter.TreatmentDate = ...;

*/