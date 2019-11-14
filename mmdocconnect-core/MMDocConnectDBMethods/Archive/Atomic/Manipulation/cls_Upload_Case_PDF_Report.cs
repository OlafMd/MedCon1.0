/* 
 * Generated on 06/18/16 09:29:13
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
using System.Runtime.Serialization;
using CL1_DOC;
using CL1_HEC_CAS;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectUtils;

namespace MMDocConnectDBMethods.Archive.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Upload_Case_PDF_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Upload_Case_PDF_Report
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_ARCH_UCPD_0950 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            if (Parameter.PlannedActionID == Guid.Empty)
            {
                return returnValue;
            }

            var documentUpload = ORM_DOC_Document.Query.Search(Connection, Transaction, new ORM_DOC_Document.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Alias = Parameter.PlannedActionID.ToString()
            }).SingleOrDefault();

            var documentUploadRevision = new ORM_DOC_DocumentRevision();
            documentUploadRevision.Revision = 0;

            if (documentUpload == null)
            {
                documentUpload = new ORM_DOC_Document();
                documentUpload.Tenant_RefID = securityTicket.TenantID;
                documentUpload.Alias = Parameter.PlannedActionID.ToString();
                documentUpload.GlobalPropertyMatchingID = "case pdf";

                documentUpload.Save(Connection, Transaction);
            }
            else
            {
                var previousDocumentUploadRevision = ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, new ORM_DOC_DocumentRevision.Query()
                {
                    IsLastRevision = true,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Document_RefID = documentUpload.DOC_DocumentID
                }).SingleOrDefault();

                previousDocumentUploadRevision.IsLastRevision = false;
                previousDocumentUploadRevision.Modification_Timestamp = DateTime.Now;

                previousDocumentUploadRevision.Save(Connection, Transaction);

                documentUploadRevision.Revision = previousDocumentUploadRevision.Revision + 1;
            }

            documentUploadRevision.File_MIMEType = Parameter.Mime;
            documentUploadRevision.Tenant_RefID = securityTicket.TenantID;
            documentUploadRevision.Document_RefID = documentUpload.DOC_DocumentID;
            documentUploadRevision.UploadedByAccount = securityTicket.AccountID;
            documentUploadRevision.File_ServerLocation = Parameter.DocumentID.ToString();
            documentUploadRevision.File_Name = Parameter.DocumentName;
            documentUploadRevision.File_Description = Parameter.CaseID.ToString();
            documentUploadRevision.IsLastRevision = true;

            documentUploadRevision.Save(Connection, Transaction);

            var docStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                Label = Parameter.CaseID.ToString()
            }).FirstOrDefault();

            if (docStructure == null)
            {
                docStructure = new ORM_DOC_Structure();
                docStructure.Tenant_RefID = securityTicket.TenantID;
                docStructure.Label = Parameter.CaseID.ToString();

                docStructure.Save(Connection, Transaction);
            }

            var doc2docStructure = new ORM_DOC_Document_2_Structure();
            doc2docStructure.Tenant_RefID = securityTicket.TenantID;
            doc2docStructure.Document_RefID = documentUpload.DOC_DocumentID;
            doc2docStructure.Structure_RefID = docStructure.DOC_StructureID;

            doc2docStructure.Save(Connection, Transaction);

            #region Case property
            var caseProperty = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
            {
                GlobalPropertyMatchingID = ECaseProperty.ReportDownloaded.Value(),
                Tenant_RefID = securityTicket.TenantID,
                IsValue_String = true,
                IsDeleted = false,
                PropertyName = "Case Report Downloaded"
            }).SingleOrDefault();

            if (caseProperty == null)
            {
                caseProperty = new ORM_HEC_CAS_Case_UniversalProperty();
                caseProperty.GlobalPropertyMatchingID = ECaseProperty.ReportDownloaded.Value();
                caseProperty.IsValue_String = true;
                caseProperty.Modification_Timestamp = DateTime.Now;
                caseProperty.PropertyName = "Case Report Downloaded";
                caseProperty.Tenant_RefID = securityTicket.TenantID;

                caseProperty.Save(Connection, Transaction);
            }

            var casePropertyValue = ORM_HEC_CAS_Case_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
            {
                HEC_CAS_Case_RefID = Parameter.CaseID,
                HEC_CAS_Case_UniversalProperty_RefID = caseProperty.HEC_CAS_Case_UniversalPropertyID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (casePropertyValue == null)
            {
                casePropertyValue = new ORM_HEC_CAS_Case_UniversalPropertyValue();
                casePropertyValue.HEC_CAS_Case_RefID = Parameter.CaseID;
                casePropertyValue.HEC_CAS_Case_UniversalProperty_RefID = caseProperty.HEC_CAS_Case_UniversalPropertyID;
                casePropertyValue.Tenant_RefID = securityTicket.TenantID;
            }

            casePropertyValue.Modification_Timestamp = DateTime.Now;
            if (casePropertyValue.Value_String == null)
            {
                casePropertyValue.Value_String = Parameter.PlannedActionID.ToString();
            }
            else
            {
                if (!casePropertyValue.Value_String.Contains(Parameter.PlannedActionID.ToString()))
                {
                    casePropertyValue.Value_String += ";" + Parameter.PlannedActionID.ToString();
                }
            }

            casePropertyValue.Save(Connection, Transaction);
            #endregion

            if (!Parameter.IsBackgroundTask)
            {
                #region Update elastic
                try
                {
                    var settlement = Get_Settlement.GetSettlementForID(Parameter.PlannedActionID.ToString(), securityTicket);
                    settlement.is_report_downloaded = true;

                    Add_new_Settlement.Import_Settlement_to_ElasticDB(new List<Settlement_Model>() { settlement }, securityTicket.TenantID.ToString());

                    var patientDetails = Retrieve_Patients.Get_PatientDetaiForID(Parameter.PlannedActionID.ToString(), securityTicket);
                    patientDetails.if_settlement_is_report_downloaded = true;

                    Add_New_Patient.ImportPatientDetailsToElastic(new List<PatientDetailViewModel>() { patientDetails }, securityTicket.TenantID.ToString());
                }
                catch { }
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
        public static FR_Guid Invoke(string ConnectionString, P_ARCH_UCPD_0950 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_ARCH_UCPD_0950 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_ARCH_UCPD_0950 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_ARCH_UCPD_0950 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Upload_Case_PDF_Report", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_ARCH_UCPD_0950 for attribute P_ARCH_UCPD_0950
    [DataContract]
    public class P_ARCH_UCPD_0950
    {
        //Standard type parameters
        [DataMember]
        public Guid DocumentID { get; set; }
        [DataMember]
        public Guid PlannedActionID { get; set; }
        [DataMember]
        public Guid CaseID { get; set; }
        [DataMember]
        public String CaseType { get; set; }
        [DataMember]
        public String Mime { get; set; }
        [DataMember]
        public String DocumentName { get; set; }
        [DataMember]
        public Boolean IsBackgroundTask { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Upload_Case_PDF_Report(,P_ARCH_UCPD_0950 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Upload_Case_PDF_Report.Invoke(connectionString,P_ARCH_UCPD_0950 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Archive.Atomic.Manipulation.P_ARCH_UCPD_0950();
parameter.DocumentID = ...;
parameter.PlannedActionID = ...;
parameter.CaseID = ...;
parameter.CaseType = ...;
parameter.Mime = ...;
parameter.DocumentName = ...;
parameter.IsBackgroundTask = ...;

*/
