/* 
 * Generated on 10/1/2014 2:04:21 PM
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
using CL1_CMN_BPT_CTM;
using DLCore_MessageListener.Messages;
using CL3_OrganizationalStructure.Utils;

namespace CL3_OrganizationalStructure.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_OrganizationalUnits_after_MessageReceive.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_OrganizationalUnits_after_MessageReceive
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3OS_COUaMR_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();

            #region Preload data

            var languages = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            });

            #endregion

            #region Retrieve already saved org. units and addresses

            var retrievedOrgUnits = CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_OrganizationalUnit.Query.Search(Connection, Transaction,
                new ORM_CMN_BPT_CTM_OrganizationalUnit.Query
                {
                    Customer_RefID = Parameter.CustomerID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });
            var retrievedOrgUnitOfficeITLs = retrievedOrgUnits.Select(x => x.CustomerTenant_OfficeITL);

            String[] officesForDeletionITLs = retrievedOrgUnitOfficeITLs.Except(Parameter.OrganizationUnits.Select(x => x.OfficeITL)).ToArray();
            String[] officesToUpdateITLs = retrievedOrgUnitOfficeITLs.Intersect(Parameter.OrganizationUnits.Select(x => x.OfficeITL)).ToArray();
            String[] officesToCreateITLs = Parameter.OrganizationUnits.Select(x => x.OfficeITL).Except(officesToUpdateITLs).ToArray();

            var dOffices = new Dictionary<String, Guid>();
            foreach (var item in retrievedOrgUnits)
            {
                dOffices[item.CustomerTenant_OfficeITL] = item.CMN_BPT_CTM_OrganizationalUnitID;
            }
            // generate IDs for new offices
            foreach (var item in officesToCreateITLs)
            {
                dOffices[item] = Guid.NewGuid();
            }

            #endregion

            #region Deleted Offices

            foreach (var deletingOfficeITL in officesForDeletionITLs)
            {
                var officeForDeletion = CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_OrganizationalUnit.Query.Search(Connection, Transaction,
                    new ORM_CMN_BPT_CTM_OrganizationalUnit.Query
                    {
                        CustomerTenant_OfficeITL = deletingOfficeITL,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();

                officeForDeletion.IsDeleted = true;
                officeForDeletion.Save(Connection, Transaction);

                var addressesForDeletion = CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_OrganizationalUnit_Address.Query.Search(Connection, Transaction,
                    new ORM_CMN_BPT_CTM_OrganizationalUnit_Address.Query
                    {
                        OrganizationalUnit_RefID = Guid.Parse(deletingOfficeITL),
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });

                foreach (var item in addressesForDeletion)
                {
                    // Delete all ORM_CMN_UniversalContactDetail connected to this Org. unit address
                    CL1_CMN.ORM_CMN_UniversalContactDetail.Query.SoftDelete(Connection, Transaction,
                    new CL1_CMN.ORM_CMN_UniversalContactDetail.Query
                    {
                        CMN_UniversalContactDetailID = item.UniversalContactDetail_Address_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });

                    // Delete ORM_CMN_BPT_CTM_OrganizationalUnit_Address
                    item.IsDeleted = true;
                    item.Save(Connection, Transaction);
                }
            }

            #endregion

            CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_OrganizationalUnit orgUnit = null;
            CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_OrganizationalUnit_Address address = null;

            #region Save new organizational units with addresses

            foreach (var item in Parameter.OrganizationUnits.Where(x => officesToCreateITLs.Contains(x.OfficeITL)))
            {
                Dict officeNameDict = new Dict(ORM_CMN_BPT_CTM_OrganizationalUnit.TableName, Guid.NewGuid());
                foreach (var lang in languages)
                {
                    officeNameDict.AddEntry(lang.CMN_LanguageID, item.Name);
                }

                orgUnit = new ORM_CMN_BPT_CTM_OrganizationalUnit
                {
                    CMN_BPT_CTM_OrganizationalUnitID = dOffices[item.OfficeITL],
                    CustomerTenant_OfficeITL = item.OfficeITL,
                    Customer_RefID = Parameter.CustomerID,
                    Parent_OrganizationalUnit_RefID = String.IsNullOrEmpty(item.ParentOfficeITL) ? Guid.Empty : dOffices[item.ParentOfficeITL],
                    OrganizationalUnit_SimpleName = item.Name,
                    OrganizationalUnit_Name = officeNameDict,
                    InternalOrganizationalUnitNumber = item.Code,
                    InternalOrganizationalUnitSimpleName = item.Name,
                    OrganizationalUnit_Description = new Dict(ORM_CMN_BPT_CTM_OrganizationalUnit.TableName, Guid.NewGuid()),
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    ExternalOrganizationalUnitNumber = item.Code,
                    Default_PhoneNumber = item.ContactPhone,
                    Default_FaxNumber = item.ContactFax,
                };

                if (String.IsNullOrEmpty(item.BillingAddressITL) == false)
                {
                    var billingAddress = Parameter.Addresses.SingleOrDefault(x => item.BillingAddressITL == x.AddressITL);

                    address = new ORM_CMN_BPT_CTM_OrganizationalUnit_Address
                    {
                        CMN_BPT_CTM_OrganizationalUnit_AddressID = Guid.NewGuid(),
                        AddressType = (int)OrganizationalUnitAddressType.Billing,
                        IsPrimary = billingAddress.IsPrimaryBillingAddress,
                        OrganizationalUnit_RefID = orgUnit.CMN_BPT_CTM_OrganizationalUnitID,
                        Creation_Timestamp = DateTime.Now,
                        Tenant_RefID = securityTicket.TenantID
                    };

                    var ucd = new CL1_CMN.ORM_CMN_UniversalContactDetail
                    {
                        CMN_UniversalContactDetailID = Guid.NewGuid(),
                        CompanyName_Line1 = null,
                        Street_Name = billingAddress.StreetName,
                        Street_Number = billingAddress.StreetNumber,
                        ZIP = billingAddress.ZipCode,
                        Town = billingAddress.City,
                        Country_639_1_ISOCode = billingAddress.CountryISO,
                        Creation_Timestamp = DateTime.Now,
                        Tenant_RefID = securityTicket.TenantID
                    };
                    ucd.Save(Connection, Transaction);

                    address.UniversalContactDetail_Address_RefID = ucd.CMN_UniversalContactDetailID;
                    address.Save(Connection, Transaction);
                }

                if (String.IsNullOrEmpty(item.ShippingAddressITL) == false)
                {
                    var shippingAddress = Parameter.Addresses.SingleOrDefault(x => item.ShippingAddressITL == x.AddressITL);

                    address = new ORM_CMN_BPT_CTM_OrganizationalUnit_Address
                    {
                        CMN_BPT_CTM_OrganizationalUnit_AddressID = Guid.NewGuid(),
                        AddressType = (int)OrganizationalUnitAddressType.Shipping,
                        IsPrimary = shippingAddress.IsPrimaryBillingAddress,
                        OrganizationalUnit_RefID = orgUnit.CMN_BPT_CTM_OrganizationalUnitID,
                        Creation_Timestamp = DateTime.Now,
                        Tenant_RefID = securityTicket.TenantID
                    };

                    var ucd = new CL1_CMN.ORM_CMN_UniversalContactDetail
                    {
                        CMN_UniversalContactDetailID = Guid.NewGuid(),
                        CompanyName_Line1 = null,
                        Street_Name = shippingAddress.StreetName,
                        Street_Number = shippingAddress.StreetNumber,
                        ZIP = shippingAddress.ZipCode,
                        Town = shippingAddress.City,
                        Country_639_1_ISOCode = shippingAddress.CountryISO,
                        Creation_Timestamp = DateTime.Now,
                        Tenant_RefID = securityTicket.TenantID
                    };
                    ucd.Save(Connection, Transaction);

                    address.UniversalContactDetail_Address_RefID = ucd.CMN_UniversalContactDetailID;
                    address.Save(Connection, Transaction);
                }

                orgUnit.Save(Connection, Transaction);

                dOffices[item.OfficeITL] = orgUnit.CMN_BPT_CTM_OrganizationalUnitID;
            }

            #endregion

            #region Update org. units with addresses

            foreach (var item in Parameter.OrganizationUnits.Where(x => officesToUpdateITLs.Contains(x.OfficeITL)))
            {
                orgUnit = retrievedOrgUnits.Single(x => x.CustomerTenant_OfficeITL == item.OfficeITL);

                #region Addresses

                #region Billing Addresses

                if (String.IsNullOrEmpty(item.BillingAddressITL))
                {
                    ORM_CMN_BPT_CTM_OrganizationalUnit_Address.Query.SoftDelete(Connection, Transaction,
                    new CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_OrganizationalUnit_Address.Query
                    {
                        OrganizationalUnit_RefID = orgUnit.CMN_BPT_CTM_OrganizationalUnitID,
                        AddressType = (int)OrganizationalUnitAddressType.Billing
                    });
                }
                else
                {
                     var billingAddress = Parameter.Addresses.SingleOrDefault(x => item.BillingAddressITL == x.AddressITL);

                    var existingBillingAdress = CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_OrganizationalUnit_Address.Query.Search(Connection, Transaction,
                        new CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_OrganizationalUnit_Address.Query
                        {
                            OrganizationalUnit_RefID = orgUnit.CMN_BPT_CTM_OrganizationalUnitID,
                            AddressType = (int)OrganizationalUnitAddressType.Billing,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).SingleOrDefault();

                    if (existingBillingAdress == null)
                    {
                        #region Create New 
                        
                        address = new ORM_CMN_BPT_CTM_OrganizationalUnit_Address
                        {
                            CMN_BPT_CTM_OrganizationalUnit_AddressID = Guid.NewGuid(),
                            AddressType = (int)OrganizationalUnitAddressType.Billing,
                            IsPrimary = billingAddress.IsPrimaryBillingAddress,
                            OrganizationalUnit_RefID = orgUnit.CMN_BPT_CTM_OrganizationalUnitID,
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID
                        };

                        var ucd = new CL1_CMN.ORM_CMN_UniversalContactDetail
                        {
                            CMN_UniversalContactDetailID = Guid.NewGuid(),
                            CompanyName_Line1 = null,
                            Street_Name = billingAddress.StreetName,
                            Street_Number = billingAddress.StreetNumber,
                            ZIP = billingAddress.ZipCode,
                            Town = billingAddress.City,
                            Country_639_1_ISOCode = billingAddress.CountryISO,
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        ucd.Save(Connection, Transaction);

                        address.UniversalContactDetail_Address_RefID = ucd.CMN_UniversalContactDetailID;
                        address.Save(Connection, Transaction);
                        
                        #endregion
                    }
                    else
                    {
                        #region Update existing

                         var ucd = CL1_CMN.ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction,
                            new CL1_CMN.ORM_CMN_UniversalContactDetail.Query
                            {
                                CMN_UniversalContactDetailID = existingBillingAdress.UniversalContactDetail_Address_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).Single();

                        ucd.Street_Name = billingAddress.StreetName;
                        ucd.Street_Number = billingAddress.StreetNumber;
                        ucd.ZIP = billingAddress.ZipCode;
                        ucd.Town = billingAddress.City;
                        ucd.Country_639_1_ISOCode = billingAddress.CountryISO;

                        ucd.Save(Connection, Transaction);
                        
                        #endregion
                    }
                }

                #endregion

                #region Shipping Addresses

                if (String.IsNullOrEmpty(item.ShippingAddressITL))
                {
                    ORM_CMN_BPT_CTM_OrganizationalUnit_Address.Query.SoftDelete(Connection, Transaction,
                    new CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_OrganizationalUnit_Address.Query
                    {
                        OrganizationalUnit_RefID = orgUnit.CMN_BPT_CTM_OrganizationalUnitID,
                        AddressType = (int)OrganizationalUnitAddressType.Shipping
                    });
                }
                else
                {
                    var shippingAddress = Parameter.Addresses.SingleOrDefault(x => item.ShippingAddressITL == x.AddressITL);

                    var existingShippingAddress = CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_OrganizationalUnit_Address.Query.Search(Connection, Transaction,
                        new CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_OrganizationalUnit_Address.Query
                        {
                            OrganizationalUnit_RefID = orgUnit.CMN_BPT_CTM_OrganizationalUnitID,
                            AddressType = (int)OrganizationalUnitAddressType.Shipping,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).SingleOrDefault();

                    if (existingShippingAddress == null)
                    {
                        #region Create New

                        address = new ORM_CMN_BPT_CTM_OrganizationalUnit_Address
                        {
                            CMN_BPT_CTM_OrganizationalUnit_AddressID = Guid.NewGuid(),
                            AddressType = (int)OrganizationalUnitAddressType.Shipping,
                            IsPrimary = shippingAddress.IsPrimaryShippingAddress,
                            OrganizationalUnit_RefID = orgUnit.CMN_BPT_CTM_OrganizationalUnitID,
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID
                        };

                        var ucd = new CL1_CMN.ORM_CMN_UniversalContactDetail
                        {
                            CMN_UniversalContactDetailID = Guid.NewGuid(),
                            CompanyName_Line1 = null,
                            Street_Name = shippingAddress.StreetName,
                            Street_Number = shippingAddress.StreetNumber,
                            ZIP = shippingAddress.ZipCode,
                            Town = shippingAddress.City,
                            Country_639_1_ISOCode = shippingAddress.CountryISO,
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        ucd.Save(Connection, Transaction);

                        address.UniversalContactDetail_Address_RefID = ucd.CMN_UniversalContactDetailID;
                        address.Save(Connection, Transaction);

                        #endregion
                    }
                    else
                    {
                        #region Update existing

                        var ucd = CL1_CMN.ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction,
                           new CL1_CMN.ORM_CMN_UniversalContactDetail.Query
                           {
                               CMN_UniversalContactDetailID = existingShippingAddress.UniversalContactDetail_Address_RefID,
                               IsDeleted = false,
                               Tenant_RefID = securityTicket.TenantID
                           }).Single();

                        ucd.Street_Name = shippingAddress.StreetName;
                        ucd.Street_Number = shippingAddress.StreetNumber;
                        ucd.ZIP = shippingAddress.ZipCode;
                        ucd.Town = shippingAddress.City;
                        ucd.Country_639_1_ISOCode = shippingAddress.CountryISO;

                        ucd.Save(Connection, Transaction);

                        #endregion
                    }
                }
                #endregion

                #endregion

                #region Org. unit

                foreach (DictEntry dictEntry in orgUnit.OrganizationalUnit_Name.Contents)
                {
                    dictEntry.Content = item.Name;
                }
                orgUnit.Parent_OrganizationalUnit_RefID = String.IsNullOrEmpty(item.ParentOfficeITL) ? Guid.Empty : dOffices[item.ParentOfficeITL];
                orgUnit.ExternalOrganizationalUnitNumber = item.Code;
                orgUnit.OrganizationalUnit_SimpleName = item.Name;
                orgUnit.Default_PhoneNumber = item.ContactPhone;
                orgUnit.Default_FaxNumber = item.ContactFax;

                orgUnit.Save(Connection, Transaction);

                #endregion
            }

            #endregion

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3OS_COUaMR_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3OS_COUaMR_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3OS_COUaMR_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3OS_COUaMR_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_OrganizationalUnits_after_MessageReceive",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3OS_COUaMR_1344 for attribute P_L3OS_COUaMR_1344
		[DataContract]
		public class P_L3OS_COUaMR_1344 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerID { get; set; } 
			[DataMember]
			public Address[] Addresses { get; set; } 
			[DataMember]
			public OrganizationUnit[] OrganizationUnits { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_OrganizationalUnits_after_MessageReceive(,P_L3OS_COUaMR_1344 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_OrganizationalUnits_after_MessageReceive.Invoke(connectionString,P_L3OS_COUaMR_1344 Parameter,securityTicket);
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
var parameter = new CL3_OrganizationalStructure.Complex.Manipulation.P_L3OS_COUaMR_1344();
parameter.CustomerID = ...;
parameter.Addresses = ...;
parameter.OrganizationUnits = ...;

*/
