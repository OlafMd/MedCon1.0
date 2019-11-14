/* 
 * Generated on 9/26/2014 2:22:43 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL1_HEC_DIA;

namespace CL5_MyHealthClub_Medication.Atomic.Manipulation
{
	[Serializable]
	public class cls_Save_DosageOfTheRecomendedProduct
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_SDOTRP_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            #region Save

            foreach(var item in Parameter.Dosages)
            {
                ORM_HEC_DIA_RecommendedProduct recommendedProduct = new ORM_HEC_DIA_RecommendedProduct();
                recommendedProduct.HEC_DIA_RecommendedProductID = item.ID;
                recommendedProduct.HealthcareProduct_RefID = Parameter.ProductID;
                recommendedProduct.PotentialDiagnosis_RefID = Parameter.DiagnoseID;
                recommendedProduct.IsDefault = item.IsDefault;
                recommendedProduct.Tenant_RefID = securityTicket.TenantID;
                recommendedProduct.Creation_Timestamp = DateTime.Now;
                recommendedProduct.Save(Connection,Transaction);
            }

            #endregion


            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5ME_SDOTRP_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5ME_SDOTRP_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_SDOTRP_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_SDOTRP_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ME_SDOTRP_1406 for attribute P_L5ME_SDOTRP_1406
		[Serializable]
		public class P_L5ME_SDOTRP_1406 
		{
			public P_L5ME_SDOTRP_1406_Dosages[] Dosages;  

			//Standard type parameters
			public Guid ProductID; 
			public Guid DiagnoseID; 

		}
		#endregion
		#region SClass P_L5ME_SDOTRP_1406_Dosages for attribute Dosages
		[Serializable]
		public class P_L5ME_SDOTRP_1406_Dosages 
		{
			//Standard type parameters
			public Guid HEC_DosageID; 
			public bool IsDefault; 
			public bool IsDeleted; 
			public Guid ID; 

		}
		#endregion

	#endregion
}
