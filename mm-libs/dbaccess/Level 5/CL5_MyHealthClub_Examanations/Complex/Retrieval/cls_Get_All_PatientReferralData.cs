/* 
 * Generated on 3/16/2015 15:36:13
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
using CL5_MyHealthClub_Examanations.Atomic.Retrieval;
using CL3_Offices.Atomic.Retrieval;
using CL1_HEC_ACT;
using CL1_HEC;
using CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval;

namespace CL5_MyHealthClub_Examinations.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_PatientReferralData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_PatientReferralData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EX_GAPRD_1154 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_GAPRD_1154 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5EX_GAPRD_1154();
            returnValue.Result = new L5EX_GAPRD_1154();
            //top medical pracices treba menjati nakon promene u bazi
            List<L5OU_GRPBD_1305_top_medical_practice_types> top_medical_practice_typesList = new List<L5OU_GRPBD_1305_top_medical_practice_types>();
            List<L5OU_GRPBD_1305_medical_practice_types> medical_practice_typesList = new List<L5OU_GRPBD_1305_medical_practice_types>();

            returnValue.Result.top_diagnoses = new List<L5OU_GRPBD_1305_top_diagnoses>().ToArray();
            returnValue.Result.doctors = new List<L5OU_GRPBD_1305_doctors>().ToArray();
            returnValue.Result.hospitals = new List<L5OU_GRPBD_1305_hospitals>().ToArray();
            var Hospitals = new List<L5OU_GRPBD_1305_hospitals>();
            var hospitals = cls_Get_All_Hospitals_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            foreach (var hospital in hospitals)
            {
                L5OU_GRPBD_1305_hospitals hosp = new L5OU_GRPBD_1305_hospitals();
                hosp.HospitalID = hospital.HEC_MedicalPractiseID;
                hosp.HospitalName = hospital.OrganizationalUnit_Name.Contents[0].Content;
                Hospitals.Add(hosp);
            }
            returnValue.Result.hospitals = Hospitals.ToArray();
            #region Top medical practice types 

            var HEC_ACT_PerformedAction_DoctorsQuery = new ORM_HEC_ACT_PerformedAction_Doctor.Query();
            HEC_ACT_PerformedAction_DoctorsQuery.IsDeleted = false;
            HEC_ACT_PerformedAction_DoctorsQuery.Tenant_RefID = securityTicket.TenantID;
            HEC_ACT_PerformedAction_DoctorsQuery.HEC_ACT_PerformedAction_RefID = Parameter.ExaminationID;

            Guid DoctorID = ORM_HEC_ACT_PerformedAction_Doctor.Query.Search(Connection, Transaction, HEC_ACT_PerformedAction_DoctorsQuery).Single().HEC_ACT_PerformedAction_DoctorID;

            var TopMedicalPractices = cls_Get_Top_MedicalPracticeTypes.Invoke(Connection, Transaction, new P_L5EX_GTMPT_1129 { DoctorID = DoctorID },securityTicket).Result.ToList();

            foreach (var item in TopMedicalPractices)
            {
                L5OU_GRPBD_1305_top_medical_practice_types top_mpt = new L5OU_GRPBD_1305_top_medical_practice_types();
                top_mpt.id = item.id.ToString();
                top_mpt.medical_pracitce_id = item.HEC_MedicalPractiseID.ToString();
                top_mpt.name = item.MedicalPracticeType_Name.Contents[0].Content;
                top_mpt.number_of_occurances = item.NumberOfOccurences.ToString();
                top_medical_practice_typesList.Add(top_mpt);
            }

            returnValue.Result.top_medical_practice_types = top_medical_practice_typesList.ToArray();
            #endregion

            #region All medical practice types that are not in the top 5 category

            var all_medical_practice_types = cls_Get_MedicalPracticeTypes_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            foreach (var item in all_medical_practice_types)
            {
                L5OU_GRPBD_1305_medical_practice_types practiceType = new L5OU_GRPBD_1305_medical_practice_types();
                practiceType.id = item.HEC_MedicalPractice_TypeID.ToString();
                practiceType.name = item.MedicalPracticeType_Name.Contents[0].Content;
                medical_practice_typesList.Add(practiceType);
            }

            returnValue.Result.medical_practice_types = medical_practice_typesList.ToArray();

            ORM_HEC_ACT_PerformedAction_Referral examinationReferral= ORM_HEC_ACT_PerformedAction_Referral.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_Referral.Query()
            {
                Tenant_RefID=securityTicket.TenantID,
                IsDeleted=false,
                HEC_ACT_PerformedAction_RefID=Parameter.ExaminationID
            }).SingleOrDefault();
            returnValue.Result.referralSaved = false;
            if (examinationReferral != null)
            {
                returnValue.Result.referralSaved = true;
                returnValue.Result.selectedDoctor = Guid.Empty;
                returnValue.Result.comment = examinationReferral.ReferralComment;
                var doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    BusinessParticipant_RefID = examinationReferral.ReferralTo_BusinessParticipant_RefID
                }).SingleOrDefault();
                if (doctor != null)
                {
                    returnValue.Result.selectedDoctor = doctor.HEC_DoctorID;
                    P_L5DO_GDfMPTID_0848 doctorsParameter = new P_L5DO_GDfMPTID_0848();
                    doctorsParameter.MedicalPracticeTypeID = examinationReferral.ReferralTo_MedicalPracticeType_RefID;
                    var doctors=cls_Get_Doctors_for_MedicalPracticeTypeID.Invoke(Connection, Transaction,doctorsParameter, securityTicket).Result;
                    returnValue.Result.doctors = new List<L5OU_GRPBD_1305_doctors>().ToArray();
                    var Doctors=new List<L5OU_GRPBD_1305_doctors>();
                    foreach (var doc in doctors)
                    {
                        L5OU_GRPBD_1305_doctors doct = new L5OU_GRPBD_1305_doctors();
                        doct.doctor = doc.doctor;
                        doct.doctor_id = doc.doctor_id;
                        doct.HEC_MedicalPractiseID = doc.HEC_MedicalPractiseID;
                        Doctors.Add(doct);
                    }
                    returnValue.Result.doctors = Doctors.ToArray();
                }
                returnValue.Result.selectedPracticeTypeID = examinationReferral.ReferralTo_MedicalPracticeType_RefID;

                returnValue.Result.selectedHospitalID = examinationReferral.ReferralTo_MedicalPractice_RefID;

                returnValue.Result.selectedProcedureID = Guid.Empty;
                var procedureReferral = ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure.Query.Search(Connection,Transaction,new ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure.Query(){
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Action_Referral_RefID=examinationReferral.HEC_ACT_PerformedAction_ReferralID
                }).SingleOrDefault();

                if (procedureReferral != null)
                    returnValue.Result.selectedProcedureID = procedureReferral.PotentialTreatment_RefID;
            }

            #endregion

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EX_GAPRD_1154 Invoke(string ConnectionString,P_L5EX_GAPRD_1154 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EX_GAPRD_1154 Invoke(DbConnection Connection,P_L5EX_GAPRD_1154 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EX_GAPRD_1154 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_GAPRD_1154 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EX_GAPRD_1154 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_GAPRD_1154 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EX_GAPRD_1154 functionReturn = new FR_L5EX_GAPRD_1154();
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

				throw new Exception("Exception occured in method cls_Get_All_PatientReferralData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EX_GAPRD_1154 : FR_Base
	{
		public L5EX_GAPRD_1154 Result	{ get; set; }

		public FR_L5EX_GAPRD_1154() : base() {}

		public FR_L5EX_GAPRD_1154(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EX_GAPRD_1154 for attribute P_L5EX_GAPRD_1154
		[DataContract]
		public class P_L5EX_GAPRD_1154 
		{
			//Standard type parameters
			[DataMember]
			public Guid ExaminationID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L5EX_GAPRD_1154 for attribute L5EX_GAPRD_1154
		[DataContract]
		public class L5EX_GAPRD_1154 
		{
			[DataMember]
			public L5OU_GRPBD_1305_top_medical_practice_types[] top_medical_practice_types { get; set; }
			[DataMember]
			public L5OU_GRPBD_1305_top_diagnoses[] top_diagnoses { get; set; }
			[DataMember]
			public L5OU_GRPBD_1305_medical_practice_types[] medical_practice_types { get; set; }
			[DataMember]
			public L5OU_GRPBD_1305_hospitals[] hospitals { get; set; }
			[DataMember]
			public L5OU_GRPBD_1305_doctors[] doctors { get; set; }
			[DataMember]
			public L5OU_GRPBD_1305_procedures[] procedures { get; set; }

			//Standard type parameters
			[DataMember]
			public Boolean referralSaved { get; set; } 
			[DataMember]
			public Guid selectedPracticeTypeID { get; set; } 
			[DataMember]
			public Guid selectedHospitalID { get; set; } 
			[DataMember]
			public Guid selectedProcedureID { get; set; } 
			[DataMember]
			public Guid selectedDoctor { get; set; } 
			[DataMember]
			public String comment { get; set; } 

		}
		#endregion
		#region SClass L5OU_GRPBD_1305_top_medical_practice_types for attribute top_medical_practice_types
		[DataContract]
		public class L5OU_GRPBD_1305_top_medical_practice_types 
		{
			//Standard type parameters
			[DataMember]
			public String id { get; set; } 
			[DataMember]
			public String medical_pracitce_id { get; set; } 
			[DataMember]
			public String name { get; set; } 
			[DataMember]
			public String number_of_occurances { get; set; } 

		}
		#endregion
		#region SClass L5OU_GRPBD_1305_top_diagnoses for attribute top_diagnoses
		[DataContract]
		public class L5OU_GRPBD_1305_top_diagnoses 
		{
			//Standard type parameters
			[DataMember]
			public String id { get; set; } 
			[DataMember]
			public String code { get; set; } 
			[DataMember]
			public String name { get; set; } 
			[DataMember]
			public String number_of_occurances { get; set; } 

		}
		#endregion
		#region SClass L5OU_GRPBD_1305_medical_practice_types for attribute medical_practice_types
		[DataContract]
		public class L5OU_GRPBD_1305_medical_practice_types 
		{
			//Standard type parameters
			[DataMember]
			public String id { get; set; } 
			[DataMember]
			public String name { get; set; } 

		}
		#endregion
		#region SClass L5OU_GRPBD_1305_hospitals for attribute hospitals
		[DataContract]
		public class L5OU_GRPBD_1305_hospitals 
		{
			//Standard type parameters
			[DataMember]
			public Guid HospitalID { get; set; } 
			[DataMember]
			public String HospitalName { get; set; } 

		}
		#endregion
		#region SClass L5OU_GRPBD_1305_doctors for attribute doctors
		[DataContract]
		public class L5OU_GRPBD_1305_doctors 
		{
			//Standard type parameters
			[DataMember]
			public String doctor { get; set; } 
			[DataMember]
			public Guid doctor_id { get; set; } 
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 

		}
		#endregion
		#region SClass L5OU_GRPBD_1305_procedures for attribute procedures
		[DataContract]
		public class L5OU_GRPBD_1305_procedures 
		{
			//Standard type parameters
			[DataMember]
			public String id { get; set; } 
			[DataMember]
			public String name { get; set; } 
			[DataMember]
			public String icd_10 { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EX_GAPRD_1154 cls_Get_All_PatientReferralData(,P_L5EX_GAPRD_1154 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EX_GAPRD_1154 invocationResult = cls_Get_All_PatientReferralData.Invoke(connectionString,P_L5EX_GAPRD_1154 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Examinations.Complex.Retrieval.P_L5EX_GAPRD_1154();
parameter.ExaminationID = ...;
parameter.PatientID = ...;

*/
