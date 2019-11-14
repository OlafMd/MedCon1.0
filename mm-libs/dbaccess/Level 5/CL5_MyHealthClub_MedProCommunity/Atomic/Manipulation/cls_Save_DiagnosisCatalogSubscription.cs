/* 
 * Generated on 2/27/2015 2:36:31 PM
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
    /// var result = cls_Save_DiagnosisCatalogSubscription.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DiagnosisCatalogSubscription
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5MPC_SDCS_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();

            List<Guid> resultID = new List<Guid>();
            foreach (var diagnosisCatalogParam in Parameter.DiagnosisCatalogSubscription)
            {
                ORM_HEC_CMT_Membership_PotentialDiagnosisCatalogSubscription existingDiagnosisCatalogSubscription = ORM_HEC_CMT_Membership_PotentialDiagnosisCatalogSubscription.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Membership_PotentialDiagnosisCatalogSubscription.Query
                {
                    PotentialDiagnosisCatalogITL = diagnosisCatalogParam.PotentialDiagnosisCatalogITL,
                    Membership_RefID = Parameter.Membership_RefID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).SingleOrDefault();

                if (existingDiagnosisCatalogSubscription == null && !diagnosisCatalogParam.IsDeleted)
                {
                    ORM_HEC_CMT_Membership_PotentialDiagnosisCatalogSubscription diagnosisCatalogSubscription = new ORM_HEC_CMT_Membership_PotentialDiagnosisCatalogSubscription();
                    diagnosisCatalogSubscription.HEC_CMT_Membership_DiagnosisCatalogSubscriptionID = Guid.NewGuid();
                    diagnosisCatalogSubscription.Membership_RefID = Parameter.Membership_RefID;
                    diagnosisCatalogSubscription.PotentialDiagnosisCatalogITL = diagnosisCatalogParam.PotentialDiagnosisCatalogITL;
                    diagnosisCatalogSubscription.Tenant_RefID = securityTicket.TenantID;
                    diagnosisCatalogSubscription.Save(Connection, Transaction);

                    resultID.Add(diagnosisCatalogSubscription.HEC_CMT_Membership_DiagnosisCatalogSubscriptionID);
                }
                else if (existingDiagnosisCatalogSubscription != null && diagnosisCatalogParam.IsDeleted)
                {
                    existingDiagnosisCatalogSubscription.IsDeleted = true;
                    existingDiagnosisCatalogSubscription.Save(Connection, Transaction);
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
		public static FR_Guids Invoke(string ConnectionString,P_L5MPC_SDCS_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5MPC_SDCS_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MPC_SDCS_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MPC_SDCS_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DiagnosisCatalogSubscription",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5MPC_SDCS_1620 for attribute P_L5MPC_SDCS_1620
		[DataContract]
		public class P_L5MPC_SDCS_1620 
		{
			[DataMember]
			public P_L5MPC_SDCS_1620_DiagnosisCatalogSubscription[] DiagnosisCatalogSubscription { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid Membership_RefID { get; set; } 

		}
		#endregion
		#region SClass P_L5MPC_SDCS_1620_DiagnosisCatalogSubscription for attribute DiagnosisCatalogSubscription
		[DataContract]
		public class P_L5MPC_SDCS_1620_DiagnosisCatalogSubscription 
		{
			//Standard type parameters
			[DataMember]
			public String PotentialDiagnosisCatalogITL { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_DiagnosisCatalogSubscription(,P_L5MPC_SDCS_1620 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_DiagnosisCatalogSubscription.Invoke(connectionString,P_L5MPC_SDCS_1620 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_MedProCommunity.Atomic.Manipulation.P_L5MPC_SDCS_1620();
parameter.DiagnosisCatalogSubscription = ...;

parameter.Membership_RefID = ...;

*/
