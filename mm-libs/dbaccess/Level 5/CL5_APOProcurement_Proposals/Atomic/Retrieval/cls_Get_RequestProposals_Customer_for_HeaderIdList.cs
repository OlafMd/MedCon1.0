/* 
 * Generated on 8/25/2014 2:39:41 PM
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
    /// var result = cls_Get_RequestProposals_Customer_for_HeaderIdList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RequestProposals_Customer_for_HeaderIdList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GRPCfHL_1418_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_GRPCfHL_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PR_GRPCfHL_1418_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOProcurement_Proposals.Atomic.Retrieval.SQL.cls_Get_RequestProposals_Customer_for_HeaderIdList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@HeaderID_List"," IN $$HeaderID_List$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$HeaderID_List$",Parameter.HeaderID_List);


			List<L5PR_GRPCfHL_1418> results = new List<L5PR_GRPCfHL_1418>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_RFO_RequestForProposal_HeaderID","RequestingBusinessParticipant_RefID","RequestForProposal_Number","DateOfPublish","ProposalDeadline","CompleteDeliveryUntillDate","RequestForProposalHeaderITPL","ORD_CUO_RFP_RequestForProposal_PositionID","CMN_PRO_Product_RefID","Quantity","IsReplacementPermitted","OrderSequence","DeliveryUntillDate","RequestForProposalPositionITPL" });
				while(reader.Read())
				{
					L5PR_GRPCfHL_1418 resultItem = new L5PR_GRPCfHL_1418();
					//0:Parameter ORD_CUO_RFO_RequestForProposal_HeaderID of type Guid
					resultItem.ORD_CUO_RFO_RequestForProposal_HeaderID = reader.GetGuid(0);
					//1:Parameter RequestingBusinessParticipant_RefID of type Guid
					resultItem.RequestingBusinessParticipant_RefID = reader.GetGuid(1);
					//2:Parameter RequestForProposal_Number of type String
					resultItem.RequestForProposal_Number = reader.GetString(2);
					//3:Parameter DateOfPublish of type DateTime
					resultItem.DateOfPublish = reader.GetDate(3);
					//4:Parameter ProposalDeadline of type String
					resultItem.ProposalDeadline = reader.GetString(4);
					//5:Parameter CompleteDeliveryUntillDate of type DateTime
					resultItem.CompleteDeliveryUntillDate = reader.GetDate(5);
					//6:Parameter RequestForProposalHeaderITPL of type String
					resultItem.RequestForProposalHeaderITPL = reader.GetString(6);
					//7:Parameter ORD_CUO_RFP_RequestForProposal_PositionID of type Guid
					resultItem.ORD_CUO_RFP_RequestForProposal_PositionID = reader.GetGuid(7);
					//8:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(8);
					//9:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(9);
					//10:Parameter IsReplacementPermitted of type bool
					resultItem.IsReplacementPermitted = reader.GetBoolean(10);
					//11:Parameter OrderSequence of type int
					resultItem.OrderSequence = reader.GetInteger(11);
					//12:Parameter DeliveryUntillDate of type DateTime
					resultItem.DeliveryUntillDate = reader.GetDate(12);
					//13:Parameter RequestForProposalPositionITPL of type String
					resultItem.RequestForProposalPositionITPL = reader.GetString(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RequestProposals_Customer_for_HeaderIdList",ex);
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
		public static FR_L5PR_GRPCfHL_1418_Array Invoke(string ConnectionString,P_L5PR_GRPCfHL_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GRPCfHL_1418_Array Invoke(DbConnection Connection,P_L5PR_GRPCfHL_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GRPCfHL_1418_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_GRPCfHL_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GRPCfHL_1418_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_GRPCfHL_1418 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GRPCfHL_1418_Array functionReturn = new FR_L5PR_GRPCfHL_1418_Array();
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

				throw new Exception("Exception occured in method cls_Get_RequestProposals_Customer_for_HeaderIdList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GRPCfHL_1418_Array : FR_Base
	{
		public L5PR_GRPCfHL_1418[] Result	{ get; set; } 
		public FR_L5PR_GRPCfHL_1418_Array() : base() {}

		public FR_L5PR_GRPCfHL_1418_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PR_GRPCfHL_1418 for attribute P_L5PR_GRPCfHL_1418
		[DataContract]
		public class P_L5PR_GRPCfHL_1418 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] HeaderID_List { get; set; } 

		}
		#endregion
		#region SClass L5PR_GRPCfHL_1418 for attribute L5PR_GRPCfHL_1418
		[DataContract]
		public class L5PR_GRPCfHL_1418 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_RFO_RequestForProposal_HeaderID { get; set; } 
			[DataMember]
			public Guid RequestingBusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String RequestForProposal_Number { get; set; } 
			[DataMember]
			public DateTime DateOfPublish { get; set; } 
			[DataMember]
			public String ProposalDeadline { get; set; } 
			[DataMember]
			public DateTime CompleteDeliveryUntillDate { get; set; } 
			[DataMember]
			public String RequestForProposalHeaderITPL { get; set; } 
			[DataMember]
			public Guid ORD_CUO_RFP_RequestForProposal_PositionID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public bool IsReplacementPermitted { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 
			[DataMember]
			public DateTime DeliveryUntillDate { get; set; } 
			[DataMember]
			public String RequestForProposalPositionITPL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GRPCfHL_1418_Array cls_Get_RequestProposals_Customer_for_HeaderIdList(,P_L5PR_GRPCfHL_1418 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GRPCfHL_1418_Array invocationResult = cls_Get_RequestProposals_Customer_for_HeaderIdList.Invoke(connectionString,P_L5PR_GRPCfHL_1418 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Proposals.Atomic.Retrieval.P_L5PR_GRPCfHL_1418();
parameter.HeaderID_List = ...;

*/
