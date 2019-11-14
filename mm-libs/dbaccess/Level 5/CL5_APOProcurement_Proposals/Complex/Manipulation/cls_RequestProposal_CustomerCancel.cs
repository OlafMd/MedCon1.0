/* 
 * Generated on 9/2/2014 3:21:22 PM
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
    /// var result = cls_RequestProposal_CustomerCancel.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_RequestProposal_CustomerCancel
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_RPCC_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();
			//Put your code here

            var cancelledHeaders = new List<Guid>();

            foreach (var cancelling in Parameter.Cancellings.ToList())
            {
                var history = new ORM_ORD_CUO_RFP_RequestForProposal_History();

                history.ORD_CUO_RFP_RequestForProposal_HistoryID = Guid.NewGuid();
                history.RequestForProposal_Header_RefID = cancelling.HeaderID;
                history.Comment = cancelling.Comment;
                history.IsEvent_ByCustomer_ProposalRequest_Revoked = true;
                history.Tenant_RefID = securityTicket.TenantID;

                cancelledHeaders.Add(cancelling.HeaderID);
            }

            returnValue.Result = cancelledHeaders.ToArray();
            
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5PR_RPCC_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5PR_RPCC_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_RPCC_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_RPCC_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_RequestProposal_CustomerCancel",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PR_RPCC_1436 for attribute P_L5PR_RPCC_1436
		[DataContract]
		public class P_L5PR_RPCC_1436 
		{
			[DataMember]
			public P_L5PR_RPCC_1436a[] Cancellings { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5PR_RPCC_1436a for attribute Cancellings
		[DataContract]
		public class P_L5PR_RPCC_1436a 
		{
			//Standard type parameters
			[DataMember]
			public Guid HeaderID { get; set; } 
			[DataMember]
			public string Comment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_RequestProposal_CustomerCancel(,P_L5PR_RPCC_1436 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_RequestProposal_CustomerCancel.Invoke(connectionString,P_L5PR_RPCC_1436 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Proposals.Complex.Manipulation.P_L5PR_RPCC_1436();
parameter.Cancellings = ...;


*/
