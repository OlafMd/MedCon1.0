/* 
 * Generated on 2/10/2015 10:42:39
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
using CL1_CMN_PRO_CUS;
using CL1_CMN;

namespace CL3_ProductCustomization.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Customization_and_CustomizationTemplate_with_Variants_for_ProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Customization_and_CustomizationTemplate_with_Variants_for_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PC_SCaCTwVfP_1712[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            var defaultLanguages = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            });
            foreach (var par in Parameter)
            {
                Guid templateID = par.TemplateRefID;
               
                if (par.SaveAsTemplate == true)
                {
                    templateID =Guid.NewGuid();
                }

                ORM_CMN_PRO_CUS_Customization customization = new ORM_CMN_PRO_CUS_Customization();
                customization.Load(Connection, Transaction, par.CustomizationID);
                if (customization.CMN_PRO_CUS_CustomizationID == Guid.Empty)
                    customization.CMN_PRO_CUS_CustomizationID = par.CustomizationID;
                customization.OrderSequence = par.OrderSequence;
                customization.IsDeleted = par.IsDeleted;
                customization.Customization_Name = new Dict(ORM_CMN_PRO_CUS_Customization.TableName);
                customization.Customization_Description = new Dict(ORM_CMN_PRO_CUS_Customization.TableName);
                if(templateID!=Guid.Empty)
                    customization.InstantiatedFrom_CustomizationTemplate_RefID = templateID;
                customization.Product_RefID = par.ProductRefID;
                customization.Tenant_RefID = securityTicket.TenantID;
              
                customization.Save(Connection, Transaction);

                foreach (var lang in defaultLanguages)
                {
                    customization.Customization_Name.UpdateEntry(lang.CMN_LanguageID, par.CustomizationName);
                    customization.Customization_Description.UpdateEntry(lang.CMN_LanguageID, par.CustomizationDescription);
                }
                customization.Save(Connection, Transaction);
                if (par.SaveAsTemplate == true)
                {
                    ORM_CMN_PRO_CUS_Customization_Template customizationTemplate = new ORM_CMN_PRO_CUS_Customization_Template();
                    customizationTemplate.Load(Connection, Transaction, templateID);
                    if (customizationTemplate.CMN_PRO_CUS_Customization_TemplateID == Guid.Empty)
                        customizationTemplate.CMN_PRO_CUS_Customization_TemplateID = templateID;
                    customizationTemplate.CustomizationTemplate_Description = new Dict(ORM_CMN_PRO_CUS_Customization_Template.TableName); 
                    customizationTemplate.CustomizationTemplate_Name = new Dict(ORM_CMN_PRO_CUS_Customization_Template.TableName); 
                    customizationTemplate.IsDeleted = false;
                    customizationTemplate.Tenant_RefID = securityTicket.TenantID;
                    customizationTemplate.Save(Connection, Transaction);
                    foreach (var lang in defaultLanguages)
                    {
                        customizationTemplate.CustomizationTemplate_Name.UpdateEntry(lang.CMN_LanguageID, par.TemplateName);
                        customizationTemplate.CustomizationTemplate_Description.UpdateEntry(lang.CMN_LanguageID, par.TemplateDescription);
                    }
                    customizationTemplate.Save(Connection, Transaction);
                }

                foreach (var customizationVariant in par.CustomizationVariants)
                {
                    ORM_CMN_PRO_CUS_Customization_Variant variantToSave = new ORM_CMN_PRO_CUS_Customization_Variant();
                    variantToSave.Load(Connection, Transaction, customizationVariant.CustomizationVariantID);
                    if (variantToSave.CMN_PRO_CUS_Customization_VariantID == null || variantToSave.CMN_PRO_CUS_Customization_VariantID == Guid.Empty)
                        variantToSave.CMN_PRO_CUS_Customization_VariantID = customizationVariant.CustomizationVariantID;
                    variantToSave.Customization_RefID = par.CustomizationID;
                    variantToSave.CustomizationVariant_Name = new Dict(ORM_CMN_PRO_CUS_Customization_Variant.TableName); 
                    variantToSave.OrderSequence = customizationVariant.CustomizationVariantOrderSequence;
                    variantToSave.IsDeleted = customizationVariant.CustomizationVariantIsDeleted;
                    variantToSave.Tenant_RefID = securityTicket.TenantID;
                    variantToSave.Save(Connection, Transaction);
                    foreach (var lang in defaultLanguages)
                    {
                        variantToSave.CustomizationVariant_Name.UpdateEntry(lang.CMN_LanguageID, customizationVariant.CustomizationVariantName);
                       
                    }
                    variantToSave.Save(Connection, Transaction);
                    if (par.SaveAsTemplate == true && customizationVariant.CustomizationVariantIsDeleted==false)
                    { 
                        ORM_CMN_PRO_CUS_Customization_Variant_Template variantTemplate = new ORM_CMN_PRO_CUS_Customization_Variant_Template();
                        variantTemplate.CMN_PRO_CUS_Customization_Variant_TemplateID = Guid.NewGuid();
                        variantTemplate.Customization_Template_RefID = templateID;
                        variantTemplate.CustomizationVariantTemplate_Name = new Dict(ORM_CMN_PRO_CUS_Customization_Variant_Template.TableName); ;
                        variantTemplate.IsDeleted = false;
                        variantTemplate.OrderSequence = customizationVariant.CustomizationVariantOrderSequence;
                        variantTemplate.Tenant_RefID = securityTicket.TenantID;
                        variantTemplate.Save(Connection, Transaction);
                        foreach (var lang in defaultLanguages)
                        {
                            variantTemplate.CustomizationVariantTemplate_Name.UpdateEntry(lang.CMN_LanguageID, customizationVariant.CustomizationVariantName);

                        }
                        variantTemplate.Save(Connection, Transaction);
                    }

                
                }
            }


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L3PC_SCaCTwVfP_1712[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L3PC_SCaCTwVfP_1712[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L3PC_SCaCTwVfP_1712[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L3PC_SCaCTwVfP_1712[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Customization_and_CustomizationTemplate_with_Variants_for_ProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PC_SCaCTwVfP_1712 for attribute P_L3PC_SCaCTwVfP_1712
		[DataContract]
		public class P_L3PC_SCaCTwVfP_1712 
		{
			[DataMember]
			public P_L3PC_SCaCTwVfP_1712a[] CustomizationVariants { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CustomizationID { get; set; } 
			[DataMember]
			public Guid TemplateRefID { get; set; } 
			[DataMember]
			public Guid ProductRefID { get; set; } 
			[DataMember]
			public String CustomizationName { get; set; } 
			[DataMember]
			public String CustomizationDescription { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public bool SaveAsTemplate { get; set; } 
			[DataMember]
			public String TemplateName { get; set; } 
			[DataMember]
			public String TemplateDescription { get; set; } 

		}
		#endregion
		#region SClass P_L3PC_SCaCTwVfP_1712a for attribute CustomizationVariants
		[DataContract]
		public class P_L3PC_SCaCTwVfP_1712a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomizationVariantID { get; set; } 
			[DataMember]
			public String CustomizationVariantName { get; set; } 
			[DataMember]
			public int CustomizationVariantOrderSequence { get; set; } 
			[DataMember]
			public bool CustomizationVariantIsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Customization_and_CustomizationTemplate_with_Variants_for_ProductID(,P_L3PC_SCaCTwVfP_1712 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Customization_and_CustomizationTemplate_with_Variants_for_ProductID.Invoke(connectionString,P_L3PC_SCaCTwVfP_1712 Parameter,securityTicket);
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
var parameter = new CL3_ProductCustomization.Complex.Manipulation.P_L3PC_SCaCTwVfP_1712();
parameter.CustomizationVariants = ...;

parameter.CustomizationID = ...;
parameter.TemplateRefID = ...;
parameter.ProductRefID = ...;
parameter.CustomizationName = ...;
parameter.CustomizationDescription = ...;
parameter.OrderSequence = ...;
parameter.IsDeleted = ...;
parameter.SaveAsTemplate = ...;
parameter.TemplateName = ...;
parameter.TemplateDescription = ...;

*/
