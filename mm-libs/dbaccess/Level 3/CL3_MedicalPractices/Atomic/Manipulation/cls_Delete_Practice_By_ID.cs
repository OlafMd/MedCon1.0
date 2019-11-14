/* 
 * Generated on 8/30/2013 12:12:51 PM
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
using CL1_HEC;
using CL1_CMN_BPT;
using CL3_MedicalPractices.Atomic.Retrieval;
using CL1_CMN_COM;
using CL1_CMN;
using CL3_MedicalPractices.Complex.Retrieval;
using CL1_CMN_CAL;
using CL1_CMN_BPT_CTM;
using CL3_Doctors.Atomic.Manipulation;
using Core_ClassLibrarySupport.Apoteken;

namespace CL3_MedicalPractices.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Practice_By_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Practice_By_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3MP_DPBID_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            P_L3MP_GPfID_1222 param = new P_L3MP_GPfID_1222();
            param.HEC_MedicalPractiseID = Parameter.HEC_MedicalPractiseID;
            var practice = cls_Get_Practice_For_ID.Invoke(Connection, Transaction, param, securityTicket).Result;
            if (practice != null)
            {
                ORM_CMN_UniversalContactDetail contactDetails = new ORM_CMN_UniversalContactDetail();
                if (practice.BaseInfo.CMN_UniversalContactDetailID != Guid.Empty)
                {
                    var result = contactDetails.Load(Connection, Transaction, practice.BaseInfo.CMN_UniversalContactDetailID);
                    if (result.Status != FR_Status.Success || contactDetails.CMN_UniversalContactDetailID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    contactDetails.IsDeleted = true;
                    contactDetails.Save(Connection, Transaction);
                }

                ORM_CMN_COM_CompanyInfo info = new ORM_CMN_COM_CompanyInfo();
                if (practice.BaseInfo.CMN_COM_CompanyInfoID != Guid.Empty)
                {
                    var result = info.Load(Connection, Transaction, practice.BaseInfo.CMN_COM_CompanyInfoID);
                    if (result.Status != FR_Status.Success || info.CMN_COM_CompanyInfoID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    info.IsDeleted = true;
                    info.Save(Connection, Transaction);
                }

                ORM_CMN_BPT_BusinessParticipant bParticipant = new ORM_CMN_BPT_BusinessParticipant();
                if (practice.BaseInfo.CMN_BPT_BusinessParticipantID != Guid.Empty)
                {
                    var result = bParticipant.Load(Connection, Transaction, practice.BaseInfo.CMN_BPT_BusinessParticipantID);
                    if (result.Status != FR_Status.Success || bParticipant.CMN_BPT_BusinessParticipantID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    bParticipant.IsDeleted = true;
                    bParticipant.Save(Connection, Transaction);
                }


                ORM_HEC_MedicalPractis practis = new ORM_HEC_MedicalPractis();
                if (practice.BaseInfo.HEC_MedicalPractiseID != Guid.Empty)
                {
                    var result = practis.Load(Connection, Transaction, practice.BaseInfo.HEC_MedicalPractiseID);
                    if (result.Status != FR_Status.Success || practis.HEC_MedicalPractiseID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    practis.IsDeleted = true;
                    practis.Save(Connection, Transaction);
                }

                if (practice.BaseInfo.WeeklyOfficeHours_Template_RefID != Guid.Empty)
                {
                    ORM_CMN_CAL_WeeklyOfficeHours_Template consultationHours = new ORM_CMN_CAL_WeeklyOfficeHours_Template();
                    if (practice.BaseInfo.WeeklyOfficeHours_Template_RefID != Guid.Empty)
                    {
                        var result = consultationHours.Load(Connection, Transaction, practice.BaseInfo.WeeklyOfficeHours_Template_RefID);
                        if (result.Status != FR_Status.Success || consultationHours.CMN_CAL_WeeklyOfficeHours_TemplateID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                        consultationHours.IsDeleted = true;
                        consultationHours.Save(Connection, Transaction);
                    }
                }
                if (practice.BaseInfo.WeeklySurgeryHours_Template_RefID != Guid.Empty)
                {
                    ORM_CMN_CAL_WeeklyOfficeHours_Template consultationHours = new ORM_CMN_CAL_WeeklyOfficeHours_Template();
                    if (practice.BaseInfo.WeeklyOfficeHours_Template_RefID != Guid.Empty)
                    {
                        var result = consultationHours.Load(Connection, Transaction, practice.BaseInfo.WeeklySurgeryHours_Template_RefID);
                        if (result.Status != FR_Status.Success || consultationHours.CMN_CAL_WeeklyOfficeHours_TemplateID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                        consultationHours.IsDeleted = true;
                        consultationHours.Save(Connection, Transaction);
                    }
                }

                if (practice.ShippingAddress != null)
                {
                    ORM_CMN_UniversalContactDetail shippingDetails = new ORM_CMN_UniversalContactDetail();
                    if (practice.ShippingAddress.CMN_UniversalContactDetailID != Guid.Empty)
                    {
                        var result = shippingDetails.Load(Connection, Transaction, practice.ShippingAddress.CMN_UniversalContactDetailID);
                        if (result.Status != FR_Status.Success || contactDetails.CMN_UniversalContactDetailID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }

                        shippingDetails.IsDeleted = true;
                        shippingDetails.Save(Connection, Transaction);
                    }

                    ORM_CMN_COM_CompanyInfo_Address shippingAddress = new ORM_CMN_COM_CompanyInfo_Address();
                    if (practice.ShippingAddress.CMN_COM_CompanyInfo_AddressID != Guid.Empty)
                    {
                        var result = shippingAddress.Load(Connection, Transaction, practice.ShippingAddress.CMN_COM_CompanyInfo_AddressID);
                        if (result.Status != FR_Status.Success || shippingAddress.CMN_COM_CompanyInfo_AddressID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                        shippingAddress.IsDeleted = true;
                        shippingAddress.Save(Connection, Transaction);
                    }
                }

                var associatedBussinessParticipantsQuery = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query();
                associatedBussinessParticipantsQuery.AssociatedBusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
                associatedBussinessParticipantsQuery.IsDeleted = false;
                var associatedBussinessParticipants = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, associatedBussinessParticipantsQuery);

                if (associatedBussinessParticipants.Count != 0)
                {
                    foreach (var assBussiness in associatedBussinessParticipants)
                    {
                        assBussiness.IsDeleted = true;
                        assBussiness.Save(Connection, Transaction);

                        //brisanje doktora ako je imao jednu praksu
                        //var d2pAssignmentQuery = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query();
                        //d2pAssignmentQuery.IsDeleted = false;
                        //d2pAssignmentQuery.BusinessParticipant_RefID = assBussiness.BusinessParticipant_RefID;
                        //var d2pAssignmentRes = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, d2pAssignmentQuery).ToArray();
                        //if (d2pAssignmentRes.Length == 0)
                        //{
                        //    var docQuery = new ORM_HEC_Doctor.Query();
                        //    docQuery.BusinessParticipant_RefID = assBussiness.BusinessParticipant_RefID;
                        //    var doctor =  ORM_HEC_Doctor.Query.Search(Connection, Transaction, docQuery).First();
                        //    P_L3MD_DDbID_1031 delDoc = new P_L3MD_DDbID_1031();
                        //    delDoc.DoctorID = doctor.HEC_DoctorID;
                        //    var delRes = cls_Delete_Doctor_byID.Invoke(Connection, Transaction, delDoc, securityTicket).Result;
                        //}
                    }
                }

                if (practice.OtherOphthal_PracticeData != null)
                {
                    ORM_HEC_PublicHealthcare_PhysitianAssociation association = new ORM_HEC_PublicHealthcare_PhysitianAssociation();
                    if (practice.OtherOphthal_PracticeData.HEC_PublicHealthcare_PhysitianAssociationID != Guid.Empty)
                    {
                        var result = association.Load(Connection, Transaction, practice.OtherOphthal_PracticeData.HEC_PublicHealthcare_PhysitianAssociationID);
                        if (result.Status != FR_Status.Success || association.HEC_PublicHealthcare_PhysitianAssociationID == Guid.Empty)
                        {
                            var item = STLD_MedicalAssociation.associationItems.FirstOrDefault(a => a.Value == practice.OtherOphthal_PracticeData.HEC_PublicHealthcare_PhysitianAssociationID);
                            if (item != null)
                            {
                                association.IsDeleted = true;
                                association.HealthAssociation_Name = item.Text;
                                association.Save(Connection, Transaction);
                            }
                        }
                    }

                    var customerQuery = new ORM_CMN_BPT_CTM_Customer.Query();
                    customerQuery.Ext_BusinessParticipant_RefID = practice.BaseInfo.CMN_BPT_BusinessParticipantID;
                    var customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery).FirstOrDefault();
                    if (customer != null)
                    {
                        customer.IsDeleted = true;
                        customer.Save(Connection, Transaction);
                    }

                    var companyTypeQuery = new ORM_CMN_COM_CompanyInfo_Type.Query();
                    companyTypeQuery.IsDeleted = false;
                    companyTypeQuery.CMN_COM_CompanyInfo_TypeID = practice.OtherOphthal_PracticeData.CMN_COM_CompanyInfo_TypeID;
                    var companyType = ORM_CMN_COM_CompanyInfo_Type.Query.Search(Connection, Transaction, companyTypeQuery).First();
                    var pHealthcareQuery = new ORM_HEC_PublicHealthcare_PhysitianAssociation.Query();
                    pHealthcareQuery.HEC_PublicHealthcare_PhysitianAssociationID = practice.OtherOphthal_PracticeData.HEC_PublicHealthcare_PhysitianAssociationID;
                    var pHealthcare = ORM_HEC_PublicHealthcare_PhysitianAssociation.Query.Search(Connection, Transaction, pHealthcareQuery).First();
                    pHealthcare.IsDeleted = true;
                    pHealthcare.Save(Connection, Transaction);

                    if (customer != null)
                    {

                        var affinityStatusQuery = new ORM_CMN_BPT_CTM_AffinityStatus.Query();
                        affinityStatusQuery.CMN_BPT_CTM_AffinityStatusID = customer.CustomerAffinityStatus_RefID;
                        var affinityStatus = ORM_CMN_BPT_CTM_AffinityStatus.Query.Search(Connection, Transaction, affinityStatusQuery).First();
                        if (affinityStatus != null)
                        {
                            affinityStatus.IsDeleted = true;
                            affinityStatus.Save(Connection, Transaction);
                        }
                    }              
                }             
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3MP_DPBID_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3MP_DPBID_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3MP_DPBID_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3MP_DPBID_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_Practice_By_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3MP_DPBID_1026 for attribute P_L3MP_DPBID_1026
		[DataContract]
		public class P_L3MP_DPBID_1026 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_Practice_By_ID(,P_L3MP_DPBID_1026 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_Guid invocationResult = cls_Delete_Practice_By_ID.Invoke(connectionString,P_L3MP_DPBID_1026 Parameter,securityTicket);
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
var parameter = new CL3_MedicalPractices.Atomic.Manipulation.P_L3MP_DPBID_1026();
parameter.HEC_MedicalPractiseID = ...;

*/
