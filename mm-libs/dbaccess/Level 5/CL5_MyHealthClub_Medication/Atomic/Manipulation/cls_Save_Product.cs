/* 
 * Generated on 2/26/2015 14:57:07
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
using CL1_CMN_PRO;
using CL1_CMN_BPT;
using CL1_CMN_PRO_PAC;
using CL1_CMN;
using CL1_HEC;
using CL1_HEC_PRO;
using CL1_HEC_SUB;
namespace CL5_MyHealthClub_Medication.Atomic.Manipulation
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
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_SP_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            returnValue.Result = new Guid();
            if (!Parameter.IsDeleted)
            {
                var DBLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result;
                Guid Hec_ProductID = Guid.Empty;

                //check if product exists
                var productQuery = new ORM_CMN_PRO_Product.Query();
                productQuery.Tenant_RefID = securityTicket.TenantID;
                productQuery.IsDeleted = false;
                productQuery.CMN_PRO_ProductID = Guid.Parse( Parameter.product_itl);
                var product = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, productQuery).SingleOrDefault();

                //save
                if (product == null)
                { 
                    ORM_CMN_PRO_Product cmn_pro_product = new ORM_CMN_PRO_Product();
                    cmn_pro_product.CMN_PRO_ProductID = Guid.NewGuid();
                    cmn_pro_product.Tenant_RefID = securityTicket.TenantID;
                    cmn_pro_product.Creation_Timestamp = DateTime.Now;
                    cmn_pro_product.Modification_Timestamp = DateTime.Now;
                    
                    Dict product_name = new Dict("cmn_pro_products");
                    for (int i = 0; i < DBLanguages.Length; i++)
                    {
                        product_name.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.product_name);
                    }
                    cmn_pro_product.Product_Name = product_name;
                    cmn_pro_product.ProductITL = Guid.NewGuid().ToString();
                    cmn_pro_product.ProducingBusinessParticipant_RefID = Guid.NewGuid();//manufacturer
                    cmn_pro_product.PackageInfo_RefID = Guid.NewGuid(); // package info
                    cmn_pro_product.Save(Connection, Transaction);
                    ORM_CMN_BPT_BusinessParticipant manufacturer = new ORM_CMN_BPT_BusinessParticipant();

                    var manufacturerQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                    manufacturerQuery.Tenant_RefID = securityTicket.TenantID;
                    manufacturerQuery.IsDeleted = false;
                    manufacturerQuery.CMN_BPT_BusinessParticipantID = Guid.Parse(Parameter.product_manufacturer_id);

                    if (Parameter.product_manufacturer_id == Guid.Empty.ToString())
                    {
                        manufacturer.CMN_BPT_BusinessParticipantID = cmn_pro_product.ProducingBusinessParticipant_RefID;
                        manufacturer.DisplayName = Parameter.product_manufacturer;
                        manufacturer.IsCompany = true;
                        manufacturer.IsNaturalPerson = false;
                        manufacturer.Tenant_RefID = securityTicket.TenantID;
                        manufacturer.Creation_Timestamp = DateTime.Now;
                        manufacturer.Modification_Timestamp = DateTime.Now;
                        manufacturer.Save(Connection, Transaction);
                    }
                    else
                    {
                        manufacturer = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, manufacturerQuery).Single();
                    }

                    ORM_CMN_PRO_PAC_PackageInfo package_info = new ORM_CMN_PRO_PAC_PackageInfo();
                    package_info.CMN_PRO_PAC_PackageInfoID = cmn_pro_product.PackageInfo_RefID;
                    package_info.Tenant_RefID = securityTicket.TenantID;
                    package_info.Creation_Timestamp = DateTime.Now;
                    package_info.Modification_Timestamp = DateTime.Now;
                    
                    string amount = String.Empty;
                    string unit = String.Empty;
                    foreach (char c in Parameter.product_strength)
                    {
                        // Do not use IsDigit as it will include more than the characters 0 through to 9
                        if (c >= '0' && c <= '9') amount += c;
                        else unit += c;
                    }
                    package_info.PackageContent_Amount = Int32.Parse(amount);
                    package_info.PackageContent_DisplayLabel = amount;


                    var unitQuery = new ORM_CMN_Unit.Query();
                    unitQuery.IsDeleted = false;
                    unitQuery.Tenant_RefID = securityTicket.TenantID;
                    unitQuery.ISOCode = unit;

                    var cmn_unit = ORM_CMN_Unit.Query.Search(Connection, Transaction, unitQuery).FirstOrDefault();

                    if (cmn_unit == null)
                    {
                        cmn_unit = new ORM_CMN_Unit();
                        cmn_unit.CMN_UnitID = Guid.NewGuid();
                        cmn_unit.Tenant_RefID = securityTicket.TenantID;
                        cmn_unit.Creation_Timestamp = DateTime.Now;
                        cmn_unit.Modification_Timestamp = DateTime.Now;
                        cmn_unit.ISOCode = unit;
                        cmn_unit.Save(Connection, Transaction);
                    }

                    package_info.PackageContent_MeasuredInUnit_RefID = cmn_unit.CMN_UnitID;
                    package_info.Save(Connection, Transaction);

                    //hec_products
                    ORM_HEC_Product hec_product = new ORM_HEC_Product();
                    hec_product.HEC_ProductID = Guid.NewGuid();
                    hec_product.Ext_PRO_Product_RefID = cmn_pro_product.CMN_PRO_ProductID;
                    hec_product.Tenant_RefID = securityTicket.TenantID;
                    hec_product.Creation_Timestamp = DateTime.Now;
                    hec_product.Modification_Timestamp = DateTime.Now;
                    
                    Hec_ProductID = hec_product.HEC_ProductID;

                    var dosage_formQuery = new ORM_HEC_Product_DosageForm.Query();
                    dosage_formQuery.Tenant_RefID = securityTicket.TenantID;
                    dosage_formQuery.IsDeleted = false;
                    dosage_formQuery.GlobalPropertyMatchingID = Parameter.product_form;

                    var dosage_form = ORM_HEC_Product_DosageForm.Query.Search(Connection, Transaction, dosage_formQuery).SingleOrDefault();

                    if (dosage_form == null)
                    {
                        dosage_form = new ORM_HEC_Product_DosageForm();
                        dosage_form.HEC_Product_DosageFormID = Guid.NewGuid();
                        dosage_form.GlobalPropertyMatchingID = Parameter.product_form;
                        dosage_form.Tenant_RefID = securityTicket.TenantID;
                        dosage_form.Creation_Timestamp = DateTime.Now;
                        dosage_form.Modification_Timestamp = DateTime.Now;

                        Dict form_name = new Dict("hec_product_dosageforms");
                        for (int i = 0; i < DBLanguages.Length; i++)
                        {
                            form_name.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.product_form);
                        }
                        dosage_form.DosageForm_Name = form_name;
                        dosage_form.Save(Connection, Transaction);
                    }

                    hec_product.ProductDosageForm_RefID = dosage_form.HEC_Product_DosageFormID;  //dosage form
                    hec_product.Save(Connection, Transaction);


                    //product component


                    ORM_HEC_PRO_Product_Component product_component = new ORM_HEC_PRO_Product_Component();
                    product_component.HEC_PRO_Product_ComponentID = Guid.NewGuid();
                    product_component.HEC_PRO_Component_RefID = Guid.NewGuid();//pro_component
                    product_component.HEC_PRO_Product_RefID = hec_product.HEC_ProductID;
                    product_component.Tenant_RefID = securityTicket.TenantID;
                    product_component.Creation_Timestamp = DateTime.Now;
                    product_component.Modification_Timestamp = DateTime.Now;
                    product_component.Save(Connection, Transaction);

                    ORM_HEC_PRO_Component pro_component = new ORM_HEC_PRO_Component();
                    pro_component.HEC_PRO_ComponentID = product_component.HEC_PRO_Component_RefID;
                    pro_component.Tenant_RefID = securityTicket.TenantID;
                    pro_component.Creation_Timestamp = DateTime.Now;
                    pro_component.Modification_Timestamp = DateTime.Now;
                    pro_component.Save(Connection, Transaction);

                    ORM_HEC_PRO_Component_SubstanceIngredient component_SubstanceIngredient = new ORM_HEC_PRO_Component_SubstanceIngredient();
                    component_SubstanceIngredient.HEC_PRO_Component_SubstanceIngredientID = Guid.NewGuid();
                    component_SubstanceIngredient.Component_RefID = pro_component.HEC_PRO_ComponentID;
                    component_SubstanceIngredient.Tenant_RefID = securityTicket.TenantID;
                    component_SubstanceIngredient.Creation_Timestamp = DateTime.Now;
                    component_SubstanceIngredient.Modification_Timestamp = DateTime.Now;

                    var substanceQuery = new ORM_HEC_SUB_Substance.Query();
                    substanceQuery.IsDeleted = false;
                    substanceQuery.Tenant_RefID = securityTicket.TenantID;
                    substanceQuery.HEC_SUB_SubstanceID = Parameter.substance_id;

                    var substance = ORM_HEC_SUB_Substance.Query.Search(Connection, Transaction, substanceQuery).SingleOrDefault();

                    component_SubstanceIngredient.Substance_RefID = substance.HEC_SUB_SubstanceID;
                    component_SubstanceIngredient.Save(Connection, Transaction);
                    Parameter.IsSaved = true;
                    Parameter.product_itl = cmn_pro_product.CMN_PRO_ProductID.ToString();
                    returnValue.Result = cmn_pro_product.CMN_PRO_ProductID;
                }
                else
                {
                    //edit
                    Parameter.IsEdited = true;

                    Dict product_name = new Dict("cmn_pro_products");
                    for (int i = 0; i < DBLanguages.Length; i++)
                    {
                        product_name.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.product_name);
                    }
                    product.Product_Name = product_name;
                    

                    var manufacturerQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                    manufacturerQuery.Tenant_RefID = securityTicket.TenantID;
                    manufacturerQuery.IsDeleted = false;
                    manufacturerQuery.CMN_BPT_BusinessParticipantID = Guid.Parse(Parameter.product_manufacturer_id);
                    ORM_CMN_BPT_BusinessParticipant manufacturer = new ORM_CMN_BPT_BusinessParticipant();
                    if (Parameter.product_manufacturer_id == Guid.Empty.ToString())
                    {
                        manufacturer.CMN_BPT_BusinessParticipantID = new Guid();
                        manufacturer.DisplayName = Parameter.product_manufacturer;
                        manufacturer.IsCompany = true;
                        manufacturer.IsNaturalPerson = false;
                        manufacturer.Tenant_RefID = securityTicket.TenantID;
                        manufacturer.Creation_Timestamp = DateTime.Now;
                        manufacturer.Modification_Timestamp = DateTime.Now;
                        manufacturer.Save(Connection, Transaction);
                    }
                    else
                    {
                        manufacturer = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, manufacturerQuery).Single();
                    }
                    product.ProducingBusinessParticipant_RefID = manufacturer.CMN_BPT_BusinessParticipantID;
                   

                    var package_info = ORM_CMN_PRO_PAC_PackageInfo.Query.Search(Connection, Transaction, new ORM_CMN_PRO_PAC_PackageInfo.Query()
                    {
                        CMN_PRO_PAC_PackageInfoID = product.PackageInfo_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    string amount = String.Empty;
                    string unit = String.Empty;
                    foreach (char c in Parameter.product_strength)
                    {
                        // Do not use IsDigit as it will include more than the characters 0 through to 9
                        if (c >= '0' && c <= '9') amount += c;
                        else unit += c;
                    }
                    package_info.PackageContent_Amount = Int32.Parse(amount);
                    package_info.PackageContent_DisplayLabel = amount;
                    package_info.Save(Connection, Transaction);



                    var unitQuery = new ORM_CMN_Unit.Query();
                    unitQuery.IsDeleted = false;
                    unitQuery.Tenant_RefID = securityTicket.TenantID;
                    unitQuery.ISOCode = unit;

                    var cmn_unit = ORM_CMN_Unit.Query.Search(Connection, Transaction, unitQuery).FirstOrDefault();

                    if (cmn_unit == null)
                    {
                        cmn_unit = new ORM_CMN_Unit();
                        cmn_unit.CMN_UnitID = Guid.NewGuid();
                        cmn_unit.Tenant_RefID = securityTicket.TenantID;
                        cmn_unit.Creation_Timestamp = DateTime.Now;
                        cmn_unit.Modification_Timestamp = DateTime.Now;
                        cmn_unit.ISOCode = unit;
                        cmn_unit.Save(Connection, Transaction);
                    }

                    package_info.PackageContent_MeasuredInUnit_RefID = cmn_unit.CMN_UnitID;
                    package_info.Save(Connection, Transaction);

                    var dosage_formQuery = new ORM_HEC_Product_DosageForm.Query();
                    dosage_formQuery.Tenant_RefID = securityTicket.TenantID;
                    dosage_formQuery.IsDeleted = false;
                    dosage_formQuery.GlobalPropertyMatchingID = Parameter.product_form;

                    var dosage_form = ORM_HEC_Product_DosageForm.Query.Search(Connection, Transaction, dosage_formQuery).SingleOrDefault();

                    if (dosage_form == null)
                    {
                        dosage_form = new ORM_HEC_Product_DosageForm();
                        dosage_form.HEC_Product_DosageFormID = Guid.NewGuid();
                        dosage_form.GlobalPropertyMatchingID = Parameter.product_form;
                        dosage_form.Tenant_RefID = securityTicket.TenantID;
                        dosage_form.Creation_Timestamp = DateTime.Now;
                        dosage_form.Modification_Timestamp = DateTime.Now;

                        Dict form_name = new Dict("hec_product_dosageforms");
                        for (int i = 0; i < DBLanguages.Length; i++)
                        {
                            form_name.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.product_form);
                        }
                        dosage_form.DosageForm_Name = form_name;
                        dosage_form.Save(Connection, Transaction);
                    }
                    ORM_HEC_Product hec_product = ORM_HEC_Product.Query.Search(Connection, Transaction, new ORM_HEC_Product.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        Ext_PRO_Product_RefID = product.CMN_PRO_ProductID
                    }).Single();
                    hec_product.ProductDosageForm_RefID = dosage_form.HEC_Product_DosageFormID;
                    hec_product.Save(Connection, Transaction);

                    ORM_HEC_PRO_Product_Component product_component = ORM_HEC_PRO_Product_Component.Query.Search(Connection, Transaction, new ORM_HEC_PRO_Product_Component.Query()
                    {
                        HEC_PRO_Product_RefID = hec_product.HEC_ProductID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();


                    ORM_HEC_PRO_Component pro_component = ORM_HEC_PRO_Component.Query.Search(Connection, Transaction, new ORM_HEC_PRO_Component.Query()
                    {
                        HEC_PRO_ComponentID= product_component.HEC_PRO_Component_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted=false
                    }).Single();

                    ORM_HEC_PRO_Component_SubstanceIngredient component_SubstanceIngredient = ORM_HEC_PRO_Component_SubstanceIngredient.Query.Search(Connection, Transaction, new ORM_HEC_PRO_Component_SubstanceIngredient.Query()
                    {
                        Component_RefID = pro_component.HEC_PRO_ComponentID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();

                    var substanceQuery = new ORM_HEC_SUB_Substance.Query();
                    substanceQuery.IsDeleted = false;
                    substanceQuery.Tenant_RefID = securityTicket.TenantID;
                    substanceQuery.HEC_SUB_SubstanceID = Parameter.substance_id;

                    var substance = ORM_HEC_SUB_Substance.Query.Search(Connection, Transaction, substanceQuery).SingleOrDefault();

                    component_SubstanceIngredient.Substance_RefID = substance.HEC_SUB_SubstanceID;
                    component_SubstanceIngredient.Save(Connection, Transaction);
                }
            }
            else
            {
                //delete
                ORM_CMN_PRO_Product product = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_PRO_ProductID = Guid.Parse(Parameter.product_itl),
                    IsDeleted = false
                }).Single();

                ORM_HEC_Product hec_product = ORM_HEC_Product.Query.Search(Connection, Transaction, new ORM_HEC_Product.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Ext_PRO_Product_RefID = product.CMN_PRO_ProductID
                }).Single();


                ORM_CMN_PRO_PAC_PackageInfo package_info = ORM_CMN_PRO_PAC_PackageInfo.Query.Search(Connection, Transaction, new ORM_CMN_PRO_PAC_PackageInfo.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    CMN_PRO_PAC_PackageInfoID = product.PackageInfo_RefID
                }).Single();


                ORM_HEC_PRO_Product_Component product_component = ORM_HEC_PRO_Product_Component.Query.Search(Connection, Transaction, new ORM_HEC_PRO_Product_Component.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    HEC_PRO_Product_RefID = hec_product.HEC_ProductID
                    
                }).Single();
                

                ORM_HEC_PRO_Component pro_component = ORM_HEC_PRO_Component.Query.Search(Connection, Transaction, new ORM_HEC_PRO_Component.Query()
                {
                    HEC_PRO_ComponentID = product_component.HEC_PRO_Component_RefID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();


                ORM_HEC_PRO_Component_SubstanceIngredient component_SubstanceIngredient = ORM_HEC_PRO_Component_SubstanceIngredient.Query.Search(Connection, Transaction, new ORM_HEC_PRO_Component_SubstanceIngredient.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Component_RefID = pro_component.HEC_PRO_ComponentID
                }).Single();

                component_SubstanceIngredient.IsDeleted = true;
                component_SubstanceIngredient.Save(Connection, Transaction);

                pro_component.IsDeleted = true;
                pro_component.Save(Connection, Transaction);

                product_component.IsDeleted = true;
                product_component.Save(Connection, Transaction);

                package_info.IsDeleted = true;
                package_info.Save(Connection, Transaction);

                product.IsDeleted = true;
                product.Save(Connection, Transaction);
          
                returnValue.Result = product.CMN_PRO_ProductID;
            }
            
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5ME_SP_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5ME_SP_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_SP_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_SP_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L5ME_SP_1054 for attribute P_L5ME_SP_1054
		[DataContract]
		public class P_L5ME_SP_1054 
		{
			//Standard type parameters
			[DataMember]
			public String product_itl { get; set; } 
			[DataMember]
			public String product_name { get; set; } 
			[DataMember]
			public Guid unit_id { get; set; } 
			[DataMember]
			public String unit_iso { get; set; } 
			[DataMember]
			public Guid substance_id { get; set; } 
			[DataMember]
			public String substance_name { get; set; } 
			[DataMember]
			public String product_strength { get; set; } 
			[DataMember]
			public String product_form { get; set; } 
			[DataMember]
			public String product_form_id { get; set; } 
			[DataMember]
			public String product_manufacturer { get; set; } 
			[DataMember]
			public String product_manufacturer_id { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsSaved { get; set; } 
			[DataMember]
			public Boolean IsEdited { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Product(,P_L5ME_SP_1054 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Product.Invoke(connectionString,P_L5ME_SP_1054 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Medication.Atomic.Manipulation.P_L5ME_SP_1054();
parameter.product_itl = ...;
parameter.product_name = ...;
parameter.unit_id = ...;
parameter.unit_iso = ...;
parameter.substance_id = ...;
parameter.substance_name = ...;
parameter.product_strength = ...;
parameter.product_form = ...;
parameter.product_form_id = ...;
parameter.product_manufacturer = ...;
parameter.product_manufacturer_id = ...;
parameter.IsDeleted = ...;
parameter.IsSaved = ...;
parameter.IsEdited = ...;

*/
