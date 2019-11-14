/* 
 * Generated on 11/19/2014 11:03:49 AM
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
using CL1_CMN;

namespace CL3_Notes.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Notes_Garbage.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Notes_Garbage
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3N_DNG_1103 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L3N_DNG_1103();
			//Put your code here
            var ProjectNotesCreatedByCurrentUser = cls_Get_All_ProjectNotes_Created_by_AccountID.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            foreach (var note in ProjectNotesCreatedByCurrentUser)
            {
                var lastnoterevision = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, new ORM_CMN_NoteRevision.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_NoteRevisionID = note.Current_NoteRevision_RefID,
                    IsDeleted = true
                }).SingleOrDefault();
                if (lastnoterevision != null)
                {
                    var noteToDelete = ORM_CMN_Note.Query.Search(Connection, Transaction, new ORM_CMN_Note.Query()
                    {
                        CMN_NoteID = note.CMN_NoteID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).SingleOrDefault();
                    if (noteToDelete != null)
                    {
                        noteToDelete.IsDeleted = true;
                        noteToDelete.Save(Connection, Transaction);
                    }

                }
            }

            var ProjectNoteswhereUserIscollab = cls_Get_All_ProjectNotes_Where_Current_User_is_Collaborator.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            foreach (var note in ProjectNoteswhereUserIscollab)
            {
                var lastnoterevision = ORM_CMN_NoteRevision.Query.Search(Connection, Transaction, new ORM_CMN_NoteRevision.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_NoteRevisionID = note.CMN_NoteID,
                    IsDeleted = true
                }).SingleOrDefault();
                if (lastnoterevision != null)
                {
                    var noteToDelete = ORM_CMN_Note.Query.Search(Connection, Transaction, new ORM_CMN_Note.Query()
                    {
                        CMN_NoteID = note.CMN_NoteID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).SingleOrDefault();
                    if (noteToDelete != null)
                    {
                        noteToDelete.IsDeleted = true;
                        noteToDelete.Save(Connection, Transaction);
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
		public static FR_L3N_DNG_1103 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3N_DNG_1103 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3N_DNG_1103 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3N_DNG_1103 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3N_DNG_1103 functionReturn = new FR_L3N_DNG_1103();
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

				throw new Exception("Exception occured in method cls_Delete_Notes_Garbage",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3N_DNG_1103 : FR_Base
	{
		public L3N_DNG_1103 Result	{ get; set; }

		public FR_L3N_DNG_1103() : base() {}

		public FR_L3N_DNG_1103(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3N_DNG_1103 for attribute L3N_DNG_1103
		[DataContract]
		public class L3N_DNG_1103 
		{
			//Standard type parameters
			[DataMember]
			public Guid RESULT { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3N_DNG_1103 cls_Delete_Notes_Garbage(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3N_DNG_1103 invocationResult = cls_Delete_Notes_Garbage.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

