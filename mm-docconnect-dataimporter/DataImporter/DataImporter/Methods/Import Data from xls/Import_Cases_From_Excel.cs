using CL1_HEC;
using CL1_HEC_DIA;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Case.Atomic.Manipulation;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.DBMethods.Patient.Atomic.Retrieval;
using DataImporter.Elastic_Methods.Doctor.Manipulation;
using DataImporter.Excel_Templates;
using DataImporter.Models;
using DLExcelUtils;
using MMDocConnectElasticSearchMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Methods.Import_Data_from_xls
{
    class Import_Cases_From_Excel
    {
        public static void Import_Cases(string connectionString, SessionSecurityTicket securityTicket)
        {
            string folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(folder, "Excel\\cases.xlsx");
            bool hasHeader = true;
            IFormatProvider culture = new System.Globalization.CultureInfo("de", true);
            DataTable excelData = null;
            Console.WriteLine("Loading data from excel...");
            try
            {
                excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
            }
            catch (Exception ex)
            {
                filePath = Path.Combine(folder, "Excel\\cases.xls");
                excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
            }

            List<CaseModel> cases = new List<CaseModel>();
            int i = 1;
            Console.WriteLine();
            try
            {
                foreach (System.Data.DataRow item in excelData.Rows)
                {
                    CaseModel _case = new CaseModel();

                    #region CASE IMPORT
                    _case.patientFirstName = (string)item.ItemArray[0];
                    _case.patientLastName = (string)item.ItemArray[1];
                    _case.hip = (string)item.ItemArray[2];
                    _case.treatmentDate = (string)item.ItemArray[3];
                    _case.drugName = (string)item.ItemArray[4];
                    _case.pzn = (string)item.ItemArray[5];
                    _case.icd10 = (string)item.ItemArray[6];
                    _case.localization = (string)item.ItemArray[7];
                    _case.opDocFirstName = (string)item.ItemArray[8];
                    _case.opDocLastName = (string)item.ItemArray[9];
                    _case.opDocLANR = (string)item.ItemArray[10];
                    _case.treatmentPractice.BSNR = (string)item.ItemArray[11];
                    _case.treatmentPractice.Name = (string)item.ItemArray[12];
                    _case.acDocFirstName = (string)item.ItemArray[13];
                    _case.acDocLastName = (string)item.ItemArray[14];
                    _case.acDocLANR = (string)item.ItemArray[15];
                    _case.aftercarePractice.BSNR = (string)item.ItemArray[16];
                    _case.aftercarePractice.Name = (string)item.ItemArray[17];
                    _case.op1 = (string)item.ItemArray[18];
                    _case.op2 = (string)item.ItemArray[19];
                    _case.op5 = (string)item.ItemArray[20];
                    _case.op6 = (string)item.ItemArray[21];
                    _case.op7 = (string)item.ItemArray[22];
                    _case.op8 = (string)item.ItemArray[23];
                    _case.op10 = (string)item.ItemArray[24];
                    _case.ac1 = (string)item.ItemArray[25];
                    _case.ac2 = (string)item.ItemArray[26];
                    _case.ac6 = (string)item.ItemArray[27];
                    _case.ac7 = (string)item.ItemArray[28];
                    _case.ac8 = (string)item.ItemArray[29];
                    _case.ac9 = (string)item.ItemArray[30];
                    _case.ac11 = (string)item.ItemArray[31];
                    _case.opSettlementNumber = (string)item.ItemArray[32];
                    _case.opFSStatuses.gpos = (string)item.ItemArray[33];
                    _case.opFSStatuses.fs1 = (string)item.ItemArray[34];
                    _case.opFSStatuses.fs2 = (string)item.ItemArray[35];
                    _case.opFSStatuses.fs4 = (string)item.ItemArray[36];
                    _case.opFSStatuses.fs5 = (string)item.ItemArray[37];
                    _case.opFSStatuses.fs7 = (string)item.ItemArray[38];
                    _case.opFSStatuses.fs8 = (string)item.ItemArray[39];
                    _case.acSettlementNumber = (string)item.ItemArray[40];
                    _case.acFSStatuses.gpos = (string)item.ItemArray[41];
                    _case.acFSStatuses.fs1 = (string)item.ItemArray[42];
                    _case.acFSStatuses.fs2 = (string)item.ItemArray[43];
                    _case.acFSStatuses.fs4 = (string)item.ItemArray[44];
                    _case.acFSStatuses.fs5 = (string)item.ItemArray[45];
                    _case.acFSStatuses.fs7 = (string)item.ItemArray[46];
                    _case.acFSStatuses.fs8 = (string)item.ItemArray[47];
                    _case.bevacizumabSettlementNumber = (string)item.ItemArray[48];
                    _case.bevacizumabFSStatuses.gpos = (string)item.ItemArray[49];
                    _case.bevacizumabFSStatuses.fs1 = (string)item.ItemArray[50];
                    _case.bevacizumabFSStatuses.fs2 = (string)item.ItemArray[51];
                    _case.bevacizumabFSStatuses.fs4 = (string)item.ItemArray[52];
                    _case.bevacizumabFSStatuses.fs5 = (string)item.ItemArray[53];
                    _case.bevacizumabFSStatuses.fs7 = (string)item.ItemArray[54];
                    _case.bevacizumabFSStatuses.fs8 = (string)item.ItemArray[55];
                    _case.managementFeeSettlementNumber = (string)item.ItemArray[56];
                    _case.managementFeeFSStatuses.gpos = (string)item.ItemArray[57];
                    _case.managementFeeFSStatuses.fs1 = (string)item.ItemArray[58];
                    _case.managementFeeFSStatuses.fs2 = (string)item.ItemArray[59];
                    _case.managementFeeFSStatuses.fs4 = (string)item.ItemArray[60];
                    _case.managementFeeFSStatuses.fs5 = (string)item.ItemArray[61];
                    _case.managementFeeFSStatuses.fs7 = (string)item.ItemArray[62];
                    _case.managementFeeFSStatuses.fs8 = (string)item.ItemArray[63];
                    _case.comments.opPrimaryComment = (string)item.ItemArray[64];
                    _case.comments.acPrimaryComment = (string)item.ItemArray[65];
                    _case.comments.bevaPrimaryComment = (string)item.ItemArray[66];
                    _case.comments.manPrimaryComment = (string)item.ItemArray[67];
                    _case.comments.opSecondaryComment = (string)item.ItemArray[68];
                    _case.comments.acSecondaryComment = (string)item.ItemArray[69];
                    _case.comments.bevaSecondaryComment = (string)item.ItemArray[70];
                    _case.comments.manSecondaryComment = (string)item.ItemArray[71];
                    #endregion

                    #region PATIENT DATA
                    if (string.IsNullOrEmpty(_case.patientFirstName))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Patient's first name empty" : _case.validationMessages + ", patient first name empty";
                    }

                    if (string.IsNullOrEmpty(_case.patientLastName))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Patient's last name empty" : _case.validationMessages + ", patient last name empty";
                    }

                    if (string.IsNullOrEmpty(_case.hip))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Patient's HIP number empty" : _case.validationMessages + ", patient HIP number empty";
                    }
                    #endregion

                    #region TREATMENT DATA
                    if (string.IsNullOrEmpty(_case.treatmentDate))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment date empty" : _case.validationMessages + ", treatment date empty";
                    }

                    if (string.IsNullOrEmpty(_case.drugName))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Drug name empty" : _case.validationMessages + ", drug name empty";
                    }

                    if (string.IsNullOrEmpty(_case.icd10))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Diagnose code empty" : _case.validationMessages + ", diagnose code empty";
                    }

                    if (string.IsNullOrEmpty(_case.localization))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Localization empty" : _case.validationMessages + ", localization empty";
                    }

                    if (string.IsNullOrEmpty(_case.opDocFirstName))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "OP doctor's first name empty" : _case.validationMessages + ", OP doctor's first name empty";
                    }

                    if (string.IsNullOrEmpty(_case.opDocLastName))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "OP doctor's last name empty" : _case.validationMessages + ", OP doctor's last name empty";
                    }

                    if (string.IsNullOrEmpty(_case.opDocLANR))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "OP doctor's LANR empty" : _case.validationMessages + ", OP doctor's LANR empty";
                    }

                    if (string.IsNullOrEmpty(_case.treatmentPractice.BSNR))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "OP practice's BSNR empty" : _case.validationMessages + ", OP practice's BSNR empty";
                    }

                    if (string.IsNullOrEmpty(_case.treatmentPractice.Name))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "OP practice's name empty" : _case.validationMessages + ", OP practice's name empty";
                    }
                    #endregion

                    #region OP8
                    if (!string.IsNullOrEmpty(_case.op8))
                    {
                        if (string.IsNullOrEmpty(_case.op6))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but wasn't in status OP6 before (Confirmed by HIP)" : _case.validationMessages + ", treatment in status OP8 (Payment in progress), but wasn't in status OP6 before (Confirmed by HIP)";
                        }

                        if (string.IsNullOrEmpty(_case.opFSStatuses.fs4))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but wasn't in status FS4 before (Confirmed by HIP)" : _case.validationMessages + ", treatment in status OP8 (Payment in progress), but wasn't in status FS4 before (Confirmed by HIP)";
                        }

                        if (string.IsNullOrEmpty(_case.localization))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but localization empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but localization empty";
                        }
                        else
                        {
                            if (_case.localization != "L" && _case.localization != "R")
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but localization different from L/R" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but localization different from L/R";
                            }
                        }

                        if (string.IsNullOrEmpty(_case.icd10))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but diagnose icd-10 code empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but diagnose icd-10 code empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but OP doctor's first name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but OP doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but OP doctor's last name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but OP doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but OP doctor's LANR empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but OP doctor's LANR empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but AC doctor's first name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but AC doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but AC doctor's last name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but AC doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but AC doctor's LANR empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but AC doctor's LANR empty";
                        }
                    }
                    #endregion

                    #region AC9
                    if (!string.IsNullOrEmpty(_case.ac9))
                    {
                        if (string.IsNullOrEmpty(_case.ac7))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare in status AC9 (Payment in progress), but wasn't in status AC7 before (Confirmed by HIP)" : _case.validationMessages + ", aftercare in status AC9 (Payment in progress), but wasn't in status AC7 before (Confirmed by HIP)";
                        }

                        if (string.IsNullOrEmpty(_case.acFSStatuses.fs4))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare in status AC9 (Payment in progress), but wasn't in status FS4 before (Confirmed by HIP)" : _case.validationMessages + ", aftercare in status AC9 (Payment in progress), but wasn't in status FS4 before (Confirmed by HIP)";
                        }

                        if (string.IsNullOrEmpty(_case.localization))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but localization empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but localization empty";
                        }
                        else
                        {
                            if (_case.localization != "L" && _case.localization != "R")
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but localization different from L/R" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but localization different from L/R";
                            }
                        }

                        if (string.IsNullOrEmpty(_case.icd10))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but diagnose icd-10 code empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but diagnose icd-10 code empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but OP doctor's first name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but OP doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but OP doctor's last name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but OP doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but OP doctor's LANR empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but OP doctor's LANR empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but AC doctor's first name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but AC doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but AC doctor's last name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but AC doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but AC doctor's LANR empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but AC doctor's LANR empty";
                        }
                    }
                    #endregion

                    #region FS1
                    if (!string.IsNullOrEmpty(_case.opFSStatuses.fs1))
                    {
                        if (string.IsNullOrEmpty(_case.drugName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but drug name empty" : _case.validationMessages + ", case submitted to MM (FS1), but drug name empty";
                        }

                        if (string.IsNullOrEmpty(_case.localization))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but localization empty" : _case.validationMessages + ", case submitted to MM (FS1), but localization empty";
                        }
                        else
                        {
                            if (_case.localization != "L" && _case.localization != "R")
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but localization different from L/R" : _case.validationMessages + ", case submitted to MM (FS1), but localization different from L/R";
                            }
                        }

                        if (string.IsNullOrEmpty(_case.icd10))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but diagnose icd-10 code empty" : _case.validationMessages + ", case submitted to MM (FS1), but diagnose icd-10 code empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but OP doctor's first name empty" : _case.validationMessages + ", case submitted to MM (FS1), but OP doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but OP doctor's last name empty" : _case.validationMessages + ", Case submitted to MM (FS1), but OP doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but OP doctor's LANR empty" : _case.validationMessages + ", Case submitted to MM (FS1), but OP doctor's LANR empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but AC doctor's first name empty" : _case.validationMessages + ", case submitted to MM (FS1), but AC doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but AC doctor's last name empty" : _case.validationMessages + ", Case submitted to MM (FS1), but AC doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but AC doctor's LANR empty" : _case.validationMessages + ", Case submitted to MM (FS1), but AC doctor's LANR empty";
                        }
                    }

                    #region AC
                    if (!string.IsNullOrEmpty(_case.acFSStatuses.fs1))
                    {
                        if (string.IsNullOrEmpty(_case.ac2))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare submitted to MM (FS1), but wasn't in AC2 status previously" : _case.validationMessages + ", aftercare submitted to MM (FS1), but wasn't in AC2 status previously";
                        }
                    }
                    #endregion

                    #endregion
                    #region FS2
                    #region OP
                    if (!string.IsNullOrEmpty(_case.opFSStatuses.fs2))
                    {
                        if (string.IsNullOrEmpty(_case.opFSStatuses.fs1))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but wasn't in FS1 status previously" : _case.validationMessages + ", case submitted to HIP (FS2), but wasn't in FS1 status previously";

                            if (string.IsNullOrEmpty(_case.drugName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but drug name empty" : _case.validationMessages + ", case submitted to HIP (FS2), but drug name empty";
                            }


                            if (string.IsNullOrEmpty(_case.localization))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but localization empty" : _case.validationMessages + ", case submitted to HIP (FS2), but localization empty";
                            }
                            else
                            {
                                if (_case.localization != "L" && _case.localization != "R")
                                {
                                    _case.isValid = false;
                                    _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but localization different from L/R" : _case.validationMessages + ", case submitted to HIP (FS2), but localization different from L/R";
                                }
                            }

                            if (string.IsNullOrEmpty(_case.icd10))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but diagnose icd-10 code empty" : _case.validationMessages + ", case submitted to HIP (FS2), but diagnose icd-10 code empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocFirstName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but OP doctor's first name empty" : _case.validationMessages + ", case submitted to HIP (FS2), but OP doctor's first name empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocLastName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but OP doctor's last name empty" : _case.validationMessages + ", case submitted to HIP (FS2), but OP doctor's last name empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocLANR))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but OP doctor's LANR empty" : _case.validationMessages + ", case submitted to HIP (FS2), but OP doctor's LANR empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocFirstName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but AC doctor's first name empty" : _case.validationMessages + ", case submitted to HIP (FS2), but AC doctor's first name empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocLastName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but AC doctor's last name empty" : _case.validationMessages + ", case submitted to HIP (FS2), but AC doctor's last name empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocLANR))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but AC doctor's LANR empty" : _case.validationMessages + ", case submitted to HIP (FS2), but AC doctor's LANR empty";
                            }
                        }
                    }
                    #endregion

                    #region AC
                    if (!string.IsNullOrEmpty(_case.acFSStatuses.fs2))
                    {
                        if (string.IsNullOrEmpty(_case.acFSStatuses.fs1))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare submitted to HIP (FS2), but wasn't in FS1 status previously" : _case.validationMessages + ", aftercare submitted to HIP (FS2), but wasn't in FS1 status previously";
                        }
                    }
                    #endregion
                    #endregion

                    #region FS4
                    if (!string.IsNullOrEmpty(_case.opFSStatuses.fs4))
                    {
                        if (string.IsNullOrEmpty(_case.opFSStatuses.fs2))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but wasn't in FS2 previously" : _case.validationMessages + ", case confirmed by HIP (FS4), but wasn't in FS2 previously";


                            if (string.IsNullOrEmpty(_case.drugName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but drug name empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but drug name empty";
                            }


                            if (string.IsNullOrEmpty(_case.localization))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but localization empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but localization empty";
                            }
                            else
                            {
                                if (_case.localization != "L" && _case.localization != "R")
                                {
                                    _case.isValid = false;
                                    _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but localization different from L/R" : _case.validationMessages + ", case confirmed by HIP (FS4), but localization different from L/R";
                                }
                            }

                            if (string.IsNullOrEmpty(_case.icd10))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but diagnose icd-10 code empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but diagnose icd-10 code empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocFirstName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but OP doctor's first name empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but OP doctor's first name empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocLastName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but OP doctor's last name empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but OP doctor's last name empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocLANR))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but OP doctor's LANR empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but OP doctor's LANR empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocFirstName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but AC doctor's first name empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but AC doctor's first name empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocLastName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but AC doctor's last name empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but AC doctor's last name empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocLANR))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but AC doctor's LANR empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but AC doctor's LANR empty";
                            }
                        }
                    }

                    #region AC
                    if (!string.IsNullOrEmpty(_case.acFSStatuses.fs4))
                    {
                        if (string.IsNullOrEmpty(_case.acFSStatuses.fs2))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare confirmed by HIP (FS4), but wasn't in FS2 previously" : _case.validationMessages + ", aftercare confirmed by HIP (FS4), but wasn't in FS2 previously";
                        }
                    }
                    #endregion
                    #endregion

                    #region FS5
                    if (!string.IsNullOrEmpty(_case.opFSStatuses.fs5))
                    {
                        if (string.IsNullOrEmpty(_case.opFSStatuses.fs2))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but wasn't in FS2 previously" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but wasn't in FS2 previously";
                        }

                        if (string.IsNullOrEmpty(_case.drugName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but drug name empty" : _case.validationMessages + ", Case in FS5 status (Error feedback from HIP), but drug name empty";
                        }


                        if (string.IsNullOrEmpty(_case.localization))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but localization empty" : _case.validationMessages + ", Case in FS5 status (Error feedback from HIP), but localization empty";
                        }
                        else
                        {
                            if (_case.localization != "L" && _case.localization != "R")
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but localization different from L/R" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but localization different from L/R";
                            }
                        }

                        if (string.IsNullOrEmpty(_case.icd10))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but diagnose icd-10 code empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but diagnose icd-10 code empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but OP doctor's first name empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but OP doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but OP doctor's last name empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but OP doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but OP doctor's LANR empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but OP doctor's LANR empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but AC doctor's first name empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but AC doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but AC doctor's last name empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but AC doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but AC doctor's LANR empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but AC doctor's LANR empty";
                        }
                    }

                    if (!string.IsNullOrEmpty(_case.acFSStatuses.fs5))
                    {
                        if (string.IsNullOrEmpty(_case.acFSStatuses.fs2))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare in FS5 status (Error feedback from HIP), but wasn't in FS2 previously" : _case.validationMessages + ", aftercare in FS5 status (Error feedback from HIP), but wasn't in FS2 previously";
                        }
                    }
                    #endregion

                    #region FS7
                    if (!string.IsNullOrEmpty(_case.opFSStatuses.fs7))
                    {
                        if (string.IsNullOrEmpty(_case.opFSStatuses.fs4))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but wasn't in FS4 previously" : _case.validationMessages + ", case paid (FS7), but wasn't in FS4 previously";


                            if (string.IsNullOrEmpty(_case.drugName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but drug name empty" : _case.validationMessages + ", case paid (FS7), but drug name empty";
                            }


                            if (string.IsNullOrEmpty(_case.localization))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but localization empty" : _case.validationMessages + ", case paid (FS7), but localization empty";
                            }
                            else
                            {
                                if (_case.localization != "L" && _case.localization != "R")
                                {
                                    _case.isValid = false;
                                    _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but localization different from L/R" : _case.validationMessages + ", case paid (FS7), but localization different from L/R";
                                }
                            }

                            if (string.IsNullOrEmpty(_case.icd10))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but diagnose icd-10 code empty" : _case.validationMessages + ", case paid (FS7), but diagnose icd-10 code empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocFirstName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but OP doctor's first name empty" : _case.validationMessages + ", case paid (FS7), but OP doctor's first name empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocLastName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but OP doctor's last name empty" : _case.validationMessages + ", case paid (FS7), but OP doctor's last name empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocLANR))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but OP doctor's LANR empty" : _case.validationMessages + ", case paid (FS7), but OP doctor's LANR empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocFirstName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but AC doctor's first name empty" : _case.validationMessages + ", case paid (FS7), but AC doctor's first name empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocLastName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but AC doctor's last name empty" : _case.validationMessages + ", case paid (FS7), but AC doctor's last name empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocLANR))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but AC doctor's LANR empty" : _case.validationMessages + ", case paid (FS7), but AC doctor's LANR empty";
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(_case.acFSStatuses.fs7))
                    {
                        if (string.IsNullOrEmpty(_case.acFSStatuses.fs4))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare paid (FS7), but wasn't in FS4 previously" : _case.validationMessages + ", aftercare paid (FS7), but wasn't in FS4 previously";
                        }
                    }
                    #endregion

                    #region GPOS
                    if (!string.IsNullOrEmpty(_case.opFSStatuses.fs2))
                    {
                        if (string.IsNullOrEmpty(_case.opFSStatuses.gpos))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case OP Gpos missing" : _case.validationMessages + ", case OP GPOS missing";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(_case.opSettlementNumber))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case OP settlement number missing" : _case.validationMessages + ", case OP settlement number missing";
                            }
                        }

                        if (string.IsNullOrEmpty(_case.managementFeeFSStatuses.gpos))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case Management fee Gpos missing" : _case.validationMessages + ", case Management fee GPOS missing";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(_case.opSettlementNumber))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case Management fee settlement number missing" : _case.validationMessages + ", case Management fee settlement number missing";
                            }
                        }

                        if (_case.drugName.Contains("Bevacizumab") && string.IsNullOrEmpty(_case.bevacizumabFSStatuses.gpos))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case Bevacizumab Gpos missing" : _case.validationMessages + ", case Bevacizumab GPOS missing";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(_case.opSettlementNumber))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case Bevacizumab settlement number missing" : _case.validationMessages + ", case Bevacizumab settlement number missing";
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(_case.acFSStatuses.fs2))
                    {
                        if (string.IsNullOrEmpty(_case.acFSStatuses.gpos))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case AC Gpos missing" : _case.validationMessages + ", case AC GPOS missing";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(_case.opSettlementNumber))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case OP settlement number missing" : _case.validationMessages + ", case OP settlement number missing";
                            }
                        }
                    }
                    #endregion

                    cases.Add(_case);
                    Console.Write("\rCase {0} of {1} validated.", i++, excelData.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.Write(ex.StackTrace);
            }


            string file = ExportCasesBeforeUpload.ExportCasesBeforeUploadToDB(cases);
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));
            Console.WriteLine("----- XLS created.");

            if (cases.Any(vl => !vl.isValid))
            {
                Console.WriteLine("Data not valid, won't be saved.");
            }
            else
            {
                DbConnection Connection = null;
                DbTransaction Transaction = null;

                #region IMPORT CASES
                bool cleanupConnection = Connection == null;
                bool cleanupTransaction = Transaction == null;

                try
                {
                    if (cleanupConnection == true)
                    {
                        Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
                        Connection.Open();
                    }
                    if (cleanupTransaction == true)
                    {
                        Transaction = Connection.BeginTransaction();
                    }

                    int ii = 1;

                    foreach (var _case in cases)
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        var aftercare_doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false, DoctorIDNumber = _case.acDocLANR }).SingleOrDefault();
                        var treatment_doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false, DoctorIDNumber = _case.opDocLANR }).SingleOrDefault();
                        var diagnose = ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query.Search(Connection, Transaction, new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false, Code = _case.icd10 }).SingleOrDefault();
                        var treatment_practice = cls_Get_PracticeID_for_BSNR.Invoke(Connection, Transaction, new P_DO_GPIDfBSNR_1011() { BSNR = _case.treatmentPractice.BSNR }, securityTicket).Result;
                        var aftercare_practice = cls_Get_PracticeID_for_BSNR.Invoke(Connection, Transaction, new P_DO_GPIDfBSNR_1011() { BSNR = _case.aftercarePractice.BSNR }, securityTicket).Result;
                        var patient = cls_Get_PatientID_for_HIP_and_PracticeID.Invoke(Connection, Transaction, new P_PA_GPIDfHIPaPID_1402() { HIP = _case.hip, PracticeID = treatment_practice.practice_id }, securityTicket).Result;
                        if (patient == null)
                        {
                            patient = cls_Get_PatientID_for_HIP_and_PracticeID.Invoke(Connection, Transaction, new P_PA_GPIDfHIPaPID_1402() { HIP = _case.hip, PracticeID = aftercare_practice.practice_id }, securityTicket).Result;
                        }

                        var drug = cls_Get_DrugID_for_DrugName_and_PZN.Invoke(Connection, Transaction, new P_DO_GDIDfDNaPZN_1027()
                        {
                            DrugName = !_case.drugName.Contains("Lucentis") ? _case.drugName + "%" : _case.pzn == "67760" ? _case.drugName + " DFL%" : _case.drugName + " FSP%"
                        }, securityTicket).Result;

                        if (aftercare_doctor != null && treatment_doctor != null && patient != null && diagnose != null && treatment_practice != null && aftercare_practice != null && drug != null)
                        {
                            var submitted_case_id = Guid.Empty;
                            var case_id = Guid.Empty;

                            #region CREATE NEW CASE
                            try
                            {
                                case_id = cls_Save_Case.Invoke(Connection, Transaction, new P_CAS_SC_1711()
                                {
                                    aftercare_doctor_practice_id = aftercare_doctor.HEC_DoctorID,
                                    diagnose_id = diagnose.PotentialDiagnosis_RefID,
                                    is_confirmed = true,
                                    is_left_eye = _case.localization.Equals("L"),
                                    patient_id = patient.patient_id,
                                    treatment_date = DateTime.ParseExact(_case.op1, "dd.MM.yyyy", culture),
                                    treatment_doctor_id = treatment_doctor.HEC_DoctorID,
                                    practice_id = treatment_practice.practice_id,
                                    drug_id = drug.drug_id,
                                    treatment_gpos = _case.opFSStatuses.gpos,
                                    bevacizumab_gpos = _case.bevacizumabFSStatuses.gpos,
                                    management_fee_gpos = _case.managementFeeFSStatuses.gpos,
                                    aftercare_gpos = _case.acFSStatuses.gpos
                                }, securityTicket).Result;
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message + "\n case number: " + ii + " op1: " + _case.op1, ex);
                            }
                            #endregion

                            Console.Write("\r                   ");
                            Console.Write("\r.");
                            #region SUBMIT TREATMENT - FS1
                            try
                            {
                                if (!string.IsNullOrEmpty(_case.opFSStatuses.fs1))
                                {
                                    submitted_case_id = cls_Submit_Case.Invoke(Connection, Transaction, new P_CAS_SC_1425()
                                    {
                                        case_id = case_id,
                                        is_treatment = true,
                                        practice_id = treatment_practice.practice_id,
                                        date_of_performed_action = DateTime.ParseExact(_case.op2, "dd.MM.yyyy", culture),
                                        date_of_submission = DateTime.ParseExact(_case.opFSStatuses.fs1, "dd.MM.yyyy", culture),
                                        treatment_gpos = _case.opFSStatuses.gpos,
                                        bevacizumab_gpos = _case.bevacizumabFSStatuses.gpos,
                                        management_fee_gpos = _case.managementFeeFSStatuses.gpos,
                                        aftercare_gpos = "",
                                        aftercare_bill_number = "",
                                        treatment_bill_number = _case.opSettlementNumber,
                                        management_fee_bill_number = _case.managementFeeSettlementNumber,
                                        bevacizumab_bill_number = _case.bevacizumabSettlementNumber
                                    }, securityTicket).Result;
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message + "\n case number: " + ii + " op2: " + _case.op2 + " op-fs1: " + _case.opFSStatuses.fs1, ex);
                            }
                            #endregion

                            Console.Write(".");

                            #region SUBMIT AFTERCARE - FS1
                            try
                            {
                                if (!string.IsNullOrEmpty(_case.acFSStatuses.fs1))
                                {
                                    submitted_case_id = cls_Submit_Case.Invoke(Connection, Transaction, new P_CAS_SC_1425()
                                    {
                                        case_id = case_id,
                                        is_treatment = false,
                                        practice_id = aftercare_practice.practice_id,
                                        date_of_performed_action = DateTime.ParseExact(_case.ac2, "dd.MM.yyyy", culture),
                                        date_of_submission = DateTime.ParseExact(_case.acFSStatuses.fs1, "dd.MM.yyyy", culture),
                                        treatment_gpos = "",
                                        aftercare_gpos = _case.acFSStatuses.gpos,
                                        bevacizumab_gpos = "",
                                        management_fee_gpos = "",
                                        aftercare_bill_number = _case.acSettlementNumber
                                    }, securityTicket).Result;
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message + "\n case number: " + ii + " ac2: " + _case.ac2 + " ac-fs1: " + _case.acFSStatuses.fs1, ex);
                            }
                            #endregion

                            Console.Write(".");

                            #region SUBMIT TREATMENT TO HIP - FS2
                            if (!string.IsNullOrEmpty(_case.opFSStatuses.fs2))
                            {
                                cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_CPASfPAID_1654()
                                {
                                    change_status = true,
                                    new_status = 2,
                                    status_date = DateTime.ParseExact(_case.opFSStatuses.fs2, "dd.MM.yyyy", culture),
                                    planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result.planned_action_id
                                }, securityTicket);
                            }
                            #endregion

                            Console.Write(".");

                            #region SUBMIT AFTERCARE TO HIP - FS2
                            if (!string.IsNullOrEmpty(_case.acFSStatuses.fs2))
                            {
                                cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_CPASfPAID_1654()
                                {
                                    change_status = true,
                                    new_status = 2,
                                    status_date = DateTime.ParseExact(_case.acFSStatuses.fs2, "dd.MM.yyyy", culture),
                                    planned_action_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_id }, securityTicket).Result.planned_action_id
                                }, securityTicket);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET TREATMENT AS CONFIRMED - FS4
                            if (!string.IsNullOrEmpty(_case.opFSStatuses.fs4))
                            {
                                cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_CPASfPAID_1654()
                                {
                                    change_status = true,
                                    new_status = 4,
                                    status_date = DateTime.ParseExact(_case.opFSStatuses.fs4, "dd.MM.yyyy", culture),
                                    management_fee_waived = cls_Get_Practice_Default_Settings_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDSfPID_0909() { PracticeID = treatment_practice.practice_id }, securityTicket).Result.WaiveServiceFee,
                                    planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result.planned_action_id
                                }, securityTicket);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET AFTERCARE AS CONFIRMED - FS4
                            if (!string.IsNullOrEmpty(_case.acFSStatuses.fs4))
                            {
                                cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_CPASfPAID_1654()
                                {
                                    change_status = true,
                                    new_status = 4,
                                    status_date = DateTime.ParseExact(_case.acFSStatuses.fs4, "dd.MM.yyyy", culture),
                                    management_fee_waived = cls_Get_Practice_Default_Settings_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDSfPID_0909() { PracticeID = aftercare_practice.practice_id }, securityTicket).Result.WaiveServiceFee,
                                    planned_action_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_id }, securityTicket).Result.planned_action_id
                                }, securityTicket);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET TREATMENT AS ERROR - FS5
                            // TODO: Set primary comment
                            if (!string.IsNullOrEmpty(_case.opFSStatuses.fs5))
                            {
                                cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_CPASfPAID_1654()
                                {
                                    change_status = true,
                                    new_status = 5,
                                    primary_comment = _case.comments.opPrimaryComment,
                                    secondary_comment = _case.comments.opSecondaryComment,
                                    status_date = DateTime.ParseExact(_case.opFSStatuses.fs5, "dd.MM.yyyy", culture),
                                    planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result.planned_action_id
                                }, securityTicket);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET AFTERCARE AS ERROR - FS5
                            // TODO: Set primary comment
                            if (!string.IsNullOrEmpty(_case.acFSStatuses.fs5))
                            {
                                cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_CPASfPAID_1654()
                                {
                                    change_status = true,
                                    new_status = 5,
                                    primary_comment = _case.comments.acPrimaryComment,
                                    secondary_comment = _case.comments.acSecondaryComment,
                                    status_date = DateTime.ParseExact(_case.acFSStatuses.fs5, "dd.MM.yyyy", culture),
                                    planned_action_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_id }, securityTicket).Result.planned_action_id
                                }, securityTicket);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET TREATMENT AS PAID - FS7
                            if (!string.IsNullOrEmpty(_case.opFSStatuses.fs7))
                            {
                                cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_CPASfPAID_1654()
                                {
                                    change_status = true,
                                    new_status = 7,
                                    status_date = DateTime.ParseExact(_case.opFSStatuses.fs7, "dd.MM.yyyy", culture),
                                    planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result.planned_action_id
                                }, securityTicket);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET AFTERCARE AS PAID - FS7
                            if (!string.IsNullOrEmpty(_case.acFSStatuses.fs7))
                            {
                                cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_CPASfPAID_1654()
                                {
                                    change_status = true,
                                    new_status = 7,
                                    status_date = DateTime.ParseExact(_case.acFSStatuses.fs7, "dd.MM.yyyy", culture),
                                    planned_action_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_id }, securityTicket).Result.planned_action_id
                                }, securityTicket);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET TREATMENT AS CANCELLED - FS8
                            if (!string.IsNullOrEmpty(_case.opFSStatuses.fs8))
                            {
                                cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_CPASfPAID_1654()
                                {
                                    change_status = true,
                                    new_status = 8,
                                    status_date = DateTime.ParseExact(_case.opFSStatuses.fs8, "dd.MM.yyyy", culture),
                                    planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result.planned_action_id
                                }, securityTicket);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET AFTERCARE AS CANCELLED - FS8
                            if (!string.IsNullOrEmpty(_case.acFSStatuses.fs8))
                            {
                                cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_CPASfPAID_1654()
                                {
                                    change_status = true,
                                    new_status = 8,
                                    status_date = DateTime.ParseExact(_case.acFSStatuses.fs8, "dd.MM.yyyy", culture),
                                    planned_action_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_id }, securityTicket).Result.planned_action_id
                                }, securityTicket);
                            }
                            #endregion

                            Console.Write(".");
                            sw.Stop();

                            var remaining = cases.Count - ii;
                            double elapsed = sw.ElapsedMilliseconds / 1000;
                            double mins = remaining * elapsed / 60;
                            double hrs = mins / 60;

                            Console.WriteLine("Estimated time to complete: {0} hours, {1} minutes", (int)hrs, Math.Ceiling(mins % 60));

                            Console.WriteLine("\rCase {0} of {1} imported.", ii, cases.Count);
                            ii++;


                        }
                        else
                        {
                            string message = "";

                            message = patient == null ? message + " Patient not found: " + _case.patientFirstName + " " + _case.patientLastName + ", hip number: " + _case.hip : message;
                            message = aftercare_doctor == null ? message + " Aftercare doctor not found:" + _case.acDocFirstName + " " + _case.acDocLastName + ", LANR: " + _case.acDocLANR : message;
                            message = treatment_doctor == null ? message + " Treatment doctor not found: " + _case.opDocFirstName + " " + _case.opDocLastName + ", LANR: " + _case.opDocLANR : message;
                            message = diagnose == null ? message + " Diagnose not found, icd-10: " + _case.icd10 : message;
                            message = aftercare_practice == null ? message + " Aftercare practice not found: " + _case.aftercarePractice.Name + ", bsnr: " + _case.aftercarePractice.BSNR : message;
                            message = treatment_practice == null ? message + " Treatment practice not found: " + _case.treatmentPractice.Name + ", bsnr: " + _case.treatmentPractice.BSNR : message;
                            message = drug == null ? message + "Drug not found: " + _case.drugName + ", pzn: " + _case.pzn : message;

                            throw new Exception(message + string.Format("Case {0} of {1} not imported. Rolling back operation.", ii, cases.Count));
                        }
                    }

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
                    Console.Clear();
                    Console.WriteLine("Deleting cases from elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "case");

                    Console.WriteLine("Deleting aftercares from elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "aftercare");

                    Console.WriteLine("Deleting submitted cases from elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "submitted_case");
                    Console.Write("Something went wrong: " + ex.Message + "\nStack trace:\n");
                    Console.WriteLine("Excetpion stack trace: " + ex.StackTrace);

                    if (ex.InnerException != null)
                        Console.WriteLine("Inner exception stack trace: " + ex.InnerException.StackTrace);

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

                    throw new Exception("Exception occured in method cls_Save_Case", ex);
                }
                #endregion

                Console.WriteLine("\n");
            }
        }

        public static void CleanupElastic(string connectionString, SessionSecurityTicket securityTicket)
        {
            string folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(folder, "Excel\\cases.xlsx");
            bool hasHeader = true;
            IFormatProvider culture = new System.Globalization.CultureInfo("de", true);
            DataTable excelData = null;
            Console.WriteLine("Loading data from excel...");
            try
            {
                excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
            }
            catch (Exception ex)
            {
                filePath = Path.Combine(folder, "Excel\\cases.xls");
                excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
            }

            List<CaseModel> cases = new List<CaseModel>();
            int i = 1;
            Console.WriteLine();
            try
            {
                foreach (System.Data.DataRow item in excelData.Rows)
                {
                    CaseModel _case = new CaseModel();

                    #region CASE IMPORT
                    _case.patientFirstName = (string)item.ItemArray[0];
                    _case.patientLastName = (string)item.ItemArray[1];
                    _case.hip = (string)item.ItemArray[2];
                    _case.treatmentDate = (string)item.ItemArray[3];
                    _case.drugName = (string)item.ItemArray[4];
                    _case.pzn = (string)item.ItemArray[5];
                    _case.icd10 = (string)item.ItemArray[6];
                    _case.localization = (string)item.ItemArray[7];
                    _case.opDocFirstName = (string)item.ItemArray[8];
                    _case.opDocLastName = (string)item.ItemArray[9];
                    _case.opDocLANR = (string)item.ItemArray[10];
                    _case.treatmentPractice.BSNR = (string)item.ItemArray[11];
                    _case.treatmentPractice.Name = (string)item.ItemArray[12];
                    _case.acDocFirstName = (string)item.ItemArray[13];
                    _case.acDocLastName = (string)item.ItemArray[14];
                    _case.acDocLANR = (string)item.ItemArray[15];
                    _case.aftercarePractice.BSNR = (string)item.ItemArray[16];
                    _case.aftercarePractice.Name = (string)item.ItemArray[17];
                    _case.op1 = (string)item.ItemArray[18];
                    _case.op2 = (string)item.ItemArray[19];
                    _case.op5 = (string)item.ItemArray[20];
                    _case.op6 = (string)item.ItemArray[21];
                    _case.op7 = (string)item.ItemArray[22];
                    _case.op8 = (string)item.ItemArray[23];
                    _case.op10 = (string)item.ItemArray[24];
                    _case.ac1 = (string)item.ItemArray[25];
                    _case.ac2 = (string)item.ItemArray[26];
                    _case.ac6 = (string)item.ItemArray[27];
                    _case.ac7 = (string)item.ItemArray[28];
                    _case.ac8 = (string)item.ItemArray[29];
                    _case.ac9 = (string)item.ItemArray[30];
                    _case.ac11 = (string)item.ItemArray[31];
                    _case.opSettlementNumber = (string)item.ItemArray[32];
                    _case.opFSStatuses.gpos = (string)item.ItemArray[33];
                    _case.opFSStatuses.fs1 = (string)item.ItemArray[34];
                    _case.opFSStatuses.fs2 = (string)item.ItemArray[35];
                    _case.opFSStatuses.fs4 = (string)item.ItemArray[36];
                    _case.opFSStatuses.fs5 = (string)item.ItemArray[37];
                    _case.opFSStatuses.fs7 = (string)item.ItemArray[38];
                    _case.opFSStatuses.fs8 = (string)item.ItemArray[39];
                    _case.acSettlementNumber = (string)item.ItemArray[40];
                    _case.acFSStatuses.gpos = (string)item.ItemArray[41];
                    _case.acFSStatuses.fs1 = (string)item.ItemArray[42];
                    _case.acFSStatuses.fs2 = (string)item.ItemArray[43];
                    _case.acFSStatuses.fs4 = (string)item.ItemArray[44];
                    _case.acFSStatuses.fs5 = (string)item.ItemArray[45];
                    _case.acFSStatuses.fs7 = (string)item.ItemArray[46];
                    _case.acFSStatuses.fs8 = (string)item.ItemArray[47];
                    _case.bevacizumabSettlementNumber = (string)item.ItemArray[48];
                    _case.bevacizumabFSStatuses.gpos = (string)item.ItemArray[49];
                    _case.bevacizumabFSStatuses.fs1 = (string)item.ItemArray[50];
                    _case.bevacizumabFSStatuses.fs2 = (string)item.ItemArray[51];
                    _case.bevacizumabFSStatuses.fs4 = (string)item.ItemArray[52];
                    _case.bevacizumabFSStatuses.fs5 = (string)item.ItemArray[53];
                    _case.bevacizumabFSStatuses.fs7 = (string)item.ItemArray[54];
                    _case.bevacizumabFSStatuses.fs8 = (string)item.ItemArray[55];
                    _case.managementFeeSettlementNumber = (string)item.ItemArray[56];
                    _case.managementFeeFSStatuses.gpos = (string)item.ItemArray[57];
                    _case.managementFeeFSStatuses.fs1 = (string)item.ItemArray[58];
                    _case.managementFeeFSStatuses.fs2 = (string)item.ItemArray[59];
                    _case.managementFeeFSStatuses.fs4 = (string)item.ItemArray[60];
                    _case.managementFeeFSStatuses.fs5 = (string)item.ItemArray[61];
                    _case.managementFeeFSStatuses.fs7 = (string)item.ItemArray[62];
                    _case.managementFeeFSStatuses.fs8 = (string)item.ItemArray[63];
                    _case.comments.opPrimaryComment = (string)item.ItemArray[64];
                    _case.comments.acPrimaryComment = (string)item.ItemArray[65];
                    _case.comments.bevaPrimaryComment = (string)item.ItemArray[66];
                    _case.comments.manPrimaryComment = (string)item.ItemArray[67];
                    _case.comments.opSecondaryComment = (string)item.ItemArray[68];
                    _case.comments.acSecondaryComment = (string)item.ItemArray[69];
                    _case.comments.bevaSecondaryComment = (string)item.ItemArray[70];
                    _case.comments.manSecondaryComment = (string)item.ItemArray[71];
                    #endregion

                    #region PATIENT DATA
                    if (string.IsNullOrEmpty(_case.patientFirstName))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Patient's first name empty" : _case.validationMessages + ", patient first name empty";
                    }

                    if (string.IsNullOrEmpty(_case.patientLastName))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Patient's last name empty" : _case.validationMessages + ", patient last name empty";
                    }

                    if (string.IsNullOrEmpty(_case.hip))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Patient's HIP number empty" : _case.validationMessages + ", patient HIP number empty";
                    }
                    #endregion

                    #region TREATMENT DATA
                    if (string.IsNullOrEmpty(_case.treatmentDate))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment date empty" : _case.validationMessages + ", treatment date empty";
                    }

                    if (string.IsNullOrEmpty(_case.drugName))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Drug name empty" : _case.validationMessages + ", drug name empty";
                    }

                    if (string.IsNullOrEmpty(_case.icd10))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Diagnose code empty" : _case.validationMessages + ", diagnose code empty";
                    }

                    if (string.IsNullOrEmpty(_case.localization))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Localization empty" : _case.validationMessages + ", localization empty";
                    }

                    if (string.IsNullOrEmpty(_case.opDocFirstName))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "OP doctor's first name empty" : _case.validationMessages + ", OP doctor's first name empty";
                    }

                    if (string.IsNullOrEmpty(_case.opDocLastName))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "OP doctor's last name empty" : _case.validationMessages + ", OP doctor's last name empty";
                    }

                    if (string.IsNullOrEmpty(_case.opDocLANR))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "OP doctor's LANR empty" : _case.validationMessages + ", OP doctor's LANR empty";
                    }

                    if (string.IsNullOrEmpty(_case.treatmentPractice.BSNR))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "OP practice's BSNR empty" : _case.validationMessages + ", OP practice's BSNR empty";
                    }

                    if (string.IsNullOrEmpty(_case.treatmentPractice.Name))
                    {
                        _case.isValid = false;
                        _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "OP practice's name empty" : _case.validationMessages + ", OP practice's name empty";
                    }
                    #endregion

                    #region OP8
                    if (!string.IsNullOrEmpty(_case.op8))
                    {
                        if (string.IsNullOrEmpty(_case.op6))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but wasn't in status OP6 before (Confirmed by HIP)" : _case.validationMessages + ", treatment in status OP8 (Payment in progress), but wasn't in status OP6 before (Confirmed by HIP)";
                        }

                        if (string.IsNullOrEmpty(_case.opFSStatuses.fs4))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but wasn't in status FS4 before (Confirmed by HIP)" : _case.validationMessages + ", treatment in status OP8 (Payment in progress), but wasn't in status FS4 before (Confirmed by HIP)";
                        }

                        if (string.IsNullOrEmpty(_case.localization))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but localization empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but localization empty";
                        }
                        else
                        {
                            if (_case.localization != "L" && _case.localization != "R")
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but localization different from L/R" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but localization different from L/R";
                            }
                        }

                        if (string.IsNullOrEmpty(_case.icd10))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but diagnose icd-10 code empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but diagnose icd-10 code empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but OP doctor's first name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but OP doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but OP doctor's last name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but OP doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but OP doctor's LANR empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but OP doctor's LANR empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but AC doctor's first name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but AC doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but AC doctor's last name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but AC doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but AC doctor's LANR empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but AC doctor's LANR empty";
                        }
                    }
                    #endregion

                    #region AC9
                    if (!string.IsNullOrEmpty(_case.ac9))
                    {
                        if (string.IsNullOrEmpty(_case.ac7))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare in status AC9 (Payment in progress), but wasn't in status AC7 before (Confirmed by HIP)" : _case.validationMessages + ", aftercare in status AC9 (Payment in progress), but wasn't in status AC7 before (Confirmed by HIP)";
                        }

                        if (string.IsNullOrEmpty(_case.acFSStatuses.fs4))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare in status AC9 (Payment in progress), but wasn't in status FS4 before (Confirmed by HIP)" : _case.validationMessages + ", aftercare in status AC9 (Payment in progress), but wasn't in status FS4 before (Confirmed by HIP)";
                        }

                        if (string.IsNullOrEmpty(_case.localization))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but localization empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but localization empty";
                        }
                        else
                        {
                            if (_case.localization != "L" && _case.localization != "R")
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but localization different from L/R" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but localization different from L/R";
                            }
                        }

                        if (string.IsNullOrEmpty(_case.icd10))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but diagnose icd-10 code empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but diagnose icd-10 code empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but OP doctor's first name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but OP doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but OP doctor's last name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but OP doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but OP doctor's LANR empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but OP doctor's LANR empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but AC doctor's first name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but AC doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but AC doctor's last name empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but AC doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Treatment in status OP8 (Payment in progress), but AC doctor's LANR empty" : _case.validationMessages + ", Treatment in status OP8 (Payment in progress), but AC doctor's LANR empty";
                        }
                    }
                    #endregion

                    #region FS1
                    if (!string.IsNullOrEmpty(_case.opFSStatuses.fs1))
                    {
                        if (string.IsNullOrEmpty(_case.drugName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but drug name empty" : _case.validationMessages + ", case submitted to MM (FS1), but drug name empty";
                        }

                        if (string.IsNullOrEmpty(_case.localization))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but localization empty" : _case.validationMessages + ", case submitted to MM (FS1), but localization empty";
                        }
                        else
                        {
                            if (_case.localization != "L" && _case.localization != "R")
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but localization different from L/R" : _case.validationMessages + ", case submitted to MM (FS1), but localization different from L/R";
                            }
                        }

                        if (string.IsNullOrEmpty(_case.icd10))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but diagnose icd-10 code empty" : _case.validationMessages + ", case submitted to MM (FS1), but diagnose icd-10 code empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but OP doctor's first name empty" : _case.validationMessages + ", case submitted to MM (FS1), but OP doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but OP doctor's last name empty" : _case.validationMessages + ", Case submitted to MM (FS1), but OP doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but OP doctor's LANR empty" : _case.validationMessages + ", Case submitted to MM (FS1), but OP doctor's LANR empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but AC doctor's first name empty" : _case.validationMessages + ", case submitted to MM (FS1), but AC doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but AC doctor's last name empty" : _case.validationMessages + ", Case submitted to MM (FS1), but AC doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to MM (FS1), but AC doctor's LANR empty" : _case.validationMessages + ", Case submitted to MM (FS1), but AC doctor's LANR empty";
                        }
                    }
                    #endregion

                    #region FS2
                    #region OP
                    if (!string.IsNullOrEmpty(_case.opFSStatuses.fs2))
                    {
                        if (string.IsNullOrEmpty(_case.opFSStatuses.fs1))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but wasn't in FS1 status previously" : _case.validationMessages + ", case submitted to HIP (FS2), but wasn't in FS1 status previously";

                            if (string.IsNullOrEmpty(_case.drugName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but drug name empty" : _case.validationMessages + ", case submitted to HIP (FS2), but drug name empty";
                            }


                            if (string.IsNullOrEmpty(_case.localization))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but localization empty" : _case.validationMessages + ", case submitted to HIP (FS2), but localization empty";
                            }
                            else
                            {
                                if (_case.localization != "L" && _case.localization != "R")
                                {
                                    _case.isValid = false;
                                    _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but localization different from L/R" : _case.validationMessages + ", case submitted to HIP (FS2), but localization different from L/R";
                                }
                            }

                            if (string.IsNullOrEmpty(_case.icd10))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but diagnose icd-10 code empty" : _case.validationMessages + ", case submitted to HIP (FS2), but diagnose icd-10 code empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocFirstName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but OP doctor's first name empty" : _case.validationMessages + ", case submitted to HIP (FS2), but OP doctor's first name empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocLastName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but OP doctor's last name empty" : _case.validationMessages + ", case submitted to HIP (FS2), but OP doctor's last name empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocLANR))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but OP doctor's LANR empty" : _case.validationMessages + ", case submitted to HIP (FS2), but OP doctor's LANR empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocFirstName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but AC doctor's first name empty" : _case.validationMessages + ", case submitted to HIP (FS2), but AC doctor's first name empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocLastName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but AC doctor's last name empty" : _case.validationMessages + ", case submitted to HIP (FS2), but AC doctor's last name empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocLANR))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case submitted to HIP (FS2), but AC doctor's LANR empty" : _case.validationMessages + ", case submitted to HIP (FS2), but AC doctor's LANR empty";
                            }
                        }
                    }
                    #endregion

                    #region AC
                    if (!string.IsNullOrEmpty(_case.acFSStatuses.fs2))
                    {
                        if (string.IsNullOrEmpty(_case.acFSStatuses.fs1))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare submitted to HIP (FS2), but wasn't in FS1 status previously" : _case.validationMessages + ", aftercare submitted to HIP (FS2), but wasn't in FS1 status previously";
                        }
                    }
                    #endregion
                    #endregion

                    #region FS4
                    if (!string.IsNullOrEmpty(_case.opFSStatuses.fs4))
                    {
                        if (string.IsNullOrEmpty(_case.opFSStatuses.fs2))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but wasn't in FS2 previously" : _case.validationMessages + ", case confirmed by HIP (FS4), but wasn't in FS2 previously";


                            if (string.IsNullOrEmpty(_case.drugName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but drug name empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but drug name empty";
                            }


                            if (string.IsNullOrEmpty(_case.localization))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but localization empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but localization empty";
                            }
                            else
                            {
                                if (_case.localization != "L" && _case.localization != "R")
                                {
                                    _case.isValid = false;
                                    _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but localization different from L/R" : _case.validationMessages + ", case confirmed by HIP (FS4), but localization different from L/R";
                                }
                            }

                            if (string.IsNullOrEmpty(_case.icd10))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but diagnose icd-10 code empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but diagnose icd-10 code empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocFirstName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but OP doctor's first name empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but OP doctor's first name empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocLastName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but OP doctor's last name empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but OP doctor's last name empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocLANR))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but OP doctor's LANR empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but OP doctor's LANR empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocFirstName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but AC doctor's first name empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but AC doctor's first name empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocLastName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but AC doctor's last name empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but AC doctor's last name empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocLANR))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case confirmed by HIP (FS4), but AC doctor's LANR empty" : _case.validationMessages + ", case confirmed by HIP (FS4), but AC doctor's LANR empty";
                            }
                        }
                    }

                    #region AC
                    if (!string.IsNullOrEmpty(_case.acFSStatuses.fs4))
                    {
                        if (string.IsNullOrEmpty(_case.acFSStatuses.fs2))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare confirmed by HIP (FS4), but wasn't in FS2 previously" : _case.validationMessages + ", aftercare confirmed by HIP (FS4), but wasn't in FS2 previously";
                        }
                    }
                    #endregion
                    #endregion

                    #region FS5
                    if (!string.IsNullOrEmpty(_case.opFSStatuses.fs5))
                    {
                        if (string.IsNullOrEmpty(_case.opFSStatuses.fs2))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but wasn't in FS2 previously" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but wasn't in FS2 previously";
                        }

                        if (string.IsNullOrEmpty(_case.drugName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but drug name empty" : _case.validationMessages + ", Case in FS5 status (Error feedback from HIP), but drug name empty";
                        }


                        if (string.IsNullOrEmpty(_case.localization))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but localization empty" : _case.validationMessages + ", Case in FS5 status (Error feedback from HIP), but localization empty";
                        }
                        else
                        {
                            if (_case.localization != "L" && _case.localization != "R")
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but localization different from L/R" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but localization different from L/R";
                            }
                        }

                        if (string.IsNullOrEmpty(_case.icd10))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but diagnose icd-10 code empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but diagnose icd-10 code empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but OP doctor's first name empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but OP doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but OP doctor's last name empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but OP doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.opDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but OP doctor's LANR empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but OP doctor's LANR empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocFirstName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but AC doctor's first name empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but AC doctor's first name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLastName))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but AC doctor's last name empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but AC doctor's last name empty";
                        }

                        if (string.IsNullOrEmpty(_case.acDocLANR))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case in FS5 status (Error feedback from HIP), but AC doctor's LANR empty" : _case.validationMessages + ", case in FS5 status (Error feedback from HIP), but AC doctor's LANR empty";
                        }
                    }

                    if (!string.IsNullOrEmpty(_case.acFSStatuses.fs5))
                    {
                        if (string.IsNullOrEmpty(_case.acFSStatuses.fs2))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare in FS5 status (Error feedback from HIP), but wasn't in FS2 previously" : _case.validationMessages + ", aftercare in FS5 status (Error feedback from HIP), but wasn't in FS2 previously";
                        }
                    }
                    #endregion

                    #region FS7
                    if (!string.IsNullOrEmpty(_case.opFSStatuses.fs7))
                    {
                        if (string.IsNullOrEmpty(_case.opFSStatuses.fs4))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but wasn't in FS4 previously" : _case.validationMessages + ", case paid (FS7), but wasn't in FS4 previously";


                            if (string.IsNullOrEmpty(_case.drugName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but drug name empty" : _case.validationMessages + ", case paid (FS7), but drug name empty";
                            }


                            if (string.IsNullOrEmpty(_case.localization))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but localization empty" : _case.validationMessages + ", case paid (FS7), but localization empty";
                            }
                            else
                            {
                                if (_case.localization != "L" && _case.localization != "R")
                                {
                                    _case.isValid = false;
                                    _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but localization different from L/R" : _case.validationMessages + ", case paid (FS7), but localization different from L/R";
                                }
                            }

                            if (string.IsNullOrEmpty(_case.icd10))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but diagnose icd-10 code empty" : _case.validationMessages + ", case paid (FS7), but diagnose icd-10 code empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocFirstName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but OP doctor's first name empty" : _case.validationMessages + ", case paid (FS7), but OP doctor's first name empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocLastName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but OP doctor's last name empty" : _case.validationMessages + ", case paid (FS7), but OP doctor's last name empty";
                            }

                            if (string.IsNullOrEmpty(_case.opDocLANR))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but OP doctor's LANR empty" : _case.validationMessages + ", case paid (FS7), but OP doctor's LANR empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocFirstName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but AC doctor's first name empty" : _case.validationMessages + ", case paid (FS7), but AC doctor's first name empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocLastName))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but AC doctor's last name empty" : _case.validationMessages + ", case paid (FS7), but AC doctor's last name empty";
                            }

                            if (string.IsNullOrEmpty(_case.acDocLANR))
                            {
                                _case.isValid = false;
                                _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Case paid (FS7), but AC doctor's LANR empty" : _case.validationMessages + ", case paid (FS7), but AC doctor's LANR empty";
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(_case.acFSStatuses.fs7))
                    {
                        if (string.IsNullOrEmpty(_case.acFSStatuses.fs4))
                        {
                            _case.isValid = false;
                            _case.validationMessages = string.IsNullOrEmpty(_case.validationMessages) ? "Aftercare paid (FS7), but wasn't in FS4 previously" : _case.validationMessages + ", aftercare paid (FS7), but wasn't in FS4 previously";
                        }
                    }
                    #endregion

                    cases.Add(_case);
                    Console.Write("\rCase {0} of {1} validated.", i++, excelData.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.Write(ex.StackTrace);
            }


            string file = ExportCasesBeforeUpload.ExportCasesBeforeUploadToDB(cases);
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));
            Console.WriteLine("----- XLS created.");

            if (cases.Any(vl => !vl.isValid))
            {
                Console.WriteLine("Data not valid, won't be saved.");
            }
            else
            {
                Console.WriteLine("Deleting cases from elastic...");
                Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "case");

                Console.WriteLine("Deleting aftercares from elastic...");
                Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "aftercare");

                Console.WriteLine("Deleting submitted cases from elastic...");
                Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "submitted_case");

                DbConnection Connection = null;
                DbTransaction Transaction = null;

                #region IMPORT CASES
                bool cleanupConnection = Connection == null;
                bool cleanupTransaction = Transaction == null;

                try
                {
                    if (cleanupConnection == true)
                    {
                        Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
                        Connection.Open();
                    }
                    if (cleanupTransaction == true)
                    {
                        Transaction = Connection.BeginTransaction();
                    }

                    int ii = 1;

                    foreach (var _case in cases)
                    {
                        var aftercare_doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false, DoctorIDNumber = _case.acDocLANR }).SingleOrDefault();
                        var treatment_doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false, DoctorIDNumber = _case.opDocLANR }).SingleOrDefault();
                        var diagnose = ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query.Search(Connection, Transaction, new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false, Code = _case.icd10 }).SingleOrDefault();
                        var treatment_practice = cls_Get_PracticeID_for_BSNR.Invoke(Connection, Transaction, new P_DO_GPIDfBSNR_1011() { BSNR = _case.treatmentPractice.BSNR }, securityTicket).Result;
                        var aftercare_practice = cls_Get_PracticeID_for_BSNR.Invoke(Connection, Transaction, new P_DO_GPIDfBSNR_1011() { BSNR = _case.aftercarePractice.BSNR }, securityTicket).Result;
                        var drug = cls_Get_DrugID_for_DrugName_and_PZN.Invoke(Connection, Transaction, new P_DO_GDIDfDNaPZN_1027()
                        {
                            DrugName = !_case.drugName.Contains("Lucentis") ? _case.drugName + "%" : _case.pzn == "67760" ? _case.drugName + " DFL%" : _case.drugName + " FSP%"
                        }, securityTicket).Result;

                        var patient = cls_Get_PatientID_for_HIP_and_PracticeID.Invoke(Connection, Transaction, new P_PA_GPIDfHIPaPID_1402() { HIP = _case.hip, PracticeID = treatment_practice.practice_id }, securityTicket).Result;
                        if (patient == null)
                        {
                            patient = cls_Get_PatientID_for_HIP_and_PracticeID.Invoke(Connection, Transaction, new P_PA_GPIDfHIPaPID_1402() { HIP = _case.hip, PracticeID = aftercare_practice.practice_id }, securityTicket).Result;
                        }
                        var case_from_db = cls_Get_CaseID_for_TreatmentDate_And_HIP.Invoke(Connection, Transaction, new P_CAS_GCIDfTDaHIP_1222() { HIPNumber = _case.hip, TreatmentDate = DateTime.ParseExact(_case.op1, "dd.MM.yyyy", culture), Localization = _case.localization }, securityTicket).Result;
                        if (aftercare_doctor != null && treatment_doctor != null && patient != null && diagnose != null && treatment_practice != null && aftercare_practice != null && drug != null)
                        {
                            var submitted_case_id = Guid.Empty;
                            Console.Write("\r                   ");
                            Console.Write("\r.");
                            #region CREATE NEW CASE

                            CleanupCase.SaveNewCase(Connection, Transaction, treatment_doctor.HEC_DoctorID, securityTicket, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id, _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.op1, "dd.MM.yyyy", culture), treatment_practice.practice_id);

                            #endregion
                            #region SUBMIT TREATMENT - FS1
                            if (!string.IsNullOrEmpty(_case.opFSStatuses.fs1))
                            {
                                CleanupCase.SubmitCase(Connection, Transaction, securityTicket, true, treatment_doctor.HEC_DoctorID, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id,
                                    _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.op1, "dd.MM.yyyy", culture), treatment_practice.practice_id, aftercare_practice.practice_id,
                                    DateTime.ParseExact(_case.opFSStatuses.fs1, "dd.MM.yyyy", culture));
                            }
                            #endregion

                            Console.Write(".");

                            #region SUBMIT AFTERCARE - FS1
                            if (!string.IsNullOrEmpty(_case.acFSStatuses.fs1))
                            {
                                CleanupCase.SubmitCase(Connection, Transaction, securityTicket, false, treatment_doctor.HEC_DoctorID, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id,
                                    _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.ac1, "dd.MM.yyyy", culture), treatment_practice.practice_id, aftercare_practice.practice_id,
                                    DateTime.ParseExact(_case.acFSStatuses.fs1, "dd.MM.yyyy", culture));
                            }
                            #endregion

                            Console.Write(".");

                            #region SUBMIT TREATMENT TO HIP - FS2
                            if (!string.IsNullOrEmpty(_case.opFSStatuses.fs2))
                            {
                                CleanupCase.ChangeCaseStatus(Connection, Transaction, securityTicket, true, treatment_doctor.HEC_DoctorID, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id,
                                    _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.ac1, "dd.MM.yyyy", culture), treatment_practice.practice_id, aftercare_practice.practice_id,
                                    DateTime.ParseExact(_case.opFSStatuses.fs2, "dd.MM.yyyy", culture), 2);
                            }
                            #endregion

                            Console.Write(".");

                            #region SUBMIT AFTERCARE TO HIP - FS2
                            if (!string.IsNullOrEmpty(_case.acFSStatuses.fs2))
                            {
                                CleanupCase.ChangeCaseStatus(Connection, Transaction, securityTicket, false, treatment_doctor.HEC_DoctorID, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id,
                                    _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.ac1, "dd.MM.yyyy", culture), treatment_practice.practice_id, aftercare_practice.practice_id,
                                    DateTime.ParseExact(_case.acFSStatuses.fs2, "dd.MM.yyyy", culture), 2);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET TREATMENT AS CONFIRMED - FS4
                            if (!string.IsNullOrEmpty(_case.opFSStatuses.fs4))
                            {
                                CleanupCase.ChangeCaseStatus(Connection, Transaction, securityTicket, true, treatment_doctor.HEC_DoctorID, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id,
                                    _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.ac1, "dd.MM.yyyy", culture), treatment_practice.practice_id, aftercare_practice.practice_id,
                                    DateTime.ParseExact(_case.opFSStatuses.fs4, "dd.MM.yyyy", culture), 4);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET AFTERCARE AS CONFIRMED - FS4
                            if (!string.IsNullOrEmpty(_case.acFSStatuses.fs4))
                            {
                                CleanupCase.ChangeCaseStatus(Connection, Transaction, securityTicket, false, treatment_doctor.HEC_DoctorID, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id,
                                    _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.ac1, "dd.MM.yyyy", culture), treatment_practice.practice_id, aftercare_practice.practice_id,
                                    DateTime.ParseExact(_case.acFSStatuses.fs4, "dd.MM.yyyy", culture), 4);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET TREATMENT AS ERROR - FS5
                            // TODO: Set primary comment
                            if (!string.IsNullOrEmpty(_case.opFSStatuses.fs5))
                            {
                                CleanupCase.ChangeCaseStatus(Connection, Transaction, securityTicket, true, treatment_doctor.HEC_DoctorID, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id,
                                    _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.ac1, "dd.MM.yyyy", culture), treatment_practice.practice_id, aftercare_practice.practice_id,
                                    DateTime.ParseExact(_case.opFSStatuses.fs5, "dd.MM.yyyy", culture), 5);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET AFTERCARE AS ERROR - FS5
                            // TODO: Set primary comment
                            if (!string.IsNullOrEmpty(_case.acFSStatuses.fs5))
                            {
                                CleanupCase.ChangeCaseStatus(Connection, Transaction, securityTicket, false, treatment_doctor.HEC_DoctorID, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id,
                                    _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.ac1, "dd.MM.yyyy", culture), treatment_practice.practice_id, aftercare_practice.practice_id,
                                    DateTime.ParseExact(_case.acFSStatuses.fs5, "dd.MM.yyyy", culture), 5);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET TREATMENT AS PAID - FS7
                            if (!string.IsNullOrEmpty(_case.opFSStatuses.fs7))
                            {
                                CleanupCase.ChangeCaseStatus(Connection, Transaction, securityTicket, true, treatment_doctor.HEC_DoctorID, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id,
                                    _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.ac1, "dd.MM.yyyy", culture), treatment_practice.practice_id, aftercare_practice.practice_id,
                                    DateTime.ParseExact(_case.opFSStatuses.fs7, "dd.MM.yyyy", culture), 7);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET AFTERCARE AS PAID - FS7
                            if (!string.IsNullOrEmpty(_case.acFSStatuses.fs7))
                            {
                                CleanupCase.ChangeCaseStatus(Connection, Transaction, securityTicket, false, treatment_doctor.HEC_DoctorID, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id,
                                    _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.ac1, "dd.MM.yyyy", culture), treatment_practice.practice_id, aftercare_practice.practice_id,
                                    DateTime.ParseExact(_case.acFSStatuses.fs7, "dd.MM.yyyy", culture), 7);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET TREATMENT AS CANCELLED - FS8
                            if (!string.IsNullOrEmpty(_case.opFSStatuses.fs8))
                            {
                                CleanupCase.ChangeCaseStatus(Connection, Transaction, securityTicket, true, treatment_doctor.HEC_DoctorID, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id,
                                    _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.ac1, "dd.MM.yyyy", culture), treatment_practice.practice_id, aftercare_practice.practice_id,
                                    DateTime.ParseExact(_case.opFSStatuses.fs8, "dd.MM.yyyy", culture), 8);
                            }
                            #endregion

                            Console.Write(".");

                            #region SET AFTERCARE AS CANCELLED - FS8
                            if (!string.IsNullOrEmpty(_case.acFSStatuses.fs8))
                            {
                                CleanupCase.ChangeCaseStatus(Connection, Transaction, securityTicket, false, treatment_doctor.HEC_DoctorID, patient.patient_id, diagnose.PotentialDiagnosis_RefID, drug.drug_id, case_from_db.case_id,
                                    _case.localization, aftercare_doctor.HEC_DoctorID, DateTime.ParseExact(_case.ac1, "dd.MM.yyyy", culture), treatment_practice.practice_id, aftercare_practice.practice_id,
                                    DateTime.ParseExact(_case.acFSStatuses.fs8, "dd.MM.yyyy", culture), 8);
                            }
                            #endregion

                            Console.Write(".");
                            Console.WriteLine("\rCase {0} of {1} imported to elastic.", ii++, cases.Count);

                        }
                        else
                        {
                            string message = "";

                            message = patient == null ? message + " Patient not found: " + _case.patientFirstName + " " + _case.patientLastName + ", hip number: " + _case.hip : "";
                            message = aftercare_doctor == null ? message + " Aftercare doctor not found:" + _case.acDocFirstName + " " + _case.acDocLastName + ", LANR: " + _case.acDocLANR : "";
                            message = treatment_doctor == null ? message + " Treatment doctor not found: " + _case.opDocFirstName + " " + _case.opDocLastName + ", LANR: " + _case.opDocLANR : "";
                            message = diagnose == null ? message + " Diagnose not found, icd-10: " + _case.icd10 : "";
                            message = aftercare_practice == null ? message + " Aftercare practice not found: " + _case.aftercarePractice.Name + ", bsnr: " + _case.aftercarePractice.BSNR : "";
                            message = treatment_practice == null ? message + " Treatment practice not found: " + _case.treatmentPractice.Name + ", bsnr: " + _case.treatmentPractice.BSNR : "";
                            message = drug == null ? message + "Drug not found: " + _case.drugName + ", pzn: " + _case.pzn : "";

                            throw new Exception(message + string.Format("Case {0} of {1} not imported. Rolling back operation.", ii, cases.Count));
                        }
                    }

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
                    Console.Clear();
                    Console.Write("Something went wrong: " + ex.Message + "\nStack trace:\n");
                    Console.WriteLine(ex.StackTrace);

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

                    throw new Exception("Exception occured in method cls_Save_Case", ex);
                }
                #endregion

                Console.WriteLine("\n");
            }
        }
    }
}
