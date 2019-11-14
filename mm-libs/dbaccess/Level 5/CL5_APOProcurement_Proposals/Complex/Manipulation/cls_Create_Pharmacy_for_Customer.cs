/* 
 * Generated on 8/20/2014 2:37:39 PM
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

namespace CL5_APOProcurement_Proposals.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Pharmacy_for_Customer.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Pharmacy_for_Customer
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_CFfC_1332 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_CFfC_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PR_CFfC_1332();
            returnValue.Result = new L5PR_CFfC_1332();			

            var tenantQuery = new ORM_CMN_Tenant.Query()
            {
                TenantITL = Parameter.Pharmacy_TenantITL,
                Tenant_RefID = securityTicket.TenantID
            };

            var pharmacyTenant = ORM_CMN_Tenant.Query.Search(Connection, Transaction, tenantQuery).SingleOrDefault();

            //Customer doesn't exist
            if (pharmacyTenant == default(ORM_CMN_Tenant))
            {
                pharmacyTenant = new ORM_CMN_Tenant();
                pharmacyTenant.CMN_TenantID = Guid.NewGuid();
                pharmacyTenant.TenantITL = Parameter.Pharmacy_TenantITL;
                pharmacyTenant.Tenant_RefID = securityTicket.TenantID;
                pharmacyTenant.Creation_Timestamp = DateTime.Now;
                pharmacyTenant.Save(Connection, Transaction);
            }

            var bp = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                IsTenant = true,
                IfTenant_Tenant_RefID = pharmacyTenant.CMN_TenantID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (bp == default(ORM_CMN_BPT_BusinessParticipant))
            {
                bp = new ORM_CMN_BPT_BusinessParticipant();
                bp.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                bp.BusinessParticipantITL = "";
                bp.DisplayName = Parameter.Pharmacy_CompanyName;
                bp.IsCompany = true;
                bp.IfCompany_CMN_COM_CompanyInfo_RefID = Guid.NewGuid();
                bp.IsTenant = true;
                bp.IfTenant_Tenant_RefID = pharmacyTenant.CMN_TenantID;
                bp.Tenant_RefID = securityTicket.TenantID;
                bp.Creation_Timestamp = DateTime.Now;
                bp.Save(Connection, Transaction);
            }

            returnValue.Result.Pharmacy_TenantID = pharmacyTenant.CMN_TenantID;
            returnValue.Result.Pharmacy_BusinessParticipantID = bp.CMN_BPT_BusinessParticipantID;           

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PR_CFfC_1332 Invoke(string ConnectionString,P_L5PR_CFfC_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_CFfC_1332 Invoke(DbConnection Connection,P_L5PR_CFfC_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_CFfC_1332 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_CFfC_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_CFfC_1332 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_CFfC_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_CFfC_1332 functionReturn = new FR_L5PR_CFfC_1332();
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

				throw new Exception("Exception occured in method cls_Create_Pharmacy_for_Customer",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_CFfC_1332 : FR_Base
	{
		public L5PR_CFfC_1332 Result	{ get; set; }

		public FR_L5PR_CFfC_1332() : base() {}

		public FR_L5PR_CFfC_1332(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PR_CFfC_1332 for attribute P_L5PR_CFfC_1332
		[DataContract]
		public class P_L5PR_CFfC_1332 
		{
			//Standard type parameters
			[DataMember]
			public String Pharmacy_TenantITL { get; set; } 
			[DataMember]
			public String Pharmacy_CompanyName { get; set; } 

		}
		#endregion
		#region SClass L5PR_CFfC_1332 for attribute L5PR_CFfC_1332
		[DataContract]
		public class L5PR_CFfC_1332 
		{
			//Standard type parameters
			[DataMember]
			public Guid Pharmacy_TenantID { get; set; } 
			[DataMember]
			public Guid Pharmacy_BusinessParticipantID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_CFfC_1332 cls_Create_Pharmacy_for_Customer(,P_L5PR_CFfC_1332 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_CFfC_1332 invocationResult = cls_Create_Pharmacy_for_Customer.Invoke(connectionString,P_L5PR_CFfC_1332 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Proposals.Complex.Manipulation.P_L5PR_CFfC_1332();
parameter.Pharmacy_TenantITL = ...;
parameter.Pharmacy_CompanyName = ...;

*/
