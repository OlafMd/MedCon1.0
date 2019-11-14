/* 
 * Generated on 10/24/2014 5:04:55 PM
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

namespace CL6_DanuTask_User.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PricingManagement_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PricingManagement_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6US_GPMfT_1213_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6US_GPMfT_1213_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_DanuTask_User.Atomic.Retrieval.SQL.cls_Get_PricingManagement_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L6US_GPMfT_1213> results = new List<L6US_GPMfT_1213>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PriceAmount","CMN_CurrencyID","ChangingLevel_Name_DictID","Name_DictID","Symbol","CMN_BPT_InvestedWorkTime_ChargingLevelID","CMN_SLS_PriceID" });
				while(reader.Read())
				{
					L6US_GPMfT_1213 resultItem = new L6US_GPMfT_1213();
					//0:Parameter PriceAmount of type decimal
					resultItem.PriceAmount = reader.GetDecimal(0);
					//1:Parameter CMN_CurrencyID of type Guid
					resultItem.CMN_CurrencyID = reader.GetGuid(1);
					//2:Parameter ChangingLevel_Name of type Dict
					resultItem.ChangingLevel_Name = reader.GetDictionary(2);
					resultItem.ChangingLevel_Name.SourceTable = "cmn_bpt_investedworktime_charginglevels";
					loader.Append(resultItem.ChangingLevel_Name);
					//3:Parameter Name_DictID of type Dict
					resultItem.Name_DictID = reader.GetDictionary(3);
					resultItem.Name_DictID.SourceTable = "cmn_currencies";
					loader.Append(resultItem.Name_DictID);
					//4:Parameter Symbol of type String
					resultItem.Symbol = reader.GetString(4);
					//5:Parameter CMN_BPT_InvestedWorkTime_ChargingLevelID of type Guid
					resultItem.CMN_BPT_InvestedWorkTime_ChargingLevelID = reader.GetGuid(5);
					//6:Parameter CMN_SLS_PriceID of type Guid
					resultItem.CMN_SLS_PriceID = reader.GetGuid(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PricingManagement_for_Tenant",ex);
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
		public static FR_L6US_GPMfT_1213_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6US_GPMfT_1213_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6US_GPMfT_1213_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6US_GPMfT_1213_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6US_GPMfT_1213_Array functionReturn = new FR_L6US_GPMfT_1213_Array();
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

				throw new Exception("Exception occured in method cls_Get_PricingManagement_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6US_GPMfT_1213_Array : FR_Base
	{
		public L6US_GPMfT_1213[] Result	{ get; set; } 
		public FR_L6US_GPMfT_1213_Array() : base() {}

		public FR_L6US_GPMfT_1213_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6US_GPMfT_1213 for attribute L6US_GPMfT_1213
		[DataContract]
		public class L6US_GPMfT_1213 
		{
			//Standard type parameters
			[DataMember]
			public decimal PriceAmount { get; set; } 
			[DataMember]
			public Guid CMN_CurrencyID { get; set; } 
			[DataMember]
			public Dict ChangingLevel_Name { get; set; } 
			[DataMember]
			public Dict Name_DictID { get; set; } 
			[DataMember]
			public String Symbol { get; set; } 
			[DataMember]
			public Guid CMN_BPT_InvestedWorkTime_ChargingLevelID { get; set; } 
			[DataMember]
			public Guid CMN_SLS_PriceID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6US_GPMfT_1213_Array cls_Get_PricingManagement_for_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6US_GPMfT_1213_Array invocationResult = cls_Get_PricingManagement_for_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

