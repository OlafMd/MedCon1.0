/* 
 * Generated on 9/15/2014 16:50:44
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
using CL2_Products.Atomic.Retrieval;
using CL3_Product.Atomic.Retrieval;
using CL2_Unit.Atomic.Retrieval;
using CL3_Taxes.Atomic.Retrieval;
using CL1_CMN_PRO;


namespace CL5_Zugseil_Articles.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PreloadingData_for_ArticleBasicInfo.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PreloadingData_for_ArticleBasicInfo
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_GPDfABI_1633 Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_GPDfABI_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5AR_GPDfABI_1633();
            #region cls_Get_Taxes_for_CountryISOCode_and_TenantID

            var defaultCountryISOCode = CL2_Country.Atomic.Retrieval.cls_Get_DefaultCountryISOCode_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            var param = new P_L3TX_GTfCICaT_1359();
            param.CountryISOCode = defaultCountryISOCode.Country_639_1_ISOCode;

            var taxes = cls_Get_Taxes_for_CountryISOCode_and_TenantID.Invoke(Connection, Transaction, param, securityTicket).Result;
            if (taxes.Count() != 0)
            { returnValue.Result.Taxes = taxes; }

            #endregion

            #region cls_Get_all_Unit_for_Tenant

            var units = cls_Get_all_Unit_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            if(units.Count()!=0)
            returnValue.Result.Units = units;

            #endregion

          

            #region cls_Get_All_ArticleGroups_and_ArticleCount_for_TenantID

            var articleGroups = cls_Get_All_ProductGroups_and_ProductCount_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            if (Parameter.ExcludeAbdaGroup)
            {
                var list = articleGroups.ToList();

                var group = list.SingleOrDefault(x => x.GlobalPropertyMatchingID == DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EProductGroup.ABDA));
                if (group != null)
                {
                    list.Remove(group);
                    articleGroups = list.ToArray();
                }
            }
            if(articleGroups.Count()!=0)
            returnValue.Result.ArticleGroups = articleGroups;

            #endregion

            #region cls_Get_AllProductTypes_for_TenantID

            var productTypes = cls_Get_AllProductTypes_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            returnValue.Result.ProductTypes = productTypes;

            #endregion

            if (Parameter.ArticleID != Guid.Empty)
            {
               

                #region Selected_and_all_article_groups

                var groupQuery = new ORM_CMN_PRO_Product_2_ProductGroup.Query();
                groupQuery.CMN_PRO_Product_RefID = Parameter.ArticleID;
                var groupsORM = ORM_CMN_PRO_Product_2_ProductGroup.Query.Search(Connection, Transaction, groupQuery);

                List<Guid> selectedGroups = new List<Guid>();

                foreach (var group in groupsORM)
                {
                    if (group.IsDeleted == false)
                    {
                        selectedGroups.Add(group.CMN_PRO_ProductGroup_RefID);
                    }
                }
                if(selectedGroups.Count()!=0)
                returnValue.Result.SelectedArticleGroups = selectedGroups.ToArray();

                #endregion
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AR_GPDfABI_1633 Invoke(string ConnectionString,P_L5AR_GPDfABI_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_GPDfABI_1633 Invoke(DbConnection Connection,P_L5AR_GPDfABI_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_GPDfABI_1633 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_GPDfABI_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_GPDfABI_1633 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_GPDfABI_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_GPDfABI_1633 functionReturn = new FR_L5AR_GPDfABI_1633();
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

				throw new Exception("Exception occured in method cls_Get_PreloadingData_for_ArticleBasicInfo",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_GPDfABI_1633 : FR_Base
	{
		public L5AR_GPDfABI_1633 Result	{ get; set; }

		public FR_L5AR_GPDfABI_1633() : base() {}

		public FR_L5AR_GPDfABI_1633(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AR_GPDfABI_1633 for attribute P_L5AR_GPDfABI_1633
		[DataContract]
		public class P_L5AR_GPDfABI_1633 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 
			[DataMember]
			public bool ExcludeAbdaGroup { get; set; } 

		}
		#endregion
		#region SClass L5AR_GPDfABI_1633 for attribute L5AR_GPDfABI_1633
		[DataContract]
		public class L5AR_GPDfABI_1633 
		{
			//Standard type parameters
			[DataMember]
			public L3TX_GTfCICaT_1359[] Taxes { get; set; } 
			[DataMember]
			public L2UN_GAUFT_1355[] Units { get; set; } 
			[DataMember]
			public L2PD_GAPTfT_1159[] ProductTypes { get; set; } 
			[DataMember]
			public L3PR_GAPGaACfT_1330[] ArticleGroups { get; set; } 
			[DataMember]
			public Guid[] SelectedArticleGroups { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_GPDfABI_1633 cls_Get_PreloadingData_for_ArticleBasicInfo(,P_L5AR_GPDfABI_1633 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_GPDfABI_1633 invocationResult = cls_Get_PreloadingData_for_ArticleBasicInfo.Invoke(connectionString,P_L5AR_GPDfABI_1633 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Articles.Complex.Retrieval.P_L5AR_GPDfABI_1633();
parameter.ArticleID = ...;
parameter.ExcludeAbdaGroup = ...;

*/
