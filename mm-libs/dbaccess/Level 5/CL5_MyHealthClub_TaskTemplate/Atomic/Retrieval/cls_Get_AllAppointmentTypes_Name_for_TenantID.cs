/* 
 * Generated on 02.02.2015 16:37:04
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
    /// var result = cls_Get_AllAppointmentTypes_Name_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllAppointmentTypes_Name_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ATW_ANfTID_1855_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ATW_ANfTID_1855_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.SQL.cls_Get_AllAppointmentTypes_Name_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5ATW_ANfTID_1855_raw> results = new List<L5ATW_ANfTID_1855_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_TSK_Task_TemplateID","TaskTemplateName_DictID","Duration_EstimatedMax_in_sec","PPS_TSK_Task_RequiredStaffID","Required_Employee_RefID","CMN_STR_Profession_RefID","StaffQuantity","CMN_STR_Skill_RefID","DEV_Device_RefID","RequiredQuantity","PPS_TSK_Task_Template_ExcludedAvailabilityTypeID" });
				while(reader.Read())
				{
					L5ATW_ANfTID_1855_raw resultItem = new L5ATW_ANfTID_1855_raw();
					//0:Parameter PPS_TSK_Task_TemplateID of type Guid
					resultItem.PPS_TSK_Task_TemplateID = reader.GetGuid(0);
					//1:Parameter TaskTemplateName of type Dict
					resultItem.TaskTemplateName = reader.GetDictionary(1);
					resultItem.TaskTemplateName.SourceTable = "pps_tsk_task_templates";
					loader.Append(resultItem.TaskTemplateName);
					//2:Parameter Duration_EstimatedMax_in_sec of type Double
					resultItem.Duration_EstimatedMax_in_sec = reader.GetDouble(2);
					//3:Parameter PPS_TSK_Task_RequiredStaffID of type Guid
					resultItem.PPS_TSK_Task_RequiredStaffID = reader.GetGuid(3);
					//4:Parameter Required_Employee_RefID of type Guid
					resultItem.Required_Employee_RefID = reader.GetGuid(4);
					//5:Parameter CMN_STR_Profession_RefID of type Guid
					resultItem.CMN_STR_Profession_RefID = reader.GetGuid(5);
					//6:Parameter StaffQuantity of type int
					resultItem.StaffQuantity = reader.GetInteger(6);
					//7:Parameter CMN_STR_Skill_RefID of type Guid
					resultItem.CMN_STR_Skill_RefID = reader.GetGuid(7);
					//8:Parameter DEV_Device_RefID of type Guid
					resultItem.DEV_Device_RefID = reader.GetGuid(8);
					//9:Parameter RequiredQuantity of type int
					resultItem.RequiredQuantity = reader.GetInteger(9);
					//10:Parameter PPS_TSK_Task_Template_ExcludedAvailabilityTypeID of type Guid
					resultItem.PPS_TSK_Task_Template_ExcludedAvailabilityTypeID = reader.GetGuid(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllAppointmentTypes_Name_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5ATW_ANfTID_1855_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ATW_ANfTID_1855_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ATW_ANfTID_1855_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ATW_ANfTID_1855_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ATW_ANfTID_1855_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ATW_ANfTID_1855_Array functionReturn = new FR_L5ATW_ANfTID_1855_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllAppointmentTypes_Name_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5ATW_ANfTID_1855_raw 
	{
		public Guid PPS_TSK_Task_TemplateID; 
		public Dict TaskTemplateName; 
		public Double Duration_EstimatedMax_in_sec; 
		public Guid PPS_TSK_Task_RequiredStaffID; 
		public Guid Required_Employee_RefID; 
		public Guid CMN_STR_Profession_RefID; 
		public int StaffQuantity; 
		public Guid CMN_STR_Skill_RefID; 
		public Guid DEV_Device_RefID; 
		public int RequiredQuantity; 
		public Guid PPS_TSK_Task_Template_ExcludedAvailabilityTypeID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ATW_ANfTID_1855[] Convert(List<L5ATW_ANfTID_1855_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ATW_ANfTID_1855 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_TemplateID)).ToArray()
	group el_L5ATW_ANfTID_1855 by new 
	{ 
		el_L5ATW_ANfTID_1855.PPS_TSK_Task_TemplateID,

	}
	into gfunct_L5ATW_ANfTID_1855
	select new L5ATW_ANfTID_1855
	{     
		PPS_TSK_Task_TemplateID = gfunct_L5ATW_ANfTID_1855.Key.PPS_TSK_Task_TemplateID ,
		TaskTemplateName = gfunct_L5ATW_ANfTID_1855.FirstOrDefault().TaskTemplateName ,
		Duration_EstimatedMax_in_sec = gfunct_L5ATW_ANfTID_1855.FirstOrDefault().Duration_EstimatedMax_in_sec ,

		Required_Employee = 
		(
			from el_Required_Employee in gfunct_L5ATW_ANfTID_1855.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_RequiredStaffID)).ToArray()
			group el_Required_Employee by new 
			{ 
				el_Required_Employee.PPS_TSK_Task_RequiredStaffID,

			}
			into gfunct_Required_Employee
			select new L5ATW_ANfTID_1855_staff
			{     
				PPS_TSK_Task_RequiredStaffID = gfunct_Required_Employee.Key.PPS_TSK_Task_RequiredStaffID ,
				Required_Employee_RefID = gfunct_Required_Employee.FirstOrDefault().Required_Employee_RefID ,
				CMN_STR_Profession_RefID = gfunct_Required_Employee.FirstOrDefault().CMN_STR_Profession_RefID ,
				StaffQuantity = gfunct_Required_Employee.FirstOrDefault().StaffQuantity ,

				Skills = 
				(
					from el_Skills in gfunct_Required_Employee.Where(element => !EqualsDefaultValue(element.CMN_STR_Skill_RefID)).ToArray()
					group el_Skills by new 
					{ 
						el_Skills.CMN_STR_Skill_RefID,

					}
					into gfunct_Skills
					select new L5ATW_ANfTID_1855_Skill
					{     
						CMN_STR_Skill_RefID = gfunct_Skills.Key.CMN_STR_Skill_RefID ,

					}
				).ToArray(),

			}
		).ToArray(),
		Device = 
		(
			from el_Device in gfunct_L5ATW_ANfTID_1855.Where(element => !EqualsDefaultValue(element.DEV_Device_RefID)).ToArray()
			group el_Device by new 
			{ 
				el_Device.DEV_Device_RefID,

			}
			into gfunct_Device
			select new L5ATW_ANfTID_1855_Device
			{     
				DEV_Device_RefID = gfunct_Device.Key.DEV_Device_RefID ,
				RequiredQuantity = gfunct_Device.FirstOrDefault().RequiredQuantity ,

			}
		).ToArray(),
		RegularType = 
		(
			from el_RegularType in gfunct_L5ATW_ANfTID_1855.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_Template_ExcludedAvailabilityTypeID)).ToArray()
			group el_RegularType by new 
			{ 
				el_RegularType.PPS_TSK_Task_Template_ExcludedAvailabilityTypeID,

			}
			into gfunct_RegularType
			select new L5ATW_ANfTID_1855_RegularType
			{     
				PPS_TSK_Task_Template_ExcludedAvailabilityTypeID = gfunct_RegularType.Key.PPS_TSK_Task_Template_ExcludedAvailabilityTypeID ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ATW_ANfTID_1855_Array : FR_Base
	{
		public L5ATW_ANfTID_1855[] Result	{ get; set; } 
		public FR_L5ATW_ANfTID_1855_Array() : base() {}

		public FR_L5ATW_ANfTID_1855_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5ATW_ANfTID_1855 for attribute L5ATW_ANfTID_1855
		[DataContract]
		public class L5ATW_ANfTID_1855 
		{
			[DataMember]
			public L5ATW_ANfTID_1855_staff[] Required_Employee { get; set; }
			[DataMember]
			public L5ATW_ANfTID_1855_Device[] Device { get; set; }
			[DataMember]
			public L5ATW_ANfTID_1855_RegularType RegularType { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_TemplateID { get; set; } 
			[DataMember]
			public Dict TaskTemplateName { get; set; } 
			[DataMember]
			public Double Duration_EstimatedMax_in_sec { get; set; } 

		}
		#endregion
		#region SClass L5ATW_ANfTID_1855_staff for attribute Required_Employee
		[DataContract]
		public class L5ATW_ANfTID_1855_staff 
		{
			[DataMember]
			public L5ATW_ANfTID_1855_Skill[] Skills { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_RequiredStaffID { get; set; } 
			[DataMember]
			public Guid Required_Employee_RefID { get; set; } 
			[DataMember]
			public Guid CMN_STR_Profession_RefID { get; set; } 
			[DataMember]
			public int StaffQuantity { get; set; } 

		}
		#endregion
		#region SClass L5ATW_ANfTID_1855_Skill for attribute Skills
		[DataContract]
		public class L5ATW_ANfTID_1855_Skill 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_Skill_RefID { get; set; } 

		}
		#endregion
		#region SClass L5ATW_ANfTID_1855_Device for attribute Device
		[DataContract]
		public class L5ATW_ANfTID_1855_Device 
		{
			//Standard type parameters
			[DataMember]
			public Guid DEV_Device_RefID { get; set; } 
			[DataMember]
			public int RequiredQuantity { get; set; } 

		}
		#endregion
		#region SClass L5ATW_ANfTID_1855_RegularType for attribute RegularType
		[DataContract]
		public class L5ATW_ANfTID_1855_RegularType 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_Template_ExcludedAvailabilityTypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ATW_ANfTID_1855_Array cls_Get_AllAppointmentTypes_Name_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ATW_ANfTID_1855_Array invocationResult = cls_Get_AllAppointmentTypes_Name_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

