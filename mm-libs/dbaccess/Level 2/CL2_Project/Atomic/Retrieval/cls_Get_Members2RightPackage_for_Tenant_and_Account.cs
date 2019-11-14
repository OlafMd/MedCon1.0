/* 
 * Generated on 1/29/2014 1:51:39 PM
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

namespace CL2_Project.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Members2RightPackage_for_Tenant_and_Account.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Members2RightPackage_for_Tenant_and_Account
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2_PR_GM2RPfTaA_0948_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2_PR_GM2RPfTaA_0948_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Project.Atomic.Retrieval.SQL.cls_Get_Members2RightPackage_for_Tenant_and_Account.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2_PR_GM2RPfTaA_0948> results = new List<L2_PR_GM2RPfTaA_0948>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "AssignmentID","ACC_RightsPackage_RefID","ProjectMember_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID" });
				while(reader.Read())
				{
					L2_PR_GM2RPfTaA_0948 resultItem = new L2_PR_GM2RPfTaA_0948();
					//0:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(0);
					//1:Parameter ACC_RightsPackage_RefID of type Guid
					resultItem.ACC_RightsPackage_RefID = reader.GetGuid(1);
					//2:Parameter ProjectMember_RefID of type Guid
					resultItem.ProjectMember_RefID = reader.GetGuid(2);
					//3:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(3);
					//4:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(4);
					//5:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Members2RightPackage_for_Tenant_and_Account",ex);
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
		public static FR_L2_PR_GM2RPfTaA_0948_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2_PR_GM2RPfTaA_0948_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2_PR_GM2RPfTaA_0948_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2_PR_GM2RPfTaA_0948_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2_PR_GM2RPfTaA_0948_Array functionReturn = new FR_L2_PR_GM2RPfTaA_0948_Array();
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

				throw new Exception("Exception occured in method cls_Get_Members2RightPackage_for_Tenant_and_Account",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2_PR_GM2RPfTaA_0948_Array : FR_Base
	{
		public L2_PR_GM2RPfTaA_0948[] Result	{ get; set; } 
		public FR_L2_PR_GM2RPfTaA_0948_Array() : base() {}

		public FR_L2_PR_GM2RPfTaA_0948_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2_PR_GM2RPfTaA_0948 for attribute L2_PR_GM2RPfTaA_0948
		[DataContract]
		public class L2_PR_GM2RPfTaA_0948 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid ACC_RightsPackage_RefID { get; set; } 
			[DataMember]
			public Guid ProjectMember_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2_PR_GM2RPfTaA_0948_Array cls_Get_Members2RightPackage_for_Tenant_and_Account(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2_PR_GM2RPfTaA_0948_Array invocationResult = cls_Get_Members2RightPackage_for_Tenant_and_Account.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
