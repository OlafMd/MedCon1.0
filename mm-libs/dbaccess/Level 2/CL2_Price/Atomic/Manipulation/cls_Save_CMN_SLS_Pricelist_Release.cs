/* 
 * Generated on 11/28/2013 4:33:56 PM
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
using CL1_CMN_SLS;

namespace CL2_Price.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CMN_SLS_Pricelist_Release.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CMN_SLS_Pricelist_Release
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2PL_SPR_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new ORM_CMN_SLS_Pricelist_Release();
			if (Parameter.CMN_SLS_Pricelist_ReleaseID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.CMN_SLS_Pricelist_ReleaseID);
			    if (result.Status != FR_Status.Success || item.CMN_SLS_Pricelist_ReleaseID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.CMN_SLS_Pricelist_ReleaseID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.CMN_SLS_Pricelist_ReleaseID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.Pricelist_RefID = Parameter.Pricelist_RefID;
			item.Release_Version = Parameter.Release_Version;
			item.PricelistRelease_Comment = Parameter.PricelistRelease_Comment;
			item.PricelistRelease_ValidFrom = Parameter.PricelistRelease_ValidFrom;
			item.PricelistRelease_ValidTo = Parameter.PricelistRelease_ValidTo;


			return new FR_Guid(item.Save(Connection, Transaction),item.CMN_SLS_Pricelist_ReleaseID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2PL_SPR_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2PL_SPR_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PL_SPR_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PL_SPR_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CMN_SLS_Pricelist_Release",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2PL_SPR_1629 for attribute P_L2PL_SPR_1629
		[DataContract]
		public class P_L2PL_SPR_1629 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_Pricelist_ReleaseID { get; set; } 
			[DataMember]
			public Guid Pricelist_RefID { get; set; } 
			[DataMember]
			public String Release_Version { get; set; } 
			[DataMember]
			public String PricelistRelease_Comment { get; set; } 
			[DataMember]
			public DateTime PricelistRelease_ValidFrom { get; set; } 
			[DataMember]
			public DateTime PricelistRelease_ValidTo { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CMN_SLS_Pricelist_Release(,P_L2PL_SPR_1629 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CMN_SLS_Pricelist_Release.Invoke(connectionString,P_L2PL_SPR_1629 Parameter,securityTicket);
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
var parameter = new CL2_Price.Atomic.Manipulation.P_L2PL_SPR_1629();
parameter.CMN_SLS_Pricelist_ReleaseID = ...;
parameter.Pricelist_RefID = ...;
parameter.Release_Version = ...;
parameter.PricelistRelease_Comment = ...;
parameter.PricelistRelease_ValidFrom = ...;
parameter.PricelistRelease_ValidTo = ...;
parameter.IsDeleted = ...;

*/
