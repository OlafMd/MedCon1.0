/* 
 * Generated on 05.03.2014 14:43:08
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
using EdifactInterface;
using CL6_Lucenits_Treatments.Complex.Retrieval;
using CL1_BIL;
using CL5_Lucentis_Doctors.Atomic.Retrieval;
using System.Net.Mail;
using System.IO;
using CL6_Lucenits_Treatments.Utils;
using System.Web;
using Core_ClassLibrarySupport.Utils;
using System.Net.Mime;

namespace CL6_Lucenits_Treatments.Complex.Manipulation
{
	/// <summary>
	/// 
	/// <example>
	/// string connectionString = ...;
	/// var result = cls_MakeReportData_forTreatments.Invoke(connectionString).Result;
	/// </example>
	/// </summary>
	[DataContract]
	public class cls_MakeReportData_forTreatments
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_MRDfTre_1300 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 

			FR_Base returnValue = new FR_Base();
			returnValue.Status = FR_Status.Error_Internal;

			List<Converter> listOfConvertesForEdifactFiles = new List<Converter>();

			string excelFileName = string.Empty;
			Guid headerID = Guid.Empty;    

			List<ExcelOutput> allExcelData = new List<ExcelOutput>();

			L6TR_GTBDpHICfID_1130 collectedData = null;
			if (Parameter.IsTreatment)
			{
				collectedData = cls_Get_TreatmentBillingData_per_HICompany_byIDs.Invoke(Connection, Transaction, new P_L6TR_GTBDpHICfID_1130() { TreatmentID_List = Parameter.TreatmentID_List }, securityTicket).Result;
			}
			else
			{
				collectedData = cls_Get_FollowupBillingData_per_HICompany_byIDs.Invoke(Connection, Transaction, new P_L6TR_GFBDpHICfID_1412() { TreatmentID_List = Parameter.TreatmentID_List }, securityTicket).Result.Data;
			}

			#region HeaderNum
			var tenantHeaders = ORM_BIL_BillHeader.Query.Search(Connection, Transaction, new ORM_BIL_BillHeader.Query()
			{
				Tenant_RefID = securityTicket.TenantID,
				IsDeleted = false
			}).ToArray();
			tenantHeaders = tenantHeaders.OrderBy(t => t.Creation_Timestamp).ToArray();
			//var headersForThisYear = tenantHeaders.Where(h => h.Creation_Timestamp.Year == DateTime.Now.Year).ToArray(); // This was when we needed to restart the numbers at the end of each year
            var headersForThisYear = tenantHeaders;

			int prevMaxHeaderNumber = 0;
			long previousMaxPositionIndex = 0;
			if (headersForThisYear.Length > 0)
			{
				ORM_BIL_BillHeader prevHeader = null;
				foreach (var headerTY in headersForThisYear)
				{
					int hn = 0;
					if (int.TryParse(headerTY.BillNumber, out hn) && prevMaxHeaderNumber <= hn)
					{
						prevMaxHeaderNumber = hn;
						prevHeader = headerTY;
					}
				}


				if (prevHeader != null)
				{
					var positionQuery = new ORM_BIL_BillPosition.Query();
					positionQuery.Tenant_RefID = securityTicket.TenantID;
					positionQuery.BIL_BilHeader_RefID = prevHeader.BIL_BillHeaderID;
					var prevPositions = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, positionQuery).ToArray();
					if (prevPositions != null && prevPositions.Length > 0)
					{
						foreach (var prevPosition in prevPositions)
						{
							long number = 0;
							if (long.TryParse(prevPosition.External_PositionReferenceField, out number) && previousMaxPositionIndex < number)
							{
								previousMaxPositionIndex = number;
							}
						}
					}
				}
			}
			var edifactRes = ORM_BIL_BillHeaderExtension_EDIFACT.Query.Search(Connection, Transaction, new ORM_BIL_BillHeaderExtension_EDIFACT.Query()
			{
				Tenant_RefID = securityTicket.TenantID
			});
			#endregion

			int currentEdifatNumber = edifactRes.Where(e => e.Creation_Timestamp.Year == DateTime.Now.Year).Count() + 1;
			int currentHeaderNumber = prevMaxHeaderNumber + 1;
			long currentMaxPositionNumber = previousMaxPositionIndex;

			if (Parameter.IsBilling)
			{
				ORM_BIL_BillHeader header = new ORM_BIL_BillHeader();
				header.Tenant_RefID = securityTicket.TenantID;
				header.BIL_BillHeaderID = Guid.NewGuid();
				header.BillNumber = currentHeaderNumber.ToString();
				header.Save(Connection, Transaction);
				headerID = header.BIL_BillHeaderID;
			}

			foreach (var dataPerCompany in collectedData.HICompanies)
			{
				List<BillingInfo> listBInfo = new List<BillingInfo>();
				foreach (var pos in dataPerCompany.Positions)
				{
					List<ArticleInfo> articleList = new List<ArticleInfo>();
					List<DiagnosisInfo> diagnosisList = new List<DiagnosisInfo>();

					foreach (var art in pos.ArticleInfos)
						articleList.Add(new ArticleInfo(art.ArticleID.ToString(), art.Name.GetContent(Parameter.LanguageID), art.PZN, Convert.ToInt32(art.Quantity)));

					foreach (var diag in pos.DiagnosisInfos)
						diagnosisList.Add(new DiagnosisInfo(diag.strDiagnosisICD10, diag.cDiagnosisState.ToCharArray()[0]));

					listBInfo.Add(new BillingInfo(
						!pos.bTreatmentIsFollowup ? pos.TreatmentID.ToString() : pos.FollowupID.ToString(),
						pos.iPatientInsuranceState,
						pos.PatientInsuranceNumber,
						pos.iPatientSex,
						pos.PatientFirstName,
						pos.PatientLastName,
						pos.dtPatientBirthDate,
						pos.strDoctorLANR,
						pos.strPracticeBSNR,
						diagnosisList,
						pos.cTreatmentLocalization.ToCharArray()[0],
						pos.bTreatmentIsFollowup,
						pos.iTreatmentNumber,
						articleList,
						pos.dtTreatment,
						pos.strFollowupPractice,
						pos.strFollowupDoctor,
						pos.strFollowupStatus,
						pos.dtFollowup));
				}

				Converter converter = new Converter(currentEdifatNumber, currentHeaderNumber, currentMaxPositionNumber,
					dataPerCompany.Positions.OrderBy(p => p.dtTreatment).First().dtTreatment, dataPerCompany.Positions.OrderBy(p => p.dtTreatment).Last().dtTreatment,
					listBInfo, dataPerCompany.HealthInsurance_Number, false);

				listOfConvertesForEdifactFiles.Add(converter);
				var excelData = converter.getExcel();

				if (excelFileName == string.Empty)
					excelFileName = converter.getExcelFilename();

				allExcelData.AddRange(excelData);

				#region  Save GPOS, charged value, Additional position compensation, Relevant article and article quantity (if is billing)
				if (Parameter.IsBilling)
				{
					var persistParam = new P_L6TR_PBD_1706()
					{
						EdifactNumber = currentEdifatNumber,
						HeaderID = headerID,
						OutputData = excelData.ToArray()
					};
					cls_Persist_TreatmentsBillData.Invoke(Connection, Transaction, persistParam, securityTicket);
				}
				#endregion

				currentEdifatNumber++;
				currentMaxPositionNumber = excelData.Max(e => e.iProcessNumber);
			}

			List<String> LANR = allExcelData.Select(x => x.strDoctorLANR).ToList();
			P_L5DO_GDDfLfR_1409 parameterDoctorData = new P_L5DO_GDDfLfR_1409();
			parameterDoctorData.LANR = LANR.ToArray();
			List<L5DO_GDDfLfR_1409> doctorData = cls_Get_DoctorData_for_LANR_for_Reports.Invoke(Connection, Transaction, parameterDoctorData, securityTicket).Result.ToList();

			List<Attachment> atts = new List<Attachment>();
			string file = ReportUtils.generateBillTreatmentsXLS(allExcelData, doctorData);

			MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));
			atts.Add(new System.Net.Mail.Attachment(ms, excelFileName));

			foreach (var converter in listOfConvertesForEdifactFiles)
			{
				var edifact = converter.getEdifact();

				var tempFilePath = Path.GetTempFileName();
				using (System.IO.StreamWriter tempFile = new System.IO.StreamWriter(tempFilePath, true))
				{
					tempFile.Write(converter.getAuf(1));
				}
				long tempFileSize = 0;
				if(File.Exists(tempFilePath))
				{
					FileInfo fi = new FileInfo(tempFilePath);
					tempFileSize = fi.Length;
					fi.Delete();
				}
				atts.Add(Attachment.CreateAttachmentFromString(edifact, converter.getEdifactFilename()));
				atts.Add(Attachment.CreateAttachmentFromString(converter.getAuf(tempFileSize), converter.getAufFilename()));
			}

            string[] toMails;
            string mailRes = (String)HttpContext.GetGlobalResourceObject("Global", "ReportMails");
#if DEBUG
            mailRes = (String)HttpContext.GetGlobalResourceObject("Global", "ReportMailsDebug");

#endif
            toMails = mailRes.Split(';');
            string subjectRes = (String)HttpContext.GetGlobalResourceObject("Global", "ReportMailSubject");

            EmailUtils.SendMail(toMails, subjectRes, "", atts);









			// @Laci, ako budes se prebacivao na thread odkomentarisi ovaj kod ispod

			//Thread emailThread = new Thread(() =>
			//{
			//    IEmail acceptEmail = EmailFactory.BasicEmail();
			//    acceptEmail.sendMailNotifier(toMails.ToList(), subjectRes, "", atts);
			//});
			//emailThread.Start();

			returnValue.Status = FR_Status.Success;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L6TR_MRDfTre_1300 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L6TR_MRDfTre_1300 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_MRDfTre_1300 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_MRDfTre_1300 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				 throw new Exception("Exception occured in method cls_MakeReportData_forTreatments",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6TR_MRDfTre_1300 for attribute P_L6TR_MRDfTre_1300
		[DataContract]
		public class P_L6TR_MRDfTre_1300 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] TreatmentID_List { get; set; } 
			[DataMember]
			public bool IsBilling { get; set; } 
			[DataMember]
			public bool IsTreatment { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_MakeReportData_forTreatments(,P_L6TR_MRDfTre_1300 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_MakeReportData_forTreatments.Invoke(connectionString,P_L6TR_MRDfTre_1300 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Complex.Manipulation.P_L6TR_MRDfTre_1300();
parameter.TreatmentID_List = ...;
parameter.IsBilling = ...;
parameter.IsTreatment = ...;
parameter.LanguageID = ...;

*/
