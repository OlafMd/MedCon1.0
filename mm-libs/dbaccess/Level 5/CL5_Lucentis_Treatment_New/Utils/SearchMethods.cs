using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL5_Lucentis_Treatment_New.Utils
{
    public static class SearchMethods
    {
        public static string getPracticeParameter(string s_practice)
        {
            string result = "";
            if(s_practice!="")
                result = " AND LOWER( medical_practice.DisplayName ) LIKE '%" + s_practice.ToLower() + "%'";
            return result;
        }

        public static string getHeathInsuranceParameter(string s_HealthInsurance)
        {
            string result = "";
            if (s_HealthInsurance != "")
                result = " AND LOWER( healthInsurance_bussinessParticipant.DisplayName ) LIKE '%" + s_HealthInsurance.ToLower() + "%'";
            return result;
        }

        public static string getPatientParameter(string s_patientFirstName, string s_patientLastName)
        {
            string result = "";
            if (s_patientFirstName != "")
                result = " AND LOWER( patient_personInfo.FirstName ) LIKE '%" + s_patientFirstName.ToLower() + "%'";
            if (s_patientLastName != "")
                result = " AND LOWER( patient_personInfo.LastName ) LIKE '%" + s_patientLastName.ToLower() + "%'";
            return result;
        }

        public static string getStatusParameter(int IsBilled, int IsPerformed, int IsSheduled, string aftercare_from, string aftercare_to)
        {
            string result = "";
            if (IsBilled == 0 && IsPerformed == 1 && IsSheduled == 1)
            {
                result = " AND treatment.IsTreatmentBilled=0 ";
                if (aftercare_from != string.Empty)
                {
                    result = result + " AND " +
"CASE " +
"WHEN (treatment.IsTreatmentBilled =0 AND treatment.IsTreatmentPerformed =1 ) THEN treatment.IfTreatmentPerformed_Date >= '" + aftercare_from + "' " +
"WHEN (treatment.IsTreatmentBilled =0 AND treatment.IsTreatmentPerformed =0   AND treatment.IsScheduled) then treatment.IfSheduled_Date >= '" + aftercare_from + "' END";
                }

                if (aftercare_to != string.Empty)
                {
                    result = result + " AND " +
    "CASE  " +
    "WHEN (treatment.IsTreatmentBilled =0 AND treatment.IsTreatmentPerformed =1 ) THEN treatment.IfTreatmentPerformed_Date <= '" + aftercare_to + "' " +
    "WHEN (treatment.IsTreatmentBilled =0 AND treatment.IsTreatmentPerformed =0   AND treatment.IsScheduled) then treatment.IfSheduled_Date <= '" + aftercare_to + "' END";

                }
            }
            else if (IsBilled == 0 && IsPerformed == 0 && IsSheduled == 1)
            {
                result = " AND treatment.IsTreatmentBilled=0 AND  treatment.IsTreatmentPerformed =0 ";
                if (aftercare_from != string.Empty)
                    result = result + " AND treatment.IfSheduled_Date >= '" + aftercare_from + "'";
                if (aftercare_to != string.Empty)
                    result = result + " AND treatment.IfSheduled_Date <= '" + aftercare_to + "' ";
            }
            else if (IsBilled == 0 && IsPerformed == 0 && IsSheduled == 0)
                result = " AND treatment.IsTreatmentBilled=0 AND  treatment.IsTreatmentPerformed =0 AND treatment.IsScheduled = 0 ";
            else if (IsBilled == 0 && IsPerformed == 1 && IsSheduled == 0)
            {
                result = " AND treatment.IsTreatmentBilled=0 AND  treatment.IsTreatmentPerformed =1 AND treatment.IsScheduled = 1 ";
                if (aftercare_from != string.Empty)
                    result = result + " AND treatment.IfTreatmentPerformed_Date >= '" + aftercare_from + "'";
                if (aftercare_to != string.Empty)
                    result = result + " AND treatment.IfTreatmentPerformed_Date <= '" + aftercare_to + "' ";
            }
            else if (IsBilled == 1 && IsPerformed == 0 && IsSheduled == 0)
            {
                result = " AND treatment.IsTreatmentBilled=1 ";
                if (aftercare_from != string.Empty)
                    result = result + " AND treatment.IfTreatmentBilled_Date >= '" + aftercare_from + "'";
                if (aftercare_to != string.Empty)
                    result = result + " AND treatment.IfTreatmentBilled_Date <= '" + aftercare_to + "' ";
            }
            else if (IsBilled == 1 && IsPerformed == 1 && IsSheduled == 0)
            {
                result = " AND( (treatment.IsTreatmentBilled=0 AND  treatment.IsTreatmentPerformed =1 ) OR "
           + "  ( treatment.IsTreatmentBilled=1 AND  treatment.IsTreatmentPerformed =1 )  ) ";

                if (aftercare_from != string.Empty)
                {
                    result = result + " AND " +
"CASE WHEN (treatment.IsTreatmentBilled =1) THEN treatment.IfTreatmentBilled_Date >= '" + aftercare_from + "' " +
"WHEN (treatment.IsTreatmentBilled =0 AND treatment.IsTreatmentPerformed =1 ) THEN treatment.IfTreatmentPerformed_Date >= '" + aftercare_from + "' " +
 " END";
                }

                if (aftercare_to != string.Empty)
                {
                    result = result + " AND " +
    "CASE WHEN (treatment.IsTreatmentBilled =1) THEN treatment.IfTreatmentBilled_Date <= '" + aftercare_to + "' " +
    "WHEN (treatment.IsTreatmentBilled =0 AND treatment.IsTreatmentPerformed =1 ) THEN treatment.IfTreatmentPerformed_Date <= '" + aftercare_to + "' " +
 " END";
                }

            }
            else if (IsBilled == 1 && IsPerformed == 0 && IsSheduled == 1)
            {
                result = " AND ( (treatment.IsTreatmentBilled=1) OR (treatment.IsTreatmentBilled=1 AND treatment.IsTreatmentPerformed=0) ) ";

                if (aftercare_from != string.Empty)
                {
                    result = result + " AND " +
"CASE WHEN (treatment.IsTreatmentBilled =1) THEN treatment.IfTreatmentBilled_Date >= '" + aftercare_from + "' " +
"WHEN (treatment.IsTreatmentBilled =0 AND treatment.IsTreatmentPerformed =0   AND treatment.IsScheduled) then treatment.IfSheduled_Date >= '" + aftercare_from + "' END";
                }

                if (aftercare_to != string.Empty)
                {
                    result = result + " AND " +
    "CASE WHEN (treatment.IsTreatmentBilled =1) THEN treatment.IfTreatmentBilled_Date <= '" + aftercare_to + "' " +
    "WHEN (treatment.IsTreatmentBilled =0 AND treatment.IsTreatmentPerformed =0   AND treatment.IsScheduled) then treatment.IfSheduled_Date <= '" + aftercare_to + "' END";

                }
            }
            else
            {
                if (aftercare_from != string.Empty)
                {
                    result = result + " AND " +
"CASE WHEN (treatment.IsTreatmentBilled =1) THEN treatment.IfTreatmentBilled_Date >= '" + aftercare_from + "' " +
"WHEN (treatment.IsTreatmentBilled =0 AND treatment.IsTreatmentPerformed =1 ) THEN treatment.IfTreatmentPerformed_Date >= '" + aftercare_from + "' " +
"WHEN (treatment.IsTreatmentBilled =0 AND treatment.IsTreatmentPerformed =0   AND treatment.IsScheduled) then treatment.IfSheduled_Date >= '" + aftercare_from + "' END";
                }

                if (aftercare_to != string.Empty)
                {
                    result = result + " AND " +
    "CASE WHEN (treatment.IsTreatmentBilled =1) THEN treatment.IfTreatmentBilled_Date <= '" + aftercare_to + "' " +
    "WHEN (treatment.IsTreatmentBilled =0 AND treatment.IsTreatmentPerformed =1 ) THEN treatment.IfTreatmentPerformed_Date <= '" + aftercare_to + "' " +
    "WHEN (treatment.IsTreatmentBilled =0 AND treatment.IsTreatmentPerformed =0   AND treatment.IsScheduled) then treatment.IfSheduled_Date <= '" + aftercare_to + "' END";

                }
            }
            return result;
        }

    }
}
