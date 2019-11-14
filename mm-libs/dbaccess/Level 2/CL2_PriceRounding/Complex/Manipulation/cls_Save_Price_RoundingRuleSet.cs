/* 
 * Generated on 29/11/2013 01:42:01
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL2_PriceRounding.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Price_RoundingRuleSet.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Price_RoundingRuleSet
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2PR_SPRRS_1549 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new CL1_CMN_SLS.ORM_CMN_SLS_Price_RoundingRuleSet();
			if (Parameter.CMN_SLS_Price_RoundingRuleSetID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.CMN_SLS_Price_RoundingRuleSetID);
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.CMN_SLS_Price_RoundingRuleSetID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.CMN_SLS_Price_RoundingRuleSetID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.RuleSet_Name = Parameter.RuleSet_Name;
			item.MaximumPriceIncreaseInPercent = Parameter.MaximumPriceIncreaseInPercent;
			item.MaximumPriceDecreaseInPercent = Parameter.MaximumPriceDecreaseInPercent;


			return new FR_Guid(item.Save(Connection, Transaction),item.CMN_SLS_Price_RoundingRuleSetID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2PR_SPRRS_1549 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2PR_SPRRS_1549 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PR_SPRRS_1549 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PR_SPRRS_1549 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Price_RoundingRuleSet",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2PR_SPRRS_1549 for attribute P_L2PR_SPRRS_1549
		[DataContract]
		public class P_L2PR_SPRRS_1549 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_Price_RoundingRuleSetID { get; set; } 
			[DataMember]
			public Dict RuleSet_Name { get; set; } 
			[DataMember]
			public Decimal MaximumPriceIncreaseInPercent { get; set; } 
			[DataMember]
			public Decimal MaximumPriceDecreaseInPercent { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Price_RoundingRuleSet(,P_L2PR_SPRRS_1549 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Price_RoundingRuleSet.Invoke(connectionString,P_L2PR_SPRRS_1549 Parameter,securityTicket);
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
var parameter = new CL2_PriceRounding.Complex.Manipulation.P_L2PR_SPRRS_1549();
parameter.CMN_SLS_Price_RoundingRuleSetID = ...;
parameter.RuleSet_Name = ...;
parameter.MaximumPriceIncreaseInPercent = ...;
parameter.MaximumPriceDecreaseInPercent = ...;
parameter.IsDeleted = ...;

*/