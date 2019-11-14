/* 
 * Generated on 7/31/2014 10:24:19 AM
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

namespace CL5_APOBilling_BillCrediting.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Reimbursements_and_GrantedCreditNotes_for_BillPositions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Reimbursements_and_GrantedCreditNotes_for_BillPositions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BC_GRaGCNfBP_1021_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BC_GRaGCNfBP_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BC_GRaGCNfBP_1021_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_BillCrediting.Atomic.Retrieval.SQL.cls_Get_Reimbursements_and_GrantedCreditNotes_for_BillPositions.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@BillPositionIDs"," IN $$BillPositionIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$BillPositionIDs$",Parameter.BillPositionIDs);


			List<L5BC_GRaGCNfBP_1021> results = new List<L5BC_GRaGCNfBP_1021>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "BIL_BillPosition_RefID","BIL_BillPosition_ReimbursementID","ACC_CRN_GrantedCreditNoteID" });
				while(reader.Read())
				{
					L5BC_GRaGCNfBP_1021 resultItem = new L5BC_GRaGCNfBP_1021();
					//0:Parameter BIL_BillPosition_RefID of type Guid
					resultItem.BIL_BillPosition_RefID = reader.GetGuid(0);
					//1:Parameter BIL_BillPosition_ReimbursementID of type Guid
					resultItem.BIL_BillPosition_ReimbursementID = reader.GetGuid(1);
					//2:Parameter ACC_CRN_GrantedCreditNoteID of type Guid
					resultItem.ACC_CRN_GrantedCreditNoteID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Reimbursements_and_GrantedCreditNotes_for_BillPositions",ex);
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
		public static FR_L5BC_GRaGCNfBP_1021_Array Invoke(string ConnectionString,P_L5BC_GRaGCNfBP_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BC_GRaGCNfBP_1021_Array Invoke(DbConnection Connection,P_L5BC_GRaGCNfBP_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BC_GRaGCNfBP_1021_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BC_GRaGCNfBP_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BC_GRaGCNfBP_1021_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BC_GRaGCNfBP_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BC_GRaGCNfBP_1021_Array functionReturn = new FR_L5BC_GRaGCNfBP_1021_Array();
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

				throw new Exception("Exception occured in method cls_Get_Reimbursements_and_GrantedCreditNotes_for_BillPositions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BC_GRaGCNfBP_1021_Array : FR_Base
	{
		public L5BC_GRaGCNfBP_1021[] Result	{ get; set; } 
		public FR_L5BC_GRaGCNfBP_1021_Array() : base() {}

		public FR_L5BC_GRaGCNfBP_1021_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BC_GRaGCNfBP_1021 for attribute P_L5BC_GRaGCNfBP_1021
		[DataContract]
		public class P_L5BC_GRaGCNfBP_1021 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] BillPositionIDs { get; set; } 

		}
		#endregion
		#region SClass L5BC_GRaGCNfBP_1021 for attribute L5BC_GRaGCNfBP_1021
		[DataContract]
		public class L5BC_GRaGCNfBP_1021 
		{
			//Standard type parameters
			[DataMember]
			public Guid BIL_BillPosition_RefID { get; set; } 
			[DataMember]
			public Guid BIL_BillPosition_ReimbursementID { get; set; } 
			[DataMember]
			public Guid ACC_CRN_GrantedCreditNoteID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BC_GRaGCNfBP_1021_Array cls_Get_Reimbursements_and_GrantedCreditNotes_for_BillPositions(,P_L5BC_GRaGCNfBP_1021 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BC_GRaGCNfBP_1021_Array invocationResult = cls_Get_Reimbursements_and_GrantedCreditNotes_for_BillPositions.Invoke(connectionString,P_L5BC_GRaGCNfBP_1021 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_BillCrediting.Atomic.Retrieval.P_L5BC_GRaGCNfBP_1021();
parameter.BillPositionIDs = ...;

*/