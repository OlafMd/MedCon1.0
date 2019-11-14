/* 
 * Generated on 7/22/2013 4:04:53 PM
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
    /// var result = cls_Get_DueDiligence_Questionnaire_For_QuestionnaireID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DueDiligence_Questionnaire_For_QuestionnaireID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5QT_GDDQFQ_1507 Execute(DbConnection Connection,DbTransaction Transaction,P_L5QT_GDDQFQ_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5QT_GDDQFQ_1507();

            returnValue.Result = new L5QT_GDDQFQ_1507();




            ORM_RES_QST_Questionnaire_Version version = new ORM_RES_QST_Questionnaire_Version();
            version.Load(Connection, Transaction, Parameter.QuestionnaireVersionID);
            returnValue.Result.IsApartmentStructureVisible = version.IsApartmentStructureVisible;
            returnValue.Result.IsAtticVisible = version.IsAtticVisible;
            returnValue.Result.IsBasementVisible = version.IsBasementVisible;
            returnValue.Result.IsFacadeVisible = version.IsFacadeVisible;
            returnValue.Result.IsHVACRVisible = version.IsHVACRVisible;
            returnValue.Result.IsRoofVisible = version.IsRoofVisible;
            returnValue.Result.IsOutdoorFacilityVisible = version.IsOutdoorFacilityVisible;
            returnValue.Result.IsStaircaseStructureVisible = version.IsStaircaseStructureVisible;

            ORM_RES_QST_Questionnaire.Query questionnaireQuery = new ORM_RES_QST_Questionnaire.Query();
            questionnaireQuery.Tenant_RefID = securityTicket.TenantID;
            questionnaireQuery.RES_QST_QuestionnaireID = version.Questionnaire_RefID;
            List<ORM_RES_QST_Questionnaire> questionnaire = ORM_RES_QST_Questionnaire.Query.Search(Connection, Transaction, questionnaireQuery);
            if (questionnaire.Count == 0)
            {
                return null;
            }

            returnValue.Result.Questionnaire_Name = questionnaire[0].Questionnaire_Name;
            
            ORM_RES_QST_Apartment_AvailableProperty.Query apartmentQuery = new ORM_RES_QST_Apartment_AvailableProperty.Query();
            apartmentQuery.Tenant_RefID = securityTicket.TenantID;
            apartmentQuery.IsDeleted = false;
            apartmentQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_Apartment_AvailableProperty> apartments = ORM_RES_QST_Apartment_AvailableProperty.Query.Search(Connection, Transaction, apartmentQuery);

            List<L5QT_GDDQFQ_1507_Apartments> apartmentList = new List<L5QT_GDDQFQ_1507_Apartments>();
            foreach (var buildingPart in apartments)
            {
                ORM_RES_STR_Apartment_Property property=new ORM_RES_STR_Apartment_Property();
                property.Load(Connection,Transaction,buildingPart.RES_STR_Apartment_Property_RefID);
                L5QT_GDDQFQ_1507_Apartments item = new L5QT_GDDQFQ_1507_Apartments();
                item.ApartmentProperty_Name = property.ApartmentProperty_Name;
                item.RES_QST_Apartment_AvailablePropertyID = buildingPart.RES_QST_Apartment_AvailablePropertyID;
                item.RES_STR_Apartment_PropertyID = buildingPart.RES_STR_Apartment_Property_RefID;
                apartmentList.Add(item);
            }
            returnValue.Result.Apartments = apartmentList.ToArray();

            ORM_RES_QST_Attic_AvailableProperty.Query atticQuery = new ORM_RES_QST_Attic_AvailableProperty.Query();
            atticQuery.Tenant_RefID = securityTicket.TenantID;
            atticQuery.IsDeleted = false;
            atticQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_Attic_AvailableProperty> attics = ORM_RES_QST_Attic_AvailableProperty.Query.Search(Connection, Transaction, atticQuery);

            List<L5QT_GDDQFQ_1507_Attics> atticList = new List<L5QT_GDDQFQ_1507_Attics>();
            foreach (var buildingPart in attics)
            {
                ORM_RES_STR_Attic_Property property = new ORM_RES_STR_Attic_Property();
                property.Load(Connection, Transaction, buildingPart.RES_STR_Attic_Property_RefID);
                L5QT_GDDQFQ_1507_Attics item = new L5QT_GDDQFQ_1507_Attics();
                item.AtticProperty_Name = property.AtticProperty_Name;
                item.RES_QST_Attic_AvailablePropertyID = buildingPart.RES_QST_Attic_AvailablePropertyID;
                item.RES_STR_Attic_PropertyID = buildingPart.RES_STR_Attic_Property_RefID;
                atticList.Add(item);
            }
            returnValue.Result.Attics = atticList.ToArray();

            ORM_RES_QST_Basement_AvailableProperty.Query basementQuery = new ORM_RES_QST_Basement_AvailableProperty.Query();
            basementQuery.Tenant_RefID = securityTicket.TenantID;
            basementQuery.IsDeleted = false;
            basementQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_Basement_AvailableProperty> basements = ORM_RES_QST_Basement_AvailableProperty.Query.Search(Connection, Transaction, basementQuery);

            List<L5QT_GDDQFQ_1507_Basements> basementList = new List<L5QT_GDDQFQ_1507_Basements>();
            foreach (var buildingPart in basements)
            {
                ORM_RES_STR_Basement_Property property = new ORM_RES_STR_Basement_Property();
                property.Load(Connection, Transaction, buildingPart.RES_STR_Basement_Property_RefID);
                L5QT_GDDQFQ_1507_Basements item = new L5QT_GDDQFQ_1507_Basements();
                item.BasementProperty_Name = property.BasementProperty_Name;
                item.RES_QST_Basement_AvailablePropertyID = buildingPart.RES_QST_Basement_AvailablePropertyID;
                item.RES_STR_Basement_PropertyID = buildingPart.RES_STR_Basement_Property_RefID;
                basementList.Add(item);
            }
            returnValue.Result.Basements = basementList.ToArray();

            ORM_RES_QST_Facade_AvailableProperty.Query facadeQuery = new ORM_RES_QST_Facade_AvailableProperty.Query();
            facadeQuery.Tenant_RefID = securityTicket.TenantID;
            facadeQuery.IsDeleted = false;
            facadeQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_Facade_AvailableProperty> facades = ORM_RES_QST_Facade_AvailableProperty.Query.Search(Connection, Transaction, facadeQuery);

            List<L5QT_GDDQFQ_1507_Facades> facadeList = new List<L5QT_GDDQFQ_1507_Facades>();
            foreach (var buildingPart in facades)
            {
                ORM_RES_STR_Facade_Property property = new ORM_RES_STR_Facade_Property();
                property.Load(Connection, Transaction, buildingPart.RES_STR_Facade_Property_RefID);
                L5QT_GDDQFQ_1507_Facades item = new L5QT_GDDQFQ_1507_Facades();
                item.FacadeProperty_Name = property.FacadeProperty_Name;
                item.RES_QST_Facade_AvailablePropertyID = buildingPart.RES_QST_Facade_AvailablePropertyID;
                item.RES_STR_Facade_PropertyID = buildingPart.RES_STR_Facade_Property_RefID;
                facadeList.Add(item);
            }
            returnValue.Result.Facades = facadeList.ToArray();

            ORM_RES_QST_HVACR_AvailableProperty.Query hvacrQuery = new ORM_RES_QST_HVACR_AvailableProperty.Query();
            hvacrQuery.Tenant_RefID = securityTicket.TenantID;
            hvacrQuery.IsDeleted = false;
            hvacrQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_HVACR_AvailableProperty> hvacrs = ORM_RES_QST_HVACR_AvailableProperty.Query.Search(Connection, Transaction, hvacrQuery);

            List<L5QT_GDDQFQ_1507_HVACRs> hvacrList = new List<L5QT_GDDQFQ_1507_HVACRs>();
            foreach (var buildingPart in hvacrs)
            {
                ORM_RES_STR_HVACR_Property property = new ORM_RES_STR_HVACR_Property();
                property.Load(Connection, Transaction, buildingPart.RES_STR_HVACR_Property_RefID);
                L5QT_GDDQFQ_1507_HVACRs item = new L5QT_GDDQFQ_1507_HVACRs();
                item.HVACRProperty_Name = property.HVACRProperty_Name;
                item.RES_QST_HVACR_AvailablePropertyID = buildingPart.RES_QST_HVACR_AvailablePropertyID;
                item.RES_STR_HVACR_PropertyID = buildingPart.RES_STR_HVACR_Property_RefID;
                hvacrList.Add(item);
            }
            returnValue.Result.HVACRs = hvacrList.ToArray();

            ORM_RES_QST_OutdoorFacility_AvailableProperty.Query outdoorQuery = new ORM_RES_QST_OutdoorFacility_AvailableProperty.Query();
            outdoorQuery.Tenant_RefID = securityTicket.TenantID;
            outdoorQuery.IsDeleted = false;
            outdoorQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_OutdoorFacility_AvailableProperty> outdoors = ORM_RES_QST_OutdoorFacility_AvailableProperty.Query.Search(Connection, Transaction, outdoorQuery);

            List<L5QT_GDDQFQ_1507_OutdoorFacilities> outdoorList = new List<L5QT_GDDQFQ_1507_OutdoorFacilities>();
            foreach (var buildingPart in outdoors)
            {
                ORM_RES_STR_OutdoorFacility_Property property = new ORM_RES_STR_OutdoorFacility_Property();
                property.Load(Connection, Transaction, buildingPart.RES_STR_OutdoorFacility_Property_RefID);
                L5QT_GDDQFQ_1507_OutdoorFacilities item = new L5QT_GDDQFQ_1507_OutdoorFacilities();
                item.OutdoorFacilityProperty_Name = property.OutdoorFacilityProperty_Name;
                item.RES_QST_OutdoorFacility_AvailablePropertyID = buildingPart.RES_QST_OutdoorFacility_AvailablePropertyID;
                item.RES_STR_OutdoorFacility_PropertyID = buildingPart.RES_STR_OutdoorFacility_Property_RefID;
                outdoorList.Add(item);
            }
            returnValue.Result.OutdoorFacilities = outdoorList.ToArray();

            ORM_RES_QST_Roof_AvailableProperty.Query roofQuery = new ORM_RES_QST_Roof_AvailableProperty.Query();
            roofQuery.Tenant_RefID = securityTicket.TenantID;
            roofQuery.IsDeleted = false;
            roofQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_Roof_AvailableProperty> roofs = ORM_RES_QST_Roof_AvailableProperty.Query.Search(Connection, Transaction, roofQuery);

            List<L5QT_GDDQFQ_1507_Roofs> roofList = new List<L5QT_GDDQFQ_1507_Roofs>();
            foreach (var buildingPart in roofs)
            {
                ORM_RES_STR_Roof_Property property = new ORM_RES_STR_Roof_Property();
                property.Load(Connection, Transaction, buildingPart.RES_STR_Roof_Property_RefID);
                L5QT_GDDQFQ_1507_Roofs item = new L5QT_GDDQFQ_1507_Roofs();
                item.RoofProperty_Name = property.RoofProperty_Name;
                item.RES_QST_Roof_AvailablePropertyID = buildingPart.RES_QST_Roof_AvailablePropertyID;
                item.RES_STR_Roof_PropertyID = buildingPart.RES_STR_Roof_Property_RefID;
                roofList.Add(item);
            }
            returnValue.Result.Roofs = roofList.ToArray();

            ORM_RES_QST_Staircase_AvailableProperty.Query staircaseQuery = new ORM_RES_QST_Staircase_AvailableProperty.Query();
            staircaseQuery.Tenant_RefID = securityTicket.TenantID;
            staircaseQuery.IsDeleted = false;
            staircaseQuery.RES_QST_Questionnaire_Version_RefID = version.RES_QST_Questionnaire_VersionID;
            List<ORM_RES_QST_Staircase_AvailableProperty> staircases = ORM_RES_QST_Staircase_AvailableProperty.Query.Search(Connection, Transaction, staircaseQuery);

            List<L5QT_GDDQFQ_1507_Staircases> staircaseList = new List<L5QT_GDDQFQ_1507_Staircases>();
            foreach (var buildingPart in staircases)
            {
                ORM_RES_STR_Staircase_Property property = new ORM_RES_STR_Staircase_Property();
                property.Load(Connection, Transaction, buildingPart.RES_STR_Staircase_Property_RefID);
                L5QT_GDDQFQ_1507_Staircases item = new L5QT_GDDQFQ_1507_Staircases();
                item.StaircaseProperty_Name = property.StaircaseProperty_Name;
                item.RES_QST_Staircase_AvailablePropertyID = buildingPart.RES_QST_Staircase_AvailablePropertyID;
                item.RES_STR_Staircase_PropertyID = buildingPart.RES_STR_Staircase_Property_RefID;
                staircaseList.Add(item);
            }
            returnValue.Result.Staircases = staircaseList.ToArray();

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5QT_GDDQFQ_1507 Invoke(string ConnectionString,P_L5QT_GDDQFQ_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5QT_GDDQFQ_1507 Invoke(DbConnection Connection,P_L5QT_GDDQFQ_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5QT_GDDQFQ_1507 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5QT_GDDQFQ_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5QT_GDDQFQ_1507 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5QT_GDDQFQ_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5QT_GDDQFQ_1507 functionReturn = new FR_L5QT_GDDQFQ_1507();
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

				throw new Exception("Exception occured in method cls_Get_DueDiligence_Questionnaire_For_QuestionnaireID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5QT_GDDQFQ_1507_raw 
	{
		public Guid RES_QST_Questionnaire_VersionID; 
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
		public Guid RES_QST_QuestionnaireID; 
		public Dict Questionnaire_Name; 
		public Dict OutdoorFacilityProperty_Name; 
		public Guid RES_QST_OutdoorFacility_AvailablePropertyID; 
		public Guid RES_STR_OutdoorFacility_PropertyID; 
		public Guid RES_QST_Apartment_AvailablePropertyID; 
		public Guid RES_STR_Apartment_PropertyID; 
		public Dict ApartmentProperty_Name; 
		public Guid RES_QST_Roof_AvailablePropertyID; 
		public Guid RES_STR_Roof_PropertyID; 
		public Dict RoofProperty_Name; 
		public Guid RES_STR_Facade_PropertyID; 
		public Guid RES_QST_Facade_AvailablePropertyID; 
		public Dict FacadeProperty_Name; 
		public Guid RES_QST_Staircase_AvailablePropertyID; 
		public Guid RES_STR_Staircase_PropertyID; 
		public Dict StaircaseProperty_Name; 
		public Guid RES_QST_Basement_AvailablePropertyID; 
		public Guid RES_STR_Basement_PropertyID; 
		public Dict BasementProperty_Name; 
		public Dict HVACRProperty_Name; 
		public Guid RES_STR_HVACR_PropertyID; 
		public Guid RES_QST_HVACR_AvailablePropertyID; 
		public Guid RES_QST_Attic_AvailablePropertyID; 
		public Guid RES_STR_Attic_PropertyID; 
		public Dict AtticProperty_Name; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5QT_GDDQFQ_1507[] Convert(List<L5QT_GDDQFQ_1507_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5QT_GDDQFQ_1507 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_QST_Questionnaire_VersionID)).ToArray()
	group el_L5QT_GDDQFQ_1507 by new 
	{ 
		el_L5QT_GDDQFQ_1507.RES_QST_Questionnaire_VersionID,

	}
	into gfunct_L5QT_GDDQFQ_1507
	select new L5QT_GDDQFQ_1507
	{     
		RES_QST_Questionnaire_VersionID = gfunct_L5QT_GDDQFQ_1507.Key.RES_QST_Questionnaire_VersionID ,
		QuestionnaireVersion_Comment = gfunct_L5QT_GDDQFQ_1507.FirstOrDefault().QuestionnaireVersion_Comment ,
		QuestionnaireVersion_VersionNumber = gfunct_L5QT_GDDQFQ_1507.FirstOrDefault().QuestionnaireVersion_VersionNumber ,
		IsApartmentStructureVisible = gfunct_L5QT_GDDQFQ_1507.FirstOrDefault().IsApartmentStructureVisible ,
		IsStaircaseStructureVisible = gfunct_L5QT_GDDQFQ_1507.FirstOrDefault().IsStaircaseStructureVisible ,
		IsOutdoorFacilityVisible = gfunct_L5QT_GDDQFQ_1507.FirstOrDefault().IsOutdoorFacilityVisible ,
		IsFacadeVisible = gfunct_L5QT_GDDQFQ_1507.FirstOrDefault().IsFacadeVisible ,
		IsRoofVisible = gfunct_L5QT_GDDQFQ_1507.FirstOrDefault().IsRoofVisible ,
		IsAtticVisible = gfunct_L5QT_GDDQFQ_1507.FirstOrDefault().IsAtticVisible ,
		IsBasementVisible = gfunct_L5QT_GDDQFQ_1507.FirstOrDefault().IsBasementVisible ,
		IsHVACRVisible = gfunct_L5QT_GDDQFQ_1507.FirstOrDefault().IsHVACRVisible ,
		RES_QST_QuestionnaireID = gfunct_L5QT_GDDQFQ_1507.FirstOrDefault().RES_QST_QuestionnaireID ,
		Questionnaire_Name = gfunct_L5QT_GDDQFQ_1507.FirstOrDefault().Questionnaire_Name ,

		OutdoorFacilities = 
		(
			from el_OutdoorFacilities in gfunct_L5QT_GDDQFQ_1507.Where(element => !EqualsDefaultValue(element.RES_STR_OutdoorFacility_PropertyID)).ToArray()
			group el_OutdoorFacilities by new 
			{ 
				el_OutdoorFacilities.RES_STR_OutdoorFacility_PropertyID,

			}
			into gfunct_OutdoorFacilities
			select new L5QT_GDDQFQ_1507_OutdoorFacilities
			{     
				OutdoorFacilityProperty_Name = gfunct_OutdoorFacilities.FirstOrDefault().OutdoorFacilityProperty_Name ,
				RES_QST_OutdoorFacility_AvailablePropertyID = gfunct_OutdoorFacilities.FirstOrDefault().RES_QST_OutdoorFacility_AvailablePropertyID ,
				RES_STR_OutdoorFacility_PropertyID = gfunct_OutdoorFacilities.Key.RES_STR_OutdoorFacility_PropertyID ,

			}
		).ToArray(),
		Apartments = 
		(
			from el_Apartments in gfunct_L5QT_GDDQFQ_1507.Where(element => !EqualsDefaultValue(element.RES_STR_Apartment_PropertyID)).ToArray()
			group el_Apartments by new 
			{ 
				el_Apartments.RES_STR_Apartment_PropertyID,

			}
			into gfunct_Apartments
			select new L5QT_GDDQFQ_1507_Apartments
			{     
				RES_QST_Apartment_AvailablePropertyID = gfunct_Apartments.FirstOrDefault().RES_QST_Apartment_AvailablePropertyID ,
				RES_STR_Apartment_PropertyID = gfunct_Apartments.Key.RES_STR_Apartment_PropertyID ,
				ApartmentProperty_Name = gfunct_Apartments.FirstOrDefault().ApartmentProperty_Name ,

			}
		).ToArray(),
		Roofs = 
		(
			from el_Roofs in gfunct_L5QT_GDDQFQ_1507.Where(element => !EqualsDefaultValue(element.RES_STR_Roof_PropertyID)).ToArray()
			group el_Roofs by new 
			{ 
				el_Roofs.RES_STR_Roof_PropertyID,

			}
			into gfunct_Roofs
			select new L5QT_GDDQFQ_1507_Roofs
			{     
				RES_QST_Roof_AvailablePropertyID = gfunct_Roofs.FirstOrDefault().RES_QST_Roof_AvailablePropertyID ,
				RES_STR_Roof_PropertyID = gfunct_Roofs.Key.RES_STR_Roof_PropertyID ,
				RoofProperty_Name = gfunct_Roofs.FirstOrDefault().RoofProperty_Name ,

			}
		).ToArray(),
		Facades = 
		(
			from el_Facades in gfunct_L5QT_GDDQFQ_1507.Where(element => !EqualsDefaultValue(element.RES_STR_Facade_PropertyID)).ToArray()
			group el_Facades by new 
			{ 
				el_Facades.RES_STR_Facade_PropertyID,

			}
			into gfunct_Facades
			select new L5QT_GDDQFQ_1507_Facades
			{     
				RES_STR_Facade_PropertyID = gfunct_Facades.Key.RES_STR_Facade_PropertyID ,
				RES_QST_Facade_AvailablePropertyID = gfunct_Facades.FirstOrDefault().RES_QST_Facade_AvailablePropertyID ,
				FacadeProperty_Name = gfunct_Facades.FirstOrDefault().FacadeProperty_Name ,

			}
		).ToArray(),
		Staircases = 
		(
			from el_Staircases in gfunct_L5QT_GDDQFQ_1507.Where(element => !EqualsDefaultValue(element.RES_STR_Staircase_PropertyID)).ToArray()
			group el_Staircases by new 
			{ 
				el_Staircases.RES_STR_Staircase_PropertyID,

			}
			into gfunct_Staircases
			select new L5QT_GDDQFQ_1507_Staircases
			{     
				RES_QST_Staircase_AvailablePropertyID = gfunct_Staircases.FirstOrDefault().RES_QST_Staircase_AvailablePropertyID ,
				RES_STR_Staircase_PropertyID = gfunct_Staircases.Key.RES_STR_Staircase_PropertyID ,
				StaircaseProperty_Name = gfunct_Staircases.FirstOrDefault().StaircaseProperty_Name ,

			}
		).ToArray(),
		Basements = 
		(
			from el_Basements in gfunct_L5QT_GDDQFQ_1507.Where(element => !EqualsDefaultValue(element.RES_STR_Basement_PropertyID)).ToArray()
			group el_Basements by new 
			{ 
				el_Basements.RES_STR_Basement_PropertyID,

			}
			into gfunct_Basements
			select new L5QT_GDDQFQ_1507_Basements
			{     
				RES_QST_Basement_AvailablePropertyID = gfunct_Basements.FirstOrDefault().RES_QST_Basement_AvailablePropertyID ,
				RES_STR_Basement_PropertyID = gfunct_Basements.Key.RES_STR_Basement_PropertyID ,
				BasementProperty_Name = gfunct_Basements.FirstOrDefault().BasementProperty_Name ,

			}
		).ToArray(),
		HVACRs = 
		(
			from el_HVACRs in gfunct_L5QT_GDDQFQ_1507.Where(element => !EqualsDefaultValue(element.RES_STR_HVACR_PropertyID)).ToArray()
			group el_HVACRs by new 
			{ 
				el_HVACRs.RES_STR_HVACR_PropertyID,

			}
			into gfunct_HVACRs
			select new L5QT_GDDQFQ_1507_HVACRs
			{     
				HVACRProperty_Name = gfunct_HVACRs.FirstOrDefault().HVACRProperty_Name ,
				RES_STR_HVACR_PropertyID = gfunct_HVACRs.Key.RES_STR_HVACR_PropertyID ,
				RES_QST_HVACR_AvailablePropertyID = gfunct_HVACRs.FirstOrDefault().RES_QST_HVACR_AvailablePropertyID ,

			}
		).ToArray(),
		Attics = 
		(
			from el_Attics in gfunct_L5QT_GDDQFQ_1507.Where(element => !EqualsDefaultValue(element.RES_STR_Attic_PropertyID)).ToArray()
			group el_Attics by new 
			{ 
				el_Attics.RES_STR_Attic_PropertyID,

			}
			into gfunct_Attics
			select new L5QT_GDDQFQ_1507_Attics
			{     
				RES_QST_Attic_AvailablePropertyID = gfunct_Attics.FirstOrDefault().RES_QST_Attic_AvailablePropertyID ,
				RES_STR_Attic_PropertyID = gfunct_Attics.Key.RES_STR_Attic_PropertyID ,
				AtticProperty_Name = gfunct_Attics.FirstOrDefault().AtticProperty_Name ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5QT_GDDQFQ_1507 : FR_Base
	{
		public L5QT_GDDQFQ_1507 Result	{ get; set; }

		public FR_L5QT_GDDQFQ_1507() : base() {}

		public FR_L5QT_GDDQFQ_1507(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5QT_GDDQFQ_1507 for attribute P_L5QT_GDDQFQ_1507
		[DataContract]
		public class P_L5QT_GDDQFQ_1507 
		{
			//Standard type parameters
			[DataMember]
			public Guid QuestionnaireVersionID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GDDQFQ_1507 for attribute L5QT_GDDQFQ_1507
		[DataContract]
		public class L5QT_GDDQFQ_1507 
		{
			[DataMember]
			public L5QT_GDDQFQ_1507_OutdoorFacilities[] OutdoorFacilities { get; set; }
			[DataMember]
			public L5QT_GDDQFQ_1507_Apartments[] Apartments { get; set; }
			[DataMember]
			public L5QT_GDDQFQ_1507_Roofs[] Roofs { get; set; }
			[DataMember]
			public L5QT_GDDQFQ_1507_Facades[] Facades { get; set; }
			[DataMember]
			public L5QT_GDDQFQ_1507_Staircases[] Staircases { get; set; }
			[DataMember]
			public L5QT_GDDQFQ_1507_Basements[] Basements { get; set; }
			[DataMember]
			public L5QT_GDDQFQ_1507_HVACRs[] HVACRs { get; set; }
			[DataMember]
			public L5QT_GDDQFQ_1507_Attics[] Attics { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_QST_Questionnaire_VersionID { get; set; } 
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
			public Guid RES_QST_QuestionnaireID { get; set; } 
			[DataMember]
			public Dict Questionnaire_Name { get; set; } 

		}
		#endregion
		#region SClass L5QT_GDDQFQ_1507_OutdoorFacilities for attribute OutdoorFacilities
		[DataContract]
		public class L5QT_GDDQFQ_1507_OutdoorFacilities 
		{
			//Standard type parameters
			[DataMember]
			public Dict OutdoorFacilityProperty_Name { get; set; } 
			[DataMember]
			public Guid RES_QST_OutdoorFacility_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_OutdoorFacility_PropertyID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GDDQFQ_1507_Apartments for attribute Apartments
		[DataContract]
		public class L5QT_GDDQFQ_1507_Apartments 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_QST_Apartment_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_Apartment_PropertyID { get; set; } 
			[DataMember]
			public Dict ApartmentProperty_Name { get; set; } 

		}
		#endregion
		#region SClass L5QT_GDDQFQ_1507_Roofs for attribute Roofs
		[DataContract]
		public class L5QT_GDDQFQ_1507_Roofs 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_QST_Roof_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_Roof_PropertyID { get; set; } 
			[DataMember]
			public Dict RoofProperty_Name { get; set; } 

		}
		#endregion
		#region SClass L5QT_GDDQFQ_1507_Facades for attribute Facades
		[DataContract]
		public class L5QT_GDDQFQ_1507_Facades 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Facade_PropertyID { get; set; } 
			[DataMember]
			public Guid RES_QST_Facade_AvailablePropertyID { get; set; } 
			[DataMember]
			public Dict FacadeProperty_Name { get; set; } 

		}
		#endregion
		#region SClass L5QT_GDDQFQ_1507_Staircases for attribute Staircases
		[DataContract]
		public class L5QT_GDDQFQ_1507_Staircases 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_QST_Staircase_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_Staircase_PropertyID { get; set; } 
			[DataMember]
			public Dict StaircaseProperty_Name { get; set; } 

		}
		#endregion
		#region SClass L5QT_GDDQFQ_1507_Basements for attribute Basements
		[DataContract]
		public class L5QT_GDDQFQ_1507_Basements 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_QST_Basement_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_Basement_PropertyID { get; set; } 
			[DataMember]
			public Dict BasementProperty_Name { get; set; } 

		}
		#endregion
		#region SClass L5QT_GDDQFQ_1507_HVACRs for attribute HVACRs
		[DataContract]
		public class L5QT_GDDQFQ_1507_HVACRs 
		{
			//Standard type parameters
			[DataMember]
			public Dict HVACRProperty_Name { get; set; } 
			[DataMember]
			public Guid RES_STR_HVACR_PropertyID { get; set; } 
			[DataMember]
			public Guid RES_QST_HVACR_AvailablePropertyID { get; set; } 

		}
		#endregion
		#region SClass L5QT_GDDQFQ_1507_Attics for attribute Attics
		[DataContract]
		public class L5QT_GDDQFQ_1507_Attics 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_QST_Attic_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_Attic_PropertyID { get; set; } 
			[DataMember]
			public Dict AtticProperty_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5QT_GDDQFQ_1507 cls_Get_DueDiligence_Questionnaire_For_QuestionnaireID(,P_L5QT_GDDQFQ_1507 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5QT_GDDQFQ_1507 invocationResult = cls_Get_DueDiligence_Questionnaire_For_QuestionnaireID.Invoke(connectionString,P_L5QT_GDDQFQ_1507 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_Questionnaire.Complex.Retrieval.P_L5QT_GDDQFQ_1507();
parameter.QuestionnaireVersionID = ...;

*/