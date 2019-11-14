/* 
 * Generated on 2/25/2015 10:03:30 AM
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
using CL2_Language.Atomic.Retrieval;
using DLCore_DBCommons;
using System.Reflection;
using System.Xml;
using CL2_DocumentTamplates.DomainManagement;
using CL1_DOC;

namespace CL2_DocumentTemplates.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllDocumentTemplates.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllDocumentTemplates
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2DT_GADT_1349_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L2DT_GADT_1349_Array();

            #region Get Languages

            P_L2LN_GALFTID_1530 param = new P_L2LN_GALFTID_1530();
            param.Tenant_RefID = securityTicket.TenantID;
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, param, securityTicket).Result;

            var languages = DBLanguages.Select(i => new ISOLanguage() { ISO = i.ISO_639_1, LanguageID = i.CMN_LanguageID }).ToList();

            #endregion

            Assembly asm = Assembly.GetExecutingAssembly();
            XmlDocument resource = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(asm.GetManifestResourceStream(DMDocumentTemplates.ResourceFilePath));
            resource.Load(reader);

            var predefinedDocumentTemplates = DMDocumentTemplates.Get_PredefinedDocumentTemplates(Connection, Transaction, securityTicket);

            var globalPropertyMatchingIDs = predefinedDocumentTemplates.Select(i => i.GlobalPropertyMatchingID).ToList();

            var globalMatching2Dict = DBCommonsReader.Instance.GetDictObjectsFromResourceFile(globalPropertyMatchingIDs, resource,
                ORM_DOC_DocumentTemplate.TableName, languages);

            List<L2DT_GADT_1349> documentTemplatesResult = new List<L2DT_GADT_1349>();
            foreach (var template in predefinedDocumentTemplates)
            {
                L2DT_GADT_1349 documentTemplate = new L2DT_GADT_1349();
                documentTemplate.DOC_DocumentTemplateID = DMDocumentTemplates.Get_DocumentTemplates_for_GlobalPropertyMatchingID(Connection, Transaction, template.GlobalPropertyMatchingID, securityTicket);
                documentTemplate.DocumentTemplate_Name = globalMatching2Dict[template.GlobalPropertyMatchingID];
                documentTemplate.GlobalPropertyMatching = template.GlobalPropertyMatchingID;
                documentTemplatesResult.Add(documentTemplate);  
            }

            returnValue.Result = documentTemplatesResult.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2DT_GADT_1349_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2DT_GADT_1349_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2DT_GADT_1349_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2DT_GADT_1349_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2DT_GADT_1349_Array functionReturn = new FR_L2DT_GADT_1349_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllDocumentTemplates",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2DT_GADT_1349_Array : FR_Base
	{
		public L2DT_GADT_1349[] Result	{ get; set; } 
		public FR_L2DT_GADT_1349_Array() : base() {}

		public FR_L2DT_GADT_1349_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2DT_GADT_1349 for attribute L2DT_GADT_1349
		[DataContract]
		public class L2DT_GADT_1349 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_DocumentTemplateID { get; set; } 
			[DataMember]
			public Dict DocumentTemplate_Name { get; set; } 
			[DataMember]
			public string GlobalPropertyMatching { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2DT_GADT_1349_Array cls_Get_AllDocumentTemplates(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2DT_GADT_1349_Array invocationResult = cls_Get_AllDocumentTemplates.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

