/* 
 * Generated on 10/27/15 14:12:30
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
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using CL1_HEC_DIA;
using CL2_Language.Atomic.Retrieval;

namespace MMDocConnectDBMethods.MainData.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_New_Diagnoses_and_Return_New_IDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_New_Diagnoses_and_Return_New_IDs
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guids Execute(DbConnection Connection, DbTransaction Transaction, P_MD_SNDaRNIDs_1412[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guids();
            var allLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            returnValue.Result = Parameter.Select(diag =>
            {
                var diagnose = cls_Get_DiagnoseID_for_ICD10_and_DiagnoseName.Invoke(Connection, Transaction, new P_MD_GDIDfDN_1408()
                {
                    DiagnoseICD10 = diag.DiagnoseICD10,
                    DiagnoseNameWithoutSpaces = diag.DiagnoseName.Replace(((char)32).ToString(), string.Empty).Replace(((char)160).ToString(), string.Empty)
                }, securityTicket).Result;

                if (diagnose != null)
                {
                    return diagnose.DiagnoseID;
                }
                else
                {
                    Dict DiagnoseName = new Dict(ORM_HEC_DIA_PotentialDiagnosis.TableName);
                    for (int i = 0; i < allLanguages.Count; i++)
                    {
                        DiagnoseName.AddEntry(allLanguages[i].CMN_LanguageID, diag.DiagnoseName);
                    }

                    Dict CatalogName = new Dict(ORM_HEC_DIA_PotentialDiagnosis_Catalog.TableName);
                    for (int i = 0; i < allLanguages.Count; i++)
                    {
                        CatalogName.AddEntry(allLanguages[i].CMN_LanguageID, "ICD-10");
                    }

                    var newDiagnose = new ORM_HEC_DIA_PotentialDiagnosis();
                    newDiagnose.PotentialDiagnosis_Name = DiagnoseName;
                    newDiagnose.IsDeleted = false;
                    newDiagnose.Tenant_RefID = securityTicket.TenantID;
                    newDiagnose.Creation_Timestamp = DateTime.Now;
                    newDiagnose.Modification_Timestamp = DateTime.Now;
                    newDiagnose.HEC_DIA_PotentialDiagnosisID = Guid.NewGuid();

                    newDiagnose.Save(Connection, Transaction);

                    var newDiagnoseCatalog = new ORM_HEC_DIA_PotentialDiagnosis_Catalog();
                    newDiagnoseCatalog.IsDeleted = false;
                    newDiagnoseCatalog.Catalog_DisplayName = "ICD-10";
                    newDiagnoseCatalog.Tenant_RefID = securityTicket.TenantID;
                    newDiagnoseCatalog.Creation_Timestamp = DateTime.Now;
                    newDiagnoseCatalog.Modification_Timestamp = DateTime.Now;
                    newDiagnoseCatalog.HEC_DIA_PotentialDiagnosis_CatalogID = Guid.NewGuid();
                    newDiagnoseCatalog.Catalog_Name = CatalogName;

                    newDiagnoseCatalog.Save(Connection, Transaction);

                    var newDiagnose2CatalogCode = new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode();
                    newDiagnose2CatalogCode.IsDeleted = false;
                    newDiagnose2CatalogCode.Tenant_RefID = securityTicket.TenantID;
                    newDiagnose2CatalogCode.Creation_Timestamp = DateTime.Now;
                    newDiagnose2CatalogCode.Modification_Timestamp = DateTime.Now;
                    newDiagnose2CatalogCode.PotentialDiagnosis_RefID = newDiagnose.HEC_DIA_PotentialDiagnosisID;
                    newDiagnose2CatalogCode.PotentialDiagnosis_Catalog_RefID = newDiagnoseCatalog.HEC_DIA_PotentialDiagnosis_CatalogID;
                    newDiagnose2CatalogCode.Code = diag.DiagnoseICD10;

                    newDiagnose2CatalogCode.Save(Connection, Transaction);

                    return newDiagnose.HEC_DIA_PotentialDiagnosisID;
                }
            }).ToArray();

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guids Invoke(string ConnectionString, P_MD_SNDaRNIDs_1412[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, P_MD_SNDaRNIDs_1412[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_SNDaRNIDs_1412[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_SNDaRNIDs_1412[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guids functionReturn = new FR_Guids();
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

                throw new Exception("Exception occured in method cls_Save_New_Diagnoses_and_Return_New_IDs", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_SNDaRNIDs_1412 for attribute P_MD_SNDaRNIDs_1412
    [DataContract]
    public class P_MD_SNDaRNIDs_1412
    {
        //Standard type parameters
        [DataMember]
        public String DiagnoseICD10 { get; set; }
        [DataMember]
        public String DiagnoseName { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_New_Diagnoses_and_Return_New_IDs(,P_MD_SNDaRNIDs_1412[] Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_New_Diagnoses_and_Return_New_IDs.Invoke(connectionString,P_MD_SNDaRNIDs_1412[] Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Manipulation.P_MD_SNDaRNIDs_1412[]();
parameter.DiagnoseICD10 = ...;
parameter.DiagnoseName = ...;

*/
