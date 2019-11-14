using CL1_BIL;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.Excel_Templates;
using DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Methods
{
    public static class ExportOldDataMethods
    {

        public static void ExportPracticesFromOldSystem(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            Console.WriteLine("----- Retrieving practices from DB started.");
            List<ED_GAPOD_1624> practiceList = cls_Get_AllPractices_OldData.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            Console.WriteLine("----- Practices retrieved.");

            Console.WriteLine("----- Creating XLS.");
            string file = ExportPracticesXLSTemplate.generateExportPracticeTemplate(practiceList);

            MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));

            Console.WriteLine("----- XLS created.");
        }

        public static void ExportDoctorsFromOldSystem(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            Console.WriteLine("----- Retrieving doctors from DB started.");
            var rawData = cls_Get_Doctors_OldData.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            List<Doctor_Model> doctorList = new List<Doctor_Model>();

            foreach(var item in rawData)
            {
                Doctor_Model doctor = new Doctor_Model();
                doctor.account_holder = item.AccountHolder;
                doctor.bank_name = item.BankName;
                doctor.bic = item.BICCode;
                doctor.first_name = item.FirstName;
                doctor.iban = item.IBAN;
                doctor.lanr = item.LANR;
                doctor.last_name = item.LastName;
                doctor.login_email = item.LoginEmail;
        
                doctor.title = doctor.title;
                List<Practice_Model_for_import> practiceList = new List<Practice_Model_for_import>();
                foreach (var itemPractice in item.AllPractices)
                {
                    Practice_Model_for_import practice = new Practice_Model_for_import();
                    practice.bsnr = itemPractice.BSNR;
                    practice.name = itemPractice.PracticeName;
                    practiceList.Add(practice);
                }
                doctor.practice_list = practiceList;
                foreach(var contentType in item.ContactTypes)
                {
                       if (contentType.Contact_Type == new Guid("35bacb40-ea8c-4474-a58f-f3fe931a7f02"))
                           doctor.phone = contentType.Content;

                       if (contentType.Contact_Type == new Guid("45eb89dc-cb98-43c1-8954-b51a38d31b23"))
                           doctor.email = contentType.Content;
                }

                doctorList.Add(doctor);
            }
            Console.WriteLine("----- Doctors retrieved.");

            Console.WriteLine("----- Creating XLS.");

            string file = ExportDoctorsXLSTemplate.generateExportDoctorsTemplate(doctorList);

             MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));

            Console.WriteLine("----- XLS created.");
        }

        public static void ExportPatientsFromOldSystem(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            //Console.WriteLine("----- Retrieving patients from DB started.");

            //List<ED_GPfOS_1048> patientList = cls_Get_Patients_from_old_System.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            //Console.WriteLine("----- Patients retrieved.");

            //Console.WriteLine("----- Creating XLS.");
            //string file = ExportPatientsXLSTemplate.ExportpatientsBeforeUploadToDB(patientList);

            //MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));

            //Console.WriteLine("----- XLS created.");
        }

        public static void ExportCasesFromOldSystem(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            Console.WriteLine("----- Retrieving cases from DB started.");
            List<ED_GATOS_1212> treatments = cls_Get_All_Treatments_OLD_System.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            Console.WriteLine("----- Cases retrieved.");

            List<CaseModel> caseList = new List<CaseModel>();
            List<ED_GATOS_1212> moreThenOneArticleList = new List<ED_GATOS_1212>();
            List<ED_GATOS_1212> moreThenOneDiagnoseList = new List<ED_GATOS_1212>();
            List<ED_GATOS_1212> moreThenOneAftercareList = new List<ED_GATOS_1212>();
            List<ED_GAAOS_1312> aftercareList = new List<ED_GAAOS_1312>();
            //key treatmentID, list of aftercares for the treatment (only if there is more then one)
            Dictionary<Guid, List<ED_GAAOS_1312>> aftercarDictionaryForMoreThenOneAftercare = new Dictionary<Guid, List<ED_GAAOS_1312>>();

            int counter = 1;
            foreach(var treatment in treatments)
            {
                CaseModel caseModel = new CaseModel();
                caseModel.opFSStatuses = new FS();
                caseModel.acFSStatuses = new FS();
                caseModel.patientFirstName = treatment.PatientFirstName;
                caseModel.patientLastName = treatment.PatientLastName;
                caseModel.hip = treatment.HealthInsurance_Number;
                caseModel.treatmentDate = treatment.isTreatmentPerformed ? treatment.treatmentPerformedDate.ToString("dd.MM.yyyy") : treatment.treatmentScheduledDate.ToString("dd.MM.yyyy");
                caseModel.op1 = treatment.treatmentScheduledDate.ToString("dd.MM.yyyy");
                caseModel.op2 = treatment.isTreatmentPerformed? treatment.treatmentPerformedDate.ToString("dd.MM.yyyy") : "not performed";
                caseModel.opFSStatuses.fs1 = caseModel.op2;
                caseModel.localization = treatment.IsTreatmentOfLeftEye ? "L" : "R";
                caseModel.bevacizumabFSStatuses = new FS();
                caseModel.managementFeeFSStatuses = new FS();
                caseModel.opDocFirstName = treatment.isTreatmentPerformed ? treatment.OPperformedDoctorFirstName : treatment.OPScheduledDoctorFirstName;
                caseModel.opDocLastName = treatment.isTreatmentPerformed ? treatment.OPperformedDoctorLastName : treatment.OPperformedDoctorLastName;
                caseModel.opDocLANR = treatment.isTreatmentPerformed ? treatment.OPperformedDoctorLANR : treatment.OPscheduledDoctorLANR;
                caseModel.treatmentPractice = new Practice();
                caseModel.aftercarePractice = new Practice();
                caseModel.treatmentPractice.BSNR = treatment.BSNR;
                caseModel.treatmentPractice.Name = treatment.PracticeName;

                //drugs
                if (treatment.Articles.Length > 1)
                {
                    moreThenOneArticleList.Add(treatment);
                    caseModel.drugName = treatment.Articles[0].ArticleName;
                    caseModel.pzn = treatment.Articles[0].PZN;

                }
                else
                {
                    if(treatment.Articles.Length!=0)
                    {
                        caseModel.drugName = treatment.Articles[0].ArticleName;
                        caseModel.pzn = treatment.Articles[0].PZN;
                    }
                    
                }
                   

                //diagnoses
                if (treatment.Diagnoses.Length > 1)
                {
                    var diagnosesGroupped = treatment.Diagnoses.GroupBy(w => w.ICD10_Code).ToList();

                    if(diagnosesGroupped.Count>1)
                    {
                        moreThenOneDiagnoseList.Add(treatment);
                        continue;
                    }
                    else
                    {
                        caseModel.icd10 = treatment.Diagnoses[0].ICD10_Code;
                    }
                    
                }
                else
                {
                    if(treatment.Diagnoses.Length!=0)
                    {
                        caseModel.icd10 = treatment.Diagnoses[0].ICD10_Code;
                    }
                }


                if(treatment.isTreatmentBilled)
                {
                    var billPositions = cls_Get_All_BillPositions_for_TreatmentID_from_OLD_System.Invoke(Connection, Transaction, new P_ED_GABfTIDOS_1712 {TreatmentID=treatment.HEC_Patient_TreatmentID }, securityTicket).Result.ToList();

                    bool isOldBillWay = false;

                    foreach(var billPosition in billPositions)
                    {
                        #region Behandlung || Behandlung | Nachsorge

                        if (billPosition.External_PositionType == "Behandlung" || billPosition.External_PositionType == "Behandlung | Nachsorge")
                        {

                            if (billPosition.External_PositionType == "Behandlung | Nachsorge")
                                isOldBillWay = true;

                            caseModel.opSettlementNumber = billPosition.VorgangsNummer;
                            caseModel.opFSStatuses.gpos = billPosition.GPOS;

                            int activeCode = 0;

                            activeCode = billPosition.TransmitionCode;

                            // TODO: Edited cases: 2, 5, 6
                            switch(activeCode)
                            {
                                case 2:
                                    caseModel.op5 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.opFSStatuses.fs2 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    //caseModel.opFSStatuses.fs1 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 3:
                                    caseModel.op6 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.opFSStatuses.fs4 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 4:
                                    caseModel.op7 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.opFSStatuses.fs5 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 5:
                                    caseModel.op8 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.opFSStatuses.fs7 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    //caseModel.opFSStatuses.fs2 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;                             
                                case 6:
                                    caseModel.op8 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.opFSStatuses.fs7 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.opFSStatuses.fs4 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 7:
                                    caseModel.op10 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.opFSStatuses.fs8 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                            }

                            if(activeCode!=2)
                            {
                                var transmitionStatusQuery = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                                transmitionStatusQuery.Tenant_RefID = securityTicket.TenantID;
                                transmitionStatusQuery.BillPosition_RefID = billPosition.BIL_BillPositionID;
                                transmitionStatusQuery.TransmitionCode = 2;

                                var transmitionStatusList = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmitionStatusQuery).ToList();

                                var status2 = new ORM_BIL_BillPosition_TransmitionStatus();

                                if (transmitionStatusList.Where(p => p.IsDeleted = false).SingleOrDefault() != null)
                                    status2 = transmitionStatusList.Where(p => p.IsDeleted = false).SingleOrDefault();
                                else
                                    status2=transmitionStatusList.First();

                                caseModel.op5 = status2.TransmittedOnDate.ToString("dd.MM.yyyy");
                                caseModel.opFSStatuses.fs1 = status2.TransmittedOnDate.ToString("dd.MM.yyyy");
                            }

                        }
                        #endregion 

                        #region  Wartezeitenmanagement
                        if (billPosition.External_PositionType == "Wartezeitenmanagement")
                        {
                            caseModel.managementFeeSettlementNumber = billPosition.VorgangsNummer;
                            caseModel.managementFeeFSStatuses.gpos = billPosition.GPOS;
                            int activeCode = 0;

                            activeCode = billPosition.TransmitionCode;


                            switch (activeCode)
                            {
                                case 2:
                                    caseModel.managementFeeFSStatuses.fs1 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 3:
                                    caseModel.managementFeeFSStatuses.fs4 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 4:
                                    caseModel.managementFeeFSStatuses.fs5 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 5:
                                    caseModel.managementFeeFSStatuses.fs2 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;

                                case 6:
                                    caseModel.managementFeeFSStatuses.fs7 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 7:
                                    caseModel.managementFeeFSStatuses.fs8 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                            }

                            if (activeCode != 2)
                            {
                                var transmitionStatusQuery = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                                transmitionStatusQuery.Tenant_RefID = securityTicket.TenantID;
                                transmitionStatusQuery.BillPosition_RefID = billPosition.BIL_BillPositionID;
                                transmitionStatusQuery.TransmitionCode = 2;

                                var transmitionStatusList = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmitionStatusQuery).ToList();

                                var status2 = new ORM_BIL_BillPosition_TransmitionStatus();

                                if (transmitionStatusList.Where(p => p.IsDeleted = false).SingleOrDefault() != null)
                                    status2 = transmitionStatusList.Where(p => p.IsDeleted = false).SingleOrDefault();
                                else
                                    status2 = transmitionStatusList.First();

                                caseModel.managementFeeFSStatuses.fs1 = status2.TransmittedOnDate.ToString("dd.MM.yyyy");
                            }

                        }
                        #endregion

                        #region Zusatzposition Bevacuzimab
                        if (billPosition.External_PositionType == "Zusatzposition Bevacuzimab")                            
                        {
                            caseModel.bevacizumabSettlementNumber = billPosition.VorgangsNummer;
                            caseModel.bevacizumabFSStatuses.gpos = billPosition.GPOS;
                            int activeCode = 0;

                            activeCode = billPosition.TransmitionCode;


                            switch (activeCode)
                            {
                                case 2:
                                    caseModel.bevacizumabFSStatuses.fs1 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 3:
                                    caseModel.bevacizumabFSStatuses.fs4 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 4:
                                    caseModel.bevacizumabFSStatuses.fs5 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 5:
                                    caseModel.bevacizumabFSStatuses.fs2 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;

                                case 6:
                                    caseModel.bevacizumabFSStatuses.fs7 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 7:
                                    caseModel.bevacizumabFSStatuses.fs8 = billPosition.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                            }

                            if (activeCode != 2)
                            {
                                var transmitionStatusQuery = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                                transmitionStatusQuery.Tenant_RefID = securityTicket.TenantID;
                                transmitionStatusQuery.BillPosition_RefID = billPosition.BIL_BillPositionID;
                                transmitionStatusQuery.TransmitionCode = 2;

                                var transmitionStatusList = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmitionStatusQuery).ToList();

                                var status2 = new ORM_BIL_BillPosition_TransmitionStatus();

                                if (transmitionStatusList.Where(p => p.IsDeleted = false).SingleOrDefault() != null)
                                    status2 = transmitionStatusList.Where(p => p.IsDeleted = false).SingleOrDefault();
                                else
                                    status2 = transmitionStatusList.First();

                                caseModel.bevacizumabFSStatuses.fs1 = status2.TransmittedOnDate.ToString("dd.MM.yyyy");
                            }


                        }
                        #endregion

                    }

                    #region Aftercare
                    

                    //Aftercare
                    var aftercareArray = cls_Get_All_Aftercares_OLD_System.Invoke(Connection, Transaction, new P_ED_GAAOS_1312 { TreatmentID = treatment.HEC_Patient_TreatmentID }, securityTicket).Result;

                    if (aftercareArray.Length > 1)
                    {
                        if (aftercareArray.Length != 2)
                        {
                            moreThenOneAftercareList.Add(treatment);
                            aftercarDictionaryForMoreThenOneAftercare.Add(treatment.HEC_Patient_TreatmentID, aftercareArray.ToList());
                            continue;
                        }
                        else
                        {
                            if(aftercareArray[0].FollowupID != aftercareArray[1].FollowupID)
                            {
                                moreThenOneAftercareList.Add(treatment);
                                aftercarDictionaryForMoreThenOneAftercare.Add(treatment.HEC_Patient_TreatmentID, aftercareArray.ToList());
                                continue;
                            }
                            else
                            {
                                aftercareArray = aftercareArray.Where(f => f.BIL_BillPositionID != Guid.Empty).ToArray();
                            }
                        }
                    }

                    if (aftercareArray.Length != 0)
                    {


                        ED_GAAOS_1312 aftercare = aftercareArray[0];
                        caseModel.acDocFirstName = aftercare.isTreatmentPerformed ? aftercare.PerformedDoctorFirstName : aftercare.ScheduledDoctorFirstName;
                        caseModel.acDocLastName = aftercare.isTreatmentPerformed ? aftercare.PerformedDoctorLastName : aftercare.ScheduledDoctorLastName;
                        caseModel.acDocLANR = aftercare.isTreatmentPerformed ? aftercare.PerformedDoctorLANR : aftercare.ScheduledDoctorLANR;
                        caseModel.ac1 = aftercare.IfSheduled_Date.ToString("dd.MM.yyyy");
                        caseModel.aftercarePractice.BSNR = aftercare.BSNR;
                        caseModel.aftercarePractice.Name = aftercare.PracticeName;

                        if (aftercare.isTreatmentPerformed)
                        {
                            caseModel.ac2 = aftercare.IfTreatmentPerformed_Date.ToString("dd.MM.yyyy");
                            caseModel.acFSStatuses.fs1 = caseModel.ac2;
                        }

                        if (isOldBillWay)
                        {
                            caseModel.acSettlementNumber = caseModel.opSettlementNumber;
                            caseModel.acFSStatuses.fs1 = caseModel.opFSStatuses.fs1;
                            caseModel.acFSStatuses.fs2 = caseModel.opFSStatuses.fs2;
                            caseModel.acFSStatuses.fs4 = caseModel.opFSStatuses.fs4;
                            caseModel.acFSStatuses.fs5 = caseModel.opFSStatuses.fs5;
                            caseModel.acFSStatuses.fs7 = caseModel.opFSStatuses.fs7;
                            caseModel.acFSStatuses.fs8 = caseModel.opFSStatuses.fs8;
                            caseModel.acFSStatuses.gpos = caseModel.opFSStatuses.gpos;

                        }
                        else
                        {
                            if (aftercare.isTreatmentBilled)
                            {
                                caseModel.acSettlementNumber = aftercare.VorgangsNummer;
                                caseModel.acFSStatuses.gpos = aftercare.GPOS;
                                switch (aftercare.TransmitionCode)
                                {
                                    case 2:
                                        caseModel.ac6 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        caseModel.acFSStatuses.fs2 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        break;
                                    case 3:
                                        caseModel.ac7 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        caseModel.acFSStatuses.fs4 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        break;
                                    case 4:
                                        caseModel.ac8 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        caseModel.acFSStatuses.fs5 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        break;
                                    case 5:
                                        caseModel.ac9 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        caseModel.acFSStatuses.fs7 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        break;
                                    case 6:
                                        caseModel.ac9 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        caseModel.acFSStatuses.fs7 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        caseModel.acFSStatuses.fs4 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        break;
                                    case 7:
                                        caseModel.ac11 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        caseModel.acFSStatuses.fs8 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        break;
                                }

                                if (aftercare.TransmitionCode != 2)
                                {
                                    var transmitionStatusQuery = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                                    transmitionStatusQuery.Tenant_RefID = securityTicket.TenantID;
                                    transmitionStatusQuery.BillPosition_RefID = aftercare.BIL_BillPositionID;
                                    transmitionStatusQuery.TransmitionCode = 2;

                                    var transmitionStatusList = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmitionStatusQuery).ToList();

                                    if (transmitionStatusList.Count > 0)
                                    {
                                        var status2 = new ORM_BIL_BillPosition_TransmitionStatus();

                                        if (transmitionStatusList.Where(p => p.IsDeleted = false).SingleOrDefault() != null)
                                            status2 = transmitionStatusList.Where(p => p.IsDeleted = false).SingleOrDefault();
                                        else
                                            status2 = transmitionStatusList.First();

                                        caseModel.ac6 = status2.TransmittedOnDate.ToString("dd.MM.yyyy");
                                        caseModel.acFSStatuses.fs1 = status2.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    }
                                }

                            }

                        }
                    }
                }
                else
                {
                    //Treatment was never billed
                    var aftercareArray = cls_Get_All_Aftercares_OLD_System.Invoke(Connection, Transaction, new P_ED_GAAOS_1312 { TreatmentID = treatment.HEC_Patient_TreatmentID }, securityTicket).Result;
                    if (aftercareArray.Length > 1)
                    {
                        if (aftercareArray.Length != 2)
                        {
                            moreThenOneAftercareList.Add(treatment);
                            aftercarDictionaryForMoreThenOneAftercare.Add(treatment.HEC_Patient_TreatmentID, aftercareArray.ToList());
                            continue;
                        }
                        else
                        {
                            if (aftercareArray[0].FollowupID != aftercareArray[1].FollowupID)
                            {
                                moreThenOneAftercareList.Add(treatment);
                                aftercarDictionaryForMoreThenOneAftercare.Add(treatment.HEC_Patient_TreatmentID, aftercareArray.ToList());
                                continue;
                            }
                            else
                            {
                                aftercareArray = aftercareArray.Where(f => f.BIL_BillPositionID != Guid.Empty).ToArray();
                            }
                        }
                    }

                    if (aftercareArray.Length != 0)
                    {

                        var aftercare = aftercareArray[0];
                        caseModel.acDocFirstName = aftercare.isTreatmentPerformed ? aftercare.PerformedDoctorFirstName : aftercare.ScheduledDoctorFirstName;
                        caseModel.acDocLastName = aftercare.isTreatmentPerformed ? aftercare.PerformedDoctorLastName : aftercare.ScheduledDoctorLastName;
                        caseModel.acDocLANR = aftercare.isTreatmentPerformed ? aftercare.PerformedDoctorLANR : aftercare.ScheduledDoctorLANR;
                        caseModel.aftercarePractice.BSNR = aftercare.BSNR;
                        caseModel.aftercarePractice.Name = aftercare.PracticeName;
                        caseModel.ac1 = aftercare.IfSheduled_Date.ToString("dd.MM.yyyy");
                        if (aftercare.isTreatmentBilled)
                            caseModel.ac2 = aftercare.IfTreatmentPerformed_Date.ToString("dd.MM.yyyy");
                        if (aftercare.isTreatmentPerformed)
                        {
                            caseModel.acSettlementNumber = aftercare.VorgangsNummer;
                        }

                        if (aftercare.isTreatmentBilled)
                        {
                            caseModel.acSettlementNumber = aftercare.VorgangsNummer;
                            caseModel.acFSStatuses.gpos = aftercare.GPOS;

                            switch (aftercare.TransmitionCode)
                            {
                                case 2:
                                    caseModel.ac6 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.acFSStatuses.fs1 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 3:
                                    caseModel.ac7 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.acFSStatuses.fs4 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 4:
                                    caseModel.ac8 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.acFSStatuses.fs5 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 5:
                                    caseModel.ac9 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.acFSStatuses.fs2 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 6:
                                    caseModel.ac9 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.acFSStatuses.fs7 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                                case 7:
                                    caseModel.ac11 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.acFSStatuses.fs8 = aftercare.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    break;
                            }

                            if (aftercare.TransmitionCode != 2)
                            {
                                var transmitionStatusQuery = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                                transmitionStatusQuery.Tenant_RefID = securityTicket.TenantID;
                                transmitionStatusQuery.BillPosition_RefID = aftercare.BIL_BillPositionID;
                                transmitionStatusQuery.TransmitionCode = 2;

                                var transmitionStatusList = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmitionStatusQuery).ToList();

                                if (transmitionStatusList.Count > 0)
                                {
                                    var status2 = new ORM_BIL_BillPosition_TransmitionStatus();

                                    if (transmitionStatusList.Where(p => p.IsDeleted = false).SingleOrDefault() != null)
                                        status2 = transmitionStatusList.Where(p => p.IsDeleted = false).SingleOrDefault();
                                    else
                                        status2 = transmitionStatusList.First();

                                    caseModel.ac6 = status2.TransmittedOnDate.ToString("dd.MM.yyyy");
                                    caseModel.acFSStatuses.fs1 = status2.TransmittedOnDate.ToString("dd.MM.yyyy");
                                }
                            }

                        }

                    }
                }

                    #endregion



                caseList.Add(caseModel);
                Console.WriteLine(counter+"___________________________________________"+treatments.Count);
                counter++;
            }

            Console.WriteLine("----- Creating XLS.");

            string file_aftercare = ExportCasesXLSTemplate.ExportCasesMoreThenOneAftercare(moreThenOneAftercareList, aftercarDictionaryForMoreThenOneAftercare);
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(file_aftercare));


            string file_article = ExportCasesXLSTemplate.ExportCasesMoreThenOneArticle(moreThenOneArticleList);
            ms = new MemoryStream(File.ReadAllBytes(file_article));

            string file_diagnose = ExportCasesXLSTemplate.ExportCasesMoreThenOneDiagnose(moreThenOneDiagnoseList);
            ms = new MemoryStream(File.ReadAllBytes(file_diagnose));

            string file = ExportCasesXLSTemplate.ExportCasesBeforeUploadToDB(caseList);
            ms = new MemoryStream(File.ReadAllBytes(file));
            Console.WriteLine("----- XLS created.");
        }
    }
}
