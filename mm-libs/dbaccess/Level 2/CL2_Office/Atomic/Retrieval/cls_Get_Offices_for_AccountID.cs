/* 
 * Generated on 3/4/2014 02:05:47
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL2_Office.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Offices_for_AccountID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Offices_for_AccountID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OF_GOFfA_1819_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OF_GOFfA_1819_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Office.Atomic.Retrieval.SQL.cls_Get_Offices_for_AccountID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5OF_GOFfA_1819> results = new List<L5OF_GOFfA_1819>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Office_Name_DictID","Office_InternalName","Office_InternalNumber","Office_Description_DictID","IsDeleted","Parent_RefID","USR_AccountID","CMN_STR_OfficeID" });
				while(reader.Read())
				{
					L5OF_GOFfA_1819 resultItem = new L5OF_GOFfA_1819();
					//0:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(0);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//1:Parameter Office_InternalName of type string
					resultItem.Office_InternalName = reader.GetString(1);
					//2:Parameter Office_InternalNumber of type string
					resultItem.Office_InternalNumber = reader.GetString(2);
					//3:Parameter Office_Description of type Dict
					resultItem.Office_Description = reader.GetDictionary(3);
					resultItem.Office_Description.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Description);
					//4:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(4);
					//5:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(5);
					//6:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(6);
					//7:Parameter CMN_STR_OfficeID of type Guid
					resultItem.CMN_STR_OfficeID = reader.GetGuid(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Offices_for_AccountID",ex);
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
		public static FR_L5OF_GOFfA_1819_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OF_GOFfA_1819_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OF_GOFfA_1819_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OF_GOFfA_1819_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OF_GOFfA_1819_Array functionReturn = new FR_L5OF_GOFfA_1819_Array();
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

				throw new Exception("Exception occured in method cls_Get_Offices_for_AccountID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OF_GOFfA_1819_Array : FR_Base
	{
		public L5OF_GOFfA_1819[] Result	{ get; set; } 
		public FR_L5OF_GOFfA_1819_Array() : base() {}

		public FR_L5OF_GOFfA_1819_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5OF_GOFfA_1819 for attribute L5OF_GOFfA_1819
		[DataContract]
		public class L5OF_GOFfA_1819 
		{
			//Standard type parameters
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public string Office_InternalName { get; set; } 
			[DataMember]
			public string Office_InternalNumber { get; set; } 
			[DataMember]
			public Dict Office_Description { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OF_GOFfA_1819_Array cls_Get_Offices_for_AccountID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OF_GOFfA_1819_Array invocationResult = cls_Get_Offices_for_AccountID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

