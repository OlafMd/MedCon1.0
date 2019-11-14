/* 
 * Generated on 2/25/2015 8:46:29 PM
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

namespace CL3_MeasurementRun.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_MeasurementRun_by_AccountCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_MeasurementRun_by_AccountCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3_MRbAC_1457_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3_MRbAC_1457 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3_MRbAC_1457_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_MeasurementRun.Atomic.Retrieval.SQL.cls_MeasurementRun_by_AccountCode.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AccountCode", Parameter.AccountCode);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DownloadCode", Parameter.DownloadCode);



			List<L3_MRbAC_1457> results = new List<L3_MRbAC_1457>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "MRS_RUN_MeasurementRunID","DateFrom","DateThrough","Creation_Timestamp","Tenant_RefID","IsDeleted","IsCorrectionRun","CorrectionOf_MeasurementRun_RefID" });
				while(reader.Read())
				{
					L3_MRbAC_1457 resultItem = new L3_MRbAC_1457();
					//0:Parameter MRS_RUN_MeasurementRunID of type Guid
					resultItem.MRS_RUN_MeasurementRunID = reader.GetGuid(0);
					//1:Parameter DateFrom of type DateTime
					resultItem.DateFrom = reader.GetDate(1);
					//2:Parameter DateThrough of type DateTime
					resultItem.DateThrough = reader.GetDate(2);
					//3:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(3);
					//4:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(4);
					//5:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(5);
					//6:Parameter IsCorrectionRun of type bool
					resultItem.IsCorrectionRun = reader.GetBoolean(6);
					//7:Parameter CorrectionOf_MeasurementRun_RefID of type Guid
					resultItem.CorrectionOf_MeasurementRun_RefID = reader.GetGuid(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_MeasurementRun_by_AccountCode",ex);
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
		public static FR_L3_MRbAC_1457_Array Invoke(string ConnectionString,P_L3_MRbAC_1457 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3_MRbAC_1457_Array Invoke(DbConnection Connection,P_L3_MRbAC_1457 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3_MRbAC_1457_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_MRbAC_1457 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3_MRbAC_1457_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_MRbAC_1457 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3_MRbAC_1457_Array functionReturn = new FR_L3_MRbAC_1457_Array();
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

				throw new Exception("Exception occured in method cls_MeasurementRun_by_AccountCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3_MRbAC_1457_Array : FR_Base
	{
		public L3_MRbAC_1457[] Result	{ get; set; } 
		public FR_L3_MRbAC_1457_Array() : base() {}

		public FR_L3_MRbAC_1457_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3_MRbAC_1457 for attribute P_L3_MRbAC_1457
		[DataContract]
		public class P_L3_MRbAC_1457 
		{
			//Standard type parameters
			[DataMember]
			public string AccountCode { get; set; } 
			[DataMember]
			public string DownloadCode { get; set; } 

		}
		#endregion
		#region SClass L3_MRbAC_1457 for attribute L3_MRbAC_1457
		[DataContract]
		public class L3_MRbAC_1457 
		{
			//Standard type parameters
			[DataMember]
			public Guid MRS_RUN_MeasurementRunID { get; set; } 
			[DataMember]
			public DateTime DateFrom { get; set; } 
			[DataMember]
			public DateTime DateThrough { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public bool IsCorrectionRun { get; set; } 
			[DataMember]
			public Guid CorrectionOf_MeasurementRun_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3_MRbAC_1457_Array cls_MeasurementRun_by_AccountCode(,P_L3_MRbAC_1457 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3_MRbAC_1457_Array invocationResult = cls_MeasurementRun_by_AccountCode.Invoke(connectionString,P_L3_MRbAC_1457 Parameter,securityTicket);
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
var parameter = new CL3_MeasurementRun.Atomic.Retrieval.P_L3_MRbAC_1457();
parameter.AccountCode = ...;
parameter.DownloadCode = ...;

*/
