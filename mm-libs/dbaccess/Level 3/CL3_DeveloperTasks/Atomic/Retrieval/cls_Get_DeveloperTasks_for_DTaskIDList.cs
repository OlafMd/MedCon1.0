/* 
 * Generated on 04-Dec-14 8:58:51 AM
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

namespace CL3_DeveloperTask.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperTasks_for_DTaskIDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperTasks_for_DTaskIDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DT_GDTfDTL_0843_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3DT_GDTfDTL_0843 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DT_GDTfDTL_0843_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperTasks_for_DTaskIDList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@DTaskIDList"," IN $$DTaskIDList$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$DTaskIDList$",Parameter.DTaskIDList);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IncludeCompleted", Parameter.IncludeCompleted);



			List<L3DT_GDTfDTL_0843_raw> results = new List<L3DT_GDTfDTL_0843_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_DeveloperTaskID","Name","IdentificationNumber","DOC_Structure_Header_RefID","DeveloperTime_CurrentInvestment_min","DeveloperTime_RequiredEstimation_min","PercentageComplete","Description","Completion_Deadline","TMS_PRO_DeveloperTask_PriorityID","Priority_Level","Priority_Label_DictID","Priority_IconLocationURL","TMS_PRO_DeveloperTask_TypeID","Type_Label_DictID","Type_IconLocationURL","Creation_Timestamp","IsComplete","IsBeingPrepared","IsIncompleteInformation","Completion_Timestamp","IsArchived","ProjectMember_RefID","TMS_PRO_DeveloperTask_InvolvementID","OrderSequence","R_InvestedWorkingTime_min","Assignment_Timestamp","Developer_CompletionTimeEstimation_min","IsActive","Assignment_Username","CreatedBy_Username","CMN_PRO_Product_ReleaseID","Product_ReleaseName","Product_Name_DictID","Name_DictID","FeaturType_Dict","Priority_Colour","DocCount","USR_AccountID","Username" });
				while(reader.Read())
				{
					L3DT_GDTfDTL_0843_raw resultItem = new L3DT_GDTfDTL_0843_raw();
					//0:Parameter TMS_PRO_DeveloperTaskID of type Guid
					resultItem.TMS_PRO_DeveloperTaskID = reader.GetGuid(0);
					//1:Parameter Name of type String
					resultItem.Name = reader.GetString(1);
					//2:Parameter IdentificationNumber of type String
					resultItem.IdentificationNumber = reader.GetString(2);
					//3:Parameter DOC_Structure_Header_RefID of type Guid
					resultItem.DOC_Structure_Header_RefID = reader.GetGuid(3);
					//4:Parameter DeveloperTime_CurrentInvestment_min of type Double
					resultItem.DeveloperTime_CurrentInvestment_min = reader.GetDouble(4);
					//5:Parameter DeveloperTime_RequiredEstimation_min of type Double
					resultItem.DeveloperTime_RequiredEstimation_min = reader.GetDouble(5);
					//6:Parameter PercentageComplete of type Double
					resultItem.PercentageComplete = reader.GetDouble(6);
					//7:Parameter Description of type String
					resultItem.Description = reader.GetString(7);
					//8:Parameter Completion_Deadline of type DateTime
					resultItem.Completion_Deadline = reader.GetDate(8);
					//9:Parameter TMS_PRO_DeveloperTask_PriorityID of type Guid
					resultItem.TMS_PRO_DeveloperTask_PriorityID = reader.GetGuid(9);
					//10:Parameter Priority_Level of type int
					resultItem.Priority_Level = reader.GetInteger(10);
					//11:Parameter Priority_Label of type Dict
					resultItem.Priority_Label = reader.GetDictionary(11);
					resultItem.Priority_Label.SourceTable = "tms_pro_developertask_priorities";
					loader.Append(resultItem.Priority_Label);
					//12:Parameter Priority_IconLocationURL of type String
					resultItem.Priority_IconLocationURL = reader.GetString(12);
					//13:Parameter TMS_PRO_DeveloperTask_TypeID of type Guid
					resultItem.TMS_PRO_DeveloperTask_TypeID = reader.GetGuid(13);
					//14:Parameter Type_Label of type Dict
					resultItem.Type_Label = reader.GetDictionary(14);
					resultItem.Type_Label.SourceTable = "tms_pro_developertask_types";
					loader.Append(resultItem.Type_Label);
					//15:Parameter Type_IconLocationURL of type String
					resultItem.Type_IconLocationURL = reader.GetString(15);
					//16:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(16);
					//17:Parameter IsComplete of type bool
					resultItem.IsComplete = reader.GetBoolean(17);
					//18:Parameter IsBeingPrepared of type bool
					resultItem.IsBeingPrepared = reader.GetBoolean(18);
					//19:Parameter IsIncompleteInformation of type bool
					resultItem.IsIncompleteInformation = reader.GetBoolean(19);
					//20:Parameter Completion_Timestamp of type DateTime
					resultItem.Completion_Timestamp = reader.GetDate(20);
					//21:Parameter IsArchived of type bool
					resultItem.IsArchived = reader.GetBoolean(21);
					//22:Parameter ProjectMember_RefID of type Guid
					resultItem.ProjectMember_RefID = reader.GetGuid(22);
					//23:Parameter TMS_PRO_DeveloperTask_InvolvementID of type Guid
					resultItem.TMS_PRO_DeveloperTask_InvolvementID = reader.GetGuid(23);
					//24:Parameter OrderSequence of type int
					resultItem.OrderSequence = reader.GetInteger(24);
					//25:Parameter R_InvestedWorkingTime_min of type long
					resultItem.R_InvestedWorkingTime_min = reader.GetLong(25);
					//26:Parameter Assignment_Timestamp of type DateTime
					resultItem.Assignment_Timestamp = reader.GetDate(26);
					//27:Parameter Developer_CompletionTimeEstimation_min of type long
					resultItem.Developer_CompletionTimeEstimation_min = reader.GetLong(27);
					//28:Parameter IsActive of type bool
					resultItem.IsActive = reader.GetBoolean(28);
					//29:Parameter Assignment_Username of type String
					resultItem.Assignment_Username = reader.GetString(29);
					//30:Parameter CreatedBy_Username of type String
					resultItem.CreatedBy_Username = reader.GetString(30);
					//31:Parameter CMN_PRO_Product_ReleaseID of type Guid
					resultItem.CMN_PRO_Product_ReleaseID = reader.GetGuid(31);
					//32:Parameter Product_ReleaseName of type String
					resultItem.Product_ReleaseName = reader.GetString(32);
					//33:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(33);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//34:Parameter Project_Name of type Dict
					resultItem.Project_Name = reader.GetDictionary(34);
					resultItem.Project_Name.SourceTable = "tms_pro_projects";
					loader.Append(resultItem.Project_Name);
					//35:Parameter FeaturType_Dict of type Dict
					resultItem.FeaturType_Dict = reader.GetDictionary(35);
					resultItem.FeaturType_Dict.SourceTable = "tms_pro_feature_type";
					loader.Append(resultItem.FeaturType_Dict);
					//36:Parameter Priority_Colour of type String
					resultItem.Priority_Colour = reader.GetString(36);
					//37:Parameter DocCount of type int
					resultItem.DocCount = reader.GetInteger(37);
					//38:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(38);
					//39:Parameter Username of type String
					resultItem.Username = reader.GetString(39);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperTasks_for_DTaskIDList",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3DT_GDTfDTL_0843_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3DT_GDTfDTL_0843_Array Invoke(string ConnectionString,P_L3DT_GDTfDTL_0843 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DT_GDTfDTL_0843_Array Invoke(DbConnection Connection,P_L3DT_GDTfDTL_0843 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DT_GDTfDTL_0843_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DT_GDTfDTL_0843 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DT_GDTfDTL_0843_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DT_GDTfDTL_0843 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DT_GDTfDTL_0843_Array functionReturn = new FR_L3DT_GDTfDTL_0843_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperTasks_for_DTaskIDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3DT_GDTfDTL_0843_raw 
	{
		public Guid TMS_PRO_DeveloperTaskID; 
		public String Name; 
		public String IdentificationNumber; 
		public Guid DOC_Structure_Header_RefID; 
		public Double DeveloperTime_CurrentInvestment_min; 
		public Double DeveloperTime_RequiredEstimation_min; 
		public Double PercentageComplete; 
		public String Description; 
		public DateTime Completion_Deadline; 
		public Guid TMS_PRO_DeveloperTask_PriorityID; 
		public int Priority_Level; 
		public Dict Priority_Label; 
		public String Priority_IconLocationURL; 
		public Guid TMS_PRO_DeveloperTask_TypeID; 
		public Dict Type_Label; 
		public String Type_IconLocationURL; 
		public DateTime Creation_Timestamp; 
		public bool IsComplete; 
		public bool IsBeingPrepared; 
		public bool IsIncompleteInformation; 
		public DateTime Completion_Timestamp; 
		public bool IsArchived; 
		public Guid ProjectMember_RefID; 
		public Guid TMS_PRO_DeveloperTask_InvolvementID; 
		public int OrderSequence; 
		public long R_InvestedWorkingTime_min; 
		public DateTime Assignment_Timestamp; 
		public long Developer_CompletionTimeEstimation_min; 
		public bool IsActive; 
		public String Assignment_Username; 
		public String CreatedBy_Username; 
		public Guid CMN_PRO_Product_ReleaseID; 
		public String Product_ReleaseName; 
		public Dict Product_Name; 
		public Dict Project_Name; 
		public Dict FeaturType_Dict; 
		public String Priority_Colour; 
		public int DocCount; 
		public Guid USR_AccountID; 
		public String Username; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3DT_GDTfDTL_0843[] Convert(List<L3DT_GDTfDTL_0843_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3DT_GDTfDTL_0843 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.TMS_PRO_DeveloperTaskID)).ToArray()
	group el_L3DT_GDTfDTL_0843 by new 
	{ 
		el_L3DT_GDTfDTL_0843.TMS_PRO_DeveloperTaskID,

	}
	into gfunct_L3DT_GDTfDTL_0843
	select new L3DT_GDTfDTL_0843
	{     
		TMS_PRO_DeveloperTaskID = gfunct_L3DT_GDTfDTL_0843.Key.TMS_PRO_DeveloperTaskID ,
		Name = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Name ,
		IdentificationNumber = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().IdentificationNumber ,
		DOC_Structure_Header_RefID = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().DOC_Structure_Header_RefID ,
		DeveloperTime_CurrentInvestment_min = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().DeveloperTime_CurrentInvestment_min ,
		DeveloperTime_RequiredEstimation_min = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().DeveloperTime_RequiredEstimation_min ,
		PercentageComplete = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().PercentageComplete ,
		Description = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Description ,
		Completion_Deadline = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Completion_Deadline ,
		TMS_PRO_DeveloperTask_PriorityID = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().TMS_PRO_DeveloperTask_PriorityID ,
		Priority_Level = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Priority_Level ,
		Priority_Label = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Priority_Label ,
		Priority_IconLocationURL = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Priority_IconLocationURL ,
		TMS_PRO_DeveloperTask_TypeID = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().TMS_PRO_DeveloperTask_TypeID ,
		Type_Label = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Type_Label ,
		Type_IconLocationURL = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Type_IconLocationURL ,
		Creation_Timestamp = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Creation_Timestamp ,
		IsComplete = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().IsComplete ,
		IsBeingPrepared = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().IsBeingPrepared ,
		IsIncompleteInformation = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().IsIncompleteInformation ,
		Completion_Timestamp = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Completion_Timestamp ,
		IsArchived = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().IsArchived ,
		ProjectMember_RefID = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().ProjectMember_RefID ,
		TMS_PRO_DeveloperTask_InvolvementID = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().TMS_PRO_DeveloperTask_InvolvementID ,
		OrderSequence = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().OrderSequence ,
		R_InvestedWorkingTime_min = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().R_InvestedWorkingTime_min ,
		Assignment_Timestamp = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Assignment_Timestamp ,
		Developer_CompletionTimeEstimation_min = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Developer_CompletionTimeEstimation_min ,
		IsActive = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().IsActive ,
		Assignment_Username = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Assignment_Username ,
		CreatedBy_Username = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().CreatedBy_Username ,
		CMN_PRO_Product_ReleaseID = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().CMN_PRO_Product_ReleaseID ,
		Product_ReleaseName = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Product_ReleaseName ,
		Product_Name = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Product_Name ,
		Project_Name = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Project_Name ,
		FeaturType_Dict = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().FeaturType_Dict ,
		Priority_Colour = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().Priority_Colour ,
		DocCount = gfunct_L3DT_GDTfDTL_0843.FirstOrDefault().DocCount ,

		RecommendedTo = 
		(
			from el_RecommendedTo in gfunct_L3DT_GDTfDTL_0843.Where(element => !EqualsDefaultValue(element.USR_AccountID)).ToArray()
			group el_RecommendedTo by new 
			{ 
				el_RecommendedTo.USR_AccountID,

			}
			into gfunct_RecommendedTo
			select new L3DT_GDTfDTL_0843a
			{     
				USR_AccountID = gfunct_RecommendedTo.Key.USR_AccountID ,
				Username = gfunct_RecommendedTo.FirstOrDefault().Username ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3DT_GDTfDTL_0843_Array : FR_Base
	{
		public L3DT_GDTfDTL_0843[] Result	{ get; set; } 
		public FR_L3DT_GDTfDTL_0843_Array() : base() {}

		public FR_L3DT_GDTfDTL_0843_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DT_GDTfDTL_0843 for attribute P_L3DT_GDTfDTL_0843
		[DataContract]
		public class P_L3DT_GDTfDTL_0843 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] DTaskIDList { get; set; } 
			[DataMember]
			public bool IncludeCompleted { get; set; } 

		}
		#endregion
		#region SClass L3DT_GDTfDTL_0843 for attribute L3DT_GDTfDTL_0843
		[DataContract]
		public class L3DT_GDTfDTL_0843 
		{
			[DataMember]
			public L3DT_GDTfDTL_0843a[] RecommendedTo { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_DeveloperTaskID { get; set; } 
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public Guid DOC_Structure_Header_RefID { get; set; } 
			[DataMember]
			public Double DeveloperTime_CurrentInvestment_min { get; set; } 
			[DataMember]
			public Double DeveloperTime_RequiredEstimation_min { get; set; } 
			[DataMember]
			public Double PercentageComplete { get; set; } 
			[DataMember]
			public String Description { get; set; } 
			[DataMember]
			public DateTime Completion_Deadline { get; set; } 
			[DataMember]
			public Guid TMS_PRO_DeveloperTask_PriorityID { get; set; } 
			[DataMember]
			public int Priority_Level { get; set; } 
			[DataMember]
			public Dict Priority_Label { get; set; } 
			[DataMember]
			public String Priority_IconLocationURL { get; set; } 
			[DataMember]
			public Guid TMS_PRO_DeveloperTask_TypeID { get; set; } 
			[DataMember]
			public Dict Type_Label { get; set; } 
			[DataMember]
			public String Type_IconLocationURL { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsComplete { get; set; } 
			[DataMember]
			public bool IsBeingPrepared { get; set; } 
			[DataMember]
			public bool IsIncompleteInformation { get; set; } 
			[DataMember]
			public DateTime Completion_Timestamp { get; set; } 
			[DataMember]
			public bool IsArchived { get; set; } 
			[DataMember]
			public Guid ProjectMember_RefID { get; set; } 
			[DataMember]
			public Guid TMS_PRO_DeveloperTask_InvolvementID { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 
			[DataMember]
			public long R_InvestedWorkingTime_min { get; set; } 
			[DataMember]
			public DateTime Assignment_Timestamp { get; set; } 
			[DataMember]
			public long Developer_CompletionTimeEstimation_min { get; set; } 
			[DataMember]
			public bool IsActive { get; set; } 
			[DataMember]
			public String Assignment_Username { get; set; } 
			[DataMember]
			public String CreatedBy_Username { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_ReleaseID { get; set; } 
			[DataMember]
			public String Product_ReleaseName { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Project_Name { get; set; } 
			[DataMember]
			public Dict FeaturType_Dict { get; set; } 
			[DataMember]
			public String Priority_Colour { get; set; } 
			[DataMember]
			public int DocCount { get; set; } 

		}
		#endregion
		#region SClass L3DT_GDTfDTL_0843a for attribute RecommendedTo
		[DataContract]
		public class L3DT_GDTfDTL_0843a 
		{
			//Standard type parameters
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public String Username { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DT_GDTfDTL_0843_Array cls_Get_DeveloperTasks_for_DTaskIDList(,P_L3DT_GDTfDTL_0843 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DT_GDTfDTL_0843_Array invocationResult = cls_Get_DeveloperTasks_for_DTaskIDList.Invoke(connectionString,P_L3DT_GDTfDTL_0843 Parameter,securityTicket);
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
var parameter = new CL3_DeveloperTask.Atomic.Retrieval.P_L3DT_GDTfDTL_0843();
parameter.DTaskIDList = ...;
parameter.IncludeCompleted = ...;

*/
