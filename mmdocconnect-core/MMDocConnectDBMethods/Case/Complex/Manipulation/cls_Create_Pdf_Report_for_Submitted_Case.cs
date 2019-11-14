/* 
 * Generated on 09/21/16 14:40:24
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using BOp.Providers;
using CL1_CMN_CTR;
using CL1_HEC;
using CL1_HEC_CAS;
using CL1_HEC_CRT;
using CSV2Core.Core;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MMDocConnectDBMethods.Archive.Atomic.Manipulation;
using MMDocConnectDBMethods.Archive.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Case.Models;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectUtils;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading;
using System.Web;
using System.Xml.Serialization;

namespace MMDocConnectDBMethods.Case.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Create_Pdf_Report_for_Submitted_Case.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Create_Pdf_Report_for_Submitted_Case
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_CPRfSC_1813 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CPRfSC_1813 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_CAS_CPRfSC_1813();
            returnValue.Result = new CAS_CPRfSC_1813();
            //Put your code here
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");

            var otherCaseIDs = new CAS_GCIDsfPAIDs_1102[] { };
            if (Parameter.CaseData.Where(x => x.CaseType != "op").Any())
            {
                otherCaseIDs = cls_Get_CaseIDs_for_PlannedActionIDs.Invoke(Connection, Transaction, new P_CAS_GCIDsfPAIDs_1102
                {
                    ActionIDs = Parameter.CaseData.Where(x => x.CaseType != "op").Select(t => t.ActionID).ToArray()
                }, securityTicket).Result;
            }

            var casesWithAction = new List<P_CAS_CPRfSC_1813a>();
            foreach (var cas in Parameter.CaseData.Where(x => x.CaseType == "op"))
            {
                if (!casesWithAction.Any(c => c.ActionID == cas.ActionID))
                {
                    casesWithAction.Add(cas);
                }
            }

            var relevantCasesWithAction = casesWithAction.ToDictionary(x => x.ActionID, x => x.CaseID);
            var casesForConcatenation = otherCaseIDs.ToDictionary(x => x.planned_action_id, x => x.case_id);
            if (relevantCasesWithAction.Any())
            {
                relevantCasesWithAction = relevantCasesWithAction.Concat(casesForConcatenation).ToDictionary(x => x.Key, x => x.Value);
            }
            else
            {
                relevantCasesWithAction = casesForConcatenation;
            }

            var caseIdArray = relevantCasesWithAction.Select(x => x.Value).ToArray();
            var patientIds = cls_Get_PatientIDs_for_CaseIDs.Invoke(Connection, Transaction, new P_CAS_GPIDsfCIDs_1650() { CaseIDs = caseIdArray }, securityTicket).Result.Select(t => t.PatientID).ToArray();
            var actionIdArray = Parameter.CaseData.Select(t => t.ActionID).ToArray();

            var octPerformedActionTypeId = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PerformedOct.Value() }, securityTicket).Result;
            var aftercarePerformedActionTypeId = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PerformedAftercare.Value() }, securityTicket).Result;
            var cases = cls_Get_Cases_for_SubmissionReport_for_CaseIDs.Invoke(Connection, Transaction, new P_CAS_GCfSRfCIDs_1855() { CaseIDs = caseIdArray }, securityTicket).Result;

            if (cases.Any())
            {
                var xmlSerializer = new XmlSerializer(typeof(SubmissionReportContent));
                var reader = new StreamReader(Parameter.ReportContentPath);
                var regularSubmissionReportContent = (SubmissionReportContent)xmlSerializer.Deserialize(reader);
                reader.Close();
                SubmissionReportContent documentationOnlySubmissionReportContent = null;

                if (!String.IsNullOrEmpty(Parameter.DocumentationOnlyReportContentPath))
                {
                    reader = new StreamReader(Parameter.DocumentationOnlyReportContentPath);
                    documentationOnlySubmissionReportContent = (SubmissionReportContent)xmlSerializer.Deserialize(reader);
                    reader.Close();
                }


                var patientIdArray = cases.Select(t => t.PatientID).ToArray();

                #region Cache
                var drugNameCache = cls_Get_Drug_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.DrugID)
                   .ToDictionary(t => t.Key, t => t.Single().DrugName);

                var diagnoseDetailsCache = cls_Get_DiagnoseDetails_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.DiagnoseID)
                    .ToDictionary(t => t.Key, t => t.Single());

                var allFsStatuses = cls_Get_Case_FS_Statuses_for_CaseIDs.Invoke(Connection, Transaction, new P_CAS_GCFSSfCIDs_1349() { PatientIDs = patientIdArray }, securityTicket).Result;

                var caseFSStatusCache = allFsStatuses.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());
                var patientFsStatuses = allFsStatuses.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.ToList());

                var doctorDataCache = cls_Get_Doctor_Details_for_Report.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.DoctorID)
                    .ToDictionary(t => t.Key, t => t.Single());

                var patientDataCache = cls_Get_Patient_Details_for_PatientIDs.Invoke(Connection, Transaction, new P_PA_GPDfPIDs_1354() { PatientIDs = patientIdArray }, securityTicket).Result.GroupBy(t => t.PatientID)
                    .ToDictionary(t => t.Key, t => t.Single());

                var patientConsentCache = cls_Get_Patient_Consents_for_PatientIDs.Invoke(Connection, Transaction, new P_PA_GPCfPIDs_1358()
                {
                    PatientIDs = patientIdArray
                }, securityTicket).Result.GroupBy(t => t.Patient_RefID).ToDictionary(t => t.Key, t => t.OrderByDescending(x => x.ValidFrom).ToList());

                var practiceDataCache = cls_Get_Practice_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.PracticeBptID)
                   .ToDictionary(t => t.Key, t => t.Where(pr => pr.StreetName != null).Single());

                var allBillNumbers = cls_Get_BillPositionNumbers_for_CaseIDs.Invoke(Connection, Transaction, new P_CAS_GBPNfCIDs_1112() { PatientIDs = patientIds }, securityTicket).Result;

                var billNumbersForNonOcts = allBillNumbers.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.ToList());
                var billNumbersForOcts = allBillNumbers.GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.ToList());

                var doctorIdCache = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).GroupBy(t => t.BusinessParticipant_RefID)
                    .ToDictionary(t => t.Key, t => t.Single());

                var contractParameterCache = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                var insuranceToBrokerContractsCache = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).
                    GroupBy(t => t.HEC_CRT_InsuranceToBrokerContractID).ToDictionary(t => t.Key, t => t.Single());

                var patientInsurancesCache = cls_Get_Patient_Insurance_Data_for_PatientIDs.Invoke(Connection, Transaction, new P_PA_GPIDfPIDs_1002() { PatientIDs = patientIdArray }, securityTicket).Result.GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t);
                var caseReportProperty = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    GlobalPropertyMatchingID = ECaseProperty.ReportDownloaded.Value()
                }).SingleOrDefault();

                var patientExternalIds = cls_Get_Patient_Properties_for_PatientIDs_and_PropertyGpmID.Invoke(Connection, Transaction, new P_PA_GPPfPIDsaPGpmID_1221()
                {
                    PatientIDs = patientIdArray,
                    PropertyGpmID = EPatientProperty.ExternalId.Value()
                }, securityTicket).Result.GroupBy(x => x.patient_id).ToDictionary(t => t.Key, t => t.Single());

                if (caseReportProperty == null)
                {
                    caseReportProperty = new ORM_HEC_CAS_Case_UniversalProperty();
                    caseReportProperty.GlobalPropertyMatchingID = ECaseProperty.ReportDownloaded.Value();
                    caseReportProperty.IsValue_String = true;
                    caseReportProperty.Modification_Timestamp = DateTime.Now;
                    caseReportProperty.PropertyName = "Case Report Downloaded";
                    caseReportProperty.Tenant_RefID = securityTicket.TenantID;

                    caseReportProperty.Save(Connection, Transaction);
                }

                var casePropertyCache = cls_Get_CasePropertyValues_for_CaseID_and_CasePropertyID.Invoke(Connection, Transaction, new P_CAS_GCPVfCIDaCPID_1540() { CaseIDs = caseIdArray, CasePropertyID = caseReportProperty.HEC_CAS_Case_UniversalPropertyID }, securityTicket).Result;
                var caseDocumentationOnlyProperties = cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID.Invoke(Connection, Transaction, new P_CAS_GCPVfCIDsaCGpmID_0832()
                {
                    CaseIDs = caseIdArray,
                    PropertyGpmID = ECaseProperty.DocumentationOnly.Value()
                }, securityTicket).Result.GroupBy(x => x.CaseID).ToDictionary(t => t.Key, t => t.Single().Value_Boolean);
                var randomGuid = Guid.Empty;
                var documentCache = cls_Get_DocumentData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.Where(t => Guid.TryParse(t.ActionID, out randomGuid)).GroupBy(t => t.ActionID).ToDictionary(t => t.Key, t => t.First());

                var relevantActionsCache = cls_Get_RelevantActionData_for_ActionIDs.Invoke(Connection, Transaction, new P_CAS_GRADfAIDs_1217() { ActionIDs = actionIdArray }, securityTicket).Result
                    .GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.PerformedActionTypeID).ToDictionary(x => x.Key, x => x.ToList()));

                var performedOpDatesCache = cls_Get_PerformedOpDates_for_PatientIDs.Invoke(Connection, Transaction, new P_CAS_GPOpDfPIDs_1509() { PatientIDs = patientIdArray }, securityTicket).Result
                    .GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t);

                var octRelevantActionsCache = cls_Get_OctRelevantActions_for_CaseIDs_and_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GOctRAfCIDsaATID_1626() { PatientIDs = patientIds, ActionTypeID = octPerformedActionTypeId }, securityTicket).Result
                    .GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.ToList());
                #endregion

                var leftColumnWidth = "3.5cm";
                var rightColumnWidth = "20cm";

                var zipNeeded = Parameter.CaseData.Length > 1;
                var filename = String.Format("medios Connect-{0}", DateTime.Now.ToString("yyyy-MM-dd-hhmm"));
                var directoryPath = Path.GetTempPath() + filename;
                var currentFileName = "";

                MemoryStream stream = new MemoryStream();
                if (zipNeeded)
                {
                    if (Directory.Exists(directoryPath))
                        Directory.Delete(directoryPath, true);

                    Directory.CreateDirectory(directoryPath);
                }

                var _providerFactory = ProviderFactory.Instance;
                var documentProvider = _providerFactory.CreateDocumentServiceProvider();
                var fileVersion = 1;

                foreach (var _case in Parameter.CaseData)
                {
                    var currentCaseID = relevantCasesWithAction[_case.ActionID];

                    var caseForReport = cases.Single(t => t.CaseID == currentCaseID);

                    var relevantAction = _case.CaseType == "op" ? null : relevantActionsCache[currentCaseID][_case.CaseType == "oct" ? octPerformedActionTypeId : aftercarePerformedActionTypeId].SingleOrDefault(t => t.ActionID == _case.ActionID);
                    var actionID = _case.ActionID.ToString();
                    if (!Parameter.IsResubmit &&
                        casePropertyCache.Any(t => t.CaseID == currentCaseID &&
                        t.ReportDownloadedFor.Contains(actionID)) && documentCache.ContainsKey(actionID) &&
                        !String.IsNullOrEmpty(documentCache[actionID].DocumentID) &&
                        documentCache[actionID].DocumentID != Guid.Empty.ToString() &&
                        !String.IsNullOrEmpty(documentCache[actionID].DocumentName)
                    )
                    {
                        var document = documentCache[actionID];

                        if (document != null)
                        {
                            var downloadUrl = documentProvider.GenerateDownloadLink(Guid.Parse(document.DocumentID), securityTicket.SessionTicket, true, true);
                            if (zipNeeded)
                            {
                                WebRequest request = WebRequest.Create(downloadUrl);
                                var streamFromRequest = request.GetResponse().GetResponseStream();
                                var tempMemoryStream = new MemoryStream();
                                streamFromRequest.CopyTo(tempMemoryStream);

                                var fname = directoryPath + "\\" + document.DocumentName;
                                if (File.Exists(fname))
                                    fname = directoryPath + "\\" + document.DocumentName.Substring(0, document.DocumentName.IndexOf(".pdf")) + "(" + fileVersion++ + ")" + ".pdf";
                                else
                                    fileVersion = 1;

                                File.WriteAllBytes(fname, tempMemoryStream.ToArray());
                            }
                            else
                            {
                                returnValue.Result.PdfUploaded = downloadUrl;
                                return returnValue;
                            }
                        }
                        else
                        {
                            throw new Exception("Document is null.");
                        }
                    }
                    else
                    {

                        #region Report generation
                        var renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
                        var document = new Document();
                        var docRenderer = new DocumentRenderer(document);
                        var patient = patientDataCache[caseForReport.PatientID];

                        if (caseForReport == null)
                            throw new Exception("Case with id: " + currentCaseID + " not found.");

                        var treatmentDate = _case.CaseType == "op" ? caseForReport.TreatmentDate.Date : relevantAction.PerformedOnDate.Date;
                        var treatmentYearStartDate = DateTime.MinValue;
                        var treatmentYearLength = 365d;

                        var isCaseDocumentationOnly = caseDocumentationOnlyProperties.ContainsKey(caseForReport.CaseID) ? caseDocumentationOnlyProperties[caseForReport.CaseID] : false;
                        var submissionReportContent = isCaseDocumentationOnly && documentationOnlySubmissionReportContent != null ? documentationOnlySubmissionReportContent : regularSubmissionReportContent;

                        #region Page setup
                        var pageSetup = new PageSetup();
                        pageSetup.PageFormat = PageFormat.A4;
                        pageSetup.TopMargin = Unit.FromCentimeter(2.5);
                        pageSetup.BottomMargin = Unit.FromCentimeter(2.0);
                        pageSetup.LeftMargin = Unit.FromCentimeter(2.5);
                        pageSetup.RightMargin = Unit.FromCentimeter(2.0);
                        document.Info.Title = "Übermittlungsbestätigung-" + DateTime.Now.ToString("dd.MM.yyyy");

                        var section = document.AddSection();
                        section.PageSetup = pageSetup;

                        var style = document.Styles["Normal"];
                        style.Font.Name = "Calibri";
                        style.Font.Size = 9;
                        #endregion

                        #region Footer
                        var paragraphFooter = section.Footers.Primary.AddParagraph();
                        paragraphFooter.AddText(Properties.Resources.footerFrom + " ");
                        paragraphFooter.AddPageField();
                        paragraphFooter.AddText(" " + Properties.Resources.footerTo + " ");
                        paragraphFooter.AddNumPagesField();
                        paragraphFooter.Format.Font.Size = 9;
                        paragraphFooter.Format.Alignment = ParagraphAlignment.Right;
                        #endregion

                        #region Logo
                        var ParagraphimageLogo = section.Headers.Primary.AddParagraph();
                        ParagraphimageLogo.Format.Alignment = ParagraphAlignment.Right;
                        var imageLogo = ParagraphimageLogo.AddImage(Parameter.LogoImageUrl);
                        imageLogo.Width = new Unit(5.803, UnitType.Centimeter);
                        imageLogo.Height = new Unit(1.43, UnitType.Centimeter);
                        imageLogo.LockAspectRatio = true;
                        #endregion

                        #region Table
                        var tableHeader = section.AddTable();
                        tableHeader.Borders.Width = 0;
                        var tableColumnLeft = tableHeader.AddColumn("8.25cm");
                        tableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                        var tableColumnRight = tableHeader.AddColumn("8.25cm");
                        tableColumnRight.Format.Alignment = ParagraphAlignment.Right;
                        var row = tableHeader.AddRow();
                        #endregion

                        #region Part under logo
                        var paragraphUnderlogo = row.Cells[1].AddParagraph();
                        paragraphUnderlogo.Format.SpaceBefore = "1cm";
                        paragraphUnderlogo.Format.Font.Size = 10;
                        paragraphUnderlogo.AddText(patient.LastName + ", " + patient.FirstName);
                        paragraphUnderlogo.AddLineBreak();
                        if (patientExternalIds.ContainsKey(patient.PatientID))
                        {
                            var patientExternalId = patientExternalIds[patient.PatientID].string_value;
                            paragraphUnderlogo.AddText(String.Format("{0} {1}", submissionReportContent.PatientID, patientExternalId));
                            paragraphUnderlogo.AddLineBreak();
                        }

                        paragraphUnderlogo.AddText(String.Format("{0} {1}", submissionReportContent.TreatmentDate, treatmentDate.ToString("dd.MM.yyyy")));
                        paragraphUnderlogo.AddLineBreak();
                        #region Bill numbers string
                        var positionType = _case.CaseType == "op" ? "treatment" : _case.CaseType == "oct" ? "oct" : "aftercare";
                        var billNumbersString = "";
                        var index = 0;
                        if (_case.CaseType == "oct")
                        {
                            var billNumbers = billNumbersForOcts[caseForReport.PatientID].Where(t => t.PositionType == positionType).OrderBy(t => Convert.ToInt32(t.BillPositionNumber)).ToList();
                            var relevantOcts = octRelevantActionsCache[patient.PatientID];

                            for (var i = 0; i < relevantOcts.Count; i++)
                            {
                                var relevantOct = relevantOcts[i];
                                if (relevantOct.ActionID == relevantAction.ActionID)
                                {
                                    index = i;
                                    break;
                                }
                            }

                            billNumbers = billNumbers.OrderBy(t => t.BillPositionCreationDate).ToList();
                            if (index >= billNumbers.Count)
                            {
                                var errorMessage = String.Format("Bill number index greater than bill position list. Bill numbers: {0} \n Number of relevant octs: {1} \n Case id: {2} \n Oct id: {3}",
                                    String.Join("; ", billNumbers.Select(t => t.BillPositionNumber)), relevantOcts.Count, currentCaseID, relevantAction.ActionID);
                                throw new Exception(errorMessage);
                            }

                            billNumbersString = billNumbers[index].BillPositionNumber;
                        }
                        else
                        {
                            var billNumbers = billNumbersForNonOcts[caseForReport.CaseID].Where(t => t.PositionType == positionType).OrderBy(t => Convert.ToInt32(t.BillPositionNumber)).ToList();
                            for (var i = 0; i < billNumbers.Count; i++)
                            {
                                billNumbersString += Convert.ToInt32(billNumbers[i].BillPositionNumber).ToString();
                                if (i != billNumbers.Count - 1)
                                    billNumbersString += ", ";
                            }
                        }
                        #endregion

                        paragraphUnderlogo.AddText(String.Format("{0} {1}", submissionReportContent.ReferenceNumber, billNumbersString));
                        paragraphUnderlogo.AddLineBreak();
                        paragraphUnderlogo.Format.Alignment = ParagraphAlignment.Right;
                        #endregion

                        #region Title
                        var titleParagraph = section.AddParagraph();
                        titleParagraph.AddText(submissionReportContent.Title);
                        titleParagraph.Format.SpaceBefore = "0.5cm";
                        titleParagraph.Format.Font.Color = Color.Parse("0xFF1C384F");
                        titleParagraph.Format.Font.Size = 14;
                        titleParagraph.Format.Font.Bold = true;
                        titleParagraph.Format.SpaceAfter = "0.3cm";
                        titleParagraph.Format.Font.Name = "Calibri Light";
                        #endregion

                        #region First paragraph
                        var firstParagraph = section.AddParagraph();
                        var caseType = _case.CaseType == "op" || _case.CaseType == "ac" ? "Behandlung" : "OCT";

                        var submissionDate = DateTime.Now;
                        if (_case.CaseType == "ac")
                        {
                            var fsStatus = caseFSStatusCache[currentCaseID].LastOrDefault(t => t.fs_key == "aftercare");
                            if (fsStatus != null)
                            {
                                submissionDate = fsStatus.status_date;
                            }
                        }
                        else if (_case.CaseType == "oct")
                        {

                            submissionDate = relevantAction.PerformedActionCreationTime;

                        }
                        else
                        {
                            var fsStatus = caseFSStatusCache[currentCaseID].LastOrDefault(t => t.fs_key == "treatment");
                            if (fsStatus != null)
                            {
                                submissionDate = fsStatus.status_date;
                            }
                        }

                        firstParagraph.AddText(submissionReportContent.FirstParagraph.Replace("{{caseType}}", caseType).Replace("{{submissionDate}}", submissionDate.ToString("dd.MM.yyyy")));
                        firstParagraph.Format.SpaceBefore = "0.5cm";
                        firstParagraph.Format.Font.Color = Color.Parse("0x00000000");
                        firstParagraph.Format.Font.Size = 11;
                        firstParagraph.Format.SpaceAfter = "0.3cm";
                        #endregion

                        #region Patient table
                        Table patientTable = section.AddTable();
                        patientTable.Borders.Width = 0;
                        Column patientTableColumnLeft = patientTable.AddColumn(leftColumnWidth);
                        patientTableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                        patientTableColumnLeft.Format.Font.Size = 11;
                        Column patientTableColumnRight = patientTable.AddColumn(rightColumnWidth);
                        patientTableColumnRight.Format.Alignment = ParagraphAlignment.Left;
                        patientTableColumnRight.Format.Font.Size = 11;
                        Row patientRow = patientTable.AddRow();
                        patientRow.Cells[0].AddParagraph(submissionReportContent.Patient);
                        var patientDetailsParagraph = patientRow.Cells[1].AddParagraph();
                        patientDetailsParagraph.Format.Font.Size = 11;
                        var patientTitle = "-";
                        switch (patient.Gender)
                        {
                            case 0: patientTitle = "Herr"; break;
                            case 1: patientTitle = "Frau"; break;
                            default: break;
                        }

                        patientDetailsParagraph.AddText(patientTitle);
                        patientDetailsParagraph.AddLineBreak();
                        patientDetailsParagraph.AddText(patient.LastName);
                        patientDetailsParagraph.AddLineBreak();
                        patientDetailsParagraph.AddText(patient.FirstName);
                        patientDetailsParagraph.AddLineBreak();
                        patientDetailsParagraph.AddText(patient.BirthDate.ToString("dd.MM.yyyy"));
                        patientDetailsParagraph.AddLineBreak();
                        PA_GPIDfPIDs_1002 hipData = null;
                        var hips = patientInsurancesCache[caseForReport.PatientID].Where(t => t.InsuranceDate <= caseForReport.CaseCreationDate);
                        if (hips.Any())
                        {
                            if (hips.First().HipIkNumber != "000000000")
                                hipData = hips.First();
                            else
                                hipData = hips.Last();
                        }

                        patientDetailsParagraph.AddText(hipData.HipName + " (" + hipData.HipIkNumber + ")");
                        patientDetailsParagraph.AddLineBreak();
                        patientDetailsParagraph.AddText(patient.InsuranceIdNumber);
                        patientDetailsParagraph.AddLineBreak();
                        patientDetailsParagraph.AddText(patient.InsuranceStatus);
                        patientDetailsParagraph.AddLineBreak();
                        #endregion

                        #region Consent paragraph
                        if (!String.IsNullOrEmpty(submissionReportContent.SecondParagraph))
                        {
                            var consentValidFrom = DateTime.MinValue;
                            var potentialConsents = patientConsentCache[caseForReport.PatientID].Where(t => t.ValidFrom.Date <= caseForReport.TreatmentDate.Date).ToList();

                            if (potentialConsents.Any())
                            {
                                var latestConsent = potentialConsents.First();
                                var contractId = insuranceToBrokerContractsCache[latestConsent.InsuranceToBrokerContract_RefID].Ext_CMN_CTR_Contract_RefID;
                                var contractParameters = contractParameterCache[contractId];

                                var isConsentRenewedByOp = contractParameters.Any(p => p.ParameterName == "OP renews patient consent");
                                var consentValidForMonths = contractParameters.SingleOrDefault(p => p.ParameterName == "Duration of participation consent – Month");

                                if (isConsentRenewedByOp)
                                {
                                    if (performedOpDatesCache.ContainsKey(caseForReport.PatientID))
                                    {
                                        var patientOpDates = performedOpDatesCache[caseForReport.PatientID];

                                        var latestOp = patientOpDates.FirstOrDefault(t => t.TreatmentDate.Date <= treatmentDate && t.OpActionID != _case.ActionID);
                                        if (latestOp != null)
                                        {
                                            consentValidFrom = latestOp.TreatmentDate;
                                        }

                                        var treatmentYearLengthContractParameter = contractParameters.SingleOrDefault(t => t.ParameterName == "Preexaminations - Days");
                                        if (treatmentYearLengthContractParameter != null)
                                        {
                                            treatmentYearLength = treatmentYearLengthContractParameter.IfNumericValue_Value;
                                        }

                                        var firstPerformedOp = patientOpDates.LastOrDefault(t => t.LocalizationCode == caseForReport.Localization && t.TreatmentDate >= latestConsent.ValidFrom);
                                        if (firstPerformedOp == null)
                                        {
                                            treatmentYearStartDate = caseForReport.TreatmentDate;
                                        }
                                        else
                                        {
                                            var nextTreatmentYearStartDate = firstPerformedOp.TreatmentDate.AddDays(treatmentYearLength);

                                            while (nextTreatmentYearStartDate < treatmentDate)
                                            {
                                                nextTreatmentYearStartDate = nextTreatmentYearStartDate.AddDays(treatmentYearLength);
                                            }

                                            treatmentYearStartDate = nextTreatmentYearStartDate.AddDays(-treatmentYearLength);
                                        }
                                    }

                                    if (consentValidFrom == DateTime.MinValue)
                                    {
                                        if (latestConsent.ValidFrom.Date.AddMonths(Convert.ToInt32(consentValidForMonths != null ? consentValidForMonths.IfNumericValue_Value : 12)) >= treatmentDate)
                                        {
                                            consentValidFrom = latestConsent.ValidFrom;
                                        }
                                    }
                                }
                                else
                                {
                                    for (var i = potentialConsents.Count - 1; i >= 0; i--)
                                    {
                                        var potentialConsent = potentialConsents[i];
                                        if (potentialConsents[i].ValidFrom.Date.AddMonths(Convert.ToInt32(consentValidForMonths != null ? consentValidForMonths.IfNumericValue_Value : 12)) >= treatmentDate)
                                        {
                                            consentValidFrom = potentialConsent.ValidFrom;
                                        }
                                    }
                                }
                            }

                            var consentParagraph = section.AddParagraph();
                            if (consentValidFrom != DateTime.MinValue)
                            {
                                consentParagraph.AddText(submissionReportContent.SecondParagraph.Replace("{{patientConsentStartDate}}", consentValidFrom.ToString("dd.MM.yyyy")));
                            }
                            else
                            {
                                consentParagraph.AddText(submissionReportContent.SecondParagraphNoConsent);
                            }

                            consentParagraph.Format.SpaceBefore = "0.5cm";
                            consentParagraph.Format.Font.Color = Color.Parse("0x00000000");
                            consentParagraph.Format.Font.Size = 11;
                            consentParagraph.Format.SpaceAfter = "0.3cm";
                        }
                        #endregion

                        #region Diagnose table
                        Table diagnoseTable = section.AddTable();
                        diagnoseTable.Format.SpaceAfter = "0.3cm";
                        diagnoseTable.Borders.Width = 0;
                        Column diagnoseTableColumnLeft = diagnoseTable.AddColumn(leftColumnWidth);
                        diagnoseTableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                        diagnoseTableColumnLeft.Format.Font.Size = 11;
                        Column diagnoseTableColumnRight = diagnoseTable.AddColumn(rightColumnWidth);
                        diagnoseTableColumnRight.Format.Alignment = ParagraphAlignment.Left;
                        diagnoseTableColumnRight.Format.Font.Size = 11;
                        Row diagnoseRow = diagnoseTable.AddRow();
                        diagnoseRow.Cells[0].AddParagraph(submissionReportContent.Diagnose);
                        var diagnoseDetailsParagraph = diagnoseRow.Cells[1].AddParagraph();
                        diagnoseDetailsParagraph.Format.Font.Size = 11;
                        diagnoseDetailsParagraph.AddText(diagnoseDetailsCache[caseForReport.DiagnoseID].DiagnoseName + " (" + diagnoseDetailsCache[caseForReport.DiagnoseID].Catalog_DisplayName + ": " + diagnoseDetailsCache[caseForReport.DiagnoseID].DiagnoseCode + ")");
                        diagnoseDetailsParagraph.AddLineBreak();
                        diagnoseDetailsParagraph.AddText(submissionReportContent.ConfirmedDiagnose);
                        diagnoseDetailsParagraph.AddLineBreak();
                        #endregion

                        #region Localization table
                        Table localizationTable = section.AddTable();
                        localizationTable.Format.SpaceAfter = "0.3cm";
                        localizationTable.Borders.Width = 0;
                        Column localizationTableColumnLeft = localizationTable.AddColumn(leftColumnWidth);
                        localizationTableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                        localizationTableColumnLeft.Format.Font.Size = 11;
                        Column localizationTableColumnRight = localizationTable.AddColumn(rightColumnWidth);
                        localizationTableColumnRight.Format.Alignment = ParagraphAlignment.Left;
                        localizationTableColumnRight.Format.Font.Size = 11;
                        Row localizationRow = localizationTable.AddRow();
                        localizationRow.Cells[0].AddParagraph(submissionReportContent.Localization);
                        var localizationDetailsParagraph = localizationRow.Cells[1].AddParagraph();
                        localizationDetailsParagraph.Format.Font.Size = 11;

                        localizationDetailsParagraph.AddText(caseForReport.Localization);
                        localizationDetailsParagraph.AddLineBreak();
                        #endregion

                        if (_case.CaseType != "oct")
                        {
                            #region Drug table
                            Table drugTable = section.AddTable();
                            drugTable.Format.SpaceAfter = "0.3cm";
                            drugTable.Borders.Width = 0;
                            Column drugTableColumnLeft = drugTable.AddColumn(leftColumnWidth);
                            drugTableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                            drugTableColumnLeft.Format.Font.Size = 11;
                            Column drugTableColumnRight = drugTable.AddColumn(rightColumnWidth);
                            drugTableColumnRight.Format.Alignment = ParagraphAlignment.Left;
                            drugTableColumnRight.Format.Font.Size = 11;
                            Row drugRow = drugTable.AddRow();
                            drugRow.Cells[0].AddParagraph(submissionReportContent.Drug);
                            var drugDetailsParagraph = drugRow.Cells[1].AddParagraph();
                            drugDetailsParagraph.Format.Font.Size = 11;
                            drugDetailsParagraph.AddText(drugNameCache[caseForReport.DrugID]);
                            drugDetailsParagraph.AddLineBreak();
                            #endregion
                        }

                        #region Case type table
                        Table caseTypeTable = section.AddTable();
                        caseTypeTable.Format.SpaceAfter = "0.3cm";
                        caseTypeTable.Borders.Width = 0;
                        Column caseTypeTableColumnLeft = caseTypeTable.AddColumn(leftColumnWidth);
                        caseTypeTableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                        caseTypeTableColumnLeft.Format.Font.Size = 11;
                        Column caseTypeTableColumnRight = caseTypeTable.AddColumn(rightColumnWidth);
                        caseTypeTableColumnRight.Format.Alignment = ParagraphAlignment.Left;
                        caseTypeTableColumnRight.Format.Font.Size = 11;
                        Row caseTypeRow = caseTypeTable.AddRow();
                        caseTypeRow.Cells[0].AddParagraph(submissionReportContent.CaseType);
                        var caseTypeDetailsParagraph = caseTypeRow.Cells[1].AddParagraph();
                        caseTypeDetailsParagraph.Format.Font.Size = 11;

                        caseTypeDetailsParagraph.AddText(_case.CaseType == "op" ? "OP" : _case.CaseType == "ac" ? "Nachsorge" : "OCT");
                        caseTypeDetailsParagraph.AddLineBreak();
                        #endregion

                        #region Treatment date table
                        Table treatmentDateTable = section.AddTable();
                        treatmentDateTable.Format.SpaceAfter = "0.3cm";
                        treatmentDateTable.Borders.Width = 0;
                        Column treatmentDateTableColumnLeft = treatmentDateTable.AddColumn(leftColumnWidth);
                        treatmentDateTableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                        treatmentDateTableColumnLeft.Format.Font.Size = 11;
                        Column treatmentDateTableColumnRight = treatmentDateTable.AddColumn(rightColumnWidth);
                        treatmentDateTableColumnRight.Format.Alignment = ParagraphAlignment.Left;
                        treatmentDateTableColumnRight.Format.Font.Size = 11;
                        Row treatmentDateRow = treatmentDateTable.AddRow();
                        treatmentDateRow.Cells[0].AddParagraph(submissionReportContent.TreatmentDate);
                        var treatmentDateDetailsParagraph = treatmentDateRow.Cells[1].AddParagraph();
                        treatmentDateDetailsParagraph.Format.Font.Size = 11;
                        treatmentDateDetailsParagraph.AddText(treatmentDate.ToString("dd.MM.yyyy"));
                        treatmentDateDetailsParagraph.AddLineBreak();
                        #endregion

                        if (treatmentYearStartDate != DateTime.MinValue)
                        {
                            #region Treatment year start date table
                            Table treatmentYearDateTable = section.AddTable();
                            treatmentYearDateTable.Format.SpaceAfter = "0.3cm";
                            treatmentYearDateTable.Borders.Width = 0;
                            Column treatmentYearDateTableColumnLeft = treatmentYearDateTable.AddColumn(leftColumnWidth);
                            treatmentYearDateTableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                            treatmentYearDateTableColumnLeft.Format.Font.Size = 11;
                            Column treatmentYearDateTableColumnRight = treatmentYearDateTable.AddColumn(rightColumnWidth);
                            treatmentYearDateTableColumnRight.Format.Alignment = ParagraphAlignment.Left;
                            treatmentYearDateTableColumnRight.Format.Font.Size = 11;
                            Row treatmentYearDateRow = treatmentYearDateTable.AddRow();
                            treatmentYearDateRow.Cells[0].AddParagraph(submissionReportContent.TreatmentYear);
                            var treatmentYearDateDetailsParagraph = treatmentYearDateRow.Cells[1].AddParagraph();
                            treatmentYearDateDetailsParagraph.Format.Font.Size = 11;
                            treatmentYearDateDetailsParagraph.AddText(String.Format("{0} – {1}", treatmentYearStartDate.ToString("dd.MM.yyyy"), treatmentYearStartDate.AddDays(treatmentYearLength).ToString("dd.MM.yyyy")));
                            treatmentYearDateDetailsParagraph.AddLineBreak();
                            #endregion
                        }

                        #region First doctor table
                        var firstDoctorID = _case.CaseType == "op" ? caseForReport.TreatmentDoctorID : doctorIdCache[relevantAction.PerformingBptID].HEC_DoctorID;

                        Table firstDoctorTable = section.AddTable();
                        firstDoctorTable.Format.SpaceAfter = "0.3cm";
                        firstDoctorTable.Borders.Width = 0;
                        Column firstDoctorTableColumnLeft = firstDoctorTable.AddColumn(leftColumnWidth);
                        firstDoctorTableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                        firstDoctorTableColumnLeft.Format.Font.Size = 11;
                        Column firstDoctorTableColumnRight = firstDoctorTable.AddColumn(rightColumnWidth);
                        firstDoctorTableColumnRight.Format.Alignment = ParagraphAlignment.Left;
                        firstDoctorTableColumnRight.Format.Font.Size = 11;
                        Row firstDoctorRow = firstDoctorTable.AddRow();
                        firstDoctorRow.Cells[0].AddParagraph(submissionReportContent.TreatmentDoctor);
                        var firstDoctorDetailsParagraph = firstDoctorRow.Cells[1].AddParagraph();
                        firstDoctorDetailsParagraph.Format.Font.Size = 11;

                        firstDoctorDetailsParagraph.AddText(doctorDataCache[firstDoctorID].Salutation_General + " " + doctorDataCache[firstDoctorID].Title);
                        firstDoctorDetailsParagraph.AddLineBreak();
                        firstDoctorDetailsParagraph.AddText(doctorDataCache[firstDoctorID].LastName);
                        firstDoctorDetailsParagraph.AddLineBreak();
                        firstDoctorDetailsParagraph.AddText(doctorDataCache[firstDoctorID].FirstName);
                        firstDoctorDetailsParagraph.AddLineBreak();
                        firstDoctorDetailsParagraph.AddText(doctorDataCache[firstDoctorID].DoctorLANR);
                        firstDoctorDetailsParagraph.AddLineBreak();

                        #endregion

                        #region First doctors practice table
                        Table firstDoctorsPracticeTable = section.AddTable();
                        firstDoctorsPracticeTable.Format.SpaceAfter = "0.3cm";
                        firstDoctorsPracticeTable.Borders.Width = 0;
                        Column firstDoctorsPracticeTableColumnLeft = firstDoctorsPracticeTable.AddColumn(leftColumnWidth);
                        firstDoctorsPracticeTableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                        firstDoctorsPracticeTableColumnLeft.Format.Font.Size = 11;
                        Column firstDoctorsPracticeTableColumnRight = firstDoctorsPracticeTable.AddColumn(rightColumnWidth);
                        firstDoctorsPracticeTableColumnRight.Format.Alignment = ParagraphAlignment.Left;
                        firstDoctorsPracticeTableColumnRight.Format.Font.Size = 11;
                        Row firstDoctorsPracticeRow = firstDoctorsPracticeTable.AddRow();
                        firstDoctorsPracticeRow.Cells[0].AddParagraph(submissionReportContent.Practice);
                        var firstDoctorsPracticeDetailsParagraph = firstDoctorsPracticeRow.Cells[1].AddParagraph();
                        firstDoctorsPracticeDetailsParagraph.Format.Font.Size = 11;

                        firstDoctorsPracticeDetailsParagraph.AddText(practiceDataCache[doctorDataCache[firstDoctorID].PracticeBPTID].PracticeName);
                        firstDoctorsPracticeDetailsParagraph.AddLineBreak();
                        firstDoctorsPracticeDetailsParagraph.AddText(practiceDataCache[doctorDataCache[firstDoctorID].PracticeBPTID].PracticeBSNR);
                        firstDoctorsPracticeDetailsParagraph.AddLineBreak();
                        firstDoctorsPracticeDetailsParagraph.AddText(practiceDataCache[doctorDataCache[firstDoctorID].PracticeBPTID].StreetName + " " + practiceDataCache[doctorDataCache[firstDoctorID].PracticeBPTID].StreetNumber);
                        firstDoctorsPracticeDetailsParagraph.AddLineBreak();
                        firstDoctorsPracticeDetailsParagraph.AddText(practiceDataCache[doctorDataCache[firstDoctorID].PracticeBPTID].ZIP + " " + practiceDataCache[doctorDataCache[firstDoctorID].PracticeBPTID].City);
                        firstDoctorsPracticeDetailsParagraph.AddLineBreak();

                        #endregion

                        #region OP date
                        if (_case.CaseType == "ac")
                        {
                            Table opDateTable = section.AddTable();
                            opDateTable.Format.SpaceAfter = "0.3cm";
                            opDateTable.Borders.Width = 0;
                            Column opDateTableColumnLeft = opDateTable.AddColumn(leftColumnWidth);
                            opDateTableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                            opDateTableColumnLeft.Format.Font.Size = 11;
                            Column opDateTableColumnRight = opDateTable.AddColumn(rightColumnWidth);
                            opDateTableColumnRight.Format.Alignment = ParagraphAlignment.Left;
                            opDateTableColumnRight.Format.Font.Size = 11;
                            Row opDateRow = opDateTable.AddRow();
                            opDateRow.Cells[0].AddParagraph(submissionReportContent.OpDate);
                            var opDateDetailsParagraph = opDateRow.Cells[1].AddParagraph();
                            opDateDetailsParagraph.Format.Font.Size = 11;
                            opDateDetailsParagraph.AddText(caseForReport.TreatmentDate.ToString("dd.MM.yyyy"));
                            opDateDetailsParagraph.AddLineBreak();
                        }
                        #endregion

                        if (_case.CaseType == "ac" || _case.CaseType == "oct")
                        {

                            #region Second doctor table
                            var secondDoctorID = caseForReport.TreatmentDoctorID;

                            Table secondDoctorTable = section.AddTable();
                            secondDoctorTable.Format.SpaceAfter = "0.3cm";
                            secondDoctorTable.Borders.Width = 0;
                            Column secondDoctorTableColumnLeft = secondDoctorTable.AddColumn(leftColumnWidth);
                            secondDoctorTableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                            secondDoctorTableColumnLeft.Format.Font.Size = 11;
                            Column secondDoctorTableColumnRight = secondDoctorTable.AddColumn(rightColumnWidth);
                            secondDoctorTableColumnRight.Format.Alignment = ParagraphAlignment.Left;
                            secondDoctorTableColumnRight.Format.Font.Size = 11;
                            Row secondDoctorRow = secondDoctorTable.AddRow();
                            secondDoctorRow.Cells[0].AddParagraph(submissionReportContent.OpDoctor);
                            var secondDoctorDetailsParagraph = secondDoctorRow.Cells[1].AddParagraph();
                            secondDoctorDetailsParagraph.Format.Font.Size = 11;

                            if (secondDoctorID != Guid.Empty)
                            {
                                secondDoctorDetailsParagraph.AddText(string.IsNullOrEmpty(doctorDataCache[secondDoctorID].Salutation_General) && string.IsNullOrEmpty(doctorDataCache[secondDoctorID].Title) ? "-" : doctorDataCache[secondDoctorID].Salutation_General + " " + doctorDataCache[secondDoctorID].Title);
                                secondDoctorDetailsParagraph.AddLineBreak();
                                secondDoctorDetailsParagraph.AddText(doctorDataCache[secondDoctorID].LastName);
                                secondDoctorDetailsParagraph.AddLineBreak();
                                secondDoctorDetailsParagraph.AddText(string.IsNullOrEmpty(doctorDataCache[secondDoctorID].FirstName) ? "-" : doctorDataCache[secondDoctorID].FirstName);
                                secondDoctorDetailsParagraph.AddLineBreak();
                                secondDoctorDetailsParagraph.AddText(string.IsNullOrEmpty(doctorDataCache[secondDoctorID].DoctorLANR) ? "-" : doctorDataCache[secondDoctorID].DoctorLANR);
                                secondDoctorDetailsParagraph.AddLineBreak();
                            }
                            else
                            {
                                secondDoctorDetailsParagraph.AddText("-");
                                secondDoctorDetailsParagraph.AddLineBreak();
                            }

                            #endregion

                            #region Second doctors practice table
                            Table secondDoctorsPracticeTable = section.AddTable();
                            secondDoctorsPracticeTable.Format.SpaceAfter = "0.3cm";
                            secondDoctorsPracticeTable.Borders.Width = 0;
                            Column secondDoctorsPracticeTableColumnLeft = secondDoctorsPracticeTable.AddColumn(leftColumnWidth);
                            secondDoctorsPracticeTableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                            secondDoctorsPracticeTableColumnLeft.Format.Font.Size = 11;
                            Column secondDoctorsPracticeTableColumnRight = secondDoctorsPracticeTable.AddColumn(rightColumnWidth);
                            secondDoctorsPracticeTableColumnRight.Format.Alignment = ParagraphAlignment.Left;
                            secondDoctorsPracticeTableColumnRight.Format.Font.Size = 11;
                            Row secondDoctorsPracticeRow = secondDoctorsPracticeTable.AddRow();
                            secondDoctorsPracticeRow.Cells[0].AddParagraph(submissionReportContent.OpPractice);
                            var secondDoctorsPracticeDetailsParagraph = secondDoctorsPracticeRow.Cells[1].AddParagraph();
                            secondDoctorsPracticeDetailsParagraph.Format.Font.Size = 11;

                            var practiceID = secondDoctorID != Guid.Empty ? doctorDataCache[secondDoctorID].PracticeBPTID : relevantAction.PerformingBptID;
                            if (practiceDataCache.ContainsKey(practiceID))
                            {
                                secondDoctorsPracticeDetailsParagraph.AddText(practiceDataCache[practiceID].PracticeName);
                                secondDoctorsPracticeDetailsParagraph.AddLineBreak();
                                secondDoctorsPracticeDetailsParagraph.AddText(practiceDataCache[practiceID].PracticeBSNR);
                                secondDoctorsPracticeDetailsParagraph.AddLineBreak();
                                secondDoctorsPracticeDetailsParagraph.AddText(practiceDataCache[practiceID].StreetName + " " + practiceDataCache[practiceID].StreetNumber);
                                secondDoctorsPracticeDetailsParagraph.AddLineBreak();
                                secondDoctorsPracticeDetailsParagraph.AddText(practiceDataCache[practiceID].ZIP + " " + practiceDataCache[practiceID].City);
                                secondDoctorsPracticeDetailsParagraph.AddLineBreak();
                            }
                            else
                            {
                                secondDoctorsPracticeDetailsParagraph.AddText("-");
                                secondDoctorsPracticeDetailsParagraph.AddLineBreak();
                            }
                            #endregion
                        }

                        #region Footer
                        Paragraph footerParagraph = section.AddParagraph();
                        footerParagraph.AddText(submissionReportContent.Footer);
                        footerParagraph.Format.SpaceBefore = "0.5cm";
                        footerParagraph.Format.Font.Color = Color.Parse("0x00000000");
                        footerParagraph.Format.Font.Size = 11;
                        footerParagraph.Format.SpaceAfter = "0.3cm";
                        #endregion

                        //save and download document
                        renderer.Document = document;
                        renderer.RenderDocument();
                        int pages = renderer.PdfDocument.Pages.Count;

                        //Add lines to document
                        for (int i = 0; i < pages; i++)
                        {
                            XGraphics gfx = XGraphics.FromPdfPage(renderer.PdfDocument.Pages[i]);
                            gfx.DrawLine(XPens.Black, new Unit(0, UnitType.Centimeter), new Unit(10.5, UnitType.Centimeter), new Unit(1.08, UnitType.Centimeter), new Unit(10.5, UnitType.Centimeter));
                            gfx.DrawLine(XPens.Black, new Unit(0, UnitType.Centimeter), new Unit(15, UnitType.Centimeter), new Unit(1.08, UnitType.Centimeter), new Unit(15, UnitType.Centimeter));
                        }

                        renderer.Save(stream, false);
                        #endregion

                        currentFileName = String.Format("{0}, {1}-{2}-{3}-{4}.pdf", patient.LastName, patient.FirstName, patient.BirthDate.ToString("dd.MM.yyyy"), caseForReport.Localization, treatmentDate.ToString("dd.MM.yyyy"));

                        if (zipNeeded)
                        {
                            var fname = directoryPath + "\\" + currentFileName;
                            if (File.Exists(fname))
                            {
                                fname = directoryPath + "\\" + currentFileName.Substring(0, currentFileName.IndexOf(".pdf")) + "(" + fileVersion++ + ")" + ".pdf";
                            }
                            else
                            {
                                fileVersion = 1;
                            }

                            File.WriteAllBytes(fname, stream.ToArray());
                            var docID = documentProvider.UploadDocument(stream.ToArray(), currentFileName, securityTicket.SessionTicket, Parameter.UploadedFrom);

                            cls_Upload_Case_PDF_Report.Invoke(Connection, Transaction, new P_ARCH_UCPD_0950()
                            {
                                CaseID = caseForReport.CaseID,
                                CaseType = _case.CaseType,
                                DocumentID = docID,
                                DocumentName = currentFileName,
                                Mime = UtilMethods.GetMimeType(currentFileName),
                                PlannedActionID = _case.ActionID,
                                IsBackgroundTask = Parameter.IsBackgroundTask
                            }, securityTicket);
                        }
                    }
                }

                byte[] bytes = new byte[] { };
                var zipName = "";
                if (zipNeeded)
                {
                    zipName = Path.GetTempPath() + "\\" + filename + ".zip";
                    ZipFile.CreateFromDirectory(directoryPath, zipName);
                    using (FileStream fs = new FileStream(zipName, FileMode.Open))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            bytes = ms.ToArray();
                        }
                    }
                }
                else
                {
                    if (currentFileName == "")
                    {
                        throw new Exception("Empty file name.");
                    }

                    bytes = stream.ToArray();
                }

                var mime = UtilMethods.GetMimeType(zipNeeded ? filename + ".zip" : currentFileName);
                var documentID = documentProvider.UploadDocument(bytes, zipNeeded ? filename + ".zip" : currentFileName, securityTicket.SessionTicket, Parameter.UploadedFrom);
                returnValue.Result.PdfUploaded = documentProvider.GenerateDownloadLink(documentID, securityTicket.SessionTicket, true, true);

                if (zipNeeded)
                {
                    Directory.Delete(directoryPath, true);
                    File.Delete(zipName);
                }
                else
                {
                    var caseData = Parameter.CaseData.Single();
                    cls_Upload_Case_PDF_Report.Invoke(Connection, Transaction, new P_ARCH_UCPD_0950()
                    {
                        CaseID = caseData.CaseID,
                        CaseType = caseData.CaseType,
                        DocumentID = documentID,
                        DocumentName = currentFileName,
                        Mime = UtilMethods.GetMimeType(currentFileName),
                        PlannedActionID = caseData.ActionID,
                        IsBackgroundTask = Parameter.IsBackgroundTask
                    }, securityTicket);
                }
            }
            else
            {
                throw new Exception("No cases found.");
            }
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_CPRfSC_1813 Invoke(string ConnectionString, P_CAS_CPRfSC_1813 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_CPRfSC_1813 Invoke(DbConnection Connection, P_CAS_CPRfSC_1813 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_CPRfSC_1813 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CPRfSC_1813 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_CPRfSC_1813 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CPRfSC_1813 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_CPRfSC_1813 functionReturn = new FR_CAS_CPRfSC_1813();
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

                throw new Exception("Exception occured in method cls_Create_Pdf_Report_for_Submitted_Case", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_CPRfSC_1813 : FR_Base
    {
        public CAS_CPRfSC_1813 Result { get; set; }

        public FR_CAS_CPRfSC_1813() : base() { }

        public FR_CAS_CPRfSC_1813(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_CPRfSC_1813 for attribute P_CAS_CPRfSC_1813
    [DataContract]
    public class P_CAS_CPRfSC_1813
    {
        [DataMember]
        public P_CAS_CPRfSC_1813a[] CaseData { get; set; }

        //Standard type parameters
        [DataMember]
        public String ReportContentPath { get; set; }
        [DataMember]
        public String DocumentationOnlyReportContentPath { get; set; }
        [DataMember]
        public String UploadedFrom { get; set; }
        [DataMember]
        public String LogoImageUrl { get; set; }
        [DataMember]
        public Boolean IsResubmit { get; set; }
        [DataMember]
        public Boolean IsBackgroundTask { get; set; }

    }
    #endregion
    #region SClass P_CAS_CPRfSC_1813a for attribute CaseData
    [DataContract]
    public class P_CAS_CPRfSC_1813a
    {
        //Standard type parameters
        [DataMember]
        public Guid ActionID { get; set; }
        [DataMember]
        public Guid CaseID { get; set; }
        [DataMember]
        public String CaseType { get; set; }

    }
    #endregion
    #region SClass CAS_CPRfSC_1813 for attribute CAS_CPRfSC_1813
    [DataContract]
    public class CAS_CPRfSC_1813
    {
        //Standard type parameters
        [DataMember]
        public String PdfUploaded { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_CPRfSC_1813 cls_Create_Pdf_Report_for_Submitted_Case(,P_CAS_CPRfSC_1813 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_CPRfSC_1813 invocationResult = cls_Create_Pdf_Report_for_Submitted_Case.Invoke(connectionString,P_CAS_CPRfSC_1813 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Manipulation.P_CAS_CPRfSC_1813();
parameter.CaseData = ...;

parameter.ReportContentPath = ...;
parameter.UploadedFrom = ...;
parameter.LogoImageUrl = ...;
parameter.IsResubmit = ...;
parameter.IsBackgroundTask = ...;

*/
