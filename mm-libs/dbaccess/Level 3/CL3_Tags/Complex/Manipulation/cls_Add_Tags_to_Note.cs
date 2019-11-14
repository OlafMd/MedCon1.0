/* 
 * Generated on 12/12/2014 4:37:06 PM
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

namespace CL3_Tags.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Add_Tags_to_Note.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Add_Tags_to_Note
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3TG_ATtN_1738 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here
            ORM_TMS_PRO_Tags.Query tagQuery = new ORM_TMS_PRO_Tags.Query();
            tagQuery.Tenant_RefID = securityTicket.TenantID;
            tagQuery.IsDeleted = false;

            ORM_TMS_PRO_Project_Note_2_Tag.Query note2TagQuery = new ORM_TMS_PRO_Project_Note_2_Tag.Query();
            note2TagQuery.Project_Note_RefID = Parameter.ProjectNoteID;
            note2TagQuery.Tenant_RefID = securityTicket.TenantID;
            note2TagQuery.IsDeleted = false;

            //remove existing ones not in the parameter list
            List<ORM_TMS_PRO_Project_Note_2_Tag> existingTags = ORM_TMS_PRO_Project_Note_2_Tag.Query.Search(Connection, Transaction, note2TagQuery);
            if (existingTags != null && existingTags.Count > 0)
            {
                foreach (var currentTag in existingTags)
                {
                    if (!Parameter.NoteTags.ToList().Exists(n => n.TMS_PRO_TagID != null && n.TMS_PRO_TagID != Guid.Empty && n.TMS_PRO_TagID == currentTag.Tag_RefID))
                    {
                        note2TagQuery.Tag_RefID = currentTag.Tag_RefID;
                        ORM_TMS_PRO_Project_Note_2_Tag.Query.SoftDelete(Connection, Transaction, note2TagQuery);
                    }
                }
            }

            foreach (var currentTag in Parameter.NoteTags)
            {
                tagQuery.TagValue = currentTag.TagValue;
                if (!ORM_TMS_PRO_Tags.Query.Exists(Connection, Transaction, tagQuery))
                {
                    //Add tag to database
                    ORM_TMS_PRO_Tags newTagData = new ORM_TMS_PRO_Tags();
                    newTagData.Tenant_RefID = securityTicket.TenantID;
                    newTagData.TagValue = currentTag.TagValue;
                    newTagData.Save(Connection, Transaction);
                    //Bind to note
                    ORM_TMS_PRO_Project_Note_2_Tag note2Tag = new ORM_TMS_PRO_Project_Note_2_Tag();
                    note2Tag.Project_Note_RefID = Parameter.ProjectNoteID;
                    note2Tag.Tag_RefID = newTagData.TMS_PRO_TagID;
                    note2Tag.Tenant_RefID = securityTicket.TenantID;
                    note2Tag.Save(Connection, Transaction);
                }
                else
                {
                    note2TagQuery.Tag_RefID = currentTag.TMS_PRO_TagID;
                    note2TagQuery.Project_Note_RefID = Parameter.ProjectNoteID;
                    if (!ORM_TMS_PRO_Project_Note_2_Tag.Query.Exists(Connection, Transaction, note2TagQuery))
                    {
                        ORM_TMS_PRO_Project_Note_2_Tag note2Tag = new ORM_TMS_PRO_Project_Note_2_Tag();
                        note2Tag.Project_Note_RefID = Parameter.ProjectNoteID;
                        note2Tag.Tag_RefID = currentTag.TMS_PRO_TagID;
                        note2Tag.Tenant_RefID = securityTicket.TenantID;
                        note2Tag.Save(Connection, Transaction);
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
		public static FR_Base Invoke(string ConnectionString,P_L3TG_ATtN_1738 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L3TG_ATtN_1738 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L3TG_ATtN_1738 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3TG_ATtN_1738 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Add_Tags_to_Note",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3TG_ATtN_1738 for attribute P_L3TG_ATtN_1738
		[DataContract]
		public class P_L3TG_ATtN_1738 
		{
			[DataMember]
			public P_L3TG_ATtN_1738a[] NoteTags { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ProjectNoteID { get; set; } 

		}
		#endregion
		#region SClass P_L3TG_ATtN_1738a for attribute NoteTags
		[DataContract]
		public class P_L3TG_ATtN_1738a 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_TagID { get; set; } 
			[DataMember]
			public String TagValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Add_Tags_to_Note(,P_L3TG_ATtN_1738 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Add_Tags_to_Note.Invoke(connectionString,P_L3TG_ATtN_1738 Parameter,securityTicket);
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
var parameter = new CL3_Tags.Complex.Manipulation.P_L3TG_ATtN_1738();
parameter.NoteTags = ...;

parameter.ProjectNoteID = ...;

*/
