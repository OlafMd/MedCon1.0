/* 
 * Generated on 31/10/2013 02:21:18
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

namespace CL5_APOAdmin_Supplier.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Supplier_Contact_Person_Info.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Supplier_Contact_Person_Info
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AAS_SSPCI_0832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

			var item = new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant();
            var associatedBusinessParticipant = new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();
            var personInfo = new CL1_CMN_PER.ORM_CMN_PER_PersonInfo();
            var communicationContacts = new List<CL1_CMN_PER.ORM_CMN_PER_CommunicationContact>();
            var address = new CL1_CMN.ORM_CMN_Address();

			if (Parameter.CMN_BPT_BusinessParticipantID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.CMN_BPT_BusinessParticipantID);
                associatedBusinessParticipant = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction,
                    new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query
                    {
                        IsDeleted = false,
                        BusinessParticipant_RefID = item.CMN_BPT_BusinessParticipantID
                    }).Single();
                // Get person info
                personInfo.Load(Connection, Transaction, item.IfNaturalPerson_CMN_PER_PersonInfo_RefID);
                // Get communication contacts
                communicationContacts = CL1_CMN_PER.ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction,
                new CL1_CMN_PER.ORM_CMN_PER_CommunicationContact.Query { IsDeleted = false, PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID});
                // Get address
                if (Parameter.CMN_AddressID != Guid.Empty)
                    address.Load(Connection, Transaction, Parameter.CMN_AddressID);
            }

            if (Parameter.IsDeleted == true)
            {
                associatedBusinessParticipant.IsDeleted = true;
                personInfo.IsDeleted = true;
                communicationContacts.ForEach(x => x.IsDeleted = true);
                communicationContacts.ForEach(x => x.Save(Connection, Transaction));
                if (address.Status_IsAlreadySaved) 
                {
                    address.IsDeleted = true;
                    address.Save(Connection, Transaction);
                }
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_BPT_BusinessParticipantID);
            }

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.CMN_BPT_BusinessParticipantID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
                associatedBusinessParticipant.Tenant_RefID = securityTicket.TenantID;
                personInfo.Tenant_RefID = securityTicket.TenantID;
                communicationContacts.ForEach(x => x.Tenant_RefID = securityTicket.TenantID);
                address.Tenant_RefID = securityTicket.TenantID;
			}

            item.IsNaturalPerson = true;
            item.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
            associatedBusinessParticipant.BusinessParticipant_RefID = item.CMN_BPT_BusinessParticipantID;
            associatedBusinessParticipant.AssociatedBusinessParticipant_RefID = Parameter.AssociatedBusinessParticipant_RefID;
            associatedBusinessParticipant.AssociatedParticipant_FunctionName = Parameter.AssociatedParticipant_FunctionName;
            personInfo.FirstName = Parameter.FirstName;
            personInfo.LastName = Parameter.LastName;
            personInfo.Address_RefID = address.CMN_AddressID;

            #region Save Address
            if (!Parameter.UseDefaultAddress)
            {
                address.City_Name = Parameter.City_Name;
                address.Street_Name = Parameter.Street_Name;
                address.Street_Number = Parameter.Street_Number;
                address.City_PostalCode = Parameter.City_PostalCode;
                address.Country_ISOCode = Parameter.Country_ISOCode;
                address.Save(Connection, Transaction);
            }
            else
            {
                if (address.Status_IsAlreadySaved)
                {
                    address.IsDeleted = true;
                    address.Save(Connection, Transaction);
                }
                personInfo.Address_RefID = Guid.Empty;
            }
            #endregion
            #region Save Connection Contact
            var tenantCompanyTypes = CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction,
                new CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query()
                {
                    Tenant_RefID = item.Tenant_RefID,
                    IsDeleted = false
                });
            foreach (var ctype in tenantCompanyTypes)
            {
                // Create communication contact save parameter.
                CL2_Contact.Complex.Manipulation.P_L2CN_SCCfPI_1409 commContactParameter = new CL2_Contact.Complex.Manipulation.P_L2CN_SCCfPI_1409();
                // Set person ref id.
                commContactParameter.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                // Find CommunicationContactID in existig list and set parameter.
                commContactParameter.CMN_PER_CommunicationContactID = communicationContacts
                    .Where(x => x.Contact_Type == ctype.CMN_PER_CommunicationContact_TypeID)
                    .Select(x => x.CMN_PER_CommunicationContactID).SingleOrDefault();
                // Set contact type parameter.
                commContactParameter.ContactType = ctype.Type;
                // Set contact value for specified content type.
                if (ctype.Type == DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Phone))
                    commContactParameter.ContactValue = Parameter.Phone;
                else if (ctype.Type == DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Email))
                    commContactParameter.ContactValue = Parameter.Email;
                else if (ctype.Type == DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Fax))
                    commContactParameter.ContactValue = Parameter.Fax;
                else continue; // not saving, because tenant don't have this contact type.
                CL2_Contact.Complex.Manipulation.cls_Save_ComunicationContact_for_PersonInfoID.Invoke(Connection, Transaction, commContactParameter, securityTicket);
            }
            #endregion
            associatedBusinessParticipant.Save(Connection, Transaction);
            personInfo.Save(Connection, Transaction);
            return new FR_Guid(item.Save(Connection, Transaction),item.CMN_BPT_BusinessParticipantID);
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AAS_SSPCI_0832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AAS_SSPCI_0832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AAS_SSPCI_0832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AAS_SSPCI_0832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Supplier_Contact_Person_Info",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AAS_SSPCI_0832 for attribute P_L5AAS_SSPCI_0832
		[DataContract]
		public class P_L5AAS_SSPCI_0832 
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
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Email { get; set; } 
			[DataMember]
			public String Phone { get; set; } 
			[DataMember]
			public String Fax { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public bool UseDefaultAddress { get; set; } 
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
FR_Guid cls_Save_Supplier_Contact_Person_Info(,P_L5AAS_SSPCI_0832 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Supplier_Contact_Person_Info.Invoke(connectionString,P_L5AAS_SSPCI_0832 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Supplier.Complex.Manipulation.P_L5AAS_SSPCI_0832();
parameter.CMN_BPT_BusinessParticipantID = ...;
parameter.IsDeleted = ...;
parameter.AssociatedBusinessParticipant_RefID = ...;
parameter.AssociatedParticipant_FunctionName = ...;
parameter.FirstName = ...;
parameter.LastName = ...;
parameter.Email = ...;
parameter.Phone = ...;
parameter.Fax = ...;
parameter.CMN_AddressID = ...;
parameter.UseDefaultAddress = ...;
parameter.Street_Name = ...;
parameter.Street_Number = ...;
parameter.City_Name = ...;
parameter.City_PostalCode = ...;
parameter.Country_ISOCode = ...;

*/
