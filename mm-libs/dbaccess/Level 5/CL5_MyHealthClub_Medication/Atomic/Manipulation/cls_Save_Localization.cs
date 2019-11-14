/* 
 * Generated on 10/2/2014 10:53:29 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL1_HEC;
using CL2_Language.Atomic.Retrieval;
using CL1_HEC_DIA;

namespace CL5_MyHealthClub_Medication.Atomic.Manipulation
{
	[Serializable]
	public class cls_Save_Localization
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_SL_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            //get languages for Tenant
            P_L2LN_GALFTID_1530 langParam = new P_L2LN_GALFTID_1530();
            langParam.Tenant_RefID = securityTicket.TenantID;
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, langParam, securityTicket).Result;

            foreach (var item in Parameter.Localization)
            {
                //Delete
                if (item.IsDeleted)
                {
                    var localizationQuery = new ORM_HEC_DIA_Diagnosis_Localization.Query();
                    localizationQuery.IsDeleted = false;
                    localizationQuery.HEC_DIA_Diagnosis_LocalizationID = item.LocalizationID;
                    localizationQuery.Diagnosis_RefID = Parameter.DiagnoseID;

                    var localization = ORM_HEC_DIA_Diagnosis_Localization.Query.Search(Connection, Transaction, localizationQuery).SingleOrDefault();

                    if (localization != null)
                    {
                        localization.IsDeleted = true;
                        localization.Save(Connection, Transaction);
                    }
                }
                else
                {
                    var localizationQuery = new ORM_HEC_DIA_Diagnosis_Localization.Query();
                    localizationQuery.IsDeleted = false;
                    localizationQuery.HEC_DIA_Diagnosis_LocalizationID = item.LocalizationID;
                    localizationQuery.Diagnosis_RefID = Parameter.DiagnoseID;

                    var localization = ORM_HEC_DIA_Diagnosis_Localization.Query.Search(Connection, Transaction, localizationQuery).SingleOrDefault();

                    //Edit
                    if (localization != null)
                    {
                        Dict name = new Dict("hec_dia_diagnosis_localizations");
                        for (int i = 0; i < DBLanguages.Length; i++)
                        {
                            name.AddEntry(DBLanguages[i].CMN_LanguageID, item.LocalizationName);
                        }

                        localization.DiagnosisLocalization_Name = name;
                        localization.Save(Connection, Transaction);
                    }
                    else // New
                    {
                        ORM_HEC_DIA_Diagnosis_Localization localizationNew = new ORM_HEC_DIA_Diagnosis_Localization();
                        localizationNew.HEC_DIA_Diagnosis_LocalizationID = item.LocalizationID;
                        Dict name = new Dict("hec_dia_diagnosis_localizations");
                        for (int i = 0; i < DBLanguages.Length; i++)
                        {
                            name.AddEntry(DBLanguages[i].CMN_LanguageID, item.LocalizationName);
                        }

                        localizationNew.DiagnosisLocalization_Name = name;
                        localizationNew.Tenant_RefID = securityTicket.TenantID;
                        localizationNew.Creation_Timestamp = DateTime.Now;
                        localizationNew.Diagnosis_RefID = Parameter.DiagnoseID;
                        localizationNew.Save(Connection, Transaction);


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
		public static FR_Guid Invoke(string ConnectionString,P_L5ME_SL_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5ME_SL_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_SL_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_SL_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ME_SL_1047 for attribute P_L5ME_SL_1047
		[Serializable]
		public class P_L5ME_SL_1047 
		{
			public P_L5ME_SL_1047_Localization[] Localization;  

			//Standard type parameters
			public Guid DiagnoseID; 

		}
		#endregion
		#region SClass P_L5ME_SL_1047_Localization for attribute Localization
		[Serializable]
		public class P_L5ME_SL_1047_Localization 
		{
			//Standard type parameters
			public String LocalizationName; 
			public Guid LocalizationID; 
			public bool IsDeleted; 

		}
		#endregion

	#endregion
}
