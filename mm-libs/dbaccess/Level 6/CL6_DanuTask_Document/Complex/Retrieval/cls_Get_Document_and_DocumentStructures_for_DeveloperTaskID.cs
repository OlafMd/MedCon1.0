/* 
 * Generated on 7/15/2014 4:22:49 PM
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
using CL6_DanuTask_Document.Atomic.Retrieval;

namespace CL6_DanuTask_Document.Complex.Retrieval
{
	/// <summary>
    /// 
   //   Get Documents and DocumentStructures for Developer task ID
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Document_and_DocumentStructures_for_DeveloperTaskID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Document_and_DocumentStructures_for_DeveloperTaskID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DO_GDaDSfDT_1512 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DO_GDaDSfDT_1512 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
            #region UserCode
            var returnValue = new FR_L6DO_GDaDSfDT_1512();
            L6DO_GDaDSfDT_1512 temp = new L6DO_GDaDSfDT_1512();
            P_L6DO_GDSfDT_1500 parStructure = new P_L6DO_GDSfDT_1500();
            parStructure.DeveloperTaskID = Parameter.DeveloperTaskID;
            var documentStructure = cls_Get_DocumentStructures_for_DeveloperTaskID.Invoke(Connection, Transaction, parStructure, securityTicket).Result;

            P_L6DO_GDfDT_1451 parDocument = new P_L6DO_GDfDT_1451();
            parDocument.DeveloperTaskID = Parameter.DeveloperTaskID;
            var documentList = cls_Get_Documents_for_DeveloperTaskID.Invoke(Connection, Transaction, parDocument, securityTicket).Result;

            temp.Documents = documentList;
            temp.DocumentStructures = documentStructure;
            returnValue.Result = temp;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DO_GDaDSfDT_1512 Invoke(string ConnectionString,P_L6DO_GDaDSfDT_1512 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DO_GDaDSfDT_1512 Invoke(DbConnection Connection,P_L6DO_GDaDSfDT_1512 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DO_GDaDSfDT_1512 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DO_GDaDSfDT_1512 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DO_GDaDSfDT_1512 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DO_GDaDSfDT_1512 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DO_GDaDSfDT_1512 functionReturn = new FR_L6DO_GDaDSfDT_1512();
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

				throw new Exception("Exception occured in method cls_Get_Document_and_DocumentStructures_for_DeveloperTaskID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DO_GDaDSfDT_1512 : FR_Base
	{
		public L6DO_GDaDSfDT_1512 Result	{ get; set; }

		public FR_L6DO_GDaDSfDT_1512() : base() {}

		public FR_L6DO_GDaDSfDT_1512(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DO_GDaDSfDT_1512 for attribute P_L6DO_GDaDSfDT_1512
		[DataContract]
		public class P_L6DO_GDaDSfDT_1512 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTaskID { get; set; } 

		}
		#endregion
		#region SClass L6DO_GDaDSfDT_1512 for attribute L6DO_GDaDSfDT_1512
		[DataContract]
		public class L6DO_GDaDSfDT_1512 
		{
			//Standard type parameters
			[DataMember]
			public L6DO_GDSfDT_1500[] DocumentStructures { get; set; } 
			[DataMember]
			public L6DO_GDfDT_1451[] Documents { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DO_GDaDSfDT_1512 cls_Get_Document_and_DocumentStructures_for_DeveloperTaskID(,P_L6DO_GDaDSfDT_1512 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DO_GDaDSfDT_1512 invocationResult = cls_Get_Document_and_DocumentStructures_for_DeveloperTaskID.Invoke(connectionString,P_L6DO_GDaDSfDT_1512 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_Document.Complex.Retrieval.P_L6DO_GDaDSfDT_1512();
parameter.DeveloperTaskID = ...;

*/
