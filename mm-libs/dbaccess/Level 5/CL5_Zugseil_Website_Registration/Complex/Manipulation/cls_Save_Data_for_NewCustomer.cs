/* 
 * Generated on 3/10/2015 1:08:41 PM
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
using CL2_Office.Atomic.Manipulation;
using CL2_CostCenter.Complex.Manipulation;
using CL2_Warehouse.Complex.Manipulation;
using CL1_USR;
using CL1_CMN_BPT;
using CL2_Language.Atomic.Retrieval;
using CL1_CMN;
using CL1_CMN_PRO;
using Newtonsoft.Json;
using DLCore_DBCommons.Zugseil.DBUpdater;
using CL1_LOG_SHP;
using DLCore_DBCommons.Zugseil.DBUpdater.Model;
using CL1_LOG_WRH;
using DLCore_DBCommons;
using CL1_ORD_CUO;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.Zugseil;
using CL1_ORD_PRC;

namespace CL5_Zugseil_Website_Registration.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Data_for_NewCustomer.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Data_for_NewCustomer
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5ZW_SDfNC_1707 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Bool();
            returnValue.Result = false;

            //Put your code here
            #region get securityTicket and businessParticipantID by Paramter.AccountID and set defaultLanguageID
            Guid tenantID;
            Guid businessParticipantID;

            if (Parameter.AccountID == Guid.Empty)
                return returnValue;

            ORM_USR_Account orm_account = new ORM_USR_Account();
            var result = orm_account.Load(Connection, Transaction, Parameter.AccountID);
            if (result.Status != FR_Status.Success || orm_account.USR_AccountID == Guid.Empty)
                return returnValue;

            tenantID = orm_account.Tenant_RefID;
            securityTicket = new CSV2Core.SessionSecurity.SessionSecurityTicket()
            {
                TenantID = tenantID
            };

            ORM_CMN_BPT_BusinessParticipant.Query businessParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
            businessParticipantQuery.IfTenant_Tenant_RefID = tenantID;
            businessParticipantQuery.IsDeleted = false;
            ORM_CMN_BPT_BusinessParticipant businessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQuery).FirstOrDefault();

            if (businessParticipant == null)
                return returnValue;

            businessParticipantID = businessParticipant.CMN_BPT_BusinessParticipantID;
            #endregion

            #region get languages for tenant and set parameter dict values
            P_L2LN_GALFTID_1530 languageParam = new P_L2LN_GALFTID_1530()
            {
                Tenant_RefID = tenantID
            };
            L2LN_GALFTID_1530[] languages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, languageParam, securityTicket).Result;
            SetParameterDictValues(Parameter, languages);

            List<ISOLanguage> languagesISOs = new List<ISOLanguage>();
            languagesISOs.AddRange(languages.Select(l => new ISOLanguage()
            {
                ISO = l.ISO_639_1,
                LanguageID = l.CMN_LanguageID
            }).ToList());
            #endregion

            #region save defaultLanguage

            // We are setting language for bp and acc
            var defaultLanguage = languages.FirstOrDefault(i => i.ISO_639_1.ToLower().Contains(Parameter.DefaultLanguageCode.ToLower()));
            if (defaultLanguage != null)
            {
                businessParticipant.DefaultLanguage_RefID = defaultLanguage.CMN_LanguageID;
                businessParticipant.Save(Connection, Transaction);

                orm_account.DefaultLanguage_RefID = defaultLanguage.CMN_LanguageID;
                orm_account.Save(Connection, Transaction);
            }

            #endregion

            #region save default country

            if (Parameter.DefaultCountry != null)
            {
                ORM_CMN_Country country = new ORM_CMN_Country();
                country.CMN_CountryID = Guid.NewGuid();
                country.Country_ISOCode_Alpha3 = Parameter.DefaultCountry.Code;
                country.Country_Name = new Dict() { DictionaryID = Guid.NewGuid() };
                country.Creation_Timestamp = DateTime.Now;
                country.Default_Currency_RefID = Guid.Empty;
                country.Default_Language_RefID = Guid.Empty;
                country.Tenant_RefID = tenantID;
                country.IsDeleted = false;
                country.IsDefault = true;

                foreach (var languageItem in languages)
                {
                    country.Country_Name.UpdateEntry(languageItem.CMN_LanguageID, Parameter.DefaultCountry.Name);
                }

                country.Save(Connection, Transaction);

            }

            #endregion

            #region save default currency
            
            //asign currency
            if(Parameter.DefaultCurrency != null)
            {
                ORM_CMN_Currency currency = new ORM_CMN_Currency();
                currency.CMN_CurrencyID = Guid.NewGuid();
                currency.Creation_Timestamp = DateTime.Now;
                currency.IsDeleted = false;
                currency.ISO4127 = Parameter.DefaultCurrency.Code;
                currency.Name = new Dict() { DictionaryID = Guid.NewGuid() };
                currency.Tenant_RefID = tenantID;

                foreach (var language in languages)
                {
                    currency.Name.UpdateEntry(language.CMN_LanguageID, Parameter.DefaultCurrency.Name);
                }

                currency.Save(Connection, Transaction);

                //set default currency
                ORM_CMN_BPT_BusinessParticipant businessPart = new ORM_CMN_BPT_BusinessParticipant();
                businessPart.Load(Connection, Transaction, businessParticipantID);

                businessPart.DefaultCurrency_RefID = currency.CMN_CurrencyID;
                businessPart.Save(Connection, Transaction);
            }

            #endregion

            #region save organisational units
            if (Parameter.OrganisationalUnitParameters.Length > 0)
            {
                foreach (var item in Parameter.OrganisationalUnitParameters)
                    cls_Save_Office.Invoke(Connection, Transaction, item, securityTicket);
            }
            #endregion

            #region save cost centers
            if (Parameter.CostCenterParameters.Length > 0)
            {
                foreach (var item in Parameter.CostCenterParameters)
                    cls_Save_CostCenter.Invoke(Connection, Transaction, item, securityTicket);
            }
            #endregion

            #region save warehouses
            if (Parameter.WarehousesParameters.Length > 0)
            {
                #region save warehouse group
                P_L2WH_SWHG_1327 warehouseGroupParam = new P_L2WH_SWHG_1327();
                warehouseGroupParam.Parent_RefID = Guid.Empty;
                warehouseGroupParam.WarehouseGroup_Name = "Waregouse group";
                warehouseGroupParam.WarehouseGroup_Description = new Dict() { DictionaryID = Guid.NewGuid() };
                foreach (var language in languages)
                {
                    warehouseGroupParam.WarehouseGroup_Description.UpdateEntry(language.CMN_LanguageID, String.Empty);
                }

                var warehouseGroupID = cls_Save_Warehouse_Group.Invoke(Connection, Transaction, warehouseGroupParam, securityTicket).Result;
                #endregion

                foreach (var item in Parameter.WarehousesParameters)
                {
                    item.LOG_WRH_WarehouseGroupID = warehouseGroupID;
                    cls_Save_Warehouse.Invoke(Connection, Transaction, item, securityTicket);
                }
            }
            #endregion

            #region create dimension templates
            string jsonTemplates = ReadFromFile.LoadContentFromFile(@"Dimensions.json");
            List<Dimension> dimensionTemplates = JsonConvert.DeserializeObject<List<Dimension>>(jsonTemplates);

            int orderSequence = 1;
            ORM_CMN_PRO_Dimension orm_dimension;
            ORM_CMN_PRO_Dimension_Value orm_dimensionValue;
            foreach (var template in dimensionTemplates)
            {
                orderSequence = 1;

                #region save dimension
                orm_dimension = new ORM_CMN_PRO_Dimension();
                orm_dimension.Product_RefID = Guid.Empty;
                orm_dimension.DimensionName = new Dict() { DictionaryID = Guid.NewGuid() };
                orm_dimension.IsDimensionTemplate = true;
                orm_dimension.Tenant_RefID = tenantID;

                foreach (var language in languages)
                {
                    orm_dimension.DimensionName.UpdateEntry(language.CMN_LanguageID, template.Name);
                }

                orm_dimension.Save(Connection, Transaction);
                #endregion

                #region save dimension values
                foreach (var templateValue in template.DimansionValues)
                {
                    orm_dimensionValue = new ORM_CMN_PRO_Dimension_Value();
                    orm_dimensionValue.Dimensions_RefID = orm_dimension.CMN_PRO_DimensionID;
                    orm_dimensionValue.DimensionValue_Text = new Dict() { DictionaryID = Guid.NewGuid() };
                    orm_dimensionValue.Tenant_RefID = tenantID;
                    orm_dimensionValue.OrderSequence = orderSequence;

                    foreach (var language in languages)
                    {
                        orm_dimensionValue.DimensionValue_Text.UpdateEntry(language.CMN_LanguageID, templateValue);
                    }

                    orm_dimensionValue.Save(Connection, Transaction);

                    orderSequence++;
                }
                #endregion
            }
            #endregion

            #region create shipment types
            string shipmentTypesJson = ReadFromFile.LoadContentFromFile(@"ShipmentTypes.json");
            List<ShipmentTypes> shipmentTypes = JsonConvert.DeserializeObject<List<ShipmentTypes>>(shipmentTypesJson);

            ORM_LOG_SHP_Shipment_Type orm_shipmentType;
            foreach (var type in shipmentTypes)
            {
                #region save LOG_SHP_Shipment_Type
                orm_shipmentType = new ORM_LOG_SHP_Shipment_Type();
                orm_shipmentType.ShipmentType_Name = new Dict() { DictionaryID = Guid.NewGuid() };
                orm_shipmentType.ShipmentType_Description = new Dict() { DictionaryID = Guid.NewGuid() };
                orm_shipmentType.Tenant_RefID = tenantID;

                foreach (var language in languages)
                {
                    orm_shipmentType.ShipmentType_Name.UpdateEntry(language.CMN_LanguageID, type.Name);
                    orm_shipmentType.ShipmentType_Description.UpdateEntry(language.CMN_LanguageID, string.Empty);
                }

                orm_shipmentType.Save(Connection, Transaction);
                #endregion
            }
            #endregion

            #region create number ranges

            string numberRangesJson = ReadFromFile.LoadContentFromFile(@"NumberRanges.json");
            NumberRange numberRanges = JsonConvert.DeserializeObject<NumberRange>(numberRangesJson);


            ORM_CMN_NumberRange_UsageArea numberRangeUsageArea;
            ORM_CMN_NumberRange orm_numberRanges;
            foreach (var item in numberRanges.NumberRanges)
            {

                if (Parameter.IsCustomerRegistration && item.Name == "Customer orders")
                    continue;

                if (!Parameter.IsCustomerRegistration && item.Name == "Distribution orders")
                    continue;

                if (!Parameter.IsCustomerRegistration && item.Name == "Procurement orders")
                    continue;

                numberRangeUsageArea = new ORM_CMN_NumberRange_UsageArea();
                numberRangeUsageArea.UsageArea_Name = new Dict() { DictionaryID = Guid.NewGuid() };
                numberRangeUsageArea.UsageArea_Description = new Dict() { DictionaryID = Guid.NewGuid() };
                foreach (var language in languages)
                {
                    numberRangeUsageArea.UsageArea_Name.UpdateEntry(language.CMN_LanguageID, item.Name);
                    numberRangeUsageArea.UsageArea_Description.UpdateEntry(language.CMN_LanguageID, string.Empty);

                }
                numberRangeUsageArea.Tenant_RefID = tenantID;
                numberRangeUsageArea.GlobalStaticMatchingID = item.GlobalStaticMatchingID;
                numberRangeUsageArea.Save(Connection, Transaction);

                orm_numberRanges = new ORM_CMN_NumberRange();
                orm_numberRanges.NumberRange_Name = item.Name;
                orm_numberRanges.Tenant_RefID = tenantID;
                orm_numberRanges.NumberRange_UsageArea_RefID = numberRangeUsageArea.CMN_NumberRange_UsageAreaID;
                orm_numberRanges.FixedPrefix = item.FixedPrefix;
                orm_numberRanges.Formatting_LeadingFillCharacter = item.FillCharacter;
                orm_numberRanges.Formatting_NumberLength = item.Length;
                orm_numberRanges.Value_Current = item.CurrentValue;
                orm_numberRanges.Value_Start = item.StartValue;
                orm_numberRanges.Value_End = item.EndValue;
                orm_numberRanges.Save(Connection, Transaction);

            }


            #endregion

            #region create inventory change reasons

            string inventoryChangeReasonsJson = ReadFromFile.LoadContentFromFile(@"InventoryChangeReasons.json");
            List<InventoryChangeReasons> inventoryChangeReasons = JsonConvert.DeserializeObject<List<InventoryChangeReasons>>(inventoryChangeReasonsJson);

            ORM_LOG_WRH_InventoryChangeReason orm_inventoryChangeReason;
            foreach (var reason in inventoryChangeReasons)
            {
                #region save inventory change reason

                orm_inventoryChangeReason = new ORM_LOG_WRH_InventoryChangeReason();
                orm_inventoryChangeReason.GlobalPropertyMatchingID = InventoryChangeReasons.InventoryChangeReasonGlobalPropertyMatchingID + "-" + reason.Name;
                orm_inventoryChangeReason.InventoryChange_Name = new Dict() { DictionaryID = Guid.NewGuid() };
                orm_inventoryChangeReason.InventoryChange_Description = new Dict() { DictionaryID = Guid.NewGuid() };
                orm_inventoryChangeReason.Tenant_RefID = tenantID;

                foreach (var language in languages)
                {
                    orm_inventoryChangeReason.InventoryChange_Name.UpdateEntry(language.CMN_LanguageID, reason.Name);
                    orm_inventoryChangeReason.InventoryChange_Description.UpdateEntry(language.CMN_LanguageID, string.Empty);
                }

                orm_inventoryChangeReason.Save(Connection, Transaction);

                #endregion
            }

            #endregion

            #region create shipment statuses
            var shipmentStatuses = Enum.GetValues(typeof(EShipmentStatus));

            var shipmentStatusDicts = EnumUtils.GetDictObjectsForStaticListData<EShipmentStatus>(
                        ResourceFilePath.ShipmentStatus, ORM_LOG_SHP_Shipment_Status.TableName, languagesISOs);

            var statusCodeCount = 1;
            ORM_LOG_SHP_Shipment_Status shipmentStatus;
            foreach (EShipmentStatus status in shipmentStatuses)
            {
                shipmentStatus = new ORM_LOG_SHP_Shipment_Status();
                shipmentStatus.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription((EShipmentStatus)status);
                shipmentStatus.Status_Code = statusCodeCount++;
                shipmentStatus.Status_Name = shipmentStatusDicts[EnumUtils.GetEnumDescription((EShipmentStatus)status)];
                shipmentStatus.Tenant_RefID = tenantID;

                shipmentStatus.Save(Connection, Transaction);
            }
            #endregion

            if (Parameter.IsCustomerRegistration)
            {
                #region create procurement order statuses
                var procurementStatuses = Enum.GetValues(typeof(EProcurementStatus));
                ORM_ORD_PRC_ProcurementOrder_Status procurementOrderStatus;
                foreach (EProcurementStatus status in procurementStatuses)
                {
                    procurementOrderStatus = new ORM_ORD_PRC_ProcurementOrder_Status();
                    procurementOrderStatus.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(status);
                    procurementOrderStatus.Tenant_RefID = tenantID;

                    procurementOrderStatus.Save(Connection, Transaction);
                }
                #endregion
            }
            else
            {
                #region create customer order statuses
                var customerOrderStatuses = Enum.GetValues(typeof(ECustomerOrderStatus));
                
                var customerOrderStatusesDicts = EnumUtils.GetDictObjectsForStaticListData<ECustomerOrderStatus>(
                        ResourceFilePath.CustomerOrderStatus, ORM_ORD_CUO_CustomerOrder_Status.TableName, languagesISOs);

                var count = 1;
                ORM_ORD_CUO_CustomerOrder_Status customerOrderStatus;
                foreach (var status in customerOrderStatuses)
                {
                    customerOrderStatus = new ORM_ORD_CUO_CustomerOrder_Status();
                    customerOrderStatus.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription((ECustomerOrderStatus)status);
                    customerOrderStatus.Status_Code = count++;
                    customerOrderStatus.Status_Name = customerOrderStatusesDicts[EnumUtils.GetEnumDescription((ECustomerOrderStatus)status)];
                    customerOrderStatus.Tenant_RefID = tenantID;

                    customerOrderStatus.Save(Connection, Transaction);
                }
                #endregion
            }

            returnValue.Result = true;
            return returnValue;

            #endregion UserCode
		}
		#endregion

        #region Support Methods
        private static void SetParameterDictValues(P_L5ZW_SDfNC_1707 parameter, L2LN_GALFTID_1530[] languages)
        {
            string tempContentName = String.Empty;
            string tempContentDescription = String.Empty;

            #region set content for organisational units
            if (parameter.OrganisationalUnitParameters.Count() > 0)
            {
                foreach (var item in parameter.OrganisationalUnitParameters)
                {
                    tempContentName = (item.Office_Name.Contents.Count > 0) ?
                        item.Office_Name.Contents[0].Content :
                       string.Empty;
                    tempContentDescription = (item.Office_Description.Contents.Count > 0) ?
                        item.Office_Description.Contents[0].Content :
                        string.Empty;

                    item.Office_Name = new Dict() { DictionaryID = Guid.NewGuid() };
                    item.Office_InternalName = tempContentName;
                    item.Office_Description = new Dict() { DictionaryID = Guid.NewGuid() };
                    foreach (var languageItem in languages)
                    {
                        item.Office_Name.UpdateEntry(languageItem.CMN_LanguageID, tempContentName);
                        item.Office_Description.UpdateEntry(languageItem.CMN_LanguageID, tempContentDescription);
                    }
                }
            }
            #endregion

            #region set content for cost centers
            if (parameter.CostCenterParameters.Count() > 0)
            {
                foreach (var item in parameter.CostCenterParameters)
                {
                    tempContentName = (item.Name.Contents.Count > 0) ?
                        item.Name.Contents[0].Content :
                        string.Empty;
                    tempContentDescription = (item.Description.Contents.Count > 0) ?
                         item.Description.Contents[0].Content :
                         string.Empty;

                    item.Name = new Dict() { DictionaryID = Guid.NewGuid() };
                    item.Description = new Dict() { DictionaryID = Guid.NewGuid() };
                    foreach (var languageItem in languages)
                    {
                        item.Name.UpdateEntry(languageItem.CMN_LanguageID, tempContentName);
                        item.Description.UpdateEntry(languageItem.CMN_LanguageID, tempContentDescription);
                    }
                }
            }
            #endregion

        }
        #endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5ZW_SDfNC_1707 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5ZW_SDfNC_1707 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ZW_SDfNC_1707 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ZW_SDfNC_1707 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Data_for_NewCustomer",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ZW_SDfNC_1707 for attribute P_L5ZW_SDfNC_1707
		[DataContract]
		public class P_L5ZW_SDfNC_1707 
		{
			[DataMember]
			public P_L5ZW_SDfNC_1707_Country DefaultCountry { get; set; }
			[DataMember]
			public P_L5ZW_SDfNC_1707_Currency DefaultCurrency { get; set; }

			//Standard type parameters
			[DataMember]
			public P_L2O_SO_1529[] OrganisationalUnitParameters { get; set; } 
			[DataMember]
			public P_L2CC_SCC_1356[] CostCenterParameters { get; set; } 
			[DataMember]
			public P_L2WH_SWH_1339[] WarehousesParameters { get; set; } 
			[DataMember]
			public Guid AccountID { get; set; } 
			[DataMember]
			public String DefaultLanguageCode { get; set; } 
			[DataMember]
			public Boolean IsCustomerRegistration { get; set; } 

		}
		#endregion
		#region SClass P_L5ZW_SDfNC_1707_Country for attribute DefaultCountry
		[DataContract]
		public class P_L5ZW_SDfNC_1707_Country 
		{
			//Standard type parameters
			[DataMember]
			public String Code { get; set; } 
			[DataMember]
			public String Name { get; set; } 

		}
		#endregion
		#region SClass P_L5ZW_SDfNC_1707_Currency for attribute DefaultCurrency
		[DataContract]
		public class P_L5ZW_SDfNC_1707_Currency 
		{
			//Standard type parameters
			[DataMember]
			public String Code { get; set; } 
			[DataMember]
			public String Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_Data_for_NewCustomer(,P_L5ZW_SDfNC_1707 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_Data_for_NewCustomer.Invoke(connectionString,P_L5ZW_SDfNC_1707 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Website_Registration.Complex.Manipulation.P_L5ZW_SDfNC_1707();
parameter.DefaultCountry = ...;
parameter.DefaultCurrency = ...;

parameter.OrganisationalUnitParameters = ...;
parameter.CostCenterParameters = ...;
parameter.WarehousesParameters = ...;
parameter.AccountID = ...;
parameter.DefaultLanguageCode = ...;
parameter.IsCustomerRegistration = ...;

*/
