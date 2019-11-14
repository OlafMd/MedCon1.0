/* 
 * Generated on 9/18/2014 1:28:15 PM
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
    /// var result = cls_Update_RequestResponse.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Update_RequestResponse
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_URR_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();
			//Put your code here

            #region DeletePreviousResponseAndPositions

            var supplierProposalResponseHeader = new ORM_ORD_PRC_RFP_SupplierProposalResponse_Header();
            supplierProposalResponseHeader.Load(Connection, Transaction, Guid.Parse(Parameter.RequestResponseITPL));

            var responseProposalPositions = ORM_ORD_PRC_RFP_SupplierProposalResponse_Position.Query.Search(Connection, Transaction,
                new ORM_ORD_PRC_RFP_SupplierProposalResponse_Position.Query()
                {
                    SupplierProposalResponseHeader_RefID = supplierProposalResponseHeader.ORD_PRC_RFP_SupplierProposalResponse_HeaderID,
                    Tenant_RefID = securityTicket.TenantID
                }
                );

            foreach (var responseProposalPosition in responseProposalPositions)
            {
                responseProposalPosition.Save(Connection, Transaction);
            }
            supplierProposalResponseHeader.Save(Connection, Transaction);

            #endregion

            //TO DO - CHECK IF HISTORY NEED TO BE UPDATED FOR INITIAL REQUEST PROPOSAL
            //ORM_ORD_PRC_RFP_RequestForProposal_Header requestHeader = new ORM_ORD_PRC_RFP_RequestForProposal_Header();
            //requestHeader.Load(Connection, Transaction, Guid.Parse(Parameter.RequestForProposalITPL));            

            var responseCreationParameter = new P_L5PR_CRR_1429();
            responseCreationParameter.CreatedFor_RequestForProposal_Header_RefID = Guid.Parse(Parameter.RequestForProposalITPL);
            responseCreationParameter.ProposalResponseHeaderITPL = Parameter.RequestResponseITPL;
            responseCreationParameter.OfferReceivedFrom_RegisteredBusinessParticipant_RefID = Guid.NewGuid(); //TO DO - registered business participant
            responseCreationParameter.ValidThrough = DateTime.Now; //TO DO - check what ValidThrough time should be

            List<P_L5PR_CRR_1429a> creationResponsePositions = new List<P_L5PR_CRR_1429a>();

            foreach (var position in Parameter.RequestResponsePositions.ToList())
            {
                P_L5PR_CRR_1429a tempResponsePosition = new P_L5PR_CRR_1429a();
                tempResponsePosition.Quantity = position.Quantity;
                tempResponsePosition.ProposalResponsePositionITPL = position.RequestResponsePositionITPL;
                tempResponsePosition.ProductID = Guid.NewGuid(); //TO DO - find ProductID using ProductITL
                tempResponsePosition.IsReplacementProduct = position.IsReplacementProduct;
                tempResponsePosition.Created_From_RequestForProposal_Position_RefID = Guid.Parse(Parameter.RequestForProposalITPL);

                creationResponsePositions.Add(tempResponsePosition);
            }

            responseCreationParameter.ProposalRequestPositions = creationResponsePositions.ToArray();

            var savedResponseHeader = cls_Create_RequestResponse.Invoke(Connection, Transaction, responseCreationParameter, securityTicket).Result;

            returnValue.Result = new Guid[] { savedResponseHeader };

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5PR_URR_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5PR_URR_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_URR_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_URR_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Update_RequestResponse",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PR_URR_1402 for attribute P_L5PR_URR_1402
		[DataContract]
		public class P_L5PR_URR_1402 
		{
			[DataMember]
			public P_L5PR_URR_1402a[] RequestResponsePositions { get; set; }

			//Standard type parameters
			[DataMember]
			public string RequestForProposalITPL { get; set; } 
			[DataMember]
			public string RequestResponseITPL { get; set; } 

		}
		#endregion
		#region SClass P_L5PR_URR_1402a for attribute RequestResponsePositions
		[DataContract]
		public class P_L5PR_URR_1402a 
		{
			//Standard type parameters
			[DataMember]
			public string RequestResponsePositionITPL { get; set; } 
			[DataMember]
			public string ProductITL { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public decimal PricePerItemWithoutTax { get; set; } 
			[DataMember]
			public DateTime ResponseValidUntil { get; set; } 
			[DataMember]
			public bool IsReplacementProduct { get; set; } 
			[DataMember]
			public string Comment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Update_RequestResponse(,P_L5PR_URR_1402 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Update_RequestResponse.Invoke(connectionString,P_L5PR_URR_1402 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Proposals.Complex.Manipulation.P_L5PR_URR_1402();
parameter.RequestResponsePositions = ...;

parameter.RequestForProposalITPL = ...;
parameter.RequestResponseITPL = ...;

*/
