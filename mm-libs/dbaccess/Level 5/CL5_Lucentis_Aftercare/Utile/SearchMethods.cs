using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL5_Lucentis_Aftercare.Utile
{
    public static class SearchMethods
    {
        public static string getPracticeParameter(string s_practice)
        {
            return " AND LOWER( MedicalPractice.DisplayName ) LIKE '%" + s_practice.ToLower() + "%'"; 
        }

        public static string getStatusParameter(int IsBilled, int IsPerformed, int IsSheduled, string aftercare_from, string aftercare_to)
        {
            string result = "";
            if (IsBilled == 0 && IsPerformed == 1 && IsSheduled == 1)
            {
                result = " AND Followup.IsTreatmentBilled=0 ";
                if (aftercare_from != string.Empty)
                {
                    result = result + " AND " +
"CASE " +
"WHEN (Followup.IsTreatmentBilled =0 AND Followup.IsTreatmentPerformed =1 ) THEN Followup.IfTreatmentPerformed_Date >= '" + aftercare_from + "' " +
"WHEN (Followup.IsTreatmentBilled =0 AND Followup.IsTreatmentPerformed =0   AND Followup.IsScheduled) then Followup.IfSheduled_Date >= '" + aftercare_from + "' END";
                }

                if (aftercare_to != string.Empty)
                {
                    result = result + " AND " +
    "CASE  " +
    "WHEN (Followup.IsTreatmentBilled =0 AND Followup.IsTreatmentPerformed =1 ) THEN Followup.IfTreatmentPerformed_Date <= '" + aftercare_to + "' " +
    "WHEN (Followup.IsTreatmentBilled =0 AND Followup.IsTreatmentPerformed =0   AND Followup.IsScheduled) then Followup.IfSheduled_Date <= '" + aftercare_to + "' END";

                }
            }
            else if (IsBilled == 0 && IsPerformed == 0 && IsSheduled == 1)
            {
                result = " AND Followup.IsTreatmentBilled=0 AND  Followup.IsTreatmentPerformed =0 ";
                if (aftercare_from != string.Empty)
                    result = result + " AND Followup.IfSheduled_Date >= '" + aftercare_from + "'";
                if (aftercare_to != string.Empty)
                    result = result + " AND Followup.IfSheduled_Date <= '" + aftercare_to + "' ";
            }
            else if (IsBilled == 0 && IsPerformed == 0 && IsSheduled == 0)
                result = " AND Followup.IsTreatmentBilled=0 AND  Followup.IsTreatmentPerformed =0 AND Followup.IsScheduled = 0 ";
            else if (IsBilled == 0 && IsPerformed == 1 && IsSheduled == 0)
            {
                result = " AND Followup.IsTreatmentBilled=0 AND  Followup.IsTreatmentPerformed =1 AND Followup.IsScheduled = 1 ";
                if (aftercare_from != string.Empty)
                    result = result + " AND Followup.IfTreatmentPerformed_Date >= '" + aftercare_from + "'";
                if (aftercare_to != string.Empty)
                    result = result + " AND Followup.IfTreatmentPerformed_Date <= '" + aftercare_to + "' ";
            }
            else if (IsBilled == 1 && IsPerformed == 0 && IsSheduled == 0)
            {
                result = " AND Followup.IsTreatmentBilled=1 ";
                if (aftercare_from != string.Empty)
                    result = result + " AND Followup.IfTreatmentBilled_Date >= '" + aftercare_from + "'";
                if (aftercare_to != string.Empty)
                    result = result + " AND Followup.IfTreatmentBilled_Date <= '" + aftercare_to + "' ";
            }
            else if (IsBilled == 1 && IsPerformed == 1 && IsSheduled == 0)
            {
                result = " AND( (Followup.IsTreatmentBilled=0 AND  Followup.IsTreatmentPerformed =1 ) OR "
           + "  ( Followup.IsTreatmentBilled=1 AND  Followup.IsTreatmentPerformed =1 )  ) ";

                if (aftercare_from != string.Empty)
                {
                    result = result + " AND " +
"CASE WHEN (Followup.IsTreatmentBilled =1) THEN Followup.IfTreatmentBilled_Date >= '" + aftercare_from + "' " +
"WHEN (Followup.IsTreatmentBilled =0 AND Followup.IsTreatmentPerformed =1 ) THEN Followup.IfTreatmentPerformed_Date >= '" + aftercare_from + "' " +
 " END";
                }

                if (aftercare_to != string.Empty)
                {
                    result = result + " AND " +
    "CASE WHEN (Followup.IsTreatmentBilled =1) THEN Followup.IfTreatmentBilled_Date <= '" + aftercare_to + "' " +
    "WHEN (Followup.IsTreatmentBilled =0 AND Followup.IsTreatmentPerformed =1 ) THEN Followup.IfTreatmentPerformed_Date <= '" + aftercare_to + "' " +
 " END";
                }

            }
            else if (IsBilled == 1 && IsPerformed == 0 && IsSheduled == 1)
            {
                result = " AND ( (Followup.IsTreatmentBilled=1) OR (Followup.IsTreatmentBilled=1 AND Followup.IsTreatmentPerformed=0) ) ";

                if (aftercare_from != string.Empty)
                {
                    result = result + " AND " +
"CASE WHEN (Followup.IsTreatmentBilled =1) THEN Followup.IfTreatmentBilled_Date >= '" + aftercare_from + "' " +
"WHEN (Followup.IsTreatmentBilled =0 AND Followup.IsTreatmentPerformed =0   AND Followup.IsScheduled) then Followup.IfSheduled_Date >= '" + aftercare_from + "' END";
                }

                if (aftercare_to != string.Empty)
                {
                    result = result + " AND " +
    "CASE WHEN (Followup.IsTreatmentBilled =1) THEN Followup.IfTreatmentBilled_Date <= '" + aftercare_to + "' " +
    "WHEN (Followup.IsTreatmentBilled =0 AND Followup.IsTreatmentPerformed =0   AND Followup.IsScheduled) then Followup.IfSheduled_Date <= '" + aftercare_to + "' END";

                }
            }
            else
            {
                if (aftercare_from != string.Empty)
                {
                    result = result + " AND " +
"CASE WHEN (Followup.IsTreatmentBilled =1) THEN Followup.IfTreatmentBilled_Date >= '" + aftercare_from + "' " +
"WHEN (Followup.IsTreatmentBilled =0 AND Followup.IsTreatmentPerformed =1 ) THEN Followup.IfTreatmentPerformed_Date >= '" + aftercare_from + "' " +
"WHEN (Followup.IsTreatmentBilled =0 AND Followup.IsTreatmentPerformed =0   AND Followup.IsScheduled) then Followup.IfSheduled_Date >= '" + aftercare_from + "' END";
                }

                if (aftercare_to != string.Empty)
                {
                    result = result + " AND " +
    "CASE WHEN (Followup.IsTreatmentBilled =1) THEN Followup.IfTreatmentBilled_Date <= '" + aftercare_to + "' " +
    "WHEN (Followup.IsTreatmentBilled =0 AND Followup.IsTreatmentPerformed =1 ) THEN Followup.IfTreatmentPerformed_Date <= '" + aftercare_to + "' " +
    "WHEN (Followup.IsTreatmentBilled =0 AND Followup.IsTreatmentPerformed =0   AND Followup.IsScheduled) then Followup.IfSheduled_Date <= '" + aftercare_to + "' END";

                }
            }
            return result;
        }

        public static string getPatientParameter(string s_patientFirstName, string s_patientLastName)
        {
            string result = "";
            if (s_patientFirstName!="")
                result = " AND LOWER( cmn_per_personinfo1.FirstName ) LIKE '%" + s_patientFirstName.ToLower() + "%'";
            if (s_patientLastName != "")
                result = " AND LOWER( cmn_per_personinfo1.LastName ) LIKE '%" + s_patientLastName.ToLower() + "%'"; 
            return result;
        }

        public static string getPerformedDoctorParameter(string s_doctorFirstName, string s_doctorLastName)
        {
            string result = "";
            if (s_doctorFirstName != "")
                result = " AND LOWER( cmn_per_personinfo.FirstName ) LIKE '%" + s_doctorFirstName.ToLower() + "%'";
            if (s_doctorLastName != "")
                result = " AND LOWER( cmn_per_personinfo.LastName ) LIKE '%" + s_doctorLastName.ToLower() + "%'"; 
            return result;
        }

        public static string getScheduledDoctorParameter(string s_doctorFirstName, string s_doctorLastName)
        {
            string result = "";
            if (s_doctorFirstName != "")
                result = " AND LOWER( ScheduledDoctor_PersonInfo.FirstName ) LIKE '%" + s_doctorFirstName.ToLower() + "%'";
            if (s_doctorLastName != "")
                result = " AND LOWER( ScheduledDoctor_PersonInfo.LastName ) LIKE '%" + s_doctorLastName.ToLower() + "%'";
            return result;
        }


        public static string getHeathInsuranceParameter(string s_HealthInsurance)
        {
            string result = "";
            if (s_HealthInsurance != "")
                result = " AND LOWER( cmn_bpt_businessparticipants2.DisplayName ) LIKE '%" + s_HealthInsurance.ToLower() + "%'";
            return result;
        }
    }
}
