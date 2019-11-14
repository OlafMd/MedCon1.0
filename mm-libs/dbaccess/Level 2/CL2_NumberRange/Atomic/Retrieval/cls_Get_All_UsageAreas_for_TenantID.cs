/* 
 * Generated on 6/10/2014 4:39:44 PM
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

namespace CL2_NumberRange.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_UsageAreas_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_UsageAreas_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2NR_GAUAfT_1033_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2NR_GAUAfT_1033_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_NumberRange.Atomic.Retrieval.SQL.cls_Get_All_UsageAreas_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2NR_GAUAfT_1033> results = new List<L2NR_GAUAfT_1033>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_NumberRange_UsageAreaID","GlobalStaticMatchingID","UsageArea_Name_DictID","UsageArea_Description_DictID","Creation_Timestamp","Tenant_RefID" });
				while(reader.Read())
				{
					L2NR_GAUAfT_1033 resultItem = new L2NR_GAUAfT_1033();
					//0:Parameter CMN_NumberRange_UsageAreaID of type Guid
					resultItem.CMN_NumberRange_UsageAreaID = reader.GetGuid(0);
					//1:Parameter GlobalStaticMatchingID of type String
					resultItem.GlobalStaticMatchingID = reader.GetString(1);
					//2:Parameter UsageArea_Name of type Dict
					resultItem.UsageArea_Name = reader.GetDictionary(2);
					resultItem.UsageArea_Name.SourceTable = "cmn_numberrange_usageareas";
					loader.Append(resultItem.UsageArea_Name);
					//3:Parameter UsageArea_Description of type Dict
					resultItem.UsageArea_Description = reader.GetDictionary(3);
					resultItem.UsageArea_Description.SourceTable = "cmn_numberrange_usageareas";
					loader.Append(resultItem.UsageArea_Description);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_UsageAreas_for_TenantID",ex);
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
		public static FR_L2NR_GAUAfT_1033_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2NR_GAUAfT_1033_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2NR_GAUAfT_1033_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2NR_GAUAfT_1033_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2NR_GAUAfT_1033_Array functionReturn = new FR_L2NR_GAUAfT_1033_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_UsageAreas_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2NR_GAUAfT_1033_Array : FR_Base
	{
		public L2NR_GAUAfT_1033[] Result	{ get; set; } 
		public FR_L2NR_GAUAfT_1033_Array() : base() {}

		public FR_L2NR_GAUAfT_1033_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2NR_GAUAfT_1033 for attribute L2NR_GAUAfT_1033
		[DataContract]
		public class L2NR_GAUAfT_1033 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_NumberRange_UsageAreaID { get; set; } 
			[DataMember]
			public String GlobalStaticMatchingID { get; set; } 
			[DataMember]
			public Dict UsageArea_Name { get; set; } 
			[DataMember]
			public Dict UsageArea_Description { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2NR_GAUAfT_1033_Array cls_Get_All_UsageAreas_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2NR_GAUAfT_1033_Array invocationResult = cls_Get_All_UsageAreas_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

