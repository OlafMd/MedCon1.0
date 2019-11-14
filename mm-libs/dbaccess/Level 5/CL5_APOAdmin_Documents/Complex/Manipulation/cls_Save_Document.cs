/* 
 * Generated on 1/10/2014 5:24:14 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL2_Document.Atomic.Manipulation;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL1_DOC;

namespace CL5_APOAdmin_Documents.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Document.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Document
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_SD_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            var saveDocumentParam = new P_L2DO_SDD_1640();

            if (Parameter.IsDeleted)
            {
                // Delete document revisions
                ORM_DOC_DocumentRevision.Query qry = new ORM_DOC_DocumentRevision.Query();
                qry.Document_RefID = Parameter.DOC_DocumentID;
                qry.IsDeleted = false;

                foreach(var item in ORM_DOC_DocumentRevision.Query.Search(Connection, Transaction, qry))
                {
                    item.Load(Connection, Transaction, item.DOC_DocumentRevisionID);
                    item.IsDeleted = true;
                    item.Save(Connection, Transaction);
                }

                //Delete document if exists
                ORM_DOC_Document doc = new ORM_DOC_Document();
                var docQry = new ORM_DOC_Document.Query()
                {
                    
                    DOC_DocumentID = Parameter.DOC_DocumentID
                };
                if (ORM_DOC_Document.Query.Exists(Connection, Transaction, docQry))
                {
                    doc.Load(Connection, Transaction, Parameter.DOC_DocumentID);
                    doc.IsDeleted = true;
                    doc.Save(Connection, Transaction);

                    returnValue.Result = doc.DOC_DocumentID;
                }

                return returnValue;
            }

            var savedDocumentGuid = cls_Save_DOC_Document.Invoke(Connection, Transaction, saveDocumentParam, securityTicket).Result;

            var saveDocumentRevisionParam = new P_L2DO_SDDR_1644();
            saveDocumentRevisionParam.Document_RefID = savedDocumentGuid;
            saveDocumentRevisionParam.File_Name = Parameter.File_Name;
            saveDocumentRevisionParam.UploadedByAccount = Parameter.UploadedByAccount;
            saveDocumentRevisionParam.File_ServerLocation = Parameter.FileLocation;
            
            saveDocumentRevisionParam.IsLastRevision = true;
            saveDocumentRevisionParam.Revision = 1;

            var webshopParam = new P_L2DO_SEDGD_1813();
            webshopParam.Document_RefID = savedDocumentGuid;
            webshopParam.IsPublicallyVisible = Parameter.VisibleInWebShop;
            webshopParam.DocumentTypeMatchingID = EnumUtils.GetEnumDescription(EDocumentType.APODemandDocument);
            cls_Save_ECM_DOC_GeneralDocument.Invoke(Connection, Transaction, webshopParam, securityTicket);

            var savedRevisionGuid = cls_Save_DOC_DocumentRevision.Invoke(Connection, Transaction, saveDocumentRevisionParam, securityTicket).Result;

            returnValue.Result = savedDocumentGuid;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DO_SD_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DO_SD_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_SD_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_SD_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Document",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DO_SD_1702 for attribute P_L5DO_SD_1702
		[DataContract]
		public class P_L5DO_SD_1702 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 
			[DataMember]
			public String File_Name { get; set; } 
			[DataMember]
			public Guid UploadedByAccount { get; set; } 
			[DataMember]
			public DateTime CreationDate { get; set; } 
			[DataMember]
			public Boolean VisibleInWebShop { get; set; } 
			[DataMember]
			public String FileLocation { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Document(,P_L5DO_SD_1702 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Document.Invoke(connectionString,P_L5DO_SD_1702 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Documents.Complex.Manipulation.P_L5DO_SD_1702();
parameter.DOC_DocumentID = ...;
parameter.File_Name = ...;
parameter.UploadedByAccount = ...;
parameter.CreationDate = ...;
parameter.VisibleInWebShop = ...;
parameter.FileLocation = ...;
parameter.IsDeleted = ...;

*/
