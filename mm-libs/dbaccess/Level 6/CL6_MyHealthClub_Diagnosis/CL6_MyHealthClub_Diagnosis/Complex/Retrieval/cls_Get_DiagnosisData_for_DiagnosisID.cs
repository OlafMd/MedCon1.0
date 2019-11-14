/* 
 * Generated on 12/9/2014 2:16:44 PM
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
using CL5_MyHealthClub_Diagnosis.Atomic.Manipulation;
using CL5_MyHealthClub_Diagnosis.Atomic.Retrieval;
using CL5_MyHealthClub_Medication.Atomic.Retrieval;

namespace CL6_MyHealthClub_Diagnosis.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DiagnosisData_for_DiagnosisID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DiagnosisData_for_DiagnosisID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DI_GDDfDID_1106 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DI_GDDfDID_1106 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6DI_GDDfDID_1106();
            returnValue.Result = new L6DI_GDDfDID_1106();
            L5DI_GDfDID_1102 diagnosisData = new L5DI_GDfDID_1102();
            returnValue.Result.DiagnosesData = diagnosisData;
            List<L6DI_GDDfDID_1106_CatalogData> catalogDataList = new List<L6DI_GDDfDID_1106_CatalogData>();
            returnValue.Result.CatalogData = catalogDataList.ToArray();
            List<L5DI_GLfDID_1731> localizationList = new List<L5DI_GLfDID_1731>();
            returnValue.Result.Localization = localizationList.ToArray();
            List<L5DI_GPOfDID_1216> observationList = new List<L5DI_GPOfDID_1216>();
            returnValue.Result.Observation_for_DiagnoseID = observationList.ToArray();
            List<L5DI_GPHRfDID_1139> hospitalReferalList = new List<L5DI_GPHRfDID_1139>();
            returnValue.Result.HospitalReferral = hospitalReferalList.ToArray();
            List<L5DI_GPPfDID_1239> procedureList = new List<L5DI_GPPfDID_1239>();
            returnValue.Result.Procedures = procedureList.ToArray();
            List<L5ME_GRPfPDID_1202> recommendedProductList = new List<L5ME_GRPfPDID_1202>();
            returnValue.Result.RecommendedProduct = recommendedProductList.ToArray();
            List<L5ME_GRSfPDID_1506> recommendedSubstancesList = new List<L5ME_GRSfPDID_1506>();
            returnValue.Result.RecommendedSubstances = recommendedSubstancesList.ToArray();


            /*@
           * 
           * Get diagnosisData
           * ************************************/
            P_L5DI_GDfDID_1102 param = new P_L5DI_GDfDID_1102();
            param.DiagnosisID = Parameter.DiagnosisID;
            returnValue.Result.DiagnosesData = cls_Get_Diagnosis_for_DiagnosisID.Invoke(Connection, Transaction, param,securityTicket).Result;


            /*@
           * 
           * Get all catalogs
           * ************************************/
            var allCatalogs = cls_Get_DiagnosesCatalog_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            /*@
             * 
             * Get catalog Data for diagnose id
             * ************************************/
            P_L5DI_GCDfDID__1606 catalogParam = new P_L5DI_GCDfDID__1606();
            catalogParam.DiagnoseID = Parameter.DiagnosisID;

            var dataForCatalogsList = cls_Get_CatalogData_for_DiagnoseID.Invoke(Connection, Transaction, catalogParam, securityTicket).Result.ToList();

            foreach (var catalog in allCatalogs)
            {
                L6DI_GDDfDID_1106_CatalogData catalogData = new L6DI_GDDfDID_1106_CatalogData();
                catalogData.Catalog_Name = catalog.Catalog_DisplayName;
                catalogData.HEC_DIA_PotentialDiagnosis_CatalogID = catalog.HEC_DIA_PotentialDiagnosis_CatalogID;

                var neededData = dataForCatalogsList.Where(i => i.HEC_DIA_PotentialDiagnosis_CatalogID == catalog.HEC_DIA_PotentialDiagnosis_CatalogID).SingleOrDefault();

                if (neededData != null)
                {
                    catalogData.isDiagnoseAddedToCatalog = true;
                    //if (neededData.HEC_DIA_PotentialDiagnosis_PrioritySequenceID != null && neededData.HEC_DIA_PotentialDiagnosis_PrioritySequenceID != Guid.Empty)
                    //    catalogData.isFavouriteStatus = true;
                }
                catalogDataList.Add(catalogData);
            }
            returnValue.Result.CatalogData = catalogDataList.ToArray();

            /*@
              * 
              * Get Localization for diagnose id
              * ************************************/
            P_L5DI_GLfDID_1731 localizationParam = new P_L5DI_GLfDID_1731();
            localizationParam.DiagnosisID = Parameter.DiagnosisID;
            returnValue.Result.Localization = cls_Get_Localization_for_DiagnosisID.Invoke(Connection, Transaction, localizationParam, securityTicket).Result;

            /*@
              * 
              * Get Observation for diagnose id
              * ************************************/
            P_L5DI_GPOfDID_1216 observationParam = new P_L5DI_GPOfDID_1216();
            observationParam.DiagnosisID = Parameter.DiagnosisID;
            returnValue.Result.Observation_for_DiagnoseID = cls_Get_PotentialObservation_for_DiagnosisID.Invoke(Connection, Transaction, observationParam, securityTicket).Result;

            /*@
            * 
            * Get HospitalReferral for diagnose id
            * ************************************/
            //P_L5DI_GPHRfDID_1139 hospitalReferalParam = new P_L5DI_GPHRfDID_1139();
            //hospitalReferalParam.DiagnosisID = Parameter.DiagnosisID;
            //returnValue.Result.HospitalReferral = cls_Get_PossibleHospitalReferral_for_DiagnosisID.Invoke(Connection, Transaction, hospitalReferalParam, securityTicket).Result;

            /*@
            * 
            * Get Procedures for diagnose id
            * ************************************/
            P_L5DI_GPPfDID_1239 procedureParam = new P_L5DI_GPPfDID_1239();
            procedureParam.DiagnosisID = Parameter.DiagnosisID;
            returnValue.Result.Procedures = cls_Get_PotentialProcedures_for_DiagnosisID.Invoke(Connection, Transaction, procedureParam, securityTicket).Result;

            /*@
            * 
            * Get RecommendedSubstances for diagnose id
            * ************************************/
            P_L5ME_GRSfPDID_1506 recommendedSubstancesParam = new P_L5ME_GRSfPDID_1506();
            recommendedSubstancesParam.PotentialDiagnosisID = Parameter.DiagnosisID;
            returnValue.Result.RecommendedSubstances = cls_Get_RecommendedSubstances_for_PotentialDiagnosisID.Invoke(Connection, Transaction, recommendedSubstancesParam, securityTicket).Result;

            /*@
            * 
            * Get RecommendedProduct for diagnose id
            * ************************************/
            P_L5ME_GRPfPDID_1202 recommendedProductParam = new P_L5ME_GRPfPDID_1202();
            recommendedProductParam.DiagnosisID = Parameter.DiagnosisID;
            returnValue.Result.RecommendedProduct = cls_Get_RecommendedProduct_for_PotentialDiagnosisID.Invoke(Connection, Transaction, recommendedProductParam, securityTicket).Result;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DI_GDDfDID_1106 Invoke(string ConnectionString,P_L6DI_GDDfDID_1106 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DI_GDDfDID_1106 Invoke(DbConnection Connection,P_L6DI_GDDfDID_1106 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DI_GDDfDID_1106 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DI_GDDfDID_1106 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DI_GDDfDID_1106 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DI_GDDfDID_1106 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DI_GDDfDID_1106 functionReturn = new FR_L6DI_GDDfDID_1106();
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

				throw new Exception("Exception occured in method cls_Get_DiagnosisData_for_DiagnosisID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DI_GDDfDID_1106 : FR_Base
	{
		public L6DI_GDDfDID_1106 Result	{ get; set; }

		public FR_L6DI_GDDfDID_1106() : base() {}

		public FR_L6DI_GDDfDID_1106(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DI_GDDfDID_1106 for attribute P_L6DI_GDDfDID_1106
		[DataContract]
		public class P_L6DI_GDDfDID_1106 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiagnosisID { get; set; } 

		}
		#endregion
		#region SClass L6DI_GDDfDID_1106 for attribute L6DI_GDDfDID_1106
		[DataContract]
		public class L6DI_GDDfDID_1106 
		{
			[DataMember]
			public L6DI_GDDfDID_1106_CatalogData[] CatalogData { get; set; }

			//Standard type parameters
			[DataMember]
			public L5DI_GDfDID_1102 DiagnosesData { get; set; } 
			[DataMember]
			public L5DI_GLfDID_1731[] Localization { get; set; } 
			[DataMember]
			public L5DI_GPOfDID_1216[] Observation_for_DiagnoseID { get; set; } 
			[DataMember]
			public L5DI_GPHRfDID_1139[] HospitalReferral { get; set; } 
			[DataMember]
			public L5DI_GPPfDID_1239[] Procedures { get; set; } 
			[DataMember]
			public L5ME_GRPfPDID_1202[] RecommendedProduct { get; set; } 
			[DataMember]
			public L5ME_GRSfPDID_1506[] RecommendedSubstances { get; set; } 

		}
		#endregion
		#region SClass L6DI_GDDfDID_1106_CatalogData for attribute CatalogData
		[DataContract]
		public class L6DI_GDDfDID_1106_CatalogData 
		{
			//Standard type parameters
			[DataMember]
			public String Catalog_Name { get; set; } 
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosis_CatalogID { get; set; } 
			[DataMember]
			public bool isDiagnoseAddedToCatalog { get; set; } 
			[DataMember]
			public bool isFavouriteStatus { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DI_GDDfDID_1106 cls_Get_DiagnosisData_for_DiagnosisID(,P_L6DI_GDDfDID_1106 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DI_GDDfDID_1106 invocationResult = cls_Get_DiagnosisData_for_DiagnosisID.Invoke(connectionString,P_L6DI_GDDfDID_1106 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Diagnosis.Complex.Retrieval.P_L6DI_GDDfDID_1106();
parameter.DiagnosisID = ...;

*/
