/* 
 * Generated on 10/20/2014 9:33:16 AM
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
using CL1_CMN_SLS_DPF;

namespace CL2_Price.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DynamicPricingFormula.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DynamicPricingFormula
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2PR_SDPF_1036 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            var item = new CL1_CMN_SLS.ORM_CMN_SLS_DynamicPricingFormula_Type();
            if (Parameter.CMN_SLS_DynamicPricingFormula_TypeID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_SLS_DynamicPricingFormula_TypeID);
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_SLS_DynamicPricingFormula_TypeID);
            }

            if (Parameter.CMN_SLS_DynamicPricingFormula_TypeID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.GlobalPropertyMatchingID = String.Empty;
            item.DynamicPricingFormulaType_Name = Parameter.DynamicPricingFormulaType_Name;
            item.DefaultDynamicPricingFormula = Parameter.DefaultDynamicPricingFormula;

            foreach (var priceRange in Parameter.PriceRanges) {

                var priceRangeORM = new ORM_CMN_SLS_DPF_Type_ProcurementPriceDependency();
                priceRangeORM.Load(Connection, Transaction, priceRange.CMN_SLS_DPF_Type_ProcurementPriceDependencyID);

                if (priceRange.IsDeleted == true && priceRangeORM.CMN_SLS_DPF_Type_ProcurementPriceDependencyID != Guid.Empty)
                {
                    priceRangeORM.IsDeleted = true;
                    priceRangeORM.Save(Connection, Transaction);
                    continue;
                }

                if (priceRangeORM.CMN_SLS_DPF_Type_ProcurementPriceDependencyID == Guid.Empty)
                {
                    priceRangeORM.CMN_SLS_DPF_Type_ProcurementPriceDependencyID = priceRange.CMN_SLS_DPF_Type_ProcurementPriceDependencyID;
                    priceRangeORM.Tenant_RefID = securityTicket.TenantID;
                }

                priceRangeORM.DynamicPricingFormula_Type_RefID = item.CMN_SLS_DynamicPricingFormula_TypeID;
                priceRangeORM.ApplicableFrom_ProcurementPrice = priceRange.ApplicableFrom_ProcurementPrice;
                priceRangeORM.ApplicableThrough_ProcurementPrice = priceRange.ApplicableThrough_ProcurementPrice;
                priceRangeORM.DynamicPricingFormula = priceRange.DynamicPricingFormula;

                priceRangeORM.Save(Connection, Transaction);
            }

            return new FR_Guid(item.Save(Connection, Transaction), item.CMN_SLS_DynamicPricingFormula_TypeID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2PR_SDPF_1036 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2PR_SDPF_1036 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PR_SDPF_1036 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PR_SDPF_1036 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DynamicPricingFormula",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2PR_SDPF_1036 for attribute P_L2PR_SDPF_1036
		[DataContract]
		public class P_L2PR_SDPF_1036 
		{
			[DataMember]
			public P_L2PR_SDPF_1036a[] PriceRanges { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_DynamicPricingFormula_TypeID { get; set; } 
			[DataMember]
			public Dict DynamicPricingFormulaType_Name { get; set; } 
			[DataMember]
			public String DefaultDynamicPricingFormula { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L2PR_SDPF_1036a for attribute PriceRanges
		[DataContract]
		public class P_L2PR_SDPF_1036a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_DPF_Type_ProcurementPriceDependencyID { get; set; } 
			[DataMember]
			public Decimal ApplicableFrom_ProcurementPrice { get; set; } 
			[DataMember]
			public Decimal ApplicableThrough_ProcurementPrice { get; set; } 
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
FR_Guid cls_Save_DynamicPricingFormula(,P_L2PR_SDPF_1036 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DynamicPricingFormula.Invoke(connectionString,P_L2PR_SDPF_1036 Parameter,securityTicket);
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
var parameter = new CL2_Price.Atomic.Manipulation.P_L2PR_SDPF_1036();
parameter.PriceRanges = ...;

parameter.CMN_SLS_DynamicPricingFormula_TypeID = ...;
parameter.DynamicPricingFormulaType_Name = ...;
parameter.DefaultDynamicPricingFormula = ...;
parameter.IsDeleted = ...;

*/
