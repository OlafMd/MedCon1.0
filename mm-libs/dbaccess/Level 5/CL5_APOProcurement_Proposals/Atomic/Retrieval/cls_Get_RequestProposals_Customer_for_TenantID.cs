/* 
 * Generated on 9/10/2014 1:11:45 PM
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

namespace CL5_APOProcurement_Proposals.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RequestProposals_Customer_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RequestProposals_Customer_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GRPCfTID_1657_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PR_GRPCfTID_1657_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOProcurement_Proposals.Atomic.Retrieval.SQL.cls_Get_RequestProposals_Customer_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5PR_GRPCfTID_1657> results = new List<L5PR_GRPCfTID_1657>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Product_RefID","IsReplacementPermitted","Quantity","DeliveryUntillDate","ORD_CUO_RFO_RequestForProposal_HeaderID","CompleteDeliveryUntillDate","ProposalDeadline","Comment","IsEvent_ProposalResponse_Sent","IsEvent_ProposalRequest_Received","IsEvent_ProposalRequest_ReceptionAcknowledged","IsEvent_ByCustomer_ProposalResponse_Declined","IsEvent_ByCustomer_ProposalResponse_Accepted","RequestingBusinessParticipant_RefID","ORD_CUO_RFP_RequestForProposal_PositionID" });
				while(reader.Read())
				{
					L5PR_GRPCfTID_1657 resultItem = new L5PR_GRPCfTID_1657();
					//0:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(0);
					//1:Parameter IsReplacementPermitted of type bool
					resultItem.IsReplacementPermitted = reader.GetBoolean(1);
					//2:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(2);
					//3:Parameter DeliveryUntillDate of type DateTime
					resultItem.DeliveryUntillDate = reader.GetDate(3);
					//4:Parameter ORD_CUO_RFO_RequestForProposal_HeaderID of type Guid
					resultItem.ORD_CUO_RFO_RequestForProposal_HeaderID = reader.GetGuid(4);
					//5:Parameter CompleteDeliveryUntillDate of type DateTime
					resultItem.CompleteDeliveryUntillDate = reader.GetDate(5);
					//6:Parameter ProposalDeadline of type String
					resultItem.ProposalDeadline = reader.GetString(6);
					//7:Parameter Comment of type String
					resultItem.Comment = reader.GetString(7);
					//8:Parameter IsEvent_ProposalResponse_Sent of type bool
					resultItem.IsEvent_ProposalResponse_Sent = reader.GetBoolean(8);
					//9:Parameter IsEvent_ProposalRequest_Received of type bool
					resultItem.IsEvent_ProposalRequest_Received = reader.GetBoolean(9);
					//10:Parameter IsEvent_ProposalRequest_ReceptionAcknowledged of type bool
					resultItem.IsEvent_ProposalRequest_ReceptionAcknowledged = reader.GetBoolean(10);
					//11:Parameter IsEvent_ByCustomer_ProposalResponse_Declined of type bool
					resultItem.IsEvent_ByCustomer_ProposalResponse_Declined = reader.GetBoolean(11);
					//12:Parameter IsEvent_ByCustomer_ProposalResponse_Accepted of type bool
					resultItem.IsEvent_ByCustomer_ProposalResponse_Accepted = reader.GetBoolean(12);
					//13:Parameter RequestingBusinessParticipant_RefID of type Guid
					resultItem.RequestingBusinessParticipant_RefID = reader.GetGuid(13);
					//14:Parameter ORD_CUO_RFP_RequestForProposal_PositionID of type Guid
					resultItem.ORD_CUO_RFP_RequestForProposal_PositionID = reader.GetGuid(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RequestProposals_Customer_for_TenantID",ex);
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
		public static FR_L5PR_GRPCfTID_1657_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GRPCfTID_1657_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GRPCfTID_1657_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GRPCfTID_1657_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GRPCfTID_1657_Array functionReturn = new FR_L5PR_GRPCfTID_1657_Array();
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

				throw new Exception("Exception occured in method cls_Get_RequestProposals_Customer_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GRPCfTID_1657_Array : FR_Base
	{
		public L5PR_GRPCfTID_1657[] Result	{ get; set; } 
		public FR_L5PR_GRPCfTID_1657_Array() : base() {}

		public FR_L5PR_GRPCfTID_1657_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5PR_GRPCfTID_1657 for attribute L5PR_GRPCfTID_1657
		[DataContract]
		public class L5PR_GRPCfTID_1657 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public bool IsReplacementPermitted { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public DateTime DeliveryUntillDate { get; set; } 
			[DataMember]
			public Guid ORD_CUO_RFO_RequestForProposal_HeaderID { get; set; } 
			[DataMember]
			public DateTime CompleteDeliveryUntillDate { get; set; } 
			[DataMember]
			public String ProposalDeadline { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public bool IsEvent_ProposalResponse_Sent { get; set; } 
			[DataMember]
			public bool IsEvent_ProposalRequest_Received { get; set; } 
			[DataMember]
			public bool IsEvent_ProposalRequest_ReceptionAcknowledged { get; set; } 
			[DataMember]
			public bool IsEvent_ByCustomer_ProposalResponse_Declined { get; set; } 
			[DataMember]
			public bool IsEvent_ByCustomer_ProposalResponse_Accepted { get; set; } 
			[DataMember]
			public Guid RequestingBusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid ORD_CUO_RFP_RequestForProposal_PositionID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GRPCfTID_1657_Array cls_Get_RequestProposals_Customer_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GRPCfTID_1657_Array invocationResult = cls_Get_RequestProposals_Customer_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

