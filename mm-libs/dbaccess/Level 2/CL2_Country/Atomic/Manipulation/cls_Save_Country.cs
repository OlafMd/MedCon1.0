/* 
 * Generated on 14/10/2013 11:48:12
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_CMN;

namespace CL2_Currency.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Country.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Country
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2CN_SC_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();
            var item = new ORM_CMN_Country();
            if (Parameter.CMN_CountryID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_CountryID);
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_CountryID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.CMN_CountryID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.Default_Language_RefID = Parameter.Default_Language_RefID;
            item.Default_Currency_RefID = Parameter.Default_Currency_RefID;
            item.Country_Name = Parameter.Country_Name;
            item.Country_ISOCode_Alpha2 = Parameter.Country_ISOCode_Alpha2;
            item.Country_ISOCode_Alpha3 = Parameter.Country_ISOCode_Alpha3;
            item.Country_ISOCode_Numeric = Parameter.Country_ISOCode_Numeric;

            return new FR_Guid(item.Save(Connection, Transaction), item.CMN_CountryID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2CN_SC_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2CN_SC_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2CN_SC_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2CN_SC_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Country",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2CN_SC_1130 for attribute P_L2CN_SC_1130
		[DataContract]
		public class P_L2CN_SC_1130 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_CountryID { get; set; } 
			[DataMember]
			public Guid Default_Language_RefID { get; set; } 
			[DataMember]
			public Guid Default_Currency_RefID { get; set; } 
			[DataMember]
			public Dict Country_Name { get; set; } 
			[DataMember]
			public String Country_ISOCode_Alpha2 { get; set; } 
			[DataMember]
			public String Country_ISOCode_Alpha3 { get; set; } 
			[DataMember]
			public int Country_ISOCode_Numeric { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Country(,P_L2CN_SC_1130 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Country.Invoke(connectionString,P_L2CN_SC_1130 Parameter,securityTicket);
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
var parameter = new CL2_Currency.Atomic.Manipulation.P_L2CN_SC_1130();
parameter.CMN_CountryID = ...;
parameter.Default_Language_RefID = ...;
parameter.Default_Currency_RefID = ...;
parameter.Country_Name = ...;
parameter.Country_ISOCode_Alpha2 = ...;
parameter.Country_ISOCode_Alpha3 = ...;
parameter.Country_ISOCode_Numeric = ...;
parameter.IsDeleted = ...;

*/
