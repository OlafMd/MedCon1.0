/* 
 * Generated on 3/23/2014 1:07:06 PM
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
using CL5_Lucentis_Treatments.Atomic.Retrieval;
using CL5_Lucentis_BillingHistory.Atomic.Retrieval;
using CL6_Lucentis_BillingHistory.Utils;
using CL5_Lucentis_Practice.Atomic.Retrieval;
using System.IO;
using System.Net.Mail;
using System.Web;
using Core_ClassLibrarySupport.Utils;
using System.Globalization;

namespace CL6_Lucentis_BillingHistory.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Make_BillingHistory_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Make_BillingHistory_Report
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L6BH_MBHR_1624 Execute(DbConnection Connection, DbTransaction Transaction, P_L6BH_MBHR_1624 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L6BH_MBHR_1624();
            returnValue.Result = new L6BH_MBHR_1624();
            returnValue.Result.areThereTreatmentsOrFollowupsBilledForParameters = false;
            List<TreatmentData> AllSortedTreatments = new List<TreatmentData>();
            List<Guid> listOfPractices = new List<Guid>();

            //treatments and followups for selected month and your (only treatment table)
            var allTreatmentsForTimeRange = cls_Get_Treatments_and_Followups_for_SelectedMonth_and_Year.Invoke(Connection, Transaction, new P_L5TR_GTaFfSMaY_1619() { SelectedMounth = Parameter.SelectedMounth, SelectedYear = Parameter.SelectedYear }, securityTicket).Result.ToList();

            if (allTreatmentsForTimeRange.Count > 0)
                returnValue.Result.areThereTreatmentsOrFollowupsBilledForParameters = true;
            else
                return returnValue;

            List<Guid> listOfTreatmentIDs = allTreatmentsForTimeRange.Select(i => i.HEC_Patient_TreatmentID).ToList();

            //all treatments and followupss that have bill position table (for selected month, year)
            var treatmentData = cls_Get_BilledTreatmentData_for_Report.Invoke(Connection, Transaction, new P_L5BH_GBTDfR_1158() { TreatmentID = listOfTreatmentIDs.ToArray() }, securityTicket).Result.ToList();

            //get all practices
            listOfPractices = treatmentData.Select(i => i.TreatmentPractice_RefID).Distinct().ToList();

            //from this list remove all treatments/followups that do not have bill positions .... // what is left is old followups which do not have sepparate bill position
            foreach (var item in treatmentData)
            {
                var treatmentToRemove = allTreatmentsForTimeRange.Where(i => i.HEC_Patient_TreatmentID == item.HEC_Patient_TreatmentID).FirstOrDefault();
                if (treatmentToRemove != null)
                    allTreatmentsForTimeRange.Remove(treatmentToRemove);
            }
            var oldFollowups = allTreatmentsForTimeRange;

            #region Get all followups with their own bill position and organise them || FOLLOWUP DATA

            var followupsWihtOwnBillPosition = treatmentData.Where(i => i.External_PositionType == "Nachsorge").ToList();

            List<TreatmentData> followupsWihtOwnBillPositionSorted = new List<TreatmentData>();
            foreach (var item in followupsWihtOwnBillPosition)
            {
                TreatmentData followupData = new TreatmentData();
                followupData.Date = item.TreatmentDate.ToString("dd.MM.yyyy", new CultureInfo("de-DE"));
                followupData.FirstName = item.FirstName;
                followupData.LastName = item.LastName;
                followupData.Birthday = item.BirthDate.ToString("dd.MM.yyyy", new CultureInfo("de-DE"));
                followupData.Article = item.Products[0].Product_Name.Contents[0].Content; ;
                followupData.Vorgassnumber = item.VorgangsNumber;
                followupData.PracticeID = item.TreatmentPractice_RefID;
                List<GPOS> GPOS = new List<GPOS>();
                GPOS gposData = new GPOS();
                gposData.Number = item.GPOS;
                gposData.Text = "Nachsorgebehandlung";
                gposData.Price = double.Parse(item.PositionValue_IncludingTax);
                GPOS.Add(gposData);
                followupData.GPOS = GPOS;
                if (item.TCode == "3")
                    followupData.isAOKConfirmedStatus = true;
                else
                    followupData.isAOKConfirmedStatus = false;
                followupsWihtOwnBillPositionSorted.Add(followupData);
            }
            #endregion

            //from all bill positions remove followups
            foreach (var item in followupsWihtOwnBillPosition)
            {
                treatmentData.Remove(item);
            }

            List<Guid> OLDFollowupsThatHaveTreatmentInDifferentPractice = new List<Guid>();
            foreach (var item in oldFollowups)
            {
                if (treatmentData.Where(i => i.HEC_Patient_TreatmentID == item.IfTreatmentFollowup_FromTreatment_RefID).ToList().Count == 0)
                    OLDFollowupsThatHaveTreatmentInDifferentPractice.Add(item.HEC_Patient_TreatmentID);
            }

            #region Organise Treatment data

            List<TreatmentData> TreatmentsSorted = new List<TreatmentData>();
            List<Guid> Treatments = treatmentData.Select(i => i.HEC_Patient_TreatmentID).Distinct().ToList();

            foreach (var treatmentID in Treatments)
            {
                var treatment = treatmentData.Where(i => i.HEC_Patient_TreatmentID == treatmentID && (i.External_PositionType == "Behandlung | Nachsorge" || i.External_PositionType == "Behandlung")).FirstOrDefault();

                TreatmentData treatmentSorted = new TreatmentData();
                treatmentSorted.Date = treatment.TreatmentDate.ToString("dd.MM.yyyy", new CultureInfo("de-DE"));
                treatmentSorted.PracticeID = treatment.TreatmentPractice_RefID;
                treatmentSorted.FirstName = treatment.FirstName;
                treatmentSorted.LastName = treatment.LastName;
                treatmentSorted.Birthday = treatment.BirthDate.ToString("dd.MM.yyyy", new CultureInfo("de-DE"));
                treatmentSorted.Vorgassnumber = treatment.VorgangsNumber;
                if (treatment.Products != null && treatment.Products.Length > 0)
                    treatmentSorted.Article = treatment.Products[0].Product_Name.Contents[0].Content;
                else
                    treatmentSorted.Article = "";
                if (treatment.TCode == "3")
                    treatmentSorted.isAOKConfirmedStatus = true;
                else
                    treatmentSorted.isAOKConfirmedStatus = false;

                List<GPOS> GPOS = new List<GPOS>();
                GPOS gposData = new GPOS();
                gposData.Number = treatment.GPOS;
                gposData.Text = "Erstbehandlung " + treatmentSorted.Article;
                gposData.Price = 230;
                gposData.ID = 1;
                GPOS.Add(gposData);

                if (treatment.External_PositionType == "Behandlung | Nachsorge")
                {

                    gposData = new GPOS();
                    gposData.Number = treatment.GPOS;
                    gposData.Text = "Nachsorgebehandlung";
                    if (treatmentSorted.Article != "Ozurdex")
                        gposData.Price = 60;
                    else
                        gposData.Price = 150;
                    gposData.ID = 2;
                    GPOS.Add(gposData);
                }

                gposData = new GPOS();
                gposData.Number = String.Empty;
                gposData.Text = "Management Pauschaule";
                gposData.Price = 0;
                gposData.ID = 5;
                GPOS.Add(gposData);

                if (treatmentSorted.Article.ToLower().Contains("bevacizumab"))
                {
                    var BevacuzimabTreatment = treatmentData.Where(i => i.HEC_Patient_TreatmentID == treatmentID && ((i.External_PositionType == "Zusatzposition Bevacuzimab") || i.External_PositionType == "Zusatzposition Bevacizumab")).FirstOrDefault();

                    if (BevacuzimabTreatment != null)
                    {
                        gposData = new GPOS();
                        gposData.Number = BevacuzimabTreatment.GPOS;
                        gposData.Text = "Medikamentenkosten Bevacizumab";
                        gposData.Price = double.Parse(BevacuzimabTreatment.PositionValue_IncludingTax);
                        gposData.ID = 3;
                        GPOS.Add(gposData);
                    }

                }

                var WartezeitenmanagementData = treatmentData.Where(i => i.HEC_Patient_TreatmentID == treatmentID && (i.External_PositionType == "Wartezeitenmanagement")).FirstOrDefault();

                if (WartezeitenmanagementData != null)
                {
                    gposData = new GPOS();
                    gposData.Number = WartezeitenmanagementData.GPOS;
                    gposData.Text = "Wartezeitenmanagement";
                    gposData.Price = double.Parse(WartezeitenmanagementData.PositionValue_IncludingTax);
                    gposData.ID = 4;
                    GPOS.Add(gposData);
                }


                GPOS = GPOS.OrderBy(i => i.ID).ToList();
                treatmentSorted.GPOS = GPOS;
                TreatmentsSorted.Add(treatmentSorted);
            }


            #endregion

            #region Combine Treatment bill positions with followup bill positions

            foreach (var item in followupsWihtOwnBillPositionSorted)
            {
                var treatment = TreatmentsSorted.Where(i => i.Date == item.Date && i.FirstName == item.FirstName && i.LastName == item.LastName && i.Birthday == item.Birthday).FirstOrDefault();
                if (treatment == null)
                    TreatmentsSorted.Add(item);
                else
                {
                    GPOS gposData = new GPOS();
                    gposData.Number = treatment.GPOS.Where(i => i.ID == 1).First().Number;
                    gposData.Text = "Nachsorgebehandlung";
                    if (treatment.Article != "Ozurdex")
                        gposData.Price = 60;
                    else
                        gposData.Price = 150;
                    gposData.ID = 2;
                    treatment.GPOS.Add(gposData);
                    treatment.GPOS = treatment.GPOS.OrderBy(i => i.ID).ToList();
                }
            }

            #endregion

            #region Organise OLD Followups (followups that do not have sepparate bill position) and add them to all Treatments
            if (OLDFollowupsThatHaveTreatmentInDifferentPractice.Count > 0)
            {
                var rawDataForOldFollowups = cls_Get_BilledFollowupData_for_Report.Invoke(Connection, Transaction, new P_L5BH_GBFDfR_1443() { FollowUpID = OLDFollowupsThatHaveTreatmentInDifferentPractice.ToArray() }, securityTicket).Result.ToList();

                rawDataForOldFollowups = rawDataForOldFollowups.Where(i => i.External_PositionType == "Behandlung | Nachsorge" || i.External_PositionType == "Behandlung").ToList();

                List<TreatmentData> OldFollowupsSorted = new List<TreatmentData>();

                foreach (var item in rawDataForOldFollowups)
                {
                    TreatmentData followup = new TreatmentData();
                    followup.Date = item.FollowupDate.ToString("dd.MM.yyyy", new CultureInfo("de-DE"));
                    followup.PracticeID = item.FollowupPracticeID;
                    followup.FirstName = item.FirstName;
                    followup.LastName = item.LastName;
                    followup.Birthday = item.BirthDate.ToString("dd.MM.yyyy", new CultureInfo("de-DE"));
                    followup.Vorgassnumber = item.VorgangsNumber;
                    if (item.Products != null && item.Products.Length > 0)
                        followup.Article = item.Products[0].Product_Name.Contents[0].Content;
                    else
                        followup.Article = "";
                    if (item.TCode == "3")
                        followup.isAOKConfirmedStatus = true;
                    else
                        followup.isAOKConfirmedStatus = false;

                    List<GPOS> GPOS = new List<GPOS>();
                    GPOS gposData = new GPOS();
                    gposData.Number = item.GPOS;
                    gposData.Text = "Nachsorgebehandlung";
                    if (followup.Article != "Ozurdex")
                        gposData.Price = 60;
                    else
                        gposData.Price = 150;
                    gposData.ID = 2;
                    GPOS.Add(gposData);

                    followup.GPOS = GPOS;
                    OldFollowupsSorted.Add(followup);
                }

                foreach (var item in OldFollowupsSorted)
                {
                    TreatmentsSorted.Add(item);
                }
            }
            #endregion


            #region get practice details

            P_L5PR_GPDfPID_1501 param = new P_L5PR_GPDfPID_1501();
            param.PracticeID = listOfPractices.ToArray();

            var practicesRawData = cls_Get_PracticeDetails_for_PracticeID.Invoke(Connection, Transaction, param, securityTicket).Result.ToList();


            List<WordReportData> WordDataByPractice = new List<WordReportData>();

            foreach (var practice in practicesRawData)
            {
                WordReportData wordData = new WordReportData();
                wordData.PracticeID = practice.HEC_MedicalPractiseID;
                wordData.PracticeName = practice.PracticeName;
                wordData.PracticeAddress = practice.Street_Name + " " + practice.Street_Number;
                wordData.PracticePostalCodeAndCity = practice.ZIP + " " + practice.Town;
                wordData.SelectedMonth = Parameter.SelectedMounth_String;
                wordData.Treatments = TreatmentsSorted.Where(i => i.PracticeID == wordData.PracticeID).OrderBy(j => j.Date).ToList();

                WordDataByPractice.Add(wordData);
            }
            #endregion

            //Make word documents by practice and attach the documents to email
            List<Attachment> atts = new List<Attachment>();
            foreach (var practice in WordDataByPractice)
            {
                var parameters = new Dictionary<String, Object>();
                parameters.Add("WordReportData", practice);
                parameters.Add("LanguageCode", Parameter.LanguageCode);
                parameters.Add("ReportType", "RTF");

                string reportName = practice.PracticeName.Replace('/', '-');

                var report = new LucentisReports.DoctorsBillingReport();
                report.SetContext(parameters);
                MemoryStream ms1 = new MemoryStream();

                ms1 = report.ExportToMemoryStream();

                ms1.Seek(0, System.IO.SeekOrigin.Begin);

                Attachment att = new Attachment(ms1, "Doctors_Billing_" + reportName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + ".rtf", "application/doc");
                atts.Add(att);
            }

            string[] toMails;
            string mailRes = (String)HttpContext.GetGlobalResourceObject("Global", "ReportMails");
#if DEBUG
            mailRes = (String)HttpContext.GetGlobalResourceObject("Global", "ReportMailsDebug");
#endif
            toMails = mailRes.Split(';');
            string subjectRes = (String)HttpContext.GetGlobalResourceObject("Global", "ReportMailSubject1");
            EmailUtils.SendMail(toMails, subjectRes, "", atts);
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L6BH_MBHR_1624 Invoke(string ConnectionString, P_L6BH_MBHR_1624 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L6BH_MBHR_1624 Invoke(DbConnection Connection, P_L6BH_MBHR_1624 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L6BH_MBHR_1624 Invoke(DbConnection Connection, DbTransaction Transaction, P_L6BH_MBHR_1624 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L6BH_MBHR_1624 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L6BH_MBHR_1624 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L6BH_MBHR_1624 functionReturn = new FR_L6BH_MBHR_1624();
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

                throw new Exception("Exception occured in method cls_Make_BillingHistory_Report", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L6BH_MBHR_1624 : FR_Base
    {
        public L6BH_MBHR_1624 Result { get; set; }

        public FR_L6BH_MBHR_1624() : base() { }

        public FR_L6BH_MBHR_1624(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_L6BH_MBHR_1624 for attribute P_L6BH_MBHR_1624
    [DataContract]
    public class P_L6BH_MBHR_1624
    {
        //Standard type parameters
        [DataMember]
        public int SelectedMounth { get; set; }
        [DataMember]
        public String SelectedMounth_String { get; set; }
        [DataMember]
        public int SelectedYear { get; set; }
        [DataMember]
        public string LanguageCode { get; set; }

    }
    #endregion
    #region SClass L6BH_MBHR_1624 for attribute L6BH_MBHR_1624
    [DataContract]
    public class L6BH_MBHR_1624
    {
        //Standard type parameters
        [DataMember]
        public bool areThereTreatmentsOrFollowupsBilledForParameters { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6BH_MBHR_1624 cls_Make_BillingHistory_Report(,P_L6BH_MBHR_1624 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6BH_MBHR_1624 invocationResult = cls_Make_BillingHistory_Report.Invoke(connectionString,P_L6BH_MBHR_1624 Parameter,securityTicket);
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
var parameter = new CL6_Lucentis_BillingHistory.Complex.Manipulation.P_L6BH_MBHR_1624();
parameter.SelectedMounth = ...;
parameter.SelectedMounth_String = ...;
parameter.SelectedYear = ...;
parameter.LanguageCode = ...;

*/
