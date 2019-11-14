/* 
 * Generated on 30/7/2014 01:06:15
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
using CL1_CMN_COM;

namespace CL5_APOCustomerAdmin_Address.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CompanyAdress.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CompanyAdress
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_SCS_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            var adress = new ORM_CMN_UniversalContactDetail();
            var company2Adress = new ORM_CMN_COM_CompanyInfo_Address();
            if (Parameter.CMN_AddressID != Guid.Empty)
            {
                var result = adress.Load(Connection, Transaction, Parameter.CMN_AddressID);
                if (result.Status != FR_Status.Success || adress.CMN_UniversalContactDetailID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                company2Adress.Address_UCD_RefID = Parameter.CMN_AddressID;
            }

            if (Parameter.CMN_COM_CompanyInfo_AddressID != Guid.Empty)
            {
                var result = company2Adress.Load(Connection, Transaction, Parameter.CMN_COM_CompanyInfo_AddressID);
                if (result.Status != FR_Status.Success || company2Adress.CMN_COM_CompanyInfo_AddressID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            if (Parameter.IsDeleted == true)
            {
                adress.IsDeleted = true;
                company2Adress.IsDeleted = true;
                company2Adress.Save(Connection, Transaction);
                return new FR_Guid(adress.Save(Connection, Transaction), adress.CMN_UniversalContactDetailID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.CMN_AddressID == Guid.Empty)
            {
                company2Adress.Address_UCD_RefID = adress.CMN_UniversalContactDetailID;
                company2Adress.Tenant_RefID = securityTicket.TenantID;
                adress.Tenant_RefID = securityTicket.TenantID;
            }

            adress.Street_Name = Parameter.Street_Name;
            adress.Street_Number = Parameter.Street_Number;
            adress.Town = Parameter.City_Name;
            adress.ZIP = Parameter.City_PostalCode;
            adress.Country_Name = Parameter.Country_Name;
            adress.Region_Code = Parameter.Country_ISOCode;

            company2Adress.IsDefault = Parameter.IsDefault;
            company2Adress.Address_Description = Parameter.AddressName;
            company2Adress.CompanyInfo_RefID = Parameter.CompanyInfo_RefID;
            company2Adress.IsBilling = Parameter.IsAddress_Billing;
            company2Adress.IsShipping = Parameter.IsAddress_Shipping;

            company2Adress.Save(Connection, Transaction);
            return new FR_Guid(adress.Save(Connection, Transaction), adress.CMN_UniversalContactDetailID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CA_SCS_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CA_SCS_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_SCS_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_SCS_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CompanyAdress",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CA_SCS_1333 for attribute P_L5CA_SCS_1333
		[DataContract]
		public class P_L5CA_SCS_1333 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public String AddressName { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsAddress_Billing { get; set; } 
			[DataMember]
			public Boolean IsAddress_Shipping { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfo_AddressID { get; set; } 
			[DataMember]
			public Guid CompanyInfo_RefID { get; set; } 
			[DataMember]
			public bool IsDefault { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CompanyAdress(,P_L5CA_SCS_1333 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CompanyAdress.Invoke(connectionString,P_L5CA_SCS_1333 Parameter,securityTicket);
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
var parameter = new CL5_APOCustomerAdmin_Address.Atomic.Manipulation.P_L5CA_SCS_1333();
parameter.CMN_AddressID = ...;
parameter.AddressName = ...;
parameter.Street_Name = ...;
parameter.Street_Number = ...;
parameter.City_Name = ...;
parameter.City_PostalCode = ...;
parameter.Country_Name = ...;
parameter.Country_ISOCode = ...;
parameter.IsDeleted = ...;
parameter.IsAddress_Billing = ...;
parameter.IsAddress_Shipping = ...;
parameter.CMN_COM_CompanyInfo_AddressID = ...;
parameter.CompanyInfo_RefID = ...;
parameter.IsDefault = ...;

*/
