/* 
 * Generated on 02-Dec-14 1:07:53 PM
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
using CL1_TMS_PRO;
using CL2_Feature.Complex.Retrieval;

namespace CL2_Feature.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Feature.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Feature
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L2FE_SF_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();
            //Put your code here

            var item = new ORM_TMS_PRO_Feature();
            if (Parameter.FeatureID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.FeatureID);
                if (result.Status != FR_Status.Success || item.TMS_PRO_FeatureID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            #region Single Delete

            if (Parameter.IsDeleted == true && Parameter.ActionType.Equals("DeleteSingle"))
            {
                ORM_TMS_PRO_Feature.Query searchQuery = new ORM_TMS_PRO_Feature.Query();
                searchQuery.TMS_PRO_FeatureID = Parameter.FeatureID;

                ORM_TMS_PRO_Feature.Query.SoftDelete(Connection, Transaction, searchQuery);

                item.IsDeleted = true;
                item.Save(Connection, Transaction);

                DeleteTags(Connection, Transaction, Parameter.FeatureID, securityTicket);

                FR_Base retVal = new FR_Base();
                retVal.Status = FR_Status.Success;

                return retVal;
            }

            #endregion

            #region Multiple Delete

            if (Parameter.IsDeleted == true && Parameter.ActionType.Equals("DeleteMultiple"))
            {
                foreach (var featureID in Parameter.FeaturesToDelete)
                {
                    ORM_TMS_PRO_Feature.Query searchQuery = new ORM_TMS_PRO_Feature.Query();
                    searchQuery.TMS_PRO_FeatureID = Guid.Parse(featureID);

                    ORM_TMS_PRO_Feature.Query.SoftDelete(Connection, Transaction, searchQuery);


                    DeleteTags(Connection, Transaction, Guid.Parse(featureID), securityTicket);
                }

                FR_Base retVal = new FR_Base();
                retVal.Status = FR_Status.Success;

                return retVal;
            }

            #endregion

            #region Add New Feature

            if (Parameter.IsDeleted == false && Parameter.ActionType.Equals("NewFeature"))
            {
                FR_Base retVal = new FR_Base();

                ORM_TMS_PRO_Feature NewFeature = new ORM_TMS_PRO_Feature();

                NewFeature.TMS_PRO_FeatureID = Guid.NewGuid();
                NewFeature.IdentificationNumber = cls_Get_NewFeatureIdentifier.Invoke(Connection, Transaction, securityTicket).Result.Identifier;

                NewFeature.Name = Parameter.Name;
                NewFeature.Description = Parameter.Description;
                NewFeature.IsDeleted = false;
                NewFeature.IsArchived = false;
                NewFeature.Feature_Deadline = Parameter.Feature_Deadline;

                NewFeature.Type_RefID = Guid.Empty;
                NewFeature.Status_RefID = Guid.Empty;
                NewFeature.Component_RefID = Guid.Empty;
                NewFeature.DOC_Structure_Header_RefID = Guid.Empty;

                NewFeature.Parent_RefID = Parameter.Parent_RefID;
                NewFeature.Project_RefID = Parameter.Project_RefID;

                NewFeature.Tenant_RefID = securityTicket.TenantID;
                NewFeature.CreatedByAccount_RefID = securityTicket.AccountID;

                if (SaveTagsForFeature(Connection, Transaction, NewFeature.TMS_PRO_FeatureID, Parameter.Tags, securityTicket).Status == FR_Status.Error_Internal)
                {
                    retVal.Status = FR_Status.Error_Internal;
                    return retVal;
                }

                NewFeature.Save(Connection, Transaction);

                retVal.Status = FR_Status.Success;
                return retVal;
            }

            #endregion

            #region Edit Feature

            if (Parameter.IsDeleted == false && Parameter.ActionType.Equals("EditFeature"))
            {
                ORM_TMS_PRO_Feature.Query featureSearchQuery = new ORM_TMS_PRO_Feature.Query();
                featureSearchQuery.TMS_PRO_FeatureID = Parameter.FeatureID;

                ORM_TMS_PRO_Feature FeatureItem = ORM_TMS_PRO_Feature.Query.Search(Connection, Transaction, featureSearchQuery).FirstOrDefault();

                FeatureItem.Name = Parameter.Name;
                FeatureItem.Description = Parameter.Description;
                FeatureItem.Project_RefID = Parameter.Project_RefID;
                FeatureItem.Parent_RefID = Parameter.Parent_RefID;
                FeatureItem.Feature_Deadline = Parameter.Feature_Deadline;


                SaveTagsFor_EditedFeature(Connection, Transaction, Parameter.FeatureID, Parameter.Tags, securityTicket);

                FeatureItem.Save(Connection, Transaction);

                FR_Base retVal = new FR_Base();
                retVal.Status = FR_Status.Success;

                return retVal;
            }

            #endregion



            return returnValue;
			#endregion UserCode
		}


        #region Support Methods

        private static FR_Base SaveTagsForFeature(DbConnection Connection, DbTransaction Transaction, Guid Feature_ID, String[] Tags, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket)
        {
            FR_Base retVal = new FR_Base();

            if (Tags != null && Tags.ToList().Count != 0)
            {
                foreach (String tag in Tags)
                {
                    ORM_TMS_PRO_Tags.Query searchForTag = new ORM_TMS_PRO_Tags.Query();
                    searchForTag.IsDeleted = false;
                    searchForTag.TagValue = tag;

                    ORM_TMS_PRO_Tags TagExists = ORM_TMS_PRO_Tags.Query.Search(Connection, Transaction, searchForTag).FirstOrDefault();


                    ORM_TMS_PRO_Feature_2_Tag Feature_2_Tag = new ORM_TMS_PRO_Feature_2_Tag();

                    Feature_2_Tag.AssignmentID = Guid.NewGuid();
                    Feature_2_Tag.IsDeleted = false;
                    Feature_2_Tag.Tenant_RefID = securityTicket.TenantID;

                    Feature_2_Tag.Feature_RefID = Feature_ID;

                    if (TagExists != null && TagExists.TMS_PRO_TagID != Guid.Empty)
                    {
                        Feature_2_Tag.Tag_RefID = TagExists.TMS_PRO_TagID;
                    }

                    if(TagExists == null || TagExists.TMS_PRO_TagID == Guid.Empty)
                    {
                        Guid NewTag_ID = SaveTag(Connection, Transaction, tag, securityTicket);
                        Feature_2_Tag.Tag_RefID = NewTag_ID;
                    }


                    Feature_2_Tag.Save(Connection, Transaction);

                }



            }

            else
            {
                retVal.Status = FR_Status.Error_Internal;

                return retVal;
            }
            retVal.Status = FR_Status.Success;

            return retVal;
        }

        private static FR_Base SaveTagsFor_EditedFeature(DbConnection Connection, DbTransaction Transaction, Guid Feature_ID, String[] Tags, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket)
        {
            FR_Base retVal = new FR_Base();

            List<String> EditedTags = Tags.ToList();

            List<ORM_TMS_PRO_Feature_2_Tag> ActiveFeatures2Tags = new List<ORM_TMS_PRO_Feature_2_Tag>();
            List<ORM_TMS_PRO_Tags> ActiveTagsForFeature = new List<ORM_TMS_PRO_Tags>();
            Dictionary<String, ORM_TMS_PRO_Tags> ActiveTagsForFeature_Remaining = new Dictionary<String, ORM_TMS_PRO_Tags>();


            #region Load lists

            ORM_TMS_PRO_Feature_2_Tag.Query search_active_f2t = new ORM_TMS_PRO_Feature_2_Tag.Query();
            search_active_f2t.Feature_RefID = Feature_ID;
            search_active_f2t.IsDeleted = false;
            search_active_f2t.Tenant_RefID = securityTicket.TenantID;

            ActiveFeatures2Tags = ORM_TMS_PRO_Feature_2_Tag.Query.Search(Connection, Transaction, search_active_f2t);

            if (ActiveFeatures2Tags != null && ActiveFeatures2Tags.Count != 0)
            {
                foreach (var f2t in ActiveFeatures2Tags)
                {
                    ORM_TMS_PRO_Tags.Query search_active_tag = new ORM_TMS_PRO_Tags.Query();
                    search_active_tag.IsDeleted = false;
                    search_active_tag.TMS_PRO_TagID = f2t.Tag_RefID;
                    search_active_tag.Tenant_RefID = securityTicket.TenantID;

                    ORM_TMS_PRO_Tags ActiveTag = ORM_TMS_PRO_Tags.Query.Search(Connection, Transaction, search_active_tag).FirstOrDefault();

                    if (ActiveTag != null)
                    {
                        ActiveTagsForFeature.Add(ActiveTag);
                        ActiveTagsForFeature_Remaining.Add(ActiveTag.TagValue ,ActiveTag);
                    }

                }
            }

            #endregion

            
            #region Delete all tags for Feature

            if (EditedTags == null || EditedTags.Count == 0)
            {

                if (ActiveFeatures2Tags.Count != 0 && ActiveFeatures2Tags != null)
                {
                    foreach (var f2t in ActiveFeatures2Tags)
                    {
                        ORM_TMS_PRO_Feature_2_Tag.Query searchQuery = new ORM_TMS_PRO_Feature_2_Tag.Query();
                        searchQuery.Feature_RefID = f2t.Feature_RefID;
                        searchQuery.Tag_RefID = f2t.Tag_RefID;
                        searchQuery.IsDeleted = false;
                        searchQuery.Tenant_RefID = securityTicket.TenantID;

                        ORM_TMS_PRO_Feature_2_Tag.Query.SoftDelete(Connection, Transaction, searchQuery);
                    }
                }

                retVal.Status = FR_Status.Success;
                return retVal;
            }

            #endregion


            #region Feature doesn't have any active tags

            if (ActiveFeatures2Tags == null || ActiveFeatures2Tags.Count == 0)
            {
                foreach (var tag in EditedTags)
                {
                    ORM_TMS_PRO_Tags.Query search_if_exists = new ORM_TMS_PRO_Tags.Query();
                    search_if_exists.IsDeleted = false;
                    search_if_exists.TagValue = tag;
                    search_if_exists.Tenant_RefID = securityTicket.TenantID;

                    ORM_TMS_PRO_Tags TagExists = ORM_TMS_PRO_Tags.Query.Search(Connection, Transaction, search_if_exists).FirstOrDefault();

                    //tag ne postoji, dodaje se novi
                    if (TagExists == null || TagExists.TMS_PRO_TagID == Guid.Empty)
                    {
                        Guid NewTag_ID = SaveTag(Connection, Transaction, tag, securityTicket);

                        ORM_TMS_PRO_Feature_2_Tag NewFeature2Tag = new ORM_TMS_PRO_Feature_2_Tag();
                        NewFeature2Tag.Feature_RefID = Feature_ID;
                        NewFeature2Tag.IsDeleted = false;
                        NewFeature2Tag.AssignmentID = Guid.NewGuid();
                        NewFeature2Tag.Tag_RefID = NewTag_ID;
                        NewFeature2Tag.Tenant_RefID = securityTicket.TenantID;

                        NewFeature2Tag.Save(Connection, Transaction);
                    }

                    // tag vec postoji
                    if (TagExists != null && TagExists.TMS_PRO_TagID != Guid.Empty)
                    {
                        ORM_TMS_PRO_Feature_2_Tag NewFeature2Tag = new ORM_TMS_PRO_Feature_2_Tag();
                        NewFeature2Tag.Feature_RefID = Feature_ID;
                        NewFeature2Tag.IsDeleted = false;
                        NewFeature2Tag.AssignmentID = Guid.NewGuid();
                        NewFeature2Tag.Tag_RefID = TagExists.TMS_PRO_TagID;
                        NewFeature2Tag.Tenant_RefID = securityTicket.TenantID;

                        NewFeature2Tag.Save(Connection, Transaction);
                    }
                }


                retVal.Status = FR_Status.Success;
                return retVal;


            }

            #endregion


            foreach (var Tag in Tags)
            {
                if(ActiveTagsForFeature.Any(ac => ac.TagValue.Equals(Tag)))
                {
                    EditedTags.Remove(Tag);
                    ActiveTagsForFeature_Remaining.Remove(Tag);
                }
            }


            #region Delete Tags no longer in use
            
            foreach (var TagToDelete in ActiveTagsForFeature_Remaining)
            {
                ORM_TMS_PRO_Feature_2_Tag.Query searchFeature2Tag = new ORM_TMS_PRO_Feature_2_Tag.Query();
                searchFeature2Tag.IsDeleted = false;
                searchFeature2Tag.Feature_RefID = Feature_ID;
                searchFeature2Tag.Tag_RefID = TagToDelete.Value.TMS_PRO_TagID;
                searchFeature2Tag.Tenant_RefID = securityTicket.TenantID;

                ORM_TMS_PRO_Feature_2_Tag.Query.SoftDelete(Connection, Transaction, searchFeature2Tag);

                
            }

            #endregion


            #region Add new tags

            foreach (var tag in EditedTags)
            {
                SaveTagsForFeature(Connection, Transaction, Feature_ID, EditedTags.ToArray(), securityTicket);
            }

            #endregion


            retVal.Status = FR_Status.Success;
            return retVal;
        }

        private static Guid SaveTag(DbConnection Connection, DbTransaction Transaction, String Tag, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket)
        {
            ORM_TMS_PRO_Tags NewTag = new ORM_TMS_PRO_Tags();

            NewTag.IsDeleted = false;
            NewTag.TagValue = Tag;
            NewTag.TMS_PRO_TagID = Guid.NewGuid();
            NewTag.Tenant_RefID = securityTicket.TenantID;

            NewTag.Save(Connection, Transaction);

            return NewTag.TMS_PRO_TagID;
        }

        private static void DeleteTags(DbConnection Connection, DbTransaction Transaction, Guid Feature_ID, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket)
        {
            ORM_TMS_PRO_Feature_2_Tag.Query searchQ = new ORM_TMS_PRO_Feature_2_Tag.Query();
            searchQ.Feature_RefID = Feature_ID;
            searchQ.IsDeleted = false;
            searchQ.Tenant_RefID = securityTicket.TenantID;

            List<ORM_TMS_PRO_Feature_2_Tag> Feature2TagsToDelete = ORM_TMS_PRO_Feature_2_Tag.Query.Search(Connection, Transaction, searchQ);

            if (Feature2TagsToDelete != null && Feature2TagsToDelete.Count != 0)
            {
                foreach (var f2t in Feature2TagsToDelete)
                {
                    ORM_TMS_PRO_Feature_2_Tag.Query searchFeature2Tag = new ORM_TMS_PRO_Feature_2_Tag.Query();
                    searchFeature2Tag.IsDeleted = false;
                    searchFeature2Tag.Feature_RefID = f2t.Feature_RefID;
                    searchFeature2Tag.Tenant_RefID = securityTicket.TenantID;

                    ORM_TMS_PRO_Feature_2_Tag.Query.SoftDelete(Connection, Transaction, searchFeature2Tag);
                }
            }
        }


        #endregion



        #endregion

        #region Method Invocation Wrappers
        ///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L2FE_SF_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L2FE_SF_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L2FE_SF_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2FE_SF_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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

				throw new Exception("Exception occured in method cls_Save_Feature",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2FE_SF_1202 for attribute P_L2FE_SF_1202
		[DataContract]
		public class P_L2FE_SF_1202 
		{
			//Standard type parameters
			[DataMember]
			public Guid FeatureID { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public Guid DOC_Structure_Header_RefID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public Guid Component_RefID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Guid Type_RefID { get; set; } 
			[DataMember]
			public Guid Status_RefID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public DateTime Feature_Deadline { get; set; } 
			[DataMember]
			public Boolean IsArchived { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Guid CreatedByAccount_RefID { get; set; } 
			[DataMember]
			public String[] Tags { get; set; } 
			[DataMember]
			public String ActionType { get; set; } 
			[DataMember]
			public String[] FeaturesToDelete { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Save_Feature(,P_L2FE_SF_1202 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Save_Feature.Invoke(connectionString,P_L2FE_SF_1202 Parameter,securityTicket);
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
var parameter = new CL2_Feature.Atomic.Manipulation.P_L2FE_SF_1202();
parameter.FeatureID = ...;
parameter.IdentificationNumber = ...;
parameter.DOC_Structure_Header_RefID = ...;
parameter.Project_RefID = ...;
parameter.Component_RefID = ...;
parameter.Parent_RefID = ...;
parameter.Type_RefID = ...;
parameter.Status_RefID = ...;
parameter.Name = ...;
parameter.Description = ...;
parameter.Feature_Deadline = ...;
parameter.IsArchived = ...;
parameter.IsDeleted = ...;
parameter.CreatedByAccount_RefID = ...;
parameter.Tags = ...;
parameter.ActionType = ...;
parameter.FeaturesToDelete = ...;

*/
