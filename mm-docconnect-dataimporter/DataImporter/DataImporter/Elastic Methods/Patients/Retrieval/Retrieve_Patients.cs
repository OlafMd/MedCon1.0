using CSV2Core.SessionSecurity;
using DataImporter.Elastic_Methods.Doctor.Manipulation;
using DataImporter.Elastic_test.Model;
using DataImporter.Models;
using MMDocConnectElasticSearchMethods;
using PlainElastic.Net;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Elastic_Methods.Patients.Retrieval
{
    public class Retrieve_Patients
    {
        public static Patient_Model Get_Patient_for_PatientID(string patient_id, SessionSecurityTicket userSecurityTicket)
        {
            Patient_Model patient = new Patient_Model();
            var TenantID = userSecurityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string elasticType = "patient";

            string query = Add_New_Patient.BuildGetPatientQuery(patient_id);

            string searchCommand = Commands.Search(TenantID, elasticType).Pretty();
            string result = connection.Post(searchCommand, query);

            var foundResults = serializer.ToSearchResult<Patient_Model>(result);

            foreach (var item in foundResults.Documents)
            {
                patient = item;
            }
            return patient;
        }
    }
}
