/* 
 * Generated on 7/31/2014 10:32:03 AM
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
using CL1_CMN_BPT;
using CL1_CMN_BPT_CTM;
using CL3_CustomerAddresses.Atomic.Retrieval;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL3_CustomerAdresses.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerAddresses_for_CustomerID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerAddresses_for_CustomerID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3ACAAD_GCAfT_1612_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3ACAAD_GCAfCID_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3ACAAD_GCAfT_1612_Array();
			//Put your code here
            if (Parameter.CustomerID == Guid.Empty)
                return returnValue;

            ORM_CMN_BPT_CTM_Customer customer;
            var customerQ = new ORM_CMN_BPT_CTM_Customer.Query();
            customerQ.Tenant_RefID = securityTicket.TenantID;
            customerQ.IsDeleted = false;
            customerQ.CMN_BPT_CTM_CustomerID = Parameter.CustomerID;
            customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQ).FirstOrDefault();
            if (customer == null)
                return returnValue;

            ORM_CMN_BPT_BusinessParticipant bParticipant;
            var bParticipantQ = new ORM_CMN_BPT_BusinessParticipant.Query();
            bParticipantQ.Tenant_RefID = securityTicket.TenantID;
            bParticipantQ.IsDeleted = false;
            bParticipantQ.CMN_BPT_BusinessParticipantID = customer.Ext_BusinessParticipant_RefID;
            bParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, bParticipantQ).FirstOrDefault();
            if (bParticipant == null)
                return returnValue;
            //L5ACAAD_GCAfT_1544
            var list = new List<L3ACAAD_GCAfT_1612>();

            if (bParticipant.IsCompany)
            {
                P_L3ACAAD_GCAfT_1607 param = new P_L3ACAAD_GCAfT_1607();
                param.CompanyInfoID = bParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
                var addresses = cls_Get_CompanyAddresses_for_CompanyInfoID.Invoke(Connection, Transaction, param, securityTicket).Result;
                if (addresses != null)
                {
                    foreach (var a in addresses)
                    {
                        L3ACAAD_GCAfT_1612 item = new L3ACAAD_GCAfT_1612();
                        item.AddressID = a.CMN_UniversalContactDetailID;
                        item.Country_639_1_ISOCode = a.Country_639_1_ISOCode;
                        item.IsBilling = a.IsBilling;
                        item.IsShipping = a.IsShipping;
                        item.IsContact = a.IsContact;
                        item.Street_Name = a.Street_Name;
                        item.Street_Number = a.Street_Number;
                        item.Town = a.Town;
                        item.ZIP = a.ZIP;
                        item.AssignmentID = Guid.Empty;
                        item.CMN_COM_CompanyInfo_AddressID = a.CMN_COM_CompanyInfo_AddressID;
                        item.Country_Name = a.Country_Name;
                        item.AddressName = a.Address_Description;
                        item.IsDefault = a.IsDefault;
                        item.IsCompany = true;
                        list.Add(item);
                    }
                }
            }
            else
            {
                P_L3ACAAD_GPAfT_1608 param = new P_L3ACAAD_GPAfT_1608();
                param.PersonInfoID = bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                var addresses = cls_Get_PersonAddresses_for_PersonInfoID.Invoke(Connection, Transaction, param, securityTicket).Result;
                if (addresses != null)
                {
                    foreach (var a in addresses)
                    {
                        L3ACAAD_GCAfT_1612 item = new L3ACAAD_GCAfT_1612();
                        item.AddressID = a.CMN_AddressID;
                        item.Country_639_1_ISOCode = a.Country_ISOCode;
                        item.IsBilling = a.IsAddress_Billing;
                        item.IsShipping = a.IsAddress_Shipping;
                        item.IsContact = a.IsAddress_Contact;
                        item.Street_Name = a.Street_Name;
                        item.Street_Number = a.Street_Number;
                        item.Town = a.City_Name;
                        item.ZIP = a.City_PostalCode;
                        item.AssignmentID = a.AssignmentID;
                        item.CMN_COM_CompanyInfo_AddressID = Guid.Empty;
                        item.Country_Name = a.Country_Name;
                        item.AddressName = a.AddressLabel;
                        item.IsDefault = a.IsPrimary;
                        item.IsCompany = false;
                        list.Add(item);
                    }
                }
            }

            returnValue.Result = list.ToArray();

            return returnValue;



			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3ACAAD_GCAfT_1612_Array Invoke(string ConnectionString,P_L3ACAAD_GCAfCID_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3ACAAD_GCAfT_1612_Array Invoke(DbConnection Connection,P_L3ACAAD_GCAfCID_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3ACAAD_GCAfT_1612_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3ACAAD_GCAfCID_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3ACAAD_GCAfT_1612_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3ACAAD_GCAfCID_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3ACAAD_GCAfT_1612_Array functionReturn = new FR_L3ACAAD_GCAfT_1612_Array();
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

				throw new Exception("Exception occured in method cls_Get_CustomerAddresses_for_CustomerID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3ACAAD_GCAfT_1612_Array : FR_Base
	{
		public L3ACAAD_GCAfT_1612[] Result	{ get; set; } 
		public FR_L3ACAAD_GCAfT_1612_Array() : base() {}

		public FR_L3ACAAD_GCAfT_1612_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3ACAAD_GCAfCID_1612 for attribute P_L3ACAAD_GCAfCID_1612
		[DataContract]
		public class P_L3ACAAD_GCAfCID_1612 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerID { get; set; } 

		}
		#endregion
		#region SClass L3ACAAD_GCAfT_1612 for attribute L3ACAAD_GCAfT_1612
		[DataContract]
		public class L3ACAAD_GCAfT_1612 
		{
			//Standard type parameters
			[DataMember]
			public Guid AddressID { get; set; } 
			[DataMember]
			public bool IsContact { get; set; } 
			[DataMember]
			public bool IsBilling { get; set; } 
			[DataMember]
			public bool IsShipping { get; set; } 
			[DataMember]
			public bool IsDefault { get; set; } 
			[DataMember]
			public bool IsCompany { get; set; } 
			[DataMember]
			public string Street_Name { get; set; } 
			[DataMember]
			public string Street_Number { get; set; } 
			[DataMember]
			public string ZIP { get; set; } 
			[DataMember]
			public string Town { get; set; } 
			[DataMember]
			public string Country_639_1_ISOCode { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfo_AddressID { get; set; } 
			[DataMember]
			public string Country_Name { get; set; } 
			[DataMember]
			public string AddressName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3ACAAD_GCAfT_1612_Array cls_Get_CustomerAddresses_for_CustomerID(,P_L3ACAAD_GCAfCID_1612 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3ACAAD_GCAfT_1612_Array invocationResult = cls_Get_CustomerAddresses_for_CustomerID.Invoke(connectionString,P_L3ACAAD_GCAfCID_1612 Parameter,securityTicket);
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
var parameter = new CL3_CustomerAdresses.Complex.Retrieval.P_L3ACAAD_GCAfCID_1612();
parameter.CustomerID = ...;

*/
