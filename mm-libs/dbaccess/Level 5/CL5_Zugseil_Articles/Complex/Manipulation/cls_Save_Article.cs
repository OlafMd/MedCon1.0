/* 
 * Generated on 11/6/2014 4:24:05 PM
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
using CL1_CMN;
using CL1_CMN_PRO;
using CL1_DOC;

namespace CL5_Zugseil_Articles.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Article.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Article
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_SA_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            var languageQuery = new ORM_CMN_Language.Query();
            languageQuery.Tenant_RefID = securityTicket.TenantID;
            languageQuery.IsDeleted = false;
            var languages = ORM_CMN_Language.Query.Search(Connection, Transaction, languageQuery);

            var product = new ORM_CMN_PRO_Product();

            if (Parameter.ArticleID == Guid.Empty)
            {
                #region ORM_CMN_PRO_Product

                product = new ORM_CMN_PRO_Product();
                product.CMN_PRO_ProductID = Guid.NewGuid();
                product.ProductITL = Guid.NewGuid().ToString();
              
                product.IsProduct_Article = true;
                product.IsProductAvailableForOrdering = true;
                product.IsImportedFromExternalCatalog = false;

                product.Product_Name = new Dict(ORM_CMN_PRO_Product.TableName);
                product.Product_Description = new Dict(ORM_CMN_PRO_Product.TableName);

                product.PackageInfo_RefID = Guid.NewGuid();

                product.Creation_Timestamp = DateTime.Now;
                product.Tenant_RefID = securityTicket.TenantID;
                product.IsDeleted = Parameter.IsDeleted;


                #region Product picture

                if (Parameter.Image != null && Parameter.Image.Document_ID != Guid.Empty)
                {

                    ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                    structureHeader.Label = "Product picture";
                    structureHeader.Tenant_RefID = securityTicket.TenantID;
                    structureHeader.Save(Connection, Transaction);

                    ORM_DOC_Structure structure = new ORM_DOC_Structure();
                    structure.Label = "Product picture";
                    structure.Structure_Header_RefID = structureHeader.DOC_Structure_HeaderID;
                    structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                    structure.Tenant_RefID = securityTicket.TenantID;
                    structure.Save(Connection, Transaction);

                    ORM_DOC_Document document = new ORM_DOC_Document();
                    document.DOC_DocumentID = Parameter.Image.Document_ID;
                    document.Tenant_RefID = securityTicket.TenantID;
                    document.Save(Connection, Transaction);

                    ORM_DOC_Document_2_Structure documentStructure = new ORM_DOC_Document_2_Structure();
                    documentStructure.Document_RefID = document.DOC_DocumentID;
                    documentStructure.Structure_RefID = structure.DOC_StructureID;
                    documentStructure.StructureHeader_RefID = structureHeader.DOC_Structure_HeaderID;
                    documentStructure.Tenant_RefID = securityTicket.TenantID;
                    documentStructure.Save(Connection, Transaction);

                    ORM_DOC_DocumentRevision documentRevision = new ORM_DOC_DocumentRevision();
                    documentRevision.Document_RefID = document.DOC_DocumentID;
                    documentRevision.Revision = 1;
                    documentRevision.IsLocked = false;
                    documentRevision.IsLastRevision = true;
                    documentRevision.UploadedByAccount = securityTicket.AccountID;
                    documentRevision.File_Name = Parameter.Image.File_Name;
                    documentRevision.File_Description = Parameter.Image.File_Description;
                    documentRevision.File_SourceLocation = Parameter.Image.File_Source_Location;
                    documentRevision.File_ServerLocation = Parameter.Image.File_Server_Location;
                    documentRevision.File_MIMEType = Parameter.Image.File_MimeType;
                    documentRevision.File_Extension = Parameter.Image.File_Extension;
                    documentRevision.File_Size_Bytes = Parameter.Image.File_Size_Bytes;
                    documentRevision.Tenant_RefID = securityTicket.TenantID;
                    documentRevision.Save(Connection, Transaction);

                    //add relation for product picture with product
                    product.Product_DocumentationStructure_RefID = structureHeader.DOC_Structure_HeaderID;
                }

                #endregion

                product.Save(Connection, Transaction);

                #endregion
            }
            else
            {
                product.Load(Connection, Transaction, Parameter.ArticleID);

                #region Product picture

                if (Parameter.Image != null && Parameter.Image.Document_ID != Guid.Empty)
                {

                    ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                    structureHeader.Label = "Product picture";
                    structureHeader.Tenant_RefID = securityTicket.TenantID;
                    structureHeader.Save(Connection, Transaction);

                    ORM_DOC_Structure structure = new ORM_DOC_Structure();
                    structure.Label = "Product picture";
                    structure.Structure_Header_RefID = structureHeader.DOC_Structure_HeaderID;
                    structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                    structure.Tenant_RefID = securityTicket.TenantID;
                    structure.Save(Connection, Transaction);

                    ORM_DOC_Document document = new ORM_DOC_Document();
                    document.DOC_DocumentID = Parameter.Image.Document_ID;
                    document.Tenant_RefID = securityTicket.TenantID;
                    document.Save(Connection, Transaction);

                    ORM_DOC_Document_2_Structure documentStructure = new ORM_DOC_Document_2_Structure();
                    documentStructure.Document_RefID = document.DOC_DocumentID;
                    documentStructure.Structure_RefID = structure.DOC_StructureID;
                    documentStructure.StructureHeader_RefID = structureHeader.DOC_Structure_HeaderID;
                    documentStructure.Tenant_RefID = securityTicket.TenantID;
                    documentStructure.Save(Connection, Transaction);

                    ORM_DOC_DocumentRevision documentRevision = new ORM_DOC_DocumentRevision();
                    documentRevision.Document_RefID = document.DOC_DocumentID;
                    documentRevision.Revision = 1;
                    documentRevision.IsLocked = false;
                    documentRevision.IsLastRevision = true;
                    documentRevision.UploadedByAccount = securityTicket.AccountID;
                    documentRevision.File_Name = Parameter.Image.File_Name;
                    documentRevision.File_Description = Parameter.Image.File_Description;
                    documentRevision.File_SourceLocation = Parameter.Image.File_Source_Location;
                    documentRevision.File_ServerLocation = Parameter.Image.File_Server_Location;
                    documentRevision.File_MIMEType = Parameter.Image.File_MimeType;
                    documentRevision.File_Extension = Parameter.Image.File_Extension;
                    documentRevision.File_Size_Bytes = Parameter.Image.File_Size_Bytes;
                    documentRevision.Tenant_RefID = securityTicket.TenantID;
                    documentRevision.Save(Connection, Transaction);

                    //add relation for product picture with product
                    product.Product_DocumentationStructure_RefID = structureHeader.DOC_Structure_HeaderID;

                }
                else
                {
                    //  if (Parameter.Image.IsForDeleting)  if product image has to be deleted
                }

                #endregion
            }


            #region ORM_CMN_PRO_Product

            product.Product_Number = Parameter.ProductNumber;

            foreach (var language in languages)
            {
                product.Product_Name.UpdateEntry(language.CMN_LanguageID, Parameter.ArticleName);
                product.Product_Description.UpdateEntry(language.CMN_LanguageID, Parameter.Description);
            }

            product.ProductType_RefID = Guid.Empty;

            product.IsPlaceholderArticle = Parameter.IsDummy;

            product.ProductSuccessor_RefID = Guid.Empty;
            product.IsDeleted = Parameter.IsDeleted;
            product.Save(Connection, Transaction);
            


            #endregion


            //#region ORM_CMN_PRO_Product_2_ProductCode

            //var product2CodeQuery = new ORM_CMN_PRO_Product_2_ProductCode.Query();
            //product2CodeQuery.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
            //product2CodeQuery.Tenant_RefID = securityTicket.TenantID;
            //product2CodeQuery.IsDeleted = false;

            //var productCodeAssignment = ORM_CMN_PRO_Product_2_ProductCode.Query.Search(Connection, Transaction, product2CodeQuery).SingleOrDefault();

            //if (productCodeAssignment == null)
            //{
            //    #region ORM_CMN_PRO_ProductCode
            #region Variant
            //Create default varient
            var defaultVarient = new ORM_CMN_PRO_Product_Variant();
            defaultVarient.CMN_PRO_Product_VariantID = Guid.NewGuid();
            defaultVarient.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
            defaultVarient.IsStandardProductVariant = true;
            defaultVarient.Tenant_RefID = securityTicket.TenantID;
            defaultVarient.VariantName = new Dict(ORM_CMN_PRO_Product_Variant.TableName);


            foreach (var language in languages)
            {
                defaultVarient.VariantName.UpdateEntry(language.CMN_LanguageID, String.Empty);
            }

            defaultVarient.Save(Connection, Transaction);
            #endregion

            returnValue.Result = product.CMN_PRO_ProductID;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AR_SA_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AR_SA_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_SA_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_SA_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Article",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AR_SA_1614 for attribute P_L5AR_SA_1614
		[DataContract]
		public class P_L5AR_SA_1614 
		{
			[DataMember]
			public P_L5AR_SA_1614_Image Image { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 
			[DataMember]
			public String ProductNumber { get; set; } 
			[DataMember]
			public String ArticleName { get; set; } 
			[DataMember]
			public String Description { get; set; } 
			[DataMember]
			public bool IsDummy { get; set; } 
			[DataMember]
			public bool IsRegularArticle { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5AR_SA_1614_Image for attribute Image
		[DataContract]
		public class P_L5AR_SA_1614_Image 
		{
			//Standard type parameters
			[DataMember]
			public Guid Document_ID { get; set; } 
			[DataMember]
			public string File_Name { get; set; } 
			[DataMember]
			public string File_Description { get; set; } 
			[DataMember]
			public string File_Source_Location { get; set; } 
			[DataMember]
			public string File_Server_Location { get; set; } 
			[DataMember]
			public string File_MimeType { get; set; } 
			[DataMember]
			public string File_Extension { get; set; } 
			[DataMember]
			public int File_Size_Bytes { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Article(,P_L5AR_SA_1614 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Article.Invoke(connectionString,P_L5AR_SA_1614 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Articles.Complex.Manipulation.P_L5AR_SA_1614();
parameter.Image = ...;

parameter.ArticleID = ...;
parameter.ProductNumber = ...;
parameter.ArticleName = ...;
parameter.Description = ...;
parameter.IsDummy = ...;
parameter.IsRegularArticle = ...;
parameter.IsDeleted = ...;

*/
