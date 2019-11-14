/* 
 * Generated on 16.01.2015 13:16:42
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
using pocdoc.Models.ERMClasses;
using CL5_MyHealthClub_EMR.Atomic.Retrieval;
using CL1_HEC_ACT;
using CL5_MyHealthClub_EMR.Model;

namespace CL5_MyHealthClub_EMR.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PatientEMRData_For_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientEMRData_For_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GPEfPID_1314 Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GPEfPID_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 

            string _dateTimeStringFormat = "yyyy-MM-ddTHH:mm:sszzz";

            var returnValue = new FR_L5ME_GPEfPID_1314()
            {
                Result = new L5ME_GPEfPID_1314()
            };

            var doctors = cls_Get_DoctorsBaseData_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            var baseData = cls_PatientInfos_for_PatientID.Invoke(Connection, Transaction, new P_L5ME_GPIfPID_1338() { patientID = Parameter.PatientID }, securityTicket).Result;

            var root = new StructuredEMRData()
            {
                BaseData = new PatientBaseData()
                {
                    DateOfBirth = baseData.BirthDate.ToString(_dateTimeStringFormat),
                    Email = baseData.PrimaryEmail,
                    FirstName = baseData.FirstName,
                    LastName = baseData.LastName,
                    PatientPicture = Guid.Empty.ToString(), //popraviti
                    PhoneNumber = baseData.Contacts.First().Content,
                    YearOfBirth = baseData.BirthDate.Year.ToString(),
                    PatientITL = baseData.HEC_PatientID.ToString(),
                    Gender = baseData.Gender.ToString()
                }
            };

            var performedActions = ORM_HEC_ACT_PerformedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Patient_RefID = Parameter.PatientID      
            }).ToArray();


          
            foreach (var performedAction in performedActions)
            {

                Examination examination = new Examination();
                examination.ITL = performedAction.HEC_ACT_PerformedActionID.ToString();
                examination.Date = performedAction.IfPerfomed_DateOfAction.ToString(_dateTimeStringFormat);

                #region vitals
                var vitals = cls_Get_Vitals_for_PerformedActionID.Invoke(Connection, Transaction, new P_L5ME_GPPfPAID_1524() { PerformedActionID = performedAction.HEC_ACT_PerformedActionID }, securityTicket).Result;
                foreach (var vital in vitals)
                    examination.PatientParameters.Add(new PatientParameter()
                    {
                         ConfirmedByDoctorITL = vital.ConfirmedBy_Doctor_RefID.ToString(),
                         ConfirmedOn = vital.DateOfValue.ToString(_dateTimeStringFormat),
                         DateOfEntry = vital.DateOfEntry.ToString(_dateTimeStringFormat),
                         IsVital = vital.IsVitalParameter,
                         ITL = vital.HEC_Patient_ParameterValueID.ToString(),
                         ParameterTypeITL = vital.HEC_Patient_ParameterID.ToString(),
                         Value = vital.StringValue
                    });
                #endregion

                #region doctors
                var action2docs = ORM_HEC_ACT_PerformedAction_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_Doctor.Query()
                {
                     Tenant_RefID = securityTicket.TenantID,
                     IsDeleted = false,
                     HEC_ACT_PerformedAction_RefID = performedAction.HEC_ACT_PerformedActionID
                }).ToArray();

                foreach(var a2d in action2docs)
                {
                    var doctor = doctors.FirstOrDefault(s => s.HEC_DoctorID == a2d.HEC_Doctor_RefID);
                    if (doctor != null)
                    {
                        var treatienDoctor = new Doctor()
                        {
                            ITL = doctor.HEC_DoctorID.ToString(),
                            FirstName = doctor.FirstName,
                            LastName = doctor.LastName,
                            Title = doctor.Title,
                            PracticeBPITL = doctor.CMN_BPT_BusinessParticipantID.ToString(),
                            PracticeName = string.Empty
                        };

                        //if (doctor.Address != null)
                        //    treatienDoctor.Address = new Address()
                        //    {
                        //        CityName = doctor.Address.City_Name,
                        //        StreetName = doctor.Address.Street_Name,
                        //        StreetNumber = doctor.Address.Street_Number
                        //    };

                        if (doctor.Practice != null)
                            treatienDoctor.PracticeName = doctor.Practice.PracticeName;

                        examination.TreatingDoctors.Add(treatienDoctor);
                    }
                }
                #endregion

                #region procedure
                var procedures = cls_Get_Procedure_for_PerformedActionID.Invoke(Connection, Transaction, new P_L5ME_GPfPAID_1953() { PerformedActionID = performedAction.HEC_ACT_PerformedActionID }, securityTicket).Result;
                foreach (var proc in procedures)
                    examination.Procedures.Add(new Procedure()
                    {
                         PotentialProcedure_RefITL = proc.HEC_TRE_PotentialProcedureID.ToString(),
                         ProcedureITL = proc.HEC_ACT_PerformedAction_ProcedureID.ToString(),
                         Name = proc.PotentialProcedure_Name.Contents.Count == 0 ? "" : proc.PotentialProcedure_Name.Contents.First().Content
                    });
                #endregion

                #region diagnosis

                var diagnoses = cls_Get_Diagnosis_for_PerformedActionID.Invoke(Connection, Transaction, new P_L5ME_GDfPAID_1919 { PerformedActionID = performedAction.HEC_ACT_PerformedActionID }, securityTicket).Result;
                foreach (var diag in diagnoses)
                {
                    Diagnosis diagnosis = new Diagnosis();
                    diagnosis.DiagnosedOn = diag.R_DiagnosedOnDate.ToString(_dateTimeStringFormat);
                    diagnosis.ScheduledExpiryDate = diag.R_ScheduledExpiryDate.ToString(_dateTimeStringFormat);
                    diagnosis.DiagnosisName = diag.PotentialDiagnosis_Name.Contents.Count == 0 ? "" : diag.PotentialDiagnosis_Name.Contents.First().Content;
                    diagnosis.ICD10Code = diag.ICD10_Code;
                    diagnosis.PatientDiagnosisITL = diag.HEC_Patient_DiagnosisID.ToString();
                    diagnosis.PotentialDiagnosisITL = diag.HEC_DIA_PotentialDiagnosisID.ToString();

                    #region observation
                    var observations = cls_Get_Observation_for_PerformedActionID.Invoke(
                        Connection, 
                        Transaction,
                        new P_L5ME_GOfPAID_1940()
                        {
                            PatientDiagnosisID = diag.HEC_Patient_DiagnosisID,
                            PerformedActionID = performedAction.HEC_ACT_PerformedActionID
                        }, 
                        securityTicket).Result;
                    foreach (var observation in observations)
                        diagnosis.Observations.Add(new Observation()
                        {
                            MadeObservationITL = observation.HEC_ACT_PerformedAction_ObservationID.ToString(),
                            //PotentialObservationITL = observation.HEC_PotentialObservationID.ToString(),
                            Text = observation.Comment
                        });

                    examination.Diagnoses.Add(diagnosis);
                    #endregion

                }
                #endregion


                #region mediaction

                var products = cls_Get_MedicationProduct_for_PerformedActionID.Invoke(Connection, Transaction, new P_L5ME_GMPfPAID_1133 { PerformedActionID = performedAction.HEC_ACT_PerformedActionID }, securityTicket).Result;
                var substances = cls_Get_MedicationSubstance_for_PerformedActionID.Invoke(Connection, Transaction, new P_L5ME_GMSfPAID_1329 { PerformedActionID = performedAction.HEC_ACT_PerformedActionID }, securityTicket).Result;
                foreach(var prod in products)
                    examination.Medications.Add(new Medication()
                    {
                        Dosage = prod.DosageText,
                        IsHealthCareProduct = true,
                        IsSubstance = false,
                        PatientMedicationITL = prod.HEC_Patient_MedicationID.ToString(),
                        Product_RefITL = prod.HEC_ProductID.ToString(),
                        Substance_RefITL = Guid.Empty.ToString(),
                        Diagnosis_RefITL = prod.Relevant_PatientDiagnosis_RefID.ToString(),
                        Name = prod.Product_Name.Contents.Count == 0 ? "" : prod.Product_Name.Contents.First().Content,
                        DurationInDays = prod.IntendedApplicationDuration_in_days.ToString(),
                        SpecialInstructions = prod.MedicationUpdateComment,
                        DosageForm = prod.DosageForm_Name.Contents.Count == 0 ? "" : prod.DosageForm_Name.Contents.First().Content,
                    });

                foreach (var subs in substances)
                    examination.Medications.Add(new Medication()
                    {
                        Dosage = subs.DosageText,
                        IsHealthCareProduct = false,
                        IsSubstance = true,
                        PatientMedicationITL = subs.HEC_Patient_MedicationID.ToString(),
                        Product_RefITL = Guid.Empty.ToString(),
                        Substance_RefITL = subs.HEC_SUB_SubstanceID.ToString(),
                        StrengthUnit = subs.ISOCode,
                        Strength = subs.IfSubstance_Strength,
                        IsActive = subs.IsActiveComponent,
                        Diagnosis_RefITL = subs.Relevant_PatientDiagnosis_RefID.ToString(),
                        Name = subs.GlobalPropertyMatchingID,
                        DurationInDays = subs.IntendedApplicationDuration_in_days.ToString(),
                        SpecialInstructions = subs.MedicationUpdateComment,
                        DosageForm = string.Empty
                    });

                #endregion

                #region referrals

                var refferals = cls_Get_Referrals_for_PerformedActionID.Invoke(Connection, Transaction, new P_L5ME_GRfPAID_1557() { PerformedActionID = performedAction.HEC_ACT_PerformedActionID }, securityTicket).Result;
                
                foreach(var r in refferals)
                {
                    Referral referral = new Referral()
                    {
                        Comment = r.ReferralComment,
                        PatientReferralITL = r.HEC_ACT_PerformedAction_ReferralID.ToString(),
                        PracticeType_RefITL = r.PracticeType != null ? r.PracticeType.HEC_MedicalPractice_TypeID.ToString() : Guid.Empty.ToString(),
                        PracticeTypeName = r.PracticeType != null ? (r.PracticeType.MedicalPracticeType_Name.Contents.Count > 0 ? r.PracticeType.MedicalPracticeType_Name.Contents.First().Content : "") : "",
                        SuggestedMedicalPracticeName = r.Practice != null ? (r.Practice.OrganizationalUnit_Name.Contents.Count > 0 ? r.Practice.OrganizationalUnit_Name.Contents.First().Content : "") : "",
                        SuggestedMedicalPractice_RefITL = r.Practice != null ? r.Practice.HEC_MedicalPractiseID.ToString() : Guid.Empty.ToString()       
                    };

                    foreach (var proc in r.Procedure)
                    {
                        referral.RequestedTreatmants.Add(new RequestedTreatmant()
                        {
                            ITL = proc.HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedureID.ToString(),
                            Name = proc.PotentialProcedure_Name.Contents.Count > 0 ?  proc.PotentialProcedure_Name.Contents.First().Content : "",
                            PotentialTreatmantITL = proc.HEC_TRE_PotentialProcedureID.ToString(),
                            ProposedDate = proc.ProposedDate.ToString(_dateTimeStringFormat),
                            ReferralITL = r.HEC_ACT_PerformedAction_ReferralID.ToString()
                        });
                    }

                    //var diagnosisUpdates = cls_Get_Referral_ReleventDiagnosis_Update.Invoke(Connection, Transaction, new P_L5_EMR_GRRDU_1254 { Referral_RefID = r.HEC_ACT_PerformedAction_ReferralID }, securityTicket).Result.SingleOrDefault();
                    //if (diagnosisUpdates != null)
                    //{
                    //    referral.RelevantPatientDiagnosis_RefITL = diagnosisUpdates.HEC_Patient_Diagnosis_RefID.ToString();
                    //    referral.RelevantPatientDiagnosisName = diagnosisUpdates.PotentialDiagnosis_Name.Contents.SingleOrDefault().Content;
                    //}
                    //examination.Referrals.Add(referral);
                }


                #endregion

                #region prescriptions

                var presctiptions = cls_Get_Prescriptions_for_PerformedActionID.Invoke(Connection, Transaction, new P_L5ME_GPfPAID_1216() { PerformedActionID = performedAction.HEC_ACT_PerformedActionID }, securityTicket).Result;
                foreach (var presctiption in presctiptions)
                {
                    PrescriptionHeader header = new PrescriptionHeader()
                    {
                        ExaminationITL = performedAction.HEC_ACT_PerformedActionID.ToString(),
                        PrescribedOn = presctiption.Prescription_Date.ToString(_dateTimeStringFormat),
                        PrescriptionITL = presctiption.HEC_Patient_Prescription_HeaderID.ToString(),
                    };

                    var doctor = doctors.First(s => s.HEC_DoctorID == presctiption.PrescribedBy_Doctor_RefID);
                    header.Doctor = new Doctor()
                    {
                        ITL = doctor.HEC_DoctorID.ToString(),
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        Title = doctor.Title,
                        PracticeBPITL = doctor.CMN_BPT_BusinessParticipantID.ToString(),
                        PracticeName = string.Empty
                    };

                    //if (doctor.Address != null)
                    //    header.Doctor.Address = new Address()
                    //    {
                    //        CityName = doctor.Address.City_Name,
                    //        StreetName = doctor.Address.Street_Name,
                    //        StreetNumber = doctor.Address.Street_Number
                    //    };

                    if (doctor.Practice != null)
                        header.Doctor.PracticeName = doctor.Practice.PracticeName;

                    foreach (var position in presctiption.Positions)
                        header.PrescriptionPositions.Add(new PrescriptionPosition()
                        {
                            PatientMedicationITL = position.InitializedFrom_PatientMedication_RefID.ToString(),
                            PrescriptionPositionITL = position.HEC_Patient_Prescription_PositionID.ToString()
                        });

                    examination.PrescriptionHeaders.Add(header);
                }


                #endregion

                root.Examinations.Add(examination);
            }

            returnValue.Result.BaseData = root;

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GPEfPID_1314 Invoke(string ConnectionString,P_L5ME_GPEfPID_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GPEfPID_1314 Invoke(DbConnection Connection,P_L5ME_GPEfPID_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GPEfPID_1314 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GPEfPID_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GPEfPID_1314 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GPEfPID_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GPEfPID_1314 functionReturn = new FR_L5ME_GPEfPID_1314();
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

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

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
					if (cleanupTransaction == true && Transaction!=null)
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

				throw new Exception("Exception occured in method cls_Get_PatientEMRData_For_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GPEfPID_1314 : FR_Base
	{
		public L5ME_GPEfPID_1314 Result	{ get; set; }

		public FR_L5ME_GPEfPID_1314() : base() {}

		public FR_L5ME_GPEfPID_1314(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GPEfPID_1314 for attribute P_L5ME_GPEfPID_1314
		[DataContract]
		public class P_L5ME_GPEfPID_1314 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L5ME_GPEfPID_1314 for attribute L5ME_GPEfPID_1314
		[DataContract]
		public class L5ME_GPEfPID_1314 
		{
			//Standard type parameters
			[DataMember]
			public StructuredEMRData BaseData { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_GPEfPID_1314 cls_Get_PatientEMRData_For_PatientID(,P_L5ME_GPEfPID_1314 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_GPEfPID_1314 invocationResult = cls_Get_PatientEMRData_For_PatientID.Invoke(connectionString,P_L5ME_GPEfPID_1314 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_EMR.Complex.Retrieval.P_L5ME_GPEfPID_1314();
parameter.PatientID = ...;

*/
