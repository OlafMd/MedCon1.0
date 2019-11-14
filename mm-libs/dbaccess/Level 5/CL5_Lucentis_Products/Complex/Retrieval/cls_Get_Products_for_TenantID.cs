/* 
 * Generated on 12/16/2013 3:40:00 PM
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
using CL1_CMN_PRO;

namespace CL5_Lucentis_Products.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Products_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Products_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5LP_GPfTID_1533_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5LP_GPfTID_1533_Array();
            List<L5LP_GPfTID_1533> productList = new List<L5LP_GPfTID_1533>();
            returnValue.Result = productList.ToArray();

            var allMedicalProducts = cls_Get_HEC_Products_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            foreach (var item in allMedicalProducts)
            {
                //Ovo ce se brisati#################################

                var cmn_pro_product_2_productGroupQuery = new ORM_CMN_PRO_Product_2_ProductGroup.Query();
                cmn_pro_product_2_productGroupQuery.Tenant_RefID = securityTicket.TenantID;
                cmn_pro_product_2_productGroupQuery.CMN_PRO_Product_RefID = item.CMN_PRO_ProductID;
                cmn_pro_product_2_productGroupQuery.IsDeleted = false;

                var cmn_pro_product_2_productGroup = ORM_CMN_PRO_Product_2_ProductGroup.Query.Search(Connection, Transaction, cmn_pro_product_2_productGroupQuery).FirstOrDefault();
                //#################################

                if (cmn_pro_product_2_productGroup == null)
                {
                    L5LP_GPfTID_1533 product = new L5LP_GPfTID_1533();
                    product.CMN_PRO_ProductID = item.CMN_PRO_ProductID;
                    product.HEC_ProductID = item.HEC_ProductID;
                    product.Product_Name = item.Product_Name;
                    product.Product_Number = item.Product_Number;
                    product.Recepie = item.Recepie;

                    productList.Add(product);
                }
                else
                    continue;
            }

            returnValue.Result = productList.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5LP_GPfTID_1533_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5LP_GPfTID_1533_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5LP_GPfTID_1533_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5LP_GPfTID_1533_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5LP_GPfTID_1533_Array functionReturn = new FR_L5LP_GPfTID_1533_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Products_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5LP_GPfTID_1533_Array : FR_Base
	{
		public L5LP_GPfTID_1533[] Result	{ get; set; } 
		public FR_L5LP_GPfTID_1533_Array() : base() {}

		public FR_L5LP_GPfTID_1533_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5LP_GPfTID_1533 for attribute L5LP_GPfTID_1533
		[DataContract]
		public class L5LP_GPfTID_1533 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid HEC_ProductID { get; set; } 
			[DataMember]
			public String Recepie { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5LP_GPfTID_1533_Array cls_Get_Products_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5LP_GPfTID_1533_Array invocationResult = cls_Get_Products_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

