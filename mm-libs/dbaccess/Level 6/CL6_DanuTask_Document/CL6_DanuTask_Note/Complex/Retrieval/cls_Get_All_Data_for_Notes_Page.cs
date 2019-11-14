/* 
 * Generated on 10/9/2014 09:43:28
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

namespace CL6_DanuTask_Note.Complex.Retrieval
{
	/// <summary>
    /// Get_All_Data_for_Notes_Page
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Data_for_Notes_Page.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Data_for_Notes_Page
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DN_GADfNP_1449_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6DN_GADfNP_1449_Array();
			//Put your code here

            // return data
            List<L6DN_GADfNP_1449> notesData = new List<L6DN_GADfNP_1449>();

            //get notes 
            var notes = cls_Get_Data_for_NotesPage_without_Collaborators_and_Tags_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            // get tags and collaborators for each note
            foreach (var note in notes)
            {
                L6DN_GADfNP_1449 notesObj = new L6DN_GADfNP_1449();

                notesObj.Notes = note;

                P_L3N_GTfPaT_1028 tagParam = new P_L3N_GTfPaT_1028();
                tagParam.ProjectNoteID = note.TMS_PRO_Project_NoteID;
                var tags = cls_Get_Tags_for_ProjectID_and_TenantID.Invoke(Connection,Transaction,tagParam,securityTicket).Result;

                notesObj.Tags = tags;

                P_L3N_GCfPaT_1422 collabParam = new P_L3N_GCfPaT_1422();
                collabParam.ProjectNoteID = note.TMS_PRO_Project_NoteID;
                var collaborators = cls_Get_Collaborators_for_ProjectID_and_TenantID.Invoke(Connection, Transaction, collabParam, securityTicket).Result;

                notesObj.Collaborators = collaborators;

                notesData.Add(notesObj);
            }

            returnValue.Result = notesData.ToArray();


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DN_GADfNP_1449_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DN_GADfNP_1449_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DN_GADfNP_1449_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DN_GADfNP_1449_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DN_GADfNP_1449_Array functionReturn = new FR_L6DN_GADfNP_1449_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Data_for_Notes_Page",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DN_GADfNP_1449_Array : FR_Base
	{
		public L6DN_GADfNP_1449[] Result	{ get; set; } 
		public FR_L6DN_GADfNP_1449_Array() : base() {}

		public FR_L6DN_GADfNP_1449_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6DN_GADfNP_1449 for attribute L6DN_GADfNP_1449
		[DataContract]
		public class L6DN_GADfNP_1449 
		{
			//Standard type parameters
			[DataMember]
			public L3N_GDfNPwCfT_1325 Notes { get; set; } 
			[DataMember]
			public L3N_GTfPaT_1028[] Tags { get; set; } 
			[DataMember]
			public L3N_GCfPaT_1422[] Collaborators { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DN_GADfNP_1449_Array cls_Get_All_Data_for_Notes_Page(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DN_GADfNP_1449_Array invocationResult = cls_Get_All_Data_for_Notes_Page.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

