/* 
 * Generated on 11/21/2014 9:47:27 AM
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
using CL1_TMP_PRO;
using CL1_TMS_PRO;

namespace CL6_DanuTask_User.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ProjectMemberType.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ProjectMemberType
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6US_SPMT_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            //If no id, create new element
            if (Parameter.Type_ID == null || Parameter.Type_ID == Guid.Empty)
            {
                ORM_TMP_PRO_ProjectMember_Type newType = new ORM_TMP_PRO_ProjectMember_Type();
                newType.ProjectMemberType_Name = Parameter.Type_name;
                newType.Color = Parameter.Color;
                newType.Tenant_RefID = securityTicket.TenantID;
                return new FR_Guid(newType.Save(Connection, Transaction),newType.TMP_PRO_ProjectMember_TypeID);
            }

            //If existing load
            ORM_TMP_PRO_ProjectMember_Type tempType = new ORM_TMP_PRO_ProjectMember_Type();
            var resultStatus = tempType.Load(Connection, Transaction, Parameter.Type_ID);
            if (resultStatus.Status != FR_Status.Success || tempType.TMP_PRO_ProjectMember_TypeID == Guid.Empty)
            {
                var error = new FR_Guid();
                error.ErrorMessage = "No Such ID";
                error.Status = FR_Status.Error_Internal;
                return error;
            }

            //If deleted, delete and replace
            if (Parameter.Type_isDeleted)
            {
                tempType.IsDeleted = true;
                resultStatus = tempType.Save(Connection, Transaction);

                if (resultStatus.Status != FR_Status.Success || tempType.TMP_PRO_ProjectMember_TypeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }

                ORM_TMS_PRO_ProjectMember.Query searchQuery = new ORM_TMS_PRO_ProjectMember.Query();
                searchQuery.ProjectMember_Type_RefID = Parameter.Type_ID;

                ORM_TMS_PRO_ProjectMember.Query updateQuery = new ORM_TMS_PRO_ProjectMember.Query();
                updateQuery.ProjectMember_Type_RefID = Parameter.Type_ReplacementTypeID;

                ORM_TMS_PRO_ProjectMember.Query.Update(Connection, Transaction, searchQuery, updateQuery);

                return new FR_Guid();
            }
            //Update name
            tempType.ProjectMemberType_Name = Parameter.Type_name;
            tempType.Color = Parameter.Color;
            return new FR_Guid(tempType.Save(Connection, Transaction), tempType.TMP_PRO_ProjectMember_TypeID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6US_SPMT_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6US_SPMT_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6US_SPMT_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6US_SPMT_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ProjectMemberType",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6US_SPMT_1448 for attribute P_L6US_SPMT_1448
		[DataContract]
		public class P_L6US_SPMT_1448 
		{
			//Standard type parameters
			[DataMember]
			public Guid Type_ID { get; set; } 
			[DataMember]
			public Dict Type_name { get; set; } 
			[DataMember]
			public bool Type_isDeleted { get; set; } 
			[DataMember]
			public Guid Type_ReplacementTypeID { get; set; } 
			[DataMember]
			public String Color { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ProjectMemberType(,P_L6US_SPMT_1448 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ProjectMemberType.Invoke(connectionString,P_L6US_SPMT_1448 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_User.Complex.Manipulation.P_L6US_SPMT_1448();
parameter.Type_ID = ...;
parameter.Type_name = ...;
parameter.Type_isDeleted = ...;
parameter.Type_ReplacementTypeID = ...;
parameter.Color = ...;

*/
