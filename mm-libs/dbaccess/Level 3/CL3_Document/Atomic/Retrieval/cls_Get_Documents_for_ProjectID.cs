/* 
 * Generated on 12/16/2014 09:51:36
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

namespace CL3_Document.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Documents_for_ProjectID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Documents_for_ProjectID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DO_GDfPID_0846_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3DO_GDfPID_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DO_GDfPID_0846_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Document.Atomic.Retrieval.SQL.cls_Get_Documents_for_ProjectID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ID", Parameter.ID);



			List<L3DO_GDfPID_0846_raw> results = new List<L3DO_GDfPID_0846_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "AssignmentID","Structure_RefID","StructureHeader_RefID","DOC_DocumentID","Alias","PrimaryType","DOC_DocumentRevisionID","Document_RefID","Revision","File_ServerLocation","File_Name","IsLastRevision","IsLocked","File_Description","File_SourceLocation","File_Size_Bytes","File_MIMEType","File_Extension","Creation_Timestamp" });
				while(reader.Read())
				{
					L3DO_GDfPID_0846_raw resultItem = new L3DO_GDfPID_0846_raw();
					//0:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(0);
					//1:Parameter Structure_RefID of type Guid
					resultItem.Structure_RefID = reader.GetGuid(1);
					//2:Parameter StructureHeader_RefID of type Guid
					resultItem.StructureHeader_RefID = reader.GetGuid(2);
					//3:Parameter DOC_DocumentID of type Guid
					resultItem.DOC_DocumentID = reader.GetGuid(3);
					//4:Parameter Alias of type String
					resultItem.Alias = reader.GetString(4);
					//5:Parameter PrimaryType of type String
					resultItem.PrimaryType = reader.GetString(5);
					//6:Parameter DOC_DocumentRevisionID of type Guid
					resultItem.DOC_DocumentRevisionID = reader.GetGuid(6);
					//7:Parameter Document_RefID of type Guid
					resultItem.Document_RefID = reader.GetGuid(7);
					//8:Parameter Revision of type int
					resultItem.Revision = reader.GetInteger(8);
					//9:Parameter File_ServerLocation of type String
					resultItem.File_ServerLocation = reader.GetString(9);
					//10:Parameter File_Name of type String
					resultItem.File_Name = reader.GetString(10);
					//11:Parameter IsLastRevision of type bool
					resultItem.IsLastRevision = reader.GetBoolean(11);
					//12:Parameter IsLocked of type bool
					resultItem.IsLocked = reader.GetBoolean(12);
					//13:Parameter File_Description of type String
					resultItem.File_Description = reader.GetString(13);
					//14:Parameter File_SourceLocation of type String
					resultItem.File_SourceLocation = reader.GetString(14);
					//15:Parameter File_Size_Bytes of type int
					resultItem.File_Size_Bytes = reader.GetInteger(15);
					//16:Parameter File_MIMEType of type String
					resultItem.File_MIMEType = reader.GetString(16);
					//17:Parameter File_Extension of type String
					resultItem.File_Extension = reader.GetString(17);
					//18:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(18);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Documents_for_ProjectID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3DO_GDfPID_0846_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3DO_GDfPID_0846_Array Invoke(string ConnectionString,P_L3DO_GDfPID_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DO_GDfPID_0846_Array Invoke(DbConnection Connection,P_L3DO_GDfPID_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DO_GDfPID_0846_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DO_GDfPID_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DO_GDfPID_0846_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DO_GDfPID_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DO_GDfPID_0846_Array functionReturn = new FR_L3DO_GDfPID_0846_Array();
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

				throw new Exception("Exception occured in method cls_Get_Documents_for_ProjectID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3DO_GDfPID_0846_raw 
	{
		public Guid AssignmentID; 
		public Guid Structure_RefID; 
		public Guid StructureHeader_RefID; 
		public Guid DOC_DocumentID; 
		public String Alias; 
		public String PrimaryType; 
		public Guid DOC_DocumentRevisionID; 
		public Guid Document_RefID; 
		public int Revision; 
		public String File_ServerLocation; 
		public String File_Name; 
		public bool IsLastRevision; 
		public bool IsLocked; 
		public String File_Description; 
		public String File_SourceLocation; 
		public int File_Size_Bytes; 
		public String File_MIMEType; 
		public String File_Extension; 
		public DateTime Creation_Timestamp; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3DO_GDfPID_0846[] Convert(List<L3DO_GDfPID_0846_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3DO_GDfPID_0846 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.DOC_DocumentID)).ToArray()
	group el_L3DO_GDfPID_0846 by new 
	{ 
		el_L3DO_GDfPID_0846.DOC_DocumentID,

	}
	into gfunct_L3DO_GDfPID_0846
	select new L3DO_GDfPID_0846
	{     
		AssignmentID = gfunct_L3DO_GDfPID_0846.FirstOrDefault().AssignmentID ,
		Structure_RefID = gfunct_L3DO_GDfPID_0846.FirstOrDefault().Structure_RefID ,
		StructureHeader_RefID = gfunct_L3DO_GDfPID_0846.FirstOrDefault().StructureHeader_RefID ,
		DOC_DocumentID = gfunct_L3DO_GDfPID_0846.Key.DOC_DocumentID ,
		Alias = gfunct_L3DO_GDfPID_0846.FirstOrDefault().Alias ,
		PrimaryType = gfunct_L3DO_GDfPID_0846.FirstOrDefault().PrimaryType ,

		Revisions = 
		(
			from el_Revisions in gfunct_L3DO_GDfPID_0846.Where(element => !EqualsDefaultValue(element.DOC_DocumentRevisionID)).ToArray()
			group el_Revisions by new 
			{ 
				el_Revisions.DOC_DocumentRevisionID,

			}
			into gfunct_Revisions
			select new L3DO_GDfPID_0846a
			{     
				DOC_DocumentRevisionID = gfunct_Revisions.Key.DOC_DocumentRevisionID ,
				Document_RefID = gfunct_Revisions.FirstOrDefault().Document_RefID ,
				Revision = gfunct_Revisions.FirstOrDefault().Revision ,
				File_ServerLocation = gfunct_Revisions.FirstOrDefault().File_ServerLocation ,
				File_Name = gfunct_Revisions.FirstOrDefault().File_Name ,
				IsLastRevision = gfunct_Revisions.FirstOrDefault().IsLastRevision ,
				IsLocked = gfunct_Revisions.FirstOrDefault().IsLocked ,
				File_Description = gfunct_Revisions.FirstOrDefault().File_Description ,
				File_SourceLocation = gfunct_Revisions.FirstOrDefault().File_SourceLocation ,
				File_Size_Bytes = gfunct_Revisions.FirstOrDefault().File_Size_Bytes ,
				File_MIMEType = gfunct_Revisions.FirstOrDefault().File_MIMEType ,
				File_Extension = gfunct_Revisions.FirstOrDefault().File_Extension ,
				Creation_Timestamp = gfunct_Revisions.FirstOrDefault().Creation_Timestamp ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3DO_GDfPID_0846_Array : FR_Base
	{
		public L3DO_GDfPID_0846[] Result	{ get; set; } 
		public FR_L3DO_GDfPID_0846_Array() : base() {}

		public FR_L3DO_GDfPID_0846_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DO_GDfPID_0846 for attribute P_L3DO_GDfPID_0846
		[DataContract]
		public class P_L3DO_GDfPID_0846 
		{
			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L3DO_GDfPID_0846 for attribute L3DO_GDfPID_0846
		[DataContract]
		public class L3DO_GDfPID_0846 
		{
			[DataMember]
			public L3DO_GDfPID_0846a[] Revisions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid Structure_RefID { get; set; } 
			[DataMember]
			public Guid StructureHeader_RefID { get; set; } 
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 
			[DataMember]
			public String Alias { get; set; } 
			[DataMember]
			public String PrimaryType { get; set; } 

		}
		#endregion
		#region SClass L3DO_GDfPID_0846a for attribute Revisions
		[DataContract]
		public class L3DO_GDfPID_0846a 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_DocumentRevisionID { get; set; } 
			[DataMember]
			public Guid Document_RefID { get; set; } 
			[DataMember]
			public int Revision { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public String File_Name { get; set; } 
			[DataMember]
			public bool IsLastRevision { get; set; } 
			[DataMember]
			public bool IsLocked { get; set; } 
			[DataMember]
			public String File_Description { get; set; } 
			[DataMember]
			public String File_SourceLocation { get; set; } 
			[DataMember]
			public int File_Size_Bytes { get; set; } 
			[DataMember]
			public String File_MIMEType { get; set; } 
			[DataMember]
			public String File_Extension { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DO_GDfPID_0846_Array cls_Get_Documents_for_ProjectID(,P_L3DO_GDfPID_0846 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DO_GDfPID_0846_Array invocationResult = cls_Get_Documents_for_ProjectID.Invoke(connectionString,P_L3DO_GDfPID_0846 Parameter,securityTicket);
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
var parameter = new CL3_Document.Atomic.Retrieval.P_L3DO_GDfPID_0846();
parameter.ID = ...;

*/
