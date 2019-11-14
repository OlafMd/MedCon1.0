/* 
 * Generated on 7/1/2014 1:45:20 PM
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
using CL5_APOAdmin_Supplier.Atomic.Retrieval;
using CSV2Core.Core;
using System.Runtime.Serialization;
using DLCore_DBCommons.APODemand;
using DLCore_DBCommons.Utils;

namespace CL5_APOAdmin_Supplier.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Supplier.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Supplier
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AAS_SS_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            var item = new CL1_CMN_BPT.ORM_CMN_BPT_Supplier();
            var businessParticipant = new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant();
            var companyInfo = new CL1_CMN_COM.ORM_CMN_COM_CompanyInfo();
            var universalContact = new CL1_CMN.ORM_CMN_UniversalContactDetail();
            var discountValue = new CL1_CMN_BPT.ORM_CMN_BPT_Supplier_DiscountValue();
            var cashDiscountValue = new CL1_CMN_BPT.ORM_CMN_BPT_Supplier_DiscountValue();

		    
            var discountQuery = new CL1_ORD_PRC.ORM_ORD_PRC_DiscountType.Query();
            discountQuery.Tenant_RefID = securityTicket.TenantID;
            discountQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDiscountType.MainDiscount);
            var discount = CL1_ORD_PRC.ORM_ORD_PRC_DiscountType.Query.Search(Connection, Transaction, discountQuery).Single();

            var scontoQuery = new CL1_ORD_PRC.ORM_ORD_PRC_DiscountType.Query();
            scontoQuery.Tenant_RefID = securityTicket.TenantID;
            scontoQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDiscountType.CashDiscount);
            var sconto = CL1_ORD_PRC.ORM_ORD_PRC_DiscountType.Query.Search(Connection, Transaction, scontoQuery).SingleOrDefault();

            
            
            if (Parameter.CMN_BPT_SupplierID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_BPT_SupplierID);
                if (item.Ext_BusinessParticipant_RefID != Guid.Empty)
                {
                    businessParticipant.Load(Connection, Transaction, item.Ext_BusinessParticipant_RefID);
                }
                if (businessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID != Guid.Empty)
                {
                    companyInfo.Load(Connection, Transaction, businessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID);
                }
                if (companyInfo.Contact_UCD_RefID != Guid.Empty)
                {
                    universalContact.Load(Connection, Transaction, companyInfo.Contact_UCD_RefID);
                }

                var discountValueQuery = new CL1_CMN_BPT.ORM_CMN_BPT_Supplier_DiscountValue.Query();
                discountValueQuery.Supplier_RefID = Parameter.CMN_BPT_SupplierID;
                discountValueQuery.Tenant_RefID = securityTicket.TenantID;
                discountValueQuery.ORD_PRC_DiscountType_RefID = discount.ORD_PRC_DiscountTypeID;
                var foundDiscountValue = CL1_CMN_BPT.ORM_CMN_BPT_Supplier_DiscountValue.Query.Search(Connection, Transaction, discountValueQuery);

                if (foundDiscountValue.Count == 1)
                {
                    discountValue = foundDiscountValue.Single();
                }

                var scontoValueQuery = new CL1_CMN_BPT.ORM_CMN_BPT_Supplier_DiscountValue.Query();
                scontoValueQuery.Supplier_RefID = Parameter.CMN_BPT_SupplierID;
                scontoValueQuery.Tenant_RefID = securityTicket.TenantID;
                scontoValueQuery.ORD_PRC_DiscountType_RefID = sconto.ORD_PRC_DiscountTypeID;
                var foundCashValue = CL1_CMN_BPT.ORM_CMN_BPT_Supplier_DiscountValue.Query.Search(Connection, Transaction, scontoValueQuery);

                if (foundCashValue.Count == 1)
                {
                    cashDiscountValue = foundCashValue.Single();
                }

            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                businessParticipant.IsDeleted = true;
                companyInfo.IsDeleted = true;
                universalContact.IsDeleted = true;

                #region Delete company info address
                P_L5AAS_GAfCI_1526 addressParam = new P_L5AAS_GAfCI_1526();
                addressParam.CompanyInfoID = companyInfo.CMN_COM_CompanyInfoID;
                var addresses = cls_Get_Addresses_for_CompanyInfoID.Invoke(Connection, Transaction, addressParam, securityTicket).Result;
                foreach (var a in addresses)
                {
                    P_L5AAS_SSA_1528 addressSaveParameter = new P_L5AAS_SSA_1528();
                    addressSaveParameter.CMN_COM_CompanyInfo_AddressID = a.CMN_COM_CompanyInfo_AddressID;
                    addressSaveParameter.CompanyInfo_RefID = a.CompanyInfo_RefID;
                    addressSaveParameter.IsDeleted = true;
                    cls_Save_Supplier_Address.Invoke(Connection, Transaction, addressSaveParameter, securityTicket);
                }
                #endregion

                #region Delete Contact Persons
                P_L5AAS_GCPIfBP_1607 contactPersonParam = new P_L5AAS_GCPIfBP_1607();
                contactPersonParam.BusinessParticipantID = businessParticipant.CMN_BPT_BusinessParticipantID;
                var contactPersons = cls_Get_Contact_Person_Info_for_BusinessParticipantID.Invoke(Connection, Transaction, contactPersonParam, securityTicket).Result;
                foreach (var c in contactPersons)
                {
                    P_L5AAS_SSPCI_0832 contactPersonSaveParam = new P_L5AAS_SSPCI_0832();
                    contactPersonSaveParam.AssociatedBusinessParticipant_RefID = c.AssociatedBusinessParticipant_RefID;
                    contactPersonSaveParam.CMN_AddressID = c.CMN_AddressID;
                    contactPersonSaveParam.CMN_BPT_BusinessParticipantID = c.CMN_BPT_BusinessParticipantID;
                    cls_Save_Supplier_Contact_Person_Info.Invoke(Connection, Transaction, contactPersonSaveParam, securityTicket);
                }
                #endregion

                businessParticipant.Save(Connection, Transaction);
                companyInfo.Save(Connection, Transaction);
                universalContact.Save(Connection, Transaction);
                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_BPT_SupplierID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.CMN_BPT_SupplierID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
                businessParticipant.Tenant_RefID = securityTicket.TenantID;
                companyInfo.Tenant_RefID = securityTicket.TenantID;
                universalContact.Tenant_RefID = securityTicket.TenantID;
            }

            item.SupplierType_RefID = Parameter.CMN_BPT_Supplier_TypeID;
            item.Ext_BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID;
            item.ExternalSupplierProvidedIdentifier = Parameter.SupplierProvidedExternalIdentifier;

            businessParticipant.DisplayName = Parameter.DisplayName;
            businessParticipant.IsCompany = true;
            businessParticipant.DefaultCurrency_RefID = Parameter.DefaultCurrency_RefID;
            businessParticipant.DefaultLanguage_RefID = Parameter.DefaultLanguage_RefID;
            businessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;

            companyInfo.Contact_UCD_RefID = universalContact.CMN_UniversalContactDetailID;
            companyInfo.CompanyInfo_EstablishmentNumber = Parameter.CompanyInfo_EstablishmentNumber;
            companyInfo.AnnualRevenueAmountValue_RefID = Parameter.AnnualRevenueAmountValue_RefID;
            companyInfo.VATIdentificationNumber = Parameter.VATIdentificationNumber;

            universalContact.CompanyName_Line1 = Parameter.CompanyName_Line1;
            universalContact.Country_639_1_ISOCode = Parameter.Country_639_1_ISOCode;

            if (businessParticipant.CMN_BPT_BusinessParticipantID != Guid.Empty)
            {
                businessParticipant.Save(Connection, Transaction);
            }

            if (companyInfo.CMN_COM_CompanyInfoID != Guid.Empty)
            {
                companyInfo.Save(Connection, Transaction);
            }

            if (universalContact.CMN_UniversalContactDetailID != Guid.Empty)
            {
                universalContact.Save(Connection, Transaction);
            }

           Guid savedSupplier = new FR_Guid(item.Save(Connection, Transaction), item.CMN_BPT_SupplierID).Result;

            #region DiscountValue
           

            if (discountValue.Tenant_RefID == Guid.Empty)
            {
                discountValue.CMN_BPT_Supplier_DiscountValueID = Guid.NewGuid();
                discountValue.Supplier_RefID = savedSupplier;
                discountValue.ORD_PRC_DiscountType_RefID = discount.ORD_PRC_DiscountTypeID;
                discountValue.Tenant_RefID = securityTicket.TenantID;
            }

		    discountValue.DiscountValue_in_percent = Parameter.DiscountValue;
            discountValue.Save(Connection, Transaction);


            if (cashDiscountValue.Tenant_RefID == Guid.Empty)
            {
                cashDiscountValue.CMN_BPT_Supplier_DiscountValueID = Guid.NewGuid();
                cashDiscountValue.Supplier_RefID = savedSupplier;
                cashDiscountValue.ORD_PRC_DiscountType_RefID = sconto.ORD_PRC_DiscountTypeID;
                cashDiscountValue.Tenant_RefID = securityTicket.TenantID;
            }

            cashDiscountValue.DiscountValue_in_percent = Parameter.CashDiscountValue;
            cashDiscountValue.Save(Connection, Transaction);

            #endregion

            returnValue.Result = savedSupplier;
            return returnValue;

            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AAS_SS_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AAS_SS_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AAS_SS_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AAS_SS_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Supplier",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AAS_SS_1355 for attribute P_L5AAS_SS_1355
		[DataContract]
		public class P_L5AAS_SS_1355 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_Supplier_TypeID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Guid DefaultLanguage_RefID { get; set; } 
			[DataMember]
			public Guid DefaultCurrency_RefID { get; set; } 
			[DataMember]
			public String CompanyInfo_EstablishmentNumber { get; set; } 
			[DataMember]
			public Guid AnnualRevenueAmountValue_RefID { get; set; } 
			[DataMember]
			public String VATIdentificationNumber { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public String Country_639_1_ISOCode { get; set; } 
			[DataMember]
			public String SupplierProvidedExternalIdentifier  { get; set; } 
			[DataMember]
			public Double DiscountValue { get; set; } 
			[DataMember]
			public Double CashDiscountValue { get; set; }
            [DataMember]
            public Guid? Main_CMN_BPT_Supplier_DiscountValueID { get; set; }
            [DataMember]
            public Guid? Cash_CMN_BPT_Supplier_DiscountValueID { get; set; }
        }
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Supplier(,P_L5AAS_SS_1355 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Supplier.Invoke(connectionString,P_L5AAS_SS_1355 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Supplier.Complex.Manipulation.P_L5AAS_SS_1355();
parameter.CMN_BPT_SupplierID = ...;
parameter.CMN_BPT_Supplier_TypeID = ...;
parameter.IsDeleted = ...;
parameter.DisplayName = ...;
parameter.DefaultLanguage_RefID = ...;
parameter.DefaultCurrency_RefID = ...;
parameter.CompanyInfo_EstablishmentNumber = ...;
parameter.AnnualRevenueAmountValue_RefID = ...;
parameter.VATIdentificationNumber = ...;
parameter.CompanyName_Line1 = ...;
parameter.Country_639_1_ISOCode = ...;
parameter.SupplierProvidedExternalIdentifier  = ...;
parameter.DiscountValue = ...;
parameter.CashDiscountValue = ...;
parameter.Cash_DiscountValue_in_percent = ...;
parameter.Main_DiscountValue_in_percent = ...;

*/
