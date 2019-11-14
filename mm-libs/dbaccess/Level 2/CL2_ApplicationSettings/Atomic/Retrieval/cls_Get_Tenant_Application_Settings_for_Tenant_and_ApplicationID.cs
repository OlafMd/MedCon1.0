/* 
 * Generated on 2/4/2014 1:23:52 PM
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
using System.Runtime.Serialization;

namespace CL2_ApplicationSettings.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Tenant_Application_Settings_for_Tenant_and_ApplicationID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Tenant_Application_Settings_for_Tenant_and_ApplicationID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2AS_GTASfTaA_1704_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2AS_GTASfTaA_1704 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2AS_GTASfTaA_1704_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_ApplicationSettings.Atomic.Retrieval.SQL.cls_Get_Tenant_Application_Settings_for_Tenant_and_ApplicationID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ApplicationID", Parameter.ApplicationID);



			List<L2AS_GTASfTaA_1704> results = new List<L2AS_GTASfTaA_1704>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ItemValue","CMN_Tenant_ApplicationSettings_DefinitionsID","ItemKey","DefaultValue" });
				while(reader.Read())
				{
					L2AS_GTASfTaA_1704 resultItem = new L2AS_GTASfTaA_1704();
					//0:Parameter ItemValue of type String
					resultItem.ItemValue = reader.GetString(0);
					//1:Parameter CMN_Tenant_ApplicationSettings_DefinitionsID of type Guid
					resultItem.CMN_Tenant_ApplicationSettings_DefinitionsID = reader.GetGuid(1);
					//2:Parameter ItemKey of type String
					resultItem.ItemKey = reader.GetString(2);
					//3:Parameter DefaultValue of type String
					resultItem.DefaultValue = reader.GetString(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Tenant_Application_Settings_for_Tenant_and_ApplicationID",ex);
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
		public static FR_L2AS_GTASfTaA_1704_Array Invoke(string ConnectionString,P_L2AS_GTASfTaA_1704 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2AS_GTASfTaA_1704_Array Invoke(DbConnection Connection,P_L2AS_GTASfTaA_1704 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2AS_GTASfTaA_1704_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2AS_GTASfTaA_1704 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2AS_GTASfTaA_1704_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2AS_GTASfTaA_1704 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2AS_GTASfTaA_1704_Array functionReturn = new FR_L2AS_GTASfTaA_1704_Array();
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

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Tenant_Application_Settings_for_Tenant_and_ApplicationID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2AS_GTASfTaA_1704_Array : FR_Base
	{
		public L2AS_GTASfTaA_1704[] Result	{ get; set; } 
		public FR_L2AS_GTASfTaA_1704_Array() : base() {}

		public FR_L2AS_GTASfTaA_1704_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2AS_GTASfTaA_1704 for attribute P_L2AS_GTASfTaA_1704
		[DataContract]
		public class P_L2AS_GTASfTaA_1704 
		{
			//Standard type parameters
			[DataMember]
			public Guid ApplicationID { get; set; } 

		}
		#endregion
		#region SClass L2AS_GTASfTaA_1704 for attribute L2AS_GTASfTaA_1704
		[DataContract]
		public class L2AS_GTASfTaA_1704 
		{
			//Standard type parameters
			[DataMember]
			public String ItemValue { get; set; } 
			[DataMember]
			public Guid CMN_Tenant_ApplicationSettings_DefinitionsID { get; set; } 
			[DataMember]
			public String ItemKey { get; set; } 
			[DataMember]
			public String DefaultValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2AS_GTASfTaA_1704_Array cls_Get_Tenant_Application_Settings_for_Tenant_and_ApplicationID(,P_L2AS_GTASfTaA_1704 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2AS_GTASfTaA_1704_Array invocationResult = cls_Get_Tenant_Application_Settings_for_Tenant_and_ApplicationID.Invoke(connectionString,P_L2AS_GTASfTaA_1704 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new CL2_ApplicationSettings.Atomic.Retrieval.P_L2AS_GTASfTaA_1704();
parameter.ApplicationID = ...;

*/
