/* 
 * Generated on 7/22/2013 5:35:22 PM
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
using CL1_RES_STR;
using CL1_RES_ACT;

namespace CL5_KPRS_Actions.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_get_Action_For_ActionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_get_Action_For_ActionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AT_GAFA_1001 Execute(DbConnection Connection,DbTransaction Transaction,P_L5AT_GAFA_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5AT_GAFA_1001();
			//Put your code here


            returnValue.Result = new L5AT_GAFA_1001();

            ORM_RES_ACT_Action action = new ORM_RES_ACT_Action();
            action.Load(Connection,Transaction,Parameter.ActionID);

            
            ORM_RES_ACT_Action_Version version = new ORM_RES_ACT_Action_Version();
            version.Load(Connection, Transaction, action.CurrentVersion_RefID);

            returnValue.Result.RES_ACT_ActionID = action.RES_ACT_ActionID;
            returnValue.Result.RES_ACT_Action_VersionID = action.CurrentVersion_RefID;
            returnValue.Result.Action_Name = version.Action_Name;
            returnValue.Result.Action_Description=version.Action_Description;
            returnValue.Result.Default_PricePerUnit_RefID = version.Default_PricePerUnit_RefID;
            returnValue.Result.Default_Unit_RefID = version.Default_Unit_RefID;
            returnValue.Result.Default_UnitAmount = version.Default_UnitAmount;
            returnValue.Result.Action_Version = version.Action_Version;




            ORM_RES_STR_Apartment_Property_AvailableAction.Query apartmentQuery = new ORM_RES_STR_Apartment_Property_AvailableAction.Query();
            apartmentQuery.Tenant_RefID = securityTicket.TenantID;
            apartmentQuery.IsDeleted = false;
            apartmentQuery.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
            List<ORM_RES_STR_Apartment_Property_AvailableAction> apartments = ORM_RES_STR_Apartment_Property_AvailableAction.Query.Search(Connection, Transaction, apartmentQuery);

            List<L5AT_GAFA_1001_Apartment_Property> apartmentList = new List<L5AT_GAFA_1001_Apartment_Property>();
            foreach (var buildingPart in apartments)
            {
                L5AT_GAFA_1001_Apartment_Property item = new L5AT_GAFA_1001_Apartment_Property();

                item.RES_STR_Apartment_Property_AvailableActionID = buildingPart.RES_STR_Apartment_Property_AvailableActionID;
                item.RES_STR_Apartment_Property_RefID = buildingPart.RES_STR_Apartment_Property_RefID;
                apartmentList.Add(item);
            }
            returnValue.Result.Apartment_Property = apartmentList.ToArray();

            ORM_RES_STR_Attic_Property_AvailableAction.Query atticQuery = new ORM_RES_STR_Attic_Property_AvailableAction.Query();
            atticQuery.Tenant_RefID = securityTicket.TenantID;
            atticQuery.IsDeleted = false;
            atticQuery.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
            List<ORM_RES_STR_Attic_Property_AvailableAction> attics = ORM_RES_STR_Attic_Property_AvailableAction.Query.Search(Connection, Transaction, atticQuery);

            List<L5AT_GAFA_1001_Attic_Property> atticList = new List<L5AT_GAFA_1001_Attic_Property>();
            foreach (var buildingPart in attics)
            {

                L5AT_GAFA_1001_Attic_Property item = new L5AT_GAFA_1001_Attic_Property();

                item.RES_STR_Attic_Property_AvailableActionID = buildingPart.RES_STR_Attic_Property_AvailableActionID;
                item.RES_STR_Attic_Property_RefID = buildingPart.RES_STR_Attic_Property_RefID;
                atticList.Add(item);
            }
            returnValue.Result.Attic_Property = atticList.ToArray();

            ORM_RES_STR_Basement_Property_AvailableAction.Query basementQuery = new ORM_RES_STR_Basement_Property_AvailableAction.Query();
            basementQuery.Tenant_RefID = securityTicket.TenantID;
            basementQuery.IsDeleted = false;
            basementQuery.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
            List<ORM_RES_STR_Basement_Property_AvailableAction> basements = ORM_RES_STR_Basement_Property_AvailableAction.Query.Search(Connection, Transaction, basementQuery);

            List<L5AT_GAFA_1001_Basement_Property> basementList = new List<L5AT_GAFA_1001_Basement_Property>();
            foreach (var buildingPart in basements)
            {

                L5AT_GAFA_1001_Basement_Property item = new L5AT_GAFA_1001_Basement_Property();

                item.RES_STR_Basement_Property_AvailableActionID = buildingPart.RES_STR_Basement_Property_AvailableActionID;
                item.RES_STR_Basement_Property_RefID = buildingPart.RES_STR_Basement_Property_RefID;
                basementList.Add(item);
            }
            returnValue.Result.Basement_Property = basementList.ToArray();

            ORM_RES_STR_Facade_Property_AvailableAction.Query facadeQuery = new ORM_RES_STR_Facade_Property_AvailableAction.Query();
            facadeQuery.Tenant_RefID = securityTicket.TenantID;
            facadeQuery.IsDeleted = false;
            facadeQuery.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
            List<ORM_RES_STR_Facade_Property_AvailableAction> facades = ORM_RES_STR_Facade_Property_AvailableAction.Query.Search(Connection, Transaction, facadeQuery);

            List<L5AT_GAFA_1001_Facade_Property> facadeList = new List<L5AT_GAFA_1001_Facade_Property>();
            foreach (var buildingPart in facades)
            {

                L5AT_GAFA_1001_Facade_Property item = new L5AT_GAFA_1001_Facade_Property();

                item.RES_STR_Facade_Property_AvailableActionID = buildingPart.RES_STR_Facade_Property_AvailableActionID;
                item.RES_STR_Facade_Property_RefID = buildingPart.RES_STR_Facade_Property_RefID;
                facadeList.Add(item);
            }
            returnValue.Result.Facade_Property = facadeList.ToArray();

            ORM_RES_STR_HVACR_Property_AvailableAction.Query hvacrQuery = new ORM_RES_STR_HVACR_Property_AvailableAction.Query();
            hvacrQuery.Tenant_RefID = securityTicket.TenantID;
            hvacrQuery.IsDeleted = false;
            hvacrQuery.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
            List<ORM_RES_STR_HVACR_Property_AvailableAction> hvacrs = ORM_RES_STR_HVACR_Property_AvailableAction.Query.Search(Connection, Transaction, hvacrQuery);

            List<L5AT_GAFA_1001_HVACR_Property> hvacrList = new List<L5AT_GAFA_1001_HVACR_Property>();
            foreach (var buildingPart in hvacrs)
            {

                L5AT_GAFA_1001_HVACR_Property item = new L5AT_GAFA_1001_HVACR_Property();

                item.RES_STR_HVACR_Property_AvailableActionID = buildingPart.RES_STR_HVACR_Property_AvailableActionID;
                item.RES_STR_HVACR_Property_RefID = buildingPart.RES_STR_HVACR_Property_RefID;
                hvacrList.Add(item);
            }
            returnValue.Result.HVACR_Property = hvacrList.ToArray();

            ORM_RES_STR_OutdoorFacility_Property_AvailableAction.Query outdoorQuery = new ORM_RES_STR_OutdoorFacility_Property_AvailableAction.Query();
            outdoorQuery.Tenant_RefID = securityTicket.TenantID;
            outdoorQuery.IsDeleted = false;
            outdoorQuery.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
            List<ORM_RES_STR_OutdoorFacility_Property_AvailableAction> outdoors = ORM_RES_STR_OutdoorFacility_Property_AvailableAction.Query.Search(Connection, Transaction, outdoorQuery);

            List<L5AT_GAFA_1001_OutdoorFacility_Property> outdoorList = new List<L5AT_GAFA_1001_OutdoorFacility_Property>();
            foreach (var buildingPart in outdoors)
            {
                L5AT_GAFA_1001_OutdoorFacility_Property item = new L5AT_GAFA_1001_OutdoorFacility_Property();
   
                item.RES_STR_OutdoorFacility_Property_AvailableActionID = buildingPart.RES_STR_OutdoorFacility_Property_AvailableActionID;
                item.RES_STR_OutdoorFacility_Property_RefID = buildingPart.RES_STR_OutdoorFacility_Property_RefID;
                outdoorList.Add(item);
            }
            returnValue.Result.OutdoorFacility_Property = outdoorList.ToArray();

            ORM_RES_STR_Roof_Property_AvailableAction.Query roofQuery = new ORM_RES_STR_Roof_Property_AvailableAction.Query();
            roofQuery.Tenant_RefID = securityTicket.TenantID;
            roofQuery.IsDeleted = false;
            roofQuery.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
            List<ORM_RES_STR_Roof_Property_AvailableAction> roofs = ORM_RES_STR_Roof_Property_AvailableAction.Query.Search(Connection, Transaction, roofQuery);

            List<L5AT_GAFA_1001_Roof_Property> roofList = new List<L5AT_GAFA_1001_Roof_Property>();
            foreach (var buildingPart in roofs)
            {

                L5AT_GAFA_1001_Roof_Property item = new L5AT_GAFA_1001_Roof_Property();
           
                item.RES_STR_Roof_Property_AvailableActionID = buildingPart.RES_STR_Roof_Property_AvailableActionID;
                item.RES_STR_Roof_Property_RefID = buildingPart.RES_STR_Roof_Property_RefID;
                roofList.Add(item);
            }
            returnValue.Result.Roof_Property = roofList.ToArray();

            ORM_RES_STR_Staircase_Property_AvailableAction.Query staircaseQuery = new ORM_RES_STR_Staircase_Property_AvailableAction.Query();
            staircaseQuery.Tenant_RefID = securityTicket.TenantID;
            staircaseQuery.IsDeleted = false;
            staircaseQuery.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
            List<ORM_RES_STR_Staircase_Property_AvailableAction> staircases = ORM_RES_STR_Staircase_Property_AvailableAction.Query.Search(Connection, Transaction, staircaseQuery);

            List<L5AT_GAFA_1001_Staircase_Property> staircaseList = new List<L5AT_GAFA_1001_Staircase_Property>();
            foreach (var buildingPart in staircases)
            {

                L5AT_GAFA_1001_Staircase_Property item = new L5AT_GAFA_1001_Staircase_Property();
 
                item.RES_STR_Staircase_Property_AvailableActionsID = action.RES_ACT_ActionID;
                item.RES_STR_Staircase_Property_RefID = buildingPart.RES_STR_Staircase_Property_RefID;
                staircaseList.Add(item);
            }
            returnValue.Result.Staircase_Property = staircaseList.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AT_GAFA_1001 Invoke(string ConnectionString,P_L5AT_GAFA_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AT_GAFA_1001 Invoke(DbConnection Connection,P_L5AT_GAFA_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AT_GAFA_1001 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AT_GAFA_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AT_GAFA_1001 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AT_GAFA_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AT_GAFA_1001 functionReturn = new FR_L5AT_GAFA_1001();
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

				throw new Exception("Exception occured in method cls_get_Action_For_ActionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AT_GAFA_1001_raw 
	{
		public Guid RES_ACT_ActionID; 
		public Guid RES_ACT_Action_VersionID; 
		public Dict Action_Name; 
		public Dict Action_Description; 
		public int Action_Version; 
		public Guid Default_PricePerUnit_RefID; 
		public Guid Default_Unit_RefID; 
		public double Default_UnitAmount; 
		public Guid RES_STR_Attic_Property_RefID; 
		public Guid RES_STR_Attic_Property_AvailableActionID; 
		public Guid RES_STR_Basement_Property_AvailableActionID; 
		public Guid RES_STR_Basement_Property_RefID; 
		public Guid RES_STR_Apartment_Property_AvailableActionID; 
		public Guid RES_STR_Apartment_Property_RefID; 
		public Guid RES_STR_OutdoorFacility_Property_AvailableActionID; 
		public Guid RES_STR_OutdoorFacility_Property_RefID; 
		public Guid RES_STR_HVACR_Property_AvailableActionID; 
		public Guid RES_STR_HVACR_Property_RefID; 
		public Guid RES_STR_Facade_Property_AvailableActionID; 
		public Guid RES_STR_Facade_Property_RefID; 
		public Guid RES_STR_Staircase_Property_RefID; 
		public Guid RES_STR_Staircase_Property_AvailableActionsID; 
		public Guid RES_STR_Roof_Property_AvailableActionID; 
		public Guid RES_STR_Roof_Property_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AT_GAFA_1001[] Convert(List<L5AT_GAFA_1001_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AT_GAFA_1001 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_ACT_ActionID)).ToArray()
	group el_L5AT_GAFA_1001 by new 
	{ 
		el_L5AT_GAFA_1001.RES_ACT_ActionID,

	}
	into gfunct_L5AT_GAFA_1001
	select new L5AT_GAFA_1001
	{     
		RES_ACT_ActionID = gfunct_L5AT_GAFA_1001.Key.RES_ACT_ActionID ,
		RES_ACT_Action_VersionID = gfunct_L5AT_GAFA_1001.FirstOrDefault().RES_ACT_Action_VersionID ,
		Action_Name = gfunct_L5AT_GAFA_1001.FirstOrDefault().Action_Name ,
		Action_Description = gfunct_L5AT_GAFA_1001.FirstOrDefault().Action_Description ,
		Action_Version = gfunct_L5AT_GAFA_1001.FirstOrDefault().Action_Version ,
		Default_PricePerUnit_RefID = gfunct_L5AT_GAFA_1001.FirstOrDefault().Default_PricePerUnit_RefID ,
		Default_Unit_RefID = gfunct_L5AT_GAFA_1001.FirstOrDefault().Default_Unit_RefID ,
		Default_UnitAmount = gfunct_L5AT_GAFA_1001.FirstOrDefault().Default_UnitAmount ,

		Attic_Property = 
		(
			from el_Attic_Property in gfunct_L5AT_GAFA_1001.Where(element => !EqualsDefaultValue(element.RES_STR_Attic_Property_RefID)).ToArray()
			group el_Attic_Property by new 
			{ 
				el_Attic_Property.RES_STR_Attic_Property_RefID,

			}
			into gfunct_Attic_Property
			select new L5AT_GAFA_1001_Attic_Property
			{     
				RES_STR_Attic_Property_RefID = gfunct_Attic_Property.Key.RES_STR_Attic_Property_RefID ,
				RES_STR_Attic_Property_AvailableActionID = gfunct_Attic_Property.FirstOrDefault().RES_STR_Attic_Property_AvailableActionID ,

			}
		).ToArray(),
		Basement_Property = 
		(
			from el_Basement_Property in gfunct_L5AT_GAFA_1001.Where(element => !EqualsDefaultValue(element.RES_STR_Basement_Property_RefID)).ToArray()
			group el_Basement_Property by new 
			{ 
				el_Basement_Property.RES_STR_Basement_Property_RefID,

			}
			into gfunct_Basement_Property
			select new L5AT_GAFA_1001_Basement_Property
			{     
				RES_STR_Basement_Property_AvailableActionID = gfunct_Basement_Property.FirstOrDefault().RES_STR_Basement_Property_AvailableActionID ,
				RES_STR_Basement_Property_RefID = gfunct_Basement_Property.Key.RES_STR_Basement_Property_RefID ,

			}
		).ToArray(),
		Apartment_Property = 
		(
			from el_Apartment_Property in gfunct_L5AT_GAFA_1001.Where(element => !EqualsDefaultValue(element.RES_STR_Apartment_Property_RefID)).ToArray()
			group el_Apartment_Property by new 
			{ 
				el_Apartment_Property.RES_STR_Apartment_Property_RefID,

			}
			into gfunct_Apartment_Property
			select new L5AT_GAFA_1001_Apartment_Property
			{     
				RES_STR_Apartment_Property_AvailableActionID = gfunct_Apartment_Property.FirstOrDefault().RES_STR_Apartment_Property_AvailableActionID ,
				RES_STR_Apartment_Property_RefID = gfunct_Apartment_Property.Key.RES_STR_Apartment_Property_RefID ,

			}
		).ToArray(),
		OutdoorFacility_Property = 
		(
			from el_OutdoorFacility_Property in gfunct_L5AT_GAFA_1001.Where(element => !EqualsDefaultValue(element.RES_STR_OutdoorFacility_Property_RefID)).ToArray()
			group el_OutdoorFacility_Property by new 
			{ 
				el_OutdoorFacility_Property.RES_STR_OutdoorFacility_Property_RefID,

			}
			into gfunct_OutdoorFacility_Property
			select new L5AT_GAFA_1001_OutdoorFacility_Property
			{     
				RES_STR_OutdoorFacility_Property_AvailableActionID = gfunct_OutdoorFacility_Property.FirstOrDefault().RES_STR_OutdoorFacility_Property_AvailableActionID ,
				RES_STR_OutdoorFacility_Property_RefID = gfunct_OutdoorFacility_Property.Key.RES_STR_OutdoorFacility_Property_RefID ,

			}
		).ToArray(),
		HVACR_Property = 
		(
			from el_HVACR_Property in gfunct_L5AT_GAFA_1001.Where(element => !EqualsDefaultValue(element.RES_STR_HVACR_Property_RefID)).ToArray()
			group el_HVACR_Property by new 
			{ 
				el_HVACR_Property.RES_STR_HVACR_Property_RefID,

			}
			into gfunct_HVACR_Property
			select new L5AT_GAFA_1001_HVACR_Property
			{     
				RES_STR_HVACR_Property_AvailableActionID = gfunct_HVACR_Property.FirstOrDefault().RES_STR_HVACR_Property_AvailableActionID ,
				RES_STR_HVACR_Property_RefID = gfunct_HVACR_Property.Key.RES_STR_HVACR_Property_RefID ,

			}
		).ToArray(),
		Facade_Property = 
		(
			from el_Facade_Property in gfunct_L5AT_GAFA_1001.Where(element => !EqualsDefaultValue(element.RES_STR_Facade_Property_RefID)).ToArray()
			group el_Facade_Property by new 
			{ 
				el_Facade_Property.RES_STR_Facade_Property_RefID,

			}
			into gfunct_Facade_Property
			select new L5AT_GAFA_1001_Facade_Property
			{     
				RES_STR_Facade_Property_AvailableActionID = gfunct_Facade_Property.FirstOrDefault().RES_STR_Facade_Property_AvailableActionID ,
				RES_STR_Facade_Property_RefID = gfunct_Facade_Property.Key.RES_STR_Facade_Property_RefID ,

			}
		).ToArray(),
		Staircase_Property = 
		(
			from el_Staircase_Property in gfunct_L5AT_GAFA_1001.Where(element => !EqualsDefaultValue(element.RES_STR_Staircase_Property_RefID)).ToArray()
			group el_Staircase_Property by new 
			{ 
				el_Staircase_Property.RES_STR_Staircase_Property_RefID,

			}
			into gfunct_Staircase_Property
			select new L5AT_GAFA_1001_Staircase_Property
			{     
				RES_STR_Staircase_Property_RefID = gfunct_Staircase_Property.Key.RES_STR_Staircase_Property_RefID ,
				RES_STR_Staircase_Property_AvailableActionsID = gfunct_Staircase_Property.FirstOrDefault().RES_STR_Staircase_Property_AvailableActionsID ,

			}
		).ToArray(),
		Roof_Property = 
		(
			from el_Roof_Property in gfunct_L5AT_GAFA_1001.Where(element => !EqualsDefaultValue(element.RES_STR_Roof_Property_RefID)).ToArray()
			group el_Roof_Property by new 
			{ 
				el_Roof_Property.RES_STR_Roof_Property_RefID,

			}
			into gfunct_Roof_Property
			select new L5AT_GAFA_1001_Roof_Property
			{     
				RES_STR_Roof_Property_AvailableActionID = gfunct_Roof_Property.FirstOrDefault().RES_STR_Roof_Property_AvailableActionID ,
				RES_STR_Roof_Property_RefID = gfunct_Roof_Property.Key.RES_STR_Roof_Property_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AT_GAFA_1001 : FR_Base
	{
		public L5AT_GAFA_1001 Result	{ get; set; }

		public FR_L5AT_GAFA_1001() : base() {}

		public FR_L5AT_GAFA_1001(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AT_GAFA_1001 for attribute P_L5AT_GAFA_1001
		[DataContract]
		public class P_L5AT_GAFA_1001 
		{
			//Standard type parameters
			[DataMember]
			public Guid ActionID { get; set; } 

		}
		#endregion
		#region SClass L5AT_GAFA_1001 for attribute L5AT_GAFA_1001
		[DataContract]
		public class L5AT_GAFA_1001 
		{
			[DataMember]
			public L5AT_GAFA_1001_Attic_Property[] Attic_Property { get; set; }
			[DataMember]
			public L5AT_GAFA_1001_Basement_Property[] Basement_Property { get; set; }
			[DataMember]
			public L5AT_GAFA_1001_Apartment_Property[] Apartment_Property { get; set; }
			[DataMember]
			public L5AT_GAFA_1001_OutdoorFacility_Property[] OutdoorFacility_Property { get; set; }
			[DataMember]
			public L5AT_GAFA_1001_HVACR_Property[] HVACR_Property { get; set; }
			[DataMember]
			public L5AT_GAFA_1001_Facade_Property[] Facade_Property { get; set; }
			[DataMember]
			public L5AT_GAFA_1001_Staircase_Property[] Staircase_Property { get; set; }
			[DataMember]
			public L5AT_GAFA_1001_Roof_Property[] Roof_Property { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_ACT_ActionID { get; set; } 
			[DataMember]
			public Guid RES_ACT_Action_VersionID { get; set; } 
			[DataMember]
			public Dict Action_Name { get; set; } 
			[DataMember]
			public Dict Action_Description { get; set; } 
			[DataMember]
			public int Action_Version { get; set; } 
			[DataMember]
			public Guid Default_PricePerUnit_RefID { get; set; } 
			[DataMember]
			public Guid Default_Unit_RefID { get; set; } 
			[DataMember]
			public double Default_UnitAmount { get; set; } 

		}
		#endregion
		#region SClass L5AT_GAFA_1001_Attic_Property for attribute Attic_Property
		[DataContract]
		public class L5AT_GAFA_1001_Attic_Property 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Attic_Property_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_Attic_Property_AvailableActionID { get; set; } 

		}
		#endregion
		#region SClass L5AT_GAFA_1001_Basement_Property for attribute Basement_Property
		[DataContract]
		public class L5AT_GAFA_1001_Basement_Property 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Basement_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid RES_STR_Basement_Property_RefID { get; set; } 

		}
		#endregion
		#region SClass L5AT_GAFA_1001_Apartment_Property for attribute Apartment_Property
		[DataContract]
		public class L5AT_GAFA_1001_Apartment_Property 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Apartment_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid RES_STR_Apartment_Property_RefID { get; set; } 

		}
		#endregion
		#region SClass L5AT_GAFA_1001_OutdoorFacility_Property for attribute OutdoorFacility_Property
		[DataContract]
		public class L5AT_GAFA_1001_OutdoorFacility_Property 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_OutdoorFacility_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid RES_STR_OutdoorFacility_Property_RefID { get; set; } 

		}
		#endregion
		#region SClass L5AT_GAFA_1001_HVACR_Property for attribute HVACR_Property
		[DataContract]
		public class L5AT_GAFA_1001_HVACR_Property 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_HVACR_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid RES_STR_HVACR_Property_RefID { get; set; } 

		}
		#endregion
		#region SClass L5AT_GAFA_1001_Facade_Property for attribute Facade_Property
		[DataContract]
		public class L5AT_GAFA_1001_Facade_Property 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Facade_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid RES_STR_Facade_Property_RefID { get; set; } 

		}
		#endregion
		#region SClass L5AT_GAFA_1001_Staircase_Property for attribute Staircase_Property
		[DataContract]
		public class L5AT_GAFA_1001_Staircase_Property 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Staircase_Property_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_Staircase_Property_AvailableActionsID { get; set; } 

		}
		#endregion
		#region SClass L5AT_GAFA_1001_Roof_Property for attribute Roof_Property
		[DataContract]
		public class L5AT_GAFA_1001_Roof_Property 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Roof_Property_AvailableActionID { get; set; } 
			[DataMember]
			public Guid RES_STR_Roof_Property_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AT_GAFA_1001 cls_get_Action_For_ActionID(,P_L5AT_GAFA_1001 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AT_GAFA_1001 invocationResult = cls_get_Action_For_ActionID.Invoke(connectionString,P_L5AT_GAFA_1001 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_Actions.Complex.Retrieval.P_L5AT_GAFA_1001();
parameter.ActionID = ...;

*/