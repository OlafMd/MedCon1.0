/* 
 * Generated on 03-Dec-14 3:15:49 PM
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
    /// var result = cls_Get_UserInformation_for_AccountID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_UserInformation_for_AccountID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3US_GUIfAID_1514 Execute(DbConnection Connection,DbTransaction Transaction,P_L3US_GUIfAID_1514 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3US_GUIfAID_1514();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_User.Atomic.Retrieval.SQL.cls_Get_UserInformation_for_AccountID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"UserAccountID", Parameter.UserAccountID);



			List<L3US_GUIfAID_1514> results = new List<L3US_GUIfAID_1514>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Username","DefaultLanguage_RefID","CMN_PER_PersonInfoID","FirstName","LastName","PrimaryEmail","Title","ProfileImage_Document_RefID","USR_Account_RefID","File_ServerLocation","File_SourceLocation" });
				while(reader.Read())
				{
					L3US_GUIfAID_1514 resultItem = new L3US_GUIfAID_1514();
					//0:Parameter Username of type String
					resultItem.Username = reader.GetString(0);
					//1:Parameter DefaultLanguage_RefID of type Guid
					resultItem.DefaultLanguage_RefID = reader.GetGuid(1);
					//2:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter LastName of type String
					resultItem.LastName = reader.GetString(4);
					//5:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(5);
					//6:Parameter Title of type String
					resultItem.Title = reader.GetString(6);
					//7:Parameter ProfileImage_Document_RefID of type Guid
					resultItem.ProfileImage_Document_RefID = reader.GetGuid(7);
					//8:Parameter USR_Account_RefID of type Guid
					resultItem.USR_Account_RefID = reader.GetGuid(8);
					//9:Parameter File_ServerLocation of type String
					resultItem.File_ServerLocation = reader.GetString(9);
					//10:Parameter File_SourceLocation of type String
					resultItem.File_SourceLocation = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_UserInformation_for_AccountID",ex);
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
		public static FR_L3US_GUIfAID_1514 Invoke(string ConnectionString,P_L3US_GUIfAID_1514 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3US_GUIfAID_1514 Invoke(DbConnection Connection,P_L3US_GUIfAID_1514 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3US_GUIfAID_1514 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3US_GUIfAID_1514 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3US_GUIfAID_1514 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3US_GUIfAID_1514 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3US_GUIfAID_1514 functionReturn = new FR_L3US_GUIfAID_1514();
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

				throw new Exception("Exception occured in method cls_Get_UserInformation_for_AccountID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3US_GUIfAID_1514 : FR_Base
	{
		public L3US_GUIfAID_1514 Result	{ get; set; }

		public FR_L3US_GUIfAID_1514() : base() {}

		public FR_L3US_GUIfAID_1514(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3US_GUIfAID_1514 for attribute P_L3US_GUIfAID_1514
		[DataContract]
		public class P_L3US_GUIfAID_1514 
		{
			//Standard type parameters
			[DataMember]
			public Guid UserAccountID { get; set; } 

		}
		#endregion
		#region SClass L3US_GUIfAID_1514 for attribute L3US_GUIfAID_1514
		[DataContract]
		public class L3US_GUIfAID_1514 
		{
			//Standard type parameters
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public Guid DefaultLanguage_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public Guid ProfileImage_Document_RefID { get; set; } 
			[DataMember]
			public Guid USR_Account_RefID { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public String File_SourceLocation { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3US_GUIfAID_1514 cls_Get_UserInformation_for_AccountID(,P_L3US_GUIfAID_1514 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3US_GUIfAID_1514 invocationResult = cls_Get_UserInformation_for_AccountID.Invoke(connectionString,P_L3US_GUIfAID_1514 Parameter,securityTicket);
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
var parameter = new CL3_User.Atomic.Retrieval.P_L3US_GUIfAID_1514();
parameter.UserAccountID = ...;

*/
