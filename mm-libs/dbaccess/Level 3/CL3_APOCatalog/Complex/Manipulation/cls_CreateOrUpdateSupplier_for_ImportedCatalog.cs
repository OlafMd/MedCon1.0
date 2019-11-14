/* 
 * Generated on 3/12/2014 2:39:39 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_CMN_COM;
using CL1_CMN_BPT;
using CL1_CMN;

namespace CL3_APOCatalog.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_CreateOrUpdateSupplier_for_ImportedCatalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_CreateOrUpdateSupplier_for_ImportedCatalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3CA_CoUSfIC_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            /*
            * @See if Supplier already exists in database
            * */
            ORM_CMN_BPT_Supplier supplier = new ORM_CMN_BPT_Supplier();

            var supplierQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
            supplierQuery.BusinessParticipantITL = Parameter.SupplierITL;
            supplierQuery.Tenant_RefID = securityTicket.TenantID;
            supplierQuery.IsDeleted = false;

            var supplier_bussinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, supplierQuery).FirstOrDefault();

            #region if supplier does not exist

            if (supplier_bussinessParticipant == null)
            {
                /*
                    * @Make Supplier Data
                    * */

                var tenantQuery = new ORM_CMN_Tenant.Query()
                {
                    TenantITL = Parameter.TenantITL,
                    Tenant_RefID = securityTicket.TenantID
                };

                var supplierTenant = ORM_CMN_Tenant.Query.Search(Connection, Transaction, tenantQuery).SingleOrDefault();

                if (supplierTenant == default(ORM_CMN_Tenant))
                {
                    supplierTenant = new ORM_CMN_Tenant();
                    supplierTenant.CMN_TenantID = Guid.NewGuid();
                    supplierTenant.TenantITL = Parameter.TenantITL;
                    supplierTenant.Tenant_RefID = securityTicket.TenantID;
                    supplierTenant.Creation_Timestamp = DateTime.Now;
                    supplierTenant.Save(Connection, Transaction);
                }

                supplier.CMN_BPT_SupplierID = Guid.NewGuid();
                supplier.Ext_BusinessParticipant_RefID = Guid.NewGuid();//supplierBussinessParticipant.CMN_BPT_BusinessParticipantID
                supplier.Creation_Timestamp = DateTime.Now;
                supplier.IsDeleted = false;
                supplier.Tenant_RefID = securityTicket.TenantID;
                supplier.Save(Connection, Transaction);

                ORM_CMN_BPT_BusinessParticipant supplierBussinessParticipant = new ORM_CMN_BPT_BusinessParticipant();
                supplierBussinessParticipant.CMN_BPT_BusinessParticipantID = supplier.Ext_BusinessParticipant_RefID;
                supplierBussinessParticipant.DisplayName = Parameter.Supplier_Name;
                supplierBussinessParticipant.BusinessParticipantITL = Parameter.SupplierITL;
                supplierBussinessParticipant.Creation_Timestamp = DateTime.Now;
                supplierBussinessParticipant.Tenant_RefID = securityTicket.TenantID;
                supplierBussinessParticipant.IsCompany = true;
                supplierBussinessParticipant.IsTenant = true;
                supplierBussinessParticipant.IfTenant_Tenant_RefID = supplierTenant.CMN_TenantID;
                supplierBussinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID = Guid.NewGuid();//companyInfo.CMN_COM_CompanyInfoID 
                supplierBussinessParticipant.Save(Connection, Transaction);

                ORM_CMN_COM_CompanyInfo companyInfo = new ORM_CMN_COM_CompanyInfo();
                companyInfo.CMN_COM_CompanyInfoID = supplierBussinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
                companyInfo.Creation_Timestamp = DateTime.Now;
                companyInfo.Tenant_RefID = securityTicket.TenantID;
                companyInfo.Contact_UCD_RefID = Guid.NewGuid();//universalContactDetail.CMN_UniversalContactDetailID
                companyInfo.Save(Connection, Transaction);

                ORM_CMN_UniversalContactDetail universalContactDetail = new ORM_CMN_UniversalContactDetail();
                universalContactDetail.CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID;
                universalContactDetail.IsCompany = true;
                universalContactDetail.Country_639_1_ISOCode = Parameter.CountryISO;
                universalContactDetail.Street_Name = Parameter.Supplier_Name;
                universalContactDetail.Street_Number = Parameter.Street_Number;
                universalContactDetail.ZIP = Parameter.ZIP;
                universalContactDetail.Town = Parameter.Town;
                universalContactDetail.Region_Code = Parameter.Region_Code;
                universalContactDetail.Tenant_RefID = securityTicket.TenantID;
                universalContactDetail.Creation_Timestamp = DateTime.Now;
                universalContactDetail.Save(Connection, Transaction);
            }
            #endregion
            #region if supplier exists , check if its data is changed
            else
            {

                var tenantQuery = new ORM_CMN_Tenant.Query()
                {
                    TenantITL = Parameter.TenantITL,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                };

                ORM_CMN_Tenant supplierTenant;

                if (ORM_CMN_Tenant.Query.Search(Connection, Transaction, tenantQuery).Count > 1)
                    supplierTenant = ORM_CMN_Tenant.Query.Search(Connection, Transaction, tenantQuery).First(); //QUICKFIX
                else
                    supplierTenant = ORM_CMN_Tenant.Query.Search(Connection, Transaction, tenantQuery).SingleOrDefault();

                if (supplierTenant == default(ORM_CMN_Tenant))
                {
                    supplierTenant = new ORM_CMN_Tenant();
                    supplierTenant.CMN_TenantID = Guid.NewGuid();
                    supplierTenant.TenantITL = Parameter.TenantITL;
                    supplierTenant.Tenant_RefID = securityTicket.TenantID;
                    supplierTenant.Creation_Timestamp = DateTime.Now;
                    supplierTenant.Save(Connection, Transaction);

                    supplier_bussinessParticipant.IsTenant = true;
                    supplier_bussinessParticipant.IfTenant_Tenant_RefID = supplierTenant.CMN_TenantID;
                }

                supplier_bussinessParticipant.DisplayName = Parameter.Supplier_Name;
                supplier_bussinessParticipant.Save(Connection, Transaction);

                var query = new ORM_CMN_BPT_Supplier.Query();
                query.Ext_BusinessParticipant_RefID = supplier_bussinessParticipant.CMN_BPT_BusinessParticipantID;
                query.Tenant_RefID = securityTicket.TenantID;
                query.IsDeleted = false;

                supplier = ORM_CMN_BPT_Supplier.Query.Search(Connection, Transaction, query).First();

                //edit universal contact details

                var companyInfoQuery = new ORM_CMN_COM_CompanyInfo.Query();
                companyInfoQuery.CMN_COM_CompanyInfoID = supplier_bussinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
                companyInfoQuery.Tenant_RefID = securityTicket.TenantID;
                companyInfoQuery.IsDeleted = false;

                var companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, companyInfoQuery).First();

                var universalContactDetailQuery = new ORM_CMN_UniversalContactDetail.Query();
                universalContactDetailQuery.CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID;
                universalContactDetailQuery.Tenant_RefID = securityTicket.TenantID;
                universalContactDetailQuery.IsDeleted = false;

                var universalContactDetail = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, universalContactDetailQuery).First();

                universalContactDetail.Country_639_1_ISOCode = Parameter.CountryISO;
                universalContactDetail.Street_Name = Parameter.Supplier_Name;
                universalContactDetail.Street_Number = Parameter.Street_Number;
                universalContactDetail.ZIP = Parameter.ZIP;
                universalContactDetail.Town = Parameter.Town;
                universalContactDetail.Region_Code = Parameter.Region_Code;
                universalContactDetail.Save(Connection, Transaction);

            }
            #endregion

            returnValue.Result = supplier.CMN_BPT_SupplierID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3CA_CoUSfIC_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3CA_CoUSfIC_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CA_CoUSfIC_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CA_CoUSfIC_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_CreateOrUpdateSupplier_for_ImportedCatalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3CA_CoUSfIC_1545 for attribute P_L3CA_CoUSfIC_1545
		[DataContract]
		public class P_L3CA_CoUSfIC_1545 
		{
			//Standard type parameters
			[DataMember]
			public String SupplierITL { get; set; } 
			[DataMember]
			public String TenantITL { get; set; } 
			[DataMember]
			public String Supplier_Name { get; set; } 
			[DataMember]
			public String CountryISO { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Region_Code { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_CreateOrUpdateSupplier_for_ImportedCatalog(,P_L3CA_CoUSfIC_1545 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_CreateOrUpdateSupplier_for_ImportedCatalog.Invoke(connectionString,P_L3CA_CoUSfIC_1545 Parameter,securityTicket);
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
var parameter = new CL3_APOCatalog.Complex.Manipulation.P_L3CA_CoUSfIC_1545();
parameter.SupplierITL = ...;
parameter.TenantITL = ...;
parameter.Supplier_Name = ...;
parameter.CountryISO = ...;
parameter.Street_Name = ...;
parameter.Street_Number = ...;
parameter.ZIP = ...;
parameter.Town = ...;
parameter.Region_Code = ...;

*/
