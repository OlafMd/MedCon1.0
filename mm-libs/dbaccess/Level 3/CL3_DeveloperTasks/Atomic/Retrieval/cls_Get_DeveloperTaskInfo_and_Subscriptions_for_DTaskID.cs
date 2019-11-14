/* 
 * Generated on 03-Dec-14 4:56:54 PM
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
    /// var result = cls_Get_DeveloperTaskInfo_and_Subscriptions_for_DTaskID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperTaskInfo_and_Subscriptions_for_DTaskID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DT_GDTIaSfDT_1654 Execute(DbConnection Connection,DbTransaction Transaction,P_L3DT_GDTIaSfDT_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DT_GDTIaSfDT_1654();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperTaskInfo_and_Subscriptions_for_DTaskID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DTaskID", Parameter.DTaskID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsBeingPrepared_Only", Parameter.IsBeingPrepared_Only);



			List<L3DT_GDTIaSfDT_1654_raw> results = new List<L3DT_GDTIaSfDT_1654_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_DeveloperTaskID","DOC_Structure_Header_RefID","IdentificationNumber","Name","DeveloperTime_CurrentInvestment_min","DeveloperTime_RequiredEstimation_min","PercentageComplete","Description","Completion_Deadline","TMS_PRO_DeveloperTask_PriorityID","Priority_Label_DictID","Priority_IconLocationURL","PriorityLevel","TMS_PRO_DeveloperTask_TypeID","Type_Label_DictID","Type_IconLocationURL","IsIncompleteInformation","Creation_Timestamp","IsArchived","IsComplete","Completion_Timestamp","IsBeingPrepared","Parent_RefID","Project_RefID","CreatedBy_Username","IsTaskEstimable","TMS_PRO_DeveloperTask_InvolvementID","OrderSequence","IsActive","R_InvestedWorkingTime_min","Developer_CompletionTimeEstimation_min","Assignment_Timestamp","IsDeleted","Assignment_To","AssignedTo_ProjectMemberID","CMN_PRO_Product_Release_RefID","PeersDevelopmentAssignmentID","TMS_PRO_ProjectMemberID","RecommendedTo_ProjectMemberID","RecommendedTo_AccountID","RecommendedTo_Username" });
				while(reader.Read())
				{
					L3DT_GDTIaSfDT_1654_raw resultItem = new L3DT_GDTIaSfDT_1654_raw();
					//0:Parameter TMS_PRO_DeveloperTaskID of type Guid
					resultItem.TMS_PRO_DeveloperTaskID = reader.GetGuid(0);
					//1:Parameter DOC_Structure_Header_RefID of type Guid
					resultItem.DOC_Structure_Header_RefID = reader.GetGuid(1);
					//2:Parameter IdentificationNumber of type String
					resultItem.IdentificationNumber = reader.GetString(2);
					//3:Parameter Name of type String
					resultItem.Name = reader.GetString(3);
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
					//10:Parameter Priority_Label of type Dict
					resultItem.Priority_Label = reader.GetDictionary(10);
					resultItem.Priority_Label.SourceTable = "tms_pro_developertask_priorities";
					loader.Append(resultItem.Priority_Label);
					//11:Parameter Priority_IconLocationURL of type String
					resultItem.Priority_IconLocationURL = reader.GetString(11);
					//12:Parameter PriorityLevel of type String
					resultItem.PriorityLevel = reader.GetString(12);
					//13:Parameter TMS_PRO_DeveloperTask_TypeID of type Guid
					resultItem.TMS_PRO_DeveloperTask_TypeID = reader.GetGuid(13);
					//14:Parameter Type_Label of type Dict
					resultItem.Type_Label = reader.GetDictionary(14);
					resultItem.Type_Label.SourceTable = "tms_pro_developertask_types";
					loader.Append(resultItem.Type_Label);
					//15:Parameter Type_IconLocationURL of type String
					resultItem.Type_IconLocationURL = reader.GetString(15);
					//16:Parameter IsIncompleteInformation of type bool
					resultItem.IsIncompleteInformation = reader.GetBoolean(16);
					//17:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(17);
					//18:Parameter IsArchived of type bool
					resultItem.IsArchived = reader.GetBoolean(18);
					//19:Parameter IsComplete of type bool
					resultItem.IsComplete = reader.GetBoolean(19);
					//20:Parameter Completion_Timestamp of type DateTime
					resultItem.Completion_Timestamp = reader.GetDate(20);
					//21:Parameter IsBeingPrepared of type bool
					resultItem.IsBeingPrepared = reader.GetBoolean(21);
					//22:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(22);
					//23:Parameter Project_RefID of type Guid
					resultItem.Project_RefID = reader.GetGuid(23);
					//24:Parameter CreatedBy_Username of type String
					resultItem.CreatedBy_Username = reader.GetString(24);
					//25:Parameter IsTaskEstimable of type bool
					resultItem.IsTaskEstimable = reader.GetBoolean(25);
					//26:Parameter TMS_PRO_DeveloperTask_InvolvementID of type Guid
					resultItem.TMS_PRO_DeveloperTask_InvolvementID = reader.GetGuid(26);
					//27:Parameter OrderSequence of type int
					resultItem.OrderSequence = reader.GetInteger(27);
					//28:Parameter IsActive of type bool
					resultItem.IsActive = reader.GetBoolean(28);
					//29:Parameter R_InvestedWorkingTime_min of type long
					resultItem.R_InvestedWorkingTime_min = reader.GetLong(29);
					//30:Parameter Developer_CompletionTimeEstimation_min of type long
					resultItem.Developer_CompletionTimeEstimation_min = reader.GetLong(30);
					//31:Parameter Assignment_Timestamp of type DateTime
					resultItem.Assignment_Timestamp = reader.GetDate(31);
					//32:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(32);
					//33:Parameter Assignment_To of type String
					resultItem.Assignment_To = reader.GetString(33);
					//34:Parameter AssignedTo_ProjectMemberID of type Guid
					resultItem.AssignedTo_ProjectMemberID = reader.GetGuid(34);
					//35:Parameter CMN_PRO_Product_Release_RefID of type Guid
					resultItem.CMN_PRO_Product_Release_RefID = reader.GetGuid(35);
					//36:Parameter PeersDevelopmentAssignmentID of type Guid
					resultItem.PeersDevelopmentAssignmentID = reader.GetGuid(36);
					//37:Parameter TMS_PRO_ProjectMemberID of type Guid
					resultItem.TMS_PRO_ProjectMemberID = reader.GetGuid(37);
					//38:Parameter RecommendedTo_ProjectMemberID of type Guid
					resultItem.RecommendedTo_ProjectMemberID = reader.GetGuid(38);
					//39:Parameter RecommendedTo_AccountID of type Guid
					resultItem.RecommendedTo_AccountID = reader.GetGuid(39);
					//40:Parameter RecommendedTo_Username of type String
					resultItem.RecommendedTo_Username = reader.GetString(40);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperTaskInfo_and_Subscriptions_for_DTaskID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3DT_GDTIaSfDT_1654_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3DT_GDTIaSfDT_1654 Invoke(string ConnectionString,P_L3DT_GDTIaSfDT_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DT_GDTIaSfDT_1654 Invoke(DbConnection Connection,P_L3DT_GDTIaSfDT_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DT_GDTIaSfDT_1654 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DT_GDTIaSfDT_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DT_GDTIaSfDT_1654 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DT_GDTIaSfDT_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DT_GDTIaSfDT_1654 functionReturn = new FR_L3DT_GDTIaSfDT_1654();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperTaskInfo_and_Subscriptions_for_DTaskID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3DT_GDTIaSfDT_1654_raw 
	{
		public Guid TMS_PRO_DeveloperTaskID; 
		public Guid DOC_Structure_Header_RefID; 
		public String IdentificationNumber; 
		public String Name; 
		public Double DeveloperTime_CurrentInvestment_min; 
		public Double DeveloperTime_RequiredEstimation_min; 
		public Double PercentageComplete; 
		public String Description; 
		public DateTime Completion_Deadline; 
		public Guid TMS_PRO_DeveloperTask_PriorityID; 
		public Dict Priority_Label; 
		public String Priority_IconLocationURL; 
		public String PriorityLevel; 
		public Guid TMS_PRO_DeveloperTask_TypeID; 
		public Dict Type_Label; 
		public String Type_IconLocationURL; 
		public bool IsIncompleteInformation; 
		public DateTime Creation_Timestamp; 
		public bool IsArchived; 
		public bool IsComplete; 
		public DateTime Completion_Timestamp; 
		public bool IsBeingPrepared; 
		public Guid Parent_RefID; 
		public Guid Project_RefID; 
		public String CreatedBy_Username; 
		public bool IsTaskEstimable; 
		public Guid TMS_PRO_DeveloperTask_InvolvementID; 
		public int OrderSequence; 
		public bool IsActive; 
		public long R_InvestedWorkingTime_min; 
		public long Developer_CompletionTimeEstimation_min; 
		public DateTime Assignment_Timestamp; 
		public bool IsDeleted; 
		public String Assignment_To; 
		public Guid AssignedTo_ProjectMemberID; 
		public Guid CMN_PRO_Product_Release_RefID; 
		public Guid PeersDevelopmentAssignmentID; 
		public Guid TMS_PRO_ProjectMemberID; 
		public Guid RecommendedTo_ProjectMemberID; 
		public Guid RecommendedTo_AccountID; 
		public String RecommendedTo_Username; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3DT_GDTIaSfDT_1654[] Convert(List<L3DT_GDTIaSfDT_1654_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3DT_GDTIaSfDT_1654 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.TMS_PRO_DeveloperTaskID)).ToArray()
	group el_L3DT_GDTIaSfDT_1654 by new 
	{ 
		el_L3DT_GDTIaSfDT_1654.TMS_PRO_DeveloperTaskID,

	}
	into gfunct_L3DT_GDTIaSfDT_1654
	select new L3DT_GDTIaSfDT_1654
	{     
		TMS_PRO_DeveloperTaskID = gfunct_L3DT_GDTIaSfDT_1654.Key.TMS_PRO_DeveloperTaskID ,
		DOC_Structure_Header_RefID = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().DOC_Structure_Header_RefID ,
		IdentificationNumber = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().IdentificationNumber ,
		Name = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Name ,
		DeveloperTime_CurrentInvestment_min = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().DeveloperTime_CurrentInvestment_min ,
		DeveloperTime_RequiredEstimation_min = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().DeveloperTime_RequiredEstimation_min ,
		PercentageComplete = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().PercentageComplete ,
		Description = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Description ,
		Completion_Deadline = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Completion_Deadline ,
		TMS_PRO_DeveloperTask_PriorityID = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().TMS_PRO_DeveloperTask_PriorityID ,
		Priority_Label = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Priority_Label ,
		Priority_IconLocationURL = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Priority_IconLocationURL ,
		PriorityLevel = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().PriorityLevel ,
		TMS_PRO_DeveloperTask_TypeID = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().TMS_PRO_DeveloperTask_TypeID ,
		Type_Label = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Type_Label ,
		Type_IconLocationURL = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Type_IconLocationURL ,
		IsIncompleteInformation = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().IsIncompleteInformation ,
		Creation_Timestamp = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Creation_Timestamp ,
		IsArchived = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().IsArchived ,
		IsComplete = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().IsComplete ,
		Completion_Timestamp = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Completion_Timestamp ,
		IsBeingPrepared = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().IsBeingPrepared ,
		Parent_RefID = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Parent_RefID ,
		Project_RefID = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Project_RefID ,
		CreatedBy_Username = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().CreatedBy_Username ,
		IsTaskEstimable = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().IsTaskEstimable ,
		TMS_PRO_DeveloperTask_InvolvementID = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().TMS_PRO_DeveloperTask_InvolvementID ,
		OrderSequence = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().OrderSequence ,
		IsActive = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().IsActive ,
		R_InvestedWorkingTime_min = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().R_InvestedWorkingTime_min ,
		Developer_CompletionTimeEstimation_min = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Developer_CompletionTimeEstimation_min ,
		Assignment_Timestamp = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Assignment_Timestamp ,
		IsDeleted = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().IsDeleted ,
		Assignment_To = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().Assignment_To ,
		AssignedTo_ProjectMemberID = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().AssignedTo_ProjectMemberID ,
		CMN_PRO_Product_Release_RefID = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().CMN_PRO_Product_Release_RefID ,
		PeersDevelopmentAssignmentID = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().PeersDevelopmentAssignmentID ,
		TMS_PRO_ProjectMemberID = gfunct_L3DT_GDTIaSfDT_1654.FirstOrDefault().TMS_PRO_ProjectMemberID ,

		RecommendedTo = 
		(
			from el_RecommendedTo in gfunct_L3DT_GDTIaSfDT_1654.Where(element => !EqualsDefaultValue(element.RecommendedTo_AccountID)).ToArray()
			group el_RecommendedTo by new 
			{ 
				el_RecommendedTo.RecommendedTo_AccountID,

			}
			into gfunct_RecommendedTo
			select new L3DT_GDTIaSfDT_1654a
			{     
				RecommendedTo_ProjectMemberID = gfunct_RecommendedTo.FirstOrDefault().RecommendedTo_ProjectMemberID ,
				RecommendedTo_AccountID = gfunct_RecommendedTo.Key.RecommendedTo_AccountID ,
				RecommendedTo_Username = gfunct_RecommendedTo.FirstOrDefault().RecommendedTo_Username ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3DT_GDTIaSfDT_1654 : FR_Base
	{
		public L3DT_GDTIaSfDT_1654 Result	{ get; set; }

		public FR_L3DT_GDTIaSfDT_1654() : base() {}

		public FR_L3DT_GDTIaSfDT_1654(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DT_GDTIaSfDT_1654 for attribute P_L3DT_GDTIaSfDT_1654
		[DataContract]
		public class P_L3DT_GDTIaSfDT_1654 
		{
			//Standard type parameters
			[DataMember]
			public Guid DTaskID { get; set; } 
			[DataMember]
			public Boolean IsBeingPrepared_Only { get; set; } 

		}
		#endregion
		#region SClass L3DT_GDTIaSfDT_1654 for attribute L3DT_GDTIaSfDT_1654
		[DataContract]
		public class L3DT_GDTIaSfDT_1654 
		{
			[DataMember]
			public L3DT_GDTIaSfDT_1654a[] RecommendedTo { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_DeveloperTaskID { get; set; } 
			[DataMember]
			public Guid DOC_Structure_Header_RefID { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public String Name { get; set; } 
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
			public Dict Priority_Label { get; set; } 
			[DataMember]
			public String Priority_IconLocationURL { get; set; } 
			[DataMember]
			public String PriorityLevel { get; set; } 
			[DataMember]
			public Guid TMS_PRO_DeveloperTask_TypeID { get; set; } 
			[DataMember]
			public Dict Type_Label { get; set; } 
			[DataMember]
			public String Type_IconLocationURL { get; set; } 
			[DataMember]
			public bool IsIncompleteInformation { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsArchived { get; set; } 
			[DataMember]
			public bool IsComplete { get; set; } 
			[DataMember]
			public DateTime Completion_Timestamp { get; set; } 
			[DataMember]
			public bool IsBeingPrepared { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public String CreatedBy_Username { get; set; } 
			[DataMember]
			public bool IsTaskEstimable { get; set; } 
			[DataMember]
			public Guid TMS_PRO_DeveloperTask_InvolvementID { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 
			[DataMember]
			public bool IsActive { get; set; } 
			[DataMember]
			public long R_InvestedWorkingTime_min { get; set; } 
			[DataMember]
			public long Developer_CompletionTimeEstimation_min { get; set; } 
			[DataMember]
			public DateTime Assignment_Timestamp { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public String Assignment_To { get; set; } 
			[DataMember]
			public Guid AssignedTo_ProjectMemberID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_Release_RefID { get; set; } 
			[DataMember]
			public Guid PeersDevelopmentAssignmentID { get; set; } 
			[DataMember]
			public Guid TMS_PRO_ProjectMemberID { get; set; } 

		}
		#endregion
		#region SClass L3DT_GDTIaSfDT_1654a for attribute RecommendedTo
		[DataContract]
		public class L3DT_GDTIaSfDT_1654a 
		{
			//Standard type parameters
			[DataMember]
			public Guid RecommendedTo_ProjectMemberID { get; set; } 
			[DataMember]
			public Guid RecommendedTo_AccountID { get; set; } 
			[DataMember]
			public String RecommendedTo_Username { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DT_GDTIaSfDT_1654 cls_Get_DeveloperTaskInfo_and_Subscriptions_for_DTaskID(,P_L3DT_GDTIaSfDT_1654 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DT_GDTIaSfDT_1654 invocationResult = cls_Get_DeveloperTaskInfo_and_Subscriptions_for_DTaskID.Invoke(connectionString,P_L3DT_GDTIaSfDT_1654 Parameter,securityTicket);
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
var parameter = new CL3_DeveloperTask.Atomic.Retrieval.P_L3DT_GDTIaSfDT_1654();
parameter.DTaskID = ...;
parameter.IsBeingPrepared_Only = ...;

*/
