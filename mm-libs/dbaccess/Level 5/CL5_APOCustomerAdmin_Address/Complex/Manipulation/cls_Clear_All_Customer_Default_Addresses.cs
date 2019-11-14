/* 
 * Generated on 1/9/2014 10:48:41
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_CMN_COM;
using CL1_CMN_PER;

namespace CL5_APOCustomerAdmin_Customer.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Clear_All_Customer_Default_Addresses.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Clear_All_Customer_Default_Addresses
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CU_CACDA_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            if (Parameter.IsCompany)
            {
                ORM_CMN_COM_CompanyInfo_Address.Query queryComAdressIsDefault = new ORM_CMN_COM_CompanyInfo_Address.Query();
                queryComAdressIsDefault.IsDefault = true;
                queryComAdressIsDefault.CompanyInfo_RefID = Parameter.CompanyInfoID;
                queryComAdressIsDefault.IsBilling = Parameter.IsBilling;
                queryComAdressIsDefault.IsShipping = !Parameter.IsBilling;

                List<ORM_CMN_COM_CompanyInfo_Address> companyAdresses = ORM_CMN_COM_CompanyInfo_Address.Query.Search(Connection, Transaction, queryComAdressIsDefault);
                if (companyAdresses.Count != 0 || companyAdresses != null)
                {
                    foreach (ORM_CMN_COM_CompanyInfo_Address item1 in companyAdresses)
                    {
                        item1.IsDefault = false;
                        item1.Save(Connection, Transaction);
                    }
                }
            }
            else
            {
                ORM_CMN_PER_PersonInfo_2_Address.Query queryPerAdressIsDefault = new ORM_CMN_PER_PersonInfo_2_Address.Query();
                queryPerAdressIsDefault.IsPrimary = true;
                queryPerAdressIsDefault.CMN_PER_PersonInfo_RefID = Parameter.PersonInfoID;
                queryPerAdressIsDefault.IsAddress_Billing = Parameter.IsBilling;
                queryPerAdressIsDefault.IsAddress_Shipping = !Parameter.IsBilling;

                List<ORM_CMN_PER_PersonInfo_2_Address> personAdresses = ORM_CMN_PER_PersonInfo_2_Address.Query.Search(Connection, Transaction, queryPerAdressIsDefault);
                if (personAdresses.Count != 0 || personAdresses != null)
                {
                    foreach (ORM_CMN_PER_PersonInfo_2_Address item1 in personAdresses)
                    {
                        item1.IsPrimary = false;
                        item1.Save(Connection, Transaction);
                    }
                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CU_CACDA_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CU_CACDA_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CU_CACDA_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CU_CACDA_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Clear_All_Customer_Default_Addresses",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CU_CACDA_1644 for attribute P_L5CU_CACDA_1644
		[DataContract]
		public class P_L5CU_CACDA_1644 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsCompany { get; set; } 
			[DataMember]
			public Guid CompanyInfoID { get; set; } 
			[DataMember]
			public Boolean IsPerson { get; set; } 
			[DataMember]
			public Guid PersonInfoID { get; set; } 
			[DataMember]
			public Boolean IsBilling { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Clear_All_Customer_Default_Addresses(,P_L5CU_CACDA_1644 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Clear_All_Customer_Default_Addresses.Invoke(connectionString,P_L5CU_CACDA_1644 Parameter,securityTicket);
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
var parameter = new CL5_APOCustomerAdmin_Customer.Complex.Manipulation.P_L5CU_CACDA_1644();
parameter.IsCompany = ...;
parameter.CompanyInfoID = ...;
parameter.IsPerson = ...;
parameter.PersonInfoID = ...;
parameter.IsBilling = ...;

*/
