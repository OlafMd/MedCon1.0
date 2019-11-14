/* 
 * Generated on 3/2/2015 3:26:40 PM
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

namespace CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DocumentTemplate.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DocumentTemplate
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_SDT_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            returnValue.Result = Guid.Empty;
            #region Save
            if (Parameter.DOC_DocumentTemplateID == Guid.Empty)
            {
                ORM_DOC_DocumentTemplate documentTemplate = new ORM_DOC_DocumentTemplate();
                documentTemplate.DOC_DocumentTemplateID = Guid.NewGuid();
                documentTemplate.DocumentTemplate_Name = Parameter.DocumentTemplate_Name;
                documentTemplate.GlobalPropertyMatchingID = "document-templates.custom-printing";
                documentTemplate.TemplateContent = "";
                documentTemplate.Tenant_RefID = securityTicket.TenantID;
                documentTemplate.Save(Connection, Transaction);

                returnValue.Result = documentTemplate.DOC_DocumentTemplateID;
            }
            #endregion
            //=====================Edit or Delete=====================
            else
            {
                ORM_DOC_DocumentTemplate existingDocumentTemplate = ORM_DOC_DocumentTemplate.Query.Search(Connection, Transaction, new ORM_DOC_DocumentTemplate.Query
                {
                    DOC_DocumentTemplateID = Parameter.DOC_DocumentTemplateID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                #region Edit
                if (Parameter.IsDeleted == false)
                {
                    existingDocumentTemplate.DocumentTemplate_Name = Parameter.DocumentTemplate_Name;
                    existingDocumentTemplate.Save(Connection, Transaction);
                }
                #endregion
                #region Delete
                else
                {
                    existingDocumentTemplate.IsDeleted = true;
                    existingDocumentTemplate.Save(Connection, Transaction);
                }
                #endregion

                returnValue.Result = existingDocumentTemplate.DOC_DocumentTemplateID;
            }

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DO_SDT_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DO_SDT_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_SDT_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_SDT_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DocumentTemplate",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DO_SDT_1508 for attribute P_L5DO_SDT_1508
		[DataContract]
		public class P_L5DO_SDT_1508 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_DocumentTemplateID { get; set; } 
			[DataMember]
			public Dict DocumentTemplate_Name { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DocumentTemplate(,P_L5DO_SDT_1508 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DocumentTemplate.Invoke(connectionString,P_L5DO_SDT_1508 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation.P_L5DO_SDT_1508();
parameter.DOC_DocumentTemplateID = ...;
parameter.DocumentTemplate_Name = ...;
parameter.IsDeleted = ...;

*/
