/* 
 * Generated on 14.05.2014 11:51:55
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
using CL6_Lucenits_Treatments.Atomic.Retrieval;
using CL5_Lucentis_Patient.Atomic.Retrieval;
using CL5_Lucentis_Doctors.Atomic.Retrieval;
using CL3_MedicalPractices.Atomic.Retrieval;

namespace CL6_Lucenits_Treatments.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_TreatmentsInfo_for_TimeRange.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_TreatmentsInfo_for_TimeRange
    {
        public static readonly int QueryTimeout = 6000;

        #region Method Execution
        protected static FR_L6TR_GTI_fTR_1816 Execute(DbConnection Connection, DbTransaction Transaction, P_L6TR_GTI_fTR_1816 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L6TR_GTI_fTR_1816();
            returnValue.Result = new L6TR_GTI_fTR_1816();

            string emptyDataConstant = "-";
            var billPositionTypes = new String[3] { "Behandlung | Nachsorge", "Behandlung", "Nachsorge" };

            var allTreatmentsForTimeRange = cls_Get_Treatments_for_TimeRange.Invoke(Connection, Transaction, new P_L6TR_GT_fTR_1950() { fromDate = Parameter.fromDate, toDate = Parameter.toDate }, securityTicket).Result;
            if (allTreatmentsForTimeRange == null || allTreatmentsForTimeRange.Length == 0)
                return returnValue;
            var treatmentIDs = allTreatmentsForTimeRange.Select(s => s.HEC_Patient_TreatmentID).Distinct().ToList();
            var otherTreatmentIDs = allTreatmentsForTimeRange.Where(w => w.IsTreatmentFollowup && !treatmentIDs.Contains(w.IfTreatmentFollowup_FromTreatment_RefID) && w.IfTreatmentFollowup_FromTreatment_RefID != Guid.Empty).Select(s => s.IfTreatmentFollowup_FromTreatment_RefID).ToList();
            treatmentIDs.AddRange(otherTreatmentIDs);
            var treatmentsData = cls_Get_TreatmentsCompleteInfo_by_IDs.Invoke(Connection, Transaction, new P_L6TR_GTCIbID_2148() { TreatmentIDs = treatmentIDs.Distinct().ToArray() }, securityTicket).Result;

            var positions = new List<L6TR_GTI_fTR_1816_Position>();
            var patients = cls_Get_AllPatientsSimpleData_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            var doctors = cls_Get_AllDoctors_withBankData_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            var practices = cls_Get_Practice_BaseInfo_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            foreach (var treatment in allTreatmentsForTimeRange)
            {
                #region collectPositionDataForReport

                L6TR_GTCIbID_2148 treatmentData = null;
                if (treatment.IsTreatmentFollowup)
                {
                    treatmentData = treatmentsData.Where(t => t.HEC_Patient_TreatmentID == treatment.IfTreatmentFollowup_FromTreatment_RefID).FirstOrDefault();
                    if (treatmentData == null)
                    {
                        continue;
                    }
                }
                else
                    treatmentData = treatmentsData.Where(t => t.HEC_Patient_TreatmentID == treatment.HEC_Patient_TreatmentID).Single();

                var billData = treatmentsData.Where(t => t.HEC_Patient_TreatmentID == treatment.HEC_Patient_TreatmentID).Single().BillData.ToList();

                var patient = patients.FirstOrDefault(p => treatmentData.HEC_Patient_RefID != null && treatmentData.HEC_Patient_RefID != Guid.Empty && p.HEC_PatientID == treatmentData.HEC_Patient_RefID);
                if (patient == null) continue;

                var treatmentPosition = new L6TR_GTI_fTR_1816_Position()
                {
                    PositionProcessNumber = -1,
                    InsuranceStateCode = patient.InsuranceStateCode,
                    HICompanyName = patient.HICompanyName,
                    HealthInsuranceNumber = patient.HealthInsurance_Number,
                    PatientFirstName = patient.FirstName,
                    PatientLastName = patient.LastName,
                    PatientDOB = patient.BirthDate,
                    DateOfTransmision = DateTime.MinValue,
                    DateOfPayment = DateTime.MinValue,
                    TransmitionStatus_Comment1 = emptyDataConstant,
                    TransmitionStatus_Comment2 = emptyDataConstant,
                    GPOS = emptyDataConstant,
                    DiagnoseCode = emptyDataConstant,
                    DiagnoseState = emptyDataConstant,
                    DiagnoseName = emptyDataConstant,
                    DiagnoseLocalization = treatmentData.IsTreatmentOfLeftEye ? "L" : "R",
                    ArticleName = emptyDataConstant,
                    TreatmentDate = treatment.IsTreatmentPerformed ? treatment.IfTreatmentPerformed_Date : treatment.IfSheduled_Date,
                    BSNR = emptyDataConstant,
                    PracticeName = emptyDataConstant,
                    LANR = emptyDataConstant,
                    DoctroFullName = emptyDataConstant,
                    AccountOwner = emptyDataConstant,
                    BLZ = emptyDataConstant,
                    AccountNumber = emptyDataConstant,
                    IBAN = emptyDataConstant,
                    BIC = emptyDataConstant,
                    BankName = emptyDataConstant,
                    TreatmentDateFromOriginalTreatment = DateTime.MinValue
                };
                var diagnose = treatmentData.RelevantDiagnosis.FirstOrDefault();
                if (diagnose != null)
                {
                    treatmentPosition.DiagnoseCode = diagnose.ICD10_Code;
                    treatmentPosition.DiagnoseState = diagnose.DiagnosisState_Abbreviation;
                    treatmentPosition.DiagnoseName = diagnose.PotentialDiagnosis_Name_DictID.GetContent(Parameter.LanguageID);
                }
                var article = treatmentData.Articles.FirstOrDefault();
                if (article != null)
                    treatmentPosition.ArticleName = article.Product_Name.GetContent(Parameter.LanguageID);

                var practice = practices.FirstOrDefault(p => p.HEC_MedicalPractiseID == treatment.TreatmentPractice_RefID && treatment.TreatmentPractice_RefID != Guid.Empty);
                if (practice != null)
                {
                    treatmentPosition.BSNR = practice.BSNR;
                    treatmentPosition.PracticeName = practice.PracticeName;
                }
                else
                {

                }
                var doctor = doctors.FirstOrDefault(d => d.HEC_DoctorID == (treatment.IsTreatmentPerformed ? treatment.IfTreatmentPerformed_ByDoctor_RefID : treatment.IfSheduled_ForDoctor_RefID));
                if (doctor != null)
                {
                    treatmentPosition.LANR = doctor.LANR;
                    treatmentPosition.DoctroFullName = doctor.FirstName + " " + doctor.LastName;
                    treatmentPosition.AccountOwner = doctor.OwnerText;
                    treatmentPosition.BLZ = doctor.BankNumber;
                    treatmentPosition.AccountNumber = doctor.AccountNumber;
                    treatmentPosition.IBAN = doctor.IBAN;
                    treatmentPosition.BIC = doctor.BICCode;
                    treatmentPosition.BankName = doctor.BankName;
                };

                if (!treatment.IsTreatmentFollowup)
                {
                    treatmentPosition.TreatmentType = "OP-Termin";
                    treatmentPosition.TreatmentDateFromOriginalTreatment = treatmentPosition.TreatmentDate;
                }
                else
                {
                    treatmentPosition.TreatmentType = "Nachsorge";
                    treatmentPosition.TreatmentDateFromOriginalTreatment = treatmentData.IsTreatmentPerformed ? treatmentData.IfTreatmentPerformed_Date : treatmentData.IfSheduled_Date;
                }

                if (billData.Count > 0)
                {
                    var currentBillData = billData.Where(b => billPositionTypes.Contains(b.External_PositionType)).FirstOrDefault();
                    if (currentBillData != null)
                    {
                        switch (currentBillData.External_PositionType)
                        {
                            case "Behandlung | Nachsorge":
                                treatmentPosition.Price = currentBillData.PositionValue_IncludingTax - 60;
                                break;
                            case "Behandlung":
                                treatmentPosition.Price = currentBillData.PositionValue_IncludingTax;
                                break;
                            case "Nachsorge":
                                treatmentPosition.Price = currentBillData.PositionValue_IncludingTax;
                                break;
                        }
                        treatmentPosition.GPOS = currentBillData.External_PositionCode;
                        treatmentPosition.PositionProcessNumber = Int64.Parse(currentBillData.External_PositionReferenceField);
                        treatmentPosition.positionSequence = treatmentPosition.PositionProcessNumber;
                        if (currentBillData.Statuses != null)
                        {
                            var activeStatus = currentBillData.Statuses.Where(s => s.IsActive).FirstOrDefault();
                            if (activeStatus == null)
                            {
                            }

                            treatmentPosition.NumberOfNegativeTries = currentBillData.Statuses.Where(s => s.TransmitionCode == 4).Count();
                            treatmentPosition.positionStatus = activeStatus.TransmitionCode;
                            treatmentPosition.TransmitionStatus_Comment2 = activeStatus.SecondaryComment;

                            if (currentBillData.Statuses.Where(s => s.TransmitionCode == 2).Count() > 0)
                            {
                                treatmentPosition.DateOfTransmision = currentBillData.Statuses.Where(s => s.TransmitionCode == 2).OrderByDescending(s => s.TransmittedOnDate).First().TransmittedOnDate;
                            }
                            else
                            {
                                treatmentPosition.DateOfTransmision = DateTime.MinValue;
                            }

                            switch (activeStatus.TransmitionCode)
                            {
                                case 7:
                                    treatmentPosition.TransmitionStatus_Comment1 = "storniert";
                                    break;

                                case 6:
                                    treatmentPosition.TransmitionStatus_Comment1 = activeStatus.PrimaryComment.Contains("|") ? activeStatus.PrimaryComment.Split('|')[0].Trim() : "Process status error!";
                                    break;

                                default:
                                    treatmentPosition.TransmitionStatus_Comment1 = activeStatus.PrimaryComment;
                                    break;
                            }

                            var statusWithCode5 = currentBillData.Statuses.FirstOrDefault(s => s.TransmitionCode == 5);
                            var statusWithCode6 = currentBillData.Statuses.FirstOrDefault(s => s.TransmitionCode == 6);
                            treatmentPosition.DateOfPayment = statusWithCode6 != null ? statusWithCode6.TransmittedOnDate : statusWithCode5 != null ? statusWithCode5.TransmittedOnDate : DateTime.MinValue;

                            treatmentPosition.DateOfSecondLastStatusChange = DateTime.MinValue;
                            treatmentPosition.SecondLastStatusChange = emptyDataConstant;
                            if (currentBillData.Statuses.Where(s => !s.IsActive).Count() > 0)
                            {
                                var secondLastStatus = currentBillData.Statuses.Where(s => !s.IsActive).OrderByDescending(s => s.TransmittedOnDate).First();
                                if (currentBillData.Statuses.Where(s => !s.IsActive && s.TransmittedOnDate == secondLastStatus.TransmittedOnDate).Count() > 1)
                                    secondLastStatus = currentBillData.Statuses.Where(s => !s.IsActive && s.TransmittedOnDate == secondLastStatus.TransmittedOnDate).OrderByDescending(s => s.TransmitionCode).First();

                                treatmentPosition.DateOfSecondLastStatusChange = secondLastStatus.TransmittedOnDate;
                                switch (secondLastStatus.TransmitionCode)
                                {
                                    case 7:
                                        treatmentPosition.SecondLastStatusChange = "storniert";
                                        break;

                                    case 6:
                                        treatmentPosition.SecondLastStatusChange = secondLastStatus.PrimaryComment.Contains("|") ? secondLastStatus.PrimaryComment.Split('|')[0].Trim() : "Process status error!";
                                        break;

                                    default:
                                        treatmentPosition.SecondLastStatusChange = secondLastStatus.PrimaryComment;
                                        break;
                                }

                            }
                            treatmentPosition.DateOfLastStatusChange = activeStatus.TransmittedOnDate;
                        }
                    }
                    else // za pausala, zakomentarisati kad zatreba
                    {
                        //var paushal = billData.Single(b => b.External_PositionType == "Wartezeitenmanagement");

                        //treatmentPosition.GPOS = paushal.External_PositionCode;
                        //treatmentPosition.PositionProcessNumber = Int64.Parse(paushal.External_PositionReferenceField);
                        //treatmentPosition.positionSequence = treatmentPosition.PositionProcessNumber;
                        //treatmentPosition.Price = paushal.PositionValue_IncludingTax;
                        //if (paushal.Statuses != null)
                        //{
                        //    var activeStatus = paushal.Statuses.Where(s => s.IsActive).FirstOrDefault();
                        //    if (activeStatus == null)
                        //    {
                        //    }

                        //    treatmentPosition.NumberOfNegativeTries = paushal.Statuses.Where(s => s.TransmitionCode == 4).Count();
                        //    treatmentPosition.positionStatus = activeStatus.TransmitionCode;
                        //    treatmentPosition.TransmitionStatus_Comment2 = activeStatus.SecondaryComment;

                        //    if (paushal.Statuses.Where(s => s.TransmitionCode == 2).Count() > 0)
                        //    {
                        //        treatmentPosition.DateOfTransmision = paushal.Statuses.Where(s => s.TransmitionCode == 2).OrderByDescending(s => s.TransmittedOnDate).First().TransmittedOnDate;
                        //    }
                        //    else
                        //    {
                        //        treatmentPosition.DateOfTransmision = DateTime.MinValue;
                        //    }

                        //    switch (activeStatus.TransmitionCode)
                        //    {
                        //        case 7:
                        //            treatmentPosition.TransmitionStatus_Comment1 = "storniert";
                        //            break;

                        //        case 6:
                        //            treatmentPosition.TransmitionStatus_Comment1 = activeStatus.PrimaryComment.Contains("|") ? activeStatus.PrimaryComment.Split('|')[0].Trim() : "Process status error!";
                        //            break;

                        //        default:
                        //            treatmentPosition.TransmitionStatus_Comment1 = activeStatus.PrimaryComment;
                        //            break;
                        //    }

                        //    var statusWithCode5 = paushal.Statuses.FirstOrDefault(s => s.TransmitionCode == 5);
                        //    var statusWithCode6 = paushal.Statuses.FirstOrDefault(s => s.TransmitionCode == 6);
                        //    treatmentPosition.DateOfPayment = statusWithCode6 != null ? statusWithCode6.TransmittedOnDate : statusWithCode5 != null ? statusWithCode5.TransmittedOnDate : DateTime.MinValue;

                        //    treatmentPosition.DateOfSecondLastStatusChange = DateTime.MinValue;
                        //    treatmentPosition.SecondLastStatusChange = emptyDataConstant;
                        //    if (paushal.Statuses.Where(s => !s.IsActive).Count() > 0)
                        //    {
                        //        var secondLastStatus = paushal.Statuses.Where(s => !s.IsActive).OrderByDescending(s => s.TransmittedOnDate).First();
                        //        if (paushal.Statuses.Where(s => !s.IsActive && s.TransmittedOnDate == secondLastStatus.TransmittedOnDate).Count() > 1)
                        //            secondLastStatus = paushal.Statuses.Where(s => !s.IsActive && s.TransmittedOnDate == secondLastStatus.TransmittedOnDate).OrderByDescending(s => s.TransmitionCode).First();

                        //        treatmentPosition.DateOfSecondLastStatusChange = secondLastStatus.TransmittedOnDate;
                        //        switch (secondLastStatus.TransmitionCode)
                        //        {
                        //            case 7:
                        //                treatmentPosition.SecondLastStatusChange = "storniert";
                        //                break;

                        //            case 6:
                        //                treatmentPosition.SecondLastStatusChange = secondLastStatus.PrimaryComment.Contains("|") ? secondLastStatus.PrimaryComment.Split('|')[0].Trim() : "Process status error!";
                        //                break;

                        //            default:
                        //                treatmentPosition.SecondLastStatusChange = secondLastStatus.PrimaryComment;
                        //                break;
                        //        }

                        //    }
                        //    treatmentPosition.DateOfLastStatusChange = activeStatus.TransmittedOnDate;
                        //}
                    }

                    foreach (var otherBillData in billData)
                    {
                        if (currentBillData != null && otherBillData.BIL_BillPositionID == currentBillData.BIL_BillPositionID)
                            continue;

                        L6TR_GTI_fTR_1816_Position newPosition = new L6TR_GTI_fTR_1816_Position();
                        newPosition.positionSequence = long.MaxValue;
                        newPosition.InsuranceStateCode = treatmentPosition.InsuranceStateCode;
                        newPosition.HealthInsuranceNumber = treatmentPosition.HealthInsuranceNumber;
                        newPosition.PatientFirstName = treatmentPosition.PatientFirstName;
                        newPosition.PatientLastName = treatmentPosition.PatientLastName;
                        newPosition.PatientDOB = treatmentPosition.PatientDOB;
                        newPosition.TreatmentType = otherBillData.External_PositionType;
                        newPosition.DiagnoseCode = treatmentPosition.DiagnoseCode;
                        newPosition.DiagnoseState = treatmentPosition.DiagnoseState;
                        newPosition.DiagnoseName = treatmentPosition.DiagnoseName;
                        newPosition.DiagnoseLocalization = treatmentPosition.DiagnoseLocalization;
                        newPosition.ArticleName = treatmentPosition.ArticleName;
                        newPosition.TreatmentDate = treatmentPosition.TreatmentDate;
                        newPosition.BSNR = treatmentPosition.BSNR;
                        newPosition.PracticeName = treatmentPosition.PracticeName;
                        newPosition.LANR = treatmentPosition.LANR;
                        newPosition.DoctroFullName = treatmentPosition.DoctroFullName;
                        newPosition.AccountOwner = treatmentPosition.AccountOwner;
                        newPosition.BLZ = treatmentPosition.BLZ;
                        newPosition.AccountNumber = treatmentPosition.AccountNumber;
                        newPosition.IBAN = treatmentPosition.IBAN;
                        newPosition.BIC = treatmentPosition.BIC;
                        newPosition.BankName = treatmentPosition.BankName;
                        newPosition.HICompanyName = treatmentPosition.HICompanyName;
                        newPosition.TreatmentDateFromOriginalTreatment = treatmentPosition.TreatmentDateFromOriginalTreatment;


                        newPosition.GPOS = otherBillData.External_PositionCode;
                        newPosition.Price = otherBillData.PositionValue_IncludingTax;

                        long processNumber = long.MaxValue;
                        if (!Int64.TryParse(otherBillData.External_PositionReferenceField, out processNumber))
                        {
                            newPosition.positionSequence = long.MaxValue - 1;
                            newPosition.PositionProcessNumber = 0;
                        }
                        else
                        {
                            newPosition.positionSequence = processNumber;
                            newPosition.PositionProcessNumber = processNumber;
                        }

                        if (String.IsNullOrEmpty(otherBillData.External_PositionType))
                        {
                            newPosition.TreatmentType = "no type";
                        }


                        if (currentBillData == null)//ovde je promena!!!!
                            continue;

                        var activeStatus = currentBillData.Statuses.Where(s => s.IsActive).SingleOrDefault();

                        newPosition.NumberOfNegativeTries = currentBillData.Statuses.Where(s => s.TransmitionCode == 4).Count();
                        newPosition.positionStatus = activeStatus.TransmitionCode;
                        newPosition.TransmitionStatus_Comment2 = activeStatus.SecondaryComment;

                        if (currentBillData.Statuses.Where(s => s.TransmitionCode == 2).Count() > 0)
                        {
                            newPosition.DateOfTransmision = currentBillData.Statuses.Where(s => s.TransmitionCode == 2).OrderByDescending(s => s.TransmittedOnDate).First().TransmittedOnDate;
                        }
                        else
                        {
                            newPosition.DateOfTransmision = DateTime.MinValue;
                        }

                        switch (activeStatus.TransmitionCode)
                        {
                            case 7:
                                newPosition.TransmitionStatus_Comment1 = "storniert";
                                break;

                            case 6:
                                newPosition.TransmitionStatus_Comment1 = activeStatus.PrimaryComment.Contains("|") ? activeStatus.PrimaryComment.Split('|')[0].Trim() : "Process status error!";
                                break;

                            default:
                                newPosition.TransmitionStatus_Comment1 = activeStatus.PrimaryComment;
                                break;
                        }

                        var statusWithCode5 = currentBillData.Statuses.FirstOrDefault(s => s.TransmitionCode == 5);
                        var statusWithCode6 = currentBillData.Statuses.FirstOrDefault(s => s.TransmitionCode == 6);
                        newPosition.DateOfPayment = statusWithCode6 != null ? statusWithCode6.TransmittedOnDate : statusWithCode5 != null ? statusWithCode5.TransmittedOnDate : DateTime.MinValue;

                        newPosition.DateOfSecondLastStatusChange = DateTime.MinValue;
                        newPosition.SecondLastStatusChange = emptyDataConstant;
                        if (currentBillData.Statuses.Where(s => !s.IsActive).Count() > 0)
                        {
                            var secondLastStatus = currentBillData.Statuses.Where(s => !s.IsActive).OrderByDescending(s => s.TransmittedOnDate).First();
                            if (currentBillData.Statuses.Where(s => !s.IsActive && s.TransmittedOnDate == secondLastStatus.TransmittedOnDate).Count() > 1)
                                secondLastStatus = currentBillData.Statuses.Where(s => !s.IsActive && s.TransmittedOnDate == secondLastStatus.TransmittedOnDate).OrderByDescending(s => s.TransmitionCode).First();

                            newPosition.DateOfSecondLastStatusChange = secondLastStatus.TransmittedOnDate;
                            switch (secondLastStatus.TransmitionCode)
                            {
                                case 7:
                                    newPosition.SecondLastStatusChange = "storniert";
                                    break;

                                case 6:
                                    newPosition.SecondLastStatusChange = secondLastStatus.PrimaryComment.Contains("|") ? secondLastStatus.PrimaryComment.Split('|')[0].Trim() : "Process status error!";
                                    break;

                                default:
                                    newPosition.SecondLastStatusChange = secondLastStatus.PrimaryComment;
                                    break;
                            }

                        }
                        newPosition.DateOfLastStatusChange = activeStatus.TransmittedOnDate;
                        positions.Add(newPosition);
                    }
                }
                if (billData.Count == 0)
                {
                    if (treatment.IsTreatmentFollowup && treatmentData.BillData.FirstOrDefault(bd => bd.External_PositionType == "Behandlung | Nachsorge") != null)
                    {
                        var currentBillData = treatmentData.BillData.Where(bd => bd.External_PositionType == "Behandlung | Nachsorge").First();
                        string comment1 = "offen";

                        var statusWithCode2 = currentBillData.Statuses.Where(s => s.TransmitionCode == 2).OrderByDescending(s => s.TransmittedOnDate).FirstOrDefault();
                        var statusWithCode5 = currentBillData.Statuses.FirstOrDefault(s => s.TransmitionCode == 5);
                        var statusWithCode6 = currentBillData.Statuses.FirstOrDefault(s => s.TransmitionCode == 6);

                        var activeStatus = currentBillData.Statuses.Where(s => s.IsActive).FirstOrDefault();
                        if (activeStatus != null)
                        {
                            if (activeStatus.TransmitionCode == 6)
                                comment1 = activeStatus.PrimaryComment.Contains("|") ? activeStatus.PrimaryComment.Split('|')[1].Trim() : "Process status error!";
                            else
                                comment1 = activeStatus.PrimaryComment;

                            if (activeStatus.TransmitionCode == 7) comment1 = "storniert";
                            treatmentPosition.TransmitionStatus_Comment2 = activeStatus.SecondaryComment;
                            treatmentPosition.positionStatus = activeStatus.TransmitionCode;
                            treatmentPosition.DateOfLastStatusChange = activeStatus.TransmittedOnDate;
                        }
                        treatmentPosition.DateOfPayment = statusWithCode6 != null ? DateTime.MinValue : statusWithCode5 != null ? statusWithCode5.TransmittedOnDate : DateTime.MinValue;
                        treatmentPosition.DateOfTransmision = statusWithCode2 == null ? DateTime.MinValue : statusWithCode2.TransmittedOnDate;

                        treatmentPosition.TransmitionStatus_Comment1 = comment1;
                        treatmentPosition.GPOS = currentBillData.External_PositionCode;
                        treatmentPosition.PositionProcessNumber = Int64.Parse(currentBillData.External_PositionReferenceField);
                        treatmentPosition.positionSequence = treatmentPosition.PositionProcessNumber;
                        treatmentPosition.Price = 60;

                        treatmentPosition.DateOfSecondLastStatusChange = DateTime.MinValue;
                        treatmentPosition.SecondLastStatusChange = emptyDataConstant;
                        if (currentBillData.Statuses.Where(s => !s.IsActive).Count() > 0)
                        {
                            var secondLastStatus = currentBillData.Statuses.Where(s => !s.IsActive).OrderByDescending(s => s.TransmittedOnDate).First();
                            if (currentBillData.Statuses.Where(s => !s.IsActive && s.TransmittedOnDate == secondLastStatus.TransmittedOnDate).Count() > 1)
                                secondLastStatus = currentBillData.Statuses.Where(s => !s.IsActive && s.TransmittedOnDate == secondLastStatus.TransmittedOnDate).OrderByDescending(s => s.TransmitionCode).First();

                            treatmentPosition.DateOfSecondLastStatusChange = secondLastStatus.TransmittedOnDate;
                            switch (secondLastStatus.TransmitionCode)
                            {
                                case 7:
                                    treatmentPosition.SecondLastStatusChange = "storniert";
                                    break;

                                case 6:
                                    treatmentPosition.SecondLastStatusChange = secondLastStatus.PrimaryComment.Contains("|") ? secondLastStatus.PrimaryComment.Split('|')[0].Trim() : "Process status error!";
                                    break;

                                default:
                                    treatmentPosition.SecondLastStatusChange = secondLastStatus.PrimaryComment;
                                    break;
                            }

                        }
                    }
                    else
                    {
                        treatmentPosition.positionSequence = long.MaxValue - 2;
                        treatmentPosition.TransmitionStatus_Comment1 = "offen";
                    }
                }
                positions.Add(treatmentPosition);

                #endregion
            }
            returnValue.Result.Positions = positions.Where(p => Parameter.statusFilter.Contains(p.positionStatus))
               .OrderBy(p => p.positionSequence).ToArray();

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L6TR_GTI_fTR_1816 Invoke(string ConnectionString, P_L6TR_GTI_fTR_1816 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L6TR_GTI_fTR_1816 Invoke(DbConnection Connection, P_L6TR_GTI_fTR_1816 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L6TR_GTI_fTR_1816 Invoke(DbConnection Connection, DbTransaction Transaction, P_L6TR_GTI_fTR_1816 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L6TR_GTI_fTR_1816 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L6TR_GTI_fTR_1816 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L6TR_GTI_fTR_1816 functionReturn = new FR_L6TR_GTI_fTR_1816();
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

                throw new Exception("Exception occured in method cls_Get_TreatmentsInfo_for_TimeRange", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L6TR_GTI_fTR_1816 : FR_Base
    {
        public L6TR_GTI_fTR_1816 Result { get; set; }

        public FR_L6TR_GTI_fTR_1816() : base() { }

        public FR_L6TR_GTI_fTR_1816(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_L6TR_GTI_fTR_1816 for attribute P_L6TR_GTI_fTR_1816
    [DataContract]
    public class P_L6TR_GTI_fTR_1816
    {
        //Standard type parameters
        [DataMember]
        public Guid LanguageID { get; set; }
        [DataMember]
        public DateTime fromDate { get; set; }
        [DataMember]
        public DateTime toDate { get; set; }
        [DataMember]
        public int[] statusFilter { get; set; }

    }
    #endregion
    #region SClass L6TR_GTI_fTR_1816 for attribute L6TR_GTI_fTR_1816
    [DataContract]
    public class L6TR_GTI_fTR_1816
    {
        [DataMember]
        public L6TR_GTI_fTR_1816_Position[] Positions { get; set; }

        //Standard type parameters
    }
    #endregion
    #region SClass L6TR_GTI_fTR_1816_Position for attribute Positions
    [DataContract]
    public class L6TR_GTI_fTR_1816_Position
    {
        //Standard type parameters
        [DataMember]
        public int positionStatus { get; set; }
        [DataMember]
        public long positionSequence { get; set; }
        [DataMember]
        public string HICompanyName { get; set; }
        [DataMember]
        public string InsuranceStateCode { get; set; }
        [DataMember]
        public string HealthInsuranceNumber { get; set; }
        [DataMember]
        public string PatientFirstName { get; set; }
        [DataMember]
        public string PatientLastName { get; set; }
        [DataMember]
        public DateTime PatientDOB { get; set; }
        [DataMember]
        public long PositionProcessNumber { get; set; }
        [DataMember]
        public string TreatmentType { get; set; }
        [DataMember]
        public string GPOS { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int NumberOfNegativeTries { get; set; }
        [DataMember]
        public DateTime DateOfTransmision { get; set; }
        [DataMember]
        public string TransmitionStatus_Comment2 { get; set; }
        [DataMember]
        public DateTime DateOfPayment { get; set; }
        [DataMember]
        public string TransmitionStatus_Comment1 { get; set; }
        [DataMember]
        public DateTime DateOfLastStatusChange { get; set; }
        [DataMember]
        public DateTime DateOfSecondLastStatusChange { get; set; }
        [DataMember]
        public string SecondLastStatusChange { get; set; }
        [DataMember]
        public string DiagnoseCode { get; set; }
        [DataMember]
        public string DiagnoseState { get; set; }
        [DataMember]
        public string DiagnoseName { get; set; }
        [DataMember]
        public string DiagnoseLocalization { get; set; }
        [DataMember]
        public string ArticleName { get; set; }
        [DataMember]
        public DateTime TreatmentDate { get; set; }
        [DataMember]
        public DateTime TreatmentDateFromOriginalTreatment { get; set; }
        [DataMember]
        public string BSNR { get; set; }
        [DataMember]
        public string PracticeName { get; set; }
        [DataMember]
        public string LANR { get; set; }
        [DataMember]
        public string DoctroFullName { get; set; }
        [DataMember]
        public string AccountOwner { get; set; }
        [DataMember]
        public string BLZ { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string IBAN { get; set; }
        [DataMember]
        public string BIC { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6TR_GTI_fTR_1816 cls_Get_TreatmentsInfo_for_TimeRange(,P_L6TR_GTI_fTR_1816 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6TR_GTI_fTR_1816 invocationResult = cls_Get_TreatmentsInfo_for_TimeRange.Invoke(connectionString,P_L6TR_GTI_fTR_1816 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Complex.Retrieval.P_L6TR_GTI_fTR_1816();
parameter.LanguageID = ...;
parameter.fromDate = ...;
parameter.toDate = ...;
parameter.statusFilter = ...;

*/
