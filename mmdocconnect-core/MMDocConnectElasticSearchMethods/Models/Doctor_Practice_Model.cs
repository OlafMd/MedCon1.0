using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{

    public class Practice_Doctors_Model : IElasticMapper
    {
        public string id { get; set; }
        public string name { get; set; }
        public string name_untouched { get; set; }
        public string autocomplete_name { get; set; }
        public string aditional_info { get; set; }
        public string salutation { get; set; }
        public string type { get; set; }
        public string bsnr_lanr { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string bank { get; set; }
        public string bank_untouched { get; set; }
        public string bank_id { get; set; }
        public bool bank_info_inherited { get; set; }
        public string bic { get; set; }
        public string iban { get; set; }
        public object contract { get; set; }
        public string account_status { get; set; }
        public string tenantid { get; set; }
        public string group_name { get; set; }
        public string order_name { get; set; }
        public string practice_for_doctor_id { get; set; }
        public string practice_name_for_doctor { get; set; }
        public string doctor_count_or_practice_name { get; set; }
        public string role { get; set; }

    }

    public class Practice_Doctor_Last_Used_Model : IElasticMapper
    {
        public string id { get; set; }
        public string display_name { get; set; }
        public DateTime date_of_use { get; set; }
        public string practice_id { get; set; }
        public string secondary_display_name { get; set; }

    }

    public class ObjSort
    {
        public bool ascending { get; set; }
        public string sortfield { get; set; }
        public string second_sort_key { get; set; }
        public Guid ID { get; set; }

    }

    public class Practice_Parameter
    {
        public Guid practice_id { get; set; }
        public string bsnr { get; set; }
        public string practice_bank_account_id { get; set; }
        public bool ascending { get; set; }
        public string sortfield { get; set; }
        public string role { get; set; }
        public string search_criteria { get; set; }
        public bool? account_status { get; set; }
        public string type { get; set; }
        public int start_row_index { get; set; }
    }

    public class Contract
    {

        public string contract_name { get; set; }
        public DateTime valid_from { get; set; }
        public DateTime valid_to { get; set; }

    }

    public class objDoc
    {

        public Guid DocId { get; set; }
        public string ContractName { get; set; }
        public Guid ContractID { get; set; }
        public Guid ContractAssignment { get; set; }
        public Guid DoctorAssignment { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidThrough { get; set; }
        public string HIP { get; set; }
        public string ValidFromstr { get; set; }
        public string ValidThroughstr { get; set; }
    }
    public class Doctor_Contracts
    {
        public Guid DocID { get; set; }
        public int NumberOfContracts { get; set; }

    }

    public class Bic_Iban_Codes
    {
        public Guid CodeID { get; set; }
        public string IbanPar { get; set; }
        public string BankName { get; set; }
        public string bic { get; set; }
    }
    public class Bic_Parameter
    {

        public string Bic { get; set; }

    }
    public class IBAN_Parameter
    {

        public string iban { get; set; }

    }

}

//public class Rootobject
//{
//    public Practice_Doctors_Model[] practice_doctors { get; set; }
//}


