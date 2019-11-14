/* 
 * Generated on 7/16/2013 5:07:57 PM
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

namespace CL5_KPRS_Questionnaire.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Questionnaires_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Questionnaires_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5QT_GQFT_1707_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5QT_GQFT_1707_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_Questionnaire.Atomic.Retrieval.SQL.cls_Get_Questionnaires_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5QT_GQFT_1707> results = new List<L5QT_GQFT_1707>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_QST_QuestionnaireID","Questionnaire_Description_DictID","Questionnaire_Name_DictID","QuestionnaireVersion_VersionNumber","RES_QST_Questionnaire_VersionID" });
				while(reader.Read())
				{
					L5QT_GQFT_1707 resultItem = new L5QT_GQFT_1707();
					//0:Parameter RES_QST_QuestionnaireID of type Guid
					resultItem.RES_QST_QuestionnaireID = reader.GetGuid(0);
					//1:Parameter Questionnaire_Description of type Dict
					resultItem.Questionnaire_Description = reader.GetDictionary(1);
					resultItem.Questionnaire_Description.SourceTable = "res_qst_questionnaire";
					loader.Append(resultItem.Questionnaire_Description);
					//2:Parameter Questionnaire_Name of type Dict
					resultItem.Questionnaire_Name = reader.GetDictionary(2);
					resultItem.Questionnaire_Name.SourceTable = "res_qst_questionnaire";
					loader.Append(resultItem.Questionnaire_Name);
					//3:Parameter QuestionnaireVersion_VersionNumber of type int
					resultItem.QuestionnaireVersion_VersionNumber = reader.GetInteger(3);
					//4:Parameter RES_QST_Questionnaire_VersionID of type Guid
					resultItem.RES_QST_Questionnaire_VersionID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Questionnaires_For_Tenant",ex);
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
		public static FR_L5QT_GQFT_1707_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5QT_GQFT_1707_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5QT_GQFT_1707_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5QT_GQFT_1707_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5QT_GQFT_1707_Array functionReturn = new FR_L5QT_GQFT_1707_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Questionnaires_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5QT_GQFT_1707_Array : FR_Base
	{
		public L5QT_GQFT_1707[] Result	{ get; set; } 
		public FR_L5QT_GQFT_1707_Array() : base() {}

		public FR_L5QT_GQFT_1707_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5QT_GQFT_1707 for attribute L5QT_GQFT_1707
		[DataContract]
		public class L5QT_GQFT_1707 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_QST_QuestionnaireID { get; set; } 
			[DataMember]
			public Dict Questionnaire_Description { get; set; } 
			[DataMember]
			public Dict Questionnaire_Name { get; set; } 
			[DataMember]
			public int QuestionnaireVersion_VersionNumber { get; set; } 
			[DataMember]
			public Guid RES_QST_Questionnaire_VersionID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5QT_GQFT_1707_Array cls_Get_Questionnaires_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5QT_GQFT_1707_Array invocationResult = cls_Get_Questionnaires_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
