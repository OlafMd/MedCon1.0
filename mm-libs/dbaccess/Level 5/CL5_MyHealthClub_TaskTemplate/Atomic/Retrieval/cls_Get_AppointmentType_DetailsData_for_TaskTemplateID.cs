/* 
 * Generated on 7/29/2014 10:41:21 AM
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
    /// var result = cls_Get_AppointmentType_DetailsData_for_TaskTemplateID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AppointmentType_DetailsData_for_TaskTemplateID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AT_GATDDfTTID_1015 Execute(DbConnection Connection,DbTransaction Transaction,P_L5AT_GATDDfTTID_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AT_GATDDfTTID_1015();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.SQL.cls_Get_AppointmentType_DetailsData_for_TaskTemplateID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TaskTemplateID", Parameter.TaskTemplateID);



			List<L5AT_GATDDfTTID_1015_raw> results = new List<L5AT_GATDDfTTID_1015_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_TSK_Task_TemplateID","Duration_EstimatedMax_in_sec","TaskTemplateName_DictID","Duration_Recommended_in_sec","isNotWebBookable","PPS_TSK_Task_Template_RequiredDeviceID","TaskTemplate_RefID_Device","RequiredQuantity","DEV_Device_RefID","PPS_DEV_DeviceID","DeviceName_DictID","DeviceDisplayName","PPS_TSK_Task_RequiredStaffID","StaffQuantity","CMN_STR_Profession_RefID","ProfessionName_DictID","Required_Employee_RefID","CMN_STR_Skill_RefID","Skill_Name_DictID" });
				while(reader.Read())
				{
					L5AT_GATDDfTTID_1015_raw resultItem = new L5AT_GATDDfTTID_1015_raw();
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
					//6:Parameter TaskTemplate_RefID_Device of type Guid
					resultItem.TaskTemplate_RefID_Device = reader.GetGuid(6);
					//7:Parameter RequiredQuantity of type int
					resultItem.RequiredQuantity = reader.GetInteger(7);
					//8:Parameter DEV_Device_RefID of type Guid
					resultItem.DEV_Device_RefID = reader.GetGuid(8);
					//9:Parameter PPS_DEV_DeviceID of type Guid
					resultItem.PPS_DEV_DeviceID = reader.GetGuid(9);
					//10:Parameter DeviceName of type Dict
					resultItem.DeviceName = reader.GetDictionary(10);
					resultItem.DeviceName.SourceTable = "pps_dev_devices";
					loader.Append(resultItem.DeviceName);
					//11:Parameter DeviceDisplayName of type String
					resultItem.DeviceDisplayName = reader.GetString(11);
					//12:Parameter PPS_TSK_Task_RequiredStaffID of type Guid
					resultItem.PPS_TSK_Task_RequiredStaffID = reader.GetGuid(12);
					//13:Parameter StaffQuantity of type int
					resultItem.StaffQuantity = reader.GetInteger(13);
					//14:Parameter CMN_STR_Profession_RefID of type Guid
					resultItem.CMN_STR_Profession_RefID = reader.GetGuid(14);
					//15:Parameter ProfessionName of type Dict
					resultItem.ProfessionName = reader.GetDictionary(15);
					resultItem.ProfessionName.SourceTable = "cmn_str_professions";
					loader.Append(resultItem.ProfessionName);
					//16:Parameter Required_Employee_RefID of type Guid
					resultItem.Required_Employee_RefID = reader.GetGuid(16);
					//17:Parameter CMN_STR_Skill_RefID of type Guid
					resultItem.CMN_STR_Skill_RefID = reader.GetGuid(17);
					//18:Parameter Skill_Name of type Dict
					resultItem.Skill_Name = reader.GetDictionary(18);
					resultItem.Skill_Name.SourceTable = "cmn_str_skills";
					loader.Append(resultItem.Skill_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AppointmentType_DetailsData_for_TaskTemplateID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AT_GATDDfTTID_1015_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AT_GATDDfTTID_1015 Invoke(string ConnectionString,P_L5AT_GATDDfTTID_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AT_GATDDfTTID_1015 Invoke(DbConnection Connection,P_L5AT_GATDDfTTID_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AT_GATDDfTTID_1015 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AT_GATDDfTTID_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AT_GATDDfTTID_1015 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AT_GATDDfTTID_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AT_GATDDfTTID_1015 functionReturn = new FR_L5AT_GATDDfTTID_1015();
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

				throw new Exception("Exception occured in method cls_Get_AppointmentType_DetailsData_for_TaskTemplateID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AT_GATDDfTTID_1015_raw 
	{
		public Guid PPS_TSK_Task_TemplateID; 
		public long Duration_EstimatedMax_in_sec; 
		public Dict TaskTemplateName; 
		public long Duration_Recommended_in_sec; 
		public Guid isNotWebBookable; 
		public Guid PPS_TSK_Task_Template_RequiredDeviceID; 
		public Guid TaskTemplate_RefID_Device; 
		public int RequiredQuantity; 
		public Guid DEV_Device_RefID; 
		public Guid PPS_DEV_DeviceID; 
		public Dict DeviceName; 
		public String DeviceDisplayName; 
		public Guid PPS_TSK_Task_RequiredStaffID; 
		public int StaffQuantity; 
		public Guid CMN_STR_Profession_RefID; 
		public Dict ProfessionName; 
		public Guid Required_Employee_RefID; 
		public Guid CMN_STR_Skill_RefID; 
		public Dict Skill_Name; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AT_GATDDfTTID_1015[] Convert(List<L5AT_GATDDfTTID_1015_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AT_GATDDfTTID_1015 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_TemplateID)).ToArray()
	group el_L5AT_GATDDfTTID_1015 by new 
	{ 
		el_L5AT_GATDDfTTID_1015.PPS_TSK_Task_TemplateID,

	}
	into gfunct_L5AT_GATDDfTTID_1015
	select new L5AT_GATDDfTTID_1015
	{     
		PPS_TSK_Task_TemplateID = gfunct_L5AT_GATDDfTTID_1015.Key.PPS_TSK_Task_TemplateID ,
		Duration_EstimatedMax_in_sec = gfunct_L5AT_GATDDfTTID_1015.FirstOrDefault().Duration_EstimatedMax_in_sec ,
		TaskTemplateName = gfunct_L5AT_GATDDfTTID_1015.FirstOrDefault().TaskTemplateName ,
		Duration_Recommended_in_sec = gfunct_L5AT_GATDDfTTID_1015.FirstOrDefault().Duration_Recommended_in_sec ,
		isNotWebBookable = gfunct_L5AT_GATDDfTTID_1015.FirstOrDefault().isNotWebBookable ,

		Devices = 
		(
			from el_Devices in gfunct_L5AT_GATDDfTTID_1015.Where(element => !EqualsDefaultValue(element.PPS_DEV_DeviceID)).ToArray()
			group el_Devices by new 
			{ 
				el_Devices.PPS_DEV_DeviceID,

			}
			into gfunct_Devices
			select new L5AT_GATDDfTTID_1015_Device
			{     
				PPS_TSK_Task_Template_RequiredDeviceID = gfunct_Devices.FirstOrDefault().PPS_TSK_Task_Template_RequiredDeviceID ,
				TaskTemplate_RefID_Device = gfunct_Devices.FirstOrDefault().TaskTemplate_RefID_Device ,
				RequiredQuantity = gfunct_Devices.FirstOrDefault().RequiredQuantity ,
				DEV_Device_RefID = gfunct_Devices.FirstOrDefault().DEV_Device_RefID ,
				PPS_DEV_DeviceID = gfunct_Devices.Key.PPS_DEV_DeviceID ,
				DeviceName = gfunct_Devices.FirstOrDefault().DeviceName ,
				DeviceDisplayName = gfunct_Devices.FirstOrDefault().DeviceDisplayName ,

			}
		).ToArray(),
		ReqSkillsAndProfession = 
		(
			from el_ReqSkillsAndProfession in gfunct_L5AT_GATDDfTTID_1015.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_RequiredStaffID)).ToArray()
			group el_ReqSkillsAndProfession by new 
			{ 
				el_ReqSkillsAndProfession.PPS_TSK_Task_RequiredStaffID,

			}
			into gfunct_ReqSkillsAndProfession
			select new L5AT_GATDDfTTID_1015_ReqSkillsAndProfession
			{     
				PPS_TSK_Task_RequiredStaffID = gfunct_ReqSkillsAndProfession.Key.PPS_TSK_Task_RequiredStaffID ,
				StaffQuantity = gfunct_ReqSkillsAndProfession.FirstOrDefault().StaffQuantity ,
				CMN_STR_Profession_RefID = gfunct_ReqSkillsAndProfession.FirstOrDefault().CMN_STR_Profession_RefID ,
				ProfessionName = gfunct_ReqSkillsAndProfession.FirstOrDefault().ProfessionName ,
				Required_Employee_RefID = gfunct_ReqSkillsAndProfession.FirstOrDefault().Required_Employee_RefID ,

				ReqSkills = 
				(
					from el_ReqSkills in gfunct_ReqSkillsAndProfession.Where(element => !EqualsDefaultValue(element.CMN_STR_Skill_RefID)).ToArray()
					group el_ReqSkills by new 
					{ 
						el_ReqSkills.CMN_STR_Skill_RefID,

					}
					into gfunct_ReqSkills
					select new L5AT_GATDDfTTID_1015_ReqSkills
					{     
						CMN_STR_Skill_RefID = gfunct_ReqSkills.Key.CMN_STR_Skill_RefID ,
						Skill_Name = gfunct_ReqSkills.FirstOrDefault().Skill_Name ,

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
	public class FR_L5AT_GATDDfTTID_1015 : FR_Base
	{
		public L5AT_GATDDfTTID_1015 Result	{ get; set; }

		public FR_L5AT_GATDDfTTID_1015() : base() {}

		public FR_L5AT_GATDDfTTID_1015(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AT_GATDDfTTID_1015 for attribute P_L5AT_GATDDfTTID_1015
		[DataContract]
		public class P_L5AT_GATDDfTTID_1015 
		{
			//Standard type parameters
			[DataMember]
			public Guid TaskTemplateID { get; set; } 

		}
		#endregion
		#region SClass L5AT_GATDDfTTID_1015 for attribute L5AT_GATDDfTTID_1015
		[DataContract]
		public class L5AT_GATDDfTTID_1015 
		{
			[DataMember]
			public L5AT_GATDDfTTID_1015_Device[] Devices { get; set; }
			[DataMember]
			public L5AT_GATDDfTTID_1015_ReqSkillsAndProfession[] ReqSkillsAndProfession { get; set; }

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
		#region SClass L5AT_GATDDfTTID_1015_Device for attribute Devices
		[DataContract]
		public class L5AT_GATDDfTTID_1015_Device 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_Template_RequiredDeviceID { get; set; } 
			[DataMember]
			public Guid TaskTemplate_RefID_Device { get; set; } 
			[DataMember]
			public int RequiredQuantity { get; set; } 
			[DataMember]
			public Guid DEV_Device_RefID { get; set; } 
			[DataMember]
			public Guid PPS_DEV_DeviceID { get; set; } 
			[DataMember]
			public Dict DeviceName { get; set; } 
			[DataMember]
			public String DeviceDisplayName { get; set; } 

		}
		#endregion
		#region SClass L5AT_GATDDfTTID_1015_ReqSkillsAndProfession for attribute ReqSkillsAndProfession
		[DataContract]
		public class L5AT_GATDDfTTID_1015_ReqSkillsAndProfession 
		{
			[DataMember]
			public L5AT_GATDDfTTID_1015_ReqSkills[] ReqSkills { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_RequiredStaffID { get; set; } 
			[DataMember]
			public int StaffQuantity { get; set; } 
			[DataMember]
			public Guid CMN_STR_Profession_RefID { get; set; } 
			[DataMember]
			public Dict ProfessionName { get; set; } 
			[DataMember]
			public Guid Required_Employee_RefID { get; set; } 

		}
		#endregion
		#region SClass L5AT_GATDDfTTID_1015_ReqSkills for attribute ReqSkills
		[DataContract]
		public class L5AT_GATDDfTTID_1015_ReqSkills 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_Skill_RefID { get; set; } 
			[DataMember]
			public Dict Skill_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AT_GATDDfTTID_1015 cls_Get_AppointmentType_DetailsData_for_TaskTemplateID(,P_L5AT_GATDDfTTID_1015 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AT_GATDDfTTID_1015 invocationResult = cls_Get_AppointmentType_DetailsData_for_TaskTemplateID.Invoke(connectionString,P_L5AT_GATDDfTTID_1015 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.P_L5AT_GATDDfTTID_1015();
parameter.TaskTemplateID = ...;

*/
