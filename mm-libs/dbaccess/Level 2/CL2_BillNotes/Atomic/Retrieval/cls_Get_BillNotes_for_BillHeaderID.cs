/* 
 * Generated on 6/10/2014 05:40:08
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

namespace CL2_BillNotes.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BillNotes_for_BillHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BillNotes_for_BillHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2BN_GBNfBH_1058_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2BN_GBNfBH_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2BN_GBNfBH_1058_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_BillNotes.Atomic.Retrieval.SQL.cls_Get_BillNotes_for_BillHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillHeaderID", Parameter.BillHeaderID);



			List<L2BN_GBNfBH_1058> results = new List<L2BN_GBNfBH_1058>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "BIL_Note","BillHeader_RefID","BillPosition_RefID","CreatedBy_BusinessParticipant_RefID","Creation_Timestamp","IsDeleted","NoteText","SequenceOrderNumber","Tenant_RefID","Title","CreatedBy" });
				while(reader.Read())
				{
					L2BN_GBNfBH_1058 resultItem = new L2BN_GBNfBH_1058();
					//0:Parameter BIL_Note of type Guid
					resultItem.BIL_Note = reader.GetGuid(0);
					//1:Parameter BillHeader_RefID of type Guid
					resultItem.BillHeader_RefID = reader.GetGuid(1);
					//2:Parameter BillPosition_RefID of type Guid
					resultItem.BillPosition_RefID = reader.GetGuid(2);
					//3:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
					resultItem.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(5);
					//6:Parameter NoteText of type String
					resultItem.NoteText = reader.GetString(6);
					//7:Parameter SequenceOrderNumber of type int
					resultItem.SequenceOrderNumber = reader.GetInteger(7);
					//8:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(8);
					//9:Parameter Title of type String
					resultItem.Title = reader.GetString(9);
					//10:Parameter CreatedBy of type String
					resultItem.CreatedBy = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BillNotes_for_BillHeaderID",ex);
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
		public static FR_L2BN_GBNfBH_1058_Array Invoke(string ConnectionString,P_L2BN_GBNfBH_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2BN_GBNfBH_1058_Array Invoke(DbConnection Connection,P_L2BN_GBNfBH_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2BN_GBNfBH_1058_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2BN_GBNfBH_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2BN_GBNfBH_1058_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2BN_GBNfBH_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2BN_GBNfBH_1058_Array functionReturn = new FR_L2BN_GBNfBH_1058_Array();
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

				throw new Exception("Exception occured in method cls_Get_BillNotes_for_BillHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2BN_GBNfBH_1058_Array : FR_Base
	{
		public L2BN_GBNfBH_1058[] Result	{ get; set; } 
		public FR_L2BN_GBNfBH_1058_Array() : base() {}

		public FR_L2BN_GBNfBH_1058_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2BN_GBNfBH_1058 for attribute P_L2BN_GBNfBH_1058
		[DataContract]
		public class P_L2BN_GBNfBH_1058 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 

		}
		#endregion
		#region SClass L2BN_GBNfBH_1058 for attribute L2BN_GBNfBH_1058
		[DataContract]
		public class L2BN_GBNfBH_1058 
		{
			//Standard type parameters
			[DataMember]
			public Guid BIL_Note { get; set; } 
			[DataMember]
			public Guid BillHeader_RefID { get; set; } 
			[DataMember]
			public Guid BillPosition_RefID { get; set; } 
			[DataMember]
			public Guid CreatedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public String NoteText { get; set; } 
			[DataMember]
			public int SequenceOrderNumber { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String CreatedBy { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2BN_GBNfBH_1058_Array cls_Get_BillNotes_for_BillHeaderID(,P_L2BN_GBNfBH_1058 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2BN_GBNfBH_1058_Array invocationResult = cls_Get_BillNotes_for_BillHeaderID.Invoke(connectionString,P_L2BN_GBNfBH_1058 Parameter,securityTicket);
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
var parameter = new CL2_BillNotes.Atomic.Retrieval.P_L2BN_GBNfBH_1058();
parameter.BillHeaderID = ...;

*/
