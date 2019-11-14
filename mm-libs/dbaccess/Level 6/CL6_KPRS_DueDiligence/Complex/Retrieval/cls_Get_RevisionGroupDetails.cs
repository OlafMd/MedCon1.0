/* 
 * Generated on 8/8/2013 5:43:22 PM
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
using CL1_RES_DUD;
using CL1_RES;
using CL1_CMN_LOC;
using CL1_CMN;
using CL2_AccountInformation.Atomic.Retrieval;
using CL5_KPRS_DueDiligences.Atomic.Retrieval;
using CL5_KPRS_Buildings.Complex.Retrieval;
using CL3_Document.Atomic.Retrieval;
using CL2_Price.Atomic.Retrieval;

namespace CL5_KPRS_DueDiligences.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RevisionGroupDetails.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RevisionGroupDetails
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DD_RGD_1503 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DD_RGD_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6DD_RGD_1503();
            //Put your code here
            returnValue.Result = new L6DD_RGD_1503();

            var ormRevisionGroups = ORM_RES_DUD_RevisionGroup.Query.Search(Connection, Transaction, new ORM_RES_DUD_RevisionGroup.Query()
            {
                RES_DUD_Revision_GroupID = Parameter.RevisionGroupID,
                Tenant_RefID=securityTicket.TenantID,
                IsDeleted = false
            });
            if (ormRevisionGroups.Count == 0)
            {
                return null;
            }
            var revisionGroup = ormRevisionGroups[0];

            var docHeaderIDs = new List<Guid>();
            var priceIDs = new List<Guid>();
            returnValue.Result.Currency = "EUR"; //HARDCODED
            returnValue.Result.Name = revisionGroup.RevisionGroup_Name;
            returnValue.Result.Comment = revisionGroup.RevisionGroup_Comment;
            returnValue.Result.SubmittedByAccount = revisionGroup.RevisionGroup_SubmittedBy_Account_RefID;
            returnValue.Result.CreationTimestamp = revisionGroup.Creation_Timestamp;
            returnValue.Result.RevisionGroupID = revisionGroup.RES_DUD_Revision_GroupID;

            ORM_RES_RealestateProperty ormRealestateProperty = new ORM_RES_RealestateProperty();
            ormRealestateProperty.Load(Connection, Transaction, revisionGroup.RealestateProperty_RefID);
            ORM_CMN_LOC_Location ormLocation = new ORM_CMN_LOC_Location();
            ormLocation.Load(Connection, Transaction, ormRealestateProperty.RealestateProperty_Location_RefID);
            ORM_CMN_Address ormAddress = new ORM_CMN_Address();
            ormAddress.Load(Connection, Transaction, ormLocation.Address_RefID);

            returnValue.Result.Street_Name = ormAddress.Street_Name;
            returnValue.Result.Street_Number = ormAddress.Street_Number;
            returnValue.Result.Country_Name = ormAddress.Country_Name;
            returnValue.Result.City_Name = ormAddress.City_Name;
            returnValue.Result.City_PostalCode = ormAddress.City_PostalCode;
            returnValue.Result.City_Region = ormAddress.City_Region;

            var accountInformation = cls_Get_Account_PersonalInformation_for_AccountID.Invoke(Connection, Transaction, new P_L2AI_GAPIfAI_1627()
            {
                AccountRefID = revisionGroup.RevisionGroup_SubmittedBy_Account_RefID
            }, securityTicket).Result;
            returnValue.Result.SubmittedByAccount_LastName = accountInformation.LastName;
            returnValue.Result.SubmittedByAccount_FirstName = accountInformation.FirstName;

            var revisions = ORM_RES_DUD_Revision.Query.Search(Connection, Transaction, new ORM_RES_DUD_Revision.Query()
            {
                RevisionGroup_RefID = revisionGroup.RES_DUD_Revision_GroupID,
                IsDeleted=false,
                Tenant_RefID=securityTicket.TenantID
            });

            if (revisions == null)
                return null;

            var populatedRevisions = new List<Revisions>();
            #region retrieve revision full details
            foreach (var revision in revisions)
            {
                Revisions populatedRevision = new Revisions();
                populatedRevision.RevisionID = revision.RES_DUD_RevisionID;
                populatedRevision.QuestionnaireVersionID = revision.QuestionnaireVersion_RefID;
                populatedRevision.Comment = revision.Revision_Comment;
                populatedRevision.Title = revision.Revision_Title;
                populatedRevision.CreationTimestamp = revision.Creation_Timestamp;

                //For each revision in revision group gather and assemble info

                #region submision information
                populatedRevision.ApartmentSubmissionInfo = cls_Get_ApartmentSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, new P_L5DD_GASIfRID_1007()
                {
                    RevisionID = revision.RES_DUD_RevisionID
                }, securityTicket).Result;
                if (populatedRevision.ApartmentSubmissionInfo != null)
                {
                    var assessments = populatedRevision.ApartmentSubmissionInfo.SelectMany(a => a.ApartmentPropertyAsessments);
                    if (assessments != null)
                    {
                        var reqActions = assessments.SelectMany(ass => ass.ApartmentReqActions);
                        List<Guid> pricePerUnitRefIDs = reqActions.Where(r=>r.Action_PricePerUnit_RefID != Guid.Empty).Select(r=>r.Action_PricePerUnit_RefID).ToList();
                        List<Guid> effectivePriceRefIDs = reqActions.Where(r => r.EffectivePrice_RefID != Guid.Empty).Select(r => r.EffectivePrice_RefID).ToList();
                        priceIDs.AddRange(pricePerUnitRefIDs);
                        priceIDs.AddRange(effectivePriceRefIDs);
                    }
                }

                populatedRevision.AtticSubmissionInfo = cls_Get_AtticSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, new P_L5DD_GATTSIFRID_1411()
                {
                    RevisionID = revision.RES_DUD_RevisionID
                }, securityTicket).Result;
                if (populatedRevision.AtticSubmissionInfo != null)
                {
                    var assessments = populatedRevision.AtticSubmissionInfo.SelectMany(a => a.AtticPropertyAsessments);
                    if (assessments != null)
                    {
                        var reqActions = assessments.SelectMany(ass => ass.AtticReqActions);
                        List<Guid> pricePerUnitRefIDs = reqActions.Where(r => r.Action_PricePerUnit_RefID != Guid.Empty).Select(r => r.Action_PricePerUnit_RefID).ToList();
                        List<Guid> effectivePriceRefIDs = reqActions.Where(r => r.EffectivePrice_RefID != Guid.Empty).Select(r => r.EffectivePrice_RefID).ToList();
                        priceIDs.AddRange(pricePerUnitRefIDs);
                        priceIDs.AddRange(effectivePriceRefIDs);
                    }
                }

                populatedRevision.BasementSubmissionInfo = cls_Get_BasementSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, new P_L5DD_GBSIfRID_1431()
                {
                    RevisionID = revision.RES_DUD_RevisionID
                }, securityTicket).Result;
                if (populatedRevision.BasementSubmissionInfo != null)
                {
                    var assessments = populatedRevision.BasementSubmissionInfo.SelectMany(a => a.BasementPropertyAsessments);
                    if (assessments != null)
                    {
                        var reqActions = assessments.SelectMany(ass => ass.BasementReqActions);
                        List<Guid> pricePerUnitRefIDs = reqActions.Where(r => r.Action_PricePerUnit_RefID != Guid.Empty).Select(r => r.Action_PricePerUnit_RefID).ToList();
                        List<Guid> effectivePriceRefIDs = reqActions.Where(r => r.EffectivePrice_RefID != Guid.Empty).Select(r => r.EffectivePrice_RefID).ToList();
                        priceIDs.AddRange(pricePerUnitRefIDs);
                        priceIDs.AddRange(effectivePriceRefIDs);
                    }
                }

                populatedRevision.FacadeSubmissionInfo = cls_Get_FacadeSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, new P_L5DD_GFSIfRID_1438()
                {
                    RevisionID = revision.RES_DUD_RevisionID
                }, securityTicket).Result;
                if (populatedRevision.FacadeSubmissionInfo != null)
                {
                    var assessments = populatedRevision.FacadeSubmissionInfo.SelectMany(a => a.FacadePropertyAsessments);
                    if (assessments != null)
                    {
                        var reqActions = assessments.SelectMany(ass => ass.FacadeReqActions);
                        List<Guid> pricePerUnitRefIDs = reqActions.Where(r => r.Action_PricePerUnit_RefID != Guid.Empty).Select(r => r.Action_PricePerUnit_RefID).ToList();
                        List<Guid> effectivePriceRefIDs = reqActions.Where(r => r.EffectivePrice_RefID != Guid.Empty).Select(r => r.EffectivePrice_RefID).ToList();
                        priceIDs.AddRange(pricePerUnitRefIDs);
                        priceIDs.AddRange(effectivePriceRefIDs);
                    }
                }

                populatedRevision.HVACRSubmissionInfo = cls_Get_HVACRSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, new P_L5DD_GHSIfRID_1448()
                {
                    RevisionID = revision.RES_DUD_RevisionID
                }, securityTicket).Result;
                if (populatedRevision.HVACRSubmissionInfo != null)
                {
                    var assessments = populatedRevision.HVACRSubmissionInfo.SelectMany(a => a.HVACRPropertyAsessments);
                    if (assessments != null)
                    {
                        var reqActions = assessments.SelectMany(ass => ass.HVACRReqActions);
                        List<Guid> pricePerUnitRefIDs = reqActions.Where(r => r.Action_PricePerUnit_RefID != Guid.Empty).Select(r => r.Action_PricePerUnit_RefID).ToList();
                        List<Guid> effectivePriceRefIDs = reqActions.Where(r => r.EffectivePrice_RefID != Guid.Empty).Select(r => r.EffectivePrice_RefID).ToList();
                        priceIDs.AddRange(pricePerUnitRefIDs);
                        priceIDs.AddRange(effectivePriceRefIDs);
                    }
                }

                populatedRevision.OutdoorFascilitySubmissionInfo = cls_Get_OutdoorFascilitySubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, new P_L5DD_GOFSIfRID_1454()
                {
                    RevisionID = revision.RES_DUD_RevisionID
                }, securityTicket).Result;
                if (populatedRevision.OutdoorFascilitySubmissionInfo != null)
                {
                    var assessments = populatedRevision.OutdoorFascilitySubmissionInfo.SelectMany(a => a.OutdoorFacilityAsessments);
                    if (assessments != null)
                    {
                        var reqActions = assessments.SelectMany(ass => ass.OutdoorFacilityReqActions);
                        List<Guid> pricePerUnitRefIDs = reqActions.Where(r => r.Action_PricePerUnit_RefID != Guid.Empty).Select(r => r.Action_PricePerUnit_RefID).ToList();
                        List<Guid> effectivePriceRefIDs = reqActions.Where(r => r.EffectivePrice_RefID != Guid.Empty).Select(r => r.EffectivePrice_RefID).ToList();
                        priceIDs.AddRange(pricePerUnitRefIDs);
                        priceIDs.AddRange(effectivePriceRefIDs);
                    }
                }

                populatedRevision.RoofSubmissionInfo = cls_Get_RoofSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, new P_L5DD_GRSIfRID_1213()
                {
                    RevisionID = revision.RES_DUD_RevisionID
                }, securityTicket).Result;
                if (populatedRevision.RoofSubmissionInfo != null)
                {
                    var assessments = populatedRevision.RoofSubmissionInfo.SelectMany(a => a.RoofPropertyAsessments);
                    if (assessments != null)
                    {
                        var reqActions = assessments.SelectMany(ass => ass.RoofReqActions);
                        List<Guid> pricePerUnitRefIDs = reqActions.Where(r => r.Action_PricePerUnit_RefID != Guid.Empty).Select(r => r.Action_PricePerUnit_RefID).ToList();
                        List<Guid> effectivePriceRefIDs = reqActions.Where(r => r.EffectivePrice_RefID != Guid.Empty).Select(r => r.EffectivePrice_RefID).ToList();
                        priceIDs.AddRange(pricePerUnitRefIDs);
                        priceIDs.AddRange(effectivePriceRefIDs);
                    }
                }

                populatedRevision.StaircaseSubmissionInfo = cls_Get_StaircaseSubmisionInfo_For_RevisionID.Invoke(Connection, Transaction, new P_L5DD_GASIfRID_1507()
                {
                    RevisionID = revision.RES_DUD_RevisionID
                }, securityTicket).Result;
                if (populatedRevision.StaircaseSubmissionInfo != null)
                {
                    var assessments = populatedRevision.StaircaseSubmissionInfo.SelectMany(a => a.StaircasePropertyAsessments);
                    if (assessments != null)
                    {
                        var reqActions = assessments.SelectMany(ass => ass.StaircaseReqActions);
                        List<Guid> pricePerUnitRefIDs = reqActions.Where(r => r.Action_PricePerUnit_RefID != Guid.Empty).Select(r => r.Action_PricePerUnit_RefID).ToList();
                        List<Guid> effectivePriceRefIDs = reqActions.Where(r => r.EffectivePrice_RefID != Guid.Empty).Select(r => r.EffectivePrice_RefID).ToList();
                        priceIDs.AddRange(pricePerUnitRefIDs);
                        priceIDs.AddRange(effectivePriceRefIDs);
                    }
                }

                #endregion

                #region building information

                populatedRevision.Building = cls_Get_BuildingInfo_for_Building_ID.Invoke(Connection, Transaction, new P_L5BL_GBIfBI_1159()
                {
                    BuildingID = revision.RES_BLD_Building_RefID
                }, securityTicket).Result;

                populatedRevisions.Add(populatedRevision);
                #endregion

            }
            #endregion
            returnValue.Result.Revisions = populatedRevisions.ToArray();


            #region Retrieve Images (documents)

            //retrieve image and price ID's
            foreach (var revision in returnValue.Result.Revisions)
            {
                docHeaderIDs.AddRange(revision.ApartmentSubmissionInfo.Select(x => x.Apartment_DocumentHeader_RefID));
                docHeaderIDs.AddRange(revision.ApartmentSubmissionInfo.SelectMany(x => x.ApartmentPropertyAsessments.Select(s => s.DocumentHeader_RefID)));

                docHeaderIDs.AddRange(revision.AtticSubmissionInfo.Select(x => x.Attic_DocumentHeader_RefID));
                docHeaderIDs.AddRange(revision.AtticSubmissionInfo.SelectMany(x => x.AtticPropertyAsessments.Select(s => s.DocumentHeader_RefID)));

                docHeaderIDs.AddRange(revision.BasementSubmissionInfo.Select(x => x.Basement_DocumentHeader_RefID));
                docHeaderIDs.AddRange(revision.BasementSubmissionInfo.SelectMany(x => x.BasementPropertyAsessments.Select(s => s.DocumentHeader_RefID)));

                docHeaderIDs.AddRange(revision.FacadeSubmissionInfo.Select(x => x.Facade_DocumentHeader_RefID));
                docHeaderIDs.AddRange(revision.FacadeSubmissionInfo.SelectMany(x => x.FacadePropertyAsessments.Select(s => s.DocumentHeader_RefID)));

                docHeaderIDs.AddRange(revision.HVACRSubmissionInfo.Select(x => x.HVACR_DocumentHeader_RefID));
                docHeaderIDs.AddRange(revision.HVACRSubmissionInfo.SelectMany(x => x.HVACRPropertyAsessments.Select(s => s.DocumentHeader_RefID)));

                docHeaderIDs.AddRange(revision.OutdoorFascilitySubmissionInfo.Select(x => x.OutdoorF_DocumentHeader_RefID));
                docHeaderIDs.AddRange(revision.OutdoorFascilitySubmissionInfo.SelectMany(x => x.OutdoorFacilityAsessments.Select(s => s.DocumentHeader_RefID)));

                docHeaderIDs.AddRange(revision.RoofSubmissionInfo.Select(x => x.Roof_DocumentHeader_RefID));
                docHeaderIDs.AddRange(revision.RoofSubmissionInfo.SelectMany(x => x.RoofPropertyAsessments.Select(s => s.DocumentHeader_RefID)));

                docHeaderIDs.AddRange(revision.StaircaseSubmissionInfo.Select(x => x.Staircase_DocumentHeader_RefID));
                docHeaderIDs.AddRange(revision.StaircaseSubmissionInfo.SelectMany(x => x.StaircasePropertyAsessments.Select(s => s.DocumentHeader_RefID)));

                docHeaderIDs.Add(revision.Building.Building_DocumentationStructure_RefID);


                priceIDs.AddRange(revision.ApartmentSubmissionInfo.SelectMany(x => x.ApartmentPropertyAsessments.SelectMany(s => s.ApartmentReqActions.Select(z => z.Action_PricePerUnit_RefID))));
                priceIDs.AddRange(revision.AtticSubmissionInfo.SelectMany(x => x.AtticPropertyAsessments.SelectMany(s => s.AtticReqActions.Select(z => z.Action_PricePerUnit_RefID))));
                priceIDs.AddRange(revision.BasementSubmissionInfo.SelectMany(x => x.BasementPropertyAsessments.SelectMany(s => s.BasementReqActions.Select(z => z.Action_PricePerUnit_RefID))));
                priceIDs.AddRange(revision.FacadeSubmissionInfo.SelectMany(x => x.FacadePropertyAsessments.SelectMany(s => s.FacadeReqActions.Select(z => z.Action_PricePerUnit_RefID))));
                priceIDs.AddRange(revision.HVACRSubmissionInfo.SelectMany(x => x.HVACRPropertyAsessments.SelectMany(s => s.HVACRReqActions.Select(z => z.Action_PricePerUnit_RefID))));
                priceIDs.AddRange(revision.OutdoorFascilitySubmissionInfo.SelectMany(x => x.OutdoorFacilityAsessments.SelectMany(s => s.OutdoorFacilityReqActions.Select(z => z.Action_PricePerUnit_RefID))));
                priceIDs.AddRange(revision.RoofSubmissionInfo.SelectMany(x => x.RoofPropertyAsessments.SelectMany(s => s.RoofReqActions.Select(z => z.Action_PricePerUnit_RefID))));
                priceIDs.AddRange(revision.StaircaseSubmissionInfo.SelectMany(x => x.StaircasePropertyAsessments.SelectMany(s => s.StaircaseReqActions.Select(z => z.Action_PricePerUnit_RefID))));

                priceIDs.AddRange(revision.ApartmentSubmissionInfo.SelectMany(x => x.ApartmentPropertyAsessments.SelectMany(s => s.ApartmentReqActions.Select(z => z.EffectivePrice_RefID))));
                priceIDs.AddRange(revision.AtticSubmissionInfo.SelectMany(x => x.AtticPropertyAsessments.SelectMany(s => s.AtticReqActions.Select(z => z.EffectivePrice_RefID))));
                priceIDs.AddRange(revision.BasementSubmissionInfo.SelectMany(x => x.BasementPropertyAsessments.SelectMany(s => s.BasementReqActions.Select(z => z.EffectivePrice_RefID))));
                priceIDs.AddRange(revision.FacadeSubmissionInfo.SelectMany(x => x.FacadePropertyAsessments.SelectMany(s => s.FacadeReqActions.Select(z => z.EffectivePrice_RefID))));
                priceIDs.AddRange(revision.HVACRSubmissionInfo.SelectMany(x => x.HVACRPropertyAsessments.SelectMany(s => s.HVACRReqActions.Select(z => z.EffectivePrice_RefID))));
                priceIDs.AddRange(revision.OutdoorFascilitySubmissionInfo.SelectMany(x => x.OutdoorFacilityAsessments.SelectMany(s => s.OutdoorFacilityReqActions.Select(z => z.EffectivePrice_RefID))));
                priceIDs.AddRange(revision.RoofSubmissionInfo.SelectMany(x => x.RoofPropertyAsessments.SelectMany(s => s.RoofReqActions.Select(z => z.EffectivePrice_RefID))));
                priceIDs.AddRange(revision.StaircaseSubmissionInfo.SelectMany(x => x.StaircasePropertyAsessments.SelectMany(s => s.StaircaseReqActions.Select(z => z.EffectivePrice_RefID))));


                //docHeaderIDs.Concat(revison.BuildingInfo.BuildingDocuments.Select(x => x.Building_DocumentationStructure_RefID));
            }


            var docHeaders = new List<L3DO_GDfDH_1133>();

            foreach (var docHeaderID in docHeaderIDs)
            {
                if (docHeaderID == Guid.Empty)
                    continue;
                var documentRevisions = cls_Get_Documents_for_DHeaderID.Invoke(Connection, Transaction, new P_L3DO_GDfDH_1133()
                {
                    DHeaderID = docHeaderID
                }, securityTicket).Result;
                if (documentRevisions == null || documentRevisions.Count() == 0)
                    continue;               
           
                docHeaders.AddRange(documentRevisions);
            }
            returnValue.Result.Images = docHeaders.ToArray();
            #endregion

            #region Retrieve Prices
            var dbPrices = new List<L2PR_GPIfP_1135>();
            foreach (var priceID in priceIDs)
            {
                if (priceID == Guid.Empty)
                    continue;
                var priceValue = cls_Get_PriceInformation_For_PriceID.Invoke(Connection, Transaction, new P_L2PR_GPIfP_1135()
                {
                    PriceID = priceID
                }, securityTicket).Result;
                if (priceValue == null)
                    continue;
                dbPrices.Add(priceValue);
                //Find EU

                //if (string.Equals(priceValue.ISO4127, "EUR", StringComparison.OrdinalIgnoreCase))
                //    {
                //        dbPrices.Add(priceValue);
                //        break;
                //    }
                //    else
                //    {
                //        dbPrices.Add(priceValue);
                //        break;
                //    }

            }
            returnValue.Result.Prices = dbPrices.ToArray();

            #endregion

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DD_RGD_1503 Invoke(string ConnectionString,P_L6DD_RGD_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DD_RGD_1503 Invoke(DbConnection Connection,P_L6DD_RGD_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DD_RGD_1503 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DD_RGD_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DD_RGD_1503 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DD_RGD_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DD_RGD_1503 functionReturn = new FR_L6DD_RGD_1503();
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

				throw new Exception("Exception occured in method cls_Get_RevisionGroupDetails",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DD_RGD_1503 : FR_Base
	{
		public L6DD_RGD_1503 Result	{ get; set; }

		public FR_L6DD_RGD_1503() : base() {}

		public FR_L6DD_RGD_1503(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DD_RGD_1503 for attribute P_L6DD_RGD_1503
		[DataContract]
		public class P_L6DD_RGD_1503 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionGroupID { get; set; } 

		}
		#endregion
		#region SClass L6DD_RGD_1503 for attribute L6DD_RGD_1503
		[DataContract]
		public class L6DD_RGD_1503 
		{
			[DataMember]
			public Revisions[] Revisions { get; set; }

			//Standard type parameters
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public Guid SubmittedByAccount { get; set; } 
			[DataMember]
			public String SubmittedByAccount_FirstName { get; set; } 
			[DataMember]
			public String SubmittedByAccount_LastName { get; set; } 
			[DataMember]
			public String Currency { get; set; } 
			[DataMember]
			public DateTime CreationTimestamp { get; set; } 
			[DataMember]
			public Guid RevisionGroupID { get; set; } 
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
			[DataMember]
			public L3DO_GDfDH_1133[] Images { get; set; } 
			[DataMember]
			public L2PR_GPIfP_1135[] Prices { get; set; } 

		}
		#endregion
		#region SClass Revisions for attribute Revisions
		[DataContract]
		public class Revisions 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionID { get; set; } 
			[DataMember]
			public Guid QuestionnaireVersionID { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public DateTime CreationTimestamp { get; set; } 
			[DataMember]
			public L5BL_GBIfBI_1159 Building { get; set; } 
			[DataMember]
			public L5DD_GASIfRID_1007[] ApartmentSubmissionInfo { get; set; } 
			[DataMember]
			public L5DD_GATTSIFRID_1411[] AtticSubmissionInfo { get; set; } 
			[DataMember]
			public L5DD_GBSIfRID_1431[] BasementSubmissionInfo { get; set; } 
			[DataMember]
			public L5DD_GOFSIfRID_1454[] OutdoorFascilitySubmissionInfo { get; set; } 
			[DataMember]
			public L5DD_GRSIfRID_1213[] RoofSubmissionInfo { get; set; } 
			[DataMember]
			public L5DD_GHSIfRID_1448[] HVACRSubmissionInfo { get; set; } 
			[DataMember]
			public L5DD_GASIfRID_1507[] StaircaseSubmissionInfo { get; set; } 
			[DataMember]
			public L5DD_GFSIfRID_1438[] FacadeSubmissionInfo { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DD_RGD_1503 cls_Get_RevisionGroupDetails(,P_L6DD_RGD_1503 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DD_RGD_1503 invocationResult = cls_Get_RevisionGroupDetails.Invoke(connectionString,P_L6DD_RGD_1503 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_DueDiligences.Complex.Retrieval.P_L6DD_RGD_1503();
parameter.RevisionGroupID = ...;

*/