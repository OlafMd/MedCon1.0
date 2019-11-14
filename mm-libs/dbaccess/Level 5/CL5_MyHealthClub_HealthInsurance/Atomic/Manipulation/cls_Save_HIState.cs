/* 
 * Generated on 26.06.2014 15:05:50
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

namespace CL5_MyHealthClub_HealthInsurance.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_HIState.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_HIState
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5HI_SHIS_1500 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_HEC_Patient_HealthInsurance_State item;
            if (Parameter.HEC_Patient_HealthInsurance_StateID != Guid.Empty)
            {
                if (Parameter.IsDeleted)
                {
                    ORM_HEC_Patient_HealthInsurance_State.Query.SoftDelete(Connection, Transaction, new ORM_HEC_Patient_HealthInsurance_State.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        HEC_Patient_HealthInsurance_StateID = Parameter.HEC_Patient_HealthInsurance_StateID
                    });
                    return returnValue;
                }

                item = ORM_HEC_Patient_HealthInsurance_State.Query.Search(Connection, Transaction, new ORM_HEC_Patient_HealthInsurance_State.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    HEC_Patient_HealthInsurance_StateID = Parameter.HEC_Patient_HealthInsurance_StateID
                }).Single();

            }
            else
            {
                item = new ORM_HEC_Patient_HealthInsurance_State();
                item.HEC_Patient_HealthInsurance_StateID = Guid.NewGuid();
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.HealthInsuranceState_Abbreviation = Parameter.HealthInsuranceState_Abbreviation;
            item.HealthInsuranceState_Name = Parameter.HealthInsuranceState_Name;
            item.Save(Connection, Transaction);

            returnValue.Result = item.HEC_Patient_HealthInsurance_StateID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5HI_SHIS_1500 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5HI_SHIS_1500 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5HI_SHIS_1500 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5HI_SHIS_1500 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_HIState",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5HI_SHIS_1500 for attribute P_L5HI_SHIS_1500
		[DataContract]
		public class P_L5HI_SHIS_1500 
		{
			//Standard type parameters
			[DataMember]
			public String HealthInsuranceState_Abbreviation { get; set; } 
			[DataMember]
			public Dict HealthInsuranceState_Name { get; set; } 
			[DataMember]
			public Guid HEC_Patient_HealthInsurance_StateID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_HIState(,P_L5HI_SHIS_1500 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_HIState.Invoke(connectionString,P_L5HI_SHIS_1500 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_HealthInsurance.Atomic.Manipulation.P_L5HI_SHIS_1500();
parameter.HealthInsuranceState_Abbreviation = ...;
parameter.HealthInsuranceState_Name = ...;
parameter.HEC_Patient_HealthInsurance_StateID = ...;
parameter.IsDeleted = ...;

*/
