/* 
 * Generated on 11/12/2014 5:20:53 PM
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
    /// var result = cls_Save_DiagnosisCatalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DiagnosisCatalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_SDC_1032 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            //get languages for Tenant
            P_L2LN_GALFTID_1530 langParam = new P_L2LN_GALFTID_1530();
            langParam.Tenant_RefID = securityTicket.TenantID;
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, langParam, securityTicket).Result;

            #region Save
            if (Parameter.CatalogID == Guid.Empty || Parameter.CatalogID == null)
            {

                ORM_HEC_DIA_PotentialDiagnosis_Catalog catalog = new ORM_HEC_DIA_PotentialDiagnosis_Catalog();
                catalog.HEC_DIA_PotentialDiagnosis_CatalogID = Guid.NewGuid();
                catalog.Creation_Timestamp = DateTime.Now;
                catalog.IsPrivateCatalog = Parameter.IsPrivateCatalog;
                catalog.Tenant_RefID = securityTicket.TenantID;
                catalog.GlobalPropertyMatchingID = Parameter.Catalog_Name;
                catalog.Catalog_DisplayName = Parameter.Catalog_Name;

                Dict Catalogname = new Dict("hec_dia_potentialdiagnosis_catalogs");
                for (int i = 0; i < DBLanguages.Length; i++)
                {
                    Catalogname.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.Catalog_Name);
                }
                catalog.Catalog_Name = Catalogname;
                catalog.Save(Connection, Transaction);
            }
            #endregion
            else
            {
                //Delete
                if (Parameter.isDeleted)
                {
                    var catalogQuery = new ORM_HEC_DIA_PotentialDiagnosis_Catalog.Query();
                    catalogQuery.HEC_DIA_PotentialDiagnosis_CatalogID = Parameter.CatalogID;
                    catalogQuery.IsDeleted = false;
                    catalogQuery.Tenant_RefID = securityTicket.TenantID;

                    var catalog = ORM_HEC_DIA_PotentialDiagnosis_Catalog.Query.Search(Connection, Transaction, catalogQuery).Single();
                    catalog.IsDeleted = true;
                    catalog.Save(Connection, Transaction);

                    //Delete catalog products table
                    var catalogCodeQuery = new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query();
                    catalogCodeQuery.IsDeleted = false;
                    catalogCodeQuery.PotentialDiagnosis_Catalog_RefID = catalog.HEC_DIA_PotentialDiagnosis_CatalogID;
                    catalogCodeQuery.Tenant_RefID = securityTicket.TenantID;

                    ORM_HEC_DIA_PotentialDiagnosis_CatalogCode.Query.SoftDelete(Connection, Transaction, catalogCodeQuery);
                }
                 //Edit
                else
                {
                    var catalogQuery = new ORM_HEC_DIA_PotentialDiagnosis_Catalog.Query();
                    catalogQuery.IsDeleted = false;
                    catalogQuery.HEC_DIA_PotentialDiagnosis_CatalogID = Parameter.CatalogID;
                    catalogQuery.Tenant_RefID = securityTicket.TenantID;

                    var catalog = ORM_HEC_DIA_PotentialDiagnosis_Catalog.Query.Search(Connection, Transaction, catalogQuery).Single();
                    catalog.GlobalPropertyMatchingID = Parameter.Catalog_Name;
                    catalog.Catalog_DisplayName = Parameter.Catalog_Name;
                    catalog.IsPrivateCatalog = Parameter.IsPrivateCatalog;

                    Dict Catalogname = new Dict("hec_dia_potentialdiagnosis_catalogs");
                    for (int i = 0; i < DBLanguages.Length; i++)
                    {
                        Catalogname.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.Catalog_Name);
                    }
                    catalog.Catalog_Name = Catalogname;
                    catalog.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_L5DI_SDC_1032 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DI_SDC_1032 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_SDC_1032 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_SDC_1032 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DiagnosisCatalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DI_SDC_1032 for attribute P_L5DI_SDC_1032
		[DataContract]
		public class P_L5DI_SDC_1032 
		{
			[DataMember]
			public P_L5DI_SDC_1032_CatalogAccess[] CatalogAccess { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CatalogID { get; set; } 
			[DataMember]
			public Boolean isDeleted { get; set; } 
			[DataMember]
			public String Catalog_Name { get; set; } 
			[DataMember]
			public bool IsPrivateCatalog { get; set; } 

		}
		#endregion
		#region SClass P_L5DI_SDC_1032_CatalogAccess for attribute CatalogAccess
		[DataContract]
		public class P_L5DI_SDC_1032_CatalogAccess 
		{
			//Standard type parameters
			[DataMember]
			public Guid Catalog_AccessID { get; set; } 
			[DataMember]
			public bool IsContributor { get; set; } 
			[DataMember]
			public Boolean isDeleted { get; set; } 
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DiagnosisCatalog(,P_L5DI_SDC_1032 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DiagnosisCatalog.Invoke(connectionString,P_L5DI_SDC_1032 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Manipulation.P_L5DI_SDC_1032();
parameter.CatalogAccess = ...;

parameter.CatalogID = ...;
parameter.isDeleted = ...;
parameter.Catalog_Name = ...;
parameter.IsPrivateCatalog = ...;

*/
