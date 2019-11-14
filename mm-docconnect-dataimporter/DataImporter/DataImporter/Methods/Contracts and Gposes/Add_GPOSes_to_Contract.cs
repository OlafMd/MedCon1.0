using CL1_CMN;
using CL1_CMN_BPT;
using CL1_CMN_CTR;
using CL1_CMN_PRO;
using CL1_HEC;
using CL1_HEC_BIL;
using CL1_HEC_CRT;
using CL1_HEC_CTR;
using CL1_HEC_CTR_I2BC;
using CL1_HEC_DIA;
using CL1_USR;
using CL2_Language.Atomic.Retrieval;
using CSV2Core.SessionSecurity;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Methods
{
    class Add_GPOSes_to_Contract
    {
        public static void Create_data_for_GPOSes(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            List<GPOS_Model> GPOSesDataL = new List<GPOS_Model>();
            GPOS_Model GPOSesData = new GPOS_Model();
            GPOSesData.GPOSTitle = "Operation";
            GPOSesData.BillingCode = "36620050";
            GPOSesData.Case_Type = "Case Type";
            GPOSesData.Case_Type_Value = "OP";
            GPOSesData.From_inj = "From injection no.";
            GPOSesData.From_inj_No = 1;
            GPOSesData.To_inj = "To injection no.";
            GPOSesData.To_inj_No = 3;
            GPOSesData.Waive_with_Order = "Waive with order";
            GPOSesData.Waive_with_Order_value = true;
            GPOSesData.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData.Service_fee_in_Eur_Value = "25";
            GPOSesData.Fee_in_EUR = 230;

            List<Drugs> drugDataL = new List<Drugs>();
            Drugs drugData = new Drugs();
            drugData.Drug_name = "Lucentis DFL";
            drugDataL.Add(drugData);
            Drugs drugData2 = new Drugs();
            drugData2.Drug_name = "Lucentis FSP";
            drugDataL.Add(drugData2);
            Drugs drugData3 = new Drugs();
            drugData3.Drug_name = "Macugen";
            drugDataL.Add(drugData3);
            Drugs drugData4 = new Drugs();
            drugData4.Drug_name = "Ranibizumab 0,5mg";
            drugDataL.Add(drugData4);
            Drugs drugData5 = new Drugs();
            drugData5.Drug_name = "Eylea";
            drugDataL.Add(drugData5);
            Drugs drugData6 = new Drugs();
            drugData6.Drug_name = "Aflibercept 2,0mg";
            drugDataL.Add(drugData6);
            Drugs drugData7 = new Drugs();
            drugData7.Drug_name = "Bevacizumab 1,25mg";
            drugDataL.Add(drugData7);
            Drugs drugData8 = new Drugs();
            drugData8.Drug_name = "Bevacizumab 1,5mg";
            drugDataL.Add(drugData8);
            GPOSesData.DrugsForGPOS = drugDataL;

            List<Diagnosis> diagnosisDataL = new List<Diagnosis>();
            Diagnosis diagnosisData = new Diagnosis();
            diagnosisData.DiagnoseCode = "H35.3";
            diagnosisDataL.Add(diagnosisData);
            Diagnosis diagnosisData2 = new Diagnosis();
            diagnosisData2.DiagnoseCode = "H36.0";
            diagnosisDataL.Add(diagnosisData2);

            GPOSesData.DiagnosisForGPOS = diagnosisDataL;
            GPOSesDataL.Add(GPOSesData);
            //first GPOS added 

            GPOS_Model GPOSesData2 = new GPOS_Model();
            GPOSesData2.GPOSTitle = "Nachsorge";
            GPOSesData2.BillingCode = "36620058";
            GPOSesData2.Case_Type = "Case Type";
            GPOSesData2.Case_Type_Value = "Nachsorge";
            GPOSesData2.From_inj = "From injection no.";
            GPOSesData2.From_inj_No = 1;
            GPOSesData2.To_inj = "To injection no.";
            GPOSesData2.To_inj_No = 3;
            GPOSesData2.Waive_with_Order = "Waive with order";
            GPOSesData2.Waive_with_Order_value = false;
            GPOSesData2.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData2.Service_fee_in_Eur_Value = "-";
            GPOSesData2.Fee_in_EUR = 60;

            GPOSesData2.DrugsForGPOS = drugDataL;



            GPOSesData2.DiagnosisForGPOS = diagnosisDataL;
            GPOSesDataL.Add(GPOSesData2);
            ////second GPOS added 

            GPOS_Model GPOSesData3 = new GPOS_Model();
            GPOSesData3.GPOSTitle = "Operation";
            GPOSesData3.BillingCode = "36620051";
            GPOSesData3.Case_Type = "Case Type";
            GPOSesData3.Case_Type_Value = "OP";
            GPOSesData3.From_inj = "From injection no.";
            GPOSesData3.From_inj_No = 4;
            GPOSesData3.To_inj = "To injection no.";
            GPOSesData3.To_inj_No = 6;
            GPOSesData3.Waive_with_Order = "Waive with order";
            GPOSesData3.Waive_with_Order_value = true;
            GPOSesData3.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData3.Service_fee_in_Eur_Value = "25";
            GPOSesData3.Fee_in_EUR = 230;

            GPOSesData3.DrugsForGPOS = drugDataL;

            GPOSesData3.DiagnosisForGPOS = diagnosisDataL;
            GPOSesDataL.Add(GPOSesData3);
            ////Third GPOS added

            GPOS_Model GPOSesData4 = new GPOS_Model();
            GPOSesData4.GPOSTitle = "Nachsorge";
            GPOSesData4.BillingCode = "36620059";
            GPOSesData4.Case_Type = "Case Type";
            GPOSesData4.Case_Type_Value = "Nachsorge";
            GPOSesData4.From_inj = "From injection no.";
            GPOSesData4.From_inj_No = 4;
            GPOSesData4.To_inj = "To injection no.";
            GPOSesData4.To_inj_No = 6;
            GPOSesData4.Waive_with_Order = "Waive with order";
            GPOSesData4.Waive_with_Order_value = false;
            GPOSesData4.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData4.Service_fee_in_Eur_Value = "-";
            GPOSesData4.Fee_in_EUR = 60;

            GPOSesData4.DrugsForGPOS = drugDataL;

            GPOSesData4.DiagnosisForGPOS = diagnosisDataL;
            GPOSesDataL.Add(GPOSesData4);
            ////Fourth GPOS added 

            GPOS_Model GPOSesData5 = new GPOS_Model();
            GPOSesData5.GPOSTitle = "Operation";
            GPOSesData5.BillingCode = "36620052";
            GPOSesData5.Case_Type = "Case Type";
            GPOSesData5.Case_Type_Value = "OP";
            GPOSesData5.From_inj = "From injection no.";
            GPOSesData5.From_inj_No = 7;
            GPOSesData5.To_inj = "To injection no.";
            GPOSesData5.To_inj_No = int.MaxValue;
            GPOSesData5.Waive_with_Order = "Waive with order";
            GPOSesData5.Waive_with_Order_value = true;
            GPOSesData5.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData5.Service_fee_in_Eur_Value = "25";
            GPOSesData5.Fee_in_EUR = 230;

            GPOSesData5.DrugsForGPOS = drugDataL;


            GPOSesData5.DiagnosisForGPOS = diagnosisDataL;
            GPOSesDataL.Add(GPOSesData5);
            ////Fifth GPOS added 

            GPOS_Model GPOSesData6 = new GPOS_Model();
            GPOSesData6.GPOSTitle = "Nachsorge";
            GPOSesData6.BillingCode = "36620060";
            GPOSesData6.Case_Type = "Case Type";
            GPOSesData6.Case_Type_Value = "Nachsorge";
            GPOSesData6.From_inj = "From injection no.";
            GPOSesData6.From_inj_No = 7;
            GPOSesData6.To_inj = "To injection no.";
            GPOSesData6.To_inj_No = int.MaxValue;
            GPOSesData6.Waive_with_Order = "Waive with order";
            GPOSesData6.Waive_with_Order_value = false;
            GPOSesData6.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData6.Service_fee_in_Eur_Value = "-";
            GPOSesData6.Fee_in_EUR = 60;
            GPOSesData6.DrugsForGPOS = drugDataL;
            GPOSesData6.DiagnosisForGPOS = diagnosisDataL;
            GPOSesDataL.Add(GPOSesData6);
            ////Sixth GPOS added 

            GPOS_Model GPOSesData7 = new GPOS_Model();
            GPOSesData7.GPOSTitle = "Operation";
            GPOSesData7.BillingCode = "36620053";
            GPOSesData7.Case_Type = "Case Type";
            GPOSesData7.Case_Type_Value = "OP";
            GPOSesData7.From_inj = "From injection no.";
            GPOSesData7.From_inj_No = 1;
            GPOSesData7.To_inj = "To injection no.";
            GPOSesData7.To_inj_No = int.MaxValue;
            GPOSesData7.Waive_with_Order = "Waive with order";
            GPOSesData7.Waive_with_Order_value = true;
            GPOSesData7.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData7.Service_fee_in_Eur_Value = "25";
            GPOSesData7.Fee_in_EUR = 230;

            GPOSesData7.DrugsForGPOS = drugDataL;

            List<Diagnosis> diagnosisDataL2 = new List<Diagnosis>();
            Diagnosis diagnosisData4 = new Diagnosis();
            diagnosisData4.DiagnoseCode = "H34.8";
            diagnosisDataL2.Add(diagnosisData4);

            GPOSesData7.DiagnosisForGPOS = diagnosisDataL2;
            GPOSesDataL.Add(GPOSesData7);

            ////Seventh GPOS added 

            GPOS_Model GPOSesData8 = new GPOS_Model();
            GPOSesData8.GPOSTitle = "Nachsorge";
            GPOSesData8.BillingCode = "36620061";
            GPOSesData8.Case_Type = "Case Type";
            GPOSesData8.Case_Type_Value = "Nachsorge";
            GPOSesData8.From_inj = "From injection no.";
            GPOSesData8.From_inj_No = 1;
            GPOSesData8.To_inj = "To injection no.";
            GPOSesData8.To_inj_No = 3;
            GPOSesData8.Waive_with_Order = "Waive with order";
            GPOSesData8.Waive_with_Order_value = false;
            GPOSesData8.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData8.Service_fee_in_Eur_Value = "-";
            GPOSesData8.Fee_in_EUR = 60;
            GPOSesData8.DrugsForGPOS = drugDataL;
            GPOSesData8.DiagnosisForGPOS = diagnosisDataL2;
            GPOSesDataL.Add(GPOSesData8);
            ////Eighth GPOS added 


            GPOS_Model GPOSesData9 = new GPOS_Model();
            GPOSesData9.GPOSTitle = "Operation";
            GPOSesData9.BillingCode = "36620054";
            GPOSesData9.Case_Type = "Case Type";
            GPOSesData9.Case_Type_Value = "OP";
            GPOSesData9.From_inj = "From injection no.";
            GPOSesData9.From_inj_No = 4;
            GPOSesData9.To_inj = "To injection no.";
            GPOSesData9.To_inj_No = int.MaxValue;
            GPOSesData9.Waive_with_Order = "Waive with order";
            GPOSesData9.Waive_with_Order_value = true;
            GPOSesData9.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData9.Service_fee_in_Eur_Value = "25";
            GPOSesData9.Fee_in_EUR = 230;
            GPOSesData9.DrugsForGPOS = drugDataL;
            GPOSesData9.DiagnosisForGPOS = diagnosisDataL2;
            GPOSesDataL.Add(GPOSesData9);
            ////Ninth GPOS added

            GPOS_Model GPOSesData10 = new GPOS_Model();
            GPOSesData10.GPOSTitle = "Nachsorge";
            GPOSesData10.BillingCode = "36620062";
            GPOSesData10.Case_Type = "Case Type";
            GPOSesData10.Case_Type_Value = "Nachsorge";
            GPOSesData10.From_inj = "From injection no.";
            GPOSesData10.From_inj_No = 4;
            GPOSesData10.To_inj = "To injection no.";
            GPOSesData10.To_inj_No = int.MaxValue;
            GPOSesData10.Waive_with_Order = "Waive with order";
            GPOSesData10.Waive_with_Order_value = false;
            GPOSesData10.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData10.Service_fee_in_Eur_Value = "-";
            GPOSesData10.Fee_in_EUR = 60;
            GPOSesData10.DrugsForGPOS = drugDataL;
            GPOSesData10.DiagnosisForGPOS = diagnosisDataL2;
            GPOSesDataL.Add(GPOSesData10);
            ////Tenth GPOS added 


            GPOS_Model GPOSesData11 = new GPOS_Model();
            GPOSesData11.GPOSTitle = "Operation";
            GPOSesData11.BillingCode = "36620055";
            GPOSesData11.Case_Type = "Case Type";
            GPOSesData11.Case_Type_Value = "OP";
            GPOSesData11.From_inj = "From injection no.";
            GPOSesData11.From_inj_No = 1;
            GPOSesData11.To_inj = "To injection no.";
            GPOSesData11.To_inj_No = 1;
            GPOSesData11.Waive_with_Order = "Waive with order";
            GPOSesData11.Waive_with_Order_value = true;
            GPOSesData11.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData11.Service_fee_in_Eur_Value = "25";
            GPOSesData11.Fee_in_EUR = 230;
            List<Drugs> drugDataL2 = new List<Drugs>();
            Drugs drugData9 = new Drugs();
            drugData9.Drug_name = "Ozurdex";
            drugDataL2.Add(drugData9);
            GPOSesData11.DrugsForGPOS = drugDataL2;
            GPOSesData11.DiagnosisForGPOS = diagnosisDataL2;
            GPOSesDataL.Add(GPOSesData11);

            ////Eleventh GPOS added

            GPOS_Model GPOSesData12 = new GPOS_Model();
            GPOSesData12.GPOSTitle = "Nachsorge";
            GPOSesData12.BillingCode = "36620063";
            GPOSesData12.Case_Type = "Case Type";
            GPOSesData12.Case_Type_Value = "Nachsorge";
            GPOSesData12.From_inj = "From injection no.";
            GPOSesData12.From_inj_No = 1;
            GPOSesData12.To_inj = "To injection no.";
            GPOSesData12.To_inj_No = 1;
            GPOSesData12.Waive_with_Order = "Waive with order";
            GPOSesData12.Waive_with_Order_value = false;
            GPOSesData12.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData12.Service_fee_in_Eur_Value = "-";
            GPOSesData12.Fee_in_EUR = 150;

            GPOSesData12.DrugsForGPOS = drugDataL2;
            GPOSesData12.DiagnosisForGPOS = diagnosisDataL2;
            GPOSesDataL.Add(GPOSesData12);
            ////Twelfth GPOS added 


            GPOS_Model GPOSesData13 = new GPOS_Model();
            GPOSesData13.GPOSTitle = "Operation";
            GPOSesData13.BillingCode = "36620056";
            GPOSesData13.Case_Type = "Case Type";
            GPOSesData13.Case_Type_Value = "OP";
            GPOSesData13.From_inj = "From injection no.";
            GPOSesData13.From_inj_No = 2;
            GPOSesData13.To_inj = "To injection no.";
            GPOSesData13.To_inj_No = int.MaxValue;
            GPOSesData13.Waive_with_Order = "Waive with order";
            GPOSesData13.Waive_with_Order_value = true;
            GPOSesData13.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData13.Service_fee_in_Eur_Value = "25";
            GPOSesData13.Fee_in_EUR = 230;
            GPOSesData13.DrugsForGPOS = drugDataL2;
            GPOSesData13.DiagnosisForGPOS = diagnosisDataL2;
            GPOSesDataL.Add(GPOSesData13);
            ////Thirteenth GPOS added 

            GPOS_Model GPOSesData14 = new GPOS_Model();
            GPOSesData14.GPOSTitle = "Nachsorge";
            GPOSesData14.BillingCode = "36620064";
            GPOSesData14.Case_Type = "Case Type";
            GPOSesData14.Case_Type_Value = "Nachsorge";
            GPOSesData14.From_inj = "From injection no.";
            GPOSesData14.From_inj_No = 2;
            GPOSesData14.To_inj = "To injection no.";
            GPOSesData14.To_inj_No = int.MaxValue;
            GPOSesData14.Waive_with_Order = "Waive with order";
            GPOSesData14.Waive_with_Order_value = false;
            GPOSesData14.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData14.Service_fee_in_Eur_Value = "-";
            GPOSesData14.Fee_in_EUR = 150;
            GPOSesData14.DrugsForGPOS = drugDataL2;
            GPOSesData14.DiagnosisForGPOS = diagnosisDataL2;
            GPOSesDataL.Add(GPOSesData14);

            ////Fourteenth GPOS added 

            GPOS_Model GPOSesData15 = new GPOS_Model();
            GPOSesData15.GPOSTitle = "Zusatzposition Bevacizumab";
            GPOSesData15.BillingCode = "06010050";
            GPOSesData15.Case_Type = "Case Type";
            GPOSesData15.Case_Type_Value = "OP";
            GPOSesData15.From_inj = "From injection no.";
            GPOSesData15.From_inj_No = int.MaxValue;
            GPOSesData15.To_inj = "To injection no.";
            GPOSesData15.To_inj_No = int.MaxValue;
            GPOSesData15.Waive_with_Order = "Waive with order";
            GPOSesData15.Waive_with_Order_value = false;
            GPOSesData15.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData15.Service_fee_in_Eur_Value = "-";
            GPOSesData15.Fee_in_EUR = 75;
            List<Drugs> drugDataL3 = new List<Drugs>();
            Drugs drugData10 = new Drugs();
            drugData10.Drug_name = "Bevacizumab 1,25mg";
            drugDataL3.Add(drugData10);
            Drugs drugData11 = new Drugs();
            drugData11.Drug_name = "Bevacizumab 1,5mg";
            drugDataL3.Add(drugData11);
            GPOSesData15.DrugsForGPOS = drugDataL3;

            List<Diagnosis> diagnosisDataL15 = new List<Diagnosis>();
            Diagnosis diagnosisData15 = new Diagnosis();
            diagnosisData15.DiagnoseCode = "all";
            diagnosisDataL15.Add(diagnosisData15);

            GPOSesData15.DiagnosisForGPOS = diagnosisDataL15;
            GPOSesDataL.Add(GPOSesData15);
            ////Fifteenth GPOS added 

            GPOS_Model GPOSesData16 = new GPOS_Model();
            GPOSesData16.GPOSTitle = "Wartezeitenmanagement";
            GPOSesData16.BillingCode = "36620057";
            GPOSesData16.Case_Type = "Case Type";
            GPOSesData16.Case_Type_Value = "OP";
            GPOSesData16.From_inj = "From injection no.";
            GPOSesData16.From_inj_No = int.MaxValue;
            GPOSesData16.To_inj = "To injection no.";
            GPOSesData16.To_inj_No = int.MaxValue;
            GPOSesData16.Waive_with_Order = "Waive with order";
            GPOSesData16.Waive_with_Order_value = false;
            GPOSesData16.Service_fee_in_Eur = "Service Fee in EUR";
            GPOSesData16.Service_fee_in_Eur_Value = "-";
            GPOSesData16.Fee_in_EUR = 25;
            List<Drugs> drugDataL16 = new List<Drugs>();
            Drugs drugData16 = new Drugs();
            drugData16.Drug_name = "all";

            drugDataL16.Add(drugData16);
            GPOSesData16.DrugsForGPOS = drugDataL16;

            List<Diagnosis> diagnosisDataL16 = new List<Diagnosis>();
            Diagnosis diagnosisData16 = new Diagnosis();
            diagnosisData16.DiagnoseCode = "all";
            diagnosisDataL16.Add(diagnosisData16);

            GPOSesData16.DiagnosisForGPOS = diagnosisDataL16;
            GPOSesDataL.Add(GPOSesData16);
            //Sixteenth GPOS added

            Add_GPOSes_to_ContractTables(GPOSesDataL, Connection, Transaction, securityTicket);

        }
        public static void Add_GPOSes_to_ContractTables(List<GPOS_Model> parameter, DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {

            var accountforTenant = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
            {
                IsDeleted = false,
                USR_AccountID = securityTicket.AccountID,
                Tenant_RefID = securityTicket.TenantID

            }).Single();

            var businessParticipantForTenant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                CMN_BPT_BusinessParticipantID = accountforTenant.BusinessParticipant_RefID
            }).Single();

            var searchContractParties = ORM_CMN_CTR_Contract_Party.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Party.Query()
            {

                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                Undersigning_BusinessParticipant_RefID = businessParticipantForTenant.CMN_BPT_BusinessParticipantID

            }).ToList();
            Guid contractID = Guid.NewGuid();


            var catalog1 = new ORM_HEC_BIL_PotentialCode_Catalog();
            catalog1.IsDeleted = false;
            catalog1.Tenant_RefID = securityTicket.TenantID;
            catalog1.HEC_BIL_PotentialCode_CatalogID = Guid.NewGuid();
            catalog1.GlobalPropertyMatchingID = "mm.docconnect.gpos.catalog.operation";
            catalog1.Creation_Timestamp = DateTime.Now;
            catalog1.Save(Connection, Transaction);


            var catalog2 = new ORM_HEC_BIL_PotentialCode_Catalog();
            catalog2.IsDeleted = false;
            catalog2.Tenant_RefID = securityTicket.TenantID;
            catalog2.HEC_BIL_PotentialCode_CatalogID = Guid.NewGuid();
            catalog2.GlobalPropertyMatchingID = "mm.docconnect.gpos.catalog.nachsorge";
            catalog2.Creation_Timestamp = DateTime.Now;
            catalog2.Save(Connection, Transaction);

            var catalog3 = new ORM_HEC_BIL_PotentialCode_Catalog();
            catalog3.IsDeleted = false;
            catalog3.Tenant_RefID = securityTicket.TenantID;
            catalog3.HEC_BIL_PotentialCode_CatalogID = Guid.NewGuid();
            catalog3.GlobalPropertyMatchingID = "mm.docconnect.gpos.catalog.zusatzposition.bevacizumab";
            catalog3.Creation_Timestamp = DateTime.Now;
            catalog3.Save(Connection, Transaction);

            var catalog4 = new ORM_HEC_BIL_PotentialCode_Catalog();
            catalog4.IsDeleted = false;
            catalog4.Tenant_RefID = securityTicket.TenantID;
            catalog4.HEC_BIL_PotentialCode_CatalogID = Guid.NewGuid();
            catalog4.GlobalPropertyMatchingID = "mm.docconnect.gpos.catalog.wartezeitenmanagement";
            catalog4.Creation_Timestamp = DateTime.Now;
            catalog4.Save(Connection, Transaction);

            foreach (var partie in searchContractParties)
            {
                var searchContract = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query()
              {
                  IsDeleted = false,
                  Tenant_RefID = securityTicket.TenantID,
                  CMN_CTR_ContractID = partie.Contract_RefID,
                  ContractName = "IVI-Vertrag",
              }).SingleOrDefault();
                if (searchContract != null)
                {
                    contractID = searchContract.CMN_CTR_ContractID;
                }

            }


            var hecContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                Ext_CMN_CTR_Contract_RefID = contractID

            }).Single();

            foreach (var GPOSData in parameter)
            {


                var contract2BillCodes = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCode();
                contract2BillCodes.IsDeleted = false;
                contract2BillCodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID = Guid.NewGuid();
                contract2BillCodes.Tenant_RefID = securityTicket.TenantID;
                contract2BillCodes.InsuranceToBrokerContract_RefID = hecContract.HEC_CRT_InsuranceToBrokerContractID;
                contract2BillCodes.PotentialBillCode_RefID = Guid.NewGuid();
                contract2BillCodes.Creation_Timestamp = DateTime.Now;
                contract2BillCodes.Modification_Timestamp = DateTime.Now;
                contract2BillCodes.Save(Connection, Transaction);

                var DBLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result.ToList();
                Dict PotentialCodeName = new Dict(ORM_HEC_BIL_PotentialCode.TableName);
                for (int i = 0; i < DBLanguages.Count; i++)
                {
                    PotentialCodeName.AddEntry(DBLanguages[i].CMN_LanguageID, GPOSData.GPOSTitle);
                }

                Guid billCatalogID = Guid.NewGuid();
                switch (GPOSData.GPOSTitle)
                {

                    case "Operation":
                        billCatalogID = catalog1.HEC_BIL_PotentialCode_CatalogID;
                        break;
                    case "Nachsorge":
                        billCatalogID = catalog2.HEC_BIL_PotentialCode_CatalogID;
                        break;
                    case "Zusatzposition Bevacizumab":
                        billCatalogID = catalog3.HEC_BIL_PotentialCode_CatalogID;
                        break;
                    case "Wartezeitenmanagement":
                        billCatalogID = catalog4.HEC_BIL_PotentialCode_CatalogID;
                        break;
                };


                var potentialBillCode = new ORM_HEC_BIL_PotentialCode();
                potentialBillCode.IsDeleted = false;
                potentialBillCode.Tenant_RefID = securityTicket.TenantID;
                potentialBillCode.HEC_BIL_PotentialCodeID = contract2BillCodes.PotentialBillCode_RefID;
                potentialBillCode.Creation_Timestamp = DateTime.Now;
                potentialBillCode.Modification_Timestamp = DateTime.Now;
                potentialBillCode.CodeName = PotentialCodeName;
                potentialBillCode.BillingCode = GPOSData.BillingCode;
                potentialBillCode.Price_RefID = Guid.NewGuid();
                potentialBillCode.PotentialCode_Catalog_RefID = billCatalogID;
                potentialBillCode.Save(Connection, Transaction);


                var hecBillCodes2UniversalProperty = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_2_UniversalProperty();
                hecBillCodes2UniversalProperty.IsDeleted = false;
                hecBillCodes2UniversalProperty.Tenant_RefID = securityTicket.TenantID;
                hecBillCodes2UniversalProperty.Creation_Timestamp = DateTime.Now;
                hecBillCodes2UniversalProperty.Modification_Timestamp = DateTime.Now;
                hecBillCodes2UniversalProperty.AssignmentID = Guid.NewGuid();
                hecBillCodes2UniversalProperty.CoveredPotentialBillCode_RefID = contract2BillCodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID;
                hecBillCodes2UniversalProperty.CoveredPotentialBillCode_UniversalProperty_RefID = Guid.NewGuid();
                hecBillCodes2UniversalProperty.Value_String = GPOSData.Case_Type;
                hecBillCodes2UniversalProperty.Save(Connection, Transaction);

                var billCodesUniversalProperty = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalProperty();
                billCodesUniversalProperty.IsDeleted = false;
                billCodesUniversalProperty.Tenant_RefID = securityTicket.TenantID;
                billCodesUniversalProperty.Creation_Timestamp = DateTime.Now;
                billCodesUniversalProperty.Modification_Timestamp = DateTime.Now;
                billCodesUniversalProperty.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID = hecBillCodes2UniversalProperty.CoveredPotentialBillCode_RefID;
                billCodesUniversalProperty.PropertyName = GPOSData.Case_Type_Value;
                billCodesUniversalProperty.IsValue_Number = true;
                billCodesUniversalProperty.Save(Connection, Transaction);


                var hecBillCodes2UniversalProperty2 = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_2_UniversalProperty();
                hecBillCodes2UniversalProperty2.IsDeleted = false;
                hecBillCodes2UniversalProperty2.Tenant_RefID = securityTicket.TenantID;
                hecBillCodes2UniversalProperty2.Creation_Timestamp = DateTime.Now;
                hecBillCodes2UniversalProperty2.CoveredPotentialBillCode_RefID = contract2BillCodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID;
                hecBillCodes2UniversalProperty2.CoveredPotentialBillCode_UniversalProperty_RefID = Guid.NewGuid();
                hecBillCodes2UniversalProperty2.Value_Number = GPOSData.From_inj_No;
                hecBillCodes2UniversalProperty2.Save(Connection, Transaction);

                var billCodesUniversalProperty2 = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalProperty();
                billCodesUniversalProperty2.IsDeleted = false;
                billCodesUniversalProperty2.Tenant_RefID = securityTicket.TenantID;
                billCodesUniversalProperty2.Creation_Timestamp = DateTime.Now;
                billCodesUniversalProperty2.Modification_Timestamp = DateTime.Now;
                billCodesUniversalProperty2.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID = hecBillCodes2UniversalProperty2.CoveredPotentialBillCode_UniversalProperty_RefID;
                billCodesUniversalProperty2.PropertyName = GPOSData.From_inj;
                billCodesUniversalProperty2.IsValue_Number = true;
                billCodesUniversalProperty2.Save(Connection, Transaction);

                var hecBillCodes2UniversalProperty3 = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_2_UniversalProperty();
                hecBillCodes2UniversalProperty3.IsDeleted = false;
                hecBillCodes2UniversalProperty3.Tenant_RefID = securityTicket.TenantID;
                hecBillCodes2UniversalProperty3.Creation_Timestamp = DateTime.Now;
                hecBillCodes2UniversalProperty3.CoveredPotentialBillCode_RefID = contract2BillCodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID;
                hecBillCodes2UniversalProperty3.CoveredPotentialBillCode_UniversalProperty_RefID = Guid.NewGuid();
                hecBillCodes2UniversalProperty3.Value_Number = GPOSData.To_inj_No;
                hecBillCodes2UniversalProperty3.Save(Connection, Transaction);

                var billCodesUniversalProperty3 = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalProperty();
                billCodesUniversalProperty3.IsDeleted = false;
                billCodesUniversalProperty3.Tenant_RefID = securityTicket.TenantID;
                billCodesUniversalProperty3.Creation_Timestamp = DateTime.Now;
                billCodesUniversalProperty3.Modification_Timestamp = DateTime.Now;
                billCodesUniversalProperty3.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID = hecBillCodes2UniversalProperty3.CoveredPotentialBillCode_UniversalProperty_RefID;
                billCodesUniversalProperty3.PropertyName = GPOSData.To_inj;
                billCodesUniversalProperty3.IsValue_String = true;
                billCodesUniversalProperty3.Save(Connection, Transaction);

                var hecBillCodes2UniversalProperty4 = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_2_UniversalProperty();
                hecBillCodes2UniversalProperty4.IsDeleted = false;
                hecBillCodes2UniversalProperty4.Tenant_RefID = securityTicket.TenantID;
                hecBillCodes2UniversalProperty4.Creation_Timestamp = DateTime.Now;
                hecBillCodes2UniversalProperty4.CoveredPotentialBillCode_RefID = contract2BillCodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID;
                hecBillCodes2UniversalProperty4.CoveredPotentialBillCode_UniversalProperty_RefID = Guid.NewGuid();
                hecBillCodes2UniversalProperty4.Value_Boolean = GPOSData.Waive_with_Order_value;
                hecBillCodes2UniversalProperty4.Save(Connection, Transaction);

                var billCodesUniversalProperty4 = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalProperty();
                billCodesUniversalProperty4.IsDeleted = false;
                billCodesUniversalProperty4.Tenant_RefID = securityTicket.TenantID;
                billCodesUniversalProperty4.Creation_Timestamp = DateTime.Now;
                billCodesUniversalProperty4.Modification_Timestamp = DateTime.Now;
                billCodesUniversalProperty4.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID = hecBillCodes2UniversalProperty4.CoveredPotentialBillCode_UniversalProperty_RefID;
                billCodesUniversalProperty4.PropertyName = GPOSData.Waive_with_Order;
                billCodesUniversalProperty4.IsValue_Boolean = true;
                billCodesUniversalProperty4.Save(Connection, Transaction);



                var hecBillCodes2UniversalProperty5 = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_2_UniversalProperty();
                hecBillCodes2UniversalProperty5.IsDeleted = false;
                hecBillCodes2UniversalProperty5.Tenant_RefID = securityTicket.TenantID;
                hecBillCodes2UniversalProperty5.Creation_Timestamp = DateTime.Now;
                hecBillCodes2UniversalProperty5.CoveredPotentialBillCode_RefID = contract2BillCodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID;
                hecBillCodes2UniversalProperty5.CoveredPotentialBillCode_UniversalProperty_RefID = Guid.NewGuid();
                hecBillCodes2UniversalProperty5.Value_String = GPOSData.Service_fee_in_Eur_Value;
                hecBillCodes2UniversalProperty5.Save(Connection, Transaction);

                var billCodesUniversalProperty5 = new ORM_HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalProperty();
                billCodesUniversalProperty5.IsDeleted = false;
                billCodesUniversalProperty5.Tenant_RefID = securityTicket.TenantID;
                billCodesUniversalProperty5.Creation_Timestamp = DateTime.Now;
                billCodesUniversalProperty5.Modification_Timestamp = DateTime.Now;
                billCodesUniversalProperty5.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID = hecBillCodes2UniversalProperty5.CoveredPotentialBillCode_UniversalProperty_RefID;
                billCodesUniversalProperty5.PropertyName = GPOSData.Service_fee_in_Eur;
                billCodesUniversalProperty5.IsValue_String = true;
                billCodesUniversalProperty5.Save(Connection, Transaction);



                var currencyforTenant = ORM_CMN_Currency.Query.Search(Connection, Transaction, new ORM_CMN_Currency.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID

                }).First();

                var price = new ORM_CMN_Price();
                price.CMN_PriceID = potentialBillCode.Price_RefID;
                price.IsDeleted = false;
                price.Tenant_RefID = securityTicket.TenantID;
                price.Creation_Timestamp = DateTime.Now;
                price.Save(Connection, Transaction);

                var priceValue = new ORM_CMN_Price_Value();
                priceValue.CMN_Price_ValueID = Guid.NewGuid();
                priceValue.IsDeleted = false;
                priceValue.Tenant_RefID = securityTicket.TenantID;
                priceValue.Price_RefID = price.CMN_PriceID;
                priceValue.PriceValue_Amount = GPOSData.Fee_in_EUR;
                priceValue.PriceValue_Currency_RefID = currencyforTenant.CMN_CurrencyID;
                priceValue.Save(Connection, Transaction);


                var hecContract2Diagnosis = ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialDiagnosis.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    InsuranceToBrokerContract_RefID = hecContract.HEC_CRT_InsuranceToBrokerContractID

                }).ToList();
                List<ORM_HEC_DIA_PotentialDiagnosis> potendialDiagnosisList = new List<ORM_HEC_DIA_PotentialDiagnosis>();
                foreach (var ctr2dia in hecContract2Diagnosis)
                {
                    var potentialDiagnosis = ORM_HEC_DIA_PotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_DIA_PotentialDiagnosis.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        HEC_DIA_PotentialDiagnosisID = ctr2dia.PotentialDiagnosis_RefID
                    }).SingleOrDefault();
                    potendialDiagnosisList.Add(potentialDiagnosis);
                }

                foreach (var diagnosispot in potendialDiagnosisList)
                {
                    foreach (var diagnosisData in GPOSData.DiagnosisForGPOS)
                    {
                        var CatalogCodes = ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query.Search(Connection, Transaction, new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query()
                           {
                               IsDeleted = false,
                               Tenant_RefID = securityTicket.TenantID,
                               PotentialDiagnosis_RefID = diagnosispot.HEC_DIA_PotentialDiagnosisID
                           }).SingleOrDefault();
                        if (CatalogCodes.Code != null)
                            if (CatalogCodes.Code == diagnosisData.DiagnoseCode || diagnosisData.DiagnoseCode == "all")
                            {
                                var BillCode2PotentialDiagnosis = new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis();
                                BillCode2PotentialDiagnosis.HEC_BIL_PotentialCode_RefID = potentialBillCode.HEC_BIL_PotentialCodeID;
                                BillCode2PotentialDiagnosis.HEC_DIA_PotentialDiagnosis_RefID = diagnosispot.HEC_DIA_PotentialDiagnosisID;
                                BillCode2PotentialDiagnosis.IsDeleted = false;
                                BillCode2PotentialDiagnosis.Tenant_RefID = securityTicket.TenantID;
                                BillCode2PotentialDiagnosis.Creation_Timestamp = DateTime.Now;
                                BillCode2PotentialDiagnosis.Modification_Timestamp = DateTime.Now;
                                BillCode2PotentialDiagnosis.Save(Connection, Transaction);
                            }
                    }
                }

                var hecContract2Products = ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    InsuranceToBrokerContract_RefID = hecContract.HEC_CRT_InsuranceToBrokerContractID
                }).ToList();

                List<ORM_HEC_Product> HecProductList = new List<ORM_HEC_Product>();
                foreach (var cont2product in hecContract2Products)
                {
                    var searchProducts = ORM_HEC_Product.Query.Search(Connection, Transaction, new ORM_HEC_Product.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        HEC_ProductID = cont2product.HealthcareProduct_RefID

                    }).SingleOrDefault();
                    if (searchProducts != null)
                    {
                        HecProductList.Add(searchProducts);
                    }

                }

                List<ORM_CMN_PRO_Product> drugList = new List<ORM_CMN_PRO_Product>();
                foreach (var hecProd in HecProductList)
                {
                    var searchProd = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_PRO_ProductID = hecProd.Ext_PRO_Product_RefID

                    }).SingleOrDefault();
                    if (searchProd != null)
                    {
                        drugList.Add(searchProd);
                    }

                }



                if (GPOSData.DrugsForGPOS != null)
                {
                    foreach (var drugsData in GPOSData.DrugsForGPOS)
                    {

                        foreach (var drug in HecProductList)
                        {


                            Dict ProductNameDict = new Dict(ORM_CMN_PRO_Product.TableName);
                            for (int i = 0; i < DBLanguages.Count; i++)
                            {
                                ProductNameDict.AddEntry(DBLanguages[i].CMN_LanguageID, drugsData.Drug_name);
                            }

                            var searchProd = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                CMN_PRO_ProductID = drug.Ext_PRO_Product_RefID

                            }).SingleOrDefault();

                            if (searchProd.Product_Name.Contents[0].Content == ProductNameDict.Contents[0].Content || drugsData.Drug_name == "all")
                            {

                                var billCode2product = new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct();
                                billCode2product.IsDeleted = false;
                                billCode2product.Tenant_RefID = securityTicket.TenantID;
                                billCode2product.Creation_Timestamp = DateTime.Now;
                                billCode2product.AssignmentID = Guid.NewGuid();
                                billCode2product.HEC_BIL_PotentialCode_RefID = potentialBillCode.HEC_BIL_PotentialCodeID;
                                billCode2product.HEC_Product_RefID = drug.HEC_ProductID;
                                billCode2product.Save(Connection, Transaction);

                            }

                        }

                    }
                }

                else
                {

                    Console.WriteLine(GPOSData);
                }
            }

        }

    }
}
