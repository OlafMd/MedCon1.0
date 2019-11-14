/* 
 * Generated on 3/26/2015 13:59:24
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
using CL5_MyHealthClub_Patient.Atomic.Retrieval;
using CL3_Offices.Atomic.Retrieval;

namespace CL6_MyHealthClub_Examanations.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Patient_examination_documents.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Patient_examination_documents
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6EX_GPED_0953 Execute(DbConnection Connection,DbTransaction Transaction,P_L6EX_GPED_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6EX_GPED_0953();
            returnValue.Result = new L6EX_GPED_0953();
            List<L6EX_GPED_0953_referal_types> referal_typeList = new List<L6EX_GPED_0953_referal_types>();
            returnValue.Result.referal_types = referal_typeList.ToArray();

            var patient_findings = cls_Get_PatientFindings.Invoke(Connection, Transaction, new P_L5PA_GPF_1649 { PatientID = Parameter.PatientID }, securityTicket).Result.ToList();
            var referal_types =  cls_Get_MedicalPracticeTypes_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            foreach (var item in referal_types)
            {
                L6EX_GPED_0953_referal_types referal = new L6EX_GPED_0953_referal_types();
                referal.referal_type_id = item.HEC_MedicalPractice_TypeID.ToString();
                referal.name = item.MedicalPracticeType_Name.Contents[0].Content;

                var referal_findings = patient_findings.Where(i => i.referal_id == item.HEC_MedicalPractice_TypeID).ToList();

                var findingsCount = 0;
                List<L6EX_GPED_0953_findings> findingList = new List<L6EX_GPED_0953_findings>();
                List<L6EX_GPED_0953_files> documents = new List<L6EX_GPED_0953_files>();
                foreach (var finding in referal_findings)
                {
                    L6EX_GPED_0953_findings newFinding = new L6EX_GPED_0953_findings();
                    newFinding.findings_id = finding.finding_id.ToString();
                    newFinding.findings_date = finding.date.ToShortDateString();
                    newFinding.files = new List<L6EX_GPED_0953_files>().ToArray();
                    var findings_documents = new List<L6EX_GPED_0953_files>();
                    foreach (var file in finding.files)
                    {
                        findingsCount++;
                        L6EX_GPED_0953_files document = new L6EX_GPED_0953_files();
                        document.document_id = file.file_url;
                        document.document_name = file.file_name;
                        findings_documents.Add(document);
                    }
                    newFinding.files = findings_documents.ToArray();
                    findingList.Add(newFinding);
                }
                referal.count = findingsCount.ToString();
                referal.findings = findingList.ToArray();
                referal_typeList.Add(referal);
            }

            returnValue.Result.referal_types = referal_typeList.ToArray();


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6EX_GPED_0953 Invoke(string ConnectionString,P_L6EX_GPED_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6EX_GPED_0953 Invoke(DbConnection Connection,P_L6EX_GPED_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6EX_GPED_0953 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6EX_GPED_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6EX_GPED_0953 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6EX_GPED_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6EX_GPED_0953 functionReturn = new FR_L6EX_GPED_0953();
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

				throw new Exception("Exception occured in method cls_Get_Patient_examination_documents",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6EX_GPED_0953 : FR_Base
	{
		public L6EX_GPED_0953 Result	{ get; set; }

		public FR_L6EX_GPED_0953() : base() {}

		public FR_L6EX_GPED_0953(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6EX_GPED_0953 for attribute P_L6EX_GPED_0953
		[DataContract]
		public class P_L6EX_GPED_0953 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L6EX_GPED_0953 for attribute L6EX_GPED_0953
		[DataContract]
		public class L6EX_GPED_0953 
		{
			[DataMember]
			public L6EX_GPED_0953_referal_types[] referal_types { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L6EX_GPED_0953_referal_types for attribute referal_types
		[DataContract]
		public class L6EX_GPED_0953_referal_types 
		{
			[DataMember]
			public L6EX_GPED_0953_findings[] findings { get; set; }

			//Standard type parameters
			[DataMember]
			public String referal_type_id { get; set; } 
			[DataMember]
			public String name { get; set; } 
			[DataMember]
			public String count { get; set; } 

		}
		#endregion
		#region SClass L6EX_GPED_0953_findings for attribute findings
		[DataContract]
		public class L6EX_GPED_0953_findings 
		{
			[DataMember]
			public L6EX_GPED_0953_files[] files { get; set; }

			//Standard type parameters
			[DataMember]
			public String findings_id { get; set; } 
			[DataMember]
			public String findings_date { get; set; } 

		}
		#endregion
		#region SClass L6EX_GPED_0953_files for attribute files
		[DataContract]
		public class L6EX_GPED_0953_files 
		{
			//Standard type parameters
			[DataMember]
			public Guid document_id { get; set; } 
			[DataMember]
			public String document_name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6EX_GPED_0953 cls_Get_Patient_examination_documents(,P_L6EX_GPED_0953 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6EX_GPED_0953 invocationResult = cls_Get_Patient_examination_documents.Invoke(connectionString,P_L6EX_GPED_0953 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Examanations.Complex.Retrieval.P_L6EX_GPED_0953();
parameter.PatientID = ...;

*/
