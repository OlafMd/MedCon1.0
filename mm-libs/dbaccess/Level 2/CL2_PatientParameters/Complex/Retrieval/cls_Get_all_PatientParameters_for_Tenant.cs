/* 
 * Generated on 2/6/2015 15:54:33
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
using CL2_PatientParameters.DomainManagement;
using CL1_HEC;
using System.Xml;
using System.Reflection;
using DLCore_DBCommons;
using CL2_Language.Atomic.Retrieval;
using CL2_Contact.Complex.Retrieval;
namespace CL2_PatientParameters.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_all_PatientParameters_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_all_PatientParameters_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PP_GaPP_1554_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L2PP_GaPP_1554_Array();
			//Put your code here
            var parameterTypes = DMPatientParameterTypes.Get_PredefinedPatientParameterTypes(Connection, Transaction,securityTicket);
             List<L2PP_GaPP_1554> patParameters = new List<L2PP_GaPP_1554>();
             

            P_L2LN_GALFTID_1530 param = new P_L2LN_GALFTID_1530();
            param.Tenant_RefID = securityTicket.TenantID;
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, param, securityTicket).Result;

            var languages = DBLanguages.Select(i => new ISOLanguage() { ISO = i.ISO_639_1, LanguageID = i.CMN_LanguageID }).ToList();
            Assembly asm = Assembly.GetExecutingAssembly();
            XmlDocument resource = new XmlDocument();
            var xmlpath = asm.GetManifestResourceStream(DMPatientParameterTypes.ResourceFilePath);
            XmlTextReader reader = new XmlTextReader(xmlpath);
            resource.Load(reader);
            
            var predefinedPatientParameterTypes = DMPatientParameterTypes.Get_PredefinedPatientParameterTypes(Connection, Transaction, securityTicket);

            var globalPropertyMatchingIDs = predefinedPatientParameterTypes.Select(i => i.GlobalPropertyMatchingID).ToList();

            var globalMatching2Dict = DBCommonsReader.Instance.GetDictObjectsFromResourceFile(globalPropertyMatchingIDs, resource,
                ORM_HEC_Patient_Parameter.TableName, languages);

            foreach (var item in parameterTypes)
            {
                var patientParameter = ORM_HEC_Patient_Parameter.Query.Search(Connection, Transaction, new ORM_HEC_Patient_Parameter.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    GlobalPropertyMatchingID = item.GlobalPropertyMatchingID
                });
                if (patientParameter != null && patientParameter.Count != 0)
                {
                    L2PP_GaPP_1554 patParameter = new L2PP_GaPP_1554();
                    patParameter.GlobalPropertyMatchingID = item.GlobalPropertyMatchingID;
                    patParameter.PatientParameter_ID = patientParameter.Single().HEC_Patient_ParameterID;
                    patParameters.Add(patParameter);
                }
                else
                {
                    ORM_HEC_Patient_Parameter newPatparameter = new ORM_HEC_Patient_Parameter();
                    newPatparameter.IsVitalParameter = true;
                    newPatparameter.ParameterType_RefID = DMPatientParameterTypes.Get_PatientParameterTypes_for_GlobalPropertyMatchingID(Connection, Transaction, item.GlobalPropertyMatchingID, securityTicket);
                    newPatparameter.Tenant_RefID = securityTicket.TenantID;
                    newPatparameter.PatientParameterITL = Guid.NewGuid().ToString();
                    newPatparameter.GlobalPropertyMatchingID = item.GlobalPropertyMatchingID;
                    newPatparameter.IsString = true;
                    newPatparameter.Parameter_Name = globalMatching2Dict[item.GlobalPropertyMatchingID];
                    newPatparameter.Save(Connection, Transaction);

                    L2PP_GaPP_1554 patParameter = new L2PP_GaPP_1554();
                    patParameter.GlobalPropertyMatchingID = item.GlobalPropertyMatchingID;
                    patParameter.PatientParameter_ID = newPatparameter.HEC_Patient_ParameterID;
                    patParameters.Add(patParameter);
                    
                }
            }
            returnValue.Result = patParameters.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2PP_GaPP_1554_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PP_GaPP_1554_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PP_GaPP_1554_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PP_GaPP_1554_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PP_GaPP_1554_Array functionReturn = new FR_L2PP_GaPP_1554_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_all_PatientParameters_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PP_GaPP_1554_Array : FR_Base
	{
		public L2PP_GaPP_1554[] Result	{ get; set; } 
		public FR_L2PP_GaPP_1554_Array() : base() {}

		public FR_L2PP_GaPP_1554_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2PP_GaPP_1554 for attribute L2PP_GaPP_1554
		[DataContract]
		public class L2PP_GaPP_1554 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientParameter_ID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PP_GaPP_1554_Array cls_Get_all_PatientParameters_for_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PP_GaPP_1554_Array invocationResult = cls_Get_all_PatientParameters_for_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

