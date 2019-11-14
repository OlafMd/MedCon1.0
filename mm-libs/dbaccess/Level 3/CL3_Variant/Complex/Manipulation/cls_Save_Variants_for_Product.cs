/* 
 * Generated on 11/27/2014 17:09:21
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

namespace CL3_Variant.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Variants_for_Product.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Variants_for_Product
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3VA_SVfP_1019 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Base();


            if (Parameter == null)
            {
                returnValue.ErrorMessage = "Parameter is null or there is no product variant defined";
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            }

            if (Parameter.Variants == null && Parameter.Dimensions == null && Parameter.DimensionValues == null)
            {
                returnValue.ErrorMessage = "Variants, Dimensions and Dimension Values are not defined";
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            }


            if (Parameter.Variants.Length == 0 && Parameter.Dimensions.Length == 0 && Parameter.DimensionValues.Length == 0)
            {
                returnValue.ErrorMessage = "Variants, Dimensions and Dimension Values are not defined";
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            }

            #region Variants Create/Update

            foreach (var variant in Parameter.Variants)
            {
                bool createNewVariant = false;
                ORM_CMN_PRO_Product_Variant variantToCreateUpdate = new ORM_CMN_PRO_Product_Variant();

                FR_Base vLoad = variantToCreateUpdate.Load(Connection, Transaction, variant.CMN_PRO_Product_VariantID);
                if (vLoad.Status != FR_Status.Success || variantToCreateUpdate.CMN_PRO_Product_VariantID == Guid.Empty)
                {
                    createNewVariant = true;
                }


                if (createNewVariant)
                {
                    variantToCreateUpdate.CMN_PRO_Product_VariantID = variant.CMN_PRO_Product_VariantID;
                    variantToCreateUpdate.CMN_PRO_Product_RefID = Parameter.ProductID;
                    variantToCreateUpdate.Creation_Timestamp = DateTime.Now;
                    variantToCreateUpdate.Tenant_RefID = securityTicket.TenantID;
                    variantToCreateUpdate.ProductVariantITL = "";
                    variantToCreateUpdate.ProductVariant_DocumentationStructure_RefID = Guid.Empty;
                    variantToCreateUpdate.VariantName = variant.VariantName;
                    variantToCreateUpdate.IsDeleted = false;
                }

                variantToCreateUpdate.IsImportedFromExternalCatalog = variant.IsImportedFromExternalCatalog;
                variantToCreateUpdate.IsObsolete = variant.IsObsolete;
                variantToCreateUpdate.IsProductAvailableForOrdering = variant.IsProductAvailableForOrdering;
                variantToCreateUpdate.IsStandardProductVariant = variant.IsStandardProductVariant;
                variantToCreateUpdate.Modification_Timestamp = DateTime.Now;

                variantToCreateUpdate.Save(Connection, Transaction);
            }

            #endregion

            #region Dimensions Create/Update

            foreach (var dimension in Parameter.Dimensions)
            {

                bool createNewDimension = false;
                ORM_CMN_PRO_Dimension dimensionToCreateUpdate = new ORM_CMN_PRO_Dimension();
                FR_Base dLoad = dimensionToCreateUpdate.Load(Connection, Transaction, dimension.CMN_PRO_DimensionID);
                if (dLoad.Status != FR_Status.Success || dimensionToCreateUpdate.CMN_PRO_DimensionID == Guid.Empty)
                {
                    createNewDimension = true;
                }

                if (createNewDimension)
                {
                    dimensionToCreateUpdate.CMN_PRO_DimensionID = dimension.CMN_PRO_DimensionID;
                    dimensionToCreateUpdate.Abbreviation = dimension.Abbreviation;
                    dimensionToCreateUpdate.Creation_Timestamp = DateTime.Now;
                    dimensionToCreateUpdate.DimensionName = dimension.DimensionName;
                    dimensionToCreateUpdate.IsDeleted = false;
                    dimensionToCreateUpdate.IsDimensionTemplate = false;
                    dimensionToCreateUpdate.Product_RefID = Parameter.ProductID;
                    dimensionToCreateUpdate.Tenant_RefID = securityTicket.TenantID;
                }

                dimensionToCreateUpdate.OrderSequence = dimension.OrderSequence;
                dimensionToCreateUpdate.Modification_Timestamp = DateTime.Now;
                dimensionToCreateUpdate.Save(Connection, Transaction);

            }

            #endregion

            #region Dimension Values Create/Update

            foreach (var dimensionValue in Parameter.DimensionValues)
            {
                bool createNewDimensionValue = false;
                ORM_CMN_PRO_Dimension_Value dimensionValueToCreateUpdate = new ORM_CMN_PRO_Dimension_Value();

                FR_Base dvLoad = dimensionValueToCreateUpdate.Load(Connection, Transaction, dimensionValue.CMN_PRO_Dimension_ValueID);
                if (dvLoad.Status != FR_Status.Success || dimensionValueToCreateUpdate.CMN_PRO_Dimension_ValueID == Guid.Empty)
                {
                    createNewDimensionValue = true;
                }

                if (createNewDimensionValue)
                {
                    dimensionValueToCreateUpdate.CMN_PRO_Dimension_ValueID = dimensionValue.CMN_PRO_Dimension_ValueID;
                    dimensionValueToCreateUpdate.Creation_Timestamp = DateTime.Now;
                    dimensionValueToCreateUpdate.Dimensions_RefID = dimensionValue.Dimension_RefID;
                    dimensionValueToCreateUpdate.DimensionValue_Text = dimensionValue.DimensionValue_Text;
                    dimensionValueToCreateUpdate.IsDeleted = false;
                    dimensionValueToCreateUpdate.Tenant_RefID = securityTicket.TenantID;
                }

                dimensionValueToCreateUpdate.Modification_Timestamp = DateTime.Now;
                dimensionValueToCreateUpdate.OrderSequence = dimensionValue.OrderSequence;
                dimensionValueToCreateUpdate.Save(Connection, Transaction);

            }

            #endregion

            #region Assignments

            foreach (var variant in Parameter.Variants)
            {

                foreach (var dimensionValue in Parameter.DimensionValues)
                {

                    if ((variant.DimensionValue1_RefID == dimensionValue.CMN_PRO_Dimension_ValueID) || (variant.DimensionValue2_RefID == dimensionValue.CMN_PRO_Dimension_ValueID))
                    {
                        bool assignmentExists = ORM_CMN_PRO_Variant_DimensionValue.Query.Exists(Connection, Transaction, new ORM_CMN_PRO_Variant_DimensionValue.Query()
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            DimensionValue_RefID = dimensionValue.CMN_PRO_Dimension_ValueID,
                            ProductVariant_RefID = variant.CMN_PRO_Product_VariantID
                        });

                        if (!assignmentExists)
                        {
                            ORM_CMN_PRO_Variant_DimensionValue assignment = new ORM_CMN_PRO_Variant_DimensionValue();
                            assignment.CMN_PRO_Variant_DimensionValueID = Guid.NewGuid();
                            assignment.Creation_Timestamp = DateTime.Now;
                            assignment.DimensionValue_RefID = dimensionValue.CMN_PRO_Dimension_ValueID;
                            assignment.IsDeleted = false;
                            assignment.Modification_Timestamp = DateTime.Now;
                            assignment.ProductVariant_RefID = variant.CMN_PRO_Product_VariantID;
                            assignment.Tenant_RefID = securityTicket.TenantID;
                            assignment.Save(Connection, Transaction);
                        }
                    }
                }
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
		public static FR_Base Invoke(string ConnectionString,P_L3VA_SVfP_1019 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L3VA_SVfP_1019 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L3VA_SVfP_1019 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3VA_SVfP_1019 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Variants_for_Product",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3VA_SVfP_1019 for attribute P_L3VA_SVfP_1019
		[DataContract]
		public class P_L3VA_SVfP_1019 
		{
			[DataMember]
			public P_L3VA_SVfP_1019a[] Variants { get; set; }
			[DataMember]
			public P_L3VA_SVfP_1019b[] Dimensions { get; set; }
			[DataMember]
			public P_L3VA_SVfP_1019c[] DimensionValues { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass P_L3VA_SVfP_1019a for attribute Variants
		[DataContract]
		public class P_L3VA_SVfP_1019a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_VariantID { get; set; } 
			[DataMember]
			public string ProductVariantITL { get; set; } 
			[DataMember]
			public Dict VariantName { get; set; } 
			[DataMember]
			public bool IsStandardProductVariant { get; set; } 
			[DataMember]
			public bool IsImportedFromExternalCatalog { get; set; } 
			[DataMember]
			public bool IsProductAvailableForOrdering { get; set; } 
			[DataMember]
			public bool IsObsolete { get; set; } 
			[DataMember]
			public Guid DimensionValue1_RefID { get; set; } 
			[DataMember]
			public Guid DimensionValue2_RefID { get; set; } 

		}
		#endregion
		#region SClass P_L3VA_SVfP_1019b for attribute Dimensions
		[DataContract]
		public class P_L3VA_SVfP_1019b 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_DimensionID { get; set; } 
			[DataMember]
			public string Abbreviation { get; set; } 
			[DataMember]
			public Dict DimensionName { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 
			[DataMember]
			public bool IsDimensionTemplate { get; set; } 

		}
		#endregion
		#region SClass P_L3VA_SVfP_1019c for attribute DimensionValues
		[DataContract]
		public class P_L3VA_SVfP_1019c 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Dimension_ValueID { get; set; } 
			[DataMember]
			public Guid Dimension_RefID { get; set; } 
			[DataMember]
			public Dict DimensionValue_Text { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Save_Variants_for_Product(,P_L3VA_SVfP_1019 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Save_Variants_for_Product.Invoke(connectionString,P_L3VA_SVfP_1019 Parameter,securityTicket);
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
var parameter = new CL3_Variant.Complex.Manipulation.P_L3VA_SVfP_1019();
parameter.Variants = ...;
parameter.Dimensions = ...;
parameter.DimensionValues = ...;

parameter.ProductID = ...;

*/
