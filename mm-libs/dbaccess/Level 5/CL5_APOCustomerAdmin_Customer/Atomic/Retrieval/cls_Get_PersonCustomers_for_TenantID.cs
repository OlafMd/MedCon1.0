/* 
 * Generated on 9/26/2014 4:36:40 PM
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

namespace CL5_APOCustomerAdmin_Customer.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PersonCustomers_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PersonCustomers_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ACACU_GCCfT_1715_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ACACU_GCCfT_1715_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOCustomerAdmin_Customer.Atomic.Retrieval.SQL.cls_Get_PersonCustomers_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5ACACU_GCCfT_1715> results = new List<L5ACACU_GCCfT_1715>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_CTM_CustomerID","LastName","CMN_PER_PersonInfoID","FirstName","CMN_BPT_BusinessParticipantID","BirthDate","ACC_PAY_Type_RefID","InternalCustomerNumber","ACC_PAY_Condition_RefID","DisplayName","IsRepresentedByLegalGuardian","LegalGuardianDisplayName","IsCustomerOrderAutomaticallyApprovedOnReceipt","NumberOfComments" });
				while(reader.Read())
				{
					L5ACACU_GCCfT_1715 resultItem = new L5ACACU_GCCfT_1715();
					//0:Parameter CMN_BPT_CTM_CustomerID of type Guid
					resultItem.CMN_BPT_CTM_CustomerID = reader.GetGuid(0);
					//1:Parameter LastName of type String
					resultItem.LastName = reader.GetString(1);
					//2:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(4);
					//5:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(5);
					//6:Parameter ACC_PAY_Type_RefID of type Guid
					resultItem.ACC_PAY_Type_RefID = reader.GetGuid(6);
					//7:Parameter InternalCustomerNumber of type String
					resultItem.InternalCustomerNumber = reader.GetString(7);
					//8:Parameter ACC_PAY_Condition_RefID of type Guid
					resultItem.ACC_PAY_Condition_RefID = reader.GetGuid(8);
					//9:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(9);
					//10:Parameter IsRepresentedByLegalGuardian of type bool
					resultItem.IsRepresentedByLegalGuardian = reader.GetBoolean(10);
					//11:Parameter LegalGuardianDisplayName of type String
					resultItem.LegalGuardianDisplayName = reader.GetString(11);
					//12:Parameter IsCustomerOrderAutomaticallyApprovedOnReceipt of type bool
					resultItem.IsCustomerOrderAutomaticallyApprovedOnReceipt = reader.GetBoolean(12);
					//13:Parameter NumberOfComments of type int
					resultItem.NumberOfComments = reader.GetInteger(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PersonCustomers_for_TenantID",ex);
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
		public static FR_L5ACACU_GCCfT_1715_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ACACU_GCCfT_1715_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ACACU_GCCfT_1715_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ACACU_GCCfT_1715_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ACACU_GCCfT_1715_Array functionReturn = new FR_L5ACACU_GCCfT_1715_Array();
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

				throw new Exception("Exception occured in method cls_Get_PersonCustomers_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ACACU_GCCfT_1715_Array : FR_Base
	{
		public L5ACACU_GCCfT_1715[] Result	{ get; set; } 
		public FR_L5ACACU_GCCfT_1715_Array() : base() {}

		public FR_L5ACACU_GCCfT_1715_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5ACACU_GCCfT_1715 for attribute L5ACACU_GCCfT_1715
		[DataContract]
		public class L5ACACU_GCCfT_1715 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public Guid ACC_PAY_Type_RefID { get; set; } 
			[DataMember]
			public String InternalCustomerNumber { get; set; } 
			[DataMember]
			public Guid ACC_PAY_Condition_RefID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public bool IsRepresentedByLegalGuardian { get; set; } 
			[DataMember]
			public String LegalGuardianDisplayName { get; set; } 
			[DataMember]
			public bool IsCustomerOrderAutomaticallyApprovedOnReceipt { get; set; } 
			[DataMember]
			public int NumberOfComments { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ACACU_GCCfT_1715_Array cls_Get_PersonCustomers_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ACACU_GCCfT_1715_Array invocationResult = cls_Get_PersonCustomers_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

