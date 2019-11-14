/* 
 * Generated on 12/17/2014 09:41:18
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
using CL3_Document.Atomic.Retrieval;
using CL1_TMS_PRO;
using CL1_CMN_BPT;
using CL1_TMP_PRO;
using CL1_CMN_PRO;
using CL1_CMN;

namespace CL6_DanuTask_Document.Complex.Retrieval
{
	/// <summary>
    /// 
    ///  Get Document and Document Structures for any ID
    ///
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Document_and_DocumentStructures_for_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Document_and_DocumentStructures_for_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DO_GDaDSfID_1658 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DO_GDaDSfID_1658 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6DO_GDaDSfID_1658();
            returnValue.Result = new L6DO_GDaDSfID_1658();

            var bTaskQuery = new ORM_TMS_PRO_BusinessTask.Query();
            bTaskQuery.TMS_PRO_BusinessTaskID = Parameter.ID;
            var bTaskList = ORM_TMS_PRO_BusinessTask.Query.Search(Connection, Transaction, bTaskQuery);

            List<L3DO_GDfBTID_1725> docList = new List<L3DO_GDfBTID_1725>();
            List<L3DO_GDfBTID_1725a> revList = new List<L3DO_GDfBTID_1725a>();
            List<L3DO_GDSfBTID_1117> docStructList = new List<L3DO_GDSfBTID_1117>();

            if (bTaskList.Count != 0)
            {
                P_L3DO_GDfBTID_1725 parameter = new P_L3DO_GDfBTID_1725();
                parameter.ID = Parameter.ID;
                var documentList = cls_Get_Documents_for_BusinessTaskID.Invoke(Connection, Transaction, parameter, securityTicket).Result;
                foreach (var doc in documentList)
                {
                    L3DO_GDfBTID_1725 tempDoc = new L3DO_GDfBTID_1725();
                    tempDoc.Alias = doc.Alias;
                    tempDoc.AssignmentID = doc.AssignmentID;
                    tempDoc.DOC_DocumentID = doc.DOC_DocumentID;
                    tempDoc.PrimaryType = doc.PrimaryType;
                    tempDoc.Structure_RefID = doc.Structure_RefID;
                    tempDoc.StructureHeader_RefID = doc.StructureHeader_RefID;
                    foreach (var revision in doc.Revisions)
                    {
                        L3DO_GDfBTID_1725a tempRevision = new L3DO_GDfBTID_1725a();
                        tempRevision.Creation_Timestamp = revision.Creation_Timestamp;
                        tempRevision.DOC_DocumentRevisionID = revision.DOC_DocumentRevisionID;
                        tempRevision.Document_RefID = revision.Document_RefID;
                        tempRevision.File_Description = revision.File_Description;
                        tempRevision.File_Extension = revision.File_Extension;
                        tempRevision.File_MIMEType = revision.File_MIMEType;
                        tempRevision.File_Name = revision.File_Name;
                        tempRevision.File_ServerLocation = revision.File_ServerLocation;
                        tempRevision.File_Size_Bytes = revision.File_Size_Bytes;
                        tempRevision.File_SourceLocation = revision.File_SourceLocation;
                        tempRevision.IsLastRevision = revision.IsLastRevision;
                        tempRevision.IsLocked = revision.IsLocked;
                        tempRevision.Revision = revision.Revision;

                        revList.Add(tempRevision);
                    }

                    tempDoc.Revisions = revList.ToArray();

                    docList.Add(tempDoc);
                }

                P_L3DO_GDSfBTID_1117 parStructure = new P_L3DO_GDSfBTID_1117();
                parStructure.ID = Parameter.ID;
                var documentStructures = cls_Get_DocumentStructures_for_BusinessTaskID.Invoke(Connection, Transaction, parStructure, securityTicket).Result;

                foreach (var ds in documentStructures)
                {
                    L3DO_GDSfBTID_1117 temp = new L3DO_GDSfBTID_1117();
                    temp.DOC_StructureID = ds.DOC_StructureID;
                    temp.Label = ds.Label;
                    temp.Parent_RefID = ds.Parent_RefID;
                    temp.Structure_Header_RefID = ds.Structure_Header_RefID;

                    docStructList.Add(temp);
                }

                returnValue.Result.Documents = docList.ToArray();
                returnValue.Result.DocumentStructures = docStructList.ToArray();
                returnValue.Result.DocumentParentType = "BusinessTask";
            }
            else
            {
                var featureQuery = new ORM_TMS_PRO_Feature.Query();
                featureQuery.TMS_PRO_FeatureID = Parameter.ID;
                var featureList = ORM_TMS_PRO_Feature.Query.Search(Connection, Transaction, featureQuery);

                if (featureList.Count != 0)
                {
                    P_L3DO_GDfFID_0843 parameter = new P_L3DO_GDfFID_0843();
                    parameter.ID = Parameter.ID;
                    var documentList = cls_Get_Documents_for_FeatureID.Invoke(Connection, Transaction, parameter, securityTicket).Result; 
                    foreach (var doc in documentList)
                    {
                        L3DO_GDfBTID_1725 tempDoc = new L3DO_GDfBTID_1725();
                        tempDoc.Alias = doc.Alias;
                        tempDoc.AssignmentID = doc.AssignmentID;
                        tempDoc.DOC_DocumentID = doc.DOC_DocumentID;
                        tempDoc.PrimaryType = doc.PrimaryType;
                        tempDoc.Structure_RefID = doc.Structure_RefID;
                        tempDoc.StructureHeader_RefID = doc.StructureHeader_RefID;
                        foreach (var revision in doc.Revisions) {
                            L3DO_GDfBTID_1725a tempRevision = new L3DO_GDfBTID_1725a();
                            tempRevision.Creation_Timestamp = revision.Creation_Timestamp;
                            tempRevision.DOC_DocumentRevisionID = revision.DOC_DocumentRevisionID;
                            tempRevision.Document_RefID = revision.Document_RefID;
                            tempRevision.File_Description = revision.File_Description;
                            tempRevision.File_Extension = revision.File_Extension;
                            tempRevision.File_MIMEType = revision.File_MIMEType;
                            tempRevision.File_Name = revision.File_Name;
                            tempRevision.File_ServerLocation = revision.File_ServerLocation;
                            tempRevision.File_Size_Bytes = revision.File_Size_Bytes;
                            tempRevision.File_SourceLocation = revision.File_SourceLocation;
                            tempRevision.IsLastRevision = revision.IsLastRevision;
                            tempRevision.IsLocked = revision.IsLocked;
                            tempRevision.Revision = revision.Revision;

                            revList.Add(tempRevision);                             
                        }

                        tempDoc.Revisions = revList.ToArray();

                        docList.Add(tempDoc);
                    }

                    P_L3DO_GDSfFID_1137 parStructure = new P_L3DO_GDSfFID_1137();
                    parStructure.ID = Parameter.ID;
                    var documentStructures = cls_Get_DocumentStructures_for_FeatureID.Invoke(Connection, Transaction, parStructure, securityTicket).Result;

                    foreach (var ds in documentStructures)
                    {
                        L3DO_GDSfBTID_1117 temp = new L3DO_GDSfBTID_1117();
                        temp.DOC_StructureID = ds.DOC_StructureID;
                        temp.Label = ds.Label;
                        temp.Parent_RefID = ds.Parent_RefID;
                        temp.Structure_Header_RefID = ds.Structure_Header_RefID;

                        docStructList.Add(temp);
                    }

                    returnValue.Result.Documents = docList.ToArray();
                    returnValue.Result.DocumentStructures = docStructList.ToArray();
                    returnValue.Result.DocumentParentType = "Feature";
                }
                else
                {
                    var dTaskQuery = new ORM_TMS_PRO_DeveloperTask.Query();
                    dTaskQuery.TMS_PRO_DeveloperTaskID = Parameter.ID;
                    var dTaskList = ORM_TMS_PRO_DeveloperTask.Query.Search(Connection, Transaction, dTaskQuery);

                    if (dTaskList.Count != 0)
                    {
                        P_L3DO_GDfDTID_0840 parameter = new P_L3DO_GDfDTID_0840();
                        parameter.ID = Parameter.ID;
                        var documentList = cls_Get_Documents_for_DeveloperTaskID.Invoke(Connection, Transaction, parameter, securityTicket).Result;
                        foreach (var doc in documentList)
                        {
                            L3DO_GDfBTID_1725 tempDoc = new L3DO_GDfBTID_1725();
                            tempDoc.Alias = doc.Alias;
                            tempDoc.AssignmentID = doc.AssignmentID;
                            tempDoc.DOC_DocumentID = doc.DOC_DocumentID;
                            tempDoc.PrimaryType = doc.PrimaryType;
                            tempDoc.Structure_RefID = doc.Structure_RefID;
                            tempDoc.StructureHeader_RefID = doc.StructureHeader_RefID;
                            foreach (var revision in doc.Revisions)
                            {
                                L3DO_GDfBTID_1725a tempRevision = new L3DO_GDfBTID_1725a();
                                tempRevision.Creation_Timestamp = revision.Creation_Timestamp;
                                tempRevision.DOC_DocumentRevisionID = revision.DOC_DocumentRevisionID;
                                tempRevision.Document_RefID = revision.Document_RefID;
                                tempRevision.File_Description = revision.File_Description;
                                tempRevision.File_Extension = revision.File_Extension;
                                tempRevision.File_MIMEType = revision.File_MIMEType;
                                tempRevision.File_Name = revision.File_Name;
                                tempRevision.File_ServerLocation = revision.File_ServerLocation;
                                tempRevision.File_Size_Bytes = revision.File_Size_Bytes;
                                tempRevision.File_SourceLocation = revision.File_SourceLocation;
                                tempRevision.IsLastRevision = revision.IsLastRevision;
                                tempRevision.IsLocked = revision.IsLocked;
                                tempRevision.Revision = revision.Revision;

                                revList.Add(tempRevision);
                            }

                            tempDoc.Revisions = revList.ToArray();

                            docList.Add(tempDoc);
                        }

                        P_L3DO_GDSfDTID_1500 parStructure = new P_L3DO_GDSfDTID_1500();
                        parStructure.ID = Parameter.ID;
                        var documentStructures = cls_Get_DocumentStructures_for_DeveloperTaskID.Invoke(Connection, Transaction, parStructure, securityTicket).Result;

                        foreach (var ds in documentStructures)
                        {
                            L3DO_GDSfBTID_1117 temp = new L3DO_GDSfBTID_1117();
                            temp.DOC_StructureID = ds.DOC_StructureID;
                            temp.Label = ds.Label;
                            temp.Parent_RefID = ds.Parent_RefID;
                            temp.Structure_Header_RefID = ds.Structure_Header_RefID;

                            docStructList.Add(temp);
                        }

                        returnValue.Result.Documents = docList.ToArray();
                        returnValue.Result.DocumentStructures = docStructList.ToArray();
                        returnValue.Result.DocumentParentType = "DeveloperTask"; 
                    }
                    else
                    {
                        var projectQuery = new ORM_TMS_PRO_Project.Query();
                        projectQuery.TMS_PRO_ProjectID = Parameter.ID;
                        var projectList = ORM_TMS_PRO_Project.Query.Search(Connection, Transaction, projectQuery);

                        if (projectList.Count != 0)
                        {
                            P_L3DO_GDfPID_0846 parameter = new P_L3DO_GDfPID_0846();
                            parameter.ID = Parameter.ID;
                            var documentList = cls_Get_Documents_for_ProjectID.Invoke(Connection, Transaction, parameter, securityTicket).Result;
                            foreach (var doc in documentList)
                            {
                                L3DO_GDfBTID_1725 tempDoc = new L3DO_GDfBTID_1725();
                                tempDoc.Alias = doc.Alias;
                                tempDoc.AssignmentID = doc.AssignmentID;
                                tempDoc.DOC_DocumentID = doc.DOC_DocumentID;
                                tempDoc.PrimaryType = doc.PrimaryType;
                                tempDoc.Structure_RefID = doc.Structure_RefID;
                                tempDoc.StructureHeader_RefID = doc.StructureHeader_RefID;
                                foreach (var revision in doc.Revisions)
                                {
                                    L3DO_GDfBTID_1725a tempRevision = new L3DO_GDfBTID_1725a();
                                    tempRevision.Creation_Timestamp = revision.Creation_Timestamp;
                                    tempRevision.DOC_DocumentRevisionID = revision.DOC_DocumentRevisionID;
                                    tempRevision.Document_RefID = revision.Document_RefID;
                                    tempRevision.File_Description = revision.File_Description;
                                    tempRevision.File_Extension = revision.File_Extension;
                                    tempRevision.File_MIMEType = revision.File_MIMEType;
                                    tempRevision.File_Name = revision.File_Name;
                                    tempRevision.File_ServerLocation = revision.File_ServerLocation;
                                    tempRevision.File_Size_Bytes = revision.File_Size_Bytes;
                                    tempRevision.File_SourceLocation = revision.File_SourceLocation;
                                    tempRevision.IsLastRevision = revision.IsLastRevision;
                                    tempRevision.IsLocked = revision.IsLocked;
                                    tempRevision.Revision = revision.Revision;

                                    revList.Add(tempRevision);
                                }

                                tempDoc.Revisions = revList.ToArray();

                                docList.Add(tempDoc);
                            }

                            P_L3DO_GDSfPID_1517 parStructure = new P_L3DO_GDSfPID_1517();
                            parStructure.ID = Parameter.ID;
                            var documentStructures = cls_Get_DocumentStructures_for_ProjectID.Invoke(Connection, Transaction, parStructure, securityTicket).Result;

                            foreach (var ds in documentStructures)
                            {
                                L3DO_GDSfBTID_1117 temp = new L3DO_GDSfBTID_1117();
                                temp.DOC_StructureID = ds.DOC_StructureID;
                                temp.Label = ds.Label;
                                temp.Parent_RefID = ds.Parent_RefID;
                                temp.Structure_Header_RefID = ds.Structure_Header_RefID;

                                docStructList.Add(temp);
                            }

                            returnValue.Result.Documents = docList.ToArray();
                            returnValue.Result.DocumentStructures = docStructList.ToArray();
                            returnValue.Result.DocumentParentType = "Project";
                        }
                        else
                        {
                            var commentQuery = new ORM_TMS_PRO_Comment.Query();
                            commentQuery.TMS_PRO_CommentID = Parameter.ID;
                            var commentList = ORM_TMS_PRO_Comment.Query.Search(Connection, Transaction, commentQuery);

                            if (commentList.Count != 0)
                            {
                                P_L3DO_GDfCID_0848 parameter = new P_L3DO_GDfCID_0848();
                                parameter.ID = Parameter.ID;
                                var documentList = cls_Get_Documents_for_CommentID.Invoke(Connection, Transaction, parameter, securityTicket).Result;
                                foreach (var doc in documentList)
                                {
                                    L3DO_GDfBTID_1725 tempDoc = new L3DO_GDfBTID_1725();
                                    tempDoc.Alias = doc.Alias;
                                    tempDoc.AssignmentID = doc.AssignmentID;
                                    tempDoc.DOC_DocumentID = doc.DOC_DocumentID;
                                    tempDoc.PrimaryType = doc.PrimaryType;
                                    tempDoc.Structure_RefID = doc.Structure_RefID;
                                    tempDoc.StructureHeader_RefID = doc.StructureHeader_RefID;
                                    foreach (var revision in doc.Revisions)
                                    {
                                        L3DO_GDfBTID_1725a tempRevision = new L3DO_GDfBTID_1725a();
                                        tempRevision.Creation_Timestamp = revision.Creation_Timestamp;
                                        tempRevision.DOC_DocumentRevisionID = revision.DOC_DocumentRevisionID;
                                        tempRevision.Document_RefID = revision.Document_RefID;
                                        tempRevision.File_Description = revision.File_Description;
                                        tempRevision.File_Extension = revision.File_Extension;
                                        tempRevision.File_MIMEType = revision.File_MIMEType;
                                        tempRevision.File_Name = revision.File_Name;
                                        tempRevision.File_ServerLocation = revision.File_ServerLocation;
                                        tempRevision.File_Size_Bytes = revision.File_Size_Bytes;
                                        tempRevision.File_SourceLocation = revision.File_SourceLocation;
                                        tempRevision.IsLastRevision = revision.IsLastRevision;
                                        tempRevision.IsLocked = revision.IsLocked;
                                        tempRevision.Revision = revision.Revision;

                                        revList.Add(tempRevision);
                                    }

                                    tempDoc.Revisions = revList.ToArray();

                                    docList.Add(tempDoc);
                                }

                                P_L3DO_GDSfCID_1523 parStructure = new P_L3DO_GDSfCID_1523();
                                parStructure.ID = Parameter.ID;
                                var documentStructures = cls_Get_DocumentStructures_for_CommentID.Invoke(Connection, Transaction, parStructure, securityTicket).Result;

                                foreach (var ds in documentStructures)
                                {
                                    L3DO_GDSfBTID_1117 temp = new L3DO_GDSfBTID_1117();
                                    temp.DOC_StructureID = ds.DOC_StructureID;
                                    temp.Label = ds.Label;
                                    temp.Parent_RefID = ds.Parent_RefID;
                                    temp.Structure_Header_RefID = ds.Structure_Header_RefID;

                                    docStructList.Add(temp);
                                }

                                returnValue.Result.Documents = docList.ToArray();
                                returnValue.Result.DocumentStructures = docStructList.ToArray();
                                returnValue.Result.DocumentParentType = "Comment";
                            }
                            else
                            {
                                var memoQuery = new ORM_CMN_BPT_Memo.Query();
                                memoQuery.CMN_BPT_MemoID = Parameter.ID;
                                var memoList = ORM_CMN_BPT_Memo.Query.Search(Connection, Transaction, memoQuery);

                                if (memoList.Count != 0)
                                {
                                    P_L3DO_GDfMID_0849 parameter = new P_L3DO_GDfMID_0849();
                                    parameter.ID = Parameter.ID;
                                    var documentList = cls_Get_Documents_for_MemoID.Invoke(Connection, Transaction, parameter, securityTicket).Result;
                                    foreach (var doc in documentList)
                                    {
                                        L3DO_GDfBTID_1725 tempDoc = new L3DO_GDfBTID_1725();
                                        tempDoc.Alias = doc.Alias;
                                        tempDoc.AssignmentID = doc.AssignmentID;
                                        tempDoc.DOC_DocumentID = doc.DOC_DocumentID;
                                        tempDoc.PrimaryType = doc.PrimaryType;
                                        tempDoc.Structure_RefID = doc.Structure_RefID;
                                        tempDoc.StructureHeader_RefID = doc.StructureHeader_RefID;
                                        foreach (var revision in doc.Revisions)
                                        {
                                            L3DO_GDfBTID_1725a tempRevision = new L3DO_GDfBTID_1725a();
                                            tempRevision.Creation_Timestamp = revision.Creation_Timestamp;
                                            tempRevision.DOC_DocumentRevisionID = revision.DOC_DocumentRevisionID;
                                            tempRevision.Document_RefID = revision.Document_RefID;
                                            tempRevision.File_Description = revision.File_Description;
                                            tempRevision.File_Extension = revision.File_Extension;
                                            tempRevision.File_MIMEType = revision.File_MIMEType;
                                            tempRevision.File_Name = revision.File_Name;
                                            tempRevision.File_ServerLocation = revision.File_ServerLocation;
                                            tempRevision.File_Size_Bytes = revision.File_Size_Bytes;
                                            tempRevision.File_SourceLocation = revision.File_SourceLocation;
                                            tempRevision.IsLastRevision = revision.IsLastRevision;
                                            tempRevision.IsLocked = revision.IsLocked;
                                            tempRevision.Revision = revision.Revision;

                                            revList.Add(tempRevision);
                                        }

                                        tempDoc.Revisions = revList.ToArray();

                                        docList.Add(tempDoc);
                                    }

                                    P_L3DO_GDSfMID_1503 parStructure = new P_L3DO_GDSfMID_1503();
                                    parStructure.ID = Parameter.ID;
                                    var documentStructures = cls_Get_DocumentStructures_for_MemoID.Invoke(Connection, Transaction, parStructure, securityTicket).Result;

                                    foreach (var ds in documentStructures)
                                    {
                                        L3DO_GDSfBTID_1117 temp = new L3DO_GDSfBTID_1117();
                                        temp.DOC_StructureID = ds.DOC_StructureID;
                                        temp.Label = ds.Label;
                                        temp.Parent_RefID = ds.Parent_RefID;
                                        temp.Structure_Header_RefID = ds.Structure_Header_RefID;

                                        docStructList.Add(temp);
                                    }

                                    returnValue.Result.Documents = docList.ToArray();
                                    returnValue.Result.DocumentStructures = docStructList.ToArray();
                                    returnValue.Result.DocumentParentType = "Memo";
                                }
                                else
                                {
                                    var milestoneQuery = new ORM_TMP_PRO_Milestone.Query();
                                    milestoneQuery.TMP_PRO_MilestoneID = Parameter.ID;
                                    var milestoneList = ORM_TMP_PRO_Milestone.Query.Search(Connection, Transaction, milestoneQuery);

                                    if (milestoneList.Count != 0)
                                    {
                                        P_L3DO_GDfMSID_0851 parameter = new P_L3DO_GDfMSID_0851();
                                        parameter.ID = Parameter.ID;
                                        var documentList = cls_Get_Documents_for_MilestoneID.Invoke(Connection, Transaction, parameter, securityTicket).Result;
                                        foreach (var doc in documentList)
                                        {
                                            L3DO_GDfBTID_1725 tempDoc = new L3DO_GDfBTID_1725();
                                            tempDoc.Alias = doc.Alias;
                                            tempDoc.AssignmentID = doc.AssignmentID;
                                            tempDoc.DOC_DocumentID = doc.DOC_DocumentID;
                                            tempDoc.PrimaryType = doc.PrimaryType;
                                            tempDoc.Structure_RefID = doc.Structure_RefID;
                                            tempDoc.StructureHeader_RefID = doc.StructureHeader_RefID;
                                            foreach (var revision in doc.Revisions)
                                            {
                                                L3DO_GDfBTID_1725a tempRevision = new L3DO_GDfBTID_1725a();
                                                tempRevision.Creation_Timestamp = revision.Creation_Timestamp;
                                                tempRevision.DOC_DocumentRevisionID = revision.DOC_DocumentRevisionID;
                                                tempRevision.Document_RefID = revision.Document_RefID;
                                                tempRevision.File_Description = revision.File_Description;
                                                tempRevision.File_Extension = revision.File_Extension;
                                                tempRevision.File_MIMEType = revision.File_MIMEType;
                                                tempRevision.File_Name = revision.File_Name;
                                                tempRevision.File_ServerLocation = revision.File_ServerLocation;
                                                tempRevision.File_Size_Bytes = revision.File_Size_Bytes;
                                                tempRevision.File_SourceLocation = revision.File_SourceLocation;
                                                tempRevision.IsLastRevision = revision.IsLastRevision;
                                                tempRevision.IsLocked = revision.IsLocked;
                                                tempRevision.Revision = revision.Revision;

                                                revList.Add(tempRevision);
                                            }

                                            tempDoc.Revisions = revList.ToArray();

                                            docList.Add(tempDoc);
                                        }

                                        P_L3DO_GDSfMSID_1507 parStructure = new P_L3DO_GDSfMSID_1507();
                                        parStructure.ID = Parameter.ID;
                                        var documentStructures = cls_Get_DocumentStructures_for_MilestoneID.Invoke(Connection, Transaction, parStructure, securityTicket).Result;

                                        foreach (var ds in documentStructures)
                                        {
                                            L3DO_GDSfBTID_1117 temp = new L3DO_GDSfBTID_1117();
                                            temp.DOC_StructureID = ds.DOC_StructureID;
                                            temp.Label = ds.Label;
                                            temp.Parent_RefID = ds.Parent_RefID;
                                            temp.Structure_Header_RefID = ds.Structure_Header_RefID;

                                            docStructList.Add(temp);
                                        }

                                        returnValue.Result.Documents = docList.ToArray();
                                        returnValue.Result.DocumentStructures = docStructList.ToArray();
                                        returnValue.Result.DocumentParentType = "Milestone";
                                    }
                                    else
                                    {
                                        var productReleaseQuery = new ORM_CMN_PRO_Product_Release.Query();
                                        productReleaseQuery.CMN_PRO_Product_ReleaseID = Parameter.ID;
                                        var productReleaseList = ORM_CMN_PRO_Product_Release.Query.Search(Connection, Transaction, productReleaseQuery);

                                        if (productReleaseList.Count != 0)
                                        {
                                            P_L3DO_GDfPRID_0853 parameter = new P_L3DO_GDfPRID_0853();
                                            parameter.ID = Parameter.ID;
                                            var documentList = cls_Get_Documents_for_ProductReleaseID.Invoke(Connection, Transaction, parameter, securityTicket).Result;
                                            foreach (var doc in documentList)
                                            {
                                                L3DO_GDfBTID_1725 tempDoc = new L3DO_GDfBTID_1725();
                                                tempDoc.Alias = doc.Alias;
                                                tempDoc.AssignmentID = doc.AssignmentID;
                                                tempDoc.DOC_DocumentID = doc.DOC_DocumentID;
                                                tempDoc.PrimaryType = doc.PrimaryType;
                                                tempDoc.Structure_RefID = doc.Structure_RefID;
                                                tempDoc.StructureHeader_RefID = doc.StructureHeader_RefID;
                                                foreach (var revision in doc.Revisions)
                                                {
                                                    L3DO_GDfBTID_1725a tempRevision = new L3DO_GDfBTID_1725a();
                                                    tempRevision.Creation_Timestamp = revision.Creation_Timestamp;
                                                    tempRevision.DOC_DocumentRevisionID = revision.DOC_DocumentRevisionID;
                                                    tempRevision.Document_RefID = revision.Document_RefID;
                                                    tempRevision.File_Description = revision.File_Description;
                                                    tempRevision.File_Extension = revision.File_Extension;
                                                    tempRevision.File_MIMEType = revision.File_MIMEType;
                                                    tempRevision.File_Name = revision.File_Name;
                                                    tempRevision.File_ServerLocation = revision.File_ServerLocation;
                                                    tempRevision.File_Size_Bytes = revision.File_Size_Bytes;
                                                    tempRevision.File_SourceLocation = revision.File_SourceLocation;
                                                    tempRevision.IsLastRevision = revision.IsLastRevision;
                                                    tempRevision.IsLocked = revision.IsLocked;
                                                    tempRevision.Revision = revision.Revision;

                                                    revList.Add(tempRevision);
                                                }

                                                tempDoc.Revisions = revList.ToArray();

                                                docList.Add(tempDoc);
                                            }

                                            P_L3DO_GDSfPRID_1513 parStructure = new P_L3DO_GDSfPRID_1513();
                                            parStructure.ID = Parameter.ID;
                                            var documentStructures = cls_Get_DocumentStructures_for_ProductReleaseID.Invoke(Connection, Transaction, parStructure, securityTicket).Result;

                                            foreach (var ds in documentStructures)
                                            {
                                                L3DO_GDSfBTID_1117 temp = new L3DO_GDSfBTID_1117();
                                                temp.DOC_StructureID = ds.DOC_StructureID;
                                                temp.Label = ds.Label;
                                                temp.Parent_RefID = ds.Parent_RefID;
                                                temp.Structure_Header_RefID = ds.Structure_Header_RefID;

                                                docStructList.Add(temp);
                                            }

                                            returnValue.Result.Documents = docList.ToArray();
                                            returnValue.Result.DocumentStructures = docStructList.ToArray();
                                            returnValue.Result.DocumentParentType = "ProductRelease";
                                        }
                                        else
                                        {
                                            var productVariantQuery = new ORM_CMN_PRO_Product_Variant.Query();
                                            productVariantQuery.CMN_PRO_Product_VariantID = Parameter.ID;
                                            var productVariantList = ORM_CMN_PRO_Product_Variant.Query.Search(Connection, Transaction, productVariantQuery);

                                            if (productVariantList.Count != 0)
                                            {
                                                P_L3DO_GDfPVID_0854 parameter = new P_L3DO_GDfPVID_0854();
                                                parameter.ID = Parameter.ID;
                                                var documentList = cls_Get_Documents_for_ProductVariantID.Invoke(Connection, Transaction, parameter, securityTicket).Result;
                                                foreach (var doc in documentList)
                                                {
                                                    L3DO_GDfBTID_1725 tempDoc = new L3DO_GDfBTID_1725();
                                                    tempDoc.Alias = doc.Alias;
                                                    tempDoc.AssignmentID = doc.AssignmentID;
                                                    tempDoc.DOC_DocumentID = doc.DOC_DocumentID;
                                                    tempDoc.PrimaryType = doc.PrimaryType;
                                                    tempDoc.Structure_RefID = doc.Structure_RefID;
                                                    tempDoc.StructureHeader_RefID = doc.StructureHeader_RefID;
                                                    foreach (var revision in doc.Revisions)
                                                    {
                                                        L3DO_GDfBTID_1725a tempRevision = new L3DO_GDfBTID_1725a();
                                                        tempRevision.Creation_Timestamp = revision.Creation_Timestamp;
                                                        tempRevision.DOC_DocumentRevisionID = revision.DOC_DocumentRevisionID;
                                                        tempRevision.Document_RefID = revision.Document_RefID;
                                                        tempRevision.File_Description = revision.File_Description;
                                                        tempRevision.File_Extension = revision.File_Extension;
                                                        tempRevision.File_MIMEType = revision.File_MIMEType;
                                                        tempRevision.File_Name = revision.File_Name;
                                                        tempRevision.File_ServerLocation = revision.File_ServerLocation;
                                                        tempRevision.File_Size_Bytes = revision.File_Size_Bytes;
                                                        tempRevision.File_SourceLocation = revision.File_SourceLocation;
                                                        tempRevision.IsLastRevision = revision.IsLastRevision;
                                                        tempRevision.IsLocked = revision.IsLocked;
                                                        tempRevision.Revision = revision.Revision;

                                                        revList.Add(tempRevision);
                                                    }

                                                    tempDoc.Revisions = revList.ToArray();

                                                    docList.Add(tempDoc);
                                                }

                                                P_L3DO_GDSfPVID_1515 parStructure = new P_L3DO_GDSfPVID_1515();
                                                parStructure.ID = Parameter.ID;
                                                var documentStructures = cls_Get_DocumentStructures_for_ProductVariantID.Invoke(Connection, Transaction, parStructure, securityTicket).Result;

                                                foreach (var ds in documentStructures)
                                                {
                                                    L3DO_GDSfBTID_1117 temp = new L3DO_GDSfBTID_1117();
                                                    temp.DOC_StructureID = ds.DOC_StructureID;
                                                    temp.Label = ds.Label;
                                                    temp.Parent_RefID = ds.Parent_RefID;
                                                    temp.Structure_Header_RefID = ds.Structure_Header_RefID;

                                                    docStructList.Add(temp);
                                                }

                                                returnValue.Result.Documents = docList.ToArray();
                                                returnValue.Result.DocumentStructures = docStructList.ToArray();
                                                returnValue.Result.DocumentParentType = "ProductVariant";
                                            }
                                            else
                                            {
                                                var noteRevisionQuery = new ORM_CMN_NoteRevision.Query();
                                                noteRevisionQuery.CMN_NoteRevisionID = Parameter.ID;
                                                var noteRevisionList = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, noteRevisionQuery);

                                                if (productVariantList.Count != 0)
                                                {
                                                    P_L3DO_GDfNRID_1110 parameter = new P_L3DO_GDfNRID_1110();
                                                    parameter.ID = Parameter.ID;
                                                    var documentList = cls_Get_Documents_for_NoteRevisionID.Invoke(Connection, Transaction, parameter, securityTicket).Result;
                                                    foreach (var doc in documentList)
                                                    {
                                                        L3DO_GDfBTID_1725 tempDoc = new L3DO_GDfBTID_1725();
                                                        tempDoc.Alias = doc.Alias;
                                                        tempDoc.AssignmentID = doc.AssignmentID;
                                                        tempDoc.DOC_DocumentID = doc.DOC_DocumentID;
                                                        tempDoc.PrimaryType = doc.PrimaryType;
                                                        tempDoc.Structure_RefID = doc.Structure_RefID;
                                                        tempDoc.StructureHeader_RefID = doc.StructureHeader_RefID;
                                                        foreach (var revision in doc.Revisions)
                                                        {
                                                            L3DO_GDfBTID_1725a tempRevision = new L3DO_GDfBTID_1725a();
                                                            tempRevision.Creation_Timestamp = revision.Creation_Timestamp;
                                                            tempRevision.DOC_DocumentRevisionID = revision.DOC_DocumentRevisionID;
                                                            tempRevision.Document_RefID = revision.Document_RefID;
                                                            tempRevision.File_Description = revision.File_Description;
                                                            tempRevision.File_Extension = revision.File_Extension;
                                                            tempRevision.File_MIMEType = revision.File_MIMEType;
                                                            tempRevision.File_Name = revision.File_Name;
                                                            tempRevision.File_ServerLocation = revision.File_ServerLocation;
                                                            tempRevision.File_Size_Bytes = revision.File_Size_Bytes;
                                                            tempRevision.File_SourceLocation = revision.File_SourceLocation;
                                                            tempRevision.IsLastRevision = revision.IsLastRevision;
                                                            tempRevision.IsLocked = revision.IsLocked;
                                                            tempRevision.Revision = revision.Revision;

                                                            revList.Add(tempRevision);
                                                        }

                                                        tempDoc.Revisions = revList.ToArray();

                                                        docList.Add(tempDoc);
                                                    }

                                                    P_L3DO_GDSfNRID_1510 parStructure = new P_L3DO_GDSfNRID_1510();
                                                    parStructure.ID = Parameter.ID;
                                                    var documentStructures = cls_Get_DocumentStructures_for_NoteRevisionID.Invoke(Connection, Transaction, parStructure, securityTicket).Result;

                                                    foreach (var ds in documentStructures)
                                                    {
                                                        L3DO_GDSfBTID_1117 temp = new L3DO_GDSfBTID_1117();
                                                        temp.DOC_StructureID = ds.DOC_StructureID;
                                                        temp.Label = ds.Label;
                                                        temp.Parent_RefID = ds.Parent_RefID;
                                                        temp.Structure_Header_RefID = ds.Structure_Header_RefID;

                                                        docStructList.Add(temp);
                                                    }

                                                    returnValue.Result.Documents = docList.ToArray();
                                                    returnValue.Result.DocumentStructures = docStructList.ToArray();
                                                    returnValue.Result.DocumentParentType = "NoteRevision";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
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
		public static FR_L6DO_GDaDSfID_1658 Invoke(string ConnectionString,P_L6DO_GDaDSfID_1658 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DO_GDaDSfID_1658 Invoke(DbConnection Connection,P_L6DO_GDaDSfID_1658 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DO_GDaDSfID_1658 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DO_GDaDSfID_1658 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DO_GDaDSfID_1658 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DO_GDaDSfID_1658 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DO_GDaDSfID_1658 functionReturn = new FR_L6DO_GDaDSfID_1658();
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

				throw new Exception("Exception occured in method cls_Get_Document_and_DocumentStructures_for_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DO_GDaDSfID_1658 : FR_Base
	{
		public L6DO_GDaDSfID_1658 Result	{ get; set; }

		public FR_L6DO_GDaDSfID_1658() : base() {}

		public FR_L6DO_GDaDSfID_1658(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DO_GDaDSfID_1658 for attribute P_L6DO_GDaDSfID_1658
		[DataContract]
		public class P_L6DO_GDaDSfID_1658 
		{
			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L6DO_GDaDSfID_1658 for attribute L6DO_GDaDSfID_1658
		[DataContract]
		public class L6DO_GDaDSfID_1658 
		{
			//Standard type parameters
			[DataMember]
			public L3DO_GDfBTID_1725[] Documents { get; set; } 
			[DataMember]
			public L3DO_GDSfBTID_1117[] DocumentStructures { get; set; } 
			[DataMember]
			public String DocumentParentType { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DO_GDaDSfID_1658 cls_Get_Document_and_DocumentStructures_for_ID(,P_L6DO_GDaDSfID_1658 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DO_GDaDSfID_1658 invocationResult = cls_Get_Document_and_DocumentStructures_for_ID.Invoke(connectionString,P_L6DO_GDaDSfID_1658 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_Document.Complex.Retrieval.P_L6DO_GDaDSfID_1658();
parameter.ID = ...;

*/
