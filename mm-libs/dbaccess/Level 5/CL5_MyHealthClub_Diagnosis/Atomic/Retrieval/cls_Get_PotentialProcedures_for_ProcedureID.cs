/* 
 * Generated on 12/9/2014 12:57:58 PM
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

namespace CL5_MyHealthClub_Diagnosis.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PotentialProcedures_for_ProcedureID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PotentialProcedures_for_ProcedureID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DI_GPPfPID_1235 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_GPPfPID_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DI_GPPfPID_1235();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.SQL.cls_Get_PotentialProcedures_for_ProcedureID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProcedureID", Parameter.ProcedureID);



			List<L5DI_GPPfPID_1235> results = new List<L5DI_GPPfPID_1235>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PotentialProcedure_Name_DictID","Code","HEC_TRE_PotentialProcedureID" });
				while(reader.Read())
				{
					L5DI_GPPfPID_1235 resultItem = new L5DI_GPPfPID_1235();
					//0:Parameter PotentialProcedure_Name of type Dict
					resultItem.PotentialProcedure_Name = reader.GetDictionary(0);
					resultItem.PotentialProcedure_Name.SourceTable = "hec_tre_potentialprocedures";
					loader.Append(resultItem.PotentialProcedure_Name);
					//1:Parameter Code of type String
					resultItem.Code = reader.GetString(1);
					//2:Parameter HEC_TRE_PotentialProcedureID of type Guid
					resultItem.HEC_TRE_PotentialProcedureID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PotentialProcedures_for_ProcedureID",ex);
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
		public static FR_L5DI_GPPfPID_1235 Invoke(string ConnectionString,P_L5DI_GPPfPID_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DI_GPPfPID_1235 Invoke(DbConnection Connection,P_L5DI_GPPfPID_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DI_GPPfPID_1235 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_GPPfPID_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DI_GPPfPID_1235 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_GPPfPID_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DI_GPPfPID_1235 functionReturn = new FR_L5DI_GPPfPID_1235();
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

				throw new Exception("Exception occured in method cls_Get_PotentialProcedures_for_ProcedureID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DI_GPPfPID_1235 : FR_Base
	{
		public L5DI_GPPfPID_1235 Result	{ get; set; }

		public FR_L5DI_GPPfPID_1235() : base() {}

		public FR_L5DI_GPPfPID_1235(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DI_GPPfPID_1235 for attribute P_L5DI_GPPfPID_1235
		[DataContract]
		public class P_L5DI_GPPfPID_1235 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProcedureID { get; set; } 

		}
		#endregion
		#region SClass L5DI_GPPfPID_1235 for attribute L5DI_GPPfPID_1235
		[DataContract]
		public class L5DI_GPPfPID_1235 
		{
			//Standard type parameters
			[DataMember]
			public Dict PotentialProcedure_Name { get; set; } 
			[DataMember]
			public String Code { get; set; } 
			[DataMember]
			public Guid HEC_TRE_PotentialProcedureID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DI_GPPfPID_1235 cls_Get_PotentialProcedures_for_ProcedureID(,P_L5DI_GPPfPID_1235 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DI_GPPfPID_1235 invocationResult = cls_Get_PotentialProcedures_for_ProcedureID.Invoke(connectionString,P_L5DI_GPPfPID_1235 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.P_L5DI_GPPfPID_1235();
parameter.ProcedureID = ...;

*/
