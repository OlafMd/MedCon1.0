/* 
 * Generated on 8/28/2014 4:08:04 PM
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
    /// var result = cls_Create_RequestResponse.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_RequestResponse
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_CRR_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            #region ArticlesAndPrices
           
            var productIDsParam = new List<Guid>();

            foreach (var proposalRequestPosition in Parameter.ProposalRequestPositions)
            {
                productIDsParam.Add(proposalRequestPosition.ProductID);
            }

            var productsParameter = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfAL_0942();
            productsParameter.ProductID_List = productIDsParam.Distinct().ToArray();

            var pricesParam = new CL3_Price.Complex.Retrieval.P_L3PR_GSPfPIL_1645();
            pricesParam.ProductIDList = productIDsParam.Distinct().ToArray();

            var products = new List<CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942>();
            var prices = new List<CL3_Price.Complex.Retrieval.L3PR_GSPfPIL_1645>();

            if (Parameter.ProposalRequestPositions.Length > 0)
            {
                prices = CL3_Price.Complex.Retrieval.cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, pricesParam, securityTicket).Result.ToList();
                products = CL3_Articles.Atomic.Retrieval.cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, productsParameter, securityTicket).Result.ToList();
            }

            #endregion

            var responseHeader = new CL1_ORD_PRC_RFP.ORM_ORD_PRC_RFP_SupplierProposalResponse_Header();
            responseHeader.ORD_PRC_RFP_SupplierProposalResponse_HeaderID = Guid.NewGuid();
            responseHeader.ProposalResponseHeaderITPL = Parameter.ProposalResponseHeaderITPL;
            responseHeader.OfferReceivedFrom_RegisteredBusinessParticipant_RefID = Parameter.OfferReceivedFrom_RegisteredBusinessParticipant_RefID;
            responseHeader.CreatedFor_RequestForProposal_Header_RefID = Parameter.CreatedFor_RequestForProposal_Header_RefID;
            responseHeader.ValidThrough = Parameter.ValidThrough;
            responseHeader.Tenant_RefID = securityTicket.TenantID;

            responseHeader.Save(Connection, Transaction);           

            foreach (var param in Parameter.ProposalRequestPositions)
            {
                #region RegisteredBusinessParticipantHistoryUpdate

                var potentialSupplier = new CL1_ORD_PRC_RFP.ORM_ORD_PRC_RFP_PotentialSupplier();

                var supplierForHistoryQuery = ORM_ORD_PRC_RFP_PotentialSupplier.Query.Search(Connection, Transaction,
                    new ORM_ORD_PRC_RFP_PotentialSupplier.Query
                    {
                        RequestForProposal_Header_RefID = Parameter.CreatedFor_RequestForProposal_Header_RefID,
                        Tenant_RefID = securityTicket.TenantID
                    }
                    ).First();

                //accepted request history
                var history = new CL1_ORD_PRC_RFP.ORM_ORD_PRC_RFP_PotentialSupplier_History();
                history.ORD_PRC_RFP_PotentialSupplier_HistoryID = Guid.NewGuid();
                history.ORD_PRC_RFP_PotentialSupplier_RefID = supplierForHistoryQuery.ORD_PRC_RFP_PotentialSupplierID;
                history.IsEvent_ProposalResponse_Accepted = true;
                history.Tenant_RefID = securityTicket.TenantID;
                history.Save(Connection, Transaction);

                #endregion

                var responsePosition = new CL1_ORD_PRC_RFP.ORM_ORD_PRC_RFP_SupplierProposalResponse_Position();

                var productPrice = prices.Single(pr => pr.ProductID == param.ProductID).SalesPrice;
                var productTax = Convert.ToDecimal(products.Single(pr => pr.CMN_PRO_ProductID == param.ProductID).Taxes[0].TaxRate);

                responsePosition.ORD_PRC_RFP_SupplierProposalResponse_PositionID = Guid.NewGuid();
                responsePosition.PricePerUnit_WithoutTax = productPrice;
                responsePosition.PricePerUnit_IncludingTax = DLUtils_Common.Calculations.MoneyUtils.CalculateGrossPriceForTaxInPercent(productPrice, productTax);
                responsePosition.SupplierProposalResponseHeader_RefID = responseHeader.ORD_PRC_RFP_SupplierProposalResponse_HeaderID;
                responsePosition.ProposalResponsePositionITPL = responsePosition.ORD_PRC_RFP_SupplierProposalResponse_PositionID.ToString();
                responsePosition.Quantity = param.Quantity;
                responsePosition.TotalPrice_IncludingTax = responseHeader.TotalPrice_IncludingTax;
                responsePosition.TotalPrice_WithoutTax = responseHeader.TotalPrice_WithoutTax;
                responsePosition.CreatedFrom_RequestForProposal_Position_RefID = param.Created_From_RequestForProposal_Position_RefID;
                responsePosition.Tenant_RefID = securityTicket.TenantID;
                responsePosition.CMN_PRO_Product_RefID = param.ProductID;
                responsePosition.Save(Connection, Transaction);                
            }


            returnValue.Result = responseHeader.ORD_PRC_RFP_SupplierProposalResponse_HeaderID;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PR_CRR_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PR_CRR_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_CRR_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_CRR_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_RequestResponse",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PR_CRR_1429 for attribute P_L5PR_CRR_1429
		[DataContract]
		public class P_L5PR_CRR_1429 
		{
			[DataMember]
			public P_L5PR_CRR_1429a[] ProposalRequestPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public String ProposalResponseHeaderITPL { get; set; } 
			[DataMember]
			public Guid CreatedFor_RequestForProposal_Header_RefID { get; set; } 
			[DataMember]
			public Guid OfferReceivedFrom_RegisteredBusinessParticipant_RefID { get; set; } 
			[DataMember]
			public DateTime ValidThrough { get; set; } 

		}
		#endregion
		#region SClass P_L5PR_CRR_1429a for attribute ProposalRequestPositions
		[DataContract]
		public class P_L5PR_CRR_1429a 
		{
			//Standard type parameters
			[DataMember]
			public String ProposalResponsePositionITPL { get; set; } 
			[DataMember]
			public Guid Created_From_RequestForProposal_Position_RefID { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public bool IsReplacementProduct { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_RequestResponse(,P_L5PR_CRR_1429 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_RequestResponse.Invoke(connectionString,P_L5PR_CRR_1429 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Proposals.Complex.Manipulation.P_L5PR_CRR_1429();
parameter.ProposalRequestPositions = ...;

parameter.ProposalResponseHeaderITPL = ...;
parameter.CreatedFor_RequestForProposal_Header_RefID = ...;
parameter.OfferReceivedFrom_RegisteredBusinessParticipant_RefID = ...;
parameter.ValidThrough = ...;

*/
