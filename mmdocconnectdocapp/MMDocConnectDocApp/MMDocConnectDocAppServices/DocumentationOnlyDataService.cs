using DLCore_TokenVerification;
using MMDocConnectDocAppInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMDocConnectUtils;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using System.Web;
using System.Reflection;
using System.Data.Common;
using CSV2Core_MySQL.Support;
using LogUtils;
using MMDocConnectDocAppModels;
using System.Globalization;
using MMDocConnectDocApp;
using MMDocConnectDBMethods.Case.Atomic.Manipulation;
using CL1_HEC_CAS;
using CL1_USR;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using CL1_HEC_TRE;
using CL1_CMN;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using BOp.Providers;
using BOp.Providers.TMS.Requests;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using CSV2Core.SessionSecurity;
using CL1_CMN_BPT;
using CL1_HEC;
using MMDocConnectElasticSearchMethods;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using CL1_CMN_CTR;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using CL1_HEC_ACT;
using CL1_HEC_BIL;
using CL1_BIL;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using SharedServiceUtils;


namespace MMDocConnectDocAppServices
{
    public class DocumentationOnlyDataService : BaseVerification, IDocumentationOnlyDataService
    {

        public DocumentationOnlyOpAndOctData GetExistingCasesForPatient(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            transaction = new TransactionalInformation();

            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            var result = new DocumentationOnlyOpAndOctData();

            try
            {
                using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                {
                    dbConnection.Open();
                    var dbTransaction = dbConnection.BeginTransaction();
                    var existing_ivoms = cls_Get_Latest_Cases_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GLCfPIDaL_2013() { PatientID = patient_id }, securityTicket).Result.GroupBy(t => t.localization).ToDictionary(t => t.Key, t => t.ToList());
                    var left_eye_localization_code = "L";
                    var right_eye_localization_code = "R";
                    var doctor_data = cls_Get_Doctor_Details_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result.GroupBy(t => t.id).ToDictionary(t => t.Key, t => t.Single());

                    if (existing_ivoms.ContainsKey(left_eye_localization_code))
                    {
                        result.left_eye = new DocumentationOnlyEye();
                        result.left_eye.ops = existing_ivoms[left_eye_localization_code].Select(t =>
                        {
                            var doctor = doctor_data[t.op_doctor_id];

                            return new DocumentationOnlyOp()
                            {
                                date = t.date,
                                is_regular_op = true,
                                diagnose_id = t.diagnose_id,
                                drug_id = t.drug_id,
                                id = t.case_id,
                                doctor = new AutocompleteModel()
                                {
                                    display_name = String.Format("{0} {1} {2} ({3})", doctor.title, doctor.first_name, doctor.last_name, doctor.lanr),
                                    name = GenericUtils.GetDoctorName(doctor),
                                    id = doctor.id,
                                    secondary_display_name = doctor.practice_name
                                }
                            };
                        });
                    }

                    if (existing_ivoms.ContainsKey(right_eye_localization_code))
                    {
                        result.right_eye = new DocumentationOnlyEye();
                        result.right_eye.ops = existing_ivoms[right_eye_localization_code].Select(t =>
                        {
                            var doctor = doctor_data[t.op_doctor_id];

                            return new DocumentationOnlyOp()
                            {
                                date = t.date,
                                is_regular_op = true,
                                diagnose_id = t.diagnose_id,
                                drug_id = t.drug_id,
                                id = t.case_id,
                                doctor = new AutocompleteModel()
                                {
                                    display_name = String.Format("{0} {1} {2} ({3})", doctor.title, doctor.first_name, doctor.last_name, doctor.lanr),
                                    name = GenericUtils.GetDoctorName(doctor),
                                    id = doctor.id,
                                    secondary_display_name = doctor.practice_name
                                }
                            };
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return result;
        }

        public DocumentationOnlyOpAndOctData GetExistingDocumentationOnlyCases(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { address = "none", agent = "none" };

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            var result = new DocumentationOnlyOpAndOctData();
            result.patient_id = patient_id;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var fake_case_property = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
                    {
                        GlobalPropertyMatchingID = ECaseProperty.FakeCase.Value(),
                        IsValue_Boolean = true,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    var fake_case_property_id = fake_case_property != null ? fake_case_property.HEC_CAS_Case_UniversalPropertyID : Guid.Empty;
                    var left_eye_localization_code = "L";
                    var right_eye_localization_code = "R";
                    var left_eye_latest_ivom = cls_Get_Latest_CaseBasicInformation_for_PatientID_and_Localization.Invoke(dbConnection, dbTransaction, new P_CAS_GLCBIfPIDaL_1737()
                    {
                        Localization = left_eye_localization_code,
                        PatientID = patient_id,
                        CasePropertyID = fake_case_property_id
                    }, securityTicket).Result;
                    var right_eye_latest_ivom = cls_Get_Latest_CaseBasicInformation_for_PatientID_and_Localization.Invoke(dbConnection, dbTransaction, new P_CAS_GLCBIfPIDaL_1737()
                    {
                        Localization = right_eye_localization_code,
                        PatientID = patient_id,
                        CasePropertyID = fake_case_property_id
                    }, securityTicket).Result;
                    var fake_case_ids = cls_Get_DocumentationOnly_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GDOCIDs_1610()
                    {
                        PatientID = patient_id,
                        PropertyGpmID = ECaseProperty.FakeCase.Value()
                    }, securityTicket).Result;
                    var all_case_ids = cls_Get_DocumentationOnly_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GDOCIDs_1610()
                    {
                        PatientID = patient_id,
                        PropertyGpmID = ECaseProperty.DocumentationOnly.Value()
                    }, securityTicket).Result;
                    var missing_ivom_case_ids = cls_Get_DocumentationOnly_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GDOCIDs_1610()
                    {
                        PatientID = patient_id,
                        PropertyGpmID = ECaseProperty.MissingIvom.Value()
                    }, securityTicket).Result;
                    var doctor_data = cls_Get_Doctor_Details_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result.GroupBy(t => t.id).ToDictionary(t => t.Key, t => t.Single());
                    var case_ids = all_case_ids.Where(t => !fake_case_ids.Any(x => x.case_id == t.case_id)).ToList();
                    var left_eye_ops_list = new List<DocumentationOnlyOp>();
                    var right_eye_ops_list = new List<DocumentationOnlyOp>();
                    var left_eye_treatment_year_start_date = DateTime.MinValue.ToUniversalTime();
                    var right_eye_treatment_year_start_date = DateTime.MinValue.ToUniversalTime();

                    if (left_eye_latest_ivom != null && !missing_ivom_case_ids.Any(r => r.case_id == left_eye_latest_ivom.case_id))
                    {
                        result.left_eye = new DocumentationOnlyEye();
                        var doctor = doctor_data[left_eye_latest_ivom.op_doctor_id];

                        left_eye_ops_list.Add(new DocumentationOnlyOp()
                        {
                            date = left_eye_latest_ivom.date.ToUniversalTime(),
                            diagnose_id = left_eye_latest_ivom.diagnose_id,
                            doctor = new AutocompleteModel()
                            {
                                display_name = String.Format("{0} {1} {2} ({3})", doctor.title, doctor.first_name, doctor.last_name, doctor.lanr),
                                name = GenericUtils.GetDoctorName(doctor),
                                id = doctor.id,
                                secondary_display_name = doctor.practice_name
                            },
                            drug_id = left_eye_latest_ivom.drug_id,
                            id = left_eye_latest_ivom.case_id,
                            is_regular_op = !all_case_ids.Any(r => r.case_id == left_eye_latest_ivom.case_id)
                        });

                        left_eye_treatment_year_start_date = left_eye_latest_ivom.date;
                    }

                    if (right_eye_latest_ivom != null && !missing_ivom_case_ids.Any(r => r.case_id == right_eye_latest_ivom.case_id))
                    {
                        result.right_eye = new DocumentationOnlyEye();
                        var doctor = doctor_data[right_eye_latest_ivom.op_doctor_id];

                        right_eye_ops_list.Add(new DocumentationOnlyOp()
                        {
                            date = right_eye_latest_ivom.date.ToUniversalTime(),
                            diagnose_id = right_eye_latest_ivom.diagnose_id,
                            doctor = new AutocompleteModel()
                            {
                                display_name = String.Format("{0} {1} {2} ({3})", doctor.title, doctor.first_name, doctor.last_name, doctor.lanr),
                                name = GenericUtils.GetDoctorName(doctor),
                                id = doctor.id,
                                secondary_display_name = doctor.practice_name
                            },
                            drug_id = right_eye_latest_ivom.drug_id,
                            id = right_eye_latest_ivom.case_id,
                            is_regular_op = !all_case_ids.Any(r => r.case_id == right_eye_latest_ivom.case_id)
                        });

                        right_eye_treatment_year_start_date = right_eye_latest_ivom.date;
                    }

                    if (case_ids.Any())
                    {
                        var caseIdArray = case_ids.Select(t => t.case_id).ToArray();
                        var allCaseIds = all_case_ids.Select(t => t.case_id).ToArray();
                        var all_ops = cls_Get_Case_Treatment_Data_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GCTDfCIDs_1624() { CaseIDs = allCaseIds }, securityTicket).Result.GroupBy(t => t.localization).ToDictionary(t => t.Key, t => t.ToList());
                        if (all_ops.ContainsKey(left_eye_localization_code))
                        {
                            if (result.left_eye == null)
                            {
                                result.left_eye = new DocumentationOnlyEye();
                            }

                            result.left_eye.octs = Enumerable.Empty<DocumentationOnlyOct>();

                            var all_left_eye_ops = all_ops[left_eye_localization_code];
                            var left_eye_ops = all_left_eye_ops.Where(t => !fake_case_ids.Any(r => r.case_id == t.case_id) && !left_eye_ops_list.Any(r => r.id == t.case_id)).ToList();
                            left_eye_ops_list.AddRange(left_eye_ops.Select(t =>
                            {
                                var doctor = doctor_data[t.op_doctor_id];

                                return new DocumentationOnlyOp()
                                {
                                    date = t.treatment_date.ToUniversalTime(),
                                    diagnose_id = t.diagnose_id,
                                    doctor = new AutocompleteModel()
                                    {
                                        display_name = String.Format("{0} {1} {2} ({3})", doctor.title, doctor.first_name, doctor.last_name, doctor.lanr),
                                        name = GenericUtils.GetDoctorName(doctor),
                                        id = doctor.id,
                                        secondary_display_name = doctor.practice_name
                                    },
                                    drug_id = t.drug_id,
                                    id = t.case_id
                                };
                            }).ToList());

                            var fake_case = all_left_eye_ops.SingleOrDefault(t => fake_case_ids.Any(x => x.case_id == t.case_id));
                            if (fake_case != null)
                            {
                                left_eye_treatment_year_start_date = fake_case.treatment_date;
                            }
                            else
                            {
                                left_eye_treatment_year_start_date = all_left_eye_ops.Min(t => t.treatment_date).ToUniversalTime();
                            }
                        }

                        if (all_ops.ContainsKey(right_eye_localization_code))
                        {
                            if (result.right_eye == null)
                            {
                                result.right_eye = new DocumentationOnlyEye();
                            }

                            result.right_eye.octs = Enumerable.Empty<DocumentationOnlyOct>();

                            var all_right_eye_ops = all_ops[right_eye_localization_code];
                            var right_eye_ops = all_right_eye_ops.Where(t => !fake_case_ids.Any(r => r.case_id == t.case_id) && !right_eye_ops_list.Any(r => r.id == t.case_id)).ToList();
                            right_eye_ops_list.AddRange(right_eye_ops.Select(t =>
                            {
                                var doctor = doctor_data[t.op_doctor_id];

                                return new DocumentationOnlyOp()
                                {
                                    date = t.treatment_date.ToUniversalTime(),
                                    diagnose_id = t.diagnose_id,
                                    doctor = new AutocompleteModel()
                                    {
                                        display_name = String.Format("{0} {1} {2} ({3})", doctor.title, doctor.first_name, doctor.last_name, doctor.lanr),
                                        name = GenericUtils.GetDoctorName(doctor),
                                        id = doctor.id,
                                        secondary_display_name = doctor.practice_name
                                    },
                                    drug_id = t.drug_id,
                                    id = t.case_id
                                };
                            }).ToList());

                            var fake_case = all_right_eye_ops.SingleOrDefault(t => fake_case_ids.Any(x => x.case_id == t.case_id));
                            if (fake_case != null)
                            {
                                right_eye_treatment_year_start_date = fake_case.treatment_date;
                            }
                            else
                            {
                                right_eye_treatment_year_start_date = all_right_eye_ops.Min(t => t.treatment_date).ToUniversalTime();
                            }
                        }

                        var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;
                        var oct_case_id_array = caseIdArray.Where(t => !missing_ivom_case_ids.Any(r => r.case_id == t)).ToArray();
                        if (oct_case_id_array.Any())
                        {
                            var case_fs_statuses = cls_Get_Case_TransmitionCode_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GCTCfCIDs_1519()
                            {
                                CaseID = caseIdArray
                            }, securityTicket).Result.Where(t => t.fs_key == "oct").ToList();
                            var all_octs = cls_Get_OctData_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GOctDfCIDs_1642() { CaseIDs = oct_case_id_array, ActionTypeID = oct_planned_action_type_id }, securityTicket).Result;
                            var documentation_octs = new List<CAS_GOctDfCIDs_1642>();

                            for (var i = 0; i < all_octs.Length; i++)
                            {
                                var status = case_fs_statuses[i].fs_status;
                                if (status == 13)
                                {
                                    documentation_octs.Add(all_octs[i]);
                                }
                            }

                            var octs = documentation_octs.GroupBy(t => t.localization).ToDictionary(t => t.Key, t => t.ToList());

                            if (octs.ContainsKey(left_eye_localization_code))
                            {
                                var left_eye_octs = octs[left_eye_localization_code];
                                result.left_eye.octs = left_eye_octs.Select(t =>
                                {
                                    var doctor = doctor_data[t.doctor_id];

                                    return new DocumentationOnlyOct()
                                    {
                                        date = t.date.ToUniversalTime(),
                                        doctor = new AutocompleteModel()
                                        {
                                            display_name = String.Format("{0} {1} {2} ({3})", doctor.title, doctor.first_name, doctor.last_name, doctor.lanr),
                                            name = GenericUtils.GetDoctorName(doctor),
                                            id = doctor.id,
                                            secondary_display_name = doctor.practice_name
                                        },
                                        id = t.id
                                    };
                                }).ToList();

                                var min_oct_date = left_eye_octs.Min(t => t.date);
                                if (min_oct_date < result.left_eye.treatment_year_start_date)
                                {
                                    result.left_eye.treatment_year_start_date = min_oct_date.ToUniversalTime();
                                }
                            }

                            if (octs.ContainsKey(right_eye_localization_code))
                            {
                                result.right_eye.octs = octs[right_eye_localization_code].Select(t =>
                                {
                                    var doctor = doctor_data[t.doctor_id];

                                    return new DocumentationOnlyOct()
                                    {
                                        date = t.date.ToUniversalTime(),
                                        doctor = new AutocompleteModel()
                                        {
                                            display_name = String.Format("{0} {1} {2} ({3})", doctor.title, doctor.first_name, doctor.last_name, doctor.lanr),
                                            name = GenericUtils.GetDoctorName(doctor),
                                            id = doctor.id,
                                            secondary_display_name = doctor.practice_name
                                        },
                                        id = t.id
                                    };
                                }).ToList();
                            }
                        }
                    }

