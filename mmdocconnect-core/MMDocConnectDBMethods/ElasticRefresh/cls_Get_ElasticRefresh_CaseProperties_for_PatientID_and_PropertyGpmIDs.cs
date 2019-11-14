/* 
 * Generated on 03/22/17 10:11:35
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

namespace MMDocConnectDBMethods.ElasticRefresh
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ElasticRefresh_CaseProperties_for_PatientID_and_PropertyGpmIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ElasticRefresh_CaseProperties_for_PatientID_and_PropertyGpmIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ER_GERCPfPIDaPGpmIDs_1011_Array Execute(DbConnection Connection,DbTransaction Transaction,P_ER_GERCPfPIDaPGpmIDs_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ER_GERCPfPIDaPGpmIDs_1011_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.ElasticRefresh.SQL.cls_Get_ElasticRefresh_CaseProperties_for_PatientID_and_PropertyGpmIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@PropertyGpmIDs"," IN $$PropertyGpmIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$PropertyGpmIDs$",Parameter.PropertyGpmIDs);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<ER_GERCPfPIDaPGpmIDs_1011> results = new List<ER_GERCPfPIDaPGpmIDs_1011>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Value_String","Value_Boolean","Value_Number","ID","CaseID","PatientID","GpmID" });
				while(reader.Read())
				{
					ER_GERCPfPIDaPGpmIDs_1011 resultItem = new ER_GERCPfPIDaPGpmIDs_1011();
					//0:Parameter Value_String of type String
					resultItem.Value_String = reader.GetString(0);
					//1:Parameter Value_Boolean of type Boolean
					resultItem.Value_Boolean = reader.GetBoolean(1);
					//2:Parameter Value_Number of type Double
					resultItem.Value_Number = reader.GetDouble(2);
					//3:Parameter ID of type Guid
					resultItem.ID = reader.GetGuid(3);
					//4:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(4);
					//5:Parameter PatientID of type Guid
					resultItem.PatientID = reader.GetGuid(5);
					//6:Parameter GpmID of type String
					resultItem.GpmID = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ElasticRefresh_CaseProperties_for_PatientID_and_PropertyGpmIDs",ex);
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
		public static FR_ER_GERCPfPIDaPGpmIDs_1011_Array Invoke(string ConnectionString,P_ER_GERCPfPIDaPGpmIDs_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ER_GERCPfPIDaPGpmIDs_1011_Array Invoke(DbConnection Connection,P_ER_GERCPfPIDaPGpmIDs_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ER_GERCPfPIDaPGpmIDs_1011_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_ER_GERCPfPIDaPGpmIDs_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ER_GERCPfPIDaPGpmIDs_1011_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ER_GERCPfPIDaPGpmIDs_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ER_GERCPfPIDaPGpmIDs_1011_Array functionReturn = new FR_ER_GERCPfPIDaPGpmIDs_1011_Array();
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

				throw new Exception("Exception occured in method cls_Get_ElasticRefresh_CaseProperties_for_PatientID_and_PropertyGpmIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ER_GERCPfPIDaPGpmIDs_1011_Array : FR_Base
	{
		public ER_GERCPfPIDaPGpmIDs_1011[] Result	{ get; set; } 
		public FR_ER_GERCPfPIDaPGpmIDs_1011_Array() : base() {}

		public FR_ER_GERCPfPIDaPGpmIDs_1011_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ER_GERCPfPIDaPGpmIDs_1011 for attribute P_ER_GERCPfPIDaPGpmIDs_1011
		[DataContract]
		public class P_ER_GERCPfPIDaPGpmIDs_1011 
		{
			//Standard type parameters
			[DataMember]
			public String[] PropertyGpmIDs { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass ER_GERCPfPIDaPGpmIDs_1011 for attribute ER_GERCPfPIDaPGpmIDs_1011
		[DataContract]
		public class ER_GERCPfPIDaPGpmIDs_1011 
		{
			//Standard type parameters
			[DataMember]
			public String Value_String { get; set; } 
			[DataMember]
			public Boolean Value_Boolean { get; set; } 
			[DataMember]
			public Double Value_Number { get; set; } 
			[DataMember]
			public Guid ID { get; set; } 
			[DataMember]
			public Guid CaseID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public String GpmID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ER_GERCPfPIDaPGpmIDs_1011_Array cls_Get_ElasticRefresh_CaseProperties_for_PatientID_and_PropertyGpmIDs(,P_ER_GERCPfPIDaPGpmIDs_1011 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ER_GERCPfPIDaPGpmIDs_1011_Array invocationResult = cls_Get_ElasticRefresh_CaseProperties_for_PatientID_and_PropertyGpmIDs.Invoke(connectionString,P_ER_GERCPfPIDaPGpmIDs_1011 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.ElasticRefresh.P_ER_GERCPfPIDaPGpmIDs_1011();
parameter.PropertyGpmIDs = ...;
parameter.PatientID = ...;

*/
