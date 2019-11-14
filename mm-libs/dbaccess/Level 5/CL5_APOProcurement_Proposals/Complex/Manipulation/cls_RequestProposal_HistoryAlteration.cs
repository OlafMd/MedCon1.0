/* 
 * Generated on 9/3/2014 2:53:57 PM
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
using CL1_ORD_PRC_RFP;

namespace CL5_APOProcurement_Proposals.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_RequestProposal_HistoryAlteration.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_RequestProposal_HistoryAlteration
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_RPHA_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();
			//Put your code here

            var updatedHeaders = new List<Guid>();

            foreach (var headerID in Parameter.HeaderIDs.Distinct().ToList())
            {
                var header = new ORM_ORD_PRC_RFP_RequestForProposal_Header().Load(Connection, Transaction, headerID);

                var potentialSuppliers = ORM_ORD_PRC_RFP_PotentialSupplier.Query.Search(Connection, Transaction,
                    new ORM_ORD_PRC_RFP_PotentialSupplier.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        RequestForProposal_Header_RefID = headerID,
                        IsDeleted = false
                    }
                    );

                foreach (var supplier in Parameter.PotentialSuppliers.ToList())
                {
                    ORM_ORD_PRC_RFP_PotentialSupplier_History history = new ORM_ORD_PRC_RFP_PotentialSupplier_History();
                    history.ORD_PRC_RFP_PotentialSupplier_HistoryID = Guid.NewGuid();
                    history.ORD_PRC_RFP_PotentialSupplier_RefID = supplier;
                    history.Comment = Parameter.HistoryModel.Comment;
                    history.IsEvent_ProposalRequest_Sent = Parameter.HistoryModel.IsEvent_ProposalRequest_Sent;
                    history.IsEvent_ProposalResponse_Declined = Parameter.HistoryModel.IsEvent_ProposalResponse_Declined;
                    history.IsEvent_ProposalRequest_Revoked = Parameter.HistoryModel.IsEvent_ProposalRequest_Revoked;
                    history.Tenant_RefID = securityTicket.TenantID;

                    history.Save(Connection, Transaction);
                }

                updatedHeaders.Add(headerID);
            }

            returnValue.Result = updatedHeaders.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5PR_RPHA_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5PR_RPHA_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_RPHA_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_RPHA_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guids functionReturn = new FR_Guids();
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

				throw new Exception("Exception occured in method cls_RequestProposal_HistoryAlteration",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PR_RPHA_1546 for attribute P_L5PR_RPHA_1546
		[DataContract]
		public class P_L5PR_RPHA_1546 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] HeaderIDs { get; set; } 
			[DataMember]
			public CL5_APOProcurement_Proposals.Complex.Models.HistoryModel HistoryModel { get; set; } 
			[DataMember]
			public Guid[] PotentialSuppliers { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_RequestProposal_HistoryAlteration(,P_L5PR_RPHA_1546 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_RequestProposal_HistoryAlteration.Invoke(connectionString,P_L5PR_RPHA_1546 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Proposals.Complex.Manipulation.P_L5PR_RPHA_1546();
parameter.HeaderIDs = ...;
parameter.HistoryModel = ...;
parameter.PotentialSuppliers = ...;

*/
