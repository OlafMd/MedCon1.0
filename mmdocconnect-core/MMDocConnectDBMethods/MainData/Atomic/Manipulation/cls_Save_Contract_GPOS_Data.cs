/* 
 * Generated on 10/20/15 16:01:57
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
using CL1_HEC_BIL;
using CL1_HEC_CRT;
using CL1_HEC_CTR;
using CL1_HEC_CTR_I2BC;

namespace MMDocConnectDBMethods.MainData.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Contract_GPOS_Data.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Contract_GPOS_Data
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MD_SCGPOSD_1306 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            var insuranceToBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
            {
                Ext_CMN_CTR_Contract_RefID = Parameter.ContractID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (insuranceToBrokerContract == null)
            {
                insuranceToBrokerContract = new ORM_HEC_CRT_InsuranceToBrokerContract();
                insuranceToBrokerContract.Creation_Timestamp = DateTime.Now;
                insuranceToBrokerContract.Ext_CMN_CTR_Contract_RefID = Parameter.ContractID;
                insuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID = Guid.NewGuid();
                insuranceToBrokerContract.Modification_Timestamp = DateTime.Now;
                insuranceToBrokerContract.Tenant_RefID = securityTicket.TenantID;

                insuranceToBrokerContract.Save(Connection, Transaction);
            }

            var allLanguages = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray();

            var currency = ORM_CMN_Currency.Query.Search(Connection, Transaction, new ORM_CMN_Currency.Query() { ISO4127 = "EUR", IsDeleted = false, Symbol = "EUR", Tenant_RefID = securityTicket.TenantID }).Single();

            #region DELETE DISCONNECTED GPOS-ES
            var currentGposesConnectedToContract = ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCode.Query.Search(Connection, Transaction, new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCode.Query()
            {
                InsuranceToBrokerContract_RefID = insuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            });
            var gposIDs = Parameter.GposData.Select(gpos => gpos.GposID).ToArray();

            foreach (var currGpos in currentGposesConnectedToContract)
            {
                var exists = gposIDs.Any(id => currGpos.PotentialBillCode_RefID == id);
                if (!gposIDs.Any(id => id == currGpos.PotentialBillCode_RefID))
                {
                    cls_Delete_GPOS_Data.Invoke(Connection, Transaction, new P_MD_DGPOSD_1033() { GposID = currGpos.PotentialBillCode_RefID }, securityTicket);
                }

            }
            #endregion DELETE DISCONNECTED GPOS-ES

            foreach (var gpos in Parameter.GposData)
            {
                #region NEW GPOS DATA
                if (gpos.GposID == Guid.Empty)
                {
                    #region GPOS CATALOG
                    var catalog = ORM_HEC_BIL_PotentialCode_Catalog.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_Catalog.Query()
                    {
                        GlobalPropertyMatchingID = gpos.GposType,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).SingleOrDefault();

                    if (catalog == null)
                    {
                        catalog = new ORM_HEC_BIL_PotentialCode_Catalog();
                        var catalogNameDict = new Dict(ORM_HEC_BIL_PotentialCode_Catalog.TableName);
                        var catalogNameString = gpos.GposType.Replace("mm.docconnect.gpos.catalog.", "");
                        catalogNameString = catalogNameString.Substring(0, 1).ToUpper() + catalogNameString.Substring(1);
                        foreach (var lang in allLanguages)
                        {
                            catalogNameDict.AddEntry(lang.CMN_LanguageID, catalogNameString);
                        }
                        catalog.GlobalPropertyMatchingID = gpos.GposType;
                        catalog.Modification_Timestamp = DateTime.Now;
                        catalog.Tenant_RefID = securityTicket.TenantID;

                        catalog.Save(Connection, Transaction);
                    }
                    #endregion GPOS CATALOG

                    #region PRICE
                    var price = new ORM_CMN_Price();
                    price.CMN_PriceID = Guid.NewGuid();
                    price.Creation_Timestamp = DateTime.Now;
                    price.Tenant_RefID = securityTicket.TenantID;

                    price.Save(Connection, Transaction);

                    var priceValue = new ORM_CMN_Price_Value();
                    priceValue.CMN_Price_ValueID = Guid.NewGuid();
                    priceValue.Creation_Timestamp = DateTime.Now;
                    priceValue.Price_RefID = price.CMN_PriceID;
                    priceValue.PriceValue_Amount = gpos.FeeValue;
                    priceValue.PriceValue_Currency_RefID = currency.CMN_CurrencyID;
                    priceValue.Tenant_RefID = securityTicket.TenantID;

                    priceValue.Save(Connection, Transaction);
                    #endregion PRICE

                    #region POTENTIAL CODE
                    var newPotentialCode = new ORM_HEC_BIL_PotentialCode();

                    var potentialCodeName = new Dict(ORM_HEC_BIL_PotentialCode.TableName);
                    foreach (var lang in allLanguages)
                    {
                        potentialCodeName.AddEntry(lang.CMN_LanguageID, gpos.GposName);
                    }

                    newPotentialCode.CodeName = potentialCodeName;
                    newPotentialCode.Creation_Timestamp = DateTime.Now;
                    newPotentialCode.HEC_BIL_PotentialCodeID = Guid.NewGuid();
                    newPotentialCode.PotentialCode_Catalog_RefID = catalog.HEC_BIL_PotentialCode_CatalogID;
                    newPotentialCode.Modification_Timestamp = DateTime.Now;
                    newPotentialCode.Price_RefID = price.CMN_PriceID;
                    newPotentialCode.BillingCode = gpos.GposNumber;
                    newPotentialCode.Tenant_RefID = securityTicket.TenantID;

                    newPotentialCode.Save(Connection, Transaction);
                    #endregion POTENTIAL CODE

                    #region CONTRACT CONNECTION

                    var coveredPotentialCode = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCode();
                    coveredPotentialCode.Creation_Timestamp = DateTime.Now;
                    coveredPotentialCode.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID = Guid.NewGuid();
                    coveredPotentialCode.InsuranceToBrokerContract_RefID = insuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                    coveredPotentialCode.Modification_Timestamp = DateTime.Now;
                    coveredPotentialCode.PotentialBillCode_RefID = newPotentialCode.HEC_BIL_PotentialCodeID;
                    coveredPotentialCode.Tenant_RefID = securityTicket.TenantID;

                    coveredPotentialCode.Save(Connection, Transaction);

                    #endregion CONTRACT CONNECTION

                    #region POTENTIAL CODE PROPERTIES

                    #region FROM INJECTION
                    var fromInjectionProperty = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalProperty();
                    fromInjectionProperty.Creation_Timestamp = DateTime.Now;
                    fromInjectionProperty.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID = Guid.NewGuid();
                    fromInjectionProperty.IsValue_Number = true;
                    fromInjectionProperty.Modification_Timestamp = DateTime.Now;
                    fromInjectionProperty.PropertyName = "From injection no.";
                    fromInjectionProperty.Tenant_RefID = securityTicket.TenantID;

                    fromInjectionProperty.Save(Connection, Transaction);

                    var fromInjectionPropertyToCode = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_2_UniversalProperty();
                    fromInjectionPropertyToCode.Tenant_RefID = securityTicket.TenantID;
                    fromInjectionPropertyToCode.AssignmentID = Guid.NewGuid();
                    fromInjectionPropertyToCode.CoveredPotentialBillCode_RefID = coveredPotentialCode.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID;
                    fromInjectionPropertyToCode.CoveredPotentialBillCode_UniversalProperty_RefID = fromInjectionProperty.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID;
                    fromInjectionPropertyToCode.Creation_Timestamp = DateTime.Now;
                    fromInjectionPropertyToCode.Modification_Timestamp = DateTime.Now;
                    fromInjectionPropertyToCode.Value_Number = gpos.FromInjection == 0 || gpos.FromInjection == null ? int.MaxValue : gpos.FromInjection;

                    fromInjectionPropertyToCode.Save(Connection, Transaction);
                    #endregion FROM INJECTION

                    #region SERVICE FEE
                    var serviceFeeProperty = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalProperty();
                    serviceFeeProperty.Creation_Timestamp = DateTime.Now;
                    serviceFeeProperty.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID = Guid.NewGuid();
                    serviceFeeProperty.IsValue_String = true;
                    serviceFeeProperty.Modification_Timestamp = DateTime.Now;
                    serviceFeeProperty.PropertyName = "Service Fee in EUR";
                    serviceFeeProperty.Tenant_RefID = securityTicket.TenantID;

                    serviceFeeProperty.Save(Connection, Transaction);

                    var serviceFeePropertyToCode = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_2_UniversalProperty();
                    serviceFeePropertyToCode.Tenant_RefID = securityTicket.TenantID;
                    serviceFeePropertyToCode.AssignmentID = Guid.NewGuid();
                    serviceFeePropertyToCode.CoveredPotentialBillCode_RefID = coveredPotentialCode.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID;
                    serviceFeePropertyToCode.CoveredPotentialBillCode_UniversalProperty_RefID = serviceFeeProperty.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID;
                    serviceFeePropertyToCode.Creation_Timestamp = DateTime.Now;
                    serviceFeePropertyToCode.Modification_Timestamp = DateTime.Now;
                    serviceFeePropertyToCode.Value_String = string.IsNullOrEmpty(gpos.ManagementFeeValue) ? "-" : gpos.ManagementFeeValue;

                    serviceFeePropertyToCode.Save(Connection, Transaction);
                    #endregion SERVICE FEE

                    #region WAIVE WITH ORDER
                    var waiveWithOrderProperty = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalProperty();
                    waiveWithOrderProperty.Creation_Timestamp = DateTime.Now;
                    waiveWithOrderProperty.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID = Guid.NewGuid();
                    waiveWithOrderProperty.IsValue_Boolean = true;
                    waiveWithOrderProperty.Modification_Timestamp = DateTime.Now;
                    waiveWithOrderProperty.PropertyName = "Waive with order";
                    waiveWithOrderProperty.Tenant_RefID = securityTicket.TenantID;

                    waiveWithOrderProperty.Save(Connection, Transaction);

                    var waiveWithOrderPropertyToCode = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_2_UniversalProperty();
                    waiveWithOrderPropertyToCode.Tenant_RefID = securityTicket.TenantID;
                    waiveWithOrderPropertyToCode.AssignmentID = Guid.NewGuid();
                    waiveWithOrderPropertyToCode.CoveredPotentialBillCode_RefID = coveredPotentialCode.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID;
                    waiveWithOrderPropertyToCode.CoveredPotentialBillCode_UniversalProperty_RefID = waiveWithOrderProperty.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID;
                    waiveWithOrderPropertyToCode.Creation_Timestamp = DateTime.Now;
                    waiveWithOrderPropertyToCode.Modification_Timestamp = DateTime.Now;
                    waiveWithOrderPropertyToCode.Value_Boolean = gpos.WaiveServiceFeeWithOrder;

                    waiveWithOrderPropertyToCode.Save(Connection, Transaction);
                    #endregion WAIVE WITH ORDER

                    #endregion POTENTIAL CODE PROPERTIES

                    #region CONNECTED DRUGS
                    if (gpos.DrugIDs.Length != 0)
                    {
                        foreach (var drugID in gpos.DrugIDs)
                        {
                            var potentialCodeToDrug = new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct();
                            potentialCodeToDrug.AssignmentID = Guid.NewGuid();
                            potentialCodeToDrug.Creation_Timestamp = DateTime.Now;
                            potentialCodeToDrug.HEC_BIL_PotentialCode_RefID = newPotentialCode.HEC_BIL_PotentialCodeID;
                            potentialCodeToDrug.HEC_Product_RefID = drugID;
                            potentialCodeToDrug.Modification_Timestamp = DateTime.Now;
                            potentialCodeToDrug.Tenant_RefID = securityTicket.TenantID;

                            potentialCodeToDrug.Save(Connection, Transaction);
                        }
                    }
                    #endregion CONNECTED DRUGS

                    #region CONNECTED DIAGNOSES
                    if (gpos.DiagnoseIDs.Length != 0)
                    {
                        foreach (var diagnoseID in gpos.DiagnoseIDs)
                        {
                            var potentialCodeToDiagnose = new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis();
                            potentialCodeToDiagnose.AssignmentID = Guid.NewGuid();
                            potentialCodeToDiagnose.Creation_Timestamp = DateTime.Now;
                            potentialCodeToDiagnose.HEC_BIL_PotentialCode_RefID = newPotentialCode.HEC_BIL_PotentialCodeID;
                            potentialCodeToDiagnose.HEC_DIA_PotentialDiagnosis_RefID = diagnoseID;
                            potentialCodeToDiagnose.Modification_Timestamp = DateTime.Now;
                            potentialCodeToDiagnose.Tenant_RefID = securityTicket.TenantID;

                            potentialCodeToDiagnose.Save(Connection, Transaction);
                        }

                    }
                    #endregion CONNECTED DIAGNOSES
                }
                #endregion NEW GPOS DATA

                #region EDIT
                else
                {
                    var currentGpos = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode.Query()
                    {
                        HEC_BIL_PotentialCodeID = gpos.GposID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).SingleOrDefault();
                    if (currentGpos != null)
                    {
                        #region BASE DATA
                        var potentialCodeName = new Dict(ORM_HEC_BIL_PotentialCode.TableName);
                        foreach (var lang in allLanguages)
                        {
                            potentialCodeName.AddEntry(lang.CMN_LanguageID, gpos.GposName);
                        }
                        currentGpos.CodeName = potentialCodeName;
                        currentGpos.BillingCode = gpos.GposNumber;

                        var catalog = ORM_HEC_BIL_PotentialCode_Catalog.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_Catalog.Query()
                        {
                            GlobalPropertyMatchingID = gpos.GposType,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).SingleOrDefault();

                        if (catalog == null)
                        {
                            catalog = new ORM_HEC_BIL_PotentialCode_Catalog();
                            var catalogNameDict = new Dict(ORM_HEC_BIL_PotentialCode_Catalog.TableName);
                            var catalogNameString = gpos.GposType.Replace("mm.docconnect.gpos.catalog.", "");
                            catalogNameString = catalogNameString.Substring(0, 1).ToUpper() + catalogNameString.Substring(1);

                            foreach (var lang in allLanguages)
                            {
                                catalogNameDict.AddEntry(lang.CMN_LanguageID, catalogNameString);
                            }

                            catalog.GlobalPropertyMatchingID = gpos.GposType;
                            catalog.Modification_Timestamp = DateTime.Now;
                            catalog.Tenant_RefID = securityTicket.TenantID;

                            catalog.Save(Connection, Transaction);
                        }

                        currentGpos.PotentialCode_Catalog_RefID = catalog.HEC_BIL_PotentialCode_CatalogID;

                        currentGpos.Save(Connection, Transaction);
                        #endregion

                        #region PRICE
                        var currentPriceValue = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, new ORM_CMN_Price_Value.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            Price_RefID = currentGpos.Price_RefID
                        }).SingleOrDefault();

                        if (currentPriceValue != null)
                        {
                            currentPriceValue.PriceValue_Amount = gpos.FeeValue;
                            currentPriceValue.Save(Connection, Transaction);
                        }
                        #endregion

                        #region CONTRACT CONNECTION
                        var coveredPotentialCode = ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCode.Query.Search(Connection, Transaction, new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCode.Query()
                        {
                            PotentialBillCode_RefID = gpos.GposID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).SingleOrDefault();
                        #endregion

                        #region POTENTIAL CODE PROPERTIES
                        var gposPropertyConnections = ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_2_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_2_UniversalProperty.Query()
                        {
                            CoveredPotentialBillCode_RefID = coveredPotentialCode.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });

                        foreach (var conn in gposPropertyConnections)
                        {
                            var gposProperty = ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalProperty.Query()
                            {
                                HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID = conn.CoveredPotentialBillCode_UniversalProperty_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).SingleOrDefault();

                            if (gposProperty != null)
                            {
                                switch (gposProperty.PropertyName)
                                {
                                    case "From injection no.":
                                        conn.Value_Number = gpos.FromInjection;
                                        break;
                                    case "Waive with order":
                                        conn.Value_Boolean = gpos.WaiveServiceFeeWithOrder;
                                        break;
                                    case "Service Fee in EUR":
                                        conn.Value_String = gpos.ManagementFeeValue;
                                        break;
                                }

                                conn.Modification_Timestamp = DateTime.Now;
                                conn.Save(Connection, Transaction);
                            }
                        }

                        #endregion POTENTIAL CODE PROPERTIES

                        #region CONNECTED DRUGS
                        var currentGposDrugConnections = ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                        {
                            HEC_BIL_PotentialCode_RefID = gpos.GposID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });

                        foreach (var drugConnection in currentGposDrugConnections)
                        {
                            if (gpos.DrugIDs.Length == 0 || !gpos.DrugIDs.Any(did => did == drugConnection.HEC_Product_RefID))
                            {
                                drugConnection.IsDeleted = true;
                                drugConnection.Modification_Timestamp = DateTime.Now;

                                drugConnection.Save(Connection, Transaction);
                            }
                        }

                        foreach (var drugID in gpos.DrugIDs)
                        {
                            if (!currentGposDrugConnections.Any(cpd => cpd.HEC_Product_RefID == drugID))
                            {
                                var newDrugConnection = new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct();
                                newDrugConnection.AssignmentID = Guid.NewGuid();
                                newDrugConnection.Creation_Timestamp = DateTime.Now;
                                newDrugConnection.HEC_BIL_PotentialCode_RefID = gpos.GposID;
                                newDrugConnection.HEC_Product_RefID = drugID;
                                newDrugConnection.Modification_Timestamp = DateTime.Now;
                                newDrugConnection.Tenant_RefID = securityTicket.TenantID;

                                newDrugConnection.Save(Connection, Transaction);
                            }
                        }

                        #endregion CONNECTED DRUGS

                        #region CONNECTED DIAGNOSES
                        var currentGposDiagnoseConnections = ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query()
                        {
                            HEC_BIL_PotentialCode_RefID = gpos.GposID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });

                        foreach (var diagnoseConnection in currentGposDiagnoseConnections)
                        {
                            if (gpos.DiagnoseIDs.Length == 0 || !gpos.DiagnoseIDs.Any(did => did == diagnoseConnection.HEC_DIA_PotentialDiagnosis_RefID))
                            {
                                diagnoseConnection.IsDeleted = true;
                                diagnoseConnection.Modification_Timestamp = DateTime.Now;

                                diagnoseConnection.Save(Connection, Transaction);
                            }
                        }

                        foreach (var diagnoseID in gpos.DiagnoseIDs)
                        {
                            if (!currentGposDiagnoseConnections.Any(cpd => cpd.HEC_DIA_PotentialDiagnosis_RefID == diagnoseID))
                            {
                                var newDiagnoseConnection = new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis();
                                newDiagnoseConnection.AssignmentID = Guid.NewGuid();
                                newDiagnoseConnection.Creation_Timestamp = DateTime.Now;
                                newDiagnoseConnection.HEC_BIL_PotentialCode_RefID = gpos.GposID;
                                newDiagnoseConnection.HEC_DIA_PotentialDiagnosis_RefID = diagnoseID;
                                newDiagnoseConnection.Modification_Timestamp = DateTime.Now;
                                newDiagnoseConnection.Tenant_RefID = securityTicket.TenantID;

                                newDiagnoseConnection.Save(Connection, Transaction);
                            }
                        }
                        #endregion CONNECTED DIAGNOSES
                    }
                }
                #endregion EDIT
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_MD_SCGPOSD_1306 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MD_SCGPOSD_1306 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_SCGPOSD_1306 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_SCGPOSD_1306 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Contract_GPOS_Data", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_SCGPOSD_1306 for attribute P_MD_SCGPOSD_1306
    [DataContract]
    public class P_MD_SCGPOSD_1306
    {
        [DataMember]
        public P_MD_SCGPOSD_1306_Array[] GposData { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid ContractID { get; set; }

    }
    #endregion
    #region SClass P_MD_SCGPOSD_1306_Array for attribute GposData
    [DataContract]
    public class P_MD_SCGPOSD_1306_Array
    {
        //Standard type parameters
        [DataMember]
        public Guid GposID { get; set; }
        [DataMember]
        public String GposName { get; set; }
        [DataMember]
        public String GposNumber { get; set; }
        [DataMember]
        public String GposType { get; set; }
        [DataMember]
        public int FromInjection { get; set; }
        [DataMember]
        public Double FeeValue { get; set; }
        [DataMember]
        public String ManagementFeeValue { get; set; }
        [DataMember]
        public Boolean WaiveServiceFeeWithOrder { get; set; }
        [DataMember]
        public Guid[] DrugIDs { get; set; }
        [DataMember]
        public Guid[] DiagnoseIDs { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Contract_GPOS_Data(,P_MD_SCGPOSD_1306 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Contract_GPOS_Data.Invoke(connectionString,P_MD_SCGPOSD_1306 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Manipulation.P_MD_SCGPOSD_1306();
parameter.GposData = ...;

parameter.ContractID = ...;

*/
