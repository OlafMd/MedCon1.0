/* 
 * Generated on 10/15/2014 16:40:09
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
    /// var result = cls_Get_Project_Membership_for_Account_and_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Project_Membership_for_Account_and_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PR_GPMfAaT_1228_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PR_GPMfAaT_1228_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Project.Atomic.Retrieval.SQL.cls_Get_Project_Membership_for_Account_and_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2PR_GPMfAaT_1228> results = new List<L2PR_GPMfAaT_1228>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_ProjectMemberID","USR_Account_RefID","Project_RefID","IsOwner","Creation_Timestamp","IsDeleted","Tenant_RefID","ProjectMember_Type_RefID","ChargingLevel_RefID" });
				while(reader.Read())
				{
					L2PR_GPMfAaT_1228 resultItem = new L2PR_GPMfAaT_1228();
					//0:Parameter TMS_PRO_ProjectMemberID of type Guid
					resultItem.TMS_PRO_ProjectMemberID = reader.GetGuid(0);
					//1:Parameter USR_Account_RefID of type Guid
					resultItem.USR_Account_RefID = reader.GetGuid(1);
					//2:Parameter Project_RefID of type Guid
					resultItem.Project_RefID = reader.GetGuid(2);
					//3:Parameter IsOwner of type bool
					resultItem.IsOwner = reader.GetBoolean(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(5);
					//6:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(6);
					//7:Parameter ProjectMember_Type_RefID of type Guid
					resultItem.ProjectMember_Type_RefID = reader.GetGuid(7);
					//8:Parameter ChargingLevel_RefID of type Guid
					resultItem.ChargingLevel_RefID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Project_Membership_for_Account_and_Tenant",ex);
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
		public static FR_L2PR_GPMfAaT_1228_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PR_GPMfAaT_1228_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PR_GPMfAaT_1228_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PR_GPMfAaT_1228_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PR_GPMfAaT_1228_Array functionReturn = new FR_L2PR_GPMfAaT_1228_Array();
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

				throw new Exception("Exception occured in method cls_Get_Project_Membership_for_Account_and_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PR_GPMfAaT_1228_Array : FR_Base
	{
		public L2PR_GPMfAaT_1228[] Result	{ get; set; } 
		public FR_L2PR_GPMfAaT_1228_Array() : base() {}

		public FR_L2PR_GPMfAaT_1228_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2PR_GPMfAaT_1228 for attribute L2PR_GPMfAaT_1228
		[DataContract]
		public class L2PR_GPMfAaT_1228 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_ProjectMemberID { get; set; } 
			[DataMember]
			public Guid USR_Account_RefID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public bool IsOwner { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Guid ProjectMember_Type_RefID { get; set; } 
			[DataMember]
			public Guid ChargingLevel_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PR_GPMfAaT_1228_Array cls_Get_Project_Membership_for_Account_and_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PR_GPMfAaT_1228_Array invocationResult = cls_Get_Project_Membership_for_Account_and_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

