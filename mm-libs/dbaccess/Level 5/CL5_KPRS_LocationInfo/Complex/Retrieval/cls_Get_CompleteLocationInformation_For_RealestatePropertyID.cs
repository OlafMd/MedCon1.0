/* 
 * Generated on 8/1/2013 2:04:36 PM
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
using CL1_RES_LOC;
using CL1_CMN_LOC;
using CL1_RES;
using CL1_CMN;
using CL2_Price.Atomic.Retrieval;

namespace CL5_KPRS_LocationInfo.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CompleteLocationInformation_For_RealestatePropertyID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CompleteLocationInformation_For_RealestatePropertyID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5LI_GCLIFRP_0936 Execute(DbConnection Connection,DbTransaction Transaction,P_L5LI_GCLIFRP_0936 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5LI_GCLIFRP_0936();

            returnValue.Result = new L5LI_GCLIFRP_0936();

            ORM_RES_RealestateProperty orm_realestate = new ORM_RES_RealestateProperty();
            orm_realestate.Load(Connection, Transaction, Parameter.RealestatePropertyID);

            ORM_CMN_LOC_Location orm_location = new ORM_CMN_LOC_Location();
            orm_location.Load(Connection, Transaction, orm_realestate.RealestateProperty_Location_RefID);
            returnValue.Result.CMN_LOC_LocationID = orm_location.CMN_LOC_LocationID;

            ORM_CMN_Address orm_address = new ORM_CMN_Address();
            orm_address.Load(Connection, Transaction, orm_location.Address_RefID);

            L5LI_GCLIFRP_0936_Address address = new L5LI_GCLIFRP_0936_Address();
            address.CMN_AddressID = orm_address.CMN_AddressID;
            address.Street_Name = orm_address.Street_Name;
            address.Street_Number = orm_address.Street_Number;
            address.City_PostalCode = orm_address.City_PostalCode;
            address.City_Name = orm_address.City_Name;
            address.City_Region = orm_address.City_Region;
            address.City_AdministrativeDistrict = orm_address.City_AdministrativeDistrict;
            address.Province_Name = orm_address.Province_Name;

            returnValue.Result.Address = address;


            ORM_CMN_LOC_Region orm_region = new ORM_CMN_LOC_Region();
            orm_region.Load(Connection, Transaction, orm_location.Region_RefID);

            L5LI_GCLIFRP_0936_Region region = new L5LI_GCLIFRP_0936_Region();
            region.CMN_LOC_RegionID = orm_region.CMN_LOC_RegionID;
            region.Country_RefID = orm_region.Country_RefID;

            returnValue.Result.Region = region;


            ORM_RES_LOC_LocationInformation.Query locationInfoQuery = new ORM_RES_LOC_LocationInformation.Query();
            locationInfoQuery.CMN_LOC_Location_RefID = orm_location.CMN_LOC_LocationID;
            locationInfoQuery.Tenant_RefID = securityTicket.TenantID;
            locationInfoQuery.IsDeleted = false;
            ORM_RES_LOC_LocationInformation locationInfoFromQuery = ORM_RES_LOC_LocationInformation.Query.Search(Connection, Transaction, locationInfoQuery).FirstOrDefault();

            L5LI_GCLIFRP_0936_LocationInformation locationInfo = new L5LI_GCLIFRP_0936_LocationInformation();
            locationInfo.RES_LOC_LocationInformationID = locationInfoFromQuery.RES_LOC_LocationInformationID;
            locationInfo.MapImage = locationInfoFromQuery.LocationInformation_MapImage_DocID;
            locationInfo.SateliteImage = locationInfoFromQuery.LocationInformation_SatelliteImage_DocID;
            locationInfo.AddressImage = locationInfoFromQuery.LocationInformation_AddressImage_DocID;

            returnValue.Result.LocationInformation = locationInfo;

            ORM_RES_LOC_RegionInformation.Query regionInfoQuery = new ORM_RES_LOC_RegionInformation.Query();
            regionInfoQuery.CMN_LOC_Region_RefID = orm_region.CMN_LOC_RegionID;
            regionInfoQuery.Tenant_RefID = securityTicket.TenantID;
            regionInfoQuery.IsDeleted = false;
            List<ORM_RES_LOC_RegionInformation> regionInfos = ORM_RES_LOC_RegionInformation.Query.Search(Connection, Transaction, regionInfoQuery);

            L5LI_GCLIFRP_0936_RegionInformation regionInfo = new L5LI_GCLIFRP_0936_RegionInformation();
            regionInfo.RegionInformation_RegionArea_in_sqkm = regionInfos[0].RegionInformation_RegionArea_in_sqkm;
            regionInfo.RegionInformation_TotalPopulation = regionInfos[0].RegionInformation_TotalPopulation;
            regionInfo.RegionInformation_Population_per_sqkm = regionInfos[0].RegionInformation_Population_per_sqkm;
            regionInfo.RegionInformation_RegionUnemploymentRatePercent = regionInfos[0].RegionInformation_RegionUnemploymentRatePercent;
            regionInfo.RegionInformation_NumberOfHouseholds_Current = regionInfos[0].RegionInformation_NumberOfHouseholds_Current;
            regionInfo.RegionInformation_NumberOfHouseholds_Forecast = regionInfos[0].RegionInformation_NumberOfHouseholds_Forecast;
            regionInfo.RegionInformation_PurchasingPowerAmount_Current_RefID = regionInfos[0].RegionInformation_PurchasingPowerAmount_Current_RefID;
            regionInfo.RegionInformation_PurchasingPowerAmount_Forecast_RefID = regionInfos[0].RegionInformation_PurchasingPowerAmount_Forecast_RefID;
            regionInfo.RegionInformation_ResidentialRent_MinPrice_RefID = regionInfos[0].RegionInformation_ResidentialRent_MinPrice_RefID;
            regionInfo.RegionInformation_ResidentialRent_AveragePrice_RefID = regionInfos[0].RegionInformation_ResidentialRent_AveragePrice_RefID;
            regionInfo.RegionInformation_ResidentialRent_MaxPrice_RefID = regionInfos[0].RegionInformation_ResidentialRent_MaxPrice_RefID;
            regionInfo.RegionInformation_NonResidentialRent_MinPrice_RefID = regionInfos[0].RegionInformation_NonResidentialRent_MinPrice_RefID;
            regionInfo.RegionInformation_NonResidentialRent_AveragePrice_RefID = regionInfos[0].RegionInformation_NonResidentialRent_AveragePrice_RefID;
            regionInfo.RegionInformation_NonResidentialRent_MaxPrice_RefID = regionInfos[0].RegionInformation_NonResidentialRent_MaxPrice_RefID;

            returnValue.Result.RegionInformation = regionInfo;

            P_L2PR_GPVFP_0932 priceParam = new P_L2PR_GPVFP_0932();
            priceParam.PriceID = regionInfos[0].RegionInformation_NonResidentialRent_AveragePrice_RefID;
            returnValue.Result.RegionInformation_NonResidentialRent_AveragePrice_Amount = cls_Get_PriceValue_For_PriceID.Invoke(Connection, Transaction, priceParam, securityTicket).Result.PriceValue_Amount;

            priceParam.PriceID = regionInfos[0].RegionInformation_NonResidentialRent_MaxPrice_RefID;
            returnValue.Result.RegionInformation_NonResidentialRent_MaxPrice_Amount = cls_Get_PriceValue_For_PriceID.Invoke(Connection, Transaction, priceParam, securityTicket).Result.PriceValue_Amount;

            priceParam.PriceID = regionInfos[0].RegionInformation_NonResidentialRent_MinPrice_RefID;
            returnValue.Result.RegionInformation_NonResidentialRent_MinPrice_Amount = cls_Get_PriceValue_For_PriceID.Invoke(Connection, Transaction, priceParam, securityTicket).Result.PriceValue_Amount;

            priceParam.PriceID = regionInfos[0].RegionInformation_PurchasingPowerAmount_Current_RefID;
            returnValue.Result.RegionInformation_PurchasingPowerAmount_Current_Amount = cls_Get_PriceValue_For_PriceID.Invoke(Connection, Transaction, priceParam, securityTicket).Result.PriceValue_Amount;

            priceParam.PriceID = regionInfos[0].RegionInformation_PurchasingPowerAmount_Forecast_RefID;
            returnValue.Result.RegionInformation_PurchasingPowerAmount_Forecast_Amount = cls_Get_PriceValue_For_PriceID.Invoke(Connection, Transaction, priceParam, securityTicket).Result.PriceValue_Amount;

            priceParam.PriceID = regionInfos[0].RegionInformation_ResidentialRent_AveragePrice_RefID;
            returnValue.Result.RegionInformation_ResidentialRent_AveragePrice_Amount = cls_Get_PriceValue_For_PriceID.Invoke(Connection, Transaction, priceParam, securityTicket).Result.PriceValue_Amount;

            priceParam.PriceID = regionInfos[0].RegionInformation_ResidentialRent_MaxPrice_RefID;
            returnValue.Result.RegionInformation_ResidentialRent_MaxPrice_Amount = cls_Get_PriceValue_For_PriceID.Invoke(Connection, Transaction, priceParam, securityTicket).Result.PriceValue_Amount;

            priceParam.PriceID = regionInfos[0].RegionInformation_ResidentialRent_MinPrice_RefID;
            returnValue.Result.RegionInformation_ResidentialRent_MinPrice_Amount = cls_Get_PriceValue_For_PriceID.Invoke(Connection, Transaction, priceParam, securityTicket).Result.PriceValue_Amount;


            //result.Means_of_Transportation
            ORM_RES_LOC_LocationInformation_2_MeansOfTransportation.Query locationInfo_2_mot_Query = new ORM_RES_LOC_LocationInformation_2_MeansOfTransportation.Query();
            locationInfo_2_mot_Query.RES_LOC_LocationInformation_RefID = locationInfoFromQuery.RES_LOC_LocationInformationID;
            locationInfo_2_mot_Query.Tenant_RefID = securityTicket.TenantID;
            locationInfo_2_mot_Query.IsDeleted = false;
            List<ORM_RES_LOC_LocationInformation_2_MeansOfTransportation> locationInfo_2_mots = ORM_RES_LOC_LocationInformation_2_MeansOfTransportation.Query.Search(Connection, Transaction, locationInfo_2_mot_Query);

            List<L5LI_GCLIFRP_0936_MeansOfTransportation> MeansOfTransportation_List = new List<L5LI_GCLIFRP_0936_MeansOfTransportation>();
            L5LI_GCLIFRP_0936_MeansOfTransportation MeansOfTransportation;
            if (locationInfo_2_mots.Count > 0)
            {
                ORM_RES_LOC_MeansOfTransportation.Query motQuery;
                foreach (var locationInfi_2_mot in locationInfo_2_mots)
                {
                    motQuery = new ORM_RES_LOC_MeansOfTransportation.Query();
                    motQuery.RES_LOC_MeansOfTransportationID = locationInfi_2_mot.RES_LOC_MeansOfTransportation_RefID;
                    motQuery.Tenant_RefID = securityTicket.TenantID;
                    motQuery.IsDeleted = false;
                    List<ORM_RES_LOC_MeansOfTransportation> mots = ORM_RES_LOC_MeansOfTransportation.Query.Search(Connection, Transaction, motQuery);
                    
                    MeansOfTransportation = new L5LI_GCLIFRP_0936_MeansOfTransportation();
                    MeansOfTransportation.MeansOfTransportation_ID = mots[0].RES_LOC_MeansOfTransportationID;
                    MeansOfTransportation.MeansOfTransportation_Name = mots[0].Transportation_Name;
                    
                    MeansOfTransportation_List.Add(MeansOfTransportation);
                }
            }
            returnValue.Result.MeansOfTransportation = MeansOfTransportation_List.ToArray();


            //result.Emmissions
            ORM_RES_LOC_LocationInformation_2_Emmission.Query emmissions_Query = new ORM_RES_LOC_LocationInformation_2_Emmission.Query();
            emmissions_Query.RES_LOC_LocationInformation_RefID = locationInfoFromQuery.RES_LOC_LocationInformationID;
            emmissions_Query.Tenant_RefID = securityTicket.TenantID;
            emmissions_Query.IsDeleted = false;
            List<ORM_RES_LOC_LocationInformation_2_Emmission> emmissions = ORM_RES_LOC_LocationInformation_2_Emmission.Query.Search(Connection, Transaction, emmissions_Query);

            List<L5LI_GCLIFRP_0936_Emmissions> Emmissions_List = new List<L5LI_GCLIFRP_0936_Emmissions>();
            L5LI_GCLIFRP_0936_Emmissions Emmission;
            if(emmissions.Count > 0)
            {
                ORM_RES_LOC_Emmission.Query emmissionQuery;
                foreach(var emmission in emmissions)
                {
                    emmissionQuery = new ORM_RES_LOC_Emmission.Query();
                    emmissionQuery.RES_LOC_EmmissionID = emmission.RES_LOC_Emmission_RefID;
                    emmissionQuery.Tenant_RefID = securityTicket.TenantID;
                    emmissionQuery.IsDeleted = false;
                    List<ORM_RES_LOC_Emmission> orm_emmissions = ORM_RES_LOC_Emmission.Query.Search(Connection,Transaction,emmissionQuery);

                    Emmission = new L5LI_GCLIFRP_0936_Emmissions();
                    Emmission.Emmissions_ID = orm_emmissions[0].RES_LOC_EmmissionID;
                    Emmission.Emmissions_Name = orm_emmissions[0].Emmission_Name;

                    Emmissions_List.Add(Emmission);
                }
            }
            returnValue.Result.Emmissions = Emmissions_List.ToArray();


            //result.SurroundingInfrastructures
            ORM_RES_LOC_LocationInformation_2_SurroundingInfrastructure.Query SurroundingInfrastructures_Query = new ORM_RES_LOC_LocationInformation_2_SurroundingInfrastructure.Query();
            SurroundingInfrastructures_Query.RES_LOC_LocationInformation_RefID = locationInfoFromQuery.RES_LOC_LocationInformationID;
            SurroundingInfrastructures_Query.Tenant_RefID = securityTicket.TenantID;
            SurroundingInfrastructures_Query.IsDeleted = false;
            List<ORM_RES_LOC_LocationInformation_2_SurroundingInfrastructure> SurroundingInfrastructures = ORM_RES_LOC_LocationInformation_2_SurroundingInfrastructure.Query.Search(Connection, Transaction, SurroundingInfrastructures_Query);

            List<L5LI_GCLIFRP_0936_SurroundingInfrastructures> SurroundingInfrastructures_List = new List<L5LI_GCLIFRP_0936_SurroundingInfrastructures>();
            L5LI_GCLIFRP_0936_SurroundingInfrastructures SurroundingInfrastructure;
            if (SurroundingInfrastructures.Count > 0)
            {
                ORM_RES_LOC_SurroundingInfrastructure.Query SurroundingInfrastructure_Query;
                foreach (var infrastructure in SurroundingInfrastructures)
                {
                    SurroundingInfrastructure_Query = new ORM_RES_LOC_SurroundingInfrastructure.Query();
                    SurroundingInfrastructure_Query.RES_LOC_SurroundingInfrastructureID = infrastructure.RES_LOC_SurroundingInfrastructure_RefID;
                    SurroundingInfrastructure_Query.Tenant_RefID = securityTicket.TenantID;
                    SurroundingInfrastructure_Query.IsDeleted = false;
                    List<ORM_RES_LOC_SurroundingInfrastructure> orm_SurroundingInfrastructure = ORM_RES_LOC_SurroundingInfrastructure.Query.Search(Connection, Transaction, SurroundingInfrastructure_Query);

                    SurroundingInfrastructure = new L5LI_GCLIFRP_0936_SurroundingInfrastructures();
                    SurroundingInfrastructure.SurroundingInfrastructures_ID = orm_SurroundingInfrastructure[0].RES_LOC_SurroundingInfrastructureID;
                    SurroundingInfrastructure.SurroundingInfrastructures_Name = orm_SurroundingInfrastructure[0].SurroundingInfrastructure_Name;

                    SurroundingInfrastructures_List.Add(SurroundingInfrastructure);
                }
            }
            returnValue.Result.SurroundingInfrastructures = SurroundingInfrastructures_List.ToArray();


            //result.Neighborhood
            ORM_RES_LOC_LocationInformation_2_NeighborhoodQuality.Query neighborhoodQuality_Query = new ORM_RES_LOC_LocationInformation_2_NeighborhoodQuality.Query();
            neighborhoodQuality_Query.RES_LOC_LocationInformation_RefID = locationInfoFromQuery.RES_LOC_LocationInformationID;
            neighborhoodQuality_Query.Tenant_RefID = securityTicket.TenantID;
            neighborhoodQuality_Query.IsDeleted = false;
            List<ORM_RES_LOC_LocationInformation_2_NeighborhoodQuality> neighborhoodQualities = ORM_RES_LOC_LocationInformation_2_NeighborhoodQuality.Query.Search(Connection, Transaction, neighborhoodQuality_Query);

            List<L5LI_GCLIFRP_0936_NeighborhoodQualities> NeighborhoodQualities_List = new List<L5LI_GCLIFRP_0936_NeighborhoodQualities>();
            L5LI_GCLIFRP_0936_NeighborhoodQualities NeighborhoodQuality;
            if (neighborhoodQualities.Count > 0)
            {
                ORM_RES_LOC_NeighborhoodQuality.Query NeighborhoodQuality_Query;
                foreach (var quality in neighborhoodQualities)
                {
                    NeighborhoodQuality_Query = new ORM_RES_LOC_NeighborhoodQuality.Query();
                    NeighborhoodQuality_Query.RES_LOC_NeighborhoodQualityID = quality.RES_LOC_NeighborhoodQuality_RefID;
                    NeighborhoodQuality_Query.Tenant_RefID = securityTicket.TenantID;
                    NeighborhoodQuality_Query.IsDeleted = false;
                    List<ORM_RES_LOC_NeighborhoodQuality> orm_neighborhoodQualities = ORM_RES_LOC_NeighborhoodQuality.Query.Search(Connection, Transaction, NeighborhoodQuality_Query);

                    NeighborhoodQuality = new L5LI_GCLIFRP_0936_NeighborhoodQualities();
                    NeighborhoodQuality.NeighborhoodQualities_ID = orm_neighborhoodQualities[0].RES_LOC_NeighborhoodQualityID;
                    NeighborhoodQuality.NeighborhoodQualities_Name = orm_neighborhoodQualities[0].NeighborhoodQuality_Name;

                    NeighborhoodQualities_List.Add(NeighborhoodQuality);
                }
            }
            returnValue.Result.NeighborhoodQualities = NeighborhoodQualities_List.ToArray();
            

            //result.ParkingSituation
            ORM_RES_LOC_LocationInfo_2_ParkingSituation.Query parkingSituation_Query = new ORM_RES_LOC_LocationInfo_2_ParkingSituation.Query();
            parkingSituation_Query.RES_LOC_LocationInfo_RefID = locationInfoFromQuery.RES_LOC_LocationInformationID;
            parkingSituation_Query.Tenant_RefID = securityTicket.TenantID;
            parkingSituation_Query.IsDeleted = false;
            List<ORM_RES_LOC_LocationInfo_2_ParkingSituation> parkingSituations = ORM_RES_LOC_LocationInfo_2_ParkingSituation.Query.Search(Connection, Transaction, parkingSituation_Query);

            List<L5LI_GCLIFRP_0936_ParkingSituations> ParkingSituations_List = new List<L5LI_GCLIFRP_0936_ParkingSituations>();
            L5LI_GCLIFRP_0936_ParkingSituations ParkingSituation;
            if (parkingSituations.Count > 0)
            {
                ORM_RES_LOC_ParkingSituation.Query ParkingSituation_Query;
                foreach(var situtaion in parkingSituations)
                {
                    ParkingSituation_Query = new ORM_RES_LOC_ParkingSituation.Query();
                    ParkingSituation_Query.RES_LOC_ParkingSituationID = situtaion.RES_LOC_ParkingSituation_RefID;
                    ParkingSituation_Query.Tenant_RefID = securityTicket.TenantID;
                    ParkingSituation_Query.IsDeleted = false;
                    List<ORM_RES_LOC_ParkingSituation> orm_parkingSituations = ORM_RES_LOC_ParkingSituation.Query.Search(Connection, Transaction, ParkingSituation_Query);

                    ParkingSituation = new L5LI_GCLIFRP_0936_ParkingSituations();
                    ParkingSituation.ParkingSituations_ID = orm_parkingSituations[0].RES_LOC_ParkingSituationID;
                    ParkingSituation.ParkingSituations_Name = orm_parkingSituations[0].ParkingSituation_Name;

                    ParkingSituations_List.Add(ParkingSituation);
                }
            }
            returnValue.Result.ParkingSituations = ParkingSituations_List.ToArray();


            //result.ResidentialVacancies
            ORM_RES_LOC_LocationInfo_2_ResidentialVacancy.Query residentialVacancy_Query = new ORM_RES_LOC_LocationInfo_2_ResidentialVacancy.Query();
            residentialVacancy_Query.RES_LOC_LocationInfo_RefID = locationInfoFromQuery.RES_LOC_LocationInformationID;
            residentialVacancy_Query.Tenant_RefID = securityTicket.TenantID;
            residentialVacancy_Query.IsDeleted = false;
            List<ORM_RES_LOC_LocationInfo_2_ResidentialVacancy> residentalVacancies = ORM_RES_LOC_LocationInfo_2_ResidentialVacancy.Query.Search(Connection, Transaction, residentialVacancy_Query);

            List<L5LI_GCLIFRP_0936_ResidentialVacancies> ResidentialVacancies_List = new List<L5LI_GCLIFRP_0936_ResidentialVacancies>();
            L5LI_GCLIFRP_0936_ResidentialVacancies ResidentialVacancy;
            if (residentalVacancies.Count > 0)
            {
                ORM_RES_LOC_ResidentialVacancy.Query ResidentialVacancy_Query;
                foreach (var vacancy in residentalVacancies)
                {
                    ResidentialVacancy_Query = new ORM_RES_LOC_ResidentialVacancy.Query();
                    ResidentialVacancy_Query.RES_LOC_ResidentialVacancyID = vacancy.RES_LOC_ResidentialVacancy_RefID;
                    ResidentialVacancy_Query.Tenant_RefID = securityTicket.TenantID;
                    ResidentialVacancy_Query.IsDeleted = false;
                    List<ORM_RES_LOC_ResidentialVacancy> orm_residentalVacancies = ORM_RES_LOC_ResidentialVacancy.Query.Search(Connection, Transaction, ResidentialVacancy_Query);

                    ResidentialVacancy = new L5LI_GCLIFRP_0936_ResidentialVacancies();
                    ResidentialVacancy.ResidentialVacancies_ID = orm_residentalVacancies[0].RES_LOC_ResidentialVacancyID;
                    ResidentialVacancy.ResidentialVacancies_Name = orm_residentalVacancies[0].ResidentialVacancy_Name;

                    ResidentialVacancies_List.Add(ResidentialVacancy);
                }
            }
            returnValue.Result.ResidentialVacancies = ResidentialVacancies_List.ToArray();


            //return.CommercialVacancies
            ORM_RES_LOC_LocationInfo_2_CommercialVacancy.Query commercialVacancies_Query = new ORM_RES_LOC_LocationInfo_2_CommercialVacancy.Query();
            commercialVacancies_Query.RES_LOC_LocationInfo_RefID = locationInfoFromQuery.RES_LOC_LocationInformationID;
            commercialVacancies_Query.Tenant_RefID = securityTicket.TenantID;
            commercialVacancies_Query.IsDeleted = false;
            List<ORM_RES_LOC_LocationInfo_2_CommercialVacancy> commaericalVacancies = ORM_RES_LOC_LocationInfo_2_CommercialVacancy.Query.Search(Connection, Transaction, commercialVacancies_Query);

            List<L5LI_GCLIFRP_0936_CommercialVacancies> CommercialVacancies_List = new List<L5LI_GCLIFRP_0936_CommercialVacancies>();
            L5LI_GCLIFRP_0936_CommercialVacancies CommercialVacancy;
            if (commaericalVacancies.Count > 0)
            {
                ORM_RES_LOC_CommercialVacancy.Query CommercialVacancies_Query;
                foreach (var vacancy in commaericalVacancies)
                {
                    CommercialVacancies_Query = new ORM_RES_LOC_CommercialVacancy.Query();
                    CommercialVacancies_Query.RES_LOC_CommercialVacancyID = vacancy.RES_LOC_CommercialVacancy_RefID;
                    CommercialVacancies_Query.Tenant_RefID = securityTicket.TenantID;
                    CommercialVacancies_Query.IsDeleted = false;
                    List<ORM_RES_LOC_CommercialVacancy> orm_commercialVacancies = ORM_RES_LOC_CommercialVacancy.Query.Search(Connection, Transaction, CommercialVacancies_Query);

                    CommercialVacancy = new L5LI_GCLIFRP_0936_CommercialVacancies();
                    CommercialVacancy.CommercialVacancies_ID = orm_commercialVacancies[0].RES_LOC_CommercialVacancyID;
                    CommercialVacancy.CommercialVacancies_Name = orm_commercialVacancies[0].CommercialVacancy_Name;

                    CommercialVacancies_List.Add(CommercialVacancy);
                }
            }
            returnValue.Result.CommercialVacancies = CommercialVacancies_List.ToArray();


			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5LI_GCLIFRP_0936 Invoke(string ConnectionString,P_L5LI_GCLIFRP_0936 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5LI_GCLIFRP_0936 Invoke(DbConnection Connection,P_L5LI_GCLIFRP_0936 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5LI_GCLIFRP_0936 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5LI_GCLIFRP_0936 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5LI_GCLIFRP_0936 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5LI_GCLIFRP_0936 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5LI_GCLIFRP_0936 functionReturn = new FR_L5LI_GCLIFRP_0936();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L5LI_GCLIFRP_0936 : FR_Base
	{
		public L5LI_GCLIFRP_0936 Result	{ get; set; }

		public FR_L5LI_GCLIFRP_0936() : base() {}

		public FR_L5LI_GCLIFRP_0936(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5LI_GCLIFRP_0936 for attribute P_L5LI_GCLIFRP_0936
		[DataContract]
		public class P_L5LI_GCLIFRP_0936 
		{
			//Standard type parameters
			[DataMember]
			public Guid RealestatePropertyID { get; set; } 

		}
		#endregion
		#region SClass L5LI_GCLIFRP_0936 for attribute L5LI_GCLIFRP_0936
		[DataContract]
		public class L5LI_GCLIFRP_0936 
		{
			[DataMember]
			public L5LI_GCLIFRP_0936_MeansOfTransportation[] MeansOfTransportation { get; set; }
			[DataMember]
			public L5LI_GCLIFRP_0936_Emmissions[] Emmissions { get; set; }
			[DataMember]
			public L5LI_GCLIFRP_0936_SurroundingInfrastructures[] SurroundingInfrastructures { get; set; }
			[DataMember]
			public L5LI_GCLIFRP_0936_NeighborhoodQualities[] NeighborhoodQualities { get; set; }
			[DataMember]
			public L5LI_GCLIFRP_0936_ParkingSituations[] ParkingSituations { get; set; }
			[DataMember]
			public L5LI_GCLIFRP_0936_ResidentialVacancies[] ResidentialVacancies { get; set; }
			[DataMember]
			public L5LI_GCLIFRP_0936_CommercialVacancies[] CommercialVacancies { get; set; }
			[DataMember]
			public L5LI_GCLIFRP_0936_Address Address { get; set; }
			[DataMember]
			public L5LI_GCLIFRP_0936_Region Region { get; set; }
			[DataMember]
			public L5LI_GCLIFRP_0936_RegionInformation RegionInformation { get; set; }
			[DataMember]
			public L5LI_GCLIFRP_0936_LocationInformation LocationInformation { get; set; }

			//Standard type parameters
			[DataMember]
			public Double RegionInformation_PurchasingPowerAmount_Current_Amount { get; set; } 
			[DataMember]
			public Double RegionInformation_PurchasingPowerAmount_Forecast_Amount { get; set; } 
			[DataMember]
			public Double RegionInformation_ResidentialRent_MinPrice_Amount { get; set; } 
			[DataMember]
			public Double RegionInformation_ResidentialRent_AveragePrice_Amount { get; set; } 
			[DataMember]
			public Double RegionInformation_ResidentialRent_MaxPrice_Amount { get; set; } 
			[DataMember]
			public Double RegionInformation_NonResidentialRent_MinPrice_Amount { get; set; } 
			[DataMember]
			public Double RegionInformation_NonResidentialRent_AveragePrice_Amount { get; set; } 
			[DataMember]
			public Double RegionInformation_NonResidentialRent_MaxPrice_Amount { get; set; } 
			[DataMember]
			public Guid CMN_LOC_LocationID { get; set; } 

		}
		#endregion
		#region SClass L5LI_GCLIFRP_0936_MeansOfTransportation for attribute MeansOfTransportation
		[DataContract]
		public class L5LI_GCLIFRP_0936_MeansOfTransportation 
		{
			//Standard type parameters
			[DataMember]
			public Guid MeansOfTransportation_ID { get; set; } 
			[DataMember]
			public Dict MeansOfTransportation_Name { get; set; } 

		}
		#endregion
		#region SClass L5LI_GCLIFRP_0936_Emmissions for attribute Emmissions
		[DataContract]
		public class L5LI_GCLIFRP_0936_Emmissions 
		{
			//Standard type parameters
			[DataMember]
			public Guid Emmissions_ID { get; set; } 
			[DataMember]
			public Dict Emmissions_Name { get; set; } 

		}
		#endregion
		#region SClass L5LI_GCLIFRP_0936_SurroundingInfrastructures for attribute SurroundingInfrastructures
		[DataContract]
		public class L5LI_GCLIFRP_0936_SurroundingInfrastructures 
		{
			//Standard type parameters
			[DataMember]
			public Guid SurroundingInfrastructures_ID { get; set; } 
			[DataMember]
			public Dict SurroundingInfrastructures_Name { get; set; } 

		}
		#endregion
		#region SClass L5LI_GCLIFRP_0936_NeighborhoodQualities for attribute NeighborhoodQualities
		[DataContract]
		public class L5LI_GCLIFRP_0936_NeighborhoodQualities 
		{
			//Standard type parameters
			[DataMember]
			public Guid NeighborhoodQualities_ID { get; set; } 
			[DataMember]
			public Dict NeighborhoodQualities_Name { get; set; } 

		}
		#endregion
		#region SClass L5LI_GCLIFRP_0936_ParkingSituations for attribute ParkingSituations
		[DataContract]
		public class L5LI_GCLIFRP_0936_ParkingSituations 
		{
			//Standard type parameters
			[DataMember]
			public Guid ParkingSituations_ID { get; set; } 
			[DataMember]
			public Dict ParkingSituations_Name { get; set; } 

		}
		#endregion
		#region SClass L5LI_GCLIFRP_0936_ResidentialVacancies for attribute ResidentialVacancies
		[DataContract]
		public class L5LI_GCLIFRP_0936_ResidentialVacancies 
		{
			//Standard type parameters
			[DataMember]
			public Guid ResidentialVacancies_ID { get; set; } 
			[DataMember]
			public Dict ResidentialVacancies_Name { get; set; } 

		}
		#endregion
		#region SClass L5LI_GCLIFRP_0936_CommercialVacancies for attribute CommercialVacancies
		[DataContract]
		public class L5LI_GCLIFRP_0936_CommercialVacancies 
		{
			//Standard type parameters
			[DataMember]
			public Guid CommercialVacancies_ID { get; set; } 
			[DataMember]
			public Dict CommercialVacancies_Name { get; set; } 

		}
		#endregion
		#region SClass L5LI_GCLIFRP_0936_Address for attribute Address
		[DataContract]
		public class L5LI_GCLIFRP_0936_Address 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_Region { get; set; } 
			[DataMember]
			public String City_AdministrativeDistrict { get; set; } 
			[DataMember]
			public String Province_Name { get; set; } 

		}
		#endregion
		#region SClass L5LI_GCLIFRP_0936_Region for attribute Region
		[DataContract]
		public class L5LI_GCLIFRP_0936_Region 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_LOC_RegionID { get; set; } 
			[DataMember]
			public Guid Country_RefID { get; set; } 

		}
		#endregion
		#region SClass L5LI_GCLIFRP_0936_RegionInformation for attribute RegionInformation
		[DataContract]
		public class L5LI_GCLIFRP_0936_RegionInformation 
		{
			//Standard type parameters
			[DataMember]
			public Double RegionInformation_RegionArea_in_sqkm { get; set; } 
			[DataMember]
			public int RegionInformation_TotalPopulation { get; set; } 
			[DataMember]
			public Double RegionInformation_Population_per_sqkm { get; set; } 
			[DataMember]
			public Double RegionInformation_RegionUnemploymentRatePercent { get; set; } 
			[DataMember]
			public int RegionInformation_NumberOfHouseholds_Current { get; set; } 
			[DataMember]
			public int RegionInformation_NumberOfHouseholds_Forecast { get; set; } 
			[DataMember]
			public Guid RegionInformation_PurchasingPowerAmount_Current_RefID { get; set; } 
			[DataMember]
			public Guid RegionInformation_PurchasingPowerAmount_Forecast_RefID { get; set; } 
			[DataMember]
			public Guid RegionInformation_ResidentialRent_MinPrice_RefID { get; set; } 
			[DataMember]
			public Guid RegionInformation_ResidentialRent_AveragePrice_RefID { get; set; } 
			[DataMember]
			public Guid RegionInformation_ResidentialRent_MaxPrice_RefID { get; set; } 
			[DataMember]
			public Guid RegionInformation_NonResidentialRent_MinPrice_RefID { get; set; } 
			[DataMember]
			public Guid RegionInformation_NonResidentialRent_AveragePrice_RefID { get; set; } 
			[DataMember]
			public Guid RegionInformation_NonResidentialRent_MaxPrice_RefID { get; set; } 

		}
		#endregion
		#region SClass L5LI_GCLIFRP_0936_LocationInformation for attribute LocationInformation
		[DataContract]
		public class L5LI_GCLIFRP_0936_LocationInformation 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_LOC_LocationInformationID { get; set; } 
			[DataMember]
			public Guid MapImage { get; set; } 
			[DataMember]
			public Guid SateliteImage { get; set; } 
			[DataMember]
			public Guid AddressImage { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5LI_GCLIFRP_0936 cls_Get_CompleteLocationInformation_For_RealestatePropertyID(P_L5LI_GCLIFRP_0936 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5LI_GCLIFRP_0936 result = cls_Get_CompleteLocationInformation_For_RealestatePropertyID.Invoke(connectionString,P_L5LI_GCLIFRP_0936 Parameter,securityTicket);
	 return result;
}
*/