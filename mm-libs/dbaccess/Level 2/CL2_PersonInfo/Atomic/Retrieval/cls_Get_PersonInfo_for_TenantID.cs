/* 
 * Generated on 18/10/2013 03:36:40
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

namespace CL2_PersonInfo.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PersonInfo_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PersonInfo_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PI_GPIfT_1234_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PI_GPIfT_1234_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_PersonInfo.Atomic.Retrieval.SQL.cls_Get_PersonInfo_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2PI_GPIfT_1234> results = new List<L2PI_GPIfT_1234>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PER_PersonInfoID","FirstName","LastName","PrimaryEmail","Title","ProfileImage_Document_RefID","BirthDate","Address_RefID","Salutation_General","Salutation_Letter","Gender" });
				while(reader.Read())
				{
					L2PI_GPIfT_1234 resultItem = new L2PI_GPIfT_1234();
					//0:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(3);
					//4:Parameter Title of type String
					resultItem.Title = reader.GetString(4);
					//5:Parameter ProfileImage_Document_RefID of type Guid
					resultItem.ProfileImage_Document_RefID = reader.GetGuid(5);
					//6:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(6);
					//7:Parameter Address_RefID of type Guid
					resultItem.Address_RefID = reader.GetGuid(7);
					//8:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(8);
					//9:Parameter Salutation_Letter of type String
					resultItem.Salutation_Letter = reader.GetString(9);
					//10:Parameter Gender of type String
					resultItem.Gender = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PersonInfo_for_TenantID",ex);
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
		public static FR_L2PI_GPIfT_1234_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PI_GPIfT_1234_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PI_GPIfT_1234_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PI_GPIfT_1234_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PI_GPIfT_1234_Array functionReturn = new FR_L2PI_GPIfT_1234_Array();
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

				throw new Exception("Exception occured in method cls_Get_PersonInfo_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PI_GPIfT_1234_Array : FR_Base
	{
		public L2PI_GPIfT_1234[] Result	{ get; set; } 
		public FR_L2PI_GPIfT_1234_Array() : base() {}

		public FR_L2PI_GPIfT_1234_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2PI_GPIfT_1234 for attribute L2PI_GPIfT_1234
		[DataContract]
		public class L2PI_GPIfT_1234 
		{
			//Standard type parameters
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
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public Guid Address_RefID { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String Salutation_Letter { get; set; } 
			[DataMember]
			public String Gender { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PI_GPIfT_1234_Array cls_Get_PersonInfo_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PI_GPIfT_1234_Array invocationResult = cls_Get_PersonInfo_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

