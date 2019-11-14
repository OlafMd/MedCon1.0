/* 
 * Generated on 08.02.2014 14:02:16
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
using CL5_Lucentis_Doctors.Atomic.Retrieval;
using CL5_Lucentis_Patient.Atomic.Retrieval;
using CL6_Lucenits_Treatments.Atomic.Retrieval;
using CL3_MedicalPractices.Atomic.Retrieval;

namespace CL6_Lucenits_Treatments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Bill_AllTreatments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Bill_AllTreatments
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6TR_BAT_2014 Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_BAT_2014 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode

            var returnValue = new FR_L6TR_BAT_2014();
            returnValue.Result = new L6TR_BAT_2014();
            string emptyDataConstant = "-";

            var allTreatments = cls_Get_Treatment_and_RelevantDiagnosis_for_BillInfo.Invoke(Connection, Transaction, new P_L6TR_GTaRD_2039() { fromDate = Parameter.fromDate, toDate = Parameter.toDate }, securityTicket).Result;
            if (allTreatments == null || allTreatments.Length == 0)
                return returnValue;

            List<L6TR_BAT_2014_Position> positions = new List<L6TR_BAT_2014_Position>();
            var patients = cls_Get_AllPatientsSimpleData_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            var doctors = cls_Get_AllDoctors_withBankData_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            var practices = cls_Get_Practice_BaseInfo_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            var treatemntsForReport = allTreatments.Where(t => !t.IsTreatmentFollowup && !t.IsTreatmentDeleted); //(((t.BillData == null || t.BillData.Length == 0) && !t.IsTreatmentDeleted) || !t.IsTreatmentDeleted)).ToList();
            Dictionary<Guid, L6TR_GTaRD_2039> followupsForTreatmentID = new Dictionary<Guid, L6TR_GTaRD_2039>();
            foreach (var t in treatemntsForReport)
            {
                var follwoups = allTreatments.Where(f => f.IfTreatmentFollowup_FromTreatment_RefID == t.HEC_Patient_TreatmentID && !t.IsTreatmentDeleted).ToList();// && (((t.BillData == null || t.BillData.Length == 0) && !t.IsTreatmentDeleted) || !t.IsTreatmentDeleted)).ToArray();
                var followup = follwoups.OrderByDescending(f => f.IfTreatmentBilled_Date).FirstOrDefault();

                if (followup != null)
                {
                    followupsForTreatmentID.Add(t.HEC_Patient_TreatmentID, followup);
                }
                else
                {
                    if (t.BillData != null && t.BillData.Length > 0)
                    {
                        followupsForTreatmentID.Add(t.HEC_Patient_TreatmentID, null);
                    }
                }
            }

            foreach (var treatment in treatemntsForReport)
            {
                #region collectPositionDataForReport

                bool addFollowup = false;

                var patient = patients.FirstOrDefault(p => treatment.HEC_Patient_RefID != null && treatment.HEC_Patient_RefID != Guid.Empty && p.HEC_PatientID == treatment.HEC_Patient_RefID);

                if (patient == null)
                    continue;

                var doctor = doctors.FirstOrDefault(d => d.HEC_DoctorID == (treatment.IsTreatmentPerformed ? treatment.IfTreatmentPerformed_ByDoctor_RefID : treatment.IfSheduled_ForDoctor_RefID));
                var practice = practices.FirstOrDefault(p => p.HEC_MedicalPractiseID == treatment.TreatmentPractice_RefID && treatment.TreatmentPractice_RefID != Guid.Empty);

                L6TR_BAT_2014_Position tPosition = new L6TR_BAT_2014_Position();
                tPosition.PositionProcessNumber = -1;

                tPosition.InsuranceStateCode = patient == null ? emptyDataConstant : patient.InsuranceStateCode;
                tPosition.HealthInsuranceNumber = patient == null ? emptyDataConstant : patient.HealthInsurance_Number;
                tPosition.PatientFirstName = patient == null ? emptyDataConstant : patient.FirstName;
                tPosition.PatientLastName = patient == null ? emptyDataConstant : patient.LastName;
                tPosition.PatientDOB = patient != null ? patient.BirthDate : DateTime.MinValue;

                tPosition.TreatmentType = "OP-Termin";

                tPosition.DateOfTransmision = DateTime.MinValue;
                tPosition.DateOfPayment = DateTime.MinValue;
                tPosition.TransmitionStatus_Comment1 = emptyDataConstant;
                tPosition.TransmitionStatus_Comment2 = emptyDataConstant;
                tPosition.GPOS = emptyDataConstant;

                var diagnose = treatment.RelevantDiagnosis.FirstOrDefault();
                tPosition.DiagnoseCode = diagnose == null ? emptyDataConstant : diagnose.ICD10_Code;
                tPosition.DiagnoseState = diagnose == null ? emptyDataConstant : diagnose.DiagnosisState_Abbreviation;
                tPosition.DiagnoseName = diagnose == null ? emptyDataConstant : diagnose.PotentialDiagnosis_Name_DictID.GetContent(Parameter.LanguageID);
                tPosition.DiagnoseLocalization = treatment.IsTreatmentOfLeftEye ? "L" : "R";
                var article = treatment.Article.FirstOrDefault();
                tPosition.ArticleName = article != null ? article.Product_Name.GetContent(Parameter.LanguageID) : emptyDataConstant;

                tPosition.TreatmentDate = treatment.IsTreatmentPerformed ? treatment.IfTreatmentPerformed_Date : treatment.IfSheduled_Date;
                tPosition.BSNR = practice == null ? emptyDataConstant : practice.BSNR;
                tPosition.PracticeName = practice != null ? practice.PracticeName : emptyDataConstant;
                tPosition.LANR = doctor != null ? doctor.LANR : emptyDataConstant;
                tPosition.DoctroFullName = doctor == null ? emptyDataConstant : doctor.FirstName + " " + doctor.LastName;

                tPosition.AccountOwner = doctor == null ? emptyDataConstant : doctor.OwnerText;
                tPosition.BLZ = doctor == null ? emptyDataConstant : doctor.BankNumber;
                tPosition.AccountNumber = doctor == null ? emptyDataConstant : doctor.AccountNumber;
                tPosition.IBAN = doctor == null ? emptyDataConstant : doctor.IBAN;
                tPosition.BIC = doctor == null ? emptyDataConstant : doctor.BICCode;
                tPosition.BankName = doctor == null ? emptyDataConstant : doctor.BankName;

                long numb = long.MaxValue;
                var billData = treatment.BillData.FirstOrDefault(b => b.External_PositionType == "Behandlung | Nachsorge" && Int64.TryParse(b.External_PositionReferenceField, out numb));

                if (treatment.BillData.Length == 0)
                {
                    tPosition.positionSequence = long.MaxValue - 2;
                    tPosition.TransmitionStatus_Comment1 = "offen";
                    positions.Add(tPosition);
                    addFollowup = true;
                }

                if (billData != null)
                {
                    tPosition.GPOS = billData.External_PositionCode;
                    tPosition.Price = billData.PositionValue_IncludingTax > 230 ? billData.PositionValue_IncludingTax - 60 : billData.PositionValue_IncludingTax;
                    tPosition.PositionProcessNumber = numb;
                    tPosition.positionSequence = tPosition.PositionProcessNumber;
                    if (billData.Status != null)
                    {
                        var status = billData.Status.OrderByDescending(s => s.TransmitionCode).FirstOrDefault();
                        if (status != null)
                        {
                            tPosition.NumberOfNegativeTries = billData.Status.Where(s => s.TransmitionCode == 4).Count();
                            var statusWithCode5 = billData.Status.FirstOrDefault(s => s.TransmitionCode == 5);
                            var statusWithCode6 = billData.Status.FirstOrDefault(s => s.TransmitionCode == 6);
                            var statusWithCode2s = billData.Status.Where(s => s.TransmitionCode == 2);
                            L6TR_GTaRD_2039_TransmisionStatus status2 = statusWithCode2s == null ? null : statusWithCode2s.OrderByDescending(s => s.TransmittedOnDate).FirstOrDefault();
                            tPosition.DateOfTransmision = status2 == null ? DateTime.MinValue : status2.TransmittedOnDate;
                            tPosition.DateOfPayment = statusWithCode6 != null ? statusWithCode6.TransmittedOnDate : statusWithCode5 != null ? statusWithCode5.TransmittedOnDate : DateTime.MinValue; //statusWithCode5 != null || statusWithCode6 != null ? status.TransmittedOnDate : DateTime.MinValue;
                            tPosition.TransmitionStatus_Comment1 = status.TransmitionCode == 6 ? (status.PrimaryComment.Contains("|") ? status.PrimaryComment.Split('|')[0].Trim() : "Process status error!") : status.PrimaryComment;
                            tPosition.TransmitionStatus_Comment2 = status.SecondaryComment;
                            tPosition.positionStatus = status.TransmitionCode;
                            if (status.TransmitionCode == 7) tPosition.TransmitionStatus_Comment1 = "storniert";
                        }
                    }
                    positions.Add(tPosition);
                    addFollowup = true;
                }

                if (followupsForTreatmentID.ContainsKey(treatment.HEC_Patient_TreatmentID))
                {
                    var followup = followupsForTreatmentID[treatment.HEC_Patient_TreatmentID];

                    if (followup != null)
                    {
                        doctor = doctors.FirstOrDefault(d => d.HEC_DoctorID == followup.IfTreatmentPerformed_ByDoctor_RefID && followup.IfTreatmentPerformed_ByDoctor_RefID != Guid.Empty);
                        practice = practices.FirstOrDefault(p => p.HEC_MedicalPractiseID == followup.TreatmentPractice_RefID && followup.TreatmentPractice_RefID != Guid.Empty);
                    }
                    else
                    {
                        doctor = null;
                        practice = null;
                    }

                    var fPosition = new L6TR_BAT_2014_Position();

                    fPosition.DiagnoseLocalization = tPosition.DiagnoseLocalization;
                    fPosition.TreatmentDate = followup != null ? followup.IsTreatmentPerformed ? followup.IfTreatmentPerformed_Date : followup.IfSheduled_Date : treatment.IsTreatmentPerformed ? treatment.IfTreatmentPerformed_Date : treatment.IfSheduled_Date;

                    fPosition.InsuranceStateCode = patient == null ? emptyDataConstant : patient.InsuranceStateCode;
                    fPosition.HealthInsuranceNumber = patient == null ? emptyDataConstant : patient.HealthInsurance_Number;
                    fPosition.PatientFirstName = patient == null ? emptyDataConstant : patient.FirstName;
                    fPosition.PatientLastName = patient == null ? emptyDataConstant : patient.LastName;
                    fPosition.PatientDOB = patient == null ? DateTime.MinValue : patient.BirthDate;

                    fPosition.TreatmentType = "Nachsorge";

                    fPosition.GPOS = billData != null ? tPosition.GPOS : emptyDataConstant;
                    fPosition.Price = billData != null ? 60 : 0;
                    fPosition.positionSequence = tPosition.positionSequence;
                    fPosition.PositionProcessNumber = tPosition.PositionProcessNumber;

                    string comment1 = "offen";
                    if (billData != null && billData.Status != null)
                    {
                        var status = treatment.BillData.FirstOrDefault(b => b.External_PositionType == "Behandlung | Nachsorge").Status.OrderByDescending(s => s.TransmitionCode).FirstOrDefault();
                        if (status != null)
                            if (status.TransmitionCode == 6)
                                comment1 = status.PrimaryComment.Contains("|") ? status.PrimaryComment.Split('|')[1].Trim() : "Process status error!";
                            else
                                comment1 = status.PrimaryComment;
                        if (status.TransmitionCode == 7) comment1 = "storniert";
                    }

                    if (billData != null)
                    {
                        var statusWithCode5 = billData.Status.FirstOrDefault(s => s.TransmitionCode == 5);
                        var statusWithCode6 = billData.Status.FirstOrDefault(s => s.TransmitionCode == 6);
                        fPosition.DateOfPayment = statusWithCode6 != null ? DateTime.MinValue : statusWithCode5 != null ? statusWithCode5.TransmittedOnDate : DateTime.MinValue;
                    }
                    else
                        fPosition.DateOfPayment = DateTime.MinValue;

                    fPosition.DateOfTransmision = billData == null ? DateTime.MinValue : tPosition.DateOfTransmision;
                    fPosition.TransmitionStatus_Comment1 = comment1;
                    fPosition.TransmitionStatus_Comment2 = billData == null ? emptyDataConstant : tPosition.TransmitionStatus_Comment2;
                    fPosition.GPOS = billData == null ? emptyDataConstant : tPosition.GPOS;
                    fPosition.positionStatus = billData == null ? 0 : tPosition.positionStatus;
                    fPosition.DiagnoseCode = diagnose == null ? emptyDataConstant : diagnose.ICD10_Code;
                    fPosition.DiagnoseState = diagnose == null ? emptyDataConstant : diagnose.DiagnosisState_Abbreviation;
                    fPosition.DiagnoseName = diagnose == null ? emptyDataConstant : diagnose.PotentialDiagnosis_Name_DictID.GetContent(Parameter.LanguageID);
                    fPosition.ArticleName = article != null ? article.Product_Name.GetContent(Parameter.LanguageID) : emptyDataConstant;
                    fPosition.BSNR = practice == null ? emptyDataConstant : practice.BSNR;
                    fPosition.PracticeName = practice != null ? practice.PracticeName : emptyDataConstant;
                    fPosition.LANR = doctor != null ? doctor.LANR : emptyDataConstant;
                    fPosition.AccountOwner = doctor == null ? emptyDataConstant : doctor.OwnerText;
                    fPosition.DoctroFullName = doctor == null ? emptyDataConstant : doctor.FirstName + " " + doctor.LastName;
                    fPosition.BLZ = doctor == null ? emptyDataConstant : doctor.BankNumber;
                    fPosition.AccountNumber = doctor == null ? emptyDataConstant : doctor.AccountNumber;
                    fPosition.IBAN = doctor == null ? emptyDataConstant : doctor.IBAN;
                    fPosition.BIC = doctor == null ? emptyDataConstant : doctor.BICCode;
                    fPosition.BankName = doctor == null ? emptyDataConstant : doctor.BankName;
                    if (addFollowup)
                        positions.Add(fPosition);

                    foreach (var otherBillData in treatment.BillData)
                    {
                        if (otherBillData.External_PositionType == "Behandlung | Nachsorge" && Int64.TryParse(otherBillData.External_PositionReferenceField, out numb))
                            continue;

                        L6TR_BAT_2014_Position newPosition = new L6TR_BAT_2014_Position();
                        newPosition.positionSequence = long.MaxValue;

                        newPosition.InsuranceStateCode = tPosition.InsuranceStateCode;
                        newPosition.HealthInsuranceNumber = tPosition.HealthInsuranceNumber;
                        newPosition.PatientFirstName = tPosition.PatientFirstName;
                        newPosition.PatientLastName = tPosition.PatientLastName;
                        newPosition.PatientDOB = tPosition.PatientDOB;
                        newPosition.TreatmentType = otherBillData.External_PositionType;
                        newPosition.DiagnoseCode = tPosition.DiagnoseCode;
                        newPosition.DiagnoseState = tPosition.DiagnoseState;
                        newPosition.DiagnoseName = tPosition.DiagnoseName;
                        newPosition.DiagnoseLocalization = tPosition.DiagnoseLocalization;
                        newPosition.ArticleName = tPosition.ArticleName;
                        newPosition.TreatmentDate = tPosition.TreatmentDate;
                        newPosition.BSNR = tPosition.BSNR;
                        newPosition.PracticeName = tPosition.PracticeName;
                        newPosition.LANR = tPosition.LANR;
                        newPosition.DoctroFullName = tPosition.DoctroFullName;
                        newPosition.AccountOwner = tPosition.AccountOwner;
                        newPosition.BLZ = tPosition.BLZ;
                        newPosition.AccountNumber = tPosition.AccountNumber;
                        newPosition.IBAN = tPosition.IBAN;
                        newPosition.BIC = tPosition.BIC;
                        newPosition.BankName = tPosition.BankName;

                        newPosition.GPOS = otherBillData.External_PositionCode;
                        newPosition.Price = otherBillData.PositionValue_IncludingTax;

                        numb = long.MaxValue;
                        if (!Int64.TryParse(otherBillData.External_PositionReferenceField, out numb))
                        {
                            newPosition.positionSequence = long.MaxValue - 1;
                            newPosition.PositionProcessNumber = 0;
                        }
                        else
                        {
                            newPosition.positionSequence = numb;
                            newPosition.PositionProcessNumber = numb;
                        }

                        if (String.IsNullOrEmpty(otherBillData.External_PositionType))
                        {
                            newPosition.TreatmentType = "no type";
                        }

                        if (otherBillData.Status != null)
                        {
                            var status = otherBillData.Status.OrderByDescending(s => s.TransmitionCode).FirstOrDefault();
                            if (status != null)
                            {
                                newPosition.NumberOfNegativeTries = otherBillData.Status.Where(s => s.TransmitionCode == 4).Count();
                                var statusWithCode5 = otherBillData.Status.FirstOrDefault(s => s.TransmitionCode == 5);
                                var statusWithCode6 = otherBillData.Status.FirstOrDefault(s => s.TransmitionCode == 6);
                                var statusWithCode2s = otherBillData.Status.Where(s => s.TransmitionCode == 2);
                                L6TR_GTaRD_2039_TransmisionStatus status2 = statusWithCode2s == null ? null : statusWithCode2s.OrderByDescending(s => s.TransmittedOnDate).FirstOrDefault();
                                newPosition.DateOfTransmision = status2 == null ? DateTime.MinValue : status2.TransmittedOnDate;
                                newPosition.DateOfPayment = statusWithCode6 != null ? statusWithCode6.TransmittedOnDate : statusWithCode5 != null ? statusWithCode5.TransmittedOnDate : DateTime.MinValue; //statusWithCode5 != null || statusWithCode6 != null ? status.TransmittedOnDate : DateTime.MinValue;
                                newPosition.TransmitionStatus_Comment1 = status.TransmitionCode == 6 ? (status.PrimaryComment.Contains("|") ? status.PrimaryComment.Split('|')[0].Trim() : "Process status error!") : status.PrimaryComment;
                                newPosition.TransmitionStatus_Comment2 = status.SecondaryComment;
                                newPosition.positionStatus = status.TransmitionCode;
                                if (status.TransmitionCode == 7) newPosition.TransmitionStatus_Comment1 = "storniert";
                            }
                        }

                        positions.Add(newPosition);
                    }
                }

                #endregion
            }
            returnValue.Result.Positions = positions.Where(p => Parameter.statusFilter.Contains(p.positionStatus))
               .OrderBy(p => p.positionSequence).ToArray();
            return returnValue;

            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6TR_BAT_2014 Invoke(string ConnectionString,P_L6TR_BAT_2014 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TR_BAT_2014 Invoke(DbConnection Connection,P_L6TR_BAT_2014 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TR_BAT_2014 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_BAT_2014 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TR_BAT_2014 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_BAT_2014 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TR_BAT_2014 functionReturn = new FR_L6TR_BAT_2014();
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

				throw new Exception("Exception occured in method cls_Bill_AllTreatments",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6TR_BAT_2014 : FR_Base
	{
		public L6TR_BAT_2014 Result	{ get; set; }

		public FR_L6TR_BAT_2014() : base() {}

		public FR_L6TR_BAT_2014(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TR_BAT_2014 for attribute P_L6TR_BAT_2014
		[DataContract]
		public class P_L6TR_BAT_2014 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public DateTime fromDate { get; set; } 
			[DataMember]
			public DateTime toDate { get; set; } 
			[DataMember]
			public int[] statusFilter { get; set; } 

		}
		#endregion
		#region SClass L6TR_BAT_2014 for attribute L6TR_BAT_2014
		[DataContract]
		public class L6TR_BAT_2014 
		{
			[DataMember]
			public L6TR_BAT_2014_Position[] Positions { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L6TR_BAT_2014_Position for attribute Positions
		[DataContract]
		public class L6TR_BAT_2014_Position 
		{
			//Standard type parameters
			[DataMember]
			public int positionStatus { get; set; } 
			[DataMember]
			public long positionSequence { get; set; } 
			[DataMember]
			public string InsuranceStateCode { get; set; } 
			[DataMember]
			public string HealthInsuranceNumber { get; set; } 
			[DataMember]
			public string PatientFirstName { get; set; } 
			[DataMember]
			public string PatientLastName { get; set; } 
			[DataMember]
			public DateTime PatientDOB { get; set; } 
			[DataMember]
			public long PositionProcessNumber { get; set; } 
			[DataMember]
			public string TreatmentType { get; set; } 
			[DataMember]
			public string GPOS { get; set; } 
			[DataMember]
			public double Price { get; set; } 
			[DataMember]
			public int NumberOfNegativeTries { get; set; } 
			[DataMember]
			public DateTime DateOfTransmision { get; set; } 
			[DataMember]
			public string TransmitionStatus_Comment2 { get; set; } 
			[DataMember]
			public DateTime DateOfPayment { get; set; } 
			[DataMember]
			public string TransmitionStatus_Comment1 { get; set; } 
			[DataMember]
			public string DiagnoseCode { get; set; } 
			[DataMember]
			public string DiagnoseState { get; set; } 
			[DataMember]
			public string DiagnoseName { get; set; } 
			[DataMember]
			public string DiagnoseLocalization { get; set; } 
			[DataMember]
			public string ArticleName { get; set; } 
			[DataMember]
			public DateTime TreatmentDate { get; set; } 
			[DataMember]
			public string BSNR { get; set; } 
			[DataMember]
			public string PracticeName { get; set; } 
			[DataMember]
			public string LANR { get; set; } 
			[DataMember]
			public string DoctroFullName { get; set; } 
			[DataMember]
			public string AccountOwner { get; set; } 
			[DataMember]
			public string BLZ { get; set; } 
			[DataMember]
			public string AccountNumber { get; set; } 
			[DataMember]
			public string BankName { get; set; } 
			[DataMember]
			public string IBAN { get; set; } 
			[DataMember]
			public string BIC { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6TR_BAT_2014 cls_Bill_AllTreatments(,P_L6TR_BAT_2014 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6TR_BAT_2014 invocationResult = cls_Bill_AllTreatments.Invoke(connectionString,P_L6TR_BAT_2014 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Complex.Manipulation.P_L6TR_BAT_2014();
parameter.LanguageID = ...;
parameter.fromDate = ...;
parameter.toDate = ...;
parameter.statusFilter = ...;

*/
