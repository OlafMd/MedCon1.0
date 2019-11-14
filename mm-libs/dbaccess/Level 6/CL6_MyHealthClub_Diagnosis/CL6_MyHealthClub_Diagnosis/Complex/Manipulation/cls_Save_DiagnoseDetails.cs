/* 
 * Generated on 12/15/2014 1:21:23 PM
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
using CL1_HEC_DIA;
using CL5_MyHealthClub_Medication.Atomic.Manipulation;
using CL5_MyHealthClub_Diagnosis.Atomic.Manipulation;

namespace CL6_MyHealthClub_Diagnosis.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DiagnoseDetails.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DiagnoseDetails
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DI_SDD_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            var potentialDiagnoseQuery = new ORM_HEC_DIA_PotentialDiagnosis.Query();
            potentialDiagnoseQuery.IsDeleted = false;
            potentialDiagnoseQuery.Tenant_RefID = securityTicket.TenantID;
            potentialDiagnoseQuery.HEC_DIA_PotentialDiagnosisID = Parameter.DiagnoseID;

            var potentialDiagnose = ORM_HEC_DIA_PotentialDiagnosis.Query.Search(Connection, Transaction, potentialDiagnoseQuery).Single();

            #region Deactivation in days
            potentialDiagnose.DefaultTimeUntillDeactivation_InDays = Parameter.Deactivation_inDays;
            potentialDiagnose.Save(Connection, Transaction);
            #endregion

            #region Save Localization
            List<P_L5ME_SL_1047_Localization> LocalizationList = new List<P_L5ME_SL_1047_Localization>();

            foreach (var item in Parameter.Localization)
            {
                P_L5ME_SL_1047_Localization param = new P_L5ME_SL_1047_Localization();
                param.IsDeleted = item.IsDeleted;
                param.LocalizationID = item.LocalizationID;
                param.LocalizationName = item.LocalizationName;
                LocalizationList.Add(param);
            }

            P_L5ME_SL_1047 par = new P_L5ME_SL_1047();
            par.DiagnoseID = Parameter.DiagnoseID;
            par.Localization = LocalizationList.ToArray();
            cls_Save_Localization.Invoke(Connection, Transaction, par, securityTicket);
            #endregion

            #region Save catalog - diagnose details

            foreach (var item in Parameter.CatalogDiagnoseData)
            {
               var catalogCodeQuery = new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query();
               catalogCodeQuery.Tenant_RefID = securityTicket.TenantID;
               catalogCodeQuery.IsDeleted = false;
               catalogCodeQuery.PotentialDiagnosis_Catalog_RefID = item.HEC_DIA_PotentialDiagnosis_CatalogID;
               catalogCodeQuery.PotentialDiagnosis_RefID = Parameter.DiagnoseID;

               var catalogCode = ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query.Search(Connection, Transaction, catalogCodeQuery).SingleOrDefault();

               if (item.isDiagnoseAddedToCatalog)
               {
                   if (catalogCode == null)
                   {
                       catalogCode = new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode();
                       catalogCode.HEC_DIA_PotentialDiagnosis_CatalogCodeID = Guid.NewGuid();
                       catalogCode.Tenant_RefID = securityTicket.TenantID;
                       catalogCode.Creation_Timestamp = DateTime.Now;
                       catalogCode.PotentialDiagnosis_Catalog_RefID = item.HEC_DIA_PotentialDiagnosis_CatalogID;
                       catalogCode.PotentialDiagnosis_RefID = Parameter.DiagnoseID;
                       catalogCode.Code = potentialDiagnose.ICD10_Code;
                       catalogCode.Save(Connection, Transaction);

                       //if (item.isFavouriteStatus)
                       //{
                       //    var prioritySequence = new ORM_HEC_DIA_PotentialDiagnosis_PrioritySequence();
                       //    prioritySequence.HEC_DIA_PotentialDiagnosis_PrioritySequenceID = Guid.NewGuid();
                       //    prioritySequence.PotentialDiagnosis_RefID = Parameter.DiagnoseID;
                       //    prioritySequence.PotentialDiagnosis_Catalog_RefID = item.HEC_DIA_PotentialDiagnosis_CatalogID;
                       //    prioritySequence.Tenant_RefID = securityTicket.TenantID;
                       //    prioritySequence.Creation_Timestamp = DateTime.Now;
                       //    prioritySequence.Save(Connection, Transaction);
                       //}
                   }
                   //else
                   //{
                   //    var prioritySequenceQuery = new ORM_HEC_DIA_PotentialDiagnosis_PrioritySequence.Query();
                   //    prioritySequenceQuery.IsDeleted = false;
                   //    prioritySequenceQuery.Tenant_RefID = securityTicket.TenantID;
                   //    prioritySequenceQuery.PotentialDiagnosis_RefID = Parameter.DiagnoseID;
                   //    prioritySequenceQuery.PotentialDiagnosis_Catalog_RefID = item.HEC_DIA_PotentialDiagnosis_CatalogID;

                   //    var prioritySequence = ORM_HEC_DIA_PotentialDiagnosis_PrioritySequence.Query.Search(Connection, Transaction, prioritySequenceQuery).SingleOrDefault();

                   //    if (item.isFavouriteStatus)
                   //    {
                   //        if (prioritySequence == null)
                   //        {
                   //            prioritySequence = new ORM_HEC_DIA_PotentialDiagnosis_PrioritySequence();
                   //            prioritySequence.HEC_DIA_PotentialDiagnosis_PrioritySequenceID = Guid.NewGuid();
                   //            prioritySequence.PotentialDiagnosis_RefID = Parameter.DiagnoseID;
                   //            prioritySequence.PotentialDiagnosis_Catalog_RefID = item.HEC_DIA_PotentialDiagnosis_CatalogID;
                   //            prioritySequence.Tenant_RefID = securityTicket.TenantID;
                   //            prioritySequence.Creation_Timestamp = DateTime.Now;
                   //            prioritySequence.Save(Connection, Transaction);
                   //        }
                   //    }
                   //    else
                   //    {
                   //        if (prioritySequence != null)
                   //        {
                   //            prioritySequence.IsDeleted = true;
                   //            prioritySequence.Save(Connection, Transaction);
                   //        }
                   //    }
                   //}
               }
               else
               {
                   if (catalogCode != null)
                   {
                       catalogCode.IsDeleted = true;
                       catalogCode.Save(Connection, Transaction);

                       //var prioritySequenceQuery = new ORM_HEC_DIA_PotentialDiagnosis_PrioritySequence.Query();
                       //prioritySequenceQuery.IsDeleted = false;
                       //prioritySequenceQuery.Tenant_RefID = securityTicket.TenantID;
                       //prioritySequenceQuery.PotentialDiagnosis_RefID = Parameter.DiagnoseID;
                       //prioritySequenceQuery.PotentialDiagnosis_Catalog_RefID = item.HEC_DIA_PotentialDiagnosis_CatalogID;

                       //var prioritySequence = ORM_HEC_DIA_PotentialDiagnosis_PrioritySequence.Query.Search(Connection, Transaction, prioritySequenceQuery).SingleOrDefault();

                       //if (prioritySequence != null)
                       //{
                       //    prioritySequence.IsDeleted = true;
                       //    prioritySequence.Save(Connection, Transaction);
                       //}
                   }
               }

            }

            #endregion

            #region Save Observation
            List<P_L5DI_SPO_1452_PotentialObservation> ObservationList = new List<P_L5DI_SPO_1452_PotentialObservation>();
            foreach (var item in Parameter.PotentialObservation)
            {
                P_L5DI_SPO_1452_PotentialObservation observation = new P_L5DI_SPO_1452_PotentialObservation();
                observation.IsDeleted = item.IsDeleted;
                observation.NewPotentialObservation = item.NewPotentialObservation;
                observation.Observation_Text = item.Observation_Text;
                observation.PotentialDiagnosis_RefID = item.PotentialDiagnosis_RefID;
                observation.PotentialObservationID = item.PotentialObservationID;
                observation.TypicalPotentialObservationID = item.TypicalPotentialObservationID;
                ObservationList.Add(observation);
            }
            P_L5DI_SPO_1452 observationParam = new P_L5DI_SPO_1452();
            observationParam.PotentialObservation = ObservationList.ToArray();
            cls_Save_PotentialObservation.Invoke(Connection, Transaction, observationParam, securityTicket);
            #endregion

            #region Hospital Referral
            //List<P_L5DI_SPHR_1208_PossibleHospitalReferral> PossibleReferralList = new List<P_L5DI_SPHR_1208_PossibleHospitalReferral>();

            //foreach (var item in Parameter.PossibleHospitalReferral)
            //{
            //    P_L5DI_SPHR_1208_PossibleHospitalReferral param = new P_L5DI_SPHR_1208_PossibleHospitalReferral();
            //    param.HEC_DIA_FrequentPotentialDiagnosisID = item.HEC_DIA_FrequentPotentialDiagnosisID;
            //    param.IsDeleted = item.IsDeleted;
            //    param.MedicalPractice_RefID = item.MedicalPractice_RefID;
            //    param.PotentialDiagnosis_RefID = item.PotentialDiagnosis_RefID;
            //    PossibleReferralList.Add(param);
            //}

            //P_L5DI_SPHR_1208 posibleRefealParam = new P_L5DI_SPHR_1208();
            //posibleRefealParam.PossibleHospitalReferral = PossibleReferralList.ToArray();
            //cls_Save_PossibleHospitalReferral.Invoke(Connection, Transaction, posibleRefealParam, securityTicket);
            #endregion

            #region Save  Procedure

            List<P_L5DI_SPP_1242_PotentialProcedures> procedureList = new List<P_L5DI_SPP_1242_PotentialProcedures>();
            foreach (var item in Parameter.PotentialProcedures)
            {
                P_L5DI_SPP_1242_PotentialProcedures procedure = new P_L5DI_SPP_1242_PotentialProcedures();
                procedure.HEC_DIA_TypicalPotentialProcedureID = item.HEC_DIA_TypicalPotentialProcedureID;
                procedure.IsDeleted = item.IsDeleted;
                procedure.PotentialDiagnosis_RefID = item.PotentialDiagnosis_RefID;
                procedure.PotentialProcedure_RefID = item.PotentialProcedure_RefID;
                procedureList.Add(procedure);
            }

            P_L5DI_SPP_1242 procedureParam = new P_L5DI_SPP_1242();
            procedureParam.PotentialProcedures = procedureList.ToArray();
            cls_Save_PotentialProcedures.Invoke(Connection, Transaction, procedureParam, securityTicket);

            #endregion

            #region Save RecommendedSubstance
            List<P_L5ME_SRS_1512_RecommendedSubstance> RecommendedSubstanceList = new List<P_L5ME_SRS_1512_RecommendedSubstance>();
            foreach (var item in Parameter.RecommendedSubstance)
            {
                P_L5ME_SRS_1512_RecommendedSubstance substance = new P_L5ME_SRS_1512_RecommendedSubstance();
                substance.IsDeleted = item.IsDeleted;
                substance.DiagnoseID = item.DiagnoseID;
                substance.SubstanceID = item.SubstanceID;
                substance.Substance_Unit_RefID = item.Substance_Unit_RefID;
                substance.SubstanceStrength = item.SubstanceStrength;
                substance.HEC_DIA_RecommendedSubstanceID = item.HEC_DIA_RecommendedSubstanceID;
                List<P_L5ME_SRS_1512_DosageList> dosageList = new List<P_L5ME_SRS_1512_DosageList>();
                foreach (var subitem in item.SubstanceDosageList)
                {
                    P_L5ME_SRS_1512_DosageList dosage = new P_L5ME_SRS_1512_DosageList();
                    dosage.Dosage_RefID = subitem.Dosage_RefID;
                    dosage.HEC_DIA_RecommendedSubstance_DosageID = subitem.HEC_DIA_RecommendedSubstance_DosageID;
                    dosage.IsDefault = subitem.IsDefault;
                    dosage.IsDeleted = subitem.IsDeleted;
                    dosageList.Add(dosage);
                }
                substance.DosageList = dosageList.ToArray();
                RecommendedSubstanceList.Add(substance);
            }
            P_L5ME_SRS_1512 substanceParam = new P_L5ME_SRS_1512();
            substanceParam.RecommendedSubstance = RecommendedSubstanceList.ToArray();
            cls_Save_RecommendedSubstance.Invoke(Connection, Transaction, substanceParam, securityTicket);
            #endregion

            #region Save RecommendedProduct
            List<P_L5ME_SRP_1317_RecommendedProduct> RecommendedProductList = new List<P_L5ME_SRP_1317_RecommendedProduct>();
            foreach (var item in Parameter.RecommendedProduct)
            {
                P_L5ME_SRP_1317_RecommendedProduct product = new P_L5ME_SRP_1317_RecommendedProduct();
                product.IsDeleted = item.IsDeleted;
                product.DiagnoseID = item.DiagnoseID;
                product.ProductID = item.ProductID;
                product.HEC_DIA_RecommendedProductID = item.HEC_DIA_RecommendedProductID;
                List<P_L5ME_SRP_1317_DosageList> dosageList = new List<P_L5ME_SRP_1317_DosageList>();
                foreach (var subitem in item.ProductDosageList)
                {
                    P_L5ME_SRP_1317_DosageList dosageParam = new P_L5ME_SRP_1317_DosageList();
                    dosageParam.Dosage_RefID = subitem.Dosage_RefID;
                    dosageParam.HEC_DIA_RecommendedProduct_DosageID = subitem.HEC_DIA_RecommendedProduct_DosageID;
                    dosageParam.IsDefault = subitem.IsDefault;
                    dosageParam.IsDeleted = subitem.IsDeleted;
                    dosageList.Add(dosageParam);
                }
                product.DosageList = dosageList.ToArray();
                RecommendedProductList.Add(product);
            }
            P_L5ME_SRP_1317 productParam = new P_L5ME_SRP_1317();
            productParam.RecommendedProduct = RecommendedProductList.ToArray();
            cls_Save_RecommendedProduct.Invoke(Connection, Transaction, productParam, securityTicket);
            #endregion

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DI_SDD_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DI_SDD_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DI_SDD_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DI_SDD_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DiagnoseDetails",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6DI_SDD_1202 for attribute P_L6DI_SDD_1202
		[DataContract]
		public class P_L6DI_SDD_1202 
		{
			[DataMember]
			public P_L6DI_SDD_1202_Localization[] Localization { get; set; }
			[DataMember]
			public P_L6DI_SDD_1202_CatalogDiagnoseData[] CatalogDiagnoseData { get; set; }
			[DataMember]
			public P_L6DI_SDD_1202_PossibleHospitalReferral[] PossibleHospitalReferral { get; set; }
			[DataMember]
			public P_L6DI_SDD_1202_PotentialProcedures[] PotentialProcedures { get; set; }
			[DataMember]
			public P_L6DI_SDD_1202_PotentialObservation[] PotentialObservation { get; set; }
			[DataMember]
			public P_L6DI_SDD_1202_RecommendedProduct[] RecommendedProduct { get; set; }
			[DataMember]
			public P_L6DI_SDD_1202_RecommendedSubstance[] RecommendedSubstance { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid DiagnoseID { get; set; } 
			[DataMember]
			public int Deactivation_inDays { get; set; } 

		}
		#endregion
		#region SClass P_L6DI_SDD_1202_Localization for attribute Localization
		[DataContract]
		public class P_L6DI_SDD_1202_Localization 
		{
			//Standard type parameters
			[DataMember]
			public String LocalizationName { get; set; } 
			[DataMember]
			public Guid LocalizationID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L6DI_SDD_1202_CatalogDiagnoseData for attribute CatalogDiagnoseData
		[DataContract]
		public class P_L6DI_SDD_1202_CatalogDiagnoseData 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosis_CatalogID { get; set; } 
			[DataMember]
			public bool isDiagnoseAddedToCatalog { get; set; } 
			[DataMember]
			public bool isFavouriteStatus { get; set; } 

		}
		#endregion
		#region SClass P_L6DI_SDD_1202_PossibleHospitalReferral for attribute PossibleHospitalReferral
		[DataContract]
		public class P_L6DI_SDD_1202_PossibleHospitalReferral 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_FrequentPotentialDiagnosisID { get; set; } 
			[DataMember]
			public Guid PotentialDiagnosis_RefID { get; set; } 
			[DataMember]
			public Guid MedicalPractice_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L6DI_SDD_1202_PotentialProcedures for attribute PotentialProcedures
		[DataContract]
		public class P_L6DI_SDD_1202_PotentialProcedures 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_TypicalPotentialProcedureID { get; set; } 
			[DataMember]
			public Guid PotentialDiagnosis_RefID { get; set; } 
			[DataMember]
			public Guid PotentialProcedure_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L6DI_SDD_1202_PotentialObservation for attribute PotentialObservation
		[DataContract]
		public class P_L6DI_SDD_1202_PotentialObservation 
		{
			//Standard type parameters
			[DataMember]
			public Guid TypicalPotentialObservationID { get; set; } 
			[DataMember]
			public Guid PotentialObservationID { get; set; } 
			[DataMember]
			public Guid PotentialDiagnosis_RefID { get; set; } 
			[DataMember]
			public Dict Observation_Text { get; set; } 
			[DataMember]
			public bool NewPotentialObservation { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L6DI_SDD_1202_RecommendedProduct for attribute RecommendedProduct
		[DataContract]
		public class P_L6DI_SDD_1202_RecommendedProduct 
		{
			[DataMember]
			public P_L6DI_SDD_1202_ProductDosageList[] ProductDosageList { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_RecommendedProductID { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Guid DiagnoseID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L6DI_SDD_1202_ProductDosageList for attribute ProductDosageList
		[DataContract]
		public class P_L6DI_SDD_1202_ProductDosageList 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_RecommendedProduct_DosageID { get; set; } 
			[DataMember]
			public Guid Dosage_RefID { get; set; } 
			[DataMember]
			public bool IsDefault { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L6DI_SDD_1202_RecommendedSubstance for attribute RecommendedSubstance
		[DataContract]
		public class P_L6DI_SDD_1202_RecommendedSubstance 
		{
			[DataMember]
			public P_L6DI_SDD_1202_SubstanceDosageList[] SubstanceDosageList { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_RecommendedSubstanceID { get; set; } 
			[DataMember]
			public Guid DiagnoseID { get; set; } 
			[DataMember]
			public Guid SubstanceID { get; set; } 
			[DataMember]
			public String SubstanceStrength { get; set; } 
			[DataMember]
			public Guid Substance_Unit_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L6DI_SDD_1202_SubstanceDosageList for attribute SubstanceDosageList
		[DataContract]
		public class P_L6DI_SDD_1202_SubstanceDosageList 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_RecommendedSubstance_DosageID { get; set; } 
			[DataMember]
			public Guid Dosage_RefID { get; set; } 
			[DataMember]
			public bool IsDefault { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DiagnoseDetails(,P_L6DI_SDD_1202 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DiagnoseDetails.Invoke(connectionString,P_L6DI_SDD_1202 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Diagnosis.Complex.Manipulation.P_L6DI_SDD_1202();
parameter.Localization = ...;
parameter.CatalogDiagnoseData = ...;
parameter.PossibleHospitalReferral = ...;
parameter.PotentialProcedures = ...;
parameter.PotentialObservation = ...;
parameter.RecommendedProduct = ...;
parameter.RecommendedSubstance = ...;

parameter.DiagnoseID = ...;
parameter.Deactivation_inDays = ...;

*/
