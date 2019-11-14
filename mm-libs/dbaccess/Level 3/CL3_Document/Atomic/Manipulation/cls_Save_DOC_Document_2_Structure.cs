/* 
 * Generated on 7/14/2014 3:58:16 PM
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

namespace CL3_Document.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DOC_Document_2_Structure.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DOC_Document_2_Structure
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3DO_SD2S_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new CL1_DOC.ORM_DOC_Document_2_Structure();
			if (Parameter.AssignmentID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.AssignmentID);
			    if (result.Status != FR_Status.Success || item.AssignmentID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.AssignmentID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.AssignmentID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.Document_RefID = Parameter.Document_RefID;
			item.Structure_RefID = Parameter.Structure_RefID;
			item.StructureHeader_RefID = Parameter.StructureHeader_RefID;
			item.IsPrimaryLocation = Parameter.IsPrimaryLocation;


			return new FR_Guid(item.Save(Connection, Transaction),item.AssignmentID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3DO_SD2S_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3DO_SD2S_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DO_SD2S_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DO_SD2S_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DOC_Document_2_Structure",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3DO_SD2S_1407 for attribute P_L3DO_SD2S_1407
		[DataContract]
		public class P_L3DO_SD2S_1407 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid Document_RefID { get; set; } 
			[DataMember]
			public Guid Structure_RefID { get; set; } 
			[DataMember]
			public Guid StructureHeader_RefID { get; set; } 
			[DataMember]
			public Boolean IsPrimaryLocation { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DOC_Document_2_Structure(,P_L3DO_SD2S_1407 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DOC_Document_2_Structure.Invoke(connectionString,P_L3DO_SD2S_1407 Parameter,securityTicket);
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
var parameter = new CL3_Document.Atomic.Manipulation.P_L3DO_SD2S_1407();
parameter.AssignmentID = ...;
parameter.Document_RefID = ...;
parameter.Structure_RefID = ...;
parameter.StructureHeader_RefID = ...;
parameter.IsPrimaryLocation = ...;
parameter.IsDeleted = ...;

*/
