/* 
 * Generated on 11/13/2014 5:45:02 PM
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
using CL1_CMN_COM;
using CL1_CMN;
using CL1_CMN_BPT;

namespace CL3_Tenant.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Tenant_Initial_Table_Structure.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Tenant_Initial_Table_Structure
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3TE_CTITS_1108 Execute(DbConnection Connection,DbTransaction Transaction,P_L3TE_CTITS_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L3TE_CTITS_1108();
            returnValue.Result = new L3TE_CTITS_1108();
            returnValue.Status = FR_Status.Error_Internal;

            #region Load or Create Tenant
            var tenantQuery = new ORM_CMN_Tenant.Query()
            {
                TenantITL = Parameter.TenantITL,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            };

            var customerTenant = ORM_CMN_Tenant.Query.Search(Connection, Transaction, tenantQuery).SingleOrDefault();

            if (customerTenant == default(ORM_CMN_Tenant))
            {
                customerTenant = new ORM_CMN_Tenant();
                customerTenant.CMN_TenantID = Guid.NewGuid();
                customerTenant.TenantITL = Parameter.TenantITL;
                customerTenant.Tenant_RefID = securityTicket.TenantID;
                customerTenant.Creation_Timestamp = DateTime.Now;
                customerTenant.UniversalContactDetail_RefID = Guid.NewGuid();
                if (customerTenant.Save(Connection, Transaction).Status != FR_Status.Success)
                {
                    return returnValue;
                }
            }
            #endregion

            #region Load or Create BusinessParticipant
            var businessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                IsTenant = true,
                IfTenant_Tenant_RefID = customerTenant.CMN_TenantID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (businessParticipant == default(ORM_CMN_BPT_BusinessParticipant))
            {
                businessParticipant = new ORM_CMN_BPT_BusinessParticipant();
                businessParticipant.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                businessParticipant.BusinessParticipantITL = Parameter.BusinessParticipantITL;
                businessParticipant.DisplayName = Parameter.CompanyName;
                businessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID = Guid.NewGuid();
                businessParticipant.IfTenant_Tenant_RefID = customerTenant.CMN_TenantID;
                businessParticipant.IsCompany = true;
                businessParticipant.IsTenant = true;
                businessParticipant.Tenant_RefID = securityTicket.TenantID;
                businessParticipant.Creation_Timestamp = DateTime.Now;
                if (businessParticipant.Save(Connection, Transaction).Status != FR_Status.Success)
                {
                    return returnValue;
                }
            }
            #endregion

            #region Load or Create CompanyInfo
            var companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, new ORM_CMN_COM_CompanyInfo.Query()
            {
                CMN_COM_CompanyInfoID = businessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (companyInfo == default(ORM_CMN_COM_CompanyInfo))
            {
                companyInfo = new ORM_CMN_COM_CompanyInfo();
                companyInfo.CMN_COM_CompanyInfoID = businessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
                companyInfo.Contact_UCD_RefID = Guid.NewGuid();
                companyInfo.Tenant_RefID = securityTicket.TenantID;
                companyInfo.Creation_Timestamp = DateTime.Now;
                if (companyInfo.Save(Connection, Transaction).Status != FR_Status.Success)
                {
                    return returnValue;
                }
            }
            #endregion

            #region Load or Create UniversalContactDetails for Tenant and CompanyInfo
            var ucdTenant = ORM_CMN_UniversalContactDetail.Query.Search(
                Connection,
                Transaction,
                new ORM_CMN_UniversalContactDetail.Query()
                {
                    CMN_UniversalContactDetailID = customerTenant.UniversalContactDetail_RefID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

            if (ucdTenant == default(ORM_CMN_UniversalContactDetail))
            {
                ucdTenant = new ORM_CMN_UniversalContactDetail();
                ucdTenant.CMN_UniversalContactDetailID = customerTenant.UniversalContactDetail_RefID;
                ucdTenant.UniversalContactDetailsITL = Parameter.TenantUniversalContactDetailITL;
                ucdTenant.IsCompany = true;
                ucdTenant.CompanyName_Line1 = Parameter.CompanyName;
                ucdTenant.Contact_Email = Parameter.ContactEmail;
                ucdTenant.Tenant_RefID = securityTicket.TenantID;
                ucdTenant.Creation_Timestamp = DateTime.Now;
                if (ucdTenant.Save(Connection, Transaction).Status != FR_Status.Success)
                {
                    return returnValue;
                }
            }

            var ucdCompanyInfo = ORM_CMN_UniversalContactDetail.Query.Search(
                Connection,
                Transaction,
                new ORM_CMN_UniversalContactDetail.Query()
                {
                    CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

            if (ucdCompanyInfo == default(ORM_CMN_UniversalContactDetail))
            {
                ucdCompanyInfo = new ORM_CMN_UniversalContactDetail();
                ucdCompanyInfo.CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID;
                ucdCompanyInfo.UniversalContactDetailsITL = Parameter.CompanyInfoUniversalContactDetailITL;
                ucdCompanyInfo.IsCompany = true;
                ucdCompanyInfo.CompanyName_Line1 = Parameter.CompanyName;
                ucdCompanyInfo.Contact_Email = Parameter.ContactEmail;
                ucdCompanyInfo.Tenant_RefID = securityTicket.TenantID;
                ucdCompanyInfo.Creation_Timestamp = DateTime.Now;
                if (ucdCompanyInfo.Save(Connection, Transaction).Status != FR_Status.Success)
                {
                    return returnValue;
                }
            }
            #endregion

            returnValue.Result.TenantID = customerTenant.CMN_TenantID;
            returnValue.Result.BusinessParticipantID = businessParticipant.CMN_BPT_BusinessParticipantID;
            returnValue.Result.TenantUniversalContactDetailID = ucdTenant.CMN_UniversalContactDetailID;
            returnValue.Result.CompanyInfoUniversalContactDetailID = ucdCompanyInfo.CMN_UniversalContactDetailID;
            returnValue.Result.CompanyInfoID = companyInfo.CMN_COM_CompanyInfoID;
            returnValue.Status = FR_Status.Success;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3TE_CTITS_1108 Invoke(string ConnectionString,P_L3TE_CTITS_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3TE_CTITS_1108 Invoke(DbConnection Connection,P_L3TE_CTITS_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3TE_CTITS_1108 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3TE_CTITS_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3TE_CTITS_1108 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3TE_CTITS_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3TE_CTITS_1108 functionReturn = new FR_L3TE_CTITS_1108();
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

				throw new Exception("Exception occured in method cls_Create_Tenant_Initial_Table_Structure",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3TE_CTITS_1108 : FR_Base
	{
		public L3TE_CTITS_1108 Result	{ get; set; }

		public FR_L3TE_CTITS_1108() : base() {}

		public FR_L3TE_CTITS_1108(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3TE_CTITS_1108 for attribute P_L3TE_CTITS_1108
		[DataContract]
		public class P_L3TE_CTITS_1108 
		{
			//Standard type parameters
			[DataMember]
			public String TenantITL { get; set; } 
			[DataMember]
			public String CompanyName { get; set; } 
			[DataMember]
			public String ContactEmail { get; set; } 
			[DataMember]
			public String BusinessParticipantITL { get; set; } 
			[DataMember]
			public String TenantUniversalContactDetailITL { get; set; } 
			[DataMember]
			public String CompanyInfoUniversalContactDetailITL { get; set; } 

		}
		#endregion
		#region SClass L3TE_CTITS_1108 for attribute L3TE_CTITS_1108
		[DataContract]
		public class L3TE_CTITS_1108 
		{
			//Standard type parameters
			[DataMember]
			public Guid TenantID { get; set; } 
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CompanyInfoUniversalContactDetailID { get; set; } 
			[DataMember]
			public Guid TenantUniversalContactDetailID { get; set; } 
			[DataMember]
			public Guid CompanyInfoID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3TE_CTITS_1108 cls_Create_Tenant_Initial_Table_Structure(,P_L3TE_CTITS_1108 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3TE_CTITS_1108 invocationResult = cls_Create_Tenant_Initial_Table_Structure.Invoke(connectionString,P_L3TE_CTITS_1108 Parameter,securityTicket);
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
var parameter = new CL3_Tenant.Complex.Manipulation.P_L3TE_CTITS_1108();
parameter.TenantITL = ...;
parameter.CompanyName = ...;
parameter.ContactEmail = ...;
parameter.BusinessParticipantITL = ...;
parameter.TenantUniversalContactDetailITL = ...;
parameter.CompanyInfoUniversalContactDetailITL = ...;

*/
