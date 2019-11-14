/* 
 * Generated on 3/13/2015 08:51:15
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
using CL1_HEC_ACT;
using CL1_HEC;

namespace CL5_MyHealthClub_Examanations.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PatientExaminationReferrals.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PatientExaminationReferrals
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_SPER_1422 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();

            var examination = ORM_HEC_ACT_PerformedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction.Query()
            {
                Tenant_RefID=securityTicket.TenantID,
                IsDeleted=false,
                HEC_ACT_PerformedActionID = Parameter.ExaminationID
            }).Single();

            ORM_HEC_ACT_PerformedAction_Referral examinationReferral = ORM_HEC_ACT_PerformedAction_Referral.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_Referral.Query()
            {
                Tenant_RefID=securityTicket.TenantID,
                IsDeleted=false,
                HEC_ACT_PerformedAction_RefID=examination.HEC_ACT_PerformedActionID
            }).SingleOrDefault();
            //save
            if (examinationReferral == null)
            {
                examinationReferral = new ORM_HEC_ACT_PerformedAction_Referral();
                examinationReferral.Tenant_RefID = securityTicket.TenantID;
                examinationReferral.HEC_ACT_PerformedAction_ReferralID = Guid.NewGuid();
                examinationReferral.HEC_ACT_PerformedAction_RefID = examination.HEC_ACT_PerformedActionID;
                examinationReferral.ReferralComment = Parameter.Comment;
                if (Parameter.HospitalID != Guid.Empty)
                {
                    var medicalPractice = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractis.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        IsHospital = true,
                        HEC_MedicalPractiseID = Parameter.HospitalID
                    }).Single();
                    
                    ORM_HEC_MedicalPractice_2_PracticeType medPrac2Type = ORM_HEC_MedicalPractice_2_PracticeType.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_PracticeType.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        HEC_MedicalPractice_RefID = Parameter.HospitalID
                    }).Single();
                    examinationReferral.ReferralTo_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                    examinationReferral.ReferralTo_MedicalPracticeType_RefID = medPrac2Type.HEC_MedicalPractice_Type_RefID;
                }
                else
                {
                    examinationReferral.ReferralTo_MedicalPractice_RefID = Guid.Empty;
                    examinationReferral.ReferralTo_MedicalPracticeType_RefID = Parameter.ReferralPracticeTypeID;
                }
                examinationReferral.ReferralTo_BusinessParticipant_RefID = Guid.Empty;
                if (Parameter.RecomendedDoctorID != Guid.Empty){
                    var doctorBusinessParticipant = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        HEC_DoctorID = Parameter.RecomendedDoctorID
                    }).Single().BusinessParticipant_RefID;
                    examinationReferral.ReferralTo_BusinessParticipant_RefID = doctorBusinessParticipant;
                
                }
               
                ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure performedActionProcedure = new ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure();
                performedActionProcedure.Action_Referral_RefID = examinationReferral.HEC_ACT_PerformedAction_ReferralID;
                performedActionProcedure.PotentialTreatment_RefID = Parameter.ProcedureID;
                performedActionProcedure.Tenant_RefID = securityTicket.TenantID;
                performedActionProcedure.Save(Connection,Transaction);
                examinationReferral.Save(Connection, Transaction);
                
            }
            else
            {//edit
                if (!Parameter.IsDeleted)
                {
                    examinationReferral.ReferralComment = Parameter.Comment;
                    if (Parameter.HospitalID != Guid.Empty)
                    {
                        if (examinationReferral.ReferralTo_MedicalPracticeType_RefID == null)
                            examinationReferral.ReferralTo_MedicalPracticeType_RefID = new Guid();
                        examinationReferral.ReferralTo_MedicalPracticeType_RefID = Guid.Empty;
                        if (examinationReferral.ReferralTo_BusinessParticipant_RefID == null)
                            examinationReferral.ReferralTo_BusinessParticipant_RefID = new Guid();
                        examinationReferral.ReferralTo_BusinessParticipant_RefID = Guid.Empty;
                        examinationReferral.ReferralTo_MedicalPractice_RefID = Parameter.HospitalID;
                        ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure performedActionProcedure = ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            Action_Referral_RefID = examinationReferral.HEC_ACT_PerformedAction_ReferralID
                        }).SingleOrDefault();
                        if (performedActionProcedure != null)
                        {
                            performedActionProcedure.IsDeleted = true;
                            performedActionProcedure.Save(Connection, Transaction);
                        }
                        examinationReferral.Save(Connection, Transaction);
                    }
                    else
                    {
                        examinationReferral.ReferralTo_MedicalPracticeType_RefID = Parameter.ReferralPracticeTypeID;
                        examinationReferral.ReferralTo_MedicalPractice_RefID = Parameter.HospitalID;
                        ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure performedActionProcedure = ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            Action_Referral_RefID = examinationReferral.HEC_ACT_PerformedAction_ReferralID
                        }).SingleOrDefault();
                        if (performedActionProcedure == null)
                        {
                            performedActionProcedure = new ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure();
                            performedActionProcedure.Action_Referral_RefID = examinationReferral.HEC_ACT_PerformedAction_ReferralID;
                            performedActionProcedure.HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedureID = Guid.NewGuid();
                            performedActionProcedure.Tenant_RefID = securityTicket.TenantID;
                            performedActionProcedure.Save(Connection,Transaction);
                        }
                        performedActionProcedure.PotentialTreatment_RefID = Parameter.ProcedureID;
                        performedActionProcedure.Save(Connection, Transaction);
                        examinationReferral.ReferralTo_BusinessParticipant_RefID = Guid.Empty;
                        if (Parameter.RecomendedDoctorID != Guid.Empty)
                        {
                            var doctorBusinessParticipant = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                HEC_DoctorID = Parameter.RecomendedDoctorID
                            }).Single().BusinessParticipant_RefID;
                            examinationReferral.ReferralTo_BusinessParticipant_RefID = doctorBusinessParticipant;

                        }
                        examinationReferral.Save(Connection, Transaction);
                    }
                }
                else
                {//delete
                    ORM_HEC_ACT_PerformedAction_Referral refferal = ORM_HEC_ACT_PerformedAction_Referral.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_Referral.Query()
                    {
                        Tenant_RefID=securityTicket.TenantID,
                        IsDeleted=false,
                        HEC_ACT_PerformedAction_RefID=examination.HEC_ACT_PerformedActionID
                    }).Single();

                    ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure performedActionProcedure = ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedure.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        Action_Referral_RefID = refferal.HEC_ACT_PerformedAction_ReferralID
                    }).Single();

                    performedActionProcedure.IsDeleted = true;
                    performedActionProcedure.Save(Connection, Transaction);
                    refferal.IsDeleted = true;
                    refferal.Save(Connection,Transaction);

                }
                

            }
            returnValue.Result = true;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5PA_SPER_1422 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5PA_SPER_1422 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_SPER_1422 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_SPER_1422 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Save_PatientExaminationReferrals",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PA_SPER_1422 for attribute P_L5PA_SPER_1422
		[DataContract]
		public class P_L5PA_SPER_1422 
		{
			//Standard type parameters
			[DataMember]
			public Guid ExaminationID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public Guid ReferralPracticeTypeID { get; set; } 
			[DataMember]
			public Guid HospitalID { get; set; } 
			[DataMember]
			public Guid ProcedureID { get; set; } 
			[DataMember]
			public Guid RecomendedDoctorID { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_PatientExaminationReferrals(,P_L5PA_SPER_1422 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_PatientExaminationReferrals.Invoke(connectionString,P_L5PA_SPER_1422 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Examanations.Atomic.Manipulation.P_L5PA_SPER_1422();
parameter.ExaminationID = ...;
parameter.PatientID = ...;
parameter.ReferralPracticeTypeID = ...;
parameter.HospitalID = ...;
parameter.ProcedureID = ...;
parameter.RecomendedDoctorID = ...;
parameter.Comment = ...;
parameter.IsDeleted = ...;

*/
