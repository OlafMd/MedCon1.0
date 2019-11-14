/* 
 * Generated on 1/29/2014 1:47:24 PM
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
    /// var result = cls_Get_PersonInfo_For_Tenant_Mobile.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PersonInfo_For_Tenant_Mobile
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PI_GPIfTM_1556_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PI_GPIfTM_1556_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_PersonInfo.Atomic.Retrieval.SQL.cls_Get_PersonInfo_For_Tenant_Mobile.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2PI_GPIfTM_1556> results = new List<L2PI_GPIfTM_1556>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "NumberOfChildren","Gender","Salutation_Letter","Salutation_General","Tenant_RefID","IsDeleted","Creation_Timestamp","Address_RefID","BirthDate","ProfileImage_Document_RefID","Title","PrimaryEmail","LastName","FirstName","CMN_PER_PersonInfoID" });
				while(reader.Read())
				{
					L2PI_GPIfTM_1556 resultItem = new L2PI_GPIfTM_1556();
					//0:Parameter NumberOfChildren of type String
					resultItem.NumberOfChildren = reader.GetString(0);
					//1:Parameter Gender of type String
					resultItem.Gender = reader.GetString(1);
					//2:Parameter Salutation_Letter of type String
					resultItem.Salutation_Letter = reader.GetString(2);
					//3:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(3);
					//4:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(4);
					//5:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(5);
					//6:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(6);
					//7:Parameter Address_RefID of type Guid
					resultItem.Address_RefID = reader.GetGuid(7);
					//8:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(8);
					//9:Parameter ProfileImage_Document_RefID of type Guid
					resultItem.ProfileImage_Document_RefID = reader.GetGuid(9);
					//10:Parameter Title of type String
					resultItem.Title = reader.GetString(10);
					//11:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(11);
					//12:Parameter LastName of type String
					resultItem.LastName = reader.GetString(12);
					//13:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(13);
					//14:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PersonInfo_For_Tenant_Mobile",ex);
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
		public static FR_L2PI_GPIfTM_1556_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PI_GPIfTM_1556_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PI_GPIfTM_1556_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PI_GPIfTM_1556_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PI_GPIfTM_1556_Array functionReturn = new FR_L2PI_GPIfTM_1556_Array();
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

				throw new Exception("Exception occured in method cls_Get_PersonInfo_For_Tenant_Mobile",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PI_GPIfTM_1556_Array : FR_Base
	{
		public L2PI_GPIfTM_1556[] Result	{ get; set; } 
		public FR_L2PI_GPIfTM_1556_Array() : base() {}

		public FR_L2PI_GPIfTM_1556_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2PI_GPIfTM_1556 for attribute L2PI_GPIfTM_1556
		[DataContract]
		public class L2PI_GPIfTM_1556 
		{
			//Standard type parameters
			[DataMember]
			public String NumberOfChildren { get; set; } 
			[DataMember]
			public String Gender { get; set; } 
			[DataMember]
			public String Salutation_Letter { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Address_RefID { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public Guid ProfileImage_Document_RefID { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PI_GPIfTM_1556_Array cls_Get_PersonInfo_For_Tenant_Mobile(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PI_GPIfTM_1556_Array invocationResult = cls_Get_PersonInfo_For_Tenant_Mobile.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

