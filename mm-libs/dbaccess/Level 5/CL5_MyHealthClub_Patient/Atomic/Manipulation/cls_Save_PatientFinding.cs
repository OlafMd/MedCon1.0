/* 
 * Generated on 12/26/2014 1:34:30 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL1_CMN_STR;
using CL1_HEC;
using CL1_HEC_ACT;

namespace CL5_MyHealthClub_Patient.Atomic.Manipulation
{
	[Serializable]
	public class cls_Save_PatientFinding
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_SPF_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            var returnID = Guid.Empty;

            if (Parameter.FindingID == Guid.Empty)
            {
                #region Save


                var officeQuery = new ORM_CMN_STR_Office.Query();
                officeQuery.CMN_STR_OfficeID = Parameter.PracticeID;
                officeQuery.IsMedicalPractice = true;
                officeQuery.IsDeleted = false;
                officeQuery.Tenant_RefID = securityTicket.TenantID;

                var office = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, officeQuery).SingleOrDefault();

                ORM_HEC_Patient_Finding patient_finding = new ORM_HEC_Patient_Finding();
                patient_finding.HEC_Patient_FindingID = Guid.NewGuid();
                patient_finding.Patient_RefID = Parameter.PatientID;
                patient_finding.MedicalPractice_RefID =office!=null ? office.IfMedicalPractise_HEC_MedicalPractice_RefID : Guid.Empty;
                patient_finding.UndersigningDoctor_RefID = Parameter.DoctorID;
                patient_finding.IfFindingFromReferral_Referral_RefID = Guid.NewGuid();
                patient_finding.Tenant_RefID = securityTicket.TenantID;
                patient_finding.Creation_Timestamp = Parameter.Date;
                patient_finding.Modification_Timestamp = DateTime.Now;
                patient_finding.Save(Connection,Transaction);
     
                ORM_HEC_ACT_PerformedAction_Referral referal = new ORM_HEC_ACT_PerformedAction_Referral();
                referal.HEC_ACT_PerformedAction_ReferralID = patient_finding.IfFindingFromReferral_Referral_RefID;
                referal.Tenant_RefID = securityTicket.TenantID;
                referal.ReferralTo_MedicalPractice_RefID = Parameter.ReferalPracticeID;
                referal.Creation_Timestamp = DateTime.Now;
                referal.Modification_Timestamp = DateTime.Now;
                referal.ReferralTo_MedicalPracticeType_RefID = Parameter.ReferalTypeID;
                referal.Save(Connection, Transaction);

                returnID = patient_finding.HEC_Patient_FindingID;
                #endregion
            }
            else
            {
                if (Parameter.isDeleted)
                {
                    #region Delete
                    var patient_findingQuery = new ORM_HEC_Patient_Finding.Query();
                    patient_findingQuery.HEC_Patient_FindingID = Parameter.FindingID;
                    patient_findingQuery.Patient_RefID = Parameter.PatientID;
                    patient_findingQuery.IsDeleted = false;
                    patient_findingQuery.Tenant_RefID = securityTicket.TenantID;

                    var patient_finding = ORM_HEC_Patient_Finding.Query.Search(Connection, Transaction, patient_findingQuery).Single();
                    patient_finding.IsDeleted = true;
                    patient_finding.Modification_Timestamp = DateTime.Now;
                    patient_finding.Save(Connection,Transaction);

                    var referalQuery = new ORM_HEC_ACT_PerformedAction_Referral.Query();
                    referalQuery.HEC_ACT_PerformedAction_ReferralID = patient_finding.IfFindingFromReferral_Referral_RefID;
                    referalQuery.IsDeleted = false;
                    referalQuery.Tenant_RefID = securityTicket.TenantID;

                    var referal = ORM_HEC_ACT_PerformedAction_Referral.Query.Search(Connection, Transaction, referalQuery).Single();
                    referal.IsDeleted = true;
                    referal.Modification_Timestamp = DateTime.Now;
                    referal.Save(Connection,Transaction);
                    #endregion
                }
                else
                {
                    #region Edit
                    var officeQuery = new ORM_CMN_STR_Office.Query();
                    officeQuery.CMN_STR_OfficeID = Parameter.PracticeID;
                    officeQuery.IsMedicalPractice = true;
                    officeQuery.IsDeleted = false;
                    officeQuery.Tenant_RefID = securityTicket.TenantID;

                    var office = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, officeQuery).SingleOrDefault();

                    var patient_findingQuery = new ORM_HEC_Patient_Finding.Query();
                    patient_findingQuery.HEC_Patient_FindingID = Parameter.FindingID;
                    patient_findingQuery.Patient_RefID = Parameter.PatientID;
                    patient_findingQuery.IsDeleted = false;
                    patient_findingQuery.Tenant_RefID = securityTicket.TenantID;

                    var patient_finding = ORM_HEC_Patient_Finding.Query.Search(Connection, Transaction, patient_findingQuery).Single();
                    patient_finding.Patient_RefID = Parameter.PatientID;
                    patient_finding.MedicalPractice_RefID = office != null ? office.IfMedicalPractise_HEC_MedicalPractice_RefID : Guid.Empty;
                    patient_finding.UndersigningDoctor_RefID = Parameter.DoctorID;
                    patient_finding.Modification_Timestamp = DateTime.Now;
                    patient_finding.Save(Connection, Transaction);

                    var referalQuery = new ORM_HEC_ACT_PerformedAction_Referral.Query();
                    referalQuery.HEC_ACT_PerformedAction_ReferralID = patient_finding.IfFindingFromReferral_Referral_RefID;
                    referalQuery.IsDeleted = false;
                    referalQuery.Tenant_RefID = securityTicket.TenantID;

                    var referal = ORM_HEC_ACT_PerformedAction_Referral.Query.Search(Connection, Transaction, referalQuery).Single();
                    referal.Modification_Timestamp = DateTime.Now;
                    referal.ReferralTo_MedicalPracticeType_RefID = Parameter.ReferalTypeID;
                    referal.ReferralTo_MedicalPractice_RefID = Parameter.ReferalPracticeID;
                    referal.Save(Connection, Transaction);

                    returnID = patient_finding.HEC_Patient_FindingID;
                    #endregion
                }

            }

            returnValue.Result = returnID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PA_SPF_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PA_SPF_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_SPF_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_SPF_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

	#region Support Classes
		#region SClass P_L5PA_SPF_1413 for attribute P_L5PA_SPF_1413
		[Serializable]
		public class P_L5PA_SPF_1413 
		{
			//Standard type parameters
			public bool isDeleted; 
			public DateTime Date; 
			public Guid ReferalTypeID; 
			public Guid ReferalPracticeID; 
			public Guid PracticeID; 
			public Guid DoctorID; 
			public Guid PatientID; 
			public Guid FindingID; 

		}
		#endregion

	#endregion
}
