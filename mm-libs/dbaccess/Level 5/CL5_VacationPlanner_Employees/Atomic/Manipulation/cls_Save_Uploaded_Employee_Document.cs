/* 
 * Generated on 12/16/2013 12:03:21 PM
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
using CL1_CMN_BPT_EMP;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Uploaded_Employee_Document.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Uploaded_Employee_Document
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_SUED_1648 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            ORM_CMN_BPT_EMP_Employee_PayroleDocument.Query payroleDocumentQuery = new ORM_CMN_BPT_EMP_Employee_PayroleDocument.Query();
            payroleDocumentQuery.Employee_RefID = Parameter.Employee_RefID;
            payroleDocumentQuery.Tenant_RefID = securityTicket.TenantID;
            payroleDocumentQuery.IsDeleted = false;
            List<ORM_CMN_BPT_EMP_Employee_PayroleDocument> payroleDocumentList = ORM_CMN_BPT_EMP_Employee_PayroleDocument.Query.Search(Connection, Transaction, payroleDocumentQuery);

            List<ORM_CMN_BPT_EMP_Employee_PayroleDocument> deletedDocumentList = new List<ORM_CMN_BPT_EMP_Employee_PayroleDocument>();
            ORM_DOC_DocumentRevision docReviosion = new ORM_DOC_DocumentRevision();
            ORM_DOC_Document docDocument;
            FR_Base docRevisionResult = new FR_Base();
            FR_Base docDocumentResult = new FR_Base();
            foreach (var item in payroleDocumentList)
            {
                if (Parameter.Documents.Any(p => p.CMN_BPT_EMP_Employee_PayroleDocumentsID == item.CMN_BPT_EMP_Employee_PayroleDocumentsID))
                    continue;

                if (item.Document_RefID != Guid.Empty)
                    docRevisionResult = docReviosion.Load(Connection, Transaction, item.Document_RefID);

                if (docRevisionResult.Status == FR_Status.Success && docReviosion.DOC_DocumentRevisionID != Guid.Empty)
                    docReviosion.Remove(Connection, Transaction);

                item.Remove(Connection, Transaction);
                deletedDocumentList.Add(item);

            }
            payroleDocumentList = payroleDocumentList.Except(deletedDocumentList).ToList();

            foreach (var payroleDocument in Parameter.Documents)
            {
                ORM_CMN_BPT_EMP_Employee_PayroleDocument payroleDocuments = new ORM_CMN_BPT_EMP_Employee_PayroleDocument();

                if (payroleDocumentList.Any(item => item.CMN_BPT_EMP_Employee_PayroleDocumentsID == payroleDocument.CMN_BPT_EMP_Employee_PayroleDocumentsID))
                    payroleDocuments.Load(Connection, Transaction, payroleDocument.CMN_BPT_EMP_Employee_PayroleDocumentsID);

                docDocument = new ORM_DOC_Document();
                docReviosion = new ORM_DOC_DocumentRevision();
                if (payroleDocuments.Document_RefID != Guid.Empty)
                {
                    docRevisionResult = docReviosion.Load(Connection, Transaction, payroleDocument.DocumentID);
                    docDocumentResult = docDocument.Load(Connection, Transaction, docReviosion.Document_RefID);
                }

                docDocument.Alias = payroleDocument.File_Name;
                docDocument.Tenant_RefID = securityTicket.TenantID;
                docDocument.Save(Connection, Transaction);

                docReviosion.DOC_DocumentRevisionID = payroleDocument.DocumentID;
                docReviosion.Document_RefID = docDocument.DOC_DocumentID;
                docReviosion.File_Name = payroleDocument.File_Name;
                docReviosion.File_Description = payroleDocument.File_Description;
                docReviosion.File_Extension = payroleDocument.File_Extension;
                docReviosion.File_MIMEType = payroleDocument.File_MIMEType;
                docReviosion.Tenant_RefID = securityTicket.TenantID;
                docReviosion.Save(Connection, Transaction);

                payroleDocuments.Tenant_RefID = securityTicket.TenantID;
                payroleDocuments.Document_RefID = payroleDocument.DocumentID;
                payroleDocuments.DocumentDate = payroleDocument.DocumentDate;
                payroleDocuments.Employee_RefID = Parameter.Employee_RefID;

                payroleDocuments.Save(Connection, Transaction);

            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EM_SUED_1648 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EM_SUED_1648 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_SUED_1648 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_SUED_1648 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Uploaded_Employee_Document(P_L5EM_SUED_1648 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_Uploaded_Employee_Document.Invoke(connectionString,P_L5EM_SUED_1648 Parameter,securityTicket);
	 return result;
}
*/