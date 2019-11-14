using CL1_CMN_BPT;
using CL1_CMN_CTR;
using CL1_CMN_PER;
using CL1_HEC;
using CL1_HEC_CRT;
using CL1_HEC_HIS;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.Elastic_Methods.Doctor.Manipulation;
using DataImporter.Elastic_Methods.Patients.Retrieval;
using DataImporter.Elastic_test.Model;
using DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataImporter.DBMethods.ExportData.Complex.Manipulation
{
    class Save_Patients
    {
        public static void Save_Patients_to_DB(Patient_Model_xls Parameter, bool create_consents, string connectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;
            Guid patient_id = Guid.NewGuid();
            if (cleanupConnection == true)
            {
                Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
                Connection.Open();
            }
            if (cleanupTransaction == true)
            {
                Transaction = Connection.BeginTransaction();
            }

            try
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");

                ORM_HEC_Patient patients = new ORM_HEC_Patient();
                patients.HEC_PatientID = Guid.NewGuid();
                patients.Tenant_RefID = securityTicket.TenantID;
                patients.Creation_Timestamp = DateTime.Now;
                patients.Modification_Timestamp = DateTime.Now;
                patients.CMN_BPT_BusinessParticipant_RefID = Guid.NewGuid();
                patients.Save(Connection, Transaction);
                patient_id = patients.HEC_PatientID;

                ORM_CMN_BPT_BusinessParticipant businesParticipantPatient = new ORM_CMN_BPT_BusinessParticipant();
                businesParticipantPatient.CMN_BPT_BusinessParticipantID = patients.CMN_BPT_BusinessParticipant_RefID;
                businesParticipantPatient.Tenant_RefID = securityTicket.TenantID;
                businesParticipantPatient.Creation_Timestamp = DateTime.Now;
                businesParticipantPatient.Modification_Timestamp = DateTime.Now;
                businesParticipantPatient.IsNaturalPerson = true;
                businesParticipantPatient.IfNaturalPerson_CMN_PER_PersonInfo_RefID = Guid.NewGuid();
                businesParticipantPatient.Save(Connection, Transaction);
                int PatientSex = 0;
                switch (Parameter.sex)
                {
                    case "M":
                        PatientSex = 0;
                        break;
                    case "W":
                        PatientSex = 1;
                        break;
                    case "o.A.":
                        PatientSex = 2;
                        break;
                }

                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.CMN_PER_PersonInfoID = businesParticipantPatient.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                personInfo.Tenant_RefID = securityTicket.TenantID;
                personInfo.Creation_Timestamp = DateTime.Now;
                personInfo.Modification_Timestamp = DateTime.Now;
                personInfo.FirstName = Parameter.name;
                personInfo.LastName = Parameter.LastName;
                personInfo.BirthDate = Parameter.birthday;
                personInfo.Gender = PatientSex;
                personInfo.Save(Connection, Transaction);

                ORM_HEC_Patient_MedicalPractice medical_practice_to_patient = new ORM_HEC_Patient_MedicalPractice();
                medical_practice_to_patient.HEC_Patient_MedicalPracticeID = Guid.NewGuid();
                medical_practice_to_patient.HEC_Patient_RefID = patients.HEC_PatientID;
                medical_practice_to_patient.HEC_MedicalPractices_RefID = Guid.Parse(Parameter.practice_id);//
                medical_practice_to_patient.Tenant_RefID = securityTicket.TenantID;
                medical_practice_to_patient.Creation_Timestamp = DateTime.Now;
                medical_practice_to_patient.Save(Connection, Transaction);


                var medicalPracticeQuery = new ORM_HEC_HIS_HealthInsurance_Company.Query();
                medicalPracticeQuery.IsDeleted = false;
                medicalPracticeQuery.Tenant_RefID = securityTicket.TenantID;

                var HIPList = ORM_HEC_HIS_HealthInsurance_Company.Query.Search(Connection, Transaction, medicalPracticeQuery).ToList();

                if (Parameter.isPrivatelyInsured)
                    Parameter.health_insurance_providerNumber = "000000000";

                var GetHip = HIPList.Where(hp => hp.HealthInsurance_IKNumber == Parameter.health_insurance_providerNumber).SingleOrDefault();
                if (GetHip == null)
                {
                    var businessParticipantHIP = new ORM_CMN_BPT_BusinessParticipant();
                    businessParticipantHIP.IsCompany = true;
                    businessParticipantHIP.Tenant_RefID = securityTicket.TenantID;
                    businessParticipantHIP.Modification_Timestamp = DateTime.Now;
                    businessParticipantHIP.DisplayName = Parameter.health_insurance_provider;

                    businessParticipantHIP.Save(Connection, Transaction);

                    GetHip = new ORM_HEC_HIS_HealthInsurance_Company();
                    GetHip.Tenant_RefID = securityTicket.TenantID;
                    GetHip.CMN_BPT_BusinessParticipant_RefID = businessParticipantHIP.CMN_BPT_BusinessParticipantID;
                    GetHip.HealthInsurance_IKNumber = String.IsNullOrEmpty(Parameter.health_insurance_provider) ? "privat versichert" : Parameter.health_insurance_provider;

                    GetHip.Save(Connection, Transaction);
                }

                ORM_HEC_Patient_HealthInsurance patientHealthInsurance = new ORM_HEC_Patient_HealthInsurance();
                patientHealthInsurance.HEC_Patient_HealthInsurancesID = Guid.NewGuid();
                patientHealthInsurance.Patient_RefID = patients.HEC_PatientID;
                patientHealthInsurance.HealthInsurance_Number = Parameter.insurance_id;//
                patientHealthInsurance.Tenant_RefID = securityTicket.TenantID;
                patientHealthInsurance.InsuranceStateCode = Parameter.insurance_status;//
                patientHealthInsurance.HIS_HealthInsurance_Company_RefID = GetHip.HEC_HealthInsurance_CompanyID;
                patientHealthInsurance.Save(Connection, Transaction);

                #region import Patient to Elastic
                Patient_Model patientModel = new Patient_Model();


                patientModel.birthday = Parameter.birthday;
                patientModel.birthday_string = Parameter.birthday.ToString("dd.MM.yyyy");
                patientModel.name = Parameter.LastName + ", " + Parameter.name;
                patientModel.health_insurance_provider = String.IsNullOrEmpty(Parameter.health_insurance_provider) ? "privat versichert" : Parameter.health_insurance_provider;
                patientModel.name_with_birthdate = Parameter.name + " " + Parameter.LastName + " (" + Parameter.birthday.ToString("dd.MM.yyyy") + ")";
                patientModel.id = patients.HEC_PatientID.ToString();
                patientModel.insurance_id = String.IsNullOrEmpty(Parameter.insurance_id) ? "-" : Parameter.insurance_id;
                patientModel.insurance_status = String.IsNullOrEmpty(Parameter.insurance_status) ? "-" : Parameter.insurance_status;
                patientModel.practice_id = Parameter.practice_id.ToString();

                if (PatientSex == 0)
                    patientModel.sex = "M";
                else if (PatientSex == 1)
                    patientModel.sex = "W";
                else if (PatientSex == 2)
                    patientModel.sex = "o.A.";

                Add_New_Patient.Import_Patients_to_ElasticDB(patientModel, securityTicket.TenantID.ToString());
                if (create_consents)
                {
                    #region Participation Consent
                    var contractIvi = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        ContractName = "IVI-Vertrag"
                    }).SingleOrDefault();

                    if (contractIvi != null)
                    {
                        var InsuranceToBrokerContractQuery = new ORM_HEC_CRT_InsuranceToBrokerContract.Query();
                        InsuranceToBrokerContractQuery.Tenant_RefID = securityTicket.TenantID;
                        InsuranceToBrokerContractQuery.IsDeleted = false;
                        InsuranceToBrokerContractQuery.Ext_CMN_CTR_Contract_RefID = contractIvi.CMN_CTR_ContractID;

                        ORM_HEC_CRT_InsuranceToBrokerContract InsuranceToBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, InsuranceToBrokerContractQuery).Single();

                        List<DateTime> TimeFrom = new List<DateTime>();
                        DateTime time1 = new DateTime(2013, 6, 15);
                        DateTime time2 = new DateTime(2014, 6, 15);
                        DateTime time3 = new DateTime(2015, 6, 15);

                        TimeFrom.Add(time1);
                        TimeFrom.Add(time2);
                        TimeFrom.Add(time3);
                        foreach (var date in TimeFrom)
                        {
                            ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient InsuranceToBrokerContract_ParticipatingPatient = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient();
                            InsuranceToBrokerContract_ParticipatingPatient.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = Guid.NewGuid();
                            InsuranceToBrokerContract_ParticipatingPatient.InsuranceToBrokerContract_RefID = InsuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                            InsuranceToBrokerContract_ParticipatingPatient.Creation_Timestamp = DateTime.Now;
                            InsuranceToBrokerContract_ParticipatingPatient.Modification_Timestamp = DateTime.Now;
                            InsuranceToBrokerContract_ParticipatingPatient.Tenant_RefID = securityTicket.TenantID;
                            InsuranceToBrokerContract_ParticipatingPatient.ValidFrom = date;
                            InsuranceToBrokerContract_ParticipatingPatient.ValidThrough = DateTime.MinValue;
                            InsuranceToBrokerContract_ParticipatingPatient.Patient_RefID = patient_id;
                            InsuranceToBrokerContract_ParticipatingPatient.Save(Connection, Transaction);

                            Patient_Model patientModel2 = new Patient_Model();
                            patientModel2 = Retrieve_Patients.Get_Patient_for_PatientID(patient_id.ToString(), securityTicket);

                            var InsuranceToBrokerContract_ParticipatingPatientQuery = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query();
                            InsuranceToBrokerContract_ParticipatingPatientQuery.IsDeleted = false;
                            InsuranceToBrokerContract_ParticipatingPatientQuery.Tenant_RefID = securityTicket.TenantID;
                            InsuranceToBrokerContract_ParticipatingPatientQuery.Patient_RefID = patient_id;

                            var allInsuranceToBrokerContract_ParticipatingPatient = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(Connection, Transaction, InsuranceToBrokerContract_ParticipatingPatientQuery).ToList();
                            var latest_participation_date = allInsuranceToBrokerContract_ParticipatingPatient.OrderByDescending(m => m.ValidFrom).FirstOrDefault();

                            patientModel2.participation_consent_from = latest_participation_date.ValidFrom;
                            patientModel2.participation_consent_to = latest_participation_date.ValidThrough;
                            patientModel2.has_participation_consent = true;

                            Add_New_Patient.Import_Patients_to_ElasticDB(patientModel2, securityTicket.TenantID.ToString());
                        }
                    }
                }

                    #endregion
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

                throw ex;
            }

                #endregion

        }
    }
}
