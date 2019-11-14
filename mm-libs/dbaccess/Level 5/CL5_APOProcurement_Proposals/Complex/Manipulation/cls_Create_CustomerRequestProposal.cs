/* 
 * Generated on 8/26/2014 11:11:09 AM
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
using CL1_ORD_CUO_RFP;
using CL1_HEC_CUO_RFP;

namespace CL5_APOProcurement_Proposals.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_CustomerRequestProposal.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_CustomerRequestProposal
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_CCRP_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            ORM_ORD_CUO_RFP_RequestForProposal_Header customerHeader = new ORM_ORD_CUO_RFP_RequestForProposal_Header();

            var incrNumberParam = new CL2_NumberRange.Complex.Retrieval.P_L2NR_GaIINfUA_1454()
            {
                GlobalStaticMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.ENumberRangeUsageAreaType.CUORequestProposalNumberCustomer)
            };

            var requestProposalNumber = CL2_NumberRange.Complex.Retrieval.
                   cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

            customerHeader.ORD_CUO_RFO_RequestForProposal_HeaderID = Guid.NewGuid();
            customerHeader.CompleteDeliveryUntillDate = Parameter.CompleteDeliveryUntil;
            customerHeader.RequestForProposalHeaderITPL = Parameter.RequestForProposalHeaderITPL;
            customerHeader.ProposalDeadline = Parameter.ProposalDeadline;
            customerHeader.RequestingBusinessParticipant_RefID = Parameter.RequestingBusinessParticipant;
            customerHeader.RequestForProposal_Number = requestProposalNumber;
            customerHeader.Tenant_RefID = securityTicket.TenantID;
            customerHeader.Save(Connection, Transaction);

            ORM_ORD_CUO_RFP_RequestForProposal_History customerProposalHistory = new ORM_ORD_CUO_RFP_RequestForProposal_History();
            customerProposalHistory.ORD_CUO_RFP_RequestForProposal_HistoryID = Guid.NewGuid();
            customerProposalHistory.RequestForProposal_Header_RefID = customerHeader.ORD_CUO_RFO_RequestForProposal_HeaderID;
            customerProposalHistory.Tenant_RefID = securityTicket.TenantID;
            customerProposalHistory.Save(Connection, Transaction);

            ORM_HEC_CUO_RFP_RequestForProposal_Header hecHeader = new ORM_HEC_CUO_RFP_RequestForProposal_Header();
            hecHeader.HEC_CUO_RFP_RequestForProposal_HeaderID = Guid.NewGuid();
            hecHeader.Ext_ORD_CUO_RFP_RequestForProposal_Header_RefID = customerHeader.ORD_CUO_RFO_RequestForProposal_HeaderID;
            hecHeader.Tenant_RefID = securityTicket.TenantID;
            hecHeader.Save(Connection, Transaction);

            foreach (var position in Parameter.Positions.ToList())
            {
                ORM_ORD_CUO_RFP_RequestForProposal_Position customerPosition = new ORM_ORD_CUO_RFP_RequestForProposal_Position();
                customerPosition.ORD_CUO_RFP_RequestForProposal_PositionID = Guid.NewGuid();
                customerPosition.RequestForProposalPositionITPL = position.RequestForProposalPositionITPL;
                customerPosition.Quantity = position.Quantity;
                customerPosition.CMN_PRO_Product_RefID = position.ProductID;
                customerPosition.DeliveryUntillDate = position.LatestDateOfDelivery;
                customerPosition.IsReplacementPermitted = position.IsReplacementAllowed;
                customerPosition.RequestForProposal_Header_RefID = customerHeader.ORD_CUO_RFO_RequestForProposal_HeaderID;
                customerPosition.Tenant_RefID = securityTicket.TenantID;
                customerPosition.Save(Connection, Transaction);

                ORM_HEC_CUO_RFP_RequestForProposal_Position hecPosition = new ORM_HEC_CUO_RFP_RequestForProposal_Position();
                hecPosition.HEC_CUO_RFP_RequestForProposal_PositionID = Guid.NewGuid();
                hecPosition.Ext_ORD_CUO_RFP_RequestForProposal_Position_RefID = customerPosition.ORD_CUO_RFP_RequestForProposal_PositionID;
                hecPosition.Tenant_RefID = securityTicket.TenantID;
                hecPosition.Save(Connection, Transaction);
            }

            returnValue.Result = customerHeader.ORD_CUO_RFO_RequestForProposal_HeaderID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PR_CCRP_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PR_CCRP_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_CCRP_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_CCRP_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Create_CustomerRequestProposal",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PR_CCRP_1631 for attribute P_L5PR_CCRP_1631
		[DataContract]
		public class P_L5PR_CCRP_1631 
		{
			[DataMember]
			public P_L5PR_CCRP_1631a[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public DateTime ProposalDeadline { get; set; } 
			[DataMember]
			public DateTime CompleteDeliveryUntil { get; set; } 
			[DataMember]
			public Guid RequestingBusinessParticipant { get; set; } 
			[DataMember]
			public string RequestForProposalHeaderITPL { get; set; } 

		}
		#endregion
		#region SClass P_L5PR_CCRP_1631a for attribute Positions
		[DataContract]
		public class P_L5PR_CCRP_1631a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public DateTime LatestDateOfDelivery { get; set; } 
			[DataMember]
			public bool IsReplacementAllowed  { get; set; } 
			[DataMember]
			public string RequestForProposalPositionITPL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_CustomerRequestProposal(,P_L5PR_CCRP_1631 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_CustomerRequestProposal.Invoke(connectionString,P_L5PR_CCRP_1631 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Proposals.Complex.Manipulation.P_L5PR_CCRP_1631();
parameter.Positions = ...;

parameter.ProposalDeadline = ...;
parameter.CompleteDeliveryUntil = ...;
parameter.RequestingBusinessParticipant = ...;
parameter.RequestForProposalHeaderITPL = ...;

*/
