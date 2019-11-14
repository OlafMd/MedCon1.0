/* 
 * Generated on 11/04/16 11:40:40
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
using CL1_HEC;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_HEC_CRT;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using CL1_CMN_CTR;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using CL1_HEC_HIS;
using MMDocConnectElasticSearchMethods.HIP.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectUtils;
using MMDocConnectElasticSearchMethods;

namespace MMDocConnectDBMethods.Patient.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Patient.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Patient
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_PA_SP_1013 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            var patientDetailList = new List<PatientDetailViewModel>();
            var elasticPatientDetailModel = new PatientDetailViewModel();
            List<Guid> consentsForDelete = new List<Guid>();
            var patientModel = new Patient_Model();

            ORM_HEC_HIS_HealthInsurance_Company hip = null;
            if (Parameter.is_privately_insured)
            {
                hip = ORM_HEC_HIS_HealthInsurance_Company.Query.Search(Connection, Transaction, new ORM_HEC_HIS_HealthInsurance_Company.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    HealthInsurance_IKNumber = "000000000"
                }).Single();

                Parameter.insurance_id = "privat";
                Parameter.insurance_status = "privat";
            }
            else
            {
                hip = ORM_HEC_HIS_HealthInsurance_Company.Query.Search(Connection, Transaction, new ORM_HEC_HIS_HealthInsurance_Company.Query()
                {
                    CMN_BPT_BusinessParticipant_RefID = Parameter.health_insurance_provider_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();
            }

            var HIP = Parameter.is_privately_insured ? "privat" : ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query() { IsDeleted = false, Tenant_RefID = securityTicket.TenantID, CMN_BPT_BusinessParticipantID = Parameter.health_insurance_provider_id }).Single().DisplayName;

            if (Parameter.id == Guid.Empty)
            {
                #region Save
                ORM_HEC_Patient patients = new ORM_HEC_Patient();
                patients.HEC_PatientID = Guid.NewGuid();
                patients.Tenant_RefID = securityTicket.TenantID;
                patients.Creation_Timestamp = DateTime.Now;
                patients.Modification_Timestamp = DateTime.Now;
                patients.CMN_BPT_BusinessParticipant_RefID = Guid.NewGuid();
                patients.Save(Connection, Transaction);

                ORM_CMN_BPT_BusinessParticipant businesParticipantPatient = new ORM_CMN_BPT_BusinessParticipant();
                businesParticipantPatient.CMN_BPT_BusinessParticipantID = patients.CMN_BPT_BusinessParticipant_RefID;
                businesParticipantPatient.Tenant_RefID = securityTicket.TenantID;
                businesParticipantPatient.Creation_Timestamp = DateTime.Now;
                businesParticipantPatient.Modification_Timestamp = DateTime.Now;
                businesParticipantPatient.IsNaturalPerson = true;
                businesParticipantPatient.IfNaturalPerson_CMN_PER_PersonInfo_RefID = Guid.NewGuid();
                businesParticipantPatient.Save(Connection, Transaction);

                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.CMN_PER_PersonInfoID = businesParticipantPatient.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                personInfo.Tenant_RefID = securityTicket.TenantID;
                personInfo.Creation_Timestamp = DateTime.Now;
                personInfo.Modification_Timestamp = DateTime.Now;
                personInfo.FirstName = Parameter.first_name;//
                personInfo.LastName = Parameter.last_name;//
                personInfo.BirthDate = Parameter.bithday;//

                personInfo.Gender = Parameter.sex;//
                personInfo.Save(Connection, Transaction);

                ORM_HEC_Patient_MedicalPractice medical_practice_to_patient = new ORM_HEC_Patient_MedicalPractice();
                medical_practice_to_patient.HEC_Patient_MedicalPracticeID = Guid.NewGuid();
                medical_practice_to_patient.HEC_Patient_RefID = patients.HEC_PatientID;
                medical_practice_to_patient.HEC_MedicalPractices_RefID = Parameter.medical_practice_id;//
                medical_practice_to_patient.Tenant_RefID = securityTicket.TenantID;
                medical_practice_to_patient.Creation_Timestamp = DateTime.Now;
                medical_practice_to_patient.Save(Connection, Transaction);

                ORM_HEC_Patient_HealthInsurance patientHealthInsurance = new ORM_HEC_Patient_HealthInsurance();
                patientHealthInsurance.HEC_Patient_HealthInsurancesID = Guid.NewGuid();
                patientHealthInsurance.Patient_RefID = patients.HEC_PatientID;
                patientHealthInsurance.HealthInsurance_Number = Parameter.insurance_id;//
                patientHealthInsurance.Tenant_RefID = securityTicket.TenantID;
                patientHealthInsurance.InsuranceStateCode = Parameter.insurance_status;//
                patientHealthInsurance.HIS_HealthInsurance_Company_RefID = hip.HEC_HealthInsurance_CompanyID;
                patientHealthInsurance.Save(Connection, Transaction);

                var HEC_CRT_InsuranceToBrokerContractID = Guid.Empty;
                var HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = Guid.Empty;
                if (Parameter.hasParticipationConsent)
                {

                    var InsuranceToBrokerContractQuery = new ORM_HEC_CRT_InsuranceToBrokerContract.Query();
                    InsuranceToBrokerContractQuery.Tenant_RefID = securityTicket.TenantID;
                    InsuranceToBrokerContractQuery.IsDeleted = false;
                    InsuranceToBrokerContractQuery.Ext_CMN_CTR_Contract_RefID = Parameter.contract_id;

                    ORM_HEC_CRT_InsuranceToBrokerContract InsuranceToBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, InsuranceToBrokerContractQuery).Single();

                    ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient InsuranceToBrokerContract_ParticipatingPatient = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient();
                    InsuranceToBrokerContract_ParticipatingPatient.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = Guid.NewGuid();
                    InsuranceToBrokerContract_ParticipatingPatient.InsuranceToBrokerContract_RefID = InsuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                    InsuranceToBrokerContract_ParticipatingPatient.Creation_Timestamp = DateTime.Now;
                    InsuranceToBrokerContract_ParticipatingPatient.Modification_Timestamp = DateTime.Now;
                    InsuranceToBrokerContract_ParticipatingPatient.Tenant_RefID = securityTicket.TenantID;
                    InsuranceToBrokerContract_ParticipatingPatient.ValidFrom = Parameter.issue_date_from;
                    InsuranceToBrokerContract_ParticipatingPatient.ValidThrough = Parameter.issue_date_to;
                    InsuranceToBrokerContract_ParticipatingPatient.Patient_RefID = patients.HEC_PatientID;
                    InsuranceToBrokerContract_ParticipatingPatient.Save(Connection, Transaction);

                    HEC_CRT_InsuranceToBrokerContractID = InsuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                    HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = InsuranceToBrokerContract_ParticipatingPatient.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID;
                }


                var practiceDetails = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = Parameter.medical_practice_id }, securityTicket).Result.FirstOrDefault();

                patientModel.birthday = Parameter.bithday;
                patientModel.birthday_string = Parameter.bithday.ToString("dd.MM.yyyy");
                patientModel.name = Parameter.last_name + ", " + Parameter.first_name;
                patientModel.health_insurance_provider = HIP;
                patientModel.name_with_birthdate = Parameter.first_name + " " + Parameter.last_name + " (" + Parameter.bithday.ToString("dd.MM.yyyy") + ")";
                patientModel.id = patients.HEC_PatientID.ToString();
                patientModel.insurance_id = Parameter.insurance_id;
                patientModel.insurance_status = Parameter.insurance_status;

                if (Parameter.sex == 0)
                    patientModel.sex = "M";
                else if (Parameter.sex == 1)
                    patientModel.sex = "W";
                else if (Parameter.sex == 2)
                    patientModel.sex = "o.A.";

                if (Parameter.hasParticipationConsent)
                {
                    patientModel.participation_consent_from = Parameter.issue_date_from;
                    patientModel.participation_consent_to = Parameter.issue_date_to;
                    patientModel.has_participation_consent = true;
                }
                patientModel.last_first_op_doctor_name = "-";
                patientModel.last_first_ac_doctor_name = "-";
                patientModel.op_doctor_lanr = "-";
                patientModel.ac_doctor_lanr = "-";
                patientModel.practice_id = practiceDetails.practiceID.ToString();

                patientModel.practice = "";
                patientModel.practice_bsnr = "";
                patientModel.op_doctor_id = "-";
                patientModel.ac_doctor_id = "-";
                patientModel.ac_practice_id = "-";
                patientModel.ac_practice = "";
                patientModel.ac_practice_bsnr = "-";


                if (Parameter.hasParticipationConsent)
                {
                    elasticPatientDetailModel.id = HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID.ToString();
                    elasticPatientDetailModel.patient_id = patients.HEC_PatientID.ToString();
                    elasticPatientDetailModel.practice_id = Parameter.medical_practice_id.ToString();
                    elasticPatientDetailModel.date = Parameter.issue_date_from;
                    elasticPatientDetailModel.date_string = Parameter.issue_date_from.ToString("dd.MM.");
                    elasticPatientDetailModel.detail_type = "participation";

                    var insuranceBrokerContractQuery = new ORM_HEC_CRT_InsuranceToBrokerContract.Query();
                    insuranceBrokerContractQuery.IsDeleted = false;
                    insuranceBrokerContractQuery.Tenant_RefID = securityTicket.TenantID;
                    insuranceBrokerContractQuery.HEC_CRT_InsuranceToBrokerContractID = HEC_CRT_InsuranceToBrokerContractID;
                    var insuranceBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, insuranceBrokerContractQuery).Single();

                    var contractQuery = new ORM_CMN_CTR_Contract.Query();
                    contractQuery.IsDeleted = false;
                    contractQuery.Tenant_RefID = securityTicket.TenantID;
                    contractQuery.CMN_CTR_ContractID = insuranceBrokerContract.Ext_CMN_CTR_Contract_RefID;
                    var contract = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, contractQuery).Single();

                    var contractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        Contract_RefID = Parameter.contract_id
                    });

                    var validUntil = contractParameters.Where(t => t.ParameterName == "Duration of participation consent – Month").Single();

                    var aftercareDays = contractParameters.Where(t => t.ParameterName == "Number of days between surgery and aftercare - Days").Single();


                    var validUntilDate = validUntil == null || validUntil.IfNumericValue_Value == double.MaxValue ? DateTime.MaxValue : Parameter.issue_date_from.AddMonths(Convert.ToInt32(validUntil.IfNumericValue_Value));

                    if (aftercareDays != null && aftercareDays.IfNumericValue_Value != double.MaxValue)
                    {
                        validUntilDate = validUntilDate.AddDays(-Convert.ToInt32(aftercareDays.IfNumericValue_Value));
                    }
                    var validUntilStr = validUntilDate == DateTime.MaxValue ? "∞" : validUntilDate.ToString("dd.MM.yyyy");

                    elasticPatientDetailModel.diagnose_or_medication = Properties.Resources.participarionConsent + " " + contract.ContractName + ", " + Properties.Resources.goodUntil + " " + validUntilStr;
                    elasticPatientDetailModel.case_id = contract.CMN_CTR_ContractID.ToString();

                    patientDetailList.Add(elasticPatientDetailModel);
                }
                patientModel.external_id = Parameter.external_id;
                Add_New_Patient.Import_Patients_to_ElasticDB(new List<Patient_Model>() { patientModel }, securityTicket.TenantID.ToString());

                if (Parameter.hasParticipationConsent)
                    Add_New_Patient.ImportPatientDetailsToElastic(patientDetailList, securityTicket.TenantID.ToString());


                returnValue.Result = patients.HEC_PatientID;
                #endregion
            }
            else
            {
                returnValue.Result = Parameter.id;

                #region Delete
                if (Parameter.isDeleted)
                {

                }
                #endregion

                #region Edit
                else
                {
                    var patientsQuery = new ORM_HEC_Patient.Query();
                    patientsQuery.IsDeleted = false;
                    patientsQuery.Tenant_RefID = securityTicket.TenantID;
                    patientsQuery.HEC_PatientID = Parameter.id;

                    var patient = ORM_HEC_Patient.Query.Search(Connection, Transaction, patientsQuery).Single();

                    var businessParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                    businessParticipantQuery.IsDeleted = false;
                    businessParticipantQuery.Tenant_RefID = securityTicket.TenantID;
                    businessParticipantQuery.CMN_BPT_BusinessParticipantID = patient.CMN_BPT_BusinessParticipant_RefID;

                    var businessParticipan = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQuery).Single();

                    var personInfoQuery = new ORM_CMN_PER_PersonInfo.Query();
                    personInfoQuery.CMN_PER_PersonInfoID = businessParticipan.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                    personInfoQuery.Tenant_RefID = securityTicket.TenantID;
                    personInfoQuery.IsDeleted = false;

                    var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, personInfoQuery).Single();
                    personInfo.FirstName = Parameter.first_name;//
                    personInfo.LastName = Parameter.last_name;//
                    personInfo.BirthDate = Parameter.bithday;//
                    personInfo.Gender = Parameter.sex;//
                    personInfo.Save(Connection, Transaction);

                    var HEC_CRT_InsuranceToBrokerContractID = Guid.Empty;
                    var HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = Guid.Empty;
                    var oldPatientHealthInsuranceQuery = new ORM_HEC_Patient_HealthInsurance.Query();
                    oldPatientHealthInsuranceQuery.IsDeleted = false;
                    oldPatientHealthInsuranceQuery.Tenant_RefID = securityTicket.TenantID;
                    oldPatientHealthInsuranceQuery.Patient_RefID = patient.HEC_PatientID;

                    var oldPatientHealthInsurance = ORM_HEC_Patient_HealthInsurance.Query.Search(Connection, Transaction, oldPatientHealthInsuranceQuery).Single();
                    if (Parameter.hip_changed)
                    {
                        var previousPatientsHipIkNumber = ORM_HEC_HIS_HealthInsurance_Company.Query.Search(Connection, Transaction, new ORM_HEC_HIS_HealthInsurance_Company.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            HEC_HealthInsurance_CompanyID = oldPatientHealthInsurance.HIS_HealthInsurance_Company_RefID
                        }).Single().HealthInsurance_IKNumber;
                        oldPatientHealthInsurance.IsDeleted = true;
                        oldPatientHealthInsurance.Save(Connection, Transaction);

                        ORM_HEC_Patient_HealthInsurance patientHealthInsurance = new ORM_HEC_Patient_HealthInsurance();
                        patientHealthInsurance.Patient_RefID = Parameter.id;
                        patientHealthInsurance.HealthInsurance_Number = Parameter.insurance_id;
                        patientHealthInsurance.Tenant_RefID = securityTicket.TenantID;
                        patientHealthInsurance.InsuranceStateCode = Parameter.insurance_status;
                        patientHealthInsurance.HIS_HealthInsurance_Company_RefID = hip.HEC_HealthInsurance_CompanyID;
                        patientHealthInsurance.Save(Connection, Transaction);

                        var shouldInvalidateConsents = Parameter.is_privately_insured;
                        if (!Parameter.is_privately_insured)
                        {
                            var previousHipContracts = cls_Get_Contracts_Where_Hip_Participating_for_HipID.Invoke(Connection, Transaction, new P_PA_GCwHipPfHipID_0954() { HipIkNumber = previousPatientsHipIkNumber }, securityTicket).Result;
                            var hipContracts = cls_Get_Contracts_Where_Hip_Participating_for_HipID.Invoke(Connection, Transaction, new P_PA_GCwHipPfHipID_0954() { HipIkNumber = hip.HealthInsurance_IKNumber }, securityTicket).Result;
                            if (previousHipContracts.Any() && !hipContracts.Any())
                                shouldInvalidateConsents = true;
                            else if (!previousHipContracts.Any() && hipContracts.Any())
                                shouldInvalidateConsents = true;
                            else if (previousHipContracts.Any() && hipContracts.Any())
                            {
                                shouldInvalidateConsents = !previousHipContracts.Any(t => hipContracts.Any(h => h.ContractID == t.ContractID));
                            }
                        }

                        if (shouldInvalidateConsents)
                        {
                            var patientConsents = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                            {
                                Patient_RefID = Parameter.id,
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false
                            });

                            foreach (var consent in patientConsents)
                            {
                                consent.IsDeleted = true;
                                consent.Modification_Timestamp = DateTime.Now;

                                consent.Save(Connection, Transaction);
                                consentsForDelete.Add(consent.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID);
                            }

                            #region Elastic
                            var patientDetailsConsents = Retrieve_Patients.GetPatientDetailsListForDetailTypeAndPatientID("participation", Parameter.id.ToString(), securityTicket);
                            if (patientDetailsConsents.Any())
                            {
                                foreach (var consent_elastic in patientDetailsConsents)
                                {
                                    consent_elastic.status = "LABEL_PARTICIPATION_NOT_ACTIVE";
                                }

                                Add_New_Patient.ImportPatientDetailsToElastic(patientDetailsConsents.ToList(), securityTicket.TenantID.ToString());
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        oldPatientHealthInsurance.HealthInsurance_Number = Parameter.insurance_id;
                        oldPatientHealthInsurance.InsuranceStateCode = Parameter.insurance_status;
                        oldPatientHealthInsurance.Save(Connection, Transaction);
                    }

                    if (Parameter.hasParticipationConsent && !Parameter.is_privately_insured)
                    {
                        var InsuranceToBrokerContractQuery = new ORM_HEC_CRT_InsuranceToBrokerContract.Query();
                        InsuranceToBrokerContractQuery.Ext_CMN_CTR_Contract_RefID = Parameter.contract_id;
                        InsuranceToBrokerContractQuery.Tenant_RefID = securityTicket.TenantID;
                        InsuranceToBrokerContractQuery.IsDeleted = false;

                        ORM_HEC_CRT_InsuranceToBrokerContract InsuranceToBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, InsuranceToBrokerContractQuery).Single();

                        if (Parameter.participation_id != Guid.Empty && !Parameter.hip_changed)
                        {
                            var queryParticipant = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query();
                            queryParticipant.IsDeleted = false;
                            queryParticipant.Tenant_RefID = securityTicket.TenantID;
                            queryParticipant.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = Parameter.participation_id;

                            var InsuranceToBrokerContract_ParticipatingPatient = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(Connection, Transaction, queryParticipant).Single();
                            InsuranceToBrokerContract_ParticipatingPatient.InsuranceToBrokerContract_RefID = InsuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                            InsuranceToBrokerContract_ParticipatingPatient.Modification_Timestamp = DateTime.Now;
                            InsuranceToBrokerContract_ParticipatingPatient.ValidFrom = Parameter.issue_date_from;
                            InsuranceToBrokerContract_ParticipatingPatient.ValidFrom = Parameter.issue_date_from;
                            InsuranceToBrokerContract_ParticipatingPatient.ValidThrough = Parameter.issue_date_to;
                            InsuranceToBrokerContract_ParticipatingPatient.Save(Connection, Transaction);

                            HEC_CRT_InsuranceToBrokerContractID = InsuranceToBrokerContract_ParticipatingPatient.InsuranceToBrokerContract_RefID;
                            HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = InsuranceToBrokerContract_ParticipatingPatient.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID;
                        }
                        else
                        {
                            ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient InsuranceToBrokerContract_ParticipatingPatient = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient();
                            InsuranceToBrokerContract_ParticipatingPatient.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = Guid.NewGuid();
                            InsuranceToBrokerContract_ParticipatingPatient.InsuranceToBrokerContract_RefID = InsuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                            InsuranceToBrokerContract_ParticipatingPatient.Creation_Timestamp = DateTime.Now;
                            InsuranceToBrokerContract_ParticipatingPatient.Modification_Timestamp = DateTime.Now;
                            InsuranceToBrokerContract_ParticipatingPatient.Tenant_RefID = securityTicket.TenantID;
                            InsuranceToBrokerContract_ParticipatingPatient.ValidFrom = Parameter.issue_date_from;
                            InsuranceToBrokerContract_ParticipatingPatient.ValidThrough = Parameter.issue_date_to;
                            InsuranceToBrokerContract_ParticipatingPatient.Patient_RefID = patient.HEC_PatientID;
                            InsuranceToBrokerContract_ParticipatingPatient.Save(Connection, Transaction);

                            HEC_CRT_InsuranceToBrokerContractID = InsuranceToBrokerContract_ParticipatingPatient.InsuranceToBrokerContract_RefID;
                            HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = InsuranceToBrokerContract_ParticipatingPatient.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID;
                        }
                    }

                    var practiceDetails = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = Parameter.medical_practice_id }, securityTicket).Result.FirstOrDefault();

                    var previous_case_details = cls_Get_Previous_Case_Data_for_PatientID.Invoke(Connection, Transaction, new P_CAS_GPCDfPID_1144() { PatientID = patient.HEC_PatientID }, securityTicket).Result;
                    var op_doc_details = previous_case_details != null ? cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = previous_case_details.treatment_doctor_id }, securityTicket).Result.FirstOrDefault() : null;
                    var ac_doc_details = previous_case_details != null ? cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = previous_case_details.aftercare_doctor_id }, securityTicket).Result.FirstOrDefault() : null;

                    patientModel.birthday = Parameter.bithday;
                    patientModel.birthday_string = Parameter.bithday.ToString("dd.MM.yyyy");
                    patientModel.name = Parameter.last_name + ", " + Parameter.first_name;
                    patientModel.health_insurance_provider = HIP;
                    patientModel.name_with_birthdate = Parameter.first_name + " " + Parameter.last_name + " (" + Parameter.bithday.ToString("dd.MM.yyyy") + ")";
                    patientModel.id = patient.HEC_PatientID.ToString();
                    patientModel.insurance_id = Parameter.insurance_id;
                    patientModel.insurance_status = Parameter.insurance_status;
                    patientModel.practice_id = Parameter.medical_practice_id.ToString();

                    patientModel.last_first_op_doctor_name = op_doc_details != null ? MMDocConnectDocApp.GenericUtils.GetDoctorName(op_doc_details) : "-";
                    patientModel.last_first_ac_doctor_name = ac_doc_details != null ? MMDocConnectDocApp.GenericUtils.GetDoctorName(ac_doc_details) : "-";
                    patientModel.op_doctor_lanr = op_doc_details != null ? op_doc_details.lanr : "-";
                    patientModel.ac_doctor_lanr = ac_doc_details != null ? ac_doc_details.lanr : "-";
                    patientModel.op_doctor_id = op_doc_details != null ? op_doc_details.practice_id.ToString() : "";
                    patientModel.practice = practiceDetails.practice_name;
                    patientModel.practice_bsnr = practiceDetails.practice_BSNR;
                    patientModel.op_doctor_id = op_doc_details != null ? op_doc_details.id.ToString() : "-";
                    patientModel.ac_doctor_id = ac_doc_details != null ? ac_doc_details.id.ToString() : "-";
                    patientModel.ac_practice_id = ac_doc_details != null ? ac_doc_details.practice_id.ToString() : "-";
                    patientModel.ac_practice = ac_doc_details != null ? ac_doc_details.practice : "";
                    patientModel.ac_practice_bsnr = ac_doc_details != null ? ac_doc_details.BSNR : "-";

                    if (Parameter.sex == 0)
                        patientModel.sex = "M";
                    else if (Parameter.sex == 1)
                        patientModel.sex = "W";
                    else if (Parameter.sex == 2)
                        patientModel.sex = "o.A.";

                    if (Parameter.hasParticipationConsent)
                    {
                        var InsuranceToBrokerContract_ParticipatingPatientQuery = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query();
                        InsuranceToBrokerContract_ParticipatingPatientQuery.IsDeleted = false;
                        InsuranceToBrokerContract_ParticipatingPatientQuery.Tenant_RefID = securityTicket.TenantID;
                        InsuranceToBrokerContract_ParticipatingPatientQuery.Patient_RefID = patient.HEC_PatientID;

                        var allInsuranceToBrokerContract_ParticipatingPatient = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(Connection, Transaction, InsuranceToBrokerContract_ParticipatingPatientQuery).ToList();
                        var latest_participation_date = allInsuranceToBrokerContract_ParticipatingPatient.OrderByDescending(m => m.ValidFrom).FirstOrDefault();

                        patientModel.participation_consent_from = latest_participation_date.ValidFrom;
                        patientModel.participation_consent_to = latest_participation_date.ValidThrough;
                        patientModel.has_participation_consent = true;

                        //////
                        elasticPatientDetailModel.id = HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID.ToString();
                        elasticPatientDetailModel.practice_id = Parameter.medical_practice_id.ToString(); ;
                        elasticPatientDetailModel.patient_id = patient.HEC_PatientID.ToString();
                        elasticPatientDetailModel.date = Parameter.issue_date_from;
                        elasticPatientDetailModel.date_string = Parameter.issue_date_from.ToString("dd.MM.");
                        elasticPatientDetailModel.detail_type = "participation";

                        var insuranceBrokerContractQuery = new ORM_HEC_CRT_InsuranceToBrokerContract.Query();
                        insuranceBrokerContractQuery.IsDeleted = false;
                        insuranceBrokerContractQuery.Tenant_RefID = securityTicket.TenantID;
                        insuranceBrokerContractQuery.HEC_CRT_InsuranceToBrokerContractID = HEC_CRT_InsuranceToBrokerContractID;
                        var insuranceBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, insuranceBrokerContractQuery).Single();

                        var contractQuery = new ORM_CMN_CTR_Contract.Query();
                        contractQuery.IsDeleted = false;
                        contractQuery.Tenant_RefID = securityTicket.TenantID;
                        contractQuery.CMN_CTR_ContractID = insuranceBrokerContract.Ext_CMN_CTR_Contract_RefID;
                        var contract = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, contractQuery).Single();

                        var contractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            Contract_RefID = Parameter.contract_id
                        });

                        var validUntil = contractParameters.Where(t => t.ParameterName == "Duration of participation consent – Month").Single();

                        var aftercareDays = contractParameters.Where(t => t.ParameterName == "Number of days between surgery and aftercare - Days").Single();


                        var validUntilDate = validUntil == null || validUntil.IfNumericValue_Value == double.MaxValue ? DateTime.MaxValue : Parameter.issue_date_from.AddMonths(Convert.ToInt32(validUntil.IfNumericValue_Value));

                        if (aftercareDays != null && aftercareDays.IfNumericValue_Value != double.MaxValue)
                        {
                            validUntilDate = validUntilDate.AddDays(-Convert.ToInt32(aftercareDays.IfNumericValue_Value));
                        }
                        var validUntilStr = validUntilDate == DateTime.MaxValue ? "∞" : validUntilDate.ToString("dd.MM.yyyy");

                        elasticPatientDetailModel.diagnose_or_medication = Properties.Resources.participarionConsent + " " + contract.ContractName + ", " + Properties.Resources.goodUntil + " " + validUntilStr;
                        elasticPatientDetailModel.case_id = contract.CMN_CTR_ContractID.ToString();

                        var todaysDate = DateTime.Now.Date;
                        int startCompare = Parameter.issue_date_from.CompareTo(todaysDate);
                        int endCompare = Parameter.issue_date_to == DateTime.MinValue ? 1 : Parameter.issue_date_to.CompareTo(todaysDate);

                        int conpareDContractStartAndParticipantDate = contract.ValidFrom.CompareTo(Parameter.issue_date_from);
                        int conpareDContractEndAndParticipantDate = contract.ValidThrough == DateTime.MinValue ? 1 : contract.ValidThrough.CompareTo(Parameter.issue_date_to);

                        if (conpareDContractStartAndParticipantDate <= 0 && conpareDContractEndAndParticipantDate >= 0)
                        {
                            if (startCompare <= 0 && endCompare >= 0)
                                elasticPatientDetailModel.status = "LABEL_PARTICIPATION_ACTIVE";
                            else
                                elasticPatientDetailModel.status = "LABEL_PARTICIPATION_NOT_ACTIVE";
                        }
                        else
                            elasticPatientDetailModel.status = "LABEL_PARTICIPATION_NOT_ACTIVE";

                        if (elasticPatientDetailModel.status == "LABEL_PARTICIPATION_ACTIVE")
                        {
                            PatientDetailViewModel patient_detail = Retrieve_Patients.Get_PatientDetailByParticipationConsentStatus(elasticPatientDetailModel.patient_id, "LABEL_PARTICIPATION_ACTIVE", securityTicket);

                            if (patient_detail != null && patient_detail.id != null && patient_detail.id != elasticPatientDetailModel.id)
                            {
                                if (patient_detail.date.CompareTo(elasticPatientDetailModel.date) > 0)
                                {
                                    patient_detail.status = "LABEL_PARTICIPATION_NOT_ACTIVE";
                                    patientDetailList.Add(patient_detail);
                                }
                                else
                                    elasticPatientDetailModel.status = "LABEL_PARTICIPATION_NOT_ACTIVE";
                            }
                        }

                        patientDetailList.Add(elasticPatientDetailModel);

                    }
                    patientModel.external_id = Parameter.external_id;

                    Add_New_Patient.Import_Patients_to_ElasticDB(new List<Patient_Model>() { patientModel }, securityTicket.TenantID.ToString());

                    if (Parameter.hasParticipationConsent)
                        Add_New_Patient.ImportPatientDetailsToElastic(patientDetailList, securityTicket.TenantID.ToString());
                }
                #endregion
            }


            if (!Parameter.is_privately_insured)
            {
                var last_used_hips = Get_HIPs.Get_LastUsed_HIPs(securityTicket.TenantID.ToString(), Parameter.medical_practice_id.ToString()).ToList();
                if (last_used_hips.Count != 0)
                {
                    var last_used = last_used_hips.Where(l => l.id == hip.HEC_HealthInsurance_CompanyID.ToString()).SingleOrDefault();
                    if (last_used != null)
                    {
                        last_used.date_of_use = DateTime.Now;
                    }
                    else
                    {
                        Practice_Doctor_Last_Used_Model hip_last_used_model = new Practice_Doctor_Last_Used_Model();
                        hip_last_used_model.id = hip.HEC_HealthInsurance_CompanyID.ToString();
                        hip_last_used_model.display_name = HIP;
                        hip_last_used_model.date_of_use = DateTime.Now;
                        hip_last_used_model.secondary_display_name = hip.HealthInsurance_IKNumber;

                        last_used_hips.Add(hip_last_used_model);
                    }
                }
                else
                {
                    Practice_Doctor_Last_Used_Model hip_last_used_model = new Practice_Doctor_Last_Used_Model();
                    hip_last_used_model.id = hip.HEC_HealthInsurance_CompanyID.ToString();
                    hip_last_used_model.display_name = HIP;
                    hip_last_used_model.date_of_use = DateTime.Now;
                    hip_last_used_model.secondary_display_name = hip.HealthInsurance_IKNumber;

                    last_used_hips.Add(hip_last_used_model);
                }

                Add_New_HIP.Import_Last_Used_HIPs_to_ElasticDB(last_used_hips, securityTicket.TenantID.ToString(), Parameter.medical_practice_id.ToString());

                last_used_hips = Get_HIPs.Get_LastUsed_HIPs(securityTicket.TenantID.ToString(), Parameter.medical_practice_id.ToString()).ToList();
                if (last_used_hips.Count > 3)
                {
                    var id_to_delete = last_used_hips.OrderBy(pd => pd.date_of_use).First().id;
                    Add_New_Practice_Last_Used.Delete_Practice_Last_Used(securityTicket.TenantID.ToString(), "last_used_hips_" + Parameter.medical_practice_id.ToString(), id_to_delete);
                }

            }


            var external_id_property = ORM_HEC_Patient_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_Patient_UniversalProperty.Query()
            {
                GlobalPropertyMatchingID = EPatientProperty.ExternalId.Value(),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (external_id_property == null)
            {
                external_id_property = new ORM_HEC_Patient_UniversalProperty();
                external_id_property.GlobalPropertyMatchingID = EPatientProperty.ExternalId.Value();
                external_id_property.IsValue_String = true;
                external_id_property.Modification_Timestamp = DateTime.Now;
                external_id_property.Tenant_RefID = securityTicket.TenantID;
                external_id_property.PropertyName = "External Id";

                external_id_property.Save(Connection, Transaction);
            }

            foreach (var consent in consentsForDelete)
            {
                Elastic_Utils.Delete_Item(securityTicket.TenantID.ToString(), "patient_details", consent);
            }

            var external_id_property_value = ORM_HEC_Patient_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_Patient_UniversalPropertyValue.Query()
            {
                HEC_Patient_RefID = returnValue.Result,
                HEC_Patient_UniversalProperty_RefID = external_id_property.HEC_Patient_UniversalPropertyID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (external_id_property_value == null)
            {
                external_id_property_value = new ORM_HEC_Patient_UniversalPropertyValue();
                external_id_property_value.HEC_Patient_RefID = returnValue.Result;
                external_id_property_value.HEC_Patient_UniversalProperty_RefID = external_id_property.HEC_Patient_UniversalPropertyID;
                external_id_property_value.Tenant_RefID = securityTicket.TenantID;
            }
            external_id_property_value.Value_String = Parameter.external_id;
            external_id_property_value.Modification_Timestamp = DateTime.Now;

            external_id_property_value.Save(Connection, Transaction);

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_PA_SP_1013 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_PA_SP_1013 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_PA_SP_1013 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_PA_SP_1013 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guid functionReturn = new FR_Guid();
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

                throw new Exception("Exception occured in method cls_Save_Patient", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_PA_SP_1013 for attribute P_PA_SP_1013
    [DataContract]
    public class P_PA_SP_1013
    {
        //Standard type parameters
        [DataMember]
        public Guid id { get; set; }
        [DataMember]
        public Guid participation_id { get; set; }
        [DataMember]
        public Guid medical_practice_id { get; set; }
        [DataMember]
        public String first_name { get; set; }
        [DataMember]
        public String last_name { get; set; }
        [DataMember]
        public DateTime bithday { get; set; }
        [DataMember]
        public int sex { get; set; }
        [DataMember]
        public Guid health_insurance_provider_id { get; set; }
        [DataMember]
        public String insurance_id { get; set; }
        [DataMember]
        public String insurance_status { get; set; }
        [DataMember]
        public String participation_consent { get; set; }
        [DataMember]
        public bool isDeleted { get; set; }
        [DataMember]
        public bool hasParticipationConsent { get; set; }
        [DataMember]
        public Guid contract_id { get; set; }
        [DataMember]
        public DateTime issue_date_from { get; set; }
        [DataMember]
        public DateTime issue_date_to { get; set; }
        [DataMember]
        public bool is_privately_insured { get; set; }
        [DataMember]
        public bool hip_changed { get; set; }
        [DataMember]
        public String external_id { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Patient(,P_PA_SP_1013 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Patient.Invoke(connectionString,P_PA_SP_1013 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Atomic.Manipulation.P_PA_SP_1013();
parameter.id = ...;
parameter.participation_id = ...;
parameter.medical_practice_id = ...;
parameter.first_name = ...;
parameter.last_name = ...;
parameter.bithday = ...;
parameter.sex = ...;
parameter.health_insurance_provider_id = ...;
parameter.insurance_id = ...;
parameter.insurance_status = ...;
parameter.participation_consent = ...;
parameter.isDeleted = ...;
parameter.hasParticipationConsent = ...;
parameter.contract_id = ...;
parameter.issue_date_from = ...;
parameter.issue_date_to = ...;
parameter.is_privately_insured = ...;
parameter.hip_changed = ...;
parameter.external_id = ...;

*/
