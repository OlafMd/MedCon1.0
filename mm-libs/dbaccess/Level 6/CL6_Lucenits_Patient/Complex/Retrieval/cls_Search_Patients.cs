/* 
 * Generated on 9/5/2013 3:56:56 PM
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
using CL5_Lucentis_Patient.Atomic.Retrieval;

namespace CL6_Lucenits_Patient.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Search_Patients.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Search_Patients
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PA_SP_1547 Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_SP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6PA_SP_1547();
            returnValue.Result = new L6PA_SP_1547();

            P_L5PA_GPfP_1242 par = new P_L5PA_GPfP_1242();
            par.PracticeID = Parameter.PracticeID;

            List<L5PA_GPfP_1242> AllPatients = cls_Get_Patients_for_PracticeID.Invoke(Connection, Transaction, par, securityTicket).Result.ToList();
            List<L5PA_GPfP_1242> FilteredAllPatients = new List<L5PA_GPfP_1242>();

            List<L5PA_GPfP_1242a> filteredTreatments = new List<L5PA_GPfP_1242a>();
            List<L5PA_GPfP_1242b> filteredFollowUps = new List<L5PA_GPfP_1242b>();

            //this is used for patients that do not have treatments or followups TODO: change with deep copy
            List<L5PA_GPfP_1242> AllPatients3 = cls_Get_Patients_for_PracticeID.Invoke(Connection, Transaction, par, securityTicket).Result.ToList();

            #region Quick search Today

            if (Parameter.isQuickTreatmentToday == true)
            {


                foreach (var item in AllPatients)
                {
                    filteredTreatments = item.Treatments.Where(v => v.IfSheduled_Date.ToShortDateString() == DateTime.Now.ToShortDateString() && v.TreatmentPractice_RefID == Parameter.PracticeID).ToList();
                    L5PA_GPfP_1242 temp = new L5PA_GPfP_1242();
                    temp.BirthDate = item.BirthDate;
                    temp.FirstName = item.FirstName;
                    temp.LastName = item.LastName;
                    temp.HEC_PatientID = item.HEC_PatientID;
                    temp.Treatments = filteredTreatments.ToArray();

                    if (temp.Treatments.Length > 0)
                    {
                        FilteredAllPatients.Add(temp);
                    }
                }

                if (Parameter.isQuickFollowUpToday == true)
                {
                    foreach (var patient in FilteredAllPatients)
                    {
                        filteredTreatments = new List<L5PA_GPfP_1242a>();

                        foreach (var treat in patient.Treatments)
                        {
                            if (treat.FollowUp.Length > 0)
                            {
                                filteredTreatments.Add(treat);
                            }
                        }
                        if (filteredTreatments.Count > 0)
                        {
                            filteredTreatments = filteredTreatments.GroupBy(a => a.HEC_Patient_TreatmentID).Select(q => q.First()).ToList();
                            patient.Treatments = filteredTreatments.ToArray();
                        }
                        else
                        {
                            patient.Treatments = patient.Treatments.GroupBy(a => a.HEC_Patient_TreatmentID).Select(q => q.First()).ToArray();
                        }
                    }
                }
            }
            #endregion

            #region Quick search Tomorrow

            if (Parameter.isQuickTreatmentTomorrow == true)
            {


                foreach (var item in AllPatients)
                {
                    filteredTreatments = item.Treatments.Where(v => v.IfSheduled_Date.ToShortDateString() == DateTime.Now.AddDays(1).ToShortDateString() && v.TreatmentPractice_RefID == Parameter.PracticeID).ToList();
                    L5PA_GPfP_1242 temp = new L5PA_GPfP_1242();
                    temp.BirthDate = item.BirthDate;
                    temp.FirstName = item.FirstName;
                    temp.LastName = item.LastName;
                    temp.HEC_PatientID = item.HEC_PatientID;
                    temp.Treatments = filteredTreatments.ToArray();

                    if (temp.Treatments.Length > 0)
                    {
                        FilteredAllPatients.Add(temp);
                    }
                }

                if (Parameter.isQuickFollowUpToday == true)
                {
                    foreach (var patient in FilteredAllPatients)
                    {
                        filteredTreatments = new List<L5PA_GPfP_1242a>();

                        foreach (var treat in patient.Treatments)
                        {
                            if (treat.FollowUp.Length > 0)
                            {
                                filteredTreatments.Add(treat);
                            }
                        }
                        if (filteredTreatments.Count > 0)
                        {
                            filteredTreatments = filteredTreatments.GroupBy(a => a.HEC_Patient_TreatmentID).Select(q => q.First()).ToList();
                            patient.Treatments = filteredTreatments.ToArray();
                        }
                        else
                        {
                            patient.Treatments = patient.Treatments.GroupBy(a => a.HEC_Patient_TreatmentID).Select(q => q.First()).ToArray();
                        }
                    }
                }
            }
            #endregion

            #region Quick search Next week

            if (Parameter.isQuickTreatmentNextWeek == true)
            {

                foreach (var item in AllPatients)
                {
                    filteredTreatments = item.Treatments.Where(v => v.IfSheduled_Date.Date < DateTime.Now.Date.AddDays(8)).ToList();
                    filteredTreatments = filteredTreatments.Where(v => v.IfSheduled_Date.Date > DateTime.Now.Date).ToList();
                    filteredTreatments = filteredTreatments.Where(v => v.TreatmentPractice_RefID == Parameter.PracticeID).ToList();

                    L5PA_GPfP_1242 temp = new L5PA_GPfP_1242();
                    temp.BirthDate = item.BirthDate;
                    temp.FirstName = item.FirstName;
                    temp.LastName = item.LastName;
                    temp.HEC_PatientID = item.HEC_PatientID;
                    temp.Treatments = filteredTreatments.ToArray();

                    if (temp.Treatments.Length > 0)
                    {
                        FilteredAllPatients.Add(temp);
                    }
                }
            }
            #endregion

            #region Quick search Last week

            if (Parameter.isQuickTreatmentLastWeek == true)
            {

                foreach (var item in AllPatients)
                {
                    filteredTreatments = item.Treatments.Where(v => v.IfSheduled_Date.Date < DateTime.Now.Date).ToList();
                    filteredTreatments = filteredTreatments.Where(v => v.IfSheduled_Date.Date > DateTime.Now.AddDays(-7)).ToList();
                    filteredTreatments = filteredTreatments.Where(v => v.TreatmentPractice_RefID == Parameter.PracticeID).ToList();

                    L5PA_GPfP_1242 temp = new L5PA_GPfP_1242();
                    temp.BirthDate = item.BirthDate;
                    temp.FirstName = item.FirstName;
                    temp.LastName = item.LastName;
                    temp.HEC_PatientID = item.HEC_PatientID;
                    temp.Treatments = filteredTreatments.ToArray();

                    if (temp.Treatments.Length > 0)
                    {
                        FilteredAllPatients.Add(temp);
                    }
                }
            }
            #endregion

            #region Quick search Next two weeks

            if (Parameter.isQuickTreatmentNextTwoWeeks == true)
            {

                foreach (var item in AllPatients)
                {
                    filteredTreatments = item.Treatments.Where(v => v.IfSheduled_Date.Date < DateTime.Now.Date.AddDays(15)).ToList();
                    filteredTreatments = filteredTreatments.Where(v => v.IfSheduled_Date.Date > DateTime.Now.Date).ToList();
                    filteredTreatments = filteredTreatments.Where(v=>v.TreatmentPractice_RefID == Parameter.PracticeID).ToList();

                    L5PA_GPfP_1242 temp = new L5PA_GPfP_1242();
                    temp.BirthDate = item.BirthDate;
                    temp.FirstName = item.FirstName;
                    temp.LastName = item.LastName;
                    temp.HEC_PatientID = item.HEC_PatientID;
                    temp.Treatments = filteredTreatments.ToArray();

                    if (temp.Treatments.Length > 0)
                    {
                        FilteredAllPatients.Add(temp);
                    }
                }
            }
            #endregion

            #region Quick Search Followup Today

            if (Parameter.isQuickFollowUpToday == true)
            {
                foreach (var item in AllPatients)
                {

                    if (FilteredAllPatients.Where(k=>k.HEC_PatientID==item.HEC_PatientID).ToList().Count>0)
                        continue;

                    if (item.Treatments.Length > 0)
                    {

                        List<L5PA_GPfP_1242a> itemTreatmentsList = item.Treatments.ToList();
                        List<L5PA_GPfP_1242a> filteredTreatmentsForFollowups = new List<L5PA_GPfP_1242a>();

                        foreach (var treatment in itemTreatmentsList)
                        {
                            List<L5PA_GPfP_1242b> filteredFollowUps2 = new List<L5PA_GPfP_1242b>();


                            filteredFollowUps2 = treatment.FollowUp.Where(k => k.FollowUp_IfSheduled_Date.ToShortDateString() == DateTime.Now.ToShortDateString() && k.FollowUp_PracticeID == Parameter.PracticeID).ToList();
                            treatment.FollowUp = filteredFollowUps2.ToArray();

                            if (treatment.FollowUp.Length > 0)
                            {
                                filteredTreatmentsForFollowups.Add(treatment);
                            }

                        }

                        if (filteredTreatmentsForFollowups.Count > 0)
                        {
                            if (Parameter.isQuickTreatmentToday == true)
                            {
                                if (filteredTreatmentsForFollowups.Count > 1)
                                {
                                    filteredTreatmentsForFollowups.RemoveRange(1, filteredTreatmentsForFollowups.Count - 1);
                                }
                            }
                            

                            L5PA_GPfP_1242 temp = new L5PA_GPfP_1242();
                            temp.BirthDate = item.BirthDate;
                            temp.FirstName = item.FirstName;
                            temp.LastName = item.LastName;
                            temp.HEC_PatientID = item.HEC_PatientID;
                            temp.Treatments = filteredTreatmentsForFollowups.ToArray();

                            FilteredAllPatients.Add(temp);
                        }
                    }

                }

           
            }
            #endregion


            #region Quick Search Followup Tomorrow

            if (Parameter.isQuickFoolowUpTomorrow == true)
            {
                foreach (var item in AllPatients)
                {

                    if (FilteredAllPatients.Where(k => k.HEC_PatientID == item.HEC_PatientID).ToList().Count > 0)
                        continue;

                    if (item.Treatments.Length > 0)
                    {

                        List<L5PA_GPfP_1242a> itemTreatmentsList = item.Treatments.ToList();
                        List<L5PA_GPfP_1242a> filteredTreatmentsForFollowups = new List<L5PA_GPfP_1242a>();

                        foreach (var treatment in itemTreatmentsList)
                        {
                            List<L5PA_GPfP_1242b> filteredFollowUps2 = new List<L5PA_GPfP_1242b>();


                            filteredFollowUps2 = treatment.FollowUp.Where(k => k.FollowUp_IfSheduled_Date.ToShortDateString() == DateTime.Now.AddDays(1).ToShortDateString() && k.FollowUp_PracticeID == Parameter.PracticeID).ToList();
                            treatment.FollowUp = filteredFollowUps2.ToArray();

                            if (treatment.FollowUp.Length > 0)
                            {
                                filteredTreatmentsForFollowups.Add(treatment);
                            }

                        }

                        if (filteredTreatmentsForFollowups.Count > 0)
                        {
                            if (Parameter.isQuickTreatmentToday == true)
                            {
                                if (filteredTreatmentsForFollowups.Count > 1)
                                {
                                    filteredTreatmentsForFollowups.RemoveRange(1, filteredTreatmentsForFollowups.Count - 1);
                                }
                            }


                            L5PA_GPfP_1242 temp = new L5PA_GPfP_1242();
                            temp.BirthDate = item.BirthDate;
                            temp.FirstName = item.FirstName;
                            temp.LastName = item.LastName;
                            temp.HEC_PatientID = item.HEC_PatientID;
                            temp.Treatments = filteredTreatmentsForFollowups.ToArray();

                            FilteredAllPatients.Add(temp);
                        }
                    }

                }


            }
            #endregion

            #region Quick Search Followup Last week

            if (Parameter.isQuickFoolowUpLastWeek== true)
            {
                foreach (var item in AllPatients)
                {

                    if (item.Treatments.Length > 0)
                    {

                        List<L5PA_GPfP_1242a> itemTreatmentsList = item.Treatments.ToList();
                        List<L5PA_GPfP_1242a> filteredTreatmentsForFollowups = new List<L5PA_GPfP_1242a>();

                        foreach (var treatment in itemTreatmentsList)
                        {
                            List<L5PA_GPfP_1242b> filteredFollowUps2 = new List<L5PA_GPfP_1242b>();


                            filteredFollowUps2 = treatment.FollowUp.Where(k => k.FollowUp_IfSheduled_Date.Date < DateTime.Now.Date).ToList();
                            filteredFollowUps2 = filteredFollowUps2.Where(k => k.FollowUp_IfSheduled_Date.Date > DateTime.Now.Date.AddDays(-7)).ToList();
                            filteredFollowUps2 = filteredFollowUps2.Where(k => k.FollowUp_PracticeID == Parameter.PracticeID).ToList();

                            treatment.FollowUp = filteredFollowUps2.ToArray();

                            if (treatment.FollowUp.Length > 0)
                            {
                                filteredTreatmentsForFollowups.Add(treatment);
                            }

                        }
                        if (filteredTreatmentsForFollowups.Count > 0)
                        {
                            L5PA_GPfP_1242 temp = new L5PA_GPfP_1242();
                            temp.BirthDate = item.BirthDate;
                            temp.FirstName = item.FirstName;
                            temp.LastName = item.LastName;
                            temp.HEC_PatientID = item.HEC_PatientID;
                            temp.Treatments = filteredTreatmentsForFollowups.ToArray();

                            FilteredAllPatients.Add(temp);
                        }
                    }
                }
            }
            #endregion

            #region Quick Search Followup Next week

            if (Parameter.isQuickFoolowUpNextWeek == true)
            {
                foreach (var item in AllPatients)
                {

                    if (item.Treatments.Length > 0)
                    {

                        List<L5PA_GPfP_1242a> itemTreatmentsList = item.Treatments.ToList();
                        List<L5PA_GPfP_1242a> filteredTreatmentsForFollowups = new List<L5PA_GPfP_1242a>();

                        foreach (var treatment in itemTreatmentsList)
                        {
                            List<L5PA_GPfP_1242b> filteredFollowUps2 = new List<L5PA_GPfP_1242b>();


                            filteredFollowUps2 = treatment.FollowUp.Where(k => k.FollowUp_IfSheduled_Date.Date < DateTime.Now.Date.AddDays(8)).ToList();
                            filteredFollowUps2 = filteredFollowUps2.Where(k => k.FollowUp_IfSheduled_Date.Date > DateTime.Now.Date).ToList();
                            filteredFollowUps2 = filteredFollowUps2.Where(k => k.FollowUp_PracticeID == Parameter.PracticeID).ToList();

                            treatment.FollowUp = filteredFollowUps2.ToArray();

                            if (treatment.FollowUp.Length > 0)
                            {
                                filteredTreatmentsForFollowups.Add(treatment);
                            }

                        }
                        if (filteredTreatmentsForFollowups.Count > 0)
                        {
                            L5PA_GPfP_1242 temp = new L5PA_GPfP_1242();
                            temp.BirthDate = item.BirthDate;
                            temp.FirstName = item.FirstName;
                            temp.LastName = item.LastName;
                            temp.HEC_PatientID = item.HEC_PatientID;
                            temp.Treatments = filteredTreatmentsForFollowups.ToArray();

                            FilteredAllPatients.Add(temp);
                        }
                    }
                }
            }
            #endregion

            #region Quick Search Followup Next two weeks

            if (Parameter.isQuickFollowUpNextTwoWeeks == true)
            {
                foreach (var item in AllPatients)
                {

                    if (item.Treatments.Length > 0)
                    {

                        List<L5PA_GPfP_1242a> itemTreatmentsList = item.Treatments.ToList();
                        List<L5PA_GPfP_1242a> filteredTreatmentsForFollowups = new List<L5PA_GPfP_1242a>();

                        foreach (var treatment in itemTreatmentsList)
                        {
                            List<L5PA_GPfP_1242b> filteredFollowUps2 = new List<L5PA_GPfP_1242b>();


                            filteredFollowUps2 = treatment.FollowUp.Where(k => k.FollowUp_IfSheduled_Date.Date < DateTime.Now.Date.AddDays(15)).ToList();
                            filteredFollowUps2 = filteredFollowUps2.Where(k => k.FollowUp_IfSheduled_Date.Date > DateTime.Now.Date).ToList();
                            filteredFollowUps2 = filteredFollowUps2.Where(k => k.FollowUp_PracticeID == Parameter.PracticeID).ToList();

                            treatment.FollowUp = filteredFollowUps2.ToArray();

                            if (treatment.FollowUp.Length > 0)
                            {
                                filteredTreatmentsForFollowups.Add(treatment);
                            }

                        }
                        if (filteredTreatmentsForFollowups.Count > 0)
                        {
                            L5PA_GPfP_1242 temp = new L5PA_GPfP_1242();
                            temp.BirthDate = item.BirthDate;
                            temp.FirstName = item.FirstName;
                            temp.LastName = item.LastName;
                            temp.HEC_PatientID = item.HEC_PatientID;
                            temp.Treatments = filteredTreatmentsForFollowups.ToArray();

                            FilteredAllPatients.Add(temp);
                        }
                    }
                }
            }
            #endregion

            //Search when user comes to the page, gives treatments and  followups today and all patients that do not have any treatment or followup
            if (Parameter.isQuickFollowUpToday == true && Parameter.isQuickTreatmentToday == true && Parameter.withTreatments == true)
            {
                if (Parameter.withTreatments == true)
                {

                    List<L5PA_GPfP_1242> FilteredAllPatientsNoTreatment = new List<L5PA_GPfP_1242>();

                    FilteredAllPatientsNoTreatment = AllPatients3.Where(v => v.Treatments.Length == 0).ToList();

                    FilteredAllPatientsNoTreatment = FilteredAllPatientsNoTreatment.Where(k => k.PracticeID == Parameter.PracticeID).ToList();


                    foreach (var patient in FilteredAllPatientsNoTreatment)
                    {
                        FilteredAllPatients.Add(patient);
                    }

                }
            }

            #region Noraml Search

            if (Parameter.isQuickFollowUpNextTwoWeeks == false && Parameter.isQuickFollowUpToday == false && Parameter.isQuickTreatmentNextTwoWeeks == false && Parameter.isQuickTreatmentToday == false &&
                Parameter.isQuickTreatmentLastWeek == false && Parameter.isQuickTreatmentTomorrow == false && Parameter.isQuickTreatmentNextWeek == false && Parameter.isQuickFoolowUpTomorrow== false &&
                Parameter.isQuickFoolowUpNextWeek == false && Parameter.isQuickFoolowUpLastWeek==false)
            {

                if (Parameter.withTreatments == false)
                {
                    AllPatients = AllPatients.Where(c => c.Treatments.Length > 0).ToList();
                }
                else
                {
                    AllPatients = AllPatients.Where(c => c.Treatments.Length > 0).ToList();
                    List<L5PA_GPfP_1242> FilteredAllPatientsNoTreatment = new List<L5PA_GPfP_1242>();

                    FilteredAllPatientsNoTreatment = AllPatients3.Where(v => v.Treatments.Length == 0).ToList();

                    FilteredAllPatientsNoTreatment = FilteredAllPatientsNoTreatment.Where(k => k.PracticeID == Parameter.PracticeID).ToList();


                    foreach (var patient in FilteredAllPatientsNoTreatment)
                    {
                        AllPatients.Add(patient);
                    }
                }


                if (Parameter.FirstName != "")
                {

                    foreach (var item in AllPatients)
                    {
                        if (Core_ClassLibrarySupport.Utils.StringExtensions.ContainsIgnoreCase(item.FirstName, Parameter.FirstName) == true)
                        {
                            FilteredAllPatients.Add(item);
                        }

                    }

                    AllPatients = FilteredAllPatients;
                }

                if (Parameter.LastName != "")
                {
                    FilteredAllPatients = new List<L5PA_GPfP_1242>();
                    foreach (var pat in AllPatients)
                    {
                        FilteredAllPatients.Add(pat);
                    }

                    foreach (var item in AllPatients)
                    {
                        if (Core_ClassLibrarySupport.Utils.StringExtensions.ContainsIgnoreCase(item.LastName, Parameter.LastName) == false)
                        {
                            FilteredAllPatients.Remove(item);
                        }

                    }

                    AllPatients = FilteredAllPatients;
                }

                if (Parameter.BirthDate != null)
                {
                    DateTime date = (DateTime)Parameter.BirthDate;
                    AllPatients = AllPatients.Where(c => c.BirthDate.ToShortDateString() == date.ToShortDateString()).ToList();
                }

                #region TreatmentFrom

                if (Parameter.TreatmentFrom != null)
                {
                    FilteredAllPatients = new List<L5PA_GPfP_1242>();

                    foreach (var item in AllPatients)
                    {


                        filteredTreatments = item.Treatments.Where(v => v.IfSheduled_Date > Parameter.TreatmentFrom).ToList();
                        item.Treatments = filteredTreatments.ToArray();

                        if (item.Treatments.Length > 0)
                        {
                            FilteredAllPatients.Add(item);
                        }
                    }

                    AllPatients = FilteredAllPatients;
                }

                #endregion

                #region TreatmentTo

                if (Parameter.TreatmentTo != null)
                {
                    FilteredAllPatients = new List<L5PA_GPfP_1242>();

                    foreach (var item in AllPatients)
                    {


                        filteredTreatments = item.Treatments.Where(v => v.IfSheduled_Date < Parameter.TreatmentTo).ToList();
                        item.Treatments = filteredTreatments.ToArray();

                        if (item.Treatments.Length > 0)
                        {
                            FilteredAllPatients.Add(item);
                        }
                    }

                    AllPatients = FilteredAllPatients;
                }

                #endregion

                #region FollowupFrom

                if (Parameter.FollowupFrom != null)
                {

                    FilteredAllPatients = new List<L5PA_GPfP_1242>();
                    filteredTreatments = new List<L5PA_GPfP_1242a>();

                    foreach (var item in AllPatients)
                    {

                        if (item.Treatments.Length > 0)
                        {

                            List<L5PA_GPfP_1242a> itemTreatmentsList = item.Treatments.ToList();

                            foreach (var treatment in itemTreatmentsList)
                            {



                                filteredFollowUps = treatment.FollowUp.Where(k => k.FollowUp_IfSheduled_Date > Parameter.FollowupFrom).ToList();
                                treatment.FollowUp = filteredFollowUps.ToArray();

                                if (treatment.FollowUp.Length > 0)
                                {
                                    filteredTreatments.Add(treatment);
                                }

                            }
                            if (filteredTreatments.Count > 0)
                            {
                                item.Treatments = filteredTreatments.ToArray();
                                FilteredAllPatients.Add(item);
                            }
                        }
                    }

                    AllPatients = FilteredAllPatients;
                }
                #endregion

                #region FollowUpTo

                if (Parameter.FollowUpTo != null)
                {

                    FilteredAllPatients = new List<L5PA_GPfP_1242>();
                    filteredTreatments = new List<L5PA_GPfP_1242a>();

                    foreach (var item in AllPatients)
                    {

                        if (item.Treatments.Length > 0)
                        {

                            List<L5PA_GPfP_1242a> itemTreatmentsList = item.Treatments.ToList();

                            foreach (var treatment in itemTreatmentsList)
                            {



                                filteredFollowUps = treatment.FollowUp.Where(k => k.FollowUp_IfSheduled_Date < Parameter.FollowUpTo).ToList();
                                treatment.FollowUp = filteredFollowUps.ToArray();

                                if (treatment.FollowUp.Length > 0)
                                {
                                    filteredTreatments.Add(treatment);
                                }

                            }
                            if (filteredTreatments.Count > 0)
                            {
                                item.Treatments = filteredTreatments.ToArray();
                                FilteredAllPatients.Add(item);
                            }
                        }
                    }

                    AllPatients = FilteredAllPatients;
                }

                #endregion


                if (Parameter.FirstName == "" && Parameter.LastName == "" && Parameter.BirthDate == null && Parameter.TreatmentFrom == null && Parameter.TreatmentTo == null &&
                    Parameter.FollowupFrom == null && Parameter.FollowUpTo == null)
                {
                    List<L5PA_GPfP_1242> AllPatients2 = cls_Get_Patients_for_PracticeID.Invoke(Connection, Transaction, par, securityTicket).Result.ToList();
                    List<L5PA_GPfP_1242> FilteredAllPatientsTodayTreatment = new List<L5PA_GPfP_1242>();
                    FilteredAllPatients = new List<L5PA_GPfP_1242>();

                                   

                    foreach (var item2 in FilteredAllPatients)
                    {
                        if (!FilteredAllPatientsTodayTreatment.Select(c => c.HEC_PatientID).Contains(item2.HEC_PatientID))
                        {
                            FilteredAllPatientsTodayTreatment.Add(item2);
                        }
                    }

                    AllPatients = FilteredAllPatientsTodayTreatment;

                    //if search patients without treatments and followups
                    if (Parameter.withTreatments == true)
                    {
                        
                        List<L5PA_GPfP_1242> FilteredAllPatientsNoTreatment = new List<L5PA_GPfP_1242>();

                        FilteredAllPatientsNoTreatment = AllPatients3.Where(v => v.Treatments.Length == 0).ToList();

                        FilteredAllPatientsNoTreatment = FilteredAllPatientsNoTreatment.Where(k => k.PracticeID == Parameter.PracticeID).ToList();


                        foreach (var patient in FilteredAllPatientsNoTreatment)
                        {
                            AllPatients.Add(patient);
                        }

                    }
                }

                returnValue.Result.AllPatients = AllPatients.ToArray();
            }
            else {

                returnValue.Result.AllPatients = FilteredAllPatients.ToArray();
            
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
		public static FR_L6PA_SP_1547 Invoke(string ConnectionString,P_L6PA_SP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PA_SP_1547 Invoke(DbConnection Connection,P_L6PA_SP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PA_SP_1547 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_SP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PA_SP_1547 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_SP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PA_SP_1547 functionReturn = new FR_L6PA_SP_1547();
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

				throw new Exception("Exception occured in method cls_Search_Patients",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PA_SP_1547 : FR_Base
	{
		public L6PA_SP_1547 Result	{ get; set; }

		public FR_L6PA_SP_1547() : base() {}

		public FR_L6PA_SP_1547(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PA_SP_1547 for attribute P_L6PA_SP_1547
		[DataContract]
		public class P_L6PA_SP_1547 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public bool withTreatments { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public bool isQuickTreatmentToday { get; set; } 
			[DataMember]
			public bool isQuickTreatmentNextTwoWeeks { get; set; } 
			[DataMember]
			public bool isQuickFollowUpToday { get; set; } 
			[DataMember]
			public bool isQuickFollowUpNextTwoWeeks { get; set; } 
			[DataMember]
			public DateTime? BirthDate { get; set; } 
			[DataMember]
			public DateTime? TreatmentFrom { get; set; } 
			[DataMember]
			public DateTime? TreatmentTo { get; set; } 
			[DataMember]
			public DateTime? FollowupFrom { get; set; } 
			[DataMember]
			public DateTime? FollowUpTo { get; set; } 
			[DataMember]
			public bool isQuickTreatmentTomorrow { get; set; } 
			[DataMember]
			public bool isQuickTreatmentLastWeek { get; set; } 
			[DataMember]
			public bool isQuickTreatmentNextWeek { get; set; } 
			[DataMember]
			public bool isQuickFoolowUpTomorrow { get; set; } 
			[DataMember]
			public bool isQuickFoolowUpLastWeek { get; set; } 
			[DataMember]
			public bool isQuickFoolowUpNextWeek { get; set; } 

		}
		#endregion
		#region SClass L6PA_SP_1547 for attribute L6PA_SP_1547
		[DataContract]
		public class L6PA_SP_1547 
		{
			//Standard type parameters
			[DataMember]
			public L5PA_GPfP_1242[] AllPatients { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PA_SP_1547 cls_Search_Patients(,P_L6PA_SP_1547 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PA_SP_1547 invocationResult = cls_Search_Patients.Invoke(connectionString,P_L6PA_SP_1547 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Patient.Complex.Retrieval.P_L6PA_SP_1547();
parameter.PracticeID = ...;
parameter.withTreatments = ...;
parameter.FirstName = ...;
parameter.LastName = ...;
parameter.isQuickTreatmentToday = ...;
parameter.isQuickTreatmentNextTwoWeeks = ...;
parameter.isQuickFollowUpToday = ...;
parameter.isQuickFollowUpNextTwoWeeks = ...;
parameter.BirthDate = ...;
parameter.TreatmentFrom = ...;
parameter.TreatmentTo = ...;
parameter.FollowupFrom = ...;
parameter.FollowUpTo = ...;
parameter.isQuickTreatmentTomorrow = ...;
parameter.isQuickTreatmentLastWeek = ...;
parameter.isQuickTreatmentNextWeek = ...;
parameter.isQuickFoolowUpTomorrow = ...;
parameter.isQuickFoolowUpLastWeek = ...;
parameter.isQuickFoolowUpNextWeek = ...;

*/
