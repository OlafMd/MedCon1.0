using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Models
{
  public  class GPOS_Model
    {
      public string GPOSTitle { get; set; }
      public string BillingCode { get; set; }
      public string Case_Type { get; set; }
      public string Case_Type_Value { get; set; }
      public string From_inj { get; set; }
      public int From_inj_No { get; set; }
      public string To_inj { get; set; }
      public int To_inj_No { get; set; }

      public string Waive_with_Order { get; set; }
      public bool Waive_with_Order_value { get; set;}
      public string Service_fee_in_Eur { get; set; }
      public string Service_fee_in_Eur_Value { get; set; }
      public int Fee_in_EUR { get; set; }
      public List<Drugs> DrugsForGPOS { get; set; }
      public List<Diagnosis> DiagnosisForGPOS { get; set; }
    }
    public  class Drugs
    {
    public string Drug_name {get; set;}

    }
    public class Diagnosis
    {
        public string DiagnoseCode { get; set; }

    }
}
