/* 
 * Generated on 9/1/2014 13:57:33
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

namespace CL3_Project.Atomic.Retrieval
{
	/// <summary>
    /// Get all projects (with or without archived) for AccountID and RightPackageList of User
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Projects_for_AccountID_and_RightPackIDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Projects_for_AccountID_and_RightPackIDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GPfAaR_1344_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GPfAaR_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PR_GPfAaR_1344_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Project.Atomic.Retrieval.SQL.cls_Get_Projects_for_AccountID_and_RightPackIDList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsArchived", Parameter.IsArchived);

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@RightPackIDList"," IN $$RightPackIDList$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$RightPackIDList$",Parameter.RightPackIDList);


			List<L3PR_GPfAaR_1344_raw> results = new List<L3PR_GPfAaR_1344_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_ProjectMemberID","TMS_PRO_ProjectID","DOC_Structure_Header_RefID","Name_DictID","Status_RefID","IsArchived","Creation_Timestamp","Description_DictID","ACC_RightsPackage_RefID" });
				while(reader.Read())
				{
					L3PR_GPfAaR_1344_raw resultItem = new L3PR_GPfAaR_1344_raw();
					//0:Parameter TMS_PRO_ProjectMemberID of type Guid
					resultItem.TMS_PRO_ProjectMemberID = reader.GetGuid(0);
					//1:Parameter TMS_PRO_ProjectID of type Guid
					resultItem.TMS_PRO_ProjectID = reader.GetGuid(1);
					//2:Parameter DOC_Structure_Header_RefID of type Guid
					resultItem.DOC_Structure_Header_RefID = reader.GetGuid(2);
					//3:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(3);
					resultItem.Name.SourceTable = "tms_pro_projects";
					loader.Append(resultItem.Name);
					//4:Parameter Status_RefID of type Guid
					resultItem.Status_RefID = reader.GetGuid(4);
					//5:Parameter IsArchived of type Boolean
					resultItem.IsArchived = reader.GetBoolean(5);
					//6:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(6);
					//7:Parameter Description of type Dict
					resultItem.Description = reader.GetDictionary(7);
					resultItem.Description.SourceTable = "tms_pro_projects";
					loader.Append(resultItem.Description);
					//8:Parameter ACC_RightsPackage_RefID of type Guid
					resultItem.ACC_RightsPackage_RefID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Projects_for_AccountID_and_RightPackIDList",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3PR_GPfAaR_1344_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PR_GPfAaR_1344_Array Invoke(string ConnectionString,P_L3PR_GPfAaR_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GPfAaR_1344_Array Invoke(DbConnection Connection,P_L3PR_GPfAaR_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GPfAaR_1344_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GPfAaR_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GPfAaR_1344_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GPfAaR_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GPfAaR_1344_Array functionReturn = new FR_L3PR_GPfAaR_1344_Array();
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

				throw new Exception("Exception occured in method cls_Get_Projects_for_AccountID_and_RightPackIDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3PR_GPfAaR_1344_raw 
	{
		public Guid TMS_PRO_ProjectMemberID; 
		public Guid TMS_PRO_ProjectID; 
		public Guid DOC_Structure_Header_RefID; 
		public Dict Name; 
		public Guid Status_RefID; 
		public Boolean IsArchived; 
		public DateTime Creation_Timestamp; 
		public Dict Description; 
		public Guid ACC_RightsPackage_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3PR_GPfAaR_1344[] Convert(List<L3PR_GPfAaR_1344_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3PR_GPfAaR_1344 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.TMS_PRO_ProjectMemberID)).ToArray()
	group el_L3PR_GPfAaR_1344 by new 
	{ 
		el_L3PR_GPfAaR_1344.TMS_PRO_ProjectMemberID,

	}
	into gfunct_L3PR_GPfAaR_1344
	select new L3PR_GPfAaR_1344
	{     
		TMS_PRO_ProjectMemberID = gfunct_L3PR_GPfAaR_1344.Key.TMS_PRO_ProjectMemberID ,
		TMS_PRO_ProjectID = gfunct_L3PR_GPfAaR_1344.FirstOrDefault().TMS_PRO_ProjectID ,
		DOC_Structure_Header_RefID = gfunct_L3PR_GPfAaR_1344.FirstOrDefault().DOC_Structure_Header_RefID ,
		Name = gfunct_L3PR_GPfAaR_1344.FirstOrDefault().Name ,
		Status_RefID = gfunct_L3PR_GPfAaR_1344.FirstOrDefault().Status_RefID ,
		IsArchived = gfunct_L3PR_GPfAaR_1344.FirstOrDefault().IsArchived ,
		Creation_Timestamp = gfunct_L3PR_GPfAaR_1344.FirstOrDefault().Creation_Timestamp ,
		Description = gfunct_L3PR_GPfAaR_1344.FirstOrDefault().Description ,

		RightsPackages = 
		(
			from el_RightsPackages in gfunct_L3PR_GPfAaR_1344.Where(element => !EqualsDefaultValue(element.ACC_RightsPackage_RefID)).ToArray()
			group el_RightsPackages by new 
			{ 
				el_RightsPackages.ACC_RightsPackage_RefID,

			}
			into gfunct_RightsPackages
			select new L3PR_GPfAaR_1344a
			{     
				ACC_RightsPackage_RefID = gfunct_RightsPackages.Key.ACC_RightsPackage_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GPfAaR_1344_Array : FR_Base
	{
		public L3PR_GPfAaR_1344[] Result	{ get; set; } 
		public FR_L3PR_GPfAaR_1344_Array() : base() {}

		public FR_L3PR_GPfAaR_1344_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GPfAaR_1344 for attribute P_L3PR_GPfAaR_1344
		[DataContract]
		public class P_L3PR_GPfAaR_1344 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsArchived { get; set; } 
			[DataMember]
			public Guid[] RightPackIDList { get; set; } 

		}
		#endregion
		#region SClass L3PR_GPfAaR_1344 for attribute L3PR_GPfAaR_1344
		[DataContract]
		public class L3PR_GPfAaR_1344 
		{
			[DataMember]
			public L3PR_GPfAaR_1344a[] RightsPackages { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_ProjectMemberID { get; set; } 
			[DataMember]
			public Guid TMS_PRO_ProjectID { get; set; } 
			[DataMember]
			public Guid DOC_Structure_Header_RefID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Guid Status_RefID { get; set; } 
			[DataMember]
			public Boolean IsArchived { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L3PR_GPfAaR_1344a for attribute RightsPackages
		[DataContract]
		public class L3PR_GPfAaR_1344a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_RightsPackage_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GPfAaR_1344_Array cls_Get_Projects_for_AccountID_and_RightPackIDList(,P_L3PR_GPfAaR_1344 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GPfAaR_1344_Array invocationResult = cls_Get_Projects_for_AccountID_and_RightPackIDList.Invoke(connectionString,P_L3PR_GPfAaR_1344 Parameter,securityTicket);
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
var parameter = new CL3_Project.Atomic.Retrieval.P_L3PR_GPfAaR_1344();
parameter.IsArchived = ...;
parameter.RightPackIDList = ...;

*/
