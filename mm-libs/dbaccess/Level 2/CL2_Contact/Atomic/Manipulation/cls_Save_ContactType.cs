/* 
 * Generated on 12/10/2013 4:40:44 PM
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
using CL1_CMN_PER;

namespace CL2_Contact.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ContactType.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ContactType
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2CN_SC_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

			//Put your code here
            ORM_CMN_PER_CommunicationContact_Type contactType = new ORM_CMN_PER_CommunicationContact_Type();

            if (Parameter.CMN_PER_CommunicationContact_TypeID != Guid.Empty)
            {
                var result = contactType.Load(Connection, Transaction, Parameter.CMN_PER_CommunicationContact_TypeID);
                if (result.Status != FR_Status.Success || contactType.CMN_PER_CommunicationContact_TypeID == Guid.Empty)
                {
                    FR_Guid error = new FR_Guid();
                    error.ErrorMessage = "No Such ID.";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            contactType.Tenant_RefID = securityTicket.TenantID;
            contactType.Type = Parameter.Type;
            contactType.IsPersistent = Parameter.IsPersistent;
            contactType.Save(Connection, Transaction);

            returnValue.Result = contactType.CMN_PER_CommunicationContact_TypeID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2CN_SC_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2CN_SC_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2CN_SC_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2CN_SC_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2CN_SC_1712 for attribute P_L2CN_SC_1712
		[DataContract]
		public class P_L2CN_SC_1712 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PER_CommunicationContact_TypeID { get; set; } 
			[DataMember]
			public String Type { get; set; } 
			[DataMember]
			public bool IsPersistent { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ContactType(P_L2CN_SC_1712 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_ContactType.Invoke(connectionString,P_L2CN_SC_1712 Parameter,securityTicket);
	 return result;
}
*/