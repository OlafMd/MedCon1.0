/* 
 * Generated on 8/30/2013 10:47:58 AM
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
using CL1_HEC;

namespace CL5_OphthalDoctors.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Add_HEC_Doctor_RequiredProduct.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Add_HEC_Doctor_RequiredProduct
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OD_ADRP_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            foreach (var CMN_PRO_ProductID in Parameter.CMN_PRO_ProductID_List)
            {

                var query = new ORM_HEC_Doctor_RequiredProduct.Query();
                query.CMN_PRO_Product_RefID = CMN_PRO_ProductID;
                query.HEC_Doctor_RefID = Parameter.HEC_Doctor_RefID;

                var assignment = ORM_HEC_Doctor_RequiredProduct.Query.Search(Connection, Transaction, query);

                if (assignment != null && assignment.Count() != 0)
                {
                    ORM_HEC_Doctor_RequiredProduct.Query.SoftRecover(Connection, Transaction, query);
                }
                else
                {

                    var newAssignment = new ORM_HEC_Doctor_RequiredProduct();
                    newAssignment.HEC_Doctor_RequiredProductID = Guid.NewGuid();
                    newAssignment.CMN_PRO_Product_RefID = CMN_PRO_ProductID;
                    newAssignment.HEC_Doctor_RefID = Parameter.HEC_Doctor_RefID;
                    newAssignment.Tenant_RefID = securityTicket.TenantID;
                    newAssignment.Creation_Timestamp = DateTime.Now;
                    newAssignment.Save(Connection, Transaction);

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
		public static FR_Guid Invoke(string ConnectionString,P_L5OD_ADRP_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OD_ADRP_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OD_ADRP_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OD_ADRP_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Add_HEC_Doctor_RequiredProduct",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OD_ADRP_1502 for attribute P_L5OD_ADRP_1502
		[DataContract]
		public class P_L5OD_ADRP_1502 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Doctor_RefID { get; set; } 
			[DataMember]
			public Guid[] CMN_PRO_ProductID_List { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Add_HEC_Doctor_RequiredProduct(,P_L5OD_ADRP_1502 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Add_HEC_Doctor_RequiredProduct.Invoke(connectionString,P_L5OD_ADRP_1502 Parameter,securityTicket);
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
var parameter = new CL5_OphthalDoctors.Atomic.Manipulation.P_L5OD_ADRP_1502();
parameter.HEC_Doctor_RefID = ...;
parameter.CMN_PRO_ProductID_List = ...;

*/
