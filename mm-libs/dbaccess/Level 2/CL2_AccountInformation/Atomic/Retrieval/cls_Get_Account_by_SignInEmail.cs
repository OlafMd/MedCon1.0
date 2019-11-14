/* 
 * Generated on 12/10/2013 11:27:25 AM
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
using System.Runtime.Serialization;

namespace CL2_AccountInformation.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Account_by_SignInEmail.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Account_by_SignInEmail
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2AI_GAbSIE_1520 Execute(DbConnection Connection,DbTransaction Transaction,P_L2AI_GAbSIE_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2AI_GAbSIE_1520();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_AccountInformation.Atomic.Retrieval.SQL.cls_Get_Account_by_SignInEmail.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SignInEmail", Parameter.SignInEmail);



			List<L2AI_GAbSIE_1520> results = new List<L2AI_GAbSIE_1520>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "USR_AccountID","DefaultLanguage_RefID","Username","BusinessParticipant_RefID","AccountSignInEmailAddress","AccountType","RemoveViewedNotificationAfterDays" });
				while(reader.Read())
				{
					L2AI_GAbSIE_1520 resultItem = new L2AI_GAbSIE_1520();
					//0:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(0);
					//1:Parameter DefaultLanguage_RefID of type Guid
					resultItem.DefaultLanguage_RefID = reader.GetGuid(1);
					//2:Parameter Username of type String
					resultItem.Username = reader.GetString(2);
					//3:Parameter BusinessParticipant_RefID of type Guid
					resultItem.BusinessParticipant_RefID = reader.GetGuid(3);
					//4:Parameter AccountSignInEmailAddress of type String
					resultItem.AccountSignInEmailAddress = reader.GetString(4);
					//5:Parameter AccountType of type String
					resultItem.AccountType = reader.GetString(5);
					//6:Parameter RemoveViewedNotificationAfterDays of type String
					resultItem.RemoveViewedNotificationAfterDays = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Account_by_SignInEmail",ex);
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
		public static FR_L2AI_GAbSIE_1520 Invoke(string ConnectionString,P_L2AI_GAbSIE_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2AI_GAbSIE_1520 Invoke(DbConnection Connection,P_L2AI_GAbSIE_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2AI_GAbSIE_1520 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2AI_GAbSIE_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2AI_GAbSIE_1520 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2AI_GAbSIE_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2AI_GAbSIE_1520 functionReturn = new FR_L2AI_GAbSIE_1520();
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

				throw new Exception("Exception occured in method cls_Get_Account_by_SignInEmail",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2AI_GAbSIE_1520 : FR_Base
	{
		public L2AI_GAbSIE_1520 Result	{ get; set; }

		public FR_L2AI_GAbSIE_1520() : base() {}

		public FR_L2AI_GAbSIE_1520(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2AI_GAbSIE_1520 for attribute P_L2AI_GAbSIE_1520
		[DataContract]
		public class P_L2AI_GAbSIE_1520 
		{
			//Standard type parameters
			[DataMember]
			public String SignInEmail { get; set; } 

		}
		#endregion
		#region SClass L2AI_GAbSIE_1520 for attribute L2AI_GAbSIE_1520
		[DataContract]
		public class L2AI_GAbSIE_1520 
		{
			//Standard type parameters
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public Guid DefaultLanguage_RefID { get; set; } 
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public Guid BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String AccountSignInEmailAddress { get; set; } 
			[DataMember]
			public String AccountType { get; set; } 
			[DataMember]
			public String RemoveViewedNotificationAfterDays { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2AI_GAbSIE_1520 cls_Get_Account_by_SignInEmail(,P_L2AI_GAbSIE_1520 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2AI_GAbSIE_1520 invocationResult = cls_Get_Account_by_SignInEmail.Invoke(connectionString,P_L2AI_GAbSIE_1520 Parameter,securityTicket);
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
var parameter = new CL2_AccountInformation.Atomic.Retrieval.P_L2AI_GAbSIE_1520();
parameter.SignInEmail = ...;

*/
