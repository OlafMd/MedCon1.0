/* 
 * Generated on 7/8/2013 11:13:23 AM
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
using CL5_Lucentis_Products.Atomic.Retrieval;
using CL6_Lucenits_Products.Atomic.Retrieval;
using CL1_CMN_PRO;

namespace CLE_L6_CMN_Products.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProductsForTreatment_and_AllAvailableProducts.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProductsForTreatment_and_AllAvailableProducts
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PD_GOPaAAP_1154 Execute(DbConnection Connection,DbTransaction Transaction,P_L6PD_GOPaAAP_1154 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6PD_GOPaAAP_1154();
            returnValue.Result = new L6PD_GOPaAAP_1154();

            var param = new P_L6PD_GPaCOSfT_1120();
            param.TreatmentID = Parameter.TreatmentID;

            returnValue.Result.ProductsForTreatment = cls_Get_Products_and_CustomerOrderStatuses_for_TreatmentID.Invoke(Connection, Transaction, param, securityTicket).Result.ToArray();


            List<L5PR_GHPfT_1018> filteredArticles = new List<L5PR_GHPfT_1018>();    
            var allArticles= cls_Get_HEC_Products_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            foreach (var item in allArticles)
            {
                //Ovo ce se brisati#################################

                var cmn_pro_product_2_productGroupQuery = new ORM_CMN_PRO_Product_2_ProductGroup.Query();
                cmn_pro_product_2_productGroupQuery.Tenant_RefID = securityTicket.TenantID;
                cmn_pro_product_2_productGroupQuery.CMN_PRO_Product_RefID = item.CMN_PRO_ProductID;
                cmn_pro_product_2_productGroupQuery.IsDeleted = false;

                var cmn_pro_product_2_productGroup = ORM_CMN_PRO_Product_2_ProductGroup.Query.Search(Connection, Transaction, cmn_pro_product_2_productGroupQuery).FirstOrDefault();
                //#################################

                if (cmn_pro_product_2_productGroup == null)
                    filteredArticles.Add(item);
                else
                    continue;
            }
            returnValue.Result.AllProducts = filteredArticles.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PD_GOPaAAP_1154 Invoke(string ConnectionString,P_L6PD_GOPaAAP_1154 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PD_GOPaAAP_1154 Invoke(DbConnection Connection,P_L6PD_GOPaAAP_1154 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PD_GOPaAAP_1154 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PD_GOPaAAP_1154 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PD_GOPaAAP_1154 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PD_GOPaAAP_1154 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PD_GOPaAAP_1154 functionReturn = new FR_L6PD_GOPaAAP_1154();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PD_GOPaAAP_1154 : FR_Base
	{
		public L6PD_GOPaAAP_1154 Result	{ get; set; }

		public FR_L6PD_GOPaAAP_1154() : base() {}

		public FR_L6PD_GOPaAAP_1154(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PD_GOPaAAP_1154 for attribute P_L6PD_GOPaAAP_1154
		[DataContract]
		public class P_L6PD_GOPaAAP_1154 
		{
			//Standard type parameters
			[DataMember]
			public Guid TreatmentID { get; set; } 

		}
		#endregion
		#region SClass L6PD_GOPaAAP_1154 for attribute L6PD_GOPaAAP_1154
		[DataContract]
		public class L6PD_GOPaAAP_1154 
		{
			//Standard type parameters
			[DataMember]
			public L5PR_GHPfT_1018[] AllProducts { get; set; } 
			[DataMember]
			public L6PD_GPaCOSfT_1120[] ProductsForTreatment { get; set; } 

		}
		#endregion

	#endregion
}
