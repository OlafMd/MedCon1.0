/* 
 * Generated on 11/5/2013 9:39:11 AM
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

namespace CL2_Unit.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_all_Unit_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_all_Unit_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2UN_GAUFT_1355_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2UN_GAUFT_1355_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Unit.Atomic.Retrieval.SQL.cls_Get_all_Unit_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L2UN_GAUFT_1355> results = new List<L2UN_GAUFT_1355>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_UnitID","Label_DictID","Abbreviation_DictID","ISOCode" });
				while(reader.Read())
				{
					L2UN_GAUFT_1355 resultItem = new L2UN_GAUFT_1355();
					//0:Parameter CMN_UnitID of type Guid
					resultItem.CMN_UnitID = reader.GetGuid(0);
					//1:Parameter Label of type Dict
					resultItem.Label = reader.GetDictionary(1);
					resultItem.Label.SourceTable = "cmn_units";
					loader.Append(resultItem.Label);
					//2:Parameter Abbreviation of type Dict
					resultItem.Abbreviation = reader.GetDictionary(2);
					resultItem.Abbreviation.SourceTable = "cmn_units";
					loader.Append(resultItem.Abbreviation);
					//3:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(3);

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
		public static FR_L2UN_GAUFT_1355_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2UN_GAUFT_1355_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2UN_GAUFT_1355_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2UN_GAUFT_1355_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2UN_GAUFT_1355_Array functionReturn = new FR_L2UN_GAUFT_1355_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2UN_GAUFT_1355_Array : FR_Base
	{
		public L2UN_GAUFT_1355[] Result	{ get; set; } 
		public FR_L2UN_GAUFT_1355_Array() : base() {}

		public FR_L2UN_GAUFT_1355_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2UN_GAUFT_1355 for attribute L2UN_GAUFT_1355
		[DataContract]
		public class L2UN_GAUFT_1355 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_UnitID { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 
			[DataMember]
			public Dict Abbreviation { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2UN_GAUFT_1355_Array cls_Get_all_Unit_for_Tenant(string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L2UN_GAUFT_1355_Array result = cls_Get_all_Unit_for_Tenant.Invoke(connectionString,securityTicket);
	 return result;
}
*/