/* 
 * Generated on 1/14/2014 3:01:43 PM
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

namespace CL3_Catalog.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CatalogProductExtensionRequests_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CatalogProductExtensionRequests_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CA_GCPERfT_1137_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CA_GCPERfT_1137_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Catalog.Atomic.Retrieval.SQL.cls_Get_CatalogProductExtensionRequests_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3CA_GCPERfT_1137> results = new List<L3CA_GCPERfT_1137>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_CTM_CatalogProductExtensionRequestID","RequestCaseIdentifier","RequestedBy_Person_BusinessParticipant_RefID","RequestedBy_Customer_BusinessParticipant_RefID","IfAnswerSent_By_BusinessParticipant_RefID","RequestedFor_Catalog_RefID","Doctor_FirstName","Doctor_LastName","Doctor_Title","CompanyName","CatalogProductExtensionRequestITL","Request_Question","Request_Answer","IsAnswerSent","IfAnswerSent_Date","RequestDate" });
				while(reader.Read())
				{
					L3CA_GCPERfT_1137 resultItem = new L3CA_GCPERfT_1137();
					//0:Parameter CMN_BPT_CTM_CatalogProductExtensionRequestID of type Guid
					resultItem.CMN_BPT_CTM_CatalogProductExtensionRequestID = reader.GetGuid(0);
					//1:Parameter RequestCaseIdentifier of type String
					resultItem.RequestCaseIdentifier = reader.GetString(1);
					//2:Parameter RequestedBy_Person_BusinessParticipant_RefID of type Guid
					resultItem.RequestedBy_Person_BusinessParticipant_RefID = reader.GetGuid(2);
					//3:Parameter RequestedBy_Customer_BusinessParticipant_RefID of type Guid
					resultItem.RequestedBy_Customer_BusinessParticipant_RefID = reader.GetGuid(3);
					//4:Parameter IfAnswerSent_By_BusinessParticipant_RefID of type Guid
					resultItem.IfAnswerSent_By_BusinessParticipant_RefID = reader.GetGuid(4);
					//5:Parameter RequestedFor_Catalog_RefID of type Guid
					resultItem.RequestedFor_Catalog_RefID = reader.GetGuid(5);
					//6:Parameter Doctor_FirstName of type String
					resultItem.Doctor_FirstName = reader.GetString(6);
					//7:Parameter Doctor_LastName of type String
					resultItem.Doctor_LastName = reader.GetString(7);
					//8:Parameter Doctor_Title of type String
					resultItem.Doctor_Title = reader.GetString(8);
					//9:Parameter CompanyName of type String
					resultItem.CompanyName = reader.GetString(9);
					//10:Parameter CatalogProductExtensionRequestITL of type String
					resultItem.CatalogProductExtensionRequestITL = reader.GetString(10);
					//11:Parameter Request_Question of type String
					resultItem.Request_Question = reader.GetString(11);
					//12:Parameter Request_Answer of type String
					resultItem.Request_Answer = reader.GetString(12);
					//13:Parameter IsAnswerSent of type bool
					resultItem.IsAnswerSent = reader.GetBoolean(13);
					//14:Parameter IfAnswerSent_Date of type DateTime
					resultItem.IfAnswerSent_Date = reader.GetDate(14);
					//15:Parameter RequestDate of type DateTime
					resultItem.RequestDate = reader.GetDate(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CatalogProductExtensionRequests_for_TenantID",ex);
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
		public static FR_L3CA_GCPERfT_1137_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CA_GCPERfT_1137_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CA_GCPERfT_1137_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CA_GCPERfT_1137_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CA_GCPERfT_1137_Array functionReturn = new FR_L3CA_GCPERfT_1137_Array();
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

				throw new Exception("Exception occured in method cls_Get_CatalogProductExtensionRequests_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3CA_GCPERfT_1137_Array : FR_Base
	{
		public L3CA_GCPERfT_1137[] Result	{ get; set; } 
		public FR_L3CA_GCPERfT_1137_Array() : base() {}

		public FR_L3CA_GCPERfT_1137_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3CA_GCPERfT_1137 for attribute L3CA_GCPERfT_1137
		[DataContract]
		public class L3CA_GCPERfT_1137 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_CatalogProductExtensionRequestID { get; set; } 
			[DataMember]
			public String RequestCaseIdentifier { get; set; } 
			[DataMember]
			public Guid RequestedBy_Person_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid RequestedBy_Customer_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid IfAnswerSent_By_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid RequestedFor_Catalog_RefID { get; set; } 
			[DataMember]
			public String Doctor_FirstName { get; set; } 
			[DataMember]
			public String Doctor_LastName { get; set; } 
			[DataMember]
			public String Doctor_Title { get; set; } 
			[DataMember]
			public String CompanyName { get; set; } 
			[DataMember]
			public String CatalogProductExtensionRequestITL { get; set; } 
			[DataMember]
			public String Request_Question { get; set; } 
			[DataMember]
			public String Request_Answer { get; set; } 
			[DataMember]
			public bool IsAnswerSent { get; set; } 
			[DataMember]
			public DateTime IfAnswerSent_Date { get; set; } 
			[DataMember]
			public DateTime RequestDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CA_GCPERfT_1137_Array cls_Get_CatalogProductExtensionRequests_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CA_GCPERfT_1137_Array invocationResult = cls_Get_CatalogProductExtensionRequests_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

