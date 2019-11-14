/* 
 * Generated on 7/2/2013 12:29:24 PM
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
using CL6_BBV_Patient.Atomic.Retrieval;
using CL1_HEC_STU;
using Core_ClassLibrarySupport.BBV;
using CL1_DOC_SLT;
using CL1_DOC;

namespace CL6_BBV_Patient.Complex.Manipulation
{
	[DataContract]
	public class cls_Save_BBV_PatientPolicy
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_SBBVPP_1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            P_L6PA_GBBVPfID_1714 getPatientParam = new P_L6PA_GBBVPfID_1714();
            getPatientParam.HEC_PatientID = Parameter.HEC_PatientID;
            L6PA_GBBVPfID_1714 patient = cls_Get_BBV_Patients_For_ID.Invoke(Connection, Transaction, getPatientParam, securityTicket).Result;

            if (patient == null)
            {
                var error = new FR_Guid();
                error.ErrorMessage = "No Such ID";
                error.Status = FR_Status.Error_Internal;
                return error;
            }

            ORM_HEC_STU_Study currentStudy;

            ORM_HEC_STU_Study.Query StudyQuer = new ORM_HEC_STU_Study.Query();
            StudyQuer.Tenant_RefID = securityTicket.TenantID;
            StudyQuer.IsDeleted = false;
            StudyQuer.GlobalPropertyMatchingID = STLD_Sudies.Sudies_GlobalProperty;
            var studyRes = ORM_HEC_STU_Study.Query.Search(Connection, Transaction, StudyQuer);
            if (studyRes.Count == 0)
            {
                ORM_HEC_STU_Study study = new ORM_HEC_STU_Study();
                study.GlobalPropertyMatchingID = STLD_Sudies.Sudies_GlobalProperty;
                study.Tenant_RefID = securityTicket.TenantID;
                study.Save(Connection, Transaction);
                currentStudy = study;
            }
            else
            {
                currentStudy = studyRes[0];
            }

            ORM_HEC_STU_Study_ParticipatingPatient.Query ppQuery = new ORM_HEC_STU_Study_ParticipatingPatient.Query();
            ppQuery.IsDeleted = false;
            ppQuery.Tenant_RefID = securityTicket.TenantID;
            ppQuery.HEC_STU_Study_ParticipatingPatientID = patient.HEC_STU_Study_ParticipatingPatientID;
            var ppRes = ORM_HEC_STU_Study_ParticipatingPatient.Query.Search(Connection, Transaction, ppQuery);

            ORM_HEC_STU_Study_ParticipatingPatient ParticipatingPatient = ppRes[0];
            ParticipatingPatient.Study_RefID = currentStudy.HEC_STU_StudyID;
            ParticipatingPatient.Participation_DateOfSigning = DateTime.Now;
            ParticipatingPatient.Save(Connection, Transaction);

            if (Parameter.Documents != null)
            {
                foreach (var doc in Parameter.Documents)
                {
                    ORM_DOC_SLT_DocumentSlot currentSlot;

                    ORM_DOC_SLT_DocumentSlot.Query QueryORM_DOC_SLT_DocumentSlotQuery = new ORM_DOC_SLT_DocumentSlot.Query();
                    QueryORM_DOC_SLT_DocumentSlotQuery.Tenant_RefID = securityTicket.TenantID;
                    QueryORM_DOC_SLT_DocumentSlotQuery.IsDeleted = false;
                    QueryORM_DOC_SLT_DocumentSlotQuery.GlobalPropertyMatchingID = doc.DocSlot_GlobalPropertyMatching;
                    var QueryORM_DOC_SLT_DocumentSlotQueryRes = ORM_DOC_SLT_DocumentSlot.Query.Search(Connection, Transaction, QueryORM_DOC_SLT_DocumentSlotQuery);
                    if (QueryORM_DOC_SLT_DocumentSlotQueryRes.Count == 0)
                    {
                        ORM_DOC_SLT_DocumentSlot DocumentSlot = new ORM_DOC_SLT_DocumentSlot();
                        DocumentSlot.GlobalPropertyMatchingID = doc.DocSlot_GlobalPropertyMatching;
                        DocumentSlot.Tenant_RefID = securityTicket.TenantID;
                        DocumentSlot.Save(Connection, Transaction);
                        currentSlot = DocumentSlot;
                    }
                    else
                    {
                        currentSlot = QueryORM_DOC_SLT_DocumentSlotQueryRes[0];
                    }

                    ORM_HEC_STU_Study_ParticipationRequiredDocument ParticipationRequiredDocument = new ORM_HEC_STU_Study_ParticipationRequiredDocument();
                    ParticipationRequiredDocument.Tenant_RefID = securityTicket.TenantID;
                    ParticipationRequiredDocument.Study_RefID = currentStudy.HEC_STU_StudyID;
                    ParticipationRequiredDocument.DOC_SLT_DocumentSlot_RefID = currentSlot.DOC_SLT_DocumentSlotID;
                    ParticipationRequiredDocument.IsRequiredFor_PatientParticipation = true;
                    ParticipationRequiredDocument.Save(Connection, Transaction);

                    ORM_HEC_STU_Study_PatientDocument PatientDocument = new ORM_HEC_STU_Study_PatientDocument();
                    PatientDocument.Tenant_RefID = securityTicket.TenantID;
                    PatientDocument.ParticipatingPatient_RefID = ParticipatingPatient.HEC_STU_Study_ParticipatingPatientID;
                    PatientDocument.ParticipationRequiredDocument_RefID = ParticipationRequiredDocument.HEC_STU_Study_ParticipatingPatient_RequiredDocumentID;
                    PatientDocument.Document_RefID = Guid.NewGuid();
                    PatientDocument.Save(Connection, Transaction);

                    var document = new ORM_DOC_Document();
                    document.DOC_DocumentID = PatientDocument.Document_RefID;
                    document.Alias = doc.File_Name;
                    document.PrimaryType = doc.File_Extension;
                    document.Creation_Timestamp = DateTime.Now;
                    document.Tenant_RefID = securityTicket.TenantID;
                    document.Save(Connection, Transaction);

                    var revision = new ORM_DOC_DocumentRevision();
                    revision.DOC_DocumentRevisionID = Guid.NewGuid();
                    revision.Document_RefID = PatientDocument.Document_RefID;
                    revision.Revision = 1;
                    revision.IsLastRevision = true;
                    revision.UploadedByAccount = securityTicket.AccountID;
                    revision.File_Name = doc.File_Name;
                    revision.File_ServerLocation = doc.File_ServerLocation;
                    revision.File_Extension = doc.File_Extension;
                    revision.File_Size_Bytes = doc.File_Size_Bytes;
                    revision.Creation_Timestamp = DateTime.Now;
                    revision.Tenant_RefID = securityTicket.TenantID;
                    revision.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_L6PA_SBBVPP_1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6PA_SBBVPP_1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_SBBVPP_1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_SBBVPP_1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L6PA_SBBVPP_1434 for attribute P_L6PA_SBBVPP_1434
		[DataContract]
		public class P_L6PA_SBBVPP_1434 
		{
			[DataMember]
			public P_L6PA_SBBVPP_1434_Document[] Documents { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_PatientID { get; set; } 

		}
		#endregion
		#region SClass P_L6PA_SBBVPP_1434_Document for attribute Documents
		[DataContract]
		public class P_L6PA_SBBVPP_1434_Document 
		{
			//Standard type parameters
			[DataMember]
			public String File_Name { get; set; } 
			[DataMember]
			public String File_Extension { get; set; } 
			[DataMember]
			public int File_Size_Bytes { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public string DocSlot_GlobalPropertyMatching { get; set; } 

		}
		#endregion

	#endregion
}
