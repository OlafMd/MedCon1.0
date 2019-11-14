/* 
 * Generated on 12/3/2013 10:04:02 AM
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
using CL2_Contact.Atomic.Retrieval;

namespace CL2_Contact.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ContactType_For_TypeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ContactType_For_TypeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2CN_GCTFCT_1724 Execute(DbConnection Connection,DbTransaction Transaction,P_L2CN_GCTFCT_1724 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L2CN_GCTFCT_1724();
            returnValue.Result = new L2CN_GCTFCT_1724();
            var contactTypeResult = new L2CN_GCTFT_1615();

			//Put your code here
            ORM_CMN_PER_CommunicationContact_Type contactType = new ORM_CMN_PER_CommunicationContact_Type();

            if (Parameter.CMN_PER_CommunicationContact_TypeID != Guid.Empty)
            {
                var result = contactType.Load(Connection, Transaction, Parameter.CMN_PER_CommunicationContact_TypeID);
                if (result.Status != FR_Status.Success || contactType.CMN_PER_CommunicationContact_TypeID == Guid.Empty)
                    return null;
            }

            contactTypeResult.CMN_PER_CommunicationContact_TypeID = contactType.CMN_PER_CommunicationContact_TypeID;
            contactTypeResult.Type = contactType.Type;

            returnValue.Result.ContactType = contactTypeResult;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2CN_GCTFCT_1724 Invoke(string ConnectionString,P_L2CN_GCTFCT_1724 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2CN_GCTFCT_1724 Invoke(DbConnection Connection,P_L2CN_GCTFCT_1724 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2CN_GCTFCT_1724 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2CN_GCTFCT_1724 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2CN_GCTFCT_1724 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2CN_GCTFCT_1724 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2CN_GCTFCT_1724 functionReturn = new FR_L2CN_GCTFCT_1724();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L2CN_GCTFCT_1724 : FR_Base
	{
		public L2CN_GCTFCT_1724 Result	{ get; set; }

		public FR_L2CN_GCTFCT_1724() : base() {}

		public FR_L2CN_GCTFCT_1724(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2CN_GCTFCT_1724 for attribute P_L2CN_GCTFCT_1724
		[DataContract]
		public class P_L2CN_GCTFCT_1724 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PER_CommunicationContact_TypeID { get; set; } 

		}
		#endregion
		#region SClass L2CN_GCTFCT_1724 for attribute L2CN_GCTFCT_1724
		[DataContract]
		public class L2CN_GCTFCT_1724 
		{
			//Standard type parameters
			[DataMember]
			public L2CN_GCTFT_1615 ContactType { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2CN_GCTFCT_1724 cls_Get_ContactType_For_TypeID(P_L2CN_GCTFCT_1724 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L2CN_GCTFCT_1724 result = cls_Get_ContactType_For_TypeID.Invoke(connectionString,P_L2CN_GCTFCT_1724 Parameter,securityTicket);
	 return result;
}
*/