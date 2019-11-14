/* 
 * Generated on 8/20/2013 2:25:35 PM
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
using CL1_RES_STR;

namespace CL5_KPRS_Questionnaire.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_QuestionnaireInfo_for_VersionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_QuestionnaireInfo_for_VersionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5QT_GQIfVI_1048 Execute(DbConnection Connection,DbTransaction Transaction,P_L5QT_GQIfVI_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5QT_GQIfVI_1048();
            //Put your code here
            var ormQuestionnaireVersion = new ORM_RES_QST_Questionnaire_Version();
            ormQuestionnaireVersion.Load(Connection, Transaction, Parameter.QuestionnaireVersionID);

            returnValue.Result = new L5QT_GQIfVI_1048();
            returnValue.Result.IsApartmentStructureVisible = ormQuestionnaireVersion.IsApartmentStructureVisible;
            returnValue.Result.IsAtticVisible = ormQuestionnaireVersion.IsAtticVisible;
            returnValue.Result.IsBasementVisible = ormQuestionnaireVersion.IsBasementVisible;
            returnValue.Result.IsFacadeVisible = ormQuestionnaireVersion.IsFacadeVisible;
            returnValue.Result.IsHVACRVisible = ormQuestionnaireVersion.IsHVACRVisible;
            returnValue.Result.IsOutdoorFacilityVisible = ormQuestionnaireVersion.IsOutdoorFacilityVisible;
            returnValue.Result.IsRoofVisible = ormQuestionnaireVersion.IsRoofVisible;
            returnValue.Result.IsStaircaseStructureVisible = ormQuestionnaireVersion.IsStaircaseStructureVisible;
            returnValue.Result.QuestionnaireVersion_Comment = ormQuestionnaireVersion.QuestionnaireVersion_Comment;
            returnValue.Result.QuestionnaireVersion_VersionNumber = ormQuestionnaireVersion.QuestionnaireVersion_VersionNumber.ToString();
            returnValue.Result.RES_QST_Questionnaire_VersionID = ormQuestionnaireVersion.RES_QST_Questionnaire_VersionID;
            returnValue.Result.RES_QST_QuestionnaireID = ormQuestionnaireVersion.Questionnaire_RefID;

            var ormQuestionnaire = new ORM_RES_QST_Questionnaire();
            ormQuestionnaire.Load(Connection, Transaction, ormQuestionnaireVersion.Questionnaire_RefID);
            returnValue.Result.Questionnaire_Description = ormQuestionnaire.Questionnaire_Description;
            returnValue.Result.Questionnaire_Name = ormQuestionnaire.Questionnaire_Name;
            

            #region ApartmentInfo
            var apartmentPropertyInfoList = new List<L5QT_GQIfVI_1048_Apartments>();
            var ormApartmentAvailableProperties = ORM_RES_QST_Apartment_AvailableProperty.Query.Search(Connection, Transaction, new ORM_RES_QST_Apartment_AvailableProperty.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                RES_QST_Questionnaire_Version_RefID = Parameter.QuestionnaireVersionID
            });

            foreach (var ormAvailableProperty in ormApartmentAvailableProperties)
            {
                var buildingPart = new L5QT_GQIfVI_1048_Apartments();
               
                var ormBuildingPartProperty = new ORM_RES_STR_Apartment_Property();
                ormBuildingPartProperty.Load(Connection, Transaction, ormAvailableProperty.RES_STR_Apartment_Property_RefID);
                
                buildingPart.ApartmentProperty_GlobalID = ormBuildingPartProperty.GlobalPropertyMatchingID;
                buildingPart.ApartmentProperty_Name = ormBuildingPartProperty.ApartmentProperty_Name;
                buildingPart.RES_STR_Apartment_PropertyID = ormBuildingPartProperty.RES_STR_Apartment_PropertyID;


                var ormBuildingPartAvailableActions = ORM_RES_STR_Apartment_Property_AvailableAction.Query.Search(Connection, Transaction, new ORM_RES_STR_Apartment_Property_AvailableAction.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    RES_STR_Apartment_Property_RefID = ormBuildingPartProperty.RES_STR_Apartment_PropertyID
                });

                var buildingPartAvailableActions = new List<L5QT_GQIfVI_1048_ApartmentAvailableActions>();
                foreach (var availableAction in ormBuildingPartAvailableActions)
                {
                    buildingPartAvailableActions.Add(new L5QT_GQIfVI_1048_ApartmentAvailableActions()
                    {
                        Apartment_Action_RefID = availableAction.RES_ACT_Action_RefID,
                        RES_STR_Apartment_Property_AvailableActionID = availableAction.RES_STR_Apartment_Property_AvailableActionID
                    });
                }
                buildingPart.ApartmentAvailableActions = buildingPartAvailableActions.ToArray();

                apartmentPropertyInfoList.Add(buildingPart);
            }
            returnValue.Result.Apartments = apartmentPropertyInfoList.ToArray();
            #endregion ApartmentInfo

            #region AtticInfo
            var atticPropertyInfoList = new List<L5QT_GQIfVI_1048_Attics>();
            var ormAtticAvailableProperties = ORM_RES_QST_Attic_AvailableProperty.Query.Search(Connection, Transaction, new ORM_RES_QST_Attic_AvailableProperty.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                RES_QST_Questionnaire_Version_RefID = Parameter.QuestionnaireVersionID
            });

            foreach (var ormAvailableProperty in ormAtticAvailableProperties)
            {
                var buildingPart = new L5QT_GQIfVI_1048_Attics();

                var ormBuildingPartProperty = new ORM_RES_STR_Attic_Property();
                ormBuildingPartProperty.Load(Connection, Transaction, ormAvailableProperty.RES_STR_Attic_Property_RefID);

                buildingPart.AtticProperty_GlobalID = ormBuildingPartProperty.GlobalPropertyMatchingID;
                buildingPart.AtticProperty_Name = ormBuildingPartProperty.AtticProperty_Name;
                buildingPart.RES_STR_Attic_PropertyID = ormBuildingPartProperty.RES_STR_Attic_PropertyID;

                var ormBuildingPartAvailableActions = ORM_RES_STR_Attic_Property_AvailableAction.Query.Search(Connection, Transaction, new ORM_RES_STR_Attic_Property_AvailableAction.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    RES_STR_Attic_Property_RefID = ormBuildingPartProperty.RES_STR_Attic_PropertyID
                });

                var buildingPartAvailableActions = new List<L5QT_GQIfVI_1048_AtticAvailableActions>();
                foreach (var availableAction in ormBuildingPartAvailableActions)
                {
                    buildingPartAvailableActions.Add(new L5QT_GQIfVI_1048_AtticAvailableActions()
                    {
                        Attic_Action_RefID = availableAction.RES_ACT_Action_RefID,
                        RES_STR_Attic_Property_AvailableActionID = availableAction.RES_STR_Attic_Property_AvailableActionID
                    });
                }
                buildingPart.AtticAvailableActions = buildingPartAvailableActions.ToArray();

                atticPropertyInfoList.Add(buildingPart);
            }
            returnValue.Result.Attics = atticPropertyInfoList.ToArray();
            #endregion AtticInfo

            #region BasementInfo
            var basementPropertyInfoList = new List<L5QT_GQIfVI_1048_Basements>();
            var ormBasementAvailableProperties = ORM_RES_QST_Basement_AvailableProperty.Query.Search(Connection, Transaction, new ORM_RES_QST_Basement_AvailableProperty.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                RES_QST_Questionnaire_Version_RefID = Parameter.QuestionnaireVersionID
            });

            foreach (var ormAvailableProperty in ormBasementAvailableProperties)
            {
                var buildingPart = new L5QT_GQIfVI_1048_Basements();

                var ormBuildingPartProperty = new ORM_RES_STR_Basement_Property();
                ormBuildingPartProperty.Load(Connection, Transaction, ormAvailableProperty.RES_STR_Basement_Property_RefID);

                buildingPart.BasementProperty_GlobalID = ormBuildingPartProperty.GlobalPropertyMatchingID;
                buildingPart.BasementProperty_Name = ormBuildingPartProperty.BasementProperty_Name;
                buildingPart.RES_STR_Basement_PropertyID = ormBuildingPartProperty.RES_STR_Basement_PropertyID;

                var ormBuildingPartAvailableActions = ORM_RES_STR_Basement_Property_AvailableAction.Query.Search(Connection, Transaction, new ORM_RES_STR_Basement_Property_AvailableAction.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    RES_STR_Basement_Property_RefID = ormBuildingPartProperty.RES_STR_Basement_PropertyID
                });

                var buildingPartAvailableActions = new List<L5QT_GQIfVI_1048_BasementAvailableActions>();
                foreach (var availableAction in ormBuildingPartAvailableActions)
                {
                    buildingPartAvailableActions.Add(new L5QT_GQIfVI_1048_BasementAvailableActions()
                    {
                        Basement_Action_RefID = availableAction.RES_ACT_Action_RefID,
                        RES_STR_Basement_Property_AvailableActionID = availableAction.RES_STR_Basement_Property_AvailableActionID
                    });
                }
                buildingPart.BasementAvailableActions = buildingPartAvailableActions.ToArray();

                basementPropertyInfoList.Add(buildingPart);
            }
            returnValue.Result.Basements = basementPropertyInfoList.ToArray();
            #endregion 

            
            #region StaircaseInfo
            var staircasePropertyInfoList = new List<L5QT_GQIfVI_1048_Staircases>();
            var ormStaircaseAvailableProperties = ORM_RES_QST_Staircase_AvailableProperty.Query.Search(Connection, Transaction, new ORM_RES_QST_Staircase_AvailableProperty.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                RES_QST_Questionnaire_Version_RefID = Parameter.QuestionnaireVersionID
            });

            foreach (var ormAvailableProperty in ormStaircaseAvailableProperties)
            {
                var buildingPart = new L5QT_GQIfVI_1048_Staircases();

                var ormBuildingPartProperty = new ORM_RES_STR_Staircase_Property();
                ormBuildingPartProperty.Load(Connection, Transaction, ormAvailableProperty.RES_STR_Staircase_Property_RefID);

                buildingPart.StaircaseProperty_GlobalID = ormBuildingPartProperty.GlobalPropertyMatchingID;
                buildingPart.StaircaseProperty_Name = ormBuildingPartProperty.StaircaseProperty_Name;
                buildingPart.RES_STR_Staircase_PropertyID = ormBuildingPartProperty.RES_STR_Staircase_PropertyID;

                var ormBuildingPartAvailableActions = ORM_RES_STR_Staircase_Property_AvailableAction.Query.Search(Connection, Transaction, new ORM_RES_STR_Staircase_Property_AvailableAction.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    RES_STR_Staircase_Property_RefID = ormBuildingPartProperty.RES_STR_Staircase_PropertyID
                });

                var buildingPartAvailableActions = new List<L5QT_GQIfVI_1048_StaircaseAvailableActions>();
                foreach (var availableAction in ormBuildingPartAvailableActions)
                {
                    buildingPartAvailableActions.Add(new L5QT_GQIfVI_1048_StaircaseAvailableActions()
                    {
                        Staricase_Action_RefID = availableAction.RES_ACT_Action_RefID,
                        RES_STR_Staircase_Property_AvailableActionsID= availableAction.RES_STR_Staircase_Property_AvailableActionsID
                    });
                }
                buildingPart.StaircaseAvailableActions = buildingPartAvailableActions.ToArray();

                staircasePropertyInfoList.Add(buildingPart);
            }
            returnValue.Result.Staircases = staircasePropertyInfoList.ToArray();
            #endregion 

                        
            #region FacadeInfo
            var facadePropertyInfoList = new List<L5QT_GQIfVI_1048_Facades>();
            var ormFacadeAvailableProperties = ORM_RES_QST_Facade_AvailableProperty.Query.Search(Connection, Transaction, new ORM_RES_QST_Facade_AvailableProperty.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                RES_QST_Questionnaire_Version_RefID = Parameter.QuestionnaireVersionID
            });

            foreach (var ormAvailableProperty in ormFacadeAvailableProperties)
            {
                var buildingPart = new L5QT_GQIfVI_1048_Facades();

                var ormBuildingPartProperty = new ORM_RES_STR_Facade_Property();
                ormBuildingPartProperty.Load(Connection, Transaction, ormAvailableProperty.RES_STR_Facade_Property_RefID);

                buildingPart.FacadeProperty_GlobalID = ormBuildingPartProperty.GlobalPropertyMatchingID;
                buildingPart.FacadeProperty_Name = ormBuildingPartProperty.FacadeProperty_Name;
                buildingPart.RES_STR_Facade_PropertyID = ormBuildingPartProperty.RES_STR_Facade_PropertyID;

                var ormBuildingPartAvailableActions = ORM_RES_STR_Facade_Property_AvailableAction.Query.Search(Connection, Transaction, new ORM_RES_STR_Facade_Property_AvailableAction.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    RES_STR_Facade_Property_RefID = ormBuildingPartProperty.RES_STR_Facade_PropertyID
                });

                var buildingPartAvailableActions = new List<L5QT_GQIfVI_1048_FacadeAvailableActions>();
                foreach (var availableAction in ormBuildingPartAvailableActions)
                {
                    buildingPartAvailableActions.Add(new L5QT_GQIfVI_1048_FacadeAvailableActions()
                    {
                        Facade_Action_RefID = availableAction.RES_ACT_Action_RefID,
                        RES_STR_Facade_Property_AvailableActionID= availableAction.RES_STR_Facade_Property_AvailableActionID
                    });
                }
                buildingPart.FacadeAvailableActions = buildingPartAvailableActions.ToArray();

                facadePropertyInfoList.Add(buildingPart);
            }
            returnValue.Result.Facades = facadePropertyInfoList.ToArray();
            #endregion 

            #region RoofInfo
            var roofPropertyInfoList = new List<L5QT_GQIfVI_1048_Roofs>();
            var ormRoofAvailableProperties = ORM_RES_QST_Roof_AvailableProperty.Query.Search(Connection, Transaction, new ORM_RES_QST_Roof_AvailableProperty.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                RES_QST_Questionnaire_Version_RefID = Parameter.QuestionnaireVersionID
            });

            foreach (var ormAvailableProperty in ormRoofAvailableProperties)
            {
                var buildingPart = new L5QT_GQIfVI_1048_Roofs();

                var ormBuildingPartProperty = new ORM_RES_STR_Roof_Property();
                ormBuildingPartProperty.Load(Connection, Transaction, ormAvailableProperty.RES_STR_Roof_Property_RefID);

                buildingPart.RoofProperty_GlobalID = ormBuildingPartProperty.GlobalPropertyMatchingID;
                buildingPart.RoofProperty_Name = ormBuildingPartProperty.RoofProperty_Name;
                buildingPart.RES_STR_Roof_PropertyID = ormBuildingPartProperty.RES_STR_Roof_PropertyID;

                var ormBuildingPartAvailableActions = ORM_RES_STR_Roof_Property_AvailableAction.Query.Search(Connection, Transaction, new ORM_RES_STR_Roof_Property_AvailableAction.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    RES_STR_Roof_Property_RefID = ormBuildingPartProperty.RES_STR_Roof_PropertyID
                });

                var buildingPartAvailableActions = new List<L5QT_GQIfVI_1048_RoofAvailableActions>();
                foreach (var availableAction in ormBuildingPartAvailableActions)
                {
                    buildingPartAvailableActions.Add(new L5QT_GQIfVI_1048_RoofAvailableActions()
                    {
                        Roof_Action_RefID = availableAction.RES_ACT_Action_RefID,
                        RES_STR_Roof_Property_AvailableActionID = availableAction.RES_STR_Roof_Property_AvailableActionID
                    });
                }
                buildingPart.RoofAvailableActions = buildingPartAvailableActions.ToArray();

                roofPropertyInfoList.Add(buildingPart);
            }
            returnValue.Result.Roofs = roofPropertyInfoList.ToArray();
            #endregion 

            #region HVACRInfo
            var HVACRPropertyInfoList = new List<L5QT_GQIfVI_1048_HVACRs>();
            var ormHVACRAvailableProperties = ORM_RES_QST_HVACR_AvailableProperty.Query.Search(Connection, Transaction, new ORM_RES_QST_HVACR_AvailableProperty.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                RES_QST_Questionnaire_Version_RefID = Parameter.QuestionnaireVersionID
            });

            foreach (var ormAvailableProperty in ormHVACRAvailableProperties)
            {
                var buildingPart = new L5QT_GQIfVI_1048_HVACRs();

                var ormBuildingPartProperty = new ORM_RES_STR_HVACR_Property();
                ormBuildingPartProperty.Load(Connection, Transaction, ormAvailableProperty.RES_STR_HVACR_Property_RefID);

                buildingPart.HVACRProperty_GlobalID = ormBuildingPartProperty.GlobalPropertyMatchingID;
                buildingPart.HVACRProperty_Name = ormBuildingPartProperty.HVACRProperty_Name;
                buildingPart.RES_STR_HVACR_PropertyID = ormBuildingPartProperty.RES_STR_HVACR_PropertyID;

                var ormBuildingPartAvailableActions = ORM_RES_STR_HVACR_Property_AvailableAction.Query.Search(Connection, Transaction, new ORM_RES_STR_HVACR_Property_AvailableAction.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    RES_STR_HVACR_Property_RefID = ormBuildingPartProperty.RES_STR_HVACR_PropertyID
                });

                var buildingPartAvailableActions = new List<L5QT_GQIfVI_1048_HVACRAvailableActions>();
                foreach (var availableAction in ormBuildingPartAvailableActions)
                {
                    buildingPartAvailableActions.Add(new L5QT_GQIfVI_1048_HVACRAvailableActions()
                    {
                        HVACR_Action_RefID = availableAction.RES_ACT_Action_RefID,
                        RES_STR_HVACR_Property_AvailableActionID = availableAction.RES_STR_HVACR_Property_AvailableActionID
                    });
                }
                buildingPart.HVACRAvailableActions = buildingPartAvailableActions.ToArray();

                HVACRPropertyInfoList.Add(buildingPart);
            }
            returnValue.Result.HVACRs = HVACRPropertyInfoList.ToArray();
            #endregion 


            
            #region OutfoorFascilityInfo
            var outdoorFascilityPropertyInfoList = new List<L5QT_GQIfVI_1048_OutdoorFacilities>();
            var ormOutdoorFascilityAvailableProperties = ORM_RES_QST_OutdoorFacility_AvailableProperty.Query.Search(Connection, Transaction, new ORM_RES_QST_OutdoorFacility_AvailableProperty.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                RES_QST_Questionnaire_Version_RefID = Parameter.QuestionnaireVersionID
            });

            foreach (var ormAvailableProperty in ormOutdoorFascilityAvailableProperties)
            {
                var buildingPart = new L5QT_GQIfVI_1048_OutdoorFacilities();

                var ormBuildingPartProperty = new ORM_RES_STR_OutdoorFacility_Property();
                ormBuildingPartProperty.Load(Connection, Transaction, ormAvailableProperty.RES_STR_OutdoorFacility_Property_RefID);

                buildingPart.GlobalPropertyMatchingID = ormBuildingPartProperty.GlobalPropertyMatchingID;
                buildingPart.OutdoorFacilityProperty_Name = ormBuildingPartProperty.OutdoorFacilityProperty_Name;
                buildingPart.RES_STR_OutdoorFacility_PropertyID = ormBuildingPartProperty.RES_STR_OutdoorFacility_PropertyID;

                var ormBuildingPartAvailableActions = ORM_RES_STR_OutdoorFacility_Property_AvailableAction.Query.Search(Connection, Transaction, new ORM_RES_STR_OutdoorFacility_Property_AvailableAction.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    RES_STR_OutdoorFacility_Property_RefID= ormBuildingPartProperty.RES_STR_OutdoorFacility_PropertyID
                });

                var buildingPartAvailableActions = new List<L5QT_GQIfVI_1048_OutdoorFacilityAvailableActions>();
                foreach (var availableAction in ormBuildingPartAvailableActions)
                {
                    buildingPartAvailableActions.Add(new L5QT_GQIfVI_1048_OutdoorFacilityAvailableActions()
                    {
                        RES_ACT_Action_RefID = availableAction.RES_ACT_Action_RefID,
                        RES_STR_OutdoorFacility_Property_AvailableActionID= availableAction.RES_STR_OutdoorFacility_Property_AvailableActionID
                    });
                }
                buildingPart.OutdoorFacilityAvailableActions = buildingPartAvailableActions.ToArray();

                outdoorFascilityPropertyInfoList.Add(buildingPart);
            }
            returnValue.Result.OutdoorFacilities = outdoorFascilityPropertyInfoList.ToArray();
            #endregion 


            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5QT_GQIfVI_1048 Invoke(string ConnectionString,P_L5QT_GQIfVI_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5QT_GQIfVI_1048 Invoke(DbConnection Connection,P_L5QT_GQIfVI_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5QT_GQIfVI_1048 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5QT_GQIfVI_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5QT_GQIfVI_1048 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5QT_GQIfVI_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5QT_GQIfVI_1048 functionReturn = new FR_L5QT_GQIfVI_1048();
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

				throw new Exception("Exception occured in method cls_Get_QuestionnaireInfo_for_VersionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5QT_GQIfVI_1048_raw 
	{
		public String QuestionnaireVersion_Comment; 
		public String QuestionnaireVersion_VersionNumber; 
		public bool IsApartmentStructureVisible; 
		public bool IsStaircaseStructureVisible; 
		public bool IsOutdoorFacilityVisible; 
		public bool IsFacadeVisible; 
		public bool IsRoofVisible; 
		public bool IsAtticVisible; 
		public bool IsBasementVisible; 
		public bool IsHVACRVisible; 
		public Guid RES_QST_Questionnaire_VersionID; 
		public Guid RES_QST_QuestionnaireID; 
		public Dict Questionnaire_Name; 
		public Dict Questionnaire_Description; 
		public Dict OutdoorFacilityProperty_Name; 
		public Guid RES_STR_OutdoorFacility_PropertyID; 
		public String GlobalPropertyMatchingID; 
		public Guid RES_STR_OutdoorFacility_Property_AvailableActionID; 
		public Guid RES_ACT_Action_RefID; 
		public Guid RES_STR_Apartment_PropertyID; 
		public Dict ApartmentProperty_Name; 
		public String ApartmentProperty_GlobalID; 
		public Guid RES_STR_Apartment_Property_AvailableActionID; 
		public Guid Apartment_Action_RefID; 
		public Guid RES_STR_Roof_PropertyID; 
		public Dict RoofProperty_Name; 
		public String RoofProperty_GlobalID; 
		public Guid RES_STR_Roof_Property_AvailableActionID; 
		public Guid Roof_Action_RefID; 
		public Guid RES_STR_Facade_PropertyID; 
		public Dict FacadeProperty_Name; 
		public String FacadeProperty_GlobalID; 
		public Guid RES_STR_Facade_Property_AvailableActionID; 
		public Guid Facade_Action_RefID; 
		public Guid RES_STR_Staircase_PropertyID; 
		public Dict StaircaseProperty_Name; 
		public String StaircaseProperty_GlobalID; 
		public Guid RES_STR_Staircase_Property_AvailableActionsID; 
		public Guid Staricase_Action_RefID; 
		public Guid RES_STR_Basement_PropertyID; 
		public Dict BasementProperty_Name; 
		public String BasementProperty_GlobalID; 
		public Guid RES_STR_Basement_Property_AvailableActionID; 
		public Guid Basement_Action_RefID; 
		public Dict HVACRProperty_Name; 
		public Guid RES_STR_HVACR_PropertyID; 
		public String HVACRProperty_GlobalID; 
		public Guid RES_STR_HVACR_Property_AvailableActionID; 
		public Guid HVACR_Action_RefID; 
		public Guid RES_STR_Attic_PropertyID; 
		public Dict AtticProperty_Name; 
		public String AtticProperty_GlobalID; 
		public Guid RES_STR_Attic_Property_AvailableActionID; 
		public Guid Attic_Action_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5QT_GQIfVI_1048[] Convert(List<L5QT_GQIfVI_1048_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5QT_GQIfVI_1048 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_QST_QuestionnaireID)).ToArray()
	group el_L5QT_GQIfVI_1048 by new 
	{ 
		el_L5QT_GQIfVI_1048.RES_QST_QuestionnaireID,

	}
	into gfunct_L5QT_GQIfVI_1048
	select new L5QT_GQIfVI_1048
	{     
		QuestionnaireVersion_Comment = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().QuestionnaireVersion_Comment ,
		QuestionnaireVersion_VersionNumber = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().QuestionnaireVersion_VersionNumber ,
		IsApartmentStructureVisible = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().IsApartmentStructureVisible ,
		IsStaircaseStructureVisible = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().IsStaircaseStructureVisible ,
		IsOutdoorFacilityVisible = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().IsOutdoorFacilityVisible ,
		IsFacadeVisible = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().IsFacadeVisible ,
		IsRoofVisible = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().IsRoofVisible ,
		IsAtticVisible = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().IsAtticVisible ,
		IsBasementVisible = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().IsBasementVisible ,
		IsHVACRVisible = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().IsHVACRVisible ,
		RES_QST_Questionnaire_VersionID = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().RES_QST_Questionnaire_VersionID ,
		RES_QST_QuestionnaireID = gfunct_L5QT_GQIfVI_1048.Key.RES_QST_QuestionnaireID ,
		Questionnaire_Name = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().Questionnaire_Name ,
		Questionnaire_Description = gfunct_L5QT_GQIfVI_1048.FirstOrDefault().Questionnaire_Description ,

		OutdoorFacilities = 
		(
			from el_OutdoorFacilities in gfunct_L5QT_GQIfVI_1048.Where(element => !EqualsDefaultValue(element.RES_STR_OutdoorFacility_PropertyID)).ToArray()
			group el_OutdoorFacilities by new 
			{ 
				el_OutdoorFacilities.RES_STR_OutdoorFacility_PropertyID,

			}
			into gfunct_OutdoorFacilities
			select new L5QT_GQIfVI_1048_OutdoorFacilities
			{     
				OutdoorFacilityProperty_Name = gfunct_OutdoorFacilities.FirstOrDefault().OutdoorFacilityProperty_Name ,
				RES_STR_OutdoorFacility_PropertyID = gfunct_OutdoorFacilities.Key.RES_STR_OutdoorFacility_PropertyID ,
				GlobalPropertyMatchingID = gfunct_OutdoorFacilities.FirstOrDefault().GlobalPropertyMatchingID ,

				OutdoorFacilityAvailableActions = 
				(
					from el_OutdoorFacilityAvailableActions in gfunct_OutdoorFacilities.ToArray()
					select new L5QT_GQIfVI_1048_OutdoorFacilityAvailableActions
					{     
						RES_STR_OutdoorFacility_Property_AvailableActionID = el_OutdoorFacilityAvailableActions.RES_STR_OutdoorFacility_Property_AvailableActionID,
						RES_ACT_Action_RefID = el_OutdoorFacilityAvailableActions.RES_ACT_Action_RefID,

					}
				).ToArray(),

			}
		).ToArray(),
		Apartments = 
		(
			from el_Apartments in gfunct_L5QT_GQIfVI_1048.Where(element => !EqualsDefaultValue(element.RES_STR_Apartment_PropertyID)).ToArray()
			group el_Apartments by new 
			{ 
				el_Apartments.RES_STR_Apartment_PropertyID,

			}
			into gfunct_Apartments
			select new L5QT_GQIfVI_1048_Apartments
			{     
				RES_STR_Apartment_PropertyID = gfunct_Apartments.Key.RES_STR_Apartment_PropertyID ,
				ApartmentProperty_Name = gfunct_Apartments.FirstOrDefault().ApartmentProperty_Name ,
				ApartmentProperty_GlobalID = gfunct_Apartments.FirstOrDefault().ApartmentProperty_GlobalID ,

				ApartmentAvailableActions = 
				(
					from el_ApartmentAvailableActions in gfunct_Apartments.ToArray()
					select new L5QT_GQIfVI_1048_ApartmentAvailableActions
					{     
						RES_STR_Apartment_Property_AvailableActionID = el_ApartmentAvailableActions.RES_STR_Apartment_Property_AvailableActionID,
						Apartment_Action_RefID = el_ApartmentAvailableActions.Apartment_Action_RefID,

					}
				).ToArray(),

			}
		).ToArray(),
		Roofs = 
		(
			from el_Roofs in gfunct_L5QT_GQIfVI_1048.Where(element => !EqualsDefaultValue(element.RES_STR_Roof_PropertyID)).ToArray()
			group el_Roofs by new 
			{ 
				el_Roofs.RES_STR_Roof_PropertyID,

			}
			into gfunct_Roofs
			select new L5QT_GQIfVI_1048_Roofs
			{     
				RES_STR_Roof_PropertyID = gfunct_Roofs.Key.RES_STR_Roof_PropertyID ,
				RoofProperty_Name = gfunct_Roofs.FirstOrDefault().RoofProperty_Name ,
				RoofProperty_GlobalID = gfunct_Roofs.FirstOrDefault().RoofProperty_GlobalID ,

				RoofAvailableActions = 
				(
					from el_RoofAvailableActions in gfunct_Roofs.ToArray()
					select new L5QT_GQIfVI_1048_RoofAvailableActions
					{     
						RES_STR_Roof_Property_AvailableActionID = el_RoofAvailableActions.RES_STR_Roof_Property_AvailableActionID,
						Roof_Action_RefID = el_RoofAvailableActions.Roof_Action_RefID,

					}
				).ToArray(),

			}
		).ToArray(),
		Facades = 
		(
			from el_Facades in gfunct_L5QT_GQIfVI_1048.Where(element => !EqualsDefaultValue(element.RES_STR_Facade_PropertyID)).ToArray()
			group el_Facades by new 
			{ 
				el_Facades.RES_STR_Facade_PropertyID,

			}
			into gfunct_Facades
			select new L5QT_GQIfVI_1048_Facades
			{     
				RES_STR_Facade_PropertyID = gfunct_Facades.Key.RES_STR_Facade_PropertyID ,
				FacadeProperty_Name = gfunct_Facades.FirstOrDefault().FacadeProperty_Name ,
				FacadeProperty_GlobalID = gfunct_Facades.FirstOrDefault().FacadeProperty_GlobalID ,

				FacadeAvailableActions = 
				(
					from el_FacadeAvailableActions in gfunct_Facades.ToArray()
					select new L5QT_GQIfVI_1048_FacadeAvailableActions
					{     
						RES_STR_Facade_Property_AvailableActionID = el_FacadeAvailableActions.RES_STR_Facade_Property_AvailableActionID,
						Facade_Action_RefID = el_FacadeAvailableActions.Facade_Action_RefID,

					}
				).ToArray(),

			}
		).ToArray(),
		Staircases = 
		(
			from el_Staircases in gfunct_L5QT_GQIfVI_1048.Where(element => !EqualsDefaultValue(element.RES_STR_Staircase_PropertyID)).ToArray()
			group el_Staircases by new 
			{ 
				el_Staircases.RES_STR_Staircase_PropertyID,

			}
			into gfunct_Staircases
			select new L5QT_GQIfVI_1048_Staircases
			{     
				RES_STR_Staircase_PropertyID = gfunct_Staircases.Key.RES_STR_Staircase_PropertyID ,
				StaircaseProperty_Name = gfunct_Staircases.FirstOrDefault().StaircaseProperty_Name ,
				StaircaseProperty_GlobalID = gfunct_Staircases.FirstOrDefault().StaircaseProperty_GlobalID ,

				StaircaseAvailableActions = 
				(
					from el_StaircaseAvailableActions in gfunct_Staircases.ToArray()
					select new L5QT_GQIfVI_1048_StaircaseAvailableActions
					{     
						RES_STR_Staircase_Property_AvailableActionsID = el_StaircaseAvailableActions.RES_STR_Staircase_Property_AvailableActionsID,
						Staricase_Action_RefID = el_StaircaseAvailableActions.Staricase_Action_RefID,

					}
				).ToArray(),

			}
		).ToArray(),
		Basements = 
		(
			from el_Basements in gfunct_L5QT_GQIfVI_1048.Where(element => !EqualsDefaultValue(element.RES_STR_Basement_PropertyID)).ToArray()
			group el_Basements by new 
			{ 
				el_Basements.RES_STR_Basement_PropertyID,

			}
			into gfunct_Basements
			select new L5QT_GQIfVI_1048_Basements
			{     
				RES_STR_Basement_PropertyID = gfunct_Basements.Key.RES_STR_Basement_PropertyID ,
				BasementProperty_Name = gfunct_Basements.FirstOrDefault().BasementProperty_Name ,
				BasementProperty_GlobalID = gfunct_Basements.FirstOrDefault().BasementProperty_GlobalID ,

				BasementAvailableActions = 
				(
					from el_BasementAvailableActions in gfunct_Basements.ToArray()
					select new L5QT_GQIfVI_1048_BasementAvailableActions
					{     
						RES_STR_Basement_Property_AvailableActionID = el_BasementAvailableActions.RES_STR_Basement_Property_AvailableActionID,
						Basement_Action_RefID = el_BasementAvailableActions.Basement_Action_RefID,

					}
				).ToArray(),

			}
		).ToArray(),
		HVACRs = 
		(
			from el_HVACRs in gfunct_L5QT_GQIfVI_1048.Where(element => !EqualsDefaultValue(element.RES_STR_HVACR_PropertyID)).ToArray()
			group el_HVACRs by new 
			{ 
				el_HVACRs.RES_STR_HVACR_PropertyID,

			}
			into gfunct_HVACRs
			select new L5QT_GQIfVI_1048_HVACRs
			{     
				HVACRProperty_Name = gfunct_HVACRs.FirstOrDefault().HVACRProperty_Name ,
				RES_STR_HVACR_PropertyID = gfunct_HVACRs.Key.RES_STR_HVACR_PropertyID ,
				HVACRProperty_GlobalID = gfunct_HVACRs.FirstOrDefault().HVACRProperty_GlobalID ,

				HVACRAvailableActions = 
				(
					from el_HVACRAvailableActions in gfunct_HVACRs.ToArray()
					select new L5QT_GQIfVI_1048_HVACRAvailableActions
					{     
						RES_STR_HVACR_Property_AvailableActionID = el_HVACRAvailableActions.RES_STR_HVACR_Property_AvailableActionID,
						HVACR_Action_RefID = el_HVACRAvailableActions.HVACR_Action_RefID,

					}
				).ToArray(),

			}
		).ToArray(),
		Attics = 
		(
			from el_Attics in gfunct_L5QT_GQIfVI_1048.Where(element => !EqualsDefaultValue(element.RES_STR_Attic_PropertyID)).ToArray()
			group el_Attics by new 
			{ 
				el_Attics.RES_STR_Attic_PropertyID,

			}
			into gfunct_Attics
			select new L5QT_GQIfVI_1048_Attics
			{     
				RES_STR_Attic_PropertyID = gfunct_Attics.Key.RES_STR_Attic_PropertyID ,
				AtticProperty_Name = gfunct_Attics.FirstOrDefault().AtticProperty_Name ,
				AtticProperty_GlobalID = gfunct_Attics.FirstOrDefault().AtticProperty_GlobalID ,

				AtticAvailableActions = 
				(
					from el_AtticAvailableActions in gfunct_Attics.ToArray()
					select new L5QT_GQIfVI_1048_AtticAvailableActions
					{     
						RES_STR_Attic_Property_AvailableActionID = el_AtticAvailableActions.RES_STR_Attic_Property_AvailableActionID,
						Attic_Action_RefID = el_AtticAvailableActions.Attic_Action_RefID,

					}
				).ToArray(),

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5QT_GQIfVI_1048 : FR_Base
	{
		public L5QT_GQIfVI_1048 Result	{ get; set; }

		public FR_L5QT_GQIfVI_1048() : base() {}

		public FR_L5QT_GQIfVI_1048(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5QT_GQIfVI_1048 for attribute P_L5QT_GQIfVI_1048
		[DataContract]
		public class P_L5QT_GQIfVI_1048 
		{
			//Standard type parameters
			[DataMember]
			public Guid QuestionnaireVersionID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048 for attribute L5QT_GQIfVI_1048
		[DataContract]
		public class L5QT_GQIfVI_1048 
		{
			[DataMember]
			public L5QT_GQIfVI_1048_OutdoorFacilities[] OutdoorFacilities { get; set; }
			[DataMember]
			public L5QT_GQIfVI_1048_Apartments[] Apartments { get; set; }
			[DataMember]
			public L5QT_GQIfVI_1048_Roofs[] Roofs { get; set; }
			[DataMember]
			public L5QT_GQIfVI_1048_Facades[] Facades { get; set; }
			[DataMember]
			public L5QT_GQIfVI_1048_Staircases[] Staircases { get; set; }
			[DataMember]
			public L5QT_GQIfVI_1048_Basements[] Basements { get; set; }
			[DataMember]
			public L5QT_GQIfVI_1048_HVACRs[] HVACRs { get; set; }
			[DataMember]
			public L5QT_GQIfVI_1048_Attics[] Attics { get; set; }

			//Standard type parameters
			[DataMember]
			public String QuestionnaireVersion_Comment { get; set; } 
			[DataMember]
			public String QuestionnaireVersion_VersionNumber { get; set; } 
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
			[DataMember]
			public Guid RES_QST_Questionnaire_VersionID { get; set; } 
			[DataMember]
			public Guid RES_QST_QuestionnaireID { get; set; } 
			[DataMember]
			public Dict Questionnaire_Name { get; set; } 
			[DataMember]
			public Dict Questionnaire_Description { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_OutdoorFacilities for attribute OutdoorFacilities
		[DataContract]
		public class L5QT_GQIfVI_1048_OutdoorFacilities 
		{
			[DataMember]
			public L5QT_GQIfVI_1048_OutdoorFacilityAvailableActions[] OutdoorFacilityAvailableActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Dict OutdoorFacilityProperty_Name { get; set; } 
			[DataMember]
			public Guid RES_STR_OutdoorFacility_PropertyID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_OutdoorFacilityAvailableActions for attribute OutdoorFacilityAvailableActions
		[DataContract]
		public class L5QT_GQIfVI_1048_OutdoorFacilityAvailableActions 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_OutdoorFacility_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid RES_ACT_Action_RefID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_Apartments for attribute Apartments
		[DataContract]
		public class L5QT_GQIfVI_1048_Apartments 
		{
			[DataMember]
			public L5QT_GQIfVI_1048_ApartmentAvailableActions[] ApartmentAvailableActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Apartment_PropertyID { get; set; } 
			[DataMember]
			public Dict ApartmentProperty_Name { get; set; } 
			[DataMember]
			public String ApartmentProperty_GlobalID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_ApartmentAvailableActions for attribute ApartmentAvailableActions
		[DataContract]
		public class L5QT_GQIfVI_1048_ApartmentAvailableActions 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Apartment_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid Apartment_Action_RefID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_Roofs for attribute Roofs
		[DataContract]
		public class L5QT_GQIfVI_1048_Roofs 
		{
			[DataMember]
			public L5QT_GQIfVI_1048_RoofAvailableActions[] RoofAvailableActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Roof_PropertyID { get; set; } 
			[DataMember]
			public Dict RoofProperty_Name { get; set; } 
			[DataMember]
			public String RoofProperty_GlobalID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_RoofAvailableActions for attribute RoofAvailableActions
		[DataContract]
		public class L5QT_GQIfVI_1048_RoofAvailableActions 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Roof_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid Roof_Action_RefID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_Facades for attribute Facades
		[DataContract]
		public class L5QT_GQIfVI_1048_Facades 
		{
			[DataMember]
			public L5QT_GQIfVI_1048_FacadeAvailableActions[] FacadeAvailableActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Facade_PropertyID { get; set; } 
			[DataMember]
			public Dict FacadeProperty_Name { get; set; } 
			[DataMember]
			public String FacadeProperty_GlobalID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_FacadeAvailableActions for attribute FacadeAvailableActions
		[DataContract]
		public class L5QT_GQIfVI_1048_FacadeAvailableActions 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Facade_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid Facade_Action_RefID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_Staircases for attribute Staircases
		[DataContract]
		public class L5QT_GQIfVI_1048_Staircases 
		{
			[DataMember]
			public L5QT_GQIfVI_1048_StaircaseAvailableActions[] StaircaseAvailableActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Staircase_PropertyID { get; set; } 
			[DataMember]
			public Dict StaircaseProperty_Name { get; set; } 
			[DataMember]
			public String StaircaseProperty_GlobalID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_StaircaseAvailableActions for attribute StaircaseAvailableActions
		[DataContract]
		public class L5QT_GQIfVI_1048_StaircaseAvailableActions 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Staircase_Property_AvailableActionsID { get; set; } 
			[DataMember]
			public Guid Staricase_Action_RefID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_Basements for attribute Basements
		[DataContract]
		public class L5QT_GQIfVI_1048_Basements 
		{
			[DataMember]
			public L5QT_GQIfVI_1048_BasementAvailableActions[] BasementAvailableActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Basement_PropertyID { get; set; } 
			[DataMember]
			public Dict BasementProperty_Name { get; set; } 
			[DataMember]
			public String BasementProperty_GlobalID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_BasementAvailableActions for attribute BasementAvailableActions
		[DataContract]
		public class L5QT_GQIfVI_1048_BasementAvailableActions 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Basement_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid Basement_Action_RefID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_HVACRs for attribute HVACRs
		[DataContract]
		public class L5QT_GQIfVI_1048_HVACRs 
		{
			[DataMember]
			public L5QT_GQIfVI_1048_HVACRAvailableActions[] HVACRAvailableActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Dict HVACRProperty_Name { get; set; } 
			[DataMember]
			public Guid RES_STR_HVACR_PropertyID { get; set; } 
			[DataMember]
			public String HVACRProperty_GlobalID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_HVACRAvailableActions for attribute HVACRAvailableActions
		[DataContract]
		public class L5QT_GQIfVI_1048_HVACRAvailableActions 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_HVACR_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid HVACR_Action_RefID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_Attics for attribute Attics
		[DataContract]
		public class L5QT_GQIfVI_1048_Attics 
		{
			[DataMember]
			public L5QT_GQIfVI_1048_AtticAvailableActions[] AtticAvailableActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Attic_PropertyID { get; set; } 
			[DataMember]
			public Dict AtticProperty_Name { get; set; } 
			[DataMember]
			public String AtticProperty_GlobalID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQIfVI_1048_AtticAvailableActions for attribute AtticAvailableActions
		[DataContract]
		public class L5QT_GQIfVI_1048_AtticAvailableActions 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Attic_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid Attic_Action_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5QT_GQIfVI_1048 cls_Get_QuestionnaireInfo_for_VersionID(,P_L5QT_GQIfVI_1048 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5QT_GQIfVI_1048 invocationResult = cls_Get_QuestionnaireInfo_for_VersionID.Invoke(connectionString,P_L5QT_GQIfVI_1048 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_Questionnaire.Complex.Retrieval.P_L5QT_GQIfVI_1048();
parameter.QuestionnaireVersionID = ...;

*/