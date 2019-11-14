/* 
 * Generated on 08.12.2014 16:26:45
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
    /// var result = cls_Get_AllAppointment_Task_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllAppointment_Task_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5A_GAATfTID_1430_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5A_GAATfTID_1430_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.SQL.cls_Get_AllAppointment_Task_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5A_GAATfTID_1430_raw> results = new List<L5A_GAATfTID_1430_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_TSK_TaskID","InstantiatedFrom_TaskTemplate_RefID","DisplayName","PlannedStartDate","PlannedDuration_in_sec","PPS_TSK_Task_StaffBookingsID","PPS_TSK_Task_RefID","CMN_BPT_EMP_Employee_RefID","CreatedFrom_TaskTemplate_RequiredStaff_RefID","PPS_TSK_Task_OfficeBookingID","PPS_TSK_Task_RefID_Office","CMN_STR_Office_RefID","PPS_TSK_Task_DeviceBookingID","PPS_TSK_Task_RefID_Device","PPS_DEV_Device_Instance_RefID","HEC_APP_AppointmentID","Ext_PPS_TSK_Task_RefID","HEC_ACT_PlannedActionID","Patient_RefID" });
				while(reader.Read())
				{
					L5A_GAATfTID_1430_raw resultItem = new L5A_GAATfTID_1430_raw();
					//0:Parameter PPS_TSK_TaskID of type Guid
					resultItem.PPS_TSK_TaskID = reader.GetGuid(0);
					//1:Parameter InstantiatedFrom_TaskTemplate_RefID of type Guid
					resultItem.InstantiatedFrom_TaskTemplate_RefID = reader.GetGuid(1);
					//2:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(2);
					//3:Parameter PlannedStartDate of type DateTime
					resultItem.PlannedStartDate = reader.GetDate(3);
					//4:Parameter PlannedDuration_in_sec of type String
					resultItem.PlannedDuration_in_sec = reader.GetString(4);
					//5:Parameter PPS_TSK_Task_StaffBookingsID of type Guid
					resultItem.PPS_TSK_Task_StaffBookingsID = reader.GetGuid(5);
					//6:Parameter PPS_TSK_Task_RefID of type Guid
					resultItem.PPS_TSK_Task_RefID = reader.GetGuid(6);
					//7:Parameter CMN_BPT_EMP_Employee_RefID of type Guid
					resultItem.CMN_BPT_EMP_Employee_RefID = reader.GetGuid(7);
					//8:Parameter CreatedFrom_TaskTemplate_RequiredStaff_RefID of type Guid
					resultItem.CreatedFrom_TaskTemplate_RequiredStaff_RefID = reader.GetGuid(8);
					//9:Parameter PPS_TSK_Task_OfficeBookingID of type Guid
					resultItem.PPS_TSK_Task_OfficeBookingID = reader.GetGuid(9);
					//10:Parameter PPS_TSK_Task_RefID_Office of type Guid
					resultItem.PPS_TSK_Task_RefID_Office = reader.GetGuid(10);
					//11:Parameter CMN_STR_Office_RefID of type Guid
					resultItem.CMN_STR_Office_RefID = reader.GetGuid(11);
					//12:Parameter PPS_TSK_Task_DeviceBookingID of type Guid
					resultItem.PPS_TSK_Task_DeviceBookingID = reader.GetGuid(12);
					//13:Parameter PPS_TSK_Task_RefID_Device of type Guid
					resultItem.PPS_TSK_Task_RefID_Device = reader.GetGuid(13);
					//14:Parameter PPS_DEV_Device_Instance_RefID of type Guid
					resultItem.PPS_DEV_Device_Instance_RefID = reader.GetGuid(14);
					//15:Parameter HEC_APP_AppointmentID of type Guid
					resultItem.HEC_APP_AppointmentID = reader.GetGuid(15);
					//16:Parameter Ext_PPS_TSK_Task_RefID of type Guid
					resultItem.Ext_PPS_TSK_Task_RefID = reader.GetGuid(16);
					//17:Parameter HEC_ACT_PlannedActionID of type Guid
					resultItem.HEC_ACT_PlannedActionID = reader.GetGuid(17);
					//18:Parameter Patient_RefID of type Guid
					resultItem.Patient_RefID = reader.GetGuid(18);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllAppointment_Task_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5A_GAATfTID_1430_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5A_GAATfTID_1430_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5A_GAATfTID_1430_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5A_GAATfTID_1430_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5A_GAATfTID_1430_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5A_GAATfTID_1430_Array functionReturn = new FR_L5A_GAATfTID_1430_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllAppointment_Task_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5A_GAATfTID_1430_raw 
	{
		public Guid PPS_TSK_TaskID; 
		public Guid InstantiatedFrom_TaskTemplate_RefID; 
		public String DisplayName; 
		public DateTime PlannedStartDate; 
		public String PlannedDuration_in_sec; 
		public Guid PPS_TSK_Task_StaffBookingsID; 
		public Guid PPS_TSK_Task_RefID; 
		public Guid CMN_BPT_EMP_Employee_RefID; 
		public Guid CreatedFrom_TaskTemplate_RequiredStaff_RefID; 
		public Guid PPS_TSK_Task_OfficeBookingID; 
		public Guid PPS_TSK_Task_RefID_Office; 
		public Guid CMN_STR_Office_RefID; 
		public Guid PPS_TSK_Task_DeviceBookingID; 
		public Guid PPS_TSK_Task_RefID_Device; 
		public Guid PPS_DEV_Device_Instance_RefID; 
		public Guid HEC_APP_AppointmentID; 
		public Guid Ext_PPS_TSK_Task_RefID; 
		public Guid HEC_ACT_PlannedActionID; 
		public Guid Patient_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5A_GAATfTID_1430[] Convert(List<L5A_GAATfTID_1430_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5A_GAATfTID_1430 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.PPS_TSK_TaskID)).ToArray()
	group el_L5A_GAATfTID_1430 by new 
	{ 
		el_L5A_GAATfTID_1430.PPS_TSK_TaskID,

	}
	into gfunct_L5A_GAATfTID_1430
	select new L5A_GAATfTID_1430
	{     
		PPS_TSK_TaskID = gfunct_L5A_GAATfTID_1430.Key.PPS_TSK_TaskID ,
		InstantiatedFrom_TaskTemplate_RefID = gfunct_L5A_GAATfTID_1430.FirstOrDefault().InstantiatedFrom_TaskTemplate_RefID ,
		DisplayName = gfunct_L5A_GAATfTID_1430.FirstOrDefault().DisplayName ,
		PlannedStartDate = gfunct_L5A_GAATfTID_1430.FirstOrDefault().PlannedStartDate ,
		PlannedDuration_in_sec = gfunct_L5A_GAATfTID_1430.FirstOrDefault().PlannedDuration_in_sec ,

		Staff = 
		(
			from el_Staff in gfunct_L5A_GAATfTID_1430.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_Employee_RefID)).ToArray()
			group el_Staff by new 
			{ 
				el_Staff.CMN_BPT_EMP_Employee_RefID,

			}
			into gfunct_Staff
			select new L5A_GAATfTID_1430_Staff
			{     
				PPS_TSK_Task_StaffBookingsID = gfunct_Staff.FirstOrDefault().PPS_TSK_Task_StaffBookingsID ,
				PPS_TSK_Task_RefID = gfunct_Staff.FirstOrDefault().PPS_TSK_Task_RefID ,
				CMN_BPT_EMP_Employee_RefID = gfunct_Staff.Key.CMN_BPT_EMP_Employee_RefID ,
				CreatedFrom_TaskTemplate_RequiredStaff_RefID = gfunct_Staff.FirstOrDefault().CreatedFrom_TaskTemplate_RequiredStaff_RefID ,

			}
		).ToArray(),
		Offices = 
		(
			from el_Offices in gfunct_L5A_GAATfTID_1430.Where(element => !EqualsDefaultValue(element.CMN_STR_Office_RefID)).ToArray()
			group el_Offices by new 
			{ 
				el_Offices.CMN_STR_Office_RefID,

			}
			into gfunct_Offices
			select new L5A_GAATfTID_1430_Office
			{     
				PPS_TSK_Task_OfficeBookingID = gfunct_Offices.FirstOrDefault().PPS_TSK_Task_OfficeBookingID ,
				PPS_TSK_Task_RefID_Office = gfunct_Offices.FirstOrDefault().PPS_TSK_Task_RefID_Office ,
				CMN_STR_Office_RefID = gfunct_Offices.Key.CMN_STR_Office_RefID ,

			}
		).FirstOrDefault(),
		Devices = 
		(
			from el_Devices in gfunct_L5A_GAATfTID_1430.Where(element => !EqualsDefaultValue(element.PPS_DEV_Device_Instance_RefID)).ToArray()
			group el_Devices by new 
			{ 
				el_Devices.PPS_DEV_Device_Instance_RefID,

			}
			into gfunct_Devices
			select new L5A_GAATfTID_1430_Device
			{     
				PPS_TSK_Task_DeviceBookingID = gfunct_Devices.FirstOrDefault().PPS_TSK_Task_DeviceBookingID ,
				PPS_TSK_Task_RefID_Device = gfunct_Devices.FirstOrDefault().PPS_TSK_Task_RefID_Device ,
				PPS_DEV_Device_Instance_RefID = gfunct_Devices.Key.PPS_DEV_Device_Instance_RefID ,

			}
		).ToArray(),
		Patients = 
		(
			from el_Patients in gfunct_L5A_GAATfTID_1430.Where(element => !EqualsDefaultValue(element.Patient_RefID)).ToArray()
			group el_Patients by new 
			{ 
				el_Patients.Patient_RefID,

			}
			into gfunct_Patients
			select new L5A_GAATfTID_1430_Patient
			{     
				HEC_APP_AppointmentID = gfunct_Patients.FirstOrDefault().HEC_APP_AppointmentID ,
				Ext_PPS_TSK_Task_RefID = gfunct_Patients.FirstOrDefault().Ext_PPS_TSK_Task_RefID ,
				HEC_ACT_PlannedActionID = gfunct_Patients.FirstOrDefault().HEC_ACT_PlannedActionID ,
				Patient_RefID = gfunct_Patients.Key.Patient_RefID ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5A_GAATfTID_1430_Array : FR_Base
	{
		public L5A_GAATfTID_1430[] Result	{ get; set; } 
		public FR_L5A_GAATfTID_1430_Array() : base() {}

		public FR_L5A_GAATfTID_1430_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5A_GAATfTID_1430 for attribute L5A_GAATfTID_1430
		[DataContract]
		public class L5A_GAATfTID_1430 
		{
			[DataMember]
			public L5A_GAATfTID_1430_Staff[] Staff { get; set; }
			[DataMember]
			public L5A_GAATfTID_1430_Office Offices { get; set; }
			[DataMember]
			public L5A_GAATfTID_1430_Device[] Devices { get; set; }
			[DataMember]
			public L5A_GAATfTID_1430_Patient Patients { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_TaskID { get; set; } 
			[DataMember]
			public Guid InstantiatedFrom_TaskTemplate_RefID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public DateTime PlannedStartDate { get; set; } 
			[DataMember]
			public String PlannedDuration_in_sec { get; set; } 

		}
		#endregion
		#region SClass L5A_GAATfTID_1430_Staff for attribute Staff
		[DataContract]
		public class L5A_GAATfTID_1430_Staff 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_StaffBookingsID { get; set; } 
			[DataMember]
			public Guid PPS_TSK_Task_RefID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_EMP_Employee_RefID { get; set; } 
			[DataMember]
			public Guid CreatedFrom_TaskTemplate_RequiredStaff_RefID { get; set; } 

		}
		#endregion
		#region SClass L5A_GAATfTID_1430_Office for attribute Offices
		[DataContract]
		public class L5A_GAATfTID_1430_Office 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_OfficeBookingID { get; set; } 
			[DataMember]
			public Guid PPS_TSK_Task_RefID_Office { get; set; } 
			[DataMember]
			public Guid CMN_STR_Office_RefID { get; set; } 

		}
		#endregion
		#region SClass L5A_GAATfTID_1430_Device for attribute Devices
		[DataContract]
		public class L5A_GAATfTID_1430_Device 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_DeviceBookingID { get; set; } 
			[DataMember]
			public Guid PPS_TSK_Task_RefID_Device { get; set; } 
			[DataMember]
			public Guid PPS_DEV_Device_Instance_RefID { get; set; } 

		}
		#endregion
		#region SClass L5A_GAATfTID_1430_Patient for attribute Patients
		[DataContract]
		public class L5A_GAATfTID_1430_Patient 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_APP_AppointmentID { get; set; } 
			[DataMember]
			public Guid Ext_PPS_TSK_Task_RefID { get; set; } 
			[DataMember]
			public Guid HEC_ACT_PlannedActionID { get; set; } 
			[DataMember]
			public Guid Patient_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5A_GAATfTID_1430_Array cls_Get_AllAppointment_Task_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5A_GAATfTID_1430_Array invocationResult = cls_Get_AllAppointment_Task_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

