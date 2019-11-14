/* 
 * Generated on 28.02.2014 14:27:07
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
using CL1_CMN;
using CL1_CMN_BPT;
using CL1_CMN_TRL;

namespace CL2_TrustRelation.Complex.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_CreateTrustrelation.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_CreateTrustrelation
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2TR_CTR_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();


            ORM_CMN_Tenant guestTenant = ORM_CMN_Tenant.Query.Search(Connection, Transaction, new ORM_CMN_Tenant.Query()
            {
                IsDeleted = false,
                TenantITL = Parameter.GuestTenantID.ToString(),
                Tenant_RefID = Parameter.TenantID
            }).Single();

            ORM_CMN_BPT_BusinessParticipant bp = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                IsTenant = true,
                IsDeleted = false,
                IfTenant_Tenant_RefID = guestTenant.CMN_TenantID,
                Tenant_RefID = Parameter.TenantID
            }).Single();

            ORM_CMN_TRL_TrustRelationRequest request = ORM_CMN_TRL_TrustRelationRequest.Query.Search(Connection, Transaction, new ORM_CMN_TRL_TrustRelationRequest.Query()
            {
                IsDeleted = false,
                Tenant_RefID = Parameter.TenantID,
                TrustRelationRequestITL = Parameter.TrustRelationRequestITL,
                Requesting_BusinessParticipant_RefID = bp.CMN_BPT_BusinessParticipantID
            }).FirstOrDefault();
            if (request == null)
            {
                if (Parameter.IsInvalidation)
                    throw new Exception("Trustreslation request doesnt exists!");
                request = new ORM_CMN_TRL_TrustRelationRequest()
                {
                    CMN_TRL_TrustRelationRequestID = Guid.NewGuid(),
                    Tenant_RefID = Parameter.TenantID,
                    TrustRelationRequestITL = Parameter.TrustRelationRequestITL,
                    Requesting_BusinessParticipant_RefID = bp.CMN_BPT_BusinessParticipantID,
                    IsApproved = true
                };
            }
            request.Title = Parameter.Title;
            request.Comment = Parameter.Comment;
            request.Save(Connection, Transaction);

            ORM_CMN_TRL_TrustRelation_Type type = ORM_CMN_TRL_TrustRelation_Type.Query.Search(Connection, Transaction, new ORM_CMN_TRL_TrustRelation_Type.Query()
            {
                IsDeleted = false,
                Tenant_RefID = Parameter.TenantID,
                TrustRelationTypeITL = Parameter.TrustRelationTypeITL
            }).FirstOrDefault();
            if (type == null)
            {
                type = new ORM_CMN_TRL_TrustRelation_Type();
                type.CMN_TRL_TrustRelation_TypeID = Guid.NewGuid();
                type.Tenant_RefID = Parameter.TenantID;
                type.TrustRelationTypeITL = Parameter.TrustRelationTypeITL;
                type.Save(Connection, Transaction);
            }

            var activeTR = ORM_CMN_TRL_TrustRelation.Query.Search(Connection, Transaction, new ORM_CMN_TRL_TrustRelation.Query()
            {
                IsDeleted = false,
                Tenant_RefID = Parameter.TenantID,
                CMN_TRL_TrustRelation_Type_RefID = type.CMN_TRL_TrustRelation_TypeID,
                IsPaused = false,
                IsValid = true
            }).FirstOrDefault();

            ORM_CMN_TRL_TrustRelation tr = ORM_CMN_TRL_TrustRelation.Query.Search(Connection, Transaction, new ORM_CMN_TRL_TrustRelation.Query()
            {
                IsDeleted = false,
                Tenant_RefID = Parameter.TenantID,
                CMN_TRL_TrustRelation_Type_RefID = type.CMN_TRL_TrustRelation_TypeID,
                CreatedFrom_TrustRelationRequest_RefID = request.CMN_TRL_TrustRelationRequestID,
            }).FirstOrDefault();
            if (tr == null)
            {
                if (Parameter.IsInvalidation)
                    throw new Exception("Trustreslation request doesnt exists!");
                tr = new ORM_CMN_TRL_TrustRelation()
                {
                    CMN_TRL_TrustRelationID = Guid.NewGuid(),
                    Tenant_RefID = Parameter.TenantID,
                    CMN_BPT_BusinessParticpant_RefID = bp.CMN_BPT_BusinessParticipantID,
                    CMN_TRL_TrustRelation_Type_RefID = type.CMN_TRL_TrustRelation_TypeID,
                    CreatedFrom_TrustRelationRequest_RefID = request.CMN_TRL_TrustRelationRequestID,
                    IsValid = true
                };

                ORM_CMN_TRL_TrustRelation_History history = new ORM_CMN_TRL_TrustRelation_History()
                {
                    CMN_TRL_TrustRelation_HistoryID = Guid.NewGuid(),
                    Tenant_RefID = Parameter.TenantID,
                    TrustRelation_RefID = tr.CMN_TRL_TrustRelationID,
                };
                history.Save(Connection, Transaction);
                tr.Save(Connection, Transaction);
            }
            else
            {
                if (Parameter.IsInvalidation)
                {
                    tr.IsValid = false;
                    tr.Save(Connection, Transaction);

                    ORM_CMN_TRL_TrustRelation_History history = new ORM_CMN_TRL_TrustRelation_History()
                    {
                        CMN_TRL_TrustRelation_HistoryID = Guid.NewGuid(),
                        Tenant_RefID = Parameter.TenantID,
                        TrustRelation_RefID = tr.CMN_TRL_TrustRelationID,
                        StatusType = 2
                    };
                    history.Save(Connection, Transaction);
                }
                return returnValue;
            }

            if(activeTR != null && tr.CMN_TRL_TrustRelationID != activeTR.CMN_TRL_TrustRelationID) // invalidatin old active tr
            {
                activeTR.IsValid = false;
                activeTR.Save(Connection, Transaction);

                ORM_CMN_TRL_TrustRelation_History history = new ORM_CMN_TRL_TrustRelation_History()
                {
                    CMN_TRL_TrustRelation_HistoryID = Guid.NewGuid(),
                    Tenant_RefID = Parameter.TenantID,
                    TrustRelation_RefID = activeTR.CMN_TRL_TrustRelationID,
                    StatusType = 2
                };
                history.Save(Connection, Transaction);
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2TR_CTR_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2TR_CTR_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2TR_CTR_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2TR_CTR_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_CreateTrustrelation",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2TR_CTR_1405 for attribute P_L2TR_CTR_1405
		[DataContract]
		public class P_L2TR_CTR_1405 
		{
			//Standard type parameters
			[DataMember]
			public Guid TenantID { get; set; } 
			[DataMember]
			public Guid GuestTenantID { get; set; } 
			[DataMember]
			public string Title { get; set; } 
			[DataMember]
			public string Comment { get; set; } 
			[DataMember]
			public bool IsInvalidation { get; set; } 
			[DataMember]
			public string TrustRelationRequestITL { get; set; } 
			[DataMember]
			public string TrustRelationTypeITL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_CreateTrustrelation(,P_L2TR_CTR_1405 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_CreateTrustrelation.Invoke(connectionString,P_L2TR_CTR_1405 Parameter,securityTicket);
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
var parameter = new CL2_TrustRelation.Complex.Manipulation.P_L2TR_CTR_1405();
parameter.TenantID = ...;
parameter.GuestTenantID = ...;
parameter.Title = ...;
parameter.Comment = ...;
parameter.IsInvalidation = ...;
parameter.TrustRelationRequestITL = ...;
parameter.TrustRelationTypeITL = ...;

*/
