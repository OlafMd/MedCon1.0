/* 
 * Generated on 8/26/2013 11:20:14 AM
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
    /// var result = cls_Get_LoggedAccount.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LoggedAccount
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2AI_GLA_1038 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2AI_GLA_1038();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_AccountInformation.Atomic.Retrieval.SQL.cls_Get_LoggedAccount.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2AI_GLA_1038> results = new List<L2AI_GLA_1038>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "USR_AccountID","DefaultLanguage_RefID","Username","CMN_PER_PersonInfoID","ProfileImage_Document_RefID","Tenant_RefID","CMN_AddressID","BusinessParticipant_RefID","FirstName","LastName","PrimaryEmail","Title","Salutation_General","Salutation_Letter","Street_Name","Street_Number","City_AdministrativeDistrict","City_Region","City_Name","City_PostalCode","Country_ISOCode","Country_Name","Province_Name","BirthDate","AccountType" });
				while(reader.Read())
				{
					L2AI_GLA_1038 resultItem = new L2AI_GLA_1038();
					//0:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(0);
					//1:Parameter DefaultLanguage_RefID of type Guid
					resultItem.DefaultLanguage_RefID = reader.GetGuid(1);
					//2:Parameter Username of type String
					resultItem.Username = reader.GetString(2);
					//3:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(3);
					//4:Parameter ProfileImage_Document_RefID of type Guid
					resultItem.ProfileImage_Document_RefID = reader.GetGuid(4);
					//5:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(5);
					//6:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(6);
					//7:Parameter BusinessParticipant_RefID of type Guid
					resultItem.BusinessParticipant_RefID = reader.GetGuid(7);
					//8:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(8);
					//9:Parameter LastName of type String
					resultItem.LastName = reader.GetString(9);
					//10:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(10);
					//11:Parameter Title of type String
					resultItem.Title = reader.GetString(11);
					//12:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(12);
					//13:Parameter Salutation_Letter of type String
					resultItem.Salutation_Letter = reader.GetString(13);
					//14:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(14);
					//15:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(15);
					//16:Parameter City_AdministrativeDistrict of type String
					resultItem.City_AdministrativeDistrict = reader.GetString(16);
					//17:Parameter City_Region of type String
					resultItem.City_Region = reader.GetString(17);
					//18:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(18);
					//19:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(19);
					//20:Parameter Country_ISOCode of type String
					resultItem.Country_ISOCode = reader.GetString(20);
					//21:Parameter Country_Name of type String
					resultItem.Country_Name = reader.GetString(21);
					//22:Parameter Province_Name of type String
					resultItem.Province_Name = reader.GetString(22);
					//23:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(23);
					//24:Parameter AccountType of type int
					resultItem.AccountType = reader.GetInteger(24);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_LoggedAccount",ex);
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
		public static FR_L2AI_GLA_1038 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2AI_GLA_1038 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2AI_GLA_1038 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2AI_GLA_1038 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2AI_GLA_1038 functionReturn = new FR_L2AI_GLA_1038();
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

				throw new Exception("Exception occured in method cls_Get_LoggedAccount",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2AI_GLA_1038 : FR_Base
	{
		public L2AI_GLA_1038 Result	{ get; set; }

		public FR_L2AI_GLA_1038() : base() {}

		public FR_L2AI_GLA_1038(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2AI_GLA_1038 for attribute L2AI_GLA_1038
		[DataContract]
		public class L2AI_GLA_1038 
		{
			//Standard type parameters
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public Guid DefaultLanguage_RefID { get; set; } 
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public Guid ProfileImage_Document_RefID { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public Guid BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String Salutation_Letter { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_AdministrativeDistrict { get; set; } 
			[DataMember]
			public String City_Region { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 
			[DataMember]
			public String Province_Name { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public int AccountType { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2AI_GLA_1038 cls_Get_LoggedAccount(string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_L2AI_GLA_1038 invocationResult = cls_Get_LoggedAccount.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
