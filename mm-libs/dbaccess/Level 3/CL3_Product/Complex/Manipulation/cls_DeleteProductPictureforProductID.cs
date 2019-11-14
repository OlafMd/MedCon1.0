/* 
 * Generated on 2/9/2015 2:46:15 PM
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
using CL1_CMN_PRO;
using CL1_DOC;

namespace CL3_Product.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_DeleteProductPictureforProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_DeleteProductPictureforProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3_DPPfID_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here

            var productID = Parameter.ProductID;

            ORM_CMN_PRO_Product product = new ORM_CMN_PRO_Product();
            product.Load(Connection, Transaction, productID);

            var DocumentationStructure = product.Product_DocumentationStructure_RefID;

            product.Product_DocumentationStructure_RefID = Guid.Empty;
            product.Save(Connection, Transaction);

            //////////////////////////////////////////////////////////////////////////////////////

            ORM_DOC_Document_2_Structure.Query documentToStructure = new ORM_DOC_Document_2_Structure.Query();
            documentToStructure.StructureHeader_RefID = DocumentationStructure;
            documentToStructure.Tenant_RefID = securityTicket.TenantID;
            documentToStructure.IsDeleted = false;

            var documentStructure = ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, documentToStructure);

            var doc_documentID = documentStructure.Count() > 0 ? documentStructure.Select(x => x.Document_RefID).FirstOrDefault() : Guid.Empty;
       
            ORM_DOC_Document_2_Structure.Query.SoftDelete(Connection, Transaction, documentToStructure);

            //////////////////////////////////////////////////////////////////////////////////////

            ORM_DOC_Document.Query document = new ORM_DOC_Document.Query();
            document.DOC_DocumentID = doc_documentID;
            document.Tenant_RefID = securityTicket.TenantID;
            document.IsDeleted = false;

            ORM_DOC_Document.Query.SoftDelete(Connection, Transaction, document);

            /////////////////////////////////////////////////////////////////////////////////////

            ORM_DOC_Structure.Query structure = new ORM_DOC_Structure.Query();
            structure.Structure_Header_RefID = DocumentationStructure;
            structure.Tenant_RefID = securityTicket.TenantID;
            structure.IsDeleted = false;

            ORM_DOC_Structure.Query.SoftDelete(Connection, Transaction, structure);

            /////////////////////////////////////////////////////////////////////////////////////

            ORM_DOC_Structure_Header.Query structureHeader = new ORM_DOC_Structure_Header.Query();
            structureHeader.DOC_Structure_HeaderID = DocumentationStructure;
            structureHeader.Tenant_RefID = securityTicket.TenantID;
            structureHeader.IsDeleted = false;

            ORM_DOC_Structure_Header.Query.SoftDelete(Connection, Transaction, structureHeader);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L3_DPPfID_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L3_DPPfID_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_DPPfID_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_DPPfID_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_DeleteProductPictureforProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3_DPPfID_1421 for attribute P_L3_DPPfID_1421
		[DataContract]
		public class P_L3_DPPfID_1421 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_DeleteProductPictureforProductID(,P_L3_DPPfID_1421 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_DeleteProductPictureforProductID.Invoke(connectionString,P_L3_DPPfID_1421 Parameter,securityTicket);
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
var parameter = new CL3_Product.Complex.Manipulation.P_L3_DPPfID_1421();
parameter.ProductID = ...;

*/
