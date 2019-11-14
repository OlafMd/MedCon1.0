/* 
 * Generated on 3/20/2014 11:57:08 AM
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
using CL1_RES;
using CL1_RES_DUD;
using CL1_RES_BLD;
using CL1_CMN_PER;
using CL1_CMN_LOC;
using CL1_CMN;

namespace CL5_KPRS_DueDiligences.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RevisionGroups_For_RealestatePropertyID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RevisionGroups_For_RealestatePropertyID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DD_GRGFRP_1403_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DD_GRGFRP_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5DD_GRGFRP_1403_Array();
            var retVal = new List<L5DD_GRGFRP_1403>();
            L5DD_GRGFRP_1403 revisionGroupItem;

			//Put your code here
            #region Realestate
            ORM_RES_RealestateProperty realestateProperty = new ORM_RES_RealestateProperty();
            if (Parameter.RealestatePropertyID != Guid.Empty)
            {
                var realestatePropertyResult = realestateProperty.Load(Connection, Transaction, Parameter.RealestatePropertyID);
                if (realestatePropertyResult.Status != FR_Status.Success || realestateProperty.RES_RealestatePropertyID == Guid.Empty)
                    return null;
            }
            #endregion

            #region Address
            ORM_CMN_Address address = new ORM_CMN_Address();

            ORM_CMN_LOC_Location location = new ORM_CMN_LOC_Location();
            var locationResult = location.Load(Connection, Transaction, realestateProperty.RealestateProperty_Location_RefID);
            if (locationResult.Status == FR_Status.Success && location.CMN_LOC_LocationID != Guid.Empty)
            {
                var addressResult = address.Load(Connection, Transaction, location.Address_RefID);
                if (locationResult.Status != FR_Status.Success || location.CMN_LOC_LocationID == Guid.Empty)
                    address = null;
            }
            #endregion

            #region Revision groups for realestrate
            ORM_RES_DUD_RevisionGroup.Query revisionGroupQuery = new ORM_RES_DUD_RevisionGroup.Query();
            revisionGroupQuery.Tenant_RefID = securityTicket.TenantID;
            revisionGroupQuery.IsDeleted = false;
            revisionGroupQuery.RealestateProperty_RefID = realestateProperty.RES_RealestatePropertyID;
            List<ORM_RES_DUD_RevisionGroup> revisionGroupList = ORM_RES_DUD_RevisionGroup.Query.Search(Connection, Transaction, revisionGroupQuery);
            #endregion

            #region Buildings for realestate
            ORM_RES_BLD_Building_RevisionHeader.Query revisionHeaderQuery = new ORM_RES_BLD_Building_RevisionHeader.Query();
            revisionHeaderQuery.Tenant_RefID = securityTicket.TenantID;
            revisionHeaderQuery.IsDeleted = false;
            revisionHeaderQuery.RealestateProperty_RefID = realestateProperty.RES_RealestatePropertyID;
            ORM_RES_BLD_Building_RevisionHeader revisionHeader = ORM_RES_BLD_Building_RevisionHeader.Query.Search(Connection, Transaction, revisionHeaderQuery).FirstOrDefault();

            List<ORM_RES_BLD_Building> buildings = new List<ORM_RES_BLD_Building>();
            List<ORM_RES_DUD_Revision> revisions = new List<ORM_RES_DUD_Revision>();
            List<ORM_RES_BLD_Building_2_BuildingType> buildingTypes = new List<ORM_RES_BLD_Building_2_BuildingType>();
            List<ORM_RES_BLD_Building_2_GarbageContainerType> buildingGarbageContainerType = new List<ORM_RES_BLD_Building_2_GarbageContainerType>();
            if (revisionHeader != null)
            {
                ORM_RES_BLD_Building.Query buildingQuery = new ORM_RES_BLD_Building.Query();
                buildingQuery.Tenant_RefID = securityTicket.TenantID;
                buildingQuery.IsDeleted = false;
                buildingQuery.BuildingRevisionHeader_RefID = revisionHeader.RES_BLD_Building_RevisionHeaderID;
                buildings = ORM_RES_BLD_Building.Query.Search(Connection, Transaction, buildingQuery);

                if (buildings == null)
                    buildings = new List<ORM_RES_BLD_Building>();

                #region revisions and building types for every building
                foreach (var buildingItem in buildings)
                {
                    ORM_RES_DUD_Revision.Query revisionQuery = new ORM_RES_DUD_Revision.Query();
                    revisionQuery.Tenant_RefID = securityTicket.TenantID;
                    revisionQuery.IsDeleted = false;
                    revisionQuery.RES_BLD_Building_RefID = buildingItem.RES_BLD_BuildingID;
                    revisions.AddRange(ORM_RES_DUD_Revision.Query.Search(Connection, Transaction, revisionQuery));

                    ORM_RES_BLD_Building_2_BuildingType.Query buildingTypeQuery = new ORM_RES_BLD_Building_2_BuildingType.Query();
                    buildingTypeQuery.Tenant_RefID = securityTicket.TenantID;
                    buildingTypeQuery.IsDeleted = false;
                    buildingTypeQuery.RES_BLD_Building_RefID = buildingItem.RES_BLD_BuildingID;
                    buildingTypes.AddRange(ORM_RES_BLD_Building_2_BuildingType.Query.Search(Connection, Transaction, buildingTypeQuery));

                    ORM_RES_BLD_Building_2_GarbageContainerType.Query buildingGarbageContainerTypeQuery = new ORM_RES_BLD_Building_2_GarbageContainerType.Query();
                    buildingGarbageContainerTypeQuery.Tenant_RefID = securityTicket.TenantID;
                    buildingGarbageContainerTypeQuery.IsDeleted = false;
                    buildingGarbageContainerTypeQuery.RES_BLD_Building_RefID = buildingItem.RES_BLD_BuildingID;
                    buildingGarbageContainerType.AddRange(ORM_RES_BLD_Building_2_GarbageContainerType.Query.Search(Connection, Transaction, buildingGarbageContainerTypeQuery));
                }
                #endregion

            }
            #endregion

            #region Revision groups
            List<L5DD_GRGFRP_1403_Buildings> buildingsResult;
            L5DD_GRGFRP_1403_Buildings buildingResult;
            foreach (var revisionGroup in revisionGroupList)
            {
                revisionGroupItem = new L5DD_GRGFRP_1403();
                revisionGroupItem.RES_DUD_Revision_GroupID = revisionGroup.RES_DUD_Revision_GroupID;
                revisionGroupItem.RevisionGroup_Name = revisionGroup.RevisionGroup_Name;
                revisionGroupItem.RevisionGroup_SubmittedBy_Account_RefID = revisionGroup.RevisionGroup_SubmittedBy_Account_RefID;
                revisionGroupItem.Creation_Timestamp = revisionGroup.Creation_Timestamp;
                revisionGroupItem.Tenant_RefID = revisionGroup.Tenant_RefID;
                revisionGroupItem.IsDeleted = revisionGroup.IsDeleted;
                revisionGroupItem.RealestateProperty_RefID = revisionGroup.RealestateProperty_RefID;
                revisionGroupItem.RevisionGroup_Comment = revisionGroup.RevisionGroup_Comment;
                
                #region Person info
                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();

                ORM_CMN_PER_PersonInfo_2_Account.Query personInfoAccountQuery = new ORM_CMN_PER_PersonInfo_2_Account.Query();
                personInfoAccountQuery.Tenant_RefID = securityTicket.TenantID;
                personInfoAccountQuery.IsDeleted = false;
                personInfoAccountQuery.USR_Account_RefID = revisionGroup.RevisionGroup_SubmittedBy_Account_RefID;
                ORM_CMN_PER_PersonInfo_2_Account account = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, personInfoAccountQuery).FirstOrDefault();

                if (account != null)
                {
                    var personInfoResult = personInfo.Load(Connection, Transaction, account.CMN_PER_PersonInfo_RefID);
                    if (personInfoResult.Status == FR_Status.Success && personInfo.CMN_PER_PersonInfoID != Guid.Empty)
                    {
                        revisionGroupItem.FirstName = personInfo.FirstName;
                        revisionGroupItem.LastName = personInfo.LastName;
                    }

                }
                #endregion

                #region set address info
                if (address != null)
                {
                    revisionGroupItem.Country_Name = address.Country_Name;
                    revisionGroupItem.City_Region = address.City_Region;
                    revisionGroupItem.City_PostalCode = address.City_PostalCode;
                    revisionGroupItem.City_Name = address.City_Name;
                    revisionGroupItem.Street_Name = address.Street_Name;
                    revisionGroupItem.Street_Number = address.Street_Number;
                }
                #endregion

                #region set building info
                buildingsResult = new List<L5DD_GRGFRP_1403_Buildings>();

                // get revisions for revision group
                var revisionsForRetVal = revisions.Where(i => i.RevisionGroup_RefID == revisionGroup.RES_DUD_Revision_GroupID).ToList();
                ORM_RES_DUD_Revision revisionForBuildingID;

                // get buildings for list of revision
                List<ORM_RES_BLD_Building> buildingForRetVal = new List<ORM_RES_BLD_Building>();
                buildingForRetVal.AddRange(buildings.Where(i => revisionsForRetVal.Any(j => j.RES_BLD_Building_RefID == i.RES_BLD_BuildingID)).ToList());

                foreach (var buildingForRetValItem in buildingForRetVal)
                {
                    revisionForBuildingID = revisionsForRetVal.FirstOrDefault(i => i.RES_BLD_Building_RefID == buildingForRetValItem.RES_BLD_BuildingID);

                    buildingResult = new L5DD_GRGFRP_1403_Buildings();
                    buildingResult.Building_Name = buildingForRetValItem.Building_Name;
                    buildingResult.RES_BLD_BuildingID = buildingForRetValItem.RES_BLD_BuildingID;
                    buildingResult.RES_DUD_RevisionID = revisionForBuildingID.RES_DUD_RevisionID;
                    buildingResult.QuestionnaireVersion_RefID = revisionForBuildingID.QuestionnaireVersion_RefID;

                    buildingResult.RES_BLD_Building_Type_RefID = buildingTypes.FirstOrDefault(i => i.RES_BLD_Building_RefID == buildingForRetValItem.RES_BLD_BuildingID).RES_BLD_Building_Type_RefID;
                    buildingResult.RES_BLD_GarbageContainerType_RefID = buildingGarbageContainerType.FirstOrDefault(i => i.RES_BLD_Building_RefID == buildingForRetValItem.RES_BLD_BuildingID).RES_BLD_GarbageContainerType_RefID;

                    buildingsResult.Add(buildingResult);
                }
                #endregion

                revisionGroupItem.Buildings = buildingsResult.ToArray();
                retVal.Add(revisionGroupItem);
            }
            #endregion

            returnValue.Result = retVal.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DD_GRGFRP_1403_Array Invoke(string ConnectionString,P_L5DD_GRGFRP_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DD_GRGFRP_1403_Array Invoke(DbConnection Connection,P_L5DD_GRGFRP_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DD_GRGFRP_1403_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DD_GRGFRP_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DD_GRGFRP_1403_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DD_GRGFRP_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DD_GRGFRP_1403_Array functionReturn = new FR_L5DD_GRGFRP_1403_Array();
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

	#region Raw Grouping Class
	[Serializable]
	public class L5DD_GRGFRP_1403_raw 
	{
		public Guid RES_DUD_Revision_GroupID; 
		public String RevisionGroup_Name; 
		public Guid RevisionGroup_SubmittedBy_Account_RefID; 
		public DateTime Creation_Timestamp; 
		public Guid Tenant_RefID; 
		public bool IsDeleted; 
		public Guid RealestateProperty_RefID; 
		public String FirstName; 
		public String LastName; 
		public String RevisionGroup_Comment; 
		public String Country_Name; 
		public String City_Region; 
		public String City_PostalCode; 
		public String City_Name; 
		public String Street_Number; 
		public String Street_Name; 
		public String Building_Name; 
		public Guid RES_BLD_BuildingID; 
		public Guid RES_DUD_RevisionID; 
		public Guid QuestionnaireVersion_RefID; 
		public Guid RES_BLD_Building_Type_RefID; 
		public Guid RES_BLD_GarbageContainerType_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DD_GRGFRP_1403[] Convert(List<L5DD_GRGFRP_1403_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DD_GRGFRP_1403 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_DUD_Revision_GroupID)).ToArray()
	group el_L5DD_GRGFRP_1403 by new 
	{ 
		el_L5DD_GRGFRP_1403.RES_DUD_Revision_GroupID,

	}
	into gfunct_L5DD_GRGFRP_1403
	select new L5DD_GRGFRP_1403
	{     
		RES_DUD_Revision_GroupID = gfunct_L5DD_GRGFRP_1403.Key.RES_DUD_Revision_GroupID ,
		RevisionGroup_Name = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().RevisionGroup_Name ,
		RevisionGroup_SubmittedBy_Account_RefID = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().RevisionGroup_SubmittedBy_Account_RefID ,
		Creation_Timestamp = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().Creation_Timestamp ,
		Tenant_RefID = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().Tenant_RefID ,
		IsDeleted = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().IsDeleted ,
		RealestateProperty_RefID = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().RealestateProperty_RefID ,
		FirstName = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().FirstName ,
		LastName = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().LastName ,
		RevisionGroup_Comment = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().RevisionGroup_Comment ,
		Country_Name = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().Country_Name ,
		City_Region = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().City_Region ,
		City_PostalCode = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().City_PostalCode ,
		City_Name = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().City_Name ,
		Street_Number = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().Street_Number ,
		Street_Name = gfunct_L5DD_GRGFRP_1403.FirstOrDefault().Street_Name ,

		Buildings = 
		(
			from el_Buildings in gfunct_L5DD_GRGFRP_1403.Where(element => !EqualsDefaultValue(element.RES_BLD_BuildingID)).ToArray()
			group el_Buildings by new 
			{ 
				el_Buildings.RES_BLD_BuildingID,

			}
			into gfunct_Buildings
			select new L5DD_GRGFRP_1403_Buildings
			{     
				Building_Name = gfunct_Buildings.FirstOrDefault().Building_Name ,
				RES_BLD_BuildingID = gfunct_Buildings.Key.RES_BLD_BuildingID ,
				RES_DUD_RevisionID = gfunct_Buildings.FirstOrDefault().RES_DUD_RevisionID ,
				QuestionnaireVersion_RefID = gfunct_Buildings.FirstOrDefault().QuestionnaireVersion_RefID ,
				RES_BLD_Building_Type_RefID = gfunct_Buildings.FirstOrDefault().RES_BLD_Building_Type_RefID ,
				RES_BLD_GarbageContainerType_RefID = gfunct_Buildings.FirstOrDefault().RES_BLD_GarbageContainerType_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DD_GRGFRP_1403_Array : FR_Base
	{
		public L5DD_GRGFRP_1403[] Result	{ get; set; } 
		public FR_L5DD_GRGFRP_1403_Array() : base() {}

		public FR_L5DD_GRGFRP_1403_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DD_GRGFRP_1403 for attribute P_L5DD_GRGFRP_1403
		[DataContract]
		public class P_L5DD_GRGFRP_1403 
		{
			//Standard type parameters
			[DataMember]
			public Guid RealestatePropertyID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GRGFRP_1403 for attribute L5DD_GRGFRP_1403
		[DataContract]
		public class L5DD_GRGFRP_1403 
		{
			[DataMember]
			public L5DD_GRGFRP_1403_Buildings[] Buildings { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_DUD_Revision_GroupID { get; set; } 
			[DataMember]
			public String RevisionGroup_Name { get; set; } 
			[DataMember]
			public Guid RevisionGroup_SubmittedBy_Account_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid RealestateProperty_RefID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String RevisionGroup_Comment { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 
			[DataMember]
			public String City_Region { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 

		}
		#endregion
		#region SClass L5DD_GRGFRP_1403_Buildings for attribute Buildings
		[DataContract]
		public class L5DD_GRGFRP_1403_Buildings 
		{
			//Standard type parameters
			[DataMember]
			public String Building_Name { get; set; } 
			[DataMember]
			public Guid RES_BLD_BuildingID { get; set; } 
			[DataMember]
			public Guid RES_DUD_RevisionID { get; set; } 
			[DataMember]
			public Guid QuestionnaireVersion_RefID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Building_Type_RefID { get; set; } 
			[DataMember]
			public Guid RES_BLD_GarbageContainerType_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DD_GRGFRP_1403_Array cls_Get_RevisionGroups_For_RealestatePropertyID(P_L5DD_GRGFRP_1403 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5DD_GRGFRP_1403_Array result = cls_Get_RevisionGroups_For_RealestatePropertyID.Invoke(connectionString,P_L5DD_GRGFRP_1403 Parameter,securityTicket);
	 return result;
}
*/