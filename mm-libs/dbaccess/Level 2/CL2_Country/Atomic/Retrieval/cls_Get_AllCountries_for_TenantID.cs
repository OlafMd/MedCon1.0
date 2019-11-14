/* 
 * Generated on 3/4/2014 11:39:59 AM
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

namespace CL2_Country.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllCountries_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllCountries_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2CN_GACfT_1122_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2CN_GACfT_1122_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Country.Atomic.Retrieval.SQL.cls_Get_AllCountries_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L2CN_GACfT_1122> results = new List<L2CN_GACfT_1122>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_CountryID","Default_Language_RefID","Default_Currency_RefID","Country_Name_DictID","Country_ISOCode_Alpha2","Country_ISOCode_Alpha3","Country_ISOCode_Numeric" });
				while(reader.Read())
				{
					L2CN_GACfT_1122 resultItem = new L2CN_GACfT_1122();
					//0:Parameter CMN_CountryID of type Guid
					resultItem.CMN_CountryID = reader.GetGuid(0);
					//1:Parameter Default_Language_RefID of type Guid
					resultItem.Default_Language_RefID = reader.GetGuid(1);
					//2:Parameter Default_Currency_RefID of type Guid
					resultItem.Default_Currency_RefID = reader.GetGuid(2);
					//3:Parameter Country_Name of type Dict
					resultItem.Country_Name = reader.GetDictionary(3);
					resultItem.Country_Name.SourceTable = "cmn_countries";
					loader.Append(resultItem.Country_Name);
					//4:Parameter Country_ISOCode_Alpha2 of type String
					resultItem.Country_ISOCode_Alpha2 = reader.GetString(4);
					//5:Parameter Country_ISOCode_Alpha3 of type String
					resultItem.Country_ISOCode_Alpha3 = reader.GetString(5);
					//6:Parameter Country_ISOCode_Numeric of type int
					resultItem.Country_ISOCode_Numeric = reader.GetInteger(6);

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
		public static FR_L2CN_GACfT_1122_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2CN_GACfT_1122_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2CN_GACfT_1122_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2CN_GACfT_1122_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2CN_GACfT_1122_Array functionReturn = new FR_L2CN_GACfT_1122_Array();
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
	public class FR_L2CN_GACfT_1122_Array : FR_Base
	{
		public L2CN_GACfT_1122[] Result	{ get; set; } 
		public FR_L2CN_GACfT_1122_Array() : base() {}

		public FR_L2CN_GACfT_1122_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2CN_GACfT_1122 for attribute L2CN_GACfT_1122
		[DataContract]
		public class L2CN_GACfT_1122 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_CountryID { get; set; } 
			[DataMember]
			public Guid Default_Language_RefID { get; set; } 
			[DataMember]
			public Guid Default_Currency_RefID { get; set; } 
			[DataMember]
			public Dict Country_Name { get; set; } 
			[DataMember]
			public String Country_ISOCode_Alpha2 { get; set; } 
			[DataMember]
			public String Country_ISOCode_Alpha3 { get; set; } 
			[DataMember]
			public int Country_ISOCode_Numeric { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2CN_GACfT_1122_Array cls_Get_AllCountries_for_TenantID(string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L2CN_GACfT_1122_Array result = cls_Get_AllCountries_for_TenantID.Invoke(connectionString,securityTicket);
	 return result;
}
*/