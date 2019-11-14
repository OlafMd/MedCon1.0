/* 
 * Generated on 03/30/17 14:45:13
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
    /// var result = cls_Get_Aftercares_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Aftercares_on_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GAoT_1120_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GAoT_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GAoT_1120_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Aftercares_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IncludeDeleted", Parameter.IncludeDeleted);



			List<CAS_GAoT_1120> results = new List<CAS_GAoT_1120>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IsPerformed","Case_RefID","HEC_ACT_PlannedActionID","HEC_CAS_Case_RelevantPlannedActionID","Creation_Timestamp","IfPerfomed_DateOfAction" });
				while(reader.Read())
				{
					CAS_GAoT_1120 resultItem = new CAS_GAoT_1120();
					//0:Parameter IsPerformed of type Boolean
					resultItem.IsPerformed = reader.GetBoolean(0);
					//1:Parameter Case_RefID of type Guid
					resultItem.Case_RefID = reader.GetGuid(1);
					//2:Parameter HEC_ACT_PlannedActionID of type Guid
					resultItem.HEC_ACT_PlannedActionID = reader.GetGuid(2);
					//3:Parameter HEC_CAS_Case_RelevantPlannedActionID of type Guid
					resultItem.HEC_CAS_Case_RelevantPlannedActionID = reader.GetGuid(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter IfPerfomed_DateOfAction of type DateTime
					resultItem.IfPerfomed_DateOfAction = reader.GetDate(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Aftercares_on_Tenant",ex);
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
		public static FR_CAS_GAoT_1120_Array Invoke(string ConnectionString,P_CAS_GAoT_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GAoT_1120_Array Invoke(DbConnection Connection,P_CAS_GAoT_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GAoT_1120_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GAoT_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GAoT_1120_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GAoT_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GAoT_1120_Array functionReturn = new FR_CAS_GAoT_1120_Array();
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

				throw new Exception("Exception occured in method cls_Get_Aftercares_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GAoT_1120_Array : FR_Base
	{
		public CAS_GAoT_1120[] Result	{ get; set; } 
		public FR_CAS_GAoT_1120_Array() : base() {}

		public FR_CAS_GAoT_1120_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GAoT_1120 for attribute P_CAS_GAoT_1120
		[DataContract]
		public class P_CAS_GAoT_1120 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IncludeDeleted { get; set; } 

		}
		#endregion
		#region SClass CAS_GAoT_1120 for attribute CAS_GAoT_1120
		[DataContract]
		public class CAS_GAoT_1120 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsPerformed { get; set; } 
			[DataMember]
			public Guid Case_RefID { get; set; } 
			[DataMember]
			public Guid HEC_ACT_PlannedActionID { get; set; } 
			[DataMember]
			public Guid HEC_CAS_Case_RelevantPlannedActionID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public DateTime IfPerfomed_DateOfAction { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GAoT_1120_Array cls_Get_Aftercares_on_Tenant(,P_CAS_GAoT_1120 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GAoT_1120_Array invocationResult = cls_Get_Aftercares_on_Tenant.Invoke(connectionString,P_CAS_GAoT_1120 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Retrieval.P_CAS_GAoT_1120();
parameter.IncludeDeleted = ...;

*/
