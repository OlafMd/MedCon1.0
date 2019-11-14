/* 
 * Generated on 3/29/2017 11:10:27 AM
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

namespace DataImporter.DBMethods.Doctor.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctor_Properties.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_Properties
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GDP_1107_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GDP_1107_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Doctor.Atomic.Retrieval.SQL.cls_Get_Doctor_Properties.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<DO_GDP_1107> results = new List<DO_GDP_1107>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IsValue_String","IsValue_Number","IsValue_Boolean","Value_String","Value_Number","Value_Boolean","GlobalPropertyMatchingID","DoctorID" });
				while(reader.Read())
				{
					DO_GDP_1107 resultItem = new DO_GDP_1107();
					//0:Parameter IsValue_String of type bool
					resultItem.IsValue_String = reader.GetBoolean(0);
					//1:Parameter IsValue_Number of type bool
					resultItem.IsValue_Number = reader.GetBoolean(1);
					//2:Parameter IsValue_Boolean of type bool
					resultItem.IsValue_Boolean = reader.GetBoolean(2);
					//3:Parameter Value_String of type String
					resultItem.Value_String = reader.GetString(3);
					//4:Parameter Value_Number of type Double
					resultItem.Value_Number = reader.GetDouble(4);
					//5:Parameter Value_Boolean of type bool
					resultItem.Value_Boolean = reader.GetBoolean(5);
					//6:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(6);
					//7:Parameter DoctorID of type Guid
					resultItem.DoctorID = reader.GetGuid(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctor_Properties",ex);
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
		public static FR_DO_GDP_1107_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GDP_1107_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GDP_1107_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GDP_1107_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GDP_1107_Array functionReturn = new FR_DO_GDP_1107_Array();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_Properties",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GDP_1107_Array : FR_Base
	{
		public DO_GDP_1107[] Result	{ get; set; } 
		public FR_DO_GDP_1107_Array() : base() {}

		public FR_DO_GDP_1107_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass DO_GDP_1107 for attribute DO_GDP_1107
		[DataContract]
		public class DO_GDP_1107 
		{
			//Standard type parameters
			[DataMember]
			public bool IsValue_String { get; set; } 
			[DataMember]
			public bool IsValue_Number { get; set; } 
			[DataMember]
			public bool IsValue_Boolean { get; set; } 
			[DataMember]
			public String Value_String { get; set; } 
			[DataMember]
			public Double Value_Number { get; set; } 
			[DataMember]
			public bool Value_Boolean { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid DoctorID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GDP_1107_Array cls_Get_Doctor_Properties(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GDP_1107_Array invocationResult = cls_Get_Doctor_Properties.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

