/* 
 * Generated on 3/24/2015 14:34:16
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
using CL1_HEC_ACT;
using CL1_HEC;
using CL1_DOC;

namespace CL5_MyHealthClub_Examanations.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Finding.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Finding
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EX_SPF_1207 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_SPF_1207 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5EX_SPF_1207();
			//Put your code here
           
            if (!Parameter.IsDeleted)
            {
                //save
                returnValue.Result = new L5EX_SPF_1207();
                var performedActionFindings =new  ORM_HEC_ACT_PerformedAction_PatientProvidedFinding();
                performedActionFindings.Tenant_RefID=securityTicket.TenantID;
                performedActionFindings.HEC_Patient_Finding_RefID = Guid.NewGuid();
                performedActionFindings.HEC_ACT_PerformedAction_RefID=Parameter.ExaminationID;
                performedActionFindings.Save(Connection,Transaction);

                var patientFinding = new ORM_HEC_Patient_Finding();
                patientFinding.HEC_Patient_FindingID = performedActionFindings.HEC_Patient_Finding_RefID;

                patientFinding.DateOfFindings = Parameter.PictureTakenDate;
                patientFinding.Tenant_RefID = securityTicket.TenantID;
                patientFinding.Patient_RefID = Parameter.PatientID;
                patientFinding.MedicalPracticeType_RefID = Parameter.PracticeTypeID;
                patientFinding.Save(Connection, Transaction);
                returnValue.Result.FindingID = new Guid();
                returnValue.Result.FindingID = patientFinding.HEC_Patient_FindingID;

                var medicalPracticeType = ORM_HEC_MedicalPractice_Type.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_Type.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    HEC_MedicalPractice_TypeID = Parameter.PracticeTypeID

                }).Single();
                returnValue.Result.MedicalPracticeTypeName = medicalPracticeType.MedicalPracticeType_Name.Contents[0].Content;
                
            }
            else
            {
                //delete examination patient finding
                var performedActionFindings = ORM_HEC_ACT_PerformedAction_PatientProvidedFinding.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_PatientProvidedFinding.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    HEC_Patient_Finding_RefID = Parameter.FindingID,
                    HEC_ACT_PerformedAction_RefID = Parameter.ExaminationID
                }).Single();

                performedActionFindings.IsDeleted = true;
                performedActionFindings.Save(Connection, Transaction);

                var patientFinding = ORM_HEC_Patient_Finding.Query.Search(Connection,Transaction,new ORM_HEC_Patient_Finding.Query(){
                    IsDeleted=false,
                    Tenant_RefID = securityTicket.TenantID,
                    HEC_Patient_FindingID = Parameter.FindingID
                }).Single();



                var findingDocuments = ORM_HEC_Patient_Finding_Document.Query.Search(Connection, Transaction, new ORM_HEC_Patient_Finding_Document.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Patient_Finding_RefID = Parameter.FindingID
                });
                foreach (var findingDocument in findingDocuments)
                {
                    var document = ORM_DOC_Document.Query.Search(Connection, Transaction, new ORM_DOC_Document.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        DOC_DocumentID = findingDocument.Document_RefID
                    }).Single();
                    document.IsDeleted = true;
                    document.Save(Connection, Transaction);

                    findingDocument.IsDeleted = true;
                    findingDocument.Save(Connection, Transaction);

                }
                patientFinding.IsDeleted=true;
                patientFinding.Save(Connection,Transaction);

            }
            
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EX_SPF_1207 Invoke(string ConnectionString,P_L5EX_SPF_1207 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EX_SPF_1207 Invoke(DbConnection Connection,P_L5EX_SPF_1207 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EX_SPF_1207 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_SPF_1207 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EX_SPF_1207 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_SPF_1207 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EX_SPF_1207 functionReturn = new FR_L5EX_SPF_1207();
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

				throw new Exception("Exception occured in method cls_Save_Finding",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EX_SPF_1207 : FR_Base
	{
		public L5EX_SPF_1207 Result	{ get; set; }

		public FR_L5EX_SPF_1207() : base() {}

		public FR_L5EX_SPF_1207(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EX_SPF_1207 for attribute P_L5EX_SPF_1207
		[DataContract]
		public class P_L5EX_SPF_1207 
		{
			//Standard type parameters
			[DataMember]
			public Guid ExaminationID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public DateTime PictureTakenDate { get; set; } 
			[DataMember]
			public Guid PracticeTypeID { get; set; } 
			[DataMember]
			public Guid FindingID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion
		#region SClass L5EX_SPF_1207 for attribute L5EX_SPF_1207
		[DataContract]
		public class L5EX_SPF_1207 
		{
			//Standard type parameters
			[DataMember]
			public Guid FindingID { get; set; } 
			[DataMember]
			public String MedicalPracticeTypeName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EX_SPF_1207 cls_Save_Finding(,P_L5EX_SPF_1207 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EX_SPF_1207 invocationResult = cls_Save_Finding.Invoke(connectionString,P_L5EX_SPF_1207 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Examanations.Atomic.Manipulation.P_L5EX_SPF_1207();
parameter.ExaminationID = ...;
parameter.PatientID = ...;
parameter.PictureTakenDate = ...;
parameter.PracticeTypeID = ...;
parameter.FindingID = ...;
parameter.IsDeleted = ...;

*/
