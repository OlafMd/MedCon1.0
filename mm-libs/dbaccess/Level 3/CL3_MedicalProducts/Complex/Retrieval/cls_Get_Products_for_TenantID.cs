/* 
 * Generated on 8/29/2013 4:15:09 PM
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
using CL1_CMN_PRO;
using CL1_HEC;


namespace CL3_MedicalProducts.Complex.Retrieval
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
		protected static FR_L3MP_GPfTID_1602_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L3MP_GPfTID_1602_Array();

            List<L2PD_GAPfTI_1541> allProducts = cls_Get_Product_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            List<L3MP_GPfTID_1602> sortedData = new List<L3MP_GPfTID_1602>();

            for (int i = 0; i < allProducts.Count; i++)
            {
                //Ovo ce se brisati#################################

                var cmn_pro_product_2_productGroupQuery = new ORM_CMN_PRO_Product_2_ProductGroup.Query();
                cmn_pro_product_2_productGroupQuery.Tenant_RefID = securityTicket.TenantID;
                cmn_pro_product_2_productGroupQuery.CMN_PRO_Product_RefID = allProducts[i].CMN_PRO_ProductID;
                cmn_pro_product_2_productGroupQuery.IsDeleted = false;

                var cmn_pro_product_2_productGroup = ORM_CMN_PRO_Product_2_ProductGroup.Query.Search(Connection, Transaction, cmn_pro_product_2_productGroupQuery).FirstOrDefault();
                //#################################

                if (cmn_pro_product_2_productGroup == null)
                {
                    L3MP_GPfTID_1602 product = new L3MP_GPfTID_1602();

                    product.CMN_PRO_ProductID = allProducts[i].CMN_PRO_ProductID;
                    product.Creation_Timestamp = allProducts[i].Creation_Timestamp;
                    product.Product_Description = allProducts[i].Product_Description;
                    product.Product_Name_DictID = allProducts[i].Product_Name_DictID;
                    product.Product_Number = allProducts[i].Product_Number;
                    product.Tenant_RefID = allProducts[i].Tenant_RefID;

                    #region Surveys

                    var surveysQuery = new ORM_CMN_PRO_Product_Questionnaire_Assignment.Query();
                    surveysQuery.CMN_PRO_Product_RefID = allProducts[i].CMN_PRO_ProductID;
                    surveysQuery.IsDeleted = false;

                    var surveyes = ORM_CMN_PRO_Product_Questionnaire_Assignment.Query.Search(Connection, Transaction, surveysQuery).ToList();

                    if (surveyes.Count != 0)
                    {
                        List<L3MP_GPfTID_1602_Surveys> listOfSurveys = new List<L3MP_GPfTID_1602_Surveys>();

                        foreach (var survey in surveyes)
                        {
                            L3MP_GPfTID_1602_Surveys surveyData = new L3MP_GPfTID_1602_Surveys();
                            surveyData.CMN_PRO_Product_Questionnaire_AssignmentID = survey.CMN_PRO_Product_Questionnaire_AssignmentID;
                            listOfSurveys.Add(surveyData);
                        }

                        product.Surveys = listOfSurveys.ToArray();
                    }

                    #endregion

                    #region Medical_ProductData

                    var medicalProductDataQuery = new ORM_HEC_Product.Query();
                    medicalProductDataQuery.Ext_PRO_Product_RefID = allProducts[i].CMN_PRO_ProductID;
                    medicalProductDataQuery.IsDeleted = false;

                    var medicalProductData = ORM_HEC_Product.Query.Search(Connection, Transaction, medicalProductDataQuery).FirstOrDefault();

                    if (medicalProductData != null)
                    {
                        L3MP_GPfTID_1602_Medical_ProductData productData = new L3MP_GPfTID_1602_Medical_ProductData();
                        productData.HEC_ProductID = medicalProductData.HEC_ProductID;
                        productData.Recepie = medicalProductData.Recepie;

                        product.Medical_ProductData = productData;
                    }

                    #endregion

                    sortedData.Add(product);

                }
                else
                {
                    continue;
                }
            }

            returnValue.Result = sortedData.ToArray();

                return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3MP_GPfTID_1602_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3MP_GPfTID_1602_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3MP_GPfTID_1602_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3MP_GPfTID_1602_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3MP_GPfTID_1602_Array functionReturn = new FR_L3MP_GPfTID_1602_Array();
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
	public class FR_L3MP_GPfTID_1602_Array : FR_Base
	{
		public L3MP_GPfTID_1602[] Result	{ get; set; } 
		public FR_L3MP_GPfTID_1602_Array() : base() {}

		public FR_L3MP_GPfTID_1602_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3MP_GPfTID_1602 for attribute L3MP_GPfTID_1602
		[DataContract]
		public class L3MP_GPfTID_1602 
		{
			[DataMember]
			public L3MP_GPfTID_1602_Surveys[] Surveys { get; set; }
			[DataMember]
			public L3MP_GPfTID_1602_Medical_ProductData Medical_ProductData { get; set; }

			//Standard type parameters
			[DataMember]
			public Dict Product_Name_DictID { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 

		}
		#endregion
		#region SClass L3MP_GPfTID_1602_Surveys for attribute Surveys
		[DataContract]
		public class L3MP_GPfTID_1602_Surveys 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_Questionnaire_AssignmentID { get; set; } 

		}
		#endregion
		#region SClass L3MP_GPfTID_1602_Medical_ProductData for attribute Medical_ProductData
		[DataContract]
		public class L3MP_GPfTID_1602_Medical_ProductData 
		{
			//Standard type parameters
			[DataMember]
			public String Recepie { get; set; } 
			[DataMember]
			public Guid HEC_ProductID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3MP_GPfTID_1602_Array cls_Get_Products_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_L3MP_GPfTID_1602_Array invocationResult = cls_Get_Products_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

