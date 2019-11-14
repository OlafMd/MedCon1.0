/* 
 * Generated on 7/16/2013 2:33:24 PM
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
using CL5_KPRS_DueDiligences.Atomic.Retrieval;
using CL5_KPRS_DueDiligences.Complex.Retrieval;

namespace CL6_KPRS_DueDiligence.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RevisionGroup_For_RevisionGroupID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RevisionGroup_For_RevisionGroupID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DD_GRGFRG_1006 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DD_GRGFRG_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6DD_GRGFRG_1006();
            returnValue.Result = new L6DD_GRGFRG_1006();
            P_L5DD_GDDFDD_1402 param = new P_L5DD_GDDFDD_1402();
            param.RevisionGroupID = Parameter.RevisionGroupID;
            returnValue.Result.RevisionGroup = cls_Get_DueDiligence_For_DueDiligenceID.Invoke(Connection, Transaction, param, securityTicket).Result;

            P_L6DD_GRFRG_1005 buildingsParam = new P_L6DD_GRFRG_1005();
            buildingsParam.RevisionGroupID = Parameter.RevisionGroupID;
            returnValue.Result.Revisions = cls_Get_Revisions_For_RevisionGroupID.Invoke(Connection, Transaction, buildingsParam, securityTicket).Result;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DD_GRGFRG_1006 Invoke(string ConnectionString,P_L6DD_GRGFRG_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DD_GRGFRG_1006 Invoke(DbConnection Connection,P_L6DD_GRGFRG_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DD_GRGFRG_1006 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DD_GRGFRG_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DD_GRGFRG_1006 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DD_GRGFRG_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DD_GRGFRG_1006 functionReturn = new FR_L6DD_GRGFRG_1006();
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

				throw new Exception("Exception occured in method cls_Get_RevisionGroup_For_RevisionGroupID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DD_GRGFRG_1006 : FR_Base
	{
		public L6DD_GRGFRG_1006 Result	{ get; set; }

		public FR_L6DD_GRGFRG_1006() : base() {}

		public FR_L6DD_GRGFRG_1006(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DD_GRGFRG_1006 for attribute P_L6DD_GRGFRG_1006
		[DataContract]
		public class P_L6DD_GRGFRG_1006 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionGroupID { get; set; } 

		}
		#endregion
		#region SClass L6DD_GRGFRG_1006 for attribute L6DD_GRGFRG_1006
		[DataContract]
		public class L6DD_GRGFRG_1006 
		{
			//Standard type parameters
			[DataMember]
			public L5DD_GDDFDD_1402 RevisionGroup { get; set; } 
			[DataMember]
			public L6DD_GRFRG_1005[] Revisions { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DD_GRGFRG_1006 cls_Get_RevisionGroup_For_RevisionGroupID(,P_L6DD_GRGFRG_1006 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DD_GRGFRG_1006 invocationResult = cls_Get_RevisionGroup_For_RevisionGroupID.Invoke(connectionString,P_L6DD_GRGFRG_1006 Parameter,securityTicket);
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
var parameter = new CL6_KPRS_DueDiligence.Complex.Retrieval.P_L6DD_GRGFRG_1006();
parameter.RevisionGroupID = ...;

*/