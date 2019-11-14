/* 
 * Generated on 7/23/2013 11:17:37 AM
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

namespace CL5_KPRS_LocationInfo.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_LocationInformation_For_RealestatePropertyID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LocationInformation_For_RealestatePropertyID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5LI_GLIFRP_0953 Execute(DbConnection Connection,DbTransaction Transaction,P_L5LI_GLIFRP_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5LI_GLIFRP_0953();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_LocationInfo.Atomic.Retrieval.SQL.cls_Get_LocationInformation_For_RealestatePropertyID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RealestatePropertyID", Parameter.RealestatePropertyID);


			List<L5LI_GLIFRP_0953> results = new List<L5LI_GLIFRP_0953>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Street_Name","Street_Number","City_PostalCode","City_Name","City_Region","City_AdministrativeDistrict","Province_Name","Country_RefID","RegionInformation_RegionArea_in_sqkm","RegionInformation_TotalPopulation","RegionInformation_Population_per_sqkm","RegionInformation_RegionUnemploymentRatePercent","RegionInformation_NumberOfHouseholds_Current","RegionInformation_NumberOfHouseholds_Forecast","RegionInformation_PurchasingPowerAmount_Current_RefID","RegionInformation_PurchasingPowerAmount_Forecast_RefID","RegionInformation_ResidentialRent_MinPrice_RefID","RegionInformation_ResidentialRent_AveragePrice_RefID","RegionInformation_ResidentialRent_MaxPrice_RefID","RegionInformation_NonResidentialRent_MinPrice_RefID","RegionInformation_NonResidentialRent_AveragePrice_RefID","RegionInformation_NonResidentialRent_MaxPrice_RefID","CMN_LOC_RegionID","CMN_AddressID","RES_LOC_LocationInformationID","CMN_LOC_LocationID" });
				while(reader.Read())
				{
					L5LI_GLIFRP_0953 resultItem = new L5LI_GLIFRP_0953();
					//0:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(0);
					//1:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(1);
					//2:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(2);
					//3:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(3);
					//4:Parameter City_Region of type String
					resultItem.City_Region = reader.GetString(4);
					//5:Parameter City_AdministrativeDistrict of type String
					resultItem.City_AdministrativeDistrict = reader.GetString(5);
					//6:Parameter Province_Name of type String
					resultItem.Province_Name = reader.GetString(6);
					//7:Parameter Country_RefID of type Guid
					resultItem.Country_RefID = reader.GetGuid(7);
					//8:Parameter RegionInformation_RegionArea_in_sqkm of type Double
					resultItem.RegionInformation_RegionArea_in_sqkm = reader.GetDouble(8);
					//9:Parameter RegionInformation_TotalPopulation of type int
					resultItem.RegionInformation_TotalPopulation = reader.GetInteger(9);
					//10:Parameter RegionInformation_Population_per_sqkm of type Double
					resultItem.RegionInformation_Population_per_sqkm = reader.GetDouble(10);
					//11:Parameter RegionInformation_RegionUnemploymentRatePercent of type Double
					resultItem.RegionInformation_RegionUnemploymentRatePercent = reader.GetDouble(11);
					//12:Parameter RegionInformation_NumberOfHouseholds_Current of type int
					resultItem.RegionInformation_NumberOfHouseholds_Current = reader.GetInteger(12);
					//13:Parameter RegionInformation_NumberOfHouseholds_Forecast of type int
					resultItem.RegionInformation_NumberOfHouseholds_Forecast = reader.GetInteger(13);
					//14:Parameter RegionInformation_PurchasingPowerAmount_Current_RefID of type Guid
					resultItem.RegionInformation_PurchasingPowerAmount_Current_RefID = reader.GetGuid(14);
					//15:Parameter RegionInformation_PurchasingPowerAmount_Forecast_RefID of type Guid
					resultItem.RegionInformation_PurchasingPowerAmount_Forecast_RefID = reader.GetGuid(15);
					//16:Parameter RegionInformation_ResidentialRent_MinPrice_RefID of type Guid
					resultItem.RegionInformation_ResidentialRent_MinPrice_RefID = reader.GetGuid(16);
					//17:Parameter RegionInformation_ResidentialRent_AveragePrice_RefID of type Guid
					resultItem.RegionInformation_ResidentialRent_AveragePrice_RefID = reader.GetGuid(17);
					//18:Parameter RegionInformation_ResidentialRent_MaxPrice_RefID of type Guid
					resultItem.RegionInformation_ResidentialRent_MaxPrice_RefID = reader.GetGuid(18);
					//19:Parameter RegionInformation_NonResidentialRent_MinPrice_RefID of type Guid
					resultItem.RegionInformation_NonResidentialRent_MinPrice_RefID = reader.GetGuid(19);
					//20:Parameter RegionInformation_NonResidentialRent_AveragePrice_RefID of type Guid
					resultItem.RegionInformation_NonResidentialRent_AveragePrice_RefID = reader.GetGuid(20);
					//21:Parameter RegionInformation_NonResidentialRent_MaxPrice_RefID of type Guid
					resultItem.RegionInformation_NonResidentialRent_MaxPrice_RefID = reader.GetGuid(21);
					//22:Parameter CMN_LOC_RegionID of type Guid
					resultItem.CMN_LOC_RegionID = reader.GetGuid(22);
					//23:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(23);
					//24:Parameter RES_LOC_LocationInformationID of type Guid
					resultItem.RES_LOC_LocationInformationID = reader.GetGuid(24);
					//25:Parameter CMN_LOC_LocationID of type Guid
					resultItem.CMN_LOC_LocationID = reader.GetGuid(25);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5LI_GLIFRP_0953 Invoke(string ConnectionString,P_L5LI_GLIFRP_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5LI_GLIFRP_0953 Invoke(DbConnection Connection,P_L5LI_GLIFRP_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5LI_GLIFRP_0953 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5LI_GLIFRP_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5LI_GLIFRP_0953 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5LI_GLIFRP_0953 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5LI_GLIFRP_0953 functionReturn = new FR_L5LI_GLIFRP_0953();
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
	public class FR_L5LI_GLIFRP_0953 : FR_Base
	{
		public L5LI_GLIFRP_0953 Result	{ get; set; }

		public FR_L5LI_GLIFRP_0953() : base() {}

		public FR_L5LI_GLIFRP_0953(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5LI_GLIFRP_0953 for attribute P_L5LI_GLIFRP_0953
		[DataContract]
		public class P_L5LI_GLIFRP_0953 
		{
			//Standard type parameters
			[DataMember]
			public Guid RealestatePropertyID { get; set; } 

		}
		#endregion
		#region SClass L5LI_GLIFRP_0953 for attribute L5LI_GLIFRP_0953
		[DataContract]
		public class L5LI_GLIFRP_0953 
		{
			//Standard type parameters
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
			public Guid CMN_LOC_RegionID { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public Guid RES_LOC_LocationInformationID { get; set; } 
			[DataMember]
			public Guid CMN_LOC_LocationID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5LI_GLIFRP_0953 cls_Get_LocationInformation_For_RealestatePropertyID(P_L5LI_GLIFRP_0953 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5LI_GLIFRP_0953 result = cls_Get_LocationInformation_For_RealestatePropertyID.Invoke(connectionString,P_L5LI_GLIFRP_0953 Parameter,securityTicket);
	 return result;
}
*/