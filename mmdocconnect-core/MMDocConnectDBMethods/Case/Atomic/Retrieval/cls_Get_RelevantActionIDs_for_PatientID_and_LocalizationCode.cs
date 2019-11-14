/* 
 * Generated on 10/17/16 10:23:41
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
    /// var result = cls_Get_RelevantActionIDs_for_PatientID_and_LocalizationCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RelevantActionIDs_for_PatientID_and_LocalizationCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GRAIDsfPIDaLC_1011_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GRAIDsfPIDaLC_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GRAIDsfPIDaLC_1011_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_RelevantActionIDs_for_PatientID_and_LocalizationCode.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActionTypeID", Parameter.ActionTypeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LocalizationCode", Parameter.LocalizationCode);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TreatmentYearStartDate", Parameter.TreatmentYearStartDate);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TreatmentYearEndDate", Parameter.TreatmentYearEndDate);



			List<CAS_GRAIDsfPIDaLC_1011> results = new List<CAS_GRAIDsfPIDaLC_1011>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "case_id","action_id" });
				while(reader.Read())
				{
					CAS_GRAIDsfPIDaLC_1011 resultItem = new CAS_GRAIDsfPIDaLC_1011();
					//0:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(0);
					//1:Parameter action_id of type Guid
					resultItem.action_id = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RelevantActionIDs_for_PatientID_and_LocalizationCode",ex);
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
		public static FR_CAS_GRAIDsfPIDaLC_1011_Array Invoke(string ConnectionString,P_CAS_GRAIDsfPIDaLC_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GRAIDsfPIDaLC_1011_Array Invoke(DbConnection Connection,P_CAS_GRAIDsfPIDaLC_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GRAIDsfPIDaLC_1011_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GRAIDsfPIDaLC_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GRAIDsfPIDaLC_1011_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GRAIDsfPIDaLC_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GRAIDsfPIDaLC_1011_Array functionReturn = new FR_CAS_GRAIDsfPIDaLC_1011_Array();
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

				throw new Exception("Exception occured in method cls_Get_RelevantActionIDs_for_PatientID_and_LocalizationCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GRAIDsfPIDaLC_1011_Array : FR_Base
	{
		public CAS_GRAIDsfPIDaLC_1011[] Result	{ get; set; } 
		public FR_CAS_GRAIDsfPIDaLC_1011_Array() : base() {}

		public FR_CAS_GRAIDsfPIDaLC_1011_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GRAIDsfPIDaLC_1011 for attribute P_CAS_GRAIDsfPIDaLC_1011
		[DataContract]
		public class P_CAS_GRAIDsfPIDaLC_1011 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public Guid ActionTypeID { get; set; } 
			[DataMember]
			public String LocalizationCode { get; set; } 
			[DataMember]
			public DateTime TreatmentYearStartDate { get; set; } 
			[DataMember]
			public DateTime TreatmentYearEndDate { get; set; } 

		}
		#endregion
		#region SClass CAS_GRAIDsfPIDaLC_1011 for attribute CAS_GRAIDsfPIDaLC_1011
		[DataContract]
		public class CAS_GRAIDsfPIDaLC_1011 
		{
			//Standard type parameters
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid action_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GRAIDsfPIDaLC_1011_Array cls_Get_RelevantActionIDs_for_PatientID_and_LocalizationCode(,P_CAS_GRAIDsfPIDaLC_1011 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GRAIDsfPIDaLC_1011_Array invocationResult = cls_Get_RelevantActionIDs_for_PatientID_and_LocalizationCode.Invoke(connectionString,P_CAS_GRAIDsfPIDaLC_1011 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GRAIDsfPIDaLC_1011();
parameter.PatientID = ...;
parameter.ActionTypeID = ...;
parameter.LocalizationCode = ...;
parameter.TreatmentYearStartDate = ...;
parameter.TreatmentYearEndDate = ...;

*/
