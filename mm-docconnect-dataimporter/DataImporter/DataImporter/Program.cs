using BOp.Providers;
using BOp.Providers.TMS.Requests;
using CL1_BIL;
using CL1_CMN;
using CL1_HEC;
using CL1_HEC_ACT;
using CL1_HEC_BIL;
using CL1_HEC_CAS;
using CL1_HEC_CRT;
using CL1_HEC_DIA;
using CL1_HEC_TRE;
using CL1_ORD_PRC;
using CSV2Core.SessionSecurity;
using CSV2Core_MySQL.Support;
using DataImporter.DBMethods.Case.Atomic.Manipulation;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using DataImporter.DBMethods.Case.Complex.Retrieval;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.DBMethods.Order.Atomic.Retrieval;
using DataImporter.DBMethods.Patient.Atomic.Retrieval;
using DataImporter.Elastic_Methods.Doctor.Manipulation;
using DataImporter.Elastic_test.Model;
using DataImporter.Methods;
using DataImporter.Methods.Contracts_and_Gposes;
using DataImporter.Methods.Help_Methods;
using DataImporter.Methods.Import_Data_from_xls;
using DataImporter.Methods.Patient_Methods;
using DataImporter.Models;
using MMDocConnectElasticSearchMethods;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using PlainElastic.Net;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Threading;

