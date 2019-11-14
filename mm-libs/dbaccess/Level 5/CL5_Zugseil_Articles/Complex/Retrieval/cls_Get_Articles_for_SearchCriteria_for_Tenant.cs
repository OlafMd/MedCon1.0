/* 
 * Generated on 9/24/2014 09:57:04
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
using CL5_Zugseil_Articles.Atomic.Retrieval;

namespace CL5_Zugseil_Articles.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_Articles_for_SearchCriteria_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_Articles_for_SearchCriteria_for_Tenant
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L5AR_GAfSCfT_0938 Execute(DbConnection Connection, DbTransaction Transaction, P_L5AR_GAfSCfT_0938 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L5AR_GAfSCfT_0938();

            if (Parameter.SearchCriteria != null)
            {
               
            Parameter.SearchCriteria=Parameter.SearchCriteria.Replace("%","\\%");
               Parameter.SearchCriteria = "%" + Parameter.SearchCriteria.ToUpper() + "%";
             

            }
            P_L5AR_GNoAfT_0936 numberOfArticelsParameter = new P_L5AR_GNoAfT_0936();
            numberOfArticelsParameter.LanguageID = Parameter.LanguageID;
            numberOfArticelsParameter.SearchCriteria = Parameter.SearchCriteria;

            L5AR_GNoAfT_0936 numberOfArticles = new L5AR_GNoAfT_0936();
            numberOfArticles = cls_Get_Number_of_Articles_for_Tenant.Invoke(Connection, Transaction, numberOfArticelsParameter, securityTicket).Result;

            P_L5AR_GAfT_1108 ArticleListParameter = new P_L5AR_GAfT_1108();
            ArticleListParameter.LanguageID = Parameter.LanguageID;
            ArticleListParameter.ActivePage = Parameter.ActivePage;
            ArticleListParameter.PageSize = Parameter.PageSize;
            ArticleListParameter.SearchCriteria = Parameter.SearchCriteria;
            ArticleListParameter.OrderByCriteria = Parameter.OrderByCriteria;
            if (Parameter.ActivePage != 0)
            {
                ArticleListParameter.ActivePage = Parameter.ActivePage - 1;
            }
            List<L5AR_GAfT_1108> articleList = new List<L5AR_GAfT_1108>();

            if ((numberOfArticles.NumberOfProducts - (Parameter.ActivePage + Parameter.PageSize)) > 0 || (numberOfArticles.NumberOfProducts - (Parameter.ActivePage + Parameter.PageSize)) == 0)
            {

                articleList = cls_Get_Articles_for_Tenant.Invoke(Connection, Transaction, ArticleListParameter, securityTicket).Result.ToList();
            }
            else
            {
                int itemsLeft = numberOfArticles.NumberOfProducts - Parameter.ActivePage;
                if (itemsLeft > 0)
                {
                    ArticleListParameter.PageSize = itemsLeft;
                    articleList = cls_Get_Articles_for_Tenant.Invoke(Connection, Transaction, ArticleListParameter, securityTicket).Result.ToList();
                }
                else
                {
                    articleList = null;
                }
            }

            L5AR_GAfSCfT_0938 result = new L5AR_GAfSCfT_0938();
            result.AritclesList = articleList.ToArray();
            result.NumberOfArticles = numberOfArticles;
            returnValue.Result = result;

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L5AR_GAfSCfT_0938 Invoke(string ConnectionString, P_L5AR_GAfSCfT_0938 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L5AR_GAfSCfT_0938 Invoke(DbConnection Connection, P_L5AR_GAfSCfT_0938 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L5AR_GAfSCfT_0938 Invoke(DbConnection Connection, DbTransaction Transaction, P_L5AR_GAfSCfT_0938 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L5AR_GAfSCfT_0938 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5AR_GAfSCfT_0938 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L5AR_GAfSCfT_0938 functionReturn = new FR_L5AR_GAfSCfT_0938();
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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

                throw new Exception("Exception occured in method cls_Get_Articles_for_SearchCriteria_for_Tenant", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L5AR_GAfSCfT_0938 : FR_Base
    {
        public L5AR_GAfSCfT_0938 Result { get; set; }

        public FR_L5AR_GAfSCfT_0938() : base() { }

        public FR_L5AR_GAfSCfT_0938(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_L5AR_GAfSCfT_0938 for attribute P_L5AR_GAfSCfT_0938
    [DataContract]
    public class P_L5AR_GAfSCfT_0938
    {
        //Standard type parameters
        [DataMember]
        public Guid LanguageID { get; set; }
        [DataMember]
        public int PageSize { get; set; }
        [DataMember]
        public int ActivePage { get; set; }
        [DataMember]
        public String SearchCriteria { get; set; }
        [DataMember]
        public string OrderByCriteria { get; set; }

    }
    #endregion
    #region SClass L5AR_GAfSCfT_0938 for attribute L5AR_GAfSCfT_0938
    [DataContract]
    public class L5AR_GAfSCfT_0938
    {
        //Standard type parameters
        [DataMember]
        public L5AR_GNoAfT_0936 NumberOfArticles { get; set; }
        [DataMember]
        public L5AR_GAfT_1108[] AritclesList { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_GAfSCfT_0938 cls_Get_Articles_for_SearchCriteria_for_Tenant(,P_L5AR_GAfSCfT_0938 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_GAfSCfT_0938 invocationResult = cls_Get_Articles_for_SearchCriteria_for_Tenant.Invoke(connectionString,P_L5AR_GAfSCfT_0938 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new CL5_Zugseil_Articles.Complex.Retrieval.P_L5AR_GAfSCfT_0938();
parameter.LanguageID = ...;
parameter.PageSize = ...;
parameter.ActivePage = ...;
parameter.SearchCriteria = ...;
parameter.OrderByCriteria = ...;

*/
