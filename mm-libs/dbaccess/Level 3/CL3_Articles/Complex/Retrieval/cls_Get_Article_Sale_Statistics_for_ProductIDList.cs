/* 
 * Generated on 10/10/2014 11:11:57 AM
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
using CL3_Price.Complex.Retrieval;
using CL3_APOStatistic.Complex.Retrieval;

namespace CL3_Articles.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Article_Sale_Statistics_for_ProductIDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Article_Sale_Statistics_for_ProductIDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GASS_fPIL_1533_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GASS_fPIL_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3PR_GASS_fPIL_1533_Array();

            #region Shippment Status - Shipped
            
            var shippedStatus = CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Status.Query.Search(Connection, Transaction,
                new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Status.Query
                {
                    GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EShipmentStatus.Shipped),
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

            #endregion

            #region Get shipped quantities by month/year period for year given by the parameter for the list of articles

            var sqParam = new  CL3_Articles.Atomic.Retrieval.P_L3AR_GSQbMaY_1546
            {
                ShippedStatusID = shippedStatus.LOG_SHP_Shipment_StatusID,
                ProductID_List = Parameter.ProductIDList,
                Year = Parameter.Year
            };

            var quantitiesByPeriod = CL3_Articles.Atomic.Retrieval.cls_Get_Shipped_Quantities_by_Month_and_Year.Invoke(Connection, Transaction, sqParam, securityTicket).Result;
            
            #endregion

            #region Get summed up quantities of the products in the stock

            var scqParam = new CL3_Articles.Atomic.Retrieval.P_L3AR_GCQfPIL_1013
            {
                ProductID_List = Parameter.ProductIDList
            };

            var quantitiesByProduct = CL3_Articles.Atomic.Retrieval.cls_Get_CurrentQuantity_for_ProductIDList.Invoke(Connection, Transaction, scqParam, securityTicket).Result;

            #endregion

            #region Get all articles data regardless of the found quantities

            var articleParam = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfAL_0942
            {
                ProductID_List = Parameter.ProductIDList
            };

            var articles = CL3_Articles.Atomic.Retrieval.cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, articleParam, securityTicket).Result;

            #endregion

            #region Get Companies info data (Just one for now, from the current user's account)

            var companyInfo = CL2_AccountInformation.Atomic.Retrieval.cls_Get_AccountCompanyInformation_for_AccountID.Invoke(Connection, Transaction, securityTicket).Result;
            
            /*
             * TODO: Remove this. Find out why can there be no data for this retrieval.
             */
            if (companyInfo == null)
            {
                companyInfo = new CL2_AccountInformation.Atomic.Retrieval.L2AI_GACIfAID_1455();
                companyInfo.CompanyName_Line1 = "-";
                companyInfo.BusinessParticipant_RefID = Guid.NewGuid();
            }

            #endregion

            #region Get MSR

            var msrForProducts = cls_Get_MSR_for_ProductIDList.Invoke(Connection, Transaction,
                new P_L3AS_GSMRfPL_1508 { ProductIDList = Parameter.ProductIDList }, securityTicket).Result;

            #endregion

            #region Bind all data to returning object

            var result = new List<L3PR_GASS_fPIL_1533>();

            L3PR_GASS_fPIL_1533 resultItem = null;
            foreach (var productID in Parameter.ProductIDList)
            {
                resultItem = new L3PR_GASS_fPIL_1533();
                var productMSR = msrForProducts.SingleOrDefault(x => x.ProductID == productID);



                resultItem.Article = articles.SingleOrDefault(x => x.CMN_PRO_ProductID == productID);
                resultItem.SoldByPeriod = quantitiesByPeriod.Where(x => x.ProductID == productID).ToArray();
                resultItem.ShelfContent = quantitiesByProduct.SingleOrDefault(x => x.Product_RefID == productID);
                resultItem.MSR = (productMSR != null) ? productMSR.MSR : (double)0.0;
                resultItem.CompanyInfo = new L3PR_GASS_fPIL_1533a
                    {
                        BPID = companyInfo.BusinessParticipant_RefID,
                        Name = companyInfo.CompanyName_Line1
                    };
                result.Add(resultItem);
            }

            returnValue.Result = result.ToArray();

            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PR_GASS_fPIL_1533_Array Invoke(string ConnectionString,P_L3PR_GASS_fPIL_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GASS_fPIL_1533_Array Invoke(DbConnection Connection,P_L3PR_GASS_fPIL_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GASS_fPIL_1533_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GASS_fPIL_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GASS_fPIL_1533_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GASS_fPIL_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GASS_fPIL_1533_Array functionReturn = new FR_L3PR_GASS_fPIL_1533_Array();
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

				throw new Exception("Exception occured in method cls_Get_Article_Sale_Statistics_for_ProductIDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GASS_fPIL_1533_Array : FR_Base
	{
		public L3PR_GASS_fPIL_1533[] Result	{ get; set; } 
		public FR_L3PR_GASS_fPIL_1533_Array() : base() {}

		public FR_L3PR_GASS_fPIL_1533_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GASS_fPIL_1533 for attribute P_L3PR_GASS_fPIL_1533
		[DataContract]
		public class P_L3PR_GASS_fPIL_1533 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProductIDList { get; set; } 
			[DataMember]
			public Guid[] Companies { get; set; } 
			[DataMember]
			public int Year { get; set; } 

		}
		#endregion
		#region SClass L3PR_GASS_fPIL_1533 for attribute L3PR_GASS_fPIL_1533
		[DataContract]
		public class L3PR_GASS_fPIL_1533 
		{
			[DataMember]
			public L3PR_GASS_fPIL_1533a CompanyInfo { get; set; }

			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GSQbMaY_1546[] SoldByPeriod { get; set; } 
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GCQfPIL_1013 ShelfContent { get; set; } 
			[DataMember]
			public double MSR { get; set; } 

		}
		#endregion
		#region SClass L3PR_GASS_fPIL_1533a for attribute CompanyInfo
		[DataContract]
		public class L3PR_GASS_fPIL_1533a 
		{
			//Standard type parameters
			[DataMember]
			public Guid BPID { get; set; } 
			[DataMember]
			public String Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GASS_fPIL_1533_Array cls_Get_Article_Sale_Statistics_for_ProductIDList(,P_L3PR_GASS_fPIL_1533 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GASS_fPIL_1533_Array invocationResult = cls_Get_Article_Sale_Statistics_for_ProductIDList.Invoke(connectionString,P_L3PR_GASS_fPIL_1533 Parameter,securityTicket);
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
var parameter = new CL3_Articles.Complex.Retrieval.P_L3PR_GASS_fPIL_1533();
parameter.ProductIDList = ...;
parameter.Companies = ...;
parameter.Year = ...;

*/