namespace DataImporter
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            var title = "*** Medios Connect Data-Importer v197 ***";

            Console.WriteLine(title);

            var connectionString = ConfigurationManager.AppSettings["connectionString"];
            var connection = Elastic_Utils.ElsaticConnection();
            var securityTicket = new SessionSecurityTicket();
            // securityTicket.TenantID = Guid.Parse("6bb8c93c-40f3-4670-9697-7ddb940a51e1");
            // x'3cc9b86bf340704696977ddb940a51e1'
            var _sessionProvider = ProviderFactory.Instance.CreateSessionServiceProvider();

            var command = "";
            var logged_in_as = "";

            var logmail = ConfigurationManager.AppSettings["username"];
            var pass = ConfigurationManager.AppSettings["password"];

            var session = _sessionProvider.SignIn(logmail, pass);

            securityTicket.SessionTicket = session.SessionToken;
            securityTicket.AccountID = session.AccountID;
            securityTicket.TenantID = session.TenantID;
            logged_in_as = logmail;

            if (args.Any())
            {
                foreach (var arg in args)
                {
                    switch (arg)
                    {
                        case "3.1": Command31(connectionString, securityTicket, connection); break;
                        case "3.2": Command32(connectionString, securityTicket, connection); break;
                        case "3.3": Command33(connectionString, securityTicket, connection); break;
                        case "3.4": Command34(connectionString, securityTicket, connection); break;
                        case "3.5": Command35(connectionString, securityTicket, connection); break;
                        case "3.6": Command36(connectionString, securityTicket, connection); break;
                        case "3.7": Command37(connectionString, securityTicket, connection); break;
                        case "3.8": Command38(connectionString, securityTicket, connection); break;
                        case "3.9": Command39(connectionString, securityTicket, connection); break;
                        case "3.10": Command310(connectionString, securityTicket, connection); break;
                        case "3.11": Command311(connectionString, securityTicket, connection); break;

                        default: continue;
                    }
                }
            }
            else
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine(title);
                    Console.WriteLine("Successfully logged in as: {0}", logged_in_as);
                    Console.WriteLine();
                    Console.WriteLine("1. Initial setup for new tenant.");
                    Console.WriteLine("2. Import data from excel files.");
                    Console.WriteLine("3. Elastic rebuild.");
                    Console.WriteLine("4. Fix data in the database.");
                    Console.WriteLine("5. Set password to all users.");
                    Console.WriteLine("9. System (Olaf)");
                    Console.WriteLine("0. Exit.");
                    Console.WriteLine();

                    if (command == "1")
                    {
                        Console.WriteLine("*** Command [{0}] status  ***", command);
                        Console.WriteLine("Command executed.");
                        Console.WriteLine();
                    }

                    Console.WriteLine("Enter command: ");
                    command = Console.ReadLine();

                    switch (command)
                    {
                        #region COMMAND 1
                        case "1":
                            Setup_for_Tenant.Setup_for_new_Tenant(connectionString, securityTicket);
                            break;

                        #endregion

                        #region COMMAND 2
                        case "2":
                            var cmd2innerCommand = "";
                            do
                            {
                                Console.Clear();
                                Console.WriteLine(title);
                                Console.WriteLine("Successfully logged in as: {0}", logged_in_as);
                                Console.WriteLine();
                                Console.WriteLine("1. Import practices to DB. ");
                                Console.WriteLine("2. Import doctors to DB. ");
                                Console.WriteLine("3. Import patients to DB. ");
                                Console.WriteLine("4. Import BIC / IBAN codes. ");
                                Console.WriteLine("5. Import cases. ");
                                Console.WriteLine("6. Import diagnoses. ");
                                Console.WriteLine("7. Import HIPs. ");
                                Console.WriteLine("8. Import patient consents (replace existing consents). ");
                                Console.WriteLine("0. Return to previous screen.");
                                Console.WriteLine();

                                if (cmd2innerCommand != "")
                                {
                                    Console.WriteLine("*** Command [{0}] status ***", cmd2innerCommand);
                                    Console.WriteLine("Command executed.");
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Enter command: ");
                                cmd2innerCommand = Console.ReadLine();

                                switch (cmd2innerCommand)
                                {
                                    #region PRACTICES
                                    case "1":
                                        {
                                            Console.WriteLine("Importing practices, data validation and importing data to DB ");
                                            import_Practice_from_excel.import_Practice_from_xls(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region DOCTORS
                                    case "2":
                                        {
                                            Console.WriteLine("Importing doctors, data validation and importing data to DB ");
                                            Import_Doctors_From_Excel.Import_Doctors_from_xls(connectionString, securityTicket);
                                            break;
                                        }
                                    #endregion

                                    #region PATIENTS
                                    case "3":
                                        {
                                            Console.WriteLine("Create default participation consents? [y/n]");

                                            var create_consents = Console.ReadLine().ToLower() == "y";
                                            Console.WriteLine("Importing patients, data validation and importing data to DB ");
                                            Import_Patients_From_Excel.Import_Patients_from_xls(create_consents, connectionString, securityTicket);
                                            break;
                                        }
                                    #endregion

                                    #region BIC / IBAn
                                    case "4":
                                        {
                                            Iban_Bic_Codes_and_Bank_Name_Import.ImportCodes_to_ElasticDB();
                                        }
                                        break;
                                    #endregion

                                    #region CASES
                                    case "5":
                                        Import_Cases_From_Excel.Import_Cases(connectionString, securityTicket);
                                        break;
                                    #endregion

                                    #region DIAGNOSES
                                    case "6":
                                        Import_Diagnoses_From_Excel.Import_Diagnoses(connectionString, securityTicket);
                                        break;
                                    #endregion

                                    #region HIPS
                                    case "7":
                                        Import_HIPs_From_Excel.Import_HIPs(connectionString, securityTicket);
                                        break;
                                    #endregion

                                    #region PARTIICPATION CONSENTS
                                    case "8":
                                        Import_Participation_Consents_From_Excel.Import_Consents(connectionString, securityTicket);

                                        var patientDetails = PatientMethods.RebuildPatientDetails(connectionString, securityTicket);
                                        if (patientDetails.Count() != 0)
                                        {
                                            if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/patient_details", connection))
                                            {
                                                Console.WriteLine("Deleting patient details section on elastic...");
                                                Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "patient_details");
                                            }

                                            Console.WriteLine("Importing new data to elastic...");
                                            Add_New_Patient.ImportPatientDetailsToElastic(patientDetails, securityTicket.TenantID.ToString());
                                        }
                                        break;
                                    #endregion

                                    default: break;

                                }

                            } while (cmd2innerCommand != "0");
                            break;
                        #endregion

                        #region COMMAND 3
                        case "3":
                            var cmd3innerCommand = "";
                            do
                            {
                                Console.Clear();
                                Console.WriteLine(title);
                                Console.WriteLine();
                                Console.WriteLine("Successfully logged in as: {0}", logged_in_as);
                                Console.WriteLine();
                                Console.WriteLine("1. Rebuild planning section elastic. ");
                                Console.WriteLine("2. Rebuild aftercare section elastic. ");
                                Console.WriteLine("3. Rebuild settlement section elastic. ");
                                Console.WriteLine("4. Rebuild doctor practices section elastic.");
                                Console.WriteLine("5. Rebuild patients section elastic. ");
                                Console.WriteLine("6. Rebuild orders section elastic. ");
                                Console.WriteLine("7. Rebuild treatments section elastic. ");
                                Console.WriteLine("8. Rebuild archive section elastic. ");
                                Console.WriteLine("9. Rebuild receipt section elastic. ");
                                Console.WriteLine("10. Rebuild patient details list.");
                                Console.WriteLine("11. Rebuild OCT section elastic. ");
                                Console.WriteLine("0. Return to previous screen.");
                                Console.WriteLine();
                                if (cmd3innerCommand != "")
                                {
                                    Console.WriteLine("*** Command [{0}] status ***", cmd3innerCommand);
                                    Console.WriteLine("Command executed.");
                                    Console.WriteLine();
                                }

                                Console.WriteLine("Enter command: ");
                                cmd3innerCommand = Console.ReadLine();

                                switch (cmd3innerCommand)
                                {
                                    #region PLANNING
                                    case "1":
                                        Command31(connectionString, securityTicket, connection);
                                        break;
                                    #endregion

                                    #region AFTERCARE
                                    case "2":
                                        Command32(connectionString, securityTicket, connection);
                                        break;
                                    #endregion

                                    #region SETTLEMENT
                                    case "3":
                                        Command33(connectionString, securityTicket, connection);
                                        break;
                                    #endregion

                                    #region DOCTOR / PRACTICE
                                    case "4":
                                        Command34(connectionString, securityTicket, connection);
                                        break;
                                    #endregion

                                    #region PATIENT
                                    case "5":
                                        Command35(connectionString, securityTicket, connection);
                                        break;
                                    #endregion

                                    #region ORDER
                                    case "6":
                                        Command36(connectionString, securityTicket, connection);
                                        break;
                                    #endregion

                                    #region TREATMENT
                                    case "7":
                                        Command37(connectionString, securityTicket, connection);
                                        break;
                                    #endregion

                                    #region ARCHIVE
                                    case "8":
                                        Command38(connectionString, securityTicket, connection);
                                        break;
                                    #endregion

                                    #region RECEIPT
                                    case "9":
                                        Command39(connectionString, securityTicket, connection);
                                        break;
                                    #endregion

                                    #region PATIENT DETAILS
                                    case "10":
                                        Command310(connectionString, securityTicket, connection);
                                        break;
                                    #endregion

                                    #region OCT
                                    case "11":
                                        Command311(connectionString, securityTicket, connection);
                                        break;
                                    #endregion

                                    default: break;
                                }

                            } while (cmd3innerCommand != "0");
                            break;
                        #endregion

                        #region COMMAND 4
                        case "4":
                            var cmd4innerCommand = "";
                            var cmd21anyCaseUpdated = false;
                            var isCommand4Executed = true;
                            do
                            {
                                // todo: remove unused commands
                                Console.Clear();
                                Console.WriteLine(title);
                                Console.WriteLine();
                                Console.WriteLine("Successfully logged in as: {0}", logged_in_as);
                                Console.WriteLine();
                                Console.WriteLine("1. Clean up cases on the elastic server. ");
                                Console.WriteLine("2. Update doctors and patients- add contract assignment. ");
                                Console.WriteLine("3. Recalculate all GPOS-es on tenant. ");
                                Console.WriteLine("4. Delete last used aftercares. ");
                                Console.WriteLine("5. Fix doctors db table. ");
                                Console.WriteLine("6. Fix gpos in the db. ");
                                Console.WriteLine("7. Fix aftercare FS status (when aftercare doesn't have FS status assigned to it after submission).");
                                Console.WriteLine("8. Add company settings for tenant.");
                                Console.WriteLine("9. Fix open aftercares bill positions.");
                                Console.WriteLine("10. Fix double aftercares on old cases (cases that had treatment and aftercare billed together).");
                                Console.WriteLine("11. Fix contract roles.");
                                Console.WriteLine("12. Fix multiple patient pariticipation consents.");
                                Console.WriteLine("13. Fix multiple aftercare FS statuses.");
                                Console.WriteLine("14. Fix multiple doctor consents.");
                                Console.WriteLine("15. Fix missing GPOS-es.");
                                Console.WriteLine("16. Update bill position numbers. ");
                                Console.WriteLine("17. Fix bill positions for open aftercares. ");
                                Console.WriteLine("18. Fix cases that are twice in the report. ");
                                Console.WriteLine("19. Fix aftercares which are performed/paid twice. ");
                                Console.WriteLine("20. Fix aftercares FS statuses deleted by mistake. ");
                                Console.WriteLine("21. Fix missing aftercare GPOS-es caused by new contract. ");
                                Console.WriteLine("22. Set all cases with case number below 10000 to have had their submit.pdf report downloaded");
                                Console.WriteLine("23. Fix Invoice to practice case property. ");
                                Console.WriteLine("24. Fix cases submitted without patient participation consent.");
                                Console.WriteLine("25. Convert pre-examinations into OCTs.");
                                Console.WriteLine("26. Fix double oct planned action type.");
                                Console.WriteLine("27. Add missing open OCTs.");
                                Console.WriteLine("28. Fix relevant planned action creation timestamps.");
                                Console.WriteLine("29. Fix patient insurances creation timestamps.");
                                Console.WriteLine("30. Mark all cancelled orders as exported.");
                                Console.WriteLine("31. Fix FS8 cases wrongfully transferred to FS7.");
                                Console.WriteLine("32. Fix patients with HIP with no contract that have consents.");
                                Console.WriteLine("33. Fix documentation cases without GPOS.");
                                Console.WriteLine("34. Fix submitted cases that were cancelled.");
                                Console.WriteLine("35. Add default pharmacy to old orders.");
                                Console.WriteLine("36. Fix missing billing information for reassigned aftercares.");
                                Console.WriteLine("37. Fix open aftercares (cases where both error correction and open aftercare exist).");
                                Console.WriteLine("38. Check if there are cases with multiple billed aftercares without aftercare cancellation.");
                                Console.WriteLine("39. Fix performed OCTs without FS status");
                                Console.WriteLine("40. Fix missing OCT bill positions.");
                                Console.WriteLine("41. Fix missing open aftercares.");
                                Console.WriteLine("42. Fix missing gpos for open OCTs.");
                                Console.WriteLine("43. Remove OCTs attached to cases with missing Ozurdex GPOS.");
                                Console.WriteLine("0. Return to previous screen.");
                                Console.WriteLine();

                                if (cmd4innerCommand != "")
                                {
                                    Console.WriteLine("*** Command [{0}] status ***", cmd4innerCommand);
                                    if (isCommand4Executed)
                                    {
                                        Console.WriteLine("Command executed.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Command execution cancelled.");
                                    }

                                    if (cmd4innerCommand == "21" && !cmd21anyCaseUpdated)
                                        Console.WriteLine("No cases updated.");
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Enter command: ");
                                cmd4innerCommand = Console.ReadLine();

                                switch (cmd4innerCommand)
                                {
                                    #region COMMAND 1
                                    case "1":
                                        Import_Cases_From_Excel.CleanupElastic(connectionString, securityTicket);
                                        break;
                                    #endregion

                                    #region COMMAND 2
                                    case "2":
                                        Update_doctors_and_patients_contract.Update_Doctors_add_Contract_Assignment(connectionString, securityTicket);
                                        Console.WriteLine("Doctor contracts added ");
                                        Update_doctors_and_patients_contract.Update_Patients_add_Participation_Consent(connectionString, securityTicket);
                                        Console.WriteLine("Patient participation consents added");
                                        break;
                                    #endregion

                                    #region COMMAND 3
                                    case "3":
                                        GPOS_Utils.FixGPOS(connectionString, securityTicket);
                                        break;
                                    #endregion

                                    #region COMMAND 4
                                    case "4":
                                        var types = Elastic_Utils.GetAllTypes(securityTicket.TenantID.ToString());
                                        var length = Guid.Empty.ToString().Length;
                                        length += 5;
                                        var types_to_delete = new List<string>();
                                        for (int i = 0; i < types.Length; i += length)
                                        {
                                            int index = types.IndexOf("user_", i);
                                            if (index != -1 && !types_to_delete.Contains(types.Substring(index, length)))
                                                types_to_delete.Add(types.Substring(index, length));
                                        }

                                        foreach (var type in types_to_delete)
                                        {
                                            Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), type);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 5
                                    case "5":
                                        {
                                            FixDoctorsTable.FixDataInDB(connectionString, securityTicket);
                                        }

                                        break;
                                    #endregion

                                    #region COMMAND 6
                                    case "6":
                                        {
                                            FixDoctorsTable.FixGposData(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 7
                                    case "7":
                                        {
                                            FixDoctorsTable.FixAftercareFSStatus(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 8
                                    case "8":
                                        {
                                            Setup_for_Tenant.Add_Company_Settings_for_Tenant(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 9
                                    case "9":
                                        {
                                            FixDoctorsTable.FixOpenAftercaresBillPositions(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 10
                                    case "10":
                                        {
                                            FixDoctorsTable.FixDoubleAftercares(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 11
                                    case "11":
                                        {
                                            FixDoctorsTable.FixContractRoles(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 12
                                    case "12":
                                        {
                                            FixDoctorsTable.FixDoubleParticipationConsents(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 13
                                    case "13":
                                        {
                                            FixDoctorsTable.FixMultipleAftercareFsStatuses(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 14
                                    case "14":
                                        {
                                            FixDoctorsTable.FixMultipleDoctorsConsents(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 15
                                    case "15":
                                        {
                                            FixDoctorsTable.FixMissingGposes(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 16
                                    case "16":
                                        {
                                            FixDoctorsTable.UpdateBillPositionNumbers(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 17
                                    case "17":
                                        {
                                            FixDoctorsTable.FixMissingBillPositionsOnOpenAftercares(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 18
                                    case "18":
                                        {
                                            FixDoctorsTable.FixDoubleCasesInTheReport(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 19
                                    case "19":
                                        {
                                            FixDoctorsTable.FixMultipleAftercaresWithFSstatus(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 20
                                    case "20":
                                        {
                                            FixDoctorsTable.FixWrongFSStatusDeletion(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 21
                                    case "21":
                                        {
                                            // FixDoctorsTable.FixOldCasesAftercarePerformedDate(connectionString, securityTicket);
                                            cmd21anyCaseUpdated = FixDoctorsTable.FixMissingAftercareGPOSesOnNewContract(connectionString, securityTicket);
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 22
                                    case "22":
                                        {
                                            var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                                            DbTransaction transaction = null;
                                            try
                                            {
                                                dbConnection.Open();
                                                transaction = dbConnection.BeginTransaction();
                                                var cases = cls_Get_Cases_to_Set_Documents_as_Downloaded.Invoke(dbConnection, transaction, securityTicket).Result;
                                                if (cases.Any())
                                                {
                                                    var elasticConnection = Elastic_Utils.ElsaticConnection();
                                                    var serializer = new JsonNetSerializer();
                                                    var elasticCommad = Commands.Search(securityTicket.TenantID.ToString(), "settlement").Pretty();
                                                    var query = new QueryBuilder<Settlement_Model>().Size(int.MaxValue).BuildBeautified();
                                                    var result = elasticConnection.Post(elasticCommad, query);
                                                    var existingSettlements = serializer.ToSearchResult<Settlement_Model>(result).Documents;

                                                    elasticCommad = Commands.Search(securityTicket.TenantID.ToString(), "patient_details").Pretty();
                                                    query = new QueryBuilder<PatientDetailViewModel>().Size(int.MaxValue).BuildBeautified();
                                                    result = elasticConnection.Post(elasticCommad, query);
                                                    var existingPatientDetails = serializer.ToSearchResult<PatientDetailViewModel>(result).Documents;

                                                    var caseProperty = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(dbConnection, transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
                                                    {
                                                        GlobalPropertyMatchingID = "mm.docconnect.case.report.downloaded",
                                                        Tenant_RefID = securityTicket.TenantID,
                                                        IsValue_String = true,
                                                        IsDeleted = false,
                                                        PropertyName = "Case Report Downloaded"
                                                    }).SingleOrDefault();

                                                    if (caseProperty == null)
                                                    {
                                                        caseProperty = new ORM_HEC_CAS_Case_UniversalProperty();
                                                        caseProperty.GlobalPropertyMatchingID = "mm.docconnect.case.report.downloaded";
                                                        caseProperty.IsValue_String = true;
                                                        caseProperty.Modification_Timestamp = DateTime.Now;
                                                        caseProperty.PropertyName = "Case Report Downloaded";
                                                        caseProperty.Tenant_RefID = securityTicket.TenantID;

                                                        caseProperty.Save(dbConnection, transaction);
                                                    }

                                                    foreach (var cas in cases)
                                                    {
                                                        var casePropertyValue = ORM_HEC_CAS_Case_UniversalPropertyValue.Query.Search(dbConnection, transaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
                                                        {
                                                            HEC_CAS_Case_RefID = cas.CaseID,
                                                            HEC_CAS_Case_UniversalProperty_RefID = caseProperty.HEC_CAS_Case_UniversalPropertyID,
                                                            Tenant_RefID = securityTicket.TenantID,
                                                            IsDeleted = false
                                                        }).SingleOrDefault();

                                                        if (casePropertyValue == null)
                                                        {
                                                            casePropertyValue = new ORM_HEC_CAS_Case_UniversalPropertyValue();
                                                            casePropertyValue.HEC_CAS_Case_RefID = cas.CaseID;
                                                            casePropertyValue.HEC_CAS_Case_UniversalProperty_RefID = caseProperty.HEC_CAS_Case_UniversalPropertyID;
                                                            casePropertyValue.Tenant_RefID = securityTicket.TenantID;
                                                        }

                                                        casePropertyValue.Modification_Timestamp = DateTime.Now;
                                                        if (casePropertyValue.Value_String == null)
                                                        {
                                                            casePropertyValue.Value_String = cas.TreatmentActionID.ToString();
                                                            if (cas.AftercareActionID != Guid.Empty)
                                                            {
                                                                casePropertyValue.Value_String += ";" + cas.AftercareActionID.ToString();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (!casePropertyValue.Value_String.Contains(cas.TreatmentActionID.ToString()))
                                                            {
                                                                casePropertyValue.Value_String += ";" + cas.TreatmentActionID.ToString();
                                                            }

                                                            if (cas.AftercareActionID != Guid.Empty && !casePropertyValue.Value_String.Contains(cas.AftercareActionID.ToString()))
                                                            {
                                                                casePropertyValue.Value_String += ";" + cas.AftercareActionID.ToString();
                                                            }
                                                        }

                                                        casePropertyValue.Save(dbConnection, transaction);

                                                        var settlements = existingSettlements.Where(t => t.case_id == cas.CaseID.ToString()).ToList();
                                                        if (settlements.Any())
                                                        {
                                                            foreach (var settlement in settlements)
                                                            {
                                                                settlement.is_report_downloaded = true;
                                                            }

                                                            var patientDetails = existingPatientDetails.Where(t => t.case_id == cas.CaseID.ToString()).ToList();
                                                            if (patientDetails.Any())
                                                            {
                                                                foreach (var patientDetail in patientDetails)
                                                                {
                                                                    patientDetail.if_settlement_is_report_downloaded = true;
                                                                }

                                                                Add_New_Patient.ImportPatientDetailsToElastic(patientDetails, securityTicket.TenantID.ToString());
                                                            }

                                                            Add_new_Settlement.Import_Settlement_to_ElasticDB(settlements, securityTicket.TenantID.ToString());
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine(String.Format("No settlement found for case {0}", cas.CaseNumber));
                                                            Console.WriteLine("Continue?");
                                                            if (Console.ReadLine().ToLower() != "y")
                                                            {
                                                                throw new Exception("Command 4-22 aborted.");
                                                            }
                                                        }
                                                    }
                                                }

                                                transaction.Commit();
                                            }
                                            catch (Exception ex)
                                            {
                                                if (transaction != null)
                                                {
                                                    transaction.Rollback();
                                                }

                                                Console.WriteLine(ex.Message);
                                                Console.Read();
                                                break;
                                            }
                                            finally
                                            {
                                                dbConnection.Close();
                                            }
                                            break;
                                        }
                                    #endregion

                                    #region COMMAND 23
                                    case "23":
                                        var cmd23Connection = DBSQLSupport.CreateConnection(connectionString);
                                        DbTransaction cmd23Transaction = null;
                                        try
                                        {
                                            cmd23Connection.Open();
                                            cmd23Transaction = cmd23Connection.BeginTransaction();

                                            var caseProperties = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(cmd23Connection, cmd23Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
                                            {
                                                GlobalPropertyMatchingID = "mm.doc.connect.case.practice.invoice",
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            });

                                            var propToRemain = caseProperties.First();

                                            foreach (var prop in caseProperties.Skip(1))
                                            {
                                                prop.IsDeleted = true;
                                                prop.Save(cmd23Connection, cmd23Transaction);
                                            }

                                            var values = ORM_HEC_CAS_Case_UniversalPropertyValue.Query.Search(cmd23Connection, cmd23Transaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
                                            {
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).OrderByDescending(t => t.Creation_Timestamp).GroupBy(t => t.HEC_CAS_Case_RefID).ToDictionary(t => t.Key, t => t);

                                            foreach (var value in values)
                                            {
                                                var valueToRemain = value.Value.First();
                                                if (caseProperties.Any(t => t.HEC_CAS_Case_UniversalPropertyID == valueToRemain.HEC_CAS_Case_UniversalProperty_RefID))
                                                {
                                                    valueToRemain.HEC_CAS_Case_UniversalProperty_RefID = propToRemain.HEC_CAS_Case_UniversalPropertyID;
                                                    valueToRemain.Save(cmd23Connection, cmd23Transaction);
                                                }

                                                foreach (var v in value.Value.Skip(1))
                                                {
                                                    if (caseProperties.Any(t => t.HEC_CAS_Case_UniversalPropertyID == v.HEC_CAS_Case_UniversalProperty_RefID))
                                                    {
                                                        v.IsDeleted = true;
                                                        v.Save(cmd23Connection, cmd23Transaction);
                                                    }
                                                }
                                            }

                                            cmd23Transaction.Commit();
                                        }
                                        catch (Exception ex)
                                        {
                                            if (cmd23Transaction != null)
                                            {
                                                cmd23Transaction.Rollback();
                                            }

                                            Console.WriteLine(ex.Message);
                                            Console.Read();
                                            break;
                                        }
                                        finally
                                        {
                                            if (cmd23Connection.State == System.Data.ConnectionState.Open)
                                            {
                                                cmd23Connection.Close();
                                            }
                                        }
                                        break;
                                    #endregion

                                    #region COMMAND 24
                                    case "24":
                                        var cmd24Connection = DBSQLSupport.CreateConnection(connectionString);
                                        DbTransaction cmd24Transaction = null;
                                        try
                                        {
                                            cmd24Connection.Open();
                                            cmd24Transaction = cmd24Connection.BeginTransaction();

                                            List<Case_Model> cases_elastic = new List<Case_Model>();
                                            var cases = cls_Get_Cases_Submitted_Without_Consent.Invoke(cmd24Connection, cmd24Transaction, securityTicket).Result;
                                            if (cases.Any())
                                            {
                                                Console.WriteLine("Found cases: {0}", cases.Length);
                                                foreach (var case_to_fix in cases)
                                                {
                                                    Console.WriteLine("Case number: {0} \nCreated on: {1}\n", case_to_fix.CaseNumber, case_to_fix.Creation_Timestamp.ToString("dd.MM.yyyy - HH:mm"));
                                                    Console.WriteLine("Continue? [y/n]");

                                                    if (Console.ReadLine().ToLower() == "y")
                                                    {
                                                        var op = ORM_HEC_ACT_PlannedAction.Query.Search(cmd24Connection, cmd24Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                                                        {
                                                            HEC_ACT_PlannedActionID = case_to_fix.HEC_ACT_PlannedActionID
                                                        }).Single();
                                                        if (op.IsPerformed)
                                                        {
                                                            var performedOp = ORM_HEC_ACT_PerformedAction.Query.Search(cmd24Connection, cmd24Transaction, new ORM_HEC_ACT_PerformedAction.Query()
                                                            {
                                                                HEC_ACT_PerformedActionID = op.IfPerformed_PerformedAction_RefID
                                                            }).Single();

                                                            performedOp.IsDeleted = true;
                                                            performedOp.Save(cmd24Connection, cmd24Transaction);

                                                            op.IfPerformed_PerformedAction_RefID = Guid.Empty;
                                                            op.IsPerformed = false;

                                                            op.Save(cmd24Connection, cmd24Transaction);

                                                            try
                                                            {
                                                                Elastic_Utils.Delete_Entry(securityTicket.TenantID.ToString(), "settlement", op.HEC_ACT_PlannedActionID.ToString());
                                                            }
                                                            catch { }
                                                            try
                                                            {
                                                                Elastic_Utils.Delete_Entry(securityTicket.TenantID.ToString(), "submitted_case", op.HEC_ACT_PlannedActionID.ToString());
                                                            }
                                                            catch { }
                                                            try
                                                            {
                                                                Elastic_Utils.Delete_Entry(securityTicket.TenantID.ToString(), "patient_details", op.HEC_ACT_PlannedActionID.ToString());
                                                            }
                                                            catch { }

                                                            #region Add new entry to elastic

                                                            var doctorsCache = cls_Get_Doctor_Details_on_Tenant.Invoke(cmd24Connection, cmd24Transaction, securityTicket).Result.GroupBy(t => t.DoctorBptId).ToDictionary(t => t.Key, t => t.Single());
                                                            var practiceCache = cls_Get_Practice_Details_on_Tenant.Invoke(cmd24Connection, cmd24Transaction, securityTicket).Result.GroupBy(t => t.PracticeBptID).ToDictionary(t => t.Key, t => t.Single());
                                                            var orderStatusCache = cls_Get_Order_Status_History_on_Tenant.Invoke(cmd24Connection, cmd24Transaction, securityTicket).Result.GroupBy(t => t.header_id).ToDictionary(t => t.Key, t => t);
                                                            var fsStatusCache = cls_Get_Case_FS_Statuses_on_Tenant.Invoke(cmd24Connection, cmd24Transaction, securityTicket).Result;
                                                            var all_cases = cls_Get_All_Cases_from_DB_for_ElasticRebuild.Invoke(cmd24Connection, cmd24Transaction, securityTicket).Result.Where(c => !fsStatusCache.Any(t => t.case_id == c.case_id)).ToList();
                                                            var patientCache = cls_Get_Patient_Details_on_Tenant.Invoke(cmd24Connection, cmd24Transaction, securityTicket).Result.GroupBy(t => t.id).ToDictionary(t => t.Key, t => t.Single());

                                                            var _case = all_cases.Single(t => t.case_id == case_to_fix.HEC_CAS_CaseID);
                                                            bool is_orders_drug = _case.order_header_id != Guid.Empty;
                                                            Case_Model case_model_elastic = new Case_Model();
                                                            case_model_elastic.aftercare_name = "-";

                                                            if (_case.aftercare_bpt != Guid.Empty)
                                                            {
                                                                if (doctorsCache.ContainsKey(_case.aftercare_bpt))
                                                                {
                                                                    var acDoctor = doctorsCache[_case.aftercare_bpt];
                                                                    case_model_elastic.is_aftercare_doctor = true;
                                                                    case_model_elastic.aftercare_name = GenericUtils.GetDoctorNamePascal(acDoctor);
                                                                    case_model_elastic.aftercare_doctors_practice_name = acDoctor.PracticeName;
                                                                    case_model_elastic.aftercare_doctor_practice_id = acDoctor.DoctorID.ToString();
                                                                    case_model_elastic.aftercare_doctor_lanr = acDoctor.DoctorLANR;

                                                                    if (practiceCache.ContainsKey(acDoctor.PracticeBPTID))
                                                                    {
                                                                        case_model_elastic.aftercare_doctors_practice_id = practiceCache[acDoctor.PracticeBPTID].PracticeID.ToString();
                                                                    }
                                                                }
                                                                else if (practiceCache.ContainsKey(_case.aftercare_bpt))
                                                                {
                                                                    var practice = practiceCache[_case.aftercare_bpt];
                                                                    case_model_elastic.aftercare_name = practice.PracticeName;
                                                                    case_model_elastic.aftercare_doctor_practice_id = practice.PracticeID.ToString();
                                                                    case_model_elastic.aftercare_doctor_lanr = practice.PracticeBSNR;
                                                                }
                                                            }

                                                            case_model_elastic.delivery_time_from = _case.order_delivery_time_from;
                                                            case_model_elastic.delivery_time_string = _case.order_delivery_date.ToString("dd.MM.yyyy");
                                                            case_model_elastic.delivery_time_to = _case.order_delivery_time_to;
                                                            case_model_elastic.diagnose = _case.diagnose_name == null ? "" : _case.diagnose_name;
                                                            case_model_elastic.diagnose_id = _case.diagnose_id == Guid.Empty ? "" : _case.diagnose_id.ToString();
                                                            case_model_elastic.drug = _case.drug_name;
                                                            case_model_elastic.drug_id = _case.hec_drug_id.ToString();
                                                            case_model_elastic.id = _case.case_id.ToString();
                                                            case_model_elastic.is_orders_drug = is_orders_drug;
                                                            case_model_elastic.localization = _case.localization == null ? "-" : _case.localization;
                                                            case_model_elastic.order_modification_timestamp = _case.order_modification_timestamp;
                                                            case_model_elastic.order_modification_timestamp_string = _case.order_modification_timestamp.ToString("dd.MM.yyyy");

                                                            if (patientCache.ContainsKey(_case.patient_id))
                                                            {
                                                                var patient = patientCache[_case.patient_id];

                                                                case_model_elastic.patient_birthdate = patient.birthday;
                                                                case_model_elastic.patient_birthdate_string = patient.birthday.ToString("dd.MM.yyyy");
                                                                case_model_elastic.patient_hip = patient.health_insurance_provider;
                                                                case_model_elastic.patient_insurance_number = patient.insurance_id;
                                                                case_model_elastic.patient_id = _case.patient_id.ToString();
                                                                case_model_elastic.patient_name = patient.patient_last_name + ", " + patient.patient_first_name;
                                                            }

                                                            case_model_elastic.practice_id = _case.practice_id.ToString();
                                                            case_model_elastic.previous_status_drug_order = "";
                                                            case_model_elastic.status_drug_order = "";
                                                            if (is_orders_drug)
                                                            {
                                                                var order_status_history = orderStatusCache[_case.order_header_id].ToList();
                                                                if (order_status_history.First().order_status_code == 6)
                                                                {
                                                                    case_model_elastic.previous_status_drug_order = "MO" + order_status_history[1].order_status_code;
                                                                }
                                                                else if (order_status_history.First().order_status_code == 7)
                                                                {
                                                                    case_model_elastic.previous_status_drug_order = "MO" + order_status_history[2].order_status_code;
                                                                }
                                                                else
                                                                {
                                                                    case_model_elastic.previous_status_drug_order = "";
                                                                }
                                                                var status = "MO" + order_status_history.First().order_status_code;
                                                                case_model_elastic.status_drug_order = status == "MO7" ? "MO6" : status;
                                                            }

                                                            case_model_elastic.status_treatment = _case.diagnose_name == null ? "" : _case.is_treatment_cancelled ? "OP4" : _case.treatment_date < DateTime.Now.Date ? "OP3" : "OP1";
                                                            case_model_elastic.treatment_date = _case.treatment_date;
                                                            case_model_elastic.treatment_date_day_month = _case.treatment_date.ToString("dd.MM");
                                                            case_model_elastic.treatment_date_month_year = _case.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                                                            case_model_elastic.treatment_doctor_id = _case.treatment_doctor_id != Guid.Empty ? _case.treatment_doctor_id.ToString() : "";
                                                            case_model_elastic.treatment_doctor_lanr = _case.treatment_doctor_lanr == null ? "" : _case.treatment_doctor_lanr;
                                                            case_model_elastic.treatment_doctor_name = _case.treatment_doctor_name == null ? "-" : _case.treatment_doctor_name;

                                                            cases_elastic.Add(case_model_elastic);
                                                            #endregion

                                                            var all_languagesL = ORM_CMN_Language.Query.Search(cmd24Connection, cmd24Transaction, new ORM_CMN_Language.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray();
                                                            var case_details = cls_Get_Case_Details_for_CaseID.Invoke(cmd24Connection, cmd24Transaction, new P_CAS_GCDfCID_1435() { CaseID = case_to_fix.HEC_CAS_CaseID }, securityTicket).Result;

                                                            cls_Calculate_Case_GPOS.Invoke(cmd24Connection, cmd24Transaction, new P_CAS_CCGPOS_1000()
                                                            {
                                                                ac_doctor_id = case_details.ac_doctor_id,
                                                                case_id = case_to_fix.HEC_CAS_CaseID,
                                                                diagnose_id = case_details.diagnose_id,
                                                                drug_id = case_details.drug_id,
                                                                localization = case_details.localization,
                                                                patient_id = case_details.patient_id,
                                                                treatment_doctor_id = case_details.op_doctor_id,
                                                                treatment_date = case_details.treatment_date,
                                                                all_languagesL = all_languagesL
                                                            }, securityTicket);
                                                        }

                                                        var relevantAftercares = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(cmd24Connection, cmd24Transaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query()
                                                        {
                                                            Case_RefID = case_to_fix.HEC_CAS_CaseID
                                                        });

                                                        foreach (var relevantAftercare in relevantAftercares)
                                                        {
                                                            var ac = ORM_HEC_ACT_PlannedAction.Query.Search(cmd24Connection, cmd24Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                                                            {
                                                                HEC_ACT_PlannedActionID = relevantAftercare.PlannedAction_RefID
                                                            }).Single();

                                                            if (ac.IsPerformed)
                                                            {
                                                                var performedAc = ORM_HEC_ACT_PerformedAction.Query.Search(cmd24Connection, cmd24Transaction, new ORM_HEC_ACT_PerformedAction.Query()
                                                                {
                                                                    HEC_ACT_PerformedActionID = ac.IfPerformed_PerformedAction_RefID
                                                                }).Single();

                                                                performedAc.IsDeleted = true;
                                                                performedAc.Save(cmd24Connection, cmd24Transaction);

                                                                ac.IsPerformed = false;
                                                                ac.IfPerformed_PerformedAction_RefID = Guid.Empty;

                                                                ac.Save(cmd24Connection, cmd24Transaction);

                                                                try
                                                                {
                                                                    Elastic_Utils.Delete_Entry(securityTicket.TenantID.ToString(), "settlement", ac.HEC_ACT_PlannedActionID.ToString());
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    Elastic_Utils.Delete_Entry(securityTicket.TenantID.ToString(), "submitted_case", ac.HEC_ACT_PlannedActionID.ToString());
                                                                }
                                                                catch { }
                                                                try
                                                                {
                                                                    Elastic_Utils.Delete_Entry(securityTicket.TenantID.ToString(), "patient_details", ac.HEC_ACT_PlannedActionID.ToString());
                                                                }
                                                                catch { }
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            cmd24Transaction.Commit();

                                            if (cases_elastic.Any())
                                            {
                                                Add_New_Case.Import_Case_Data_to_ElasticDB(cases_elastic, securityTicket.TenantID.ToString());
                                            }
                                            break;
                                        }
                                        catch (Exception ex)
                                        {
                                            if (cmd24Transaction != null)
                                            {
                                                cmd24Transaction.Rollback();
                                            }

                                            Console.WriteLine(ex.Message);
                                            Console.Read();
                                            break;
                                        }
                                        finally
                                        {
                                            if (cmd24Connection.State == System.Data.ConnectionState.Open)
                                            {
                                                cmd24Connection.Close();
                                            }
                                        }
                                    #endregion

                                    #region COMMAND 25
                                    case "25":
                                        var cmd25Connection = DBSQLSupport.CreateConnection(connectionString);
                                        DbTransaction cmd25Transaction = null;

                                        var filePath = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Convert_Pre-examinations_to_OCTs_analysis.txt");
                                        if (File.Exists(filePath))
                                        {
                                            filePath = filePath.Replace(".txt", String.Format("{0}.txt", new Random().Next(1, 100)));
                                        }
                                        try
                                        {
                                            cmd25Connection.Open();
                                            cmd25Transaction = cmd25Connection.BeginTransaction();

                                            var cancelationStatuses = new List<int>() { 8, 11, 17 };

                                            var preexaminations = cls_Get_Preexaminations_on_Tenant.Invoke(cmd25Connection, cmd25Transaction, securityTicket).Result
                                                .GroupBy(t => t.Patient_RefID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.IM_PotentialDiagnosisLocalization_Code).ToDictionary(x => x.Key, x => x
                                                    .GroupBy(cas => cas.Case_RefID).ToDictionary(cas => cas.Key, cas => cas.OrderBy(r => r.PlannedFor_Date).ToList())));

                                            var allCaseData = cls_Get_CaseData_on_Tenant.Invoke(cmd25Connection, cmd25Transaction, securityTicket).Result
                                                .GroupBy(t => t.Patient_RefID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.IM_PotentialDiagnosisLocalization_Code).ToDictionary(x => x.Key, x => x.OrderBy(r => r.PlannedFor_Date).ToList()));
                                            var doctors_cache = cls_Get_Doctor_Details_on_Tenant.Invoke(cmd25Connection, cmd25Transaction, securityTicket).Result.GroupBy(t => t.DoctorBptId).ToDictionary(t => t.Key, t => t.Single());
                                            var all_practices = cls_Get_Practice_Details_on_Tenant.Invoke(cmd25Connection, cmd25Transaction, securityTicket).Result.GroupBy(t => t.PracticeBptID).ToDictionary(t => t.Key, t => t.Single());

                                            ORM_CMN_Language.Query all_languagesQ = new ORM_CMN_Language.Query();
                                            all_languagesQ.Tenant_RefID = securityTicket.TenantID;
                                            all_languagesQ.IsDeleted = false;

                                            var all_languagesL = ORM_CMN_Language.Query.Search(cmd25Connection, cmd25Transaction, all_languagesQ).ToArray();

                                            var doctors = ORM_HEC_Doctor.Query.Search(cmd25Connection, cmd25Transaction, new ORM_HEC_Doctor.Query()
                                            {
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).ToDictionary(t => t.HEC_DoctorID, t => t.BusinessParticipant_RefID);

                                            var patients = cls_Get_Patient_Details_on_Tenant.Invoke(cmd25Connection, cmd25Transaction, securityTicket).Result.ToDictionary(t => t.id, t => t);

                                            var octPlannedActionTypeGpmId = "mm.docconect.doc.app.planned.action.oct";
                                            var octPlannedActionType = ORM_HEC_ACT_ActionType.Query.Search(cmd25Connection, cmd25Transaction, new ORM_HEC_ACT_ActionType.Query()
                                            {
                                                GlobalPropertyMatchingID = octPlannedActionTypeGpmId,
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).SingleOrDefault();

                                            var randomDrugDiagnoseCombo = cls_Get_Random_Drug_Diagnose_Combination_on_Oct_Contract.Invoke(cmd25Connection, cmd25Transaction, securityTicket).Result;

                                            var case_ids_with_open_octs = new List<Guid>();

                                            if (octPlannedActionType == null)
                                            {
                                                octPlannedActionType = new ORM_HEC_ACT_ActionType();
                                                octPlannedActionType.GlobalPropertyMatchingID = octPlannedActionTypeGpmId;
                                                octPlannedActionType.Modification_Timestamp = DateTime.Now;
                                                octPlannedActionType.Tenant_RefID = securityTicket.TenantID;

                                                octPlannedActionType.Save(cmd25Connection, cmd25Transaction);
                                            }

                                            var octPerformedActionTypeGpmId = "mm.docconect.doc.app.performed.action.oct";
                                            var octPerformedActionType = ORM_HEC_ACT_ActionType.Query.Search(cmd25Connection, cmd25Transaction, new ORM_HEC_ACT_ActionType.Query()
                                            {
                                                GlobalPropertyMatchingID = octPerformedActionTypeGpmId,
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).SingleOrDefault();

                                            if (octPerformedActionType == null)
                                            {
                                                octPerformedActionType = new ORM_HEC_ACT_ActionType();
                                                octPerformedActionType.GlobalPropertyMatchingID = octPerformedActionTypeGpmId;
                                                octPerformedActionType.Modification_Timestamp = DateTime.Now;
                                                octPerformedActionType.Tenant_RefID = securityTicket.TenantID;

                                                octPerformedActionType.Save(cmd25Connection, cmd25Transaction);
                                            }

                                            var gpos_type = "mm.docconnect.gpos.catalog.operation";

                                            File.AppendAllText(filePath, "Pre-examinations that will be converted to octs: \n");
                                            foreach (var patientPreexaminations in preexaminations)
                                            {
                                                var patientId = patientPreexaminations.Key;
                                                var patient_details = patients[patientId];
                                                var patientName = String.Format("{0}, {1}", patient_details.patient_last_name, patient_details.patient_first_name);
                                                var patientCaseData = allCaseData.ContainsKey(patientId) ? allCaseData[patientPreexaminations.Key] : null;

                                                var contracts = cls_Get_InsuranceToBrokerContractID_for_DrugID_and_DiagnoseID.Invoke(cmd25Connection, cmd25Transaction, new P_CAS_GItBCIDfDIDaDID_1541()
                                                {
                                                    DiagnoseID = randomDrugDiagnoseCombo.PotentialDiagnosis_RefID,
                                                    DrugID = randomDrugDiagnoseCombo.HealthcareProduct_RefID,
                                                    PatientID = patientId,
                                                    TreatmentDate = new DateTime(2016, 11, 3)
                                                }, securityTicket).Result;

                                                foreach (var localization in patientPreexaminations.Value)
                                                {
                                                    var localizationCaseData = new List<CAS_GCDoT_1825>();

                                                    if (patientCaseData != null && patientCaseData.ContainsKey(localization.Key))
                                                    {
                                                        localizationCaseData = patientCaseData[localization.Key];
                                                    }
                                                    else
                                                    {
                                                        var latest_preexamination_date = localization.Value.Max(t => t.Value.Max(x => x.PlannedFor_Date));
                                                        var op_date = latest_preexamination_date.AddDays(-364);
                                                        var doctor_id = localization.Value.First().Value.First().HEC_DoctorID;
                                                        var bpt_id = doctors[doctor_id];
                                                        var practiceBptId = doctors_cache[bpt_id].PracticeBPTID;
                                                        var practiceId = all_practices[practiceBptId].PracticeID;

                                                        #region Create IVOM
                                                        var new_case = new ORM_HEC_CAS_Case();
                                                        new_case.Patient_RefID = patientId;
                                                        new_case.Patient_FirstName = patient_details.patient_first_name;
                                                        new_case.Patient_LastName = patient_details.patient_last_name;
                                                        new_case.Patient_Gender = patient_details.gender;
                                                        new_case.Patient_BirthDate = patient_details.birthday;
                                                        new_case.CaseNumber = cls_Get_Next_Case_Number.Invoke(cmd25Connection, cmd25Transaction, securityTicket).Result.case_number;

                                                        new_case.Modification_Timestamp = DateTime.Now;

                                                        var today = DateTime.Today;
                                                        int age = today.Year - patient_details.birthday.Year;
                                                        if (patient_details.birthday > today.AddYears(-age))
                                                            age--;

                                                        new_case.Patient_Age = age;
                                                        new_case.Tenant_RefID = securityTicket.TenantID;

                                                        new_case.Save(cmd25Connection, cmd25Transaction);

                                                        var case_id = new_case.HEC_CAS_CaseID;

                                                        var initial_performed_action_id = cls_Create_Initial_Performed_Action.Invoke(cmd25Connection, cmd25Transaction, new P_CAS_CIPA_1140()
                                                        {
                                                            all_languagesL = all_languagesL,
                                                            case_id = new_case.HEC_CAS_CaseID,
                                                            patient_id = patientId,
                                                            practice_id = practiceId
                                                        }, securityTicket).Result;

                                                        var intraocular_procedure_id = Guid.Empty;
                                                        var intraocular_packageQ = new ORM_HEC_TRE_PotentialProcedure_Package.Query();
                                                        intraocular_packageQ.Tenant_RefID = securityTicket.TenantID;
                                                        intraocular_packageQ.IsDeleted = false;
                                                        intraocular_packageQ.GlobalPropertyMatchingID = "mm.docconect.doc.app.intraocular.package";

                                                        var intraocular_package = ORM_HEC_TRE_PotentialProcedure_Package.Query.Search(cmd25Connection, cmd25Transaction, intraocular_packageQ).FirstOrDefault();
                                                        if (intraocular_package != null)
                                                        {
                                                            var procedure_2_packageQ = new ORM_HEC_TRE_PotentialProcedure_2_ProcedurePackage.Query();
                                                            procedure_2_packageQ.Tenant_RefID = securityTicket.TenantID;
                                                            procedure_2_packageQ.IsDeleted = false;
                                                            procedure_2_packageQ.HEC_TRE_PotentialProcedure_Package_RefID = intraocular_package.HEC_TRE_PotentialProcedure_PackageID;

                                                            var procedure_2_package = ORM_HEC_TRE_PotentialProcedure_2_ProcedurePackage.Query.Search(cmd25Connection, cmd25Transaction, procedure_2_packageQ).FirstOrDefault();
                                                            if (procedure_2_package != null)
                                                            {
                                                                intraocular_procedure_id = procedure_2_package.HEC_TRE_PotentialProcedure_RefID;
                                                            }
                                                            else
                                                            {
                                                                intraocular_procedure_id = cls_Create_Potential_Procedure.Invoke(cmd25Connection, cmd25Transaction, securityTicket).Result;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            intraocular_procedure_id = cls_Create_Potential_Procedure.Invoke(cmd25Connection, cmd25Transaction, securityTicket).Result;
                                                        }

                                                        cls_Create_Treatment_Planned_Action.Invoke(cmd25Connection, cmd25Transaction, new P_CAS_CTPA_1225()
                                                        {
                                                            all_languagesL = all_languagesL,
                                                            case_id = new_case.HEC_CAS_CaseID,
                                                            diagnose_id = randomDrugDiagnoseCombo.PotentialDiagnosis_RefID,
                                                            initial_performed_action_id = initial_performed_action_id,
                                                            drug_id = randomDrugDiagnoseCombo.HealthcareProduct_RefID,
                                                            intraocular_procedure_id = intraocular_procedure_id,
                                                            is_confirmed = true,
                                                            is_left_eye = localization.Key == "L",
                                                            patient_id = patientId,
                                                            practice_id = practiceId,
                                                            treatment_date = op_date,
                                                            treatment_doctor_id = doctor_id
                                                        }, securityTicket);

                                                        cls_Calculate_Case_GPOS.Invoke(cmd25Connection, cmd25Transaction, new P_CAS_CCGPOS_1000()
                                                        {
                                                            case_id = case_id,
                                                            diagnose_id = randomDrugDiagnoseCombo.PotentialDiagnosis_RefID,
                                                            drug_id = randomDrugDiagnoseCombo.HealthcareProduct_RefID,
                                                            patient_id = patientId,
                                                            localization = localization.Key,
                                                            treatment_date = latest_preexamination_date,
                                                            treatment_doctor_id = doctor_id
                                                        }, securityTicket);

                                                        #endregion

                                                        if (localization.Value.Any(t => t.Value.Any(x => x.IsActive && !cancelationStatuses.Any(c => c == x.TransmitionCode))))
                                                        {
                                                            #region Submit fake documentation case
                                                            var caseProperty = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(cmd25Connection, cmd25Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
                                                            {
                                                                GlobalPropertyMatchingID = "mm.doc.connect.case.is.for.documentation.only",
                                                                Tenant_RefID = securityTicket.TenantID,
                                                                IsValue_Boolean = true,
                                                                IsDeleted = false,
                                                                PropertyName = "Is For Documentation Only"
                                                            }).SingleOrDefault();

                                                            if (caseProperty == null)
                                                            {
                                                                caseProperty = new ORM_HEC_CAS_Case_UniversalProperty();
                                                                caseProperty.GlobalPropertyMatchingID = "mm.doc.connect.case.is.for.documentation.only";
                                                                caseProperty.IsValue_Boolean = true;
                                                                caseProperty.Modification_Timestamp = DateTime.Now;
                                                                caseProperty.PropertyName = "Is For Documentation Only";
                                                                caseProperty.Tenant_RefID = securityTicket.TenantID;

                                                                caseProperty.Save(cmd25Connection, cmd25Transaction);
                                                            }

                                                            var casePropertyValue = new ORM_HEC_CAS_Case_UniversalPropertyValue();
                                                            casePropertyValue.HEC_CAS_Case_RefID = case_id;
                                                            casePropertyValue.HEC_CAS_Case_UniversalProperty_RefID = caseProperty.HEC_CAS_Case_UniversalPropertyID;
                                                            casePropertyValue.Tenant_RefID = securityTicket.TenantID;
                                                            casePropertyValue.Modification_Timestamp = DateTime.Now;
                                                            casePropertyValue.Value_Boolean = true;

                                                            casePropertyValue.Save(cmd25Connection, cmd25Transaction);

                                                            var missingIvomProperty = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(cmd25Connection, cmd25Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
                                                            {
                                                                GlobalPropertyMatchingID = "mm.doc.connect.case.missing.oct.ivom",
                                                                Tenant_RefID = securityTicket.TenantID,
                                                                IsValue_Boolean = true,
                                                                IsDeleted = false,
                                                                PropertyName = "Is Missing OCT IVOM"
                                                            }).SingleOrDefault();

                                                            if (missingIvomProperty == null)
                                                            {
                                                                missingIvomProperty = new ORM_HEC_CAS_Case_UniversalProperty();
                                                                missingIvomProperty.GlobalPropertyMatchingID = "mm.doc.connect.case.missing.oct.ivom";
                                                                missingIvomProperty.IsValue_Boolean = true;
                                                                missingIvomProperty.Modification_Timestamp = DateTime.Now;
                                                                missingIvomProperty.PropertyName = "Is Missing OCT IVOM";
                                                                missingIvomProperty.Tenant_RefID = securityTicket.TenantID;

                                                                missingIvomProperty.Save(cmd25Connection, cmd25Transaction);
                                                            }

                                                            var missingIvomPropertyValue = new ORM_HEC_CAS_Case_UniversalPropertyValue();
                                                            missingIvomPropertyValue.HEC_CAS_Case_RefID = case_id;
                                                            missingIvomPropertyValue.HEC_CAS_Case_UniversalProperty_RefID = missingIvomProperty.HEC_CAS_Case_UniversalPropertyID;
                                                            missingIvomPropertyValue.Tenant_RefID = securityTicket.TenantID;
                                                            missingIvomPropertyValue.Modification_Timestamp = DateTime.Now;
                                                            missingIvomPropertyValue.Value_Boolean = true;

                                                            missingIvomPropertyValue.Save(cmd25Connection, cmd25Transaction);

                                                            var gpos_header = new ORM_BIL_BillHeader();
                                                            gpos_header.CreatedBy_BusinessParticipant_RefID = bpt_id;
                                                            gpos_header.Modification_Timestamp = DateTime.Now;
                                                            gpos_header.Tenant_RefID = securityTicket.TenantID;

                                                            var bill_header_history_entry = new ORM_BIL_BillHeader_History();
                                                            bill_header_history_entry.BillHeader_RefID = gpos_header.BIL_BillHeaderID;
                                                            bill_header_history_entry.Comment = "Doctor";
                                                            bill_header_history_entry.IsCreated = true;
                                                            bill_header_history_entry.Modification_Timestamp = DateTime.Now;
                                                            bill_header_history_entry.Tenant_RefID = securityTicket.TenantID;
                                                            bill_header_history_entry.TriggeredBy_BusinessParticipant_RefID = bpt_id;

                                                            bill_header_history_entry.Save(cmd25Connection, cmd25Transaction);

                                                            var hec_gpos_header = new ORM_HEC_BIL_BillHeader();
                                                            hec_gpos_header.Ext_BIL_BillHeader_RefID = gpos_header.BIL_BillHeaderID;
                                                            hec_gpos_header.Modification_Timestamp = DateTime.Now;
                                                            hec_gpos_header.Patient_RefID = patientId;
                                                            hec_gpos_header.Tenant_RefID = securityTicket.TenantID;

                                                            hec_gpos_header.Save(cmd25Connection, cmd25Transaction);

                                                            decimal sum_total = 0;
                                                            var bill_position_ids = cls_Get_BillPositionIDs_for_CaseID.Invoke(cmd25Connection, cmd25Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = case_id }, securityTicket).Result;
                                                            if (bill_position_ids.Length != 0)
                                                            {
                                                                ORM_BIL_BillPosition.Query bill_positionQ = new ORM_BIL_BillPosition.Query();
                                                                bill_positionQ.IsDeleted = false;
                                                                bill_positionQ.Tenant_RefID = securityTicket.TenantID;

                                                                var latest = 0;
                                                                var latestBill = cls_Get_Latest_Bill_Position_Number.Invoke(cmd25Connection, cmd25Transaction, securityTicket).Result;
                                                                if (latestBill != null && !string.IsNullOrEmpty(latestBill.latest_bill_position_number))
                                                                {
                                                                    latest = Convert.ToInt32(latestBill.latest_bill_position_number);
                                                                }
                                                                foreach (var id in bill_position_ids)
                                                                {
                                                                    bill_positionQ.BIL_BillPositionID = id.bill_position_id;
                                                                    var bill_position = ORM_BIL_BillPosition.Query.Search(cmd25Connection, cmd25Transaction, bill_positionQ).SingleOrDefault();
                                                                    if (bill_position != null)
                                                                    {
                                                                        bill_position.BIL_BilHeader_RefID = gpos_header.BIL_BillHeaderID;
                                                                        if (string.IsNullOrEmpty(bill_position.PositionNumber))
                                                                        {
                                                                            bill_position.PositionNumber = SynchronizedSequentialNumberGenerator.Instance.Generate(latest).ToString();
                                                                        }

                                                                        bill_position.Save(cmd25Connection, cmd25Transaction);

                                                                        sum_total += bill_position.PositionValue_IncludingTax;
                                                                    }

                                                                    var billing_code = cls_Get_BillingCode_for_CaseBillCodeID.Invoke(cmd25Connection, cmd25Transaction, new P_CAS_GBCfCBCID_1334() { CaseBillCodeID = id.hec_case_bill_code_id }, securityTicket).Result;
                                                                    if (billing_code != null)
                                                                    {
                                                                        if (id.gpos_type == gpos_type)
                                                                        {

                                                                            ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                                                            position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                                                            position_status.BillPosition_RefID = id.bill_position_id;
                                                                            position_status.Creation_Timestamp = DateTime.Now;
                                                                            position_status.IsActive = true;
                                                                            position_status.Modification_Timestamp = DateTime.Now;
                                                                            position_status.TransmitionCode = 13;
                                                                            position_status.TransmittedOnDate = DateTime.Now;
                                                                            position_status.Tenant_RefID = securityTicket.TenantID;
                                                                            position_status.TransmitionStatusKey = "treatment";

                                                                            position_status.Save(cmd25Connection, cmd25Transaction);
                                                                        }
                                                                    }
                                                                }
                                                            }

                                                            gpos_header.TotalValue_IncludingTax = sum_total;
                                                            gpos_header.Save(cmd25Connection, cmd25Transaction);

                                                            var treatment_planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(cmd25Connection, cmd25Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result;
                                                            if (treatment_planned_action_id != null)
                                                            {
                                                                var treatment_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                                                                treatment_planned_actionQ.HEC_ACT_PlannedActionID = treatment_planned_action_id.planned_action_id;
                                                                treatment_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                                                                treatment_planned_actionQ.IsDeleted = false;
                                                                treatment_planned_actionQ.IsPerformed = false;

                                                                var treatment_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(cmd25Connection, cmd25Transaction, treatment_planned_actionQ).SingleOrDefault();
                                                                if (treatment_planned_action != null)
                                                                {
                                                                    var treatment_performed_action = new ORM_HEC_ACT_PerformedAction();
                                                                    treatment_performed_action.Creation_Timestamp = DateTime.Now;
                                                                    treatment_performed_action.HEC_ACT_PerformedActionID = Guid.NewGuid();
                                                                    treatment_performed_action.IfPerfomed_DateOfAction = treatment_planned_action.PlannedFor_Date;
                                                                    treatment_performed_action.IfPerformed_DateOfAction_Day = treatment_planned_action.PlannedFor_Date.Day;
                                                                    treatment_performed_action.IfPerformed_DateOfAction_Month = treatment_planned_action.PlannedFor_Date.Month;
                                                                    treatment_performed_action.IfPerformed_DateOfAction_Year = treatment_planned_action.PlannedFor_Date.Year;
                                                                    treatment_performed_action.IfPerformedInternaly_ResponsibleBusinessParticipant_RefID = bpt_id;
                                                                    treatment_performed_action.IsPerformed_MedicalPractice_RefID = practiceId;
                                                                    treatment_performed_action.Modification_Timestamp = DateTime.Now;
                                                                    treatment_performed_action.Patient_RefID = patientId;
                                                                    treatment_performed_action.Tenant_RefID = securityTicket.TenantID;
                                                                    treatment_performed_action.Save(cmd25Connection, cmd25Transaction);

                                                                    var treatment_perf_action_type = ORM_HEC_ACT_ActionType.Query.Search(cmd25Connection, cmd25Transaction, new ORM_HEC_ACT_ActionType.Query()
                                                                    {
                                                                        GlobalPropertyMatchingID = "mm.docconect.doc.app.performed.action.treatment",
                                                                        Tenant_RefID = securityTicket.TenantID,
                                                                        IsDeleted = false
                                                                    }).SingleOrDefault();

                                                                    if (treatment_perf_action_type == null)
                                                                    {
                                                                        treatment_perf_action_type = new ORM_HEC_ACT_ActionType();
                                                                        treatment_perf_action_type.GlobalPropertyMatchingID = "mm.docconect.doc.app.performed.action.treatment";
                                                                        treatment_perf_action_type.Modification_Timestamp = DateTime.Now;
                                                                        treatment_perf_action_type.Tenant_RefID = securityTicket.TenantID;

                                                                        treatment_perf_action_type.Save(cmd25Connection, cmd25Transaction);
                                                                    }

                                                                    var treatment_performed_action_type_id = treatment_perf_action_type.HEC_ACT_ActionTypeID;
                                                                    var treatment_performed_action_2_type = new ORM_HEC_ACT_PerformedAction_2_ActionType();
                                                                    treatment_performed_action_2_type.AssignmentID = Guid.NewGuid();
                                                                    treatment_performed_action_2_type.Creation_Timestamp = DateTime.Now;
                                                                    treatment_performed_action_2_type.HEC_ACT_ActionType_RefID = treatment_performed_action_type_id;
                                                                    treatment_performed_action_2_type.HEC_ACT_PerformedAction_RefID = treatment_performed_action.HEC_ACT_PerformedActionID;
                                                                    treatment_performed_action_2_type.IM_ActionType_Name = "Treatment";
                                                                    treatment_performed_action_2_type.Tenant_RefID = securityTicket.TenantID;
                                                                    treatment_performed_action_2_type.Modification_Timestamp = DateTime.Now;

                                                                    treatment_performed_action_2_type.Save(cmd25Connection, cmd25Transaction);

                                                                    treatment_planned_action.IsPerformed = true;
                                                                    treatment_planned_action.IfPerformed_PerformedAction_RefID = treatment_performed_action.HEC_ACT_PerformedActionID;
                                                                    treatment_planned_action.Modification_Timestamp = DateTime.Now;

                                                                    treatment_planned_action.Save(cmd25Connection, cmd25Transaction);

                                                                    var patient_diagnosis = new ORM_HEC_Patient_Diagnosis();
                                                                    patient_diagnosis.Creation_Timestamp = DateTime.Now;
                                                                    patient_diagnosis.HEC_Patient_DiagnosisID = Guid.NewGuid();
                                                                    patient_diagnosis.Modification_Timestamp = DateTime.Now;
                                                                    patient_diagnosis.Patient_RefID = patientId;
                                                                    patient_diagnosis.R_IsConfirmed = true;
                                                                    patient_diagnosis.R_PotentialDiagnosis_RefID = randomDrugDiagnoseCombo.PotentialDiagnosis_RefID;
                                                                    patient_diagnosis.Tenant_RefID = securityTicket.TenantID;

                                                                    patient_diagnosis.Save(cmd25Connection, cmd25Transaction);

                                                                    var treatment_diagnosis_update = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate();
                                                                    treatment_diagnosis_update.Creation_Timestamp = DateTime.Now;
                                                                    treatment_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID = Guid.NewGuid();
                                                                    treatment_diagnosis_update.HEC_ACT_PerformedAction_RefID = treatment_performed_action.HEC_ACT_PerformedActionID;
                                                                    treatment_diagnosis_update.PotentialDiagnosis_RefID = randomDrugDiagnoseCombo.PotentialDiagnosis_RefID;
                                                                    treatment_diagnosis_update.IsDiagnosisConfirmed = true;
                                                                    treatment_diagnosis_update.Modification_Timestamp = DateTime.Now;
                                                                    treatment_diagnosis_update.Tenant_RefID = securityTicket.TenantID;
                                                                    treatment_diagnosis_update.HEC_Patient_Diagnosis_RefID = patient_diagnosis != null ? patient_diagnosis.HEC_Patient_DiagnosisID : Guid.Empty;

                                                                    treatment_diagnosis_update.Save(cmd25Connection, cmd25Transaction);

                                                                    var diagnosis_localization = new ORM_HEC_DIA_Diagnosis_Localization();
                                                                    diagnosis_localization.Creation_Timestamp = DateTime.Now;
                                                                    diagnosis_localization.Diagnosis_RefID = randomDrugDiagnoseCombo.PotentialDiagnosis_RefID; ;
                                                                    diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID = Guid.NewGuid();
                                                                    diagnosis_localization.Modification_Timestamp = DateTime.Now;
                                                                    diagnosis_localization.Tenant_RefID = securityTicket.TenantID;
                                                                    diagnosis_localization.LocalizationCode = localization.Key;

                                                                    diagnosis_localization.Save(cmd25Connection, cmd25Transaction);

                                                                    var treatment_diagnosis_update_localization = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization();
                                                                    treatment_diagnosis_update_localization.Creation_Timestamp = DateTime.Now;
                                                                    treatment_diagnosis_update_localization.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID = Guid.NewGuid();
                                                                    treatment_diagnosis_update_localization.HEX_EXC_Action_DiagnosisUpdate_RefID = treatment_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID;
                                                                    treatment_diagnosis_update_localization.HEC_DIA_Diagnosis_Localization_RefID = diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID;
                                                                    treatment_diagnosis_update_localization.IM_PotentialDiagnosisLocalization_Code = localization.Key;
                                                                    treatment_diagnosis_update_localization.Tenant_RefID = securityTicket.TenantID;
                                                                    treatment_diagnosis_update_localization.Modification_Timestamp = DateTime.Now;

                                                                    treatment_diagnosis_update_localization.Save(cmd25Connection, cmd25Transaction);

                                                                    var aftercare_planned_action_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(cmd25Connection, cmd25Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_id }, securityTicket).Result;
                                                                    if (aftercare_planned_action_id != null)
                                                                    {
                                                                        var aftercare_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                                                                        aftercare_planned_actionQ.HEC_ACT_PlannedActionID = aftercare_planned_action_id.planned_action_id;
                                                                        aftercare_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                                                                        aftercare_planned_actionQ.IsDeleted = false;
                                                                        aftercare_planned_actionQ.IsPerformed = false;
                                                                        aftercare_planned_actionQ.HEC_ACT_PlannedActionID = aftercare_planned_action_id.planned_action_id;
                                                                        var aftercare_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(cmd25Connection, cmd25Transaction, aftercare_planned_actionQ).SingleOrDefault();
                                                                        if (aftercare_planned_action != null)
                                                                        {
                                                                            aftercare_planned_action.IfPlannedFollowup_PreviousAction_RefID = treatment_performed_action.HEC_ACT_PerformedActionID;
                                                                            aftercare_planned_action.Modification_Timestamp = DateTime.Now;

                                                                            aftercare_planned_action.Save(cmd25Connection, cmd25Transaction);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            #endregion
                                                        }
                                                        else
                                                        {
                                                            #region Cancel planned IVOM
                                                            var treatment_planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(cmd25Connection, cmd25Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result;
                                                            if (treatment_planned_action_id != null)
                                                            {
                                                                var treatment_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                                                                treatment_planned_actionQ.HEC_ACT_PlannedActionID = treatment_planned_action_id.planned_action_id;
                                                                treatment_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                                                                treatment_planned_actionQ.IsDeleted = false;
                                                                treatment_planned_actionQ.IsPerformed = false;

                                                                var treatment_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(cmd25Connection, cmd25Transaction, treatment_planned_actionQ).SingleOrDefault();
                                                                if (treatment_planned_action != null)
                                                                {
                                                                    treatment_planned_action.IsCancelled = true;
                                                                    treatment_planned_action.Save(cmd25Connection, cmd25Transaction);
                                                                }

                                                                new_case.Remove(cmd25Connection, cmd25Transaction);
                                                            }
                                                            #endregion
                                                        }

                                                        localizationCaseData.Add(new CAS_GCDoT_1825()
                                                        {
                                                            Case_RefID = case_id,
                                                            CaseNumber = new_case.CaseNumber,
                                                            HealthcareProduct_RefID = randomDrugDiagnoseCombo.HealthcareProduct_RefID,
                                                            IM_PotentialDiagnosisLocalization_Code = localization.Key,
                                                            IsPerformed = true,
                                                            Patient_RefID = patientId,
                                                            PlannedFor_Date = op_date,
                                                            PotentialDiagnosis_RefID = randomDrugDiagnoseCombo.PotentialDiagnosis_RefID
                                                        });
                                                    }

                                                    var closestCase = localizationCaseData.Last();
                                                    var latestPreexamination = localization.Value.OrderByDescending(t => t.Value.First().PlannedFor_Date).First().Value.First();

                                                    foreach (var preexaminationCase in localization.Value)
                                                    {
                                                        File.AppendAllText(filePath, "--------------------------------------\n");
                                                        var preexamination = preexaminationCase.Value.First();

                                                        File.AppendAllText(filePath, String.Format("Case: {0}\n", preexamination.CaseNumber));
                                                        File.AppendAllText(filePath, String.Format("\tPatient name: {0}\n", patientName));
                                                        File.AppendAllText(filePath, String.Format("\tPerformed on date: {0}\n", preexamination.PlannedFor_Date.ToString("dd.MM.yyyy")));
                                                        File.AppendAllText(filePath, String.Format("\tLocalization: {0}\n", preexamination.IM_PotentialDiagnosisLocalization_Code));

                                                        #region delete old data

                                                        ORM_HEC_CAS_Case.Query.SoftDelete(cmd25Connection, cmd25Transaction, new ORM_HEC_CAS_Case.Query()
                                                        {
                                                            HEC_CAS_CaseID = preexamination.Case_RefID
                                                        });

                                                        ORM_HEC_ACT_PlannedAction_2_ActionType.Query.SoftDelete(cmd25Connection, cmd25Transaction, new ORM_HEC_ACT_PlannedAction_2_ActionType.Query()
                                                        {
                                                            HEC_ACT_PlannedAction_RefID = preexamination.HEC_ACT_PlannedActionID
                                                        });

                                                        ORM_HEC_CAS_Case_RelevantPerformedAction.Query.SoftDelete(cmd25Connection, cmd25Transaction, new ORM_HEC_CAS_Case_RelevantPerformedAction.Query()
                                                        {
                                                            Case_RefID = preexamination.Case_RefID
                                                        });

                                                        ORM_HEC_ACT_PerformedAction.Query.SoftDelete(cmd25Connection, cmd25Transaction, new ORM_HEC_ACT_PerformedAction.Query()
                                                        {
                                                            HEC_ACT_PerformedActionID = preexamination.IfPerformed_PerformedAction_RefID
                                                        });

                                                        ORM_HEC_ACT_PerformedAction_2_ActionType.Query.SoftDelete(cmd25Connection, cmd25Transaction, new ORM_HEC_ACT_PerformedAction_2_ActionType.Query()
                                                        {
                                                            HEC_ACT_PerformedAction_RefID = preexamination.IfPerformed_PerformedAction_RefID
                                                        });

                                                        #endregion

                                                        File.AppendAllText(filePath, String.Format("Attached to case: {0}\n", closestCase.CaseNumber));
                                                        File.AppendAllText(filePath, String.Format("\tPatient name: {0}\n", patientName));
                                                        File.AppendAllText(filePath, String.Format("\tPerformed on date: {0}\n", closestCase.PlannedFor_Date.ToString("dd.MM.yyyy")));
                                                        File.AppendAllText(filePath, String.Format("\tLocalization: {0}\n", closestCase.IM_PotentialDiagnosisLocalization_Code));

                                                        File.AppendAllText(filePath, "out of possible cases: \n");
                                                        File.AppendAllText(filePath, "\t------------------------------\n");
                                                        for (var i = 0; i < localizationCaseData.Count; i++)
                                                        {
                                                            var _case = localizationCaseData[i];
                                                            File.AppendAllText(filePath, String.Format("\tCase number: {0}\n", _case.CaseNumber));
                                                            File.AppendAllText(filePath, String.Format("\tPerformed on date: {0}\n", _case.PlannedFor_Date.ToString("dd.MM.yyyy")));
                                                            if (i != localizationCaseData.Count - 1)
                                                            {
                                                                File.AppendAllText(filePath, "\t------------------------------\n");
                                                            }
                                                        }
                                                        File.AppendAllText(filePath, "\t------------------------------\n");

                                                        var caseBillCode = new ORM_HEC_CAS_Case_BillCode();
                                                        caseBillCode.Load(cmd25Connection, cmd25Transaction, preexamination.HEC_CAS_Case_BillCodeID);

                                                        caseBillCode.HEC_CAS_Case_RefID = closestCase.Case_RefID;
                                                        caseBillCode.Modification_Timestamp = DateTime.Now;

                                                        caseBillCode.Save(cmd25Connection, cmd25Transaction);

                                                        var octPlannedAction = new ORM_HEC_ACT_PlannedAction();
                                                        octPlannedAction.Load(cmd25Connection, cmd25Transaction, preexamination.HEC_ACT_PlannedActionID);

                                                        var newCaseRelevantAction = new ORM_HEC_CAS_Case_RelevantPlannedAction();
                                                        newCaseRelevantAction.Creation_Timestamp = octPlannedAction.Creation_Timestamp;
                                                        newCaseRelevantAction.Case_RefID = closestCase.Case_RefID;
                                                        newCaseRelevantAction.Modification_Timestamp = DateTime.Now;
                                                        newCaseRelevantAction.PlannedAction_RefID = preexamination.HEC_ACT_PlannedActionID;
                                                        newCaseRelevantAction.Tenant_RefID = securityTicket.TenantID;

                                                        newCaseRelevantAction.Save(cmd25Connection, cmd25Transaction);

                                                        var newPlannedActionType = new ORM_HEC_ACT_PlannedAction_2_ActionType();
                                                        newPlannedActionType.HEC_ACT_ActionType_RefID = octPlannedActionType.HEC_ACT_ActionTypeID;
                                                        newPlannedActionType.HEC_ACT_PlannedAction_RefID = preexamination.HEC_ACT_PlannedActionID;
                                                        newPlannedActionType.Modification_Timestamp = DateTime.Now;
                                                        newPlannedActionType.Tenant_RefID = securityTicket.TenantID;

                                                        newPlannedActionType.Save(cmd25Connection, cmd25Transaction);

                                                        var octPerformedAction = new ORM_HEC_ACT_PerformedAction();
                                                        octPerformedAction.IfPerfomed_DateOfAction = octPlannedAction.PlannedFor_Date;
                                                        octPerformedAction.IfPerformed_DateOfAction_Day = octPlannedAction.PlannedFor_Date.Day;
                                                        octPerformedAction.IfPerformed_DateOfAction_Month = octPlannedAction.PlannedFor_Date.Month;
                                                        octPerformedAction.IfPerformed_DateOfAction_Year = octPlannedAction.PlannedFor_Date.Year;
                                                        octPerformedAction.Modification_Timestamp = DateTime.Now;
                                                        octPerformedAction.IsPerformed_MedicalPractice_RefID = octPlannedAction.MedicalPractice_RefID;
                                                        octPerformedAction.Patient_RefID = octPlannedAction.Patient_RefID;
                                                        octPerformedAction.Tenant_RefID = securityTicket.TenantID;

                                                        octPerformedAction.Save(cmd25Connection, cmd25Transaction);

                                                        octPlannedAction.IfPerformed_PerformedAction_RefID = octPerformedAction.HEC_ACT_PerformedActionID;
                                                        octPlannedAction.Save(cmd25Connection, cmd25Transaction);

                                                        var newPerformedActionType = new ORM_HEC_ACT_PerformedAction_2_ActionType();
                                                        newPerformedActionType.HEC_ACT_ActionType_RefID = octPerformedActionType.HEC_ACT_ActionTypeID;
                                                        newPerformedActionType.HEC_ACT_PerformedAction_RefID = octPerformedAction.HEC_ACT_PerformedActionID;
                                                        newPerformedActionType.Modification_Timestamp = DateTime.Now;
                                                        newPerformedActionType.IM_ActionType_Name = octPerformedActionTypeGpmId;
                                                        newPerformedActionType.Tenant_RefID = securityTicket.TenantID;

                                                        newPerformedActionType.Save(cmd25Connection, cmd25Transaction);

                                                        var performedActionDiagnose = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate();
                                                        performedActionDiagnose.Load(cmd25Connection, cmd25Transaction, preexamination.HEC_ACT_PerformedAction_DiagnosisUpdateID);
                                                        performedActionDiagnose.HEC_ACT_PerformedAction_RefID = octPerformedAction.HEC_ACT_PerformedActionID;
                                                        performedActionDiagnose.PotentialDiagnosis_RefID = closestCase.PotentialDiagnosis_RefID;
                                                        performedActionDiagnose.Modification_Timestamp = DateTime.Now;

                                                        performedActionDiagnose.Save(cmd25Connection, cmd25Transaction);

                                                        foreach (var preexaminationFsStatus in preexaminationCase.Value)
                                                        {
                                                            var fsStatus = new ORM_BIL_BillPosition_TransmitionStatus();
                                                            fsStatus.Load(cmd25Connection, cmd25Transaction, preexaminationFsStatus.BIL_BillPosition_TransmitionStatusID);

                                                            fsStatus.TransmitionStatusKey = "oct";
                                                            fsStatus.Save(cmd25Connection, cmd25Transaction);
                                                        }

                                                        var existing_bill = cls_Get_ExistingBillPosition_for_PatientID_and_LocalizationCode.Invoke(cmd25Connection, cmd25Transaction, new P_CAS_GEBPfPIDaLC_1803()
                                                        {
                                                            PatientID = preexamination.Patient_RefID,
                                                            LocalizationCode = preexamination.IM_PotentialDiagnosisLocalization_Code
                                                        }, securityTicket).Result;

                                                        if (existing_bill == null)
                                                        {
                                                            Thread.Sleep(1000);

                                                            var latestOctPLannedAction = new ORM_HEC_ACT_PlannedAction();
                                                            latestOctPLannedAction.Load(cmd25Connection, cmd25Transaction, latestPreexamination.HEC_ACT_PlannedActionID);

                                                            var newOctPlannedAction = new ORM_HEC_ACT_PlannedAction();
                                                            newOctPlannedAction.MedicalPractice_RefID = latestOctPLannedAction.MedicalPractice_RefID;
                                                            newOctPlannedAction.Patient_RefID = latestOctPLannedAction.Patient_RefID;
                                                            newOctPlannedAction.Tenant_RefID = securityTicket.TenantID;
                                                            newOctPlannedAction.ToBePerformedBy_BusinessParticipant_RefID = latestOctPLannedAction.ToBePerformedBy_BusinessParticipant_RefID;

                                                            newOctPlannedAction.Save(cmd25Connection, cmd25Transaction);

                                                            var newOctRelevantPlannedAction = new ORM_HEC_CAS_Case_RelevantPlannedAction();
                                                            newOctRelevantPlannedAction.Case_RefID = closestCase.Case_RefID;
                                                            newOctRelevantPlannedAction.PlannedAction_RefID = newOctPlannedAction.HEC_ACT_PlannedActionID;
                                                            newOctRelevantPlannedAction.Tenant_RefID = securityTicket.TenantID;
                                                            newOctRelevantPlannedAction.Modification_Timestamp = DateTime.Now;

                                                            newOctRelevantPlannedAction.Save(cmd25Connection, cmd25Transaction);

                                                            var newOctPlannedAction_2_type = new ORM_HEC_ACT_PlannedAction_2_ActionType();
                                                            newOctPlannedAction_2_type.HEC_ACT_ActionType_RefID = octPlannedActionType.HEC_ACT_ActionTypeID;
                                                            newOctPlannedAction_2_type.HEC_ACT_PlannedAction_RefID = newOctPlannedAction.HEC_ACT_PlannedActionID;
                                                            newOctPlannedAction_2_type.Modification_Timestamp = DateTime.Now;
                                                            newOctPlannedAction_2_type.Tenant_RefID = securityTicket.TenantID;

                                                            newOctPlannedAction_2_type.Save(cmd25Connection, cmd25Transaction);

                                                            cls_Calculate_Case_GPOS.Invoke(cmd25Connection, cmd25Transaction, new P_CAS_CCGPOS_1000()
                                                            {
                                                                case_id = closestCase.Case_RefID,
                                                                diagnose_id = closestCase.PotentialDiagnosis_RefID,
                                                                drug_id = closestCase.HealthcareProduct_RefID,
                                                                patient_id = preexamination.Patient_RefID,
                                                                localization = preexamination.IM_PotentialDiagnosisLocalization_Code,
                                                                treatment_date = preexamination.PlannedFor_Date,
                                                                oct_doctor_id = Guid.NewGuid()
                                                            }, securityTicket);
                                                        }

                                                        File.AppendAllText(filePath, "--------------------------------------\n");
                                                    }
                                                }
                                            }

                                            Console.WriteLine("File saved to: {0}", filePath);
                                            Console.WriteLine();
                                            Console.WriteLine("Save changes? [y/n]");
                                            if (Console.ReadLine().ToLower() == "y")
                                            {
                                                cmd25Transaction.Commit();
                                            }
                                            else
                                            {
                                                isCommand4Executed = false;
                                            }

                                            break;
                                        }
                                        catch (Exception ex)
                                        {
                                            if (cmd25Transaction != null)
                                            {
                                                cmd25Transaction.Rollback();
                                            }

                                            Console.WriteLine(ex.Message);
                                            Console.WriteLine(ex.StackTrace);

                                            Console.Read();
                                            break;
                                        }
                                        finally
                                        {
                                            if (cmd25Connection.State == System.Data.ConnectionState.Open)
                                            {
                                                cmd25Connection.Close();
                                            }
                                        }
                                    #endregion

                                    #region Command 26
                                    case "26":
                                        var cmd26Connection = DBSQLSupport.CreateConnection(connectionString);
                                        DbTransaction cmd26Transaction = null;

                                        try
                                        {
                                            cmd26Connection.Open();
                                            cmd26Transaction = cmd26Connection.BeginTransaction();

                                            var octPlannedActionTypeGpmId = "mm.docconect.doc.app.planned.action.oct";
                                            var action_types = ORM_HEC_ACT_ActionType.Query.Search(cmd26Connection, cmd26Transaction, new ORM_HEC_ACT_ActionType.Query()
                                            {
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).Where(t => t.GlobalPropertyMatchingID == octPlannedActionTypeGpmId).ToList();

                                            var octPerformedActionTypeGpmId = "mm.docconect.doc.app.performed.action.oct";
                                            var octPerformedActionType = ORM_HEC_ACT_ActionType.Query.Search(cmd26Connection, cmd26Transaction, new ORM_HEC_ACT_ActionType.Query()
                                            {
                                                GlobalPropertyMatchingID = octPerformedActionTypeGpmId,
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).SingleOrDefault();

                                            if (octPerformedActionType == null)
                                            {
                                                octPerformedActionType = new ORM_HEC_ACT_ActionType();
                                                octPerformedActionType.GlobalPropertyMatchingID = octPerformedActionTypeGpmId;
                                                octPerformedActionType.Modification_Timestamp = DateTime.Now;
                                                octPerformedActionType.Tenant_RefID = securityTicket.TenantID;

                                                octPerformedActionType.Save(cmd26Connection, cmd26Transaction);
                                            }

                                            foreach (var act_type in action_types)
                                            {
                                                var performed_action_connections = ORM_HEC_ACT_PerformedAction_2_ActionType.Query.Search(cmd26Connection, cmd26Transaction, new ORM_HEC_ACT_PerformedAction_2_ActionType.Query()
                                                {
                                                    HEC_ACT_ActionType_RefID = act_type.HEC_ACT_ActionTypeID,
                                                    Tenant_RefID = securityTicket.TenantID,
                                                    IsDeleted = false
                                                });
                                                if (performed_action_connections.Any())
                                                {
                                                    act_type.Remove(cmd26Connection, cmd26Transaction);

                                                    foreach (var conn in performed_action_connections)
                                                    {
                                                        conn.HEC_ACT_ActionType_RefID = octPerformedActionType.HEC_ACT_ActionTypeID;
                                                        conn.Save(cmd26Connection, cmd26Transaction);
                                                    }
                                                }
                                            }

                                            cmd26Transaction.Commit();
                                            break;
                                        }
                                        catch (Exception ex)
                                        {
                                            if (cmd26Transaction != null)
                                            {
                                                cmd26Transaction.Rollback();
                                            }

                                            Console.WriteLine(ex.Message);
                                            Console.Read();
                                            break;
                                        }
                                        finally
                                        {
                                            if (cmd26Connection.State == System.Data.ConnectionState.Open)
                                            {
                                                cmd26Connection.Close();
                                            }
                                        }
                                    #endregion

                                    #region Command 27
                                    case "27":
                                        var cmd27Connection = DBSQLSupport.CreateConnection(connectionString);
                                        DbTransaction cmd27Transaction = null;

                                        try
                                        {
                                            cmd27Connection.Open();
                                            cmd27Transaction = cmd27Connection.BeginTransaction();

                                            isCommand4Executed = false;
                                            var patients = cls_Get_PatientIDs_with_Participation_with_GposType.Invoke(cmd27Connection, cmd27Transaction, new P_PA_GPIDswPwGposT_1731()
                                            {
                                                GposType = "mm.docconnect.gpos.catalog.voruntersuchung"
                                            }, securityTicket).Result;

                                            var patient_ids = new Guid[] { };

                                            if (patients.Any())
                                            {
                                                patient_ids = patients.Select(t => t.patient_id).ToArray();
                                            }

                                            var octPlannedActionTypeGpmId = "mm.docconect.doc.app.planned.action.oct";
                                            var octPlannedActionType = ORM_HEC_ACT_ActionType.Query.Search(cmd27Connection, cmd27Transaction, new ORM_HEC_ACT_ActionType.Query()
                                            {
                                                GlobalPropertyMatchingID = octPlannedActionTypeGpmId,
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).SingleOrDefault();

                                            var case_ids_with_open_octs = new List<Guid>();

                                            if (octPlannedActionType == null)
                                            {
                                                octPlannedActionType = new ORM_HEC_ACT_ActionType();
                                                octPlannedActionType.GlobalPropertyMatchingID = octPlannedActionTypeGpmId;
                                                octPlannedActionType.Modification_Timestamp = DateTime.Now;
                                                octPlannedActionType.Tenant_RefID = securityTicket.TenantID;

                                                octPlannedActionType.Save(cmd27Connection, cmd27Transaction);
                                            }
                                            if (!patient_ids.Any())
                                            {
                                                Console.WriteLine("No BARMER patients found.");
                                                Console.Read();
                                                break;
                                            }
                                            var missingOctsFilePath = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Add-missing-OCTsS.txt");
                                            var cases = cls_Get_Cases_without_Octs_for_PatientIDs.Invoke(cmd27Connection, cmd27Transaction, new P_CAS_GCwOctsfPIDs_1738()
                                            {
                                                PatientIDs = patient_ids
                                            }, securityTicket).Result;

                                            var fs_statuses = cls_Get_Case_FS_Statuses_on_Tenant.Invoke(cmd27Connection, cmd27Transaction, securityTicket).Result.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.Where(x => x.gpos_type == "mm.docconnect.gpos.catalog.operation").ToList());

                                            if (!cases.Any())
                                            {
                                                Console.WriteLine("No cases with missing octs found.");
                                                Console.Read();
                                                break;
                                            }

                                            var case_ids = cases.Select(t => t.case_id).ToArray();

                                            var relevant_octs = cls_Get_RelevantOctActions_for_CaseIDs.Invoke(cmd27Connection, cmd27Transaction, new P_CAS_GROctsfCIDs_0835()
                                            {
                                                OctPlannedActionTypeID = octPlannedActionType.HEC_ACT_ActionTypeID,
                                                CaseIDs = case_ids
                                            }, securityTicket).Result;

                                            cases = cases.Where(t =>
                                            {
                                                var case_not_cancelled = fs_statuses.ContainsKey(t.case_id) ? !fs_statuses[t.case_id].Any(fs => fs.case_fs_status_code == 8 || fs.case_fs_status_code == 11 || fs.case_fs_status_code == 17) : true;
                                                var no_existing_oct = !relevant_octs.Any(r => r.case_id == t.case_id);

                                                return case_not_cancelled && no_existing_oct;
                                            }).OrderByDescending(t => t.creation_date).ToArray();

                                            var existing_octs = cls_Get_ExistingOcts_for_PatientIDs.Invoke(cmd27Connection, cmd27Transaction, new P_CAS_GEOctsfPIDs_1748()
                                            {
                                                OctPlannedActionTypeID = octPlannedActionType.HEC_ACT_ActionTypeID,
                                                PatientIDs = patient_ids
                                            }, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(x => x.localization).ToDictionary(x => x.Key, x => x.ToList()));

                                            var patient_info = cls_Get_Patient_Details_on_Tenant.Invoke(cmd27Connection, cmd27Transaction, securityTicket).Result.GroupBy(t => t.id).ToDictionary(t => t.Key, t => t.Single());

                                            var doctors = cls_Get_DoctorBptIDs_with_PracticeID_on_Tenant.Invoke(cmd27Connection, cmd27Transaction, securityTicket).Result.GroupBy(t => t.doctor_bpt_id).ToDictionary(t => t.Key, t => t.Single().practice_id);

                                            File.AppendAllText(missingOctsFilePath, "Cases:\n");
                                            var total = 0;
                                            foreach (var _case in cases)
                                            {
                                                if (existing_octs.ContainsKey(_case.patient_id))
                                                {
                                                    var existting_patient_octs = existing_octs[_case.patient_id];
                                                    if (existting_patient_octs.ContainsKey(_case.localization))
                                                    {
                                                        continue;
                                                    }
                                                }

                                                if (!doctors.ContainsKey(_case.op_doctor_bpt_id))
                                                {
                                                    continue;
                                                }

                                                var newOctPlannedAction = new ORM_HEC_ACT_PlannedAction();
                                                newOctPlannedAction.MedicalPractice_RefID = doctors[_case.op_doctor_bpt_id];
                                                newOctPlannedAction.Patient_RefID = _case.patient_id;
                                                newOctPlannedAction.Tenant_RefID = securityTicket.TenantID;
                                                newOctPlannedAction.ToBePerformedBy_BusinessParticipant_RefID = _case.op_doctor_bpt_id;

                                                newOctPlannedAction.Save(cmd27Connection, cmd27Transaction);

                                                var newOctRelevantPlannedAction = new ORM_HEC_CAS_Case_RelevantPlannedAction();
                                                newOctRelevantPlannedAction.Case_RefID = _case.case_id;
                                                newOctRelevantPlannedAction.PlannedAction_RefID = newOctPlannedAction.HEC_ACT_PlannedActionID;
                                                newOctRelevantPlannedAction.Tenant_RefID = securityTicket.TenantID;
                                                newOctRelevantPlannedAction.Modification_Timestamp = DateTime.Now;

                                                newOctRelevantPlannedAction.Save(cmd27Connection, cmd27Transaction);

                                                var newOctPlannedAction_2_type = new ORM_HEC_ACT_PlannedAction_2_ActionType();
                                                newOctPlannedAction_2_type.HEC_ACT_ActionType_RefID = octPlannedActionType.HEC_ACT_ActionTypeID;
                                                newOctPlannedAction_2_type.HEC_ACT_PlannedAction_RefID = newOctPlannedAction.HEC_ACT_PlannedActionID;
                                                newOctPlannedAction_2_type.Modification_Timestamp = DateTime.Now;
                                                newOctPlannedAction_2_type.Tenant_RefID = securityTicket.TenantID;

                                                newOctPlannedAction_2_type.Save(cmd27Connection, cmd27Transaction);

                                                cls_Calculate_Case_GPOS.Invoke(cmd27Connection, cmd27Transaction, new P_CAS_CCGPOS_1000()
                                                {
                                                    case_id = _case.case_id,
                                                    diagnose_id = _case.diagnose_id,
                                                    drug_id = _case.drug_id,
                                                    patient_id = _case.patient_id,
                                                    localization = _case.localization,
                                                    treatment_date = _case.op_date,
                                                    oct_doctor_id = Guid.NewGuid()
                                                }, securityTicket);

                                                total++;
                                                var patient_details = patient_info[_case.patient_id];
                                                File.AppendAllText(missingOctsFilePath, String.Format("\nCase [{0}] performed on date {1}: {2}, {3} ({4})", _case.case_number,
                                                    _case.op_date.ToString("dd.MM.yyyy"),
                                                    patient_details.patient_last_name,
                                                    patient_details.patient_first_name,
                                                    patient_details.birthday.ToString("dd.MM.yyyy")
                                                ));

                                                if (!existing_octs.ContainsKey(_case.patient_id))
                                                {
                                                    existing_octs.Add(_case.patient_id, new Dictionary<string, List<CAS_GEOctsfPIDs_1748>>());
                                                }

                                                var existing_patient_octs = existing_octs[_case.patient_id];
                                                if (!existing_patient_octs.ContainsKey(_case.localization))
                                                {
                                                    existing_patient_octs.Add(_case.localization, new List<CAS_GEOctsfPIDs_1748>());
                                                }

                                                existing_patient_octs[_case.localization].Add(new CAS_GEOctsfPIDs_1748()
                                                {
                                                    localization = _case.localization,
                                                    patient_id = _case.patient_id
                                                });
                                            }

                                            Console.WriteLine("Total cases: {0}", total);
                                            Console.WriteLine("File saved to: {0}", missingOctsFilePath);
                                            Console.WriteLine();
                                            Console.WriteLine("Save changes? [y/n]");
                                            if (Console.ReadLine().ToLower() == "y")
                                            {
                                                cmd27Transaction.Commit();
                                                isCommand4Executed = true;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            if (cmd27Transaction != null)
                                            {
                                                cmd27Transaction.Rollback();
                                            }

                                            Console.WriteLine(ex.Message);
                                            Console.WriteLine(ex.StackTrace);
                                            Console.Read();
                                            break;
                                        }
                                        finally
                                        {
                                            if (cmd27Connection.State == System.Data.ConnectionState.Open)
                                            {
                                                cmd27Connection.Close();
                                            }
                                        }

                                        break;
                                    #endregion

                                    #region Command 28
                                    case "28":
                                        var cmd28Connection = DBSQLSupport.CreateConnection(connectionString);
                                        DbTransaction cmd28Transaction = null;

                                        try
                                        {
                                            cmd28Connection.Open();
                                            cmd28Transaction = cmd28Connection.BeginTransaction();

                                            var relevantActions = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(cmd28Connection, cmd28Transaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query()
                                            {
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            });

                                            var plannedActions = ORM_HEC_ACT_PlannedAction.Query.Search(cmd28Connection, cmd28Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                                            {
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            });

                                            foreach (var rel in relevantActions)
                                            {
                                                var pl = plannedActions.First(t => t.HEC_ACT_PlannedActionID == rel.PlannedAction_RefID);
                                                rel.Creation_Timestamp = pl.Creation_Timestamp;

                                                rel.Save(cmd28Connection, cmd28Transaction);
                                            }

                                            cmd28Transaction.Commit();
                                        }
                                        catch (Exception ex)
                                        {
                                            if (cmd28Connection != null)
                                            {
                                                cmd28Transaction.Rollback();
                                            }

                                            Console.WriteLine(ex.Message);
                                            Console.Read();
                                            break;
                                        }
                                        finally
                                        {
                                            if (cmd28Connection.State == System.Data.ConnectionState.Open)
                                            {
                                                cmd28Connection.Close();
                                            }
                                        }

                                        break;
                                    #endregion

                                    #region Command 29
                                    case "29":
                                        var cmd29Connection = DBSQLSupport.CreateConnection(connectionString);
                                        DbTransaction cmd29Transaction = null;

                                        try
                                        {
                                            cmd29Connection.Open();
                                            cmd29Transaction = cmd29Connection.BeginTransaction();

                                            var insurances = ORM_HEC_Patient_HealthInsurance.Query.Search(cmd29Connection, cmd29Transaction, new ORM_HEC_Patient_HealthInsurance.Query()
                                            {
                                                Tenant_RefID = securityTicket.TenantID
                                            })
                                            .Where(t => t.Creation_Timestamp >= new DateTime(2015, 12, 27))
                                            .GroupBy(t => t.Patient_RefID).ToDictionary(t => t.Key, t => t.OrderBy(x => x.Creation_Timestamp).ToList());

                                            foreach (var ins in insurances)
                                            {
                                                var patient_insurances = ins.Value;
                                                if (patient_insurances.Count != 1)
                                                {
                                                    var insurance = patient_insurances.First();
                                                    insurance.Creation_Timestamp = insurance.Creation_Timestamp.AddMonths(1);

                                                    insurance.Save(cmd29Connection, cmd29Transaction);
                                                }
                                            }

                                            cmd29Transaction.Commit();
                                        }
                                        catch (Exception ex)
                                        {
                                            if (cmd29Connection != null)
                                            {
                                                cmd29Transaction.Rollback();
                                            }

                                            Console.WriteLine(ex.Message);
                                            Console.Read();
                                            break;
                                        }
                                        finally
                                        {
                                            if (cmd29Connection.State == System.Data.ConnectionState.Open)
                                            {
                                                cmd29Connection.Close();
                                            }
                                        }

                                        break;
                                    #endregion

                                    #region Command 30
                                    case "30":
                                        using (var c30 = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            c30.Open();
                                            var t30 = c30.BeginTransaction();

                                            var order_ids = cls_Get_all_Cancelled_Orders.Invoke(c30, t30, securityTicket).Result.Select(t => t.order_header_id).ToList();
                                            Console.WriteLine("Found orders: {0}", order_ids.Count);
                                            Console.WriteLine("\nContinue? [y/n]");

                                            var should_continue = Console.ReadLine() == "y";
                                            if (should_continue)
                                            {
                                                foreach (var order_id in order_ids)
                                                {
                                                    var procurmentHeader = ORM_ORD_PRC_ProcurementOrder_Header.Query.Search(c30, t30, new ORM_ORD_PRC_ProcurementOrder_Header.Query()
                                                    {
                                                        IsDeleted = false,
                                                        Tenant_RefID = securityTicket.TenantID,
                                                        ORD_PRC_ProcurementOrder_HeaderID = order_id
                                                    }).Single();

                                                    var newOrderStatus = new ORM_ORD_PRC_ProcurementOrder_Status();
                                                    newOrderStatus.Tenant_RefID = securityTicket.TenantID;
                                                    newOrderStatus.Status_Code = 7;

                                                    newOrderStatus.Save(c30, t30);

                                                    var newOrderStatusHistory = new ORM_ORD_PRC_ProcurementOrder_StatusHistory();
                                                    newOrderStatusHistory.Tenant_RefID = securityTicket.TenantID;
                                                    newOrderStatusHistory.ProcurementOrder_Status_RefID = newOrderStatus.ORD_PRC_ProcurementOrder_StatusID;
                                                    newOrderStatusHistory.IsStatus_RejectedBySupplier = true;
                                                    newOrderStatusHistory.ProcurementOrder_Header_RefID = procurmentHeader.ORD_PRC_ProcurementOrder_HeaderID;

                                                    newOrderStatusHistory.Save(c30, t30);

                                                    procurmentHeader.Current_ProcurementOrderStatus_RefID = newOrderStatus.ORD_PRC_ProcurementOrder_StatusID;
                                                    procurmentHeader.Save(c30, t30);
                                                }
                                            }

                                            t30.Commit();
                                        }

                                        break;
                                    #endregion

                                    #region Command 31
                                    case "31":
                                        using (var c32 = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            c32.Open();
                                            var t32 = c32.BeginTransaction();
                                            var filePath31 = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Cancelled_Cases_transfer_to_FS7_fixing.txt");
                                            if (File.Exists(filePath31))
                                            {
                                                filePath31 = filePath31.Replace(".txt", String.Format("{0}.txt", new Random().Next(1, 100)));
                                            }

                                            Console.WriteLine("Fetching GPOS data.");
                                            var gposes = ORM_HEC_BIL_PotentialCode.Query.Search(c32, t32, new ORM_HEC_BIL_PotentialCode.Query()
                                            {
                                                Tenant_RefID = securityTicket.TenantID
                                            }).GroupBy(t => t.HEC_BIL_PotentialCodeID).ToDictionary(t => t.Key, t => t.First().CodeName.Contents.First().Content);

                                            Console.WriteLine("Fetching FS history.");
                                            var fs_history = cls_Get_Case_FS_Status_History_on_Tenant.Invoke(c32, t32, securityTicket).Result.OrderBy(t => Convert.ToInt32(t.CaseNumber)).ToList();
                                            var bill_positions_fs_history = fs_history.GroupBy(t => t.Ext_BIL_BillPosition_RefID).ToDictionary(t => t.Key, t => t.ToList());

                                            Console.WriteLine("Fetching FS status table entries.");
                                            var all_statuses = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(c32, t32, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                                            {
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).GroupBy(t => t.BIL_BillPosition_TransmitionStatusID).ToDictionary(t => t.Key, t => t.Single());

                                            Console.WriteLine("Scanning FS history for affected cases.");

                                            var affected_cases = fs_history.Where(t =>
                                            {
                                                var bill_position_fs_history = bill_positions_fs_history[t.Ext_BIL_BillPosition_RefID];
                                                var is_paid_status_active = t.IsActive && t.TransmitionCode == 7 && !t.IsTransmitionStatusManuallySet;

                                                var is_wrongfully_transferred = is_paid_status_active
                                                    && !bill_position_fs_history.Any(r => r.TransmitionCode == 11)
                                                    && bill_position_fs_history.Any(r => !r.IsActive && (r.TransmitionCode == 8 || r.TransmitionCode == 17));

                                                if (is_wrongfully_transferred)
                                                {
                                                    File.AppendAllText(filePath31, "--------------------------------------------------------------- \r\n\r\n");
                                                    File.AppendAllText(filePath31, String.Format("Case: {0};\nType: {1} \r\n\r\n", t.CaseNumber, gposes[t.PotentialCode_RefID]));
                                                }
                                                else if (is_paid_status_active && bill_position_fs_history.Any(r => r.TransmitionCode == 11))
                                                {
                                                    File.AppendAllText(filePath31, "----------------------------- Bill position was in FS11 status -------------------------------------- \r\n\r\n");
                                                    File.AppendAllText(filePath31, String.Format("Case: {0};\nType: {1} \r\n\r\n", t.CaseNumber, gposes[t.PotentialCode_RefID]));
                                                }

                                                return is_wrongfully_transferred;
                                            }).ToList();
                                            var cases = fs_history.Where(t => affected_cases.Any(x => x.Ext_BIL_BillPosition_RefID == t.Ext_BIL_BillPosition_RefID)).ToList();
                                            if (cases.Any())
                                            {
                                                File.AppendAllText(filePath31, "--------------------------------------------------------------- \r\n\r\n");
                                                Console.WriteLine("File saved to {0}", filePath31);
                                            }

                                            var casesGrouped = cases.GroupBy(t => t.CaseNumber).ToDictionary(t => t.Key, t => t.GroupBy(r => r.Ext_BIL_BillPosition_RefID).ToDictionary(r => r.Key, r => r.ToList()));

                                            var file_updated = false;
                                            foreach (var _case in casesGrouped)
                                            {
                                                foreach (var caseData in _case.Value)
                                                {
                                                    var billPositionData = caseData.Value.OrderByDescending(t => t.TransmittedOnDate).ToList();
                                                    var real = billPositionData.FirstOrDefault(t => t.TransmitionCode == 8 || t.TransmitionCode == 17);
                                                    if (real == null)
                                                    {
                                                        Console.WriteLine("FS8 status not found for case: {0}", caseData.Value.First().CaseNumber);
                                                        File.AppendAllText(filePath31, "------------------------------------- FS8 Status not found ------------------------------------------- \r\n\r\n");
                                                        File.AppendAllText(filePath31, String.Format("Case: {0};\nBill position id: {1} \r\n\r\n", caseData.Value.First().CaseNumber, caseData.Value.First().Ext_BIL_BillPosition_RefID));
                                                        File.AppendAllText(filePath31, "--------------------------------------------------------------- \r\n\r\n");
                                                        file_updated = true;
                                                        continue;
                                                    }
                                                    var latest = billPositionData.First();

                                                    var current_status = all_statuses[latest.BIL_BillPosition_TransmitionStatusID];

                                                    current_status.IsDeleted = true;
                                                    current_status.Save(c32, t32);
                                                    var realStatus = all_statuses[real.BIL_BillPosition_TransmitionStatusID];

                                                    realStatus.IsActive = true;
                                                    realStatus.Save(c32, t32);
                                                }
                                            }
                                            if (file_updated)
                                            {
                                                Console.WriteLine("File {0} updated.", filePath31);
                                            }

                                            Console.WriteLine("\nSave changes? [y/n]");

                                            var should_continue = Console.ReadLine() == "y";
                                            if (should_continue)
                                            {
                                                t32.Commit();
                                            }

                                            Console.WriteLine("Press any key to continue...");
                                            Console.Read();
                                        }

                                        break;
                                    #endregion

                                    #region Command 32
                                    case "32":
                                        using (var c33 = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            c33.Open();
                                            var t33 = c33.BeginTransaction();

                                            var impossibleConsents = cls_Get_ImpossibleConsents.Invoke(c33, t33, securityTicket).Result;
                                            foreach (var impossibleConsent in impossibleConsents)
                                            {
                                                ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.SoftDelete(c33, t33, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                                                {
                                                    HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = impossibleConsent.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID
                                                });
                                            }

                                            t33.Commit();
                                        }

                                        break;
                                    #endregion

                                    #region Command 33
                                    case "33":

                                        using (var c33 = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            Console.WriteLine("Fetching data...");
                                            c33.Open();
                                            var t33 = c33.BeginTransaction();

                                            ORM_CMN_Language.Query all_languagesQ = new ORM_CMN_Language.Query();
                                            all_languagesQ.Tenant_RefID = securityTicket.TenantID;
                                            all_languagesQ.IsDeleted = false;

                                            var all_languagesL = ORM_CMN_Language.Query.Search(c33, t33, all_languagesQ).ToArray();

                                            var cases = cls_Get_DocumentationCases_Without_BillPositions.Invoke(c33, t33, securityTicket).Result;
                                            Console.WriteLine("Found cases: {0}", cases.Length);
                                            var i = 1;
                                            foreach (var _case in cases)
                                            {
                                                Console.WriteLine("{1}. Fixing case: {0}", _case.CaseNumber, i++);
                                                var case_details = cls_Get_Case_Details_for_CaseID.Invoke(c33, t33, new P_CAS_GCDfCID_1435() { CaseID = _case.HEC_CAS_CaseID }, securityTicket).Result;

                                                cls_Calculate_Case_GPOS.Invoke(c33, t33, new P_CAS_CCGPOS_1000()
                                                {
                                                    all_languagesL = all_languagesL,
                                                    case_id = _case.HEC_CAS_CaseID,
                                                    diagnose_id = case_details.diagnose_id,
                                                    drug_id = case_details.drug_id,
                                                    localization = case_details.localization,
                                                    patient_id = case_details.patient_id,
                                                    treatment_date = case_details.treatment_date,
                                                    treatment_doctor_id = case_details.op_doctor_id
                                                }, securityTicket);

                                                var bill_positions = cls_Get_BillPositionIDs_for_CaseID.Invoke(c33, t33, new P_CAS_GBPIDsfCID_0928() { CaseID = _case.HEC_CAS_CaseID }, securityTicket).Result;
                                                foreach (var bill_position in bill_positions)
                                                {
                                                    var fs_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                                    fs_status.IsActive = true;
                                                    fs_status.Modification_Timestamp = DateTime.Now;
                                                    fs_status.Tenant_RefID = securityTicket.TenantID;
                                                    fs_status.TransmitionCode = 13;
                                                    fs_status.TransmitionStatusKey = "treatment";
                                                    fs_status.TransmittedOnDate = case_details.treatment_date;
                                                    fs_status.BillPosition_RefID = bill_position.bill_position_id;
                                                    fs_status.Save(c33, t33);
                                                }
                                            }

                                            Console.WriteLine("Save changes? [y/n]");
                                            if (Console.ReadLine().ToLower() == "y")
                                            {
                                                t33.Commit();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Changes not saved.\nPress any key to continue...");
                                                Console.Read();
                                            }
                                        }
                                        break;

                                    #endregion

                                    #region Command 34
                                    case "34":

                                        using (var c34 = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            Console.WriteLine("Fetching data...");
                                            c34.Open();
                                            var t34 = c34.BeginTransaction();

                                            var ops = cls_Get_OPs_where_Case_Cancelled_and_Submitted.Invoke(c34, t34, securityTicket).Result;
                                            var acs = cls_Get_ACs_where_Case_Cancelled_and_Submitted.Invoke(c34, t34, securityTicket).Result;

                                            Console.WriteLine("Found cancelled and submitted IVOMs: {0}", ops.Length);
                                            Console.WriteLine("Case numbers: ");
                                            foreach (var op in ops)
                                            {
                                                Console.WriteLine(op.CaseNumber);
                                            }

                                            Console.WriteLine("Found aftercares where IVOM cancelled and submitted: {0}", acs.Length);
                                            Console.WriteLine("Case numbers: ");
                                            foreach (var ac in acs)
                                            {
                                                Console.WriteLine(ac.CaseNumber);
                                            }

                                            Console.WriteLine("Continue? [y/n]");
                                            if (Console.ReadLine().ToLower() == "y")
                                            {
                                                foreach (var op in ops)
                                                {
                                                    var op_action = new ORM_HEC_ACT_PlannedAction();
                                                    op_action.Load(c34, t34, op.HEC_ACT_PlannedActionID);

                                                    ORM_HEC_ACT_PerformedAction.Query.SoftDelete(c34, t34, new ORM_HEC_ACT_PerformedAction.Query()
                                                    {
                                                        HEC_ACT_PerformedActionID = op_action.IfPerformed_PerformedAction_RefID,
                                                        Tenant_RefID = securityTicket.TenantID,
                                                        IsDeleted = false
                                                    });

                                                    op_action.IsPerformed = false;
                                                    op_action.IfPerformed_PerformedAction_RefID = Guid.Empty;
                                                    op_action.Save(c34, t34);

                                                    var case_bill_codes = ORM_HEC_CAS_Case_BillCode.Query.Search(c34, t34, new ORM_HEC_CAS_Case_BillCode.Query()
                                                    {
                                                        HEC_CAS_Case_RefID = op.HEC_CAS_CaseID,
                                                        Tenant_RefID = securityTicket.TenantID,
                                                        IsDeleted = false
                                                    });

                                                    foreach (var case_bill_code in case_bill_codes)
                                                    {
                                                        var bill_code = new ORM_HEC_BIL_BillPosition_BillCode();
                                                        bill_code.Load(c34, t34, case_bill_code.HEC_BIL_BillPosition_BillCode_RefID);

                                                        var gpos = new ORM_HEC_BIL_PotentialCode();
                                                        gpos.Load(c34, t34, bill_code.PotentialCode_RefID);

                                                        var gpos_catalog = new ORM_HEC_BIL_PotentialCode_Catalog();
                                                        gpos_catalog.Load(c34, t34, gpos.PotentialCode_Catalog_RefID);

                                                        if (gpos_catalog.GlobalPropertyMatchingID == EGposType.Operation.Value())
                                                        {
                                                            var bill_position = new ORM_HEC_BIL_BillPosition();
                                                            bill_position.Load(c34, t34, bill_code.BillPosition_RefID);

                                                            ORM_BIL_BillPosition_TransmitionStatus.Query.SoftDelete(c34, t34, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                                                            {
                                                                BillPosition_RefID = bill_position.Ext_BIL_BillPosition_RefID,
                                                                Tenant_RefID = securityTicket.TenantID,
                                                                IsDeleted = false
                                                            });
                                                        }
                                                    }
                                                }

                                                foreach (var ac in acs)
                                                {
                                                    var ac_action = new ORM_HEC_ACT_PlannedAction();
                                                    ac_action.Load(c34, t34, ac.HEC_ACT_PlannedActionID);

                                                    ORM_HEC_ACT_PerformedAction.Query.SoftDelete(c34, t34, new ORM_HEC_ACT_PerformedAction.Query()
                                                    {
                                                        HEC_ACT_PerformedActionID = ac_action.IfPerformed_PerformedAction_RefID,
                                                        Tenant_RefID = securityTicket.TenantID,
                                                        IsDeleted = false
                                                    });

                                                    ac_action.IsPerformed = false;
                                                    ac_action.IfPerformed_PerformedAction_RefID = Guid.Empty;
                                                    ac_action.Save(c34, t34);

                                                    var case_bill_codes = ORM_HEC_CAS_Case_BillCode.Query.Search(c34, t34, new ORM_HEC_CAS_Case_BillCode.Query()
                                                    {
                                                        HEC_CAS_Case_RefID = ac.HEC_CAS_CaseID,
                                                        Tenant_RefID = securityTicket.TenantID,
                                                        IsDeleted = false
                                                    });

                                                    foreach (var case_bill_code in case_bill_codes)
                                                    {
                                                        var bill_code = new ORM_HEC_BIL_BillPosition_BillCode();
                                                        bill_code.Load(c34, t34, case_bill_code.HEC_BIL_BillPosition_BillCode_RefID);

                                                        var gpos = new ORM_HEC_BIL_PotentialCode();
                                                        gpos.Load(c34, t34, bill_code.PotentialCode_RefID);

                                                        var gpos_catalog = new ORM_HEC_BIL_PotentialCode_Catalog();
                                                        gpos_catalog.Load(c34, t34, gpos.PotentialCode_Catalog_RefID);

                                                        if (gpos_catalog.GlobalPropertyMatchingID == EGposType.Aftercare.Value())
                                                        {
                                                            var bill_position = new ORM_HEC_BIL_BillPosition();
                                                            bill_position.Load(c34, t34, bill_code.BillPosition_RefID);

                                                            ORM_BIL_BillPosition_TransmitionStatus.Query.SoftDelete(c34, t34, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                                                            {
                                                                BillPosition_RefID = bill_position.Ext_BIL_BillPosition_RefID,
                                                                Tenant_RefID = securityTicket.TenantID,
                                                                IsDeleted = false
                                                            });
                                                        }
                                                    }
                                                }

                                                t34.Commit();
                                            }
                                        }
                                        break;

                                    #endregion

                                    #region Command 35
                                    case "35":

                                        using (var c35 = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            Console.WriteLine("Fetching pharmacies...");
                                            c35.Open();
                                            var t35 = c35.BeginTransaction();

                                            var pharmacies = cls_Get_All_Pharmacies.Invoke(c35, t35, securityTicket).Result;
                                            Console.WriteLine("Found pharmacies: {0}", pharmacies.Length);
                                            if (pharmacies.Any())
                                            {
                                                Console.WriteLine();

                                                for (var i = 0; i < pharmacies.Length; i++)
                                                {
                                                    var pharmacy = pharmacies[i];
                                                    Console.WriteLine("{0}. {1}", i + 1, pharmacy.name);
                                                }

                                                Console.WriteLine();
                                                Console.WriteLine("Please choose a pharmacy to be set as the pharmacy for the previous orders:");

                                                var index = -1;
                                                var input = Console.ReadLine();
                                                if (Int32.TryParse(input, out index) && index <= pharmacies.Length)
                                                {
                                                    var selectedPharmacy = pharmacies[index - 1];

                                                    Console.WriteLine("Fetching orders...");
                                                    var orders = cls_Get_all_Orders_without_Pharmacy.Invoke(c35, t35, securityTicket).Result;
                                                    Console.WriteLine("Found orders: {0}", orders.Length);

                                                    Console.WriteLine("Print order numbers to file? [y/n]");
                                                    var saveToFile = Console.ReadLine().ToLower() == "y";
                                                    var filepath = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Orders-without-pharmacies.txt");
                                                    var headers = ORM_ORD_PRC_ProcurementOrder_Header.Query.Search(c35, t35, new ORM_ORD_PRC_ProcurementOrder_Header.Query()
                                                    {
                                                        Tenant_RefID = securityTicket.TenantID,
                                                        IsDeleted = false
                                                    });

                                                    for (var i = 0; i < orders.Length; i++)
                                                    {
                                                        var order = orders[i];
                                                        if (saveToFile)
                                                        {
                                                            File.AppendAllText(filepath, String.Format("Order number: {0}, in status: MO{1} \n", order.number, order.status));
                                                        }

                                                        var header = headers.FirstOrDefault(t => t.ORD_PRC_ProcurementOrder_HeaderID == order.id);
                                                        if (header == null)
                                                        {
                                                            throw new ArgumentException("Header not found for id: " + order.id);
                                                        }

                                                        header.ProcurementOrder_Supplier_RefID = selectedPharmacy.id;
                                                        header.Save(c35, t35);

                                                        Console.Write("\rOrder {0} of {1} updated. ({2})               ", i + 1, orders.Length, order.number);
                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Save changes? [y/n]", selectedPharmacy.name);
                                                    if (Console.ReadLine().ToLower() == "y")
                                                    {
                                                        t35.Commit();
                                                    }
                                                }
                                            }

                                        }
                                        break;

                                    #endregion

                                    #region Command 36
                                    case "36":
                                        using (var c36 = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            Console.WriteLine("Fetching pharmacies...");
                                            c36.Open();
                                            var t36 = c36.BeginTransaction();

                                            var cases = cls_Get_CaseIDs_where_Aftercare_missing_FS_status.Invoke(c36, t36, securityTicket).Result;
                                            Console.WriteLine("Found cases: {0}", cases.Length);
                                            foreach (var cas in cases)
                                            {
                                                Console.WriteLine(cas.CaseNumber);

                                                var caseFsStatuses = cls_Get_Case_FS_Status_for_CaseID.Invoke(c36, t36, new P_CAS_GCFSSfCID_2238() { CaseID = cas.HEC_CAS_CaseID }, securityTicket).Result.Where(t => t.gpos_type == EGposType.Aftercare.Value()).ToList();
                                                var caseBillPositions = cls_Get_BillPositionIDs_for_CaseID.Invoke(c36, t36, new P_CAS_GBPIDsfCID_0928() { CaseID = cas.HEC_CAS_CaseID }, securityTicket).Result.Where(t => t.gpos_type == EGposType.Aftercare.Value()).ToList();
                                                if (caseBillPositions.Count > 1)
                                                {
                                                    foreach (var billPosition in caseBillPositions)
                                                    {
                                                        if (!caseFsStatuses.Any(t => t.bill_position_id == billPosition.bill_position_id))
                                                        {
                                                            ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                                            position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                                            position_status.BillPosition_RefID = billPosition.bill_position_id;
                                                            position_status.Creation_Timestamp = DateTime.Now;
                                                            position_status.IsActive = true;
                                                            position_status.Modification_Timestamp = DateTime.Now;
                                                            position_status.TransmitionCode = 1;
                                                            position_status.TransmittedOnDate = DateTime.Now;
                                                            position_status.Tenant_RefID = securityTicket.TenantID;
                                                            position_status.TransmitionStatusKey = "aftercare";

                                                            position_status.Save(c36, t36);

                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    var all_languagesL = ORM_CMN_Language.Query.Search(c36, t36, new ORM_CMN_Language.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray();
                                                    var case_details = cls_Get_Case_Details_for_CaseID.Invoke(c36, t36, new P_CAS_GCDfCID_1435() { CaseID = cas.HEC_CAS_CaseID }, securityTicket).Result;

                                                    var billPositionId = cls_Calculate_Case_GPOS.Invoke(c36, t36, new P_CAS_CCGPOS_1000()
                                                    {
                                                        ac_doctor_id = case_details.ac_doctor_id,
                                                        case_id = cas.HEC_CAS_CaseID,
                                                        diagnose_id = case_details.diagnose_id,
                                                        drug_id = case_details.drug_id,
                                                        localization = case_details.localization,
                                                        patient_id = case_details.patient_id,
                                                        treatment_date = case_details.treatment_date,
                                                        all_languagesL = all_languagesL
                                                    }, securityTicket).Result.Single();

                                                    ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                                    position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                                    position_status.BillPosition_RefID = billPositionId;
                                                    position_status.Creation_Timestamp = DateTime.Now;
                                                    position_status.IsActive = true;
                                                    position_status.Modification_Timestamp = DateTime.Now;
                                                    position_status.TransmitionCode = 1;
                                                    position_status.TransmittedOnDate = DateTime.Now;
                                                    position_status.Tenant_RefID = securityTicket.TenantID;
                                                    position_status.TransmitionStatusKey = "aftercare";

                                                    position_status.Save(c36, t36);
                                                }
                                            }

                                            Console.WriteLine();
                                            Console.WriteLine("Save changes? [y/n]");
                                            if (Console.ReadLine().ToLower() == "y")
                                            {
                                                t36.Commit();
                                            }
                                        }
                                        break;

                                    #endregion

                                    #region Command 37
                                    case "37":
                                        using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            dbConnection.Open();
                                            var dbTransaction = dbConnection.BeginTransaction();
                                            var filePath37 = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Command-37-analysis.txt");
                                            if (File.Exists(filePath37))
                                            {
                                                filePath37 = filePath37.Replace(".txt", String.Format("{0}.txt", new Random().Next(1, 100)));
                                            }

                                            Console.WriteLine("Fetching FS history.");

                                            var gpos_catalog = ORM_HEC_BIL_PotentialCode_Catalog.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_PotentialCode_Catalog.Query()
                                            {
                                                GlobalPropertyMatchingID = EGposType.Aftercare.Value(),
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).Single();

                                            var fs_history = cls_Get_Case_FS_Status_History_on_Tenant_by_GposType.Invoke(dbConnection, dbTransaction, new P_CAS_GCFsSHoTbGposT_1102()
                                            {
                                                GposCatalogID = gpos_catalog.HEC_BIL_PotentialCode_CatalogID
                                            }, securityTicket).Result.OrderBy(t => Convert.ToInt32(t.CaseNumber)).GroupBy(t => t.HEC_CAS_CaseID).ToDictionary(t => t.Key, t => t.ToList());

                                            Console.WriteLine("Fetching aftercares.");
                                            var all_aftercares = cls_Get_Aftercares_on_Tenant.Invoke(dbConnection, dbTransaction, new P_CAS_GAoT_1120() { IncludeDeleted = false }, securityTicket).Result.GroupBy(t => t.Case_RefID).ToDictionary(t => t.Key, t => t.ToList());

                                            var cancelled_statuses = new int[] { 8, 11, 17 };
                                            foreach (var case_aftercares in all_aftercares)
                                            {
                                                if (fs_history.ContainsKey(case_aftercares.Key) && case_aftercares.Value.Count > 1 && case_aftercares.Value.Any(t => !t.IsPerformed))
                                                {
                                                    var case_fs_history = fs_history[case_aftercares.Key];
                                                    var case_number = case_fs_history.First().CaseNumber;
                                                    var performed_acs_count = case_aftercares.Value.Count(t => t.IsPerformed);
                                                    var cancelled_acs_count = case_fs_history.Count(t => cancelled_statuses.Any(r => r == t.TransmitionCode));
                                                    if (performed_acs_count != cancelled_acs_count)
                                                    {
                                                        File.AppendAllText(filePath37, "--------------------------------------------------------------- \r\n\r\n");
                                                        File.AppendAllText(filePath37, String.Format("Case: {0};\r\n\r\n", case_number));
                                                        File.AppendAllText(filePath37, "--------------------------------------------------------------- \r\n\r\n");

                                                        var open_ac = case_aftercares.Value.Single(t => !t.IsPerformed);
                                                        ORM_HEC_ACT_PlannedAction.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction.Query()
                                                        {
                                                            HEC_ACT_PlannedActionID = open_ac.HEC_ACT_PlannedActionID
                                                        });

                                                        ORM_HEC_CAS_Case_RelevantPlannedAction.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query()
                                                        {
                                                            HEC_CAS_Case_RelevantPlannedActionID = open_ac.HEC_CAS_Case_RelevantPlannedActionID
                                                        });
                                                    }
                                                }
                                            }



                                            Console.WriteLine("Save changes? [y/n]");
                                            if (Console.ReadLine().ToLower() == "y")
                                            {
                                                dbTransaction.Commit();
                                            }
                                        }
                                        break;
                                    #endregion

                                    #region Command 38
                                    case "38":

                                        using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            dbConnection.Open();
                                            var dbTransaction = dbConnection.BeginTransaction();
                                            var filePath37 = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Command-37-analysis.txt");
                                            if (File.Exists(filePath37))
                                            {
                                                filePath37 = filePath37.Replace(".txt", String.Format("{0}.txt", new Random().Next(1, 100)));
                                            }

                                            Console.WriteLine("Fetching FS history.");

                                            var gpos_catalog = ORM_HEC_BIL_PotentialCode_Catalog.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_PotentialCode_Catalog.Query()
                                            {
                                                GlobalPropertyMatchingID = EGposType.Aftercare.Value(),
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).Single();

                                            var fs_history = cls_Get_Case_FS_Status_History_on_Tenant_by_GposType.Invoke(dbConnection, dbTransaction, new P_CAS_GCFsSHoTbGposT_1102()
                                            {
                                                GposCatalogID = gpos_catalog.HEC_BIL_PotentialCode_CatalogID
                                            }, securityTicket).Result.OrderBy(t => Convert.ToInt32(t.CaseNumber)).GroupBy(t => t.HEC_CAS_CaseID).ToDictionary(t => t.Key, t => t.ToList());

                                            Console.WriteLine("Fetching aftercares.");
                                            var all_aftercares = cls_Get_Aftercares_on_Tenant.Invoke(dbConnection, dbTransaction, new P_CAS_GAoT_1120() { IncludeDeleted = false }, securityTicket).Result.GroupBy(t => t.Case_RefID).ToDictionary(t => t.Key, t => t.ToList());

                                            var cancelled_statuses = new int[] { 8, 11, 17 };
                                            foreach (var case_aftercares in all_aftercares)
                                            {
                                                if (fs_history.ContainsKey(case_aftercares.Key) && case_aftercares.Value.Count > 1)
                                                {
                                                    var case_fs_history = fs_history[case_aftercares.Key];
                                                    var case_number = case_fs_history.First().CaseNumber;
                                                    var performed_acs_count = case_aftercares.Value.Count(t => t.IsPerformed);
                                                    var cancelled_acs_count = case_fs_history.Count(t => cancelled_statuses.Any(r => r == t.TransmitionCode));
                                                    if (performed_acs_count > 1 && (cancelled_acs_count == 0 || (performed_acs_count - cancelled_acs_count > 1)))
                                                    {
                                                        File.AppendAllText(filePath37, "--------------------------------------------------------------- \r\n\r\n");
                                                        File.AppendAllText(filePath37, String.Format("Case: {0};\r\n\r\n", case_number));
                                                        File.AppendAllText(filePath37, "--------------------------------------------------------------- \r\n\r\n");
                                                    }
                                                }
                                            }
                                        }

                                        break;
                                    #endregion

                                    #region Command 39
                                    case "39":
                                        using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            dbConnection.Open();
                                            var dbTransaction = dbConnection.BeginTransaction();
                                            var filePath37 = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Command-39-analysis.txt");
                                            if (File.Exists(filePath37))
                                            {
                                                filePath37 = filePath37.Replace(".txt", String.Format("{0}.txt", new Random().Next(1, 100)));
                                            }

                                            Console.WriteLine("Fetching OCT dates.");
                                            var oct_performed_action_type = ORM_HEC_ACT_ActionType.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_ActionType.Query()
                                            {
                                                GlobalPropertyMatchingID = EActionType.PerformedOct.Value(),
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).Single();

                                            var oct_dates = cls_Get_PerformedActionsDates_by_ActionTypeID_on_Tenant.Invoke(dbConnection, dbTransaction, new P_CAS_GPADbATIDoT_1411() { ActionTypeID = oct_performed_action_type.HEC_ACT_ActionTypeID }, securityTicket).Result
                                                .GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(x => x.localization).ToDictionary(x => x.Key, x => x.ToList()));

                                            Console.WriteLine("Fetching OCT FS statuses.");
                                            var oct_fs_statuses = cls_Get_Oct_FsStatuses_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result
                                                .GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.GroupBy(x => x.localization).ToDictionary(x => x.Key, x => x.ToList()));

                                            var changed = false;

                                            Console.WriteLine("Scanning data.");
                                            foreach (var patient_oct_dates in oct_dates)
                                            {
                                                if (!oct_fs_statuses.ContainsKey(patient_oct_dates.Key))
                                                {
                                                    File.AppendAllText(filePath37, "----------------------------------------------- NO OCT FS STATUSES FOUND FOR PATIENT ----------------------------------------------- \r\n\r\n");
                                                    File.AppendAllText(filePath37, String.Format("Patient id: {0};\r\n\r\n", patient_oct_dates.Key));
                                                    File.AppendAllText(filePath37, "------------------------------------------------------------------------------------------------------------------------------------ \r\n\r\n");
                                                    continue;
                                                }

                                                var patient_oct_fs_statuses = oct_fs_statuses[patient_oct_dates.Key];
                                                foreach (var localization_oct_dates in patient_oct_dates.Value)
                                                {
                                                    if (!patient_oct_fs_statuses.ContainsKey(localization_oct_dates.Key))
                                                    {
                                                        File.AppendAllText(filePath37, "----------------------------------------------- NO OCT FS STATUSES FOUND FOR PATIENT AND LOCALIZATION ----------------------------------------------- \r\n\r\n");
                                                        File.AppendAllText(filePath37, String.Format("Patient id: {0};\nLocalization: {1} \r\n\r\n", patient_oct_dates.Key, localization_oct_dates.Key));
                                                        File.AppendAllText(filePath37, "----------------------------------------------------------------------------------------------------------------------------------------------------- \r\n\r\n");
                                                        continue;
                                                    }

                                                    var localization_oct_fs_statuses = patient_oct_fs_statuses[localization_oct_dates.Key];
                                                    if (localization_oct_fs_statuses.Count != localization_oct_dates.Value.Count)
                                                    {
                                                        File.AppendAllText(filePath37, "----------------------------------------------- FS STATUS AND OCT DATES COUNT MISMATCH ----------------------------------------------- \r\n\r\n");
                                                        File.AppendAllText(filePath37, String.Format("Patient id: {0};\nLocalization: {1} \r\n\r\n", patient_oct_dates.Key, localization_oct_dates.Key));
                                                        File.AppendAllText(filePath37, "Dates: ");
                                                        foreach (var date in localization_oct_dates.Value)
                                                        {
                                                            File.AppendAllText(filePath37, String.Format("{0}\n", date.treatment_date.ToString("yyyy-MM-dd")));

                                                            if (!localization_oct_fs_statuses.Any(t => t.case_id == date.case_id))
                                                            {
                                                                var bill_positions = cls_Get_BillPositionIDs_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GBPIDsfCID_0928() { CaseID = date.case_id }, securityTicket).Result.Where(t => t.gpos_type == EGposType.Oct.Value()).ToList();
                                                                foreach (var bill_position in bill_positions)
                                                                {
                                                                    var fs_status_exists = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(dbConnection, dbTransaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                                                                    {
                                                                        BillPosition_RefID = bill_position.bill_position_id,
                                                                        Tenant_RefID = securityTicket.TenantID,
                                                                        IsDeleted = false
                                                                    }).Any();

                                                                    if (!fs_status_exists)
                                                                    {
                                                                        var new_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                                                        new_status.BillPosition_RefID = bill_position.bill_position_id;
                                                                        new_status.IsActive = true;
                                                                        new_status.Modification_Timestamp = DateTime.Now;
                                                                        new_status.Tenant_RefID = securityTicket.TenantID;
                                                                        new_status.TransmitionCode = 1;
                                                                        new_status.TransmitionStatusKey = "oct";
                                                                        new_status.TransmittedOnDate = date.treatment_date;

                                                                        new_status.Save(dbConnection, dbTransaction);
                                                                        changed = true;
                                                                    }
                                                                }
                                                            }
                                                        }

                                                        File.AppendAllText(filePath37, "Bill positions: ");
                                                        foreach (var bill in localization_oct_fs_statuses)
                                                        {
                                                            File.AppendAllText(filePath37, String.Format("id: {0}\nstatus: {1} \n", bill.bill_position_id, bill.fs_status));
                                                        }

                                                        File.AppendAllText(filePath37, "-------------------------------------------------------------------------------------------------------------------------------------- \r\n\r\n");
                                                    }
                                                }
                                            }

                                            if (changed)
                                            {
                                                Console.WriteLine("Save changes? [y/n]");
                                                if (Console.ReadLine().ToLower() == "y")
                                                {
                                                    dbTransaction.Commit();
                                                }
                                            }
                                        }


                                        break;
                                    #endregion

                                    #region Command 40
                                    case "40":
                                        using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            dbConnection.Open();
                                            var dbTransaction = dbConnection.BeginTransaction();
                                            var filePath40 = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Command-40-analysis.txt");
                                            if (File.Exists(filePath40))
                                            {
                                                filePath40 = filePath40.Replace(".txt", String.Format("{0}.txt", new Random().Next(1, 100)));
                                            }
                                            var changesExist = false;
                                            Console.WriteLine("Fetching treatment data.");
                                            var treatmentData = cls_Get_Treatment_Data_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result;
                                            var allPatientTreatmentData = treatmentData
                                                .GroupBy(t => t.Patient_RefID)
                                                .ToDictionary(t => t.Key, t => t.ToList());

                                            var allCaseTreatmentData = treatmentData
                                                .GroupBy(t => t.HEC_CAS_CaseID)
                                                .ToDictionary(t => t.Key, t => t.First());

                                            Console.WriteLine("Fetching cases with open oct.");
                                            var casesWithOpenOcts = cls_Get_CaseIds_with_OpenOcts_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result;

                                            Console.WriteLine("Fetching cases with open oct bill positions.");
                                            var casesWithOpenOctBillPositions = cls_Get_CaseIds_with_OpenOctBillPosition_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result;

                                            var allLanguages = ORM_CMN_Language.Query.Search(dbConnection, dbTransaction, new ORM_CMN_Language.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray();

                                            var parsedPatients = new Dictionary<Guid, List<string>>();
                                            Console.WriteLine("Scanning cases");

                                            foreach (var caseWithOpenOcts in casesWithOpenOcts)
                                            {
                                                if (casesWithOpenOctBillPositions.Any(t => t.HEC_CAS_CaseID == caseWithOpenOcts.HEC_CAS_CaseID))
                                                {
                                                    continue;
                                                }

                                                if (!allCaseTreatmentData.ContainsKey(caseWithOpenOcts.HEC_CAS_CaseID))
                                                {
                                                    continue;
                                                }


                                                var caseTreatmentData = allCaseTreatmentData[caseWithOpenOcts.HEC_CAS_CaseID];

                                                if (!allPatientTreatmentData.ContainsKey(caseTreatmentData.Patient_RefID))
                                                {
                                                    continue;
                                                }

                                                var patientCases = allPatientTreatmentData[caseTreatmentData.Patient_RefID].Where(t => t.IM_PotentialDiagnosisLocalization_Code == caseTreatmentData.IM_PotentialDiagnosisLocalization_Code).ToList();
                                                if (casesWithOpenOctBillPositions.Any(t => patientCases.Any(p => p.HEC_CAS_CaseID == t.HEC_CAS_CaseID)))
                                                {
                                                    continue;
                                                }

                                                if (parsedPatients.ContainsKey(caseTreatmentData.Patient_RefID) && parsedPatients[caseTreatmentData.Patient_RefID].Any(t => t == caseTreatmentData.IM_PotentialDiagnosisLocalization_Code))
                                                {
                                                    continue;
                                                }

                                                if (!parsedPatients.ContainsKey(caseTreatmentData.Patient_RefID))
                                                {
                                                    parsedPatients.Add(caseTreatmentData.Patient_RefID, new List<string>());
                                                }
                                                parsedPatients[caseTreatmentData.Patient_RefID].Add(caseTreatmentData.IM_PotentialDiagnosisLocalization_Code);

                                                var str = String.Format("Case number: {0}, Patient id: {1}, Localization: {2} \n", caseTreatmentData.CaseNumber, caseTreatmentData.Patient_RefID, caseTreatmentData.IM_PotentialDiagnosisLocalization_Code);
                                                File.AppendAllText(filePath40, str);

                                                try
                                                {
                                                    cls_Calculate_Case_GPOS.Invoke(dbConnection, dbTransaction, new P_CAS_CCGPOS_1000()
                                                    {
                                                        all_languagesL = allLanguages,
                                                        case_id = caseTreatmentData.HEC_CAS_CaseID,
                                                        oct_doctor_id = Guid.NewGuid(),
                                                        patient_id = caseTreatmentData.Patient_RefID,
                                                        treatment_date = caseTreatmentData.PlannedFor_Date,
                                                        diagnose_id = caseTreatmentData.PotentialDiagnosis_RefID,
                                                        localization = caseTreatmentData.IM_PotentialDiagnosisLocalization_Code,
                                                        drug_id = caseTreatmentData.HealthcareProduct_RefID
                                                    }, securityTicket);
                                                }
                                                catch
                                                {
                                                    continue;
                                                }
                                                changesExist = true;
                                            }

                                            if (changesExist)
                                            {
                                                Console.WriteLine("Save changes? [y/n]");
                                                if (Console.ReadLine().ToLower() == "y")
                                                {
                                                    dbTransaction.Commit();
                                                }
                                            }

                                            Console.WriteLine("Press any key to continue...");
                                            Console.Read();
                                        }

                                        break;
                                    #endregion

                                    #region Command 41
                                    case "41":
                                        using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            dbConnection.Open();
                                            var dbTransaction = dbConnection.BeginTransaction();
                                            var filePath37 = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Command-41-analysis.txt");
                                            if (File.Exists(filePath37))
                                            {
                                                filePath37 = filePath37.Replace(".txt", String.Format("{0}.txt", new Random().Next(1, 100)));
                                            }
                                            var changesExist = false;

                                            var all_languages = ORM_CMN_Language.Query.Search(dbConnection, dbTransaction, new ORM_CMN_Language.Query()
                                            {
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).ToArray();

                                            var cancelled_statuses = new int[] { 8, 11, 17 };
                                            Console.WriteLine("Fetching submitted cases.");
                                            var submitted_case_ids = cls_Get_Submitted_NonError_CaseIDs.Invoke(dbConnection, dbTransaction, securityTicket).Result.Select(t => t.HEC_CAS_Case_RefID).ToArray();

                                            Console.WriteLine("Fetching all cases with submitted aftercares.");
                                            var cases = cls_Get_Cases_With_Submitted_Aftercares.Invoke(dbConnection, dbTransaction, new P_CAS_GCwSA_1430() { CaseIDs = submitted_case_ids }, securityTicket).Result.GroupBy(t => t.HEC_CAS_CaseID).ToDictionary(t => t.Key, t => t.Where(x => x.GposType == EGposType.Aftercare.Value()).ToList());

                                            Console.WriteLine("Fetching all aftercares.");
                                            var aftercares = cls_Get_Aftercares_on_Tenant.Invoke(dbConnection, dbTransaction, new P_CAS_GAoT_1120() { IncludeDeleted = true }, securityTicket).Result.GroupBy(t => t.Case_RefID).ToDictionary(t => t.Key, t => t.ToList());

                                            foreach (var _case in cases)
                                            {
                                                var case_aftercare_bill_positions = _case.Value;
                                                if (case_aftercare_bill_positions.Any(t => cancelled_statuses.Any(r => r == t.TransmitionCode)))
                                                {
                                                    if (aftercares.ContainsKey(_case.Key))
                                                    {
                                                        var case_aftercares = aftercares[_case.Key];
                                                        var total_aftercares_count = case_aftercares.Count;
                                                        var total_aftercare_bill_positions_count = case_aftercare_bill_positions.Count;
                                                        if (total_aftercare_bill_positions_count != total_aftercares_count)
                                                        {
                                                            var any_unperformed_aftercare = case_aftercares.Any(t => !t.IsPerformed);
                                                            var any_non_open_non_cancelled_fs_status = case_aftercare_bill_positions.Any(t => t.TransmitionCode != 8 && t.TransmitionCode != 17 && t.TransmitionCode != 11 && t.TransmitionCode != 0);
                                                            var performed_aftercares_count = case_aftercares.Count(t => t.IsPerformed);
                                                            var fs_statuses_count = case_aftercare_bill_positions.Count(t => t.TransmitionCode != 0);

                                                            if (!any_unperformed_aftercare && !any_non_open_non_cancelled_fs_status && performed_aftercares_count > fs_statuses_count)
                                                            {
                                                                Console.WriteLine("Fixing case: {0}", _case.Value.First().CaseNumber);

                                                                var performed_action_creation_date = case_aftercares.Max(t => t.Creation_Timestamp);

                                                                var open_bill_position = _case.Value.FirstOrDefault(t => t.TransmitionCode == 0 && t.Ext_BIL_BillPosition_RefID != Guid.Empty && t.GposType == EGposType.Aftercare.Value());

                                                                var open_bill_position_id = Guid.Empty;
                                                                if (open_bill_position == null)
                                                                {
                                                                    var case_details = cls_Get_Case_Details_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCDfCID_1435() { CaseID = _case.Key }, securityTicket).Result;
                                                                    open_bill_position_id = cls_Calculate_Case_GPOS.Invoke(dbConnection, dbTransaction, new P_CAS_CCGPOS_1000()
                                                                    {
                                                                        ac_doctor_id = Guid.NewGuid(),
                                                                        all_languagesL = all_languages,
                                                                        case_id = _case.Key,
                                                                        creation_timestamp = performed_action_creation_date,
                                                                        diagnose_id = case_details.diagnose_id,
                                                                        drug_id = case_details.drug_id,
                                                                        localization = case_details.localization,
                                                                        patient_id = case_details.patient_id,
                                                                        treatment_date = case_details.treatment_date
                                                                    }, securityTicket).Result.First();
                                                                }
                                                                else
                                                                {
                                                                    open_bill_position_id = open_bill_position.Ext_BIL_BillPosition_RefID;
                                                                }


                                                                var new_fs_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                                                new_fs_status.BillPosition_RefID = open_bill_position_id;
                                                                new_fs_status.Creation_Timestamp = performed_action_creation_date;
                                                                new_fs_status.IsActive = true;
                                                                new_fs_status.Modification_Timestamp = DateTime.Now;
                                                                new_fs_status.SecondaryComment = "Fixed using command 4-41 of the dataimporter";
                                                                new_fs_status.Tenant_RefID = securityTicket.TenantID;
                                                                new_fs_status.TransmitionCode = 1;
                                                                new_fs_status.TransmitionStatusKey = "aftercare";
                                                                new_fs_status.TransmittedOnDate = performed_action_creation_date;

                                                                new_fs_status.Save(dbConnection, dbTransaction);

                                                                if (!changesExist)
                                                                {
                                                                    changesExist = true;
                                                                }

                                                                var str = String.Format("Case number: {0} \nNumber of aftercares: {1} \nNumber of bill positions: {2} \n", _case.Value.First().CaseNumber, total_aftercares_count, total_aftercare_bill_positions_count);

                                                                File.AppendAllText(filePath37, str);
                                                                File.AppendAllText(filePath37, "Bill position statuses: \n\n");
                                                                foreach (var status in case_aftercare_bill_positions)
                                                                {
                                                                    File.AppendAllText(filePath37, String.Format("{0}: {1} \n", status.Ext_BIL_BillPosition_RefID, status.TransmitionCode));

                                                                }
                                                                File.AppendAllText(filePath37, "\n\n");

                                                                File.AppendAllText(filePath37, " ------------------------------------- \r\n\r\n");
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            if (changesExist)
                                            {
                                                Console.WriteLine("File saved to {0}", filePath37);
                                                Console.WriteLine();


                                                Console.WriteLine("Save changes? [y/n]");
                                                if (Console.ReadLine().ToLower() == "y")
                                                {
                                                    dbTransaction.Commit();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("No affected cases found. Press any key to continue...");
                                                Console.Read();
                                            }
                                        }

                                        break;
                                    #endregion

                                    #region Command 42
                                    case "42":
                                        using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            dbConnection.Open();
                                            var dbTransaction = dbConnection.BeginTransaction();
                                            var filePath42 = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Command-42-analysis.txt");
                                            if (File.Exists(filePath42))
                                            {
                                                filePath42 = filePath42.Replace(".txt", String.Format("{0}.txt", new Random().Next(1, 100)));
                                            }
                                            var changesExist = false;

                                            Console.WriteLine("\nFetching OCTs.");
                                            var dbOcts = cls_Get_Octs_for_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result;

                                            Console.WriteLine("Fetching Bill data.");
                                            var caseBillPositionData = cls_Get_Case_BillingData_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result;

                                            Console.WriteLine("Fetching Languages.");
                                            var all_languages = ORM_CMN_Language.Query.Search(dbConnection, dbTransaction, new ORM_CMN_Language.Query()
                                            {
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).ToArray();

                                            Console.WriteLine("Fetching all OCTs without GPOs data.");
                                            var allOCTsWithoutGPOs = dbOcts.Where(x => !caseBillPositionData.Any(c => c.patient_id == x.PatientID && x.Localization == c.localization)).ToList();
                                            var totalNumberOfOcts = allOCTsWithoutGPOs.Count;

                                            Console.WriteLine(String.Format("Total number of OCTs without GPOs: {0} \n\n", totalNumberOfOcts));
                                            File.AppendAllText(filePath42, String.Format("Total number of OCTs without GPOs: {0} \n\n", totalNumberOfOcts));
                                            var processedPatientsAndLocalizations = new Dictionary<Guid, List<string>>();
                                            var oct_index = 1;
                                            foreach (var oct in allOCTsWithoutGPOs)
                                            {
                                                try
                                                {
                                                    if (processedPatientsAndLocalizations.ContainsKey(oct.PatientID) && processedPatientsAndLocalizations[oct.PatientID].Any(t => t == oct.Localization))
                                                    {
                                                        continue;
                                                    }

                                                    var bill_position_id = cls_Calculate_Case_GPOS.Invoke(dbConnection, dbTransaction, new P_CAS_CCGPOS_1000()
                                                    {
                                                        case_id = oct.CaseID,
                                                        diagnose_id = oct.DiagnoseID,
                                                        drug_id = oct.DrugID,
                                                        patient_id = oct.PatientID,
                                                        localization = oct.Localization,
                                                        treatment_date = oct.TreatmentDate,
                                                        oct_doctor_id = oct.OctDoctorID
                                                    }, securityTicket).Result;

                                                    if (oct.IsPerformed)
                                                    {
                                                        var oct_fs_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                                        oct_fs_status.BillPosition_RefID = bill_position_id.First();
                                                        oct_fs_status.IsActive = true;
                                                        oct_fs_status.Modification_Timestamp = DateTime.Now;
                                                        oct_fs_status.Tenant_RefID = securityTicket.TenantID;
                                                        oct_fs_status.TransmitionCode = 1;
                                                        oct_fs_status.TransmitionStatusKey = "oct";
                                                        oct_fs_status.TransmittedOnDate = DateTime.Now;
                                                    }

                                                    if (!changesExist)
                                                    {
                                                        changesExist = true;
                                                    }

                                                    var str = String.Format("Case id: {0}, OCT id: {1}, Patient id: {2} \n", oct.CaseID, oct.ID, oct.PatientID);
                                                    File.AppendAllText(filePath42, str);

                                                    Console.Write("\rOCT {0} of {1} updated.                ", oct_index++, totalNumberOfOcts);

                                                    if (!processedPatientsAndLocalizations.ContainsKey(oct.PatientID))
                                                    {
                                                        processedPatientsAndLocalizations.Add(oct.PatientID, new List<string>());
                                                    }

                                                    processedPatientsAndLocalizations[oct.PatientID].Add(oct.Localization);
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("Exception while update OCT id: {0}, Patient id: {1} \n", oct.ID, oct.PatientID);
                                                }
                                            }


                                            if (changesExist)
                                            {
                                                Console.WriteLine("File saved to {0}", filePath42);
                                                Console.WriteLine();

                                                Console.WriteLine("Save changes? [y/n]");
                                                if (Console.ReadLine().ToLower() == "y")
                                                {
                                                    dbTransaction.Commit();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("No affected OCTs found. Press any key to continue...");
                                                Console.Read();
                                            }
                                        }

                                        break;
                                    #endregion
                                    #region Command 43
                                    case "43":
                                        using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                                        {
                                            dbConnection.Open();
                                            var dbTransaction = dbConnection.BeginTransaction();
                                            var filepath = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Command-43-analysis.txt");

                                            var octPlannedActionType = ORM_HEC_ACT_ActionType.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_ActionType.Query()
                                            {
                                                GlobalPropertyMatchingID = EActionType.PlannedOct.Value(),
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            }).SingleOrDefault();

                                            Console.WriteLine("\nFetching OCTs.");
                                            var octCaseIds = cls_Get_CaseIDs_on_Tenant_by_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GCIDsoTbATID_2352() { ActionTypeID = octPlannedActionType.HEC_ACT_ActionTypeID }, securityTicket).Result;
                                            var changesExist = false;

                                            Console.WriteLine("\nFetching drugs covered by GPOS-es.");
                                            var gposCoveredDrugs = ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                                            {
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            });

                                            Console.WriteLine("\nFetching diagnoses covered by GPOS-es.");
                                            var gposCoveredDiagnoses = ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query()
                                            {
                                                Tenant_RefID = securityTicket.TenantID,
                                                IsDeleted = false
                                            });
                                            Console.WriteLine("\nFetching GPOS-es attached to cases.");
                                            var caseGposIds = cls_Get_Case_GposIDs_on_Tenant_by_GposType.Invoke(dbConnection, dbTransaction, new P_CAS_GCGposIDsoTbGposT_0006()
                                            {
                                                GposType = EGposType.Operation.Value()
                                            }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.ToList());

                                            var gposCoveredDrugsAndDiagnoses = new Dictionary<Guid, GposDrugDiagnose>();
                                            foreach (var drug in gposCoveredDrugs)
                                            {
                                                if (!gposCoveredDrugsAndDiagnoses.ContainsKey(drug.HEC_BIL_PotentialCode_RefID))
                                                {
                                                    gposCoveredDrugsAndDiagnoses.Add(drug.HEC_BIL_PotentialCode_RefID, new GposDrugDiagnose());
                                                }

                                                gposCoveredDrugsAndDiagnoses[drug.HEC_BIL_PotentialCode_RefID].DrugIds.Add(drug.HEC_Product_RefID);
                                            }

                                            foreach (var diagnose in gposCoveredDiagnoses)
                                            {
                                                if (!gposCoveredDrugsAndDiagnoses.ContainsKey(diagnose.HEC_BIL_PotentialCode_RefID))
                                                {
                                                    gposCoveredDrugsAndDiagnoses.Add(diagnose.HEC_BIL_PotentialCode_RefID, new GposDrugDiagnose());
                                                }

                                                gposCoveredDrugsAndDiagnoses[diagnose.HEC_BIL_PotentialCode_RefID].DiagnoseIds.Add(diagnose.HEC_DIA_PotentialDiagnosis_RefID);
                                            }

                                            var allCaseTreatmentData = cls_Get_CaseData_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result.GroupBy(t => t.Case_RefID).ToDictionary(t => t.Key, t => t.ToList());
                                            foreach (var octCaseId in octCaseIds)
                                            {
                                                if (caseGposIds.ContainsKey(octCaseId.CaseID))
                                                {
                                                    var caseBilling = caseGposIds[octCaseId.CaseID];

                                                    var caseTreatmentData = allCaseTreatmentData[octCaseId.CaseID].First();
                                                    var affectedBillPosition = caseBilling.FirstOrDefault(gpos =>
                                                    {
                                                        var gposCovered = gposCoveredDrugsAndDiagnoses[gpos.GposID];
                                                        return !gposCovered.DiagnoseIds.Any(t => t == caseTreatmentData.PotentialDiagnosis_RefID) && !gposCovered.DrugIds.Any(t => t == caseTreatmentData.HealthcareProduct_RefID);
                                                    });

                                                    if (affectedBillPosition != null)
                                                    {
                                                        Console.WriteLine("Removing OCT data from case: {0}", octCaseId.CaseNumber);

                                                        var caseDetails = cls_Get_Case_Details_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCDfCID_1435() { CaseID = octCaseId.CaseID }, securityTicket).Result;
                                                        var drug = cls_Get_Drug_Details_for_DrugID.Invoke(dbConnection, dbTransaction, new P_CAS_GDDfDID_1614() { DrugID = caseDetails.drug_id }, securityTicket).Result;
                                                        var diagnose = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(dbConnection, dbTransaction, new P_CAS_GDDfDID_1357() { DiagnoseID = caseDetails.diagnose_id }, securityTicket).Result;
                                                        File.AppendAllText(filepath, String.Format("Case number: {0}, drug: {1}, diagnose: {2}, localization: {3}\n", octCaseId.CaseNumber, drug.drug_name, diagnose.diagnose_name, caseDetails.localization));
                                                        changesExist = true;

                                                        #region Delete billing
                                                        var bill_position = ORM_BIL_BillPosition.Query.Search(dbConnection, dbTransaction, new ORM_BIL_BillPosition.Query()
                                                        {
                                                            BIL_BillPositionID = affectedBillPosition.BillPositionID
                                                        }).SingleOrDefault();

                                                        if (bill_position == null)
                                                        {
                                                            throw new KeyNotFoundException(String.Format("Bill position not found for id: {0}", affectedBillPosition.BillPositionID));
                                                        }

                                                        bill_position.IsDeleted = true;
                                                        bill_position.Modification_Timestamp = DateTime.Now;

                                                        bill_position.Save(dbConnection, dbTransaction);

                                                        var hec_bill_position = ORM_HEC_BIL_BillPosition.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_BillPosition.Query()
                                                        {
                                                            Ext_BIL_BillPosition_RefID = bill_position.BIL_BillPositionID
                                                        }).SingleOrDefault();

                                                        if (hec_bill_position == null)
                                                        {
                                                            throw new KeyNotFoundException(String.Format("Hec bill position not found for ref id: {0}", affectedBillPosition.BillPositionID));
                                                        }

                                                        hec_bill_position.IsDeleted = true;
                                                        hec_bill_position.Modification_Timestamp = DateTime.Now;

                                                        hec_bill_position.Save(dbConnection, dbTransaction);

                                                        var hec_bill_position_bill_code = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_BillPosition_BillCode.Query()
                                                        {
                                                            BillPosition_RefID = hec_bill_position.HEC_BIL_BillPositionID
                                                        }).SingleOrDefault();

                                                        if (hec_bill_position_bill_code == null)
                                                        {
                                                            throw new KeyNotFoundException(String.Format("Hec bill position code not found for ref id: {0}", hec_bill_position.HEC_BIL_BillPositionID));
                                                        }

                                                        hec_bill_position_bill_code.IsDeleted = true;
                                                        hec_bill_position_bill_code.Modification_Timestamp = DateTime.Now;

                                                        hec_bill_position_bill_code.Save(dbConnection, dbTransaction);

                                                        var hec_case_billcode = ORM_HEC_CAS_Case_BillCode.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_BillCode.Query()
                                                        {
                                                            HEC_BIL_BillPosition_BillCode_RefID = hec_bill_position_bill_code.HEC_BIL_BillPosition_BillCodeID
                                                        }).SingleOrDefault();

                                                        if (hec_case_billcode == null)
                                                        {
                                                            throw new KeyNotFoundException(String.Format("Hec case bill position code not found for ref id: {0}", hec_bill_position_bill_code.HEC_BIL_BillPosition_BillCodeID));
                                                        }

                                                        hec_case_billcode.IsDeleted = true;
                                                        hec_case_billcode.Modification_Timestamp = DateTime.Now;

                                                        hec_case_billcode.Save(dbConnection, dbTransaction);
                                                        #endregion

                                                        #region Delete action data
                                                        ORM_HEC_ACT_PlannedAction.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction.Query() { HEC_ACT_PlannedActionID = octCaseId.ActionID });
                                                        ORM_HEC_CAS_Case_RelevantPlannedAction.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query() { PlannedAction_RefID = octCaseId.ActionID });
                                                        ORM_HEC_ACT_PlannedAction_2_ActionType.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction_2_ActionType.Query() { HEC_ACT_PlannedAction_RefID = octCaseId.ActionID });
                                                        #endregion
                                                    }
                                                }
                                            }

                                            if (changesExist)
                                            {
                                                Console.WriteLine();

                                                Console.WriteLine("Save changes? [y/n]");
                                                if (Console.ReadLine().ToLower() == "y")
                                                {
                                                    dbTransaction.Commit();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("No affected cases found. Press any key to continue...");
                                                Console.Read();
                                            }

                                        }
                                        break;
                                    #endregion


                                    default:
                                        break;
                                }
                            } while (cmd4innerCommand != "0");
                            break;
                        default: break;
                        #endregion

                        #region COMMAND 5
                        case "5":
                            var password = ConfigurationManager.AppSettings["password-for-all-users"];
                            if (String.IsNullOrEmpty(password))
                            {
                                Console.WriteLine("Config file password empty. Please enter the password you wish to set on all accounts: ");
                                password = Console.ReadLine();
                            }

                            using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                            {
                                dbConnection.Open();
                                var dbTransaction = dbConnection.BeginTransaction();

                                var accountService = ProviderFactory.Instance.CreateAccountServiceProvider();
                                var accounts = cls_Get_All_DocApp_Accounts_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result;
                                foreach (var account in accounts)
                                {
                                    accountService.ResetPassword(new ResetPasswordRequest()
                                    {
                                        AccountID = account.account_id,
                                        NewPassword = password,
                                        SessionToken = securityTicket.SessionTicket
                                    });

                                    Console.WriteLine("Account: {0} updated.", account.email);
                                }
                            }

                            Console.WriteLine("\nPress any key to continue...");
                            Console.Read();
                            break;
                        #endregion

                        #region COMMAND 9 (Olaf)
                        case "9":

                            string myGuidString = "27DB00BB-4BA8-4D12-A3C3-7ABB05DC9AF4";
                            Guid myGuid = new Guid(myGuidString);
                            var found = Utilities.SearchKey(connectionString, myGuid);
                            Console.WriteLine("? key ");
                            foreach (var record in found)
                            {

                                Console.WriteLine("Key found in : {0} \t ID: {1}", record.Tablename, record.Columnname);
                            }

                            Console.WriteLine("\nPress any key to continue...");
                            Console.Read();
                            break;
                            #endregion

                    }

                } while (!command.Equals("0"));
            }
        }

        #region Commands
        static void Command31(string connectionString, SessionSecurityTicket securityTicket, ElasticConnection connection)
        {
            var cases = RebuildElastic.RebuildPlanning(connectionString, securityTicket);

            if (cases.Count != 0)
            {
                if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/case", connection))
                {
                    Console.WriteLine("Deleting planning section on elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "case");
                }

                ImportToElasticInChunks<Case_Model>(cases, securityTicket.TenantID.ToString(), (data, index) =>
                {
                    Add_New_Case.Import_Case_Data_to_ElasticDB(data, index);
                });
            }
        }

        private static void ImportToElasticInChunks<T>(List<T> data, string index
            , Action<List<T>, string> action)
            where T : IElasticMapper
        {
            var pageSize = 1000;
            var page = 0;
            Console.WriteLine("Total entries to import: {0}", data.Count);
            while (true)
            {
                var skip = pageSize * page;
                if (skip < data.Count)
                {
                    var chunk = data.Skip(skip).Take(pageSize).ToList();
                    Console.WriteLine("Importing {0}. batch of {1}", page + 1, data.Count / pageSize + 1);

                    try
                    {
                        Thread.Sleep(100);
                        action(chunk, index);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine(ex.InnerException.Message);
                            if (ex.InnerException.InnerException != null)
                            {
                                Console.WriteLine(ex.InnerException.InnerException.Message);
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
                page++;
            }

        }

        static void Command32(string connectionString, SessionSecurityTicket securityTicket, ElasticConnection connection)
        {
            var aftercares = RebuildElastic.RebuildAftercare(connectionString, securityTicket);

            if (aftercares.Count != 0)
            {
                if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/aftercare", connection))
                {
                    Console.WriteLine("Deleting aftercare section on elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "aftercare");
                }

                ImportToElasticInChunks<Aftercare_Model>(aftercares, securityTicket.TenantID.ToString(), (data, index) =>
                {
                    Add_New_Aftercare.Import_Aftercare_Data_to_ElasticDB(data, index);
                });
            }
        }

        static void Command33(string connectionString, SessionSecurityTicket securityTicket, ElasticConnection connection, DbConnection Connection = null, DbTransaction Transaction = null)
        {
            var settlements = RebuildElastic.RebuildSettlement(connectionString, securityTicket, Connection, Transaction);

            if (settlements.Count != 0)
            {
                if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/settlement", connection))
                {
                    Console.WriteLine("Deleting settlement section on elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "settlement");
                }

                ImportToElasticInChunks<Settlement_Model>(settlements, securityTicket.TenantID.ToString(), (data, index) =>
                {
                    Add_new_Settlement.Import_Settlement_to_ElasticDB(data, index);
                });
            }
        }

        static void Command34(string connectionString, SessionSecurityTicket securityTicket, ElasticConnection connection)
        {
            var doctorPractices = RebuildElastic.RebuildDoctorsAndPractices(connectionString, securityTicket);

            if (doctorPractices.Count != 0)
            {
                if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/user", connection))
                {
                    Console.WriteLine("Deleting doctors/practices section on elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "user");
                }

                ImportToElasticInChunks<Practice_Doctors_Model>(doctorPractices, securityTicket.TenantID.ToString(), (data, index) =>
                {
                    Add_Practice_Doctors_to_Elastic.Import_Practice_Data_to_ElasticDB(data, index);
                });
            }
        }

        static void Command35(string connectionString, SessionSecurityTicket securityTicket, ElasticConnection connection)
        {
            var patients = RebuildElastic.RebuildPatients(connectionString, securityTicket);
            if (patients.Count != 0)
            {
                if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/patient", connection))
                {
                    Console.WriteLine("Deleting patients section on elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "patient");
                }

                ImportToElasticInChunks<Patient_Model>(patients, securityTicket.TenantID.ToString(), (data, index) =>
                {
                    Add_New_Patient.Import_Patients_List_to_ElasticDB(data, index);
                });
            }
        }

        static void Command36(string connectionString, SessionSecurityTicket securityTicket, ElasticConnection connection)
        {
            var orders = RebuildElastic.RebuildOrders(connectionString, securityTicket);
            if (orders.Count != 0)
            {
                if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/order", connection))
                {
                    Console.WriteLine("Deleting order section on elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "order");
                }

                ImportToElasticInChunks<Order_Model>(orders, securityTicket.TenantID.ToString(), (data, index) =>
                {
                    Add_New_Order.Import_Order_Data_to_ElasticDB(data, index);
                });
            }
        }

        static void Command37(string connectionString, SessionSecurityTicket securityTicket, ElasticConnection connection)
        {
            var treatments = RebuildElastic.RebuildTreatments(connectionString, securityTicket);
            if (treatments.Count != 0)
            {
                if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/submitted_case", connection))
                {
                    Console.WriteLine("Deleting treatment section on elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "submitted_case");
                }

                ImportToElasticInChunks<Submitted_Case_Model>(treatments, securityTicket.TenantID.ToString(), (data, index) =>
                {
                    Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(data, index);
                });
            }
        }

        static void Command38(string connectionString, SessionSecurityTicket securityTicket, ElasticConnection connection)
        {
            var archive = RebuildElastic.RebuildArchive(connectionString, securityTicket);
            if (archive.Count != 0)
            {
                if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/docarchive", connection))
                {
                    Console.WriteLine("Deleting archive section on elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "docarchive");
                }

                ImportToElasticInChunks<Archive_Model>(archive, securityTicket.TenantID.ToString(), (data, index) =>
                {
                    Add_New_Archive.Import_Archive_Item_to_ElasticDB(data, index);
                });
            }
        }

        static void Command39(string connectionString, SessionSecurityTicket securityTicket, ElasticConnection connection)
        {
            var receipt = RebuildElastic.RebuildReceipt(connectionString, securityTicket);
            if (receipt.Count != 0)
            {
                if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/receipts", connection))
                {
                    Console.WriteLine("Deleting receipt section on elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "receipts");
                }

                ImportToElasticInChunks<Receipt_Model>(receipt, securityTicket.TenantID.ToString(), (data, index) =>
                {
                    Add_Item_to_Receipts.Import_Receipt_Item_to_ElasticDB(data, index);
                });
            }
        }

        static void Command310(string connectionString, SessionSecurityTicket securityTicket, ElasticConnection connection)
        {
            var patientDetails = PatientMethods.RebuildPatientDetails(connectionString, securityTicket);
            if (patientDetails.Count() != 0)
            {
                if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/patient_details", connection))
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Deleting patient details section on elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "patient_details");
                }

                List<PatientDetailViewModel> teilMenge = patientDetails.Where(a => a.detail_type == "oct").ToList();
                ImportToElasticInChunks<PatientDetailViewModel>(teilMenge,
                    securityTicket.TenantID.ToString()
                    , (data, index) => { Add_New_Patient.ImportPatientDetailsToElastic(data, index); });


                teilMenge = patientDetails.Where(a => a.detail_type == "ac").ToList();
                ImportToElasticInChunks<PatientDetailViewModel>(teilMenge,
                    securityTicket.TenantID.ToString()
                    , (data, index) => { Add_New_Patient.ImportPatientDetailsToElastic(data, index); });


                teilMenge = patientDetails.Where(a => a.detail_type == "op").ToList();
                ImportToElasticInChunks<PatientDetailViewModel>(teilMenge,
                    securityTicket.TenantID.ToString()
                    , (data, index) => { Add_New_Patient.ImportPatientDetailsToElastic(data, index); });

                teilMenge = patientDetails.Where(a => a.detail_type != "oct" && a.detail_type != "ac" && a.detail_type != "op").ToList();
                ImportToElasticInChunks<PatientDetailViewModel>(teilMenge,
                    securityTicket.TenantID.ToString()
                    , (data, index) => { Add_New_Patient.ImportPatientDetailsToElastic(data, index); });

            }
        }

        static void Command311(string connectionString, SessionSecurityTicket securityTicket, ElasticConnection connection)
        {
            var octs = RebuildElastic.RebuildOct(connectionString, securityTicket);
            if (octs.Count != 0)
            {
                if (Elastic_Utils.IfIndexOrTypeExists(securityTicket.TenantID.ToString() + "/oct", connection))
                {
                    Console.WriteLine("Deleting oct section on elastic...");
                    Elastic_Utils.Delete_Type(securityTicket.TenantID.ToString(), "oct");
                }


                ImportToElasticInChunks<Oct_Model>(octs, securityTicket.TenantID.ToString(), (data, index) =>
                {
                    Add_New_Oct.Import_Oct_Data_to_ElasticDB(data, index);
                });
            }
        }
        #endregion
    }
}


