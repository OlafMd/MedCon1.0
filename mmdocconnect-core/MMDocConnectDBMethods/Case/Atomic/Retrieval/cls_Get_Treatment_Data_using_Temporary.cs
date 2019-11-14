/* 
 * Generated on 1/30/2017 4:20:14 PM
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Treatment_Data_using_Temporary.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Treatment_Data_using_Temporary
	{
        public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_CAS_GTDuT_1931_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GTDuT_1931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GTDuT_1931_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Treatment_Data_using_Temporary.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CaseUniversalPID", Parameter.CaseUniversalPID);



			List<CAS_GTDuT_1931> results = new List<CAS_GTDuT_1931>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PatientID","DiagnoseID","LocalizationCode","TreatmentDate" });
				while(reader.Read())
				{
					CAS_GTDuT_1931 resultItem = new CAS_GTDuT_1931();
					//0:Parameter PatientID of type Guid
					resultItem.PatientID = reader.GetGuid(0);
					//1:Parameter DiagnoseID of type Guid
					resultItem.DiagnoseID = reader.GetGuid(1);
					//2:Parameter LocalizationCode of type String
					resultItem.LocalizationCode = reader.GetString(2);
					//3:Parameter TreatmentDate of type DateTime
					resultItem.TreatmentDate = reader.GetDate(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Treatment_Data_using_Temporary",ex);
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
		public static FR_CAS_GTDuT_1931_Array Invoke(string ConnectionString,P_CAS_GTDuT_1931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GTDuT_1931_Array Invoke(DbConnection Connection,P_CAS_GTDuT_1931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GTDuT_1931_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GTDuT_1931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GTDuT_1931_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GTDuT_1931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GTDuT_1931_Array functionReturn = new FR_CAS_GTDuT_1931_Array();
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

				throw new Exception("Exception occured in method cls_Get_Treatment_Data_using_Temporary",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GTDuT_1931_Array : FR_Base
	{
		public CAS_GTDuT_1931[] Result	{ get; set; } 
		public FR_CAS_GTDuT_1931_Array() : base() {}

		public FR_CAS_GTDuT_1931_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GTDuT_1931 for attribute P_CAS_GTDuT_1931
		[DataContract]
		public class P_CAS_GTDuT_1931 
		{
			//Standard type parameters
			[DataMember]
			public Guid CaseUniversalPID { get; set; } 

		}
		#endregion
		#region SClass CAS_GTDuT_1931 for attribute CAS_GTDuT_1931
		[DataContract]
		public class CAS_GTDuT_1931 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public Guid DiagnoseID { get; set; } 
			[DataMember]
			public String LocalizationCode { get; set; } 
			[DataMember]
			public DateTime TreatmentDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GTDuT_1931_Array cls_Get_Treatment_Data_using_Temporary(,P_CAS_GTDuT_1931 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GTDuT_1931_Array invocationResult = cls_Get_Treatment_Data_using_Temporary.Invoke(connectionString,P_CAS_GTDuT_1931 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GTDuT_1931();
parameter.CaseUniversalPID = ...;

*/
