/* 
 * Generated on 03/10/17 14:11:48
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
    /// var result = cls_Get_PerformedActionsDates_by_ActionTypeID_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PerformedActionsDates_by_ActionTypeID_on_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GPADbATIDoT_1411_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GPADbATIDoT_1411 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GPADbATIDoT_1411_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_PerformedActionsDates_by_ActionTypeID_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActionTypeID", Parameter.ActionTypeID);



			List<CAS_GPADbATIDoT_1411> results = new List<CAS_GPADbATIDoT_1411>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "treatment_date","action_id","case_id","creation_timestamp","patient_id","localization" });
				while(reader.Read())
				{
					CAS_GPADbATIDoT_1411 resultItem = new CAS_GPADbATIDoT_1411();
					//0:Parameter treatment_date of type DateTime
					resultItem.treatment_date = reader.GetDate(0);
					//1:Parameter action_id of type Guid
					resultItem.action_id = reader.GetGuid(1);
					//2:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(2);
					//3:Parameter creation_timestamp of type DateTime
					resultItem.creation_timestamp = reader.GetDate(3);
					//4:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(4);
					//5:Parameter localization of type String
					resultItem.localization = reader.GetString(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PerformedActionsDates_by_ActionTypeID_on_Tenant",ex);
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
		public static FR_CAS_GPADbATIDoT_1411_Array Invoke(string ConnectionString,P_CAS_GPADbATIDoT_1411 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GPADbATIDoT_1411_Array Invoke(DbConnection Connection,P_CAS_GPADbATIDoT_1411 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GPADbATIDoT_1411_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GPADbATIDoT_1411 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GPADbATIDoT_1411_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GPADbATIDoT_1411 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GPADbATIDoT_1411_Array functionReturn = new FR_CAS_GPADbATIDoT_1411_Array();
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

				throw new Exception("Exception occured in method cls_Get_PerformedActionsDates_by_ActionTypeID_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GPADbATIDoT_1411_Array : FR_Base
	{
		public CAS_GPADbATIDoT_1411[] Result	{ get; set; } 
		public FR_CAS_GPADbATIDoT_1411_Array() : base() {}

		public FR_CAS_GPADbATIDoT_1411_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GPADbATIDoT_1411 for attribute P_CAS_GPADbATIDoT_1411
		[DataContract]
		public class P_CAS_GPADbATIDoT_1411 
		{
			//Standard type parameters
			[DataMember]
			public Guid ActionTypeID { get; set; } 

		}
		#endregion
		#region SClass CAS_GPADbATIDoT_1411 for attribute CAS_GPADbATIDoT_1411
		[DataContract]
		public class CAS_GPADbATIDoT_1411 
		{
			//Standard type parameters
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public Guid action_id { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public DateTime creation_timestamp { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public String localization { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GPADbATIDoT_1411_Array cls_Get_PerformedActionsDates_by_ActionTypeID_on_Tenant(,P_CAS_GPADbATIDoT_1411 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GPADbATIDoT_1411_Array invocationResult = cls_Get_PerformedActionsDates_by_ActionTypeID_on_Tenant.Invoke(connectionString,P_CAS_GPADbATIDoT_1411 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Retrieval.P_CAS_GPADbATIDoT_1411();
parameter.ActionTypeID = ...;

*/
