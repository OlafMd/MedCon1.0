/* 
 * Generated on 10/20/2014 12:00:14 PM
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
using CL1_HEC_DIA;

namespace CL5_MyHealthClub_Medication.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_RecommendedProduct.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_RecommendedProduct
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_SRP_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();
			//Put your code here

            List<Guid> resultID = new List<Guid>();
            foreach (var productParam in Parameter.RecommendedProduct)
            {
                ORM_HEC_DIA_RecommendedProduct existingProduct = ORM_HEC_DIA_RecommendedProduct.Query.Search(Connection, Transaction, new ORM_HEC_DIA_RecommendedProduct.Query
                {
                    HEC_DIA_RecommendedProductID = productParam.HEC_DIA_RecommendedProductID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).SingleOrDefault();

                if (!productParam.IsDeleted)
                {
                    Guid ProductID = productParam.ProductID;
                    Guid DiagnosisID = productParam.DiagnoseID;

                    if (existingProduct == null)
                    {
                        existingProduct = new ORM_HEC_DIA_RecommendedProduct();
                        existingProduct.HEC_DIA_RecommendedProductID = productParam.HEC_DIA_RecommendedProductID;
                        existingProduct.PotentialDiagnosis_RefID = DiagnosisID;
                        existingProduct.HealthcareProduct_RefID = ProductID;
                        existingProduct.IsDeleted = false;
                        existingProduct.Tenant_RefID = securityTicket.TenantID;
                        existingProduct.Save(Connection, Transaction);
                    }
                    resultID.Add(existingProduct.HEC_DIA_RecommendedProductID);

                    foreach (var dosageParam in productParam.DosageList)
                    {
                        ORM_HEC_DIA_RecommendedProduct_Dosage existingDosage = ORM_HEC_DIA_RecommendedProduct_Dosage.Query.Search(Connection, Transaction, new ORM_HEC_DIA_RecommendedProduct_Dosage.Query
                        {
                            HEC_DIA_RecommendedProduct_DosageID = dosageParam.HEC_DIA_RecommendedProduct_DosageID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).SingleOrDefault();
                        if (!dosageParam.IsDeleted)
                        {
                            if (existingDosage == null)
                            {
                                existingDosage = new ORM_HEC_DIA_RecommendedProduct_Dosage();
                                existingDosage.HEC_DIA_RecommendedProduct_DosageID = dosageParam.HEC_DIA_RecommendedProduct_DosageID;
                            }
                            existingDosage.IsDefault = dosageParam.IsDefault;
                            existingDosage.Dosage_RefID = dosageParam.Dosage_RefID;
                            existingDosage.RecommendedProduct_RefID = existingProduct.HEC_DIA_RecommendedProductID;
                            existingDosage.IsDeleted = false;
                            existingDosage.Tenant_RefID = securityTicket.TenantID;
                            existingDosage.Save(Connection, Transaction);
                        }
                        else if (existingDosage != null && dosageParam.IsDeleted)
                        {
                            existingDosage.IsDeleted = true;
                            existingDosage.Save(Connection, Transaction);
                        }
                    }
                }
                else
                {
                    ORM_HEC_DIA_RecommendedProduct_Dosage.Query.SoftDelete(Connection, Transaction, new ORM_HEC_DIA_RecommendedProduct_Dosage.Query
                    {
                        RecommendedProduct_RefID = existingProduct.HEC_DIA_RecommendedProductID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });
                    existingProduct.IsDeleted = true;
                    existingProduct.Save(Connection, Transaction);
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
		public static FR_Guids Invoke(string ConnectionString,P_L5ME_SRP_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5ME_SRP_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_SRP_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_SRP_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guids functionReturn = new FR_Guids();
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

				throw new Exception("Exception occured in method cls_Save_RecommendedProduct",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ME_SRP_1317 for attribute P_L5ME_SRP_1317
		[DataContract]
		public class P_L5ME_SRP_1317 
		{
			[DataMember]
			public P_L5ME_SRP_1317_RecommendedProduct[] RecommendedProduct { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5ME_SRP_1317_RecommendedProduct for attribute RecommendedProduct
		[DataContract]
		public class P_L5ME_SRP_1317_RecommendedProduct 
		{
			[DataMember]
			public P_L5ME_SRP_1317_DosageList[] DosageList { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_RecommendedProductID { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Guid DiagnoseID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5ME_SRP_1317_DosageList for attribute DosageList
		[DataContract]
		public class P_L5ME_SRP_1317_DosageList 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_RecommendedProduct_DosageID { get; set; } 
			[DataMember]
			public Guid Dosage_RefID { get; set; } 
			[DataMember]
			public bool IsDefault { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_RecommendedProduct(,P_L5ME_SRP_1317 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_RecommendedProduct.Invoke(connectionString,P_L5ME_SRP_1317 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Medication.Atomic.Manipulation.P_L5ME_SRP_1317();
parameter.RecommendedProduct = ...;


*/
