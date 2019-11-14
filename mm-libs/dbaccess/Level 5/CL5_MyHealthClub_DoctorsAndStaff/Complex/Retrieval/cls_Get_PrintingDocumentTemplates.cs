/* 
 * Generated on 3/2/2015 4:54:11 PM
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
using CL2_DocumentTemplates.Complex.Retrieval;
using CL1_DOC;

namespace CL5_MyHealthClub_DoctorsAndStaff.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PrintingDocumentTemplates.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PrintingDocumentTemplates
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DO_GPDT_0957_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5DO_GPDT_0957_Array();

            var predefinedPrintingSetting = cls_Get_AllDocumentTemplates.Invoke(Connection, Transaction, securityTicket).Result.Where(x => x.GlobalPropertyMatching.Contains("default-printing")).ToList();

            List<L5DO_GPDT_0957> resultSettings = new List<L5DO_GPDT_0957>();

            foreach (var item in predefinedPrintingSetting)
            {
                L5DO_GPDT_0957 settings = new L5DO_GPDT_0957();
                settings.DOC_DocumentTemplateID = item.DOC_DocumentTemplateID;
                settings.DocumentTemplate_Name = item.DocumentTemplate_Name;
                settings.GlobalPropertyMatchingID = item.GlobalPropertyMatching;
                resultSettings.Add(settings);
            }

            List<ORM_DOC_DocumentTemplate> documentTemplate = ORM_DOC_DocumentTemplate.Query.Search(Connection, Transaction, new ORM_DOC_DocumentTemplate.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                GlobalPropertyMatchingID = "document-templates.custom-printing"
            }).ToList();

            foreach (var item in documentTemplate)
            {
                L5DO_GPDT_0957 settings = new L5DO_GPDT_0957();
                settings.DOC_DocumentTemplateID = item.DOC_DocumentTemplateID;
                settings.DocumentTemplate_Name = item.DocumentTemplate_Name;
                settings.GlobalPropertyMatchingID = item.GlobalPropertyMatchingID;
                resultSettings.Add(settings);
            }

            returnValue.Result = resultSettings.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DO_GPDT_0957_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DO_GPDT_0957_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DO_GPDT_0957_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DO_GPDT_0957_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DO_GPDT_0957_Array functionReturn = new FR_L5DO_GPDT_0957_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_PrintingDocumentTemplates",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DO_GPDT_0957_Array : FR_Base
	{
		public L5DO_GPDT_0957[] Result	{ get; set; } 
		public FR_L5DO_GPDT_0957_Array() : base() {}

		public FR_L5DO_GPDT_0957_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5DO_GPDT_0957 for attribute L5DO_GPDT_0957
		[DataContract]
		public class L5DO_GPDT_0957 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_DocumentTemplateID { get; set; } 
			[DataMember]
			public Dict DocumentTemplate_Name { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DO_GPDT_0957_Array cls_Get_PrintingDocumentTemplates(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DO_GPDT_0957_Array invocationResult = cls_Get_PrintingDocumentTemplates.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

