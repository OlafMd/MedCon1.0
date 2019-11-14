/* 
 * Generated on 10/30/2014 9:11:36 AM
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
    /// var result = cls_Get_OrderCollective_for_Member.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OrderCollective_for_Member
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3OC_GOCfM_1544_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3OC_GOCfM_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3OC_GOCfM_1544_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_OrderCollective.Atomic.Retrieval.SQL.cls_Get_OrderCollective_for_Member.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsMemberLead", Parameter.IsMemberLead);



			List<L3OC_GOCfM_1544> results = new List<L3OC_GOCfM_1544>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "OCL_OrderCollectiveID","OrderCollective_Name_DictID","Creation_Timestamp","OrderCollectiveMembersCount","LeadMemberID","LeadBusinessParticipantName","LeadCompanyName" });
				while(reader.Read())
				{
					L3OC_GOCfM_1544 resultItem = new L3OC_GOCfM_1544();
					//0:Parameter OCL_OrderCollectiveID of type Guid
					resultItem.OCL_OrderCollectiveID = reader.GetGuid(0);
					//1:Parameter OrderCollective_Name of type Dict
					resultItem.OrderCollective_Name = reader.GetDictionary(1);
					resultItem.OrderCollective_Name.SourceTable = "ocl_ordercollectives";
					loader.Append(resultItem.OrderCollective_Name);
					//2:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(2);
					//3:Parameter OrderCollectiveMembersCount of type int
					resultItem.OrderCollectiveMembersCount = reader.GetInteger(3);
					//4:Parameter LeadMemberID of type Guid
					resultItem.LeadMemberID = reader.GetGuid(4);
					//5:Parameter LeadBusinessParticipantName of type string
					resultItem.LeadBusinessParticipantName = reader.GetString(5);
					//6:Parameter LeadCompanyName of type string
					resultItem.LeadCompanyName = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_OrderCollective_for_Member",ex);
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
		public static FR_L3OC_GOCfM_1544_Array Invoke(string ConnectionString,P_L3OC_GOCfM_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3OC_GOCfM_1544_Array Invoke(DbConnection Connection,P_L3OC_GOCfM_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3OC_GOCfM_1544_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3OC_GOCfM_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3OC_GOCfM_1544_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3OC_GOCfM_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3OC_GOCfM_1544_Array functionReturn = new FR_L3OC_GOCfM_1544_Array();
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

				throw new Exception("Exception occured in method cls_Get_OrderCollective_for_Member",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3OC_GOCfM_1544_Array : FR_Base
	{
		public L3OC_GOCfM_1544[] Result	{ get; set; } 
		public FR_L3OC_GOCfM_1544_Array() : base() {}

		public FR_L3OC_GOCfM_1544_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3OC_GOCfM_1544 for attribute P_L3OC_GOCfM_1544
		[DataContract]
		public class P_L3OC_GOCfM_1544 
		{
			//Standard type parameters
			[DataMember]
			public bool IsMemberLead { get; set; } 

		}
		#endregion
		#region SClass L3OC_GOCfM_1544 for attribute L3OC_GOCfM_1544
		[DataContract]
		public class L3OC_GOCfM_1544 
		{
			//Standard type parameters
			[DataMember]
			public Guid OCL_OrderCollectiveID { get; set; } 
			[DataMember]
			public Dict OrderCollective_Name { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public int OrderCollectiveMembersCount { get; set; } 
			[DataMember]
			public Guid LeadMemberID { get; set; } 
			[DataMember]
			public string LeadBusinessParticipantName { get; set; } 
			[DataMember]
			public string LeadCompanyName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3OC_GOCfM_1544_Array cls_Get_OrderCollective_for_Member(,P_L3OC_GOCfM_1544 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3OC_GOCfM_1544_Array invocationResult = cls_Get_OrderCollective_for_Member.Invoke(connectionString,P_L3OC_GOCfM_1544 Parameter,securityTicket);
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
var parameter = new CL3_OrderCollective.Atomic.Retrieval.P_L3OC_GOCfM_1544();
parameter.IsMemberLead = ...;

*/
