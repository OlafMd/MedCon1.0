/* 
 * Generated on 10/30/2014 11:30:16 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL1_HEC_DIA;

namespace CL5_MyHealthClub_Diagnosis.Atomic.Manipulation
{
	[Serializable]
	public class cls_Save_FavouriteDiagnoseScore
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_SFDS_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();

                foreach (var catalog in Parameter.SelfLearningData)
                {
                    var potentialDiagnosisCatalogQuery = new ORM_HEC_DIA_PotentialDiagnosis_Catalog.Query();
                    potentialDiagnosisCatalogQuery.Tenant_RefID = securityTicket.TenantID;
                    potentialDiagnosisCatalogQuery.IsDeleted = false;
                    potentialDiagnosisCatalogQuery.HEC_DIA_PotentialDiagnosis_CatalogID = catalog.CatalogID;

                    var potentialCatalog = ORM_HEC_DIA_PotentialDiagnosis_Catalog.Query.Search(Connection, Transaction, potentialDiagnosisCatalogQuery).Single();

                    if (catalog.isSelfLearning)
                    {                      
                        potentialCatalog.IsUsingSelfLearningPriorities = true;
                        potentialCatalog.SelfLearningPriorities_InitializationTreshold = Int32.Parse(catalog.Initialization_Threshold);
                        potentialCatalog.SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount = Int32.Parse(catalog.FavouriteDiagnoseIntervalinDays);
                        potentialCatalog.Save(Connection, Transaction);
                    }
                    else
                    {
                        potentialCatalog.IsUsingSelfLearningPriorities = false;
                        potentialCatalog.SelfLearningPriorities_InitializationTreshold = 0;
                        potentialCatalog.SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount = 0;
                        potentialCatalog.Save(Connection, Transaction);
                    }
                }

                foreach (var diagnose in Parameter.Diagnoses)
                {
                    var potentionalDiagnosePrioritySequenceQuery = new ORM_HEC_DIA_PotentialDiagnosis_PrioritySequence.Query();
                    potentionalDiagnosePrioritySequenceQuery.Tenant_RefID = securityTicket.TenantID;
                    potentionalDiagnosePrioritySequenceQuery.IsDeleted = false;
                    potentionalDiagnosePrioritySequenceQuery.HEC_DIA_PotentialDiagnosis_PrioritySequenceID = diagnose.PrioritySequenceID;

                    var potentionalDiagnosePrioritySequence = ORM_HEC_DIA_PotentialDiagnosis_PrioritySequence.Query.Search(Connection, Transaction, potentionalDiagnosePrioritySequenceQuery).Single();


                    if (!Parameter.SelfLearningData.Where(i => i.CatalogID == potentionalDiagnosePrioritySequence.PotentialDiagnosis_Catalog_RefID).Single().isSelfLearning)
                    {
                        potentionalDiagnosePrioritySequence.PriorityNumber_Manual = Int32.Parse(diagnose.ManualScore);
                        potentionalDiagnosePrioritySequence.PriorityNumber_Automatic = Int32.Parse(diagnose.CalculatedScore);
                        potentionalDiagnosePrioritySequence.Save(Connection, Transaction);
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
		public static FR_Guids Invoke(string ConnectionString,P_L5DI_SFDS_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5DI_SFDS_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_SFDS_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_SFDS_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guids functionReturn = new FR_Guids();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DI_SFDS_1352 for attribute P_L5DI_SFDS_1352
		[Serializable]
		public class P_L5DI_SFDS_1352 
		{
			public P_L5DI_SFDS_1352_SelfLearningData[] SelfLearningData;  
			public P_L5DI_SFDS_1352_Diagnoses[] Diagnoses;  

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5DI_SFDS_1352_SelfLearningData for attribute SelfLearningData
		[Serializable]
		public class P_L5DI_SFDS_1352_SelfLearningData 
		{
			//Standard type parameters
			public bool isSelfLearning; 
			public Guid CatalogID; 
			public String Initialization_Threshold; 
			public String FavouriteDiagnoseIntervalinDays; 

		}
		#endregion
		#region SClass P_L5DI_SFDS_1352_Diagnoses for attribute Diagnoses
		[Serializable]
		public class P_L5DI_SFDS_1352_Diagnoses 
		{
			//Standard type parameters
			public Guid PrioritySequenceID; 
			public String CalculatedScore; 
			public String ManualScore; 

		}
		#endregion

	#endregion
}
