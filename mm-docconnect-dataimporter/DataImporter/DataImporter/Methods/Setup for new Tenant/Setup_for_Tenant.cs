using CL1_CMN;
using CL1_CMN_CTR;
using CL2_Language.Atomic.Retrieval;
using CSV2Core.SessionSecurity;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataImporter.Methods
{
    class Setup_for_Tenant
    {
        public static void Setup_for_new_Tenant(string connectionString,  SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;
            try
            {
               
                if (cleanupConnection == true)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
                    Connection.Open();
                }
                if (cleanupTransaction == true)
                {
                    Transaction = Connection.BeginTransaction();
                }
                //add default currency for Tenant used for GPOSes 
                var DBLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result.ToList();
                Dict currencyName = new Dict(ORM_CMN_Currency.TableName);
                for (int i = 0; i < DBLanguages.Count; i++)
                {
                    currencyName.AddEntry(DBLanguages[i].CMN_LanguageID, "Euro");
                }

                var currencyGeneral = new ORM_CMN_Currency();
                currencyGeneral.CMN_CurrencyID = Guid.NewGuid();
                currencyGeneral.ISO4127 = "EUR";
                currencyGeneral.Symbol = "€";
                currencyGeneral.Tenant_RefID = securityTicket.TenantID;
                currencyGeneral.IsDeleted = false;
                currencyGeneral.Name = currencyName;
                currencyGeneral.Creation_Timestamp = DateTime.Now;
                currencyGeneral.Save(Connection, Transaction);

                var contract = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).ToList();
                if (contract.Count() == 0) { 
                Precreaton_of_First_Contract.Create_Contract_With_Private_HIP(Connection, Transaction, securityTicket); //first run this -adding contract with private hIP
                Precreaton_of_First_Contract.Create_Contract_Ivi_Vertrag(Connection, Transaction, securityTicket);  //second, run this- contract with diagnoses 
                Add_GPOSes_to_Contract.Create_data_for_GPOSes(Connection, Transaction, securityTicket);
                }
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

             throw ex;
         }
}
        public static void Add_Company_Settings_for_Tenant(string connectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;
            try
            {
                if (cleanupConnection == true)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
                    Connection.Open();
                }
                if (cleanupTransaction == true)
                {
                    Transaction = Connection.BeginTransaction();
                }
                var tenantSettingsQ = ORM_CMN_Tenant_ApplicationSetting.Query.Search(Connection, Transaction, new ORM_CMN_Tenant_ApplicationSetting.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).SingleOrDefault();
                if (tenantSettingsQ==null) {
                    //create xml file
                    var ms = new MemoryStream();
                    var w = new XmlTextWriter(ms, new UTF8Encoding(false)) { Formatting = System.Xml.Formatting.Indented };


                    w.WriteStartDocument();
                    w.WriteStartElement("AppSettings");
                    w.WriteElementString("AccountID", securityTicket.AccountID.ToString());
                    w.WriteElementString("Email", ConfigurationManager.AppSettings["mailFrom"]);
                    w.WriteElementString("ImmediateOrderInterval","120");
                    w.WriteElementString("OrderInterval", "120");
                    w.WriteEndElement();

                    w.WriteEndDocument();
                    w.Flush();
                    var xml = Encoding.UTF8.GetString(ms.ToArray());
                    var tenantSettings = new ORM_CMN_Tenant_ApplicationSetting();
                    tenantSettings.IsDeleted = false;
                    tenantSettings.Tenant_RefID = securityTicket.TenantID;
                    tenantSettings.ItemValue = xml;
                    tenantSettings.Creation_Timestamp = DateTime.Now;
                    tenantSettings.Save(Connection, Transaction);

                
                }

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

                throw ex;
            }
        }
    }
}
