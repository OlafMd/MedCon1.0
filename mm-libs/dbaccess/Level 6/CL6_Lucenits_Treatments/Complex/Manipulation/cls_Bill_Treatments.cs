/* 
 * Generated on 04.03.2014 12:03:11
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
using CL1_BIL;
using CL1_HEC;
using CL6_Lucenits_Patient.Atomic.Retrieval;
using CL6_Lucenits_Treatments.Atomic.Retrieval;
using CL5_Lucentis_Treatments.Complex.Retrieval;
using CL1_CMN_COM;

namespace CL6_Lucenits_Treatments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Bill_Treatments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Bill_Treatments
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6TR_BT_2204 Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_BT_2204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6TR_BT_2204();
            returnValue.Result = new L6TR_BT_2204();
            ORM_BIL_BillHeader header = new ORM_BIL_BillHeader();
            long previousMaxPositionIndex = Parameter.previousMaxPositionIndex;

            #region persistHeader

            if (Parameter.isNewBilling)
            {
                header.Tenant_RefID = securityTicket.TenantID;
                header.BIL_BillHeaderID = Guid.NewGuid();

                var tenantHeaders = ORM_BIL_BillHeader.Query.Search(Connection, Transaction, new ORM_BIL_BillHeader.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).ToArray();
                tenantHeaders = tenantHeaders.OrderBy(t => t.Creation_Timestamp).ToArray();
                var headersForThisYear = tenantHeaders.Where(h => h.Creation_Timestamp.Year == DateTime.Now.Year).ToArray();

                int prevMaxHeaderNumber = 0;
                if (headersForThisYear.Length > 0)
                {
                    ORM_BIL_BillHeader prevHeader = null;
                    foreach(var headerTY in headersForThisYear)
                    {
                        int hn = 0;
                        if (int.TryParse(headerTY.BillNumber, out hn) && prevMaxHeaderNumber <= hn)
                        {
                            prevMaxHeaderNumber = hn;
                            prevHeader = headerTY;
                        }
                    }

                    if (prevHeader != null)
                    {
                        var positionQuery = new ORM_BIL_BillPosition.Query();
                        positionQuery.Tenant_RefID = securityTicket.TenantID;
                        positionQuery.BIL_BilHeader_RefID = prevHeader.BIL_BillHeaderID;
                        var prevPositions = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, positionQuery).ToArray();
                        if (prevPositions != null && prevPositions.Length > 0)
                        {
                            foreach (var prevPosition in prevPositions)
                            {
                                long number = 0;
                                if (long.TryParse(prevPosition.External_PositionReferenceField, out number) && previousMaxPositionIndex < number)
                                {
                                    previousMaxPositionIndex = number;
                                }
                            }
                        }
                    }                  
                }
                header.BillNumber = prevMaxHeaderNumber + 1 + "";
                if (Parameter.billTreatments) header.Save(Connection, Transaction);
            }
            else
            {         
                header.Tenant_RefID = securityTicket.TenantID;
                header.BIL_BillHeaderID = Parameter.ifOldBillingHeaderID;
                header.BillNumber = Parameter.ifOldBillingHeaderNumber;
            }

            //new edifact entry
            ORM_BIL_BillHeaderExtension_EDIFACT.Query edifactQuery = new ORM_BIL_BillHeaderExtension_EDIFACT.Query();
            edifactQuery.Tenant_RefID = securityTicket.TenantID;
            var edifactRes = ORM_BIL_BillHeaderExtension_EDIFACT.Query.Search(Connection, Transaction, edifactQuery);
            edifactRes = edifactRes.Where(e => e.Creation_Timestamp.Year == DateTime.Now.Year).ToList();
            ORM_BIL_BillHeaderExtension_EDIFACT edifact = new ORM_BIL_BillHeaderExtension_EDIFACT();
            edifact.BIL_BillHeader_RefID = header.BIL_BillHeaderID;
            edifact.BIL_BillHeaderExtension_EDIFACTID = Guid.NewGuid();
            edifact.EDIFACTCounter = edifactRes.Count + 1;
            edifact.Tenant_RefID = securityTicket.TenantID;
            if (Parameter.billTreatments) edifact.Save(Connection, Transaction);
            #endregion

            //positions 
            List<L6TR_BT_2204_Position> positions = new List<L6TR_BT_2204_Position>();
            List<Guid> patientsIDlist = new List<Guid>();
            Dictionary<Guid, Guid> treatment2patient = new Dictionary<Guid,Guid>();
            Dictionary<Guid, int> positionCountPerPatient = new Dictionary<Guid, int>();

            foreach (var id in Parameter.TreatmentID_List)
            {
                var item = new ORM_HEC_Patient_Treatment();
                item.Load(Connection, Transaction, id);
                if(item.IsTreatmentFollowup)
                    throw new Exception("This treatment, ID: " + id + ", is followup!");
                var patient2treatmentQuery = new ORM_HEC_Patient_2_PatientTreatment.Query();
                patient2treatmentQuery.Tenant_RefID = securityTicket.TenantID;
                patient2treatmentQuery.HEC_Patient_Treatment_RefID = id;
                var patient2treatmentRes = ORM_HEC_Patient_2_PatientTreatment.Query.Search(Connection, Transaction, patient2treatmentQuery).First();
                if (!patientsIDlist.Contains(patient2treatmentRes.HEC_Patient_RefID))
                {
                    patientsIDlist.Add(patient2treatmentRes.HEC_Patient_RefID);
                } 
                treatment2patient.Add(id, patient2treatmentRes.HEC_Patient_RefID);

                if (!positionCountPerPatient.ContainsKey(patient2treatmentRes.HEC_Patient_RefID))
                {
                    positionCountPerPatient.Add(patient2treatmentRes.HEC_Patient_RefID, 0);
                }
                
            }

            //log.Debug("first loop finished after: " + sw.ElapsedMilliseconds);

            P_L6PA_GPBIfPID_1155 patParam = new P_L6PA_GPBIfPID_1155();
            patParam.PatientID = patientsIDlist.ToArray();
            var patients = cls_Get_PatientBillInfo_for_PatientID.Invoke(Connection, Transaction, patParam, securityTicket).Result;

            P_L6TR_GTaRDfBIbT_1204 tretParam = new P_L6TR_GTaRDfBIbT_1204();
            tretParam.TreatmentID = Parameter.TreatmentID_List;
            var treatments = cls_Get_Treatment_and_RelevantDiagnosis_for_BillInfo_by_TreatmentID.Invoke(Connection, Transaction, tretParam, securityTicket).Result;
            
            List<Guid> followTretIDs = new List<Guid>();
            if(treatments != null)
            {
                foreach(var t in treatments)
                {
                    followTretIDs.Add(t.HEC_Patient_TreatmentID);
                }
            }
            P_L6TR_GFTfRbIDs_1646 followParam = new P_L6TR_GFTfRbIDs_1646();
            followParam.TreatmentIDs = followTretIDs.ToArray();
            var followups = cls_Get_Followups_for_Report_byIDs.Invoke(Connection, Transaction, followParam, securityTicket).Result;

            ///counter bill
            P_L5TR_GTCfPID_1152 tcParam = new P_L5TR_GTCfPID_1152();
            tcParam.PatientID = patientsIDlist.ToArray();
            var tretRes = cls_Get_TreatmentCount_for_PatientIDlist.Invoke(Connection, Transaction, tcParam, securityTicket).Result;

            int i = 1;
            foreach (var id in Parameter.TreatmentID_List)
            {
                #region collectPositionDataForReport

                var patient = patients.FirstOrDefault(p => p.HEC_PatientID == treatment2patient[id]);
                if (patient == null)
                {
                    //throw new Exception("No patient for ID: " + treatment2patient[id]);
                }
                var treatment = treatments.FirstOrDefault(t => t.HEC_Patient_TreatmentID == id);
                if (treatment == null)
                {
                    throw new Exception("No treatment for ID: " + id);
                }

                var followupsForThisThreatment = followups.Where(f=>f.IfTreatmentFollowup_FromTreatment_RefID == treatment.HEC_Patient_TreatmentID).ToArray();

                #region changeFlag
                if (Parameter.billTreatments)
                {
                    var item = new ORM_HEC_Patient_Treatment();
                    item.Load(Connection, Transaction, id);
                    item.IsTreatmentBilled = true;
                    item.IfTreatmentBilled_Date = DateTime.Now;
                    item.Save(Connection, Transaction);
                }
                #endregion

                #region persistPosition
                ORM_BIL_BillPosition position = new ORM_BIL_BillPosition();
                position.Tenant_RefID = securityTicket.TenantID;
                position.PositionIndex = i;
                position.BIL_BilHeader_RefID = header.BIL_BillHeaderID;
                position.BIL_BillPositionID = Guid.NewGuid();
                if (Parameter.billTreatments) position.Save(Connection, Transaction);

                ORM_BIL_BillPosition_2_PatientTreatment p2t = new ORM_BIL_BillPosition_2_PatientTreatment();
                p2t.AssignmentID = Guid.NewGuid();
                p2t.Tenant_RefID = securityTicket.TenantID;
                p2t.BIL_BillPosition_RefID = position.BIL_BillPositionID;
                p2t.HEC_Patient_Treatment_RefID = treatment.HEC_Patient_TreatmentID;
                if (Parameter.billTreatments) p2t.Save(Connection, Transaction);
                #endregion

                ORM_HEC_Doctor doctor = new ORM_HEC_Doctor();
                if (treatment.IfTreatmentPerformed_ByDoctor_RefID != Guid.Empty)
                {
                    var doctorQuery = new ORM_HEC_Doctor.Query();
                    doctorQuery.HEC_DoctorID = treatment.IfTreatmentPerformed_ByDoctor_RefID;
                    doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, doctorQuery).FirstOrDefault();
                }

                var practiceQuery = new ORM_HEC_MedicalPractis.Query();
                practiceQuery.HEC_MedicalPractiseID = treatment.TreatmentPractice_RefID;
                practiceQuery.Tenant_RefID = securityTicket.TenantID;
                var practice = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, practiceQuery).FirstOrDefault();
                string BSNR = "x";
                if (practice != null)
                {
                    var practiceInfoQuery = new ORM_CMN_COM_CompanyInfo.Query();
                    practiceInfoQuery.CMN_COM_CompanyInfoID = practice.Ext_CompanyInfo_RefID;
                    practiceInfoQuery.Tenant_RefID = securityTicket.TenantID;
                    var practiceInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, practiceInfoQuery).First();
                    BSNR = practiceInfo.CompanyInfo_EstablishmentNumber;
                }

                L6TR_BT_2204_Position pos = new L6TR_BT_2204_Position();
                pos.ORM_BIL_BillPositionID = position.BIL_BillPositionID;
                pos.strDoctorLANR = (doctor != null) ? doctor.DoctorIDNumber : "HEC_Doctor is null!!!!";
                pos.TreatmentID = treatment.HEC_Patient_TreatmentID;
                pos.bTreatmentIsFollowup = treatment.IsTreatmentFollowup;
                pos.strPracticeBSNR = BSNR;
                pos.dtTreatment = treatment.IfTreatmentPerformed_Date;

                if (patient != null)
                {
                    pos.iTreatmentNumber = tretRes.FirstOrDefault(t => t.HEC_PatientID == patient.HEC_PatientID).treatmentCount + positionCountPerPatient[treatment2patient[id]];
                    pos.iPatientSex = patient.Gender;
                    pos.iPatientInsuranceState = (patient.InsuranceStateCode != null) ? patient.InsuranceStateCode : String.Empty;
                    pos.dtPatientBirthDate = patient.Birthdate;
                    pos.PatientFirstName = patient.FirstName;
                    pos.PatientLastName = patient.LastName;
                    pos.PatientInsuranceNumber = (patient.HealthInsurance_Number != null) ? patient.HealthInsurance_Number : String.Empty;
                    
                }
                else
                {
                    pos.iTreatmentNumber = -1;
                    pos.iPatientSex = 0;
                    pos.iPatientInsuranceState = "xxxxx";
                    pos.dtPatientBirthDate = DateTime.MinValue;
                    pos.PatientFirstName = "x";
                    pos.PatientLastName = "x";
                    pos.PatientInsuranceNumber = "x";
                }

                pos.cTreatmentLocalization = (treatment.IsTreatmentOfLeftEye) ? "L" : "R";
                pos.strFollowupPractice = "-";
                pos.strFollowupDoctor = "-";
                pos.strFollowupStatus = "Keine Nachuntersuchung geplant.";
                if (followupsForThisThreatment != null && followupsForThisThreatment.Length > 0)
                {
                    var performedF = followupsForThisThreatment.Where(f => f.IsTreatmentPerformed == true).ToArray();
                    if (performedF != null && performedF.Length > 0)
                    {
                        performedF = performedF.OrderBy(f => f.IfTreatmentPerformed_Date).ToArray();
                        var firstPF = performedF.First();
                        pos.strFollowupDoctor = firstPF.DoctorFirstName + " " + firstPF.DoctorLastname;
                        pos.dtFollowup = firstPF.IfTreatmentPerformed_Date;
                        pos.strFollowupPractice = firstPF.DisplayName;
                        pos.strFollowupStatus = (firstPF.IsTreatmentPerformed) ? "durchgeführt" : "geplant";
                    }
                    else
                    {
                        var scheduledF = followupsForThisThreatment.Where(f => f.IsScheduled == true).ToArray();
                        if (scheduledF != null && scheduledF.Length > 0)
                        {
                            scheduledF = scheduledF.OrderBy(f => f.IfSheduled_Date).ToArray();
                            var firstSF = scheduledF.First();
                            pos.strFollowupDoctor = firstSF.DoctorFirstName + " " + firstSF.DoctorLastname;
                            pos.dtFollowup = firstSF.IfTreatmentPerformed_Date;
                            pos.strFollowupPractice = firstSF.DisplayName;
                            pos.strFollowupStatus = (firstSF.IsTreatmentPerformed) ? "durchgeführt" : "geplant";
                        }
                    }
                }

                var articles = new List<L6TR_BT_2204_ArticleInfo>();
                foreach (var art in treatment.Article)
                {
                    var article = new L6TR_BT_2204_ArticleInfo();
                    article.ArticleID = art.CMN_PRO_ProductID;
                    article.Name = art.Product_Name;
                    article.PZN = art.Product_Number;
                    article.Quantity = art.Quantity;
                    articles.Add(article);
                }
                pos.ArticleInfo = articles.ToArray();

                var diagnosies = new List<L6TR_BT_2204_DiagnosisInfo>();
                foreach (var diag in treatment.RelevantDiagnosis)
                {
                    var diagnose = new L6TR_BT_2204_DiagnosisInfo();
                    diagnose.cDiagnosisState = diag.DiagnosisState_Abbreviation;
                    diagnose.DiagnosisID = diag.HEC_Patient_Treatment_RelevantDiagnosisID;
                    diagnose.strDiagnosisICD10 = diag.ICD10_Code;
                    diagnose.PatientInsuranceState = diag.DiagnosisState_Name;
                    diagnosies.Add(diagnose);
                }
                pos.DiagnosisInfo = diagnosies.ToArray();
                positions.Add(pos);
                #endregion

                positionCountPerPatient[treatment2patient[id]] = positionCountPerPatient[treatment2patient[id]] + 1;
                i++;
            }

            returnValue.Result.Positions = positions.ToArray();
            returnValue.Result.EDIFACTCounter = edifact.EDIFACTCounter;
            returnValue.Result.HeaderNumber = header.BillNumber;
            returnValue.Result.HeaderID = header.BIL_BillHeaderID;
            returnValue.Result.previousMaxPositionIndex = previousMaxPositionIndex;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6TR_BT_2204 Invoke(string ConnectionString,P_L6TR_BT_2204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TR_BT_2204 Invoke(DbConnection Connection,P_L6TR_BT_2204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TR_BT_2204 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_BT_2204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TR_BT_2204 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_BT_2204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TR_BT_2204 functionReturn = new FR_L6TR_BT_2204();
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

				throw new Exception("Exception occured in method cls_Bill_Treatments",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6TR_BT_2204 : FR_Base
	{
		public L6TR_BT_2204 Result	{ get; set; }

		public FR_L6TR_BT_2204() : base() {}

		public FR_L6TR_BT_2204(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TR_BT_2204 for attribute P_L6TR_BT_2204
		[DataContract]
		public class P_L6TR_BT_2204 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] TreatmentID_List { get; set; } 
			[DataMember]
			public bool billTreatments { get; set; } 
			[DataMember]
			public long previousMaxPositionIndex { get; set; } 
			[DataMember]
			public bool isNewBilling { get; set; } 
			[DataMember]
			public Guid ifOldBillingHeaderID { get; set; } 
			[DataMember]
			public string ifOldBillingHeaderNumber { get; set; } 

		}
		#endregion
		#region SClass L6TR_BT_2204 for attribute L6TR_BT_2204
		[DataContract]
		public class L6TR_BT_2204 
		{
			[DataMember]
			public L6TR_BT_2204_Position[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public int EDIFACTCounter { get; set; } 
			[DataMember]
			public Guid HeaderID { get; set; } 
			[DataMember]
			public string HeaderNumber { get; set; } 
			[DataMember]
			public long previousMaxPositionIndex { get; set; } 

		}
		#endregion
		#region SClass L6TR_BT_2204_Position for attribute Positions
		[DataContract]
		public class L6TR_BT_2204_Position 
		{
			[DataMember]
			public L6TR_BT_2204_ArticleInfo[] ArticleInfo { get; set; }
			[DataMember]
			public L6TR_BT_2204_DiagnosisInfo[] DiagnosisInfo { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORM_BIL_BillPositionID { get; set; } 
			[DataMember]
			public Guid TreatmentID { get; set; } 
			[DataMember]
			public string PatientFirstName { get; set; } 
			[DataMember]
			public string PatientLastName { get; set; } 
			[DataMember]
			public string PatientInsuranceNumber { get; set; } 
			[DataMember]
			public DateTime dtPatientBirthDate { get; set; } 
			[DataMember]
			public string strDoctorLANR { get; set; } 
			[DataMember]
			public string strPracticeBSNR { get; set; } 
			[DataMember]
			public bool bTreatmentIsFollowup { get; set; } 
			[DataMember]
			public int iTreatmentNumber { get; set; } 
			[DataMember]
			public DateTime dtTreatment { get; set; } 
			[DataMember]
			public string cTreatmentLocalization { get; set; } 
			[DataMember]
			public string iPatientInsuranceState { get; set; } 
			[DataMember]
			public int iPatientSex { get; set; } 
			[DataMember]
			public string strFollowupPractice { get; set; } 
			[DataMember]
			public string strFollowupDoctor { get; set; } 
			[DataMember]
			public string strFollowupStatus { get; set; } 
			[DataMember]
			public DateTime dtFollowup { get; set; } 
			[DataMember]
			public string healthInsuranceCompany { get; set; } 

		}
		#endregion
		#region SClass L6TR_BT_2204_ArticleInfo for attribute ArticleInfo
		[DataContract]
		public class L6TR_BT_2204_ArticleInfo 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public string PZN { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 

		}
		#endregion
		#region SClass L6TR_BT_2204_DiagnosisInfo for attribute DiagnosisInfo
		[DataContract]
		public class L6TR_BT_2204_DiagnosisInfo 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiagnosisID { get; set; } 
			[DataMember]
			public string strDiagnosisICD10 { get; set; } 
			[DataMember]
			public string cDiagnosisState { get; set; } 
			[DataMember]
			public Dict PatientInsuranceState { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6TR_BT_2204 cls_Bill_Treatments(,P_L6TR_BT_2204 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6TR_BT_2204 invocationResult = cls_Bill_Treatments.Invoke(connectionString,P_L6TR_BT_2204 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Complex.Manipulation.P_L6TR_BT_2204();
parameter.TreatmentID_List = ...;
parameter.billTreatments = ...;
parameter.previousMaxPositionIndex = ...;
parameter.isNewBilling = ...;
parameter.ifOldBillingHeaderID = ...;
parameter.ifOldBillingHeaderNumber = ...;

*/
