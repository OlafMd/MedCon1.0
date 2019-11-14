/* 
 * Generated on 9/10/2014 11:05:49 AM
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
using CL3_Articles.Atomic.Retrieval;

namespace CL5_APOProcurement_Proposals.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_CustomerRequestResponse.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_CustomerRequestResponse
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_CCRR_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();
			//Put your code here

            List<Guid> createdResponses = new List<Guid>();

            foreach (var request in Parameter.ProposalRequests)
            {
                List<Guid> articlesList = new List<Guid>();
                foreach (var position in request.RequestPositions)
                {
                    articlesList.Add(position.ProductID);
                }

                var articlesParameter = new P_L3AR_GAfAL_0942();
                articlesParameter.ProductID_List = articlesList.ToArray();

                var articles = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, articlesParameter, securityTicket).Result;

                ORM_ORD_CUO_RFP_IssuedProposalResponse_Header responseHeader = new ORM_ORD_CUO_RFP_IssuedProposalResponse_Header();
                responseHeader.ORD_CUO_RFP_IssuedProposalResponse_HeaderID = Guid.NewGuid();

                foreach (var position in request.RequestPositions)
                {
                    ORM_ORD_CUO_RFP_IssuedProposalResponse_Position tempPosition = new ORM_ORD_CUO_RFP_IssuedProposalResponse_Position();                    
                    tempPosition.ORD_CUO_RFP_IssuedProposalResponse_PositionID = Guid.NewGuid();
                    tempPosition.Quantity = position.Quantity;
                    tempPosition.CMN_PRO_Product_RefID = position.ProductID;
                    tempPosition.IssuedProposalResponseHeader_RefID = responseHeader.ORD_CUO_RFP_IssuedProposalResponse_HeaderID;
                    tempPosition.ProposalResponsePositionITPL = tempPosition.ORD_CUO_RFP_IssuedProposalResponse_PositionID.ToString();
                    tempPosition.CreatedFrom_RequestForProposal_Position_RefID = position.RequestPositionID;
                    tempPosition.Tenant_RefID = securityTicket.TenantID;
                    tempPosition.Save(Connection, Transaction);
                }

                responseHeader.ProposalResponseHeaderITPL = responseHeader.ORD_CUO_RFP_IssuedProposalResponse_HeaderID.ToString();
                responseHeader.CreatedFor_RequestForProposal_Header_RefID = request.RequestHeaderID;
                responseHeader.ValidThrough = request.ValidThrough;
                responseHeader.Save(Connection, Transaction);

                createdResponses.Add(responseHeader.ORD_CUO_RFP_IssuedProposalResponse_HeaderID);
            }

            returnValue.Result = createdResponses.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5PR_CCRR_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5PR_CCRR_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_CCRR_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_CCRR_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_CustomerRequestResponse",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PR_CCRR_1327 for attribute P_L5PR_CCRR_1327
		[DataContract]
		public class P_L5PR_CCRR_1327 
		{
			[DataMember]
			public P_L5PR_CCRR_1327a[] ProposalRequests { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5PR_CCRR_1327a for attribute ProposalRequests
		[DataContract]
		public class P_L5PR_CCRR_1327a 
		{
			[DataMember]
			public P_L5PR_CCRR_1327aa[] RequestPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RequestHeaderID { get; set; } 
			[DataMember]
			public DateTime ValidThrough { get; set; } 
			[DataMember]
			public Guid RegisterdParticipantID { get; set; } 

		}
		#endregion
		#region SClass P_L5PR_CCRR_1327aa for attribute RequestPositions
		[DataContract]
		public class P_L5PR_CCRR_1327aa 
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
FR_Guids cls_Create_CustomerRequestResponse(,P_L5PR_CCRR_1327 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Create_CustomerRequestResponse.Invoke(connectionString,P_L5PR_CCRR_1327 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Proposals.Complex.Manipulation.P_L5PR_CCRR_1327();
parameter.ProposalRequests = ...;


*/
