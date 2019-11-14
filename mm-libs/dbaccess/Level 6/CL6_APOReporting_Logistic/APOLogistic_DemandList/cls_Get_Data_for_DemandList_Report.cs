/* 
 * Generated on 5/13/2014 10:04:38 AM
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
using CL3_Account.Atomic.Retrieval;
using CL3_Articles.Atomic.Retrieval;
using CL2_Language.Atomic.Retrieval;

namespace CL6_APOReporting_Logistic.APOLogistic_DemandList
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_Data_for_DemandList_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_Data_for_DemandList_Report
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L6LG_GDfDLR_1634 Execute(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L6LG_GDfDLR_1634();
            returnValue.Result = new L6LG_GDfDLR_1634();

            var languages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, new P_L2LN_GALFTID_1530() { Tenant_RefID = securityTicket.TenantID }, securityTicket).Result;


            var account = cls_Get_DisplayName_of_Account.Invoke(Connection, Transaction, securityTicket).Result;

            List<L6LG_GDfDLR_1634a> returnList = new List<L6LG_GDfDLR_1634a>();
            var produtDemandAndSupplyQuantityList = cls_Get_Product_Demand_and_Supply_Quantity.Invoke(Connection, Transaction, securityTicket).Result;
            List<Guid> productIdList = produtDemandAndSupplyQuantityList.Select(p => p.ProductID).Distinct().ToList();

            L3AR_GAfAL_0942[] articlesForArticleList = new L3AR_GAfAL_0942[0];
            if (productIdList != null && productIdList.Count > 0)
            {
                P_L3AR_GAfAL_0942 articlesForArticleListParameter = new P_L3AR_GAfAL_0942();
                articlesForArticleListParameter.ProductID_List = productIdList.ToArray();
                FR_L3AR_GAfAL_0942_Array articlesForArticleListResult = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, articlesForArticleListParameter, securityTicket);
                articlesForArticleList = articlesForArticleListResult.Result;
            }


            foreach (L6LG_GPDaSQ_1636 productDemandAndSupplyQuantity in produtDemandAndSupplyQuantityList)
            {

                L3AR_GAfAL_0942 article = articlesForArticleList.FirstOrDefault(a => a.CMN_PRO_ProductID == productDemandAndSupplyQuantity.ProductID);

                if (article == null)
                {
                    continue;
                }


                L6LG_GDfDLR_1634a product = new L6LG_GDfDLR_1634a();
                product.ProductID = article.CMN_PRO_ProductID;
                product.DossageFormName = article.DossageFormName;
                product.ProducerName = article.ProducerName;
                product.Product_Name = new Dictionary<string, string>();

                foreach (L2LN_GALFTID_1530 lang in languages)
                {
                    string iso = lang.ISO_639_1;
                    string content = "";
                    if (article.Product_Name != null && article.Product_Name.Contents != null)
                    {
                        DictEntry dicEntry = article.Product_Name.Contents.FirstOrDefault(c => c.LanguageID == lang.CMN_LanguageID);
                        if (dicEntry != null)
                        {
                            content = dicEntry.Content;
                        }
                    }
                    product.Product_Name.Add(iso, content);
                }

                product.Product_Number = article.Product_Number;
                product.UnitAmount = article.UnitAmount;
                product.UnitIsoCode = article.UnitIsoCode;
                product.DemandQuantity = productDemandAndSupplyQuantity.DemandQuantity;
                product.SupplyQuantity = productDemandAndSupplyQuantity.SupplyQuantity;
                product.ToBeOrderedQuantity = productDemandAndSupplyQuantity.DemandQuantity - productDemandAndSupplyQuantity.SupplyQuantity;
                returnList.Add(product);

            }

            returnValue.Result.Products = returnList.ToArray();
            returnValue.Result.Account = account;

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L6LG_GDfDLR_1634 Invoke(string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L6LG_GDfDLR_1634 Invoke(DbConnection Connection, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L6LG_GDfDLR_1634 Invoke(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L6LG_GDfDLR_1634 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L6LG_GDfDLR_1634 functionReturn = new FR_L6LG_GDfDLR_1634();
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

                functionReturn = Execute(Connection, Transaction, securityTicket);

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

                throw new Exception("Exception occured in method cls_Get_Data_for_DemandList_Report", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L6LG_GDfDLR_1634 : FR_Base
    {
        public L6LG_GDfDLR_1634 Result { get; set; }

        public FR_L6LG_GDfDLR_1634() : base() { }

        public FR_L6LG_GDfDLR_1634(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass L6LG_GDfDLR_1634 for attribute L6LG_GDfDLR_1634
    [DataContract]
    public class L6LG_GDfDLR_1634
    {
        [DataMember]
        public L6LG_GDfDLR_1634a[] Products { get; set; }

        //Standard type parameters
        [DataMember]
        public CL3_Account.Atomic.Retrieval.CL2_AC_GDNoA_0952 Account { get; set; }

    }
    #endregion
    #region SClass L6LG_GDfDLR_1634a for attribute Products
    [DataContract]
    public class L6LG_GDfDLR_1634a
    {
        //Standard type parameters
        [DataMember]
        public Guid ProductID { get; set; }
        [DataMember]
        public Dictionary<String, String> Product_Name { get; set; }
        [DataMember]
        public String Product_Number { get; set; }
        [DataMember]
        public double UnitAmount { get; set; }
        [DataMember]
        public String UnitIsoCode { get; set; }
        [DataMember]
        public string DossageFormName { get; set; }
        [DataMember]
        public string ProducerName { get; set; }
        [DataMember]
        public double DemandQuantity { get; set; }
        [DataMember]
        public double SupplyQuantity { get; set; }
        [DataMember]
        public double ToBeOrderedQuantity { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6LG_GDfDLR_1634 cls_Get_Data_for_DemandList_Report(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6LG_GDfDLR_1634 invocationResult = cls_Get_Data_for_DemandList_Report.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

