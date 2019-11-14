/* 
 * Generated on 7/3/2014 4:49:35 PM
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

namespace CL5_APOProcurement_Proposals.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_RequestProposal.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_RequestProposal
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_CRP_1104 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            
            //Put your code here           

            var requestProposalHeader = new CL1_ORD_PRC_RFP.ORM_ORD_PRC_RFP_RequestForProposal_Header();

            List<Tuple<Guid, double, DateTime>> saveParams = new List<Tuple<Guid, double, DateTime>>();
            for (int i = 0; i < Parameter.ProductIDs.Length; i++)
            {
                Tuple<Guid, double, DateTime> tempParam =
                    new Tuple<Guid, double, DateTime>(Parameter.ProductIDs[i], Parameter.Quantities[i], Parameter.DeliveryScheduleToDates[i]);
                saveParams.Add(tempParam);
            }

            #region Usefull commented

            //var productIDsList = Parameter.ProductIDs.ToList();
            //var positionsList = Parameter.ProposalPositionsIDs.ToList();

            //if (Parameter.ORD_PRC_RFO_RequestForProposal_HeaderID != Guid.Empty)
            //{
            //    requestProposalHeader.Load(Connection, Transaction, Parameter.ORD_PRC_RFO_RequestForProposal_HeaderID);               
            //}
            //else
            //{
            //    requestProposalHeader.ORD_PRC_RFO_RequestForProposal_HeaderID = Guid.NewGuid();

            //    var incrNumberParam = new CL2_NumberRange.Complex.Retrieval.P_L2NR_GaIINfUA_1454()
            //    {
            //        GlobalStaticMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.ENumberRangeUsageAreaType.RequestProposalNumber)
            //    };

            //    var requestProposalNumber = CL2_NumberRange.Complex.Retrieval.
            //        cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;
            //    requestProposalHeader.RequestForProposal_Number = requestProposalNumber;
            //    requestProposalHeader.Tenant_RefID = securityTicket.TenantID;                
            //}

            #endregion

            #region BusinessParticipantsForTenant(temporary)

            List<Guid> participantIDs = new List<Guid>();
            participantIDs.Add(new Guid("05AA8199-18D9-4DEC-95D1-5266EB64F14D"));
            participantIDs.Add(new Guid("3AEF102F-006D-4B48-BA98-5AAE1E4330ED"));
            //var accountsQuery = new CL1_USR.ORM_USR_Account.Query();
            //accountsQuery.Tenant_RefID = securityTicket.TenantID;
            //accountsQuery.IsDeleted = false;
            //var foundAccounts = CL1_USR.ORM_USR_Account.Query.Search(Connection, Transaction, accountsQuery).ToList();           
            //foreach (var account in foundAccounts)
            //{
            //    if (account.USR_AccountID != securityTicket.AccountID)
            //    {
            //        participantIDs.Add(account.BusinessParticipant_RefID);
            //    }
            //}        

            #endregion

            var returnedGuids = new List<Guid>();

            foreach (var saveParam in saveParams)
            {
                var requestProposalPosition = new CL1_ORD_PRC_RFP.ORM_ORD_PRC_RFP_RequestForProposal_Position();
             
                #region CreateHeaderAndPosition

                requestProposalHeader.ORD_PRC_RFO_RequestForProposal_HeaderID = Guid.NewGuid();

                var incrNumberParam = new CL2_NumberRange.Complex.Retrieval.P_L2NR_GaIINfUA_1454()
                {
                    GlobalStaticMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.ENumberRangeUsageAreaType.PRCRequestProposalNumber)
                };
                
                var requestProposalNumber = CL2_NumberRange.Complex.Retrieval.
                    cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

                requestProposalHeader.RequestForProposal_Number = requestProposalNumber;
                requestProposalHeader.Tenant_RefID = securityTicket.TenantID;
                requestProposalHeader.RequestForProposalHeaderITPL = requestProposalHeader.ORD_PRC_RFO_RequestForProposal_HeaderID.ToString();

                returnedGuids.Add(requestProposalHeader.ORD_PRC_RFO_RequestForProposal_HeaderID);

                requestProposalPosition.ORD_PRC_RFP_RequestForProposal_PositionID = Guid.NewGuid();
                requestProposalPosition.RequestForProposalPositionITPL = requestProposalPosition.ORD_PRC_RFP_RequestForProposal_PositionID.ToString();
                requestProposalPosition.RequestForProposal_Header_RefID = requestProposalHeader.ORD_PRC_RFO_RequestForProposal_HeaderID;
                requestProposalPosition.Tenant_RefID = securityTicket.TenantID;
                requestProposalPosition.CMN_PRO_Product_RefID = saveParam.Item1;

                #region CommentedPossiblyUseful

                //if (saveParam.Item1 != Guid.Empty)
                //{
                //    #region LoadHeaderAndPosition

                //    requestProposalHeader.Load(Connection, Transaction, Parameter.ORD_PRC_RFO_RequestForProposal_HeaderID);  
                //    requestProposalPosition.Load(Connection, Transaction, saveParam.Item1);

                //    #endregion
                //}
                //else
                //{

                //CL1_USR.ORM_USR_Account currentAccount = new CL1_USR.ORM_USR_Account();
                //currentAccount.Load(Connection, Transaction, securityTicket.AccountID);                    

                //var registeredBusinessParticipant = new CL1_ORD_PRC_RFP.ORM_ORD_PRC_RFP_RegisteredBusinessParticipant();
                //registeredBusinessParticipant.ORD_PRC_RFP_RegisteredBusinessParticipantID = Guid.NewGuid();
                //registeredBusinessParticipant.RequestForProposal_Header_RefID = requestProposalHeader.ORD_PRC_RFO_RequestForProposal_HeaderID;
                //registeredBusinessParticipant.CMN_BPT_BusinessParticipant_RefID = currentAccount.BusinessParticipant_RefID;
                //registeredBusinessParticipant.Tenant_RefID = securityTicket.TenantID;

                #endregion

                foreach (var id in participantIDs)
                {
                    //Creation of registered business participant
                    CL1_ORD_PRC_RFP.ORM_ORD_PRC_RFP_PotentialSupplier potentialSupplier = new CL1_ORD_PRC_RFP.ORM_ORD_PRC_RFP_PotentialSupplier();
                    potentialSupplier.CMN_BPT_BusinessParticipant_RefID = id;
                    potentialSupplier.ORD_PRC_RFP_PotentialSupplierID = Guid.NewGuid();
                    potentialSupplier.RequestForProposal_Header_RefID = requestProposalHeader.ORD_PRC_RFO_RequestForProposal_HeaderID;
                    potentialSupplier.Tenant_RefID = securityTicket.TenantID;
                    potentialSupplier.Save(Connection, Transaction);

                    CL1_ORD_PRC_RFP.ORM_ORD_PRC_RFP_PotentialSupplier_History history = new CL1_ORD_PRC_RFP.ORM_ORD_PRC_RFP_PotentialSupplier_History();
                    history.ORD_PRC_RFP_PotentialSupplier_HistoryID = Guid.NewGuid();
                    history.IsEvent_ProposalRequest_Sent = true;
                    history.ORD_PRC_RFP_PotentialSupplier_RefID = potentialSupplier.ORD_PRC_RFP_PotentialSupplierID;
                    history.Tenant_RefID = securityTicket.TenantID;
                    history.Save(Connection, Transaction);
                }

                requestProposalPosition.Quantity = (saveParam.Item2 == 0.0) ? 1 : saveParam.Item2;
                requestProposalPosition.DeliveryUntillDate = (saveParam.Item3 == DateTime.MinValue) ? DateTime.Now : saveParam.Item3;
                
                requestProposalHeader.Save(Connection, Transaction);
                requestProposalPosition.Save(Connection, Transaction);
                #endregion                
            }

            var returnValue = new FR_Guids();
            returnValue.Result = returnedGuids.ToArray();
            
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5PR_CRP_1104 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5PR_CRP_1104 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_CRP_1104 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_CRP_1104 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_RequestProposal",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PR_CRP_1104 for attribute P_L5PR_CRP_1104
		[DataContract]
		public class P_L5PR_CRP_1104 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProductIDs { get; set; } 
			[DataMember]
			public double[] Quantities { get; set; } 
			[DataMember]
			public DateTime[] DeliveryScheduleToDates { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Create_RequestProposal(,P_L5PR_CRP_1104 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Create_RequestProposal.Invoke(connectionString,P_L5PR_CRP_1104 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Proposals.Complex.Manipulation.P_L5PR_CRP_1104();
parameter.ProductIDs = ...;
parameter.Quantities = ...;
parameter.DeliveryScheduleToDates = ...;

*/
