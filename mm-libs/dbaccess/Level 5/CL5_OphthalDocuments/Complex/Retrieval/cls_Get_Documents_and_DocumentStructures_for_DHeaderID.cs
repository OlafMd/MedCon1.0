/* 
 * Generated on 8/30/2013 10:55:11 AM
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
using CL3_Document.Atomic.Retrieval;

namespace CL5_OphthalDocuments.Complex.Retrieval
{
	/// <summary>
    /// 
     // Get Documents and DocumentStructures for DocumentHeaderRefID
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Documents_and_DocumentStructures_for_DHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Documents_and_DocumentStructures_for_DHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OD_GDaDSfDG_1146 Execute(DbConnection Connection,DbTransaction Transaction,P_L5OD_GDaDSfDG_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5OD_GDaDSfDG_1146();
            P_L3DO_GDfDH_1108 param1 = new P_L3DO_GDfDH_1108();
            param1.DHeaderID = Parameter.DHeaderID;

            L3DO_GDfDH_1108[] docStructures = cls_Get_DocumentStructures_for_DHeaderID.Invoke(Connection, Transaction, param1, securityTicket).Result;

            P_L3DO_GDfDH_1133 param2 = new P_L3DO_GDfDH_1133();
            param2.DHeaderID = Parameter.DHeaderID;

            L3DO_GDfDH_1133[] document = cls_Get_Documents_for_DHeaderID.Invoke(Connection, Transaction, param2, securityTicket).Result;

            returnValue.Result = new L5OD_GDaDSfDG_1146();
            returnValue.Result.DocumentStructures = docStructures;
            returnValue.Result.Documents = document;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OD_GDaDSfDG_1146 Invoke(string ConnectionString,P_L5OD_GDaDSfDG_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OD_GDaDSfDG_1146 Invoke(DbConnection Connection,P_L5OD_GDaDSfDG_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OD_GDaDSfDG_1146 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OD_GDaDSfDG_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OD_GDaDSfDG_1146 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OD_GDaDSfDG_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OD_GDaDSfDG_1146 functionReturn = new FR_L5OD_GDaDSfDG_1146();
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

				throw new Exception("Exception occured in method cls_Get_Documents_and_DocumentStructures_for_DHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OD_GDaDSfDG_1146 : FR_Base
	{
		public L5OD_GDaDSfDG_1146 Result	{ get; set; }

		public FR_L5OD_GDaDSfDG_1146() : base() {}

		public FR_L5OD_GDaDSfDG_1146(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OD_GDaDSfDG_1146 for attribute P_L5OD_GDaDSfDG_1146
		[DataContract]
		public class P_L5OD_GDaDSfDG_1146 
		{
			//Standard type parameters
			[DataMember]
			public Guid DHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5OD_GDaDSfDG_1146 for attribute L5OD_GDaDSfDG_1146
		[DataContract]
		public class L5OD_GDaDSfDG_1146 
		{
			//Standard type parameters
			[DataMember]
			public L3DO_GDfDH_1108[] DocumentStructures { get; set; } 
			[DataMember]
			public L3DO_GDfDH_1133[] Documents { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OD_GDaDSfDG_1146 cls_Get_Documents_and_DocumentStructures_for_DHeaderID(,P_L5OD_GDaDSfDG_1146 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OD_GDaDSfDG_1146 invocationResult = cls_Get_Documents_and_DocumentStructures_for_DHeaderID.Invoke(connectionString,P_L5OD_GDaDSfDG_1146 Parameter,securityTicket);
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
var parameter = new CL5_OphthalDocuments.Complex.Retrieval.P_L5OD_GDaDSfDG_1146();
parameter.DHeaderID = ...;

*/
