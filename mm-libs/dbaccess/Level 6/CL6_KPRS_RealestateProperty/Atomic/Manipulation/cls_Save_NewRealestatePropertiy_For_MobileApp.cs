/* 
 * Generated on 8/21/2013 3:02:01 PM
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
using CL5_KPRS_Realestate.Atomic.Manipulation;
using CL5_KPRS_LocationInfo.Atomic.Manipulation;
using CL3_Country.Atomic.Retrieval;
using CL5_KPRS_Buildings.Atomic.Manipulation;
using CL1_CMN;

namespace CL6_KPRS_RealestateProperty.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_NewRealestatePropertiy_For_MobileApp.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_NewRealestatePropertiy_For_MobileApp
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6RP_SNRPFMA_1321 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            P_L5RE_SREPBI_0846 realestateParam=new P_L5RE_SREPBI_0846();
            realestateParam.InformationSubmittedBy_Account_RefID=securityTicket.AccountID;
            realestateParam.LandRegistrationEntry_GroundAreaSize_in_sqm=0;
            realestateParam.RealestateProperty_ConstructionDate=new DateTime(0);
            realestateParam.RealestateProperty_InformationDate=DateTime.Now;
            realestateParam.RealestateProperty_InternalID=Guid.NewGuid().ToString();
            realestateParam.RealestateProperty_LivingSpace_in_sqm=0;
            realestateParam.RealestateProperty_NumberOfResidentialUnits=0;
            realestateParam.RealestateProperty_RefurbishmentDate=new DateTime(0);
            realestateParam.RealestateProperty_Title=Parameter.Title;
            realestateParam.RES_RealestateProperty_ConstructionTypeID=Guid.Empty;
            realestateParam.RES_RealestateProperty_SourceOfInformationID=Guid.Empty;
            realestateParam.RES_RealestateProperty_TypeID=Guid.Empty;
            realestateParam.Longitude = Parameter.Longitude;
            realestateParam.Lattitude = Parameter.Lattitude;

            returnValue.Result = cls_Save_RealestateProperty_BasicInfo.Invoke(Connection, Transaction, realestateParam, securityTicket).Result;



            P_L5LI_SLI_1538 locationInfoParam = new P_L5LI_SLI_1538();
            locationInfoParam.City_Name = Parameter.City;
            locationInfoParam.City_PostalCode = Parameter.ZipCode;
            locationInfoParam.City_Region = Parameter.Region;
            L3CTR_GAC_1420[] countries = cls_Get_All_Countries.Invoke(Connection, Transaction, securityTicket).Result;

            if (countries.Any(c => c.Country_ISOCode_Alpha2 == Parameter.Country))
            {
                locationInfoParam.Country_RefID = countries.Where(c => c.Country_ISOCode_Alpha2 == Parameter.Country).Select(c => c.CMN_CountryID).FirstOrDefault();

                ORM_CMN_Address address = new ORM_CMN_Address();
                address.Tenant_RefID = securityTicket.TenantID;
                address.Country_ISOCode = Parameter.Country;
                address.Save(Connection, Transaction);

                locationInfoParam.AddressID = address.CMN_AddressID;
            }

            locationInfoParam.Province_Name = Parameter.Province;
            locationInfoParam.Street_Name = Parameter.StreetName;
            locationInfoParam.Street_Number = Parameter.StreetNumber;
            locationInfoParam.RealestatePropertyID = returnValue.Result;
      
            cls_Save_LocationInformation.Invoke(Connection, Transaction,locationInfoParam, securityTicket);

            foreach (var building in Parameter.Buildings)
            {
                P_L5BD_SB_1359 buildingParam = new P_L5BD_SB_1359();
                buildingParam.AppartmentCount = building.numberOfApartments;
                buildingParam.atticsCount = building.numberOfAttics;
                buildingParam.basementsCount = building.numberOfBasements;
                buildingParam.Building_Name = building.name;
                buildingParam.facadesCount = building.numberOfFacades;
                buildingParam.hvarcsCount = building.numberOfHvacrs;
                buildingParam.outdoorfacilitiesCount = building.numberOfOutdoorFacilities;
                buildingParam.RealestatePropertyID = returnValue.Result;
                buildingParam.roofCount = building.numberOfRoofs;
                buildingParam.staircasesCount = building.numberOfStaircases;
                buildingParam.Building_Name = building.name;
                cls_Save_Building.Invoke(Connection, Transaction, buildingParam,securityTicket);
            }
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6RP_SNRPFMA_1321 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6RP_SNRPFMA_1321 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6RP_SNRPFMA_1321 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6RP_SNRPFMA_1321 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_NewRealestatePropertiy_For_MobileApp",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6RP_SNRPFMA_1321 for attribute P_L6RP_SNRPFMA_1321
		[DataContract]
		public class P_L6RP_SNRPFMA_1321 
		{
			[DataMember]
			public P_L6RP_SNRPFMA_1321_Buildings[] Buildings { get; set; }

			//Standard type parameters
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String StreetName { get; set; } 
			[DataMember]
			public String StreetNumber { get; set; } 
			[DataMember]
			public String City { get; set; } 
			[DataMember]
			public String Province { get; set; } 
			[DataMember]
			public String Region { get; set; } 
			[DataMember]
			public String ZipCode { get; set; } 
			[DataMember]
			public String Country { get; set; } 
			[DataMember]
			public double Lattitude { get; set; } 
			[DataMember]
			public double Longitude { get; set; } 

		}
		#endregion
		#region SClass P_L6RP_SNRPFMA_1321_Buildings for attribute Buildings
		[DataContract]
		public class P_L6RP_SNRPFMA_1321_Buildings 
		{
			//Standard type parameters
			[DataMember]
			public String name { get; set; } 
			[DataMember]
			public int numberOfAttics { get; set; } 
			[DataMember]
			public int numberOfApartments { get; set; } 
			[DataMember]
			public int numberOfBasements { get; set; } 
			[DataMember]
			public int numberOfFacades { get; set; } 
			[DataMember]
			public int numberOfHvacrs { get; set; } 
			[DataMember]
			public int numberOfRoofs { get; set; } 
			[DataMember]
			public int numberOfStaircases { get; set; } 
			[DataMember]
			public int numberOfOutdoorFacilities { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_NewRealestatePropertiy_For_MobileApp(,P_L6RP_SNRPFMA_1321 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_NewRealestatePropertiy_For_MobileApp.Invoke(connectionString,P_L6RP_SNRPFMA_1321 Parameter,securityTicket);
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
var parameter = new CL6_KPRS_RealestateProperty.Atomic.Manipulation.P_L6RP_SNRPFMA_1321();
parameter.Buildings = ...;

parameter.Title = ...;
parameter.StreetName = ...;
parameter.StreetNumber = ...;
parameter.City = ...;
parameter.Province = ...;
parameter.Region = ...;
parameter.ZipCode = ...;
parameter.Country = ...;
parameter.Lattitude = ...;
parameter.Longitude = ...;

*/