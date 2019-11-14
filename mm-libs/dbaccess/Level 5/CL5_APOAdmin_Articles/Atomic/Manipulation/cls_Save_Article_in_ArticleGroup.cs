
/* 
 * Generated on 11/7/2013 5:27:04 PM
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
using CL1_CMN_PRO;

namespace CL5_APOAdmin_Articles.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Article_in_ArticleGroup.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Article_in_ArticleGroup
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_SAiAG_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var item = new ORM_CMN_PRO_Product_2_ProductGroup();
            if (Parameter.AssignmentID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.AssignmentID);
                if (result.Status != FR_Status.Success || item.AssignmentID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            if (Parameter.IsDeleted == true)
            {
                //var query = new ORM_CMN_PRO_Product_2_ProductGroup.Query();
                //query.CMN_PRO_Product_RefID = Parameter.CMN_PRO_ProductID;
                //query.CMN_PRO_ProductGroup_RefID = Parameter.CMN_PRO_ProductGroupID;
                //ORM_CMN_PRO_Product_2_ProductGroup deletedItem = ORM_CMN_PRO_Product_2_ProductGroup.Query.Search(Connection,Transaction,query).First();

                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.AssignmentID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.AssignmentID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.CMN_PRO_Product_RefID = Parameter.CMN_PRO_ProductID;
            item.CMN_PRO_ProductGroup_RefID = Parameter.CMN_PRO_ProductGroupID;

            return new FR_Guid(item.Save(Connection, Transaction), item.AssignmentID);
            


			//return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AR_SAiAG_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AR_SAiAG_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_SAiAG_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_SAiAG_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Article_in_ArticleGroup",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AR_SAiAG_1623 for attribute P_L5AR_SAiAG_1623
		[DataContract]
		public class P_L5AR_SAiAG_1623 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductGroupID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Article_in_ArticleGroup(,P_L5AR_SAiAG_1623 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Article_in_ArticleGroup.Invoke(connectionString,P_L5AR_SAiAG_1623 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Atomic.Manipulation.P_L5AR_SAiAG_1623();
parameter.AssignmentID = ...;
parameter.CMN_PRO_ProductID = ...;
parameter.CMN_PRO_ProductGroupID = ...;
parameter.IsDeleted = ...;

*/
