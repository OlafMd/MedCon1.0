/* 
 * Generated on 1/29/2014 1:42:36 PM
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

namespace CL2_DeveloperTask.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperTask_Priorities_for_Tenant_and_Acount.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperTask_Priorities_for_Tenant_and_Acount
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2_DT_GDTSfTaA_1337_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2_DT_GDTSfTaA_1337_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperTask_Priorities_for_Tenant_and_Acount.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2_DT_GDTSfTaA_1337> results = new List<L2_DT_GDTSfTaA_1337>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_DeveloperTask_PriorityID","Label_DictID","Description_DictID","IconLocationURL","Groups","PriorityLevel","IsPersistent","Creation_Timestamp","Tenant_RefID","IsDeleted","Priority_Colour","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L2_DT_GDTSfTaA_1337 resultItem = new L2_DT_GDTSfTaA_1337();
					//0:Parameter TMS_PRO_DeveloperTask_PriorityID of type Guid
					resultItem.TMS_PRO_DeveloperTask_PriorityID = reader.GetGuid(0);
					//1:Parameter Label of type Dict
					resultItem.Label = reader.GetDictionary(1);
					resultItem.Label.SourceTable = "tms_pro_developertask_priorities";
					loader.Append(resultItem.Label);
					//2:Parameter Description of type Dict
					resultItem.Description = reader.GetDictionary(2);
					resultItem.Description.SourceTable = "tms_pro_developertask_priorities";
					loader.Append(resultItem.Description);
					//3:Parameter IconLocationURL of type String
					resultItem.IconLocationURL = reader.GetString(3);
					//4:Parameter Groups of type String
					resultItem.Groups = reader.GetString(4);
					//5:Parameter PriorityLevel of type String
					resultItem.PriorityLevel = reader.GetString(5);
					//6:Parameter IsPersistent of type bool
					resultItem.IsPersistent = reader.GetBoolean(6);
					//7:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(7);
					//8:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(8);
					//9:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(9);
					//10:Parameter Priority_Colour of type String
					resultItem.Priority_Colour = reader.GetString(10);
					//11:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperTask_Priorities_for_Tenant_and_Acount",ex);
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
		public static FR_L2_DT_GDTSfTaA_1337_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2_DT_GDTSfTaA_1337_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2_DT_GDTSfTaA_1337_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2_DT_GDTSfTaA_1337_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2_DT_GDTSfTaA_1337_Array functionReturn = new FR_L2_DT_GDTSfTaA_1337_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperTask_Priorities_for_Tenant_and_Acount",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2_DT_GDTSfTaA_1337_Array : FR_Base
	{
		public L2_DT_GDTSfTaA_1337[] Result	{ get; set; } 
		public FR_L2_DT_GDTSfTaA_1337_Array() : base() {}

		public FR_L2_DT_GDTSfTaA_1337_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2_DT_GDTSfTaA_1337 for attribute L2_DT_GDTSfTaA_1337
		[DataContract]
		public class L2_DT_GDTSfTaA_1337 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_DeveloperTask_PriorityID { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public String IconLocationURL { get; set; } 
			[DataMember]
			public String Groups { get; set; } 
			[DataMember]
			public String PriorityLevel { get; set; } 
			[DataMember]
			public bool IsPersistent { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public String Priority_Colour { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2_DT_GDTSfTaA_1337_Array cls_Get_DeveloperTask_Priorities_for_Tenant_and_Acount(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2_DT_GDTSfTaA_1337_Array invocationResult = cls_Get_DeveloperTask_Priorities_for_Tenant_and_Acount.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

