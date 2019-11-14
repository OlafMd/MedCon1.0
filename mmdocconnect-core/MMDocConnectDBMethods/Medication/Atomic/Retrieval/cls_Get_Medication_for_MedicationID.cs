/* 
 * Generated on 10/05/15 14:16:20
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

namespace MMDocConnectDBMethods.Medication.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Medication_for_MedicationID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Medication_for_MedicationID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MC_GMfMID_1433 Execute(DbConnection Connection,DbTransaction Transaction,P_MC_GMfMID_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_MC_GMfMID_1433();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Medication.Atomic.Retrieval.SQL.cls_Get_Medication_for_MedicationID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"MedicationID", Parameter.MedicationID);



			List<MC_GMfMID_1433> results = new List<MC_GMfMID_1433>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "MedicationID","Medication","ProprietaryDrug","PZNScheme","HecDrugID" });
				while(reader.Read())
				{
					MC_GMfMID_1433 resultItem = new MC_GMfMID_1433();
					//0:Parameter MedicationID of type Guid
					resultItem.MedicationID = reader.GetGuid(0);
					//1:Parameter Medication of type string
					resultItem.Medication = reader.GetString(1);
					//2:Parameter ProprietaryDrug of type bool
					resultItem.ProprietaryDrug = reader.GetBoolean(2);
					//3:Parameter PZNScheme of type string
					resultItem.PZNScheme = reader.GetString(3);
					//4:Parameter HecDrugID of type Guid
					resultItem.HecDrugID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Medication_for_MedicationID",ex);
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
		public static FR_MC_GMfMID_1433 Invoke(string ConnectionString,P_MC_GMfMID_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MC_GMfMID_1433 Invoke(DbConnection Connection,P_MC_GMfMID_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MC_GMfMID_1433 Invoke(DbConnection Connection, DbTransaction Transaction,P_MC_GMfMID_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MC_GMfMID_1433 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_MC_GMfMID_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MC_GMfMID_1433 functionReturn = new FR_MC_GMfMID_1433();
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

				throw new Exception("Exception occured in method cls_Get_Medication_for_MedicationID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_MC_GMfMID_1433 : FR_Base
	{
		public MC_GMfMID_1433 Result	{ get; set; }

		public FR_MC_GMfMID_1433() : base() {}

		public FR_MC_GMfMID_1433(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_MC_GMfMID_1433 for attribute P_MC_GMfMID_1433
		[DataContract]
		public class P_MC_GMfMID_1433 
		{
			//Standard type parameters
			[DataMember]
			public Guid MedicationID { get; set; } 

		}
		#endregion
		#region SClass MC_GMfMID_1433 for attribute MC_GMfMID_1433
		[DataContract]
		public class MC_GMfMID_1433 
		{
			//Standard type parameters
			[DataMember]
			public Guid MedicationID { get; set; } 
			[DataMember]
			public string Medication { get; set; } 
			[DataMember]
			public bool ProprietaryDrug { get; set; } 
			[DataMember]
			public string PZNScheme { get; set; } 
			[DataMember]
			public Guid HecDrugID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MC_GMfMID_1433 cls_Get_Medication_for_MedicationID(,P_MC_GMfMID_1433 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MC_GMfMID_1433 invocationResult = cls_Get_Medication_for_MedicationID.Invoke(connectionString,P_MC_GMfMID_1433 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Medication.Atomic.Retrieval.P_MC_GMfMID_1433();
parameter.MedicationID = ...;

*/
