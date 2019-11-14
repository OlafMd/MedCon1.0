/* 
 * Generated on 12/2/2014 9:51:54 AM
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
using CL1_CMN;
using CL1_USR;

namespace CL3_Notes.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_NewNote.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_NewNote
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3N_SNN_0921 Execute(DbConnection Connection,DbTransaction Transaction,P_L3N_SNN_0921 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3N_SNN_0921();
			//Put your code here
            if (Parameter.SaveType == "SaveNewVersion")
            {
                if (Parameter.SaveOnlyNewVersion) 
                {
                    //only title/content has been changed
                    ORM_TMS_PRO_Project_Notes newProjectNote = new ORM_TMS_PRO_Project_Notes();
                    //save new note version
                    ORM_CMN_NoteRevision newNoteVersion = new ORM_CMN_NoteRevision();
                    newNoteVersion.CMN_NoteRevisionID = Guid.NewGuid();
                    newNoteVersion.Content = Parameter.Content;
                    newNoteVersion.Title = Parameter.Title;
                    newNoteVersion.Tenant_RefID = securityTicket.TenantID;
                    newNoteVersion.Note_RefID = Parameter.NoteID;
                    ORM_CMN_Note note = ORM_CMN_Note.Query.Search(Connection, Transaction, new ORM_CMN_Note.Query()
                    {
                        CMN_NoteID = Parameter.NoteID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();


                    if (note != null)
                    {
                        ORM_CMN_NoteRevision currentNoteVersion = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, new ORM_CMN_NoteRevision.Query()
                        {
                            CMN_NoteRevisionID = Parameter.NoteRevisionID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                        if (currentNoteVersion != null)
                        {
                            if (Parameter.SaveOverVersion)
                            {
                                newNoteVersion.Version = currentNoteVersion.Version;
                            }
                            else
                            {
                                newNoteVersion.Version = currentNoteVersion.Version + 1;
                            }
                            
                            note.Current_NoteRevision_RefID = newNoteVersion.CMN_NoteRevisionID;
                            note.Save(Connection, Transaction);
                        }
                    }

                    ORM_USR_Account creator = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                    {
                        USR_AccountID = Parameter.CreatorID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();
                    newNoteVersion.CreatedBy_BusinessParticipant_RefID = creator.BusinessParticipant_RefID;
                    newNoteVersion.Save(Connection, Transaction);
                }
                    
                else
                {
                    ORM_CMN_Note newNote = new ORM_CMN_Note();
                    newNote.CMN_NoteID = Guid.NewGuid();
                    newNote.Tenant_RefID = securityTicket.TenantID;
                    ORM_USR_Account currentUser = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                    {
                        USR_AccountID = securityTicket.AccountID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false

                    }).Single();
                    newNote.CreatedBy_BusinessParticipant_RefID = currentUser.BusinessParticipant_RefID;

                    //create first version of note
                    
                    ORM_CMN_NoteRevision newNoteVersion = new ORM_CMN_NoteRevision();
                    newNoteVersion.CMN_NoteRevisionID = Guid.NewGuid();
                    newNoteVersion.Content = Parameter.Content;
                    newNoteVersion.Title = Parameter.Title;
                    newNoteVersion.Tenant_RefID = securityTicket.TenantID;
                    newNoteVersion.Note_RefID = newNote.CMN_NoteID;
                    newNoteVersion.CreatedBy_BusinessParticipant_RefID = currentUser.BusinessParticipant_RefID;
                    /*******/
                    ORM_CMN_Note note = ORM_CMN_Note.Query.Search(Connection, Transaction, new ORM_CMN_Note.Query()
                    {
                        CMN_NoteID = Parameter.NoteID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();


                    if (note != null)
                    {
                        if (Parameter.SaveOverVersion)
                        {
                            ORM_CMN_NoteRevision passedNoteVersion = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, new ORM_CMN_NoteRevision.Query()
                            {
                                CMN_NoteRevisionID = Parameter.NoteRevisionID,
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false
                            }).SingleOrDefault();

                            newNoteVersion.Version = passedNoteVersion.Version;
                        }
                        else
                        {
                            ORM_CMN_NoteRevision currentNoteVersion = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, new ORM_CMN_NoteRevision.Query()
                            {
                                CMN_NoteRevisionID = Parameter.NoteRevisionID,
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false
                            }).SingleOrDefault();
                            newNoteVersion.Version = currentNoteVersion.Version + 1;
                        }

                    }
                    /********/


                    newNoteVersion.Save(Connection, Transaction);

                    newNote.Current_NoteRevision_RefID = newNoteVersion.CMN_NoteRevisionID;


                    ORM_TMS_PRO_Project_Notes projectNote = new ORM_TMS_PRO_Project_Notes();

                   
                        ORM_TMS_PRO_Project_Notes newProjectNote = new ORM_TMS_PRO_Project_Notes();
                        newProjectNote.Ext_CMN_Note_RefID = newNote.CMN_NoteID;
                        newProjectNote.Project_RefID = Parameter.ProjectID;
                        newProjectNote.Tenant_RefID = securityTicket.TenantID;
                        newProjectNote.TMS_PRO_Project_NoteID = Guid.NewGuid();
                        newProjectNote.Save(Connection,Transaction);
                        projectNote = newProjectNote;
                  

                    // ADDING/REMOVING COLLABORATORS
                    if(Parameter.Collaborators!=null && Parameter.Collaborators.Count()!=0)
                    {
                       
                            //check which project members to remove and which to add
                            var collaboratorsForProjectNote = ORM_TMS_PRO_Project_Note_Collaborators.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project_Note_Collaborators.Query()
                            {
                                ProjectNote_RefID = projectNote.TMS_PRO_Project_NoteID,
                                Tenant_RefID=securityTicket.TenantID,
                                IsDeleted = false
                            });
                            foreach (var collab in collaboratorsForProjectNote)
                            {

                                if (!Parameter.Collaborators.Contains(collab.Account_RefID))
                                {
                                    ORM_TMS_PRO_Project_Note_Collaborators CollaboratorToDelete = ORM_TMS_PRO_Project_Note_Collaborators.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project_Note_Collaborators.Query()
                                    {
                                        Account_RefID=collab.Account_RefID,
                                        IsDeleted=false,
                                        Tenant_RefID=securityTicket.TenantID
                                    }).Single();
                                    CollaboratorToDelete.IsDeleted = true;
                                    CollaboratorToDelete.Save(Connection,Transaction);
                                }
                                
                            }

                            foreach (var newCollab in Parameter.Collaborators)
                            {
                                if (!collaboratorsForProjectNote.Exists(cpn=>cpn.Account_RefID==newCollab))
                                {
                                    ORM_TMS_PRO_Project_Note_Collaborators newCollaborator = new ORM_TMS_PRO_Project_Note_Collaborators();
                                    newCollaborator.TMS_PRO_Project_Note_CollaboratorID = Guid.NewGuid();
                                    newCollaborator.Tenant_RefID = securityTicket.TenantID;
                                    newCollaborator.ProjectNote_RefID = projectNote.TMS_PRO_Project_NoteID;
                                    newCollaborator.Account_RefID = newCollab;
                                    newCollaborator.Save(Connection, Transaction);
                                }
                            }
                            
                            
                        
                    }
                    // ADDING/REMOVING TAGS
                    if (Parameter.Tags != null && Parameter.Tags.Count() != 0)
                    {
                       
                          foreach (var tag in Parameter.Tags)
                        {
                            
                            
                            ORM_TMS_PRO_Tags existingTag = ORM_TMS_PRO_Tags.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Tags.Query()
                            {
                                TMS_PRO_TagID = tag.TagID,
                                IsDeleted=false,
                                Tenant_RefID = securityTicket.TenantID
                            }).SingleOrDefault();

                            if (existingTag == null)
                            {
                                ORM_TMS_PRO_Tags newTag = new ORM_TMS_PRO_Tags();
                                newTag.TMS_PRO_TagID = Guid.NewGuid();
                                newTag.TagValue = tag.TagValue;
                                newTag.Tenant_RefID = securityTicket.TenantID;
                                newTag.Save(Connection, Transaction);

                                ORM_TMS_PRO_Project_Note_2_Tag newTagToNote = new ORM_TMS_PRO_Project_Note_2_Tag();
                                newTagToNote.AssignmentID = Guid.NewGuid();
                                newTagToNote.Project_Note_RefID = newProjectNote.TMS_PRO_Project_NoteID;
                                newTagToNote.Tag_RefID = newTag.TMS_PRO_TagID;
                                newTagToNote.Save(Connection, Transaction);
                            }
                            else
                            {
                                ORM_TMS_PRO_Project_Note_2_Tag newTagToNote = new ORM_TMS_PRO_Project_Note_2_Tag();
                                newTagToNote.AssignmentID = Guid.NewGuid();
                                newTagToNote.Project_Note_RefID = newProjectNote.TMS_PRO_Project_NoteID;
                                newTagToNote.Tag_RefID = existingTag.TMS_PRO_TagID;
                                newTagToNote.Save(Connection, Transaction);
                            }
                   
                        }
                         var allProjectNote2Tags = ORM_TMS_PRO_Project_Note_2_Tag.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project_Note_2_Tag.Query()
                            {
                                Project_Note_RefID=Parameter.ProjectNoteID,
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted=false
                            }
                            );
                         foreach (var projectNote2Tag in allProjectNote2Tags)
                         {
                             if (!Parameter.Tags.ToList().Exists(tag => tag.TagID == projectNote2Tag.Tag_RefID))
                             {
                                 var ProjectNote2TagToDelete = ORM_TMS_PRO_Project_Note_2_Tag.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project_Note_2_Tag.Query()
                                 {
                                     AssignmentID = projectNote2Tag.AssignmentID,
                                     Tenant_RefID = securityTicket.TenantID,
                                     IsDeleted = false
                                 }
                                ).Single();
                                 ProjectNote2TagToDelete.IsDeleted = true;
                                 ProjectNote2TagToDelete.Save(Connection, Transaction);
                             }
                         } 
                    }
                    newNote.Save(Connection, Transaction);
                    }
                    if (Parameter.SaveOverVersion)
                    {
                        var noteRevisionForRevisionID = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, new ORM_CMN_NoteRevision.Query()
                        {
                            CMN_NoteRevisionID = Parameter.NoteRevisionID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false

                        }).Single();

                        //note
                        ORM_CMN_Note noteToDelete = ORM_CMN_Note.Query.Search(Connection, Transaction, new ORM_CMN_Note.Query()
                        {
                            CMN_NoteID = Parameter.NoteID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false

                        }).Single();
                        //all versions of that note
                        var noteRevisionsForNoteID = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, new ORM_CMN_NoteRevision.Query()
                        {
                            Note_RefID = Parameter.NoteID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false

                        });

                        if (noteToDelete.Current_NoteRevision_RefID == noteRevisionForRevisionID.CMN_NoteRevisionID)
                        {
                            if (noteRevisionsForNoteID.Count() > 1)
                            {

                                //proveriti prvo da li je to trenutna verzija notea, ako jeste i ima ih jos onda brisi ovu, uzmi prethodnu 
                                var newCurrentNoteRevision = noteRevisionsForNoteID.Where(nr => nr.Version < noteRevisionForRevisionID.Version).First();
                                noteToDelete.Current_NoteRevision_RefID = newCurrentNoteRevision.CMN_NoteRevisionID;
                                noteRevisionForRevisionID.IsDeleted = true;
                                noteRevisionForRevisionID.Save(Connection, Transaction);
                                noteToDelete.Save(Connection, Transaction);
                            }
                            else if (noteRevisionsForNoteID.Count() == 1)
                            {

                                noteToDelete.IsDeleted = true;
                                noteToDelete.Save(Connection, Transaction);

                                var projectNotesToDelete = ORM_TMS_PRO_Project_Notes.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project_Notes.Query()
                                {
                                    Ext_CMN_Note_RefID = noteToDelete.CMN_NoteID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false
                                });
                                foreach (var item in projectNotesToDelete)
                                {
                                    item.IsDeleted = true;
                                    item.Save(Connection, Transaction);
                                    //delete collaborators and tags regarding that note

                                    var currentCollaborators = ORM_TMS_PRO_Project_Note_Collaborators.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project_Note_Collaborators.Query()
                                    {

                                        ProjectNote_RefID = item.TMS_PRO_Project_NoteID,
                                        Tenant_RefID = securityTicket.TenantID,
                                        IsDeleted = false

                                    });
                                    if (currentCollaborators != null)
                                    {
                                        foreach (var collaborator in currentCollaborators)
                                        {
                                            collaborator.IsDeleted = true;
                                            collaborator.Save(Connection, Transaction);
                                        }

                                    }
                                    ORM_TMS_PRO_Project_Note_2_Tag currentTags = ORM_TMS_PRO_Project_Note_2_Tag.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project_Note_2_Tag.Query()
                                    {
                                        Project_Note_RefID = item.TMS_PRO_Project_NoteID,
                                        Tenant_RefID = securityTicket.TenantID,
                                        IsDeleted = false

                                    }).SingleOrDefault();

                                    if (currentTags != null)
                                    {
                                        currentTags.IsDeleted = true;
                                        currentTags.Save(Connection, Transaction);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //izbrisi samo tu verziju
                            noteRevisionForRevisionID.IsDeleted = true;
                            noteRevisionForRevisionID.Save(Connection, Transaction);

                        }
                        //ako je to poslednja verzija tog notea, izbrisati i note.
                    }

            }
            else if (Parameter.SaveType == "SaveNewNote")
            {
                ORM_CMN_Note newNote = new ORM_CMN_Note();
                newNote.CMN_NoteID = Guid.NewGuid();
                newNote.Tenant_RefID = securityTicket.TenantID;
                ORM_USR_Account currentUser = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                {
                    USR_AccountID = securityTicket.AccountID,
                    Tenant_RefID = securityTicket.TenantID,
                    //IsDeleted = true
                }).Single();
                newNote.CreatedBy_BusinessParticipant_RefID = currentUser.BusinessParticipant_RefID;

                //create first version of note
                 
                ORM_CMN_NoteRevision newNoteVersion = new ORM_CMN_NoteRevision();
                newNoteVersion.CMN_NoteRevisionID = Guid.NewGuid();
                newNoteVersion.Content = Parameter.Content;
                newNoteVersion.Title = Parameter.Title;
                newNoteVersion.Tenant_RefID = securityTicket.TenantID;
                newNoteVersion.Note_RefID = newNote.CMN_NoteID;
                newNoteVersion.Version = 1;
                newNoteVersion.CreatedBy_BusinessParticipant_RefID = currentUser.BusinessParticipant_RefID;

                newNoteVersion.Save(Connection,Transaction);

                newNote.Current_NoteRevision_RefID = newNoteVersion.CMN_NoteRevisionID;

                //create new project note
                ORM_TMS_PRO_Project_Notes newProjectNote = new ORM_TMS_PRO_Project_Notes();
                newProjectNote.TMS_PRO_Project_NoteID = Guid.NewGuid();
                newProjectNote.Ext_CMN_Note_RefID = newNote.CMN_NoteID;
                newProjectNote.Tenant_RefID = securityTicket.TenantID;
                newProjectNote.Project_RefID = Parameter.ProjectID;

                newProjectNote.Save(Connection,Transaction);



                if (Parameter.Collaborators != null && Parameter.Collaborators.Count() != 0)
                {
                    foreach (var collab in Parameter.Collaborators)
                    {

                        ORM_TMS_PRO_Project_Note_Collaborators newCollaborators = new ORM_TMS_PRO_Project_Note_Collaborators();
                        newCollaborators.ProjectNote_RefID = newProjectNote.TMS_PRO_Project_NoteID;
                        newCollaborators.TMS_PRO_Project_Note_CollaboratorID = Guid.NewGuid();
                        newCollaborators.Tenant_RefID = securityTicket.TenantID;
                        newCollaborators.Account_RefID = collab;
                        newCollaborators.Save(Connection, Transaction);

                    }

                }
                if (Parameter.Tags != null && Parameter.Tags.Count() != 0)
                {
                    foreach (var tag in Parameter.Tags)
                    {
                        //todo: search by id
                        ORM_TMS_PRO_Tags existingTag = ORM_TMS_PRO_Tags.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Tags.Query()
                        {
                            TMS_PRO_TagID = tag.TagID,
                            IsDeleted=false,
                            Tenant_RefID = securityTicket.TenantID
                        }).SingleOrDefault();

                        if (existingTag == null)
                        {
                            ORM_TMS_PRO_Tags newTag = new ORM_TMS_PRO_Tags();
                            newTag.TMS_PRO_TagID = Guid.NewGuid();
                            newTag.TagValue = tag.TagValue;
                            newTag.Tenant_RefID = securityTicket.TenantID;
                            newTag.Save(Connection, Transaction);

                            ORM_TMS_PRO_Project_Note_2_Tag newTagToNote = new ORM_TMS_PRO_Project_Note_2_Tag();
                            newTagToNote.AssignmentID = Guid.NewGuid();
                            newTagToNote.Project_Note_RefID = newProjectNote.TMS_PRO_Project_NoteID;
                            newTagToNote.Tag_RefID = newTag.TMS_PRO_TagID;
                            newTagToNote.Save(Connection, Transaction);
                        }
                        else
                        {
                            ORM_TMS_PRO_Project_Note_2_Tag newTagToNote = new ORM_TMS_PRO_Project_Note_2_Tag();
                            newTagToNote.AssignmentID = Guid.NewGuid();
                            newTagToNote.Project_Note_RefID = newProjectNote.TMS_PRO_Project_NoteID;
                            newTagToNote.Tag_RefID = existingTag.TMS_PRO_TagID;
                            newTagToNote.Save(Connection, Transaction);
                        }
                    }

                }
                newNote.Save(Connection, Transaction);


                
            }
            else if (Parameter.SaveType == "DeleteNote")
            {
                var noteRevisionForRevisionID = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, new ORM_CMN_NoteRevision.Query()
                {
                    CMN_NoteRevisionID = Parameter.NoteRevisionID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false

                }).Single();

                //note
                ORM_CMN_Note noteToDelete = ORM_CMN_Note.Query.Search(Connection, Transaction, new ORM_CMN_Note.Query()
                {
                    CMN_NoteID = Parameter.NoteID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false

                }).Single();
                //all versions of that note
                var noteRevisionsForNoteID = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, new ORM_CMN_NoteRevision.Query()
                {
                    Note_RefID = Parameter.NoteID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false

                });

                if (noteToDelete.Current_NoteRevision_RefID == noteRevisionForRevisionID.CMN_NoteRevisionID)
                {
                    if (noteRevisionsForNoteID.Count() > 1)
                    {

                        //proveriti prvo da li je to trenutna verzija notea, ako jeste i ima ih jos onda brisi ovu, uzmi prethodnu 
                        var newCurrentNoteRevision = noteRevisionsForNoteID.Where(nr => nr.Version < noteRevisionForRevisionID.Version).First();
                        noteToDelete.Current_NoteRevision_RefID = newCurrentNoteRevision.CMN_NoteRevisionID;
                        noteRevisionForRevisionID.IsDeleted = true;
                        noteRevisionForRevisionID.Save(Connection, Transaction);
                        noteToDelete.Save(Connection, Transaction);
                    }
                    else if (noteRevisionsForNoteID.Count() == 1)
                    {

                        noteToDelete.IsDeleted = true;
                        noteToDelete.Save(Connection, Transaction);

                        var projectNotesToDelete = ORM_TMS_PRO_Project_Notes.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project_Notes.Query()
                        {
                            Ext_CMN_Note_RefID = noteToDelete.CMN_NoteID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        });
                        foreach (var item in projectNotesToDelete)
                        {
                            item.IsDeleted = true;
                            item.Save(Connection, Transaction);
                            //delete collaborators and tags regarding that note

                            var currentCollaborators = ORM_TMS_PRO_Project_Note_Collaborators.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project_Note_Collaborators.Query()
                            {

                                ProjectNote_RefID = item.TMS_PRO_Project_NoteID,
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false

                            });
                            if (currentCollaborators != null)
                            {
                                foreach (var collaborator in currentCollaborators)
                                {
                                    collaborator.IsDeleted = true;
                                    collaborator.Save(Connection, Transaction);
                                }

                            }
                            ORM_TMS_PRO_Project_Note_2_Tag currentTags = ORM_TMS_PRO_Project_Note_2_Tag.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project_Note_2_Tag.Query()
                            {
                                Project_Note_RefID = item.TMS_PRO_Project_NoteID,
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false

                            }).SingleOrDefault();

                            if (currentTags != null)
                            {
                                currentTags.IsDeleted = true;
                                currentTags.Save(Connection, Transaction);
                            }
                        }
                    }
                }
                else
                {
                    //izbrisi samo tu verziju
                    noteRevisionForRevisionID.IsDeleted = true;
                    noteRevisionForRevisionID.Save(Connection, Transaction);

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
		public static FR_L3N_SNN_0921 Invoke(string ConnectionString,P_L3N_SNN_0921 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3N_SNN_0921 Invoke(DbConnection Connection,P_L3N_SNN_0921 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3N_SNN_0921 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3N_SNN_0921 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3N_SNN_0921 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3N_SNN_0921 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3N_SNN_0921 functionReturn = new FR_L3N_SNN_0921();
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

				throw new Exception("Exception occured in method cls_Save_NewNote",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3N_SNN_0921 : FR_Base
	{
		public L3N_SNN_0921 Result	{ get; set; }

		public FR_L3N_SNN_0921() : base() {}

		public FR_L3N_SNN_0921(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3N_SNN_0921 for attribute P_L3N_SNN_0921
		[DataContract]
		public class P_L3N_SNN_0921 
		{
			[DataMember]
			public P_L3N_SNN_0921a[] Tags { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ProjectID { get; set; } 
			[DataMember]
			public Guid NoteID { get; set; } 
			[DataMember]
			public Guid NoteRevisionID { get; set; } 
			[DataMember]
			public Guid CreatorID { get; set; } 
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String SaveType { get; set; } 
			[DataMember]
			public Boolean SaveOnlyNewVersion { get; set; } 
			[DataMember]
			public Boolean SaveOverVersion { get; set; } 
			[DataMember]
			public Guid ProjectNoteID { get; set; } 
			[DataMember]
			public Guid[] Collaborators { get; set; } 

		}
		#endregion
		#region SClass P_L3N_SNN_0921a for attribute Tags
		[DataContract]
		public class P_L3N_SNN_0921a 
		{
			//Standard type parameters
			[DataMember]
			public Guid TagID { get; set; } 
			[DataMember]
			public String TagValue { get; set; } 

		}
		#endregion
		#region SClass L3N_SNN_0921 for attribute L3N_SNN_0921
		[DataContract]
		public class L3N_SNN_0921 
		{
			//Standard type parameters
			[DataMember]
			public Guid NewNote { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3N_SNN_0921 cls_Save_NewNote(,P_L3N_SNN_0921 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3N_SNN_0921 invocationResult = cls_Save_NewNote.Invoke(connectionString,P_L3N_SNN_0921 Parameter,securityTicket);
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
var parameter = new CL3_Notes.Complex.Manipulation.P_L3N_SNN_0921();
parameter.Tags = ...;

parameter.ProjectID = ...;
parameter.NoteID = ...;
parameter.NoteRevisionID = ...;
parameter.CreatorID = ...;
parameter.Content = ...;
parameter.Title = ...;
parameter.SaveType = ...;
parameter.SaveOnlyNewVersion = ...;
parameter.SaveOverVersion = ...;
parameter.ProjectNoteID = ...;
parameter.Collaborators = ...;

*/
