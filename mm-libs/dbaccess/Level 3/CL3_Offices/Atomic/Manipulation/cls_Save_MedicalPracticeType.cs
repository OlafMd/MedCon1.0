/* 
 * Generated on 5.9.2014 17:21:00
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
using CL1_HEC;

namespace CL3_Offices.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_MedicalPracticeType.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_MedicalPracticeType
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3O_SMPT_1719 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            //Put your code here

            if (Parameter.HEC_MedicalPractice_TypeID == Guid.Empty)
            {
                ORM_HEC_MedicalPractice_Type type = new ORM_HEC_MedicalPractice_Type();
                type.HEC_MedicalPractice_TypeID = Guid.NewGuid();
                type.MedicalPracticeType_Name = Parameter.MedicalPracticeType_Name_DictID;
                type.IsDeleted = false;
                type.Tenant_RefID = securityTicket.TenantID;
                type.Save(Connection, Transaction);
                returnValue.Result = type.HEC_MedicalPractice_TypeID;
            }
            else
            {
                var type = ORM_HEC_MedicalPractice_Type.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_Type.Query { HEC_MedicalPractice_TypeID = Parameter.HEC_MedicalPractice_TypeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                if (Parameter.IsDeleted == false)
                {
                    type.MedicalPracticeType_Name = Parameter.MedicalPracticeType_Name_DictID;
                }
                type.IsDeleted = Parameter.IsDeleted;
                type.Save(Connection, Transaction);
                returnValue.Result = type.HEC_MedicalPractice_TypeID;
            }

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3O_SMPT_1719 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3O_SMPT_1719 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3O_SMPT_1719 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3O_SMPT_1719 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_MedicalPracticeType",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3O_SMPT_1719 for attribute P_L3O_SMPT_1719
		[DataContract]
		public class P_L3O_SMPT_1719 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractice_TypeID { get; set; } 
			[DataMember]
			public Dict MedicalPracticeType_Name_DictID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_MedicalPracticeType(,P_L3O_SMPT_1719 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_MedicalPracticeType.Invoke(connectionString,P_L3O_SMPT_1719 Parameter,securityTicket);
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
var parameter = new CL3_Offices.Atomic.Manipulation.P_L3O_SMPT_1719();
parameter.HEC_MedicalPractice_TypeID = ...;
parameter.MedicalPracticeType_Name_DictID = ...;
parameter.IsDeleted = ...;

*/
