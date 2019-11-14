/* 
 * Generated on 9/16/2014 16:14:59
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

namespace CL3_Comments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Comment_and_Mentions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Comment_and_Mentions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3C_SCaM_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here

            // check if there is mentions for saving
            if (Parameter.Mentions != null)
            {
                #region Save comment

                ORM_TMS_PRO_Comment comment = new ORM_TMS_PRO_Comment();

                comment.TMS_PRO_CommentID = Guid.NewGuid();
                comment.Comment_BoundTo_BusinessTask_RefID = Parameter.Comment_BoundTo_BusinessTask_RefID;
                comment.Comment_BoundTo_DeveloperTask_RefID = Parameter.Comment_BoundTo_DeveloperTask_RefID;
                comment.Comment_BoundTo_Feature_RefID = Parameter.Comment_BoundTo_Feature_RefID;
                comment.Comment_BoundTo_Project_RefID = Parameter.Comment_BoundTo_Project_RefID;
                comment.Comment_CreatedByAccount_RefID = Parameter.Comment_CreatedByAccount_RefID;
                comment.Comment_Quoatation_RefID = Parameter.Comment_Quoatation_RefID;
                comment.Comment_Quotation_Text = Parameter.Comment_Quotation_Text;
                comment.Comment_TextContent = Parameter.Comment_TextContent;
                comment.Creation_Timestamp = DateTime.Now;
                comment.Tenant_RefID = securityTicket.TenantID;
                comment.IsComment_BoundToDeveloperTask = Parameter.Comment_BoundTo_DeveloperTask_RefID != Guid.Empty;
                comment.IsComment_BoundToBusinessTask = Parameter.Comment_BoundTo_BusinessTask_RefID != Guid.Empty;
                comment.IsComment_BoundToFeature = Parameter.Comment_BoundTo_Feature_RefID != Guid.Empty;

                comment.Save(Connection, Transaction);

                #endregion

                #region Save mention/s

                foreach (var item in Parameter.Mentions)
                {

                    ORM_TMS_PRO_Comment_Mention mention = new ORM_TMS_PRO_Comment_Mention();

                    mention.TMS_PRO_Comment_MentionID = Guid.NewGuid();
                    mention.Comment_RefID = comment.TMS_PRO_CommentID;
                    mention.IsMentionFor_Account = item.Mention_Account_RefID != Guid.Empty;
                    mention.IsMentionFor_BusinessTask = item.Mention_BusinessTask_RefID != Guid.Empty;
                    mention.IsMentionFor_Feature = item.Mention_Feature_RefID != Guid.Empty;
                    mention.IsMentionFor_DeveloperTask = item.Mention_DeveloperTask_RefID != Guid.Empty;
                    mention.Mention_Account_RefID = item.Mention_Account_RefID;
                    mention.Mention_BusinessTask_RefID = item.Mention_BusinessTask_RefID;
                    mention.Mention_Feature_RefID = item.Mention_Feature_RefID;
                    mention.Mention_DeveloperTask_RefID = item.Mention_DeveloperTask_RefID;
                    mention.CommentMention_Position = item.CommentMention_Position;
                    mention.R_CommentMention_Text = item.R_CommentMention_Text;
                    mention.Creation_Timestamp = DateTime.Now;
                    mention.Tenant_RefID = securityTicket.TenantID;

                    mention.Save(Connection, Transaction);
                }

                #endregion
            }

            else

            {
                #region Save comment without mention
            

                ORM_TMS_PRO_Comment comment = new ORM_TMS_PRO_Comment();

                comment.TMS_PRO_CommentID = Guid.NewGuid();
                comment.Comment_BoundTo_BusinessTask_RefID = Parameter.Comment_BoundTo_BusinessTask_RefID;
                comment.Comment_BoundTo_DeveloperTask_RefID = Parameter.Comment_BoundTo_DeveloperTask_RefID;
                comment.Comment_BoundTo_Feature_RefID = Parameter.Comment_BoundTo_Feature_RefID;
                comment.Comment_BoundTo_Project_RefID = Parameter.Comment_BoundTo_Project_RefID;
                comment.Comment_CreatedByAccount_RefID = Parameter.Comment_CreatedByAccount_RefID;
                comment.Comment_Quoatation_RefID = Parameter.Comment_Quoatation_RefID;
                comment.Comment_Quotation_Text = Parameter.Comment_Quotation_Text;
                comment.Comment_TextContent = Parameter.Comment_TextContent;
                comment.Creation_Timestamp = DateTime.Now;
                comment.Tenant_RefID = securityTicket.TenantID;
                comment.IsComment_BoundToDeveloperTask = Parameter.Comment_BoundTo_DeveloperTask_RefID != Guid.Empty;
                comment.IsComment_BoundToBusinessTask = Parameter.Comment_BoundTo_BusinessTask_RefID != Guid.Empty;
                comment.IsComment_BoundToFeature = Parameter.Comment_BoundTo_Feature_RefID != Guid.Empty;

                comment.Save(Connection, Transaction);

            
            #endregion
            }

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L3C_SCaM_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L3C_SCaM_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L3C_SCaM_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3C_SCaM_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Comment_and_Mentions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3C_SCaM_1612 for attribute P_L3C_SCaM_1612
		[DataContract]
		public class P_L3C_SCaM_1612 
		{
			[DataMember]
			public P_L3C_SCaM_1612a[] Mentions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid Comment_BoundTo_Project_RefID { get; set; } 
			[DataMember]
			public Guid Comment_BoundTo_BusinessTask_RefID { get; set; } 
			[DataMember]
			public Guid Comment_BoundTo_Feature_RefID { get; set; } 
			[DataMember]
			public Guid Comment_BoundTo_DeveloperTask_RefID { get; set; } 
			[DataMember]
			public Guid Comment_Quoatation_RefID { get; set; } 
			[DataMember]
			public Guid Comment_CreatedByAccount_RefID { get; set; } 
			[DataMember]
			public String Comment_Quotation_Text { get; set; } 
			[DataMember]
			public String Comment_TextContent { get; set; } 

		}
		#endregion
		#region SClass P_L3C_SCaM_1612a for attribute Mentions
		[DataContract]
		public class P_L3C_SCaM_1612a 
		{
			//Standard type parameters
			[DataMember]
			public Guid Mention_Account_RefID { get; set; } 
			[DataMember]
			public Guid Mention_BusinessTask_RefID { get; set; } 
			[DataMember]
			public Guid Mention_Feature_RefID { get; set; } 
			[DataMember]
			public Guid Mention_DeveloperTask_RefID { get; set; } 
			[DataMember]
			public int CommentMention_Position { get; set; } 
			[DataMember]
			public String R_CommentMention_Text { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Save_Comment_and_Mentions(,P_L3C_SCaM_1612 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Save_Comment_and_Mentions.Invoke(connectionString,P_L3C_SCaM_1612 Parameter,securityTicket);
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
var parameter = new CL3_Comments.Complex.Manipulation.P_L3C_SCaM_1612();
parameter.Mentions = ...;

parameter.Comment_BoundTo_Project_RefID = ...;
parameter.Comment_BoundTo_BusinessTask_RefID = ...;
parameter.Comment_BoundTo_Feature_RefID = ...;
parameter.Comment_BoundTo_DeveloperTask_RefID = ...;
parameter.Comment_Quoatation_RefID = ...;
parameter.Comment_CreatedByAccount_RefID = ...;
parameter.Comment_Quotation_Text = ...;
parameter.Comment_TextContent = ...;

*/
