/* 
 * Generated on 2/27/2015 2:36:36 PM
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
using CL1_HEC_CMT;

namespace CL5_MyHealthClub_MedProCommunity.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ProcedureCatalogSubscription.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ProcedureCatalogSubscription
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5MPC_SPCS_1632 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();

            List<Guid> resultID = new List<Guid>();
            foreach (var procedureCatalogParam in Parameter.ProcedureCatalogSubscription)
            {
                ORM_HEC_CMT_Membership_PotentialProcedureCatalogSubscription existingProcedureCatalogSubscription = ORM_HEC_CMT_Membership_PotentialProcedureCatalogSubscription.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Membership_PotentialProcedureCatalogSubscription.Query
                {
                    PotentialProcedureCatalogITL = procedureCatalogParam.PotentialProcedureCatalogITL,
                    Membership_RefID = Parameter.Membership_RefID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).SingleOrDefault();

                if (existingProcedureCatalogSubscription == null && !procedureCatalogParam.IsDeleted)
                {
                    ORM_HEC_CMT_Membership_PotentialProcedureCatalogSubscription procedureCatalogSubscription = new ORM_HEC_CMT_Membership_PotentialProcedureCatalogSubscription();
                    procedureCatalogSubscription.HEC_CMT_Membership_PotentialProcedureCatalogSubscriptionID = Guid.NewGuid();
                    procedureCatalogSubscription.Membership_RefID = Parameter.Membership_RefID;
                    procedureCatalogSubscription.PotentialProcedureCatalogITL = procedureCatalogParam.PotentialProcedureCatalogITL;
                    procedureCatalogSubscription.Tenant_RefID = securityTicket.TenantID;
                    procedureCatalogSubscription.Save(Connection, Transaction);

                    resultID.Add(procedureCatalogSubscription.HEC_CMT_Membership_PotentialProcedureCatalogSubscriptionID);
                }
                else if (existingProcedureCatalogSubscription != null && procedureCatalogParam.IsDeleted)
                {
                    existingProcedureCatalogSubscription.IsDeleted = true;
                    existingProcedureCatalogSubscription.Save(Connection, Transaction);
                }
            }
            returnValue.Result = resultID.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5MPC_SPCS_1632 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5MPC_SPCS_1632 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MPC_SPCS_1632 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MPC_SPCS_1632 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ProcedureCatalogSubscription",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5MPC_SPCS_1632 for attribute P_L5MPC_SPCS_1632
		[DataContract]
		public class P_L5MPC_SPCS_1632 
		{
			[DataMember]
			public P_L5MPC_SPCS_1632_ProcedureCatalogSubscription[] ProcedureCatalogSubscription { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid Membership_RefID { get; set; } 

		}
		#endregion
		#region SClass P_L5MPC_SPCS_1632_ProcedureCatalogSubscription for attribute ProcedureCatalogSubscription
		[DataContract]
		public class P_L5MPC_SPCS_1632_ProcedureCatalogSubscription 
		{
			//Standard type parameters
			[DataMember]
			public String PotentialProcedureCatalogITL { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_ProcedureCatalogSubscription(,P_L5MPC_SPCS_1632 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_ProcedureCatalogSubscription.Invoke(connectionString,P_L5MPC_SPCS_1632 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_MedProCommunity.Atomic.Manipulation.P_L5MPC_SPCS_1632();
parameter.ProcedureCatalogSubscription = ...;

parameter.Membership_RefID = ...;

*/
