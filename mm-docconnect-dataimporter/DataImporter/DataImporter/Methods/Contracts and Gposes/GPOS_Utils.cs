using CL1_BIL;
using CL1_CMN;
using CL1_HEC_BIL;
using CL1_HEC_CAS;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Case.Atomic.Manipulation;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Methods.Contracts_and_Gposes
{
    public static class GPOS_Utils
    {
        public static void FixGPOS(string connectionString, SessionSecurityTicket securityTicket)
        {
            var Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
            Connection.Open();

            var Transaction = Connection.BeginTransaction();
            try
            {
                #region ALL LANGUAGES
                ORM_CMN_Language.Query all_languagesQ = new ORM_CMN_Language.Query();
                all_languagesQ.Tenant_RefID = securityTicket.TenantID;
                all_languagesQ.IsDeleted = false;

                var all_languagesL = ORM_CMN_Language.Query.Search(Connection, Transaction, all_languagesQ).ToArray();
                #endregion
                var case_ids = ORM_HEC_CAS_Case.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case.Query() { Tenant_RefID = securityTicket.TenantID }).Where(cas => int.Parse(cas.CaseNumber) >= 10000).Select(cas => cas.HEC_CAS_CaseID).ToArray();
                int i = 1;
                foreach (var case_id in case_ids)
                {
                    var case_details = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = case_id }, securityTicket).Result;
                    if (case_details != null)
                    {
                        cls_Update_Case_GPOS.Invoke(Connection, Transaction, new P_CAS_UCGPOS_1516()
                        {
                            all_languagesL = all_languagesL,
                            case_id = case_id,
                            diagnose_id = case_details.diagnose_id,
                            drug_id = case_details.drug_id,
                            localization = case_details.localization,
                            patient_id = case_details.patient_id
                        }, securityTicket);
                    }
                    Console.Write("\rCase {0} of {1} GPOS updated.                ", i++, case_ids.Length);
                }

                Transaction.Commit();
                Connection.Close();

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                Connection.Close();

                throw new Exception("Something went wrong during GPOS fixing", ex);
            }

        }
    }
}
