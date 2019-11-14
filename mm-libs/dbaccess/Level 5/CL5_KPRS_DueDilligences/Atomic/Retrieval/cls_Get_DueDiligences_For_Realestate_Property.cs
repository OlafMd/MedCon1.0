/* 
 * Generated on 8/12/2013 10:45:23 AM
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

namespace CL5_KPRS_DueDiligences.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DueDiligences_For_Realestate_Property.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DueDiligences_For_Realestate_Property
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DD_GDDFRP_1133_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DD_GDDFRP_1133 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DD_GDDFRP_1133_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_DueDiligences.Atomic.Retrieval.SQL.cls_Get_DueDiligences_For_Realestate_Property.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RealEstatePropertyID", Parameter.RealEstatePropertyID);



			List<L5DD_GDDFRP_1133_raw> results = new List<L5DD_GDDFRP_1133_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_DUD_Revision_GroupID","RevisionGroup_Name","RevisionGroup_Comment","RevisionGroup_SubmittedBy_Account_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","RealestateProperty_RefID","FirstName","LastName","Building_Name","RES_BLD_BuildingID","RES_DUD_RevisionID","QuestionnaireVersion_RefID" });
				while(reader.Read())
				{
					L5DD_GDDFRP_1133_raw resultItem = new L5DD_GDDFRP_1133_raw();
					//0:Parameter RES_DUD_Revision_GroupID of type Guid
					resultItem.RES_DUD_Revision_GroupID = reader.GetGuid(0);
					//1:Parameter RevisionGroup_Name of type String
					resultItem.RevisionGroup_Name = reader.GetString(1);
					//2:Parameter RevisionGroup_Comment of type String
					resultItem.RevisionGroup_Comment = reader.GetString(2);
					//3:Parameter RevisionGroup_SubmittedBy_Account_RefID of type Guid
					resultItem.RevisionGroup_SubmittedBy_Account_RefID = reader.GetGuid(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(5);
					//6:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(6);
					//7:Parameter RealestateProperty_RefID of type Guid
					resultItem.RealestateProperty_RefID = reader.GetGuid(7);
					//8:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(8);
					//9:Parameter LastName of type String
					resultItem.LastName = reader.GetString(9);
					//10:Parameter Building_Name of type String
					resultItem.Building_Name = reader.GetString(10);
					//11:Parameter RES_BLD_BuildingID of type Guid
					resultItem.RES_BLD_BuildingID = reader.GetGuid(11);
					//12:Parameter RES_DUD_RevisionID of type Guid
					resultItem.RES_DUD_RevisionID = reader.GetGuid(12);
					//13:Parameter QuestionnaireVersion_RefID of type Guid
					resultItem.QuestionnaireVersion_RefID = reader.GetGuid(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DueDiligences_For_Realestate_Property",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5DD_GDDFRP_1133_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DD_GDDFRP_1133_Array Invoke(string ConnectionString,P_L5DD_GDDFRP_1133 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DD_GDDFRP_1133_Array Invoke(DbConnection Connection,P_L5DD_GDDFRP_1133 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DD_GDDFRP_1133_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DD_GDDFRP_1133 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DD_GDDFRP_1133_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DD_GDDFRP_1133 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DD_GDDFRP_1133_Array functionReturn = new FR_L5DD_GDDFRP_1133_Array();
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

				throw new Exception("Exception occured in method cls_Get_DueDiligences_For_Realestate_Property",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5DD_GDDFRP_1133_raw 
	{
		public Guid RES_DUD_Revision_GroupID; 
		public String RevisionGroup_Name; 
		public String RevisionGroup_Comment; 
		public Guid RevisionGroup_SubmittedBy_Account_RefID; 
		public DateTime Creation_Timestamp; 
		public Guid Tenant_RefID; 
		public bool IsDeleted; 
		public Guid RealestateProperty_RefID; 
		public String FirstName; 
		public String LastName; 
		public String Building_Name; 
		public Guid RES_BLD_BuildingID; 
		public Guid RES_DUD_RevisionID; 
		public Guid QuestionnaireVersion_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DD_GDDFRP_1133[] Convert(List<L5DD_GDDFRP_1133_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DD_GDDFRP_1133 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_DUD_Revision_GroupID)).ToArray()
	group el_L5DD_GDDFRP_1133 by new 
	{ 
		el_L5DD_GDDFRP_1133.RES_DUD_Revision_GroupID,

	}
	into gfunct_L5DD_GDDFRP_1133
	select new L5DD_GDDFRP_1133
	{     
		RES_DUD_Revision_GroupID = gfunct_L5DD_GDDFRP_1133.Key.RES_DUD_Revision_GroupID ,
		RevisionGroup_Name = gfunct_L5DD_GDDFRP_1133.FirstOrDefault().RevisionGroup_Name ,
		RevisionGroup_Comment = gfunct_L5DD_GDDFRP_1133.FirstOrDefault().RevisionGroup_Comment ,
		RevisionGroup_SubmittedBy_Account_RefID = gfunct_L5DD_GDDFRP_1133.FirstOrDefault().RevisionGroup_SubmittedBy_Account_RefID ,
		Creation_Timestamp = gfunct_L5DD_GDDFRP_1133.FirstOrDefault().Creation_Timestamp ,
		Tenant_RefID = gfunct_L5DD_GDDFRP_1133.FirstOrDefault().Tenant_RefID ,
		IsDeleted = gfunct_L5DD_GDDFRP_1133.FirstOrDefault().IsDeleted ,
		RealestateProperty_RefID = gfunct_L5DD_GDDFRP_1133.FirstOrDefault().RealestateProperty_RefID ,
		FirstName = gfunct_L5DD_GDDFRP_1133.FirstOrDefault().FirstName ,
		LastName = gfunct_L5DD_GDDFRP_1133.FirstOrDefault().LastName ,

		Revisions = 
		(
			from el_Revisions in gfunct_L5DD_GDDFRP_1133.Where(element => !EqualsDefaultValue(element.RES_DUD_RevisionID)).ToArray()
			group el_Revisions by new 
			{ 
				el_Revisions.RES_DUD_RevisionID,

			}
			into gfunct_Revisions
			select new L5DD_GDDFRP_1133_Revisions
			{     
				Building_Name = gfunct_Revisions.FirstOrDefault().Building_Name ,
				RES_BLD_BuildingID = gfunct_Revisions.FirstOrDefault().RES_BLD_BuildingID ,
				RES_DUD_RevisionID = gfunct_Revisions.Key.RES_DUD_RevisionID ,
				QuestionnaireVersion_RefID = gfunct_Revisions.FirstOrDefault().QuestionnaireVersion_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DD_GDDFRP_1133_Array : FR_Base
	{
		public L5DD_GDDFRP_1133[] Result	{ get; set; } 
		public FR_L5DD_GDDFRP_1133_Array() : base() {}

		public FR_L5DD_GDDFRP_1133_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DD_GDDFRP_1133 for attribute P_L5DD_GDDFRP_1133
		[DataContract]
		public class P_L5DD_GDDFRP_1133 
		{
			//Standard type parameters
			[DataMember]
			public Guid RealEstatePropertyID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GDDFRP_1133 for attribute L5DD_GDDFRP_1133
		[DataContract]
		public class L5DD_GDDFRP_1133 
		{
			[DataMember]
			public L5DD_GDDFRP_1133_Revisions[] Revisions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_DUD_Revision_GroupID { get; set; } 
			[DataMember]
			public String RevisionGroup_Name { get; set; } 
			[DataMember]
			public String RevisionGroup_Comment { get; set; } 
			[DataMember]
			public Guid RevisionGroup_SubmittedBy_Account_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid RealestateProperty_RefID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 

		}
		#endregion
		#region SClass L5DD_GDDFRP_1133_Revisions for attribute Revisions
		[DataContract]
		public class L5DD_GDDFRP_1133_Revisions 
		{
			//Standard type parameters
			[DataMember]
			public String Building_Name { get; set; } 
			[DataMember]
			public Guid RES_BLD_BuildingID { get; set; } 
			[DataMember]
			public Guid RES_DUD_RevisionID { get; set; } 
			[DataMember]
			public Guid QuestionnaireVersion_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DD_GDDFRP_1133_Array cls_Get_DueDiligences_For_Realestate_Property(,P_L5DD_GDDFRP_1133 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DD_GDDFRP_1133_Array invocationResult = cls_Get_DueDiligences_For_Realestate_Property.Invoke(connectionString,P_L5DD_GDDFRP_1133 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_DueDiligences.Atomic.Retrieval.P_L5DD_GDDFRP_1133();
parameter.RealEstatePropertyID = ...;

*/