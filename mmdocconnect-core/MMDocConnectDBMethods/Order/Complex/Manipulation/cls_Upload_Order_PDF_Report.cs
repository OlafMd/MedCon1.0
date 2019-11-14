/* 
 * Generated on 2/14/2017 11:49:28 AM
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

namespace MMDocConnectDBMethods.Order.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Upload_Order_PDF_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Upload_Order_PDF_Report
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_OR_UOPDFR_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            if (String.IsNullOrEmpty(Parameter.CaseOrderNumber))
            {
                return returnValue;
            }

            # region save document
            var documentUpload = ORM_DOC_Document.Query.Search(Connection, Transaction, new ORM_DOC_Document.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Alias = Parameter.CaseOrderNumber,
                GlobalPropertyMatchingID = "Submitted order pdf"
            }).SingleOrDefault();

            if (documentUpload == null)
            {
                documentUpload = new ORM_DOC_Document();
                documentUpload.Tenant_RefID = securityTicket.TenantID;
                documentUpload.Alias = Parameter.CaseOrderNumber;
                documentUpload.GlobalPropertyMatchingID = "Submitted order pdf";

                documentUpload.Save(Connection, Transaction);
            }
            #endregion

            #region revision
            var documentUploadRevision = new ORM_DOC_DocumentRevision();
            documentUploadRevision.Revision = 0;
            documentUploadRevision.File_MIMEType = Parameter.Mime;
            documentUploadRevision.Tenant_RefID = securityTicket.TenantID;
            documentUploadRevision.Document_RefID = documentUpload.DOC_DocumentID;
            documentUploadRevision.UploadedByAccount = securityTicket.AccountID;
            documentUploadRevision.File_ServerLocation = Parameter.DocumentID.ToString();
            documentUploadRevision.File_Name = Parameter.DocumentName;
            documentUploadRevision.File_Description = Parameter.DocumentName;
            documentUploadRevision.IsLastRevision = true;

            documentUploadRevision.Save(Connection, Transaction);
            #endregion

            foreach (var order in Parameter.OrderIDs)
            {
                var docStructure = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Label = order.ToString()
                }).SingleOrDefault();
                if (docStructure == null)
                {
                    docStructure = new ORM_DOC_Structure();
                    docStructure.Tenant_RefID = securityTicket.TenantID;
                    docStructure.Label = order.ToString();
                    docStructure.Save(Connection, Transaction);
                }

                var doc2docStructure = new ORM_DOC_Document_2_Structure();
                doc2docStructure.Tenant_RefID = securityTicket.TenantID;
                doc2docStructure.Document_RefID = documentUpload.DOC_DocumentID;
                doc2docStructure.Structure_RefID = docStructure.DOC_StructureID;

                doc2docStructure.Save(Connection, Transaction);
            }

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_OR_UOPDFR_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_OR_UOPDFR_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_OR_UOPDFR_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_OR_UOPDFR_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Upload_Order_PDF_Report",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_OR_UOPDFR_1049 for attribute P_OR_UOPDFR_1049
		[DataContract]
		public class P_OR_UOPDFR_1049 
		{
			//Standard type parameters
			[DataMember]
			public Guid DocumentID { get; set; } 
			[DataMember]
			public String CaseOrderNumber { get; set; } 
			[DataMember]
			public Guid[] OrderIDs { get; set; } 
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
FR_Guid cls_Upload_Order_PDF_Report(,P_OR_UOPDFR_1049 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Upload_Order_PDF_Report.Invoke(connectionString,P_OR_UOPDFR_1049 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Order.Complex.Manipulation.P_OR_UOPDFR_1049();
parameter.DocumentID = ...;
parameter.CaseOrderNumber = ...;
parameter.OrderIDs = ...;
parameter.Mime = ...;
parameter.DocumentName = ...;
parameter.IsBackgroundTask = ...;

*/
