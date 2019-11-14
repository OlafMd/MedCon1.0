/* 
 * Generated on 8/30/2013 10:50:28 AM
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
using CL2_Language.Atomic.Retrieval;
using CL1_CMN_PRO;
using CL1_HEC;

namespace CL3_MedicalProducts.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Product.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Product
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3MP_SP_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            //languages
            P_L2LN_GALFTID_1530 languageTenandID = new P_L2LN_GALFTID_1530();
            languageTenandID.Tenant_RefID = securityTicket.TenantID;
            List<L2LN_GALFTID_1530> DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, languageTenandID, securityTicket).Result.ToList();

            ORM_CMN_PRO_Product item = new ORM_CMN_PRO_Product();

            if (Parameter.CMN_PRO_ProductID != null && Parameter.CMN_PRO_ProductID != Guid.Empty)
            {


                var result = item.Load(Connection, Transaction, Parameter.CMN_PRO_ProductID);
                if (result.Status != FR_Status.Success)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }

                #region Edit

                Dict _extProductDictName = new Dict("cmn_pro_products");

                _extProductDictName = Parameter.Product_Name_DictID;

                if (_extProductDictName != null)
                {
                    foreach (var entry in _extProductDictName.Contents)
                    {
                        item.Product_Name.UpdateEntry(entry.LanguageID, entry.Content);
                    }
                }


                Dict _extProductDictDescription = new Dict("cmn_pro_products");

                _extProductDictDescription = Parameter.Product_Description;

                if (_extProductDictDescription != null)
                {
                    foreach (var entry in _extProductDictDescription.Contents)
                    {
                        item.Product_Description.UpdateEntry(entry.LanguageID, entry.Content);
                    }
                }

                item.Product_Number = Parameter.Product_Number;


                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_PRO_ProductID);

                #endregion
            }

            else
            {
                #region Save

                item.CMN_PRO_ProductID = Guid.NewGuid();
                item.Creation_Timestamp = DateTime.Now;
                item.IsDeleted = false;

                Dict _extProductDictName = new Dict("cmn_pro_products");

                _extProductDictName= Parameter.Product_Name_DictID;

                if (_extProductDictName != null)
                {
                    foreach (var entry in _extProductDictName.Contents)
                    {
                        item.Product_Name.UpdateEntry(entry.LanguageID, entry.Content);
                    }
                }


                Dict _extProductDictDescription = new Dict("cmn_pro_products");

                _extProductDictDescription = Parameter.Product_Description;

                if (_extProductDictDescription != null)
                {
                    foreach (var entry in _extProductDictDescription.Contents)
                    {
                        item.Product_Description.UpdateEntry(entry.LanguageID, entry.Content);
                    }
                }

                item.Product_Number = Parameter.Product_Number;
                item.Tenant_RefID = securityTicket.TenantID;
                item.Modification_Timestamp = DateTime.MinValue;

                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_PRO_ProductID);

               

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
		public static FR_Guid Invoke(string ConnectionString,P_L3MP_SP_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3MP_SP_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3MP_SP_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3MP_SP_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Product",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3MP_SP_1045 for attribute P_L3MP_SP_1045
		[DataContract]
		public class P_L3MP_SP_1045 
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
FR_Guid cls_Save_Product(,P_L3MP_SP_1045 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_Guid invocationResult = cls_Save_Product.Invoke(connectionString,P_L3MP_SP_1045 Parameter,securityTicket);
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
var parameter = new CL3_MedicalProducts.Atomic.Manipulation.P_L3MP_SP_1045();
parameter.CMN_PRO_ProductID = ...;
parameter.Product_Name_DictID = ...;
parameter.Product_Number = ...;
parameter.Product_Description = ...;
parameter.IsDeleted = ...;
parameter.Recepie = ...;

*/
