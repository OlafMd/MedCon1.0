/* 
 * Generated on 1/9/2014 12:33:03 PM
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
using CL5_Lucentis_Catalogs.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL5_Lucentis_Catalogs.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Articles_for_ArticleGroups_Catalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Articles_for_ArticleGroups_Catalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CA_GAfAGC_1148_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_GAfAGC_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5CA_GAfAGC_1148_Array();
			//Put your code here
            String globalMatchingID = "";

            if (Parameter.IsPublicCatalog == true)
            {
                globalMatchingID = EnumUtils.GetEnumDescription(EProductGroup.ABDA) + Parameter.BusinessParticipant_RefID;
            }
            else
            {
                globalMatchingID = EnumUtils.GetEnumDescription(EProductGroup.HauseList) + Parameter.BusinessParticipant_RefID;
            }

            //var query = new ORM_CMN_PRO_ProductGroup.Query();
            //query.Tenant_RefID = securityTicket.TenantID;
            //query.GlobalPropertyMatchingID = globalMatchingID;
            //query.IsDeleted = false;

            //var productGroup = ORM_CMN_PRO_ProductGroup.Query.Search(Connection, Transaction, query).First();
            //Put your code here


            P_L5CA_GPDgPGgC_1205 param = new P_L5CA_GPDgPGgC_1205();
            param.ProductGroupMatchingID = globalMatchingID;

            var articles = cls_Get_ProductDetails_for_ProductGroupID_for_Catalogs.Invoke(Connection, Transaction, param, securityTicket).Result;

            List<L5CA_GAfAGC_1148> ArticleCatalogs = new List<L5CA_GAfAGC_1148>();

            foreach (var article in articles)
            {
                L5CA_GAfAGC_1148 catalogArticle = new L5CA_GAfAGC_1148();
                catalogArticle.CMN_PRO_ProductID = article.CMN_PRO_ProductID;
                catalogArticle.CMN_UnitID = article.CMN_UnitID;                
                catalogArticle.DosageForm_Name = article.DosageForm_Name;
                catalogArticle.HEC_Product_DosageFormID = article.HEC_Product_DosageFormID;
                catalogArticle.Label = article.Label;
                catalogArticle.Product_Name = article.Product_Name;
                catalogArticle.Product_Number = article.Product_Number;
                catalogArticle.ISOCode = article.ISOCode;
                catalogArticle.PackageContent_Amount = article.PackageContent_Amount;
                ArticleCatalogs.Add(catalogArticle);
            }


            returnValue.Result = ArticleCatalogs.ToArray();
 
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CA_GAfAGC_1148_Array Invoke(string ConnectionString,P_L5CA_GAfAGC_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CA_GAfAGC_1148_Array Invoke(DbConnection Connection,P_L5CA_GAfAGC_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CA_GAfAGC_1148_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_GAfAGC_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CA_GAfAGC_1148_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_GAfAGC_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CA_GAfAGC_1148_Array functionReturn = new FR_L5CA_GAfAGC_1148_Array();
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

				throw new Exception("Exception occured in method cls_Get_Articles_for_ArticleGroups_Catalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CA_GAfAGC_1148_Array : FR_Base
	{
		public L5CA_GAfAGC_1148[] Result	{ get; set; } 
		public FR_L5CA_GAfAGC_1148_Array() : base() {}

		public FR_L5CA_GAfAGC_1148_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CA_GAfAGC_1148 for attribute P_L5CA_GAfAGC_1148
		[DataContract]
		public class P_L5CA_GAfAGC_1148 
		{
			//Standard type parameters
			[DataMember]
			public bool IsPublicCatalog { get; set; } 
			[DataMember]
			public Guid BusinessParticipant_RefID { get; set; } 

		}
		#endregion
		#region SClass L5CA_GAfAGC_1148 for attribute L5CA_GAfAGC_1148
		[DataContract]
		public class L5CA_GAfAGC_1148 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid HEC_Product_DosageFormID { get; set; } 
			[DataMember]
			public Dict DosageForm_Name { get; set; } 
			[DataMember]
			public Guid CMN_UnitID { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public String PackageContent_Amount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CA_GAfAGC_1148_Array cls_Get_Articles_for_ArticleGroups_Catalog(,P_L5CA_GAfAGC_1148 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CA_GAfAGC_1148_Array invocationResult = cls_Get_Articles_for_ArticleGroups_Catalog.Invoke(connectionString,P_L5CA_GAfAGC_1148 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Catalogs.Complex.Retrieval.P_L5CA_GAfAGC_1148();
parameter.IsPublicCatalog = ...;
parameter.BusinessParticipant_RefID = ...;

*/
