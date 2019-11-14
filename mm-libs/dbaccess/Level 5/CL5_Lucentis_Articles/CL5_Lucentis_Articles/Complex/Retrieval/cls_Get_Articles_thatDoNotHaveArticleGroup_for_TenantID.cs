/* 
 * Generated on 12/23/2013 1:24:21 PM
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
using CL5_Lucentis_Articles.Atomic.Retrieval;
using CL1_CMN_PRO;

namespace CL5_Lucentis_Articles.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Articles_thatDoNotHaveArticleGroup_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Articles_thatDoNotHaveArticleGroup_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5LA_GADHAGfTID_1152_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5LA_GADHAGfTID_1152_Array();

            List<L5LA_GADHAGfTID_1152> productList = new List<L5LA_GADHAGfTID_1152>();
            returnValue.Result = productList.ToArray();


            var allMedicalProducts = cls_Get_Article_ForTenantID.Invoke(Connection, Transaction, securityTicket).Result.ToList();

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
                    L5LA_GADHAGfTID_1152 product = new L5LA_GADHAGfTID_1152();
                    product.CMN_PRO_ProductID = item.CMN_PRO_ProductID;
                    product.HEC_ProductID = item.HEC_ProductID;
                    product.ArticleRecipe = item.ArticleRecipe;
                    product.Product_Number = item.Product_Number;
                    product.HEC_ProductID = item.HEC_ProductID;
                    product.Creation_Timestamp = item.Creation_Timestamp;
                    product.Product_Name_DictID = item.Product_Name_DictID;

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
		public static FR_L5LA_GADHAGfTID_1152_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5LA_GADHAGfTID_1152_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5LA_GADHAGfTID_1152_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5LA_GADHAGfTID_1152_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5LA_GADHAGfTID_1152_Array functionReturn = new FR_L5LA_GADHAGfTID_1152_Array();
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

				throw new Exception("Exception occured in method cls_Get_Articles_thatDoNotHaveArticleGroup_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5LA_GADHAGfTID_1152_raw 
	{
		public String ArticleRecipe; 
		public Dict Product_Name_DictID; 
		public String Product_Number; 
		public Guid HEC_ProductID; 
		public DateTime Creation_Timestamp; 
		public Guid CMN_PRO_ProductID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5LA_GADHAGfTID_1152[] Convert(List<L5LA_GADHAGfTID_1152_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5LA_GADHAGfTID_1152 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
	group el_L5LA_GADHAGfTID_1152 by new 
	{ 
		el_L5LA_GADHAGfTID_1152.CMN_PRO_ProductID,

	}
	into gfunct_L5LA_GADHAGfTID_1152
	select new L5LA_GADHAGfTID_1152
	{     
		ArticleRecipe = gfunct_L5LA_GADHAGfTID_1152.FirstOrDefault().ArticleRecipe ,
		Product_Name_DictID = gfunct_L5LA_GADHAGfTID_1152.FirstOrDefault().Product_Name_DictID ,
		Product_Number = gfunct_L5LA_GADHAGfTID_1152.FirstOrDefault().Product_Number ,
		HEC_ProductID = gfunct_L5LA_GADHAGfTID_1152.FirstOrDefault().HEC_ProductID ,
		Creation_Timestamp = gfunct_L5LA_GADHAGfTID_1152.FirstOrDefault().Creation_Timestamp ,
		CMN_PRO_ProductID = gfunct_L5LA_GADHAGfTID_1152.Key.CMN_PRO_ProductID ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5LA_GADHAGfTID_1152_Array : FR_Base
	{
		public L5LA_GADHAGfTID_1152[] Result	{ get; set; } 
		public FR_L5LA_GADHAGfTID_1152_Array() : base() {}

		public FR_L5LA_GADHAGfTID_1152_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5LA_GADHAGfTID_1152 for attribute L5LA_GADHAGfTID_1152
		[DataContract]
		public class L5LA_GADHAGfTID_1152 
		{
			//Standard type parameters
			[DataMember]
			public String ArticleRecipe { get; set; } 
			[DataMember]
			public Dict Product_Name_DictID { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid HEC_ProductID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5LA_GADHAGfTID_1152_Array cls_Get_Articles_thatDoNotHaveArticleGroup_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5LA_GADHAGfTID_1152_Array invocationResult = cls_Get_Articles_thatDoNotHaveArticleGroup_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

