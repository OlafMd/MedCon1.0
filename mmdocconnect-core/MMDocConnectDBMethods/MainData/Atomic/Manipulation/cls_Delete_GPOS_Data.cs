/* 
 * Generated on 10/21/15 10:36:38
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
using CL1_HEC_BIL;
using CL1_CMN;
using CL1_HEC_CTR;
using CL1_HEC_CTR_I2BC;

namespace MMDocConnectDBMethods.MainData.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Delete_GPOS_Data.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Delete_GPOS_Data
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MD_DGPOSD_1033 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var gpos = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode.Query()
            {
                HEC_BIL_PotentialCodeID = Parameter.GposID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (gpos != null)
            {
                gpos.IsDeleted = true;
                gpos.Modification_Timestamp = DateTime.Now;

                gpos.Save(Connection, Transaction);

                #region PRICE
                var price = ORM_CMN_Price.Query.Search(Connection, Transaction, new ORM_CMN_Price.Query()
                {
                    CMN_PriceID = gpos.Price_RefID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (price != null)
                {
                    price.IsDeleted = true;
                    price.Save(Connection, Transaction);

                    var priceValue = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, new ORM_CMN_Price_Value.Query()
                    {
                        Price_RefID = gpos.Price_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).SingleOrDefault();

                    if (priceValue != null)
                    {
                        priceValue.IsDeleted = true;
                        priceValue.Save(Connection, Transaction);
                    }
                }
                #endregion PRICE

                #region CONTRACT CONNECTION
                var coveredPotentialCode = ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCode.Query.Search(Connection, Transaction, new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCode.Query()
                {
                    PotentialBillCode_RefID = Parameter.GposID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).SingleOrDefault();

                if (coveredPotentialCode != null)
                {
                    coveredPotentialCode.IsDeleted = true;
                    coveredPotentialCode.Save(Connection, Transaction);
                }
                #endregion CONTRACT CONNECTION

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
                        gposProperty.IsDeleted = true;
                        gposProperty.Modification_Timestamp = DateTime.Now;

                        gposProperty.Save(Connection, Transaction);
                    }

                    conn.IsDeleted = true;
                    conn.Modification_Timestamp = DateTime.Now;

                    conn.Save(Connection, Transaction);
                }

                #endregion POTENTIAL CODE PROPERTIES

                #region CONNECTED DRUGS
                var gposDrugConnections = ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                {
                    HEC_BIL_PotentialCode_RefID = Parameter.GposID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

                foreach (var conn in gposDrugConnections)
                {
                    conn.IsDeleted = true;
                    conn.Modification_Timestamp = DateTime.Now;

                    conn.Save(Connection, Transaction);
                }
                #endregion CONNECTED DRUGS

                #region CONNECTED DIAGNOSES
                var gposDiagnoseConnections = ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query()
                {
                    HEC_BIL_PotentialCode_RefID = Parameter.GposID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

                foreach (var conn in gposDiagnoseConnections)
                {
                    conn.IsDeleted = true;
                    conn.Modification_Timestamp = DateTime.Now;

                    conn.Save(Connection, Transaction);
                }
                #endregion CONNECTED DIAGNOSES
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_MD_DGPOSD_1033 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MD_DGPOSD_1033 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_DGPOSD_1033 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_DGPOSD_1033 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Delete_GPOS_Data", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_DGPOSD_1033 for attribute P_MD_DGPOSD_1033
    [DataContract]
    public class P_MD_DGPOSD_1033
    {
        //Standard type parameters
        [DataMember]
        public Guid GposID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_GPOS_Data(,P_MD_DGPOSD_1033 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_GPOS_Data.Invoke(connectionString,P_MD_DGPOSD_1033 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Manipulation.P_MD_DGPOSD_1033();
parameter.GposID = ...;

*/
