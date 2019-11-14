/* 
 * Generated on 8/12/2013 4:13:13 PM
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
using CL1_RES_DUD;

namespace CL5_KPRS_DueDiligences.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Questionnaires_for_RevisionGroupID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Questionnaires_for_RevisionGroupID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DD_GQfRGI Execute(DbConnection Connection,DbTransaction Transaction,P_L6DD_GQfRGI_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6DD_GQfRGI();
            returnValue.Result = new L6DD_GQfRGI();
            //Put your code here
            var revisions = ORM_RES_DUD_Revision.Query.Search(Connection, Transaction, new ORM_RES_DUD_Revision.Query()
            {
                RevisionGroup_RefID = Parameter.RevisionGroupID,
                Tenant_RefID = securityTicket.TenantID
            });
            if (revisions == null || revisions.Count == 0)
            {
                return null;
            }
            returnValue.Result.QuestionnaireVersions = revisions.Select(x => x.QuestionnaireVersion_RefID).Distinct().ToArray();
                       

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DD_GQfRGI Invoke(string ConnectionString,P_L6DD_GQfRGI_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DD_GQfRGI Invoke(DbConnection Connection,P_L6DD_GQfRGI_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DD_GQfRGI Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DD_GQfRGI_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DD_GQfRGI Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DD_GQfRGI_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DD_GQfRGI functionReturn = new FR_L6DD_GQfRGI();
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

				throw new Exception("Exception occured in method cls_Get_Questionnaires_for_RevisionGroupID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DD_GQfRGI : FR_Base
	{
		public L6DD_GQfRGI Result	{ get; set; }

		public FR_L6DD_GQfRGI() : base() {}

		public FR_L6DD_GQfRGI(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DD_GQfRGI_1503 for attribute P_L6DD_GQfRGI_1503
		[DataContract]
		public class P_L6DD_GQfRGI_1503 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionGroupID { get; set; } 

		}
		#endregion
		#region SClass L6DD_GQfRGI for attribute L6DD_GQfRGI
		[DataContract]
		public class L6DD_GQfRGI 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] QuestionnaireVersions { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DD_GQfRGI cls_Get_Questionnaires_for_RevisionGroupID(,P_L6DD_GQfRGI_1503 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DD_GQfRGI invocationResult = cls_Get_Questionnaires_for_RevisionGroupID.Invoke(connectionString,P_L6DD_GQfRGI_1503 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_DueDiligences.Complex.Retrieval.P_L6DD_GQfRGI_1503();
parameter.RevisionGroupID = ...;

*/