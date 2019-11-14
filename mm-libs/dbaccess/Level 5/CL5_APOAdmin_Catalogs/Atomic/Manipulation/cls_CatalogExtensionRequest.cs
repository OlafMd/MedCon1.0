/* 
 * Generated on 1/21/2014 1:48:39 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_CMN_BPT_CTM;

namespace CL5_APOAdmin_Catalogs.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_CatalogExtensionRequest.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_CatalogExtensionRequest
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_SCPER_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            ORM_CMN_BPT_CTM_CatalogProductExtensionRequests item;

            if (Parameter.CMN_BPT_CTM_CatalogProductExtensionRequestID != Guid.Empty)
            {

                item = ORM_CMN_BPT_CTM_CatalogProductExtensionRequests.Query.Search(Connection, Transaction,
                           new ORM_CMN_BPT_CTM_CatalogProductExtensionRequests.Query
                           {
                               CMN_BPT_CTM_CatalogProductExtensionRequestID = Parameter.CMN_BPT_CTM_CatalogProductExtensionRequestID,
                               IsDeleted = false
                           }).Single();
            }
            else
            {
                item = new ORM_CMN_BPT_CTM_CatalogProductExtensionRequests();
                item.Tenant_RefID = securityTicket.TenantID;
                item.CMN_BPT_CTM_CatalogProductExtensionRequestID = Guid.NewGuid();
            }

            returnValue.Result = item.CMN_BPT_CTM_CatalogProductExtensionRequestID;

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                item.Save(Connection, Transaction);
                return returnValue;
            }

            item.RequestedBy_Customer_BusinessParticipant_RefID = Parameter.RequestedBy_Customer_BusinessParticipant_RefID;
            item.RequestedBy_Person_BusinessParticipant_RefID = Parameter.RequestedBy_Person_BusinessParticipant_RefID;
            item.Request_Question = Parameter.Request_Question;
            item.Creation_Timestamp = DateTime.Now;
            item.Save(Connection, Transaction);

            //var customerBP = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
            //   new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query()
            //   {
            //       CMN_BPT_BusinessParticipantID = item.RequestedBy_Customer_BusinessParticipant_RefID,
            //       Tenant_RefID = securityTicket.TenantID,
            //       IsCompany = true,
            //       IsDeleted = false
            //   }).Single();

            //var doctorBP = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
            //   new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query()
            //   {
            //       CMN_BPT_BusinessParticipantID = item.RequestedBy_Person_BusinessParticipant_RefID,
            //       Tenant_RefID = securityTicket.TenantID,
            //       IsNaturalPerson = true,
            //       IsDeleted = false
            //   }).Single();

            //var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction,
            //   new ORM_CMN_PER_PersonInfo.Query()
            //   {
            //       CMN_PER_PersonInfoID = doctorBP.IfNaturalPerson_CMN_PER_PersonInfo_RefID,
            //       Tenant_RefID = securityTicket.TenantID,
            //       IsDeleted = false
            //   }).Single();


            //var catalogs = ORM_CMN_PRO_SubscribedCatalog.Query.Search(Connection, Transaction, new ORM_CMN_PRO_SubscribedCatalog.Query()
            //{
            //    IsDeleted = false,
            //    Tenant_RefID = securityTicket.TenantID,
            //    SubscribedBy_BusinessParticipant_RefID = item.RequestedBy_Customer_BusinessParticipant_RefID       
            //});

            //String CatalogITL = String.Empty;

            //catalogs = catalogs.Where(c => !c.IsCatalogPublic).ToList();
            //if (catalogs.Count() > 0)
            //    CatalogITL = catalogs[0].CatalogCodeITL;

            

            //returnValue.Result = new L5CA_SCPER_1105()
            //{
            //    CMN_BPT_CTM_CatalogProductExtensionRequestID = item.CMN_BPT_CTM_CatalogProductExtensionRequestID,
            //    CatalogITL = CatalogITL,
            //    DisplayName = customerBP.DisplayName,
            //    FirstName = personInfo.FirstName,
            //    LastName = personInfo.LastName,
            //    Request_Question = item.Request_Question,
            //    RequestedBy_Customer_BusinessParticipant_RefID = item.RequestedBy_Customer_BusinessParticipant_RefID,
            //    RequestedBy_Person_BusinessParticipant_RefID = item.RequestedBy_Person_BusinessParticipant_RefID
            //};
            return returnValue;

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CA_SCPER_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CA_SCPER_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_SCPER_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_SCPER_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_CatalogExtensionRequest",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CA_SCPER_1105 for attribute P_L5CA_SCPER_1105
		[DataContract]
		public class P_L5CA_SCPER_1105 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_CatalogProductExtensionRequestID { get; set; } 
			[DataMember]
			public Guid RequestedBy_Customer_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid RequestedBy_Person_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String Request_Question { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Guid ApplicationID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_CatalogExtensionRequest(,P_L5CA_SCPER_1105 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_CatalogExtensionRequest.Invoke(connectionString,P_L5CA_SCPER_1105 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Catalogs.Atomic.Manipulation.P_L5CA_SCPER_1105();
parameter.CMN_BPT_CTM_CatalogProductExtensionRequestID = ...;
parameter.RequestedBy_Customer_BusinessParticipant_RefID = ...;
parameter.RequestedBy_Person_BusinessParticipant_RefID = ...;
parameter.Request_Question = ...;
parameter.IsDeleted = ...;
parameter.ApplicationID = ...;

*/
