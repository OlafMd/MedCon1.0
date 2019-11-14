/* 
 * Generated on 3/23/2015 3:38:20 PM
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
using CL1_HEC_DIA;

namespace CL5_MyHealthClub_Diagnosis.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Diagnose.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Diagnose
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_SD_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            returnValue.Result = Guid.Empty;

            P_L2LN_GALFTID_1530 langParam = new P_L2LN_GALFTID_1530();
            langParam.Tenant_RefID = securityTicket.TenantID;
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, langParam, securityTicket).Result;

            #region Save
            if (Parameter.DiagnoseID == Guid.Empty)
            {
                var potentialDiagnosis = new ORM_HEC_DIA_PotentialDiagnosis();
                potentialDiagnosis.HEC_DIA_PotentialDiagnosisID = Guid.NewGuid();
                potentialDiagnosis.ICD10_Code = Parameter.DiagnoseICD10;
                Dict name = new Dict("hec_dia_potentialdiagnoses");
                for (int i = 0; i < DBLanguages.Length; i++)
                {
                    name.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.Name);
                }
                potentialDiagnosis.PotentialDiagnosis_Name = name;
                Dict description = new Dict("hec_dia_potentialdiagnoses");
                for (int i = 0; i < DBLanguages.Length; i++)
                {
                    description.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.Description);
                }
                potentialDiagnosis.PotentialDiagnosis_Description = description;
                potentialDiagnosis.Tenant_RefID = securityTicket.TenantID;
                potentialDiagnosis.Creation_Timestamp = DateTime.Now;
                potentialDiagnosis.Modification_Timestamp = DateTime.Now;
                potentialDiagnosis.Save(Connection, Transaction);

                ORM_HEC_DIA_PotentialDiagnosis_CatalogCode catalogCode = new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode();
                catalogCode.HEC_DIA_PotentialDiagnosis_CatalogCodeID = Guid.NewGuid();
                catalogCode.Code = Parameter.DiagnoseICD10;
                catalogCode.PotentialDiagnosis_RefID = potentialDiagnosis.HEC_DIA_PotentialDiagnosisID;
                catalogCode.PotentialDiagnosis_Catalog_RefID = Parameter.PotentialDiagnosis_CatalogID;
                catalogCode.Tenant_RefID = securityTicket.TenantID;
                catalogCode.Save(Connection, Transaction);

                returnValue.Result = potentialDiagnosis.HEC_DIA_PotentialDiagnosisID;
            }
            #endregion
            else
            {
                var potentialDiagnosisQuery = new ORM_HEC_DIA_PotentialDiagnosis.Query();
                potentialDiagnosisQuery.IsDeleted = false;
                potentialDiagnosisQuery.HEC_DIA_PotentialDiagnosisID = Parameter.DiagnoseID;

                var potentialDiagnosis = ORM_HEC_DIA_PotentialDiagnosis.Query.Search(Connection, Transaction, potentialDiagnosisQuery).Single();

                #region Delete
                if (Parameter.IsDeleted)
                {
                    ORM_HEC_DIA_PotentialDiagnosis_CatalogCode catalogCode = ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query.Search(Connection, Transaction, new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query
                    {
                        PotentialDiagnosis_RefID = potentialDiagnosis.HEC_DIA_PotentialDiagnosisID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();

                    catalogCode.IsDeleted = false;
                    catalogCode.Save(Connection, Transaction);

                    potentialDiagnosis.IsDeleted = true;
                    potentialDiagnosis.Save(Connection, Transaction);
                }
                #endregion
                #region Edit
                else
                {
                    potentialDiagnosis.ICD10_Code = Parameter.DiagnoseICD10;
                    Dict name = new Dict("hec_dia_potentialdiagnoses");
                    for (int i = 0; i < DBLanguages.Length; i++)
                    {
                        name.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.Name);
                    }
                    potentialDiagnosis.PotentialDiagnosis_Name = name;
                    Dict description = new Dict("hec_dia_potentialdiagnoses");
                    for (int i = 0; i < DBLanguages.Length; i++)
                    {
                        description.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.Description);
                    }
                    potentialDiagnosis.PotentialDiagnosis_Description = description;
                    potentialDiagnosis.Modification_Timestamp = DateTime.Now;
                    potentialDiagnosis.Save(Connection, Transaction);
                }

                returnValue.Result = potentialDiagnosis.HEC_DIA_PotentialDiagnosisID;
                #endregion
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DI_SD_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DI_SD_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_SD_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_SD_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Diagnose",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DI_SD_1633 for attribute P_L5DI_SD_1633
		[DataContract]
		public class P_L5DI_SD_1633 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiagnoseID { get; set; } 
			[DataMember]
			public string DiagnoseICD10 { get; set; } 
			[DataMember]
			public string Name { get; set; } 
			[DataMember]
			public string Description { get; set; } 
			[DataMember]
			public Guid PotentialDiagnosis_CatalogID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Diagnose(,P_L5DI_SD_1633 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Diagnose.Invoke(connectionString,P_L5DI_SD_1633 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Manipulation.P_L5DI_SD_1633();
parameter.DiagnoseID = ...;
parameter.DiagnoseICD10 = ...;
parameter.Name = ...;
parameter.Description = ...;
parameter.PotentialDiagnosis_CatalogID = ...;
parameter.IsDeleted = ...;

*/
