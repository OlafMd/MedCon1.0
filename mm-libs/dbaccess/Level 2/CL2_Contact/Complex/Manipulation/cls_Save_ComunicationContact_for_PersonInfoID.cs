/* 
 * Generated on 9/10/2013 5:06:31 PM
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
using CL2_Contact.DomainManagement;
using CL2_Contact.Complex.Retrieval;

namespace CL2_Contact.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ComunicationContact_for_PersonInfoID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ComunicationContact_for_PersonInfoID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2CN_SCCfPI_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
            var returnValue = new FR_Guid();

            var item = new ORM_CMN_PER_CommunicationContact();

            if (Parameter.CMN_PER_CommunicationContactID != Guid.Empty)
                item.Load(Connection, Transaction, Parameter.CMN_PER_CommunicationContactID);

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_PER_CommunicationContactID);
            }

            if (Parameter.CMN_PER_CommunicationContactID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            //GetComunication ContatctTypeID or create it if not exist
            var comunicationContactTypes = cls_Get_AllComunicationContactTypes.Invoke(Connection, Transaction, securityTicket).Result;
            
            var comunicationContactTypeID = DMComunactionContactTypes.Get_CommunactionContactType_for_GlobalPropertyMatchingID(Connection, Transaction, Parameter.ContactType, securityTicket);

            item.PersonInfo_RefID = Parameter.PersonInfo_RefID;
            item.Contact_Type = comunicationContactTypeID;
            item.Content = Parameter.ContactValue;

            return new FR_Guid(item.Save(Connection, Transaction), item.CMN_PER_CommunicationContactID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2CN_SCCfPI_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2CN_SCCfPI_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2CN_SCCfPI_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2CN_SCCfPI_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ComunicationContact_for_PersonInfoID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2CN_SCCfPI_1409 for attribute P_L2CN_SCCfPI_1409
		[DataContract]
		public class P_L2CN_SCCfPI_1409 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PER_CommunicationContactID { get; set; } 
			[DataMember]
			public Guid PersonInfo_RefID { get; set; } 
			[DataMember]
			public String ContactValue { get; set; } 
			[DataMember]
			public String ContactType { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ComunicationContact_for_PersonInfoID(,P_L2CN_SCCfPI_1409 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ComunicationContact_for_PersonInfoID.Invoke(connectionString,P_L2CN_SCCfPI_1409 Parameter,securityTicket);
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
var parameter = new CL2_Contact.Complex.Manipulation.P_L2CN_SCCfPI_1409();
parameter.CMN_PER_CommunicationContactID = ...;
parameter.PersonInfo_RefID = ...;
parameter.ContactValue = ...;
parameter.ContactType = ...;
parameter.IsDeleted = ...;

*/
