/* 
 * Generated on 30.10.2014 11:31:24
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
    /// var result = cls_Get_AllAppointment_BaseData_for_Office_by_Type_from_Date.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllAppointment_BaseData_for_Office_by_Type_from_Date
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5A_GAABDfObTfD_1915_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5A_GAABDfObTfD_1915 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5A_GAABDfObTfD_1915_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.SQL.cls_Get_AllAppointment_BaseData_for_Office_by_Type_from_Date.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FromDate", Parameter.FromDate);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TaskTemplateID", Parameter.TaskTemplateID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OfficeID", Parameter.OfficeID);



			List<L5A_GAABDfObTfD_1915_raw> results = new List<L5A_GAABDfObTfD_1915_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_TSK_TaskID","PlannedStartDate","PlannedDuration_in_sec","CMN_BPT_EMP_Employee_RefID","PPS_DEV_Device_Instance_RefID" });
				while(reader.Read())
				{
					L5A_GAABDfObTfD_1915_raw resultItem = new L5A_GAABDfObTfD_1915_raw();
					//0:Parameter PPS_TSK_TaskID of type Guid
					resultItem.PPS_TSK_TaskID = reader.GetGuid(0);
					//1:Parameter PlannedStartDate of type DateTime
					resultItem.PlannedStartDate = reader.GetDate(1);
					//2:Parameter PlannedDuration_in_sec of type String
					resultItem.PlannedDuration_in_sec = reader.GetString(2);
					//3:Parameter CMN_BPT_EMP_Employee_RefID of type Guid
					resultItem.CMN_BPT_EMP_Employee_RefID = reader.GetGuid(3);
					//4:Parameter PPS_DEV_Device_Instance_RefID of type Guid
					resultItem.PPS_DEV_Device_Instance_RefID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllAppointment_BaseData_for_Office_by_Type_from_Date",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5A_GAABDfObTfD_1915_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5A_GAABDfObTfD_1915_Array Invoke(string ConnectionString,P_L5A_GAABDfObTfD_1915 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5A_GAABDfObTfD_1915_Array Invoke(DbConnection Connection,P_L5A_GAABDfObTfD_1915 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5A_GAABDfObTfD_1915_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5A_GAABDfObTfD_1915 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5A_GAABDfObTfD_1915_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5A_GAABDfObTfD_1915 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5A_GAABDfObTfD_1915_Array functionReturn = new FR_L5A_GAABDfObTfD_1915_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllAppointment_BaseData_for_Office_by_Type_from_Date",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5A_GAABDfObTfD_1915_raw 
	{
		public Guid PPS_TSK_TaskID; 
		public DateTime PlannedStartDate; 
		public String PlannedDuration_in_sec; 
		public Guid CMN_BPT_EMP_Employee_RefID; 
		public Guid PPS_DEV_Device_Instance_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5A_GAABDfObTfD_1915[] Convert(List<L5A_GAABDfObTfD_1915_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5A_GAABDfObTfD_1915 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.PPS_TSK_TaskID)).ToArray()
	group el_L5A_GAABDfObTfD_1915 by new 
	{ 
		el_L5A_GAABDfObTfD_1915.PPS_TSK_TaskID,

	}
	into gfunct_L5A_GAABDfObTfD_1915
	select new L5A_GAABDfObTfD_1915
	{     
		PPS_TSK_TaskID = gfunct_L5A_GAABDfObTfD_1915.Key.PPS_TSK_TaskID ,
		PlannedStartDate = gfunct_L5A_GAABDfObTfD_1915.FirstOrDefault().PlannedStartDate ,
		PlannedDuration_in_sec = gfunct_L5A_GAABDfObTfD_1915.FirstOrDefault().PlannedDuration_in_sec ,

		StaffIDList = 
		(
			from el_StaffIDList in gfunct_L5A_GAABDfObTfD_1915.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_Employee_RefID)).ToArray()
			group el_StaffIDList by new 
			{ 
				el_StaffIDList.CMN_BPT_EMP_Employee_RefID,

			}
			into gfunct_StaffIDList
			select new L5A_GAABDfObTfD_1915_StaffID
			{     
				CMN_BPT_EMP_Employee_RefID = gfunct_StaffIDList.Key.CMN_BPT_EMP_Employee_RefID ,

			}
		).ToArray(),
		DeviceIDList = 
		(
			from el_DeviceIDList in gfunct_L5A_GAABDfObTfD_1915.Where(element => !EqualsDefaultValue(element.PPS_DEV_Device_Instance_RefID)).ToArray()
			group el_DeviceIDList by new 
			{ 
				el_DeviceIDList.PPS_DEV_Device_Instance_RefID,

			}
			into gfunct_DeviceIDList
			select new L5A_GAABDfObTfD_1915_DeviceID
			{     
				PPS_DEV_Device_Instance_RefID = gfunct_DeviceIDList.Key.PPS_DEV_Device_Instance_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5A_GAABDfObTfD_1915_Array : FR_Base
	{
		public L5A_GAABDfObTfD_1915[] Result	{ get; set; } 
		public FR_L5A_GAABDfObTfD_1915_Array() : base() {}

		public FR_L5A_GAABDfObTfD_1915_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5A_GAABDfObTfD_1915 for attribute P_L5A_GAABDfObTfD_1915
		[DataContract]
		public class P_L5A_GAABDfObTfD_1915 
		{
			//Standard type parameters
			[DataMember]
			public DateTime FromDate { get; set; } 
			[DataMember]
			public Guid TaskTemplateID { get; set; } 
			[DataMember]
			public Guid OfficeID { get; set; } 

		}
		#endregion
		#region SClass L5A_GAABDfObTfD_1915 for attribute L5A_GAABDfObTfD_1915
		[DataContract]
		public class L5A_GAABDfObTfD_1915 
		{
			[DataMember]
			public L5A_GAABDfObTfD_1915_StaffID[] StaffIDList { get; set; }
			[DataMember]
			public L5A_GAABDfObTfD_1915_DeviceID[] DeviceIDList { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_TaskID { get; set; } 
			[DataMember]
			public DateTime PlannedStartDate { get; set; } 
			[DataMember]
			public String PlannedDuration_in_sec { get; set; } 

		}
		#endregion
		#region SClass L5A_GAABDfObTfD_1915_StaffID for attribute StaffIDList
		[DataContract]
		public class L5A_GAABDfObTfD_1915_StaffID 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_EMP_Employee_RefID { get; set; } 

		}
		#endregion
		#region SClass L5A_GAABDfObTfD_1915_DeviceID for attribute DeviceIDList
		[DataContract]
		public class L5A_GAABDfObTfD_1915_DeviceID 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_DEV_Device_Instance_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5A_GAABDfObTfD_1915_Array cls_Get_AllAppointment_BaseData_for_Office_by_Type_from_Date(,P_L5A_GAABDfObTfD_1915 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5A_GAABDfObTfD_1915_Array invocationResult = cls_Get_AllAppointment_BaseData_for_Office_by_Type_from_Date.Invoke(connectionString,P_L5A_GAABDfObTfD_1915 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.P_L5A_GAABDfObTfD_1915();
parameter.FromDate = ...;
parameter.TaskTemplateID = ...;
parameter.OfficeID = ...;

*/
