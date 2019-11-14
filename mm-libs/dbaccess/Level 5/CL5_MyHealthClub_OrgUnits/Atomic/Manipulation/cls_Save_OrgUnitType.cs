/* 
 * Generated on 8/11/2014 2:49:32 PM
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
using CL3_Offices.Atomic.Manipulation;
using CL1_CMN_STR;

namespace CL5_MyHealthClub_OrgUnits.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_OrgUnitType.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_OrgUnitType
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OU_SOUT_1447 Execute(DbConnection Connection,DbTransaction Transaction,P_L5OU_SOUT_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5OU_SOUT_1447();
			//Put your code here

            List<L5OU_SOUT_1447_DeletingMessage> delMessage = new List<L5OU_SOUT_1447_DeletingMessage>();

            Guid OfficeTypeId = Guid.Empty;
            if (!Parameter.BaseData.IsDeleted)
            {
                OfficeTypeId = cls_Save_OfficeType.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
            }
            else
            {
                ORM_CMN_STR_Office_2_OfficeType existingOffice = ORM_CMN_STR_Office_2_OfficeType.Query.Search(Connection, Transaction, new ORM_CMN_STR_Office_2_OfficeType.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Office_Type_RefID = Parameter.BaseData.OfficeTypeID
                }).FirstOrDefault();

                if (existingOffice != null) //cannot delete
                {
                    delMessage.Add(new L5OU_SOUT_1447_DeletingMessage { DependentTables = "Office" });
                }

                if (delMessage.Count > 0)
                {
                    returnValue.Result.DeletingMessage = delMessage.ToArray();
                }
                else
                {
                    OfficeTypeId = cls_Save_OfficeType.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
                }
            }
            returnValue.Result.ID = OfficeTypeId;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OU_SOUT_1447 Invoke(string ConnectionString,P_L5OU_SOUT_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OU_SOUT_1447 Invoke(DbConnection Connection,P_L5OU_SOUT_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OU_SOUT_1447 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OU_SOUT_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OU_SOUT_1447 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OU_SOUT_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OU_SOUT_1447 functionReturn = new FR_L5OU_SOUT_1447();
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

				throw new Exception("Exception occured in method cls_Save_OrgUnitType",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OU_SOUT_1447 : FR_Base
	{
		public L5OU_SOUT_1447 Result	{ get; set; }

		public FR_L5OU_SOUT_1447() : base() {}

		public FR_L5OU_SOUT_1447(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OU_SOUT_1447 for attribute P_L5OU_SOUT_1447
		[DataContract]
		public class P_L5OU_SOUT_1447 
		{
			//Standard type parameters
			[DataMember]
			public P_L3O_SOT_1643 BaseData { get; set; } 

		}
		#endregion
		#region SClass L5OU_SOUT_1447 for attribute L5OU_SOUT_1447
		[DataContract]
		public class L5OU_SOUT_1447 
		{
			[DataMember]
			public L5OU_SOUT_1447_DeletingMessage[] DeletingMessage { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L5OU_SOUT_1447_DeletingMessage for attribute DeletingMessage
		[DataContract]
		public class L5OU_SOUT_1447_DeletingMessage 
		{
			//Standard type parameters
			[DataMember]
			public String DependentTables { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OU_SOUT_1447 cls_Save_OrgUnitType(,P_L5OU_SOUT_1447 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OU_SOUT_1447 invocationResult = cls_Save_OrgUnitType.Invoke(connectionString,P_L5OU_SOUT_1447 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_OrgUnits.Atomic.Manipulation.P_L5OU_SOUT_1447();
parameter.BaseData = ...;

*/
