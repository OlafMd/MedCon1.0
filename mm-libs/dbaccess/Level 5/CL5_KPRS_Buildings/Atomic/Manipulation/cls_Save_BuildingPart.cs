/* 
 * Generated on 11/6/2013 10:58:02 AM
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
using CL1_RES_BLD;
using CL1_RES_STR;
using CL1_DOC;
using CL1_RES_ACT;
using CL1_CMN;

namespace CL5_KPRS_Buildings.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_BuildingPart.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_BuildingPart
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BD_SBP_1620 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_SBP_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5BD_SBP_1620();

            returnValue.Result = new L5BD_SBP_1620();
            returnValue.Result.BuildingPropertyDocumentHeaders = new Dictionary<Guid, Guid>();

            if (Parameter.BuildingPartType == "Apartment")
            {
                #region Apartment

                ORM_RES_BLD_Apartment buildingPart = new ORM_RES_BLD_Apartment();
                if (Parameter.BuildingPartID != Guid.Empty)
                {
                    var result = buildingPart.Load(Connection, Transaction, Parameter.BuildingPartID);
                    if (result.Status != FR_Status.Success || buildingPart.RES_BLD_ApartmentID == Guid.Empty)
                    {
                        var error = new FR_L5BD_SBP_1620();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    buildingPart.ApartmentSize_Unit_RefID = Parameter.AppartmentUnitRefID;
                    buildingPart.ApartmentSize_Value = Parameter.AparementSize;
                    buildingPart.IsAppartment_ForRent = Parameter.IsApartmentForRent;
                    buildingPart.TypeOfFlooring_RefID = Parameter.Appartment_FlooringType;
                    buildingPart.TypeOfHeating_RefID = Parameter.Appartment_HeatingType;
                    buildingPart.TypeOfWallCovering_RefID = Parameter.Appartment_WallCoveringType;
                    buildingPart.Save(Connection, Transaction);
                }


                ORM_RES_STR_Apartment.Query buildingPartStrQuery = new ORM_RES_STR_Apartment.Query();
                buildingPartStrQuery.DUD_Revision_RefID = Parameter.RevisionID;
                buildingPartStrQuery.Tenant_RefID = securityTicket.TenantID;
                buildingPartStrQuery.RES_BLD_Apartment_RefID = Parameter.BuildingPartID;
                List<ORM_RES_STR_Apartment> buildingPartStrList = ORM_RES_STR_Apartment.Query.Search(Connection, Transaction, buildingPartStrQuery);
                ORM_RES_STR_Apartment buildingPartStr;
                if (buildingPartStrList.Count != 0)
                {
                    buildingPartStr = buildingPartStrList[0];
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.Save(Connection, Transaction);
                }
                else
                {
                    ORM_DOC_Structure_Header doc_header = new ORM_DOC_Structure_Header();
                    doc_header.Tenant_RefID = securityTicket.TenantID;

                    ORM_DOC_Structure doc_structure = new ORM_DOC_Structure();
                    doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                    doc_structure.Structure_Header_RefID = doc_header.DOC_Structure_HeaderID;
                    doc_structure.Tenant_RefID = securityTicket.TenantID;
                    doc_structure.Save(Connection, Transaction);

                    doc_header.DocumentStructureRoot_RefID = doc_structure.DOC_StructureID;
                    doc_header.Save(Connection, Transaction);

                    buildingPartStr = new ORM_RES_STR_Apartment();
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.DocumentHeader_RefID = doc_header.DOC_Structure_HeaderID;
                    buildingPartStr.RES_BLD_Apartment_RefID = Parameter.BuildingPartID;
                    buildingPartStr.Tenant_RefID = securityTicket.TenantID;
                    buildingPartStr.DUD_Revision_RefID = Parameter.RevisionID;
                    buildingPartStr.Save(Connection, Transaction);
                }
                foreach (var question in Parameter.Questions)
                {
                    ORM_RES_STR_Apartment_PropertyAssessment.Query buildingPartAssessmentQuery = new ORM_RES_STR_Apartment_PropertyAssessment.Query();
                    buildingPartAssessmentQuery.ApartmentProperty_RefID = question.QuestionID;
                    buildingPartAssessmentQuery.STR_Apartment_RefID = buildingPartStr.RES_STR_ApartmentID;
                    List<ORM_RES_STR_Apartment_PropertyAssessment> buildingPartAssessmentList = ORM_RES_STR_Apartment_PropertyAssessment.Query.Search(Connection, Transaction, buildingPartAssessmentQuery);
                    ORM_RES_STR_Apartment_PropertyAssessment buildingPartAssessment = new ORM_RES_STR_Apartment_PropertyAssessment();
                    if (buildingPartAssessmentList.Count != 0)
                    {
                        buildingPartAssessment = buildingPartAssessmentList[0];
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.Save(Connection, Transaction);

                        foreach (var assessment in buildingPartAssessmentList)
                        {
                            returnValue.Result.BuildingPropertyDocumentHeaders.Add(assessment.ApartmentProperty_RefID, assessment.DocumentHeader_RefID);
                        }

                    }
                    else
                    {
                        ORM_DOC_Structure_Header assessment_doc_header = new ORM_DOC_Structure_Header();
                        assessment_doc_header.Tenant_RefID = securityTicket.TenantID;

                        ORM_DOC_Structure assessment_doc_structure = new ORM_DOC_Structure();
                        assessment_doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                        assessment_doc_structure.Structure_Header_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        assessment_doc_structure.Tenant_RefID = securityTicket.TenantID;
                        assessment_doc_structure.Save(Connection, Transaction);

                        assessment_doc_header.DocumentStructureRoot_RefID = assessment_doc_structure.DOC_StructureID;
                        assessment_doc_header.Save(Connection, Transaction);

                        buildingPartAssessment = new ORM_RES_STR_Apartment_PropertyAssessment();
                        buildingPartAssessment.ApartmentProperty_RefID = question.QuestionID;
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.DocumentHeader_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.STR_Apartment_RefID = buildingPartStr.RES_STR_ApartmentID;
                        buildingPartAssessment.Tenant_RefID = securityTicket.TenantID;
                        buildingPartAssessment.Save(Connection, Transaction);

                        returnValue.Result.BuildingPropertyDocumentHeaders.Add(buildingPartAssessment.ApartmentProperty_RefID, buildingPartAssessment.DocumentHeader_RefID);
                    }
                    ORM_RES_STR_Apartment_RequiredAction.Query buildingPartRequieredActionsQuery = new ORM_RES_STR_Apartment_RequiredAction.Query();
                    buildingPartRequieredActionsQuery.ApartmentPropertyAssessment_RefID = buildingPartAssessment.RES_STR_Apartment_PropertyAssessmentID;
                    int count = ORM_RES_STR_Apartment_RequiredAction.Query.SoftDelete(Connection, Transaction, buildingPartRequieredActionsQuery);
                    foreach (var action in question.Actions)
                    {
                        ORM_RES_ACT_Action_Version version = new ORM_RES_ACT_Action_Version();
                        version.Load(Connection, Transaction, action.ActionVersionID);

                        ORM_CMN_Price_Value.Query priceQuery = new ORM_CMN_Price_Value.Query();
                        priceQuery.IsDeleted = false;
                        priceQuery.Price_RefID = version.Default_PricePerUnit_RefID;
                        priceQuery.Tenant_RefID = securityTicket.TenantID;
                        ORM_CMN_Price_Value priceValue = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceQuery).FirstOrDefault();
                        ORM_CMN_Price_Value.Query.SoftDelete(Connection, Transaction, priceQuery); ;

                        ORM_CMN_Price newPricePerUnit = new ORM_CMN_Price();
                        newPricePerUnit.Tenant_RefID = securityTicket.TenantID;
                        newPricePerUnit.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newPriceValue = new ORM_CMN_Price_Value();

                        newPriceValue.PriceValue_Amount = action.CostPerUnit;
                        newPriceValue.Price_RefID = newPricePerUnit.CMN_PriceID;
                        newPriceValue.Tenant_RefID = securityTicket.TenantID;
                        newPriceValue.Save(Connection, Transaction);

                        ORM_CMN_Price newEffectivePrice = new ORM_CMN_Price();
                        newEffectivePrice.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePrice.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newEffectivePriceValue = new ORM_CMN_Price_Value();

                        newEffectivePriceValue.PriceValue_Amount = action.CostPerUnit;
                        newEffectivePriceValue.Price_RefID = newEffectivePrice.CMN_PriceID;
                        newEffectivePriceValue.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePriceValue.Save(Connection, Transaction);

                        ORM_RES_STR_Apartment_RequiredAction buildingPartRequieredAction = new ORM_RES_STR_Apartment_RequiredAction();
                        buildingPartRequieredAction.SelectedActionVersion_RefID = action.ActionVersionID;
                        buildingPartRequieredAction.Action_UnitAmount = action.Amount;
                        buildingPartRequieredAction.Action_Timeframe_RefID = action.TimeFrameID;
                        buildingPartRequieredAction.Tenant_RefID = securityTicket.TenantID;
                        buildingPartRequieredAction.EffectivePrice_RefID = newEffectivePrice.CMN_PriceID;
                        buildingPartRequieredAction.Action_PricePerUnit_RefID = newPricePerUnit.CMN_PriceID;
                        buildingPartRequieredAction.Action_Unit_RefID = action.UnitRefID;
                        buildingPartRequieredAction.Comment = action.Comment;
                        buildingPartRequieredAction.ApartmentPropertyAssessment_RefID = buildingPartAssessment.RES_STR_Apartment_PropertyAssessmentID;
                        buildingPartRequieredAction.Save(Connection, Transaction);
                    }
                }
                returnValue.Result.BuildingPartDocumentHeader = buildingPartStr.DocumentHeader_RefID;

                #endregion
            }
            else if (Parameter.BuildingPartType == "Attic")
            {

                #region Attic

                ORM_RES_STR_Attic.Query buildingPartStrQuery = new ORM_RES_STR_Attic.Query();
                buildingPartStrQuery.DUD_Revision_RefID = Parameter.RevisionID;
                buildingPartStrQuery.Tenant_RefID = securityTicket.TenantID;
                buildingPartStrQuery.RES_BLD_Attic_RefID = Parameter.BuildingPartID;
                List<ORM_RES_STR_Attic> buildingPartStrList = ORM_RES_STR_Attic.Query.Search(Connection, Transaction, buildingPartStrQuery);
                ORM_RES_STR_Attic buildingPartStr;
                if (buildingPartStrList.Count != 0)
                {
                    buildingPartStr = buildingPartStrList[0];
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.Save(Connection, Transaction);
                }
                else
                {
                    ORM_DOC_Structure_Header doc_header = new ORM_DOC_Structure_Header();
                    doc_header.Tenant_RefID = securityTicket.TenantID;

                    ORM_DOC_Structure doc_structure = new ORM_DOC_Structure();
                    doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                    doc_structure.Structure_Header_RefID = doc_header.DOC_Structure_HeaderID;
                    doc_structure.Tenant_RefID = securityTicket.TenantID;
                    doc_structure.Save(Connection, Transaction);

                    doc_header.DocumentStructureRoot_RefID = doc_structure.DOC_StructureID;
                    doc_header.Save(Connection, Transaction);

                    buildingPartStr = new ORM_RES_STR_Attic();
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.DocumentHeader_RefID = doc_header.DOC_Structure_HeaderID;
                    buildingPartStr.RES_BLD_Attic_RefID = Parameter.BuildingPartID;
                    buildingPartStr.Tenant_RefID = securityTicket.TenantID;
                    buildingPartStr.DUD_Revision_RefID = Parameter.RevisionID;
                    buildingPartStr.Save(Connection, Transaction);
                }
                foreach (var question in Parameter.Questions)
                {
                    ORM_RES_STR_Attic_PropertyAssessment.Query buildingPartAssessmentQuery = new ORM_RES_STR_Attic_PropertyAssessment.Query();
                    buildingPartAssessmentQuery.AtticProperty_RefID = question.QuestionID;
                    buildingPartAssessmentQuery.STR_Attic_RefID = buildingPartStr.RES_STR_AtticID;
                    List<ORM_RES_STR_Attic_PropertyAssessment> buildingPartAssessmentList = ORM_RES_STR_Attic_PropertyAssessment.Query.Search(Connection, Transaction, buildingPartAssessmentQuery);
                    ORM_RES_STR_Attic_PropertyAssessment buildingPartAssessment = new ORM_RES_STR_Attic_PropertyAssessment();
                    if (buildingPartAssessmentList.Count != 0)
                    {
                        buildingPartAssessment = buildingPartAssessmentList[0];
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.Save(Connection, Transaction);

                        foreach (var assessment in buildingPartAssessmentList)
                        {
                            returnValue.Result.BuildingPropertyDocumentHeaders.Add(assessment.AtticProperty_RefID, assessment.DocumentHeader_RefID);
                        }

                    }
                    else
                    {
                        ORM_DOC_Structure_Header assessment_doc_header = new ORM_DOC_Structure_Header();
                        assessment_doc_header.Tenant_RefID = securityTicket.TenantID;

                        ORM_DOC_Structure assessment_doc_structure = new ORM_DOC_Structure();
                        assessment_doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                        assessment_doc_structure.Structure_Header_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        assessment_doc_structure.Tenant_RefID = securityTicket.TenantID;
                        assessment_doc_structure.Save(Connection, Transaction);

                        assessment_doc_header.DocumentStructureRoot_RefID = assessment_doc_structure.DOC_StructureID;
                        assessment_doc_header.Save(Connection, Transaction);

                        buildingPartAssessment = new ORM_RES_STR_Attic_PropertyAssessment();
                        buildingPartAssessment.AtticProperty_RefID = question.QuestionID;
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.DocumentHeader_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.STR_Attic_RefID = buildingPartStr.RES_STR_AtticID;
                        buildingPartAssessment.Tenant_RefID = securityTicket.TenantID;
                        buildingPartAssessment.Save(Connection, Transaction);

                        returnValue.Result.BuildingPropertyDocumentHeaders.Add(buildingPartAssessment.AtticProperty_RefID, buildingPartAssessment.DocumentHeader_RefID);

                    }
                    ORM_RES_STR_Attic_RequiredAction.Query buildingPartRequieredActionsQuery = new ORM_RES_STR_Attic_RequiredAction.Query();
                    buildingPartRequieredActionsQuery.AtticPropertyAssestment_RefID = buildingPartAssessment.RES_STR_Attic_PropertyAssessmentID;
                    int count = ORM_RES_STR_Attic_RequiredAction.Query.SoftDelete(Connection, Transaction, buildingPartRequieredActionsQuery);
                    foreach (var action in question.Actions)
                    {

                        ORM_RES_ACT_Action_Version version = new ORM_RES_ACT_Action_Version();
                        version.Load(Connection, Transaction, action.ActionVersionID);

                        ORM_CMN_Price_Value.Query priceQuery = new ORM_CMN_Price_Value.Query();
                        priceQuery.IsDeleted = false;
                        priceQuery.Price_RefID = version.Default_PricePerUnit_RefID;
                        priceQuery.Tenant_RefID = securityTicket.TenantID;
                        ORM_CMN_Price_Value priceValue = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceQuery).FirstOrDefault();

                        ORM_CMN_Price newPricePerUnit = new ORM_CMN_Price();
                        newPricePerUnit.Tenant_RefID = securityTicket.TenantID;
                        newPricePerUnit.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newPriceValue = new ORM_CMN_Price_Value();

                        newPriceValue.PriceValue_Amount = action.CostPerUnit;
                        newPriceValue.Price_RefID = newPricePerUnit.CMN_PriceID;
                        newPriceValue.Tenant_RefID = securityTicket.TenantID;
                        newPriceValue.Save(Connection, Transaction);

                        ORM_CMN_Price newEffectivePrice = new ORM_CMN_Price();
                        newEffectivePrice.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePrice.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newEffectivePriceValue = new ORM_CMN_Price_Value();

                        newEffectivePriceValue.PriceValue_Amount = action.CostPerUnit;
                        newEffectivePriceValue.Price_RefID = newEffectivePrice.CMN_PriceID;
                        newEffectivePriceValue.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePriceValue.Save(Connection, Transaction);

                        ORM_RES_STR_Attic_RequiredAction buildingPartRequieredAction = new ORM_RES_STR_Attic_RequiredAction();
                        buildingPartRequieredAction.SelectedActionVersion_RefID = action.ActionVersionID;
                        buildingPartRequieredAction.Action_UnitAmount = action.Amount;
                        buildingPartRequieredAction.Action_Timeframe_RefID = action.TimeFrameID;
                        buildingPartRequieredAction.Tenant_RefID = securityTicket.TenantID;
                        buildingPartRequieredAction.EffectivePrice_RefID = newEffectivePrice.CMN_PriceID;
                        buildingPartRequieredAction.Action_PricePerUnit_RefID = newPricePerUnit.CMN_PriceID;
                        buildingPartRequieredAction.Action_Unit_RefID = action.UnitRefID;
                        buildingPartRequieredAction.Comment = action.Comment;
                        buildingPartRequieredAction.AtticPropertyAssestment_RefID = buildingPartAssessment.RES_STR_Attic_PropertyAssessmentID;
                        buildingPartRequieredAction.Save(Connection, Transaction);
                    }
                }
                returnValue.Result.BuildingPartDocumentHeader = buildingPartStr.DocumentHeader_RefID;

                #endregion
            }
            else if (Parameter.BuildingPartType == "Outdoor")
            {

                #region Outdoor
                ORM_RES_BLD_OutdoorFacility buildingPart = new ORM_RES_BLD_OutdoorFacility();
                if (Parameter.BuildingPartID != Guid.Empty)
                {
                    var result = buildingPart.Load(Connection, Transaction, Parameter.BuildingPartID);
                    if (result.Status != FR_Status.Success || buildingPart.RES_BLD_OutdoorFacilityID == Guid.Empty)
                    {
                        var error = new FR_L5BD_SBP_1620();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    buildingPart.NumberOfGaragePlaces = Parameter.OutdoorNumberOfGaragePlaces;
                    buildingPart.NumberOfRentedGaragePlaces = Parameter.OutdoorNumberOfRentedGaragePlaces;
                    buildingPart.TypeOfAccessRoad_RefID = Parameter.OutdoorFacility_AccessRoadType;
                    buildingPart.TypeOfFence_RefID = Parameter.OutdoorFacility_FenceType;
                    buildingPart.Save(Connection, Transaction);
                }

                ORM_RES_STR_OutdoorFacility.Query buildingPartStrQuery = new ORM_RES_STR_OutdoorFacility.Query();
                buildingPartStrQuery.DUD_Revision_RefID = Parameter.RevisionID;
                buildingPartStrQuery.Tenant_RefID = securityTicket.TenantID;
                buildingPartStrQuery.RES_BLD_OutdoorFacility_RefID = Parameter.BuildingPartID;
                List<ORM_RES_STR_OutdoorFacility> buildingPartStrList = ORM_RES_STR_OutdoorFacility.Query.Search(Connection, Transaction, buildingPartStrQuery);
                ORM_RES_STR_OutdoorFacility buildingPartStr;
                if (buildingPartStrList.Count != 0)
                {
                    buildingPartStr = buildingPartStrList[0];
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.Save(Connection, Transaction);
                }
                else
                {
                    ORM_DOC_Structure_Header doc_header = new ORM_DOC_Structure_Header();
                    doc_header.Tenant_RefID = securityTicket.TenantID;

                    ORM_DOC_Structure doc_structure = new ORM_DOC_Structure();
                    doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                    doc_structure.Structure_Header_RefID = doc_header.DOC_Structure_HeaderID;
                    doc_structure.Tenant_RefID = securityTicket.TenantID;
                    doc_structure.Save(Connection, Transaction);

                    doc_header.DocumentStructureRoot_RefID = doc_structure.DOC_StructureID;
                    doc_header.Save(Connection, Transaction);

                    buildingPartStr = new ORM_RES_STR_OutdoorFacility();
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.DocumentHeader_RefID = doc_header.DOC_Structure_HeaderID;
                    buildingPartStr.RES_BLD_OutdoorFacility_RefID = Parameter.BuildingPartID;
                    buildingPartStr.Tenant_RefID = securityTicket.TenantID;
                    buildingPartStr.DUD_Revision_RefID = Parameter.RevisionID;
                    buildingPartStr.Save(Connection, Transaction);
                }
                foreach (var question in Parameter.Questions)
                {
                    ORM_RES_STR_OutdoorFacility_PropertyAssessment.Query buildingPartAssessmentQuery = new ORM_RES_STR_OutdoorFacility_PropertyAssessment.Query();
                    buildingPartAssessmentQuery.OutdoorFacilityProperty_RefID = question.QuestionID;
                    buildingPartAssessmentQuery.STR_OutdoorFacility_RefID = buildingPartStr.RES_STR_OutdoorFacilityID;
                    List<ORM_RES_STR_OutdoorFacility_PropertyAssessment> buildingPartAssessmentList = ORM_RES_STR_OutdoorFacility_PropertyAssessment.Query.Search(Connection, Transaction, buildingPartAssessmentQuery);
                    ORM_RES_STR_OutdoorFacility_PropertyAssessment buildingPartAssessment = new ORM_RES_STR_OutdoorFacility_PropertyAssessment();
                    if (buildingPartAssessmentList.Count != 0)
                    {
                        buildingPartAssessment = buildingPartAssessmentList[0];
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.Save(Connection, Transaction);

                        foreach (var assessment in buildingPartAssessmentList)
                        {
                            returnValue.Result.BuildingPropertyDocumentHeaders.Add(assessment.OutdoorFacilityProperty_RefID, assessment.DocumentHeader_RefID);
                        }

                    }
                    else
                    {
                        ORM_DOC_Structure_Header assessment_doc_header = new ORM_DOC_Structure_Header();
                        assessment_doc_header.Tenant_RefID = securityTicket.TenantID;

                        ORM_DOC_Structure assessment_doc_structure = new ORM_DOC_Structure();
                        assessment_doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                        assessment_doc_structure.Structure_Header_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        assessment_doc_structure.Tenant_RefID = securityTicket.TenantID;
                        assessment_doc_structure.Save(Connection, Transaction);

                        assessment_doc_header.DocumentStructureRoot_RefID = assessment_doc_structure.DOC_StructureID;
                        assessment_doc_header.Save(Connection, Transaction);

                        buildingPartAssessment = new ORM_RES_STR_OutdoorFacility_PropertyAssessment();
                        buildingPartAssessment.OutdoorFacilityProperty_RefID = question.QuestionID;
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.DocumentHeader_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.STR_OutdoorFacility_RefID = buildingPartStr.RES_STR_OutdoorFacilityID;
                        buildingPartAssessment.Tenant_RefID = securityTicket.TenantID;
                        buildingPartAssessment.Save(Connection, Transaction);

                        returnValue.Result.BuildingPropertyDocumentHeaders.Add(buildingPartAssessment.OutdoorFacilityProperty_RefID, buildingPartAssessment.DocumentHeader_RefID);

                    }
                    ORM_RES_STR_OutdoorFacility_RequiredAction.Query buildingPartRequieredActionsQuery = new ORM_RES_STR_OutdoorFacility_RequiredAction.Query();
                    buildingPartRequieredActionsQuery.OutdoorFacilityPropertyAssestment_RefID = buildingPartAssessment.RES_STR_OutdoorFacility_PropertyAssessmentID;
                    int count = ORM_RES_STR_OutdoorFacility_RequiredAction.Query.SoftDelete(Connection, Transaction, buildingPartRequieredActionsQuery);
                    foreach (var action in question.Actions)
                    {
                        ORM_RES_ACT_Action_Version version = new ORM_RES_ACT_Action_Version();
                        version.Load(Connection, Transaction, action.ActionVersionID);

                        ORM_CMN_Price_Value.Query priceQuery = new ORM_CMN_Price_Value.Query();
                        priceQuery.IsDeleted = false;
                        priceQuery.Price_RefID = version.Default_PricePerUnit_RefID;
                        priceQuery.Tenant_RefID = securityTicket.TenantID;
                        ORM_CMN_Price_Value priceValue = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceQuery).FirstOrDefault();

                        ORM_CMN_Price newPricePerUnit = new ORM_CMN_Price();
                        newPricePerUnit.Tenant_RefID = securityTicket.TenantID;
                        newPricePerUnit.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newPriceValue = new ORM_CMN_Price_Value();

                        newPriceValue.PriceValue_Amount = action.CostPerUnit;
                        newPriceValue.Price_RefID = newPricePerUnit.CMN_PriceID;
                        newPriceValue.Tenant_RefID = securityTicket.TenantID;
                        newPriceValue.Save(Connection, Transaction);

                        ORM_CMN_Price newEffectivePrice = new ORM_CMN_Price();
                        newEffectivePrice.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePrice.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newEffectivePriceValue = new ORM_CMN_Price_Value();

                        newEffectivePriceValue.PriceValue_Amount = action.CostPerUnit;
                        newEffectivePriceValue.Price_RefID = newEffectivePrice.CMN_PriceID;
                        newEffectivePriceValue.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePriceValue.Save(Connection, Transaction);

                        ORM_RES_STR_OutdoorFacility_RequiredAction buildingPartRequieredAction = new ORM_RES_STR_OutdoorFacility_RequiredAction();
                        buildingPartRequieredAction.SelectedActionVersion_RefID = action.ActionVersionID;
                        buildingPartRequieredAction.Action_UnitAmount = action.Amount;
                        buildingPartRequieredAction.Action_Timeframe_RefID = action.TimeFrameID;
                        buildingPartRequieredAction.Tenant_RefID = securityTicket.TenantID;
                        buildingPartRequieredAction.EffectivePrice_RefID = newEffectivePrice.CMN_PriceID;
                        buildingPartRequieredAction.Action_PricePerUnit_RefID = newPricePerUnit.CMN_PriceID;
                        buildingPartRequieredAction.Action_Unit_RefID = action.UnitRefID;
                        buildingPartRequieredAction.Comment = action.Comment;
                        buildingPartRequieredAction.OutdoorFacilityPropertyAssestment_RefID = buildingPartAssessment.RES_STR_OutdoorFacility_PropertyAssessmentID;
                        buildingPartRequieredAction.Save(Connection, Transaction);
                    }
                }
                returnValue.Result.BuildingPartDocumentHeader = buildingPartStr.DocumentHeader_RefID;

                #endregion

            }
            else if (Parameter.BuildingPartType == "Facade")
            {

                #region Facade

                ORM_RES_STR_Facade.Query buildingPartStrQuery = new ORM_RES_STR_Facade.Query();
                buildingPartStrQuery.DUD_Revision_RefID = Parameter.RevisionID;
                buildingPartStrQuery.Tenant_RefID = securityTicket.TenantID;
                buildingPartStrQuery.RES_BLD_Facade_RefID = Parameter.BuildingPartID;
                List<ORM_RES_STR_Facade> buildingPartStrList = ORM_RES_STR_Facade.Query.Search(Connection, Transaction, buildingPartStrQuery);
                ORM_RES_STR_Facade buildingPartStr;
                if (buildingPartStrList.Count != 0)
                {
                    buildingPartStr = buildingPartStrList[0];
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.Save(Connection, Transaction);
                }
                else
                {
                    ORM_DOC_Structure_Header doc_header = new ORM_DOC_Structure_Header();
                    doc_header.Tenant_RefID = securityTicket.TenantID;

                    ORM_DOC_Structure doc_structure = new ORM_DOC_Structure();
                    doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                    doc_structure.Structure_Header_RefID = doc_header.DOC_Structure_HeaderID;
                    doc_structure.Tenant_RefID = securityTicket.TenantID;
                    doc_structure.Save(Connection, Transaction);

                    doc_header.DocumentStructureRoot_RefID = doc_structure.DOC_StructureID;
                    doc_header.Save(Connection, Transaction);

                    buildingPartStr = new ORM_RES_STR_Facade();
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.DocumentHeader_RefID = doc_header.DOC_Structure_HeaderID;
                    buildingPartStr.RES_BLD_Facade_RefID = Parameter.BuildingPartID;
                    buildingPartStr.Tenant_RefID = securityTicket.TenantID;
                    buildingPartStr.DUD_Revision_RefID = Parameter.RevisionID;
                    buildingPartStr.Save(Connection, Transaction);
                }
                foreach (var question in Parameter.Questions)
                {
                    ORM_RES_STR_Facade_PropertyAssessment.Query buildingPartAssessmentQuery = new ORM_RES_STR_Facade_PropertyAssessment.Query();
                    buildingPartAssessmentQuery.FacadeProperty_RefID = question.QuestionID;
                    buildingPartAssessmentQuery.STR_Facade_RefID = buildingPartStr.RES_STR_FacadeID;
                    List<ORM_RES_STR_Facade_PropertyAssessment> buildingPartAssessmentList = ORM_RES_STR_Facade_PropertyAssessment.Query.Search(Connection, Transaction, buildingPartAssessmentQuery);
                    ORM_RES_STR_Facade_PropertyAssessment buildingPartAssessment = new ORM_RES_STR_Facade_PropertyAssessment();
                    if (buildingPartAssessmentList.Count != 0)
                    {
                        buildingPartAssessment = buildingPartAssessmentList[0];
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.Save(Connection, Transaction);

                        foreach (var assessment in buildingPartAssessmentList)
                        {
                            returnValue.Result.BuildingPropertyDocumentHeaders.Add(assessment.FacadeProperty_RefID, assessment.DocumentHeader_RefID);
                        }

                    }
                    else
                    {
                        ORM_DOC_Structure_Header assessment_doc_header = new ORM_DOC_Structure_Header();
                        assessment_doc_header.Tenant_RefID = securityTicket.TenantID;

                        ORM_DOC_Structure assessment_doc_structure = new ORM_DOC_Structure();
                        assessment_doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                        assessment_doc_structure.Structure_Header_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        assessment_doc_structure.Tenant_RefID = securityTicket.TenantID;
                        assessment_doc_structure.Save(Connection, Transaction);

                        assessment_doc_header.DocumentStructureRoot_RefID = assessment_doc_structure.DOC_StructureID;
                        assessment_doc_header.Save(Connection, Transaction);

                        buildingPartAssessment = new ORM_RES_STR_Facade_PropertyAssessment();
                        buildingPartAssessment.FacadeProperty_RefID = question.QuestionID;
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.DocumentHeader_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.STR_Facade_RefID = buildingPartStr.RES_STR_FacadeID;
                        buildingPartAssessment.Tenant_RefID = securityTicket.TenantID;
                        buildingPartAssessment.Save(Connection, Transaction);

                        returnValue.Result.BuildingPropertyDocumentHeaders.Add(buildingPartAssessment.FacadeProperty_RefID, buildingPartAssessment.DocumentHeader_RefID);

                    }
                    ORM_RES_STR_Facade_RequiredAction.Query buildingPartRequieredActionsQuery = new ORM_RES_STR_Facade_RequiredAction.Query();
                    buildingPartRequieredActionsQuery.FacadePropertyAssestment_RefID = buildingPartAssessment.RES_STR_Facade_PropertyAssessmentID;
                    int count = ORM_RES_STR_Facade_RequiredAction.Query.SoftDelete(Connection, Transaction, buildingPartRequieredActionsQuery);
                    foreach (var action in question.Actions)
                    {

                        ORM_RES_ACT_Action_Version version = new ORM_RES_ACT_Action_Version();
                        version.Load(Connection, Transaction, action.ActionVersionID);

                        ORM_CMN_Price_Value.Query priceQuery = new ORM_CMN_Price_Value.Query();
                        priceQuery.IsDeleted = false;
                        priceQuery.Price_RefID = version.Default_PricePerUnit_RefID;
                        priceQuery.Tenant_RefID = securityTicket.TenantID;
                        ORM_CMN_Price_Value priceValue = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceQuery).FirstOrDefault();
                        ORM_CMN_Price_Value.Query.SoftDelete(Connection, Transaction, priceQuery); ;

                        ORM_CMN_Price newPricePerUnit = new ORM_CMN_Price();
                        newPricePerUnit.Tenant_RefID = securityTicket.TenantID;
                        newPricePerUnit.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newPriceValue = new ORM_CMN_Price_Value();

                        newPriceValue.PriceValue_Amount = action.CostPerUnit;
                        newPriceValue.Price_RefID = newPricePerUnit.CMN_PriceID;
                        newPriceValue.Tenant_RefID = securityTicket.TenantID;
                        newPriceValue.Save(Connection, Transaction);

                        ORM_CMN_Price newEffectivePrice = new ORM_CMN_Price();
                        newEffectivePrice.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePrice.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newEffectivePriceValue = new ORM_CMN_Price_Value();

                        newEffectivePriceValue.PriceValue_Amount = action.CostPerUnit;
                        newEffectivePriceValue.Price_RefID = newEffectivePrice.CMN_PriceID;
                        newEffectivePriceValue.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePriceValue.Save(Connection, Transaction);

                        ORM_RES_STR_Facade_RequiredAction buildingPartRequieredAction = new ORM_RES_STR_Facade_RequiredAction();
                        buildingPartRequieredAction.SelectedActionVersion_RefID = action.ActionVersionID;
                        buildingPartRequieredAction.Action_UnitAmount = action.Amount;
                        buildingPartRequieredAction.Action_Timeframe_RefID = action.TimeFrameID;
                        buildingPartRequieredAction.Tenant_RefID = securityTicket.TenantID;
                        buildingPartRequieredAction.Action_Unit_RefID = action.UnitRefID;
                        buildingPartRequieredAction.Comment = action.Comment;
                        buildingPartRequieredAction.EffectivePrice_RefID = newEffectivePrice.CMN_PriceID;
                        buildingPartRequieredAction.Action_PricePerUnit_RefID = newPricePerUnit.CMN_PriceID;
                        buildingPartRequieredAction.FacadePropertyAssestment_RefID = buildingPartAssessment.RES_STR_Facade_PropertyAssessmentID;
                        buildingPartRequieredAction.Save(Connection, Transaction);
                    }
                }
                returnValue.Result.BuildingPartDocumentHeader = buildingPartStr.DocumentHeader_RefID;

                #endregion

            }
            else if (Parameter.BuildingPartType == "Roof")
            {

                #region Roof

                if (Parameter.BuildingPartID != Guid.Empty)
                {
                    ORM_RES_BLD_Roof buildingPart = new ORM_RES_BLD_Roof();
                    var result = buildingPart.Load(Connection, Transaction, Parameter.BuildingPartID);
                    if (result.Status != FR_Status.Success || buildingPart.RES_BLD_RoofID == Guid.Empty)
                    {
                        var error = new FR_L5BD_SBP_1620();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }

                    ORM_RES_BLD_Roof_2_RoofType.Query roof_2_TypeQuery = new ORM_RES_BLD_Roof_2_RoofType.Query();
                    roof_2_TypeQuery.Tenant_RefID = securityTicket.TenantID;
                    roof_2_TypeQuery.IsDeleted = false;
                    roof_2_TypeQuery.RES_BLD_Roof_RefID = buildingPart.RES_BLD_RoofID;
                    ORM_RES_BLD_Roof_2_RoofType roof_Type = ORM_RES_BLD_Roof_2_RoofType.Query.Search(Connection, Transaction, roof_2_TypeQuery).FirstOrDefault();

                    if (roof_Type != null)
                    {
                        roof_Type.RES_BLD_Roof_Type_RefID = Parameter.RoofType;
                        roof_Type.Save(Connection, Transaction);
                    }
                    else
                    {
                        roof_Type = new ORM_RES_BLD_Roof_2_RoofType();
                        roof_Type.Tenant_RefID = securityTicket.TenantID;
                        roof_Type.RES_BLD_Roof_Type_RefID = Parameter.RoofType;
                        roof_Type.RES_BLD_Roof_RefID = buildingPart.RES_BLD_RoofID;
                        roof_Type.Save(Connection, Transaction);
                    }
                }
                

                ORM_RES_STR_Roof.Query buildingPartStrQuery = new ORM_RES_STR_Roof.Query();
                buildingPartStrQuery.DUD_Revision_RefID = Parameter.RevisionID;
                buildingPartStrQuery.Tenant_RefID = securityTicket.TenantID;
                buildingPartStrQuery.RES_BLD_Roof_RefID = Parameter.BuildingPartID;
                List<ORM_RES_STR_Roof> buildingPartStrList = ORM_RES_STR_Roof.Query.Search(Connection, Transaction, buildingPartStrQuery);
                ORM_RES_STR_Roof buildingPartStr;
                if (buildingPartStrList.Count != 0)
                {
                    buildingPartStr = buildingPartStrList[0];
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.Save(Connection, Transaction);
                }
                else
                {
                    ORM_DOC_Structure_Header doc_header = new ORM_DOC_Structure_Header();
                    doc_header.Tenant_RefID = securityTicket.TenantID;

                    ORM_DOC_Structure doc_structure = new ORM_DOC_Structure();
                    doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                    doc_structure.Structure_Header_RefID = doc_header.DOC_Structure_HeaderID;
                    doc_structure.Tenant_RefID = securityTicket.TenantID;
                    doc_structure.Save(Connection, Transaction);

                    doc_header.DocumentStructureRoot_RefID = doc_structure.DOC_StructureID;
                    doc_header.Save(Connection, Transaction);

                    buildingPartStr = new ORM_RES_STR_Roof();
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.DocumentHeader_RefID = doc_header.DOC_Structure_HeaderID;
                    buildingPartStr.RES_BLD_Roof_RefID = Parameter.BuildingPartID;
                    buildingPartStr.Tenant_RefID = securityTicket.TenantID;
                    buildingPartStr.DUD_Revision_RefID = Parameter.RevisionID;
                    buildingPartStr.Save(Connection, Transaction);
                }
                foreach (var question in Parameter.Questions)
                {
                    ORM_RES_STR_Roof_PropertyAssessment.Query buildingPartAssessmentQuery = new ORM_RES_STR_Roof_PropertyAssessment.Query();
                    buildingPartAssessmentQuery.RoofProperty_RefID = question.QuestionID;
                    buildingPartAssessmentQuery.STR_Roof_RefID = buildingPartStr.RES_STR_RoofID;
                    List<ORM_RES_STR_Roof_PropertyAssessment> buildingPartAssessmentList = ORM_RES_STR_Roof_PropertyAssessment.Query.Search(Connection, Transaction, buildingPartAssessmentQuery);
                    ORM_RES_STR_Roof_PropertyAssessment buildingPartAssessment = new ORM_RES_STR_Roof_PropertyAssessment();
                    if (buildingPartAssessmentList.Count != 0)
                    {
                        buildingPartAssessment = buildingPartAssessmentList[0];
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.Save(Connection, Transaction);

                        foreach (var assessment in buildingPartAssessmentList)
                        {
                            returnValue.Result.BuildingPropertyDocumentHeaders.Add(assessment.RoofProperty_RefID, assessment.DocumentHeader_RefID);
                        }

                    }
                    else
                    {
                        ORM_DOC_Structure_Header assessment_doc_header = new ORM_DOC_Structure_Header();
                        assessment_doc_header.Tenant_RefID = securityTicket.TenantID;

                        ORM_DOC_Structure assessment_doc_structure = new ORM_DOC_Structure();
                        assessment_doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                        assessment_doc_structure.Structure_Header_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        assessment_doc_structure.Tenant_RefID = securityTicket.TenantID;
                        assessment_doc_structure.Save(Connection, Transaction);

                        assessment_doc_header.DocumentStructureRoot_RefID = assessment_doc_structure.DOC_StructureID;
                        assessment_doc_header.Save(Connection, Transaction);

                        buildingPartAssessment = new ORM_RES_STR_Roof_PropertyAssessment();
                        buildingPartAssessment.RoofProperty_RefID = question.QuestionID;
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.DocumentHeader_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.STR_Roof_RefID = buildingPartStr.RES_STR_RoofID;
                        buildingPartAssessment.Tenant_RefID = securityTicket.TenantID;
                        buildingPartAssessment.Save(Connection, Transaction);

                        returnValue.Result.BuildingPropertyDocumentHeaders.Add(buildingPartAssessment.RoofProperty_RefID, buildingPartAssessment.DocumentHeader_RefID);

                    }
                    ORM_RES_STR_Roof_RequiredAction.Query buildingPartRequieredActionsQuery = new ORM_RES_STR_Roof_RequiredAction.Query();
                    buildingPartRequieredActionsQuery.RoofPropertyAssestment_RefID = buildingPartAssessment.RES_STR_Roof_PropertyAssessmentID;
                    int count = ORM_RES_STR_Roof_RequiredAction.Query.SoftDelete(Connection, Transaction, buildingPartRequieredActionsQuery);
                    foreach (var action in question.Actions)
                    {

                        ORM_RES_ACT_Action_Version version = new ORM_RES_ACT_Action_Version();
                        version.Load(Connection, Transaction, action.ActionVersionID);

                        ORM_CMN_Price_Value.Query priceQuery = new ORM_CMN_Price_Value.Query();
                        priceQuery.IsDeleted = false;
                        priceQuery.Price_RefID = version.Default_PricePerUnit_RefID;
                        priceQuery.Tenant_RefID = securityTicket.TenantID;
                        ORM_CMN_Price_Value priceValue = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceQuery).FirstOrDefault();
                        ORM_CMN_Price_Value.Query.SoftDelete(Connection, Transaction, priceQuery);

                        ORM_CMN_Price newPricePerUnit = new ORM_CMN_Price();
                        newPricePerUnit.Tenant_RefID = securityTicket.TenantID;
                        newPricePerUnit.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newPriceValue = new ORM_CMN_Price_Value();

                        newPriceValue.PriceValue_Amount = action.CostPerUnit;
                        newPriceValue.Price_RefID = newPricePerUnit.CMN_PriceID;
                        newPriceValue.Tenant_RefID = securityTicket.TenantID;
                        newPriceValue.Save(Connection, Transaction);

                        ORM_CMN_Price newEffectivePrice = new ORM_CMN_Price();
                        newEffectivePrice.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePrice.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newEffectivePriceValue = new ORM_CMN_Price_Value();

                        newEffectivePriceValue.PriceValue_Amount = action.CostPerUnit;
                        newEffectivePriceValue.Price_RefID = newEffectivePrice.CMN_PriceID;
                        newEffectivePriceValue.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePriceValue.Save(Connection, Transaction);

                        ORM_RES_STR_Roof_RequiredAction buildingPartRequieredAction = new ORM_RES_STR_Roof_RequiredAction();
                        buildingPartRequieredAction.SelectedActionVersion_RefID = action.ActionVersionID;
                        buildingPartRequieredAction.Action_UnitAmount = action.Amount;
                        buildingPartRequieredAction.Action_Timeframe_RefID = action.TimeFrameID;
                        buildingPartRequieredAction.Tenant_RefID = securityTicket.TenantID;
                        buildingPartRequieredAction.EffectivePrice_RefID = newEffectivePrice.CMN_PriceID;
                        buildingPartRequieredAction.Action_PricePerUnit_RefID = newPricePerUnit.CMN_PriceID;
                        buildingPartRequieredAction.Action_Unit_RefID = action.UnitRefID;
                        buildingPartRequieredAction.Comment = action.Comment;
                        buildingPartRequieredAction.RoofPropertyAssestment_RefID = buildingPartAssessment.RES_STR_Roof_PropertyAssessmentID;
                        buildingPartRequieredAction.Save(Connection, Transaction);
                    }
                }
                returnValue.Result.BuildingPartDocumentHeader = buildingPartStr.DocumentHeader_RefID;

                #endregion

            }
            else if (Parameter.BuildingPartType == "Basement")
            {

                #region Basement

                ORM_RES_BLD_Basement buildingPart = new ORM_RES_BLD_Basement();
                if (Parameter.BuildingPartID != Guid.Empty)
                {
                    var result = buildingPart.Load(Connection, Transaction, Parameter.BuildingPartID);
                    if (result.Status != FR_Status.Success || buildingPart.RES_BLD_BasementID == Guid.Empty)
                    {
                        var error = new FR_L5BD_SBP_1620();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    buildingPart.TypeOfFloor_RefID = Parameter.Basement_FloorType;
                    buildingPart.Save(Connection, Transaction);
                }

                ORM_RES_STR_Basement.Query buildingPartStrQuery = new ORM_RES_STR_Basement.Query();
                buildingPartStrQuery.DUD_Revision_RefID = Parameter.RevisionID;
                buildingPartStrQuery.Tenant_RefID = securityTicket.TenantID;
                buildingPartStrQuery.RES_BLD_Basement_RefID = Parameter.BuildingPartID;
                List<ORM_RES_STR_Basement> buildingPartStrList = ORM_RES_STR_Basement.Query.Search(Connection, Transaction, buildingPartStrQuery);
                ORM_RES_STR_Basement buildingPartStr;
                if (buildingPartStrList.Count != 0)
                {
                    buildingPartStr = buildingPartStrList[0];
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.Save(Connection, Transaction);
                }
                else
                {
                    ORM_DOC_Structure_Header doc_header = new ORM_DOC_Structure_Header();
                    doc_header.Tenant_RefID = securityTicket.TenantID;

                    ORM_DOC_Structure doc_structure = new ORM_DOC_Structure();
                    doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                    doc_structure.Structure_Header_RefID = doc_header.DOC_Structure_HeaderID;
                    doc_structure.Tenant_RefID = securityTicket.TenantID;
                    doc_structure.Save(Connection, Transaction);

                    doc_header.DocumentStructureRoot_RefID = doc_structure.DOC_StructureID;
                    doc_header.Save(Connection, Transaction);

                    buildingPartStr = new ORM_RES_STR_Basement();
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.DocumentHeader_RefID = doc_header.DOC_Structure_HeaderID;
                    buildingPartStr.RES_BLD_Basement_RefID = Parameter.BuildingPartID;
                    buildingPartStr.Tenant_RefID = securityTicket.TenantID;
                    buildingPartStr.DUD_Revision_RefID = Parameter.RevisionID;
                    buildingPartStr.Save(Connection, Transaction);
                }
                foreach (var question in Parameter.Questions)
                {
                    ORM_RES_STR_Basement_PropertyAssessment.Query buildingPartAssessmentQuery = new ORM_RES_STR_Basement_PropertyAssessment.Query();
                    buildingPartAssessmentQuery.BasementProperty_RefID = question.QuestionID;
                    buildingPartAssessmentQuery.STR_Basement_RefID = buildingPartStr.RES_STR_BasementID;
                    List<ORM_RES_STR_Basement_PropertyAssessment> buildingPartAssessmentList = ORM_RES_STR_Basement_PropertyAssessment.Query.Search(Connection, Transaction, buildingPartAssessmentQuery);
                    ORM_RES_STR_Basement_PropertyAssessment buildingPartAssessment = new ORM_RES_STR_Basement_PropertyAssessment();
                    if (buildingPartAssessmentList.Count != 0)
                    {
                        buildingPartAssessment = buildingPartAssessmentList[0];
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.Save(Connection, Transaction);

                        foreach (var assessment in buildingPartAssessmentList)
                        {
                            returnValue.Result.BuildingPropertyDocumentHeaders.Add(assessment.BasementProperty_RefID, assessment.DocumentHeader_RefID);
                        }

                    }
                    else
                    {
                        ORM_DOC_Structure_Header assessment_doc_header = new ORM_DOC_Structure_Header();
                        assessment_doc_header.Tenant_RefID = securityTicket.TenantID;

                        ORM_DOC_Structure assessment_doc_structure = new ORM_DOC_Structure();
                        assessment_doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                        assessment_doc_structure.Structure_Header_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        assessment_doc_structure.Tenant_RefID = securityTicket.TenantID;
                        assessment_doc_structure.Save(Connection, Transaction);

                        assessment_doc_header.DocumentStructureRoot_RefID = assessment_doc_structure.DOC_StructureID;
                        assessment_doc_header.Save(Connection, Transaction);

                        buildingPartAssessment = new ORM_RES_STR_Basement_PropertyAssessment();
                        buildingPartAssessment.BasementProperty_RefID = question.QuestionID;
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.DocumentHeader_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.STR_Basement_RefID = buildingPartStr.RES_STR_BasementID;
                        buildingPartAssessment.Tenant_RefID = securityTicket.TenantID;
                        buildingPartAssessment.Save(Connection, Transaction);

                        returnValue.Result.BuildingPropertyDocumentHeaders.Add(buildingPartAssessment.BasementProperty_RefID, buildingPartAssessment.DocumentHeader_RefID);

                    }
                    ORM_RES_STR_Basement_RequiredAction.Query buildingPartRequieredActionsQuery = new ORM_RES_STR_Basement_RequiredAction.Query();
                    buildingPartRequieredActionsQuery.BasementPropertyAssestment_RefID = buildingPartAssessment.RES_STR_Basement_PropertyAssessmentID;
                    int count = ORM_RES_STR_Basement_RequiredAction.Query.SoftDelete(Connection, Transaction, buildingPartRequieredActionsQuery);
                    foreach (var action in question.Actions)
                    {

                        ORM_RES_ACT_Action_Version version = new ORM_RES_ACT_Action_Version();
                        version.Load(Connection, Transaction, action.ActionVersionID);

                        ORM_CMN_Price_Value.Query priceQuery = new ORM_CMN_Price_Value.Query();
                        priceQuery.IsDeleted = false;
                        priceQuery.Price_RefID = version.Default_PricePerUnit_RefID;
                        priceQuery.Tenant_RefID = securityTicket.TenantID;
                        ORM_CMN_Price_Value priceValue = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceQuery).FirstOrDefault();
                        ORM_CMN_Price_Value.Query.SoftDelete(Connection, Transaction, priceQuery); ;

                        ORM_CMN_Price newPricePerUnit = new ORM_CMN_Price();
                        newPricePerUnit.Tenant_RefID = securityTicket.TenantID;
                        newPricePerUnit.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newPriceValue = new ORM_CMN_Price_Value();

                        newPriceValue.PriceValue_Amount = action.CostPerUnit;
                        newPriceValue.Price_RefID = newPricePerUnit.CMN_PriceID;
                        newPriceValue.Tenant_RefID = securityTicket.TenantID;
                        newPriceValue.Save(Connection, Transaction);

                        ORM_CMN_Price newEffectivePrice = new ORM_CMN_Price();
                        newEffectivePrice.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePrice.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newEffectivePriceValue = new ORM_CMN_Price_Value();

                        newEffectivePriceValue.PriceValue_Amount = action.CostPerUnit;
                        newEffectivePriceValue.Price_RefID = newEffectivePrice.CMN_PriceID;
                        newEffectivePriceValue.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePriceValue.Save(Connection, Transaction);

                        ORM_RES_STR_Basement_RequiredAction buildingPartRequieredAction = new ORM_RES_STR_Basement_RequiredAction();
                        buildingPartRequieredAction.SelectedActionVersion_RefID = action.ActionVersionID;
                        buildingPartRequieredAction.Action_UnitAmount = action.Amount;
                        buildingPartRequieredAction.Action_Timeframe_RefID = action.TimeFrameID;
                        buildingPartRequieredAction.Tenant_RefID = securityTicket.TenantID;
                        buildingPartRequieredAction.Action_Unit_RefID = action.UnitRefID;
                        buildingPartRequieredAction.Comment = action.Comment;
                        buildingPartRequieredAction.EffectivePrice_RefID = newEffectivePrice.CMN_PriceID;
                        buildingPartRequieredAction.Action_PricePerUnit_RefID = newPricePerUnit.CMN_PriceID;
                        buildingPartRequieredAction.BasementPropertyAssestment_RefID = buildingPartAssessment.RES_STR_Basement_PropertyAssessmentID;
                        buildingPartRequieredAction.Save(Connection, Transaction);
                    }
                }
                returnValue.Result.BuildingPartDocumentHeader = buildingPartStr.DocumentHeader_RefID;

                #endregion

            }
            else if (Parameter.BuildingPartType == "Hvacr")
            {

                #region Hvacr


                ORM_RES_STR_HVACR.Query buildingPartStrQuery = new ORM_RES_STR_HVACR.Query();
                buildingPartStrQuery.DUD_Revision_RefID = Parameter.RevisionID;
                buildingPartStrQuery.Tenant_RefID = securityTicket.TenantID;
                buildingPartStrQuery.RES_BLD_HVACR_RefID = Parameter.BuildingPartID;
                List<ORM_RES_STR_HVACR> buildingPartStrList = ORM_RES_STR_HVACR.Query.Search(Connection, Transaction, buildingPartStrQuery);
                ORM_RES_STR_HVACR buildingPartStr;
                if (buildingPartStrList.Count != 0)
                {
                    buildingPartStr = buildingPartStrList[0];
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.Save(Connection, Transaction);
                }
                else
                {
                    ORM_DOC_Structure_Header doc_header = new ORM_DOC_Structure_Header();
                    doc_header.Tenant_RefID = securityTicket.TenantID;

                    ORM_DOC_Structure doc_structure = new ORM_DOC_Structure();
                    doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                    doc_structure.Structure_Header_RefID = doc_header.DOC_Structure_HeaderID;
                    doc_structure.Tenant_RefID = securityTicket.TenantID;
                    doc_structure.Save(Connection, Transaction);

                    doc_header.DocumentStructureRoot_RefID = doc_structure.DOC_StructureID;
                    doc_header.Save(Connection, Transaction);

                    buildingPartStr = new ORM_RES_STR_HVACR();
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.DocumentHeader_RefID = doc_header.DOC_Structure_HeaderID;
                    buildingPartStr.RES_BLD_HVACR_RefID = Parameter.BuildingPartID;
                    buildingPartStr.Tenant_RefID = securityTicket.TenantID;
                    buildingPartStr.DUD_Revision_RefID = Parameter.RevisionID;
                    buildingPartStr.Save(Connection, Transaction);
                }
                foreach (var question in Parameter.Questions)
                {
                    ORM_RES_STR_HVACR_PropertyAssessment.Query buildingPartAssessmentQuery = new ORM_RES_STR_HVACR_PropertyAssessment.Query();
                    buildingPartAssessmentQuery.HVACRProperty_RefID = question.QuestionID;
                    buildingPartAssessmentQuery.STR_HVACR_RefID = buildingPartStr.RES_STR_HVACRID;
                    List<ORM_RES_STR_HVACR_PropertyAssessment> buildingPartAssessmentList = ORM_RES_STR_HVACR_PropertyAssessment.Query.Search(Connection, Transaction, buildingPartAssessmentQuery);
                    ORM_RES_STR_HVACR_PropertyAssessment buildingPartAssessment = new ORM_RES_STR_HVACR_PropertyAssessment();
                    if (buildingPartAssessmentList.Count != 0)
                    {
                        buildingPartAssessment = buildingPartAssessmentList[0];
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.Save(Connection, Transaction);

                        foreach (var assessment in buildingPartAssessmentList)
                        {
                            returnValue.Result.BuildingPropertyDocumentHeaders.Add(assessment.HVACRProperty_RefID, assessment.DocumentHeader_RefID);
                        }

                    }
                    else
                    {
                        ORM_DOC_Structure_Header assessment_doc_header = new ORM_DOC_Structure_Header();
                        assessment_doc_header.Tenant_RefID = securityTicket.TenantID;

                        ORM_DOC_Structure assessment_doc_structure = new ORM_DOC_Structure();
                        assessment_doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                        assessment_doc_structure.Structure_Header_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        assessment_doc_structure.Tenant_RefID = securityTicket.TenantID;
                        assessment_doc_structure.Save(Connection, Transaction);

                        assessment_doc_header.DocumentStructureRoot_RefID = assessment_doc_structure.DOC_StructureID;
                        assessment_doc_header.Save(Connection, Transaction);

                        buildingPartAssessment = new ORM_RES_STR_HVACR_PropertyAssessment();
                        buildingPartAssessment.HVACRProperty_RefID = question.QuestionID;
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.DocumentHeader_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.STR_HVACR_RefID = buildingPartStr.RES_STR_HVACRID;
                        buildingPartAssessment.Tenant_RefID = securityTicket.TenantID;
                        buildingPartAssessment.Save(Connection, Transaction);

                        returnValue.Result.BuildingPropertyDocumentHeaders.Add(buildingPartAssessment.HVACRProperty_RefID, buildingPartAssessment.DocumentHeader_RefID);

                    }
                    ORM_RES_STR_HVACR_RequiredAction.Query buildingPartRequieredActionsQuery = new ORM_RES_STR_HVACR_RequiredAction.Query();
                    buildingPartRequieredActionsQuery.HVACRPropertyAssestment_RefID = buildingPartAssessment.RES_STR_HVACR_PropertyAssessmentID;
                    int count = ORM_RES_STR_HVACR_RequiredAction.Query.SoftDelete(Connection, Transaction, buildingPartRequieredActionsQuery);
                    foreach (var action in question.Actions)
                    {

                        ORM_RES_ACT_Action_Version version = new ORM_RES_ACT_Action_Version();
                        version.Load(Connection, Transaction, action.ActionVersionID);

                        ORM_CMN_Price_Value.Query priceQuery = new ORM_CMN_Price_Value.Query();
                        priceQuery.IsDeleted = false;
                        priceQuery.Price_RefID = version.Default_PricePerUnit_RefID;
                        priceQuery.Tenant_RefID = securityTicket.TenantID;
                        ORM_CMN_Price_Value priceValue = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceQuery).FirstOrDefault();
                        ORM_CMN_Price_Value.Query.SoftDelete(Connection, Transaction, priceQuery); ;

                        ORM_CMN_Price newPricePerUnit = new ORM_CMN_Price();
                        newPricePerUnit.Tenant_RefID = securityTicket.TenantID;
                        newPricePerUnit.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newPriceValue = new ORM_CMN_Price_Value();

                        newPriceValue.PriceValue_Amount = action.CostPerUnit;
                        newPriceValue.Price_RefID = newPricePerUnit.CMN_PriceID;
                        newPriceValue.Tenant_RefID = securityTicket.TenantID;
                        newPriceValue.Save(Connection, Transaction);

                        ORM_CMN_Price newEffectivePrice = new ORM_CMN_Price();
                        newEffectivePrice.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePrice.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newEffectivePriceValue = new ORM_CMN_Price_Value();

                        newEffectivePriceValue.PriceValue_Amount = action.CostPerUnit;
                        newEffectivePriceValue.Price_RefID = newEffectivePrice.CMN_PriceID;
                        newEffectivePriceValue.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePriceValue.Save(Connection, Transaction);

                        ORM_RES_STR_HVACR_RequiredAction buildingPartRequieredAction = new ORM_RES_STR_HVACR_RequiredAction();
                        buildingPartRequieredAction.SelectedActionVersion_RefID = action.ActionVersionID;
                        buildingPartRequieredAction.Action_UnitAmount = action.Amount;
                        buildingPartRequieredAction.Action_Timeframe_RefID = action.TimeFrameID;
                        buildingPartRequieredAction.Tenant_RefID = securityTicket.TenantID;
                        buildingPartRequieredAction.EffectivePrice_RefID = newEffectivePrice.CMN_PriceID;
                        buildingPartRequieredAction.Action_PricePerUnit_RefID = newPricePerUnit.CMN_PriceID;
                        buildingPartRequieredAction.Action_Unit_RefID = action.UnitRefID;
                        buildingPartRequieredAction.Comment = action.Comment;
                        buildingPartRequieredAction.HVACRPropertyAssestment_RefID = buildingPartAssessment.RES_STR_HVACR_PropertyAssessmentID;
                        buildingPartRequieredAction.Save(Connection, Transaction);
                    }
                }
                returnValue.Result.BuildingPartDocumentHeader = buildingPartStr.DocumentHeader_RefID;

                #endregion

            }
            else if (Parameter.BuildingPartType == "StairCase")
            {

                #region StairCase
                ORM_RES_BLD_Staircase buildingPart = new ORM_RES_BLD_Staircase();
                if (Parameter.BuildingPartID != Guid.Empty)
                {
                    var result = buildingPart.Load(Connection, Transaction, Parameter.BuildingPartID);
                    if (result.Status != FR_Status.Success || buildingPart.RES_BLD_StaircaseID == Guid.Empty)
                    {
                        var error = new FR_L5BD_SBP_1620();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    buildingPart.StaircaseSize_Unit_RefID = Parameter.StaircaseUnitRefID;
                    buildingPart.StaircaseSize_Value = Parameter.StaircaseSize;
                    buildingPart.Save(Connection, Transaction);
                }

                ORM_RES_STR_Staircase.Query buildingPartStrQuery = new ORM_RES_STR_Staircase.Query();
                buildingPartStrQuery.DUD_Revision_RefID = Parameter.RevisionID;
                buildingPartStrQuery.Tenant_RefID = securityTicket.TenantID;
                buildingPartStrQuery.RES_BLD_Staircase_RefID = Parameter.BuildingPartID;
                List<ORM_RES_STR_Staircase> buildingPartStrList = ORM_RES_STR_Staircase.Query.Search(Connection, Transaction, buildingPartStrQuery);
                ORM_RES_STR_Staircase buildingPartStr;
                if (buildingPartStrList.Count != 0)
                {
                    buildingPartStr = buildingPartStrList[0];
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.Save(Connection, Transaction);
                }
                else
                {
                    ORM_DOC_Structure_Header doc_header = new ORM_DOC_Structure_Header();
                    doc_header.Tenant_RefID = securityTicket.TenantID;

                    ORM_DOC_Structure doc_structure = new ORM_DOC_Structure();
                    doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                    doc_structure.Structure_Header_RefID = doc_header.DOC_Structure_HeaderID;
                    doc_structure.Tenant_RefID = securityTicket.TenantID;
                    doc_structure.Save(Connection, Transaction);

                    doc_header.DocumentStructureRoot_RefID = doc_structure.DOC_StructureID;
                    doc_header.Save(Connection, Transaction);

                    buildingPartStr = new ORM_RES_STR_Staircase();
                    buildingPartStr.AverageRating_RefID = Parameter.GeneralRating;
                    buildingPartStr.Comment = Parameter.Comment;
                    buildingPartStr.DocumentHeader_RefID = doc_header.DOC_Structure_HeaderID;
                    buildingPartStr.RES_BLD_Staircase_RefID = Parameter.BuildingPartID;
                    buildingPartStr.Tenant_RefID = securityTicket.TenantID;
                    buildingPartStr.DUD_Revision_RefID = Parameter.RevisionID;
                    buildingPartStr.Save(Connection, Transaction);
                }
                foreach (var question in Parameter.Questions)
                {
                    ORM_RES_STR_Staircase_PropertyAssessment.Query buildingPartAssessmentQuery = new ORM_RES_STR_Staircase_PropertyAssessment.Query();
                    buildingPartAssessmentQuery.StaircaseProperty_RefID = question.QuestionID;
                    buildingPartAssessmentQuery.STR_Staircase_RefID = buildingPartStr.RES_STR_StaircaseID;
                    List<ORM_RES_STR_Staircase_PropertyAssessment> buildingPartAssessmentList = ORM_RES_STR_Staircase_PropertyAssessment.Query.Search(Connection, Transaction, buildingPartAssessmentQuery);
                    ORM_RES_STR_Staircase_PropertyAssessment buildingPartAssessment = new ORM_RES_STR_Staircase_PropertyAssessment();
                    if (buildingPartAssessmentList.Count != 0)
                    {
                        buildingPartAssessment = buildingPartAssessmentList[0];
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.Save(Connection, Transaction);

                        foreach (var assessment in buildingPartAssessmentList)
                        {
                            returnValue.Result.BuildingPropertyDocumentHeaders.Add(assessment.StaircaseProperty_RefID, assessment.DocumentHeader_RefID);
                        }

                    }
                    else
                    {
                        ORM_DOC_Structure_Header assessment_doc_header = new ORM_DOC_Structure_Header();
                        assessment_doc_header.Tenant_RefID = securityTicket.TenantID;

                        ORM_DOC_Structure assessment_doc_structure = new ORM_DOC_Structure();
                        assessment_doc_structure.CreatedBy_Account_RefID = securityTicket.AccountID;
                        assessment_doc_structure.Structure_Header_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        assessment_doc_structure.Tenant_RefID = securityTicket.TenantID;
                        assessment_doc_structure.Save(Connection, Transaction);

                        assessment_doc_header.DocumentStructureRoot_RefID = assessment_doc_structure.DOC_StructureID;
                        assessment_doc_header.Save(Connection, Transaction);

                        buildingPartAssessment = new ORM_RES_STR_Staircase_PropertyAssessment();
                        buildingPartAssessment.StaircaseProperty_RefID = question.QuestionID;
                        buildingPartAssessment.Comment = question.Comment;
                        buildingPartAssessment.DocumentHeader_RefID = assessment_doc_header.DOC_Structure_HeaderID;
                        buildingPartAssessment.Rating_RefID = question.GeneralRating;
                        buildingPartAssessment.STR_Staircase_RefID = buildingPartStr.RES_STR_StaircaseID;
                        buildingPartAssessment.Tenant_RefID = securityTicket.TenantID;
                        buildingPartAssessment.Save(Connection, Transaction);

                        returnValue.Result.BuildingPropertyDocumentHeaders.Add(buildingPartAssessment.StaircaseProperty_RefID, buildingPartAssessment.DocumentHeader_RefID);

                    }
                    ORM_RES_STR_Staircase_RequiredAction.Query buildingPartRequieredActionsQuery = new ORM_RES_STR_Staircase_RequiredAction.Query();
                    buildingPartRequieredActionsQuery.StaircasePropertyAssessment_RefID = buildingPartAssessment.RES_STR_Staircase_PropertyAssessmentID;
                    int count = ORM_RES_STR_Staircase_RequiredAction.Query.SoftDelete(Connection, Transaction, buildingPartRequieredActionsQuery);
                    foreach (var action in question.Actions)
                    {

                        ORM_RES_ACT_Action_Version version = new ORM_RES_ACT_Action_Version();
                        version.Load(Connection, Transaction, action.ActionVersionID);

                        ORM_CMN_Price_Value.Query priceQuery = new ORM_CMN_Price_Value.Query();
                        priceQuery.IsDeleted = false;
                        priceQuery.Price_RefID = version.Default_PricePerUnit_RefID;
                        priceQuery.Tenant_RefID = securityTicket.TenantID;
                        ORM_CMN_Price_Value priceValue = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceQuery).FirstOrDefault();
                        ORM_CMN_Price_Value.Query.SoftDelete(Connection, Transaction, priceQuery); ;

                        ORM_CMN_Price newPricePerUnit = new ORM_CMN_Price();
                        newPricePerUnit.Tenant_RefID = securityTicket.TenantID;
                        newPricePerUnit.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newPriceValue = new ORM_CMN_Price_Value();

                        newPriceValue.PriceValue_Amount = action.CostPerUnit;
                        newPriceValue.Price_RefID = newPricePerUnit.CMN_PriceID;
                        newPriceValue.Tenant_RefID = securityTicket.TenantID;
                        newPriceValue.Save(Connection, Transaction);

                        ORM_CMN_Price newEffectivePrice = new ORM_CMN_Price();
                        newEffectivePrice.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePrice.Save(Connection, Transaction);

                        ORM_CMN_Price_Value newEffectivePriceValue = new ORM_CMN_Price_Value();

                        newEffectivePriceValue.PriceValue_Amount = action.CostPerUnit;
                        newEffectivePriceValue.Price_RefID = newEffectivePrice.CMN_PriceID;
                        newEffectivePriceValue.Tenant_RefID = securityTicket.TenantID;
                        newEffectivePriceValue.Save(Connection, Transaction);

                        ORM_RES_STR_Staircase_RequiredAction buildingPartRequieredAction = new ORM_RES_STR_Staircase_RequiredAction();
                        buildingPartRequieredAction.SelectedActionVersion_RefID = action.ActionVersionID;
                        buildingPartRequieredAction.Action_UnitAmount = action.Amount;
                        buildingPartRequieredAction.Action_Timeframe_RefID = action.TimeFrameID;
                        buildingPartRequieredAction.Tenant_RefID = securityTicket.TenantID;
                        buildingPartRequieredAction.EffectivePrice_RefID = newEffectivePrice.CMN_PriceID;
                        buildingPartRequieredAction.Action_PricePerUnit_RefID = newPricePerUnit.CMN_PriceID;
                        buildingPartRequieredAction.Action_Unit_RefID = action.UnitRefID;
                        buildingPartRequieredAction.Comment = action.Comment;
                        buildingPartRequieredAction.StaircasePropertyAssessment_RefID = buildingPartAssessment.RES_STR_Staircase_PropertyAssessmentID;
                        buildingPartRequieredAction.Save(Connection, Transaction);
                    }
                }

                returnValue.Result.BuildingPartDocumentHeader = buildingPartStr.DocumentHeader_RefID;

                #endregion
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
		public static FR_L5BD_SBP_1620 Invoke(string ConnectionString,P_L5BD_SBP_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BD_SBP_1620 Invoke(DbConnection Connection,P_L5BD_SBP_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BD_SBP_1620 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_SBP_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BD_SBP_1620 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_SBP_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BD_SBP_1620 functionReturn = new FR_L5BD_SBP_1620();
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
	public class FR_L5BD_SBP_1620 : FR_Base
	{
		public L5BD_SBP_1620 Result	{ get; set; }

		public FR_L5BD_SBP_1620() : base() {}

		public FR_L5BD_SBP_1620(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BD_SBP_1620 for attribute P_L5BD_SBP_1620
		[DataContract]
		public class P_L5BD_SBP_1620 
		{
			[DataMember]
			public P_L5BD_SBP_1620_Question[] Questions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid BuildingPartID { get; set; } 
			[DataMember]
			public Guid RevisionID { get; set; } 
			[DataMember]
			public Guid GeneralRating { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public String BuildingPartType { get; set; } 
			[DataMember]
			public bool IsApartmentForRent { get; set; } 
			[DataMember]
			public Guid AppartmentUnitRefID { get; set; } 
			[DataMember]
			public double AparementSize { get; set; } 
			[DataMember]
			public Guid Appartment_HeatingType { get; set; } 
			[DataMember]
			public Guid Appartment_FlooringType { get; set; } 
			[DataMember]
			public Guid Appartment_WallCoveringType { get; set; } 
			[DataMember]
			public Guid StaircaseUnitRefID { get; set; } 
			[DataMember]
			public double StaircaseSize { get; set; } 
			[DataMember]
			public int OutdoorNumberOfGaragePlaces { get; set; } 
			[DataMember]
			public int OutdoorNumberOfRentedGaragePlaces { get; set; } 
			[DataMember]
			public Guid OutdoorFacility_AccessRoadType { get; set; } 
			[DataMember]
			public Guid OutdoorFacility_FenceType { get; set; } 
			[DataMember]
			public Guid Basement_FloorType { get; set; } 
			[DataMember]
			public Guid RoofType { get; set; } 

		}
		#endregion
		#region SClass P_L5BD_SBP_1620_Question for attribute Questions
		[DataContract]
		public class P_L5BD_SBP_1620_Question 
		{
			[DataMember]
			public P_L5BD_SBP_1620_Action[] Actions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid QuestionID { get; set; } 
			[DataMember]
			public Guid GeneralRating { get; set; } 
			[DataMember]
			public String Comment { get; set; } 

		}
		#endregion
		#region SClass P_L5BD_SBP_1620_Action for attribute Actions
		[DataContract]
		public class P_L5BD_SBP_1620_Action 
		{
			//Standard type parameters
			[DataMember]
			public Guid ActionVersionID { get; set; } 
			[DataMember]
			public Guid TimeFrameID { get; set; } 
			[DataMember]
			public double CostPerUnit { get; set; } 
			[DataMember]
			public double Amount { get; set; } 
			[DataMember]
			public Guid UnitRefID { get; set; } 
			[DataMember]
			public String Comment { get; set; } 

		}
		#endregion
		#region SClass L5BD_SBP_1620 for attribute L5BD_SBP_1620
		[DataContract]
		public class L5BD_SBP_1620 
		{
			//Standard type parameters
			[DataMember]
			public Guid BuildingPartDocumentHeader { get; set; } 
			[DataMember]
            public Dictionary<Guid, Guid> BuildingPropertyDocumentHeaders { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BD_SBP_1620 cls_Save_BuildingPart(P_L5BD_SBP_1620 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5BD_SBP_1620 result = cls_Save_BuildingPart.Invoke(connectionString,P_L5BD_SBP_1620 Parameter,securityTicket);
	 return result;
}
*/