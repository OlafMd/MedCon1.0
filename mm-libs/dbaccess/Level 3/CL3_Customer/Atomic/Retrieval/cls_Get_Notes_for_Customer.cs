/* 
 * Generated on 30/9/2014 10:31:36
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

namespace CL3_Customer.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Notes_for_Customer.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Notes_for_Customer
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CU_GNfC_1730_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3CU_GNfC_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CU_GNfC_1730_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Customer.Atomic.Retrieval.SQL.cls_Get_Notes_for_Customer.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RelatedParticipantID", Parameter.RelatedParticipantID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsImportant", Parameter.IsImportant);



			List<L3CU_GNfC_1730> results = new List<L3CU_GNfC_1730>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_MemoID","USR_AccountID","Username","Memo_Text","Creation_Timestamp","IsImportant","CMN_BPT_Memo_RelatedParticipantID","CMN_BPT_BusinessParticipant_RefID","Tenant_RefID" });
				while(reader.Read())
				{
					L3CU_GNfC_1730 resultItem = new L3CU_GNfC_1730();
					//0:Parameter CMN_BPT_MemoID of type Guid
					resultItem.CMN_BPT_MemoID = reader.GetGuid(0);
					//1:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(1);
					//2:Parameter Username of type String
					resultItem.Username = reader.GetString(2);
					//3:Parameter Memo_Text of type String
					resultItem.Memo_Text = reader.GetString(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter IsImportant of type bool
					resultItem.IsImportant = reader.GetBoolean(5);
					//6:Parameter CMN_BPT_Memo_RelatedParticipantID of type Guid
					resultItem.CMN_BPT_Memo_RelatedParticipantID = reader.GetGuid(6);
					//7:Parameter CMN_BPT_BusinessParticipant_RefID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_RefID = reader.GetGuid(7);
					//8:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Notes_for_Customer",ex);
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
		public static FR_L3CU_GNfC_1730_Array Invoke(string ConnectionString,P_L3CU_GNfC_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CU_GNfC_1730_Array Invoke(DbConnection Connection,P_L3CU_GNfC_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CU_GNfC_1730_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CU_GNfC_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CU_GNfC_1730_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CU_GNfC_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CU_GNfC_1730_Array functionReturn = new FR_L3CU_GNfC_1730_Array();
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

				throw new Exception("Exception occured in method cls_Get_Notes_for_Customer",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3CU_GNfC_1730_Array : FR_Base
	{
		public L3CU_GNfC_1730[] Result	{ get; set; } 
		public FR_L3CU_GNfC_1730_Array() : base() {}

		public FR_L3CU_GNfC_1730_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CU_GNfC_1730 for attribute P_L3CU_GNfC_1730
		[DataContract]
		public class P_L3CU_GNfC_1730 
		{
			//Standard type parameters
			[DataMember]
			public Guid RelatedParticipantID { get; set; } 
			[DataMember]
			public bool? IsImportant { get; set; } 

		}
		#endregion
		#region SClass L3CU_GNfC_1730 for attribute L3CU_GNfC_1730
		[DataContract]
		public class L3CU_GNfC_1730 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_MemoID { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public String Memo_Text { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsImportant { get; set; } 
			[DataMember]
			public Guid CMN_BPT_Memo_RelatedParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CU_GNfC_1730_Array cls_Get_Notes_for_Customer(,P_L3CU_GNfC_1730 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CU_GNfC_1730_Array invocationResult = cls_Get_Notes_for_Customer.Invoke(connectionString,P_L3CU_GNfC_1730 Parameter,securityTicket);
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
var parameter = new CL3_Customer.Atomic.Retrieval.P_L3CU_GNfC_1730();
parameter.RelatedParticipantID = ...;
parameter.IsImportant = ...;

*/
