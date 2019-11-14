/* 
 * Generated on 7/19/2013 11:24:10 AM
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

namespace CL5_KPRS_Buildings.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Buildings_For_RevisionGroupID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Buildings_For_RevisionGroupID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BD_GBFRG_1005_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_GBFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BD_GBFRG_1005_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_Buildings.Atomic.Retrieval.SQL.cls_Get_Buildings_For_RevisionGroupID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RevisionGroupID", Parameter.RevisionGroupID);



			List<L5BD_GBFRG_1005_raw> results = new List<L5BD_GBFRG_1005_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Building_Name","RES_BLD_BuildingID","IsContaminationSuspected","Building_NumberOfFloors","Building_ElevatorCoveragePercent","Building_NumberOfAppartments","Building_NumberOfOccupiedAppartments","Building_NumberOfOffices","Building_NumberOfRetailUnits","Building_NumberOfProductionUnits","Building_NumberOfOtherUnits","Building_BalconyPortionPercent","RES_DUD_RevisionID","QuestionnaireVersion_RefID","RES_BLD_RoofID","RES_BLD_Roof_Type_RefID","roofComment","RES_BLD_ApartmentID","IsAppartment_ForRent","ApartmentSize_Unit_RefID","ApartmentSize_Value","RES_BLD_Apartment_Type_RefID","apartmentComment","RES_BLD_OutdoorFacilityID","NumberOfGaragePlaces","NumberOfRentedGaragePlaces","RES_BLD_OutdoorFacility_Type_RefID","outdoorComment","RES_BLD_FacadeID","RES_BLD_Facade_Type_RefID","facadeComment","hvacrComment","RES_BLD_HVACR_Type_RefID","RES_BLD_HVACRID","RES_BLD_BasementID","RES_BLD_Basement_Type_RefID","basementComment","RES_BLD_AtticID","RES_BLD_Attic_Type_RefID","atticComment","RES_BLD_StaircaseID","StaircaseSize_Value","StaircaseSize_Unit_RefID","RES_BLD_Staircase_Type_RefID","staircaseComment" });
				while(reader.Read())
				{
					L5BD_GBFRG_1005_raw resultItem = new L5BD_GBFRG_1005_raw();
					//0:Parameter Building_Name of type String
					resultItem.Building_Name = reader.GetString(0);
					//1:Parameter RES_BLD_BuildingID of type Guid
					resultItem.RES_BLD_BuildingID = reader.GetGuid(1);
					//2:Parameter IsContaminationSuspected of type bool
					resultItem.IsContaminationSuspected = reader.GetBoolean(2);
					//3:Parameter Building_NumberOfFloors of type String
					resultItem.Building_NumberOfFloors = reader.GetString(3);
					//4:Parameter Building_ElevatorCoveragePercent of type String
					resultItem.Building_ElevatorCoveragePercent = reader.GetString(4);
					//5:Parameter Building_NumberOfAppartments of type String
					resultItem.Building_NumberOfAppartments = reader.GetString(5);
					//6:Parameter Building_NumberOfOccupiedAppartments of type String
					resultItem.Building_NumberOfOccupiedAppartments = reader.GetString(6);
					//7:Parameter Building_NumberOfOffices of type String
					resultItem.Building_NumberOfOffices = reader.GetString(7);
					//8:Parameter Building_NumberOfRetailUnits of type String
					resultItem.Building_NumberOfRetailUnits = reader.GetString(8);
					//9:Parameter Building_NumberOfProductionUnits of type String
					resultItem.Building_NumberOfProductionUnits = reader.GetString(9);
					//10:Parameter Building_NumberOfOtherUnits of type String
					resultItem.Building_NumberOfOtherUnits = reader.GetString(10);
					//11:Parameter Building_BalconyPortionPercent of type String
					resultItem.Building_BalconyPortionPercent = reader.GetString(11);
					//12:Parameter RES_DUD_RevisionID of type Guid
					resultItem.RES_DUD_RevisionID = reader.GetGuid(12);
					//13:Parameter QuestionnaireVersion_RefID of type Guid
					resultItem.QuestionnaireVersion_RefID = reader.GetGuid(13);
					//14:Parameter RES_BLD_RoofID of type Guid
					resultItem.RES_BLD_RoofID = reader.GetGuid(14);
					//15:Parameter RES_BLD_Roof_Type_RefID of type Guid
					resultItem.RES_BLD_Roof_Type_RefID = reader.GetGuid(15);
					//16:Parameter roofComment of type String
					resultItem.roofComment = reader.GetString(16);
					//17:Parameter RES_BLD_ApartmentID of type Guid
					resultItem.RES_BLD_ApartmentID = reader.GetGuid(17);
					//18:Parameter IsAppartment_ForRent of type bool
					resultItem.IsAppartment_ForRent = reader.GetBoolean(18);
					//19:Parameter ApartmentSize_Unit_RefID of type Guid
					resultItem.ApartmentSize_Unit_RefID = reader.GetGuid(19);
					//20:Parameter ApartmentSize_Value of type String
					resultItem.ApartmentSize_Value = reader.GetString(20);
					//21:Parameter RES_BLD_Apartment_Type_RefID of type Guid
					resultItem.RES_BLD_Apartment_Type_RefID = reader.GetGuid(21);
					//22:Parameter apartmentComment of type String
					resultItem.apartmentComment = reader.GetString(22);
					//23:Parameter RES_BLD_OutdoorFacilityID of type Guid
					resultItem.RES_BLD_OutdoorFacilityID = reader.GetGuid(23);
					//24:Parameter NumberOfGaragePlaces of type String
					resultItem.NumberOfGaragePlaces = reader.GetString(24);
					//25:Parameter NumberOfRentedGaragePlaces of type String
					resultItem.NumberOfRentedGaragePlaces = reader.GetString(25);
					//26:Parameter RES_BLD_OutdoorFacility_Type_RefID of type Guid
					resultItem.RES_BLD_OutdoorFacility_Type_RefID = reader.GetGuid(26);
					//27:Parameter outdoorComment of type String
					resultItem.outdoorComment = reader.GetString(27);
					//28:Parameter RES_BLD_FacadeID of type Guid
					resultItem.RES_BLD_FacadeID = reader.GetGuid(28);
					//29:Parameter RES_BLD_Facade_Type_RefID of type Guid
					resultItem.RES_BLD_Facade_Type_RefID = reader.GetGuid(29);
					//30:Parameter facadeComment of type String
					resultItem.facadeComment = reader.GetString(30);
					//31:Parameter hvacrComment of type String
					resultItem.hvacrComment = reader.GetString(31);
					//32:Parameter RES_BLD_HVACR_Type_RefID of type Guid
					resultItem.RES_BLD_HVACR_Type_RefID = reader.GetGuid(32);
					//33:Parameter RES_BLD_HVACRID of type Guid
					resultItem.RES_BLD_HVACRID = reader.GetGuid(33);
					//34:Parameter RES_BLD_BasementID of type Guid
					resultItem.RES_BLD_BasementID = reader.GetGuid(34);
					//35:Parameter RES_BLD_Basement_Type_RefID of type Guid
					resultItem.RES_BLD_Basement_Type_RefID = reader.GetGuid(35);
					//36:Parameter basementComment of type String
					resultItem.basementComment = reader.GetString(36);
					//37:Parameter RES_BLD_AtticID of type Guid
					resultItem.RES_BLD_AtticID = reader.GetGuid(37);
					//38:Parameter RES_BLD_Attic_Type_RefID of type Guid
					resultItem.RES_BLD_Attic_Type_RefID = reader.GetGuid(38);
					//39:Parameter atticComment of type String
					resultItem.atticComment = reader.GetString(39);
					//40:Parameter RES_BLD_StaircaseID of type Guid
					resultItem.RES_BLD_StaircaseID = reader.GetGuid(40);
					//41:Parameter StaircaseSize_Value of type String
					resultItem.StaircaseSize_Value = reader.GetString(41);
					//42:Parameter StaircaseSize_Unit_RefID of type Guid
					resultItem.StaircaseSize_Unit_RefID = reader.GetGuid(42);
					//43:Parameter RES_BLD_Staircase_Type_RefID of type Guid
					resultItem.RES_BLD_Staircase_Type_RefID = reader.GetGuid(43);
					//44:Parameter staircaseComment of type String
					resultItem.staircaseComment = reader.GetString(44);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Buildings_For_RevisionGroupID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5BD_GBFRG_1005_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BD_GBFRG_1005_Array Invoke(string ConnectionString,P_L5BD_GBFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BD_GBFRG_1005_Array Invoke(DbConnection Connection,P_L5BD_GBFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BD_GBFRG_1005_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_GBFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BD_GBFRG_1005_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_GBFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BD_GBFRG_1005_Array functionReturn = new FR_L5BD_GBFRG_1005_Array();
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

				throw new Exception("Exception occured in method cls_Get_Buildings_For_RevisionGroupID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5BD_GBFRG_1005_raw 
	{
		public String Building_Name; 
		public Guid RES_BLD_BuildingID; 
		public bool IsContaminationSuspected; 
		public String Building_NumberOfFloors; 
		public String Building_ElevatorCoveragePercent; 
		public String Building_NumberOfAppartments; 
		public String Building_NumberOfOccupiedAppartments; 
		public String Building_NumberOfOffices; 
		public String Building_NumberOfRetailUnits; 
		public String Building_NumberOfProductionUnits; 
		public String Building_NumberOfOtherUnits; 
		public String Building_BalconyPortionPercent; 
		public Guid RES_DUD_RevisionID; 
		public Guid QuestionnaireVersion_RefID; 
		public Guid RES_BLD_RoofID; 
		public Guid RES_BLD_Roof_Type_RefID; 
		public String roofComment; 
		public Guid RES_BLD_ApartmentID; 
		public bool IsAppartment_ForRent; 
		public Guid ApartmentSize_Unit_RefID; 
		public String ApartmentSize_Value; 
		public Guid RES_BLD_Apartment_Type_RefID; 
		public String apartmentComment; 
		public Guid RES_BLD_OutdoorFacilityID; 
		public String NumberOfGaragePlaces; 
		public String NumberOfRentedGaragePlaces; 
		public Guid RES_BLD_OutdoorFacility_Type_RefID; 
		public String outdoorComment; 
		public Guid RES_BLD_FacadeID; 
		public Guid RES_BLD_Facade_Type_RefID; 
		public String facadeComment; 
		public String hvacrComment; 
		public Guid RES_BLD_HVACR_Type_RefID; 
		public Guid RES_BLD_HVACRID; 
		public Guid RES_BLD_BasementID; 
		public Guid RES_BLD_Basement_Type_RefID; 
		public String basementComment; 
		public Guid RES_BLD_AtticID; 
		public Guid RES_BLD_Attic_Type_RefID; 
		public String atticComment; 
		public Guid RES_BLD_StaircaseID; 
		public String StaircaseSize_Value; 
		public Guid StaircaseSize_Unit_RefID; 
		public Guid RES_BLD_Staircase_Type_RefID; 
		public String staircaseComment; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5BD_GBFRG_1005[] Convert(List<L5BD_GBFRG_1005_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5BD_GBFRG_1005 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_BLD_BuildingID)).ToArray()
	group el_L5BD_GBFRG_1005 by new 
	{ 
		el_L5BD_GBFRG_1005.RES_BLD_BuildingID,

	}
	into gfunct_L5BD_GBFRG_1005
	select new L5BD_GBFRG_1005
	{     
		Building_Name = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_Name ,
		RES_BLD_BuildingID = gfunct_L5BD_GBFRG_1005.Key.RES_BLD_BuildingID ,
		IsContaminationSuspected = gfunct_L5BD_GBFRG_1005.FirstOrDefault().IsContaminationSuspected ,
		Building_NumberOfFloors = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfFloors ,
		Building_ElevatorCoveragePercent = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_ElevatorCoveragePercent ,
		Building_NumberOfAppartments = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfAppartments ,
		Building_NumberOfOccupiedAppartments = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfOccupiedAppartments ,
		Building_NumberOfOffices = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfOffices ,
		Building_NumberOfRetailUnits = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfRetailUnits ,
		Building_NumberOfProductionUnits = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfProductionUnits ,
		Building_NumberOfOtherUnits = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_NumberOfOtherUnits ,
		Building_BalconyPortionPercent = gfunct_L5BD_GBFRG_1005.FirstOrDefault().Building_BalconyPortionPercent ,
		RES_DUD_RevisionID = gfunct_L5BD_GBFRG_1005.FirstOrDefault().RES_DUD_RevisionID ,
		QuestionnaireVersion_RefID = gfunct_L5BD_GBFRG_1005.FirstOrDefault().QuestionnaireVersion_RefID ,

		Roofs = 
		(
			from el_Roofs in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_RoofID)).ToArray()
			group el_Roofs by new 
			{ 
				el_Roofs.RES_BLD_RoofID,

			}
			into gfunct_Roofs
			select new L5BD_GBFRG_1005_Roof
			{     
				RES_BLD_RoofID = gfunct_Roofs.Key.RES_BLD_RoofID ,
				RES_BLD_Roof_Type_RefID = gfunct_Roofs.FirstOrDefault().RES_BLD_Roof_Type_RefID ,
				roofComment = gfunct_Roofs.FirstOrDefault().roofComment ,

			}
		).ToArray(),
		Apartments = 
		(
			from el_Apartments in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_ApartmentID)).ToArray()
			group el_Apartments by new 
			{ 
				el_Apartments.RES_BLD_ApartmentID,

			}
			into gfunct_Apartments
			select new L5BD_GBFRG_1005_Apartment
			{     
				RES_BLD_ApartmentID = gfunct_Apartments.Key.RES_BLD_ApartmentID ,
				IsAppartment_ForRent = gfunct_Apartments.FirstOrDefault().IsAppartment_ForRent ,
				ApartmentSize_Unit_RefID = gfunct_Apartments.FirstOrDefault().ApartmentSize_Unit_RefID ,
				ApartmentSize_Value = gfunct_Apartments.FirstOrDefault().ApartmentSize_Value ,
				RES_BLD_Apartment_Type_RefID = gfunct_Apartments.FirstOrDefault().RES_BLD_Apartment_Type_RefID ,
				apartmentComment = gfunct_Apartments.FirstOrDefault().apartmentComment ,

			}
		).ToArray(),
		OutdoorFacilities = 
		(
			from el_OutdoorFacilities in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_OutdoorFacilityID)).ToArray()
			group el_OutdoorFacilities by new 
			{ 
				el_OutdoorFacilities.RES_BLD_OutdoorFacilityID,

			}
			into gfunct_OutdoorFacilities
			select new L5BD_GBFRG_1005_OutdoorFacility
			{     
				RES_BLD_OutdoorFacilityID = gfunct_OutdoorFacilities.Key.RES_BLD_OutdoorFacilityID ,
				NumberOfGaragePlaces = gfunct_OutdoorFacilities.FirstOrDefault().NumberOfGaragePlaces ,
				NumberOfRentedGaragePlaces = gfunct_OutdoorFacilities.FirstOrDefault().NumberOfRentedGaragePlaces ,
				RES_BLD_OutdoorFacility_Type_RefID = gfunct_OutdoorFacilities.FirstOrDefault().RES_BLD_OutdoorFacility_Type_RefID ,
				outdoorComment = gfunct_OutdoorFacilities.FirstOrDefault().outdoorComment ,

			}
		).ToArray(),
		Facades = 
		(
			from el_Facades in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_FacadeID)).ToArray()
			group el_Facades by new 
			{ 
				el_Facades.RES_BLD_FacadeID,

			}
			into gfunct_Facades
			select new L5BD_GBFRG_1005_Facade
			{     
				RES_BLD_FacadeID = gfunct_Facades.Key.RES_BLD_FacadeID ,
				RES_BLD_Facade_Type_RefID = gfunct_Facades.FirstOrDefault().RES_BLD_Facade_Type_RefID ,
				facadeComment = gfunct_Facades.FirstOrDefault().facadeComment ,

			}
		).ToArray(),
		HVACRs = 
		(
			from el_HVACRs in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_HVACRID)).ToArray()
			group el_HVACRs by new 
			{ 
				el_HVACRs.RES_BLD_HVACRID,

			}
			into gfunct_HVACRs
			select new L5BD_GBFRG_1005_HVACR
			{     
				hvacrComment = gfunct_HVACRs.FirstOrDefault().hvacrComment ,
				RES_BLD_HVACR_Type_RefID = gfunct_HVACRs.FirstOrDefault().RES_BLD_HVACR_Type_RefID ,
				RES_BLD_HVACRID = gfunct_HVACRs.Key.RES_BLD_HVACRID ,

			}
		).ToArray(),
		Basements = 
		(
			from el_Basements in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_BasementID)).ToArray()
			group el_Basements by new 
			{ 
				el_Basements.RES_BLD_BasementID,

			}
			into gfunct_Basements
			select new L5BD_GBFRG_1005_Basement
			{     
				RES_BLD_BasementID = gfunct_Basements.Key.RES_BLD_BasementID ,
				RES_BLD_Basement_Type_RefID = gfunct_Basements.FirstOrDefault().RES_BLD_Basement_Type_RefID ,
				basementComment = gfunct_Basements.FirstOrDefault().basementComment ,

			}
		).ToArray(),
		Attics = 
		(
			from el_Attics in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_AtticID)).ToArray()
			group el_Attics by new 
			{ 
				el_Attics.RES_BLD_AtticID,

			}
			into gfunct_Attics
			select new L5BD_GBFRG_1005_Attic
			{     
				RES_BLD_AtticID = gfunct_Attics.Key.RES_BLD_AtticID ,
				RES_BLD_Attic_Type_RefID = gfunct_Attics.FirstOrDefault().RES_BLD_Attic_Type_RefID ,
				atticComment = gfunct_Attics.FirstOrDefault().atticComment ,

			}
		).ToArray(),
		Staircases = 
		(
			from el_Staircases in gfunct_L5BD_GBFRG_1005.Where(element => !EqualsDefaultValue(element.RES_BLD_StaircaseID)).ToArray()
			group el_Staircases by new 
			{ 
				el_Staircases.RES_BLD_StaircaseID,

			}
			into gfunct_Staircases
			select new L5BD_GBFRG_1005_Staircase
			{     
				RES_BLD_StaircaseID = gfunct_Staircases.Key.RES_BLD_StaircaseID ,
				StaircaseSize_Value = gfunct_Staircases.FirstOrDefault().StaircaseSize_Value ,
				StaircaseSize_Unit_RefID = gfunct_Staircases.FirstOrDefault().StaircaseSize_Unit_RefID ,
				RES_BLD_Staircase_Type_RefID = gfunct_Staircases.FirstOrDefault().RES_BLD_Staircase_Type_RefID ,
				staircaseComment = gfunct_Staircases.FirstOrDefault().staircaseComment ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5BD_GBFRG_1005_Array : FR_Base
	{
		public L5BD_GBFRG_1005[] Result	{ get; set; } 
		public FR_L5BD_GBFRG_1005_Array() : base() {}

		public FR_L5BD_GBFRG_1005_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BD_GBFRG_1005 for attribute P_L5BD_GBFRG_1005
		[DataContract]
		public class P_L5BD_GBFRG_1005 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionGroupID { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005 for attribute L5BD_GBFRG_1005
		[DataContract]
		public class L5BD_GBFRG_1005 
		{
			[DataMember]
			public L5BD_GBFRG_1005_Roof[] Roofs { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_Apartment[] Apartments { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_OutdoorFacility[] OutdoorFacilities { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_Facade[] Facades { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_HVACR[] HVACRs { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_Basement[] Basements { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_Attic[] Attics { get; set; }
			[DataMember]
			public L5BD_GBFRG_1005_Staircase[] Staircases { get; set; }

			//Standard type parameters
			[DataMember]
			public String Building_Name { get; set; } 
			[DataMember]
			public Guid RES_BLD_BuildingID { get; set; } 
			[DataMember]
			public bool IsContaminationSuspected { get; set; } 
			[DataMember]
			public String Building_NumberOfFloors { get; set; } 
			[DataMember]
			public String Building_ElevatorCoveragePercent { get; set; } 
			[DataMember]
			public String Building_NumberOfAppartments { get; set; } 
			[DataMember]
			public String Building_NumberOfOccupiedAppartments { get; set; } 
			[DataMember]
			public String Building_NumberOfOffices { get; set; } 
			[DataMember]
			public String Building_NumberOfRetailUnits { get; set; } 
			[DataMember]
			public String Building_NumberOfProductionUnits { get; set; } 
			[DataMember]
			public String Building_NumberOfOtherUnits { get; set; } 
			[DataMember]
			public String Building_BalconyPortionPercent { get; set; } 
			[DataMember]
			public Guid RES_DUD_RevisionID { get; set; } 
			[DataMember]
			public Guid QuestionnaireVersion_RefID { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_Roof for attribute Roofs
		[DataContract]
		public class L5BD_GBFRG_1005_Roof 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_RoofID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Roof_Type_RefID { get; set; } 
			[DataMember]
			public String roofComment { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_Apartment for attribute Apartments
		[DataContract]
		public class L5BD_GBFRG_1005_Apartment 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_ApartmentID { get; set; } 
			[DataMember]
			public bool IsAppartment_ForRent { get; set; } 
			[DataMember]
			public Guid ApartmentSize_Unit_RefID { get; set; } 
			[DataMember]
			public String ApartmentSize_Value { get; set; } 
			[DataMember]
			public Guid RES_BLD_Apartment_Type_RefID { get; set; } 
			[DataMember]
			public String apartmentComment { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_OutdoorFacility for attribute OutdoorFacilities
		[DataContract]
		public class L5BD_GBFRG_1005_OutdoorFacility 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_OutdoorFacilityID { get; set; } 
			[DataMember]
			public String NumberOfGaragePlaces { get; set; } 
			[DataMember]
			public String NumberOfRentedGaragePlaces { get; set; } 
			[DataMember]
			public Guid RES_BLD_OutdoorFacility_Type_RefID { get; set; } 
			[DataMember]
			public String outdoorComment { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_Facade for attribute Facades
		[DataContract]
		public class L5BD_GBFRG_1005_Facade 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_FacadeID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Facade_Type_RefID { get; set; } 
			[DataMember]
			public String facadeComment { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_HVACR for attribute HVACRs
		[DataContract]
		public class L5BD_GBFRG_1005_HVACR 
		{
			//Standard type parameters
			[DataMember]
			public String hvacrComment { get; set; } 
			[DataMember]
			public Guid RES_BLD_HVACR_Type_RefID { get; set; } 
			[DataMember]
			public Guid RES_BLD_HVACRID { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_Basement for attribute Basements
		[DataContract]
		public class L5BD_GBFRG_1005_Basement 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_BasementID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Basement_Type_RefID { get; set; } 
			[DataMember]
			public String basementComment { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_Attic for attribute Attics
		[DataContract]
		public class L5BD_GBFRG_1005_Attic 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_AtticID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Attic_Type_RefID { get; set; } 
			[DataMember]
			public String atticComment { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBFRG_1005_Staircase for attribute Staircases
		[DataContract]
		public class L5BD_GBFRG_1005_Staircase 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_StaircaseID { get; set; } 
			[DataMember]
			public String StaircaseSize_Value { get; set; } 
			[DataMember]
			public Guid StaircaseSize_Unit_RefID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Staircase_Type_RefID { get; set; } 
			[DataMember]
			public String staircaseComment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BD_GBFRG_1005_Array cls_Get_Buildings_For_RevisionGroupID(,P_L5BD_GBFRG_1005 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BD_GBFRG_1005_Array invocationResult = cls_Get_Buildings_For_RevisionGroupID.Invoke(connectionString,P_L5BD_GBFRG_1005 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_Buildings.Atomic.Retrieval.P_L5BD_GBFRG_1005();
parameter.RevisionGroupID = ...;

*/