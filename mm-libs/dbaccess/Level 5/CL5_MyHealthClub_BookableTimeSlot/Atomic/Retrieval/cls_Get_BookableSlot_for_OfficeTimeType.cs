/* 
 * Generated on 27.11.2014 11:45:44
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

namespace CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BookableSlot_for_OfficeTimeType.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BookableSlot_for_OfficeTimeType
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BTS_GBSfOTT_1618 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BTS_GBSfOTT_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BTS_GBSfOTT_1618();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval.SQL.cls_Get_BookableSlot_for_OfficeTimeType.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OfficeID", Parameter.OfficeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TypeID", Parameter.TypeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StartTime", Parameter.StartTime);



			List<L5BTS_GBSfOTT_1618_raw> results = new List<L5BTS_GBSfOTT_1618_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_TSK_BOK_BookableTimeSlotID","FreeSlotsForTaskTemplateITPL","FreeInterval_End","IsAvailable","PPS_TSK_BOK_AvailableResourceCombinationID","PPS_TSK_BOK_DeviceResourceID","PPS_DEV_Device_Instance_RefID","PPS_TSK_BOK_StaffResourceID","CMN_BPT_EMP_Employee_RefID","CreatedFor_TaskTemplateRequiredStaff_RefID" });
				while(reader.Read())
				{
					L5BTS_GBSfOTT_1618_raw resultItem = new L5BTS_GBSfOTT_1618_raw();
					//0:Parameter PPS_TSK_BOK_BookableTimeSlotID of type Guid
					resultItem.PPS_TSK_BOK_BookableTimeSlotID = reader.GetGuid(0);
					//1:Parameter FreeSlotsForTaskTemplateITPL of type string
					resultItem.FreeSlotsForTaskTemplateITPL = reader.GetString(1);
					//2:Parameter FreeInterval_End of type DateTime
					resultItem.FreeInterval_End = reader.GetDate(2);
					//3:Parameter IsAvailable of type bool
					resultItem.IsAvailable = reader.GetBoolean(3);
					//4:Parameter PPS_TSK_BOK_AvailableResourceCombinationID of type Guid
					resultItem.PPS_TSK_BOK_AvailableResourceCombinationID = reader.GetGuid(4);
					//5:Parameter PPS_TSK_BOK_DeviceResourceID of type Guid
					resultItem.PPS_TSK_BOK_DeviceResourceID = reader.GetGuid(5);
					//6:Parameter PPS_DEV_Device_Instance_RefID of type Guid
					resultItem.PPS_DEV_Device_Instance_RefID = reader.GetGuid(6);
					//7:Parameter PPS_TSK_BOK_StaffResourceID of type Guid
					resultItem.PPS_TSK_BOK_StaffResourceID = reader.GetGuid(7);
					//8:Parameter CMN_BPT_EMP_Employee_RefID of type Guid
					resultItem.CMN_BPT_EMP_Employee_RefID = reader.GetGuid(8);
					//9:Parameter CreatedFor_TaskTemplateRequiredStaff_RefID of type Guid
					resultItem.CreatedFor_TaskTemplateRequiredStaff_RefID = reader.GetGuid(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BookableSlot_for_OfficeTimeType",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5BTS_GBSfOTT_1618_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BTS_GBSfOTT_1618 Invoke(string ConnectionString,P_L5BTS_GBSfOTT_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BTS_GBSfOTT_1618 Invoke(DbConnection Connection,P_L5BTS_GBSfOTT_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BTS_GBSfOTT_1618 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BTS_GBSfOTT_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BTS_GBSfOTT_1618 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BTS_GBSfOTT_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BTS_GBSfOTT_1618 functionReturn = new FR_L5BTS_GBSfOTT_1618();
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

				throw new Exception("Exception occured in method cls_Get_BookableSlot_for_OfficeTimeType",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5BTS_GBSfOTT_1618_raw 
	{
		public Guid PPS_TSK_BOK_BookableTimeSlotID; 
		public string FreeSlotsForTaskTemplateITPL; 
		public DateTime FreeInterval_End; 
		public bool IsAvailable; 
		public Guid PPS_TSK_BOK_AvailableResourceCombinationID; 
		public Guid PPS_TSK_BOK_DeviceResourceID; 
		public Guid PPS_DEV_Device_Instance_RefID; 
		public Guid PPS_TSK_BOK_StaffResourceID; 
		public Guid CMN_BPT_EMP_Employee_RefID; 
		public Guid CreatedFor_TaskTemplateRequiredStaff_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5BTS_GBSfOTT_1618[] Convert(List<L5BTS_GBSfOTT_1618_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5BTS_GBSfOTT_1618 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.PPS_TSK_BOK_BookableTimeSlotID)).ToArray()
	group el_L5BTS_GBSfOTT_1618 by new 
	{ 
		el_L5BTS_GBSfOTT_1618.PPS_TSK_BOK_BookableTimeSlotID,

	}
	into gfunct_L5BTS_GBSfOTT_1618
	select new L5BTS_GBSfOTT_1618
	{     
		PPS_TSK_BOK_BookableTimeSlotID = gfunct_L5BTS_GBSfOTT_1618.Key.PPS_TSK_BOK_BookableTimeSlotID ,
		FreeSlotsForTaskTemplateITPL = gfunct_L5BTS_GBSfOTT_1618.FirstOrDefault().FreeSlotsForTaskTemplateITPL ,
		FreeInterval_End = gfunct_L5BTS_GBSfOTT_1618.FirstOrDefault().FreeInterval_End ,

		Combinations = 
		(
			from el_Combinations in gfunct_L5BTS_GBSfOTT_1618.Where(element => !EqualsDefaultValue(element.PPS_TSK_BOK_AvailableResourceCombinationID)).ToArray()
			group el_Combinations by new 
			{ 
				el_Combinations.PPS_TSK_BOK_AvailableResourceCombinationID,

			}
			into gfunct_Combinations
			select new L5BTS_GBSfOTT_1618_ResourceCombination
			{     
				IsAvailable = gfunct_Combinations.FirstOrDefault().IsAvailable ,
				PPS_TSK_BOK_AvailableResourceCombinationID = gfunct_Combinations.Key.PPS_TSK_BOK_AvailableResourceCombinationID ,

				Devices = 
				(
					from el_Devices in gfunct_Combinations.Where(element => !EqualsDefaultValue(element.PPS_TSK_BOK_DeviceResourceID)).ToArray()
					group el_Devices by new 
					{ 
						el_Devices.PPS_TSK_BOK_DeviceResourceID,

					}
					into gfunct_Devices
					select new L5BTS_GBSfOTT_1618_ResourceCombination_Device
					{     
						PPS_TSK_BOK_DeviceResourceID = gfunct_Devices.Key.PPS_TSK_BOK_DeviceResourceID ,
						PPS_DEV_Device_Instance_RefID = gfunct_Devices.FirstOrDefault().PPS_DEV_Device_Instance_RefID ,

					}
				).ToArray(),
				Staff = 
				(
					from el_Staff in gfunct_Combinations.Where(element => !EqualsDefaultValue(element.PPS_TSK_BOK_StaffResourceID)).ToArray()
					group el_Staff by new 
					{ 
						el_Staff.PPS_TSK_BOK_StaffResourceID,

					}
					into gfunct_Staff
					select new L5BTS_GBSfOTT_1618_ResourceCombination_Staff
					{     
						PPS_TSK_BOK_StaffResourceID = gfunct_Staff.Key.PPS_TSK_BOK_StaffResourceID ,
						CMN_BPT_EMP_Employee_RefID = gfunct_Staff.FirstOrDefault().CMN_BPT_EMP_Employee_RefID ,
						CreatedFor_TaskTemplateRequiredStaff_RefID = gfunct_Staff.FirstOrDefault().CreatedFor_TaskTemplateRequiredStaff_RefID ,

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
	public class FR_L5BTS_GBSfOTT_1618 : FR_Base
	{
		public L5BTS_GBSfOTT_1618 Result	{ get; set; }

		public FR_L5BTS_GBSfOTT_1618() : base() {}

		public FR_L5BTS_GBSfOTT_1618(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BTS_GBSfOTT_1618 for attribute P_L5BTS_GBSfOTT_1618
		[DataContract]
		public class P_L5BTS_GBSfOTT_1618 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Guid TypeID { get; set; } 
			[DataMember]
			public DateTime StartTime { get; set; } 

		}
		#endregion
		#region SClass L5BTS_GBSfOTT_1618 for attribute L5BTS_GBSfOTT_1618
		[DataContract]
		public class L5BTS_GBSfOTT_1618 
		{
			[DataMember]
			public L5BTS_GBSfOTT_1618_ResourceCombination[] Combinations { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_BOK_BookableTimeSlotID { get; set; } 
			[DataMember]
			public string FreeSlotsForTaskTemplateITPL { get; set; } 
			[DataMember]
			public DateTime FreeInterval_End { get; set; } 

		}
		#endregion
		#region SClass L5BTS_GBSfOTT_1618_ResourceCombination for attribute Combinations
		[DataContract]
		public class L5BTS_GBSfOTT_1618_ResourceCombination 
		{
			[DataMember]
			public L5BTS_GBSfOTT_1618_ResourceCombination_Device[] Devices { get; set; }
			[DataMember]
			public L5BTS_GBSfOTT_1618_ResourceCombination_Staff[] Staff { get; set; }

			//Standard type parameters
			[DataMember]
			public bool IsAvailable { get; set; } 
			[DataMember]
			public Guid PPS_TSK_BOK_AvailableResourceCombinationID { get; set; } 

		}
		#endregion
		#region SClass L5BTS_GBSfOTT_1618_ResourceCombination_Device for attribute Devices
		[DataContract]
		public class L5BTS_GBSfOTT_1618_ResourceCombination_Device 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_BOK_DeviceResourceID { get; set; } 
			[DataMember]
			public Guid PPS_DEV_Device_Instance_RefID { get; set; } 

		}
		#endregion
		#region SClass L5BTS_GBSfOTT_1618_ResourceCombination_Staff for attribute Staff
		[DataContract]
		public class L5BTS_GBSfOTT_1618_ResourceCombination_Staff 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_BOK_StaffResourceID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_EMP_Employee_RefID { get; set; } 
			[DataMember]
			public Guid CreatedFor_TaskTemplateRequiredStaff_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BTS_GBSfOTT_1618 cls_Get_BookableSlot_for_OfficeTimeType(,P_L5BTS_GBSfOTT_1618 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BTS_GBSfOTT_1618 invocationResult = cls_Get_BookableSlot_for_OfficeTimeType.Invoke(connectionString,P_L5BTS_GBSfOTT_1618 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval.P_L5BTS_GBSfOTT_1618();
parameter.OfficeID = ...;
parameter.TypeID = ...;
parameter.StartTime = ...;

*/
