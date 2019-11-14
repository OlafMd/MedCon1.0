/* 
 * Generated on 12/12/2014 1:16:22 PM
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
using CL3_Tags.Complex.Manipulation;

namespace CL3_Notes.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Note.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Note
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3NT_SN_0921 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here
            ORM_USR_Account noteCreatorAccount = new ORM_USR_Account();
            noteCreatorAccount.Load(Connection, Transaction, Parameter.CreatorID);
            if (Parameter.ProjectNoteID != Guid.Empty)
            {
                if (Parameter.IsDeleted)
                {
                   ORM_CMN_NoteRevision.Query noteRevisionsQuery = new ORM_CMN_NoteRevision.Query();
                   noteRevisionsQuery.Note_RefID = Parameter.NoteID;
                   noteRevisionsQuery.IsDeleted = false;


                   List<ORM_CMN_NoteRevision> existingRevisions = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, noteRevisionsQuery);
                   if (existingRevisions.Count > 1)
                   {
                       existingRevisions = existingRevisions.Where(er => er.CMN_NoteRevisionID != Parameter.NoteRevisionID).OrderBy(er => er.Version).ToList();
                       noteRevisionsQuery.CMN_NoteRevisionID = Parameter.NoteRevisionID;
                       ORM_CMN_NoteRevision.Query.SoftDelete(Connection, Transaction, noteRevisionsQuery);

                       ORM_CMN_Note parentNote = new ORM_CMN_Note();
                       parentNote.Load(Connection, Transaction, Parameter.NoteID);
                       parentNote.Current_NoteRevision_RefID = existingRevisions.Last().CMN_NoteRevisionID;
                       parentNote.Save(Connection, Transaction);
                   }
                   else
                   {
                       ORM_CMN_Note.Query cmnNoteQuery = new ORM_CMN_Note.Query();
                       cmnNoteQuery.CMN_NoteID = Parameter.NoteID;
                       ORM_CMN_Note.Query.SoftDelete(Connection, Transaction, cmnNoteQuery);

                       ORM_TMS_PRO_Project_Notes.Query projectNotesQuery = new ORM_TMS_PRO_Project_Notes.Query();
                       projectNotesQuery.Ext_CMN_Note_RefID = Parameter.NoteID;
                       ORM_TMS_PRO_Project_Notes.Query.SoftDelete(Connection, Transaction, projectNotesQuery);

                       ORM_CMN_NoteRevision.Query.SoftDelete(Connection, Transaction, noteRevisionsQuery);

                       ORM_TMS_PRO_Project_Note_Collaborators.Query notesCollaboratorQuery = new ORM_TMS_PRO_Project_Note_Collaborators.Query();
                       notesCollaboratorQuery.ProjectNote_RefID = Parameter.ProjectNoteID;
                       ORM_TMS_PRO_Project_Note_Collaborators.Query.SoftDelete(Connection, Transaction, notesCollaboratorQuery);

                       ORM_TMS_PRO_Project_Note_2_Tag.Query note2tagQuery = new ORM_TMS_PRO_Project_Note_2_Tag.Query();
                       note2tagQuery.Project_Note_RefID = Parameter.ProjectNoteID;
                       ORM_TMS_PRO_Project_Note_2_Tag.Query.SoftDelete(Connection, Transaction, note2tagQuery);
                   }
                }
                else
                {
                    ORM_TMS_PRO_Project_Notes existingProjectNote = new ORM_TMS_PRO_Project_Notes();
                    existingProjectNote.Load(Connection, Transaction, Parameter.ProjectNoteID);
                    ORM_CMN_NoteRevision existingNoteVersion = new ORM_CMN_NoteRevision();
                    existingNoteVersion.Load(Connection, Transaction, Parameter.NoteRevisionID);
                    if (Parameter.SaveAsNewVersion)
                    {
                        ORM_CMN_NoteRevision.Query RevisionCountQuery = new ORM_CMN_NoteRevision.Query();
                        RevisionCountQuery.Note_RefID = Parameter.NoteID;

                        ORM_CMN_NoteRevision newNoteVersion = new ORM_CMN_NoteRevision();
                        newNoteVersion.CreatedBy_BusinessParticipant_RefID = noteCreatorAccount.BusinessParticipant_RefID;
                        newNoteVersion.Content = Parameter.Content;
                        newNoteVersion.Note_RefID = Parameter.NoteID;
                        newNoteVersion.Tenant_RefID = securityTicket.TenantID;
                        newNoteVersion.Version = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, RevisionCountQuery).Count+1;
                        newNoteVersion.Title = Parameter.Title;
                        newNoteVersion.Save(Connection, Transaction);
                        if (Parameter.ReplaceCreator)
                        {
                            //Find current creator of note and make him a collaborator to this note
                            ORM_USR_Account.Query currentCreatorQuery = new ORM_USR_Account.Query();
                            currentCreatorQuery.BusinessParticipant_RefID = existingNoteVersion.CreatedBy_BusinessParticipant_RefID;
                            currentCreatorQuery.IsDeleted = false;
                            currentCreatorQuery.Tenant_RefID = securityTicket.TenantID;
                            ORM_USR_Account currentCreator = ORM_USR_Account.Query.Search(Connection, Transaction, currentCreatorQuery).FirstOrDefault();

                            ORM_TMS_PRO_Project_Note_Collaborators.Query noteCollaboratorQuery = new ORM_TMS_PRO_Project_Note_Collaborators.Query();
                            noteCollaboratorQuery.ProjectNote_RefID = Parameter.ProjectNoteID;
                            noteCollaboratorQuery.IsDeleted = false;
                            noteCollaboratorQuery.Account_RefID = noteCreatorAccount.USR_AccountID;
                            if (ORM_TMS_PRO_Project_Note_Collaborators.Query.Exists(Connection, Transaction, noteCollaboratorQuery))
                            {
                                //If current creator was collaborator on existing note, delete him, because he has the role of creator now, and
                                //old creator will be added to collaborators.
                                ORM_TMS_PRO_Project_Note_Collaborators.Query.SoftDelete(Connection, Transaction, noteCollaboratorQuery);
                            }
                            ORM_TMS_PRO_Project_Note_Collaborators newNoteCollaborator = new ORM_TMS_PRO_Project_Note_Collaborators();
                            newNoteCollaborator.Account_RefID = currentCreator.USR_AccountID;
                            newNoteCollaborator.ProjectNote_RefID = Parameter.ProjectNoteID;
                            newNoteCollaborator.Tenant_RefID = securityTicket.TenantID;
                            newNoteCollaborator.Save(Connection, Transaction);

                            ORM_CMN_Note.Query cmnNoteCreatorUpdateFind = new ORM_CMN_Note.Query();
                            cmnNoteCreatorUpdateFind.CMN_NoteID = Parameter.NoteID;
                            ORM_CMN_Note.Query cmnNoteCreatorUpdate = new ORM_CMN_Note.Query();
                            cmnNoteCreatorUpdate.CreatedBy_BusinessParticipant_RefID = noteCreatorAccount.BusinessParticipant_RefID;
                            ORM_CMN_Note.Query.Update(Connection, Transaction,cmnNoteCreatorUpdateFind,cmnNoteCreatorUpdate);
                        }
                    }
                    else
                    {
                        existingNoteVersion.Content = Parameter.Content;
                        existingNoteVersion.Title = Parameter.Title;
                        existingNoteVersion.Save(Connection, Transaction);

                        if (existingProjectNote.Project_RefID != Parameter.ProjectID)
                        {
                            existingProjectNote.Project_RefID = Parameter.ProjectID;
                            existingProjectNote.Save(Connection, Transaction);
                        }
                    }

                    //Update note tags (Delete existing ones and save new ones)
                    P_L3TG_ATtN_1738 tagParameter = new P_L3TG_ATtN_1738();
                    tagParameter.ProjectNoteID = Parameter.ProjectNoteID;
                    List<P_L3TG_ATtN_1738a> tagListParameter = new List<P_L3TG_ATtN_1738a>();
                    foreach(var currentTag in Parameter.Tags)
                    {
                        P_L3TG_ATtN_1738a tempTag = new P_L3TG_ATtN_1738a();
                        tempTag.TagValue = currentTag.TagValue;
                        tempTag.TMS_PRO_TagID = currentTag.TagID;
                        tagListParameter.Add(tempTag);
                    }
                    tagParameter.NoteTags = tagListParameter.ToArray();
                    cls_Add_Tags_to_Note.Invoke(Connection, Transaction, tagParameter, securityTicket);
                }
            }
            else
            {
                ORM_CMN_Note newCmnNote = new ORM_CMN_Note();
                ORM_CMN_NoteRevision newNoteRevision = new ORM_CMN_NoteRevision();
                ORM_TMS_PRO_Project_Notes newProjectNote = new ORM_TMS_PRO_Project_Notes();

                newNoteRevision.Note_RefID = newCmnNote.CMN_NoteID;
                newNoteRevision.Content = Parameter.Content;
                newNoteRevision.CreatedBy_BusinessParticipant_RefID = noteCreatorAccount.BusinessParticipant_RefID;
                newNoteRevision.Tenant_RefID = securityTicket.TenantID;
                newNoteRevision.Title = Parameter.Title;
                newNoteRevision.Version = 1;
                newNoteRevision.Save(Connection, Transaction);

                newCmnNote.Current_NoteRevision_RefID = newNoteRevision.CMN_NoteRevisionID;
                newCmnNote.CreatedBy_BusinessParticipant_RefID = noteCreatorAccount.BusinessParticipant_RefID;
                newCmnNote.Tenant_RefID = securityTicket.TenantID;
                newCmnNote.Save(Connection, Transaction);

                newProjectNote.Ext_CMN_Note_RefID = newCmnNote.CMN_NoteID;
                newProjectNote.Project_RefID = Parameter.ProjectID;
                newProjectNote.Tenant_RefID = securityTicket.TenantID;
                newProjectNote.Save(Connection, Transaction);

                //Update note tags (Delete existing ones and save new ones)
                P_L3TG_ATtN_1738 tagParameter = new P_L3TG_ATtN_1738();
                tagParameter.ProjectNoteID = newProjectNote.TMS_PRO_Project_NoteID;
                List<P_L3TG_ATtN_1738a> tagListParameter = new List<P_L3TG_ATtN_1738a>();
                foreach (var currentTag in Parameter.Tags)
                {
                    P_L3TG_ATtN_1738a tempTag = new P_L3TG_ATtN_1738a();
                    tempTag.TagValue = currentTag.TagValue;
                    tempTag.TMS_PRO_TagID = currentTag.TagID;
                    tagListParameter.Add(tempTag);
                }
                tagParameter.NoteTags = tagListParameter.ToArray();
                cls_Add_Tags_to_Note.Invoke(Connection, Transaction, tagParameter, securityTicket);
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L3NT_SN_0921 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L3NT_SN_0921 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L3NT_SN_0921 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3NT_SN_0921 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Note",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3NT_SN_0921 for attribute P_L3NT_SN_0921
		[DataContract]
		public class P_L3NT_SN_0921 
		{
			[DataMember]
			public P_L3NT_SN_0921a[] Tags { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ProjectID { get; set; } 
			[DataMember]
			public Guid NoteID { get; set; } 
			[DataMember]
			public Guid NoteRevisionID { get; set; } 
			[DataMember]
			public Guid ProjectNoteID { get; set; } 
			[DataMember]
			public Guid CreatorID { get; set; } 
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public Boolean SaveAsNewVersion { get; set; } 
			[DataMember]
			public Boolean ReplaceCreator { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
            //[DataMember]
            //public Guid[] Collaborators { get; set; } 

		}
		#endregion
		#region SClass P_L3NT_SN_0921a for attribute Tags
		[DataContract]
		public class P_L3NT_SN_0921a 
		{
			//Standard type parameters
			[DataMember]
			public Guid TagID { get; set; } 
			[DataMember]
			public String TagValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Save_Note(,P_L3NT_SN_0921 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Save_Note.Invoke(connectionString,P_L3NT_SN_0921 Parameter,securityTicket);
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
var parameter = new CL3_Notes.Complex.Manipulation.P_L3NT_SN_0921();
parameter.Tags = ...;

parameter.ProjectID = ...;
parameter.NoteID = ...;
parameter.NoteRevisionID = ...;
parameter.ProjectNoteID = ...;
parameter.CreatorID = ...;
parameter.Content = ...;
parameter.Title = ...;
parameter.SaveAsNewVersion = ...;
parameter.ReplaceCreator = ...;
parameter.IsDeleted = ...;
parameter.Collaborators = ...;

*/
