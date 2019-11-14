/* 
 * Generated on 3/4/2014 12:23:49
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

namespace CL2_Office.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Office.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Office
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2O_SO_1529 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            var returnValue = new FR_Guid();

            var item = new CL1_CMN_STR.ORM_CMN_STR_Office();
            if (Parameter.CMN_STR_OfficeID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_STR_OfficeID);
                if (result.Status != FR_Status.Success || item.CMN_STR_OfficeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status =  FR_Status.Error_Internal;
                    return error;
                }
            }

            if(Parameter.IsDeleted == true){
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction),item.CMN_STR_OfficeID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.CMN_STR_OfficeID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.Parent_RefID = Parameter.Parent_RefID;
            item.Country_RefID = Parameter.Country_RefID;
            item.Region_RefID = Parameter.Region_RefID;
            item.Default_BillingAddress_RefID = Parameter.Default_BillingAddress_RefID;
            item.Default_ShippingAddress_RefID = Parameter.Default_ShippingAddress_RefID;
            item.CMN_CAL_CalendarInstance_RefID = Parameter.CMN_CAL_CalendarInstance_RefID;
            item.Default_PhoneNumber = Parameter.Default_PhoneNumber;
            item.Default_FaxNumber = Parameter.Default_FaxNumber;
            item.Office_Name = Parameter.Office_Name;
            item.Office_Description = Parameter.Office_Description;
            item.Office_ShortName = Parameter.Office_ShortName;
            item.IsMockObject = Parameter.IsMockObject;
            item.Office_InternalName = Parameter.Office_InternalName;
            item.Office_InternalNumber = Parameter.Office_InternalNumber;

            return new FR_Guid(item.Save(Connection, Transaction),item.CMN_STR_OfficeID);
	    }
	    #endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2O_SO_1529 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2O_SO_1529 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2O_SO_1529 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2O_SO_1529 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Office",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2O_SO_1529 for attribute P_L2O_SO_1529
		[DataContract]
		public class P_L2O_SO_1529 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Guid Country_RefID { get; set; } 
			[DataMember]
			public Guid Region_RefID { get; set; } 
			[DataMember]
			public Guid Default_BillingAddress_RefID { get; set; } 
			[DataMember]
			public Guid Default_ShippingAddress_RefID { get; set; } 
			[DataMember]
			public Guid CMN_CAL_CalendarInstance_RefID { get; set; } 
			[DataMember]
			public String Default_PhoneNumber { get; set; } 
			[DataMember]
			public String Default_FaxNumber { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public Dict Office_Description { get; set; } 
			[DataMember]
			public String Office_ShortName { get; set; } 
			[DataMember]
			public Boolean IsMockObject { get; set; } 
			[DataMember]
			public String Office_InternalName { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public String Office_InternalNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Office(,P_L2O_SO_1529 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Office.Invoke(connectionString,P_L2O_SO_1529 Parameter,securityTicket);
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
var parameter = new CL2_Office.Atomic.Manipulation.P_L2O_SO_1529();
parameter.CMN_STR_OfficeID = ...;
parameter.Parent_RefID = ...;
parameter.Country_RefID = ...;
parameter.Region_RefID = ...;
parameter.Default_BillingAddress_RefID = ...;
parameter.Default_ShippingAddress_RefID = ...;
parameter.CMN_CAL_CalendarInstance_RefID = ...;
parameter.Default_PhoneNumber = ...;
parameter.Default_FaxNumber = ...;
parameter.Office_Name = ...;
parameter.Office_Description = ...;
parameter.Office_ShortName = ...;
parameter.IsMockObject = ...;
parameter.Office_InternalName = ...;
parameter.IsDeleted = ...;
parameter.Office_InternalNumber = ...;

*/
