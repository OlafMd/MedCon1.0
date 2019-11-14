/* 
 * Generated on 7/29/2013 2:31:18 PM
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
using CL5_KPRS_Questionnaire.Complex.Retrieval;
using CL5_KPRS_Buildings.Complex.Retrieval;
using CL5_KPRS_DueDiligences.Atomic.Retrieval;

namespace CL6_KPRS_DueDiligence.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Revisions_For_RevisionGroupID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Revisions_For_RevisionGroupID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DD_GRFRG_1005_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6DD_GRFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L6DD_GRFRG_1005_Array();
            
            List<L6DD_GRFRG_1005> buildingList = new List<L6DD_GRFRG_1005>();
            P_L5BD_GBFRG_1005 param = new P_L5BD_GBFRG_1005();
            param.RevisionGroupID = Parameter.RevisionGroupID;

            L5BD_GBFRG_1005[] buildings = cls_Get_Buildings_For_RevisionGroupID.Invoke(Connection, Transaction, param, securityTicket).Result;
            foreach (var currentBuilding in buildings)
            {
                L6DD_GRFRG_1005 revision = new L6DD_GRFRG_1005();
     
                revision.Building = currentBuilding;
                P_L5QT_GDDQFQ_1507 questionnaireParam = new P_L5QT_GDDQFQ_1507();
                questionnaireParam.QuestionnaireVersionID = currentBuilding.QuestionnaireVersion_RefID;
                var result = cls_Get_DueDiligence_Questionnaire_For_QuestionnaireID.Invoke(Connection, Transaction, questionnaireParam, securityTicket);
                if (result == null)
                {
                    continue;
                }else{
                    revision.Questionnaire = result.Result;
                }
                List<L5DD_GASIfRID_1007> appartments = new List<L5DD_GASIfRID_1007>();
                foreach (var bldApartment in currentBuilding.Apartments)
                {
                    P_L5DD_GASIfRID_1007 builidingPartParam = new P_L5DD_GASIfRID_1007();
                    builidingPartParam.BuildingPartID = bldApartment.RES_BLD_ApartmentID;
                    builidingPartParam.BuildingPartID_IsSpecified = true;
                    builidingPartParam.RevisionID = currentBuilding.RES_DUD_RevisionID;
                    L5DD_GASIfRID_1007[] apartment = cls_Get_ApartmentSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, builidingPartParam, securityTicket).Result;
                    if (apartment.Length != 0)
                    {
                        appartments.Add(apartment[0]);
                    }

                }

                List<L5DD_GATTSIFRID_1411> attics = new List<L5DD_GATTSIFRID_1411>();
                foreach (var bldAttic in currentBuilding.Attics)
                {
                    P_L5DD_GATTSIFRID_1411 builidingPartParam = new P_L5DD_GATTSIFRID_1411();
                    builidingPartParam.BuildingPartID = bldAttic.RES_BLD_AtticID;
                    builidingPartParam.BuildingPartID_IsSpecified = true;
                    builidingPartParam.RevisionID = currentBuilding.RES_DUD_RevisionID;
                    L5DD_GATTSIFRID_1411[] attic = cls_Get_AtticSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, builidingPartParam, securityTicket).Result;
                    if (attic.Length != 0)
                    {
                        attics.Add(attic[0]);
                    }

                }

                List<L5DD_GBSIfRID_1431> basements = new List<L5DD_GBSIfRID_1431>();
                foreach (var bldBasement in currentBuilding.Basements)
                {
                    P_L5DD_GBSIfRID_1431 builidingPartParam = new P_L5DD_GBSIfRID_1431();
                    builidingPartParam.BuildingPartID = bldBasement.RES_BLD_BasementID;
                    builidingPartParam.BuildingPartID_IsSpecified = true;
                    builidingPartParam.RevisionID = currentBuilding.RES_DUD_RevisionID;
                    L5DD_GBSIfRID_1431[] basement = cls_Get_BasementSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, builidingPartParam, securityTicket).Result;
                    if (basement.Length != 0)
                    {
                        basements.Add(basement[0]);
                    }

                }

                List<L5DD_GFSIfRID_1438> facades = new List<L5DD_GFSIfRID_1438>();
                foreach (var bldFacade in currentBuilding.Facades)
                {
                    P_L5DD_GFSIfRID_1438 builidingPartParam = new P_L5DD_GFSIfRID_1438();
                    builidingPartParam.BuildingPartID = bldFacade.RES_BLD_FacadeID;
                    builidingPartParam.BuildingPartID_IsSpecified = true;
                    builidingPartParam.RevisionID = currentBuilding.RES_DUD_RevisionID;
                    L5DD_GFSIfRID_1438[] facade = cls_Get_FacadeSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, builidingPartParam, securityTicket).Result;
                    if (facade.Length != 0)
                    {
                        facades.Add(facade[0]);
                    }

                }

                List<L5DD_GHSIfRID_1448> hvacrs = new List<L5DD_GHSIfRID_1448>();
                foreach (var bldHVACR in currentBuilding.HVACRs)
                {
                    P_L5DD_GHSIfRID_1448 builidingPartParam = new P_L5DD_GHSIfRID_1448();
                    builidingPartParam.BuildingPartID = bldHVACR.RES_BLD_HVACRID;
                    builidingPartParam.BuildingPartID_IsSpecified = true;
                    builidingPartParam.RevisionID = currentBuilding.RES_DUD_RevisionID;
                    L5DD_GHSIfRID_1448[] hvacr = cls_Get_HVACRSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, builidingPartParam, securityTicket).Result;
                    if (hvacr.Length != 0)
                    {
                        hvacrs.Add(hvacr[0]);
                    }

                }

                List<L5DD_GOFSIfRID_1454> outdoors = new List<L5DD_GOFSIfRID_1454>();
                foreach (var bldOutdoor in currentBuilding.OutdoorFacilities)
                {
                    P_L5DD_GOFSIfRID_1454 builidingPartParam = new P_L5DD_GOFSIfRID_1454();
                    builidingPartParam.BuildingPartID = bldOutdoor.RES_BLD_OutdoorFacilityID;
                    builidingPartParam.BuildingPartID_IsSpecified = true;
                    builidingPartParam.RevisionID = currentBuilding.RES_DUD_RevisionID;
                    L5DD_GOFSIfRID_1454[] outdoor = cls_Get_OutdoorFascilitySubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, builidingPartParam, securityTicket).Result;
                    if (outdoor.Length != 0)
                    {
                        outdoors.Add(outdoor[0]);
                    }

                }

                List<L5DD_GRSIfRID_1213> roofs = new List<L5DD_GRSIfRID_1213>();
                foreach (var bldRoof in currentBuilding.Roofs)
                {
                    P_L5DD_GRSIfRID_1213 builidingPartParam = new P_L5DD_GRSIfRID_1213();
                    builidingPartParam.BuildingPartID = bldRoof.RES_BLD_RoofID;
                    builidingPartParam.BuildingPartID_IsSpecified = true;
                    builidingPartParam.RevisionID = currentBuilding.RES_DUD_RevisionID;
                    L5DD_GRSIfRID_1213[] roof = cls_Get_RoofSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, builidingPartParam, securityTicket).Result;
                    if (roof.Length != 0)
                    {
                        roofs.Add(roof[0]);
                    }

                }

                List<L5DD_GASIfRID_1507> staircases = new List<L5DD_GASIfRID_1507>();
                foreach (var bldStaircase in currentBuilding.Staircases)
                {
                    P_L5DD_GASIfRID_1507 builidingPartParam = new P_L5DD_GASIfRID_1507();
                    builidingPartParam.BuildingPartID = bldStaircase.RES_BLD_StaircaseID;
                    builidingPartParam.BuildingPartID_IsSpecified = true;
                    builidingPartParam.RevisionID = currentBuilding.RES_DUD_RevisionID;
                    L5DD_GASIfRID_1507[] staircase = cls_Get_StaircaseSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, builidingPartParam, securityTicket).Result;
                    if (staircase.Length != 0)
                    {
                        staircases.Add(staircase[0]);
                    }

                }
                revision.Properties = new L5BD_GCBIFR_1005_Properties();

                revision.Properties.Apartments = appartments.ToArray();
                revision.Properties.Attics = attics.ToArray();
                revision.Properties.Basements = basements.ToArray();
                revision.Properties.Facades = facades.ToArray();
                revision.Properties.HVACRs = hvacrs.ToArray();
                revision.Properties.Roofs = roofs.ToArray();
                revision.Properties.OutdoorFacilities = outdoors.ToArray();
                revision.Properties.Staircases = staircases.ToArray();
                buildingList.Add(revision);

            }
            returnValue.Result = buildingList.ToArray();
            return returnValue;

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DD_GRFRG_1005_Array Invoke(string ConnectionString,P_L6DD_GRFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DD_GRFRG_1005_Array Invoke(DbConnection Connection,P_L6DD_GRFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DD_GRFRG_1005_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DD_GRFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DD_GRFRG_1005_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DD_GRFRG_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DD_GRFRG_1005_Array functionReturn = new FR_L6DD_GRFRG_1005_Array();
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

				throw new Exception("Exception occured in method cls_Get_Revisions_For_RevisionGroupID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DD_GRFRG_1005_Array : FR_Base
	{
		public L6DD_GRFRG_1005[] Result	{ get; set; } 
		public FR_L6DD_GRFRG_1005_Array() : base() {}

		public FR_L6DD_GRFRG_1005_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DD_GRFRG_1005 for attribute P_L6DD_GRFRG_1005
		[DataContract]
		public class P_L6DD_GRFRG_1005 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionGroupID { get; set; } 

		}
		#endregion
		#region SClass L6DD_GRFRG_1005 for attribute L6DD_GRFRG_1005
		[DataContract]
		public class L6DD_GRFRG_1005 
		{
			[DataMember]
			public L5BD_GCBIFR_1005_Properties Properties { get; set; }

			//Standard type parameters
			[DataMember]
			public L5BD_GBFRG_1005 Building { get; set; } 
			[DataMember]
			public L5QT_GDDQFQ_1507 Questionnaire { get; set; } 

		}
		#endregion
		#region SClass L5BD_GCBIFR_1005_Properties for attribute Properties
		[DataContract]
		public class L5BD_GCBIFR_1005_Properties 
		{
			//Standard type parameters
			[DataMember]
			public L5DD_GASIfRID_1007[] Apartments { get; set; } 
			[DataMember]
			public L5DD_GATTSIFRID_1411[] Attics { get; set; } 
			[DataMember]
			public L5DD_GBSIfRID_1431[] Basements { get; set; } 
			[DataMember]
			public L5DD_GFSIfRID_1438[] Facades { get; set; } 
			[DataMember]
			public L5DD_GHSIfRID_1448[] HVACRs { get; set; } 
			[DataMember]
			public L5DD_GOFSIfRID_1454[] OutdoorFacilities { get; set; } 
			[DataMember]
			public L5DD_GRSIfRID_1213[] Roofs { get; set; } 
			[DataMember]
			public L5DD_GASIfRID_1507[] Staircases { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DD_GRFRG_1005_Array cls_Get_Revisions_For_RevisionGroupID(,P_L6DD_GRFRG_1005 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DD_GRFRG_1005_Array invocationResult = cls_Get_Revisions_For_RevisionGroupID.Invoke(connectionString,P_L6DD_GRFRG_1005 Parameter,securityTicket);
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
var parameter = new CL6_KPRS_DueDiligence.Complex.Retrieval.P_L6DD_GRFRG_1005();
parameter.RevisionGroupID = ...;

*/