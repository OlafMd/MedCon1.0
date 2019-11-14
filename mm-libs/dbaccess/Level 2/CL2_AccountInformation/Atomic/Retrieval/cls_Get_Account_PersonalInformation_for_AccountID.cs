/* 
 * Generated on 9/1/2014 10:39:01
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
    /// var result = cls_Get_Account_PersonalInformation_for_AccountID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Account_PersonalInformation_for_AccountID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2AI_GAPIfAI_1627 Execute(DbConnection Connection,DbTransaction Transaction,P_L2AI_GAPIfAI_1627 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2AI_GAPIfAI_1627();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_AccountInformation.Atomic.Retrieval.SQL.cls_Get_Account_PersonalInformation_for_AccountID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AccountRefID", Parameter.AccountRefID);



			List<L2AI_GAPIfAI_1627> results = new List<L2AI_GAPIfAI_1627>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "USR_AccountID","Username","AccountSignInEmailAddress","FirstName","LastName","CMN_LanguageID","ISO_639_2","File_SourceLocation","File_ServerLocation","AccountType","Salutation_General","Salutation_Letter","PrimaryEmail","Title","BirthDate","Gender" });
				while(reader.Read())
				{
					L2AI_GAPIfAI_1627 resultItem = new L2AI_GAPIfAI_1627();
					//0:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(0);
					//1:Parameter Username of type String
					resultItem.Username = reader.GetString(1);
					//2:Parameter AccountSignInEmailAddress of type String
					resultItem.AccountSignInEmailAddress = reader.GetString(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter LastName of type String
					resultItem.LastName = reader.GetString(4);
					//5:Parameter CMN_LanguageID of type Guid
					resultItem.CMN_LanguageID = reader.GetGuid(5);
					//6:Parameter ISO_639_2 of type String
					resultItem.ISO_639_2 = reader.GetString(6);
					//7:Parameter File_SourceLocation of type String
					resultItem.File_SourceLocation = reader.GetString(7);
					//8:Parameter File_ServerLocation of type String
					resultItem.File_ServerLocation = reader.GetString(8);
					//9:Parameter AccountType of type int
					resultItem.AccountType = reader.GetInteger(9);
					//10:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(10);
					//11:Parameter Salutation_Letter of type String
					resultItem.Salutation_Letter = reader.GetString(11);
					//12:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(12);
					//13:Parameter Title of type String
					resultItem.Title = reader.GetString(13);
					//14:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(14);
					//15:Parameter Gender of type int
					resultItem.Gender = reader.GetInteger(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Account_PersonalInformation_for_AccountID",ex);
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
		public static FR_L2AI_GAPIfAI_1627 Invoke(string ConnectionString,P_L2AI_GAPIfAI_1627 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2AI_GAPIfAI_1627 Invoke(DbConnection Connection,P_L2AI_GAPIfAI_1627 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2AI_GAPIfAI_1627 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2AI_GAPIfAI_1627 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2AI_GAPIfAI_1627 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2AI_GAPIfAI_1627 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2AI_GAPIfAI_1627 functionReturn = new FR_L2AI_GAPIfAI_1627();
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

				throw new Exception("Exception occured in method cls_Get_Account_PersonalInformation_for_AccountID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2AI_GAPIfAI_1627 : FR_Base
	{
		public L2AI_GAPIfAI_1627 Result	{ get; set; }

		public FR_L2AI_GAPIfAI_1627() : base() {}

		public FR_L2AI_GAPIfAI_1627(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2AI_GAPIfAI_1627 for attribute P_L2AI_GAPIfAI_1627
		[DataContract]
		public class P_L2AI_GAPIfAI_1627 
		{
			//Standard type parameters
			[DataMember]
			public Guid AccountRefID { get; set; } 

		}
		#endregion
		#region SClass L2AI_GAPIfAI_1627 for attribute L2AI_GAPIfAI_1627
		[DataContract]
		public class L2AI_GAPIfAI_1627 
		{
			//Standard type parameters
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public String AccountSignInEmailAddress { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public Guid CMN_LanguageID { get; set; } 
			[DataMember]
			public String ISO_639_2 { get; set; } 
			[DataMember]
			public String File_SourceLocation { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public int AccountType { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String Salutation_Letter { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public int Gender { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2AI_GAPIfAI_1627 cls_Get_Account_PersonalInformation_for_AccountID(,P_L2AI_GAPIfAI_1627 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2AI_GAPIfAI_1627 invocationResult = cls_Get_Account_PersonalInformation_for_AccountID.Invoke(connectionString,P_L2AI_GAPIfAI_1627 Parameter,securityTicket);
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
var parameter = new CL2_AccountInformation.Atomic.Retrieval.P_L2AI_GAPIfAI_1627();
parameter.AccountRefID = ...;

*/
