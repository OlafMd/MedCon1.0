/* 
 * Generated on 4/29/2014 10:32:48 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL2_Price.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CMN_SLS_Price.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CMN_SLS_Price
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2PR_SCSP_1504 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
     
            #region DefaultCurrency

            var dafaultCurrency = CL2_Currency.Atomic.Retrieval.cls_Get_DefaultCurrency_for_Tenant.Invoke(Connection, Transaction,securityTicket).Result;

            #endregion

            var item = new CL1_CMN_SLS.ORM_CMN_SLS_Price();
            if (Parameter.CMN_SLS_PriceID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_SLS_PriceID);
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_SLS_PriceID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.CMN_SLS_PriceID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.PricelistRelease_RefID = Parameter.PricelistRelease_RefID;
            item.CMN_PRO_Product_RefID = Parameter.CMN_PRO_Product_RefID;
            item.CMN_PRO_Product_Variant_RefID = Parameter.CMN_PRO_Product_Variant_RefID;
            item.CMN_PRO_Product_Release_RefID = Parameter.CMN_PRO_Product_Release_RefID;
            item.CMN_Currency_RefID = dafaultCurrency.CMN_CurrencyID;
            item.PriceAmount = Parameter.PriceAmount;
            item.IsDynamicPricingUsed = Parameter.IsDynamicPricingUsed;
            item.DynamicPricingFormula_Type_RefID = Parameter.DynamicPricingFormula_Type_RefID;
            item.DynamicPricingFormula = Parameter.DynamicPricingFormula;


            return new FR_Guid(item.Save(Connection, Transaction), item.CMN_SLS_PriceID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2PR_SCSP_1504 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2PR_SCSP_1504 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PR_SCSP_1504 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PR_SCSP_1504 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CMN_SLS_Price",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2PR_SCSP_1504 for attribute P_L2PR_SCSP_1504
		[DataContract]
		public class P_L2PR_SCSP_1504 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_PriceID { get; set; } 
			[DataMember]
			public Guid PricelistRelease_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_Variant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_Release_RefID { get; set; } 
			[DataMember]
			public Decimal PriceAmount { get; set; } 
			[DataMember]
			public bool IsDynamicPricingUsed { get; set; } 
			[DataMember]
			public Guid DynamicPricingFormula_Type_RefID { get; set; } 
			[DataMember]
			public String DynamicPricingFormula { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CMN_SLS_Price(,P_L2PR_SCSP_1504 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CMN_SLS_Price.Invoke(connectionString,P_L2PR_SCSP_1504 Parameter,securityTicket);
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
var parameter = new CL2_Price.Atomic.Manipulation.P_L2PR_SCSP_1504();
parameter.CMN_SLS_PriceID = ...;
parameter.PricelistRelease_RefID = ...;
parameter.CMN_PRO_Product_RefID = ...;
parameter.CMN_PRO_Product_Variant_RefID = ...;
parameter.CMN_PRO_Product_Release_RefID = ...;
parameter.PriceAmount = ...;
parameter.IsDynamicPricingUsed = ...;
parameter.DynamicPricingFormula_Type_RefID = ...;
parameter.DynamicPricingFormula = ...;
parameter.IsDeleted = ...;

*/
