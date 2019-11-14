using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Doctor.Retrieval
{
 public  class Iban_Bic_Validation
    {

     public static List<Bic_Iban_Codes> Check_IBAN(IBAN_Parameter IBanParameter, SessionSecurityTicket securityTicket)
     {
       //  var TenantID = securityTicket.TenantID.ToString();
        
         var serializer = new JsonNetSerializer();
         var connection = Elastic_Utils.ElsaticConnection();
         string queryS = string.Empty;
         string elasticType = "iban_bic";
         var index = "validation";
         List<Bic_Iban_Codes> modelBicIBanL = new List<Bic_Iban_Codes>();
         string SearchIban = IBanParameter.iban.Substring(4,8);

         if (Elastic_Utils.IfIndexOrTypeExists(index, connection) && Elastic_Utils.IfIndexOrTypeExists(index + "/" + elasticType, connection))
         {
             var query = new QueryBuilder<Bic_Iban_Codes>()
                     .From(0)
                         .Size(100)
                   .Query(q => q
                      .Bool(b => b
                          .Should(sh => sh
                              .Match(m => m
                                  .Field("IbanPar")
                                  .Query(SearchIban).Operator(PlainElastic.Net.Operator.AND)
                                  )
                              )
                          ));


             queryS = query.BuildBeautified();

             string searchCommand_Doctors_PracticeID = Commands.Search(index, elasticType).Pretty();
             string result = connection.Post(searchCommand_Doctors_PracticeID, queryS);

             var foundResults_Doctors = serializer.ToSearchResult<Bic_Iban_Codes>(result);
             foreach (var item in foundResults_Doctors.Documents)
             {
                 Bic_Iban_Codes modelBicIBan = new Bic_Iban_Codes();
                 modelBicIBan.BankName = item.BankName;
                 modelBicIBan.bic = item.bic;
                 modelBicIBan.IbanPar = item.IbanPar;
                 modelBicIBanL.Add(modelBicIBan);
             }
         }
         return modelBicIBanL;
     }

     public static List<Bic_Iban_Codes> CheckBicBank(Bic_Parameter BicParametar, SessionSecurityTicket securityTicket)
     {
         //  var TenantID = securityTicket.TenantID.ToString();

         var serializer = new JsonNetSerializer();
         var connection = Elastic_Utils.ElsaticConnection();
         string queryS = string.Empty;
         string elasticType = "iban_bic";
         var index = "validation";
         List<Bic_Iban_Codes> modelBicIBanL = new List<Bic_Iban_Codes>();
    

         if (Elastic_Utils.IfIndexOrTypeExists(index, connection) && Elastic_Utils.IfIndexOrTypeExists(index + "/" + elasticType, connection))
         {
             var query = new QueryBuilder<Bic_Iban_Codes>()
                     .From(0)
                         .Size(100)
                   .Query(q => q
                      .Bool(b => b
                          .Should(sh => sh
                              .Match(m => m
                                  .Field("bic")
                                  .Query(BicParametar.Bic).Operator(PlainElastic.Net.Operator.AND)
                                  )
                              )
                          ));


             queryS = query.BuildBeautified();

             string searchCommand_Doctors_PracticeID = Commands.Search(index, elasticType).Pretty();
             string result = connection.Post(searchCommand_Doctors_PracticeID, queryS);

             var foundResults_Doctors = serializer.ToSearchResult<Bic_Iban_Codes>(result);
             foreach (var item in foundResults_Doctors.Documents)
             {
                 Bic_Iban_Codes modelBicIBan = new Bic_Iban_Codes();
                 modelBicIBan.BankName = item.BankName;
                 modelBicIBan.bic = item.bic;
                 modelBicIBan.IbanPar = item.IbanPar;
                 modelBicIBanL.Add(modelBicIBan);
             }
         }
         return modelBicIBanL;
     }




    }
}
