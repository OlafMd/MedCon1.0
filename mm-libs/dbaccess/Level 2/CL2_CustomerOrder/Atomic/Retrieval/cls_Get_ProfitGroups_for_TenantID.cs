/* 
 * Generated on 11/15/2013 3:27:30 PM
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

namespace CL2_CustomerOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProfitGroups_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProfitGroups_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2_CO_GPGfT_1525_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2_CO_GPGfT_1525_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_ProfitGroups_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2_CO_GPGfT_1525> results = new List<L2_CO_GPGfT_1525>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_ProfitGroupID","ShortName","ProfitGroup_Name_DictID","ProfitGroup_Description_DictID" });
				while(reader.Read())
				{
					L2_CO_GPGfT_1525 resultItem = new L2_CO_GPGfT_1525();
					//0:Parameter ORD_CUO_ProfitGroupID of type Guid
					resultItem.ORD_CUO_ProfitGroupID = reader.GetGuid(0);
					//1:Parameter ShortName of type String
					resultItem.ShortName = reader.GetString(1);
					//2:Parameter ProfitGroup_Name of type Dict
					resultItem.ProfitGroup_Name = reader.GetDictionary(2);
					resultItem.ProfitGroup_Name.SourceTable = "ord_cuo_profitgroups";
					loader.Append(resultItem.ProfitGroup_Name);
					//3:Parameter ProfitGroup_Description of type Dict
					resultItem.ProfitGroup_Description = reader.GetDictionary(3);
					resultItem.ProfitGroup_Description.SourceTable = "ord_cuo_profitgroups";
					loader.Append(resultItem.ProfitGroup_Description);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProfitGroups_for_TenantID",ex);
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
		public static FR_L2_CO_GPGfT_1525_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2_CO_GPGfT_1525_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2_CO_GPGfT_1525_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2_CO_GPGfT_1525_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2_CO_GPGfT_1525_Array functionReturn = new FR_L2_CO_GPGfT_1525_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProfitGroups_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2_CO_GPGfT_1525_Array : FR_Base
	{
		public L2_CO_GPGfT_1525[] Result	{ get; set; } 
		public FR_L2_CO_GPGfT_1525_Array() : base() {}

		public FR_L2_CO_GPGfT_1525_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2_CO_GPGfT_1525 for attribute L2_CO_GPGfT_1525
		[DataContract]
		public class L2_CO_GPGfT_1525 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_ProfitGroupID { get; set; } 
			[DataMember]
			public String ShortName { get; set; } 
			[DataMember]
			public Dict ProfitGroup_Name { get; set; } 
			[DataMember]
			public Dict ProfitGroup_Description { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2_CO_GPGfT_1525_Array cls_Get_ProfitGroups_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2_CO_GPGfT_1525_Array invocationResult = cls_Get_ProfitGroups_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

