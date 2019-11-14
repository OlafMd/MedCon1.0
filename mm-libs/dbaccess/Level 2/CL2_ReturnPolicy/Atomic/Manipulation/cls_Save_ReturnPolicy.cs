/* 
 * Generated on 11/14/2013 3:43:54 PM
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
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_CMN;
using CL1_LOG_RET;

namespace CL2_ReturnPolicy.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ReturnPolicy.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ReturnPolicy
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2RP_SRP_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            var item = new ORM_LOG_RET_ReturnPolicy();
            var price = new ORM_CMN_Price();
            var priceValue = new ORM_CMN_Price_Value();
    
            if (Parameter.LOG_RET_ReturnPolicyID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.LOG_RET_ReturnPolicyID);
                var price1 = price.Load(Connection, Transaction, item.ReturnPolicy_Cost_RefID);
               
                var query = new ORM_CMN_Price_Value.Query();
                query.Price_RefID = item.ReturnPolicy_Cost_RefID;
                priceValue = ORM_CMN_Price_Value.Query.Search(Connection,Transaction,query).First();
 
                if (result.Status != FR_Status.Success || item.LOG_RET_ReturnPolicyID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                price.IsDeleted = true;
                priceValue.IsDeleted = true;
                price.Save(Connection, Transaction);
                priceValue.Save(Connection, Transaction);
                return new FR_Guid(item.Save(Connection, Transaction), item.LOG_RET_ReturnPolicyID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.LOG_RET_ReturnPolicyID == Guid.Empty)
            {
                priceValue.Price_RefID = price.CMN_PriceID;
                //priceValue.PriceValue_Currency_RefID = Parameter.PriceValue_Currency_RefID;
                item.ReturnPolicy_Cost_RefID = price.CMN_PriceID;

                item.Tenant_RefID = securityTicket.TenantID;
                price.Tenant_RefID = securityTicket.TenantID;
                priceValue.Tenant_RefID = securityTicket.TenantID;
            }

            priceValue.PriceValue_Currency_RefID = Parameter.PriceValue_Currency_RefID;
            item.ReturnPolicy_Abbreviation = Parameter.ReturnPolicy_Abbreviation;
            item.ReturnPolicy_Reason = Parameter.ReturnPolicy_Reason_DictID;
            item.GlobalPropertyMatchingID = Parameter.GlobalPropertyMatchingID;
            priceValue.PriceValue_Amount = Parameter.PriceValue_Amount;
            price.Save(Connection, Transaction);
            priceValue.Save(Connection, Transaction);
            return new FR_Guid(item.Save(Connection, Transaction), item.LOG_RET_ReturnPolicyID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2RP_SRP_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2RP_SRP_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2RP_SRP_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2RP_SRP_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ReturnPolicy",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2RP_SRP_1421 for attribute P_L2RP_SRP_1421
		[DataContract]
		public class P_L2RP_SRP_1421 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RET_ReturnPolicyID { get; set; } 
			[DataMember]
			public Dict ReturnPolicy_Reason_DictID { get; set; } 
			[DataMember]
			public String ReturnPolicy_Abbreviation { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Double PriceValue_Amount { get; set; } 
			[DataMember]
			public Guid PriceValue_Currency_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ReturnPolicy(,P_L2RP_SRP_1421 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ReturnPolicy.Invoke(connectionString,P_L2RP_SRP_1421 Parameter,securityTicket);
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
var parameter = new CL2_ReturnPolicy.Atomic.Manipulation.P_L2RP_SRP_1421();
parameter.LOG_RET_ReturnPolicyID = ...;
parameter.ReturnPolicy_Reason_DictID = ...;
parameter.ReturnPolicy_Abbreviation = ...;
parameter.GlobalPropertyMatchingID = ...;
parameter.PriceValue_Amount = ...;
parameter.PriceValue_Currency_RefID = ...;
parameter.IsDeleted = ...;

*/
