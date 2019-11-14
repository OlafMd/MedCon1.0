/* 
 * Generated on 3/20/2015 11:31:31
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
using CL1_DOC;

namespace CL5_MyHealthClub_Patient.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PatientDocuments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PatientDocuments
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_SPU_1713 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            if (Parameter.Documents.Length > 0)
            {
                var patient_findingQuery = new ORM_HEC_Patient_Finding.Query();
                patient_findingQuery.HEC_Patient_FindingID = Parameter.PatientFindingID;
                patient_findingQuery.IsDeleted = false;
                patient_findingQuery.Tenant_RefID = securityTicket.TenantID;
                var patient_finding = ORM_HEC_Patient_Finding.Query.Search(Connection, Transaction, patient_findingQuery).Single();
                patient_finding.Modification_Timestamp = DateTime.Now;
                patient_finding.Save(Connection, Transaction);
            }

            foreach (var document in Parameter.Documents)
            {
                if (document.isDeleted)
                {
                    var findingDocumentQuery = new ORM_HEC_Patient_Finding_Document.Query();
                    findingDocumentQuery.Tenant_RefID = securityTicket.TenantID;
                    findingDocumentQuery.IsDeleted = false;
                    findingDocumentQuery.HEC_Patient_Finding_DocumentID = document.id;

                    var findingDocument = ORM_HEC_Patient_Finding_Document.Query.Search(Connection, Transaction, findingDocumentQuery).Single();
                    findingDocument.IsDeleted = true;
                    findingDocument.Save(Connection, Transaction);

                    var documentTableQuery = new ORM_DOC_Document.Query();
                    documentTableQuery.DOC_DocumentID = findingDocument.Document_RefID;
                    findingDocument.Tenant_RefID = securityTicket.TenantID;
                    findingDocument.IsDeleted = false;

                    var documentTable = ORM_DOC_Document.Query.Search(Connection, Transaction, documentTableQuery).Single();
                    documentTable.IsDeleted = true;
                    documentTable.Save(Connection, Transaction);
                }
                else
                {
                    
                    ORM_HEC_Patient_Finding_Document findingDocument = new ORM_HEC_Patient_Finding_Document();
                    findingDocument.HEC_Patient_Finding_DocumentID = document.id;
                    findingDocument.Document_RefID = document.Document_RefID;
                    findingDocument.Comment = document.Name;
                    //findingDocument.Patient_Finding_RefID = document.findingid;
                    findingDocument.Tenant_RefID = securityTicket.TenantID;
                    findingDocument.Creation_Timestamp = DateTime.Now;
                    findingDocument.Modification_Timestamp = DateTime.Now;
                    findingDocument.Save(Connection, Transaction);

                    ORM_DOC_Document documentTable = new ORM_DOC_Document();
                    documentTable.PrimaryType = document.Type;
                    documentTable.DOC_DocumentID = findingDocument.Document_RefID;
                    documentTable.Alias = document.Size;
                    documentTable.Tenant_RefID = securityTicket.TenantID;
                    documentTable.Creation_Timestamp = DateTime.Now;
                    documentTable.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_L5PA_SPU_1713 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PA_SPU_1713 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_SPU_1713 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_SPU_1713 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_PatientDocuments",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PA_SPU_1713 for attribute P_L5PA_SPU_1713
		[DataContract]
		public class P_L5PA_SPU_1713 
		{
			[DataMember]
			public P_L5PA_SPU_1713_Documents[] Documents { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PatientFindingID { get; set; } 
			[DataMember]
			public DateTime FindingsDate { get; set; } 

		}
		#endregion
		#region SClass P_L5PA_SPU_1713_Documents for attribute Documents
		[DataContract]
		public class P_L5PA_SPU_1713_Documents 
		{
			//Standard type parameters
			[DataMember]
			public bool isDeleted { get; set; } 
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public String Type { get; set; } 
			[DataMember]
			public String Size { get; set; } 
			[DataMember]
			public Guid id { get; set; } 
			[DataMember]
			public Guid Document_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_PatientDocuments(,P_L5PA_SPU_1713 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_PatientDocuments.Invoke(connectionString,P_L5PA_SPU_1713 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Patient.Atomic.Manipulation.P_L5PA_SPU_1713();
parameter.Documents = ...;

parameter.PatientFindingID = ...;
parameter.FindingsDate = ...;

*/
