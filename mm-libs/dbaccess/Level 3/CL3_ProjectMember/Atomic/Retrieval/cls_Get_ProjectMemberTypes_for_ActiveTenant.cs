/* 
 * Generated on 11/21/2014 9:23:42 AM
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

namespace CL3_ProjectMember.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProjectMemberTypes_for_ActiveTenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProjectMemberTypes_for_ActiveTenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PM_GPMTfAT_1522_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PM_GPMTfAT_1522_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_ProjectMember.Atomic.Retrieval.SQL.cls_Get_ProjectMemberTypes_for_ActiveTenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3PM_GPMTfAT_1522> results = new List<L3PM_GPMTfAT_1522>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMP_PRO_ProjectMember_TypeID","ProjectMemberType_Name_DictID","Color" });
				while(reader.Read())
				{
					L3PM_GPMTfAT_1522 resultItem = new L3PM_GPMTfAT_1522();
					//0:Parameter TMP_PRO_ProjectMember_TypeID of type Guid
					resultItem.TMP_PRO_ProjectMember_TypeID = reader.GetGuid(0);
					//1:Parameter ProjectMemberType_Name of type Dict
					resultItem.ProjectMemberType_Name = reader.GetDictionary(1);
					resultItem.ProjectMemberType_Name.SourceTable = "tmp_pro_projectmember_types";
					loader.Append(resultItem.ProjectMemberType_Name);
					//2:Parameter Color of type String
					resultItem.Color = reader.GetString(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProjectMemberTypes_for_ActiveTenant",ex);
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
		public static FR_L3PM_GPMTfAT_1522_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PM_GPMTfAT_1522_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PM_GPMTfAT_1522_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PM_GPMTfAT_1522_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PM_GPMTfAT_1522_Array functionReturn = new FR_L3PM_GPMTfAT_1522_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProjectMemberTypes_for_ActiveTenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PM_GPMTfAT_1522_Array : FR_Base
	{
		public L3PM_GPMTfAT_1522[] Result	{ get; set; } 
		public FR_L3PM_GPMTfAT_1522_Array() : base() {}

		public FR_L3PM_GPMTfAT_1522_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3PM_GPMTfAT_1522 for attribute L3PM_GPMTfAT_1522
		[DataContract]
		public class L3PM_GPMTfAT_1522 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMP_PRO_ProjectMember_TypeID { get; set; } 
			[DataMember]
			public Dict ProjectMemberType_Name { get; set; } 
			[DataMember]
			public String Color { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PM_GPMTfAT_1522_Array cls_Get_ProjectMemberTypes_for_ActiveTenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PM_GPMTfAT_1522_Array invocationResult = cls_Get_ProjectMemberTypes_for_ActiveTenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

