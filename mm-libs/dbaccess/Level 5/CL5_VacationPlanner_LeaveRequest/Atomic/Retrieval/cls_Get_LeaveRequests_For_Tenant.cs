/* 
 * Generated on 2/13/2014 2:57:37 PM
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
using PlannicoModel.Models;

namespace CL5_VacationPlanner_LeaveRequest.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_LeaveRequests_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LeaveRequests_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5LR_GLRFT_1643_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5LR_GLRFT_1643_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_LeaveRequest.Atomic.Retrieval.SQL.cls_Get_LeaveRequests_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5LR_GLRFT_1643_raw> results = new List<L5LR_GLRFT_1643_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ShortName","Name_DictID","Description_DictID","ColorCode","Parent_RefID","IsAuthorizationRequired","IsIncludedInCapacityCalculation","AbsenceReason_Type_RefID","IsAllowedAbsence","IsDeactivated","IsCarryOverEnabled","IsCaryOverLimited","IfCarryOverLimited_MaximumAmount_Hrs","CMN_BPT_EMP_Employee_LeaveRequestID","CMN_CAL_Event_RefID","CMN_CAL_Event_Approval_RefID","CMN_BPT_STA_AbsenceReason_RefID","Comment","StartTime","EndTime","R_EventDuration_sec","CalendarInstance_RefID","IsApprovalProcessDenied","ForEmployeeID","ForEmployee_BusinessParticipant_RefID","ForEmployee_Staff_Number","ForEmployee_StandardFunction","IsApproved","IsApprovalProcessOpened","IsApprovalProcessCanceledByUser","StandardFunction","BusinessParticipant_RefID","CMN_BPT_EMP_EmployeeID","SequenceNumber","CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID","ActionTriggeredBy_Account_RefID","CMN_CAL_Event_Approval_ActionID","IsApproval","IsRevocation","IsDenial","Approval_Action_Commnet" });
				while(reader.Read())
				{
					L5LR_GLRFT_1643_raw resultItem = new L5LR_GLRFT_1643_raw();
					//0:Parameter ShortName of type string
					resultItem.ShortName = reader.GetString(0);
					//1:Parameter ReasonName of type Dict
					resultItem.ReasonName = reader.GetDictionary(1);
					resultItem.ReasonName.SourceTable = "cmn_bpt_sta_absencereasons";
					loader.Append(resultItem.ReasonName);
					//2:Parameter ReasonDesc of type Dict
					resultItem.ReasonDesc = reader.GetDictionary(2);
					resultItem.ReasonDesc.SourceTable = "cmn_bpt_sta_absencereasons";
					loader.Append(resultItem.ReasonDesc);
					//3:Parameter ColorCode of type string
					resultItem.ColorCode = reader.GetString(3);
					//4:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(4);
					//5:Parameter IsAuthorizationRequired of type bool
					resultItem.IsAuthorizationRequired = reader.GetBoolean(5);
					//6:Parameter IsIncludedInCapacityCalculation of type bool
					resultItem.IsIncludedInCapacityCalculation = reader.GetBoolean(6);
					//7:Parameter AbsenceReason_Type_RefID of type Guid
					resultItem.AbsenceReason_Type_RefID = reader.GetGuid(7);
					//8:Parameter IsAllowedAbsence of type bool
					resultItem.IsAllowedAbsence = reader.GetBoolean(8);
					//9:Parameter IsDeactivated of type bool
					resultItem.IsDeactivated = reader.GetBoolean(9);
					//10:Parameter IsCarryOverEnabled of type bool
					resultItem.IsCarryOverEnabled = reader.GetBoolean(10);
					//11:Parameter IsCaryOverLimited of type bool
					resultItem.IsCaryOverLimited = reader.GetBoolean(11);
					//12:Parameter IfCarryOverLimited_MaximumAmount_Hrs of type double
					resultItem.IfCarryOverLimited_MaximumAmount_Hrs = reader.GetDouble(12);
					//13:Parameter CMN_BPT_EMP_Employee_LeaveRequestID of type Guid
					resultItem.CMN_BPT_EMP_Employee_LeaveRequestID = reader.GetGuid(13);
					//14:Parameter CMN_CAL_Event_RefID of type Guid
					resultItem.CMN_CAL_Event_RefID = reader.GetGuid(14);
					//15:Parameter CMN_CAL_Event_Approval_RefID of type Guid
					resultItem.CMN_CAL_Event_Approval_RefID = reader.GetGuid(15);
					//16:Parameter CMN_BPT_STA_AbsenceReason_RefID of type Guid
					resultItem.CMN_BPT_STA_AbsenceReason_RefID = reader.GetGuid(16);
					//17:Parameter Comment of type string
					resultItem.Comment = reader.GetString(17);
					//18:Parameter StartTime of type DateTime
					resultItem.StartTime = reader.GetDate(18);
					//19:Parameter EndTime of type DateTime
					resultItem.EndTime = reader.GetDate(19);
					//20:Parameter R_EventDuration_sec of type long
					resultItem.R_EventDuration_sec = reader.GetLong(20);
					//21:Parameter CalendarInstance_RefID of type Guid
					resultItem.CalendarInstance_RefID = reader.GetGuid(21);
					//22:Parameter IsApprovalProcessDenied of type bool
					resultItem.IsApprovalProcessDenied = reader.GetBoolean(22);
					//23:Parameter ForEmployeeID of type Guid
					resultItem.ForEmployeeID = reader.GetGuid(23);
					//24:Parameter ForEmployee_BusinessParticipant_RefID of type Guid
					resultItem.ForEmployee_BusinessParticipant_RefID = reader.GetGuid(24);
					//25:Parameter ForEmployee_Staff_Number of type string
					resultItem.ForEmployee_Staff_Number = reader.GetString(25);
					//26:Parameter ForEmployee_StandardFunction of type string
					resultItem.ForEmployee_StandardFunction = reader.GetString(26);
					//27:Parameter IsApproved of type bool
					resultItem.IsApproved = reader.GetBoolean(27);
					//28:Parameter IsApprovalProcessOpened of type bool
					resultItem.IsApprovalProcessOpened = reader.GetBoolean(28);
					//29:Parameter IsApprovalProcessCanceledByUser of type bool
					resultItem.IsApprovalProcessCanceledByUser = reader.GetBoolean(29);
					//30:Parameter StandardFunction of type string
					resultItem.StandardFunction = reader.GetString(30);
					//31:Parameter BusinessParticipant_RefID of type Guid
					resultItem.BusinessParticipant_RefID = reader.GetGuid(31);
					//32:Parameter CMN_BPT_EMP_EmployeeID of type Guid
					resultItem.CMN_BPT_EMP_EmployeeID = reader.GetGuid(32);
					//33:Parameter SequenceNumber of type string
					resultItem.SequenceNumber = reader.GetString(33);
					//34:Parameter CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID of type Guid
					resultItem.CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID = reader.GetGuid(34);
					//35:Parameter ActionTriggeredBy_Account_RefID of type Guid
					resultItem.ActionTriggeredBy_Account_RefID = reader.GetGuid(35);
					//36:Parameter CMN_CAL_Event_Approval_ActionID of type Guid
					resultItem.CMN_CAL_Event_Approval_ActionID = reader.GetGuid(36);
					//37:Parameter IsApproval of type bool
					resultItem.IsApproval = reader.GetBoolean(37);
					//38:Parameter IsRevocation of type bool
					resultItem.IsRevocation = reader.GetBoolean(38);
					//39:Parameter IsDenial of type bool
					resultItem.IsDenial = reader.GetBoolean(39);
					//40:Parameter Approval_Action_Commnet of type string
					resultItem.Approval_Action_Commnet = reader.GetString(40);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_LeaveRequests_For_Tenant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5LR_GLRFT_1643_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5LR_GLRFT_1643_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5LR_GLRFT_1643_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5LR_GLRFT_1643_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5LR_GLRFT_1643_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5LR_GLRFT_1643_Array functionReturn = new FR_L5LR_GLRFT_1643_Array();
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

				throw new Exception("Exception occured in method cls_Get_LeaveRequests_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5LR_GLRFT_1643_raw 
	{
		public string ShortName; 
		public Dict ReasonName; 
		public Dict ReasonDesc; 
		public string ColorCode; 
		public Guid Parent_RefID; 
		public bool IsAuthorizationRequired; 
		public bool IsIncludedInCapacityCalculation; 
		public Guid AbsenceReason_Type_RefID; 
		public bool IsAllowedAbsence; 
		public bool IsDeactivated; 
		public bool IsCarryOverEnabled; 
		public bool IsCaryOverLimited; 
		public double IfCarryOverLimited_MaximumAmount_Hrs; 
		public Guid CMN_BPT_EMP_Employee_LeaveRequestID; 
		public Guid CMN_CAL_Event_RefID; 
		public Guid CMN_CAL_Event_Approval_RefID; 
		public Guid CMN_BPT_STA_AbsenceReason_RefID; 
		public string Comment; 
		public DateTime StartTime; 
		public DateTime EndTime; 
		public long R_EventDuration_sec; 
		public Guid CalendarInstance_RefID; 
		public bool IsApprovalProcessDenied; 
		public Guid ForEmployeeID; 
		public Guid ForEmployee_BusinessParticipant_RefID; 
		public string ForEmployee_Staff_Number; 
		public string ForEmployee_StandardFunction; 
		public bool IsApproved; 
		public bool IsApprovalProcessOpened; 
		public bool IsApprovalProcessCanceledByUser; 
		public string StandardFunction; 
		public Guid BusinessParticipant_RefID; 
		public Guid CMN_BPT_EMP_EmployeeID; 
		public string SequenceNumber; 
		public Guid CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID; 
		public Guid ActionTriggeredBy_Account_RefID; 
		public Guid CMN_CAL_Event_Approval_ActionID; 
		public bool IsApproval; 
		public bool IsRevocation; 
		public bool IsDenial; 
		public string Approval_Action_Commnet; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5LR_GLRFT_1643[] Convert(List<L5LR_GLRFT_1643_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5LR_GLRFT_1643 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_Employee_LeaveRequestID)).ToArray()
	group el_L5LR_GLRFT_1643 by new 
	{ 
		el_L5LR_GLRFT_1643.CMN_BPT_EMP_Employee_LeaveRequestID,

	}
	into gfunct_L5LR_GLRFT_1643
	select new L5LR_GLRFT_1643
	{     
		ShortName = gfunct_L5LR_GLRFT_1643.FirstOrDefault().ShortName ,
		ReasonName = gfunct_L5LR_GLRFT_1643.FirstOrDefault().ReasonName ,
		ReasonDesc = gfunct_L5LR_GLRFT_1643.FirstOrDefault().ReasonDesc ,
		ColorCode = gfunct_L5LR_GLRFT_1643.FirstOrDefault().ColorCode ,
		Parent_RefID = gfunct_L5LR_GLRFT_1643.FirstOrDefault().Parent_RefID ,
		IsAuthorizationRequired = gfunct_L5LR_GLRFT_1643.FirstOrDefault().IsAuthorizationRequired ,
		IsIncludedInCapacityCalculation = gfunct_L5LR_GLRFT_1643.FirstOrDefault().IsIncludedInCapacityCalculation ,
		AbsenceReason_Type_RefID = gfunct_L5LR_GLRFT_1643.FirstOrDefault().AbsenceReason_Type_RefID ,
		IsAllowedAbsence = gfunct_L5LR_GLRFT_1643.FirstOrDefault().IsAllowedAbsence ,
		IsDeactivated = gfunct_L5LR_GLRFT_1643.FirstOrDefault().IsDeactivated ,
		IsCarryOverEnabled = gfunct_L5LR_GLRFT_1643.FirstOrDefault().IsCarryOverEnabled ,
		IsCaryOverLimited = gfunct_L5LR_GLRFT_1643.FirstOrDefault().IsCaryOverLimited ,
		IfCarryOverLimited_MaximumAmount_Hrs = gfunct_L5LR_GLRFT_1643.FirstOrDefault().IfCarryOverLimited_MaximumAmount_Hrs ,
		CMN_BPT_EMP_Employee_LeaveRequestID = gfunct_L5LR_GLRFT_1643.Key.CMN_BPT_EMP_Employee_LeaveRequestID ,
		CMN_CAL_Event_RefID = gfunct_L5LR_GLRFT_1643.FirstOrDefault().CMN_CAL_Event_RefID ,
		CMN_CAL_Event_Approval_RefID = gfunct_L5LR_GLRFT_1643.FirstOrDefault().CMN_CAL_Event_Approval_RefID ,
		CMN_BPT_STA_AbsenceReason_RefID = gfunct_L5LR_GLRFT_1643.FirstOrDefault().CMN_BPT_STA_AbsenceReason_RefID ,
		Comment = gfunct_L5LR_GLRFT_1643.FirstOrDefault().Comment ,
		StartTime = gfunct_L5LR_GLRFT_1643.FirstOrDefault().StartTime ,
		EndTime = gfunct_L5LR_GLRFT_1643.FirstOrDefault().EndTime ,
		R_EventDuration_sec = gfunct_L5LR_GLRFT_1643.FirstOrDefault().R_EventDuration_sec ,
		CalendarInstance_RefID = gfunct_L5LR_GLRFT_1643.FirstOrDefault().CalendarInstance_RefID ,
		IsApprovalProcessDenied = gfunct_L5LR_GLRFT_1643.FirstOrDefault().IsApprovalProcessDenied ,
		ForEmployeeID = gfunct_L5LR_GLRFT_1643.FirstOrDefault().ForEmployeeID ,
		ForEmployee_BusinessParticipant_RefID = gfunct_L5LR_GLRFT_1643.FirstOrDefault().ForEmployee_BusinessParticipant_RefID ,
		ForEmployee_Staff_Number = gfunct_L5LR_GLRFT_1643.FirstOrDefault().ForEmployee_Staff_Number ,
		ForEmployee_StandardFunction = gfunct_L5LR_GLRFT_1643.FirstOrDefault().ForEmployee_StandardFunction ,
		IsApproved = gfunct_L5LR_GLRFT_1643.FirstOrDefault().IsApproved ,
		IsApprovalProcessOpened = gfunct_L5LR_GLRFT_1643.FirstOrDefault().IsApprovalProcessOpened ,
		IsApprovalProcessCanceledByUser = gfunct_L5LR_GLRFT_1643.FirstOrDefault().IsApprovalProcessCanceledByUser ,

		Convers = 
		(
			from el_Convers in gfunct_L5LR_GLRFT_1643.Where(element => !EqualsDefaultValue(element.BusinessParticipant_RefID)).ToArray()
			group el_Convers by new 
			{ 
				el_Convers.BusinessParticipant_RefID,

			}
			into gfunct_Convers
			select new L5LR_GLRFT_1643_Convers
			{     
				StandardFunction = gfunct_Convers.FirstOrDefault().StandardFunction ,
				BusinessParticipant_RefID = gfunct_Convers.Key.BusinessParticipant_RefID ,
				CMN_BPT_EMP_EmployeeID = gfunct_Convers.FirstOrDefault().CMN_BPT_EMP_EmployeeID ,
				SequenceNumber = gfunct_Convers.FirstOrDefault().SequenceNumber ,
				CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID = gfunct_Convers.FirstOrDefault().CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID ,

			}
		).ToArray(),
		Actions = 
		(
			from el_Actions in gfunct_L5LR_GLRFT_1643.Where(element => !EqualsDefaultValue(element.ActionTriggeredBy_Account_RefID)).ToArray()
			group el_Actions by new 
			{ 
				el_Actions.ActionTriggeredBy_Account_RefID,

			}
			into gfunct_Actions
			select new L5LR_GLRFT_1643_Actions
			{     
				ActionTriggeredBy_Account_RefID = gfunct_Actions.Key.ActionTriggeredBy_Account_RefID ,
				CMN_CAL_Event_Approval_ActionID = gfunct_Actions.FirstOrDefault().CMN_CAL_Event_Approval_ActionID ,
				IsApproval = gfunct_Actions.FirstOrDefault().IsApproval ,
				IsRevocation = gfunct_Actions.FirstOrDefault().IsRevocation ,
				IsDenial = gfunct_Actions.FirstOrDefault().IsDenial ,
				Approval_Action_Commnet = gfunct_Actions.FirstOrDefault().Approval_Action_Commnet ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5LR_GLRFT_1643_Array : FR_Base
	{
		public L5LR_GLRFT_1643[] Result	{ get; set; } 
		public FR_L5LR_GLRFT_1643_Array() : base() {}

		public FR_L5LR_GLRFT_1643_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5LR_GLRFT_1643_Array cls_Get_LeaveRequests_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5LR_GLRFT_1643_Array invocationResult = cls_Get_LeaveRequests_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
