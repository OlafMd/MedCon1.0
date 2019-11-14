/* 
 * Generated on 2/13/2015 15:03:54
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
using CL1_HEC;
using CL1_HEC_ACT;
using CL1_CMN_PRO;
using CL1_CMN_BPT;
using CL1_CMN_PRO_PAC;
using CL1_CMN;
using CL1_HEC_PRO;
using CL1_HEC_SUB;
using CL5_MyHealthClub_MedProCommunity.Atomic.Retrieval;

namespace CL5_MyHealthClub_Examanations.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PatientExaminationMedications.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PatientExaminationMedications
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_SPEM_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();

            var medPro_Credentials = cls_Get_TenantMemershipData.Invoke(Connection, Transaction, securityTicket).Result;

            P_L2LN_GALFTID_1530 langParam = new P_L2LN_GALFTID_1530();
            langParam.Tenant_RefID = securityTicket.TenantID;
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, langParam, securityTicket).Result;

            var examination = ORM_HEC_ACT_PerformedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                HEC_ACT_PerformedActionID = Parameter.ExaminationID
            }).Single();
            #region Save

            foreach (var item in Parameter.new_medication)
            {
                //check if dosage exists

                var dosageQuery = new ORM_HEC_Dosage.Query();
                dosageQuery.IsDeleted = false;
                dosageQuery.Tenant_RefID = securityTicket.TenantID;
                dosageQuery.DosageText = item.dosage_text;

                var dosage_table = ORM_HEC_Dosage.Query.Search(Connection, Transaction, dosageQuery).SingleOrDefault();

                if (dosage_table == null)
                {
                    dosage_table = new ORM_HEC_Dosage();
                    dosage_table.HEC_DosageID = Guid.NewGuid();
                    dosage_table.Tenant_RefID = securityTicket.TenantID;
                    dosage_table.Creation_Timestamp = DateTime.Now;
                    dosage_table.Modification_Timestamp = DateTime.Now;
                    dosage_table.DosageText = item.dosage_text;
                    dosage_table.Save(Connection, Transaction);
                }
                
                ORM_HEC_ACT_PerformedAction_MedicationUpdate medicationUpdate = new ORM_HEC_ACT_PerformedAction_MedicationUpdate();
                medicationUpdate.HEC_ACT_PerformedAction_MedicationUpdateID = Guid.NewGuid();
                medicationUpdate.Tenant_RefID = securityTicket.TenantID;
                medicationUpdate.Creation_Timestamp = DateTime.Now;
                medicationUpdate.Modification_Timestamp = DateTime.Now;
                medicationUpdate.IsSubstance = !item.is_product;
                medicationUpdate.IsHealthcareProduct = item.is_product;
                medicationUpdate.IntendedApplicationDuration_in_days = item.days_valid;
                medicationUpdate.HEC_ACT_PerformedAction_RefID = Parameter.ExaminationID;
                medicationUpdate.HEC_Patient_Medication_RefID = Guid.NewGuid();

                ORM_HEC_Patient_Medication patient_medications = new ORM_HEC_Patient_Medication();
                patient_medications.HEC_Patient_MedicationID = medicationUpdate.HEC_Patient_Medication_RefID;
                patient_medications.Patient_RefID = Parameter.PatientID;
                patient_medications.Creation_Timestamp = DateTime.Now;
                patient_medications.Tenant_RefID = securityTicket.TenantID;
                patient_medications.Modification_Timestamp = DateTime.Now;
                patient_medications.R_IsActive = true;
                patient_medications.R_DateOfAdding = examination.IfPerfomed_DateOfAction;
                patient_medications.R_IsHealthcareProduct = item.is_product;
                patient_medications.R_IsSubstance = !item.is_product;
                patient_medications.R_ActiveUntill = patient_medications.R_DateOfAdding.AddDays(item.days_valid);
      

                if (item.is_product)//medication is a product
                {

                    Guid Hec_ProductID = Guid.Empty;

                    //check if product exists
                    var productQuery = new ORM_CMN_PRO_Product.Query();
                    productQuery.Tenant_RefID = securityTicket.TenantID;
                    productQuery.IsDeleted = false;
                    productQuery.ProductITL = item.product_itl;

                    var product = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, productQuery).SingleOrDefault();

                    //if product does not exist create it
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
                            product_name.AddEntry(DBLanguages[i].CMN_LanguageID, item.product_name);
                        }

                        cmn_pro_product.Product_Name = product_name;
                        cmn_pro_product.ProductITL = item.product_itl;
                        cmn_pro_product.ProducingBusinessParticipant_RefID = Guid.NewGuid();//manufacturer
                        cmn_pro_product.PackageInfo_RefID = Guid.NewGuid(); // package info
                        cmn_pro_product.Save(Connection, Transaction);

                        ORM_CMN_BPT_BusinessParticipant manufacturer = new ORM_CMN_BPT_BusinessParticipant();
                        manufacturer.CMN_BPT_BusinessParticipantID = cmn_pro_product.ProducingBusinessParticipant_RefID;
                        manufacturer.DisplayName = item.product_manufacturer;
                        manufacturer.IsCompany = true;
                        manufacturer.IsNaturalPerson = false;
                        manufacturer.Tenant_RefID = securityTicket.TenantID;
                        manufacturer.Creation_Timestamp = DateTime.Now;
                        manufacturer.Modification_Timestamp = DateTime.Now;
                        manufacturer.Save(Connection, Transaction);

                        ORM_CMN_PRO_PAC_PackageInfo package_info = new ORM_CMN_PRO_PAC_PackageInfo();
                        package_info.CMN_PRO_PAC_PackageInfoID = cmn_pro_product.PackageInfo_RefID;
                        package_info.Tenant_RefID = securityTicket.TenantID;
                        package_info.Creation_Timestamp = DateTime.Now;
                        package_info.Modification_Timestamp = DateTime.Now;

                        string amount = String.Empty;
                        string unit = String.Empty;
                        foreach (char c in item.product_strength)
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
                        dosage_formQuery.GlobalPropertyMatchingID = item.product_form;

                        var dosage_form = ORM_HEC_Product_DosageForm.Query.Search(Connection, Transaction, dosage_formQuery).SingleOrDefault();

                        if (dosage_form == null)
                        {
                            dosage_form = new ORM_HEC_Product_DosageForm();
                            dosage_form.HEC_Product_DosageFormID = Guid.NewGuid();
                            dosage_form.GlobalPropertyMatchingID = item.product_form;
                            dosage_form.Tenant_RefID = securityTicket.TenantID;
                            dosage_form.Creation_Timestamp = DateTime.Now;
                            dosage_form.Modification_Timestamp = DateTime.Now;

                            Dict form_name = new Dict("hec_product_dosageforms");
                            for (int i = 0; i < DBLanguages.Length; i++)
                            {
                                form_name.AddEntry(DBLanguages[i].CMN_LanguageID, item.product_form);
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
                        substanceQuery.HealthcareSubstanceITL = item.substance_itl;

                        var substance = ORM_HEC_SUB_Substance.Query.Search(Connection, Transaction, substanceQuery).SingleOrDefault();

                        if (substance == null)
                        {
                            substance =new ORM_HEC_SUB_Substance();
                            substance.HealthcareSubstanceITL = item.substance_itl;
                            substance.HEC_SUB_SubstanceID = Guid.NewGuid();
                            substance.GlobalPropertyMatchingID = item.substance_name;
                            substance.Tenant_RefID = securityTicket.TenantID;
                            substance.Creation_Timestamp = DateTime.Now;
                            substance.Modification_Timestamp = DateTime.Now;
                            substance.Save(Connection, Transaction);

                            ORM_HEC_SUB_Substance_Name substance_name = new ORM_HEC_SUB_Substance_Name();
                            substance_name.HEC_SUB_Substance_NameID = Guid.NewGuid();
                            substance_name.HEC_SUB_Substance_RefID = substance.HEC_SUB_SubstanceID;

                            Dict substance_name_ = new Dict("hec_sub_substance_names");
                            for (int i = 0; i < DBLanguages.Length; i++)
                            {
                                substance_name_.AddEntry(DBLanguages[i].CMN_LanguageID, item.substance_name);
                            }
                            substance_name.SubstanceName_Label = substance_name_;
                            substance_name.Tenant_RefID = securityTicket.TenantID;
                            substance_name.Creation_Timestamp = DateTime.Now;
                            substance_name.Modification_Timestamp = DateTime.Now;
                            substance_name.Save(Connection, Transaction);
                        }

                        component_SubstanceIngredient.Substance_RefID = substance.HEC_SUB_SubstanceID;
                        component_SubstanceIngredient.Save(Connection, Transaction);
                    }
                    else
                    {
                        var hec_productQuery = new ORM_HEC_Product.Query();
                        hec_productQuery.IsDeleted = false;
                        hec_productQuery.Tenant_RefID = securityTicket.TenantID;
                        hec_productQuery.Ext_PRO_Product_RefID = product.CMN_PRO_ProductID;

                        var hec_product = ORM_HEC_Product.Query.Search(Connection, Transaction, hec_productQuery).Single();

                        Hec_ProductID = hec_product.HEC_ProductID;
                    }


                    medicationUpdate.HEC_Product_RefID = Hec_ProductID;                  
                    patient_medications.R_HEC_Product_RefID = Hec_ProductID;
                    patient_medications.R_DosageText = item.dosage_text;
                    medicationUpdate.DosageText = item.dosage_text;
                }
                else// medication is a substance
                {

                    medicationUpdate.IfSubstance_Strength = item.substance_strength;
                    patient_medications.R_IfSubstance_Strength = item.substance_strength;
                    medicationUpdate.IfSubstance_Unit_RefID = item.substance_unit;
                    patient_medications.R_IfSubstance_Unit_RefID = item.substance_unit;
                    patient_medications.R_DosageText = item.dosage_text;
                    medicationUpdate.DosageText = item.dosage_text;
                     
                    var substanceQuery = new ORM_HEC_SUB_Substance.Query();
                    substanceQuery.IsDeleted = false;
                    substanceQuery.Tenant_RefID = securityTicket.TenantID;
                    substanceQuery.HealthcareSubstanceITL = item.substance_itl;

                    var substance = ORM_HEC_SUB_Substance.Query.Search(Connection, Transaction, substanceQuery).SingleOrDefault();

                    if (substance == null)
                    {
                        substance = new ORM_HEC_SUB_Substance();
                        substance.HealthcareSubstanceITL = item.substance_itl;
                        substance.HEC_SUB_SubstanceID = Guid.NewGuid();
                        substance.GlobalPropertyMatchingID = item.substance_name;
                        substance.Tenant_RefID = securityTicket.TenantID;
                        substance.Creation_Timestamp = DateTime.Now;
                        substance.Modification_Timestamp = DateTime.Now;
                        substance.Save(Connection, Transaction);

                        ORM_HEC_SUB_Substance_Name substance_name = new ORM_HEC_SUB_Substance_Name();
                        substance_name.HEC_SUB_Substance_NameID = Guid.NewGuid();
                        substance_name.HEC_SUB_Substance_RefID = substance.HEC_SUB_SubstanceID;

                        Dict substance_name_ = new Dict("hec_sub_substance_names");
                        for (int i = 0; i < DBLanguages.Length; i++)
                        {
                            substance_name_.AddEntry(DBLanguages[i].CMN_LanguageID, item.substance_name);
                        }
                        substance_name.SubstanceName_Label = substance_name_;
                        substance_name.Tenant_RefID = securityTicket.TenantID;
                        substance_name.Creation_Timestamp = DateTime.Now;
                        substance_name.Modification_Timestamp = DateTime.Now;
                        substance_name.Save(Connection, Transaction);
                    }

                    medicationUpdate.IfSubstance_Substance_RefiD = substance.HEC_SUB_SubstanceID;
                    patient_medications.R_IfSubstance_Substance_RefiD = substance.HEC_SUB_SubstanceID;
                }

                patient_medications.Save(Connection, Transaction);
                medicationUpdate.Save(Connection, Transaction);
                returnValue.Result = true;
            }

            #endregion

            #region Delete
            foreach (var item in Parameter.deleted_medications)
            {
                var medicationUpdateQuery = new ORM_HEC_ACT_PerformedAction_MedicationUpdate.Query();
                medicationUpdateQuery.IsDeleted = false;
                medicationUpdateQuery.IsMedicationDeactivated = false;
                medicationUpdateQuery.Tenant_RefID = securityTicket.TenantID;
                medicationUpdateQuery.HEC_ACT_PerformedAction_MedicationUpdateID = item.performedAction_medicationUpdate_id;

                var medicationUpdate = ORM_HEC_ACT_PerformedAction_MedicationUpdate.Query.Search(Connection, Transaction, medicationUpdateQuery).Single();
                medicationUpdate.IsMedicationDeactivated = true;
                medicationUpdate.Save(Connection, Transaction);
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
		public static FR_Bool Invoke(string ConnectionString,P_L5PA_SPEM_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5PA_SPEM_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_SPEM_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_SPEM_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Save_PatientExaminationMedications",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PA_SPEM_1413 for attribute P_L5PA_SPEM_1413
		[DataContract]
		public class P_L5PA_SPEM_1413 
		{
			[DataMember]
			public P_L5PA_SPEM_1413_new_medication[] new_medication { get; set; }
			[DataMember]
			public P_L5PA_SPEM_1413_deleted_medications[] deleted_medications { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ExaminationID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass P_L5PA_SPEM_1413_new_medication for attribute new_medication
		[DataContract]
		public class P_L5PA_SPEM_1413_new_medication 
		{
			//Standard type parameters
			[DataMember]
			public bool is_product { get; set; } 
			[DataMember]
			public String product_itl { get; set; } 
			[DataMember]
			public String product_name { get; set; } 
			[DataMember]
			public String substance_itl { get; set; } 
			[DataMember]
			public String substance_name { get; set; } 
			[DataMember]
			public String product_strength { get; set; } 
			[DataMember]
			public String product_form { get; set; } 
			[DataMember]
			public String product_manufacturer { get; set; } 
			[DataMember]
			public int days_valid { get; set; } 
			[DataMember]
			public Guid dosage { get; set; } 
			[DataMember]
			public String dosage_text { get; set; } 
			[DataMember]
			public Guid substance_unit { get; set; } 
			[DataMember]
			public String substance_strength { get; set; } 

		}
		#endregion
		#region SClass P_L5PA_SPEM_1413_deleted_medications for attribute deleted_medications
		[DataContract]
		public class P_L5PA_SPEM_1413_deleted_medications 
		{
			//Standard type parameters
			[DataMember]
			public Guid product_id { get; set; } 
			[DataMember]
			public Guid substance_id { get; set; } 
			[DataMember]
			public Guid performedAction_medicationUpdate_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_PatientExaminationMedications(,P_L5PA_SPEM_1413 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_PatientExaminationMedications.Invoke(connectionString,P_L5PA_SPEM_1413 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Examanations.Atomic.Manipulation.P_L5PA_SPEM_1413();
parameter.new_medication = ...;
parameter.deleted_medications = ...;

parameter.ExaminationID = ...;
parameter.PatientID = ...;

*/
