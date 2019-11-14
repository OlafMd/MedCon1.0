/* 
 * Generated on 7/2/2013 9:21:32 AM
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

namespace CL5_KPRS_Questionnaire.Atomic.Manipulation
{
	[DataContract]
	public class cls_Save_Questionnaire
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SQ_SU_1250 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            ORM_RES_QST_Questionnaire_Version oldVersion = new ORM_RES_QST_Questionnaire_Version();

            ORM_RES_QST_Questionnaire questionnaire = new ORM_RES_QST_Questionnaire();
            int versionNumber = 0;
            if (Parameter.RES_QST_QuestionnaireID != Guid.Empty)
            {
                var result = questionnaire.Load(Connection, Transaction, Parameter.RES_QST_QuestionnaireID);
                if (result.Status != FR_Status.Success || questionnaire.RES_QST_QuestionnaireID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                ORM_RES_QST_Questionnaire_Version.Query versionQuery = new ORM_RES_QST_Questionnaire_Version.Query();
                versionQuery.Tenant_RefID = securityTicket.TenantID;
                versionQuery.IsDeleted = false;
                versionQuery.Questionnaire_RefID = questionnaire.RES_QST_QuestionnaireID;
                List<ORM_RES_QST_Questionnaire_Version> versions = ORM_RES_QST_Questionnaire_Version.Query.Search(Connection, Transaction, versionQuery);

                versionNumber = versions.Max(i => i.QuestionnaireVersion_VersionNumber);
                oldVersion = versions.FirstOrDefault(i => i.QuestionnaireVersion_VersionNumber == versionNumber);
                versionNumber++;

            }
            else
            {
                versionNumber = 1;
                questionnaire.Tenant_RefID = securityTicket.TenantID;
            }

            ORM_RES_QST_Questionnaire_Version version = new ORM_RES_QST_Questionnaire_Version();
            version.QuestionnaireVersion_VersionNumber = versionNumber;
            version.Questionnaire_RefID = questionnaire.RES_QST_QuestionnaireID;
            version.IsApartmentStructureVisible = Parameter.IsApartmentStructureVisible;
            version.IsAtticVisible = Parameter.IsAtticVisible;
            version.IsBasementVisible = Parameter.IsBasementVisible;
            version.IsFacadeVisible = Parameter.IsFacadeVisible;
            version.IsHVACRVisible = Parameter.IsHVACRVisible;
            version.IsOutdoorFacilityVisible = Parameter.IsOutdoorFacilityVisible;
            version.IsRoofVisible = Parameter.IsRoofVisible;
            version.IsStaircaseStructureVisible = Parameter.IsStaircaseStructureVisible;
            version.Tenant_RefID = securityTicket.TenantID;
            version.Save(Connection, Transaction);

            questionnaire.Questionnaire_Description = Parameter.Questionnaire_Description;
            questionnaire.Questionnaire_Name = Parameter.Questionnaire_Name;
            questionnaire.Current_QuestionnaireVersion_RefID = version.RES_QST_Questionnaire_VersionID;
            questionnaire.Save(Connection, Transaction);



            // OutdoorFacility, Facade, Roof, Attic, Staircase, Basement, HVCAR, Appartment

            foreach (var question in Parameter.availableQuestions)
            {
                if (question.questionType == "OutdoorFacility")
                {
                    ORM_RES_QST_OutdoorFacility_AvailableProperty item = new ORM_RES_QST_OutdoorFacility_AvailableProperty();
                    item.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
                    item.RES_STR_OutdoorFacility_Property_RefID = question.questionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }
                else if (question.questionType == "Facade")
                {
                    ORM_RES_QST_Facade_AvailableProperty item = new ORM_RES_QST_Facade_AvailableProperty();
                    item.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
                    item.RES_STR_Facade_Property_RefID = question.questionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }
                else if (question.questionType == "Roof")
                {
                    ORM_RES_QST_Roof_AvailableProperty item = new ORM_RES_QST_Roof_AvailableProperty();
                    item.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
                    item.RES_STR_Roof_Property_RefID = question.questionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }
                else if (question.questionType == "Attic")
                {
                    ORM_RES_QST_Attic_AvailableProperty item = new ORM_RES_QST_Attic_AvailableProperty();
                    item.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
                    item.RES_STR_Attic_Property_RefID = question.questionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }
                else if (question.questionType == "Staircase")
                {
                    ORM_RES_QST_Staircase_AvailableProperty item = new ORM_RES_QST_Staircase_AvailableProperty();
                    item.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
                    item.RES_STR_Staircase_Property_RefID = question.questionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }
                else if (question.questionType == "Basement")
                {
                    ORM_RES_QST_Basement_AvailableProperty item = new ORM_RES_QST_Basement_AvailableProperty();
                    item.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
                    item.RES_STR_Basement_Property_RefID = question.questionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }
                else if (question.questionType == "HVCAR")
                {
                    ORM_RES_QST_HVACR_AvailableProperty item = new ORM_RES_QST_HVACR_AvailableProperty();
                    item.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
                    item.RES_STR_HVACR_Property_RefID = question.questionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }
                else if (question.questionType == "Apartment")
                {
                    ORM_RES_QST_Apartment_AvailableProperty item = new ORM_RES_QST_Apartment_AvailableProperty();
                    item.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
                    item.RES_STR_Apartment_Property_RefID = question.questionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }
            }

            returnValue.Result = questionnaire.RES_QST_QuestionnaireID;


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SQ_SU_1250 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SQ_SU_1250 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SQ_SU_1250 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SQ_SU_1250 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L5SQ_SU_1250 for attribute P_L5SQ_SU_1250
		[DataContract]
		public class P_L5SQ_SU_1250 
		{
			[DataMember]
			public P_L5SQ_SU_1250_availableQuestions[] availableQuestions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_QST_QuestionnaireID { get; set; } 
			[DataMember]
			public Dict Questionnaire_Description { get; set; } 
			[DataMember]
			public Dict Questionnaire_Name { get; set; } 
			[DataMember]
			public bool IsApartmentStructureVisible { get; set; } 
			[DataMember]
			public bool IsStaircaseStructureVisible { get; set; } 
			[DataMember]
			public bool IsOutdoorFacilityVisible { get; set; } 
			[DataMember]
			public bool IsFacadeVisible { get; set; } 
			[DataMember]
			public bool IsRoofVisible { get; set; } 
			[DataMember]
			public bool IsAtticVisible { get; set; } 
			[DataMember]
			public bool IsBasementVisible { get; set; } 
			[DataMember]
			public bool IsHVACRVisible { get; set; } 

		}
		#endregion
		#region SClass P_L5SQ_SU_1250_availableQuestions for attribute availableQuestions
		[DataContract]
		public class P_L5SQ_SU_1250_availableQuestions 
		{
			//Standard type parameters
			[DataMember]
			public Guid questionID { get; set; } 
			[DataMember]
			public String questionType { get; set; } 
			[DataMember]
			public bool questionIsAvailable { get; set; } 

		}
		#endregion

	#endregion
}
