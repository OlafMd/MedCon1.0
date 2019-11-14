/* 
 * Generated on 15/10/2014 02:12:55
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
using CL1_CMN_STR;
using CL2_Address.Atomic.Manipulation;
using CL1_CMN;

namespace CL2_Office.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Office_Address.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Office_Address
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2OF_SOA_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here      

            if (Parameter.IsDefaultAddress)
            {
                //set previous flags as non default
                ORM_CMN_STR_Office_Address.Query.Update(Connection, Transaction,
                    new ORM_CMN_STR_Office_Address.Query()
                    {
                        Office_RefID = Parameter.OfficeID,
                        IsDefault = true,
                        IsShippingAddress = Parameter.IsShippingAddress,
                        IsBillingAddress = Parameter.IsBillingAddress
                    },
                    new ORM_CMN_STR_Office_Address.Query()
                    {
                        IsDefault = false
                    }
                );
            }

            var addressID = Guid.Empty;
            if (Parameter.AddressID == Guid.Empty)
            {
                //Create
                var saveAddressParam = new P_L2AD_SA_1755();
                saveAddressParam.CMN_AddressID = Parameter.Address_Save.CMN_AddressID;
                saveAddressParam.CareOf = Parameter.Address_Save.CareOf;
                saveAddressParam.Street_Name = Parameter.Address_Save.Street_Name;
                saveAddressParam.Street_Number = Parameter.Address_Save.Street_Number;
                saveAddressParam.City_PostalCode = Parameter.Address_Save.City_PostalCode;
                saveAddressParam.City_Name = Parameter.Address_Save.City_Name;
                saveAddressParam.Country_Name = Parameter.Address_Save.Country_Name;
                saveAddressParam.Country_ISOCode = Parameter.Address_Save.Country_ISOCode;
                addressID = cls_Save_Address.Invoke(Connection, Transaction, saveAddressParam, securityTicket).Result;

                var OfficeAddress = new ORM_CMN_STR_Office_Address();

                OfficeAddress.CMN_Address_RefID = addressID;
                OfficeAddress.Office_RefID = Parameter.OfficeID;
                OfficeAddress.IsBillingAddress = Parameter.IsBillingAddress;
                OfficeAddress.IsShippingAddress = Parameter.IsShippingAddress;
                OfficeAddress.IsSpecialAddress = Parameter.IsSpecialAddress;
                OfficeAddress.IfSpecialAddress_Name = Parameter.IsSpecialAddress_Name;
                OfficeAddress.IsDefault = Parameter.IsDefaultAddress;
                OfficeAddress.Tenant_RefID = securityTicket.TenantID;
                OfficeAddress.Save(Connection, Transaction);
            }
            else
            {
                //Update
                addressID = Parameter.AddressID;

                var address = new ORM_CMN_Address();
                address.Load(Connection, Transaction, Parameter.AddressID);
                address.CareOf = Parameter.Address_Save.CareOf;
                address.Street_Name = Parameter.Address_Save.Street_Name;
                address.Street_Number = Parameter.Address_Save.Street_Number;
                address.City_PostalCode = Parameter.Address_Save.City_PostalCode;
                address.City_Name = Parameter.Address_Save.City_Name;
                address.Country_Name = Parameter.Address_Save.Country_Name;
                address.Country_ISOCode = Parameter.Address_Save.Country_ISOCode;
                address.Save(Connection, Transaction);

                var queryOfficeAddress = new ORM_CMN_STR_Office_Address.Query();
                queryOfficeAddress.CMN_Address_RefID = Parameter.AddressID;
                queryOfficeAddress.Office_RefID = Parameter.OfficeID;
                queryOfficeAddress.IsDeleted = false;
                var officeAddress = ORM_CMN_STR_Office_Address.Query.Search(Connection, Transaction, queryOfficeAddress).FirstOrDefault();

                officeAddress.IsDefault = Parameter.IsDefaultAddress;
                officeAddress.IsBillingAddress = Parameter.IsBillingAddress;
                officeAddress.IsShippingAddress = Parameter.IsShippingAddress;
                officeAddress.IsSpecialAddress = Parameter.IsSpecialAddress;
                officeAddress.IfSpecialAddress_Name = Parameter.IsSpecialAddress_Name;

                officeAddress.Save(Connection, Transaction);
            }


            #region Update DefaultAdresses

            var defaultShippingAddressQuery = new ORM_CMN_STR_Office_Address.Query();
            defaultShippingAddressQuery.Office_RefID = Parameter.OfficeID;
            defaultShippingAddressQuery.IsDeleted = false;
            defaultShippingAddressQuery.IsDefault = true;
            defaultShippingAddressQuery.IsShippingAddress = true;
            var defaultShippingAddress = ORM_CMN_STR_Office_Address.Query.Search(Connection, Transaction, defaultShippingAddressQuery).SingleOrDefault();

            var defaultBillingAddressQuery = new ORM_CMN_STR_Office_Address.Query();
            defaultBillingAddressQuery.Office_RefID = Parameter.OfficeID;
            defaultBillingAddressQuery.IsDeleted = false;
            defaultBillingAddressQuery.IsDefault = true;
            defaultBillingAddressQuery.IsBillingAddress = true;
            var defaultBillingAddress = ORM_CMN_STR_Office_Address.Query.Search(Connection, Transaction, defaultBillingAddressQuery).SingleOrDefault();

            var office = new ORM_CMN_STR_Office();
            office.Load(Connection, Transaction, Parameter.OfficeID);

            office.Default_BillingAddress_RefID = (defaultBillingAddress != null) ? defaultBillingAddress.CMN_Address_RefID : Guid.Empty;
            office.Default_ShippingAddress_RefID = (defaultShippingAddress != null) ? defaultShippingAddress.CMN_Address_RefID : Guid.Empty;
            office.Save(Connection, Transaction);

            #endregion

            return returnValue;
            #endregion UserCode
        }
        #endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2OF_SOA_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2OF_SOA_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2OF_SOA_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2OF_SOA_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Office_Address",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2OF_SOA_1410 for attribute P_L2OF_SOA_1410
		[DataContract]
		public class P_L2OF_SOA_1410 
		{
			//Standard type parameters
			[DataMember]
			public P_L2AD_SA_1755 Address_Save { get; set; } 
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Guid AddressID { get; set; } 
			[DataMember]
			public Boolean IsShippingAddress { get; set; } 
			[DataMember]
			public Boolean IsBillingAddress { get; set; } 
			[DataMember]
			public Boolean IsSpecialAddress { get; set; } 
			[DataMember]
			public String IsSpecialAddress_Name { get; set; } 
			[DataMember]
			public Boolean IsDefaultAddress { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Office_Address(,P_L2OF_SOA_1410 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Office_Address.Invoke(connectionString,P_L2OF_SOA_1410 Parameter,securityTicket);
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
var parameter = new CL2_Office.Complex.Manipulation.P_L2OF_SOA_1410();
parameter.Address_Save = ...;
parameter.OfficeID = ...;
parameter.AddressID = ...;
parameter.IsShippingAddress = ...;
parameter.IsBillingAddress = ...;
parameter.IsSpecialAddress = ...;
parameter.IsSpecialAddress_Name = ...;
parameter.IsDefaultAddress = ...;

*/
