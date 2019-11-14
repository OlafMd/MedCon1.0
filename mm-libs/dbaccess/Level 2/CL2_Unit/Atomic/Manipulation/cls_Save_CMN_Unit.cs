/* 
 * Generated on 11/5/2013 9:37:21 AM
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

namespace CL2_Unit.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CMN_Unit.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CMN_Unit
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2UT_SU_1250 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

            var returnValue = new FR_Guid();

            var item = new ORM_CMN_Unit();
            if (Parameter.CMN_UnitID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_UnitID);
                if (result.Status != FR_Status.Success || item.CMN_UnitID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_UnitID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.CMN_UnitID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.Label = Parameter.Label;
            item.Abbreviation = Parameter.Abbreviation;
            item.ISOCode = Parameter.ISOCode;


            return new FR_Guid(item.Save(Connection, Transaction), item.CMN_UnitID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2UT_SU_1250 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2UT_SU_1250 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2UT_SU_1250 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2UT_SU_1250 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2UT_SU_1250 for attribute P_L2UT_SU_1250
		[DataContract]
		public class P_L2UT_SU_1250 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_UnitID { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 
			[DataMember]
			public Dict Abbreviation { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CMN_Unit(P_L2UT_SU_1250 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_CMN_Unit.Invoke(connectionString,P_L2UT_SU_1250 Parameter,securityTicket);
	 return result;
}
*/