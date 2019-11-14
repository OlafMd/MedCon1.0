/* 
 * Generated on 6/11/2013 09:20:03
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
using System.Runtime.Serialization;
using CL5_APOAdmin_Supplier.Atomic.Retrieval;
using CL2_Contact.DomainManagement;
using DLCore_DBCommons.Utils;

namespace CL5_APOAdmin_Supplier.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Contact_Person_for_BusinessParticipantID_CommunicationContact.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Contact_Person_for_BusinessParticipantID_CommunicationContact
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
        protected static FR_L5AAS_GCPfBPCC_0849_Array Execute(DbConnection Connection, DbTransaction Transaction, P_L5AAS_GCPfBPCC_0849 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L5AAS_GCPfBPCC_0849_Array();
            P_L5AAS_GCPIfBP_1607 ParamGetContactPerson = new P_L5AAS_GCPIfBP_1607();
            ParamGetContactPerson.BusinessParticipantID = Parameter.BusinessParticipantID;
            var contactPersons = cls_Get_Contact_Person_Info_for_BusinessParticipantID.Invoke(Connection, Transaction, ParamGetContactPerson, securityTicket).Result;
            List<L5AAS_GCPfBPCC_0849> transformedContacts = new List<L5AAS_GCPfBPCC_0849>();
            foreach (var cp in contactPersons)
            {
                L5AAS_GCPfBPCC_0849 transformedContact = new L5AAS_GCPfBPCC_0849();
                transformedContact.CMN_BPT_BusinessParticipantID = cp.CMN_BPT_BusinessParticipantID;
                transformedContact.IsDeleted = cp.IsDeleted;
                transformedContact.AssociatedBusinessParticipant_RefID = cp.AssociatedBusinessParticipant_RefID;
                transformedContact.AssociatedParticipant_FunctionName = cp.AssociatedParticipant_FunctionName;
                transformedContact.CMN_PER_PersonInfoID = cp.CMN_PER_PersonInfoID;
                transformedContact.FirstName = cp.FirstName;
                transformedContact.LastName = cp.LastName;
                transformedContact.CMN_AddressID = cp.CMN_AddressID;
                transformedContact.Street_Name = cp.Street_Name;
                transformedContact.Street_Number = cp.Street_Number;
                transformedContact.City_Name = cp.City_Name;
                transformedContact.City_PostalCode = cp.City_PostalCode;
                transformedContact.Country_ISOCode = cp.Country_ISOCode;
                transformedContact.Email = GetContentByContentType(EnumUtils.GetEnumDescription(EComunactionContactType.Email), cp.ContactTypes);
                transformedContact.Phone = GetContentByContentType(EnumUtils.GetEnumDescription(EComunactionContactType.Phone), cp.ContactTypes);
                transformedContact.Fax = GetContentByContentType(EnumUtils.GetEnumDescription(EComunactionContactType.Fax), cp.ContactTypes);
                transformedContacts.Add(transformedContact);
            }
            returnValue.Result = transformedContacts.ToArray();
            returnValue.Status = FR_Status.Success;
            return returnValue;
            #endregion UserCode
        }
        private static string GetContentByContentType(string contentType, L5AAS_GCPIfBP_1607_ContactTypeContent[] contentTypesWithContent)
        {
            return contentTypesWithContent.Where(x => x.CommunicationContact_Type == contentType)
                                   .Select(x => x.cmn_per_communicationcontacts_Content).SingleOrDefault();
        }
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AAS_GCPfBPCC_0849_Array Invoke(string ConnectionString,P_L5AAS_GCPfBPCC_0849 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AAS_GCPfBPCC_0849_Array Invoke(DbConnection Connection,P_L5AAS_GCPfBPCC_0849 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AAS_GCPfBPCC_0849_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AAS_GCPfBPCC_0849 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AAS_GCPfBPCC_0849_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AAS_GCPfBPCC_0849 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AAS_GCPfBPCC_0849_Array functionReturn = new FR_L5AAS_GCPfBPCC_0849_Array();
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

				throw new Exception("Exception occured in method cls_Get_Contact_Person_for_BusinessParticipantID_CommunicationContact",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AAS_GCPfBPCC_0849_Array : FR_Base
	{
		public L5AAS_GCPfBPCC_0849[] Result	{ get; set; } 
		public FR_L5AAS_GCPfBPCC_0849_Array() : base() {}

		public FR_L5AAS_GCPfBPCC_0849_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AAS_GCPfBPCC_0849 for attribute P_L5AAS_GCPfBPCC_0849
		[DataContract]
		public class P_L5AAS_GCPfBPCC_0849 
		{
			//Standard type parameters
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 

		}
		#endregion
		#region SClass L5AAS_GCPfBPCC_0849 for attribute L5AAS_GCPfBPCC_0849
		[DataContract]
		public class L5AAS_GCPfBPCC_0849 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid AssociatedBusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String AssociatedParticipant_FunctionName { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Phone { get; set; } 
			[DataMember]
			public String Email { get; set; } 
			[DataMember]
			public String Fax { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AAS_GCPfBPCC_0849_Array cls_Get_Contact_Person_for_BusinessParticipantID_CommunicationContact(,P_L5AAS_GCPfBPCC_0849 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AAS_GCPfBPCC_0849_Array invocationResult = cls_Get_Contact_Person_for_BusinessParticipantID_CommunicationContact.Invoke(connectionString,P_L5AAS_GCPfBPCC_0849 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Supplier.Complex.Retrieval.P_L5AAS_GCPfBPCC_0849();
parameter.BusinessParticipantID = ...;

*/
