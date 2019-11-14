/* 
 * Generated on 8/20/2013 2:00:19 PM
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
using CL1_RES;
using CL1_CMN_LOC;
using CL1_CMN;

namespace CL5_KPRS_LocationInfo.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_LocationInformation.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_LocationInformation
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5LI_SLI_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            Guid PurchasingPowerAmount_Current;
            Guid PurchasingPowerAmount_Forecast;
            Guid ResidentialRent_MinPrice;
            Guid ResidentialRent_AveragePrice;
            Guid ResidentialRent_MaxPrice;
            Guid NonResidentialRent_MinPrice;
            Guid NonResidentialRent_AveragePrice;
            Guid NonResidentialRent_MaxPrice;

            ORM_CMN_Address address = new ORM_CMN_Address();
            if (Parameter.AddressID != Guid.Empty)
            {
                var result = address.Load(Connection, Transaction, Parameter.AddressID);
                if (result.Status != FR_Status.Success || address.CMN_AddressID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            address.City_Region = Parameter.City_Region;
            address.Street_Name = Parameter.Street_Name;
            address.Street_Number = Parameter.Street_Number;
            address.City_AdministrativeDistrict = Parameter.City_AdministrativeDistrict;
            address.City_Name = Parameter.City_Name;
            address.City_PostalCode = Parameter.City_PostalCode;
            address.Province_Name = Parameter.Province_Name;
            address.Tenant_RefID = securityTicket.TenantID;
            address.Save(Connection, Transaction);

            //for purchasingPowerAmountCurrent
            ORM_CMN_Price price = new ORM_CMN_Price();
            if (Parameter.RegionInformation_PurchasingPowerAmount_Current_RefID != Guid.Empty)
            {
                var result = price.Load(Connection, Transaction, Parameter.RegionInformation_PurchasingPowerAmount_Current_RefID);
                if (result.Status != FR_Status.Success || price.CMN_PriceID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
      
            }
            price.Tenant_RefID = securityTicket.TenantID;
            price.Save(Connection, Transaction);

            PurchasingPowerAmount_Current = price.CMN_PriceID;

            ORM_CMN_Price_Value.Query priceValueQuery = new ORM_CMN_Price_Value.Query();
            priceValueQuery.Tenant_RefID = securityTicket.TenantID;
            priceValueQuery.Price_RefID = price.CMN_PriceID;
            priceValueQuery.IsDeleted = false;
            List<ORM_CMN_Price_Value> prices = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceValueQuery);

            ORM_CMN_Price_Value priceValue=new ORM_CMN_Price_Value();
            if (prices.Count != 0)
            {
                priceValue.Load(Connection, Transaction, prices[0].CMN_Price_ValueID);
            }
            priceValue.Tenant_RefID = securityTicket.TenantID;
            priceValue.Price_RefID = price.CMN_PriceID;
            priceValue.PriceValue_Amount = Parameter.RegionInformation_PurchasingPowerAmount_Current_RefIDValue;
            priceValue.Save(Connection, Transaction);
           

            //for RegionInformation_PurchasingPowerAmount_Forecast_RefID
            price = new ORM_CMN_Price();
            if (Parameter.RegionInformation_PurchasingPowerAmount_Forecast_RefID != Guid.Empty)
            {
                var result = price.Load(Connection, Transaction, Parameter.RegionInformation_PurchasingPowerAmount_Forecast_RefID);
                if (result.Status != FR_Status.Success || price.CMN_PriceID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            price.Tenant_RefID = securityTicket.TenantID;
            price.Save(Connection, Transaction);

            PurchasingPowerAmount_Forecast = price.CMN_PriceID;

            priceValueQuery = new ORM_CMN_Price_Value.Query();
            priceValueQuery.Tenant_RefID = securityTicket.TenantID;
            priceValueQuery.Price_RefID = price.CMN_PriceID;
            priceValueQuery.IsDeleted = false;
            prices = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceValueQuery);

            priceValue = new ORM_CMN_Price_Value();
            if (prices.Count != 0)
            {
                priceValue.Load(Connection, Transaction, prices[0].CMN_Price_ValueID);
            }
            priceValue.Tenant_RefID = securityTicket.TenantID;
            priceValue.Price_RefID = price.CMN_PriceID;
            priceValue.PriceValue_Amount = Parameter.RegionInformation_PurchasingPowerAmount_Forecast_RefIDValue;
            priceValue.Save(Connection, Transaction);

            //for RegionInformation_ResidentialRent_MinPrice_RefID
            price = new ORM_CMN_Price();
            if (Parameter.RegionInformation_ResidentialRent_MinPrice_RefID != Guid.Empty)
            {
                var result = price.Load(Connection, Transaction, Parameter.RegionInformation_ResidentialRent_MinPrice_RefID);
                if (result.Status != FR_Status.Success || price.CMN_PriceID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            price.Tenant_RefID = securityTicket.TenantID;
            price.Save(Connection, Transaction);

            ResidentialRent_MinPrice = price.CMN_PriceID;

            priceValueQuery = new ORM_CMN_Price_Value.Query();
            priceValueQuery.Tenant_RefID = securityTicket.TenantID;
            priceValueQuery.Price_RefID = price.CMN_PriceID;
            priceValueQuery.IsDeleted = false;
            prices = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceValueQuery);

            priceValue = new ORM_CMN_Price_Value();
            if (prices.Count != 0)
            {
                priceValue.Load(Connection, Transaction, prices[0].CMN_Price_ValueID);
            }
            priceValue.Tenant_RefID = securityTicket.TenantID;
            priceValue.Price_RefID = price.CMN_PriceID;
            priceValue.PriceValue_Amount = Parameter.RegionInformation_ResidentialRent_MinPrice_RefIDValue;
            priceValue.Save(Connection, Transaction);

            //for RegionInformation_ResidentialRent_AveragePrice_RefID
            price = new ORM_CMN_Price();
            if (Parameter.RegionInformation_ResidentialRent_AveragePrice_RefID != Guid.Empty)
            {
                var result = price.Load(Connection, Transaction, Parameter.RegionInformation_ResidentialRent_AveragePrice_RefID);
                if (result.Status != FR_Status.Success || price.CMN_PriceID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            price.Tenant_RefID = securityTicket.TenantID;
            price.Save(Connection, Transaction);

            ResidentialRent_AveragePrice = price.CMN_PriceID;

            priceValueQuery = new ORM_CMN_Price_Value.Query();
            priceValueQuery.Tenant_RefID = securityTicket.TenantID;
            priceValueQuery.Price_RefID = price.CMN_PriceID;
            priceValueQuery.IsDeleted = false;
            prices = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceValueQuery);

            priceValue = new ORM_CMN_Price_Value();
            if (prices.Count != 0)
            {
                priceValue.Load(Connection, Transaction, prices[0].CMN_Price_ValueID);
            }
            priceValue.Tenant_RefID = securityTicket.TenantID;
            priceValue.Price_RefID = price.CMN_PriceID;
            priceValue.PriceValue_Amount = Parameter.RegionInformation_ResidentialRent_AveragePrice_RefIDValue;
            priceValue.Save(Connection, Transaction);

            //for RegionInformation_ResidentialRent_MaxPrice_RefID
            price = new ORM_CMN_Price();
            if (Parameter.RegionInformation_ResidentialRent_MaxPrice_RefID != Guid.Empty)
            {
                var result = price.Load(Connection, Transaction, Parameter.RegionInformation_ResidentialRent_MaxPrice_RefID);
                if (result.Status != FR_Status.Success || price.CMN_PriceID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            price.Tenant_RefID = securityTicket.TenantID;
            price.Save(Connection, Transaction);

            ResidentialRent_MaxPrice = price.CMN_PriceID;

            priceValueQuery = new ORM_CMN_Price_Value.Query();
            priceValueQuery.Tenant_RefID = securityTicket.TenantID;
            priceValueQuery.Price_RefID = price.CMN_PriceID;
            priceValueQuery.IsDeleted = false;
            prices = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceValueQuery);

            priceValue = new ORM_CMN_Price_Value();
            if (prices.Count != 0)
            {
                priceValue.Load(Connection, Transaction, prices[0].CMN_Price_ValueID);
            }
            priceValue.Tenant_RefID = securityTicket.TenantID;
            priceValue.Price_RefID = price.CMN_PriceID;
            priceValue.PriceValue_Amount = Parameter.RegionInformation_ResidentialRent_MaxPrice_RefIDValue;
            priceValue.Save(Connection, Transaction);

            //for RegionInformation_NonResidentialRent_MinPrice_RefID
            price = new ORM_CMN_Price();
            if (Parameter.RegionInformation_NonResidentialRent_MinPrice_RefID != Guid.Empty)
            {
                var result = price.Load(Connection, Transaction, Parameter.RegionInformation_NonResidentialRent_MinPrice_RefID);
                if (result.Status != FR_Status.Success || price.CMN_PriceID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            price.Tenant_RefID = securityTicket.TenantID;
            price.Save(Connection, Transaction);

            NonResidentialRent_MinPrice = price.CMN_PriceID;

            priceValueQuery = new ORM_CMN_Price_Value.Query();
            priceValueQuery.Tenant_RefID = securityTicket.TenantID;
            priceValueQuery.Price_RefID = price.CMN_PriceID;
            priceValueQuery.IsDeleted = false;
            prices = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceValueQuery);

            priceValue = new ORM_CMN_Price_Value();
            if (prices.Count != 0)
            {
                priceValue.Load(Connection, Transaction, prices[0].CMN_Price_ValueID);
            }
            priceValue.Tenant_RefID = securityTicket.TenantID;
            priceValue.Price_RefID = price.CMN_PriceID;
            priceValue.PriceValue_Amount = Parameter.RegionInformation_NonResidentialRent_MinPrice_RefIDValue;
            priceValue.Save(Connection, Transaction);

            //for RegionInformation_NonResidentialRent_AveragePrice_RefID
            price = new ORM_CMN_Price();
            if (Parameter.RegionInformation_NonResidentialRent_AveragePrice_RefID != Guid.Empty)
            {
                var result = price.Load(Connection, Transaction, Parameter.RegionInformation_NonResidentialRent_AveragePrice_RefID);
                if (result.Status != FR_Status.Success || price.CMN_PriceID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            price.Tenant_RefID = securityTicket.TenantID;
            price.Save(Connection, Transaction);

            NonResidentialRent_AveragePrice = price.CMN_PriceID;

            priceValueQuery = new ORM_CMN_Price_Value.Query();
            priceValueQuery.Tenant_RefID = securityTicket.TenantID;
            priceValueQuery.Price_RefID = price.CMN_PriceID;
            priceValueQuery.IsDeleted = false;
            prices = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceValueQuery);

            priceValue = new ORM_CMN_Price_Value();
            if (prices.Count != 0)
            {
                priceValue.Load(Connection, Transaction, prices[0].CMN_Price_ValueID);
            }
            priceValue.Tenant_RefID = securityTicket.TenantID;
            priceValue.Price_RefID = price.CMN_PriceID;
            priceValue.PriceValue_Amount = Parameter.RegionInformation_NonResidentialRent_AveragePrice_RefIDValue;
            priceValue.Save(Connection, Transaction);

            //for RegionInformation_NonResidentialRent_MaxPrice_RefID
            price = new ORM_CMN_Price();
            if (Parameter.RegionInformation_NonResidentialRent_MaxPrice_RefID != Guid.Empty)
            {
                var result = price.Load(Connection, Transaction, Parameter.RegionInformation_NonResidentialRent_MaxPrice_RefID);
                if (result.Status != FR_Status.Success || price.CMN_PriceID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            price.Tenant_RefID = securityTicket.TenantID;
            price.Save(Connection, Transaction);

            NonResidentialRent_MaxPrice = price.CMN_PriceID;

            priceValueQuery = new ORM_CMN_Price_Value.Query();
            priceValueQuery.Tenant_RefID = securityTicket.TenantID;
            priceValueQuery.Price_RefID = price.CMN_PriceID;
            priceValueQuery.IsDeleted = false;
            prices = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceValueQuery);

            priceValue = new ORM_CMN_Price_Value();
            if (prices.Count != 0)
            {
                priceValue.Load(Connection, Transaction, prices[0].CMN_Price_ValueID);
            }
            priceValue.Tenant_RefID = securityTicket.TenantID;
            priceValue.Price_RefID = price.CMN_PriceID;
            priceValue.PriceValue_Amount = Parameter.RegionInformation_NonResidentialRent_MaxPrice_RefIDValue;
            priceValue.Save(Connection, Transaction);

            //for regionInfo and region
            ORM_CMN_LOC_Region region = new ORM_CMN_LOC_Region();
            if (Parameter.RegionID != Guid.Empty)
            {
                var result = region.Load(Connection, Transaction, Parameter.RegionID);
                if (result.Status != FR_Status.Success || region.CMN_LOC_RegionID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            ORM_RES_LOC_RegionInformation.Query regionInfo = new ORM_RES_LOC_RegionInformation.Query();
            regionInfo.CMN_LOC_Region_RefID = region.CMN_LOC_RegionID;
            regionInfo.Tenant_RefID = securityTicket.TenantID;
            regionInfo.IsDeleted = false;
            List<ORM_RES_LOC_RegionInformation> infos = ORM_RES_LOC_RegionInformation.Query.Search(Connection, Transaction, regionInfo);

            ORM_RES_LOC_RegionInformation info;
            if (infos.Count > 0)
            {
                info = infos[0];
                info.RegionInformation_RegionArea_in_sqkm = Parameter.RegionInformation_RegionArea_in_sqkm;
                info.RegionInformation_TotalPopulation = Parameter.RegionInformation_TotalPopulation;
                info.RegionInformation_Population_per_sqkm = Parameter.RegionInformation_Population_per_sqkm;
                info.RegionInformation_RegionUnemploymentRatePercent = Parameter.RegionInformation_RegionUnemploymentRatePercent;
                info.RegionInformation_NumberOfHouseholds_Current = Parameter.RegionInformation_NumberOfHouseholds_Current;
                info.RegionInformation_NumberOfHouseholds_Forecast = Parameter.RegionInformation_NumberOfHouseholds_Forecast;
                info.Tenant_RefID = securityTicket.TenantID;
                info.Save(Connection, Transaction);
            }
            else
            {
                info = new ORM_RES_LOC_RegionInformation();
                info.CMN_LOC_Region_RefID = region.CMN_LOC_RegionID;
                info.RegionInformation_RegionArea_in_sqkm = Parameter.RegionInformation_RegionArea_in_sqkm;
                info.RegionInformation_TotalPopulation = Parameter.RegionInformation_TotalPopulation;
                info.RegionInformation_Population_per_sqkm = Parameter.RegionInformation_Population_per_sqkm;
                info.RegionInformation_RegionUnemploymentRatePercent = Parameter.RegionInformation_RegionUnemploymentRatePercent;
                info.RegionInformation_NumberOfHouseholds_Current = Parameter.RegionInformation_NumberOfHouseholds_Current;
                info.RegionInformation_NumberOfHouseholds_Forecast = Parameter.RegionInformation_NumberOfHouseholds_Forecast;
                info.RegionInformation_PurchasingPowerAmount_Current_RefID = PurchasingPowerAmount_Current;
                info.RegionInformation_PurchasingPowerAmount_Forecast_RefID = PurchasingPowerAmount_Forecast;
                info.RegionInformation_ResidentialRent_MinPrice_RefID = ResidentialRent_MinPrice;
                info.RegionInformation_ResidentialRent_AveragePrice_RefID = ResidentialRent_AveragePrice;
                info.RegionInformation_ResidentialRent_MaxPrice_RefID = ResidentialRent_MaxPrice;
                info.RegionInformation_NonResidentialRent_MinPrice_RefID = NonResidentialRent_MinPrice;
                info.RegionInformation_NonResidentialRent_AveragePrice_RefID = NonResidentialRent_AveragePrice;
                info.RegionInformation_NonResidentialRent_MaxPrice_RefID = NonResidentialRent_MaxPrice;
                info.Tenant_RefID = securityTicket.TenantID;
                info.Save(Connection, Transaction);
            }

            //save region
            region.Country_RefID = Parameter.Country_RefID;
            region.Tenant_RefID = securityTicket.TenantID;
            region.Save(Connection, Transaction);

            //for location
            ORM_CMN_LOC_Location location = new ORM_CMN_LOC_Location();
            if (Parameter.CMN_LOC_LocationID != Guid.Empty)
            {
                var result = location.Load(Connection, Transaction, Parameter.CMN_LOC_LocationID);
                if (result.Status != FR_Status.Success || location.CMN_LOC_LocationID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            location.Region_RefID = region.CMN_LOC_RegionID;
            location.Address_RefID = address.CMN_AddressID;
            location.Tenant_RefID = securityTicket.TenantID;
            location.Save(Connection, Transaction);

            //add location ref id in realesteProperty
            ORM_RES_RealestateProperty.Query realestatePropertyQuery = new ORM_RES_RealestateProperty.Query();
            realestatePropertyQuery.RES_RealestatePropertyID = Parameter.RealestatePropertyID;
            List<ORM_RES_RealestateProperty> realestates = ORM_RES_RealestateProperty.Query.Search(Connection, Transaction, realestatePropertyQuery);
            ORM_RES_RealestateProperty realestate = realestates[0];
            realestate.RealestateProperty_Location_RefID = location.CMN_LOC_LocationID;
            realestate.Save(Connection, Transaction);

            //for locationInformation
            ORM_RES_LOC_LocationInformation locationInformation = new ORM_RES_LOC_LocationInformation();
            if (Parameter.LocationInformationID != Guid.Empty)
            {
                var result = locationInformation.Load(Connection, Transaction, Parameter.LocationInformationID);
                if (result.Status != FR_Status.Success || locationInformation.RES_LOC_LocationInformationID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            locationInformation.CMN_LOC_Location_RefID = location.CMN_LOC_LocationID;
            locationInformation.LocationInformation_MapImage_DocID = Parameter.MapImage;
            locationInformation.LocationInformation_SatelliteImage_DocID = Parameter.SateliteImage;
            locationInformation.LocationInformation_AddressImage_DocID = Parameter.AddressImage;
            locationInformation.Tenant_RefID = securityTicket.TenantID;
            locationInformation.Save(Connection, Transaction);

            //for meansOfTrasnportation, emmissions, infrastructures...
            ORM_RES_LOC_LocationInformation_2_MeansOfTransportation transportation;
            ORM_RES_LOC_LocationInformation_2_SurroundingInfrastructure infrastructure;
            ORM_RES_LOC_LocationInformation_2_Emmission emmission;
            ORM_RES_LOC_LocationInformation_2_NeighborhoodQuality qualitie;
            ORM_RES_LOC_LocationInfo_2_ParkingSituation parkingSituation;
            ORM_RES_LOC_LocationInfo_2_ResidentialVacancy residentialVacancy;
            ORM_RES_LOC_LocationInfo_2_CommercialVacancy commercialVacancy;

            ORM_RES_LOC_LocationInformation_2_MeansOfTransportation.Query transportationQuery = new ORM_RES_LOC_LocationInformation_2_MeansOfTransportation.Query();
            transportationQuery.RES_LOC_LocationInformation_RefID = locationInformation.RES_LOC_LocationInformationID;
            transportationQuery.Tenant_RefID = securityTicket.TenantID;
            transportationQuery.IsDeleted = false;
            ORM_RES_LOC_LocationInformation_2_MeansOfTransportation.Query.SoftDelete(Connection, Transaction, transportationQuery);

            if (Parameter.RES_LOC_MeansOfTransportation_RefID != null) 
            {
                foreach (Guid guid in Parameter.RES_LOC_MeansOfTransportation_RefID)
                {
                    transportation = new ORM_RES_LOC_LocationInformation_2_MeansOfTransportation();
                    transportation.RES_LOC_LocationInformation_RefID = locationInformation.RES_LOC_LocationInformationID;
                    transportation.RES_LOC_MeansOfTransportation_RefID = guid;
                    transportation.Tenant_RefID = securityTicket.TenantID;
                    transportation.Save(Connection, Transaction);
                }

            }

            ORM_RES_LOC_LocationInformation_2_SurroundingInfrastructure.Query infrastructureQuery = new ORM_RES_LOC_LocationInformation_2_SurroundingInfrastructure.Query();
            infrastructureQuery.RES_LOC_LocationInformation_RefID = locationInformation.RES_LOC_LocationInformationID;
            infrastructureQuery.Tenant_RefID = securityTicket.TenantID;
            infrastructureQuery.IsDeleted = false;
            ORM_RES_LOC_LocationInformation_2_SurroundingInfrastructure.Query.SoftDelete(Connection, Transaction, infrastructureQuery);

            if (Parameter.RES_LOC_SurroundingInfrastructure_RefID != null) 
            {

                foreach (Guid guid in Parameter.RES_LOC_SurroundingInfrastructure_RefID)
                {
                    infrastructure = new ORM_RES_LOC_LocationInformation_2_SurroundingInfrastructure();
                    infrastructure.RES_LOC_LocationInformation_RefID = locationInformation.RES_LOC_LocationInformationID;
                    infrastructure.RES_LOC_SurroundingInfrastructure_RefID = guid;
                    infrastructure.Tenant_RefID = securityTicket.TenantID;
                    infrastructure.Save(Connection, Transaction);
                }
                
            }

            ORM_RES_LOC_LocationInformation_2_Emmission.Query emmissionQuery = new ORM_RES_LOC_LocationInformation_2_Emmission.Query();
            emmissionQuery.RES_LOC_LocationInformation_RefID = locationInformation.RES_LOC_LocationInformationID;
            emmissionQuery.Tenant_RefID = securityTicket.TenantID;
            emmissionQuery.IsDeleted = false;
            ORM_RES_LOC_LocationInformation_2_Emmission.Query.SoftDelete(Connection, Transaction, emmissionQuery);

            if (Parameter.RES_LOC_Emmission_RefID != null)
            {

                foreach (Guid guid in Parameter.RES_LOC_Emmission_RefID)
                {
                    emmission = new ORM_RES_LOC_LocationInformation_2_Emmission();
                    emmission.RES_LOC_LocationInformation_RefID = locationInformation.RES_LOC_LocationInformationID;
                    emmission.RES_LOC_Emmission_RefID = guid;
                    emmission.Tenant_RefID = securityTicket.TenantID;
                    emmission.Save(Connection, Transaction);
                }

            }

            ORM_RES_LOC_LocationInformation_2_NeighborhoodQuality.Query neighborhoodQuery = new ORM_RES_LOC_LocationInformation_2_NeighborhoodQuality.Query();
            neighborhoodQuery.RES_LOC_LocationInformation_RefID = locationInformation.RES_LOC_LocationInformationID;
            neighborhoodQuery.Tenant_RefID = securityTicket.TenantID;
            neighborhoodQuery.IsDeleted = false;
            ORM_RES_LOC_LocationInformation_2_NeighborhoodQuality.Query.SoftDelete(Connection, Transaction, neighborhoodQuery);

            if (Parameter.RES_LOC_NeighborhoodQuality_RefID != null)
            {

                foreach (Guid guid in Parameter.RES_LOC_NeighborhoodQuality_RefID)
                {
                    qualitie = new ORM_RES_LOC_LocationInformation_2_NeighborhoodQuality();
                    qualitie.RES_LOC_LocationInformation_RefID = locationInformation.RES_LOC_LocationInformationID;
                    qualitie.RES_LOC_NeighborhoodQuality_RefID = guid;
                    qualitie.Tenant_RefID = securityTicket.TenantID;
                    qualitie.Save(Connection, Transaction);
                }

            }

            ORM_RES_LOC_LocationInfo_2_ParkingSituation.Query parkingQuery = new ORM_RES_LOC_LocationInfo_2_ParkingSituation.Query();
            parkingQuery.RES_LOC_LocationInfo_RefID = locationInformation.RES_LOC_LocationInformationID;
            parkingQuery.Tenant_RefID = securityTicket.TenantID;
            parkingQuery.IsDeleted = false;
            ORM_RES_LOC_LocationInfo_2_ParkingSituation.Query.SoftDelete(Connection, Transaction, parkingQuery);

            if (Parameter.RES_LOC_ParkingSituation_RefID != null)
            {

                foreach (Guid guid in Parameter.RES_LOC_ParkingSituation_RefID)
                {
                    parkingSituation = new ORM_RES_LOC_LocationInfo_2_ParkingSituation();
                    parkingSituation.RES_LOC_LocationInfo_RefID = locationInformation.RES_LOC_LocationInformationID;
                    parkingSituation.RES_LOC_ParkingSituation_RefID = guid;
                    parkingSituation.Tenant_RefID = securityTicket.TenantID;
                    parkingSituation.Save(Connection, Transaction);
                }

            }

            ORM_RES_LOC_LocationInfo_2_ResidentialVacancy.Query residentalQuery = new ORM_RES_LOC_LocationInfo_2_ResidentialVacancy.Query();
            residentalQuery.RES_LOC_LocationInfo_RefID = locationInformation.RES_LOC_LocationInformationID;
            residentalQuery.Tenant_RefID = securityTicket.TenantID;
            residentalQuery.IsDeleted = false;
            ORM_RES_LOC_LocationInfo_2_ResidentialVacancy.Query.SoftDelete(Connection, Transaction, residentalQuery);

            if (Parameter.RES_LOC_ResidentialVacancies_RefID != null)
            {

                foreach (Guid guid in Parameter.RES_LOC_ResidentialVacancies_RefID)
                {
                    residentialVacancy = new ORM_RES_LOC_LocationInfo_2_ResidentialVacancy();
                    residentialVacancy.RES_LOC_LocationInfo_RefID = locationInformation.RES_LOC_LocationInformationID;
                    residentialVacancy.RES_LOC_ResidentialVacancy_RefID = guid;
                    residentialVacancy.Tenant_RefID = securityTicket.TenantID;
                    residentialVacancy.Save(Connection, Transaction);
                }

            }

            ORM_RES_LOC_LocationInfo_2_CommercialVacancy.Query commercialQuery = new ORM_RES_LOC_LocationInfo_2_CommercialVacancy.Query();
            commercialQuery.RES_LOC_LocationInfo_RefID = locationInformation.RES_LOC_LocationInformationID;
            commercialQuery.Tenant_RefID = securityTicket.TenantID;
            commercialQuery.IsDeleted = false;
            ORM_RES_LOC_LocationInfo_2_CommercialVacancy.Query.SoftDelete(Connection, Transaction, commercialQuery);

            if (Parameter.RES_LOC_CommercialVacancies_RefID != null)
            {

                foreach (Guid guid in Parameter.RES_LOC_CommercialVacancies_RefID)
                {
                    commercialVacancy = new ORM_RES_LOC_LocationInfo_2_CommercialVacancy();
                    commercialVacancy.RES_LOC_LocationInfo_RefID = locationInformation.RES_LOC_LocationInformationID;
                    commercialVacancy.RES_LOC_CommercialVacancy_RefID = guid;
                    commercialVacancy.Tenant_RefID = securityTicket.TenantID;
                    commercialVacancy.Save(Connection, Transaction);
                }

            }

            returnValue.Result = location.CMN_LOC_LocationID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5LI_SLI_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5LI_SLI_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5LI_SLI_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5LI_SLI_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_LocationInformation",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5LI_SLI_1538 for attribute P_L5LI_SLI_1538
		[DataContract]
		public class P_L5LI_SLI_1538 
		{
			//Standard type parameters
			[DataMember]
			public Guid RealestatePropertyID { get; set; } 
			[DataMember]
			public Guid AddressID { get; set; } 
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
			[DataMember]
			public Double RegionInformation_PurchasingPowerAmount_Current_RefIDValue { get; set; } 
			[DataMember]
			public Double RegionInformation_PurchasingPowerAmount_Forecast_RefIDValue { get; set; } 
			[DataMember]
			public Double RegionInformation_ResidentialRent_MinPrice_RefIDValue { get; set; } 
			[DataMember]
			public Double RegionInformation_ResidentialRent_AveragePrice_RefIDValue { get; set; } 
			[DataMember]
			public Double RegionInformation_ResidentialRent_MaxPrice_RefIDValue { get; set; } 
			[DataMember]
			public Double RegionInformation_NonResidentialRent_MinPrice_RefIDValue { get; set; } 
			[DataMember]
			public Double RegionInformation_NonResidentialRent_AveragePrice_RefIDValue { get; set; } 
			[DataMember]
			public Double RegionInformation_NonResidentialRent_MaxPrice_RefIDValue { get; set; } 
			[DataMember]
			public Guid LocationInformationID { get; set; } 
			[DataMember]
			public Guid MapImage { get; set; } 
			[DataMember]
			public Guid SateliteImage { get; set; } 
			[DataMember]
			public Guid AddressImage { get; set; } 
			[DataMember]
			public Guid CMN_LOC_LocationID { get; set; } 
			[DataMember]
			public Guid[] RES_LOC_Emmission_RefID { get; set; } 
			[DataMember]
			public Guid[] RES_LOC_MeansOfTransportation_RefID { get; set; } 
			[DataMember]
			public Guid[] RES_LOC_NeighborhoodQuality_RefID { get; set; } 
			[DataMember]
			public Guid[] RES_LOC_SurroundingInfrastructure_RefID { get; set; } 
			[DataMember]
			public Guid[] RES_LOC_ParkingSituation_RefID { get; set; } 
			[DataMember]
			public Guid[] RES_LOC_ResidentialVacancies_RefID { get; set; } 
			[DataMember]
			public Guid[] RES_LOC_CommercialVacancies_RefID { get; set; } 
			[DataMember]
			public Guid RegionID { get; set; } 
			[DataMember]
			public Guid Country_RefID { get; set; } 
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

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_LocationInformation(,P_L5LI_SLI_1538 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_LocationInformation.Invoke(connectionString,P_L5LI_SLI_1538 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_LocationInfo.Atomic.Manipulation.P_L5LI_SLI_1538();
parameter.RealestatePropertyID = ...;
parameter.AddressID = ...;
parameter.Street_Name = ...;
parameter.Street_Number = ...;
parameter.City_PostalCode = ...;
parameter.City_Name = ...;
parameter.City_Region = ...;
parameter.City_AdministrativeDistrict = ...;
parameter.Province_Name = ...;
parameter.RegionInformation_PurchasingPowerAmount_Current_RefID = ...;
parameter.RegionInformation_PurchasingPowerAmount_Forecast_RefID = ...;
parameter.RegionInformation_ResidentialRent_MinPrice_RefID = ...;
parameter.RegionInformation_ResidentialRent_AveragePrice_RefID = ...;
parameter.RegionInformation_ResidentialRent_MaxPrice_RefID = ...;
parameter.RegionInformation_NonResidentialRent_MinPrice_RefID = ...;
parameter.RegionInformation_NonResidentialRent_AveragePrice_RefID = ...;
parameter.RegionInformation_NonResidentialRent_MaxPrice_RefID = ...;
parameter.RegionInformation_PurchasingPowerAmount_Current_RefIDValue = ...;
parameter.RegionInformation_PurchasingPowerAmount_Forecast_RefIDValue = ...;
parameter.RegionInformation_ResidentialRent_MinPrice_RefIDValue = ...;
parameter.RegionInformation_ResidentialRent_AveragePrice_RefIDValue = ...;
parameter.RegionInformation_ResidentialRent_MaxPrice_RefIDValue = ...;
parameter.RegionInformation_NonResidentialRent_MinPrice_RefIDValue = ...;
parameter.RegionInformation_NonResidentialRent_AveragePrice_RefIDValue = ...;
parameter.RegionInformation_NonResidentialRent_MaxPrice_RefIDValue = ...;
parameter.LocationInformationID = ...;
parameter.MapImage = ...;
parameter.SateliteImage = ...;
parameter.AddressImage = ...;
parameter.CMN_LOC_LocationID = ...;
parameter.RES_LOC_Emmission_RefID = ...;
parameter.RES_LOC_MeansOfTransportation_RefID = ...;
parameter.RES_LOC_NeighborhoodQuality_RefID = ...;
parameter.RES_LOC_SurroundingInfrastructure_RefID = ...;
parameter.RES_LOC_ParkingSituation_RefID = ...;
parameter.RES_LOC_ResidentialVacancies_RefID = ...;
parameter.RES_LOC_CommercialVacancies_RefID = ...;
parameter.RegionID = ...;
parameter.Country_RefID = ...;
parameter.RegionInformation_RegionArea_in_sqkm = ...;
parameter.RegionInformation_TotalPopulation = ...;
parameter.RegionInformation_Population_per_sqkm = ...;
parameter.RegionInformation_RegionUnemploymentRatePercent = ...;
parameter.RegionInformation_NumberOfHouseholds_Current = ...;
parameter.RegionInformation_NumberOfHouseholds_Forecast = ...;

*/