                    if (result.left_eye != null)
                    {
                        result.left_eye.ops = left_eye_ops_list.OrderBy(t => t.date).ToList();
                        result.left_eye.treatment_year_start_date = left_eye_treatment_year_start_date;
                        result.left_eye.latest_ivom = result.left_eye.ops.Last();
                    }

                    if (result.right_eye != null)
                    {
                        result.right_eye.ops = right_eye_ops_list.OrderBy(t => t.date).ToList();
                        result.right_eye.treatment_year_start_date = right_eye_treatment_year_start_date;
                        result.right_eye.latest_ivom = result.right_eye.ops.Last();
                    }
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return result;
        }

        private void DeleteOp(Guid case_id, Guid case_id_to_transfer_octs_to, List<ORM_HEC_BIL_PotentialCode> retrieved_gposes, DbConnection dbConnection, DbTransaction dbTransaction, SessionSecurityTicket securityTicket)
        {
            var case_details = cls_Get_Case_Details_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCDfCID_1435() { CaseID = case_id }, securityTicket).Result;

            #region Case and billing
            ORM_HEC_CAS_Case.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_CAS_Case.Query()
            {
                HEC_CAS_CaseID = case_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            var case_bill_codes = ORM_HEC_CAS_Case_BillCode.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_BillCode.Query()
            {
                HEC_CAS_Case_RefID = case_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            var oct_gpos_catalog_id = ORM_HEC_BIL_PotentialCode_Catalog.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_PotentialCode_Catalog.Query()
            {
                GlobalPropertyMatchingID = EGposType.Oct.Value(),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single().HEC_BIL_PotentialCode_CatalogID;

            var relevant_planned_actions = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query()
            {
                Case_RefID = case_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            foreach (var relevant_planned_action in relevant_planned_actions)
            {
                if (case_id_to_transfer_octs_to != Guid.Empty)
                {
                    relevant_planned_action.Case_RefID = case_id_to_transfer_octs_to;
                    relevant_planned_action.Save(dbConnection, dbTransaction);
                }
                else
                {
                    relevant_planned_action.Remove(dbConnection, dbTransaction);
                }
            }

            foreach (var case_bill_code in case_bill_codes)
            {
                var bill_position_bill_code = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_BillPosition_BillCode.Query()
                {
                    HEC_BIL_BillPosition_BillCodeID = case_bill_code.HEC_BIL_BillPosition_BillCode_RefID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                var gpos_id = bill_position_bill_code.PotentialCode_RefID;

                var gpos = retrieved_gposes.SingleOrDefault(t => t.HEC_BIL_PotentialCodeID == gpos_id);
                if (gpos == null)
                {
                    gpos = ORM_HEC_BIL_PotentialCode.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_PotentialCode.Query()
                    {
                        HEC_BIL_PotentialCodeID = gpos_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single(); ;

                    retrieved_gposes.Add(gpos);
                }

                var is_oct = gpos.PotentialCode_Catalog_RefID == oct_gpos_catalog_id;
                if (is_oct && case_id_to_transfer_octs_to != Guid.Empty)
                {
                    case_bill_code.HEC_CAS_Case_RefID = case_id_to_transfer_octs_to;
                    case_bill_code.Save(dbConnection, dbTransaction);
                }
                else
                {
                    case_bill_code.Remove(dbConnection, dbTransaction);
                    bill_position_bill_code.Remove(dbConnection, dbTransaction);

                    var hec_bill_position = ORM_HEC_BIL_BillPosition.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_BillPosition.Query()
                    {
                        HEC_BIL_BillPositionID = bill_position_bill_code.BillPosition_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    hec_bill_position.Remove(dbConnection, dbTransaction);

                    var bill_position_id = hec_bill_position.Ext_BIL_BillPosition_RefID;

                    var bill_position = ORM_BIL_BillPosition.Query.Search(dbConnection, dbTransaction, new ORM_BIL_BillPosition.Query()
                    {
                        BIL_BillPositionID = bill_position_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    bill_position.Remove(dbConnection, dbTransaction);

                    var bill_header_id = bill_position.BIL_BilHeader_RefID;

                    ORM_BIL_BillHeader.Query.SoftDelete(dbConnection, dbTransaction, new ORM_BIL_BillHeader.Query()
                    {
                        BIL_BillHeaderID = bill_header_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });

                    ORM_HEC_BIL_BillHeader.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_BIL_BillHeader.Query()
                    {
                        Ext_BIL_BillHeader_RefID = bill_header_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });

                    ORM_BIL_BillPosition_TransmitionStatus.Query.SoftDelete(dbConnection, dbTransaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                    {
                        BillPosition_RefID = bill_position_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });
                }
            }
            #endregion

            #region Initial performed action
            var relevant_performed_action = ORM_HEC_CAS_Case_RelevantPerformedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_RelevantPerformedAction.Query()
            {
                Case_RefID = case_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            relevant_performed_action.Remove(dbConnection, dbTransaction);

            var initial_performed_action_id = relevant_performed_action.PerformedAction_RefID;

            ORM_HEC_ACT_PerformedAction.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction.Query()
            {
                HEC_ACT_PerformedActionID = initial_performed_action_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            var initial_performed_action_diagnosis_update = ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query()
            {
                HEC_ACT_PerformedAction_RefID = initial_performed_action_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            initial_performed_action_diagnosis_update.Remove(dbConnection, dbTransaction);

            ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query()
            {
                HEX_EXC_Action_DiagnosisUpdate_RefID = initial_performed_action_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            ORM_HEC_ACT_PerformedAction_2_ActionType.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction_2_ActionType.Query()
            {
                HEC_ACT_PerformedAction_RefID = initial_performed_action_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });
            #endregion

            #region Op planned action
            var op_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction.Query()
            {
                IfPlannedFollowup_PreviousAction_RefID = initial_performed_action_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            op_planned_action.Remove(dbConnection, dbTransaction);

            var op_planned_action_id = op_planned_action.HEC_ACT_PlannedActionID;

            var op_planned_action_potential_procedure = ORM_HEC_ACT_PlannedAction_PotentialProcedure.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction_PotentialProcedure.Query()
            {
                PlannedAction_RefID = op_planned_action_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            op_planned_action_potential_procedure.Remove(dbConnection, dbTransaction);

            ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query()
            {
                PlannedAction_PotentialProcedure_RefID = op_planned_action_potential_procedure.HEC_ACT_PlannedAction_PotentialProcedureID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            ORM_HEC_ACT_PlannedAction_2_ActionType.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction_2_ActionType.Query()
            {
                HEC_ACT_PlannedAction_RefID = op_planned_action_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });
            #endregion

            #region Op performed action
            var op_performed_action_id = op_planned_action.IfPerformed_PerformedAction_RefID;

            ORM_HEC_ACT_PerformedAction.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction.Query()
            {
                HEC_ACT_PerformedActionID = op_performed_action_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            var op_performed_action_diagnosis_update = ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query()
            {
                HEC_ACT_PerformedAction_RefID = op_performed_action_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            op_performed_action_diagnosis_update.Remove(dbConnection, dbTransaction);

            ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query()
            {
                HEX_EXC_Action_DiagnosisUpdate_RefID = op_performed_action_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            ORM_HEC_ACT_PerformedAction_2_ActionType.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction_2_ActionType.Query()
            {
                HEC_ACT_PerformedAction_RefID = op_performed_action_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });
            #endregion

            #region Properties
            ORM_HEC_CAS_Case_UniversalPropertyValue.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
            {
                HEC_CAS_Case_RefID = case_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });
            #endregion
        }

        public void DeleteOpData(List<Guid> op_ids_to_delete, IEnumerable<Guid> all_op_ids, DbConnection dbConnection, DbTransaction dbTransaction, SessionSecurityTicket securityTicket, Guid patient_id = default(Guid), string localization = null)
        {
            var elastic_index = securityTicket.TenantID.ToString();
            var case_id_to_transfer_octs_to = all_op_ids.FirstOrDefault(t => !op_ids_to_delete.Any(x => x == t));
            var retrieved_gposes = new List<ORM_HEC_BIL_PotentialCode>();

            foreach (var case_id in op_ids_to_delete)
            {
                var op_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result.planned_action_id;
                DeleteOp(case_id, case_id_to_transfer_octs_to, retrieved_gposes, dbConnection, dbTransaction, securityTicket);
            }

            if (patient_id != Guid.Empty)
            {
                var fake_cases = cls_Get_DocumentationOnly_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GDOCIDs_1610() { PatientID = patient_id, PropertyGpmID = ECaseProperty.FakeCase.Value() }, securityTicket).Result.ToList();
                foreach (var fake_case in fake_cases)
                {
                    var fake_case_id = fake_case.case_id;
                    var fake_case_matches_localization = cls_Get_Case_Treatment_Data_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCTDfCID_1143() { CaseID = fake_case_id }, securityTicket).Result.localization == localization;
                    if (fake_case_matches_localization)
                    {
                        DeleteOp(fake_case_id, Guid.Empty, retrieved_gposes, dbConnection, dbTransaction, securityTicket);
                    }
                }

                var elasticRefresher = new ElasticRefresher(new Guid[] { patient_id }, dbConnection, dbTransaction, securityTicket);
                elasticRefresher.RebuildElastic();
            }
        }

        private void DeleteOctData(IEnumerable<DocumentationOnlyOct> octs_to_delete, Guid patient_id, string localization, DbConnection dbConnection, DbTransaction dbTransaction, SessionSecurityTicket securityTicket)
        {
            var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;
            var oct_performed_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514()
            {
                action_type_gpmid = EActionType.PerformedOct.Value()
            }, securityTicket).Result;

            foreach (var oct in octs_to_delete)
            {
                var oct_id = oct.id;

                var doctor = cls_Get_Latest_OctDoctorID_for_PatientID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_DO_GLOctDIDfPIDaLC_1939()
                {
                    LocalizationCode = localization,
                    OctPlannedActionTypeID = oct_planned_action_type_id,
                    PatientID = patient_id
                }, securityTicket).Result;
                var doctor_details = cls_Get_Doctor_BasicInformation_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDBIfDID_1034() { DoctorID = doctor.oct_doctor_id }, securityTicket).Result;

                var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(dbConnection, dbTransaction, new P_CAS_GTYL_1317() { Date = oct.date, PatientID = patient_id }, securityTicket).Result;
                var case_id = Guid.Empty;

                var oct_relevant_planned_action = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query()
                {
                    PlannedAction_RefID = oct_id,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

                case_id = oct_relevant_planned_action.Case_RefID;
                var oct_planned_action = new ORM_HEC_ACT_PlannedAction();
                oct_planned_action.Load(dbConnection, dbTransaction, oct_id);

                var oct_performed_action_id = oct_planned_action.IfPerformed_PerformedAction_RefID;

                #region Performed
                ORM_HEC_ACT_PerformedAction.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction.Query()
                {
                    HEC_ACT_PerformedActionID = oct_performed_action_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                ORM_HEC_ACT_PerformedAction_2_ActionType.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction_2_ActionType.Query()
                {
                    HEC_ACT_PerformedAction_RefID = oct_performed_action_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                var oct_performed_action_diagnosis_update = ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query()
                {
                    HEC_ACT_PerformedAction_RefID = oct_performed_action_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                oct_performed_action_diagnosis_update.Remove(dbConnection, dbTransaction);

                ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query()
                {
                    HEX_EXC_Action_DiagnosisUpdate_RefID = oct_performed_action_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });
                #endregion

                #region Billing
                var case_bill_codes = cls_Get_Case_BillCodeIDs_for_CaseID_And_GposTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GCBCIDsfCIDaGposT_1342()
                {
                    CaseID = case_id,
                    GposTypeGpmID = EGposType.Oct.Value()
                }, securityTicket).Result;

                var oct_gpos_catalog_id = ORM_HEC_BIL_PotentialCode_Catalog.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_PotentialCode_Catalog.Query()
                {
                    GlobalPropertyMatchingID = EGposType.Oct.Value(),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single().HEC_BIL_PotentialCode_CatalogID;

                var oct_relevant_planned_actions = cls_Get_RelevanActionIDs_for_CaseID_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GRAIDsfCIDaATID_1547()
                {
                    ActionTypeID = oct_planned_action_type_id,
                    CaseID = case_id
                }, securityTicket).Result;

                CAS_GCBCIDsfCIDaGposT_1342 case_bill_code = null;
                for (var i = 0; i < oct_relevant_planned_actions.Length; i++)
                {
                    var relevant_oct_action = oct_relevant_planned_actions[i];
                    if (relevant_oct_action.action_id == oct_id)
                    {
                        case_bill_code = case_bill_codes[i];
                    }
                }

                var bill_position_bill_code = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_BillPosition_BillCode.Query()
                {
                    HEC_BIL_BillPosition_BillCodeID = case_bill_code.billposition_bill_code_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                ORM_HEC_CAS_Case_BillCode.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_BillCode.Query()
                {
                    HEC_CAS_Case_BillCodeID = case_bill_code.case_bill_code_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                var hec_bill_position = ORM_HEC_BIL_BillPosition.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_BillPosition.Query()
                {
                    HEC_BIL_BillPositionID = bill_position_bill_code.BillPosition_RefID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                hec_bill_position.Remove(dbConnection, dbTransaction);

                var bill_position_id = hec_bill_position.Ext_BIL_BillPosition_RefID;

                var bill_position = ORM_BIL_BillPosition.Query.Search(dbConnection, dbTransaction, new ORM_BIL_BillPosition.Query()
                {
                    BIL_BillPositionID = bill_position_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                bill_position.Remove(dbConnection, dbTransaction);

                var bill_header_id = bill_position.BIL_BilHeader_RefID;

                ORM_BIL_BillHeader.Query.SoftDelete(dbConnection, dbTransaction, new ORM_BIL_BillHeader.Query()
                {
                    BIL_BillHeaderID = bill_header_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                ORM_HEC_BIL_BillHeader.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_BIL_BillHeader.Query()
                {
                    Ext_BIL_BillHeader_RefID = bill_header_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                ORM_BIL_BillPosition_TransmitionStatus.Query.SoftDelete(dbConnection, dbTransaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                {
                    BillPosition_RefID = bill_position_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });
                #endregion

                #region Planned
                oct_planned_action.Remove(dbConnection, dbTransaction);

                ORM_HEC_ACT_PlannedAction_2_ActionType.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction_2_ActionType.Query()
                {
                    HEC_ACT_PlannedAction_RefID = oct_id,
                    Tenant_RefID = securityTicket.TenantID
                });

                oct_relevant_planned_action.Remove(dbConnection, dbTransaction);
                #endregion
            }

        }

        private void SaveDocumentationOnlyData(DocumentationOnlyEye parameter, Guid patient_id, bool is_left_eye, string connectionString, DbConnection dbConnection, DbTransaction dbTransaction, SessionSecurityTicket securityTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { address = "none", agent = "none" };

            transaction = new TransactionalInformation();
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(dbConnection, dbTransaction, securityTicket).Result;

            var planning_service = new PlanningDataService();
            var oct_service = new OctService();
            var is_missing_ivom_review = false;

            var culture = new CultureInfo("de", true);

            parameter.octs = parameter.octs.OrderBy(t => t.date).ToList();
            parameter.ops = parameter.ops.OrderBy(t => t.date).ToList();

            var create_fake_op = !parameter.ops.Any(t => t.id != Guid.Empty) && !parameter.octs.Any(t => t.date == parameter.treatment_year_start_date) && !parameter.ops.Any(t => t.date == parameter.treatment_year_start_date);

            var op_ids = new Dictionary<Guid, List<Guid>>();
            var oct_ids = new Dictionary<Guid, List<Guid>>();

            var trigger_acc = new ORM_USR_Account();
            trigger_acc.Load(dbConnection, dbTransaction, securityTicket.AccountID);
            var all_languagesL = ORM_CMN_Language.Query.Search(dbConnection, dbTransaction, new ORM_CMN_Language.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).ToArray();
            var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(dbConnection, dbTransaction, new P_P_PA_GPDfPID_1124() { PatientID = patient_id }, securityTicket).Result;

            var localization = is_left_eye ? "L" : "R";

            if (create_fake_op)
            {
                var op = parameter.ops.First();

                var case_parameter = new Case()
                {
                    diagnose_id = op.diagnose_id,
                    drug_id = op.drug_id,
                    is_confirmed = true,
                    is_documentation_only = true,
                    is_left_eye = is_left_eye,
                    patient_id = patient_id,
                    practice_id = data.PracticeID,
                    treatment_date = parameter.treatment_year_start_date.ToString("dd.MM.yyyy"),
                    treatment_doctor_id = op.doctor.id,
                    min_delivery_date = op.date.ToString("dd.MM.yyyy")
                };

                var new_case_id = planning_service.CreateCase(case_parameter, connectionString, securityTicket.SessionTicket, out transaction, dbConnection, dbTransaction);
                cls_Save_Case_Property.Invoke(dbConnection, dbTransaction, new P_CAS_SCP_1308()
                {
                    case_id = new_case_id,
                    property_gpm_id = ECaseProperty.FakeCase.Value(),
                    property_name = "Fake treatment year case",
                    property_boolean_value = true
                }, securityTicket);

                if (!transaction.ReturnStatus)
                {
                    throw new Exception("Fake case cannot be imported.");
                }

                cls_Submit_Case.Invoke(dbConnection, dbTransaction, new P_CAS_SC_1425()
                {
                    case_ids = new Guid[] { new_case_id },
                    is_treatment = true,
                    practice_id = data.PracticeID,
                    authorizing_doctor_id = op.doctor.id
                }, securityTicket);

                var op_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GTPAfCID_0946 { CaseID = new_case_id }, securityTicket).Result.planned_action_id.ToString();
                var index_name = securityTicket.TenantID.ToString();
            }

            var documentation_only_case_ids = cls_Get_DocumentationOnly_CaseIDs_for_PatientID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_CAS_GDOCIDsfPIDaLC_1435()
            {
                PatientID = patient_id,
                CasePropertyGpmID = ECaseProperty.DocumentationOnly.Value(),
                LocalizatioNCode = localization
            }, securityTicket).Result.Select(x => x.case_id).ToArray();

            if (documentation_only_case_ids.Any())
            {
                var fake_cases = cls_Get_DocumentationOnly_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GDOCIDs_1610() { PatientID = patient_id, PropertyGpmID = ECaseProperty.FakeCase.Value() }, securityTicket).Result;
                var ops = cls_Get_Case_Treatment_Data_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GCTDfCIDs_1624() { CaseIDs = documentation_only_case_ids }, securityTicket).Result.Where(t => !fake_cases.Any(x => x.case_id == t.case_id)).ToList();
                var ops_to_delete = ops.Where(t => !parameter.ops.Any(r => r.id == t.case_id)).ToList();

                DeleteOpData(ops_to_delete.Select(t => t.case_id).ToList(), parameter.ops.Select(x => x.id).ToList(), dbConnection, dbTransaction, securityTicket);
                parameter.ops = parameter.ops.Where(x => !ops_to_delete.Any(r => r.case_id == x.id)).ToList();
            }

            var oct_doctor_id = Guid.Empty;
            foreach (var op in parameter.ops.Where(t => !t.is_regular_op))
            {
                var relevant_oct = parameter.octs.FirstOrDefault(t => t.date.Date <= op.date.Date);
                if (relevant_oct == null)
                {
                    relevant_oct = parameter.octs.LastOrDefault(t => t.date.Date > op.date.Date);
                }

                if (relevant_oct != null)
                {
                    oct_doctor_id = relevant_oct.doctor.id;
                }
                else
                {
                    oct_doctor_id = op.doctor.id;
                }

                var _case = new Case()
                {
                    diagnose_id = op.diagnose_id,
                    drug_id = op.drug_id,
                    is_confirmed = true,
                    is_documentation_only = true,
                    is_left_eye = is_left_eye,
                    oct_doctor_id = oct_doctor_id,
                    patient_id = patient_id,
                    practice_id = data.PracticeID,
                    treatment_date = op.date.ToString("dd.MM.yyyy"),
                    treatment_doctor_id = op.doctor.id,
                    min_delivery_date = op.date.ToString("dd.MM.yyyy"),
                    case_id = op.id
                };

                if (op.id != Guid.Empty)
                {
                    _case.planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GTPAfCID_0946() { CaseID = op.id }, securityTicket).Result.planned_action_id;
                }

                var new_case_id = planning_service.CreateCase(_case, connectionString, securityTicket.SessionTicket, out transaction, dbConnection, dbTransaction);

                var case_props = cls_Get_Case_Properties_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCPfCID_1204() { CaseID = new_case_id }, securityTicket).Result;
                var missing_ivom_case = case_props.SingleOrDefault(t => t.property_gpmid == ECaseProperty.MissingIvom.Value());
                if (missing_ivom_case != null)
                {
                    is_missing_ivom_review = true;

                    ORM_HEC_CAS_Case_UniversalPropertyValue.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
                    {
                        HEC_CAS_Case_UniversalPropertyValueID = missing_ivom_case.id
                    });
                }

                if (!transaction.ReturnStatus)
                {
                    throw new Exception("Documentation only case cannot be imported.");
                }

                if (op.id == Guid.Empty)
                {
                    if (!op_ids.ContainsKey(op.doctor.id))
                    {
                        op_ids.Add(op.doctor.id, new List<Guid>());
                    }

                    op_ids[op.doctor.id].Add(new_case_id);
                }
            }

            if (oct_doctor_id == Guid.Empty)
            {
                var relevant_oct = parameter.octs.FirstOrDefault(t => t.date.Date <= parameter.latest_ivom.date.Date);
                if (relevant_oct == null)
                {
                    relevant_oct = parameter.octs.LastOrDefault(t => t.date.Date > parameter.latest_ivom.date.Date);
                }

                if (relevant_oct != null)
                {
                    oct_doctor_id = relevant_oct.doctor.id;
                }
            }

            foreach (var op in op_ids)
            {
                cls_Submit_Case.Invoke(dbConnection, dbTransaction, new P_CAS_SC_1425()
                {
                    case_ids = op.Value.ToArray(),
                    is_treatment = true,
                    practice_id = data.PracticeID,
                    authorizing_doctor_id = op.Key
                }, securityTicket);
            }

            if (documentation_only_case_ids.Any() && !is_missing_ivom_review)
            {
                var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                var case_fs_statuses = cls_Get_Case_TransmitionCode_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GCTCfCIDs_1519()
                {
                    CaseID = documentation_only_case_ids
                }, securityTicket).Result.Where(t => t.fs_key == "oct").ToList();
                var all_octs = cls_Get_OctData_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GOctDfCIDs_1642() { CaseIDs = documentation_only_case_ids, ActionTypeID = oct_planned_action_type_id }, securityTicket).Result;
                var octs = new List<CAS_GOctDfCIDs_1642>();

                for (var i = 0; i < all_octs.Length; i++)
                {
                    var status = case_fs_statuses[i].fs_status;
                    if (status == 13)
                    {
                        octs.Add(all_octs[i]);
                    }
                }

                if (octs.Any())
                {
                    var octs_to_delete = octs.Where(t => !parameter.octs.Any(x => x.id == t.id)).ToList();
                    if (octs_to_delete.Any())
                    {
                        DeleteOctData(octs_to_delete.Select(t => new DocumentationOnlyOct() { id = t.id, date = t.date.ToUniversalTime() }), patient_id, localization, dbConnection, dbTransaction, securityTicket);
                        parameter.octs = parameter.octs.Where(x => !octs_to_delete.Any(r => r.id == x.id)).ToList();
                    }
                }
            }

            var open_oct = Retrieve_Octs.GetOctsWhereFieldsHaveValues(new List<FieldValueParameter>() { 
                                    new FieldValueParameter() { FieldName = "localization", FieldValue = localization},
                                    new FieldValueParameter() { FieldName = "patient_id", FieldValue = patient_id.ToString() }, 
                }, null, securityTicket.TenantID.ToString()).SingleOrDefault();

            if (open_oct == null)
            {
                var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(dbConnection, dbTransaction, new P_CAS_GDDfDID_1608() { DiagnoseID = parameter.latest_ivom.diagnose_id }, securityTicket).Result;
                var drug_details = cls_Get_Drug_Details_for_DrugID.Invoke(dbConnection, dbTransaction, new P_CAS_GDDfDID_1614() { DrugID = parameter.latest_ivom.drug_id }, securityTicket).Result;
                var oct_doctor_details = cls_Get_Doctor_BasicInformation_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDBIfDID_1034() { DoctorID = oct_doctor_id }, securityTicket).Result;
                var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDDfDID_0823() { DoctorID = parameter.latest_ivom.doctor.id }, securityTicket).Result.First();

                cls_Handle_OCT.Invoke(dbConnection, dbTransaction, new P_CAS_HOCT_1013()
                {
                    case_id = parameter.latest_ivom.id,
                    diagnose_id = parameter.latest_ivom.diagnose_id,
                    diagnose_name = diagnose_details == null ? "-" : String.Format("{0} ({1}: {2})", diagnose_details.diagnose_name, diagnose_details.catalog_display_name, diagnose_details.diagnose_icd_10),
                    drug_id = parameter.latest_ivom.drug_id,
                    localization = localization,
                    oct_doctor_id = oct_doctor_id,
                    oct_doctor_name = oct_doctor_details != null ? GenericUtils.GetDoctorName(oct_doctor_details) : "-",
                    oct_doctor_practice_id = oct_doctor_details != null ? oct_doctor_details.practice_id : Guid.Empty,
                    patient_birthdate = patient_details.birthday,
                    patient_id = patient_id,
                    patient_name = String.Format("{0}, {1}", patient_details.patient_last_name, patient_details.patient_first_name),
                    treatment_date = parameter.latest_ivom.date,
                    treatment_doctor_id = parameter.latest_ivom.doctor.id,
                    treatment_doctor_name = treatment_doctor_details != null ? GenericUtils.GetDoctorName(treatment_doctor_details) : "-",
                    treatment_doctor_practice_id = treatment_doctor_details != null ? treatment_doctor_details.practice_id : Guid.Empty,
                    treatment_doctor_practice_name = treatment_doctor_details != null ? treatment_doctor_details.practice : "-",
                    patient_hip = patient_details.health_insurance_provider,
                    is_documentation = true
                }, securityTicket);
            }

            foreach (var oct in parameter.octs)
            {
                if (oct.id == Guid.Empty)
                {
                    var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(dbConnection, dbTransaction, new P_CAS_GTYL_1317()
                    {
                        Date = oct.date,
                        PatientID = patient_id
                    }, securityTicket).Result;

                    var existing_bill_position = cls_Get_Existing_OCT_BillPosition_for_PatientID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_CAS_GEBPfPIDaLC_1803()
                    {
                        LocalizationCode = localization,
                        PatientID = patient_id
                    }, securityTicket).Result;

                    if (existing_bill_position == null)
                    {
                        throw new Exception(String.Format("Oct submission failed, patient: {0}, localization: {1}, oct date: {2} (No open bill position found)", patient_id, localization, oct.date));
                    }

                    var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;
                    var open_oct_id = cls_Get_Open_ActionID_for_CaseID_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GOAIDfCIDaATID_1547() { ActionTypeID = oct_planned_action_type_id, CaseID = existing_bill_position.CaseID }, securityTicket).Result.ActionID;

                    oct_service.SubmitOct(new List<Guid> { open_oct_id }, oct.date.ToString("dd.MM.yyyy"), oct.doctor.id, false, connectionString, securityTicket.SessionTicket, out transaction, true, dbConnection, dbTransaction);
                }
                else
                {
                    oct_service.EditOctForErrorCorrection(oct.id, oct.date.ToString("dd.MM.yyyy"), oct.doctor.id, is_left_eye, connectionString, securityTicket.SessionTicket, out transaction, dbConnection, dbTransaction);
                }

                if (!transaction.ReturnStatus)
                {
                    throw new Exception(String.Format("Oct submission failed, patient: {0}, localization: {1}, oct date: {2}", patient_id, localization, oct.date));
                }


                var elastic_type = "user_oct_";
                var last_used_practices_doctors_oct = Get_Practices_and_Doctors.Get_Last_Used_Doctors_Practices(Guid.Empty, securityTicket, elastic_type);
                var oct_doctor_details = cls_Get_Doctor_BasicInformation_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDBIfDID_1034() { DoctorID = oct.doctor.id }, securityTicket).Result;
                if (last_used_practices_doctors_oct.Count != 0)
                {
                    last_used_practices_doctors_oct = last_used_practices_doctors_oct.OrderBy(l => l.date_of_use).ToList();
                    var last_used = last_used_practices_doctors_oct.SingleOrDefault(l => l.id.ToLower() == oct.doctor.id.ToString().ToLower());
                    if (last_used != null)
                    {
                        last_used.date_of_use = DateTime.Now;
                    }
                    else
                    {
                        Practice_Doctor_Last_Used_Model practice_last_used_model = new Practice_Doctor_Last_Used_Model();
                        practice_last_used_model.id = oct.doctor.id.ToString();
                        practice_last_used_model.display_name = GenericUtils.GetDoctorName(oct_doctor_details);
                        practice_last_used_model.date_of_use = DateTime.Now;
                        practice_last_used_model.practice_id = oct_doctor_details.practice_id.ToString();

                        last_used_practices_doctors_oct.Add(practice_last_used_model);
                    }
                }
                else
                {
                    Practice_Doctor_Last_Used_Model practice_last_used_model = new Practice_Doctor_Last_Used_Model();
                    practice_last_used_model.id = oct.doctor.id.ToString();
                    practice_last_used_model.display_name = GenericUtils.GetDoctorName(oct_doctor_details);
                    practice_last_used_model.date_of_use = DateTime.Now;
                    practice_last_used_model.practice_id = oct_doctor_details.practice_id.ToString();

                    last_used_practices_doctors_oct.Add(practice_last_used_model);
                }

                Add_New_Practice_Last_Used.Import_Practice_Last_Used_Data_to_ElasticDB(last_used_practices_doctors_oct, securityTicket.TenantID.ToString(), securityTicket.AccountID.ToString(), elastic_type);

                last_used_practices_doctors_oct = Get_Practices_and_Doctors.Get_Last_Used_Doctors_Practices(Guid.Empty, securityTicket, elastic_type);

                if (last_used_practices_doctors_oct.Count > 3)
                {
                    var id_to_delete = last_used_practices_doctors_oct.OrderBy(pd => pd.date_of_use).First().id;
                    Add_New_Practice_Last_Used.Delete_Practice_Last_Used(securityTicket.TenantID.ToString(), elastic_type + securityTicket.AccountID.ToString(), id_to_delete);
                }
            }

            var elasticRefresher = new ElasticRefresher(new Guid[] { patient_id }, dbConnection, dbTransaction, securityTicket);
            elasticRefresher.RebuildElastic();
        }

        public void SaveDocumentationOnlyOpAndOctData(DocumentationOnlyOpAndOctData parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { address = "none", agent = "none" };

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            var elastic_index = securityTicket.TenantID.ToString();
            var elastic_patient_id = parameter.patient_id.ToString();

            var existing_planning = Elastic_Utils.GetDataForPatientID<Case_Model>(elastic_index, "case", elastic_patient_id).ToList();
            var existing_settlement = Elastic_Utils.GetDataForPatientID<Settlement_Model>(elastic_index, "settlement", elastic_patient_id).ToList();
            var existing_patient_details = Elastic_Utils.GetDataForPatientID<PatientDetailViewModel>(elastic_index, "patient_details", elastic_patient_id).ToList();
            var existing_treatments = Elastic_Utils.GetDataForPatientID<Submitted_Case_Model>(elastic_index, "submitted_case", elastic_patient_id).ToList();
            var existing_octs = Elastic_Utils.GetDataForPatientID<Oct_Model>(elastic_index, "oct", elastic_patient_id).ToList();

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    #region Patient consent
                    var patient_service = new PatientDataService();

                    var left_eye_treatment_year_start_date = parameter.left_eye != null ? parameter.left_eye.treatment_year_start_date : DateTime.MinValue;
                    var right_eye_treatment_year_start_date = parameter.right_eye != null ? parameter.right_eye.treatment_year_start_date : DateTime.MinValue;

                    var consent_start_date = DateTime.MinValue;
                    if (left_eye_treatment_year_start_date.Date != DateTime.MinValue.Date && right_eye_treatment_year_start_date.Date != DateTime.MinValue.Date)
                    {
                        consent_start_date = left_eye_treatment_year_start_date > right_eye_treatment_year_start_date ? right_eye_treatment_year_start_date : left_eye_treatment_year_start_date;
                    }
                    else if (left_eye_treatment_year_start_date.Date != DateTime.MinValue.Date)
                    {
                        consent_start_date = left_eye_treatment_year_start_date;
                    }
                    else
                    {
                        consent_start_date = right_eye_treatment_year_start_date;
                    }

                    var patient_hip = ORM_HEC_Patient_HealthInsurance.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Patient_HealthInsurance.Query()
                    {
                        Patient_RefID = parameter.patient_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    var oct_gpos_ids = cls_Get_GposIDs_for_GposType.Invoke(dbConnection, dbTransaction, new P_MD_GGpoIDsfGposT_1145() { GposType = EGposType.Oct.Value() }, securityTicket).Result.Select(t => t.GposID).ToArray();
                    var contract = cls_Get_Oldest_ContractID_for_HipID_and_GposIDs.Invoke(dbConnection, dbTransaction, new P_MD_GOCIDfHipIDaGposIDs_0841()
                    {
                        GposIDs = oct_gpos_ids,
                        HipID = patient_hip.HIS_HealthInsurance_Company_RefID
                    }, securityTicket).Result;

                    if (contract == null)
                    {
                        throw new ArgumentException(String.Format("OCT contract not found for patient: {0}, HIP: {1}", parameter.patient_id, patient_hip.HIS_HealthInsurance_Company_RefID));
                    }

                    var contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                    {
                        Contract_RefID = contract.contract_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });

                    var consent_valid_for_months = 12;
                    var consent_valid_for_months_parameter = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.DurationOfParticipationConsent.Value());
                    if (consent_valid_for_months_parameter != null)
                    {
                        consent_valid_for_months = Convert.ToInt32(consent_valid_for_months_parameter.IfNumericValue_Value);
                    }

                    var existing_consents = cls_Get_Patient_Consents_on_Contract_for_PatientID.Invoke(dbConnection, dbTransaction, new P_PA_GPCoCfPID_0959() { ContractID = contract.contract_id, PatientID = parameter.patient_id }, securityTicket).Result;
                    if (!existing_consents.Any(x => x.consent_valid_from <= consent_start_date && x.consent_valid_from.AddMonths(consent_valid_for_months) > consent_start_date))
                    {
                        var consent = new ParticipationConsent()
                        {
                            contract_id = contract.contract_id,
                            issue_date = consent_start_date.ToString("dd.MM.yyyy"),
                            patient_id = parameter.patient_id,
                            participation_consent_valid_days = consent_valid_for_months,
                            contract_ValidTo = consent_start_date.AddMonths(consent_valid_for_months)
                        };

                        patient_service.SaveParticipationConsent(consent, connectionString, securityTicket.SessionTicket, out transaction, dbConnection, dbTransaction);
                        if (!transaction.ReturnStatus)
                        {
                            throw new Exception("Consent creation failed");
                        }
                    }
                    #endregion

                    var existing_documentation_only_data = GetExistingDocumentationOnlyCases(parameter.patient_id, connectionString, sessionTicket, out transaction);
                    if (parameter.left_eye != null && parameter.left_eye.treatment_year_start_date.Date != DateTime.MinValue.Date)
                    {
                        SaveDocumentationOnlyData(parameter.left_eye, parameter.patient_id, true, connectionString, dbConnection, dbTransaction, securityTicket, out transaction);
                    }
                    else
                    {
                        var localization = "L";
                        var existing_eye_data = existing_documentation_only_data.left_eye;
                        if (existing_eye_data != null)
                        {
                            DeleteOpData(existing_eye_data.ops.Select(x => x.id).ToList(), new List<Guid>(), dbConnection, dbTransaction, securityTicket, parameter.patient_id, localization);
                            DeleteOctData(existing_eye_data.octs, parameter.patient_id, localization, dbConnection, dbTransaction, securityTicket);
                        }
                    }

                    if (parameter.right_eye != null && parameter.right_eye.treatment_year_start_date.Date != DateTime.MinValue.Date)
                    {
                        SaveDocumentationOnlyData(parameter.right_eye, parameter.patient_id, false, connectionString, dbConnection, dbTransaction, securityTicket, out transaction);
                    }
                    else
                    {
                        var localization = "R";
                        var existing_eye_data = existing_documentation_only_data.right_eye;
                        if (existing_eye_data != null)
                        {
                            DeleteOpData(existing_eye_data.ops.Select(x => x.id).ToList(), new List<Guid>(), dbConnection, dbTransaction, securityTicket, parameter.patient_id, localization);
                            DeleteOctData(existing_eye_data.octs, parameter.patient_id, localization, dbConnection, dbTransaction, securityTicket);
                        }
                    }

                    var elasticRefresher = new ElasticRefresher(new Guid[] { parameter.patient_id }, dbConnection, dbTransaction, securityTicket);
                    elasticRefresher.RebuildElastic();

                    dbTransaction.Commit();

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, parameter, existing_documentation_only_data, "Documentation cases and octs"), data.PracticeName);
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Elastic_Utils.DeleteDataForPatientID<Case_Model>(elastic_index, "case", elastic_patient_id);
                Elastic_Utils.DeleteDataForPatientID<Settlement_Model>(elastic_index, "settlement", elastic_patient_id);
                Elastic_Utils.DeleteDataForPatientID<Submitted_Case_Model>(elastic_index, "submitted_case", elastic_patient_id);
                Elastic_Utils.DeleteDataForPatientID<Oct_Model>(elastic_index, "oct", elastic_patient_id);
                Elastic_Utils.DeleteDataForPatientID<PatientDetailViewModel>(elastic_index, "patient_details", elastic_patient_id, new string[] { "op", "oct" });

                if (existing_planning.Any())
                {
                    Add_New_Case.Import_Case_Data_to_ElasticDB(existing_planning, elastic_index);
                }

                if (existing_settlement.Any())
                {
                    Add_new_Settlement.Import_Settlement_to_ElasticDB(existing_settlement, elastic_index);
                }

                if (existing_treatments.Any())
                {
                    Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(existing_treatments, elastic_index);
                }

                if (existing_octs.Any())
                {
                    Add_New_Oct.Import_Oct_Data_to_ElasticDB(existing_octs, elastic_index);
                }

                if (existing_patient_details.Any())
                {
                    Add_New_Patient.ImportPatientDetailsToElastic(existing_patient_details, elastic_index);
                }

                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
        }
    }
}
