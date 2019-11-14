/* 
 * Generated on 3/11/2015 13:16:38
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

namespace CL5_MyHealthClub_Diagnosis.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Procedures_for_MedProTenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Procedures_for_MedProTenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DI_GPfMPT_1253_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DI_GPfMPT_1253_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Diagnosis.Atomic.Manipulation.SQL.cls_Get_Procedures_for_MedProTenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5DI_GPfMPT_1253> results = new List<L5DI_GPfMPT_1253>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_TRE_PotentialProcedureID","PotentialProcedure_Name_DictID","Code" });
				while(reader.Read())
				{
					L5DI_GPfMPT_1253 resultItem = new L5DI_GPfMPT_1253();
					//0:Parameter HEC_TRE_PotentialProcedureID of type Guid
					resultItem.HEC_TRE_PotentialProcedureID = reader.GetGuid(0);
					//1:Parameter PotentialProcedure_Name_DictID of type Dict
					resultItem.PotentialProcedure_Name_DictID = reader.GetDictionary(1);
					resultItem.PotentialProcedure_Name_DictID.SourceTable = "hec_tre_potentialprocedures";
					loader.Append(resultItem.PotentialProcedure_Name_DictID);
					//2:Parameter Code of type String
					resultItem.Code = reader.GetString(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Procedures_for_MedProTenant",ex);
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
		public static FR_L5DI_GPfMPT_1253_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DI_GPfMPT_1253_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DI_GPfMPT_1253_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DI_GPfMPT_1253_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DI_GPfMPT_1253_Array functionReturn = new FR_L5DI_GPfMPT_1253_Array();
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

				throw new Exception("Exception occured in method cls_Get_Procedures_for_MedProTenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DI_GPfMPT_1253_Array : FR_Base
	{
		public L5DI_GPfMPT_1253[] Result	{ get; set; } 
		public FR_L5DI_GPfMPT_1253_Array() : base() {}

		public FR_L5DI_GPfMPT_1253_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5DI_GPfMPT_1253 for attribute L5DI_GPfMPT_1253
		[DataContract]
		public class L5DI_GPfMPT_1253 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_TRE_PotentialProcedureID { get; set; } 
			[DataMember]
			public Dict PotentialProcedure_Name_DictID { get; set; } 
			[DataMember]
			public String Code { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DI_GPfMPT_1253_Array cls_Get_Procedures_for_MedProTenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DI_GPfMPT_1253_Array invocationResult = cls_Get_Procedures_for_MedProTenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

