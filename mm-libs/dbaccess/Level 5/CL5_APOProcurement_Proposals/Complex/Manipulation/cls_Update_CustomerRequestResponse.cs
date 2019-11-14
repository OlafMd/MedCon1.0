/* 
 * Generated on 9/17/2014 9:03:34 AM
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

namespace CL5_APOProcurement_Proposals.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Update_CustomerRequestResponse.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Update_CustomerRequestResponse
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_UCRR_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();
			//Put your code here

            var responsesToBeCancelled = ORM_ORD_CUO_RFP_IssuedProposalResponse_Header.Query.Search(Connection, Transaction,
            new ORM_ORD_CUO_RFP_IssuedProposalResponse_Header.Query()
            {
                CreatedFor_RequestForProposal_Header_RefID = Parameter.RequestHeaderID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            });

            foreach (var responseHeader in responsesToBeCancelled)
            {
                var responsePositionsToBeCancelled = ORM_ORD_CUO_RFP_IssuedProposalResponse_Position.Query.Search(Connection, Transaction,
                   new ORM_ORD_CUO_RFP_IssuedProposalResponse_Position.Query()
                   {
                       IssuedProposalResponseHeader_RefID = responseHeader.ORD_CUO_RFP_IssuedProposalResponse_HeaderID,
                       IsDeleted = false,
                       Tenant_RefID = securityTicket.TenantID
                   });

                foreach (var responsePosition in responsePositionsToBeCancelled)
                {
                    responsePosition.IsDeleted = true;
                    responsePosition.Save(Connection, Transaction);
                }

                responseHeader.IsDeleted = true;
                responseHeader.Save(Connection, Transaction);
            }

            //set status to revoked
            var cancellingParameter = new P_L5PR_RPCC_1436();
            var cancellings = new List<P_L5PR_RPCC_1436a>();
            cancellings.Add(new P_L5PR_RPCC_1436a() { HeaderID = Parameter.RequestHeaderID });
            cancellingParameter.Cancellings = cancellings.ToArray();
            var cancelledResponses = cls_RequestProposal_CustomerCancel.Invoke(Connection, Transaction, cancellingParameter, securityTicket).Result;
            
            var creationParameter = new P_L5PR_CCRR_1327();

            var positions = new List<P_L5PR_CCRR_1327a>();
            var tempRequest = new P_L5PR_CCRR_1327a();
            tempRequest.RequestHeaderID = Parameter.RequestHeaderID;
            tempRequest.RegisterdParticipantID = Parameter.RegisterdParticipantID;
            tempRequest.ValidThrough = Parameter.ValidThrough;

            var creations = new List<P_L5PR_CCRR_1327aa>();

            foreach (var position in Parameter.RequestPositions.ToList())
            {                
                var tempCreation = new P_L5PR_CCRR_1327aa();
                tempCreation.ProductID = position.ProductID;
                tempCreation.Quantity = position.Quantity;
                tempCreation.RequestPositionID = position.RequestPositionID;

                creations.Add(tempCreation);
                tempRequest.RequestPositions = creations.ToArray();
            }

            creationParameter.ProposalRequests = new List<P_L5PR_CCRR_1327a>(){tempRequest}.ToArray();
            var newCreatedResponses = cls_Create_CustomerRequestResponse.Invoke(Connection, Transaction, creationParameter, securityTicket).Result;

            returnValue.Result = newCreatedResponses;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5PR_UCRR_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5PR_UCRR_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_UCRR_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_UCRR_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Update_CustomerRequestResponse",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PR_UCRR_1631 for attribute P_L5PR_UCRR_1631
		[DataContract]
		public class P_L5PR_UCRR_1631 
		{
			[DataMember]
			public P_L5PR_UCRR_1631a[] RequestPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RequestHeaderID { get; set; } 
			[DataMember]
			public DateTime ValidThrough { get; set; } 
			[DataMember]
			public Guid RegisterdParticipantID { get; set; } 

		}
		#endregion
		#region SClass P_L5PR_UCRR_1631a for attribute RequestPositions
		[DataContract]
		public class P_L5PR_UCRR_1631a 
		{
			//Standard type parameters
			[DataMember]
			public Guid RequestPositionID { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Update_CustomerRequestResponse(,P_L5PR_UCRR_1631 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Update_CustomerRequestResponse.Invoke(connectionString,P_L5PR_UCRR_1631 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Proposals.Complex.Manipulation.P_L5PR_UCRR_1631();
parameter.RequestPositions = ...;

parameter.RequestHeaderID = ...;
parameter.ValidThrough = ...;
parameter.RegisterdParticipantID = ...;

*/
