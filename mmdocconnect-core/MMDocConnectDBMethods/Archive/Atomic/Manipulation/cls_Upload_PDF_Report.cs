/* 
 * Generated on 10.9.2015 13:46:09
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
using CL1_DOC;
using CL1_USR;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Receipt.Manipulation;

namespace MMDocConnectDBMethods.Archive.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Upload_PDF_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Upload_PDF_Report
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_ARCH_UPD_1434 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            var documentUpload = new ORM_DOC_Document();
            documentUpload.DOC_DocumentID = Guid.NewGuid();
            documentUpload.IsDeleted = false;
            documentUpload.Creation_Timestamp = DateTime.Now;
            documentUpload.Tenant_RefID = securityTicket.TenantID;
            documentUpload.Alias = Parameter.RecepiantID.ToString();
            documentUpload.PrimaryType = Parameter.AmountNo.ToString();
            documentUpload.GlobalPropertyMatchingID = "pdf doc";
            documentUpload.Save(Connection, Transaction);


            var documentUploadRevision = new ORM_DOC_DocumentRevision();
            documentUploadRevision.DOC_DocumentRevisionID = Guid.NewGuid();
            documentUploadRevision.Creation_Timestamp = DateTime.Now;
            documentUploadRevision.File_MIMEType = Parameter.Mime;
            documentUploadRevision.IsDeleted = false;
            documentUploadRevision.Tenant_RefID = securityTicket.TenantID;
            documentUploadRevision.Document_RefID = documentUpload.DOC_DocumentID;
            documentUploadRevision.UploadedByAccount = securityTicket.AccountID;
            documentUploadRevision.File_ServerLocation = Parameter.DocumentID.ToString();
            documentUploadRevision.File_Name = Parameter.DocumentName;
            documentUploadRevision.File_Description = Parameter.Description;
            documentUploadRevision.Save(Connection, Transaction);

            var usrAccount = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                USR_AccountID = securityTicket.AccountID

            }).Single();
            Guid DocStructureGuid = Guid.NewGuid();
            var docStructureQ = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                Label = usrAccount.BusinessParticipant_RefID.ToString()

            }).SingleOrDefault();
            if (docStructureQ == null)
            {
                var docStructure = new ORM_DOC_Structure();
                docStructure.DOC_StructureID = DocStructureGuid;
                docStructure.IsDeleted = false;
                docStructure.Tenant_RefID = securityTicket.TenantID;
                docStructure.Label = usrAccount.BusinessParticipant_RefID.ToString();
                docStructure.Creation_Timestamp = DateTime.Now;
                docStructure.Save(Connection, Transaction);
            }
            else
            {
                DocStructureGuid = docStructureQ.DOC_StructureID;
            }

            var doc2docStructure = new ORM_DOC_Document_2_Structure();
            doc2docStructure.IsDeleted = false;
            doc2docStructure.Tenant_RefID = securityTicket.TenantID;
            doc2docStructure.Creation_Timestamp = DateTime.Now;
            doc2docStructure.AssignmentID = Guid.NewGuid();
            doc2docStructure.Document_RefID = documentUpload.DOC_DocumentID;
            doc2docStructure.Structure_RefID = DocStructureGuid;
            doc2docStructure.Save(Connection, Transaction);

            Receipt_Model receipt = new Receipt_Model();
            receipt.id = documentUpload.DOC_DocumentID.ToString();
            receipt.documentID = Parameter.DocumentID.ToString();
            receipt.filedate = Parameter.DocumentDate;
            receipt.filedateString = Parameter.DocumentDate.ToString("dd.MM.yyyy");
            receipt.period = Parameter.Description;
            receipt.periodDate = Parameter.DocumentDate;
            receipt.amount = Parameter.Amount;
            receipt.doctorID = Parameter.RecepiantID.ToString();
            receipt.amountNo = Parameter.AmountNo;
            receipt.isViewed = false;

            Add_Item_to_Receipts.Import_Receipt_Item_to_ElasticDB(new List<Receipt_Model>() { receipt }, securityTicket.TenantID.ToString());

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_ARCH_UPD_1434 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_ARCH_UPD_1434 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_ARCH_UPD_1434 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_ARCH_UPD_1434 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Upload_PDF_Report", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_ARCH_UPD_1434 for attribute P_ARCH_UPD_1434
    [DataContract]
    public class P_ARCH_UPD_1434
    {
        //Standard type parameters
        [DataMember]
        public Guid DocumentID { get; set; }
        [DataMember]
        public Guid RecepiantID { get; set; }
        [DataMember]
        public String Mime { get; set; }
        [DataMember]
        public String DocumentName { get; set; }
        [DataMember]
        public DateTime DocumentDate { get; set; }
        [DataMember]
        public String Receiver { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String Amount { get; set; }
        [DataMember]
        public int AmountNo { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Upload_PDF_Report(,P_ARCH_UPD_1434 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Upload_PDF_Report.Invoke(connectionString,P_ARCH_UPD_1434 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Archive.Atomic.Manipulation.P_ARCH_UPD_1434();
parameter.DocumentID = ...;
parameter.RecepiantID = ...;
parameter.Mime = ...;
parameter.DocumentName = ...;
parameter.DocumentDate = ...;
parameter.Receiver = ...;
parameter.Description = ...;
parameter.Amount = ...;
parameter.AmountNo = ...;

*/
