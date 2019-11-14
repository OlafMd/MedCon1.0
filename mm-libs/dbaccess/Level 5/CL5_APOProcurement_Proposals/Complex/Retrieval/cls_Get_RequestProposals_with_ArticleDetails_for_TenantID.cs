/* 
 * Generated on 6/26/2014 11:53:17 AM
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
using CL5_APOProcurement_Proposals.Atomic.Retrieval;
using CL3_Articles.Atomic.Retrieval;

namespace CL5_APOProcurement_Proposals.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RequestProposals_with_ArticleDetails_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RequestProposals_with_ArticleDetails_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GRPwADfTID_1145 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PR_GRPwADfTID_1145();
			//Put your code here

            var proposalsParameter = new P_L5PR_GRPfTID_1136();
            proposalsParameter.IsEvent_ProposalRequest_Sent = true;

            var proposals = cls_Get_RequestProposals_for_TenantID.Invoke(Connection, Transaction, proposalsParameter, securityTicket).Result.ToList();

            List<Guid> articlesList = new List<Guid>();
            foreach (var proposal in proposals)
            {
                articlesList.Add(proposal.CMN_PRO_Product_RefID);
            }

            var articlesParameter = new P_L3AR_GAfAL_0942();
            articlesParameter.ProductID_List = articlesList.ToArray();

            var articles = new List<L3AR_GAfAL_0942>();

            if (articlesList.Count > 0)
            {
                articles = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, articlesParameter, securityTicket).Result.ToList();
            }

            List<L5PR_GRPwADfTID_1145a> proposalsWithDetails = new List<L5PR_GRPwADfTID_1145a>();

            foreach (var proposal in proposals)
            {
                L5PR_GRPwADfTID_1145a tempProposalWithDetails = new L5PR_GRPwADfTID_1145a();
                tempProposalWithDetails.Proposal = proposal;
                tempProposalWithDetails.Article = articles.Where(ar => ar.CMN_PRO_ProductID == proposal.CMN_PRO_Product_RefID).Single();
                proposalsWithDetails.Add(tempProposalWithDetails);
            }

            returnValue.Result = new L5PR_GRPwADfTID_1145();
            returnValue.Result.ProposalsWithArticleDetails = proposalsWithDetails.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PR_GRPwADfTID_1145 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GRPwADfTID_1145 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GRPwADfTID_1145 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GRPwADfTID_1145 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GRPwADfTID_1145 functionReturn = new FR_L5PR_GRPwADfTID_1145();
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

				throw new Exception("Exception occured in method cls_Get_RequestProposals_with_ArticleDetails_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GRPwADfTID_1145 : FR_Base
	{
		public L5PR_GRPwADfTID_1145 Result	{ get; set; }

		public FR_L5PR_GRPwADfTID_1145() : base() {}

		public FR_L5PR_GRPwADfTID_1145(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5PR_GRPwADfTID_1145 for attribute L5PR_GRPwADfTID_1145
		[DataContract]
		public class L5PR_GRPwADfTID_1145 
		{
			[DataMember]
			public L5PR_GRPwADfTID_1145a[] ProposalsWithArticleDetails { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5PR_GRPwADfTID_1145a for attribute ProposalsWithArticleDetails
		[DataContract]
		public class L5PR_GRPwADfTID_1145a 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL5_APOProcurement_Proposals.Atomic.Retrieval.L5PR_GRPfTID_1136 Proposal { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GRPwADfTID_1145 cls_Get_RequestProposals_with_ArticleDetails_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GRPwADfTID_1145 invocationResult = cls_Get_RequestProposals_with_ArticleDetails_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

