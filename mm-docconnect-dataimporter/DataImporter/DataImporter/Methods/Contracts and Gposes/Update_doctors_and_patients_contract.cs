using CL1_CMN_CTR;
using CL1_HEC;
using CL1_HEC_CRT;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.Elastic_Methods.Doctor.Manipulation;
using DataImporter.Elastic_Methods.Doctor.Retrieval;
using DataImporter.Elastic_Methods.Patients.Retrieval;
using DataImporter.Models;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Methods.Contracts_and_Gposes
{
    public class Update_doctors_and_patients_contract
    {
        public static void Update_Doctors_add_Contract_Assignment(string connectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;
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
                var allDoctors = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).ToList();
                foreach (var doctor in allDoctors)
                {
                    #region Assignment to Contract

                    var contractIvi = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        ContractName = "IVI-Vertrag"
                    }).SingleOrDefault();
                    if (contractIvi != null)
                    {
                        Guid AssignmentID = Guid.NewGuid();
                        var insuranceTobrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                        {
                            Ext_CMN_CTR_Contract_RefID = contractIvi.CMN_CTR_ContractID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,

                        }).SingleOrDefault();
                        if (insuranceTobrokerContract != null)
                        {
                            AssignmentID = insuranceTobrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                        }
                        else
                        {

                            var insuranceTobrokerContractNew = new ORM_HEC_CRT_InsuranceToBrokerContract();
                            insuranceTobrokerContractNew.HEC_CRT_InsuranceToBrokerContractID = Guid.NewGuid();
                            insuranceTobrokerContractNew.Creation_Timestamp = DateTime.Now;
                            insuranceTobrokerContractNew.IsDeleted = false;
                            insuranceTobrokerContractNew.Tenant_RefID = securityTicket.TenantID;
                            insuranceTobrokerContractNew.Ext_CMN_CTR_Contract_RefID = contractIvi.CMN_CTR_ContractID;
                            insuranceTobrokerContractNew.Save(Connection, Transaction);
                            AssignmentID = insuranceTobrokerContractNew.HEC_CRT_InsuranceToBrokerContractID;

                        }
                        var insuranceTobrokerContract2doctor = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor();
                        insuranceTobrokerContract2doctor.Creation_Timestamp = DateTime.Now;
                        insuranceTobrokerContract2doctor.HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID = Guid.NewGuid();
                        insuranceTobrokerContract2doctor.InsuranceToBrokerContract_RefID = AssignmentID;
                        insuranceTobrokerContract2doctor.Tenant_RefID = securityTicket.TenantID;
                        insuranceTobrokerContract2doctor.IsDeleted = false;
                        insuranceTobrokerContract2doctor.Doctor_RefID = doctor.HEC_DoctorID;
                        insuranceTobrokerContract2doctor.ValidFrom = new DateTime(2013, 6, 15);
                        insuranceTobrokerContract2doctor.ValidThrough = DateTime.MinValue;
                        insuranceTobrokerContract2doctor.Save(Connection, Transaction);

                        P_DO_CDCD_1505 ParameterDoctorID = new P_DO_CDCD_1505();
                        ParameterDoctorID.DoctorID = doctor.HEC_DoctorID;
                        var data = cls_Get_Doctor_Contract_Numbers.Invoke(Connection, Transaction, ParameterDoctorID, securityTicket).Result;

                        int DoctorContracts = data.Count();
                        Doctor_Contracts ParameterDoctor = new Doctor_Contracts();
                        ParameterDoctor.DocID = doctor.HEC_DoctorID;

                        Practice_Doctors_Model DoctorFound = Get_Doctors_for_PracticeID.Set_Contract_Number_for_DoctorID(ParameterDoctor, securityTicket);

                        if (DoctorFound != null)
                        {
                            List<Practice_Doctors_Model> DoctorFoundL = new List<Practice_Doctors_Model>();
                            DoctorFound.contract = DoctorContracts;
                            DoctorFoundL.Add(DoctorFound);
                            Add_Practice_Doctors_to_Elastic.Import_Practice_Data_to_ElasticDB(DoctorFoundL, securityTicket.TenantID.ToString());
                        }


                        P_DO_GPIDfDID_1353 ParametarDocID = new P_DO_GPIDfDID_1353();
                        ParametarDocID.DoctorID = doctor.HEC_DoctorID;
                        DO_GPIDfDID_1353[] data2 = cls_Get_PracticeID_for_DoctorID.Invoke(Connection, Transaction, ParametarDocID, securityTicket).Result;

                        P_DO_GCfPID_1507 ParametarPractice = new P_DO_GCfPID_1507();

                        ParametarPractice.PracticeID = data2.First().HEC_MedicalPractiseID;
                        DO_GCfPID_1507[] Contracts = cls_Get_all_Doctors_Contract_Assignment_for_PracticeID.Invoke(Connection, Transaction, ParametarPractice, securityTicket).Result;
                        int NumberOfContractsForPractice = Contracts.Count();
                        Practice_Doctors_Model practice = new Practice_Doctors_Model();
                        practice.id = ParametarPractice.PracticeID.ToString();

                        Practice_Doctors_Model PracticeFound = Get_Doctors_for_PracticeID.Get_Practice_for_PracticeID(practice, securityTicket);
                        List<Practice_Doctors_Model> practiceL = new List<Practice_Doctors_Model>();
                        PracticeFound.contract = NumberOfContractsForPractice;
                        practiceL.Add(PracticeFound);
                        Add_Practice_Doctors_to_Elastic.Import_Practice_Data_to_ElasticDB(practiceL, securityTicket.TenantID.ToString());
                    #endregion
                    }
                }

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

        }

        public static void Update_Patients_add_Participation_Consent(string connectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;
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

                var allPatients = ORM_HEC_Patient.Query.Search(Connection, Transaction, new ORM_HEC_Patient.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).ToList();

                foreach (var patient in allPatients)
                {
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
                            InsuranceToBrokerContract_ParticipatingPatient.Patient_RefID = patient.HEC_PatientID;
                            InsuranceToBrokerContract_ParticipatingPatient.Save(Connection, Transaction);


                            Patient_Model patientModel2 = new Patient_Model();
                            patientModel2 = Retrieve_Patients.Get_Patient_for_PatientID(patient.HEC_PatientID.ToString(), securityTicket);

                            var InsuranceToBrokerContract_ParticipatingPatientQuery = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query();
                            InsuranceToBrokerContract_ParticipatingPatientQuery.IsDeleted = false;
                            InsuranceToBrokerContract_ParticipatingPatientQuery.Tenant_RefID = securityTicket.TenantID;
                            InsuranceToBrokerContract_ParticipatingPatientQuery.Patient_RefID = patient.HEC_PatientID;

                            var allInsuranceToBrokerContract_ParticipatingPatient = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(Connection, Transaction, InsuranceToBrokerContract_ParticipatingPatientQuery).ToList();
                            var latest_participation_date = allInsuranceToBrokerContract_ParticipatingPatient.OrderByDescending(m => m.ValidFrom).FirstOrDefault();

                            patientModel2.participation_consent_from = latest_participation_date.ValidFrom;
                            patientModel2.participation_consent_to = latest_participation_date.ValidThrough;
                            patientModel2.has_participation_consent = true;

                            Add_New_Patient.Import_Patients_to_ElasticDB(patientModel2, securityTicket.TenantID.ToString());
                        }
                    }
                }
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
        }

    }
}
