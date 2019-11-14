/* 
 * Generated on 31/7/2014 04:49:27
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
using CL1_CMN;
using CL1_CMN_BPT_CTM;

namespace CL5_APOCustomerAdmin_Address.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_OrganizationalUnit_Address.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_OrganizationalUnit_Address
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5ACAAD_SOUA_1239 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            var address = new ORM_CMN_BPT_CTM_OrganizationalUnit_Address();
            var universalcontactdetails = new ORM_CMN_UniversalContactDetail();

            if (Parameter.IsDelete)
            {
                var resultAddress = address.Load(Connection, Transaction, Parameter.CMN_AddressID);
                if (address.CMN_BPT_CTM_OrganizationalUnit_AddressID != Guid.Empty)
                {
                    address.IsDeleted = true;
                    address.Save(Connection, Transaction);
                }
                var resultOrgUnit = universalcontactdetails.Load(Connection, Transaction, Parameter.UniversalContactDetailsID);
                if (universalcontactdetails.CMN_UniversalContactDetailID != Guid.Empty)
                {
                    universalcontactdetails.IsDeleted = true;
                    universalcontactdetails.Save(Connection, Transaction);
                }
            }
            else
            {
                if (Parameter.CMN_AddressID != Guid.Empty && Parameter.UniversalContactDetailsID != Guid.Empty)
                {
                    var resultAddress = address.Load(Connection, Transaction, Parameter.CMN_AddressID);
                    var resultOrgUnit = universalcontactdetails.Load(Connection, Transaction, Parameter.UniversalContactDetailsID);
                }
                else
                {
                    universalcontactdetails.CMN_UniversalContactDetailID = Guid.NewGuid();
                    universalcontactdetails.Tenant_RefID = securityTicket.TenantID;
                    universalcontactdetails.Creation_Timestamp = DateTime.Now;
                    universalcontactdetails.IsDeleted = false;

                    address.CMN_BPT_CTM_OrganizationalUnit_AddressID = Guid.NewGuid();
                    address.OrganizationalUnit_RefID = Parameter.OrganizationalUnitID;
                    address.UniversalContactDetail_Address_RefID = universalcontactdetails.CMN_UniversalContactDetailID;
                    address.Tenant_RefID = securityTicket.TenantID;
                    address.Creation_Timestamp = DateTime.Now;
                    address.IsDeleted = false;
                }

                universalcontactdetails.Country_639_1_ISOCode = Parameter.Country_ISOCode;
                universalcontactdetails.Country_Name = Parameter.Country_Name;
                universalcontactdetails.Street_Name = Parameter.StreetName;
                universalcontactdetails.Street_Number = Parameter.StreetNumber;
                universalcontactdetails.Town = Parameter.Town;
                universalcontactdetails.ZIP = Parameter.City_PostalCode;
                universalcontactdetails.IsReadOnly = Parameter.IsReadOnly;
                universalcontactdetails.Save(Connection, Transaction);

                address.AddressType = Parameter.IsBilling ? 2 : 1;
                address.IsPrimary = Parameter.IsPrimary;
                address.Save(Connection, Transaction);
            }

            returnValue = new FR_Guid(address.CMN_BPT_CTM_OrganizationalUnit_AddressID);
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5ACAAD_SOUA_1239 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5ACAAD_SOUA_1239 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ACAAD_SOUA_1239 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ACAAD_SOUA_1239 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_OrganizationalUnit_Address",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ACAAD_SOUA_1239 for attribute P_L5ACAAD_SOUA_1239
		[DataContract]
		public class P_L5ACAAD_SOUA_1239 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public Guid OrganizationalUnitID { get; set; } 
			[DataMember]
			public Guid UniversalContactDetailsID { get; set; } 
			[DataMember]
			public Boolean IsBilling { get; set; } 
			[DataMember]
			public String AddressName { get; set; } 
			[DataMember]
			public String StreetName { get; set; } 
			[DataMember]
			public String StreetNumber { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public Boolean IsPrimary { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public Boolean IsDelete { get; set; } 
			[DataMember]
			public Boolean IsReadOnly { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_OrganizationalUnit_Address(,P_L5ACAAD_SOUA_1239 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_OrganizationalUnit_Address.Invoke(connectionString,P_L5ACAAD_SOUA_1239 Parameter,securityTicket);
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
var parameter = new CL5_APOCustomerAdmin_Address.Atomic.Manipulation.P_L5ACAAD_SOUA_1239();
parameter.CMN_AddressID = ...;
parameter.OrganizationalUnitID = ...;
parameter.UniversalContactDetailsID = ...;
parameter.IsBilling = ...;
parameter.AddressName = ...;
parameter.StreetName = ...;
parameter.StreetNumber = ...;
parameter.Country_Name = ...;
parameter.Country_ISOCode = ...;
parameter.Town = ...;
parameter.IsPrimary = ...;
parameter.City_PostalCode = ...;
parameter.IsDelete = ...;
parameter.IsReadOnly = ...;

*/
