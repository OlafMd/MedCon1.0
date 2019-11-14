/* 
 * Generated on 2/22/2015 23:08:17
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
using CL1_CMN_PRO_CUS;

namespace CL3_ProductCustomization.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CustomizationTemplate_with_Variants.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CustomizationTemplate_with_Variants
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PC_SCTwV_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            var defaultLanguages = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query
         {
             IsDeleted = false,
             Tenant_RefID = securityTicket.TenantID
         });
            ORM_CMN_PRO_CUS_Customization_Template templateToSave = new ORM_CMN_PRO_CUS_Customization_Template();
            templateToSave.Load(Connection, Transaction, Parameter.CustomizationTemplateID);
            if (templateToSave == null || templateToSave.CMN_PRO_CUS_Customization_TemplateID == Guid.Empty)
                templateToSave.CMN_PRO_CUS_Customization_TemplateID = Parameter.CustomizationTemplateID;

            templateToSave.CustomizationTemplate_Name = new Dict(ORM_CMN_PRO_CUS_Customization_Template.TableName);
            templateToSave.CustomizationTemplate_Description = new Dict(ORM_CMN_PRO_CUS_Customization_Template.TableName);
            templateToSave.IsDeleted = false;
            templateToSave.Tenant_RefID = securityTicket.TenantID;
            templateToSave.Save(Connection, Transaction);


            foreach (var lang in defaultLanguages)
            {
                templateToSave.CustomizationTemplate_Name.UpdateEntry(lang.CMN_LanguageID, Parameter.CustomizationTemplateName);
                templateToSave.CustomizationTemplate_Description.UpdateEntry(lang.CMN_LanguageID, Parameter.CustomizationTemplateDescription);
            }
                templateToSave.Save(Connection, Transaction);

            foreach (var templateVariant in Parameter.CustomizationTemplateVariants)
            {
                ORM_CMN_PRO_CUS_Customization_Variant_Template templateVariantToSave = new ORM_CMN_PRO_CUS_Customization_Variant_Template();
                templateVariantToSave.Load(Connection, Transaction, templateVariant.CustomizationTemplateVariantID);

                if (templateVariantToSave == null || templateVariantToSave.CMN_PRO_CUS_Customization_Variant_TemplateID == Guid.Empty)
                    templateVariantToSave.CMN_PRO_CUS_Customization_Variant_TemplateID = templateVariant.CustomizationTemplateVariantID;

                templateVariantToSave.Customization_Template_RefID = Parameter.CustomizationTemplateID;
                templateVariantToSave.CustomizationVariantTemplate_Name = new Dict(ORM_CMN_PRO_CUS_Customization_Variant_Template.TableName);
                templateVariantToSave.IsDeleted = templateVariant.CustomizationTemplateVariantIsDeleted;
                templateVariantToSave.OrderSequence = templateVariant.CustomizationTemplateVariantOrderSequence;
                templateVariantToSave.Tenant_RefID = securityTicket.TenantID;

                templateVariantToSave.Save(Connection, Transaction);


                foreach (var lang in defaultLanguages)
                {
                    templateVariantToSave.CustomizationVariantTemplate_Name.UpdateEntry(lang.CMN_LanguageID, templateVariant.CustomizationTemplateVariantName);

                }
                templateVariantToSave.Save(Connection, Transaction);

            }
            returnValue.Result = templateToSave.CMN_PRO_CUS_Customization_TemplateID;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3PC_SCTwV_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3PC_SCTwV_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PC_SCTwV_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PC_SCTwV_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CustomizationTemplate_with_Variants",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PC_SCTwV_1217 for attribute P_L3PC_SCTwV_1217
		[DataContract]
		public class P_L3PC_SCTwV_1217 
		{
			[DataMember]
			public P_L3PC_SCTwV_1217a[] CustomizationTemplateVariants { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CustomizationTemplateID { get; set; } 
			[DataMember]
			public String CustomizationTemplateName { get; set; } 
			[DataMember]
			public String CustomizationTemplateDescription { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L3PC_SCTwV_1217a for attribute CustomizationTemplateVariants
		[DataContract]
		public class P_L3PC_SCTwV_1217a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomizationTemplateVariantID { get; set; } 
			[DataMember]
			public String CustomizationTemplateVariantName { get; set; } 
			[DataMember]
			public int CustomizationTemplateVariantOrderSequence { get; set; } 
			[DataMember]
			public bool CustomizationTemplateVariantIsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CustomizationTemplate_with_Variants(,P_L3PC_SCTwV_1217 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CustomizationTemplate_with_Variants.Invoke(connectionString,P_L3PC_SCTwV_1217 Parameter,securityTicket);
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
var parameter = new CL3_ProductCustomization.Complex.Manipulation.P_L3PC_SCTwV_1217();
parameter.CustomizationTemplateVariants = ...;

parameter.CustomizationTemplateID = ...;
parameter.CustomizationTemplateName = ...;
parameter.CustomizationTemplateDescription = ...;
parameter.OrderSequence = ...;
parameter.IsDeleted = ...;

*/
