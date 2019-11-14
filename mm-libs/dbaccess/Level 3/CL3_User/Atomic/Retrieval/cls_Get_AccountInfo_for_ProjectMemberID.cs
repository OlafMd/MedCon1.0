/* 
 * Generated on 03-Dec-14 3:12:21 PM
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

namespace CL3_User.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AccountInfo_for_ProjectMemberID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AccountInfo_for_ProjectMemberID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3US_GAIfPMID_1508 Execute(DbConnection Connection,DbTransaction Transaction,P_L3US_GAIfPMID_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3US_GAIfPMID_1508();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_User.Atomic.Retrieval.SQL.cls_Get_AccountInfo_for_ProjectMemberID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProjectMember", Parameter.ProjectMember);



			List<L3US_GAIfPMID_1508> results = new List<L3US_GAIfPMID_1508>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Username","BusinessParticipant_RefID","USR_AccountID","AccountType","DefaultLanguage_RefID" });
				while(reader.Read())
				{
					L3US_GAIfPMID_1508 resultItem = new L3US_GAIfPMID_1508();
					//0:Parameter Username of type String
					resultItem.Username = reader.GetString(0);
					//1:Parameter BusinessParticipant_RefID of type Guid
					resultItem.BusinessParticipant_RefID = reader.GetGuid(1);
					//2:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(2);
					//3:Parameter AccountType of type String
					resultItem.AccountType = reader.GetString(3);
					//4:Parameter DefaultLanguage_RefID of type Guid
					resultItem.DefaultLanguage_RefID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AccountInfo_for_ProjectMemberID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3US_GAIfPMID_1508 Invoke(string ConnectionString,P_L3US_GAIfPMID_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3US_GAIfPMID_1508 Invoke(DbConnection Connection,P_L3US_GAIfPMID_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3US_GAIfPMID_1508 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3US_GAIfPMID_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3US_GAIfPMID_1508 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3US_GAIfPMID_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3US_GAIfPMID_1508 functionReturn = new FR_L3US_GAIfPMID_1508();
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

				throw new Exception("Exception occured in method cls_Get_AccountInfo_for_ProjectMemberID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3US_GAIfPMID_1508 : FR_Base
	{
		public L3US_GAIfPMID_1508 Result	{ get; set; }

		public FR_L3US_GAIfPMID_1508() : base() {}

		public FR_L3US_GAIfPMID_1508(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3US_GAIfPMID_1508 for attribute P_L3US_GAIfPMID_1508
		[DataContract]
		public class P_L3US_GAIfPMID_1508 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectMember { get; set; } 

		}
		#endregion
		#region SClass L3US_GAIfPMID_1508 for attribute L3US_GAIfPMID_1508
		[DataContract]
		public class L3US_GAIfPMID_1508 
		{
			//Standard type parameters
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public Guid BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public String AccountType { get; set; } 
			[DataMember]
			public Guid DefaultLanguage_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3US_GAIfPMID_1508 cls_Get_AccountInfo_for_ProjectMemberID(,P_L3US_GAIfPMID_1508 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3US_GAIfPMID_1508 invocationResult = cls_Get_AccountInfo_for_ProjectMemberID.Invoke(connectionString,P_L3US_GAIfPMID_1508 Parameter,securityTicket);
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
var parameter = new CL3_User.Atomic.Retrieval.P_L3US_GAIfPMID_1508();
parameter.ProjectMember = ...;

*/
