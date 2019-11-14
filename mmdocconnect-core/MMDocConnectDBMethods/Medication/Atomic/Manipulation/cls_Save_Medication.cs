/* 
 * Generated on 1.10.2015 11:35:51
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
using CL1_HEC;
using CL1_HEC_CTR;
using CL2_Language.Atomic.Retrieval;
using CL1_CMN_PRO;

namespace MMDocConnectDBMethods.Medication.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Medication.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Medication
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MC_SM_1132 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            //save new medication 
            if (Parameter.MedicationID == Guid.Empty)
            {
                var hecProducts = new ORM_HEC_Product();
                hecProducts.IsDeleted = false;
                hecProducts.Tenant_RefID = securityTicket.TenantID;
                hecProducts.Creation_Timestamp = DateTime.Now;
                hecProducts.Modification_Timestamp = DateTime.Now;
                hecProducts.Ext_PRO_Product_RefID = Guid.NewGuid();
                hecProducts.Save(Connection, Transaction);

                var DBLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result.ToList();
                Dict ProductNameDict = new Dict(ORM_CMN_PRO_Product.TableName);
                for (int i = 0; i < DBLanguages.Count; i++)
                {
                    ProductNameDict.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.Medication);
                }

                var products = new ORM_CMN_PRO_Product();
                products.CMN_PRO_ProductID = hecProducts.Ext_PRO_Product_RefID;
                products.IsDeleted = false;
                products.Tenant_RefID = securityTicket.TenantID;
                products.Creation_Timestamp = DateTime.Now;
                products.Product_Name = ProductNameDict;
                products.IsProducable_Internally = Parameter.ProprietaryDrug;
                products.Product_Number = Parameter.PZNScheme;
                products.Save(Connection, Transaction);

                //dosage and unit!!! 
            }
            else
            {
                //edit medication

                var medication = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_PRO_ProductID = Parameter.MedicationID
                }).SingleOrDefault();
                if (medication != null)
                {

                    
                var DBLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result.ToList();
                Dict ProductNameDict = new Dict(ORM_CMN_PRO_Product.TableName);
                for (int i = 0; i < DBLanguages.Count; i++)
                {
                    ProductNameDict.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.Medication);
                }

                    medication.Modification_Timestamp = DateTime.Now;
                    medication.Product_Name = ProductNameDict;
                    medication.IsProducable_Internally = Parameter.ProprietaryDrug;
                    medication.Product_Number = Parameter.PZNScheme;
                    medication.Save(Connection, Transaction);
                
                }
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_MC_SM_1132 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MC_SM_1132 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MC_SM_1132 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MC_SM_1132 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Medication", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MC_SM_1132 for attribute P_MC_SM_1132
    [DataContract]
    public class P_MC_SM_1132
    {
        //Standard type parameters
        [DataMember]
        public Guid MedicationID { get; set; }
        [DataMember]
        public string Medication { get; set; }
        [DataMember]
        public bool ProprietaryDrug { get; set; }
        [DataMember]
        public string PZNScheme { get; set; }
        [DataMember]
        public int Dosage { get; set; }
        [DataMember]
        public string Unit { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Medication(,P_MC_SM_1132 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Medication.Invoke(connectionString,P_MC_SM_1132 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Medication.Atomic.Manipulation.P_MC_SM_1132();
parameter.MedicationID = ...;
parameter.Medication = ...;
parameter.ProprietaryDrug = ...;
parameter.PZNScheme = ...;
parameter.Dosage = ...;
parameter.Unit = ...;

*/
