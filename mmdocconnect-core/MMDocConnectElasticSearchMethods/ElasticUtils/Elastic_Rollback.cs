using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Order.Retrieval;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectUtils;
using Newtonsoft.Json.Linq;
using PlainElastic.Net;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace MMDocConnectElasticSearchMethods
{
    public static class Elastic_Rollback
    {
        public static void InsertDataIntoElastic(IEnumerable<IEnumerable<IElasticMapper>> data, string index_name)
        {
            foreach (var data_list in data)
            {
                if (data_list.Any())
                {
                    switch (data_list.First().GetType().Name)
                    {
                        case "Case_Model": Add_New_Case.Import_Case_Data_to_ElasticDB(data_list.Cast<Case_Model>().ToList(), index_name); break;
                        case "Aftercare_Model": Add_New_Aftercare.Import_Aftercare_Data_to_ElasticDB(data_list.Cast<Aftercare_Model>().ToList(), index_name); break;
                        case "Settlement_Model": Add_new_Settlement.Import_Settlement_to_ElasticDB(data_list.Cast<Settlement_Model>().ToList(), index_name); break;
                        case "Order_Model": Add_New_Order.Import_Order_Data_to_ElasticDB(data_list.Cast<Order_Model>().ToList(), index_name); break;
                        case "Patient_Model": Add_New_Patient.Import_Patients_to_ElasticDB(data_list.Cast<Patient_Model>().ToList(), index_name); break;
                        case "Submitted_Case_Model": Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(data_list.Cast<Submitted_Case_Model>().ToList(), index_name); break;
                        case "PatientDetailViewModel": Add_New_Patient.ImportPatientDetailsToElastic(data_list.Cast<PatientDetailViewModel>().ToList(), index_name); break;
                        case "Oct_Model": Add_New_Oct.Import_Oct_Data_to_ElasticDB(data_list.Cast<Oct_Model>().ToList(), index_name); break;
                        default: break;
                    }
                }
            }
        }

        public static void UpdateAftercareDoctor(List<Practice_Doctor_Last_Used_Model> data, string index_name, string account_id, string elastic_type)
        {
            if (data.Any())
            {
                Add_New_Practice_Last_Used.Import_Practice_Last_Used_Data_to_ElasticDB(data, index_name, account_id, elastic_type);
            }
        }

        public static IEnumerable<IEnumerable<IElasticMapper>> GetBackup(string index_name, string id, string ordinal)
        {

            var cases_aftercares_query_parameters = new List<Query_Object>();
            var treatments_orders_query_parameters = new List<Query_Object>();
            var patients_query_parameters = new List<Query_Object>();

            switch (ordinal)
            {
                case "doctor":
                    cases_aftercares_query_parameters.Add(
                        new Query_Object()
                        {
                            field = "treatment_doctor_id",
                            value = id
                        });

                    cases_aftercares_query_parameters.Add(
                    new Query_Object()
                    {
                        field = "aftercare_doctor_practice_id",
                        value = id
                    });

                    treatments_orders_query_parameters.Add(
                       new Query_Object()
                       {
                           field = "doctor_id",
                           value = id
                       });

                    patients_query_parameters.Add(
                        new Query_Object()
                        {
                            field = "op_doctor_id",
                            value = id
                        });

                    patients_query_parameters.Add(
                        new Query_Object()
                        {
                            field = "ac_doctor_practice_id",
                            value = id
                        });
                    break;
                case "practice":
                    cases_aftercares_query_parameters.Add(
                    new Query_Object()
                    {
                        field = "aftercare_doctors_practice_id",
                        value = id
                    });

                    cases_aftercares_query_parameters.Add(
                    new Query_Object()
                    {
                        field = "aftercare_doctor_practice_id",
                        value = id
                    });

                    treatments_orders_query_parameters.Add(
                    new Query_Object()
                    {
                        field = "practice_id",
                        value = id
                    });

                    patients_query_parameters.Add(
                    new Query_Object()
                    {
                        field = "practice_id",
                        value = id
                    });

                    patients_query_parameters.Add(
                    new Query_Object()
                    {
                        field = "ac_practice_id",
                        value = id
                    });

                    break;
                case "patient":
                    cases_aftercares_query_parameters.Add(
                    new Query_Object()
                    {
                        field = "patient_id",
                        value = id
                    });

                    patients_query_parameters = treatments_orders_query_parameters = cases_aftercares_query_parameters;

                    break;
                case "drug":
                    cases_aftercares_query_parameters.Add(
                    new Query_Object()
                    {
                        field = "drug_id",
                        value = id
                    });

                    patients_query_parameters = treatments_orders_query_parameters = cases_aftercares_query_parameters;

                    break;
                case "diagnose":
                    cases_aftercares_query_parameters.Add(
                    new Query_Object()
                    {
                        field = "diagnose_id",
                        value = id
                    });

                    patients_query_parameters = treatments_orders_query_parameters = cases_aftercares_query_parameters;

                    break;
                default:
                    return new List<List<IElasticMapper>>();
            }

            var cases_backup = Get_Cases.GetCasesForRollback<Case_Model>(cases_aftercares_query_parameters, index_name, "case").ToList();

            var aftercares_backup = Get_Cases.GetCasesForRollback<Aftercare_Model>(cases_aftercares_query_parameters, index_name, "aftercare").ToList();

            var settlements_backup = Get_Cases.GetCasesForRollback<Settlement_Model>(cases_aftercares_query_parameters, index_name, "settlement").ToList();

            var treatments_backup = Get_Cases.GetCasesForRollback<Submitted_Case_Model>(treatments_orders_query_parameters, index_name, "submitted_case").ToList();

            var orders_backup = Get_Cases.GetCasesForRollback<Order_Model>(treatments_orders_query_parameters, index_name, "order").ToList();

            var patients_backup = Get_Cases.GetCasesForRollback<Patient_Model>(patients_query_parameters, index_name, "patient").ToList();

            var patients_details_backup = Get_Cases.GetCasesForRollback<PatientDetailViewModel>(cases_aftercares_query_parameters, index_name, "patient_details");

            var octs_backup = Get_Cases.GetCasesForRollback<Oct_Model>(cases_aftercares_query_parameters, index_name, "oct");

            return new List<IEnumerable<IElasticMapper>>() { cases_backup, aftercares_backup, settlements_backup, treatments_backup, orders_backup, patients_backup, patients_details_backup, octs_backup };
        }

        public static IEnumerable<IEnumerable<IElasticMapper>> GetUpdatedData(string index_name, string id, string type, string[] values)
        {
            var planning_cases = new List<Case_Model>();
            var open_aftercares = new List<Aftercare_Model>();
            var error_correction_settlements = new List<Settlement_Model>();
            var error_correction_treatments = new List<Submitted_Case_Model>();
            var patients = new List<Patient_Model>();
            var patient_details = new List<PatientDetailViewModel>();
            var orders = new List<Order_Model>();
            var octs = new List<Oct_Model>();

            switch (type)
            {
                case "doctor":

                    #region UPDATE PLANNING CASES
                    var cases_from_elastic = Get_Cases.GetCasesWhereIDPresent<Case_Model>(id, "treatment_doctor_id", index_name, "case");
                    if (cases_from_elastic.Any())
                    {
                        planning_cases = cases_from_elastic.Select(cas =>
                        {
                            cas.treatment_doctor_name = values[0];
                            cas.treatment_doctor_lanr = values[1];

                            return cas;
                        }).ToList();
                    }

                    cases_from_elastic = Get_Cases.GetCasesWhereIDPresent<Case_Model>(id, "aftercare_doctor_practice_id", index_name, "case");
                    if (cases_from_elastic.Any())
                    {
                        planning_cases.AddRange(cases_from_elastic.Select(cas =>
                        {

                            planning_cases.RemoveAll(pc => pc.id == cas.id);

                            cas.treatment_doctor_name = values[0];
                            cas.treatment_doctor_lanr = values[1];


                            cas.aftercare_name = values[0];
                            cas.aftercare_doctor_lanr = values[1];

                            return cas;
                        }).ToList());
                    }
                    #endregion

                    #region UPDATE AFTERCARES
                    var aftercares_from_elastic = Get_Cases.GetCasesWhereIDPresent<Aftercare_Model>(id, "treatment_doctor_id", index_name, "aftercare");
                    if (aftercares_from_elastic.Any())
                    {
                        open_aftercares = aftercares_from_elastic.Select(ac =>
                        {
                            ac.treatment_doctor_name = values[0];
                            ac.op_lanr = values[1];

                            return ac;
                        }).ToList();
                    }

                    aftercares_from_elastic = Get_Cases.GetCasesWhereIDPresent<Aftercare_Model>(id, "aftercare_doctor_practice_id", index_name, "aftercare");
                    if (aftercares_from_elastic.Any())
                    {
                        open_aftercares.AddRange(aftercares_from_elastic.Select(ac =>
                        {

                            open_aftercares.RemoveAll(oac => oac.id == ac.id);

                            ac.treatment_doctor_name = values[0];
                            ac.ac_lanr = values[1];


                            ac.aftercare_doctor_name = values[0];

                            return ac;
                        }).ToList());
                    }
                    #endregion

                    #region UPDATE SETTLEMENTS IN ERROR CORRECTION
                    var settlements_from_elastic = Get_Settlement.GetCasesWhereIDPresent(id, "treatment_doctor_id", index_name, "op");
                    if (settlements_from_elastic.Any())
                    {
                        error_correction_settlements = settlements_from_elastic.Select(cas =>
                        {
                            cas.doctor = values[0];
                            cas.lanr = values[1];

                            return cas;
                        }).ToList();
                    }

                    settlements_from_elastic = Get_Settlement.GetCasesWhereIDPresent(id, "aftercare_doctor_practice_id", index_name, "ac");
                    if (settlements_from_elastic.Any())
                    {
                        error_correction_settlements.AddRange(settlements_from_elastic.Select(cas =>
                        {

                            error_correction_settlements.RemoveAll(ecs => ecs.id == cas.id);

                            cas.doctor = values[0];
                            cas.lanr = values[1];


                            cas.doctor = values[0];
                            cas.lanr = values[1];

                            return cas;
                        }).ToList());
                    }
                    #endregion

                    #region UPDATE MM TREATMENTS IN ERROR CORRECTION
                    var treatments_from_elastic = Get_Cases.GetSubmittedCasesInErrorCorrectionAndWhereIDPresent(id, "doctor_id", index_name, "op");
                    if (treatments_from_elastic.Any())
                    {
                        error_correction_treatments = treatments_from_elastic.Select(cas =>
                        {
                            cas.doctor_name = values[0];
                            cas.doctor_lanr = values[1];

                            return cas;
                        }).ToList();
                    }

                    treatments_from_elastic = Get_Cases.GetSubmittedCasesInErrorCorrectionAndWhereIDPresent(id, "doctor_id", index_name, "ac");
                    if (treatments_from_elastic.Any())
                    {
                        error_correction_treatments.AddRange(treatments_from_elastic.Select(cas =>
                        {

                            error_correction_treatments.RemoveAll(ect => ect.id == cas.id);

                            cas.doctor_name = values[0];
                            cas.doctor_lanr = values[1];


                            cas.doctor_name = values[0];
                            cas.doctor_lanr = values[1];

                            return cas;
                        }).ToList());
                    }
                    #endregion

                    #region UPDATE ORDERS
                    var orders_from_elastic = Get_Orders.GetOrdersWhereForIdAndOrdinal(id, "doctor_id", index_name);
                    if (orders_from_elastic.Any())
                    {
                        orders = orders_from_elastic.Select(ord =>
                        {
                            ord.treatment_doctor_name = values[0];
                            ord.lanr = values[1];

                            return ord;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE PATIENTS
                    var patients_from_elastic = Retrieve_Patients.GetPatientsWhereIDPresent(id, "op_doctor_id", index_name);
                    if (patients_from_elastic.Any())
                    {
                        patients = patients_from_elastic.Select(patient =>
                        {
                            patient.last_first_op_doctor_name = values[0];
                            patient.op_doctor_lanr = values[1];

                            return patient;
                        }).ToList();
                    }

                    patients_from_elastic = Retrieve_Patients.GetPatientsWhereIDPresent(id, "ac_doctor_id", index_name);
                    if (patients_from_elastic.Any())
                    {
                        patients.AddRange(patients_from_elastic.Select(patient =>
                        {
                            patients.RemoveAll(pat => pat.id == patient.id);

                            patient.last_first_op_doctor_name = values[0];
                            patient.op_doctor_lanr = values[1];
                            patient.last_first_ac_doctor_name = values[0];
                            patient.ac_doctor_lanr = values[1];

                            return patient;
                        }).ToList());
                    }
                    #endregion

                    #region UPDATE PATIENT DETAILS
                    var patients_details_from_elastic = Retrieve_Patients.GetPatientDetailsForIdAndOrdinal(id, "treatment_doctor_id", index_name);
                    if (patients_details_from_elastic.Any())
                    {
                        patient_details = patients_details_from_elastic.Select(patient =>
                        {
                            patient.doctor = values[0];

                            return patient;
                        }).ToList();
                    }

                    patients_details_from_elastic = Retrieve_Patients.GetPatientDetailsForIdAndOrdinal(id, "aftercare_doctor_practice_id", index_name);
                    if (patients_details_from_elastic.Any())
                    {
                        patient_details.AddRange(patients_details_from_elastic.Select(patient =>
                        {
                            patient.doctor = values[0];

                            return patient;
                        }).ToList());
                    }
                    #endregion

                    #region UPDATE OCT

                    octs.AddRange(Retrieve_Octs.GetOctsWhereFieldsHaveValues(new List<FieldValueParameter>() 
                    { 
                        new FieldValueParameter() { FieldName = "oct_doctor_id", FieldValue = id },
                        new FieldValueParameter() { FieldName = "treatment_doctor_id", FieldValue = id, Negation = true }
                    }, null, index_name)
                        .Select(t =>
                        {
                            t.oct_doctor_name = values[0];

                            return t;
                        }).ToList());

                    octs.AddRange(Retrieve_Octs.GetOctsWhereFieldsHaveValues(new List<FieldValueParameter>() 
                    { 
                        new FieldValueParameter() { FieldName = "treatment_doctor_id", FieldValue = id },
                        new FieldValueParameter() { FieldName = "oct_doctor_id", FieldValue = id, Negation = true }
                    }, null, index_name)
                     .Select(t =>
                     {
                         t.treatment_doctor_name = values[0];

                         return t;
                     }).ToList());

                    octs.AddRange(Retrieve_Octs.GetOctsWhereFieldsHaveValues(new List<FieldValueParameter>() 
                    { 
                        new FieldValueParameter() { FieldName = "treatment_doctor_id", FieldValue = id },
                        new FieldValueParameter() { FieldName = "oct_doctor_id", FieldValue = id }
                    }, null, index_name)
                      .Select(t =>
                      {
                          t.oct_doctor_name = values[0];
                          t.treatment_doctor_name = values[0];

                          return t;
                      }).ToList());

                    #endregion

                    #region UPDATE AC DOCTORS
                    var types = Elastic_Utils.GetAllTypes(index_name);

                    HashSet<string> last_used_types = new HashSet<string>();

                    var newTypes = types.Replace(index_name, "allData");
                    dynamic data = JObject.Parse(newTypes);
                    var mappings = data.allData.mappings;
                    var neededLength = Guid.Empty.ToString().Length + 5;
                    var elasticType = "user_";

                    foreach (var acType in mappings)
                    {
                        if (acType.Name.Contains(elasticType) && acType.Name.Length == neededLength)
                        {
                            var dataForType = Get_Practices_and_Doctors.GetACDoctorsWhereIDPresent(id, "id", index_name, acType.Name);

                            foreach (var acDoc in dataForType)
                            {
                                acDoc.display_name = String.Format("{0} ({1})", values[0], values[1]);
                            }

                            var accountID = acType.Name.Split(new string[] { elasticType }, StringSplitOptions.None)[1];
                            UpdateAftercareDoctor(dataForType, index_name, accountID, elasticType);

                        }
                    };
                    #endregion

                    break;

                case "practice":

                    #region UPDATE PLANNING CASES
                    var practice_cases_from_elastic = Get_Cases.GetCasesWhereIDPresent<Case_Model>(id, "aftercare_doctors_practice_id", index_name, "case");
                    if (practice_cases_from_elastic.Any())
                    {
                        planning_cases = practice_cases_from_elastic.Select(cas =>
                        {
                            cas.aftercare_doctors_practice_name = values[0];
                            cas.aftercare_practice_bsnr = values[1];

                            return cas;
                        }).ToList();
                    }

                    practice_cases_from_elastic = Get_Cases.GetCasesWhereIDPresent<Case_Model>(id, "aftercare_doctor_practice_id", index_name, "case");
                    if (practice_cases_from_elastic.Any())
                    {
                        planning_cases.AddRange(practice_cases_from_elastic.Select(cas =>
                        {

                            planning_cases.RemoveAll(pc => pc.id == cas.id);

                            cas.aftercare_doctors_practice_name = values[0];
                            cas.aftercare_practice_bsnr = values[1];


                            cas.aftercare_name = values[0];
                            cas.aftercare_practice_bsnr = values[1];

                            return cas;
                        }).ToList());
                    }
                    #endregion

                    #region UPDATE AFTERCARES
                    var practice_aftercares_from_elastic = Get_Cases.GetCasesWhereIDPresent<Aftercare_Model>(id, "treatment_doctors_practice_id", index_name, "aftercare");
                    if (practice_aftercares_from_elastic.Any())
                    {
                        open_aftercares = practice_aftercares_from_elastic.Select(ac =>
                        {
                            ac.treatment_doctor_practice_name = values[0];
                            ac.bsnr = values[1];

                            return ac;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE MM TREATMENTS IN ERROR CORRECTION
                    var practice_treatments_from_elastic = Get_Cases.GetSubmittedCasesInErrorCorrectionAndWhereIDPresent(id, "practice_id", index_name);
                    if (practice_treatments_from_elastic.Any())
                    {
                        error_correction_treatments = practice_treatments_from_elastic.Select(cas =>
                        {
                            cas.practice_name = values[0];
                            cas.practice_bsnr = values[1];

                            return cas;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE ORDERS
                    var practice_orders_from_elastic = Get_Orders.GetOrdersWhereIDPresent(id, "practice_id", index_name);
                    if (practice_orders_from_elastic.Any())
                    {
                        orders = practice_orders_from_elastic.Select(ord =>
                        {
                            ord.treatment_doctor_practice_name = values[0];
                            ord.bsnr = values[1];

                            return ord;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE PATIENTS
                    var pratice_patients_from_elastic = Retrieve_Patients.GetPatientsWhereIDPresent(id, "practice_id", index_name);
                    if (pratice_patients_from_elastic.Any())
                    {
                        patients = pratice_patients_from_elastic.Select(patient =>
                        {
                            patient.practice = values[0];
                            patient.practice_bsnr = values[1];

                            return patient;
                        }).ToList();
                    }

                    pratice_patients_from_elastic = Retrieve_Patients.GetPatientsWhereIDPresent(id, "ac_practice_id", index_name);
                    if (pratice_patients_from_elastic.Any())
                    {
                        patients.AddRange(pratice_patients_from_elastic.Select(patient =>
                        {

                            patients.RemoveAll(pat => pat.id == patient.id);

                            patient.practice = values[0];
                            patient.practice_bsnr = values[1];


                            patient.ac_practice = values[0];
                            patient.ac_practice_bsnr = values[1];

                            return patient;
                        }).ToList());
                    }
                    #endregion

                    break;
                case "patient":
                    IFormatProvider culture = new System.Globalization.CultureInfo("de", true);

                    #region UPDATE PLANNING CASES
                    var patient_cases_from_elastic = Get_Cases.GetCasesWhereIDPresent<Case_Model>(id, "patient_id", index_name, "case");
                    if (patient_cases_from_elastic.Any())
                    {
                        planning_cases = patient_cases_from_elastic.Select(cas =>
                        {
                            cas.patient_name = values[0];
                            cas.patient_insurance_number = values[1];
                            cas.patient_birthdate = DateTime.Parse(values[2], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                            cas.patient_birthdate_string = values[2];

                            return cas;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE AFTERCARES
                    var patient_aftercares_from_elastic = Get_Cases.GetCasesWhereIDPresent<Aftercare_Model>(id, "patient_id", index_name, "aftercare");
                    if (patient_aftercares_from_elastic.Any())
                    {
                        open_aftercares = patient_aftercares_from_elastic.Select(ac =>
                        {
                            ac.patient_name = values[0];
                            ac.patient_insurance_number = values[1];
                            ac.patient_birthdate = DateTime.Parse(values[2], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                            ac.patient_birthdate_string = values[2];

                            return ac;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE SETTLEMENTS IN ERROR CORRECTION
                    var patient_settlements_from_elastic = Get_Settlement.GetCasesWhereIDPresent(id, "patient_id", index_name);
                    if (patient_settlements_from_elastic.Any())
                    {
                        error_correction_settlements = patient_settlements_from_elastic.Select(cas =>
                        {
                            cas.patient_full_name = values[0];
                            cas.patient_insurance_number = values[1];
                            cas.birthday = values[2];

                            return cas;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE MM TREATMENTS IN ERROR CORRECTION
                    var patient_treatments_from_elastic = Get_Cases.GetSubmittedCasesInErrorCorrectionAndWhereIDPresent(id, "patient_id", index_name);
                    if (patient_treatments_from_elastic.Any())
                    {
                        error_correction_treatments = patient_treatments_from_elastic.Select(cas =>
                        {
                            cas.patient_name = values[0];
                            cas.patient_insurance_number = values[1];
                            cas.patient_birthdate = DateTime.Parse(values[2], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                            cas.patient_birthdate_string = values[2];

                            return cas;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE ORDERS
                    var patient_orders_from_elastic = Get_Orders.GetOrdersWhereIDPresent(id, "patient_id", index_name);
                    if (patient_orders_from_elastic.Any())
                    {
                        orders = patient_orders_from_elastic.Select(ord =>
                        {
                            ord.patient_name = values[0];
                            ord.patient_insurance_number = values[1];
                            ord.patient_birthdate = DateTime.Parse(values[2], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                            ord.patient_birthdate_string = values[2];

                            return ord;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE OCT
                    octs = Retrieve_Octs.GetOctsWhereFieldsHaveValues(new List<FieldValueParameter>() 
                    { 
                        new FieldValueParameter() { FieldName = "patient_id", FieldValue = id },
                        new FieldValueParameter() { FieldName = "status.lower_case_sort", FieldValue = "oct1" },
                    }, null, index_name)
                        .Select(t =>
                        {
                            t.patient_name = values[0];
                            t.patient_insurance_number = values[1];
                            t.patient_birthdate = DateTime.Parse(values[2], culture, System.Globalization.DateTimeStyles.AssumeLocal);

                            return t;
                        }).ToList();
                    #endregion

                    break;

                case "drug":

                    #region UPDATE PLANNING CASES
                    var drug_cases_from_elastic = Get_Cases.GetCasesWhereIDPresent<Case_Model>(id, "drug_id", index_name, "case");
                    if (drug_cases_from_elastic.Any())
                    {
                        planning_cases = drug_cases_from_elastic.Select(cas =>
                        {
                            cas.drug = values[0];

                            return cas;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE SETTLEMENTS IN ERROR CORRECTION
                    var drug_settlements_from_elastic = Get_Settlement.GetCasesWhereIDPresent(id, "drug_id", index_name);
                    if (drug_settlements_from_elastic.Any())
                    {
                        error_correction_settlements = drug_settlements_from_elastic.Select(cas =>
                        {
                            cas.drug = values[0];

                            return cas;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE MM TREATMENTS IN ERROR CORRECTION
                    var drug_treatments_from_elastic = Get_Cases.GetSubmittedCasesInErrorCorrectionAndWhereIDPresent(id, "drug_id", index_name);
                    if (drug_treatments_from_elastic.Any())
                    {
                        error_correction_treatments = drug_treatments_from_elastic.Select(cas =>
                        {
                            cas.drug = values[0];

                            return cas;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE ORDERS
                    var drug_orders_from_elastic = Get_Orders.GetOrdersWhereIDPresent(id, "drug_id", index_name);
                    if (drug_orders_from_elastic.Any())
                    {
                        orders = drug_orders_from_elastic.Select(ord =>
                        {
                            ord.drug = values[0];

                            return ord;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE PATIENT DETAILS
                    var drug_patients_details_from_elastic = Retrieve_Patients.GetPatientDetailsWhereIDPresent(id, "drug_id", index_name);
                    if (drug_patients_details_from_elastic.Any())
                    {
                        patient_details = drug_patients_details_from_elastic.Select(patient =>
                        {
                            patient.drug = values[0];
                            if (patient.detail_type == "order")
                                patient.diagnose_or_medication = values[0];

                            return patient;
                        }).ToList();
                    }
                    #endregion

                    break;
                case "diagnose":

                    #region UPDATE PLANNING CASES
                    var diagnose_cases_from_elastic = Get_Cases.GetCasesWhereIDPresent<Case_Model>(id, "diagnose_id", index_name, "case");
                    if (diagnose_cases_from_elastic.Any())
                    {
                        planning_cases = diagnose_cases_from_elastic.Select(cas =>
                        {
                            cas.diagnose = values[0];

                            return cas;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE SETTLEMENTS IN ERROR CORRECTION
                    var diagnose_settlements_from_elastic = Get_Settlement.GetCasesWhereIDPresent(id, "diagnose_id", index_name);
                    if (diagnose_settlements_from_elastic.Any())
                    {
                        error_correction_settlements = diagnose_settlements_from_elastic.Select(cas =>
                        {
                            cas.diagnose = values[0];

                            return cas;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE MM TREATMENTS IN ERROR CORRECTION
                    var diagnose_treatments_from_elastic = Get_Cases.GetSubmittedCasesInErrorCorrectionAndWhereIDPresent(id, "diagnose_id", index_name);
                    if (diagnose_treatments_from_elastic.Any())
                    {
                        error_correction_treatments = diagnose_treatments_from_elastic.Select(cas =>
                        {
                            cas.diagnose = values[0];

                            return cas;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE ORDERS
                    var diagnose_orders_from_elastic = Get_Orders.GetOrdersWhereIDPresent(id, "diagnose_id", index_name);
                    if (diagnose_orders_from_elastic.Any())
                    {
                        orders = diagnose_orders_from_elastic.Select(ord =>
                        {
                            ord.diagnose = values[0];

                            return ord;
                        }).ToList();
                    }
                    #endregion

                    #region UPDATE PATIENT DETAILS
                    var diagnose_patients_details_from_elastic = Retrieve_Patients.GetPatientDetailsWhereIDPresent(id, "diagnose_id", index_name);
                    if (diagnose_patients_details_from_elastic.Any())
                    {
                        patient_details = diagnose_patients_details_from_elastic.Select(patient =>
                        {
                            if (patient.detail_type == "op" || patient.detail_type == "ac")
                                patient.diagnose_or_medication = values[0];

                            return patient;
                        }).ToList();
                    }
                    #endregion

                    break;
                default:
                    break;
            }

            return new List<IEnumerable<IElasticMapper>>() 
            {
                planning_cases, 
                open_aftercares,
                error_correction_settlements, 
                error_correction_treatments, 
                orders, 
                patients,
                patient_details,
                octs
            };

        }
    }
}
