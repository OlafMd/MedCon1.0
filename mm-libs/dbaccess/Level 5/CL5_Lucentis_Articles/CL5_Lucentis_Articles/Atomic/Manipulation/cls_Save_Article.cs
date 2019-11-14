/* 
 * Generated on 8/30/2013 12:50:06 PM
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
using CL3_MedicalProducts.Atomic.Manipulation;
using CL1_HEC;


namespace CL5_Lucentis_Articles.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Article.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Article
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5LA_SA_1249 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();


            if (Parameter.IsDeleted == true)
            {

                P_L3MP_DP_1145 param = new P_L3MP_DP_1145();
                param.CMN_PRO_ProductID = Parameter.CMN_PRO_ProductID;

                cls_Delete_Product.Invoke(Connection, Transaction, param,securityTicket);
            }

            else
            {
                P_L3MP_SP_1045 par = new P_L3MP_SP_1045();

                par.CMN_PRO_ProductID = Parameter.CMN_PRO_ProductID;
                par.IsDeleted = Parameter.IsDeleted;
                par.Product_Description = Parameter.Product_Description;
                par.Product_Name_DictID = Parameter.Product_Name_DictID;
                par.Product_Number = Parameter.Product_Number;


                if (Parameter.CMN_PRO_ProductID != Guid.Empty && Parameter.CMN_PRO_ProductID != null)
                {
                    #region Edit


                    Guid Ext_PRO_Product_RefID = cls_Save_Product.Invoke(Connection, Transaction, par, securityTicket).Result;


                    var hecProductQuery2 = new ORM_HEC_Product.Query();
                    hecProductQuery2.Ext_PRO_Product_RefID = Parameter.CMN_PRO_ProductID;
                    hecProductQuery2.IsDeleted = false;

                    var medProduct2 = ORM_HEC_Product.Query.Search(Connection, Transaction, hecProductQuery2).FirstOrDefault();

                    if (medProduct2 != null)
                    {
                        medProduct2.Recepie = Parameter.Recepie;
                        medProduct2.Save(Connection, Transaction);
                    }  
                    else
                    {
                        ORM_HEC_Product hecProductNew = new ORM_HEC_Product();

                        hecProductNew.Creation_Timestamp = DateTime.Now;
                        hecProductNew.HEC_ProductID = Guid.NewGuid();
                        hecProductNew.IsDeleted = false;
                        hecProductNew.Ext_PRO_Product_RefID = Ext_PRO_Product_RefID;
                        hecProductNew.Recepie = Parameter.Recepie;
                        hecProductNew.Tenant_RefID = securityTicket.TenantID;

                        hecProductNew.Save(Connection, Transaction);
                    }

                    #endregion
                }
                else
                {
                    #region Save

                    Guid Ext_PRO_Product_RefID = cls_Save_Product.Invoke(Connection, Transaction, par, securityTicket).Result;

                    ORM_HEC_Product hec_Product = new ORM_HEC_Product();

                    hec_Product.Creation_Timestamp = DateTime.Now;
                    hec_Product.HEC_ProductID = Guid.NewGuid();
                    hec_Product.IsDeleted = false;
                    hec_Product.Ext_PRO_Product_RefID = Ext_PRO_Product_RefID;
                    hec_Product.Recepie = Parameter.Recepie;
                    hec_Product.Tenant_RefID = securityTicket.TenantID;

                    hec_Product.Save(Connection, Transaction);

                    returnValue.Result = Ext_PRO_Product_RefID;
                    #endregion
                }
            }

            

            

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5LA_SA_1249 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5LA_SA_1249 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5LA_SA_1249 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5LA_SA_1249 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Article",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5LA_SA_1249 for attribute P_L5LA_SA_1249
		[DataContract]
		public class P_L5LA_SA_1249 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name_DictID { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public String Recepie { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Article(,P_L5LA_SA_1249 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Article.Invoke(connectionString,P_L5LA_SA_1249 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Articles.Atomic.Manipulation.P_L5LA_SA_1249();
parameter.CMN_PRO_ProductID = ...;
parameter.Product_Name_DictID = ...;
parameter.Product_Number = ...;
parameter.Product_Description = ...;
parameter.IsDeleted = ...;
parameter.Recepie = ...;

*/
