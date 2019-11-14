/* 
 * Generated on 9/16/2014 12:50:56 PM
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
    /// var result = cls_Get_RequestProposals_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RequestProposals_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GRPfTID_1136_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_GRPfTID_1136 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PR_GRPfTID_1136_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOProcurement_Proposals.Atomic.Retrieval.SQL.cls_Get_RequestProposals_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsEvent_ProposalRequest_Sent", Parameter.IsEvent_ProposalRequest_Sent);



			List<L5PR_GRPfTID_1136_raw> results = new List<L5PR_GRPfTID_1136_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_PRC_RFO_RequestForProposal_HeaderID","ORD_PRC_RFP_RequestForProposal_PositionID","CMN_PRO_Product_RefID","OfferReceivedFrom_RegisteredBusinessParticipant_RefID","CreatedFor_RequestForProposal_Header_RefID","DeliveryUntillDate","Quantity","CompleteDeliveryUntillDate","ProposalDeadline","ORD_PRC_RFP_PotentialSupplierID","Deliverer","ORD_PRC_RFP_PotentialSupplier_HistoryID","IsEvent_ProposalRequest_Sent","IsEvent_ProposalResponse_Received","IsEvent_ProposalResponse_Accepted","IsEvent_ProposalResponse_ReceptionAcknowledged","IsEvent_ProposalResponse_Declined","IsEvent_ProposalRequest_Revoked","IsEvent_ProposalResponse_ModificationRequired","Comment" });
				while(reader.Read())
				{
					L5PR_GRPfTID_1136_raw resultItem = new L5PR_GRPfTID_1136_raw();
					//0:Parameter ORD_PRC_RFO_RequestForProposal_HeaderID of type Guid
					resultItem.ORD_PRC_RFO_RequestForProposal_HeaderID = reader.GetGuid(0);
					//1:Parameter ORD_PRC_RFP_RequestForProposal_PositionID of type Guid
					resultItem.ORD_PRC_RFP_RequestForProposal_PositionID = reader.GetGuid(1);
					//2:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(2);
					//3:Parameter OfferReceivedFrom_RegisteredBusinessParticipant_RefID of type Guid
					resultItem.OfferReceivedFrom_RegisteredBusinessParticipant_RefID = reader.GetGuid(3);
					//4:Parameter CreatedFor_RequestForProposal_Header_RefID of type Guid
					resultItem.CreatedFor_RequestForProposal_Header_RefID = reader.GetGuid(4);
					//5:Parameter DeliveryUntillDate of type DateTime
					resultItem.DeliveryUntillDate = reader.GetDate(5);
					//6:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(6);
					//7:Parameter CompleteDeliveryUntillDate of type DateTime
					resultItem.CompleteDeliveryUntillDate = reader.GetDate(7);
					//8:Parameter ProposalDeadline of type DateTime
					resultItem.ProposalDeadline = reader.GetDate(8);
					//9:Parameter ORD_PRC_RFP_PotentialSupplierID of type Guid
					resultItem.ORD_PRC_RFP_PotentialSupplierID = reader.GetGuid(9);
					//10:Parameter Deliverer of type String
					resultItem.Deliverer = reader.GetString(10);
					//11:Parameter ORD_PRC_RFP_PotentialSupplier_HistoryID of type Guid
					resultItem.ORD_PRC_RFP_PotentialSupplier_HistoryID = reader.GetGuid(11);
					//12:Parameter IsEvent_ProposalRequest_Sent of type bool
					resultItem.IsEvent_ProposalRequest_Sent = reader.GetBoolean(12);
					//13:Parameter IsEvent_ProposalResponse_Received of type bool
					resultItem.IsEvent_ProposalResponse_Received = reader.GetBoolean(13);
					//14:Parameter IsEvent_ProposalResponse_Accepted of type bool
					resultItem.IsEvent_ProposalResponse_Accepted = reader.GetBoolean(14);
					//15:Parameter IsEvent_ProposalResponse_ReceptionAcknowledged of type bool
					resultItem.IsEvent_ProposalResponse_ReceptionAcknowledged = reader.GetBoolean(15);
					//16:Parameter IsEvent_ProposalResponse_Declined of type bool
					resultItem.IsEvent_ProposalResponse_Declined = reader.GetBoolean(16);
					//17:Parameter IsEvent_ProposalRequest_Revoked of type bool
					resultItem.IsEvent_ProposalRequest_Revoked = reader.GetBoolean(17);
					//18:Parameter IsEvent_ProposalResponse_ModificationRequired of type bool
					resultItem.IsEvent_ProposalResponse_ModificationRequired = reader.GetBoolean(18);
					//19:Parameter Comment of type String
					resultItem.Comment = reader.GetString(19);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RequestProposals_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5PR_GRPfTID_1136_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PR_GRPfTID_1136_Array Invoke(string ConnectionString,P_L5PR_GRPfTID_1136 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GRPfTID_1136_Array Invoke(DbConnection Connection,P_L5PR_GRPfTID_1136 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GRPfTID_1136_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_GRPfTID_1136 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GRPfTID_1136_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_GRPfTID_1136 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GRPfTID_1136_Array functionReturn = new FR_L5PR_GRPfTID_1136_Array();
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

				throw new Exception("Exception occured in method cls_Get_RequestProposals_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5PR_GRPfTID_1136_raw 
	{
		public Guid ORD_PRC_RFO_RequestForProposal_HeaderID; 
		public Guid ORD_PRC_RFP_RequestForProposal_PositionID; 
		public Guid CMN_PRO_Product_RefID; 
		public Guid OfferReceivedFrom_RegisteredBusinessParticipant_RefID; 
		public Guid CreatedFor_RequestForProposal_Header_RefID; 
		public DateTime DeliveryUntillDate; 
		public double Quantity; 
		public DateTime CompleteDeliveryUntillDate; 
		public DateTime ProposalDeadline; 
		public Guid ORD_PRC_RFP_PotentialSupplierID; 
		public String Deliverer; 
		public Guid ORD_PRC_RFP_PotentialSupplier_HistoryID; 
		public bool IsEvent_ProposalRequest_Sent; 
		public bool IsEvent_ProposalResponse_Received; 
		public bool IsEvent_ProposalResponse_Accepted; 
		public bool IsEvent_ProposalResponse_ReceptionAcknowledged; 
		public bool IsEvent_ProposalResponse_Declined; 
		public bool IsEvent_ProposalRequest_Revoked; 
		public bool IsEvent_ProposalResponse_ModificationRequired; 
		public String Comment; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5PR_GRPfTID_1136[] Convert(List<L5PR_GRPfTID_1136_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5PR_GRPfTID_1136 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ORD_PRC_RFO_RequestForProposal_HeaderID)).ToArray()
	group el_L5PR_GRPfTID_1136 by new 
	{ 
		el_L5PR_GRPfTID_1136.ORD_PRC_RFO_RequestForProposal_HeaderID,

	}
	into gfunct_L5PR_GRPfTID_1136
	select new L5PR_GRPfTID_1136
	{     
		ORD_PRC_RFO_RequestForProposal_HeaderID = gfunct_L5PR_GRPfTID_1136.Key.ORD_PRC_RFO_RequestForProposal_HeaderID ,
		ORD_PRC_RFP_RequestForProposal_PositionID = gfunct_L5PR_GRPfTID_1136.FirstOrDefault().ORD_PRC_RFP_RequestForProposal_PositionID ,
		CMN_PRO_Product_RefID = gfunct_L5PR_GRPfTID_1136.FirstOrDefault().CMN_PRO_Product_RefID ,
		OfferReceivedFrom_RegisteredBusinessParticipant_RefID = gfunct_L5PR_GRPfTID_1136.FirstOrDefault().OfferReceivedFrom_RegisteredBusinessParticipant_RefID ,
		CreatedFor_RequestForProposal_Header_RefID = gfunct_L5PR_GRPfTID_1136.FirstOrDefault().CreatedFor_RequestForProposal_Header_RefID ,
		DeliveryUntillDate = gfunct_L5PR_GRPfTID_1136.FirstOrDefault().DeliveryUntillDate ,
		Quantity = gfunct_L5PR_GRPfTID_1136.FirstOrDefault().Quantity ,
		CompleteDeliveryUntillDate = gfunct_L5PR_GRPfTID_1136.FirstOrDefault().CompleteDeliveryUntillDate ,
		ProposalDeadline = gfunct_L5PR_GRPfTID_1136.FirstOrDefault().ProposalDeadline ,

		PotentialSuppliers = 
		(
			from el_PotentialSuppliers in gfunct_L5PR_GRPfTID_1136.Where(element => !EqualsDefaultValue(element.ORD_PRC_RFP_PotentialSupplierID)).ToArray()
			group el_PotentialSuppliers by new 
			{ 
				el_PotentialSuppliers.ORD_PRC_RFP_PotentialSupplierID,

			}
			into gfunct_PotentialSuppliers
			select new L5PR_GRPfTID_1136_PotentialSuppliers
			{     
				ORD_PRC_RFP_PotentialSupplierID = gfunct_PotentialSuppliers.Key.ORD_PRC_RFP_PotentialSupplierID ,
				Deliverer = gfunct_PotentialSuppliers.FirstOrDefault().Deliverer ,

				SupplierHistories = 
				(
					from el_SupplierHistories in gfunct_PotentialSuppliers.ToArray()
					select new L5PR_GRPfTID_1136_SupplierHistory
					{     
						ORD_PRC_RFP_PotentialSupplier_HistoryID = el_SupplierHistories.ORD_PRC_RFP_PotentialSupplier_HistoryID,
						IsEvent_ProposalRequest_Sent = el_SupplierHistories.IsEvent_ProposalRequest_Sent,
						IsEvent_ProposalResponse_Received = el_SupplierHistories.IsEvent_ProposalResponse_Received,
						IsEvent_ProposalResponse_Accepted = el_SupplierHistories.IsEvent_ProposalResponse_Accepted,
						IsEvent_ProposalResponse_ReceptionAcknowledged = el_SupplierHistories.IsEvent_ProposalResponse_ReceptionAcknowledged,
						IsEvent_ProposalResponse_Declined = el_SupplierHistories.IsEvent_ProposalResponse_Declined,
						IsEvent_ProposalRequest_Revoked = el_SupplierHistories.IsEvent_ProposalRequest_Revoked,
						IsEvent_ProposalResponse_ModificationRequired = el_SupplierHistories.IsEvent_ProposalResponse_ModificationRequired,
						Comment = el_SupplierHistories.Comment,

					}
				).ToArray(),

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GRPfTID_1136_Array : FR_Base
	{
		public L5PR_GRPfTID_1136[] Result	{ get; set; } 
		public FR_L5PR_GRPfTID_1136_Array() : base() {}

		public FR_L5PR_GRPfTID_1136_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PR_GRPfTID_1136 for attribute P_L5PR_GRPfTID_1136
		[DataContract]
		public class P_L5PR_GRPfTID_1136 
		{
			//Standard type parameters
			[DataMember]
			public bool IsEvent_ProposalRequest_Sent { get; set; } 

		}
		#endregion
		#region SClass L5PR_GRPfTID_1136 for attribute L5PR_GRPfTID_1136
		[DataContract]
		public class L5PR_GRPfTID_1136 
		{
			[DataMember]
			public L5PR_GRPfTID_1136_PotentialSuppliers[] PotentialSuppliers { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_RFO_RequestForProposal_HeaderID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_RFP_RequestForProposal_PositionID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid OfferReceivedFrom_RegisteredBusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid CreatedFor_RequestForProposal_Header_RefID { get; set; } 
			[DataMember]
			public DateTime DeliveryUntillDate { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public DateTime CompleteDeliveryUntillDate { get; set; } 
			[DataMember]
			public DateTime ProposalDeadline { get; set; } 

		}
		#endregion
		#region SClass L5PR_GRPfTID_1136_PotentialSuppliers for attribute PotentialSuppliers
		[DataContract]
		public class L5PR_GRPfTID_1136_PotentialSuppliers 
		{
			[DataMember]
			public L5PR_GRPfTID_1136_SupplierHistory[] SupplierHistories { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_RFP_PotentialSupplierID { get; set; } 
			[DataMember]
			public String Deliverer { get; set; } 

		}
		#endregion
		#region SClass L5PR_GRPfTID_1136_SupplierHistory for attribute SupplierHistories
		[DataContract]
		public class L5PR_GRPfTID_1136_SupplierHistory 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_RFP_PotentialSupplier_HistoryID { get; set; } 
			[DataMember]
			public bool IsEvent_ProposalRequest_Sent { get; set; } 
			[DataMember]
			public bool IsEvent_ProposalResponse_Received { get; set; } 
			[DataMember]
			public bool IsEvent_ProposalResponse_Accepted { get; set; } 
			[DataMember]
			public bool IsEvent_ProposalResponse_ReceptionAcknowledged { get; set; } 
			[DataMember]
			public bool IsEvent_ProposalResponse_Declined { get; set; } 
			[DataMember]
			public bool IsEvent_ProposalRequest_Revoked { get; set; } 
			[DataMember]
			public bool IsEvent_ProposalResponse_ModificationRequired { get; set; } 
			[DataMember]
			public String Comment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GRPfTID_1136_Array cls_Get_RequestProposals_for_TenantID(,P_L5PR_GRPfTID_1136 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GRPfTID_1136_Array invocationResult = cls_Get_RequestProposals_for_TenantID.Invoke(connectionString,P_L5PR_GRPfTID_1136 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Proposals.Atomic.Retrieval.P_L5PR_GRPfTID_1136();
parameter.IsEvent_ProposalRequest_Sent = ...;

*/
