/* 
 * Generated on 05.02.2015 16:35:42
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
using CL1_HEC_CMT;
using CL1_APP;
using CL2_Language.Atomic.Retrieval;
using CL2_HECCommunityRole.DomainManagement;
using DLCore_DBCommons.Utils;

namespace CL5_MPC_TenantInitialization.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_TenantInitialization.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_TenantInitialization
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5TI_TI_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Bool();

            var init = ORM_APP_Initialization.Query.Search(Connection, Transaction, new ORM_APP_Initialization.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Application_RefID = Parameter.AppID
            }).SingleOrDefault();

            if (init == null)
            {
                init = new ORM_APP_Initialization()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    Application_RefID = Parameter.AppID,
                    APP_InitializationID = Guid.NewGuid(),
                    Initialization_StartedAtDate = DateTime.Now,
                    Version = "1.0"
                };
            }

            var DBLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result;


            var communitiy = new ORM_HEC_CMT_Community()
            {
                HEC_CMT_CommunityID = Guid.NewGuid(),
                Tenant_RefID = securityTicket.TenantID,
                IsCommunityOperatedByThisTenant = true,
                CommunityServicesBaseURL = string.Empty,
                HealthcareCommunityITL = Guid.NewGuid().ToString()
            };
            communitiy.Save(Connection, Transaction);

            var tenantMembershipType = new ORM_HEC_CMT_Community_OfferedMembershipType()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsAvailableFor_Tenants = true,
                HEC_CMT_Community_OfferedMembershipTypeID = Guid.NewGuid(),
                HealthcareCommunityOfferedMembershipTypesITL = Guid.NewGuid().ToString(),
                OfferedMembershipType_DisplayName = "Tenant Membership Type",
                Community_RefID = communitiy.HEC_CMT_CommunityID
            };
            tenantMembershipType.Save(Connection, Transaction);

            var personMembershipType = new ORM_HEC_CMT_Community_OfferedMembershipType()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsAvailableFor_Doctors = true,
                HEC_CMT_Community_OfferedMembershipTypeID = Guid.NewGuid(),
                HealthcareCommunityOfferedMembershipTypesITL = Guid.NewGuid().ToString(),
                OfferedMembershipType_DisplayName = "Person Membership Type",
                Community_RefID = communitiy.HEC_CMT_CommunityID
            };
            personMembershipType.Save(Connection, Transaction);

            var communityRoles = Enum.GetValues(typeof(ECommunityRole));
            foreach (ECommunityRole role in communityRoles)
            {
                DMCommunityRoles.Get_CommunityRole_for_GlobalPropertyMatchingID(Connection, Transaction, EnumUtils.GetEnumDescription(role), communitiy.HEC_CMT_CommunityID, securityTicket);
            }

            init.Initialiaztion_CompletedAtDate = DateTime.Now;
            init.IsInitializationComplete = true;
            init.Save(Connection, Transaction);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5TI_TI_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5TI_TI_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TI_TI_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TI_TI_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_TenantInitialization",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5TI_TI_1134 for attribute P_L5TI_TI_1134
		[DataContract]
		public class P_L5TI_TI_1134 
		{
			//Standard type parameters
			[DataMember]
			public Guid AppID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_TenantInitialization(,P_L5TI_TI_1134 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_TenantInitialization.Invoke(connectionString,P_L5TI_TI_1134 Parameter,securityTicket);
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
var parameter = new CL5_MPC_TenantInitialization.Atomic.Manipulation.P_L5TI_TI_1134();
parameter.AppID = ...;

*/
