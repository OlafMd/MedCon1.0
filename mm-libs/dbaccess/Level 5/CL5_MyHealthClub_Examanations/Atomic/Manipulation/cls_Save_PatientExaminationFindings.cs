/* 
 * Generated on 3/25/2015 15:27:36
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
using CL1_HEC_ACT;

namespace CL5_MyHealthClub_Examanations.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PatientExaminationFindings.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PatientExaminationFindings
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_SPEF_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();
			//Put your code here
            //remove deleted images from database
            foreach (var image2delete in Parameter.PictureIDsToRemove)
            {
                  var findingDocumentQuery = new ORM_HEC_Patient_Finding_Document.Query();
                    findingDocumentQuery.Tenant_RefID = securityTicket.TenantID;
                    findingDocumentQuery.IsDeleted = false;
                    findingDocumentQuery.Document_RefID = image2delete;

                    var findingDocument = ORM_HEC_Patient_Finding_Document.Query.Search(Connection, Transaction, findingDocumentQuery).Single();
                    findingDocument.IsDeleted = true;
                    findingDocument.Save(Connection, Transaction);

                    var documentTableQuery = new ORM_DOC_Document.Query();
                    documentTableQuery.DOC_DocumentID = image2delete;
                    findingDocument.Tenant_RefID = securityTicket.TenantID;
                    findingDocument.IsDeleted = false;

                    var documentTable = ORM_DOC_Document.Query.Search(Connection, Transaction, documentTableQuery).Single();
                    documentTable.IsDeleted = true;
                    documentTable.Save(Connection, Transaction);
            }
            //delete findings that have no documents(images)
            foreach (var finding2delete in Parameter.PatientFindingIDsToRemove)
            {
                var examinationFinding = ORM_HEC_ACT_PerformedAction_PatientProvidedFinding.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_PatientProvidedFinding.Query()
                {
                    Tenant_RefID=securityTicket.TenantID,
                    IsDeleted = false,
                    HEC_Patient_Finding_RefID = finding2delete
                }).Single();
                examinationFinding.IsDeleted = true;
                examinationFinding.Save(Connection, Transaction);

                var patientFindings = ORM_HEC_Patient_Finding.Query.Search(Connection, Transaction, new ORM_HEC_Patient_Finding.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted=false,
                    HEC_Patient_FindingID = finding2delete
                }).Single();
                patientFindings.IsDeleted = true;
                patientFindings.Save(Connection, Transaction);
            }
            //save new images
            foreach(var images2Save in Parameter.PicturesToAdd){
                var findingDocument = new ORM_HEC_Patient_Finding_Document();
                findingDocument.Comment = images2Save.Name;
                findingDocument.HEC_Patient_Finding_DocumentID = Guid.NewGuid();
                findingDocument.Document_RefID = images2Save.DocumentID;
                findingDocument.Tenant_RefID = securityTicket.TenantID;
                findingDocument.Patient_Finding_RefID = images2Save.FindingID;
                findingDocument.Save(Connection, Transaction);

                var document = new ORM_DOC_Document();
                document.PrimaryType =  images2Save.Type.ToString();
                document.DOC_DocumentID = images2Save.DocumentID;
                document.Alias = images2Save.Size;
                document.Tenant_RefID = securityTicket.TenantID;
                document.Save(Connection, Transaction);
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5EX_SPEF_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5EX_SPEF_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_SPEF_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_SPEF_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Save_PatientExaminationFindings",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5EX_SPEF_1258 for attribute P_L5EX_SPEF_1258
		[DataContract]
		public class P_L5EX_SPEF_1258 
		{
			[DataMember]
			public P_L5EX_SPEF_1258_images[] PicturesToAdd { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid[] PictureIDsToRemove { get; set; } 
			[DataMember]
			public Guid[] PatientFindingIDsToRemove { get; set; } 

		}
		#endregion
		#region SClass P_L5EX_SPEF_1258_images for attribute PicturesToAdd
		[DataContract]
		public class P_L5EX_SPEF_1258_images 
		{
			//Standard type parameters
			[DataMember]
			public Guid DocumentID { get; set; } 
			[DataMember]
			public Guid FindingID { get; set; } 
			[DataMember]
			public String Size { get; set; } 
			[DataMember]
			public String Type { get; set; } 
			[DataMember]
			public String Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_PatientExaminationFindings(,P_L5EX_SPEF_1258 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_PatientExaminationFindings.Invoke(connectionString,P_L5EX_SPEF_1258 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Examanations.Atomic.Manipulation.P_L5EX_SPEF_1258();
parameter.PicturesToAdd = ...;

parameter.PictureIDsToRemove = ...;
parameter.PatientFindingIDsToRemove = ...;

*/
