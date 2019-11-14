/* 
 * Generated on 1/29/2014 1:35:39 PM
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

namespace CL2_BusinessTask.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BuisinessTasks_2_feature_for_account_and_tennant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BuisinessTasks_2_feature_for_account_and_tennant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2BT_GBT2FfAaT_1306_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2BT_GBT2FfAaT_1306_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_BusinessTask.Atomic.Retrieval.SQL.cls_Get_BuisinessTasks_2_feature_for_account_and_tennant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2BT_GBT2FfAaT_1306> results = new List<L2BT_GBT2FfAaT_1306>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Tenant_RefID","IsDeleted","Creation_Timestamp","Feature_RefID","BusinessTask_RefID","AssignmentID" });
				while(reader.Read())
				{
					L2BT_GBT2FfAaT_1306 resultItem = new L2BT_GBT2FfAaT_1306();
					//0:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(0);
					//1:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(1);
					//2:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(2);
					//3:Parameter Feature_RefID of type Guid
					resultItem.Feature_RefID = reader.GetGuid(3);
					//4:Parameter BusinessTask_RefID of type Guid
					resultItem.BusinessTask_RefID = reader.GetGuid(4);
					//5:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BuisinessTasks_2_feature_for_account_and_tennant",ex);
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
		public static FR_L2BT_GBT2FfAaT_1306_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2BT_GBT2FfAaT_1306_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2BT_GBT2FfAaT_1306_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2BT_GBT2FfAaT_1306_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2BT_GBT2FfAaT_1306_Array functionReturn = new FR_L2BT_GBT2FfAaT_1306_Array();
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

				throw new Exception("Exception occured in method cls_Get_BuisinessTasks_2_feature_for_account_and_tennant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2BT_GBT2FfAaT_1306_Array : FR_Base
	{
		public L2BT_GBT2FfAaT_1306[] Result	{ get; set; } 
		public FR_L2BT_GBT2FfAaT_1306_Array() : base() {}

		public FR_L2BT_GBT2FfAaT_1306_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2BT_GBT2FfAaT_1306 for attribute L2BT_GBT2FfAaT_1306
		[DataContract]
		public class L2BT_GBT2FfAaT_1306 
		{
			//Standard type parameters
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Feature_RefID { get; set; } 
			[DataMember]
			public Guid BusinessTask_RefID { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2BT_GBT2FfAaT_1306_Array cls_Get_BuisinessTasks_2_feature_for_account_and_tennant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2BT_GBT2FfAaT_1306_Array invocationResult = cls_Get_BuisinessTasks_2_feature_for_account_and_tennant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

