/* 
 * Generated on 12/16/2013 9:30:56 AM
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
using CL1_CMN_BPT_CTM;
using CL1_USR;
using Realm.APODemand;
using DLCore_MessageListener.SettingsReader;
using CL1_CMN_PRO;

namespace CL5_APOAdmin_Catalogs.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_AnswerCatalogExtensionRequest.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_AnswerCatalogExtensionRequest
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_ACER_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_CMN_BPT_CTM_CatalogProductExtensionRequests request = new ORM_CMN_BPT_CTM_CatalogProductExtensionRequests();
            var fetched = request.Load(Connection, Transaction, Parameter.RequestID);
            if (fetched.Status != FR_Status.Success || request.CMN_BPT_CTM_CatalogProductExtensionRequestID == Parameter.RequestID)
            {
                var error = new FR_Guid();
                error.ErrorMessage = "No Such ID";
                error.Status = FR_Status.Error_Internal;
                return error;
            }

            ORM_USR_Account account = new ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);

            request.IsAnswerSent = true;
            request.IfAnswerSent_By_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
            request.IfAnswerSent_Date = DateTime.Now;
            request.Request_Answer = Parameter.RequestAnswer;
            request.Save(Connection, Transaction);

            ArticleRequestAnswerCreation answer = new ArticleRequestAnswerCreation();
            answer.IntendedFor_TenantID = DBCrossTenantReader.Instance.GetPracticeTenantID();
            answer.CreatedBy_TenantID = securityTicket.TenantID;
            answer.ArticleRequestITL = Guid.Parse(request.CatalogProductExtensionRequestITL);

            #region Add products
            ORM_CMN_BPT_CTM_CatalogProductExtensionRequest_Product product = null;

            if (Parameter.Products != null)
            {
                foreach (P_L5CA_ACER_1055a item in Parameter.Products)
                {
                    product = new ORM_CMN_BPT_CTM_CatalogProductExtensionRequest_Product();
                    product.CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID = Guid.NewGuid();
                    product.CMN_PRO_Product_RefID = item.ProductID;
                    product.Creation_Timestamp = DateTime.Now;
                    product.Tenant_RefID = securityTicket.TenantID;
                    product.CatalogProductExtensionRequest_RefID = request.CMN_BPT_CTM_CatalogProductExtensionRequestID;
                    product.Comment = "";
                    product.Save(Connection, Transaction);
               
                    var cmnProProduct = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction,
                    new ORM_CMN_PRO_Product.Query()
                    {
                        CMN_PRO_ProductID = item.ProductID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    Product prod = new Product();
                    prod.Product_ITL = cmnProProduct.ProductITL;
                    answer.Products.Add(prod);
                }
            }
            #endregion

            returnValue.Result = request.CMN_BPT_CTM_CatalogProductExtensionRequestID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CA_ACER_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CA_ACER_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_ACER_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_ACER_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

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
					if (cleanupTransaction == true && Transaction!=null)
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

				throw new Exception("Exception occured in method cls_AnswerCatalogExtensionRequest",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CA_ACER_1055 for attribute P_L5CA_ACER_1055
		[DataContract]
		public class P_L5CA_ACER_1055 
		{
			[DataMember]
			public P_L5CA_ACER_1055a[] Products { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RequestID { get; set; } 
			[DataMember]
			public String RequestAnswer { get; set; } 

		}
		#endregion
		#region SClass P_L5CA_ACER_1055a for attribute Products
		[DataContract]
		public class P_L5CA_ACER_1055a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_AnswerCatalogExtensionRequest(,P_L5CA_ACER_1055 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_AnswerCatalogExtensionRequest.Invoke(connectionString,P_L5CA_ACER_1055 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Catalogs.Complex.Manipulation.P_L5CA_ACER_1055();
parameter.Products = ...;

parameter.RequestID = ...;
parameter.RequestAnswer = ...;

*/
