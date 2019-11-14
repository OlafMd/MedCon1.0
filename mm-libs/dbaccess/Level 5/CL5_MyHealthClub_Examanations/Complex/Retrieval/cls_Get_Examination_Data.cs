/* 
 * Generated on 2/16/2015 5:46:54 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL5_MyHealthClub_Examanations.Complex.Retrieval;
using CL5_MyHealthClub_EMR.Atomic.Retrieval;
using CL5_MyHealthClub_Examanations.Atomic.Retrieval;
using CL1_HEC_ACT;
using CL1_HEC;

namespace CL5_MyHealthClub_Examinations.Complex.Retrieval
{
	[Serializable]
	public class cls_Get_Examination_Data
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EX_GED_1024 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_GED_1024 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5EX_GED_1024();
            returnValue.Result = new L5EX_GED_1024();

            //observations
            var madeObservationsForPerformedActionID = ORM_HEC_ACT_PerformedAction_MadeObservation.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_MadeObservation.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                HEC_ACT_PerformedAction_RefID = Parameter.ExaminationID
            }).ToArray();

            List<L5EX_GED_1024_patient_observations> observaionList = new List<L5EX_GED_1024_patient_observations>();

            foreach (var item in madeObservationsForPerformedActionID)
            {
                L5EX_GED_1024_patient_observations observation = new L5EX_GED_1024_patient_observations();
                observation.id = item.HEC_ACT_PerformedAction_ObservationID.ToString();
                if (item.Comment == null)
                {
                    var potentialObservationQuery = new ORM_HEC_PotentialObservation.Query();
                    potentialObservationQuery.HEC_PotentialObservationID = item.PotentialObservation_RefID;
                    potentialObservationQuery.IsDeleted = false;
                    potentialObservationQuery.Tenant_RefID = securityTicket.TenantID;
                    var potentialObdervation = ORM_HEC_PotentialObservation.Query.Search(Connection, Transaction, potentialObservationQuery).First();
                    observation.name = potentialObdervation.Observation_Text.Contents[0].Content;
                }
                else
                {
                    observation.name = item.Comment;
                }
                observaionList.Add(observation);
            }
            returnValue.Result.observations = observaionList.ToArray();

            //diagnoses
            var patient_diagnoses_list = cls_Get_Examination_Diagnoses.Invoke(Connection, Transaction, new P_L5EX_GED_1640
            {
               
                ExaminationID = Parameter.ExaminationID,
                PatientID = Parameter.PatientID
            }, securityTicket).Result.ToList();

            List<L5EX_GED_1024_patient_diagnoses> diagnoseList = new List<L5EX_GED_1024_patient_diagnoses>();
            foreach (var item in patient_diagnoses_list)
            {
                L5EX_GED_1024_patient_diagnoses diagnose = new L5EX_GED_1024_patient_diagnoses();
                diagnose.id = item.HEC_Patient_DiagnosisID.ToString();
                diagnose.name = item.ICD10_Code + " " + item.PotentialDiagnosis_Name.Contents[0].Content;
                diagnoseList.Add(diagnose);
            }

            returnValue.Result.patient_diagnoses = diagnoseList.ToArray();

            //medications

            var productList = cls_Get_MedicationProduct_for_PerformedActionID.Invoke(Connection, Transaction, new P_L5ME_GMPfPAID_1133
            {
                PerformedActionID = Parameter.ExaminationID
            }, securityTicket).Result.ToList();

            List<L5EX_GED_1024_patient_medications> medication_list = new List<L5EX_GED_1024_patient_medications>();

            foreach (var item in productList)
            {
                L5EX_GED_1024_patient_medications medication = new L5EX_GED_1024_patient_medications();
                medication.id = item.HEC_ACT_PerformedAction_MedicationUpdateID.ToString();
                medication.name = item.Product_Name.Contents[0].Content + " " + item.DosageForm_Name.Contents[0].Content + " " + item.DosageText;
                medication.image = item.IsMedicationDeactivated == false ? "../Images/icons/added.png" : "../Images/icons/removed.png";
                medication_list.Add(medication);
            }

            P_L5EMR_GSfEID_1210  substancesParameter =  new P_L5EMR_GSfEID_1210();
            substancesParameter.PerformedActionID = Parameter.ExaminationID;
            var substanceList = cls_Get_Substances_for_ExaminationID.Invoke(Connection, Transaction, substancesParameter, securityTicket).Result;

            foreach (var item in substanceList)
            {
                L5EX_GED_1024_patient_medications medication = new L5EX_GED_1024_patient_medications();
                medication.id = item.HEC_ACT_PerformedAction_MedicationUpdateID.ToString();
                medication.name = item.GlobalPropertyMatchingID + " " + item.IfSubstance_Strength + " " + item.ISOCode;
                medication.image = item.IsMedicationDeactivated == false ? "../Images/icons/added.png" : "../Images/icons/removed.png";
                medication_list.Add(medication);
            }

            returnValue.Result.medications = medication_list.ToArray();

            //aftercares

            var aftercareList = cls_Get_Followups_for_PatientID_and_ExaminationID.Invoke(Connection,Transaction,new P_L5EX_GFPIDEID_1805{ExaminationID = Parameter.ExaminationID,
            PatientID = Parameter.PatientID},securityTicket).Result;


            List<L5EX_GED_1024_patient_aftercares> aftercare_list = new List<L5EX_GED_1024_patient_aftercares>();
           foreach (var item in aftercareList)
           {
               L5EX_GED_1024_patient_aftercares aftercare = new L5EX_GED_1024_patient_aftercares();
               aftercare.id = item.HEC_ACT_PlannedActionID.ToString();
               aftercare.date = item.date.ToShortDateString();
               aftercare.reason = item.FollowupReason;
               aftercare_list.Add(aftercare);
           }
           
            returnValue.Result.aftercares = aftercare_list.ToArray();

            //Referral
            var referralList = cls_Get_Examination_Referrals.Invoke(Connection, Transaction, new P_L5EX_GER_1744 { ExaminationID = Parameter.ExaminationID }, securityTicket).Result;
            List<L5EX_GED_1024_patient_referrals> referral_list = new List<L5EX_GED_1024_patient_referrals>();
            foreach (var item in referralList)
            {
                L5EX_GED_1024_patient_referrals referral = new L5EX_GED_1024_patient_referrals();
                referral.id = item.id.ToString();
                if(item.OrganizationalUnit_Name_DictID.Contents.Count!=0)
                    referral.medical_practice = item.OrganizationalUnit_Name_DictID.Contents[0].Content;
                if (item.MedicalPracticeType_Name.Contents.Count != 0)
                {
                    referral.medical_practice_type = item.MedicalPracticeType_Name.Contents[0].Content;
                }
                referral_list.Add(referral);
            }

            returnValue.Result.referrals = referral_list.ToArray();


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EX_GED_1024 Invoke(string ConnectionString,P_L5EX_GED_1024 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EX_GED_1024 Invoke(DbConnection Connection,P_L5EX_GED_1024 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EX_GED_1024 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_GED_1024 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EX_GED_1024 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_GED_1024 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EX_GED_1024 functionReturn = new FR_L5EX_GED_1024();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EX_GED_1024 : FR_Base
	{
		public L5EX_GED_1024 Result	{ get; set; }

		public FR_L5EX_GED_1024() : base() {}

		public FR_L5EX_GED_1024(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EX_GED_1024 for attribute P_L5EX_GED_1024
		[Serializable]
		public class P_L5EX_GED_1024 
		{
			//Standard type parameters
			public Guid ExaminationID; 
			public Guid PatientID; 

		}
		#endregion
		#region SClass L5EX_GED_1024 for attribute L5EX_GED_1024
		[Serializable]
		public class L5EX_GED_1024 
		{
			public L5EX_GED_1024_patient_diagnoses[] patient_diagnoses;  
			public L5EX_GED_1024_patient_observations[] observations;  
			public L5EX_GED_1024_patient_aftercares[] aftercares;  
			public L5EX_GED_1024_patient_medications[] medications;  
			public L5EX_GED_1024_patient_referrals[] referrals;  

			//Standard type parameters
		}
		#endregion
		#region SClass L5EX_GED_1024_patient_diagnoses for attribute patient_diagnoses
		[Serializable]
		public class L5EX_GED_1024_patient_diagnoses 
		{
			//Standard type parameters
			public String id; 
			public String name; 

		}
		#endregion
		#region SClass L5EX_GED_1024_patient_observations for attribute observations
		[Serializable]
		public class L5EX_GED_1024_patient_observations 
		{
			//Standard type parameters
			public String id; 
			public String name; 

		}
		#endregion
		#region SClass L5EX_GED_1024_patient_aftercares for attribute aftercares
		[Serializable]
		public class L5EX_GED_1024_patient_aftercares 
		{
			//Standard type parameters
			public String id; 
			public String date; 
			public String reason; 

		}
		#endregion
		#region SClass L5EX_GED_1024_patient_medications for attribute medications
		[Serializable]
		public class L5EX_GED_1024_patient_medications 
		{
			//Standard type parameters
			public String id; 
			public String name; 
			public String image; 

		}
		#endregion
		#region SClass L5EX_GED_1024_patient_referrals for attribute referrals
		[Serializable]
		public class L5EX_GED_1024_patient_referrals 
		{
			//Standard type parameters
			public String id; 
			public String medical_practice; 
			public String medical_practice_type; 

		}
		#endregion

	#endregion
}
