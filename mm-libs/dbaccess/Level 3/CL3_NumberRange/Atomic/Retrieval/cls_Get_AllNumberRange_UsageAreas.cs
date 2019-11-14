/* 
 * Generated on 1/20/2015 12:59:48 PM
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

namespace CL3_NumberRange.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllNumberRange_UsageAreas.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllNumberRange_UsageAreas
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3NR_GANR_1700_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3NR_GANR_1700_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_NumberRange.Atomic.Retrieval.SQL.cls_Get_AllNumberRange_UsageAreas.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3NR_GANR_1700> results = new List<L3NR_GANR_1700>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_NumberRange_UsageAreaID","UsageArea_Name_DictID","IsDeleted","Tenant_RefID" });
				while(reader.Read())
				{
					L3NR_GANR_1700 resultItem = new L3NR_GANR_1700();
					//0:Parameter CMN_NumberRange_UsageAreaID of type Guid
					resultItem.CMN_NumberRange_UsageAreaID = reader.GetGuid(0);
					//1:Parameter UsageAreaName of type Dict
					resultItem.UsageAreaName = reader.GetDictionary(1);
					resultItem.UsageAreaName.SourceTable = "cmn_numberrange_usageareas";
					loader.Append(resultItem.UsageAreaName);
					//2:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(2);
					//3:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllNumberRange_UsageAreas",ex);
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
		public static FR_L3NR_GANR_1700_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3NR_GANR_1700_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3NR_GANR_1700_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3NR_GANR_1700_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3NR_GANR_1700_Array functionReturn = new FR_L3NR_GANR_1700_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllNumberRange_UsageAreas",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3NR_GANR_1700_Array : FR_Base
	{
		public L3NR_GANR_1700[] Result	{ get; set; } 
		public FR_L3NR_GANR_1700_Array() : base() {}

		public FR_L3NR_GANR_1700_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3NR_GANR_1700 for attribute L3NR_GANR_1700
		[DataContract]
		public class L3NR_GANR_1700 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_NumberRange_UsageAreaID { get; set; } 
			[DataMember]
			public Dict UsageAreaName { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3NR_GANR_1700_Array cls_Get_AllNumberRange_UsageAreas(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3NR_GANR_1700_Array invocationResult = cls_Get_AllNumberRange_UsageAreas.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

