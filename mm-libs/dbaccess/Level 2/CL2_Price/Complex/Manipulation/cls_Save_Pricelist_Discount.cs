/* 
 * Generated on 22/11/2013 03:17:48
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

namespace CL2_Price.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Pricelist_Discount.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Pricelist_Discount
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L2PL_SPD_1516 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {

            var returnValue = new FR_Guid();
            #region UserCode
            var item = new CL1_CMN_SLS.ORM_CMN_SLS_Pricelist_Discount();
            if (Parameter.CMN_SLS_Pricelist_DiscountID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_SLS_Pricelist_DiscountID);
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_SLS_Pricelist_DiscountID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.CMN_SLS_Pricelist_DiscountID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.PricelistVersion_RefID = Parameter.PricelistVersion_RefID;
            item.ProductGroup_RefID = Parameter.ProductGroup_RefID;
            item.Product_RefID = Parameter.Product_RefID;
            item.Product_Variant_RefID = Parameter.Product_Variant_RefID;
            item.Product_Release_RefID = Parameter.Product_Release_RefID;
            item.DiscountPercentAmount = Parameter.DiscountPercentAmount;
            item.DiscountValid_From = Parameter.DiscountValid_From;
            item.DiscountValid_To = Parameter.DiscountValid_To;


            return new FR_Guid(item.Save(Connection, Transaction), item.CMN_SLS_Pricelist_DiscountID);
            #endregion UserCode
        }
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2PL_SPD_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2PL_SPD_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PL_SPD_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PL_SPD_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Pricelist_Discount",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2PL_SPD_1516 for attribute P_L2PL_SPD_1516
		[DataContract]
		public class P_L2PL_SPD_1516 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_Pricelist_DiscountID { get; set; } 
			[DataMember]
			public Guid PricelistVersion_RefID { get; set; } 
			[DataMember]
			public Guid ProductGroup_RefID { get; set; } 
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public Guid Product_Variant_RefID { get; set; } 
			[DataMember]
			public Guid Product_Release_RefID { get; set; } 
			[DataMember]
			public Decimal DiscountPercentAmount { get; set; } 
			[DataMember]
			public DateTime DiscountValid_From { get; set; } 
			[DataMember]
			public DateTime DiscountValid_To { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Pricelist_Discount(,P_L2PL_SPD_1516 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Pricelist_Discount.Invoke(connectionString,P_L2PL_SPD_1516 Parameter,securityTicket);
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
var parameter = new CL2_Price.Complex.Manipulation.P_L2PL_SPD_1516();
parameter.CMN_SLS_Pricelist_DiscountID = ...;
parameter.PricelistVersion_RefID = ...;
parameter.ProductGroup_RefID = ...;
parameter.Product_RefID = ...;
parameter.Product_Variant_RefID = ...;
parameter.Product_Release_RefID = ...;
parameter.DiscountPercentAmount = ...;
parameter.DiscountValid_From = ...;
parameter.DiscountValid_To = ...;
parameter.IsDeleted = ...;

*/
