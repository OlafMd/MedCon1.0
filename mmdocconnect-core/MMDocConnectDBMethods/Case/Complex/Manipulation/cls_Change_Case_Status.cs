/* 
 * Generated on 08/30/17 10:28:20
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
using System.Runtime.Serialization;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils.ExcelTemplates;
using CL1_BIL;
using CL1_HEC_CAS;
using CL1_CMN_CTR;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectUtils;
using System.Globalization;
using System.IO;
using BOp.Providers;
using System.Web;
using MMDocConnectDBMethods.Archive.Complex.Manipulation;
using MMDocConnectDBMethods.Archive.Atomic.Retrieval;
using Edifact_API;
using Edifact_API.Models;
using MMDocConnectDocApp;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using System.Web.Configuration;
using System.Threading;
using LogUtils;
using MMDocConnectDBMethods.Properties;
using System.Security.Cryptography;
using System.Text;
using MMDocConnectDBMethods.MainData.Atomic.Manipulation;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;

namespace MMDocConnectDBMethods.Case.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Change_Case_Status.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Change_Case_Status
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_CCS_1516 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CCS_1516 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode

            #region Thread cultrue
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            var germanCulture = new CultureInfo("de-de");
            #endregion

            #region Local variables
            var returnValue = new FR_CAS_CCS_1516();
            returnValue.Result = new CAS_CCS_1516();
            var settlements = new List<Settlement_Model>();
            var patientDetailList = new List<PatientDetailViewModel>();
            var cases_to_submit = new List<Submitted_Case_Model>();
            var documents = new List<Documents>();
            var statusChangedOnDate = Parameter.StatusChangedOnDate == DateTime.MinValue ? DateTime.Now : Parameter.StatusChangedOnDate;

            var DateForElastic = DateTime.Now;

            var cases = cls_Generate_Report.Invoke(Connection, Transaction, new P_CAS_GR_1608()
            {
                statuses = Parameter.StatusFrom == 2 ? new int[] { 2, 11 } : Parameter.StatusFrom == 4 ? new int[] { 4, 8, 10 } : new int[] { Convert.ToInt32(Parameter.StatusFrom) },
                position_numbers = Parameter.PositionNumbers,
                updateCasesSubmittedBeforeDate = Parameter.UpdatedCasesSubmittedBeforeDate
            }, securityTicket).Result.cases;

            var earliestFsStatusDate = DateTime.MinValue;
            var latestFsStatusDate = DateTime.MinValue;

            #endregion

            #region Pre-fetched data

            // todo: write queries for ids!
            var activeFsStatuses = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
            {
                IsDeleted = false,
                IsActive = true,
                Tenant_RefID = securityTicket.TenantID,
                TransmitionCode = Convert.ToInt32(Parameter.StatusFrom)
            }).ToDictionary(t => t.BIL_BillPosition_TransmitionStatusID, t => t);

            var casesToUpdate = ORM_HEC_CAS_Case.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).ToDictionary(t => t.HEC_CAS_CaseID, t => t);
            #endregion

            foreach (var reportCase in cases)
            {
                if (Parameter.StatusTo == 7 && (reportCase.CurrentFsStatusCode == 8 || reportCase.CurrentFsStatusCode == 11 || reportCase.CurrentFsStatusCode == 17))
                {
                    continue;
                }

                #region Patient age calculation
                DateTime today = DateTime.Today;
                int patientAge = today.Year - reportCase.PatientBirthday.Year;
                if (reportCase.PatientBirthday > today.AddYears(-patientAge))
                {
                    patientAge--;
                }
                #endregion

                #region FS status update
                var caseActiveFsStatus = activeFsStatuses.ContainsKey(reportCase.TransmitionStatusID) ? activeFsStatuses[reportCase.TransmitionStatusID] : ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                {
                    BIL_BillPosition_TransmitionStatusID = reportCase.TransmitionStatusID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                var responseFromHip = "";
                if (Parameter.StatusTo == 5)
                {
                    var edifact = new EDIFACT();
                    var edifactMessage = Parameter.EdifactMessage;
                    var parser = new Parser(ref edifactMessage);
                    EDIMessage.segmentArray = parser.GetSegments();
                    var parsedEdifact = EDIMessage.SegmentsToParsedEdifact();
                    var message = parsedEdifact.transmitionMessages.Single(t => Int32.Parse(t.Rgi.Segment5.Value.Split('K').Last()) == reportCase.InvoiceNumberForTheHIP);
                    responseFromHip = String.Join("; ", message.Fhl.Select(t => t.Segment4.Value));
                }

                if (!Parameter.AreCasesPaymentAndStatus)
                {
                    if (caseActiveFsStatus.TransmittedOnDate.Date > latestFsStatusDate)
                    {
                        latestFsStatusDate = caseActiveFsStatus.TransmittedOnDate;
                    }

                    if (earliestFsStatusDate < caseActiveFsStatus.TransmittedOnDate.Date)
                    {
                        earliestFsStatusDate = caseActiveFsStatus.TransmittedOnDate;
                    }

                    caseActiveFsStatus.Modification_Timestamp = DateTime.Now;
                    caseActiveFsStatus.IsActive = false;

                    caseActiveFsStatus.Save(Connection, Transaction);

                    var NewStatusForCase = new ORM_BIL_BillPosition_TransmitionStatus();
                    NewStatusForCase.Modification_Timestamp = DateTime.Now;
                    NewStatusForCase.Tenant_RefID = securityTicket.TenantID;
                    NewStatusForCase.BillPosition_RefID = caseActiveFsStatus.BillPosition_RefID;
                    NewStatusForCase.TransmitionStatusKey = caseActiveFsStatus.TransmitionStatusKey;
                    NewStatusForCase.TransmittedOnDate = statusChangedOnDate;
                    NewStatusForCase.PrimaryComment = responseFromHip;
                    NewStatusForCase.TransmitionCode = Convert.ToInt32(Parameter.StatusTo);
                    NewStatusForCase.TransmissionDataXML = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                    {
                        DiagnosisCatalogCode = reportCase.DiagnoseCode,
                        DiagnosisCatalogName = "ICD-10",
                        IFPerformedMedicalPracticeName = reportCase.PracticeName,
                        IFPerformedResponsibleBPFullName = reportCase.DocName,
                        Localization = reportCase.Localization,
                        PatientBirthDate = reportCase.PatientBirthday.ToString("dd.MM.yyyy"),
                        PatientFirstName = reportCase.PatientFirstName,
                        PatientGender = reportCase.PatientGender.ToString(),
                        PatientAge = patientAge.ToString()
                    }, securityTicket).Result.XmlFileString;

                    if (caseActiveFsStatus.TransmitionCode == 11)
                    {
                        var cancellingStatus = new ORM_BIL_BillPosition_TransmitionStatus();
                        cancellingStatus.TransmitionCode = 8;
                        cancellingStatus.BillPosition_RefID = caseActiveFsStatus.BillPosition_RefID;
                        cancellingStatus.IsActive = true;
                        cancellingStatus.Modification_Timestamp = DateTime.Now;
                        cancellingStatus.Tenant_RefID = securityTicket.TenantID;
                        cancellingStatus.TransmittedOnDate = statusChangedOnDate;
                        cancellingStatus.TransmitionStatusKey = caseActiveFsStatus.TransmitionStatusKey;
                        cancellingStatus.TransmissionDataXML = NewStatusForCase.TransmissionDataXML;

                        cancellingStatus.Save(Connection, Transaction);
                    }
                    else
                    {
                        NewStatusForCase.IsActive = true;
                    }

                    NewStatusForCase.Save(Connection, Transaction);


                    #region Elastic updates
                    var elasticId = reportCase.UniqueID.ToString();
                    try
                    {
                        var submitted_case_model_elastic = Get_Submitted_Cases.GetSubmittedCaseforSubmittedCaseID(elasticId, securityTicket);
                        var settlement = Get_Settlement.GetSettlementForID(elasticId, securityTicket);
                        var patient_detail = Retrieve_Patients.Get_PatientDetaiForID(elasticId, securityTicket);

                        var newStatus = "";
                        if (caseActiveFsStatus.TransmitionCode == 11)
                        {
                            newStatus = "FS8";
                        }
                        else
                        {
                            newStatus = "FS" + Parameter.StatusTo;
                        }

                        submitted_case_model_elastic.status = newStatus;
                        submitted_case_model_elastic.status_date = statusChangedOnDate;
                        submitted_case_model_elastic.status_date_string = statusChangedOnDate.ToString("dd.MM.yyyy");
                        settlement.status = newStatus;
                        settlement.status_date = statusChangedOnDate;
                        patient_detail.status = newStatus;

                        cases_to_submit.Add(submitted_case_model_elastic);
                        settlements.Add(settlement);
                        patientDetailList.Add(patient_detail);
                    }
                    catch
                    {

                    }
                    #endregion
                }
                #endregion

                #region Immutable fields update
                var caseToUpdate = casesToUpdate[reportCase.CaseID];
                caseToUpdate.Modification_Timestamp = DateTime.Now;
                caseToUpdate.Patient_BirthDate = reportCase.PatientBirthday;
                caseToUpdate.Patient_FirstName = reportCase.PatientFirstName;
                caseToUpdate.Patient_LastName = reportCase.PatientLastName;
                caseToUpdate.Patient_Gender = reportCase.PatientGender;
                caseToUpdate.Patient_Age = patientAge;

                caseToUpdate.Save(Connection, Transaction);
                #endregion
            }

            if (cases.Any())
            {
                #region Edifact generation
                if (Parameter.StatusTo == 2)
                {
                    var contracts = cases.GroupBy(i => i.ContractID).ToDictionary(t => t.Key, t => t.ToList());
                    var isTestData = false;
                    try
                    {
                        isTestData = bool.Parse(WebConfigurationManager.AppSettings["edifact-generate-test-data"]);
                    }
                    catch { }

                    var cmnContracts = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false });

                    foreach (var contract in contracts)
                    {
                        var contractID = contract.Key;
                        var contractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                        {
                            Contract_RefID = contractID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        });

                        var contractCharacteristicIDParameter = contractParameters.SingleOrDefault(t => t.ParameterName == EContractParameter.CharacteristicID.Value());
                        var edifactType = contractParameters.SingleOrDefault(t => t.ParameterName == EContractParameter.EdifactType.Value());
                        var encryptEdifactParameter = contractParameters.SingleOrDefault(t => t.ParameterName == EContractParameter.EncryptEdifact.Value());
                        var nextEdifactNumberParameter = contractParameters.SingleOrDefault(t => t.ParameterName == EContractParameter.NextEdifactNumber.Value());

                        var contractType = contractParameters.SingleOrDefault(t => t.ParameterName == EContractParameter.ContractType.Value());
                        var messageType = contractParameters.SingleOrDefault(t => t.ParameterName == EContractParameter.MessageType.Value());
                        var mergeForAllHips = contractParameters.SingleOrDefault(t => t.ParameterName == EContractParameter.MergeForAllHips.Value());
                        var useKForCorrection = contractParameters.SingleOrDefault(t => t.ParameterName == EContractParameter.UseKForCorrection.Value());
                        var IKNumber = contractParameters.SingleOrDefault(t => t.ParameterName == EContractParameter.IKNumber.Value());

                        var IKNumberValue = IKNumber != null ? IKNumber.IfStringValue_Value : contract.Value.First() != null ? contract.Value.First().HIP_IK : "";
                        var mergeForAllHipsValue = mergeForAllHips != null ? mergeForAllHips.IfBooleanValue_Value : false;
                        var useKForVorrectionValue = useKForCorrection != null ? useKForCorrection.IfBooleanValue_Value : true;
                        var contactTypeValue = contractType != null ? contractType.IfStringValue_Value : "7";

                        var hipNameForMergedEdifact = mergeForAllHipsValue ? cls_Get_HIP_Name_for_HIP_IK_Number.Invoke(Connection, Transaction, new P_CAS_GHIPIKfHIPIKN_1207
                        {
                            HIPIKNumber = IKNumberValue
                        }, securityTicket).Result.Name : "";

                        var encryptEdifact = false;
                        if (encryptEdifactParameter != null)
                        {
                            encryptEdifact = encryptEdifactParameter.IfBooleanValue_Value;
                        }

                        var contractCharacteristicID = "000000";
                        if (contractCharacteristicIDParameter != null)
                        {
                            contractCharacteristicID = contractCharacteristicIDParameter.IfStringValue_Value;
                        }


                        var controldocumentExcel = cls_Get_Number_of_Edifacts.Invoke(Connection, Transaction, new P_ARCH_GNoE_0910 { ContractID = contractID.ToString() }, securityTicket).Result;

                        uint controlReference = 1;
                        if (controldocumentExcel != null && (uint)controldocumentExcel.numberOfEdifacts > 0 &&
                            nextEdifactNumberParameter != null && nextEdifactNumberParameter.IfNumericValue_Value > 0)
                        {
                            controlReference = nextEdifactNumberParameter != null ? Convert.ToUInt32(nextEdifactNumberParameter.IfNumericValue_Value) : 1;
                        }

                        var casesINContract = contract.Value;
                        var hips = mergeForAllHipsValue ? new Dictionary<string, List<CaseForReportModel>>() { { "", casesINContract } } : casesINContract.GroupBy(i => i.HIP_IK).ToDictionary(t => t.Key, t => t.ToList());
                        foreach (var hip in hips)
                        {
                            var casesWithHIP_IK = hip.Value;
                            var baseHipData = casesWithHIP_IK.First();
                            var mmIkNumber = Resources.InterchangeSenderID;
                            var minTreatmentDate = baseHipData.TreatmentDay;
                            var maxTreatmentDate = baseHipData.TreatmentDay;
                            var ikNumberForHIP = mergeForAllHipsValue ? IKNumberValue : baseHipData.HIP_IK;

                            var edi = new EDIFACT();
                            edi.mmIkNumber = mmIkNumber;
                            edi.hipIkNumber = ikNumberForHIP;

                            foreach (var _case in casesWithHIP_IK)
                            {
                                if (_case.TreatmentDay != DateTime.MinValue && _case.TreatmentDay < minTreatmentDate)
                                {
                                    minTreatmentDate = _case.TreatmentDay;
                                }

                                if (_case.TreatmentDay != DateTime.MaxValue && _case.TreatmentDay > maxTreatmentDate)
                                {
                                    maxTreatmentDate = _case.TreatmentDay;
                                }
                            }

                            edi.Una = "UNA:+,? '\n";
                            var edifactVersion = 3;
                            if (edifactType != null && edifactType.IfStringValue_Value == "4")
                            {
                                edifactVersion = 4;
                            }
                            edi.FileName = String.Format("{0}DRC0{1}", isTestData ? "T" : "E", controlReference.ToString("D3"));

                            #region UNB
                            edi.Unb.Segment1 = "UNOC";
                            edi.Unb.Segment2 = "3";
                            edi.Unb.Segment3 = mmIkNumber;
                            edi.Unb.Segment4 = ikNumberForHIP;
                            // todo: check if this date is always subtracted
                            edi.Unb.Segment5 = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
                            edi.Unb.Segment6 = DateTime.Now.ToString("HHmm");
                            edi.Unb.Segment7 = controlReference.ToString("D5");
                            edi.Unb.Segment8 = String.Format("{0}DRC0{1}{2}", isTestData ? "T" : "E", controlReference.ToString("D2"), DateTime.Now.ToString("yyMM"));
                            if (isTestData && edifactVersion == 4)
                            {
                                edi.Unb.Segment9 = "1";
                            }

                            #endregion

                            var referenceNumber = 1;
                            foreach (var caseModel in casesWithHIP_IK)
                            {
                                var hipIkNumber = mergeForAllHipsValue ? IKNumberValue : caseModel.HIP_IK;

                                var message = new TransmitionMessage();
                                var gender = "0";
                                var currentMessageNumber = String.Format("99{0}", referenceNumber.ToString("D8"));

                                #region Gender

                                switch (caseModel.PatientGender)
                                {
                                    case 0:
                                        gender = "2";
                                        break;
                                    case 1:
                                        gender = "1";
                                        break;
                                    case 2:
                                        gender = "3";
                                        break;
                                }

                                #endregion

                                #region Version independent

                                #region UNH

                                message.Unh.Segment1 = currentMessageNumber;
                                message.Unh.Segment2 = messageType != null ? messageType.IfStringValue_Value : "DIR73C";
                                message.Unh.Segment3 = edifactVersion.ToString();
                                message.Unh.Segment4 = "0";
                                message.Unh.Segment5 = "DR";

                                #endregion

                                #region IVK

                                message.Ivk.Segment1 = useKForVorrectionValue ? "10" : Convert.ToInt32(caseModel.NumberOfNegativeTry) > 0 ? "30" : "10";
                                message.Ivk.Segment2 = "01";
                                message.Ivk.Segment3 = mmIkNumber;
                                message.Ivk.Segment4 = hipIkNumber;

                                #endregion

                                #region IBH

                                message.Ibh.Segment1 = caseModel.LANR;
                                message.Ibh.Segment2 = caseModel.BSNR;

                                #endregion

                                #region INF

                                message.Inf.Segment1 = contractCharacteristicID;
                                message.Inf.Segment2 = "";
                                message.Inf.Segment3 = "0";
                                message.Inf.Segment4 = contactTypeValue;

                                #endregion

                                #region INV
                                message.Inv.Segment4 = caseModel.PatientInsuranceNumber;
                                message.Inv.Segment5 = hipIkNumber;
                                message.Inv.Segment6 = caseModel.PatientLastName;
                                message.Inv.Segment7 = caseModel.PatientFirstName;
                                message.Inv.Segment8 = caseModel.PatientBirthday.ToString("yyyyMMdd");
                                message.Inv.Segment9 = gender;

                                #endregion

                                #region DIA

                                message.Dia.Segment1 = caseModel.DiagnoseCode;
                                message.Dia.Segment2 = "G";
                                message.Dia.Segment3 = caseModel.Localization;

                                #endregion

                                #region ABR

                                message.Abr.Segment1 = "";
                                message.Abr.Segment2 = caseModel.GPOS;
                                message.Abr.Segment3 = "";
                                message.Abr.Segment4 = "";
                                message.Abr.Segment5 = "1";
                                message.Abr.Segment6 = caseModel.AmountForThisGPOS.ToString("F", germanCulture);
                                message.Abr.Segment7 = "";
                                message.Abr.Segment8 = "";
                                message.Abr.Segment9 = "";
                                message.Abr.Segment10 = "";
                                message.Abr.Segment11 = caseModel.TreatmentDay.ToString("yyyyMMdd");

                                #endregion

                                #region FKI

                                message.Fki.Segment1 = caseModel.AmountForThisGPOS.ToString("F", germanCulture);
                                message.Fki.Segment2 = "";
                                message.Fki.Segment3 = "";
                                message.Fki.Segment4 = "";
                                message.Fki.Segment5 = "";
                                message.Fki.Segment6 = "";
                                message.Fki.Segment7 = caseModel.AmountForThisGPOS.ToString("F", germanCulture);

                                #endregion

                                #region RGI
                                message.Rgi.Segment1 = minTreatmentDate.ToString("yyyyMMdd");
                                message.Rgi.Segment2 = maxTreatmentDate.ToString("yyyyMMdd");
                                message.Rgi.Segment3 = "1";
                                message.Rgi.Segment4 = mmIkNumber;

                                message.Rgi.Segment5 = useKForVorrectionValue && Convert.ToInt32(caseModel.NumberOfNegativeTry) > 0
                                    ? String.Format("{0}K{1}", caseModel.NumberOfNegativeTry, caseModel.InvoiceNumberForTheHIP.ToString())
                                    : caseModel.InvoiceNumberForTheHIP.ToString();

                                message.Rgi.Segment6 = DateTime.Now.ToString("yyyyMMdd");
                                message.Rgi.Segment7 = "";
                                message.Rgi.Segment8 = Convert.ToUInt32(caseModel.NumberOfNegativeTry).ToString("D3");

                                #endregion

                                #region UNT

                                message.Unt.Segment1 = "10";
                                message.Unt.Segment2 = currentMessageNumber;

                                #endregion

                                #endregion

                                #region Version specific

                                var InvSegment1Value = caseModel.PatientStatusNumber.Replace(" ", string.Empty);
                                switch (edifactVersion)
                                {
                                    case 3:
                                        message.Inv.Segment1 = InvSegment1Value.Length < 5 ? InvSegment1Value.Substring(0, 1) + "0001" : InvSegment1Value;
                                        message.Ivk.Segment5 = caseModel.InvoiceNumberForTheHIP.ToString();
                                        break;

                                    case 4:
                                        message.Inv.Segment1 = InvSegment1Value.Substring(0, 1);
                                        message.Inv.Segment2 = "";
                                        message.Inv.Segment3 = "";

                                        message.Ivk.Segment5 = "99999999999999";
                                        message.Ivk.Segment6 = hipIkNumber;

                                        break;

                                    default:
                                        break;
                                }

                                #endregion

                                edi.transmitionMessages.Add(message);

                                referenceNumber++;
                            }

                            #region UNZ

                            edi.Unz.Segment1 = edi.transmitionMessages.Count.ToString();
                            edi.Unz.Segment2 = controlReference.ToString("D5");

                            #endregion

                            var edifact = edi.GetEdifact();
                            var edi_path = System.IO.Path.GetTempPath() + edifact.edifactName;
                            var i = 1;
                            while (File.Exists(edi_path))
                            {
                                edifact.edifactName = string.Format("{0}({1})", edifact.edifactName, i++);
                                edi_path = System.IO.Path.GetTempPath() + edifact.edifactName;
                            }

                            File.WriteAllText(edi_path, edifact.edifactFileOutput);
                            var fi = new FileInfo(edi_path);
                            edi.decryptedFileSize = fi.Length;
                            edi.encryptedFileSize = fi.Length;

                            var aufFile = edi.GetAufFile();
                            var path_auf = System.IO.Path.GetTempPath() + aufFile.aufName;
                            File.WriteAllText(path_auf, aufFile.aufFileOutput);

                            var files = new List<string>();

                            files.Add(edi_path);
                            files.Add(path_auf);

                            var zipPath = System.IO.Path.GetTempPath() + edifact.edifactName + ".zip";
                            ZipFIlesUtils.AddToArchive(zipPath, files);

                            var documentEdifact = new Documents();
                            documentEdifact.documentName = "Export von " + minTreatmentDate.ToString("dd.MM.yyyy") + " - " + maxTreatmentDate.ToString("dd.MM.yyyy");
                            documentEdifact.documentOutputLocation = zipPath;
                            documentEdifact.ContractID = contractID;
                            documentEdifact.receiver = mergeForAllHipsValue ? hipNameForMergedEdifact : casesWithHIP_IK[0].HIP;
                            documentEdifact.mimeType = "Application/Edifact";

                            documents.Add(documentEdifact);

                            controlReference++;
                        }

                        #region Update parameters
                        cls_Save_Contract_Parameter.Invoke(Connection, Transaction, new P_MD_SCP_1754()
                        {
                            Name = EContractParameter.NextEdifactNumber.Value(),
                            ContractID = contractID,
                            NumericValue = Convert.ToDouble(controlReference)
                        }, securityTicket);
                        #endregion
                    }
                }
                #endregion

                #region Excel report generation
                Documents documentExcel = new Documents();
                documentExcel.documentName = "ExcelReport" + DateTime.Now.ToString("dd.MM.yyyy_HH.mm");
                documentExcel.documentOutputLocation = GenerateReportCases.CreateCaseXlsReport(cases.ToList(), documentExcel.documentName);
                documentExcel.mimeType = UtilMethods.GetMimeType(documentExcel.documentOutputLocation);
                documentExcel.receiver = "MM";
                documents.Add(documentExcel);
                #endregion

                #region Negative feedback edifact
                if (Parameter.StatusTo == 5 && !String.IsNullOrEmpty(Parameter.HipIkNumber))
                {
                    var files = new List<string>();
                    var edi_path = Path.GetTempPath() + Parameter.EdifactFileName;
                    File.WriteAllText(edi_path, Parameter.EdifactMessage);
                    files.Add(edi_path);

                    var zipPath = Path.GetTempPath() + Parameter.EdifactFileName + ".zip";
                    ZipFIlesUtils.AddToArchive(zipPath, files);

                    var errorEdifact = new Documents();
                    errorEdifact.documentName = String.Format("Import von {0} - {1}", earliestFsStatusDate.ToString("dd.MM.yyyy"), latestFsStatusDate.ToString("dd.MM.yyyy"));
                    errorEdifact.documentOutputLocation = zipPath;
                    errorEdifact.receiver = cls_Get_HIP_Name_for_HIP_IK_Number.Invoke(Connection, Transaction, new P_CAS_GHIPIKfHIPIKN_1207() { HIPIKNumber = Parameter.HipIkNumber }, securityTicket).Result.Name;
                    errorEdifact.mimeType = "Application/Edifact_Error";

                    documents.Add(errorEdifact);
                }
                #endregion

                #region Document upload
                foreach (var document in documents)
                {
                    var ms = new MemoryStream(File.ReadAllBytes(document.documentOutputLocation));

                    var byteArrayFile = ms.ToArray();
                    var _providerFactory = ProviderFactory.Instance;
                    var documentProvider = _providerFactory.CreateDocumentServiceProvider();
                    var uploadedFrom = HttpContext.Current.Request.UserHostAddress;
                    var documentID = documentProvider.UploadDocument(byteArrayFile, document.documentOutputLocation, securityTicket.SessionTicket, uploadedFrom);
                    var downloadURL = documentProvider.GenerateImageThumbnailLink(documentID, securityTicket.SessionTicket, false, 200);

                    var parameterDoc = new P_ARCH_UD_1326();
                    parameterDoc.DocumentID = documentID;
                    parameterDoc.Mime = document.mimeType;
                    parameterDoc.DocumentName = document.documentName;
                    parameterDoc.DocumentDate = DateForElastic;
                    parameterDoc.Receiver = document.receiver;
                    parameterDoc.ContractID = document.ContractID;
                    if (!Parameter.AreCasesFiltered)
                    {
                        if (parameterDoc.Mime == "Application/Edifact")
                        {
                            parameterDoc.Description = parameterDoc.DocumentName;
                        }
                        else
                        {
                            if (Parameter.AreCasesPositive)
                            {
                                parameterDoc.Description = "DATEV";
                            }
                            else
                            {
                                parameterDoc.Description = "EDIFACT";
                            }
                        }
                    }
                    else
                    {
                        if (Parameter.StatusTo == 5)
                        {
                            if (parameterDoc.Mime == "Application/Edifact_Error")
                            {
                                parameterDoc.Description = parameterDoc.DocumentName;
                            }
                            else
                            {
                                parameterDoc.Description = "KV Fehler";
                            }
                        }
                        else
                        {
                            parameterDoc.Description = "KV Import";
                        }
                    }

                    cls_Upload_Report.Invoke(Connection, Transaction, parameterDoc, securityTicket);
                }
                #endregion
            }

            #region Receipt pdf generation
            var create_pdf_report = false;
            try
            {
                create_pdf_report = Boolean.Parse(WebConfigurationManager.AppSettings["generateReceiptPdf"]);
            }
            catch { }

            if (create_pdf_report && Parameter.StatusTo == 7)
            {
                cls_Create_Pdf_Report.Invoke(Connection, Transaction, new P_CAS_CPR_1050() { cases = cases }, securityTicket);
            }
            #endregion



            #region Elastic import
            if (cases_to_submit.Count != 0)
                Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(cases_to_submit, securityTicket.TenantID.ToString());
            if (settlements.Count != 0)
                Add_new_Settlement.Import_Settlement_to_ElasticDB(settlements, securityTicket.TenantID.ToString());
            if (patientDetailList.Count != 0)
                Add_New_Patient.ImportPatientDetailsToElastic(patientDetailList, securityTicket.TenantID.ToString());
            #endregion

            returnValue.Result.caseList = cases.Select(t => new CaseLogObject()
            {
                BillPositionNumber = t.InvoiceNumberForTheHIP.ToString(),
                BillPositionType = t.CaseType,
                CaseNumber = t.CaseNumber.ToString()
            }).ToArray();

            return returnValue;

            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_CCS_1516 Invoke(string ConnectionString, P_CAS_CCS_1516 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_CCS_1516 Invoke(DbConnection Connection, P_CAS_CCS_1516 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_CCS_1516 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CCS_1516 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_CCS_1516 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CCS_1516 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_CCS_1516 functionReturn = new FR_CAS_CCS_1516();
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

                throw new Exception("Exception occured in method cls_Change_Case_Status", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_CCS_1516 : FR_Base
    {
        public CAS_CCS_1516 Result { get; set; }

        public FR_CAS_CCS_1516() : base() { }

        public FR_CAS_CCS_1516(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_CCS_1516 for attribute P_CAS_CCS_1516
    [DataContract]
    public class P_CAS_CCS_1516
    {
        //Standard type parameters
        [DataMember]
        public Double StatusFrom { get; set; }
        [DataMember]
        public Double StatusTo { get; set; }
        [DataMember]
        public bool AreCasesFiltered { get; set; }
        [DataMember]
        public bool AreCasesPositive { get; set; }
        [DataMember]
        public bool AreCasesPaymentAndStatus { get; set; }
        [DataMember]
        public String EdifactFileName { get; set; }
        [DataMember]
        public String HipIkNumber { get; set; }
        [DataMember]
        public String EdifactMessage { get; set; }
        [DataMember]
        public double[] PositionNumbers { get; set; }
        [DataMember]
        public DateTime StatusChangedOnDate { get; set; }
        [DataMember]
        public DateTime? UpdatedCasesSubmittedBeforeDate { get; set; }

    }
    #endregion
    #region SClass CAS_CCS_1516 for attribute CAS_CCS_1516
    [DataContract]
    public class CAS_CCS_1516
    {
        //Standard type parameters
        [DataMember]
        public LogUtils.CaseLogObject[] caseList { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_CCS_1516 cls_Change_Case_Status(,P_CAS_CCS_1516 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_CCS_1516 invocationResult = cls_Change_Case_Status.Invoke(connectionString,P_CAS_CCS_1516 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Manipulation.P_CAS_CCS_1516();
parameter.StatusFrom = ...;
parameter.StatusTo = ...;
parameter.AreCasesFiltered = ...;
parameter.AreCasesPositive = ...;
parameter.AreCasesPaymentAndStatus = ...;
parameter.EdifactFileName = ...;
parameter.HipIkNumber = ...;
parameter.EdifactMessage = ...;
parameter.PositionNumbers = ...;
parameter.StatusChangedOnDate = ...;
parameter.UpdatedCasesSubmittedBeforeDate = ...;

*/
