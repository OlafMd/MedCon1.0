/* 
 * Generated on 24.2.2015 2:46:28
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
using CL1_ORD_DIS;
using CL1_DOC;
using CL1_USR;
using CL1_CMN_PRO_ASS;
using CL1_CMN_PRO;

namespace CL3_DistributionOrder.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_DistributionOrder.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_DistributionOrder
    {
        public static readonly int QueryTimeout = 60;
        public static readonly string NumberRangeGlobalPropertyMatchingID = "zugseil-numberrange-distributionorder";

        #region Method Execution
        protected static FR_L3DO_SDO_1801 Execute(DbConnection Connection, DbTransaction Transaction, P_L3DO_SDO_1801 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L3DO_SDO_1801();
            returnValue.Result = new L3DO_SDO_1801();

            ORM_CMN_UniversalContactDetail universalContactDetails = new ORM_CMN_UniversalContactDetail();
            universalContactDetails.CMN_UniversalContactDetailID = Guid.NewGuid();
            universalContactDetails.Contact_Email = Parameter.UniversalContactDetails.Email;
            universalContactDetails.Contact_Telephone = Parameter.UniversalContactDetails.Phone;
            universalContactDetails.Country_Name = Parameter.UniversalContactDetails.Country;
            universalContactDetails.Country_639_1_ISOCode = Parameter.UniversalContactDetails.CountryIso;
            universalContactDetails.Creation_Timestamp = DateTime.Now;
            universalContactDetails.First_Name = Parameter.UniversalContactDetails.FirstName;
            universalContactDetails.Last_Name = Parameter.UniversalContactDetails.LastName;
            universalContactDetails.Street_Name = Parameter.UniversalContactDetails.StreetName;
            universalContactDetails.Street_Number = Parameter.UniversalContactDetails.StreetNumber;
            universalContactDetails.ZIP = Parameter.UniversalContactDetails.Zip;
            universalContactDetails.Town = Parameter.UniversalContactDetails.Town;
            universalContactDetails.Tenant_RefID = securityTicket.TenantID;
            universalContactDetails.POBox = Parameter.UniversalContactDetails.POBox;
            universalContactDetails.Save(Connection, Transaction);


            ORM_CMN_NumberRange_UsageArea numberRangeUsageArea = ORM_CMN_NumberRange_UsageArea.Query.Search(Connection, Transaction, new ORM_CMN_NumberRange_UsageArea.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                GlobalStaticMatchingID = NumberRangeGlobalPropertyMatchingID
            }).FirstOrDefault();


            if (numberRangeUsageArea == null)
            {
                throw new Exception(String.Format("Number range usage area with GPMID = {0} was not found.", NumberRangeGlobalPropertyMatchingID));
            }

            ORM_CMN_NumberRange numberRange = ORM_CMN_NumberRange.Query.Search(Connection, Transaction, new ORM_CMN_NumberRange.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                NumberRange_UsageArea_RefID = numberRangeUsageArea.CMN_NumberRange_UsageAreaID
            }).FirstOrDefault();

            if (numberRange == null)
            {
                throw new Exception(String.Format("Number range for area with GPMID = {0} was not found.", NumberRangeGlobalPropertyMatchingID));
            }

            numberRange.Value_Current++;
            numberRange.Save(Connection, Transaction);

            string distributionOrderNumber = numberRange.FixedPrefix + numberRange.Value_Current.ToString().PadLeft(numberRange.Formatting_NumberLength, numberRange.Formatting_LeadingFillCharacter[0]);

            ORM_ORD_DIS_DistributionOrder_Header header = new ORM_ORD_DIS_DistributionOrder_Header();
            header.Charged_CostCenter_RefID = Parameter.IsCostCenterOrderRefID;
            header.Creation_Timestamp = DateTime.Now;
            header.DistributeTo_UCDAddress_RefID = universalContactDetails.CMN_UniversalContactDetailID;
            header.DistributionOrderDate = DateTime.Now;
            header.DistributionOrderNumber = distributionOrderNumber;
            header.IfForDelivery_LogisticsProvider_RefID = Parameter.IsForDeliveryLogisticProviderRefID.ToString();
            header.IfForDelivery_ShipmentType_RefID = Parameter.IsForDeliveryShipmentTypeRefID;
            header.IfForPickup_PointOfSale_RefID = Parameter.IsForPickupPointOfSaleRefID;
            header.IsCostCenterOrder = Parameter.IsCostCenterOrder;
            header.IsDeleted = false;
            header.IsForDelivery = Parameter.IsForDelivery;
            header.ORD_DIS_DistributionOrder_HeaderID = Guid.NewGuid();
            header.Tenant_RefID = securityTicket.TenantID;
            header.InternallyCharged_Currency_RefID = Parameter.CurrencyID;
            header.InternallyCharged_TotalNetPriceValue = 0;
            header.IsForPickup = Parameter.IsForPickup;


            foreach (var item in Parameter.DistributionOrderPositions)
            {
                if (item.Quantity == 0)
                {
                    continue;
                }

                ORM_CMN_PRO_ASS_AssortmentVariant assortmentVariant = ORM_CMN_PRO_ASS_AssortmentVariant.Query.Search(Connection, Transaction, new ORM_CMN_PRO_ASS_AssortmentVariant.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Ext_CMN_PRO_Product_Variant_RefID = item.ProductVariantID
                }).FirstOrDefault();


                ORM_ORD_DIS_DistributionOrder_Position position = null;

                if (assortmentVariant == null)
                {
                    //This means that this product might be local one
                    position = new ORM_ORD_DIS_DistributionOrder_Position();

                    position.Product_RefID = item.ProductID;
                    position.Product_Variant_RefID = item.ProductVariantID;
                }
                else
                {
                    //This means that product is from assortment and we are supposed to take orginal product.
                    List<ORM_CMN_PRO_ASS_AssortmentVariant_VendorVariant> assortmentVendorVariats = ORM_CMN_PRO_ASS_AssortmentVariant_VendorVariant.Query.Search(Connection, Transaction, new ORM_CMN_PRO_ASS_AssortmentVariant_VendorVariant.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_PRO_ASS_AssortmentVariant_RefID = assortmentVariant.CMN_PRO_ASS_AssortmentVariantID
                    });

                    ORM_CMN_PRO_ASS_AssortmentVariant_VendorVariant defaultVendorVariant = assortmentVendorVariats.FirstOrDefault(x => x.IsDefaultVendorVariant == true);
                    if (defaultVendorVariant == null)
                    {
                        defaultVendorVariant = assortmentVendorVariats.First();
                    }

                    if (defaultVendorVariant != null)
                    {
                        ORM_CMN_PRO_Product_Variant productVariant = ORM_CMN_PRO_Product_Variant.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product_Variant.Query()
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            CMN_PRO_Product_VariantID = defaultVendorVariant.CMN_PRO_Product_Variant_RefID
                        }).FirstOrDefault();

                        if (productVariant != null)
                        {
                            position = new ORM_ORD_DIS_DistributionOrder_Position();

                            position.Product_RefID = productVariant.CMN_PRO_Product_RefID;
                            position.Product_Variant_RefID = productVariant.CMN_PRO_Product_VariantID;

                        }
                    }
                }


                if (position != null)
                {
                    position.Creation_Timestamp = DateTime.Now;
                    position.DistributionOrder_Header_RefID = header.ORD_DIS_DistributionOrder_HeaderID;
                    position.ORD_DIS_DistributionOrder_PositionID = Guid.NewGuid();
                    position.Quantity = item.Quantity;
                    position.Tenant_RefID = securityTicket.TenantID;
                    position.InternallyCharged_TotalNetPriceValue = item.PriceValueTotal;

                    position.Save(Connection, Transaction);

                    if (item.DistributionOrderPositionCustomizations != null && item.DistributionOrderPositionCustomizations.Where(x => x.CustomizationVariantID != Guid.Empty).Count() > 0)
                    {
                        foreach (var itemCustomization in item.DistributionOrderPositionCustomizations)
                        {

                            if (itemCustomization.CustomizationVariantID != Guid.Empty)
                            {
                                ORM_ORD_DIS_DistributionOrder_Position_Customization customization = new ORM_ORD_DIS_DistributionOrder_Position_Customization();
                                customization.ORD_DIS_DistributionOrder_Position_CustomizationID = itemCustomization.DistributionOrderPositionCustomizationID;
                                customization.Tenant_RefID = securityTicket.TenantID;
                                customization.DistributionOrder_Position_RefID = position.ORD_DIS_DistributionOrder_PositionID;
                                customization.CustomizationVariant_Name = itemCustomization.CustomizationVariantName;
                                customization.Customization_Variant_RefID = itemCustomization.CustomizationVariantID;
                                customization.Customization_Name = itemCustomization.CustomizationName;

                                customization.Save(Connection, Transaction);
                            }
                        }
                    }
                }

                header.InternallyCharged_TotalNetPriceValue += position.InternallyCharged_TotalNetPriceValue;
            }

            header.Save(Connection, Transaction);

            foreach (var item in Parameter.Documents)
            {

                ORM_DOC_Document document = new ORM_DOC_Document();
                document.Alias = item.Alias;
                document.PrimaryType = item.PrimaryType;
                document.DOC_DocumentID = item.DocumentID;
                document.Creation_Timestamp = DateTime.Now;
                document.Tenant_RefID = securityTicket.TenantID;
                document.Save(Connection, Transaction);

                ORM_ORD_DIS_DistributionOrder_Header_Document orderDocument = new ORM_ORD_DIS_DistributionOrder_Header_Document();
                orderDocument.Creation_Timestamp = DateTime.Now;
                orderDocument.DistributionOrder_Header_RefID = header.ORD_DIS_DistributionOrder_HeaderID;
                orderDocument.Document_RefID = document.DOC_DocumentID;
                orderDocument.ORD_DIS_DistributionOrder_Header_DocumentID = Guid.NewGuid();
                orderDocument.Tenant_RefID = securityTicket.TenantID;
                orderDocument.Save(Connection, Transaction);

            }

            ORM_USR_Account account = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                USR_AccountID = securityTicket.AccountID,
                IsDeleted = false
            }).FirstOrDefault();

            ORM_ORD_DIS_DistributionOrder_Header_History history = new ORM_ORD_DIS_DistributionOrder_Header_History();
            history.Comment = Parameter.UniversalContactDetails.Comment;
            history.Creation_Timestamp = DateTime.Now;
            history.DistributionOrder_Header_RefID = header.ORD_DIS_DistributionOrder_HeaderID;
            history.IsCreated = true;
            history.ORD_DIS_DistributionOrder_Header_HistoryID = Guid.NewGuid();
            history.Tenant_RefID = securityTicket.TenantID;
            history.TriggeredBy_BusinessParticipant_RefID = account != null ? account.BusinessParticipant_RefID : Guid.Empty;
            history.Save(Connection, Transaction);

            returnValue.Result.DistributionOrderHeaderID = header.ORD_DIS_DistributionOrder_HeaderID;
            returnValue.Result.DistributionOrderNumber = header.DistributionOrderNumber;

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L3DO_SDO_1801 Invoke(string ConnectionString, P_L3DO_SDO_1801 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L3DO_SDO_1801 Invoke(DbConnection Connection, P_L3DO_SDO_1801 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L3DO_SDO_1801 Invoke(DbConnection Connection, DbTransaction Transaction, P_L3DO_SDO_1801 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L3DO_SDO_1801 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L3DO_SDO_1801 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L3DO_SDO_1801 functionReturn = new FR_L3DO_SDO_1801();
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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
                    if (cleanupTransaction == true && Transaction != null)
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

                throw new Exception("Exception occured in method cls_Save_DistributionOrder", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L3DO_SDO_1801 : FR_Base
    {
        public L3DO_SDO_1801 Result { get; set; }

        public FR_L3DO_SDO_1801() : base() { }

        public FR_L3DO_SDO_1801(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_L3DO_SDO_1801 for attribute P_L3DO_SDO_1801
    [DataContract]
    public class P_L3DO_SDO_1801
    {
        [DataMember]
        public P_L3DO_SDO_1801a UniversalContactDetails { get; set; }
        [DataMember]
        public P_L3DO_SDO_1801b[] Documents { get; set; }
        [DataMember]
        public P_L3DO_SDO_1801c[] DistributionOrderPositions { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid DistributionOrderID { get; set; }
        [DataMember]
        public bool IsCostCenterOrder { get; set; }
        [DataMember]
        public Guid IsCostCenterOrderRefID { get; set; }
        [DataMember]
        public bool IsForPickup { get; set; }
        [DataMember]
        public Guid IsForPickupPointOfSaleRefID { get; set; }
        [DataMember]
        public bool IsForDelivery { get; set; }
        [DataMember]
        public Guid IsForDeliveryShipmentTypeRefID { get; set; }
        [DataMember]
        public Guid IsForDeliveryLogisticProviderRefID { get; set; }
        [DataMember]
        public Guid CurrencyID { get; set; }

    }
    #endregion
    #region SClass P_L3DO_SDO_1801a for attribute UniversalContactDetails
    [DataContract]
    public class P_L3DO_SDO_1801a
    {
        //Standard type parameters
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string POBox { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public string StreetNumber { get; set; }
        [DataMember]
        public string StreetName { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public string Town { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string CountryIso { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }

    }
    #endregion
    #region SClass P_L3DO_SDO_1801b for attribute Documents
    [DataContract]
    public class P_L3DO_SDO_1801b
    {
        //Standard type parameters
        [DataMember]
        public Guid DocumentID { get; set; }
        [DataMember]
        public string Alias { get; set; }
        [DataMember]
        public string PrimaryType { get; set; }

    }
    #endregion
    #region SClass P_L3DO_SDO_1801c for attribute DistributionOrderPositions
    [DataContract]
    public class P_L3DO_SDO_1801c
    {
        [DataMember]
        public P_L3DO_SDO_1801d[] DistributionOrderPositionCustomizations { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid ProductID { get; set; }
        [DataMember]
        public Guid ProductVariantID { get; set; }
        [DataMember]
        public float Quantity { get; set; }
        [DataMember]
        public decimal PriceValue { get; set; }
        [DataMember]
        public decimal PriceValueTotal { get; set; }

    }
    #endregion
    #region SClass P_L3DO_SDO_1801d for attribute DistributionOrderPositionCustomizations
    [DataContract]
    public class P_L3DO_SDO_1801d
    {
        //Standard type parameters
        [DataMember]
        public Guid DistributionOrderPositionCustomizationID { get; set; }
        [DataMember]
        public Guid DistributionOrderPositionID { get; set; }
        [DataMember]
        public string CustomizationName { get; set; }
        [DataMember]
        public string CustomizationVariantName { get; set; }
        [DataMember]
        public double ValuePerUnit { get; set; }
        [DataMember]
        public double ValueTotal { get; set; }
        [DataMember]
        public Guid CustomizationID { get; set; }
        [DataMember]
        public Guid CustomizationVariantID { get; set; }

    }
    #endregion
    #region SClass L3DO_SDO_1801 for attribute L3DO_SDO_1801
    [DataContract]
    public class L3DO_SDO_1801
    {
        //Standard type parameters
        [DataMember]
        public Guid DistributionOrderHeaderID { get; set; }
        [DataMember]
        public string DistributionOrderNumber { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DO_SDO_1801 cls_Save_DistributionOrder(,P_L3DO_SDO_1801 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DO_SDO_1801 invocationResult = cls_Save_DistributionOrder.Invoke(connectionString,P_L3DO_SDO_1801 Parameter,securityTicket);
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
var parameter = new CL3_DistributionOrder.Complex.Manipulation.P_L3DO_SDO_1801();
parameter.UniversalContactDetails = ...;
parameter.Documents = ...;
parameter.DistributionOrderPositions = ...;

parameter.DistributionOrderID = ...;
parameter.IsCostCenterOrder = ...;
parameter.IsCostCenterOrderRefID = ...;
parameter.IsForPickup = ...;
parameter.IsForPickupPointOfSaleRefID = ...;
parameter.IsForDelivery = ...;
parameter.IsForDeliveryShipmentTypeRefID = ...;
parameter.IsForDeliveryLogisticProviderRefID = ...;
parameter.CurrencyID = ...;

*/
