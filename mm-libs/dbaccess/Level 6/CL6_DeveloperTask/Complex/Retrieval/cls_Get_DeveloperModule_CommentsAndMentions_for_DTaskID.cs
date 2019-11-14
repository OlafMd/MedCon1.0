/* 
 * Generated on 11-Dec-14 12:33:14 PM
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
using CL6_DanuTask_DeveloperTask.Atomic.Retrieval;

namespace CL6_DeveloperTask.Complex.Retrieval
{
	/// <summary>
    /// Get_DeveloperModule_CommentsAndMentions_for_DTaskID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperModule_CommentsAndMentions_for_DTaskID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperModule_CommentsAndMentions_for_DTaskID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GDMCaMfDT_1140_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_GDMCaMfDT_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6DT_GDMCaMfDT_1140_Array();
            //Put your code here

            P_L6DT_GDMCfDT_1058 commentParam = new P_L6DT_GDMCfDT_1058();
                commentParam.DTaskID = Parameter.DeveloperTaskID;
                commentParam.ProjectID = Parameter.ProjectID;
                commentParam.FeatureID = Parameter.FeatureID;

            var CommentsList = cls_Get_DeveloperModule_Comments_for_DTaskID.Invoke(Connection, Transaction, commentParam, securityTicket).Result.ToList();

            // list for returned results (comments+mentions)
            List<L6DT_GDMCaMfDT_1140> returnedList = new List<L6DT_GDMCaMfDT_1140>();


                foreach (var comment in CommentsList)
                {
                    if (Parameter.ProjectID!=null && Parameter.ProjectID!=Guid.Empty && comment.Comment_BoundTo_Project_RefID == Parameter.ProjectID)
                    {
                        L6DT_GDMCaMfDT_1140 commentsAndMentions = new L6DT_GDMCaMfDT_1140();

                        commentsAndMentions.AuthorFirstName = comment.AuthorFirstName;
                        commentsAndMentions.AuthorLastName = comment.AuthorLastName;
                        commentsAndMentions.CommentAccID = comment.CommentAccID;
                        commentsAndMentions.CommentID = comment.CommentID;
                        commentsAndMentions.CommentText = comment.CommentText;
                        commentsAndMentions.CreationDate = comment.CreationDate;
                        commentsAndMentions.IsDeletedComment = comment.IsDeletedComment;
                        commentsAndMentions.AuthorProfilePicture_ServerLocation = comment.File_ServerLocation;
                        commentsAndMentions.AuthorProfilePicture_SourceLocation = comment.File_SourceLocation;

                        // get mentions for this comment by CommentID
                        P_L6DT_GDMMfC_1104 mentionParam = new P_L6DT_GDMMfC_1104();
                        mentionParam.CommentID = comment.CommentID;

                        var MentionsList = cls_Get_DeveloperModule_Mentions_for_CommentID.Invoke(Connection, Transaction, mentionParam, securityTicket).Result;

                        List<L6DT_GDMCaMfDT_1140a> paramMentionsList = new List<L6DT_GDMCaMfDT_1140a>();

                        foreach (var mention in MentionsList)
                        {
                            L6DT_GDMCaMfDT_1140a mentionListparam = new L6DT_GDMCaMfDT_1140a();

                            mentionListparam.Comment_RefID = mention.Comment_RefID;
                            mentionListparam.CommentMention_Position = mention.CommentMention_Position;
                            mentionListparam.Creation_Timestamp = mention.Creation_Timestamp;
                            mentionListparam.IsDeleted = mention.IsDeleted;
                            mentionListparam.R_CommentMention_Text = mention.R_CommentMention_Text;
                            mentionListparam.TMS_PRO_Comment_MentionID = mention.TMS_PRO_Comment_MentionID;

                            paramMentionsList.Add(mentionListparam);
                        }

                        // store mentions for this comment 
                        commentsAndMentions.Mentions = paramMentionsList.ToArray();

                        // save in returned list
                        returnedList.Add(commentsAndMentions);
                    }
                    
                    if (Parameter.DeveloperTaskID!=null && Parameter.DeveloperTaskID!=Guid.Empty && comment.Comment_BoundTo_DeveloperTask_RefID == Parameter.DeveloperTaskID)
                    {
                        L6DT_GDMCaMfDT_1140 commentsAndMentions = new L6DT_GDMCaMfDT_1140();

                        commentsAndMentions.AuthorFirstName = comment.AuthorFirstName;
                        commentsAndMentions.AuthorLastName = comment.AuthorLastName;
                        commentsAndMentions.CommentAccID = comment.CommentAccID;
                        commentsAndMentions.CommentID = comment.CommentID;
                        commentsAndMentions.CommentText = comment.CommentText;
                        commentsAndMentions.CreationDate = comment.CreationDate;
                        commentsAndMentions.IsDeletedComment = comment.IsDeletedComment;
                        commentsAndMentions.AuthorProfilePicture_ServerLocation = comment.File_ServerLocation;
                        commentsAndMentions.AuthorProfilePicture_SourceLocation = comment.File_SourceLocation;

                        // get mentions for this comment by CommentID
                        P_L6DT_GDMMfC_1104 mentionParam = new P_L6DT_GDMMfC_1104();
                        mentionParam.CommentID = comment.CommentID;

                        var MentionsList = cls_Get_DeveloperModule_Mentions_for_CommentID.Invoke(Connection, Transaction, mentionParam, securityTicket).Result;

                        List<L6DT_GDMCaMfDT_1140a> paramMentionsList = new List<L6DT_GDMCaMfDT_1140a>();

                        foreach (var mention in MentionsList)
                        {
                            L6DT_GDMCaMfDT_1140a mentionListparam = new L6DT_GDMCaMfDT_1140a();

                            mentionListparam.Comment_RefID = mention.Comment_RefID;
                            mentionListparam.CommentMention_Position = mention.CommentMention_Position;
                            mentionListparam.Creation_Timestamp = mention.Creation_Timestamp;
                            mentionListparam.IsDeleted = mention.IsDeleted;
                            mentionListparam.R_CommentMention_Text = mention.R_CommentMention_Text;
                            mentionListparam.TMS_PRO_Comment_MentionID = mention.TMS_PRO_Comment_MentionID;

                            paramMentionsList.Add(mentionListparam);
                        }

                        // store mentions for this comment 
                        commentsAndMentions.Mentions = paramMentionsList.ToArray();

                        // save in returned list
                        returnedList.Add(commentsAndMentions);
                    
                    }

                    if (Parameter.FeatureID != null && Parameter.FeatureID != Guid.Empty && comment.Comment_BoundTo_Feature_RefID == Parameter.FeatureID)
                    {
                        L6DT_GDMCaMfDT_1140 commentsAndMentions = new L6DT_GDMCaMfDT_1140();

                        commentsAndMentions.AuthorFirstName = comment.AuthorFirstName;
                        commentsAndMentions.AuthorLastName = comment.AuthorLastName;
                        commentsAndMentions.CommentAccID = comment.CommentAccID;
                        commentsAndMentions.CommentID = comment.CommentID;
                        commentsAndMentions.CommentText = comment.CommentText;
                        commentsAndMentions.CreationDate = comment.CreationDate;
                        commentsAndMentions.IsDeletedComment = comment.IsDeletedComment;
                        commentsAndMentions.AuthorProfilePicture_ServerLocation = comment.File_ServerLocation;
                        commentsAndMentions.AuthorProfilePicture_SourceLocation = comment.File_SourceLocation;


                        // get mentions for this comment by CommentID
                        P_L6DT_GDMMfC_1104 mentionParam = new P_L6DT_GDMMfC_1104();
                        mentionParam.CommentID = comment.CommentID;

                        var MentionsList = cls_Get_DeveloperModule_Mentions_for_CommentID.Invoke(Connection, Transaction, mentionParam, securityTicket).Result;

                        List<L6DT_GDMCaMfDT_1140a> paramMentionsList = new List<L6DT_GDMCaMfDT_1140a>();

                        foreach (var mention in MentionsList)
                        {
                            L6DT_GDMCaMfDT_1140a mentionListparam = new L6DT_GDMCaMfDT_1140a();

                            mentionListparam.Comment_RefID = mention.Comment_RefID;
                            mentionListparam.CommentMention_Position = mention.CommentMention_Position;
                            mentionListparam.Creation_Timestamp = mention.Creation_Timestamp;
                            mentionListparam.IsDeleted = mention.IsDeleted;
                            mentionListparam.R_CommentMention_Text = mention.R_CommentMention_Text;
                            mentionListparam.TMS_PRO_Comment_MentionID = mention.TMS_PRO_Comment_MentionID;

                            paramMentionsList.Add(mentionListparam);
                        }

                        // store mentions for this comment 
                        commentsAndMentions.Mentions = paramMentionsList.ToArray();

                        // save in returned list
                        returnedList.Add(commentsAndMentions);

                    }
                }




            returnValue.Result = returnedList.ToArray();

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DT_GDMCaMfDT_1140_Array Invoke(string ConnectionString,P_L6DT_GDMCaMfDT_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GDMCaMfDT_1140_Array Invoke(DbConnection Connection,P_L6DT_GDMCaMfDT_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GDMCaMfDT_1140_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_GDMCaMfDT_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GDMCaMfDT_1140_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_GDMCaMfDT_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GDMCaMfDT_1140_Array functionReturn = new FR_L6DT_GDMCaMfDT_1140_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperModule_CommentsAndMentions_for_DTaskID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GDMCaMfDT_1140_Array : FR_Base
	{
		public L6DT_GDMCaMfDT_1140[] Result	{ get; set; } 
		public FR_L6DT_GDMCaMfDT_1140_Array() : base() {}

		public FR_L6DT_GDMCaMfDT_1140_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DT_GDMCaMfDT_1140 for attribute P_L6DT_GDMCaMfDT_1140
		[DataContract]
		public class P_L6DT_GDMCaMfDT_1140 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTaskID { get; set; } 
			[DataMember]
			public Guid ProjectID { get; set; } 
			[DataMember]
			public Guid FeatureID { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDMCaMfDT_1140 for attribute L6DT_GDMCaMfDT_1140
		[DataContract]
		public class L6DT_GDMCaMfDT_1140 
		{
			[DataMember]
			public L6DT_GDMCaMfDT_1140a[] Mentions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CommentID { get; set; } 
			[DataMember]
			public DateTime CreationDate { get; set; } 
			[DataMember]
			public String CommentText { get; set; } 
			[DataMember]
			public Boolean IsDeletedComment { get; set; } 
			[DataMember]
			public Guid CommentAccID { get; set; } 
			[DataMember]
			public String AuthorFirstName { get; set; } 
			[DataMember]
			public String AuthorLastName { get; set; } 
			[DataMember]
			public String AuthorProfilePicture_SourceLocation { get; set; } 
			[DataMember]
			public String AuthorProfilePicture_ServerLocation { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDMCaMfDT_1140a for attribute Mentions
		[DataContract]
		public class L6DT_GDMCaMfDT_1140a 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_Comment_MentionID { get; set; } 
			[DataMember]
			public Guid Comment_RefID { get; set; } 
			[DataMember]
			public String R_CommentMention_Text { get; set; } 
			[DataMember]
			public int CommentMention_Position { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GDMCaMfDT_1140_Array cls_Get_DeveloperModule_CommentsAndMentions_for_DTaskID(,P_L6DT_GDMCaMfDT_1140 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GDMCaMfDT_1140_Array invocationResult = cls_Get_DeveloperModule_CommentsAndMentions_for_DTaskID.Invoke(connectionString,P_L6DT_GDMCaMfDT_1140 Parameter,securityTicket);
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
var parameter = new CL6_DeveloperTask.Complex.Retrieval.P_L6DT_GDMCaMfDT_1140();
parameter.DeveloperTaskID = ...;
parameter.ProjectID = ...;
parameter.FeatureID = ...;

*/
