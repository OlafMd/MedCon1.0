/* 
 * Generated on 7/29/2014 1:04:50 PM
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

namespace CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AppointmentType_MainData_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AppointmentType_MainData_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AT_GATMDfTID_0922_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AT_GATMDfTID_0922_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.SQL.cls_Get_AppointmentType_MainData_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5AT_GATMDfTID_0922_raw> results = new List<L5AT_GATMDfTID_0922_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_TSK_Task_TemplateID","Duration_EstimatedMax_in_sec","TaskTemplateName_DictID","Duration_Recommended_in_sec","isNotWebBookable","PPS_TSK_Task_Template_RequiredDeviceID","DeviceQuantity","DeviceDisplayName","PPS_TSK_Task_RequiredStaffID","PPS_TSK_Task_RequiredStaff_ProfessionID","ProfessionName_DictID","Required_Employee_RefID","ReqEmployeeFirstName","ReqEmployeeLastName","EmployeeTitle","StaffQuantity","PPS_TSK_Task_RequiredStaff_SkillID","Skill_Name_DictID" });
				while(reader.Read())
				{
					L5AT_GATMDfTID_0922_raw resultItem = new L5AT_GATMDfTID_0922_raw();
					//0:Parameter PPS_TSK_Task_TemplateID of type Guid
					resultItem.PPS_TSK_Task_TemplateID = reader.GetGuid(0);
					//1:Parameter Duration_EstimatedMax_in_sec of type long
					resultItem.Duration_EstimatedMax_in_sec = reader.GetLong(1);
					//2:Parameter TaskTemplateName of type Dict
					resultItem.TaskTemplateName = reader.GetDictionary(2);
					resultItem.TaskTemplateName.SourceTable = "pps_tsk_task_templates";
					loader.Append(resultItem.TaskTemplateName);
					//3:Parameter Duration_Recommended_in_sec of type long
					resultItem.Duration_Recommended_in_sec = reader.GetLong(3);
					//4:Parameter isNotWebBookable of type Guid
					resultItem.isNotWebBookable = reader.GetGuid(4);
					//5:Parameter PPS_TSK_Task_Template_RequiredDeviceID of type Guid
					resultItem.PPS_TSK_Task_Template_RequiredDeviceID = reader.GetGuid(5);
					//6:Parameter DeviceQuantity of type String
					resultItem.DeviceQuantity = reader.GetString(6);
					//7:Parameter DeviceDisplayName of type String
					resultItem.DeviceDisplayName = reader.GetString(7);
					//8:Parameter PPS_TSK_Task_RequiredStaffID of type Guid
					resultItem.PPS_TSK_Task_RequiredStaffID = reader.GetGuid(8);
					//9:Parameter PPS_TSK_Task_RequiredStaff_ProfessionID of type Guid
					resultItem.PPS_TSK_Task_RequiredStaff_ProfessionID = reader.GetGuid(9);
					//10:Parameter ProfessionName of type Dict
					resultItem.ProfessionName = reader.GetDictionary(10);
					resultItem.ProfessionName.SourceTable = "cmn_str_professions";
					loader.Append(resultItem.ProfessionName);
					//11:Parameter Required_Employee_RefID of type Guid
					resultItem.Required_Employee_RefID = reader.GetGuid(11);
					//12:Parameter ReqEmployeeFirstName of type String
					resultItem.ReqEmployeeFirstName = reader.GetString(12);
					//13:Parameter ReqEmployeeLastName of type String
					resultItem.ReqEmployeeLastName = reader.GetString(13);
					//14:Parameter EmployeeTitle of type String
					resultItem.EmployeeTitle = reader.GetString(14);
					//15:Parameter StaffQuantity of type int
					resultItem.StaffQuantity = reader.GetInteger(15);
					//16:Parameter PPS_TSK_Task_RequiredStaff_SkillID of type Guid
					resultItem.PPS_TSK_Task_RequiredStaff_SkillID = reader.GetGuid(16);
					//17:Parameter Skill_Name of type Dict
					resultItem.Skill_Name = reader.GetDictionary(17);
					resultItem.Skill_Name.SourceTable = "cmn_str_skills";
					loader.Append(resultItem.Skill_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AppointmentType_MainData_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AT_GATMDfTID_0922_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AT_GATMDfTID_0922_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AT_GATMDfTID_0922_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AT_GATMDfTID_0922_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AT_GATMDfTID_0922_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AT_GATMDfTID_0922_Array functionReturn = new FR_L5AT_GATMDfTID_0922_Array();
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

				throw new Exception("Exception occured in method cls_Get_AppointmentType_MainData_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AT_GATMDfTID_0922_raw 
	{
		public Guid PPS_TSK_Task_TemplateID; 
		public long Duration_EstimatedMax_in_sec; 
		public Dict TaskTemplateName; 
		public long Duration_Recommended_in_sec; 
		public Guid isNotWebBookable; 
		public Guid PPS_TSK_Task_Template_RequiredDeviceID; 
		public String DeviceQuantity; 
		public String DeviceDisplayName; 
		public Guid PPS_TSK_Task_RequiredStaffID; 
		public Guid PPS_TSK_Task_RequiredStaff_ProfessionID; 
		public Dict ProfessionName; 
		public Guid Required_Employee_RefID; 
		public String ReqEmployeeFirstName; 
		public String ReqEmployeeLastName; 
		public String EmployeeTitle; 
		public int StaffQuantity; 
		public Guid PPS_TSK_Task_RequiredStaff_SkillID; 
		public Dict Skill_Name; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AT_GATMDfTID_0922[] Convert(List<L5AT_GATMDfTID_0922_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AT_GATMDfTID_0922 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_TemplateID)).ToArray()
	group el_L5AT_GATMDfTID_0922 by new 
	{ 
		el_L5AT_GATMDfTID_0922.PPS_TSK_Task_TemplateID,

	}
	into gfunct_L5AT_GATMDfTID_0922
	select new L5AT_GATMDfTID_0922
	{     
		PPS_TSK_Task_TemplateID = gfunct_L5AT_GATMDfTID_0922.Key.PPS_TSK_Task_TemplateID ,
		Duration_EstimatedMax_in_sec = gfunct_L5AT_GATMDfTID_0922.FirstOrDefault().Duration_EstimatedMax_in_sec ,
		TaskTemplateName = gfunct_L5AT_GATMDfTID_0922.FirstOrDefault().TaskTemplateName ,
		Duration_Recommended_in_sec = gfunct_L5AT_GATMDfTID_0922.FirstOrDefault().Duration_Recommended_in_sec ,
		isNotWebBookable = gfunct_L5AT_GATMDfTID_0922.FirstOrDefault().isNotWebBookable ,

		Devices = 
		(
			from el_Devices in gfunct_L5AT_GATMDfTID_0922.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_Template_RequiredDeviceID)).ToArray()
			group el_Devices by new 
			{ 
				el_Devices.PPS_TSK_Task_Template_RequiredDeviceID,

			}
			into gfunct_Devices
			select new L5AT_GATMDfTID_0922_Device
			{     
				PPS_TSK_Task_Template_RequiredDeviceID = gfunct_Devices.Key.PPS_TSK_Task_Template_RequiredDeviceID ,
				DeviceQuantity = gfunct_Devices.FirstOrDefault().DeviceQuantity ,
				DeviceDisplayName = gfunct_Devices.FirstOrDefault().DeviceDisplayName ,

			}
		).ToArray(),
		Staff = 
		(
			from el_Staff in gfunct_L5AT_GATMDfTID_0922.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_RequiredStaffID)).ToArray()
			group el_Staff by new 
			{ 
				el_Staff.PPS_TSK_Task_RequiredStaffID,

			}
			into gfunct_Staff
			select new L5AT_GATMDfTID_0922_Staff
			{     
				PPS_TSK_Task_RequiredStaffID = gfunct_Staff.Key.PPS_TSK_Task_RequiredStaffID ,
				PPS_TSK_Task_RequiredStaff_ProfessionID = gfunct_Staff.FirstOrDefault().PPS_TSK_Task_RequiredStaff_ProfessionID ,
				ProfessionName = gfunct_Staff.FirstOrDefault().ProfessionName ,
				Required_Employee_RefID = gfunct_Staff.FirstOrDefault().Required_Employee_RefID ,
				ReqEmployeeFirstName = gfunct_Staff.FirstOrDefault().ReqEmployeeFirstName ,
				ReqEmployeeLastName = gfunct_Staff.FirstOrDefault().ReqEmployeeLastName ,
				EmployeeTitle = gfunct_Staff.FirstOrDefault().EmployeeTitle ,
				StaffQuantity = gfunct_Staff.FirstOrDefault().StaffQuantity ,

				StaffSkill = 
				(
					from el_StaffSkill in gfunct_Staff.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_RequiredStaff_SkillID)).ToArray()
					group el_StaffSkill by new 
					{ 
						el_StaffSkill.PPS_TSK_Task_RequiredStaff_SkillID,

					}
					into gfunct_StaffSkill
					select new L5AT_GATMDfTID_0922_Skill
					{     
						PPS_TSK_Task_RequiredStaff_SkillID = gfunct_StaffSkill.Key.PPS_TSK_Task_RequiredStaff_SkillID ,
						Skill_Name = gfunct_StaffSkill.FirstOrDefault().Skill_Name ,

					}
				).ToArray(),

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AT_GATMDfTID_0922_Array : FR_Base
	{
		public L5AT_GATMDfTID_0922[] Result	{ get; set; } 
		public FR_L5AT_GATMDfTID_0922_Array() : base() {}

		public FR_L5AT_GATMDfTID_0922_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5AT_GATMDfTID_0922 for attribute L5AT_GATMDfTID_0922
		[DataContract]
		public class L5AT_GATMDfTID_0922 
		{
			[DataMember]
			public L5AT_GATMDfTID_0922_Device[] Devices { get; set; }
			[DataMember]
			public L5AT_GATMDfTID_0922_Staff[] Staff { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_TemplateID { get; set; } 
			[DataMember]
			public long Duration_EstimatedMax_in_sec { get; set; } 
			[DataMember]
			public Dict TaskTemplateName { get; set; } 
			[DataMember]
			public long Duration_Recommended_in_sec { get; set; } 
			[DataMember]
			public Guid isNotWebBookable { get; set; } 

		}
		#endregion
		#region SClass L5AT_GATMDfTID_0922_Device for attribute Devices
		[DataContract]
		public class L5AT_GATMDfTID_0922_Device 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_Template_RequiredDeviceID { get; set; } 
			[DataMember]
			public String DeviceQuantity { get; set; } 
			[DataMember]
			public String DeviceDisplayName { get; set; } 

		}
		#endregion
		#region SClass L5AT_GATMDfTID_0922_Staff for attribute Staff
		[DataContract]
		public class L5AT_GATMDfTID_0922_Staff 
		{
			[DataMember]
			public L5AT_GATMDfTID_0922_Skill[] StaffSkill { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_RequiredStaffID { get; set; } 
			[DataMember]
			public Guid PPS_TSK_Task_RequiredStaff_ProfessionID { get; set; } 
			[DataMember]
			public Dict ProfessionName { get; set; } 
			[DataMember]
			public Guid Required_Employee_RefID { get; set; } 
			[DataMember]
			public String ReqEmployeeFirstName { get; set; } 
			[DataMember]
			public String ReqEmployeeLastName { get; set; } 
			[DataMember]
			public String EmployeeTitle { get; set; } 
			[DataMember]
			public int StaffQuantity { get; set; } 

		}
		#endregion
		#region SClass L5AT_GATMDfTID_0922_Skill for attribute StaffSkill
		[DataContract]
		public class L5AT_GATMDfTID_0922_Skill 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_RequiredStaff_SkillID { get; set; } 
			[DataMember]
			public Dict Skill_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AT_GATMDfTID_0922_Array cls_Get_AppointmentType_MainData_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AT_GATMDfTID_0922_Array invocationResult = cls_Get_AppointmentType_MainData_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

