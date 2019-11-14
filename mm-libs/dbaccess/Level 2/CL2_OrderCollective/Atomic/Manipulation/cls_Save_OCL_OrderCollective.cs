/* 
 * Generated on 10/10/2014 2:58:50 PM
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
using CL1_OCL;
using CL1_CMN;

namespace CL2_OrderCollective.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_OCL_OrderCollective.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_OCL_OrderCollective
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2OC_SOC_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

            var returnValue = new FR_Guid();

            var item = new ORM_OCL_OrderCollective();
            if (Parameter.OCL_OrderCollectiveID != Guid.Empty)
            {
            var result = item.Load(Connection, Transaction, Parameter.OCL_OrderCollectiveID);
            if (result.Status != FR_Status.Success || item.OCL_OrderCollectiveID == Guid.Empty)
            {
            var error = new FR_Guid();
            error.ErrorMessage = "No Such ID";
            error.Status =  FR_Status.Error_Internal;
            return error;
            }
            }

            if(Parameter.IsDeleted == true){
            item.IsDeleted = true;
            return new FR_Guid(item.Save(Connection, Transaction),item.OCL_OrderCollectiveID);
            }

            if (Parameter.OCL_OrderCollectiveID == Guid.Empty)
            {
            item.Tenant_RefID = securityTicket.TenantID;
            }

            item.OrderCollectiveITL = Parameter.OrderCollectiveITL;
            item.OrderCollective_Name = new Dict(ORM_OCL_OrderCollective.TableName);
            var languages = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            });
            foreach (var lang in languages)
            {
                item.OrderCollective_Name.AddEntry(lang.CMN_LanguageID, Parameter.OrderCollective_Name);
            }

            return new FR_Guid(item.Save(Connection, Transaction),item.OCL_OrderCollectiveID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2OC_SOC_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2OC_SOC_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2OC_SOC_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2OC_SOC_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_OCL_OrderCollective",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2OC_SOC_1528 for attribute P_L2OC_SOC_1528
		[DataContract]
		public class P_L2OC_SOC_1528 
		{
			//Standard type parameters
			[DataMember]
			public Guid OCL_OrderCollectiveID { get; set; } 
			[DataMember]
			public String OrderCollectiveITL { get; set; } 
			[DataMember]
			public String OrderCollective_Name { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_OCL_OrderCollective(,P_L2OC_SOC_1528 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_OCL_OrderCollective.Invoke(connectionString,P_L2OC_SOC_1528 Parameter,securityTicket);
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
var parameter = new CL2_OrderCollective.Atomic.Manipulation.P_L2OC_SOC_1528();
parameter.OCL_OrderCollectiveID = ...;
parameter.OrderCollectiveITL = ...;
parameter.OrderCollective_Name = ...;
parameter.IsDeleted = ...;

*/
