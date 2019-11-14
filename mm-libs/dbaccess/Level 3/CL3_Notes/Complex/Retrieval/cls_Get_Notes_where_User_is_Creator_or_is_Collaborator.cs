/* 
 * Generated on 11/19/2014 4:24:01 PM
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
using CL3_Notes.Atomic.Retrieval;
using CL1_TMS_PRO;
using CL2_AccountInformation.Atomic.Retrieval;
using CL1_CMN;
using CL1_CMN_BPT;
using CL1_USR;

namespace CL3_Notes.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Notes_where_User_is_Creator_or_is_Collaborator.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Notes_where_User_is_Creator_or_is_Collaborator
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3NO_GNwUiCoiC_1032_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3NO_GNwUiCoiC_1032_Array();
			//Put your code here
            List<L3NO_GNwUiCoiC_1032> notes = new List<L3NO_GNwUiCoiC_1032>();
            //************************************************************************************************//
            #region GETTING NOTES CREATED BY USER
            
            var ProjectNotesCreatedByCurrentUser = cls_Get_All_ProjectNotes_Created_by_AccountID.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            
            foreach (var item in ProjectNotesCreatedByCurrentUser)
            {
                L3NO_GNwUiCoiC_1032 note = new L3NO_GNwUiCoiC_1032();
                note.NoteID = item.CMN_NoteID;
                //setting project info
                L3NO_GNwUiCoiC_1032c projectInfo = new L3NO_GNwUiCoiC_1032c();

                projectInfo.ProjectID = item.Project_RefID;
                var project=ORM_TMS_PRO_Project.Query.Search(Connection,Transaction, new ORM_TMS_PRO_Project.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    TMS_PRO_ProjectID = item.Project_RefID,
                    IsDeleted = false
                }).SingleOrDefault();
                if (project != null)
                {
                    projectInfo.ProjectName = project.Name;
                    note.ProjectInfo = projectInfo;
                    note.ProjectNoteID = item.TMS_PRO_Project_NoteID;
                    note.CurrentVersionID = item.Current_NoteRevision_RefID;
                    //setting collaborators info
                    List<L3NO_GNwUiCoiC_1032a> collaboratorsInfo = new List<L3NO_GNwUiCoiC_1032a>();

                    var collaboratorsForProjectNoteID = ORM_TMS_PRO_Project_Note_Collaborators.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project_Note_Collaborators.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        ProjectNote_RefID = item.TMS_PRO_Project_NoteID,
                        IsDeleted = false
                    });

                    foreach (var collaborator in collaboratorsForProjectNoteID)
                    {
                        L3NO_GNwUiCoiC_1032a collInfo = new L3NO_GNwUiCoiC_1032a();
                        collInfo.AccountID = collaborator.Account_RefID;
                        collInfo.CollaboratorID = collaborator.TMS_PRO_Project_Note_CollaboratorID;

                        P_L2AI_GAPIfAI_1627 userParameter = new P_L2AI_GAPIfAI_1627();
                        userParameter.AccountRefID = collaborator.Account_RefID;
                        var userinfo = cls_Get_Account_PersonalInformation_for_AccountID.Invoke(Connection, Transaction, userParameter, securityTicket).Result;
                        collInfo.FirstAndLastName = userinfo.FirstName + " " + userinfo.LastName;
                        collaboratorsInfo.Add(collInfo);
                    }
                    note.CollaboratorsInfo = collaboratorsInfo.ToArray();
                    //setting tags info
                    List<L3NO_GNwUiCoiC_1032b> tagsInfo = new List<L3NO_GNwUiCoiC_1032b>();
                    P_L3N_GTfPNID_1415 tagsParameter = new P_L3N_GTfPNID_1415();
                    tagsParameter.ProjectNoteID = item.TMS_PRO_Project_NoteID;
                    var tagsForProjectNoteID = cls_Get_Tags_for_ProjectNoteID.Invoke(Connection, Transaction, tagsParameter, securityTicket).Result.ToList();
                    foreach (var tag in tagsForProjectNoteID)
                    {
                        L3NO_GNwUiCoiC_1032b tagInfo = new L3NO_GNwUiCoiC_1032b();
                        tagInfo.TagID = tag.TMS_PRO_TagID;
                        tagInfo.TagValue = tag.TagValue;
                        tagsInfo.Add(tagInfo);
                    }
                    note.TagsInfo = tagsInfo.ToArray();
                    //setting current note version
                    var lastnoterevision = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, new ORM_CMN_NoteRevision.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_NoteRevisionID = item.Current_NoteRevision_RefID,
                        IsDeleted = false
                    });
                    if (lastnoterevision != null && lastnoterevision.Count != 0)
                    {
                        note.NoteVersion = lastnoterevision.First().Version.ToString();
                    }
                    else
                    {
                        note.NoteVersion = "1";
                    }
                    
                    //setting all note revisions
                    
                    List<L3NO_GNwUiCoiC_1032d> noteRevisionsInfo = new List<L3NO_GNwUiCoiC_1032d>();

                    P_L3N_GNRfNID_1559 revisionsParameter = new P_L3N_GNRfNID_1559();
                    revisionsParameter.NoteID = item.CMN_NoteID;
                    var noteRevisionsForNote = cls_Get_NoteRevisions_for_NoteID.Invoke(Connection, Transaction, revisionsParameter, securityTicket).Result.ToList();
                    foreach (var noteRevision in noteRevisionsForNote)
                    {
                        L3NO_GNwUiCoiC_1032d noteRevisionInfo = new L3NO_GNwUiCoiC_1032d();
                        noteRevisionInfo.NoteRevisionID = noteRevision.CMN_NoteRevisionID;
                        noteRevisionInfo.NoteRevisionContent = noteRevision.Content;
                        noteRevisionInfo.NoteRevisionCreatedOn = noteRevision.Creation_Timestamp;
                        noteRevisionInfo.NoteRevisionModifiedOn = noteRevision.Modification_Timestamp;
                        noteRevisionInfo.NoteRevisionTitle = noteRevision.Title;
                        noteRevisionInfo.NoteRevisionVersion = noteRevision.Version;
                        noteRevisionInfo.NoteRevisionCreatorID = noteRevision.CreatedBy_BusinessParticipant_RefID;

                        var revisionCreator = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                        {
                            //TODO: For future publish,if creator business participant is deleted, do not display his name and offer collaborators option to delete note revision and note
                            Tenant_RefID = securityTicket.TenantID,
                            CMN_BPT_BusinessParticipantID = noteRevision.CreatedBy_BusinessParticipant_RefID
                        }).SingleOrDefault();
                        if (revisionCreator != null)
                            noteRevisionInfo.NoteRevisionCreatorFirstAndLastName = revisionCreator.DisplayName;
                        noteRevisionsInfo.Add(noteRevisionInfo);
                    }
                    note.NoteRevisionInfo = noteRevisionsInfo.ToArray();

                    var NoteCreator = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                    {
                        //TODO: For future publish,if creator business participant is deleted, do not display his name and offer collaborators option to delete note
                        CMN_BPT_BusinessParticipantID = item.CreatedBy_BusinessParticipant_RefID,
                        Tenant_RefID = securityTicket.TenantID
                    }).SingleOrDefault();
                    L3NO_GNwUiCoiC_1032e noteCreator = new L3NO_GNwUiCoiC_1032e();
                    ORM_USR_Account user = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                    {
                        BusinessParticipant_RefID = item.CreatedBy_BusinessParticipant_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).SingleOrDefault();
                    if (user != null)
                    {
                        noteCreator.CreatorID = user.USR_AccountID;
                        P_L2AI_GAPIfAI_1627 personalInfoParameter = new P_L2AI_GAPIfAI_1627();
                        personalInfoParameter.AccountRefID = user.USR_AccountID;
                        var personalInfoForUser = cls_Get_Account_PersonalInformation_for_AccountID.Invoke(Connection, Transaction, personalInfoParameter, securityTicket).Result;
                        if (personalInfoForUser != null)
                            noteCreator.CreatorFirstAndLastName = personalInfoForUser.FirstName + " " + personalInfoForUser.LastName;
                    }
                    note.NoteCreatorInfo = noteCreator;
                    note.LastEdited = item.Modification_Timestamp;
                    note.CreatedOn = item.Creation_Timestamp;
                    notes.Add(note);
                }
                
            }
            #endregion
            //************************************************************************************************//
            #region GETTING NOTES WHERE USER IS COLLABORATOR

            var ProjectNotesWhereCurrentUserIsCollaborator = cls_Get_All_ProjectNotes_Where_Current_User_is_Collaborator.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            foreach (var item in ProjectNotesWhereCurrentUserIsCollaborator)
            {
                L3NO_GNwUiCoiC_1032 note = new L3NO_GNwUiCoiC_1032();
                note.NoteID = item.CMN_NoteID;
                //setting project info
                L3NO_GNwUiCoiC_1032c projectInfo = new L3NO_GNwUiCoiC_1032c();

                projectInfo.ProjectID = item.Project_RefID;
                ORM_TMS_PRO_Project project = ORM_TMS_PRO_Project.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    TMS_PRO_ProjectID = item.Project_RefID,
                    IsDeleted = false
                }).SingleOrDefault();
                if (project != null)
                {
                    projectInfo.ProjectName = project.Name;
                    note.ProjectInfo = projectInfo;
                    note.ProjectNoteID = item.TMS_PRO_Project_NoteID;
                    note.CurrentVersionID = item.Current_NoteRevision_RefID;
                    //setting collaborators info
                    List<L3NO_GNwUiCoiC_1032a> collaboratorsInfo = new List<L3NO_GNwUiCoiC_1032a>();

                    var collaboratorsForProjectNoteID = ORM_TMS_PRO_Project_Note_Collaborators.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project_Note_Collaborators.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        ProjectNote_RefID = item.TMS_PRO_Project_NoteID,
                        IsDeleted = false
                    });

                    foreach (var collaborator in collaboratorsForProjectNoteID)
                    {
                        L3NO_GNwUiCoiC_1032a collInfo = new L3NO_GNwUiCoiC_1032a();
                        collInfo.AccountID = collaborator.Account_RefID;
                        collInfo.CollaboratorID = collaborator.TMS_PRO_Project_Note_CollaboratorID;

                        P_L2AI_GAPIfAI_1627 userParameter = new P_L2AI_GAPIfAI_1627();
                        userParameter.AccountRefID = collaborator.Account_RefID;
                        var userinfo = cls_Get_Account_PersonalInformation_for_AccountID.Invoke(Connection, Transaction, userParameter, securityTicket).Result;
                        collInfo.FirstAndLastName = userinfo.FirstName + " " + userinfo.LastName;
                        collaboratorsInfo.Add(collInfo);
                    }
                    note.CollaboratorsInfo = collaboratorsInfo.ToArray();
                    //setting tags info
                    List<L3NO_GNwUiCoiC_1032b> tagsInfo = new List<L3NO_GNwUiCoiC_1032b>();
                    P_L3N_GTfPNID_1415 tagsParameter = new P_L3N_GTfPNID_1415();
                    tagsParameter.ProjectNoteID = item.TMS_PRO_Project_NoteID;
                    var tagsForProjectNoteID = cls_Get_Tags_for_ProjectNoteID.Invoke(Connection, Transaction, tagsParameter, securityTicket).Result.ToList();
                    foreach (var tag in tagsForProjectNoteID)
                    {
                        L3NO_GNwUiCoiC_1032b tagInfo = new L3NO_GNwUiCoiC_1032b();
                        tagInfo.TagID = tag.TMS_PRO_TagID;
                        tagInfo.TagValue = tag.TagValue;
                        tagsInfo.Add(tagInfo);
                    }
                    note.TagsInfo = tagsInfo.ToArray();
                    //setting current note version
                    var lastnoterevision = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, new ORM_CMN_NoteRevision.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_NoteRevisionID = item.Current_NoteRevision_RefID,
                        IsDeleted = false
                    });
                    if (lastnoterevision != null && lastnoterevision.Count != 0)
                    {
                        note.NoteVersion = lastnoterevision.First().Version.ToString();
                    }
                    else
                    {
                        note.NoteVersion = "1";
                    }
                    //setting all note revisions
                    List<L3NO_GNwUiCoiC_1032d> noteRevisionsInfo = new List<L3NO_GNwUiCoiC_1032d>();

                    P_L3N_GNRfNID_1559 revisionsParameter = new P_L3N_GNRfNID_1559();
                    revisionsParameter.NoteID = item.CMN_NoteID;
                    var noteRevisionsForNote = cls_Get_NoteRevisions_for_NoteID.Invoke(Connection, Transaction, revisionsParameter, securityTicket).Result.ToList();
                    foreach (var noteRevision in noteRevisionsForNote)
                    {
                        L3NO_GNwUiCoiC_1032d noteRevisionInfo = new L3NO_GNwUiCoiC_1032d();
                        noteRevisionInfo.NoteRevisionID = noteRevision.CMN_NoteRevisionID;
                        noteRevisionInfo.NoteRevisionContent = noteRevision.Content;
                        noteRevisionInfo.NoteRevisionCreatedOn = noteRevision.Creation_Timestamp;
                        noteRevisionInfo.NoteRevisionModifiedOn = noteRevision.Modification_Timestamp;
                        noteRevisionInfo.NoteRevisionTitle = noteRevision.Title;
                        noteRevisionInfo.NoteRevisionVersion = noteRevision.Version;
                        noteRevisionInfo.NoteRevisionCreatorID = noteRevision.CreatedBy_BusinessParticipant_RefID;

                        var revisionCreator = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                        {
                            IsDeleted = false,
                            CMN_BPT_BusinessParticipantID = noteRevision.CreatedBy_BusinessParticipant_RefID
                        }).SingleOrDefault();
                        if (revisionCreator != null)
                            noteRevisionInfo.NoteRevisionCreatorFirstAndLastName = revisionCreator.DisplayName;
                        noteRevisionsInfo.Add(noteRevisionInfo);
                    }
                    note.NoteRevisionInfo = noteRevisionsInfo.ToArray();

                    var NoteCreator = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                    {
                        IsDeleted = false,
                        CMN_BPT_BusinessParticipantID = item.CreatedBy_BusinessParticipant_RefID

                    }).SingleOrDefault();
                    L3NO_GNwUiCoiC_1032e noteCreator = new L3NO_GNwUiCoiC_1032e();
                    ORM_USR_Account user = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                    {
                        BusinessParticipant_RefID = item.CreatedBy_BusinessParticipant_RefID,
                        IsDeleted=false,
                        Tenant_RefID=securityTicket.TenantID
                    }).SingleOrDefault();
                    if (user != null)
                    {
                        noteCreator.CreatorID = user.USR_AccountID;
                        P_L2AI_GAPIfAI_1627 personalInfoParameter = new P_L2AI_GAPIfAI_1627();
                        personalInfoParameter.AccountRefID = user.USR_AccountID;
                        var personalInfoForUser = cls_Get_Account_PersonalInformation_for_AccountID.Invoke(Connection, Transaction,personalInfoParameter, securityTicket).Result;
                        if (personalInfoForUser != null)
                            noteCreator.CreatorFirstAndLastName = personalInfoForUser.FirstName+" "+personalInfoForUser.LastName;
                    }
                    
                    note.NoteCreatorInfo = noteCreator;
                    note.LastEdited = item.Modification_Timestamp;
                    note.CreatedOn = item.Creation_Timestamp;
                    notes.Add(note);
                }
                
            }

            #endregion
            //************************************************************************************************//
            returnValue.Result = notes.ToArray();

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3NO_GNwUiCoiC_1032_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3NO_GNwUiCoiC_1032_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3NO_GNwUiCoiC_1032_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3NO_GNwUiCoiC_1032_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3NO_GNwUiCoiC_1032_Array functionReturn = new FR_L3NO_GNwUiCoiC_1032_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Notes_where_User_is_Creator_or_is_Collaborator",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3NO_GNwUiCoiC_1032_Array : FR_Base
	{
		public L3NO_GNwUiCoiC_1032[] Result	{ get; set; } 
		public FR_L3NO_GNwUiCoiC_1032_Array() : base() {}

		public FR_L3NO_GNwUiCoiC_1032_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3NO_GNwUiCoiC_1032 for attribute L3NO_GNwUiCoiC_1032
		[DataContract]
		public class L3NO_GNwUiCoiC_1032 
		{
			[DataMember]
			public L3NO_GNwUiCoiC_1032a[] CollaboratorsInfo { get; set; }
			[DataMember]
			public L3NO_GNwUiCoiC_1032b[] TagsInfo { get; set; }
			[DataMember]
			public L3NO_GNwUiCoiC_1032c ProjectInfo { get; set; }
			[DataMember]
			public L3NO_GNwUiCoiC_1032d[] NoteRevisionInfo { get; set; }
			[DataMember]
			public L3NO_GNwUiCoiC_1032e NoteCreatorInfo { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid NoteID { get; set; } 
			[DataMember]
			public Guid ProjectNoteID { get; set; } 
			[DataMember]
			public Guid CurrentVersionID { get; set; } 
			[DataMember]
			public DateTime LastEdited { get; set; } 
			[DataMember]
			public DateTime CreatedOn { get; set; } 
			[DataMember]
			public String NoteVersion { get; set; } 

		}
		#endregion
		#region SClass L3NO_GNwUiCoiC_1032a for attribute CollaboratorsInfo
		[DataContract]
		public class L3NO_GNwUiCoiC_1032a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CollaboratorID { get; set; } 
			[DataMember]
			public Guid AccountID { get; set; } 
			[DataMember]
			public String FirstAndLastName { get; set; } 

		}
		#endregion
		#region SClass L3NO_GNwUiCoiC_1032b for attribute TagsInfo
		[DataContract]
		public class L3NO_GNwUiCoiC_1032b 
		{
			//Standard type parameters
			[DataMember]
			public Guid TagID { get; set; } 
			[DataMember]
			public String TagValue { get; set; } 

		}
		#endregion
		#region SClass L3NO_GNwUiCoiC_1032c for attribute ProjectInfo
		[DataContract]
		public class L3NO_GNwUiCoiC_1032c 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectID { get; set; } 
			[DataMember]
			public Dict ProjectName { get; set; } 

		}
		#endregion
		#region SClass L3NO_GNwUiCoiC_1032d for attribute NoteRevisionInfo
		[DataContract]
		public class L3NO_GNwUiCoiC_1032d 
		{
			//Standard type parameters
			[DataMember]
			public Guid NoteRevisionID { get; set; } 
			[DataMember]
			public Guid NoteRevisionCreatorID { get; set; } 
			[DataMember]
			public String NoteRevisionCreatorFirstAndLastName { get; set; } 
			[DataMember]
			public String NoteRevisionTitle { get; set; } 
			[DataMember]
			public String NoteRevisionContent { get; set; } 
			[DataMember]
			public int NoteRevisionVersion { get; set; } 
			[DataMember]
			public DateTime NoteRevisionCreatedOn { get; set; } 
			[DataMember]
			public DateTime NoteRevisionModifiedOn { get; set; } 

		}
		#endregion
		#region SClass L3NO_GNwUiCoiC_1032e for attribute NoteCreatorInfo
		[DataContract]
		public class L3NO_GNwUiCoiC_1032e 
		{
			//Standard type parameters
			[DataMember]
			public Guid CreatorID { get; set; } 
			[DataMember]
			public String CreatorFirstAndLastName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3NO_GNwUiCoiC_1032_Array cls_Get_Notes_where_User_is_Creator_or_is_Collaborator(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3NO_GNwUiCoiC_1032_Array invocationResult = cls_Get_Notes_where_User_is_Creator_or_is_Collaborator.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

