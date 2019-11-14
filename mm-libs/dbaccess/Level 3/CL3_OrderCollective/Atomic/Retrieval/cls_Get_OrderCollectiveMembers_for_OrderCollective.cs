/* 
 * Generated on 11/13/2014 6:16:13 PM
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

namespace CL3_OrderCollective.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_OrderCollectiveMembers_for_OrderCollective.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OrderCollectiveMembers_for_OrderCollective
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3OC_GOCMfOC_1329_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3OC_GOCMfOC_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3OC_GOCMfOC_1329_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_OrderCollective.Atomic.Retrieval.SQL.cls_Get_OrderCollectiveMembers_for_OrderCollective.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderCollectiveID", Parameter.OrderCollectiveID);



			List<L3OC_GOCMfOC_1329> results = new List<L3OC_GOCMfOC_1329>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "OCL_OrderCollective_MemberID","OrderCollective_RefID","OrderCollectiveMemberITL","IsOrderCollectiveLead","BusinessParticipant_RefID","MemberSince","EndOfMembership","Creation_Timestamp","BusinessParticipantDispalyName","BusinessParticipantITL","IsCompany","CMN_UniversalContactDetailID","UniversalContactDetailsITL","UniversalContactDetailCompanyName","Contact_Email","MemberTenantID","MemberTenantITL","CompanyInfoUniversalContactDetailsID","CompanyInfoUniversalContactDetailsITL" });
				while(reader.Read())
				{
					L3OC_GOCMfOC_1329 resultItem = new L3OC_GOCMfOC_1329();
					//0:Parameter OCL_OrderCollective_MemberID of type Guid
					resultItem.OCL_OrderCollective_MemberID = reader.GetGuid(0);
					//1:Parameter OrderCollective_RefID of type Guid
					resultItem.OrderCollective_RefID = reader.GetGuid(1);
					//2:Parameter OrderCollectiveMemberITL of type String
					resultItem.OrderCollectiveMemberITL = reader.GetString(2);
					//3:Parameter IsOrderCollectiveLead of type bool
					resultItem.IsOrderCollectiveLead = reader.GetBoolean(3);
					//4:Parameter BusinessParticipant_RefID of type Guid
					resultItem.BusinessParticipant_RefID = reader.GetGuid(4);
					//5:Parameter MemberSince of type DateTime
					resultItem.MemberSince = reader.GetDate(5);
					//6:Parameter EndOfMembership of type DateTime
					resultItem.EndOfMembership = reader.GetDate(6);
					//7:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(7);
					//8:Parameter BusinessParticipantDispalyName of type string
					resultItem.BusinessParticipantDispalyName = reader.GetString(8);
					//9:Parameter BusinessParticipantITL of type String
					resultItem.BusinessParticipantITL = reader.GetString(9);
					//10:Parameter IsCompany of type bool
					resultItem.IsCompany = reader.GetBoolean(10);
					//11:Parameter CMN_UniversalContactDetailID of type Guid
					resultItem.CMN_UniversalContactDetailID = reader.GetGuid(11);
					//12:Parameter UniversalContactDetailsITL of type String
					resultItem.UniversalContactDetailsITL = reader.GetString(12);
					//13:Parameter UniversalContactDetailCompanyName of type String
					resultItem.UniversalContactDetailCompanyName = reader.GetString(13);
					//14:Parameter Contact_Email of type String
					resultItem.Contact_Email = reader.GetString(14);
					//15:Parameter MemberTenantID of type Guid
					resultItem.MemberTenantID = reader.GetGuid(15);
					//16:Parameter MemberTenantITL of type String
					resultItem.MemberTenantITL = reader.GetString(16);
					//17:Parameter CompanyInfoUniversalContactDetailsID of type Guid
					resultItem.CompanyInfoUniversalContactDetailsID = reader.GetGuid(17);
					//18:Parameter CompanyInfoUniversalContactDetailsITL of type String
					resultItem.CompanyInfoUniversalContactDetailsITL = reader.GetString(18);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_OrderCollectiveMembers_for_OrderCollective",ex);
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
		public static FR_L3OC_GOCMfOC_1329_Array Invoke(string ConnectionString,P_L3OC_GOCMfOC_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3OC_GOCMfOC_1329_Array Invoke(DbConnection Connection,P_L3OC_GOCMfOC_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3OC_GOCMfOC_1329_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3OC_GOCMfOC_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3OC_GOCMfOC_1329_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3OC_GOCMfOC_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3OC_GOCMfOC_1329_Array functionReturn = new FR_L3OC_GOCMfOC_1329_Array();
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

				throw new Exception("Exception occured in method cls_Get_OrderCollectiveMembers_for_OrderCollective",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3OC_GOCMfOC_1329_Array : FR_Base
	{
		public L3OC_GOCMfOC_1329[] Result	{ get; set; } 
		public FR_L3OC_GOCMfOC_1329_Array() : base() {}

		public FR_L3OC_GOCMfOC_1329_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3OC_GOCMfOC_1329 for attribute P_L3OC_GOCMfOC_1329
		[DataContract]
		public class P_L3OC_GOCMfOC_1329 
		{
			//Standard type parameters
			[DataMember]
			public Guid OrderCollectiveID { get; set; } 

		}
		#endregion
		#region SClass L3OC_GOCMfOC_1329 for attribute L3OC_GOCMfOC_1329
		[DataContract]
		public class L3OC_GOCMfOC_1329 
		{
			//Standard type parameters
			[DataMember]
			public Guid OCL_OrderCollective_MemberID { get; set; } 
			[DataMember]
			public Guid OrderCollective_RefID { get; set; } 
			[DataMember]
			public String OrderCollectiveMemberITL { get; set; } 
			[DataMember]
			public bool IsOrderCollectiveLead { get; set; } 
			[DataMember]
			public Guid BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public DateTime MemberSince { get; set; } 
			[DataMember]
			public DateTime EndOfMembership { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public string BusinessParticipantDispalyName { get; set; } 
			[DataMember]
			public String BusinessParticipantITL { get; set; } 
			[DataMember]
			public bool IsCompany { get; set; } 
			[DataMember]
			public Guid CMN_UniversalContactDetailID { get; set; } 
			[DataMember]
			public String UniversalContactDetailsITL { get; set; } 
			[DataMember]
			public String UniversalContactDetailCompanyName { get; set; } 
			[DataMember]
			public String Contact_Email { get; set; } 
			[DataMember]
			public Guid MemberTenantID { get; set; } 
			[DataMember]
			public String MemberTenantITL { get; set; } 
			[DataMember]
			public Guid CompanyInfoUniversalContactDetailsID { get; set; } 
			[DataMember]
			public String CompanyInfoUniversalContactDetailsITL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3OC_GOCMfOC_1329_Array cls_Get_OrderCollectiveMembers_for_OrderCollective(,P_L3OC_GOCMfOC_1329 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3OC_GOCMfOC_1329_Array invocationResult = cls_Get_OrderCollectiveMembers_for_OrderCollective.Invoke(connectionString,P_L3OC_GOCMfOC_1329 Parameter,securityTicket);
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
var parameter = new CL3_OrderCollective.Atomic.Retrieval.P_L3OC_GOCMfOC_1329();
parameter.OrderCollectiveID = ...;

*/
