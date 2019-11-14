/* 
 * Generated on 2/15/2015 23:56:06
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
using CL1_CMN;
using CL1_CMN_PRO;
using CL1_CMN_PRO_CUS;
namespace CL5_Zugseil_Product.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Product.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Product
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_SP_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            var languageQuery = new ORM_CMN_Language.Query();
            languageQuery.Tenant_RefID = securityTicket.TenantID;
            languageQuery.IsDeleted = false;
            var languages = ORM_CMN_Language.Query.Search(Connection, Transaction, languageQuery);

            var product = new ORM_CMN_PRO_Product();

            if (Parameter.ProductID == Guid.Empty)
            {
                #region ORM_CMN_PRO_Product

                product = new ORM_CMN_PRO_Product();
                product.CMN_PRO_ProductID = Guid.NewGuid();
                product.ProductITL = String.Empty;
                product.IsCustomizable = Parameter.IsCustomizable;
                product.IsProduct_Article = true;
                product.IsProductAvailableForOrdering = true;
                product.IsImportedFromExternalCatalog = false;
                product.IsProductForInternalDistributionOnly = Parameter.IsProductForInternalDistribution;
                if (Parameter.CatalogRefID != null && Parameter.CatalogRefID != Guid.Empty)
                {
                    product.IfImportedFromExternalCatalog_CatalogSubscription_RefID = Parameter.CatalogRefID;
                }
                product.Product_Name = new Dict(ORM_CMN_PRO_Product.TableName);
                product.Product_Description = new Dict(ORM_CMN_PRO_Product.TableName);

                product.PackageInfo_RefID = Guid.NewGuid();

                product.Creation_Timestamp = DateTime.Now;
                product.Tenant_RefID = securityTicket.TenantID;
                product.IsDeleted = Parameter.IsDeleted;


                
                product.Save(Connection, Transaction);

                #endregion
            }
            else
            {
                product.Load(Connection, Transaction, Parameter.ProductID);

        
            }
            if (Parameter.Document_ID != null && Parameter.Document_ID != Guid.Empty)
            {
                ORM_DOC_Structure_Header structureHeader = new ORM_DOC_Structure_Header();
                if (Parameter.DocumentStructureHeaderID == Guid.Empty)
                {
                    structureHeader.Label = "Product picture";
                    structureHeader.Tenant_RefID = securityTicket.TenantID;
                    structureHeader.Save(Connection, Transaction);
                    product.Product_DocumentationStructure_RefID = structureHeader.DOC_Structure_HeaderID;
                }
                ORM_DOC_Structure structure = new ORM_DOC_Structure();
                if (Parameter.DocumentStructureHeaderID == Guid.Empty)
                {

                    structure.Label = "Product picture";
                    structure.Structure_Header_RefID = structureHeader.DOC_Structure_HeaderID;
                    structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                    structure.Tenant_RefID = securityTicket.TenantID;
                    structure.Save(Connection, Transaction);
                }
                ORM_DOC_Document document = new ORM_DOC_Document();
                document.DOC_DocumentID = Parameter.Document_ID;
                document.Tenant_RefID = securityTicket.TenantID;
                document.Save(Connection, Transaction);
                var documentStructureID = structure.DOC_StructureID;
                var assignmentID = Guid.Empty;
                List<ORM_DOC_Document_2_Structure> existingDocumentStructure = new List<ORM_DOC_Document_2_Structure>();
                if(Parameter.DocumentStructureHeaderID!=Guid.Empty)
                {
                 existingDocumentStructure = ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query()
                {
                    StructureHeader_RefID = Parameter.DocumentStructureHeaderID
                });
                }
                ORM_DOC_Document_2_Structure documentStructure = new ORM_DOC_Document_2_Structure();
                if (existingDocumentStructure != null && existingDocumentStructure.Count()>0)
                {
                    existingDocumentStructure.First().Document_RefID = document.DOC_DocumentID;
                    existingDocumentStructure.First().Save(Connection, Transaction);


                }
                else
                {

                   
                    documentStructure.Document_RefID = document.DOC_DocumentID;
                    documentStructure.Structure_RefID = documentStructureID;
                    documentStructure.StructureHeader_RefID = structure.Structure_Header_RefID;
                    documentStructure.Tenant_RefID = securityTicket.TenantID;
                    documentStructure.Save(Connection, Transaction);
                }






            }

            #region ORM_CMN_PRO_Product

            product.Product_Number = Parameter.ProductNumber;

            foreach (var language in languages)
            {
                product.Product_Name.UpdateEntry(language.CMN_LanguageID, Parameter.ProductName);
                product.Product_Description.UpdateEntry(language.CMN_LanguageID, Parameter.Description);
            }

            product.ProductType_RefID = Guid.Empty;

            product.IsPlaceholderArticle = Parameter.IsDummy;
            product.IsCustomizable = Parameter.IsCustomizable; 
            product.ProductSuccessor_RefID = Guid.Empty;
            product.IsDeleted = Parameter.IsDeleted;
            product.Save(Connection, Transaction);



            #endregion

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

            #region Customization
            if (Parameter.IsCustomizable == false && Parameter.ProductID!=Guid.Empty)
            {

                var customizations = ORM_CMN_PRO_CUS_Customization.Query.Search(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization.Query() { Product_RefID = Parameter.ProductID });
                foreach (var customization in customizations)
                {
                    ORM_CMN_PRO_CUS_Customization_Variant.Query.SoftDelete(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization_Variant.Query() { Customization_RefID = customization.CMN_PRO_CUS_CustomizationID });
                }
                ORM_CMN_PRO_CUS_Customization.Query.SoftDelete(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization.Query() { Product_RefID = Parameter.ProductID });
                
            }
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
		public static FR_Guid Invoke(string ConnectionString,P_L5PR_SP_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PR_SP_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_SP_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_SP_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Product",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PR_SP_1614 for attribute P_L5PR_SP_1614
		[DataContract]
		public class P_L5PR_SP_1614 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public String ProductNumber { get; set; } 
			[DataMember]
			public String ProductName { get; set; } 
			[DataMember]
			public string ProductITL { get; set; } 
			[DataMember]
			public String Description { get; set; } 
			[DataMember]
			public bool IsDummy { get; set; } 
			[DataMember]
			public bool IsRegularArticle { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Guid DocumentStructureHeaderID { get; set; } 
			[DataMember]
			public bool IsImportedFromExternalCatalog { get; set; } 
			[DataMember]
			public bool IsProductForInternalDistribution { get; set; } 
			[DataMember]
			public bool IsCustomizable { get; set; } 
			[DataMember]
			public Guid CatalogRefID { get; set; } 
			[DataMember]
			public Guid Document_ID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Product(,P_L5PR_SP_1614 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Product.Invoke(connectionString,P_L5PR_SP_1614 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Product.Complex.Manipulation.P_L5PR_SP_1614();
parameter.ProductID = ...;
parameter.ProductNumber = ...;
parameter.ProductName = ...;
parameter.ProductITL = ...;
parameter.Description = ...;
parameter.IsDummy = ...;
parameter.IsRegularArticle = ...;
parameter.IsDeleted = ...;
parameter.DocumentStructureHeaderID = ...;
parameter.IsImportedFromExternalCatalog = ...;
parameter.IsProductForInternalDistribution = ...;
parameter.IsCustomizable = ...;
parameter.CatalogRefID = ...;
parameter.Document_ID = ...;

*/
