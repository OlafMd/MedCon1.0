/* 
 * Generated on 7/22/2013 3:25:54 PM
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
using CL1_RES_QST;

namespace CL5_KPRS_Questionnaire.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Questionnaires_For_QuestionnaireID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Questionnaires_For_QuestionnaireID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5QT_GQFQI_1517 Execute(DbConnection Connection,DbTransaction Transaction,P_L5QT_GQFQI_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5QT_GQFQI_1517();

            returnValue.Result = new L5QT_GQFQI_1517();


            ORM_RES_QST_Questionnaire questionnaire = new ORM_RES_QST_Questionnaire();
            questionnaire.Load(Connection, Transaction, Parameter.QuestionnaireID);
            returnValue.Result.Questionnaire = questionnaire;

            ORM_RES_QST_Questionnaire_Version version = new ORM_RES_QST_Questionnaire_Version();
            version.Load(Connection, Transaction, questionnaire.Current_QuestionnaireVersion_RefID);
            returnValue.Result.QuestionnaireVersion = version;
             
            
            ORM_RES_QST_Apartment_AvailableProperty.Query apartmentQuery = new ORM_RES_QST_Apartment_AvailableProperty.Query();
            apartmentQuery.Tenant_RefID = securityTicket.TenantID;
            apartmentQuery.IsDeleted = false;
            apartmentQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_Apartment_AvailableProperty> apartments = ORM_RES_QST_Apartment_AvailableProperty.Query.Search(Connection, Transaction, apartmentQuery);
            returnValue.Result.Apartments = apartments.ToArray();

            ORM_RES_QST_Attic_AvailableProperty.Query atticQuery = new ORM_RES_QST_Attic_AvailableProperty.Query();
            atticQuery.Tenant_RefID = securityTicket.TenantID;
            atticQuery.IsDeleted = false;
            atticQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_Attic_AvailableProperty> attics = ORM_RES_QST_Attic_AvailableProperty.Query.Search(Connection, Transaction, atticQuery);
            returnValue.Result.Attics = attics.ToArray();

            ORM_RES_QST_Basement_AvailableProperty.Query basementQuery = new ORM_RES_QST_Basement_AvailableProperty.Query();
            basementQuery.Tenant_RefID = securityTicket.TenantID;
            basementQuery.IsDeleted = false;
            basementQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_Basement_AvailableProperty> basements = ORM_RES_QST_Basement_AvailableProperty.Query.Search(Connection, Transaction, basementQuery);
            returnValue.Result.Basements = basements.ToArray();

            ORM_RES_QST_Facade_AvailableProperty.Query facadeQuery = new ORM_RES_QST_Facade_AvailableProperty.Query();
            facadeQuery.Tenant_RefID = securityTicket.TenantID;
            facadeQuery.IsDeleted = false;
            facadeQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_Facade_AvailableProperty> facades = ORM_RES_QST_Facade_AvailableProperty.Query.Search(Connection, Transaction, facadeQuery);
            returnValue.Result.Facades = facades.ToArray();

            ORM_RES_QST_HVACR_AvailableProperty.Query hvacrQuery = new ORM_RES_QST_HVACR_AvailableProperty.Query();
            hvacrQuery.Tenant_RefID = securityTicket.TenantID;
            hvacrQuery.IsDeleted = false;
            hvacrQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_HVACR_AvailableProperty> hvacrs = ORM_RES_QST_HVACR_AvailableProperty.Query.Search(Connection, Transaction, hvacrQuery);
            returnValue.Result.Hvacr = hvacrs.ToArray();

            ORM_RES_QST_OutdoorFacility_AvailableProperty.Query outdoorQuery = new ORM_RES_QST_OutdoorFacility_AvailableProperty.Query();
            outdoorQuery.Tenant_RefID = securityTicket.TenantID;
            outdoorQuery.IsDeleted = false;
            outdoorQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_OutdoorFacility_AvailableProperty> outdoors = ORM_RES_QST_OutdoorFacility_AvailableProperty.Query.Search(Connection, Transaction, outdoorQuery);
            returnValue.Result.OutdoorFacilities = outdoors.ToArray();

            ORM_RES_QST_Roof_AvailableProperty.Query roofQuery = new ORM_RES_QST_Roof_AvailableProperty.Query();
            roofQuery.Tenant_RefID = securityTicket.TenantID;
            roofQuery.IsDeleted = false;
            roofQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_Roof_AvailableProperty> roofs = ORM_RES_QST_Roof_AvailableProperty.Query.Search(Connection, Transaction, roofQuery);
            returnValue.Result.Roofs = roofs.ToArray();

            ORM_RES_QST_Staircase_AvailableProperty.Query staircaseQuery = new ORM_RES_QST_Staircase_AvailableProperty.Query();
            staircaseQuery.Tenant_RefID = securityTicket.TenantID;
            staircaseQuery.IsDeleted = false;
            staircaseQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_Staircase_AvailableProperty> staircases = ORM_RES_QST_Staircase_AvailableProperty.Query.Search(Connection, Transaction, staircaseQuery);
            returnValue.Result.Staircases = staircases.ToArray();

          
            //Put your code here
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5QT_GQFQI_1517 Invoke(string ConnectionString,P_L5QT_GQFQI_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5QT_GQFQI_1517 Invoke(DbConnection Connection,P_L5QT_GQFQI_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5QT_GQFQI_1517 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5QT_GQFQI_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5QT_GQFQI_1517 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5QT_GQFQI_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5QT_GQFQI_1517 functionReturn = new FR_L5QT_GQFQI_1517();
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

				throw new Exception("Exception occured in method cls_Get_Questionnaires_For_QuestionnaireID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5QT_GQFQI_1517 : FR_Base
	{
		public L5QT_GQFQI_1517 Result	{ get; set; }

		public FR_L5QT_GQFQI_1517() : base() {}

		public FR_L5QT_GQFQI_1517(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5QT_GQFQI_1517 for attribute P_L5QT_GQFQI_1517
		[DataContract]
		public class P_L5QT_GQFQI_1517 
		{
			//Standard type parameters
			[DataMember]
			public Guid QuestionnaireID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQFQI_1517 for attribute L5QT_GQFQI_1517
		[DataContract]
		public class L5QT_GQFQI_1517 
		{
			//Standard type parameters
			[DataMember]
			public ORM_RES_QST_Questionnaire Questionnaire { get; set; } 
			[DataMember]
			public ORM_RES_QST_Questionnaire_Version QuestionnaireVersion { get; set; } 
			[DataMember]
			public ORM_RES_QST_Apartment_AvailableProperty[] Apartments { get; set; } 
			[DataMember]
			public ORM_RES_QST_Attic_AvailableProperty[] Attics { get; set; } 
			[DataMember]
			public ORM_RES_QST_Basement_AvailableProperty[] Basements { get; set; } 
			[DataMember]
			public ORM_RES_QST_Facade_AvailableProperty[] Facades { get; set; } 
			[DataMember]
			public ORM_RES_QST_HVACR_AvailableProperty[] Hvacr { get; set; } 
			[DataMember]
			public ORM_RES_QST_Roof_AvailableProperty[] Roofs { get; set; } 
			[DataMember]
			public ORM_RES_QST_OutdoorFacility_AvailableProperty[] OutdoorFacilities { get; set; } 
			[DataMember]
			public ORM_RES_QST_Staircase_AvailableProperty[] Staircases { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5QT_GQFQI_1517 cls_Get_Questionnaires_For_QuestionnaireID(,P_L5QT_GQFQI_1517 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5QT_GQFQI_1517 invocationResult = cls_Get_Questionnaires_For_QuestionnaireID.Invoke(connectionString,P_L5QT_GQFQI_1517 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_Questionnaire.Complex.Retrieval.P_L5QT_GQFQI_1517();
parameter.QuestionnaireID = ...;

*/