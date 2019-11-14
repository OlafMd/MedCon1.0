/* 
 * Generated on 9/12/2013 08:33:45
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

namespace CL5_APOAdmin_Supplier.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Supplier_Address.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Supplier_Address
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AAS_SSA_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

			var item = new CL1_CMN_COM.ORM_CMN_COM_CompanyInfo_Address();
            var universalContact = new CL1_CMN.ORM_CMN_UniversalContactDetail();
			if (Parameter.CMN_COM_CompanyInfo_AddressID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.CMN_COM_CompanyInfo_AddressID);
                if (item.Address_UCD_RefID != Guid.Empty)
                {
                    universalContact.Load(Connection, Transaction, item.Address_UCD_RefID);
                }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
                universalContact.IsDeleted = true;
                universalContact.Save(Connection, Transaction);
				return new FR_Guid(item.Save(Connection, Transaction),item.CMN_COM_CompanyInfo_AddressID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.CMN_COM_CompanyInfo_AddressID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
                universalContact.Tenant_RefID = securityTicket.TenantID;
			}

            if (Parameter.IsDefault)
            {
                // Get all default company addresses
                var addresses = CL1_CMN_COM.ORM_CMN_COM_CompanyInfo_Address.Query.Search(Connection, Transaction,
                    new CL1_CMN_COM.ORM_CMN_COM_CompanyInfo_Address.Query
                    {
                        IsDeleted = false,
                        IsDefault = true,
                        IsBilling = Parameter.IsBilling,
                        IsShipping = Parameter.IsShipping,
                        CompanyInfo_RefID = item.CompanyInfo_RefID
                    });
                addresses = addresses.Where(x => x.CMN_COM_CompanyInfo_AddressID != item.CMN_COM_CompanyInfo_AddressID).ToList();
                addresses.ForEach(x => x.IsDefault = false);
                addresses.ForEach(x => x.Save(Connection, Transaction));
            }
            item.IsContact = true;
            item.Address_UCD_RefID = universalContact.CMN_UniversalContactDetailID;
			item.CompanyInfo_RefID = Parameter.CompanyInfo_RefID;
			item.IsBilling = Parameter.IsBilling;
			item.IsShipping = Parameter.IsShipping;
			item.Address_UCD_RefID = universalContact.CMN_UniversalContactDetailID;
            item.IsDefault = Parameter.IsDefault;
            universalContact.CareOf = Parameter.CareOf;
            universalContact.Street_Name = Parameter.Street_Name;
            universalContact.Street_Number = Parameter.Street_Number;
            universalContact.ZIP = Parameter.ZIP;
            universalContact.Town = Parameter.Town;
            universalContact.Country_639_1_ISOCode = Parameter.Country_639_1_ISOCode;
            universalContact.Save(Connection, Transaction);
			return new FR_Guid(item.Save(Connection, Transaction),item.CMN_COM_CompanyInfo_AddressID);
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AAS_SSA_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AAS_SSA_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AAS_SSA_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AAS_SSA_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Supplier_Address",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AAS_SSA_1528 for attribute P_L5AAS_SSA_1528
		[DataContract]
		public class P_L5AAS_SSA_1528 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_COM_CompanyInfo_AddressID { get; set; } 
			[DataMember]
			public Guid CompanyInfo_RefID { get; set; } 
			[DataMember]
			public bool IsBilling { get; set; } 
			[DataMember]
			public bool IsShipping { get; set; } 
			[DataMember]
			public bool IsDefault { get; set; } 
			[DataMember]
			public String CareOf { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Country_639_1_ISOCode { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Supplier_Address(,P_L5AAS_SSA_1528 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Supplier_Address.Invoke(connectionString,P_L5AAS_SSA_1528 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Supplier.Complex.Manipulation.P_L5AAS_SSA_1528();
parameter.CMN_COM_CompanyInfo_AddressID = ...;
parameter.CompanyInfo_RefID = ...;
parameter.IsBilling = ...;
parameter.IsShipping = ...;
parameter.IsDefault = ...;
parameter.CareOf = ...;
parameter.Street_Name = ...;
parameter.Street_Number = ...;
parameter.ZIP = ...;
parameter.Town = ...;
parameter.Country_639_1_ISOCode = ...;
parameter.IsDeleted = ...;

*/
