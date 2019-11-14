using CL1_BIL;
using CL1_CMN;
using CL1_CMN_CTR;
using CL1_HEC;
using CL1_HEC_ACT;
using CL1_HEC_BIL;
using CL1_HEC_CAS;
using CL1_HEC_CRT;
using CL1_HEC_CTR;
using CL1_HEC_DIA;
using CL1_USR;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Case.Atomic.Manipulation;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using DataImporter.DBMethods.Case.Complex.Retrieval;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.DBMethods.Patient.Atomic.Retrieval;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace DataImporter.Methods.Help_Methods
{
    public static class FixDoctorsTable
    {
        public static void FixOldCasesAftercarePerformedDate(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }

                var gposAssignmentsCountCache = cls_Get_Number_of_GposTypes_on_Case_for_CaseID_and_GposType.Invoke(Connection, Transaction, new P_CAS_GNoGPOSToCfCIDaGPOST_1023()
                {
                    GposType = "mm.docconnect.gpos.catalog.operation"
                }, securityTicket).Result.Where(t => t.NumberOfTreatmentGposes > 1).GroupBy(t => t.CaseID).Select(t => t.Key);

                var treatmentCache = cls_Get_Cases_Treatment_Dates_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.Single().TreatmentPlannedActionDate);

                var cases = cls_Get_Cases_Aftercare_PlannedActionIDs_and_Dates_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.Where(t => gposAssignmentsCountCache.Any(g => g == t.CaseID) && treatmentCache[t.CaseID] == t.PlannedActionDate);
                Console.WriteLine("Found cases: " + cases.Count());
                Console.WriteLine("Print case numbers? [y/n]");
                if (Console.ReadLine().ToLower() == "y")
                {

                    foreach (var cas in cases)
                    {
                        Console.WriteLine(cas.CaseNumber);
                    }
                }

                Console.WriteLine("Continue? [y/n]");
                if (Console.ReadLine().ToLower() == "y")
                {
                    var i = 1;
                    foreach (var cas in cases)
                    {
                        var performedAction = ORM_HEC_ACT_PerformedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            HEC_ACT_PerformedActionID = cas.PerformedActionID
                        }).SingleOrDefault();

                        if (performedAction == null)
                        {
                            Console.WriteLine("Case " + cas.CaseNumber + " not fixed. Performed action not found for id: " + cas.PerformedActionID);
                            Console.WriteLine("Continue with command execution? [y/n]");
                            if (Console.ReadLine().ToLower() != "y")
                            {
                                break;
                            }
                        }
                        else
                        {
                            performedAction.IfPerfomed_DateOfAction = cas.PlannedActionDate;
                            performedAction.IfPerformed_DateOfAction_Day = cas.PlannedActionDate.Day;
                            performedAction.IfPerformed_DateOfAction_Month = cas.PlannedActionDate.Month;
                            performedAction.IfPerformed_DateOfAction_Year = cas.PlannedActionDate.Year;
                            performedAction.Modification_Timestamp = DateTime.Now;

                            performedAction.Save(Connection, Transaction);
                        }

                        Console.WriteLine("Case " + i++ + "/" + cases.Count() + " updated.");
                    }
                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static bool FixMissingAftercareGPOSesOnNewContract(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }
                var aftercareGposType = "mm.docconnect.gpos.catalog.nachsorge";
                var caseNumber = 10000;
                Console.WriteLine("Enter case number from which to update aftercare GPOS-es: ");
                caseNumber = Int32.Parse(Console.ReadLine());
                var cases = cls_Get_Cases_from_CaseNumber_Onward.Invoke(Connection, Transaction, new P_CAS_GCfCNO_1021() { CaseNumber = caseNumber }, securityTicket).Result;


                var temp = cls_Get_Cases_with_GposTypes_for_CaseIDs.Invoke(Connection, Transaction, new P_CAS_GCwGTfCIDs_1026() { CaseIDs = cases.Select(t => t.CaseID).ToArray() }, securityTicket).Result
                    .GroupBy(t => t.CaseID);
                var casesThatNeedToBeFixed = cls_Get_Cases_with_GposTypes_for_CaseIDs.Invoke(Connection, Transaction, new P_CAS_GCwGTfCIDs_1026() { CaseIDs = cases.Select(t => t.CaseID).ToArray() }, securityTicket).Result
                    .GroupBy(t => t.CaseID);

                var iviCtr = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query()
                {
                    ContractName = "IVI-Vertrag",
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                var insuranceToBrokerCtrIDToOmit = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                {
                    Ext_CMN_CTR_Contract_RefID = iviCtr.CMN_CTR_ContractID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single().HEC_CRT_InsuranceToBrokerContractID;

                var insuranceToBrokerContractIDs = cls_Get_InsuranceToBrokerContractIDs_on_Tenant.Invoke(Connection, Transaction, new P_PA_GITBCIDsoT_1238() { PatientIDs = cases.Select(t => t.PatientID).ToArray() }, securityTicket).Result.Where(t => t.InsuranceToBrokerContractID != insuranceToBrokerCtrIDToOmit).GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.First().InsuranceToBrokerContractID);
                var gposDrugCache = ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).GroupBy(t => t.HEC_BIL_PotentialCode_RefID).ToDictionary(t => t.Key, t => t);

                var gposCache = cls_Get_Case_GposIDs_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t);

                var anyCaseUpdated = false;

                var gposToConsider = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    BillingCode = "73000001"
                }).Single();

                foreach (var cas in cases)
                {
                    try
                    {
                        if (!gposCache.ContainsKey(cas.CaseID) || !gposCache[cas.CaseID].Any(t => t.GposID == gposToConsider.HEC_BIL_PotentialCodeID))
                            continue;

                        var acPlannedAction = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = cas.CaseID }, securityTicket).Result.planned_action_id;
                        var plannedAction = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            HEC_ACT_PlannedActionID = acPlannedAction
                        }).Single();

                        var gposes = cls_Get_GPOS_Details_for_InsuranceToBrokerContractID.Invoke(Connection, Transaction, new P_CAS_GGPOSDfITBCID_1245() { InsuranceToBrokerContractID = insuranceToBrokerContractIDs[cas.PatientID] }, securityTicket).Result.Where(t => t.GposType == aftercareGposType);
                        var drugID = cls_Get_DrugID_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GDIDfCID_1248() { CaseID = cas.CaseID }, securityTicket).Result.DrugID;

                        var caseHeaderID = cls_Get_BillHeaderID_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBHIDfCID_1311() { CaseID = cas.CaseID }, securityTicket).Result;

                        var caseHeader = ORM_BIL_BillHeader.Query.Search(Connection, Transaction, new ORM_BIL_BillHeader.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            BIL_BillHeaderID = caseHeaderID == null ? Guid.Empty : caseHeaderID.header_id
                        }).SingleOrDefault();

                        var aftercarePerformed = plannedAction.IsPerformed && caseHeader != null;

                        foreach (var gpos in gposes)
                        {
                            if (gposCache[cas.CaseID].Any(t => t.GposID == gpos.GposID))
                                continue;

                            if (gposDrugCache.Any(t => t.Value.Any(d => d.HEC_Product_RefID == drugID)))
                            {
                                if (gposDrugCache.ContainsKey(gpos.GposID) && !gposDrugCache[gpos.GposID].Any(t => t.HEC_Product_RefID == drugID))
                                    continue;
                            }

                            Console.WriteLine("Case " + cas.CaseNumber + " will have aftercare bill position updated. Continue? [y/n]");
                            if (Console.ReadLine().ToLower() == "y")
                            {
                                anyCaseUpdated = true;

                                ORM_BIL_BillPosition gpos_position = new ORM_BIL_BillPosition();
                                gpos_position.BIL_BilHeader_RefID = aftercarePerformed ? caseHeader.BIL_BillHeaderID : Guid.Empty;
                                gpos_position.Tenant_RefID = securityTicket.TenantID;
                                gpos_position.PositionValue_IncludingTax = Convert.ToDecimal(gpos.GposPrice);

                                gpos_position.Save(Connection, Transaction);

                                ORM_HEC_BIL_BillPosition hec_gpos_position = new ORM_HEC_BIL_BillPosition();
                                hec_gpos_position.Ext_BIL_BillPosition_RefID = gpos_position.BIL_BillPositionID;
                                hec_gpos_position.Tenant_RefID = securityTicket.TenantID;
                                hec_gpos_position.PositionFor_Patient_RefID = cas.PatientID;

                                hec_gpos_position.Save(Connection, Transaction);

                                ORM_HEC_BIL_BillPosition_BillCode hec_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                                hec_gpos_position_code.BillPosition_RefID = hec_gpos_position.HEC_BIL_BillPositionID;
                                hec_gpos_position_code.IM_BillingCode = gpos.GposCode;
                                hec_gpos_position_code.PotentialCode_RefID = gpos.GposID;
                                hec_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                                hec_gpos_position_code.Save(Connection, Transaction);

                                ORM_HEC_CAS_Case_BillCode hec_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                                hec_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                                hec_gpos_case_code.HEC_CAS_Case_RefID = cas.CaseID;
                                hec_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                                hec_gpos_case_code.Save(Connection, Transaction);

                                if (aftercarePerformed)
                                {
                                    var performedAction = ORM_HEC_ACT_PerformedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction.Query()
                                    {
                                        Tenant_RefID = securityTicket.TenantID,
                                        IsDeleted = false,
                                        HEC_ACT_PerformedActionID = plannedAction.IfPerformed_PerformedAction_RefID
                                    }).Single();

                                    var fsStatus = new ORM_BIL_BillPosition_TransmitionStatus();
                                    fsStatus.BillPosition_RefID = gpos_position.BIL_BillPositionID;
                                    fsStatus.IsActive = true;
                                    fsStatus.Tenant_RefID = securityTicket.TenantID;
                                    fsStatus.TransmitionCode = 1;
                                    fsStatus.TransmittedOnDate = performedAction.IfPerfomed_DateOfAction;
                                    fsStatus.TransmitionStatusKey = "aftercare";

                                    fsStatus.Save(Connection, Transaction);

                                    caseHeader.TotalValue_IncludingTax += gpos_position.PositionValue_IncludingTax;
                                }
                            }

                            if (aftercarePerformed)
                                caseHeader.Save(Connection, Transaction);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception occured for case: " + cas.CaseNumber + "; stack trace" + ex.StackTrace);

                        Console.WriteLine();
                        Console.WriteLine("Continue? [y/n]");
                        if (Console.ReadLine().ToLower() != "y")
                        {
                            break;
                        };
                    }
                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion

                return anyCaseUpdated;
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixDoubleCasesInTheReport(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }

                List<CAS_GCABPD_1150> casesThatNeedFixing = new List<CAS_GCABPD_1150>();
                var cases = cls_Get_Cases_and_BillPositionData.Invoke(Connection, Transaction, securityTicket).Result.Where(t => !t.IsBillCodeDeleted && (t.FsStatusType == null || (t.FsStatusCode != 8 && t.FsStatusCode != 17))).GroupBy(t => t.CaseID).Select(t => new { Key = t.Key, Values = t }).ToDictionary(t => t.Key, t => t.Values);
                foreach (var errorCase in cases)
                {
                    var group = errorCase.Value.GroupBy(t => t.GposType).Select(t => new { key = t.Key, values = t }).ToDictionary(t => t.key, t => t.values);
                    foreach (var data in group)
                    {
                        if (data.Value.Any(t => t.FsStatusType == null) && data.Value.Any(t => t.FsStatusType != null))
                        {
                            casesThatNeedFixing.AddRange(data.Value.Where(t => t.FsStatusType == null));
                        }
                    }

                }

                var debug = casesThatNeedFixing.GroupBy(t => t.CaseNumber).Select(t => new { key = t.Key, values = t.ToList() }).ToDictionary(t => t.key, t => t.values);

                if (casesThatNeedFixing.Any())
                {
                    Console.WriteLine("Cases found: " + casesThatNeedFixing.Count);
                    foreach (var cas in casesThatNeedFixing.GroupBy(t => t.CaseNumber))
                    {
                        Console.WriteLine(cas.Key);
                    }

                    Console.WriteLine("Continue? [y/n]");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        foreach (var cas in casesThatNeedFixing)
                        {
                            var case_billcode = ORM_HEC_CAS_Case_BillCode.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_BillCode.Query() { HEC_CAS_Case_BillCodeID = cas.HEC_CAS_Case_BillCodeID, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (case_billcode != null)
                            {
                                case_billcode.IsDeleted = true;
                                case_billcode.Modification_Timestamp = DateTime.Now;

                                case_billcode.Save(Connection, Transaction);
                            }

                            var hec_billposition_billcode = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_BillPosition_BillCode.Query() { HEC_BIL_BillPosition_BillCodeID = cas.HEC_BIL_BillPosition_BillCodeID, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (hec_billposition_billcode != null)
                            {
                                hec_billposition_billcode.IsDeleted = true;
                                hec_billposition_billcode.Modification_Timestamp = DateTime.Now;

                                hec_billposition_billcode.Save(Connection, Transaction);
                            }

                            var hec_billpositon = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, new ORM_HEC_BIL_BillPosition.Query() { HEC_BIL_BillPositionID = cas.HEC_BIL_BillPositionID, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (hec_billpositon != null)
                            {
                                hec_billpositon.IsDeleted = true;
                                hec_billpositon.Modification_Timestamp = DateTime.Now;

                                hec_billpositon.Save(Connection, Transaction);
                            }

                            var billposition = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition.Query() { BIL_BillPositionID = cas.Ext_BIL_BillPosition_RefID, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (billposition != null)
                            {
                                billposition.IsDeleted = true;
                                billposition.Modification_Timestamp = DateTime.Now;

                                billposition.Save(Connection, Transaction);
                            }
                        }
                    }
                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixMultipleAftercaresWithFSstatus(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }
                var aftercareGposType = "mm.docconnect.gpos.catalog.nachsorge";
                List<CAS_GCABPD_1150> casesThatNeedFixing = new List<CAS_GCABPD_1150>();
                var cases = cls_Get_Cases_and_BillPositionData.Invoke(Connection, Transaction, securityTicket).Result.Where(t => !t.IsBillCodeDeleted).GroupBy(t => t.CaseID).Select(t => new { Key = t.Key, Values = t }).ToDictionary(t => t.Key, t => t.Values);
                foreach (var errorCase in cases)
                {
                    if (errorCase.Value.Count(t => t.GposType == aftercareGposType) > 1)
                    {
                        casesThatNeedFixing.AddRange(errorCase.Value.Where(t => t.GposType == aftercareGposType));
                    }
                }

                if (casesThatNeedFixing.Any())
                {
                    var drugDiagnoseComboCache = cls_Get_Case_Drug_Diagnose_Combo_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.CaseID).Select(t => new { key = t.Key, val = t }).ToDictionary(t => t.key, t => t.val);

                    var gposDrugCache = ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });

                    var gposDiagnoseCache = ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });
                    List<string> casesNotFixable = new List<string>();
                    var toFix = casesThatNeedFixing.Select(t =>
                    {
                        if (drugDiagnoseComboCache.ContainsKey(t.CaseID))
                        {
                            var gposDiag = gposDiagnoseCache.Where(g => g.HEC_DIA_PotentialDiagnosis_RefID == drugDiagnoseComboCache[t.CaseID].First().DiagnoseID);
                            if (!gposDiag.Any(g => g.HEC_BIL_PotentialCode_RefID == t.GposID))
                            {
                                return t;
                            }

                            var gposDrug = gposDrugCache.Where(g => g.HEC_Product_RefID == drugDiagnoseComboCache[t.CaseID].First().DrugID);
                            if (!gposDrug.Any(g => g.HEC_BIL_PotentialCode_RefID == t.GposID))
                            {
                                return t;
                            }
                        }
                        else
                        {
                            casesNotFixable.Add(t.CaseNumber);
                        }

                        return null;
                    }).Where(t => t != null).ToList();

                    if (casesNotFixable.Any())
                    {
                        Console.WriteLine("Unfixable cases: ");
                        foreach (var c in casesNotFixable)
                            Console.WriteLine(c);
                    }

                    Console.WriteLine("Cases found: " + toFix.Count);
                    foreach (var cas in toFix.GroupBy(t => t.CaseNumber))
                    {
                        Console.WriteLine(cas.Key);
                    }

                    Console.WriteLine("Continue? [y/n]");
                    if (Console.ReadLine().ToLower() == "y")
                    {

                        foreach (var cas in toFix)
                        {
                            var case_billcode = ORM_HEC_CAS_Case_BillCode.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_BillCode.Query() { HEC_CAS_Case_BillCodeID = cas.HEC_CAS_Case_BillCodeID, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (case_billcode != null)
                            {
                                case_billcode.IsDeleted = true;
                                case_billcode.Modification_Timestamp = DateTime.Now;

                                case_billcode.Save(Connection, Transaction);
                            }

                            var hec_billposition_billcode = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_BillPosition_BillCode.Query() { HEC_BIL_BillPosition_BillCodeID = cas.HEC_BIL_BillPosition_BillCodeID, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (hec_billposition_billcode != null)
                            {
                                hec_billposition_billcode.IsDeleted = true;
                                hec_billposition_billcode.Modification_Timestamp = DateTime.Now;

                                hec_billposition_billcode.Save(Connection, Transaction);
                            }

                            var hec_billpositon = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, new ORM_HEC_BIL_BillPosition.Query() { HEC_BIL_BillPositionID = cas.HEC_BIL_BillPositionID, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (hec_billpositon != null)
                            {
                                hec_billpositon.IsDeleted = true;
                                hec_billpositon.Modification_Timestamp = DateTime.Now;

                                hec_billpositon.Save(Connection, Transaction);
                            }

                            var billposition = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition.Query() { BIL_BillPositionID = cas.Ext_BIL_BillPosition_RefID, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (billposition != null)
                            {
                                billposition.IsDeleted = true;
                                billposition.Modification_Timestamp = DateTime.Now;

                                billposition.Save(Connection, Transaction);
                            }
                        }
                    }
                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixWrongFSStatusDeletion(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }

                var cases = cls_Get_CaseIDs_Where_Wrong_Aftercare_FS_Status_Deleted.Invoke(Connection, Transaction, securityTicket).Result;
                if (cases.Any())
                {
                    Console.WriteLine("Found cases: " + cases.Count());
                    foreach (var cas in cases)
                    {
                        Console.WriteLine(cas.CaseNumber);
                    }
                    Console.WriteLine("Continue? [y/n]");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        foreach (var cas in cases.Take(4))
                        {
                            Console.Clear();
                            Console.WriteLine("Processing case: " + cas.CaseNumber);

                            var fsStatuses = cls_Get_FS_Statuses_For_Wrong_Aftercares_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GFSSfWAfCID_1732() { CaseID = cas.CaseID }, securityTicket).Result;
                            if (fsStatuses.Any())
                            {
                                Console.WriteLine("Found bill position statuses: " + fsStatuses.Count());
                                foreach (var fs in fsStatuses)
                                {
                                    var status = fs.IsActive ? "active" : "inactive";
                                    var comment = fs.StatusComment ?? "-";

                                    Console.WriteLine("FS STATUS - status: " + status + "; code: " + fs.StatusCode + "; date: " + fs.StatusDate.ToString("dd.MM.yyyy") + "; comment:" + comment + "; Position number: " + fs.PositionNumber);
                                }

                                Console.WriteLine("Replace current aftercare statuses with these? [y/n]");
                                if (Console.ReadLine().ToLower() == "y")
                                {
                                    foreach (var fs in fsStatuses)
                                    {
                                        var status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                                        {
                                            BIL_BillPosition_TransmitionStatusID = fs.StatusID,
                                            Tenant_RefID = securityTicket.TenantID
                                        }).Single();

                                        status.BillPosition_RefID = cas.BillPositionID;
                                        status.Modification_Timestamp = DateTime.Now;

                                        status.Save(Connection, Transaction);
                                    }

                                    var oldStatus = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                                    {
                                        BIL_BillPosition_TransmitionStatusID = cas.StatusID,
                                        Tenant_RefID = securityTicket.TenantID
                                    }).Single();
                                    oldStatus.IsDeleted = true;
                                    oldStatus.Modification_Timestamp = DateTime.Now;

                                    oldStatus.Save(Connection, Transaction);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixMissingBillPositionsOnOpenAftercares(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }
                var aftercareGposType = "mm.docconnect.gpos.catalog.nachsorge";
                List<CAS_GCABPD_1150> casesThatNeedFixing = new List<CAS_GCABPD_1150>();
                var cases = cls_Get_Cases_and_BillPositionData.Invoke(Connection, Transaction, securityTicket).Result.Where(t => Convert.ToInt32(t.CaseNumber) >= 10000).GroupBy(t => t.CaseID).Select(t => new { Key = t.Key, Values = t }).ToDictionary(t => t.Key, t => t.Values);
                foreach (var errorCase in cases)
                {
                    if (!errorCase.Value.Any(t => t.GposType == aftercareGposType && !t.IsBillCodeDeleted))
                    {
                        var ac = errorCase.Value.Where(t => t.GposType == aftercareGposType).FirstOrDefault();
                        if (ac != null)
                            casesThatNeedFixing.Add(ac);
                    }
                }

                if (casesThatNeedFixing.Any())
                {
                    Console.WriteLine("Cases found: " + casesThatNeedFixing.Count);
                    foreach (var cas in casesThatNeedFixing)
                    {
                        Console.WriteLine(cas.CaseNumber);
                    }

                    Console.WriteLine("Continue? [y/n]");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        foreach (var cas in casesThatNeedFixing)
                        {
                            var case_billcode = ORM_HEC_CAS_Case_BillCode.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_BillCode.Query() { HEC_CAS_Case_BillCodeID = cas.HEC_CAS_Case_BillCodeID, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (case_billcode != null)
                            {
                                case_billcode.IsDeleted = false;
                                case_billcode.Modification_Timestamp = DateTime.Now;

                                case_billcode.Save(Connection, Transaction);
                            }

                            var hec_billposition_billcode = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_BillPosition_BillCode.Query() { HEC_BIL_BillPosition_BillCodeID = cas.HEC_BIL_BillPosition_BillCodeID, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (hec_billposition_billcode != null)
                            {
                                hec_billposition_billcode.IsDeleted = false;
                                hec_billposition_billcode.Modification_Timestamp = DateTime.Now;

                                hec_billposition_billcode.Save(Connection, Transaction);
                            }

                            var hec_billpositon = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, new ORM_HEC_BIL_BillPosition.Query() { HEC_BIL_BillPositionID = cas.HEC_BIL_BillPositionID, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (hec_billpositon != null)
                            {
                                hec_billpositon.IsDeleted = false;
                                hec_billpositon.Modification_Timestamp = DateTime.Now;

                                hec_billpositon.Save(Connection, Transaction);
                            }

                            var billposition = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition.Query() { BIL_BillPositionID = cas.Ext_BIL_BillPosition_RefID, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (billposition != null)
                            {
                                billposition.IsDeleted = false;
                                billposition.Modification_Timestamp = DateTime.Now;

                                billposition.Save(Connection, Transaction);
                            }
                        }
                    }
                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void UpdateBillPositionNumbers(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }
                var billPositionsCache = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                var billPositions = cls_Get_Bill_Positions_without_Bill_Number.Invoke(Connection, Transaction, securityTicket).Result;
                foreach (var bp in billPositions)
                {
                    var billPosition = billPositionsCache.Where(t => t.BIL_BillPositionID == bp.BillPositionID).SingleOrDefault();
                    if (billPosition != null)
                    {
                        billPosition.PositionNumber = cls_Get_Next_Bill_Position_Number.Invoke(Connection, Transaction, securityTicket).Result.bill_position_number;
                        billPosition.Modification_Timestamp = DateTime.Now;

                        billPosition.Save(Connection, Transaction);
                    }
                }


                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixMissingGposes(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }

                var gposes = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });
                var prices = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, new ORM_CMN_Price_Value.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                var caseBillPositions = cls_Get_Case_BillPositionIDs_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.CaseID).Select(t => new { key = t.Key, value = t.ToList() })
                    .ToDictionary(t => t.key, t => t.value);

                var gposIDs = new List<ORM_HEC_BIL_PotentialCode>();
                var specialNoDrugsGposIds = new List<ORM_HEC_BIL_PotentialCode>();

                foreach (var gpos in gposes)
                {
                    var covered_diagnoses = ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query()
                    {
                        HEC_BIL_PotentialCode_RefID = gpos.HEC_BIL_PotentialCodeID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Select(covered_diagnose => covered_diagnose.HEC_DIA_PotentialDiagnosis_RefID);

                    var covered_drugs = ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                    {
                        HEC_BIL_PotentialCode_RefID = gpos.HEC_BIL_PotentialCodeID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });

                    if (!covered_diagnoses.Any())
                    {
                        gposIDs.Add(gpos);
                        if (!covered_drugs.Any())
                        {
                            specialNoDrugsGposIds.Add(gpos);
                        }
                    }
                }

                var gposOnContracts = ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCode.Query.Search(Connection, Transaction, new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCode.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Where(t => gposIDs.Any(r => r.HEC_BIL_PotentialCodeID == t.PotentialBillCode_RefID)).GroupBy(t => t.InsuranceToBrokerContract_RefID).Select(t => new { Key = t.Key, value = t.ToList() }).ToDictionary(t => t.Key, t => t.value);

                var specialDrugGposes = ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Where(t => gposIDs.Any(r => r.HEC_BIL_PotentialCodeID == t.HEC_BIL_PotentialCode_RefID));

                var caseData = cls_Get_Cases_Bill_Data_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.CaseID).Select(t => new { Key = t.Key, value = t.ToList() }).ToDictionary(t => t.Key, t => t.value);
                List<Guid> casesToUpdate = new List<Guid>();
                foreach (var cas in caseData)
                {
                    // check for every contract
                    if (!cas.Value.Any(t => gposIDs.Any(r => r.HEC_BIL_PotentialCodeID == t.GposID)))
                    {
                        // check wartenzeiten
                        if (!cas.Value.Any(t => specialNoDrugsGposIds.Any(r => r.HEC_BIL_PotentialCodeID == t.GposID)))
                        {
                            foreach (var gp in specialNoDrugsGposIds)
                            {
                                var gposFromDb = gposes.Where(r => r.HEC_BIL_PotentialCodeID == gp.HEC_BIL_PotentialCodeID).Single();

                                ORM_BIL_BillPosition gpos_position = new ORM_BIL_BillPosition();
                                gpos_position.BIL_BilHeader_RefID = Guid.Empty;
                                gpos_position.BIL_BillPositionID = Guid.NewGuid();
                                gpos_position.Creation_Timestamp = DateTime.Now;
                                gpos_position.Modification_Timestamp = DateTime.Now;
                                gpos_position.Tenant_RefID = securityTicket.TenantID;
                                gpos_position.PositionValue_IncludingTax = (decimal)prices.Where(t => t.Price_RefID == gposFromDb.Price_RefID).Single().PriceValue_Amount;

                                gpos_position.Save(Connection, Transaction);

                                ORM_HEC_BIL_BillPosition hec_gpos_position = new ORM_HEC_BIL_BillPosition();
                                hec_gpos_position.Creation_Timestamp = DateTime.Now;
                                hec_gpos_position.Ext_BIL_BillPosition_RefID = gpos_position.BIL_BillPositionID;
                                hec_gpos_position.HEC_BIL_BillPositionID = Guid.NewGuid();
                                hec_gpos_position.Modification_Timestamp = DateTime.Now;
                                hec_gpos_position.Tenant_RefID = securityTicket.TenantID;
                                hec_gpos_position.PositionFor_Patient_RefID = cas.Value.First().PatientID;

                                hec_gpos_position.Save(Connection, Transaction);

                                ORM_HEC_BIL_BillPosition_BillCode hec_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                                hec_gpos_position_code.BillPosition_RefID = hec_gpos_position.HEC_BIL_BillPositionID;
                                hec_gpos_position_code.Creation_Timestamp = DateTime.Now;
                                hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
                                hec_gpos_position_code.IM_BillingCode = gposFromDb.BillingCode;
                                hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                hec_gpos_position_code.PotentialCode_RefID = gposFromDb.HEC_BIL_PotentialCodeID;
                                hec_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                                hec_gpos_position_code.Save(Connection, Transaction);

                                ORM_HEC_CAS_Case_BillCode hec_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                                hec_gpos_case_code.Creation_Timestamp = DateTime.Now;
                                hec_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                                hec_gpos_case_code.HEC_CAS_Case_BillCodeID = Guid.NewGuid();
                                hec_gpos_case_code.HEC_CAS_Case_RefID = cas.Key;
                                hec_gpos_case_code.Modification_Timestamp = DateTime.Now;
                                hec_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                                hec_gpos_case_code.Save(Connection, Transaction);

                                foreach (var bp in caseBillPositions[cas.Key])
                                {
                                    var fsStatuses = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                                    {
                                        BillPosition_RefID = bp.BillPositionID,
                                        Tenant_RefID = securityTicket.TenantID,
                                        IsDeleted = false
                                    });
                                    if (fsStatuses.Any())
                                    {
                                        foreach (var status in fsStatuses)
                                        {
                                            var st = new ORM_BIL_BillPosition_TransmitionStatus();
                                            st.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                            st.BillPosition_RefID = gpos_position.BIL_BillPositionID;
                                            st.Creation_Timestamp = status.Creation_Timestamp;
                                            st.IsActive = status.IsActive;
                                            st.IsTransmitionStatusManuallySet = status.IsTransmitionStatusManuallySet;
                                            st.Modification_Timestamp = status.Modification_Timestamp;
                                            st.PrimaryComment = status.PrimaryComment;
                                            st.SecondaryComment = status.SecondaryComment;
                                            st.Tenant_RefID = securityTicket.TenantID;
                                            st.TransmissionDataXML = status.TransmissionDataXML;
                                            st.TransmitionCode = status.TransmitionCode;
                                            st.TransmitionStatusKey = status.TransmitionStatusKey;
                                            st.TransmittedOnDate = status.TransmittedOnDate;

                                            st.Save(Connection, Transaction);
                                        }
                                    }
                                }
                            }
                        }

                        // check beva
                        var specialDrugGposIds = specialDrugGposes.Where(t => cas.Value.Any(c => c.DrugID == t.HEC_Product_RefID));
                        if (specialDrugGposIds.Any() && !cas.Value.Any(c => specialDrugGposIds.Any(t => t.HEC_BIL_PotentialCode_RefID == c.GposID)))
                        {
                            foreach (var gposDetail in specialDrugGposIds)
                            {
                                var gposFromDb = gposes.Where(r => r.HEC_BIL_PotentialCodeID == gposDetail.HEC_BIL_PotentialCode_RefID).Single();

                                ORM_BIL_BillPosition gpos_position = new ORM_BIL_BillPosition();
                                gpos_position.BIL_BilHeader_RefID = Guid.Empty;
                                gpos_position.BIL_BillPositionID = Guid.NewGuid();
                                gpos_position.Creation_Timestamp = DateTime.Now;
                                gpos_position.Modification_Timestamp = DateTime.Now;
                                gpos_position.Tenant_RefID = securityTicket.TenantID;
                                gpos_position.PositionValue_IncludingTax = (decimal)prices.Where(t => t.Price_RefID == gposFromDb.Price_RefID).Single().PriceValue_Amount;

                                gpos_position.Save(Connection, Transaction);

                                ORM_HEC_BIL_BillPosition hec_gpos_position = new ORM_HEC_BIL_BillPosition();
                                hec_gpos_position.Creation_Timestamp = DateTime.Now;
                                hec_gpos_position.Ext_BIL_BillPosition_RefID = gpos_position.BIL_BillPositionID;
                                hec_gpos_position.HEC_BIL_BillPositionID = Guid.NewGuid();
                                hec_gpos_position.Modification_Timestamp = DateTime.Now;
                                hec_gpos_position.Tenant_RefID = securityTicket.TenantID;
                                hec_gpos_position.PositionFor_Patient_RefID = cas.Value.First().PatientID;

                                hec_gpos_position.Save(Connection, Transaction);

                                ORM_HEC_BIL_BillPosition_BillCode hec_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                                hec_gpos_position_code.BillPosition_RefID = hec_gpos_position.HEC_BIL_BillPositionID;
                                hec_gpos_position_code.Creation_Timestamp = DateTime.Now;
                                hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
                                hec_gpos_position_code.IM_BillingCode = gposFromDb.BillingCode;
                                hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                hec_gpos_position_code.PotentialCode_RefID = gposFromDb.HEC_BIL_PotentialCodeID;
                                hec_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                                hec_gpos_position_code.Save(Connection, Transaction);

                                ORM_HEC_CAS_Case_BillCode hec_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                                hec_gpos_case_code.Creation_Timestamp = DateTime.Now;
                                hec_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                                hec_gpos_case_code.HEC_CAS_Case_BillCodeID = Guid.NewGuid();
                                hec_gpos_case_code.HEC_CAS_Case_RefID = cas.Key;
                                hec_gpos_case_code.Modification_Timestamp = DateTime.Now;
                                hec_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                                hec_gpos_case_code.Save(Connection, Transaction);

                                foreach (var bp in caseBillPositions[cas.Key])
                                {
                                    var fsStatuses = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                                    {
                                        BillPosition_RefID = bp.BillPositionID,
                                        Tenant_RefID = securityTicket.TenantID,
                                        IsDeleted = false
                                    });
                                    if (fsStatuses.Any())
                                    {
                                        foreach (var status in fsStatuses)
                                        {
                                            var st = new ORM_BIL_BillPosition_TransmitionStatus();
                                            st.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                            st.BillPosition_RefID = gpos_position.BIL_BillPositionID;
                                            st.Creation_Timestamp = status.Creation_Timestamp;
                                            st.IsActive = status.IsActive;
                                            st.IsTransmitionStatusManuallySet = status.IsTransmitionStatusManuallySet;
                                            st.Modification_Timestamp = status.Modification_Timestamp;
                                            st.PrimaryComment = status.PrimaryComment;
                                            st.SecondaryComment = status.SecondaryComment;
                                            st.Tenant_RefID = securityTicket.TenantID;
                                            st.TransmissionDataXML = status.TransmissionDataXML;
                                            st.TransmitionCode = status.TransmitionCode;
                                            st.TransmitionStatusKey = status.TransmitionStatusKey;
                                            st.TransmittedOnDate = status.TransmittedOnDate;

                                            st.Save(Connection, Transaction);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixMultipleDoctorsConsents(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }

                var consents = cls_Get_all_Doctor_Consents.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.ContractID).Select(t => new { Key = t.Key, Value = t.ToList() })
                    .ToDictionary(t => t.Key, t => t.Value);

                if (consents.Count != 0)
                {
                    foreach (var consent in consents)
                    {
                        var doctorConsents = consent.Value.GroupBy(t => t.DoctorID).Select(t => new { Key = t.Key, Value = t.ToList() })
                            .ToDictionary(t => t.Key, t => t.Value);

                        foreach (var docConsent in doctorConsents)
                        {
                            var doubleConsents = docConsent.Value.GroupBy(t => t.ConsentValidFrom).Select(t => new { Key = t.Key, Value = t.ToList() })
                            .ToDictionary(t => t.Key, t => t.Value);

                            foreach (var doubleConsent in doubleConsents)
                            {
                                var idsToDelete = doubleConsent.Value.Skip(1);

                                foreach (var id in idsToDelete)
                                {
                                    var participatingDoc = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query()
                                    {
                                        IsDeleted = false,
                                        Tenant_RefID = securityTicket.TenantID,
                                        HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID = id.AssignmentID
                                    }).SingleOrDefault();

                                    if (participatingDoc != null)
                                    {
                                        participatingDoc.IsDeleted = true;
                                        participatingDoc.Modification_Timestamp = DateTime.Now;

                                        participatingDoc.Save(Connection, Transaction);
                                    }
                                }
                            }
                        }
                    }
                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixMultipleAftercareFsStatuses(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }

                var statuses = cls_Get_Multiple_Active_Aftercare_FS_Statuses.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.CaseID).Select(t => new { Key = t.Key, Value = t.ToList() })
                    .ToDictionary(t => t.Key, t => t.Value);

                Console.WriteLine("Found cases: " + statuses.Count);

                if (statuses.Count != 0)
                {
                    foreach (var status in statuses)
                    {
                        var idsToDelete = status.Value.Skip(1).ToList();
                        foreach (var id in idsToDelete)
                        {
                            var fsStatus = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                            {
                                BIL_BillPosition_TransmitionStatusID = id.StatusID
                            }).SingleOrDefault();

                            if (fsStatus != null)
                            {
                                fsStatus.IsDeleted = true;
                                fsStatus.Modification_Timestamp = DateTime.Now;

                                fsStatus.Save(Connection, Transaction);


                                var billPosition = new ORM_BIL_BillPosition();
                                billPosition.Load(Connection, Transaction, fsStatus.BillPosition_RefID);

                                billPosition.Remove(Connection, Transaction);

                                var hecBillPosition = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, new ORM_HEC_BIL_BillPosition.Query()
                                {
                                    Ext_BIL_BillPosition_RefID = billPosition.BIL_BillPositionID
                                }).Single();

                                hecBillPosition.Remove(Connection, Transaction);

                                var hecBillCode = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_BillPosition_BillCode.Query()
                                {
                                    BillPosition_RefID = hecBillPosition.HEC_BIL_BillPositionID
                                }).Single();

                                hecBillCode.Remove(Connection, Transaction);

                                var caseBillCode = ORM_HEC_CAS_Case_BillCode.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_BillCode.Query()
                                {
                                    HEC_BIL_BillPosition_BillCode_RefID = hecBillCode.HEC_BIL_BillPosition_BillCodeID
                                }).Single();

                                caseBillCode.Remove(Connection, Transaction);
                            }
                            else
                            {
                                Console.WriteLine("Fs status not found for id: {0}", id.StatusID);
                            }
                        }
                    }
                }

                Console.WriteLine("Save changes? [y/n]");
                if (Console.ReadLine().ToLower() == "y")
                {
                    Transaction.Commit();
                }

                Connection.Close();

            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixDataInDB(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }

                List<ORM_HEC_Doctor> doctors = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                if (doctors.Count != 0)
                {
                    foreach (var doctor in doctors)
                    {
                        ORM_USR_Account acc = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query() { BusinessParticipant_RefID = doctor.BusinessParticipant_RefID, Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).SingleOrDefault();
                        if (acc != null)
                        {
                            doctor.Account_RefID = acc.USR_AccountID;
                            doctor.Save(Connection, Transaction);
                        }
                    }

                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixDoubleAftercares(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }

                var all_cases = ORM_HEC_CAS_Case.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case.Query() { IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).OrderBy(c => c.Creation_Timestamp).Where(cas => Convert.ToInt32(cas.CaseNumber) < 10000).ToList();
                if (all_cases.Count != 0)
                {
                    var i = 0;
                    foreach (var cas in all_cases)
                    {
                        var case_fs_statuses = cls_Get_Case_FS_Status_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCFSSfCID_2238()
                        {
                            CaseID = cas.HEC_CAS_CaseID
                        }, securityTicket).Result.Where(fss => fss.case_type == "treatment" && fss.price == 60).ToArray();

                        if (case_fs_statuses.Length != 0)
                        {
                            var case_bill_position_ids = cls_Get_BillPositionIDs_for_CaseID_of_Cases_Billed_Old_Way.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCIDoCBOW_1509() { CaseID = cas.HEC_CAS_CaseID }, securityTicket).Result;
                            if (case_bill_position_ids != null)
                            {
                                var case_billcode = ORM_HEC_CAS_Case_BillCode.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_BillCode.Query()
                                {
                                    HEC_CAS_Case_BillCodeID = case_bill_position_ids.HEC_CAS_Case_BillCodeID
                                    ,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).SingleOrDefault();

                                if (case_billcode != null)
                                {
                                    case_billcode.Modification_Timestamp = DateTime.Now;
                                    case_billcode.IsDeleted = true;

                                    case_billcode.Save(Connection, Transaction);

                                    var billposition_billcode = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_BillPosition_BillCode.Query()
                                    {
                                        HEC_BIL_BillPosition_BillCodeID = case_bill_position_ids.HEC_BIL_BillPosition_BillCodeID,
                                        IsDeleted = false,
                                        Tenant_RefID = securityTicket.TenantID
                                    }).SingleOrDefault();

                                    if (billposition_billcode != null)
                                    {
                                        billposition_billcode.Modification_Timestamp = DateTime.Now;
                                        billposition_billcode.IsDeleted = true;

                                        billposition_billcode.Save(Connection, Transaction);

                                        var hec_billposition = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, new ORM_HEC_BIL_BillPosition.Query()
                                        {
                                            HEC_BIL_BillPositionID = case_bill_position_ids.HEC_BIL_BillPositionID,
                                            IsDeleted = false,
                                            Tenant_RefID = securityTicket.TenantID
                                        }).SingleOrDefault();

                                        if (hec_billposition != null)
                                        {
                                            hec_billposition.Modification_Timestamp = DateTime.Now;
                                            hec_billposition.IsDeleted = true;

                                            hec_billposition.Save(Connection, Transaction);

                                            var bil_billposition = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition.Query()
                                            {
                                                BIL_BillPositionID = case_bill_position_ids.BIL_BillPositionID,
                                                IsDeleted = false,
                                                Tenant_RefID = securityTicket.TenantID
                                            }).SingleOrDefault();

                                            if (bil_billposition != null)
                                            {
                                                bil_billposition.Modification_Timestamp = DateTime.Now;
                                                bil_billposition.IsDeleted = true;

                                                bil_billposition.Save(Connection, Transaction);

                                                var billposition_transmitionstatus = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                                                {
                                                    BIL_BillPosition_TransmitionStatusID = case_bill_position_ids.BIL_BillPosition_TransmitionStatusID,
                                                    Tenant_RefID = securityTicket.TenantID,
                                                    IsDeleted = false
                                                }).SingleOrDefault();

                                                if (billposition_transmitionstatus != null)
                                                {
                                                    billposition_transmitionstatus.Modification_Timestamp = DateTime.Now;
                                                    billposition_transmitionstatus.IsDeleted = true;

                                                    billposition_transmitionstatus.Save(Connection, Transaction);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        Console.Write("\rCase {0} of {1} updated.                            ", i++, all_cases.Count);
                    }
                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixContractRoles(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }

                var roles = ORM_CMN_CTR_Contract_Role.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Role.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                var rolesToKeep = new List<ORM_CMN_CTR_Contract_Role>();

                rolesToKeep.Add(roles.Where(r => r.RoleName == "Mediator").First());
                rolesToKeep.Add(roles.Where(r => r.RoleName == "Health Insurance Provider").First());

                foreach (var role in roles)
                {
                    if (!rolesToKeep.Any(r => r.CMN_CTR_Contract_RoleID == role.CMN_CTR_Contract_RoleID))
                    {
                        role.IsDeleted = true;
                        role.Modification_Timestamp = DateTime.Now;

                        role.Save(Connection, Transaction);
                    }
                }

                var contractParties = ORM_CMN_CTR_Contract_Party.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Party.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                foreach (var party in contractParties)
                {
                    if (!rolesToKeep.Any(r => r.CMN_CTR_Contract_RoleID == party.Party_ContractRole_RefID))
                    {
                        var name = roles.Where(rl => rl.CMN_CTR_Contract_RoleID == party.Party_ContractRole_RefID).Single().RoleName;
                        party.Party_ContractRole_RefID = rolesToKeep.Where(rr => rr.RoleName == name).Single().CMN_CTR_Contract_RoleID;
                        party.Modification_Timestamp = DateTime.Now;

                        party.Save(Connection, Transaction);
                    }
                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixDoubleParticipationConsents(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }

                // todo

                var allParticipationConsents = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).GroupBy(t => t.InsuranceToBrokerContract_RefID).Select(t => new { Key = t.Key, Values = t.ToList() }).ToDictionary(t => t.Key, t => t.Values);

                foreach (var consentListOnContract in allParticipationConsents)
                {
                    var patientsConsentsOnContract = consentListOnContract.Value.GroupBy(t => t.Patient_RefID).Select(t => new { Key = t.Key, Values = t.ToList() }).ToDictionary(t => t.Key, t => t.Values);
                    foreach (var patientConsents in patientsConsentsOnContract)
                    {
                        var consentCounts = patientConsents.Value.GroupBy(t => t.ValidFrom).Select(t => new { Key = t.Key, Value = t.ToList() }).ToList();
                        if (consentCounts.Any(t => t.Value.Count > 1))
                        {
                            var duplicateConsentsList = consentCounts.Where(t => t.Value.Count > 1).Select(t => t.Value.ToList());
                            foreach (var duplicateConsents in duplicateConsentsList)
                            {
                                foreach (var consent in duplicateConsents.Skip(1))
                                {
                                    consent.IsDeleted = true;
                                    consent.Modification_Timestamp = DateTime.Now;

                                    consent.Save(Connection, Transaction);
                                }
                            }
                        }
                    }
                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixGposData(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }
                // code
                var potential_codes = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode.Query()
                {
                    IsDeleted = false,
                    BillingCode = "36620062"
                });

                if (potential_codes.Count != 0)
                {
                    foreach (var potential_code in potential_codes)
                    {
                        ORM_HEC_DIA_PotentialDiagnosis_CatalogCode old_diagnose = null;
                        try
                        {
                            old_diagnose = ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query.Search(Connection, Transaction, new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query()
                            {
                                Code = "H36.0",
                                IsDeleted = false,
                                Tenant_RefID = potential_code.Tenant_RefID
                            }).SingleOrDefault();
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }

                        if (old_diagnose != null)
                        {
                            var old_diagnose_to_potential_code = ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query()
                            {
                                Tenant_RefID = potential_code.Tenant_RefID,
                                IsDeleted = false,
                                HEC_BIL_PotentialCode_RefID = potential_code.HEC_BIL_PotentialCodeID,
                                HEC_DIA_PotentialDiagnosis_RefID = old_diagnose.PotentialDiagnosis_RefID
                            }).SingleOrDefault();

                            if (old_diagnose_to_potential_code != null)
                            {
                                old_diagnose_to_potential_code.IsDeleted = true;
                                old_diagnose_to_potential_code.Save(Connection, Transaction);

                                var new_diagnose = ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query.Search(Connection, Transaction, new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query()
                                {
                                    Code = "H34.8",
                                    IsDeleted = false,
                                    Tenant_RefID = potential_code.Tenant_RefID
                                }).SingleOrDefault();

                                if (new_diagnose != null)
                                {
                                    var new_diagnose_to_potential_code = new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis();
                                    new_diagnose_to_potential_code.Tenant_RefID = potential_code.Tenant_RefID;
                                    new_diagnose_to_potential_code.AssignmentID = Guid.NewGuid();
                                    new_diagnose_to_potential_code.Creation_Timestamp = old_diagnose_to_potential_code.Creation_Timestamp;
                                    new_diagnose_to_potential_code.HEC_BIL_PotentialCode_RefID = potential_code.HEC_BIL_PotentialCodeID;
                                    new_diagnose_to_potential_code.HEC_DIA_PotentialDiagnosis_RefID = new_diagnose.PotentialDiagnosis_RefID;
                                    new_diagnose_to_potential_code.Modification_Timestamp = DateTime.Now;

                                    new_diagnose_to_potential_code.Save(Connection, Transaction);
                                }
                            }
                        }
                    }
                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }

        public static void FixOpenAftercaresBillPositions(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            using (var Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString))
            {
                Connection.Open();
                var Transaction = Connection.BeginTransaction();

                var all_languagesQ = new ORM_CMN_Language.Query();
                all_languagesQ.Tenant_RefID = securityTicket.TenantID;
                all_languagesQ.IsDeleted = false;

                var all_languagesL = ORM_CMN_Language.Query.Search(Connection, Transaction, all_languagesQ).ToArray();

                var cases = cls_Get_Submitted_CaseIDs.Invoke(Connection, Transaction, securityTicket).Result;

                if (cases.Length != 0)
                {
                    var g_cases = cases.GroupBy(cas => cas.case_id).Where(cas => !cas.Any(t => t.gpos_type == EGposType.Aftercare.Value()) && cas.Any(t => t.gpos_type == EGposType.Operation.Value())).ToDictionary(t => t.Key, t => t.ToList());

                    var changed = false;
                    Console.WriteLine("cases found: " + g_cases.Count);
                    foreach (var cas in g_cases)
                    {
                        var case_number = cas.Value.First().case_number;

                        var case_details = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = cas.Key }, securityTicket).Result;
                        if (case_details != null)
                        {
                            if (!changed)
                            {
                                changed = true;
                            }

                            Console.WriteLine("Fixing case: {0}", case_number);

                            cls_Calculate_Case_GPOS.Invoke(Connection, Transaction, new P_CAS_CCGPOS_1000()
                            {
                                ac_doctor_id = case_details.ac_doctor_id != Guid.Empty ? case_details.ac_doctor_id : case_details.ac_practice_id,
                                case_id = cas.Key,
                                diagnose_id = case_details.diagnose_id,
                                drug_id = case_details.drug_id,
                                localization = case_details.localization,
                                patient_id = case_details.patient_id,
                                treatment_doctor_id = Guid.Empty,
                                treatment_date = case_details.treatment_date,
                                all_languagesL = all_languagesL
                            }, securityTicket);
                        }
                    }
                    if (changed)
                    {
                        Console.WriteLine("Save changes? [y/n]");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            Transaction.Commit();
                        }
                    }
                }
            }
        }

        public static void FixAftercareFSStatus(string ConnectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;

            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GCIDfTDaHIP_1222 functionReturn = new FR_CAS_GCIDfTDaHIP_1222();
            try
            {

                if (cleanupConnection)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                }

                ORM_CMN_Language.Query all_languagesQ = new ORM_CMN_Language.Query();
                all_languagesQ.Tenant_RefID = securityTicket.TenantID;
                all_languagesQ.IsDeleted = false;

                var all_languagesL = ORM_CMN_Language.Query.Search(Connection, Transaction, all_languagesQ).ToArray();

                var cases = cls_Get_Cases_Where_Aftercare_Performed.Invoke(Connection, Transaction, securityTicket).Result;
                Console.WriteLine("cases found: " + cases.Length);

                if (cases.Length != 0)
                {
                    Console.WriteLine();
                    foreach (var cas in cases)
                    {
                        var bill_positions = cls_Get_Submitted_Aftercare_Bill_Position_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GSABPIDfCID_1013() { CaseID = cas.case_id }, securityTicket).Result;
                        if (bill_positions.Length == 0)
                        {
                            Console.Write("\r");

                            var case_details = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = cas.case_id }, securityTicket).Result;
                            if (case_details != null)
                            {
                                Console.WriteLine("Case " + cas.case_number + " fixing started.");
                                cls_Calculate_Case_GPOS.Invoke(Connection, Transaction, new P_CAS_CCGPOS_1000()
                                {
                                    ac_doctor_id = case_details.ac_doctor_id,
                                    case_id = cas.case_id,
                                    diagnose_id = case_details.diagnose_id,
                                    drug_id = case_details.drug_id,
                                    localization = case_details.localization,
                                    patient_id = case_details.patient_id,
                                    treatment_doctor_id = Guid.Empty,
                                    treatment_date = case_details.treatment_date,
                                    all_languagesL = all_languagesL,
                                    should_update = true
                                }, securityTicket);
                            }
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                }

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method fix doctors table: " + ex.StackTrace, ex);
            }
        }
    }
}
