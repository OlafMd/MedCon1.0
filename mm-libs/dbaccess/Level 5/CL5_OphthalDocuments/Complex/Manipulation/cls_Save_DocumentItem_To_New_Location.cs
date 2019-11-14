/* 
 * Generated on 8/30/2013 10:57:02 AM
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
using CL1_DOC;

namespace CL5_OphthalDocuments.Complex.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DocumentItem_To_New_Location.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DocumentItem_To_New_Location
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OD_SDTNL_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            if (Parameter.ItemID == Guid.Empty)
            {
                var error = new FR_Guid();
                error.ErrorMessage = "ItemID can not be empty";
                error.Status = FR_Status.Error_Internal;
                return error;
            }


            #region DocumentPackage

            if (Parameter.isDocumentPackage == true)
            {
                var item = new ORM_DOC_Structure();

                var result = item.Load(Connection, Transaction, Parameter.ItemID);
                if (result.Status != FR_Status.Success || item.DOC_StructureID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }

                item.Parent_RefID = Parameter.ParentID;

                return new FR_Guid(item.Save(Connection, Transaction), item.DOC_StructureID);
            }

            #endregion

            #region Document

            if (Parameter.isDocument == true)
            {
                var item1 = new ORM_DOC_Document_2_Structure();

                var assigment = new ORM_DOC_Document_2_Structure.Query();
                assigment.Document_RefID = Parameter.ItemID;
                assigment.IsDeleted = false;

                var assignments = ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, assigment);

                foreach (var assign in assignments)
                {

                    assign.Structure_RefID = Parameter.ParentID;
                    assign.Save(Connection, Transaction);

                }

                return new FR_Guid();


            }
            #endregion
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OD_SDTNL_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OD_SDTNL_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OD_SDTNL_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OD_SDTNL_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DocumentItem_To_New_Location",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OD_SDTNL_1714 for attribute P_L5OD_SDTNL_1714
		[DataContract]
		public class P_L5OD_SDTNL_1714 
		{
			//Standard type parameters
			[DataMember]
			public Guid ItemID { get; set; } 
			[DataMember]
			public Guid ParentID { get; set; } 
			[DataMember]
			public bool isDocumentPackage { get; set; } 
			[DataMember]
			public bool isDocument { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DocumentItem_To_New_Location(,P_L5OD_SDTNL_1714 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DocumentItem_To_New_Location.Invoke(connectionString,P_L5OD_SDTNL_1714 Parameter,securityTicket);
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
var parameter = new CL5_OphthalDocuments.Complex.Manipulation.P_L5OD_SDTNL_1714();
parameter.ItemID = ...;
parameter.ParentID = ...;
parameter.isDocumentPackage = ...;
parameter.isDocument = ...;

*/
