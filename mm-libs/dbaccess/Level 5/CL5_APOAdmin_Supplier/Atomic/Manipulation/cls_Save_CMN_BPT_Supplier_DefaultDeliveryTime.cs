/* 
 * Generated on 2/18/2014 10:26:42 AM
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
using CL1_CMN_BPT;

namespace CL5_APOAdmin_Supplier.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CMN_BPT_Supplier_DefaultDeliveryTime.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CMN_BPT_Supplier_DefaultDeliveryTime
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SU_SDDT_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new ORM_CMN_BPT_Supplier_DefaultDeliveryTime();
			if (Parameter.CMN_BPT_Supplier_DefaultDeliveryTimeID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.CMN_BPT_Supplier_DefaultDeliveryTimeID);
			    if (result.Status != FR_Status.Success || item.CMN_BPT_Supplier_DefaultDeliveryTimeID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.CMN_BPT_Supplier_DefaultDeliveryTimeID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.CMN_BPT_Supplier_DefaultDeliveryTimeID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.Supplier_RefID = Parameter.Supplier_RefID;
			item.CRONExpression = Parameter.CRONExpression;
			item.Specified_Product_Group_RefID = Parameter.Specified_Product_Group_RefID;
			item.Specified_Product_RefID = Parameter.Specified_Product_RefID;
			item.Specified_Product_Variant_RefID = Parameter.Specified_Product_Variant_RefID;
			item.Specified_Product_Release_RefID = Parameter.Specified_Product_Release_RefID;


			return new FR_Guid(item.Save(Connection, Transaction),item.CMN_BPT_Supplier_DefaultDeliveryTimeID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SU_SDDT_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SU_SDDT_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SU_SDDT_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SU_SDDT_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CMN_BPT_Supplier_DefaultDeliveryTime",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SU_SDDT_1021 for attribute P_L5SU_SDDT_1021
		[DataContract]
		public class P_L5SU_SDDT_1021 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_Supplier_DefaultDeliveryTimeID { get; set; } 
			[DataMember]
			public Guid Supplier_RefID { get; set; } 
			[DataMember]
			public String CRONExpression { get; set; } 
			[DataMember]
			public Guid Specified_Product_Group_RefID { get; set; } 
			[DataMember]
			public Guid Specified_Product_RefID { get; set; } 
			[DataMember]
			public Guid Specified_Product_Variant_RefID { get; set; } 
			[DataMember]
			public Guid Specified_Product_Release_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CMN_BPT_Supplier_DefaultDeliveryTime(,P_L5SU_SDDT_1021 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CMN_BPT_Supplier_DefaultDeliveryTime.Invoke(connectionString,P_L5SU_SDDT_1021 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Supplier.Atomic.Manipulation.P_L5SU_SDDT_1021();
parameter.CMN_BPT_Supplier_DefaultDeliveryTimeID = ...;
parameter.Supplier_RefID = ...;
parameter.CRONExpression = ...;
parameter.Specified_Product_Group_RefID = ...;
parameter.Specified_Product_RefID = ...;
parameter.Specified_Product_Variant_RefID = ...;
parameter.Specified_Product_Release_RefID = ...;
parameter.IsDeleted = ...;

*/
