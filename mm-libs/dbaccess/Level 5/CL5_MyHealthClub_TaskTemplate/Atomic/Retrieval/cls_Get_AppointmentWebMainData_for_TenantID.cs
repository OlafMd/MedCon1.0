/* 
 * Generated on 26.12.2014 19:45:37
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
    /// var result = cls_Get_AppointmentWebMainData_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AppointmentWebMainData_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AP_GAWMDfTID_1101_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AP_GAWMDfTID_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AP_GAWMDfTID_1101_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.SQL.cls_Get_AppointmentWebMainData_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Type", Parameter.Type);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TaskType", Parameter.TaskType);



			List<L5AP_GAWMDfTID_1101_raw> results = new List<L5AP_GAWMDfTID_1101_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TaskTemplateName_DictID","DisplayName","PPS_TSK_TaskID","Office_Name_DictID","PatientFirstName","PatientLastName","PatientBirthDay","PlannedStartDate","PlannedDuration_in_sec","AcademicTitle","PrimaryEmail","Content","DoctorID","DoctorFirstName","DoctorLastName","DoctorTitle","DoctorFlag","RequiredDoctorID","RequiredDoctorFirstName","RequiredDoctorLastName","RequiredDoctorTitle","RequiredDoctorFlag" });
				while(reader.Read())
				{
					L5AP_GAWMDfTID_1101_raw resultItem = new L5AP_GAWMDfTID_1101_raw();
					//0:Parameter TaskTemplateName of type Dict
					resultItem.TaskTemplateName = reader.GetDictionary(0);
					resultItem.TaskTemplateName.SourceTable = "pps_tsk_task_templates";
					loader.Append(resultItem.TaskTemplateName);
					//1:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(1);
					//2:Parameter PPS_TSK_TaskID of type Guid
					resultItem.PPS_TSK_TaskID = reader.GetGuid(2);
					//3:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(3);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//4:Parameter PatientFirstName of type String
					resultItem.PatientFirstName = reader.GetString(4);
					//5:Parameter PatientLastName of type String
					resultItem.PatientLastName = reader.GetString(5);
					//6:Parameter PatientBirthDay of type DateTime
					resultItem.PatientBirthDay = reader.GetDate(6);
					//7:Parameter PlannedStartDate of type DateTime
					resultItem.PlannedStartDate = reader.GetDate(7);
					//8:Parameter PlannedDuration_in_sec of type String
					resultItem.PlannedDuration_in_sec = reader.GetString(8);
					//9:Parameter AcademicTitle of type String
					resultItem.AcademicTitle = reader.GetString(9);
					//10:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(10);
					//11:Parameter Content of type String
					resultItem.Content = reader.GetString(11);
					//12:Parameter DoctorID of type Guid
					resultItem.DoctorID = reader.GetGuid(12);
					//13:Parameter DoctorFirstName of type String
					resultItem.DoctorFirstName = reader.GetString(13);
					//14:Parameter DoctorLastName of type String
					resultItem.DoctorLastName = reader.GetString(14);
					//15:Parameter DoctorTitle of type String
					resultItem.DoctorTitle = reader.GetString(15);
					//16:Parameter DoctorFlag of type Guid
					resultItem.DoctorFlag = reader.GetGuid(16);
					//17:Parameter RequiredDoctorID of type Guid
					resultItem.RequiredDoctorID = reader.GetGuid(17);
					//18:Parameter RequiredDoctorFirstName of type String
					resultItem.RequiredDoctorFirstName = reader.GetString(18);
					//19:Parameter RequiredDoctorLastName of type String
					resultItem.RequiredDoctorLastName = reader.GetString(19);
					//20:Parameter RequiredDoctorTitle of type String
					resultItem.RequiredDoctorTitle = reader.GetString(20);
					//21:Parameter RequiredDoctorFlag of type Guid
					resultItem.RequiredDoctorFlag = reader.GetGuid(21);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AppointmentWebMainData_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AP_GAWMDfTID_1101_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AP_GAWMDfTID_1101_Array Invoke(string ConnectionString,P_L5AP_GAWMDfTID_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AP_GAWMDfTID_1101_Array Invoke(DbConnection Connection,P_L5AP_GAWMDfTID_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AP_GAWMDfTID_1101_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AP_GAWMDfTID_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AP_GAWMDfTID_1101_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AP_GAWMDfTID_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AP_GAWMDfTID_1101_Array functionReturn = new FR_L5AP_GAWMDfTID_1101_Array();
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

				throw new Exception("Exception occured in method cls_Get_AppointmentWebMainData_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AP_GAWMDfTID_1101_raw 
	{
		public Dict TaskTemplateName; 
		public String DisplayName; 
		public Guid PPS_TSK_TaskID; 
		public Dict Office_Name; 
		public String PatientFirstName; 
		public String PatientLastName; 
		public DateTime PatientBirthDay; 
		public DateTime PlannedStartDate; 
		public String PlannedDuration_in_sec; 
		public String AcademicTitle; 
		public String PrimaryEmail; 
		public String Content; 
		public Guid DoctorID; 
		public String DoctorFirstName; 
		public String DoctorLastName; 
		public String DoctorTitle; 
		public Guid DoctorFlag; 
		public Guid RequiredDoctorID; 
		public String RequiredDoctorFirstName; 
		public String RequiredDoctorLastName; 
		public String RequiredDoctorTitle; 
		public Guid RequiredDoctorFlag; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AP_GAWMDfTID_1101[] Convert(List<L5AP_GAWMDfTID_1101_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AP_GAWMDfTID_1101 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.PPS_TSK_TaskID)).ToArray()
	group el_L5AP_GAWMDfTID_1101 by new 
	{ 
		el_L5AP_GAWMDfTID_1101.PPS_TSK_TaskID,

	}
	into gfunct_L5AP_GAWMDfTID_1101
	select new L5AP_GAWMDfTID_1101
	{     
		TaskTemplateName = gfunct_L5AP_GAWMDfTID_1101.FirstOrDefault().TaskTemplateName ,
		DisplayName = gfunct_L5AP_GAWMDfTID_1101.FirstOrDefault().DisplayName ,
		PPS_TSK_TaskID = gfunct_L5AP_GAWMDfTID_1101.Key.PPS_TSK_TaskID ,
		Office_Name = gfunct_L5AP_GAWMDfTID_1101.FirstOrDefault().Office_Name ,
		PatientFirstName = gfunct_L5AP_GAWMDfTID_1101.FirstOrDefault().PatientFirstName ,
		PatientLastName = gfunct_L5AP_GAWMDfTID_1101.FirstOrDefault().PatientLastName ,
		PatientBirthDay = gfunct_L5AP_GAWMDfTID_1101.FirstOrDefault().PatientBirthDay ,
		PlannedStartDate = gfunct_L5AP_GAWMDfTID_1101.FirstOrDefault().PlannedStartDate ,
		PlannedDuration_in_sec = gfunct_L5AP_GAWMDfTID_1101.FirstOrDefault().PlannedDuration_in_sec ,
		AcademicTitle = gfunct_L5AP_GAWMDfTID_1101.FirstOrDefault().AcademicTitle ,
		PrimaryEmail = gfunct_L5AP_GAWMDfTID_1101.FirstOrDefault().PrimaryEmail ,
		Content = gfunct_L5AP_GAWMDfTID_1101.FirstOrDefault().Content ,

		Doctor = 
		(
			from el_Doctor in gfunct_L5AP_GAWMDfTID_1101.Where(element => !EqualsDefaultValue(element.DoctorID)).ToArray()
			group el_Doctor by new 
			{ 
				el_Doctor.DoctorID,

			}
			into gfunct_Doctor
			select new L5AP_GAWMDfTID_1101_Doctor
			{     
				DoctorID = gfunct_Doctor.Key.DoctorID ,
				DoctorFirstName = gfunct_Doctor.FirstOrDefault().DoctorFirstName ,
				DoctorLastName = gfunct_Doctor.FirstOrDefault().DoctorLastName ,
				DoctorTitle = gfunct_Doctor.FirstOrDefault().DoctorTitle ,
				DoctorFlag = gfunct_Doctor.FirstOrDefault().DoctorFlag ,

			}
		).ToArray(),
		RequiredDoctor = 
		(
			from el_RequiredDoctor in gfunct_L5AP_GAWMDfTID_1101.Where(element => !EqualsDefaultValue(element.RequiredDoctorID)).ToArray()
			group el_RequiredDoctor by new 
			{ 
				el_RequiredDoctor.RequiredDoctorID,

			}
			into gfunct_RequiredDoctor
			select new L5AP_GAWMDfTID_1101_RequiredDoctor
			{     
				RequiredDoctorID = gfunct_RequiredDoctor.Key.RequiredDoctorID ,
				RequiredDoctorFirstName = gfunct_RequiredDoctor.FirstOrDefault().RequiredDoctorFirstName ,
				RequiredDoctorLastName = gfunct_RequiredDoctor.FirstOrDefault().RequiredDoctorLastName ,
				RequiredDoctorTitle = gfunct_RequiredDoctor.FirstOrDefault().RequiredDoctorTitle ,
				RequiredDoctorFlag = gfunct_RequiredDoctor.FirstOrDefault().RequiredDoctorFlag ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AP_GAWMDfTID_1101_Array : FR_Base
	{
		public L5AP_GAWMDfTID_1101[] Result	{ get; set; } 
		public FR_L5AP_GAWMDfTID_1101_Array() : base() {}

		public FR_L5AP_GAWMDfTID_1101_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AP_GAWMDfTID_1101 for attribute P_L5AP_GAWMDfTID_1101
		[DataContract]
		public class P_L5AP_GAWMDfTID_1101 
		{
			//Standard type parameters
			[DataMember]
			public String Type { get; set; } 
			[DataMember]
			public String TaskType { get; set; } 

		}
		#endregion
		#region SClass L5AP_GAWMDfTID_1101 for attribute L5AP_GAWMDfTID_1101
		[DataContract]
		public class L5AP_GAWMDfTID_1101 
		{
			[DataMember]
			public L5AP_GAWMDfTID_1101_Doctor[] Doctor { get; set; }
			[DataMember]
			public L5AP_GAWMDfTID_1101_RequiredDoctor[] RequiredDoctor { get; set; }

			//Standard type parameters
			[DataMember]
			public Dict TaskTemplateName { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Guid PPS_TSK_TaskID { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public String PatientFirstName { get; set; } 
			[DataMember]
			public String PatientLastName { get; set; } 
			[DataMember]
			public DateTime PatientBirthDay { get; set; } 
			[DataMember]
			public DateTime PlannedStartDate { get; set; } 
			[DataMember]
			public String PlannedDuration_in_sec { get; set; } 
			[DataMember]
			public String AcademicTitle { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String Content { get; set; } 

		}
		#endregion
		#region SClass L5AP_GAWMDfTID_1101_Doctor for attribute Doctor
		[DataContract]
		public class L5AP_GAWMDfTID_1101_Doctor 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public String DoctorFirstName { get; set; } 
			[DataMember]
			public String DoctorLastName { get; set; } 
			[DataMember]
			public String DoctorTitle { get; set; } 
			[DataMember]
			public Guid DoctorFlag { get; set; } 

		}
		#endregion
		#region SClass L5AP_GAWMDfTID_1101_RequiredDoctor for attribute RequiredDoctor
		[DataContract]
		public class L5AP_GAWMDfTID_1101_RequiredDoctor 
		{
			//Standard type parameters
			[DataMember]
			public Guid RequiredDoctorID { get; set; } 
			[DataMember]
			public String RequiredDoctorFirstName { get; set; } 
			[DataMember]
			public String RequiredDoctorLastName { get; set; } 
			[DataMember]
			public String RequiredDoctorTitle { get; set; } 
			[DataMember]
			public Guid RequiredDoctorFlag { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AP_GAWMDfTID_1101_Array cls_Get_AppointmentWebMainData_for_TenantID(,P_L5AP_GAWMDfTID_1101 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AP_GAWMDfTID_1101_Array invocationResult = cls_Get_AppointmentWebMainData_for_TenantID.Invoke(connectionString,P_L5AP_GAWMDfTID_1101 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.P_L5AP_GAWMDfTID_1101();
parameter.Type = ...;
parameter.TaskType = ...;

*/
