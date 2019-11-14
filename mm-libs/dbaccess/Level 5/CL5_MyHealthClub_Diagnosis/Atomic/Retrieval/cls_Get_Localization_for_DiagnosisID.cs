/* 
 * Generated on 10/8/2014 1:11:29 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL5_MyHealthClub_Diagnosis.Atomic.Retrieval
{
	[Serializable]
	public class cls_Get_Localization_for_DiagnosisID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DI_GLfDID_1731_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_GLfDID_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DI_GLfDID_1731_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.SQL.cls_Get_Localization_for_DiagnosisID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DiagnosisID", Parameter.DiagnosisID);


			List<L5DI_GLfDID_1731> results = new List<L5DI_GLfDID_1731>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DIA_Diagnosis_LocalizationID","DiagnosisLocalization_Name_DictID" });
				while(reader.Read())
				{
					L5DI_GLfDID_1731 resultItem = new L5DI_GLfDID_1731();
					//0:Parameter HEC_DIA_Diagnosis_LocalizationID of type Guid
					resultItem.HEC_DIA_Diagnosis_LocalizationID = reader.GetGuid(0);
					//1:Parameter DiagnosisLocalization_Name of type Dict
					resultItem.DiagnosisLocalization_Name = reader.GetDictionary(1);
					resultItem.DiagnosisLocalization_Name.SourceTable = "hec_dia_diagnosis_localizations";
					loader.Append(resultItem.DiagnosisLocalization_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
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
		public static FR_L5DI_GLfDID_1731_Array Invoke(string ConnectionString,P_L5DI_GLfDID_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DI_GLfDID_1731_Array Invoke(DbConnection Connection,P_L5DI_GLfDID_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DI_GLfDID_1731_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_GLfDID_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DI_GLfDID_1731_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_GLfDID_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DI_GLfDID_1731_Array functionReturn = new FR_L5DI_GLfDID_1731_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DI_GLfDID_1731_Array : FR_Base
	{
		public L5DI_GLfDID_1731[] Result	{ get; set; } 
		public FR_L5DI_GLfDID_1731_Array() : base() {}

		public FR_L5DI_GLfDID_1731_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DI_GLfDID_1731 for attribute P_L5DI_GLfDID_1731
		[Serializable]
		public class P_L5DI_GLfDID_1731 
		{
			//Standard type parameters
			public Guid DiagnosisID; 

		}
		#endregion
		#region SClass L5DI_GLfDID_1731 for attribute L5DI_GLfDID_1731
		[Serializable]
		public class L5DI_GLfDID_1731 
		{
			//Standard type parameters
			public Guid HEC_DIA_Diagnosis_LocalizationID; 
			public Dict DiagnosisLocalization_Name; 

		}
		#endregion

	#endregion
}
